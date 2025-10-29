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
     [Table("produto_material","prm")]
     public class ProdutoMaterialBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do ProdutoMaterialClass";
protected const string ErroDelete = "Erro ao excluir o ProdutoMaterialClass  ";
protected const string ErroSave = "Erro ao salvar o ProdutoMaterialClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroProdutoObrigatorio = "O campo Produto é obrigatório";
protected const string ErroMaterialObrigatorio = "O campo Material é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do ProdutoMaterialClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade ProdutoMaterialClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.ProdutoClass _produtoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.ProdutoClass _produtoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.ProdutoClass _valueProduto;
        [Column("id_produto", "produto", "id_produto")]
       public virtual BibliotecaEntidades.Entidades.ProdutoClass Produto
        { 
           get {                 return this._valueProduto; } 
           set 
           { 
                if (this._valueProduto == value)return;
                 this._valueProduto = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.MaterialClass _materialOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.MaterialClass _materialOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.MaterialClass _valueMaterial;
        [Column("id_material", "material", "id_material")]
       public virtual BibliotecaEntidades.Entidades.MaterialClass Material
        { 
           get {                 return this._valueMaterial; } 
           set 
           { 
                if (this._valueMaterial == value)return;
                 this._valueMaterial = value; 
           } 
       } 

       protected double _quantidadeOriginal{get;private set;}
       private double _quantidadeOriginalCommited{get; set;}
        private double _valueQuantidade;
         [Column("prm_quantidade")]
        public virtual double Quantidade
         { 
            get { return this._valueQuantidade; } 
            set 
            { 
                if (this._valueQuantidade == value)return;
                 this._valueQuantidade = value; 
            } 
        } 

       protected double _qtdProdutoPorUnidadeOriginal{get;private set;}
       private double _qtdProdutoPorUnidadeOriginalCommited{get; set;}
        private double _valueQtdProdutoPorUnidade;
         [Column("prm_qtd_produto_por_unidade")]
        public virtual double QtdProdutoPorUnidade
         { 
            get { return this._valueQtdProdutoPorUnidade; } 
            set 
            { 
                if (this._valueQtdProdutoPorUnidade == value)return;
                 this._valueQtdProdutoPorUnidade = value; 
            } 
        } 

       protected int _versaoEstruturaOriginal{get;private set;}
       private int _versaoEstruturaOriginalCommited{get; set;}
        private int _valueVersaoEstrutura;
         [Column("prm_versao_estrutura")]
        public virtual int VersaoEstrutura
         { 
            get { return this._valueVersaoEstrutura; } 
            set 
            { 
                if (this._valueVersaoEstrutura == value)return;
                 this._valueVersaoEstrutura = value; 
            } 
        } 

       protected bool _planoCorteOriginal{get;private set;}
       private bool _planoCorteOriginalCommited{get; set;}
        private bool _valuePlanoCorte;
         [Column("prm_plano_corte")]
        public virtual bool PlanoCorte
         { 
            get { return this._valuePlanoCorte; } 
            set 
            { 
                if (this._valuePlanoCorte == value)return;
                 this._valuePlanoCorte = value; 
            } 
        } 

       protected double? _planoCorteQuantidadeOriginal{get;private set;}
       private double? _planoCorteQuantidadeOriginalCommited{get; set;}
        private double? _valuePlanoCorteQuantidade;
         [Column("prm_plano_corte_quantidade")]
        public virtual double? PlanoCorteQuantidade
         { 
            get { return this._valuePlanoCorteQuantidade; } 
            set 
            { 
                if (this._valuePlanoCorteQuantidade == value)return;
                 this._valuePlanoCorteQuantidade = value; 
            } 
        } 

       protected string _planoCorteDimensao1Original{get;private set;}
       private string _planoCorteDimensao1OriginalCommited{get; set;}
        private string _valuePlanoCorteDimensao1;
         [Column("prm_plano_corte_dimensao_1")]
        public virtual string PlanoCorteDimensao1
         { 
            get { return this._valuePlanoCorteDimensao1; } 
            set 
            { 
                if (this._valuePlanoCorteDimensao1 == value)return;
                 this._valuePlanoCorteDimensao1 = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.DimensaoClass _dimensao1Original{get;private set;}
       private BibliotecaEntidades.Entidades.DimensaoClass _dimensao1OriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.DimensaoClass _valueDimensao1;
        [Column("id_dimensao_1", "dimensao", "id_dimensao")]
       public virtual BibliotecaEntidades.Entidades.DimensaoClass Dimensao1
        { 
           get {                 return this._valueDimensao1; } 
           set 
           { 
                if (this._valueDimensao1 == value)return;
                 this._valueDimensao1 = value; 
           } 
       } 

       protected string _planoCorteDimensao2Original{get;private set;}
       private string _planoCorteDimensao2OriginalCommited{get; set;}
        private string _valuePlanoCorteDimensao2;
         [Column("prm_plano_corte_dimensao_2")]
        public virtual string PlanoCorteDimensao2
         { 
            get { return this._valuePlanoCorteDimensao2; } 
            set 
            { 
                if (this._valuePlanoCorteDimensao2 == value)return;
                 this._valuePlanoCorteDimensao2 = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.DimensaoClass _dimensao2Original{get;private set;}
       private BibliotecaEntidades.Entidades.DimensaoClass _dimensao2OriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.DimensaoClass _valueDimensao2;
        [Column("id_dimensao_2", "dimensao", "id_dimensao")]
       public virtual BibliotecaEntidades.Entidades.DimensaoClass Dimensao2
        { 
           get {                 return this._valueDimensao2; } 
           set 
           { 
                if (this._valueDimensao2 == value)return;
                 this._valueDimensao2 = value; 
           } 
       } 

       protected string _planoCorteDimensao3Original{get;private set;}
       private string _planoCorteDimensao3OriginalCommited{get; set;}
        private string _valuePlanoCorteDimensao3;
         [Column("prm_plano_corte_dimensao_3")]
        public virtual string PlanoCorteDimensao3
         { 
            get { return this._valuePlanoCorteDimensao3; } 
            set 
            { 
                if (this._valuePlanoCorteDimensao3 == value)return;
                 this._valuePlanoCorteDimensao3 = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.DimensaoClass _dimensao3Original{get;private set;}
       private BibliotecaEntidades.Entidades.DimensaoClass _dimensao3OriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.DimensaoClass _valueDimensao3;
        [Column("id_dimensao_3", "dimensao", "id_dimensao")]
       public virtual BibliotecaEntidades.Entidades.DimensaoClass Dimensao3
        { 
           get {                 return this._valueDimensao3; } 
           set 
           { 
                if (this._valueDimensao3 == value)return;
                 this._valueDimensao3 = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.PostoTrabalhoClass _postoTrabalhoCorteOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.PostoTrabalhoClass _postoTrabalhoCorteOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.PostoTrabalhoClass _valuePostoTrabalhoCorte;
        [Column("id_posto_trabalho_corte", "posto_trabalho", "id_posto_trabalho")]
       public virtual BibliotecaEntidades.Entidades.PostoTrabalhoClass PostoTrabalhoCorte
        { 
           get {                 return this._valuePostoTrabalhoCorte; } 
           set 
           { 
                if (this._valuePostoTrabalhoCorte == value)return;
                 this._valuePostoTrabalhoCorte = value; 
           } 
       } 

       protected string _planoCorteInformacoesAdicionaisOriginal{get;private set;}
       private string _planoCorteInformacoesAdicionaisOriginalCommited{get; set;}
        private string _valuePlanoCorteInformacoesAdicionais;
         [Column("prm_plano_corte_informacoes_adicionais")]
        public virtual string PlanoCorteInformacoesAdicionais
         { 
            get { return this._valuePlanoCorteInformacoesAdicionais; } 
            set 
            { 
                if (this._valuePlanoCorteInformacoesAdicionais == value)return;
                 this._valuePlanoCorteInformacoesAdicionais = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.UnidadeMedidaClass _unidadeMedidaDimensao1Original{get;private set;}
       private BibliotecaEntidades.Entidades.UnidadeMedidaClass _unidadeMedidaDimensao1OriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.UnidadeMedidaClass _valueUnidadeMedidaDimensao1;
        [Column("id_unidade_medida_dimensao_1", "unidade_medida", "id_unidade_medida")]
       public virtual BibliotecaEntidades.Entidades.UnidadeMedidaClass UnidadeMedidaDimensao1
        { 
           get {                 return this._valueUnidadeMedidaDimensao1; } 
           set 
           { 
                if (this._valueUnidadeMedidaDimensao1 == value)return;
                 this._valueUnidadeMedidaDimensao1 = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.UnidadeMedidaClass _unidadeMedidaDimensao2Original{get;private set;}
       private BibliotecaEntidades.Entidades.UnidadeMedidaClass _unidadeMedidaDimensao2OriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.UnidadeMedidaClass _valueUnidadeMedidaDimensao2;
        [Column("id_unidade_medida_dimensao_2", "unidade_medida", "id_unidade_medida")]
       public virtual BibliotecaEntidades.Entidades.UnidadeMedidaClass UnidadeMedidaDimensao2
        { 
           get {                 return this._valueUnidadeMedidaDimensao2; } 
           set 
           { 
                if (this._valueUnidadeMedidaDimensao2 == value)return;
                 this._valueUnidadeMedidaDimensao2 = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.UnidadeMedidaClass _unidadeMedidaDimensao3Original{get;private set;}
       private BibliotecaEntidades.Entidades.UnidadeMedidaClass _unidadeMedidaDimensao3OriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.UnidadeMedidaClass _valueUnidadeMedidaDimensao3;
        [Column("id_unidade_medida_dimensao_3", "unidade_medida", "id_unidade_medida")]
       public virtual BibliotecaEntidades.Entidades.UnidadeMedidaClass UnidadeMedidaDimensao3
        { 
           get {                 return this._valueUnidadeMedidaDimensao3; } 
           set 
           { 
                if (this._valueUnidadeMedidaDimensao3 == value)return;
                 this._valueUnidadeMedidaDimensao3 = value; 
           } 
       } 

       protected bool _materialCondicionalOriginal{get;private set;}
       private bool _materialCondicionalOriginalCommited{get; set;}
        private bool _valueMaterialCondicional;
         [Column("prm_material_condicional")]
        public virtual bool MaterialCondicional
         { 
            get { return this._valueMaterialCondicional; } 
            set 
            { 
                if (this._valueMaterialCondicional == value)return;
                 this._valueMaterialCondicional = value; 
            } 
        } 

       protected string _materialCondicionalRegraOriginal{get;private set;}
       private string _materialCondicionalRegraOriginalCommited{get; set;}
        private string _valueMaterialCondicionalRegra;
         [Column("prm_material_condicional_regra")]
        public virtual string MaterialCondicionalRegra
         { 
            get { return this._valueMaterialCondicionalRegra; } 
            set 
            { 
                if (this._valueMaterialCondicionalRegra == value)return;
                 this._valueMaterialCondicionalRegra = value; 
            } 
        } 

       protected bool _qtdCondicionalOriginal{get;private set;}
       private bool _qtdCondicionalOriginalCommited{get; set;}
        private bool _valueQtdCondicional;
         [Column("prm_qtd_condicional")]
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
         [Column("prm_qtd_condicional_regra")]
        public virtual string QtdCondicionalRegra
         { 
            get { return this._valueQtdCondicionalRegra; } 
            set 
            { 
                if (this._valueQtdCondicionalRegra == value)return;
                 this._valueQtdCondicionalRegra = value; 
            } 
        } 

        public ProdutoMaterialBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Quantidade = 0;
           this.VersaoEstrutura = 0;
           this.PlanoCorte = false;
           this.MaterialCondicional = false;
           this.QtdCondicional = false;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static ProdutoMaterialClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (ProdutoMaterialClass) GetEntity(typeof(ProdutoMaterialClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if ( _valueProduto == null)
                {
                    throw new Exception(ErroProdutoObrigatorio);
                }
                if ( _valueMaterial == null)
                {
                    throw new Exception(ErroMaterialObrigatorio);
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
                    "  public.produto_material  " +
                    "WHERE " +
                    "  id_produto_material = :id";
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
                        "  public.produto_material   " +
                        "SET  " + 
                        "  id_produto = :id_produto, " + 
                        "  id_material = :id_material, " + 
                        "  prm_quantidade = :prm_quantidade, " + 
                        "  prm_qtd_produto_por_unidade = :prm_qtd_produto_por_unidade, " + 
                        "  prm_versao_estrutura = :prm_versao_estrutura, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  prm_plano_corte = :prm_plano_corte, " + 
                        "  prm_plano_corte_quantidade = :prm_plano_corte_quantidade, " + 
                        "  prm_plano_corte_dimensao_1 = :prm_plano_corte_dimensao_1, " + 
                        "  id_dimensao_1 = :id_dimensao_1, " + 
                        "  prm_plano_corte_dimensao_2 = :prm_plano_corte_dimensao_2, " + 
                        "  id_dimensao_2 = :id_dimensao_2, " + 
                        "  prm_plano_corte_dimensao_3 = :prm_plano_corte_dimensao_3, " + 
                        "  id_dimensao_3 = :id_dimensao_3, " + 
                        "  id_posto_trabalho_corte = :id_posto_trabalho_corte, " + 
                        "  prm_plano_corte_informacoes_adicionais = :prm_plano_corte_informacoes_adicionais, " + 
                        "  id_unidade_medida_dimensao_1 = :id_unidade_medida_dimensao_1, " + 
                        "  id_unidade_medida_dimensao_2 = :id_unidade_medida_dimensao_2, " + 
                        "  id_unidade_medida_dimensao_3 = :id_unidade_medida_dimensao_3, " + 
                        "  prm_material_condicional = :prm_material_condicional, " + 
                        "  prm_material_condicional_regra = :prm_material_condicional_regra, " + 
                        "  prm_qtd_condicional = :prm_qtd_condicional, " + 
                        "  prm_qtd_condicional_regra = :prm_qtd_condicional_regra "+
                        "WHERE  " +
                        "  id_produto_material = :id " +
                        "RETURNING id_produto_material;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.produto_material " +
                        "( " +
                        "  id_produto , " + 
                        "  id_material , " + 
                        "  prm_quantidade , " + 
                        "  prm_qtd_produto_por_unidade , " + 
                        "  prm_versao_estrutura , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  prm_plano_corte , " + 
                        "  prm_plano_corte_quantidade , " + 
                        "  prm_plano_corte_dimensao_1 , " + 
                        "  id_dimensao_1 , " + 
                        "  prm_plano_corte_dimensao_2 , " + 
                        "  id_dimensao_2 , " + 
                        "  prm_plano_corte_dimensao_3 , " + 
                        "  id_dimensao_3 , " + 
                        "  id_posto_trabalho_corte , " + 
                        "  prm_plano_corte_informacoes_adicionais , " + 
                        "  id_unidade_medida_dimensao_1 , " + 
                        "  id_unidade_medida_dimensao_2 , " + 
                        "  id_unidade_medida_dimensao_3 , " + 
                        "  prm_material_condicional , " + 
                        "  prm_material_condicional_regra , " + 
                        "  prm_qtd_condicional , " + 
                        "  prm_qtd_condicional_regra  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_produto , " + 
                        "  :id_material , " + 
                        "  :prm_quantidade , " + 
                        "  :prm_qtd_produto_por_unidade , " + 
                        "  :prm_versao_estrutura , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :prm_plano_corte , " + 
                        "  :prm_plano_corte_quantidade , " + 
                        "  :prm_plano_corte_dimensao_1 , " + 
                        "  :id_dimensao_1 , " + 
                        "  :prm_plano_corte_dimensao_2 , " + 
                        "  :id_dimensao_2 , " + 
                        "  :prm_plano_corte_dimensao_3 , " + 
                        "  :id_dimensao_3 , " + 
                        "  :id_posto_trabalho_corte , " + 
                        "  :prm_plano_corte_informacoes_adicionais , " + 
                        "  :id_unidade_medida_dimensao_1 , " + 
                        "  :id_unidade_medida_dimensao_2 , " + 
                        "  :id_unidade_medida_dimensao_3 , " + 
                        "  :prm_material_condicional , " + 
                        "  :prm_material_condicional_regra , " + 
                        "  :prm_qtd_condicional , " + 
                        "  :prm_qtd_condicional_regra  "+
                        ")RETURNING id_produto_material;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Produto==null ? (object) DBNull.Value : this.Produto.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_material", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Material==null ? (object) DBNull.Value : this.Material.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prm_quantidade", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Quantidade ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prm_qtd_produto_por_unidade", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.QtdProdutoPorUnidade ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prm_versao_estrutura", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VersaoEstrutura ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prm_plano_corte", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PlanoCorte ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prm_plano_corte_quantidade", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PlanoCorteQuantidade ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prm_plano_corte_dimensao_1", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PlanoCorteDimensao1 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_dimensao_1", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Dimensao1==null ? (object) DBNull.Value : this.Dimensao1.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prm_plano_corte_dimensao_2", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PlanoCorteDimensao2 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_dimensao_2", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Dimensao2==null ? (object) DBNull.Value : this.Dimensao2.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prm_plano_corte_dimensao_3", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PlanoCorteDimensao3 ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_dimensao_3", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Dimensao3==null ? (object) DBNull.Value : this.Dimensao3.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_posto_trabalho_corte", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.PostoTrabalhoCorte==null ? (object) DBNull.Value : this.PostoTrabalhoCorte.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prm_plano_corte_informacoes_adicionais", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PlanoCorteInformacoesAdicionais ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_unidade_medida_dimensao_1", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.UnidadeMedidaDimensao1==null ? (object) DBNull.Value : this.UnidadeMedidaDimensao1.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_unidade_medida_dimensao_2", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.UnidadeMedidaDimensao2==null ? (object) DBNull.Value : this.UnidadeMedidaDimensao2.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_unidade_medida_dimensao_3", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.UnidadeMedidaDimensao3==null ? (object) DBNull.Value : this.UnidadeMedidaDimensao3.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prm_material_condicional", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.MaterialCondicional ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prm_material_condicional_regra", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.MaterialCondicionalRegra ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prm_qtd_condicional", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.QtdCondicional ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prm_qtd_condicional_regra", NpgsqlDbType.Varchar));
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
        public static ProdutoMaterialClass CopiarEntidade(ProdutoMaterialClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               ProdutoMaterialClass toRet = new ProdutoMaterialClass(usuario,conn);
 toRet.Produto= entidadeCopiar.Produto;
 toRet.Material= entidadeCopiar.Material;
 toRet.Quantidade= entidadeCopiar.Quantidade;
 toRet.QtdProdutoPorUnidade= entidadeCopiar.QtdProdutoPorUnidade;
 toRet.VersaoEstrutura= entidadeCopiar.VersaoEstrutura;
 toRet.PlanoCorte= entidadeCopiar.PlanoCorte;
 toRet.PlanoCorteQuantidade= entidadeCopiar.PlanoCorteQuantidade;
 toRet.PlanoCorteDimensao1= entidadeCopiar.PlanoCorteDimensao1;
 toRet.Dimensao1= entidadeCopiar.Dimensao1;
 toRet.PlanoCorteDimensao2= entidadeCopiar.PlanoCorteDimensao2;
 toRet.Dimensao2= entidadeCopiar.Dimensao2;
 toRet.PlanoCorteDimensao3= entidadeCopiar.PlanoCorteDimensao3;
 toRet.Dimensao3= entidadeCopiar.Dimensao3;
 toRet.PostoTrabalhoCorte= entidadeCopiar.PostoTrabalhoCorte;
 toRet.PlanoCorteInformacoesAdicionais= entidadeCopiar.PlanoCorteInformacoesAdicionais;
 toRet.UnidadeMedidaDimensao1= entidadeCopiar.UnidadeMedidaDimensao1;
 toRet.UnidadeMedidaDimensao2= entidadeCopiar.UnidadeMedidaDimensao2;
 toRet.UnidadeMedidaDimensao3= entidadeCopiar.UnidadeMedidaDimensao3;
 toRet.MaterialCondicional= entidadeCopiar.MaterialCondicional;
 toRet.MaterialCondicionalRegra= entidadeCopiar.MaterialCondicionalRegra;
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
       _produtoOriginal = Produto;
       _produtoOriginalCommited = _produtoOriginal;
       _materialOriginal = Material;
       _materialOriginalCommited = _materialOriginal;
       _quantidadeOriginal = Quantidade;
       _quantidadeOriginalCommited = _quantidadeOriginal;
       _qtdProdutoPorUnidadeOriginal = QtdProdutoPorUnidade;
       _qtdProdutoPorUnidadeOriginalCommited = _qtdProdutoPorUnidadeOriginal;
       _versaoEstruturaOriginal = VersaoEstrutura;
       _versaoEstruturaOriginalCommited = _versaoEstruturaOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _planoCorteOriginal = PlanoCorte;
       _planoCorteOriginalCommited = _planoCorteOriginal;
       _planoCorteQuantidadeOriginal = PlanoCorteQuantidade;
       _planoCorteQuantidadeOriginalCommited = _planoCorteQuantidadeOriginal;
       _planoCorteDimensao1Original = PlanoCorteDimensao1;
       _planoCorteDimensao1OriginalCommited = _planoCorteDimensao1Original;
       _dimensao1Original = Dimensao1;
       _dimensao1OriginalCommited = _dimensao1Original;
       _planoCorteDimensao2Original = PlanoCorteDimensao2;
       _planoCorteDimensao2OriginalCommited = _planoCorteDimensao2Original;
       _dimensao2Original = Dimensao2;
       _dimensao2OriginalCommited = _dimensao2Original;
       _planoCorteDimensao3Original = PlanoCorteDimensao3;
       _planoCorteDimensao3OriginalCommited = _planoCorteDimensao3Original;
       _dimensao3Original = Dimensao3;
       _dimensao3OriginalCommited = _dimensao3Original;
       _postoTrabalhoCorteOriginal = PostoTrabalhoCorte;
       _postoTrabalhoCorteOriginalCommited = _postoTrabalhoCorteOriginal;
       _planoCorteInformacoesAdicionaisOriginal = PlanoCorteInformacoesAdicionais;
       _planoCorteInformacoesAdicionaisOriginalCommited = _planoCorteInformacoesAdicionaisOriginal;
       _unidadeMedidaDimensao1Original = UnidadeMedidaDimensao1;
       _unidadeMedidaDimensao1OriginalCommited = _unidadeMedidaDimensao1Original;
       _unidadeMedidaDimensao2Original = UnidadeMedidaDimensao2;
       _unidadeMedidaDimensao2OriginalCommited = _unidadeMedidaDimensao2Original;
       _unidadeMedidaDimensao3Original = UnidadeMedidaDimensao3;
       _unidadeMedidaDimensao3OriginalCommited = _unidadeMedidaDimensao3Original;
       _materialCondicionalOriginal = MaterialCondicional;
       _materialCondicionalOriginalCommited = _materialCondicionalOriginal;
       _materialCondicionalRegraOriginal = MaterialCondicionalRegra;
       _materialCondicionalRegraOriginalCommited = _materialCondicionalRegraOriginal;
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
       _produtoOriginalCommited = Produto;
       _materialOriginalCommited = Material;
       _quantidadeOriginalCommited = Quantidade;
       _qtdProdutoPorUnidadeOriginalCommited = QtdProdutoPorUnidade;
       _versaoEstruturaOriginalCommited = VersaoEstrutura;
       _versionOriginalCommited = Version;
       _planoCorteOriginalCommited = PlanoCorte;
       _planoCorteQuantidadeOriginalCommited = PlanoCorteQuantidade;
       _planoCorteDimensao1OriginalCommited = PlanoCorteDimensao1;
       _dimensao1OriginalCommited = Dimensao1;
       _planoCorteDimensao2OriginalCommited = PlanoCorteDimensao2;
       _dimensao2OriginalCommited = Dimensao2;
       _planoCorteDimensao3OriginalCommited = PlanoCorteDimensao3;
       _dimensao3OriginalCommited = Dimensao3;
       _postoTrabalhoCorteOriginalCommited = PostoTrabalhoCorte;
       _planoCorteInformacoesAdicionaisOriginalCommited = PlanoCorteInformacoesAdicionais;
       _unidadeMedidaDimensao1OriginalCommited = UnidadeMedidaDimensao1;
       _unidadeMedidaDimensao2OriginalCommited = UnidadeMedidaDimensao2;
       _unidadeMedidaDimensao3OriginalCommited = UnidadeMedidaDimensao3;
       _materialCondicionalOriginalCommited = MaterialCondicional;
       _materialCondicionalRegraOriginalCommited = MaterialCondicionalRegra;
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
               Produto=_produtoOriginal;
               _produtoOriginalCommited=_produtoOriginal;
               Material=_materialOriginal;
               _materialOriginalCommited=_materialOriginal;
               Quantidade=_quantidadeOriginal;
               _quantidadeOriginalCommited=_quantidadeOriginal;
               QtdProdutoPorUnidade=_qtdProdutoPorUnidadeOriginal;
               _qtdProdutoPorUnidadeOriginalCommited=_qtdProdutoPorUnidadeOriginal;
               VersaoEstrutura=_versaoEstruturaOriginal;
               _versaoEstruturaOriginalCommited=_versaoEstruturaOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               PlanoCorte=_planoCorteOriginal;
               _planoCorteOriginalCommited=_planoCorteOriginal;
               PlanoCorteQuantidade=_planoCorteQuantidadeOriginal;
               _planoCorteQuantidadeOriginalCommited=_planoCorteQuantidadeOriginal;
               PlanoCorteDimensao1=_planoCorteDimensao1Original;
               _planoCorteDimensao1OriginalCommited=_planoCorteDimensao1Original;
               Dimensao1=_dimensao1Original;
               _dimensao1OriginalCommited=_dimensao1Original;
               PlanoCorteDimensao2=_planoCorteDimensao2Original;
               _planoCorteDimensao2OriginalCommited=_planoCorteDimensao2Original;
               Dimensao2=_dimensao2Original;
               _dimensao2OriginalCommited=_dimensao2Original;
               PlanoCorteDimensao3=_planoCorteDimensao3Original;
               _planoCorteDimensao3OriginalCommited=_planoCorteDimensao3Original;
               Dimensao3=_dimensao3Original;
               _dimensao3OriginalCommited=_dimensao3Original;
               PostoTrabalhoCorte=_postoTrabalhoCorteOriginal;
               _postoTrabalhoCorteOriginalCommited=_postoTrabalhoCorteOriginal;
               PlanoCorteInformacoesAdicionais=_planoCorteInformacoesAdicionaisOriginal;
               _planoCorteInformacoesAdicionaisOriginalCommited=_planoCorteInformacoesAdicionaisOriginal;
               UnidadeMedidaDimensao1=_unidadeMedidaDimensao1Original;
               _unidadeMedidaDimensao1OriginalCommited=_unidadeMedidaDimensao1Original;
               UnidadeMedidaDimensao2=_unidadeMedidaDimensao2Original;
               _unidadeMedidaDimensao2OriginalCommited=_unidadeMedidaDimensao2Original;
               UnidadeMedidaDimensao3=_unidadeMedidaDimensao3Original;
               _unidadeMedidaDimensao3OriginalCommited=_unidadeMedidaDimensao3Original;
               MaterialCondicional=_materialCondicionalOriginal;
               _materialCondicionalOriginalCommited=_materialCondicionalOriginal;
               MaterialCondicionalRegra=_materialCondicionalRegraOriginal;
               _materialCondicionalRegraOriginalCommited=_materialCondicionalRegraOriginal;
               QtdCondicional=_qtdCondicionalOriginal;
               _qtdCondicionalOriginalCommited=_qtdCondicionalOriginal;
               QtdCondicionalRegra=_qtdCondicionalRegraOriginal;
               _qtdCondicionalRegraOriginalCommited=_qtdCondicionalRegraOriginal;

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
       if (_produtoOriginal!=null)
       {
          dirty = !_produtoOriginal.Equals(Produto);
       }
       else
       {
            dirty = Produto != null;
       }
      if (dirty) return true;
       if (_materialOriginal!=null)
       {
          dirty = !_materialOriginal.Equals(Material);
       }
       else
       {
            dirty = Material != null;
       }
      if (dirty) return true;
       dirty = _quantidadeOriginal != Quantidade;
      if (dirty) return true;
       dirty = _qtdProdutoPorUnidadeOriginal != QtdProdutoPorUnidade;
      if (dirty) return true;
       dirty = _versaoEstruturaOriginal != VersaoEstrutura;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _planoCorteOriginal != PlanoCorte;
      if (dirty) return true;
       dirty = _planoCorteQuantidadeOriginal != PlanoCorteQuantidade;
      if (dirty) return true;
       dirty = _planoCorteDimensao1Original != PlanoCorteDimensao1;
      if (dirty) return true;
       if (_dimensao1Original!=null)
       {
          dirty = !_dimensao1Original.Equals(Dimensao1);
       }
       else
       {
            dirty = Dimensao1 != null;
       }
      if (dirty) return true;
       dirty = _planoCorteDimensao2Original != PlanoCorteDimensao2;
      if (dirty) return true;
       if (_dimensao2Original!=null)
       {
          dirty = !_dimensao2Original.Equals(Dimensao2);
       }
       else
       {
            dirty = Dimensao2 != null;
       }
      if (dirty) return true;
       dirty = _planoCorteDimensao3Original != PlanoCorteDimensao3;
      if (dirty) return true;
       if (_dimensao3Original!=null)
       {
          dirty = !_dimensao3Original.Equals(Dimensao3);
       }
       else
       {
            dirty = Dimensao3 != null;
       }
      if (dirty) return true;
       if (_postoTrabalhoCorteOriginal!=null)
       {
          dirty = !_postoTrabalhoCorteOriginal.Equals(PostoTrabalhoCorte);
       }
       else
       {
            dirty = PostoTrabalhoCorte != null;
       }
      if (dirty) return true;
       dirty = _planoCorteInformacoesAdicionaisOriginal != PlanoCorteInformacoesAdicionais;
      if (dirty) return true;
       if (_unidadeMedidaDimensao1Original!=null)
       {
          dirty = !_unidadeMedidaDimensao1Original.Equals(UnidadeMedidaDimensao1);
       }
       else
       {
            dirty = UnidadeMedidaDimensao1 != null;
       }
      if (dirty) return true;
       if (_unidadeMedidaDimensao2Original!=null)
       {
          dirty = !_unidadeMedidaDimensao2Original.Equals(UnidadeMedidaDimensao2);
       }
       else
       {
            dirty = UnidadeMedidaDimensao2 != null;
       }
      if (dirty) return true;
       if (_unidadeMedidaDimensao3Original!=null)
       {
          dirty = !_unidadeMedidaDimensao3Original.Equals(UnidadeMedidaDimensao3);
       }
       else
       {
            dirty = UnidadeMedidaDimensao3 != null;
       }
      if (dirty) return true;
       dirty = _materialCondicionalOriginal != MaterialCondicional;
      if (dirty) return true;
       dirty = _materialCondicionalRegraOriginal != MaterialCondicionalRegra;
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
       if (_produtoOriginalCommited!=null)
       {
          dirty = !_produtoOriginalCommited.Equals(Produto);
       }
       else
       {
            dirty = Produto != null;
       }
      if (dirty) return true;
       if (_materialOriginalCommited!=null)
       {
          dirty = !_materialOriginalCommited.Equals(Material);
       }
       else
       {
            dirty = Material != null;
       }
      if (dirty) return true;
       dirty = _quantidadeOriginalCommited != Quantidade;
      if (dirty) return true;
       dirty = _qtdProdutoPorUnidadeOriginalCommited != QtdProdutoPorUnidade;
      if (dirty) return true;
       dirty = _versaoEstruturaOriginalCommited != VersaoEstrutura;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _planoCorteOriginalCommited != PlanoCorte;
      if (dirty) return true;
       dirty = _planoCorteQuantidadeOriginalCommited != PlanoCorteQuantidade;
      if (dirty) return true;
       dirty = _planoCorteDimensao1OriginalCommited != PlanoCorteDimensao1;
      if (dirty) return true;
       if (_dimensao1OriginalCommited!=null)
       {
          dirty = !_dimensao1OriginalCommited.Equals(Dimensao1);
       }
       else
       {
            dirty = Dimensao1 != null;
       }
      if (dirty) return true;
       dirty = _planoCorteDimensao2OriginalCommited != PlanoCorteDimensao2;
      if (dirty) return true;
       if (_dimensao2OriginalCommited!=null)
       {
          dirty = !_dimensao2OriginalCommited.Equals(Dimensao2);
       }
       else
       {
            dirty = Dimensao2 != null;
       }
      if (dirty) return true;
       dirty = _planoCorteDimensao3OriginalCommited != PlanoCorteDimensao3;
      if (dirty) return true;
       if (_dimensao3OriginalCommited!=null)
       {
          dirty = !_dimensao3OriginalCommited.Equals(Dimensao3);
       }
       else
       {
            dirty = Dimensao3 != null;
       }
      if (dirty) return true;
       if (_postoTrabalhoCorteOriginalCommited!=null)
       {
          dirty = !_postoTrabalhoCorteOriginalCommited.Equals(PostoTrabalhoCorte);
       }
       else
       {
            dirty = PostoTrabalhoCorte != null;
       }
      if (dirty) return true;
       dirty = _planoCorteInformacoesAdicionaisOriginalCommited != PlanoCorteInformacoesAdicionais;
      if (dirty) return true;
       if (_unidadeMedidaDimensao1OriginalCommited!=null)
       {
          dirty = !_unidadeMedidaDimensao1OriginalCommited.Equals(UnidadeMedidaDimensao1);
       }
       else
       {
            dirty = UnidadeMedidaDimensao1 != null;
       }
      if (dirty) return true;
       if (_unidadeMedidaDimensao2OriginalCommited!=null)
       {
          dirty = !_unidadeMedidaDimensao2OriginalCommited.Equals(UnidadeMedidaDimensao2);
       }
       else
       {
            dirty = UnidadeMedidaDimensao2 != null;
       }
      if (dirty) return true;
       if (_unidadeMedidaDimensao3OriginalCommited!=null)
       {
          dirty = !_unidadeMedidaDimensao3OriginalCommited.Equals(UnidadeMedidaDimensao3);
       }
       else
       {
            dirty = UnidadeMedidaDimensao3 != null;
       }
      if (dirty) return true;
       dirty = _materialCondicionalOriginalCommited != MaterialCondicional;
      if (dirty) return true;
       dirty = _materialCondicionalRegraOriginalCommited != MaterialCondicionalRegra;
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
             case "Produto":
                return this.Produto;
             case "Material":
                return this.Material;
             case "Quantidade":
                return this.Quantidade;
             case "QtdProdutoPorUnidade":
                return this.QtdProdutoPorUnidade;
             case "VersaoEstrutura":
                return this.VersaoEstrutura;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "PlanoCorte":
                return this.PlanoCorte;
             case "PlanoCorteQuantidade":
                return this.PlanoCorteQuantidade;
             case "PlanoCorteDimensao1":
                return this.PlanoCorteDimensao1;
             case "Dimensao1":
                return this.Dimensao1;
             case "PlanoCorteDimensao2":
                return this.PlanoCorteDimensao2;
             case "Dimensao2":
                return this.Dimensao2;
             case "PlanoCorteDimensao3":
                return this.PlanoCorteDimensao3;
             case "Dimensao3":
                return this.Dimensao3;
             case "PostoTrabalhoCorte":
                return this.PostoTrabalhoCorte;
             case "PlanoCorteInformacoesAdicionais":
                return this.PlanoCorteInformacoesAdicionais;
             case "UnidadeMedidaDimensao1":
                return this.UnidadeMedidaDimensao1;
             case "UnidadeMedidaDimensao2":
                return this.UnidadeMedidaDimensao2;
             case "UnidadeMedidaDimensao3":
                return this.UnidadeMedidaDimensao3;
             case "MaterialCondicional":
                return this.MaterialCondicional;
             case "MaterialCondicionalRegra":
                return this.MaterialCondicionalRegra;
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
             if (Produto!=null)
                Produto.ChangeSingleConnection(newConnection);
             if (Material!=null)
                Material.ChangeSingleConnection(newConnection);
             if (Dimensao1!=null)
                Dimensao1.ChangeSingleConnection(newConnection);
             if (Dimensao2!=null)
                Dimensao2.ChangeSingleConnection(newConnection);
             if (Dimensao3!=null)
                Dimensao3.ChangeSingleConnection(newConnection);
             if (PostoTrabalhoCorte!=null)
                PostoTrabalhoCorte.ChangeSingleConnection(newConnection);
             if (UnidadeMedidaDimensao1!=null)
                UnidadeMedidaDimensao1.ChangeSingleConnection(newConnection);
             if (UnidadeMedidaDimensao2!=null)
                UnidadeMedidaDimensao2.ChangeSingleConnection(newConnection);
             if (UnidadeMedidaDimensao3!=null)
                UnidadeMedidaDimensao3.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(produto_material.id_produto_material) " ;
               }
               else
               {
               command.CommandText += "produto_material.id_produto_material, " ;
               command.CommandText += "produto_material.id_produto, " ;
               command.CommandText += "produto_material.id_material, " ;
               command.CommandText += "produto_material.prm_quantidade, " ;
               command.CommandText += "produto_material.prm_qtd_produto_por_unidade, " ;
               command.CommandText += "produto_material.prm_versao_estrutura, " ;
               command.CommandText += "produto_material.entity_uid, " ;
               command.CommandText += "produto_material.version, " ;
               command.CommandText += "produto_material.prm_plano_corte, " ;
               command.CommandText += "produto_material.prm_plano_corte_quantidade, " ;
               command.CommandText += "produto_material.prm_plano_corte_dimensao_1, " ;
               command.CommandText += "produto_material.id_dimensao_1, " ;
               command.CommandText += "produto_material.prm_plano_corte_dimensao_2, " ;
               command.CommandText += "produto_material.id_dimensao_2, " ;
               command.CommandText += "produto_material.prm_plano_corte_dimensao_3, " ;
               command.CommandText += "produto_material.id_dimensao_3, " ;
               command.CommandText += "produto_material.id_posto_trabalho_corte, " ;
               command.CommandText += "produto_material.prm_plano_corte_informacoes_adicionais, " ;
               command.CommandText += "produto_material.id_unidade_medida_dimensao_1, " ;
               command.CommandText += "produto_material.id_unidade_medida_dimensao_2, " ;
               command.CommandText += "produto_material.id_unidade_medida_dimensao_3, " ;
               command.CommandText += "produto_material.prm_material_condicional, " ;
               command.CommandText += "produto_material.prm_material_condicional_regra, " ;
               command.CommandText += "produto_material.prm_qtd_condicional, " ;
               command.CommandText += "produto_material.prm_qtd_condicional_regra " ;
               }
               command.CommandText += " FROM  produto_material ";
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
                        orderByClause += " , prm_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(prm_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = produto_material.id_acs_usuario_ultima_revisao ";
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
                     case "id_produto_material":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_material.id_produto_material " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_material.id_produto_material) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_produto":
                     case "Produto":
                     command.CommandText += " LEFT JOIN produto as produto_Produto ON produto_Produto.id_produto = produto_material.id_produto ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_Produto.pro_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_Produto.pro_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_material":
                     case "Material":
                     command.CommandText += " LEFT JOIN material as material_Material ON material_Material.id_material = produto_material.id_material ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , material_Material.mat_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(material_Material.mat_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prm_quantidade":
                     case "Quantidade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_material.prm_quantidade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_material.prm_quantidade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prm_qtd_produto_por_unidade":
                     case "QtdProdutoPorUnidade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_material.prm_qtd_produto_por_unidade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_material.prm_qtd_produto_por_unidade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prm_versao_estrutura":
                     case "VersaoEstrutura":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_material.prm_versao_estrutura " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_material.prm_versao_estrutura) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_material.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_material.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , produto_material.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_material.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prm_plano_corte":
                     case "PlanoCorte":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_material.prm_plano_corte " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_material.prm_plano_corte) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prm_plano_corte_quantidade":
                     case "PlanoCorteQuantidade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_material.prm_plano_corte_quantidade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_material.prm_plano_corte_quantidade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prm_plano_corte_dimensao_1":
                     case "PlanoCorteDimensao1":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_material.prm_plano_corte_dimensao_1 " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_material.prm_plano_corte_dimensao_1) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_dimensao_1":
                     case "Dimensao1":
                     command.CommandText += " LEFT JOIN dimensao as dimensao_Dimensao1 ON dimensao_Dimensao1.id_dimensao = produto_material.id_dimensao_1 ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , dimensao_Dimensao1.dim_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(dimensao_Dimensao1.dim_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prm_plano_corte_dimensao_2":
                     case "PlanoCorteDimensao2":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_material.prm_plano_corte_dimensao_2 " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_material.prm_plano_corte_dimensao_2) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_dimensao_2":
                     case "Dimensao2":
                     command.CommandText += " LEFT JOIN dimensao as dimensao_Dimensao2 ON dimensao_Dimensao2.id_dimensao = produto_material.id_dimensao_2 ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , dimensao_Dimensao2.dim_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(dimensao_Dimensao2.dim_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prm_plano_corte_dimensao_3":
                     case "PlanoCorteDimensao3":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_material.prm_plano_corte_dimensao_3 " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_material.prm_plano_corte_dimensao_3) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_dimensao_3":
                     case "Dimensao3":
                     command.CommandText += " LEFT JOIN dimensao as dimensao_Dimensao3 ON dimensao_Dimensao3.id_dimensao = produto_material.id_dimensao_3 ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , dimensao_Dimensao3.dim_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(dimensao_Dimensao3.dim_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_posto_trabalho_corte":
                     case "PostoTrabalhoCorte":
                     command.CommandText += " LEFT JOIN posto_trabalho as posto_trabalho_PostoTrabalhoCorte ON posto_trabalho_PostoTrabalhoCorte.id_posto_trabalho = produto_material.id_posto_trabalho_corte ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , posto_trabalho_PostoTrabalhoCorte.pos_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(posto_trabalho_PostoTrabalhoCorte.pos_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prm_plano_corte_informacoes_adicionais":
                     case "PlanoCorteInformacoesAdicionais":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_material.prm_plano_corte_informacoes_adicionais " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_material.prm_plano_corte_informacoes_adicionais) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_unidade_medida_dimensao_1":
                     case "UnidadeMedidaDimensao1":
                     command.CommandText += " LEFT JOIN unidade_medida as unidade_medida_UnidadeMedidaDimensao1 ON unidade_medida_UnidadeMedidaDimensao1.id_unidade_medida = produto_material.id_unidade_medida_dimensao_1 ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , unidade_medida_UnidadeMedidaDimensao1.unm_abreviada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(unidade_medida_UnidadeMedidaDimensao1.unm_abreviada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_unidade_medida_dimensao_2":
                     case "UnidadeMedidaDimensao2":
                     command.CommandText += " LEFT JOIN unidade_medida as unidade_medida_UnidadeMedidaDimensao2 ON unidade_medida_UnidadeMedidaDimensao2.id_unidade_medida = produto_material.id_unidade_medida_dimensao_2 ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , unidade_medida_UnidadeMedidaDimensao2.unm_abreviada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(unidade_medida_UnidadeMedidaDimensao2.unm_abreviada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_unidade_medida_dimensao_3":
                     case "UnidadeMedidaDimensao3":
                     command.CommandText += " LEFT JOIN unidade_medida as unidade_medida_UnidadeMedidaDimensao3 ON unidade_medida_UnidadeMedidaDimensao3.id_unidade_medida = produto_material.id_unidade_medida_dimensao_3 ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , unidade_medida_UnidadeMedidaDimensao3.unm_abreviada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(unidade_medida_UnidadeMedidaDimensao3.unm_abreviada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prm_material_condicional":
                     case "MaterialCondicional":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_material.prm_material_condicional " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_material.prm_material_condicional) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prm_material_condicional_regra":
                     case "MaterialCondicionalRegra":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_material.prm_material_condicional_regra " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_material.prm_material_condicional_regra) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prm_qtd_condicional":
                     case "QtdCondicional":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_material.prm_qtd_condicional " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_material.prm_qtd_condicional) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "prm_qtd_condicional_regra":
                     case "QtdCondicionalRegra":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_material.prm_qtd_condicional_regra " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_material.prm_qtd_condicional_regra) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           whereClause += " OR UPPER(produto_material.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto_material.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("prm_plano_corte_dimensao_1")) 
                        {
                           whereClause += " OR UPPER(produto_material.prm_plano_corte_dimensao_1) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto_material.prm_plano_corte_dimensao_1) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("prm_plano_corte_dimensao_2")) 
                        {
                           whereClause += " OR UPPER(produto_material.prm_plano_corte_dimensao_2) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto_material.prm_plano_corte_dimensao_2) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("prm_plano_corte_dimensao_3")) 
                        {
                           whereClause += " OR UPPER(produto_material.prm_plano_corte_dimensao_3) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto_material.prm_plano_corte_dimensao_3) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("prm_plano_corte_informacoes_adicionais")) 
                        {
                           whereClause += " OR UPPER(produto_material.prm_plano_corte_informacoes_adicionais) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto_material.prm_plano_corte_informacoes_adicionais) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("prm_material_condicional_regra")) 
                        {
                           whereClause += " OR UPPER(produto_material.prm_material_condicional_regra) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto_material.prm_material_condicional_regra) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("prm_qtd_condicional_regra")) 
                        {
                           whereClause += " OR UPPER(produto_material.prm_qtd_condicional_regra) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto_material.prm_qtd_condicional_regra) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_produto_material")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_material.id_produto_material IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_material.id_produto_material = :produto_material_ID_2507 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_material_ID_2507", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Produto" || parametro.FieldName == "id_produto")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.ProdutoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.ProdutoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_material.id_produto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_material.id_produto = :produto_material_Produto_654 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_material_Produto_654", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Material" || parametro.FieldName == "id_material")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.MaterialClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.MaterialClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_material.id_material IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_material.id_material = :produto_material_Material_1545 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_material_Material_1545", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Quantidade" || parametro.FieldName == "prm_quantidade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_material.prm_quantidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_material.prm_quantidade = :produto_material_Quantidade_9943 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_material_Quantidade_9943", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "QtdProdutoPorUnidade" || parametro.FieldName == "prm_qtd_produto_por_unidade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_material.prm_qtd_produto_por_unidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_material.prm_qtd_produto_por_unidade = :produto_material_QtdProdutoPorUnidade_4098 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_material_QtdProdutoPorUnidade_4098", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VersaoEstrutura" || parametro.FieldName == "prm_versao_estrutura")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_material.prm_versao_estrutura IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_material.prm_versao_estrutura = :produto_material_VersaoEstrutura_9684 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_material_VersaoEstrutura_9684", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  produto_material.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_material.entity_uid LIKE :produto_material_EntityUid_7512 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_material_EntityUid_7512", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  produto_material.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_material.version = :produto_material_Version_8636 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_material_Version_8636", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoCorte" || parametro.FieldName == "prm_plano_corte")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_material.prm_plano_corte IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_material.prm_plano_corte = :produto_material_PlanoCorte_5338 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_material_PlanoCorte_5338", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoCorteQuantidade" || parametro.FieldName == "prm_plano_corte_quantidade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_material.prm_plano_corte_quantidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_material.prm_plano_corte_quantidade = :produto_material_PlanoCorteQuantidade_3422 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_material_PlanoCorteQuantidade_3422", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoCorteDimensao1" || parametro.FieldName == "prm_plano_corte_dimensao_1")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_material.prm_plano_corte_dimensao_1 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_material.prm_plano_corte_dimensao_1 LIKE :produto_material_PlanoCorteDimensao1_6219 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_material_PlanoCorteDimensao1_6219", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Dimensao1" || parametro.FieldName == "id_dimensao_1")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.DimensaoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.DimensaoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_material.id_dimensao_1 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_material.id_dimensao_1 = :produto_material_Dimensao1_7763 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_material_Dimensao1_7763", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoCorteDimensao2" || parametro.FieldName == "prm_plano_corte_dimensao_2")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_material.prm_plano_corte_dimensao_2 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_material.prm_plano_corte_dimensao_2 LIKE :produto_material_PlanoCorteDimensao2_4892 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_material_PlanoCorteDimensao2_4892", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Dimensao2" || parametro.FieldName == "id_dimensao_2")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.DimensaoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.DimensaoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_material.id_dimensao_2 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_material.id_dimensao_2 = :produto_material_Dimensao2_5926 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_material_Dimensao2_5926", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoCorteDimensao3" || parametro.FieldName == "prm_plano_corte_dimensao_3")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_material.prm_plano_corte_dimensao_3 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_material.prm_plano_corte_dimensao_3 LIKE :produto_material_PlanoCorteDimensao3_7326 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_material_PlanoCorteDimensao3_7326", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Dimensao3" || parametro.FieldName == "id_dimensao_3")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.DimensaoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.DimensaoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_material.id_dimensao_3 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_material.id_dimensao_3 = :produto_material_Dimensao3_7311 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_material_Dimensao3_7311", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PostoTrabalhoCorte" || parametro.FieldName == "id_posto_trabalho_corte")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.PostoTrabalhoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.PostoTrabalhoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_material.id_posto_trabalho_corte IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_material.id_posto_trabalho_corte = :produto_material_PostoTrabalhoCorte_1673 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_material_PostoTrabalhoCorte_1673", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoCorteInformacoesAdicionais" || parametro.FieldName == "prm_plano_corte_informacoes_adicionais")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_material.prm_plano_corte_informacoes_adicionais IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_material.prm_plano_corte_informacoes_adicionais LIKE :produto_material_PlanoCorteInformacoesAdicionais_7993 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_material_PlanoCorteInformacoesAdicionais_7993", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UnidadeMedidaDimensao1" || parametro.FieldName == "id_unidade_medida_dimensao_1")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.UnidadeMedidaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.UnidadeMedidaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_material.id_unidade_medida_dimensao_1 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_material.id_unidade_medida_dimensao_1 = :produto_material_UnidadeMedidaDimensao1_6384 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_material_UnidadeMedidaDimensao1_6384", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UnidadeMedidaDimensao2" || parametro.FieldName == "id_unidade_medida_dimensao_2")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.UnidadeMedidaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.UnidadeMedidaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_material.id_unidade_medida_dimensao_2 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_material.id_unidade_medida_dimensao_2 = :produto_material_UnidadeMedidaDimensao2_7766 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_material_UnidadeMedidaDimensao2_7766", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UnidadeMedidaDimensao3" || parametro.FieldName == "id_unidade_medida_dimensao_3")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.UnidadeMedidaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.UnidadeMedidaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_material.id_unidade_medida_dimensao_3 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_material.id_unidade_medida_dimensao_3 = :produto_material_UnidadeMedidaDimensao3_6796 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_material_UnidadeMedidaDimensao3_6796", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MaterialCondicional" || parametro.FieldName == "prm_material_condicional")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_material.prm_material_condicional IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_material.prm_material_condicional = :produto_material_MaterialCondicional_8672 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_material_MaterialCondicional_8672", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MaterialCondicionalRegra" || parametro.FieldName == "prm_material_condicional_regra")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_material.prm_material_condicional_regra IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_material.prm_material_condicional_regra LIKE :produto_material_MaterialCondicionalRegra_3750 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_material_MaterialCondicionalRegra_3750", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "QtdCondicional" || parametro.FieldName == "prm_qtd_condicional")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_material.prm_qtd_condicional IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_material.prm_qtd_condicional = :produto_material_QtdCondicional_885 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_material_QtdCondicional_885", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "QtdCondicionalRegra" || parametro.FieldName == "prm_qtd_condicional_regra")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_material.prm_qtd_condicional_regra IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_material.prm_qtd_condicional_regra LIKE :produto_material_QtdCondicionalRegra_6350 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_material_QtdCondicionalRegra_6350", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  produto_material.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_material.entity_uid LIKE :produto_material_EntityUid_7179 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_material_EntityUid_7179", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoCorteDimensao1Exato" || parametro.FieldName == "PlanoCorteDimensao1Exata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_material.prm_plano_corte_dimensao_1 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_material.prm_plano_corte_dimensao_1 LIKE :produto_material_PlanoCorteDimensao1_3450 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_material_PlanoCorteDimensao1_3450", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoCorteDimensao2Exato" || parametro.FieldName == "PlanoCorteDimensao2Exata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_material.prm_plano_corte_dimensao_2 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_material.prm_plano_corte_dimensao_2 LIKE :produto_material_PlanoCorteDimensao2_7433 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_material_PlanoCorteDimensao2_7433", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoCorteDimensao3Exato" || parametro.FieldName == "PlanoCorteDimensao3Exata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_material.prm_plano_corte_dimensao_3 IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_material.prm_plano_corte_dimensao_3 LIKE :produto_material_PlanoCorteDimensao3_2906 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_material_PlanoCorteDimensao3_2906", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PlanoCorteInformacoesAdicionaisExato" || parametro.FieldName == "PlanoCorteInformacoesAdicionaisExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_material.prm_plano_corte_informacoes_adicionais IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_material.prm_plano_corte_informacoes_adicionais LIKE :produto_material_PlanoCorteInformacoesAdicionais_5149 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_material_PlanoCorteInformacoesAdicionais_5149", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MaterialCondicionalRegraExato" || parametro.FieldName == "MaterialCondicionalRegraExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_material.prm_material_condicional_regra IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_material.prm_material_condicional_regra LIKE :produto_material_MaterialCondicionalRegra_623 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_material_MaterialCondicionalRegra_623", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  produto_material.prm_qtd_condicional_regra IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_material.prm_qtd_condicional_regra LIKE :produto_material_QtdCondicionalRegra_8366 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_material_QtdCondicionalRegra_8366", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  ProdutoMaterialClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (ProdutoMaterialClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(ProdutoMaterialClass), Convert.ToInt32(read["id_produto_material"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new ProdutoMaterialClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_produto_material"]);
                     if (read["id_produto"] != DBNull.Value)
                     {
                        entidade.Produto = (BibliotecaEntidades.Entidades.ProdutoClass)BibliotecaEntidades.Entidades.ProdutoClass.GetEntidade(Convert.ToInt32(read["id_produto"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Produto = null ;
                     }
                     if (read["id_material"] != DBNull.Value)
                     {
                        entidade.Material = (BibliotecaEntidades.Entidades.MaterialClass)BibliotecaEntidades.Entidades.MaterialClass.GetEntidade(Convert.ToInt32(read["id_material"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Material = null ;
                     }
                     entidade.Quantidade = (double)read["prm_quantidade"];
                     entidade.QtdProdutoPorUnidade = (double)read["prm_qtd_produto_por_unidade"];
                     entidade.VersaoEstrutura = (int)read["prm_versao_estrutura"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.PlanoCorte = Convert.ToBoolean(Convert.ToInt16(read["prm_plano_corte"]));
                     entidade.PlanoCorteQuantidade = read["prm_plano_corte_quantidade"] as double?;
                     entidade.PlanoCorteDimensao1 = (read["prm_plano_corte_dimensao_1"] != DBNull.Value ? read["prm_plano_corte_dimensao_1"].ToString() : null);
                     if (read["id_dimensao_1"] != DBNull.Value)
                     {
                        entidade.Dimensao1 = (BibliotecaEntidades.Entidades.DimensaoClass)BibliotecaEntidades.Entidades.DimensaoClass.GetEntidade(Convert.ToInt32(read["id_dimensao_1"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Dimensao1 = null ;
                     }
                     entidade.PlanoCorteDimensao2 = (read["prm_plano_corte_dimensao_2"] != DBNull.Value ? read["prm_plano_corte_dimensao_2"].ToString() : null);
                     if (read["id_dimensao_2"] != DBNull.Value)
                     {
                        entidade.Dimensao2 = (BibliotecaEntidades.Entidades.DimensaoClass)BibliotecaEntidades.Entidades.DimensaoClass.GetEntidade(Convert.ToInt32(read["id_dimensao_2"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Dimensao2 = null ;
                     }
                     entidade.PlanoCorteDimensao3 = (read["prm_plano_corte_dimensao_3"] != DBNull.Value ? read["prm_plano_corte_dimensao_3"].ToString() : null);
                     if (read["id_dimensao_3"] != DBNull.Value)
                     {
                        entidade.Dimensao3 = (BibliotecaEntidades.Entidades.DimensaoClass)BibliotecaEntidades.Entidades.DimensaoClass.GetEntidade(Convert.ToInt32(read["id_dimensao_3"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Dimensao3 = null ;
                     }
                     if (read["id_posto_trabalho_corte"] != DBNull.Value)
                     {
                        entidade.PostoTrabalhoCorte = (BibliotecaEntidades.Entidades.PostoTrabalhoClass)BibliotecaEntidades.Entidades.PostoTrabalhoClass.GetEntidade(Convert.ToInt32(read["id_posto_trabalho_corte"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.PostoTrabalhoCorte = null ;
                     }
                     entidade.PlanoCorteInformacoesAdicionais = (read["prm_plano_corte_informacoes_adicionais"] != DBNull.Value ? read["prm_plano_corte_informacoes_adicionais"].ToString() : null);
                     if (read["id_unidade_medida_dimensao_1"] != DBNull.Value)
                     {
                        entidade.UnidadeMedidaDimensao1 = (BibliotecaEntidades.Entidades.UnidadeMedidaClass)BibliotecaEntidades.Entidades.UnidadeMedidaClass.GetEntidade(Convert.ToInt32(read["id_unidade_medida_dimensao_1"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.UnidadeMedidaDimensao1 = null ;
                     }
                     if (read["id_unidade_medida_dimensao_2"] != DBNull.Value)
                     {
                        entidade.UnidadeMedidaDimensao2 = (BibliotecaEntidades.Entidades.UnidadeMedidaClass)BibliotecaEntidades.Entidades.UnidadeMedidaClass.GetEntidade(Convert.ToInt32(read["id_unidade_medida_dimensao_2"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.UnidadeMedidaDimensao2 = null ;
                     }
                     if (read["id_unidade_medida_dimensao_3"] != DBNull.Value)
                     {
                        entidade.UnidadeMedidaDimensao3 = (BibliotecaEntidades.Entidades.UnidadeMedidaClass)BibliotecaEntidades.Entidades.UnidadeMedidaClass.GetEntidade(Convert.ToInt32(read["id_unidade_medida_dimensao_3"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.UnidadeMedidaDimensao3 = null ;
                     }
                     entidade.MaterialCondicional = Convert.ToBoolean(Convert.ToInt16(read["prm_material_condicional"]));
                     entidade.MaterialCondicionalRegra = (read["prm_material_condicional_regra"] != DBNull.Value ? read["prm_material_condicional_regra"].ToString() : null);
                     entidade.QtdCondicional = Convert.ToBoolean(Convert.ToInt16(read["prm_qtd_condicional"]));
                     entidade.QtdCondicionalRegra = (read["prm_qtd_condicional_regra"] != DBNull.Value ? read["prm_qtd_condicional_regra"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (ProdutoMaterialClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
