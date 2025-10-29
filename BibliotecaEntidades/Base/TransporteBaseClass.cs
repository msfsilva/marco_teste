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
     [Table("transporte","trp")]
     public class TransporteBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do TransporteClass";
protected const string ErroDelete = "Erro ao excluir o TransporteClass  ";
protected const string ErroSave = "Erro ao salvar o TransporteClass.";
protected const string ErroCollectionEmbarqueClassTransporte = "Erro ao carregar a coleção de EmbarqueClass.";
protected const string ErroCollectionOrdemProducaoEnvioTerceirosClassTransporte = "Erro ao carregar a coleção de OrdemProducaoEnvioTerceirosClass.";
protected const string ErroCollectionPostoTrabalhoClassTransporte = "Erro ao carregar a coleção de PostoTrabalhoClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do TransporteClass.";
protected const string MensagemUtilizadoCollectionEmbarqueClassTransporte =  "A entidade TransporteClass está sendo utilizada nos seguintes EmbarqueClass:";
protected const string MensagemUtilizadoCollectionOrdemProducaoEnvioTerceirosClassTransporte =  "A entidade TransporteClass está sendo utilizada nos seguintes OrdemProducaoEnvioTerceirosClass:";
protected const string MensagemUtilizadoCollectionPostoTrabalhoClassTransporte =  "A entidade TransporteClass está sendo utilizada nos seguintes PostoTrabalhoClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade TransporteClass está sendo utilizada.";
#endregion
       protected string _razaoOriginal{get;private set;}
       private string _razaoOriginalCommited{get; set;}
        private string _valueRazao;
         [Column("trp_razao")]
        public virtual string Razao
         { 
            get { return this._valueRazao; } 
            set 
            { 
                if (this._valueRazao == value)return;
                 this._valueRazao = value; 
            } 
        } 

       protected string _ieOriginal{get;private set;}
       private string _ieOriginalCommited{get; set;}
        private string _valueIe;
         [Column("trp_ie")]
        public virtual string Ie
         { 
            get { return this._valueIe; } 
            set 
            { 
                if (this._valueIe == value)return;
                 this._valueIe = value; 
            } 
        } 

       protected string _enderecoOriginal{get;private set;}
       private string _enderecoOriginalCommited{get; set;}
        private string _valueEndereco;
         [Column("trp_endereco")]
        public virtual string Endereco
         { 
            get { return this._valueEndereco; } 
            set 
            { 
                if (this._valueEndereco == value)return;
                 this._valueEndereco = value; 
            } 
        } 

       protected string _siglaUfOriginal{get;private set;}
       private string _siglaUfOriginalCommited{get; set;}
        private string _valueSiglaUf;
         [Column("trp_sigla_uf")]
        public virtual string SiglaUf
         { 
            get { return this._valueSiglaUf; } 
            set 
            { 
                if (this._valueSiglaUf == value)return;
                 this._valueSiglaUf = value; 
            } 
        } 

       protected string _municipioOriginal{get;private set;}
       private string _municipioOriginalCommited{get; set;}
        private string _valueMunicipio;
         [Column("trp_municipio")]
        public virtual string Municipio
         { 
            get { return this._valueMunicipio; } 
            set 
            { 
                if (this._valueMunicipio == value)return;
                 this._valueMunicipio = value; 
            } 
        } 

       protected string _cpfCnpjOriginal{get;private set;}
       private string _cpfCnpjOriginalCommited{get; set;}
        private string _valueCpfCnpj;
         [Column("trp_cpf_cnpj")]
        public virtual string CpfCnpj
         { 
            get { return this._valueCpfCnpj; } 
            set 
            { 
                if (this._valueCpfCnpj == value)return;
                 this._valueCpfCnpj = value; 
            } 
        } 

       protected string _placaOriginal{get;private set;}
       private string _placaOriginalCommited{get; set;}
        private string _valuePlaca;
         [Column("trp_placa")]
        public virtual string Placa
         { 
            get { return this._valuePlaca; } 
            set 
            { 
                if (this._valuePlaca == value)return;
                 this._valuePlaca = value; 
            } 
        } 

       protected string _registroAnttOriginal{get;private set;}
       private string _registroAnttOriginalCommited{get; set;}
        private string _valueRegistroAntt;
         [Column("trp_registro_antt")]
        public virtual string RegistroAntt
         { 
            get { return this._valueRegistroAntt; } 
            set 
            { 
                if (this._valueRegistroAntt == value)return;
                 this._valueRegistroAntt = value; 
            } 
        } 

       protected string _siglaUfVeiculoOriginal{get;private set;}
       private string _siglaUfVeiculoOriginalCommited{get; set;}
        private string _valueSiglaUfVeiculo;
         [Column("trp_sigla_uf_veiculo")]
        public virtual string SiglaUfVeiculo
         { 
            get { return this._valueSiglaUfVeiculo; } 
            set 
            { 
                if (this._valueSiglaUfVeiculo == value)return;
                 this._valueSiglaUfVeiculo = value; 
            } 
        } 

       protected string _descricaoOriginal{get;private set;}
       private string _descricaoOriginalCommited{get; set;}
        private string _valueDescricao;
         [Column("trp_descricao")]
        public virtual string Descricao
         { 
            get { return this._valueDescricao; } 
            set 
            { 
                if (this._valueDescricao == value)return;
                 this._valueDescricao = value; 
            } 
        } 

       protected string _identificacaoOriginal{get;private set;}
       private string _identificacaoOriginalCommited{get; set;}
        private string _valueIdentificacao;
         [Column("trp_identificacao")]
        public virtual string Identificacao
         { 
            get { return this._valueIdentificacao; } 
            set 
            { 
                if (this._valueIdentificacao == value)return;
                 this._valueIdentificacao = value; 
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

       protected BibliotecaEntidades.Entidades.EstadoClass _estadoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.EstadoClass _estadoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.EstadoClass _valueEstado;
        [Column("id_estado", "estado", "id_estado")]
       public virtual BibliotecaEntidades.Entidades.EstadoClass Estado
        { 
           get {                 return this._valueEstado; } 
           set 
           { 
                if (this._valueEstado == value)return;
                 this._valueEstado = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.EstadoClass _estadoVeiculoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.EstadoClass _estadoVeiculoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.EstadoClass _valueEstadoVeiculo;
        [Column("id_estado_veiculo", "estado", "id_estado")]
       public virtual BibliotecaEntidades.Entidades.EstadoClass EstadoVeiculo
        { 
           get {                 return this._valueEstadoVeiculo; } 
           set 
           { 
                if (this._valueEstadoVeiculo == value)return;
                 this._valueEstadoVeiculo = value; 
           } 
       } 

       protected string _contatoOriginal{get;private set;}
       private string _contatoOriginalCommited{get; set;}
        private string _valueContato;
         [Column("trp_contato")]
        public virtual string Contato
         { 
            get { return this._valueContato; } 
            set 
            { 
                if (this._valueContato == value)return;
                 this._valueContato = value; 
            } 
        } 

       protected string _telefoneOriginal{get;private set;}
       private string _telefoneOriginalCommited{get; set;}
        private string _valueTelefone;
         [Column("trp_telefone")]
        public virtual string Telefone
         { 
            get { return this._valueTelefone; } 
            set 
            { 
                if (this._valueTelefone == value)return;
                 this._valueTelefone = value; 
            } 
        } 

       protected string _emailOriginal{get;private set;}
       private string _emailOriginalCommited{get; set;}
        private string _valueEmail;
         [Column("trp_email")]
        public virtual string Email
         { 
            get { return this._valueEmail; } 
            set 
            { 
                if (this._valueEmail == value)return;
                 this._valueEmail = value; 
            } 
        } 

       private List<long> _collectionEmbarqueClassTransporteOriginal;
       private List<Entidades.EmbarqueClass > _collectionEmbarqueClassTransporteRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEmbarqueClassTransporteLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEmbarqueClassTransporteChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEmbarqueClassTransporteCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.EmbarqueClass> _valueCollectionEmbarqueClassTransporte { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.EmbarqueClass> CollectionEmbarqueClassTransporte 
       { 
           get { if(!_valueCollectionEmbarqueClassTransporteLoaded && !this.DisableLoadCollection){this.LoadCollectionEmbarqueClassTransporte();}
return this._valueCollectionEmbarqueClassTransporte; } 
           set 
           { 
               this._valueCollectionEmbarqueClassTransporte = value; 
               this._valueCollectionEmbarqueClassTransporteLoaded = true; 
           } 
       } 

       private List<long> _collectionOrdemProducaoEnvioTerceirosClassTransporteOriginal;
       private List<Entidades.OrdemProducaoEnvioTerceirosClass > _collectionOrdemProducaoEnvioTerceirosClassTransporteRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoEnvioTerceirosClassTransporteLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoEnvioTerceirosClassTransporteChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoEnvioTerceirosClassTransporteCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemProducaoEnvioTerceirosClass> _valueCollectionOrdemProducaoEnvioTerceirosClassTransporte { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemProducaoEnvioTerceirosClass> CollectionOrdemProducaoEnvioTerceirosClassTransporte 
       { 
           get { if(!_valueCollectionOrdemProducaoEnvioTerceirosClassTransporteLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemProducaoEnvioTerceirosClassTransporte();}
return this._valueCollectionOrdemProducaoEnvioTerceirosClassTransporte; } 
           set 
           { 
               this._valueCollectionOrdemProducaoEnvioTerceirosClassTransporte = value; 
               this._valueCollectionOrdemProducaoEnvioTerceirosClassTransporteLoaded = true; 
           } 
       } 

       private List<long> _collectionPostoTrabalhoClassTransporteOriginal;
       private List<Entidades.PostoTrabalhoClass > _collectionPostoTrabalhoClassTransporteRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPostoTrabalhoClassTransporteLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPostoTrabalhoClassTransporteChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPostoTrabalhoClassTransporteCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PostoTrabalhoClass> _valueCollectionPostoTrabalhoClassTransporte { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PostoTrabalhoClass> CollectionPostoTrabalhoClassTransporte 
       { 
           get { if(!_valueCollectionPostoTrabalhoClassTransporteLoaded && !this.DisableLoadCollection){this.LoadCollectionPostoTrabalhoClassTransporte();}
return this._valueCollectionPostoTrabalhoClassTransporte; } 
           set 
           { 
               this._valueCollectionPostoTrabalhoClassTransporte = value; 
               this._valueCollectionPostoTrabalhoClassTransporteLoaded = true; 
           } 
       } 

        public TransporteBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static TransporteClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (TransporteClass) GetEntity(typeof(TransporteClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionEmbarqueClassTransporteChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionEmbarqueClassTransporteChanged = true;
                  _valueCollectionEmbarqueClassTransporteCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionEmbarqueClassTransporteChanged = true; 
                  _valueCollectionEmbarqueClassTransporteCommitedChanged = true;
                 foreach (Entidades.EmbarqueClass item in e.OldItems) 
                 { 
                     _collectionEmbarqueClassTransporteRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionEmbarqueClassTransporteChanged = true; 
                  _valueCollectionEmbarqueClassTransporteCommitedChanged = true;
                 foreach (Entidades.EmbarqueClass item in _valueCollectionEmbarqueClassTransporte) 
                 { 
                     _collectionEmbarqueClassTransporteRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionEmbarqueClassTransporte()
         {
            try
            {
                 ObservableCollection<Entidades.EmbarqueClass> oc;
                _valueCollectionEmbarqueClassTransporteChanged = false;
                 _valueCollectionEmbarqueClassTransporteCommitedChanged = false;
                _collectionEmbarqueClassTransporteRemovidos = new List<Entidades.EmbarqueClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.EmbarqueClass>();
                }
                else{ 
                   Entidades.EmbarqueClass search = new Entidades.EmbarqueClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.EmbarqueClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Transporte", this),                     }                       ).Cast<Entidades.EmbarqueClass>().ToList());
                 }
                 _valueCollectionEmbarqueClassTransporte = new BindingList<Entidades.EmbarqueClass>(oc); 
                 _collectionEmbarqueClassTransporteOriginal= (from a in _valueCollectionEmbarqueClassTransporte select a.ID).ToList();
                 _valueCollectionEmbarqueClassTransporteLoaded = true;
                 oc.CollectionChanged += CollectionEmbarqueClassTransporteChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionEmbarqueClassTransporte+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrdemProducaoEnvioTerceirosClassTransporteChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemProducaoEnvioTerceirosClassTransporteChanged = true;
                  _valueCollectionOrdemProducaoEnvioTerceirosClassTransporteCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemProducaoEnvioTerceirosClassTransporteChanged = true; 
                  _valueCollectionOrdemProducaoEnvioTerceirosClassTransporteCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoEnvioTerceirosClass item in e.OldItems) 
                 { 
                     _collectionOrdemProducaoEnvioTerceirosClassTransporteRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemProducaoEnvioTerceirosClassTransporteChanged = true; 
                  _valueCollectionOrdemProducaoEnvioTerceirosClassTransporteCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoEnvioTerceirosClass item in _valueCollectionOrdemProducaoEnvioTerceirosClassTransporte) 
                 { 
                     _collectionOrdemProducaoEnvioTerceirosClassTransporteRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemProducaoEnvioTerceirosClassTransporte()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemProducaoEnvioTerceirosClass> oc;
                _valueCollectionOrdemProducaoEnvioTerceirosClassTransporteChanged = false;
                 _valueCollectionOrdemProducaoEnvioTerceirosClassTransporteCommitedChanged = false;
                _collectionOrdemProducaoEnvioTerceirosClassTransporteRemovidos = new List<Entidades.OrdemProducaoEnvioTerceirosClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemProducaoEnvioTerceirosClass>();
                }
                else{ 
                   Entidades.OrdemProducaoEnvioTerceirosClass search = new Entidades.OrdemProducaoEnvioTerceirosClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemProducaoEnvioTerceirosClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Transporte", this),                     }                       ).Cast<Entidades.OrdemProducaoEnvioTerceirosClass>().ToList());
                 }
                 _valueCollectionOrdemProducaoEnvioTerceirosClassTransporte = new BindingList<Entidades.OrdemProducaoEnvioTerceirosClass>(oc); 
                 _collectionOrdemProducaoEnvioTerceirosClassTransporteOriginal= (from a in _valueCollectionOrdemProducaoEnvioTerceirosClassTransporte select a.ID).ToList();
                 _valueCollectionOrdemProducaoEnvioTerceirosClassTransporteLoaded = true;
                 oc.CollectionChanged += CollectionOrdemProducaoEnvioTerceirosClassTransporteChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemProducaoEnvioTerceirosClassTransporte+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPostoTrabalhoClassTransporteChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPostoTrabalhoClassTransporteChanged = true;
                  _valueCollectionPostoTrabalhoClassTransporteCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPostoTrabalhoClassTransporteChanged = true; 
                  _valueCollectionPostoTrabalhoClassTransporteCommitedChanged = true;
                 foreach (Entidades.PostoTrabalhoClass item in e.OldItems) 
                 { 
                     _collectionPostoTrabalhoClassTransporteRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPostoTrabalhoClassTransporteChanged = true; 
                  _valueCollectionPostoTrabalhoClassTransporteCommitedChanged = true;
                 foreach (Entidades.PostoTrabalhoClass item in _valueCollectionPostoTrabalhoClassTransporte) 
                 { 
                     _collectionPostoTrabalhoClassTransporteRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPostoTrabalhoClassTransporte()
         {
            try
            {
                 ObservableCollection<Entidades.PostoTrabalhoClass> oc;
                _valueCollectionPostoTrabalhoClassTransporteChanged = false;
                 _valueCollectionPostoTrabalhoClassTransporteCommitedChanged = false;
                _collectionPostoTrabalhoClassTransporteRemovidos = new List<Entidades.PostoTrabalhoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PostoTrabalhoClass>();
                }
                else{ 
                   Entidades.PostoTrabalhoClass search = new Entidades.PostoTrabalhoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PostoTrabalhoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Transporte", this),                     }                       ).Cast<Entidades.PostoTrabalhoClass>().ToList());
                 }
                 _valueCollectionPostoTrabalhoClassTransporte = new BindingList<Entidades.PostoTrabalhoClass>(oc); 
                 _collectionPostoTrabalhoClassTransporteOriginal= (from a in _valueCollectionPostoTrabalhoClassTransporte select a.ID).ToList();
                 _valueCollectionPostoTrabalhoClassTransporteLoaded = true;
                 oc.CollectionChanged += CollectionPostoTrabalhoClassTransporteChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPostoTrabalhoClassTransporte+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {

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
                    "  public.transporte  " +
                    "WHERE " +
                    "  id_transporte = :id";
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
                        "  public.transporte   " +
                        "SET  " + 
                        "  trp_razao = :trp_razao, " + 
                        "  trp_ie = :trp_ie, " + 
                        "  trp_endereco = :trp_endereco, " + 
                        "  trp_sigla_uf = :trp_sigla_uf, " + 
                        "  trp_municipio = :trp_municipio, " + 
                        "  trp_cpf_cnpj = :trp_cpf_cnpj, " + 
                        "  trp_placa = :trp_placa, " + 
                        "  trp_registro_antt = :trp_registro_antt, " + 
                        "  trp_sigla_uf_veiculo = :trp_sigla_uf_veiculo, " + 
                        "  trp_descricao = :trp_descricao, " + 
                        "  trp_identificacao = :trp_identificacao, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  id_cidade = :id_cidade, " + 
                        "  id_estado = :id_estado, " + 
                        "  id_estado_veiculo = :id_estado_veiculo, " + 
                        "  trp_contato = :trp_contato, " + 
                        "  trp_telefone = :trp_telefone, " + 
                        "  trp_email = :trp_email "+
                        "WHERE  " +
                        "  id_transporte = :id " +
                        "RETURNING id_transporte;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.transporte " +
                        "( " +
                        "  trp_razao , " + 
                        "  trp_ie , " + 
                        "  trp_endereco , " + 
                        "  trp_sigla_uf , " + 
                        "  trp_municipio , " + 
                        "  trp_cpf_cnpj , " + 
                        "  trp_placa , " + 
                        "  trp_registro_antt , " + 
                        "  trp_sigla_uf_veiculo , " + 
                        "  trp_descricao , " + 
                        "  trp_identificacao , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  id_cidade , " + 
                        "  id_estado , " + 
                        "  id_estado_veiculo , " + 
                        "  trp_contato , " + 
                        "  trp_telefone , " + 
                        "  trp_email  "+
                        ")  " +
                        "VALUES ( " +
                        "  :trp_razao , " + 
                        "  :trp_ie , " + 
                        "  :trp_endereco , " + 
                        "  :trp_sigla_uf , " + 
                        "  :trp_municipio , " + 
                        "  :trp_cpf_cnpj , " + 
                        "  :trp_placa , " + 
                        "  :trp_registro_antt , " + 
                        "  :trp_sigla_uf_veiculo , " + 
                        "  :trp_descricao , " + 
                        "  :trp_identificacao , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :id_cidade , " + 
                        "  :id_estado , " + 
                        "  :id_estado_veiculo , " + 
                        "  :trp_contato , " + 
                        "  :trp_telefone , " + 
                        "  :trp_email  "+
                        ")RETURNING id_transporte;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("trp_razao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Razao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("trp_ie", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Ie ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("trp_endereco", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Endereco ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("trp_sigla_uf", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.SiglaUf ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("trp_municipio", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Municipio ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("trp_cpf_cnpj", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CpfCnpj ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("trp_placa", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Placa ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("trp_registro_antt", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.RegistroAntt ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("trp_sigla_uf_veiculo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.SiglaUfVeiculo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("trp_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Descricao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("trp_identificacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Identificacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_cidade", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Cidade==null ? (object) DBNull.Value : this.Cidade.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_estado", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Estado==null ? (object) DBNull.Value : this.Estado.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_estado_veiculo", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.EstadoVeiculo==null ? (object) DBNull.Value : this.EstadoVeiculo.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("trp_contato", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Contato ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("trp_telefone", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Telefone ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("trp_email", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Email ?? DBNull.Value;

 
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
 if (CollectionEmbarqueClassTransporte.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionEmbarqueClassTransporte+"\r\n";
                foreach (Entidades.EmbarqueClass tmp in CollectionEmbarqueClassTransporte)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrdemProducaoEnvioTerceirosClassTransporte.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemProducaoEnvioTerceirosClassTransporte+"\r\n";
                foreach (Entidades.OrdemProducaoEnvioTerceirosClass tmp in CollectionOrdemProducaoEnvioTerceirosClassTransporte)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPostoTrabalhoClassTransporte.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPostoTrabalhoClassTransporte+"\r\n";
                foreach (Entidades.PostoTrabalhoClass tmp in CollectionPostoTrabalhoClassTransporte)
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
        public static TransporteClass CopiarEntidade(TransporteClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               TransporteClass toRet = new TransporteClass(usuario,conn);
 toRet.Razao= entidadeCopiar.Razao;
 toRet.Ie= entidadeCopiar.Ie;
 toRet.Endereco= entidadeCopiar.Endereco;
 toRet.SiglaUf= entidadeCopiar.SiglaUf;
 toRet.Municipio= entidadeCopiar.Municipio;
 toRet.CpfCnpj= entidadeCopiar.CpfCnpj;
 toRet.Placa= entidadeCopiar.Placa;
 toRet.RegistroAntt= entidadeCopiar.RegistroAntt;
 toRet.SiglaUfVeiculo= entidadeCopiar.SiglaUfVeiculo;
 toRet.Descricao= entidadeCopiar.Descricao;
 toRet.Identificacao= entidadeCopiar.Identificacao;
 toRet.Cidade= entidadeCopiar.Cidade;
 toRet.Estado= entidadeCopiar.Estado;
 toRet.EstadoVeiculo= entidadeCopiar.EstadoVeiculo;
 toRet.Contato= entidadeCopiar.Contato;
 toRet.Telefone= entidadeCopiar.Telefone;
 toRet.Email= entidadeCopiar.Email;

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
       _razaoOriginal = Razao;
       _razaoOriginalCommited = _razaoOriginal;
       _ieOriginal = Ie;
       _ieOriginalCommited = _ieOriginal;
       _enderecoOriginal = Endereco;
       _enderecoOriginalCommited = _enderecoOriginal;
       _siglaUfOriginal = SiglaUf;
       _siglaUfOriginalCommited = _siglaUfOriginal;
       _municipioOriginal = Municipio;
       _municipioOriginalCommited = _municipioOriginal;
       _cpfCnpjOriginal = CpfCnpj;
       _cpfCnpjOriginalCommited = _cpfCnpjOriginal;
       _placaOriginal = Placa;
       _placaOriginalCommited = _placaOriginal;
       _registroAnttOriginal = RegistroAntt;
       _registroAnttOriginalCommited = _registroAnttOriginal;
       _siglaUfVeiculoOriginal = SiglaUfVeiculo;
       _siglaUfVeiculoOriginalCommited = _siglaUfVeiculoOriginal;
       _descricaoOriginal = Descricao;
       _descricaoOriginalCommited = _descricaoOriginal;
       _identificacaoOriginal = Identificacao;
       _identificacaoOriginalCommited = _identificacaoOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _cidadeOriginal = Cidade;
       _cidadeOriginalCommited = _cidadeOriginal;
       _estadoOriginal = Estado;
       _estadoOriginalCommited = _estadoOriginal;
       _estadoVeiculoOriginal = EstadoVeiculo;
       _estadoVeiculoOriginalCommited = _estadoVeiculoOriginal;
       _contatoOriginal = Contato;
       _contatoOriginalCommited = _contatoOriginal;
       _telefoneOriginal = Telefone;
       _telefoneOriginalCommited = _telefoneOriginal;
       _emailOriginal = Email;
       _emailOriginalCommited = _emailOriginal;

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
       _razaoOriginalCommited = Razao;
       _ieOriginalCommited = Ie;
       _enderecoOriginalCommited = Endereco;
       _siglaUfOriginalCommited = SiglaUf;
       _municipioOriginalCommited = Municipio;
       _cpfCnpjOriginalCommited = CpfCnpj;
       _placaOriginalCommited = Placa;
       _registroAnttOriginalCommited = RegistroAntt;
       _siglaUfVeiculoOriginalCommited = SiglaUfVeiculo;
       _descricaoOriginalCommited = Descricao;
       _identificacaoOriginalCommited = Identificacao;
       _versionOriginalCommited = Version;
       _cidadeOriginalCommited = Cidade;
       _estadoOriginalCommited = Estado;
       _estadoVeiculoOriginalCommited = EstadoVeiculo;
       _contatoOriginalCommited = Contato;
       _telefoneOriginalCommited = Telefone;
       _emailOriginalCommited = Email;

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
               if (_valueCollectionEmbarqueClassTransporteLoaded) 
               {
                  if (_collectionEmbarqueClassTransporteRemovidos != null) 
                  {
                     _collectionEmbarqueClassTransporteRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionEmbarqueClassTransporteRemovidos = new List<Entidades.EmbarqueClass>();
                  }
                  _collectionEmbarqueClassTransporteOriginal= (from a in _valueCollectionEmbarqueClassTransporte select a.ID).ToList();
                  _valueCollectionEmbarqueClassTransporteChanged = false;
                  _valueCollectionEmbarqueClassTransporteCommitedChanged = false;
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosClassTransporteLoaded) 
               {
                  if (_collectionOrdemProducaoEnvioTerceirosClassTransporteRemovidos != null) 
                  {
                     _collectionOrdemProducaoEnvioTerceirosClassTransporteRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemProducaoEnvioTerceirosClassTransporteRemovidos = new List<Entidades.OrdemProducaoEnvioTerceirosClass>();
                  }
                  _collectionOrdemProducaoEnvioTerceirosClassTransporteOriginal= (from a in _valueCollectionOrdemProducaoEnvioTerceirosClassTransporte select a.ID).ToList();
                  _valueCollectionOrdemProducaoEnvioTerceirosClassTransporteChanged = false;
                  _valueCollectionOrdemProducaoEnvioTerceirosClassTransporteCommitedChanged = false;
               }
               if (_valueCollectionPostoTrabalhoClassTransporteLoaded) 
               {
                  if (_collectionPostoTrabalhoClassTransporteRemovidos != null) 
                  {
                     _collectionPostoTrabalhoClassTransporteRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPostoTrabalhoClassTransporteRemovidos = new List<Entidades.PostoTrabalhoClass>();
                  }
                  _collectionPostoTrabalhoClassTransporteOriginal= (from a in _valueCollectionPostoTrabalhoClassTransporte select a.ID).ToList();
                  _valueCollectionPostoTrabalhoClassTransporteChanged = false;
                  _valueCollectionPostoTrabalhoClassTransporteCommitedChanged = false;
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
               Razao=_razaoOriginal;
               _razaoOriginalCommited=_razaoOriginal;
               Ie=_ieOriginal;
               _ieOriginalCommited=_ieOriginal;
               Endereco=_enderecoOriginal;
               _enderecoOriginalCommited=_enderecoOriginal;
               SiglaUf=_siglaUfOriginal;
               _siglaUfOriginalCommited=_siglaUfOriginal;
               Municipio=_municipioOriginal;
               _municipioOriginalCommited=_municipioOriginal;
               CpfCnpj=_cpfCnpjOriginal;
               _cpfCnpjOriginalCommited=_cpfCnpjOriginal;
               Placa=_placaOriginal;
               _placaOriginalCommited=_placaOriginal;
               RegistroAntt=_registroAnttOriginal;
               _registroAnttOriginalCommited=_registroAnttOriginal;
               SiglaUfVeiculo=_siglaUfVeiculoOriginal;
               _siglaUfVeiculoOriginalCommited=_siglaUfVeiculoOriginal;
               Descricao=_descricaoOriginal;
               _descricaoOriginalCommited=_descricaoOriginal;
               Identificacao=_identificacaoOriginal;
               _identificacaoOriginalCommited=_identificacaoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               Cidade=_cidadeOriginal;
               _cidadeOriginalCommited=_cidadeOriginal;
               Estado=_estadoOriginal;
               _estadoOriginalCommited=_estadoOriginal;
               EstadoVeiculo=_estadoVeiculoOriginal;
               _estadoVeiculoOriginalCommited=_estadoVeiculoOriginal;
               Contato=_contatoOriginal;
               _contatoOriginalCommited=_contatoOriginal;
               Telefone=_telefoneOriginal;
               _telefoneOriginalCommited=_telefoneOriginal;
               Email=_emailOriginal;
               _emailOriginalCommited=_emailOriginal;
               if (_valueCollectionEmbarqueClassTransporteLoaded) 
               {
                  CollectionEmbarqueClassTransporte.Clear();
                  foreach(int item in _collectionEmbarqueClassTransporteOriginal)
                  {
                    CollectionEmbarqueClassTransporte.Add(Entidades.EmbarqueClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionEmbarqueClassTransporteRemovidos.Clear();
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosClassTransporteLoaded) 
               {
                  CollectionOrdemProducaoEnvioTerceirosClassTransporte.Clear();
                  foreach(int item in _collectionOrdemProducaoEnvioTerceirosClassTransporteOriginal)
                  {
                    CollectionOrdemProducaoEnvioTerceirosClassTransporte.Add(Entidades.OrdemProducaoEnvioTerceirosClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemProducaoEnvioTerceirosClassTransporteRemovidos.Clear();
               }
               if (_valueCollectionPostoTrabalhoClassTransporteLoaded) 
               {
                  CollectionPostoTrabalhoClassTransporte.Clear();
                  foreach(int item in _collectionPostoTrabalhoClassTransporteOriginal)
                  {
                    CollectionPostoTrabalhoClassTransporte.Add(Entidades.PostoTrabalhoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPostoTrabalhoClassTransporteRemovidos.Clear();
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
               if (_valueCollectionEmbarqueClassTransporteLoaded) 
               {
                  if (_valueCollectionEmbarqueClassTransporteChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosClassTransporteLoaded) 
               {
                  if (_valueCollectionOrdemProducaoEnvioTerceirosClassTransporteChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPostoTrabalhoClassTransporteLoaded) 
               {
                  if (_valueCollectionPostoTrabalhoClassTransporteChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionEmbarqueClassTransporteLoaded) 
               {
                   tempRet = CollectionEmbarqueClassTransporte.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosClassTransporteLoaded) 
               {
                   tempRet = CollectionOrdemProducaoEnvioTerceirosClassTransporte.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPostoTrabalhoClassTransporteLoaded) 
               {
                   tempRet = CollectionPostoTrabalhoClassTransporte.Any(item => item.IsDirty());
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
       dirty = _razaoOriginal != Razao;
      if (dirty) return true;
       dirty = _ieOriginal != Ie;
      if (dirty) return true;
       dirty = _enderecoOriginal != Endereco;
      if (dirty) return true;
       dirty = _siglaUfOriginal != SiglaUf;
      if (dirty) return true;
       dirty = _municipioOriginal != Municipio;
      if (dirty) return true;
       dirty = _cpfCnpjOriginal != CpfCnpj;
      if (dirty) return true;
       dirty = _placaOriginal != Placa;
      if (dirty) return true;
       dirty = _registroAnttOriginal != RegistroAntt;
      if (dirty) return true;
       dirty = _siglaUfVeiculoOriginal != SiglaUfVeiculo;
      if (dirty) return true;
       dirty = _descricaoOriginal != Descricao;
      if (dirty) return true;
       dirty = _identificacaoOriginal != Identificacao;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
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
       if (_estadoOriginal!=null)
       {
          dirty = !_estadoOriginal.Equals(Estado);
       }
       else
       {
            dirty = Estado != null;
       }
      if (dirty) return true;
       if (_estadoVeiculoOriginal!=null)
       {
          dirty = !_estadoVeiculoOriginal.Equals(EstadoVeiculo);
       }
       else
       {
            dirty = EstadoVeiculo != null;
       }
      if (dirty) return true;
       dirty = _contatoOriginal != Contato;
      if (dirty) return true;
       dirty = _telefoneOriginal != Telefone;
      if (dirty) return true;
       dirty = _emailOriginal != Email;

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
               if (_valueCollectionEmbarqueClassTransporteLoaded) 
               {
                  if (_valueCollectionEmbarqueClassTransporteCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosClassTransporteLoaded) 
               {
                  if (_valueCollectionOrdemProducaoEnvioTerceirosClassTransporteCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPostoTrabalhoClassTransporteLoaded) 
               {
                  if (_valueCollectionPostoTrabalhoClassTransporteCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionEmbarqueClassTransporteLoaded) 
               {
                   tempRet = CollectionEmbarqueClassTransporte.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosClassTransporteLoaded) 
               {
                   tempRet = CollectionOrdemProducaoEnvioTerceirosClassTransporte.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPostoTrabalhoClassTransporteLoaded) 
               {
                   tempRet = CollectionPostoTrabalhoClassTransporte.Any(item => item.IsDirtyCommited());
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
       dirty = _razaoOriginalCommited != Razao;
      if (dirty) return true;
       dirty = _ieOriginalCommited != Ie;
      if (dirty) return true;
       dirty = _enderecoOriginalCommited != Endereco;
      if (dirty) return true;
       dirty = _siglaUfOriginalCommited != SiglaUf;
      if (dirty) return true;
       dirty = _municipioOriginalCommited != Municipio;
      if (dirty) return true;
       dirty = _cpfCnpjOriginalCommited != CpfCnpj;
      if (dirty) return true;
       dirty = _placaOriginalCommited != Placa;
      if (dirty) return true;
       dirty = _registroAnttOriginalCommited != RegistroAntt;
      if (dirty) return true;
       dirty = _siglaUfVeiculoOriginalCommited != SiglaUfVeiculo;
      if (dirty) return true;
       dirty = _descricaoOriginalCommited != Descricao;
      if (dirty) return true;
       dirty = _identificacaoOriginalCommited != Identificacao;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
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
       if (_estadoOriginalCommited!=null)
       {
          dirty = !_estadoOriginalCommited.Equals(Estado);
       }
       else
       {
            dirty = Estado != null;
       }
      if (dirty) return true;
       if (_estadoVeiculoOriginalCommited!=null)
       {
          dirty = !_estadoVeiculoOriginalCommited.Equals(EstadoVeiculo);
       }
       else
       {
            dirty = EstadoVeiculo != null;
       }
      if (dirty) return true;
       dirty = _contatoOriginalCommited != Contato;
      if (dirty) return true;
       dirty = _telefoneOriginalCommited != Telefone;
      if (dirty) return true;
       dirty = _emailOriginalCommited != Email;

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
               if (_valueCollectionEmbarqueClassTransporteLoaded) 
               {
                  foreach(EmbarqueClass item in CollectionEmbarqueClassTransporte)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosClassTransporteLoaded) 
               {
                  foreach(OrdemProducaoEnvioTerceirosClass item in CollectionOrdemProducaoEnvioTerceirosClassTransporte)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPostoTrabalhoClassTransporteLoaded) 
               {
                  foreach(PostoTrabalhoClass item in CollectionPostoTrabalhoClassTransporte)
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
             case "Razao":
                return this.Razao;
             case "Ie":
                return this.Ie;
             case "Endereco":
                return this.Endereco;
             case "SiglaUf":
                return this.SiglaUf;
             case "Municipio":
                return this.Municipio;
             case "CpfCnpj":
                return this.CpfCnpj;
             case "Placa":
                return this.Placa;
             case "RegistroAntt":
                return this.RegistroAntt;
             case "SiglaUfVeiculo":
                return this.SiglaUfVeiculo;
             case "Descricao":
                return this.Descricao;
             case "Identificacao":
                return this.Identificacao;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "Cidade":
                return this.Cidade;
             case "Estado":
                return this.Estado;
             case "EstadoVeiculo":
                return this.EstadoVeiculo;
             case "Contato":
                return this.Contato;
             case "Telefone":
                return this.Telefone;
             case "Email":
                return this.Email;
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
             if (Estado!=null)
                Estado.ChangeSingleConnection(newConnection);
             if (EstadoVeiculo!=null)
                EstadoVeiculo.ChangeSingleConnection(newConnection);
               if (_valueCollectionEmbarqueClassTransporteLoaded) 
               {
                  foreach(EmbarqueClass item in CollectionEmbarqueClassTransporte)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosClassTransporteLoaded) 
               {
                  foreach(OrdemProducaoEnvioTerceirosClass item in CollectionOrdemProducaoEnvioTerceirosClassTransporte)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPostoTrabalhoClassTransporteLoaded) 
               {
                  foreach(PostoTrabalhoClass item in CollectionPostoTrabalhoClassTransporte)
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
                  command.CommandText += " COUNT(transporte.id_transporte) " ;
               }
               else
               {
               command.CommandText += "transporte.id_transporte, " ;
               command.CommandText += "transporte.trp_razao, " ;
               command.CommandText += "transporte.trp_ie, " ;
               command.CommandText += "transporte.trp_endereco, " ;
               command.CommandText += "transporte.trp_sigla_uf, " ;
               command.CommandText += "transporte.trp_municipio, " ;
               command.CommandText += "transporte.trp_cpf_cnpj, " ;
               command.CommandText += "transporte.trp_placa, " ;
               command.CommandText += "transporte.trp_registro_antt, " ;
               command.CommandText += "transporte.trp_sigla_uf_veiculo, " ;
               command.CommandText += "transporte.trp_descricao, " ;
               command.CommandText += "transporte.trp_identificacao, " ;
               command.CommandText += "transporte.entity_uid, " ;
               command.CommandText += "transporte.version, " ;
               command.CommandText += "transporte.id_cidade, " ;
               command.CommandText += "transporte.id_estado, " ;
               command.CommandText += "transporte.id_estado_veiculo, " ;
               command.CommandText += "transporte.trp_contato, " ;
               command.CommandText += "transporte.trp_telefone, " ;
               command.CommandText += "transporte.trp_email " ;
               }
               command.CommandText += " FROM  transporte ";
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
                        orderByClause += " , trp_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(trp_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = transporte.id_acs_usuario_ultima_revisao ";
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
                     case "id_transporte":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , transporte.id_transporte " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(transporte.id_transporte) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "trp_razao":
                     case "Razao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , transporte.trp_razao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(transporte.trp_razao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "trp_ie":
                     case "Ie":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , transporte.trp_ie " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(transporte.trp_ie) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "trp_endereco":
                     case "Endereco":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , transporte.trp_endereco " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(transporte.trp_endereco) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "trp_sigla_uf":
                     case "SiglaUf":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , transporte.trp_sigla_uf " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(transporte.trp_sigla_uf) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "trp_municipio":
                     case "Municipio":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , transporte.trp_municipio " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(transporte.trp_municipio) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "trp_cpf_cnpj":
                     case "CpfCnpj":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , transporte.trp_cpf_cnpj " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(transporte.trp_cpf_cnpj) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "trp_placa":
                     case "Placa":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , transporte.trp_placa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(transporte.trp_placa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "trp_registro_antt":
                     case "RegistroAntt":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , transporte.trp_registro_antt " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(transporte.trp_registro_antt) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "trp_sigla_uf_veiculo":
                     case "SiglaUfVeiculo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , transporte.trp_sigla_uf_veiculo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(transporte.trp_sigla_uf_veiculo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "trp_descricao":
                     case "Descricao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , transporte.trp_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(transporte.trp_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "trp_identificacao":
                     case "Identificacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , transporte.trp_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(transporte.trp_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , transporte.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(transporte.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , transporte.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(transporte.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_cidade":
                     case "Cidade":
                     command.CommandText += " LEFT JOIN cidade as cidade_Cidade ON cidade_Cidade.id_cidade = transporte.id_cidade ";                     switch (parametro.TipoOrdenacao)
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
                     case "id_estado":
                     case "Estado":
                     command.CommandText += " LEFT JOIN estado as estado_Estado ON estado_Estado.id_estado = transporte.id_estado ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , estado_Estado.est_sigla " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(estado_Estado.est_sigla) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , estado_Estado.est_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(estado_Estado.est_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_estado_veiculo":
                     case "EstadoVeiculo":
                     command.CommandText += " LEFT JOIN estado as estado_EstadoVeiculo ON estado_EstadoVeiculo.id_estado = transporte.id_estado_veiculo ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , estado_EstadoVeiculo.est_sigla " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(estado_EstadoVeiculo.est_sigla) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , estado_EstadoVeiculo.est_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(estado_EstadoVeiculo.est_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "trp_contato":
                     case "Contato":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , transporte.trp_contato " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(transporte.trp_contato) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "trp_telefone":
                     case "Telefone":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , transporte.trp_telefone " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(transporte.trp_telefone) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "trp_email":
                     case "Email":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , transporte.trp_email " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(transporte.trp_email) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("trp_razao")) 
                        {
                           whereClause += " OR UPPER(transporte.trp_razao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(transporte.trp_razao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("trp_ie")) 
                        {
                           whereClause += " OR UPPER(transporte.trp_ie) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(transporte.trp_ie) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("trp_endereco")) 
                        {
                           whereClause += " OR UPPER(transporte.trp_endereco) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(transporte.trp_endereco) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("trp_sigla_uf")) 
                        {
                           whereClause += " OR UPPER(transporte.trp_sigla_uf) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(transporte.trp_sigla_uf) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("trp_municipio")) 
                        {
                           whereClause += " OR UPPER(transporte.trp_municipio) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(transporte.trp_municipio) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("trp_cpf_cnpj")) 
                        {
                           whereClause += " OR UPPER(transporte.trp_cpf_cnpj) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(transporte.trp_cpf_cnpj) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("trp_placa")) 
                        {
                           whereClause += " OR UPPER(transporte.trp_placa) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(transporte.trp_placa) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("trp_registro_antt")) 
                        {
                           whereClause += " OR UPPER(transporte.trp_registro_antt) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(transporte.trp_registro_antt) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("trp_sigla_uf_veiculo")) 
                        {
                           whereClause += " OR UPPER(transporte.trp_sigla_uf_veiculo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(transporte.trp_sigla_uf_veiculo) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("trp_descricao")) 
                        {
                           whereClause += " OR UPPER(transporte.trp_descricao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(transporte.trp_descricao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("trp_identificacao")) 
                        {
                           whereClause += " OR UPPER(transporte.trp_identificacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(transporte.trp_identificacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(transporte.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(transporte.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("trp_contato")) 
                        {
                           whereClause += " OR UPPER(transporte.trp_contato) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(transporte.trp_contato) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("trp_telefone")) 
                        {
                           whereClause += " OR UPPER(transporte.trp_telefone) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(transporte.trp_telefone) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("trp_email")) 
                        {
                           whereClause += " OR UPPER(transporte.trp_email) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(transporte.trp_email) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_transporte")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  transporte.id_transporte IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transporte.id_transporte = :transporte_ID_7022 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transporte_ID_7022", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Razao" || parametro.FieldName == "trp_razao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  transporte.trp_razao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transporte.trp_razao LIKE :transporte_Razao_8008 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transporte_Razao_8008", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Ie" || parametro.FieldName == "trp_ie")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  transporte.trp_ie IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transporte.trp_ie LIKE :transporte_Ie_6187 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transporte_Ie_6187", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Endereco" || parametro.FieldName == "trp_endereco")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  transporte.trp_endereco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transporte.trp_endereco LIKE :transporte_Endereco_4463 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transporte_Endereco_4463", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SiglaUf" || parametro.FieldName == "trp_sigla_uf")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  transporte.trp_sigla_uf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transporte.trp_sigla_uf LIKE :transporte_SiglaUf_3997 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transporte_SiglaUf_3997", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Municipio" || parametro.FieldName == "trp_municipio")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  transporte.trp_municipio IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transporte.trp_municipio LIKE :transporte_Municipio_3813 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transporte_Municipio_3813", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CpfCnpj" || parametro.FieldName == "trp_cpf_cnpj")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  transporte.trp_cpf_cnpj IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transporte.trp_cpf_cnpj LIKE :transporte_CpfCnpj_4143 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transporte_CpfCnpj_4143", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Placa" || parametro.FieldName == "trp_placa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  transporte.trp_placa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transporte.trp_placa LIKE :transporte_Placa_7344 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transporte_Placa_7344", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RegistroAntt" || parametro.FieldName == "trp_registro_antt")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  transporte.trp_registro_antt IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transporte.trp_registro_antt LIKE :transporte_RegistroAntt_9363 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transporte_RegistroAntt_9363", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SiglaUfVeiculo" || parametro.FieldName == "trp_sigla_uf_veiculo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  transporte.trp_sigla_uf_veiculo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transporte.trp_sigla_uf_veiculo LIKE :transporte_SiglaUfVeiculo_2342 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transporte_SiglaUfVeiculo_2342", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Descricao" || parametro.FieldName == "trp_descricao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  transporte.trp_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transporte.trp_descricao LIKE :transporte_Descricao_9059 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transporte_Descricao_9059", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Identificacao" || parametro.FieldName == "trp_identificacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  transporte.trp_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transporte.trp_identificacao LIKE :transporte_Identificacao_5400 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transporte_Identificacao_5400", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  transporte.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transporte.entity_uid LIKE :transporte_EntityUid_8259 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transporte_EntityUid_8259", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  transporte.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transporte.version = :transporte_Version_9535 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transporte_Version_9535", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  transporte.id_cidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transporte.id_cidade = :transporte_Cidade_7592 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transporte_Cidade_7592", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Estado" || parametro.FieldName == "id_estado")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.EstadoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.EstadoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  transporte.id_estado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transporte.id_estado = :transporte_Estado_4498 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transporte_Estado_4498", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EstadoVeiculo" || parametro.FieldName == "id_estado_veiculo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.EstadoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.EstadoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  transporte.id_estado_veiculo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transporte.id_estado_veiculo = :transporte_EstadoVeiculo_6370 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transporte_EstadoVeiculo_6370", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Contato" || parametro.FieldName == "trp_contato")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  transporte.trp_contato IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transporte.trp_contato LIKE :transporte_Contato_5728 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transporte_Contato_5728", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Telefone" || parametro.FieldName == "trp_telefone")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  transporte.trp_telefone IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transporte.trp_telefone LIKE :transporte_Telefone_7354 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transporte_Telefone_7354", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Email" || parametro.FieldName == "trp_email")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  transporte.trp_email IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transporte.trp_email LIKE :transporte_Email_210 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transporte_Email_210", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RazaoExato" || parametro.FieldName == "RazaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  transporte.trp_razao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transporte.trp_razao LIKE :transporte_Razao_485 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transporte_Razao_485", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IeExato" || parametro.FieldName == "IeExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  transporte.trp_ie IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transporte.trp_ie LIKE :transporte_Ie_2947 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transporte_Ie_2947", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  transporte.trp_endereco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transporte.trp_endereco LIKE :transporte_Endereco_9346 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transporte_Endereco_9346", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SiglaUfExato" || parametro.FieldName == "SiglaUfExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  transporte.trp_sigla_uf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transporte.trp_sigla_uf LIKE :transporte_SiglaUf_3810 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transporte_SiglaUf_3810", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MunicipioExato" || parametro.FieldName == "MunicipioExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  transporte.trp_municipio IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transporte.trp_municipio LIKE :transporte_Municipio_1526 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transporte_Municipio_1526", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CpfCnpjExato" || parametro.FieldName == "CpfCnpjExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  transporte.trp_cpf_cnpj IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transporte.trp_cpf_cnpj LIKE :transporte_CpfCnpj_8135 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transporte_CpfCnpj_8135", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  transporte.trp_placa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transporte.trp_placa LIKE :transporte_Placa_4007 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transporte_Placa_4007", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RegistroAnttExato" || parametro.FieldName == "RegistroAnttExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  transporte.trp_registro_antt IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transporte.trp_registro_antt LIKE :transporte_RegistroAntt_7131 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transporte_RegistroAntt_7131", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SiglaUfVeiculoExato" || parametro.FieldName == "SiglaUfVeiculoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  transporte.trp_sigla_uf_veiculo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transporte.trp_sigla_uf_veiculo LIKE :transporte_SiglaUfVeiculo_8046 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transporte_SiglaUfVeiculo_8046", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  transporte.trp_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transporte.trp_descricao LIKE :transporte_Descricao_8047 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transporte_Descricao_8047", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  transporte.trp_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transporte.trp_identificacao LIKE :transporte_Identificacao_1008 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transporte_Identificacao_1008", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  transporte.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transporte.entity_uid LIKE :transporte_EntityUid_8875 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transporte_EntityUid_8875", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ContatoExato" || parametro.FieldName == "ContatoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  transporte.trp_contato IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transporte.trp_contato LIKE :transporte_Contato_9914 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transporte_Contato_9914", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TelefoneExato" || parametro.FieldName == "TelefoneExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  transporte.trp_telefone IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transporte.trp_telefone LIKE :transporte_Telefone_4839 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transporte_Telefone_4839", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  transporte.trp_email IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transporte.trp_email LIKE :transporte_Email_169 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transporte_Email_169", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  TransporteClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (TransporteClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(TransporteClass), Convert.ToInt32(read["id_transporte"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new TransporteClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_transporte"]);
                     entidade.Razao = (read["trp_razao"] != DBNull.Value ? read["trp_razao"].ToString() : null);
                     entidade.Ie = (read["trp_ie"] != DBNull.Value ? read["trp_ie"].ToString() : null);
                     entidade.Endereco = (read["trp_endereco"] != DBNull.Value ? read["trp_endereco"].ToString() : null);
                     entidade.SiglaUf = (read["trp_sigla_uf"] != DBNull.Value ? read["trp_sigla_uf"].ToString() : null);
                     entidade.Municipio = (read["trp_municipio"] != DBNull.Value ? read["trp_municipio"].ToString() : null);
                     entidade.CpfCnpj = (read["trp_cpf_cnpj"] != DBNull.Value ? read["trp_cpf_cnpj"].ToString() : null);
                     entidade.Placa = (read["trp_placa"] != DBNull.Value ? read["trp_placa"].ToString() : null);
                     entidade.RegistroAntt = (read["trp_registro_antt"] != DBNull.Value ? read["trp_registro_antt"].ToString() : null);
                     entidade.SiglaUfVeiculo = (read["trp_sigla_uf_veiculo"] != DBNull.Value ? read["trp_sigla_uf_veiculo"].ToString() : null);
                     entidade.Descricao = (read["trp_descricao"] != DBNull.Value ? read["trp_descricao"].ToString() : null);
                     entidade.Identificacao = (read["trp_identificacao"] != DBNull.Value ? read["trp_identificacao"].ToString() : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     if (read["id_cidade"] != DBNull.Value)
                     {
                        entidade.Cidade = (BibliotecaEntidades.Entidades.CidadeClass)BibliotecaEntidades.Entidades.CidadeClass.GetEntidade(Convert.ToInt32(read["id_cidade"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Cidade = null ;
                     }
                     if (read["id_estado"] != DBNull.Value)
                     {
                        entidade.Estado = (BibliotecaEntidades.Entidades.EstadoClass)BibliotecaEntidades.Entidades.EstadoClass.GetEntidade(Convert.ToInt32(read["id_estado"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Estado = null ;
                     }
                     if (read["id_estado_veiculo"] != DBNull.Value)
                     {
                        entidade.EstadoVeiculo = (BibliotecaEntidades.Entidades.EstadoClass)BibliotecaEntidades.Entidades.EstadoClass.GetEntidade(Convert.ToInt32(read["id_estado_veiculo"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.EstadoVeiculo = null ;
                     }
                     entidade.Contato = (read["trp_contato"] != DBNull.Value ? read["trp_contato"].ToString() : null);
                     entidade.Telefone = (read["trp_telefone"] != DBNull.Value ? read["trp_telefone"].ToString() : null);
                     entidade.Email = (read["trp_email"] != DBNull.Value ? read["trp_email"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (TransporteClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
