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
     [Table("ordem_producao_posto_trabalho","opt")]
     public class OrdemProducaoPostoTrabalhoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do OrdemProducaoPostoTrabalhoClass";
protected const string ErroDelete = "Erro ao excluir o OrdemProducaoPostoTrabalhoClass  ";
protected const string ErroSave = "Erro ao salvar o OrdemProducaoPostoTrabalhoClass.";
protected const string ErroCollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalho = "Erro ao carregar a coleção de OrdemProducaoDiferencaClass.";
protected const string ErroCollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalho = "Erro ao carregar a coleção de OrdemProducaoPostoTrabalhoProducaoClass.";
protected const string ErroPostoCodigoObrigatorio = "O campo PostoCodigo é obrigatório";
protected const string ErroPostoCodigoComprimento = "O campo PostoCodigo deve ter no máximo 255 caracteres";
protected const string ErroPostoNomeObrigatorio = "O campo PostoNome é obrigatório";
protected const string ErroPostoNomeComprimento = "O campo PostoNome deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroOrdemProducaoObrigatorio = "O campo OrdemProducao é obrigatório";
protected const string ErroPostoTrabalhoObrigatorio = "O campo PostoTrabalho é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do OrdemProducaoPostoTrabalhoClass.";
protected const string MensagemUtilizadoCollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalho =  "A entidade OrdemProducaoPostoTrabalhoClass está sendo utilizada nos seguintes OrdemProducaoDiferencaClass:";
protected const string MensagemUtilizadoCollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalho =  "A entidade OrdemProducaoPostoTrabalhoClass está sendo utilizada nos seguintes OrdemProducaoPostoTrabalhoProducaoClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade OrdemProducaoPostoTrabalhoClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.OrdemProducaoClass _ordemProducaoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.OrdemProducaoClass _ordemProducaoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.OrdemProducaoClass _valueOrdemProducao;
        [Column("id_ordem_producao", "ordem_producao", "id_ordem_producao")]
       public virtual BibliotecaEntidades.Entidades.OrdemProducaoClass OrdemProducao
        { 
           get {                 return this._valueOrdemProducao; } 
           set 
           { 
                if (this._valueOrdemProducao == value)return;
                 this._valueOrdemProducao = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.PostoTrabalhoClass _postoTrabalhoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.PostoTrabalhoClass _postoTrabalhoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.PostoTrabalhoClass _valuePostoTrabalho;
        [Column("id_posto_trabalho", "posto_trabalho", "id_posto_trabalho")]
       public virtual BibliotecaEntidades.Entidades.PostoTrabalhoClass PostoTrabalho
        { 
           get {                 return this._valuePostoTrabalho; } 
           set 
           { 
                if (this._valuePostoTrabalho == value)return;
                 this._valuePostoTrabalho = value; 
           } 
       } 

       protected string _postoCodigoOriginal{get;private set;}
       private string _postoCodigoOriginalCommited{get; set;}
        private string _valuePostoCodigo;
         [Column("opt_posto_codigo")]
        public virtual string PostoCodigo
         { 
            get { return this._valuePostoCodigo; } 
            set 
            { 
                if (this._valuePostoCodigo == value)return;
                 this._valuePostoCodigo = value; 
            } 
        } 

       protected string _postoNomeOriginal{get;private set;}
       private string _postoNomeOriginalCommited{get; set;}
        private string _valuePostoNome;
         [Column("opt_posto_nome")]
        public virtual string PostoNome
         { 
            get { return this._valuePostoNome; } 
            set 
            { 
                if (this._valuePostoNome == value)return;
                 this._valuePostoNome = value; 
            } 
        } 

       protected string _postoOperacaoOriginal{get;private set;}
       private string _postoOperacaoOriginalCommited{get; set;}
        private string _valuePostoOperacao;
         [Column("opt_posto_operacao")]
        public virtual string PostoOperacao
         { 
            get { return this._valuePostoOperacao; } 
            set 
            { 
                if (this._valuePostoOperacao == value)return;
                 this._valuePostoOperacao = value; 
            } 
        } 

       protected string _operadorTempo1Original{get;private set;}
       private string _operadorTempo1OriginalCommited{get; set;}
        private string _valueOperadorTempo1;
         [Column("opt_operador_tempo_1")]
        public virtual string OperadorTempo1
         { 
            get { return this._valueOperadorTempo1; } 
            set 
            { 
                if (this._valueOperadorTempo1 == value)return;
                 this._valueOperadorTempo1 = value; 
            } 
        } 

       protected IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioTempo1Original{get;private set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioTempo1OriginalCommited {get; set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _valueAcsUsuarioTempo1;
        [Column("id_acs_usuario_tempo_1", "acs_usuario", "id_acs_usuario")]
       public virtual IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass AcsUsuarioTempo1
        { 
           get {                 return this._valueAcsUsuarioTempo1; } 
           set 
           { 
                if (this._valueAcsUsuarioTempo1 == value)return;
                 this._valueAcsUsuarioTempo1 = value; 
           } 
       } 

       protected DateTime? _tempo1Original{get;private set;}
       private DateTime? _tempo1OriginalCommited{get; set;}
        private DateTime? _valueTempo1;
         [Column("opt_tempo1")]
        public virtual DateTime? Tempo1
         { 
            get { return this._valueTempo1; } 
            set 
            { 
                if (this._valueTempo1 == value)return;
                 this._valueTempo1 = value; 
            } 
        } 

       protected DateTime? _tempo2Original{get;private set;}
       private DateTime? _tempo2OriginalCommited{get; set;}
        private DateTime? _valueTempo2;
         [Column("opt_tempo2")]
        public virtual DateTime? Tempo2
         { 
            get { return this._valueTempo2; } 
            set 
            { 
                if (this._valueTempo2 == value)return;
                 this._valueTempo2 = value; 
            } 
        } 

       protected DateTime? _tempo3Original{get;private set;}
       private DateTime? _tempo3OriginalCommited{get; set;}
        private DateTime? _valueTempo3;
         [Column("opt_tempo3")]
        public virtual DateTime? Tempo3
         { 
            get { return this._valueTempo3; } 
            set 
            { 
                if (this._valueTempo3 == value)return;
                 this._valueTempo3 = value; 
            } 
        } 

       protected DateTime? _tempo4Original{get;private set;}
       private DateTime? _tempo4OriginalCommited{get; set;}
        private DateTime? _valueTempo4;
         [Column("opt_tempo4")]
        public virtual DateTime? Tempo4
         { 
            get { return this._valueTempo4; } 
            set 
            { 
                if (this._valueTempo4 == value)return;
                 this._valueTempo4 = value; 
            } 
        } 

       protected double? _quantidadeEntradaOriginal{get;private set;}
       private double? _quantidadeEntradaOriginalCommited{get; set;}
        private double? _valueQuantidadeEntrada;
         [Column("opt_quantidade_entrada")]
        public virtual double? QuantidadeEntrada
         { 
            get { return this._valueQuantidadeEntrada; } 
            set 
            { 
                if (this._valueQuantidadeEntrada == value)return;
                 this._valueQuantidadeEntrada = value; 
            } 
        } 

       protected double? _quantidadeSaidaOriginal{get;private set;}
       private double? _quantidadeSaidaOriginalCommited{get; set;}
        private double? _valueQuantidadeSaida;
         [Column("opt_quantidade_saida")]
        public virtual double? QuantidadeSaida
         { 
            get { return this._valueQuantidadeSaida; } 
            set 
            { 
                if (this._valueQuantidadeSaida == value)return;
                 this._valueQuantidadeSaida = value; 
            } 
        } 

       protected int _sequenciaOriginal{get;private set;}
       private int _sequenciaOriginalCommited{get; set;}
        private int _valueSequencia;
         [Column("opt_sequencia")]
        public virtual int Sequencia
         { 
            get { return this._valueSequencia; } 
            set 
            { 
                if (this._valueSequencia == value)return;
                 this._valueSequencia = value; 
            } 
        } 

       protected double? _tempoSetupOriginal{get;private set;}
       private double? _tempoSetupOriginalCommited{get; set;}
        private double? _valueTempoSetup;
         [Column("opt_tempo_setup")]
        public virtual double? TempoSetup
         { 
            get { return this._valueTempoSetup; } 
            set 
            { 
                if (this._valueTempoSetup == value)return;
                 this._valueTempoSetup = value; 
            } 
        } 

       protected double? _tempoProducaoOriginal{get;private set;}
       private double? _tempoProducaoOriginalCommited{get; set;}
        private double? _valueTempoProducao;
         [Column("opt_tempo_producao")]
        public virtual double? TempoProducao
         { 
            get { return this._valueTempoProducao; } 
            set 
            { 
                if (this._valueTempoProducao == value)return;
                 this._valueTempoProducao = value; 
            } 
        } 

       protected string _operadorTempo2Original{get;private set;}
       private string _operadorTempo2OriginalCommited{get; set;}
        private string _valueOperadorTempo2;
         [Column("opt_operador_tempo_2")]
        public virtual string OperadorTempo2
         { 
            get { return this._valueOperadorTempo2; } 
            set 
            { 
                if (this._valueOperadorTempo2 == value)return;
                 this._valueOperadorTempo2 = value; 
            } 
        } 

       protected IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioTempo2Original{get;private set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioTempo2OriginalCommited {get; set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _valueAcsUsuarioTempo2;
        [Column("id_acs_usuario_tempo_2", "acs_usuario", "id_acs_usuario")]
       public virtual IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass AcsUsuarioTempo2
        { 
           get {                 return this._valueAcsUsuarioTempo2; } 
           set 
           { 
                if (this._valueAcsUsuarioTempo2 == value)return;
                 this._valueAcsUsuarioTempo2 = value; 
           } 
       } 

       protected string _operadorTempo3Original{get;private set;}
       private string _operadorTempo3OriginalCommited{get; set;}
        private string _valueOperadorTempo3;
         [Column("opt_operador_tempo_3")]
        public virtual string OperadorTempo3
         { 
            get { return this._valueOperadorTempo3; } 
            set 
            { 
                if (this._valueOperadorTempo3 == value)return;
                 this._valueOperadorTempo3 = value; 
            } 
        } 

       protected IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioTempo3Original{get;private set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioTempo3OriginalCommited {get; set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _valueAcsUsuarioTempo3;
        [Column("id_acs_usuario_tempo_3", "acs_usuario", "id_acs_usuario")]
       public virtual IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass AcsUsuarioTempo3
        { 
           get {                 return this._valueAcsUsuarioTempo3; } 
           set 
           { 
                if (this._valueAcsUsuarioTempo3 == value)return;
                 this._valueAcsUsuarioTempo3 = value; 
           } 
       } 

       protected string _operadorTempo4Original{get;private set;}
       private string _operadorTempo4OriginalCommited{get; set;}
        private string _valueOperadorTempo4;
         [Column("opt_operador_tempo_4")]
        public virtual string OperadorTempo4
         { 
            get { return this._valueOperadorTempo4; } 
            set 
            { 
                if (this._valueOperadorTempo4 == value)return;
                 this._valueOperadorTempo4 = value; 
            } 
        } 

       protected IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioTempo4Original{get;private set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioTempo4OriginalCommited {get; set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _valueAcsUsuarioTempo4;
        [Column("id_acs_usuario_tempo_4", "acs_usuario", "id_acs_usuario")]
       public virtual IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass AcsUsuarioTempo4
        { 
           get {                 return this._valueAcsUsuarioTempo4; } 
           set 
           { 
                if (this._valueAcsUsuarioTempo4 == value)return;
                 this._valueAcsUsuarioTempo4 = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.MotivoAlteracaoQtdOpClass _motivoAlteracaoQtdOpOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.MotivoAlteracaoQtdOpClass _motivoAlteracaoQtdOpOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.MotivoAlteracaoQtdOpClass _valueMotivoAlteracaoQtdOp;
        [Column("id_motivo_alteracao_qtd_op", "motivo_alteracao_qtd_op", "id_motivo_alteracao_qtd_op")]
       public virtual BibliotecaEntidades.Entidades.MotivoAlteracaoQtdOpClass MotivoAlteracaoQtdOp
        { 
           get {                 return this._valueMotivoAlteracaoQtdOp; } 
           set 
           { 
                if (this._valueMotivoAlteracaoQtdOp == value)return;
                 this._valueMotivoAlteracaoQtdOp = value; 
           } 
       } 

       private List<long> _collectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalhoOriginal;
       private List<Entidades.OrdemProducaoDiferencaClass > _collectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalhoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalhoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalhoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalhoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemProducaoDiferencaClass> _valueCollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalho { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemProducaoDiferencaClass> CollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalho 
       { 
           get { if(!_valueCollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalhoLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalho();}
return this._valueCollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalho; } 
           set 
           { 
               this._valueCollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalho = value; 
               this._valueCollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalhoLoaded = true; 
           } 
       } 

       private List<long> _collectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalhoOriginal;
       private List<Entidades.OrdemProducaoPostoTrabalhoProducaoClass > _collectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalhoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalhoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalhoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalhoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemProducaoPostoTrabalhoProducaoClass> _valueCollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalho { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemProducaoPostoTrabalhoProducaoClass> CollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalho 
       { 
           get { if(!_valueCollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalhoLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalho();}
return this._valueCollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalho; } 
           set 
           { 
               this._valueCollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalho = value; 
               this._valueCollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalhoLoaded = true; 
           } 
       } 

        public OrdemProducaoPostoTrabalhoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
             base.SalvarValoresAntigosHabilitado = true;
         }

public static OrdemProducaoPostoTrabalhoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (OrdemProducaoPostoTrabalhoClass) GetEntity(typeof(OrdemProducaoPostoTrabalhoClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalhoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalhoChanged = true;
                  _valueCollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalhoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalhoChanged = true; 
                  _valueCollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalhoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoDiferencaClass item in e.OldItems) 
                 { 
                     _collectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalhoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalhoChanged = true; 
                  _valueCollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalhoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoDiferencaClass item in _valueCollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalho) 
                 { 
                     _collectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalhoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalho()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemProducaoDiferencaClass> oc;
                _valueCollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalhoChanged = false;
                 _valueCollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalhoCommitedChanged = false;
                _collectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalhoRemovidos = new List<Entidades.OrdemProducaoDiferencaClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemProducaoDiferencaClass>();
                }
                else{ 
                   Entidades.OrdemProducaoDiferencaClass search = new Entidades.OrdemProducaoDiferencaClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemProducaoDiferencaClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OrdemProducaoPostoTrabalho", this),                     }                       ).Cast<Entidades.OrdemProducaoDiferencaClass>().ToList());
                 }
                 _valueCollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalho = new BindingList<Entidades.OrdemProducaoDiferencaClass>(oc); 
                 _collectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalhoOriginal= (from a in _valueCollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalho select a.ID).ToList();
                 _valueCollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalhoLoaded = true;
                 oc.CollectionChanged += CollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalhoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalho+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalhoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalhoChanged = true;
                  _valueCollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalhoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalhoChanged = true; 
                  _valueCollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalhoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoPostoTrabalhoProducaoClass item in e.OldItems) 
                 { 
                     _collectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalhoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalhoChanged = true; 
                  _valueCollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalhoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoPostoTrabalhoProducaoClass item in _valueCollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalho) 
                 { 
                     _collectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalhoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalho()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemProducaoPostoTrabalhoProducaoClass> oc;
                _valueCollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalhoChanged = false;
                 _valueCollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalhoCommitedChanged = false;
                _collectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalhoRemovidos = new List<Entidades.OrdemProducaoPostoTrabalhoProducaoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemProducaoPostoTrabalhoProducaoClass>();
                }
                else{ 
                   Entidades.OrdemProducaoPostoTrabalhoProducaoClass search = new Entidades.OrdemProducaoPostoTrabalhoProducaoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemProducaoPostoTrabalhoProducaoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OrdemProducaoPostoTrabalho", this)                    }                       ).Cast<Entidades.OrdemProducaoPostoTrabalhoProducaoClass>().ToList());
                 }
                 _valueCollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalho = new BindingList<Entidades.OrdemProducaoPostoTrabalhoProducaoClass>(oc); 
                 _collectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalhoOriginal= (from a in _valueCollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalho select a.ID).ToList();
                 _valueCollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalhoLoaded = true;
                 oc.CollectionChanged += CollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalhoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalho+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(PostoCodigo))
                {
                    throw new Exception(ErroPostoCodigoObrigatorio);
                }
                if (PostoCodigo.Length >255)
                {
                    throw new Exception( ErroPostoCodigoComprimento);
                }
                if (string.IsNullOrEmpty(PostoNome))
                {
                    throw new Exception(ErroPostoNomeObrigatorio);
                }
                if (PostoNome.Length >255)
                {
                    throw new Exception( ErroPostoNomeComprimento);
                }
                if ( _valueOrdemProducao == null)
                {
                    throw new Exception(ErroOrdemProducaoObrigatorio);
                }
                if ( _valuePostoTrabalho == null)
                {
                    throw new Exception(ErroPostoTrabalhoObrigatorio);
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
                    "  public.ordem_producao_posto_trabalho  " +
                    "WHERE " +
                    "  id_ordem_producao_posto_trabalho = :id";
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
                        "  public.ordem_producao_posto_trabalho   " +
                        "SET  " + 
                        "  id_ordem_producao = :id_ordem_producao, " + 
                        "  id_posto_trabalho = :id_posto_trabalho, " + 
                        "  opt_posto_codigo = :opt_posto_codigo, " + 
                        "  opt_posto_nome = :opt_posto_nome, " + 
                        "  opt_posto_operacao = :opt_posto_operacao, " + 
                        "  opt_operador_tempo_1 = :opt_operador_tempo_1, " + 
                        "  id_acs_usuario_tempo_1 = :id_acs_usuario_tempo_1, " + 
                        "  opt_tempo1 = :opt_tempo1, " + 
                        "  opt_tempo2 = :opt_tempo2, " + 
                        "  opt_tempo3 = :opt_tempo3, " + 
                        "  opt_tempo4 = :opt_tempo4, " + 
                        "  opt_quantidade_entrada = :opt_quantidade_entrada, " + 
                        "  opt_quantidade_saida = :opt_quantidade_saida, " + 
                        "  opt_sequencia = :opt_sequencia, " + 
                        "  opt_tempo_setup = :opt_tempo_setup, " + 
                        "  opt_tempo_producao = :opt_tempo_producao, " + 
                        "  opt_operador_tempo_2 = :opt_operador_tempo_2, " + 
                        "  id_acs_usuario_tempo_2 = :id_acs_usuario_tempo_2, " + 
                        "  opt_operador_tempo_3 = :opt_operador_tempo_3, " + 
                        "  id_acs_usuario_tempo_3 = :id_acs_usuario_tempo_3, " + 
                        "  opt_operador_tempo_4 = :opt_operador_tempo_4, " + 
                        "  id_acs_usuario_tempo_4 = :id_acs_usuario_tempo_4, " + 
                        "  id_motivo_alteracao_qtd_op = :id_motivo_alteracao_qtd_op, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_ordem_producao_posto_trabalho = :id " +
                        "RETURNING id_ordem_producao_posto_trabalho;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.ordem_producao_posto_trabalho " +
                        "( " +
                        "  id_ordem_producao , " + 
                        "  id_posto_trabalho , " + 
                        "  opt_posto_codigo , " + 
                        "  opt_posto_nome , " + 
                        "  opt_posto_operacao , " + 
                        "  opt_operador_tempo_1 , " + 
                        "  id_acs_usuario_tempo_1 , " + 
                        "  opt_tempo1 , " + 
                        "  opt_tempo2 , " + 
                        "  opt_tempo3 , " + 
                        "  opt_tempo4 , " + 
                        "  opt_quantidade_entrada , " + 
                        "  opt_quantidade_saida , " + 
                        "  opt_sequencia , " + 
                        "  opt_tempo_setup , " + 
                        "  opt_tempo_producao , " + 
                        "  opt_operador_tempo_2 , " + 
                        "  id_acs_usuario_tempo_2 , " + 
                        "  opt_operador_tempo_3 , " + 
                        "  id_acs_usuario_tempo_3 , " + 
                        "  opt_operador_tempo_4 , " + 
                        "  id_acs_usuario_tempo_4 , " + 
                        "  id_motivo_alteracao_qtd_op , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_ordem_producao , " + 
                        "  :id_posto_trabalho , " + 
                        "  :opt_posto_codigo , " + 
                        "  :opt_posto_nome , " + 
                        "  :opt_posto_operacao , " + 
                        "  :opt_operador_tempo_1 , " + 
                        "  :id_acs_usuario_tempo_1 , " + 
                        "  :opt_tempo1 , " + 
                        "  :opt_tempo2 , " + 
                        "  :opt_tempo3 , " + 
                        "  :opt_tempo4 , " + 
                        "  :opt_quantidade_entrada , " + 
                        "  :opt_quantidade_saida , " + 
                        "  :opt_sequencia , " + 
                        "  :opt_tempo_setup , " + 
                        "  :opt_tempo_producao , " + 
                        "  :opt_operador_tempo_2 , " + 
                        "  :id_acs_usuario_tempo_2 , " + 
                        "  :opt_operador_tempo_3 , " + 
                        "  :id_acs_usuario_tempo_3 , " + 
                        "  :opt_operador_tempo_4 , " + 
                        "  :id_acs_usuario_tempo_4 , " + 
                        "  :id_motivo_alteracao_qtd_op , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_ordem_producao_posto_trabalho;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.OrdemProducao==null ? (object) DBNull.Value : this.OrdemProducao.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_posto_trabalho", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.PostoTrabalho==null ? (object) DBNull.Value : this.PostoTrabalho.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opt_posto_codigo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PostoCodigo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opt_posto_nome", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PostoNome ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opt_posto_operacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PostoOperacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opt_operador_tempo_1", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.OperadorTempo1 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_tempo_1", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuarioTempo1==null ? (object) DBNull.Value : this.AcsUsuarioTempo1.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opt_tempo1", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Tempo1 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opt_tempo2", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Tempo2 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opt_tempo3", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Tempo3 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opt_tempo4", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Tempo4 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opt_quantidade_entrada", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.QuantidadeEntrada ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opt_quantidade_saida", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.QuantidadeSaida ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opt_sequencia", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Sequencia ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opt_tempo_setup", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.TempoSetup ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opt_tempo_producao", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.TempoProducao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opt_operador_tempo_2", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.OperadorTempo2 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_tempo_2", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuarioTempo2==null ? (object) DBNull.Value : this.AcsUsuarioTempo2.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opt_operador_tempo_3", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.OperadorTempo3 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_tempo_3", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuarioTempo3==null ? (object) DBNull.Value : this.AcsUsuarioTempo3.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opt_operador_tempo_4", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.OperadorTempo4 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_tempo_4", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuarioTempo4==null ? (object) DBNull.Value : this.AcsUsuarioTempo4.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_motivo_alteracao_qtd_op", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.MotivoAlteracaoQtdOp==null ? (object) DBNull.Value : this.MotivoAlteracaoQtdOp.ID;
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
 if (CollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalho.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalho+"\r\n";
                foreach (Entidades.OrdemProducaoDiferencaClass tmp in CollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalho)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalho.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalho+"\r\n";
                foreach (Entidades.OrdemProducaoPostoTrabalhoProducaoClass tmp in CollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalho)
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
        public static OrdemProducaoPostoTrabalhoClass CopiarEntidade(OrdemProducaoPostoTrabalhoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               OrdemProducaoPostoTrabalhoClass toRet = new OrdemProducaoPostoTrabalhoClass(usuario,conn);
 toRet.OrdemProducao= entidadeCopiar.OrdemProducao;
 toRet.PostoTrabalho= entidadeCopiar.PostoTrabalho;
 toRet.PostoCodigo= entidadeCopiar.PostoCodigo;
 toRet.PostoNome= entidadeCopiar.PostoNome;
 toRet.PostoOperacao= entidadeCopiar.PostoOperacao;
 toRet.OperadorTempo1= entidadeCopiar.OperadorTempo1;
 toRet.AcsUsuarioTempo1= entidadeCopiar.AcsUsuarioTempo1;
 toRet.Tempo1= entidadeCopiar.Tempo1;
 toRet.Tempo2= entidadeCopiar.Tempo2;
 toRet.Tempo3= entidadeCopiar.Tempo3;
 toRet.Tempo4= entidadeCopiar.Tempo4;
 toRet.QuantidadeEntrada= entidadeCopiar.QuantidadeEntrada;
 toRet.QuantidadeSaida= entidadeCopiar.QuantidadeSaida;
 toRet.Sequencia= entidadeCopiar.Sequencia;
 toRet.TempoSetup= entidadeCopiar.TempoSetup;
 toRet.TempoProducao= entidadeCopiar.TempoProducao;
 toRet.OperadorTempo2= entidadeCopiar.OperadorTempo2;
 toRet.AcsUsuarioTempo2= entidadeCopiar.AcsUsuarioTempo2;
 toRet.OperadorTempo3= entidadeCopiar.OperadorTempo3;
 toRet.AcsUsuarioTempo3= entidadeCopiar.AcsUsuarioTempo3;
 toRet.OperadorTempo4= entidadeCopiar.OperadorTempo4;
 toRet.AcsUsuarioTempo4= entidadeCopiar.AcsUsuarioTempo4;
 toRet.MotivoAlteracaoQtdOp= entidadeCopiar.MotivoAlteracaoQtdOp;

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
       _ordemProducaoOriginal = OrdemProducao;
       _ordemProducaoOriginalCommited = _ordemProducaoOriginal;
       _postoTrabalhoOriginal = PostoTrabalho;
       _postoTrabalhoOriginalCommited = _postoTrabalhoOriginal;
       _postoCodigoOriginal = PostoCodigo;
       _postoCodigoOriginalCommited = _postoCodigoOriginal;
       _postoNomeOriginal = PostoNome;
       _postoNomeOriginalCommited = _postoNomeOriginal;
       _postoOperacaoOriginal = PostoOperacao;
       _postoOperacaoOriginalCommited = _postoOperacaoOriginal;
       _operadorTempo1Original = OperadorTempo1;
       _operadorTempo1OriginalCommited = _operadorTempo1Original;
       _acsUsuarioTempo1Original = AcsUsuarioTempo1;
       _acsUsuarioTempo1OriginalCommited = _acsUsuarioTempo1Original;
       _tempo1Original = Tempo1;
       _tempo1OriginalCommited = _tempo1Original;
       _tempo2Original = Tempo2;
       _tempo2OriginalCommited = _tempo2Original;
       _tempo3Original = Tempo3;
       _tempo3OriginalCommited = _tempo3Original;
       _tempo4Original = Tempo4;
       _tempo4OriginalCommited = _tempo4Original;
       _quantidadeEntradaOriginal = QuantidadeEntrada;
       _quantidadeEntradaOriginalCommited = _quantidadeEntradaOriginal;
       _quantidadeSaidaOriginal = QuantidadeSaida;
       _quantidadeSaidaOriginalCommited = _quantidadeSaidaOriginal;
       _sequenciaOriginal = Sequencia;
       _sequenciaOriginalCommited = _sequenciaOriginal;
       _tempoSetupOriginal = TempoSetup;
       _tempoSetupOriginalCommited = _tempoSetupOriginal;
       _tempoProducaoOriginal = TempoProducao;
       _tempoProducaoOriginalCommited = _tempoProducaoOriginal;
       _operadorTempo2Original = OperadorTempo2;
       _operadorTempo2OriginalCommited = _operadorTempo2Original;
       _acsUsuarioTempo2Original = AcsUsuarioTempo2;
       _acsUsuarioTempo2OriginalCommited = _acsUsuarioTempo2Original;
       _operadorTempo3Original = OperadorTempo3;
       _operadorTempo3OriginalCommited = _operadorTempo3Original;
       _acsUsuarioTempo3Original = AcsUsuarioTempo3;
       _acsUsuarioTempo3OriginalCommited = _acsUsuarioTempo3Original;
       _operadorTempo4Original = OperadorTempo4;
       _operadorTempo4OriginalCommited = _operadorTempo4Original;
       _acsUsuarioTempo4Original = AcsUsuarioTempo4;
       _acsUsuarioTempo4OriginalCommited = _acsUsuarioTempo4Original;
       _motivoAlteracaoQtdOpOriginal = MotivoAlteracaoQtdOp;
       _motivoAlteracaoQtdOpOriginalCommited = _motivoAlteracaoQtdOpOriginal;
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
       _ordemProducaoOriginalCommited = OrdemProducao;
       _postoTrabalhoOriginalCommited = PostoTrabalho;
       _postoCodigoOriginalCommited = PostoCodigo;
       _postoNomeOriginalCommited = PostoNome;
       _postoOperacaoOriginalCommited = PostoOperacao;
       _operadorTempo1OriginalCommited = OperadorTempo1;
       _acsUsuarioTempo1OriginalCommited = AcsUsuarioTempo1;
       _tempo1OriginalCommited = Tempo1;
       _tempo2OriginalCommited = Tempo2;
       _tempo3OriginalCommited = Tempo3;
       _tempo4OriginalCommited = Tempo4;
       _quantidadeEntradaOriginalCommited = QuantidadeEntrada;
       _quantidadeSaidaOriginalCommited = QuantidadeSaida;
       _sequenciaOriginalCommited = Sequencia;
       _tempoSetupOriginalCommited = TempoSetup;
       _tempoProducaoOriginalCommited = TempoProducao;
       _operadorTempo2OriginalCommited = OperadorTempo2;
       _acsUsuarioTempo2OriginalCommited = AcsUsuarioTempo2;
       _operadorTempo3OriginalCommited = OperadorTempo3;
       _acsUsuarioTempo3OriginalCommited = AcsUsuarioTempo3;
       _operadorTempo4OriginalCommited = OperadorTempo4;
       _acsUsuarioTempo4OriginalCommited = AcsUsuarioTempo4;
       _motivoAlteracaoQtdOpOriginalCommited = MotivoAlteracaoQtdOp;
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
               if (_valueCollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalhoLoaded) 
               {
                  if (_collectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalhoRemovidos != null) 
                  {
                     _collectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalhoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalhoRemovidos = new List<Entidades.OrdemProducaoDiferencaClass>();
                  }
                  _collectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalhoOriginal= (from a in _valueCollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalho select a.ID).ToList();
                  _valueCollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalhoChanged = false;
                  _valueCollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalhoCommitedChanged = false;
               }
               if (_valueCollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalhoLoaded) 
               {
                  if (_collectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalhoRemovidos != null) 
                  {
                     _collectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalhoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalhoRemovidos = new List<Entidades.OrdemProducaoPostoTrabalhoProducaoClass>();
                  }
                  _collectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalhoOriginal= (from a in _valueCollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalho select a.ID).ToList();
                  _valueCollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalhoChanged = false;
                  _valueCollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalhoCommitedChanged = false;
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
               OrdemProducao=_ordemProducaoOriginal;
               _ordemProducaoOriginalCommited=_ordemProducaoOriginal;
               PostoTrabalho=_postoTrabalhoOriginal;
               _postoTrabalhoOriginalCommited=_postoTrabalhoOriginal;
               PostoCodigo=_postoCodigoOriginal;
               _postoCodigoOriginalCommited=_postoCodigoOriginal;
               PostoNome=_postoNomeOriginal;
               _postoNomeOriginalCommited=_postoNomeOriginal;
               PostoOperacao=_postoOperacaoOriginal;
               _postoOperacaoOriginalCommited=_postoOperacaoOriginal;
               OperadorTempo1=_operadorTempo1Original;
               _operadorTempo1OriginalCommited=_operadorTempo1Original;
               AcsUsuarioTempo1=_acsUsuarioTempo1Original;
               _acsUsuarioTempo1OriginalCommited=_acsUsuarioTempo1Original;
               Tempo1=_tempo1Original;
               _tempo1OriginalCommited=_tempo1Original;
               Tempo2=_tempo2Original;
               _tempo2OriginalCommited=_tempo2Original;
               Tempo3=_tempo3Original;
               _tempo3OriginalCommited=_tempo3Original;
               Tempo4=_tempo4Original;
               _tempo4OriginalCommited=_tempo4Original;
               QuantidadeEntrada=_quantidadeEntradaOriginal;
               _quantidadeEntradaOriginalCommited=_quantidadeEntradaOriginal;
               QuantidadeSaida=_quantidadeSaidaOriginal;
               _quantidadeSaidaOriginalCommited=_quantidadeSaidaOriginal;
               Sequencia=_sequenciaOriginal;
               _sequenciaOriginalCommited=_sequenciaOriginal;
               TempoSetup=_tempoSetupOriginal;
               _tempoSetupOriginalCommited=_tempoSetupOriginal;
               TempoProducao=_tempoProducaoOriginal;
               _tempoProducaoOriginalCommited=_tempoProducaoOriginal;
               OperadorTempo2=_operadorTempo2Original;
               _operadorTempo2OriginalCommited=_operadorTempo2Original;
               AcsUsuarioTempo2=_acsUsuarioTempo2Original;
               _acsUsuarioTempo2OriginalCommited=_acsUsuarioTempo2Original;
               OperadorTempo3=_operadorTempo3Original;
               _operadorTempo3OriginalCommited=_operadorTempo3Original;
               AcsUsuarioTempo3=_acsUsuarioTempo3Original;
               _acsUsuarioTempo3OriginalCommited=_acsUsuarioTempo3Original;
               OperadorTempo4=_operadorTempo4Original;
               _operadorTempo4OriginalCommited=_operadorTempo4Original;
               AcsUsuarioTempo4=_acsUsuarioTempo4Original;
               _acsUsuarioTempo4OriginalCommited=_acsUsuarioTempo4Original;
               MotivoAlteracaoQtdOp=_motivoAlteracaoQtdOpOriginal;
               _motivoAlteracaoQtdOpOriginalCommited=_motivoAlteracaoQtdOpOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               if (_valueCollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalhoLoaded) 
               {
                  CollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalho.Clear();
                  foreach(int item in _collectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalhoOriginal)
                  {
                    CollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalho.Add(Entidades.OrdemProducaoDiferencaClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalhoRemovidos.Clear();
               }
               if (_valueCollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalhoLoaded) 
               {
                  CollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalho.Clear();
                  foreach(int item in _collectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalhoOriginal)
                  {
                    CollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalho.Add(Entidades.OrdemProducaoPostoTrabalhoProducaoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalhoRemovidos.Clear();
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
               if (_valueCollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalhoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalhoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalhoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalhoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalhoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalho.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalhoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalho.Any(item => item.IsDirty());
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
       if (_ordemProducaoOriginal!=null)
       {
          dirty = !_ordemProducaoOriginal.Equals(OrdemProducao);
       }
       else
       {
            dirty = OrdemProducao != null;
       }
      if (dirty) return true;
       if (_postoTrabalhoOriginal!=null)
       {
          dirty = !_postoTrabalhoOriginal.Equals(PostoTrabalho);
       }
       else
       {
            dirty = PostoTrabalho != null;
       }
      if (dirty) return true;
       dirty = _postoCodigoOriginal != PostoCodigo;
      if (dirty) return true;
       dirty = _postoNomeOriginal != PostoNome;
      if (dirty) return true;
       dirty = _postoOperacaoOriginal != PostoOperacao;
      if (dirty) return true;
       dirty = _operadorTempo1Original != OperadorTempo1;
      if (dirty) return true;
       if (_acsUsuarioTempo1Original!=null)
       {
          dirty = !_acsUsuarioTempo1Original.Equals(AcsUsuarioTempo1);
       }
       else
       {
            dirty = AcsUsuarioTempo1 != null;
       }
      if (dirty) return true;
       dirty = _tempo1Original != Tempo1;
      if (dirty) return true;
       dirty = _tempo2Original != Tempo2;
      if (dirty) return true;
       dirty = _tempo3Original != Tempo3;
      if (dirty) return true;
       dirty = _tempo4Original != Tempo4;
      if (dirty) return true;
       dirty = _quantidadeEntradaOriginal != QuantidadeEntrada;
      if (dirty) return true;
       dirty = _quantidadeSaidaOriginal != QuantidadeSaida;
      if (dirty) return true;
       dirty = _sequenciaOriginal != Sequencia;
      if (dirty) return true;
       dirty = _tempoSetupOriginal != TempoSetup;
      if (dirty) return true;
       dirty = _tempoProducaoOriginal != TempoProducao;
      if (dirty) return true;
       dirty = _operadorTempo2Original != OperadorTempo2;
      if (dirty) return true;
       if (_acsUsuarioTempo2Original!=null)
       {
          dirty = !_acsUsuarioTempo2Original.Equals(AcsUsuarioTempo2);
       }
       else
       {
            dirty = AcsUsuarioTempo2 != null;
       }
      if (dirty) return true;
       dirty = _operadorTempo3Original != OperadorTempo3;
      if (dirty) return true;
       if (_acsUsuarioTempo3Original!=null)
       {
          dirty = !_acsUsuarioTempo3Original.Equals(AcsUsuarioTempo3);
       }
       else
       {
            dirty = AcsUsuarioTempo3 != null;
       }
      if (dirty) return true;
       dirty = _operadorTempo4Original != OperadorTempo4;
      if (dirty) return true;
       if (_acsUsuarioTempo4Original!=null)
       {
          dirty = !_acsUsuarioTempo4Original.Equals(AcsUsuarioTempo4);
       }
       else
       {
            dirty = AcsUsuarioTempo4 != null;
       }
      if (dirty) return true;
       if (_motivoAlteracaoQtdOpOriginal!=null)
       {
          dirty = !_motivoAlteracaoQtdOpOriginal.Equals(MotivoAlteracaoQtdOp);
       }
       else
       {
            dirty = MotivoAlteracaoQtdOp != null;
       }
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
               if (_valueCollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalhoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalhoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalhoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalhoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalhoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalho.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalhoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalho.Any(item => item.IsDirtyCommited());
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
       if (_ordemProducaoOriginalCommited!=null)
       {
          dirty = !_ordemProducaoOriginalCommited.Equals(OrdemProducao);
       }
       else
       {
            dirty = OrdemProducao != null;
       }
      if (dirty) return true;
       if (_postoTrabalhoOriginalCommited!=null)
       {
          dirty = !_postoTrabalhoOriginalCommited.Equals(PostoTrabalho);
       }
       else
       {
            dirty = PostoTrabalho != null;
       }
      if (dirty) return true;
       dirty = _postoCodigoOriginalCommited != PostoCodigo;
      if (dirty) return true;
       dirty = _postoNomeOriginalCommited != PostoNome;
      if (dirty) return true;
       dirty = _postoOperacaoOriginalCommited != PostoOperacao;
      if (dirty) return true;
       dirty = _operadorTempo1OriginalCommited != OperadorTempo1;
      if (dirty) return true;
       if (_acsUsuarioTempo1OriginalCommited!=null)
       {
          dirty = !_acsUsuarioTempo1OriginalCommited.Equals(AcsUsuarioTempo1);
       }
       else
       {
            dirty = AcsUsuarioTempo1 != null;
       }
      if (dirty) return true;
       dirty = _tempo1OriginalCommited != Tempo1;
      if (dirty) return true;
       dirty = _tempo2OriginalCommited != Tempo2;
      if (dirty) return true;
       dirty = _tempo3OriginalCommited != Tempo3;
      if (dirty) return true;
       dirty = _tempo4OriginalCommited != Tempo4;
      if (dirty) return true;
       dirty = _quantidadeEntradaOriginalCommited != QuantidadeEntrada;
      if (dirty) return true;
       dirty = _quantidadeSaidaOriginalCommited != QuantidadeSaida;
      if (dirty) return true;
       dirty = _sequenciaOriginalCommited != Sequencia;
      if (dirty) return true;
       dirty = _tempoSetupOriginalCommited != TempoSetup;
      if (dirty) return true;
       dirty = _tempoProducaoOriginalCommited != TempoProducao;
      if (dirty) return true;
       dirty = _operadorTempo2OriginalCommited != OperadorTempo2;
      if (dirty) return true;
       if (_acsUsuarioTempo2OriginalCommited!=null)
       {
          dirty = !_acsUsuarioTempo2OriginalCommited.Equals(AcsUsuarioTempo2);
       }
       else
       {
            dirty = AcsUsuarioTempo2 != null;
       }
      if (dirty) return true;
       dirty = _operadorTempo3OriginalCommited != OperadorTempo3;
      if (dirty) return true;
       if (_acsUsuarioTempo3OriginalCommited!=null)
       {
          dirty = !_acsUsuarioTempo3OriginalCommited.Equals(AcsUsuarioTempo3);
       }
       else
       {
            dirty = AcsUsuarioTempo3 != null;
       }
      if (dirty) return true;
       dirty = _operadorTempo4OriginalCommited != OperadorTempo4;
      if (dirty) return true;
       if (_acsUsuarioTempo4OriginalCommited!=null)
       {
          dirty = !_acsUsuarioTempo4OriginalCommited.Equals(AcsUsuarioTempo4);
       }
       else
       {
            dirty = AcsUsuarioTempo4 != null;
       }
      if (dirty) return true;
       if (_motivoAlteracaoQtdOpOriginalCommited!=null)
       {
          dirty = !_motivoAlteracaoQtdOpOriginalCommited.Equals(MotivoAlteracaoQtdOp);
       }
       else
       {
            dirty = MotivoAlteracaoQtdOp != null;
       }
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
               if (_valueCollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalhoLoaded) 
               {
                  foreach(OrdemProducaoDiferencaClass item in CollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalho)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalhoLoaded) 
               {
                  foreach(OrdemProducaoPostoTrabalhoProducaoClass item in CollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalho)
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
             case "OrdemProducao":
                return this.OrdemProducao;
             case "PostoTrabalho":
                return this.PostoTrabalho;
             case "PostoCodigo":
                return this.PostoCodigo;
             case "PostoNome":
                return this.PostoNome;
             case "PostoOperacao":
                return this.PostoOperacao;
             case "OperadorTempo1":
                return this.OperadorTempo1;
             case "AcsUsuarioTempo1":
                return this.AcsUsuarioTempo1;
             case "Tempo1":
                return this.Tempo1;
             case "Tempo2":
                return this.Tempo2;
             case "Tempo3":
                return this.Tempo3;
             case "Tempo4":
                return this.Tempo4;
             case "QuantidadeEntrada":
                return this.QuantidadeEntrada;
             case "QuantidadeSaida":
                return this.QuantidadeSaida;
             case "Sequencia":
                return this.Sequencia;
             case "TempoSetup":
                return this.TempoSetup;
             case "TempoProducao":
                return this.TempoProducao;
             case "OperadorTempo2":
                return this.OperadorTempo2;
             case "AcsUsuarioTempo2":
                return this.AcsUsuarioTempo2;
             case "OperadorTempo3":
                return this.OperadorTempo3;
             case "AcsUsuarioTempo3":
                return this.AcsUsuarioTempo3;
             case "OperadorTempo4":
                return this.OperadorTempo4;
             case "AcsUsuarioTempo4":
                return this.AcsUsuarioTempo4;
             case "MotivoAlteracaoQtdOp":
                return this.MotivoAlteracaoQtdOp;
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
             if (OrdemProducao!=null)
                OrdemProducao.ChangeSingleConnection(newConnection);
             if (PostoTrabalho!=null)
                PostoTrabalho.ChangeSingleConnection(newConnection);
             if (AcsUsuarioTempo1!=null)
                AcsUsuarioTempo1.ChangeSingleConnection(newConnection);
             if (AcsUsuarioTempo2!=null)
                AcsUsuarioTempo2.ChangeSingleConnection(newConnection);
             if (AcsUsuarioTempo3!=null)
                AcsUsuarioTempo3.ChangeSingleConnection(newConnection);
             if (AcsUsuarioTempo4!=null)
                AcsUsuarioTempo4.ChangeSingleConnection(newConnection);
             if (MotivoAlteracaoQtdOp!=null)
                MotivoAlteracaoQtdOp.ChangeSingleConnection(newConnection);
               if (_valueCollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalhoLoaded) 
               {
                  foreach(OrdemProducaoDiferencaClass item in CollectionOrdemProducaoDiferencaClassOrdemProducaoPostoTrabalho)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalhoLoaded) 
               {
                  foreach(OrdemProducaoPostoTrabalhoProducaoClass item in CollectionOrdemProducaoPostoTrabalhoProducaoClassOrdemProducaoPostoTrabalho)
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
                  command.CommandText += " COUNT(ordem_producao_posto_trabalho.id_ordem_producao_posto_trabalho) " ;
               }
               else
               {
               command.CommandText += "ordem_producao_posto_trabalho.id_ordem_producao_posto_trabalho, " ;
               command.CommandText += "ordem_producao_posto_trabalho.id_ordem_producao, " ;
               command.CommandText += "ordem_producao_posto_trabalho.id_posto_trabalho, " ;
               command.CommandText += "ordem_producao_posto_trabalho.opt_posto_codigo, " ;
               command.CommandText += "ordem_producao_posto_trabalho.opt_posto_nome, " ;
               command.CommandText += "ordem_producao_posto_trabalho.opt_posto_operacao, " ;
               command.CommandText += "ordem_producao_posto_trabalho.opt_operador_tempo_1, " ;
               command.CommandText += "ordem_producao_posto_trabalho.id_acs_usuario_tempo_1, " ;
               command.CommandText += "ordem_producao_posto_trabalho.opt_tempo1, " ;
               command.CommandText += "ordem_producao_posto_trabalho.opt_tempo2, " ;
               command.CommandText += "ordem_producao_posto_trabalho.opt_tempo3, " ;
               command.CommandText += "ordem_producao_posto_trabalho.opt_tempo4, " ;
               command.CommandText += "ordem_producao_posto_trabalho.opt_quantidade_entrada, " ;
               command.CommandText += "ordem_producao_posto_trabalho.opt_quantidade_saida, " ;
               command.CommandText += "ordem_producao_posto_trabalho.opt_sequencia, " ;
               command.CommandText += "ordem_producao_posto_trabalho.opt_tempo_setup, " ;
               command.CommandText += "ordem_producao_posto_trabalho.opt_tempo_producao, " ;
               command.CommandText += "ordem_producao_posto_trabalho.opt_operador_tempo_2, " ;
               command.CommandText += "ordem_producao_posto_trabalho.id_acs_usuario_tempo_2, " ;
               command.CommandText += "ordem_producao_posto_trabalho.opt_operador_tempo_3, " ;
               command.CommandText += "ordem_producao_posto_trabalho.id_acs_usuario_tempo_3, " ;
               command.CommandText += "ordem_producao_posto_trabalho.opt_operador_tempo_4, " ;
               command.CommandText += "ordem_producao_posto_trabalho.id_acs_usuario_tempo_4, " ;
               command.CommandText += "ordem_producao_posto_trabalho.id_motivo_alteracao_qtd_op, " ;
               command.CommandText += "ordem_producao_posto_trabalho.entity_uid, " ;
               command.CommandText += "ordem_producao_posto_trabalho.version " ;
               }
               command.CommandText += " FROM  ordem_producao_posto_trabalho ";
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
                        orderByClause += " , opt_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(opt_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = ordem_producao_posto_trabalho.id_acs_usuario_ultima_revisao ";
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
                     case "id_ordem_producao_posto_trabalho":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_posto_trabalho.id_ordem_producao_posto_trabalho " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_posto_trabalho.id_ordem_producao_posto_trabalho) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_ordem_producao":
                     case "OrdemProducao":
                     command.CommandText += " LEFT JOIN ordem_producao as ordem_producao_OrdemProducao ON ordem_producao_OrdemProducao.id_ordem_producao = ordem_producao_posto_trabalho.id_ordem_producao ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_OrdemProducao.id_ordem_producao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_OrdemProducao.id_ordem_producao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_posto_trabalho":
                     case "PostoTrabalho":
                     command.CommandText += " LEFT JOIN posto_trabalho as posto_trabalho_PostoTrabalho ON posto_trabalho_PostoTrabalho.id_posto_trabalho = ordem_producao_posto_trabalho.id_posto_trabalho ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , posto_trabalho_PostoTrabalho.pos_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(posto_trabalho_PostoTrabalho.pos_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opt_posto_codigo":
                     case "PostoCodigo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_posto_trabalho.opt_posto_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_posto_trabalho.opt_posto_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opt_posto_nome":
                     case "PostoNome":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_posto_trabalho.opt_posto_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_posto_trabalho.opt_posto_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opt_posto_operacao":
                     case "PostoOperacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_posto_trabalho.opt_posto_operacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_posto_trabalho.opt_posto_operacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opt_operador_tempo_1":
                     case "OperadorTempo1":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_posto_trabalho.opt_operador_tempo_1 " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_posto_trabalho.opt_operador_tempo_1) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_tempo_1":
                     case "AcsUsuarioTempo1":
                     orderByClause += " , ordem_producao_posto_trabalho.id_acs_usuario_tempo_1 " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "opt_tempo1":
                     case "Tempo1":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_posto_trabalho.opt_tempo1 " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_posto_trabalho.opt_tempo1) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opt_tempo2":
                     case "Tempo2":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_posto_trabalho.opt_tempo2 " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_posto_trabalho.opt_tempo2) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opt_tempo3":
                     case "Tempo3":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_posto_trabalho.opt_tempo3 " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_posto_trabalho.opt_tempo3) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opt_tempo4":
                     case "Tempo4":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_posto_trabalho.opt_tempo4 " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_posto_trabalho.opt_tempo4) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opt_quantidade_entrada":
                     case "QuantidadeEntrada":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_posto_trabalho.opt_quantidade_entrada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_posto_trabalho.opt_quantidade_entrada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opt_quantidade_saida":
                     case "QuantidadeSaida":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_posto_trabalho.opt_quantidade_saida " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_posto_trabalho.opt_quantidade_saida) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opt_sequencia":
                     case "Sequencia":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_posto_trabalho.opt_sequencia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_posto_trabalho.opt_sequencia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opt_tempo_setup":
                     case "TempoSetup":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_posto_trabalho.opt_tempo_setup " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_posto_trabalho.opt_tempo_setup) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opt_tempo_producao":
                     case "TempoProducao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_posto_trabalho.opt_tempo_producao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_posto_trabalho.opt_tempo_producao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opt_operador_tempo_2":
                     case "OperadorTempo2":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_posto_trabalho.opt_operador_tempo_2 " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_posto_trabalho.opt_operador_tempo_2) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_tempo_2":
                     case "AcsUsuarioTempo2":
                     orderByClause += " , ordem_producao_posto_trabalho.id_acs_usuario_tempo_2 " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "opt_operador_tempo_3":
                     case "OperadorTempo3":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_posto_trabalho.opt_operador_tempo_3 " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_posto_trabalho.opt_operador_tempo_3) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_tempo_3":
                     case "AcsUsuarioTempo3":
                     orderByClause += " , ordem_producao_posto_trabalho.id_acs_usuario_tempo_3 " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "opt_operador_tempo_4":
                     case "OperadorTempo4":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_posto_trabalho.opt_operador_tempo_4 " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_posto_trabalho.opt_operador_tempo_4) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_tempo_4":
                     case "AcsUsuarioTempo4":
                     orderByClause += " , ordem_producao_posto_trabalho.id_acs_usuario_tempo_4 " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "id_motivo_alteracao_qtd_op":
                     case "MotivoAlteracaoQtdOp":
                     command.CommandText += " LEFT JOIN motivo_alteracao_qtd_op as motivo_alteracao_qtd_op_MotivoAlteracaoQtdOp ON motivo_alteracao_qtd_op_MotivoAlteracaoQtdOp.id_motivo_alteracao_qtd_op = ordem_producao_posto_trabalho.id_motivo_alteracao_qtd_op ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , motivo_alteracao_qtd_op_MotivoAlteracaoQtdOp.mao_motivo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(motivo_alteracao_qtd_op_MotivoAlteracaoQtdOp.mao_motivo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_posto_trabalho.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_posto_trabalho.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , ordem_producao_posto_trabalho.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_posto_trabalho.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opt_posto_codigo")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_posto_trabalho.opt_posto_codigo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_posto_trabalho.opt_posto_codigo) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opt_posto_nome")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_posto_trabalho.opt_posto_nome) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_posto_trabalho.opt_posto_nome) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opt_posto_operacao")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_posto_trabalho.opt_posto_operacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_posto_trabalho.opt_posto_operacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opt_operador_tempo_1")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_posto_trabalho.opt_operador_tempo_1) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_posto_trabalho.opt_operador_tempo_1) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opt_operador_tempo_2")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_posto_trabalho.opt_operador_tempo_2) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_posto_trabalho.opt_operador_tempo_2) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opt_operador_tempo_3")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_posto_trabalho.opt_operador_tempo_3) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_posto_trabalho.opt_operador_tempo_3) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opt_operador_tempo_4")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_posto_trabalho.opt_operador_tempo_4) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_posto_trabalho.opt_operador_tempo_4) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_posto_trabalho.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_posto_trabalho.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_ordem_producao_posto_trabalho")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_posto_trabalho.id_ordem_producao_posto_trabalho IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho.id_ordem_producao_posto_trabalho = :ordem_producao_posto_trabalho_ID_3565 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_ID_3565", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrdemProducao" || parametro.FieldName == "id_ordem_producao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.OrdemProducaoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.OrdemProducaoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_posto_trabalho.id_ordem_producao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho.id_ordem_producao = :ordem_producao_posto_trabalho_OrdemProducao_3677 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_OrdemProducao_3677", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PostoTrabalho" || parametro.FieldName == "id_posto_trabalho")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.PostoTrabalhoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.PostoTrabalhoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_posto_trabalho.id_posto_trabalho IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho.id_posto_trabalho = :ordem_producao_posto_trabalho_PostoTrabalho_9348 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_PostoTrabalho_9348", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PostoCodigo" || parametro.FieldName == "opt_posto_codigo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_posto_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_posto_codigo LIKE :ordem_producao_posto_trabalho_PostoCodigo_6838 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_PostoCodigo_6838", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PostoNome" || parametro.FieldName == "opt_posto_nome")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_posto_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_posto_nome LIKE :ordem_producao_posto_trabalho_PostoNome_5440 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_PostoNome_5440", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PostoOperacao" || parametro.FieldName == "opt_posto_operacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_posto_operacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_posto_operacao LIKE :ordem_producao_posto_trabalho_PostoOperacao_4286 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_PostoOperacao_4286", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OperadorTempo1" || parametro.FieldName == "opt_operador_tempo_1")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_operador_tempo_1 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_operador_tempo_1 LIKE :ordem_producao_posto_trabalho_OperadorTempo1_1502 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_OperadorTempo1_1502", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcsUsuarioTempo1" || parametro.FieldName == "id_acs_usuario_tempo_1")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_posto_trabalho.id_acs_usuario_tempo_1 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho.id_acs_usuario_tempo_1 = :ordem_producao_posto_trabalho_AcsUsuarioTempo1_5493 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_AcsUsuarioTempo1_5493", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Tempo1" || parametro.FieldName == "opt_tempo1")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_tempo1 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_tempo1 = :ordem_producao_posto_trabalho_Tempo1_6486 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_Tempo1_6486", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Tempo2" || parametro.FieldName == "opt_tempo2")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_tempo2 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_tempo2 = :ordem_producao_posto_trabalho_Tempo2_1802 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_Tempo2_1802", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Tempo3" || parametro.FieldName == "opt_tempo3")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_tempo3 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_tempo3 = :ordem_producao_posto_trabalho_Tempo3_6314 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_Tempo3_6314", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Tempo4" || parametro.FieldName == "opt_tempo4")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_tempo4 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_tempo4 = :ordem_producao_posto_trabalho_Tempo4_7565 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_Tempo4_7565", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "QuantidadeEntrada" || parametro.FieldName == "opt_quantidade_entrada")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_quantidade_entrada IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_quantidade_entrada = :ordem_producao_posto_trabalho_QuantidadeEntrada_5057 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_QuantidadeEntrada_5057", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "QuantidadeSaida" || parametro.FieldName == "opt_quantidade_saida")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_quantidade_saida IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_quantidade_saida = :ordem_producao_posto_trabalho_QuantidadeSaida_5762 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_QuantidadeSaida_5762", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Sequencia" || parametro.FieldName == "opt_sequencia")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_sequencia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_sequencia = :ordem_producao_posto_trabalho_Sequencia_4625 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_Sequencia_4625", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TempoSetup" || parametro.FieldName == "opt_tempo_setup")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_tempo_setup IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_tempo_setup = :ordem_producao_posto_trabalho_TempoSetup_2091 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_TempoSetup_2091", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TempoProducao" || parametro.FieldName == "opt_tempo_producao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_tempo_producao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_tempo_producao = :ordem_producao_posto_trabalho_TempoProducao_786 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_TempoProducao_786", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OperadorTempo2" || parametro.FieldName == "opt_operador_tempo_2")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_operador_tempo_2 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_operador_tempo_2 LIKE :ordem_producao_posto_trabalho_OperadorTempo2_9352 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_OperadorTempo2_9352", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcsUsuarioTempo2" || parametro.FieldName == "id_acs_usuario_tempo_2")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_posto_trabalho.id_acs_usuario_tempo_2 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho.id_acs_usuario_tempo_2 = :ordem_producao_posto_trabalho_AcsUsuarioTempo2_3331 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_AcsUsuarioTempo2_3331", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OperadorTempo3" || parametro.FieldName == "opt_operador_tempo_3")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_operador_tempo_3 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_operador_tempo_3 LIKE :ordem_producao_posto_trabalho_OperadorTempo3_2046 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_OperadorTempo3_2046", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcsUsuarioTempo3" || parametro.FieldName == "id_acs_usuario_tempo_3")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_posto_trabalho.id_acs_usuario_tempo_3 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho.id_acs_usuario_tempo_3 = :ordem_producao_posto_trabalho_AcsUsuarioTempo3_1478 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_AcsUsuarioTempo3_1478", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OperadorTempo4" || parametro.FieldName == "opt_operador_tempo_4")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_operador_tempo_4 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_operador_tempo_4 LIKE :ordem_producao_posto_trabalho_OperadorTempo4_4183 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_OperadorTempo4_4183", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcsUsuarioTempo4" || parametro.FieldName == "id_acs_usuario_tempo_4")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_posto_trabalho.id_acs_usuario_tempo_4 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho.id_acs_usuario_tempo_4 = :ordem_producao_posto_trabalho_AcsUsuarioTempo4_3483 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_AcsUsuarioTempo4_3483", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MotivoAlteracaoQtdOp" || parametro.FieldName == "id_motivo_alteracao_qtd_op")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.MotivoAlteracaoQtdOpClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.MotivoAlteracaoQtdOpClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_posto_trabalho.id_motivo_alteracao_qtd_op IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho.id_motivo_alteracao_qtd_op = :ordem_producao_posto_trabalho_MotivoAlteracaoQtdOp_5829 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_MotivoAlteracaoQtdOp_5829", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  ordem_producao_posto_trabalho.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho.entity_uid LIKE :ordem_producao_posto_trabalho_EntityUid_2756 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_EntityUid_2756", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  ordem_producao_posto_trabalho.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho.version = :ordem_producao_posto_trabalho_Version_457 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_Version_457", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PostoCodigoExato" || parametro.FieldName == "PostoCodigoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_posto_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_posto_codigo LIKE :ordem_producao_posto_trabalho_PostoCodigo_3437 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_PostoCodigo_3437", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PostoNomeExato" || parametro.FieldName == "PostoNomeExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_posto_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_posto_nome LIKE :ordem_producao_posto_trabalho_PostoNome_5127 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_PostoNome_5127", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PostoOperacaoExato" || parametro.FieldName == "PostoOperacaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_posto_operacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_posto_operacao LIKE :ordem_producao_posto_trabalho_PostoOperacao_5505 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_PostoOperacao_5505", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OperadorTempo1Exato" || parametro.FieldName == "OperadorTempo1Exata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_operador_tempo_1 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_operador_tempo_1 LIKE :ordem_producao_posto_trabalho_OperadorTempo1_5244 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_OperadorTempo1_5244", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OperadorTempo2Exato" || parametro.FieldName == "OperadorTempo2Exata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_operador_tempo_2 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_operador_tempo_2 LIKE :ordem_producao_posto_trabalho_OperadorTempo2_4800 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_OperadorTempo2_4800", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OperadorTempo3Exato" || parametro.FieldName == "OperadorTempo3Exata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_operador_tempo_3 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_operador_tempo_3 LIKE :ordem_producao_posto_trabalho_OperadorTempo3_6577 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_OperadorTempo3_6577", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OperadorTempo4Exato" || parametro.FieldName == "OperadorTempo4Exata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_operador_tempo_4 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho.opt_operador_tempo_4 LIKE :ordem_producao_posto_trabalho_OperadorTempo4_3923 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_OperadorTempo4_3923", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  ordem_producao_posto_trabalho.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_posto_trabalho.entity_uid LIKE :ordem_producao_posto_trabalho_EntityUid_4246 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_posto_trabalho_EntityUid_4246", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  OrdemProducaoPostoTrabalhoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (OrdemProducaoPostoTrabalhoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(OrdemProducaoPostoTrabalhoClass), Convert.ToInt32(read["id_ordem_producao_posto_trabalho"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new OrdemProducaoPostoTrabalhoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_ordem_producao_posto_trabalho"]);
                     if (read["id_ordem_producao"] != DBNull.Value)
                     {
                        entidade.OrdemProducao = (BibliotecaEntidades.Entidades.OrdemProducaoClass)BibliotecaEntidades.Entidades.OrdemProducaoClass.GetEntidade(Convert.ToInt32(read["id_ordem_producao"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.OrdemProducao = null ;
                     }
                     if (read["id_posto_trabalho"] != DBNull.Value)
                     {
                        entidade.PostoTrabalho = (BibliotecaEntidades.Entidades.PostoTrabalhoClass)BibliotecaEntidades.Entidades.PostoTrabalhoClass.GetEntidade(Convert.ToInt32(read["id_posto_trabalho"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.PostoTrabalho = null ;
                     }
                     entidade.PostoCodigo = (read["opt_posto_codigo"] != DBNull.Value ? read["opt_posto_codigo"].ToString() : null);
                     entidade.PostoNome = (read["opt_posto_nome"] != DBNull.Value ? read["opt_posto_nome"].ToString() : null);
                     entidade.PostoOperacao = (read["opt_posto_operacao"] != DBNull.Value ? read["opt_posto_operacao"].ToString() : null);
                     entidade.OperadorTempo1 = (read["opt_operador_tempo_1"] != DBNull.Value ? read["opt_operador_tempo_1"].ToString() : null);
                     if (read["id_acs_usuario_tempo_1"] != DBNull.Value)
                     {
                        entidade.AcsUsuarioTempo1 = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_tempo_1"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuarioTempo1 = null ;
                     }
                     entidade.Tempo1 = read["opt_tempo1"] as DateTime?;
                     entidade.Tempo2 = read["opt_tempo2"] as DateTime?;
                     entidade.Tempo3 = read["opt_tempo3"] as DateTime?;
                     entidade.Tempo4 = read["opt_tempo4"] as DateTime?;
                     entidade.QuantidadeEntrada = read["opt_quantidade_entrada"] as double?;
                     entidade.QuantidadeSaida = read["opt_quantidade_saida"] as double?;
                     entidade.Sequencia = (int)read["opt_sequencia"];
                     entidade.TempoSetup = read["opt_tempo_setup"] as double?;
                     entidade.TempoProducao = read["opt_tempo_producao"] as double?;
                     entidade.OperadorTempo2 = (read["opt_operador_tempo_2"] != DBNull.Value ? read["opt_operador_tempo_2"].ToString() : null);
                     if (read["id_acs_usuario_tempo_2"] != DBNull.Value)
                     {
                        entidade.AcsUsuarioTempo2 = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_tempo_2"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuarioTempo2 = null ;
                     }
                     entidade.OperadorTempo3 = (read["opt_operador_tempo_3"] != DBNull.Value ? read["opt_operador_tempo_3"].ToString() : null);
                     if (read["id_acs_usuario_tempo_3"] != DBNull.Value)
                     {
                        entidade.AcsUsuarioTempo3 = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_tempo_3"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuarioTempo3 = null ;
                     }
                     entidade.OperadorTempo4 = (read["opt_operador_tempo_4"] != DBNull.Value ? read["opt_operador_tempo_4"].ToString() : null);
                     if (read["id_acs_usuario_tempo_4"] != DBNull.Value)
                     {
                        entidade.AcsUsuarioTempo4 = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_tempo_4"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuarioTempo4 = null ;
                     }
                     if (read["id_motivo_alteracao_qtd_op"] != DBNull.Value)
                     {
                        entidade.MotivoAlteracaoQtdOp = (BibliotecaEntidades.Entidades.MotivoAlteracaoQtdOpClass)BibliotecaEntidades.Entidades.MotivoAlteracaoQtdOpClass.GetEntidade(Convert.ToInt32(read["id_motivo_alteracao_qtd_op"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.MotivoAlteracaoQtdOp = null ;
                     }
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (OrdemProducaoPostoTrabalhoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
