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
     [Table("centro_custo_lucro","ccl")]
     public class CentroCustoLucroBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do CentroCustoLucroClass";
protected const string ErroDelete = "Erro ao excluir o CentroCustoLucroClass  ";
protected const string ErroSave = "Erro ao salvar o CentroCustoLucroClass.";
protected const string ErroCollectionAgrupadorPostoTrabalhoClassCentroCustoLucro = "Erro ao carregar a coleção de AgrupadorPostoTrabalhoClass.";
protected const string ErroCollectionBudgetLinhaClassCentroCustoLucro = "Erro ao carregar a coleção de BudgetLinhaClass.";
protected const string ErroCollectionCentroCustoLucroClassCentroCustoLucroPai = "Erro ao carregar a coleção de CentroCustoLucroClass.";
protected const string ErroCollectionClienteClassCentroCustoLucro = "Erro ao carregar a coleção de ClienteClass.";
protected const string ErroCollectionContaPagarClassCentroCustoLucro = "Erro ao carregar a coleção de ContaPagarClass.";
protected const string ErroCollectionContaReceberClassCentroCustoLucro = "Erro ao carregar a coleção de ContaReceberClass.";
protected const string ErroCollectionContaRecorrenteClassCentroCustoLucro = "Erro ao carregar a coleção de ContaRecorrenteClass.";
protected const string ErroCollectionFornecedorClassCentroCustoLucro = "Erro ao carregar a coleção de FornecedorClass.";
protected const string ErroCollectionLancamentoClassCentroCustoLucro = "Erro ao carregar a coleção de LancamentoClass.";
protected const string ErroCollectionOrcamentoItemClassCentroCustoLucro = "Erro ao carregar a coleção de OrcamentoItemClass.";
protected const string ErroCollectionPedidoItemClassCentroCustoLucro = "Erro ao carregar a coleção de PedidoItemClass.";
protected const string ErroCollectionRepresentanteClassCentroCustoLucro = "Erro ao carregar a coleção de RepresentanteClass.";
protected const string ErroCollectionVendedorClassCentroCustoLucro = "Erro ao carregar a coleção de VendedorClass.";
protected const string ErroCodigoObrigatorio = "O campo Codigo é obrigatório";
protected const string ErroCodigoComprimento = "O campo Codigo deve ter no máximo 50 caracteres";
protected const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
protected const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do CentroCustoLucroClass.";
protected const string MensagemUtilizadoCollectionAgrupadorPostoTrabalhoClassCentroCustoLucro =  "A entidade CentroCustoLucroClass está sendo utilizada nos seguintes AgrupadorPostoTrabalhoClass:";
protected const string MensagemUtilizadoCollectionBudgetLinhaClassCentroCustoLucro =  "A entidade CentroCustoLucroClass está sendo utilizada nos seguintes BudgetLinhaClass:";
protected const string MensagemUtilizadoCollectionCentroCustoLucroClassCentroCustoLucroPai =  "A entidade CentroCustoLucroClass está sendo utilizada nos seguintes CentroCustoLucroClass:";
protected const string MensagemUtilizadoCollectionClienteClassCentroCustoLucro =  "A entidade CentroCustoLucroClass está sendo utilizada nos seguintes ClienteClass:";
protected const string MensagemUtilizadoCollectionContaPagarClassCentroCustoLucro =  "A entidade CentroCustoLucroClass está sendo utilizada nos seguintes ContaPagarClass:";
protected const string MensagemUtilizadoCollectionContaReceberClassCentroCustoLucro =  "A entidade CentroCustoLucroClass está sendo utilizada nos seguintes ContaReceberClass:";
protected const string MensagemUtilizadoCollectionContaRecorrenteClassCentroCustoLucro =  "A entidade CentroCustoLucroClass está sendo utilizada nos seguintes ContaRecorrenteClass:";
protected const string MensagemUtilizadoCollectionFornecedorClassCentroCustoLucro =  "A entidade CentroCustoLucroClass está sendo utilizada nos seguintes FornecedorClass:";
protected const string MensagemUtilizadoCollectionLancamentoClassCentroCustoLucro =  "A entidade CentroCustoLucroClass está sendo utilizada nos seguintes LancamentoClass:";
protected const string MensagemUtilizadoCollectionOrcamentoItemClassCentroCustoLucro =  "A entidade CentroCustoLucroClass está sendo utilizada nos seguintes OrcamentoItemClass:";
protected const string MensagemUtilizadoCollectionPedidoItemClassCentroCustoLucro =  "A entidade CentroCustoLucroClass está sendo utilizada nos seguintes PedidoItemClass:";
protected const string MensagemUtilizadoCollectionRepresentanteClassCentroCustoLucro =  "A entidade CentroCustoLucroClass está sendo utilizada nos seguintes RepresentanteClass:";
protected const string MensagemUtilizadoCollectionVendedorClassCentroCustoLucro =  "A entidade CentroCustoLucroClass está sendo utilizada nos seguintes VendedorClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade CentroCustoLucroClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.CentroCustoLucroClass _centroCustoLucroPaiOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.CentroCustoLucroClass _centroCustoLucroPaiOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.CentroCustoLucroClass _valueCentroCustoLucroPai;
        [Column("id_centro_custo_lucro_pai", "centro_custo_lucro", "id_centro_custo_lucro")]
       public virtual BibliotecaEntidades.Entidades.CentroCustoLucroClass CentroCustoLucroPai
        { 
           get {                 return this._valueCentroCustoLucroPai; } 
           set 
           { 
                if (this._valueCentroCustoLucroPai == value)return;
                 this._valueCentroCustoLucroPai = value; 
           } 
       } 

       protected string _codigoOriginal{get;private set;}
       private string _codigoOriginalCommited{get; set;}
        private string _valueCodigo;
         [Column("ccl_codigo")]
        public virtual string Codigo
         { 
            get { return this._valueCodigo; } 
            set 
            { 
                if (this._valueCodigo == value)return;
                 this._valueCodigo = value; 
            } 
        } 

       protected string _identificacaoOriginal{get;private set;}
       private string _identificacaoOriginalCommited{get; set;}
        private string _valueIdentificacao;
         [Column("ccl_identificacao")]
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
         [Column("ccl_descricao")]
        public virtual string Descricao
         { 
            get { return this._valueDescricao; } 
            set 
            { 
                if (this._valueDescricao == value)return;
                 this._valueDescricao = value; 
            } 
        } 

       protected CentroCustoLucroNatureza _naturezaOriginal{get;private set;}
       private CentroCustoLucroNatureza _naturezaOriginalCommited{get; set;}
        private CentroCustoLucroNatureza _valueNatureza;
         [Column("ccl_natureza")]
        public virtual CentroCustoLucroNatureza Natureza
         { 
            get { return this._valueNatureza; } 
            set 
            { 
                if (this._valueNatureza == value)return;
                 this._valueNatureza = value; 
            } 
        } 

        public bool Natureza_Neutro
         { 
            get { return this._valueNatureza == BibliotecaEntidades.Base.CentroCustoLucroNatureza.Neutro; } 
            set { if (value) this._valueNatureza = BibliotecaEntidades.Base.CentroCustoLucroNatureza.Neutro; }
         } 

        public bool Natureza_Custo
         { 
            get { return this._valueNatureza == BibliotecaEntidades.Base.CentroCustoLucroNatureza.Custo; } 
            set { if (value) this._valueNatureza = BibliotecaEntidades.Base.CentroCustoLucroNatureza.Custo; }
         } 

        public bool Natureza_Lucro
         { 
            get { return this._valueNatureza == BibliotecaEntidades.Base.CentroCustoLucroNatureza.Lucro; } 
            set { if (value) this._valueNatureza = BibliotecaEntidades.Base.CentroCustoLucroNatureza.Lucro; }
         } 

       protected bool _ativoAntigoOriginal{get;private set;}
       private bool _ativoAntigoOriginalCommited{get; set;}
        private bool _valueAtivoAntigo;
         [Column("ccl_ativo_antigo")]
        public virtual bool AtivoAntigo
         { 
            get { return this._valueAtivoAntigo; } 
            set 
            { 
                if (this._valueAtivoAntigo == value)return;
                 this._valueAtivoAntigo = value; 
            } 
        } 

       protected bool _ativoOriginal{get;private set;}
       private bool _ativoOriginalCommited{get; set;}
        private bool _valueAtivo;
         [Column("ccl_ativo")]
        public virtual bool Ativo
         { 
            get { return this._valueAtivo; } 
            set 
            { 
                if (this._valueAtivo == value)return;
                 this._valueAtivo = value; 
            } 
        } 

       private List<long> _collectionAgrupadorPostoTrabalhoClassCentroCustoLucroOriginal;
       private List<Entidades.AgrupadorPostoTrabalhoClass > _collectionAgrupadorPostoTrabalhoClassCentroCustoLucroRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionAgrupadorPostoTrabalhoClassCentroCustoLucroLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionAgrupadorPostoTrabalhoClassCentroCustoLucroChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionAgrupadorPostoTrabalhoClassCentroCustoLucroCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.AgrupadorPostoTrabalhoClass> _valueCollectionAgrupadorPostoTrabalhoClassCentroCustoLucro { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.AgrupadorPostoTrabalhoClass> CollectionAgrupadorPostoTrabalhoClassCentroCustoLucro 
       { 
           get { if(!_valueCollectionAgrupadorPostoTrabalhoClassCentroCustoLucroLoaded && !this.DisableLoadCollection){this.LoadCollectionAgrupadorPostoTrabalhoClassCentroCustoLucro();}
return this._valueCollectionAgrupadorPostoTrabalhoClassCentroCustoLucro; } 
           set 
           { 
               this._valueCollectionAgrupadorPostoTrabalhoClassCentroCustoLucro = value; 
               this._valueCollectionAgrupadorPostoTrabalhoClassCentroCustoLucroLoaded = true; 
           } 
       } 

       private List<long> _collectionBudgetLinhaClassCentroCustoLucroOriginal;
       private List<Entidades.BudgetLinhaClass > _collectionBudgetLinhaClassCentroCustoLucroRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionBudgetLinhaClassCentroCustoLucroLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionBudgetLinhaClassCentroCustoLucroChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionBudgetLinhaClassCentroCustoLucroCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.BudgetLinhaClass> _valueCollectionBudgetLinhaClassCentroCustoLucro { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.BudgetLinhaClass> CollectionBudgetLinhaClassCentroCustoLucro 
       { 
           get { if(!_valueCollectionBudgetLinhaClassCentroCustoLucroLoaded && !this.DisableLoadCollection){this.LoadCollectionBudgetLinhaClassCentroCustoLucro();}
return this._valueCollectionBudgetLinhaClassCentroCustoLucro; } 
           set 
           { 
               this._valueCollectionBudgetLinhaClassCentroCustoLucro = value; 
               this._valueCollectionBudgetLinhaClassCentroCustoLucroLoaded = true; 
           } 
       } 

       private List<long> _collectionCentroCustoLucroClassCentroCustoLucroPaiOriginal;
       private List<Entidades.CentroCustoLucroClass > _collectionCentroCustoLucroClassCentroCustoLucroPaiRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionCentroCustoLucroClassCentroCustoLucroPaiLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionCentroCustoLucroClassCentroCustoLucroPaiChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionCentroCustoLucroClassCentroCustoLucroPaiCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.CentroCustoLucroClass> _valueCollectionCentroCustoLucroClassCentroCustoLucroPai { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.CentroCustoLucroClass> CollectionCentroCustoLucroClassCentroCustoLucroPai 
       { 
           get { if(!_valueCollectionCentroCustoLucroClassCentroCustoLucroPaiLoaded && !this.DisableLoadCollection){this.LoadCollectionCentroCustoLucroClassCentroCustoLucroPai();}
return this._valueCollectionCentroCustoLucroClassCentroCustoLucroPai; } 
           set 
           { 
               this._valueCollectionCentroCustoLucroClassCentroCustoLucroPai = value; 
               this._valueCollectionCentroCustoLucroClassCentroCustoLucroPaiLoaded = true; 
           } 
       } 

       private List<long> _collectionClienteClassCentroCustoLucroOriginal;
       private List<Entidades.ClienteClass > _collectionClienteClassCentroCustoLucroRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionClienteClassCentroCustoLucroLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionClienteClassCentroCustoLucroChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionClienteClassCentroCustoLucroCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ClienteClass> _valueCollectionClienteClassCentroCustoLucro { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ClienteClass> CollectionClienteClassCentroCustoLucro 
       { 
           get { if(!_valueCollectionClienteClassCentroCustoLucroLoaded && !this.DisableLoadCollection){this.LoadCollectionClienteClassCentroCustoLucro();}
return this._valueCollectionClienteClassCentroCustoLucro; } 
           set 
           { 
               this._valueCollectionClienteClassCentroCustoLucro = value; 
               this._valueCollectionClienteClassCentroCustoLucroLoaded = true; 
           } 
       } 

       private List<long> _collectionContaPagarClassCentroCustoLucroOriginal;
       private List<Entidades.ContaPagarClass > _collectionContaPagarClassCentroCustoLucroRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaPagarClassCentroCustoLucroLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaPagarClassCentroCustoLucroChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaPagarClassCentroCustoLucroCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ContaPagarClass> _valueCollectionContaPagarClassCentroCustoLucro { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ContaPagarClass> CollectionContaPagarClassCentroCustoLucro 
       { 
           get { if(!_valueCollectionContaPagarClassCentroCustoLucroLoaded && !this.DisableLoadCollection){this.LoadCollectionContaPagarClassCentroCustoLucro();}
return this._valueCollectionContaPagarClassCentroCustoLucro; } 
           set 
           { 
               this._valueCollectionContaPagarClassCentroCustoLucro = value; 
               this._valueCollectionContaPagarClassCentroCustoLucroLoaded = true; 
           } 
       } 

       private List<long> _collectionContaReceberClassCentroCustoLucroOriginal;
       private List<Entidades.ContaReceberClass > _collectionContaReceberClassCentroCustoLucroRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaReceberClassCentroCustoLucroLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaReceberClassCentroCustoLucroChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaReceberClassCentroCustoLucroCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ContaReceberClass> _valueCollectionContaReceberClassCentroCustoLucro { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ContaReceberClass> CollectionContaReceberClassCentroCustoLucro 
       { 
           get { if(!_valueCollectionContaReceberClassCentroCustoLucroLoaded && !this.DisableLoadCollection){this.LoadCollectionContaReceberClassCentroCustoLucro();}
return this._valueCollectionContaReceberClassCentroCustoLucro; } 
           set 
           { 
               this._valueCollectionContaReceberClassCentroCustoLucro = value; 
               this._valueCollectionContaReceberClassCentroCustoLucroLoaded = true; 
           } 
       } 

       private List<long> _collectionContaRecorrenteClassCentroCustoLucroOriginal;
       private List<Entidades.ContaRecorrenteClass > _collectionContaRecorrenteClassCentroCustoLucroRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaRecorrenteClassCentroCustoLucroLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaRecorrenteClassCentroCustoLucroChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaRecorrenteClassCentroCustoLucroCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ContaRecorrenteClass> _valueCollectionContaRecorrenteClassCentroCustoLucro { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ContaRecorrenteClass> CollectionContaRecorrenteClassCentroCustoLucro 
       { 
           get { if(!_valueCollectionContaRecorrenteClassCentroCustoLucroLoaded && !this.DisableLoadCollection){this.LoadCollectionContaRecorrenteClassCentroCustoLucro();}
return this._valueCollectionContaRecorrenteClassCentroCustoLucro; } 
           set 
           { 
               this._valueCollectionContaRecorrenteClassCentroCustoLucro = value; 
               this._valueCollectionContaRecorrenteClassCentroCustoLucroLoaded = true; 
           } 
       } 

       private List<long> _collectionFornecedorClassCentroCustoLucroOriginal;
       private List<Entidades.FornecedorClass > _collectionFornecedorClassCentroCustoLucroRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFornecedorClassCentroCustoLucroLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFornecedorClassCentroCustoLucroChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFornecedorClassCentroCustoLucroCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.FornecedorClass> _valueCollectionFornecedorClassCentroCustoLucro { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.FornecedorClass> CollectionFornecedorClassCentroCustoLucro 
       { 
           get { if(!_valueCollectionFornecedorClassCentroCustoLucroLoaded && !this.DisableLoadCollection){this.LoadCollectionFornecedorClassCentroCustoLucro();}
return this._valueCollectionFornecedorClassCentroCustoLucro; } 
           set 
           { 
               this._valueCollectionFornecedorClassCentroCustoLucro = value; 
               this._valueCollectionFornecedorClassCentroCustoLucroLoaded = true; 
           } 
       } 

       private List<long> _collectionLancamentoClassCentroCustoLucroOriginal;
       private List<Entidades.LancamentoClass > _collectionLancamentoClassCentroCustoLucroRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionLancamentoClassCentroCustoLucroLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionLancamentoClassCentroCustoLucroChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionLancamentoClassCentroCustoLucroCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.LancamentoClass> _valueCollectionLancamentoClassCentroCustoLucro { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.LancamentoClass> CollectionLancamentoClassCentroCustoLucro 
       { 
           get { if(!_valueCollectionLancamentoClassCentroCustoLucroLoaded && !this.DisableLoadCollection){this.LoadCollectionLancamentoClassCentroCustoLucro();}
return this._valueCollectionLancamentoClassCentroCustoLucro; } 
           set 
           { 
               this._valueCollectionLancamentoClassCentroCustoLucro = value; 
               this._valueCollectionLancamentoClassCentroCustoLucroLoaded = true; 
           } 
       } 

       private List<long> _collectionOrcamentoItemClassCentroCustoLucroOriginal;
       private List<Entidades.OrcamentoItemClass > _collectionOrcamentoItemClassCentroCustoLucroRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoItemClassCentroCustoLucroLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoItemClassCentroCustoLucroChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoItemClassCentroCustoLucroCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrcamentoItemClass> _valueCollectionOrcamentoItemClassCentroCustoLucro { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrcamentoItemClass> CollectionOrcamentoItemClassCentroCustoLucro 
       { 
           get { if(!_valueCollectionOrcamentoItemClassCentroCustoLucroLoaded && !this.DisableLoadCollection){this.LoadCollectionOrcamentoItemClassCentroCustoLucro();}
return this._valueCollectionOrcamentoItemClassCentroCustoLucro; } 
           set 
           { 
               this._valueCollectionOrcamentoItemClassCentroCustoLucro = value; 
               this._valueCollectionOrcamentoItemClassCentroCustoLucroLoaded = true; 
           } 
       } 

       private List<long> _collectionPedidoItemClassCentroCustoLucroOriginal;
       private List<Entidades.PedidoItemClass > _collectionPedidoItemClassCentroCustoLucroRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassCentroCustoLucroLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassCentroCustoLucroChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassCentroCustoLucroCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PedidoItemClass> _valueCollectionPedidoItemClassCentroCustoLucro { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PedidoItemClass> CollectionPedidoItemClassCentroCustoLucro 
       { 
           get { if(!_valueCollectionPedidoItemClassCentroCustoLucroLoaded && !this.DisableLoadCollection){this.LoadCollectionPedidoItemClassCentroCustoLucro();}
return this._valueCollectionPedidoItemClassCentroCustoLucro; } 
           set 
           { 
               this._valueCollectionPedidoItemClassCentroCustoLucro = value; 
               this._valueCollectionPedidoItemClassCentroCustoLucroLoaded = true; 
           } 
       } 

       private List<long> _collectionRepresentanteClassCentroCustoLucroOriginal;
       private List<Entidades.RepresentanteClass > _collectionRepresentanteClassCentroCustoLucroRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionRepresentanteClassCentroCustoLucroLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionRepresentanteClassCentroCustoLucroChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionRepresentanteClassCentroCustoLucroCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.RepresentanteClass> _valueCollectionRepresentanteClassCentroCustoLucro { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.RepresentanteClass> CollectionRepresentanteClassCentroCustoLucro 
       { 
           get { if(!_valueCollectionRepresentanteClassCentroCustoLucroLoaded && !this.DisableLoadCollection){this.LoadCollectionRepresentanteClassCentroCustoLucro();}
return this._valueCollectionRepresentanteClassCentroCustoLucro; } 
           set 
           { 
               this._valueCollectionRepresentanteClassCentroCustoLucro = value; 
               this._valueCollectionRepresentanteClassCentroCustoLucroLoaded = true; 
           } 
       } 

       private List<long> _collectionVendedorClassCentroCustoLucroOriginal;
       private List<Entidades.VendedorClass > _collectionVendedorClassCentroCustoLucroRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionVendedorClassCentroCustoLucroLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionVendedorClassCentroCustoLucroChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionVendedorClassCentroCustoLucroCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.VendedorClass> _valueCollectionVendedorClassCentroCustoLucro { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.VendedorClass> CollectionVendedorClassCentroCustoLucro 
       { 
           get { if(!_valueCollectionVendedorClassCentroCustoLucroLoaded && !this.DisableLoadCollection){this.LoadCollectionVendedorClassCentroCustoLucro();}
return this._valueCollectionVendedorClassCentroCustoLucro; } 
           set 
           { 
               this._valueCollectionVendedorClassCentroCustoLucro = value; 
               this._valueCollectionVendedorClassCentroCustoLucroLoaded = true; 
           } 
       } 

        public CentroCustoLucroBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Natureza = (CentroCustoLucroNatureza)0;
           this.AtivoAntigo = true;
           this.Ativo = true;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static CentroCustoLucroClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (CentroCustoLucroClass) GetEntity(typeof(CentroCustoLucroClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionAgrupadorPostoTrabalhoClassCentroCustoLucroChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionAgrupadorPostoTrabalhoClassCentroCustoLucroChanged = true;
                  _valueCollectionAgrupadorPostoTrabalhoClassCentroCustoLucroCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionAgrupadorPostoTrabalhoClassCentroCustoLucroChanged = true; 
                  _valueCollectionAgrupadorPostoTrabalhoClassCentroCustoLucroCommitedChanged = true;
                 foreach (Entidades.AgrupadorPostoTrabalhoClass item in e.OldItems) 
                 { 
                     _collectionAgrupadorPostoTrabalhoClassCentroCustoLucroRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionAgrupadorPostoTrabalhoClassCentroCustoLucroChanged = true; 
                  _valueCollectionAgrupadorPostoTrabalhoClassCentroCustoLucroCommitedChanged = true;
                 foreach (Entidades.AgrupadorPostoTrabalhoClass item in _valueCollectionAgrupadorPostoTrabalhoClassCentroCustoLucro) 
                 { 
                     _collectionAgrupadorPostoTrabalhoClassCentroCustoLucroRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionAgrupadorPostoTrabalhoClassCentroCustoLucro()
         {
            try
            {
                 ObservableCollection<Entidades.AgrupadorPostoTrabalhoClass> oc;
                _valueCollectionAgrupadorPostoTrabalhoClassCentroCustoLucroChanged = false;
                 _valueCollectionAgrupadorPostoTrabalhoClassCentroCustoLucroCommitedChanged = false;
                _collectionAgrupadorPostoTrabalhoClassCentroCustoLucroRemovidos = new List<Entidades.AgrupadorPostoTrabalhoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.AgrupadorPostoTrabalhoClass>();
                }
                else{ 
                   Entidades.AgrupadorPostoTrabalhoClass search = new Entidades.AgrupadorPostoTrabalhoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.AgrupadorPostoTrabalhoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("CentroCustoLucro", this),                     }                       ).Cast<Entidades.AgrupadorPostoTrabalhoClass>().ToList());
                 }
                 _valueCollectionAgrupadorPostoTrabalhoClassCentroCustoLucro = new BindingList<Entidades.AgrupadorPostoTrabalhoClass>(oc); 
                 _collectionAgrupadorPostoTrabalhoClassCentroCustoLucroOriginal= (from a in _valueCollectionAgrupadorPostoTrabalhoClassCentroCustoLucro select a.ID).ToList();
                 _valueCollectionAgrupadorPostoTrabalhoClassCentroCustoLucroLoaded = true;
                 oc.CollectionChanged += CollectionAgrupadorPostoTrabalhoClassCentroCustoLucroChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionAgrupadorPostoTrabalhoClassCentroCustoLucro+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionBudgetLinhaClassCentroCustoLucroChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionBudgetLinhaClassCentroCustoLucroChanged = true;
                  _valueCollectionBudgetLinhaClassCentroCustoLucroCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionBudgetLinhaClassCentroCustoLucroChanged = true; 
                  _valueCollectionBudgetLinhaClassCentroCustoLucroCommitedChanged = true;
                 foreach (Entidades.BudgetLinhaClass item in e.OldItems) 
                 { 
                     _collectionBudgetLinhaClassCentroCustoLucroRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionBudgetLinhaClassCentroCustoLucroChanged = true; 
                  _valueCollectionBudgetLinhaClassCentroCustoLucroCommitedChanged = true;
                 foreach (Entidades.BudgetLinhaClass item in _valueCollectionBudgetLinhaClassCentroCustoLucro) 
                 { 
                     _collectionBudgetLinhaClassCentroCustoLucroRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionBudgetLinhaClassCentroCustoLucro()
         {
            try
            {
                 ObservableCollection<Entidades.BudgetLinhaClass> oc;
                _valueCollectionBudgetLinhaClassCentroCustoLucroChanged = false;
                 _valueCollectionBudgetLinhaClassCentroCustoLucroCommitedChanged = false;
                _collectionBudgetLinhaClassCentroCustoLucroRemovidos = new List<Entidades.BudgetLinhaClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.BudgetLinhaClass>();
                }
                else{ 
                   Entidades.BudgetLinhaClass search = new Entidades.BudgetLinhaClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.BudgetLinhaClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("CentroCustoLucro", this),                     }                       ).Cast<Entidades.BudgetLinhaClass>().ToList());
                 }
                 _valueCollectionBudgetLinhaClassCentroCustoLucro = new BindingList<Entidades.BudgetLinhaClass>(oc); 
                 _collectionBudgetLinhaClassCentroCustoLucroOriginal= (from a in _valueCollectionBudgetLinhaClassCentroCustoLucro select a.ID).ToList();
                 _valueCollectionBudgetLinhaClassCentroCustoLucroLoaded = true;
                 oc.CollectionChanged += CollectionBudgetLinhaClassCentroCustoLucroChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionBudgetLinhaClassCentroCustoLucro+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionCentroCustoLucroClassCentroCustoLucroPaiChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionCentroCustoLucroClassCentroCustoLucroPaiChanged = true;
                  _valueCollectionCentroCustoLucroClassCentroCustoLucroPaiCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionCentroCustoLucroClassCentroCustoLucroPaiChanged = true; 
                  _valueCollectionCentroCustoLucroClassCentroCustoLucroPaiCommitedChanged = true;
                 foreach (Entidades.CentroCustoLucroClass item in e.OldItems) 
                 { 
                     _collectionCentroCustoLucroClassCentroCustoLucroPaiRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionCentroCustoLucroClassCentroCustoLucroPaiChanged = true; 
                  _valueCollectionCentroCustoLucroClassCentroCustoLucroPaiCommitedChanged = true;
                 foreach (Entidades.CentroCustoLucroClass item in _valueCollectionCentroCustoLucroClassCentroCustoLucroPai) 
                 { 
                     _collectionCentroCustoLucroClassCentroCustoLucroPaiRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionCentroCustoLucroClassCentroCustoLucroPai()
         {
            try
            {
                 ObservableCollection<Entidades.CentroCustoLucroClass> oc;
                _valueCollectionCentroCustoLucroClassCentroCustoLucroPaiChanged = false;
                 _valueCollectionCentroCustoLucroClassCentroCustoLucroPaiCommitedChanged = false;
                _collectionCentroCustoLucroClassCentroCustoLucroPaiRemovidos = new List<Entidades.CentroCustoLucroClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.CentroCustoLucroClass>();
                }
                else{ 
                   Entidades.CentroCustoLucroClass search = new Entidades.CentroCustoLucroClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.CentroCustoLucroClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("CentroCustoLucroPai", this),                     }                       ).Cast<Entidades.CentroCustoLucroClass>().ToList());
                 }
                 _valueCollectionCentroCustoLucroClassCentroCustoLucroPai = new BindingList<Entidades.CentroCustoLucroClass>(oc); 
                 _collectionCentroCustoLucroClassCentroCustoLucroPaiOriginal= (from a in _valueCollectionCentroCustoLucroClassCentroCustoLucroPai select a.ID).ToList();
                 _valueCollectionCentroCustoLucroClassCentroCustoLucroPaiLoaded = true;
                 oc.CollectionChanged += CollectionCentroCustoLucroClassCentroCustoLucroPaiChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionCentroCustoLucroClassCentroCustoLucroPai+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionClienteClassCentroCustoLucroChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionClienteClassCentroCustoLucroChanged = true;
                  _valueCollectionClienteClassCentroCustoLucroCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionClienteClassCentroCustoLucroChanged = true; 
                  _valueCollectionClienteClassCentroCustoLucroCommitedChanged = true;
                 foreach (Entidades.ClienteClass item in e.OldItems) 
                 { 
                     _collectionClienteClassCentroCustoLucroRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionClienteClassCentroCustoLucroChanged = true; 
                  _valueCollectionClienteClassCentroCustoLucroCommitedChanged = true;
                 foreach (Entidades.ClienteClass item in _valueCollectionClienteClassCentroCustoLucro) 
                 { 
                     _collectionClienteClassCentroCustoLucroRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionClienteClassCentroCustoLucro()
         {
            try
            {
                 ObservableCollection<Entidades.ClienteClass> oc;
                _valueCollectionClienteClassCentroCustoLucroChanged = false;
                 _valueCollectionClienteClassCentroCustoLucroCommitedChanged = false;
                _collectionClienteClassCentroCustoLucroRemovidos = new List<Entidades.ClienteClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ClienteClass>();
                }
                else{ 
                   Entidades.ClienteClass search = new Entidades.ClienteClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ClienteClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("CentroCustoLucro", this),                     }                       ).Cast<Entidades.ClienteClass>().ToList());
                 }
                 _valueCollectionClienteClassCentroCustoLucro = new BindingList<Entidades.ClienteClass>(oc); 
                 _collectionClienteClassCentroCustoLucroOriginal= (from a in _valueCollectionClienteClassCentroCustoLucro select a.ID).ToList();
                 _valueCollectionClienteClassCentroCustoLucroLoaded = true;
                 oc.CollectionChanged += CollectionClienteClassCentroCustoLucroChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionClienteClassCentroCustoLucro+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionContaPagarClassCentroCustoLucroChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionContaPagarClassCentroCustoLucroChanged = true;
                  _valueCollectionContaPagarClassCentroCustoLucroCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionContaPagarClassCentroCustoLucroChanged = true; 
                  _valueCollectionContaPagarClassCentroCustoLucroCommitedChanged = true;
                 foreach (Entidades.ContaPagarClass item in e.OldItems) 
                 { 
                     _collectionContaPagarClassCentroCustoLucroRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionContaPagarClassCentroCustoLucroChanged = true; 
                  _valueCollectionContaPagarClassCentroCustoLucroCommitedChanged = true;
                 foreach (Entidades.ContaPagarClass item in _valueCollectionContaPagarClassCentroCustoLucro) 
                 { 
                     _collectionContaPagarClassCentroCustoLucroRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionContaPagarClassCentroCustoLucro()
         {
            try
            {
                 ObservableCollection<Entidades.ContaPagarClass> oc;
                _valueCollectionContaPagarClassCentroCustoLucroChanged = false;
                 _valueCollectionContaPagarClassCentroCustoLucroCommitedChanged = false;
                _collectionContaPagarClassCentroCustoLucroRemovidos = new List<Entidades.ContaPagarClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ContaPagarClass>();
                }
                else{ 
                   Entidades.ContaPagarClass search = new Entidades.ContaPagarClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ContaPagarClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("CentroCustoLucro", this),                     }                       ).Cast<Entidades.ContaPagarClass>().ToList());
                 }
                 _valueCollectionContaPagarClassCentroCustoLucro = new BindingList<Entidades.ContaPagarClass>(oc); 
                 _collectionContaPagarClassCentroCustoLucroOriginal= (from a in _valueCollectionContaPagarClassCentroCustoLucro select a.ID).ToList();
                 _valueCollectionContaPagarClassCentroCustoLucroLoaded = true;
                 oc.CollectionChanged += CollectionContaPagarClassCentroCustoLucroChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionContaPagarClassCentroCustoLucro+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionContaReceberClassCentroCustoLucroChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionContaReceberClassCentroCustoLucroChanged = true;
                  _valueCollectionContaReceberClassCentroCustoLucroCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionContaReceberClassCentroCustoLucroChanged = true; 
                  _valueCollectionContaReceberClassCentroCustoLucroCommitedChanged = true;
                 foreach (Entidades.ContaReceberClass item in e.OldItems) 
                 { 
                     _collectionContaReceberClassCentroCustoLucroRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionContaReceberClassCentroCustoLucroChanged = true; 
                  _valueCollectionContaReceberClassCentroCustoLucroCommitedChanged = true;
                 foreach (Entidades.ContaReceberClass item in _valueCollectionContaReceberClassCentroCustoLucro) 
                 { 
                     _collectionContaReceberClassCentroCustoLucroRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionContaReceberClassCentroCustoLucro()
         {
            try
            {
                 ObservableCollection<Entidades.ContaReceberClass> oc;
                _valueCollectionContaReceberClassCentroCustoLucroChanged = false;
                 _valueCollectionContaReceberClassCentroCustoLucroCommitedChanged = false;
                _collectionContaReceberClassCentroCustoLucroRemovidos = new List<Entidades.ContaReceberClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ContaReceberClass>();
                }
                else{ 
                   Entidades.ContaReceberClass search = new Entidades.ContaReceberClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ContaReceberClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("CentroCustoLucro", this)                    }                       ).Cast<Entidades.ContaReceberClass>().ToList());
                 }
                 _valueCollectionContaReceberClassCentroCustoLucro = new BindingList<Entidades.ContaReceberClass>(oc); 
                 _collectionContaReceberClassCentroCustoLucroOriginal= (from a in _valueCollectionContaReceberClassCentroCustoLucro select a.ID).ToList();
                 _valueCollectionContaReceberClassCentroCustoLucroLoaded = true;
                 oc.CollectionChanged += CollectionContaReceberClassCentroCustoLucroChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionContaReceberClassCentroCustoLucro+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionContaRecorrenteClassCentroCustoLucroChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionContaRecorrenteClassCentroCustoLucroChanged = true;
                  _valueCollectionContaRecorrenteClassCentroCustoLucroCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionContaRecorrenteClassCentroCustoLucroChanged = true; 
                  _valueCollectionContaRecorrenteClassCentroCustoLucroCommitedChanged = true;
                 foreach (Entidades.ContaRecorrenteClass item in e.OldItems) 
                 { 
                     _collectionContaRecorrenteClassCentroCustoLucroRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionContaRecorrenteClassCentroCustoLucroChanged = true; 
                  _valueCollectionContaRecorrenteClassCentroCustoLucroCommitedChanged = true;
                 foreach (Entidades.ContaRecorrenteClass item in _valueCollectionContaRecorrenteClassCentroCustoLucro) 
                 { 
                     _collectionContaRecorrenteClassCentroCustoLucroRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionContaRecorrenteClassCentroCustoLucro()
         {
            try
            {
                 ObservableCollection<Entidades.ContaRecorrenteClass> oc;
                _valueCollectionContaRecorrenteClassCentroCustoLucroChanged = false;
                 _valueCollectionContaRecorrenteClassCentroCustoLucroCommitedChanged = false;
                _collectionContaRecorrenteClassCentroCustoLucroRemovidos = new List<Entidades.ContaRecorrenteClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ContaRecorrenteClass>();
                }
                else{ 
                   Entidades.ContaRecorrenteClass search = new Entidades.ContaRecorrenteClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ContaRecorrenteClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("CentroCustoLucro", this),                     }                       ).Cast<Entidades.ContaRecorrenteClass>().ToList());
                 }
                 _valueCollectionContaRecorrenteClassCentroCustoLucro = new BindingList<Entidades.ContaRecorrenteClass>(oc); 
                 _collectionContaRecorrenteClassCentroCustoLucroOriginal= (from a in _valueCollectionContaRecorrenteClassCentroCustoLucro select a.ID).ToList();
                 _valueCollectionContaRecorrenteClassCentroCustoLucroLoaded = true;
                 oc.CollectionChanged += CollectionContaRecorrenteClassCentroCustoLucroChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionContaRecorrenteClassCentroCustoLucro+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionFornecedorClassCentroCustoLucroChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionFornecedorClassCentroCustoLucroChanged = true;
                  _valueCollectionFornecedorClassCentroCustoLucroCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionFornecedorClassCentroCustoLucroChanged = true; 
                  _valueCollectionFornecedorClassCentroCustoLucroCommitedChanged = true;
                 foreach (Entidades.FornecedorClass item in e.OldItems) 
                 { 
                     _collectionFornecedorClassCentroCustoLucroRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionFornecedorClassCentroCustoLucroChanged = true; 
                  _valueCollectionFornecedorClassCentroCustoLucroCommitedChanged = true;
                 foreach (Entidades.FornecedorClass item in _valueCollectionFornecedorClassCentroCustoLucro) 
                 { 
                     _collectionFornecedorClassCentroCustoLucroRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionFornecedorClassCentroCustoLucro()
         {
            try
            {
                 ObservableCollection<Entidades.FornecedorClass> oc;
                _valueCollectionFornecedorClassCentroCustoLucroChanged = false;
                 _valueCollectionFornecedorClassCentroCustoLucroCommitedChanged = false;
                _collectionFornecedorClassCentroCustoLucroRemovidos = new List<Entidades.FornecedorClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.FornecedorClass>();
                }
                else{ 
                   Entidades.FornecedorClass search = new Entidades.FornecedorClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.FornecedorClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("CentroCustoLucro", this),                     }                       ).Cast<Entidades.FornecedorClass>().ToList());
                 }
                 _valueCollectionFornecedorClassCentroCustoLucro = new BindingList<Entidades.FornecedorClass>(oc); 
                 _collectionFornecedorClassCentroCustoLucroOriginal= (from a in _valueCollectionFornecedorClassCentroCustoLucro select a.ID).ToList();
                 _valueCollectionFornecedorClassCentroCustoLucroLoaded = true;
                 oc.CollectionChanged += CollectionFornecedorClassCentroCustoLucroChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionFornecedorClassCentroCustoLucro+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionLancamentoClassCentroCustoLucroChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionLancamentoClassCentroCustoLucroChanged = true;
                  _valueCollectionLancamentoClassCentroCustoLucroCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionLancamentoClassCentroCustoLucroChanged = true; 
                  _valueCollectionLancamentoClassCentroCustoLucroCommitedChanged = true;
                 foreach (Entidades.LancamentoClass item in e.OldItems) 
                 { 
                     _collectionLancamentoClassCentroCustoLucroRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionLancamentoClassCentroCustoLucroChanged = true; 
                  _valueCollectionLancamentoClassCentroCustoLucroCommitedChanged = true;
                 foreach (Entidades.LancamentoClass item in _valueCollectionLancamentoClassCentroCustoLucro) 
                 { 
                     _collectionLancamentoClassCentroCustoLucroRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionLancamentoClassCentroCustoLucro()
         {
            try
            {
                 ObservableCollection<Entidades.LancamentoClass> oc;
                _valueCollectionLancamentoClassCentroCustoLucroChanged = false;
                 _valueCollectionLancamentoClassCentroCustoLucroCommitedChanged = false;
                _collectionLancamentoClassCentroCustoLucroRemovidos = new List<Entidades.LancamentoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.LancamentoClass>();
                }
                else{ 
                   Entidades.LancamentoClass search = new Entidades.LancamentoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.LancamentoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("CentroCustoLucro", this),                     }                       ).Cast<Entidades.LancamentoClass>().ToList());
                 }
                 _valueCollectionLancamentoClassCentroCustoLucro = new BindingList<Entidades.LancamentoClass>(oc); 
                 _collectionLancamentoClassCentroCustoLucroOriginal= (from a in _valueCollectionLancamentoClassCentroCustoLucro select a.ID).ToList();
                 _valueCollectionLancamentoClassCentroCustoLucroLoaded = true;
                 oc.CollectionChanged += CollectionLancamentoClassCentroCustoLucroChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionLancamentoClassCentroCustoLucro+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrcamentoItemClassCentroCustoLucroChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrcamentoItemClassCentroCustoLucroChanged = true;
                  _valueCollectionOrcamentoItemClassCentroCustoLucroCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrcamentoItemClassCentroCustoLucroChanged = true; 
                  _valueCollectionOrcamentoItemClassCentroCustoLucroCommitedChanged = true;
                 foreach (Entidades.OrcamentoItemClass item in e.OldItems) 
                 { 
                     _collectionOrcamentoItemClassCentroCustoLucroRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrcamentoItemClassCentroCustoLucroChanged = true; 
                  _valueCollectionOrcamentoItemClassCentroCustoLucroCommitedChanged = true;
                 foreach (Entidades.OrcamentoItemClass item in _valueCollectionOrcamentoItemClassCentroCustoLucro) 
                 { 
                     _collectionOrcamentoItemClassCentroCustoLucroRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrcamentoItemClassCentroCustoLucro()
         {
            try
            {
                 ObservableCollection<Entidades.OrcamentoItemClass> oc;
                _valueCollectionOrcamentoItemClassCentroCustoLucroChanged = false;
                 _valueCollectionOrcamentoItemClassCentroCustoLucroCommitedChanged = false;
                _collectionOrcamentoItemClassCentroCustoLucroRemovidos = new List<Entidades.OrcamentoItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrcamentoItemClass>();
                }
                else{ 
                   Entidades.OrcamentoItemClass search = new Entidades.OrcamentoItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrcamentoItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("CentroCustoLucro", this),                     }                       ).Cast<Entidades.OrcamentoItemClass>().ToList());
                 }
                 _valueCollectionOrcamentoItemClassCentroCustoLucro = new BindingList<Entidades.OrcamentoItemClass>(oc); 
                 _collectionOrcamentoItemClassCentroCustoLucroOriginal= (from a in _valueCollectionOrcamentoItemClassCentroCustoLucro select a.ID).ToList();
                 _valueCollectionOrcamentoItemClassCentroCustoLucroLoaded = true;
                 oc.CollectionChanged += CollectionOrcamentoItemClassCentroCustoLucroChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrcamentoItemClassCentroCustoLucro+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPedidoItemClassCentroCustoLucroChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPedidoItemClassCentroCustoLucroChanged = true;
                  _valueCollectionPedidoItemClassCentroCustoLucroCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPedidoItemClassCentroCustoLucroChanged = true; 
                  _valueCollectionPedidoItemClassCentroCustoLucroCommitedChanged = true;
                 foreach (Entidades.PedidoItemClass item in e.OldItems) 
                 { 
                     _collectionPedidoItemClassCentroCustoLucroRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPedidoItemClassCentroCustoLucroChanged = true; 
                  _valueCollectionPedidoItemClassCentroCustoLucroCommitedChanged = true;
                 foreach (Entidades.PedidoItemClass item in _valueCollectionPedidoItemClassCentroCustoLucro) 
                 { 
                     _collectionPedidoItemClassCentroCustoLucroRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPedidoItemClassCentroCustoLucro()
         {
            try
            {
                 ObservableCollection<Entidades.PedidoItemClass> oc;
                _valueCollectionPedidoItemClassCentroCustoLucroChanged = false;
                 _valueCollectionPedidoItemClassCentroCustoLucroCommitedChanged = false;
                _collectionPedidoItemClassCentroCustoLucroRemovidos = new List<Entidades.PedidoItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PedidoItemClass>();
                }
                else{ 
                   Entidades.PedidoItemClass search = new Entidades.PedidoItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PedidoItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("CentroCustoLucro", this),                     }                       ).Cast<Entidades.PedidoItemClass>().ToList());
                 }
                 _valueCollectionPedidoItemClassCentroCustoLucro = new BindingList<Entidades.PedidoItemClass>(oc); 
                 _collectionPedidoItemClassCentroCustoLucroOriginal= (from a in _valueCollectionPedidoItemClassCentroCustoLucro select a.ID).ToList();
                 _valueCollectionPedidoItemClassCentroCustoLucroLoaded = true;
                 oc.CollectionChanged += CollectionPedidoItemClassCentroCustoLucroChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPedidoItemClassCentroCustoLucro+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionRepresentanteClassCentroCustoLucroChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionRepresentanteClassCentroCustoLucroChanged = true;
                  _valueCollectionRepresentanteClassCentroCustoLucroCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionRepresentanteClassCentroCustoLucroChanged = true; 
                  _valueCollectionRepresentanteClassCentroCustoLucroCommitedChanged = true;
                 foreach (Entidades.RepresentanteClass item in e.OldItems) 
                 { 
                     _collectionRepresentanteClassCentroCustoLucroRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionRepresentanteClassCentroCustoLucroChanged = true; 
                  _valueCollectionRepresentanteClassCentroCustoLucroCommitedChanged = true;
                 foreach (Entidades.RepresentanteClass item in _valueCollectionRepresentanteClassCentroCustoLucro) 
                 { 
                     _collectionRepresentanteClassCentroCustoLucroRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionRepresentanteClassCentroCustoLucro()
         {
            try
            {
                 ObservableCollection<Entidades.RepresentanteClass> oc;
                _valueCollectionRepresentanteClassCentroCustoLucroChanged = false;
                 _valueCollectionRepresentanteClassCentroCustoLucroCommitedChanged = false;
                _collectionRepresentanteClassCentroCustoLucroRemovidos = new List<Entidades.RepresentanteClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.RepresentanteClass>();
                }
                else{ 
                   Entidades.RepresentanteClass search = new Entidades.RepresentanteClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.RepresentanteClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("CentroCustoLucro", this),                     }                       ).Cast<Entidades.RepresentanteClass>().ToList());
                 }
                 _valueCollectionRepresentanteClassCentroCustoLucro = new BindingList<Entidades.RepresentanteClass>(oc); 
                 _collectionRepresentanteClassCentroCustoLucroOriginal= (from a in _valueCollectionRepresentanteClassCentroCustoLucro select a.ID).ToList();
                 _valueCollectionRepresentanteClassCentroCustoLucroLoaded = true;
                 oc.CollectionChanged += CollectionRepresentanteClassCentroCustoLucroChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionRepresentanteClassCentroCustoLucro+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionVendedorClassCentroCustoLucroChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionVendedorClassCentroCustoLucroChanged = true;
                  _valueCollectionVendedorClassCentroCustoLucroCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionVendedorClassCentroCustoLucroChanged = true; 
                  _valueCollectionVendedorClassCentroCustoLucroCommitedChanged = true;
                 foreach (Entidades.VendedorClass item in e.OldItems) 
                 { 
                     _collectionVendedorClassCentroCustoLucroRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionVendedorClassCentroCustoLucroChanged = true; 
                  _valueCollectionVendedorClassCentroCustoLucroCommitedChanged = true;
                 foreach (Entidades.VendedorClass item in _valueCollectionVendedorClassCentroCustoLucro) 
                 { 
                     _collectionVendedorClassCentroCustoLucroRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionVendedorClassCentroCustoLucro()
         {
            try
            {
                 ObservableCollection<Entidades.VendedorClass> oc;
                _valueCollectionVendedorClassCentroCustoLucroChanged = false;
                 _valueCollectionVendedorClassCentroCustoLucroCommitedChanged = false;
                _collectionVendedorClassCentroCustoLucroRemovidos = new List<Entidades.VendedorClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.VendedorClass>();
                }
                else{ 
                   Entidades.VendedorClass search = new Entidades.VendedorClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.VendedorClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("CentroCustoLucro", this),                     }                       ).Cast<Entidades.VendedorClass>().ToList());
                 }
                 _valueCollectionVendedorClassCentroCustoLucro = new BindingList<Entidades.VendedorClass>(oc); 
                 _collectionVendedorClassCentroCustoLucroOriginal= (from a in _valueCollectionVendedorClassCentroCustoLucro select a.ID).ToList();
                 _valueCollectionVendedorClassCentroCustoLucroLoaded = true;
                 oc.CollectionChanged += CollectionVendedorClassCentroCustoLucroChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionVendedorClassCentroCustoLucro+"\r\n" + e.Message, e);
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
                if (Codigo.Length >50)
                {
                    throw new Exception( ErroCodigoComprimento);
                }
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
                    "  public.centro_custo_lucro  " +
                    "WHERE " +
                    "  id_centro_custo_lucro = :id";
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
                        "  public.centro_custo_lucro   " +
                        "SET  " + 
                        "  id_centro_custo_lucro_pai = :id_centro_custo_lucro_pai, " + 
                        "  ccl_codigo = :ccl_codigo, " + 
                        "  ccl_identificacao = :ccl_identificacao, " + 
                        "  ccl_descricao = :ccl_descricao, " + 
                        "  ccl_natureza = :ccl_natureza, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  ccl_ativo_antigo = :ccl_ativo_antigo, " + 
                        "  ccl_ativo = :ccl_ativo "+
                        "WHERE  " +
                        "  id_centro_custo_lucro = :id " +
                        "RETURNING id_centro_custo_lucro;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.centro_custo_lucro " +
                        "( " +
                        "  id_centro_custo_lucro_pai , " + 
                        "  ccl_codigo , " + 
                        "  ccl_identificacao , " + 
                        "  ccl_descricao , " + 
                        "  ccl_natureza , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  ccl_ativo_antigo , " + 
                        "  ccl_ativo  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_centro_custo_lucro_pai , " + 
                        "  :ccl_codigo , " + 
                        "  :ccl_identificacao , " + 
                        "  :ccl_descricao , " + 
                        "  :ccl_natureza , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :ccl_ativo_antigo , " + 
                        "  :ccl_ativo  "+
                        ")RETURNING id_centro_custo_lucro;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_centro_custo_lucro_pai", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.CentroCustoLucroPai==null ? (object) DBNull.Value : this.CentroCustoLucroPai.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ccl_codigo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Codigo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ccl_identificacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Identificacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ccl_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Descricao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ccl_natureza", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Natureza);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ccl_ativo_antigo", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.AtivoAntigo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ccl_ativo", NpgsqlDbType.Boolean));
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
 if (CollectionAgrupadorPostoTrabalhoClassCentroCustoLucro.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionAgrupadorPostoTrabalhoClassCentroCustoLucro+"\r\n";
                foreach (Entidades.AgrupadorPostoTrabalhoClass tmp in CollectionAgrupadorPostoTrabalhoClassCentroCustoLucro)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionBudgetLinhaClassCentroCustoLucro.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionBudgetLinhaClassCentroCustoLucro+"\r\n";
                foreach (Entidades.BudgetLinhaClass tmp in CollectionBudgetLinhaClassCentroCustoLucro)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionCentroCustoLucroClassCentroCustoLucroPai.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionCentroCustoLucroClassCentroCustoLucroPai+"\r\n";
                foreach (Entidades.CentroCustoLucroClass tmp in CollectionCentroCustoLucroClassCentroCustoLucroPai)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionClienteClassCentroCustoLucro.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionClienteClassCentroCustoLucro+"\r\n";
                foreach (Entidades.ClienteClass tmp in CollectionClienteClassCentroCustoLucro)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionContaPagarClassCentroCustoLucro.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionContaPagarClassCentroCustoLucro+"\r\n";
                foreach (Entidades.ContaPagarClass tmp in CollectionContaPagarClassCentroCustoLucro)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionContaReceberClassCentroCustoLucro.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionContaReceberClassCentroCustoLucro+"\r\n";
                foreach (Entidades.ContaReceberClass tmp in CollectionContaReceberClassCentroCustoLucro)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionContaRecorrenteClassCentroCustoLucro.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionContaRecorrenteClassCentroCustoLucro+"\r\n";
                foreach (Entidades.ContaRecorrenteClass tmp in CollectionContaRecorrenteClassCentroCustoLucro)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionFornecedorClassCentroCustoLucro.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionFornecedorClassCentroCustoLucro+"\r\n";
                foreach (Entidades.FornecedorClass tmp in CollectionFornecedorClassCentroCustoLucro)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionLancamentoClassCentroCustoLucro.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionLancamentoClassCentroCustoLucro+"\r\n";
                foreach (Entidades.LancamentoClass tmp in CollectionLancamentoClassCentroCustoLucro)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrcamentoItemClassCentroCustoLucro.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrcamentoItemClassCentroCustoLucro+"\r\n";
                foreach (Entidades.OrcamentoItemClass tmp in CollectionOrcamentoItemClassCentroCustoLucro)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPedidoItemClassCentroCustoLucro.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPedidoItemClassCentroCustoLucro+"\r\n";
                foreach (Entidades.PedidoItemClass tmp in CollectionPedidoItemClassCentroCustoLucro)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionRepresentanteClassCentroCustoLucro.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionRepresentanteClassCentroCustoLucro+"\r\n";
                foreach (Entidades.RepresentanteClass tmp in CollectionRepresentanteClassCentroCustoLucro)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionVendedorClassCentroCustoLucro.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionVendedorClassCentroCustoLucro+"\r\n";
                foreach (Entidades.VendedorClass tmp in CollectionVendedorClassCentroCustoLucro)
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
        public static CentroCustoLucroClass CopiarEntidade(CentroCustoLucroClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               CentroCustoLucroClass toRet = new CentroCustoLucroClass(usuario,conn);
 toRet.CentroCustoLucroPai= entidadeCopiar.CentroCustoLucroPai;
 toRet.Codigo= entidadeCopiar.Codigo;
 toRet.Identificacao= entidadeCopiar.Identificacao;
 toRet.Descricao= entidadeCopiar.Descricao;
 toRet.Natureza= entidadeCopiar.Natureza;
 toRet.AtivoAntigo= entidadeCopiar.AtivoAntigo;
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
       _centroCustoLucroPaiOriginal = CentroCustoLucroPai;
       _centroCustoLucroPaiOriginalCommited = _centroCustoLucroPaiOriginal;
       _codigoOriginal = Codigo;
       _codigoOriginalCommited = _codigoOriginal;
       _identificacaoOriginal = Identificacao;
       _identificacaoOriginalCommited = _identificacaoOriginal;
       _descricaoOriginal = Descricao;
       _descricaoOriginalCommited = _descricaoOriginal;
       _naturezaOriginal = Natureza;
       _naturezaOriginalCommited = _naturezaOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _ativoAntigoOriginal = AtivoAntigo;
       _ativoAntigoOriginalCommited = _ativoAntigoOriginal;
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
       _centroCustoLucroPaiOriginalCommited = CentroCustoLucroPai;
       _codigoOriginalCommited = Codigo;
       _identificacaoOriginalCommited = Identificacao;
       _descricaoOriginalCommited = Descricao;
       _naturezaOriginalCommited = Natureza;
       _versionOriginalCommited = Version;
       _ativoAntigoOriginalCommited = AtivoAntigo;
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
               if (_valueCollectionAgrupadorPostoTrabalhoClassCentroCustoLucroLoaded) 
               {
                  if (_collectionAgrupadorPostoTrabalhoClassCentroCustoLucroRemovidos != null) 
                  {
                     _collectionAgrupadorPostoTrabalhoClassCentroCustoLucroRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionAgrupadorPostoTrabalhoClassCentroCustoLucroRemovidos = new List<Entidades.AgrupadorPostoTrabalhoClass>();
                  }
                  _collectionAgrupadorPostoTrabalhoClassCentroCustoLucroOriginal= (from a in _valueCollectionAgrupadorPostoTrabalhoClassCentroCustoLucro select a.ID).ToList();
                  _valueCollectionAgrupadorPostoTrabalhoClassCentroCustoLucroChanged = false;
                  _valueCollectionAgrupadorPostoTrabalhoClassCentroCustoLucroCommitedChanged = false;
               }
               if (_valueCollectionBudgetLinhaClassCentroCustoLucroLoaded) 
               {
                  if (_collectionBudgetLinhaClassCentroCustoLucroRemovidos != null) 
                  {
                     _collectionBudgetLinhaClassCentroCustoLucroRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionBudgetLinhaClassCentroCustoLucroRemovidos = new List<Entidades.BudgetLinhaClass>();
                  }
                  _collectionBudgetLinhaClassCentroCustoLucroOriginal= (from a in _valueCollectionBudgetLinhaClassCentroCustoLucro select a.ID).ToList();
                  _valueCollectionBudgetLinhaClassCentroCustoLucroChanged = false;
                  _valueCollectionBudgetLinhaClassCentroCustoLucroCommitedChanged = false;
               }
               if (_valueCollectionCentroCustoLucroClassCentroCustoLucroPaiLoaded) 
               {
                  if (_collectionCentroCustoLucroClassCentroCustoLucroPaiRemovidos != null) 
                  {
                     _collectionCentroCustoLucroClassCentroCustoLucroPaiRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionCentroCustoLucroClassCentroCustoLucroPaiRemovidos = new List<Entidades.CentroCustoLucroClass>();
                  }
                  _collectionCentroCustoLucroClassCentroCustoLucroPaiOriginal= (from a in _valueCollectionCentroCustoLucroClassCentroCustoLucroPai select a.ID).ToList();
                  _valueCollectionCentroCustoLucroClassCentroCustoLucroPaiChanged = false;
                  _valueCollectionCentroCustoLucroClassCentroCustoLucroPaiCommitedChanged = false;
               }
               if (_valueCollectionClienteClassCentroCustoLucroLoaded) 
               {
                  if (_collectionClienteClassCentroCustoLucroRemovidos != null) 
                  {
                     _collectionClienteClassCentroCustoLucroRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionClienteClassCentroCustoLucroRemovidos = new List<Entidades.ClienteClass>();
                  }
                  _collectionClienteClassCentroCustoLucroOriginal= (from a in _valueCollectionClienteClassCentroCustoLucro select a.ID).ToList();
                  _valueCollectionClienteClassCentroCustoLucroChanged = false;
                  _valueCollectionClienteClassCentroCustoLucroCommitedChanged = false;
               }
               if (_valueCollectionContaPagarClassCentroCustoLucroLoaded) 
               {
                  if (_collectionContaPagarClassCentroCustoLucroRemovidos != null) 
                  {
                     _collectionContaPagarClassCentroCustoLucroRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionContaPagarClassCentroCustoLucroRemovidos = new List<Entidades.ContaPagarClass>();
                  }
                  _collectionContaPagarClassCentroCustoLucroOriginal= (from a in _valueCollectionContaPagarClassCentroCustoLucro select a.ID).ToList();
                  _valueCollectionContaPagarClassCentroCustoLucroChanged = false;
                  _valueCollectionContaPagarClassCentroCustoLucroCommitedChanged = false;
               }
               if (_valueCollectionContaReceberClassCentroCustoLucroLoaded) 
               {
                  if (_collectionContaReceberClassCentroCustoLucroRemovidos != null) 
                  {
                     _collectionContaReceberClassCentroCustoLucroRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionContaReceberClassCentroCustoLucroRemovidos = new List<Entidades.ContaReceberClass>();
                  }
                  _collectionContaReceberClassCentroCustoLucroOriginal= (from a in _valueCollectionContaReceberClassCentroCustoLucro select a.ID).ToList();
                  _valueCollectionContaReceberClassCentroCustoLucroChanged = false;
                  _valueCollectionContaReceberClassCentroCustoLucroCommitedChanged = false;
               }
               if (_valueCollectionContaRecorrenteClassCentroCustoLucroLoaded) 
               {
                  if (_collectionContaRecorrenteClassCentroCustoLucroRemovidos != null) 
                  {
                     _collectionContaRecorrenteClassCentroCustoLucroRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionContaRecorrenteClassCentroCustoLucroRemovidos = new List<Entidades.ContaRecorrenteClass>();
                  }
                  _collectionContaRecorrenteClassCentroCustoLucroOriginal= (from a in _valueCollectionContaRecorrenteClassCentroCustoLucro select a.ID).ToList();
                  _valueCollectionContaRecorrenteClassCentroCustoLucroChanged = false;
                  _valueCollectionContaRecorrenteClassCentroCustoLucroCommitedChanged = false;
               }
               if (_valueCollectionFornecedorClassCentroCustoLucroLoaded) 
               {
                  if (_collectionFornecedorClassCentroCustoLucroRemovidos != null) 
                  {
                     _collectionFornecedorClassCentroCustoLucroRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionFornecedorClassCentroCustoLucroRemovidos = new List<Entidades.FornecedorClass>();
                  }
                  _collectionFornecedorClassCentroCustoLucroOriginal= (from a in _valueCollectionFornecedorClassCentroCustoLucro select a.ID).ToList();
                  _valueCollectionFornecedorClassCentroCustoLucroChanged = false;
                  _valueCollectionFornecedorClassCentroCustoLucroCommitedChanged = false;
               }
               if (_valueCollectionLancamentoClassCentroCustoLucroLoaded) 
               {
                  if (_collectionLancamentoClassCentroCustoLucroRemovidos != null) 
                  {
                     _collectionLancamentoClassCentroCustoLucroRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionLancamentoClassCentroCustoLucroRemovidos = new List<Entidades.LancamentoClass>();
                  }
                  _collectionLancamentoClassCentroCustoLucroOriginal= (from a in _valueCollectionLancamentoClassCentroCustoLucro select a.ID).ToList();
                  _valueCollectionLancamentoClassCentroCustoLucroChanged = false;
                  _valueCollectionLancamentoClassCentroCustoLucroCommitedChanged = false;
               }
               if (_valueCollectionOrcamentoItemClassCentroCustoLucroLoaded) 
               {
                  if (_collectionOrcamentoItemClassCentroCustoLucroRemovidos != null) 
                  {
                     _collectionOrcamentoItemClassCentroCustoLucroRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrcamentoItemClassCentroCustoLucroRemovidos = new List<Entidades.OrcamentoItemClass>();
                  }
                  _collectionOrcamentoItemClassCentroCustoLucroOriginal= (from a in _valueCollectionOrcamentoItemClassCentroCustoLucro select a.ID).ToList();
                  _valueCollectionOrcamentoItemClassCentroCustoLucroChanged = false;
                  _valueCollectionOrcamentoItemClassCentroCustoLucroCommitedChanged = false;
               }
               if (_valueCollectionPedidoItemClassCentroCustoLucroLoaded) 
               {
                  if (_collectionPedidoItemClassCentroCustoLucroRemovidos != null) 
                  {
                     _collectionPedidoItemClassCentroCustoLucroRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPedidoItemClassCentroCustoLucroRemovidos = new List<Entidades.PedidoItemClass>();
                  }
                  _collectionPedidoItemClassCentroCustoLucroOriginal= (from a in _valueCollectionPedidoItemClassCentroCustoLucro select a.ID).ToList();
                  _valueCollectionPedidoItemClassCentroCustoLucroChanged = false;
                  _valueCollectionPedidoItemClassCentroCustoLucroCommitedChanged = false;
               }
               if (_valueCollectionRepresentanteClassCentroCustoLucroLoaded) 
               {
                  if (_collectionRepresentanteClassCentroCustoLucroRemovidos != null) 
                  {
                     _collectionRepresentanteClassCentroCustoLucroRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionRepresentanteClassCentroCustoLucroRemovidos = new List<Entidades.RepresentanteClass>();
                  }
                  _collectionRepresentanteClassCentroCustoLucroOriginal= (from a in _valueCollectionRepresentanteClassCentroCustoLucro select a.ID).ToList();
                  _valueCollectionRepresentanteClassCentroCustoLucroChanged = false;
                  _valueCollectionRepresentanteClassCentroCustoLucroCommitedChanged = false;
               }
               if (_valueCollectionVendedorClassCentroCustoLucroLoaded) 
               {
                  if (_collectionVendedorClassCentroCustoLucroRemovidos != null) 
                  {
                     _collectionVendedorClassCentroCustoLucroRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionVendedorClassCentroCustoLucroRemovidos = new List<Entidades.VendedorClass>();
                  }
                  _collectionVendedorClassCentroCustoLucroOriginal= (from a in _valueCollectionVendedorClassCentroCustoLucro select a.ID).ToList();
                  _valueCollectionVendedorClassCentroCustoLucroChanged = false;
                  _valueCollectionVendedorClassCentroCustoLucroCommitedChanged = false;
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
               CentroCustoLucroPai=_centroCustoLucroPaiOriginal;
               _centroCustoLucroPaiOriginalCommited=_centroCustoLucroPaiOriginal;
               Codigo=_codigoOriginal;
               _codigoOriginalCommited=_codigoOriginal;
               Identificacao=_identificacaoOriginal;
               _identificacaoOriginalCommited=_identificacaoOriginal;
               Descricao=_descricaoOriginal;
               _descricaoOriginalCommited=_descricaoOriginal;
               Natureza=_naturezaOriginal;
               _naturezaOriginalCommited=_naturezaOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               AtivoAntigo=_ativoAntigoOriginal;
               _ativoAntigoOriginalCommited=_ativoAntigoOriginal;
               Ativo=_ativoOriginal;
               _ativoOriginalCommited=_ativoOriginal;
               if (_valueCollectionAgrupadorPostoTrabalhoClassCentroCustoLucroLoaded) 
               {
                  CollectionAgrupadorPostoTrabalhoClassCentroCustoLucro.Clear();
                  foreach(int item in _collectionAgrupadorPostoTrabalhoClassCentroCustoLucroOriginal)
                  {
                    CollectionAgrupadorPostoTrabalhoClassCentroCustoLucro.Add(Entidades.AgrupadorPostoTrabalhoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionAgrupadorPostoTrabalhoClassCentroCustoLucroRemovidos.Clear();
               }
               if (_valueCollectionBudgetLinhaClassCentroCustoLucroLoaded) 
               {
                  CollectionBudgetLinhaClassCentroCustoLucro.Clear();
                  foreach(int item in _collectionBudgetLinhaClassCentroCustoLucroOriginal)
                  {
                    CollectionBudgetLinhaClassCentroCustoLucro.Add(Entidades.BudgetLinhaClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionBudgetLinhaClassCentroCustoLucroRemovidos.Clear();
               }
               if (_valueCollectionCentroCustoLucroClassCentroCustoLucroPaiLoaded) 
               {
                  CollectionCentroCustoLucroClassCentroCustoLucroPai.Clear();
                  foreach(int item in _collectionCentroCustoLucroClassCentroCustoLucroPaiOriginal)
                  {
                    CollectionCentroCustoLucroClassCentroCustoLucroPai.Add(Entidades.CentroCustoLucroClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionCentroCustoLucroClassCentroCustoLucroPaiRemovidos.Clear();
               }
               if (_valueCollectionClienteClassCentroCustoLucroLoaded) 
               {
                  CollectionClienteClassCentroCustoLucro.Clear();
                  foreach(int item in _collectionClienteClassCentroCustoLucroOriginal)
                  {
                    CollectionClienteClassCentroCustoLucro.Add(Entidades.ClienteClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionClienteClassCentroCustoLucroRemovidos.Clear();
               }
               if (_valueCollectionContaPagarClassCentroCustoLucroLoaded) 
               {
                  CollectionContaPagarClassCentroCustoLucro.Clear();
                  foreach(int item in _collectionContaPagarClassCentroCustoLucroOriginal)
                  {
                    CollectionContaPagarClassCentroCustoLucro.Add(Entidades.ContaPagarClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionContaPagarClassCentroCustoLucroRemovidos.Clear();
               }
               if (_valueCollectionContaReceberClassCentroCustoLucroLoaded) 
               {
                  CollectionContaReceberClassCentroCustoLucro.Clear();
                  foreach(int item in _collectionContaReceberClassCentroCustoLucroOriginal)
                  {
                    CollectionContaReceberClassCentroCustoLucro.Add(Entidades.ContaReceberClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionContaReceberClassCentroCustoLucroRemovidos.Clear();
               }
               if (_valueCollectionContaRecorrenteClassCentroCustoLucroLoaded) 
               {
                  CollectionContaRecorrenteClassCentroCustoLucro.Clear();
                  foreach(int item in _collectionContaRecorrenteClassCentroCustoLucroOriginal)
                  {
                    CollectionContaRecorrenteClassCentroCustoLucro.Add(Entidades.ContaRecorrenteClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionContaRecorrenteClassCentroCustoLucroRemovidos.Clear();
               }
               if (_valueCollectionFornecedorClassCentroCustoLucroLoaded) 
               {
                  CollectionFornecedorClassCentroCustoLucro.Clear();
                  foreach(int item in _collectionFornecedorClassCentroCustoLucroOriginal)
                  {
                    CollectionFornecedorClassCentroCustoLucro.Add(Entidades.FornecedorClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionFornecedorClassCentroCustoLucroRemovidos.Clear();
               }
               if (_valueCollectionLancamentoClassCentroCustoLucroLoaded) 
               {
                  CollectionLancamentoClassCentroCustoLucro.Clear();
                  foreach(int item in _collectionLancamentoClassCentroCustoLucroOriginal)
                  {
                    CollectionLancamentoClassCentroCustoLucro.Add(Entidades.LancamentoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionLancamentoClassCentroCustoLucroRemovidos.Clear();
               }
               if (_valueCollectionOrcamentoItemClassCentroCustoLucroLoaded) 
               {
                  CollectionOrcamentoItemClassCentroCustoLucro.Clear();
                  foreach(int item in _collectionOrcamentoItemClassCentroCustoLucroOriginal)
                  {
                    CollectionOrcamentoItemClassCentroCustoLucro.Add(Entidades.OrcamentoItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrcamentoItemClassCentroCustoLucroRemovidos.Clear();
               }
               if (_valueCollectionPedidoItemClassCentroCustoLucroLoaded) 
               {
                  CollectionPedidoItemClassCentroCustoLucro.Clear();
                  foreach(int item in _collectionPedidoItemClassCentroCustoLucroOriginal)
                  {
                    CollectionPedidoItemClassCentroCustoLucro.Add(Entidades.PedidoItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPedidoItemClassCentroCustoLucroRemovidos.Clear();
               }
               if (_valueCollectionRepresentanteClassCentroCustoLucroLoaded) 
               {
                  CollectionRepresentanteClassCentroCustoLucro.Clear();
                  foreach(int item in _collectionRepresentanteClassCentroCustoLucroOriginal)
                  {
                    CollectionRepresentanteClassCentroCustoLucro.Add(Entidades.RepresentanteClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionRepresentanteClassCentroCustoLucroRemovidos.Clear();
               }
               if (_valueCollectionVendedorClassCentroCustoLucroLoaded) 
               {
                  CollectionVendedorClassCentroCustoLucro.Clear();
                  foreach(int item in _collectionVendedorClassCentroCustoLucroOriginal)
                  {
                    CollectionVendedorClassCentroCustoLucro.Add(Entidades.VendedorClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionVendedorClassCentroCustoLucroRemovidos.Clear();
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
               if (_valueCollectionAgrupadorPostoTrabalhoClassCentroCustoLucroLoaded) 
               {
                  if (_valueCollectionAgrupadorPostoTrabalhoClassCentroCustoLucroChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionBudgetLinhaClassCentroCustoLucroLoaded) 
               {
                  if (_valueCollectionBudgetLinhaClassCentroCustoLucroChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionCentroCustoLucroClassCentroCustoLucroPaiLoaded) 
               {
                  if (_valueCollectionCentroCustoLucroClassCentroCustoLucroPaiChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionClienteClassCentroCustoLucroLoaded) 
               {
                  if (_valueCollectionClienteClassCentroCustoLucroChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaPagarClassCentroCustoLucroLoaded) 
               {
                  if (_valueCollectionContaPagarClassCentroCustoLucroChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaReceberClassCentroCustoLucroLoaded) 
               {
                  if (_valueCollectionContaReceberClassCentroCustoLucroChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaRecorrenteClassCentroCustoLucroLoaded) 
               {
                  if (_valueCollectionContaRecorrenteClassCentroCustoLucroChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFornecedorClassCentroCustoLucroLoaded) 
               {
                  if (_valueCollectionFornecedorClassCentroCustoLucroChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionLancamentoClassCentroCustoLucroLoaded) 
               {
                  if (_valueCollectionLancamentoClassCentroCustoLucroChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoItemClassCentroCustoLucroLoaded) 
               {
                  if (_valueCollectionOrcamentoItemClassCentroCustoLucroChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemClassCentroCustoLucroLoaded) 
               {
                  if (_valueCollectionPedidoItemClassCentroCustoLucroChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionRepresentanteClassCentroCustoLucroLoaded) 
               {
                  if (_valueCollectionRepresentanteClassCentroCustoLucroChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionVendedorClassCentroCustoLucroLoaded) 
               {
                  if (_valueCollectionVendedorClassCentroCustoLucroChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionAgrupadorPostoTrabalhoClassCentroCustoLucroLoaded) 
               {
                   tempRet = CollectionAgrupadorPostoTrabalhoClassCentroCustoLucro.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionBudgetLinhaClassCentroCustoLucroLoaded) 
               {
                   tempRet = CollectionBudgetLinhaClassCentroCustoLucro.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionCentroCustoLucroClassCentroCustoLucroPaiLoaded) 
               {
                   tempRet = CollectionCentroCustoLucroClassCentroCustoLucroPai.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionClienteClassCentroCustoLucroLoaded) 
               {
                   tempRet = CollectionClienteClassCentroCustoLucro.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionContaPagarClassCentroCustoLucroLoaded) 
               {
                   tempRet = CollectionContaPagarClassCentroCustoLucro.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionContaReceberClassCentroCustoLucroLoaded) 
               {
                   tempRet = CollectionContaReceberClassCentroCustoLucro.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionContaRecorrenteClassCentroCustoLucroLoaded) 
               {
                   tempRet = CollectionContaRecorrenteClassCentroCustoLucro.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionFornecedorClassCentroCustoLucroLoaded) 
               {
                   tempRet = CollectionFornecedorClassCentroCustoLucro.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionLancamentoClassCentroCustoLucroLoaded) 
               {
                   tempRet = CollectionLancamentoClassCentroCustoLucro.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrcamentoItemClassCentroCustoLucroLoaded) 
               {
                   tempRet = CollectionOrcamentoItemClassCentroCustoLucro.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemClassCentroCustoLucroLoaded) 
               {
                   tempRet = CollectionPedidoItemClassCentroCustoLucro.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionRepresentanteClassCentroCustoLucroLoaded) 
               {
                   tempRet = CollectionRepresentanteClassCentroCustoLucro.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionVendedorClassCentroCustoLucroLoaded) 
               {
                   tempRet = CollectionVendedorClassCentroCustoLucro.Any(item => item.IsDirty());
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
       if (_centroCustoLucroPaiOriginal!=null)
       {
          dirty = !_centroCustoLucroPaiOriginal.Equals(CentroCustoLucroPai);
       }
       else
       {
            dirty = CentroCustoLucroPai != null;
       }
      if (dirty) return true;
       dirty = _codigoOriginal != Codigo;
      if (dirty) return true;
       dirty = _identificacaoOriginal != Identificacao;
      if (dirty) return true;
       dirty = _descricaoOriginal != Descricao;
      if (dirty) return true;
       dirty = _naturezaOriginal != Natureza;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _ativoAntigoOriginal != AtivoAntigo;
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
               if (_valueCollectionAgrupadorPostoTrabalhoClassCentroCustoLucroLoaded) 
               {
                  if (_valueCollectionAgrupadorPostoTrabalhoClassCentroCustoLucroCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionBudgetLinhaClassCentroCustoLucroLoaded) 
               {
                  if (_valueCollectionBudgetLinhaClassCentroCustoLucroCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionCentroCustoLucroClassCentroCustoLucroPaiLoaded) 
               {
                  if (_valueCollectionCentroCustoLucroClassCentroCustoLucroPaiCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionClienteClassCentroCustoLucroLoaded) 
               {
                  if (_valueCollectionClienteClassCentroCustoLucroCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaPagarClassCentroCustoLucroLoaded) 
               {
                  if (_valueCollectionContaPagarClassCentroCustoLucroCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaReceberClassCentroCustoLucroLoaded) 
               {
                  if (_valueCollectionContaReceberClassCentroCustoLucroCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaRecorrenteClassCentroCustoLucroLoaded) 
               {
                  if (_valueCollectionContaRecorrenteClassCentroCustoLucroCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFornecedorClassCentroCustoLucroLoaded) 
               {
                  if (_valueCollectionFornecedorClassCentroCustoLucroCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionLancamentoClassCentroCustoLucroLoaded) 
               {
                  if (_valueCollectionLancamentoClassCentroCustoLucroCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoItemClassCentroCustoLucroLoaded) 
               {
                  if (_valueCollectionOrcamentoItemClassCentroCustoLucroCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemClassCentroCustoLucroLoaded) 
               {
                  if (_valueCollectionPedidoItemClassCentroCustoLucroCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionRepresentanteClassCentroCustoLucroLoaded) 
               {
                  if (_valueCollectionRepresentanteClassCentroCustoLucroCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionVendedorClassCentroCustoLucroLoaded) 
               {
                  if (_valueCollectionVendedorClassCentroCustoLucroCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionAgrupadorPostoTrabalhoClassCentroCustoLucroLoaded) 
               {
                   tempRet = CollectionAgrupadorPostoTrabalhoClassCentroCustoLucro.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionBudgetLinhaClassCentroCustoLucroLoaded) 
               {
                   tempRet = CollectionBudgetLinhaClassCentroCustoLucro.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionCentroCustoLucroClassCentroCustoLucroPaiLoaded) 
               {
                   tempRet = CollectionCentroCustoLucroClassCentroCustoLucroPai.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionClienteClassCentroCustoLucroLoaded) 
               {
                   tempRet = CollectionClienteClassCentroCustoLucro.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionContaPagarClassCentroCustoLucroLoaded) 
               {
                   tempRet = CollectionContaPagarClassCentroCustoLucro.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionContaReceberClassCentroCustoLucroLoaded) 
               {
                   tempRet = CollectionContaReceberClassCentroCustoLucro.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionContaRecorrenteClassCentroCustoLucroLoaded) 
               {
                   tempRet = CollectionContaRecorrenteClassCentroCustoLucro.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionFornecedorClassCentroCustoLucroLoaded) 
               {
                   tempRet = CollectionFornecedorClassCentroCustoLucro.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionLancamentoClassCentroCustoLucroLoaded) 
               {
                   tempRet = CollectionLancamentoClassCentroCustoLucro.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrcamentoItemClassCentroCustoLucroLoaded) 
               {
                   tempRet = CollectionOrcamentoItemClassCentroCustoLucro.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemClassCentroCustoLucroLoaded) 
               {
                   tempRet = CollectionPedidoItemClassCentroCustoLucro.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionRepresentanteClassCentroCustoLucroLoaded) 
               {
                   tempRet = CollectionRepresentanteClassCentroCustoLucro.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionVendedorClassCentroCustoLucroLoaded) 
               {
                   tempRet = CollectionVendedorClassCentroCustoLucro.Any(item => item.IsDirtyCommited());
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
       if (_centroCustoLucroPaiOriginalCommited!=null)
       {
          dirty = !_centroCustoLucroPaiOriginalCommited.Equals(CentroCustoLucroPai);
       }
       else
       {
            dirty = CentroCustoLucroPai != null;
       }
      if (dirty) return true;
       dirty = _codigoOriginalCommited != Codigo;
      if (dirty) return true;
       dirty = _identificacaoOriginalCommited != Identificacao;
      if (dirty) return true;
       dirty = _descricaoOriginalCommited != Descricao;
      if (dirty) return true;
       dirty = _naturezaOriginalCommited != Natureza;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _ativoAntigoOriginalCommited != AtivoAntigo;
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
               if (_valueCollectionAgrupadorPostoTrabalhoClassCentroCustoLucroLoaded) 
               {
                  foreach(AgrupadorPostoTrabalhoClass item in CollectionAgrupadorPostoTrabalhoClassCentroCustoLucro)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionBudgetLinhaClassCentroCustoLucroLoaded) 
               {
                  foreach(BudgetLinhaClass item in CollectionBudgetLinhaClassCentroCustoLucro)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionCentroCustoLucroClassCentroCustoLucroPaiLoaded) 
               {
                  foreach(CentroCustoLucroClass item in CollectionCentroCustoLucroClassCentroCustoLucroPai)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionClienteClassCentroCustoLucroLoaded) 
               {
                  foreach(ClienteClass item in CollectionClienteClassCentroCustoLucro)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionContaPagarClassCentroCustoLucroLoaded) 
               {
                  foreach(ContaPagarClass item in CollectionContaPagarClassCentroCustoLucro)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionContaReceberClassCentroCustoLucroLoaded) 
               {
                  foreach(ContaReceberClass item in CollectionContaReceberClassCentroCustoLucro)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionContaRecorrenteClassCentroCustoLucroLoaded) 
               {
                  foreach(ContaRecorrenteClass item in CollectionContaRecorrenteClassCentroCustoLucro)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionFornecedorClassCentroCustoLucroLoaded) 
               {
                  foreach(FornecedorClass item in CollectionFornecedorClassCentroCustoLucro)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionLancamentoClassCentroCustoLucroLoaded) 
               {
                  foreach(LancamentoClass item in CollectionLancamentoClassCentroCustoLucro)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrcamentoItemClassCentroCustoLucroLoaded) 
               {
                  foreach(OrcamentoItemClass item in CollectionOrcamentoItemClassCentroCustoLucro)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPedidoItemClassCentroCustoLucroLoaded) 
               {
                  foreach(PedidoItemClass item in CollectionPedidoItemClassCentroCustoLucro)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionRepresentanteClassCentroCustoLucroLoaded) 
               {
                  foreach(RepresentanteClass item in CollectionRepresentanteClassCentroCustoLucro)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionVendedorClassCentroCustoLucroLoaded) 
               {
                  foreach(VendedorClass item in CollectionVendedorClassCentroCustoLucro)
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
             case "CentroCustoLucroPai":
                return this.CentroCustoLucroPai;
             case "Codigo":
                return this.Codigo;
             case "Identificacao":
                return this.Identificacao;
             case "Descricao":
                return this.Descricao;
             case "Natureza":
                return this.Natureza;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "AtivoAntigo":
                return this.AtivoAntigo;
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
             if (CentroCustoLucroPai!=null)
                CentroCustoLucroPai.ChangeSingleConnection(newConnection);
               if (_valueCollectionAgrupadorPostoTrabalhoClassCentroCustoLucroLoaded) 
               {
                  foreach(AgrupadorPostoTrabalhoClass item in CollectionAgrupadorPostoTrabalhoClassCentroCustoLucro)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionBudgetLinhaClassCentroCustoLucroLoaded) 
               {
                  foreach(BudgetLinhaClass item in CollectionBudgetLinhaClassCentroCustoLucro)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionCentroCustoLucroClassCentroCustoLucroPaiLoaded) 
               {
                  foreach(CentroCustoLucroClass item in CollectionCentroCustoLucroClassCentroCustoLucroPai)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionClienteClassCentroCustoLucroLoaded) 
               {
                  foreach(ClienteClass item in CollectionClienteClassCentroCustoLucro)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionContaPagarClassCentroCustoLucroLoaded) 
               {
                  foreach(ContaPagarClass item in CollectionContaPagarClassCentroCustoLucro)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionContaReceberClassCentroCustoLucroLoaded) 
               {
                  foreach(ContaReceberClass item in CollectionContaReceberClassCentroCustoLucro)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionContaRecorrenteClassCentroCustoLucroLoaded) 
               {
                  foreach(ContaRecorrenteClass item in CollectionContaRecorrenteClassCentroCustoLucro)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionFornecedorClassCentroCustoLucroLoaded) 
               {
                  foreach(FornecedorClass item in CollectionFornecedorClassCentroCustoLucro)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionLancamentoClassCentroCustoLucroLoaded) 
               {
                  foreach(LancamentoClass item in CollectionLancamentoClassCentroCustoLucro)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrcamentoItemClassCentroCustoLucroLoaded) 
               {
                  foreach(OrcamentoItemClass item in CollectionOrcamentoItemClassCentroCustoLucro)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPedidoItemClassCentroCustoLucroLoaded) 
               {
                  foreach(PedidoItemClass item in CollectionPedidoItemClassCentroCustoLucro)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionRepresentanteClassCentroCustoLucroLoaded) 
               {
                  foreach(RepresentanteClass item in CollectionRepresentanteClassCentroCustoLucro)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionVendedorClassCentroCustoLucroLoaded) 
               {
                  foreach(VendedorClass item in CollectionVendedorClassCentroCustoLucro)
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
                  command.CommandText += " COUNT(centro_custo_lucro.id_centro_custo_lucro) " ;
               }
               else
               {
               command.CommandText += "centro_custo_lucro.id_centro_custo_lucro, " ;
               command.CommandText += "centro_custo_lucro.id_centro_custo_lucro_pai, " ;
               command.CommandText += "centro_custo_lucro.ccl_codigo, " ;
               command.CommandText += "centro_custo_lucro.ccl_identificacao, " ;
               command.CommandText += "centro_custo_lucro.ccl_descricao, " ;
               command.CommandText += "centro_custo_lucro.ccl_natureza, " ;
               command.CommandText += "centro_custo_lucro.entity_uid, " ;
               command.CommandText += "centro_custo_lucro.version, " ;
               command.CommandText += "centro_custo_lucro.ccl_ativo_antigo, " ;
               command.CommandText += "centro_custo_lucro.ccl_ativo " ;
               }
               command.CommandText += " FROM  centro_custo_lucro ";
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
                        orderByClause += " , ccl_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(ccl_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = centro_custo_lucro.id_acs_usuario_ultima_revisao ";
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
                     case "id_centro_custo_lucro":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , centro_custo_lucro.id_centro_custo_lucro " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(centro_custo_lucro.id_centro_custo_lucro) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_centro_custo_lucro_pai":
                     case "CentroCustoLucroPai":
                     command.CommandText += " LEFT JOIN centro_custo_lucro as centro_custo_lucro_CentroCustoLucroPai ON centro_custo_lucro_CentroCustoLucroPai.id_centro_custo_lucro = centro_custo_lucro.id_centro_custo_lucro_pai ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , centro_custo_lucro_CentroCustoLucroPai.ccl_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(centro_custo_lucro_CentroCustoLucroPai.ccl_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , centro_custo_lucro_CentroCustoLucroPai.ccl_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(centro_custo_lucro_CentroCustoLucroPai.ccl_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ccl_codigo":
                     case "Codigo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , centro_custo_lucro.ccl_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(centro_custo_lucro.ccl_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ccl_identificacao":
                     case "Identificacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , centro_custo_lucro.ccl_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(centro_custo_lucro.ccl_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ccl_descricao":
                     case "Descricao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , centro_custo_lucro.ccl_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(centro_custo_lucro.ccl_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ccl_natureza":
                     case "Natureza":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , centro_custo_lucro.ccl_natureza " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(centro_custo_lucro.ccl_natureza) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , centro_custo_lucro.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(centro_custo_lucro.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , centro_custo_lucro.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(centro_custo_lucro.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ccl_ativo_antigo":
                     case "AtivoAntigo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , centro_custo_lucro.ccl_ativo_antigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(centro_custo_lucro.ccl_ativo_antigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ccl_ativo":
                     case "Ativo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , centro_custo_lucro.ccl_ativo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(centro_custo_lucro.ccl_ativo) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ccl_codigo")) 
                        {
                           whereClause += " OR UPPER(centro_custo_lucro.ccl_codigo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(centro_custo_lucro.ccl_codigo) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ccl_identificacao")) 
                        {
                           whereClause += " OR UPPER(centro_custo_lucro.ccl_identificacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(centro_custo_lucro.ccl_identificacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ccl_descricao")) 
                        {
                           whereClause += " OR UPPER(centro_custo_lucro.ccl_descricao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(centro_custo_lucro.ccl_descricao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(centro_custo_lucro.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(centro_custo_lucro.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_centro_custo_lucro")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  centro_custo_lucro.id_centro_custo_lucro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  centro_custo_lucro.id_centro_custo_lucro = :centro_custo_lucro_ID_730 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("centro_custo_lucro_ID_730", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CentroCustoLucroPai" || parametro.FieldName == "id_centro_custo_lucro_pai")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.CentroCustoLucroClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.CentroCustoLucroClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  centro_custo_lucro.id_centro_custo_lucro_pai IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  centro_custo_lucro.id_centro_custo_lucro_pai = :centro_custo_lucro_CentroCustoLucroPai_5826 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("centro_custo_lucro_CentroCustoLucroPai_5826", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Codigo" || parametro.FieldName == "ccl_codigo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  centro_custo_lucro.ccl_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  centro_custo_lucro.ccl_codigo LIKE :centro_custo_lucro_Codigo_3112 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("centro_custo_lucro_Codigo_3112", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Identificacao" || parametro.FieldName == "ccl_identificacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  centro_custo_lucro.ccl_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  centro_custo_lucro.ccl_identificacao LIKE :centro_custo_lucro_Identificacao_4824 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("centro_custo_lucro_Identificacao_4824", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Descricao" || parametro.FieldName == "ccl_descricao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  centro_custo_lucro.ccl_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  centro_custo_lucro.ccl_descricao LIKE :centro_custo_lucro_Descricao_1606 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("centro_custo_lucro_Descricao_1606", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Natureza" || parametro.FieldName == "ccl_natureza")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is CentroCustoLucroNatureza)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo CentroCustoLucroNatureza");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  centro_custo_lucro.ccl_natureza IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  centro_custo_lucro.ccl_natureza = :centro_custo_lucro_Natureza_7357 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("centro_custo_lucro_Natureza_7357", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  centro_custo_lucro.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  centro_custo_lucro.entity_uid LIKE :centro_custo_lucro_EntityUid_2 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("centro_custo_lucro_EntityUid_2", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  centro_custo_lucro.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  centro_custo_lucro.version = :centro_custo_lucro_Version_6014 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("centro_custo_lucro_Version_6014", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AtivoAntigo" || parametro.FieldName == "ccl_ativo_antigo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  centro_custo_lucro.ccl_ativo_antigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  centro_custo_lucro.ccl_ativo_antigo = :centro_custo_lucro_AtivoAntigo_7216 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("centro_custo_lucro_AtivoAntigo_7216", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Ativo" || parametro.FieldName == "ccl_ativo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  centro_custo_lucro.ccl_ativo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  centro_custo_lucro.ccl_ativo = :centro_custo_lucro_Ativo_8551 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("centro_custo_lucro_Ativo_8551", NpgsqlDbType.Boolean, parametro.Fieldvalue));
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
                         whereClause += "  centro_custo_lucro.ccl_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  centro_custo_lucro.ccl_codigo LIKE :centro_custo_lucro_Codigo_3100 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("centro_custo_lucro_Codigo_3100", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  centro_custo_lucro.ccl_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  centro_custo_lucro.ccl_identificacao LIKE :centro_custo_lucro_Identificacao_7292 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("centro_custo_lucro_Identificacao_7292", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  centro_custo_lucro.ccl_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  centro_custo_lucro.ccl_descricao LIKE :centro_custo_lucro_Descricao_5927 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("centro_custo_lucro_Descricao_5927", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  centro_custo_lucro.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  centro_custo_lucro.entity_uid LIKE :centro_custo_lucro_EntityUid_4645 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("centro_custo_lucro_EntityUid_4645", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  CentroCustoLucroClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (CentroCustoLucroClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(CentroCustoLucroClass), Convert.ToInt32(read["id_centro_custo_lucro"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new CentroCustoLucroClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_centro_custo_lucro"]);
                     if (read["id_centro_custo_lucro_pai"] != DBNull.Value)
                     {
                        entidade.CentroCustoLucroPai = (BibliotecaEntidades.Entidades.CentroCustoLucroClass)BibliotecaEntidades.Entidades.CentroCustoLucroClass.GetEntidade(Convert.ToInt32(read["id_centro_custo_lucro_pai"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.CentroCustoLucroPai = null ;
                     }
                     entidade.Codigo = (read["ccl_codigo"] != DBNull.Value ? read["ccl_codigo"].ToString() : null);
                     entidade.Identificacao = (read["ccl_identificacao"] != DBNull.Value ? read["ccl_identificacao"].ToString() : null);
                     entidade.Descricao = (read["ccl_descricao"] != DBNull.Value ? read["ccl_descricao"].ToString() : null);
                     entidade.Natureza = (CentroCustoLucroNatureza) (read["ccl_natureza"] != DBNull.Value ? Enum.ToObject(typeof(CentroCustoLucroNatureza), read["ccl_natureza"]) : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.AtivoAntigo = Convert.ToBoolean(Convert.ToInt16(read["ccl_ativo_antigo"]));
                     entidade.Ativo = Convert.ToBoolean(read["ccl_ativo"]);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (CentroCustoLucroClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
