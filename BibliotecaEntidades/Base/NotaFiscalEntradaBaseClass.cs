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
using IWTNF.Entidades.Entidades; 
namespace BibliotecaEntidades.Base 
{ 
    [Serializable()]
     [Table("nota_fiscal_entrada","nen")]
     public class NotaFiscalEntradaBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do NotaFiscalEntradaClass";
protected const string ErroDelete = "Erro ao excluir o NotaFiscalEntradaClass  ";
protected const string ErroSave = "Erro ao salvar o NotaFiscalEntradaClass.";
protected const string ErroCollectionContaPagarClassNotaFiscalEntrada = "Erro ao carregar a coleção de ContaPagarClass.";
protected const string ErroCollectionNotaFiscalEntradaLinhaClassNotaFiscalEntrada = "Erro ao carregar a coleção de NotaFiscalEntradaLinhaClass.";
protected const string ErroRazaoFornecedorObrigatorio = "O campo RazaoFornecedor é obrigatório";
protected const string ErroRazaoFornecedorComprimento = "O campo RazaoFornecedor deve ter no máximo 255 caracteres";
protected const string ErroNumeroNfObrigatorio = "O campo NumeroNf é obrigatório";
protected const string ErroNumeroNfComprimento = "O campo NumeroNf deve ter no máximo 255 caracteres";
protected const string ErroSerieNfObrigatorio = "O campo SerieNf é obrigatório";
protected const string ErroSerieNfComprimento = "O campo SerieNf deve ter no máximo 255 caracteres";
protected const string ErroNomeArquivoObrigatorio = "O campo NomeArquivo é obrigatório";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do NotaFiscalEntradaClass.";
protected const string MensagemUtilizadoCollectionContaPagarClassNotaFiscalEntrada =  "A entidade NotaFiscalEntradaClass está sendo utilizada nos seguintes ContaPagarClass:";
protected const string MensagemUtilizadoCollectionNotaFiscalEntradaLinhaClassNotaFiscalEntrada =  "A entidade NotaFiscalEntradaClass está sendo utilizada nos seguintes NotaFiscalEntradaLinhaClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade NotaFiscalEntradaClass está sendo utilizada.";
#endregion
       protected string _cnpjOriginal{get;private set;}
       private string _cnpjOriginalCommited{get; set;}
        private string _valueCnpj;
         [Column("nen_cnpj")]
        public virtual string Cnpj
         { 
            get { return this._valueCnpj; } 
            set 
            { 
                if (this._valueCnpj == value)return;
                 this._valueCnpj = value; 
            } 
        } 

       protected string _razaoFornecedorOriginal{get;private set;}
       private string _razaoFornecedorOriginalCommited{get; set;}
        private string _valueRazaoFornecedor;
         [Column("nen_razao_fornecedor")]
        public virtual string RazaoFornecedor
         { 
            get { return this._valueRazaoFornecedor; } 
            set 
            { 
                if (this._valueRazaoFornecedor == value)return;
                 this._valueRazaoFornecedor = value; 
            } 
        } 

       protected string _numeroNfOriginal{get;private set;}
       private string _numeroNfOriginalCommited{get; set;}
        private string _valueNumeroNf;
         [Column("nen_numero_nf")]
        public virtual string NumeroNf
         { 
            get { return this._valueNumeroNf; } 
            set 
            { 
                if (this._valueNumeroNf == value)return;
                 this._valueNumeroNf = value; 
            } 
        } 

       protected string _serieNfOriginal{get;private set;}
       private string _serieNfOriginalCommited{get; set;}
        private string _valueSerieNf;
         [Column("nen_serie_nf")]
        public virtual string SerieNf
         { 
            get { return this._valueSerieNf; } 
            set 
            { 
                if (this._valueSerieNf == value)return;
                 this._valueSerieNf = value; 
            } 
        } 

       protected DateTime _dataNfOriginal{get;private set;}
       private DateTime _dataNfOriginalCommited{get; set;}
        private DateTime _valueDataNf;
         [Column("nen_data_nf")]
        public virtual DateTime DataNf
         { 
            get { return this._valueDataNf; } 
            set 
            { 
                if (this._valueDataNf == value)return;
                 this._valueDataNf = value; 
            } 
        } 

       protected double _valorTotalOriginal{get;private set;}
       private double _valorTotalOriginalCommited{get; set;}
        private double _valueValorTotal;
         [Column("nen_valor_total")]
        public virtual double ValorTotal
         { 
            get { return this._valueValorTotal; } 
            set 
            { 
                if (this._valueValorTotal == value)return;
                 this._valueValorTotal = value; 
            } 
        } 

       protected string _nomeArquivoOriginal{get;private set;}
       private string _nomeArquivoOriginalCommited{get; set;}
        private string _valueNomeArquivo;
         [Column("nen_nome_arquivo")]
        public virtual string NomeArquivo
         { 
            get { return this._valueNomeArquivo; } 
            set 
            { 
                if (this._valueNomeArquivo == value)return;
                 this._valueNomeArquivo = value; 
            } 
        } 

       protected DateTime _dataImportacaoOriginal{get;private set;}
       private DateTime _dataImportacaoOriginalCommited{get; set;}
        private DateTime _valueDataImportacao;
         [Column("nen_data_importacao")]
        public virtual DateTime DataImportacao
         { 
            get { return this._valueDataImportacao; } 
            set 
            { 
                if (this._valueDataImportacao == value)return;
                 this._valueDataImportacao = value; 
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

       protected IWTNF.Entidades.Entidades.NfPrincipalClass _nfPrincipalOriginal{get;private set;}
       private IWTNF.Entidades.Entidades.NfPrincipalClass _nfPrincipalOriginalCommited {get; set;}
       private IWTNF.Entidades.Entidades.NfPrincipalClass _valueNfPrincipal;
        [Column("id_nf_principal", "nf_principal", "id_nf_principal")]
       public virtual IWTNF.Entidades.Entidades.NfPrincipalClass NfPrincipal
        { 
           get {                 return this._valueNfPrincipal; } 
           set 
           { 
                if (this._valueNfPrincipal == value)return;
                 this._valueNfPrincipal = value; 
           } 
       } 

       protected string _chaveNotaOriginal{get;private set;}
       private string _chaveNotaOriginalCommited{get; set;}
        private string _valueChaveNota;
         [Column("nen_chave_nota")]
        public virtual string ChaveNota
         { 
            get { return this._valueChaveNota; } 
            set 
            { 
                if (this._valueChaveNota == value)return;
                 this._valueChaveNota = value; 
            } 
        } 

       private List<long> _collectionContaPagarClassNotaFiscalEntradaOriginal;
       private List<Entidades.ContaPagarClass > _collectionContaPagarClassNotaFiscalEntradaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaPagarClassNotaFiscalEntradaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaPagarClassNotaFiscalEntradaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaPagarClassNotaFiscalEntradaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ContaPagarClass> _valueCollectionContaPagarClassNotaFiscalEntrada { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ContaPagarClass> CollectionContaPagarClassNotaFiscalEntrada 
       { 
           get { if(!_valueCollectionContaPagarClassNotaFiscalEntradaLoaded && !this.DisableLoadCollection){this.LoadCollectionContaPagarClassNotaFiscalEntrada();}
return this._valueCollectionContaPagarClassNotaFiscalEntrada; } 
           set 
           { 
               this._valueCollectionContaPagarClassNotaFiscalEntrada = value; 
               this._valueCollectionContaPagarClassNotaFiscalEntradaLoaded = true; 
           } 
       } 

       private List<long> _collectionNotaFiscalEntradaLinhaClassNotaFiscalEntradaOriginal;
       private List<Entidades.NotaFiscalEntradaLinhaClass > _collectionNotaFiscalEntradaLinhaClassNotaFiscalEntradaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNotaFiscalEntradaLinhaClassNotaFiscalEntradaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNotaFiscalEntradaLinhaClassNotaFiscalEntradaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNotaFiscalEntradaLinhaClassNotaFiscalEntradaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NotaFiscalEntradaLinhaClass> _valueCollectionNotaFiscalEntradaLinhaClassNotaFiscalEntrada { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NotaFiscalEntradaLinhaClass> CollectionNotaFiscalEntradaLinhaClassNotaFiscalEntrada 
       { 
           get { if(!_valueCollectionNotaFiscalEntradaLinhaClassNotaFiscalEntradaLoaded && !this.DisableLoadCollection){this.LoadCollectionNotaFiscalEntradaLinhaClassNotaFiscalEntrada();}
return this._valueCollectionNotaFiscalEntradaLinhaClassNotaFiscalEntrada; } 
           set 
           { 
               this._valueCollectionNotaFiscalEntradaLinhaClassNotaFiscalEntrada = value; 
               this._valueCollectionNotaFiscalEntradaLinhaClassNotaFiscalEntradaLoaded = true; 
           } 
       } 

        public NotaFiscalEntradaBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static NotaFiscalEntradaClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (NotaFiscalEntradaClass) GetEntity(typeof(NotaFiscalEntradaClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionContaPagarClassNotaFiscalEntradaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionContaPagarClassNotaFiscalEntradaChanged = true;
                  _valueCollectionContaPagarClassNotaFiscalEntradaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionContaPagarClassNotaFiscalEntradaChanged = true; 
                  _valueCollectionContaPagarClassNotaFiscalEntradaCommitedChanged = true;
                 foreach (Entidades.ContaPagarClass item in e.OldItems) 
                 { 
                     _collectionContaPagarClassNotaFiscalEntradaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionContaPagarClassNotaFiscalEntradaChanged = true; 
                  _valueCollectionContaPagarClassNotaFiscalEntradaCommitedChanged = true;
                 foreach (Entidades.ContaPagarClass item in _valueCollectionContaPagarClassNotaFiscalEntrada) 
                 { 
                     _collectionContaPagarClassNotaFiscalEntradaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionContaPagarClassNotaFiscalEntrada()
         {
            try
            {
                 ObservableCollection<Entidades.ContaPagarClass> oc;
                _valueCollectionContaPagarClassNotaFiscalEntradaChanged = false;
                 _valueCollectionContaPagarClassNotaFiscalEntradaCommitedChanged = false;
                _collectionContaPagarClassNotaFiscalEntradaRemovidos = new List<Entidades.ContaPagarClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ContaPagarClass>();
                }
                else{ 
                   Entidades.ContaPagarClass search = new Entidades.ContaPagarClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ContaPagarClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NotaFiscalEntrada", this),                     }                       ).Cast<Entidades.ContaPagarClass>().ToList());
                 }
                 _valueCollectionContaPagarClassNotaFiscalEntrada = new BindingList<Entidades.ContaPagarClass>(oc); 
                 _collectionContaPagarClassNotaFiscalEntradaOriginal= (from a in _valueCollectionContaPagarClassNotaFiscalEntrada select a.ID).ToList();
                 _valueCollectionContaPagarClassNotaFiscalEntradaLoaded = true;
                 oc.CollectionChanged += CollectionContaPagarClassNotaFiscalEntradaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionContaPagarClassNotaFiscalEntrada+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionNotaFiscalEntradaLinhaClassNotaFiscalEntradaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNotaFiscalEntradaLinhaClassNotaFiscalEntradaChanged = true;
                  _valueCollectionNotaFiscalEntradaLinhaClassNotaFiscalEntradaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNotaFiscalEntradaLinhaClassNotaFiscalEntradaChanged = true; 
                  _valueCollectionNotaFiscalEntradaLinhaClassNotaFiscalEntradaCommitedChanged = true;
                 foreach (Entidades.NotaFiscalEntradaLinhaClass item in e.OldItems) 
                 { 
                     _collectionNotaFiscalEntradaLinhaClassNotaFiscalEntradaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNotaFiscalEntradaLinhaClassNotaFiscalEntradaChanged = true; 
                  _valueCollectionNotaFiscalEntradaLinhaClassNotaFiscalEntradaCommitedChanged = true;
                 foreach (Entidades.NotaFiscalEntradaLinhaClass item in _valueCollectionNotaFiscalEntradaLinhaClassNotaFiscalEntrada) 
                 { 
                     _collectionNotaFiscalEntradaLinhaClassNotaFiscalEntradaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNotaFiscalEntradaLinhaClassNotaFiscalEntrada()
         {
            try
            {
                 ObservableCollection<Entidades.NotaFiscalEntradaLinhaClass> oc;
                _valueCollectionNotaFiscalEntradaLinhaClassNotaFiscalEntradaChanged = false;
                 _valueCollectionNotaFiscalEntradaLinhaClassNotaFiscalEntradaCommitedChanged = false;
                _collectionNotaFiscalEntradaLinhaClassNotaFiscalEntradaRemovidos = new List<Entidades.NotaFiscalEntradaLinhaClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NotaFiscalEntradaLinhaClass>();
                }
                else{ 
                   Entidades.NotaFiscalEntradaLinhaClass search = new Entidades.NotaFiscalEntradaLinhaClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NotaFiscalEntradaLinhaClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NotaFiscalEntrada", this),                     }                       ).Cast<Entidades.NotaFiscalEntradaLinhaClass>().ToList());
                 }
                 _valueCollectionNotaFiscalEntradaLinhaClassNotaFiscalEntrada = new BindingList<Entidades.NotaFiscalEntradaLinhaClass>(oc); 
                 _collectionNotaFiscalEntradaLinhaClassNotaFiscalEntradaOriginal= (from a in _valueCollectionNotaFiscalEntradaLinhaClassNotaFiscalEntrada select a.ID).ToList();
                 _valueCollectionNotaFiscalEntradaLinhaClassNotaFiscalEntradaLoaded = true;
                 oc.CollectionChanged += CollectionNotaFiscalEntradaLinhaClassNotaFiscalEntradaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNotaFiscalEntradaLinhaClassNotaFiscalEntrada+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(RazaoFornecedor))
                {
                    throw new Exception(ErroRazaoFornecedorObrigatorio);
                }
                if (RazaoFornecedor.Length >255)
                {
                    throw new Exception( ErroRazaoFornecedorComprimento);
                }
                if (string.IsNullOrEmpty(NumeroNf))
                {
                    throw new Exception(ErroNumeroNfObrigatorio);
                }
                if (NumeroNf.Length >255)
                {
                    throw new Exception( ErroNumeroNfComprimento);
                }
                if (string.IsNullOrEmpty(SerieNf))
                {
                    throw new Exception(ErroSerieNfObrigatorio);
                }
                if (SerieNf.Length >255)
                {
                    throw new Exception( ErroSerieNfComprimento);
                }
                if (string.IsNullOrEmpty(NomeArquivo))
                {
                    throw new Exception(ErroNomeArquivoObrigatorio);
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
                    "  public.nota_fiscal_entrada  " +
                    "WHERE " +
                    "  id_nota_fiscal_entrada = :id";
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
                        "  public.nota_fiscal_entrada   " +
                        "SET  " + 
                        "  nen_cnpj = :nen_cnpj, " + 
                        "  nen_razao_fornecedor = :nen_razao_fornecedor, " + 
                        "  nen_numero_nf = :nen_numero_nf, " + 
                        "  nen_serie_nf = :nen_serie_nf, " + 
                        "  nen_data_nf = :nen_data_nf, " + 
                        "  nen_valor_total = :nen_valor_total, " + 
                        "  nen_nome_arquivo = :nen_nome_arquivo, " + 
                        "  nen_data_importacao = :nen_data_importacao, " + 
                        "  id_fornecedor = :id_fornecedor, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  id_nf_principal = :id_nf_principal, " + 
                        "  nen_chave_nota = :nen_chave_nota "+
                        "WHERE  " +
                        "  id_nota_fiscal_entrada = :id " +
                        "RETURNING id_nota_fiscal_entrada;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.nota_fiscal_entrada " +
                        "( " +
                        "  nen_cnpj , " + 
                        "  nen_razao_fornecedor , " + 
                        "  nen_numero_nf , " + 
                        "  nen_serie_nf , " + 
                        "  nen_data_nf , " + 
                        "  nen_valor_total , " + 
                        "  nen_nome_arquivo , " + 
                        "  nen_data_importacao , " + 
                        "  id_fornecedor , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  id_nf_principal , " + 
                        "  nen_chave_nota  "+
                        ")  " +
                        "VALUES ( " +
                        "  :nen_cnpj , " + 
                        "  :nen_razao_fornecedor , " + 
                        "  :nen_numero_nf , " + 
                        "  :nen_serie_nf , " + 
                        "  :nen_data_nf , " + 
                        "  :nen_valor_total , " + 
                        "  :nen_nome_arquivo , " + 
                        "  :nen_data_importacao , " + 
                        "  :id_fornecedor , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :id_nf_principal , " + 
                        "  :nen_chave_nota  "+
                        ")RETURNING id_nota_fiscal_entrada;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nen_cnpj", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Cnpj ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nen_razao_fornecedor", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.RazaoFornecedor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nen_numero_nf", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NumeroNf ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nen_serie_nf", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.SerieNf ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nen_data_nf", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataNf ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nen_valor_total", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorTotal ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nen_nome_arquivo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NomeArquivo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nen_data_importacao", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataImportacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_fornecedor", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Fornecedor==null ? (object) DBNull.Value : this.Fornecedor.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nf_principal", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.NfPrincipal==null ? (object) DBNull.Value : this.NfPrincipal.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nen_chave_nota", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ChaveNota ?? DBNull.Value;

 
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
 if (CollectionContaPagarClassNotaFiscalEntrada.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionContaPagarClassNotaFiscalEntrada+"\r\n";
                foreach (Entidades.ContaPagarClass tmp in CollectionContaPagarClassNotaFiscalEntrada)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionNotaFiscalEntradaLinhaClassNotaFiscalEntrada.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNotaFiscalEntradaLinhaClassNotaFiscalEntrada+"\r\n";
                foreach (Entidades.NotaFiscalEntradaLinhaClass tmp in CollectionNotaFiscalEntradaLinhaClassNotaFiscalEntrada)
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
        public static NotaFiscalEntradaClass CopiarEntidade(NotaFiscalEntradaClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               NotaFiscalEntradaClass toRet = new NotaFiscalEntradaClass(usuario,conn);
 toRet.Cnpj= entidadeCopiar.Cnpj;
 toRet.RazaoFornecedor= entidadeCopiar.RazaoFornecedor;
 toRet.NumeroNf= entidadeCopiar.NumeroNf;
 toRet.SerieNf= entidadeCopiar.SerieNf;
 toRet.DataNf= entidadeCopiar.DataNf;
 toRet.ValorTotal= entidadeCopiar.ValorTotal;
 toRet.NomeArquivo= entidadeCopiar.NomeArquivo;
 toRet.DataImportacao= entidadeCopiar.DataImportacao;
 toRet.Fornecedor= entidadeCopiar.Fornecedor;
 toRet.NfPrincipal= entidadeCopiar.NfPrincipal;
 toRet.ChaveNota= entidadeCopiar.ChaveNota;

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
       _cnpjOriginal = Cnpj;
       _cnpjOriginalCommited = _cnpjOriginal;
       _razaoFornecedorOriginal = RazaoFornecedor;
       _razaoFornecedorOriginalCommited = _razaoFornecedorOriginal;
       _numeroNfOriginal = NumeroNf;
       _numeroNfOriginalCommited = _numeroNfOriginal;
       _serieNfOriginal = SerieNf;
       _serieNfOriginalCommited = _serieNfOriginal;
       _dataNfOriginal = DataNf;
       _dataNfOriginalCommited = _dataNfOriginal;
       _valorTotalOriginal = ValorTotal;
       _valorTotalOriginalCommited = _valorTotalOriginal;
       _nomeArquivoOriginal = NomeArquivo;
       _nomeArquivoOriginalCommited = _nomeArquivoOriginal;
       _dataImportacaoOriginal = DataImportacao;
       _dataImportacaoOriginalCommited = _dataImportacaoOriginal;
       _fornecedorOriginal = Fornecedor;
       _fornecedorOriginalCommited = _fornecedorOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _nfPrincipalOriginal = NfPrincipal;
       _nfPrincipalOriginalCommited = _nfPrincipalOriginal;
       _chaveNotaOriginal = ChaveNota;
       _chaveNotaOriginalCommited = _chaveNotaOriginal;

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
       _cnpjOriginalCommited = Cnpj;
       _razaoFornecedorOriginalCommited = RazaoFornecedor;
       _numeroNfOriginalCommited = NumeroNf;
       _serieNfOriginalCommited = SerieNf;
       _dataNfOriginalCommited = DataNf;
       _valorTotalOriginalCommited = ValorTotal;
       _nomeArquivoOriginalCommited = NomeArquivo;
       _dataImportacaoOriginalCommited = DataImportacao;
       _fornecedorOriginalCommited = Fornecedor;
       _versionOriginalCommited = Version;
       _nfPrincipalOriginalCommited = NfPrincipal;
       _chaveNotaOriginalCommited = ChaveNota;

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
               if (_valueCollectionContaPagarClassNotaFiscalEntradaLoaded) 
               {
                  if (_collectionContaPagarClassNotaFiscalEntradaRemovidos != null) 
                  {
                     _collectionContaPagarClassNotaFiscalEntradaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionContaPagarClassNotaFiscalEntradaRemovidos = new List<Entidades.ContaPagarClass>();
                  }
                  _collectionContaPagarClassNotaFiscalEntradaOriginal= (from a in _valueCollectionContaPagarClassNotaFiscalEntrada select a.ID).ToList();
                  _valueCollectionContaPagarClassNotaFiscalEntradaChanged = false;
                  _valueCollectionContaPagarClassNotaFiscalEntradaCommitedChanged = false;
               }
               if (_valueCollectionNotaFiscalEntradaLinhaClassNotaFiscalEntradaLoaded) 
               {
                  if (_collectionNotaFiscalEntradaLinhaClassNotaFiscalEntradaRemovidos != null) 
                  {
                     _collectionNotaFiscalEntradaLinhaClassNotaFiscalEntradaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNotaFiscalEntradaLinhaClassNotaFiscalEntradaRemovidos = new List<Entidades.NotaFiscalEntradaLinhaClass>();
                  }
                  _collectionNotaFiscalEntradaLinhaClassNotaFiscalEntradaOriginal= (from a in _valueCollectionNotaFiscalEntradaLinhaClassNotaFiscalEntrada select a.ID).ToList();
                  _valueCollectionNotaFiscalEntradaLinhaClassNotaFiscalEntradaChanged = false;
                  _valueCollectionNotaFiscalEntradaLinhaClassNotaFiscalEntradaCommitedChanged = false;
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
               Cnpj=_cnpjOriginal;
               _cnpjOriginalCommited=_cnpjOriginal;
               RazaoFornecedor=_razaoFornecedorOriginal;
               _razaoFornecedorOriginalCommited=_razaoFornecedorOriginal;
               NumeroNf=_numeroNfOriginal;
               _numeroNfOriginalCommited=_numeroNfOriginal;
               SerieNf=_serieNfOriginal;
               _serieNfOriginalCommited=_serieNfOriginal;
               DataNf=_dataNfOriginal;
               _dataNfOriginalCommited=_dataNfOriginal;
               ValorTotal=_valorTotalOriginal;
               _valorTotalOriginalCommited=_valorTotalOriginal;
               NomeArquivo=_nomeArquivoOriginal;
               _nomeArquivoOriginalCommited=_nomeArquivoOriginal;
               DataImportacao=_dataImportacaoOriginal;
               _dataImportacaoOriginalCommited=_dataImportacaoOriginal;
               Fornecedor=_fornecedorOriginal;
               _fornecedorOriginalCommited=_fornecedorOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               NfPrincipal=_nfPrincipalOriginal;
               _nfPrincipalOriginalCommited=_nfPrincipalOriginal;
               ChaveNota=_chaveNotaOriginal;
               _chaveNotaOriginalCommited=_chaveNotaOriginal;
               if (_valueCollectionContaPagarClassNotaFiscalEntradaLoaded) 
               {
                  CollectionContaPagarClassNotaFiscalEntrada.Clear();
                  foreach(int item in _collectionContaPagarClassNotaFiscalEntradaOriginal)
                  {
                    CollectionContaPagarClassNotaFiscalEntrada.Add(Entidades.ContaPagarClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionContaPagarClassNotaFiscalEntradaRemovidos.Clear();
               }
               if (_valueCollectionNotaFiscalEntradaLinhaClassNotaFiscalEntradaLoaded) 
               {
                  CollectionNotaFiscalEntradaLinhaClassNotaFiscalEntrada.Clear();
                  foreach(int item in _collectionNotaFiscalEntradaLinhaClassNotaFiscalEntradaOriginal)
                  {
                    CollectionNotaFiscalEntradaLinhaClassNotaFiscalEntrada.Add(Entidades.NotaFiscalEntradaLinhaClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNotaFiscalEntradaLinhaClassNotaFiscalEntradaRemovidos.Clear();
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
               if (_valueCollectionContaPagarClassNotaFiscalEntradaLoaded) 
               {
                  if (_valueCollectionContaPagarClassNotaFiscalEntradaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNotaFiscalEntradaLinhaClassNotaFiscalEntradaLoaded) 
               {
                  if (_valueCollectionNotaFiscalEntradaLinhaClassNotaFiscalEntradaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaPagarClassNotaFiscalEntradaLoaded) 
               {
                   tempRet = CollectionContaPagarClassNotaFiscalEntrada.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionNotaFiscalEntradaLinhaClassNotaFiscalEntradaLoaded) 
               {
                   tempRet = CollectionNotaFiscalEntradaLinhaClassNotaFiscalEntrada.Any(item => item.IsDirty());
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
       dirty = _cnpjOriginal != Cnpj;
      if (dirty) return true;
       dirty = _razaoFornecedorOriginal != RazaoFornecedor;
      if (dirty) return true;
       dirty = _numeroNfOriginal != NumeroNf;
      if (dirty) return true;
       dirty = _serieNfOriginal != SerieNf;
      if (dirty) return true;
       dirty = _dataNfOriginal != DataNf;
      if (dirty) return true;
       dirty = _valorTotalOriginal != ValorTotal;
      if (dirty) return true;
       dirty = _nomeArquivoOriginal != NomeArquivo;
      if (dirty) return true;
       dirty = _dataImportacaoOriginal != DataImportacao;
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
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       if (_nfPrincipalOriginal!=null)
       {
          dirty = !_nfPrincipalOriginal.Equals(NfPrincipal);
       }
       else
       {
            dirty = NfPrincipal != null;
       }
      if (dirty) return true;
       dirty = _chaveNotaOriginal != ChaveNota;

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
               if (_valueCollectionContaPagarClassNotaFiscalEntradaLoaded) 
               {
                  if (_valueCollectionContaPagarClassNotaFiscalEntradaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNotaFiscalEntradaLinhaClassNotaFiscalEntradaLoaded) 
               {
                  if (_valueCollectionNotaFiscalEntradaLinhaClassNotaFiscalEntradaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaPagarClassNotaFiscalEntradaLoaded) 
               {
                   tempRet = CollectionContaPagarClassNotaFiscalEntrada.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionNotaFiscalEntradaLinhaClassNotaFiscalEntradaLoaded) 
               {
                   tempRet = CollectionNotaFiscalEntradaLinhaClassNotaFiscalEntrada.Any(item => item.IsDirtyCommited());
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
       dirty = _cnpjOriginalCommited != Cnpj;
      if (dirty) return true;
       dirty = _razaoFornecedorOriginalCommited != RazaoFornecedor;
      if (dirty) return true;
       dirty = _numeroNfOriginalCommited != NumeroNf;
      if (dirty) return true;
       dirty = _serieNfOriginalCommited != SerieNf;
      if (dirty) return true;
       dirty = _dataNfOriginalCommited != DataNf;
      if (dirty) return true;
       dirty = _valorTotalOriginalCommited != ValorTotal;
      if (dirty) return true;
       dirty = _nomeArquivoOriginalCommited != NomeArquivo;
      if (dirty) return true;
       dirty = _dataImportacaoOriginalCommited != DataImportacao;
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
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       if (_nfPrincipalOriginalCommited!=null)
       {
          dirty = !_nfPrincipalOriginalCommited.Equals(NfPrincipal);
       }
       else
       {
            dirty = NfPrincipal != null;
       }
      if (dirty) return true;
       dirty = _chaveNotaOriginalCommited != ChaveNota;

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
               if (_valueCollectionContaPagarClassNotaFiscalEntradaLoaded) 
               {
                  foreach(ContaPagarClass item in CollectionContaPagarClassNotaFiscalEntrada)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionNotaFiscalEntradaLinhaClassNotaFiscalEntradaLoaded) 
               {
                  foreach(NotaFiscalEntradaLinhaClass item in CollectionNotaFiscalEntradaLinhaClassNotaFiscalEntrada)
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
             case "Cnpj":
                return this.Cnpj;
             case "RazaoFornecedor":
                return this.RazaoFornecedor;
             case "NumeroNf":
                return this.NumeroNf;
             case "SerieNf":
                return this.SerieNf;
             case "DataNf":
                return this.DataNf;
             case "ValorTotal":
                return this.ValorTotal;
             case "NomeArquivo":
                return this.NomeArquivo;
             case "DataImportacao":
                return this.DataImportacao;
             case "Fornecedor":
                return this.Fornecedor;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "NfPrincipal":
                return this.NfPrincipal;
             case "ChaveNota":
                return this.ChaveNota;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (Fornecedor!=null)
                Fornecedor.ChangeSingleConnection(newConnection);
             if (NfPrincipal!=null)
                NfPrincipal.ChangeSingleConnection(newConnection);
               if (_valueCollectionContaPagarClassNotaFiscalEntradaLoaded) 
               {
                  foreach(ContaPagarClass item in CollectionContaPagarClassNotaFiscalEntrada)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionNotaFiscalEntradaLinhaClassNotaFiscalEntradaLoaded) 
               {
                  foreach(NotaFiscalEntradaLinhaClass item in CollectionNotaFiscalEntradaLinhaClassNotaFiscalEntrada)
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
                  command.CommandText += " COUNT(nota_fiscal_entrada.id_nota_fiscal_entrada) " ;
               }
               else
               {
               command.CommandText += "nota_fiscal_entrada.id_nota_fiscal_entrada, " ;
               command.CommandText += "nota_fiscal_entrada.nen_cnpj, " ;
               command.CommandText += "nota_fiscal_entrada.nen_razao_fornecedor, " ;
               command.CommandText += "nota_fiscal_entrada.nen_numero_nf, " ;
               command.CommandText += "nota_fiscal_entrada.nen_serie_nf, " ;
               command.CommandText += "nota_fiscal_entrada.nen_data_nf, " ;
               command.CommandText += "nota_fiscal_entrada.nen_valor_total, " ;
               command.CommandText += "nota_fiscal_entrada.nen_nome_arquivo, " ;
               command.CommandText += "nota_fiscal_entrada.nen_data_importacao, " ;
               command.CommandText += "nota_fiscal_entrada.id_fornecedor, " ;
               command.CommandText += "nota_fiscal_entrada.entity_uid, " ;
               command.CommandText += "nota_fiscal_entrada.version, " ;
               command.CommandText += "nota_fiscal_entrada.id_nf_principal, " ;
               command.CommandText += "nota_fiscal_entrada.nen_chave_nota " ;
               }
               command.CommandText += " FROM  nota_fiscal_entrada ";
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
                        orderByClause += " , nen_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(nen_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = nota_fiscal_entrada.id_acs_usuario_ultima_revisao ";
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
                     case "id_nota_fiscal_entrada":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nota_fiscal_entrada.id_nota_fiscal_entrada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nota_fiscal_entrada.id_nota_fiscal_entrada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nen_cnpj":
                     case "Cnpj":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nota_fiscal_entrada.nen_cnpj " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nota_fiscal_entrada.nen_cnpj) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nen_razao_fornecedor":
                     case "RazaoFornecedor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nota_fiscal_entrada.nen_razao_fornecedor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nota_fiscal_entrada.nen_razao_fornecedor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nen_numero_nf":
                     case "NumeroNf":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nota_fiscal_entrada.nen_numero_nf " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nota_fiscal_entrada.nen_numero_nf) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nen_serie_nf":
                     case "SerieNf":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nota_fiscal_entrada.nen_serie_nf " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nota_fiscal_entrada.nen_serie_nf) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nen_data_nf":
                     case "DataNf":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nota_fiscal_entrada.nen_data_nf " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nota_fiscal_entrada.nen_data_nf) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nen_valor_total":
                     case "ValorTotal":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nota_fiscal_entrada.nen_valor_total " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nota_fiscal_entrada.nen_valor_total) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nen_nome_arquivo":
                     case "NomeArquivo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nota_fiscal_entrada.nen_nome_arquivo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nota_fiscal_entrada.nen_nome_arquivo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nen_data_importacao":
                     case "DataImportacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nota_fiscal_entrada.nen_data_importacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nota_fiscal_entrada.nen_data_importacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_fornecedor":
                     case "Fornecedor":
                     command.CommandText += " LEFT JOIN fornecedor as fornecedor_Fornecedor ON fornecedor_Fornecedor.id_fornecedor = nota_fiscal_entrada.id_fornecedor ";                     switch (parametro.TipoOrdenacao)
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
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nota_fiscal_entrada.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nota_fiscal_entrada.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , nota_fiscal_entrada.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nota_fiscal_entrada.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_nf_principal":
                     case "NfPrincipal":
                     orderByClause += " , nota_fiscal_entrada.id_nf_principal " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "nen_chave_nota":
                     case "ChaveNota":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nota_fiscal_entrada.nen_chave_nota " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nota_fiscal_entrada.nen_chave_nota) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nen_cnpj")) 
                        {
                           whereClause += " OR UPPER(nota_fiscal_entrada.nen_cnpj) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nota_fiscal_entrada.nen_cnpj) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nen_razao_fornecedor")) 
                        {
                           whereClause += " OR UPPER(nota_fiscal_entrada.nen_razao_fornecedor) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nota_fiscal_entrada.nen_razao_fornecedor) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nen_numero_nf")) 
                        {
                           whereClause += " OR UPPER(nota_fiscal_entrada.nen_numero_nf) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nota_fiscal_entrada.nen_numero_nf) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nen_serie_nf")) 
                        {
                           whereClause += " OR UPPER(nota_fiscal_entrada.nen_serie_nf) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nota_fiscal_entrada.nen_serie_nf) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nen_nome_arquivo")) 
                        {
                           whereClause += " OR UPPER(nota_fiscal_entrada.nen_nome_arquivo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nota_fiscal_entrada.nen_nome_arquivo) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(nota_fiscal_entrada.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nota_fiscal_entrada.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nen_chave_nota")) 
                        {
                           whereClause += " OR UPPER(nota_fiscal_entrada.nen_chave_nota) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nota_fiscal_entrada.nen_chave_nota) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_nota_fiscal_entrada")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nota_fiscal_entrada.id_nota_fiscal_entrada IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nota_fiscal_entrada.id_nota_fiscal_entrada = :nota_fiscal_entrada_ID_1156 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nota_fiscal_entrada_ID_1156", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cnpj" || parametro.FieldName == "nen_cnpj")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nota_fiscal_entrada.nen_cnpj IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nota_fiscal_entrada.nen_cnpj LIKE :nota_fiscal_entrada_Cnpj_3385 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nota_fiscal_entrada_Cnpj_3385", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RazaoFornecedor" || parametro.FieldName == "nen_razao_fornecedor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nota_fiscal_entrada.nen_razao_fornecedor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nota_fiscal_entrada.nen_razao_fornecedor LIKE :nota_fiscal_entrada_RazaoFornecedor_6216 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nota_fiscal_entrada_RazaoFornecedor_6216", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroNf" || parametro.FieldName == "nen_numero_nf")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nota_fiscal_entrada.nen_numero_nf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nota_fiscal_entrada.nen_numero_nf LIKE :nota_fiscal_entrada_NumeroNf_5645 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nota_fiscal_entrada_NumeroNf_5645", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SerieNf" || parametro.FieldName == "nen_serie_nf")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nota_fiscal_entrada.nen_serie_nf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nota_fiscal_entrada.nen_serie_nf LIKE :nota_fiscal_entrada_SerieNf_5804 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nota_fiscal_entrada_SerieNf_5804", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataNf" || parametro.FieldName == "nen_data_nf")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nota_fiscal_entrada.nen_data_nf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nota_fiscal_entrada.nen_data_nf = :nota_fiscal_entrada_DataNf_4513 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nota_fiscal_entrada_DataNf_4513", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorTotal" || parametro.FieldName == "nen_valor_total")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nota_fiscal_entrada.nen_valor_total IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nota_fiscal_entrada.nen_valor_total = :nota_fiscal_entrada_ValorTotal_2573 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nota_fiscal_entrada_ValorTotal_2573", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomeArquivo" || parametro.FieldName == "nen_nome_arquivo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nota_fiscal_entrada.nen_nome_arquivo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nota_fiscal_entrada.nen_nome_arquivo LIKE :nota_fiscal_entrada_NomeArquivo_761 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nota_fiscal_entrada_NomeArquivo_761", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataImportacao" || parametro.FieldName == "nen_data_importacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nota_fiscal_entrada.nen_data_importacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nota_fiscal_entrada.nen_data_importacao = :nota_fiscal_entrada_DataImportacao_5448 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nota_fiscal_entrada_DataImportacao_5448", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
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
                         whereClause += "  nota_fiscal_entrada.id_fornecedor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nota_fiscal_entrada.id_fornecedor = :nota_fiscal_entrada_Fornecedor_8153 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nota_fiscal_entrada_Fornecedor_8153", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  nota_fiscal_entrada.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nota_fiscal_entrada.entity_uid LIKE :nota_fiscal_entrada_EntityUid_4931 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nota_fiscal_entrada_EntityUid_4931", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  nota_fiscal_entrada.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nota_fiscal_entrada.version = :nota_fiscal_entrada_Version_9233 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nota_fiscal_entrada_Version_9233", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NfPrincipal" || parametro.FieldName == "id_nf_principal")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTNF.Entidades.Entidades.NfPrincipalClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTNF.Entidades.Entidades.NfPrincipalClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nota_fiscal_entrada.id_nf_principal IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nota_fiscal_entrada.id_nf_principal = :nota_fiscal_entrada_NfPrincipal_9815 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nota_fiscal_entrada_NfPrincipal_9815", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ChaveNota" || parametro.FieldName == "nen_chave_nota")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nota_fiscal_entrada.nen_chave_nota IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nota_fiscal_entrada.nen_chave_nota LIKE :nota_fiscal_entrada_ChaveNota_8098 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nota_fiscal_entrada_ChaveNota_8098", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CnpjExato" || parametro.FieldName == "CnpjExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nota_fiscal_entrada.nen_cnpj IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nota_fiscal_entrada.nen_cnpj LIKE :nota_fiscal_entrada_Cnpj_1206 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nota_fiscal_entrada_Cnpj_1206", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RazaoFornecedorExato" || parametro.FieldName == "RazaoFornecedorExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nota_fiscal_entrada.nen_razao_fornecedor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nota_fiscal_entrada.nen_razao_fornecedor LIKE :nota_fiscal_entrada_RazaoFornecedor_4469 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nota_fiscal_entrada_RazaoFornecedor_4469", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroNfExato" || parametro.FieldName == "NumeroNfExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nota_fiscal_entrada.nen_numero_nf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nota_fiscal_entrada.nen_numero_nf LIKE :nota_fiscal_entrada_NumeroNf_2981 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nota_fiscal_entrada_NumeroNf_2981", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SerieNfExato" || parametro.FieldName == "SerieNfExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nota_fiscal_entrada.nen_serie_nf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nota_fiscal_entrada.nen_serie_nf LIKE :nota_fiscal_entrada_SerieNf_4967 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nota_fiscal_entrada_SerieNf_4967", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomeArquivoExato" || parametro.FieldName == "NomeArquivoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nota_fiscal_entrada.nen_nome_arquivo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nota_fiscal_entrada.nen_nome_arquivo LIKE :nota_fiscal_entrada_NomeArquivo_5139 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nota_fiscal_entrada_NomeArquivo_5139", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nota_fiscal_entrada.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nota_fiscal_entrada.entity_uid LIKE :nota_fiscal_entrada_EntityUid_7880 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nota_fiscal_entrada_EntityUid_7880", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ChaveNotaExato" || parametro.FieldName == "ChaveNotaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nota_fiscal_entrada.nen_chave_nota IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nota_fiscal_entrada.nen_chave_nota LIKE :nota_fiscal_entrada_ChaveNota_1688 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nota_fiscal_entrada_ChaveNota_1688", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  NotaFiscalEntradaClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (NotaFiscalEntradaClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(NotaFiscalEntradaClass), Convert.ToInt32(read["id_nota_fiscal_entrada"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new NotaFiscalEntradaClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_nota_fiscal_entrada"]);
                     entidade.Cnpj = (read["nen_cnpj"] != DBNull.Value ? read["nen_cnpj"].ToString() : null);
                     entidade.RazaoFornecedor = (read["nen_razao_fornecedor"] != DBNull.Value ? read["nen_razao_fornecedor"].ToString() : null);
                     entidade.NumeroNf = (read["nen_numero_nf"] != DBNull.Value ? read["nen_numero_nf"].ToString() : null);
                     entidade.SerieNf = (read["nen_serie_nf"] != DBNull.Value ? read["nen_serie_nf"].ToString() : null);
                     entidade.DataNf = (DateTime)read["nen_data_nf"];
                     entidade.ValorTotal = (double)read["nen_valor_total"];
                     entidade.NomeArquivo = (read["nen_nome_arquivo"] != DBNull.Value ? read["nen_nome_arquivo"].ToString() : null);
                     entidade.DataImportacao = (DateTime)read["nen_data_importacao"];
                     if (read["id_fornecedor"] != DBNull.Value)
                     {
                        entidade.Fornecedor = (BibliotecaEntidades.Entidades.FornecedorClass)BibliotecaEntidades.Entidades.FornecedorClass.GetEntidade(Convert.ToInt32(read["id_fornecedor"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Fornecedor = null ;
                     }
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     if (read["id_nf_principal"] != DBNull.Value)
                     {
                        entidade.NfPrincipal = (IWTNF.Entidades.Entidades.NfPrincipalClass)IWTNF.Entidades.Entidades.NfPrincipalClass.GetEntidade(Convert.ToInt32(read["id_nf_principal"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.NfPrincipal = null ;
                     }
                     entidade.ChaveNota = (read["nen_chave_nota"] != DBNull.Value ? read["nen_chave_nota"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (NotaFiscalEntradaClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
