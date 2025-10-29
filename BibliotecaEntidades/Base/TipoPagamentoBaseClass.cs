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
     [Table("tipo_pagamento","tip")]
     public class TipoPagamentoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do TipoPagamentoClass";
protected const string ErroDelete = "Erro ao excluir o TipoPagamentoClass  ";
protected const string ErroSave = "Erro ao salvar o TipoPagamentoClass.";
protected const string ErroCollectionClienteClassTipoPagamento = "Erro ao carregar a coleção de ClienteClass.";
protected const string ErroCollectionContaPagarClassTipoPagamento = "Erro ao carregar a coleção de ContaPagarClass.";
protected const string ErroCollectionContaReceberClassTipoPagamento = "Erro ao carregar a coleção de ContaReceberClass.";
protected const string ErroCollectionContaRecorrenteClassTipoPagamento = "Erro ao carregar a coleção de ContaRecorrenteClass.";
protected const string ErroCollectionPedidoItemClassTipoPagamento = "Erro ao carregar a coleção de PedidoItemClass.";
protected const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
protected const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do TipoPagamentoClass.";
protected const string MensagemUtilizadoCollectionClienteClassTipoPagamento =  "A entidade TipoPagamentoClass está sendo utilizada nos seguintes ClienteClass:";
protected const string MensagemUtilizadoCollectionContaPagarClassTipoPagamento =  "A entidade TipoPagamentoClass está sendo utilizada nos seguintes ContaPagarClass:";
protected const string MensagemUtilizadoCollectionContaReceberClassTipoPagamento =  "A entidade TipoPagamentoClass está sendo utilizada nos seguintes ContaReceberClass:";
protected const string MensagemUtilizadoCollectionContaRecorrenteClassTipoPagamento =  "A entidade TipoPagamentoClass está sendo utilizada nos seguintes ContaRecorrenteClass:";
protected const string MensagemUtilizadoCollectionPedidoItemClassTipoPagamento =  "A entidade TipoPagamentoClass está sendo utilizada nos seguintes PedidoItemClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade TipoPagamentoClass está sendo utilizada.";
#endregion
       protected string _identificacaoOriginal{get;private set;}
       private string _identificacaoOriginalCommited{get; set;}
        private string _valueIdentificacao;
         [Column("tip_identificacao")]
        public virtual string Identificacao
         { 
            get { return this._valueIdentificacao; } 
            set 
            { 
                if (this._valueIdentificacao == value)return;
                 this._valueIdentificacao = value; 
            } 
        } 

       protected TipoPagamentoNfe? _tipoPagamentoNfOriginal{get;private set;}
       private TipoPagamentoNfe? _tipoPagamentoNfOriginalCommited{get; set;}
        private TipoPagamentoNfe? _valueTipoPagamentoNf;
         [Column("tip_tipo_pagamento_nf")]
        public virtual TipoPagamentoNfe? TipoPagamentoNf
         { 
            get { return this._valueTipoPagamentoNf; } 
            set 
            { 
                if (this._valueTipoPagamentoNf == value)return;
                 this._valueTipoPagamentoNf = value; 
            } 
        } 

        public bool TipoPagamentoNf_Dinheiro
         { 
            get { return this._valueTipoPagamentoNf.HasValue && this._valueTipoPagamentoNf.Value == BibliotecaEntidades.Base.TipoPagamentoNfe.Dinheiro; } 
            set { if (value) this._valueTipoPagamentoNf = BibliotecaEntidades.Base.TipoPagamentoNfe.Dinheiro; }
         } 

        public bool TipoPagamentoNf_Cheque
         { 
            get { return this._valueTipoPagamentoNf.HasValue && this._valueTipoPagamentoNf.Value == BibliotecaEntidades.Base.TipoPagamentoNfe.Cheque; } 
            set { if (value) this._valueTipoPagamentoNf = BibliotecaEntidades.Base.TipoPagamentoNfe.Cheque; }
         } 

        public bool TipoPagamentoNf_CartaodeCredito
         { 
            get { return this._valueTipoPagamentoNf.HasValue && this._valueTipoPagamentoNf.Value == BibliotecaEntidades.Base.TipoPagamentoNfe.CartaodeCredito; } 
            set { if (value) this._valueTipoPagamentoNf = BibliotecaEntidades.Base.TipoPagamentoNfe.CartaodeCredito; }
         } 

        public bool TipoPagamentoNf_CartaodeDebito
         { 
            get { return this._valueTipoPagamentoNf.HasValue && this._valueTipoPagamentoNf.Value == BibliotecaEntidades.Base.TipoPagamentoNfe.CartaodeDebito; } 
            set { if (value) this._valueTipoPagamentoNf = BibliotecaEntidades.Base.TipoPagamentoNfe.CartaodeDebito; }
         } 

        public bool TipoPagamentoNf_CreditoLoja
         { 
            get { return this._valueTipoPagamentoNf.HasValue && this._valueTipoPagamentoNf.Value == BibliotecaEntidades.Base.TipoPagamentoNfe.CreditoLoja; } 
            set { if (value) this._valueTipoPagamentoNf = BibliotecaEntidades.Base.TipoPagamentoNfe.CreditoLoja; }
         } 

        public bool TipoPagamentoNf_ValeAlimentacao
         { 
            get { return this._valueTipoPagamentoNf.HasValue && this._valueTipoPagamentoNf.Value == BibliotecaEntidades.Base.TipoPagamentoNfe.ValeAlimentacao; } 
            set { if (value) this._valueTipoPagamentoNf = BibliotecaEntidades.Base.TipoPagamentoNfe.ValeAlimentacao; }
         } 

        public bool TipoPagamentoNf_ValeRefeicao
         { 
            get { return this._valueTipoPagamentoNf.HasValue && this._valueTipoPagamentoNf.Value == BibliotecaEntidades.Base.TipoPagamentoNfe.ValeRefeicao; } 
            set { if (value) this._valueTipoPagamentoNf = BibliotecaEntidades.Base.TipoPagamentoNfe.ValeRefeicao; }
         } 

        public bool TipoPagamentoNf_ValePresente
         { 
            get { return this._valueTipoPagamentoNf.HasValue && this._valueTipoPagamentoNf.Value == BibliotecaEntidades.Base.TipoPagamentoNfe.ValePresente; } 
            set { if (value) this._valueTipoPagamentoNf = BibliotecaEntidades.Base.TipoPagamentoNfe.ValePresente; }
         } 

        public bool TipoPagamentoNf_ValeCombustivel
         { 
            get { return this._valueTipoPagamentoNf.HasValue && this._valueTipoPagamentoNf.Value == BibliotecaEntidades.Base.TipoPagamentoNfe.ValeCombustivel; } 
            set { if (value) this._valueTipoPagamentoNf = BibliotecaEntidades.Base.TipoPagamentoNfe.ValeCombustivel; }
         } 

        public bool TipoPagamentoNf_BoletoBancario
         { 
            get { return this._valueTipoPagamentoNf.HasValue && this._valueTipoPagamentoNf.Value == BibliotecaEntidades.Base.TipoPagamentoNfe.BoletoBancario; } 
            set { if (value) this._valueTipoPagamentoNf = BibliotecaEntidades.Base.TipoPagamentoNfe.BoletoBancario; }
         } 

        public bool TipoPagamentoNf_DepositoBancario
         { 
            get { return this._valueTipoPagamentoNf.HasValue && this._valueTipoPagamentoNf.Value == BibliotecaEntidades.Base.TipoPagamentoNfe.DepositoBancario; } 
            set { if (value) this._valueTipoPagamentoNf = BibliotecaEntidades.Base.TipoPagamentoNfe.DepositoBancario; }
         } 

        public bool TipoPagamentoNf_Pix
         { 
            get { return this._valueTipoPagamentoNf.HasValue && this._valueTipoPagamentoNf.Value == BibliotecaEntidades.Base.TipoPagamentoNfe.Pix; } 
            set { if (value) this._valueTipoPagamentoNf = BibliotecaEntidades.Base.TipoPagamentoNfe.Pix; }
         } 

        public bool TipoPagamentoNf_TransferenciaBancaria
         { 
            get { return this._valueTipoPagamentoNf.HasValue && this._valueTipoPagamentoNf.Value == BibliotecaEntidades.Base.TipoPagamentoNfe.TransferenciaBancaria; } 
            set { if (value) this._valueTipoPagamentoNf = BibliotecaEntidades.Base.TipoPagamentoNfe.TransferenciaBancaria; }
         } 

        public bool TipoPagamentoNf_ProgramaFidelidade
         { 
            get { return this._valueTipoPagamentoNf.HasValue && this._valueTipoPagamentoNf.Value == BibliotecaEntidades.Base.TipoPagamentoNfe.ProgramaFidelidade; } 
            set { if (value) this._valueTipoPagamentoNf = BibliotecaEntidades.Base.TipoPagamentoNfe.ProgramaFidelidade; }
         } 

        public bool TipoPagamentoNf_SemPagamento
         { 
            get { return this._valueTipoPagamentoNf.HasValue && this._valueTipoPagamentoNf.Value == BibliotecaEntidades.Base.TipoPagamentoNfe.SemPagamento; } 
            set { if (value) this._valueTipoPagamentoNf = BibliotecaEntidades.Base.TipoPagamentoNfe.SemPagamento; }
         } 

        public bool TipoPagamentoNf_Outros
         { 
            get { return this._valueTipoPagamentoNf.HasValue && this._valueTipoPagamentoNf.Value == BibliotecaEntidades.Base.TipoPagamentoNfe.Outros; } 
            set { if (value) this._valueTipoPagamentoNf = BibliotecaEntidades.Base.TipoPagamentoNfe.Outros; }
         } 

       protected string _tipoPagamentoNfDescricaoOriginal{get;private set;}
       private string _tipoPagamentoNfDescricaoOriginalCommited{get; set;}
        private string _valueTipoPagamentoNfDescricao;
         [Column("tip_tipo_pagamento_nf_descricao")]
        public virtual string TipoPagamentoNfDescricao
         { 
            get { return this._valueTipoPagamentoNfDescricao; } 
            set 
            { 
                if (this._valueTipoPagamentoNfDescricao == value)return;
                 this._valueTipoPagamentoNfDescricao = value; 
            } 
        } 

       private List<long> _collectionClienteClassTipoPagamentoOriginal;
       private List<Entidades.ClienteClass > _collectionClienteClassTipoPagamentoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionClienteClassTipoPagamentoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionClienteClassTipoPagamentoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionClienteClassTipoPagamentoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ClienteClass> _valueCollectionClienteClassTipoPagamento { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ClienteClass> CollectionClienteClassTipoPagamento 
       { 
           get { if(!_valueCollectionClienteClassTipoPagamentoLoaded && !this.DisableLoadCollection){this.LoadCollectionClienteClassTipoPagamento();}
return this._valueCollectionClienteClassTipoPagamento; } 
           set 
           { 
               this._valueCollectionClienteClassTipoPagamento = value; 
               this._valueCollectionClienteClassTipoPagamentoLoaded = true; 
           } 
       } 

       private List<long> _collectionContaPagarClassTipoPagamentoOriginal;
       private List<Entidades.ContaPagarClass > _collectionContaPagarClassTipoPagamentoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaPagarClassTipoPagamentoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaPagarClassTipoPagamentoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaPagarClassTipoPagamentoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ContaPagarClass> _valueCollectionContaPagarClassTipoPagamento { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ContaPagarClass> CollectionContaPagarClassTipoPagamento 
       { 
           get { if(!_valueCollectionContaPagarClassTipoPagamentoLoaded && !this.DisableLoadCollection){this.LoadCollectionContaPagarClassTipoPagamento();}
return this._valueCollectionContaPagarClassTipoPagamento; } 
           set 
           { 
               this._valueCollectionContaPagarClassTipoPagamento = value; 
               this._valueCollectionContaPagarClassTipoPagamentoLoaded = true; 
           } 
       } 

       private List<long> _collectionContaReceberClassTipoPagamentoOriginal;
       private List<Entidades.ContaReceberClass > _collectionContaReceberClassTipoPagamentoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaReceberClassTipoPagamentoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaReceberClassTipoPagamentoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaReceberClassTipoPagamentoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ContaReceberClass> _valueCollectionContaReceberClassTipoPagamento { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ContaReceberClass> CollectionContaReceberClassTipoPagamento 
       { 
           get { if(!_valueCollectionContaReceberClassTipoPagamentoLoaded && !this.DisableLoadCollection){this.LoadCollectionContaReceberClassTipoPagamento();}
return this._valueCollectionContaReceberClassTipoPagamento; } 
           set 
           { 
               this._valueCollectionContaReceberClassTipoPagamento = value; 
               this._valueCollectionContaReceberClassTipoPagamentoLoaded = true; 
           } 
       } 

       private List<long> _collectionContaRecorrenteClassTipoPagamentoOriginal;
       private List<Entidades.ContaRecorrenteClass > _collectionContaRecorrenteClassTipoPagamentoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaRecorrenteClassTipoPagamentoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaRecorrenteClassTipoPagamentoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaRecorrenteClassTipoPagamentoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ContaRecorrenteClass> _valueCollectionContaRecorrenteClassTipoPagamento { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ContaRecorrenteClass> CollectionContaRecorrenteClassTipoPagamento 
       { 
           get { if(!_valueCollectionContaRecorrenteClassTipoPagamentoLoaded && !this.DisableLoadCollection){this.LoadCollectionContaRecorrenteClassTipoPagamento();}
return this._valueCollectionContaRecorrenteClassTipoPagamento; } 
           set 
           { 
               this._valueCollectionContaRecorrenteClassTipoPagamento = value; 
               this._valueCollectionContaRecorrenteClassTipoPagamentoLoaded = true; 
           } 
       } 

       private List<long> _collectionPedidoItemClassTipoPagamentoOriginal;
       private List<Entidades.PedidoItemClass > _collectionPedidoItemClassTipoPagamentoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassTipoPagamentoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassTipoPagamentoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassTipoPagamentoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PedidoItemClass> _valueCollectionPedidoItemClassTipoPagamento { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PedidoItemClass> CollectionPedidoItemClassTipoPagamento 
       { 
           get { if(!_valueCollectionPedidoItemClassTipoPagamentoLoaded && !this.DisableLoadCollection){this.LoadCollectionPedidoItemClassTipoPagamento();}
return this._valueCollectionPedidoItemClassTipoPagamento; } 
           set 
           { 
               this._valueCollectionPedidoItemClassTipoPagamento = value; 
               this._valueCollectionPedidoItemClassTipoPagamentoLoaded = true; 
           } 
       } 

        public TipoPagamentoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static TipoPagamentoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (TipoPagamentoClass) GetEntity(typeof(TipoPagamentoClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionClienteClassTipoPagamentoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionClienteClassTipoPagamentoChanged = true;
                  _valueCollectionClienteClassTipoPagamentoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionClienteClassTipoPagamentoChanged = true; 
                  _valueCollectionClienteClassTipoPagamentoCommitedChanged = true;
                 foreach (Entidades.ClienteClass item in e.OldItems) 
                 { 
                     _collectionClienteClassTipoPagamentoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionClienteClassTipoPagamentoChanged = true; 
                  _valueCollectionClienteClassTipoPagamentoCommitedChanged = true;
                 foreach (Entidades.ClienteClass item in _valueCollectionClienteClassTipoPagamento) 
                 { 
                     _collectionClienteClassTipoPagamentoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionClienteClassTipoPagamento()
         {
            try
            {
                 ObservableCollection<Entidades.ClienteClass> oc;
                _valueCollectionClienteClassTipoPagamentoChanged = false;
                 _valueCollectionClienteClassTipoPagamentoCommitedChanged = false;
                _collectionClienteClassTipoPagamentoRemovidos = new List<Entidades.ClienteClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ClienteClass>();
                }
                else{ 
                   Entidades.ClienteClass search = new Entidades.ClienteClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ClienteClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("TipoPagamento", this),                     }                       ).Cast<Entidades.ClienteClass>().ToList());
                 }
                 _valueCollectionClienteClassTipoPagamento = new BindingList<Entidades.ClienteClass>(oc); 
                 _collectionClienteClassTipoPagamentoOriginal= (from a in _valueCollectionClienteClassTipoPagamento select a.ID).ToList();
                 _valueCollectionClienteClassTipoPagamentoLoaded = true;
                 oc.CollectionChanged += CollectionClienteClassTipoPagamentoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionClienteClassTipoPagamento+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionContaPagarClassTipoPagamentoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionContaPagarClassTipoPagamentoChanged = true;
                  _valueCollectionContaPagarClassTipoPagamentoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionContaPagarClassTipoPagamentoChanged = true; 
                  _valueCollectionContaPagarClassTipoPagamentoCommitedChanged = true;
                 foreach (Entidades.ContaPagarClass item in e.OldItems) 
                 { 
                     _collectionContaPagarClassTipoPagamentoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionContaPagarClassTipoPagamentoChanged = true; 
                  _valueCollectionContaPagarClassTipoPagamentoCommitedChanged = true;
                 foreach (Entidades.ContaPagarClass item in _valueCollectionContaPagarClassTipoPagamento) 
                 { 
                     _collectionContaPagarClassTipoPagamentoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionContaPagarClassTipoPagamento()
         {
            try
            {
                 ObservableCollection<Entidades.ContaPagarClass> oc;
                _valueCollectionContaPagarClassTipoPagamentoChanged = false;
                 _valueCollectionContaPagarClassTipoPagamentoCommitedChanged = false;
                _collectionContaPagarClassTipoPagamentoRemovidos = new List<Entidades.ContaPagarClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ContaPagarClass>();
                }
                else{ 
                   Entidades.ContaPagarClass search = new Entidades.ContaPagarClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ContaPagarClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("TipoPagamento", this),                     }                       ).Cast<Entidades.ContaPagarClass>().ToList());
                 }
                 _valueCollectionContaPagarClassTipoPagamento = new BindingList<Entidades.ContaPagarClass>(oc); 
                 _collectionContaPagarClassTipoPagamentoOriginal= (from a in _valueCollectionContaPagarClassTipoPagamento select a.ID).ToList();
                 _valueCollectionContaPagarClassTipoPagamentoLoaded = true;
                 oc.CollectionChanged += CollectionContaPagarClassTipoPagamentoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionContaPagarClassTipoPagamento+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionContaReceberClassTipoPagamentoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionContaReceberClassTipoPagamentoChanged = true;
                  _valueCollectionContaReceberClassTipoPagamentoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionContaReceberClassTipoPagamentoChanged = true; 
                  _valueCollectionContaReceberClassTipoPagamentoCommitedChanged = true;
                 foreach (Entidades.ContaReceberClass item in e.OldItems) 
                 { 
                     _collectionContaReceberClassTipoPagamentoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionContaReceberClassTipoPagamentoChanged = true; 
                  _valueCollectionContaReceberClassTipoPagamentoCommitedChanged = true;
                 foreach (Entidades.ContaReceberClass item in _valueCollectionContaReceberClassTipoPagamento) 
                 { 
                     _collectionContaReceberClassTipoPagamentoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionContaReceberClassTipoPagamento()
         {
            try
            {
                 ObservableCollection<Entidades.ContaReceberClass> oc;
                _valueCollectionContaReceberClassTipoPagamentoChanged = false;
                 _valueCollectionContaReceberClassTipoPagamentoCommitedChanged = false;
                _collectionContaReceberClassTipoPagamentoRemovidos = new List<Entidades.ContaReceberClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ContaReceberClass>();
                }
                else{ 
                   Entidades.ContaReceberClass search = new Entidades.ContaReceberClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ContaReceberClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("TipoPagamento", this)                    }                       ).Cast<Entidades.ContaReceberClass>().ToList());
                 }
                 _valueCollectionContaReceberClassTipoPagamento = new BindingList<Entidades.ContaReceberClass>(oc); 
                 _collectionContaReceberClassTipoPagamentoOriginal= (from a in _valueCollectionContaReceberClassTipoPagamento select a.ID).ToList();
                 _valueCollectionContaReceberClassTipoPagamentoLoaded = true;
                 oc.CollectionChanged += CollectionContaReceberClassTipoPagamentoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionContaReceberClassTipoPagamento+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionContaRecorrenteClassTipoPagamentoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionContaRecorrenteClassTipoPagamentoChanged = true;
                  _valueCollectionContaRecorrenteClassTipoPagamentoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionContaRecorrenteClassTipoPagamentoChanged = true; 
                  _valueCollectionContaRecorrenteClassTipoPagamentoCommitedChanged = true;
                 foreach (Entidades.ContaRecorrenteClass item in e.OldItems) 
                 { 
                     _collectionContaRecorrenteClassTipoPagamentoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionContaRecorrenteClassTipoPagamentoChanged = true; 
                  _valueCollectionContaRecorrenteClassTipoPagamentoCommitedChanged = true;
                 foreach (Entidades.ContaRecorrenteClass item in _valueCollectionContaRecorrenteClassTipoPagamento) 
                 { 
                     _collectionContaRecorrenteClassTipoPagamentoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionContaRecorrenteClassTipoPagamento()
         {
            try
            {
                 ObservableCollection<Entidades.ContaRecorrenteClass> oc;
                _valueCollectionContaRecorrenteClassTipoPagamentoChanged = false;
                 _valueCollectionContaRecorrenteClassTipoPagamentoCommitedChanged = false;
                _collectionContaRecorrenteClassTipoPagamentoRemovidos = new List<Entidades.ContaRecorrenteClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ContaRecorrenteClass>();
                }
                else{ 
                   Entidades.ContaRecorrenteClass search = new Entidades.ContaRecorrenteClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ContaRecorrenteClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("TipoPagamento", this),                     }                       ).Cast<Entidades.ContaRecorrenteClass>().ToList());
                 }
                 _valueCollectionContaRecorrenteClassTipoPagamento = new BindingList<Entidades.ContaRecorrenteClass>(oc); 
                 _collectionContaRecorrenteClassTipoPagamentoOriginal= (from a in _valueCollectionContaRecorrenteClassTipoPagamento select a.ID).ToList();
                 _valueCollectionContaRecorrenteClassTipoPagamentoLoaded = true;
                 oc.CollectionChanged += CollectionContaRecorrenteClassTipoPagamentoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionContaRecorrenteClassTipoPagamento+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPedidoItemClassTipoPagamentoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPedidoItemClassTipoPagamentoChanged = true;
                  _valueCollectionPedidoItemClassTipoPagamentoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPedidoItemClassTipoPagamentoChanged = true; 
                  _valueCollectionPedidoItemClassTipoPagamentoCommitedChanged = true;
                 foreach (Entidades.PedidoItemClass item in e.OldItems) 
                 { 
                     _collectionPedidoItemClassTipoPagamentoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPedidoItemClassTipoPagamentoChanged = true; 
                  _valueCollectionPedidoItemClassTipoPagamentoCommitedChanged = true;
                 foreach (Entidades.PedidoItemClass item in _valueCollectionPedidoItemClassTipoPagamento) 
                 { 
                     _collectionPedidoItemClassTipoPagamentoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPedidoItemClassTipoPagamento()
         {
            try
            {
                 ObservableCollection<Entidades.PedidoItemClass> oc;
                _valueCollectionPedidoItemClassTipoPagamentoChanged = false;
                 _valueCollectionPedidoItemClassTipoPagamentoCommitedChanged = false;
                _collectionPedidoItemClassTipoPagamentoRemovidos = new List<Entidades.PedidoItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PedidoItemClass>();
                }
                else{ 
                   Entidades.PedidoItemClass search = new Entidades.PedidoItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PedidoItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("TipoPagamento", this),                     }                       ).Cast<Entidades.PedidoItemClass>().ToList());
                 }
                 _valueCollectionPedidoItemClassTipoPagamento = new BindingList<Entidades.PedidoItemClass>(oc); 
                 _collectionPedidoItemClassTipoPagamentoOriginal= (from a in _valueCollectionPedidoItemClassTipoPagamento select a.ID).ToList();
                 _valueCollectionPedidoItemClassTipoPagamentoLoaded = true;
                 oc.CollectionChanged += CollectionPedidoItemClassTipoPagamentoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPedidoItemClassTipoPagamento+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
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
                    "  public.tipo_pagamento  " +
                    "WHERE " +
                    "  id_tipo_pagamento = :id";
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
                        "  public.tipo_pagamento   " +
                        "SET  " + 
                        "  tip_identificacao = :tip_identificacao, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  tip_tipo_pagamento_nf = :tip_tipo_pagamento_nf, " + 
                        "  tip_tipo_pagamento_nf_descricao = :tip_tipo_pagamento_nf_descricao "+
                        "WHERE  " +
                        "  id_tipo_pagamento = :id " +
                        "RETURNING id_tipo_pagamento;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.tipo_pagamento " +
                        "( " +
                        "  tip_identificacao , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  tip_tipo_pagamento_nf , " + 
                        "  tip_tipo_pagamento_nf_descricao  "+
                        ")  " +
                        "VALUES ( " +
                        "  :tip_identificacao , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :tip_tipo_pagamento_nf , " + 
                        "  :tip_tipo_pagamento_nf_descricao  "+
                        ")RETURNING id_tipo_pagamento;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tip_identificacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Identificacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tip_tipo_pagamento_nf", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = this.TipoPagamentoNf.HasValue ? (object)Convert.ToInt16(this.TipoPagamentoNf) : (object)DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tip_tipo_pagamento_nf_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.TipoPagamentoNfDescricao ?? DBNull.Value;

 
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
 if (CollectionClienteClassTipoPagamento.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionClienteClassTipoPagamento+"\r\n";
                foreach (Entidades.ClienteClass tmp in CollectionClienteClassTipoPagamento)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionContaPagarClassTipoPagamento.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionContaPagarClassTipoPagamento+"\r\n";
                foreach (Entidades.ContaPagarClass tmp in CollectionContaPagarClassTipoPagamento)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionContaReceberClassTipoPagamento.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionContaReceberClassTipoPagamento+"\r\n";
                foreach (Entidades.ContaReceberClass tmp in CollectionContaReceberClassTipoPagamento)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionContaRecorrenteClassTipoPagamento.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionContaRecorrenteClassTipoPagamento+"\r\n";
                foreach (Entidades.ContaRecorrenteClass tmp in CollectionContaRecorrenteClassTipoPagamento)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPedidoItemClassTipoPagamento.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPedidoItemClassTipoPagamento+"\r\n";
                foreach (Entidades.PedidoItemClass tmp in CollectionPedidoItemClassTipoPagamento)
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
        public static TipoPagamentoClass CopiarEntidade(TipoPagamentoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               TipoPagamentoClass toRet = new TipoPagamentoClass(usuario,conn);
 toRet.Identificacao= entidadeCopiar.Identificacao;
 toRet.TipoPagamentoNf= entidadeCopiar.TipoPagamentoNf;
 toRet.TipoPagamentoNfDescricao= entidadeCopiar.TipoPagamentoNfDescricao;

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
       _identificacaoOriginal = Identificacao;
       _identificacaoOriginalCommited = _identificacaoOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _tipoPagamentoNfOriginal = TipoPagamentoNf;
       _tipoPagamentoNfOriginalCommited = _tipoPagamentoNfOriginal;
       _tipoPagamentoNfDescricaoOriginal = TipoPagamentoNfDescricao;
       _tipoPagamentoNfDescricaoOriginalCommited = _tipoPagamentoNfDescricaoOriginal;

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
       _identificacaoOriginalCommited = Identificacao;
       _versionOriginalCommited = Version;
       _tipoPagamentoNfOriginalCommited = TipoPagamentoNf;
       _tipoPagamentoNfDescricaoOriginalCommited = TipoPagamentoNfDescricao;

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
               if (_valueCollectionClienteClassTipoPagamentoLoaded) 
               {
                  if (_collectionClienteClassTipoPagamentoRemovidos != null) 
                  {
                     _collectionClienteClassTipoPagamentoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionClienteClassTipoPagamentoRemovidos = new List<Entidades.ClienteClass>();
                  }
                  _collectionClienteClassTipoPagamentoOriginal= (from a in _valueCollectionClienteClassTipoPagamento select a.ID).ToList();
                  _valueCollectionClienteClassTipoPagamentoChanged = false;
                  _valueCollectionClienteClassTipoPagamentoCommitedChanged = false;
               }
               if (_valueCollectionContaPagarClassTipoPagamentoLoaded) 
               {
                  if (_collectionContaPagarClassTipoPagamentoRemovidos != null) 
                  {
                     _collectionContaPagarClassTipoPagamentoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionContaPagarClassTipoPagamentoRemovidos = new List<Entidades.ContaPagarClass>();
                  }
                  _collectionContaPagarClassTipoPagamentoOriginal= (from a in _valueCollectionContaPagarClassTipoPagamento select a.ID).ToList();
                  _valueCollectionContaPagarClassTipoPagamentoChanged = false;
                  _valueCollectionContaPagarClassTipoPagamentoCommitedChanged = false;
               }
               if (_valueCollectionContaReceberClassTipoPagamentoLoaded) 
               {
                  if (_collectionContaReceberClassTipoPagamentoRemovidos != null) 
                  {
                     _collectionContaReceberClassTipoPagamentoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionContaReceberClassTipoPagamentoRemovidos = new List<Entidades.ContaReceberClass>();
                  }
                  _collectionContaReceberClassTipoPagamentoOriginal= (from a in _valueCollectionContaReceberClassTipoPagamento select a.ID).ToList();
                  _valueCollectionContaReceberClassTipoPagamentoChanged = false;
                  _valueCollectionContaReceberClassTipoPagamentoCommitedChanged = false;
               }
               if (_valueCollectionContaRecorrenteClassTipoPagamentoLoaded) 
               {
                  if (_collectionContaRecorrenteClassTipoPagamentoRemovidos != null) 
                  {
                     _collectionContaRecorrenteClassTipoPagamentoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionContaRecorrenteClassTipoPagamentoRemovidos = new List<Entidades.ContaRecorrenteClass>();
                  }
                  _collectionContaRecorrenteClassTipoPagamentoOriginal= (from a in _valueCollectionContaRecorrenteClassTipoPagamento select a.ID).ToList();
                  _valueCollectionContaRecorrenteClassTipoPagamentoChanged = false;
                  _valueCollectionContaRecorrenteClassTipoPagamentoCommitedChanged = false;
               }
               if (_valueCollectionPedidoItemClassTipoPagamentoLoaded) 
               {
                  if (_collectionPedidoItemClassTipoPagamentoRemovidos != null) 
                  {
                     _collectionPedidoItemClassTipoPagamentoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPedidoItemClassTipoPagamentoRemovidos = new List<Entidades.PedidoItemClass>();
                  }
                  _collectionPedidoItemClassTipoPagamentoOriginal= (from a in _valueCollectionPedidoItemClassTipoPagamento select a.ID).ToList();
                  _valueCollectionPedidoItemClassTipoPagamentoChanged = false;
                  _valueCollectionPedidoItemClassTipoPagamentoCommitedChanged = false;
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
               Identificacao=_identificacaoOriginal;
               _identificacaoOriginalCommited=_identificacaoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               TipoPagamentoNf=_tipoPagamentoNfOriginal;
               _tipoPagamentoNfOriginalCommited=_tipoPagamentoNfOriginal;
               TipoPagamentoNfDescricao=_tipoPagamentoNfDescricaoOriginal;
               _tipoPagamentoNfDescricaoOriginalCommited=_tipoPagamentoNfDescricaoOriginal;
               if (_valueCollectionClienteClassTipoPagamentoLoaded) 
               {
                  CollectionClienteClassTipoPagamento.Clear();
                  foreach(int item in _collectionClienteClassTipoPagamentoOriginal)
                  {
                    CollectionClienteClassTipoPagamento.Add(Entidades.ClienteClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionClienteClassTipoPagamentoRemovidos.Clear();
               }
               if (_valueCollectionContaPagarClassTipoPagamentoLoaded) 
               {
                  CollectionContaPagarClassTipoPagamento.Clear();
                  foreach(int item in _collectionContaPagarClassTipoPagamentoOriginal)
                  {
                    CollectionContaPagarClassTipoPagamento.Add(Entidades.ContaPagarClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionContaPagarClassTipoPagamentoRemovidos.Clear();
               }
               if (_valueCollectionContaReceberClassTipoPagamentoLoaded) 
               {
                  CollectionContaReceberClassTipoPagamento.Clear();
                  foreach(int item in _collectionContaReceberClassTipoPagamentoOriginal)
                  {
                    CollectionContaReceberClassTipoPagamento.Add(Entidades.ContaReceberClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionContaReceberClassTipoPagamentoRemovidos.Clear();
               }
               if (_valueCollectionContaRecorrenteClassTipoPagamentoLoaded) 
               {
                  CollectionContaRecorrenteClassTipoPagamento.Clear();
                  foreach(int item in _collectionContaRecorrenteClassTipoPagamentoOriginal)
                  {
                    CollectionContaRecorrenteClassTipoPagamento.Add(Entidades.ContaRecorrenteClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionContaRecorrenteClassTipoPagamentoRemovidos.Clear();
               }
               if (_valueCollectionPedidoItemClassTipoPagamentoLoaded) 
               {
                  CollectionPedidoItemClassTipoPagamento.Clear();
                  foreach(int item in _collectionPedidoItemClassTipoPagamentoOriginal)
                  {
                    CollectionPedidoItemClassTipoPagamento.Add(Entidades.PedidoItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPedidoItemClassTipoPagamentoRemovidos.Clear();
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
               if (_valueCollectionClienteClassTipoPagamentoLoaded) 
               {
                  if (_valueCollectionClienteClassTipoPagamentoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaPagarClassTipoPagamentoLoaded) 
               {
                  if (_valueCollectionContaPagarClassTipoPagamentoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaReceberClassTipoPagamentoLoaded) 
               {
                  if (_valueCollectionContaReceberClassTipoPagamentoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaRecorrenteClassTipoPagamentoLoaded) 
               {
                  if (_valueCollectionContaRecorrenteClassTipoPagamentoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemClassTipoPagamentoLoaded) 
               {
                  if (_valueCollectionPedidoItemClassTipoPagamentoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionClienteClassTipoPagamentoLoaded) 
               {
                   tempRet = CollectionClienteClassTipoPagamento.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionContaPagarClassTipoPagamentoLoaded) 
               {
                   tempRet = CollectionContaPagarClassTipoPagamento.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionContaReceberClassTipoPagamentoLoaded) 
               {
                   tempRet = CollectionContaReceberClassTipoPagamento.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionContaRecorrenteClassTipoPagamentoLoaded) 
               {
                   tempRet = CollectionContaRecorrenteClassTipoPagamento.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemClassTipoPagamentoLoaded) 
               {
                   tempRet = CollectionPedidoItemClassTipoPagamento.Any(item => item.IsDirty());
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
       dirty = _identificacaoOriginal != Identificacao;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _tipoPagamentoNfOriginal != TipoPagamentoNf;
      if (dirty) return true;
       dirty = _tipoPagamentoNfDescricaoOriginal != TipoPagamentoNfDescricao;

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
               if (_valueCollectionClienteClassTipoPagamentoLoaded) 
               {
                  if (_valueCollectionClienteClassTipoPagamentoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaPagarClassTipoPagamentoLoaded) 
               {
                  if (_valueCollectionContaPagarClassTipoPagamentoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaReceberClassTipoPagamentoLoaded) 
               {
                  if (_valueCollectionContaReceberClassTipoPagamentoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaRecorrenteClassTipoPagamentoLoaded) 
               {
                  if (_valueCollectionContaRecorrenteClassTipoPagamentoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemClassTipoPagamentoLoaded) 
               {
                  if (_valueCollectionPedidoItemClassTipoPagamentoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionClienteClassTipoPagamentoLoaded) 
               {
                   tempRet = CollectionClienteClassTipoPagamento.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionContaPagarClassTipoPagamentoLoaded) 
               {
                   tempRet = CollectionContaPagarClassTipoPagamento.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionContaReceberClassTipoPagamentoLoaded) 
               {
                   tempRet = CollectionContaReceberClassTipoPagamento.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionContaRecorrenteClassTipoPagamentoLoaded) 
               {
                   tempRet = CollectionContaRecorrenteClassTipoPagamento.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemClassTipoPagamentoLoaded) 
               {
                   tempRet = CollectionPedidoItemClassTipoPagamento.Any(item => item.IsDirtyCommited());
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
       dirty = _identificacaoOriginalCommited != Identificacao;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _tipoPagamentoNfOriginalCommited != TipoPagamentoNf;
      if (dirty) return true;
       dirty = _tipoPagamentoNfDescricaoOriginalCommited != TipoPagamentoNfDescricao;

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
               if (_valueCollectionClienteClassTipoPagamentoLoaded) 
               {
                  foreach(ClienteClass item in CollectionClienteClassTipoPagamento)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionContaPagarClassTipoPagamentoLoaded) 
               {
                  foreach(ContaPagarClass item in CollectionContaPagarClassTipoPagamento)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionContaReceberClassTipoPagamentoLoaded) 
               {
                  foreach(ContaReceberClass item in CollectionContaReceberClassTipoPagamento)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionContaRecorrenteClassTipoPagamentoLoaded) 
               {
                  foreach(ContaRecorrenteClass item in CollectionContaRecorrenteClassTipoPagamento)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPedidoItemClassTipoPagamentoLoaded) 
               {
                  foreach(PedidoItemClass item in CollectionPedidoItemClassTipoPagamento)
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
             case "Identificacao":
                return this.Identificacao;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "TipoPagamentoNf":
                return this.TipoPagamentoNf;
             case "TipoPagamentoNfDescricao":
                return this.TipoPagamentoNfDescricao;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
               if (_valueCollectionClienteClassTipoPagamentoLoaded) 
               {
                  foreach(ClienteClass item in CollectionClienteClassTipoPagamento)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionContaPagarClassTipoPagamentoLoaded) 
               {
                  foreach(ContaPagarClass item in CollectionContaPagarClassTipoPagamento)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionContaReceberClassTipoPagamentoLoaded) 
               {
                  foreach(ContaReceberClass item in CollectionContaReceberClassTipoPagamento)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionContaRecorrenteClassTipoPagamentoLoaded) 
               {
                  foreach(ContaRecorrenteClass item in CollectionContaRecorrenteClassTipoPagamento)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPedidoItemClassTipoPagamentoLoaded) 
               {
                  foreach(PedidoItemClass item in CollectionPedidoItemClassTipoPagamento)
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
                  command.CommandText += " COUNT(tipo_pagamento.id_tipo_pagamento) " ;
               }
               else
               {
               command.CommandText += "tipo_pagamento.id_tipo_pagamento, " ;
               command.CommandText += "tipo_pagamento.tip_identificacao, " ;
               command.CommandText += "tipo_pagamento.entity_uid, " ;
               command.CommandText += "tipo_pagamento.version, " ;
               command.CommandText += "tipo_pagamento.tip_tipo_pagamento_nf, " ;
               command.CommandText += "tipo_pagamento.tip_tipo_pagamento_nf_descricao " ;
               }
               command.CommandText += " FROM  tipo_pagamento ";
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
                        orderByClause += " , tip_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(tip_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = tipo_pagamento.id_acs_usuario_ultima_revisao ";
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
                     case "id_tipo_pagamento":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , tipo_pagamento.id_tipo_pagamento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(tipo_pagamento.id_tipo_pagamento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "tip_identificacao":
                     case "Identificacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , tipo_pagamento.tip_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(tipo_pagamento.tip_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , tipo_pagamento.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(tipo_pagamento.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , tipo_pagamento.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(tipo_pagamento.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "tip_tipo_pagamento_nf":
                     case "TipoPagamentoNf":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , tipo_pagamento.tip_tipo_pagamento_nf " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(tipo_pagamento.tip_tipo_pagamento_nf) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "tip_tipo_pagamento_nf_descricao":
                     case "TipoPagamentoNfDescricao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , tipo_pagamento.tip_tipo_pagamento_nf_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(tipo_pagamento.tip_tipo_pagamento_nf_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("tip_identificacao")) 
                        {
                           whereClause += " OR UPPER(tipo_pagamento.tip_identificacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(tipo_pagamento.tip_identificacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(tipo_pagamento.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(tipo_pagamento.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("tip_tipo_pagamento_nf_descricao")) 
                        {
                           whereClause += " OR UPPER(tipo_pagamento.tip_tipo_pagamento_nf_descricao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(tipo_pagamento.tip_tipo_pagamento_nf_descricao) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_tipo_pagamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  tipo_pagamento.id_tipo_pagamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  tipo_pagamento.id_tipo_pagamento = :tipo_pagamento_ID_2255 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tipo_pagamento_ID_2255", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Identificacao" || parametro.FieldName == "tip_identificacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  tipo_pagamento.tip_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  tipo_pagamento.tip_identificacao LIKE :tipo_pagamento_Identificacao_9227 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tipo_pagamento_Identificacao_9227", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  tipo_pagamento.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  tipo_pagamento.entity_uid LIKE :tipo_pagamento_EntityUid_6694 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tipo_pagamento_EntityUid_6694", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  tipo_pagamento.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  tipo_pagamento.version = :tipo_pagamento_Version_172 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tipo_pagamento_Version_172", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoPagamentoNf" || parametro.FieldName == "tip_tipo_pagamento_nf")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is TipoPagamentoNfe?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo TipoPagamentoNfe?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  tipo_pagamento.tip_tipo_pagamento_nf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  tipo_pagamento.tip_tipo_pagamento_nf = :tipo_pagamento_TipoPagamentoNf_7366 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tipo_pagamento_TipoPagamentoNf_7366", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoPagamentoNfDescricao" || parametro.FieldName == "tip_tipo_pagamento_nf_descricao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  tipo_pagamento.tip_tipo_pagamento_nf_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  tipo_pagamento.tip_tipo_pagamento_nf_descricao LIKE :tipo_pagamento_TipoPagamentoNfDescricao_1112 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tipo_pagamento_TipoPagamentoNfDescricao_1112", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  tipo_pagamento.tip_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  tipo_pagamento.tip_identificacao LIKE :tipo_pagamento_Identificacao_6327 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tipo_pagamento_Identificacao_6327", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  tipo_pagamento.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  tipo_pagamento.entity_uid LIKE :tipo_pagamento_EntityUid_6791 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tipo_pagamento_EntityUid_6791", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoPagamentoNfDescricaoExato" || parametro.FieldName == "TipoPagamentoNfDescricaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  tipo_pagamento.tip_tipo_pagamento_nf_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  tipo_pagamento.tip_tipo_pagamento_nf_descricao LIKE :tipo_pagamento_TipoPagamentoNfDescricao_7337 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tipo_pagamento_TipoPagamentoNfDescricao_7337", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  TipoPagamentoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (TipoPagamentoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(TipoPagamentoClass), Convert.ToInt32(read["id_tipo_pagamento"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new TipoPagamentoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_tipo_pagamento"]);
                     entidade.Identificacao = (read["tip_identificacao"] != DBNull.Value ? read["tip_identificacao"].ToString() : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.TipoPagamentoNf = (TipoPagamentoNfe?) (read["tip_tipo_pagamento_nf"] != DBNull.Value ? Enum.ToObject(Nullable.GetUnderlyingType(typeof(TipoPagamentoNfe?)), read["tip_tipo_pagamento_nf"]) : null);
                     entidade.TipoPagamentoNfDescricao = (read["tip_tipo_pagamento_nf_descricao"] != DBNull.Value ? read["tip_tipo_pagamento_nf_descricao"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (TipoPagamentoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
