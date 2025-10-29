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
     [Table("nota_fiscal_entrada_linha","nel")]
     public class NotaFiscalEntradaLinhaBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do NotaFiscalEntradaLinhaClass";
protected const string ErroDelete = "Erro ao excluir o NotaFiscalEntradaLinhaClass  ";
protected const string ErroSave = "Erro ao salvar o NotaFiscalEntradaLinhaClass.";
protected const string ErroCollectionHistoricoCompraEpiClassNotaFiscalEntradaLinha = "Erro ao carregar a coleção de HistoricoCompraEpiClass.";
protected const string ErroCollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinha = "Erro ao carregar a coleção de HistoricoCompraMaterialClass.";
protected const string ErroCollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinha = "Erro ao carregar a coleção de HistoricoCompraProdutoClass.";
protected const string ErroCollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinha = "Erro ao carregar a coleção de OrdemProducaoEnvioTerceirosRecebimentoClass.";
protected const string ErroCodigoObrigatorio = "O campo Codigo é obrigatório";
protected const string ErroCodigoComprimento = "O campo Codigo deve ter no máximo 255 caracteres";
protected const string ErroDescricaoObrigatorio = "O campo Descricao é obrigatório";
protected const string ErroDescricaoComprimento = "O campo Descricao deve ter no máximo 255 caracteres";
protected const string ErroNcmObrigatorio = "O campo Ncm é obrigatório";
protected const string ErroNcmComprimento = "O campo Ncm deve ter no máximo 255 caracteres";
protected const string ErroUnidadeObrigatorio = "O campo Unidade é obrigatório";
protected const string ErroUnidadeComprimento = "O campo Unidade deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroNotaFiscalEntradaObrigatorio = "O campo NotaFiscalEntrada é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do NotaFiscalEntradaLinhaClass.";
protected const string MensagemUtilizadoCollectionHistoricoCompraEpiClassNotaFiscalEntradaLinha =  "A entidade NotaFiscalEntradaLinhaClass está sendo utilizada nos seguintes HistoricoCompraEpiClass:";
protected const string MensagemUtilizadoCollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinha =  "A entidade NotaFiscalEntradaLinhaClass está sendo utilizada nos seguintes HistoricoCompraMaterialClass:";
protected const string MensagemUtilizadoCollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinha =  "A entidade NotaFiscalEntradaLinhaClass está sendo utilizada nos seguintes HistoricoCompraProdutoClass:";
protected const string MensagemUtilizadoCollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinha =  "A entidade NotaFiscalEntradaLinhaClass está sendo utilizada nos seguintes OrdemProducaoEnvioTerceirosRecebimentoClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade NotaFiscalEntradaLinhaClass está sendo utilizada.";
#endregion
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

       protected int _linhaOriginal{get;private set;}
       private int _linhaOriginalCommited{get; set;}
        private int _valueLinha;
         [Column("nel_linha")]
        public virtual int Linha
         { 
            get { return this._valueLinha; } 
            set 
            { 
                if (this._valueLinha == value)return;
                 this._valueLinha = value; 
            } 
        } 

       protected string _codigoOriginal{get;private set;}
       private string _codigoOriginalCommited{get; set;}
        private string _valueCodigo;
         [Column("nel_codigo")]
        public virtual string Codigo
         { 
            get { return this._valueCodigo; } 
            set 
            { 
                if (this._valueCodigo == value)return;
                 this._valueCodigo = value; 
            } 
        } 

       protected string _descricaoOriginal{get;private set;}
       private string _descricaoOriginalCommited{get; set;}
        private string _valueDescricao;
         [Column("nel_descricao")]
        public virtual string Descricao
         { 
            get { return this._valueDescricao; } 
            set 
            { 
                if (this._valueDescricao == value)return;
                 this._valueDescricao = value; 
            } 
        } 

       protected double _quantidadeOriginal{get;private set;}
       private double _quantidadeOriginalCommited{get; set;}
        private double _valueQuantidade;
         [Column("nel_quantidade")]
        public virtual double Quantidade
         { 
            get { return this._valueQuantidade; } 
            set 
            { 
                if (this._valueQuantidade == value)return;
                 this._valueQuantidade = value; 
            } 
        } 

       protected double _valorUnitarioOriginal{get;private set;}
       private double _valorUnitarioOriginalCommited{get; set;}
        private double _valueValorUnitario;
         [Column("nel_valor_unitario")]
        public virtual double ValorUnitario
         { 
            get { return this._valueValorUnitario; } 
            set 
            { 
                if (this._valueValorUnitario == value)return;
                 this._valueValorUnitario = value; 
            } 
        } 

       protected double _valorTotalOriginal{get;private set;}
       private double _valorTotalOriginalCommited{get; set;}
        private double _valueValorTotal;
         [Column("nel_valor_total")]
        public virtual double ValorTotal
         { 
            get { return this._valueValorTotal; } 
            set 
            { 
                if (this._valueValorTotal == value)return;
                 this._valueValorTotal = value; 
            } 
        } 

       protected double _imcsInclusoOriginal{get;private set;}
       private double _imcsInclusoOriginalCommited{get; set;}
        private double _valueImcsIncluso;
         [Column("nel_imcs_incluso")]
        public virtual double ImcsIncluso
         { 
            get { return this._valueImcsIncluso; } 
            set 
            { 
                if (this._valueImcsIncluso == value)return;
                 this._valueImcsIncluso = value; 
            } 
        } 

       protected double _ipiNaoInclusoOriginal{get;private set;}
       private double _ipiNaoInclusoOriginalCommited{get; set;}
        private double _valueIpiNaoIncluso;
         [Column("nel_ipi_nao_incluso")]
        public virtual double IpiNaoIncluso
         { 
            get { return this._valueIpiNaoIncluso; } 
            set 
            { 
                if (this._valueIpiNaoIncluso == value)return;
                 this._valueIpiNaoIncluso = value; 
            } 
        } 

       protected bool _vinculadaOriginal{get;private set;}
       private bool _vinculadaOriginalCommited{get; set;}
        private bool _valueVinculada;
         [Column("nel_vinculada")]
        public virtual bool Vinculada
         { 
            get { return this._valueVinculada; } 
            set 
            { 
                if (this._valueVinculada == value)return;
                 this._valueVinculada = value; 
            } 
        } 

       protected string _ncmOriginal{get;private set;}
       private string _ncmOriginalCommited{get; set;}
        private string _valueNcm;
         [Column("nel_ncm")]
        public virtual string Ncm
         { 
            get { return this._valueNcm; } 
            set 
            { 
                if (this._valueNcm == value)return;
                 this._valueNcm = value; 
            } 
        } 

       protected string _unidadeOriginal{get;private set;}
       private string _unidadeOriginalCommited{get; set;}
        private string _valueUnidade;
         [Column("nel_unidade")]
        public virtual string Unidade
         { 
            get { return this._valueUnidade; } 
            set 
            { 
                if (this._valueUnidade == value)return;
                 this._valueUnidade = value; 
            } 
        } 

       protected string _xpedOriginal{get;private set;}
       private string _xpedOriginalCommited{get; set;}
        private string _valueXped;
         [Column("nel_xped")]
        public virtual string Xped
         { 
            get { return this._valueXped; } 
            set 
            { 
                if (this._valueXped == value)return;
                 this._valueXped = value; 
            } 
        } 

       protected int? _posicaoOriginal{get;private set;}
       private int? _posicaoOriginalCommited{get; set;}
        private int? _valuePosicao;
         [Column("nel_posicao")]
        public virtual int? Posicao
         { 
            get { return this._valuePosicao; } 
            set 
            { 
                if (this._valuePosicao == value)return;
                 this._valuePosicao = value; 
            } 
        } 

       private List<long> _collectionHistoricoCompraEpiClassNotaFiscalEntradaLinhaOriginal;
       private List<Entidades.HistoricoCompraEpiClass > _collectionHistoricoCompraEpiClassNotaFiscalEntradaLinhaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraEpiClassNotaFiscalEntradaLinhaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraEpiClassNotaFiscalEntradaLinhaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraEpiClassNotaFiscalEntradaLinhaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.HistoricoCompraEpiClass> _valueCollectionHistoricoCompraEpiClassNotaFiscalEntradaLinha { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.HistoricoCompraEpiClass> CollectionHistoricoCompraEpiClassNotaFiscalEntradaLinha 
       { 
           get { if(!_valueCollectionHistoricoCompraEpiClassNotaFiscalEntradaLinhaLoaded && !this.DisableLoadCollection){this.LoadCollectionHistoricoCompraEpiClassNotaFiscalEntradaLinha();}
return this._valueCollectionHistoricoCompraEpiClassNotaFiscalEntradaLinha; } 
           set 
           { 
               this._valueCollectionHistoricoCompraEpiClassNotaFiscalEntradaLinha = value; 
               this._valueCollectionHistoricoCompraEpiClassNotaFiscalEntradaLinhaLoaded = true; 
           } 
       } 

       private List<long> _collectionHistoricoCompraMaterialClassNotaFiscalEntradaLinhaOriginal;
       private List<Entidades.HistoricoCompraMaterialClass > _collectionHistoricoCompraMaterialClassNotaFiscalEntradaLinhaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinhaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinhaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinhaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.HistoricoCompraMaterialClass> _valueCollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinha { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.HistoricoCompraMaterialClass> CollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinha 
       { 
           get { if(!_valueCollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinhaLoaded && !this.DisableLoadCollection){this.LoadCollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinha();}
return this._valueCollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinha; } 
           set 
           { 
               this._valueCollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinha = value; 
               this._valueCollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinhaLoaded = true; 
           } 
       } 

       private List<long> _collectionHistoricoCompraProdutoClassNotaFiscalEntradaLinhaOriginal;
       private List<Entidades.HistoricoCompraProdutoClass > _collectionHistoricoCompraProdutoClassNotaFiscalEntradaLinhaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinhaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinhaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinhaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.HistoricoCompraProdutoClass> _valueCollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinha { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.HistoricoCompraProdutoClass> CollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinha 
       { 
           get { if(!_valueCollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinhaLoaded && !this.DisableLoadCollection){this.LoadCollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinha();}
return this._valueCollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinha; } 
           set 
           { 
               this._valueCollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinha = value; 
               this._valueCollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinhaLoaded = true; 
           } 
       } 

       private List<long> _collectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinhaOriginal;
       private List<Entidades.OrdemProducaoEnvioTerceirosRecebimentoClass > _collectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinhaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinhaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinhaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinhaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemProducaoEnvioTerceirosRecebimentoClass> _valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinha { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemProducaoEnvioTerceirosRecebimentoClass> CollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinha 
       { 
           get { if(!_valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinhaLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinha();}
return this._valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinha; } 
           set 
           { 
               this._valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinha = value; 
               this._valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinhaLoaded = true; 
           } 
       } 

        public NotaFiscalEntradaLinhaBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Vinculada = false;
           this.Ncm = "";
           this.Unidade = "";
            base.SalvarValoresAntigosHabilitado = true;
         }

public static NotaFiscalEntradaLinhaClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (NotaFiscalEntradaLinhaClass) GetEntity(typeof(NotaFiscalEntradaLinhaClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionHistoricoCompraEpiClassNotaFiscalEntradaLinhaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionHistoricoCompraEpiClassNotaFiscalEntradaLinhaChanged = true;
                  _valueCollectionHistoricoCompraEpiClassNotaFiscalEntradaLinhaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionHistoricoCompraEpiClassNotaFiscalEntradaLinhaChanged = true; 
                  _valueCollectionHistoricoCompraEpiClassNotaFiscalEntradaLinhaCommitedChanged = true;
                 foreach (Entidades.HistoricoCompraEpiClass item in e.OldItems) 
                 { 
                     _collectionHistoricoCompraEpiClassNotaFiscalEntradaLinhaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionHistoricoCompraEpiClassNotaFiscalEntradaLinhaChanged = true; 
                  _valueCollectionHistoricoCompraEpiClassNotaFiscalEntradaLinhaCommitedChanged = true;
                 foreach (Entidades.HistoricoCompraEpiClass item in _valueCollectionHistoricoCompraEpiClassNotaFiscalEntradaLinha) 
                 { 
                     _collectionHistoricoCompraEpiClassNotaFiscalEntradaLinhaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionHistoricoCompraEpiClassNotaFiscalEntradaLinha()
         {
            try
            {
                 ObservableCollection<Entidades.HistoricoCompraEpiClass> oc;
                _valueCollectionHistoricoCompraEpiClassNotaFiscalEntradaLinhaChanged = false;
                 _valueCollectionHistoricoCompraEpiClassNotaFiscalEntradaLinhaCommitedChanged = false;
                _collectionHistoricoCompraEpiClassNotaFiscalEntradaLinhaRemovidos = new List<Entidades.HistoricoCompraEpiClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.HistoricoCompraEpiClass>();
                }
                else{ 
                   Entidades.HistoricoCompraEpiClass search = new Entidades.HistoricoCompraEpiClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.HistoricoCompraEpiClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NotaFiscalEntradaLinha", this),                     }                       ).Cast<Entidades.HistoricoCompraEpiClass>().ToList());
                 }
                 _valueCollectionHistoricoCompraEpiClassNotaFiscalEntradaLinha = new BindingList<Entidades.HistoricoCompraEpiClass>(oc); 
                 _collectionHistoricoCompraEpiClassNotaFiscalEntradaLinhaOriginal= (from a in _valueCollectionHistoricoCompraEpiClassNotaFiscalEntradaLinha select a.ID).ToList();
                 _valueCollectionHistoricoCompraEpiClassNotaFiscalEntradaLinhaLoaded = true;
                 oc.CollectionChanged += CollectionHistoricoCompraEpiClassNotaFiscalEntradaLinhaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionHistoricoCompraEpiClassNotaFiscalEntradaLinha+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinhaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinhaChanged = true;
                  _valueCollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinhaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinhaChanged = true; 
                  _valueCollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinhaCommitedChanged = true;
                 foreach (Entidades.HistoricoCompraMaterialClass item in e.OldItems) 
                 { 
                     _collectionHistoricoCompraMaterialClassNotaFiscalEntradaLinhaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinhaChanged = true; 
                  _valueCollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinhaCommitedChanged = true;
                 foreach (Entidades.HistoricoCompraMaterialClass item in _valueCollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinha) 
                 { 
                     _collectionHistoricoCompraMaterialClassNotaFiscalEntradaLinhaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinha()
         {
            try
            {
                 ObservableCollection<Entidades.HistoricoCompraMaterialClass> oc;
                _valueCollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinhaChanged = false;
                 _valueCollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinhaCommitedChanged = false;
                _collectionHistoricoCompraMaterialClassNotaFiscalEntradaLinhaRemovidos = new List<Entidades.HistoricoCompraMaterialClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.HistoricoCompraMaterialClass>();
                }
                else{ 
                   Entidades.HistoricoCompraMaterialClass search = new Entidades.HistoricoCompraMaterialClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.HistoricoCompraMaterialClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NotaFiscalEntradaLinha", this),                     }                       ).Cast<Entidades.HistoricoCompraMaterialClass>().ToList());
                 }
                 _valueCollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinha = new BindingList<Entidades.HistoricoCompraMaterialClass>(oc); 
                 _collectionHistoricoCompraMaterialClassNotaFiscalEntradaLinhaOriginal= (from a in _valueCollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinha select a.ID).ToList();
                 _valueCollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinhaLoaded = true;
                 oc.CollectionChanged += CollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinhaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinha+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinhaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinhaChanged = true;
                  _valueCollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinhaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinhaChanged = true; 
                  _valueCollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinhaCommitedChanged = true;
                 foreach (Entidades.HistoricoCompraProdutoClass item in e.OldItems) 
                 { 
                     _collectionHistoricoCompraProdutoClassNotaFiscalEntradaLinhaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinhaChanged = true; 
                  _valueCollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinhaCommitedChanged = true;
                 foreach (Entidades.HistoricoCompraProdutoClass item in _valueCollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinha) 
                 { 
                     _collectionHistoricoCompraProdutoClassNotaFiscalEntradaLinhaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinha()
         {
            try
            {
                 ObservableCollection<Entidades.HistoricoCompraProdutoClass> oc;
                _valueCollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinhaChanged = false;
                 _valueCollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinhaCommitedChanged = false;
                _collectionHistoricoCompraProdutoClassNotaFiscalEntradaLinhaRemovidos = new List<Entidades.HistoricoCompraProdutoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.HistoricoCompraProdutoClass>();
                }
                else{ 
                   Entidades.HistoricoCompraProdutoClass search = new Entidades.HistoricoCompraProdutoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.HistoricoCompraProdutoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NotaFiscalEntradaLinha", this),                     }                       ).Cast<Entidades.HistoricoCompraProdutoClass>().ToList());
                 }
                 _valueCollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinha = new BindingList<Entidades.HistoricoCompraProdutoClass>(oc); 
                 _collectionHistoricoCompraProdutoClassNotaFiscalEntradaLinhaOriginal= (from a in _valueCollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinha select a.ID).ToList();
                 _valueCollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinhaLoaded = true;
                 oc.CollectionChanged += CollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinhaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinha+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinhaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinhaChanged = true;
                  _valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinhaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinhaChanged = true; 
                  _valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinhaCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoEnvioTerceirosRecebimentoClass item in e.OldItems) 
                 { 
                     _collectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinhaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinhaChanged = true; 
                  _valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinhaCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoEnvioTerceirosRecebimentoClass item in _valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinha) 
                 { 
                     _collectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinhaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinha()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemProducaoEnvioTerceirosRecebimentoClass> oc;
                _valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinhaChanged = false;
                 _valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinhaCommitedChanged = false;
                _collectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinhaRemovidos = new List<Entidades.OrdemProducaoEnvioTerceirosRecebimentoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemProducaoEnvioTerceirosRecebimentoClass>();
                }
                else{ 
                   Entidades.OrdemProducaoEnvioTerceirosRecebimentoClass search = new Entidades.OrdemProducaoEnvioTerceirosRecebimentoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemProducaoEnvioTerceirosRecebimentoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NotaFiscalEntradaLinha", this),                     }                       ).Cast<Entidades.OrdemProducaoEnvioTerceirosRecebimentoClass>().ToList());
                 }
                 _valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinha = new BindingList<Entidades.OrdemProducaoEnvioTerceirosRecebimentoClass>(oc); 
                 _collectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinhaOriginal= (from a in _valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinha select a.ID).ToList();
                 _valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinhaLoaded = true;
                 oc.CollectionChanged += CollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinhaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinha+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Codigo))
                {
                    throw new Exception(ErroCodigoObrigatorio);
                }
                if (Codigo.Length >255)
                {
                    throw new Exception( ErroCodigoComprimento);
                }
                if (string.IsNullOrEmpty(Descricao))
                {
                    throw new Exception(ErroDescricaoObrigatorio);
                }
                if (Descricao.Length >255)
                {
                    throw new Exception( ErroDescricaoComprimento);
                }
                if (string.IsNullOrEmpty(Ncm))
                {
                    throw new Exception(ErroNcmObrigatorio);
                }
                if (Ncm.Length >255)
                {
                    throw new Exception( ErroNcmComprimento);
                }
                if (string.IsNullOrEmpty(Unidade))
                {
                    throw new Exception(ErroUnidadeObrigatorio);
                }
                if (Unidade.Length >255)
                {
                    throw new Exception( ErroUnidadeComprimento);
                }
                if ( _valueNotaFiscalEntrada == null)
                {
                    throw new Exception(ErroNotaFiscalEntradaObrigatorio);
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
                    "  public.nota_fiscal_entrada_linha  " +
                    "WHERE " +
                    "  id_nota_fiscal_entrada_linha = :id";
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
                        "  public.nota_fiscal_entrada_linha   " +
                        "SET  " + 
                        "  id_nota_fiscal_entrada = :id_nota_fiscal_entrada, " + 
                        "  nel_linha = :nel_linha, " + 
                        "  nel_codigo = :nel_codigo, " + 
                        "  nel_descricao = :nel_descricao, " + 
                        "  nel_quantidade = :nel_quantidade, " + 
                        "  nel_valor_unitario = :nel_valor_unitario, " + 
                        "  nel_valor_total = :nel_valor_total, " + 
                        "  nel_imcs_incluso = :nel_imcs_incluso, " + 
                        "  nel_ipi_nao_incluso = :nel_ipi_nao_incluso, " + 
                        "  nel_vinculada = :nel_vinculada, " + 
                        "  nel_ncm = :nel_ncm, " + 
                        "  nel_unidade = :nel_unidade, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  nel_xped = :nel_xped, " + 
                        "  nel_posicao = :nel_posicao "+
                        "WHERE  " +
                        "  id_nota_fiscal_entrada_linha = :id " +
                        "RETURNING id_nota_fiscal_entrada_linha;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.nota_fiscal_entrada_linha " +
                        "( " +
                        "  id_nota_fiscal_entrada , " + 
                        "  nel_linha , " + 
                        "  nel_codigo , " + 
                        "  nel_descricao , " + 
                        "  nel_quantidade , " + 
                        "  nel_valor_unitario , " + 
                        "  nel_valor_total , " + 
                        "  nel_imcs_incluso , " + 
                        "  nel_ipi_nao_incluso , " + 
                        "  nel_vinculada , " + 
                        "  nel_ncm , " + 
                        "  nel_unidade , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  nel_xped , " + 
                        "  nel_posicao  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_nota_fiscal_entrada , " + 
                        "  :nel_linha , " + 
                        "  :nel_codigo , " + 
                        "  :nel_descricao , " + 
                        "  :nel_quantidade , " + 
                        "  :nel_valor_unitario , " + 
                        "  :nel_valor_total , " + 
                        "  :nel_imcs_incluso , " + 
                        "  :nel_ipi_nao_incluso , " + 
                        "  :nel_vinculada , " + 
                        "  :nel_ncm , " + 
                        "  :nel_unidade , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :nel_xped , " + 
                        "  :nel_posicao  "+
                        ")RETURNING id_nota_fiscal_entrada_linha;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nota_fiscal_entrada", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.NotaFiscalEntrada==null ? (object) DBNull.Value : this.NotaFiscalEntrada.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nel_linha", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Linha ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nel_codigo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Codigo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nel_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Descricao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nel_quantidade", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Quantidade ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nel_valor_unitario", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorUnitario ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nel_valor_total", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorTotal ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nel_imcs_incluso", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ImcsIncluso ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nel_ipi_nao_incluso", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IpiNaoIncluso ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nel_vinculada", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Vinculada ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nel_ncm", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Ncm ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nel_unidade", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Unidade ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nel_xped", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Xped ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nel_posicao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Posicao ?? DBNull.Value;

 
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
 if (CollectionHistoricoCompraEpiClassNotaFiscalEntradaLinha.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionHistoricoCompraEpiClassNotaFiscalEntradaLinha+"\r\n";
                foreach (Entidades.HistoricoCompraEpiClass tmp in CollectionHistoricoCompraEpiClassNotaFiscalEntradaLinha)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinha.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinha+"\r\n";
                foreach (Entidades.HistoricoCompraMaterialClass tmp in CollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinha)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinha.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinha+"\r\n";
                foreach (Entidades.HistoricoCompraProdutoClass tmp in CollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinha)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinha.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinha+"\r\n";
                foreach (Entidades.OrdemProducaoEnvioTerceirosRecebimentoClass tmp in CollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinha)
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
        public static NotaFiscalEntradaLinhaClass CopiarEntidade(NotaFiscalEntradaLinhaClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               NotaFiscalEntradaLinhaClass toRet = new NotaFiscalEntradaLinhaClass(usuario,conn);
 toRet.NotaFiscalEntrada= entidadeCopiar.NotaFiscalEntrada;
 toRet.Linha= entidadeCopiar.Linha;
 toRet.Codigo= entidadeCopiar.Codigo;
 toRet.Descricao= entidadeCopiar.Descricao;
 toRet.Quantidade= entidadeCopiar.Quantidade;
 toRet.ValorUnitario= entidadeCopiar.ValorUnitario;
 toRet.ValorTotal= entidadeCopiar.ValorTotal;
 toRet.ImcsIncluso= entidadeCopiar.ImcsIncluso;
 toRet.IpiNaoIncluso= entidadeCopiar.IpiNaoIncluso;
 toRet.Vinculada= entidadeCopiar.Vinculada;
 toRet.Ncm= entidadeCopiar.Ncm;
 toRet.Unidade= entidadeCopiar.Unidade;
 toRet.Xped= entidadeCopiar.Xped;
 toRet.Posicao= entidadeCopiar.Posicao;

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
       _notaFiscalEntradaOriginal = NotaFiscalEntrada;
       _notaFiscalEntradaOriginalCommited = _notaFiscalEntradaOriginal;
       _linhaOriginal = Linha;
       _linhaOriginalCommited = _linhaOriginal;
       _codigoOriginal = Codigo;
       _codigoOriginalCommited = _codigoOriginal;
       _descricaoOriginal = Descricao;
       _descricaoOriginalCommited = _descricaoOriginal;
       _quantidadeOriginal = Quantidade;
       _quantidadeOriginalCommited = _quantidadeOriginal;
       _valorUnitarioOriginal = ValorUnitario;
       _valorUnitarioOriginalCommited = _valorUnitarioOriginal;
       _valorTotalOriginal = ValorTotal;
       _valorTotalOriginalCommited = _valorTotalOriginal;
       _imcsInclusoOriginal = ImcsIncluso;
       _imcsInclusoOriginalCommited = _imcsInclusoOriginal;
       _ipiNaoInclusoOriginal = IpiNaoIncluso;
       _ipiNaoInclusoOriginalCommited = _ipiNaoInclusoOriginal;
       _vinculadaOriginal = Vinculada;
       _vinculadaOriginalCommited = _vinculadaOriginal;
       _ncmOriginal = Ncm;
       _ncmOriginalCommited = _ncmOriginal;
       _unidadeOriginal = Unidade;
       _unidadeOriginalCommited = _unidadeOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _xpedOriginal = Xped;
       _xpedOriginalCommited = _xpedOriginal;
       _posicaoOriginal = Posicao;
       _posicaoOriginalCommited = _posicaoOriginal;

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
       _notaFiscalEntradaOriginalCommited = NotaFiscalEntrada;
       _linhaOriginalCommited = Linha;
       _codigoOriginalCommited = Codigo;
       _descricaoOriginalCommited = Descricao;
       _quantidadeOriginalCommited = Quantidade;
       _valorUnitarioOriginalCommited = ValorUnitario;
       _valorTotalOriginalCommited = ValorTotal;
       _imcsInclusoOriginalCommited = ImcsIncluso;
       _ipiNaoInclusoOriginalCommited = IpiNaoIncluso;
       _vinculadaOriginalCommited = Vinculada;
       _ncmOriginalCommited = Ncm;
       _unidadeOriginalCommited = Unidade;
       _versionOriginalCommited = Version;
       _xpedOriginalCommited = Xped;
       _posicaoOriginalCommited = Posicao;

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
               if (_valueCollectionHistoricoCompraEpiClassNotaFiscalEntradaLinhaLoaded) 
               {
                  if (_collectionHistoricoCompraEpiClassNotaFiscalEntradaLinhaRemovidos != null) 
                  {
                     _collectionHistoricoCompraEpiClassNotaFiscalEntradaLinhaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionHistoricoCompraEpiClassNotaFiscalEntradaLinhaRemovidos = new List<Entidades.HistoricoCompraEpiClass>();
                  }
                  _collectionHistoricoCompraEpiClassNotaFiscalEntradaLinhaOriginal= (from a in _valueCollectionHistoricoCompraEpiClassNotaFiscalEntradaLinha select a.ID).ToList();
                  _valueCollectionHistoricoCompraEpiClassNotaFiscalEntradaLinhaChanged = false;
                  _valueCollectionHistoricoCompraEpiClassNotaFiscalEntradaLinhaCommitedChanged = false;
               }
               if (_valueCollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinhaLoaded) 
               {
                  if (_collectionHistoricoCompraMaterialClassNotaFiscalEntradaLinhaRemovidos != null) 
                  {
                     _collectionHistoricoCompraMaterialClassNotaFiscalEntradaLinhaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionHistoricoCompraMaterialClassNotaFiscalEntradaLinhaRemovidos = new List<Entidades.HistoricoCompraMaterialClass>();
                  }
                  _collectionHistoricoCompraMaterialClassNotaFiscalEntradaLinhaOriginal= (from a in _valueCollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinha select a.ID).ToList();
                  _valueCollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinhaChanged = false;
                  _valueCollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinhaCommitedChanged = false;
               }
               if (_valueCollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinhaLoaded) 
               {
                  if (_collectionHistoricoCompraProdutoClassNotaFiscalEntradaLinhaRemovidos != null) 
                  {
                     _collectionHistoricoCompraProdutoClassNotaFiscalEntradaLinhaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionHistoricoCompraProdutoClassNotaFiscalEntradaLinhaRemovidos = new List<Entidades.HistoricoCompraProdutoClass>();
                  }
                  _collectionHistoricoCompraProdutoClassNotaFiscalEntradaLinhaOriginal= (from a in _valueCollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinha select a.ID).ToList();
                  _valueCollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinhaChanged = false;
                  _valueCollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinhaCommitedChanged = false;
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinhaLoaded) 
               {
                  if (_collectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinhaRemovidos != null) 
                  {
                     _collectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinhaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinhaRemovidos = new List<Entidades.OrdemProducaoEnvioTerceirosRecebimentoClass>();
                  }
                  _collectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinhaOriginal= (from a in _valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinha select a.ID).ToList();
                  _valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinhaChanged = false;
                  _valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinhaCommitedChanged = false;
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
               NotaFiscalEntrada=_notaFiscalEntradaOriginal;
               _notaFiscalEntradaOriginalCommited=_notaFiscalEntradaOriginal;
               Linha=_linhaOriginal;
               _linhaOriginalCommited=_linhaOriginal;
               Codigo=_codigoOriginal;
               _codigoOriginalCommited=_codigoOriginal;
               Descricao=_descricaoOriginal;
               _descricaoOriginalCommited=_descricaoOriginal;
               Quantidade=_quantidadeOriginal;
               _quantidadeOriginalCommited=_quantidadeOriginal;
               ValorUnitario=_valorUnitarioOriginal;
               _valorUnitarioOriginalCommited=_valorUnitarioOriginal;
               ValorTotal=_valorTotalOriginal;
               _valorTotalOriginalCommited=_valorTotalOriginal;
               ImcsIncluso=_imcsInclusoOriginal;
               _imcsInclusoOriginalCommited=_imcsInclusoOriginal;
               IpiNaoIncluso=_ipiNaoInclusoOriginal;
               _ipiNaoInclusoOriginalCommited=_ipiNaoInclusoOriginal;
               Vinculada=_vinculadaOriginal;
               _vinculadaOriginalCommited=_vinculadaOriginal;
               Ncm=_ncmOriginal;
               _ncmOriginalCommited=_ncmOriginal;
               Unidade=_unidadeOriginal;
               _unidadeOriginalCommited=_unidadeOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               Xped=_xpedOriginal;
               _xpedOriginalCommited=_xpedOriginal;
               Posicao=_posicaoOriginal;
               _posicaoOriginalCommited=_posicaoOriginal;
               if (_valueCollectionHistoricoCompraEpiClassNotaFiscalEntradaLinhaLoaded) 
               {
                  CollectionHistoricoCompraEpiClassNotaFiscalEntradaLinha.Clear();
                  foreach(int item in _collectionHistoricoCompraEpiClassNotaFiscalEntradaLinhaOriginal)
                  {
                    CollectionHistoricoCompraEpiClassNotaFiscalEntradaLinha.Add(Entidades.HistoricoCompraEpiClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionHistoricoCompraEpiClassNotaFiscalEntradaLinhaRemovidos.Clear();
               }
               if (_valueCollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinhaLoaded) 
               {
                  CollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinha.Clear();
                  foreach(int item in _collectionHistoricoCompraMaterialClassNotaFiscalEntradaLinhaOriginal)
                  {
                    CollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinha.Add(Entidades.HistoricoCompraMaterialClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionHistoricoCompraMaterialClassNotaFiscalEntradaLinhaRemovidos.Clear();
               }
               if (_valueCollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinhaLoaded) 
               {
                  CollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinha.Clear();
                  foreach(int item in _collectionHistoricoCompraProdutoClassNotaFiscalEntradaLinhaOriginal)
                  {
                    CollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinha.Add(Entidades.HistoricoCompraProdutoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionHistoricoCompraProdutoClassNotaFiscalEntradaLinhaRemovidos.Clear();
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinhaLoaded) 
               {
                  CollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinha.Clear();
                  foreach(int item in _collectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinhaOriginal)
                  {
                    CollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinha.Add(Entidades.OrdemProducaoEnvioTerceirosRecebimentoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinhaRemovidos.Clear();
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
               if (_valueCollectionHistoricoCompraEpiClassNotaFiscalEntradaLinhaLoaded) 
               {
                  if (_valueCollectionHistoricoCompraEpiClassNotaFiscalEntradaLinhaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinhaLoaded) 
               {
                  if (_valueCollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinhaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinhaLoaded) 
               {
                  if (_valueCollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinhaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinhaLoaded) 
               {
                  if (_valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinhaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionHistoricoCompraEpiClassNotaFiscalEntradaLinhaLoaded) 
               {
                   tempRet = CollectionHistoricoCompraEpiClassNotaFiscalEntradaLinha.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinhaLoaded) 
               {
                   tempRet = CollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinha.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinhaLoaded) 
               {
                   tempRet = CollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinha.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinhaLoaded) 
               {
                   tempRet = CollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinha.Any(item => item.IsDirty());
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
       if (_notaFiscalEntradaOriginal!=null)
       {
          dirty = !_notaFiscalEntradaOriginal.Equals(NotaFiscalEntrada);
       }
       else
       {
            dirty = NotaFiscalEntrada != null;
       }
      if (dirty) return true;
       dirty = _linhaOriginal != Linha;
      if (dirty) return true;
       dirty = _codigoOriginal != Codigo;
      if (dirty) return true;
       dirty = _descricaoOriginal != Descricao;
      if (dirty) return true;
       dirty = _quantidadeOriginal != Quantidade;
      if (dirty) return true;
       dirty = _valorUnitarioOriginal != ValorUnitario;
      if (dirty) return true;
       dirty = _valorTotalOriginal != ValorTotal;
      if (dirty) return true;
       dirty = _imcsInclusoOriginal != ImcsIncluso;
      if (dirty) return true;
       dirty = _ipiNaoInclusoOriginal != IpiNaoIncluso;
      if (dirty) return true;
       dirty = _vinculadaOriginal != Vinculada;
      if (dirty) return true;
       dirty = _ncmOriginal != Ncm;
      if (dirty) return true;
       dirty = _unidadeOriginal != Unidade;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _xpedOriginal != Xped;
      if (dirty) return true;
       dirty = _posicaoOriginal != Posicao;

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
               if (_valueCollectionHistoricoCompraEpiClassNotaFiscalEntradaLinhaLoaded) 
               {
                  if (_valueCollectionHistoricoCompraEpiClassNotaFiscalEntradaLinhaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinhaLoaded) 
               {
                  if (_valueCollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinhaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinhaLoaded) 
               {
                  if (_valueCollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinhaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinhaLoaded) 
               {
                  if (_valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinhaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionHistoricoCompraEpiClassNotaFiscalEntradaLinhaLoaded) 
               {
                   tempRet = CollectionHistoricoCompraEpiClassNotaFiscalEntradaLinha.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinhaLoaded) 
               {
                   tempRet = CollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinha.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinhaLoaded) 
               {
                   tempRet = CollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinha.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinhaLoaded) 
               {
                   tempRet = CollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinha.Any(item => item.IsDirtyCommited());
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
       if (_notaFiscalEntradaOriginalCommited!=null)
       {
          dirty = !_notaFiscalEntradaOriginalCommited.Equals(NotaFiscalEntrada);
       }
       else
       {
            dirty = NotaFiscalEntrada != null;
       }
      if (dirty) return true;
       dirty = _linhaOriginalCommited != Linha;
      if (dirty) return true;
       dirty = _codigoOriginalCommited != Codigo;
      if (dirty) return true;
       dirty = _descricaoOriginalCommited != Descricao;
      if (dirty) return true;
       dirty = _quantidadeOriginalCommited != Quantidade;
      if (dirty) return true;
       dirty = _valorUnitarioOriginalCommited != ValorUnitario;
      if (dirty) return true;
       dirty = _valorTotalOriginalCommited != ValorTotal;
      if (dirty) return true;
       dirty = _imcsInclusoOriginalCommited != ImcsIncluso;
      if (dirty) return true;
       dirty = _ipiNaoInclusoOriginalCommited != IpiNaoIncluso;
      if (dirty) return true;
       dirty = _vinculadaOriginalCommited != Vinculada;
      if (dirty) return true;
       dirty = _ncmOriginalCommited != Ncm;
      if (dirty) return true;
       dirty = _unidadeOriginalCommited != Unidade;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _xpedOriginalCommited != Xped;
      if (dirty) return true;
       dirty = _posicaoOriginalCommited != Posicao;

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
               if (_valueCollectionHistoricoCompraEpiClassNotaFiscalEntradaLinhaLoaded) 
               {
                  foreach(HistoricoCompraEpiClass item in CollectionHistoricoCompraEpiClassNotaFiscalEntradaLinha)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinhaLoaded) 
               {
                  foreach(HistoricoCompraMaterialClass item in CollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinha)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinhaLoaded) 
               {
                  foreach(HistoricoCompraProdutoClass item in CollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinha)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinhaLoaded) 
               {
                  foreach(OrdemProducaoEnvioTerceirosRecebimentoClass item in CollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinha)
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
             case "NotaFiscalEntrada":
                return this.NotaFiscalEntrada;
             case "Linha":
                return this.Linha;
             case "Codigo":
                return this.Codigo;
             case "Descricao":
                return this.Descricao;
             case "Quantidade":
                return this.Quantidade;
             case "ValorUnitario":
                return this.ValorUnitario;
             case "ValorTotal":
                return this.ValorTotal;
             case "ImcsIncluso":
                return this.ImcsIncluso;
             case "IpiNaoIncluso":
                return this.IpiNaoIncluso;
             case "Vinculada":
                return this.Vinculada;
             case "Ncm":
                return this.Ncm;
             case "Unidade":
                return this.Unidade;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "Xped":
                return this.Xped;
             case "Posicao":
                return this.Posicao;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (NotaFiscalEntrada!=null)
                NotaFiscalEntrada.ChangeSingleConnection(newConnection);
               if (_valueCollectionHistoricoCompraEpiClassNotaFiscalEntradaLinhaLoaded) 
               {
                  foreach(HistoricoCompraEpiClass item in CollectionHistoricoCompraEpiClassNotaFiscalEntradaLinha)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinhaLoaded) 
               {
                  foreach(HistoricoCompraMaterialClass item in CollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinha)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinhaLoaded) 
               {
                  foreach(HistoricoCompraProdutoClass item in CollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinha)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinhaLoaded) 
               {
                  foreach(OrdemProducaoEnvioTerceirosRecebimentoClass item in CollectionOrdemProducaoEnvioTerceirosRecebimentoClassNotaFiscalEntradaLinha)
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
                  command.CommandText += " COUNT(nota_fiscal_entrada_linha.id_nota_fiscal_entrada_linha) " ;
               }
               else
               {
               command.CommandText += "nota_fiscal_entrada_linha.id_nota_fiscal_entrada_linha, " ;
               command.CommandText += "nota_fiscal_entrada_linha.id_nota_fiscal_entrada, " ;
               command.CommandText += "nota_fiscal_entrada_linha.nel_linha, " ;
               command.CommandText += "nota_fiscal_entrada_linha.nel_codigo, " ;
               command.CommandText += "nota_fiscal_entrada_linha.nel_descricao, " ;
               command.CommandText += "nota_fiscal_entrada_linha.nel_quantidade, " ;
               command.CommandText += "nota_fiscal_entrada_linha.nel_valor_unitario, " ;
               command.CommandText += "nota_fiscal_entrada_linha.nel_valor_total, " ;
               command.CommandText += "nota_fiscal_entrada_linha.nel_imcs_incluso, " ;
               command.CommandText += "nota_fiscal_entrada_linha.nel_ipi_nao_incluso, " ;
               command.CommandText += "nota_fiscal_entrada_linha.nel_vinculada, " ;
               command.CommandText += "nota_fiscal_entrada_linha.nel_ncm, " ;
               command.CommandText += "nota_fiscal_entrada_linha.nel_unidade, " ;
               command.CommandText += "nota_fiscal_entrada_linha.entity_uid, " ;
               command.CommandText += "nota_fiscal_entrada_linha.version, " ;
               command.CommandText += "nota_fiscal_entrada_linha.nel_xped, " ;
               command.CommandText += "nota_fiscal_entrada_linha.nel_posicao " ;
               }
               command.CommandText += " FROM  nota_fiscal_entrada_linha ";
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
                        orderByClause += " , nel_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(nel_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = nota_fiscal_entrada_linha.id_acs_usuario_ultima_revisao ";
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
                     case "id_nota_fiscal_entrada_linha":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nota_fiscal_entrada_linha.id_nota_fiscal_entrada_linha " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nota_fiscal_entrada_linha.id_nota_fiscal_entrada_linha) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_nota_fiscal_entrada":
                     case "NotaFiscalEntrada":
                     command.CommandText += " LEFT JOIN nota_fiscal_entrada as nota_fiscal_entrada_NotaFiscalEntrada ON nota_fiscal_entrada_NotaFiscalEntrada.id_nota_fiscal_entrada = nota_fiscal_entrada_linha.id_nota_fiscal_entrada ";                     switch (parametro.TipoOrdenacao)
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
                     case "nel_linha":
                     case "Linha":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nota_fiscal_entrada_linha.nel_linha " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nota_fiscal_entrada_linha.nel_linha) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nel_codigo":
                     case "Codigo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nota_fiscal_entrada_linha.nel_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nota_fiscal_entrada_linha.nel_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nel_descricao":
                     case "Descricao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nota_fiscal_entrada_linha.nel_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nota_fiscal_entrada_linha.nel_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nel_quantidade":
                     case "Quantidade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nota_fiscal_entrada_linha.nel_quantidade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nota_fiscal_entrada_linha.nel_quantidade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nel_valor_unitario":
                     case "ValorUnitario":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nota_fiscal_entrada_linha.nel_valor_unitario " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nota_fiscal_entrada_linha.nel_valor_unitario) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nel_valor_total":
                     case "ValorTotal":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nota_fiscal_entrada_linha.nel_valor_total " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nota_fiscal_entrada_linha.nel_valor_total) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nel_imcs_incluso":
                     case "ImcsIncluso":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nota_fiscal_entrada_linha.nel_imcs_incluso " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nota_fiscal_entrada_linha.nel_imcs_incluso) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nel_ipi_nao_incluso":
                     case "IpiNaoIncluso":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nota_fiscal_entrada_linha.nel_ipi_nao_incluso " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nota_fiscal_entrada_linha.nel_ipi_nao_incluso) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nel_vinculada":
                     case "Vinculada":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nota_fiscal_entrada_linha.nel_vinculada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nota_fiscal_entrada_linha.nel_vinculada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nel_ncm":
                     case "Ncm":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nota_fiscal_entrada_linha.nel_ncm " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nota_fiscal_entrada_linha.nel_ncm) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nel_unidade":
                     case "Unidade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nota_fiscal_entrada_linha.nel_unidade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nota_fiscal_entrada_linha.nel_unidade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nota_fiscal_entrada_linha.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nota_fiscal_entrada_linha.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , nota_fiscal_entrada_linha.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nota_fiscal_entrada_linha.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nel_xped":
                     case "Xped":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nota_fiscal_entrada_linha.nel_xped " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nota_fiscal_entrada_linha.nel_xped) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nel_posicao":
                     case "Posicao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nota_fiscal_entrada_linha.nel_posicao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nota_fiscal_entrada_linha.nel_posicao) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nel_codigo")) 
                        {
                           whereClause += " OR UPPER(nota_fiscal_entrada_linha.nel_codigo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nota_fiscal_entrada_linha.nel_codigo) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nel_descricao")) 
                        {
                           whereClause += " OR UPPER(nota_fiscal_entrada_linha.nel_descricao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nota_fiscal_entrada_linha.nel_descricao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nel_ncm")) 
                        {
                           whereClause += " OR UPPER(nota_fiscal_entrada_linha.nel_ncm) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nota_fiscal_entrada_linha.nel_ncm) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nel_unidade")) 
                        {
                           whereClause += " OR UPPER(nota_fiscal_entrada_linha.nel_unidade) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nota_fiscal_entrada_linha.nel_unidade) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(nota_fiscal_entrada_linha.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nota_fiscal_entrada_linha.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nel_xped")) 
                        {
                           whereClause += " OR UPPER(nota_fiscal_entrada_linha.nel_xped) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nota_fiscal_entrada_linha.nel_xped) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_nota_fiscal_entrada_linha")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nota_fiscal_entrada_linha.id_nota_fiscal_entrada_linha IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nota_fiscal_entrada_linha.id_nota_fiscal_entrada_linha = :nota_fiscal_entrada_linha_ID_9202 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nota_fiscal_entrada_linha_ID_9202", NpgsqlDbType.Bigint, parametro.Fieldvalue));
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
                         whereClause += "  nota_fiscal_entrada_linha.id_nota_fiscal_entrada IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nota_fiscal_entrada_linha.id_nota_fiscal_entrada = :nota_fiscal_entrada_linha_NotaFiscalEntrada_2425 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nota_fiscal_entrada_linha_NotaFiscalEntrada_2425", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Linha" || parametro.FieldName == "nel_linha")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nota_fiscal_entrada_linha.nel_linha IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nota_fiscal_entrada_linha.nel_linha = :nota_fiscal_entrada_linha_Linha_9529 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nota_fiscal_entrada_linha_Linha_9529", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Codigo" || parametro.FieldName == "nel_codigo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nota_fiscal_entrada_linha.nel_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nota_fiscal_entrada_linha.nel_codigo LIKE :nota_fiscal_entrada_linha_Codigo_9477 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nota_fiscal_entrada_linha_Codigo_9477", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Descricao" || parametro.FieldName == "nel_descricao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nota_fiscal_entrada_linha.nel_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nota_fiscal_entrada_linha.nel_descricao LIKE :nota_fiscal_entrada_linha_Descricao_5843 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nota_fiscal_entrada_linha_Descricao_5843", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Quantidade" || parametro.FieldName == "nel_quantidade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nota_fiscal_entrada_linha.nel_quantidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nota_fiscal_entrada_linha.nel_quantidade = :nota_fiscal_entrada_linha_Quantidade_3605 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nota_fiscal_entrada_linha_Quantidade_3605", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorUnitario" || parametro.FieldName == "nel_valor_unitario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nota_fiscal_entrada_linha.nel_valor_unitario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nota_fiscal_entrada_linha.nel_valor_unitario = :nota_fiscal_entrada_linha_ValorUnitario_3675 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nota_fiscal_entrada_linha_ValorUnitario_3675", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorTotal" || parametro.FieldName == "nel_valor_total")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nota_fiscal_entrada_linha.nel_valor_total IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nota_fiscal_entrada_linha.nel_valor_total = :nota_fiscal_entrada_linha_ValorTotal_5238 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nota_fiscal_entrada_linha_ValorTotal_5238", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ImcsIncluso" || parametro.FieldName == "nel_imcs_incluso")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nota_fiscal_entrada_linha.nel_imcs_incluso IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nota_fiscal_entrada_linha.nel_imcs_incluso = :nota_fiscal_entrada_linha_ImcsIncluso_7095 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nota_fiscal_entrada_linha_ImcsIncluso_7095", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IpiNaoIncluso" || parametro.FieldName == "nel_ipi_nao_incluso")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nota_fiscal_entrada_linha.nel_ipi_nao_incluso IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nota_fiscal_entrada_linha.nel_ipi_nao_incluso = :nota_fiscal_entrada_linha_IpiNaoIncluso_3841 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nota_fiscal_entrada_linha_IpiNaoIncluso_3841", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Vinculada" || parametro.FieldName == "nel_vinculada")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nota_fiscal_entrada_linha.nel_vinculada IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nota_fiscal_entrada_linha.nel_vinculada = :nota_fiscal_entrada_linha_Vinculada_6544 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nota_fiscal_entrada_linha_Vinculada_6544", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Ncm" || parametro.FieldName == "nel_ncm")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nota_fiscal_entrada_linha.nel_ncm IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nota_fiscal_entrada_linha.nel_ncm LIKE :nota_fiscal_entrada_linha_Ncm_7212 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nota_fiscal_entrada_linha_Ncm_7212", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Unidade" || parametro.FieldName == "nel_unidade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nota_fiscal_entrada_linha.nel_unidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nota_fiscal_entrada_linha.nel_unidade LIKE :nota_fiscal_entrada_linha_Unidade_6706 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nota_fiscal_entrada_linha_Unidade_6706", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  nota_fiscal_entrada_linha.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nota_fiscal_entrada_linha.entity_uid LIKE :nota_fiscal_entrada_linha_EntityUid_6819 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nota_fiscal_entrada_linha_EntityUid_6819", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  nota_fiscal_entrada_linha.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nota_fiscal_entrada_linha.version = :nota_fiscal_entrada_linha_Version_4214 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nota_fiscal_entrada_linha_Version_4214", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Xped" || parametro.FieldName == "nel_xped")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nota_fiscal_entrada_linha.nel_xped IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nota_fiscal_entrada_linha.nel_xped LIKE :nota_fiscal_entrada_linha_Xped_869 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nota_fiscal_entrada_linha_Xped_869", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Posicao" || parametro.FieldName == "nel_posicao")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nota_fiscal_entrada_linha.nel_posicao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nota_fiscal_entrada_linha.nel_posicao = :nota_fiscal_entrada_linha_Posicao_2670 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nota_fiscal_entrada_linha_Posicao_2670", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoExato" || parametro.FieldName == "CodigoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nota_fiscal_entrada_linha.nel_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nota_fiscal_entrada_linha.nel_codigo LIKE :nota_fiscal_entrada_linha_Codigo_2768 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nota_fiscal_entrada_linha_Codigo_2768", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nota_fiscal_entrada_linha.nel_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nota_fiscal_entrada_linha.nel_descricao LIKE :nota_fiscal_entrada_linha_Descricao_6747 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nota_fiscal_entrada_linha_Descricao_6747", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NcmExato" || parametro.FieldName == "NcmExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nota_fiscal_entrada_linha.nel_ncm IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nota_fiscal_entrada_linha.nel_ncm LIKE :nota_fiscal_entrada_linha_Ncm_7847 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nota_fiscal_entrada_linha_Ncm_7847", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UnidadeExato" || parametro.FieldName == "UnidadeExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nota_fiscal_entrada_linha.nel_unidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nota_fiscal_entrada_linha.nel_unidade LIKE :nota_fiscal_entrada_linha_Unidade_498 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nota_fiscal_entrada_linha_Unidade_498", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nota_fiscal_entrada_linha.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nota_fiscal_entrada_linha.entity_uid LIKE :nota_fiscal_entrada_linha_EntityUid_9285 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nota_fiscal_entrada_linha_EntityUid_9285", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "XpedExato" || parametro.FieldName == "XpedExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nota_fiscal_entrada_linha.nel_xped IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nota_fiscal_entrada_linha.nel_xped LIKE :nota_fiscal_entrada_linha_Xped_6208 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nota_fiscal_entrada_linha_Xped_6208", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  NotaFiscalEntradaLinhaClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (NotaFiscalEntradaLinhaClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(NotaFiscalEntradaLinhaClass), Convert.ToInt32(read["id_nota_fiscal_entrada_linha"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new NotaFiscalEntradaLinhaClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_nota_fiscal_entrada_linha"]);
                     if (read["id_nota_fiscal_entrada"] != DBNull.Value)
                     {
                        entidade.NotaFiscalEntrada = (BibliotecaEntidades.Entidades.NotaFiscalEntradaClass)BibliotecaEntidades.Entidades.NotaFiscalEntradaClass.GetEntidade(Convert.ToInt32(read["id_nota_fiscal_entrada"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.NotaFiscalEntrada = null ;
                     }
                     entidade.Linha = (int)read["nel_linha"];
                     entidade.Codigo = (read["nel_codigo"] != DBNull.Value ? read["nel_codigo"].ToString() : null);
                     entidade.Descricao = (read["nel_descricao"] != DBNull.Value ? read["nel_descricao"].ToString() : null);
                     entidade.Quantidade = (double)read["nel_quantidade"];
                     entidade.ValorUnitario = (double)read["nel_valor_unitario"];
                     entidade.ValorTotal = (double)read["nel_valor_total"];
                     entidade.ImcsIncluso = (double)read["nel_imcs_incluso"];
                     entidade.IpiNaoIncluso = (double)read["nel_ipi_nao_incluso"];
                     entidade.Vinculada = Convert.ToBoolean(Convert.ToInt16(read["nel_vinculada"]));
                     entidade.Ncm = (read["nel_ncm"] != DBNull.Value ? read["nel_ncm"].ToString() : null);
                     entidade.Unidade = (read["nel_unidade"] != DBNull.Value ? read["nel_unidade"].ToString() : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.Xped = (read["nel_xped"] != DBNull.Value ? read["nel_xped"].ToString() : null);
                     entidade.Posicao = read["nel_posicao"] as int?;
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (NotaFiscalEntradaLinhaClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
