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
     [Table("kanban_acionamento","kba")]
     public class KanbanAcionamentoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do KanbanAcionamentoClass";
protected const string ErroDelete = "Erro ao excluir o KanbanAcionamentoClass  ";
protected const string ErroSave = "Erro ao salvar o KanbanAcionamentoClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroAcsUsuarioAcionamentoObrigatorio = "O campo AcsUsuarioAcionamento é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do KanbanAcionamentoClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade KanbanAcionamentoClass está sendo utilizada.";
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

       protected BibliotecaEntidades.Entidades.ProdutoKClass _produtoKOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.ProdutoKClass _produtoKOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.ProdutoKClass _valueProdutoK;
        [Column("id_produto_k", "produto_k", "id_produto_k")]
       public virtual BibliotecaEntidades.Entidades.ProdutoKClass ProdutoK
        { 
           get {                 return this._valueProdutoK; } 
           set 
           { 
                if (this._valueProdutoK == value)return;
                 this._valueProdutoK = value; 
           } 
       } 

       protected EstoqueSeguranca _tipoOriginal{get;private set;}
       private EstoqueSeguranca _tipoOriginalCommited{get; set;}
        private EstoqueSeguranca _valueTipo;
         [Column("kba_tipo")]
        public virtual EstoqueSeguranca Tipo
         { 
            get { return this._valueTipo; } 
            set 
            { 
                if (this._valueTipo == value)return;
                 this._valueTipo = value; 
            } 
        } 

        public bool Tipo_NaoUtilizando
         { 
            get { return this._valueTipo == BibliotecaEntidades.Base.EstoqueSeguranca.NaoUtilizando; } 
            set { if (value) this._valueTipo = BibliotecaEntidades.Base.EstoqueSeguranca.NaoUtilizando; }
         } 

        public bool Tipo_Verde
         { 
            get { return this._valueTipo == BibliotecaEntidades.Base.EstoqueSeguranca.Verde; } 
            set { if (value) this._valueTipo = BibliotecaEntidades.Base.EstoqueSeguranca.Verde; }
         } 

        public bool Tipo_Amarelo
         { 
            get { return this._valueTipo == BibliotecaEntidades.Base.EstoqueSeguranca.Amarelo; } 
            set { if (value) this._valueTipo = BibliotecaEntidades.Base.EstoqueSeguranca.Amarelo; }
         } 

        public bool Tipo_Vermelho
         { 
            get { return this._valueTipo == BibliotecaEntidades.Base.EstoqueSeguranca.Vermelho; } 
            set { if (value) this._valueTipo = BibliotecaEntidades.Base.EstoqueSeguranca.Vermelho; }
         } 

       protected DateTime _dataAcionamentoOriginal{get;private set;}
       private DateTime _dataAcionamentoOriginalCommited{get; set;}
        private DateTime _valueDataAcionamento;
         [Column("kba_data_acionamento")]
        public virtual DateTime DataAcionamento
         { 
            get { return this._valueDataAcionamento; } 
            set 
            { 
                if (this._valueDataAcionamento == value)return;
                 this._valueDataAcionamento = value; 
            } 
        } 

       protected IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioAcionamentoOriginal{get;private set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioAcionamentoOriginalCommited {get; set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _valueAcsUsuarioAcionamento;
        [Column("id_acs_usuario_acionamento", "acs_usuario", "id_acs_usuario")]
       public virtual IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass AcsUsuarioAcionamento
        { 
           get {                 return this._valueAcsUsuarioAcionamento; } 
           set 
           { 
                if (this._valueAcsUsuarioAcionamento == value)return;
                 this._valueAcsUsuarioAcionamento = value; 
           } 
       } 

       protected DateTime? _dataRetiradaOriginal{get;private set;}
       private DateTime? _dataRetiradaOriginalCommited{get; set;}
        private DateTime? _valueDataRetirada;
         [Column("kba_data_retirada")]
        public virtual DateTime? DataRetirada
         { 
            get { return this._valueDataRetirada; } 
            set 
            { 
                if (this._valueDataRetirada == value)return;
                 this._valueDataRetirada = value; 
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

       protected string _entidadeRetiradaAutomaticaOriginal{get;private set;}
       private string _entidadeRetiradaAutomaticaOriginalCommited{get; set;}
        private string _valueEntidadeRetiradaAutomatica;
         [Column("kba_entidade_retirada_automatica")]
        public virtual string EntidadeRetiradaAutomatica
         { 
            get { return this._valueEntidadeRetiradaAutomatica; } 
            set 
            { 
                if (this._valueEntidadeRetiradaAutomatica == value)return;
                 this._valueEntidadeRetiradaAutomatica = value; 
            } 
        } 

       protected bool _encerradoOriginal{get;private set;}
       private bool _encerradoOriginalCommited{get; set;}
        private bool _valueEncerrado;
         [Column("kba_encerrado")]
        public virtual bool Encerrado
         { 
            get { return this._valueEncerrado; } 
            set 
            { 
                if (this._valueEncerrado == value)return;
                 this._valueEncerrado = value; 
            } 
        } 

       protected bool? _retiradaManualOriginal{get;private set;}
       private bool? _retiradaManualOriginalCommited{get; set;}
        private bool? _valueRetiradaManual;
         [Column("kba_retirada_manual")]
        public virtual bool? RetiradaManual
         { 
            get { return this._valueRetiradaManual; } 
            set 
            { 
                if (this._valueRetiradaManual == value)return;
                 this._valueRetiradaManual = value; 
            } 
        } 

        public KanbanAcionamentoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Encerrado = false;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static KanbanAcionamentoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (KanbanAcionamentoClass) GetEntity(typeof(KanbanAcionamentoClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if ( _valueAcsUsuarioAcionamento == null)
                {
                    throw new Exception(ErroAcsUsuarioAcionamentoObrigatorio);
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
                    "  public.kanban_acionamento  " +
                    "WHERE " +
                    "  id_kanban_acionamento = :id";
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
                        "  public.kanban_acionamento   " +
                        "SET  " + 
                        "  id_material = :id_material, " + 
                        "  id_produto = :id_produto, " + 
                        "  id_epi = :id_epi, " + 
                        "  id_produto_k = :id_produto_k, " + 
                        "  kba_tipo = :kba_tipo, " + 
                        "  kba_data_acionamento = :kba_data_acionamento, " + 
                        "  id_acs_usuario_acionamento = :id_acs_usuario_acionamento, " + 
                        "  kba_data_retirada = :kba_data_retirada, " + 
                        "  id_acs_usuario_retirada = :id_acs_usuario_retirada, " + 
                        "  kba_entidade_retirada_automatica = :kba_entidade_retirada_automatica, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  kba_encerrado = :kba_encerrado, " + 
                        "  kba_retirada_manual = :kba_retirada_manual "+
                        "WHERE  " +
                        "  id_kanban_acionamento = :id " +
                        "RETURNING id_kanban_acionamento;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.kanban_acionamento " +
                        "( " +
                        "  id_material , " + 
                        "  id_produto , " + 
                        "  id_epi , " + 
                        "  id_produto_k , " + 
                        "  kba_tipo , " + 
                        "  kba_data_acionamento , " + 
                        "  id_acs_usuario_acionamento , " + 
                        "  kba_data_retirada , " + 
                        "  id_acs_usuario_retirada , " + 
                        "  kba_entidade_retirada_automatica , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  kba_encerrado , " + 
                        "  kba_retirada_manual  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_material , " + 
                        "  :id_produto , " + 
                        "  :id_epi , " + 
                        "  :id_produto_k , " + 
                        "  :kba_tipo , " + 
                        "  :kba_data_acionamento , " + 
                        "  :id_acs_usuario_acionamento , " + 
                        "  :kba_data_retirada , " + 
                        "  :id_acs_usuario_retirada , " + 
                        "  :kba_entidade_retirada_automatica , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :kba_encerrado , " + 
                        "  :kba_retirada_manual  "+
                        ")RETURNING id_kanban_acionamento;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_material", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Material==null ? (object) DBNull.Value : this.Material.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Produto==null ? (object) DBNull.Value : this.Produto.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_epi", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Epi==null ? (object) DBNull.Value : this.Epi.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto_k", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.ProdutoK==null ? (object) DBNull.Value : this.ProdutoK.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("kba_tipo", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Tipo);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("kba_data_acionamento", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataAcionamento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_acionamento", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuarioAcionamento==null ? (object) DBNull.Value : this.AcsUsuarioAcionamento.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("kba_data_retirada", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataRetirada ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_retirada", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuarioRetirada==null ? (object) DBNull.Value : this.AcsUsuarioRetirada.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("kba_entidade_retirada_automatica", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntidadeRetiradaAutomatica ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("kba_encerrado", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Encerrado ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("kba_retirada_manual", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.RetiradaManual ?? DBNull.Value;

 
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
        public static KanbanAcionamentoClass CopiarEntidade(KanbanAcionamentoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               KanbanAcionamentoClass toRet = new KanbanAcionamentoClass(usuario,conn);
 toRet.Material= entidadeCopiar.Material;
 toRet.Produto= entidadeCopiar.Produto;
 toRet.Epi= entidadeCopiar.Epi;
 toRet.ProdutoK= entidadeCopiar.ProdutoK;
 toRet.Tipo= entidadeCopiar.Tipo;
 toRet.DataAcionamento= entidadeCopiar.DataAcionamento;
 toRet.AcsUsuarioAcionamento= entidadeCopiar.AcsUsuarioAcionamento;
 toRet.DataRetirada= entidadeCopiar.DataRetirada;
 toRet.AcsUsuarioRetirada= entidadeCopiar.AcsUsuarioRetirada;
 toRet.EntidadeRetiradaAutomatica= entidadeCopiar.EntidadeRetiradaAutomatica;
 toRet.Encerrado= entidadeCopiar.Encerrado;
 toRet.RetiradaManual= entidadeCopiar.RetiradaManual;

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
       _produtoOriginal = Produto;
       _produtoOriginalCommited = _produtoOriginal;
       _epiOriginal = Epi;
       _epiOriginalCommited = _epiOriginal;
       _produtoKOriginal = ProdutoK;
       _produtoKOriginalCommited = _produtoKOriginal;
       _tipoOriginal = Tipo;
       _tipoOriginalCommited = _tipoOriginal;
       _dataAcionamentoOriginal = DataAcionamento;
       _dataAcionamentoOriginalCommited = _dataAcionamentoOriginal;
       _acsUsuarioAcionamentoOriginal = AcsUsuarioAcionamento;
       _acsUsuarioAcionamentoOriginalCommited = _acsUsuarioAcionamentoOriginal;
       _dataRetiradaOriginal = DataRetirada;
       _dataRetiradaOriginalCommited = _dataRetiradaOriginal;
       _acsUsuarioRetiradaOriginal = AcsUsuarioRetirada;
       _acsUsuarioRetiradaOriginalCommited = _acsUsuarioRetiradaOriginal;
       _entidadeRetiradaAutomaticaOriginal = EntidadeRetiradaAutomatica;
       _entidadeRetiradaAutomaticaOriginalCommited = _entidadeRetiradaAutomaticaOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _encerradoOriginal = Encerrado;
       _encerradoOriginalCommited = _encerradoOriginal;
       _retiradaManualOriginal = RetiradaManual;
       _retiradaManualOriginalCommited = _retiradaManualOriginal;

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
       _produtoOriginalCommited = Produto;
       _epiOriginalCommited = Epi;
       _produtoKOriginalCommited = ProdutoK;
       _tipoOriginalCommited = Tipo;
       _dataAcionamentoOriginalCommited = DataAcionamento;
       _acsUsuarioAcionamentoOriginalCommited = AcsUsuarioAcionamento;
       _dataRetiradaOriginalCommited = DataRetirada;
       _acsUsuarioRetiradaOriginalCommited = AcsUsuarioRetirada;
       _entidadeRetiradaAutomaticaOriginalCommited = EntidadeRetiradaAutomatica;
       _versionOriginalCommited = Version;
       _encerradoOriginalCommited = Encerrado;
       _retiradaManualOriginalCommited = RetiradaManual;

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
               Produto=_produtoOriginal;
               _produtoOriginalCommited=_produtoOriginal;
               Epi=_epiOriginal;
               _epiOriginalCommited=_epiOriginal;
               ProdutoK=_produtoKOriginal;
               _produtoKOriginalCommited=_produtoKOriginal;
               Tipo=_tipoOriginal;
               _tipoOriginalCommited=_tipoOriginal;
               DataAcionamento=_dataAcionamentoOriginal;
               _dataAcionamentoOriginalCommited=_dataAcionamentoOriginal;
               AcsUsuarioAcionamento=_acsUsuarioAcionamentoOriginal;
               _acsUsuarioAcionamentoOriginalCommited=_acsUsuarioAcionamentoOriginal;
               DataRetirada=_dataRetiradaOriginal;
               _dataRetiradaOriginalCommited=_dataRetiradaOriginal;
               AcsUsuarioRetirada=_acsUsuarioRetiradaOriginal;
               _acsUsuarioRetiradaOriginalCommited=_acsUsuarioRetiradaOriginal;
               EntidadeRetiradaAutomatica=_entidadeRetiradaAutomaticaOriginal;
               _entidadeRetiradaAutomaticaOriginalCommited=_entidadeRetiradaAutomaticaOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               Encerrado=_encerradoOriginal;
               _encerradoOriginalCommited=_encerradoOriginal;
               RetiradaManual=_retiradaManualOriginal;
               _retiradaManualOriginalCommited=_retiradaManualOriginal;

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
       if (_produtoOriginal!=null)
       {
          dirty = !_produtoOriginal.Equals(Produto);
       }
       else
       {
            dirty = Produto != null;
       }
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
       if (_produtoKOriginal!=null)
       {
          dirty = !_produtoKOriginal.Equals(ProdutoK);
       }
       else
       {
            dirty = ProdutoK != null;
       }
      if (dirty) return true;
       dirty = _tipoOriginal != Tipo;
      if (dirty) return true;
       dirty = _dataAcionamentoOriginal != DataAcionamento;
      if (dirty) return true;
       if (_acsUsuarioAcionamentoOriginal!=null)
       {
          dirty = !_acsUsuarioAcionamentoOriginal.Equals(AcsUsuarioAcionamento);
       }
       else
       {
            dirty = AcsUsuarioAcionamento != null;
       }
      if (dirty) return true;
       dirty = _dataRetiradaOriginal != DataRetirada;
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
       dirty = _entidadeRetiradaAutomaticaOriginal != EntidadeRetiradaAutomatica;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _encerradoOriginal != Encerrado;
      if (dirty) return true;
       dirty = _retiradaManualOriginal != RetiradaManual;

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
       if (_produtoOriginalCommited!=null)
       {
          dirty = !_produtoOriginalCommited.Equals(Produto);
       }
       else
       {
            dirty = Produto != null;
       }
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
       if (_produtoKOriginalCommited!=null)
       {
          dirty = !_produtoKOriginalCommited.Equals(ProdutoK);
       }
       else
       {
            dirty = ProdutoK != null;
       }
      if (dirty) return true;
       dirty = _tipoOriginalCommited != Tipo;
      if (dirty) return true;
       dirty = _dataAcionamentoOriginalCommited != DataAcionamento;
      if (dirty) return true;
       if (_acsUsuarioAcionamentoOriginalCommited!=null)
       {
          dirty = !_acsUsuarioAcionamentoOriginalCommited.Equals(AcsUsuarioAcionamento);
       }
       else
       {
            dirty = AcsUsuarioAcionamento != null;
       }
      if (dirty) return true;
       dirty = _dataRetiradaOriginalCommited != DataRetirada;
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
       dirty = _entidadeRetiradaAutomaticaOriginalCommited != EntidadeRetiradaAutomatica;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _encerradoOriginalCommited != Encerrado;
      if (dirty) return true;
       dirty = _retiradaManualOriginalCommited != RetiradaManual;

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
             case "Produto":
                return this.Produto;
             case "Epi":
                return this.Epi;
             case "ProdutoK":
                return this.ProdutoK;
             case "Tipo":
                return this.Tipo;
             case "DataAcionamento":
                return this.DataAcionamento;
             case "AcsUsuarioAcionamento":
                return this.AcsUsuarioAcionamento;
             case "DataRetirada":
                return this.DataRetirada;
             case "AcsUsuarioRetirada":
                return this.AcsUsuarioRetirada;
             case "EntidadeRetiradaAutomatica":
                return this.EntidadeRetiradaAutomatica;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "Encerrado":
                return this.Encerrado;
             case "RetiradaManual":
                return this.RetiradaManual;
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
             if (Produto!=null)
                Produto.ChangeSingleConnection(newConnection);
             if (Epi!=null)
                Epi.ChangeSingleConnection(newConnection);
             if (ProdutoK!=null)
                ProdutoK.ChangeSingleConnection(newConnection);
             if (AcsUsuarioAcionamento!=null)
                AcsUsuarioAcionamento.ChangeSingleConnection(newConnection);
             if (AcsUsuarioRetirada!=null)
                AcsUsuarioRetirada.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(kanban_acionamento.id_kanban_acionamento) " ;
               }
               else
               {
               command.CommandText += "kanban_acionamento.id_kanban_acionamento, " ;
               command.CommandText += "kanban_acionamento.id_material, " ;
               command.CommandText += "kanban_acionamento.id_produto, " ;
               command.CommandText += "kanban_acionamento.id_epi, " ;
               command.CommandText += "kanban_acionamento.id_produto_k, " ;
               command.CommandText += "kanban_acionamento.kba_tipo, " ;
               command.CommandText += "kanban_acionamento.kba_data_acionamento, " ;
               command.CommandText += "kanban_acionamento.id_acs_usuario_acionamento, " ;
               command.CommandText += "kanban_acionamento.kba_data_retirada, " ;
               command.CommandText += "kanban_acionamento.id_acs_usuario_retirada, " ;
               command.CommandText += "kanban_acionamento.kba_entidade_retirada_automatica, " ;
               command.CommandText += "kanban_acionamento.entity_uid, " ;
               command.CommandText += "kanban_acionamento.version, " ;
               command.CommandText += "kanban_acionamento.kba_encerrado, " ;
               command.CommandText += "kanban_acionamento.kba_retirada_manual " ;
               }
               command.CommandText += " FROM  kanban_acionamento ";
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
                        orderByClause += " , kba_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(kba_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = kanban_acionamento.id_acs_usuario_ultima_revisao ";
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
                     case "id_kanban_acionamento":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , kanban_acionamento.id_kanban_acionamento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(kanban_acionamento.id_kanban_acionamento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_material":
                     case "Material":
                     command.CommandText += " LEFT JOIN material as material_Material ON material_Material.id_material = kanban_acionamento.id_material ";                     switch (parametro.TipoOrdenacao)
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
                     case "id_produto":
                     case "Produto":
                     command.CommandText += " LEFT JOIN produto as produto_Produto ON produto_Produto.id_produto = kanban_acionamento.id_produto ";                     switch (parametro.TipoOrdenacao)
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
                     case "id_epi":
                     case "Epi":
                     command.CommandText += " LEFT JOIN epi as epi_Epi ON epi_Epi.id_epi = kanban_acionamento.id_epi ";                     switch (parametro.TipoOrdenacao)
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
                     case "id_produto_k":
                     case "ProdutoK":
                     command.CommandText += " LEFT JOIN produto_k as produto_k_ProdutoK ON produto_k_ProdutoK.id_produto_k = kanban_acionamento.id_produto_k ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_k_ProdutoK.prk_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_k_ProdutoK.prk_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_k_ProdutoK.prk_dimensao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_k_ProdutoK.prk_dimensao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "kba_tipo":
                     case "Tipo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , kanban_acionamento.kba_tipo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(kanban_acionamento.kba_tipo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "kba_data_acionamento":
                     case "DataAcionamento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , kanban_acionamento.kba_data_acionamento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(kanban_acionamento.kba_data_acionamento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_acionamento":
                     case "AcsUsuarioAcionamento":
                     orderByClause += " , kanban_acionamento.id_acs_usuario_acionamento " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "kba_data_retirada":
                     case "DataRetirada":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , kanban_acionamento.kba_data_retirada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(kanban_acionamento.kba_data_retirada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_retirada":
                     case "AcsUsuarioRetirada":
                     orderByClause += " , kanban_acionamento.id_acs_usuario_retirada " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "kba_entidade_retirada_automatica":
                     case "EntidadeRetiradaAutomatica":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , kanban_acionamento.kba_entidade_retirada_automatica " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(kanban_acionamento.kba_entidade_retirada_automatica) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , kanban_acionamento.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(kanban_acionamento.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , kanban_acionamento.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(kanban_acionamento.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "kba_encerrado":
                     case "Encerrado":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , kanban_acionamento.kba_encerrado " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(kanban_acionamento.kba_encerrado) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "kba_retirada_manual":
                     case "RetiradaManual":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , kanban_acionamento.kba_retirada_manual " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(kanban_acionamento.kba_retirada_manual) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("kba_entidade_retirada_automatica")) 
                        {
                           whereClause += " OR UPPER(kanban_acionamento.kba_entidade_retirada_automatica) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(kanban_acionamento.kba_entidade_retirada_automatica) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(kanban_acionamento.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(kanban_acionamento.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_kanban_acionamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  kanban_acionamento.id_kanban_acionamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  kanban_acionamento.id_kanban_acionamento = :kanban_acionamento_ID_9953 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("kanban_acionamento_ID_9953", NpgsqlDbType.Bigint, parametro.Fieldvalue));
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
                         whereClause += "  kanban_acionamento.id_material IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  kanban_acionamento.id_material = :kanban_acionamento_Material_8761 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("kanban_acionamento_Material_8761", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  kanban_acionamento.id_produto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  kanban_acionamento.id_produto = :kanban_acionamento_Produto_9315 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("kanban_acionamento_Produto_9315", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  kanban_acionamento.id_epi IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  kanban_acionamento.id_epi = :kanban_acionamento_Epi_1763 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("kanban_acionamento_Epi_1763", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ProdutoK" || parametro.FieldName == "id_produto_k")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.ProdutoKClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.ProdutoKClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  kanban_acionamento.id_produto_k IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  kanban_acionamento.id_produto_k = :kanban_acionamento_ProdutoK_8357 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("kanban_acionamento_ProdutoK_8357", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Tipo" || parametro.FieldName == "kba_tipo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is EstoqueSeguranca)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo EstoqueSeguranca");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  kanban_acionamento.kba_tipo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  kanban_acionamento.kba_tipo = :kanban_acionamento_Tipo_4771 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("kanban_acionamento_Tipo_4771", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataAcionamento" || parametro.FieldName == "kba_data_acionamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  kanban_acionamento.kba_data_acionamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  kanban_acionamento.kba_data_acionamento = :kanban_acionamento_DataAcionamento_9260 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("kanban_acionamento_DataAcionamento_9260", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcsUsuarioAcionamento" || parametro.FieldName == "id_acs_usuario_acionamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  kanban_acionamento.id_acs_usuario_acionamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  kanban_acionamento.id_acs_usuario_acionamento = :kanban_acionamento_AcsUsuarioAcionamento_5749 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("kanban_acionamento_AcsUsuarioAcionamento_5749", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataRetirada" || parametro.FieldName == "kba_data_retirada")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  kanban_acionamento.kba_data_retirada IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  kanban_acionamento.kba_data_retirada = :kanban_acionamento_DataRetirada_8071 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("kanban_acionamento_DataRetirada_8071", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
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
                         whereClause += "  kanban_acionamento.id_acs_usuario_retirada IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  kanban_acionamento.id_acs_usuario_retirada = :kanban_acionamento_AcsUsuarioRetirada_9827 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("kanban_acionamento_AcsUsuarioRetirada_9827", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EntidadeRetiradaAutomatica" || parametro.FieldName == "kba_entidade_retirada_automatica")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  kanban_acionamento.kba_entidade_retirada_automatica IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  kanban_acionamento.kba_entidade_retirada_automatica LIKE :kanban_acionamento_EntidadeRetiradaAutomatica_971 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("kanban_acionamento_EntidadeRetiradaAutomatica_971", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  kanban_acionamento.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  kanban_acionamento.entity_uid LIKE :kanban_acionamento_EntityUid_2052 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("kanban_acionamento_EntityUid_2052", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  kanban_acionamento.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  kanban_acionamento.version = :kanban_acionamento_Version_659 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("kanban_acionamento_Version_659", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Encerrado" || parametro.FieldName == "kba_encerrado")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  kanban_acionamento.kba_encerrado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  kanban_acionamento.kba_encerrado = :kanban_acionamento_Encerrado_5069 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("kanban_acionamento_Encerrado_5069", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RetiradaManual" || parametro.FieldName == "kba_retirada_manual")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  kanban_acionamento.kba_retirada_manual IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  kanban_acionamento.kba_retirada_manual = :kanban_acionamento_RetiradaManual_7126 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("kanban_acionamento_RetiradaManual_7126", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EntidadeRetiradaAutomaticaExato" || parametro.FieldName == "EntidadeRetiradaAutomaticaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  kanban_acionamento.kba_entidade_retirada_automatica IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  kanban_acionamento.kba_entidade_retirada_automatica LIKE :kanban_acionamento_EntidadeRetiradaAutomatica_2183 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("kanban_acionamento_EntidadeRetiradaAutomatica_2183", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  kanban_acionamento.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  kanban_acionamento.entity_uid LIKE :kanban_acionamento_EntityUid_864 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("kanban_acionamento_EntityUid_864", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  KanbanAcionamentoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (KanbanAcionamentoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(KanbanAcionamentoClass), Convert.ToInt32(read["id_kanban_acionamento"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new KanbanAcionamentoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_kanban_acionamento"]);
                     if (read["id_material"] != DBNull.Value)
                     {
                        entidade.Material = (BibliotecaEntidades.Entidades.MaterialClass)BibliotecaEntidades.Entidades.MaterialClass.GetEntidade(Convert.ToInt32(read["id_material"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Material = null ;
                     }
                     if (read["id_produto"] != DBNull.Value)
                     {
                        entidade.Produto = (BibliotecaEntidades.Entidades.ProdutoClass)BibliotecaEntidades.Entidades.ProdutoClass.GetEntidade(Convert.ToInt32(read["id_produto"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Produto = null ;
                     }
                     if (read["id_epi"] != DBNull.Value)
                     {
                        entidade.Epi = (BibliotecaEntidades.Entidades.EpiClass)BibliotecaEntidades.Entidades.EpiClass.GetEntidade(Convert.ToInt32(read["id_epi"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Epi = null ;
                     }
                     if (read["id_produto_k"] != DBNull.Value)
                     {
                        entidade.ProdutoK = (BibliotecaEntidades.Entidades.ProdutoKClass)BibliotecaEntidades.Entidades.ProdutoKClass.GetEntidade(Convert.ToInt32(read["id_produto_k"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.ProdutoK = null ;
                     }
                     entidade.Tipo = (EstoqueSeguranca) (read["kba_tipo"] != DBNull.Value ? Enum.ToObject(typeof(EstoqueSeguranca), read["kba_tipo"]) : null);
                     entidade.DataAcionamento = (DateTime)read["kba_data_acionamento"];
                     if (read["id_acs_usuario_acionamento"] != DBNull.Value)
                     {
                        entidade.AcsUsuarioAcionamento = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_acionamento"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuarioAcionamento = null ;
                     }
                     entidade.DataRetirada = read["kba_data_retirada"] as DateTime?;
                     if (read["id_acs_usuario_retirada"] != DBNull.Value)
                     {
                        entidade.AcsUsuarioRetirada = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_retirada"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuarioRetirada = null ;
                     }
                     entidade.EntidadeRetiradaAutomatica = (read["kba_entidade_retirada_automatica"] != DBNull.Value ? read["kba_entidade_retirada_automatica"].ToString() : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.Encerrado = Convert.ToBoolean(Convert.ToInt16(read["kba_encerrado"]));
                     entidade.RetiradaManual = (read["kba_retirada_manual"] != DBNull.Value ? (bool?)Convert.ToBoolean(Convert.ToInt16(read["kba_retirada_manual"])) : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (KanbanAcionamentoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
