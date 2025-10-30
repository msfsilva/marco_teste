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
using IWTNFCompleto.BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
namespace IWTNFCompleto.BibliotecaEntidades.Base 
{ 
    [Serializable()]
     [Table("mdfe_modal_rodoviario","mrd")]
     public class MdfeModalRodoviarioBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do MdfeModalRodoviarioClass";
protected const string ErroDelete = "Erro ao excluir o MdfeModalRodoviarioClass  ";
protected const string ErroSave = "Erro ao salvar o MdfeModalRodoviarioClass.";
protected const string ErroCollectionMdfeRodoCondutorClassMdfeModalRodoviario = "Erro ao carregar a coleção de MdfeRodoCondutorClass.";
protected const string ErroCollectionMdfeRodoReboqueClassMdfeModalRodoviario = "Erro ao carregar a coleção de MdfeRodoReboqueClass.";
protected const string ErroCollectionMdfeRodoValePedagioClassMdfeModalRodoviario = "Erro ao carregar a coleção de MdfeRodoValePedagioClass.";
protected const string ErroVersaoObrigatorio = "O campo Versao é obrigatório";
protected const string ErroVersaoComprimento = "O campo Versao deve ter no máximo 10 caracteres";
protected const string ErroPlacaObrigatorio = "O campo Placa é obrigatório";
protected const string ErroPlacaComprimento = "O campo Placa deve ter no máximo 7 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroUfLiceciamentoObrigatorio = "O campo UfLiceciamento é obrigatório";
protected const string ErroUfLiceciamentoComprimento = "O campo UfLiceciamento deve ter no máximo 2 caracteres";
protected const string ErroMdfeObrigatorio = "O campo Mdfe é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do MdfeModalRodoviarioClass.";
protected const string MensagemUtilizadoCollectionMdfeRodoCondutorClassMdfeModalRodoviario =  "A entidade MdfeModalRodoviarioClass está sendo utilizada nos seguintes MdfeRodoCondutorClass:";
protected const string MensagemUtilizadoCollectionMdfeRodoReboqueClassMdfeModalRodoviario =  "A entidade MdfeModalRodoviarioClass está sendo utilizada nos seguintes MdfeRodoReboqueClass:";
protected const string MensagemUtilizadoCollectionMdfeRodoValePedagioClassMdfeModalRodoviario =  "A entidade MdfeModalRodoviarioClass está sendo utilizada nos seguintes MdfeRodoValePedagioClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade MdfeModalRodoviarioClass está sendo utilizada.";
#endregion
       protected IWTNFCompleto.BibliotecaEntidades.Entidades.MdfeClass _mdfeOriginal{get;private set;}
       private IWTNFCompleto.BibliotecaEntidades.Entidades.MdfeClass _mdfeOriginalCommited {get; set;}
       private IWTNFCompleto.BibliotecaEntidades.Entidades.MdfeClass _valueMdfe;
        [Column("id_mdfe", "mdfe", "id_mdfe")]
       public virtual IWTNFCompleto.BibliotecaEntidades.Entidades.MdfeClass Mdfe
        { 
           get {                 return this._valueMdfe; } 
           set 
           { 
                if (this._valueMdfe == value)return;
                 this._valueMdfe = value; 
           } 
       } 

       protected string _versaoOriginal{get;private set;}
       private string _versaoOriginalCommited{get; set;}
        private string _valueVersao;
         [Column("mrd_versao")]
        public virtual string Versao
         { 
            get { return this._valueVersao; } 
            set 
            { 
                if (this._valueVersao == value)return;
                 this._valueVersao = value; 
            } 
        } 

       protected int? _rntrcOriginal{get;private set;}
       private int? _rntrcOriginalCommited{get; set;}
        private int? _valueRntrc;
         [Column("mrd_rntrc")]
        public virtual int? Rntrc
         { 
            get { return this._valueRntrc; } 
            set 
            { 
                if (this._valueRntrc == value)return;
                 this._valueRntrc = value; 
            } 
        } 

       protected int? _ciotOriginal{get;private set;}
       private int? _ciotOriginalCommited{get; set;}
        private int? _valueCiot;
         [Column("mrd_ciot")]
        public virtual int? Ciot
         { 
            get { return this._valueCiot; } 
            set 
            { 
                if (this._valueCiot == value)return;
                 this._valueCiot = value; 
            } 
        } 

       protected string _codigoInternoVeiculoOriginal{get;private set;}
       private string _codigoInternoVeiculoOriginalCommited{get; set;}
        private string _valueCodigoInternoVeiculo;
         [Column("mrd_codigo_interno_veiculo")]
        public virtual string CodigoInternoVeiculo
         { 
            get { return this._valueCodigoInternoVeiculo; } 
            set 
            { 
                if (this._valueCodigoInternoVeiculo == value)return;
                 this._valueCodigoInternoVeiculo = value; 
            } 
        } 

       protected string _placaOriginal{get;private set;}
       private string _placaOriginalCommited{get; set;}
        private string _valuePlaca;
         [Column("mrd_placa")]
        public virtual string Placa
         { 
            get { return this._valuePlaca; } 
            set 
            { 
                if (this._valuePlaca == value)return;
                 this._valuePlaca = value; 
            } 
        } 

       protected double _taraOriginal{get;private set;}
       private double _taraOriginalCommited{get; set;}
        private double _valueTara;
         [Column("mrd_tara")]
        public virtual double Tara
         { 
            get { return this._valueTara; } 
            set 
            { 
                if (this._valueTara == value)return;
                 this._valueTara = value; 
            } 
        } 

       protected double? _capacidadeKgOriginal{get;private set;}
       private double? _capacidadeKgOriginalCommited{get; set;}
        private double? _valueCapacidadeKg;
         [Column("mrd_capacidade_kg")]
        public virtual double? CapacidadeKg
         { 
            get { return this._valueCapacidadeKg; } 
            set 
            { 
                if (this._valueCapacidadeKg == value)return;
                 this._valueCapacidadeKg = value; 
            } 
        } 

       protected double? _capacidadeM3Original{get;private set;}
       private double? _capacidadeM3OriginalCommited{get; set;}
        private double? _valueCapacidadeM3;
         [Column("mrd_capacidade_m3")]
        public virtual double? CapacidadeM3
         { 
            get { return this._valueCapacidadeM3; } 
            set 
            { 
                if (this._valueCapacidadeM3 == value)return;
                 this._valueCapacidadeM3 = value; 
            } 
        } 

       protected int _proprietarioRntrcOriginal{get;private set;}
       private int _proprietarioRntrcOriginalCommited{get; set;}
        private int _valueProprietarioRntrc;
         [Column("mrd_proprietario_rntrc")]
        public virtual int ProprietarioRntrc
         { 
            get { return this._valueProprietarioRntrc; } 
            set 
            { 
                if (this._valueProprietarioRntrc == value)return;
                 this._valueProprietarioRntrc = value; 
            } 
        } 

       protected string _cpfProprietarioOriginal{get;private set;}
       private string _cpfProprietarioOriginalCommited{get; set;}
        private string _valueCpfProprietario;
         [Column("mrd_cpf_proprietario")]
        public virtual string CpfProprietario
         { 
            get { return this._valueCpfProprietario; } 
            set 
            { 
                if (this._valueCpfProprietario == value)return;
                 this._valueCpfProprietario = value; 
            } 
        } 

       protected string _cnpjProprietarioOriginal{get;private set;}
       private string _cnpjProprietarioOriginalCommited{get; set;}
        private string _valueCnpjProprietario;
         [Column("mrd_cnpj_proprietario")]
        public virtual string CnpjProprietario
         { 
            get { return this._valueCnpjProprietario; } 
            set 
            { 
                if (this._valueCnpjProprietario == value)return;
                 this._valueCnpjProprietario = value; 
            } 
        } 

       protected string _nomeRazaoProprietarioOriginal{get;private set;}
       private string _nomeRazaoProprietarioOriginalCommited{get; set;}
        private string _valueNomeRazaoProprietario;
         [Column("mrd_nome_razao_proprietario")]
        public virtual string NomeRazaoProprietario
         { 
            get { return this._valueNomeRazaoProprietario; } 
            set 
            { 
                if (this._valueNomeRazaoProprietario == value)return;
                 this._valueNomeRazaoProprietario = value; 
            } 
        } 

       protected string _ieProprietarioOriginal{get;private set;}
       private string _ieProprietarioOriginalCommited{get; set;}
        private string _valueIeProprietario;
         [Column("mrd_ie_proprietario")]
        public virtual string IeProprietario
         { 
            get { return this._valueIeProprietario; } 
            set 
            { 
                if (this._valueIeProprietario == value)return;
                 this._valueIeProprietario = value; 
            } 
        } 

       protected string _ufProprietarioOriginal{get;private set;}
       private string _ufProprietarioOriginalCommited{get; set;}
        private string _valueUfProprietario;
         [Column("mdr_uf_proprietario")]
        public virtual string UfProprietario
         { 
            get { return this._valueUfProprietario; } 
            set 
            { 
                if (this._valueUfProprietario == value)return;
                 this._valueUfProprietario = value; 
            } 
        } 

       protected MDFeTipoProprietarioVeiculo? _tipoProprietarioOriginal{get;private set;}
       private MDFeTipoProprietarioVeiculo? _tipoProprietarioOriginalCommited{get; set;}
        private MDFeTipoProprietarioVeiculo? _valueTipoProprietario;
         [Column("mdr_tipo_proprietario")]
        public virtual MDFeTipoProprietarioVeiculo? TipoProprietario
         { 
            get { return this._valueTipoProprietario; } 
            set 
            { 
                if (this._valueTipoProprietario == value)return;
                 this._valueTipoProprietario = value; 
            } 
        } 

        public bool TipoProprietario_TACAgregado
         { 
            get { return this._valueTipoProprietario.HasValue && this._valueTipoProprietario.Value == IWTNFCompleto.BibliotecaEntidades.Base.MDFeTipoProprietarioVeiculo.TACAgregado; } 
            set { if (value) this._valueTipoProprietario = IWTNFCompleto.BibliotecaEntidades.Base.MDFeTipoProprietarioVeiculo.TACAgregado; }
         } 

        public bool TipoProprietario_TACIndependente
         { 
            get { return this._valueTipoProprietario.HasValue && this._valueTipoProprietario.Value == IWTNFCompleto.BibliotecaEntidades.Base.MDFeTipoProprietarioVeiculo.TACIndependente; } 
            set { if (value) this._valueTipoProprietario = IWTNFCompleto.BibliotecaEntidades.Base.MDFeTipoProprietarioVeiculo.TACIndependente; }
         } 

        public bool TipoProprietario_Outros
         { 
            get { return this._valueTipoProprietario.HasValue && this._valueTipoProprietario.Value == IWTNFCompleto.BibliotecaEntidades.Base.MDFeTipoProprietarioVeiculo.Outros; } 
            set { if (value) this._valueTipoProprietario = IWTNFCompleto.BibliotecaEntidades.Base.MDFeTipoProprietarioVeiculo.Outros; }
         } 

       protected MDFeTipoRodado _tipoRodadoOriginal{get;private set;}
       private MDFeTipoRodado _tipoRodadoOriginalCommited{get; set;}
        private MDFeTipoRodado _valueTipoRodado;
         [Column("mdr_tipo_rodado")]
        public virtual MDFeTipoRodado TipoRodado
         { 
            get { return this._valueTipoRodado; } 
            set 
            { 
                if (this._valueTipoRodado == value)return;
                 this._valueTipoRodado = value; 
            } 
        } 

        public bool TipoRodado_Truck
         { 
            get { return this._valueTipoRodado == IWTNFCompleto.BibliotecaEntidades.Base.MDFeTipoRodado.Truck; } 
            set { if (value) this._valueTipoRodado = IWTNFCompleto.BibliotecaEntidades.Base.MDFeTipoRodado.Truck; }
         } 

        public bool TipoRodado_Toco
         { 
            get { return this._valueTipoRodado == IWTNFCompleto.BibliotecaEntidades.Base.MDFeTipoRodado.Toco; } 
            set { if (value) this._valueTipoRodado = IWTNFCompleto.BibliotecaEntidades.Base.MDFeTipoRodado.Toco; }
         } 

        public bool TipoRodado_CavaloMecanico
         { 
            get { return this._valueTipoRodado == IWTNFCompleto.BibliotecaEntidades.Base.MDFeTipoRodado.CavaloMecanico; } 
            set { if (value) this._valueTipoRodado = IWTNFCompleto.BibliotecaEntidades.Base.MDFeTipoRodado.CavaloMecanico; }
         } 

        public bool TipoRodado_Van
         { 
            get { return this._valueTipoRodado == IWTNFCompleto.BibliotecaEntidades.Base.MDFeTipoRodado.Van; } 
            set { if (value) this._valueTipoRodado = IWTNFCompleto.BibliotecaEntidades.Base.MDFeTipoRodado.Van; }
         } 

        public bool TipoRodado_Utilitario
         { 
            get { return this._valueTipoRodado == IWTNFCompleto.BibliotecaEntidades.Base.MDFeTipoRodado.Utilitario; } 
            set { if (value) this._valueTipoRodado = IWTNFCompleto.BibliotecaEntidades.Base.MDFeTipoRodado.Utilitario; }
         } 

        public bool TipoRodado_Outros
         { 
            get { return this._valueTipoRodado == IWTNFCompleto.BibliotecaEntidades.Base.MDFeTipoRodado.Outros; } 
            set { if (value) this._valueTipoRodado = IWTNFCompleto.BibliotecaEntidades.Base.MDFeTipoRodado.Outros; }
         } 

       protected MDFeTipoCarroceria _tipoCarroceriaOriginal{get;private set;}
       private MDFeTipoCarroceria _tipoCarroceriaOriginalCommited{get; set;}
        private MDFeTipoCarroceria _valueTipoCarroceria;
         [Column("mdr_tipo_carroceria")]
        public virtual MDFeTipoCarroceria TipoCarroceria
         { 
            get { return this._valueTipoCarroceria; } 
            set 
            { 
                if (this._valueTipoCarroceria == value)return;
                 this._valueTipoCarroceria = value; 
            } 
        } 

        public bool TipoCarroceria_NaoAplicavel
         { 
            get { return this._valueTipoCarroceria == IWTNFCompleto.BibliotecaEntidades.Base.MDFeTipoCarroceria.NaoAplicavel; } 
            set { if (value) this._valueTipoCarroceria = IWTNFCompleto.BibliotecaEntidades.Base.MDFeTipoCarroceria.NaoAplicavel; }
         } 

        public bool TipoCarroceria_Aberta
         { 
            get { return this._valueTipoCarroceria == IWTNFCompleto.BibliotecaEntidades.Base.MDFeTipoCarroceria.Aberta; } 
            set { if (value) this._valueTipoCarroceria = IWTNFCompleto.BibliotecaEntidades.Base.MDFeTipoCarroceria.Aberta; }
         } 

        public bool TipoCarroceria_FechadaBau
         { 
            get { return this._valueTipoCarroceria == IWTNFCompleto.BibliotecaEntidades.Base.MDFeTipoCarroceria.FechadaBau; } 
            set { if (value) this._valueTipoCarroceria = IWTNFCompleto.BibliotecaEntidades.Base.MDFeTipoCarroceria.FechadaBau; }
         } 

        public bool TipoCarroceria_Granelera
         { 
            get { return this._valueTipoCarroceria == IWTNFCompleto.BibliotecaEntidades.Base.MDFeTipoCarroceria.Granelera; } 
            set { if (value) this._valueTipoCarroceria = IWTNFCompleto.BibliotecaEntidades.Base.MDFeTipoCarroceria.Granelera; }
         } 

        public bool TipoCarroceria_PortaContainer
         { 
            get { return this._valueTipoCarroceria == IWTNFCompleto.BibliotecaEntidades.Base.MDFeTipoCarroceria.PortaContainer; } 
            set { if (value) this._valueTipoCarroceria = IWTNFCompleto.BibliotecaEntidades.Base.MDFeTipoCarroceria.PortaContainer; }
         } 

        public bool TipoCarroceria_Sider
         { 
            get { return this._valueTipoCarroceria == IWTNFCompleto.BibliotecaEntidades.Base.MDFeTipoCarroceria.Sider; } 
            set { if (value) this._valueTipoCarroceria = IWTNFCompleto.BibliotecaEntidades.Base.MDFeTipoCarroceria.Sider; }
         } 

       protected string _ufLiceciamentoOriginal{get;private set;}
       private string _ufLiceciamentoOriginalCommited{get; set;}
        private string _valueUfLiceciamento;
         [Column("mdr_uf_liceciamento")]
        public virtual string UfLiceciamento
         { 
            get { return this._valueUfLiceciamento; } 
            set 
            { 
                if (this._valueUfLiceciamento == value)return;
                 this._valueUfLiceciamento = value; 
            } 
        } 

       protected string _renavamOriginal{get;private set;}
       private string _renavamOriginalCommited{get; set;}
        private string _valueRenavam;
         [Column("mrd_renavam")]
        public virtual string Renavam
         { 
            get { return this._valueRenavam; } 
            set 
            { 
                if (this._valueRenavam == value)return;
                 this._valueRenavam = value; 
            } 
        } 

       protected string _codigoAgendamentoPortoOriginal{get;private set;}
       private string _codigoAgendamentoPortoOriginalCommited{get; set;}
        private string _valueCodigoAgendamentoPorto;
         [Column("mrd_codigo_agendamento_porto")]
        public virtual string CodigoAgendamentoPorto
         { 
            get { return this._valueCodigoAgendamentoPorto; } 
            set 
            { 
                if (this._valueCodigoAgendamentoPorto == value)return;
                 this._valueCodigoAgendamentoPorto = value; 
            } 
        } 

       private List<long> _collectionMdfeRodoCondutorClassMdfeModalRodoviarioOriginal;
       private List<Entidades.MdfeRodoCondutorClass > _collectionMdfeRodoCondutorClassMdfeModalRodoviarioRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMdfeRodoCondutorClassMdfeModalRodoviarioLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMdfeRodoCondutorClassMdfeModalRodoviarioChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMdfeRodoCondutorClassMdfeModalRodoviarioCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.MdfeRodoCondutorClass> _valueCollectionMdfeRodoCondutorClassMdfeModalRodoviario { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.MdfeRodoCondutorClass> CollectionMdfeRodoCondutorClassMdfeModalRodoviario 
       { 
           get { if(!_valueCollectionMdfeRodoCondutorClassMdfeModalRodoviarioLoaded && !this.DisableLoadCollection){this.LoadCollectionMdfeRodoCondutorClassMdfeModalRodoviario();}
return this._valueCollectionMdfeRodoCondutorClassMdfeModalRodoviario; } 
           set 
           { 
               this._valueCollectionMdfeRodoCondutorClassMdfeModalRodoviario = value; 
               this._valueCollectionMdfeRodoCondutorClassMdfeModalRodoviarioLoaded = true; 
           } 
       } 

       private List<long> _collectionMdfeRodoReboqueClassMdfeModalRodoviarioOriginal;
       private List<Entidades.MdfeRodoReboqueClass > _collectionMdfeRodoReboqueClassMdfeModalRodoviarioRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMdfeRodoReboqueClassMdfeModalRodoviarioLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMdfeRodoReboqueClassMdfeModalRodoviarioChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMdfeRodoReboqueClassMdfeModalRodoviarioCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.MdfeRodoReboqueClass> _valueCollectionMdfeRodoReboqueClassMdfeModalRodoviario { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.MdfeRodoReboqueClass> CollectionMdfeRodoReboqueClassMdfeModalRodoviario 
       { 
           get { if(!_valueCollectionMdfeRodoReboqueClassMdfeModalRodoviarioLoaded && !this.DisableLoadCollection){this.LoadCollectionMdfeRodoReboqueClassMdfeModalRodoviario();}
return this._valueCollectionMdfeRodoReboqueClassMdfeModalRodoviario; } 
           set 
           { 
               this._valueCollectionMdfeRodoReboqueClassMdfeModalRodoviario = value; 
               this._valueCollectionMdfeRodoReboqueClassMdfeModalRodoviarioLoaded = true; 
           } 
       } 

       private List<long> _collectionMdfeRodoValePedagioClassMdfeModalRodoviarioOriginal;
       private List<Entidades.MdfeRodoValePedagioClass > _collectionMdfeRodoValePedagioClassMdfeModalRodoviarioRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMdfeRodoValePedagioClassMdfeModalRodoviarioLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMdfeRodoValePedagioClassMdfeModalRodoviarioChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMdfeRodoValePedagioClassMdfeModalRodoviarioCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.MdfeRodoValePedagioClass> _valueCollectionMdfeRodoValePedagioClassMdfeModalRodoviario { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.MdfeRodoValePedagioClass> CollectionMdfeRodoValePedagioClassMdfeModalRodoviario 
       { 
           get { if(!_valueCollectionMdfeRodoValePedagioClassMdfeModalRodoviarioLoaded && !this.DisableLoadCollection){this.LoadCollectionMdfeRodoValePedagioClassMdfeModalRodoviario();}
return this._valueCollectionMdfeRodoValePedagioClassMdfeModalRodoviario; } 
           set 
           { 
               this._valueCollectionMdfeRodoValePedagioClassMdfeModalRodoviario = value; 
               this._valueCollectionMdfeRodoValePedagioClassMdfeModalRodoviarioLoaded = true; 
           } 
       } 

        public MdfeModalRodoviarioBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static MdfeModalRodoviarioClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (MdfeModalRodoviarioClass) GetEntity(typeof(MdfeModalRodoviarioClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionMdfeRodoCondutorClassMdfeModalRodoviarioChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionMdfeRodoCondutorClassMdfeModalRodoviarioChanged = true;
                  _valueCollectionMdfeRodoCondutorClassMdfeModalRodoviarioCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionMdfeRodoCondutorClassMdfeModalRodoviarioChanged = true; 
                  _valueCollectionMdfeRodoCondutorClassMdfeModalRodoviarioCommitedChanged = true;
                 foreach (Entidades.MdfeRodoCondutorClass item in e.OldItems) 
                 { 
                     _collectionMdfeRodoCondutorClassMdfeModalRodoviarioRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionMdfeRodoCondutorClassMdfeModalRodoviarioChanged = true; 
                  _valueCollectionMdfeRodoCondutorClassMdfeModalRodoviarioCommitedChanged = true;
                 foreach (Entidades.MdfeRodoCondutorClass item in _valueCollectionMdfeRodoCondutorClassMdfeModalRodoviario) 
                 { 
                     _collectionMdfeRodoCondutorClassMdfeModalRodoviarioRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionMdfeRodoCondutorClassMdfeModalRodoviario()
         {
            try
            {
                 ObservableCollection<Entidades.MdfeRodoCondutorClass> oc;
                _valueCollectionMdfeRodoCondutorClassMdfeModalRodoviarioChanged = false;
                 _valueCollectionMdfeRodoCondutorClassMdfeModalRodoviarioCommitedChanged = false;
                _collectionMdfeRodoCondutorClassMdfeModalRodoviarioRemovidos = new List<Entidades.MdfeRodoCondutorClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.MdfeRodoCondutorClass>();
                }
                else{ 
                   Entidades.MdfeRodoCondutorClass search = new Entidades.MdfeRodoCondutorClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.MdfeRodoCondutorClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("MdfeModalRodoviario", this),                     }                       ).Cast<Entidades.MdfeRodoCondutorClass>().ToList());
                 }
                 _valueCollectionMdfeRodoCondutorClassMdfeModalRodoviario = new BindingList<Entidades.MdfeRodoCondutorClass>(oc); 
                 _collectionMdfeRodoCondutorClassMdfeModalRodoviarioOriginal= (from a in _valueCollectionMdfeRodoCondutorClassMdfeModalRodoviario select a.ID).ToList();
                 _valueCollectionMdfeRodoCondutorClassMdfeModalRodoviarioLoaded = true;
                 oc.CollectionChanged += CollectionMdfeRodoCondutorClassMdfeModalRodoviarioChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionMdfeRodoCondutorClassMdfeModalRodoviario+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionMdfeRodoReboqueClassMdfeModalRodoviarioChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionMdfeRodoReboqueClassMdfeModalRodoviarioChanged = true;
                  _valueCollectionMdfeRodoReboqueClassMdfeModalRodoviarioCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionMdfeRodoReboqueClassMdfeModalRodoviarioChanged = true; 
                  _valueCollectionMdfeRodoReboqueClassMdfeModalRodoviarioCommitedChanged = true;
                 foreach (Entidades.MdfeRodoReboqueClass item in e.OldItems) 
                 { 
                     _collectionMdfeRodoReboqueClassMdfeModalRodoviarioRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionMdfeRodoReboqueClassMdfeModalRodoviarioChanged = true; 
                  _valueCollectionMdfeRodoReboqueClassMdfeModalRodoviarioCommitedChanged = true;
                 foreach (Entidades.MdfeRodoReboqueClass item in _valueCollectionMdfeRodoReboqueClassMdfeModalRodoviario) 
                 { 
                     _collectionMdfeRodoReboqueClassMdfeModalRodoviarioRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionMdfeRodoReboqueClassMdfeModalRodoviario()
         {
            try
            {
                 ObservableCollection<Entidades.MdfeRodoReboqueClass> oc;
                _valueCollectionMdfeRodoReboqueClassMdfeModalRodoviarioChanged = false;
                 _valueCollectionMdfeRodoReboqueClassMdfeModalRodoviarioCommitedChanged = false;
                _collectionMdfeRodoReboqueClassMdfeModalRodoviarioRemovidos = new List<Entidades.MdfeRodoReboqueClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.MdfeRodoReboqueClass>();
                }
                else{ 
                   Entidades.MdfeRodoReboqueClass search = new Entidades.MdfeRodoReboqueClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.MdfeRodoReboqueClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("MdfeModalRodoviario", this),                     }                       ).Cast<Entidades.MdfeRodoReboqueClass>().ToList());
                 }
                 _valueCollectionMdfeRodoReboqueClassMdfeModalRodoviario = new BindingList<Entidades.MdfeRodoReboqueClass>(oc); 
                 _collectionMdfeRodoReboqueClassMdfeModalRodoviarioOriginal= (from a in _valueCollectionMdfeRodoReboqueClassMdfeModalRodoviario select a.ID).ToList();
                 _valueCollectionMdfeRodoReboqueClassMdfeModalRodoviarioLoaded = true;
                 oc.CollectionChanged += CollectionMdfeRodoReboqueClassMdfeModalRodoviarioChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionMdfeRodoReboqueClassMdfeModalRodoviario+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionMdfeRodoValePedagioClassMdfeModalRodoviarioChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionMdfeRodoValePedagioClassMdfeModalRodoviarioChanged = true;
                  _valueCollectionMdfeRodoValePedagioClassMdfeModalRodoviarioCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionMdfeRodoValePedagioClassMdfeModalRodoviarioChanged = true; 
                  _valueCollectionMdfeRodoValePedagioClassMdfeModalRodoviarioCommitedChanged = true;
                 foreach (Entidades.MdfeRodoValePedagioClass item in e.OldItems) 
                 { 
                     _collectionMdfeRodoValePedagioClassMdfeModalRodoviarioRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionMdfeRodoValePedagioClassMdfeModalRodoviarioChanged = true; 
                  _valueCollectionMdfeRodoValePedagioClassMdfeModalRodoviarioCommitedChanged = true;
                 foreach (Entidades.MdfeRodoValePedagioClass item in _valueCollectionMdfeRodoValePedagioClassMdfeModalRodoviario) 
                 { 
                     _collectionMdfeRodoValePedagioClassMdfeModalRodoviarioRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionMdfeRodoValePedagioClassMdfeModalRodoviario()
         {
            try
            {
                 ObservableCollection<Entidades.MdfeRodoValePedagioClass> oc;
                _valueCollectionMdfeRodoValePedagioClassMdfeModalRodoviarioChanged = false;
                 _valueCollectionMdfeRodoValePedagioClassMdfeModalRodoviarioCommitedChanged = false;
                _collectionMdfeRodoValePedagioClassMdfeModalRodoviarioRemovidos = new List<Entidades.MdfeRodoValePedagioClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.MdfeRodoValePedagioClass>();
                }
                else{ 
                   Entidades.MdfeRodoValePedagioClass search = new Entidades.MdfeRodoValePedagioClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.MdfeRodoValePedagioClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("MdfeModalRodoviario", this),                     }                       ).Cast<Entidades.MdfeRodoValePedagioClass>().ToList());
                 }
                 _valueCollectionMdfeRodoValePedagioClassMdfeModalRodoviario = new BindingList<Entidades.MdfeRodoValePedagioClass>(oc); 
                 _collectionMdfeRodoValePedagioClassMdfeModalRodoviarioOriginal= (from a in _valueCollectionMdfeRodoValePedagioClassMdfeModalRodoviario select a.ID).ToList();
                 _valueCollectionMdfeRodoValePedagioClassMdfeModalRodoviarioLoaded = true;
                 oc.CollectionChanged += CollectionMdfeRodoValePedagioClassMdfeModalRodoviarioChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionMdfeRodoValePedagioClassMdfeModalRodoviario+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Versao))
                {
                    throw new Exception(ErroVersaoObrigatorio);
                }
                if (Versao.Length >10)
                {
                    throw new Exception( ErroVersaoComprimento);
                }
                if (string.IsNullOrEmpty(Placa))
                {
                    throw new Exception(ErroPlacaObrigatorio);
                }
                if (Placa.Length >7)
                {
                    throw new Exception( ErroPlacaComprimento);
                }
                if (string.IsNullOrEmpty(UfLiceciamento))
                {
                    throw new Exception(ErroUfLiceciamentoObrigatorio);
                }
                if (UfLiceciamento.Length >2)
                {
                    throw new Exception( ErroUfLiceciamentoComprimento);
                }
                if ( _valueMdfe == null)
                {
                    throw new Exception(ErroMdfeObrigatorio);
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
                    "  public.mdfe_modal_rodoviario  " +
                    "WHERE " +
                    "  id_mdfe_modal_rodoviario = :id";
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
                        "  public.mdfe_modal_rodoviario   " +
                        "SET  " + 
                        "  id_mdfe = :id_mdfe, " + 
                        "  mrd_versao = :mrd_versao, " + 
                        "  mrd_rntrc = :mrd_rntrc, " + 
                        "  mrd_ciot = :mrd_ciot, " + 
                        "  mrd_codigo_interno_veiculo = :mrd_codigo_interno_veiculo, " + 
                        "  mrd_placa = :mrd_placa, " + 
                        "  mrd_tara = :mrd_tara, " + 
                        "  mrd_capacidade_kg = :mrd_capacidade_kg, " + 
                        "  mrd_capacidade_m3 = :mrd_capacidade_m3, " + 
                        "  mrd_proprietario_rntrc = :mrd_proprietario_rntrc, " + 
                        "  version = :version, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  mrd_cpf_proprietario = :mrd_cpf_proprietario, " + 
                        "  mrd_cnpj_proprietario = :mrd_cnpj_proprietario, " + 
                        "  mrd_nome_razao_proprietario = :mrd_nome_razao_proprietario, " + 
                        "  mrd_ie_proprietario = :mrd_ie_proprietario, " + 
                        "  mdr_uf_proprietario = :mdr_uf_proprietario, " + 
                        "  mdr_tipo_proprietario = :mdr_tipo_proprietario, " + 
                        "  mdr_tipo_rodado = :mdr_tipo_rodado, " + 
                        "  mdr_tipo_carroceria = :mdr_tipo_carroceria, " + 
                        "  mdr_uf_liceciamento = :mdr_uf_liceciamento, " + 
                        "  mrd_renavam = :mrd_renavam, " + 
                        "  mrd_codigo_agendamento_porto = :mrd_codigo_agendamento_porto "+
                        "WHERE  " +
                        "  id_mdfe_modal_rodoviario = :id " +
                        "RETURNING id_mdfe_modal_rodoviario;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.mdfe_modal_rodoviario " +
                        "( " +
                        "  id_mdfe , " + 
                        "  mrd_versao , " + 
                        "  mrd_rntrc , " + 
                        "  mrd_ciot , " + 
                        "  mrd_codigo_interno_veiculo , " + 
                        "  mrd_placa , " + 
                        "  mrd_tara , " + 
                        "  mrd_capacidade_kg , " + 
                        "  mrd_capacidade_m3 , " + 
                        "  mrd_proprietario_rntrc , " + 
                        "  version , " + 
                        "  entity_uid , " + 
                        "  mrd_cpf_proprietario , " + 
                        "  mrd_cnpj_proprietario , " + 
                        "  mrd_nome_razao_proprietario , " + 
                        "  mrd_ie_proprietario , " + 
                        "  mdr_uf_proprietario , " + 
                        "  mdr_tipo_proprietario , " + 
                        "  mdr_tipo_rodado , " + 
                        "  mdr_tipo_carroceria , " + 
                        "  mdr_uf_liceciamento , " + 
                        "  mrd_renavam , " + 
                        "  mrd_codigo_agendamento_porto  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_mdfe , " + 
                        "  :mrd_versao , " + 
                        "  :mrd_rntrc , " + 
                        "  :mrd_ciot , " + 
                        "  :mrd_codigo_interno_veiculo , " + 
                        "  :mrd_placa , " + 
                        "  :mrd_tara , " + 
                        "  :mrd_capacidade_kg , " + 
                        "  :mrd_capacidade_m3 , " + 
                        "  :mrd_proprietario_rntrc , " + 
                        "  :version , " + 
                        "  :entity_uid , " + 
                        "  :mrd_cpf_proprietario , " + 
                        "  :mrd_cnpj_proprietario , " + 
                        "  :mrd_nome_razao_proprietario , " + 
                        "  :mrd_ie_proprietario , " + 
                        "  :mdr_uf_proprietario , " + 
                        "  :mdr_tipo_proprietario , " + 
                        "  :mdr_tipo_rodado , " + 
                        "  :mdr_tipo_carroceria , " + 
                        "  :mdr_uf_liceciamento , " + 
                        "  :mrd_renavam , " + 
                        "  :mrd_codigo_agendamento_porto  "+
                        ")RETURNING id_mdfe_modal_rodoviario;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_mdfe", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Mdfe==null ? (object) DBNull.Value : this.Mdfe.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mrd_versao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Versao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mrd_rntrc", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Rntrc ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mrd_ciot", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Ciot ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mrd_codigo_interno_veiculo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CodigoInternoVeiculo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mrd_placa", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Placa ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mrd_tara", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Tara ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mrd_capacidade_kg", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CapacidadeKg ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mrd_capacidade_m3", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CapacidadeM3 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mrd_proprietario_rntrc", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ProprietarioRntrc ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mrd_cpf_proprietario", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CpfProprietario ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mrd_cnpj_proprietario", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CnpjProprietario ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mrd_nome_razao_proprietario", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NomeRazaoProprietario ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mrd_ie_proprietario", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IeProprietario ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdr_uf_proprietario", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UfProprietario ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdr_tipo_proprietario", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = this.TipoProprietario.HasValue ? (object)Convert.ToInt16(this.TipoProprietario) : (object)DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdr_tipo_rodado", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.TipoRodado);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdr_tipo_carroceria", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.TipoCarroceria);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdr_uf_liceciamento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UfLiceciamento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mrd_renavam", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Renavam ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mrd_codigo_agendamento_porto", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CodigoAgendamentoPorto ?? DBNull.Value;

 
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
 if (CollectionMdfeRodoCondutorClassMdfeModalRodoviario.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionMdfeRodoCondutorClassMdfeModalRodoviario+"\r\n";
                foreach (Entidades.MdfeRodoCondutorClass tmp in CollectionMdfeRodoCondutorClassMdfeModalRodoviario)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionMdfeRodoReboqueClassMdfeModalRodoviario.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionMdfeRodoReboqueClassMdfeModalRodoviario+"\r\n";
                foreach (Entidades.MdfeRodoReboqueClass tmp in CollectionMdfeRodoReboqueClassMdfeModalRodoviario)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionMdfeRodoValePedagioClassMdfeModalRodoviario.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionMdfeRodoValePedagioClassMdfeModalRodoviario+"\r\n";
                foreach (Entidades.MdfeRodoValePedagioClass tmp in CollectionMdfeRodoValePedagioClassMdfeModalRodoviario)
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
        public static MdfeModalRodoviarioClass CopiarEntidade(MdfeModalRodoviarioClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               MdfeModalRodoviarioClass toRet = new MdfeModalRodoviarioClass(usuario,conn);
 toRet.Mdfe= entidadeCopiar.Mdfe;
 toRet.Versao= entidadeCopiar.Versao;
 toRet.Rntrc= entidadeCopiar.Rntrc;
 toRet.Ciot= entidadeCopiar.Ciot;
 toRet.CodigoInternoVeiculo= entidadeCopiar.CodigoInternoVeiculo;
 toRet.Placa= entidadeCopiar.Placa;
 toRet.Tara= entidadeCopiar.Tara;
 toRet.CapacidadeKg= entidadeCopiar.CapacidadeKg;
 toRet.CapacidadeM3= entidadeCopiar.CapacidadeM3;
 toRet.ProprietarioRntrc= entidadeCopiar.ProprietarioRntrc;
 toRet.CpfProprietario= entidadeCopiar.CpfProprietario;
 toRet.CnpjProprietario= entidadeCopiar.CnpjProprietario;
 toRet.NomeRazaoProprietario= entidadeCopiar.NomeRazaoProprietario;
 toRet.IeProprietario= entidadeCopiar.IeProprietario;
 toRet.UfProprietario= entidadeCopiar.UfProprietario;
 toRet.TipoProprietario= entidadeCopiar.TipoProprietario;
 toRet.TipoRodado= entidadeCopiar.TipoRodado;
 toRet.TipoCarroceria= entidadeCopiar.TipoCarroceria;
 toRet.UfLiceciamento= entidadeCopiar.UfLiceciamento;
 toRet.Renavam= entidadeCopiar.Renavam;
 toRet.CodigoAgendamentoPorto= entidadeCopiar.CodigoAgendamentoPorto;

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
       _mdfeOriginal = Mdfe;
       _mdfeOriginalCommited = _mdfeOriginal;
       _versaoOriginal = Versao;
       _versaoOriginalCommited = _versaoOriginal;
       _rntrcOriginal = Rntrc;
       _rntrcOriginalCommited = _rntrcOriginal;
       _ciotOriginal = Ciot;
       _ciotOriginalCommited = _ciotOriginal;
       _codigoInternoVeiculoOriginal = CodigoInternoVeiculo;
       _codigoInternoVeiculoOriginalCommited = _codigoInternoVeiculoOriginal;
       _placaOriginal = Placa;
       _placaOriginalCommited = _placaOriginal;
       _taraOriginal = Tara;
       _taraOriginalCommited = _taraOriginal;
       _capacidadeKgOriginal = CapacidadeKg;
       _capacidadeKgOriginalCommited = _capacidadeKgOriginal;
       _capacidadeM3Original = CapacidadeM3;
       _capacidadeM3OriginalCommited = _capacidadeM3Original;
       _proprietarioRntrcOriginal = ProprietarioRntrc;
       _proprietarioRntrcOriginalCommited = _proprietarioRntrcOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _cpfProprietarioOriginal = CpfProprietario;
       _cpfProprietarioOriginalCommited = _cpfProprietarioOriginal;
       _cnpjProprietarioOriginal = CnpjProprietario;
       _cnpjProprietarioOriginalCommited = _cnpjProprietarioOriginal;
       _nomeRazaoProprietarioOriginal = NomeRazaoProprietario;
       _nomeRazaoProprietarioOriginalCommited = _nomeRazaoProprietarioOriginal;
       _ieProprietarioOriginal = IeProprietario;
       _ieProprietarioOriginalCommited = _ieProprietarioOriginal;
       _ufProprietarioOriginal = UfProprietario;
       _ufProprietarioOriginalCommited = _ufProprietarioOriginal;
       _tipoProprietarioOriginal = TipoProprietario;
       _tipoProprietarioOriginalCommited = _tipoProprietarioOriginal;
       _tipoRodadoOriginal = TipoRodado;
       _tipoRodadoOriginalCommited = _tipoRodadoOriginal;
       _tipoCarroceriaOriginal = TipoCarroceria;
       _tipoCarroceriaOriginalCommited = _tipoCarroceriaOriginal;
       _ufLiceciamentoOriginal = UfLiceciamento;
       _ufLiceciamentoOriginalCommited = _ufLiceciamentoOriginal;
       _renavamOriginal = Renavam;
       _renavamOriginalCommited = _renavamOriginal;
       _codigoAgendamentoPortoOriginal = CodigoAgendamentoPorto;
       _codigoAgendamentoPortoOriginalCommited = _codigoAgendamentoPortoOriginal;

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
       _mdfeOriginalCommited = Mdfe;
       _versaoOriginalCommited = Versao;
       _rntrcOriginalCommited = Rntrc;
       _ciotOriginalCommited = Ciot;
       _codigoInternoVeiculoOriginalCommited = CodigoInternoVeiculo;
       _placaOriginalCommited = Placa;
       _taraOriginalCommited = Tara;
       _capacidadeKgOriginalCommited = CapacidadeKg;
       _capacidadeM3OriginalCommited = CapacidadeM3;
       _proprietarioRntrcOriginalCommited = ProprietarioRntrc;
       _versionOriginalCommited = Version;
       _cpfProprietarioOriginalCommited = CpfProprietario;
       _cnpjProprietarioOriginalCommited = CnpjProprietario;
       _nomeRazaoProprietarioOriginalCommited = NomeRazaoProprietario;
       _ieProprietarioOriginalCommited = IeProprietario;
       _ufProprietarioOriginalCommited = UfProprietario;
       _tipoProprietarioOriginalCommited = TipoProprietario;
       _tipoRodadoOriginalCommited = TipoRodado;
       _tipoCarroceriaOriginalCommited = TipoCarroceria;
       _ufLiceciamentoOriginalCommited = UfLiceciamento;
       _renavamOriginalCommited = Renavam;
       _codigoAgendamentoPortoOriginalCommited = CodigoAgendamentoPorto;

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
               if (_valueCollectionMdfeRodoCondutorClassMdfeModalRodoviarioLoaded) 
               {
                  if (_collectionMdfeRodoCondutorClassMdfeModalRodoviarioRemovidos != null) 
                  {
                     _collectionMdfeRodoCondutorClassMdfeModalRodoviarioRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionMdfeRodoCondutorClassMdfeModalRodoviarioRemovidos = new List<Entidades.MdfeRodoCondutorClass>();
                  }
                  _collectionMdfeRodoCondutorClassMdfeModalRodoviarioOriginal= (from a in _valueCollectionMdfeRodoCondutorClassMdfeModalRodoviario select a.ID).ToList();
                  _valueCollectionMdfeRodoCondutorClassMdfeModalRodoviarioChanged = false;
                  _valueCollectionMdfeRodoCondutorClassMdfeModalRodoviarioCommitedChanged = false;
               }
               if (_valueCollectionMdfeRodoReboqueClassMdfeModalRodoviarioLoaded) 
               {
                  if (_collectionMdfeRodoReboqueClassMdfeModalRodoviarioRemovidos != null) 
                  {
                     _collectionMdfeRodoReboqueClassMdfeModalRodoviarioRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionMdfeRodoReboqueClassMdfeModalRodoviarioRemovidos = new List<Entidades.MdfeRodoReboqueClass>();
                  }
                  _collectionMdfeRodoReboqueClassMdfeModalRodoviarioOriginal= (from a in _valueCollectionMdfeRodoReboqueClassMdfeModalRodoviario select a.ID).ToList();
                  _valueCollectionMdfeRodoReboqueClassMdfeModalRodoviarioChanged = false;
                  _valueCollectionMdfeRodoReboqueClassMdfeModalRodoviarioCommitedChanged = false;
               }
               if (_valueCollectionMdfeRodoValePedagioClassMdfeModalRodoviarioLoaded) 
               {
                  if (_collectionMdfeRodoValePedagioClassMdfeModalRodoviarioRemovidos != null) 
                  {
                     _collectionMdfeRodoValePedagioClassMdfeModalRodoviarioRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionMdfeRodoValePedagioClassMdfeModalRodoviarioRemovidos = new List<Entidades.MdfeRodoValePedagioClass>();
                  }
                  _collectionMdfeRodoValePedagioClassMdfeModalRodoviarioOriginal= (from a in _valueCollectionMdfeRodoValePedagioClassMdfeModalRodoviario select a.ID).ToList();
                  _valueCollectionMdfeRodoValePedagioClassMdfeModalRodoviarioChanged = false;
                  _valueCollectionMdfeRodoValePedagioClassMdfeModalRodoviarioCommitedChanged = false;
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
               Mdfe=_mdfeOriginal;
               _mdfeOriginalCommited=_mdfeOriginal;
               Versao=_versaoOriginal;
               _versaoOriginalCommited=_versaoOriginal;
               Rntrc=_rntrcOriginal;
               _rntrcOriginalCommited=_rntrcOriginal;
               Ciot=_ciotOriginal;
               _ciotOriginalCommited=_ciotOriginal;
               CodigoInternoVeiculo=_codigoInternoVeiculoOriginal;
               _codigoInternoVeiculoOriginalCommited=_codigoInternoVeiculoOriginal;
               Placa=_placaOriginal;
               _placaOriginalCommited=_placaOriginal;
               Tara=_taraOriginal;
               _taraOriginalCommited=_taraOriginal;
               CapacidadeKg=_capacidadeKgOriginal;
               _capacidadeKgOriginalCommited=_capacidadeKgOriginal;
               CapacidadeM3=_capacidadeM3Original;
               _capacidadeM3OriginalCommited=_capacidadeM3Original;
               ProprietarioRntrc=_proprietarioRntrcOriginal;
               _proprietarioRntrcOriginalCommited=_proprietarioRntrcOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               CpfProprietario=_cpfProprietarioOriginal;
               _cpfProprietarioOriginalCommited=_cpfProprietarioOriginal;
               CnpjProprietario=_cnpjProprietarioOriginal;
               _cnpjProprietarioOriginalCommited=_cnpjProprietarioOriginal;
               NomeRazaoProprietario=_nomeRazaoProprietarioOriginal;
               _nomeRazaoProprietarioOriginalCommited=_nomeRazaoProprietarioOriginal;
               IeProprietario=_ieProprietarioOriginal;
               _ieProprietarioOriginalCommited=_ieProprietarioOriginal;
               UfProprietario=_ufProprietarioOriginal;
               _ufProprietarioOriginalCommited=_ufProprietarioOriginal;
               TipoProprietario=_tipoProprietarioOriginal;
               _tipoProprietarioOriginalCommited=_tipoProprietarioOriginal;
               TipoRodado=_tipoRodadoOriginal;
               _tipoRodadoOriginalCommited=_tipoRodadoOriginal;
               TipoCarroceria=_tipoCarroceriaOriginal;
               _tipoCarroceriaOriginalCommited=_tipoCarroceriaOriginal;
               UfLiceciamento=_ufLiceciamentoOriginal;
               _ufLiceciamentoOriginalCommited=_ufLiceciamentoOriginal;
               Renavam=_renavamOriginal;
               _renavamOriginalCommited=_renavamOriginal;
               CodigoAgendamentoPorto=_codigoAgendamentoPortoOriginal;
               _codigoAgendamentoPortoOriginalCommited=_codigoAgendamentoPortoOriginal;
               if (_valueCollectionMdfeRodoCondutorClassMdfeModalRodoviarioLoaded) 
               {
                  CollectionMdfeRodoCondutorClassMdfeModalRodoviario.Clear();
                  foreach(int item in _collectionMdfeRodoCondutorClassMdfeModalRodoviarioOriginal)
                  {
                    CollectionMdfeRodoCondutorClassMdfeModalRodoviario.Add(Entidades.MdfeRodoCondutorClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionMdfeRodoCondutorClassMdfeModalRodoviarioRemovidos.Clear();
               }
               if (_valueCollectionMdfeRodoReboqueClassMdfeModalRodoviarioLoaded) 
               {
                  CollectionMdfeRodoReboqueClassMdfeModalRodoviario.Clear();
                  foreach(int item in _collectionMdfeRodoReboqueClassMdfeModalRodoviarioOriginal)
                  {
                    CollectionMdfeRodoReboqueClassMdfeModalRodoviario.Add(Entidades.MdfeRodoReboqueClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionMdfeRodoReboqueClassMdfeModalRodoviarioRemovidos.Clear();
               }
               if (_valueCollectionMdfeRodoValePedagioClassMdfeModalRodoviarioLoaded) 
               {
                  CollectionMdfeRodoValePedagioClassMdfeModalRodoviario.Clear();
                  foreach(int item in _collectionMdfeRodoValePedagioClassMdfeModalRodoviarioOriginal)
                  {
                    CollectionMdfeRodoValePedagioClassMdfeModalRodoviario.Add(Entidades.MdfeRodoValePedagioClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionMdfeRodoValePedagioClassMdfeModalRodoviarioRemovidos.Clear();
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
               if (_valueCollectionMdfeRodoCondutorClassMdfeModalRodoviarioLoaded) 
               {
                  if (_valueCollectionMdfeRodoCondutorClassMdfeModalRodoviarioChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMdfeRodoReboqueClassMdfeModalRodoviarioLoaded) 
               {
                  if (_valueCollectionMdfeRodoReboqueClassMdfeModalRodoviarioChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMdfeRodoValePedagioClassMdfeModalRodoviarioLoaded) 
               {
                  if (_valueCollectionMdfeRodoValePedagioClassMdfeModalRodoviarioChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMdfeRodoCondutorClassMdfeModalRodoviarioLoaded) 
               {
                   tempRet = CollectionMdfeRodoCondutorClassMdfeModalRodoviario.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionMdfeRodoReboqueClassMdfeModalRodoviarioLoaded) 
               {
                   tempRet = CollectionMdfeRodoReboqueClassMdfeModalRodoviario.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionMdfeRodoValePedagioClassMdfeModalRodoviarioLoaded) 
               {
                   tempRet = CollectionMdfeRodoValePedagioClassMdfeModalRodoviario.Any(item => item.IsDirty());
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
       if (_mdfeOriginal!=null)
       {
          dirty = !_mdfeOriginal.Equals(Mdfe);
       }
       else
       {
            dirty = Mdfe != null;
       }
      if (dirty) return true;
       dirty = _versaoOriginal != Versao;
      if (dirty) return true;
       dirty = _rntrcOriginal != Rntrc;
      if (dirty) return true;
       dirty = _ciotOriginal != Ciot;
      if (dirty) return true;
       dirty = _codigoInternoVeiculoOriginal != CodigoInternoVeiculo;
      if (dirty) return true;
       dirty = _placaOriginal != Placa;
      if (dirty) return true;
       dirty = _taraOriginal != Tara;
      if (dirty) return true;
       dirty = _capacidadeKgOriginal != CapacidadeKg;
      if (dirty) return true;
       dirty = _capacidadeM3Original != CapacidadeM3;
      if (dirty) return true;
       dirty = _proprietarioRntrcOriginal != ProprietarioRntrc;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
      if (dirty) return true;
       dirty = _cpfProprietarioOriginal != CpfProprietario;
      if (dirty) return true;
       dirty = _cnpjProprietarioOriginal != CnpjProprietario;
      if (dirty) return true;
       dirty = _nomeRazaoProprietarioOriginal != NomeRazaoProprietario;
      if (dirty) return true;
       dirty = _ieProprietarioOriginal != IeProprietario;
      if (dirty) return true;
       dirty = _ufProprietarioOriginal != UfProprietario;
      if (dirty) return true;
       dirty = _tipoProprietarioOriginal != TipoProprietario;
      if (dirty) return true;
       dirty = _tipoRodadoOriginal != TipoRodado;
      if (dirty) return true;
       dirty = _tipoCarroceriaOriginal != TipoCarroceria;
      if (dirty) return true;
       dirty = _ufLiceciamentoOriginal != UfLiceciamento;
      if (dirty) return true;
       dirty = _renavamOriginal != Renavam;
      if (dirty) return true;
       dirty = _codigoAgendamentoPortoOriginal != CodigoAgendamentoPorto;

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
               if (_valueCollectionMdfeRodoCondutorClassMdfeModalRodoviarioLoaded) 
               {
                  if (_valueCollectionMdfeRodoCondutorClassMdfeModalRodoviarioCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMdfeRodoReboqueClassMdfeModalRodoviarioLoaded) 
               {
                  if (_valueCollectionMdfeRodoReboqueClassMdfeModalRodoviarioCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMdfeRodoValePedagioClassMdfeModalRodoviarioLoaded) 
               {
                  if (_valueCollectionMdfeRodoValePedagioClassMdfeModalRodoviarioCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMdfeRodoCondutorClassMdfeModalRodoviarioLoaded) 
               {
                   tempRet = CollectionMdfeRodoCondutorClassMdfeModalRodoviario.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionMdfeRodoReboqueClassMdfeModalRodoviarioLoaded) 
               {
                   tempRet = CollectionMdfeRodoReboqueClassMdfeModalRodoviario.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionMdfeRodoValePedagioClassMdfeModalRodoviarioLoaded) 
               {
                   tempRet = CollectionMdfeRodoValePedagioClassMdfeModalRodoviario.Any(item => item.IsDirtyCommited());
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
       if (_mdfeOriginalCommited!=null)
       {
          dirty = !_mdfeOriginalCommited.Equals(Mdfe);
       }
       else
       {
            dirty = Mdfe != null;
       }
      if (dirty) return true;
       dirty = _versaoOriginalCommited != Versao;
      if (dirty) return true;
       dirty = _rntrcOriginalCommited != Rntrc;
      if (dirty) return true;
       dirty = _ciotOriginalCommited != Ciot;
      if (dirty) return true;
       dirty = _codigoInternoVeiculoOriginalCommited != CodigoInternoVeiculo;
      if (dirty) return true;
       dirty = _placaOriginalCommited != Placa;
      if (dirty) return true;
       dirty = _taraOriginalCommited != Tara;
      if (dirty) return true;
       dirty = _capacidadeKgOriginalCommited != CapacidadeKg;
      if (dirty) return true;
       dirty = _capacidadeM3OriginalCommited != CapacidadeM3;
      if (dirty) return true;
       dirty = _proprietarioRntrcOriginalCommited != ProprietarioRntrc;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
      if (dirty) return true;
       dirty = _cpfProprietarioOriginalCommited != CpfProprietario;
      if (dirty) return true;
       dirty = _cnpjProprietarioOriginalCommited != CnpjProprietario;
      if (dirty) return true;
       dirty = _nomeRazaoProprietarioOriginalCommited != NomeRazaoProprietario;
      if (dirty) return true;
       dirty = _ieProprietarioOriginalCommited != IeProprietario;
      if (dirty) return true;
       dirty = _ufProprietarioOriginalCommited != UfProprietario;
      if (dirty) return true;
       dirty = _tipoProprietarioOriginalCommited != TipoProprietario;
      if (dirty) return true;
       dirty = _tipoRodadoOriginalCommited != TipoRodado;
      if (dirty) return true;
       dirty = _tipoCarroceriaOriginalCommited != TipoCarroceria;
      if (dirty) return true;
       dirty = _ufLiceciamentoOriginalCommited != UfLiceciamento;
      if (dirty) return true;
       dirty = _renavamOriginalCommited != Renavam;
      if (dirty) return true;
       dirty = _codigoAgendamentoPortoOriginalCommited != CodigoAgendamentoPorto;

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
               if (_valueCollectionMdfeRodoCondutorClassMdfeModalRodoviarioLoaded) 
               {
                  foreach(MdfeRodoCondutorClass item in CollectionMdfeRodoCondutorClassMdfeModalRodoviario)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionMdfeRodoReboqueClassMdfeModalRodoviarioLoaded) 
               {
                  foreach(MdfeRodoReboqueClass item in CollectionMdfeRodoReboqueClassMdfeModalRodoviario)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionMdfeRodoValePedagioClassMdfeModalRodoviarioLoaded) 
               {
                  foreach(MdfeRodoValePedagioClass item in CollectionMdfeRodoValePedagioClassMdfeModalRodoviario)
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
             case "Mdfe":
                return this.Mdfe;
             case "Versao":
                return this.Versao;
             case "Rntrc":
                return this.Rntrc;
             case "Ciot":
                return this.Ciot;
             case "CodigoInternoVeiculo":
                return this.CodigoInternoVeiculo;
             case "Placa":
                return this.Placa;
             case "Tara":
                return this.Tara;
             case "CapacidadeKg":
                return this.CapacidadeKg;
             case "CapacidadeM3":
                return this.CapacidadeM3;
             case "ProprietarioRntrc":
                return this.ProprietarioRntrc;
             case "Version":
                return this.Version;
             case "EntityUid":
                return this.EntityUid;
             case "CpfProprietario":
                return this.CpfProprietario;
             case "CnpjProprietario":
                return this.CnpjProprietario;
             case "NomeRazaoProprietario":
                return this.NomeRazaoProprietario;
             case "IeProprietario":
                return this.IeProprietario;
             case "UfProprietario":
                return this.UfProprietario;
             case "TipoProprietario":
                return this.TipoProprietario;
             case "TipoRodado":
                return this.TipoRodado;
             case "TipoCarroceria":
                return this.TipoCarroceria;
             case "UfLiceciamento":
                return this.UfLiceciamento;
             case "Renavam":
                return this.Renavam;
             case "CodigoAgendamentoPorto":
                return this.CodigoAgendamentoPorto;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (Mdfe!=null)
                Mdfe.ChangeSingleConnection(newConnection);
               if (_valueCollectionMdfeRodoCondutorClassMdfeModalRodoviarioLoaded) 
               {
                  foreach(MdfeRodoCondutorClass item in CollectionMdfeRodoCondutorClassMdfeModalRodoviario)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionMdfeRodoReboqueClassMdfeModalRodoviarioLoaded) 
               {
                  foreach(MdfeRodoReboqueClass item in CollectionMdfeRodoReboqueClassMdfeModalRodoviario)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionMdfeRodoValePedagioClassMdfeModalRodoviarioLoaded) 
               {
                  foreach(MdfeRodoValePedagioClass item in CollectionMdfeRodoValePedagioClassMdfeModalRodoviario)
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
                  command.CommandText += " COUNT(mdfe_modal_rodoviario.id_mdfe_modal_rodoviario) " ;
               }
               else
               {
               command.CommandText += "mdfe_modal_rodoviario.id_mdfe_modal_rodoviario, " ;
               command.CommandText += "mdfe_modal_rodoviario.id_mdfe, " ;
               command.CommandText += "mdfe_modal_rodoviario.mrd_versao, " ;
               command.CommandText += "mdfe_modal_rodoviario.mrd_rntrc, " ;
               command.CommandText += "mdfe_modal_rodoviario.mrd_ciot, " ;
               command.CommandText += "mdfe_modal_rodoviario.mrd_codigo_interno_veiculo, " ;
               command.CommandText += "mdfe_modal_rodoviario.mrd_placa, " ;
               command.CommandText += "mdfe_modal_rodoviario.mrd_tara, " ;
               command.CommandText += "mdfe_modal_rodoviario.mrd_capacidade_kg, " ;
               command.CommandText += "mdfe_modal_rodoviario.mrd_capacidade_m3, " ;
               command.CommandText += "mdfe_modal_rodoviario.mrd_proprietario_rntrc, " ;
               command.CommandText += "mdfe_modal_rodoviario.version, " ;
               command.CommandText += "mdfe_modal_rodoviario.entity_uid, " ;
               command.CommandText += "mdfe_modal_rodoviario.mrd_cpf_proprietario, " ;
               command.CommandText += "mdfe_modal_rodoviario.mrd_cnpj_proprietario, " ;
               command.CommandText += "mdfe_modal_rodoviario.mrd_nome_razao_proprietario, " ;
               command.CommandText += "mdfe_modal_rodoviario.mrd_ie_proprietario, " ;
               command.CommandText += "mdfe_modal_rodoviario.mdr_uf_proprietario, " ;
               command.CommandText += "mdfe_modal_rodoviario.mdr_tipo_proprietario, " ;
               command.CommandText += "mdfe_modal_rodoviario.mdr_tipo_rodado, " ;
               command.CommandText += "mdfe_modal_rodoviario.mdr_tipo_carroceria, " ;
               command.CommandText += "mdfe_modal_rodoviario.mdr_uf_liceciamento, " ;
               command.CommandText += "mdfe_modal_rodoviario.mrd_renavam, " ;
               command.CommandText += "mdfe_modal_rodoviario.mrd_codigo_agendamento_porto " ;
               }
               command.CommandText += " FROM  mdfe_modal_rodoviario ";
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
                        orderByClause += " , mrd_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(mrd_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = mdfe_modal_rodoviario.id_acs_usuario_ultima_revisao ";
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
                     case "id_mdfe_modal_rodoviario":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe_modal_rodoviario.id_mdfe_modal_rodoviario " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe_modal_rodoviario.id_mdfe_modal_rodoviario) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_mdfe":
                     case "Mdfe":
                     orderByClause += " , mdfe_modal_rodoviario.id_mdfe " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "mrd_versao":
                     case "Versao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe_modal_rodoviario.mrd_versao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe_modal_rodoviario.mrd_versao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mrd_rntrc":
                     case "Rntrc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe_modal_rodoviario.mrd_rntrc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe_modal_rodoviario.mrd_rntrc) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mrd_ciot":
                     case "Ciot":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe_modal_rodoviario.mrd_ciot " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe_modal_rodoviario.mrd_ciot) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mrd_codigo_interno_veiculo":
                     case "CodigoInternoVeiculo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe_modal_rodoviario.mrd_codigo_interno_veiculo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe_modal_rodoviario.mrd_codigo_interno_veiculo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mrd_placa":
                     case "Placa":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe_modal_rodoviario.mrd_placa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe_modal_rodoviario.mrd_placa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mrd_tara":
                     case "Tara":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe_modal_rodoviario.mrd_tara " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe_modal_rodoviario.mrd_tara) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mrd_capacidade_kg":
                     case "CapacidadeKg":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe_modal_rodoviario.mrd_capacidade_kg " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe_modal_rodoviario.mrd_capacidade_kg) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mrd_capacidade_m3":
                     case "CapacidadeM3":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe_modal_rodoviario.mrd_capacidade_m3 " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe_modal_rodoviario.mrd_capacidade_m3) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mrd_proprietario_rntrc":
                     case "ProprietarioRntrc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe_modal_rodoviario.mrd_proprietario_rntrc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe_modal_rodoviario.mrd_proprietario_rntrc) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , mdfe_modal_rodoviario.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe_modal_rodoviario.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe_modal_rodoviario.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe_modal_rodoviario.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mrd_cpf_proprietario":
                     case "CpfProprietario":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe_modal_rodoviario.mrd_cpf_proprietario " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe_modal_rodoviario.mrd_cpf_proprietario) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mrd_cnpj_proprietario":
                     case "CnpjProprietario":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe_modal_rodoviario.mrd_cnpj_proprietario " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe_modal_rodoviario.mrd_cnpj_proprietario) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mrd_nome_razao_proprietario":
                     case "NomeRazaoProprietario":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe_modal_rodoviario.mrd_nome_razao_proprietario " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe_modal_rodoviario.mrd_nome_razao_proprietario) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mrd_ie_proprietario":
                     case "IeProprietario":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe_modal_rodoviario.mrd_ie_proprietario " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe_modal_rodoviario.mrd_ie_proprietario) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mdr_uf_proprietario":
                     case "UfProprietario":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe_modal_rodoviario.mdr_uf_proprietario " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe_modal_rodoviario.mdr_uf_proprietario) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mdr_tipo_proprietario":
                     case "TipoProprietario":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe_modal_rodoviario.mdr_tipo_proprietario " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe_modal_rodoviario.mdr_tipo_proprietario) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mdr_tipo_rodado":
                     case "TipoRodado":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe_modal_rodoviario.mdr_tipo_rodado " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe_modal_rodoviario.mdr_tipo_rodado) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mdr_tipo_carroceria":
                     case "TipoCarroceria":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe_modal_rodoviario.mdr_tipo_carroceria " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe_modal_rodoviario.mdr_tipo_carroceria) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mdr_uf_liceciamento":
                     case "UfLiceciamento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe_modal_rodoviario.mdr_uf_liceciamento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe_modal_rodoviario.mdr_uf_liceciamento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mrd_renavam":
                     case "Renavam":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe_modal_rodoviario.mrd_renavam " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe_modal_rodoviario.mrd_renavam) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mrd_codigo_agendamento_porto":
                     case "CodigoAgendamentoPorto":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe_modal_rodoviario.mrd_codigo_agendamento_porto " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe_modal_rodoviario.mrd_codigo_agendamento_porto) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mrd_versao")) 
                        {
                           whereClause += " OR UPPER(mdfe_modal_rodoviario.mrd_versao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe_modal_rodoviario.mrd_versao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mrd_codigo_interno_veiculo")) 
                        {
                           whereClause += " OR UPPER(mdfe_modal_rodoviario.mrd_codigo_interno_veiculo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe_modal_rodoviario.mrd_codigo_interno_veiculo) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mrd_placa")) 
                        {
                           whereClause += " OR UPPER(mdfe_modal_rodoviario.mrd_placa) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe_modal_rodoviario.mrd_placa) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(mdfe_modal_rodoviario.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe_modal_rodoviario.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mrd_cpf_proprietario")) 
                        {
                           whereClause += " OR UPPER(mdfe_modal_rodoviario.mrd_cpf_proprietario) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe_modal_rodoviario.mrd_cpf_proprietario) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mrd_cnpj_proprietario")) 
                        {
                           whereClause += " OR UPPER(mdfe_modal_rodoviario.mrd_cnpj_proprietario) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe_modal_rodoviario.mrd_cnpj_proprietario) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mrd_nome_razao_proprietario")) 
                        {
                           whereClause += " OR UPPER(mdfe_modal_rodoviario.mrd_nome_razao_proprietario) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe_modal_rodoviario.mrd_nome_razao_proprietario) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mrd_ie_proprietario")) 
                        {
                           whereClause += " OR UPPER(mdfe_modal_rodoviario.mrd_ie_proprietario) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe_modal_rodoviario.mrd_ie_proprietario) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mdr_uf_proprietario")) 
                        {
                           whereClause += " OR UPPER(mdfe_modal_rodoviario.mdr_uf_proprietario) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe_modal_rodoviario.mdr_uf_proprietario) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mdr_uf_liceciamento")) 
                        {
                           whereClause += " OR UPPER(mdfe_modal_rodoviario.mdr_uf_liceciamento) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe_modal_rodoviario.mdr_uf_liceciamento) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mrd_renavam")) 
                        {
                           whereClause += " OR UPPER(mdfe_modal_rodoviario.mrd_renavam) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe_modal_rodoviario.mrd_renavam) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mrd_codigo_agendamento_porto")) 
                        {
                           whereClause += " OR UPPER(mdfe_modal_rodoviario.mrd_codigo_agendamento_porto) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe_modal_rodoviario.mrd_codigo_agendamento_porto) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_mdfe_modal_rodoviario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_modal_rodoviario.id_mdfe_modal_rodoviario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_modal_rodoviario.id_mdfe_modal_rodoviario = :mdfe_modal_rodoviario_ID_4487 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_modal_rodoviario_ID_4487", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Mdfe" || parametro.FieldName == "id_mdfe")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTNFCompleto.BibliotecaEntidades.Entidades.MdfeClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTNFCompleto.BibliotecaEntidades.Entidades.MdfeClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_modal_rodoviario.id_mdfe IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_modal_rodoviario.id_mdfe = :mdfe_modal_rodoviario_Mdfe_6628 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_modal_rodoviario_Mdfe_6628", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Versao" || parametro.FieldName == "mrd_versao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_versao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_versao LIKE :mdfe_modal_rodoviario_Versao_2819 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_modal_rodoviario_Versao_2819", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Rntrc" || parametro.FieldName == "mrd_rntrc")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_rntrc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_rntrc = :mdfe_modal_rodoviario_Rntrc_2160 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_modal_rodoviario_Rntrc_2160", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Ciot" || parametro.FieldName == "mrd_ciot")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_ciot IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_ciot = :mdfe_modal_rodoviario_Ciot_668 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_modal_rodoviario_Ciot_668", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoInternoVeiculo" || parametro.FieldName == "mrd_codigo_interno_veiculo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_codigo_interno_veiculo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_codigo_interno_veiculo LIKE :mdfe_modal_rodoviario_CodigoInternoVeiculo_6688 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_modal_rodoviario_CodigoInternoVeiculo_6688", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Placa" || parametro.FieldName == "mrd_placa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_placa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_placa LIKE :mdfe_modal_rodoviario_Placa_8154 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_modal_rodoviario_Placa_8154", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Tara" || parametro.FieldName == "mrd_tara")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_tara IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_tara = :mdfe_modal_rodoviario_Tara_8698 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_modal_rodoviario_Tara_8698", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CapacidadeKg" || parametro.FieldName == "mrd_capacidade_kg")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_capacidade_kg IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_capacidade_kg = :mdfe_modal_rodoviario_CapacidadeKg_3425 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_modal_rodoviario_CapacidadeKg_3425", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CapacidadeM3" || parametro.FieldName == "mrd_capacidade_m3")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_capacidade_m3 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_capacidade_m3 = :mdfe_modal_rodoviario_CapacidadeM3_4954 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_modal_rodoviario_CapacidadeM3_4954", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ProprietarioRntrc" || parametro.FieldName == "mrd_proprietario_rntrc")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_proprietario_rntrc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_proprietario_rntrc = :mdfe_modal_rodoviario_ProprietarioRntrc_2816 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_modal_rodoviario_ProprietarioRntrc_2816", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  mdfe_modal_rodoviario.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_modal_rodoviario.version = :mdfe_modal_rodoviario_Version_8217 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_modal_rodoviario_Version_8217", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  mdfe_modal_rodoviario.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_modal_rodoviario.entity_uid LIKE :mdfe_modal_rodoviario_EntityUid_6108 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_modal_rodoviario_EntityUid_6108", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CpfProprietario" || parametro.FieldName == "mrd_cpf_proprietario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_cpf_proprietario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_cpf_proprietario LIKE :mdfe_modal_rodoviario_CpfProprietario_4732 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_modal_rodoviario_CpfProprietario_4732", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CnpjProprietario" || parametro.FieldName == "mrd_cnpj_proprietario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_cnpj_proprietario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_cnpj_proprietario LIKE :mdfe_modal_rodoviario_CnpjProprietario_5126 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_modal_rodoviario_CnpjProprietario_5126", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomeRazaoProprietario" || parametro.FieldName == "mrd_nome_razao_proprietario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_nome_razao_proprietario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_nome_razao_proprietario LIKE :mdfe_modal_rodoviario_NomeRazaoProprietario_8568 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_modal_rodoviario_NomeRazaoProprietario_8568", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IeProprietario" || parametro.FieldName == "mrd_ie_proprietario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_ie_proprietario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_ie_proprietario LIKE :mdfe_modal_rodoviario_IeProprietario_6414 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_modal_rodoviario_IeProprietario_6414", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UfProprietario" || parametro.FieldName == "mdr_uf_proprietario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_modal_rodoviario.mdr_uf_proprietario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_modal_rodoviario.mdr_uf_proprietario LIKE :mdfe_modal_rodoviario_UfProprietario_5194 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_modal_rodoviario_UfProprietario_5194", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoProprietario" || parametro.FieldName == "mdr_tipo_proprietario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is MDFeTipoProprietarioVeiculo?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo MDFeTipoProprietarioVeiculo?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_modal_rodoviario.mdr_tipo_proprietario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_modal_rodoviario.mdr_tipo_proprietario = :mdfe_modal_rodoviario_TipoProprietario_6669 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_modal_rodoviario_TipoProprietario_6669", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoRodado" || parametro.FieldName == "mdr_tipo_rodado")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is MDFeTipoRodado)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo MDFeTipoRodado");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_modal_rodoviario.mdr_tipo_rodado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_modal_rodoviario.mdr_tipo_rodado = :mdfe_modal_rodoviario_TipoRodado_745 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_modal_rodoviario_TipoRodado_745", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoCarroceria" || parametro.FieldName == "mdr_tipo_carroceria")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is MDFeTipoCarroceria)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo MDFeTipoCarroceria");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_modal_rodoviario.mdr_tipo_carroceria IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_modal_rodoviario.mdr_tipo_carroceria = :mdfe_modal_rodoviario_TipoCarroceria_5559 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_modal_rodoviario_TipoCarroceria_5559", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UfLiceciamento" || parametro.FieldName == "mdr_uf_liceciamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_modal_rodoviario.mdr_uf_liceciamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_modal_rodoviario.mdr_uf_liceciamento LIKE :mdfe_modal_rodoviario_UfLiceciamento_8243 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_modal_rodoviario_UfLiceciamento_8243", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Renavam" || parametro.FieldName == "mrd_renavam")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_renavam IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_renavam LIKE :mdfe_modal_rodoviario_Renavam_8703 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_modal_rodoviario_Renavam_8703", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoAgendamentoPorto" || parametro.FieldName == "mrd_codigo_agendamento_porto")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_codigo_agendamento_porto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_codigo_agendamento_porto LIKE :mdfe_modal_rodoviario_CodigoAgendamentoPorto_6561 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_modal_rodoviario_CodigoAgendamentoPorto_6561", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VersaoExato" || parametro.FieldName == "VersaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_versao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_versao LIKE :mdfe_modal_rodoviario_Versao_561 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_modal_rodoviario_Versao_561", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoInternoVeiculoExato" || parametro.FieldName == "CodigoInternoVeiculoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_codigo_interno_veiculo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_codigo_interno_veiculo LIKE :mdfe_modal_rodoviario_CodigoInternoVeiculo_6398 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_modal_rodoviario_CodigoInternoVeiculo_6398", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlacaExato" || parametro.FieldName == "PlacaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_placa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_placa LIKE :mdfe_modal_rodoviario_Placa_4212 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_modal_rodoviario_Placa_4212", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  mdfe_modal_rodoviario.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_modal_rodoviario.entity_uid LIKE :mdfe_modal_rodoviario_EntityUid_2563 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_modal_rodoviario_EntityUid_2563", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CpfProprietarioExato" || parametro.FieldName == "CpfProprietarioExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_cpf_proprietario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_cpf_proprietario LIKE :mdfe_modal_rodoviario_CpfProprietario_5799 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_modal_rodoviario_CpfProprietario_5799", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CnpjProprietarioExato" || parametro.FieldName == "CnpjProprietarioExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_cnpj_proprietario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_cnpj_proprietario LIKE :mdfe_modal_rodoviario_CnpjProprietario_384 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_modal_rodoviario_CnpjProprietario_384", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomeRazaoProprietarioExato" || parametro.FieldName == "NomeRazaoProprietarioExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_nome_razao_proprietario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_nome_razao_proprietario LIKE :mdfe_modal_rodoviario_NomeRazaoProprietario_9442 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_modal_rodoviario_NomeRazaoProprietario_9442", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IeProprietarioExato" || parametro.FieldName == "IeProprietarioExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_ie_proprietario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_ie_proprietario LIKE :mdfe_modal_rodoviario_IeProprietario_8141 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_modal_rodoviario_IeProprietario_8141", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UfProprietarioExato" || parametro.FieldName == "UfProprietarioExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_modal_rodoviario.mdr_uf_proprietario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_modal_rodoviario.mdr_uf_proprietario LIKE :mdfe_modal_rodoviario_UfProprietario_7153 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_modal_rodoviario_UfProprietario_7153", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UfLiceciamentoExato" || parametro.FieldName == "UfLiceciamentoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_modal_rodoviario.mdr_uf_liceciamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_modal_rodoviario.mdr_uf_liceciamento LIKE :mdfe_modal_rodoviario_UfLiceciamento_2342 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_modal_rodoviario_UfLiceciamento_2342", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RenavamExato" || parametro.FieldName == "RenavamExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_renavam IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_renavam LIKE :mdfe_modal_rodoviario_Renavam_6287 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_modal_rodoviario_Renavam_6287", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoAgendamentoPortoExato" || parametro.FieldName == "CodigoAgendamentoPortoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_codigo_agendamento_porto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_modal_rodoviario.mrd_codigo_agendamento_porto LIKE :mdfe_modal_rodoviario_CodigoAgendamentoPorto_6997 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_modal_rodoviario_CodigoAgendamentoPorto_6997", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  MdfeModalRodoviarioClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (MdfeModalRodoviarioClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(MdfeModalRodoviarioClass), Convert.ToInt32(read["id_mdfe_modal_rodoviario"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new MdfeModalRodoviarioClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_mdfe_modal_rodoviario"]);
                     if (read["id_mdfe"] != DBNull.Value)
                     {
                        entidade.Mdfe = (IWTNFCompleto.BibliotecaEntidades.Entidades.MdfeClass)IWTNFCompleto.BibliotecaEntidades.Entidades.MdfeClass.GetEntidade(Convert.ToInt32(read["id_mdfe"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Mdfe = null ;
                     }
                     entidade.Versao = (read["mrd_versao"] != DBNull.Value ? read["mrd_versao"].ToString() : null);
                     entidade.Rntrc = read["mrd_rntrc"] as int?;
                     entidade.Ciot = read["mrd_ciot"] as int?;
                     entidade.CodigoInternoVeiculo = (read["mrd_codigo_interno_veiculo"] != DBNull.Value ? read["mrd_codigo_interno_veiculo"].ToString() : null);
                     entidade.Placa = (read["mrd_placa"] != DBNull.Value ? read["mrd_placa"].ToString() : null);
                     entidade.Tara = (double)read["mrd_tara"];
                     entidade.CapacidadeKg = read["mrd_capacidade_kg"] as double?;
                     entidade.CapacidadeM3 = read["mrd_capacidade_m3"] as double?;
                     entidade.ProprietarioRntrc = (int)read["mrd_proprietario_rntrc"];
                     entidade.Version = (int)read["version"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.CpfProprietario = (read["mrd_cpf_proprietario"] != DBNull.Value ? read["mrd_cpf_proprietario"].ToString() : null);
                     entidade.CnpjProprietario = (read["mrd_cnpj_proprietario"] != DBNull.Value ? read["mrd_cnpj_proprietario"].ToString() : null);
                     entidade.NomeRazaoProprietario = (read["mrd_nome_razao_proprietario"] != DBNull.Value ? read["mrd_nome_razao_proprietario"].ToString() : null);
                     entidade.IeProprietario = (read["mrd_ie_proprietario"] != DBNull.Value ? read["mrd_ie_proprietario"].ToString() : null);
                     entidade.UfProprietario = (read["mdr_uf_proprietario"] != DBNull.Value ? read["mdr_uf_proprietario"].ToString() : null);
                     entidade.TipoProprietario = (MDFeTipoProprietarioVeiculo?) (read["mdr_tipo_proprietario"] != DBNull.Value ? Enum.ToObject(Nullable.GetUnderlyingType(typeof(MDFeTipoProprietarioVeiculo?)), read["mdr_tipo_proprietario"]) : null);
                     entidade.TipoRodado = (MDFeTipoRodado) (read["mdr_tipo_rodado"] != DBNull.Value ? Enum.ToObject(typeof(MDFeTipoRodado), read["mdr_tipo_rodado"]) : null);
                     entidade.TipoCarroceria = (MDFeTipoCarroceria) (read["mdr_tipo_carroceria"] != DBNull.Value ? Enum.ToObject(typeof(MDFeTipoCarroceria), read["mdr_tipo_carroceria"]) : null);
                     entidade.UfLiceciamento = (read["mdr_uf_liceciamento"] != DBNull.Value ? read["mdr_uf_liceciamento"].ToString() : null);
                     entidade.Renavam = (read["mrd_renavam"] != DBNull.Value ? read["mrd_renavam"].ToString() : null);
                     entidade.CodigoAgendamentoPorto = (read["mrd_codigo_agendamento_porto"] != DBNull.Value ? read["mrd_codigo_agendamento_porto"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (MdfeModalRodoviarioClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
