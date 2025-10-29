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
     [Table("estado","est")]
     public class EstadoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do EstadoClass";
protected const string ErroDelete = "Erro ao excluir o EstadoClass  ";
protected const string ErroSave = "Erro ao salvar o EstadoClass.";
protected const string ErroCollectionAliquotaFundoCombatePobrezaClassEstado = "Erro ao carregar a coleção de AliquotaFundoCombatePobrezaClass.";
protected const string ErroCollectionCidadeClassEstado = "Erro ao carregar a coleção de CidadeClass.";
protected const string ErroCollectionClienteClassEstadoCob = "Erro ao carregar a coleção de ClienteClass.";
protected const string ErroCollectionClienteClassEstado = "Erro ao carregar a coleção de ClienteClass.";
protected const string ErroCollectionFornecedorClassEstado = "Erro ao carregar a coleção de FornecedorClass.";
protected const string ErroCollectionFuncionarioClassEstadoCtps = "Erro ao carregar a coleção de FuncionarioClass.";
protected const string ErroCollectionLocalDesembaracoAduaneiroClassEstado = "Erro ao carregar a coleção de LocalDesembaracoAduaneiroClass.";
protected const string ErroCollectionModeloFiscalIcmsClassEstadoSt = "Erro ao carregar a coleção de ModeloFiscalIcmsClass.";
protected const string ErroCollectionModeloFiscalIcmsEstadoClassEstado = "Erro ao carregar a coleção de ModeloFiscalIcmsEstadoClass.";
protected const string ErroCollectionNcmBeneficioFiscalClassEstado = "Erro ao carregar a coleção de NcmBeneficioFiscalClass.";
protected const string ErroCollectionOperacaoCompletaIcmsAliquotaClassEstado = "Erro ao carregar a coleção de OperacaoCompletaIcmsAliquotaClass.";
protected const string ErroCollectionTransporteClassEstado = "Erro ao carregar a coleção de TransporteClass.";
protected const string ErroCollectionTransporteClassEstadoVeiculo = "Erro ao carregar a coleção de TransporteClass.";
protected const string ErroSiglaObrigatorio = "O campo Sigla é obrigatório";
protected const string ErroSiglaComprimento = "O campo Sigla deve ter no máximo 2 caracteres";
protected const string ErroNomeObrigatorio = "O campo Nome é obrigatório";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do EstadoClass.";
protected const string MensagemUtilizadoCollectionAliquotaFundoCombatePobrezaClassEstado =  "A entidade EstadoClass está sendo utilizada nos seguintes AliquotaFundoCombatePobrezaClass:";
protected const string MensagemUtilizadoCollectionCidadeClassEstado =  "A entidade EstadoClass está sendo utilizada nos seguintes CidadeClass:";
protected const string MensagemUtilizadoCollectionClienteClassEstadoCob =  "A entidade EstadoClass está sendo utilizada nos seguintes ClienteClass:";
protected const string MensagemUtilizadoCollectionClienteClassEstado =  "A entidade EstadoClass está sendo utilizada nos seguintes ClienteClass:";
protected const string MensagemUtilizadoCollectionFornecedorClassEstado =  "A entidade EstadoClass está sendo utilizada nos seguintes FornecedorClass:";
protected const string MensagemUtilizadoCollectionFuncionarioClassEstadoCtps =  "A entidade EstadoClass está sendo utilizada nos seguintes FuncionarioClass:";
protected const string MensagemUtilizadoCollectionLocalDesembaracoAduaneiroClassEstado =  "A entidade EstadoClass está sendo utilizada nos seguintes LocalDesembaracoAduaneiroClass:";
protected const string MensagemUtilizadoCollectionModeloFiscalIcmsClassEstadoSt =  "A entidade EstadoClass está sendo utilizada nos seguintes ModeloFiscalIcmsClass:";
protected const string MensagemUtilizadoCollectionModeloFiscalIcmsEstadoClassEstado =  "A entidade EstadoClass está sendo utilizada nos seguintes ModeloFiscalIcmsEstadoClass:";
protected const string MensagemUtilizadoCollectionNcmBeneficioFiscalClassEstado =  "A entidade EstadoClass está sendo utilizada nos seguintes NcmBeneficioFiscalClass:";
protected const string MensagemUtilizadoCollectionOperacaoCompletaIcmsAliquotaClassEstado =  "A entidade EstadoClass está sendo utilizada nos seguintes OperacaoCompletaIcmsAliquotaClass:";
protected const string MensagemUtilizadoCollectionTransporteClassEstado =  "A entidade EstadoClass está sendo utilizada nos seguintes TransporteClass:";
protected const string MensagemUtilizadoCollectionTransporteClassEstadoVeiculo =  "A entidade EstadoClass está sendo utilizada nos seguintes TransporteClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade EstadoClass está sendo utilizada.";
#endregion
       protected string _siglaOriginal{get;private set;}
       private string _siglaOriginalCommited{get; set;}
        private string _valueSigla;
         [Column("est_sigla")]
        public virtual string Sigla
         { 
            get { return this._valueSigla; } 
            set 
            { 
                if (this._valueSigla == value)return;
                 this._valueSigla = value; 
            } 
        } 

       protected string _nomeOriginal{get;private set;}
       private string _nomeOriginalCommited{get; set;}
        private string _valueNome;
         [Column("est_nome")]
        public virtual string Nome
         { 
            get { return this._valueNome; } 
            set 
            { 
                if (this._valueNome == value)return;
                 this._valueNome = value; 
            } 
        } 

       protected double _aliquotaOriginal{get;private set;}
       private double _aliquotaOriginalCommited{get; set;}
        private double _valueAliquota;
         [Column("est_aliquota")]
        public virtual double Aliquota
         { 
            get { return this._valueAliquota; } 
            set 
            { 
                if (this._valueAliquota == value)return;
                 this._valueAliquota = value; 
            } 
        } 

       protected int? _codigoIbgeOriginal{get;private set;}
       private int? _codigoIbgeOriginalCommited{get; set;}
        private int? _valueCodigoIbge;
         [Column("est_codigo_ibge")]
        public virtual int? CodigoIbge
         { 
            get { return this._valueCodigoIbge; } 
            set 
            { 
                if (this._valueCodigoIbge == value)return;
                 this._valueCodigoIbge = value; 
            } 
        } 

       private List<long> _collectionAliquotaFundoCombatePobrezaClassEstadoOriginal;
       private List<Entidades.AliquotaFundoCombatePobrezaClass > _collectionAliquotaFundoCombatePobrezaClassEstadoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionAliquotaFundoCombatePobrezaClassEstadoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionAliquotaFundoCombatePobrezaClassEstadoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionAliquotaFundoCombatePobrezaClassEstadoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.AliquotaFundoCombatePobrezaClass> _valueCollectionAliquotaFundoCombatePobrezaClassEstado { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.AliquotaFundoCombatePobrezaClass> CollectionAliquotaFundoCombatePobrezaClassEstado 
       { 
           get { if(!_valueCollectionAliquotaFundoCombatePobrezaClassEstadoLoaded && !this.DisableLoadCollection){this.LoadCollectionAliquotaFundoCombatePobrezaClassEstado();}
return this._valueCollectionAliquotaFundoCombatePobrezaClassEstado; } 
           set 
           { 
               this._valueCollectionAliquotaFundoCombatePobrezaClassEstado = value; 
               this._valueCollectionAliquotaFundoCombatePobrezaClassEstadoLoaded = true; 
           } 
       } 

       private List<long> _collectionCidadeClassEstadoOriginal;
       private List<Entidades.CidadeClass > _collectionCidadeClassEstadoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionCidadeClassEstadoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionCidadeClassEstadoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionCidadeClassEstadoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.CidadeClass> _valueCollectionCidadeClassEstado { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.CidadeClass> CollectionCidadeClassEstado 
       { 
           get { if(!_valueCollectionCidadeClassEstadoLoaded && !this.DisableLoadCollection){this.LoadCollectionCidadeClassEstado();}
return this._valueCollectionCidadeClassEstado; } 
           set 
           { 
               this._valueCollectionCidadeClassEstado = value; 
               this._valueCollectionCidadeClassEstadoLoaded = true; 
           } 
       } 

       private List<long> _collectionClienteClassEstadoCobOriginal;
       private List<Entidades.ClienteClass > _collectionClienteClassEstadoCobRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionClienteClassEstadoCobLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionClienteClassEstadoCobChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionClienteClassEstadoCobCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ClienteClass> _valueCollectionClienteClassEstadoCob { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ClienteClass> CollectionClienteClassEstadoCob 
       { 
           get { if(!_valueCollectionClienteClassEstadoCobLoaded && !this.DisableLoadCollection){this.LoadCollectionClienteClassEstadoCob();}
return this._valueCollectionClienteClassEstadoCob; } 
           set 
           { 
               this._valueCollectionClienteClassEstadoCob = value; 
               this._valueCollectionClienteClassEstadoCobLoaded = true; 
           } 
       } 

       private List<long> _collectionClienteClassEstadoOriginal;
       private List<Entidades.ClienteClass > _collectionClienteClassEstadoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionClienteClassEstadoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionClienteClassEstadoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionClienteClassEstadoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ClienteClass> _valueCollectionClienteClassEstado { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ClienteClass> CollectionClienteClassEstado 
       { 
           get { if(!_valueCollectionClienteClassEstadoLoaded && !this.DisableLoadCollection){this.LoadCollectionClienteClassEstado();}
return this._valueCollectionClienteClassEstado; } 
           set 
           { 
               this._valueCollectionClienteClassEstado = value; 
               this._valueCollectionClienteClassEstadoLoaded = true; 
           } 
       } 

       private List<long> _collectionFornecedorClassEstadoOriginal;
       private List<Entidades.FornecedorClass > _collectionFornecedorClassEstadoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFornecedorClassEstadoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFornecedorClassEstadoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFornecedorClassEstadoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.FornecedorClass> _valueCollectionFornecedorClassEstado { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.FornecedorClass> CollectionFornecedorClassEstado 
       { 
           get { if(!_valueCollectionFornecedorClassEstadoLoaded && !this.DisableLoadCollection){this.LoadCollectionFornecedorClassEstado();}
return this._valueCollectionFornecedorClassEstado; } 
           set 
           { 
               this._valueCollectionFornecedorClassEstado = value; 
               this._valueCollectionFornecedorClassEstadoLoaded = true; 
           } 
       } 

       private List<long> _collectionFuncionarioClassEstadoCtpsOriginal;
       private List<Entidades.FuncionarioClass > _collectionFuncionarioClassEstadoCtpsRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFuncionarioClassEstadoCtpsLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFuncionarioClassEstadoCtpsChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFuncionarioClassEstadoCtpsCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.FuncionarioClass> _valueCollectionFuncionarioClassEstadoCtps { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.FuncionarioClass> CollectionFuncionarioClassEstadoCtps 
       { 
           get { if(!_valueCollectionFuncionarioClassEstadoCtpsLoaded && !this.DisableLoadCollection){this.LoadCollectionFuncionarioClassEstadoCtps();}
return this._valueCollectionFuncionarioClassEstadoCtps; } 
           set 
           { 
               this._valueCollectionFuncionarioClassEstadoCtps = value; 
               this._valueCollectionFuncionarioClassEstadoCtpsLoaded = true; 
           } 
       } 

       private List<long> _collectionLocalDesembaracoAduaneiroClassEstadoOriginal;
       private List<Entidades.LocalDesembaracoAduaneiroClass > _collectionLocalDesembaracoAduaneiroClassEstadoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionLocalDesembaracoAduaneiroClassEstadoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionLocalDesembaracoAduaneiroClassEstadoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionLocalDesembaracoAduaneiroClassEstadoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.LocalDesembaracoAduaneiroClass> _valueCollectionLocalDesembaracoAduaneiroClassEstado { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.LocalDesembaracoAduaneiroClass> CollectionLocalDesembaracoAduaneiroClassEstado 
       { 
           get { if(!_valueCollectionLocalDesembaracoAduaneiroClassEstadoLoaded && !this.DisableLoadCollection){this.LoadCollectionLocalDesembaracoAduaneiroClassEstado();}
return this._valueCollectionLocalDesembaracoAduaneiroClassEstado; } 
           set 
           { 
               this._valueCollectionLocalDesembaracoAduaneiroClassEstado = value; 
               this._valueCollectionLocalDesembaracoAduaneiroClassEstadoLoaded = true; 
           } 
       } 

       private List<long> _collectionModeloFiscalIcmsClassEstadoStOriginal;
       private List<Entidades.ModeloFiscalIcmsClass > _collectionModeloFiscalIcmsClassEstadoStRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionModeloFiscalIcmsClassEstadoStLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionModeloFiscalIcmsClassEstadoStChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionModeloFiscalIcmsClassEstadoStCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ModeloFiscalIcmsClass> _valueCollectionModeloFiscalIcmsClassEstadoSt { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ModeloFiscalIcmsClass> CollectionModeloFiscalIcmsClassEstadoSt 
       { 
           get { if(!_valueCollectionModeloFiscalIcmsClassEstadoStLoaded && !this.DisableLoadCollection){this.LoadCollectionModeloFiscalIcmsClassEstadoSt();}
return this._valueCollectionModeloFiscalIcmsClassEstadoSt; } 
           set 
           { 
               this._valueCollectionModeloFiscalIcmsClassEstadoSt = value; 
               this._valueCollectionModeloFiscalIcmsClassEstadoStLoaded = true; 
           } 
       } 

       private List<long> _collectionModeloFiscalIcmsEstadoClassEstadoOriginal;
       private List<Entidades.ModeloFiscalIcmsEstadoClass > _collectionModeloFiscalIcmsEstadoClassEstadoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionModeloFiscalIcmsEstadoClassEstadoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionModeloFiscalIcmsEstadoClassEstadoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionModeloFiscalIcmsEstadoClassEstadoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ModeloFiscalIcmsEstadoClass> _valueCollectionModeloFiscalIcmsEstadoClassEstado { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ModeloFiscalIcmsEstadoClass> CollectionModeloFiscalIcmsEstadoClassEstado 
       { 
           get { if(!_valueCollectionModeloFiscalIcmsEstadoClassEstadoLoaded && !this.DisableLoadCollection){this.LoadCollectionModeloFiscalIcmsEstadoClassEstado();}
return this._valueCollectionModeloFiscalIcmsEstadoClassEstado; } 
           set 
           { 
               this._valueCollectionModeloFiscalIcmsEstadoClassEstado = value; 
               this._valueCollectionModeloFiscalIcmsEstadoClassEstadoLoaded = true; 
           } 
       } 

       private List<long> _collectionNcmBeneficioFiscalClassEstadoOriginal;
       private List<Entidades.NcmBeneficioFiscalClass > _collectionNcmBeneficioFiscalClassEstadoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNcmBeneficioFiscalClassEstadoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNcmBeneficioFiscalClassEstadoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNcmBeneficioFiscalClassEstadoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NcmBeneficioFiscalClass> _valueCollectionNcmBeneficioFiscalClassEstado { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NcmBeneficioFiscalClass> CollectionNcmBeneficioFiscalClassEstado 
       { 
           get { if(!_valueCollectionNcmBeneficioFiscalClassEstadoLoaded && !this.DisableLoadCollection){this.LoadCollectionNcmBeneficioFiscalClassEstado();}
return this._valueCollectionNcmBeneficioFiscalClassEstado; } 
           set 
           { 
               this._valueCollectionNcmBeneficioFiscalClassEstado = value; 
               this._valueCollectionNcmBeneficioFiscalClassEstadoLoaded = true; 
           } 
       } 

       private List<long> _collectionOperacaoCompletaIcmsAliquotaClassEstadoOriginal;
       private List<Entidades.OperacaoCompletaIcmsAliquotaClass > _collectionOperacaoCompletaIcmsAliquotaClassEstadoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOperacaoCompletaIcmsAliquotaClassEstadoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOperacaoCompletaIcmsAliquotaClassEstadoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOperacaoCompletaIcmsAliquotaClassEstadoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OperacaoCompletaIcmsAliquotaClass> _valueCollectionOperacaoCompletaIcmsAliquotaClassEstado { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OperacaoCompletaIcmsAliquotaClass> CollectionOperacaoCompletaIcmsAliquotaClassEstado 
       { 
           get { if(!_valueCollectionOperacaoCompletaIcmsAliquotaClassEstadoLoaded && !this.DisableLoadCollection){this.LoadCollectionOperacaoCompletaIcmsAliquotaClassEstado();}
return this._valueCollectionOperacaoCompletaIcmsAliquotaClassEstado; } 
           set 
           { 
               this._valueCollectionOperacaoCompletaIcmsAliquotaClassEstado = value; 
               this._valueCollectionOperacaoCompletaIcmsAliquotaClassEstadoLoaded = true; 
           } 
       } 

       private List<long> _collectionTransporteClassEstadoOriginal;
       private List<Entidades.TransporteClass > _collectionTransporteClassEstadoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionTransporteClassEstadoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionTransporteClassEstadoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionTransporteClassEstadoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.TransporteClass> _valueCollectionTransporteClassEstado { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.TransporteClass> CollectionTransporteClassEstado 
       { 
           get { if(!_valueCollectionTransporteClassEstadoLoaded && !this.DisableLoadCollection){this.LoadCollectionTransporteClassEstado();}
return this._valueCollectionTransporteClassEstado; } 
           set 
           { 
               this._valueCollectionTransporteClassEstado = value; 
               this._valueCollectionTransporteClassEstadoLoaded = true; 
           } 
       } 

       private List<long> _collectionTransporteClassEstadoVeiculoOriginal;
       private List<Entidades.TransporteClass > _collectionTransporteClassEstadoVeiculoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionTransporteClassEstadoVeiculoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionTransporteClassEstadoVeiculoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionTransporteClassEstadoVeiculoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.TransporteClass> _valueCollectionTransporteClassEstadoVeiculo { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.TransporteClass> CollectionTransporteClassEstadoVeiculo 
       { 
           get { if(!_valueCollectionTransporteClassEstadoVeiculoLoaded && !this.DisableLoadCollection){this.LoadCollectionTransporteClassEstadoVeiculo();}
return this._valueCollectionTransporteClassEstadoVeiculo; } 
           set 
           { 
               this._valueCollectionTransporteClassEstadoVeiculo = value; 
               this._valueCollectionTransporteClassEstadoVeiculoLoaded = true; 
           } 
       } 

        public EstadoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static EstadoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (EstadoClass) GetEntity(typeof(EstadoClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionAliquotaFundoCombatePobrezaClassEstadoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionAliquotaFundoCombatePobrezaClassEstadoChanged = true;
                  _valueCollectionAliquotaFundoCombatePobrezaClassEstadoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionAliquotaFundoCombatePobrezaClassEstadoChanged = true; 
                  _valueCollectionAliquotaFundoCombatePobrezaClassEstadoCommitedChanged = true;
                 foreach (Entidades.AliquotaFundoCombatePobrezaClass item in e.OldItems) 
                 { 
                     _collectionAliquotaFundoCombatePobrezaClassEstadoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionAliquotaFundoCombatePobrezaClassEstadoChanged = true; 
                  _valueCollectionAliquotaFundoCombatePobrezaClassEstadoCommitedChanged = true;
                 foreach (Entidades.AliquotaFundoCombatePobrezaClass item in _valueCollectionAliquotaFundoCombatePobrezaClassEstado) 
                 { 
                     _collectionAliquotaFundoCombatePobrezaClassEstadoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionAliquotaFundoCombatePobrezaClassEstado()
         {
            try
            {
                 ObservableCollection<Entidades.AliquotaFundoCombatePobrezaClass> oc;
                _valueCollectionAliquotaFundoCombatePobrezaClassEstadoChanged = false;
                 _valueCollectionAliquotaFundoCombatePobrezaClassEstadoCommitedChanged = false;
                _collectionAliquotaFundoCombatePobrezaClassEstadoRemovidos = new List<Entidades.AliquotaFundoCombatePobrezaClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.AliquotaFundoCombatePobrezaClass>();
                }
                else{ 
                   Entidades.AliquotaFundoCombatePobrezaClass search = new Entidades.AliquotaFundoCombatePobrezaClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.AliquotaFundoCombatePobrezaClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Estado", this)                    }                       ).Cast<Entidades.AliquotaFundoCombatePobrezaClass>().ToList());
                 }
                 _valueCollectionAliquotaFundoCombatePobrezaClassEstado = new BindingList<Entidades.AliquotaFundoCombatePobrezaClass>(oc); 
                 _collectionAliquotaFundoCombatePobrezaClassEstadoOriginal= (from a in _valueCollectionAliquotaFundoCombatePobrezaClassEstado select a.ID).ToList();
                 _valueCollectionAliquotaFundoCombatePobrezaClassEstadoLoaded = true;
                 oc.CollectionChanged += CollectionAliquotaFundoCombatePobrezaClassEstadoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionAliquotaFundoCombatePobrezaClassEstado+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionCidadeClassEstadoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionCidadeClassEstadoChanged = true;
                  _valueCollectionCidadeClassEstadoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionCidadeClassEstadoChanged = true; 
                  _valueCollectionCidadeClassEstadoCommitedChanged = true;
                 foreach (Entidades.CidadeClass item in e.OldItems) 
                 { 
                     _collectionCidadeClassEstadoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionCidadeClassEstadoChanged = true; 
                  _valueCollectionCidadeClassEstadoCommitedChanged = true;
                 foreach (Entidades.CidadeClass item in _valueCollectionCidadeClassEstado) 
                 { 
                     _collectionCidadeClassEstadoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionCidadeClassEstado()
         {
            try
            {
                 ObservableCollection<Entidades.CidadeClass> oc;
                _valueCollectionCidadeClassEstadoChanged = false;
                 _valueCollectionCidadeClassEstadoCommitedChanged = false;
                _collectionCidadeClassEstadoRemovidos = new List<Entidades.CidadeClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.CidadeClass>();
                }
                else{ 
                   Entidades.CidadeClass search = new Entidades.CidadeClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.CidadeClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Estado", this)                    }                       ).Cast<Entidades.CidadeClass>().ToList());
                 }
                 _valueCollectionCidadeClassEstado = new BindingList<Entidades.CidadeClass>(oc); 
                 _collectionCidadeClassEstadoOriginal= (from a in _valueCollectionCidadeClassEstado select a.ID).ToList();
                 _valueCollectionCidadeClassEstadoLoaded = true;
                 oc.CollectionChanged += CollectionCidadeClassEstadoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionCidadeClassEstado+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionClienteClassEstadoCobChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionClienteClassEstadoCobChanged = true;
                  _valueCollectionClienteClassEstadoCobCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionClienteClassEstadoCobChanged = true; 
                  _valueCollectionClienteClassEstadoCobCommitedChanged = true;
                 foreach (Entidades.ClienteClass item in e.OldItems) 
                 { 
                     _collectionClienteClassEstadoCobRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionClienteClassEstadoCobChanged = true; 
                  _valueCollectionClienteClassEstadoCobCommitedChanged = true;
                 foreach (Entidades.ClienteClass item in _valueCollectionClienteClassEstadoCob) 
                 { 
                     _collectionClienteClassEstadoCobRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionClienteClassEstadoCob()
         {
            try
            {
                 ObservableCollection<Entidades.ClienteClass> oc;
                _valueCollectionClienteClassEstadoCobChanged = false;
                 _valueCollectionClienteClassEstadoCobCommitedChanged = false;
                _collectionClienteClassEstadoCobRemovidos = new List<Entidades.ClienteClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ClienteClass>();
                }
                else{ 
                   Entidades.ClienteClass search = new Entidades.ClienteClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ClienteClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("EstadoCob", this),                     }                       ).Cast<Entidades.ClienteClass>().ToList());
                 }
                 _valueCollectionClienteClassEstadoCob = new BindingList<Entidades.ClienteClass>(oc); 
                 _collectionClienteClassEstadoCobOriginal= (from a in _valueCollectionClienteClassEstadoCob select a.ID).ToList();
                 _valueCollectionClienteClassEstadoCobLoaded = true;
                 oc.CollectionChanged += CollectionClienteClassEstadoCobChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionClienteClassEstadoCob+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionClienteClassEstadoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionClienteClassEstadoChanged = true;
                  _valueCollectionClienteClassEstadoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionClienteClassEstadoChanged = true; 
                  _valueCollectionClienteClassEstadoCommitedChanged = true;
                 foreach (Entidades.ClienteClass item in e.OldItems) 
                 { 
                     _collectionClienteClassEstadoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionClienteClassEstadoChanged = true; 
                  _valueCollectionClienteClassEstadoCommitedChanged = true;
                 foreach (Entidades.ClienteClass item in _valueCollectionClienteClassEstado) 
                 { 
                     _collectionClienteClassEstadoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionClienteClassEstado()
         {
            try
            {
                 ObservableCollection<Entidades.ClienteClass> oc;
                _valueCollectionClienteClassEstadoChanged = false;
                 _valueCollectionClienteClassEstadoCommitedChanged = false;
                _collectionClienteClassEstadoRemovidos = new List<Entidades.ClienteClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ClienteClass>();
                }
                else{ 
                   Entidades.ClienteClass search = new Entidades.ClienteClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ClienteClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Estado", this),                     }                       ).Cast<Entidades.ClienteClass>().ToList());
                 }
                 _valueCollectionClienteClassEstado = new BindingList<Entidades.ClienteClass>(oc); 
                 _collectionClienteClassEstadoOriginal= (from a in _valueCollectionClienteClassEstado select a.ID).ToList();
                 _valueCollectionClienteClassEstadoLoaded = true;
                 oc.CollectionChanged += CollectionClienteClassEstadoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionClienteClassEstado+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionFornecedorClassEstadoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionFornecedorClassEstadoChanged = true;
                  _valueCollectionFornecedorClassEstadoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionFornecedorClassEstadoChanged = true; 
                  _valueCollectionFornecedorClassEstadoCommitedChanged = true;
                 foreach (Entidades.FornecedorClass item in e.OldItems) 
                 { 
                     _collectionFornecedorClassEstadoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionFornecedorClassEstadoChanged = true; 
                  _valueCollectionFornecedorClassEstadoCommitedChanged = true;
                 foreach (Entidades.FornecedorClass item in _valueCollectionFornecedorClassEstado) 
                 { 
                     _collectionFornecedorClassEstadoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionFornecedorClassEstado()
         {
            try
            {
                 ObservableCollection<Entidades.FornecedorClass> oc;
                _valueCollectionFornecedorClassEstadoChanged = false;
                 _valueCollectionFornecedorClassEstadoCommitedChanged = false;
                _collectionFornecedorClassEstadoRemovidos = new List<Entidades.FornecedorClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.FornecedorClass>();
                }
                else{ 
                   Entidades.FornecedorClass search = new Entidades.FornecedorClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.FornecedorClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Estado", this),                     }                       ).Cast<Entidades.FornecedorClass>().ToList());
                 }
                 _valueCollectionFornecedorClassEstado = new BindingList<Entidades.FornecedorClass>(oc); 
                 _collectionFornecedorClassEstadoOriginal= (from a in _valueCollectionFornecedorClassEstado select a.ID).ToList();
                 _valueCollectionFornecedorClassEstadoLoaded = true;
                 oc.CollectionChanged += CollectionFornecedorClassEstadoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionFornecedorClassEstado+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionFuncionarioClassEstadoCtpsChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionFuncionarioClassEstadoCtpsChanged = true;
                  _valueCollectionFuncionarioClassEstadoCtpsCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionFuncionarioClassEstadoCtpsChanged = true; 
                  _valueCollectionFuncionarioClassEstadoCtpsCommitedChanged = true;
                 foreach (Entidades.FuncionarioClass item in e.OldItems) 
                 { 
                     _collectionFuncionarioClassEstadoCtpsRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionFuncionarioClassEstadoCtpsChanged = true; 
                  _valueCollectionFuncionarioClassEstadoCtpsCommitedChanged = true;
                 foreach (Entidades.FuncionarioClass item in _valueCollectionFuncionarioClassEstadoCtps) 
                 { 
                     _collectionFuncionarioClassEstadoCtpsRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionFuncionarioClassEstadoCtps()
         {
            try
            {
                 ObservableCollection<Entidades.FuncionarioClass> oc;
                _valueCollectionFuncionarioClassEstadoCtpsChanged = false;
                 _valueCollectionFuncionarioClassEstadoCtpsCommitedChanged = false;
                _collectionFuncionarioClassEstadoCtpsRemovidos = new List<Entidades.FuncionarioClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.FuncionarioClass>();
                }
                else{ 
                   Entidades.FuncionarioClass search = new Entidades.FuncionarioClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.FuncionarioClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("EstadoCtps", this),                     }                       ).Cast<Entidades.FuncionarioClass>().ToList());
                 }
                 _valueCollectionFuncionarioClassEstadoCtps = new BindingList<Entidades.FuncionarioClass>(oc); 
                 _collectionFuncionarioClassEstadoCtpsOriginal= (from a in _valueCollectionFuncionarioClassEstadoCtps select a.ID).ToList();
                 _valueCollectionFuncionarioClassEstadoCtpsLoaded = true;
                 oc.CollectionChanged += CollectionFuncionarioClassEstadoCtpsChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionFuncionarioClassEstadoCtps+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionLocalDesembaracoAduaneiroClassEstadoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionLocalDesembaracoAduaneiroClassEstadoChanged = true;
                  _valueCollectionLocalDesembaracoAduaneiroClassEstadoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionLocalDesembaracoAduaneiroClassEstadoChanged = true; 
                  _valueCollectionLocalDesembaracoAduaneiroClassEstadoCommitedChanged = true;
                 foreach (Entidades.LocalDesembaracoAduaneiroClass item in e.OldItems) 
                 { 
                     _collectionLocalDesembaracoAduaneiroClassEstadoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionLocalDesembaracoAduaneiroClassEstadoChanged = true; 
                  _valueCollectionLocalDesembaracoAduaneiroClassEstadoCommitedChanged = true;
                 foreach (Entidades.LocalDesembaracoAduaneiroClass item in _valueCollectionLocalDesembaracoAduaneiroClassEstado) 
                 { 
                     _collectionLocalDesembaracoAduaneiroClassEstadoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionLocalDesembaracoAduaneiroClassEstado()
         {
            try
            {
                 ObservableCollection<Entidades.LocalDesembaracoAduaneiroClass> oc;
                _valueCollectionLocalDesembaracoAduaneiroClassEstadoChanged = false;
                 _valueCollectionLocalDesembaracoAduaneiroClassEstadoCommitedChanged = false;
                _collectionLocalDesembaracoAduaneiroClassEstadoRemovidos = new List<Entidades.LocalDesembaracoAduaneiroClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.LocalDesembaracoAduaneiroClass>();
                }
                else{ 
                   Entidades.LocalDesembaracoAduaneiroClass search = new Entidades.LocalDesembaracoAduaneiroClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.LocalDesembaracoAduaneiroClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Estado", this)                    }                       ).Cast<Entidades.LocalDesembaracoAduaneiroClass>().ToList());
                 }
                 _valueCollectionLocalDesembaracoAduaneiroClassEstado = new BindingList<Entidades.LocalDesembaracoAduaneiroClass>(oc); 
                 _collectionLocalDesembaracoAduaneiroClassEstadoOriginal= (from a in _valueCollectionLocalDesembaracoAduaneiroClassEstado select a.ID).ToList();
                 _valueCollectionLocalDesembaracoAduaneiroClassEstadoLoaded = true;
                 oc.CollectionChanged += CollectionLocalDesembaracoAduaneiroClassEstadoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionLocalDesembaracoAduaneiroClassEstado+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionModeloFiscalIcmsClassEstadoStChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionModeloFiscalIcmsClassEstadoStChanged = true;
                  _valueCollectionModeloFiscalIcmsClassEstadoStCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionModeloFiscalIcmsClassEstadoStChanged = true; 
                  _valueCollectionModeloFiscalIcmsClassEstadoStCommitedChanged = true;
                 foreach (Entidades.ModeloFiscalIcmsClass item in e.OldItems) 
                 { 
                     _collectionModeloFiscalIcmsClassEstadoStRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionModeloFiscalIcmsClassEstadoStChanged = true; 
                  _valueCollectionModeloFiscalIcmsClassEstadoStCommitedChanged = true;
                 foreach (Entidades.ModeloFiscalIcmsClass item in _valueCollectionModeloFiscalIcmsClassEstadoSt) 
                 { 
                     _collectionModeloFiscalIcmsClassEstadoStRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionModeloFiscalIcmsClassEstadoSt()
         {
            try
            {
                 ObservableCollection<Entidades.ModeloFiscalIcmsClass> oc;
                _valueCollectionModeloFiscalIcmsClassEstadoStChanged = false;
                 _valueCollectionModeloFiscalIcmsClassEstadoStCommitedChanged = false;
                _collectionModeloFiscalIcmsClassEstadoStRemovidos = new List<Entidades.ModeloFiscalIcmsClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ModeloFiscalIcmsClass>();
                }
                else{ 
                   Entidades.ModeloFiscalIcmsClass search = new Entidades.ModeloFiscalIcmsClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ModeloFiscalIcmsClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("EstadoSt", this),                     }                       ).Cast<Entidades.ModeloFiscalIcmsClass>().ToList());
                 }
                 _valueCollectionModeloFiscalIcmsClassEstadoSt = new BindingList<Entidades.ModeloFiscalIcmsClass>(oc); 
                 _collectionModeloFiscalIcmsClassEstadoStOriginal= (from a in _valueCollectionModeloFiscalIcmsClassEstadoSt select a.ID).ToList();
                 _valueCollectionModeloFiscalIcmsClassEstadoStLoaded = true;
                 oc.CollectionChanged += CollectionModeloFiscalIcmsClassEstadoStChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionModeloFiscalIcmsClassEstadoSt+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionModeloFiscalIcmsEstadoClassEstadoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionModeloFiscalIcmsEstadoClassEstadoChanged = true;
                  _valueCollectionModeloFiscalIcmsEstadoClassEstadoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionModeloFiscalIcmsEstadoClassEstadoChanged = true; 
                  _valueCollectionModeloFiscalIcmsEstadoClassEstadoCommitedChanged = true;
                 foreach (Entidades.ModeloFiscalIcmsEstadoClass item in e.OldItems) 
                 { 
                     _collectionModeloFiscalIcmsEstadoClassEstadoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionModeloFiscalIcmsEstadoClassEstadoChanged = true; 
                  _valueCollectionModeloFiscalIcmsEstadoClassEstadoCommitedChanged = true;
                 foreach (Entidades.ModeloFiscalIcmsEstadoClass item in _valueCollectionModeloFiscalIcmsEstadoClassEstado) 
                 { 
                     _collectionModeloFiscalIcmsEstadoClassEstadoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionModeloFiscalIcmsEstadoClassEstado()
         {
            try
            {
                 ObservableCollection<Entidades.ModeloFiscalIcmsEstadoClass> oc;
                _valueCollectionModeloFiscalIcmsEstadoClassEstadoChanged = false;
                 _valueCollectionModeloFiscalIcmsEstadoClassEstadoCommitedChanged = false;
                _collectionModeloFiscalIcmsEstadoClassEstadoRemovidos = new List<Entidades.ModeloFiscalIcmsEstadoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ModeloFiscalIcmsEstadoClass>();
                }
                else{ 
                   Entidades.ModeloFiscalIcmsEstadoClass search = new Entidades.ModeloFiscalIcmsEstadoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ModeloFiscalIcmsEstadoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Estado", this),                     }                       ).Cast<Entidades.ModeloFiscalIcmsEstadoClass>().ToList());
                 }
                 _valueCollectionModeloFiscalIcmsEstadoClassEstado = new BindingList<Entidades.ModeloFiscalIcmsEstadoClass>(oc); 
                 _collectionModeloFiscalIcmsEstadoClassEstadoOriginal= (from a in _valueCollectionModeloFiscalIcmsEstadoClassEstado select a.ID).ToList();
                 _valueCollectionModeloFiscalIcmsEstadoClassEstadoLoaded = true;
                 oc.CollectionChanged += CollectionModeloFiscalIcmsEstadoClassEstadoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionModeloFiscalIcmsEstadoClassEstado+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionNcmBeneficioFiscalClassEstadoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNcmBeneficioFiscalClassEstadoChanged = true;
                  _valueCollectionNcmBeneficioFiscalClassEstadoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNcmBeneficioFiscalClassEstadoChanged = true; 
                  _valueCollectionNcmBeneficioFiscalClassEstadoCommitedChanged = true;
                 foreach (Entidades.NcmBeneficioFiscalClass item in e.OldItems) 
                 { 
                     _collectionNcmBeneficioFiscalClassEstadoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNcmBeneficioFiscalClassEstadoChanged = true; 
                  _valueCollectionNcmBeneficioFiscalClassEstadoCommitedChanged = true;
                 foreach (Entidades.NcmBeneficioFiscalClass item in _valueCollectionNcmBeneficioFiscalClassEstado) 
                 { 
                     _collectionNcmBeneficioFiscalClassEstadoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNcmBeneficioFiscalClassEstado()
         {
            try
            {
                 ObservableCollection<Entidades.NcmBeneficioFiscalClass> oc;
                _valueCollectionNcmBeneficioFiscalClassEstadoChanged = false;
                 _valueCollectionNcmBeneficioFiscalClassEstadoCommitedChanged = false;
                _collectionNcmBeneficioFiscalClassEstadoRemovidos = new List<Entidades.NcmBeneficioFiscalClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NcmBeneficioFiscalClass>();
                }
                else{ 
                   Entidades.NcmBeneficioFiscalClass search = new Entidades.NcmBeneficioFiscalClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NcmBeneficioFiscalClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Estado", this),                     }                       ).Cast<Entidades.NcmBeneficioFiscalClass>().ToList());
                 }
                 _valueCollectionNcmBeneficioFiscalClassEstado = new BindingList<Entidades.NcmBeneficioFiscalClass>(oc); 
                 _collectionNcmBeneficioFiscalClassEstadoOriginal= (from a in _valueCollectionNcmBeneficioFiscalClassEstado select a.ID).ToList();
                 _valueCollectionNcmBeneficioFiscalClassEstadoLoaded = true;
                 oc.CollectionChanged += CollectionNcmBeneficioFiscalClassEstadoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNcmBeneficioFiscalClassEstado+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOperacaoCompletaIcmsAliquotaClassEstadoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOperacaoCompletaIcmsAliquotaClassEstadoChanged = true;
                  _valueCollectionOperacaoCompletaIcmsAliquotaClassEstadoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOperacaoCompletaIcmsAliquotaClassEstadoChanged = true; 
                  _valueCollectionOperacaoCompletaIcmsAliquotaClassEstadoCommitedChanged = true;
                 foreach (Entidades.OperacaoCompletaIcmsAliquotaClass item in e.OldItems) 
                 { 
                     _collectionOperacaoCompletaIcmsAliquotaClassEstadoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOperacaoCompletaIcmsAliquotaClassEstadoChanged = true; 
                  _valueCollectionOperacaoCompletaIcmsAliquotaClassEstadoCommitedChanged = true;
                 foreach (Entidades.OperacaoCompletaIcmsAliquotaClass item in _valueCollectionOperacaoCompletaIcmsAliquotaClassEstado) 
                 { 
                     _collectionOperacaoCompletaIcmsAliquotaClassEstadoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOperacaoCompletaIcmsAliquotaClassEstado()
         {
            try
            {
                 ObservableCollection<Entidades.OperacaoCompletaIcmsAliquotaClass> oc;
                _valueCollectionOperacaoCompletaIcmsAliquotaClassEstadoChanged = false;
                 _valueCollectionOperacaoCompletaIcmsAliquotaClassEstadoCommitedChanged = false;
                _collectionOperacaoCompletaIcmsAliquotaClassEstadoRemovidos = new List<Entidades.OperacaoCompletaIcmsAliquotaClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OperacaoCompletaIcmsAliquotaClass>();
                }
                else{ 
                   Entidades.OperacaoCompletaIcmsAliquotaClass search = new Entidades.OperacaoCompletaIcmsAliquotaClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OperacaoCompletaIcmsAliquotaClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Estado", this),                     }                       ).Cast<Entidades.OperacaoCompletaIcmsAliquotaClass>().ToList());
                 }
                 _valueCollectionOperacaoCompletaIcmsAliquotaClassEstado = new BindingList<Entidades.OperacaoCompletaIcmsAliquotaClass>(oc); 
                 _collectionOperacaoCompletaIcmsAliquotaClassEstadoOriginal= (from a in _valueCollectionOperacaoCompletaIcmsAliquotaClassEstado select a.ID).ToList();
                 _valueCollectionOperacaoCompletaIcmsAliquotaClassEstadoLoaded = true;
                 oc.CollectionChanged += CollectionOperacaoCompletaIcmsAliquotaClassEstadoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOperacaoCompletaIcmsAliquotaClassEstado+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionTransporteClassEstadoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionTransporteClassEstadoChanged = true;
                  _valueCollectionTransporteClassEstadoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionTransporteClassEstadoChanged = true; 
                  _valueCollectionTransporteClassEstadoCommitedChanged = true;
                 foreach (Entidades.TransporteClass item in e.OldItems) 
                 { 
                     _collectionTransporteClassEstadoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionTransporteClassEstadoChanged = true; 
                  _valueCollectionTransporteClassEstadoCommitedChanged = true;
                 foreach (Entidades.TransporteClass item in _valueCollectionTransporteClassEstado) 
                 { 
                     _collectionTransporteClassEstadoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionTransporteClassEstado()
         {
            try
            {
                 ObservableCollection<Entidades.TransporteClass> oc;
                _valueCollectionTransporteClassEstadoChanged = false;
                 _valueCollectionTransporteClassEstadoCommitedChanged = false;
                _collectionTransporteClassEstadoRemovidos = new List<Entidades.TransporteClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.TransporteClass>();
                }
                else{ 
                   Entidades.TransporteClass search = new Entidades.TransporteClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.TransporteClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Estado", this),                     }                       ).Cast<Entidades.TransporteClass>().ToList());
                 }
                 _valueCollectionTransporteClassEstado = new BindingList<Entidades.TransporteClass>(oc); 
                 _collectionTransporteClassEstadoOriginal= (from a in _valueCollectionTransporteClassEstado select a.ID).ToList();
                 _valueCollectionTransporteClassEstadoLoaded = true;
                 oc.CollectionChanged += CollectionTransporteClassEstadoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionTransporteClassEstado+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionTransporteClassEstadoVeiculoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionTransporteClassEstadoVeiculoChanged = true;
                  _valueCollectionTransporteClassEstadoVeiculoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionTransporteClassEstadoVeiculoChanged = true; 
                  _valueCollectionTransporteClassEstadoVeiculoCommitedChanged = true;
                 foreach (Entidades.TransporteClass item in e.OldItems) 
                 { 
                     _collectionTransporteClassEstadoVeiculoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionTransporteClassEstadoVeiculoChanged = true; 
                  _valueCollectionTransporteClassEstadoVeiculoCommitedChanged = true;
                 foreach (Entidades.TransporteClass item in _valueCollectionTransporteClassEstadoVeiculo) 
                 { 
                     _collectionTransporteClassEstadoVeiculoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionTransporteClassEstadoVeiculo()
         {
            try
            {
                 ObservableCollection<Entidades.TransporteClass> oc;
                _valueCollectionTransporteClassEstadoVeiculoChanged = false;
                 _valueCollectionTransporteClassEstadoVeiculoCommitedChanged = false;
                _collectionTransporteClassEstadoVeiculoRemovidos = new List<Entidades.TransporteClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.TransporteClass>();
                }
                else{ 
                   Entidades.TransporteClass search = new Entidades.TransporteClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.TransporteClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("EstadoVeiculo", this),                     }                       ).Cast<Entidades.TransporteClass>().ToList());
                 }
                 _valueCollectionTransporteClassEstadoVeiculo = new BindingList<Entidades.TransporteClass>(oc); 
                 _collectionTransporteClassEstadoVeiculoOriginal= (from a in _valueCollectionTransporteClassEstadoVeiculo select a.ID).ToList();
                 _valueCollectionTransporteClassEstadoVeiculoLoaded = true;
                 oc.CollectionChanged += CollectionTransporteClassEstadoVeiculoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionTransporteClassEstadoVeiculo+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Sigla))
                {
                    throw new Exception(ErroSiglaObrigatorio);
                }
                if (Sigla.Length >2)
                {
                    throw new Exception( ErroSiglaComprimento);
                }
                if (string.IsNullOrEmpty(Nome))
                {
                    throw new Exception(ErroNomeObrigatorio);
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
                    "  public.estado  " +
                    "WHERE " +
                    "  id_estado = :id";
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
                        "  public.estado   " +
                        "SET  " + 
                        "  est_sigla = :est_sigla, " + 
                        "  est_nome = :est_nome, " + 
                        "  est_aliquota = :est_aliquota, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  est_codigo_ibge = :est_codigo_ibge "+
                        "WHERE  " +
                        "  id_estado = :id " +
                        "RETURNING id_estado;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.estado " +
                        "( " +
                        "  est_sigla , " + 
                        "  est_nome , " + 
                        "  est_aliquota , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  est_codigo_ibge  "+
                        ")  " +
                        "VALUES ( " +
                        "  :est_sigla , " + 
                        "  :est_nome , " + 
                        "  :est_aliquota , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :est_codigo_ibge  "+
                        ")RETURNING id_estado;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("est_sigla", NpgsqlDbType.Char));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Sigla ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("est_nome", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Nome ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("est_aliquota", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Aliquota ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("est_codigo_ibge", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CodigoIbge ?? DBNull.Value;

 
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
 if (CollectionAliquotaFundoCombatePobrezaClassEstado.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionAliquotaFundoCombatePobrezaClassEstado+"\r\n";
                foreach (Entidades.AliquotaFundoCombatePobrezaClass tmp in CollectionAliquotaFundoCombatePobrezaClassEstado)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionCidadeClassEstado.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionCidadeClassEstado+"\r\n";
                foreach (Entidades.CidadeClass tmp in CollectionCidadeClassEstado)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionClienteClassEstadoCob.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionClienteClassEstadoCob+"\r\n";
                foreach (Entidades.ClienteClass tmp in CollectionClienteClassEstadoCob)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionClienteClassEstado.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionClienteClassEstado+"\r\n";
                foreach (Entidades.ClienteClass tmp in CollectionClienteClassEstado)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionFornecedorClassEstado.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionFornecedorClassEstado+"\r\n";
                foreach (Entidades.FornecedorClass tmp in CollectionFornecedorClassEstado)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionFuncionarioClassEstadoCtps.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionFuncionarioClassEstadoCtps+"\r\n";
                foreach (Entidades.FuncionarioClass tmp in CollectionFuncionarioClassEstadoCtps)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionLocalDesembaracoAduaneiroClassEstado.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionLocalDesembaracoAduaneiroClassEstado+"\r\n";
                foreach (Entidades.LocalDesembaracoAduaneiroClass tmp in CollectionLocalDesembaracoAduaneiroClassEstado)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionModeloFiscalIcmsClassEstadoSt.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionModeloFiscalIcmsClassEstadoSt+"\r\n";
                foreach (Entidades.ModeloFiscalIcmsClass tmp in CollectionModeloFiscalIcmsClassEstadoSt)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionModeloFiscalIcmsEstadoClassEstado.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionModeloFiscalIcmsEstadoClassEstado+"\r\n";
                foreach (Entidades.ModeloFiscalIcmsEstadoClass tmp in CollectionModeloFiscalIcmsEstadoClassEstado)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionNcmBeneficioFiscalClassEstado.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNcmBeneficioFiscalClassEstado+"\r\n";
                foreach (Entidades.NcmBeneficioFiscalClass tmp in CollectionNcmBeneficioFiscalClassEstado)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOperacaoCompletaIcmsAliquotaClassEstado.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOperacaoCompletaIcmsAliquotaClassEstado+"\r\n";
                foreach (Entidades.OperacaoCompletaIcmsAliquotaClass tmp in CollectionOperacaoCompletaIcmsAliquotaClassEstado)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionTransporteClassEstado.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionTransporteClassEstado+"\r\n";
                foreach (Entidades.TransporteClass tmp in CollectionTransporteClassEstado)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionTransporteClassEstadoVeiculo.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionTransporteClassEstadoVeiculo+"\r\n";
                foreach (Entidades.TransporteClass tmp in CollectionTransporteClassEstadoVeiculo)
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
        public static EstadoClass CopiarEntidade(EstadoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               EstadoClass toRet = new EstadoClass(usuario,conn);
 toRet.Sigla= entidadeCopiar.Sigla;
 toRet.Nome= entidadeCopiar.Nome;
 toRet.Aliquota= entidadeCopiar.Aliquota;
 toRet.CodigoIbge= entidadeCopiar.CodigoIbge;

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
       _siglaOriginal = Sigla;
       _siglaOriginalCommited = _siglaOriginal;
       _nomeOriginal = Nome;
       _nomeOriginalCommited = _nomeOriginal;
       _aliquotaOriginal = Aliquota;
       _aliquotaOriginalCommited = _aliquotaOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _codigoIbgeOriginal = CodigoIbge;
       _codigoIbgeOriginalCommited = _codigoIbgeOriginal;

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
       _siglaOriginalCommited = Sigla;
       _nomeOriginalCommited = Nome;
       _aliquotaOriginalCommited = Aliquota;
       _versionOriginalCommited = Version;
       _codigoIbgeOriginalCommited = CodigoIbge;

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
               if (_valueCollectionAliquotaFundoCombatePobrezaClassEstadoLoaded) 
               {
                  if (_collectionAliquotaFundoCombatePobrezaClassEstadoRemovidos != null) 
                  {
                     _collectionAliquotaFundoCombatePobrezaClassEstadoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionAliquotaFundoCombatePobrezaClassEstadoRemovidos = new List<Entidades.AliquotaFundoCombatePobrezaClass>();
                  }
                  _collectionAliquotaFundoCombatePobrezaClassEstadoOriginal= (from a in _valueCollectionAliquotaFundoCombatePobrezaClassEstado select a.ID).ToList();
                  _valueCollectionAliquotaFundoCombatePobrezaClassEstadoChanged = false;
                  _valueCollectionAliquotaFundoCombatePobrezaClassEstadoCommitedChanged = false;
               }
               if (_valueCollectionCidadeClassEstadoLoaded) 
               {
                  if (_collectionCidadeClassEstadoRemovidos != null) 
                  {
                     _collectionCidadeClassEstadoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionCidadeClassEstadoRemovidos = new List<Entidades.CidadeClass>();
                  }
                  _collectionCidadeClassEstadoOriginal= (from a in _valueCollectionCidadeClassEstado select a.ID).ToList();
                  _valueCollectionCidadeClassEstadoChanged = false;
                  _valueCollectionCidadeClassEstadoCommitedChanged = false;
               }
               if (_valueCollectionClienteClassEstadoCobLoaded) 
               {
                  if (_collectionClienteClassEstadoCobRemovidos != null) 
                  {
                     _collectionClienteClassEstadoCobRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionClienteClassEstadoCobRemovidos = new List<Entidades.ClienteClass>();
                  }
                  _collectionClienteClassEstadoCobOriginal= (from a in _valueCollectionClienteClassEstadoCob select a.ID).ToList();
                  _valueCollectionClienteClassEstadoCobChanged = false;
                  _valueCollectionClienteClassEstadoCobCommitedChanged = false;
               }
               if (_valueCollectionClienteClassEstadoLoaded) 
               {
                  if (_collectionClienteClassEstadoRemovidos != null) 
                  {
                     _collectionClienteClassEstadoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionClienteClassEstadoRemovidos = new List<Entidades.ClienteClass>();
                  }
                  _collectionClienteClassEstadoOriginal= (from a in _valueCollectionClienteClassEstado select a.ID).ToList();
                  _valueCollectionClienteClassEstadoChanged = false;
                  _valueCollectionClienteClassEstadoCommitedChanged = false;
               }
               if (_valueCollectionFornecedorClassEstadoLoaded) 
               {
                  if (_collectionFornecedorClassEstadoRemovidos != null) 
                  {
                     _collectionFornecedorClassEstadoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionFornecedorClassEstadoRemovidos = new List<Entidades.FornecedorClass>();
                  }
                  _collectionFornecedorClassEstadoOriginal= (from a in _valueCollectionFornecedorClassEstado select a.ID).ToList();
                  _valueCollectionFornecedorClassEstadoChanged = false;
                  _valueCollectionFornecedorClassEstadoCommitedChanged = false;
               }
               if (_valueCollectionFuncionarioClassEstadoCtpsLoaded) 
               {
                  if (_collectionFuncionarioClassEstadoCtpsRemovidos != null) 
                  {
                     _collectionFuncionarioClassEstadoCtpsRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionFuncionarioClassEstadoCtpsRemovidos = new List<Entidades.FuncionarioClass>();
                  }
                  _collectionFuncionarioClassEstadoCtpsOriginal= (from a in _valueCollectionFuncionarioClassEstadoCtps select a.ID).ToList();
                  _valueCollectionFuncionarioClassEstadoCtpsChanged = false;
                  _valueCollectionFuncionarioClassEstadoCtpsCommitedChanged = false;
               }
               if (_valueCollectionLocalDesembaracoAduaneiroClassEstadoLoaded) 
               {
                  if (_collectionLocalDesembaracoAduaneiroClassEstadoRemovidos != null) 
                  {
                     _collectionLocalDesembaracoAduaneiroClassEstadoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionLocalDesembaracoAduaneiroClassEstadoRemovidos = new List<Entidades.LocalDesembaracoAduaneiroClass>();
                  }
                  _collectionLocalDesembaracoAduaneiroClassEstadoOriginal= (from a in _valueCollectionLocalDesembaracoAduaneiroClassEstado select a.ID).ToList();
                  _valueCollectionLocalDesembaracoAduaneiroClassEstadoChanged = false;
                  _valueCollectionLocalDesembaracoAduaneiroClassEstadoCommitedChanged = false;
               }
               if (_valueCollectionModeloFiscalIcmsClassEstadoStLoaded) 
               {
                  if (_collectionModeloFiscalIcmsClassEstadoStRemovidos != null) 
                  {
                     _collectionModeloFiscalIcmsClassEstadoStRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionModeloFiscalIcmsClassEstadoStRemovidos = new List<Entidades.ModeloFiscalIcmsClass>();
                  }
                  _collectionModeloFiscalIcmsClassEstadoStOriginal= (from a in _valueCollectionModeloFiscalIcmsClassEstadoSt select a.ID).ToList();
                  _valueCollectionModeloFiscalIcmsClassEstadoStChanged = false;
                  _valueCollectionModeloFiscalIcmsClassEstadoStCommitedChanged = false;
               }
               if (_valueCollectionModeloFiscalIcmsEstadoClassEstadoLoaded) 
               {
                  if (_collectionModeloFiscalIcmsEstadoClassEstadoRemovidos != null) 
                  {
                     _collectionModeloFiscalIcmsEstadoClassEstadoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionModeloFiscalIcmsEstadoClassEstadoRemovidos = new List<Entidades.ModeloFiscalIcmsEstadoClass>();
                  }
                  _collectionModeloFiscalIcmsEstadoClassEstadoOriginal= (from a in _valueCollectionModeloFiscalIcmsEstadoClassEstado select a.ID).ToList();
                  _valueCollectionModeloFiscalIcmsEstadoClassEstadoChanged = false;
                  _valueCollectionModeloFiscalIcmsEstadoClassEstadoCommitedChanged = false;
               }
               if (_valueCollectionNcmBeneficioFiscalClassEstadoLoaded) 
               {
                  if (_collectionNcmBeneficioFiscalClassEstadoRemovidos != null) 
                  {
                     _collectionNcmBeneficioFiscalClassEstadoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNcmBeneficioFiscalClassEstadoRemovidos = new List<Entidades.NcmBeneficioFiscalClass>();
                  }
                  _collectionNcmBeneficioFiscalClassEstadoOriginal= (from a in _valueCollectionNcmBeneficioFiscalClassEstado select a.ID).ToList();
                  _valueCollectionNcmBeneficioFiscalClassEstadoChanged = false;
                  _valueCollectionNcmBeneficioFiscalClassEstadoCommitedChanged = false;
               }
               if (_valueCollectionOperacaoCompletaIcmsAliquotaClassEstadoLoaded) 
               {
                  if (_collectionOperacaoCompletaIcmsAliquotaClassEstadoRemovidos != null) 
                  {
                     _collectionOperacaoCompletaIcmsAliquotaClassEstadoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOperacaoCompletaIcmsAliquotaClassEstadoRemovidos = new List<Entidades.OperacaoCompletaIcmsAliquotaClass>();
                  }
                  _collectionOperacaoCompletaIcmsAliquotaClassEstadoOriginal= (from a in _valueCollectionOperacaoCompletaIcmsAliquotaClassEstado select a.ID).ToList();
                  _valueCollectionOperacaoCompletaIcmsAliquotaClassEstadoChanged = false;
                  _valueCollectionOperacaoCompletaIcmsAliquotaClassEstadoCommitedChanged = false;
               }
               if (_valueCollectionTransporteClassEstadoLoaded) 
               {
                  if (_collectionTransporteClassEstadoRemovidos != null) 
                  {
                     _collectionTransporteClassEstadoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionTransporteClassEstadoRemovidos = new List<Entidades.TransporteClass>();
                  }
                  _collectionTransporteClassEstadoOriginal= (from a in _valueCollectionTransporteClassEstado select a.ID).ToList();
                  _valueCollectionTransporteClassEstadoChanged = false;
                  _valueCollectionTransporteClassEstadoCommitedChanged = false;
               }
               if (_valueCollectionTransporteClassEstadoVeiculoLoaded) 
               {
                  if (_collectionTransporteClassEstadoVeiculoRemovidos != null) 
                  {
                     _collectionTransporteClassEstadoVeiculoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionTransporteClassEstadoVeiculoRemovidos = new List<Entidades.TransporteClass>();
                  }
                  _collectionTransporteClassEstadoVeiculoOriginal= (from a in _valueCollectionTransporteClassEstadoVeiculo select a.ID).ToList();
                  _valueCollectionTransporteClassEstadoVeiculoChanged = false;
                  _valueCollectionTransporteClassEstadoVeiculoCommitedChanged = false;
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
               Sigla=_siglaOriginal;
               _siglaOriginalCommited=_siglaOriginal;
               Nome=_nomeOriginal;
               _nomeOriginalCommited=_nomeOriginal;
               Aliquota=_aliquotaOriginal;
               _aliquotaOriginalCommited=_aliquotaOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               CodigoIbge=_codigoIbgeOriginal;
               _codigoIbgeOriginalCommited=_codigoIbgeOriginal;
               if (_valueCollectionAliquotaFundoCombatePobrezaClassEstadoLoaded) 
               {
                  CollectionAliquotaFundoCombatePobrezaClassEstado.Clear();
                  foreach(int item in _collectionAliquotaFundoCombatePobrezaClassEstadoOriginal)
                  {
                    CollectionAliquotaFundoCombatePobrezaClassEstado.Add(Entidades.AliquotaFundoCombatePobrezaClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionAliquotaFundoCombatePobrezaClassEstadoRemovidos.Clear();
               }
               if (_valueCollectionCidadeClassEstadoLoaded) 
               {
                  CollectionCidadeClassEstado.Clear();
                  foreach(int item in _collectionCidadeClassEstadoOriginal)
                  {
                    CollectionCidadeClassEstado.Add(Entidades.CidadeClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionCidadeClassEstadoRemovidos.Clear();
               }
               if (_valueCollectionClienteClassEstadoCobLoaded) 
               {
                  CollectionClienteClassEstadoCob.Clear();
                  foreach(int item in _collectionClienteClassEstadoCobOriginal)
                  {
                    CollectionClienteClassEstadoCob.Add(Entidades.ClienteClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionClienteClassEstadoCobRemovidos.Clear();
               }
               if (_valueCollectionClienteClassEstadoLoaded) 
               {
                  CollectionClienteClassEstado.Clear();
                  foreach(int item in _collectionClienteClassEstadoOriginal)
                  {
                    CollectionClienteClassEstado.Add(Entidades.ClienteClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionClienteClassEstadoRemovidos.Clear();
               }
               if (_valueCollectionFornecedorClassEstadoLoaded) 
               {
                  CollectionFornecedorClassEstado.Clear();
                  foreach(int item in _collectionFornecedorClassEstadoOriginal)
                  {
                    CollectionFornecedorClassEstado.Add(Entidades.FornecedorClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionFornecedorClassEstadoRemovidos.Clear();
               }
               if (_valueCollectionFuncionarioClassEstadoCtpsLoaded) 
               {
                  CollectionFuncionarioClassEstadoCtps.Clear();
                  foreach(int item in _collectionFuncionarioClassEstadoCtpsOriginal)
                  {
                    CollectionFuncionarioClassEstadoCtps.Add(Entidades.FuncionarioClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionFuncionarioClassEstadoCtpsRemovidos.Clear();
               }
               if (_valueCollectionLocalDesembaracoAduaneiroClassEstadoLoaded) 
               {
                  CollectionLocalDesembaracoAduaneiroClassEstado.Clear();
                  foreach(int item in _collectionLocalDesembaracoAduaneiroClassEstadoOriginal)
                  {
                    CollectionLocalDesembaracoAduaneiroClassEstado.Add(Entidades.LocalDesembaracoAduaneiroClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionLocalDesembaracoAduaneiroClassEstadoRemovidos.Clear();
               }
               if (_valueCollectionModeloFiscalIcmsClassEstadoStLoaded) 
               {
                  CollectionModeloFiscalIcmsClassEstadoSt.Clear();
                  foreach(int item in _collectionModeloFiscalIcmsClassEstadoStOriginal)
                  {
                    CollectionModeloFiscalIcmsClassEstadoSt.Add(Entidades.ModeloFiscalIcmsClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionModeloFiscalIcmsClassEstadoStRemovidos.Clear();
               }
               if (_valueCollectionModeloFiscalIcmsEstadoClassEstadoLoaded) 
               {
                  CollectionModeloFiscalIcmsEstadoClassEstado.Clear();
                  foreach(int item in _collectionModeloFiscalIcmsEstadoClassEstadoOriginal)
                  {
                    CollectionModeloFiscalIcmsEstadoClassEstado.Add(Entidades.ModeloFiscalIcmsEstadoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionModeloFiscalIcmsEstadoClassEstadoRemovidos.Clear();
               }
               if (_valueCollectionNcmBeneficioFiscalClassEstadoLoaded) 
               {
                  CollectionNcmBeneficioFiscalClassEstado.Clear();
                  foreach(int item in _collectionNcmBeneficioFiscalClassEstadoOriginal)
                  {
                    CollectionNcmBeneficioFiscalClassEstado.Add(Entidades.NcmBeneficioFiscalClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNcmBeneficioFiscalClassEstadoRemovidos.Clear();
               }
               if (_valueCollectionOperacaoCompletaIcmsAliquotaClassEstadoLoaded) 
               {
                  CollectionOperacaoCompletaIcmsAliquotaClassEstado.Clear();
                  foreach(int item in _collectionOperacaoCompletaIcmsAliquotaClassEstadoOriginal)
                  {
                    CollectionOperacaoCompletaIcmsAliquotaClassEstado.Add(Entidades.OperacaoCompletaIcmsAliquotaClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOperacaoCompletaIcmsAliquotaClassEstadoRemovidos.Clear();
               }
               if (_valueCollectionTransporteClassEstadoLoaded) 
               {
                  CollectionTransporteClassEstado.Clear();
                  foreach(int item in _collectionTransporteClassEstadoOriginal)
                  {
                    CollectionTransporteClassEstado.Add(Entidades.TransporteClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionTransporteClassEstadoRemovidos.Clear();
               }
               if (_valueCollectionTransporteClassEstadoVeiculoLoaded) 
               {
                  CollectionTransporteClassEstadoVeiculo.Clear();
                  foreach(int item in _collectionTransporteClassEstadoVeiculoOriginal)
                  {
                    CollectionTransporteClassEstadoVeiculo.Add(Entidades.TransporteClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionTransporteClassEstadoVeiculoRemovidos.Clear();
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
               if (_valueCollectionAliquotaFundoCombatePobrezaClassEstadoLoaded) 
               {
                  if (_valueCollectionAliquotaFundoCombatePobrezaClassEstadoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionCidadeClassEstadoLoaded) 
               {
                  if (_valueCollectionCidadeClassEstadoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionClienteClassEstadoCobLoaded) 
               {
                  if (_valueCollectionClienteClassEstadoCobChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionClienteClassEstadoLoaded) 
               {
                  if (_valueCollectionClienteClassEstadoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFornecedorClassEstadoLoaded) 
               {
                  if (_valueCollectionFornecedorClassEstadoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFuncionarioClassEstadoCtpsLoaded) 
               {
                  if (_valueCollectionFuncionarioClassEstadoCtpsChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionLocalDesembaracoAduaneiroClassEstadoLoaded) 
               {
                  if (_valueCollectionLocalDesembaracoAduaneiroClassEstadoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionModeloFiscalIcmsClassEstadoStLoaded) 
               {
                  if (_valueCollectionModeloFiscalIcmsClassEstadoStChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionModeloFiscalIcmsEstadoClassEstadoLoaded) 
               {
                  if (_valueCollectionModeloFiscalIcmsEstadoClassEstadoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNcmBeneficioFiscalClassEstadoLoaded) 
               {
                  if (_valueCollectionNcmBeneficioFiscalClassEstadoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOperacaoCompletaIcmsAliquotaClassEstadoLoaded) 
               {
                  if (_valueCollectionOperacaoCompletaIcmsAliquotaClassEstadoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionTransporteClassEstadoLoaded) 
               {
                  if (_valueCollectionTransporteClassEstadoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionTransporteClassEstadoVeiculoLoaded) 
               {
                  if (_valueCollectionTransporteClassEstadoVeiculoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionAliquotaFundoCombatePobrezaClassEstadoLoaded) 
               {
                   tempRet = CollectionAliquotaFundoCombatePobrezaClassEstado.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionCidadeClassEstadoLoaded) 
               {
                   tempRet = CollectionCidadeClassEstado.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionClienteClassEstadoCobLoaded) 
               {
                   tempRet = CollectionClienteClassEstadoCob.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionClienteClassEstadoLoaded) 
               {
                   tempRet = CollectionClienteClassEstado.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionFornecedorClassEstadoLoaded) 
               {
                   tempRet = CollectionFornecedorClassEstado.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionFuncionarioClassEstadoCtpsLoaded) 
               {
                   tempRet = CollectionFuncionarioClassEstadoCtps.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionLocalDesembaracoAduaneiroClassEstadoLoaded) 
               {
                   tempRet = CollectionLocalDesembaracoAduaneiroClassEstado.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionModeloFiscalIcmsClassEstadoStLoaded) 
               {
                   tempRet = CollectionModeloFiscalIcmsClassEstadoSt.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionModeloFiscalIcmsEstadoClassEstadoLoaded) 
               {
                   tempRet = CollectionModeloFiscalIcmsEstadoClassEstado.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionNcmBeneficioFiscalClassEstadoLoaded) 
               {
                   tempRet = CollectionNcmBeneficioFiscalClassEstado.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOperacaoCompletaIcmsAliquotaClassEstadoLoaded) 
               {
                   tempRet = CollectionOperacaoCompletaIcmsAliquotaClassEstado.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionTransporteClassEstadoLoaded) 
               {
                   tempRet = CollectionTransporteClassEstado.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionTransporteClassEstadoVeiculoLoaded) 
               {
                   tempRet = CollectionTransporteClassEstadoVeiculo.Any(item => item.IsDirty());
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
       dirty = _siglaOriginal != Sigla;
      if (dirty) return true;
       dirty = _nomeOriginal != Nome;
      if (dirty) return true;
       dirty = _aliquotaOriginal != Aliquota;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _codigoIbgeOriginal != CodigoIbge;

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
               if (_valueCollectionAliquotaFundoCombatePobrezaClassEstadoLoaded) 
               {
                  if (_valueCollectionAliquotaFundoCombatePobrezaClassEstadoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionCidadeClassEstadoLoaded) 
               {
                  if (_valueCollectionCidadeClassEstadoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionClienteClassEstadoCobLoaded) 
               {
                  if (_valueCollectionClienteClassEstadoCobCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionClienteClassEstadoLoaded) 
               {
                  if (_valueCollectionClienteClassEstadoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFornecedorClassEstadoLoaded) 
               {
                  if (_valueCollectionFornecedorClassEstadoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFuncionarioClassEstadoCtpsLoaded) 
               {
                  if (_valueCollectionFuncionarioClassEstadoCtpsCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionLocalDesembaracoAduaneiroClassEstadoLoaded) 
               {
                  if (_valueCollectionLocalDesembaracoAduaneiroClassEstadoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionModeloFiscalIcmsClassEstadoStLoaded) 
               {
                  if (_valueCollectionModeloFiscalIcmsClassEstadoStCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionModeloFiscalIcmsEstadoClassEstadoLoaded) 
               {
                  if (_valueCollectionModeloFiscalIcmsEstadoClassEstadoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNcmBeneficioFiscalClassEstadoLoaded) 
               {
                  if (_valueCollectionNcmBeneficioFiscalClassEstadoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOperacaoCompletaIcmsAliquotaClassEstadoLoaded) 
               {
                  if (_valueCollectionOperacaoCompletaIcmsAliquotaClassEstadoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionTransporteClassEstadoLoaded) 
               {
                  if (_valueCollectionTransporteClassEstadoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionTransporteClassEstadoVeiculoLoaded) 
               {
                  if (_valueCollectionTransporteClassEstadoVeiculoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionAliquotaFundoCombatePobrezaClassEstadoLoaded) 
               {
                   tempRet = CollectionAliquotaFundoCombatePobrezaClassEstado.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionCidadeClassEstadoLoaded) 
               {
                   tempRet = CollectionCidadeClassEstado.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionClienteClassEstadoCobLoaded) 
               {
                   tempRet = CollectionClienteClassEstadoCob.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionClienteClassEstadoLoaded) 
               {
                   tempRet = CollectionClienteClassEstado.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionFornecedorClassEstadoLoaded) 
               {
                   tempRet = CollectionFornecedorClassEstado.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionFuncionarioClassEstadoCtpsLoaded) 
               {
                   tempRet = CollectionFuncionarioClassEstadoCtps.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionLocalDesembaracoAduaneiroClassEstadoLoaded) 
               {
                   tempRet = CollectionLocalDesembaracoAduaneiroClassEstado.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionModeloFiscalIcmsClassEstadoStLoaded) 
               {
                   tempRet = CollectionModeloFiscalIcmsClassEstadoSt.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionModeloFiscalIcmsEstadoClassEstadoLoaded) 
               {
                   tempRet = CollectionModeloFiscalIcmsEstadoClassEstado.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionNcmBeneficioFiscalClassEstadoLoaded) 
               {
                   tempRet = CollectionNcmBeneficioFiscalClassEstado.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOperacaoCompletaIcmsAliquotaClassEstadoLoaded) 
               {
                   tempRet = CollectionOperacaoCompletaIcmsAliquotaClassEstado.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionTransporteClassEstadoLoaded) 
               {
                   tempRet = CollectionTransporteClassEstado.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionTransporteClassEstadoVeiculoLoaded) 
               {
                   tempRet = CollectionTransporteClassEstadoVeiculo.Any(item => item.IsDirtyCommited());
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
       dirty = _siglaOriginalCommited != Sigla;
      if (dirty) return true;
       dirty = _nomeOriginalCommited != Nome;
      if (dirty) return true;
       dirty = _aliquotaOriginalCommited != Aliquota;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _codigoIbgeOriginalCommited != CodigoIbge;

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
               if (_valueCollectionAliquotaFundoCombatePobrezaClassEstadoLoaded) 
               {
                  foreach(AliquotaFundoCombatePobrezaClass item in CollectionAliquotaFundoCombatePobrezaClassEstado)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionCidadeClassEstadoLoaded) 
               {
                  foreach(CidadeClass item in CollectionCidadeClassEstado)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionClienteClassEstadoCobLoaded) 
               {
                  foreach(ClienteClass item in CollectionClienteClassEstadoCob)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionClienteClassEstadoLoaded) 
               {
                  foreach(ClienteClass item in CollectionClienteClassEstado)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionFornecedorClassEstadoLoaded) 
               {
                  foreach(FornecedorClass item in CollectionFornecedorClassEstado)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionFuncionarioClassEstadoCtpsLoaded) 
               {
                  foreach(FuncionarioClass item in CollectionFuncionarioClassEstadoCtps)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionLocalDesembaracoAduaneiroClassEstadoLoaded) 
               {
                  foreach(LocalDesembaracoAduaneiroClass item in CollectionLocalDesembaracoAduaneiroClassEstado)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionModeloFiscalIcmsClassEstadoStLoaded) 
               {
                  foreach(ModeloFiscalIcmsClass item in CollectionModeloFiscalIcmsClassEstadoSt)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionModeloFiscalIcmsEstadoClassEstadoLoaded) 
               {
                  foreach(ModeloFiscalIcmsEstadoClass item in CollectionModeloFiscalIcmsEstadoClassEstado)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionNcmBeneficioFiscalClassEstadoLoaded) 
               {
                  foreach(NcmBeneficioFiscalClass item in CollectionNcmBeneficioFiscalClassEstado)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOperacaoCompletaIcmsAliquotaClassEstadoLoaded) 
               {
                  foreach(OperacaoCompletaIcmsAliquotaClass item in CollectionOperacaoCompletaIcmsAliquotaClassEstado)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionTransporteClassEstadoLoaded) 
               {
                  foreach(TransporteClass item in CollectionTransporteClassEstado)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionTransporteClassEstadoVeiculoLoaded) 
               {
                  foreach(TransporteClass item in CollectionTransporteClassEstadoVeiculo)
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
             case "Sigla":
                return this.Sigla;
             case "Nome":
                return this.Nome;
             case "Aliquota":
                return this.Aliquota;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "CodigoIbge":
                return this.CodigoIbge;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
               if (_valueCollectionAliquotaFundoCombatePobrezaClassEstadoLoaded) 
               {
                  foreach(AliquotaFundoCombatePobrezaClass item in CollectionAliquotaFundoCombatePobrezaClassEstado)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionCidadeClassEstadoLoaded) 
               {
                  foreach(CidadeClass item in CollectionCidadeClassEstado)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionClienteClassEstadoCobLoaded) 
               {
                  foreach(ClienteClass item in CollectionClienteClassEstadoCob)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionClienteClassEstadoLoaded) 
               {
                  foreach(ClienteClass item in CollectionClienteClassEstado)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionFornecedorClassEstadoLoaded) 
               {
                  foreach(FornecedorClass item in CollectionFornecedorClassEstado)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionFuncionarioClassEstadoCtpsLoaded) 
               {
                  foreach(FuncionarioClass item in CollectionFuncionarioClassEstadoCtps)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionLocalDesembaracoAduaneiroClassEstadoLoaded) 
               {
                  foreach(LocalDesembaracoAduaneiroClass item in CollectionLocalDesembaracoAduaneiroClassEstado)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionModeloFiscalIcmsClassEstadoStLoaded) 
               {
                  foreach(ModeloFiscalIcmsClass item in CollectionModeloFiscalIcmsClassEstadoSt)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionModeloFiscalIcmsEstadoClassEstadoLoaded) 
               {
                  foreach(ModeloFiscalIcmsEstadoClass item in CollectionModeloFiscalIcmsEstadoClassEstado)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionNcmBeneficioFiscalClassEstadoLoaded) 
               {
                  foreach(NcmBeneficioFiscalClass item in CollectionNcmBeneficioFiscalClassEstado)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOperacaoCompletaIcmsAliquotaClassEstadoLoaded) 
               {
                  foreach(OperacaoCompletaIcmsAliquotaClass item in CollectionOperacaoCompletaIcmsAliquotaClassEstado)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionTransporteClassEstadoLoaded) 
               {
                  foreach(TransporteClass item in CollectionTransporteClassEstado)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionTransporteClassEstadoVeiculoLoaded) 
               {
                  foreach(TransporteClass item in CollectionTransporteClassEstadoVeiculo)
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
                  command.CommandText += " COUNT(estado.id_estado) " ;
               }
               else
               {
               command.CommandText += "estado.id_estado, " ;
               command.CommandText += "estado.est_sigla, " ;
               command.CommandText += "estado.est_nome, " ;
               command.CommandText += "estado.est_aliquota, " ;
               command.CommandText += "estado.entity_uid, " ;
               command.CommandText += "estado.version, " ;
               command.CommandText += "estado.est_codigo_ibge " ;
               }
               command.CommandText += " FROM  estado ";
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
                        orderByClause += " , est_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(est_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = estado.id_acs_usuario_ultima_revisao ";
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
                     case "id_estado":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , estado.id_estado " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(estado.id_estado) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "est_sigla":
                     case "Sigla":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , estado.est_sigla " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(estado.est_sigla) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "est_nome":
                     case "Nome":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , estado.est_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(estado.est_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "est_aliquota":
                     case "Aliquota":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , estado.est_aliquota " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(estado.est_aliquota) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , estado.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(estado.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , estado.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(estado.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "est_codigo_ibge":
                     case "CodigoIbge":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , estado.est_codigo_ibge " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(estado.est_codigo_ibge) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("est_sigla")) 
                        {
                           whereClause += " OR UPPER(estado.est_sigla) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(estado.est_sigla) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("est_nome")) 
                        {
                           whereClause += " OR UPPER(estado.est_nome) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(estado.est_nome) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(estado.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(estado.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_estado")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  estado.id_estado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estado.id_estado = :estado_ID_3172 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estado_ID_3172", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Sigla" || parametro.FieldName == "est_sigla")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  estado.est_sigla IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estado.est_sigla LIKE :estado_Sigla_653 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estado_Sigla_653", NpgsqlDbType.Char,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Nome" || parametro.FieldName == "est_nome")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  estado.est_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estado.est_nome LIKE :estado_Nome_5402 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estado_Nome_5402", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Aliquota" || parametro.FieldName == "est_aliquota")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  estado.est_aliquota IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estado.est_aliquota = :estado_Aliquota_77 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estado_Aliquota_77", NpgsqlDbType.Double, parametro.Fieldvalue));
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
                         whereClause += "  estado.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estado.entity_uid LIKE :estado_EntityUid_2606 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estado_EntityUid_2606", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  estado.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estado.version = :estado_Version_570 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estado_Version_570", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoIbge" || parametro.FieldName == "est_codigo_ibge")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  estado.est_codigo_ibge IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estado.est_codigo_ibge = :estado_CodigoIbge_994 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estado_CodigoIbge_994", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SiglaExato" || parametro.FieldName == "SiglaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  estado.est_sigla IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estado.est_sigla LIKE :estado_Sigla_5492 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estado_Sigla_5492", NpgsqlDbType.Char,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  estado.est_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estado.est_nome LIKE :estado_Nome_2260 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estado_Nome_2260", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  estado.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estado.entity_uid LIKE :estado_EntityUid_1697 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estado_EntityUid_1697", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  EstadoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (EstadoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(EstadoClass), Convert.ToInt32(read["id_estado"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new EstadoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_estado"]);
                     entidade.Sigla = (read["est_sigla"] != DBNull.Value ? read["est_sigla"].ToString() : null);
                     entidade.Nome = (read["est_nome"] != DBNull.Value ? read["est_nome"].ToString() : null);
                     entidade.Aliquota = (double)read["est_aliquota"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.CodigoIbge = read["est_codigo_ibge"] as int?;
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (EstadoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
