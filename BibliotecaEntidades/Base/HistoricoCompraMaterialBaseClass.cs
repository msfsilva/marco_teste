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
     [Table("historico_compra_material","hcm")]
     public class HistoricoCompraMaterialBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do HistoricoCompraMaterialClass";
protected const string ErroDelete = "Erro ao excluir o HistoricoCompraMaterialClass  ";
protected const string ErroSave = "Erro ao salvar o HistoricoCompraMaterialClass.";
protected const string ErroNumeroNotaEntradaObrigatorio = "O campo NumeroNotaEntrada é obrigatório";
protected const string ErroNumeroNotaEntradaComprimento = "O campo NumeroNotaEntrada deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroMaterialObrigatorio = "O campo Material é obrigatório";
protected const string ErroFornecedorObrigatorio = "O campo Fornecedor é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do HistoricoCompraMaterialClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade HistoricoCompraMaterialClass está sendo utilizada.";
#endregion
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

       protected BibliotecaEntidades.Entidades.MarcaClass _marcaOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.MarcaClass _marcaOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.MarcaClass _valueMarca;
        [Column("id_marca", "marca", "id_marca")]
       public virtual BibliotecaEntidades.Entidades.MarcaClass Marca
        { 
           get {                 return this._valueMarca; } 
           set 
           { 
                if (this._valueMarca == value)return;
                 this._valueMarca = value; 
           } 
       } 

       protected string _numeroNotaEntradaOriginal{get;private set;}
       private string _numeroNotaEntradaOriginalCommited{get; set;}
        private string _valueNumeroNotaEntrada;
         [Column("hcm_numero_nota_entrada")]
        public virtual string NumeroNotaEntrada
         { 
            get { return this._valueNumeroNotaEntrada; } 
            set 
            { 
                if (this._valueNumeroNotaEntrada == value)return;
                 this._valueNumeroNotaEntrada = value; 
            } 
        } 

       protected DateTime _dataOcOriginal{get;private set;}
       private DateTime _dataOcOriginalCommited{get; set;}
        private DateTime _valueDataOc;
         [Column("hcm_data_oc")]
        public virtual DateTime DataOc
         { 
            get { return this._valueDataOc; } 
            set 
            { 
                if (this._valueDataOc == value)return;
                 this._valueDataOc = value; 
            } 
        } 

       protected DateTime _dataRecebimentoOriginal{get;private set;}
       private DateTime _dataRecebimentoOriginalCommited{get; set;}
        private DateTime _valueDataRecebimento;
         [Column("hcm_data_recebimento")]
        public virtual DateTime DataRecebimento
         { 
            get { return this._valueDataRecebimento; } 
            set 
            { 
                if (this._valueDataRecebimento == value)return;
                 this._valueDataRecebimento = value; 
            } 
        } 

       protected double _precoUnitarioOriginal{get;private set;}
       private double _precoUnitarioOriginalCommited{get; set;}
        private double _valuePrecoUnitario;
         [Column("hcm_preco_unitario")]
        public virtual double PrecoUnitario
         { 
            get { return this._valuePrecoUnitario; } 
            set 
            { 
                if (this._valuePrecoUnitario == value)return;
                 this._valuePrecoUnitario = value; 
            } 
        } 

       protected double _icmInclusoOriginal{get;private set;}
       private double _icmInclusoOriginalCommited{get; set;}
        private double _valueIcmIncluso;
         [Column("hcm_icm_incluso")]
        public virtual double IcmIncluso
         { 
            get { return this._valueIcmIncluso; } 
            set 
            { 
                if (this._valueIcmIncluso == value)return;
                 this._valueIcmIncluso = value; 
            } 
        } 

       protected double _ipiNaoInclusoOriginal{get;private set;}
       private double _ipiNaoInclusoOriginalCommited{get; set;}
        private double _valueIpiNaoIncluso;
         [Column("hcm_ipi_nao_incluso")]
        public virtual double IpiNaoIncluso
         { 
            get { return this._valueIpiNaoIncluso; } 
            set 
            { 
                if (this._valueIpiNaoIncluso == value)return;
                 this._valueIpiNaoIncluso = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.NotaFiscalEntradaLinhaClass _notaFiscalEntradaLinhaOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.NotaFiscalEntradaLinhaClass _notaFiscalEntradaLinhaOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.NotaFiscalEntradaLinhaClass _valueNotaFiscalEntradaLinha;
        [Column("id_nota_fiscal_entrada_linha", "nota_fiscal_entrada_linha", "id_nota_fiscal_entrada_linha")]
       public virtual BibliotecaEntidades.Entidades.NotaFiscalEntradaLinhaClass NotaFiscalEntradaLinha
        { 
           get {                 return this._valueNotaFiscalEntradaLinha; } 
           set 
           { 
                if (this._valueNotaFiscalEntradaLinha == value)return;
                 this._valueNotaFiscalEntradaLinha = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.LoteClass _loteOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.LoteClass _loteOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.LoteClass _valueLote;
        [Column("id_lote", "lote", "id_lote")]
       public virtual BibliotecaEntidades.Entidades.LoteClass Lote
        { 
           get {                 return this._valueLote; } 
           set 
           { 
                if (this._valueLote == value)return;
                 this._valueLote = value; 
           } 
       } 

        public HistoricoCompraMaterialBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.DataRecebimento = Configurations.DataIndependenteClass.GetData();
           this.PrecoUnitario = 0;
           this.IcmIncluso = 0;
           this.IpiNaoIncluso = 0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static HistoricoCompraMaterialClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (HistoricoCompraMaterialClass) GetEntity(typeof(HistoricoCompraMaterialClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(NumeroNotaEntrada))
                {
                    throw new Exception(ErroNumeroNotaEntradaObrigatorio);
                }
                if (NumeroNotaEntrada.Length >255)
                {
                    throw new Exception( ErroNumeroNotaEntradaComprimento);
                }
                if ( _valueMaterial == null)
                {
                    throw new Exception(ErroMaterialObrigatorio);
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
                    "  public.historico_compra_material  " +
                    "WHERE " +
                    "  id_historico_compra_material = :id";
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
                        "  public.historico_compra_material   " +
                        "SET  " + 
                        "  id_material = :id_material, " + 
                        "  id_fornecedor = :id_fornecedor, " + 
                        "  id_marca = :id_marca, " + 
                        "  hcm_numero_nota_entrada = :hcm_numero_nota_entrada, " + 
                        "  hcm_data_oc = :hcm_data_oc, " + 
                        "  hcm_data_recebimento = :hcm_data_recebimento, " + 
                        "  hcm_preco_unitario = :hcm_preco_unitario, " + 
                        "  hcm_icm_incluso = :hcm_icm_incluso, " + 
                        "  hcm_ipi_nao_incluso = :hcm_ipi_nao_incluso, " + 
                        "  id_nota_fiscal_entrada_linha = :id_nota_fiscal_entrada_linha, " + 
                        "  id_lote = :id_lote, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_historico_compra_material = :id " +
                        "RETURNING id_historico_compra_material;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.historico_compra_material " +
                        "( " +
                        "  id_material , " + 
                        "  id_fornecedor , " + 
                        "  id_marca , " + 
                        "  hcm_numero_nota_entrada , " + 
                        "  hcm_data_oc , " + 
                        "  hcm_data_recebimento , " + 
                        "  hcm_preco_unitario , " + 
                        "  hcm_icm_incluso , " + 
                        "  hcm_ipi_nao_incluso , " + 
                        "  id_nota_fiscal_entrada_linha , " + 
                        "  id_lote , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_material , " + 
                        "  :id_fornecedor , " + 
                        "  :id_marca , " + 
                        "  :hcm_numero_nota_entrada , " + 
                        "  :hcm_data_oc , " + 
                        "  :hcm_data_recebimento , " + 
                        "  :hcm_preco_unitario , " + 
                        "  :hcm_icm_incluso , " + 
                        "  :hcm_ipi_nao_incluso , " + 
                        "  :id_nota_fiscal_entrada_linha , " + 
                        "  :id_lote , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_historico_compra_material;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_material", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Material==null ? (object) DBNull.Value : this.Material.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_fornecedor", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Fornecedor==null ? (object) DBNull.Value : this.Fornecedor.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_marca", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Marca==null ? (object) DBNull.Value : this.Marca.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("hcm_numero_nota_entrada", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NumeroNotaEntrada ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("hcm_data_oc", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataOc ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("hcm_data_recebimento", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataRecebimento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("hcm_preco_unitario", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PrecoUnitario ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("hcm_icm_incluso", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IcmIncluso ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("hcm_ipi_nao_incluso", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IpiNaoIncluso ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nota_fiscal_entrada_linha", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.NotaFiscalEntradaLinha==null ? (object) DBNull.Value : this.NotaFiscalEntradaLinha.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_lote", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Lote==null ? (object) DBNull.Value : this.Lote.ID;
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
        public static HistoricoCompraMaterialClass CopiarEntidade(HistoricoCompraMaterialClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               HistoricoCompraMaterialClass toRet = new HistoricoCompraMaterialClass(usuario,conn);
 toRet.Material= entidadeCopiar.Material;
 toRet.Fornecedor= entidadeCopiar.Fornecedor;
 toRet.Marca= entidadeCopiar.Marca;
 toRet.NumeroNotaEntrada= entidadeCopiar.NumeroNotaEntrada;
 toRet.DataOc= entidadeCopiar.DataOc;
 toRet.DataRecebimento= entidadeCopiar.DataRecebimento;
 toRet.PrecoUnitario= entidadeCopiar.PrecoUnitario;
 toRet.IcmIncluso= entidadeCopiar.IcmIncluso;
 toRet.IpiNaoIncluso= entidadeCopiar.IpiNaoIncluso;
 toRet.NotaFiscalEntradaLinha= entidadeCopiar.NotaFiscalEntradaLinha;
 toRet.Lote= entidadeCopiar.Lote;

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
       _materialOriginal = Material;
       _materialOriginalCommited = _materialOriginal;
       _fornecedorOriginal = Fornecedor;
       _fornecedorOriginalCommited = _fornecedorOriginal;
       _marcaOriginal = Marca;
       _marcaOriginalCommited = _marcaOriginal;
       _numeroNotaEntradaOriginal = NumeroNotaEntrada;
       _numeroNotaEntradaOriginalCommited = _numeroNotaEntradaOriginal;
       _dataOcOriginal = DataOc;
       _dataOcOriginalCommited = _dataOcOriginal;
       _dataRecebimentoOriginal = DataRecebimento;
       _dataRecebimentoOriginalCommited = _dataRecebimentoOriginal;
       _precoUnitarioOriginal = PrecoUnitario;
       _precoUnitarioOriginalCommited = _precoUnitarioOriginal;
       _icmInclusoOriginal = IcmIncluso;
       _icmInclusoOriginalCommited = _icmInclusoOriginal;
       _ipiNaoInclusoOriginal = IpiNaoIncluso;
       _ipiNaoInclusoOriginalCommited = _ipiNaoInclusoOriginal;
       _notaFiscalEntradaLinhaOriginal = NotaFiscalEntradaLinha;
       _notaFiscalEntradaLinhaOriginalCommited = _notaFiscalEntradaLinhaOriginal;
       _loteOriginal = Lote;
       _loteOriginalCommited = _loteOriginal;
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
       _materialOriginalCommited = Material;
       _fornecedorOriginalCommited = Fornecedor;
       _marcaOriginalCommited = Marca;
       _numeroNotaEntradaOriginalCommited = NumeroNotaEntrada;
       _dataOcOriginalCommited = DataOc;
       _dataRecebimentoOriginalCommited = DataRecebimento;
       _precoUnitarioOriginalCommited = PrecoUnitario;
       _icmInclusoOriginalCommited = IcmIncluso;
       _ipiNaoInclusoOriginalCommited = IpiNaoIncluso;
       _notaFiscalEntradaLinhaOriginalCommited = NotaFiscalEntradaLinha;
       _loteOriginalCommited = Lote;
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
               Material=_materialOriginal;
               _materialOriginalCommited=_materialOriginal;
               Fornecedor=_fornecedorOriginal;
               _fornecedorOriginalCommited=_fornecedorOriginal;
               Marca=_marcaOriginal;
               _marcaOriginalCommited=_marcaOriginal;
               NumeroNotaEntrada=_numeroNotaEntradaOriginal;
               _numeroNotaEntradaOriginalCommited=_numeroNotaEntradaOriginal;
               DataOc=_dataOcOriginal;
               _dataOcOriginalCommited=_dataOcOriginal;
               DataRecebimento=_dataRecebimentoOriginal;
               _dataRecebimentoOriginalCommited=_dataRecebimentoOriginal;
               PrecoUnitario=_precoUnitarioOriginal;
               _precoUnitarioOriginalCommited=_precoUnitarioOriginal;
               IcmIncluso=_icmInclusoOriginal;
               _icmInclusoOriginalCommited=_icmInclusoOriginal;
               IpiNaoIncluso=_ipiNaoInclusoOriginal;
               _ipiNaoInclusoOriginalCommited=_ipiNaoInclusoOriginal;
               NotaFiscalEntradaLinha=_notaFiscalEntradaLinhaOriginal;
               _notaFiscalEntradaLinhaOriginalCommited=_notaFiscalEntradaLinhaOriginal;
               Lote=_loteOriginal;
               _loteOriginalCommited=_loteOriginal;
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
       if (_materialOriginal!=null)
       {
          dirty = !_materialOriginal.Equals(Material);
       }
       else
       {
            dirty = Material != null;
       }
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
       if (_marcaOriginal!=null)
       {
          dirty = !_marcaOriginal.Equals(Marca);
       }
       else
       {
            dirty = Marca != null;
       }
      if (dirty) return true;
       dirty = _numeroNotaEntradaOriginal != NumeroNotaEntrada;
      if (dirty) return true;
       dirty = _dataOcOriginal != DataOc;
      if (dirty) return true;
       dirty = _dataRecebimentoOriginal != DataRecebimento;
      if (dirty) return true;
       dirty = _precoUnitarioOriginal != PrecoUnitario;
      if (dirty) return true;
       dirty = _icmInclusoOriginal != IcmIncluso;
      if (dirty) return true;
       dirty = _ipiNaoInclusoOriginal != IpiNaoIncluso;
      if (dirty) return true;
       if (_notaFiscalEntradaLinhaOriginal!=null)
       {
          dirty = !_notaFiscalEntradaLinhaOriginal.Equals(NotaFiscalEntradaLinha);
       }
       else
       {
            dirty = NotaFiscalEntradaLinha != null;
       }
      if (dirty) return true;
       if (_loteOriginal!=null)
       {
          dirty = !_loteOriginal.Equals(Lote);
       }
       else
       {
            dirty = Lote != null;
       }
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
       if (_materialOriginalCommited!=null)
       {
          dirty = !_materialOriginalCommited.Equals(Material);
       }
       else
       {
            dirty = Material != null;
       }
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
       if (_marcaOriginalCommited!=null)
       {
          dirty = !_marcaOriginalCommited.Equals(Marca);
       }
       else
       {
            dirty = Marca != null;
       }
      if (dirty) return true;
       dirty = _numeroNotaEntradaOriginalCommited != NumeroNotaEntrada;
      if (dirty) return true;
       dirty = _dataOcOriginalCommited != DataOc;
      if (dirty) return true;
       dirty = _dataRecebimentoOriginalCommited != DataRecebimento;
      if (dirty) return true;
       dirty = _precoUnitarioOriginalCommited != PrecoUnitario;
      if (dirty) return true;
       dirty = _icmInclusoOriginalCommited != IcmIncluso;
      if (dirty) return true;
       dirty = _ipiNaoInclusoOriginalCommited != IpiNaoIncluso;
      if (dirty) return true;
       if (_notaFiscalEntradaLinhaOriginalCommited!=null)
       {
          dirty = !_notaFiscalEntradaLinhaOriginalCommited.Equals(NotaFiscalEntradaLinha);
       }
       else
       {
            dirty = NotaFiscalEntradaLinha != null;
       }
      if (dirty) return true;
       if (_loteOriginalCommited!=null)
       {
          dirty = !_loteOriginalCommited.Equals(Lote);
       }
       else
       {
            dirty = Lote != null;
       }
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
             case "Material":
                return this.Material;
             case "Fornecedor":
                return this.Fornecedor;
             case "Marca":
                return this.Marca;
             case "NumeroNotaEntrada":
                return this.NumeroNotaEntrada;
             case "DataOc":
                return this.DataOc;
             case "DataRecebimento":
                return this.DataRecebimento;
             case "PrecoUnitario":
                return this.PrecoUnitario;
             case "IcmIncluso":
                return this.IcmIncluso;
             case "IpiNaoIncluso":
                return this.IpiNaoIncluso;
             case "NotaFiscalEntradaLinha":
                return this.NotaFiscalEntradaLinha;
             case "Lote":
                return this.Lote;
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
             if (Material!=null)
                Material.ChangeSingleConnection(newConnection);
             if (Fornecedor!=null)
                Fornecedor.ChangeSingleConnection(newConnection);
             if (Marca!=null)
                Marca.ChangeSingleConnection(newConnection);
             if (NotaFiscalEntradaLinha!=null)
                NotaFiscalEntradaLinha.ChangeSingleConnection(newConnection);
             if (Lote!=null)
                Lote.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(historico_compra_material.id_historico_compra_material) " ;
               }
               else
               {
               command.CommandText += "historico_compra_material.id_historico_compra_material, " ;
               command.CommandText += "historico_compra_material.id_material, " ;
               command.CommandText += "historico_compra_material.id_fornecedor, " ;
               command.CommandText += "historico_compra_material.id_marca, " ;
               command.CommandText += "historico_compra_material.hcm_numero_nota_entrada, " ;
               command.CommandText += "historico_compra_material.hcm_data_oc, " ;
               command.CommandText += "historico_compra_material.hcm_data_recebimento, " ;
               command.CommandText += "historico_compra_material.hcm_preco_unitario, " ;
               command.CommandText += "historico_compra_material.hcm_icm_incluso, " ;
               command.CommandText += "historico_compra_material.hcm_ipi_nao_incluso, " ;
               command.CommandText += "historico_compra_material.id_nota_fiscal_entrada_linha, " ;
               command.CommandText += "historico_compra_material.id_lote, " ;
               command.CommandText += "historico_compra_material.entity_uid, " ;
               command.CommandText += "historico_compra_material.version " ;
               }
               command.CommandText += " FROM  historico_compra_material ";
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
                        orderByClause += " , hcm_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(hcm_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = historico_compra_material.id_acs_usuario_ultima_revisao ";
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
                     case "id_historico_compra_material":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , historico_compra_material.id_historico_compra_material " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(historico_compra_material.id_historico_compra_material) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_material":
                     case "Material":
                     command.CommandText += " LEFT JOIN material as material_Material ON material_Material.id_material = historico_compra_material.id_material ";                     switch (parametro.TipoOrdenacao)
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
                     case "id_fornecedor":
                     case "Fornecedor":
                     command.CommandText += " LEFT JOIN fornecedor as fornecedor_Fornecedor ON fornecedor_Fornecedor.id_fornecedor = historico_compra_material.id_fornecedor ";                     switch (parametro.TipoOrdenacao)
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
                     case "id_marca":
                     case "Marca":
                     command.CommandText += " LEFT JOIN marca as marca_Marca ON marca_Marca.id_marca = historico_compra_material.id_marca ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , marca_Marca.mar_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(marca_Marca.mar_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "hcm_numero_nota_entrada":
                     case "NumeroNotaEntrada":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , historico_compra_material.hcm_numero_nota_entrada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(historico_compra_material.hcm_numero_nota_entrada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "hcm_data_oc":
                     case "DataOc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , historico_compra_material.hcm_data_oc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(historico_compra_material.hcm_data_oc) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "hcm_data_recebimento":
                     case "DataRecebimento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , historico_compra_material.hcm_data_recebimento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(historico_compra_material.hcm_data_recebimento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "hcm_preco_unitario":
                     case "PrecoUnitario":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , historico_compra_material.hcm_preco_unitario " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(historico_compra_material.hcm_preco_unitario) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "hcm_icm_incluso":
                     case "IcmIncluso":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , historico_compra_material.hcm_icm_incluso " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(historico_compra_material.hcm_icm_incluso) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "hcm_ipi_nao_incluso":
                     case "IpiNaoIncluso":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , historico_compra_material.hcm_ipi_nao_incluso " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(historico_compra_material.hcm_ipi_nao_incluso) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_nota_fiscal_entrada_linha":
                     case "NotaFiscalEntradaLinha":
                     command.CommandText += " LEFT JOIN nota_fiscal_entrada_linha as nota_fiscal_entrada_linha_NotaFiscalEntradaLinha ON nota_fiscal_entrada_linha_NotaFiscalEntradaLinha.id_nota_fiscal_entrada_linha = historico_compra_material.id_nota_fiscal_entrada_linha ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nota_fiscal_entrada_linha_NotaFiscalEntradaLinha.id_nota_fiscal_entrada_linha " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nota_fiscal_entrada_linha_NotaFiscalEntradaLinha.id_nota_fiscal_entrada_linha) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_lote":
                     case "Lote":
                     command.CommandText += " LEFT JOIN lote as lote_Lote ON lote_Lote.id_lote = historico_compra_material.id_lote ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , lote_Lote.lot_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(lote_Lote.lot_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , historico_compra_material.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(historico_compra_material.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , historico_compra_material.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(historico_compra_material.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("hcm_numero_nota_entrada")) 
                        {
                           whereClause += " OR UPPER(historico_compra_material.hcm_numero_nota_entrada) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(historico_compra_material.hcm_numero_nota_entrada) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(historico_compra_material.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(historico_compra_material.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_historico_compra_material")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  historico_compra_material.id_historico_compra_material IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  historico_compra_material.id_historico_compra_material = :historico_compra_material_ID_6345 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("historico_compra_material_ID_6345", NpgsqlDbType.Bigint, parametro.Fieldvalue));
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
                         whereClause += "  historico_compra_material.id_material IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  historico_compra_material.id_material = :historico_compra_material_Material_9024 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("historico_compra_material_Material_9024", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  historico_compra_material.id_fornecedor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  historico_compra_material.id_fornecedor = :historico_compra_material_Fornecedor_8232 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("historico_compra_material_Fornecedor_8232", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Marca" || parametro.FieldName == "id_marca")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.MarcaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.MarcaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  historico_compra_material.id_marca IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  historico_compra_material.id_marca = :historico_compra_material_Marca_3869 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("historico_compra_material_Marca_3869", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroNotaEntrada" || parametro.FieldName == "hcm_numero_nota_entrada")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  historico_compra_material.hcm_numero_nota_entrada IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  historico_compra_material.hcm_numero_nota_entrada LIKE :historico_compra_material_NumeroNotaEntrada_3067 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("historico_compra_material_NumeroNotaEntrada_3067", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataOc" || parametro.FieldName == "hcm_data_oc")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  historico_compra_material.hcm_data_oc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  historico_compra_material.hcm_data_oc = :historico_compra_material_DataOc_8083 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("historico_compra_material_DataOc_8083", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataRecebimento" || parametro.FieldName == "hcm_data_recebimento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  historico_compra_material.hcm_data_recebimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  historico_compra_material.hcm_data_recebimento = :historico_compra_material_DataRecebimento_388 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("historico_compra_material_DataRecebimento_388", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PrecoUnitario" || parametro.FieldName == "hcm_preco_unitario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  historico_compra_material.hcm_preco_unitario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  historico_compra_material.hcm_preco_unitario = :historico_compra_material_PrecoUnitario_753 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("historico_compra_material_PrecoUnitario_753", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IcmIncluso" || parametro.FieldName == "hcm_icm_incluso")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  historico_compra_material.hcm_icm_incluso IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  historico_compra_material.hcm_icm_incluso = :historico_compra_material_IcmIncluso_3133 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("historico_compra_material_IcmIncluso_3133", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IpiNaoIncluso" || parametro.FieldName == "hcm_ipi_nao_incluso")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  historico_compra_material.hcm_ipi_nao_incluso IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  historico_compra_material.hcm_ipi_nao_incluso = :historico_compra_material_IpiNaoIncluso_2581 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("historico_compra_material_IpiNaoIncluso_2581", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NotaFiscalEntradaLinha" || parametro.FieldName == "id_nota_fiscal_entrada_linha")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.NotaFiscalEntradaLinhaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.NotaFiscalEntradaLinhaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  historico_compra_material.id_nota_fiscal_entrada_linha IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  historico_compra_material.id_nota_fiscal_entrada_linha = :historico_compra_material_NotaFiscalEntradaLinha_663 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("historico_compra_material_NotaFiscalEntradaLinha_663", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Lote" || parametro.FieldName == "id_lote")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.LoteClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.LoteClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  historico_compra_material.id_lote IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  historico_compra_material.id_lote = :historico_compra_material_Lote_3068 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("historico_compra_material_Lote_3068", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  historico_compra_material.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  historico_compra_material.entity_uid LIKE :historico_compra_material_EntityUid_4627 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("historico_compra_material_EntityUid_4627", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  historico_compra_material.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  historico_compra_material.version = :historico_compra_material_Version_2625 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("historico_compra_material_Version_2625", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroNotaEntradaExato" || parametro.FieldName == "NumeroNotaEntradaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  historico_compra_material.hcm_numero_nota_entrada IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  historico_compra_material.hcm_numero_nota_entrada LIKE :historico_compra_material_NumeroNotaEntrada_4456 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("historico_compra_material_NumeroNotaEntrada_4456", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  historico_compra_material.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  historico_compra_material.entity_uid LIKE :historico_compra_material_EntityUid_9987 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("historico_compra_material_EntityUid_9987", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  HistoricoCompraMaterialClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (HistoricoCompraMaterialClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(HistoricoCompraMaterialClass), Convert.ToInt32(read["id_historico_compra_material"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new HistoricoCompraMaterialClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_historico_compra_material"]);
                     if (read["id_material"] != DBNull.Value)
                     {
                        entidade.Material = (BibliotecaEntidades.Entidades.MaterialClass)BibliotecaEntidades.Entidades.MaterialClass.GetEntidade(Convert.ToInt32(read["id_material"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Material = null ;
                     }
                     if (read["id_fornecedor"] != DBNull.Value)
                     {
                        entidade.Fornecedor = (BibliotecaEntidades.Entidades.FornecedorClass)BibliotecaEntidades.Entidades.FornecedorClass.GetEntidade(Convert.ToInt32(read["id_fornecedor"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Fornecedor = null ;
                     }
                     if (read["id_marca"] != DBNull.Value)
                     {
                        entidade.Marca = (BibliotecaEntidades.Entidades.MarcaClass)BibliotecaEntidades.Entidades.MarcaClass.GetEntidade(Convert.ToInt32(read["id_marca"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Marca = null ;
                     }
                     entidade.NumeroNotaEntrada = (read["hcm_numero_nota_entrada"] != DBNull.Value ? read["hcm_numero_nota_entrada"].ToString() : null);
                     entidade.DataOc = (DateTime)read["hcm_data_oc"];
                     entidade.DataRecebimento = (DateTime)read["hcm_data_recebimento"];
                     entidade.PrecoUnitario = (double)read["hcm_preco_unitario"];
                     entidade.IcmIncluso = (double)read["hcm_icm_incluso"];
                     entidade.IpiNaoIncluso = (double)read["hcm_ipi_nao_incluso"];
                     if (read["id_nota_fiscal_entrada_linha"] != DBNull.Value)
                     {
                        entidade.NotaFiscalEntradaLinha = (BibliotecaEntidades.Entidades.NotaFiscalEntradaLinhaClass)BibliotecaEntidades.Entidades.NotaFiscalEntradaLinhaClass.GetEntidade(Convert.ToInt32(read["id_nota_fiscal_entrada_linha"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.NotaFiscalEntradaLinha = null ;
                     }
                     if (read["id_lote"] != DBNull.Value)
                     {
                        entidade.Lote = (BibliotecaEntidades.Entidades.LoteClass)BibliotecaEntidades.Entidades.LoteClass.GetEntidade(Convert.ToInt32(read["id_lote"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Lote = null ;
                     }
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (HistoricoCompraMaterialClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
