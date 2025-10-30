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
using IWTNF.Entidades.Entidades;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
namespace IWTNF.Entidades.Base 
{ 
    [Serializable()]
     [Table("nf_produto_declaracao_importacao","npd")]
     public class NfProdutoDeclaracaoImportacaoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do NfProdutoDeclaracaoImportacaoClass";
protected const string ErroDelete = "Erro ao excluir o NfProdutoDeclaracaoImportacaoClass  ";
protected const string ErroSave = "Erro ao salvar o NfProdutoDeclaracaoImportacaoClass.";
protected const string ErroCollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacao = "Erro ao carregar a coleção de NfProdutoDeclaracaoImportacaoAdicaoClass.";
protected const string ErroNumeroDocImportacaoObrigatorio = "O campo NumeroDocImportacao é obrigatório";
protected const string ErroNumeroDocImportacaoComprimento = "O campo NumeroDocImportacao deve ter no máximo 12 caracteres";
protected const string ErroLocalDesembaracoObrigatorio = "O campo LocalDesembaraco é obrigatório";
protected const string ErroLocalDesembaracoComprimento = "O campo LocalDesembaraco deve ter no máximo 60 caracteres";
protected const string ErroUfDesembaracoObrigatorio = "O campo UfDesembaraco é obrigatório";
protected const string ErroUfDesembaracoComprimento = "O campo UfDesembaraco deve ter no máximo 2 caracteres";
protected const string ErroCodigoExportadorObrigatorio = "O campo CodigoExportador é obrigatório";
protected const string ErroCodigoExportadorComprimento = "O campo CodigoExportador deve ter no máximo 60 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroNfItemObrigatorio = "O campo NfItem é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do NfProdutoDeclaracaoImportacaoClass.";
protected const string MensagemUtilizadoCollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacao =  "A entidade NfProdutoDeclaracaoImportacaoClass está sendo utilizada nos seguintes NfProdutoDeclaracaoImportacaoAdicaoClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade NfProdutoDeclaracaoImportacaoClass está sendo utilizada.";
#endregion
       protected IWTNF.Entidades.Entidades.NfItemClass _nfItemOriginal{get;private set;}
       private IWTNF.Entidades.Entidades.NfItemClass _nfItemOriginalCommited {get; set;}
       private IWTNF.Entidades.Entidades.NfItemClass _valueNfItem;
        [Column("id_nf_item", "nf_item", "id_nf_item")]
       public virtual IWTNF.Entidades.Entidades.NfItemClass NfItem
        { 
           get {                 return this._valueNfItem; } 
           set 
           { 
                if (this._valueNfItem == value)return;
                 this._valueNfItem = value; 
           } 
       } 

       protected string _numeroDocImportacaoOriginal{get;private set;}
       private string _numeroDocImportacaoOriginalCommited{get; set;}
        private string _valueNumeroDocImportacao;
         [Column("npd_numero_doc_importacao")]
        public virtual string NumeroDocImportacao
         { 
            get { return this._valueNumeroDocImportacao; } 
            set 
            { 
                if (this._valueNumeroDocImportacao == value)return;
                 this._valueNumeroDocImportacao = value; 
            } 
        } 

       protected DateTime _dataRegistroDiOriginal{get;private set;}
       private DateTime _dataRegistroDiOriginalCommited{get; set;}
        private DateTime _valueDataRegistroDi;
         [Column("npd_data_registro_di")]
        public virtual DateTime DataRegistroDi
         { 
            get { return this._valueDataRegistroDi; } 
            set 
            { 
                if (this._valueDataRegistroDi == value)return;
                 this._valueDataRegistroDi = value; 
            } 
        } 

       protected string _localDesembaracoOriginal{get;private set;}
       private string _localDesembaracoOriginalCommited{get; set;}
        private string _valueLocalDesembaraco;
         [Column("npd_local_desembaraco")]
        public virtual string LocalDesembaraco
         { 
            get { return this._valueLocalDesembaraco; } 
            set 
            { 
                if (this._valueLocalDesembaraco == value)return;
                 this._valueLocalDesembaraco = value; 
            } 
        } 

       protected string _ufDesembaracoOriginal{get;private set;}
       private string _ufDesembaracoOriginalCommited{get; set;}
        private string _valueUfDesembaraco;
         [Column("npd_uf_desembaraco")]
        public virtual string UfDesembaraco
         { 
            get { return this._valueUfDesembaraco; } 
            set 
            { 
                if (this._valueUfDesembaraco == value)return;
                 this._valueUfDesembaraco = value; 
            } 
        } 

       protected DateTime _dataDesembaracoOriginal{get;private set;}
       private DateTime _dataDesembaracoOriginalCommited{get; set;}
        private DateTime _valueDataDesembaraco;
         [Column("npd_data_desembaraco")]
        public virtual DateTime DataDesembaraco
         { 
            get { return this._valueDataDesembaraco; } 
            set 
            { 
                if (this._valueDataDesembaraco == value)return;
                 this._valueDataDesembaraco = value; 
            } 
        } 

       protected string _codigoExportadorOriginal{get;private set;}
       private string _codigoExportadorOriginalCommited{get; set;}
        private string _valueCodigoExportador;
         [Column("npd_codigo_exportador")]
        public virtual string CodigoExportador
         { 
            get { return this._valueCodigoExportador; } 
            set 
            { 
                if (this._valueCodigoExportador == value)return;
                 this._valueCodigoExportador = value; 
            } 
        } 

       protected int _viaTransporteOriginal{get;private set;}
       private int _viaTransporteOriginalCommited{get; set;}
        private int _valueViaTransporte;
         [Column("npd_via_transporte")]
        public virtual int ViaTransporte
         { 
            get { return this._valueViaTransporte; } 
            set 
            { 
                if (this._valueViaTransporte == value)return;
                 this._valueViaTransporte = value; 
            } 
        } 

       protected double? _valorAfrmmOriginal{get;private set;}
       private double? _valorAfrmmOriginalCommited{get; set;}
        private double? _valueValorAfrmm;
         [Column("npd_valor_afrmm")]
        public virtual double? ValorAfrmm
         { 
            get { return this._valueValorAfrmm; } 
            set 
            { 
                if (this._valueValorAfrmm == value)return;
                 this._valueValorAfrmm = value; 
            } 
        } 

       protected int _tipoIntermedioOriginal{get;private set;}
       private int _tipoIntermedioOriginalCommited{get; set;}
        private int _valueTipoIntermedio;
         [Column("npd_tipo_intermedio")]
        public virtual int TipoIntermedio
         { 
            get { return this._valueTipoIntermedio; } 
            set 
            { 
                if (this._valueTipoIntermedio == value)return;
                 this._valueTipoIntermedio = value; 
            } 
        } 

       protected string _cnpjAdquirenteOriginal{get;private set;}
       private string _cnpjAdquirenteOriginalCommited{get; set;}
        private string _valueCnpjAdquirente;
         [Column("npd_cnpj_adquirente")]
        public virtual string CnpjAdquirente
         { 
            get { return this._valueCnpjAdquirente; } 
            set 
            { 
                if (this._valueCnpjAdquirente == value)return;
                 this._valueCnpjAdquirente = value; 
            } 
        } 

       protected string _ufTerceiroOriginal{get;private set;}
       private string _ufTerceiroOriginalCommited{get; set;}
        private string _valueUfTerceiro;
         [Column("npd_uf_terceiro")]
        public virtual string UfTerceiro
         { 
            get { return this._valueUfTerceiro; } 
            set 
            { 
                if (this._valueUfTerceiro == value)return;
                 this._valueUfTerceiro = value; 
            } 
        } 

       private List<long> _collectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacaoOriginal;
       private List<Entidades.NfProdutoDeclaracaoImportacaoAdicaoClass > _collectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacaoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacaoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacaoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacaoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfProdutoDeclaracaoImportacaoAdicaoClass> _valueCollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacao { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfProdutoDeclaracaoImportacaoAdicaoClass> CollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacao 
       { 
           get { if(!_valueCollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacaoLoaded && !this.DisableLoadCollection){this.LoadCollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacao();}
return this._valueCollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacao; } 
           set 
           { 
               this._valueCollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacao = value; 
               this._valueCollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacaoLoaded = true; 
           } 
       } 

        public NfProdutoDeclaracaoImportacaoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.ViaTransporte = 4;
           this.TipoIntermedio = 1;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static NfProdutoDeclaracaoImportacaoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (NfProdutoDeclaracaoImportacaoClass) GetEntity(typeof(NfProdutoDeclaracaoImportacaoClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacaoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacaoChanged = true;
                  _valueCollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacaoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacaoChanged = true; 
                  _valueCollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacaoCommitedChanged = true;
                 foreach (Entidades.NfProdutoDeclaracaoImportacaoAdicaoClass item in e.OldItems) 
                 { 
                     _collectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacaoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacaoChanged = true; 
                  _valueCollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacaoCommitedChanged = true;
                 foreach (Entidades.NfProdutoDeclaracaoImportacaoAdicaoClass item in _valueCollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacao) 
                 { 
                     _collectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacaoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacao()
         {
            try
            {
                 ObservableCollection<Entidades.NfProdutoDeclaracaoImportacaoAdicaoClass> oc;
                _valueCollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacaoChanged = false;
                 _valueCollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacaoCommitedChanged = false;
                _collectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacaoRemovidos = new List<Entidades.NfProdutoDeclaracaoImportacaoAdicaoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfProdutoDeclaracaoImportacaoAdicaoClass>();
                }
                else{ 
                   Entidades.NfProdutoDeclaracaoImportacaoAdicaoClass search = new Entidades.NfProdutoDeclaracaoImportacaoAdicaoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfProdutoDeclaracaoImportacaoAdicaoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfProdutoDeclaracaoImportacao", this)                    }                       ).Cast<Entidades.NfProdutoDeclaracaoImportacaoAdicaoClass>().ToList());
                 }
                 _valueCollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacao = new BindingList<Entidades.NfProdutoDeclaracaoImportacaoAdicaoClass>(oc); 
                 _collectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacaoOriginal= (from a in _valueCollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacao select a.ID).ToList();
                 _valueCollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacaoLoaded = true;
                 oc.CollectionChanged += CollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacaoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacao+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(NumeroDocImportacao))
                {
                    throw new Exception(ErroNumeroDocImportacaoObrigatorio);
                }
                if (NumeroDocImportacao.Length >12)
                {
                    throw new Exception( ErroNumeroDocImportacaoComprimento);
                }
                if (string.IsNullOrEmpty(LocalDesembaraco))
                {
                    throw new Exception(ErroLocalDesembaracoObrigatorio);
                }
                if (LocalDesembaraco.Length >60)
                {
                    throw new Exception( ErroLocalDesembaracoComprimento);
                }
                if (string.IsNullOrEmpty(UfDesembaraco))
                {
                    throw new Exception(ErroUfDesembaracoObrigatorio);
                }
                if (UfDesembaraco.Length >2)
                {
                    throw new Exception( ErroUfDesembaracoComprimento);
                }
                if (string.IsNullOrEmpty(CodigoExportador))
                {
                    throw new Exception(ErroCodigoExportadorObrigatorio);
                }
                if (CodigoExportador.Length >60)
                {
                    throw new Exception( ErroCodigoExportadorComprimento);
                }
                if ( _valueNfItem == null)
                {
                    throw new Exception(ErroNfItemObrigatorio);
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
                    "  public.nf_produto_declaracao_importacao  " +
                    "WHERE " +
                    "  id_nf_produto_declaracao_importacao = :id";
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
                        "  public.nf_produto_declaracao_importacao   " +
                        "SET  " + 
                        "  id_nf_item = :id_nf_item, " + 
                        "  npd_numero_doc_importacao = :npd_numero_doc_importacao, " + 
                        "  npd_data_registro_di = :npd_data_registro_di, " + 
                        "  npd_local_desembaraco = :npd_local_desembaraco, " + 
                        "  npd_uf_desembaraco = :npd_uf_desembaraco, " + 
                        "  npd_data_desembaraco = :npd_data_desembaraco, " + 
                        "  npd_codigo_exportador = :npd_codigo_exportador, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  npd_via_transporte = :npd_via_transporte, " + 
                        "  npd_valor_afrmm = :npd_valor_afrmm, " + 
                        "  npd_tipo_intermedio = :npd_tipo_intermedio, " + 
                        "  npd_cnpj_adquirente = :npd_cnpj_adquirente, " + 
                        "  npd_uf_terceiro = :npd_uf_terceiro "+
                        "WHERE  " +
                        "  id_nf_produto_declaracao_importacao = :id " +
                        "RETURNING id_nf_produto_declaracao_importacao;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.nf_produto_declaracao_importacao " +
                        "( " +
                        "  id_nf_item , " + 
                        "  npd_numero_doc_importacao , " + 
                        "  npd_data_registro_di , " + 
                        "  npd_local_desembaraco , " + 
                        "  npd_uf_desembaraco , " + 
                        "  npd_data_desembaraco , " + 
                        "  npd_codigo_exportador , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  npd_via_transporte , " + 
                        "  npd_valor_afrmm , " + 
                        "  npd_tipo_intermedio , " + 
                        "  npd_cnpj_adquirente , " + 
                        "  npd_uf_terceiro  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_nf_item , " + 
                        "  :npd_numero_doc_importacao , " + 
                        "  :npd_data_registro_di , " + 
                        "  :npd_local_desembaraco , " + 
                        "  :npd_uf_desembaraco , " + 
                        "  :npd_data_desembaraco , " + 
                        "  :npd_codigo_exportador , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :npd_via_transporte , " + 
                        "  :npd_valor_afrmm , " + 
                        "  :npd_tipo_intermedio , " + 
                        "  :npd_cnpj_adquirente , " + 
                        "  :npd_uf_terceiro  "+
                        ")RETURNING id_nf_produto_declaracao_importacao;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nf_item", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.NfItem==null ? (object) DBNull.Value : this.NfItem.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npd_numero_doc_importacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NumeroDocImportacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npd_data_registro_di", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataRegistroDi ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npd_local_desembaraco", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.LocalDesembaraco ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npd_uf_desembaraco", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UfDesembaraco ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npd_data_desembaraco", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataDesembaraco ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npd_codigo_exportador", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CodigoExportador ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npd_via_transporte", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ViaTransporte ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npd_valor_afrmm", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorAfrmm ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npd_tipo_intermedio", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.TipoIntermedio ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npd_cnpj_adquirente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CnpjAdquirente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npd_uf_terceiro", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UfTerceiro ?? DBNull.Value;

 
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
 if (CollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacao.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacao+"\r\n";
                foreach (Entidades.NfProdutoDeclaracaoImportacaoAdicaoClass tmp in CollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacao)
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
        public static NfProdutoDeclaracaoImportacaoClass CopiarEntidade(NfProdutoDeclaracaoImportacaoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               NfProdutoDeclaracaoImportacaoClass toRet = new NfProdutoDeclaracaoImportacaoClass(usuario,conn);
 toRet.NfItem= entidadeCopiar.NfItem;
 toRet.NumeroDocImportacao= entidadeCopiar.NumeroDocImportacao;
 toRet.DataRegistroDi= entidadeCopiar.DataRegistroDi;
 toRet.LocalDesembaraco= entidadeCopiar.LocalDesembaraco;
 toRet.UfDesembaraco= entidadeCopiar.UfDesembaraco;
 toRet.DataDesembaraco= entidadeCopiar.DataDesembaraco;
 toRet.CodigoExportador= entidadeCopiar.CodigoExportador;
 toRet.ViaTransporte= entidadeCopiar.ViaTransporte;
 toRet.ValorAfrmm= entidadeCopiar.ValorAfrmm;
 toRet.TipoIntermedio= entidadeCopiar.TipoIntermedio;
 toRet.CnpjAdquirente= entidadeCopiar.CnpjAdquirente;
 toRet.UfTerceiro= entidadeCopiar.UfTerceiro;

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
       _nfItemOriginal = NfItem;
       _nfItemOriginalCommited = _nfItemOriginal;
       _numeroDocImportacaoOriginal = NumeroDocImportacao;
       _numeroDocImportacaoOriginalCommited = _numeroDocImportacaoOriginal;
       _dataRegistroDiOriginal = DataRegistroDi;
       _dataRegistroDiOriginalCommited = _dataRegistroDiOriginal;
       _localDesembaracoOriginal = LocalDesembaraco;
       _localDesembaracoOriginalCommited = _localDesembaracoOriginal;
       _ufDesembaracoOriginal = UfDesembaraco;
       _ufDesembaracoOriginalCommited = _ufDesembaracoOriginal;
       _dataDesembaracoOriginal = DataDesembaraco;
       _dataDesembaracoOriginalCommited = _dataDesembaracoOriginal;
       _codigoExportadorOriginal = CodigoExportador;
       _codigoExportadorOriginalCommited = _codigoExportadorOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _viaTransporteOriginal = ViaTransporte;
       _viaTransporteOriginalCommited = _viaTransporteOriginal;
       _valorAfrmmOriginal = ValorAfrmm;
       _valorAfrmmOriginalCommited = _valorAfrmmOriginal;
       _tipoIntermedioOriginal = TipoIntermedio;
       _tipoIntermedioOriginalCommited = _tipoIntermedioOriginal;
       _cnpjAdquirenteOriginal = CnpjAdquirente;
       _cnpjAdquirenteOriginalCommited = _cnpjAdquirenteOriginal;
       _ufTerceiroOriginal = UfTerceiro;
       _ufTerceiroOriginalCommited = _ufTerceiroOriginal;

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
       _nfItemOriginalCommited = NfItem;
       _numeroDocImportacaoOriginalCommited = NumeroDocImportacao;
       _dataRegistroDiOriginalCommited = DataRegistroDi;
       _localDesembaracoOriginalCommited = LocalDesembaraco;
       _ufDesembaracoOriginalCommited = UfDesembaraco;
       _dataDesembaracoOriginalCommited = DataDesembaraco;
       _codigoExportadorOriginalCommited = CodigoExportador;
       _versionOriginalCommited = Version;
       _viaTransporteOriginalCommited = ViaTransporte;
       _valorAfrmmOriginalCommited = ValorAfrmm;
       _tipoIntermedioOriginalCommited = TipoIntermedio;
       _cnpjAdquirenteOriginalCommited = CnpjAdquirente;
       _ufTerceiroOriginalCommited = UfTerceiro;

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
               if (_valueCollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacaoLoaded) 
               {
                  if (_collectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacaoRemovidos != null) 
                  {
                     _collectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacaoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacaoRemovidos = new List<Entidades.NfProdutoDeclaracaoImportacaoAdicaoClass>();
                  }
                  _collectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacaoOriginal= (from a in _valueCollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacao select a.ID).ToList();
                  _valueCollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacaoChanged = false;
                  _valueCollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacaoCommitedChanged = false;
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
               NfItem=_nfItemOriginal;
               _nfItemOriginalCommited=_nfItemOriginal;
               NumeroDocImportacao=_numeroDocImportacaoOriginal;
               _numeroDocImportacaoOriginalCommited=_numeroDocImportacaoOriginal;
               DataRegistroDi=_dataRegistroDiOriginal;
               _dataRegistroDiOriginalCommited=_dataRegistroDiOriginal;
               LocalDesembaraco=_localDesembaracoOriginal;
               _localDesembaracoOriginalCommited=_localDesembaracoOriginal;
               UfDesembaraco=_ufDesembaracoOriginal;
               _ufDesembaracoOriginalCommited=_ufDesembaracoOriginal;
               DataDesembaraco=_dataDesembaracoOriginal;
               _dataDesembaracoOriginalCommited=_dataDesembaracoOriginal;
               CodigoExportador=_codigoExportadorOriginal;
               _codigoExportadorOriginalCommited=_codigoExportadorOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               ViaTransporte=_viaTransporteOriginal;
               _viaTransporteOriginalCommited=_viaTransporteOriginal;
               ValorAfrmm=_valorAfrmmOriginal;
               _valorAfrmmOriginalCommited=_valorAfrmmOriginal;
               TipoIntermedio=_tipoIntermedioOriginal;
               _tipoIntermedioOriginalCommited=_tipoIntermedioOriginal;
               CnpjAdquirente=_cnpjAdquirenteOriginal;
               _cnpjAdquirenteOriginalCommited=_cnpjAdquirenteOriginal;
               UfTerceiro=_ufTerceiroOriginal;
               _ufTerceiroOriginalCommited=_ufTerceiroOriginal;
               if (_valueCollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacaoLoaded) 
               {
                  CollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacao.Clear();
                  foreach(int item in _collectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacaoOriginal)
                  {
                    CollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacao.Add(Entidades.NfProdutoDeclaracaoImportacaoAdicaoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacaoRemovidos.Clear();
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
               if (_valueCollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacaoLoaded) 
               {
                  if (_valueCollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacaoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacaoLoaded) 
               {
                   tempRet = CollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacao.Any(item => item.IsDirty());
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
       if (_nfItemOriginal!=null)
       {
          dirty = !_nfItemOriginal.Equals(NfItem);
       }
       else
       {
            dirty = NfItem != null;
       }
      if (dirty) return true;
       dirty = _numeroDocImportacaoOriginal != NumeroDocImportacao;
      if (dirty) return true;
       dirty = _dataRegistroDiOriginal != DataRegistroDi;
      if (dirty) return true;
       dirty = _localDesembaracoOriginal != LocalDesembaraco;
      if (dirty) return true;
       dirty = _ufDesembaracoOriginal != UfDesembaraco;
      if (dirty) return true;
       dirty = _dataDesembaracoOriginal != DataDesembaraco;
      if (dirty) return true;
       dirty = _codigoExportadorOriginal != CodigoExportador;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _viaTransporteOriginal != ViaTransporte;
      if (dirty) return true;
       dirty = _valorAfrmmOriginal != ValorAfrmm;
      if (dirty) return true;
       dirty = _tipoIntermedioOriginal != TipoIntermedio;
      if (dirty) return true;
       dirty = _cnpjAdquirenteOriginal != CnpjAdquirente;
      if (dirty) return true;
       dirty = _ufTerceiroOriginal != UfTerceiro;

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
               if (_valueCollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacaoLoaded) 
               {
                  if (_valueCollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacaoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacaoLoaded) 
               {
                   tempRet = CollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacao.Any(item => item.IsDirtyCommited());
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
       if (_nfItemOriginalCommited!=null)
       {
          dirty = !_nfItemOriginalCommited.Equals(NfItem);
       }
       else
       {
            dirty = NfItem != null;
       }
      if (dirty) return true;
       dirty = _numeroDocImportacaoOriginalCommited != NumeroDocImportacao;
      if (dirty) return true;
       dirty = _dataRegistroDiOriginalCommited != DataRegistroDi;
      if (dirty) return true;
       dirty = _localDesembaracoOriginalCommited != LocalDesembaraco;
      if (dirty) return true;
       dirty = _ufDesembaracoOriginalCommited != UfDesembaraco;
      if (dirty) return true;
       dirty = _dataDesembaracoOriginalCommited != DataDesembaraco;
      if (dirty) return true;
       dirty = _codigoExportadorOriginalCommited != CodigoExportador;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _viaTransporteOriginalCommited != ViaTransporte;
      if (dirty) return true;
       dirty = _valorAfrmmOriginalCommited != ValorAfrmm;
      if (dirty) return true;
       dirty = _tipoIntermedioOriginalCommited != TipoIntermedio;
      if (dirty) return true;
       dirty = _cnpjAdquirenteOriginalCommited != CnpjAdquirente;
      if (dirty) return true;
       dirty = _ufTerceiroOriginalCommited != UfTerceiro;

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
               if (_valueCollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacaoLoaded) 
               {
                  foreach(NfProdutoDeclaracaoImportacaoAdicaoClass item in CollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacao)
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
             case "NfItem":
                return this.NfItem;
             case "NumeroDocImportacao":
                return this.NumeroDocImportacao;
             case "DataRegistroDi":
                return this.DataRegistroDi;
             case "LocalDesembaraco":
                return this.LocalDesembaraco;
             case "UfDesembaraco":
                return this.UfDesembaraco;
             case "DataDesembaraco":
                return this.DataDesembaraco;
             case "CodigoExportador":
                return this.CodigoExportador;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "ViaTransporte":
                return this.ViaTransporte;
             case "ValorAfrmm":
                return this.ValorAfrmm;
             case "TipoIntermedio":
                return this.TipoIntermedio;
             case "CnpjAdquirente":
                return this.CnpjAdquirente;
             case "UfTerceiro":
                return this.UfTerceiro;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (NfItem!=null)
                NfItem.ChangeSingleConnection(newConnection);
               if (_valueCollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacaoLoaded) 
               {
                  foreach(NfProdutoDeclaracaoImportacaoAdicaoClass item in CollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacao)
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
                  command.CommandText += " COUNT(nf_produto_declaracao_importacao.id_nf_produto_declaracao_importacao) " ;
               }
               else
               {
               command.CommandText += "nf_produto_declaracao_importacao.id_nf_produto_declaracao_importacao, " ;
               command.CommandText += "nf_produto_declaracao_importacao.id_nf_item, " ;
               command.CommandText += "nf_produto_declaracao_importacao.npd_numero_doc_importacao, " ;
               command.CommandText += "nf_produto_declaracao_importacao.npd_data_registro_di, " ;
               command.CommandText += "nf_produto_declaracao_importacao.npd_local_desembaraco, " ;
               command.CommandText += "nf_produto_declaracao_importacao.npd_uf_desembaraco, " ;
               command.CommandText += "nf_produto_declaracao_importacao.npd_data_desembaraco, " ;
               command.CommandText += "nf_produto_declaracao_importacao.npd_codigo_exportador, " ;
               command.CommandText += "nf_produto_declaracao_importacao.entity_uid, " ;
               command.CommandText += "nf_produto_declaracao_importacao.version, " ;
               command.CommandText += "nf_produto_declaracao_importacao.npd_via_transporte, " ;
               command.CommandText += "nf_produto_declaracao_importacao.npd_valor_afrmm, " ;
               command.CommandText += "nf_produto_declaracao_importacao.npd_tipo_intermedio, " ;
               command.CommandText += "nf_produto_declaracao_importacao.npd_cnpj_adquirente, " ;
               command.CommandText += "nf_produto_declaracao_importacao.npd_uf_terceiro " ;
               }
               command.CommandText += " FROM  nf_produto_declaracao_importacao ";
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
                        orderByClause += " , npd_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(npd_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = nf_produto_declaracao_importacao.id_acs_usuario_ultima_revisao ";
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
                     case "id_nf_produto_declaracao_importacao":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_declaracao_importacao.id_nf_produto_declaracao_importacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_declaracao_importacao.id_nf_produto_declaracao_importacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_nf_item":
                     case "NfItem":
                     orderByClause += " , nf_produto_declaracao_importacao.id_nf_item " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "npd_numero_doc_importacao":
                     case "NumeroDocImportacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto_declaracao_importacao.npd_numero_doc_importacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto_declaracao_importacao.npd_numero_doc_importacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npd_data_registro_di":
                     case "DataRegistroDi":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_declaracao_importacao.npd_data_registro_di " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_declaracao_importacao.npd_data_registro_di) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npd_local_desembaraco":
                     case "LocalDesembaraco":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto_declaracao_importacao.npd_local_desembaraco " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto_declaracao_importacao.npd_local_desembaraco) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npd_uf_desembaraco":
                     case "UfDesembaraco":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto_declaracao_importacao.npd_uf_desembaraco " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto_declaracao_importacao.npd_uf_desembaraco) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npd_data_desembaraco":
                     case "DataDesembaraco":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_declaracao_importacao.npd_data_desembaraco " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_declaracao_importacao.npd_data_desembaraco) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npd_codigo_exportador":
                     case "CodigoExportador":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto_declaracao_importacao.npd_codigo_exportador " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto_declaracao_importacao.npd_codigo_exportador) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto_declaracao_importacao.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto_declaracao_importacao.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , nf_produto_declaracao_importacao.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_declaracao_importacao.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npd_via_transporte":
                     case "ViaTransporte":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_declaracao_importacao.npd_via_transporte " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_declaracao_importacao.npd_via_transporte) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npd_valor_afrmm":
                     case "ValorAfrmm":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_declaracao_importacao.npd_valor_afrmm " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_declaracao_importacao.npd_valor_afrmm) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npd_tipo_intermedio":
                     case "TipoIntermedio":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_declaracao_importacao.npd_tipo_intermedio " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_declaracao_importacao.npd_tipo_intermedio) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npd_cnpj_adquirente":
                     case "CnpjAdquirente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto_declaracao_importacao.npd_cnpj_adquirente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto_declaracao_importacao.npd_cnpj_adquirente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npd_uf_terceiro":
                     case "UfTerceiro":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto_declaracao_importacao.npd_uf_terceiro " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto_declaracao_importacao.npd_uf_terceiro) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("npd_numero_doc_importacao")) 
                        {
                           whereClause += " OR UPPER(nf_produto_declaracao_importacao.npd_numero_doc_importacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto_declaracao_importacao.npd_numero_doc_importacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("npd_local_desembaraco")) 
                        {
                           whereClause += " OR UPPER(nf_produto_declaracao_importacao.npd_local_desembaraco) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto_declaracao_importacao.npd_local_desembaraco) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("npd_uf_desembaraco")) 
                        {
                           whereClause += " OR UPPER(nf_produto_declaracao_importacao.npd_uf_desembaraco) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto_declaracao_importacao.npd_uf_desembaraco) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("npd_codigo_exportador")) 
                        {
                           whereClause += " OR UPPER(nf_produto_declaracao_importacao.npd_codigo_exportador) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto_declaracao_importacao.npd_codigo_exportador) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(nf_produto_declaracao_importacao.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto_declaracao_importacao.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("npd_cnpj_adquirente")) 
                        {
                           whereClause += " OR UPPER(nf_produto_declaracao_importacao.npd_cnpj_adquirente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto_declaracao_importacao.npd_cnpj_adquirente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("npd_uf_terceiro")) 
                        {
                           whereClause += " OR UPPER(nf_produto_declaracao_importacao.npd_uf_terceiro) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto_declaracao_importacao.npd_uf_terceiro) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_nf_produto_declaracao_importacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_declaracao_importacao.id_nf_produto_declaracao_importacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_declaracao_importacao.id_nf_produto_declaracao_importacao = :nf_produto_declaracao_importacao_ID_3276 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_declaracao_importacao_ID_3276", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NfItem" || parametro.FieldName == "id_nf_item")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTNF.Entidades.Entidades.NfItemClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTNF.Entidades.Entidades.NfItemClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_declaracao_importacao.id_nf_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_declaracao_importacao.id_nf_item = :nf_produto_declaracao_importacao_NfItem_9201 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_declaracao_importacao_NfItem_9201", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroDocImportacao" || parametro.FieldName == "npd_numero_doc_importacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_declaracao_importacao.npd_numero_doc_importacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_declaracao_importacao.npd_numero_doc_importacao LIKE :nf_produto_declaracao_importacao_NumeroDocImportacao_6479 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_declaracao_importacao_NumeroDocImportacao_6479", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataRegistroDi" || parametro.FieldName == "npd_data_registro_di")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_declaracao_importacao.npd_data_registro_di IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_declaracao_importacao.npd_data_registro_di = :nf_produto_declaracao_importacao_DataRegistroDi_8358 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_declaracao_importacao_DataRegistroDi_8358", NpgsqlDbType.Date, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "LocalDesembaraco" || parametro.FieldName == "npd_local_desembaraco")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_declaracao_importacao.npd_local_desembaraco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_declaracao_importacao.npd_local_desembaraco LIKE :nf_produto_declaracao_importacao_LocalDesembaraco_3295 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_declaracao_importacao_LocalDesembaraco_3295", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UfDesembaraco" || parametro.FieldName == "npd_uf_desembaraco")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_declaracao_importacao.npd_uf_desembaraco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_declaracao_importacao.npd_uf_desembaraco LIKE :nf_produto_declaracao_importacao_UfDesembaraco_238 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_declaracao_importacao_UfDesembaraco_238", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataDesembaraco" || parametro.FieldName == "npd_data_desembaraco")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_declaracao_importacao.npd_data_desembaraco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_declaracao_importacao.npd_data_desembaraco = :nf_produto_declaracao_importacao_DataDesembaraco_5618 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_declaracao_importacao_DataDesembaraco_5618", NpgsqlDbType.Date, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoExportador" || parametro.FieldName == "npd_codigo_exportador")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_declaracao_importacao.npd_codigo_exportador IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_declaracao_importacao.npd_codigo_exportador LIKE :nf_produto_declaracao_importacao_CodigoExportador_6969 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_declaracao_importacao_CodigoExportador_6969", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  nf_produto_declaracao_importacao.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_declaracao_importacao.entity_uid LIKE :nf_produto_declaracao_importacao_EntityUid_8568 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_declaracao_importacao_EntityUid_8568", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  nf_produto_declaracao_importacao.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_declaracao_importacao.version = :nf_produto_declaracao_importacao_Version_4782 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_declaracao_importacao_Version_4782", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ViaTransporte" || parametro.FieldName == "npd_via_transporte")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_declaracao_importacao.npd_via_transporte IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_declaracao_importacao.npd_via_transporte = :nf_produto_declaracao_importacao_ViaTransporte_1854 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_declaracao_importacao_ViaTransporte_1854", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorAfrmm" || parametro.FieldName == "npd_valor_afrmm")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_declaracao_importacao.npd_valor_afrmm IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_declaracao_importacao.npd_valor_afrmm = :nf_produto_declaracao_importacao_ValorAfrmm_7121 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_declaracao_importacao_ValorAfrmm_7121", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoIntermedio" || parametro.FieldName == "npd_tipo_intermedio")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_declaracao_importacao.npd_tipo_intermedio IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_declaracao_importacao.npd_tipo_intermedio = :nf_produto_declaracao_importacao_TipoIntermedio_1286 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_declaracao_importacao_TipoIntermedio_1286", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CnpjAdquirente" || parametro.FieldName == "npd_cnpj_adquirente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_declaracao_importacao.npd_cnpj_adquirente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_declaracao_importacao.npd_cnpj_adquirente LIKE :nf_produto_declaracao_importacao_CnpjAdquirente_665 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_declaracao_importacao_CnpjAdquirente_665", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UfTerceiro" || parametro.FieldName == "npd_uf_terceiro")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_declaracao_importacao.npd_uf_terceiro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_declaracao_importacao.npd_uf_terceiro LIKE :nf_produto_declaracao_importacao_UfTerceiro_7802 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_declaracao_importacao_UfTerceiro_7802", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroDocImportacaoExato" || parametro.FieldName == "NumeroDocImportacaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_declaracao_importacao.npd_numero_doc_importacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_declaracao_importacao.npd_numero_doc_importacao LIKE :nf_produto_declaracao_importacao_NumeroDocImportacao_8812 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_declaracao_importacao_NumeroDocImportacao_8812", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "LocalDesembaracoExato" || parametro.FieldName == "LocalDesembaracoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_declaracao_importacao.npd_local_desembaraco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_declaracao_importacao.npd_local_desembaraco LIKE :nf_produto_declaracao_importacao_LocalDesembaraco_5731 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_declaracao_importacao_LocalDesembaraco_5731", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UfDesembaracoExato" || parametro.FieldName == "UfDesembaracoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_declaracao_importacao.npd_uf_desembaraco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_declaracao_importacao.npd_uf_desembaraco LIKE :nf_produto_declaracao_importacao_UfDesembaraco_866 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_declaracao_importacao_UfDesembaraco_866", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoExportadorExato" || parametro.FieldName == "CodigoExportadorExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_declaracao_importacao.npd_codigo_exportador IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_declaracao_importacao.npd_codigo_exportador LIKE :nf_produto_declaracao_importacao_CodigoExportador_3203 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_declaracao_importacao_CodigoExportador_3203", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nf_produto_declaracao_importacao.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_declaracao_importacao.entity_uid LIKE :nf_produto_declaracao_importacao_EntityUid_7086 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_declaracao_importacao_EntityUid_7086", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CnpjAdquirenteExato" || parametro.FieldName == "CnpjAdquirenteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_declaracao_importacao.npd_cnpj_adquirente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_declaracao_importacao.npd_cnpj_adquirente LIKE :nf_produto_declaracao_importacao_CnpjAdquirente_1420 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_declaracao_importacao_CnpjAdquirente_1420", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UfTerceiroExato" || parametro.FieldName == "UfTerceiroExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_declaracao_importacao.npd_uf_terceiro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_declaracao_importacao.npd_uf_terceiro LIKE :nf_produto_declaracao_importacao_UfTerceiro_9185 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_declaracao_importacao_UfTerceiro_9185", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  NfProdutoDeclaracaoImportacaoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (NfProdutoDeclaracaoImportacaoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(NfProdutoDeclaracaoImportacaoClass), Convert.ToInt32(read["id_nf_produto_declaracao_importacao"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new NfProdutoDeclaracaoImportacaoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_nf_produto_declaracao_importacao"]);
                     if (read["id_nf_item"] != DBNull.Value)
                     {
                        entidade.NfItem = (IWTNF.Entidades.Entidades.NfItemClass)IWTNF.Entidades.Entidades.NfItemClass.GetEntidade(Convert.ToInt32(read["id_nf_item"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.NfItem = null ;
                     }
                     entidade.NumeroDocImportacao = (read["npd_numero_doc_importacao"] != DBNull.Value ? read["npd_numero_doc_importacao"].ToString() : null);
                     entidade.DataRegistroDi = (DateTime)read["npd_data_registro_di"];
                     entidade.LocalDesembaraco = (read["npd_local_desembaraco"] != DBNull.Value ? read["npd_local_desembaraco"].ToString() : null);
                     entidade.UfDesembaraco = (read["npd_uf_desembaraco"] != DBNull.Value ? read["npd_uf_desembaraco"].ToString() : null);
                     entidade.DataDesembaraco = (DateTime)read["npd_data_desembaraco"];
                     entidade.CodigoExportador = (read["npd_codigo_exportador"] != DBNull.Value ? read["npd_codigo_exportador"].ToString() : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.ViaTransporte = (int)read["npd_via_transporte"];
                     entidade.ValorAfrmm = read["npd_valor_afrmm"] as double?;
                     entidade.TipoIntermedio = (int)read["npd_tipo_intermedio"];
                     entidade.CnpjAdquirente = (read["npd_cnpj_adquirente"] != DBNull.Value ? read["npd_cnpj_adquirente"].ToString() : null);
                     entidade.UfTerceiro = (read["npd_uf_terceiro"] != DBNull.Value ? read["npd_uf_terceiro"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (NfProdutoDeclaracaoImportacaoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
