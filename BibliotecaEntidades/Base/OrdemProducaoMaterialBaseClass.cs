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
     [Table("ordem_producao_material","opm")]
     public class OrdemProducaoMaterialBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do OrdemProducaoMaterialClass";
protected const string ErroDelete = "Erro ao excluir o OrdemProducaoMaterialClass  ";
protected const string ErroSave = "Erro ao salvar o OrdemProducaoMaterialClass.";
protected const string ErroMaterialDescricaoObrigatorio = "O campo MaterialDescricao é obrigatório";
protected const string ErroMaterialDescricaoComprimento = "O campo MaterialDescricao deve ter no máximo 255 caracteres";
protected const string ErroMaterialUnidadeMedidaObrigatorio = "O campo MaterialUnidadeMedida é obrigatório";
protected const string ErroMaterialUnidadeMedidaComprimento = "O campo MaterialUnidadeMedida deve ter no máximo 255 caracteres";
protected const string ErroMaterialTipoAcabamentoObrigatorio = "O campo MaterialTipoAcabamento é obrigatório";
protected const string ErroMaterialTipoAcabamentoComprimento = "O campo MaterialTipoAcabamento deve ter no máximo 255 caracteres";
protected const string ErroMaterialCodigoObrigatorio = "O campo MaterialCodigo é obrigatório";
protected const string ErroMaterialCodigoComprimento = "O campo MaterialCodigo deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroOrdemProducaoObrigatorio = "O campo OrdemProducao é obrigatório";
protected const string ErroMaterialObrigatorio = "O campo Material é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do OrdemProducaoMaterialClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade OrdemProducaoMaterialClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.OrdemProducaoClass _ordemProducaoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.OrdemProducaoClass _ordemProducaoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.OrdemProducaoClass _valueOrdemProducao;
        [Column("id_ordem_producao", "ordem_producao", "id_ordem_producao")]
       public virtual BibliotecaEntidades.Entidades.OrdemProducaoClass OrdemProducao
        { 
           get {                 return this._valueOrdemProducao; } 
           set 
           { 
                if (this._valueOrdemProducao == value)return;
                 this._valueOrdemProducao = value; 
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
         [Column("opm_quantidade")]
        public virtual double Quantidade
         { 
            get { return this._valueQuantidade; } 
            set 
            { 
                if (this._valueQuantidade == value)return;
                 this._valueQuantidade = value; 
            } 
        } 

       protected string _materialDescricaoOriginal{get;private set;}
       private string _materialDescricaoOriginalCommited{get; set;}
        private string _valueMaterialDescricao;
         [Column("opm_material_descricao")]
        public virtual string MaterialDescricao
         { 
            get { return this._valueMaterialDescricao; } 
            set 
            { 
                if (this._valueMaterialDescricao == value)return;
                 this._valueMaterialDescricao = value; 
            } 
        } 

       protected string _materialUnidadeMedidaOriginal{get;private set;}
       private string _materialUnidadeMedidaOriginalCommited{get; set;}
        private string _valueMaterialUnidadeMedida;
         [Column("opm_material_unidade_medida")]
        public virtual string MaterialUnidadeMedida
         { 
            get { return this._valueMaterialUnidadeMedida; } 
            set 
            { 
                if (this._valueMaterialUnidadeMedida == value)return;
                 this._valueMaterialUnidadeMedida = value; 
            } 
        } 

       protected double _materialMedidaOriginal{get;private set;}
       private double _materialMedidaOriginalCommited{get; set;}
        private double _valueMaterialMedida;
         [Column("opm_material_medida")]
        public virtual double MaterialMedida
         { 
            get { return this._valueMaterialMedida; } 
            set 
            { 
                if (this._valueMaterialMedida == value)return;
                 this._valueMaterialMedida = value; 
            } 
        } 

       protected double _materialMedidaLarguraOriginal{get;private set;}
       private double _materialMedidaLarguraOriginalCommited{get; set;}
        private double _valueMaterialMedidaLargura;
         [Column("opm_material_medida_largura")]
        public virtual double MaterialMedidaLargura
         { 
            get { return this._valueMaterialMedidaLargura; } 
            set 
            { 
                if (this._valueMaterialMedidaLargura == value)return;
                 this._valueMaterialMedidaLargura = value; 
            } 
        } 

       protected double _materialMedidaComprimentoOriginal{get;private set;}
       private double _materialMedidaComprimentoOriginalCommited{get; set;}
        private double _valueMaterialMedidaComprimento;
         [Column("opm_material_medida_comprimento")]
        public virtual double MaterialMedidaComprimento
         { 
            get { return this._valueMaterialMedidaComprimento; } 
            set 
            { 
                if (this._valueMaterialMedidaComprimento == value)return;
                 this._valueMaterialMedidaComprimento = value; 
            } 
        } 

       protected string _materialTipoAcabamentoOriginal{get;private set;}
       private string _materialTipoAcabamentoOriginalCommited{get; set;}
        private string _valueMaterialTipoAcabamento;
         [Column("opm_material_tipo_acabamento")]
        public virtual string MaterialTipoAcabamento
         { 
            get { return this._valueMaterialTipoAcabamento; } 
            set 
            { 
                if (this._valueMaterialTipoAcabamento == value)return;
                 this._valueMaterialTipoAcabamento = value; 
            } 
        } 

       protected string _materialCodigoOriginal{get;private set;}
       private string _materialCodigoOriginalCommited{get; set;}
        private string _valueMaterialCodigo;
         [Column("opm_material_codigo")]
        public virtual string MaterialCodigo
         { 
            get { return this._valueMaterialCodigo; } 
            set 
            { 
                if (this._valueMaterialCodigo == value)return;
                 this._valueMaterialCodigo = value; 
            } 
        } 

       protected bool _materialAuxiliarOriginal{get;private set;}
       private bool _materialAuxiliarOriginalCommited{get; set;}
        private bool _valueMaterialAuxiliar;
         [Column("opm_material_auxiliar")]
        public virtual bool MaterialAuxiliar
         { 
            get { return this._valueMaterialAuxiliar; } 
            set 
            { 
                if (this._valueMaterialAuxiliar == value)return;
                 this._valueMaterialAuxiliar = value; 
            } 
        } 

        public OrdemProducaoMaterialBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.MaterialMedida = 0;
           this.MaterialMedidaLargura = 0;
           this.MaterialMedidaComprimento = 0;
           this.MaterialAuxiliar = false;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static OrdemProducaoMaterialClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (OrdemProducaoMaterialClass) GetEntity(typeof(OrdemProducaoMaterialClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(MaterialDescricao))
                {
                    throw new Exception(ErroMaterialDescricaoObrigatorio);
                }
                if (MaterialDescricao.Length >255)
                {
                    throw new Exception( ErroMaterialDescricaoComprimento);
                }
                if (string.IsNullOrEmpty(MaterialUnidadeMedida))
                {
                    throw new Exception(ErroMaterialUnidadeMedidaObrigatorio);
                }
                if (MaterialUnidadeMedida.Length >255)
                {
                    throw new Exception( ErroMaterialUnidadeMedidaComprimento);
                }
                if (string.IsNullOrEmpty(MaterialTipoAcabamento))
                {
                    throw new Exception(ErroMaterialTipoAcabamentoObrigatorio);
                }
                if (MaterialTipoAcabamento.Length >255)
                {
                    throw new Exception( ErroMaterialTipoAcabamentoComprimento);
                }
                if (string.IsNullOrEmpty(MaterialCodigo))
                {
                    throw new Exception(ErroMaterialCodigoObrigatorio);
                }
                if (MaterialCodigo.Length >255)
                {
                    throw new Exception( ErroMaterialCodigoComprimento);
                }
                if ( _valueOrdemProducao == null)
                {
                    throw new Exception(ErroOrdemProducaoObrigatorio);
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
                    "  public.ordem_producao_material  " +
                    "WHERE " +
                    "  id_ordem_producao_material = :id";
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
                        "  public.ordem_producao_material   " +
                        "SET  " + 
                        "  id_ordem_producao = :id_ordem_producao, " + 
                        "  id_material = :id_material, " + 
                        "  opm_quantidade = :opm_quantidade, " + 
                        "  opm_material_descricao = :opm_material_descricao, " + 
                        "  opm_material_unidade_medida = :opm_material_unidade_medida, " + 
                        "  opm_material_medida = :opm_material_medida, " + 
                        "  opm_material_medida_largura = :opm_material_medida_largura, " + 
                        "  opm_material_medida_comprimento = :opm_material_medida_comprimento, " + 
                        "  opm_material_tipo_acabamento = :opm_material_tipo_acabamento, " + 
                        "  opm_material_codigo = :opm_material_codigo, " + 
                        "  opm_material_auxiliar = :opm_material_auxiliar, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_ordem_producao_material = :id " +
                        "RETURNING id_ordem_producao_material;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.ordem_producao_material " +
                        "( " +
                        "  id_ordem_producao , " + 
                        "  id_material , " + 
                        "  opm_quantidade , " + 
                        "  opm_material_descricao , " + 
                        "  opm_material_unidade_medida , " + 
                        "  opm_material_medida , " + 
                        "  opm_material_medida_largura , " + 
                        "  opm_material_medida_comprimento , " + 
                        "  opm_material_tipo_acabamento , " + 
                        "  opm_material_codigo , " + 
                        "  opm_material_auxiliar , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_ordem_producao , " + 
                        "  :id_material , " + 
                        "  :opm_quantidade , " + 
                        "  :opm_material_descricao , " + 
                        "  :opm_material_unidade_medida , " + 
                        "  :opm_material_medida , " + 
                        "  :opm_material_medida_largura , " + 
                        "  :opm_material_medida_comprimento , " + 
                        "  :opm_material_tipo_acabamento , " + 
                        "  :opm_material_codigo , " + 
                        "  :opm_material_auxiliar , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_ordem_producao_material;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.OrdemProducao==null ? (object) DBNull.Value : this.OrdemProducao.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_material", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Material==null ? (object) DBNull.Value : this.Material.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opm_quantidade", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Quantidade ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opm_material_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.MaterialDescricao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opm_material_unidade_medida", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.MaterialUnidadeMedida ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opm_material_medida", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.MaterialMedida ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opm_material_medida_largura", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.MaterialMedidaLargura ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opm_material_medida_comprimento", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.MaterialMedidaComprimento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opm_material_tipo_acabamento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.MaterialTipoAcabamento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opm_material_codigo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.MaterialCodigo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opm_material_auxiliar", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.MaterialAuxiliar ?? DBNull.Value;
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
        public static OrdemProducaoMaterialClass CopiarEntidade(OrdemProducaoMaterialClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               OrdemProducaoMaterialClass toRet = new OrdemProducaoMaterialClass(usuario,conn);
 toRet.OrdemProducao= entidadeCopiar.OrdemProducao;
 toRet.Material= entidadeCopiar.Material;
 toRet.Quantidade= entidadeCopiar.Quantidade;
 toRet.MaterialDescricao= entidadeCopiar.MaterialDescricao;
 toRet.MaterialUnidadeMedida= entidadeCopiar.MaterialUnidadeMedida;
 toRet.MaterialMedida= entidadeCopiar.MaterialMedida;
 toRet.MaterialMedidaLargura= entidadeCopiar.MaterialMedidaLargura;
 toRet.MaterialMedidaComprimento= entidadeCopiar.MaterialMedidaComprimento;
 toRet.MaterialTipoAcabamento= entidadeCopiar.MaterialTipoAcabamento;
 toRet.MaterialCodigo= entidadeCopiar.MaterialCodigo;
 toRet.MaterialAuxiliar= entidadeCopiar.MaterialAuxiliar;

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
       _ordemProducaoOriginal = OrdemProducao;
       _ordemProducaoOriginalCommited = _ordemProducaoOriginal;
       _materialOriginal = Material;
       _materialOriginalCommited = _materialOriginal;
       _quantidadeOriginal = Quantidade;
       _quantidadeOriginalCommited = _quantidadeOriginal;
       _materialDescricaoOriginal = MaterialDescricao;
       _materialDescricaoOriginalCommited = _materialDescricaoOriginal;
       _materialUnidadeMedidaOriginal = MaterialUnidadeMedida;
       _materialUnidadeMedidaOriginalCommited = _materialUnidadeMedidaOriginal;
       _materialMedidaOriginal = MaterialMedida;
       _materialMedidaOriginalCommited = _materialMedidaOriginal;
       _materialMedidaLarguraOriginal = MaterialMedidaLargura;
       _materialMedidaLarguraOriginalCommited = _materialMedidaLarguraOriginal;
       _materialMedidaComprimentoOriginal = MaterialMedidaComprimento;
       _materialMedidaComprimentoOriginalCommited = _materialMedidaComprimentoOriginal;
       _materialTipoAcabamentoOriginal = MaterialTipoAcabamento;
       _materialTipoAcabamentoOriginalCommited = _materialTipoAcabamentoOriginal;
       _materialCodigoOriginal = MaterialCodigo;
       _materialCodigoOriginalCommited = _materialCodigoOriginal;
       _materialAuxiliarOriginal = MaterialAuxiliar;
       _materialAuxiliarOriginalCommited = _materialAuxiliarOriginal;
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
       _ordemProducaoOriginalCommited = OrdemProducao;
       _materialOriginalCommited = Material;
       _quantidadeOriginalCommited = Quantidade;
       _materialDescricaoOriginalCommited = MaterialDescricao;
       _materialUnidadeMedidaOriginalCommited = MaterialUnidadeMedida;
       _materialMedidaOriginalCommited = MaterialMedida;
       _materialMedidaLarguraOriginalCommited = MaterialMedidaLargura;
       _materialMedidaComprimentoOriginalCommited = MaterialMedidaComprimento;
       _materialTipoAcabamentoOriginalCommited = MaterialTipoAcabamento;
       _materialCodigoOriginalCommited = MaterialCodigo;
       _materialAuxiliarOriginalCommited = MaterialAuxiliar;
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
               OrdemProducao=_ordemProducaoOriginal;
               _ordemProducaoOriginalCommited=_ordemProducaoOriginal;
               Material=_materialOriginal;
               _materialOriginalCommited=_materialOriginal;
               Quantidade=_quantidadeOriginal;
               _quantidadeOriginalCommited=_quantidadeOriginal;
               MaterialDescricao=_materialDescricaoOriginal;
               _materialDescricaoOriginalCommited=_materialDescricaoOriginal;
               MaterialUnidadeMedida=_materialUnidadeMedidaOriginal;
               _materialUnidadeMedidaOriginalCommited=_materialUnidadeMedidaOriginal;
               MaterialMedida=_materialMedidaOriginal;
               _materialMedidaOriginalCommited=_materialMedidaOriginal;
               MaterialMedidaLargura=_materialMedidaLarguraOriginal;
               _materialMedidaLarguraOriginalCommited=_materialMedidaLarguraOriginal;
               MaterialMedidaComprimento=_materialMedidaComprimentoOriginal;
               _materialMedidaComprimentoOriginalCommited=_materialMedidaComprimentoOriginal;
               MaterialTipoAcabamento=_materialTipoAcabamentoOriginal;
               _materialTipoAcabamentoOriginalCommited=_materialTipoAcabamentoOriginal;
               MaterialCodigo=_materialCodigoOriginal;
               _materialCodigoOriginalCommited=_materialCodigoOriginal;
               MaterialAuxiliar=_materialAuxiliarOriginal;
               _materialAuxiliarOriginalCommited=_materialAuxiliarOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;

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
       if (_ordemProducaoOriginal!=null)
       {
          dirty = !_ordemProducaoOriginal.Equals(OrdemProducao);
       }
       else
       {
            dirty = OrdemProducao != null;
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
       dirty = _materialDescricaoOriginal != MaterialDescricao;
      if (dirty) return true;
       dirty = _materialUnidadeMedidaOriginal != MaterialUnidadeMedida;
      if (dirty) return true;
       dirty = _materialMedidaOriginal != MaterialMedida;
      if (dirty) return true;
       dirty = _materialMedidaLarguraOriginal != MaterialMedidaLargura;
      if (dirty) return true;
       dirty = _materialMedidaComprimentoOriginal != MaterialMedidaComprimento;
      if (dirty) return true;
       dirty = _materialTipoAcabamentoOriginal != MaterialTipoAcabamento;
      if (dirty) return true;
       dirty = _materialCodigoOriginal != MaterialCodigo;
      if (dirty) return true;
       dirty = _materialAuxiliarOriginal != MaterialAuxiliar;
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
       if (_ordemProducaoOriginalCommited!=null)
       {
          dirty = !_ordemProducaoOriginalCommited.Equals(OrdemProducao);
       }
       else
       {
            dirty = OrdemProducao != null;
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
       dirty = _materialDescricaoOriginalCommited != MaterialDescricao;
      if (dirty) return true;
       dirty = _materialUnidadeMedidaOriginalCommited != MaterialUnidadeMedida;
      if (dirty) return true;
       dirty = _materialMedidaOriginalCommited != MaterialMedida;
      if (dirty) return true;
       dirty = _materialMedidaLarguraOriginalCommited != MaterialMedidaLargura;
      if (dirty) return true;
       dirty = _materialMedidaComprimentoOriginalCommited != MaterialMedidaComprimento;
      if (dirty) return true;
       dirty = _materialTipoAcabamentoOriginalCommited != MaterialTipoAcabamento;
      if (dirty) return true;
       dirty = _materialCodigoOriginalCommited != MaterialCodigo;
      if (dirty) return true;
       dirty = _materialAuxiliarOriginalCommited != MaterialAuxiliar;
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
             case "OrdemProducao":
                return this.OrdemProducao;
             case "Material":
                return this.Material;
             case "Quantidade":
                return this.Quantidade;
             case "MaterialDescricao":
                return this.MaterialDescricao;
             case "MaterialUnidadeMedida":
                return this.MaterialUnidadeMedida;
             case "MaterialMedida":
                return this.MaterialMedida;
             case "MaterialMedidaLargura":
                return this.MaterialMedidaLargura;
             case "MaterialMedidaComprimento":
                return this.MaterialMedidaComprimento;
             case "MaterialTipoAcabamento":
                return this.MaterialTipoAcabamento;
             case "MaterialCodigo":
                return this.MaterialCodigo;
             case "MaterialAuxiliar":
                return this.MaterialAuxiliar;
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
             if (OrdemProducao!=null)
                OrdemProducao.ChangeSingleConnection(newConnection);
             if (Material!=null)
                Material.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(ordem_producao_material.id_ordem_producao_material) " ;
               }
               else
               {
               command.CommandText += "ordem_producao_material.id_ordem_producao_material, " ;
               command.CommandText += "ordem_producao_material.id_ordem_producao, " ;
               command.CommandText += "ordem_producao_material.id_material, " ;
               command.CommandText += "ordem_producao_material.opm_quantidade, " ;
               command.CommandText += "ordem_producao_material.opm_material_descricao, " ;
               command.CommandText += "ordem_producao_material.opm_material_unidade_medida, " ;
               command.CommandText += "ordem_producao_material.opm_material_medida, " ;
               command.CommandText += "ordem_producao_material.opm_material_medida_largura, " ;
               command.CommandText += "ordem_producao_material.opm_material_medida_comprimento, " ;
               command.CommandText += "ordem_producao_material.opm_material_tipo_acabamento, " ;
               command.CommandText += "ordem_producao_material.opm_material_codigo, " ;
               command.CommandText += "ordem_producao_material.opm_material_auxiliar, " ;
               command.CommandText += "ordem_producao_material.entity_uid, " ;
               command.CommandText += "ordem_producao_material.version " ;
               }
               command.CommandText += " FROM  ordem_producao_material ";
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
                        orderByClause += " , opm_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(opm_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = ordem_producao_material.id_acs_usuario_ultima_revisao ";
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
                     case "id_ordem_producao_material":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_material.id_ordem_producao_material " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_material.id_ordem_producao_material) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_ordem_producao":
                     case "OrdemProducao":
                     command.CommandText += " LEFT JOIN ordem_producao as ordem_producao_OrdemProducao ON ordem_producao_OrdemProducao.id_ordem_producao = ordem_producao_material.id_ordem_producao ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_OrdemProducao.id_ordem_producao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_OrdemProducao.id_ordem_producao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_material":
                     case "Material":
                     command.CommandText += " LEFT JOIN material as material_Material ON material_Material.id_material = ordem_producao_material.id_material ";                     switch (parametro.TipoOrdenacao)
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
                     case "opm_quantidade":
                     case "Quantidade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_material.opm_quantidade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_material.opm_quantidade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opm_material_descricao":
                     case "MaterialDescricao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_material.opm_material_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_material.opm_material_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opm_material_unidade_medida":
                     case "MaterialUnidadeMedida":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_material.opm_material_unidade_medida " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_material.opm_material_unidade_medida) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opm_material_medida":
                     case "MaterialMedida":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_material.opm_material_medida " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_material.opm_material_medida) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opm_material_medida_largura":
                     case "MaterialMedidaLargura":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_material.opm_material_medida_largura " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_material.opm_material_medida_largura) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opm_material_medida_comprimento":
                     case "MaterialMedidaComprimento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_material.opm_material_medida_comprimento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_material.opm_material_medida_comprimento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opm_material_tipo_acabamento":
                     case "MaterialTipoAcabamento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_material.opm_material_tipo_acabamento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_material.opm_material_tipo_acabamento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opm_material_codigo":
                     case "MaterialCodigo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_material.opm_material_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_material.opm_material_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opm_material_auxiliar":
                     case "MaterialAuxiliar":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_material.opm_material_auxiliar " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_material.opm_material_auxiliar) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_material.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_material.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , ordem_producao_material.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_material.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opm_material_descricao")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_material.opm_material_descricao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_material.opm_material_descricao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opm_material_unidade_medida")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_material.opm_material_unidade_medida) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_material.opm_material_unidade_medida) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opm_material_tipo_acabamento")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_material.opm_material_tipo_acabamento) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_material.opm_material_tipo_acabamento) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opm_material_codigo")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_material.opm_material_codigo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_material.opm_material_codigo) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_material.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_material.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_ordem_producao_material")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_material.id_ordem_producao_material IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_material.id_ordem_producao_material = :ordem_producao_material_ID_4993 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_material_ID_4993", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrdemProducao" || parametro.FieldName == "id_ordem_producao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.OrdemProducaoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.OrdemProducaoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_material.id_ordem_producao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_material.id_ordem_producao = :ordem_producao_material_OrdemProducao_8996 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_material_OrdemProducao_8996", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  ordem_producao_material.id_material IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_material.id_material = :ordem_producao_material_Material_7089 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_material_Material_7089", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Quantidade" || parametro.FieldName == "opm_quantidade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_material.opm_quantidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_material.opm_quantidade = :ordem_producao_material_Quantidade_9716 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_material_Quantidade_9716", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MaterialDescricao" || parametro.FieldName == "opm_material_descricao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_material.opm_material_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_material.opm_material_descricao LIKE :ordem_producao_material_MaterialDescricao_8884 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_material_MaterialDescricao_8884", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MaterialUnidadeMedida" || parametro.FieldName == "opm_material_unidade_medida")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_material.opm_material_unidade_medida IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_material.opm_material_unidade_medida LIKE :ordem_producao_material_MaterialUnidadeMedida_1182 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_material_MaterialUnidadeMedida_1182", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MaterialMedida" || parametro.FieldName == "opm_material_medida")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_material.opm_material_medida IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_material.opm_material_medida = :ordem_producao_material_MaterialMedida_845 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_material_MaterialMedida_845", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MaterialMedidaLargura" || parametro.FieldName == "opm_material_medida_largura")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_material.opm_material_medida_largura IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_material.opm_material_medida_largura = :ordem_producao_material_MaterialMedidaLargura_2596 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_material_MaterialMedidaLargura_2596", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MaterialMedidaComprimento" || parametro.FieldName == "opm_material_medida_comprimento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_material.opm_material_medida_comprimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_material.opm_material_medida_comprimento = :ordem_producao_material_MaterialMedidaComprimento_3694 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_material_MaterialMedidaComprimento_3694", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MaterialTipoAcabamento" || parametro.FieldName == "opm_material_tipo_acabamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_material.opm_material_tipo_acabamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_material.opm_material_tipo_acabamento LIKE :ordem_producao_material_MaterialTipoAcabamento_7549 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_material_MaterialTipoAcabamento_7549", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MaterialCodigo" || parametro.FieldName == "opm_material_codigo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_material.opm_material_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_material.opm_material_codigo LIKE :ordem_producao_material_MaterialCodigo_9137 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_material_MaterialCodigo_9137", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MaterialAuxiliar" || parametro.FieldName == "opm_material_auxiliar")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_material.opm_material_auxiliar IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_material.opm_material_auxiliar = :ordem_producao_material_MaterialAuxiliar_4737 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_material_MaterialAuxiliar_4737", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
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
                         whereClause += "  ordem_producao_material.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_material.entity_uid LIKE :ordem_producao_material_EntityUid_2642 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_material_EntityUid_2642", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  ordem_producao_material.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_material.version = :ordem_producao_material_Version_924 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_material_Version_924", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MaterialDescricaoExato" || parametro.FieldName == "MaterialDescricaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_material.opm_material_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_material.opm_material_descricao LIKE :ordem_producao_material_MaterialDescricao_674 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_material_MaterialDescricao_674", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MaterialUnidadeMedidaExato" || parametro.FieldName == "MaterialUnidadeMedidaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_material.opm_material_unidade_medida IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_material.opm_material_unidade_medida LIKE :ordem_producao_material_MaterialUnidadeMedida_7914 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_material_MaterialUnidadeMedida_7914", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MaterialTipoAcabamentoExato" || parametro.FieldName == "MaterialTipoAcabamentoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_material.opm_material_tipo_acabamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_material.opm_material_tipo_acabamento LIKE :ordem_producao_material_MaterialTipoAcabamento_7767 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_material_MaterialTipoAcabamento_7767", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MaterialCodigoExato" || parametro.FieldName == "MaterialCodigoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_material.opm_material_codigo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_material.opm_material_codigo LIKE :ordem_producao_material_MaterialCodigo_2955 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_material_MaterialCodigo_2955", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  ordem_producao_material.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_material.entity_uid LIKE :ordem_producao_material_EntityUid_6769 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_material_EntityUid_6769", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  OrdemProducaoMaterialClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (OrdemProducaoMaterialClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(OrdemProducaoMaterialClass), Convert.ToInt32(read["id_ordem_producao_material"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new OrdemProducaoMaterialClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_ordem_producao_material"]);
                     if (read["id_ordem_producao"] != DBNull.Value)
                     {
                        entidade.OrdemProducao = (BibliotecaEntidades.Entidades.OrdemProducaoClass)BibliotecaEntidades.Entidades.OrdemProducaoClass.GetEntidade(Convert.ToInt32(read["id_ordem_producao"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.OrdemProducao = null ;
                     }
                     if (read["id_material"] != DBNull.Value)
                     {
                        entidade.Material = (BibliotecaEntidades.Entidades.MaterialClass)BibliotecaEntidades.Entidades.MaterialClass.GetEntidade(Convert.ToInt32(read["id_material"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Material = null ;
                     }
                     entidade.Quantidade = (double)read["opm_quantidade"];
                     entidade.MaterialDescricao = (read["opm_material_descricao"] != DBNull.Value ? read["opm_material_descricao"].ToString() : null);
                     entidade.MaterialUnidadeMedida = (read["opm_material_unidade_medida"] != DBNull.Value ? read["opm_material_unidade_medida"].ToString() : null);
                     entidade.MaterialMedida = (double)read["opm_material_medida"];
                     entidade.MaterialMedidaLargura = (double)read["opm_material_medida_largura"];
                     entidade.MaterialMedidaComprimento = (double)read["opm_material_medida_comprimento"];
                     entidade.MaterialTipoAcabamento = (read["opm_material_tipo_acabamento"] != DBNull.Value ? read["opm_material_tipo_acabamento"].ToString() : null);
                     entidade.MaterialCodigo = (read["opm_material_codigo"] != DBNull.Value ? read["opm_material_codigo"].ToString() : null);
                     entidade.MaterialAuxiliar = Convert.ToBoolean(Convert.ToInt16(read["opm_material_auxiliar"]));
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (OrdemProducaoMaterialClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
