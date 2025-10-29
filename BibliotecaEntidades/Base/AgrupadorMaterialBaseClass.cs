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
     [Table("agrupador_material","agm")]
     public class AgrupadorMaterialBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do AgrupadorMaterialClass";
protected const string ErroDelete = "Erro ao excluir o AgrupadorMaterialClass  ";
protected const string ErroSave = "Erro ao salvar o AgrupadorMaterialClass.";
protected const string ErroCollectionFamiliaMaterialClassAgrupadorMaterial = "Erro ao carregar a coleção de FamiliaMaterialClass.";
protected const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
protected const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do AgrupadorMaterialClass.";
protected const string MensagemUtilizadoCollectionFamiliaMaterialClassAgrupadorMaterial =  "A entidade AgrupadorMaterialClass está sendo utilizada nos seguintes FamiliaMaterialClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade AgrupadorMaterialClass está sendo utilizada.";
#endregion
       protected string _identificacaoOriginal{get;private set;}
       private string _identificacaoOriginalCommited{get; set;}
        private string _valueIdentificacao;
         [Column("agm_identificacao")]
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
         [Column("agm_descricao")]
        public virtual string Descricao
         { 
            get { return this._valueDescricao; } 
            set 
            { 
                if (this._valueDescricao == value)return;
                 this._valueDescricao = value; 
            } 
        } 

       protected string _corOriginal{get;private set;}
       private string _corOriginalCommited{get; set;}
        private string _valueCor;
         [Column("agm_cor")]
        public virtual string Cor
         { 
            get { return this._valueCor; } 
            set 
            { 
                if (this._valueCor == value)return;
                 this._valueCor = value; 
            } 
        } 

       protected EASITipoConsumoEstoque _tipoConsumoEstoqueOriginal{get;private set;}
       private EASITipoConsumoEstoque _tipoConsumoEstoqueOriginalCommited{get; set;}
        private EASITipoConsumoEstoque _valueTipoConsumoEstoque;
         [Column("agm_tipo_consumo_estoque")]
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

       private List<long> _collectionFamiliaMaterialClassAgrupadorMaterialOriginal;
       private List<Entidades.FamiliaMaterialClass > _collectionFamiliaMaterialClassAgrupadorMaterialRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFamiliaMaterialClassAgrupadorMaterialLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFamiliaMaterialClassAgrupadorMaterialChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFamiliaMaterialClassAgrupadorMaterialCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.FamiliaMaterialClass> _valueCollectionFamiliaMaterialClassAgrupadorMaterial { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.FamiliaMaterialClass> CollectionFamiliaMaterialClassAgrupadorMaterial 
       { 
           get { if(!_valueCollectionFamiliaMaterialClassAgrupadorMaterialLoaded && !this.DisableLoadCollection){this.LoadCollectionFamiliaMaterialClassAgrupadorMaterial();}
return this._valueCollectionFamiliaMaterialClassAgrupadorMaterial; } 
           set 
           { 
               this._valueCollectionFamiliaMaterialClassAgrupadorMaterial = value; 
               this._valueCollectionFamiliaMaterialClassAgrupadorMaterialLoaded = true; 
           } 
       } 

        public AgrupadorMaterialBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.TipoConsumoEstoque = (EASITipoConsumoEstoque)0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static AgrupadorMaterialClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (AgrupadorMaterialClass) GetEntity(typeof(AgrupadorMaterialClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionFamiliaMaterialClassAgrupadorMaterialChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionFamiliaMaterialClassAgrupadorMaterialChanged = true;
                  _valueCollectionFamiliaMaterialClassAgrupadorMaterialCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionFamiliaMaterialClassAgrupadorMaterialChanged = true; 
                  _valueCollectionFamiliaMaterialClassAgrupadorMaterialCommitedChanged = true;
                 foreach (Entidades.FamiliaMaterialClass item in e.OldItems) 
                 { 
                     _collectionFamiliaMaterialClassAgrupadorMaterialRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionFamiliaMaterialClassAgrupadorMaterialChanged = true; 
                  _valueCollectionFamiliaMaterialClassAgrupadorMaterialCommitedChanged = true;
                 foreach (Entidades.FamiliaMaterialClass item in _valueCollectionFamiliaMaterialClassAgrupadorMaterial) 
                 { 
                     _collectionFamiliaMaterialClassAgrupadorMaterialRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionFamiliaMaterialClassAgrupadorMaterial()
         {
            try
            {
                 ObservableCollection<Entidades.FamiliaMaterialClass> oc;
                _valueCollectionFamiliaMaterialClassAgrupadorMaterialChanged = false;
                 _valueCollectionFamiliaMaterialClassAgrupadorMaterialCommitedChanged = false;
                _collectionFamiliaMaterialClassAgrupadorMaterialRemovidos = new List<Entidades.FamiliaMaterialClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.FamiliaMaterialClass>();
                }
                else{ 
                   Entidades.FamiliaMaterialClass search = new Entidades.FamiliaMaterialClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.FamiliaMaterialClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("AgrupadorMaterial", this),                     }                       ).Cast<Entidades.FamiliaMaterialClass>().ToList());
                 }
                 _valueCollectionFamiliaMaterialClassAgrupadorMaterial = new BindingList<Entidades.FamiliaMaterialClass>(oc); 
                 _collectionFamiliaMaterialClassAgrupadorMaterialOriginal= (from a in _valueCollectionFamiliaMaterialClassAgrupadorMaterial select a.ID).ToList();
                 _valueCollectionFamiliaMaterialClassAgrupadorMaterialLoaded = true;
                 oc.CollectionChanged += CollectionFamiliaMaterialClassAgrupadorMaterialChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionFamiliaMaterialClassAgrupadorMaterial+"\r\n" + e.Message, e);
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
                    "  public.agrupador_material  " +
                    "WHERE " +
                    "  id_agrupador_material = :id";
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
                        "  public.agrupador_material   " +
                        "SET  " + 
                        "  agm_identificacao = :agm_identificacao, " + 
                        "  agm_descricao = :agm_descricao, " + 
                        "  agm_cor = :agm_cor, " + 
                        "  agm_ultima_revisao = :agm_ultima_revisao, " + 
                        "  agm_ultima_revisao_data = :agm_ultima_revisao_data, " + 
                        "  id_acs_usuario_ultima_revisao = :id_acs_usuario_ultima_revisao, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  agm_tipo_consumo_estoque = :agm_tipo_consumo_estoque "+
                        "WHERE  " +
                        "  id_agrupador_material = :id " +
                        "RETURNING id_agrupador_material;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.agrupador_material " +
                        "( " +
                        "  agm_identificacao , " + 
                        "  agm_descricao , " + 
                        "  agm_cor , " + 
                        "  agm_ultima_revisao , " + 
                        "  agm_ultima_revisao_data , " + 
                        "  id_acs_usuario_ultima_revisao , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  agm_tipo_consumo_estoque  "+
                        ")  " +
                        "VALUES ( " +
                        "  :agm_identificacao , " + 
                        "  :agm_descricao , " + 
                        "  :agm_cor , " + 
                        "  :agm_ultima_revisao , " + 
                        "  :agm_ultima_revisao_data , " + 
                        "  :id_acs_usuario_ultima_revisao , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :agm_tipo_consumo_estoque  "+
                        ")RETURNING id_agrupador_material;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agm_identificacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Identificacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agm_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Descricao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agm_cor", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Cor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agm_ultima_revisao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UltimaRevisao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agm_ultima_revisao_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UltimaRevisaoData ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_ultima_revisao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.UltimaRevisaoUsuario==null ? (object) DBNull.Value : this.UltimaRevisaoUsuario.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agm_tipo_consumo_estoque", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.TipoConsumoEstoque);

 
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
 if (CollectionFamiliaMaterialClassAgrupadorMaterial.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionFamiliaMaterialClassAgrupadorMaterial+"\r\n";
                foreach (Entidades.FamiliaMaterialClass tmp in CollectionFamiliaMaterialClassAgrupadorMaterial)
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
        public static AgrupadorMaterialClass CopiarEntidade(AgrupadorMaterialClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               AgrupadorMaterialClass toRet = new AgrupadorMaterialClass(usuario,conn);
 toRet.Identificacao= entidadeCopiar.Identificacao;
 toRet.Descricao= entidadeCopiar.Descricao;
 toRet.Cor= entidadeCopiar.Cor;
 toRet.TipoConsumoEstoque= entidadeCopiar.TipoConsumoEstoque;

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
       _descricaoOriginal = Descricao;
       _descricaoOriginalCommited = _descricaoOriginal;
       _corOriginal = Cor;
       _corOriginalCommited = _corOriginal;
       _ultimaRevisaoOriginal = UltimaRevisao;
       _ultimaRevisaoOriginalCommited = _ultimaRevisaoOriginal ;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _tipoConsumoEstoqueOriginal = TipoConsumoEstoque;
       _tipoConsumoEstoqueOriginalCommited = _tipoConsumoEstoqueOriginal;

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
       _descricaoOriginalCommited = Descricao;
       _corOriginalCommited = Cor;
       _ultimaRevisaoOriginalCommited = UltimaRevisao;
       _versionOriginalCommited = Version;
       _tipoConsumoEstoqueOriginalCommited = TipoConsumoEstoque;

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
               if (_valueCollectionFamiliaMaterialClassAgrupadorMaterialLoaded) 
               {
                  if (_collectionFamiliaMaterialClassAgrupadorMaterialRemovidos != null) 
                  {
                     _collectionFamiliaMaterialClassAgrupadorMaterialRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionFamiliaMaterialClassAgrupadorMaterialRemovidos = new List<Entidades.FamiliaMaterialClass>();
                  }
                  _collectionFamiliaMaterialClassAgrupadorMaterialOriginal= (from a in _valueCollectionFamiliaMaterialClassAgrupadorMaterial select a.ID).ToList();
                  _valueCollectionFamiliaMaterialClassAgrupadorMaterialChanged = false;
                  _valueCollectionFamiliaMaterialClassAgrupadorMaterialCommitedChanged = false;
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
               Descricao=_descricaoOriginal;
               _descricaoOriginalCommited=_descricaoOriginal;
               Cor=_corOriginal;
               _corOriginalCommited=_corOriginal;
               UltimaRevisao=_ultimaRevisaoOriginal;
               _ultimaRevisaoOriginalCommited=_ultimaRevisaoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               TipoConsumoEstoque=_tipoConsumoEstoqueOriginal;
               _tipoConsumoEstoqueOriginalCommited=_tipoConsumoEstoqueOriginal;
               if (_valueCollectionFamiliaMaterialClassAgrupadorMaterialLoaded) 
               {
                  CollectionFamiliaMaterialClassAgrupadorMaterial.Clear();
                  foreach(int item in _collectionFamiliaMaterialClassAgrupadorMaterialOriginal)
                  {
                    CollectionFamiliaMaterialClassAgrupadorMaterial.Add(Entidades.FamiliaMaterialClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionFamiliaMaterialClassAgrupadorMaterialRemovidos.Clear();
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
               if (_valueCollectionFamiliaMaterialClassAgrupadorMaterialLoaded) 
               {
                  if (_valueCollectionFamiliaMaterialClassAgrupadorMaterialChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFamiliaMaterialClassAgrupadorMaterialLoaded) 
               {
                   tempRet = CollectionFamiliaMaterialClassAgrupadorMaterial.Any(item => item.IsDirty());
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
       dirty = _descricaoOriginal != Descricao;
      if (dirty) return true;
       dirty = _corOriginal != Cor;
      if (dirty) return true;
       dirty = _ultimaRevisaoOriginal != UltimaRevisao;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _tipoConsumoEstoqueOriginal != TipoConsumoEstoque;

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
               if (_valueCollectionFamiliaMaterialClassAgrupadorMaterialLoaded) 
               {
                  if (_valueCollectionFamiliaMaterialClassAgrupadorMaterialCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFamiliaMaterialClassAgrupadorMaterialLoaded) 
               {
                   tempRet = CollectionFamiliaMaterialClassAgrupadorMaterial.Any(item => item.IsDirtyCommited());
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
       dirty = _descricaoOriginalCommited != Descricao;
      if (dirty) return true;
       dirty = _corOriginalCommited != Cor;
      if (dirty) return true;
       dirty = _ultimaRevisaoOriginalCommited != UltimaRevisao;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _tipoConsumoEstoqueOriginalCommited != TipoConsumoEstoque;

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
               if (_valueCollectionFamiliaMaterialClassAgrupadorMaterialLoaded) 
               {
                  foreach(FamiliaMaterialClass item in CollectionFamiliaMaterialClassAgrupadorMaterial)
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
             case "Descricao":
                return this.Descricao;
             case "Cor":
                return this.Cor;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "TipoConsumoEstoque":
                return this.TipoConsumoEstoque;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
               if (_valueCollectionFamiliaMaterialClassAgrupadorMaterialLoaded) 
               {
                  foreach(FamiliaMaterialClass item in CollectionFamiliaMaterialClassAgrupadorMaterial)
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
                  command.CommandText += " COUNT(agrupador_material.id_agrupador_material) " ;
               }
               else
               {
               command.CommandText += "agrupador_material.id_agrupador_material, " ;
               command.CommandText += "agrupador_material.agm_identificacao, " ;
               command.CommandText += "agrupador_material.agm_descricao, " ;
               command.CommandText += "agrupador_material.agm_cor, " ;
               command.CommandText += "agrupador_material.agm_ultima_revisao, " ;
               command.CommandText += "agrupador_material.agm_ultima_revisao_data, " ;
               command.CommandText += "agrupador_material.id_acs_usuario_ultima_revisao, " ;
               command.CommandText += "agrupador_material.entity_uid, " ;
               command.CommandText += "agrupador_material.version, " ;
               command.CommandText += "agrupador_material.agm_tipo_consumo_estoque " ;
               }
               command.CommandText += " FROM  agrupador_material ";
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
                        orderByClause += " , agm_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(agm_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = agrupador_material.id_acs_usuario_ultima_revisao ";
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
                     case "id_agrupador_material":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , agrupador_material.id_agrupador_material " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(agrupador_material.id_agrupador_material) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "agm_identificacao":
                     case "Identificacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , agrupador_material.agm_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(agrupador_material.agm_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "agm_descricao":
                     case "Descricao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , agrupador_material.agm_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(agrupador_material.agm_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "agm_cor":
                     case "Cor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , agrupador_material.agm_cor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(agrupador_material.agm_cor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "agm_ultima_revisao":
                     case "UltimaRevisao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , agrupador_material.agm_ultima_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(agrupador_material.agm_ultima_revisao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "agm_ultima_revisao_data":
                     case "UltimaRevisaoData":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , agrupador_material.agm_ultima_revisao_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(agrupador_material.agm_ultima_revisao_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_ultima_revisao":
                     case "UltimaRevisaoUsuario":
                     orderByClause += " , agrupador_material.id_acs_usuario_ultima_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , agrupador_material.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(agrupador_material.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , agrupador_material.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(agrupador_material.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "agm_tipo_consumo_estoque":
                     case "TipoConsumoEstoque":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , agrupador_material.agm_tipo_consumo_estoque " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(agrupador_material.agm_tipo_consumo_estoque) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("agm_identificacao")) 
                        {
                           whereClause += " OR UPPER(agrupador_material.agm_identificacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(agrupador_material.agm_identificacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("agm_descricao")) 
                        {
                           whereClause += " OR UPPER(agrupador_material.agm_descricao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(agrupador_material.agm_descricao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("agm_cor")) 
                        {
                           whereClause += " OR UPPER(agrupador_material.agm_cor) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(agrupador_material.agm_cor) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("agm_ultima_revisao")) 
                        {
                           whereClause += " OR UPPER(agrupador_material.agm_ultima_revisao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(agrupador_material.agm_ultima_revisao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(agrupador_material.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(agrupador_material.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_agrupador_material")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  agrupador_material.id_agrupador_material IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  agrupador_material.id_agrupador_material = :agrupador_material_ID_4109 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agrupador_material_ID_4109", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Identificacao" || parametro.FieldName == "agm_identificacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  agrupador_material.agm_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  agrupador_material.agm_identificacao LIKE :agrupador_material_Identificacao_2107 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agrupador_material_Identificacao_2107", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Descricao" || parametro.FieldName == "agm_descricao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  agrupador_material.agm_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  agrupador_material.agm_descricao LIKE :agrupador_material_Descricao_7538 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agrupador_material_Descricao_7538", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cor" || parametro.FieldName == "agm_cor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  agrupador_material.agm_cor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  agrupador_material.agm_cor LIKE :agrupador_material_Cor_3870 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agrupador_material_Cor_3870", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao" || parametro.FieldName == "agm_ultima_revisao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  agrupador_material.agm_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  agrupador_material.agm_ultima_revisao LIKE :agrupador_material_UltimaRevisao_5010 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agrupador_material_UltimaRevisao_5010", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoData" || parametro.FieldName == "agm_ultima_revisao_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  agrupador_material.agm_ultima_revisao_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  agrupador_material.agm_ultima_revisao_data = :agrupador_material_UltimaRevisaoData_5162 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agrupador_material_UltimaRevisaoData_5162", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
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
                         whereClause += "  agrupador_material.id_acs_usuario_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  agrupador_material.id_acs_usuario_ultima_revisao = :agrupador_material_UltimaRevisaoUsuario_8241 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agrupador_material_UltimaRevisaoUsuario_8241", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  agrupador_material.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  agrupador_material.entity_uid LIKE :agrupador_material_EntityUid_8639 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agrupador_material_EntityUid_8639", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  agrupador_material.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  agrupador_material.version = :agrupador_material_Version_2777 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agrupador_material_Version_2777", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoConsumoEstoque" || parametro.FieldName == "agm_tipo_consumo_estoque")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is EASITipoConsumoEstoque)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo EASITipoConsumoEstoque");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  agrupador_material.agm_tipo_consumo_estoque IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  agrupador_material.agm_tipo_consumo_estoque = :agrupador_material_TipoConsumoEstoque_8612 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agrupador_material_TipoConsumoEstoque_8612", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  agrupador_material.agm_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  agrupador_material.agm_identificacao LIKE :agrupador_material_Identificacao_4309 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agrupador_material_Identificacao_4309", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  agrupador_material.agm_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  agrupador_material.agm_descricao LIKE :agrupador_material_Descricao_6485 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agrupador_material_Descricao_6485", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CorExato" || parametro.FieldName == "CorExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  agrupador_material.agm_cor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  agrupador_material.agm_cor LIKE :agrupador_material_Cor_6621 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agrupador_material_Cor_6621", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  agrupador_material.agm_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  agrupador_material.agm_ultima_revisao LIKE :agrupador_material_UltimaRevisao_1085 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agrupador_material_UltimaRevisao_1085", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  agrupador_material.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  agrupador_material.entity_uid LIKE :agrupador_material_EntityUid_6243 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("agrupador_material_EntityUid_6243", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  AgrupadorMaterialClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (AgrupadorMaterialClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(AgrupadorMaterialClass), Convert.ToInt32(read["id_agrupador_material"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new AgrupadorMaterialClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_agrupador_material"]);
                     entidade.Identificacao = (read["agm_identificacao"] != DBNull.Value ? read["agm_identificacao"].ToString() : null);
                     entidade.Descricao = (read["agm_descricao"] != DBNull.Value ? read["agm_descricao"].ToString() : null);
                     entidade.Cor = (read["agm_cor"] != DBNull.Value ? read["agm_cor"].ToString() : null);
                     entidade.UltimaRevisao = (read["agm_ultima_revisao"] != DBNull.Value ? read["agm_ultima_revisao"].ToString() : null);
                     entidade.UltimaRevisaoData = read["agm_ultima_revisao_data"] as DateTime?;
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
                     entidade.TipoConsumoEstoque = (EASITipoConsumoEstoque) (read["agm_tipo_consumo_estoque"] != DBNull.Value ? Enum.ToObject(typeof(EASITipoConsumoEstoque), read["agm_tipo_consumo_estoque"]) : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (AgrupadorMaterialClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
