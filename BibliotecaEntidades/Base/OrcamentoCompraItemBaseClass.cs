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
     [Table("orcamento_compra_item","oci")]
     public class OrcamentoCompraItemBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do OrcamentoCompraItemClass";
protected const string ErroDelete = "Erro ao excluir o OrcamentoCompraItemClass  ";
protected const string ErroSave = "Erro ao salvar o OrcamentoCompraItemClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroOrcamentoCompraObrigatorio = "O campo OrcamentoCompra é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do OrcamentoCompraItemClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade OrcamentoCompraItemClass está sendo utilizada.";
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
         [Column("oci_quantidade")]
        public virtual double Quantidade
         { 
            get { return this._valueQuantidade; } 
            set 
            { 
                if (this._valueQuantidade == value)return;
                 this._valueQuantidade = value; 
            } 
        } 

       protected double? _valorRecebidoOriginal{get;private set;}
       private double? _valorRecebidoOriginalCommited{get; set;}
        private double? _valueValorRecebido;
         [Column("oci_valor_recebido")]
        public virtual double? ValorRecebido
         { 
            get { return this._valueValorRecebido; } 
            set 
            { 
                if (this._valueValorRecebido == value)return;
                 this._valueValorRecebido = value; 
            } 
        } 

       protected DateTime? _dataRecebimentoOriginal{get;private set;}
       private DateTime? _dataRecebimentoOriginalCommited{get; set;}
        private DateTime? _valueDataRecebimento;
         [Column("oci_data_recebimento")]
        public virtual DateTime? DataRecebimento
         { 
            get { return this._valueDataRecebimento; } 
            set 
            { 
                if (this._valueDataRecebimento == value)return;
                 this._valueDataRecebimento = value; 
            } 
        } 

       protected IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioRecebimentoOriginal{get;private set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioRecebimentoOriginalCommited {get; set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _valueAcsUsuarioRecebimento;
        [Column("id_acs_usuario_recebimento", "acs_usuario", "id_acs_usuario")]
       public virtual IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass AcsUsuarioRecebimento
        { 
           get {                 return this._valueAcsUsuarioRecebimento; } 
           set 
           { 
                if (this._valueAcsUsuarioRecebimento == value)return;
                 this._valueAcsUsuarioRecebimento = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.OrcamentoCompraClass _orcamentoCompraOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.OrcamentoCompraClass _orcamentoCompraOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.OrcamentoCompraClass _valueOrcamentoCompra;
        [Column("id_orcamento_compra", "orcamento_compra", "id_orcamento_compra")]
       public virtual BibliotecaEntidades.Entidades.OrcamentoCompraClass OrcamentoCompra
        { 
           get {                 return this._valueOrcamentoCompra; } 
           set 
           { 
                if (this._valueOrcamentoCompra == value)return;
                 this._valueOrcamentoCompra = value; 
           } 
       } 

       protected double? _ipiRecebimentoOriginal{get;private set;}
       private double? _ipiRecebimentoOriginalCommited{get; set;}
        private double? _valueIpiRecebimento;
         [Column("oci_ipi_recebimento")]
        public virtual double? IpiRecebimento
         { 
            get { return this._valueIpiRecebimento; } 
            set 
            { 
                if (this._valueIpiRecebimento == value)return;
                 this._valueIpiRecebimento = value; 
            } 
        } 

       protected double? _icmsRecebimentoOriginal{get;private set;}
       private double? _icmsRecebimentoOriginalCommited{get; set;}
        private double? _valueIcmsRecebimento;
         [Column("oci_icms_recebimento")]
        public virtual double? IcmsRecebimento
         { 
            get { return this._valueIcmsRecebimento; } 
            set 
            { 
                if (this._valueIcmsRecebimento == value)return;
                 this._valueIcmsRecebimento = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.EpiClass _epiOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.EpiClass _epiOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.EpiClass _valueEpi;
        [Column("id_epi", "epi", "id_epi")]
       public virtual BibliotecaEntidades.Entidades.EpiClass Epi
        { 
           get {                 return this._valueEpi; } 
           set 
           { 
                if (this._valueEpi == value)return;
                 this._valueEpi = value; 
           } 
       } 

        public OrcamentoCompraItemBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static OrcamentoCompraItemClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (OrcamentoCompraItemClass) GetEntity(typeof(OrcamentoCompraItemClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if ( _valueOrcamentoCompra == null)
                {
                    throw new Exception(ErroOrcamentoCompraObrigatorio);
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
                    "  public.orcamento_compra_item  " +
                    "WHERE " +
                    "  id_orcamento_compra_item = :id";
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
                        "  public.orcamento_compra_item   " +
                        "SET  " + 
                        "  id_produto = :id_produto, " + 
                        "  id_material = :id_material, " + 
                        "  oci_quantidade = :oci_quantidade, " + 
                        "  oci_valor_recebido = :oci_valor_recebido, " + 
                        "  oci_data_recebimento = :oci_data_recebimento, " + 
                        "  id_acs_usuario_recebimento = :id_acs_usuario_recebimento, " + 
                        "  id_orcamento_compra = :id_orcamento_compra, " + 
                        "  oci_ipi_recebimento = :oci_ipi_recebimento, " + 
                        "  oci_icms_recebimento = :oci_icms_recebimento, " + 
                        "  id_epi = :id_epi, " + 
                        "  version = :version, " + 
                        "  entity_uid = :entity_uid "+
                        "WHERE  " +
                        "  id_orcamento_compra_item = :id " +
                        "RETURNING id_orcamento_compra_item;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.orcamento_compra_item " +
                        "( " +
                        "  id_produto , " + 
                        "  id_material , " + 
                        "  oci_quantidade , " + 
                        "  oci_valor_recebido , " + 
                        "  oci_data_recebimento , " + 
                        "  id_acs_usuario_recebimento , " + 
                        "  id_orcamento_compra , " + 
                        "  oci_ipi_recebimento , " + 
                        "  oci_icms_recebimento , " + 
                        "  id_epi , " + 
                        "  version , " + 
                        "  entity_uid  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_produto , " + 
                        "  :id_material , " + 
                        "  :oci_quantidade , " + 
                        "  :oci_valor_recebido , " + 
                        "  :oci_data_recebimento , " + 
                        "  :id_acs_usuario_recebimento , " + 
                        "  :id_orcamento_compra , " + 
                        "  :oci_ipi_recebimento , " + 
                        "  :oci_icms_recebimento , " + 
                        "  :id_epi , " + 
                        "  :version , " + 
                        "  :entity_uid  "+
                        ")RETURNING id_orcamento_compra_item;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Produto==null ? (object) DBNull.Value : this.Produto.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_material", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Material==null ? (object) DBNull.Value : this.Material.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oci_quantidade", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Quantidade ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oci_valor_recebido", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorRecebido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oci_data_recebimento", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataRecebimento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_recebimento", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuarioRecebimento==null ? (object) DBNull.Value : this.AcsUsuarioRecebimento.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_orcamento_compra", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.OrcamentoCompra==null ? (object) DBNull.Value : this.OrcamentoCompra.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oci_ipi_recebimento", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IpiRecebimento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oci_icms_recebimento", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IcmsRecebimento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_epi", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Epi==null ? (object) DBNull.Value : this.Epi.ID;
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
        public static OrcamentoCompraItemClass CopiarEntidade(OrcamentoCompraItemClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               OrcamentoCompraItemClass toRet = new OrcamentoCompraItemClass(usuario,conn);
 toRet.Produto= entidadeCopiar.Produto;
 toRet.Material= entidadeCopiar.Material;
 toRet.Quantidade= entidadeCopiar.Quantidade;
 toRet.ValorRecebido= entidadeCopiar.ValorRecebido;
 toRet.DataRecebimento= entidadeCopiar.DataRecebimento;
 toRet.AcsUsuarioRecebimento= entidadeCopiar.AcsUsuarioRecebimento;
 toRet.OrcamentoCompra= entidadeCopiar.OrcamentoCompra;
 toRet.IpiRecebimento= entidadeCopiar.IpiRecebimento;
 toRet.IcmsRecebimento= entidadeCopiar.IcmsRecebimento;
 toRet.Epi= entidadeCopiar.Epi;

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
       _valorRecebidoOriginal = ValorRecebido;
       _valorRecebidoOriginalCommited = _valorRecebidoOriginal;
       _dataRecebimentoOriginal = DataRecebimento;
       _dataRecebimentoOriginalCommited = _dataRecebimentoOriginal;
       _acsUsuarioRecebimentoOriginal = AcsUsuarioRecebimento;
       _acsUsuarioRecebimentoOriginalCommited = _acsUsuarioRecebimentoOriginal;
       _orcamentoCompraOriginal = OrcamentoCompra;
       _orcamentoCompraOriginalCommited = _orcamentoCompraOriginal;
       _ipiRecebimentoOriginal = IpiRecebimento;
       _ipiRecebimentoOriginalCommited = _ipiRecebimentoOriginal;
       _icmsRecebimentoOriginal = IcmsRecebimento;
       _icmsRecebimentoOriginalCommited = _icmsRecebimentoOriginal;
       _epiOriginal = Epi;
       _epiOriginalCommited = _epiOriginal;
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
       _produtoOriginalCommited = Produto;
       _materialOriginalCommited = Material;
       _quantidadeOriginalCommited = Quantidade;
       _valorRecebidoOriginalCommited = ValorRecebido;
       _dataRecebimentoOriginalCommited = DataRecebimento;
       _acsUsuarioRecebimentoOriginalCommited = AcsUsuarioRecebimento;
       _orcamentoCompraOriginalCommited = OrcamentoCompra;
       _ipiRecebimentoOriginalCommited = IpiRecebimento;
       _icmsRecebimentoOriginalCommited = IcmsRecebimento;
       _epiOriginalCommited = Epi;
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
               Produto=_produtoOriginal;
               _produtoOriginalCommited=_produtoOriginal;
               Material=_materialOriginal;
               _materialOriginalCommited=_materialOriginal;
               Quantidade=_quantidadeOriginal;
               _quantidadeOriginalCommited=_quantidadeOriginal;
               ValorRecebido=_valorRecebidoOriginal;
               _valorRecebidoOriginalCommited=_valorRecebidoOriginal;
               DataRecebimento=_dataRecebimentoOriginal;
               _dataRecebimentoOriginalCommited=_dataRecebimentoOriginal;
               AcsUsuarioRecebimento=_acsUsuarioRecebimentoOriginal;
               _acsUsuarioRecebimentoOriginalCommited=_acsUsuarioRecebimentoOriginal;
               OrcamentoCompra=_orcamentoCompraOriginal;
               _orcamentoCompraOriginalCommited=_orcamentoCompraOriginal;
               IpiRecebimento=_ipiRecebimentoOriginal;
               _ipiRecebimentoOriginalCommited=_ipiRecebimentoOriginal;
               IcmsRecebimento=_icmsRecebimentoOriginal;
               _icmsRecebimentoOriginalCommited=_icmsRecebimentoOriginal;
               Epi=_epiOriginal;
               _epiOriginalCommited=_epiOriginal;
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
       dirty = _valorRecebidoOriginal != ValorRecebido;
      if (dirty) return true;
       dirty = _dataRecebimentoOriginal != DataRecebimento;
      if (dirty) return true;
       if (_acsUsuarioRecebimentoOriginal!=null)
       {
          dirty = !_acsUsuarioRecebimentoOriginal.Equals(AcsUsuarioRecebimento);
       }
       else
       {
            dirty = AcsUsuarioRecebimento != null;
       }
      if (dirty) return true;
       if (_orcamentoCompraOriginal!=null)
       {
          dirty = !_orcamentoCompraOriginal.Equals(OrcamentoCompra);
       }
       else
       {
            dirty = OrcamentoCompra != null;
       }
      if (dirty) return true;
       dirty = _ipiRecebimentoOriginal != IpiRecebimento;
      if (dirty) return true;
       dirty = _icmsRecebimentoOriginal != IcmsRecebimento;
      if (dirty) return true;
       if (_epiOriginal!=null)
       {
          dirty = !_epiOriginal.Equals(Epi);
       }
       else
       {
            dirty = Epi != null;
       }
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
       dirty = _valorRecebidoOriginalCommited != ValorRecebido;
      if (dirty) return true;
       dirty = _dataRecebimentoOriginalCommited != DataRecebimento;
      if (dirty) return true;
       if (_acsUsuarioRecebimentoOriginalCommited!=null)
       {
          dirty = !_acsUsuarioRecebimentoOriginalCommited.Equals(AcsUsuarioRecebimento);
       }
       else
       {
            dirty = AcsUsuarioRecebimento != null;
       }
      if (dirty) return true;
       if (_orcamentoCompraOriginalCommited!=null)
       {
          dirty = !_orcamentoCompraOriginalCommited.Equals(OrcamentoCompra);
       }
       else
       {
            dirty = OrcamentoCompra != null;
       }
      if (dirty) return true;
       dirty = _ipiRecebimentoOriginalCommited != IpiRecebimento;
      if (dirty) return true;
       dirty = _icmsRecebimentoOriginalCommited != IcmsRecebimento;
      if (dirty) return true;
       if (_epiOriginalCommited!=null)
       {
          dirty = !_epiOriginalCommited.Equals(Epi);
       }
       else
       {
            dirty = Epi != null;
       }
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
             case "Produto":
                return this.Produto;
             case "Material":
                return this.Material;
             case "Quantidade":
                return this.Quantidade;
             case "ValorRecebido":
                return this.ValorRecebido;
             case "DataRecebimento":
                return this.DataRecebimento;
             case "AcsUsuarioRecebimento":
                return this.AcsUsuarioRecebimento;
             case "OrcamentoCompra":
                return this.OrcamentoCompra;
             case "IpiRecebimento":
                return this.IpiRecebimento;
             case "IcmsRecebimento":
                return this.IcmsRecebimento;
             case "Epi":
                return this.Epi;
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
             if (Produto!=null)
                Produto.ChangeSingleConnection(newConnection);
             if (Material!=null)
                Material.ChangeSingleConnection(newConnection);
             if (AcsUsuarioRecebimento!=null)
                AcsUsuarioRecebimento.ChangeSingleConnection(newConnection);
             if (OrcamentoCompra!=null)
                OrcamentoCompra.ChangeSingleConnection(newConnection);
             if (Epi!=null)
                Epi.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(orcamento_compra_item.id_orcamento_compra_item) " ;
               }
               else
               {
               command.CommandText += "orcamento_compra_item.id_orcamento_compra_item, " ;
               command.CommandText += "orcamento_compra_item.id_produto, " ;
               command.CommandText += "orcamento_compra_item.id_material, " ;
               command.CommandText += "orcamento_compra_item.oci_quantidade, " ;
               command.CommandText += "orcamento_compra_item.oci_valor_recebido, " ;
               command.CommandText += "orcamento_compra_item.oci_data_recebimento, " ;
               command.CommandText += "orcamento_compra_item.id_acs_usuario_recebimento, " ;
               command.CommandText += "orcamento_compra_item.id_orcamento_compra, " ;
               command.CommandText += "orcamento_compra_item.oci_ipi_recebimento, " ;
               command.CommandText += "orcamento_compra_item.oci_icms_recebimento, " ;
               command.CommandText += "orcamento_compra_item.id_epi, " ;
               command.CommandText += "orcamento_compra_item.version, " ;
               command.CommandText += "orcamento_compra_item.entity_uid " ;
               }
               command.CommandText += " FROM  orcamento_compra_item ";
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
                        orderByClause += " , oci_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(oci_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = orcamento_compra_item.id_acs_usuario_ultima_revisao ";
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
                     case "id_orcamento_compra_item":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_compra_item.id_orcamento_compra_item " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_compra_item.id_orcamento_compra_item) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_produto":
                     case "Produto":
                     command.CommandText += " LEFT JOIN produto as produto_Produto ON produto_Produto.id_produto = orcamento_compra_item.id_produto ";                     switch (parametro.TipoOrdenacao)
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
                     command.CommandText += " LEFT JOIN material as material_Material ON material_Material.id_material = orcamento_compra_item.id_material ";                     switch (parametro.TipoOrdenacao)
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
                     case "oci_quantidade":
                     case "Quantidade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_compra_item.oci_quantidade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_compra_item.oci_quantidade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oci_valor_recebido":
                     case "ValorRecebido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_compra_item.oci_valor_recebido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_compra_item.oci_valor_recebido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oci_data_recebimento":
                     case "DataRecebimento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_compra_item.oci_data_recebimento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_compra_item.oci_data_recebimento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_recebimento":
                     case "AcsUsuarioRecebimento":
                     orderByClause += " , orcamento_compra_item.id_acs_usuario_recebimento " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "id_orcamento_compra":
                     case "OrcamentoCompra":
                     command.CommandText += " LEFT JOIN orcamento_compra as orcamento_compra_OrcamentoCompra ON orcamento_compra_OrcamentoCompra.id_orcamento_compra = orcamento_compra_item.id_orcamento_compra ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_compra_OrcamentoCompra.id_orcamento_compra " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_compra_OrcamentoCompra.id_orcamento_compra) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oci_ipi_recebimento":
                     case "IpiRecebimento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_compra_item.oci_ipi_recebimento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_compra_item.oci_ipi_recebimento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oci_icms_recebimento":
                     case "IcmsRecebimento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_compra_item.oci_icms_recebimento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_compra_item.oci_icms_recebimento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_epi":
                     case "Epi":
                     command.CommandText += " LEFT JOIN epi as epi_Epi ON epi_Epi.id_epi = orcamento_compra_item.id_epi ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , epi_Epi.epi_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(epi_Epi.epi_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , orcamento_compra_item.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_compra_item.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_compra_item.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_compra_item.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           whereClause += " OR UPPER(orcamento_compra_item.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_compra_item.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_orcamento_compra_item")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_compra_item.id_orcamento_compra_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_compra_item.id_orcamento_compra_item = :orcamento_compra_item_ID_4710 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_compra_item_ID_4710", NpgsqlDbType.Bigint, parametro.Fieldvalue));
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
                         whereClause += "  orcamento_compra_item.id_produto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_compra_item.id_produto = :orcamento_compra_item_Produto_5798 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_compra_item_Produto_5798", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  orcamento_compra_item.id_material IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_compra_item.id_material = :orcamento_compra_item_Material_8896 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_compra_item_Material_8896", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Quantidade" || parametro.FieldName == "oci_quantidade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_compra_item.oci_quantidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_compra_item.oci_quantidade = :orcamento_compra_item_Quantidade_5738 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_compra_item_Quantidade_5738", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorRecebido" || parametro.FieldName == "oci_valor_recebido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_compra_item.oci_valor_recebido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_compra_item.oci_valor_recebido = :orcamento_compra_item_ValorRecebido_6677 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_compra_item_ValorRecebido_6677", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataRecebimento" || parametro.FieldName == "oci_data_recebimento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_compra_item.oci_data_recebimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_compra_item.oci_data_recebimento = :orcamento_compra_item_DataRecebimento_899 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_compra_item_DataRecebimento_899", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcsUsuarioRecebimento" || parametro.FieldName == "id_acs_usuario_recebimento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_compra_item.id_acs_usuario_recebimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_compra_item.id_acs_usuario_recebimento = :orcamento_compra_item_AcsUsuarioRecebimento_2199 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_compra_item_AcsUsuarioRecebimento_2199", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrcamentoCompra" || parametro.FieldName == "id_orcamento_compra")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.OrcamentoCompraClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.OrcamentoCompraClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_compra_item.id_orcamento_compra IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_compra_item.id_orcamento_compra = :orcamento_compra_item_OrcamentoCompra_6285 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_compra_item_OrcamentoCompra_6285", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IpiRecebimento" || parametro.FieldName == "oci_ipi_recebimento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_compra_item.oci_ipi_recebimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_compra_item.oci_ipi_recebimento = :orcamento_compra_item_IpiRecebimento_1240 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_compra_item_IpiRecebimento_1240", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IcmsRecebimento" || parametro.FieldName == "oci_icms_recebimento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_compra_item.oci_icms_recebimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_compra_item.oci_icms_recebimento = :orcamento_compra_item_IcmsRecebimento_7656 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_compra_item_IcmsRecebimento_7656", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Epi" || parametro.FieldName == "id_epi")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.EpiClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.EpiClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_compra_item.id_epi IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_compra_item.id_epi = :orcamento_compra_item_Epi_1408 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_compra_item_Epi_1408", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  orcamento_compra_item.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_compra_item.version = :orcamento_compra_item_Version_9976 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_compra_item_Version_9976", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  orcamento_compra_item.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_compra_item.entity_uid LIKE :orcamento_compra_item_EntityUid_4656 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_compra_item_EntityUid_4656", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  orcamento_compra_item.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_compra_item.entity_uid LIKE :orcamento_compra_item_EntityUid_4536 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_compra_item_EntityUid_4536", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  OrcamentoCompraItemClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (OrcamentoCompraItemClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(OrcamentoCompraItemClass), Convert.ToInt32(read["id_orcamento_compra_item"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new OrcamentoCompraItemClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_orcamento_compra_item"]);
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
                     entidade.Quantidade = (double)read["oci_quantidade"];
                     entidade.ValorRecebido = read["oci_valor_recebido"] as double?;
                     entidade.DataRecebimento = read["oci_data_recebimento"] as DateTime?;
                     if (read["id_acs_usuario_recebimento"] != DBNull.Value)
                     {
                        entidade.AcsUsuarioRecebimento = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_recebimento"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuarioRecebimento = null ;
                     }
                     if (read["id_orcamento_compra"] != DBNull.Value)
                     {
                        entidade.OrcamentoCompra = (BibliotecaEntidades.Entidades.OrcamentoCompraClass)BibliotecaEntidades.Entidades.OrcamentoCompraClass.GetEntidade(Convert.ToInt32(read["id_orcamento_compra"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.OrcamentoCompra = null ;
                     }
                     entidade.IpiRecebimento = read["oci_ipi_recebimento"] as double?;
                     entidade.IcmsRecebimento = read["oci_icms_recebimento"] as double?;
                     if (read["id_epi"] != DBNull.Value)
                     {
                        entidade.Epi = (BibliotecaEntidades.Entidades.EpiClass)BibliotecaEntidades.Entidades.EpiClass.GetEntidade(Convert.ToInt32(read["id_epi"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Epi = null ;
                     }
                     entidade.Version = (int)read["version"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (OrcamentoCompraItemClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
