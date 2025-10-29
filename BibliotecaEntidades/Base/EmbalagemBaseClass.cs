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
     [Table("embalagem","emb")]
     public class EmbalagemBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do EmbalagemClass";
protected const string ErroDelete = "Erro ao excluir o EmbalagemClass  ";
protected const string ErroSave = "Erro ao salvar o EmbalagemClass.";
protected const string ErroCollectionProdutoClassEmbalagem = "Erro ao carregar a coleção de ProdutoClass.";
protected const string ErroCodigoObrigatorio = "O campo Codigo é obrigatório";
protected const string ErroCodigoComprimento = "O campo Codigo deve ter no máximo 255 caracteres";
protected const string ErroDescricaoObrigatorio = "O campo Descricao é obrigatório";
protected const string ErroDescricaoComprimento = "O campo Descricao deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do EmbalagemClass.";
protected const string MensagemUtilizadoCollectionProdutoClassEmbalagem =  "A entidade EmbalagemClass está sendo utilizada nos seguintes ProdutoClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade EmbalagemClass está sendo utilizada.";
#endregion
       protected string _codigoOriginal{get;private set;}
       private string _codigoOriginalCommited{get; set;}
        private string _valueCodigo;
         [Column("emb_codigo")]
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
         [Column("emb_descricao")]
        public virtual string Descricao
         { 
            get { return this._valueDescricao; } 
            set 
            { 
                if (this._valueDescricao == value)return;
                 this._valueDescricao = value; 
            } 
        } 

       protected double _larguraOriginal{get;private set;}
       private double _larguraOriginalCommited{get; set;}
        private double _valueLargura;
         [Column("emb_largura")]
        public virtual double Largura
         { 
            get { return this._valueLargura; } 
            set 
            { 
                if (this._valueLargura == value)return;
                 this._valueLargura = value; 
            } 
        } 

       protected double _alturaOriginal{get;private set;}
       private double _alturaOriginalCommited{get; set;}
        private double _valueAltura;
         [Column("emb_altura")]
        public virtual double Altura
         { 
            get { return this._valueAltura; } 
            set 
            { 
                if (this._valueAltura == value)return;
                 this._valueAltura = value; 
            } 
        } 

       protected double _comprimentoOriginal{get;private set;}
       private double _comprimentoOriginalCommited{get; set;}
        private double _valueComprimento;
         [Column("emb_comprimento")]
        public virtual double Comprimento
         { 
            get { return this._valueComprimento; } 
            set 
            { 
                if (this._valueComprimento == value)return;
                 this._valueComprimento = value; 
            } 
        } 

       protected DimensaoVariavelEmbalagem _dimensaoVariavelOriginal{get;private set;}
       private DimensaoVariavelEmbalagem _dimensaoVariavelOriginalCommited{get; set;}
        private DimensaoVariavelEmbalagem _valueDimensaoVariavel;
         [Column("emb_dimensao_variavel")]
        public virtual DimensaoVariavelEmbalagem DimensaoVariavel
         { 
            get { return this._valueDimensaoVariavel; } 
            set 
            { 
                if (this._valueDimensaoVariavel == value)return;
                 this._valueDimensaoVariavel = value; 
            } 
        } 

        public bool DimensaoVariavel_Nenhuma
         { 
            get { return this._valueDimensaoVariavel == BibliotecaEntidades.Base.DimensaoVariavelEmbalagem.Nenhuma; } 
            set { if (value) this._valueDimensaoVariavel = BibliotecaEntidades.Base.DimensaoVariavelEmbalagem.Nenhuma; }
         } 

        public bool DimensaoVariavel_Largura
         { 
            get { return this._valueDimensaoVariavel == BibliotecaEntidades.Base.DimensaoVariavelEmbalagem.Largura; } 
            set { if (value) this._valueDimensaoVariavel = BibliotecaEntidades.Base.DimensaoVariavelEmbalagem.Largura; }
         } 

        public bool DimensaoVariavel_Altura
         { 
            get { return this._valueDimensaoVariavel == BibliotecaEntidades.Base.DimensaoVariavelEmbalagem.Altura; } 
            set { if (value) this._valueDimensaoVariavel = BibliotecaEntidades.Base.DimensaoVariavelEmbalagem.Altura; }
         } 

        public bool DimensaoVariavel_Comprimento
         { 
            get { return this._valueDimensaoVariavel == BibliotecaEntidades.Base.DimensaoVariavelEmbalagem.Comprimento; } 
            set { if (value) this._valueDimensaoVariavel = BibliotecaEntidades.Base.DimensaoVariavelEmbalagem.Comprimento; }
         } 

       private List<long> _collectionProdutoClassEmbalagemOriginal;
       private List<Entidades.ProdutoClass > _collectionProdutoClassEmbalagemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoClassEmbalagemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoClassEmbalagemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoClassEmbalagemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoClass> _valueCollectionProdutoClassEmbalagem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoClass> CollectionProdutoClassEmbalagem 
       { 
           get { if(!_valueCollectionProdutoClassEmbalagemLoaded && !this.DisableLoadCollection){this.LoadCollectionProdutoClassEmbalagem();}
return this._valueCollectionProdutoClassEmbalagem; } 
           set 
           { 
               this._valueCollectionProdutoClassEmbalagem = value; 
               this._valueCollectionProdutoClassEmbalagemLoaded = true; 
           } 
       } 

        public EmbalagemBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.DimensaoVariavel = (DimensaoVariavelEmbalagem)0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static EmbalagemClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (EmbalagemClass) GetEntity(typeof(EmbalagemClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionProdutoClassEmbalagemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoClassEmbalagemChanged = true;
                  _valueCollectionProdutoClassEmbalagemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoClassEmbalagemChanged = true; 
                  _valueCollectionProdutoClassEmbalagemCommitedChanged = true;
                 foreach (Entidades.ProdutoClass item in e.OldItems) 
                 { 
                     _collectionProdutoClassEmbalagemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoClassEmbalagemChanged = true; 
                  _valueCollectionProdutoClassEmbalagemCommitedChanged = true;
                 foreach (Entidades.ProdutoClass item in _valueCollectionProdutoClassEmbalagem) 
                 { 
                     _collectionProdutoClassEmbalagemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoClassEmbalagem()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoClass> oc;
                _valueCollectionProdutoClassEmbalagemChanged = false;
                 _valueCollectionProdutoClassEmbalagemCommitedChanged = false;
                _collectionProdutoClassEmbalagemRemovidos = new List<Entidades.ProdutoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoClass>();
                }
                else{ 
                   Entidades.ProdutoClass search = new Entidades.ProdutoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Embalagem", this),                     }                       ).Cast<Entidades.ProdutoClass>().ToList());
                 }
                 _valueCollectionProdutoClassEmbalagem = new BindingList<Entidades.ProdutoClass>(oc); 
                 _collectionProdutoClassEmbalagemOriginal= (from a in _valueCollectionProdutoClassEmbalagem select a.ID).ToList();
                 _valueCollectionProdutoClassEmbalagemLoaded = true;
                 oc.CollectionChanged += CollectionProdutoClassEmbalagemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoClassEmbalagem+"\r\n" + e.Message, e);
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
                if (Codigo.Length >255)
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
                    "  public.embalagem  " +
                    "WHERE " +
                    "  id_embalagem = :id";
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
                        "  public.embalagem   " +
                        "SET  " + 
                        "  emb_codigo = :emb_codigo, " + 
                        "  emb_descricao = :emb_descricao, " + 
                        "  emb_largura = :emb_largura, " + 
                        "  emb_altura = :emb_altura, " + 
                        "  emb_comprimento = :emb_comprimento, " + 
                        "  emb_dimensao_variavel = :emb_dimensao_variavel, " + 
                        "  emb_ultima_revisao = :emb_ultima_revisao, " + 
                        "  emb_ultima_revisao_data = :emb_ultima_revisao_data, " + 
                        "  id_acs_usuario_ultima_revisao = :id_acs_usuario_ultima_revisao, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_embalagem = :id " +
                        "RETURNING id_embalagem;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.embalagem " +
                        "( " +
                        "  emb_codigo , " + 
                        "  emb_descricao , " + 
                        "  emb_largura , " + 
                        "  emb_altura , " + 
                        "  emb_comprimento , " + 
                        "  emb_dimensao_variavel , " + 
                        "  emb_ultima_revisao , " + 
                        "  emb_ultima_revisao_data , " + 
                        "  id_acs_usuario_ultima_revisao , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :emb_codigo , " + 
                        "  :emb_descricao , " + 
                        "  :emb_largura , " + 
                        "  :emb_altura , " + 
                        "  :emb_comprimento , " + 
                        "  :emb_dimensao_variavel , " + 
                        "  :emb_ultima_revisao , " + 
                        "  :emb_ultima_revisao_data , " + 
                        "  :id_acs_usuario_ultima_revisao , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_embalagem;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("emb_codigo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Codigo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("emb_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Descricao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("emb_largura", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Largura ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("emb_altura", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Altura ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("emb_comprimento", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Comprimento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("emb_dimensao_variavel", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.DimensaoVariavel);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("emb_ultima_revisao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UltimaRevisao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("emb_ultima_revisao_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UltimaRevisaoData ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_ultima_revisao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.UltimaRevisaoUsuario==null ? (object) DBNull.Value : this.UltimaRevisaoUsuario.ID;
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
 if (CollectionProdutoClassEmbalagem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoClassEmbalagem+"\r\n";
                foreach (Entidades.ProdutoClass tmp in CollectionProdutoClassEmbalagem)
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
        public static EmbalagemClass CopiarEntidade(EmbalagemClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               EmbalagemClass toRet = new EmbalagemClass(usuario,conn);
 toRet.Codigo= entidadeCopiar.Codigo;
 toRet.Descricao= entidadeCopiar.Descricao;
 toRet.Largura= entidadeCopiar.Largura;
 toRet.Altura= entidadeCopiar.Altura;
 toRet.Comprimento= entidadeCopiar.Comprimento;
 toRet.DimensaoVariavel= entidadeCopiar.DimensaoVariavel;

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
       _larguraOriginal = Largura;
       _larguraOriginalCommited = _larguraOriginal;
       _alturaOriginal = Altura;
       _alturaOriginalCommited = _alturaOriginal;
       _comprimentoOriginal = Comprimento;
       _comprimentoOriginalCommited = _comprimentoOriginal;
       _dimensaoVariavelOriginal = DimensaoVariavel;
       _dimensaoVariavelOriginalCommited = _dimensaoVariavelOriginal;
       _ultimaRevisaoOriginal = UltimaRevisao;
       _ultimaRevisaoOriginalCommited = _ultimaRevisaoOriginal ;
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
       _larguraOriginalCommited = Largura;
       _alturaOriginalCommited = Altura;
       _comprimentoOriginalCommited = Comprimento;
       _dimensaoVariavelOriginalCommited = DimensaoVariavel;
       _ultimaRevisaoOriginalCommited = UltimaRevisao;
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
               if (_valueCollectionProdutoClassEmbalagemLoaded) 
               {
                  if (_collectionProdutoClassEmbalagemRemovidos != null) 
                  {
                     _collectionProdutoClassEmbalagemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoClassEmbalagemRemovidos = new List<Entidades.ProdutoClass>();
                  }
                  _collectionProdutoClassEmbalagemOriginal= (from a in _valueCollectionProdutoClassEmbalagem select a.ID).ToList();
                  _valueCollectionProdutoClassEmbalagemChanged = false;
                  _valueCollectionProdutoClassEmbalagemCommitedChanged = false;
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
               Largura=_larguraOriginal;
               _larguraOriginalCommited=_larguraOriginal;
               Altura=_alturaOriginal;
               _alturaOriginalCommited=_alturaOriginal;
               Comprimento=_comprimentoOriginal;
               _comprimentoOriginalCommited=_comprimentoOriginal;
               DimensaoVariavel=_dimensaoVariavelOriginal;
               _dimensaoVariavelOriginalCommited=_dimensaoVariavelOriginal;
               UltimaRevisao=_ultimaRevisaoOriginal;
               _ultimaRevisaoOriginalCommited=_ultimaRevisaoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               if (_valueCollectionProdutoClassEmbalagemLoaded) 
               {
                  CollectionProdutoClassEmbalagem.Clear();
                  foreach(int item in _collectionProdutoClassEmbalagemOriginal)
                  {
                    CollectionProdutoClassEmbalagem.Add(Entidades.ProdutoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoClassEmbalagemRemovidos.Clear();
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
               if (_valueCollectionProdutoClassEmbalagemLoaded) 
               {
                  if (_valueCollectionProdutoClassEmbalagemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoClassEmbalagemLoaded) 
               {
                   tempRet = CollectionProdutoClassEmbalagem.Any(item => item.IsDirty());
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
       dirty = _larguraOriginal != Largura;
      if (dirty) return true;
       dirty = _alturaOriginal != Altura;
      if (dirty) return true;
       dirty = _comprimentoOriginal != Comprimento;
      if (dirty) return true;
       dirty = _dimensaoVariavelOriginal != DimensaoVariavel;
      if (dirty) return true;
       dirty = _ultimaRevisaoOriginal != UltimaRevisao;
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
               if (_valueCollectionProdutoClassEmbalagemLoaded) 
               {
                  if (_valueCollectionProdutoClassEmbalagemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoClassEmbalagemLoaded) 
               {
                   tempRet = CollectionProdutoClassEmbalagem.Any(item => item.IsDirtyCommited());
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
       dirty = _larguraOriginalCommited != Largura;
      if (dirty) return true;
       dirty = _alturaOriginalCommited != Altura;
      if (dirty) return true;
       dirty = _comprimentoOriginalCommited != Comprimento;
      if (dirty) return true;
       dirty = _dimensaoVariavelOriginalCommited != DimensaoVariavel;
      if (dirty) return true;
       dirty = _ultimaRevisaoOriginalCommited != UltimaRevisao;
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
               if (_valueCollectionProdutoClassEmbalagemLoaded) 
               {
                  foreach(ProdutoClass item in CollectionProdutoClassEmbalagem)
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
             case "Largura":
                return this.Largura;
             case "Altura":
                return this.Altura;
             case "Comprimento":
                return this.Comprimento;
             case "DimensaoVariavel":
                return this.DimensaoVariavel;
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
               if (_valueCollectionProdutoClassEmbalagemLoaded) 
               {
                  foreach(ProdutoClass item in CollectionProdutoClassEmbalagem)
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
                  command.CommandText += " COUNT(embalagem.id_embalagem) " ;
               }
               else
               {
               command.CommandText += "embalagem.id_embalagem, " ;
               command.CommandText += "embalagem.emb_codigo, " ;
               command.CommandText += "embalagem.emb_descricao, " ;
               command.CommandText += "embalagem.emb_largura, " ;
               command.CommandText += "embalagem.emb_altura, " ;
               command.CommandText += "embalagem.emb_comprimento, " ;
               command.CommandText += "embalagem.emb_dimensao_variavel, " ;
               command.CommandText += "embalagem.emb_ultima_revisao, " ;
               command.CommandText += "embalagem.emb_ultima_revisao_data, " ;
               command.CommandText += "embalagem.id_acs_usuario_ultima_revisao, " ;
               command.CommandText += "embalagem.entity_uid, " ;
               command.CommandText += "embalagem.version " ;
               }
               command.CommandText += " FROM  embalagem ";
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
                        orderByClause += " , emb_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(emb_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = embalagem.id_acs_usuario_ultima_revisao ";
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
                     case "id_embalagem":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , embalagem.id_embalagem " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(embalagem.id_embalagem) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "emb_codigo":
                     case "Codigo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , embalagem.emb_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(embalagem.emb_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "emb_descricao":
                     case "Descricao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , embalagem.emb_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(embalagem.emb_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "emb_largura":
                     case "Largura":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , embalagem.emb_largura " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(embalagem.emb_largura) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "emb_altura":
                     case "Altura":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , embalagem.emb_altura " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(embalagem.emb_altura) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "emb_comprimento":
                     case "Comprimento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , embalagem.emb_comprimento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(embalagem.emb_comprimento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "emb_dimensao_variavel":
                     case "DimensaoVariavel":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , embalagem.emb_dimensao_variavel " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(embalagem.emb_dimensao_variavel) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "emb_ultima_revisao":
                     case "UltimaRevisao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , embalagem.emb_ultima_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(embalagem.emb_ultima_revisao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "emb_ultima_revisao_data":
                     case "UltimaRevisaoData":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , embalagem.emb_ultima_revisao_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(embalagem.emb_ultima_revisao_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_ultima_revisao":
                     case "UltimaRevisaoUsuario":
                     orderByClause += " , embalagem.id_acs_usuario_ultima_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , embalagem.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(embalagem.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , embalagem.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(embalagem.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("emb_codigo")) 
                        {
                           whereClause += " OR UPPER(embalagem.emb_codigo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(embalagem.emb_codigo) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("emb_descricao")) 
                        {
                           whereClause += " OR UPPER(embalagem.emb_descricao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(embalagem.emb_descricao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("emb_ultima_revisao")) 
                        {
                           whereClause += " OR UPPER(embalagem.emb_ultima_revisao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(embalagem.emb_ultima_revisao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(embalagem.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(embalagem.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_embalagem")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  embalagem.id_embalagem IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  embalagem.id_embalagem = :embalagem_ID_5157 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("embalagem_ID_5157", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Codigo" || parametro.FieldName == "emb_codigo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  embalagem.emb_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  embalagem.emb_codigo LIKE :embalagem_Codigo_6146 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("embalagem_Codigo_6146", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Descricao" || parametro.FieldName == "emb_descricao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  embalagem.emb_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  embalagem.emb_descricao LIKE :embalagem_Descricao_1246 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("embalagem_Descricao_1246", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Largura" || parametro.FieldName == "emb_largura")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  embalagem.emb_largura IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  embalagem.emb_largura = :embalagem_Largura_302 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("embalagem_Largura_302", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Altura" || parametro.FieldName == "emb_altura")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  embalagem.emb_altura IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  embalagem.emb_altura = :embalagem_Altura_3931 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("embalagem_Altura_3931", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Comprimento" || parametro.FieldName == "emb_comprimento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  embalagem.emb_comprimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  embalagem.emb_comprimento = :embalagem_Comprimento_4917 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("embalagem_Comprimento_4917", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DimensaoVariavel" || parametro.FieldName == "emb_dimensao_variavel")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DimensaoVariavelEmbalagem)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DimensaoVariavelEmbalagem");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  embalagem.emb_dimensao_variavel IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  embalagem.emb_dimensao_variavel = :embalagem_DimensaoVariavel_1955 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("embalagem_DimensaoVariavel_1955", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao" || parametro.FieldName == "emb_ultima_revisao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  embalagem.emb_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  embalagem.emb_ultima_revisao LIKE :embalagem_UltimaRevisao_5758 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("embalagem_UltimaRevisao_5758", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoData" || parametro.FieldName == "emb_ultima_revisao_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  embalagem.emb_ultima_revisao_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  embalagem.emb_ultima_revisao_data = :embalagem_UltimaRevisaoData_4615 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("embalagem_UltimaRevisaoData_4615", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
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
                         whereClause += "  embalagem.id_acs_usuario_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  embalagem.id_acs_usuario_ultima_revisao = :embalagem_UltimaRevisaoUsuario_5505 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("embalagem_UltimaRevisaoUsuario_5505", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  embalagem.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  embalagem.entity_uid LIKE :embalagem_EntityUid_5671 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("embalagem_EntityUid_5671", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  embalagem.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  embalagem.version = :embalagem_Version_5987 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("embalagem_Version_5987", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  embalagem.emb_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  embalagem.emb_codigo LIKE :embalagem_Codigo_4583 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("embalagem_Codigo_4583", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  embalagem.emb_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  embalagem.emb_descricao LIKE :embalagem_Descricao_7194 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("embalagem_Descricao_7194", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  embalagem.emb_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  embalagem.emb_ultima_revisao LIKE :embalagem_UltimaRevisao_5790 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("embalagem_UltimaRevisao_5790", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  embalagem.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  embalagem.entity_uid LIKE :embalagem_EntityUid_6925 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("embalagem_EntityUid_6925", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  EmbalagemClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (EmbalagemClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(EmbalagemClass), Convert.ToInt32(read["id_embalagem"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new EmbalagemClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_embalagem"]);
                     entidade.Codigo = (read["emb_codigo"] != DBNull.Value ? read["emb_codigo"].ToString() : null);
                     entidade.Descricao = (read["emb_descricao"] != DBNull.Value ? read["emb_descricao"].ToString() : null);
                     entidade.Largura = (double)read["emb_largura"];
                     entidade.Altura = (double)read["emb_altura"];
                     entidade.Comprimento = (double)read["emb_comprimento"];
                     entidade.DimensaoVariavel = (DimensaoVariavelEmbalagem) (read["emb_dimensao_variavel"] != DBNull.Value ? Enum.ToObject(typeof(DimensaoVariavelEmbalagem), read["emb_dimensao_variavel"]) : null);
                     entidade.UltimaRevisao = (read["emb_ultima_revisao"] != DBNull.Value ? read["emb_ultima_revisao"].ToString() : null);
                     entidade.UltimaRevisaoData = read["emb_ultima_revisao_data"] as DateTime?;
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
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (EmbalagemClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
