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
     [Table("produto_pai_filho","ppf")]
     public class ProdutoPaiFilhoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do ProdutoPaiFilhoClass";
protected const string ErroDelete = "Erro ao excluir o ProdutoPaiFilhoClass  ";
protected const string ErroSave = "Erro ao salvar o ProdutoPaiFilhoClass.";
protected const string ErroCollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilho = "Erro ao carregar a coleção de ProdutoEstruturaInconsistenciaClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do ProdutoPaiFilhoClass.";
protected const string MensagemUtilizadoCollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilho =  "A entidade ProdutoPaiFilhoClass está sendo utilizada nos seguintes ProdutoEstruturaInconsistenciaClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade ProdutoPaiFilhoClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.ProdutoClass _produtoPaiOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.ProdutoClass _produtoPaiOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.ProdutoClass _valueProdutoPai;
        [Column("id_produto_pai", "produto", "id_produto")]
       public virtual BibliotecaEntidades.Entidades.ProdutoClass ProdutoPai
        { 
           get {                 return this._valueProdutoPai; } 
           set 
           { 
                if (this._valueProdutoPai == value)return;
                 this._valueProdutoPai = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.ProdutoClass _produtoFilhoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.ProdutoClass _produtoFilhoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.ProdutoClass _valueProdutoFilho;
        [Column("id_produto_filho", "produto", "id_produto")]
       public virtual BibliotecaEntidades.Entidades.ProdutoClass ProdutoFilho
        { 
           get {                 return this._valueProdutoFilho; } 
           set 
           { 
                if (this._valueProdutoFilho == value)return;
                 this._valueProdutoFilho = value; 
           } 
       } 

       protected double _quantidadeFilhoOriginal{get;private set;}
       private double _quantidadeFilhoOriginalCommited{get; set;}
        private double _valueQuantidadeFilho;
         [Column("ppf_quantidade_filho")]
        public virtual double QuantidadeFilho
         { 
            get { return this._valueQuantidadeFilho; } 
            set 
            { 
                if (this._valueQuantidadeFilho == value)return;
                 this._valueQuantidadeFilho = value; 
            } 
        } 

       protected bool _somaPrecoOriginal{get;private set;}
       private bool _somaPrecoOriginalCommited{get; set;}
        private bool _valueSomaPreco;
         [Column("ppf_soma_preco")]
        public virtual bool SomaPreco
         { 
            get { return this._valueSomaPreco; } 
            set 
            { 
                if (this._valueSomaPreco == value)return;
                 this._valueSomaPreco = value; 
            } 
        } 

       protected int _versaoEstruturaOriginal{get;private set;}
       private int _versaoEstruturaOriginalCommited{get; set;}
        private int _valueVersaoEstrutura;
         [Column("ppf_versao_estrutura")]
        public virtual int VersaoEstrutura
         { 
            get { return this._valueVersaoEstrutura; } 
            set 
            { 
                if (this._valueVersaoEstrutura == value)return;
                 this._valueVersaoEstrutura = value; 
            } 
        } 

       protected int _versaoEstruturaFilhoOriginal{get;private set;}
       private int _versaoEstruturaFilhoOriginalCommited{get; set;}
        private int _valueVersaoEstruturaFilho;
         [Column("ppf_versao_estrutura_filho")]
        public virtual int VersaoEstruturaFilho
         { 
            get { return this._valueVersaoEstruturaFilho; } 
            set 
            { 
                if (this._valueVersaoEstruturaFilho == value)return;
                 this._valueVersaoEstruturaFilho = value; 
            } 
        } 

       protected string _posicaoDesenhoPaiOriginal{get;private set;}
       private string _posicaoDesenhoPaiOriginalCommited{get; set;}
        private string _valuePosicaoDesenhoPai;
         [Column("ppf_posicao_desenho_pai")]
        public virtual string PosicaoDesenhoPai
         { 
            get { return this._valuePosicaoDesenhoPai; } 
            set 
            { 
                if (this._valuePosicaoDesenhoPai == value)return;
                 this._valuePosicaoDesenhoPai = value; 
            } 
        } 

       protected bool _filhoCondicionalOriginal{get;private set;}
       private bool _filhoCondicionalOriginalCommited{get; set;}
        private bool _valueFilhoCondicional;
         [Column("ppf_filho_condicional")]
        public virtual bool FilhoCondicional
         { 
            get { return this._valueFilhoCondicional; } 
            set 
            { 
                if (this._valueFilhoCondicional == value)return;
                 this._valueFilhoCondicional = value; 
            } 
        } 

       protected string _filhoCondicionalRegraOriginal{get;private set;}
       private string _filhoCondicionalRegraOriginalCommited{get; set;}
        private string _valueFilhoCondicionalRegra;
         [Column("ppf_filho_condicional_regra")]
        public virtual string FilhoCondicionalRegra
         { 
            get { return this._valueFilhoCondicionalRegra; } 
            set 
            { 
                if (this._valueFilhoCondicionalRegra == value)return;
                 this._valueFilhoCondicionalRegra = value; 
            } 
        } 

       protected bool _qtdCondicionalOriginal{get;private set;}
       private bool _qtdCondicionalOriginalCommited{get; set;}
        private bool _valueQtdCondicional;
         [Column("ppf_qtd_condicional")]
        public virtual bool QtdCondicional
         { 
            get { return this._valueQtdCondicional; } 
            set 
            { 
                if (this._valueQtdCondicional == value)return;
                 this._valueQtdCondicional = value; 
            } 
        } 

       protected string _qtdCondicionalRegraOriginal{get;private set;}
       private string _qtdCondicionalRegraOriginalCommited{get; set;}
        private string _valueQtdCondicionalRegra;
         [Column("ppf_qtd_condicional_regra")]
        public virtual string QtdCondicionalRegra
         { 
            get { return this._valueQtdCondicionalRegra; } 
            set 
            { 
                if (this._valueQtdCondicionalRegra == value)return;
                 this._valueQtdCondicionalRegra = value; 
            } 
        } 

       private List<long> _collectionProdutoEstruturaInconsistenciaClassProdutoPaiFilhoOriginal;
       private List<Entidades.ProdutoEstruturaInconsistenciaClass > _collectionProdutoEstruturaInconsistenciaClassProdutoPaiFilhoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilhoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilhoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilhoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoEstruturaInconsistenciaClass> _valueCollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilho { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoEstruturaInconsistenciaClass> CollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilho 
       { 
           get { if(!_valueCollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilhoLoaded && !this.DisableLoadCollection){this.LoadCollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilho();}
return this._valueCollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilho; } 
           set 
           { 
               this._valueCollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilho = value; 
               this._valueCollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilhoLoaded = true; 
           } 
       } 

        public ProdutoPaiFilhoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.QuantidadeFilho = 1;
           this.SomaPreco = false;
           this.VersaoEstrutura = 0;
           this.VersaoEstruturaFilho = 0;
           this.FilhoCondicional = false;
           this.QtdCondicional = false;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static ProdutoPaiFilhoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (ProdutoPaiFilhoClass) GetEntity(typeof(ProdutoPaiFilhoClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilhoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilhoChanged = true;
                  _valueCollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilhoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilhoChanged = true; 
                  _valueCollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilhoCommitedChanged = true;
                 foreach (Entidades.ProdutoEstruturaInconsistenciaClass item in e.OldItems) 
                 { 
                     _collectionProdutoEstruturaInconsistenciaClassProdutoPaiFilhoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilhoChanged = true; 
                  _valueCollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilhoCommitedChanged = true;
                 foreach (Entidades.ProdutoEstruturaInconsistenciaClass item in _valueCollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilho) 
                 { 
                     _collectionProdutoEstruturaInconsistenciaClassProdutoPaiFilhoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilho()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoEstruturaInconsistenciaClass> oc;
                _valueCollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilhoChanged = false;
                 _valueCollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilhoCommitedChanged = false;
                _collectionProdutoEstruturaInconsistenciaClassProdutoPaiFilhoRemovidos = new List<Entidades.ProdutoEstruturaInconsistenciaClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoEstruturaInconsistenciaClass>();
                }
                else{ 
                   Entidades.ProdutoEstruturaInconsistenciaClass search = new Entidades.ProdutoEstruturaInconsistenciaClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoEstruturaInconsistenciaClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ProdutoPaiFilho", this)                    }                       ).Cast<Entidades.ProdutoEstruturaInconsistenciaClass>().ToList());
                 }
                 _valueCollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilho = new BindingList<Entidades.ProdutoEstruturaInconsistenciaClass>(oc); 
                 _collectionProdutoEstruturaInconsistenciaClassProdutoPaiFilhoOriginal= (from a in _valueCollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilho select a.ID).ToList();
                 _valueCollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilhoLoaded = true;
                 oc.CollectionChanged += CollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilhoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilho+"\r\n" + e.Message, e);
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
                    "  public.produto_pai_filho  " +
                    "WHERE " +
                    "  id_produto_pai_filho = :id";
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
                        "  public.produto_pai_filho   " +
                        "SET  " + 
                        "  id_produto_pai = :id_produto_pai, " + 
                        "  id_produto_filho = :id_produto_filho, " + 
                        "  ppf_quantidade_filho = :ppf_quantidade_filho, " + 
                        "  ppf_soma_preco = :ppf_soma_preco, " + 
                        "  ppf_versao_estrutura = :ppf_versao_estrutura, " + 
                        "  ppf_versao_estrutura_filho = :ppf_versao_estrutura_filho, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  ppf_posicao_desenho_pai = :ppf_posicao_desenho_pai, " + 
                        "  ppf_filho_condicional = :ppf_filho_condicional, " + 
                        "  ppf_filho_condicional_regra = :ppf_filho_condicional_regra, " + 
                        "  ppf_qtd_condicional = :ppf_qtd_condicional, " + 
                        "  ppf_qtd_condicional_regra = :ppf_qtd_condicional_regra "+
                        "WHERE  " +
                        "  id_produto_pai_filho = :id " +
                        "RETURNING id_produto_pai_filho;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.produto_pai_filho " +
                        "( " +
                        "  id_produto_pai , " + 
                        "  id_produto_filho , " + 
                        "  ppf_quantidade_filho , " + 
                        "  ppf_soma_preco , " + 
                        "  ppf_versao_estrutura , " + 
                        "  ppf_versao_estrutura_filho , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  ppf_posicao_desenho_pai , " + 
                        "  ppf_filho_condicional , " + 
                        "  ppf_filho_condicional_regra , " + 
                        "  ppf_qtd_condicional , " + 
                        "  ppf_qtd_condicional_regra  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_produto_pai , " + 
                        "  :id_produto_filho , " + 
                        "  :ppf_quantidade_filho , " + 
                        "  :ppf_soma_preco , " + 
                        "  :ppf_versao_estrutura , " + 
                        "  :ppf_versao_estrutura_filho , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :ppf_posicao_desenho_pai , " + 
                        "  :ppf_filho_condicional , " + 
                        "  :ppf_filho_condicional_regra , " + 
                        "  :ppf_qtd_condicional , " + 
                        "  :ppf_qtd_condicional_regra  "+
                        ")RETURNING id_produto_pai_filho;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto_pai", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.ProdutoPai==null ? (object) DBNull.Value : this.ProdutoPai.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto_filho", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.ProdutoFilho==null ? (object) DBNull.Value : this.ProdutoFilho.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ppf_quantidade_filho", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.QuantidadeFilho ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ppf_soma_preco", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.SomaPreco ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ppf_versao_estrutura", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VersaoEstrutura ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ppf_versao_estrutura_filho", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VersaoEstruturaFilho ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ppf_posicao_desenho_pai", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PosicaoDesenhoPai ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ppf_filho_condicional", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.FilhoCondicional ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ppf_filho_condicional_regra", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.FilhoCondicionalRegra ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ppf_qtd_condicional", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.QtdCondicional ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ppf_qtd_condicional_regra", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.QtdCondicionalRegra ?? DBNull.Value;

 
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
 if (CollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilho.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilho+"\r\n";
                foreach (Entidades.ProdutoEstruturaInconsistenciaClass tmp in CollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilho)
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
        public static ProdutoPaiFilhoClass CopiarEntidade(ProdutoPaiFilhoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               ProdutoPaiFilhoClass toRet = new ProdutoPaiFilhoClass(usuario,conn);
 toRet.ProdutoPai= entidadeCopiar.ProdutoPai;
 toRet.ProdutoFilho= entidadeCopiar.ProdutoFilho;
 toRet.QuantidadeFilho= entidadeCopiar.QuantidadeFilho;
 toRet.SomaPreco= entidadeCopiar.SomaPreco;
 toRet.VersaoEstrutura= entidadeCopiar.VersaoEstrutura;
 toRet.VersaoEstruturaFilho= entidadeCopiar.VersaoEstruturaFilho;
 toRet.PosicaoDesenhoPai= entidadeCopiar.PosicaoDesenhoPai;
 toRet.FilhoCondicional= entidadeCopiar.FilhoCondicional;
 toRet.FilhoCondicionalRegra= entidadeCopiar.FilhoCondicionalRegra;
 toRet.QtdCondicional= entidadeCopiar.QtdCondicional;
 toRet.QtdCondicionalRegra= entidadeCopiar.QtdCondicionalRegra;

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
       _produtoPaiOriginal = ProdutoPai;
       _produtoPaiOriginalCommited = _produtoPaiOriginal;
       _produtoFilhoOriginal = ProdutoFilho;
       _produtoFilhoOriginalCommited = _produtoFilhoOriginal;
       _quantidadeFilhoOriginal = QuantidadeFilho;
       _quantidadeFilhoOriginalCommited = _quantidadeFilhoOriginal;
       _somaPrecoOriginal = SomaPreco;
       _somaPrecoOriginalCommited = _somaPrecoOriginal;
       _versaoEstruturaOriginal = VersaoEstrutura;
       _versaoEstruturaOriginalCommited = _versaoEstruturaOriginal;
       _versaoEstruturaFilhoOriginal = VersaoEstruturaFilho;
       _versaoEstruturaFilhoOriginalCommited = _versaoEstruturaFilhoOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _posicaoDesenhoPaiOriginal = PosicaoDesenhoPai;
       _posicaoDesenhoPaiOriginalCommited = _posicaoDesenhoPaiOriginal;
       _filhoCondicionalOriginal = FilhoCondicional;
       _filhoCondicionalOriginalCommited = _filhoCondicionalOriginal;
       _filhoCondicionalRegraOriginal = FilhoCondicionalRegra;
       _filhoCondicionalRegraOriginalCommited = _filhoCondicionalRegraOriginal;
       _qtdCondicionalOriginal = QtdCondicional;
       _qtdCondicionalOriginalCommited = _qtdCondicionalOriginal;
       _qtdCondicionalRegraOriginal = QtdCondicionalRegra;
       _qtdCondicionalRegraOriginalCommited = _qtdCondicionalRegraOriginal;

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
       _produtoPaiOriginalCommited = ProdutoPai;
       _produtoFilhoOriginalCommited = ProdutoFilho;
       _quantidadeFilhoOriginalCommited = QuantidadeFilho;
       _somaPrecoOriginalCommited = SomaPreco;
       _versaoEstruturaOriginalCommited = VersaoEstrutura;
       _versaoEstruturaFilhoOriginalCommited = VersaoEstruturaFilho;
       _versionOriginalCommited = Version;
       _posicaoDesenhoPaiOriginalCommited = PosicaoDesenhoPai;
       _filhoCondicionalOriginalCommited = FilhoCondicional;
       _filhoCondicionalRegraOriginalCommited = FilhoCondicionalRegra;
       _qtdCondicionalOriginalCommited = QtdCondicional;
       _qtdCondicionalRegraOriginalCommited = QtdCondicionalRegra;

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
               if (_valueCollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilhoLoaded) 
               {
                  if (_collectionProdutoEstruturaInconsistenciaClassProdutoPaiFilhoRemovidos != null) 
                  {
                     _collectionProdutoEstruturaInconsistenciaClassProdutoPaiFilhoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoEstruturaInconsistenciaClassProdutoPaiFilhoRemovidos = new List<Entidades.ProdutoEstruturaInconsistenciaClass>();
                  }
                  _collectionProdutoEstruturaInconsistenciaClassProdutoPaiFilhoOriginal= (from a in _valueCollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilho select a.ID).ToList();
                  _valueCollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilhoChanged = false;
                  _valueCollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilhoCommitedChanged = false;
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
               ProdutoPai=_produtoPaiOriginal;
               _produtoPaiOriginalCommited=_produtoPaiOriginal;
               ProdutoFilho=_produtoFilhoOriginal;
               _produtoFilhoOriginalCommited=_produtoFilhoOriginal;
               QuantidadeFilho=_quantidadeFilhoOriginal;
               _quantidadeFilhoOriginalCommited=_quantidadeFilhoOriginal;
               SomaPreco=_somaPrecoOriginal;
               _somaPrecoOriginalCommited=_somaPrecoOriginal;
               VersaoEstrutura=_versaoEstruturaOriginal;
               _versaoEstruturaOriginalCommited=_versaoEstruturaOriginal;
               VersaoEstruturaFilho=_versaoEstruturaFilhoOriginal;
               _versaoEstruturaFilhoOriginalCommited=_versaoEstruturaFilhoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               PosicaoDesenhoPai=_posicaoDesenhoPaiOriginal;
               _posicaoDesenhoPaiOriginalCommited=_posicaoDesenhoPaiOriginal;
               FilhoCondicional=_filhoCondicionalOriginal;
               _filhoCondicionalOriginalCommited=_filhoCondicionalOriginal;
               FilhoCondicionalRegra=_filhoCondicionalRegraOriginal;
               _filhoCondicionalRegraOriginalCommited=_filhoCondicionalRegraOriginal;
               QtdCondicional=_qtdCondicionalOriginal;
               _qtdCondicionalOriginalCommited=_qtdCondicionalOriginal;
               QtdCondicionalRegra=_qtdCondicionalRegraOriginal;
               _qtdCondicionalRegraOriginalCommited=_qtdCondicionalRegraOriginal;
               if (_valueCollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilhoLoaded) 
               {
                  CollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilho.Clear();
                  foreach(int item in _collectionProdutoEstruturaInconsistenciaClassProdutoPaiFilhoOriginal)
                  {
                    CollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilho.Add(Entidades.ProdutoEstruturaInconsistenciaClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoEstruturaInconsistenciaClassProdutoPaiFilhoRemovidos.Clear();
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
               if (_valueCollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilhoLoaded) 
               {
                  if (_valueCollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilhoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilhoLoaded) 
               {
                   tempRet = CollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilho.Any(item => item.IsDirty());
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
       if (_produtoPaiOriginal!=null)
       {
          dirty = !_produtoPaiOriginal.Equals(ProdutoPai);
       }
       else
       {
            dirty = ProdutoPai != null;
       }
      if (dirty) return true;
       if (_produtoFilhoOriginal!=null)
       {
          dirty = !_produtoFilhoOriginal.Equals(ProdutoFilho);
       }
       else
       {
            dirty = ProdutoFilho != null;
       }
      if (dirty) return true;
       dirty = _quantidadeFilhoOriginal != QuantidadeFilho;
      if (dirty) return true;
       dirty = _somaPrecoOriginal != SomaPreco;
      if (dirty) return true;
       dirty = _versaoEstruturaOriginal != VersaoEstrutura;
      if (dirty) return true;
       dirty = _versaoEstruturaFilhoOriginal != VersaoEstruturaFilho;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _posicaoDesenhoPaiOriginal != PosicaoDesenhoPai;
      if (dirty) return true;
       dirty = _filhoCondicionalOriginal != FilhoCondicional;
      if (dirty) return true;
       dirty = _filhoCondicionalRegraOriginal != FilhoCondicionalRegra;
      if (dirty) return true;
       dirty = _qtdCondicionalOriginal != QtdCondicional;
      if (dirty) return true;
       dirty = _qtdCondicionalRegraOriginal != QtdCondicionalRegra;

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
               if (_valueCollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilhoLoaded) 
               {
                  if (_valueCollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilhoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilhoLoaded) 
               {
                   tempRet = CollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilho.Any(item => item.IsDirtyCommited());
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
       if (_produtoPaiOriginalCommited!=null)
       {
          dirty = !_produtoPaiOriginalCommited.Equals(ProdutoPai);
       }
       else
       {
            dirty = ProdutoPai != null;
       }
      if (dirty) return true;
       if (_produtoFilhoOriginalCommited!=null)
       {
          dirty = !_produtoFilhoOriginalCommited.Equals(ProdutoFilho);
       }
       else
       {
            dirty = ProdutoFilho != null;
       }
      if (dirty) return true;
       dirty = _quantidadeFilhoOriginalCommited != QuantidadeFilho;
      if (dirty) return true;
       dirty = _somaPrecoOriginalCommited != SomaPreco;
      if (dirty) return true;
       dirty = _versaoEstruturaOriginalCommited != VersaoEstrutura;
      if (dirty) return true;
       dirty = _versaoEstruturaFilhoOriginalCommited != VersaoEstruturaFilho;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _posicaoDesenhoPaiOriginalCommited != PosicaoDesenhoPai;
      if (dirty) return true;
       dirty = _filhoCondicionalOriginalCommited != FilhoCondicional;
      if (dirty) return true;
       dirty = _filhoCondicionalRegraOriginalCommited != FilhoCondicionalRegra;
      if (dirty) return true;
       dirty = _qtdCondicionalOriginalCommited != QtdCondicional;
      if (dirty) return true;
       dirty = _qtdCondicionalRegraOriginalCommited != QtdCondicionalRegra;

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
               if (_valueCollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilhoLoaded) 
               {
                  foreach(ProdutoEstruturaInconsistenciaClass item in CollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilho)
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
             case "ProdutoPai":
                return this.ProdutoPai;
             case "ProdutoFilho":
                return this.ProdutoFilho;
             case "QuantidadeFilho":
                return this.QuantidadeFilho;
             case "SomaPreco":
                return this.SomaPreco;
             case "VersaoEstrutura":
                return this.VersaoEstrutura;
             case "VersaoEstruturaFilho":
                return this.VersaoEstruturaFilho;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "PosicaoDesenhoPai":
                return this.PosicaoDesenhoPai;
             case "FilhoCondicional":
                return this.FilhoCondicional;
             case "FilhoCondicionalRegra":
                return this.FilhoCondicionalRegra;
             case "QtdCondicional":
                return this.QtdCondicional;
             case "QtdCondicionalRegra":
                return this.QtdCondicionalRegra;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (ProdutoPai!=null)
                ProdutoPai.ChangeSingleConnection(newConnection);
             if (ProdutoFilho!=null)
                ProdutoFilho.ChangeSingleConnection(newConnection);
               if (_valueCollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilhoLoaded) 
               {
                  foreach(ProdutoEstruturaInconsistenciaClass item in CollectionProdutoEstruturaInconsistenciaClassProdutoPaiFilho)
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
                  command.CommandText += " COUNT(produto_pai_filho.id_produto_pai_filho) " ;
               }
               else
               {
               command.CommandText += "produto_pai_filho.id_produto_pai_filho, " ;
               command.CommandText += "produto_pai_filho.id_produto_pai, " ;
               command.CommandText += "produto_pai_filho.id_produto_filho, " ;
               command.CommandText += "produto_pai_filho.ppf_quantidade_filho, " ;
               command.CommandText += "produto_pai_filho.ppf_soma_preco, " ;
               command.CommandText += "produto_pai_filho.ppf_versao_estrutura, " ;
               command.CommandText += "produto_pai_filho.ppf_versao_estrutura_filho, " ;
               command.CommandText += "produto_pai_filho.entity_uid, " ;
               command.CommandText += "produto_pai_filho.version, " ;
               command.CommandText += "produto_pai_filho.ppf_posicao_desenho_pai, " ;
               command.CommandText += "produto_pai_filho.ppf_filho_condicional, " ;
               command.CommandText += "produto_pai_filho.ppf_filho_condicional_regra, " ;
               command.CommandText += "produto_pai_filho.ppf_qtd_condicional, " ;
               command.CommandText += "produto_pai_filho.ppf_qtd_condicional_regra " ;
               }
               command.CommandText += " FROM  produto_pai_filho ";
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
                        orderByClause += " , ppf_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(ppf_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = produto_pai_filho.id_acs_usuario_ultima_revisao ";
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
                     case "id_produto_pai_filho":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_pai_filho.id_produto_pai_filho " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_pai_filho.id_produto_pai_filho) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_produto_pai":
                     case "ProdutoPai":
                     command.CommandText += " LEFT JOIN produto as produto_ProdutoPai ON produto_ProdutoPai.id_produto = produto_pai_filho.id_produto_pai ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_ProdutoPai.pro_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_ProdutoPai.pro_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_produto_filho":
                     case "ProdutoFilho":
                     command.CommandText += " LEFT JOIN produto as produto_ProdutoFilho ON produto_ProdutoFilho.id_produto = produto_pai_filho.id_produto_filho ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_ProdutoFilho.pro_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_ProdutoFilho.pro_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ppf_quantidade_filho":
                     case "QuantidadeFilho":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_pai_filho.ppf_quantidade_filho " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_pai_filho.ppf_quantidade_filho) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ppf_soma_preco":
                     case "SomaPreco":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_pai_filho.ppf_soma_preco " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_pai_filho.ppf_soma_preco) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ppf_versao_estrutura":
                     case "VersaoEstrutura":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_pai_filho.ppf_versao_estrutura " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_pai_filho.ppf_versao_estrutura) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ppf_versao_estrutura_filho":
                     case "VersaoEstruturaFilho":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_pai_filho.ppf_versao_estrutura_filho " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_pai_filho.ppf_versao_estrutura_filho) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_pai_filho.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_pai_filho.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , produto_pai_filho.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_pai_filho.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ppf_posicao_desenho_pai":
                     case "PosicaoDesenhoPai":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_pai_filho.ppf_posicao_desenho_pai " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_pai_filho.ppf_posicao_desenho_pai) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ppf_filho_condicional":
                     case "FilhoCondicional":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_pai_filho.ppf_filho_condicional " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_pai_filho.ppf_filho_condicional) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ppf_filho_condicional_regra":
                     case "FilhoCondicionalRegra":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_pai_filho.ppf_filho_condicional_regra " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_pai_filho.ppf_filho_condicional_regra) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ppf_qtd_condicional":
                     case "QtdCondicional":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_pai_filho.ppf_qtd_condicional " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_pai_filho.ppf_qtd_condicional) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ppf_qtd_condicional_regra":
                     case "QtdCondicionalRegra":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_pai_filho.ppf_qtd_condicional_regra " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_pai_filho.ppf_qtd_condicional_regra) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           whereClause += " OR UPPER(produto_pai_filho.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto_pai_filho.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ppf_posicao_desenho_pai")) 
                        {
                           whereClause += " OR UPPER(produto_pai_filho.ppf_posicao_desenho_pai) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto_pai_filho.ppf_posicao_desenho_pai) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ppf_filho_condicional_regra")) 
                        {
                           whereClause += " OR UPPER(produto_pai_filho.ppf_filho_condicional_regra) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto_pai_filho.ppf_filho_condicional_regra) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ppf_qtd_condicional_regra")) 
                        {
                           whereClause += " OR UPPER(produto_pai_filho.ppf_qtd_condicional_regra) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto_pai_filho.ppf_qtd_condicional_regra) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_produto_pai_filho")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_pai_filho.id_produto_pai_filho IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_pai_filho.id_produto_pai_filho = :produto_pai_filho_ID_8450 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_pai_filho_ID_8450", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ProdutoPai" || parametro.FieldName == "id_produto_pai")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.ProdutoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.ProdutoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_pai_filho.id_produto_pai IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_pai_filho.id_produto_pai = :produto_pai_filho_ProdutoPai_3328 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_pai_filho_ProdutoPai_3328", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ProdutoFilho" || parametro.FieldName == "id_produto_filho")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.ProdutoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.ProdutoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_pai_filho.id_produto_filho IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_pai_filho.id_produto_filho = :produto_pai_filho_ProdutoFilho_3928 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_pai_filho_ProdutoFilho_3928", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "QuantidadeFilho" || parametro.FieldName == "ppf_quantidade_filho")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_pai_filho.ppf_quantidade_filho IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_pai_filho.ppf_quantidade_filho = :produto_pai_filho_QuantidadeFilho_7340 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_pai_filho_QuantidadeFilho_7340", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SomaPreco" || parametro.FieldName == "ppf_soma_preco")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_pai_filho.ppf_soma_preco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_pai_filho.ppf_soma_preco = :produto_pai_filho_SomaPreco_7440 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_pai_filho_SomaPreco_7440", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VersaoEstrutura" || parametro.FieldName == "ppf_versao_estrutura")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_pai_filho.ppf_versao_estrutura IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_pai_filho.ppf_versao_estrutura = :produto_pai_filho_VersaoEstrutura_710 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_pai_filho_VersaoEstrutura_710", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VersaoEstruturaFilho" || parametro.FieldName == "ppf_versao_estrutura_filho")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_pai_filho.ppf_versao_estrutura_filho IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_pai_filho.ppf_versao_estrutura_filho = :produto_pai_filho_VersaoEstruturaFilho_3486 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_pai_filho_VersaoEstruturaFilho_3486", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  produto_pai_filho.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_pai_filho.entity_uid LIKE :produto_pai_filho_EntityUid_4447 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_pai_filho_EntityUid_4447", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  produto_pai_filho.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_pai_filho.version = :produto_pai_filho_Version_6571 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_pai_filho_Version_6571", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PosicaoDesenhoPai" || parametro.FieldName == "ppf_posicao_desenho_pai")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_pai_filho.ppf_posicao_desenho_pai IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_pai_filho.ppf_posicao_desenho_pai LIKE :produto_pai_filho_PosicaoDesenhoPai_8089 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_pai_filho_PosicaoDesenhoPai_8089", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "FilhoCondicional" || parametro.FieldName == "ppf_filho_condicional")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_pai_filho.ppf_filho_condicional IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_pai_filho.ppf_filho_condicional = :produto_pai_filho_FilhoCondicional_1884 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_pai_filho_FilhoCondicional_1884", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "FilhoCondicionalRegra" || parametro.FieldName == "ppf_filho_condicional_regra")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_pai_filho.ppf_filho_condicional_regra IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_pai_filho.ppf_filho_condicional_regra LIKE :produto_pai_filho_FilhoCondicionalRegra_2572 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_pai_filho_FilhoCondicionalRegra_2572", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "QtdCondicional" || parametro.FieldName == "ppf_qtd_condicional")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_pai_filho.ppf_qtd_condicional IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_pai_filho.ppf_qtd_condicional = :produto_pai_filho_QtdCondicional_5844 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_pai_filho_QtdCondicional_5844", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "QtdCondicionalRegra" || parametro.FieldName == "ppf_qtd_condicional_regra")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_pai_filho.ppf_qtd_condicional_regra IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_pai_filho.ppf_qtd_condicional_regra LIKE :produto_pai_filho_QtdCondicionalRegra_4697 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_pai_filho_QtdCondicionalRegra_4697", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  produto_pai_filho.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_pai_filho.entity_uid LIKE :produto_pai_filho_EntityUid_3641 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_pai_filho_EntityUid_3641", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PosicaoDesenhoPaiExato" || parametro.FieldName == "PosicaoDesenhoPaiExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_pai_filho.ppf_posicao_desenho_pai IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_pai_filho.ppf_posicao_desenho_pai LIKE :produto_pai_filho_PosicaoDesenhoPai_322 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_pai_filho_PosicaoDesenhoPai_322", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "FilhoCondicionalRegraExato" || parametro.FieldName == "FilhoCondicionalRegraExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_pai_filho.ppf_filho_condicional_regra IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_pai_filho.ppf_filho_condicional_regra LIKE :produto_pai_filho_FilhoCondicionalRegra_3353 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_pai_filho_FilhoCondicionalRegra_3353", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "QtdCondicionalRegraExato" || parametro.FieldName == "QtdCondicionalRegraExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_pai_filho.ppf_qtd_condicional_regra IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_pai_filho.ppf_qtd_condicional_regra LIKE :produto_pai_filho_QtdCondicionalRegra_9329 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_pai_filho_QtdCondicionalRegra_9329", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  ProdutoPaiFilhoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (ProdutoPaiFilhoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(ProdutoPaiFilhoClass), Convert.ToInt32(read["id_produto_pai_filho"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new ProdutoPaiFilhoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_produto_pai_filho"]);
                     if (read["id_produto_pai"] != DBNull.Value)
                     {
                        entidade.ProdutoPai = (BibliotecaEntidades.Entidades.ProdutoClass)BibliotecaEntidades.Entidades.ProdutoClass.GetEntidade(Convert.ToInt32(read["id_produto_pai"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.ProdutoPai = null ;
                     }
                     if (read["id_produto_filho"] != DBNull.Value)
                     {
                        entidade.ProdutoFilho = (BibliotecaEntidades.Entidades.ProdutoClass)BibliotecaEntidades.Entidades.ProdutoClass.GetEntidade(Convert.ToInt32(read["id_produto_filho"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.ProdutoFilho = null ;
                     }
                     entidade.QuantidadeFilho = (double)read["ppf_quantidade_filho"];
                     entidade.SomaPreco = Convert.ToBoolean(Convert.ToInt16(read["ppf_soma_preco"]));
                     entidade.VersaoEstrutura = (int)read["ppf_versao_estrutura"];
                     entidade.VersaoEstruturaFilho = (int)read["ppf_versao_estrutura_filho"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.PosicaoDesenhoPai = (read["ppf_posicao_desenho_pai"] != DBNull.Value ? read["ppf_posicao_desenho_pai"].ToString() : null);
                     entidade.FilhoCondicional = Convert.ToBoolean(Convert.ToInt16(read["ppf_filho_condicional"]));
                     entidade.FilhoCondicionalRegra = (read["ppf_filho_condicional_regra"] != DBNull.Value ? read["ppf_filho_condicional_regra"].ToString() : null);
                     entidade.QtdCondicional = Convert.ToBoolean(Convert.ToInt16(read["ppf_qtd_condicional"]));
                     entidade.QtdCondicionalRegra = (read["ppf_qtd_condicional_regra"] != DBNull.Value ? read["ppf_qtd_condicional_regra"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (ProdutoPaiFilhoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
