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
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades; 
namespace BibliotecaEntidades.Base 
{ 
    [Serializable()]
     [Table("ordem_producao_envio_terceiros","oet")]
     public class OrdemProducaoEnvioTerceirosBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do OrdemProducaoEnvioTerceirosClass";
protected const string ErroDelete = "Erro ao excluir o OrdemProducaoEnvioTerceirosClass  ";
protected const string ErroSave = "Erro ao salvar o OrdemProducaoEnvioTerceirosClass.";
protected const string ErroCollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceiros = "Erro ao carregar a coleção de OrdemProducaoEnvioTerceirosCancSaldoRecebClass.";
protected const string ErroCollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceiros = "Erro ao carregar a coleção de OrdemProducaoEnvioTerceirosRecebimentoClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroOrdemProducaoObrigatorio = "O campo OrdemProducao é obrigatório";
protected const string ErroFornecedorObrigatorio = "O campo Fornecedor é obrigatório";
protected const string ErroAcsUsuarioEnvioObrigatorio = "O campo AcsUsuarioEnvio é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do OrdemProducaoEnvioTerceirosClass.";
protected const string MensagemUtilizadoCollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceiros =  "A entidade OrdemProducaoEnvioTerceirosClass está sendo utilizada nos seguintes OrdemProducaoEnvioTerceirosCancSaldoRecebClass:";
protected const string MensagemUtilizadoCollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceiros =  "A entidade OrdemProducaoEnvioTerceirosClass está sendo utilizada nos seguintes OrdemProducaoEnvioTerceirosRecebimentoClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade OrdemProducaoEnvioTerceirosClass está sendo utilizada.";
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

       protected BibliotecaEntidades.Entidades.OperacaoClass _operacaoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.OperacaoClass _operacaoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.OperacaoClass _valueOperacao;
        [Column("id_operacao", "operacao", "id_operacao")]
       public virtual BibliotecaEntidades.Entidades.OperacaoClass Operacao
        { 
           get {                 return this._valueOperacao; } 
           set 
           { 
                if (this._valueOperacao == value)return;
                 this._valueOperacao = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.OperacaoCompletaClass _operacaoCompletaOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.OperacaoCompletaClass _operacaoCompletaOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.OperacaoCompletaClass _valueOperacaoCompleta;
        [Column("id_operacao_completa", "operacao_completa", "id_operacao_completa")]
       public virtual BibliotecaEntidades.Entidades.OperacaoCompletaClass OperacaoCompleta
        { 
           get {                 return this._valueOperacaoCompleta; } 
           set 
           { 
                if (this._valueOperacaoCompleta == value)return;
                 this._valueOperacaoCompleta = value; 
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

       protected BibliotecaEntidades.Entidades.TransporteClass _transporteOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.TransporteClass _transporteOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.TransporteClass _valueTransporte;
        [Column("id_transporte", "transporte", "id_transporte")]
       public virtual BibliotecaEntidades.Entidades.TransporteClass Transporte
        { 
           get {                 return this._valueTransporte; } 
           set 
           { 
                if (this._valueTransporte == value)return;
                 this._valueTransporte = value; 
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

       protected double _quantidadeOriginal{get;private set;}
       private double _quantidadeOriginalCommited{get; set;}
        private double _valueQuantidade;
         [Column("oet_quantidade")]
        public virtual double Quantidade
         { 
            get { return this._valueQuantidade; } 
            set 
            { 
                if (this._valueQuantidade == value)return;
                 this._valueQuantidade = value; 
            } 
        } 

       protected DateTime _dataEnvioOriginal{get;private set;}
       private DateTime _dataEnvioOriginalCommited{get; set;}
        private DateTime _valueDataEnvio;
         [Column("oet_data_envio")]
        public virtual DateTime DataEnvio
         { 
            get { return this._valueDataEnvio; } 
            set 
            { 
                if (this._valueDataEnvio == value)return;
                 this._valueDataEnvio = value; 
            } 
        } 

       protected IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioEnvioOriginal{get;private set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioEnvioOriginalCommited {get; set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _valueAcsUsuarioEnvio;
        [Column("id_acs_usuario_envio", "acs_usuario", "id_acs_usuario")]
       public virtual IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass AcsUsuarioEnvio
        { 
           get {                 return this._valueAcsUsuarioEnvio; } 
           set 
           { 
                if (this._valueAcsUsuarioEnvio == value)return;
                 this._valueAcsUsuarioEnvio = value; 
           } 
       } 

       protected bool _totalmenteRecebidoOriginal{get;private set;}
       private bool _totalmenteRecebidoOriginalCommited{get; set;}
        private bool _valueTotalmenteRecebido;
         [Column("oet_totalmente_recebido")]
        public virtual bool TotalmenteRecebido
         { 
            get { return this._valueTotalmenteRecebido; } 
            set 
            { 
                if (this._valueTotalmenteRecebido == value)return;
                 this._valueTotalmenteRecebido = value; 
            } 
        } 

       private List<long> _collectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceirosOriginal;
       private List<Entidades.OrdemProducaoEnvioTerceirosCancSaldoRecebClass > _collectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceirosRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceirosLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceirosChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceirosCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemProducaoEnvioTerceirosCancSaldoRecebClass> _valueCollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceiros { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemProducaoEnvioTerceirosCancSaldoRecebClass> CollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceiros 
       { 
           get { if(!_valueCollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceirosLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceiros();}
return this._valueCollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceiros; } 
           set 
           { 
               this._valueCollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceiros = value; 
               this._valueCollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceirosLoaded = true; 
           } 
       } 

       private List<long> _collectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceirosOriginal;
       private List<Entidades.OrdemProducaoEnvioTerceirosRecebimentoClass > _collectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceirosRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceirosLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceirosChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceirosCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemProducaoEnvioTerceirosRecebimentoClass> _valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceiros { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemProducaoEnvioTerceirosRecebimentoClass> CollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceiros 
       { 
           get { if(!_valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceirosLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceiros();}
return this._valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceiros; } 
           set 
           { 
               this._valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceiros = value; 
               this._valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceirosLoaded = true; 
           } 
       } 

        public OrdemProducaoEnvioTerceirosBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Quantidade = 0;
           this.TotalmenteRecebido = false;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static OrdemProducaoEnvioTerceirosClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (OrdemProducaoEnvioTerceirosClass) GetEntity(typeof(OrdemProducaoEnvioTerceirosClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceirosChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceirosChanged = true;
                  _valueCollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceirosCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceirosChanged = true; 
                  _valueCollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceirosCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoEnvioTerceirosCancSaldoRecebClass item in e.OldItems) 
                 { 
                     _collectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceirosRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceirosChanged = true; 
                  _valueCollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceirosCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoEnvioTerceirosCancSaldoRecebClass item in _valueCollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceiros) 
                 { 
                     _collectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceirosRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceiros()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemProducaoEnvioTerceirosCancSaldoRecebClass> oc;
                _valueCollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceirosChanged = false;
                 _valueCollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceirosCommitedChanged = false;
                _collectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceirosRemovidos = new List<Entidades.OrdemProducaoEnvioTerceirosCancSaldoRecebClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemProducaoEnvioTerceirosCancSaldoRecebClass>();
                }
                else{ 
                   Entidades.OrdemProducaoEnvioTerceirosCancSaldoRecebClass search = new Entidades.OrdemProducaoEnvioTerceirosCancSaldoRecebClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemProducaoEnvioTerceirosCancSaldoRecebClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OrdemProducaoEnvioTerceiros", this),                     }                       ).Cast<Entidades.OrdemProducaoEnvioTerceirosCancSaldoRecebClass>().ToList());
                 }
                 _valueCollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceiros = new BindingList<Entidades.OrdemProducaoEnvioTerceirosCancSaldoRecebClass>(oc); 
                 _collectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceirosOriginal= (from a in _valueCollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceiros select a.ID).ToList();
                 _valueCollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceirosLoaded = true;
                 oc.CollectionChanged += CollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceirosChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceiros+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceirosChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceirosChanged = true;
                  _valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceirosCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceirosChanged = true; 
                  _valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceirosCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoEnvioTerceirosRecebimentoClass item in e.OldItems) 
                 { 
                     _collectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceirosRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceirosChanged = true; 
                  _valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceirosCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoEnvioTerceirosRecebimentoClass item in _valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceiros) 
                 { 
                     _collectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceirosRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceiros()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemProducaoEnvioTerceirosRecebimentoClass> oc;
                _valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceirosChanged = false;
                 _valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceirosCommitedChanged = false;
                _collectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceirosRemovidos = new List<Entidades.OrdemProducaoEnvioTerceirosRecebimentoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemProducaoEnvioTerceirosRecebimentoClass>();
                }
                else{ 
                   Entidades.OrdemProducaoEnvioTerceirosRecebimentoClass search = new Entidades.OrdemProducaoEnvioTerceirosRecebimentoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemProducaoEnvioTerceirosRecebimentoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OrdemProducaoEnvioTerceiros", this),                     }                       ).Cast<Entidades.OrdemProducaoEnvioTerceirosRecebimentoClass>().ToList());
                 }
                 _valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceiros = new BindingList<Entidades.OrdemProducaoEnvioTerceirosRecebimentoClass>(oc); 
                 _collectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceirosOriginal= (from a in _valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceiros select a.ID).ToList();
                 _valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceirosLoaded = true;
                 oc.CollectionChanged += CollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceirosChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceiros+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if ( _valueOrdemProducao == null)
                {
                    throw new Exception(ErroOrdemProducaoObrigatorio);
                }
                if ( _valueFornecedor == null)
                {
                    throw new Exception(ErroFornecedorObrigatorio);
                }
                if ( _valueAcsUsuarioEnvio == null)
                {
                    throw new Exception(ErroAcsUsuarioEnvioObrigatorio);
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
                    "  public.ordem_producao_envio_terceiros  " +
                    "WHERE " +
                    "  id_ordem_producao_envio_terceiros = :id";
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
                        "  public.ordem_producao_envio_terceiros   " +
                        "SET  " + 
                        "  id_ordem_producao = :id_ordem_producao, " + 
                        "  id_operacao = :id_operacao, " + 
                        "  id_operacao_completa = :id_operacao_completa, " + 
                        "  id_fornecedor = :id_fornecedor, " + 
                        "  id_transporte = :id_transporte, " + 
                        "  id_nf_principal = :id_nf_principal, " + 
                        "  oet_quantidade = :oet_quantidade, " + 
                        "  oet_data_envio = :oet_data_envio, " + 
                        "  id_acs_usuario_envio = :id_acs_usuario_envio, " + 
                        "  oet_totalmente_recebido = :oet_totalmente_recebido, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_ordem_producao_envio_terceiros = :id " +
                        "RETURNING id_ordem_producao_envio_terceiros;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.ordem_producao_envio_terceiros " +
                        "( " +
                        "  id_ordem_producao , " + 
                        "  id_operacao , " + 
                        "  id_operacao_completa , " + 
                        "  id_fornecedor , " + 
                        "  id_transporte , " + 
                        "  id_nf_principal , " + 
                        "  oet_quantidade , " + 
                        "  oet_data_envio , " + 
                        "  id_acs_usuario_envio , " + 
                        "  oet_totalmente_recebido , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_ordem_producao , " + 
                        "  :id_operacao , " + 
                        "  :id_operacao_completa , " + 
                        "  :id_fornecedor , " + 
                        "  :id_transporte , " + 
                        "  :id_nf_principal , " + 
                        "  :oet_quantidade , " + 
                        "  :oet_data_envio , " + 
                        "  :id_acs_usuario_envio , " + 
                        "  :oet_totalmente_recebido , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_ordem_producao_envio_terceiros;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.OrdemProducao==null ? (object) DBNull.Value : this.OrdemProducao.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_operacao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Operacao==null ? (object) DBNull.Value : this.Operacao.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_operacao_completa", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.OperacaoCompleta==null ? (object) DBNull.Value : this.OperacaoCompleta.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_fornecedor", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Fornecedor==null ? (object) DBNull.Value : this.Fornecedor.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_transporte", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Transporte==null ? (object) DBNull.Value : this.Transporte.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nf_principal", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.NfPrincipal==null ? (object) DBNull.Value : this.NfPrincipal.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oet_quantidade", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Quantidade ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oet_data_envio", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataEnvio ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_envio", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuarioEnvio==null ? (object) DBNull.Value : this.AcsUsuarioEnvio.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oet_totalmente_recebido", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.TotalmenteRecebido ?? DBNull.Value;
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
 if (CollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceiros.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceiros+"\r\n";
                foreach (Entidades.OrdemProducaoEnvioTerceirosCancSaldoRecebClass tmp in CollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceiros)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceiros.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceiros+"\r\n";
                foreach (Entidades.OrdemProducaoEnvioTerceirosRecebimentoClass tmp in CollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceiros)
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
        public static OrdemProducaoEnvioTerceirosClass CopiarEntidade(OrdemProducaoEnvioTerceirosClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               OrdemProducaoEnvioTerceirosClass toRet = new OrdemProducaoEnvioTerceirosClass(usuario,conn);
 toRet.OrdemProducao= entidadeCopiar.OrdemProducao;
 toRet.Operacao= entidadeCopiar.Operacao;
 toRet.OperacaoCompleta= entidadeCopiar.OperacaoCompleta;
 toRet.Fornecedor= entidadeCopiar.Fornecedor;
 toRet.Transporte= entidadeCopiar.Transporte;
 toRet.NfPrincipal= entidadeCopiar.NfPrincipal;
 toRet.Quantidade= entidadeCopiar.Quantidade;
 toRet.DataEnvio= entidadeCopiar.DataEnvio;
 toRet.AcsUsuarioEnvio= entidadeCopiar.AcsUsuarioEnvio;
 toRet.TotalmenteRecebido= entidadeCopiar.TotalmenteRecebido;

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
       _operacaoOriginal = Operacao;
       _operacaoOriginalCommited = _operacaoOriginal;
       _operacaoCompletaOriginal = OperacaoCompleta;
       _operacaoCompletaOriginalCommited = _operacaoCompletaOriginal;
       _fornecedorOriginal = Fornecedor;
       _fornecedorOriginalCommited = _fornecedorOriginal;
       _transporteOriginal = Transporte;
       _transporteOriginalCommited = _transporteOriginal;
       _nfPrincipalOriginal = NfPrincipal;
       _nfPrincipalOriginalCommited = _nfPrincipalOriginal;
       _quantidadeOriginal = Quantidade;
       _quantidadeOriginalCommited = _quantidadeOriginal;
       _dataEnvioOriginal = DataEnvio;
       _dataEnvioOriginalCommited = _dataEnvioOriginal;
       _acsUsuarioEnvioOriginal = AcsUsuarioEnvio;
       _acsUsuarioEnvioOriginalCommited = _acsUsuarioEnvioOriginal;
       _totalmenteRecebidoOriginal = TotalmenteRecebido;
       _totalmenteRecebidoOriginalCommited = _totalmenteRecebidoOriginal;
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
       _operacaoOriginalCommited = Operacao;
       _operacaoCompletaOriginalCommited = OperacaoCompleta;
       _fornecedorOriginalCommited = Fornecedor;
       _transporteOriginalCommited = Transporte;
       _nfPrincipalOriginalCommited = NfPrincipal;
       _quantidadeOriginalCommited = Quantidade;
       _dataEnvioOriginalCommited = DataEnvio;
       _acsUsuarioEnvioOriginalCommited = AcsUsuarioEnvio;
       _totalmenteRecebidoOriginalCommited = TotalmenteRecebido;
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
               if (_valueCollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceirosLoaded) 
               {
                  if (_collectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceirosRemovidos != null) 
                  {
                     _collectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceirosRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceirosRemovidos = new List<Entidades.OrdemProducaoEnvioTerceirosCancSaldoRecebClass>();
                  }
                  _collectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceirosOriginal= (from a in _valueCollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceiros select a.ID).ToList();
                  _valueCollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceirosChanged = false;
                  _valueCollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceirosCommitedChanged = false;
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceirosLoaded) 
               {
                  if (_collectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceirosRemovidos != null) 
                  {
                     _collectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceirosRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceirosRemovidos = new List<Entidades.OrdemProducaoEnvioTerceirosRecebimentoClass>();
                  }
                  _collectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceirosOriginal= (from a in _valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceiros select a.ID).ToList();
                  _valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceirosChanged = false;
                  _valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceirosCommitedChanged = false;
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
               Operacao=_operacaoOriginal;
               _operacaoOriginalCommited=_operacaoOriginal;
               OperacaoCompleta=_operacaoCompletaOriginal;
               _operacaoCompletaOriginalCommited=_operacaoCompletaOriginal;
               Fornecedor=_fornecedorOriginal;
               _fornecedorOriginalCommited=_fornecedorOriginal;
               Transporte=_transporteOriginal;
               _transporteOriginalCommited=_transporteOriginal;
               NfPrincipal=_nfPrincipalOriginal;
               _nfPrincipalOriginalCommited=_nfPrincipalOriginal;
               Quantidade=_quantidadeOriginal;
               _quantidadeOriginalCommited=_quantidadeOriginal;
               DataEnvio=_dataEnvioOriginal;
               _dataEnvioOriginalCommited=_dataEnvioOriginal;
               AcsUsuarioEnvio=_acsUsuarioEnvioOriginal;
               _acsUsuarioEnvioOriginalCommited=_acsUsuarioEnvioOriginal;
               TotalmenteRecebido=_totalmenteRecebidoOriginal;
               _totalmenteRecebidoOriginalCommited=_totalmenteRecebidoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               if (_valueCollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceirosLoaded) 
               {
                  CollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceiros.Clear();
                  foreach(int item in _collectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceirosOriginal)
                  {
                    CollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceiros.Add(Entidades.OrdemProducaoEnvioTerceirosCancSaldoRecebClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceirosRemovidos.Clear();
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceirosLoaded) 
               {
                  CollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceiros.Clear();
                  foreach(int item in _collectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceirosOriginal)
                  {
                    CollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceiros.Add(Entidades.OrdemProducaoEnvioTerceirosRecebimentoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceirosRemovidos.Clear();
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
               if (_valueCollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceirosLoaded) 
               {
                  if (_valueCollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceirosChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceirosLoaded) 
               {
                  if (_valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceirosChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceirosLoaded) 
               {
                   tempRet = CollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceiros.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceirosLoaded) 
               {
                   tempRet = CollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceiros.Any(item => item.IsDirty());
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
       if (_operacaoOriginal!=null)
       {
          dirty = !_operacaoOriginal.Equals(Operacao);
       }
       else
       {
            dirty = Operacao != null;
       }
      if (dirty) return true;
       if (_operacaoCompletaOriginal!=null)
       {
          dirty = !_operacaoCompletaOriginal.Equals(OperacaoCompleta);
       }
       else
       {
            dirty = OperacaoCompleta != null;
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
       if (_transporteOriginal!=null)
       {
          dirty = !_transporteOriginal.Equals(Transporte);
       }
       else
       {
            dirty = Transporte != null;
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
       dirty = _quantidadeOriginal != Quantidade;
      if (dirty) return true;
       dirty = _dataEnvioOriginal != DataEnvio;
      if (dirty) return true;
       if (_acsUsuarioEnvioOriginal!=null)
       {
          dirty = !_acsUsuarioEnvioOriginal.Equals(AcsUsuarioEnvio);
       }
       else
       {
            dirty = AcsUsuarioEnvio != null;
       }
      if (dirty) return true;
       dirty = _totalmenteRecebidoOriginal != TotalmenteRecebido;
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
               if (_valueCollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceirosLoaded) 
               {
                  if (_valueCollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceirosCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceirosLoaded) 
               {
                  if (_valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceirosCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceirosLoaded) 
               {
                   tempRet = CollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceiros.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceirosLoaded) 
               {
                   tempRet = CollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceiros.Any(item => item.IsDirtyCommited());
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
       if (_operacaoOriginalCommited!=null)
       {
          dirty = !_operacaoOriginalCommited.Equals(Operacao);
       }
       else
       {
            dirty = Operacao != null;
       }
      if (dirty) return true;
       if (_operacaoCompletaOriginalCommited!=null)
       {
          dirty = !_operacaoCompletaOriginalCommited.Equals(OperacaoCompleta);
       }
       else
       {
            dirty = OperacaoCompleta != null;
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
       if (_transporteOriginalCommited!=null)
       {
          dirty = !_transporteOriginalCommited.Equals(Transporte);
       }
       else
       {
            dirty = Transporte != null;
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
       dirty = _quantidadeOriginalCommited != Quantidade;
      if (dirty) return true;
       dirty = _dataEnvioOriginalCommited != DataEnvio;
      if (dirty) return true;
       if (_acsUsuarioEnvioOriginalCommited!=null)
       {
          dirty = !_acsUsuarioEnvioOriginalCommited.Equals(AcsUsuarioEnvio);
       }
       else
       {
            dirty = AcsUsuarioEnvio != null;
       }
      if (dirty) return true;
       dirty = _totalmenteRecebidoOriginalCommited != TotalmenteRecebido;
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
               if (_valueCollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceirosLoaded) 
               {
                  foreach(OrdemProducaoEnvioTerceirosCancSaldoRecebClass item in CollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceiros)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceirosLoaded) 
               {
                  foreach(OrdemProducaoEnvioTerceirosRecebimentoClass item in CollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceiros)
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
             case "Operacao":
                return this.Operacao;
             case "OperacaoCompleta":
                return this.OperacaoCompleta;
             case "Fornecedor":
                return this.Fornecedor;
             case "Transporte":
                return this.Transporte;
             case "NfPrincipal":
                return this.NfPrincipal;
             case "Quantidade":
                return this.Quantidade;
             case "DataEnvio":
                return this.DataEnvio;
             case "AcsUsuarioEnvio":
                return this.AcsUsuarioEnvio;
             case "TotalmenteRecebido":
                return this.TotalmenteRecebido;
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
             if (Operacao!=null)
                Operacao.ChangeSingleConnection(newConnection);
             if (OperacaoCompleta!=null)
                OperacaoCompleta.ChangeSingleConnection(newConnection);
             if (Fornecedor!=null)
                Fornecedor.ChangeSingleConnection(newConnection);
             if (Transporte!=null)
                Transporte.ChangeSingleConnection(newConnection);
             if (NfPrincipal!=null)
                NfPrincipal.ChangeSingleConnection(newConnection);
             if (AcsUsuarioEnvio!=null)
                AcsUsuarioEnvio.ChangeSingleConnection(newConnection);
               if (_valueCollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceirosLoaded) 
               {
                  foreach(OrdemProducaoEnvioTerceirosCancSaldoRecebClass item in CollectionOrdemProducaoEnvioTerceirosCancSaldoRecebClassOrdemProducaoEnvioTerceiros)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceirosLoaded) 
               {
                  foreach(OrdemProducaoEnvioTerceirosRecebimentoClass item in CollectionOrdemProducaoEnvioTerceirosRecebimentoClassOrdemProducaoEnvioTerceiros)
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
                  command.CommandText += " COUNT(ordem_producao_envio_terceiros.id_ordem_producao_envio_terceiros) " ;
               }
               else
               {
               command.CommandText += "ordem_producao_envio_terceiros.id_ordem_producao_envio_terceiros, " ;
               command.CommandText += "ordem_producao_envio_terceiros.id_ordem_producao, " ;
               command.CommandText += "ordem_producao_envio_terceiros.id_operacao, " ;
               command.CommandText += "ordem_producao_envio_terceiros.id_operacao_completa, " ;
               command.CommandText += "ordem_producao_envio_terceiros.id_fornecedor, " ;
               command.CommandText += "ordem_producao_envio_terceiros.id_transporte, " ;
               command.CommandText += "ordem_producao_envio_terceiros.id_nf_principal, " ;
               command.CommandText += "ordem_producao_envio_terceiros.oet_quantidade, " ;
               command.CommandText += "ordem_producao_envio_terceiros.oet_data_envio, " ;
               command.CommandText += "ordem_producao_envio_terceiros.id_acs_usuario_envio, " ;
               command.CommandText += "ordem_producao_envio_terceiros.oet_totalmente_recebido, " ;
               command.CommandText += "ordem_producao_envio_terceiros.entity_uid, " ;
               command.CommandText += "ordem_producao_envio_terceiros.version " ;
               }
               command.CommandText += " FROM  ordem_producao_envio_terceiros ";
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
                        orderByClause += " , oet_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(oet_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = ordem_producao_envio_terceiros.id_acs_usuario_ultima_revisao ";
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
                     case "id_ordem_producao_envio_terceiros":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_envio_terceiros.id_ordem_producao_envio_terceiros " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_envio_terceiros.id_ordem_producao_envio_terceiros) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_ordem_producao":
                     case "OrdemProducao":
                     command.CommandText += " LEFT JOIN ordem_producao as ordem_producao_OrdemProducao ON ordem_producao_OrdemProducao.id_ordem_producao = ordem_producao_envio_terceiros.id_ordem_producao ";                     switch (parametro.TipoOrdenacao)
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
                     case "id_operacao":
                     case "Operacao":
                     command.CommandText += " LEFT JOIN operacao as operacao_Operacao ON operacao_Operacao.id_operacao = ordem_producao_envio_terceiros.id_operacao ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , operacao_Operacao.ope_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(operacao_Operacao.ope_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_operacao_completa":
                     case "OperacaoCompleta":
                     command.CommandText += " LEFT JOIN operacao_completa as operacao_completa_OperacaoCompleta ON operacao_completa_OperacaoCompleta.id_operacao_completa = ordem_producao_envio_terceiros.id_operacao_completa ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , operacao_completa_OperacaoCompleta.opc_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(operacao_completa_OperacaoCompleta.opc_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_fornecedor":
                     case "Fornecedor":
                     command.CommandText += " LEFT JOIN fornecedor as fornecedor_Fornecedor ON fornecedor_Fornecedor.id_fornecedor = ordem_producao_envio_terceiros.id_fornecedor ";                     switch (parametro.TipoOrdenacao)
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
                     case "id_transporte":
                     case "Transporte":
                     command.CommandText += " LEFT JOIN transporte as transporte_Transporte ON transporte_Transporte.id_transporte = ordem_producao_envio_terceiros.id_transporte ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , transporte_Transporte.trp_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(transporte_Transporte.trp_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_nf_principal":
                     case "NfPrincipal":
                     orderByClause += " , ordem_producao_envio_terceiros.id_nf_principal " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "oet_quantidade":
                     case "Quantidade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_envio_terceiros.oet_quantidade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_envio_terceiros.oet_quantidade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oet_data_envio":
                     case "DataEnvio":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_envio_terceiros.oet_data_envio " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_envio_terceiros.oet_data_envio) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_envio":
                     case "AcsUsuarioEnvio":
                     orderByClause += " , ordem_producao_envio_terceiros.id_acs_usuario_envio " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "oet_totalmente_recebido":
                     case "TotalmenteRecebido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_envio_terceiros.oet_totalmente_recebido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_envio_terceiros.oet_totalmente_recebido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_envio_terceiros.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_envio_terceiros.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , ordem_producao_envio_terceiros.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_envio_terceiros.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_envio_terceiros.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_envio_terceiros.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_ordem_producao_envio_terceiros")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_envio_terceiros.id_ordem_producao_envio_terceiros IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_envio_terceiros.id_ordem_producao_envio_terceiros = :ordem_producao_envio_terceiros_ID_1700 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_envio_terceiros_ID_1700", NpgsqlDbType.Bigint, parametro.Fieldvalue));
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
                         whereClause += "  ordem_producao_envio_terceiros.id_ordem_producao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_envio_terceiros.id_ordem_producao = :ordem_producao_envio_terceiros_OrdemProducao_1815 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_envio_terceiros_OrdemProducao_1815", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Operacao" || parametro.FieldName == "id_operacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.OperacaoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.OperacaoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_envio_terceiros.id_operacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_envio_terceiros.id_operacao = :ordem_producao_envio_terceiros_Operacao_4407 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_envio_terceiros_Operacao_4407", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OperacaoCompleta" || parametro.FieldName == "id_operacao_completa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.OperacaoCompletaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.OperacaoCompletaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_envio_terceiros.id_operacao_completa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_envio_terceiros.id_operacao_completa = :ordem_producao_envio_terceiros_OperacaoCompleta_2677 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_envio_terceiros_OperacaoCompleta_2677", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  ordem_producao_envio_terceiros.id_fornecedor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_envio_terceiros.id_fornecedor = :ordem_producao_envio_terceiros_Fornecedor_5374 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_envio_terceiros_Fornecedor_5374", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Transporte" || parametro.FieldName == "id_transporte")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.TransporteClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.TransporteClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_envio_terceiros.id_transporte IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_envio_terceiros.id_transporte = :ordem_producao_envio_terceiros_Transporte_5389 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_envio_terceiros_Transporte_5389", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  ordem_producao_envio_terceiros.id_nf_principal IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_envio_terceiros.id_nf_principal = :ordem_producao_envio_terceiros_NfPrincipal_9311 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_envio_terceiros_NfPrincipal_9311", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Quantidade" || parametro.FieldName == "oet_quantidade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_envio_terceiros.oet_quantidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_envio_terceiros.oet_quantidade = :ordem_producao_envio_terceiros_Quantidade_3907 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_envio_terceiros_Quantidade_3907", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataEnvio" || parametro.FieldName == "oet_data_envio")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_envio_terceiros.oet_data_envio IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_envio_terceiros.oet_data_envio = :ordem_producao_envio_terceiros_DataEnvio_1738 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_envio_terceiros_DataEnvio_1738", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcsUsuarioEnvio" || parametro.FieldName == "id_acs_usuario_envio")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_envio_terceiros.id_acs_usuario_envio IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_envio_terceiros.id_acs_usuario_envio = :ordem_producao_envio_terceiros_AcsUsuarioEnvio_4965 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_envio_terceiros_AcsUsuarioEnvio_4965", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TotalmenteRecebido" || parametro.FieldName == "oet_totalmente_recebido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_envio_terceiros.oet_totalmente_recebido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_envio_terceiros.oet_totalmente_recebido = :ordem_producao_envio_terceiros_TotalmenteRecebido_2926 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_envio_terceiros_TotalmenteRecebido_2926", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
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
                         whereClause += "  ordem_producao_envio_terceiros.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_envio_terceiros.entity_uid LIKE :ordem_producao_envio_terceiros_EntityUid_8153 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_envio_terceiros_EntityUid_8153", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  ordem_producao_envio_terceiros.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_envio_terceiros.version = :ordem_producao_envio_terceiros_Version_1381 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_envio_terceiros_Version_1381", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  ordem_producao_envio_terceiros.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_envio_terceiros.entity_uid LIKE :ordem_producao_envio_terceiros_EntityUid_3421 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_envio_terceiros_EntityUid_3421", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  OrdemProducaoEnvioTerceirosClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (OrdemProducaoEnvioTerceirosClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(OrdemProducaoEnvioTerceirosClass), Convert.ToInt32(read["id_ordem_producao_envio_terceiros"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new OrdemProducaoEnvioTerceirosClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_ordem_producao_envio_terceiros"]);
                     if (read["id_ordem_producao"] != DBNull.Value)
                     {
                        entidade.OrdemProducao = (BibliotecaEntidades.Entidades.OrdemProducaoClass)BibliotecaEntidades.Entidades.OrdemProducaoClass.GetEntidade(Convert.ToInt32(read["id_ordem_producao"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.OrdemProducao = null ;
                     }
                     if (read["id_operacao"] != DBNull.Value)
                     {
                        entidade.Operacao = (BibliotecaEntidades.Entidades.OperacaoClass)BibliotecaEntidades.Entidades.OperacaoClass.GetEntidade(Convert.ToInt32(read["id_operacao"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Operacao = null ;
                     }
                     if (read["id_operacao_completa"] != DBNull.Value)
                     {
                        entidade.OperacaoCompleta = (BibliotecaEntidades.Entidades.OperacaoCompletaClass)BibliotecaEntidades.Entidades.OperacaoCompletaClass.GetEntidade(Convert.ToInt32(read["id_operacao_completa"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.OperacaoCompleta = null ;
                     }
                     if (read["id_fornecedor"] != DBNull.Value)
                     {
                        entidade.Fornecedor = (BibliotecaEntidades.Entidades.FornecedorClass)BibliotecaEntidades.Entidades.FornecedorClass.GetEntidade(Convert.ToInt32(read["id_fornecedor"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Fornecedor = null ;
                     }
                     if (read["id_transporte"] != DBNull.Value)
                     {
                        entidade.Transporte = (BibliotecaEntidades.Entidades.TransporteClass)BibliotecaEntidades.Entidades.TransporteClass.GetEntidade(Convert.ToInt32(read["id_transporte"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Transporte = null ;
                     }
                     if (read["id_nf_principal"] != DBNull.Value)
                     {
                        entidade.NfPrincipal = (IWTNF.Entidades.Entidades.NfPrincipalClass)IWTNF.Entidades.Entidades.NfPrincipalClass.GetEntidade(Convert.ToInt32(read["id_nf_principal"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.NfPrincipal = null ;
                     }
                     entidade.Quantidade = (double)read["oet_quantidade"];
                     entidade.DataEnvio = (DateTime)read["oet_data_envio"];
                     if (read["id_acs_usuario_envio"] != DBNull.Value)
                     {
                        entidade.AcsUsuarioEnvio = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_envio"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuarioEnvio = null ;
                     }
                     entidade.TotalmenteRecebido = Convert.ToBoolean(Convert.ToInt16(read["oet_totalmente_recebido"]));
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (OrdemProducaoEnvioTerceirosClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
