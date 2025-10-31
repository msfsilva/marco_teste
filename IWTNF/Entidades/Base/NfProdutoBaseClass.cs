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
     [Table("nf_produto","nfp")]
     public class NfProdutoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do NfProdutoClass";
protected const string ErroDelete = "Erro ao excluir o NfProdutoClass  ";
protected const string ErroSave = "Erro ao salvar o NfProdutoClass.";
protected const string ErroCollectionNfProdutoRastreabilidadeClassNfProduto = "Erro ao carregar a coleção de NfProdutoRastreabilidadeClass.";
protected const string ErroCodigoObrigatorio = "O campo Codigo é obrigatório";
protected const string ErroCodigoComprimento = "O campo Codigo deve ter no máximo 60 caracteres";
protected const string ErroDescricaoObrigatorio = "O campo Descricao é obrigatório";
protected const string ErroDescricaoComprimento = "O campo Descricao deve ter no máximo 1400 caracteres";
protected const string ErroUnidadeObrigatorio = "O campo Unidade é obrigatório";
protected const string ErroUnidadeComprimento = "O campo Unidade deve ter no máximo 6 caracteres";
protected const string ErroUnidadeTributacaoObrigatorio = "O campo UnidadeTributacao é obrigatório";
protected const string ErroUnidadeTributacaoComprimento = "O campo UnidadeTributacao deve ter no máximo 6 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroNfItemObrigatorio = "O campo NfItem é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do NfProdutoClass.";
protected const string MensagemUtilizadoCollectionNfProdutoRastreabilidadeClassNfProduto =  "A entidade NfProdutoClass está sendo utilizada nos seguintes NfProdutoRastreabilidadeClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade NfProdutoClass está sendo utilizada.";
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

       protected string _codigoOriginal{get;private set;}
       private string _codigoOriginalCommited{get; set;}
        private string _valueCodigo;
         [Column("nfp_codigo")]
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
         [Column("nfp_descricao")]
        public virtual string Descricao
         { 
            get { return this._valueDescricao; } 
            set 
            { 
                if (this._valueDescricao == value)return;
                 this._valueDescricao = value; 
            } 
        } 

       protected string _gtinOriginal{get;private set;}
       private string _gtinOriginalCommited{get; set;}
        private string _valueGtin;
         [Column("nfp_gtin")]
        public virtual string Gtin
         { 
            get { return this._valueGtin; } 
            set 
            { 
                if (this._valueGtin == value)return;
                 this._valueGtin = value; 
            } 
        } 

       protected string _ncmOriginal{get;private set;}
       private string _ncmOriginalCommited{get; set;}
        private string _valueNcm;
         [Column("nfp_ncm")]
        public virtual string Ncm
         { 
            get { return this._valueNcm; } 
            set 
            { 
                if (this._valueNcm == value)return;
                 this._valueNcm = value; 
            } 
        } 

       protected string _extipiOriginal{get;private set;}
       private string _extipiOriginalCommited{get; set;}
        private string _valueExtipi;
         [Column("nfp_extipi")]
        public virtual string Extipi
         { 
            get { return this._valueExtipi; } 
            set 
            { 
                if (this._valueExtipi == value)return;
                 this._valueExtipi = value; 
            } 
        } 

       protected string _generoOriginal{get;private set;}
       private string _generoOriginalCommited{get; set;}
        private string _valueGenero;
         [Column("nfp_genero")]
        public virtual string Genero
         { 
            get { return this._valueGenero; } 
            set 
            { 
                if (this._valueGenero == value)return;
                 this._valueGenero = value; 
            } 
        } 

       protected string _unidadeOriginal{get;private set;}
       private string _unidadeOriginalCommited{get; set;}
        private string _valueUnidade;
         [Column("nfp_unidade")]
        public virtual string Unidade
         { 
            get { return this._valueUnidade; } 
            set 
            { 
                if (this._valueUnidade == value)return;
                 this._valueUnidade = value; 
            } 
        } 

       protected double _valorUnitarioOriginal{get;private set;}
       private double _valorUnitarioOriginalCommited{get; set;}
        private double _valueValorUnitario;
         [Column("nfp_valor_unitario")]
        public virtual double ValorUnitario
         { 
            get { return this._valueValorUnitario; } 
            set 
            { 
                if (this._valueValorUnitario == value)return;
                 this._valueValorUnitario = value; 
            } 
        } 

       protected string _gtimUnidadeTrinutacaoOriginal{get;private set;}
       private string _gtimUnidadeTrinutacaoOriginalCommited{get; set;}
        private string _valueGtimUnidadeTrinutacao;
         [Column("nfp_gtim_unidade_trinutacao")]
        public virtual string GtimUnidadeTrinutacao
         { 
            get { return this._valueGtimUnidadeTrinutacao; } 
            set 
            { 
                if (this._valueGtimUnidadeTrinutacao == value)return;
                 this._valueGtimUnidadeTrinutacao = value; 
            } 
        } 

       protected string _unidadeTributacaoOriginal{get;private set;}
       private string _unidadeTributacaoOriginalCommited{get; set;}
        private string _valueUnidadeTributacao;
         [Column("nfp_unidade_tributacao")]
        public virtual string UnidadeTributacao
         { 
            get { return this._valueUnidadeTributacao; } 
            set 
            { 
                if (this._valueUnidadeTributacao == value)return;
                 this._valueUnidadeTributacao = value; 
            } 
        } 

       protected double _valorUnitarioTrinutacaoOriginal{get;private set;}
       private double _valorUnitarioTrinutacaoOriginalCommited{get; set;}
        private double _valueValorUnitarioTrinutacao;
         [Column("nfp_valor_unitario_trinutacao")]
        public virtual double ValorUnitarioTrinutacao
         { 
            get { return this._valueValorUnitarioTrinutacao; } 
            set 
            { 
                if (this._valueValorUnitarioTrinutacao == value)return;
                 this._valueValorUnitarioTrinutacao = value; 
            } 
        } 

       protected double _quantidadeTributavelOriginal{get;private set;}
       private double _quantidadeTributavelOriginalCommited{get; set;}
        private double _valueQuantidadeTributavel;
         [Column("nfp_quantidade_tributavel")]
        public virtual double QuantidadeTributavel
         { 
            get { return this._valueQuantidadeTributavel; } 
            set 
            { 
                if (this._valueQuantidadeTributavel == value)return;
                 this._valueQuantidadeTributavel = value; 
            } 
        } 

       protected double _valorTotalTributavelOriginal{get;private set;}
       private double _valorTotalTributavelOriginalCommited{get; set;}
        private double _valueValorTotalTributavel;
         [Column("nfp_valor_total_tributavel")]
        public virtual double ValorTotalTributavel
         { 
            get { return this._valueValorTotalTributavel; } 
            set 
            { 
                if (this._valueValorTotalTributavel == value)return;
                 this._valueValorTotalTributavel = value; 
            } 
        } 

       protected double _valorFreteOriginal{get;private set;}
       private double _valorFreteOriginalCommited{get; set;}
        private double _valueValorFrete;
         [Column("nfp_valor_frete")]
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
         [Column("nfp_valor_seguro")]
        public virtual double ValorSeguro
         { 
            get { return this._valueValorSeguro; } 
            set 
            { 
                if (this._valueValorSeguro == value)return;
                 this._valueValorSeguro = value; 
            } 
        } 

       protected double _valorDescontoOriginal{get;private set;}
       private double _valorDescontoOriginalCommited{get; set;}
        private double _valueValorDesconto;
         [Column("nfp_valor_desconto")]
        public virtual double ValorDesconto
         { 
            get { return this._valueValorDesconto; } 
            set 
            { 
                if (this._valueValorDesconto == value)return;
                 this._valueValorDesconto = value; 
            } 
        } 

       protected double _quantidadeOriginal{get;private set;}
       private double _quantidadeOriginalCommited{get; set;}
        private double _valueQuantidade;
         [Column("nfp_quantidade")]
        public virtual double Quantidade
         { 
            get { return this._valueQuantidade; } 
            set 
            { 
                if (this._valueQuantidade == value)return;
                 this._valueQuantidade = value; 
            } 
        } 

       protected double _outrasDespesasAcessoriasOriginal{get;private set;}
       private double _outrasDespesasAcessoriasOriginalCommited{get; set;}
        private double _valueOutrasDespesasAcessorias;
         [Column("nfp_outras_despesas_acessorias")]
        public virtual double OutrasDespesasAcessorias
         { 
            get { return this._valueOutrasDespesasAcessorias; } 
            set 
            { 
                if (this._valueOutrasDespesasAcessorias == value)return;
                 this._valueOutrasDespesasAcessorias = value; 
            } 
        } 

       protected string _xpedOriginal{get;private set;}
       private string _xpedOriginalCommited{get; set;}
        private string _valueXped;
         [Column("nfp_xped")]
        public virtual string Xped
         { 
            get { return this._valueXped; } 
            set 
            { 
                if (this._valueXped == value)return;
                 this._valueXped = value; 
            } 
        } 

       protected int? _numeroItemPedidoOriginal{get;private set;}
       private int? _numeroItemPedidoOriginalCommited{get; set;}
        private int? _valueNumeroItemPedido;
         [Column("nfp_numero_item_pedido")]
        public virtual int? NumeroItemPedido
         { 
            get { return this._valueNumeroItemPedido; } 
            set 
            { 
                if (this._valueNumeroItemPedido == value)return;
                 this._valueNumeroItemPedido = value; 
            } 
        } 

       protected string _cestOriginal{get;private set;}
       private string _cestOriginalCommited{get; set;}
        private string _valueCest;
         [Column("nfp_cest")]
        public virtual string Cest
         { 
            get { return this._valueCest; } 
            set 
            { 
                if (this._valueCest == value)return;
                 this._valueCest = value; 
            } 
        } 

       protected string _codigoBeneficioOriginal{get;private set;}
       private string _codigoBeneficioOriginalCommited{get; set;}
        private string _valueCodigoBeneficio;
         [Column("nfp_codigo_beneficio")]
        public virtual string CodigoBeneficio
         { 
            get { return this._valueCodigoBeneficio; } 
            set 
            { 
                if (this._valueCodigoBeneficio == value)return;
                 this._valueCodigoBeneficio = value; 
            } 
        } 

       protected NfeTipoProdutoEspecifico _tipoProdutoEspecificoOriginal{get;private set;}
       private NfeTipoProdutoEspecifico _tipoProdutoEspecificoOriginalCommited{get; set;}
        private NfeTipoProdutoEspecifico _valueTipoProdutoEspecifico;
         [Column("nfp_tipo_produto_especifico")]
        public virtual NfeTipoProdutoEspecifico TipoProdutoEspecifico
         { 
            get { return this._valueTipoProdutoEspecifico; } 
            set 
            { 
                if (this._valueTipoProdutoEspecifico == value)return;
                 this._valueTipoProdutoEspecifico = value; 
            } 
        } 

        public bool TipoProdutoEspecifico_Comum
         { 
            get { return this._valueTipoProdutoEspecifico == IWTNF.Entidades.Base.NfeTipoProdutoEspecifico.Comum; } 
            set { if (value) this._valueTipoProdutoEspecifico = IWTNF.Entidades.Base.NfeTipoProdutoEspecifico.Comum; }
         } 

        public bool TipoProdutoEspecifico_Medicamento
         { 
            get { return this._valueTipoProdutoEspecifico == IWTNF.Entidades.Base.NfeTipoProdutoEspecifico.Medicamento; } 
            set { if (value) this._valueTipoProdutoEspecifico = IWTNF.Entidades.Base.NfeTipoProdutoEspecifico.Medicamento; }
         } 

       protected string _medicamentoCodigoAnvisaOriginal{get;private set;}
       private string _medicamentoCodigoAnvisaOriginalCommited{get; set;}
        private string _valueMedicamentoCodigoAnvisa;
         [Column("nfp_medicamento_codigo_anvisa")]
        public virtual string MedicamentoCodigoAnvisa
         { 
            get { return this._valueMedicamentoCodigoAnvisa; } 
            set 
            { 
                if (this._valueMedicamentoCodigoAnvisa == value)return;
                 this._valueMedicamentoCodigoAnvisa = value; 
            } 
        } 

       protected double? _medicamentoPrecoMaximoConsumidorOriginal{get;private set;}
       private double? _medicamentoPrecoMaximoConsumidorOriginalCommited{get; set;}
        private double? _valueMedicamentoPrecoMaximoConsumidor;
         [Column("nfp_medicamento_preco_maximo_consumidor")]
        public virtual double? MedicamentoPrecoMaximoConsumidor
         { 
            get { return this._valueMedicamentoPrecoMaximoConsumidor; } 
            set 
            { 
                if (this._valueMedicamentoPrecoMaximoConsumidor == value)return;
                 this._valueMedicamentoPrecoMaximoConsumidor = value; 
            } 
        } 

       protected double? _percentualMercadoriaDevolvidaOriginal{get;private set;}
       private double? _percentualMercadoriaDevolvidaOriginalCommited{get; set;}
        private double? _valuePercentualMercadoriaDevolvida;
         [Column("nfp_percentual_mercadoria_devolvida")]
        public virtual double? PercentualMercadoriaDevolvida
         { 
            get { return this._valuePercentualMercadoriaDevolvida; } 
            set 
            { 
                if (this._valuePercentualMercadoriaDevolvida == value)return;
                 this._valuePercentualMercadoriaDevolvida = value; 
            } 
        } 

       protected double? _valorIpiDevolvidoOriginal{get;private set;}
       private double? _valorIpiDevolvidoOriginalCommited{get; set;}
        private double? _valueValorIpiDevolvido;
         [Column("nfp_valor_ipi_devolvido")]
        public virtual double? ValorIpiDevolvido
         { 
            get { return this._valueValorIpiDevolvido; } 
            set 
            { 
                if (this._valueValorIpiDevolvido == value)return;
                 this._valueValorIpiDevolvido = value; 
            } 
        } 

       protected short? _indSubstOriginal{get;private set;}
       private short? _indSubstOriginalCommited{get; set;}
        private short? _valueIndSubst;
         [Column("npd_ind_subst")]
        public virtual short? IndSubst
         { 
            get { return this._valueIndSubst; } 
            set 
            { 
                if (this._valueIndSubst == value)return;
                 this._valueIndSubst = value; 
            } 
        } 

       protected string _indEscalaOriginal{get;private set;}
       private string _indEscalaOriginalCommited{get; set;}
        private string _valueIndEscala;
         [Column("npd_ind_escala")]
        public virtual string IndEscala
         { 
            get { return this._valueIndEscala; } 
            set 
            { 
                if (this._valueIndEscala == value)return;
                 this._valueIndEscala = value; 
            } 
        } 

       protected short? _indCredNfeOriginal{get;private set;}
       private short? _indCredNfeOriginalCommited{get; set;}
        private short? _valueIndCredNfe;
         [Column("npd_ind_cred_nfe")]
        public virtual short? IndCredNfe
         { 
            get { return this._valueIndCredNfe; } 
            set 
            { 
                if (this._valueIndCredNfe == value)return;
                 this._valueIndCredNfe = value; 
            } 
        } 

       protected string _cBenefOriginal{get;private set;}
       private string _cBenefOriginalCommited{get; set;}
        private string _valueCBenef;
         [Column("npd_c_benef")]
        public virtual string CBenef
         { 
            get { return this._valueCBenef; } 
            set 
            { 
                if (this._valueCBenef == value)return;
                 this._valueCBenef = value; 
            } 
        } 

       private List<long> _collectionNfProdutoRastreabilidadeClassNfProdutoOriginal;
       private List<Entidades.NfProdutoRastreabilidadeClass > _collectionNfProdutoRastreabilidadeClassNfProdutoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfProdutoRastreabilidadeClassNfProdutoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfProdutoRastreabilidadeClassNfProdutoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNfProdutoRastreabilidadeClassNfProdutoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NfProdutoRastreabilidadeClass> _valueCollectionNfProdutoRastreabilidadeClassNfProduto { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NfProdutoRastreabilidadeClass> CollectionNfProdutoRastreabilidadeClassNfProduto 
       { 
           get { if(!_valueCollectionNfProdutoRastreabilidadeClassNfProdutoLoaded && !this.DisableLoadCollection){this.LoadCollectionNfProdutoRastreabilidadeClassNfProduto();}
return this._valueCollectionNfProdutoRastreabilidadeClassNfProduto; } 
           set 
           { 
               this._valueCollectionNfProdutoRastreabilidadeClassNfProduto = value; 
               this._valueCollectionNfProdutoRastreabilidadeClassNfProdutoLoaded = true; 
           } 
       } 

        public NfProdutoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Quantidade = 0;
           this.OutrasDespesasAcessorias = 0;
           this.TipoProdutoEspecifico = (NfeTipoProdutoEspecifico)0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static NfProdutoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (NfProdutoClass) GetEntity(typeof(NfProdutoClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionNfProdutoRastreabilidadeClassNfProdutoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNfProdutoRastreabilidadeClassNfProdutoChanged = true;
                  _valueCollectionNfProdutoRastreabilidadeClassNfProdutoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNfProdutoRastreabilidadeClassNfProdutoChanged = true; 
                  _valueCollectionNfProdutoRastreabilidadeClassNfProdutoCommitedChanged = true;
                 foreach (Entidades.NfProdutoRastreabilidadeClass item in e.OldItems) 
                 { 
                     _collectionNfProdutoRastreabilidadeClassNfProdutoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNfProdutoRastreabilidadeClassNfProdutoChanged = true; 
                  _valueCollectionNfProdutoRastreabilidadeClassNfProdutoCommitedChanged = true;
                 foreach (Entidades.NfProdutoRastreabilidadeClass item in _valueCollectionNfProdutoRastreabilidadeClassNfProduto) 
                 { 
                     _collectionNfProdutoRastreabilidadeClassNfProdutoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNfProdutoRastreabilidadeClassNfProduto()
         {
            try
            {
                 ObservableCollection<Entidades.NfProdutoRastreabilidadeClass> oc;
                _valueCollectionNfProdutoRastreabilidadeClassNfProdutoChanged = false;
                 _valueCollectionNfProdutoRastreabilidadeClassNfProdutoCommitedChanged = false;
                _collectionNfProdutoRastreabilidadeClassNfProdutoRemovidos = new List<Entidades.NfProdutoRastreabilidadeClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NfProdutoRastreabilidadeClass>();
                }
                else{ 
                   Entidades.NfProdutoRastreabilidadeClass search = new Entidades.NfProdutoRastreabilidadeClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NfProdutoRastreabilidadeClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("NfProduto", this),                     }                       ).Cast<Entidades.NfProdutoRastreabilidadeClass>().ToList());
                 }
                 _valueCollectionNfProdutoRastreabilidadeClassNfProduto = new BindingList<Entidades.NfProdutoRastreabilidadeClass>(oc); 
                 _collectionNfProdutoRastreabilidadeClassNfProdutoOriginal= (from a in _valueCollectionNfProdutoRastreabilidadeClassNfProduto select a.ID).ToList();
                 _valueCollectionNfProdutoRastreabilidadeClassNfProdutoLoaded = true;
                 oc.CollectionChanged += CollectionNfProdutoRastreabilidadeClassNfProdutoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNfProdutoRastreabilidadeClassNfProduto+"\r\n" + e.Message, e);
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
                if (Codigo.Length >60)
                {
                    throw new Exception( ErroCodigoComprimento);
                }
                if (string.IsNullOrEmpty(Descricao))
                {
                    throw new Exception(ErroDescricaoObrigatorio);
                }
                if (Descricao.Length >1400)
                {
                    throw new Exception( ErroDescricaoComprimento);
                }
                if (string.IsNullOrEmpty(Unidade))
                {
                    throw new Exception(ErroUnidadeObrigatorio);
                }
                if (Unidade.Length >6)
                {
                    throw new Exception( ErroUnidadeComprimento);
                }
                if (string.IsNullOrEmpty(UnidadeTributacao))
                {
                    throw new Exception(ErroUnidadeTributacaoObrigatorio);
                }
                if (UnidadeTributacao.Length >6)
                {
                    throw new Exception( ErroUnidadeTributacaoComprimento);
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
                    "  public.nf_produto  " +
                    "WHERE " +
                    "  id_nf_produto = :id";
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
                        "  public.nf_produto   " +
                        "SET  " + 
                        "  id_nf_item = :id_nf_item, " + 
                        "  nfp_codigo = :nfp_codigo, " + 
                        "  nfp_descricao = :nfp_descricao, " + 
                        "  nfp_gtin = :nfp_gtin, " + 
                        "  nfp_ncm = :nfp_ncm, " + 
                        "  nfp_extipi = :nfp_extipi, " + 
                        "  nfp_genero = :nfp_genero, " + 
                        "  nfp_unidade = :nfp_unidade, " + 
                        "  nfp_valor_unitario = :nfp_valor_unitario, " + 
                        "  nfp_gtim_unidade_trinutacao = :nfp_gtim_unidade_trinutacao, " + 
                        "  nfp_unidade_tributacao = :nfp_unidade_tributacao, " + 
                        "  nfp_valor_unitario_trinutacao = :nfp_valor_unitario_trinutacao, " + 
                        "  nfp_quantidade_tributavel = :nfp_quantidade_tributavel, " + 
                        "  nfp_valor_total_tributavel = :nfp_valor_total_tributavel, " + 
                        "  nfp_valor_frete = :nfp_valor_frete, " + 
                        "  nfp_valor_seguro = :nfp_valor_seguro, " + 
                        "  nfp_valor_desconto = :nfp_valor_desconto, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  nfp_quantidade = :nfp_quantidade, " + 
                        "  nfp_outras_despesas_acessorias = :nfp_outras_despesas_acessorias, " + 
                        "  nfp_xped = :nfp_xped, " + 
                        "  nfp_numero_item_pedido = :nfp_numero_item_pedido, " + 
                        "  nfp_cest = :nfp_cest, " + 
                        "  nfp_codigo_beneficio = :nfp_codigo_beneficio, " + 
                        "  nfp_tipo_produto_especifico = :nfp_tipo_produto_especifico, " + 
                        "  nfp_medicamento_codigo_anvisa = :nfp_medicamento_codigo_anvisa, " + 
                        "  nfp_medicamento_preco_maximo_consumidor = :nfp_medicamento_preco_maximo_consumidor, " + 
                        "  nfp_percentual_mercadoria_devolvida = :nfp_percentual_mercadoria_devolvida, " + 
                        "  nfp_valor_ipi_devolvido = :nfp_valor_ipi_devolvido, " + 
                        "  npd_ind_subst = :npd_ind_subst, " + 
                        "  npd_ind_escala = :npd_ind_escala, " + 
                        "  npd_ind_cred_nfe = :npd_ind_cred_nfe, " + 
                        "  npd_c_benef = :npd_c_benef "+
                        "WHERE  " +
                        "  id_nf_produto = :id " +
                        "RETURNING id_nf_produto;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.nf_produto " +
                        "( " +
                        "  id_nf_item , " + 
                        "  nfp_codigo , " + 
                        "  nfp_descricao , " + 
                        "  nfp_gtin , " + 
                        "  nfp_ncm , " + 
                        "  nfp_extipi , " + 
                        "  nfp_genero , " + 
                        "  nfp_unidade , " + 
                        "  nfp_valor_unitario , " + 
                        "  nfp_gtim_unidade_trinutacao , " + 
                        "  nfp_unidade_tributacao , " + 
                        "  nfp_valor_unitario_trinutacao , " + 
                        "  nfp_quantidade_tributavel , " + 
                        "  nfp_valor_total_tributavel , " + 
                        "  nfp_valor_frete , " + 
                        "  nfp_valor_seguro , " + 
                        "  nfp_valor_desconto , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  nfp_quantidade , " + 
                        "  nfp_outras_despesas_acessorias , " + 
                        "  nfp_xped , " + 
                        "  nfp_numero_item_pedido , " + 
                        "  nfp_cest , " + 
                        "  nfp_codigo_beneficio , " + 
                        "  nfp_tipo_produto_especifico , " + 
                        "  nfp_medicamento_codigo_anvisa , " + 
                        "  nfp_medicamento_preco_maximo_consumidor , " + 
                        "  nfp_percentual_mercadoria_devolvida , " + 
                        "  nfp_valor_ipi_devolvido , " + 
                        "  npd_ind_subst , " + 
                        "  npd_ind_escala , " + 
                        "  npd_ind_cred_nfe , " + 
                        "  npd_c_benef  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_nf_item , " + 
                        "  :nfp_codigo , " + 
                        "  :nfp_descricao , " + 
                        "  :nfp_gtin , " + 
                        "  :nfp_ncm , " + 
                        "  :nfp_extipi , " + 
                        "  :nfp_genero , " + 
                        "  :nfp_unidade , " + 
                        "  :nfp_valor_unitario , " + 
                        "  :nfp_gtim_unidade_trinutacao , " + 
                        "  :nfp_unidade_tributacao , " + 
                        "  :nfp_valor_unitario_trinutacao , " + 
                        "  :nfp_quantidade_tributavel , " + 
                        "  :nfp_valor_total_tributavel , " + 
                        "  :nfp_valor_frete , " + 
                        "  :nfp_valor_seguro , " + 
                        "  :nfp_valor_desconto , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :nfp_quantidade , " + 
                        "  :nfp_outras_despesas_acessorias , " + 
                        "  :nfp_xped , " + 
                        "  :nfp_numero_item_pedido , " + 
                        "  :nfp_cest , " + 
                        "  :nfp_codigo_beneficio , " + 
                        "  :nfp_tipo_produto_especifico , " + 
                        "  :nfp_medicamento_codigo_anvisa , " + 
                        "  :nfp_medicamento_preco_maximo_consumidor , " + 
                        "  :nfp_percentual_mercadoria_devolvida , " + 
                        "  :nfp_valor_ipi_devolvido , " + 
                        "  :npd_ind_subst , " + 
                        "  :npd_ind_escala , " + 
                        "  :npd_ind_cred_nfe , " + 
                        "  :npd_c_benef  "+
                        ")RETURNING id_nf_produto;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nf_item", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.NfItem==null ? (object) DBNull.Value : this.NfItem.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_codigo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Codigo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Descricao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_gtin", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Gtin ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_ncm", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Ncm ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_extipi", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Extipi ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_genero", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Genero ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_unidade", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Unidade ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_valor_unitario", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorUnitario ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_gtim_unidade_trinutacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.GtimUnidadeTrinutacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_unidade_tributacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UnidadeTributacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_valor_unitario_trinutacao", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorUnitarioTrinutacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_quantidade_tributavel", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.QuantidadeTributavel ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_valor_total_tributavel", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorTotalTributavel ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_valor_frete", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorFrete ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_valor_seguro", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorSeguro ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_valor_desconto", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorDesconto ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_quantidade", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Quantidade ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_outras_despesas_acessorias", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.OutrasDespesasAcessorias ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_xped", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Xped ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_numero_item_pedido", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NumeroItemPedido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_cest", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Cest ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_codigo_beneficio", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CodigoBeneficio ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_tipo_produto_especifico", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.TipoProdutoEspecifico);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_medicamento_codigo_anvisa", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.MedicamentoCodigoAnvisa ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_medicamento_preco_maximo_consumidor", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.MedicamentoPrecoMaximoConsumidor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_percentual_mercadoria_devolvida", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PercentualMercadoriaDevolvida ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfp_valor_ipi_devolvido", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorIpiDevolvido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npd_ind_subst", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IndSubst ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npd_ind_escala", NpgsqlDbType.Char));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IndEscala ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npd_ind_cred_nfe", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IndCredNfe ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npd_c_benef", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CBenef ?? DBNull.Value;

 
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
 if (CollectionNfProdutoRastreabilidadeClassNfProduto.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNfProdutoRastreabilidadeClassNfProduto+"\r\n";
                foreach (Entidades.NfProdutoRastreabilidadeClass tmp in CollectionNfProdutoRastreabilidadeClassNfProduto)
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
        public static NfProdutoClass CopiarEntidade(NfProdutoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               NfProdutoClass toRet = new NfProdutoClass(usuario,conn);
 toRet.NfItem= entidadeCopiar.NfItem;
 toRet.Codigo= entidadeCopiar.Codigo;
 toRet.Descricao= entidadeCopiar.Descricao;
 toRet.Gtin= entidadeCopiar.Gtin;
 toRet.Ncm= entidadeCopiar.Ncm;
 toRet.Extipi= entidadeCopiar.Extipi;
 toRet.Genero= entidadeCopiar.Genero;
 toRet.Unidade= entidadeCopiar.Unidade;
 toRet.ValorUnitario= entidadeCopiar.ValorUnitario;
 toRet.GtimUnidadeTrinutacao= entidadeCopiar.GtimUnidadeTrinutacao;
 toRet.UnidadeTributacao= entidadeCopiar.UnidadeTributacao;
 toRet.ValorUnitarioTrinutacao= entidadeCopiar.ValorUnitarioTrinutacao;
 toRet.QuantidadeTributavel= entidadeCopiar.QuantidadeTributavel;
 toRet.ValorTotalTributavel= entidadeCopiar.ValorTotalTributavel;
 toRet.ValorFrete= entidadeCopiar.ValorFrete;
 toRet.ValorSeguro= entidadeCopiar.ValorSeguro;
 toRet.ValorDesconto= entidadeCopiar.ValorDesconto;
 toRet.Quantidade= entidadeCopiar.Quantidade;
 toRet.OutrasDespesasAcessorias= entidadeCopiar.OutrasDespesasAcessorias;
 toRet.Xped= entidadeCopiar.Xped;
 toRet.NumeroItemPedido= entidadeCopiar.NumeroItemPedido;
 toRet.Cest= entidadeCopiar.Cest;
 toRet.CodigoBeneficio= entidadeCopiar.CodigoBeneficio;
 toRet.TipoProdutoEspecifico= entidadeCopiar.TipoProdutoEspecifico;
 toRet.MedicamentoCodigoAnvisa= entidadeCopiar.MedicamentoCodigoAnvisa;
 toRet.MedicamentoPrecoMaximoConsumidor= entidadeCopiar.MedicamentoPrecoMaximoConsumidor;
 toRet.PercentualMercadoriaDevolvida= entidadeCopiar.PercentualMercadoriaDevolvida;
 toRet.ValorIpiDevolvido= entidadeCopiar.ValorIpiDevolvido;
 toRet.IndSubst= entidadeCopiar.IndSubst;
 toRet.IndEscala= entidadeCopiar.IndEscala;
 toRet.IndCredNfe= entidadeCopiar.IndCredNfe;
 toRet.CBenef= entidadeCopiar.CBenef;

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
       _codigoOriginal = Codigo;
       _codigoOriginalCommited = _codigoOriginal;
       _descricaoOriginal = Descricao;
       _descricaoOriginalCommited = _descricaoOriginal;
       _gtinOriginal = Gtin;
       _gtinOriginalCommited = _gtinOriginal;
       _ncmOriginal = Ncm;
       _ncmOriginalCommited = _ncmOriginal;
       _extipiOriginal = Extipi;
       _extipiOriginalCommited = _extipiOriginal;
       _generoOriginal = Genero;
       _generoOriginalCommited = _generoOriginal;
       _unidadeOriginal = Unidade;
       _unidadeOriginalCommited = _unidadeOriginal;
       _valorUnitarioOriginal = ValorUnitario;
       _valorUnitarioOriginalCommited = _valorUnitarioOriginal;
       _gtimUnidadeTrinutacaoOriginal = GtimUnidadeTrinutacao;
       _gtimUnidadeTrinutacaoOriginalCommited = _gtimUnidadeTrinutacaoOriginal;
       _unidadeTributacaoOriginal = UnidadeTributacao;
       _unidadeTributacaoOriginalCommited = _unidadeTributacaoOriginal;
       _valorUnitarioTrinutacaoOriginal = ValorUnitarioTrinutacao;
       _valorUnitarioTrinutacaoOriginalCommited = _valorUnitarioTrinutacaoOriginal;
       _quantidadeTributavelOriginal = QuantidadeTributavel;
       _quantidadeTributavelOriginalCommited = _quantidadeTributavelOriginal;
       _valorTotalTributavelOriginal = ValorTotalTributavel;
       _valorTotalTributavelOriginalCommited = _valorTotalTributavelOriginal;
       _valorFreteOriginal = ValorFrete;
       _valorFreteOriginalCommited = _valorFreteOriginal;
       _valorSeguroOriginal = ValorSeguro;
       _valorSeguroOriginalCommited = _valorSeguroOriginal;
       _valorDescontoOriginal = ValorDesconto;
       _valorDescontoOriginalCommited = _valorDescontoOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _quantidadeOriginal = Quantidade;
       _quantidadeOriginalCommited = _quantidadeOriginal;
       _outrasDespesasAcessoriasOriginal = OutrasDespesasAcessorias;
       _outrasDespesasAcessoriasOriginalCommited = _outrasDespesasAcessoriasOriginal;
       _xpedOriginal = Xped;
       _xpedOriginalCommited = _xpedOriginal;
       _numeroItemPedidoOriginal = NumeroItemPedido;
       _numeroItemPedidoOriginalCommited = _numeroItemPedidoOriginal;
       _cestOriginal = Cest;
       _cestOriginalCommited = _cestOriginal;
       _codigoBeneficioOriginal = CodigoBeneficio;
       _codigoBeneficioOriginalCommited = _codigoBeneficioOriginal;
       _tipoProdutoEspecificoOriginal = TipoProdutoEspecifico;
       _tipoProdutoEspecificoOriginalCommited = _tipoProdutoEspecificoOriginal;
       _medicamentoCodigoAnvisaOriginal = MedicamentoCodigoAnvisa;
       _medicamentoCodigoAnvisaOriginalCommited = _medicamentoCodigoAnvisaOriginal;
       _medicamentoPrecoMaximoConsumidorOriginal = MedicamentoPrecoMaximoConsumidor;
       _medicamentoPrecoMaximoConsumidorOriginalCommited = _medicamentoPrecoMaximoConsumidorOriginal;
       _percentualMercadoriaDevolvidaOriginal = PercentualMercadoriaDevolvida;
       _percentualMercadoriaDevolvidaOriginalCommited = _percentualMercadoriaDevolvidaOriginal;
       _valorIpiDevolvidoOriginal = ValorIpiDevolvido;
       _valorIpiDevolvidoOriginalCommited = _valorIpiDevolvidoOriginal;
       _indSubstOriginal = IndSubst;
       _indSubstOriginalCommited = _indSubstOriginal;
       _indEscalaOriginal = IndEscala;
       _indEscalaOriginalCommited = _indEscalaOriginal;
       _indCredNfeOriginal = IndCredNfe;
       _indCredNfeOriginalCommited = _indCredNfeOriginal;
       _cBenefOriginal = CBenef;
       _cBenefOriginalCommited = _cBenefOriginal;

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
       _codigoOriginalCommited = Codigo;
       _descricaoOriginalCommited = Descricao;
       _gtinOriginalCommited = Gtin;
       _ncmOriginalCommited = Ncm;
       _extipiOriginalCommited = Extipi;
       _generoOriginalCommited = Genero;
       _unidadeOriginalCommited = Unidade;
       _valorUnitarioOriginalCommited = ValorUnitario;
       _gtimUnidadeTrinutacaoOriginalCommited = GtimUnidadeTrinutacao;
       _unidadeTributacaoOriginalCommited = UnidadeTributacao;
       _valorUnitarioTrinutacaoOriginalCommited = ValorUnitarioTrinutacao;
       _quantidadeTributavelOriginalCommited = QuantidadeTributavel;
       _valorTotalTributavelOriginalCommited = ValorTotalTributavel;
       _valorFreteOriginalCommited = ValorFrete;
       _valorSeguroOriginalCommited = ValorSeguro;
       _valorDescontoOriginalCommited = ValorDesconto;
       _versionOriginalCommited = Version;
       _quantidadeOriginalCommited = Quantidade;
       _outrasDespesasAcessoriasOriginalCommited = OutrasDespesasAcessorias;
       _xpedOriginalCommited = Xped;
       _numeroItemPedidoOriginalCommited = NumeroItemPedido;
       _cestOriginalCommited = Cest;
       _codigoBeneficioOriginalCommited = CodigoBeneficio;
       _tipoProdutoEspecificoOriginalCommited = TipoProdutoEspecifico;
       _medicamentoCodigoAnvisaOriginalCommited = MedicamentoCodigoAnvisa;
       _medicamentoPrecoMaximoConsumidorOriginalCommited = MedicamentoPrecoMaximoConsumidor;
       _percentualMercadoriaDevolvidaOriginalCommited = PercentualMercadoriaDevolvida;
       _valorIpiDevolvidoOriginalCommited = ValorIpiDevolvido;
       _indSubstOriginalCommited = IndSubst;
       _indEscalaOriginalCommited = IndEscala;
       _indCredNfeOriginalCommited = IndCredNfe;
       _cBenefOriginalCommited = CBenef;

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
               if (_valueCollectionNfProdutoRastreabilidadeClassNfProdutoLoaded) 
               {
                  if (_collectionNfProdutoRastreabilidadeClassNfProdutoRemovidos != null) 
                  {
                     _collectionNfProdutoRastreabilidadeClassNfProdutoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNfProdutoRastreabilidadeClassNfProdutoRemovidos = new List<Entidades.NfProdutoRastreabilidadeClass>();
                  }
                  _collectionNfProdutoRastreabilidadeClassNfProdutoOriginal= (from a in _valueCollectionNfProdutoRastreabilidadeClassNfProduto select a.ID).ToList();
                  _valueCollectionNfProdutoRastreabilidadeClassNfProdutoChanged = false;
                  _valueCollectionNfProdutoRastreabilidadeClassNfProdutoCommitedChanged = false;
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
               Codigo=_codigoOriginal;
               _codigoOriginalCommited=_codigoOriginal;
               Descricao=_descricaoOriginal;
               _descricaoOriginalCommited=_descricaoOriginal;
               Gtin=_gtinOriginal;
               _gtinOriginalCommited=_gtinOriginal;
               Ncm=_ncmOriginal;
               _ncmOriginalCommited=_ncmOriginal;
               Extipi=_extipiOriginal;
               _extipiOriginalCommited=_extipiOriginal;
               Genero=_generoOriginal;
               _generoOriginalCommited=_generoOriginal;
               Unidade=_unidadeOriginal;
               _unidadeOriginalCommited=_unidadeOriginal;
               ValorUnitario=_valorUnitarioOriginal;
               _valorUnitarioOriginalCommited=_valorUnitarioOriginal;
               GtimUnidadeTrinutacao=_gtimUnidadeTrinutacaoOriginal;
               _gtimUnidadeTrinutacaoOriginalCommited=_gtimUnidadeTrinutacaoOriginal;
               UnidadeTributacao=_unidadeTributacaoOriginal;
               _unidadeTributacaoOriginalCommited=_unidadeTributacaoOriginal;
               ValorUnitarioTrinutacao=_valorUnitarioTrinutacaoOriginal;
               _valorUnitarioTrinutacaoOriginalCommited=_valorUnitarioTrinutacaoOriginal;
               QuantidadeTributavel=_quantidadeTributavelOriginal;
               _quantidadeTributavelOriginalCommited=_quantidadeTributavelOriginal;
               ValorTotalTributavel=_valorTotalTributavelOriginal;
               _valorTotalTributavelOriginalCommited=_valorTotalTributavelOriginal;
               ValorFrete=_valorFreteOriginal;
               _valorFreteOriginalCommited=_valorFreteOriginal;
               ValorSeguro=_valorSeguroOriginal;
               _valorSeguroOriginalCommited=_valorSeguroOriginal;
               ValorDesconto=_valorDescontoOriginal;
               _valorDescontoOriginalCommited=_valorDescontoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               Quantidade=_quantidadeOriginal;
               _quantidadeOriginalCommited=_quantidadeOriginal;
               OutrasDespesasAcessorias=_outrasDespesasAcessoriasOriginal;
               _outrasDespesasAcessoriasOriginalCommited=_outrasDespesasAcessoriasOriginal;
               Xped=_xpedOriginal;
               _xpedOriginalCommited=_xpedOriginal;
               NumeroItemPedido=_numeroItemPedidoOriginal;
               _numeroItemPedidoOriginalCommited=_numeroItemPedidoOriginal;
               Cest=_cestOriginal;
               _cestOriginalCommited=_cestOriginal;
               CodigoBeneficio=_codigoBeneficioOriginal;
               _codigoBeneficioOriginalCommited=_codigoBeneficioOriginal;
               TipoProdutoEspecifico=_tipoProdutoEspecificoOriginal;
               _tipoProdutoEspecificoOriginalCommited=_tipoProdutoEspecificoOriginal;
               MedicamentoCodigoAnvisa=_medicamentoCodigoAnvisaOriginal;
               _medicamentoCodigoAnvisaOriginalCommited=_medicamentoCodigoAnvisaOriginal;
               MedicamentoPrecoMaximoConsumidor=_medicamentoPrecoMaximoConsumidorOriginal;
               _medicamentoPrecoMaximoConsumidorOriginalCommited=_medicamentoPrecoMaximoConsumidorOriginal;
               PercentualMercadoriaDevolvida=_percentualMercadoriaDevolvidaOriginal;
               _percentualMercadoriaDevolvidaOriginalCommited=_percentualMercadoriaDevolvidaOriginal;
               ValorIpiDevolvido=_valorIpiDevolvidoOriginal;
               _valorIpiDevolvidoOriginalCommited=_valorIpiDevolvidoOriginal;
               IndSubst=_indSubstOriginal;
               _indSubstOriginalCommited=_indSubstOriginal;
               IndEscala=_indEscalaOriginal;
               _indEscalaOriginalCommited=_indEscalaOriginal;
               IndCredNfe=_indCredNfeOriginal;
               _indCredNfeOriginalCommited=_indCredNfeOriginal;
               CBenef=_cBenefOriginal;
               _cBenefOriginalCommited=_cBenefOriginal;
               if (_valueCollectionNfProdutoRastreabilidadeClassNfProdutoLoaded) 
               {
                  CollectionNfProdutoRastreabilidadeClassNfProduto.Clear();
                  foreach(int item in _collectionNfProdutoRastreabilidadeClassNfProdutoOriginal)
                  {
                    CollectionNfProdutoRastreabilidadeClassNfProduto.Add(Entidades.NfProdutoRastreabilidadeClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNfProdutoRastreabilidadeClassNfProdutoRemovidos.Clear();
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
               if (_valueCollectionNfProdutoRastreabilidadeClassNfProdutoLoaded) 
               {
                  if (_valueCollectionNfProdutoRastreabilidadeClassNfProdutoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfProdutoRastreabilidadeClassNfProdutoLoaded) 
               {
                   tempRet = CollectionNfProdutoRastreabilidadeClassNfProduto.Any(item => item.IsDirty());
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
       dirty = _codigoOriginal != Codigo;
      if (dirty) return true;
       dirty = _descricaoOriginal != Descricao;
      if (dirty) return true;
       dirty = _gtinOriginal != Gtin;
      if (dirty) return true;
       dirty = _ncmOriginal != Ncm;
      if (dirty) return true;
       dirty = _extipiOriginal != Extipi;
      if (dirty) return true;
       dirty = _generoOriginal != Genero;
      if (dirty) return true;
       dirty = _unidadeOriginal != Unidade;
      if (dirty) return true;
       dirty = _valorUnitarioOriginal != ValorUnitario;
      if (dirty) return true;
       dirty = _gtimUnidadeTrinutacaoOriginal != GtimUnidadeTrinutacao;
      if (dirty) return true;
       dirty = _unidadeTributacaoOriginal != UnidadeTributacao;
      if (dirty) return true;
       dirty = _valorUnitarioTrinutacaoOriginal != ValorUnitarioTrinutacao;
      if (dirty) return true;
       dirty = _quantidadeTributavelOriginal != QuantidadeTributavel;
      if (dirty) return true;
       dirty = _valorTotalTributavelOriginal != ValorTotalTributavel;
      if (dirty) return true;
       dirty = _valorFreteOriginal != ValorFrete;
      if (dirty) return true;
       dirty = _valorSeguroOriginal != ValorSeguro;
      if (dirty) return true;
       dirty = _valorDescontoOriginal != ValorDesconto;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _quantidadeOriginal != Quantidade;
      if (dirty) return true;
       dirty = _outrasDespesasAcessoriasOriginal != OutrasDespesasAcessorias;
      if (dirty) return true;
       dirty = _xpedOriginal != Xped;
      if (dirty) return true;
       dirty = _numeroItemPedidoOriginal != NumeroItemPedido;
      if (dirty) return true;
       dirty = _cestOriginal != Cest;
      if (dirty) return true;
       dirty = _codigoBeneficioOriginal != CodigoBeneficio;
      if (dirty) return true;
       dirty = _tipoProdutoEspecificoOriginal != TipoProdutoEspecifico;
      if (dirty) return true;
       dirty = _medicamentoCodigoAnvisaOriginal != MedicamentoCodigoAnvisa;
      if (dirty) return true;
       dirty = _medicamentoPrecoMaximoConsumidorOriginal != MedicamentoPrecoMaximoConsumidor;
      if (dirty) return true;
       dirty = _percentualMercadoriaDevolvidaOriginal != PercentualMercadoriaDevolvida;
      if (dirty) return true;
       dirty = _valorIpiDevolvidoOriginal != ValorIpiDevolvido;
      if (dirty) return true;
       dirty = _indSubstOriginal != IndSubst;
      if (dirty) return true;
       dirty = _indEscalaOriginal != IndEscala;
      if (dirty) return true;
       dirty = _indCredNfeOriginal != IndCredNfe;
      if (dirty) return true;
       dirty = _cBenefOriginal != CBenef;

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
               if (_valueCollectionNfProdutoRastreabilidadeClassNfProdutoLoaded) 
               {
                  if (_valueCollectionNfProdutoRastreabilidadeClassNfProdutoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNfProdutoRastreabilidadeClassNfProdutoLoaded) 
               {
                   tempRet = CollectionNfProdutoRastreabilidadeClassNfProduto.Any(item => item.IsDirtyCommited());
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
       dirty = _codigoOriginalCommited != Codigo;
      if (dirty) return true;
       dirty = _descricaoOriginalCommited != Descricao;
      if (dirty) return true;
       dirty = _gtinOriginalCommited != Gtin;
      if (dirty) return true;
       dirty = _ncmOriginalCommited != Ncm;
      if (dirty) return true;
       dirty = _extipiOriginalCommited != Extipi;
      if (dirty) return true;
       dirty = _generoOriginalCommited != Genero;
      if (dirty) return true;
       dirty = _unidadeOriginalCommited != Unidade;
      if (dirty) return true;
       dirty = _valorUnitarioOriginalCommited != ValorUnitario;
      if (dirty) return true;
       dirty = _gtimUnidadeTrinutacaoOriginalCommited != GtimUnidadeTrinutacao;
      if (dirty) return true;
       dirty = _unidadeTributacaoOriginalCommited != UnidadeTributacao;
      if (dirty) return true;
       dirty = _valorUnitarioTrinutacaoOriginalCommited != ValorUnitarioTrinutacao;
      if (dirty) return true;
       dirty = _quantidadeTributavelOriginalCommited != QuantidadeTributavel;
      if (dirty) return true;
       dirty = _valorTotalTributavelOriginalCommited != ValorTotalTributavel;
      if (dirty) return true;
       dirty = _valorFreteOriginalCommited != ValorFrete;
      if (dirty) return true;
       dirty = _valorSeguroOriginalCommited != ValorSeguro;
      if (dirty) return true;
       dirty = _valorDescontoOriginalCommited != ValorDesconto;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _quantidadeOriginalCommited != Quantidade;
      if (dirty) return true;
       dirty = _outrasDespesasAcessoriasOriginalCommited != OutrasDespesasAcessorias;
      if (dirty) return true;
       dirty = _xpedOriginalCommited != Xped;
      if (dirty) return true;
       dirty = _numeroItemPedidoOriginalCommited != NumeroItemPedido;
      if (dirty) return true;
       dirty = _cestOriginalCommited != Cest;
      if (dirty) return true;
       dirty = _codigoBeneficioOriginalCommited != CodigoBeneficio;
      if (dirty) return true;
       dirty = _tipoProdutoEspecificoOriginalCommited != TipoProdutoEspecifico;
      if (dirty) return true;
       dirty = _medicamentoCodigoAnvisaOriginalCommited != MedicamentoCodigoAnvisa;
      if (dirty) return true;
       dirty = _medicamentoPrecoMaximoConsumidorOriginalCommited != MedicamentoPrecoMaximoConsumidor;
      if (dirty) return true;
       dirty = _percentualMercadoriaDevolvidaOriginalCommited != PercentualMercadoriaDevolvida;
      if (dirty) return true;
       dirty = _valorIpiDevolvidoOriginalCommited != ValorIpiDevolvido;
      if (dirty) return true;
       dirty = _indSubstOriginalCommited != IndSubst;
      if (dirty) return true;
       dirty = _indEscalaOriginalCommited != IndEscala;
      if (dirty) return true;
       dirty = _indCredNfeOriginalCommited != IndCredNfe;
      if (dirty) return true;
       dirty = _cBenefOriginalCommited != CBenef;

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
               if (_valueCollectionNfProdutoRastreabilidadeClassNfProdutoLoaded) 
               {
                  foreach(NfProdutoRastreabilidadeClass item in CollectionNfProdutoRastreabilidadeClassNfProduto)
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
             case "Codigo":
                return this.Codigo;
             case "Descricao":
                return this.Descricao;
             case "Gtin":
                return this.Gtin;
             case "Ncm":
                return this.Ncm;
             case "Extipi":
                return this.Extipi;
             case "Genero":
                return this.Genero;
             case "Unidade":
                return this.Unidade;
             case "ValorUnitario":
                return this.ValorUnitario;
             case "GtimUnidadeTrinutacao":
                return this.GtimUnidadeTrinutacao;
             case "UnidadeTributacao":
                return this.UnidadeTributacao;
             case "ValorUnitarioTrinutacao":
                return this.ValorUnitarioTrinutacao;
             case "QuantidadeTributavel":
                return this.QuantidadeTributavel;
             case "ValorTotalTributavel":
                return this.ValorTotalTributavel;
             case "ValorFrete":
                return this.ValorFrete;
             case "ValorSeguro":
                return this.ValorSeguro;
             case "ValorDesconto":
                return this.ValorDesconto;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "Quantidade":
                return this.Quantidade;
             case "OutrasDespesasAcessorias":
                return this.OutrasDespesasAcessorias;
             case "Xped":
                return this.Xped;
             case "NumeroItemPedido":
                return this.NumeroItemPedido;
             case "Cest":
                return this.Cest;
             case "CodigoBeneficio":
                return this.CodigoBeneficio;
             case "TipoProdutoEspecifico":
                return this.TipoProdutoEspecifico;
             case "MedicamentoCodigoAnvisa":
                return this.MedicamentoCodigoAnvisa;
             case "MedicamentoPrecoMaximoConsumidor":
                return this.MedicamentoPrecoMaximoConsumidor;
             case "PercentualMercadoriaDevolvida":
                return this.PercentualMercadoriaDevolvida;
             case "ValorIpiDevolvido":
                return this.ValorIpiDevolvido;
             case "IndSubst":
                return this.IndSubst;
             case "IndEscala":
                return this.IndEscala;
             case "IndCredNfe":
                return this.IndCredNfe;
             case "CBenef":
                return this.CBenef;
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
               if (_valueCollectionNfProdutoRastreabilidadeClassNfProdutoLoaded) 
               {
                  foreach(NfProdutoRastreabilidadeClass item in CollectionNfProdutoRastreabilidadeClassNfProduto)
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
                  command.CommandText += " COUNT(nf_produto.id_nf_produto) " ;
               }
               else
               {
               command.CommandText += "nf_produto.id_nf_item, " ;
               command.CommandText += "nf_produto.nfp_codigo, " ;
               command.CommandText += "nf_produto.nfp_descricao, " ;
               command.CommandText += "nf_produto.nfp_gtin, " ;
               command.CommandText += "nf_produto.nfp_ncm, " ;
               command.CommandText += "nf_produto.nfp_extipi, " ;
               command.CommandText += "nf_produto.nfp_genero, " ;
               command.CommandText += "nf_produto.nfp_unidade, " ;
               command.CommandText += "nf_produto.nfp_valor_unitario, " ;
               command.CommandText += "nf_produto.nfp_gtim_unidade_trinutacao, " ;
               command.CommandText += "nf_produto.nfp_unidade_tributacao, " ;
               command.CommandText += "nf_produto.nfp_valor_unitario_trinutacao, " ;
               command.CommandText += "nf_produto.nfp_quantidade_tributavel, " ;
               command.CommandText += "nf_produto.nfp_valor_total_tributavel, " ;
               command.CommandText += "nf_produto.nfp_valor_frete, " ;
               command.CommandText += "nf_produto.nfp_valor_seguro, " ;
               command.CommandText += "nf_produto.nfp_valor_desconto, " ;
               command.CommandText += "nf_produto.entity_uid, " ;
               command.CommandText += "nf_produto.version, " ;
               command.CommandText += "nf_produto.nfp_quantidade, " ;
               command.CommandText += "nf_produto.nfp_outras_despesas_acessorias, " ;
               command.CommandText += "nf_produto.id_nf_produto, " ;
               command.CommandText += "nf_produto.nfp_xped, " ;
               command.CommandText += "nf_produto.nfp_numero_item_pedido, " ;
               command.CommandText += "nf_produto.nfp_cest, " ;
               command.CommandText += "nf_produto.nfp_codigo_beneficio, " ;
               command.CommandText += "nf_produto.nfp_tipo_produto_especifico, " ;
               command.CommandText += "nf_produto.nfp_medicamento_codigo_anvisa, " ;
               command.CommandText += "nf_produto.nfp_medicamento_preco_maximo_consumidor, " ;
               command.CommandText += "nf_produto.nfp_percentual_mercadoria_devolvida, " ;
               command.CommandText += "nf_produto.nfp_valor_ipi_devolvido, " ;
               command.CommandText += "nf_produto.npd_ind_subst, " ;
               command.CommandText += "nf_produto.npd_ind_escala, " ;
               command.CommandText += "nf_produto.npd_ind_cred_nfe, " ;
               command.CommandText += "nf_produto.npd_c_benef " ;
               }
               command.CommandText += " FROM  nf_produto ";
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
                        orderByClause += " , nfp_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(nfp_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = nf_produto.id_acs_usuario_ultima_revisao ";
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
                     case "id_nf_item":
                     case "NfItem":
                     orderByClause += " , nf_produto.id_nf_item " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "nfp_codigo":
                     case "Codigo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto.nfp_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto.nfp_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_descricao":
                     case "Descricao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto.nfp_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto.nfp_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_gtin":
                     case "Gtin":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto.nfp_gtin " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto.nfp_gtin) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_ncm":
                     case "Ncm":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto.nfp_ncm " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto.nfp_ncm) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_extipi":
                     case "Extipi":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto.nfp_extipi " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto.nfp_extipi) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_genero":
                     case "Genero":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto.nfp_genero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto.nfp_genero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_unidade":
                     case "Unidade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto.nfp_unidade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto.nfp_unidade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_valor_unitario":
                     case "ValorUnitario":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto.nfp_valor_unitario " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto.nfp_valor_unitario) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_gtim_unidade_trinutacao":
                     case "GtimUnidadeTrinutacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto.nfp_gtim_unidade_trinutacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto.nfp_gtim_unidade_trinutacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_unidade_tributacao":
                     case "UnidadeTributacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto.nfp_unidade_tributacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto.nfp_unidade_tributacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_valor_unitario_trinutacao":
                     case "ValorUnitarioTrinutacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto.nfp_valor_unitario_trinutacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto.nfp_valor_unitario_trinutacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_quantidade_tributavel":
                     case "QuantidadeTributavel":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto.nfp_quantidade_tributavel " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto.nfp_quantidade_tributavel) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_valor_total_tributavel":
                     case "ValorTotalTributavel":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto.nfp_valor_total_tributavel " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto.nfp_valor_total_tributavel) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_valor_frete":
                     case "ValorFrete":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto.nfp_valor_frete " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto.nfp_valor_frete) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_valor_seguro":
                     case "ValorSeguro":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto.nfp_valor_seguro " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto.nfp_valor_seguro) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_valor_desconto":
                     case "ValorDesconto":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto.nfp_valor_desconto " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto.nfp_valor_desconto) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , nf_produto.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_quantidade":
                     case "Quantidade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto.nfp_quantidade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto.nfp_quantidade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_outras_despesas_acessorias":
                     case "OutrasDespesasAcessorias":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto.nfp_outras_despesas_acessorias " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto.nfp_outras_despesas_acessorias) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_nf_produto":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto.id_nf_produto " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto.id_nf_produto) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_xped":
                     case "Xped":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto.nfp_xped " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto.nfp_xped) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_numero_item_pedido":
                     case "NumeroItemPedido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto.nfp_numero_item_pedido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto.nfp_numero_item_pedido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_cest":
                     case "Cest":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto.nfp_cest " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto.nfp_cest) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_codigo_beneficio":
                     case "CodigoBeneficio":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto.nfp_codigo_beneficio " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto.nfp_codigo_beneficio) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_tipo_produto_especifico":
                     case "TipoProdutoEspecifico":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto.nfp_tipo_produto_especifico " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto.nfp_tipo_produto_especifico) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_medicamento_codigo_anvisa":
                     case "MedicamentoCodigoAnvisa":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto.nfp_medicamento_codigo_anvisa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto.nfp_medicamento_codigo_anvisa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_medicamento_preco_maximo_consumidor":
                     case "MedicamentoPrecoMaximoConsumidor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto.nfp_medicamento_preco_maximo_consumidor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto.nfp_medicamento_preco_maximo_consumidor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_percentual_mercadoria_devolvida":
                     case "PercentualMercadoriaDevolvida":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto.nfp_percentual_mercadoria_devolvida " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto.nfp_percentual_mercadoria_devolvida) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfp_valor_ipi_devolvido":
                     case "ValorIpiDevolvido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto.nfp_valor_ipi_devolvido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto.nfp_valor_ipi_devolvido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npd_ind_subst":
                     case "IndSubst":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto.npd_ind_subst " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto.npd_ind_subst) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npd_ind_escala":
                     case "IndEscala":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto.npd_ind_escala " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto.npd_ind_escala) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npd_ind_cred_nfe":
                     case "IndCredNfe":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto.npd_ind_cred_nfe " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto.npd_ind_cred_nfe) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npd_c_benef":
                     case "CBenef":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto.npd_c_benef " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto.npd_c_benef) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfp_codigo")) 
                        {
                           whereClause += " OR UPPER(nf_produto.nfp_codigo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto.nfp_codigo) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfp_descricao")) 
                        {
                           whereClause += " OR UPPER(nf_produto.nfp_descricao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto.nfp_descricao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfp_gtin")) 
                        {
                           whereClause += " OR UPPER(nf_produto.nfp_gtin) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto.nfp_gtin) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfp_ncm")) 
                        {
                           whereClause += " OR UPPER(nf_produto.nfp_ncm) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto.nfp_ncm) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfp_extipi")) 
                        {
                           whereClause += " OR UPPER(nf_produto.nfp_extipi) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto.nfp_extipi) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfp_genero")) 
                        {
                           whereClause += " OR UPPER(nf_produto.nfp_genero) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto.nfp_genero) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfp_unidade")) 
                        {
                           whereClause += " OR UPPER(nf_produto.nfp_unidade) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto.nfp_unidade) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfp_gtim_unidade_trinutacao")) 
                        {
                           whereClause += " OR UPPER(nf_produto.nfp_gtim_unidade_trinutacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto.nfp_gtim_unidade_trinutacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfp_unidade_tributacao")) 
                        {
                           whereClause += " OR UPPER(nf_produto.nfp_unidade_tributacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto.nfp_unidade_tributacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(nf_produto.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfp_xped")) 
                        {
                           whereClause += " OR UPPER(nf_produto.nfp_xped) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto.nfp_xped) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfp_cest")) 
                        {
                           whereClause += " OR UPPER(nf_produto.nfp_cest) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto.nfp_cest) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfp_codigo_beneficio")) 
                        {
                           whereClause += " OR UPPER(nf_produto.nfp_codigo_beneficio) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto.nfp_codigo_beneficio) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfp_medicamento_codigo_anvisa")) 
                        {
                           whereClause += " OR UPPER(nf_produto.nfp_medicamento_codigo_anvisa) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto.nfp_medicamento_codigo_anvisa) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("npd_ind_escala")) 
                        {
                           whereClause += " OR UPPER(nf_produto.npd_ind_escala) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto.npd_ind_escala) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("npd_c_benef")) 
                        {
                           whereClause += " OR UPPER(nf_produto.npd_c_benef) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto.npd_c_benef) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
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
                         whereClause += "  nf_produto.id_nf_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.id_nf_item = :nf_produto_NfItem_6553 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_NfItem_6553", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Codigo" || parametro.FieldName == "nfp_codigo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.nfp_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.nfp_codigo LIKE :nf_produto_Codigo_4836 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_Codigo_4836", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Descricao" || parametro.FieldName == "nfp_descricao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.nfp_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.nfp_descricao LIKE :nf_produto_Descricao_278 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_Descricao_278", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Gtin" || parametro.FieldName == "nfp_gtin")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.nfp_gtin IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.nfp_gtin LIKE :nf_produto_Gtin_1154 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_Gtin_1154", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Ncm" || parametro.FieldName == "nfp_ncm")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.nfp_ncm IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.nfp_ncm LIKE :nf_produto_Ncm_9079 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_Ncm_9079", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Extipi" || parametro.FieldName == "nfp_extipi")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.nfp_extipi IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.nfp_extipi LIKE :nf_produto_Extipi_6775 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_Extipi_6775", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Genero" || parametro.FieldName == "nfp_genero")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.nfp_genero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.nfp_genero LIKE :nf_produto_Genero_2015 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_Genero_2015", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Unidade" || parametro.FieldName == "nfp_unidade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.nfp_unidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.nfp_unidade LIKE :nf_produto_Unidade_5178 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_Unidade_5178", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorUnitario" || parametro.FieldName == "nfp_valor_unitario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.nfp_valor_unitario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.nfp_valor_unitario = :nf_produto_ValorUnitario_6818 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ValorUnitario_6818", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "GtimUnidadeTrinutacao" || parametro.FieldName == "nfp_gtim_unidade_trinutacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.nfp_gtim_unidade_trinutacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.nfp_gtim_unidade_trinutacao LIKE :nf_produto_GtimUnidadeTrinutacao_9698 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_GtimUnidadeTrinutacao_9698", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UnidadeTributacao" || parametro.FieldName == "nfp_unidade_tributacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.nfp_unidade_tributacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.nfp_unidade_tributacao LIKE :nf_produto_UnidadeTributacao_4586 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_UnidadeTributacao_4586", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorUnitarioTrinutacao" || parametro.FieldName == "nfp_valor_unitario_trinutacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.nfp_valor_unitario_trinutacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.nfp_valor_unitario_trinutacao = :nf_produto_ValorUnitarioTrinutacao_508 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ValorUnitarioTrinutacao_508", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "QuantidadeTributavel" || parametro.FieldName == "nfp_quantidade_tributavel")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.nfp_quantidade_tributavel IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.nfp_quantidade_tributavel = :nf_produto_QuantidadeTributavel_361 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_QuantidadeTributavel_361", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorTotalTributavel" || parametro.FieldName == "nfp_valor_total_tributavel")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.nfp_valor_total_tributavel IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.nfp_valor_total_tributavel = :nf_produto_ValorTotalTributavel_6675 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ValorTotalTributavel_6675", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorFrete" || parametro.FieldName == "nfp_valor_frete")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.nfp_valor_frete IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.nfp_valor_frete = :nf_produto_ValorFrete_6395 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ValorFrete_6395", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorSeguro" || parametro.FieldName == "nfp_valor_seguro")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.nfp_valor_seguro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.nfp_valor_seguro = :nf_produto_ValorSeguro_7028 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ValorSeguro_7028", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorDesconto" || parametro.FieldName == "nfp_valor_desconto")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.nfp_valor_desconto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.nfp_valor_desconto = :nf_produto_ValorDesconto_2555 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ValorDesconto_2555", NpgsqlDbType.Double, parametro.Fieldvalue));
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
                         whereClause += "  nf_produto.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.entity_uid LIKE :nf_produto_EntityUid_1269 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_EntityUid_1269", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  nf_produto.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.version = :nf_produto_Version_2218 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_Version_2218", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Quantidade" || parametro.FieldName == "nfp_quantidade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.nfp_quantidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.nfp_quantidade = :nf_produto_Quantidade_8839 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_Quantidade_8839", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OutrasDespesasAcessorias" || parametro.FieldName == "nfp_outras_despesas_acessorias")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.nfp_outras_despesas_acessorias IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.nfp_outras_despesas_acessorias = :nf_produto_OutrasDespesasAcessorias_6349 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_OutrasDespesasAcessorias_6349", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_nf_produto")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.id_nf_produto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.id_nf_produto = :nf_produto_ID_1752 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ID_1752", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Xped" || parametro.FieldName == "nfp_xped")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.nfp_xped IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.nfp_xped LIKE :nf_produto_Xped_2638 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_Xped_2638", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroItemPedido" || parametro.FieldName == "nfp_numero_item_pedido")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.nfp_numero_item_pedido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.nfp_numero_item_pedido = :nf_produto_NumeroItemPedido_5261 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_NumeroItemPedido_5261", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cest" || parametro.FieldName == "nfp_cest")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.nfp_cest IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.nfp_cest LIKE :nf_produto_Cest_7966 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_Cest_7966", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoBeneficio" || parametro.FieldName == "nfp_codigo_beneficio")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.nfp_codigo_beneficio IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.nfp_codigo_beneficio LIKE :nf_produto_CodigoBeneficio_5286 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_CodigoBeneficio_5286", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoProdutoEspecifico" || parametro.FieldName == "nfp_tipo_produto_especifico")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is NfeTipoProdutoEspecifico)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo NfeTipoProdutoEspecifico");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.nfp_tipo_produto_especifico IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.nfp_tipo_produto_especifico = :nf_produto_TipoProdutoEspecifico_8901 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_TipoProdutoEspecifico_8901", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MedicamentoCodigoAnvisa" || parametro.FieldName == "nfp_medicamento_codigo_anvisa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.nfp_medicamento_codigo_anvisa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.nfp_medicamento_codigo_anvisa LIKE :nf_produto_MedicamentoCodigoAnvisa_6399 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_MedicamentoCodigoAnvisa_6399", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MedicamentoPrecoMaximoConsumidor" || parametro.FieldName == "nfp_medicamento_preco_maximo_consumidor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.nfp_medicamento_preco_maximo_consumidor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.nfp_medicamento_preco_maximo_consumidor = :nf_produto_MedicamentoPrecoMaximoConsumidor_5276 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_MedicamentoPrecoMaximoConsumidor_5276", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PercentualMercadoriaDevolvida" || parametro.FieldName == "nfp_percentual_mercadoria_devolvida")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.nfp_percentual_mercadoria_devolvida IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.nfp_percentual_mercadoria_devolvida = :nf_produto_PercentualMercadoriaDevolvida_1506 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_PercentualMercadoriaDevolvida_1506", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorIpiDevolvido" || parametro.FieldName == "nfp_valor_ipi_devolvido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.nfp_valor_ipi_devolvido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.nfp_valor_ipi_devolvido = :nf_produto_ValorIpiDevolvido_6081 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_ValorIpiDevolvido_6081", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IndSubst" || parametro.FieldName == "npd_ind_subst")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.npd_ind_subst IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.npd_ind_subst = :nf_produto_IndSubst_6417 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_IndSubst_6417", NpgsqlDbType.Smallint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IndEscala" || parametro.FieldName == "npd_ind_escala")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.npd_ind_escala IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.npd_ind_escala LIKE :nf_produto_IndEscala_7989 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_IndEscala_7989", NpgsqlDbType.Char,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IndCredNfe" || parametro.FieldName == "npd_ind_cred_nfe")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.npd_ind_cred_nfe IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.npd_ind_cred_nfe = :nf_produto_IndCredNfe_241 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_IndCredNfe_241", NpgsqlDbType.Smallint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CBenef" || parametro.FieldName == "npd_c_benef")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.npd_c_benef IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.npd_c_benef LIKE :nf_produto_CBenef_6093 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_CBenef_6093", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  nf_produto.nfp_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.nfp_codigo LIKE :nf_produto_Codigo_6723 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_Codigo_6723", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nf_produto.nfp_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.nfp_descricao LIKE :nf_produto_Descricao_6268 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_Descricao_6268", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "GtinExato" || parametro.FieldName == "GtinExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.nfp_gtin IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.nfp_gtin LIKE :nf_produto_Gtin_2635 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_Gtin_2635", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NcmExato" || parametro.FieldName == "NcmExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.nfp_ncm IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.nfp_ncm LIKE :nf_produto_Ncm_9971 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_Ncm_9971", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ExtipiExato" || parametro.FieldName == "ExtipiExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.nfp_extipi IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.nfp_extipi LIKE :nf_produto_Extipi_2253 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_Extipi_2253", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "GeneroExato" || parametro.FieldName == "GeneroExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.nfp_genero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.nfp_genero LIKE :nf_produto_Genero_6787 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_Genero_6787", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UnidadeExato" || parametro.FieldName == "UnidadeExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.nfp_unidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.nfp_unidade LIKE :nf_produto_Unidade_4293 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_Unidade_4293", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "GtimUnidadeTrinutacaoExato" || parametro.FieldName == "GtimUnidadeTrinutacaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.nfp_gtim_unidade_trinutacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.nfp_gtim_unidade_trinutacao LIKE :nf_produto_GtimUnidadeTrinutacao_7689 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_GtimUnidadeTrinutacao_7689", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UnidadeTributacaoExato" || parametro.FieldName == "UnidadeTributacaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.nfp_unidade_tributacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.nfp_unidade_tributacao LIKE :nf_produto_UnidadeTributacao_1998 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_UnidadeTributacao_1998", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nf_produto.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.entity_uid LIKE :nf_produto_EntityUid_6438 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_EntityUid_6438", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "XpedExato" || parametro.FieldName == "XpedExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.nfp_xped IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.nfp_xped LIKE :nf_produto_Xped_5205 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_Xped_5205", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CestExato" || parametro.FieldName == "CestExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.nfp_cest IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.nfp_cest LIKE :nf_produto_Cest_1528 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_Cest_1528", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoBeneficioExato" || parametro.FieldName == "CodigoBeneficioExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.nfp_codigo_beneficio IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.nfp_codigo_beneficio LIKE :nf_produto_CodigoBeneficio_8261 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_CodigoBeneficio_8261", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MedicamentoCodigoAnvisaExato" || parametro.FieldName == "MedicamentoCodigoAnvisaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.nfp_medicamento_codigo_anvisa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.nfp_medicamento_codigo_anvisa LIKE :nf_produto_MedicamentoCodigoAnvisa_8081 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_MedicamentoCodigoAnvisa_8081", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IndEscalaExato" || parametro.FieldName == "IndEscalaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.npd_ind_escala IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.npd_ind_escala LIKE :nf_produto_IndEscala_2970 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_IndEscala_2970", NpgsqlDbType.Char,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CBenefExato" || parametro.FieldName == "CBenefExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto.npd_c_benef IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto.npd_c_benef LIKE :nf_produto_CBenef_9008 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_CBenef_9008", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  NfProdutoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (NfProdutoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(NfProdutoClass), Convert.ToInt32(read["id_nf_produto"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new NfProdutoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     if (read["id_nf_item"] != DBNull.Value)
                     {
                        entidade.NfItem = (IWTNF.Entidades.Entidades.NfItemClass)IWTNF.Entidades.Entidades.NfItemClass.GetEntidade(Convert.ToInt32(read["id_nf_item"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.NfItem = null ;
                     }
                     entidade.Codigo = (read["nfp_codigo"] != DBNull.Value ? read["nfp_codigo"].ToString() : null);
                     entidade.Descricao = (read["nfp_descricao"] != DBNull.Value ? read["nfp_descricao"].ToString() : null);
                     entidade.Gtin = (read["nfp_gtin"] != DBNull.Value ? read["nfp_gtin"].ToString() : null);
                     entidade.Ncm = (read["nfp_ncm"] != DBNull.Value ? read["nfp_ncm"].ToString() : null);
                     entidade.Extipi = (read["nfp_extipi"] != DBNull.Value ? read["nfp_extipi"].ToString() : null);
                     entidade.Genero = (read["nfp_genero"] != DBNull.Value ? read["nfp_genero"].ToString() : null);
                     entidade.Unidade = (read["nfp_unidade"] != DBNull.Value ? read["nfp_unidade"].ToString() : null);
                     entidade.ValorUnitario = (double)read["nfp_valor_unitario"];
                     entidade.GtimUnidadeTrinutacao = (read["nfp_gtim_unidade_trinutacao"] != DBNull.Value ? read["nfp_gtim_unidade_trinutacao"].ToString() : null);
                     entidade.UnidadeTributacao = (read["nfp_unidade_tributacao"] != DBNull.Value ? read["nfp_unidade_tributacao"].ToString() : null);
                     entidade.ValorUnitarioTrinutacao = (double)read["nfp_valor_unitario_trinutacao"];
                     entidade.QuantidadeTributavel = (double)read["nfp_quantidade_tributavel"];
                     entidade.ValorTotalTributavel = (double)read["nfp_valor_total_tributavel"];
                     entidade.ValorFrete = (double)read["nfp_valor_frete"];
                     entidade.ValorSeguro = (double)read["nfp_valor_seguro"];
                     entidade.ValorDesconto = (double)read["nfp_valor_desconto"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.Quantidade = (double)read["nfp_quantidade"];
                     entidade.OutrasDespesasAcessorias = (double)read["nfp_outras_despesas_acessorias"];
                     entidade.ID = Convert.ToInt64(read["id_nf_produto"]);
                     entidade.Xped = (read["nfp_xped"] != DBNull.Value ? read["nfp_xped"].ToString() : null);
                     entidade.NumeroItemPedido = read["nfp_numero_item_pedido"] as int?;
                     entidade.Cest = (read["nfp_cest"] != DBNull.Value ? read["nfp_cest"].ToString() : null);
                     entidade.CodigoBeneficio = (read["nfp_codigo_beneficio"] != DBNull.Value ? read["nfp_codigo_beneficio"].ToString() : null);
                     entidade.TipoProdutoEspecifico = (NfeTipoProdutoEspecifico) (read["nfp_tipo_produto_especifico"] != DBNull.Value ? Enum.ToObject(typeof(NfeTipoProdutoEspecifico), read["nfp_tipo_produto_especifico"]) : null);
                     entidade.MedicamentoCodigoAnvisa = (read["nfp_medicamento_codigo_anvisa"] != DBNull.Value ? read["nfp_medicamento_codigo_anvisa"].ToString() : null);
                     entidade.MedicamentoPrecoMaximoConsumidor = read["nfp_medicamento_preco_maximo_consumidor"] as double?;
                     entidade.PercentualMercadoriaDevolvida = read["nfp_percentual_mercadoria_devolvida"] as double?;
                     entidade.ValorIpiDevolvido = read["nfp_valor_ipi_devolvido"] as double?;
                     entidade.IndSubst = read["npd_ind_subst"] as short?;
                     entidade.IndEscala = (read["npd_ind_escala"] != DBNull.Value ? read["npd_ind_escala"].ToString() : null);
                     entidade.IndCredNfe = read["npd_ind_cred_nfe"] as short?;
                     entidade.CBenef = (read["npd_c_benef"] != DBNull.Value ? read["npd_c_benef"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (NfProdutoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
