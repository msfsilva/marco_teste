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
     [Table("ordem_producao_diferenca","opd")]
     public class OrdemProducaoDiferencaBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do OrdemProducaoDiferencaClass";
protected const string ErroDelete = "Erro ao excluir o OrdemProducaoDiferencaClass  ";
protected const string ErroSave = "Erro ao salvar o OrdemProducaoDiferencaClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroOrdemProducaoObrigatorio = "O campo OrdemProducao é obrigatório";
protected const string ErroOrdemProducaoPostoTrabalhoObrigatorio = "O campo OrdemProducaoPostoTrabalho é obrigatório";
protected const string ErroAcsUsuarioObrigatorio = "O campo AcsUsuario é obrigatório";
protected const string ErroMotivoAlteracaoQtdOpObrigatorio = "O campo MotivoAlteracaoQtdOp é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do OrdemProducaoDiferencaClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade OrdemProducaoDiferencaClass está sendo utilizada.";
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

       protected BibliotecaEntidades.Entidades.OrdemProducaoPostoTrabalhoClass _ordemProducaoPostoTrabalhoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.OrdemProducaoPostoTrabalhoClass _ordemProducaoPostoTrabalhoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.OrdemProducaoPostoTrabalhoClass _valueOrdemProducaoPostoTrabalho;
        [Column("id_ordem_producao_posto_trabalho", "ordem_producao_posto_trabalho", "id_ordem_producao_posto_trabalho")]
       public virtual BibliotecaEntidades.Entidades.OrdemProducaoPostoTrabalhoClass OrdemProducaoPostoTrabalho
        { 
           get {                 return this._valueOrdemProducaoPostoTrabalho; } 
           set 
           { 
                if (this._valueOrdemProducaoPostoTrabalho == value)return;
                 this._valueOrdemProducaoPostoTrabalho = value; 
           } 
       } 

       protected IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioOriginal{get;private set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioOriginalCommited {get; set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _valueAcsUsuario;
        [Column("id_acs_usuario", "acs_usuario", "id_acs_usuario")]
       public virtual IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass AcsUsuario
        { 
           get {                 return this._valueAcsUsuario; } 
           set 
           { 
                if (this._valueAcsUsuario == value)return;
                 this._valueAcsUsuario = value; 
           } 
       } 

       protected bool? _reporOriginal{get;private set;}
       private bool? _reporOriginalCommited{get; set;}
        private bool? _valueRepor;
         [Column("opd_repor")]
        public virtual bool? Repor
         { 
            get { return this._valueRepor; } 
            set 
            { 
                if (this._valueRepor == value)return;
                 this._valueRepor = value; 
            } 
        } 

       protected bool? _repostoOriginal{get;private set;}
       private bool? _repostoOriginalCommited{get; set;}
        private bool? _valueReposto;
         [Column("opd_reposto")]
        public virtual bool? Reposto
         { 
            get { return this._valueReposto; } 
            set 
            { 
                if (this._valueReposto == value)return;
                 this._valueReposto = value; 
            } 
        } 

       protected double _quantidadeOriginal{get;private set;}
       private double _quantidadeOriginalCommited{get; set;}
        private double _valueQuantidade;
         [Column("opd_quantidade")]
        public virtual double Quantidade
         { 
            get { return this._valueQuantidade; } 
            set 
            { 
                if (this._valueQuantidade == value)return;
                 this._valueQuantidade = value; 
            } 
        } 

       protected DestinoDiferencaOP? _destinoOriginal{get;private set;}
       private DestinoDiferencaOP? _destinoOriginalCommited{get; set;}
        private DestinoDiferencaOP? _valueDestino;
         [Column("opd_destino")]
        public virtual DestinoDiferencaOP? Destino
         { 
            get { return this._valueDestino; } 
            set 
            { 
                if (this._valueDestino == value)return;
                 this._valueDestino = value; 
            } 
        } 

        public bool Destino_Descarte
         { 
            get { return this._valueDestino.HasValue && this._valueDestino.Value == BibliotecaEntidades.Base.DestinoDiferencaOP.Descarte; } 
            set { if (value) this._valueDestino = BibliotecaEntidades.Base.DestinoDiferencaOP.Descarte; }
         } 

        public bool Destino_Cliente
         { 
            get { return this._valueDestino.HasValue && this._valueDestino.Value == BibliotecaEntidades.Base.DestinoDiferencaOP.Cliente; } 
            set { if (value) this._valueDestino = BibliotecaEntidades.Base.DestinoDiferencaOP.Cliente; }
         } 

        public bool Destino_Estoque
         { 
            get { return this._valueDestino.HasValue && this._valueDestino.Value == BibliotecaEntidades.Base.DestinoDiferencaOP.Estoque; } 
            set { if (value) this._valueDestino = BibliotecaEntidades.Base.DestinoDiferencaOP.Estoque; }
         } 

       protected BibliotecaEntidades.Entidades.EstoqueClass _estoqueOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.EstoqueClass _estoqueOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.EstoqueClass _valueEstoque;
        [Column("id_estoque", "estoque", "id_estoque")]
       public virtual BibliotecaEntidades.Entidades.EstoqueClass Estoque
        { 
           get {                 return this._valueEstoque; } 
           set 
           { 
                if (this._valueEstoque == value)return;
                 this._valueEstoque = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.MotivoAlteracaoQtdOpClass _motivoAlteracaoQtdOpOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.MotivoAlteracaoQtdOpClass _motivoAlteracaoQtdOpOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.MotivoAlteracaoQtdOpClass _valueMotivoAlteracaoQtdOp;
        [Column("id_motivo_alteracao_qtd_op", "motivo_alteracao_qtd_op", "id_motivo_alteracao_qtd_op")]
       public virtual BibliotecaEntidades.Entidades.MotivoAlteracaoQtdOpClass MotivoAlteracaoQtdOp
        { 
           get {                 return this._valueMotivoAlteracaoQtdOp; } 
           set 
           { 
                if (this._valueMotivoAlteracaoQtdOp == value)return;
                 this._valueMotivoAlteracaoQtdOp = value; 
           } 
       } 

        public OrdemProducaoDiferencaBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Repor = false;
           this.Reposto = false;
           this.Destino = (DestinoDiferencaOP?)0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static OrdemProducaoDiferencaClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (OrdemProducaoDiferencaClass) GetEntity(typeof(OrdemProducaoDiferencaClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if ( _valueOrdemProducao == null)
                {
                    throw new Exception(ErroOrdemProducaoObrigatorio);
                }
                if ( _valueOrdemProducaoPostoTrabalho == null)
                {
                    throw new Exception(ErroOrdemProducaoPostoTrabalhoObrigatorio);
                }
                if ( _valueAcsUsuario == null)
                {
                    throw new Exception(ErroAcsUsuarioObrigatorio);
                }
                if ( _valueMotivoAlteracaoQtdOp == null)
                {
                    throw new Exception(ErroMotivoAlteracaoQtdOpObrigatorio);
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
                    "  public.ordem_producao_diferenca  " +
                    "WHERE " +
                    "  id_ordem_producao_diferenca = :id";
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
                        "  public.ordem_producao_diferenca   " +
                        "SET  " + 
                        "  id_ordem_producao = :id_ordem_producao, " + 
                        "  id_ordem_producao_posto_trabalho = :id_ordem_producao_posto_trabalho, " + 
                        "  id_acs_usuario = :id_acs_usuario, " + 
                        "  opd_repor = :opd_repor, " + 
                        "  opd_reposto = :opd_reposto, " + 
                        "  opd_quantidade = :opd_quantidade, " + 
                        "  opd_destino = :opd_destino, " + 
                        "  id_estoque = :id_estoque, " + 
                        "  id_motivo_alteracao_qtd_op = :id_motivo_alteracao_qtd_op, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_ordem_producao_diferenca = :id " +
                        "RETURNING id_ordem_producao_diferenca;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.ordem_producao_diferenca " +
                        "( " +
                        "  id_ordem_producao , " + 
                        "  id_ordem_producao_posto_trabalho , " + 
                        "  id_acs_usuario , " + 
                        "  opd_repor , " + 
                        "  opd_reposto , " + 
                        "  opd_quantidade , " + 
                        "  opd_destino , " + 
                        "  id_estoque , " + 
                        "  id_motivo_alteracao_qtd_op , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_ordem_producao , " + 
                        "  :id_ordem_producao_posto_trabalho , " + 
                        "  :id_acs_usuario , " + 
                        "  :opd_repor , " + 
                        "  :opd_reposto , " + 
                        "  :opd_quantidade , " + 
                        "  :opd_destino , " + 
                        "  :id_estoque , " + 
                        "  :id_motivo_alteracao_qtd_op , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_ordem_producao_diferenca;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.OrdemProducao==null ? (object) DBNull.Value : this.OrdemProducao.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao_posto_trabalho", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.OrdemProducaoPostoTrabalho==null ? (object) DBNull.Value : this.OrdemProducaoPostoTrabalho.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuario==null ? (object) DBNull.Value : this.AcsUsuario.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opd_repor", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Repor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opd_reposto", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Reposto ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opd_quantidade", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Quantidade ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opd_destino", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = this.Destino.HasValue ? (object)Convert.ToInt16(this.Destino) : (object)DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_estoque", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Estoque==null ? (object) DBNull.Value : this.Estoque.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_motivo_alteracao_qtd_op", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.MotivoAlteracaoQtdOp==null ? (object) DBNull.Value : this.MotivoAlteracaoQtdOp.ID;
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
        public static OrdemProducaoDiferencaClass CopiarEntidade(OrdemProducaoDiferencaClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               OrdemProducaoDiferencaClass toRet = new OrdemProducaoDiferencaClass(usuario,conn);
 toRet.OrdemProducao= entidadeCopiar.OrdemProducao;
 toRet.OrdemProducaoPostoTrabalho= entidadeCopiar.OrdemProducaoPostoTrabalho;
 toRet.AcsUsuario= entidadeCopiar.AcsUsuario;
 toRet.Repor= entidadeCopiar.Repor;
 toRet.Reposto= entidadeCopiar.Reposto;
 toRet.Quantidade= entidadeCopiar.Quantidade;
 toRet.Destino= entidadeCopiar.Destino;
 toRet.Estoque= entidadeCopiar.Estoque;
 toRet.MotivoAlteracaoQtdOp= entidadeCopiar.MotivoAlteracaoQtdOp;

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
       _ordemProducaoPostoTrabalhoOriginal = OrdemProducaoPostoTrabalho;
       _ordemProducaoPostoTrabalhoOriginalCommited = _ordemProducaoPostoTrabalhoOriginal;
       _acsUsuarioOriginal = AcsUsuario;
       _acsUsuarioOriginalCommited = _acsUsuarioOriginal;
       _reporOriginal = Repor;
       _reporOriginalCommited = _reporOriginal;
       _repostoOriginal = Reposto;
       _repostoOriginalCommited = _repostoOriginal;
       _quantidadeOriginal = Quantidade;
       _quantidadeOriginalCommited = _quantidadeOriginal;
       _destinoOriginal = Destino;
       _destinoOriginalCommited = _destinoOriginal;
       _estoqueOriginal = Estoque;
       _estoqueOriginalCommited = _estoqueOriginal;
       _motivoAlteracaoQtdOpOriginal = MotivoAlteracaoQtdOp;
       _motivoAlteracaoQtdOpOriginalCommited = _motivoAlteracaoQtdOpOriginal;
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
       _ordemProducaoPostoTrabalhoOriginalCommited = OrdemProducaoPostoTrabalho;
       _acsUsuarioOriginalCommited = AcsUsuario;
       _reporOriginalCommited = Repor;
       _repostoOriginalCommited = Reposto;
       _quantidadeOriginalCommited = Quantidade;
       _destinoOriginalCommited = Destino;
       _estoqueOriginalCommited = Estoque;
       _motivoAlteracaoQtdOpOriginalCommited = MotivoAlteracaoQtdOp;
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
               OrdemProducaoPostoTrabalho=_ordemProducaoPostoTrabalhoOriginal;
               _ordemProducaoPostoTrabalhoOriginalCommited=_ordemProducaoPostoTrabalhoOriginal;
               AcsUsuario=_acsUsuarioOriginal;
               _acsUsuarioOriginalCommited=_acsUsuarioOriginal;
               Repor=_reporOriginal;
               _reporOriginalCommited=_reporOriginal;
               Reposto=_repostoOriginal;
               _repostoOriginalCommited=_repostoOriginal;
               Quantidade=_quantidadeOriginal;
               _quantidadeOriginalCommited=_quantidadeOriginal;
               Destino=_destinoOriginal;
               _destinoOriginalCommited=_destinoOriginal;
               Estoque=_estoqueOriginal;
               _estoqueOriginalCommited=_estoqueOriginal;
               MotivoAlteracaoQtdOp=_motivoAlteracaoQtdOpOriginal;
               _motivoAlteracaoQtdOpOriginalCommited=_motivoAlteracaoQtdOpOriginal;
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
       if (_ordemProducaoPostoTrabalhoOriginal!=null)
       {
          dirty = !_ordemProducaoPostoTrabalhoOriginal.Equals(OrdemProducaoPostoTrabalho);
       }
       else
       {
            dirty = OrdemProducaoPostoTrabalho != null;
       }
      if (dirty) return true;
       if (_acsUsuarioOriginal!=null)
       {
          dirty = !_acsUsuarioOriginal.Equals(AcsUsuario);
       }
       else
       {
            dirty = AcsUsuario != null;
       }
      if (dirty) return true;
       dirty = _reporOriginal != Repor;
      if (dirty) return true;
       dirty = _repostoOriginal != Reposto;
      if (dirty) return true;
       dirty = _quantidadeOriginal != Quantidade;
      if (dirty) return true;
       dirty = _destinoOriginal != Destino;
      if (dirty) return true;
       if (_estoqueOriginal!=null)
       {
          dirty = !_estoqueOriginal.Equals(Estoque);
       }
       else
       {
            dirty = Estoque != null;
       }
      if (dirty) return true;
       if (_motivoAlteracaoQtdOpOriginal!=null)
       {
          dirty = !_motivoAlteracaoQtdOpOriginal.Equals(MotivoAlteracaoQtdOp);
       }
       else
       {
            dirty = MotivoAlteracaoQtdOp != null;
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
       if (_ordemProducaoOriginalCommited!=null)
       {
          dirty = !_ordemProducaoOriginalCommited.Equals(OrdemProducao);
       }
       else
       {
            dirty = OrdemProducao != null;
       }
      if (dirty) return true;
       if (_ordemProducaoPostoTrabalhoOriginalCommited!=null)
       {
          dirty = !_ordemProducaoPostoTrabalhoOriginalCommited.Equals(OrdemProducaoPostoTrabalho);
       }
       else
       {
            dirty = OrdemProducaoPostoTrabalho != null;
       }
      if (dirty) return true;
       if (_acsUsuarioOriginalCommited!=null)
       {
          dirty = !_acsUsuarioOriginalCommited.Equals(AcsUsuario);
       }
       else
       {
            dirty = AcsUsuario != null;
       }
      if (dirty) return true;
       dirty = _reporOriginalCommited != Repor;
      if (dirty) return true;
       dirty = _repostoOriginalCommited != Reposto;
      if (dirty) return true;
       dirty = _quantidadeOriginalCommited != Quantidade;
      if (dirty) return true;
       dirty = _destinoOriginalCommited != Destino;
      if (dirty) return true;
       if (_estoqueOriginalCommited!=null)
       {
          dirty = !_estoqueOriginalCommited.Equals(Estoque);
       }
       else
       {
            dirty = Estoque != null;
       }
      if (dirty) return true;
       if (_motivoAlteracaoQtdOpOriginalCommited!=null)
       {
          dirty = !_motivoAlteracaoQtdOpOriginalCommited.Equals(MotivoAlteracaoQtdOp);
       }
       else
       {
            dirty = MotivoAlteracaoQtdOp != null;
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
             case "OrdemProducao":
                return this.OrdemProducao;
             case "OrdemProducaoPostoTrabalho":
                return this.OrdemProducaoPostoTrabalho;
             case "AcsUsuario":
                return this.AcsUsuario;
             case "Repor":
                return this.Repor;
             case "Reposto":
                return this.Reposto;
             case "Quantidade":
                return this.Quantidade;
             case "Destino":
                return this.Destino;
             case "Estoque":
                return this.Estoque;
             case "MotivoAlteracaoQtdOp":
                return this.MotivoAlteracaoQtdOp;
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
             if (OrdemProducaoPostoTrabalho!=null)
                OrdemProducaoPostoTrabalho.ChangeSingleConnection(newConnection);
             if (AcsUsuario!=null)
                AcsUsuario.ChangeSingleConnection(newConnection);
             if (Estoque!=null)
                Estoque.ChangeSingleConnection(newConnection);
             if (MotivoAlteracaoQtdOp!=null)
                MotivoAlteracaoQtdOp.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(ordem_producao_diferenca.id_ordem_producao_diferenca) " ;
               }
               else
               {
               command.CommandText += "ordem_producao_diferenca.id_ordem_producao_diferenca, " ;
               command.CommandText += "ordem_producao_diferenca.id_ordem_producao, " ;
               command.CommandText += "ordem_producao_diferenca.id_ordem_producao_posto_trabalho, " ;
               command.CommandText += "ordem_producao_diferenca.id_acs_usuario, " ;
               command.CommandText += "ordem_producao_diferenca.opd_repor, " ;
               command.CommandText += "ordem_producao_diferenca.opd_reposto, " ;
               command.CommandText += "ordem_producao_diferenca.opd_quantidade, " ;
               command.CommandText += "ordem_producao_diferenca.opd_destino, " ;
               command.CommandText += "ordem_producao_diferenca.id_estoque, " ;
               command.CommandText += "ordem_producao_diferenca.id_motivo_alteracao_qtd_op, " ;
               command.CommandText += "ordem_producao_diferenca.entity_uid, " ;
               command.CommandText += "ordem_producao_diferenca.version " ;
               }
               command.CommandText += " FROM  ordem_producao_diferenca ";
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
                        orderByClause += " , opd_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(opd_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = ordem_producao_diferenca.id_acs_usuario_ultima_revisao ";
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
                     case "id_ordem_producao_diferenca":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_diferenca.id_ordem_producao_diferenca " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_diferenca.id_ordem_producao_diferenca) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_ordem_producao":
                     case "OrdemProducao":
                     command.CommandText += " LEFT JOIN ordem_producao as ordem_producao_OrdemProducao ON ordem_producao_OrdemProducao.id_ordem_producao = ordem_producao_diferenca.id_ordem_producao ";                     switch (parametro.TipoOrdenacao)
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
                     case "id_ordem_producao_posto_trabalho":
                     case "OrdemProducaoPostoTrabalho":
                     command.CommandText += " LEFT JOIN ordem_producao_posto_trabalho as ordem_producao_posto_trabalho_OrdemProducaoPostoTrabalho ON ordem_producao_posto_trabalho_OrdemProducaoPostoTrabalho.id_ordem_producao_posto_trabalho = ordem_producao_diferenca.id_ordem_producao_posto_trabalho ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_posto_trabalho_OrdemProducaoPostoTrabalho.id_ordem_producao_posto_trabalho " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_posto_trabalho_OrdemProducaoPostoTrabalho.id_ordem_producao_posto_trabalho) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario":
                     case "AcsUsuario":
                     orderByClause += " , ordem_producao_diferenca.id_acs_usuario " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "opd_repor":
                     case "Repor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_diferenca.opd_repor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_diferenca.opd_repor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opd_reposto":
                     case "Reposto":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_diferenca.opd_reposto " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_diferenca.opd_reposto) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opd_quantidade":
                     case "Quantidade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_diferenca.opd_quantidade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_diferenca.opd_quantidade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opd_destino":
                     case "Destino":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_diferenca.opd_destino " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_diferenca.opd_destino) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_estoque":
                     case "Estoque":
                     command.CommandText += " LEFT JOIN estoque as estoque_Estoque ON estoque_Estoque.id_estoque = ordem_producao_diferenca.id_estoque ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , estoque_Estoque.est_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(estoque_Estoque.est_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_motivo_alteracao_qtd_op":
                     case "MotivoAlteracaoQtdOp":
                     command.CommandText += " LEFT JOIN motivo_alteracao_qtd_op as motivo_alteracao_qtd_op_MotivoAlteracaoQtdOp ON motivo_alteracao_qtd_op_MotivoAlteracaoQtdOp.id_motivo_alteracao_qtd_op = ordem_producao_diferenca.id_motivo_alteracao_qtd_op ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , motivo_alteracao_qtd_op_MotivoAlteracaoQtdOp.mao_motivo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(motivo_alteracao_qtd_op_MotivoAlteracaoQtdOp.mao_motivo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_diferenca.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_diferenca.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , ordem_producao_diferenca.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_diferenca.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           whereClause += " OR UPPER(ordem_producao_diferenca.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_diferenca.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_ordem_producao_diferenca")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_diferenca.id_ordem_producao_diferenca IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_diferenca.id_ordem_producao_diferenca = :ordem_producao_diferenca_ID_3598 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_diferenca_ID_3598", NpgsqlDbType.Bigint, parametro.Fieldvalue));
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
                         whereClause += "  ordem_producao_diferenca.id_ordem_producao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_diferenca.id_ordem_producao = :ordem_producao_diferenca_OrdemProducao_8210 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_diferenca_OrdemProducao_8210", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrdemProducaoPostoTrabalho" || parametro.FieldName == "id_ordem_producao_posto_trabalho")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.OrdemProducaoPostoTrabalhoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.OrdemProducaoPostoTrabalhoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_diferenca.id_ordem_producao_posto_trabalho IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_diferenca.id_ordem_producao_posto_trabalho = :ordem_producao_diferenca_OrdemProducaoPostoTrabalho_8505 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_diferenca_OrdemProducaoPostoTrabalho_8505", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcsUsuario" || parametro.FieldName == "id_acs_usuario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_diferenca.id_acs_usuario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_diferenca.id_acs_usuario = :ordem_producao_diferenca_AcsUsuario_897 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_diferenca_AcsUsuario_897", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Repor" || parametro.FieldName == "opd_repor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_diferenca.opd_repor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_diferenca.opd_repor = :ordem_producao_diferenca_Repor_6804 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_diferenca_Repor_6804", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Reposto" || parametro.FieldName == "opd_reposto")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_diferenca.opd_reposto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_diferenca.opd_reposto = :ordem_producao_diferenca_Reposto_7724 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_diferenca_Reposto_7724", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Quantidade" || parametro.FieldName == "opd_quantidade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_diferenca.opd_quantidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_diferenca.opd_quantidade = :ordem_producao_diferenca_Quantidade_3565 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_diferenca_Quantidade_3565", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Destino" || parametro.FieldName == "opd_destino")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DestinoDiferencaOP?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DestinoDiferencaOP?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_diferenca.opd_destino IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_diferenca.opd_destino = :ordem_producao_diferenca_Destino_238 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_diferenca_Destino_238", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Estoque" || parametro.FieldName == "id_estoque")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.EstoqueClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.EstoqueClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_diferenca.id_estoque IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_diferenca.id_estoque = :ordem_producao_diferenca_Estoque_491 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_diferenca_Estoque_491", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MotivoAlteracaoQtdOp" || parametro.FieldName == "id_motivo_alteracao_qtd_op")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.MotivoAlteracaoQtdOpClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.MotivoAlteracaoQtdOpClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_diferenca.id_motivo_alteracao_qtd_op IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_diferenca.id_motivo_alteracao_qtd_op = :ordem_producao_diferenca_MotivoAlteracaoQtdOp_1298 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_diferenca_MotivoAlteracaoQtdOp_1298", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  ordem_producao_diferenca.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_diferenca.entity_uid LIKE :ordem_producao_diferenca_EntityUid_7715 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_diferenca_EntityUid_7715", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  ordem_producao_diferenca.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_diferenca.version = :ordem_producao_diferenca_Version_1737 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_diferenca_Version_1737", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  ordem_producao_diferenca.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_diferenca.entity_uid LIKE :ordem_producao_diferenca_EntityUid_211 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_diferenca_EntityUid_211", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  OrdemProducaoDiferencaClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (OrdemProducaoDiferencaClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(OrdemProducaoDiferencaClass), Convert.ToInt32(read["id_ordem_producao_diferenca"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new OrdemProducaoDiferencaClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_ordem_producao_diferenca"]);
                     if (read["id_ordem_producao"] != DBNull.Value)
                     {
                        entidade.OrdemProducao = (BibliotecaEntidades.Entidades.OrdemProducaoClass)BibliotecaEntidades.Entidades.OrdemProducaoClass.GetEntidade(Convert.ToInt32(read["id_ordem_producao"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.OrdemProducao = null ;
                     }
                     if (read["id_ordem_producao_posto_trabalho"] != DBNull.Value)
                     {
                        entidade.OrdemProducaoPostoTrabalho = (BibliotecaEntidades.Entidades.OrdemProducaoPostoTrabalhoClass)BibliotecaEntidades.Entidades.OrdemProducaoPostoTrabalhoClass.GetEntidade(Convert.ToInt32(read["id_ordem_producao_posto_trabalho"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.OrdemProducaoPostoTrabalho = null ;
                     }
                     if (read["id_acs_usuario"] != DBNull.Value)
                     {
                        entidade.AcsUsuario = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuario = null ;
                     }
                     entidade.Repor = (read["opd_repor"] != DBNull.Value ? (bool?)Convert.ToBoolean(Convert.ToInt16(read["opd_repor"])) : null);
                     entidade.Reposto = (read["opd_reposto"] != DBNull.Value ? (bool?)Convert.ToBoolean(Convert.ToInt16(read["opd_reposto"])) : null);
                     entidade.Quantidade = (double)read["opd_quantidade"];
                     entidade.Destino = (DestinoDiferencaOP?) (read["opd_destino"] != DBNull.Value ? Enum.ToObject(Nullable.GetUnderlyingType(typeof(DestinoDiferencaOP?)), read["opd_destino"]) : null);
                     if (read["id_estoque"] != DBNull.Value)
                     {
                        entidade.Estoque = (BibliotecaEntidades.Entidades.EstoqueClass)BibliotecaEntidades.Entidades.EstoqueClass.GetEntidade(Convert.ToInt32(read["id_estoque"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Estoque = null ;
                     }
                     if (read["id_motivo_alteracao_qtd_op"] != DBNull.Value)
                     {
                        entidade.MotivoAlteracaoQtdOp = (BibliotecaEntidades.Entidades.MotivoAlteracaoQtdOpClass)BibliotecaEntidades.Entidades.MotivoAlteracaoQtdOpClass.GetEntidade(Convert.ToInt32(read["id_motivo_alteracao_qtd_op"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.MotivoAlteracaoQtdOp = null ;
                     }
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (OrdemProducaoDiferencaClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
