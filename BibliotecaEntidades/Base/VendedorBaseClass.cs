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
     [Table("vendedor","ven")]
     public class VendedorBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do VendedorClass";
protected const string ErroDelete = "Erro ao excluir o VendedorClass  ";
protected const string ErroSave = "Erro ao salvar o VendedorClass.";
protected const string ErroCollectionClienteClassVendedor = "Erro ao carregar a coleção de ClienteClass.";
protected const string ErroCollectionContaPagarClassVendedor = "Erro ao carregar a coleção de ContaPagarClass.";
protected const string ErroCollectionCredorDevedorClassVendedor = "Erro ao carregar a coleção de CredorDevedorClass.";
protected const string ErroCollectionOrcamentoItemClassVendedor = "Erro ao carregar a coleção de OrcamentoItemClass.";
protected const string ErroCollectionPedidoItemClassVendedor = "Erro ao carregar a coleção de PedidoItemClass.";
protected const string ErroCollectionRepresentanteClassVendedor = "Erro ao carregar a coleção de RepresentanteClass.";
protected const string ErroRazaoSocialObrigatorio = "O campo RazaoSocial é obrigatório";
protected const string ErroCnpjObrigatorio = "O campo Cnpj é obrigatório";
protected const string ErroCnpjComprimento = "O campo Cnpj deve ter no máximo 20 caracteres";
protected const string ErroInscricaoEstadualObrigatorio = "O campo InscricaoEstadual é obrigatório";
protected const string ErroInscricaoEstadualComprimento = "O campo InscricaoEstadual deve ter no máximo 50 caracteres";
protected const string ErroEnderecoObrigatorio = "O campo Endereco é obrigatório";
protected const string ErroEnderecoComprimento = "O campo Endereco deve ter no máximo 255 caracteres";
protected const string ErroEnderecoNumeroObrigatorio = "O campo EnderecoNumero é obrigatório";
protected const string ErroEnderecoNumeroComprimento = "O campo EnderecoNumero deve ter no máximo 50 caracteres";
protected const string ErroBairroObrigatorio = "O campo Bairro é obrigatório";
protected const string ErroBairroComprimento = "O campo Bairro deve ter no máximo 50 caracteres";
protected const string ErroCepObrigatorio = "O campo Cep é obrigatório";
protected const string ErroCepComprimento = "O campo Cep deve ter no máximo 10 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroCidadeObrigatorio = "O campo Cidade é obrigatório";
protected const string ErroContaBancariaObrigatorio = "O campo ContaBancaria é obrigatório";
protected const string ErroCentroCustoLucroObrigatorio = "O campo CentroCustoLucro é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do VendedorClass.";
protected const string MensagemUtilizadoCollectionClienteClassVendedor =  "A entidade VendedorClass está sendo utilizada nos seguintes ClienteClass:";
protected const string MensagemUtilizadoCollectionContaPagarClassVendedor =  "A entidade VendedorClass está sendo utilizada nos seguintes ContaPagarClass:";
protected const string MensagemUtilizadoCollectionCredorDevedorClassVendedor =  "A entidade VendedorClass está sendo utilizada nos seguintes CredorDevedorClass:";
protected const string MensagemUtilizadoCollectionOrcamentoItemClassVendedor =  "A entidade VendedorClass está sendo utilizada nos seguintes OrcamentoItemClass:";
protected const string MensagemUtilizadoCollectionPedidoItemClassVendedor =  "A entidade VendedorClass está sendo utilizada nos seguintes PedidoItemClass:";
protected const string MensagemUtilizadoCollectionRepresentanteClassVendedor =  "A entidade VendedorClass está sendo utilizada nos seguintes RepresentanteClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade VendedorClass está sendo utilizada.";
#endregion
       protected TipoPessoa _tipoPessoaOriginal{get;private set;}
       private TipoPessoa _tipoPessoaOriginalCommited{get; set;}
        private TipoPessoa _valueTipoPessoa;
         [Column("ven_tipo_pessoa")]
        public virtual TipoPessoa TipoPessoa
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
            get { return this._valueTipoPessoa == BibliotecaEntidades.Base.TipoPessoa.PJ; } 
            set { if (value) this._valueTipoPessoa = BibliotecaEntidades.Base.TipoPessoa.PJ; }
         } 

        public bool TipoPessoa_PF
         { 
            get { return this._valueTipoPessoa == BibliotecaEntidades.Base.TipoPessoa.PF; } 
            set { if (value) this._valueTipoPessoa = BibliotecaEntidades.Base.TipoPessoa.PF; }
         } 

       protected string _razaoSocialOriginal{get;private set;}
       private string _razaoSocialOriginalCommited{get; set;}
        private string _valueRazaoSocial;
         [Column("ven_razao_social")]
        public virtual string RazaoSocial
         { 
            get { return this._valueRazaoSocial; } 
            set 
            { 
                if (this._valueRazaoSocial == value)return;
                 this._valueRazaoSocial = value; 
            } 
        } 

       protected string _cnpjOriginal{get;private set;}
       private string _cnpjOriginalCommited{get; set;}
        private string _valueCnpj;
         [Column("ven_cnpj")]
        public virtual string Cnpj
         { 
            get { return this._valueCnpj; } 
            set 
            { 
                if (this._valueCnpj == value)return;
                 this._valueCnpj = value; 
            } 
        } 

       protected string _inscricaoEstadualOriginal{get;private set;}
       private string _inscricaoEstadualOriginalCommited{get; set;}
        private string _valueInscricaoEstadual;
         [Column("ven_inscricao_estadual")]
        public virtual string InscricaoEstadual
         { 
            get { return this._valueInscricaoEstadual; } 
            set 
            { 
                if (this._valueInscricaoEstadual == value)return;
                 this._valueInscricaoEstadual = value; 
            } 
        } 

       protected string _inscricaoMunicipalOriginal{get;private set;}
       private string _inscricaoMunicipalOriginalCommited{get; set;}
        private string _valueInscricaoMunicipal;
         [Column("ven_inscricao_municipal")]
        public virtual string InscricaoMunicipal
         { 
            get { return this._valueInscricaoMunicipal; } 
            set 
            { 
                if (this._valueInscricaoMunicipal == value)return;
                 this._valueInscricaoMunicipal = value; 
            } 
        } 

       protected string _enderecoOriginal{get;private set;}
       private string _enderecoOriginalCommited{get; set;}
        private string _valueEndereco;
         [Column("ven_endereco")]
        public virtual string Endereco
         { 
            get { return this._valueEndereco; } 
            set 
            { 
                if (this._valueEndereco == value)return;
                 this._valueEndereco = value; 
            } 
        } 

       protected string _enderecoNumeroOriginal{get;private set;}
       private string _enderecoNumeroOriginalCommited{get; set;}
        private string _valueEnderecoNumero;
         [Column("ven_endereco_numero")]
        public virtual string EnderecoNumero
         { 
            get { return this._valueEnderecoNumero; } 
            set 
            { 
                if (this._valueEnderecoNumero == value)return;
                 this._valueEnderecoNumero = value; 
            } 
        } 

       protected string _enderecoComplementoOriginal{get;private set;}
       private string _enderecoComplementoOriginalCommited{get; set;}
        private string _valueEnderecoComplemento;
         [Column("ven_endereco_complemento")]
        public virtual string EnderecoComplemento
         { 
            get { return this._valueEnderecoComplemento; } 
            set 
            { 
                if (this._valueEnderecoComplemento == value)return;
                 this._valueEnderecoComplemento = value; 
            } 
        } 

       protected string _bairroOriginal{get;private set;}
       private string _bairroOriginalCommited{get; set;}
        private string _valueBairro;
         [Column("ven_bairro")]
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
         [Column("ven_cep")]
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
         [Column("ven_fone1")]
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
         [Column("ven_fone2")]
        public virtual string Fone2
         { 
            get { return this._valueFone2; } 
            set 
            { 
                if (this._valueFone2 == value)return;
                 this._valueFone2 = value; 
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

       protected string _emailOriginal{get;private set;}
       private string _emailOriginalCommited{get; set;}
        private string _valueEmail;
         [Column("ven_email")]
        public virtual string Email
         { 
            get { return this._valueEmail; } 
            set 
            { 
                if (this._valueEmail == value)return;
                 this._valueEmail = value; 
            } 
        } 

       protected bool _envioEmailOriginal{get;private set;}
       private bool _envioEmailOriginalCommited{get; set;}
        private bool _valueEnvioEmail;
         [Column("ven_envio_email")]
        public virtual bool EnvioEmail
         { 
            get { return this._valueEnvioEmail; } 
            set 
            { 
                if (this._valueEnvioEmail == value)return;
                 this._valueEnvioEmail = value; 
            } 
        } 

       protected string _bancoOriginal{get;private set;}
       private string _bancoOriginalCommited{get; set;}
        private string _valueBanco;
         [Column("ven_banco")]
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
         [Column("ven_agencia")]
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
         [Column("ven_conta")]
        public virtual string Conta
         { 
            get { return this._valueConta; } 
            set 
            { 
                if (this._valueConta == value)return;
                 this._valueConta = value; 
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

       protected double _comissaoOriginal{get;private set;}
       private double _comissaoOriginalCommited{get; set;}
        private double _valueComissao;
         [Column("ven_comissao")]
        public virtual double Comissao
         { 
            get { return this._valueComissao; } 
            set 
            { 
                if (this._valueComissao == value)return;
                 this._valueComissao = value; 
            } 
        } 

       private List<long> _collectionClienteClassVendedorOriginal;
       private List<Entidades.ClienteClass > _collectionClienteClassVendedorRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionClienteClassVendedorLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionClienteClassVendedorChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionClienteClassVendedorCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ClienteClass> _valueCollectionClienteClassVendedor { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ClienteClass> CollectionClienteClassVendedor 
       { 
           get { if(!_valueCollectionClienteClassVendedorLoaded && !this.DisableLoadCollection){this.LoadCollectionClienteClassVendedor();}
return this._valueCollectionClienteClassVendedor; } 
           set 
           { 
               this._valueCollectionClienteClassVendedor = value; 
               this._valueCollectionClienteClassVendedorLoaded = true; 
           } 
       } 

       private List<long> _collectionContaPagarClassVendedorOriginal;
       private List<Entidades.ContaPagarClass > _collectionContaPagarClassVendedorRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaPagarClassVendedorLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaPagarClassVendedorChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaPagarClassVendedorCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ContaPagarClass> _valueCollectionContaPagarClassVendedor { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ContaPagarClass> CollectionContaPagarClassVendedor 
       { 
           get { if(!_valueCollectionContaPagarClassVendedorLoaded && !this.DisableLoadCollection){this.LoadCollectionContaPagarClassVendedor();}
return this._valueCollectionContaPagarClassVendedor; } 
           set 
           { 
               this._valueCollectionContaPagarClassVendedor = value; 
               this._valueCollectionContaPagarClassVendedorLoaded = true; 
           } 
       } 

       private List<long> _collectionCredorDevedorClassVendedorOriginal;
       private List<Entidades.CredorDevedorClass > _collectionCredorDevedorClassVendedorRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionCredorDevedorClassVendedorLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionCredorDevedorClassVendedorChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionCredorDevedorClassVendedorCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.CredorDevedorClass> _valueCollectionCredorDevedorClassVendedor { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.CredorDevedorClass> CollectionCredorDevedorClassVendedor 
       { 
           get { if(!_valueCollectionCredorDevedorClassVendedorLoaded && !this.DisableLoadCollection){this.LoadCollectionCredorDevedorClassVendedor();}
return this._valueCollectionCredorDevedorClassVendedor; } 
           set 
           { 
               this._valueCollectionCredorDevedorClassVendedor = value; 
               this._valueCollectionCredorDevedorClassVendedorLoaded = true; 
           } 
       } 

       private List<long> _collectionOrcamentoItemClassVendedorOriginal;
       private List<Entidades.OrcamentoItemClass > _collectionOrcamentoItemClassVendedorRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoItemClassVendedorLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoItemClassVendedorChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoItemClassVendedorCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrcamentoItemClass> _valueCollectionOrcamentoItemClassVendedor { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrcamentoItemClass> CollectionOrcamentoItemClassVendedor 
       { 
           get { if(!_valueCollectionOrcamentoItemClassVendedorLoaded && !this.DisableLoadCollection){this.LoadCollectionOrcamentoItemClassVendedor();}
return this._valueCollectionOrcamentoItemClassVendedor; } 
           set 
           { 
               this._valueCollectionOrcamentoItemClassVendedor = value; 
               this._valueCollectionOrcamentoItemClassVendedorLoaded = true; 
           } 
       } 

       private List<long> _collectionPedidoItemClassVendedorOriginal;
       private List<Entidades.PedidoItemClass > _collectionPedidoItemClassVendedorRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassVendedorLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassVendedorChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassVendedorCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PedidoItemClass> _valueCollectionPedidoItemClassVendedor { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PedidoItemClass> CollectionPedidoItemClassVendedor 
       { 
           get { if(!_valueCollectionPedidoItemClassVendedorLoaded && !this.DisableLoadCollection){this.LoadCollectionPedidoItemClassVendedor();}
return this._valueCollectionPedidoItemClassVendedor; } 
           set 
           { 
               this._valueCollectionPedidoItemClassVendedor = value; 
               this._valueCollectionPedidoItemClassVendedorLoaded = true; 
           } 
       } 

       private List<long> _collectionRepresentanteClassVendedorOriginal;
       private List<Entidades.RepresentanteClass > _collectionRepresentanteClassVendedorRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionRepresentanteClassVendedorLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionRepresentanteClassVendedorChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionRepresentanteClassVendedorCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.RepresentanteClass> _valueCollectionRepresentanteClassVendedor { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.RepresentanteClass> CollectionRepresentanteClassVendedor 
       { 
           get { if(!_valueCollectionRepresentanteClassVendedorLoaded && !this.DisableLoadCollection){this.LoadCollectionRepresentanteClassVendedor();}
return this._valueCollectionRepresentanteClassVendedor; } 
           set 
           { 
               this._valueCollectionRepresentanteClassVendedor = value; 
               this._valueCollectionRepresentanteClassVendedorLoaded = true; 
           } 
       } 

        public VendedorBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.TipoPessoa = (TipoPessoa)0;
           this.EnvioEmail = false;
           this.Comissao = 0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static VendedorClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (VendedorClass) GetEntity(typeof(VendedorClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionClienteClassVendedorChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionClienteClassVendedorChanged = true;
                  _valueCollectionClienteClassVendedorCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionClienteClassVendedorChanged = true; 
                  _valueCollectionClienteClassVendedorCommitedChanged = true;
                 foreach (Entidades.ClienteClass item in e.OldItems) 
                 { 
                     _collectionClienteClassVendedorRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionClienteClassVendedorChanged = true; 
                  _valueCollectionClienteClassVendedorCommitedChanged = true;
                 foreach (Entidades.ClienteClass item in _valueCollectionClienteClassVendedor) 
                 { 
                     _collectionClienteClassVendedorRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionClienteClassVendedor()
         {
            try
            {
                 ObservableCollection<Entidades.ClienteClass> oc;
                _valueCollectionClienteClassVendedorChanged = false;
                 _valueCollectionClienteClassVendedorCommitedChanged = false;
                _collectionClienteClassVendedorRemovidos = new List<Entidades.ClienteClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ClienteClass>();
                }
                else{ 
                   Entidades.ClienteClass search = new Entidades.ClienteClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ClienteClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Vendedor", this),                     }                       ).Cast<Entidades.ClienteClass>().ToList());
                 }
                 _valueCollectionClienteClassVendedor = new BindingList<Entidades.ClienteClass>(oc); 
                 _collectionClienteClassVendedorOriginal= (from a in _valueCollectionClienteClassVendedor select a.ID).ToList();
                 _valueCollectionClienteClassVendedorLoaded = true;
                 oc.CollectionChanged += CollectionClienteClassVendedorChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionClienteClassVendedor+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionContaPagarClassVendedorChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionContaPagarClassVendedorChanged = true;
                  _valueCollectionContaPagarClassVendedorCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionContaPagarClassVendedorChanged = true; 
                  _valueCollectionContaPagarClassVendedorCommitedChanged = true;
                 foreach (Entidades.ContaPagarClass item in e.OldItems) 
                 { 
                     _collectionContaPagarClassVendedorRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionContaPagarClassVendedorChanged = true; 
                  _valueCollectionContaPagarClassVendedorCommitedChanged = true;
                 foreach (Entidades.ContaPagarClass item in _valueCollectionContaPagarClassVendedor) 
                 { 
                     _collectionContaPagarClassVendedorRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionContaPagarClassVendedor()
         {
            try
            {
                 ObservableCollection<Entidades.ContaPagarClass> oc;
                _valueCollectionContaPagarClassVendedorChanged = false;
                 _valueCollectionContaPagarClassVendedorCommitedChanged = false;
                _collectionContaPagarClassVendedorRemovidos = new List<Entidades.ContaPagarClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ContaPagarClass>();
                }
                else{ 
                   Entidades.ContaPagarClass search = new Entidades.ContaPagarClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ContaPagarClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Vendedor", this),                     }                       ).Cast<Entidades.ContaPagarClass>().ToList());
                 }
                 _valueCollectionContaPagarClassVendedor = new BindingList<Entidades.ContaPagarClass>(oc); 
                 _collectionContaPagarClassVendedorOriginal= (from a in _valueCollectionContaPagarClassVendedor select a.ID).ToList();
                 _valueCollectionContaPagarClassVendedorLoaded = true;
                 oc.CollectionChanged += CollectionContaPagarClassVendedorChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionContaPagarClassVendedor+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionCredorDevedorClassVendedorChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionCredorDevedorClassVendedorChanged = true;
                  _valueCollectionCredorDevedorClassVendedorCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionCredorDevedorClassVendedorChanged = true; 
                  _valueCollectionCredorDevedorClassVendedorCommitedChanged = true;
                 foreach (Entidades.CredorDevedorClass item in e.OldItems) 
                 { 
                     _collectionCredorDevedorClassVendedorRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionCredorDevedorClassVendedorChanged = true; 
                  _valueCollectionCredorDevedorClassVendedorCommitedChanged = true;
                 foreach (Entidades.CredorDevedorClass item in _valueCollectionCredorDevedorClassVendedor) 
                 { 
                     _collectionCredorDevedorClassVendedorRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionCredorDevedorClassVendedor()
         {
            try
            {
                 ObservableCollection<Entidades.CredorDevedorClass> oc;
                _valueCollectionCredorDevedorClassVendedorChanged = false;
                 _valueCollectionCredorDevedorClassVendedorCommitedChanged = false;
                _collectionCredorDevedorClassVendedorRemovidos = new List<Entidades.CredorDevedorClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.CredorDevedorClass>();
                }
                else{ 
                   Entidades.CredorDevedorClass search = new Entidades.CredorDevedorClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.CredorDevedorClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Vendedor", this),                     }                       ).Cast<Entidades.CredorDevedorClass>().ToList());
                 }
                 _valueCollectionCredorDevedorClassVendedor = new BindingList<Entidades.CredorDevedorClass>(oc); 
                 _collectionCredorDevedorClassVendedorOriginal= (from a in _valueCollectionCredorDevedorClassVendedor select a.ID).ToList();
                 _valueCollectionCredorDevedorClassVendedorLoaded = true;
                 oc.CollectionChanged += CollectionCredorDevedorClassVendedorChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionCredorDevedorClassVendedor+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrcamentoItemClassVendedorChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrcamentoItemClassVendedorChanged = true;
                  _valueCollectionOrcamentoItemClassVendedorCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrcamentoItemClassVendedorChanged = true; 
                  _valueCollectionOrcamentoItemClassVendedorCommitedChanged = true;
                 foreach (Entidades.OrcamentoItemClass item in e.OldItems) 
                 { 
                     _collectionOrcamentoItemClassVendedorRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrcamentoItemClassVendedorChanged = true; 
                  _valueCollectionOrcamentoItemClassVendedorCommitedChanged = true;
                 foreach (Entidades.OrcamentoItemClass item in _valueCollectionOrcamentoItemClassVendedor) 
                 { 
                     _collectionOrcamentoItemClassVendedorRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrcamentoItemClassVendedor()
         {
            try
            {
                 ObservableCollection<Entidades.OrcamentoItemClass> oc;
                _valueCollectionOrcamentoItemClassVendedorChanged = false;
                 _valueCollectionOrcamentoItemClassVendedorCommitedChanged = false;
                _collectionOrcamentoItemClassVendedorRemovidos = new List<Entidades.OrcamentoItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrcamentoItemClass>();
                }
                else{ 
                   Entidades.OrcamentoItemClass search = new Entidades.OrcamentoItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrcamentoItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Vendedor", this),                     }                       ).Cast<Entidades.OrcamentoItemClass>().ToList());
                 }
                 _valueCollectionOrcamentoItemClassVendedor = new BindingList<Entidades.OrcamentoItemClass>(oc); 
                 _collectionOrcamentoItemClassVendedorOriginal= (from a in _valueCollectionOrcamentoItemClassVendedor select a.ID).ToList();
                 _valueCollectionOrcamentoItemClassVendedorLoaded = true;
                 oc.CollectionChanged += CollectionOrcamentoItemClassVendedorChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrcamentoItemClassVendedor+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPedidoItemClassVendedorChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPedidoItemClassVendedorChanged = true;
                  _valueCollectionPedidoItemClassVendedorCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPedidoItemClassVendedorChanged = true; 
                  _valueCollectionPedidoItemClassVendedorCommitedChanged = true;
                 foreach (Entidades.PedidoItemClass item in e.OldItems) 
                 { 
                     _collectionPedidoItemClassVendedorRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPedidoItemClassVendedorChanged = true; 
                  _valueCollectionPedidoItemClassVendedorCommitedChanged = true;
                 foreach (Entidades.PedidoItemClass item in _valueCollectionPedidoItemClassVendedor) 
                 { 
                     _collectionPedidoItemClassVendedorRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPedidoItemClassVendedor()
         {
            try
            {
                 ObservableCollection<Entidades.PedidoItemClass> oc;
                _valueCollectionPedidoItemClassVendedorChanged = false;
                 _valueCollectionPedidoItemClassVendedorCommitedChanged = false;
                _collectionPedidoItemClassVendedorRemovidos = new List<Entidades.PedidoItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PedidoItemClass>();
                }
                else{ 
                   Entidades.PedidoItemClass search = new Entidades.PedidoItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PedidoItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Vendedor", this),                     }                       ).Cast<Entidades.PedidoItemClass>().ToList());
                 }
                 _valueCollectionPedidoItemClassVendedor = new BindingList<Entidades.PedidoItemClass>(oc); 
                 _collectionPedidoItemClassVendedorOriginal= (from a in _valueCollectionPedidoItemClassVendedor select a.ID).ToList();
                 _valueCollectionPedidoItemClassVendedorLoaded = true;
                 oc.CollectionChanged += CollectionPedidoItemClassVendedorChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPedidoItemClassVendedor+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionRepresentanteClassVendedorChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionRepresentanteClassVendedorChanged = true;
                  _valueCollectionRepresentanteClassVendedorCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionRepresentanteClassVendedorChanged = true; 
                  _valueCollectionRepresentanteClassVendedorCommitedChanged = true;
                 foreach (Entidades.RepresentanteClass item in e.OldItems) 
                 { 
                     _collectionRepresentanteClassVendedorRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionRepresentanteClassVendedorChanged = true; 
                  _valueCollectionRepresentanteClassVendedorCommitedChanged = true;
                 foreach (Entidades.RepresentanteClass item in _valueCollectionRepresentanteClassVendedor) 
                 { 
                     _collectionRepresentanteClassVendedorRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionRepresentanteClassVendedor()
         {
            try
            {
                 ObservableCollection<Entidades.RepresentanteClass> oc;
                _valueCollectionRepresentanteClassVendedorChanged = false;
                 _valueCollectionRepresentanteClassVendedorCommitedChanged = false;
                _collectionRepresentanteClassVendedorRemovidos = new List<Entidades.RepresentanteClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.RepresentanteClass>();
                }
                else{ 
                   Entidades.RepresentanteClass search = new Entidades.RepresentanteClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.RepresentanteClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Vendedor", this),                     }                       ).Cast<Entidades.RepresentanteClass>().ToList());
                 }
                 _valueCollectionRepresentanteClassVendedor = new BindingList<Entidades.RepresentanteClass>(oc); 
                 _collectionRepresentanteClassVendedorOriginal= (from a in _valueCollectionRepresentanteClassVendedor select a.ID).ToList();
                 _valueCollectionRepresentanteClassVendedorLoaded = true;
                 oc.CollectionChanged += CollectionRepresentanteClassVendedorChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionRepresentanteClassVendedor+"\r\n" + e.Message, e);
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
                if (string.IsNullOrEmpty(Cnpj))
                {
                    throw new Exception(ErroCnpjObrigatorio);
                }
                if (Cnpj.Length >20)
                {
                    throw new Exception( ErroCnpjComprimento);
                }
                if (string.IsNullOrEmpty(InscricaoEstadual))
                {
                    throw new Exception(ErroInscricaoEstadualObrigatorio);
                }
                if (InscricaoEstadual.Length >50)
                {
                    throw new Exception( ErroInscricaoEstadualComprimento);
                }
                if (string.IsNullOrEmpty(Endereco))
                {
                    throw new Exception(ErroEnderecoObrigatorio);
                }
                if (Endereco.Length >255)
                {
                    throw new Exception( ErroEnderecoComprimento);
                }
                if (string.IsNullOrEmpty(EnderecoNumero))
                {
                    throw new Exception(ErroEnderecoNumeroObrigatorio);
                }
                if (EnderecoNumero.Length >50)
                {
                    throw new Exception( ErroEnderecoNumeroComprimento);
                }
                if (string.IsNullOrEmpty(Bairro))
                {
                    throw new Exception(ErroBairroObrigatorio);
                }
                if (Bairro.Length >50)
                {
                    throw new Exception( ErroBairroComprimento);
                }
                if (string.IsNullOrEmpty(Cep))
                {
                    throw new Exception(ErroCepObrigatorio);
                }
                if (Cep.Length >10)
                {
                    throw new Exception( ErroCepComprimento);
                }
                if ( _valueCidade == null)
                {
                    throw new Exception(ErroCidadeObrigatorio);
                }
                if ( _valueContaBancaria == null)
                {
                    throw new Exception(ErroContaBancariaObrigatorio);
                }
                if ( _valueCentroCustoLucro == null)
                {
                    throw new Exception(ErroCentroCustoLucroObrigatorio);
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
                    "  public.vendedor  " +
                    "WHERE " +
                    "  id_vendedor = :id";
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
                        "  public.vendedor   " +
                        "SET  " + 
                        "  ven_tipo_pessoa = :ven_tipo_pessoa, " + 
                        "  ven_razao_social = :ven_razao_social, " + 
                        "  ven_cnpj = :ven_cnpj, " + 
                        "  ven_inscricao_estadual = :ven_inscricao_estadual, " + 
                        "  ven_inscricao_municipal = :ven_inscricao_municipal, " + 
                        "  ven_endereco = :ven_endereco, " + 
                        "  ven_endereco_numero = :ven_endereco_numero, " + 
                        "  ven_endereco_complemento = :ven_endereco_complemento, " + 
                        "  ven_bairro = :ven_bairro, " + 
                        "  ven_cep = :ven_cep, " + 
                        "  ven_fone1 = :ven_fone1, " + 
                        "  ven_fone2 = :ven_fone2, " + 
                        "  id_cidade = :id_cidade, " + 
                        "  ven_email = :ven_email, " + 
                        "  ven_envio_email = :ven_envio_email, " + 
                        "  ven_banco = :ven_banco, " + 
                        "  ven_agencia = :ven_agencia, " + 
                        "  ven_conta = :ven_conta, " + 
                        "  id_conta_bancaria = :id_conta_bancaria, " + 
                        "  id_centro_custo_lucro = :id_centro_custo_lucro, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  ven_comissao = :ven_comissao "+
                        "WHERE  " +
                        "  id_vendedor = :id " +
                        "RETURNING id_vendedor;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.vendedor " +
                        "( " +
                        "  ven_tipo_pessoa , " + 
                        "  ven_razao_social , " + 
                        "  ven_cnpj , " + 
                        "  ven_inscricao_estadual , " + 
                        "  ven_inscricao_municipal , " + 
                        "  ven_endereco , " + 
                        "  ven_endereco_numero , " + 
                        "  ven_endereco_complemento , " + 
                        "  ven_bairro , " + 
                        "  ven_cep , " + 
                        "  ven_fone1 , " + 
                        "  ven_fone2 , " + 
                        "  id_cidade , " + 
                        "  ven_email , " + 
                        "  ven_envio_email , " + 
                        "  ven_banco , " + 
                        "  ven_agencia , " + 
                        "  ven_conta , " + 
                        "  id_conta_bancaria , " + 
                        "  id_centro_custo_lucro , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  ven_comissao  "+
                        ")  " +
                        "VALUES ( " +
                        "  :ven_tipo_pessoa , " + 
                        "  :ven_razao_social , " + 
                        "  :ven_cnpj , " + 
                        "  :ven_inscricao_estadual , " + 
                        "  :ven_inscricao_municipal , " + 
                        "  :ven_endereco , " + 
                        "  :ven_endereco_numero , " + 
                        "  :ven_endereco_complemento , " + 
                        "  :ven_bairro , " + 
                        "  :ven_cep , " + 
                        "  :ven_fone1 , " + 
                        "  :ven_fone2 , " + 
                        "  :id_cidade , " + 
                        "  :ven_email , " + 
                        "  :ven_envio_email , " + 
                        "  :ven_banco , " + 
                        "  :ven_agencia , " + 
                        "  :ven_conta , " + 
                        "  :id_conta_bancaria , " + 
                        "  :id_centro_custo_lucro , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :ven_comissao  "+
                        ")RETURNING id_vendedor;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ven_tipo_pessoa", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.TipoPessoa);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ven_razao_social", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.RazaoSocial ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ven_cnpj", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Cnpj ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ven_inscricao_estadual", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.InscricaoEstadual ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ven_inscricao_municipal", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.InscricaoMunicipal ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ven_endereco", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Endereco ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ven_endereco_numero", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EnderecoNumero ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ven_endereco_complemento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EnderecoComplemento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ven_bairro", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Bairro ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ven_cep", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Cep ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ven_fone1", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Fone1 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ven_fone2", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Fone2 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_cidade", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Cidade==null ? (object) DBNull.Value : this.Cidade.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ven_email", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Email ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ven_envio_email", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EnvioEmail ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ven_banco", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Banco ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ven_agencia", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Agencia ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ven_conta", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Conta ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_conta_bancaria", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.ContaBancaria==null ? (object) DBNull.Value : this.ContaBancaria.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_centro_custo_lucro", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.CentroCustoLucro==null ? (object) DBNull.Value : this.CentroCustoLucro.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ven_comissao", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Comissao ?? DBNull.Value;

 
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
 if (CollectionClienteClassVendedor.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionClienteClassVendedor+"\r\n";
                foreach (Entidades.ClienteClass tmp in CollectionClienteClassVendedor)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionContaPagarClassVendedor.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionContaPagarClassVendedor+"\r\n";
                foreach (Entidades.ContaPagarClass tmp in CollectionContaPagarClassVendedor)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionCredorDevedorClassVendedor.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionCredorDevedorClassVendedor+"\r\n";
                foreach (Entidades.CredorDevedorClass tmp in CollectionCredorDevedorClassVendedor)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrcamentoItemClassVendedor.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrcamentoItemClassVendedor+"\r\n";
                foreach (Entidades.OrcamentoItemClass tmp in CollectionOrcamentoItemClassVendedor)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPedidoItemClassVendedor.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPedidoItemClassVendedor+"\r\n";
                foreach (Entidades.PedidoItemClass tmp in CollectionPedidoItemClassVendedor)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionRepresentanteClassVendedor.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionRepresentanteClassVendedor+"\r\n";
                foreach (Entidades.RepresentanteClass tmp in CollectionRepresentanteClassVendedor)
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
        public static VendedorClass CopiarEntidade(VendedorClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               VendedorClass toRet = new VendedorClass(usuario,conn);
 toRet.TipoPessoa= entidadeCopiar.TipoPessoa;
 toRet.RazaoSocial= entidadeCopiar.RazaoSocial;
 toRet.Cnpj= entidadeCopiar.Cnpj;
 toRet.InscricaoEstadual= entidadeCopiar.InscricaoEstadual;
 toRet.InscricaoMunicipal= entidadeCopiar.InscricaoMunicipal;
 toRet.Endereco= entidadeCopiar.Endereco;
 toRet.EnderecoNumero= entidadeCopiar.EnderecoNumero;
 toRet.EnderecoComplemento= entidadeCopiar.EnderecoComplemento;
 toRet.Bairro= entidadeCopiar.Bairro;
 toRet.Cep= entidadeCopiar.Cep;
 toRet.Fone1= entidadeCopiar.Fone1;
 toRet.Fone2= entidadeCopiar.Fone2;
 toRet.Cidade= entidadeCopiar.Cidade;
 toRet.Email= entidadeCopiar.Email;
 toRet.EnvioEmail= entidadeCopiar.EnvioEmail;
 toRet.Banco= entidadeCopiar.Banco;
 toRet.Agencia= entidadeCopiar.Agencia;
 toRet.Conta= entidadeCopiar.Conta;
 toRet.ContaBancaria= entidadeCopiar.ContaBancaria;
 toRet.CentroCustoLucro= entidadeCopiar.CentroCustoLucro;
 toRet.Comissao= entidadeCopiar.Comissao;

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
       _tipoPessoaOriginal = TipoPessoa;
       _tipoPessoaOriginalCommited = _tipoPessoaOriginal;
       _razaoSocialOriginal = RazaoSocial;
       _razaoSocialOriginalCommited = _razaoSocialOriginal;
       _cnpjOriginal = Cnpj;
       _cnpjOriginalCommited = _cnpjOriginal;
       _inscricaoEstadualOriginal = InscricaoEstadual;
       _inscricaoEstadualOriginalCommited = _inscricaoEstadualOriginal;
       _inscricaoMunicipalOriginal = InscricaoMunicipal;
       _inscricaoMunicipalOriginalCommited = _inscricaoMunicipalOriginal;
       _enderecoOriginal = Endereco;
       _enderecoOriginalCommited = _enderecoOriginal;
       _enderecoNumeroOriginal = EnderecoNumero;
       _enderecoNumeroOriginalCommited = _enderecoNumeroOriginal;
       _enderecoComplementoOriginal = EnderecoComplemento;
       _enderecoComplementoOriginalCommited = _enderecoComplementoOriginal;
       _bairroOriginal = Bairro;
       _bairroOriginalCommited = _bairroOriginal;
       _cepOriginal = Cep;
       _cepOriginalCommited = _cepOriginal;
       _fone1Original = Fone1;
       _fone1OriginalCommited = _fone1Original;
       _fone2Original = Fone2;
       _fone2OriginalCommited = _fone2Original;
       _cidadeOriginal = Cidade;
       _cidadeOriginalCommited = _cidadeOriginal;
       _emailOriginal = Email;
       _emailOriginalCommited = _emailOriginal;
       _envioEmailOriginal = EnvioEmail;
       _envioEmailOriginalCommited = _envioEmailOriginal;
       _bancoOriginal = Banco;
       _bancoOriginalCommited = _bancoOriginal;
       _agenciaOriginal = Agencia;
       _agenciaOriginalCommited = _agenciaOriginal;
       _contaOriginal = Conta;
       _contaOriginalCommited = _contaOriginal;
       _contaBancariaOriginal = ContaBancaria;
       _contaBancariaOriginalCommited = _contaBancariaOriginal;
       _centroCustoLucroOriginal = CentroCustoLucro;
       _centroCustoLucroOriginalCommited = _centroCustoLucroOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _comissaoOriginal = Comissao;
       _comissaoOriginalCommited = _comissaoOriginal;

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
       _tipoPessoaOriginalCommited = TipoPessoa;
       _razaoSocialOriginalCommited = RazaoSocial;
       _cnpjOriginalCommited = Cnpj;
       _inscricaoEstadualOriginalCommited = InscricaoEstadual;
       _inscricaoMunicipalOriginalCommited = InscricaoMunicipal;
       _enderecoOriginalCommited = Endereco;
       _enderecoNumeroOriginalCommited = EnderecoNumero;
       _enderecoComplementoOriginalCommited = EnderecoComplemento;
       _bairroOriginalCommited = Bairro;
       _cepOriginalCommited = Cep;
       _fone1OriginalCommited = Fone1;
       _fone2OriginalCommited = Fone2;
       _cidadeOriginalCommited = Cidade;
       _emailOriginalCommited = Email;
       _envioEmailOriginalCommited = EnvioEmail;
       _bancoOriginalCommited = Banco;
       _agenciaOriginalCommited = Agencia;
       _contaOriginalCommited = Conta;
       _contaBancariaOriginalCommited = ContaBancaria;
       _centroCustoLucroOriginalCommited = CentroCustoLucro;
       _versionOriginalCommited = Version;
       _comissaoOriginalCommited = Comissao;

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
               if (_valueCollectionClienteClassVendedorLoaded) 
               {
                  if (_collectionClienteClassVendedorRemovidos != null) 
                  {
                     _collectionClienteClassVendedorRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionClienteClassVendedorRemovidos = new List<Entidades.ClienteClass>();
                  }
                  _collectionClienteClassVendedorOriginal= (from a in _valueCollectionClienteClassVendedor select a.ID).ToList();
                  _valueCollectionClienteClassVendedorChanged = false;
                  _valueCollectionClienteClassVendedorCommitedChanged = false;
               }
               if (_valueCollectionContaPagarClassVendedorLoaded) 
               {
                  if (_collectionContaPagarClassVendedorRemovidos != null) 
                  {
                     _collectionContaPagarClassVendedorRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionContaPagarClassVendedorRemovidos = new List<Entidades.ContaPagarClass>();
                  }
                  _collectionContaPagarClassVendedorOriginal= (from a in _valueCollectionContaPagarClassVendedor select a.ID).ToList();
                  _valueCollectionContaPagarClassVendedorChanged = false;
                  _valueCollectionContaPagarClassVendedorCommitedChanged = false;
               }
               if (_valueCollectionCredorDevedorClassVendedorLoaded) 
               {
                  if (_collectionCredorDevedorClassVendedorRemovidos != null) 
                  {
                     _collectionCredorDevedorClassVendedorRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionCredorDevedorClassVendedorRemovidos = new List<Entidades.CredorDevedorClass>();
                  }
                  _collectionCredorDevedorClassVendedorOriginal= (from a in _valueCollectionCredorDevedorClassVendedor select a.ID).ToList();
                  _valueCollectionCredorDevedorClassVendedorChanged = false;
                  _valueCollectionCredorDevedorClassVendedorCommitedChanged = false;
               }
               if (_valueCollectionOrcamentoItemClassVendedorLoaded) 
               {
                  if (_collectionOrcamentoItemClassVendedorRemovidos != null) 
                  {
                     _collectionOrcamentoItemClassVendedorRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrcamentoItemClassVendedorRemovidos = new List<Entidades.OrcamentoItemClass>();
                  }
                  _collectionOrcamentoItemClassVendedorOriginal= (from a in _valueCollectionOrcamentoItemClassVendedor select a.ID).ToList();
                  _valueCollectionOrcamentoItemClassVendedorChanged = false;
                  _valueCollectionOrcamentoItemClassVendedorCommitedChanged = false;
               }
               if (_valueCollectionPedidoItemClassVendedorLoaded) 
               {
                  if (_collectionPedidoItemClassVendedorRemovidos != null) 
                  {
                     _collectionPedidoItemClassVendedorRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPedidoItemClassVendedorRemovidos = new List<Entidades.PedidoItemClass>();
                  }
                  _collectionPedidoItemClassVendedorOriginal= (from a in _valueCollectionPedidoItemClassVendedor select a.ID).ToList();
                  _valueCollectionPedidoItemClassVendedorChanged = false;
                  _valueCollectionPedidoItemClassVendedorCommitedChanged = false;
               }
               if (_valueCollectionRepresentanteClassVendedorLoaded) 
               {
                  if (_collectionRepresentanteClassVendedorRemovidos != null) 
                  {
                     _collectionRepresentanteClassVendedorRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionRepresentanteClassVendedorRemovidos = new List<Entidades.RepresentanteClass>();
                  }
                  _collectionRepresentanteClassVendedorOriginal= (from a in _valueCollectionRepresentanteClassVendedor select a.ID).ToList();
                  _valueCollectionRepresentanteClassVendedorChanged = false;
                  _valueCollectionRepresentanteClassVendedorCommitedChanged = false;
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
               TipoPessoa=_tipoPessoaOriginal;
               _tipoPessoaOriginalCommited=_tipoPessoaOriginal;
               RazaoSocial=_razaoSocialOriginal;
               _razaoSocialOriginalCommited=_razaoSocialOriginal;
               Cnpj=_cnpjOriginal;
               _cnpjOriginalCommited=_cnpjOriginal;
               InscricaoEstadual=_inscricaoEstadualOriginal;
               _inscricaoEstadualOriginalCommited=_inscricaoEstadualOriginal;
               InscricaoMunicipal=_inscricaoMunicipalOriginal;
               _inscricaoMunicipalOriginalCommited=_inscricaoMunicipalOriginal;
               Endereco=_enderecoOriginal;
               _enderecoOriginalCommited=_enderecoOriginal;
               EnderecoNumero=_enderecoNumeroOriginal;
               _enderecoNumeroOriginalCommited=_enderecoNumeroOriginal;
               EnderecoComplemento=_enderecoComplementoOriginal;
               _enderecoComplementoOriginalCommited=_enderecoComplementoOriginal;
               Bairro=_bairroOriginal;
               _bairroOriginalCommited=_bairroOriginal;
               Cep=_cepOriginal;
               _cepOriginalCommited=_cepOriginal;
               Fone1=_fone1Original;
               _fone1OriginalCommited=_fone1Original;
               Fone2=_fone2Original;
               _fone2OriginalCommited=_fone2Original;
               Cidade=_cidadeOriginal;
               _cidadeOriginalCommited=_cidadeOriginal;
               Email=_emailOriginal;
               _emailOriginalCommited=_emailOriginal;
               EnvioEmail=_envioEmailOriginal;
               _envioEmailOriginalCommited=_envioEmailOriginal;
               Banco=_bancoOriginal;
               _bancoOriginalCommited=_bancoOriginal;
               Agencia=_agenciaOriginal;
               _agenciaOriginalCommited=_agenciaOriginal;
               Conta=_contaOriginal;
               _contaOriginalCommited=_contaOriginal;
               ContaBancaria=_contaBancariaOriginal;
               _contaBancariaOriginalCommited=_contaBancariaOriginal;
               CentroCustoLucro=_centroCustoLucroOriginal;
               _centroCustoLucroOriginalCommited=_centroCustoLucroOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               Comissao=_comissaoOriginal;
               _comissaoOriginalCommited=_comissaoOriginal;
               if (_valueCollectionClienteClassVendedorLoaded) 
               {
                  CollectionClienteClassVendedor.Clear();
                  foreach(int item in _collectionClienteClassVendedorOriginal)
                  {
                    CollectionClienteClassVendedor.Add(Entidades.ClienteClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionClienteClassVendedorRemovidos.Clear();
               }
               if (_valueCollectionContaPagarClassVendedorLoaded) 
               {
                  CollectionContaPagarClassVendedor.Clear();
                  foreach(int item in _collectionContaPagarClassVendedorOriginal)
                  {
                    CollectionContaPagarClassVendedor.Add(Entidades.ContaPagarClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionContaPagarClassVendedorRemovidos.Clear();
               }
               if (_valueCollectionCredorDevedorClassVendedorLoaded) 
               {
                  CollectionCredorDevedorClassVendedor.Clear();
                  foreach(int item in _collectionCredorDevedorClassVendedorOriginal)
                  {
                    CollectionCredorDevedorClassVendedor.Add(Entidades.CredorDevedorClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionCredorDevedorClassVendedorRemovidos.Clear();
               }
               if (_valueCollectionOrcamentoItemClassVendedorLoaded) 
               {
                  CollectionOrcamentoItemClassVendedor.Clear();
                  foreach(int item in _collectionOrcamentoItemClassVendedorOriginal)
                  {
                    CollectionOrcamentoItemClassVendedor.Add(Entidades.OrcamentoItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrcamentoItemClassVendedorRemovidos.Clear();
               }
               if (_valueCollectionPedidoItemClassVendedorLoaded) 
               {
                  CollectionPedidoItemClassVendedor.Clear();
                  foreach(int item in _collectionPedidoItemClassVendedorOriginal)
                  {
                    CollectionPedidoItemClassVendedor.Add(Entidades.PedidoItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPedidoItemClassVendedorRemovidos.Clear();
               }
               if (_valueCollectionRepresentanteClassVendedorLoaded) 
               {
                  CollectionRepresentanteClassVendedor.Clear();
                  foreach(int item in _collectionRepresentanteClassVendedorOriginal)
                  {
                    CollectionRepresentanteClassVendedor.Add(Entidades.RepresentanteClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionRepresentanteClassVendedorRemovidos.Clear();
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
               if (_valueCollectionClienteClassVendedorLoaded) 
               {
                  if (_valueCollectionClienteClassVendedorChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaPagarClassVendedorLoaded) 
               {
                  if (_valueCollectionContaPagarClassVendedorChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionCredorDevedorClassVendedorLoaded) 
               {
                  if (_valueCollectionCredorDevedorClassVendedorChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoItemClassVendedorLoaded) 
               {
                  if (_valueCollectionOrcamentoItemClassVendedorChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemClassVendedorLoaded) 
               {
                  if (_valueCollectionPedidoItemClassVendedorChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionRepresentanteClassVendedorLoaded) 
               {
                  if (_valueCollectionRepresentanteClassVendedorChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionClienteClassVendedorLoaded) 
               {
                   tempRet = CollectionClienteClassVendedor.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionContaPagarClassVendedorLoaded) 
               {
                   tempRet = CollectionContaPagarClassVendedor.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionCredorDevedorClassVendedorLoaded) 
               {
                   tempRet = CollectionCredorDevedorClassVendedor.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrcamentoItemClassVendedorLoaded) 
               {
                   tempRet = CollectionOrcamentoItemClassVendedor.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemClassVendedorLoaded) 
               {
                   tempRet = CollectionPedidoItemClassVendedor.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionRepresentanteClassVendedorLoaded) 
               {
                   tempRet = CollectionRepresentanteClassVendedor.Any(item => item.IsDirty());
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
       dirty = _tipoPessoaOriginal != TipoPessoa;
      if (dirty) return true;
       dirty = _razaoSocialOriginal != RazaoSocial;
      if (dirty) return true;
       dirty = _cnpjOriginal != Cnpj;
      if (dirty) return true;
       dirty = _inscricaoEstadualOriginal != InscricaoEstadual;
      if (dirty) return true;
       dirty = _inscricaoMunicipalOriginal != InscricaoMunicipal;
      if (dirty) return true;
       dirty = _enderecoOriginal != Endereco;
      if (dirty) return true;
       dirty = _enderecoNumeroOriginal != EnderecoNumero;
      if (dirty) return true;
       dirty = _enderecoComplementoOriginal != EnderecoComplemento;
      if (dirty) return true;
       dirty = _bairroOriginal != Bairro;
      if (dirty) return true;
       dirty = _cepOriginal != Cep;
      if (dirty) return true;
       dirty = _fone1Original != Fone1;
      if (dirty) return true;
       dirty = _fone2Original != Fone2;
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
       dirty = _emailOriginal != Email;
      if (dirty) return true;
       dirty = _envioEmailOriginal != EnvioEmail;
      if (dirty) return true;
       dirty = _bancoOriginal != Banco;
      if (dirty) return true;
       dirty = _agenciaOriginal != Agencia;
      if (dirty) return true;
       dirty = _contaOriginal != Conta;
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
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _comissaoOriginal != Comissao;

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
               if (_valueCollectionClienteClassVendedorLoaded) 
               {
                  if (_valueCollectionClienteClassVendedorCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaPagarClassVendedorLoaded) 
               {
                  if (_valueCollectionContaPagarClassVendedorCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionCredorDevedorClassVendedorLoaded) 
               {
                  if (_valueCollectionCredorDevedorClassVendedorCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoItemClassVendedorLoaded) 
               {
                  if (_valueCollectionOrcamentoItemClassVendedorCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemClassVendedorLoaded) 
               {
                  if (_valueCollectionPedidoItemClassVendedorCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionRepresentanteClassVendedorLoaded) 
               {
                  if (_valueCollectionRepresentanteClassVendedorCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionClienteClassVendedorLoaded) 
               {
                   tempRet = CollectionClienteClassVendedor.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionContaPagarClassVendedorLoaded) 
               {
                   tempRet = CollectionContaPagarClassVendedor.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionCredorDevedorClassVendedorLoaded) 
               {
                   tempRet = CollectionCredorDevedorClassVendedor.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrcamentoItemClassVendedorLoaded) 
               {
                   tempRet = CollectionOrcamentoItemClassVendedor.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemClassVendedorLoaded) 
               {
                   tempRet = CollectionPedidoItemClassVendedor.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionRepresentanteClassVendedorLoaded) 
               {
                   tempRet = CollectionRepresentanteClassVendedor.Any(item => item.IsDirtyCommited());
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
       dirty = _tipoPessoaOriginalCommited != TipoPessoa;
      if (dirty) return true;
       dirty = _razaoSocialOriginalCommited != RazaoSocial;
      if (dirty) return true;
       dirty = _cnpjOriginalCommited != Cnpj;
      if (dirty) return true;
       dirty = _inscricaoEstadualOriginalCommited != InscricaoEstadual;
      if (dirty) return true;
       dirty = _inscricaoMunicipalOriginalCommited != InscricaoMunicipal;
      if (dirty) return true;
       dirty = _enderecoOriginalCommited != Endereco;
      if (dirty) return true;
       dirty = _enderecoNumeroOriginalCommited != EnderecoNumero;
      if (dirty) return true;
       dirty = _enderecoComplementoOriginalCommited != EnderecoComplemento;
      if (dirty) return true;
       dirty = _bairroOriginalCommited != Bairro;
      if (dirty) return true;
       dirty = _cepOriginalCommited != Cep;
      if (dirty) return true;
       dirty = _fone1OriginalCommited != Fone1;
      if (dirty) return true;
       dirty = _fone2OriginalCommited != Fone2;
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
       dirty = _emailOriginalCommited != Email;
      if (dirty) return true;
       dirty = _envioEmailOriginalCommited != EnvioEmail;
      if (dirty) return true;
       dirty = _bancoOriginalCommited != Banco;
      if (dirty) return true;
       dirty = _agenciaOriginalCommited != Agencia;
      if (dirty) return true;
       dirty = _contaOriginalCommited != Conta;
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
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _comissaoOriginalCommited != Comissao;

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
               if (_valueCollectionClienteClassVendedorLoaded) 
               {
                  foreach(ClienteClass item in CollectionClienteClassVendedor)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionContaPagarClassVendedorLoaded) 
               {
                  foreach(ContaPagarClass item in CollectionContaPagarClassVendedor)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionCredorDevedorClassVendedorLoaded) 
               {
                  foreach(CredorDevedorClass item in CollectionCredorDevedorClassVendedor)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrcamentoItemClassVendedorLoaded) 
               {
                  foreach(OrcamentoItemClass item in CollectionOrcamentoItemClassVendedor)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPedidoItemClassVendedorLoaded) 
               {
                  foreach(PedidoItemClass item in CollectionPedidoItemClassVendedor)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionRepresentanteClassVendedorLoaded) 
               {
                  foreach(RepresentanteClass item in CollectionRepresentanteClassVendedor)
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
             case "TipoPessoa":
                return this.TipoPessoa;
             case "RazaoSocial":
                return this.RazaoSocial;
             case "Cnpj":
                return this.Cnpj;
             case "InscricaoEstadual":
                return this.InscricaoEstadual;
             case "InscricaoMunicipal":
                return this.InscricaoMunicipal;
             case "Endereco":
                return this.Endereco;
             case "EnderecoNumero":
                return this.EnderecoNumero;
             case "EnderecoComplemento":
                return this.EnderecoComplemento;
             case "Bairro":
                return this.Bairro;
             case "Cep":
                return this.Cep;
             case "Fone1":
                return this.Fone1;
             case "Fone2":
                return this.Fone2;
             case "Cidade":
                return this.Cidade;
             case "Email":
                return this.Email;
             case "EnvioEmail":
                return this.EnvioEmail;
             case "Banco":
                return this.Banco;
             case "Agencia":
                return this.Agencia;
             case "Conta":
                return this.Conta;
             case "ContaBancaria":
                return this.ContaBancaria;
             case "CentroCustoLucro":
                return this.CentroCustoLucro;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "Comissao":
                return this.Comissao;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (Cidade!=null)
                Cidade.ChangeSingleConnection(newConnection);
             if (ContaBancaria!=null)
                ContaBancaria.ChangeSingleConnection(newConnection);
             if (CentroCustoLucro!=null)
                CentroCustoLucro.ChangeSingleConnection(newConnection);
               if (_valueCollectionClienteClassVendedorLoaded) 
               {
                  foreach(ClienteClass item in CollectionClienteClassVendedor)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionContaPagarClassVendedorLoaded) 
               {
                  foreach(ContaPagarClass item in CollectionContaPagarClassVendedor)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionCredorDevedorClassVendedorLoaded) 
               {
                  foreach(CredorDevedorClass item in CollectionCredorDevedorClassVendedor)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrcamentoItemClassVendedorLoaded) 
               {
                  foreach(OrcamentoItemClass item in CollectionOrcamentoItemClassVendedor)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPedidoItemClassVendedorLoaded) 
               {
                  foreach(PedidoItemClass item in CollectionPedidoItemClassVendedor)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionRepresentanteClassVendedorLoaded) 
               {
                  foreach(RepresentanteClass item in CollectionRepresentanteClassVendedor)
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
                  command.CommandText += " COUNT(vendedor.id_vendedor) " ;
               }
               else
               {
               command.CommandText += "vendedor.id_vendedor, " ;
               command.CommandText += "vendedor.ven_tipo_pessoa, " ;
               command.CommandText += "vendedor.ven_razao_social, " ;
               command.CommandText += "vendedor.ven_cnpj, " ;
               command.CommandText += "vendedor.ven_inscricao_estadual, " ;
               command.CommandText += "vendedor.ven_inscricao_municipal, " ;
               command.CommandText += "vendedor.ven_endereco, " ;
               command.CommandText += "vendedor.ven_endereco_numero, " ;
               command.CommandText += "vendedor.ven_endereco_complemento, " ;
               command.CommandText += "vendedor.ven_bairro, " ;
               command.CommandText += "vendedor.ven_cep, " ;
               command.CommandText += "vendedor.ven_fone1, " ;
               command.CommandText += "vendedor.ven_fone2, " ;
               command.CommandText += "vendedor.id_cidade, " ;
               command.CommandText += "vendedor.ven_email, " ;
               command.CommandText += "vendedor.ven_envio_email, " ;
               command.CommandText += "vendedor.ven_banco, " ;
               command.CommandText += "vendedor.ven_agencia, " ;
               command.CommandText += "vendedor.ven_conta, " ;
               command.CommandText += "vendedor.id_conta_bancaria, " ;
               command.CommandText += "vendedor.id_centro_custo_lucro, " ;
               command.CommandText += "vendedor.entity_uid, " ;
               command.CommandText += "vendedor.version, " ;
               command.CommandText += "vendedor.ven_comissao " ;
               }
               command.CommandText += " FROM  vendedor ";
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
                        orderByClause += " , ven_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(ven_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = vendedor.id_acs_usuario_ultima_revisao ";
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
                     case "id_vendedor":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , vendedor.id_vendedor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(vendedor.id_vendedor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ven_tipo_pessoa":
                     case "TipoPessoa":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , vendedor.ven_tipo_pessoa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(vendedor.ven_tipo_pessoa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ven_razao_social":
                     case "RazaoSocial":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , vendedor.ven_razao_social " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(vendedor.ven_razao_social) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ven_cnpj":
                     case "Cnpj":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , vendedor.ven_cnpj " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(vendedor.ven_cnpj) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ven_inscricao_estadual":
                     case "InscricaoEstadual":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , vendedor.ven_inscricao_estadual " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(vendedor.ven_inscricao_estadual) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ven_inscricao_municipal":
                     case "InscricaoMunicipal":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , vendedor.ven_inscricao_municipal " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(vendedor.ven_inscricao_municipal) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ven_endereco":
                     case "Endereco":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , vendedor.ven_endereco " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(vendedor.ven_endereco) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ven_endereco_numero":
                     case "EnderecoNumero":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , vendedor.ven_endereco_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(vendedor.ven_endereco_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ven_endereco_complemento":
                     case "EnderecoComplemento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , vendedor.ven_endereco_complemento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(vendedor.ven_endereco_complemento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ven_bairro":
                     case "Bairro":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , vendedor.ven_bairro " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(vendedor.ven_bairro) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ven_cep":
                     case "Cep":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , vendedor.ven_cep " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(vendedor.ven_cep) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ven_fone1":
                     case "Fone1":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , vendedor.ven_fone1 " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(vendedor.ven_fone1) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ven_fone2":
                     case "Fone2":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , vendedor.ven_fone2 " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(vendedor.ven_fone2) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_cidade":
                     case "Cidade":
                     command.CommandText += " LEFT JOIN cidade as cidade_Cidade ON cidade_Cidade.id_cidade = vendedor.id_cidade ";                     switch (parametro.TipoOrdenacao)
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
                     case "ven_email":
                     case "Email":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , vendedor.ven_email " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(vendedor.ven_email) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ven_envio_email":
                     case "EnvioEmail":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , vendedor.ven_envio_email " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(vendedor.ven_envio_email) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ven_banco":
                     case "Banco":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , vendedor.ven_banco " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(vendedor.ven_banco) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ven_agencia":
                     case "Agencia":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , vendedor.ven_agencia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(vendedor.ven_agencia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ven_conta":
                     case "Conta":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , vendedor.ven_conta " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(vendedor.ven_conta) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_conta_bancaria":
                     case "ContaBancaria":
                     command.CommandText += " LEFT JOIN conta_bancaria as conta_bancaria_ContaBancaria ON conta_bancaria_ContaBancaria.id_conta_bancaria = vendedor.id_conta_bancaria ";                     switch (parametro.TipoOrdenacao)
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
                     command.CommandText += " LEFT JOIN centro_custo_lucro as centro_custo_lucro_CentroCustoLucro ON centro_custo_lucro_CentroCustoLucro.id_centro_custo_lucro = vendedor.id_centro_custo_lucro ";                     switch (parametro.TipoOrdenacao)
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
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , vendedor.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(vendedor.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , vendedor.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(vendedor.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ven_comissao":
                     case "Comissao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , vendedor.ven_comissao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(vendedor.ven_comissao) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ven_razao_social")) 
                        {
                           whereClause += " OR UPPER(vendedor.ven_razao_social) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(vendedor.ven_razao_social) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ven_cnpj")) 
                        {
                           whereClause += " OR UPPER(vendedor.ven_cnpj) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(vendedor.ven_cnpj) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ven_inscricao_estadual")) 
                        {
                           whereClause += " OR UPPER(vendedor.ven_inscricao_estadual) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(vendedor.ven_inscricao_estadual) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ven_inscricao_municipal")) 
                        {
                           whereClause += " OR UPPER(vendedor.ven_inscricao_municipal) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(vendedor.ven_inscricao_municipal) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ven_endereco")) 
                        {
                           whereClause += " OR UPPER(vendedor.ven_endereco) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(vendedor.ven_endereco) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ven_endereco_numero")) 
                        {
                           whereClause += " OR UPPER(vendedor.ven_endereco_numero) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(vendedor.ven_endereco_numero) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ven_endereco_complemento")) 
                        {
                           whereClause += " OR UPPER(vendedor.ven_endereco_complemento) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(vendedor.ven_endereco_complemento) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ven_bairro")) 
                        {
                           whereClause += " OR UPPER(vendedor.ven_bairro) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(vendedor.ven_bairro) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ven_cep")) 
                        {
                           whereClause += " OR UPPER(vendedor.ven_cep) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(vendedor.ven_cep) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ven_fone1")) 
                        {
                           whereClause += " OR UPPER(vendedor.ven_fone1) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(vendedor.ven_fone1) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ven_fone2")) 
                        {
                           whereClause += " OR UPPER(vendedor.ven_fone2) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(vendedor.ven_fone2) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ven_email")) 
                        {
                           whereClause += " OR UPPER(vendedor.ven_email) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(vendedor.ven_email) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ven_banco")) 
                        {
                           whereClause += " OR UPPER(vendedor.ven_banco) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(vendedor.ven_banco) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ven_agencia")) 
                        {
                           whereClause += " OR UPPER(vendedor.ven_agencia) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(vendedor.ven_agencia) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ven_conta")) 
                        {
                           whereClause += " OR UPPER(vendedor.ven_conta) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(vendedor.ven_conta) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(vendedor.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(vendedor.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_vendedor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  vendedor.id_vendedor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  vendedor.id_vendedor = :vendedor_ID_1691 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("vendedor_ID_1691", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoPessoa" || parametro.FieldName == "ven_tipo_pessoa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is TipoPessoa)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo TipoPessoa");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  vendedor.ven_tipo_pessoa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  vendedor.ven_tipo_pessoa = :vendedor_TipoPessoa_769 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("vendedor_TipoPessoa_769", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RazaoSocial" || parametro.FieldName == "ven_razao_social")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  vendedor.ven_razao_social IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  vendedor.ven_razao_social LIKE :vendedor_RazaoSocial_5074 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("vendedor_RazaoSocial_5074", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cnpj" || parametro.FieldName == "ven_cnpj")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  vendedor.ven_cnpj IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  vendedor.ven_cnpj LIKE :vendedor_Cnpj_9249 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("vendedor_Cnpj_9249", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "InscricaoEstadual" || parametro.FieldName == "ven_inscricao_estadual")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  vendedor.ven_inscricao_estadual IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  vendedor.ven_inscricao_estadual LIKE :vendedor_InscricaoEstadual_632 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("vendedor_InscricaoEstadual_632", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "InscricaoMunicipal" || parametro.FieldName == "ven_inscricao_municipal")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  vendedor.ven_inscricao_municipal IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  vendedor.ven_inscricao_municipal LIKE :vendedor_InscricaoMunicipal_5101 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("vendedor_InscricaoMunicipal_5101", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Endereco" || parametro.FieldName == "ven_endereco")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  vendedor.ven_endereco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  vendedor.ven_endereco LIKE :vendedor_Endereco_7005 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("vendedor_Endereco_7005", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EnderecoNumero" || parametro.FieldName == "ven_endereco_numero")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  vendedor.ven_endereco_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  vendedor.ven_endereco_numero LIKE :vendedor_EnderecoNumero_9196 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("vendedor_EnderecoNumero_9196", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EnderecoComplemento" || parametro.FieldName == "ven_endereco_complemento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  vendedor.ven_endereco_complemento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  vendedor.ven_endereco_complemento LIKE :vendedor_EnderecoComplemento_5452 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("vendedor_EnderecoComplemento_5452", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Bairro" || parametro.FieldName == "ven_bairro")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  vendedor.ven_bairro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  vendedor.ven_bairro LIKE :vendedor_Bairro_7967 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("vendedor_Bairro_7967", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cep" || parametro.FieldName == "ven_cep")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  vendedor.ven_cep IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  vendedor.ven_cep LIKE :vendedor_Cep_9462 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("vendedor_Cep_9462", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Fone1" || parametro.FieldName == "ven_fone1")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  vendedor.ven_fone1 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  vendedor.ven_fone1 LIKE :vendedor_Fone1_4186 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("vendedor_Fone1_4186", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Fone2" || parametro.FieldName == "ven_fone2")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  vendedor.ven_fone2 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  vendedor.ven_fone2 LIKE :vendedor_Fone2_4456 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("vendedor_Fone2_4456", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  vendedor.id_cidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  vendedor.id_cidade = :vendedor_Cidade_1817 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("vendedor_Cidade_1817", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Email" || parametro.FieldName == "ven_email")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  vendedor.ven_email IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  vendedor.ven_email LIKE :vendedor_Email_7561 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("vendedor_Email_7561", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EnvioEmail" || parametro.FieldName == "ven_envio_email")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  vendedor.ven_envio_email IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  vendedor.ven_envio_email = :vendedor_EnvioEmail_1471 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("vendedor_EnvioEmail_1471", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Banco" || parametro.FieldName == "ven_banco")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  vendedor.ven_banco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  vendedor.ven_banco LIKE :vendedor_Banco_8764 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("vendedor_Banco_8764", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Agencia" || parametro.FieldName == "ven_agencia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  vendedor.ven_agencia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  vendedor.ven_agencia LIKE :vendedor_Agencia_7727 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("vendedor_Agencia_7727", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Conta" || parametro.FieldName == "ven_conta")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  vendedor.ven_conta IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  vendedor.ven_conta LIKE :vendedor_Conta_7132 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("vendedor_Conta_7132", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  vendedor.id_conta_bancaria IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  vendedor.id_conta_bancaria = :vendedor_ContaBancaria_6134 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("vendedor_ContaBancaria_6134", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  vendedor.id_centro_custo_lucro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  vendedor.id_centro_custo_lucro = :vendedor_CentroCustoLucro_6641 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("vendedor_CentroCustoLucro_6641", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  vendedor.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  vendedor.entity_uid LIKE :vendedor_EntityUid_2817 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("vendedor_EntityUid_2817", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  vendedor.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  vendedor.version = :vendedor_Version_5252 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("vendedor_Version_5252", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Comissao" || parametro.FieldName == "ven_comissao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  vendedor.ven_comissao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  vendedor.ven_comissao = :vendedor_Comissao_8090 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("vendedor_Comissao_8090", NpgsqlDbType.Double, parametro.Fieldvalue));
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
                         whereClause += "  vendedor.ven_razao_social IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  vendedor.ven_razao_social LIKE :vendedor_RazaoSocial_9331 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("vendedor_RazaoSocial_9331", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  vendedor.ven_cnpj IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  vendedor.ven_cnpj LIKE :vendedor_Cnpj_5637 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("vendedor_Cnpj_5637", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "InscricaoEstadualExato" || parametro.FieldName == "InscricaoEstadualExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  vendedor.ven_inscricao_estadual IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  vendedor.ven_inscricao_estadual LIKE :vendedor_InscricaoEstadual_9747 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("vendedor_InscricaoEstadual_9747", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  vendedor.ven_inscricao_municipal IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  vendedor.ven_inscricao_municipal LIKE :vendedor_InscricaoMunicipal_8699 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("vendedor_InscricaoMunicipal_8699", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  vendedor.ven_endereco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  vendedor.ven_endereco LIKE :vendedor_Endereco_1882 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("vendedor_Endereco_1882", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  vendedor.ven_endereco_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  vendedor.ven_endereco_numero LIKE :vendedor_EnderecoNumero_3944 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("vendedor_EnderecoNumero_3944", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EnderecoComplementoExato" || parametro.FieldName == "EnderecoComplementoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  vendedor.ven_endereco_complemento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  vendedor.ven_endereco_complemento LIKE :vendedor_EnderecoComplemento_7102 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("vendedor_EnderecoComplemento_7102", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  vendedor.ven_bairro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  vendedor.ven_bairro LIKE :vendedor_Bairro_8622 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("vendedor_Bairro_8622", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  vendedor.ven_cep IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  vendedor.ven_cep LIKE :vendedor_Cep_2252 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("vendedor_Cep_2252", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  vendedor.ven_fone1 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  vendedor.ven_fone1 LIKE :vendedor_Fone1_2418 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("vendedor_Fone1_2418", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  vendedor.ven_fone2 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  vendedor.ven_fone2 LIKE :vendedor_Fone2_4264 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("vendedor_Fone2_4264", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  vendedor.ven_email IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  vendedor.ven_email LIKE :vendedor_Email_4952 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("vendedor_Email_4952", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  vendedor.ven_banco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  vendedor.ven_banco LIKE :vendedor_Banco_6668 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("vendedor_Banco_6668", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  vendedor.ven_agencia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  vendedor.ven_agencia LIKE :vendedor_Agencia_107 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("vendedor_Agencia_107", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  vendedor.ven_conta IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  vendedor.ven_conta LIKE :vendedor_Conta_2994 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("vendedor_Conta_2994", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  vendedor.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  vendedor.entity_uid LIKE :vendedor_EntityUid_8223 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("vendedor_EntityUid_8223", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  VendedorClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (VendedorClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(VendedorClass), Convert.ToInt32(read["id_vendedor"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new VendedorClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_vendedor"]);
                     entidade.TipoPessoa = (TipoPessoa) (read["ven_tipo_pessoa"] != DBNull.Value ? Enum.ToObject(typeof(TipoPessoa), read["ven_tipo_pessoa"]) : null);
                     entidade.RazaoSocial = (read["ven_razao_social"] != DBNull.Value ? read["ven_razao_social"].ToString() : null);
                     entidade.Cnpj = (read["ven_cnpj"] != DBNull.Value ? read["ven_cnpj"].ToString() : null);
                     entidade.InscricaoEstadual = (read["ven_inscricao_estadual"] != DBNull.Value ? read["ven_inscricao_estadual"].ToString() : null);
                     entidade.InscricaoMunicipal = (read["ven_inscricao_municipal"] != DBNull.Value ? read["ven_inscricao_municipal"].ToString() : null);
                     entidade.Endereco = (read["ven_endereco"] != DBNull.Value ? read["ven_endereco"].ToString() : null);
                     entidade.EnderecoNumero = (read["ven_endereco_numero"] != DBNull.Value ? read["ven_endereco_numero"].ToString() : null);
                     entidade.EnderecoComplemento = (read["ven_endereco_complemento"] != DBNull.Value ? read["ven_endereco_complemento"].ToString() : null);
                     entidade.Bairro = (read["ven_bairro"] != DBNull.Value ? read["ven_bairro"].ToString() : null);
                     entidade.Cep = (read["ven_cep"] != DBNull.Value ? read["ven_cep"].ToString() : null);
                     entidade.Fone1 = (read["ven_fone1"] != DBNull.Value ? read["ven_fone1"].ToString() : null);
                     entidade.Fone2 = (read["ven_fone2"] != DBNull.Value ? read["ven_fone2"].ToString() : null);
                     if (read["id_cidade"] != DBNull.Value)
                     {
                        entidade.Cidade = (BibliotecaEntidades.Entidades.CidadeClass)BibliotecaEntidades.Entidades.CidadeClass.GetEntidade(Convert.ToInt32(read["id_cidade"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Cidade = null ;
                     }
                     entidade.Email = (read["ven_email"] != DBNull.Value ? read["ven_email"].ToString() : null);
                     entidade.EnvioEmail = Convert.ToBoolean(Convert.ToInt16(read["ven_envio_email"]));
                     entidade.Banco = (read["ven_banco"] != DBNull.Value ? read["ven_banco"].ToString() : null);
                     entidade.Agencia = (read["ven_agencia"] != DBNull.Value ? read["ven_agencia"].ToString() : null);
                     entidade.Conta = (read["ven_conta"] != DBNull.Value ? read["ven_conta"].ToString() : null);
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
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.Comissao = (double)read["ven_comissao"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (VendedorClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
