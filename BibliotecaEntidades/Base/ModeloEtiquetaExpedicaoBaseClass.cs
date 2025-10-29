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
     [Table("modelo_etiqueta_expedicao","mee")]
     public class ModeloEtiquetaExpedicaoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do ModeloEtiquetaExpedicaoClass";
protected const string ErroDelete = "Erro ao excluir o ModeloEtiquetaExpedicaoClass  ";
protected const string ErroSave = "Erro ao salvar o ModeloEtiquetaExpedicaoClass.";
protected const string ErroCollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicao = "Erro ao carregar a coleção de OrcamentoConfiguradoClass.";
protected const string ErroCollectionOrderItemEtiquetaClassModeloEtiquetaExpedicao = "Erro ao carregar a coleção de OrderItemEtiquetaClass.";
protected const string ErroCollectionProdutoClassModeloEtiquetaExpedicao = "Erro ao carregar a coleção de ProdutoClass.";
protected const string ErroCodigoConfiguradoObrigatorio = "O campo CodigoConfigurado é obrigatório";
protected const string ErroCodigoConfiguradoComprimento = "O campo CodigoConfigurado deve ter no máximo 255 caracteres";
protected const string ErroDescricaoClienteObrigatorio = "O campo DescricaoCliente é obrigatório";
protected const string ErroDescricaoClienteComprimento = "O campo DescricaoCliente deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do ModeloEtiquetaExpedicaoClass.";
protected const string MensagemUtilizadoCollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicao =  "A entidade ModeloEtiquetaExpedicaoClass está sendo utilizada nos seguintes OrcamentoConfiguradoClass:";
protected const string MensagemUtilizadoCollectionOrderItemEtiquetaClassModeloEtiquetaExpedicao =  "A entidade ModeloEtiquetaExpedicaoClass está sendo utilizada nos seguintes OrderItemEtiquetaClass:";
protected const string MensagemUtilizadoCollectionProdutoClassModeloEtiquetaExpedicao =  "A entidade ModeloEtiquetaExpedicaoClass está sendo utilizada nos seguintes ProdutoClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade ModeloEtiquetaExpedicaoClass está sendo utilizada.";
#endregion
       protected string _codigoConfiguradoOriginal{get;private set;}
       private string _codigoConfiguradoOriginalCommited{get; set;}
        private string _valueCodigoConfigurado;
         [Column("mee_codigo_configurado")]
        public virtual string CodigoConfigurado
         { 
            get { return this._valueCodigoConfigurado; } 
            set 
            { 
                if (this._valueCodigoConfigurado == value)return;
                 this._valueCodigoConfigurado = value; 
            } 
        } 

       protected string _descricaoClienteOriginal{get;private set;}
       private string _descricaoClienteOriginalCommited{get; set;}
        private string _valueDescricaoCliente;
         [Column("mee_descricao_cliente")]
        public virtual string DescricaoCliente
         { 
            get { return this._valueDescricaoCliente; } 
            set 
            { 
                if (this._valueDescricaoCliente == value)return;
                 this._valueDescricaoCliente = value; 
            } 
        } 

       private List<long> _collectionOrcamentoConfiguradoClassModeloEtiquetaExpedicaoOriginal;
       private List<Entidades.OrcamentoConfiguradoClass > _collectionOrcamentoConfiguradoClassModeloEtiquetaExpedicaoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicaoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicaoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicaoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrcamentoConfiguradoClass> _valueCollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicao { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrcamentoConfiguradoClass> CollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicao 
       { 
           get { if(!_valueCollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicaoLoaded && !this.DisableLoadCollection){this.LoadCollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicao();}
return this._valueCollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicao; } 
           set 
           { 
               this._valueCollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicao = value; 
               this._valueCollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicaoLoaded = true; 
           } 
       } 

       private List<long> _collectionOrderItemEtiquetaClassModeloEtiquetaExpedicaoOriginal;
       private List<Entidades.OrderItemEtiquetaClass > _collectionOrderItemEtiquetaClassModeloEtiquetaExpedicaoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrderItemEtiquetaClassModeloEtiquetaExpedicaoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrderItemEtiquetaClassModeloEtiquetaExpedicaoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrderItemEtiquetaClassModeloEtiquetaExpedicaoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrderItemEtiquetaClass> _valueCollectionOrderItemEtiquetaClassModeloEtiquetaExpedicao { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrderItemEtiquetaClass> CollectionOrderItemEtiquetaClassModeloEtiquetaExpedicao 
       { 
           get { if(!_valueCollectionOrderItemEtiquetaClassModeloEtiquetaExpedicaoLoaded && !this.DisableLoadCollection){this.LoadCollectionOrderItemEtiquetaClassModeloEtiquetaExpedicao();}
return this._valueCollectionOrderItemEtiquetaClassModeloEtiquetaExpedicao; } 
           set 
           { 
               this._valueCollectionOrderItemEtiquetaClassModeloEtiquetaExpedicao = value; 
               this._valueCollectionOrderItemEtiquetaClassModeloEtiquetaExpedicaoLoaded = true; 
           } 
       } 

       private List<long> _collectionProdutoClassModeloEtiquetaExpedicaoOriginal;
       private List<Entidades.ProdutoClass > _collectionProdutoClassModeloEtiquetaExpedicaoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoClassModeloEtiquetaExpedicaoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoClassModeloEtiquetaExpedicaoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoClassModeloEtiquetaExpedicaoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoClass> _valueCollectionProdutoClassModeloEtiquetaExpedicao { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoClass> CollectionProdutoClassModeloEtiquetaExpedicao 
       { 
           get { if(!_valueCollectionProdutoClassModeloEtiquetaExpedicaoLoaded && !this.DisableLoadCollection){this.LoadCollectionProdutoClassModeloEtiquetaExpedicao();}
return this._valueCollectionProdutoClassModeloEtiquetaExpedicao; } 
           set 
           { 
               this._valueCollectionProdutoClassModeloEtiquetaExpedicao = value; 
               this._valueCollectionProdutoClassModeloEtiquetaExpedicaoLoaded = true; 
           } 
       } 

        public ModeloEtiquetaExpedicaoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static ModeloEtiquetaExpedicaoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (ModeloEtiquetaExpedicaoClass) GetEntity(typeof(ModeloEtiquetaExpedicaoClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicaoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicaoChanged = true;
                  _valueCollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicaoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicaoChanged = true; 
                  _valueCollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicaoCommitedChanged = true;
                 foreach (Entidades.OrcamentoConfiguradoClass item in e.OldItems) 
                 { 
                     _collectionOrcamentoConfiguradoClassModeloEtiquetaExpedicaoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicaoChanged = true; 
                  _valueCollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicaoCommitedChanged = true;
                 foreach (Entidades.OrcamentoConfiguradoClass item in _valueCollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicao) 
                 { 
                     _collectionOrcamentoConfiguradoClassModeloEtiquetaExpedicaoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicao()
         {
            try
            {
                 ObservableCollection<Entidades.OrcamentoConfiguradoClass> oc;
                _valueCollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicaoChanged = false;
                 _valueCollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicaoCommitedChanged = false;
                _collectionOrcamentoConfiguradoClassModeloEtiquetaExpedicaoRemovidos = new List<Entidades.OrcamentoConfiguradoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrcamentoConfiguradoClass>();
                }
                else{ 
                   Entidades.OrcamentoConfiguradoClass search = new Entidades.OrcamentoConfiguradoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrcamentoConfiguradoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ModeloEtiquetaExpedicao", this)                    }                       ).Cast<Entidades.OrcamentoConfiguradoClass>().ToList());
                 }
                 _valueCollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicao = new BindingList<Entidades.OrcamentoConfiguradoClass>(oc); 
                 _collectionOrcamentoConfiguradoClassModeloEtiquetaExpedicaoOriginal= (from a in _valueCollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicao select a.ID).ToList();
                 _valueCollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicaoLoaded = true;
                 oc.CollectionChanged += CollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicaoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicao+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrderItemEtiquetaClassModeloEtiquetaExpedicaoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrderItemEtiquetaClassModeloEtiquetaExpedicaoChanged = true;
                  _valueCollectionOrderItemEtiquetaClassModeloEtiquetaExpedicaoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrderItemEtiquetaClassModeloEtiquetaExpedicaoChanged = true; 
                  _valueCollectionOrderItemEtiquetaClassModeloEtiquetaExpedicaoCommitedChanged = true;
                 foreach (Entidades.OrderItemEtiquetaClass item in e.OldItems) 
                 { 
                     _collectionOrderItemEtiquetaClassModeloEtiquetaExpedicaoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrderItemEtiquetaClassModeloEtiquetaExpedicaoChanged = true; 
                  _valueCollectionOrderItemEtiquetaClassModeloEtiquetaExpedicaoCommitedChanged = true;
                 foreach (Entidades.OrderItemEtiquetaClass item in _valueCollectionOrderItemEtiquetaClassModeloEtiquetaExpedicao) 
                 { 
                     _collectionOrderItemEtiquetaClassModeloEtiquetaExpedicaoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrderItemEtiquetaClassModeloEtiquetaExpedicao()
         {
            try
            {
                 ObservableCollection<Entidades.OrderItemEtiquetaClass> oc;
                _valueCollectionOrderItemEtiquetaClassModeloEtiquetaExpedicaoChanged = false;
                 _valueCollectionOrderItemEtiquetaClassModeloEtiquetaExpedicaoCommitedChanged = false;
                _collectionOrderItemEtiquetaClassModeloEtiquetaExpedicaoRemovidos = new List<Entidades.OrderItemEtiquetaClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrderItemEtiquetaClass>();
                }
                else{ 
                   Entidades.OrderItemEtiquetaClass search = new Entidades.OrderItemEtiquetaClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrderItemEtiquetaClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ModeloEtiquetaExpedicao", this)                    }                       ).Cast<Entidades.OrderItemEtiquetaClass>().ToList());
                 }
                 _valueCollectionOrderItemEtiquetaClassModeloEtiquetaExpedicao = new BindingList<Entidades.OrderItemEtiquetaClass>(oc); 
                 _collectionOrderItemEtiquetaClassModeloEtiquetaExpedicaoOriginal= (from a in _valueCollectionOrderItemEtiquetaClassModeloEtiquetaExpedicao select a.ID).ToList();
                 _valueCollectionOrderItemEtiquetaClassModeloEtiquetaExpedicaoLoaded = true;
                 oc.CollectionChanged += CollectionOrderItemEtiquetaClassModeloEtiquetaExpedicaoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrderItemEtiquetaClassModeloEtiquetaExpedicao+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoClassModeloEtiquetaExpedicaoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoClassModeloEtiquetaExpedicaoChanged = true;
                  _valueCollectionProdutoClassModeloEtiquetaExpedicaoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoClassModeloEtiquetaExpedicaoChanged = true; 
                  _valueCollectionProdutoClassModeloEtiquetaExpedicaoCommitedChanged = true;
                 foreach (Entidades.ProdutoClass item in e.OldItems) 
                 { 
                     _collectionProdutoClassModeloEtiquetaExpedicaoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoClassModeloEtiquetaExpedicaoChanged = true; 
                  _valueCollectionProdutoClassModeloEtiquetaExpedicaoCommitedChanged = true;
                 foreach (Entidades.ProdutoClass item in _valueCollectionProdutoClassModeloEtiquetaExpedicao) 
                 { 
                     _collectionProdutoClassModeloEtiquetaExpedicaoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoClassModeloEtiquetaExpedicao()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoClass> oc;
                _valueCollectionProdutoClassModeloEtiquetaExpedicaoChanged = false;
                 _valueCollectionProdutoClassModeloEtiquetaExpedicaoCommitedChanged = false;
                _collectionProdutoClassModeloEtiquetaExpedicaoRemovidos = new List<Entidades.ProdutoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoClass>();
                }
                else{ 
                   Entidades.ProdutoClass search = new Entidades.ProdutoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ModeloEtiquetaExpedicao", this)                    }                       ).Cast<Entidades.ProdutoClass>().ToList());
                 }
                 _valueCollectionProdutoClassModeloEtiquetaExpedicao = new BindingList<Entidades.ProdutoClass>(oc); 
                 _collectionProdutoClassModeloEtiquetaExpedicaoOriginal= (from a in _valueCollectionProdutoClassModeloEtiquetaExpedicao select a.ID).ToList();
                 _valueCollectionProdutoClassModeloEtiquetaExpedicaoLoaded = true;
                 oc.CollectionChanged += CollectionProdutoClassModeloEtiquetaExpedicaoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoClassModeloEtiquetaExpedicao+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(CodigoConfigurado))
                {
                    throw new Exception(ErroCodigoConfiguradoObrigatorio);
                }
                if (CodigoConfigurado.Length >255)
                {
                    throw new Exception( ErroCodigoConfiguradoComprimento);
                }
                if (string.IsNullOrEmpty(DescricaoCliente))
                {
                    throw new Exception(ErroDescricaoClienteObrigatorio);
                }
                if (DescricaoCliente.Length >255)
                {
                    throw new Exception( ErroDescricaoClienteComprimento);
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
                    "  public.modelo_etiqueta_expedicao  " +
                    "WHERE " +
                    "  id_modelo_etiqueta_expedicao = :id";
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
                        "  public.modelo_etiqueta_expedicao   " +
                        "SET  " + 
                        "  mee_codigo_configurado = :mee_codigo_configurado, " + 
                        "  mee_descricao_cliente = :mee_descricao_cliente, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_modelo_etiqueta_expedicao = :id " +
                        "RETURNING id_modelo_etiqueta_expedicao;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.modelo_etiqueta_expedicao " +
                        "( " +
                        "  mee_codigo_configurado , " + 
                        "  mee_descricao_cliente , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :mee_codigo_configurado , " + 
                        "  :mee_descricao_cliente , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_modelo_etiqueta_expedicao;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mee_codigo_configurado", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CodigoConfigurado ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mee_descricao_cliente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DescricaoCliente ?? DBNull.Value;
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
 if (CollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicao.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicao+"\r\n";
                foreach (Entidades.OrcamentoConfiguradoClass tmp in CollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicao)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrderItemEtiquetaClassModeloEtiquetaExpedicao.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrderItemEtiquetaClassModeloEtiquetaExpedicao+"\r\n";
                foreach (Entidades.OrderItemEtiquetaClass tmp in CollectionOrderItemEtiquetaClassModeloEtiquetaExpedicao)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoClassModeloEtiquetaExpedicao.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoClassModeloEtiquetaExpedicao+"\r\n";
                foreach (Entidades.ProdutoClass tmp in CollectionProdutoClassModeloEtiquetaExpedicao)
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
        public static ModeloEtiquetaExpedicaoClass CopiarEntidade(ModeloEtiquetaExpedicaoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               ModeloEtiquetaExpedicaoClass toRet = new ModeloEtiquetaExpedicaoClass(usuario,conn);
 toRet.CodigoConfigurado= entidadeCopiar.CodigoConfigurado;
 toRet.DescricaoCliente= entidadeCopiar.DescricaoCliente;

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
       _codigoConfiguradoOriginal = CodigoConfigurado;
       _codigoConfiguradoOriginalCommited = _codigoConfiguradoOriginal;
       _descricaoClienteOriginal = DescricaoCliente;
       _descricaoClienteOriginalCommited = _descricaoClienteOriginal;
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
       _codigoConfiguradoOriginalCommited = CodigoConfigurado;
       _descricaoClienteOriginalCommited = DescricaoCliente;
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
               if (_valueCollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicaoLoaded) 
               {
                  if (_collectionOrcamentoConfiguradoClassModeloEtiquetaExpedicaoRemovidos != null) 
                  {
                     _collectionOrcamentoConfiguradoClassModeloEtiquetaExpedicaoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrcamentoConfiguradoClassModeloEtiquetaExpedicaoRemovidos = new List<Entidades.OrcamentoConfiguradoClass>();
                  }
                  _collectionOrcamentoConfiguradoClassModeloEtiquetaExpedicaoOriginal= (from a in _valueCollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicao select a.ID).ToList();
                  _valueCollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicaoChanged = false;
                  _valueCollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicaoCommitedChanged = false;
               }
               if (_valueCollectionOrderItemEtiquetaClassModeloEtiquetaExpedicaoLoaded) 
               {
                  if (_collectionOrderItemEtiquetaClassModeloEtiquetaExpedicaoRemovidos != null) 
                  {
                     _collectionOrderItemEtiquetaClassModeloEtiquetaExpedicaoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrderItemEtiquetaClassModeloEtiquetaExpedicaoRemovidos = new List<Entidades.OrderItemEtiquetaClass>();
                  }
                  _collectionOrderItemEtiquetaClassModeloEtiquetaExpedicaoOriginal= (from a in _valueCollectionOrderItemEtiquetaClassModeloEtiquetaExpedicao select a.ID).ToList();
                  _valueCollectionOrderItemEtiquetaClassModeloEtiquetaExpedicaoChanged = false;
                  _valueCollectionOrderItemEtiquetaClassModeloEtiquetaExpedicaoCommitedChanged = false;
               }
               if (_valueCollectionProdutoClassModeloEtiquetaExpedicaoLoaded) 
               {
                  if (_collectionProdutoClassModeloEtiquetaExpedicaoRemovidos != null) 
                  {
                     _collectionProdutoClassModeloEtiquetaExpedicaoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoClassModeloEtiquetaExpedicaoRemovidos = new List<Entidades.ProdutoClass>();
                  }
                  _collectionProdutoClassModeloEtiquetaExpedicaoOriginal= (from a in _valueCollectionProdutoClassModeloEtiquetaExpedicao select a.ID).ToList();
                  _valueCollectionProdutoClassModeloEtiquetaExpedicaoChanged = false;
                  _valueCollectionProdutoClassModeloEtiquetaExpedicaoCommitedChanged = false;
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
               CodigoConfigurado=_codigoConfiguradoOriginal;
               _codigoConfiguradoOriginalCommited=_codigoConfiguradoOriginal;
               DescricaoCliente=_descricaoClienteOriginal;
               _descricaoClienteOriginalCommited=_descricaoClienteOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               if (_valueCollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicaoLoaded) 
               {
                  CollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicao.Clear();
                  foreach(int item in _collectionOrcamentoConfiguradoClassModeloEtiquetaExpedicaoOriginal)
                  {
                    CollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicao.Add(Entidades.OrcamentoConfiguradoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrcamentoConfiguradoClassModeloEtiquetaExpedicaoRemovidos.Clear();
               }
               if (_valueCollectionOrderItemEtiquetaClassModeloEtiquetaExpedicaoLoaded) 
               {
                  CollectionOrderItemEtiquetaClassModeloEtiquetaExpedicao.Clear();
                  foreach(int item in _collectionOrderItemEtiquetaClassModeloEtiquetaExpedicaoOriginal)
                  {
                    CollectionOrderItemEtiquetaClassModeloEtiquetaExpedicao.Add(Entidades.OrderItemEtiquetaClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrderItemEtiquetaClassModeloEtiquetaExpedicaoRemovidos.Clear();
               }
               if (_valueCollectionProdutoClassModeloEtiquetaExpedicaoLoaded) 
               {
                  CollectionProdutoClassModeloEtiquetaExpedicao.Clear();
                  foreach(int item in _collectionProdutoClassModeloEtiquetaExpedicaoOriginal)
                  {
                    CollectionProdutoClassModeloEtiquetaExpedicao.Add(Entidades.ProdutoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoClassModeloEtiquetaExpedicaoRemovidos.Clear();
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
               if (_valueCollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicaoLoaded) 
               {
                  if (_valueCollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicaoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrderItemEtiquetaClassModeloEtiquetaExpedicaoLoaded) 
               {
                  if (_valueCollectionOrderItemEtiquetaClassModeloEtiquetaExpedicaoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoClassModeloEtiquetaExpedicaoLoaded) 
               {
                  if (_valueCollectionProdutoClassModeloEtiquetaExpedicaoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicaoLoaded) 
               {
                   tempRet = CollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicao.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrderItemEtiquetaClassModeloEtiquetaExpedicaoLoaded) 
               {
                   tempRet = CollectionOrderItemEtiquetaClassModeloEtiquetaExpedicao.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoClassModeloEtiquetaExpedicaoLoaded) 
               {
                   tempRet = CollectionProdutoClassModeloEtiquetaExpedicao.Any(item => item.IsDirty());
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
       dirty = _codigoConfiguradoOriginal != CodigoConfigurado;
      if (dirty) return true;
       dirty = _descricaoClienteOriginal != DescricaoCliente;
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
               if (_valueCollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicaoLoaded) 
               {
                  if (_valueCollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicaoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrderItemEtiquetaClassModeloEtiquetaExpedicaoLoaded) 
               {
                  if (_valueCollectionOrderItemEtiquetaClassModeloEtiquetaExpedicaoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoClassModeloEtiquetaExpedicaoLoaded) 
               {
                  if (_valueCollectionProdutoClassModeloEtiquetaExpedicaoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicaoLoaded) 
               {
                   tempRet = CollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicao.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrderItemEtiquetaClassModeloEtiquetaExpedicaoLoaded) 
               {
                   tempRet = CollectionOrderItemEtiquetaClassModeloEtiquetaExpedicao.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoClassModeloEtiquetaExpedicaoLoaded) 
               {
                   tempRet = CollectionProdutoClassModeloEtiquetaExpedicao.Any(item => item.IsDirtyCommited());
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
       dirty = _codigoConfiguradoOriginalCommited != CodigoConfigurado;
      if (dirty) return true;
       dirty = _descricaoClienteOriginalCommited != DescricaoCliente;
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
               if (_valueCollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicaoLoaded) 
               {
                  foreach(OrcamentoConfiguradoClass item in CollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicao)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrderItemEtiquetaClassModeloEtiquetaExpedicaoLoaded) 
               {
                  foreach(OrderItemEtiquetaClass item in CollectionOrderItemEtiquetaClassModeloEtiquetaExpedicao)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoClassModeloEtiquetaExpedicaoLoaded) 
               {
                  foreach(ProdutoClass item in CollectionProdutoClassModeloEtiquetaExpedicao)
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
             case "CodigoConfigurado":
                return this.CodigoConfigurado;
             case "DescricaoCliente":
                return this.DescricaoCliente;
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
               if (_valueCollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicaoLoaded) 
               {
                  foreach(OrcamentoConfiguradoClass item in CollectionOrcamentoConfiguradoClassModeloEtiquetaExpedicao)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrderItemEtiquetaClassModeloEtiquetaExpedicaoLoaded) 
               {
                  foreach(OrderItemEtiquetaClass item in CollectionOrderItemEtiquetaClassModeloEtiquetaExpedicao)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoClassModeloEtiquetaExpedicaoLoaded) 
               {
                  foreach(ProdutoClass item in CollectionProdutoClassModeloEtiquetaExpedicao)
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
                  command.CommandText += " COUNT(modelo_etiqueta_expedicao.id_modelo_etiqueta_expedicao) " ;
               }
               else
               {
               command.CommandText += "modelo_etiqueta_expedicao.id_modelo_etiqueta_expedicao, " ;
               command.CommandText += "modelo_etiqueta_expedicao.mee_codigo_configurado, " ;
               command.CommandText += "modelo_etiqueta_expedicao.mee_descricao_cliente, " ;
               command.CommandText += "modelo_etiqueta_expedicao.entity_uid, " ;
               command.CommandText += "modelo_etiqueta_expedicao.version " ;
               }
               command.CommandText += " FROM  modelo_etiqueta_expedicao ";
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
                        orderByClause += " , mee_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(mee_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = modelo_etiqueta_expedicao.id_acs_usuario_ultima_revisao ";
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
                     case "id_modelo_etiqueta_expedicao":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , modelo_etiqueta_expedicao.id_modelo_etiqueta_expedicao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(modelo_etiqueta_expedicao.id_modelo_etiqueta_expedicao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mee_codigo_configurado":
                     case "CodigoConfigurado":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , modelo_etiqueta_expedicao.mee_codigo_configurado " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(modelo_etiqueta_expedicao.mee_codigo_configurado) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mee_descricao_cliente":
                     case "DescricaoCliente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , modelo_etiqueta_expedicao.mee_descricao_cliente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(modelo_etiqueta_expedicao.mee_descricao_cliente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , modelo_etiqueta_expedicao.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(modelo_etiqueta_expedicao.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , modelo_etiqueta_expedicao.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(modelo_etiqueta_expedicao.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mee_codigo_configurado")) 
                        {
                           whereClause += " OR UPPER(modelo_etiqueta_expedicao.mee_codigo_configurado) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(modelo_etiqueta_expedicao.mee_codigo_configurado) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mee_descricao_cliente")) 
                        {
                           whereClause += " OR UPPER(modelo_etiqueta_expedicao.mee_descricao_cliente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(modelo_etiqueta_expedicao.mee_descricao_cliente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(modelo_etiqueta_expedicao.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(modelo_etiqueta_expedicao.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_modelo_etiqueta_expedicao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  modelo_etiqueta_expedicao.id_modelo_etiqueta_expedicao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  modelo_etiqueta_expedicao.id_modelo_etiqueta_expedicao = :modelo_etiqueta_expedicao_ID_3858 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("modelo_etiqueta_expedicao_ID_3858", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoConfigurado" || parametro.FieldName == "mee_codigo_configurado")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  modelo_etiqueta_expedicao.mee_codigo_configurado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  modelo_etiqueta_expedicao.mee_codigo_configurado LIKE :modelo_etiqueta_expedicao_CodigoConfigurado_682 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("modelo_etiqueta_expedicao_CodigoConfigurado_682", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescricaoCliente" || parametro.FieldName == "mee_descricao_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  modelo_etiqueta_expedicao.mee_descricao_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  modelo_etiqueta_expedicao.mee_descricao_cliente LIKE :modelo_etiqueta_expedicao_DescricaoCliente_2689 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("modelo_etiqueta_expedicao_DescricaoCliente_2689", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  modelo_etiqueta_expedicao.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  modelo_etiqueta_expedicao.entity_uid LIKE :modelo_etiqueta_expedicao_EntityUid_4097 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("modelo_etiqueta_expedicao_EntityUid_4097", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  modelo_etiqueta_expedicao.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  modelo_etiqueta_expedicao.version = :modelo_etiqueta_expedicao_Version_8278 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("modelo_etiqueta_expedicao_Version_8278", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoConfiguradoExato" || parametro.FieldName == "CodigoConfiguradoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  modelo_etiqueta_expedicao.mee_codigo_configurado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  modelo_etiqueta_expedicao.mee_codigo_configurado LIKE :modelo_etiqueta_expedicao_CodigoConfigurado_6587 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("modelo_etiqueta_expedicao_CodigoConfigurado_6587", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescricaoClienteExato" || parametro.FieldName == "DescricaoClienteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  modelo_etiqueta_expedicao.mee_descricao_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  modelo_etiqueta_expedicao.mee_descricao_cliente LIKE :modelo_etiqueta_expedicao_DescricaoCliente_7056 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("modelo_etiqueta_expedicao_DescricaoCliente_7056", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  modelo_etiqueta_expedicao.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  modelo_etiqueta_expedicao.entity_uid LIKE :modelo_etiqueta_expedicao_EntityUid_6793 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("modelo_etiqueta_expedicao_EntityUid_6793", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  ModeloEtiquetaExpedicaoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (ModeloEtiquetaExpedicaoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(ModeloEtiquetaExpedicaoClass), Convert.ToInt32(read["id_modelo_etiqueta_expedicao"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new ModeloEtiquetaExpedicaoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_modelo_etiqueta_expedicao"]);
                     entidade.CodigoConfigurado = (read["mee_codigo_configurado"] != DBNull.Value ? read["mee_codigo_configurado"].ToString() : null);
                     entidade.DescricaoCliente = (read["mee_descricao_cliente"] != DBNull.Value ? read["mee_descricao_cliente"].ToString() : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (ModeloEtiquetaExpedicaoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
