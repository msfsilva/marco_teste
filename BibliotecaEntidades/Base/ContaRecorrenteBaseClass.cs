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
     [Table("conta_recorrente","crr")]
     public class ContaRecorrenteBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do ContaRecorrenteClass";
protected const string ErroDelete = "Erro ao excluir o ContaRecorrenteClass  ";
protected const string ErroSave = "Erro ao salvar o ContaRecorrenteClass.";
protected const string ErroCollectionContaPagarClassContaRecorrente = "Erro ao carregar a coleção de ContaPagarClass.";
protected const string ErroCollectionContaReceberClassContaRecorrente = "Erro ao carregar a coleção de ContaReceberClass.";
protected const string ErroHistoricoObrigatorio = "O campo Historico é obrigatório";
protected const string ErroHistoricoComprimento = "O campo Historico deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroContaBancariaObrigatorio = "O campo ContaBancaria é obrigatório";
protected const string ErroCentroCustoLucroObrigatorio = "O campo CentroCustoLucro é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do ContaRecorrenteClass.";
protected const string MensagemUtilizadoCollectionContaPagarClassContaRecorrente =  "A entidade ContaRecorrenteClass está sendo utilizada nos seguintes ContaPagarClass:";
protected const string MensagemUtilizadoCollectionContaReceberClassContaRecorrente =  "A entidade ContaRecorrenteClass está sendo utilizada nos seguintes ContaReceberClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade ContaRecorrenteClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.TipoPagamentoClass _tipoPagamentoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.TipoPagamentoClass _tipoPagamentoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.TipoPagamentoClass _valueTipoPagamento;
        [Column("id_tipo_pagamento", "tipo_pagamento", "id_tipo_pagamento")]
       public virtual BibliotecaEntidades.Entidades.TipoPagamentoClass TipoPagamento
        { 
           get {                 return this._valueTipoPagamento; } 
           set 
           { 
                if (this._valueTipoPagamento == value)return;
                 this._valueTipoPagamento = value; 
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

       protected TipoContaRecorrente _tipoOriginal{get;private set;}
       private TipoContaRecorrente _tipoOriginalCommited{get; set;}
        private TipoContaRecorrente _valueTipo;
         [Column("crr_tipo")]
        public virtual TipoContaRecorrente Tipo
         { 
            get { return this._valueTipo; } 
            set 
            { 
                if (this._valueTipo == value)return;
                 this._valueTipo = value; 
            } 
        } 

        public bool Tipo_ValorFixo
         { 
            get { return this._valueTipo == BibliotecaEntidades.Base.TipoContaRecorrente.ValorFixo; } 
            set { if (value) this._valueTipo = BibliotecaEntidades.Base.TipoContaRecorrente.ValorFixo; }
         } 

        public bool Tipo_Media
         { 
            get { return this._valueTipo == BibliotecaEntidades.Base.TipoContaRecorrente.Media; } 
            set { if (value) this._valueTipo = BibliotecaEntidades.Base.TipoContaRecorrente.Media; }
         } 

        public bool Tipo_ValorDefinir
         { 
            get { return this._valueTipo == BibliotecaEntidades.Base.TipoContaRecorrente.ValorDefinir; } 
            set { if (value) this._valueTipo = BibliotecaEntidades.Base.TipoContaRecorrente.ValorDefinir; }
         } 

       protected double? _valorFixoOriginal{get;private set;}
       private double? _valorFixoOriginalCommited{get; set;}
        private double? _valueValorFixo;
         [Column("crr_valor_fixo")]
        public virtual double? ValorFixo
         { 
            get { return this._valueValorFixo; } 
            set 
            { 
                if (this._valueValorFixo == value)return;
                 this._valueValorFixo = value; 
            } 
        } 

       protected string _historicoOriginal{get;private set;}
       private string _historicoOriginalCommited{get; set;}
        private string _valueHistorico;
         [Column("crr_historico")]
        public virtual string Historico
         { 
            get { return this._valueHistorico; } 
            set 
            { 
                if (this._valueHistorico == value)return;
                 this._valueHistorico = value; 
            } 
        } 

       protected DateTime _dataPrevistaOriginal{get;private set;}
       private DateTime _dataPrevistaOriginalCommited{get; set;}
        private DateTime _valueDataPrevista;
         [Column("crr_data_prevista")]
        public virtual DateTime DataPrevista
         { 
            get { return this._valueDataPrevista; } 
            set 
            { 
                if (this._valueDataPrevista == value)return;
                 this._valueDataPrevista = value; 
            } 
        } 

       protected int _periodicidadeOriginal{get;private set;}
       private int _periodicidadeOriginalCommited{get; set;}
        private int _valuePeriodicidade;
         [Column("crr_periodicidade")]
        public virtual int Periodicidade
         { 
            get { return this._valuePeriodicidade; } 
            set 
            { 
                if (this._valuePeriodicidade == value)return;
                 this._valuePeriodicidade = value; 
            } 
        } 

       protected NaturezaConta _naturezaOriginal{get;private set;}
       private NaturezaConta _naturezaOriginalCommited{get; set;}
        private NaturezaConta _valueNatureza;
         [Column("crr_natureza")]
        public virtual NaturezaConta Natureza
         { 
            get { return this._valueNatureza; } 
            set 
            { 
                if (this._valueNatureza == value)return;
                 this._valueNatureza = value; 
            } 
        } 

        public bool Natureza_ContaPagar
         { 
            get { return this._valueNatureza == BibliotecaEntidades.Base.NaturezaConta.ContaPagar; } 
            set { if (value) this._valueNatureza = BibliotecaEntidades.Base.NaturezaConta.ContaPagar; }
         } 

        public bool Natureza_ContaReceber
         { 
            get { return this._valueNatureza == BibliotecaEntidades.Base.NaturezaConta.ContaReceber; } 
            set { if (value) this._valueNatureza = BibliotecaEntidades.Base.NaturezaConta.ContaReceber; }
         } 

       protected BibliotecaEntidades.Entidades.ClienteClass _clienteOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.ClienteClass _clienteOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.ClienteClass _valueCliente;
        [Column("id_cliente", "cliente", "id_cliente")]
       public virtual BibliotecaEntidades.Entidades.ClienteClass Cliente
        { 
           get {                 return this._valueCliente; } 
           set 
           { 
                if (this._valueCliente == value)return;
                 this._valueCliente = value; 
           } 
       } 

       private List<long> _collectionContaPagarClassContaRecorrenteOriginal;
       private List<Entidades.ContaPagarClass > _collectionContaPagarClassContaRecorrenteRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaPagarClassContaRecorrenteLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaPagarClassContaRecorrenteChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaPagarClassContaRecorrenteCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ContaPagarClass> _valueCollectionContaPagarClassContaRecorrente { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ContaPagarClass> CollectionContaPagarClassContaRecorrente 
       { 
           get { if(!_valueCollectionContaPagarClassContaRecorrenteLoaded && !this.DisableLoadCollection){this.LoadCollectionContaPagarClassContaRecorrente();}
return this._valueCollectionContaPagarClassContaRecorrente; } 
           set 
           { 
               this._valueCollectionContaPagarClassContaRecorrente = value; 
               this._valueCollectionContaPagarClassContaRecorrenteLoaded = true; 
           } 
       } 

       private List<long> _collectionContaReceberClassContaRecorrenteOriginal;
       private List<Entidades.ContaReceberClass > _collectionContaReceberClassContaRecorrenteRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaReceberClassContaRecorrenteLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaReceberClassContaRecorrenteChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaReceberClassContaRecorrenteCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ContaReceberClass> _valueCollectionContaReceberClassContaRecorrente { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ContaReceberClass> CollectionContaReceberClassContaRecorrente 
       { 
           get { if(!_valueCollectionContaReceberClassContaRecorrenteLoaded && !this.DisableLoadCollection){this.LoadCollectionContaReceberClassContaRecorrente();}
return this._valueCollectionContaReceberClassContaRecorrente; } 
           set 
           { 
               this._valueCollectionContaReceberClassContaRecorrente = value; 
               this._valueCollectionContaReceberClassContaRecorrenteLoaded = true; 
           } 
       } 

        public ContaRecorrenteBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Tipo = (TipoContaRecorrente)0;
           this.Periodicidade = 1;
           this.Natureza = (NaturezaConta)0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static ContaRecorrenteClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (ContaRecorrenteClass) GetEntity(typeof(ContaRecorrenteClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionContaPagarClassContaRecorrenteChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionContaPagarClassContaRecorrenteChanged = true;
                  _valueCollectionContaPagarClassContaRecorrenteCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionContaPagarClassContaRecorrenteChanged = true; 
                  _valueCollectionContaPagarClassContaRecorrenteCommitedChanged = true;
                 foreach (Entidades.ContaPagarClass item in e.OldItems) 
                 { 
                     _collectionContaPagarClassContaRecorrenteRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionContaPagarClassContaRecorrenteChanged = true; 
                  _valueCollectionContaPagarClassContaRecorrenteCommitedChanged = true;
                 foreach (Entidades.ContaPagarClass item in _valueCollectionContaPagarClassContaRecorrente) 
                 { 
                     _collectionContaPagarClassContaRecorrenteRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionContaPagarClassContaRecorrente()
         {
            try
            {
                 ObservableCollection<Entidades.ContaPagarClass> oc;
                _valueCollectionContaPagarClassContaRecorrenteChanged = false;
                 _valueCollectionContaPagarClassContaRecorrenteCommitedChanged = false;
                _collectionContaPagarClassContaRecorrenteRemovidos = new List<Entidades.ContaPagarClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ContaPagarClass>();
                }
                else{ 
                   Entidades.ContaPagarClass search = new Entidades.ContaPagarClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ContaPagarClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ContaRecorrente", this),                     }                       ).Cast<Entidades.ContaPagarClass>().ToList());
                 }
                 _valueCollectionContaPagarClassContaRecorrente = new BindingList<Entidades.ContaPagarClass>(oc); 
                 _collectionContaPagarClassContaRecorrenteOriginal= (from a in _valueCollectionContaPagarClassContaRecorrente select a.ID).ToList();
                 _valueCollectionContaPagarClassContaRecorrenteLoaded = true;
                 oc.CollectionChanged += CollectionContaPagarClassContaRecorrenteChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionContaPagarClassContaRecorrente+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionContaReceberClassContaRecorrenteChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionContaReceberClassContaRecorrenteChanged = true;
                  _valueCollectionContaReceberClassContaRecorrenteCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionContaReceberClassContaRecorrenteChanged = true; 
                  _valueCollectionContaReceberClassContaRecorrenteCommitedChanged = true;
                 foreach (Entidades.ContaReceberClass item in e.OldItems) 
                 { 
                     _collectionContaReceberClassContaRecorrenteRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionContaReceberClassContaRecorrenteChanged = true; 
                  _valueCollectionContaReceberClassContaRecorrenteCommitedChanged = true;
                 foreach (Entidades.ContaReceberClass item in _valueCollectionContaReceberClassContaRecorrente) 
                 { 
                     _collectionContaReceberClassContaRecorrenteRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionContaReceberClassContaRecorrente()
         {
            try
            {
                 ObservableCollection<Entidades.ContaReceberClass> oc;
                _valueCollectionContaReceberClassContaRecorrenteChanged = false;
                 _valueCollectionContaReceberClassContaRecorrenteCommitedChanged = false;
                _collectionContaReceberClassContaRecorrenteRemovidos = new List<Entidades.ContaReceberClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ContaReceberClass>();
                }
                else{ 
                   Entidades.ContaReceberClass search = new Entidades.ContaReceberClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ContaReceberClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ContaRecorrente", this)                    }                       ).Cast<Entidades.ContaReceberClass>().ToList());
                 }
                 _valueCollectionContaReceberClassContaRecorrente = new BindingList<Entidades.ContaReceberClass>(oc); 
                 _collectionContaReceberClassContaRecorrenteOriginal= (from a in _valueCollectionContaReceberClassContaRecorrente select a.ID).ToList();
                 _valueCollectionContaReceberClassContaRecorrenteLoaded = true;
                 oc.CollectionChanged += CollectionContaReceberClassContaRecorrenteChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionContaReceberClassContaRecorrente+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Historico))
                {
                    throw new Exception(ErroHistoricoObrigatorio);
                }
                if (Historico.Length >255)
                {
                    throw new Exception( ErroHistoricoComprimento);
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
                    "  public.conta_recorrente  " +
                    "WHERE " +
                    "  id_conta_recorrente = :id";
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
                        "  public.conta_recorrente   " +
                        "SET  " + 
                        "  id_tipo_pagamento = :id_tipo_pagamento, " + 
                        "  id_fornecedor = :id_fornecedor, " + 
                        "  id_conta_bancaria = :id_conta_bancaria, " + 
                        "  id_centro_custo_lucro = :id_centro_custo_lucro, " + 
                        "  crr_tipo = :crr_tipo, " + 
                        "  crr_valor_fixo = :crr_valor_fixo, " + 
                        "  crr_historico = :crr_historico, " + 
                        "  crr_data_prevista = :crr_data_prevista, " + 
                        "  crr_periodicidade = :crr_periodicidade, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  crr_natureza = :crr_natureza, " + 
                        "  id_cliente = :id_cliente "+
                        "WHERE  " +
                        "  id_conta_recorrente = :id " +
                        "RETURNING id_conta_recorrente;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.conta_recorrente " +
                        "( " +
                        "  id_tipo_pagamento , " + 
                        "  id_fornecedor , " + 
                        "  id_conta_bancaria , " + 
                        "  id_centro_custo_lucro , " + 
                        "  crr_tipo , " + 
                        "  crr_valor_fixo , " + 
                        "  crr_historico , " + 
                        "  crr_data_prevista , " + 
                        "  crr_periodicidade , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  crr_natureza , " + 
                        "  id_cliente  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_tipo_pagamento , " + 
                        "  :id_fornecedor , " + 
                        "  :id_conta_bancaria , " + 
                        "  :id_centro_custo_lucro , " + 
                        "  :crr_tipo , " + 
                        "  :crr_valor_fixo , " + 
                        "  :crr_historico , " + 
                        "  :crr_data_prevista , " + 
                        "  :crr_periodicidade , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :crr_natureza , " + 
                        "  :id_cliente  "+
                        ")RETURNING id_conta_recorrente;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_tipo_pagamento", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.TipoPagamento==null ? (object) DBNull.Value : this.TipoPagamento.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_fornecedor", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Fornecedor==null ? (object) DBNull.Value : this.Fornecedor.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_conta_bancaria", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.ContaBancaria==null ? (object) DBNull.Value : this.ContaBancaria.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_centro_custo_lucro", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.CentroCustoLucro==null ? (object) DBNull.Value : this.CentroCustoLucro.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("crr_tipo", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Tipo);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("crr_valor_fixo", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorFixo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("crr_historico", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Historico ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("crr_data_prevista", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataPrevista ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("crr_periodicidade", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Periodicidade ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("crr_natureza", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Natureza);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_cliente", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Cliente==null ? (object) DBNull.Value : this.Cliente.ID;

 
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
 if (CollectionContaPagarClassContaRecorrente.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionContaPagarClassContaRecorrente+"\r\n";
                foreach (Entidades.ContaPagarClass tmp in CollectionContaPagarClassContaRecorrente)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionContaReceberClassContaRecorrente.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionContaReceberClassContaRecorrente+"\r\n";
                foreach (Entidades.ContaReceberClass tmp in CollectionContaReceberClassContaRecorrente)
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
        public static ContaRecorrenteClass CopiarEntidade(ContaRecorrenteClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               ContaRecorrenteClass toRet = new ContaRecorrenteClass(usuario,conn);
 toRet.TipoPagamento= entidadeCopiar.TipoPagamento;
 toRet.Fornecedor= entidadeCopiar.Fornecedor;
 toRet.ContaBancaria= entidadeCopiar.ContaBancaria;
 toRet.CentroCustoLucro= entidadeCopiar.CentroCustoLucro;
 toRet.Tipo= entidadeCopiar.Tipo;
 toRet.ValorFixo= entidadeCopiar.ValorFixo;
 toRet.Historico= entidadeCopiar.Historico;
 toRet.DataPrevista= entidadeCopiar.DataPrevista;
 toRet.Periodicidade= entidadeCopiar.Periodicidade;
 toRet.Natureza= entidadeCopiar.Natureza;
 toRet.Cliente= entidadeCopiar.Cliente;

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
       _tipoPagamentoOriginal = TipoPagamento;
       _tipoPagamentoOriginalCommited = _tipoPagamentoOriginal;
       _fornecedorOriginal = Fornecedor;
       _fornecedorOriginalCommited = _fornecedorOriginal;
       _contaBancariaOriginal = ContaBancaria;
       _contaBancariaOriginalCommited = _contaBancariaOriginal;
       _centroCustoLucroOriginal = CentroCustoLucro;
       _centroCustoLucroOriginalCommited = _centroCustoLucroOriginal;
       _tipoOriginal = Tipo;
       _tipoOriginalCommited = _tipoOriginal;
       _valorFixoOriginal = ValorFixo;
       _valorFixoOriginalCommited = _valorFixoOriginal;
       _historicoOriginal = Historico;
       _historicoOriginalCommited = _historicoOriginal;
       _dataPrevistaOriginal = DataPrevista;
       _dataPrevistaOriginalCommited = _dataPrevistaOriginal;
       _periodicidadeOriginal = Periodicidade;
       _periodicidadeOriginalCommited = _periodicidadeOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _naturezaOriginal = Natureza;
       _naturezaOriginalCommited = _naturezaOriginal;
       _clienteOriginal = Cliente;
       _clienteOriginalCommited = _clienteOriginal;

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
       _tipoPagamentoOriginalCommited = TipoPagamento;
       _fornecedorOriginalCommited = Fornecedor;
       _contaBancariaOriginalCommited = ContaBancaria;
       _centroCustoLucroOriginalCommited = CentroCustoLucro;
       _tipoOriginalCommited = Tipo;
       _valorFixoOriginalCommited = ValorFixo;
       _historicoOriginalCommited = Historico;
       _dataPrevistaOriginalCommited = DataPrevista;
       _periodicidadeOriginalCommited = Periodicidade;
       _versionOriginalCommited = Version;
       _naturezaOriginalCommited = Natureza;
       _clienteOriginalCommited = Cliente;

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
               if (_valueCollectionContaPagarClassContaRecorrenteLoaded) 
               {
                  if (_collectionContaPagarClassContaRecorrenteRemovidos != null) 
                  {
                     _collectionContaPagarClassContaRecorrenteRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionContaPagarClassContaRecorrenteRemovidos = new List<Entidades.ContaPagarClass>();
                  }
                  _collectionContaPagarClassContaRecorrenteOriginal= (from a in _valueCollectionContaPagarClassContaRecorrente select a.ID).ToList();
                  _valueCollectionContaPagarClassContaRecorrenteChanged = false;
                  _valueCollectionContaPagarClassContaRecorrenteCommitedChanged = false;
               }
               if (_valueCollectionContaReceberClassContaRecorrenteLoaded) 
               {
                  if (_collectionContaReceberClassContaRecorrenteRemovidos != null) 
                  {
                     _collectionContaReceberClassContaRecorrenteRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionContaReceberClassContaRecorrenteRemovidos = new List<Entidades.ContaReceberClass>();
                  }
                  _collectionContaReceberClassContaRecorrenteOriginal= (from a in _valueCollectionContaReceberClassContaRecorrente select a.ID).ToList();
                  _valueCollectionContaReceberClassContaRecorrenteChanged = false;
                  _valueCollectionContaReceberClassContaRecorrenteCommitedChanged = false;
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
               TipoPagamento=_tipoPagamentoOriginal;
               _tipoPagamentoOriginalCommited=_tipoPagamentoOriginal;
               Fornecedor=_fornecedorOriginal;
               _fornecedorOriginalCommited=_fornecedorOriginal;
               ContaBancaria=_contaBancariaOriginal;
               _contaBancariaOriginalCommited=_contaBancariaOriginal;
               CentroCustoLucro=_centroCustoLucroOriginal;
               _centroCustoLucroOriginalCommited=_centroCustoLucroOriginal;
               Tipo=_tipoOriginal;
               _tipoOriginalCommited=_tipoOriginal;
               ValorFixo=_valorFixoOriginal;
               _valorFixoOriginalCommited=_valorFixoOriginal;
               Historico=_historicoOriginal;
               _historicoOriginalCommited=_historicoOriginal;
               DataPrevista=_dataPrevistaOriginal;
               _dataPrevistaOriginalCommited=_dataPrevistaOriginal;
               Periodicidade=_periodicidadeOriginal;
               _periodicidadeOriginalCommited=_periodicidadeOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               Natureza=_naturezaOriginal;
               _naturezaOriginalCommited=_naturezaOriginal;
               Cliente=_clienteOriginal;
               _clienteOriginalCommited=_clienteOriginal;
               if (_valueCollectionContaPagarClassContaRecorrenteLoaded) 
               {
                  CollectionContaPagarClassContaRecorrente.Clear();
                  foreach(int item in _collectionContaPagarClassContaRecorrenteOriginal)
                  {
                    CollectionContaPagarClassContaRecorrente.Add(Entidades.ContaPagarClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionContaPagarClassContaRecorrenteRemovidos.Clear();
               }
               if (_valueCollectionContaReceberClassContaRecorrenteLoaded) 
               {
                  CollectionContaReceberClassContaRecorrente.Clear();
                  foreach(int item in _collectionContaReceberClassContaRecorrenteOriginal)
                  {
                    CollectionContaReceberClassContaRecorrente.Add(Entidades.ContaReceberClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionContaReceberClassContaRecorrenteRemovidos.Clear();
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
               if (_valueCollectionContaPagarClassContaRecorrenteLoaded) 
               {
                  if (_valueCollectionContaPagarClassContaRecorrenteChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaReceberClassContaRecorrenteLoaded) 
               {
                  if (_valueCollectionContaReceberClassContaRecorrenteChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaPagarClassContaRecorrenteLoaded) 
               {
                   tempRet = CollectionContaPagarClassContaRecorrente.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionContaReceberClassContaRecorrenteLoaded) 
               {
                   tempRet = CollectionContaReceberClassContaRecorrente.Any(item => item.IsDirty());
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
       if (_tipoPagamentoOriginal!=null)
       {
          dirty = !_tipoPagamentoOriginal.Equals(TipoPagamento);
       }
       else
       {
            dirty = TipoPagamento != null;
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
       dirty = _tipoOriginal != Tipo;
      if (dirty) return true;
       dirty = _valorFixoOriginal != ValorFixo;
      if (dirty) return true;
       dirty = _historicoOriginal != Historico;
      if (dirty) return true;
       dirty = _dataPrevistaOriginal != DataPrevista;
      if (dirty) return true;
       dirty = _periodicidadeOriginal != Periodicidade;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _naturezaOriginal != Natureza;
      if (dirty) return true;
       if (_clienteOriginal!=null)
       {
          dirty = !_clienteOriginal.Equals(Cliente);
       }
       else
       {
            dirty = Cliente != null;
       }

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
               if (_valueCollectionContaPagarClassContaRecorrenteLoaded) 
               {
                  if (_valueCollectionContaPagarClassContaRecorrenteCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaReceberClassContaRecorrenteLoaded) 
               {
                  if (_valueCollectionContaReceberClassContaRecorrenteCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaPagarClassContaRecorrenteLoaded) 
               {
                   tempRet = CollectionContaPagarClassContaRecorrente.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionContaReceberClassContaRecorrenteLoaded) 
               {
                   tempRet = CollectionContaReceberClassContaRecorrente.Any(item => item.IsDirtyCommited());
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
       if (_tipoPagamentoOriginalCommited!=null)
       {
          dirty = !_tipoPagamentoOriginalCommited.Equals(TipoPagamento);
       }
       else
       {
            dirty = TipoPagamento != null;
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
       dirty = _tipoOriginalCommited != Tipo;
      if (dirty) return true;
       dirty = _valorFixoOriginalCommited != ValorFixo;
      if (dirty) return true;
       dirty = _historicoOriginalCommited != Historico;
      if (dirty) return true;
       dirty = _dataPrevistaOriginalCommited != DataPrevista;
      if (dirty) return true;
       dirty = _periodicidadeOriginalCommited != Periodicidade;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _naturezaOriginalCommited != Natureza;
      if (dirty) return true;
       if (_clienteOriginalCommited!=null)
       {
          dirty = !_clienteOriginalCommited.Equals(Cliente);
       }
       else
       {
            dirty = Cliente != null;
       }

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
               if (_valueCollectionContaPagarClassContaRecorrenteLoaded) 
               {
                  foreach(ContaPagarClass item in CollectionContaPagarClassContaRecorrente)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionContaReceberClassContaRecorrenteLoaded) 
               {
                  foreach(ContaReceberClass item in CollectionContaReceberClassContaRecorrente)
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
             case "TipoPagamento":
                return this.TipoPagamento;
             case "Fornecedor":
                return this.Fornecedor;
             case "ContaBancaria":
                return this.ContaBancaria;
             case "CentroCustoLucro":
                return this.CentroCustoLucro;
             case "Tipo":
                return this.Tipo;
             case "ValorFixo":
                return this.ValorFixo;
             case "Historico":
                return this.Historico;
             case "DataPrevista":
                return this.DataPrevista;
             case "Periodicidade":
                return this.Periodicidade;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "Natureza":
                return this.Natureza;
             case "Cliente":
                return this.Cliente;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (TipoPagamento!=null)
                TipoPagamento.ChangeSingleConnection(newConnection);
             if (Fornecedor!=null)
                Fornecedor.ChangeSingleConnection(newConnection);
             if (ContaBancaria!=null)
                ContaBancaria.ChangeSingleConnection(newConnection);
             if (CentroCustoLucro!=null)
                CentroCustoLucro.ChangeSingleConnection(newConnection);
             if (Cliente!=null)
                Cliente.ChangeSingleConnection(newConnection);
               if (_valueCollectionContaPagarClassContaRecorrenteLoaded) 
               {
                  foreach(ContaPagarClass item in CollectionContaPagarClassContaRecorrente)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionContaReceberClassContaRecorrenteLoaded) 
               {
                  foreach(ContaReceberClass item in CollectionContaReceberClassContaRecorrente)
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
                  command.CommandText += " COUNT(conta_recorrente.id_conta_recorrente) " ;
               }
               else
               {
               command.CommandText += "conta_recorrente.id_conta_recorrente, " ;
               command.CommandText += "conta_recorrente.id_tipo_pagamento, " ;
               command.CommandText += "conta_recorrente.id_fornecedor, " ;
               command.CommandText += "conta_recorrente.id_conta_bancaria, " ;
               command.CommandText += "conta_recorrente.id_centro_custo_lucro, " ;
               command.CommandText += "conta_recorrente.crr_tipo, " ;
               command.CommandText += "conta_recorrente.crr_valor_fixo, " ;
               command.CommandText += "conta_recorrente.crr_historico, " ;
               command.CommandText += "conta_recorrente.crr_data_prevista, " ;
               command.CommandText += "conta_recorrente.crr_periodicidade, " ;
               command.CommandText += "conta_recorrente.entity_uid, " ;
               command.CommandText += "conta_recorrente.version, " ;
               command.CommandText += "conta_recorrente.crr_natureza, " ;
               command.CommandText += "conta_recorrente.id_cliente " ;
               }
               command.CommandText += " FROM  conta_recorrente ";
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
                        orderByClause += " , crr_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(crr_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = conta_recorrente.id_acs_usuario_ultima_revisao ";
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
                     case "id_conta_recorrente":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conta_recorrente.id_conta_recorrente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_recorrente.id_conta_recorrente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_tipo_pagamento":
                     case "TipoPagamento":
                     command.CommandText += " LEFT JOIN tipo_pagamento as tipo_pagamento_TipoPagamento ON tipo_pagamento_TipoPagamento.id_tipo_pagamento = conta_recorrente.id_tipo_pagamento ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , tipo_pagamento_TipoPagamento.tip_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(tipo_pagamento_TipoPagamento.tip_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_fornecedor":
                     case "Fornecedor":
                     command.CommandText += " LEFT JOIN fornecedor as fornecedor_Fornecedor ON fornecedor_Fornecedor.id_fornecedor = conta_recorrente.id_fornecedor ";                     switch (parametro.TipoOrdenacao)
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
                     case "id_conta_bancaria":
                     case "ContaBancaria":
                     command.CommandText += " LEFT JOIN conta_bancaria as conta_bancaria_ContaBancaria ON conta_bancaria_ContaBancaria.id_conta_bancaria = conta_recorrente.id_conta_bancaria ";                     switch (parametro.TipoOrdenacao)
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
                     command.CommandText += " LEFT JOIN centro_custo_lucro as centro_custo_lucro_CentroCustoLucro ON centro_custo_lucro_CentroCustoLucro.id_centro_custo_lucro = conta_recorrente.id_centro_custo_lucro ";                     switch (parametro.TipoOrdenacao)
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
                     case "crr_tipo":
                     case "Tipo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conta_recorrente.crr_tipo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_recorrente.crr_tipo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "crr_valor_fixo":
                     case "ValorFixo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conta_recorrente.crr_valor_fixo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_recorrente.crr_valor_fixo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "crr_historico":
                     case "Historico":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , conta_recorrente.crr_historico " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(conta_recorrente.crr_historico) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "crr_data_prevista":
                     case "DataPrevista":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conta_recorrente.crr_data_prevista " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_recorrente.crr_data_prevista) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "crr_periodicidade":
                     case "Periodicidade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conta_recorrente.crr_periodicidade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_recorrente.crr_periodicidade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , conta_recorrente.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(conta_recorrente.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , conta_recorrente.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_recorrente.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "crr_natureza":
                     case "Natureza":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conta_recorrente.crr_natureza " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conta_recorrente.crr_natureza) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_cliente":
                     case "Cliente":
                     command.CommandText += " LEFT JOIN cliente as cliente_Cliente ON cliente_Cliente.id_cliente = conta_recorrente.id_cliente ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cliente_Cliente.cli_nome_resumido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cliente_Cliente.cli_nome_resumido) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("crr_historico")) 
                        {
                           whereClause += " OR UPPER(conta_recorrente.crr_historico) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(conta_recorrente.crr_historico) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(conta_recorrente.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(conta_recorrente.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_conta_recorrente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_recorrente.id_conta_recorrente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_recorrente.id_conta_recorrente = :conta_recorrente_ID_2998 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_recorrente_ID_2998", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoPagamento" || parametro.FieldName == "id_tipo_pagamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.TipoPagamentoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.TipoPagamentoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_recorrente.id_tipo_pagamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_recorrente.id_tipo_pagamento = :conta_recorrente_TipoPagamento_4519 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_recorrente_TipoPagamento_4519", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  conta_recorrente.id_fornecedor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_recorrente.id_fornecedor = :conta_recorrente_Fornecedor_7148 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_recorrente_Fornecedor_7148", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  conta_recorrente.id_conta_bancaria IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_recorrente.id_conta_bancaria = :conta_recorrente_ContaBancaria_9028 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_recorrente_ContaBancaria_9028", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  conta_recorrente.id_centro_custo_lucro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_recorrente.id_centro_custo_lucro = :conta_recorrente_CentroCustoLucro_5137 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_recorrente_CentroCustoLucro_5137", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Tipo" || parametro.FieldName == "crr_tipo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is TipoContaRecorrente)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo TipoContaRecorrente");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_recorrente.crr_tipo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_recorrente.crr_tipo = :conta_recorrente_Tipo_1989 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_recorrente_Tipo_1989", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorFixo" || parametro.FieldName == "crr_valor_fixo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_recorrente.crr_valor_fixo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_recorrente.crr_valor_fixo = :conta_recorrente_ValorFixo_9607 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_recorrente_ValorFixo_9607", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Historico" || parametro.FieldName == "crr_historico")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_recorrente.crr_historico IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_recorrente.crr_historico LIKE :conta_recorrente_Historico_2592 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_recorrente_Historico_2592", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataPrevista" || parametro.FieldName == "crr_data_prevista")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_recorrente.crr_data_prevista IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_recorrente.crr_data_prevista = :conta_recorrente_DataPrevista_2028 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_recorrente_DataPrevista_2028", NpgsqlDbType.Date, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Periodicidade" || parametro.FieldName == "crr_periodicidade")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_recorrente.crr_periodicidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_recorrente.crr_periodicidade = :conta_recorrente_Periodicidade_2254 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_recorrente_Periodicidade_2254", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  conta_recorrente.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_recorrente.entity_uid LIKE :conta_recorrente_EntityUid_618 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_recorrente_EntityUid_618", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  conta_recorrente.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_recorrente.version = :conta_recorrente_Version_8244 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_recorrente_Version_8244", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Natureza" || parametro.FieldName == "crr_natureza")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is NaturezaConta)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo NaturezaConta");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_recorrente.crr_natureza IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_recorrente.crr_natureza = :conta_recorrente_Natureza_2176 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_recorrente_Natureza_2176", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cliente" || parametro.FieldName == "id_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.ClienteClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.ClienteClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_recorrente.id_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_recorrente.id_cliente = :conta_recorrente_Cliente_9114 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_recorrente_Cliente_9114", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "HistoricoExato" || parametro.FieldName == "HistoricoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conta_recorrente.crr_historico IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_recorrente.crr_historico LIKE :conta_recorrente_Historico_9842 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_recorrente_Historico_9842", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  conta_recorrente.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conta_recorrente.entity_uid LIKE :conta_recorrente_EntityUid_2826 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conta_recorrente_EntityUid_2826", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  ContaRecorrenteClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (ContaRecorrenteClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(ContaRecorrenteClass), Convert.ToInt32(read["id_conta_recorrente"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new ContaRecorrenteClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_conta_recorrente"]);
                     if (read["id_tipo_pagamento"] != DBNull.Value)
                     {
                        entidade.TipoPagamento = (BibliotecaEntidades.Entidades.TipoPagamentoClass)BibliotecaEntidades.Entidades.TipoPagamentoClass.GetEntidade(Convert.ToInt32(read["id_tipo_pagamento"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.TipoPagamento = null ;
                     }
                     if (read["id_fornecedor"] != DBNull.Value)
                     {
                        entidade.Fornecedor = (BibliotecaEntidades.Entidades.FornecedorClass)BibliotecaEntidades.Entidades.FornecedorClass.GetEntidade(Convert.ToInt32(read["id_fornecedor"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Fornecedor = null ;
                     }
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
                     entidade.Tipo = (TipoContaRecorrente) (read["crr_tipo"] != DBNull.Value ? Enum.ToObject(typeof(TipoContaRecorrente), read["crr_tipo"]) : null);
                     entidade.ValorFixo = read["crr_valor_fixo"] as double?;
                     entidade.Historico = (read["crr_historico"] != DBNull.Value ? read["crr_historico"].ToString() : null);
                     entidade.DataPrevista = (DateTime)read["crr_data_prevista"];
                     entidade.Periodicidade = (int)read["crr_periodicidade"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.Natureza = (NaturezaConta) (read["crr_natureza"] != DBNull.Value ? Enum.ToObject(typeof(NaturezaConta), read["crr_natureza"]) : null);
                     if (read["id_cliente"] != DBNull.Value)
                     {
                        entidade.Cliente = (BibliotecaEntidades.Entidades.ClienteClass)BibliotecaEntidades.Entidades.ClienteClass.GetEntidade(Convert.ToInt32(read["id_cliente"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Cliente = null ;
                     }
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (ContaRecorrenteClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
