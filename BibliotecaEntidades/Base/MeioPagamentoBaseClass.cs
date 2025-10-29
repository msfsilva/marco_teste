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
     [Table("meio_pagamento","mep")]
     public class MeioPagamentoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do MeioPagamentoClass";
protected const string ErroDelete = "Erro ao excluir o MeioPagamentoClass  ";
protected const string ErroSave = "Erro ao salvar o MeioPagamentoClass.";
protected const string ErroCollectionContaPagarClassMeioPagamento = "Erro ao carregar a coleção de ContaPagarClass.";
protected const string ErroCollectionContaReceberClassMeioPagamento = "Erro ao carregar a coleção de ContaReceberClass.";
protected const string ErroCollectionFormaPagamentoClassMeioPagamento = "Erro ao carregar a coleção de FormaPagamentoClass.";
protected const string ErroCollectionPedidoItemClassMeioPagamento = "Erro ao carregar a coleção de PedidoItemClass.";
protected const string ErroCodigoObrigatorio = "O campo Codigo é obrigatório";
protected const string ErroCodigoComprimento = "O campo Codigo deve ter no máximo 2 caracteres";
protected const string ErroDescricaoObrigatorio = "O campo Descricao é obrigatório";
protected const string ErroDescricaoComprimento = "O campo Descricao deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do MeioPagamentoClass.";
protected const string MensagemUtilizadoCollectionContaPagarClassMeioPagamento =  "A entidade MeioPagamentoClass está sendo utilizada nos seguintes ContaPagarClass:";
protected const string MensagemUtilizadoCollectionContaReceberClassMeioPagamento =  "A entidade MeioPagamentoClass está sendo utilizada nos seguintes ContaReceberClass:";
protected const string MensagemUtilizadoCollectionFormaPagamentoClassMeioPagamento =  "A entidade MeioPagamentoClass está sendo utilizada nos seguintes FormaPagamentoClass:";
protected const string MensagemUtilizadoCollectionPedidoItemClassMeioPagamento =  "A entidade MeioPagamentoClass está sendo utilizada nos seguintes PedidoItemClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade MeioPagamentoClass está sendo utilizada.";
#endregion
       protected string _codigoOriginal{get;private set;}
       private string _codigoOriginalCommited{get; set;}
        private string _valueCodigo;
         [Column("mep_codigo")]
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
         [Column("mep_descricao")]
        public virtual string Descricao
         { 
            get { return this._valueDescricao; } 
            set 
            { 
                if (this._valueDescricao == value)return;
                 this._valueDescricao = value; 
            } 
        } 

       private List<long> _collectionContaPagarClassMeioPagamentoOriginal;
       private List<Entidades.ContaPagarClass > _collectionContaPagarClassMeioPagamentoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaPagarClassMeioPagamentoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaPagarClassMeioPagamentoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaPagarClassMeioPagamentoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ContaPagarClass> _valueCollectionContaPagarClassMeioPagamento { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ContaPagarClass> CollectionContaPagarClassMeioPagamento 
       { 
           get { if(!_valueCollectionContaPagarClassMeioPagamentoLoaded && !this.DisableLoadCollection){this.LoadCollectionContaPagarClassMeioPagamento();}
return this._valueCollectionContaPagarClassMeioPagamento; } 
           set 
           { 
               this._valueCollectionContaPagarClassMeioPagamento = value; 
               this._valueCollectionContaPagarClassMeioPagamentoLoaded = true; 
           } 
       } 

       private List<long> _collectionContaReceberClassMeioPagamentoOriginal;
       private List<Entidades.ContaReceberClass > _collectionContaReceberClassMeioPagamentoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaReceberClassMeioPagamentoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaReceberClassMeioPagamentoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaReceberClassMeioPagamentoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ContaReceberClass> _valueCollectionContaReceberClassMeioPagamento { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ContaReceberClass> CollectionContaReceberClassMeioPagamento 
       { 
           get { if(!_valueCollectionContaReceberClassMeioPagamentoLoaded && !this.DisableLoadCollection){this.LoadCollectionContaReceberClassMeioPagamento();}
return this._valueCollectionContaReceberClassMeioPagamento; } 
           set 
           { 
               this._valueCollectionContaReceberClassMeioPagamento = value; 
               this._valueCollectionContaReceberClassMeioPagamentoLoaded = true; 
           } 
       } 

       private List<long> _collectionFormaPagamentoClassMeioPagamentoOriginal;
       private List<Entidades.FormaPagamentoClass > _collectionFormaPagamentoClassMeioPagamentoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFormaPagamentoClassMeioPagamentoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFormaPagamentoClassMeioPagamentoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFormaPagamentoClassMeioPagamentoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.FormaPagamentoClass> _valueCollectionFormaPagamentoClassMeioPagamento { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.FormaPagamentoClass> CollectionFormaPagamentoClassMeioPagamento 
       { 
           get { if(!_valueCollectionFormaPagamentoClassMeioPagamentoLoaded && !this.DisableLoadCollection){this.LoadCollectionFormaPagamentoClassMeioPagamento();}
return this._valueCollectionFormaPagamentoClassMeioPagamento; } 
           set 
           { 
               this._valueCollectionFormaPagamentoClassMeioPagamento = value; 
               this._valueCollectionFormaPagamentoClassMeioPagamentoLoaded = true; 
           } 
       } 

       private List<long> _collectionPedidoItemClassMeioPagamentoOriginal;
       private List<Entidades.PedidoItemClass > _collectionPedidoItemClassMeioPagamentoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassMeioPagamentoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassMeioPagamentoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassMeioPagamentoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PedidoItemClass> _valueCollectionPedidoItemClassMeioPagamento { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PedidoItemClass> CollectionPedidoItemClassMeioPagamento 
       { 
           get { if(!_valueCollectionPedidoItemClassMeioPagamentoLoaded && !this.DisableLoadCollection){this.LoadCollectionPedidoItemClassMeioPagamento();}
return this._valueCollectionPedidoItemClassMeioPagamento; } 
           set 
           { 
               this._valueCollectionPedidoItemClassMeioPagamento = value; 
               this._valueCollectionPedidoItemClassMeioPagamentoLoaded = true; 
           } 
       } 

        public MeioPagamentoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static MeioPagamentoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (MeioPagamentoClass) GetEntity(typeof(MeioPagamentoClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionContaPagarClassMeioPagamentoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionContaPagarClassMeioPagamentoChanged = true;
                  _valueCollectionContaPagarClassMeioPagamentoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionContaPagarClassMeioPagamentoChanged = true; 
                  _valueCollectionContaPagarClassMeioPagamentoCommitedChanged = true;
                 foreach (Entidades.ContaPagarClass item in e.OldItems) 
                 { 
                     _collectionContaPagarClassMeioPagamentoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionContaPagarClassMeioPagamentoChanged = true; 
                  _valueCollectionContaPagarClassMeioPagamentoCommitedChanged = true;
                 foreach (Entidades.ContaPagarClass item in _valueCollectionContaPagarClassMeioPagamento) 
                 { 
                     _collectionContaPagarClassMeioPagamentoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionContaPagarClassMeioPagamento()
         {
            try
            {
                 ObservableCollection<Entidades.ContaPagarClass> oc;
                _valueCollectionContaPagarClassMeioPagamentoChanged = false;
                 _valueCollectionContaPagarClassMeioPagamentoCommitedChanged = false;
                _collectionContaPagarClassMeioPagamentoRemovidos = new List<Entidades.ContaPagarClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ContaPagarClass>();
                }
                else{ 
                   Entidades.ContaPagarClass search = new Entidades.ContaPagarClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ContaPagarClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("MeioPagamento", this),                     }                       ).Cast<Entidades.ContaPagarClass>().ToList());
                 }
                 _valueCollectionContaPagarClassMeioPagamento = new BindingList<Entidades.ContaPagarClass>(oc); 
                 _collectionContaPagarClassMeioPagamentoOriginal= (from a in _valueCollectionContaPagarClassMeioPagamento select a.ID).ToList();
                 _valueCollectionContaPagarClassMeioPagamentoLoaded = true;
                 oc.CollectionChanged += CollectionContaPagarClassMeioPagamentoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionContaPagarClassMeioPagamento+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionContaReceberClassMeioPagamentoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionContaReceberClassMeioPagamentoChanged = true;
                  _valueCollectionContaReceberClassMeioPagamentoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionContaReceberClassMeioPagamentoChanged = true; 
                  _valueCollectionContaReceberClassMeioPagamentoCommitedChanged = true;
                 foreach (Entidades.ContaReceberClass item in e.OldItems) 
                 { 
                     _collectionContaReceberClassMeioPagamentoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionContaReceberClassMeioPagamentoChanged = true; 
                  _valueCollectionContaReceberClassMeioPagamentoCommitedChanged = true;
                 foreach (Entidades.ContaReceberClass item in _valueCollectionContaReceberClassMeioPagamento) 
                 { 
                     _collectionContaReceberClassMeioPagamentoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionContaReceberClassMeioPagamento()
         {
            try
            {
                 ObservableCollection<Entidades.ContaReceberClass> oc;
                _valueCollectionContaReceberClassMeioPagamentoChanged = false;
                 _valueCollectionContaReceberClassMeioPagamentoCommitedChanged = false;
                _collectionContaReceberClassMeioPagamentoRemovidos = new List<Entidades.ContaReceberClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ContaReceberClass>();
                }
                else{ 
                   Entidades.ContaReceberClass search = new Entidades.ContaReceberClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ContaReceberClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("MeioPagamento", this),                     }                       ).Cast<Entidades.ContaReceberClass>().ToList());
                 }
                 _valueCollectionContaReceberClassMeioPagamento = new BindingList<Entidades.ContaReceberClass>(oc); 
                 _collectionContaReceberClassMeioPagamentoOriginal= (from a in _valueCollectionContaReceberClassMeioPagamento select a.ID).ToList();
                 _valueCollectionContaReceberClassMeioPagamentoLoaded = true;
                 oc.CollectionChanged += CollectionContaReceberClassMeioPagamentoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionContaReceberClassMeioPagamento+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionFormaPagamentoClassMeioPagamentoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionFormaPagamentoClassMeioPagamentoChanged = true;
                  _valueCollectionFormaPagamentoClassMeioPagamentoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionFormaPagamentoClassMeioPagamentoChanged = true; 
                  _valueCollectionFormaPagamentoClassMeioPagamentoCommitedChanged = true;
                 foreach (Entidades.FormaPagamentoClass item in e.OldItems) 
                 { 
                     _collectionFormaPagamentoClassMeioPagamentoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionFormaPagamentoClassMeioPagamentoChanged = true; 
                  _valueCollectionFormaPagamentoClassMeioPagamentoCommitedChanged = true;
                 foreach (Entidades.FormaPagamentoClass item in _valueCollectionFormaPagamentoClassMeioPagamento) 
                 { 
                     _collectionFormaPagamentoClassMeioPagamentoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionFormaPagamentoClassMeioPagamento()
         {
            try
            {
                 ObservableCollection<Entidades.FormaPagamentoClass> oc;
                _valueCollectionFormaPagamentoClassMeioPagamentoChanged = false;
                 _valueCollectionFormaPagamentoClassMeioPagamentoCommitedChanged = false;
                _collectionFormaPagamentoClassMeioPagamentoRemovidos = new List<Entidades.FormaPagamentoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.FormaPagamentoClass>();
                }
                else{ 
                   Entidades.FormaPagamentoClass search = new Entidades.FormaPagamentoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.FormaPagamentoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("MeioPagamento", this),                     }                       ).Cast<Entidades.FormaPagamentoClass>().ToList());
                 }
                 _valueCollectionFormaPagamentoClassMeioPagamento = new BindingList<Entidades.FormaPagamentoClass>(oc); 
                 _collectionFormaPagamentoClassMeioPagamentoOriginal= (from a in _valueCollectionFormaPagamentoClassMeioPagamento select a.ID).ToList();
                 _valueCollectionFormaPagamentoClassMeioPagamentoLoaded = true;
                 oc.CollectionChanged += CollectionFormaPagamentoClassMeioPagamentoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionFormaPagamentoClassMeioPagamento+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPedidoItemClassMeioPagamentoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPedidoItemClassMeioPagamentoChanged = true;
                  _valueCollectionPedidoItemClassMeioPagamentoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPedidoItemClassMeioPagamentoChanged = true; 
                  _valueCollectionPedidoItemClassMeioPagamentoCommitedChanged = true;
                 foreach (Entidades.PedidoItemClass item in e.OldItems) 
                 { 
                     _collectionPedidoItemClassMeioPagamentoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPedidoItemClassMeioPagamentoChanged = true; 
                  _valueCollectionPedidoItemClassMeioPagamentoCommitedChanged = true;
                 foreach (Entidades.PedidoItemClass item in _valueCollectionPedidoItemClassMeioPagamento) 
                 { 
                     _collectionPedidoItemClassMeioPagamentoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPedidoItemClassMeioPagamento()
         {
            try
            {
                 ObservableCollection<Entidades.PedidoItemClass> oc;
                _valueCollectionPedidoItemClassMeioPagamentoChanged = false;
                 _valueCollectionPedidoItemClassMeioPagamentoCommitedChanged = false;
                _collectionPedidoItemClassMeioPagamentoRemovidos = new List<Entidades.PedidoItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PedidoItemClass>();
                }
                else{ 
                   Entidades.PedidoItemClass search = new Entidades.PedidoItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PedidoItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("MeioPagamento", this),                     }                       ).Cast<Entidades.PedidoItemClass>().ToList());
                 }
                 _valueCollectionPedidoItemClassMeioPagamento = new BindingList<Entidades.PedidoItemClass>(oc); 
                 _collectionPedidoItemClassMeioPagamentoOriginal= (from a in _valueCollectionPedidoItemClassMeioPagamento select a.ID).ToList();
                 _valueCollectionPedidoItemClassMeioPagamentoLoaded = true;
                 oc.CollectionChanged += CollectionPedidoItemClassMeioPagamentoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPedidoItemClassMeioPagamento+"\r\n" + e.Message, e);
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
                if (Codigo.Length >2)
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
                    "  public.meio_pagamento  " +
                    "WHERE " +
                    "  id_meio_pagamento = :id";
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
                        "  public.meio_pagamento   " +
                        "SET  " + 
                        "  mep_codigo = :mep_codigo, " + 
                        "  mep_descricao = :mep_descricao, " + 
                        "  version = :version, " + 
                        "  entity_uid = :entity_uid "+
                        "WHERE  " +
                        "  id_meio_pagamento = :id " +
                        "RETURNING id_meio_pagamento;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.meio_pagamento " +
                        "( " +
                        "  mep_codigo , " + 
                        "  mep_descricao , " + 
                        "  version , " + 
                        "  entity_uid  "+
                        ")  " +
                        "VALUES ( " +
                        "  :mep_codigo , " + 
                        "  :mep_descricao , " + 
                        "  :version , " + 
                        "  :entity_uid  "+
                        ")RETURNING id_meio_pagamento;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mep_codigo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Codigo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mep_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Descricao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;

 
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
 if (CollectionContaPagarClassMeioPagamento.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionContaPagarClassMeioPagamento+"\r\n";
                foreach (Entidades.ContaPagarClass tmp in CollectionContaPagarClassMeioPagamento)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionContaReceberClassMeioPagamento.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionContaReceberClassMeioPagamento+"\r\n";
                foreach (Entidades.ContaReceberClass tmp in CollectionContaReceberClassMeioPagamento)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionFormaPagamentoClassMeioPagamento.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionFormaPagamentoClassMeioPagamento+"\r\n";
                foreach (Entidades.FormaPagamentoClass tmp in CollectionFormaPagamentoClassMeioPagamento)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPedidoItemClassMeioPagamento.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPedidoItemClassMeioPagamento+"\r\n";
                foreach (Entidades.PedidoItemClass tmp in CollectionPedidoItemClassMeioPagamento)
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
        public static MeioPagamentoClass CopiarEntidade(MeioPagamentoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               MeioPagamentoClass toRet = new MeioPagamentoClass(usuario,conn);
 toRet.Codigo= entidadeCopiar.Codigo;
 toRet.Descricao= entidadeCopiar.Descricao;

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
       _codigoOriginal = Codigo;
       _codigoOriginalCommited = _codigoOriginal;
       _descricaoOriginal = Descricao;
       _descricaoOriginalCommited = _descricaoOriginal;
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
       _codigoOriginalCommited = Codigo;
       _descricaoOriginalCommited = Descricao;
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
               if (_valueCollectionContaPagarClassMeioPagamentoLoaded) 
               {
                  if (_collectionContaPagarClassMeioPagamentoRemovidos != null) 
                  {
                     _collectionContaPagarClassMeioPagamentoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionContaPagarClassMeioPagamentoRemovidos = new List<Entidades.ContaPagarClass>();
                  }
                  _collectionContaPagarClassMeioPagamentoOriginal= (from a in _valueCollectionContaPagarClassMeioPagamento select a.ID).ToList();
                  _valueCollectionContaPagarClassMeioPagamentoChanged = false;
                  _valueCollectionContaPagarClassMeioPagamentoCommitedChanged = false;
               }
               if (_valueCollectionContaReceberClassMeioPagamentoLoaded) 
               {
                  if (_collectionContaReceberClassMeioPagamentoRemovidos != null) 
                  {
                     _collectionContaReceberClassMeioPagamentoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionContaReceberClassMeioPagamentoRemovidos = new List<Entidades.ContaReceberClass>();
                  }
                  _collectionContaReceberClassMeioPagamentoOriginal= (from a in _valueCollectionContaReceberClassMeioPagamento select a.ID).ToList();
                  _valueCollectionContaReceberClassMeioPagamentoChanged = false;
                  _valueCollectionContaReceberClassMeioPagamentoCommitedChanged = false;
               }
               if (_valueCollectionFormaPagamentoClassMeioPagamentoLoaded) 
               {
                  if (_collectionFormaPagamentoClassMeioPagamentoRemovidos != null) 
                  {
                     _collectionFormaPagamentoClassMeioPagamentoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionFormaPagamentoClassMeioPagamentoRemovidos = new List<Entidades.FormaPagamentoClass>();
                  }
                  _collectionFormaPagamentoClassMeioPagamentoOriginal= (from a in _valueCollectionFormaPagamentoClassMeioPagamento select a.ID).ToList();
                  _valueCollectionFormaPagamentoClassMeioPagamentoChanged = false;
                  _valueCollectionFormaPagamentoClassMeioPagamentoCommitedChanged = false;
               }
               if (_valueCollectionPedidoItemClassMeioPagamentoLoaded) 
               {
                  if (_collectionPedidoItemClassMeioPagamentoRemovidos != null) 
                  {
                     _collectionPedidoItemClassMeioPagamentoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPedidoItemClassMeioPagamentoRemovidos = new List<Entidades.PedidoItemClass>();
                  }
                  _collectionPedidoItemClassMeioPagamentoOriginal= (from a in _valueCollectionPedidoItemClassMeioPagamento select a.ID).ToList();
                  _valueCollectionPedidoItemClassMeioPagamentoChanged = false;
                  _valueCollectionPedidoItemClassMeioPagamentoCommitedChanged = false;
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
               Codigo=_codigoOriginal;
               _codigoOriginalCommited=_codigoOriginal;
               Descricao=_descricaoOriginal;
               _descricaoOriginalCommited=_descricaoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               if (_valueCollectionContaPagarClassMeioPagamentoLoaded) 
               {
                  CollectionContaPagarClassMeioPagamento.Clear();
                  foreach(int item in _collectionContaPagarClassMeioPagamentoOriginal)
                  {
                    CollectionContaPagarClassMeioPagamento.Add(Entidades.ContaPagarClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionContaPagarClassMeioPagamentoRemovidos.Clear();
               }
               if (_valueCollectionContaReceberClassMeioPagamentoLoaded) 
               {
                  CollectionContaReceberClassMeioPagamento.Clear();
                  foreach(int item in _collectionContaReceberClassMeioPagamentoOriginal)
                  {
                    CollectionContaReceberClassMeioPagamento.Add(Entidades.ContaReceberClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionContaReceberClassMeioPagamentoRemovidos.Clear();
               }
               if (_valueCollectionFormaPagamentoClassMeioPagamentoLoaded) 
               {
                  CollectionFormaPagamentoClassMeioPagamento.Clear();
                  foreach(int item in _collectionFormaPagamentoClassMeioPagamentoOriginal)
                  {
                    CollectionFormaPagamentoClassMeioPagamento.Add(Entidades.FormaPagamentoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionFormaPagamentoClassMeioPagamentoRemovidos.Clear();
               }
               if (_valueCollectionPedidoItemClassMeioPagamentoLoaded) 
               {
                  CollectionPedidoItemClassMeioPagamento.Clear();
                  foreach(int item in _collectionPedidoItemClassMeioPagamentoOriginal)
                  {
                    CollectionPedidoItemClassMeioPagamento.Add(Entidades.PedidoItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPedidoItemClassMeioPagamentoRemovidos.Clear();
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
               if (_valueCollectionContaPagarClassMeioPagamentoLoaded) 
               {
                  if (_valueCollectionContaPagarClassMeioPagamentoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaReceberClassMeioPagamentoLoaded) 
               {
                  if (_valueCollectionContaReceberClassMeioPagamentoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFormaPagamentoClassMeioPagamentoLoaded) 
               {
                  if (_valueCollectionFormaPagamentoClassMeioPagamentoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemClassMeioPagamentoLoaded) 
               {
                  if (_valueCollectionPedidoItemClassMeioPagamentoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaPagarClassMeioPagamentoLoaded) 
               {
                   tempRet = CollectionContaPagarClassMeioPagamento.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionContaReceberClassMeioPagamentoLoaded) 
               {
                   tempRet = CollectionContaReceberClassMeioPagamento.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionFormaPagamentoClassMeioPagamentoLoaded) 
               {
                   tempRet = CollectionFormaPagamentoClassMeioPagamento.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemClassMeioPagamentoLoaded) 
               {
                   tempRet = CollectionPedidoItemClassMeioPagamento.Any(item => item.IsDirty());
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
       dirty = _codigoOriginal != Codigo;
      if (dirty) return true;
       dirty = _descricaoOriginal != Descricao;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;

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
               if (_valueCollectionContaPagarClassMeioPagamentoLoaded) 
               {
                  if (_valueCollectionContaPagarClassMeioPagamentoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaReceberClassMeioPagamentoLoaded) 
               {
                  if (_valueCollectionContaReceberClassMeioPagamentoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFormaPagamentoClassMeioPagamentoLoaded) 
               {
                  if (_valueCollectionFormaPagamentoClassMeioPagamentoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemClassMeioPagamentoLoaded) 
               {
                  if (_valueCollectionPedidoItemClassMeioPagamentoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaPagarClassMeioPagamentoLoaded) 
               {
                   tempRet = CollectionContaPagarClassMeioPagamento.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionContaReceberClassMeioPagamentoLoaded) 
               {
                   tempRet = CollectionContaReceberClassMeioPagamento.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionFormaPagamentoClassMeioPagamentoLoaded) 
               {
                   tempRet = CollectionFormaPagamentoClassMeioPagamento.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemClassMeioPagamentoLoaded) 
               {
                   tempRet = CollectionPedidoItemClassMeioPagamento.Any(item => item.IsDirtyCommited());
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
       dirty = _codigoOriginalCommited != Codigo;
      if (dirty) return true;
       dirty = _descricaoOriginalCommited != Descricao;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;

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
               if (_valueCollectionContaPagarClassMeioPagamentoLoaded) 
               {
                  foreach(ContaPagarClass item in CollectionContaPagarClassMeioPagamento)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionContaReceberClassMeioPagamentoLoaded) 
               {
                  foreach(ContaReceberClass item in CollectionContaReceberClassMeioPagamento)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionFormaPagamentoClassMeioPagamentoLoaded) 
               {
                  foreach(FormaPagamentoClass item in CollectionFormaPagamentoClassMeioPagamento)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPedidoItemClassMeioPagamentoLoaded) 
               {
                  foreach(PedidoItemClass item in CollectionPedidoItemClassMeioPagamento)
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
             case "Codigo":
                return this.Codigo;
             case "Descricao":
                return this.Descricao;
             case "Version":
                return this.Version;
             case "EntityUid":
                return this.EntityUid;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
               if (_valueCollectionContaPagarClassMeioPagamentoLoaded) 
               {
                  foreach(ContaPagarClass item in CollectionContaPagarClassMeioPagamento)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionContaReceberClassMeioPagamentoLoaded) 
               {
                  foreach(ContaReceberClass item in CollectionContaReceberClassMeioPagamento)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionFormaPagamentoClassMeioPagamentoLoaded) 
               {
                  foreach(FormaPagamentoClass item in CollectionFormaPagamentoClassMeioPagamento)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPedidoItemClassMeioPagamentoLoaded) 
               {
                  foreach(PedidoItemClass item in CollectionPedidoItemClassMeioPagamento)
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
                  command.CommandText += " COUNT(meio_pagamento.id_meio_pagamento) " ;
               }
               else
               {
               command.CommandText += "meio_pagamento.id_meio_pagamento, " ;
               command.CommandText += "meio_pagamento.mep_codigo, " ;
               command.CommandText += "meio_pagamento.mep_descricao, " ;
               command.CommandText += "meio_pagamento.version, " ;
               command.CommandText += "meio_pagamento.entity_uid " ;
               }
               command.CommandText += " FROM  meio_pagamento ";
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
                        orderByClause += " , mep_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(mep_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = meio_pagamento.id_acs_usuario_ultima_revisao ";
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
                     case "id_meio_pagamento":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , meio_pagamento.id_meio_pagamento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(meio_pagamento.id_meio_pagamento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mep_codigo":
                     case "Codigo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , meio_pagamento.mep_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(meio_pagamento.mep_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mep_descricao":
                     case "Descricao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , meio_pagamento.mep_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(meio_pagamento.mep_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , meio_pagamento.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(meio_pagamento.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , meio_pagamento.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(meio_pagamento.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mep_codigo")) 
                        {
                           whereClause += " OR UPPER(meio_pagamento.mep_codigo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(meio_pagamento.mep_codigo) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mep_descricao")) 
                        {
                           whereClause += " OR UPPER(meio_pagamento.mep_descricao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(meio_pagamento.mep_descricao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(meio_pagamento.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(meio_pagamento.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_meio_pagamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  meio_pagamento.id_meio_pagamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  meio_pagamento.id_meio_pagamento = :meio_pagamento_ID_5494 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("meio_pagamento_ID_5494", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Codigo" || parametro.FieldName == "mep_codigo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  meio_pagamento.mep_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  meio_pagamento.mep_codigo LIKE :meio_pagamento_Codigo_6668 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("meio_pagamento_Codigo_6668", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Descricao" || parametro.FieldName == "mep_descricao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  meio_pagamento.mep_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  meio_pagamento.mep_descricao LIKE :meio_pagamento_Descricao_7840 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("meio_pagamento_Descricao_7840", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  meio_pagamento.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  meio_pagamento.version = :meio_pagamento_Version_2081 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("meio_pagamento_Version_2081", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  meio_pagamento.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  meio_pagamento.entity_uid LIKE :meio_pagamento_EntityUid_557 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("meio_pagamento_EntityUid_557", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  meio_pagamento.mep_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  meio_pagamento.mep_codigo LIKE :meio_pagamento_Codigo_5503 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("meio_pagamento_Codigo_5503", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  meio_pagamento.mep_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  meio_pagamento.mep_descricao LIKE :meio_pagamento_Descricao_9847 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("meio_pagamento_Descricao_9847", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  meio_pagamento.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  meio_pagamento.entity_uid LIKE :meio_pagamento_EntityUid_1542 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("meio_pagamento_EntityUid_1542", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  MeioPagamentoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (MeioPagamentoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(MeioPagamentoClass), Convert.ToInt32(read["id_meio_pagamento"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new MeioPagamentoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_meio_pagamento"]);
                     entidade.Codigo = (read["mep_codigo"] != DBNull.Value ? read["mep_codigo"].ToString() : null);
                     entidade.Descricao = (read["mep_descricao"] != DBNull.Value ? read["mep_descricao"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (MeioPagamentoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
