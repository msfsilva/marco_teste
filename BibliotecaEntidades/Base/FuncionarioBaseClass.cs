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
     [Table("funcionario","fuc")]
     public class FuncionarioBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do FuncionarioClass";
protected const string ErroDelete = "Erro ao excluir o FuncionarioClass  ";
protected const string ErroSave = "Erro ao salvar o FuncionarioClass.";
protected const string ErroCollectionContaPagarClassFuncionario = "Erro ao carregar a coleção de ContaPagarClass.";
protected const string ErroCollectionContaReceberClassFuncionario = "Erro ao carregar a coleção de ContaReceberClass.";
protected const string ErroCollectionCredorDevedorClassFuncionario = "Erro ao carregar a coleção de CredorDevedorClass.";
protected const string ErroCollectionFuncionarioDocumentoClassFuncionario = "Erro ao carregar a coleção de FuncionarioDocumentoClass.";
protected const string ErroCollectionFuncionarioEpiClassFuncionario = "Erro ao carregar a coleção de FuncionarioEpiClass.";
protected const string ErroCollectionFuncionarioFuncaoClassFuncionario = "Erro ao carregar a coleção de FuncionarioFuncaoClass.";
protected const string ErroNomeObrigatorio = "O campo Nome é obrigatório";
protected const string ErroCpfObrigatorio = "O campo Cpf é obrigatório";
protected const string ErroCpfComprimento = "O campo Cpf deve ter no máximo 20 caracteres";
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
protected const string ErroUltimaRevisaoObrigatorio = "O campo UltimaRevisao é obrigatório";
protected const string ErroUltimaRevisaoComprimento = "O campo UltimaRevisao deve ter no máximo 255 caracteres";
protected const string ErroCidadeObrigatorio = "O campo Cidade é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do FuncionarioClass.";
protected const string MensagemUtilizadoCollectionContaPagarClassFuncionario =  "A entidade FuncionarioClass está sendo utilizada nos seguintes ContaPagarClass:";
protected const string MensagemUtilizadoCollectionContaReceberClassFuncionario =  "A entidade FuncionarioClass está sendo utilizada nos seguintes ContaReceberClass:";
protected const string MensagemUtilizadoCollectionCredorDevedorClassFuncionario =  "A entidade FuncionarioClass está sendo utilizada nos seguintes CredorDevedorClass:";
protected const string MensagemUtilizadoCollectionFuncionarioDocumentoClassFuncionario =  "A entidade FuncionarioClass está sendo utilizada nos seguintes FuncionarioDocumentoClass:";
protected const string MensagemUtilizadoCollectionFuncionarioEpiClassFuncionario =  "A entidade FuncionarioClass está sendo utilizada nos seguintes FuncionarioEpiClass:";
protected const string MensagemUtilizadoCollectionFuncionarioFuncaoClassFuncionario =  "A entidade FuncionarioClass está sendo utilizada nos seguintes FuncionarioFuncaoClass:";
protected const string ErroFotoLoad = "O campo Foto não pode ser carregado";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade FuncionarioClass está sendo utilizada.";
#endregion
       protected string _nomeOriginal{get;private set;}
       private string _nomeOriginalCommited{get; set;}
        private string _valueNome;
         [Column("fuc_nome")]
        public virtual string Nome
         { 
            get { return this._valueNome; } 
            set 
            { 
                if (this._valueNome == value)return;
                 this._valueNome = value; 
            } 
        } 

       protected string _cpfOriginal{get;private set;}
       private string _cpfOriginalCommited{get; set;}
        private string _valueCpf;
         [Column("fuc_cpf")]
        public virtual string Cpf
         { 
            get { return this._valueCpf; } 
            set 
            { 
                if (this._valueCpf == value)return;
                 this._valueCpf = value; 
            } 
        } 

       protected string _rgOriginal{get;private set;}
       private string _rgOriginalCommited{get; set;}
        private string _valueRg;
         [Column("fuc_rg")]
        public virtual string Rg
         { 
            get { return this._valueRg; } 
            set 
            { 
                if (this._valueRg == value)return;
                 this._valueRg = value; 
            } 
        } 

       protected string _pisOriginal{get;private set;}
       private string _pisOriginalCommited{get; set;}
        private string _valuePis;
         [Column("fuc_pis")]
        public virtual string Pis
         { 
            get { return this._valuePis; } 
            set 
            { 
                if (this._valuePis == value)return;
                 this._valuePis = value; 
            } 
        } 

       protected string _numeroCtpsOriginal{get;private set;}
       private string _numeroCtpsOriginalCommited{get; set;}
        private string _valueNumeroCtps;
         [Column("fuc_numero_ctps")]
        public virtual string NumeroCtps
         { 
            get { return this._valueNumeroCtps; } 
            set 
            { 
                if (this._valueNumeroCtps == value)return;
                 this._valueNumeroCtps = value; 
            } 
        } 

       protected DateTime _dataNascimentoOriginal{get;private set;}
       private DateTime _dataNascimentoOriginalCommited{get; set;}
        private DateTime _valueDataNascimento;
         [Column("fuc_data_nascimento")]
        public virtual DateTime DataNascimento
         { 
            get { return this._valueDataNascimento; } 
            set 
            { 
                if (this._valueDataNascimento == value)return;
                 this._valueDataNascimento = value; 
            } 
        } 

       protected string _enderecoOriginal{get;private set;}
       private string _enderecoOriginalCommited{get; set;}
        private string _valueEndereco;
         [Column("fuc_endereco")]
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
         [Column("fuc_endereco_numero")]
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
         [Column("fuc_endereco_complemento")]
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
         [Column("fuc_bairro")]
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
         [Column("fuc_cep")]
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
         [Column("fuc_fone1")]
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
         [Column("fuc_fone2")]
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
         [Column("fuc_email")]
        public virtual string Email
         { 
            get { return this._valueEmail; } 
            set 
            { 
                if (this._valueEmail == value)return;
                 this._valueEmail = value; 
            } 
        } 

       protected string _bancoOriginal{get;private set;}
       private string _bancoOriginalCommited{get; set;}
        private string _valueBanco;
         [Column("fuc_banco")]
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
         [Column("fuc_agencia")]
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
         [Column("fuc_conta")]
        public virtual string Conta
         { 
            get { return this._valueConta; } 
            set 
            { 
                if (this._valueConta == value)return;
                 this._valueConta = value; 
            } 
        } 

       protected string _ctpsSerieOriginal{get;private set;}
       private string _ctpsSerieOriginalCommited{get; set;}
        private string _valueCtpsSerie;
         [Column("fuc_ctps_serie")]
        public virtual string CtpsSerie
         { 
            get { return this._valueCtpsSerie; } 
            set 
            { 
                if (this._valueCtpsSerie == value)return;
                 this._valueCtpsSerie = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.EstadoClass _estadoCtpsOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.EstadoClass _estadoCtpsOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.EstadoClass _valueEstadoCtps;
        [Column("id_estado_ctps", "estado", "id_estado")]
       public virtual BibliotecaEntidades.Entidades.EstadoClass EstadoCtps
        { 
           get {                 return this._valueEstadoCtps; } 
           set 
           { 
                if (this._valueEstadoCtps == value)return;
                 this._valueEstadoCtps = value; 
           } 
       } 

       protected string _fotoOriginal= null;
        private string _fotoOriginalCommited= null;
        private bool _FotoLoaded = false;
        [UnCloneable(UnCloneableAttributeType.RetFalse)]
       protected bool FotoLoaded 
       { 
            get {                     return _FotoLoaded; } 
           set 
           { 
                this._FotoLoaded = value;
           } 
       } 
        [UnCloneable(UnCloneableAttributeType.RetNull)] 
         private byte[] _valueFoto;
         [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
         [Column("fuc_foto")]
        public virtual byte[] Foto
         { 
            get { 
                   if (!this.FotoLoaded) 
                   {
                       this.LoadFoto();
                   }
                   return this._valueFoto; } 
            set 
            { 
                FotoLoaded = true; 
                if (this._valueFoto == value)return;
                 this._valueFoto = value; 
            } 
        } 

       protected DateTime _dataAdmissaoOriginal{get;private set;}
       private DateTime _dataAdmissaoOriginalCommited{get; set;}
        private DateTime _valueDataAdmissao;
         [Column("fuc_data_admissao")]
        public virtual DateTime DataAdmissao
         { 
            get { return this._valueDataAdmissao; } 
            set 
            { 
                if (this._valueDataAdmissao == value)return;
                 this._valueDataAdmissao = value; 
            } 
        } 

       protected DateTime? _dataDemissaoOriginal{get;private set;}
       private DateTime? _dataDemissaoOriginalCommited{get; set;}
        private DateTime? _valueDataDemissao;
         [Column("fuc_data_demissao")]
        public virtual DateTime? DataDemissao
         { 
            get { return this._valueDataDemissao; } 
            set 
            { 
                if (this._valueDataDemissao == value)return;
                 this._valueDataDemissao = value; 
            } 
        } 

       protected bool _ativoOriginal{get;private set;}
       private bool _ativoOriginalCommited{get; set;}
        private bool _valueAtivo;
         [Column("fuc_ativo")]
        public virtual bool Ativo
         { 
            get { return this._valueAtivo; } 
            set 
            { 
                if (this._valueAtivo == value)return;
                 this._valueAtivo = value; 
            } 
        } 

       private List<long> _collectionContaPagarClassFuncionarioOriginal;
       private List<Entidades.ContaPagarClass > _collectionContaPagarClassFuncionarioRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaPagarClassFuncionarioLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaPagarClassFuncionarioChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaPagarClassFuncionarioCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ContaPagarClass> _valueCollectionContaPagarClassFuncionario { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ContaPagarClass> CollectionContaPagarClassFuncionario 
       { 
           get { if(!_valueCollectionContaPagarClassFuncionarioLoaded && !this.DisableLoadCollection){this.LoadCollectionContaPagarClassFuncionario();}
return this._valueCollectionContaPagarClassFuncionario; } 
           set 
           { 
               this._valueCollectionContaPagarClassFuncionario = value; 
               this._valueCollectionContaPagarClassFuncionarioLoaded = true; 
           } 
       } 

       private List<long> _collectionContaReceberClassFuncionarioOriginal;
       private List<Entidades.ContaReceberClass > _collectionContaReceberClassFuncionarioRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaReceberClassFuncionarioLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaReceberClassFuncionarioChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaReceberClassFuncionarioCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ContaReceberClass> _valueCollectionContaReceberClassFuncionario { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ContaReceberClass> CollectionContaReceberClassFuncionario 
       { 
           get { if(!_valueCollectionContaReceberClassFuncionarioLoaded && !this.DisableLoadCollection){this.LoadCollectionContaReceberClassFuncionario();}
return this._valueCollectionContaReceberClassFuncionario; } 
           set 
           { 
               this._valueCollectionContaReceberClassFuncionario = value; 
               this._valueCollectionContaReceberClassFuncionarioLoaded = true; 
           } 
       } 

       private List<long> _collectionCredorDevedorClassFuncionarioOriginal;
       private List<Entidades.CredorDevedorClass > _collectionCredorDevedorClassFuncionarioRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionCredorDevedorClassFuncionarioLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionCredorDevedorClassFuncionarioChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionCredorDevedorClassFuncionarioCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.CredorDevedorClass> _valueCollectionCredorDevedorClassFuncionario { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.CredorDevedorClass> CollectionCredorDevedorClassFuncionario 
       { 
           get { if(!_valueCollectionCredorDevedorClassFuncionarioLoaded && !this.DisableLoadCollection){this.LoadCollectionCredorDevedorClassFuncionario();}
return this._valueCollectionCredorDevedorClassFuncionario; } 
           set 
           { 
               this._valueCollectionCredorDevedorClassFuncionario = value; 
               this._valueCollectionCredorDevedorClassFuncionarioLoaded = true; 
           } 
       } 

       private List<long> _collectionFuncionarioDocumentoClassFuncionarioOriginal;
       private List<Entidades.FuncionarioDocumentoClass > _collectionFuncionarioDocumentoClassFuncionarioRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFuncionarioDocumentoClassFuncionarioLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFuncionarioDocumentoClassFuncionarioChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFuncionarioDocumentoClassFuncionarioCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.FuncionarioDocumentoClass> _valueCollectionFuncionarioDocumentoClassFuncionario { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.FuncionarioDocumentoClass> CollectionFuncionarioDocumentoClassFuncionario 
       { 
           get { if(!_valueCollectionFuncionarioDocumentoClassFuncionarioLoaded && !this.DisableLoadCollection){this.LoadCollectionFuncionarioDocumentoClassFuncionario();}
return this._valueCollectionFuncionarioDocumentoClassFuncionario; } 
           set 
           { 
               this._valueCollectionFuncionarioDocumentoClassFuncionario = value; 
               this._valueCollectionFuncionarioDocumentoClassFuncionarioLoaded = true; 
           } 
       } 

       private List<long> _collectionFuncionarioEpiClassFuncionarioOriginal;
       private List<Entidades.FuncionarioEpiClass > _collectionFuncionarioEpiClassFuncionarioRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFuncionarioEpiClassFuncionarioLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFuncionarioEpiClassFuncionarioChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFuncionarioEpiClassFuncionarioCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.FuncionarioEpiClass> _valueCollectionFuncionarioEpiClassFuncionario { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.FuncionarioEpiClass> CollectionFuncionarioEpiClassFuncionario 
       { 
           get { if(!_valueCollectionFuncionarioEpiClassFuncionarioLoaded && !this.DisableLoadCollection){this.LoadCollectionFuncionarioEpiClassFuncionario();}
return this._valueCollectionFuncionarioEpiClassFuncionario; } 
           set 
           { 
               this._valueCollectionFuncionarioEpiClassFuncionario = value; 
               this._valueCollectionFuncionarioEpiClassFuncionarioLoaded = true; 
           } 
       } 

       private List<long> _collectionFuncionarioFuncaoClassFuncionarioOriginal;
       private List<Entidades.FuncionarioFuncaoClass > _collectionFuncionarioFuncaoClassFuncionarioRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFuncionarioFuncaoClassFuncionarioLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFuncionarioFuncaoClassFuncionarioChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFuncionarioFuncaoClassFuncionarioCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.FuncionarioFuncaoClass> _valueCollectionFuncionarioFuncaoClassFuncionario { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.FuncionarioFuncaoClass> CollectionFuncionarioFuncaoClassFuncionario 
       { 
           get { if(!_valueCollectionFuncionarioFuncaoClassFuncionarioLoaded && !this.DisableLoadCollection){this.LoadCollectionFuncionarioFuncaoClassFuncionario();}
return this._valueCollectionFuncionarioFuncaoClassFuncionario; } 
           set 
           { 
               this._valueCollectionFuncionarioFuncaoClassFuncionario = value; 
               this._valueCollectionFuncionarioFuncaoClassFuncionarioLoaded = true; 
           } 
       } 

        public FuncionarioBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.DataAdmissao = Configurations.DataIndependenteClass.GetData();
           this.Ativo = true;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static FuncionarioClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (FuncionarioClass) GetEntity(typeof(FuncionarioClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionContaPagarClassFuncionarioChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionContaPagarClassFuncionarioChanged = true;
                  _valueCollectionContaPagarClassFuncionarioCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionContaPagarClassFuncionarioChanged = true; 
                  _valueCollectionContaPagarClassFuncionarioCommitedChanged = true;
                 foreach (Entidades.ContaPagarClass item in e.OldItems) 
                 { 
                     _collectionContaPagarClassFuncionarioRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionContaPagarClassFuncionarioChanged = true; 
                  _valueCollectionContaPagarClassFuncionarioCommitedChanged = true;
                 foreach (Entidades.ContaPagarClass item in _valueCollectionContaPagarClassFuncionario) 
                 { 
                     _collectionContaPagarClassFuncionarioRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionContaPagarClassFuncionario()
         {
            try
            {
                 ObservableCollection<Entidades.ContaPagarClass> oc;
                _valueCollectionContaPagarClassFuncionarioChanged = false;
                 _valueCollectionContaPagarClassFuncionarioCommitedChanged = false;
                _collectionContaPagarClassFuncionarioRemovidos = new List<Entidades.ContaPagarClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ContaPagarClass>();
                }
                else{ 
                   Entidades.ContaPagarClass search = new Entidades.ContaPagarClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ContaPagarClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Funcionario", this),                     }                       ).Cast<Entidades.ContaPagarClass>().ToList());
                 }
                 _valueCollectionContaPagarClassFuncionario = new BindingList<Entidades.ContaPagarClass>(oc); 
                 _collectionContaPagarClassFuncionarioOriginal= (from a in _valueCollectionContaPagarClassFuncionario select a.ID).ToList();
                 _valueCollectionContaPagarClassFuncionarioLoaded = true;
                 oc.CollectionChanged += CollectionContaPagarClassFuncionarioChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionContaPagarClassFuncionario+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionContaReceberClassFuncionarioChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionContaReceberClassFuncionarioChanged = true;
                  _valueCollectionContaReceberClassFuncionarioCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionContaReceberClassFuncionarioChanged = true; 
                  _valueCollectionContaReceberClassFuncionarioCommitedChanged = true;
                 foreach (Entidades.ContaReceberClass item in e.OldItems) 
                 { 
                     _collectionContaReceberClassFuncionarioRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionContaReceberClassFuncionarioChanged = true; 
                  _valueCollectionContaReceberClassFuncionarioCommitedChanged = true;
                 foreach (Entidades.ContaReceberClass item in _valueCollectionContaReceberClassFuncionario) 
                 { 
                     _collectionContaReceberClassFuncionarioRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionContaReceberClassFuncionario()
         {
            try
            {
                 ObservableCollection<Entidades.ContaReceberClass> oc;
                _valueCollectionContaReceberClassFuncionarioChanged = false;
                 _valueCollectionContaReceberClassFuncionarioCommitedChanged = false;
                _collectionContaReceberClassFuncionarioRemovidos = new List<Entidades.ContaReceberClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ContaReceberClass>();
                }
                else{ 
                   Entidades.ContaReceberClass search = new Entidades.ContaReceberClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ContaReceberClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Funcionario", this)                    }                       ).Cast<Entidades.ContaReceberClass>().ToList());
                 }
                 _valueCollectionContaReceberClassFuncionario = new BindingList<Entidades.ContaReceberClass>(oc); 
                 _collectionContaReceberClassFuncionarioOriginal= (from a in _valueCollectionContaReceberClassFuncionario select a.ID).ToList();
                 _valueCollectionContaReceberClassFuncionarioLoaded = true;
                 oc.CollectionChanged += CollectionContaReceberClassFuncionarioChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionContaReceberClassFuncionario+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionCredorDevedorClassFuncionarioChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionCredorDevedorClassFuncionarioChanged = true;
                  _valueCollectionCredorDevedorClassFuncionarioCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionCredorDevedorClassFuncionarioChanged = true; 
                  _valueCollectionCredorDevedorClassFuncionarioCommitedChanged = true;
                 foreach (Entidades.CredorDevedorClass item in e.OldItems) 
                 { 
                     _collectionCredorDevedorClassFuncionarioRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionCredorDevedorClassFuncionarioChanged = true; 
                  _valueCollectionCredorDevedorClassFuncionarioCommitedChanged = true;
                 foreach (Entidades.CredorDevedorClass item in _valueCollectionCredorDevedorClassFuncionario) 
                 { 
                     _collectionCredorDevedorClassFuncionarioRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionCredorDevedorClassFuncionario()
         {
            try
            {
                 ObservableCollection<Entidades.CredorDevedorClass> oc;
                _valueCollectionCredorDevedorClassFuncionarioChanged = false;
                 _valueCollectionCredorDevedorClassFuncionarioCommitedChanged = false;
                _collectionCredorDevedorClassFuncionarioRemovidos = new List<Entidades.CredorDevedorClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.CredorDevedorClass>();
                }
                else{ 
                   Entidades.CredorDevedorClass search = new Entidades.CredorDevedorClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.CredorDevedorClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Funcionario", this),                     }                       ).Cast<Entidades.CredorDevedorClass>().ToList());
                 }
                 _valueCollectionCredorDevedorClassFuncionario = new BindingList<Entidades.CredorDevedorClass>(oc); 
                 _collectionCredorDevedorClassFuncionarioOriginal= (from a in _valueCollectionCredorDevedorClassFuncionario select a.ID).ToList();
                 _valueCollectionCredorDevedorClassFuncionarioLoaded = true;
                 oc.CollectionChanged += CollectionCredorDevedorClassFuncionarioChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionCredorDevedorClassFuncionario+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionFuncionarioDocumentoClassFuncionarioChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionFuncionarioDocumentoClassFuncionarioChanged = true;
                  _valueCollectionFuncionarioDocumentoClassFuncionarioCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionFuncionarioDocumentoClassFuncionarioChanged = true; 
                  _valueCollectionFuncionarioDocumentoClassFuncionarioCommitedChanged = true;
                 foreach (Entidades.FuncionarioDocumentoClass item in e.OldItems) 
                 { 
                     _collectionFuncionarioDocumentoClassFuncionarioRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionFuncionarioDocumentoClassFuncionarioChanged = true; 
                  _valueCollectionFuncionarioDocumentoClassFuncionarioCommitedChanged = true;
                 foreach (Entidades.FuncionarioDocumentoClass item in _valueCollectionFuncionarioDocumentoClassFuncionario) 
                 { 
                     _collectionFuncionarioDocumentoClassFuncionarioRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionFuncionarioDocumentoClassFuncionario()
         {
            try
            {
                 ObservableCollection<Entidades.FuncionarioDocumentoClass> oc;
                _valueCollectionFuncionarioDocumentoClassFuncionarioChanged = false;
                 _valueCollectionFuncionarioDocumentoClassFuncionarioCommitedChanged = false;
                _collectionFuncionarioDocumentoClassFuncionarioRemovidos = new List<Entidades.FuncionarioDocumentoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.FuncionarioDocumentoClass>();
                }
                else{ 
                   Entidades.FuncionarioDocumentoClass search = new Entidades.FuncionarioDocumentoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.FuncionarioDocumentoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Funcionario", this),                     }                       ).Cast<Entidades.FuncionarioDocumentoClass>().ToList());
                 }
                 _valueCollectionFuncionarioDocumentoClassFuncionario = new BindingList<Entidades.FuncionarioDocumentoClass>(oc); 
                 _collectionFuncionarioDocumentoClassFuncionarioOriginal= (from a in _valueCollectionFuncionarioDocumentoClassFuncionario select a.ID).ToList();
                 _valueCollectionFuncionarioDocumentoClassFuncionarioLoaded = true;
                 oc.CollectionChanged += CollectionFuncionarioDocumentoClassFuncionarioChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionFuncionarioDocumentoClassFuncionario+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionFuncionarioEpiClassFuncionarioChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionFuncionarioEpiClassFuncionarioChanged = true;
                  _valueCollectionFuncionarioEpiClassFuncionarioCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionFuncionarioEpiClassFuncionarioChanged = true; 
                  _valueCollectionFuncionarioEpiClassFuncionarioCommitedChanged = true;
                 foreach (Entidades.FuncionarioEpiClass item in e.OldItems) 
                 { 
                     _collectionFuncionarioEpiClassFuncionarioRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionFuncionarioEpiClassFuncionarioChanged = true; 
                  _valueCollectionFuncionarioEpiClassFuncionarioCommitedChanged = true;
                 foreach (Entidades.FuncionarioEpiClass item in _valueCollectionFuncionarioEpiClassFuncionario) 
                 { 
                     _collectionFuncionarioEpiClassFuncionarioRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionFuncionarioEpiClassFuncionario()
         {
            try
            {
                 ObservableCollection<Entidades.FuncionarioEpiClass> oc;
                _valueCollectionFuncionarioEpiClassFuncionarioChanged = false;
                 _valueCollectionFuncionarioEpiClassFuncionarioCommitedChanged = false;
                _collectionFuncionarioEpiClassFuncionarioRemovidos = new List<Entidades.FuncionarioEpiClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.FuncionarioEpiClass>();
                }
                else{ 
                   Entidades.FuncionarioEpiClass search = new Entidades.FuncionarioEpiClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.FuncionarioEpiClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Funcionario", this),                     }                       ).Cast<Entidades.FuncionarioEpiClass>().ToList());
                 }
                 _valueCollectionFuncionarioEpiClassFuncionario = new BindingList<Entidades.FuncionarioEpiClass>(oc); 
                 _collectionFuncionarioEpiClassFuncionarioOriginal= (from a in _valueCollectionFuncionarioEpiClassFuncionario select a.ID).ToList();
                 _valueCollectionFuncionarioEpiClassFuncionarioLoaded = true;
                 oc.CollectionChanged += CollectionFuncionarioEpiClassFuncionarioChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionFuncionarioEpiClassFuncionario+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionFuncionarioFuncaoClassFuncionarioChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionFuncionarioFuncaoClassFuncionarioChanged = true;
                  _valueCollectionFuncionarioFuncaoClassFuncionarioCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionFuncionarioFuncaoClassFuncionarioChanged = true; 
                  _valueCollectionFuncionarioFuncaoClassFuncionarioCommitedChanged = true;
                 foreach (Entidades.FuncionarioFuncaoClass item in e.OldItems) 
                 { 
                     _collectionFuncionarioFuncaoClassFuncionarioRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionFuncionarioFuncaoClassFuncionarioChanged = true; 
                  _valueCollectionFuncionarioFuncaoClassFuncionarioCommitedChanged = true;
                 foreach (Entidades.FuncionarioFuncaoClass item in _valueCollectionFuncionarioFuncaoClassFuncionario) 
                 { 
                     _collectionFuncionarioFuncaoClassFuncionarioRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionFuncionarioFuncaoClassFuncionario()
         {
            try
            {
                 ObservableCollection<Entidades.FuncionarioFuncaoClass> oc;
                _valueCollectionFuncionarioFuncaoClassFuncionarioChanged = false;
                 _valueCollectionFuncionarioFuncaoClassFuncionarioCommitedChanged = false;
                _collectionFuncionarioFuncaoClassFuncionarioRemovidos = new List<Entidades.FuncionarioFuncaoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.FuncionarioFuncaoClass>();
                }
                else{ 
                   Entidades.FuncionarioFuncaoClass search = new Entidades.FuncionarioFuncaoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.FuncionarioFuncaoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Funcionario", this),                     }                       ).Cast<Entidades.FuncionarioFuncaoClass>().ToList());
                 }
                 _valueCollectionFuncionarioFuncaoClassFuncionario = new BindingList<Entidades.FuncionarioFuncaoClass>(oc); 
                 _collectionFuncionarioFuncaoClassFuncionarioOriginal= (from a in _valueCollectionFuncionarioFuncaoClassFuncionario select a.ID).ToList();
                 _valueCollectionFuncionarioFuncaoClassFuncionarioLoaded = true;
                 oc.CollectionChanged += CollectionFuncionarioFuncaoClassFuncionarioChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionFuncionarioFuncaoClassFuncionario+"\r\n" + e.Message, e);
            }
         } 
private void LoadFoto()
        {
            try
            {
                if (this.ID == -1)
                {

                    FotoLoaded = true;
                    return;
                }

                IWTPostgreNpgsqlCommand command = this.SingleConnection.CreateCommand();
                command.CommandText = "SELECT fuc_foto FROM funcionario WHERE id_funcionario = :id ";
                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;

                object tmp = command.ExecuteScalar();
                if (tmp != DBNull.Value)
                {
                    this._valueFoto = (byte[]) tmp;
                }
                if (this._valueFoto != null)
                  { 
                     using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                     { 
                        _fotoOriginal = Convert.ToBase64String(sha1.ComputeHash(this._valueFoto));
                     }
                  } 
                  else 
                  { 
                        _fotoOriginal = null ;
                  } 
                FotoLoaded = true;
            }
            catch (Exception e)
            {
                throw new Exception(ErroFotoLoad + "\r\n" + e.Message, e);
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
                if (string.IsNullOrEmpty(Cpf))
                {
                    throw new Exception(ErroCpfObrigatorio);
                }
                if (Cpf.Length >20)
                {
                    throw new Exception( ErroCpfComprimento);
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
                    "  public.funcionario  " +
                    "WHERE " +
                    "  id_funcionario = :id";
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
                        "  public.funcionario   " +
                        "SET  " + 
                        "  fuc_nome = :fuc_nome, " + 
                        "  fuc_cpf = :fuc_cpf, " + 
                        "  fuc_rg = :fuc_rg, " + 
                        "  fuc_pis = :fuc_pis, " + 
                        "  fuc_numero_ctps = :fuc_numero_ctps, " + 
                        "  fuc_data_nascimento = :fuc_data_nascimento, " + 
                        "  fuc_endereco = :fuc_endereco, " + 
                        "  fuc_endereco_numero = :fuc_endereco_numero, " + 
                        "  fuc_endereco_complemento = :fuc_endereco_complemento, " + 
                        "  fuc_bairro = :fuc_bairro, " + 
                        "  fuc_cep = :fuc_cep, " + 
                        "  fuc_fone1 = :fuc_fone1, " + 
                        "  fuc_fone2 = :fuc_fone2, " + 
                        "  id_cidade = :id_cidade, " + 
                        "  fuc_email = :fuc_email, " + 
                        "  fuc_banco = :fuc_banco, " + 
                        "  fuc_agencia = :fuc_agencia, " + 
                        "  fuc_conta = :fuc_conta, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  fuc_ultima_revisao = :fuc_ultima_revisao, " + 
                        "  fuc_ultima_revisao_data = :fuc_ultima_revisao_data, " + 
                        "  id_acs_usuario_ultima_revisao = :id_acs_usuario_ultima_revisao, " + 
                        "  fuc_ctps_serie = :fuc_ctps_serie, " + 
                        "  id_estado_ctps = :id_estado_ctps, " + 
                        "  fuc_foto = :fuc_foto, " + 
                        "  fuc_data_admissao = :fuc_data_admissao, " + 
                        "  fuc_data_demissao = :fuc_data_demissao, " + 
                        "  fuc_ativo = :fuc_ativo "+
                        "WHERE  " +
                        "  id_funcionario = :id " +
                        "RETURNING id_funcionario;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.funcionario " +
                        "( " +
                        "  fuc_nome , " + 
                        "  fuc_cpf , " + 
                        "  fuc_rg , " + 
                        "  fuc_pis , " + 
                        "  fuc_numero_ctps , " + 
                        "  fuc_data_nascimento , " + 
                        "  fuc_endereco , " + 
                        "  fuc_endereco_numero , " + 
                        "  fuc_endereco_complemento , " + 
                        "  fuc_bairro , " + 
                        "  fuc_cep , " + 
                        "  fuc_fone1 , " + 
                        "  fuc_fone2 , " + 
                        "  id_cidade , " + 
                        "  fuc_email , " + 
                        "  fuc_banco , " + 
                        "  fuc_agencia , " + 
                        "  fuc_conta , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  fuc_ultima_revisao , " + 
                        "  fuc_ultima_revisao_data , " + 
                        "  id_acs_usuario_ultima_revisao , " + 
                        "  fuc_ctps_serie , " + 
                        "  id_estado_ctps , " + 
                        "  fuc_foto , " + 
                        "  fuc_data_admissao , " + 
                        "  fuc_data_demissao , " + 
                        "  fuc_ativo  "+
                        ")  " +
                        "VALUES ( " +
                        "  :fuc_nome , " + 
                        "  :fuc_cpf , " + 
                        "  :fuc_rg , " + 
                        "  :fuc_pis , " + 
                        "  :fuc_numero_ctps , " + 
                        "  :fuc_data_nascimento , " + 
                        "  :fuc_endereco , " + 
                        "  :fuc_endereco_numero , " + 
                        "  :fuc_endereco_complemento , " + 
                        "  :fuc_bairro , " + 
                        "  :fuc_cep , " + 
                        "  :fuc_fone1 , " + 
                        "  :fuc_fone2 , " + 
                        "  :id_cidade , " + 
                        "  :fuc_email , " + 
                        "  :fuc_banco , " + 
                        "  :fuc_agencia , " + 
                        "  :fuc_conta , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :fuc_ultima_revisao , " + 
                        "  :fuc_ultima_revisao_data , " + 
                        "  :id_acs_usuario_ultima_revisao , " + 
                        "  :fuc_ctps_serie , " + 
                        "  :id_estado_ctps , " + 
                        "  :fuc_foto , " + 
                        "  :fuc_data_admissao , " + 
                        "  :fuc_data_demissao , " + 
                        "  :fuc_ativo  "+
                        ")RETURNING id_funcionario;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fuc_nome", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Nome ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fuc_cpf", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Cpf ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fuc_rg", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Rg ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fuc_pis", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Pis ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fuc_numero_ctps", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NumeroCtps ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fuc_data_nascimento", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataNascimento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fuc_endereco", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Endereco ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fuc_endereco_numero", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EnderecoNumero ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fuc_endereco_complemento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EnderecoComplemento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fuc_bairro", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Bairro ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fuc_cep", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Cep ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fuc_fone1", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Fone1 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fuc_fone2", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Fone2 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_cidade", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Cidade==null ? (object) DBNull.Value : this.Cidade.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fuc_email", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Email ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fuc_banco", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Banco ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fuc_agencia", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Agencia ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fuc_conta", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Conta ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fuc_ultima_revisao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UltimaRevisao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fuc_ultima_revisao_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UltimaRevisaoData ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_ultima_revisao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.UltimaRevisaoUsuario==null ? (object) DBNull.Value : this.UltimaRevisaoUsuario.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fuc_ctps_serie", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CtpsSerie ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_estado_ctps", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.EstadoCtps==null ? (object) DBNull.Value : this.EstadoCtps.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fuc_foto", NpgsqlDbType.Bytea));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Foto ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fuc_data_admissao", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataAdmissao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fuc_data_demissao", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataDemissao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fuc_ativo", NpgsqlDbType.Smallint));
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
 if (CollectionContaPagarClassFuncionario.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionContaPagarClassFuncionario+"\r\n";
                foreach (Entidades.ContaPagarClass tmp in CollectionContaPagarClassFuncionario)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionContaReceberClassFuncionario.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionContaReceberClassFuncionario+"\r\n";
                foreach (Entidades.ContaReceberClass tmp in CollectionContaReceberClassFuncionario)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionCredorDevedorClassFuncionario.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionCredorDevedorClassFuncionario+"\r\n";
                foreach (Entidades.CredorDevedorClass tmp in CollectionCredorDevedorClassFuncionario)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionFuncionarioDocumentoClassFuncionario.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionFuncionarioDocumentoClassFuncionario+"\r\n";
                foreach (Entidades.FuncionarioDocumentoClass tmp in CollectionFuncionarioDocumentoClassFuncionario)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionFuncionarioEpiClassFuncionario.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionFuncionarioEpiClassFuncionario+"\r\n";
                foreach (Entidades.FuncionarioEpiClass tmp in CollectionFuncionarioEpiClassFuncionario)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionFuncionarioFuncaoClassFuncionario.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionFuncionarioFuncaoClassFuncionario+"\r\n";
                foreach (Entidades.FuncionarioFuncaoClass tmp in CollectionFuncionarioFuncaoClassFuncionario)
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
        public static FuncionarioClass CopiarEntidade(FuncionarioClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               FuncionarioClass toRet = new FuncionarioClass(usuario,conn);
 toRet.Nome= entidadeCopiar.Nome;
 toRet.Cpf= entidadeCopiar.Cpf;
 toRet.Rg= entidadeCopiar.Rg;
 toRet.Pis= entidadeCopiar.Pis;
 toRet.NumeroCtps= entidadeCopiar.NumeroCtps;
 toRet.DataNascimento= entidadeCopiar.DataNascimento;
 toRet.Endereco= entidadeCopiar.Endereco;
 toRet.EnderecoNumero= entidadeCopiar.EnderecoNumero;
 toRet.EnderecoComplemento= entidadeCopiar.EnderecoComplemento;
 toRet.Bairro= entidadeCopiar.Bairro;
 toRet.Cep= entidadeCopiar.Cep;
 toRet.Fone1= entidadeCopiar.Fone1;
 toRet.Fone2= entidadeCopiar.Fone2;
 toRet.Cidade= entidadeCopiar.Cidade;
 toRet.Email= entidadeCopiar.Email;
 toRet.Banco= entidadeCopiar.Banco;
 toRet.Agencia= entidadeCopiar.Agencia;
 toRet.Conta= entidadeCopiar.Conta;
 toRet.CtpsSerie= entidadeCopiar.CtpsSerie;
 toRet.EstadoCtps= entidadeCopiar.EstadoCtps;
 toRet.Foto= entidadeCopiar.Foto;
 toRet.DataAdmissao= entidadeCopiar.DataAdmissao;
 toRet.DataDemissao= entidadeCopiar.DataDemissao;
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
       _nomeOriginal = Nome;
       _nomeOriginalCommited = _nomeOriginal;
       _cpfOriginal = Cpf;
       _cpfOriginalCommited = _cpfOriginal;
       _rgOriginal = Rg;
       _rgOriginalCommited = _rgOriginal;
       _pisOriginal = Pis;
       _pisOriginalCommited = _pisOriginal;
       _numeroCtpsOriginal = NumeroCtps;
       _numeroCtpsOriginalCommited = _numeroCtpsOriginal;
       _dataNascimentoOriginal = DataNascimento;
       _dataNascimentoOriginalCommited = _dataNascimentoOriginal;
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
       _bancoOriginal = Banco;
       _bancoOriginalCommited = _bancoOriginal;
       _agenciaOriginal = Agencia;
       _agenciaOriginalCommited = _agenciaOriginal;
       _contaOriginal = Conta;
       _contaOriginalCommited = _contaOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _ultimaRevisaoOriginal = UltimaRevisao;
       _ultimaRevisaoOriginalCommited = _ultimaRevisaoOriginal ;
       _ctpsSerieOriginal = CtpsSerie;
       _ctpsSerieOriginalCommited = _ctpsSerieOriginal;
       _estadoCtpsOriginal = EstadoCtps;
       _estadoCtpsOriginalCommited = _estadoCtpsOriginal;
       _dataAdmissaoOriginal = DataAdmissao;
       _dataAdmissaoOriginalCommited = _dataAdmissaoOriginal;
       _dataDemissaoOriginal = DataDemissao;
       _dataDemissaoOriginalCommited = _dataDemissaoOriginal;
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
       _nomeOriginalCommited = Nome;
       _cpfOriginalCommited = Cpf;
       _rgOriginalCommited = Rg;
       _pisOriginalCommited = Pis;
       _numeroCtpsOriginalCommited = NumeroCtps;
       _dataNascimentoOriginalCommited = DataNascimento;
       _enderecoOriginalCommited = Endereco;
       _enderecoNumeroOriginalCommited = EnderecoNumero;
       _enderecoComplementoOriginalCommited = EnderecoComplemento;
       _bairroOriginalCommited = Bairro;
       _cepOriginalCommited = Cep;
       _fone1OriginalCommited = Fone1;
       _fone2OriginalCommited = Fone2;
       _cidadeOriginalCommited = Cidade;
       _emailOriginalCommited = Email;
       _bancoOriginalCommited = Banco;
       _agenciaOriginalCommited = Agencia;
       _contaOriginalCommited = Conta;
       _versionOriginalCommited = Version;
       _ultimaRevisaoOriginalCommited = UltimaRevisao;
       _ctpsSerieOriginalCommited = CtpsSerie;
       _estadoCtpsOriginalCommited = EstadoCtps;
       _dataAdmissaoOriginalCommited = DataAdmissao;
       _dataDemissaoOriginalCommited = DataDemissao;
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
               if (FotoLoaded)
               {
                  if(this._valueFoto != null)
                  { 
                     using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                     { 
                        _fotoOriginal = Convert.ToBase64String(sha1.ComputeHash(this._valueFoto));
                     }
                  } 
                  else 
                  { 
                        _fotoOriginal = null ;
                  } 
               }
               if (_valueCollectionContaPagarClassFuncionarioLoaded) 
               {
                  if (_collectionContaPagarClassFuncionarioRemovidos != null) 
                  {
                     _collectionContaPagarClassFuncionarioRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionContaPagarClassFuncionarioRemovidos = new List<Entidades.ContaPagarClass>();
                  }
                  _collectionContaPagarClassFuncionarioOriginal= (from a in _valueCollectionContaPagarClassFuncionario select a.ID).ToList();
                  _valueCollectionContaPagarClassFuncionarioChanged = false;
                  _valueCollectionContaPagarClassFuncionarioCommitedChanged = false;
               }
               if (_valueCollectionContaReceberClassFuncionarioLoaded) 
               {
                  if (_collectionContaReceberClassFuncionarioRemovidos != null) 
                  {
                     _collectionContaReceberClassFuncionarioRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionContaReceberClassFuncionarioRemovidos = new List<Entidades.ContaReceberClass>();
                  }
                  _collectionContaReceberClassFuncionarioOriginal= (from a in _valueCollectionContaReceberClassFuncionario select a.ID).ToList();
                  _valueCollectionContaReceberClassFuncionarioChanged = false;
                  _valueCollectionContaReceberClassFuncionarioCommitedChanged = false;
               }
               if (_valueCollectionCredorDevedorClassFuncionarioLoaded) 
               {
                  if (_collectionCredorDevedorClassFuncionarioRemovidos != null) 
                  {
                     _collectionCredorDevedorClassFuncionarioRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionCredorDevedorClassFuncionarioRemovidos = new List<Entidades.CredorDevedorClass>();
                  }
                  _collectionCredorDevedorClassFuncionarioOriginal= (from a in _valueCollectionCredorDevedorClassFuncionario select a.ID).ToList();
                  _valueCollectionCredorDevedorClassFuncionarioChanged = false;
                  _valueCollectionCredorDevedorClassFuncionarioCommitedChanged = false;
               }
               if (_valueCollectionFuncionarioDocumentoClassFuncionarioLoaded) 
               {
                  if (_collectionFuncionarioDocumentoClassFuncionarioRemovidos != null) 
                  {
                     _collectionFuncionarioDocumentoClassFuncionarioRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionFuncionarioDocumentoClassFuncionarioRemovidos = new List<Entidades.FuncionarioDocumentoClass>();
                  }
                  _collectionFuncionarioDocumentoClassFuncionarioOriginal= (from a in _valueCollectionFuncionarioDocumentoClassFuncionario select a.ID).ToList();
                  _valueCollectionFuncionarioDocumentoClassFuncionarioChanged = false;
                  _valueCollectionFuncionarioDocumentoClassFuncionarioCommitedChanged = false;
               }
               if (_valueCollectionFuncionarioEpiClassFuncionarioLoaded) 
               {
                  if (_collectionFuncionarioEpiClassFuncionarioRemovidos != null) 
                  {
                     _collectionFuncionarioEpiClassFuncionarioRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionFuncionarioEpiClassFuncionarioRemovidos = new List<Entidades.FuncionarioEpiClass>();
                  }
                  _collectionFuncionarioEpiClassFuncionarioOriginal= (from a in _valueCollectionFuncionarioEpiClassFuncionario select a.ID).ToList();
                  _valueCollectionFuncionarioEpiClassFuncionarioChanged = false;
                  _valueCollectionFuncionarioEpiClassFuncionarioCommitedChanged = false;
               }
               if (_valueCollectionFuncionarioFuncaoClassFuncionarioLoaded) 
               {
                  if (_collectionFuncionarioFuncaoClassFuncionarioRemovidos != null) 
                  {
                     _collectionFuncionarioFuncaoClassFuncionarioRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionFuncionarioFuncaoClassFuncionarioRemovidos = new List<Entidades.FuncionarioFuncaoClass>();
                  }
                  _collectionFuncionarioFuncaoClassFuncionarioOriginal= (from a in _valueCollectionFuncionarioFuncaoClassFuncionario select a.ID).ToList();
                  _valueCollectionFuncionarioFuncaoClassFuncionarioChanged = false;
                  _valueCollectionFuncionarioFuncaoClassFuncionarioCommitedChanged = false;
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
               Cpf=_cpfOriginal;
               _cpfOriginalCommited=_cpfOriginal;
               Rg=_rgOriginal;
               _rgOriginalCommited=_rgOriginal;
               Pis=_pisOriginal;
               _pisOriginalCommited=_pisOriginal;
               NumeroCtps=_numeroCtpsOriginal;
               _numeroCtpsOriginalCommited=_numeroCtpsOriginal;
               DataNascimento=_dataNascimentoOriginal;
               _dataNascimentoOriginalCommited=_dataNascimentoOriginal;
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
               Banco=_bancoOriginal;
               _bancoOriginalCommited=_bancoOriginal;
               Agencia=_agenciaOriginal;
               _agenciaOriginalCommited=_agenciaOriginal;
               Conta=_contaOriginal;
               _contaOriginalCommited=_contaOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               UltimaRevisao=_ultimaRevisaoOriginal;
               _ultimaRevisaoOriginalCommited=_ultimaRevisaoOriginal;
               CtpsSerie=_ctpsSerieOriginal;
               _ctpsSerieOriginalCommited=_ctpsSerieOriginal;
               EstadoCtps=_estadoCtpsOriginal;
               _estadoCtpsOriginalCommited=_estadoCtpsOriginal;
               FotoLoaded = false;
               this._fotoOriginal = null;
               this._fotoOriginalCommited = null;
               this._valueFoto = null;
               DataAdmissao=_dataAdmissaoOriginal;
               _dataAdmissaoOriginalCommited=_dataAdmissaoOriginal;
               DataDemissao=_dataDemissaoOriginal;
               _dataDemissaoOriginalCommited=_dataDemissaoOriginal;
               Ativo=_ativoOriginal;
               _ativoOriginalCommited=_ativoOriginal;
               if (_valueCollectionContaPagarClassFuncionarioLoaded) 
               {
                  CollectionContaPagarClassFuncionario.Clear();
                  foreach(int item in _collectionContaPagarClassFuncionarioOriginal)
                  {
                    CollectionContaPagarClassFuncionario.Add(Entidades.ContaPagarClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionContaPagarClassFuncionarioRemovidos.Clear();
               }
               if (_valueCollectionContaReceberClassFuncionarioLoaded) 
               {
                  CollectionContaReceberClassFuncionario.Clear();
                  foreach(int item in _collectionContaReceberClassFuncionarioOriginal)
                  {
                    CollectionContaReceberClassFuncionario.Add(Entidades.ContaReceberClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionContaReceberClassFuncionarioRemovidos.Clear();
               }
               if (_valueCollectionCredorDevedorClassFuncionarioLoaded) 
               {
                  CollectionCredorDevedorClassFuncionario.Clear();
                  foreach(int item in _collectionCredorDevedorClassFuncionarioOriginal)
                  {
                    CollectionCredorDevedorClassFuncionario.Add(Entidades.CredorDevedorClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionCredorDevedorClassFuncionarioRemovidos.Clear();
               }
               if (_valueCollectionFuncionarioDocumentoClassFuncionarioLoaded) 
               {
                  CollectionFuncionarioDocumentoClassFuncionario.Clear();
                  foreach(int item in _collectionFuncionarioDocumentoClassFuncionarioOriginal)
                  {
                    CollectionFuncionarioDocumentoClassFuncionario.Add(Entidades.FuncionarioDocumentoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionFuncionarioDocumentoClassFuncionarioRemovidos.Clear();
               }
               if (_valueCollectionFuncionarioEpiClassFuncionarioLoaded) 
               {
                  CollectionFuncionarioEpiClassFuncionario.Clear();
                  foreach(int item in _collectionFuncionarioEpiClassFuncionarioOriginal)
                  {
                    CollectionFuncionarioEpiClassFuncionario.Add(Entidades.FuncionarioEpiClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionFuncionarioEpiClassFuncionarioRemovidos.Clear();
               }
               if (_valueCollectionFuncionarioFuncaoClassFuncionarioLoaded) 
               {
                  CollectionFuncionarioFuncaoClassFuncionario.Clear();
                  foreach(int item in _collectionFuncionarioFuncaoClassFuncionarioOriginal)
                  {
                    CollectionFuncionarioFuncaoClassFuncionario.Add(Entidades.FuncionarioFuncaoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionFuncionarioFuncaoClassFuncionarioRemovidos.Clear();
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
               if (_valueCollectionContaPagarClassFuncionarioLoaded) 
               {
                  if (_valueCollectionContaPagarClassFuncionarioChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaReceberClassFuncionarioLoaded) 
               {
                  if (_valueCollectionContaReceberClassFuncionarioChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionCredorDevedorClassFuncionarioLoaded) 
               {
                  if (_valueCollectionCredorDevedorClassFuncionarioChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFuncionarioDocumentoClassFuncionarioLoaded) 
               {
                  if (_valueCollectionFuncionarioDocumentoClassFuncionarioChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFuncionarioEpiClassFuncionarioLoaded) 
               {
                  if (_valueCollectionFuncionarioEpiClassFuncionarioChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFuncionarioFuncaoClassFuncionarioLoaded) 
               {
                  if (_valueCollectionFuncionarioFuncaoClassFuncionarioChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaPagarClassFuncionarioLoaded) 
               {
                   tempRet = CollectionContaPagarClassFuncionario.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionContaReceberClassFuncionarioLoaded) 
               {
                   tempRet = CollectionContaReceberClassFuncionario.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionCredorDevedorClassFuncionarioLoaded) 
               {
                   tempRet = CollectionCredorDevedorClassFuncionario.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionFuncionarioDocumentoClassFuncionarioLoaded) 
               {
                   tempRet = CollectionFuncionarioDocumentoClassFuncionario.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionFuncionarioEpiClassFuncionarioLoaded) 
               {
                   tempRet = CollectionFuncionarioEpiClassFuncionario.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionFuncionarioFuncaoClassFuncionarioLoaded) 
               {
                   tempRet = CollectionFuncionarioFuncaoClassFuncionario.Any(item => item.IsDirty());
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
       dirty = _cpfOriginal != Cpf;
      if (dirty) return true;
       dirty = _rgOriginal != Rg;
      if (dirty) return true;
       dirty = _pisOriginal != Pis;
      if (dirty) return true;
       dirty = _numeroCtpsOriginal != NumeroCtps;
      if (dirty) return true;
       dirty = _dataNascimentoOriginal != DataNascimento;
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
       dirty = _bancoOriginal != Banco;
      if (dirty) return true;
       dirty = _agenciaOriginal != Agencia;
      if (dirty) return true;
       dirty = _contaOriginal != Conta;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _ultimaRevisaoOriginal != UltimaRevisao;
      if (dirty) return true;
       dirty = _ctpsSerieOriginal != CtpsSerie;
      if (dirty) return true;
       if (_estadoCtpsOriginal!=null)
       {
          dirty = !_estadoCtpsOriginal.Equals(EstadoCtps);
       }
       else
       {
            dirty = EstadoCtps != null;
       }
      if (dirty) return true;
               if (FotoLoaded)
               {
                using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                   { 
                      string tmpFoto ;
                      if (this._valueFoto == null) 
                      { 
                         tmpFoto = null; 
                      } 
                      else 
                      { 
                         tmpFoto = Convert.ToBase64String(sha1.ComputeHash(this._valueFoto));
                      } 
                       dirty = _fotoOriginal != tmpFoto;
                   }
               }
      if (dirty) return true;
       dirty = _dataAdmissaoOriginal != DataAdmissao;
      if (dirty) return true;
       dirty = _dataDemissaoOriginal != DataDemissao;
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
               if (_valueCollectionContaPagarClassFuncionarioLoaded) 
               {
                  if (_valueCollectionContaPagarClassFuncionarioCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaReceberClassFuncionarioLoaded) 
               {
                  if (_valueCollectionContaReceberClassFuncionarioCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionCredorDevedorClassFuncionarioLoaded) 
               {
                  if (_valueCollectionCredorDevedorClassFuncionarioCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFuncionarioDocumentoClassFuncionarioLoaded) 
               {
                  if (_valueCollectionFuncionarioDocumentoClassFuncionarioCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFuncionarioEpiClassFuncionarioLoaded) 
               {
                  if (_valueCollectionFuncionarioEpiClassFuncionarioCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFuncionarioFuncaoClassFuncionarioLoaded) 
               {
                  if (_valueCollectionFuncionarioFuncaoClassFuncionarioCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaPagarClassFuncionarioLoaded) 
               {
                   tempRet = CollectionContaPagarClassFuncionario.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionContaReceberClassFuncionarioLoaded) 
               {
                   tempRet = CollectionContaReceberClassFuncionario.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionCredorDevedorClassFuncionarioLoaded) 
               {
                   tempRet = CollectionCredorDevedorClassFuncionario.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionFuncionarioDocumentoClassFuncionarioLoaded) 
               {
                   tempRet = CollectionFuncionarioDocumentoClassFuncionario.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionFuncionarioEpiClassFuncionarioLoaded) 
               {
                   tempRet = CollectionFuncionarioEpiClassFuncionario.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionFuncionarioFuncaoClassFuncionarioLoaded) 
               {
                   tempRet = CollectionFuncionarioFuncaoClassFuncionario.Any(item => item.IsDirtyCommited());
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
       dirty = _cpfOriginalCommited != Cpf;
      if (dirty) return true;
       dirty = _rgOriginalCommited != Rg;
      if (dirty) return true;
       dirty = _pisOriginalCommited != Pis;
      if (dirty) return true;
       dirty = _numeroCtpsOriginalCommited != NumeroCtps;
      if (dirty) return true;
       dirty = _dataNascimentoOriginalCommited != DataNascimento;
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
       dirty = _bancoOriginalCommited != Banco;
      if (dirty) return true;
       dirty = _agenciaOriginalCommited != Agencia;
      if (dirty) return true;
       dirty = _contaOriginalCommited != Conta;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _ultimaRevisaoOriginalCommited != UltimaRevisao;
      if (dirty) return true;
       dirty = _ctpsSerieOriginalCommited != CtpsSerie;
      if (dirty) return true;
       if (_estadoCtpsOriginalCommited!=null)
       {
          dirty = !_estadoCtpsOriginalCommited.Equals(EstadoCtps);
       }
       else
       {
            dirty = EstadoCtps != null;
       }
      if (dirty) return true;
               if (FotoLoaded)
               {
                using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                   { 
                      string tmpFoto ;
                      if (this._valueFoto == null) 
                      { 
                         tmpFoto = null; 
                      } 
                      else 
                      { 
                         tmpFoto = Convert.ToBase64String(sha1.ComputeHash(this._valueFoto));
                      } 
                       dirty = _fotoOriginalCommited != tmpFoto;
                   }
               }
      if (dirty) return true;
       dirty = _dataAdmissaoOriginalCommited != DataAdmissao;
      if (dirty) return true;
       dirty = _dataDemissaoOriginalCommited != DataDemissao;
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
               if (_valueCollectionContaPagarClassFuncionarioLoaded) 
               {
                  foreach(ContaPagarClass item in CollectionContaPagarClassFuncionario)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionContaReceberClassFuncionarioLoaded) 
               {
                  foreach(ContaReceberClass item in CollectionContaReceberClassFuncionario)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionCredorDevedorClassFuncionarioLoaded) 
               {
                  foreach(CredorDevedorClass item in CollectionCredorDevedorClassFuncionario)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionFuncionarioDocumentoClassFuncionarioLoaded) 
               {
                  foreach(FuncionarioDocumentoClass item in CollectionFuncionarioDocumentoClassFuncionario)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionFuncionarioEpiClassFuncionarioLoaded) 
               {
                  foreach(FuncionarioEpiClass item in CollectionFuncionarioEpiClassFuncionario)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionFuncionarioFuncaoClassFuncionarioLoaded) 
               {
                  foreach(FuncionarioFuncaoClass item in CollectionFuncionarioFuncaoClassFuncionario)
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
             case "Cpf":
                return this.Cpf;
             case "Rg":
                return this.Rg;
             case "Pis":
                return this.Pis;
             case "NumeroCtps":
                return this.NumeroCtps;
             case "DataNascimento":
                return this.DataNascimento;
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
             case "Banco":
                return this.Banco;
             case "Agencia":
                return this.Agencia;
             case "Conta":
                return this.Conta;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "CtpsSerie":
                return this.CtpsSerie;
             case "EstadoCtps":
                return this.EstadoCtps;
             case "Foto":
                return this.Foto;
             case "DataAdmissao":
                return this.DataAdmissao;
             case "DataDemissao":
                return this.DataDemissao;
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
             if (Cidade!=null)
                Cidade.ChangeSingleConnection(newConnection);
             if (EstadoCtps!=null)
                EstadoCtps.ChangeSingleConnection(newConnection);
               if (_valueCollectionContaPagarClassFuncionarioLoaded) 
               {
                  foreach(ContaPagarClass item in CollectionContaPagarClassFuncionario)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionContaReceberClassFuncionarioLoaded) 
               {
                  foreach(ContaReceberClass item in CollectionContaReceberClassFuncionario)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionCredorDevedorClassFuncionarioLoaded) 
               {
                  foreach(CredorDevedorClass item in CollectionCredorDevedorClassFuncionario)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionFuncionarioDocumentoClassFuncionarioLoaded) 
               {
                  foreach(FuncionarioDocumentoClass item in CollectionFuncionarioDocumentoClassFuncionario)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionFuncionarioEpiClassFuncionarioLoaded) 
               {
                  foreach(FuncionarioEpiClass item in CollectionFuncionarioEpiClassFuncionario)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionFuncionarioFuncaoClassFuncionarioLoaded) 
               {
                  foreach(FuncionarioFuncaoClass item in CollectionFuncionarioFuncaoClassFuncionario)
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
                  command.CommandText += " COUNT(funcionario.id_funcionario) " ;
               }
               else
               {
               command.CommandText += "funcionario.id_funcionario, " ;
               command.CommandText += "funcionario.fuc_nome, " ;
               command.CommandText += "funcionario.fuc_cpf, " ;
               command.CommandText += "funcionario.fuc_rg, " ;
               command.CommandText += "funcionario.fuc_pis, " ;
               command.CommandText += "funcionario.fuc_numero_ctps, " ;
               command.CommandText += "funcionario.fuc_data_nascimento, " ;
               command.CommandText += "funcionario.fuc_endereco, " ;
               command.CommandText += "funcionario.fuc_endereco_numero, " ;
               command.CommandText += "funcionario.fuc_endereco_complemento, " ;
               command.CommandText += "funcionario.fuc_bairro, " ;
               command.CommandText += "funcionario.fuc_cep, " ;
               command.CommandText += "funcionario.fuc_fone1, " ;
               command.CommandText += "funcionario.fuc_fone2, " ;
               command.CommandText += "funcionario.id_cidade, " ;
               command.CommandText += "funcionario.fuc_email, " ;
               command.CommandText += "funcionario.fuc_banco, " ;
               command.CommandText += "funcionario.fuc_agencia, " ;
               command.CommandText += "funcionario.fuc_conta, " ;
               command.CommandText += "funcionario.entity_uid, " ;
               command.CommandText += "funcionario.version, " ;
               command.CommandText += "funcionario.fuc_ultima_revisao, " ;
               command.CommandText += "funcionario.fuc_ultima_revisao_data, " ;
               command.CommandText += "funcionario.id_acs_usuario_ultima_revisao, " ;
               command.CommandText += "funcionario.fuc_ctps_serie, " ;
               command.CommandText += "funcionario.id_estado_ctps, " ;
               command.CommandText += "funcionario.fuc_data_admissao, " ;
               command.CommandText += "funcionario.fuc_data_demissao, " ;
               command.CommandText += "funcionario.fuc_ativo " ;
               }
               command.CommandText += " FROM  funcionario ";
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
                        orderByClause += " , fuc_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(fuc_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = funcionario.id_acs_usuario_ultima_revisao ";
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
                     case "id_funcionario":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , funcionario.id_funcionario " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(funcionario.id_funcionario) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fuc_nome":
                     case "Nome":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , funcionario.fuc_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(funcionario.fuc_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fuc_cpf":
                     case "Cpf":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , funcionario.fuc_cpf " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(funcionario.fuc_cpf) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fuc_rg":
                     case "Rg":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , funcionario.fuc_rg " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(funcionario.fuc_rg) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fuc_pis":
                     case "Pis":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , funcionario.fuc_pis " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(funcionario.fuc_pis) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fuc_numero_ctps":
                     case "NumeroCtps":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , funcionario.fuc_numero_ctps " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(funcionario.fuc_numero_ctps) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fuc_data_nascimento":
                     case "DataNascimento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , funcionario.fuc_data_nascimento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(funcionario.fuc_data_nascimento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fuc_endereco":
                     case "Endereco":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , funcionario.fuc_endereco " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(funcionario.fuc_endereco) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fuc_endereco_numero":
                     case "EnderecoNumero":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , funcionario.fuc_endereco_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(funcionario.fuc_endereco_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fuc_endereco_complemento":
                     case "EnderecoComplemento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , funcionario.fuc_endereco_complemento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(funcionario.fuc_endereco_complemento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fuc_bairro":
                     case "Bairro":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , funcionario.fuc_bairro " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(funcionario.fuc_bairro) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fuc_cep":
                     case "Cep":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , funcionario.fuc_cep " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(funcionario.fuc_cep) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fuc_fone1":
                     case "Fone1":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , funcionario.fuc_fone1 " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(funcionario.fuc_fone1) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fuc_fone2":
                     case "Fone2":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , funcionario.fuc_fone2 " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(funcionario.fuc_fone2) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_cidade":
                     case "Cidade":
                     command.CommandText += " LEFT JOIN cidade as cidade_Cidade ON cidade_Cidade.id_cidade = funcionario.id_cidade ";                     switch (parametro.TipoOrdenacao)
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
                     case "fuc_email":
                     case "Email":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , funcionario.fuc_email " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(funcionario.fuc_email) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fuc_banco":
                     case "Banco":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , funcionario.fuc_banco " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(funcionario.fuc_banco) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fuc_agencia":
                     case "Agencia":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , funcionario.fuc_agencia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(funcionario.fuc_agencia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fuc_conta":
                     case "Conta":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , funcionario.fuc_conta " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(funcionario.fuc_conta) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , funcionario.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(funcionario.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , funcionario.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(funcionario.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fuc_ultima_revisao":
                     case "UltimaRevisao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , funcionario.fuc_ultima_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(funcionario.fuc_ultima_revisao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fuc_ultima_revisao_data":
                     case "UltimaRevisaoData":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , funcionario.fuc_ultima_revisao_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(funcionario.fuc_ultima_revisao_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_ultima_revisao":
                     case "UltimaRevisaoUsuario":
                     orderByClause += " , funcionario.id_acs_usuario_ultima_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "fuc_ctps_serie":
                     case "CtpsSerie":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , funcionario.fuc_ctps_serie " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(funcionario.fuc_ctps_serie) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_estado_ctps":
                     case "EstadoCtps":
                     command.CommandText += " LEFT JOIN estado as estado_EstadoCtps ON estado_EstadoCtps.id_estado = funcionario.id_estado_ctps ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , estado_EstadoCtps.est_sigla " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(estado_EstadoCtps.est_sigla) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , estado_EstadoCtps.est_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(estado_EstadoCtps.est_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fuc_foto":
                     case "Foto":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , funcionario.fuc_foto " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(funcionario.fuc_foto) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fuc_data_admissao":
                     case "DataAdmissao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , funcionario.fuc_data_admissao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(funcionario.fuc_data_admissao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fuc_data_demissao":
                     case "DataDemissao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , funcionario.fuc_data_demissao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(funcionario.fuc_data_demissao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fuc_ativo":
                     case "Ativo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , funcionario.fuc_ativo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(funcionario.fuc_ativo) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("fuc_nome")) 
                        {
                           whereClause += " OR UPPER(funcionario.fuc_nome) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(funcionario.fuc_nome) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("fuc_cpf")) 
                        {
                           whereClause += " OR UPPER(funcionario.fuc_cpf) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(funcionario.fuc_cpf) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("fuc_rg")) 
                        {
                           whereClause += " OR UPPER(funcionario.fuc_rg) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(funcionario.fuc_rg) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("fuc_pis")) 
                        {
                           whereClause += " OR UPPER(funcionario.fuc_pis) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(funcionario.fuc_pis) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("fuc_numero_ctps")) 
                        {
                           whereClause += " OR UPPER(funcionario.fuc_numero_ctps) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(funcionario.fuc_numero_ctps) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("fuc_endereco")) 
                        {
                           whereClause += " OR UPPER(funcionario.fuc_endereco) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(funcionario.fuc_endereco) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("fuc_endereco_numero")) 
                        {
                           whereClause += " OR UPPER(funcionario.fuc_endereco_numero) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(funcionario.fuc_endereco_numero) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("fuc_endereco_complemento")) 
                        {
                           whereClause += " OR UPPER(funcionario.fuc_endereco_complemento) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(funcionario.fuc_endereco_complemento) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("fuc_bairro")) 
                        {
                           whereClause += " OR UPPER(funcionario.fuc_bairro) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(funcionario.fuc_bairro) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("fuc_cep")) 
                        {
                           whereClause += " OR UPPER(funcionario.fuc_cep) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(funcionario.fuc_cep) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("fuc_fone1")) 
                        {
                           whereClause += " OR UPPER(funcionario.fuc_fone1) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(funcionario.fuc_fone1) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("fuc_fone2")) 
                        {
                           whereClause += " OR UPPER(funcionario.fuc_fone2) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(funcionario.fuc_fone2) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("fuc_email")) 
                        {
                           whereClause += " OR UPPER(funcionario.fuc_email) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(funcionario.fuc_email) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("fuc_banco")) 
                        {
                           whereClause += " OR UPPER(funcionario.fuc_banco) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(funcionario.fuc_banco) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("fuc_agencia")) 
                        {
                           whereClause += " OR UPPER(funcionario.fuc_agencia) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(funcionario.fuc_agencia) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("fuc_conta")) 
                        {
                           whereClause += " OR UPPER(funcionario.fuc_conta) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(funcionario.fuc_conta) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(funcionario.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(funcionario.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("fuc_ultima_revisao")) 
                        {
                           whereClause += " OR UPPER(funcionario.fuc_ultima_revisao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(funcionario.fuc_ultima_revisao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("fuc_ctps_serie")) 
                        {
                           whereClause += " OR UPPER(funcionario.fuc_ctps_serie) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(funcionario.fuc_ctps_serie) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_funcionario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  funcionario.id_funcionario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.id_funcionario = :funcionario_ID_3314 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_ID_3314", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Nome" || parametro.FieldName == "fuc_nome")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  funcionario.fuc_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.fuc_nome LIKE :funcionario_Nome_2252 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_Nome_2252", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cpf" || parametro.FieldName == "fuc_cpf")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  funcionario.fuc_cpf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.fuc_cpf LIKE :funcionario_Cpf_4498 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_Cpf_4498", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Rg" || parametro.FieldName == "fuc_rg")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  funcionario.fuc_rg IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.fuc_rg LIKE :funcionario_Rg_7065 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_Rg_7065", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Pis" || parametro.FieldName == "fuc_pis")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  funcionario.fuc_pis IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.fuc_pis LIKE :funcionario_Pis_8708 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_Pis_8708", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroCtps" || parametro.FieldName == "fuc_numero_ctps")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  funcionario.fuc_numero_ctps IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.fuc_numero_ctps LIKE :funcionario_NumeroCtps_5711 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_NumeroCtps_5711", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataNascimento" || parametro.FieldName == "fuc_data_nascimento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  funcionario.fuc_data_nascimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.fuc_data_nascimento = :funcionario_DataNascimento_317 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_DataNascimento_317", NpgsqlDbType.Date, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Endereco" || parametro.FieldName == "fuc_endereco")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  funcionario.fuc_endereco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.fuc_endereco LIKE :funcionario_Endereco_3647 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_Endereco_3647", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EnderecoNumero" || parametro.FieldName == "fuc_endereco_numero")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  funcionario.fuc_endereco_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.fuc_endereco_numero LIKE :funcionario_EnderecoNumero_8486 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_EnderecoNumero_8486", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EnderecoComplemento" || parametro.FieldName == "fuc_endereco_complemento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  funcionario.fuc_endereco_complemento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.fuc_endereco_complemento LIKE :funcionario_EnderecoComplemento_1643 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_EnderecoComplemento_1643", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Bairro" || parametro.FieldName == "fuc_bairro")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  funcionario.fuc_bairro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.fuc_bairro LIKE :funcionario_Bairro_9748 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_Bairro_9748", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cep" || parametro.FieldName == "fuc_cep")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  funcionario.fuc_cep IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.fuc_cep LIKE :funcionario_Cep_7175 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_Cep_7175", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Fone1" || parametro.FieldName == "fuc_fone1")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  funcionario.fuc_fone1 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.fuc_fone1 LIKE :funcionario_Fone1_5313 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_Fone1_5313", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Fone2" || parametro.FieldName == "fuc_fone2")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  funcionario.fuc_fone2 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.fuc_fone2 LIKE :funcionario_Fone2_2306 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_Fone2_2306", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  funcionario.id_cidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.id_cidade = :funcionario_Cidade_9490 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_Cidade_9490", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Email" || parametro.FieldName == "fuc_email")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  funcionario.fuc_email IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.fuc_email LIKE :funcionario_Email_9336 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_Email_9336", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Banco" || parametro.FieldName == "fuc_banco")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  funcionario.fuc_banco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.fuc_banco LIKE :funcionario_Banco_2133 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_Banco_2133", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Agencia" || parametro.FieldName == "fuc_agencia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  funcionario.fuc_agencia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.fuc_agencia LIKE :funcionario_Agencia_5774 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_Agencia_5774", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Conta" || parametro.FieldName == "fuc_conta")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  funcionario.fuc_conta IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.fuc_conta LIKE :funcionario_Conta_105 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_Conta_105", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  funcionario.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.entity_uid LIKE :funcionario_EntityUid_3880 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_EntityUid_3880", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  funcionario.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.version = :funcionario_Version_1723 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_Version_1723", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao" || parametro.FieldName == "fuc_ultima_revisao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  funcionario.fuc_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.fuc_ultima_revisao LIKE :funcionario_UltimaRevisao_2720 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_UltimaRevisao_2720", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoData" || parametro.FieldName == "fuc_ultima_revisao_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  funcionario.fuc_ultima_revisao_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.fuc_ultima_revisao_data = :funcionario_UltimaRevisaoData_1509 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_UltimaRevisaoData_1509", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
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
                         whereClause += "  funcionario.id_acs_usuario_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.id_acs_usuario_ultima_revisao = :funcionario_UltimaRevisaoUsuario_2963 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_UltimaRevisaoUsuario_2963", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CtpsSerie" || parametro.FieldName == "fuc_ctps_serie")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  funcionario.fuc_ctps_serie IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.fuc_ctps_serie LIKE :funcionario_CtpsSerie_6140 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_CtpsSerie_6140", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EstadoCtps" || parametro.FieldName == "id_estado_ctps")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.EstadoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.EstadoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  funcionario.id_estado_ctps IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.id_estado_ctps = :funcionario_EstadoCtps_3283 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_EstadoCtps_3283", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Foto" || parametro.FieldName == "fuc_foto")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is byte[])))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo byte[]");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  funcionario.fuc_foto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.fuc_foto = :funcionario_Foto_9870 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_Foto_9870", NpgsqlDbType.Bytea, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataAdmissao" || parametro.FieldName == "fuc_data_admissao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  funcionario.fuc_data_admissao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.fuc_data_admissao = :funcionario_DataAdmissao_3594 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_DataAdmissao_3594", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataDemissao" || parametro.FieldName == "fuc_data_demissao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  funcionario.fuc_data_demissao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.fuc_data_demissao = :funcionario_DataDemissao_3670 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_DataDemissao_3670", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Ativo" || parametro.FieldName == "fuc_ativo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  funcionario.fuc_ativo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.fuc_ativo = :funcionario_Ativo_6275 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_Ativo_6275", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
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
                         whereClause += "  funcionario.fuc_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.fuc_nome LIKE :funcionario_Nome_1510 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_Nome_1510", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CpfExato" || parametro.FieldName == "CpfExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  funcionario.fuc_cpf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.fuc_cpf LIKE :funcionario_Cpf_8914 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_Cpf_8914", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RgExato" || parametro.FieldName == "RgExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  funcionario.fuc_rg IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.fuc_rg LIKE :funcionario_Rg_6547 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_Rg_6547", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PisExato" || parametro.FieldName == "PisExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  funcionario.fuc_pis IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.fuc_pis LIKE :funcionario_Pis_2573 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_Pis_2573", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroCtpsExato" || parametro.FieldName == "NumeroCtpsExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  funcionario.fuc_numero_ctps IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.fuc_numero_ctps LIKE :funcionario_NumeroCtps_611 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_NumeroCtps_611", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  funcionario.fuc_endereco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.fuc_endereco LIKE :funcionario_Endereco_1965 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_Endereco_1965", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  funcionario.fuc_endereco_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.fuc_endereco_numero LIKE :funcionario_EnderecoNumero_1906 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_EnderecoNumero_1906", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  funcionario.fuc_endereco_complemento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.fuc_endereco_complemento LIKE :funcionario_EnderecoComplemento_9286 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_EnderecoComplemento_9286", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  funcionario.fuc_bairro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.fuc_bairro LIKE :funcionario_Bairro_5112 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_Bairro_5112", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  funcionario.fuc_cep IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.fuc_cep LIKE :funcionario_Cep_6932 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_Cep_6932", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  funcionario.fuc_fone1 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.fuc_fone1 LIKE :funcionario_Fone1_3470 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_Fone1_3470", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  funcionario.fuc_fone2 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.fuc_fone2 LIKE :funcionario_Fone2_6415 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_Fone2_6415", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  funcionario.fuc_email IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.fuc_email LIKE :funcionario_Email_6198 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_Email_6198", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  funcionario.fuc_banco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.fuc_banco LIKE :funcionario_Banco_2430 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_Banco_2430", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  funcionario.fuc_agencia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.fuc_agencia LIKE :funcionario_Agencia_9711 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_Agencia_9711", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  funcionario.fuc_conta IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.fuc_conta LIKE :funcionario_Conta_3881 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_Conta_3881", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  funcionario.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.entity_uid LIKE :funcionario_EntityUid_721 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_EntityUid_721", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  funcionario.fuc_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.fuc_ultima_revisao LIKE :funcionario_UltimaRevisao_7997 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_UltimaRevisao_7997", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CtpsSerieExato" || parametro.FieldName == "CtpsSerieExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  funcionario.fuc_ctps_serie IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario.fuc_ctps_serie LIKE :funcionario_CtpsSerie_7930 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_CtpsSerie_7930", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  FuncionarioClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (FuncionarioClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(FuncionarioClass), Convert.ToInt32(read["id_funcionario"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new FuncionarioClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_funcionario"]);
                     entidade.Nome = (read["fuc_nome"] != DBNull.Value ? read["fuc_nome"].ToString() : null);
                     entidade.Cpf = (read["fuc_cpf"] != DBNull.Value ? read["fuc_cpf"].ToString() : null);
                     entidade.Rg = (read["fuc_rg"] != DBNull.Value ? read["fuc_rg"].ToString() : null);
                     entidade.Pis = (read["fuc_pis"] != DBNull.Value ? read["fuc_pis"].ToString() : null);
                     entidade.NumeroCtps = (read["fuc_numero_ctps"] != DBNull.Value ? read["fuc_numero_ctps"].ToString() : null);
                     entidade.DataNascimento = (DateTime)read["fuc_data_nascimento"];
                     entidade.Endereco = (read["fuc_endereco"] != DBNull.Value ? read["fuc_endereco"].ToString() : null);
                     entidade.EnderecoNumero = (read["fuc_endereco_numero"] != DBNull.Value ? read["fuc_endereco_numero"].ToString() : null);
                     entidade.EnderecoComplemento = (read["fuc_endereco_complemento"] != DBNull.Value ? read["fuc_endereco_complemento"].ToString() : null);
                     entidade.Bairro = (read["fuc_bairro"] != DBNull.Value ? read["fuc_bairro"].ToString() : null);
                     entidade.Cep = (read["fuc_cep"] != DBNull.Value ? read["fuc_cep"].ToString() : null);
                     entidade.Fone1 = (read["fuc_fone1"] != DBNull.Value ? read["fuc_fone1"].ToString() : null);
                     entidade.Fone2 = (read["fuc_fone2"] != DBNull.Value ? read["fuc_fone2"].ToString() : null);
                     if (read["id_cidade"] != DBNull.Value)
                     {
                        entidade.Cidade = (BibliotecaEntidades.Entidades.CidadeClass)BibliotecaEntidades.Entidades.CidadeClass.GetEntidade(Convert.ToInt32(read["id_cidade"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Cidade = null ;
                     }
                     entidade.Email = (read["fuc_email"] != DBNull.Value ? read["fuc_email"].ToString() : null);
                     entidade.Banco = (read["fuc_banco"] != DBNull.Value ? read["fuc_banco"].ToString() : null);
                     entidade.Agencia = (read["fuc_agencia"] != DBNull.Value ? read["fuc_agencia"].ToString() : null);
                     entidade.Conta = (read["fuc_conta"] != DBNull.Value ? read["fuc_conta"].ToString() : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.UltimaRevisao = (read["fuc_ultima_revisao"] != DBNull.Value ? read["fuc_ultima_revisao"].ToString() : null);
                     entidade.UltimaRevisaoData = read["fuc_ultima_revisao_data"] as DateTime?;
                     if (read["id_acs_usuario_ultima_revisao"] != DBNull.Value)
                     {
                        entidade.UltimaRevisaoUsuario = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_ultima_revisao"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.UltimaRevisaoUsuario = null ;
                     }
                     entidade.CtpsSerie = (read["fuc_ctps_serie"] != DBNull.Value ? read["fuc_ctps_serie"].ToString() : null);
                     if (read["id_estado_ctps"] != DBNull.Value)
                     {
                        entidade.EstadoCtps = (BibliotecaEntidades.Entidades.EstadoClass)BibliotecaEntidades.Entidades.EstadoClass.GetEntidade(Convert.ToInt32(read["id_estado_ctps"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.EstadoCtps = null ;
                     }
                     entidade.DataAdmissao = (DateTime)read["fuc_data_admissao"];
                     entidade.DataDemissao = read["fuc_data_demissao"] as DateTime?;
                     entidade.Ativo = Convert.ToBoolean(Convert.ToInt16(read["fuc_ativo"]));
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (FuncionarioClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
