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
     [Table("declaracao_importacao_adicao_item","dai")]
     public class DeclaracaoImportacaoAdicaoItemBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do DeclaracaoImportacaoAdicaoItemClass";
protected const string ErroDelete = "Erro ao excluir o DeclaracaoImportacaoAdicaoItemClass  ";
protected const string ErroSave = "Erro ao salvar o DeclaracaoImportacaoAdicaoItemClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroDeclaracaoImportacaoAdicaoObrigatorio = "O campo DeclaracaoImportacaoAdicao é obrigatório";
protected const string ErroMaterialObrigatorio = "O campo Material é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do DeclaracaoImportacaoAdicaoItemClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade DeclaracaoImportacaoAdicaoItemClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.DeclaracaoImportacaoAdicaoClass _declaracaoImportacaoAdicaoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.DeclaracaoImportacaoAdicaoClass _declaracaoImportacaoAdicaoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.DeclaracaoImportacaoAdicaoClass _valueDeclaracaoImportacaoAdicao;
        [Column("id_declaracao_importacao_adicao", "declaracao_importacao_adicao", "id_declaracao_importacao_adicao")]
       public virtual BibliotecaEntidades.Entidades.DeclaracaoImportacaoAdicaoClass DeclaracaoImportacaoAdicao
        { 
           get {                 return this._valueDeclaracaoImportacaoAdicao; } 
           set 
           { 
                if (this._valueDeclaracaoImportacaoAdicao == value)return;
                 this._valueDeclaracaoImportacaoAdicao = value; 
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

       protected double _aliquotaIiOriginal{get;private set;}
       private double _aliquotaIiOriginalCommited{get; set;}
        private double _valueAliquotaIi;
         [Column("dai_aliquota_ii")]
        public virtual double AliquotaIi
         { 
            get { return this._valueAliquotaIi; } 
            set 
            { 
                if (this._valueAliquotaIi == value)return;
                 this._valueAliquotaIi = value; 
            } 
        } 

       protected double _quantidadeOriginal{get;private set;}
       private double _quantidadeOriginalCommited{get; set;}
        private double _valueQuantidade;
         [Column("dai_quantidade")]
        public virtual double Quantidade
         { 
            get { return this._valueQuantidade; } 
            set 
            { 
                if (this._valueQuantidade == value)return;
                 this._valueQuantidade = value; 
            } 
        } 

       protected double _valorUnitarioDolaresOriginal{get;private set;}
       private double _valorUnitarioDolaresOriginalCommited{get; set;}
        private double _valueValorUnitarioDolares;
         [Column("dai_valor_unitario_dolares")]
        public virtual double ValorUnitarioDolares
         { 
            get { return this._valueValorUnitarioDolares; } 
            set 
            { 
                if (this._valueValorUnitarioDolares == value)return;
                 this._valueValorUnitarioDolares = value; 
            } 
        } 

       protected double _valorUnitarioReaisOriginal{get;private set;}
       private double _valorUnitarioReaisOriginalCommited{get; set;}
        private double _valueValorUnitarioReais;
         [Column("dai_valor_unitario_reais")]
        public virtual double ValorUnitarioReais
         { 
            get { return this._valueValorUnitarioReais; } 
            set 
            { 
                if (this._valueValorUnitarioReais == value)return;
                 this._valueValorUnitarioReais = value; 
            } 
        } 

       protected double _valorTotalDolaresOriginal{get;private set;}
       private double _valorTotalDolaresOriginalCommited{get; set;}
        private double _valueValorTotalDolares;
         [Column("dai_valor_total_dolares")]
        public virtual double ValorTotalDolares
         { 
            get { return this._valueValorTotalDolares; } 
            set 
            { 
                if (this._valueValorTotalDolares == value)return;
                 this._valueValorTotalDolares = value; 
            } 
        } 

       protected double _valorTotalReaisOriginal{get;private set;}
       private double _valorTotalReaisOriginalCommited{get; set;}
        private double _valueValorTotalReais;
         [Column("dai_valor_total_reais")]
        public virtual double ValorTotalReais
         { 
            get { return this._valueValorTotalReais; } 
            set 
            { 
                if (this._valueValorTotalReais == value)return;
                 this._valueValorTotalReais = value; 
            } 
        } 

       protected short _numeroSequencialNaAdicaoOriginal{get;private set;}
       private short _numeroSequencialNaAdicaoOriginalCommited{get; set;}
        private short _valueNumeroSequencialNaAdicao;
         [Column("dai_numero_sequencial_na_adicao")]
        public virtual short NumeroSequencialNaAdicao
         { 
            get { return this._valueNumeroSequencialNaAdicao; } 
            set 
            { 
                if (this._valueNumeroSequencialNaAdicao == value)return;
                 this._valueNumeroSequencialNaAdicao = value; 
            } 
        } 

        public DeclaracaoImportacaoAdicaoItemBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.AliquotaIi = 0;
           this.Quantidade = 0;
           this.ValorUnitarioDolares = 0;
           this.ValorUnitarioReais = 0;
           this.ValorTotalDolares = 0;
           this.ValorTotalReais = 0;
           this.NumeroSequencialNaAdicao = 0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static DeclaracaoImportacaoAdicaoItemClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (DeclaracaoImportacaoAdicaoItemClass) GetEntity(typeof(DeclaracaoImportacaoAdicaoItemClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if ( _valueDeclaracaoImportacaoAdicao == null)
                {
                    throw new Exception(ErroDeclaracaoImportacaoAdicaoObrigatorio);
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
                    "  public.declaracao_importacao_adicao_item  " +
                    "WHERE " +
                    "  id_declaracao_importacao_adicao_item = :id";
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
                        "  public.declaracao_importacao_adicao_item   " +
                        "SET  " + 
                        "  id_declaracao_importacao_adicao = :id_declaracao_importacao_adicao, " + 
                        "  id_material = :id_material, " + 
                        "  dai_aliquota_ii = :dai_aliquota_ii, " + 
                        "  dai_quantidade = :dai_quantidade, " + 
                        "  dai_valor_unitario_dolares = :dai_valor_unitario_dolares, " + 
                        "  dai_valor_unitario_reais = :dai_valor_unitario_reais, " + 
                        "  dai_valor_total_dolares = :dai_valor_total_dolares, " + 
                        "  dai_valor_total_reais = :dai_valor_total_reais, " + 
                        "  dai_numero_sequencial_na_adicao = :dai_numero_sequencial_na_adicao, " + 
                        "  version = :version, " + 
                        "  entity_uid = :entity_uid "+
                        "WHERE  " +
                        "  id_declaracao_importacao_adicao_item = :id " +
                        "RETURNING id_declaracao_importacao_adicao_item;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.declaracao_importacao_adicao_item " +
                        "( " +
                        "  id_declaracao_importacao_adicao , " + 
                        "  id_material , " + 
                        "  dai_aliquota_ii , " + 
                        "  dai_quantidade , " + 
                        "  dai_valor_unitario_dolares , " + 
                        "  dai_valor_unitario_reais , " + 
                        "  dai_valor_total_dolares , " + 
                        "  dai_valor_total_reais , " + 
                        "  dai_numero_sequencial_na_adicao , " + 
                        "  version , " + 
                        "  entity_uid  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_declaracao_importacao_adicao , " + 
                        "  :id_material , " + 
                        "  :dai_aliquota_ii , " + 
                        "  :dai_quantidade , " + 
                        "  :dai_valor_unitario_dolares , " + 
                        "  :dai_valor_unitario_reais , " + 
                        "  :dai_valor_total_dolares , " + 
                        "  :dai_valor_total_reais , " + 
                        "  :dai_numero_sequencial_na_adicao , " + 
                        "  :version , " + 
                        "  :entity_uid  "+
                        ")RETURNING id_declaracao_importacao_adicao_item;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_declaracao_importacao_adicao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.DeclaracaoImportacaoAdicao==null ? (object) DBNull.Value : this.DeclaracaoImportacaoAdicao.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_material", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Material==null ? (object) DBNull.Value : this.Material.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dai_aliquota_ii", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.AliquotaIi ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dai_quantidade", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Quantidade ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dai_valor_unitario_dolares", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorUnitarioDolares ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dai_valor_unitario_reais", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorUnitarioReais ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dai_valor_total_dolares", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorTotalDolares ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dai_valor_total_reais", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorTotalReais ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dai_numero_sequencial_na_adicao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NumeroSequencialNaAdicao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
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
        public static DeclaracaoImportacaoAdicaoItemClass CopiarEntidade(DeclaracaoImportacaoAdicaoItemClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               DeclaracaoImportacaoAdicaoItemClass toRet = new DeclaracaoImportacaoAdicaoItemClass(usuario,conn);
 toRet.DeclaracaoImportacaoAdicao= entidadeCopiar.DeclaracaoImportacaoAdicao;
 toRet.Material= entidadeCopiar.Material;
 toRet.AliquotaIi= entidadeCopiar.AliquotaIi;
 toRet.Quantidade= entidadeCopiar.Quantidade;
 toRet.ValorUnitarioDolares= entidadeCopiar.ValorUnitarioDolares;
 toRet.ValorUnitarioReais= entidadeCopiar.ValorUnitarioReais;
 toRet.ValorTotalDolares= entidadeCopiar.ValorTotalDolares;
 toRet.ValorTotalReais= entidadeCopiar.ValorTotalReais;
 toRet.NumeroSequencialNaAdicao= entidadeCopiar.NumeroSequencialNaAdicao;

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
       _declaracaoImportacaoAdicaoOriginal = DeclaracaoImportacaoAdicao;
       _declaracaoImportacaoAdicaoOriginalCommited = _declaracaoImportacaoAdicaoOriginal;
       _materialOriginal = Material;
       _materialOriginalCommited = _materialOriginal;
       _aliquotaIiOriginal = AliquotaIi;
       _aliquotaIiOriginalCommited = _aliquotaIiOriginal;
       _quantidadeOriginal = Quantidade;
       _quantidadeOriginalCommited = _quantidadeOriginal;
       _valorUnitarioDolaresOriginal = ValorUnitarioDolares;
       _valorUnitarioDolaresOriginalCommited = _valorUnitarioDolaresOriginal;
       _valorUnitarioReaisOriginal = ValorUnitarioReais;
       _valorUnitarioReaisOriginalCommited = _valorUnitarioReaisOriginal;
       _valorTotalDolaresOriginal = ValorTotalDolares;
       _valorTotalDolaresOriginalCommited = _valorTotalDolaresOriginal;
       _valorTotalReaisOriginal = ValorTotalReais;
       _valorTotalReaisOriginalCommited = _valorTotalReaisOriginal;
       _numeroSequencialNaAdicaoOriginal = NumeroSequencialNaAdicao;
       _numeroSequencialNaAdicaoOriginalCommited = _numeroSequencialNaAdicaoOriginal;
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
       _declaracaoImportacaoAdicaoOriginalCommited = DeclaracaoImportacaoAdicao;
       _materialOriginalCommited = Material;
       _aliquotaIiOriginalCommited = AliquotaIi;
       _quantidadeOriginalCommited = Quantidade;
       _valorUnitarioDolaresOriginalCommited = ValorUnitarioDolares;
       _valorUnitarioReaisOriginalCommited = ValorUnitarioReais;
       _valorTotalDolaresOriginalCommited = ValorTotalDolares;
       _valorTotalReaisOriginalCommited = ValorTotalReais;
       _numeroSequencialNaAdicaoOriginalCommited = NumeroSequencialNaAdicao;
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
               DeclaracaoImportacaoAdicao=_declaracaoImportacaoAdicaoOriginal;
               _declaracaoImportacaoAdicaoOriginalCommited=_declaracaoImportacaoAdicaoOriginal;
               Material=_materialOriginal;
               _materialOriginalCommited=_materialOriginal;
               AliquotaIi=_aliquotaIiOriginal;
               _aliquotaIiOriginalCommited=_aliquotaIiOriginal;
               Quantidade=_quantidadeOriginal;
               _quantidadeOriginalCommited=_quantidadeOriginal;
               ValorUnitarioDolares=_valorUnitarioDolaresOriginal;
               _valorUnitarioDolaresOriginalCommited=_valorUnitarioDolaresOriginal;
               ValorUnitarioReais=_valorUnitarioReaisOriginal;
               _valorUnitarioReaisOriginalCommited=_valorUnitarioReaisOriginal;
               ValorTotalDolares=_valorTotalDolaresOriginal;
               _valorTotalDolaresOriginalCommited=_valorTotalDolaresOriginal;
               ValorTotalReais=_valorTotalReaisOriginal;
               _valorTotalReaisOriginalCommited=_valorTotalReaisOriginal;
               NumeroSequencialNaAdicao=_numeroSequencialNaAdicaoOriginal;
               _numeroSequencialNaAdicaoOriginalCommited=_numeroSequencialNaAdicaoOriginal;
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
       if (_declaracaoImportacaoAdicaoOriginal!=null)
       {
          dirty = !_declaracaoImportacaoAdicaoOriginal.Equals(DeclaracaoImportacaoAdicao);
       }
       else
       {
            dirty = DeclaracaoImportacaoAdicao != null;
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
       dirty = _aliquotaIiOriginal != AliquotaIi;
      if (dirty) return true;
       dirty = _quantidadeOriginal != Quantidade;
      if (dirty) return true;
       dirty = _valorUnitarioDolaresOriginal != ValorUnitarioDolares;
      if (dirty) return true;
       dirty = _valorUnitarioReaisOriginal != ValorUnitarioReais;
      if (dirty) return true;
       dirty = _valorTotalDolaresOriginal != ValorTotalDolares;
      if (dirty) return true;
       dirty = _valorTotalReaisOriginal != ValorTotalReais;
      if (dirty) return true;
       dirty = _numeroSequencialNaAdicaoOriginal != NumeroSequencialNaAdicao;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
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
       if (_declaracaoImportacaoAdicaoOriginalCommited!=null)
       {
          dirty = !_declaracaoImportacaoAdicaoOriginalCommited.Equals(DeclaracaoImportacaoAdicao);
       }
       else
       {
            dirty = DeclaracaoImportacaoAdicao != null;
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
       dirty = _aliquotaIiOriginalCommited != AliquotaIi;
      if (dirty) return true;
       dirty = _quantidadeOriginalCommited != Quantidade;
      if (dirty) return true;
       dirty = _valorUnitarioDolaresOriginalCommited != ValorUnitarioDolares;
      if (dirty) return true;
       dirty = _valorUnitarioReaisOriginalCommited != ValorUnitarioReais;
      if (dirty) return true;
       dirty = _valorTotalDolaresOriginalCommited != ValorTotalDolares;
      if (dirty) return true;
       dirty = _valorTotalReaisOriginalCommited != ValorTotalReais;
      if (dirty) return true;
       dirty = _numeroSequencialNaAdicaoOriginalCommited != NumeroSequencialNaAdicao;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
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
             case "DeclaracaoImportacaoAdicao":
                return this.DeclaracaoImportacaoAdicao;
             case "Material":
                return this.Material;
             case "AliquotaIi":
                return this.AliquotaIi;
             case "Quantidade":
                return this.Quantidade;
             case "ValorUnitarioDolares":
                return this.ValorUnitarioDolares;
             case "ValorUnitarioReais":
                return this.ValorUnitarioReais;
             case "ValorTotalDolares":
                return this.ValorTotalDolares;
             case "ValorTotalReais":
                return this.ValorTotalReais;
             case "NumeroSequencialNaAdicao":
                return this.NumeroSequencialNaAdicao;
             case "Version":
                return this.Version;
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
             if (DeclaracaoImportacaoAdicao!=null)
                DeclaracaoImportacaoAdicao.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(declaracao_importacao_adicao_item.id_declaracao_importacao_adicao_item) " ;
               }
               else
               {
               command.CommandText += "declaracao_importacao_adicao_item.id_declaracao_importacao_adicao_item, " ;
               command.CommandText += "declaracao_importacao_adicao_item.id_declaracao_importacao_adicao, " ;
               command.CommandText += "declaracao_importacao_adicao_item.id_material, " ;
               command.CommandText += "declaracao_importacao_adicao_item.dai_aliquota_ii, " ;
               command.CommandText += "declaracao_importacao_adicao_item.dai_quantidade, " ;
               command.CommandText += "declaracao_importacao_adicao_item.dai_valor_unitario_dolares, " ;
               command.CommandText += "declaracao_importacao_adicao_item.dai_valor_unitario_reais, " ;
               command.CommandText += "declaracao_importacao_adicao_item.dai_valor_total_dolares, " ;
               command.CommandText += "declaracao_importacao_adicao_item.dai_valor_total_reais, " ;
               command.CommandText += "declaracao_importacao_adicao_item.dai_numero_sequencial_na_adicao, " ;
               command.CommandText += "declaracao_importacao_adicao_item.version, " ;
               command.CommandText += "declaracao_importacao_adicao_item.entity_uid " ;
               }
               command.CommandText += " FROM  declaracao_importacao_adicao_item ";
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
                        orderByClause += " , dai_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(dai_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = declaracao_importacao_adicao_item.id_acs_usuario_ultima_revisao ";
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
                     case "id_declaracao_importacao_adicao_item":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , declaracao_importacao_adicao_item.id_declaracao_importacao_adicao_item " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(declaracao_importacao_adicao_item.id_declaracao_importacao_adicao_item) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_declaracao_importacao_adicao":
                     case "DeclaracaoImportacaoAdicao":
                     command.CommandText += " LEFT JOIN declaracao_importacao_adicao as declaracao_importacao_adicao_DeclaracaoImportacaoAdicao ON declaracao_importacao_adicao_DeclaracaoImportacaoAdicao.id_declaracao_importacao_adicao = declaracao_importacao_adicao_item.id_declaracao_importacao_adicao ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , declaracao_importacao_adicao_DeclaracaoImportacaoAdicao.dia_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(declaracao_importacao_adicao_DeclaracaoImportacaoAdicao.dia_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_material":
                     case "Material":
                     command.CommandText += " LEFT JOIN material as material_Material ON material_Material.id_material = declaracao_importacao_adicao_item.id_material ";                     switch (parametro.TipoOrdenacao)
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
                     case "dai_aliquota_ii":
                     case "AliquotaIi":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , declaracao_importacao_adicao_item.dai_aliquota_ii " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(declaracao_importacao_adicao_item.dai_aliquota_ii) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dai_quantidade":
                     case "Quantidade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , declaracao_importacao_adicao_item.dai_quantidade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(declaracao_importacao_adicao_item.dai_quantidade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dai_valor_unitario_dolares":
                     case "ValorUnitarioDolares":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , declaracao_importacao_adicao_item.dai_valor_unitario_dolares " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(declaracao_importacao_adicao_item.dai_valor_unitario_dolares) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dai_valor_unitario_reais":
                     case "ValorUnitarioReais":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , declaracao_importacao_adicao_item.dai_valor_unitario_reais " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(declaracao_importacao_adicao_item.dai_valor_unitario_reais) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dai_valor_total_dolares":
                     case "ValorTotalDolares":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , declaracao_importacao_adicao_item.dai_valor_total_dolares " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(declaracao_importacao_adicao_item.dai_valor_total_dolares) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dai_valor_total_reais":
                     case "ValorTotalReais":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , declaracao_importacao_adicao_item.dai_valor_total_reais " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(declaracao_importacao_adicao_item.dai_valor_total_reais) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dai_numero_sequencial_na_adicao":
                     case "NumeroSequencialNaAdicao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , declaracao_importacao_adicao_item.dai_numero_sequencial_na_adicao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(declaracao_importacao_adicao_item.dai_numero_sequencial_na_adicao) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , declaracao_importacao_adicao_item.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(declaracao_importacao_adicao_item.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , declaracao_importacao_adicao_item.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(declaracao_importacao_adicao_item.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           whereClause += " OR UPPER(declaracao_importacao_adicao_item.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(declaracao_importacao_adicao_item.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_declaracao_importacao_adicao_item")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  declaracao_importacao_adicao_item.id_declaracao_importacao_adicao_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  declaracao_importacao_adicao_item.id_declaracao_importacao_adicao_item = :declaracao_importacao_adicao_item_ID_3335 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("declaracao_importacao_adicao_item_ID_3335", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DeclaracaoImportacaoAdicao" || parametro.FieldName == "id_declaracao_importacao_adicao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.DeclaracaoImportacaoAdicaoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.DeclaracaoImportacaoAdicaoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  declaracao_importacao_adicao_item.id_declaracao_importacao_adicao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  declaracao_importacao_adicao_item.id_declaracao_importacao_adicao = :declaracao_importacao_adicao_item_DeclaracaoImportacaoAdicao_5041 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("declaracao_importacao_adicao_item_DeclaracaoImportacaoAdicao_5041", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  declaracao_importacao_adicao_item.id_material IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  declaracao_importacao_adicao_item.id_material = :declaracao_importacao_adicao_item_Material_3743 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("declaracao_importacao_adicao_item_Material_3743", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AliquotaIi" || parametro.FieldName == "dai_aliquota_ii")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  declaracao_importacao_adicao_item.dai_aliquota_ii IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  declaracao_importacao_adicao_item.dai_aliquota_ii = :declaracao_importacao_adicao_item_AliquotaIi_808 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("declaracao_importacao_adicao_item_AliquotaIi_808", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Quantidade" || parametro.FieldName == "dai_quantidade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  declaracao_importacao_adicao_item.dai_quantidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  declaracao_importacao_adicao_item.dai_quantidade = :declaracao_importacao_adicao_item_Quantidade_1764 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("declaracao_importacao_adicao_item_Quantidade_1764", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorUnitarioDolares" || parametro.FieldName == "dai_valor_unitario_dolares")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  declaracao_importacao_adicao_item.dai_valor_unitario_dolares IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  declaracao_importacao_adicao_item.dai_valor_unitario_dolares = :declaracao_importacao_adicao_item_ValorUnitarioDolares_2575 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("declaracao_importacao_adicao_item_ValorUnitarioDolares_2575", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorUnitarioReais" || parametro.FieldName == "dai_valor_unitario_reais")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  declaracao_importacao_adicao_item.dai_valor_unitario_reais IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  declaracao_importacao_adicao_item.dai_valor_unitario_reais = :declaracao_importacao_adicao_item_ValorUnitarioReais_7501 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("declaracao_importacao_adicao_item_ValorUnitarioReais_7501", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorTotalDolares" || parametro.FieldName == "dai_valor_total_dolares")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  declaracao_importacao_adicao_item.dai_valor_total_dolares IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  declaracao_importacao_adicao_item.dai_valor_total_dolares = :declaracao_importacao_adicao_item_ValorTotalDolares_8374 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("declaracao_importacao_adicao_item_ValorTotalDolares_8374", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorTotalReais" || parametro.FieldName == "dai_valor_total_reais")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  declaracao_importacao_adicao_item.dai_valor_total_reais IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  declaracao_importacao_adicao_item.dai_valor_total_reais = :declaracao_importacao_adicao_item_ValorTotalReais_3632 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("declaracao_importacao_adicao_item_ValorTotalReais_3632", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroSequencialNaAdicao" || parametro.FieldName == "dai_numero_sequencial_na_adicao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  declaracao_importacao_adicao_item.dai_numero_sequencial_na_adicao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  declaracao_importacao_adicao_item.dai_numero_sequencial_na_adicao = :declaracao_importacao_adicao_item_NumeroSequencialNaAdicao_9888 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("declaracao_importacao_adicao_item_NumeroSequencialNaAdicao_9888", NpgsqlDbType.Smallint, parametro.Fieldvalue));
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
                         whereClause += "  declaracao_importacao_adicao_item.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  declaracao_importacao_adicao_item.version = :declaracao_importacao_adicao_item_Version_2181 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("declaracao_importacao_adicao_item_Version_2181", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  declaracao_importacao_adicao_item.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  declaracao_importacao_adicao_item.entity_uid LIKE :declaracao_importacao_adicao_item_EntityUid_1245 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("declaracao_importacao_adicao_item_EntityUid_1245", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  declaracao_importacao_adicao_item.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  declaracao_importacao_adicao_item.entity_uid LIKE :declaracao_importacao_adicao_item_EntityUid_1353 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("declaracao_importacao_adicao_item_EntityUid_1353", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  DeclaracaoImportacaoAdicaoItemClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (DeclaracaoImportacaoAdicaoItemClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(DeclaracaoImportacaoAdicaoItemClass), Convert.ToInt32(read["id_declaracao_importacao_adicao_item"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new DeclaracaoImportacaoAdicaoItemClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_declaracao_importacao_adicao_item"]);
                     if (read["id_declaracao_importacao_adicao"] != DBNull.Value)
                     {
                        entidade.DeclaracaoImportacaoAdicao = (BibliotecaEntidades.Entidades.DeclaracaoImportacaoAdicaoClass)BibliotecaEntidades.Entidades.DeclaracaoImportacaoAdicaoClass.GetEntidade(Convert.ToInt32(read["id_declaracao_importacao_adicao"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.DeclaracaoImportacaoAdicao = null ;
                     }
                     if (read["id_material"] != DBNull.Value)
                     {
                        entidade.Material = (BibliotecaEntidades.Entidades.MaterialClass)BibliotecaEntidades.Entidades.MaterialClass.GetEntidade(Convert.ToInt32(read["id_material"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Material = null ;
                     }
                     entidade.AliquotaIi = (double)read["dai_aliquota_ii"];
                     entidade.Quantidade = (double)read["dai_quantidade"];
                     entidade.ValorUnitarioDolares = (double)read["dai_valor_unitario_dolares"];
                     entidade.ValorUnitarioReais = (double)read["dai_valor_unitario_reais"];
                     entidade.ValorTotalDolares = (double)read["dai_valor_total_dolares"];
                     entidade.ValorTotalReais = (double)read["dai_valor_total_reais"];
                     entidade.NumeroSequencialNaAdicao = (short)read["dai_numero_sequencial_na_adicao"];
                     entidade.Version = (int)read["version"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (DeclaracaoImportacaoAdicaoItemClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
