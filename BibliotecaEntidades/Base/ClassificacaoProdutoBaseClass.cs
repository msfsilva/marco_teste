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
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades; 
namespace BibliotecaEntidades.Base 
{ 
    [Serializable()]
     [Table("classificacao_produto","clp")]
     public class ClassificacaoProdutoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do ClassificacaoProdutoClass";
protected const string ErroDelete = "Erro ao excluir o ClassificacaoProdutoClass  ";
protected const string ErroSave = "Erro ao salvar o ClassificacaoProdutoClass.";
protected const string ErroCollectionProdutoClassClassificacaoProduto = "Erro ao carregar a coleção de ProdutoClass.";
protected const string ErroCollectionProdutoKClassClassificacaoProduto = "Erro ao carregar a coleção de ProdutoKClass.";
protected const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
protected const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do ClassificacaoProdutoClass.";
protected const string MensagemUtilizadoCollectionProdutoClassClassificacaoProduto =  "A entidade ClassificacaoProdutoClass está sendo utilizada nos seguintes ProdutoClass:";
protected const string MensagemUtilizadoCollectionProdutoKClassClassificacaoProduto =  "A entidade ClassificacaoProdutoClass está sendo utilizada nos seguintes ProdutoKClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade ClassificacaoProdutoClass está sendo utilizada.";
#endregion
       protected string _descricaoOriginal{get;private set;}
       private string _descricaoOriginalCommited{get; set;}
        private string _valueDescricao;
         [Column("clp_descricao")]
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
         [Column("clp_identificacao")]
        public virtual string Identificacao
         { 
            get { return this._valueIdentificacao; } 
            set 
            { 
                if (this._valueIdentificacao == value)return;
                 this._valueIdentificacao = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.CompradorClass _compradorOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.CompradorClass _compradorOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.CompradorClass _valueComprador;
        [Column("id_comprador", "comprador", "id_comprador")]
       public virtual BibliotecaEntidades.Entidades.CompradorClass Comprador
        { 
           get {                 return this._valueComprador; } 
           set 
           { 
                if (this._valueComprador == value)return;
                 this._valueComprador = value; 
           } 
       } 

       protected EASITipoConsumoEstoque _tipoConsumoEstoqueOriginal{get;private set;}
       private EASITipoConsumoEstoque _tipoConsumoEstoqueOriginalCommited{get; set;}
        private EASITipoConsumoEstoque _valueTipoConsumoEstoque;
         [Column("clp_tipo_consumo_estoque")]
        public virtual EASITipoConsumoEstoque TipoConsumoEstoque
         { 
            get { return this._valueTipoConsumoEstoque; } 
            set 
            { 
                if (this._valueTipoConsumoEstoque == value)return;
                 this._valueTipoConsumoEstoque = value; 
            } 
        } 

        public bool TipoConsumoEstoque_MateriaPrima
         { 
            get { return this._valueTipoConsumoEstoque == BibliotecaEntidades.Base.EASITipoConsumoEstoque.MateriaPrima; } 
            set { if (value) this._valueTipoConsumoEstoque = BibliotecaEntidades.Base.EASITipoConsumoEstoque.MateriaPrima; }
         } 

        public bool TipoConsumoEstoque_Consumo
         { 
            get { return this._valueTipoConsumoEstoque == BibliotecaEntidades.Base.EASITipoConsumoEstoque.Consumo; } 
            set { if (value) this._valueTipoConsumoEstoque = BibliotecaEntidades.Base.EASITipoConsumoEstoque.Consumo; }
         } 

        public bool TipoConsumoEstoque_Escolher
         { 
            get { return this._valueTipoConsumoEstoque == BibliotecaEntidades.Base.EASITipoConsumoEstoque.Escolher; } 
            set { if (value) this._valueTipoConsumoEstoque = BibliotecaEntidades.Base.EASITipoConsumoEstoque.Escolher; }
         } 

       protected bool _configuracaoAutomaticaOriginal{get;private set;}
       private bool _configuracaoAutomaticaOriginalCommited{get; set;}
        private bool _valueConfiguracaoAutomatica;
         [Column("clp_configuracao_automatica")]
        public virtual bool ConfiguracaoAutomatica
         { 
            get { return this._valueConfiguracaoAutomatica; } 
            set 
            { 
                if (this._valueConfiguracaoAutomatica == value)return;
                 this._valueConfiguracaoAutomatica = value; 
            } 
        } 

       protected EasiConfiguracaoAutomaticaReferencia? _configuracaoAutomaticaReferenciaOriginal{get;private set;}
       private EasiConfiguracaoAutomaticaReferencia? _configuracaoAutomaticaReferenciaOriginalCommited{get; set;}
        private EasiConfiguracaoAutomaticaReferencia? _valueConfiguracaoAutomaticaReferencia;
         [Column("clp_configuracao_automatica_referencia")]
        public virtual EasiConfiguracaoAutomaticaReferencia? ConfiguracaoAutomaticaReferencia
         { 
            get { return this._valueConfiguracaoAutomaticaReferencia; } 
            set 
            { 
                if (this._valueConfiguracaoAutomaticaReferencia == value)return;
                 this._valueConfiguracaoAutomaticaReferencia = value; 
            } 
        } 

        public bool ConfiguracaoAutomaticaReferencia_DataCadastro
         { 
            get { return this._valueConfiguracaoAutomaticaReferencia.HasValue && this._valueConfiguracaoAutomaticaReferencia.Value == BibliotecaEntidades.Base.EasiConfiguracaoAutomaticaReferencia.DataCadastro; } 
            set { if (value) this._valueConfiguracaoAutomaticaReferencia = BibliotecaEntidades.Base.EasiConfiguracaoAutomaticaReferencia.DataCadastro; }
         } 

        public bool ConfiguracaoAutomaticaReferencia_DataEntrega
         { 
            get { return this._valueConfiguracaoAutomaticaReferencia.HasValue && this._valueConfiguracaoAutomaticaReferencia.Value == BibliotecaEntidades.Base.EasiConfiguracaoAutomaticaReferencia.DataEntrega; } 
            set { if (value) this._valueConfiguracaoAutomaticaReferencia = BibliotecaEntidades.Base.EasiConfiguracaoAutomaticaReferencia.DataEntrega; }
         } 

       protected int? _configuracaoAutomaticaIntervaloOriginal{get;private set;}
       private int? _configuracaoAutomaticaIntervaloOriginalCommited{get; set;}
        private int? _valueConfiguracaoAutomaticaIntervalo;
         [Column("clp_configuracao_automatica_intervalo")]
        public virtual int? ConfiguracaoAutomaticaIntervalo
         { 
            get { return this._valueConfiguracaoAutomaticaIntervalo; } 
            set 
            { 
                if (this._valueConfiguracaoAutomaticaIntervalo == value)return;
                 this._valueConfiguracaoAutomaticaIntervalo = value; 
            } 
        } 

       private List<long> _collectionProdutoClassClassificacaoProdutoOriginal;
       private List<Entidades.ProdutoClass > _collectionProdutoClassClassificacaoProdutoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoClassClassificacaoProdutoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoClassClassificacaoProdutoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoClassClassificacaoProdutoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoClass> _valueCollectionProdutoClassClassificacaoProduto { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoClass> CollectionProdutoClassClassificacaoProduto 
       { 
           get { if(!_valueCollectionProdutoClassClassificacaoProdutoLoaded && !this.DisableLoadCollection){this.LoadCollectionProdutoClassClassificacaoProduto();}
return this._valueCollectionProdutoClassClassificacaoProduto; } 
           set 
           { 
               this._valueCollectionProdutoClassClassificacaoProduto = value; 
               this._valueCollectionProdutoClassClassificacaoProdutoLoaded = true; 
           } 
       } 

       private List<long> _collectionProdutoKClassClassificacaoProdutoOriginal;
       private List<Entidades.ProdutoKClass > _collectionProdutoKClassClassificacaoProdutoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoKClassClassificacaoProdutoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoKClassClassificacaoProdutoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoKClassClassificacaoProdutoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoKClass> _valueCollectionProdutoKClassClassificacaoProduto { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoKClass> CollectionProdutoKClassClassificacaoProduto 
       { 
           get { if(!_valueCollectionProdutoKClassClassificacaoProdutoLoaded && !this.DisableLoadCollection){this.LoadCollectionProdutoKClassClassificacaoProduto();}
return this._valueCollectionProdutoKClassClassificacaoProduto; } 
           set 
           { 
               this._valueCollectionProdutoKClassClassificacaoProduto = value; 
               this._valueCollectionProdutoKClassClassificacaoProdutoLoaded = true; 
           } 
       } 

        public ClassificacaoProdutoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.TipoConsumoEstoque = (EASITipoConsumoEstoque)0;
           this.ConfiguracaoAutomatica = false;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static ClassificacaoProdutoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (ClassificacaoProdutoClass) GetEntity(typeof(ClassificacaoProdutoClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionProdutoClassClassificacaoProdutoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoClassClassificacaoProdutoChanged = true;
                  _valueCollectionProdutoClassClassificacaoProdutoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoClassClassificacaoProdutoChanged = true; 
                  _valueCollectionProdutoClassClassificacaoProdutoCommitedChanged = true;
                 foreach (Entidades.ProdutoClass item in e.OldItems) 
                 { 
                     _collectionProdutoClassClassificacaoProdutoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoClassClassificacaoProdutoChanged = true; 
                  _valueCollectionProdutoClassClassificacaoProdutoCommitedChanged = true;
                 foreach (Entidades.ProdutoClass item in _valueCollectionProdutoClassClassificacaoProduto) 
                 { 
                     _collectionProdutoClassClassificacaoProdutoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoClassClassificacaoProduto()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoClass> oc;
                _valueCollectionProdutoClassClassificacaoProdutoChanged = false;
                 _valueCollectionProdutoClassClassificacaoProdutoCommitedChanged = false;
                _collectionProdutoClassClassificacaoProdutoRemovidos = new List<Entidades.ProdutoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoClass>();
                }
                else{ 
                   Entidades.ProdutoClass search = new Entidades.ProdutoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ClassificacaoProduto", this),                     }                       ).Cast<Entidades.ProdutoClass>().ToList());
                 }
                 _valueCollectionProdutoClassClassificacaoProduto = new BindingList<Entidades.ProdutoClass>(oc); 
                 _collectionProdutoClassClassificacaoProdutoOriginal= (from a in _valueCollectionProdutoClassClassificacaoProduto select a.ID).ToList();
                 _valueCollectionProdutoClassClassificacaoProdutoLoaded = true;
                 oc.CollectionChanged += CollectionProdutoClassClassificacaoProdutoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoClassClassificacaoProduto+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoKClassClassificacaoProdutoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoKClassClassificacaoProdutoChanged = true;
                  _valueCollectionProdutoKClassClassificacaoProdutoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoKClassClassificacaoProdutoChanged = true; 
                  _valueCollectionProdutoKClassClassificacaoProdutoCommitedChanged = true;
                 foreach (Entidades.ProdutoKClass item in e.OldItems) 
                 { 
                     _collectionProdutoKClassClassificacaoProdutoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoKClassClassificacaoProdutoChanged = true; 
                  _valueCollectionProdutoKClassClassificacaoProdutoCommitedChanged = true;
                 foreach (Entidades.ProdutoKClass item in _valueCollectionProdutoKClassClassificacaoProduto) 
                 { 
                     _collectionProdutoKClassClassificacaoProdutoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoKClassClassificacaoProduto()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoKClass> oc;
                _valueCollectionProdutoKClassClassificacaoProdutoChanged = false;
                 _valueCollectionProdutoKClassClassificacaoProdutoCommitedChanged = false;
                _collectionProdutoKClassClassificacaoProdutoRemovidos = new List<Entidades.ProdutoKClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoKClass>();
                }
                else{ 
                   Entidades.ProdutoKClass search = new Entidades.ProdutoKClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoKClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ClassificacaoProduto", this),                     }                       ).Cast<Entidades.ProdutoKClass>().ToList());
                 }
                 _valueCollectionProdutoKClassClassificacaoProduto = new BindingList<Entidades.ProdutoKClass>(oc); 
                 _collectionProdutoKClassClassificacaoProdutoOriginal= (from a in _valueCollectionProdutoKClassClassificacaoProduto select a.ID).ToList();
                 _valueCollectionProdutoKClassClassificacaoProdutoLoaded = true;
                 oc.CollectionChanged += CollectionProdutoKClassClassificacaoProdutoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoKClassClassificacaoProduto+"\r\n" + e.Message, e);
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
                    "  public.classificacao_produto  " +
                    "WHERE " +
                    "  id_classificacao_produto = :id";
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
                        "  public.classificacao_produto   " +
                        "SET  " + 
                        "  clp_descricao = :clp_descricao, " + 
                        "  clp_identificacao = :clp_identificacao, " + 
                        "  clp_ultima_revisao = :clp_ultima_revisao, " + 
                        "  clp_ultima_revisao_data = :clp_ultima_revisao_data, " + 
                        "  id_acs_usuario_ultima_revisao = :id_acs_usuario_ultima_revisao, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  id_comprador = :id_comprador, " + 
                        "  clp_tipo_consumo_estoque = :clp_tipo_consumo_estoque, " + 
                        "  clp_configuracao_automatica = :clp_configuracao_automatica, " + 
                        "  clp_configuracao_automatica_referencia = :clp_configuracao_automatica_referencia, " + 
                        "  clp_configuracao_automatica_intervalo = :clp_configuracao_automatica_intervalo "+
                        "WHERE  " +
                        "  id_classificacao_produto = :id " +
                        "RETURNING id_classificacao_produto;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.classificacao_produto " +
                        "( " +
                        "  clp_descricao , " + 
                        "  clp_identificacao , " + 
                        "  clp_ultima_revisao , " + 
                        "  clp_ultima_revisao_data , " + 
                        "  id_acs_usuario_ultima_revisao , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  id_comprador , " + 
                        "  clp_tipo_consumo_estoque , " + 
                        "  clp_configuracao_automatica , " + 
                        "  clp_configuracao_automatica_referencia , " + 
                        "  clp_configuracao_automatica_intervalo  "+
                        ")  " +
                        "VALUES ( " +
                        "  :clp_descricao , " + 
                        "  :clp_identificacao , " + 
                        "  :clp_ultima_revisao , " + 
                        "  :clp_ultima_revisao_data , " + 
                        "  :id_acs_usuario_ultima_revisao , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :id_comprador , " + 
                        "  :clp_tipo_consumo_estoque , " + 
                        "  :clp_configuracao_automatica , " + 
                        "  :clp_configuracao_automatica_referencia , " + 
                        "  :clp_configuracao_automatica_intervalo  "+
                        ")RETURNING id_classificacao_produto;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("clp_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Descricao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("clp_identificacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Identificacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("clp_ultima_revisao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UltimaRevisao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("clp_ultima_revisao_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UltimaRevisaoData ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_ultima_revisao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.UltimaRevisaoUsuario==null ? (object) DBNull.Value : this.UltimaRevisaoUsuario.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_comprador", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Comprador==null ? (object) DBNull.Value : this.Comprador.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("clp_tipo_consumo_estoque", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.TipoConsumoEstoque);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("clp_configuracao_automatica", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ConfiguracaoAutomatica ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("clp_configuracao_automatica_referencia", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = this.ConfiguracaoAutomaticaReferencia.HasValue ? (object)Convert.ToInt16(this.ConfiguracaoAutomaticaReferencia) : (object)DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("clp_configuracao_automatica_intervalo", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ConfiguracaoAutomaticaIntervalo ?? DBNull.Value;

 
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
 if (CollectionProdutoClassClassificacaoProduto.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoClassClassificacaoProduto+"\r\n";
                foreach (Entidades.ProdutoClass tmp in CollectionProdutoClassClassificacaoProduto)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoKClassClassificacaoProduto.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoKClassClassificacaoProduto+"\r\n";
                foreach (Entidades.ProdutoKClass tmp in CollectionProdutoKClassClassificacaoProduto)
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
        public static ClassificacaoProdutoClass CopiarEntidade(ClassificacaoProdutoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               ClassificacaoProdutoClass toRet = new ClassificacaoProdutoClass(usuario,conn);
 toRet.Descricao= entidadeCopiar.Descricao;
 toRet.Identificacao= entidadeCopiar.Identificacao;
 toRet.Comprador= entidadeCopiar.Comprador;
 toRet.TipoConsumoEstoque= entidadeCopiar.TipoConsumoEstoque;
 toRet.ConfiguracaoAutomatica= entidadeCopiar.ConfiguracaoAutomatica;
 toRet.ConfiguracaoAutomaticaReferencia= entidadeCopiar.ConfiguracaoAutomaticaReferencia;
 toRet.ConfiguracaoAutomaticaIntervalo= entidadeCopiar.ConfiguracaoAutomaticaIntervalo;

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
       _descricaoOriginal = Descricao;
       _descricaoOriginalCommited = _descricaoOriginal;
       _identificacaoOriginal = Identificacao;
       _identificacaoOriginalCommited = _identificacaoOriginal;
       _ultimaRevisaoOriginal = UltimaRevisao;
       _ultimaRevisaoOriginalCommited = _ultimaRevisaoOriginal ;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _compradorOriginal = Comprador;
       _compradorOriginalCommited = _compradorOriginal;
       _tipoConsumoEstoqueOriginal = TipoConsumoEstoque;
       _tipoConsumoEstoqueOriginalCommited = _tipoConsumoEstoqueOriginal;
       _configuracaoAutomaticaOriginal = ConfiguracaoAutomatica;
       _configuracaoAutomaticaOriginalCommited = _configuracaoAutomaticaOriginal;
       _configuracaoAutomaticaReferenciaOriginal = ConfiguracaoAutomaticaReferencia;
       _configuracaoAutomaticaReferenciaOriginalCommited = _configuracaoAutomaticaReferenciaOriginal;
       _configuracaoAutomaticaIntervaloOriginal = ConfiguracaoAutomaticaIntervalo;
       _configuracaoAutomaticaIntervaloOriginalCommited = _configuracaoAutomaticaIntervaloOriginal;

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
       _descricaoOriginalCommited = Descricao;
       _identificacaoOriginalCommited = Identificacao;
       _ultimaRevisaoOriginalCommited = UltimaRevisao;
       _versionOriginalCommited = Version;
       _compradorOriginalCommited = Comprador;
       _tipoConsumoEstoqueOriginalCommited = TipoConsumoEstoque;
       _configuracaoAutomaticaOriginalCommited = ConfiguracaoAutomatica;
       _configuracaoAutomaticaReferenciaOriginalCommited = ConfiguracaoAutomaticaReferencia;
       _configuracaoAutomaticaIntervaloOriginalCommited = ConfiguracaoAutomaticaIntervalo;

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
               if (_valueCollectionProdutoClassClassificacaoProdutoLoaded) 
               {
                  if (_collectionProdutoClassClassificacaoProdutoRemovidos != null) 
                  {
                     _collectionProdutoClassClassificacaoProdutoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoClassClassificacaoProdutoRemovidos = new List<Entidades.ProdutoClass>();
                  }
                  _collectionProdutoClassClassificacaoProdutoOriginal= (from a in _valueCollectionProdutoClassClassificacaoProduto select a.ID).ToList();
                  _valueCollectionProdutoClassClassificacaoProdutoChanged = false;
                  _valueCollectionProdutoClassClassificacaoProdutoCommitedChanged = false;
               }
               if (_valueCollectionProdutoKClassClassificacaoProdutoLoaded) 
               {
                  if (_collectionProdutoKClassClassificacaoProdutoRemovidos != null) 
                  {
                     _collectionProdutoKClassClassificacaoProdutoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoKClassClassificacaoProdutoRemovidos = new List<Entidades.ProdutoKClass>();
                  }
                  _collectionProdutoKClassClassificacaoProdutoOriginal= (from a in _valueCollectionProdutoKClassClassificacaoProduto select a.ID).ToList();
                  _valueCollectionProdutoKClassClassificacaoProdutoChanged = false;
                  _valueCollectionProdutoKClassClassificacaoProdutoCommitedChanged = false;
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
               Descricao=_descricaoOriginal;
               _descricaoOriginalCommited=_descricaoOriginal;
               Identificacao=_identificacaoOriginal;
               _identificacaoOriginalCommited=_identificacaoOriginal;
               UltimaRevisao=_ultimaRevisaoOriginal;
               _ultimaRevisaoOriginalCommited=_ultimaRevisaoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               Comprador=_compradorOriginal;
               _compradorOriginalCommited=_compradorOriginal;
               TipoConsumoEstoque=_tipoConsumoEstoqueOriginal;
               _tipoConsumoEstoqueOriginalCommited=_tipoConsumoEstoqueOriginal;
               ConfiguracaoAutomatica=_configuracaoAutomaticaOriginal;
               _configuracaoAutomaticaOriginalCommited=_configuracaoAutomaticaOriginal;
               ConfiguracaoAutomaticaReferencia=_configuracaoAutomaticaReferenciaOriginal;
               _configuracaoAutomaticaReferenciaOriginalCommited=_configuracaoAutomaticaReferenciaOriginal;
               ConfiguracaoAutomaticaIntervalo=_configuracaoAutomaticaIntervaloOriginal;
               _configuracaoAutomaticaIntervaloOriginalCommited=_configuracaoAutomaticaIntervaloOriginal;
               if (_valueCollectionProdutoClassClassificacaoProdutoLoaded) 
               {
                  CollectionProdutoClassClassificacaoProduto.Clear();
                  foreach(int item in _collectionProdutoClassClassificacaoProdutoOriginal)
                  {
                    CollectionProdutoClassClassificacaoProduto.Add(Entidades.ProdutoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoClassClassificacaoProdutoRemovidos.Clear();
               }
               if (_valueCollectionProdutoKClassClassificacaoProdutoLoaded) 
               {
                  CollectionProdutoKClassClassificacaoProduto.Clear();
                  foreach(int item in _collectionProdutoKClassClassificacaoProdutoOriginal)
                  {
                    CollectionProdutoKClassClassificacaoProduto.Add(Entidades.ProdutoKClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoKClassClassificacaoProdutoRemovidos.Clear();
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
               if (_valueCollectionProdutoClassClassificacaoProdutoLoaded) 
               {
                  if (_valueCollectionProdutoClassClassificacaoProdutoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoKClassClassificacaoProdutoLoaded) 
               {
                  if (_valueCollectionProdutoKClassClassificacaoProdutoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoClassClassificacaoProdutoLoaded) 
               {
                   tempRet = CollectionProdutoClassClassificacaoProduto.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoKClassClassificacaoProdutoLoaded) 
               {
                   tempRet = CollectionProdutoKClassClassificacaoProduto.Any(item => item.IsDirty());
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
       dirty = _descricaoOriginal != Descricao;
      if (dirty) return true;
       dirty = _identificacaoOriginal != Identificacao;
      if (dirty) return true;
       dirty = _ultimaRevisaoOriginal != UltimaRevisao;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       if (_compradorOriginal!=null)
       {
          dirty = !_compradorOriginal.Equals(Comprador);
       }
       else
       {
            dirty = Comprador != null;
       }
      if (dirty) return true;
       dirty = _tipoConsumoEstoqueOriginal != TipoConsumoEstoque;
      if (dirty) return true;
       dirty = _configuracaoAutomaticaOriginal != ConfiguracaoAutomatica;
      if (dirty) return true;
       dirty = _configuracaoAutomaticaReferenciaOriginal != ConfiguracaoAutomaticaReferencia;
      if (dirty) return true;
       dirty = _configuracaoAutomaticaIntervaloOriginal != ConfiguracaoAutomaticaIntervalo;

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
               if (_valueCollectionProdutoClassClassificacaoProdutoLoaded) 
               {
                  if (_valueCollectionProdutoClassClassificacaoProdutoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoKClassClassificacaoProdutoLoaded) 
               {
                  if (_valueCollectionProdutoKClassClassificacaoProdutoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoClassClassificacaoProdutoLoaded) 
               {
                   tempRet = CollectionProdutoClassClassificacaoProduto.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoKClassClassificacaoProdutoLoaded) 
               {
                   tempRet = CollectionProdutoKClassClassificacaoProduto.Any(item => item.IsDirtyCommited());
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
       dirty = _descricaoOriginalCommited != Descricao;
      if (dirty) return true;
       dirty = _identificacaoOriginalCommited != Identificacao;
      if (dirty) return true;
       dirty = _ultimaRevisaoOriginalCommited != UltimaRevisao;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       if (_compradorOriginalCommited!=null)
       {
          dirty = !_compradorOriginalCommited.Equals(Comprador);
       }
       else
       {
            dirty = Comprador != null;
       }
      if (dirty) return true;
       dirty = _tipoConsumoEstoqueOriginalCommited != TipoConsumoEstoque;
      if (dirty) return true;
       dirty = _configuracaoAutomaticaOriginalCommited != ConfiguracaoAutomatica;
      if (dirty) return true;
       dirty = _configuracaoAutomaticaReferenciaOriginalCommited != ConfiguracaoAutomaticaReferencia;
      if (dirty) return true;
       dirty = _configuracaoAutomaticaIntervaloOriginalCommited != ConfiguracaoAutomaticaIntervalo;

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
               if (_valueCollectionProdutoClassClassificacaoProdutoLoaded) 
               {
                  foreach(ProdutoClass item in CollectionProdutoClassClassificacaoProduto)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoKClassClassificacaoProdutoLoaded) 
               {
                  foreach(ProdutoKClass item in CollectionProdutoKClassClassificacaoProduto)
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
             case "Descricao":
                return this.Descricao;
             case "Identificacao":
                return this.Identificacao;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "Comprador":
                return this.Comprador;
             case "TipoConsumoEstoque":
                return this.TipoConsumoEstoque;
             case "ConfiguracaoAutomatica":
                return this.ConfiguracaoAutomatica;
             case "ConfiguracaoAutomaticaReferencia":
                return this.ConfiguracaoAutomaticaReferencia;
             case "ConfiguracaoAutomaticaIntervalo":
                return this.ConfiguracaoAutomaticaIntervalo;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (Comprador!=null)
                Comprador.ChangeSingleConnection(newConnection);
               if (_valueCollectionProdutoClassClassificacaoProdutoLoaded) 
               {
                  foreach(ProdutoClass item in CollectionProdutoClassClassificacaoProduto)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoKClassClassificacaoProdutoLoaded) 
               {
                  foreach(ProdutoKClass item in CollectionProdutoKClassClassificacaoProduto)
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
                  command.CommandText += " COUNT(classificacao_produto.id_classificacao_produto) " ;
               }
               else
               {
               command.CommandText += "classificacao_produto.id_classificacao_produto, " ;
               command.CommandText += "classificacao_produto.clp_descricao, " ;
               command.CommandText += "classificacao_produto.clp_identificacao, " ;
               command.CommandText += "classificacao_produto.clp_ultima_revisao, " ;
               command.CommandText += "classificacao_produto.clp_ultima_revisao_data, " ;
               command.CommandText += "classificacao_produto.id_acs_usuario_ultima_revisao, " ;
               command.CommandText += "classificacao_produto.entity_uid, " ;
               command.CommandText += "classificacao_produto.version, " ;
               command.CommandText += "classificacao_produto.id_comprador, " ;
               command.CommandText += "classificacao_produto.clp_tipo_consumo_estoque, " ;
               command.CommandText += "classificacao_produto.clp_configuracao_automatica, " ;
               command.CommandText += "classificacao_produto.clp_configuracao_automatica_referencia, " ;
               command.CommandText += "classificacao_produto.clp_configuracao_automatica_intervalo " ;
               }
               command.CommandText += " FROM  classificacao_produto ";
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
                        orderByClause += " , clp_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(clp_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = classificacao_produto.id_acs_usuario_ultima_revisao ";
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
                     case "id_classificacao_produto":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , classificacao_produto.id_classificacao_produto " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(classificacao_produto.id_classificacao_produto) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "clp_descricao":
                     case "Descricao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , classificacao_produto.clp_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(classificacao_produto.clp_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "clp_identificacao":
                     case "Identificacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , classificacao_produto.clp_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(classificacao_produto.clp_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "clp_ultima_revisao":
                     case "UltimaRevisao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , classificacao_produto.clp_ultima_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(classificacao_produto.clp_ultima_revisao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "clp_ultima_revisao_data":
                     case "UltimaRevisaoData":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , classificacao_produto.clp_ultima_revisao_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(classificacao_produto.clp_ultima_revisao_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_ultima_revisao":
                     case "UltimaRevisaoUsuario":
                     orderByClause += " , classificacao_produto.id_acs_usuario_ultima_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , classificacao_produto.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(classificacao_produto.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , classificacao_produto.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(classificacao_produto.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_comprador":
                     case "Comprador":
                     command.CommandText += " LEFT JOIN comprador as comprador_Comprador ON comprador_Comprador.id_comprador = classificacao_produto.id_comprador ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , comprador_Comprador.com_apelido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(comprador_Comprador.com_apelido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "clp_tipo_consumo_estoque":
                     case "TipoConsumoEstoque":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , classificacao_produto.clp_tipo_consumo_estoque " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(classificacao_produto.clp_tipo_consumo_estoque) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "clp_configuracao_automatica":
                     case "ConfiguracaoAutomatica":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , classificacao_produto.clp_configuracao_automatica " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(classificacao_produto.clp_configuracao_automatica) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "clp_configuracao_automatica_referencia":
                     case "ConfiguracaoAutomaticaReferencia":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , classificacao_produto.clp_configuracao_automatica_referencia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(classificacao_produto.clp_configuracao_automatica_referencia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "clp_configuracao_automatica_intervalo":
                     case "ConfiguracaoAutomaticaIntervalo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , classificacao_produto.clp_configuracao_automatica_intervalo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(classificacao_produto.clp_configuracao_automatica_intervalo) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("clp_descricao")) 
                        {
                           whereClause += " OR UPPER(classificacao_produto.clp_descricao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(classificacao_produto.clp_descricao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("clp_identificacao")) 
                        {
                           whereClause += " OR UPPER(classificacao_produto.clp_identificacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(classificacao_produto.clp_identificacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("clp_ultima_revisao")) 
                        {
                           whereClause += " OR UPPER(classificacao_produto.clp_ultima_revisao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(classificacao_produto.clp_ultima_revisao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(classificacao_produto.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(classificacao_produto.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_classificacao_produto")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  classificacao_produto.id_classificacao_produto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  classificacao_produto.id_classificacao_produto = :classificacao_produto_ID_4633 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("classificacao_produto_ID_4633", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Descricao" || parametro.FieldName == "clp_descricao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  classificacao_produto.clp_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  classificacao_produto.clp_descricao LIKE :classificacao_produto_Descricao_7745 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("classificacao_produto_Descricao_7745", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Identificacao" || parametro.FieldName == "clp_identificacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  classificacao_produto.clp_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  classificacao_produto.clp_identificacao LIKE :classificacao_produto_Identificacao_6484 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("classificacao_produto_Identificacao_6484", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao" || parametro.FieldName == "clp_ultima_revisao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  classificacao_produto.clp_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  classificacao_produto.clp_ultima_revisao LIKE :classificacao_produto_UltimaRevisao_7159 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("classificacao_produto_UltimaRevisao_7159", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoData" || parametro.FieldName == "clp_ultima_revisao_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  classificacao_produto.clp_ultima_revisao_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  classificacao_produto.clp_ultima_revisao_data = :classificacao_produto_UltimaRevisaoData_1527 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("classificacao_produto_UltimaRevisaoData_1527", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario" || parametro.FieldName == "id_acs_usuario_ultima_revisao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  classificacao_produto.id_acs_usuario_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  classificacao_produto.id_acs_usuario_ultima_revisao = :classificacao_produto_UltimaRevisaoUsuario_9174 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("classificacao_produto_UltimaRevisaoUsuario_9174", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  classificacao_produto.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  classificacao_produto.entity_uid LIKE :classificacao_produto_EntityUid_7796 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("classificacao_produto_EntityUid_7796", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  classificacao_produto.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  classificacao_produto.version = :classificacao_produto_Version_7059 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("classificacao_produto_Version_7059", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Comprador" || parametro.FieldName == "id_comprador")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.CompradorClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.CompradorClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  classificacao_produto.id_comprador IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  classificacao_produto.id_comprador = :classificacao_produto_Comprador_3921 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("classificacao_produto_Comprador_3921", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoConsumoEstoque" || parametro.FieldName == "clp_tipo_consumo_estoque")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is EASITipoConsumoEstoque)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo EASITipoConsumoEstoque");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  classificacao_produto.clp_tipo_consumo_estoque IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  classificacao_produto.clp_tipo_consumo_estoque = :classificacao_produto_TipoConsumoEstoque_7177 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("classificacao_produto_TipoConsumoEstoque_7177", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ConfiguracaoAutomatica" || parametro.FieldName == "clp_configuracao_automatica")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  classificacao_produto.clp_configuracao_automatica IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  classificacao_produto.clp_configuracao_automatica = :classificacao_produto_ConfiguracaoAutomatica_9871 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("classificacao_produto_ConfiguracaoAutomatica_9871", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ConfiguracaoAutomaticaReferencia" || parametro.FieldName == "clp_configuracao_automatica_referencia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is EasiConfiguracaoAutomaticaReferencia?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo EasiConfiguracaoAutomaticaReferencia?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  classificacao_produto.clp_configuracao_automatica_referencia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  classificacao_produto.clp_configuracao_automatica_referencia = :classificacao_produto_ConfiguracaoAutomaticaReferencia_1336 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("classificacao_produto_ConfiguracaoAutomaticaReferencia_1336", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ConfiguracaoAutomaticaIntervalo" || parametro.FieldName == "clp_configuracao_automatica_intervalo")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  classificacao_produto.clp_configuracao_automatica_intervalo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  classificacao_produto.clp_configuracao_automatica_intervalo = :classificacao_produto_ConfiguracaoAutomaticaIntervalo_2147 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("classificacao_produto_ConfiguracaoAutomaticaIntervalo_2147", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  classificacao_produto.clp_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  classificacao_produto.clp_descricao LIKE :classificacao_produto_Descricao_7202 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("classificacao_produto_Descricao_7202", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  classificacao_produto.clp_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  classificacao_produto.clp_identificacao LIKE :classificacao_produto_Identificacao_7185 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("classificacao_produto_Identificacao_7185", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoExato" || parametro.FieldName == "UltimaRevisaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  classificacao_produto.clp_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  classificacao_produto.clp_ultima_revisao LIKE :classificacao_produto_UltimaRevisao_9915 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("classificacao_produto_UltimaRevisao_9915", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  classificacao_produto.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  classificacao_produto.entity_uid LIKE :classificacao_produto_EntityUid_3468 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("classificacao_produto_EntityUid_3468", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  ClassificacaoProdutoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (ClassificacaoProdutoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(ClassificacaoProdutoClass), Convert.ToInt32(read["id_classificacao_produto"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new ClassificacaoProdutoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_classificacao_produto"]);
                     entidade.Descricao = (read["clp_descricao"] != DBNull.Value ? read["clp_descricao"].ToString() : null);
                     entidade.Identificacao = (read["clp_identificacao"] != DBNull.Value ? read["clp_identificacao"].ToString() : null);
                     entidade.UltimaRevisao = (read["clp_ultima_revisao"] != DBNull.Value ? read["clp_ultima_revisao"].ToString() : null);
                     entidade.UltimaRevisaoData = read["clp_ultima_revisao_data"] as DateTime?;
                     if (read["id_acs_usuario_ultima_revisao"] != DBNull.Value)
                     {
                        entidade.UltimaRevisaoUsuario = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_ultima_revisao"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.UltimaRevisaoUsuario = null ;
                     }
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     if (read["id_comprador"] != DBNull.Value)
                     {
                        entidade.Comprador = (BibliotecaEntidades.Entidades.CompradorClass)BibliotecaEntidades.Entidades.CompradorClass.GetEntidade(Convert.ToInt32(read["id_comprador"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Comprador = null ;
                     }
                     entidade.TipoConsumoEstoque = (EASITipoConsumoEstoque) (read["clp_tipo_consumo_estoque"] != DBNull.Value ? Enum.ToObject(typeof(EASITipoConsumoEstoque), read["clp_tipo_consumo_estoque"]) : null);
                     entidade.ConfiguracaoAutomatica = Convert.ToBoolean(Convert.ToInt16(read["clp_configuracao_automatica"]));
                     entidade.ConfiguracaoAutomaticaReferencia = (EasiConfiguracaoAutomaticaReferencia?) (read["clp_configuracao_automatica_referencia"] != DBNull.Value ? Enum.ToObject(Nullable.GetUnderlyingType(typeof(EasiConfiguracaoAutomaticaReferencia?)), read["clp_configuracao_automatica_referencia"]) : null);
                     entidade.ConfiguracaoAutomaticaIntervalo = read["clp_configuracao_automatica_intervalo"] as int?;
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (ClassificacaoProdutoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
