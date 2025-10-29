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
     [Table("fomulario_retirada_manual_estoque","fre")]
     public class FomularioRetiradaManualEstoqueBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do FomularioRetiradaManualEstoqueClass";
protected const string ErroDelete = "Erro ao excluir o FomularioRetiradaManualEstoqueClass  ";
protected const string ErroSave = "Erro ao salvar o FomularioRetiradaManualEstoqueClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroAcsUsuarioAberturaObrigatorio = "O campo AcsUsuarioAbertura é obrigatório";
protected const string ErroEstoqueGavetaObrigatorio = "O campo EstoqueGaveta é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do FomularioRetiradaManualEstoqueClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade FomularioRetiradaManualEstoqueClass está sendo utilizada.";
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

       protected IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioAberturaOriginal{get;private set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioAberturaOriginalCommited {get; set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _valueAcsUsuarioAbertura;
        [Column("id_acs_usuario_abertura", "acs_usuario", "id_acs_usuario")]
       public virtual IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass AcsUsuarioAbertura
        { 
           get {                 return this._valueAcsUsuarioAbertura; } 
           set 
           { 
                if (this._valueAcsUsuarioAbertura == value)return;
                 this._valueAcsUsuarioAbertura = value; 
           } 
       } 

       protected DateTime _dataAberturaOriginal{get;private set;}
       private DateTime _dataAberturaOriginalCommited{get; set;}
        private DateTime _valueDataAbertura;
         [Column("fre_data_abertura")]
        public virtual DateTime DataAbertura
         { 
            get { return this._valueDataAbertura; } 
            set 
            { 
                if (this._valueDataAbertura == value)return;
                 this._valueDataAbertura = value; 
            } 
        } 

       protected double _quantidadeOriginal{get;private set;}
       private double _quantidadeOriginalCommited{get; set;}
        private double _valueQuantidade;
         [Column("fre_quantidade")]
        public virtual double Quantidade
         { 
            get { return this._valueQuantidade; } 
            set 
            { 
                if (this._valueQuantidade == value)return;
                 this._valueQuantidade = value; 
            } 
        } 

       protected IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioRetiradaOriginal{get;private set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioRetiradaOriginalCommited {get; set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _valueAcsUsuarioRetirada;
        [Column("id_acs_usuario_retirada", "acs_usuario", "id_acs_usuario")]
       public virtual IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass AcsUsuarioRetirada
        { 
           get {                 return this._valueAcsUsuarioRetirada; } 
           set 
           { 
                if (this._valueAcsUsuarioRetirada == value)return;
                 this._valueAcsUsuarioRetirada = value; 
           } 
       } 

       protected DateTime? _dataRetiradaOriginal{get;private set;}
       private DateTime? _dataRetiradaOriginalCommited{get; set;}
        private DateTime? _valueDataRetirada;
         [Column("fre_data_retirada")]
        public virtual DateTime? DataRetirada
         { 
            get { return this._valueDataRetirada; } 
            set 
            { 
                if (this._valueDataRetirada == value)return;
                 this._valueDataRetirada = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.EstoqueGavetaClass _estoqueGavetaOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.EstoqueGavetaClass _estoqueGavetaOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.EstoqueGavetaClass _valueEstoqueGaveta;
        [Column("id_estoque_gaveta", "estoque_gaveta", "id_estoque_gaveta")]
       public virtual BibliotecaEntidades.Entidades.EstoqueGavetaClass EstoqueGaveta
        { 
           get {                 return this._valueEstoqueGaveta; } 
           set 
           { 
                if (this._valueEstoqueGaveta == value)return;
                 this._valueEstoqueGaveta = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.EstoqueGavetaClass _estoqueGavetaDestinoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.EstoqueGavetaClass _estoqueGavetaDestinoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.EstoqueGavetaClass _valueEstoqueGavetaDestino;
        [Column("id_estoque_gaveta_destino", "estoque_gaveta", "id_estoque_gaveta")]
       public virtual BibliotecaEntidades.Entidades.EstoqueGavetaClass EstoqueGavetaDestino
        { 
           get {                 return this._valueEstoqueGavetaDestino; } 
           set 
           { 
                if (this._valueEstoqueGavetaDestino == value)return;
                 this._valueEstoqueGavetaDestino = value; 
           } 
       } 

       protected string _observacaoOriginal{get;private set;}
       private string _observacaoOriginalCommited{get; set;}
        private string _valueObservacao;
         [Column("fre_observacao")]
        public virtual string Observacao
         { 
            get { return this._valueObservacao; } 
            set 
            { 
                if (this._valueObservacao == value)return;
                 this._valueObservacao = value; 
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

        public FomularioRetiradaManualEstoqueBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static FomularioRetiradaManualEstoqueClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (FomularioRetiradaManualEstoqueClass) GetEntity(typeof(FomularioRetiradaManualEstoqueClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if ( _valueAcsUsuarioAbertura == null)
                {
                    throw new Exception(ErroAcsUsuarioAberturaObrigatorio);
                }
                if ( _valueEstoqueGaveta == null)
                {
                    throw new Exception(ErroEstoqueGavetaObrigatorio);
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
                    "  public.fomulario_retirada_manual_estoque  " +
                    "WHERE " +
                    "  id_fomulario_retirada_manual_estoque = :id";
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
                        "  public.fomulario_retirada_manual_estoque   " +
                        "SET  " + 
                        "  id_produto = :id_produto, " + 
                        "  id_material = :id_material, " + 
                        "  id_acs_usuario_abertura = :id_acs_usuario_abertura, " + 
                        "  fre_data_abertura = :fre_data_abertura, " + 
                        "  fre_quantidade = :fre_quantidade, " + 
                        "  id_acs_usuario_retirada = :id_acs_usuario_retirada, " + 
                        "  fre_data_retirada = :fre_data_retirada, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  id_estoque_gaveta = :id_estoque_gaveta, " + 
                        "  id_estoque_gaveta_destino = :id_estoque_gaveta_destino, " + 
                        "  fre_observacao = :fre_observacao, " + 
                        "  id_epi = :id_epi "+
                        "WHERE  " +
                        "  id_fomulario_retirada_manual_estoque = :id " +
                        "RETURNING id_fomulario_retirada_manual_estoque;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.fomulario_retirada_manual_estoque " +
                        "( " +
                        "  id_produto , " + 
                        "  id_material , " + 
                        "  id_acs_usuario_abertura , " + 
                        "  fre_data_abertura , " + 
                        "  fre_quantidade , " + 
                        "  id_acs_usuario_retirada , " + 
                        "  fre_data_retirada , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  id_estoque_gaveta , " + 
                        "  id_estoque_gaveta_destino , " + 
                        "  fre_observacao , " + 
                        "  id_epi  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_produto , " + 
                        "  :id_material , " + 
                        "  :id_acs_usuario_abertura , " + 
                        "  :fre_data_abertura , " + 
                        "  :fre_quantidade , " + 
                        "  :id_acs_usuario_retirada , " + 
                        "  :fre_data_retirada , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :id_estoque_gaveta , " + 
                        "  :id_estoque_gaveta_destino , " + 
                        "  :fre_observacao , " + 
                        "  :id_epi  "+
                        ")RETURNING id_fomulario_retirada_manual_estoque;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Produto==null ? (object) DBNull.Value : this.Produto.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_material", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Material==null ? (object) DBNull.Value : this.Material.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_abertura", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuarioAbertura==null ? (object) DBNull.Value : this.AcsUsuarioAbertura.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fre_data_abertura", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataAbertura ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fre_quantidade", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Quantidade ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_retirada", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuarioRetirada==null ? (object) DBNull.Value : this.AcsUsuarioRetirada.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fre_data_retirada", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataRetirada ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_estoque_gaveta", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.EstoqueGaveta==null ? (object) DBNull.Value : this.EstoqueGaveta.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_estoque_gaveta_destino", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.EstoqueGavetaDestino==null ? (object) DBNull.Value : this.EstoqueGavetaDestino.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fre_observacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Observacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_epi", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Epi==null ? (object) DBNull.Value : this.Epi.ID;

 
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
        public static FomularioRetiradaManualEstoqueClass CopiarEntidade(FomularioRetiradaManualEstoqueClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               FomularioRetiradaManualEstoqueClass toRet = new FomularioRetiradaManualEstoqueClass(usuario,conn);
 toRet.Produto= entidadeCopiar.Produto;
 toRet.Material= entidadeCopiar.Material;
 toRet.AcsUsuarioAbertura= entidadeCopiar.AcsUsuarioAbertura;
 toRet.DataAbertura= entidadeCopiar.DataAbertura;
 toRet.Quantidade= entidadeCopiar.Quantidade;
 toRet.AcsUsuarioRetirada= entidadeCopiar.AcsUsuarioRetirada;
 toRet.DataRetirada= entidadeCopiar.DataRetirada;
 toRet.EstoqueGaveta= entidadeCopiar.EstoqueGaveta;
 toRet.EstoqueGavetaDestino= entidadeCopiar.EstoqueGavetaDestino;
 toRet.Observacao= entidadeCopiar.Observacao;
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
       _acsUsuarioAberturaOriginal = AcsUsuarioAbertura;
       _acsUsuarioAberturaOriginalCommited = _acsUsuarioAberturaOriginal;
       _dataAberturaOriginal = DataAbertura;
       _dataAberturaOriginalCommited = _dataAberturaOriginal;
       _quantidadeOriginal = Quantidade;
       _quantidadeOriginalCommited = _quantidadeOriginal;
       _acsUsuarioRetiradaOriginal = AcsUsuarioRetirada;
       _acsUsuarioRetiradaOriginalCommited = _acsUsuarioRetiradaOriginal;
       _dataRetiradaOriginal = DataRetirada;
       _dataRetiradaOriginalCommited = _dataRetiradaOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _estoqueGavetaOriginal = EstoqueGaveta;
       _estoqueGavetaOriginalCommited = _estoqueGavetaOriginal;
       _estoqueGavetaDestinoOriginal = EstoqueGavetaDestino;
       _estoqueGavetaDestinoOriginalCommited = _estoqueGavetaDestinoOriginal;
       _observacaoOriginal = Observacao;
       _observacaoOriginalCommited = _observacaoOriginal;
       _epiOriginal = Epi;
       _epiOriginalCommited = _epiOriginal;

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
       _acsUsuarioAberturaOriginalCommited = AcsUsuarioAbertura;
       _dataAberturaOriginalCommited = DataAbertura;
       _quantidadeOriginalCommited = Quantidade;
       _acsUsuarioRetiradaOriginalCommited = AcsUsuarioRetirada;
       _dataRetiradaOriginalCommited = DataRetirada;
       _versionOriginalCommited = Version;
       _estoqueGavetaOriginalCommited = EstoqueGaveta;
       _estoqueGavetaDestinoOriginalCommited = EstoqueGavetaDestino;
       _observacaoOriginalCommited = Observacao;
       _epiOriginalCommited = Epi;

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
               AcsUsuarioAbertura=_acsUsuarioAberturaOriginal;
               _acsUsuarioAberturaOriginalCommited=_acsUsuarioAberturaOriginal;
               DataAbertura=_dataAberturaOriginal;
               _dataAberturaOriginalCommited=_dataAberturaOriginal;
               Quantidade=_quantidadeOriginal;
               _quantidadeOriginalCommited=_quantidadeOriginal;
               AcsUsuarioRetirada=_acsUsuarioRetiradaOriginal;
               _acsUsuarioRetiradaOriginalCommited=_acsUsuarioRetiradaOriginal;
               DataRetirada=_dataRetiradaOriginal;
               _dataRetiradaOriginalCommited=_dataRetiradaOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               EstoqueGaveta=_estoqueGavetaOriginal;
               _estoqueGavetaOriginalCommited=_estoqueGavetaOriginal;
               EstoqueGavetaDestino=_estoqueGavetaDestinoOriginal;
               _estoqueGavetaDestinoOriginalCommited=_estoqueGavetaDestinoOriginal;
               Observacao=_observacaoOriginal;
               _observacaoOriginalCommited=_observacaoOriginal;
               Epi=_epiOriginal;
               _epiOriginalCommited=_epiOriginal;

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
       if (_acsUsuarioAberturaOriginal!=null)
       {
          dirty = !_acsUsuarioAberturaOriginal.Equals(AcsUsuarioAbertura);
       }
       else
       {
            dirty = AcsUsuarioAbertura != null;
       }
      if (dirty) return true;
       dirty = _dataAberturaOriginal != DataAbertura;
      if (dirty) return true;
       dirty = _quantidadeOriginal != Quantidade;
      if (dirty) return true;
       if (_acsUsuarioRetiradaOriginal!=null)
       {
          dirty = !_acsUsuarioRetiradaOriginal.Equals(AcsUsuarioRetirada);
       }
       else
       {
            dirty = AcsUsuarioRetirada != null;
       }
      if (dirty) return true;
       dirty = _dataRetiradaOriginal != DataRetirada;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       if (_estoqueGavetaOriginal!=null)
       {
          dirty = !_estoqueGavetaOriginal.Equals(EstoqueGaveta);
       }
       else
       {
            dirty = EstoqueGaveta != null;
       }
      if (dirty) return true;
       if (_estoqueGavetaDestinoOriginal!=null)
       {
          dirty = !_estoqueGavetaDestinoOriginal.Equals(EstoqueGavetaDestino);
       }
       else
       {
            dirty = EstoqueGavetaDestino != null;
       }
      if (dirty) return true;
       dirty = _observacaoOriginal != Observacao;
      if (dirty) return true;
       if (_epiOriginal!=null)
       {
          dirty = !_epiOriginal.Equals(Epi);
       }
       else
       {
            dirty = Epi != null;
       }

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
       if (_acsUsuarioAberturaOriginalCommited!=null)
       {
          dirty = !_acsUsuarioAberturaOriginalCommited.Equals(AcsUsuarioAbertura);
       }
       else
       {
            dirty = AcsUsuarioAbertura != null;
       }
      if (dirty) return true;
       dirty = _dataAberturaOriginalCommited != DataAbertura;
      if (dirty) return true;
       dirty = _quantidadeOriginalCommited != Quantidade;
      if (dirty) return true;
       if (_acsUsuarioRetiradaOriginalCommited!=null)
       {
          dirty = !_acsUsuarioRetiradaOriginalCommited.Equals(AcsUsuarioRetirada);
       }
       else
       {
            dirty = AcsUsuarioRetirada != null;
       }
      if (dirty) return true;
       dirty = _dataRetiradaOriginalCommited != DataRetirada;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       if (_estoqueGavetaOriginalCommited!=null)
       {
          dirty = !_estoqueGavetaOriginalCommited.Equals(EstoqueGaveta);
       }
       else
       {
            dirty = EstoqueGaveta != null;
       }
      if (dirty) return true;
       if (_estoqueGavetaDestinoOriginalCommited!=null)
       {
          dirty = !_estoqueGavetaDestinoOriginalCommited.Equals(EstoqueGavetaDestino);
       }
       else
       {
            dirty = EstoqueGavetaDestino != null;
       }
      if (dirty) return true;
       dirty = _observacaoOriginalCommited != Observacao;
      if (dirty) return true;
       if (_epiOriginalCommited!=null)
       {
          dirty = !_epiOriginalCommited.Equals(Epi);
       }
       else
       {
            dirty = Epi != null;
       }

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
             case "AcsUsuarioAbertura":
                return this.AcsUsuarioAbertura;
             case "DataAbertura":
                return this.DataAbertura;
             case "Quantidade":
                return this.Quantidade;
             case "AcsUsuarioRetirada":
                return this.AcsUsuarioRetirada;
             case "DataRetirada":
                return this.DataRetirada;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "EstoqueGaveta":
                return this.EstoqueGaveta;
             case "EstoqueGavetaDestino":
                return this.EstoqueGavetaDestino;
             case "Observacao":
                return this.Observacao;
             case "Epi":
                return this.Epi;
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
             if (AcsUsuarioAbertura!=null)
                AcsUsuarioAbertura.ChangeSingleConnection(newConnection);
             if (AcsUsuarioRetirada!=null)
                AcsUsuarioRetirada.ChangeSingleConnection(newConnection);
             if (EstoqueGaveta!=null)
                EstoqueGaveta.ChangeSingleConnection(newConnection);
             if (EstoqueGavetaDestino!=null)
                EstoqueGavetaDestino.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(fomulario_retirada_manual_estoque.id_fomulario_retirada_manual_estoque) " ;
               }
               else
               {
               command.CommandText += "fomulario_retirada_manual_estoque.id_fomulario_retirada_manual_estoque, " ;
               command.CommandText += "fomulario_retirada_manual_estoque.id_produto, " ;
               command.CommandText += "fomulario_retirada_manual_estoque.id_material, " ;
               command.CommandText += "fomulario_retirada_manual_estoque.id_acs_usuario_abertura, " ;
               command.CommandText += "fomulario_retirada_manual_estoque.fre_data_abertura, " ;
               command.CommandText += "fomulario_retirada_manual_estoque.fre_quantidade, " ;
               command.CommandText += "fomulario_retirada_manual_estoque.id_acs_usuario_retirada, " ;
               command.CommandText += "fomulario_retirada_manual_estoque.fre_data_retirada, " ;
               command.CommandText += "fomulario_retirada_manual_estoque.entity_uid, " ;
               command.CommandText += "fomulario_retirada_manual_estoque.version, " ;
               command.CommandText += "fomulario_retirada_manual_estoque.id_estoque_gaveta, " ;
               command.CommandText += "fomulario_retirada_manual_estoque.id_estoque_gaveta_destino, " ;
               command.CommandText += "fomulario_retirada_manual_estoque.fre_observacao, " ;
               command.CommandText += "fomulario_retirada_manual_estoque.id_epi " ;
               }
               command.CommandText += " FROM  fomulario_retirada_manual_estoque ";
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
                        orderByClause += " , fre_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(fre_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = fomulario_retirada_manual_estoque.id_acs_usuario_ultima_revisao ";
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
                     case "id_fomulario_retirada_manual_estoque":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , fomulario_retirada_manual_estoque.id_fomulario_retirada_manual_estoque " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(fomulario_retirada_manual_estoque.id_fomulario_retirada_manual_estoque) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_produto":
                     case "Produto":
                     command.CommandText += " LEFT JOIN produto as produto_Produto ON produto_Produto.id_produto = fomulario_retirada_manual_estoque.id_produto ";                     switch (parametro.TipoOrdenacao)
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
                     command.CommandText += " LEFT JOIN material as material_Material ON material_Material.id_material = fomulario_retirada_manual_estoque.id_material ";                     switch (parametro.TipoOrdenacao)
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
                     case "id_acs_usuario_abertura":
                     case "AcsUsuarioAbertura":
                     orderByClause += " , fomulario_retirada_manual_estoque.id_acs_usuario_abertura " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "fre_data_abertura":
                     case "DataAbertura":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , fomulario_retirada_manual_estoque.fre_data_abertura " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(fomulario_retirada_manual_estoque.fre_data_abertura) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fre_quantidade":
                     case "Quantidade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , fomulario_retirada_manual_estoque.fre_quantidade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(fomulario_retirada_manual_estoque.fre_quantidade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_retirada":
                     case "AcsUsuarioRetirada":
                     orderByClause += " , fomulario_retirada_manual_estoque.id_acs_usuario_retirada " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "fre_data_retirada":
                     case "DataRetirada":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , fomulario_retirada_manual_estoque.fre_data_retirada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(fomulario_retirada_manual_estoque.fre_data_retirada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , fomulario_retirada_manual_estoque.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(fomulario_retirada_manual_estoque.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , fomulario_retirada_manual_estoque.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(fomulario_retirada_manual_estoque.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_estoque_gaveta":
                     case "EstoqueGaveta":
                     command.CommandText += " LEFT JOIN estoque_gaveta as estoque_gaveta_EstoqueGaveta ON estoque_gaveta_EstoqueGaveta.id_estoque_gaveta = fomulario_retirada_manual_estoque.id_estoque_gaveta ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , estoque_gaveta_EstoqueGaveta.esg_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(estoque_gaveta_EstoqueGaveta.esg_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_estoque_gaveta_destino":
                     case "EstoqueGavetaDestino":
                     command.CommandText += " LEFT JOIN estoque_gaveta as estoque_gaveta_EstoqueGavetaDestino ON estoque_gaveta_EstoqueGavetaDestino.id_estoque_gaveta = fomulario_retirada_manual_estoque.id_estoque_gaveta_destino ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , estoque_gaveta_EstoqueGavetaDestino.esg_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(estoque_gaveta_EstoqueGavetaDestino.esg_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fre_observacao":
                     case "Observacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , fomulario_retirada_manual_estoque.fre_observacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(fomulario_retirada_manual_estoque.fre_observacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_epi":
                     case "Epi":
                     command.CommandText += " LEFT JOIN epi as epi_Epi ON epi_Epi.id_epi = fomulario_retirada_manual_estoque.id_epi ";                     switch (parametro.TipoOrdenacao)
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
                           whereClause += " OR UPPER(fomulario_retirada_manual_estoque.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(fomulario_retirada_manual_estoque.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("fre_observacao")) 
                        {
                           whereClause += " OR UPPER(fomulario_retirada_manual_estoque.fre_observacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(fomulario_retirada_manual_estoque.fre_observacao) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_fomulario_retirada_manual_estoque")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fomulario_retirada_manual_estoque.id_fomulario_retirada_manual_estoque IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fomulario_retirada_manual_estoque.id_fomulario_retirada_manual_estoque = :fomulario_retirada_manual_estoque_ID_7283 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fomulario_retirada_manual_estoque_ID_7283", NpgsqlDbType.Bigint, parametro.Fieldvalue));
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
                         whereClause += "  fomulario_retirada_manual_estoque.id_produto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fomulario_retirada_manual_estoque.id_produto = :fomulario_retirada_manual_estoque_Produto_3239 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fomulario_retirada_manual_estoque_Produto_3239", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  fomulario_retirada_manual_estoque.id_material IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fomulario_retirada_manual_estoque.id_material = :fomulario_retirada_manual_estoque_Material_6185 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fomulario_retirada_manual_estoque_Material_6185", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcsUsuarioAbertura" || parametro.FieldName == "id_acs_usuario_abertura")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fomulario_retirada_manual_estoque.id_acs_usuario_abertura IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fomulario_retirada_manual_estoque.id_acs_usuario_abertura = :fomulario_retirada_manual_estoque_AcsUsuarioAbertura_7515 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fomulario_retirada_manual_estoque_AcsUsuarioAbertura_7515", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataAbertura" || parametro.FieldName == "fre_data_abertura")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fomulario_retirada_manual_estoque.fre_data_abertura IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fomulario_retirada_manual_estoque.fre_data_abertura = :fomulario_retirada_manual_estoque_DataAbertura_1360 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fomulario_retirada_manual_estoque_DataAbertura_1360", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Quantidade" || parametro.FieldName == "fre_quantidade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fomulario_retirada_manual_estoque.fre_quantidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fomulario_retirada_manual_estoque.fre_quantidade = :fomulario_retirada_manual_estoque_Quantidade_4406 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fomulario_retirada_manual_estoque_Quantidade_4406", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcsUsuarioRetirada" || parametro.FieldName == "id_acs_usuario_retirada")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fomulario_retirada_manual_estoque.id_acs_usuario_retirada IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fomulario_retirada_manual_estoque.id_acs_usuario_retirada = :fomulario_retirada_manual_estoque_AcsUsuarioRetirada_2238 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fomulario_retirada_manual_estoque_AcsUsuarioRetirada_2238", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataRetirada" || parametro.FieldName == "fre_data_retirada")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fomulario_retirada_manual_estoque.fre_data_retirada IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fomulario_retirada_manual_estoque.fre_data_retirada = :fomulario_retirada_manual_estoque_DataRetirada_4181 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fomulario_retirada_manual_estoque_DataRetirada_4181", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
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
                         whereClause += "  fomulario_retirada_manual_estoque.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fomulario_retirada_manual_estoque.entity_uid LIKE :fomulario_retirada_manual_estoque_EntityUid_3199 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fomulario_retirada_manual_estoque_EntityUid_3199", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  fomulario_retirada_manual_estoque.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fomulario_retirada_manual_estoque.version = :fomulario_retirada_manual_estoque_Version_9260 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fomulario_retirada_manual_estoque_Version_9260", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EstoqueGaveta" || parametro.FieldName == "id_estoque_gaveta")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.EstoqueGavetaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.EstoqueGavetaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fomulario_retirada_manual_estoque.id_estoque_gaveta IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fomulario_retirada_manual_estoque.id_estoque_gaveta = :fomulario_retirada_manual_estoque_EstoqueGaveta_9322 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fomulario_retirada_manual_estoque_EstoqueGaveta_9322", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EstoqueGavetaDestino" || parametro.FieldName == "id_estoque_gaveta_destino")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.EstoqueGavetaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.EstoqueGavetaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fomulario_retirada_manual_estoque.id_estoque_gaveta_destino IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fomulario_retirada_manual_estoque.id_estoque_gaveta_destino = :fomulario_retirada_manual_estoque_EstoqueGavetaDestino_9559 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fomulario_retirada_manual_estoque_EstoqueGavetaDestino_9559", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Observacao" || parametro.FieldName == "fre_observacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fomulario_retirada_manual_estoque.fre_observacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fomulario_retirada_manual_estoque.fre_observacao LIKE :fomulario_retirada_manual_estoque_Observacao_1839 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fomulario_retirada_manual_estoque_Observacao_1839", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  fomulario_retirada_manual_estoque.id_epi IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fomulario_retirada_manual_estoque.id_epi = :fomulario_retirada_manual_estoque_Epi_8470 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fomulario_retirada_manual_estoque_Epi_8470", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  fomulario_retirada_manual_estoque.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fomulario_retirada_manual_estoque.entity_uid LIKE :fomulario_retirada_manual_estoque_EntityUid_5649 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fomulario_retirada_manual_estoque_EntityUid_5649", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ObservacaoExato" || parametro.FieldName == "ObservacaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  fomulario_retirada_manual_estoque.fre_observacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  fomulario_retirada_manual_estoque.fre_observacao LIKE :fomulario_retirada_manual_estoque_Observacao_9529 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fomulario_retirada_manual_estoque_Observacao_9529", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  FomularioRetiradaManualEstoqueClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (FomularioRetiradaManualEstoqueClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(FomularioRetiradaManualEstoqueClass), Convert.ToInt32(read["id_fomulario_retirada_manual_estoque"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new FomularioRetiradaManualEstoqueClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_fomulario_retirada_manual_estoque"]);
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
                     if (read["id_acs_usuario_abertura"] != DBNull.Value)
                     {
                        entidade.AcsUsuarioAbertura = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_abertura"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuarioAbertura = null ;
                     }
                     entidade.DataAbertura = (DateTime)read["fre_data_abertura"];
                     entidade.Quantidade = (double)read["fre_quantidade"];
                     if (read["id_acs_usuario_retirada"] != DBNull.Value)
                     {
                        entidade.AcsUsuarioRetirada = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_retirada"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuarioRetirada = null ;
                     }
                     entidade.DataRetirada = read["fre_data_retirada"] as DateTime?;
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     if (read["id_estoque_gaveta"] != DBNull.Value)
                     {
                        entidade.EstoqueGaveta = (BibliotecaEntidades.Entidades.EstoqueGavetaClass)BibliotecaEntidades.Entidades.EstoqueGavetaClass.GetEntidade(Convert.ToInt32(read["id_estoque_gaveta"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.EstoqueGaveta = null ;
                     }
                     if (read["id_estoque_gaveta_destino"] != DBNull.Value)
                     {
                        entidade.EstoqueGavetaDestino = (BibliotecaEntidades.Entidades.EstoqueGavetaClass)BibliotecaEntidades.Entidades.EstoqueGavetaClass.GetEntidade(Convert.ToInt32(read["id_estoque_gaveta_destino"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.EstoqueGavetaDestino = null ;
                     }
                     entidade.Observacao = (read["fre_observacao"] != DBNull.Value ? read["fre_observacao"].ToString() : null);
                     if (read["id_epi"] != DBNull.Value)
                     {
                        entidade.Epi = (BibliotecaEntidades.Entidades.EpiClass)BibliotecaEntidades.Entidades.EpiClass.GetEntidade(Convert.ToInt32(read["id_epi"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Epi = null ;
                     }
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (FomularioRetiradaManualEstoqueClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
