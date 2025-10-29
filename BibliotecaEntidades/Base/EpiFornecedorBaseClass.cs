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
     [Table("epi_fornecedor","epf")]
     public class EpiFornecedorBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do EpiFornecedorClass";
protected const string ErroDelete = "Erro ao excluir o EpiFornecedorClass  ";
protected const string ErroSave = "Erro ao salvar o EpiFornecedorClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroEpiObrigatorio = "O campo Epi é obrigatório";
protected const string ErroFornecedorObrigatorio = "O campo Fornecedor é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do EpiFornecedorClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade EpiFornecedorClass está sendo utilizada.";
#endregion
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

       protected bool _ativoOriginal{get;private set;}
       private bool _ativoOriginalCommited{get; set;}
        private bool _valueAtivo;
         [Column("epf_ativo")]
        public virtual bool Ativo
         { 
            get { return this._valueAtivo; } 
            set 
            { 
                if (this._valueAtivo == value)return;
                 this._valueAtivo = value; 
            } 
        } 

       protected double _ultimoPrecoOriginal{get;private set;}
       private double _ultimoPrecoOriginalCommited{get; set;}
        private double _valueUltimoPreco;
         [Column("epf_ultimo_preco")]
        public virtual double UltimoPreco
         { 
            get { return this._valueUltimoPreco; } 
            set 
            { 
                if (this._valueUltimoPreco == value)return;
                 this._valueUltimoPreco = value; 
            } 
        } 

       protected double _ipiOriginal{get;private set;}
       private double _ipiOriginalCommited{get; set;}
        private double _valueIpi;
         [Column("epf_ipi")]
        public virtual double Ipi
         { 
            get { return this._valueIpi; } 
            set 
            { 
                if (this._valueIpi == value)return;
                 this._valueIpi = value; 
            } 
        } 

       protected double _icmsOriginal{get;private set;}
       private double _icmsOriginalCommited{get; set;}
        private double _valueIcms;
         [Column("epf_icms")]
        public virtual double Icms
         { 
            get { return this._valueIcms; } 
            set 
            { 
                if (this._valueIcms == value)return;
                 this._valueIcms = value; 
            } 
        } 

       protected DateTime? _dataUltimaCompraOriginal{get;private set;}
       private DateTime? _dataUltimaCompraOriginalCommited{get; set;}
        private DateTime? _valueDataUltimaCompra;
         [Column("epf_data_ultima_compra")]
        public virtual DateTime? DataUltimaCompra
         { 
            get { return this._valueDataUltimaCompra; } 
            set 
            { 
                if (this._valueDataUltimaCompra == value)return;
                 this._valueDataUltimaCompra = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.UnidadeMedidaClass _unidadeMedidaCompraOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.UnidadeMedidaClass _unidadeMedidaCompraOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.UnidadeMedidaClass _valueUnidadeMedidaCompra;
        [Column("id_unidade_medida_compra", "unidade_medida", "id_unidade_medida")]
       public virtual BibliotecaEntidades.Entidades.UnidadeMedidaClass UnidadeMedidaCompra
        { 
           get {                 return this._valueUnidadeMedidaCompra; } 
           set 
           { 
                if (this._valueUnidadeMedidaCompra == value)return;
                 this._valueUnidadeMedidaCompra = value; 
           } 
       } 

       protected double? _unidadesPorUnCompraOriginal{get;private set;}
       private double? _unidadesPorUnCompraOriginalCommited{get; set;}
        private double? _valueUnidadesPorUnCompra;
         [Column("epf_unidades_por_un_compra")]
        public virtual double? UnidadesPorUnCompra
         { 
            get { return this._valueUnidadesPorUnCompra; } 
            set 
            { 
                if (this._valueUnidadesPorUnCompra == value)return;
                 this._valueUnidadesPorUnCompra = value; 
            } 
        } 

       protected double? _lotePadraoOriginal{get;private set;}
       private double? _lotePadraoOriginalCommited{get; set;}
        private double? _valueLotePadrao;
         [Column("epf_lote_padrao")]
        public virtual double? LotePadrao
         { 
            get { return this._valueLotePadrao; } 
            set 
            { 
                if (this._valueLotePadrao == value)return;
                 this._valueLotePadrao = value; 
            } 
        } 

       protected double? _loteMinimoOriginal{get;private set;}
       private double? _loteMinimoOriginalCommited{get; set;}
        private double? _valueLoteMinimo;
         [Column("epf_lote_minimo")]
        public virtual double? LoteMinimo
         { 
            get { return this._valueLoteMinimo; } 
            set 
            { 
                if (this._valueLoteMinimo == value)return;
                 this._valueLoteMinimo = value; 
            } 
        } 

       protected bool _preferencialOriginal{get;private set;}
       private bool _preferencialOriginalCommited{get; set;}
        private bool _valuePreferencial;
         [Column("epf_preferencial")]
        public virtual bool Preferencial
         { 
            get { return this._valuePreferencial; } 
            set 
            { 
                if (this._valuePreferencial == value)return;
                 this._valuePreferencial = value; 
            } 
        } 

        public EpiFornecedorBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Ativo = true;
           this.UltimoPreco = 0;
           this.Ipi = 0;
           this.Icms = 0;
           this.Preferencial = false;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static EpiFornecedorClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (EpiFornecedorClass) GetEntity(typeof(EpiFornecedorClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if ( _valueEpi == null)
                {
                    throw new Exception(ErroEpiObrigatorio);
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
                    "  public.epi_fornecedor  " +
                    "WHERE " +
                    "  id_epi_fornecedor = :id";
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
                        "  public.epi_fornecedor   " +
                        "SET  " + 
                        "  id_epi = :id_epi, " + 
                        "  id_fornecedor = :id_fornecedor, " + 
                        "  epf_ativo = :epf_ativo, " + 
                        "  epf_ultimo_preco = :epf_ultimo_preco, " + 
                        "  epf_ipi = :epf_ipi, " + 
                        "  epf_icms = :epf_icms, " + 
                        "  epf_data_ultima_compra = :epf_data_ultima_compra, " + 
                        "  id_unidade_medida_compra = :id_unidade_medida_compra, " + 
                        "  epf_unidades_por_un_compra = :epf_unidades_por_un_compra, " + 
                        "  epf_lote_padrao = :epf_lote_padrao, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  epf_lote_minimo = :epf_lote_minimo, " + 
                        "  epf_preferencial = :epf_preferencial "+
                        "WHERE  " +
                        "  id_epi_fornecedor = :id " +
                        "RETURNING id_epi_fornecedor;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.epi_fornecedor " +
                        "( " +
                        "  id_epi , " + 
                        "  id_fornecedor , " + 
                        "  epf_ativo , " + 
                        "  epf_ultimo_preco , " + 
                        "  epf_ipi , " + 
                        "  epf_icms , " + 
                        "  epf_data_ultima_compra , " + 
                        "  id_unidade_medida_compra , " + 
                        "  epf_unidades_por_un_compra , " + 
                        "  epf_lote_padrao , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  epf_lote_minimo , " + 
                        "  epf_preferencial  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_epi , " + 
                        "  :id_fornecedor , " + 
                        "  :epf_ativo , " + 
                        "  :epf_ultimo_preco , " + 
                        "  :epf_ipi , " + 
                        "  :epf_icms , " + 
                        "  :epf_data_ultima_compra , " + 
                        "  :id_unidade_medida_compra , " + 
                        "  :epf_unidades_por_un_compra , " + 
                        "  :epf_lote_padrao , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :epf_lote_minimo , " + 
                        "  :epf_preferencial  "+
                        ")RETURNING id_epi_fornecedor;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_epi", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Epi==null ? (object) DBNull.Value : this.Epi.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_fornecedor", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Fornecedor==null ? (object) DBNull.Value : this.Fornecedor.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epf_ativo", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Ativo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epf_ultimo_preco", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UltimoPreco ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epf_ipi", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Ipi ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epf_icms", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Icms ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epf_data_ultima_compra", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataUltimaCompra ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_unidade_medida_compra", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.UnidadeMedidaCompra==null ? (object) DBNull.Value : this.UnidadeMedidaCompra.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epf_unidades_por_un_compra", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UnidadesPorUnCompra ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epf_lote_padrao", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.LotePadrao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epf_lote_minimo", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.LoteMinimo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epf_preferencial", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Preferencial ?? DBNull.Value;

 
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
        public static EpiFornecedorClass CopiarEntidade(EpiFornecedorClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               EpiFornecedorClass toRet = new EpiFornecedorClass(usuario,conn);
 toRet.Epi= entidadeCopiar.Epi;
 toRet.Fornecedor= entidadeCopiar.Fornecedor;
 toRet.Ativo= entidadeCopiar.Ativo;
 toRet.UltimoPreco= entidadeCopiar.UltimoPreco;
 toRet.Ipi= entidadeCopiar.Ipi;
 toRet.Icms= entidadeCopiar.Icms;
 toRet.DataUltimaCompra= entidadeCopiar.DataUltimaCompra;
 toRet.UnidadeMedidaCompra= entidadeCopiar.UnidadeMedidaCompra;
 toRet.UnidadesPorUnCompra= entidadeCopiar.UnidadesPorUnCompra;
 toRet.LotePadrao= entidadeCopiar.LotePadrao;
 toRet.LoteMinimo= entidadeCopiar.LoteMinimo;
 toRet.Preferencial= entidadeCopiar.Preferencial;

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
       _epiOriginal = Epi;
       _epiOriginalCommited = _epiOriginal;
       _fornecedorOriginal = Fornecedor;
       _fornecedorOriginalCommited = _fornecedorOriginal;
       _ativoOriginal = Ativo;
       _ativoOriginalCommited = _ativoOriginal;
       _ultimoPrecoOriginal = UltimoPreco;
       _ultimoPrecoOriginalCommited = _ultimoPrecoOriginal;
       _ipiOriginal = Ipi;
       _ipiOriginalCommited = _ipiOriginal;
       _icmsOriginal = Icms;
       _icmsOriginalCommited = _icmsOriginal;
       _dataUltimaCompraOriginal = DataUltimaCompra;
       _dataUltimaCompraOriginalCommited = _dataUltimaCompraOriginal;
       _unidadeMedidaCompraOriginal = UnidadeMedidaCompra;
       _unidadeMedidaCompraOriginalCommited = _unidadeMedidaCompraOriginal;
       _unidadesPorUnCompraOriginal = UnidadesPorUnCompra;
       _unidadesPorUnCompraOriginalCommited = _unidadesPorUnCompraOriginal;
       _lotePadraoOriginal = LotePadrao;
       _lotePadraoOriginalCommited = _lotePadraoOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _loteMinimoOriginal = LoteMinimo;
       _loteMinimoOriginalCommited = _loteMinimoOriginal;
       _preferencialOriginal = Preferencial;
       _preferencialOriginalCommited = _preferencialOriginal;

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
       _epiOriginalCommited = Epi;
       _fornecedorOriginalCommited = Fornecedor;
       _ativoOriginalCommited = Ativo;
       _ultimoPrecoOriginalCommited = UltimoPreco;
       _ipiOriginalCommited = Ipi;
       _icmsOriginalCommited = Icms;
       _dataUltimaCompraOriginalCommited = DataUltimaCompra;
       _unidadeMedidaCompraOriginalCommited = UnidadeMedidaCompra;
       _unidadesPorUnCompraOriginalCommited = UnidadesPorUnCompra;
       _lotePadraoOriginalCommited = LotePadrao;
       _versionOriginalCommited = Version;
       _loteMinimoOriginalCommited = LoteMinimo;
       _preferencialOriginalCommited = Preferencial;

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
               Epi=_epiOriginal;
               _epiOriginalCommited=_epiOriginal;
               Fornecedor=_fornecedorOriginal;
               _fornecedorOriginalCommited=_fornecedorOriginal;
               Ativo=_ativoOriginal;
               _ativoOriginalCommited=_ativoOriginal;
               UltimoPreco=_ultimoPrecoOriginal;
               _ultimoPrecoOriginalCommited=_ultimoPrecoOriginal;
               Ipi=_ipiOriginal;
               _ipiOriginalCommited=_ipiOriginal;
               Icms=_icmsOriginal;
               _icmsOriginalCommited=_icmsOriginal;
               DataUltimaCompra=_dataUltimaCompraOriginal;
               _dataUltimaCompraOriginalCommited=_dataUltimaCompraOriginal;
               UnidadeMedidaCompra=_unidadeMedidaCompraOriginal;
               _unidadeMedidaCompraOriginalCommited=_unidadeMedidaCompraOriginal;
               UnidadesPorUnCompra=_unidadesPorUnCompraOriginal;
               _unidadesPorUnCompraOriginalCommited=_unidadesPorUnCompraOriginal;
               LotePadrao=_lotePadraoOriginal;
               _lotePadraoOriginalCommited=_lotePadraoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               LoteMinimo=_loteMinimoOriginal;
               _loteMinimoOriginalCommited=_loteMinimoOriginal;
               Preferencial=_preferencialOriginal;
               _preferencialOriginalCommited=_preferencialOriginal;

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
       if (_epiOriginal!=null)
       {
          dirty = !_epiOriginal.Equals(Epi);
       }
       else
       {
            dirty = Epi != null;
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
       dirty = _ativoOriginal != Ativo;
      if (dirty) return true;
       dirty = _ultimoPrecoOriginal != UltimoPreco;
      if (dirty) return true;
       dirty = _ipiOriginal != Ipi;
      if (dirty) return true;
       dirty = _icmsOriginal != Icms;
      if (dirty) return true;
       dirty = _dataUltimaCompraOriginal != DataUltimaCompra;
      if (dirty) return true;
       if (_unidadeMedidaCompraOriginal!=null)
       {
          dirty = !_unidadeMedidaCompraOriginal.Equals(UnidadeMedidaCompra);
       }
       else
       {
            dirty = UnidadeMedidaCompra != null;
       }
      if (dirty) return true;
       dirty = _unidadesPorUnCompraOriginal != UnidadesPorUnCompra;
      if (dirty) return true;
       dirty = _lotePadraoOriginal != LotePadrao;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _loteMinimoOriginal != LoteMinimo;
      if (dirty) return true;
       dirty = _preferencialOriginal != Preferencial;

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
       if (_epiOriginalCommited!=null)
       {
          dirty = !_epiOriginalCommited.Equals(Epi);
       }
       else
       {
            dirty = Epi != null;
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
       dirty = _ativoOriginalCommited != Ativo;
      if (dirty) return true;
       dirty = _ultimoPrecoOriginalCommited != UltimoPreco;
      if (dirty) return true;
       dirty = _ipiOriginalCommited != Ipi;
      if (dirty) return true;
       dirty = _icmsOriginalCommited != Icms;
      if (dirty) return true;
       dirty = _dataUltimaCompraOriginalCommited != DataUltimaCompra;
      if (dirty) return true;
       if (_unidadeMedidaCompraOriginalCommited!=null)
       {
          dirty = !_unidadeMedidaCompraOriginalCommited.Equals(UnidadeMedidaCompra);
       }
       else
       {
            dirty = UnidadeMedidaCompra != null;
       }
      if (dirty) return true;
       dirty = _unidadesPorUnCompraOriginalCommited != UnidadesPorUnCompra;
      if (dirty) return true;
       dirty = _lotePadraoOriginalCommited != LotePadrao;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _loteMinimoOriginalCommited != LoteMinimo;
      if (dirty) return true;
       dirty = _preferencialOriginalCommited != Preferencial;

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
             case "Epi":
                return this.Epi;
             case "Fornecedor":
                return this.Fornecedor;
             case "Ativo":
                return this.Ativo;
             case "UltimoPreco":
                return this.UltimoPreco;
             case "Ipi":
                return this.Ipi;
             case "Icms":
                return this.Icms;
             case "DataUltimaCompra":
                return this.DataUltimaCompra;
             case "UnidadeMedidaCompra":
                return this.UnidadeMedidaCompra;
             case "UnidadesPorUnCompra":
                return this.UnidadesPorUnCompra;
             case "LotePadrao":
                return this.LotePadrao;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "LoteMinimo":
                return this.LoteMinimo;
             case "Preferencial":
                return this.Preferencial;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (Epi!=null)
                Epi.ChangeSingleConnection(newConnection);
             if (Fornecedor!=null)
                Fornecedor.ChangeSingleConnection(newConnection);
             if (UnidadeMedidaCompra!=null)
                UnidadeMedidaCompra.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(epi_fornecedor.id_epi_fornecedor) " ;
               }
               else
               {
               command.CommandText += "epi_fornecedor.id_epi_fornecedor, " ;
               command.CommandText += "epi_fornecedor.id_epi, " ;
               command.CommandText += "epi_fornecedor.id_fornecedor, " ;
               command.CommandText += "epi_fornecedor.epf_ativo, " ;
               command.CommandText += "epi_fornecedor.epf_ultimo_preco, " ;
               command.CommandText += "epi_fornecedor.epf_ipi, " ;
               command.CommandText += "epi_fornecedor.epf_icms, " ;
               command.CommandText += "epi_fornecedor.epf_data_ultima_compra, " ;
               command.CommandText += "epi_fornecedor.id_unidade_medida_compra, " ;
               command.CommandText += "epi_fornecedor.epf_unidades_por_un_compra, " ;
               command.CommandText += "epi_fornecedor.epf_lote_padrao, " ;
               command.CommandText += "epi_fornecedor.entity_uid, " ;
               command.CommandText += "epi_fornecedor.version, " ;
               command.CommandText += "epi_fornecedor.epf_lote_minimo, " ;
               command.CommandText += "epi_fornecedor.epf_preferencial " ;
               }
               command.CommandText += " FROM  epi_fornecedor ";
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
                        orderByClause += " , epf_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(epf_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = epi_fornecedor.id_acs_usuario_ultima_revisao ";
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
                     case "id_epi_fornecedor":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , epi_fornecedor.id_epi_fornecedor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(epi_fornecedor.id_epi_fornecedor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_epi":
                     case "Epi":
                     command.CommandText += " LEFT JOIN epi as epi_Epi ON epi_Epi.id_epi = epi_fornecedor.id_epi ";                     switch (parametro.TipoOrdenacao)
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
                     case "id_fornecedor":
                     case "Fornecedor":
                     command.CommandText += " LEFT JOIN fornecedor as fornecedor_Fornecedor ON fornecedor_Fornecedor.id_fornecedor = epi_fornecedor.id_fornecedor ";                     switch (parametro.TipoOrdenacao)
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
                     case "epf_ativo":
                     case "Ativo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , epi_fornecedor.epf_ativo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(epi_fornecedor.epf_ativo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "epf_ultimo_preco":
                     case "UltimoPreco":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , epi_fornecedor.epf_ultimo_preco " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(epi_fornecedor.epf_ultimo_preco) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "epf_ipi":
                     case "Ipi":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , epi_fornecedor.epf_ipi " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(epi_fornecedor.epf_ipi) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "epf_icms":
                     case "Icms":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , epi_fornecedor.epf_icms " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(epi_fornecedor.epf_icms) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "epf_data_ultima_compra":
                     case "DataUltimaCompra":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , epi_fornecedor.epf_data_ultima_compra " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(epi_fornecedor.epf_data_ultima_compra) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_unidade_medida_compra":
                     case "UnidadeMedidaCompra":
                     command.CommandText += " LEFT JOIN unidade_medida as unidade_medida_UnidadeMedidaCompra ON unidade_medida_UnidadeMedidaCompra.id_unidade_medida = epi_fornecedor.id_unidade_medida_compra ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , unidade_medida_UnidadeMedidaCompra.unm_abreviada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(unidade_medida_UnidadeMedidaCompra.unm_abreviada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "epf_unidades_por_un_compra":
                     case "UnidadesPorUnCompra":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , epi_fornecedor.epf_unidades_por_un_compra " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(epi_fornecedor.epf_unidades_por_un_compra) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "epf_lote_padrao":
                     case "LotePadrao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , epi_fornecedor.epf_lote_padrao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(epi_fornecedor.epf_lote_padrao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , epi_fornecedor.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(epi_fornecedor.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , epi_fornecedor.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(epi_fornecedor.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "epf_lote_minimo":
                     case "LoteMinimo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , epi_fornecedor.epf_lote_minimo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(epi_fornecedor.epf_lote_minimo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "epf_preferencial":
                     case "Preferencial":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , epi_fornecedor.epf_preferencial " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(epi_fornecedor.epf_preferencial) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           whereClause += " OR UPPER(epi_fornecedor.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(epi_fornecedor.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_epi_fornecedor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi_fornecedor.id_epi_fornecedor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi_fornecedor.id_epi_fornecedor = :epi_fornecedor_ID_7108 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_fornecedor_ID_7108", NpgsqlDbType.Bigint, parametro.Fieldvalue));
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
                         whereClause += "  epi_fornecedor.id_epi IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi_fornecedor.id_epi = :epi_fornecedor_Epi_7105 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_fornecedor_Epi_7105", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  epi_fornecedor.id_fornecedor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi_fornecedor.id_fornecedor = :epi_fornecedor_Fornecedor_7931 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_fornecedor_Fornecedor_7931", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Ativo" || parametro.FieldName == "epf_ativo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi_fornecedor.epf_ativo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi_fornecedor.epf_ativo = :epi_fornecedor_Ativo_6468 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_fornecedor_Ativo_6468", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimoPreco" || parametro.FieldName == "epf_ultimo_preco")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi_fornecedor.epf_ultimo_preco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi_fornecedor.epf_ultimo_preco = :epi_fornecedor_UltimoPreco_3891 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_fornecedor_UltimoPreco_3891", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Ipi" || parametro.FieldName == "epf_ipi")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi_fornecedor.epf_ipi IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi_fornecedor.epf_ipi = :epi_fornecedor_Ipi_5825 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_fornecedor_Ipi_5825", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Icms" || parametro.FieldName == "epf_icms")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi_fornecedor.epf_icms IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi_fornecedor.epf_icms = :epi_fornecedor_Icms_852 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_fornecedor_Icms_852", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataUltimaCompra" || parametro.FieldName == "epf_data_ultima_compra")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi_fornecedor.epf_data_ultima_compra IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi_fornecedor.epf_data_ultima_compra = :epi_fornecedor_DataUltimaCompra_1281 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_fornecedor_DataUltimaCompra_1281", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UnidadeMedidaCompra" || parametro.FieldName == "id_unidade_medida_compra")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.UnidadeMedidaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.UnidadeMedidaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi_fornecedor.id_unidade_medida_compra IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi_fornecedor.id_unidade_medida_compra = :epi_fornecedor_UnidadeMedidaCompra_2968 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_fornecedor_UnidadeMedidaCompra_2968", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UnidadesPorUnCompra" || parametro.FieldName == "epf_unidades_por_un_compra")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi_fornecedor.epf_unidades_por_un_compra IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi_fornecedor.epf_unidades_por_un_compra = :epi_fornecedor_UnidadesPorUnCompra_9817 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_fornecedor_UnidadesPorUnCompra_9817", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "LotePadrao" || parametro.FieldName == "epf_lote_padrao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi_fornecedor.epf_lote_padrao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi_fornecedor.epf_lote_padrao = :epi_fornecedor_LotePadrao_4057 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_fornecedor_LotePadrao_4057", NpgsqlDbType.Double, parametro.Fieldvalue));
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
                         whereClause += "  epi_fornecedor.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi_fornecedor.entity_uid LIKE :epi_fornecedor_EntityUid_8009 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_fornecedor_EntityUid_8009", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  epi_fornecedor.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi_fornecedor.version = :epi_fornecedor_Version_7693 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_fornecedor_Version_7693", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "LoteMinimo" || parametro.FieldName == "epf_lote_minimo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi_fornecedor.epf_lote_minimo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi_fornecedor.epf_lote_minimo = :epi_fornecedor_LoteMinimo_8473 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_fornecedor_LoteMinimo_8473", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Preferencial" || parametro.FieldName == "epf_preferencial")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  epi_fornecedor.epf_preferencial IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi_fornecedor.epf_preferencial = :epi_fornecedor_Preferencial_2782 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_fornecedor_Preferencial_2782", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
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
                         whereClause += "  epi_fornecedor.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  epi_fornecedor.entity_uid LIKE :epi_fornecedor_EntityUid_527 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("epi_fornecedor_EntityUid_527", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  EpiFornecedorClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (EpiFornecedorClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(EpiFornecedorClass), Convert.ToInt32(read["id_epi_fornecedor"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new EpiFornecedorClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_epi_fornecedor"]);
                     if (read["id_epi"] != DBNull.Value)
                     {
                        entidade.Epi = (BibliotecaEntidades.Entidades.EpiClass)BibliotecaEntidades.Entidades.EpiClass.GetEntidade(Convert.ToInt32(read["id_epi"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Epi = null ;
                     }
                     if (read["id_fornecedor"] != DBNull.Value)
                     {
                        entidade.Fornecedor = (BibliotecaEntidades.Entidades.FornecedorClass)BibliotecaEntidades.Entidades.FornecedorClass.GetEntidade(Convert.ToInt32(read["id_fornecedor"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Fornecedor = null ;
                     }
                     entidade.Ativo = Convert.ToBoolean(Convert.ToInt16(read["epf_ativo"]));
                     entidade.UltimoPreco = (double)read["epf_ultimo_preco"];
                     entidade.Ipi = (double)read["epf_ipi"];
                     entidade.Icms = (double)read["epf_icms"];
                     entidade.DataUltimaCompra = read["epf_data_ultima_compra"] as DateTime?;
                     if (read["id_unidade_medida_compra"] != DBNull.Value)
                     {
                        entidade.UnidadeMedidaCompra = (BibliotecaEntidades.Entidades.UnidadeMedidaClass)BibliotecaEntidades.Entidades.UnidadeMedidaClass.GetEntidade(Convert.ToInt32(read["id_unidade_medida_compra"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.UnidadeMedidaCompra = null ;
                     }
                     entidade.UnidadesPorUnCompra = read["epf_unidades_por_un_compra"] as double?;
                     entidade.LotePadrao = read["epf_lote_padrao"] as double?;
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.LoteMinimo = read["epf_lote_minimo"] as double?;
                     entidade.Preferencial = Convert.ToBoolean(Convert.ToInt16(read["epf_preferencial"]));
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (EpiFornecedorClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
