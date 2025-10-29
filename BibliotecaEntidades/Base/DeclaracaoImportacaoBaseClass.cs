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
     [Table("declaracao_importacao","dii")]
     public class DeclaracaoImportacaoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do DeclaracaoImportacaoClass";
protected const string ErroDelete = "Erro ao excluir o DeclaracaoImportacaoClass  ";
protected const string ErroSave = "Erro ao salvar o DeclaracaoImportacaoClass.";
protected const string ErroCollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacao = "Erro ao carregar a coleção de DeclaracaoImportacaoAdicaoClass.";
protected const string ErroNumeroObrigatorio = "O campo Numero é obrigatório";
protected const string ErroNumeroComprimento = "O campo Numero deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroLocalDesembaracoAduaneiroObrigatorio = "O campo LocalDesembaracoAduaneiro é obrigatório";
protected const string ErroFornecedorObrigatorio = "O campo Fornecedor é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do DeclaracaoImportacaoClass.";
protected const string MensagemUtilizadoCollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacao =  "A entidade DeclaracaoImportacaoClass está sendo utilizada nos seguintes DeclaracaoImportacaoAdicaoClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade DeclaracaoImportacaoClass está sendo utilizada.";
#endregion
       protected string _numeroOriginal{get;private set;}
       private string _numeroOriginalCommited{get; set;}
        private string _valueNumero;
         [Column("dii_numero")]
        public virtual string Numero
         { 
            get { return this._valueNumero; } 
            set 
            { 
                if (this._valueNumero == value)return;
                 this._valueNumero = value; 
            } 
        } 

       protected DateTime _dataRegistroOriginal{get;private set;}
       private DateTime _dataRegistroOriginalCommited{get; set;}
        private DateTime _valueDataRegistro;
         [Column("dii_data_registro")]
        public virtual DateTime DataRegistro
         { 
            get { return this._valueDataRegistro; } 
            set 
            { 
                if (this._valueDataRegistro == value)return;
                 this._valueDataRegistro = value; 
            } 
        } 

       protected double _valorMercadoriaOriginal{get;private set;}
       private double _valorMercadoriaOriginalCommited{get; set;}
        private double _valueValorMercadoria;
         [Column("dii_valor_mercadoria")]
        public virtual double ValorMercadoria
         { 
            get { return this._valueValorMercadoria; } 
            set 
            { 
                if (this._valueValorMercadoria == value)return;
                 this._valueValorMercadoria = value; 
            } 
        } 

       protected double _valorFreteOriginal{get;private set;}
       private double _valorFreteOriginalCommited{get; set;}
        private double _valueValorFrete;
         [Column("dii_valor_frete")]
        public virtual double ValorFrete
         { 
            get { return this._valueValorFrete; } 
            set 
            { 
                if (this._valueValorFrete == value)return;
                 this._valueValorFrete = value; 
            } 
        } 

       protected double _valorSeguroOriginal{get;private set;}
       private double _valorSeguroOriginalCommited{get; set;}
        private double _valueValorSeguro;
         [Column("dii_valor_seguro")]
        public virtual double ValorSeguro
         { 
            get { return this._valueValorSeguro; } 
            set 
            { 
                if (this._valueValorSeguro == value)return;
                 this._valueValorSeguro = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.LocalDesembaracoAduaneiroClass _localDesembaracoAduaneiroOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.LocalDesembaracoAduaneiroClass _localDesembaracoAduaneiroOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.LocalDesembaracoAduaneiroClass _valueLocalDesembaracoAduaneiro;
        [Column("id_local_desembaraco_aduaneiro", "local_desembaraco_aduaneiro", "id_local_desembaraco_aduaneiro")]
       public virtual BibliotecaEntidades.Entidades.LocalDesembaracoAduaneiroClass LocalDesembaracoAduaneiro
        { 
           get {                 return this._valueLocalDesembaracoAduaneiro; } 
           set 
           { 
                if (this._valueLocalDesembaracoAduaneiro == value)return;
                 this._valueLocalDesembaracoAduaneiro = value; 
           } 
       } 

       protected DateTime _dataDesembaracoOriginal{get;private set;}
       private DateTime _dataDesembaracoOriginalCommited{get; set;}
        private DateTime _valueDataDesembaraco;
         [Column("dii_data_desembaraco")]
        public virtual DateTime DataDesembaraco
         { 
            get { return this._valueDataDesembaraco; } 
            set 
            { 
                if (this._valueDataDesembaraco == value)return;
                 this._valueDataDesembaraco = value; 
            } 
        } 

       protected int? _qtdVolumesOriginal{get;private set;}
       private int? _qtdVolumesOriginalCommited{get; set;}
        private int? _valueQtdVolumes;
         [Column("dii_qtd_volumes")]
        public virtual int? QtdVolumes
         { 
            get { return this._valueQtdVolumes; } 
            set 
            { 
                if (this._valueQtdVolumes == value)return;
                 this._valueQtdVolumes = value; 
            } 
        } 

       protected string _especieVolumesOriginal{get;private set;}
       private string _especieVolumesOriginalCommited{get; set;}
        private string _valueEspecieVolumes;
         [Column("dii_especie_volumes")]
        public virtual string EspecieVolumes
         { 
            get { return this._valueEspecieVolumes; } 
            set 
            { 
                if (this._valueEspecieVolumes == value)return;
                 this._valueEspecieVolumes = value; 
            } 
        } 

       protected double? _pesoLiquidoOriginal{get;private set;}
       private double? _pesoLiquidoOriginalCommited{get; set;}
        private double? _valuePesoLiquido;
         [Column("dii_peso_liquido")]
        public virtual double? PesoLiquido
         { 
            get { return this._valuePesoLiquido; } 
            set 
            { 
                if (this._valuePesoLiquido == value)return;
                 this._valuePesoLiquido = value; 
            } 
        } 

       protected double? _pesoBrutoOriginal{get;private set;}
       private double? _pesoBrutoOriginalCommited{get; set;}
        private double? _valuePesoBruto;
         [Column("dii_peso_bruto")]
        public virtual double? PesoBruto
         { 
            get { return this._valuePesoBruto; } 
            set 
            { 
                if (this._valuePesoBruto == value)return;
                 this._valuePesoBruto = value; 
            } 
        } 

       protected double _cotacaoDolarOriginal{get;private set;}
       private double _cotacaoDolarOriginalCommited{get; set;}
        private double _valueCotacaoDolar;
         [Column("dii_cotacao_dolar")]
        public virtual double CotacaoDolar
         { 
            get { return this._valueCotacaoDolar; } 
            set 
            { 
                if (this._valueCotacaoDolar == value)return;
                 this._valueCotacaoDolar = value; 
            } 
        } 

       protected double _valorTotalDolarOriginal{get;private set;}
       private double _valorTotalDolarOriginalCommited{get; set;}
        private double _valueValorTotalDolar;
         [Column("dii_valor_total_dolar")]
        public virtual double ValorTotalDolar
         { 
            get { return this._valueValorTotalDolar; } 
            set 
            { 
                if (this._valueValorTotalDolar == value)return;
                 this._valueValorTotalDolar = value; 
            } 
        } 

       protected double _valorTotalReaisOriginal{get;private set;}
       private double _valorTotalReaisOriginalCommited{get; set;}
        private double _valueValorTotalReais;
         [Column("dii_valor_total_reais")]
        public virtual double ValorTotalReais
         { 
            get { return this._valueValorTotalReais; } 
            set 
            { 
                if (this._valueValorTotalReais == value)return;
                 this._valueValorTotalReais = value; 
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

       protected double _taxaSiscomexOriginal{get;private set;}
       private double _taxaSiscomexOriginalCommited{get; set;}
        private double _valueTaxaSiscomex;
         [Column("dii_taxa_siscomex")]
        public virtual double TaxaSiscomex
         { 
            get { return this._valueTaxaSiscomex; } 
            set 
            { 
                if (this._valueTaxaSiscomex == value)return;
                 this._valueTaxaSiscomex = value; 
            } 
        } 

       protected double _taxaAfrmmOriginal{get;private set;}
       private double _taxaAfrmmOriginalCommited{get; set;}
        private double _valueTaxaAfrmm;
         [Column("dii_taxa_afrmm")]
        public virtual double TaxaAfrmm
         { 
            get { return this._valueTaxaAfrmm; } 
            set 
            { 
                if (this._valueTaxaAfrmm == value)return;
                 this._valueTaxaAfrmm = value; 
            } 
        } 

       protected bool _nfGeradaOriginal{get;private set;}
       private bool _nfGeradaOriginalCommited{get; set;}
        private bool _valueNfGerada;
         [Column("dii_nf_gerada")]
        public virtual bool NfGerada
         { 
            get { return this._valueNfGerada; } 
            set 
            { 
                if (this._valueNfGerada == value)return;
                 this._valueNfGerada = value; 
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

       private List<long> _collectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacaoOriginal;
       private List<Entidades.DeclaracaoImportacaoAdicaoClass > _collectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacaoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacaoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacaoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacaoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.DeclaracaoImportacaoAdicaoClass> _valueCollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacao { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.DeclaracaoImportacaoAdicaoClass> CollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacao 
       { 
           get { if(!_valueCollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacaoLoaded && !this.DisableLoadCollection){this.LoadCollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacao();}
return this._valueCollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacao; } 
           set 
           { 
               this._valueCollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacao = value; 
               this._valueCollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacaoLoaded = true; 
           } 
       } 

        public DeclaracaoImportacaoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.ValorMercadoria = 0;
           this.ValorFrete = 0;
           this.ValorSeguro = 0;
           this.CotacaoDolar = 0;
           this.ValorTotalDolar = 0;
           this.ValorTotalReais = 0;
           this.TaxaSiscomex = 0;
           this.TaxaAfrmm = 0;
           this.NfGerada = false;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static DeclaracaoImportacaoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (DeclaracaoImportacaoClass) GetEntity(typeof(DeclaracaoImportacaoClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacaoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacaoChanged = true;
                  _valueCollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacaoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacaoChanged = true; 
                  _valueCollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacaoCommitedChanged = true;
                 foreach (Entidades.DeclaracaoImportacaoAdicaoClass item in e.OldItems) 
                 { 
                     _collectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacaoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacaoChanged = true; 
                  _valueCollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacaoCommitedChanged = true;
                 foreach (Entidades.DeclaracaoImportacaoAdicaoClass item in _valueCollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacao) 
                 { 
                     _collectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacaoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacao()
         {
            try
            {
                 ObservableCollection<Entidades.DeclaracaoImportacaoAdicaoClass> oc;
                _valueCollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacaoChanged = false;
                 _valueCollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacaoCommitedChanged = false;
                _collectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacaoRemovidos = new List<Entidades.DeclaracaoImportacaoAdicaoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.DeclaracaoImportacaoAdicaoClass>();
                }
                else{ 
                   Entidades.DeclaracaoImportacaoAdicaoClass search = new Entidades.DeclaracaoImportacaoAdicaoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.DeclaracaoImportacaoAdicaoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("DeclaracaoImportacao", this)                    }                       ).Cast<Entidades.DeclaracaoImportacaoAdicaoClass>().ToList());
                 }
                 _valueCollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacao = new BindingList<Entidades.DeclaracaoImportacaoAdicaoClass>(oc); 
                 _collectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacaoOriginal= (from a in _valueCollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacao select a.ID).ToList();
                 _valueCollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacaoLoaded = true;
                 oc.CollectionChanged += CollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacaoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacao+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Numero))
                {
                    throw new Exception(ErroNumeroObrigatorio);
                }
                if (Numero.Length >255)
                {
                    throw new Exception( ErroNumeroComprimento);
                }
                if ( _valueLocalDesembaracoAduaneiro == null)
                {
                    throw new Exception(ErroLocalDesembaracoAduaneiroObrigatorio);
                }
                if ( _valueFornecedor == null)
                {
                    throw new Exception(ErroFornecedorObrigatorio);
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
                    "  public.declaracao_importacao  " +
                    "WHERE " +
                    "  id_declaracao_importacao = :id";
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
                        "  public.declaracao_importacao   " +
                        "SET  " + 
                        "  dii_numero = :dii_numero, " + 
                        "  dii_data_registro = :dii_data_registro, " + 
                        "  dii_valor_mercadoria = :dii_valor_mercadoria, " + 
                        "  dii_valor_frete = :dii_valor_frete, " + 
                        "  dii_valor_seguro = :dii_valor_seguro, " + 
                        "  id_local_desembaraco_aduaneiro = :id_local_desembaraco_aduaneiro, " + 
                        "  dii_data_desembaraco = :dii_data_desembaraco, " + 
                        "  dii_qtd_volumes = :dii_qtd_volumes, " + 
                        "  dii_especie_volumes = :dii_especie_volumes, " + 
                        "  dii_peso_liquido = :dii_peso_liquido, " + 
                        "  dii_peso_bruto = :dii_peso_bruto, " + 
                        "  version = :version, " + 
                        "  dii_cotacao_dolar = :dii_cotacao_dolar, " + 
                        "  dii_valor_total_dolar = :dii_valor_total_dolar, " + 
                        "  dii_valor_total_reais = :dii_valor_total_reais, " + 
                        "  id_fornecedor = :id_fornecedor, " + 
                        "  dii_taxa_siscomex = :dii_taxa_siscomex, " + 
                        "  dii_taxa_afrmm = :dii_taxa_afrmm, " + 
                        "  dii_nf_gerada = :dii_nf_gerada, " + 
                        "  id_nf_principal = :id_nf_principal, " + 
                        "  entity_uid = :entity_uid "+
                        "WHERE  " +
                        "  id_declaracao_importacao = :id " +
                        "RETURNING id_declaracao_importacao;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.declaracao_importacao " +
                        "( " +
                        "  dii_numero , " + 
                        "  dii_data_registro , " + 
                        "  dii_valor_mercadoria , " + 
                        "  dii_valor_frete , " + 
                        "  dii_valor_seguro , " + 
                        "  id_local_desembaraco_aduaneiro , " + 
                        "  dii_data_desembaraco , " + 
                        "  dii_qtd_volumes , " + 
                        "  dii_especie_volumes , " + 
                        "  dii_peso_liquido , " + 
                        "  dii_peso_bruto , " + 
                        "  version , " + 
                        "  dii_cotacao_dolar , " + 
                        "  dii_valor_total_dolar , " + 
                        "  dii_valor_total_reais , " + 
                        "  id_fornecedor , " + 
                        "  dii_taxa_siscomex , " + 
                        "  dii_taxa_afrmm , " + 
                        "  dii_nf_gerada , " + 
                        "  id_nf_principal , " + 
                        "  entity_uid  "+
                        ")  " +
                        "VALUES ( " +
                        "  :dii_numero , " + 
                        "  :dii_data_registro , " + 
                        "  :dii_valor_mercadoria , " + 
                        "  :dii_valor_frete , " + 
                        "  :dii_valor_seguro , " + 
                        "  :id_local_desembaraco_aduaneiro , " + 
                        "  :dii_data_desembaraco , " + 
                        "  :dii_qtd_volumes , " + 
                        "  :dii_especie_volumes , " + 
                        "  :dii_peso_liquido , " + 
                        "  :dii_peso_bruto , " + 
                        "  :version , " + 
                        "  :dii_cotacao_dolar , " + 
                        "  :dii_valor_total_dolar , " + 
                        "  :dii_valor_total_reais , " + 
                        "  :id_fornecedor , " + 
                        "  :dii_taxa_siscomex , " + 
                        "  :dii_taxa_afrmm , " + 
                        "  :dii_nf_gerada , " + 
                        "  :id_nf_principal , " + 
                        "  :entity_uid  "+
                        ")RETURNING id_declaracao_importacao;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dii_numero", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Numero ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dii_data_registro", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataRegistro ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dii_valor_mercadoria", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorMercadoria ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dii_valor_frete", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorFrete ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dii_valor_seguro", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorSeguro ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_local_desembaraco_aduaneiro", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.LocalDesembaracoAduaneiro==null ? (object) DBNull.Value : this.LocalDesembaracoAduaneiro.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dii_data_desembaraco", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataDesembaraco ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dii_qtd_volumes", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.QtdVolumes ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dii_especie_volumes", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EspecieVolumes ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dii_peso_liquido", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PesoLiquido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dii_peso_bruto", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PesoBruto ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dii_cotacao_dolar", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CotacaoDolar ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dii_valor_total_dolar", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorTotalDolar ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dii_valor_total_reais", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorTotalReais ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_fornecedor", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Fornecedor==null ? (object) DBNull.Value : this.Fornecedor.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dii_taxa_siscomex", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.TaxaSiscomex ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dii_taxa_afrmm", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.TaxaAfrmm ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dii_nf_gerada", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NfGerada ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nf_principal", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.NfPrincipal==null ? (object) DBNull.Value : this.NfPrincipal.ID;
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
 if (CollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacao.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacao+"\r\n";
                foreach (Entidades.DeclaracaoImportacaoAdicaoClass tmp in CollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacao)
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
        public static DeclaracaoImportacaoClass CopiarEntidade(DeclaracaoImportacaoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               DeclaracaoImportacaoClass toRet = new DeclaracaoImportacaoClass(usuario,conn);
 toRet.Numero= entidadeCopiar.Numero;
 toRet.DataRegistro= entidadeCopiar.DataRegistro;
 toRet.ValorMercadoria= entidadeCopiar.ValorMercadoria;
 toRet.ValorFrete= entidadeCopiar.ValorFrete;
 toRet.ValorSeguro= entidadeCopiar.ValorSeguro;
 toRet.LocalDesembaracoAduaneiro= entidadeCopiar.LocalDesembaracoAduaneiro;
 toRet.DataDesembaraco= entidadeCopiar.DataDesembaraco;
 toRet.QtdVolumes= entidadeCopiar.QtdVolumes;
 toRet.EspecieVolumes= entidadeCopiar.EspecieVolumes;
 toRet.PesoLiquido= entidadeCopiar.PesoLiquido;
 toRet.PesoBruto= entidadeCopiar.PesoBruto;
 toRet.CotacaoDolar= entidadeCopiar.CotacaoDolar;
 toRet.ValorTotalDolar= entidadeCopiar.ValorTotalDolar;
 toRet.ValorTotalReais= entidadeCopiar.ValorTotalReais;
 toRet.Fornecedor= entidadeCopiar.Fornecedor;
 toRet.TaxaSiscomex= entidadeCopiar.TaxaSiscomex;
 toRet.TaxaAfrmm= entidadeCopiar.TaxaAfrmm;
 toRet.NfGerada= entidadeCopiar.NfGerada;
 toRet.NfPrincipal= entidadeCopiar.NfPrincipal;

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
       _numeroOriginal = Numero;
       _numeroOriginalCommited = _numeroOriginal;
       _dataRegistroOriginal = DataRegistro;
       _dataRegistroOriginalCommited = _dataRegistroOriginal;
       _valorMercadoriaOriginal = ValorMercadoria;
       _valorMercadoriaOriginalCommited = _valorMercadoriaOriginal;
       _valorFreteOriginal = ValorFrete;
       _valorFreteOriginalCommited = _valorFreteOriginal;
       _valorSeguroOriginal = ValorSeguro;
       _valorSeguroOriginalCommited = _valorSeguroOriginal;
       _localDesembaracoAduaneiroOriginal = LocalDesembaracoAduaneiro;
       _localDesembaracoAduaneiroOriginalCommited = _localDesembaracoAduaneiroOriginal;
       _dataDesembaracoOriginal = DataDesembaraco;
       _dataDesembaracoOriginalCommited = _dataDesembaracoOriginal;
       _qtdVolumesOriginal = QtdVolumes;
       _qtdVolumesOriginalCommited = _qtdVolumesOriginal;
       _especieVolumesOriginal = EspecieVolumes;
       _especieVolumesOriginalCommited = _especieVolumesOriginal;
       _pesoLiquidoOriginal = PesoLiquido;
       _pesoLiquidoOriginalCommited = _pesoLiquidoOriginal;
       _pesoBrutoOriginal = PesoBruto;
       _pesoBrutoOriginalCommited = _pesoBrutoOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _cotacaoDolarOriginal = CotacaoDolar;
       _cotacaoDolarOriginalCommited = _cotacaoDolarOriginal;
       _valorTotalDolarOriginal = ValorTotalDolar;
       _valorTotalDolarOriginalCommited = _valorTotalDolarOriginal;
       _valorTotalReaisOriginal = ValorTotalReais;
       _valorTotalReaisOriginalCommited = _valorTotalReaisOriginal;
       _fornecedorOriginal = Fornecedor;
       _fornecedorOriginalCommited = _fornecedorOriginal;
       _taxaSiscomexOriginal = TaxaSiscomex;
       _taxaSiscomexOriginalCommited = _taxaSiscomexOriginal;
       _taxaAfrmmOriginal = TaxaAfrmm;
       _taxaAfrmmOriginalCommited = _taxaAfrmmOriginal;
       _nfGeradaOriginal = NfGerada;
       _nfGeradaOriginalCommited = _nfGeradaOriginal;
       _nfPrincipalOriginal = NfPrincipal;
       _nfPrincipalOriginalCommited = _nfPrincipalOriginal;

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
       _numeroOriginalCommited = Numero;
       _dataRegistroOriginalCommited = DataRegistro;
       _valorMercadoriaOriginalCommited = ValorMercadoria;
       _valorFreteOriginalCommited = ValorFrete;
       _valorSeguroOriginalCommited = ValorSeguro;
       _localDesembaracoAduaneiroOriginalCommited = LocalDesembaracoAduaneiro;
       _dataDesembaracoOriginalCommited = DataDesembaraco;
       _qtdVolumesOriginalCommited = QtdVolumes;
       _especieVolumesOriginalCommited = EspecieVolumes;
       _pesoLiquidoOriginalCommited = PesoLiquido;
       _pesoBrutoOriginalCommited = PesoBruto;
       _versionOriginalCommited = Version;
       _cotacaoDolarOriginalCommited = CotacaoDolar;
       _valorTotalDolarOriginalCommited = ValorTotalDolar;
       _valorTotalReaisOriginalCommited = ValorTotalReais;
       _fornecedorOriginalCommited = Fornecedor;
       _taxaSiscomexOriginalCommited = TaxaSiscomex;
       _taxaAfrmmOriginalCommited = TaxaAfrmm;
       _nfGeradaOriginalCommited = NfGerada;
       _nfPrincipalOriginalCommited = NfPrincipal;

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
               if (_valueCollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacaoLoaded) 
               {
                  if (_collectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacaoRemovidos != null) 
                  {
                     _collectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacaoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacaoRemovidos = new List<Entidades.DeclaracaoImportacaoAdicaoClass>();
                  }
                  _collectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacaoOriginal= (from a in _valueCollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacao select a.ID).ToList();
                  _valueCollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacaoChanged = false;
                  _valueCollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacaoCommitedChanged = false;
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
               Numero=_numeroOriginal;
               _numeroOriginalCommited=_numeroOriginal;
               DataRegistro=_dataRegistroOriginal;
               _dataRegistroOriginalCommited=_dataRegistroOriginal;
               ValorMercadoria=_valorMercadoriaOriginal;
               _valorMercadoriaOriginalCommited=_valorMercadoriaOriginal;
               ValorFrete=_valorFreteOriginal;
               _valorFreteOriginalCommited=_valorFreteOriginal;
               ValorSeguro=_valorSeguroOriginal;
               _valorSeguroOriginalCommited=_valorSeguroOriginal;
               LocalDesembaracoAduaneiro=_localDesembaracoAduaneiroOriginal;
               _localDesembaracoAduaneiroOriginalCommited=_localDesembaracoAduaneiroOriginal;
               DataDesembaraco=_dataDesembaracoOriginal;
               _dataDesembaracoOriginalCommited=_dataDesembaracoOriginal;
               QtdVolumes=_qtdVolumesOriginal;
               _qtdVolumesOriginalCommited=_qtdVolumesOriginal;
               EspecieVolumes=_especieVolumesOriginal;
               _especieVolumesOriginalCommited=_especieVolumesOriginal;
               PesoLiquido=_pesoLiquidoOriginal;
               _pesoLiquidoOriginalCommited=_pesoLiquidoOriginal;
               PesoBruto=_pesoBrutoOriginal;
               _pesoBrutoOriginalCommited=_pesoBrutoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               CotacaoDolar=_cotacaoDolarOriginal;
               _cotacaoDolarOriginalCommited=_cotacaoDolarOriginal;
               ValorTotalDolar=_valorTotalDolarOriginal;
               _valorTotalDolarOriginalCommited=_valorTotalDolarOriginal;
               ValorTotalReais=_valorTotalReaisOriginal;
               _valorTotalReaisOriginalCommited=_valorTotalReaisOriginal;
               Fornecedor=_fornecedorOriginal;
               _fornecedorOriginalCommited=_fornecedorOriginal;
               TaxaSiscomex=_taxaSiscomexOriginal;
               _taxaSiscomexOriginalCommited=_taxaSiscomexOriginal;
               TaxaAfrmm=_taxaAfrmmOriginal;
               _taxaAfrmmOriginalCommited=_taxaAfrmmOriginal;
               NfGerada=_nfGeradaOriginal;
               _nfGeradaOriginalCommited=_nfGeradaOriginal;
               NfPrincipal=_nfPrincipalOriginal;
               _nfPrincipalOriginalCommited=_nfPrincipalOriginal;
               if (_valueCollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacaoLoaded) 
               {
                  CollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacao.Clear();
                  foreach(int item in _collectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacaoOriginal)
                  {
                    CollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacao.Add(Entidades.DeclaracaoImportacaoAdicaoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacaoRemovidos.Clear();
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
               if (_valueCollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacaoLoaded) 
               {
                  if (_valueCollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacaoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacaoLoaded) 
               {
                   tempRet = CollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacao.Any(item => item.IsDirty());
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
       dirty = _numeroOriginal != Numero;
      if (dirty) return true;
       dirty = _dataRegistroOriginal != DataRegistro;
      if (dirty) return true;
       dirty = _valorMercadoriaOriginal != ValorMercadoria;
      if (dirty) return true;
       dirty = _valorFreteOriginal != ValorFrete;
      if (dirty) return true;
       dirty = _valorSeguroOriginal != ValorSeguro;
      if (dirty) return true;
       if (_localDesembaracoAduaneiroOriginal!=null)
       {
          dirty = !_localDesembaracoAduaneiroOriginal.Equals(LocalDesembaracoAduaneiro);
       }
       else
       {
            dirty = LocalDesembaracoAduaneiro != null;
       }
      if (dirty) return true;
       dirty = _dataDesembaracoOriginal != DataDesembaraco;
      if (dirty) return true;
       dirty = _qtdVolumesOriginal != QtdVolumes;
      if (dirty) return true;
       dirty = _especieVolumesOriginal != EspecieVolumes;
      if (dirty) return true;
       dirty = _pesoLiquidoOriginal != PesoLiquido;
      if (dirty) return true;
       dirty = _pesoBrutoOriginal != PesoBruto;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _cotacaoDolarOriginal != CotacaoDolar;
      if (dirty) return true;
       dirty = _valorTotalDolarOriginal != ValorTotalDolar;
      if (dirty) return true;
       dirty = _valorTotalReaisOriginal != ValorTotalReais;
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
       dirty = _taxaSiscomexOriginal != TaxaSiscomex;
      if (dirty) return true;
       dirty = _taxaAfrmmOriginal != TaxaAfrmm;
      if (dirty) return true;
       dirty = _nfGeradaOriginal != NfGerada;
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
               if (_valueCollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacaoLoaded) 
               {
                  if (_valueCollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacaoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacaoLoaded) 
               {
                   tempRet = CollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacao.Any(item => item.IsDirtyCommited());
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
       dirty = _numeroOriginalCommited != Numero;
      if (dirty) return true;
       dirty = _dataRegistroOriginalCommited != DataRegistro;
      if (dirty) return true;
       dirty = _valorMercadoriaOriginalCommited != ValorMercadoria;
      if (dirty) return true;
       dirty = _valorFreteOriginalCommited != ValorFrete;
      if (dirty) return true;
       dirty = _valorSeguroOriginalCommited != ValorSeguro;
      if (dirty) return true;
       if (_localDesembaracoAduaneiroOriginalCommited!=null)
       {
          dirty = !_localDesembaracoAduaneiroOriginalCommited.Equals(LocalDesembaracoAduaneiro);
       }
       else
       {
            dirty = LocalDesembaracoAduaneiro != null;
       }
      if (dirty) return true;
       dirty = _dataDesembaracoOriginalCommited != DataDesembaraco;
      if (dirty) return true;
       dirty = _qtdVolumesOriginalCommited != QtdVolumes;
      if (dirty) return true;
       dirty = _especieVolumesOriginalCommited != EspecieVolumes;
      if (dirty) return true;
       dirty = _pesoLiquidoOriginalCommited != PesoLiquido;
      if (dirty) return true;
       dirty = _pesoBrutoOriginalCommited != PesoBruto;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _cotacaoDolarOriginalCommited != CotacaoDolar;
      if (dirty) return true;
       dirty = _valorTotalDolarOriginalCommited != ValorTotalDolar;
      if (dirty) return true;
       dirty = _valorTotalReaisOriginalCommited != ValorTotalReais;
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
       dirty = _taxaSiscomexOriginalCommited != TaxaSiscomex;
      if (dirty) return true;
       dirty = _taxaAfrmmOriginalCommited != TaxaAfrmm;
      if (dirty) return true;
       dirty = _nfGeradaOriginalCommited != NfGerada;
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
               if (_valueCollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacaoLoaded) 
               {
                  foreach(DeclaracaoImportacaoAdicaoClass item in CollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacao)
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
             case "Numero":
                return this.Numero;
             case "DataRegistro":
                return this.DataRegistro;
             case "ValorMercadoria":
                return this.ValorMercadoria;
             case "ValorFrete":
                return this.ValorFrete;
             case "ValorSeguro":
                return this.ValorSeguro;
             case "LocalDesembaracoAduaneiro":
                return this.LocalDesembaracoAduaneiro;
             case "DataDesembaraco":
                return this.DataDesembaraco;
             case "QtdVolumes":
                return this.QtdVolumes;
             case "EspecieVolumes":
                return this.EspecieVolumes;
             case "PesoLiquido":
                return this.PesoLiquido;
             case "PesoBruto":
                return this.PesoBruto;
             case "Version":
                return this.Version;
             case "CotacaoDolar":
                return this.CotacaoDolar;
             case "ValorTotalDolar":
                return this.ValorTotalDolar;
             case "ValorTotalReais":
                return this.ValorTotalReais;
             case "Fornecedor":
                return this.Fornecedor;
             case "TaxaSiscomex":
                return this.TaxaSiscomex;
             case "TaxaAfrmm":
                return this.TaxaAfrmm;
             case "NfGerada":
                return this.NfGerada;
             case "NfPrincipal":
                return this.NfPrincipal;
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
             if (LocalDesembaracoAduaneiro!=null)
                LocalDesembaracoAduaneiro.ChangeSingleConnection(newConnection);
             if (Fornecedor!=null)
                Fornecedor.ChangeSingleConnection(newConnection);
             if (NfPrincipal!=null)
                NfPrincipal.ChangeSingleConnection(newConnection);
               if (_valueCollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacaoLoaded) 
               {
                  foreach(DeclaracaoImportacaoAdicaoClass item in CollectionDeclaracaoImportacaoAdicaoClassDeclaracaoImportacao)
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
                  command.CommandText += " COUNT(declaracao_importacao.id_declaracao_importacao) " ;
               }
               else
               {
               command.CommandText += "declaracao_importacao.id_declaracao_importacao, " ;
               command.CommandText += "declaracao_importacao.dii_numero, " ;
               command.CommandText += "declaracao_importacao.dii_data_registro, " ;
               command.CommandText += "declaracao_importacao.dii_valor_mercadoria, " ;
               command.CommandText += "declaracao_importacao.dii_valor_frete, " ;
               command.CommandText += "declaracao_importacao.dii_valor_seguro, " ;
               command.CommandText += "declaracao_importacao.id_local_desembaraco_aduaneiro, " ;
               command.CommandText += "declaracao_importacao.dii_data_desembaraco, " ;
               command.CommandText += "declaracao_importacao.dii_qtd_volumes, " ;
               command.CommandText += "declaracao_importacao.dii_especie_volumes, " ;
               command.CommandText += "declaracao_importacao.dii_peso_liquido, " ;
               command.CommandText += "declaracao_importacao.dii_peso_bruto, " ;
               command.CommandText += "declaracao_importacao.version, " ;
               command.CommandText += "declaracao_importacao.dii_cotacao_dolar, " ;
               command.CommandText += "declaracao_importacao.dii_valor_total_dolar, " ;
               command.CommandText += "declaracao_importacao.dii_valor_total_reais, " ;
               command.CommandText += "declaracao_importacao.id_fornecedor, " ;
               command.CommandText += "declaracao_importacao.dii_taxa_siscomex, " ;
               command.CommandText += "declaracao_importacao.dii_taxa_afrmm, " ;
               command.CommandText += "declaracao_importacao.dii_nf_gerada, " ;
               command.CommandText += "declaracao_importacao.id_nf_principal, " ;
               command.CommandText += "declaracao_importacao.entity_uid " ;
               }
               command.CommandText += " FROM  declaracao_importacao ";
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
                        orderByClause += " , dii_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(dii_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = declaracao_importacao.id_acs_usuario_ultima_revisao ";
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
                     case "id_declaracao_importacao":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , declaracao_importacao.id_declaracao_importacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(declaracao_importacao.id_declaracao_importacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dii_numero":
                     case "Numero":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , declaracao_importacao.dii_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(declaracao_importacao.dii_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dii_data_registro":
                     case "DataRegistro":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , declaracao_importacao.dii_data_registro " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(declaracao_importacao.dii_data_registro) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dii_valor_mercadoria":
                     case "ValorMercadoria":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , declaracao_importacao.dii_valor_mercadoria " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(declaracao_importacao.dii_valor_mercadoria) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dii_valor_frete":
                     case "ValorFrete":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , declaracao_importacao.dii_valor_frete " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(declaracao_importacao.dii_valor_frete) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dii_valor_seguro":
                     case "ValorSeguro":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , declaracao_importacao.dii_valor_seguro " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(declaracao_importacao.dii_valor_seguro) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_local_desembaraco_aduaneiro":
                     case "LocalDesembaracoAduaneiro":
                     command.CommandText += " LEFT JOIN local_desembaraco_aduaneiro as local_desembaraco_aduaneiro_LocalDesembaracoAduaneiro ON local_desembaraco_aduaneiro_LocalDesembaracoAduaneiro.id_local_desembaraco_aduaneiro = declaracao_importacao.id_local_desembaraco_aduaneiro ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , local_desembaraco_aduaneiro_LocalDesembaracoAduaneiro.lda_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(local_desembaraco_aduaneiro_LocalDesembaracoAduaneiro.lda_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dii_data_desembaraco":
                     case "DataDesembaraco":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , declaracao_importacao.dii_data_desembaraco " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(declaracao_importacao.dii_data_desembaraco) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dii_qtd_volumes":
                     case "QtdVolumes":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , declaracao_importacao.dii_qtd_volumes " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(declaracao_importacao.dii_qtd_volumes) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dii_especie_volumes":
                     case "EspecieVolumes":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , declaracao_importacao.dii_especie_volumes " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(declaracao_importacao.dii_especie_volumes) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dii_peso_liquido":
                     case "PesoLiquido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , declaracao_importacao.dii_peso_liquido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(declaracao_importacao.dii_peso_liquido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dii_peso_bruto":
                     case "PesoBruto":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , declaracao_importacao.dii_peso_bruto " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(declaracao_importacao.dii_peso_bruto) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , declaracao_importacao.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(declaracao_importacao.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dii_cotacao_dolar":
                     case "CotacaoDolar":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , declaracao_importacao.dii_cotacao_dolar " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(declaracao_importacao.dii_cotacao_dolar) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dii_valor_total_dolar":
                     case "ValorTotalDolar":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , declaracao_importacao.dii_valor_total_dolar " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(declaracao_importacao.dii_valor_total_dolar) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dii_valor_total_reais":
                     case "ValorTotalReais":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , declaracao_importacao.dii_valor_total_reais " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(declaracao_importacao.dii_valor_total_reais) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_fornecedor":
                     case "Fornecedor":
                     command.CommandText += " LEFT JOIN fornecedor as fornecedor_Fornecedor ON fornecedor_Fornecedor.id_fornecedor = declaracao_importacao.id_fornecedor ";                     switch (parametro.TipoOrdenacao)
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
                     case "dii_taxa_siscomex":
                     case "TaxaSiscomex":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , declaracao_importacao.dii_taxa_siscomex " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(declaracao_importacao.dii_taxa_siscomex) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dii_taxa_afrmm":
                     case "TaxaAfrmm":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , declaracao_importacao.dii_taxa_afrmm " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(declaracao_importacao.dii_taxa_afrmm) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dii_nf_gerada":
                     case "NfGerada":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , declaracao_importacao.dii_nf_gerada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(declaracao_importacao.dii_nf_gerada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_nf_principal":
                     case "NfPrincipal":
                     orderByClause += " , declaracao_importacao.id_nf_principal " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , declaracao_importacao.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(declaracao_importacao.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("dii_numero")) 
                        {
                           whereClause += " OR UPPER(declaracao_importacao.dii_numero) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(declaracao_importacao.dii_numero) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("dii_especie_volumes")) 
                        {
                           whereClause += " OR UPPER(declaracao_importacao.dii_especie_volumes) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(declaracao_importacao.dii_especie_volumes) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(declaracao_importacao.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(declaracao_importacao.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_declaracao_importacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  declaracao_importacao.id_declaracao_importacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  declaracao_importacao.id_declaracao_importacao = :declaracao_importacao_ID_1384 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("declaracao_importacao_ID_1384", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Numero" || parametro.FieldName == "dii_numero")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  declaracao_importacao.dii_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  declaracao_importacao.dii_numero LIKE :declaracao_importacao_Numero_4082 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("declaracao_importacao_Numero_4082", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataRegistro" || parametro.FieldName == "dii_data_registro")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  declaracao_importacao.dii_data_registro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  declaracao_importacao.dii_data_registro = :declaracao_importacao_DataRegistro_7056 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("declaracao_importacao_DataRegistro_7056", NpgsqlDbType.Date, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorMercadoria" || parametro.FieldName == "dii_valor_mercadoria")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  declaracao_importacao.dii_valor_mercadoria IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  declaracao_importacao.dii_valor_mercadoria = :declaracao_importacao_ValorMercadoria_4640 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("declaracao_importacao_ValorMercadoria_4640", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorFrete" || parametro.FieldName == "dii_valor_frete")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  declaracao_importacao.dii_valor_frete IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  declaracao_importacao.dii_valor_frete = :declaracao_importacao_ValorFrete_1803 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("declaracao_importacao_ValorFrete_1803", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorSeguro" || parametro.FieldName == "dii_valor_seguro")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  declaracao_importacao.dii_valor_seguro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  declaracao_importacao.dii_valor_seguro = :declaracao_importacao_ValorSeguro_1667 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("declaracao_importacao_ValorSeguro_1667", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "LocalDesembaracoAduaneiro" || parametro.FieldName == "id_local_desembaraco_aduaneiro")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.LocalDesembaracoAduaneiroClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.LocalDesembaracoAduaneiroClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  declaracao_importacao.id_local_desembaraco_aduaneiro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  declaracao_importacao.id_local_desembaraco_aduaneiro = :declaracao_importacao_LocalDesembaracoAduaneiro_8603 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("declaracao_importacao_LocalDesembaracoAduaneiro_8603", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataDesembaraco" || parametro.FieldName == "dii_data_desembaraco")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  declaracao_importacao.dii_data_desembaraco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  declaracao_importacao.dii_data_desembaraco = :declaracao_importacao_DataDesembaraco_2853 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("declaracao_importacao_DataDesembaraco_2853", NpgsqlDbType.Date, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "QtdVolumes" || parametro.FieldName == "dii_qtd_volumes")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  declaracao_importacao.dii_qtd_volumes IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  declaracao_importacao.dii_qtd_volumes = :declaracao_importacao_QtdVolumes_5279 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("declaracao_importacao_QtdVolumes_5279", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EspecieVolumes" || parametro.FieldName == "dii_especie_volumes")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  declaracao_importacao.dii_especie_volumes IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  declaracao_importacao.dii_especie_volumes LIKE :declaracao_importacao_EspecieVolumes_5576 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("declaracao_importacao_EspecieVolumes_5576", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PesoLiquido" || parametro.FieldName == "dii_peso_liquido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  declaracao_importacao.dii_peso_liquido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  declaracao_importacao.dii_peso_liquido = :declaracao_importacao_PesoLiquido_3794 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("declaracao_importacao_PesoLiquido_3794", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PesoBruto" || parametro.FieldName == "dii_peso_bruto")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  declaracao_importacao.dii_peso_bruto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  declaracao_importacao.dii_peso_bruto = :declaracao_importacao_PesoBruto_9222 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("declaracao_importacao_PesoBruto_9222", NpgsqlDbType.Double, parametro.Fieldvalue));
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
                         whereClause += "  declaracao_importacao.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  declaracao_importacao.version = :declaracao_importacao_Version_8242 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("declaracao_importacao_Version_8242", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CotacaoDolar" || parametro.FieldName == "dii_cotacao_dolar")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  declaracao_importacao.dii_cotacao_dolar IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  declaracao_importacao.dii_cotacao_dolar = :declaracao_importacao_CotacaoDolar_231 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("declaracao_importacao_CotacaoDolar_231", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorTotalDolar" || parametro.FieldName == "dii_valor_total_dolar")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  declaracao_importacao.dii_valor_total_dolar IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  declaracao_importacao.dii_valor_total_dolar = :declaracao_importacao_ValorTotalDolar_3175 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("declaracao_importacao_ValorTotalDolar_3175", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorTotalReais" || parametro.FieldName == "dii_valor_total_reais")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  declaracao_importacao.dii_valor_total_reais IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  declaracao_importacao.dii_valor_total_reais = :declaracao_importacao_ValorTotalReais_8006 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("declaracao_importacao_ValorTotalReais_8006", NpgsqlDbType.Double, parametro.Fieldvalue));
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
                         whereClause += "  declaracao_importacao.id_fornecedor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  declaracao_importacao.id_fornecedor = :declaracao_importacao_Fornecedor_7845 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("declaracao_importacao_Fornecedor_7845", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TaxaSiscomex" || parametro.FieldName == "dii_taxa_siscomex")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  declaracao_importacao.dii_taxa_siscomex IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  declaracao_importacao.dii_taxa_siscomex = :declaracao_importacao_TaxaSiscomex_5014 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("declaracao_importacao_TaxaSiscomex_5014", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TaxaAfrmm" || parametro.FieldName == "dii_taxa_afrmm")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  declaracao_importacao.dii_taxa_afrmm IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  declaracao_importacao.dii_taxa_afrmm = :declaracao_importacao_TaxaAfrmm_213 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("declaracao_importacao_TaxaAfrmm_213", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NfGerada" || parametro.FieldName == "dii_nf_gerada")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  declaracao_importacao.dii_nf_gerada IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  declaracao_importacao.dii_nf_gerada = :declaracao_importacao_NfGerada_3539 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("declaracao_importacao_NfGerada_3539", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
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
                         whereClause += "  declaracao_importacao.id_nf_principal IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  declaracao_importacao.id_nf_principal = :declaracao_importacao_NfPrincipal_750 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("declaracao_importacao_NfPrincipal_750", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  declaracao_importacao.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  declaracao_importacao.entity_uid LIKE :declaracao_importacao_EntityUid_1772 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("declaracao_importacao_EntityUid_1772", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroExato" || parametro.FieldName == "NumeroExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  declaracao_importacao.dii_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  declaracao_importacao.dii_numero LIKE :declaracao_importacao_Numero_8248 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("declaracao_importacao_Numero_8248", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EspecieVolumesExato" || parametro.FieldName == "EspecieVolumesExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  declaracao_importacao.dii_especie_volumes IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  declaracao_importacao.dii_especie_volumes LIKE :declaracao_importacao_EspecieVolumes_8105 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("declaracao_importacao_EspecieVolumes_8105", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  declaracao_importacao.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  declaracao_importacao.entity_uid LIKE :declaracao_importacao_EntityUid_1479 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("declaracao_importacao_EntityUid_1479", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  DeclaracaoImportacaoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (DeclaracaoImportacaoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(DeclaracaoImportacaoClass), Convert.ToInt32(read["id_declaracao_importacao"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new DeclaracaoImportacaoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_declaracao_importacao"]);
                     entidade.Numero = (read["dii_numero"] != DBNull.Value ? read["dii_numero"].ToString() : null);
                     entidade.DataRegistro = (DateTime)read["dii_data_registro"];
                     entidade.ValorMercadoria = (double)read["dii_valor_mercadoria"];
                     entidade.ValorFrete = (double)read["dii_valor_frete"];
                     entidade.ValorSeguro = (double)read["dii_valor_seguro"];
                     if (read["id_local_desembaraco_aduaneiro"] != DBNull.Value)
                     {
                        entidade.LocalDesembaracoAduaneiro = (BibliotecaEntidades.Entidades.LocalDesembaracoAduaneiroClass)BibliotecaEntidades.Entidades.LocalDesembaracoAduaneiroClass.GetEntidade(Convert.ToInt32(read["id_local_desembaraco_aduaneiro"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.LocalDesembaracoAduaneiro = null ;
                     }
                     entidade.DataDesembaraco = (DateTime)read["dii_data_desembaraco"];
                     entidade.QtdVolumes = read["dii_qtd_volumes"] as int?;
                     entidade.EspecieVolumes = (read["dii_especie_volumes"] != DBNull.Value ? read["dii_especie_volumes"].ToString() : null);
                     entidade.PesoLiquido = read["dii_peso_liquido"] as double?;
                     entidade.PesoBruto = read["dii_peso_bruto"] as double?;
                     entidade.Version = (int)read["version"];
                     entidade.CotacaoDolar = (double)read["dii_cotacao_dolar"];
                     entidade.ValorTotalDolar = (double)read["dii_valor_total_dolar"];
                     entidade.ValorTotalReais = (double)read["dii_valor_total_reais"];
                     if (read["id_fornecedor"] != DBNull.Value)
                     {
                        entidade.Fornecedor = (BibliotecaEntidades.Entidades.FornecedorClass)BibliotecaEntidades.Entidades.FornecedorClass.GetEntidade(Convert.ToInt32(read["id_fornecedor"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Fornecedor = null ;
                     }
                     entidade.TaxaSiscomex = (double)read["dii_taxa_siscomex"];
                     entidade.TaxaAfrmm = (double)read["dii_taxa_afrmm"];
                     entidade.NfGerada = Convert.ToBoolean(Convert.ToInt16(read["dii_nf_gerada"]));
                     if (read["id_nf_principal"] != DBNull.Value)
                     {
                        entidade.NfPrincipal = (IWTNF.Entidades.Entidades.NfPrincipalClass)IWTNF.Entidades.Entidades.NfPrincipalClass.GetEntidade(Convert.ToInt32(read["id_nf_principal"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.NfPrincipal = null ;
                     }
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (DeclaracaoImportacaoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
