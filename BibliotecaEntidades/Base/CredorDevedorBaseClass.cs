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
     [Table("credor_devedor","cre")]
     public class CredorDevedorBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do CredorDevedorClass";
protected const string ErroDelete = "Erro ao excluir o CredorDevedorClass  ";
protected const string ErroSave = "Erro ao salvar o CredorDevedorClass.";
protected const string ErroNomeObrigatorio = "O campo Nome é obrigatório";
protected const string ErroNomeComprimento = "O campo Nome deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do CredorDevedorClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade CredorDevedorClass está sendo utilizada.";
#endregion
       protected string _tipoCredorDevedorOriginal{get;private set;}
       private string _tipoCredorDevedorOriginalCommited{get; set;}
        private string _valueTipoCredorDevedor;
         [Column("cre_tipo_credor_devedor")]
        public virtual string TipoCredorDevedor
         { 
            get { return this._valueTipoCredorDevedor; } 
            set 
            { 
                if (this._valueTipoCredorDevedor == value)return;
                 this._valueTipoCredorDevedor = value; 
            } 
        } 

       protected string _nomeOriginal{get;private set;}
       private string _nomeOriginalCommited{get; set;}
        private string _valueNome;
         [Column("crd_nome")]
        public virtual string Nome
         { 
            get { return this._valueNome; } 
            set 
            { 
                if (this._valueNome == value)return;
                 this._valueNome = value; 
            } 
        } 

       protected bool _ativoOriginal{get;private set;}
       private bool _ativoOriginalCommited{get; set;}
        private bool _valueAtivo;
         [Column("crd_ativo")]
        public virtual bool Ativo
         { 
            get { return this._valueAtivo; } 
            set 
            { 
                if (this._valueAtivo == value)return;
                 this._valueAtivo = value; 
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

       protected BibliotecaEntidades.Entidades.FuncionarioClass _funcionarioOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.FuncionarioClass _funcionarioOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.FuncionarioClass _valueFuncionario;
        [Column("id_funcionario", "funcionario", "id_funcionario")]
       public virtual BibliotecaEntidades.Entidades.FuncionarioClass Funcionario
        { 
           get {                 return this._valueFuncionario; } 
           set 
           { 
                if (this._valueFuncionario == value)return;
                 this._valueFuncionario = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.VendedorClass _vendedorOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.VendedorClass _vendedorOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.VendedorClass _valueVendedor;
        [Column("id_vendedor", "vendedor", "id_vendedor")]
       public virtual BibliotecaEntidades.Entidades.VendedorClass Vendedor
        { 
           get {                 return this._valueVendedor; } 
           set 
           { 
                if (this._valueVendedor == value)return;
                 this._valueVendedor = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.ClienteClass _clienteOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.ClienteClass _clienteOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.ClienteClass _valueCliente;
        [Column("id_cliente", "cliente", "id_cliente")]
       public virtual BibliotecaEntidades.Entidades.ClienteClass Cliente
        { 
           get {                 return this._valueCliente; } 
           set 
           { 
                if (this._valueCliente == value)return;
                 this._valueCliente = value; 
           } 
       } 

       protected string _cnpjOriginal{get;private set;}
       private string _cnpjOriginalCommited{get; set;}
        private string _valueCnpj;
         [Column("crd_cnpj")]
        public virtual string Cnpj
         { 
            get { return this._valueCnpj; } 
            set 
            { 
                if (this._valueCnpj == value)return;
                 this._valueCnpj = value; 
            } 
        } 

        public CredorDevedorBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Ativo = true;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static CredorDevedorClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (CredorDevedorClass) GetEntity(typeof(CredorDevedorClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Nome))
                {
                    throw new Exception(ErroNomeObrigatorio);
                }
                if (Nome.Length >255)
                {
                    throw new Exception( ErroNomeComprimento);
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
                    "  public.credor_devedor  " +
                    "WHERE " +
                    "  id_credor_devedor = :id";
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
                        "  public.credor_devedor   " +
                        "SET  " + 
                        "  cre_tipo_credor_devedor = CAST (:cre_tipo_credor_devedor AS tipo_credor_devedor) , " + 
                        "  crd_nome = :crd_nome, " + 
                        "  version = :version, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  crd_ativo = :crd_ativo, " + 
                        "  id_fornecedor = :id_fornecedor, " + 
                        "  id_funcionario = :id_funcionario, " + 
                        "  id_vendedor = :id_vendedor, " + 
                        "  id_cliente = :id_cliente, " + 
                        "  crd_cnpj = :crd_cnpj "+
                        "WHERE  " +
                        "  id_credor_devedor = :id " +
                        "RETURNING id_credor_devedor;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.credor_devedor " +
                        "( " +
                        "  cre_tipo_credor_devedor , " + 
                        "  crd_nome , " + 
                        "  version , " + 
                        "  entity_uid , " + 
                        "  crd_ativo , " + 
                        "  id_fornecedor , " + 
                        "  id_funcionario , " + 
                        "  id_vendedor , " + 
                        "  id_cliente , " + 
                        "  crd_cnpj  "+
                        ")  " +
                        "VALUES ( " +
                        " CAST (:cre_tipo_credor_devedor AS tipo_credor_devedor) , " + 
                        "  :crd_nome , " + 
                        "  :version , " + 
                        "  :entity_uid , " + 
                        "  :crd_ativo , " + 
                        "  :id_fornecedor , " + 
                        "  :id_funcionario , " + 
                        "  :id_vendedor , " + 
                        "  :id_cliente , " + 
                        "  :crd_cnpj  "+
                        ")RETURNING id_credor_devedor;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cre_tipo_credor_devedor", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.TipoCredorDevedor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("crd_nome", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Nome ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("crd_ativo", NpgsqlDbType.Boolean));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Ativo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_fornecedor", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Fornecedor==null ? (object) DBNull.Value : this.Fornecedor.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_funcionario", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Funcionario==null ? (object) DBNull.Value : this.Funcionario.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_vendedor", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Vendedor==null ? (object) DBNull.Value : this.Vendedor.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_cliente", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Cliente==null ? (object) DBNull.Value : this.Cliente.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("crd_cnpj", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Cnpj ?? DBNull.Value;

 
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
        public static CredorDevedorClass CopiarEntidade(CredorDevedorClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               CredorDevedorClass toRet = new CredorDevedorClass(usuario,conn);
 toRet.TipoCredorDevedor= entidadeCopiar.TipoCredorDevedor;
 toRet.Nome= entidadeCopiar.Nome;
 toRet.Ativo= entidadeCopiar.Ativo;
 toRet.Fornecedor= entidadeCopiar.Fornecedor;
 toRet.Funcionario= entidadeCopiar.Funcionario;
 toRet.Vendedor= entidadeCopiar.Vendedor;
 toRet.Cliente= entidadeCopiar.Cliente;
 toRet.Cnpj= entidadeCopiar.Cnpj;

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
       _tipoCredorDevedorOriginal = TipoCredorDevedor;
       _tipoCredorDevedorOriginalCommited = _tipoCredorDevedorOriginal;
       _nomeOriginal = Nome;
       _nomeOriginalCommited = _nomeOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _ativoOriginal = Ativo;
       _ativoOriginalCommited = _ativoOriginal;
       _fornecedorOriginal = Fornecedor;
       _fornecedorOriginalCommited = _fornecedorOriginal;
       _funcionarioOriginal = Funcionario;
       _funcionarioOriginalCommited = _funcionarioOriginal;
       _vendedorOriginal = Vendedor;
       _vendedorOriginalCommited = _vendedorOriginal;
       _clienteOriginal = Cliente;
       _clienteOriginalCommited = _clienteOriginal;
       _cnpjOriginal = Cnpj;
       _cnpjOriginalCommited = _cnpjOriginal;

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
       _tipoCredorDevedorOriginalCommited = TipoCredorDevedor;
       _nomeOriginalCommited = Nome;
       _versionOriginalCommited = Version;
       _ativoOriginalCommited = Ativo;
       _fornecedorOriginalCommited = Fornecedor;
       _funcionarioOriginalCommited = Funcionario;
       _vendedorOriginalCommited = Vendedor;
       _clienteOriginalCommited = Cliente;
       _cnpjOriginalCommited = Cnpj;

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
               TipoCredorDevedor=_tipoCredorDevedorOriginal;
               _tipoCredorDevedorOriginalCommited=_tipoCredorDevedorOriginal;
               Nome=_nomeOriginal;
               _nomeOriginalCommited=_nomeOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               Ativo=_ativoOriginal;
               _ativoOriginalCommited=_ativoOriginal;
               Fornecedor=_fornecedorOriginal;
               _fornecedorOriginalCommited=_fornecedorOriginal;
               Funcionario=_funcionarioOriginal;
               _funcionarioOriginalCommited=_funcionarioOriginal;
               Vendedor=_vendedorOriginal;
               _vendedorOriginalCommited=_vendedorOriginal;
               Cliente=_clienteOriginal;
               _clienteOriginalCommited=_clienteOriginal;
               Cnpj=_cnpjOriginal;
               _cnpjOriginalCommited=_cnpjOriginal;

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
       dirty = _tipoCredorDevedorOriginal != TipoCredorDevedor;
      if (dirty) return true;
       dirty = _nomeOriginal != Nome;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
      if (dirty) return true;
       dirty = _ativoOriginal != Ativo;
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
       if (_funcionarioOriginal!=null)
       {
          dirty = !_funcionarioOriginal.Equals(Funcionario);
       }
       else
       {
            dirty = Funcionario != null;
       }
      if (dirty) return true;
       if (_vendedorOriginal!=null)
       {
          dirty = !_vendedorOriginal.Equals(Vendedor);
       }
       else
       {
            dirty = Vendedor != null;
       }
      if (dirty) return true;
       if (_clienteOriginal!=null)
       {
          dirty = !_clienteOriginal.Equals(Cliente);
       }
       else
       {
            dirty = Cliente != null;
       }
      if (dirty) return true;
       dirty = _cnpjOriginal != Cnpj;

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
       dirty = _tipoCredorDevedorOriginalCommited != TipoCredorDevedor;
      if (dirty) return true;
       dirty = _nomeOriginalCommited != Nome;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
      if (dirty) return true;
       dirty = _ativoOriginalCommited != Ativo;
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
       if (_funcionarioOriginalCommited!=null)
       {
          dirty = !_funcionarioOriginalCommited.Equals(Funcionario);
       }
       else
       {
            dirty = Funcionario != null;
       }
      if (dirty) return true;
       if (_vendedorOriginalCommited!=null)
       {
          dirty = !_vendedorOriginalCommited.Equals(Vendedor);
       }
       else
       {
            dirty = Vendedor != null;
       }
      if (dirty) return true;
       if (_clienteOriginalCommited!=null)
       {
          dirty = !_clienteOriginalCommited.Equals(Cliente);
       }
       else
       {
            dirty = Cliente != null;
       }
      if (dirty) return true;
       dirty = _cnpjOriginalCommited != Cnpj;

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
             case "TipoCredorDevedor":
                return this.TipoCredorDevedor;
             case "Nome":
                return this.Nome;
             case "Version":
                return this.Version;
             case "EntityUid":
                return this.EntityUid;
             case "Ativo":
                return this.Ativo;
             case "Fornecedor":
                return this.Fornecedor;
             case "Funcionario":
                return this.Funcionario;
             case "Vendedor":
                return this.Vendedor;
             case "Cliente":
                return this.Cliente;
             case "Cnpj":
                return this.Cnpj;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (Fornecedor!=null)
                Fornecedor.ChangeSingleConnection(newConnection);
             if (Funcionario!=null)
                Funcionario.ChangeSingleConnection(newConnection);
             if (Vendedor!=null)
                Vendedor.ChangeSingleConnection(newConnection);
             if (Cliente!=null)
                Cliente.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(credor_devedor.id_credor_devedor) " ;
               }
               else
               {
               command.CommandText += "credor_devedor.id_credor_devedor, " ;
               command.CommandText += "credor_devedor.cre_tipo_credor_devedor, " ;
               command.CommandText += "credor_devedor.crd_nome, " ;
               command.CommandText += "credor_devedor.version, " ;
               command.CommandText += "credor_devedor.entity_uid, " ;
               command.CommandText += "credor_devedor.crd_ativo, " ;
               command.CommandText += "credor_devedor.id_fornecedor, " ;
               command.CommandText += "credor_devedor.id_funcionario, " ;
               command.CommandText += "credor_devedor.id_vendedor, " ;
               command.CommandText += "credor_devedor.id_cliente, " ;
               command.CommandText += "credor_devedor.crd_cnpj " ;
               }
               command.CommandText += " FROM  credor_devedor ";
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
                        orderByClause += " , cre_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(cre_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = credor_devedor.id_acs_usuario_ultima_revisao ";
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
                     case "id_credor_devedor":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , credor_devedor.id_credor_devedor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(credor_devedor.id_credor_devedor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cre_tipo_credor_devedor":
                     case "TipoCredorDevedor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , credor_devedor.cre_tipo_credor_devedor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(credor_devedor.cre_tipo_credor_devedor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "crd_nome":
                     case "Nome":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , credor_devedor.crd_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(credor_devedor.crd_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , credor_devedor.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(credor_devedor.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , credor_devedor.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(credor_devedor.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "crd_ativo":
                     case "Ativo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , credor_devedor.crd_ativo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(credor_devedor.crd_ativo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_fornecedor":
                     case "Fornecedor":
                     command.CommandText += " LEFT JOIN fornecedor as fornecedor_Fornecedor ON fornecedor_Fornecedor.id_fornecedor = credor_devedor.id_fornecedor ";                     switch (parametro.TipoOrdenacao)
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
                     case "id_funcionario":
                     case "Funcionario":
                     command.CommandText += " LEFT JOIN funcionario as funcionario_Funcionario ON funcionario_Funcionario.id_funcionario = credor_devedor.id_funcionario ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , funcionario_Funcionario.fuc_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(funcionario_Funcionario.fuc_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_vendedor":
                     case "Vendedor":
                     command.CommandText += " LEFT JOIN vendedor as vendedor_Vendedor ON vendedor_Vendedor.id_vendedor = credor_devedor.id_vendedor ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , vendedor_Vendedor.ven_razao_social " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(vendedor_Vendedor.ven_razao_social) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_cliente":
                     case "Cliente":
                     command.CommandText += " LEFT JOIN cliente as cliente_Cliente ON cliente_Cliente.id_cliente = credor_devedor.id_cliente ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cliente_Cliente.cli_nome_resumido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cliente_Cliente.cli_nome_resumido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "crd_cnpj":
                     case "Cnpj":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , credor_devedor.crd_cnpj " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(credor_devedor.crd_cnpj) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("crd_nome")) 
                        {
                           whereClause += " OR UPPER(credor_devedor.crd_nome) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(credor_devedor.crd_nome) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(credor_devedor.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(credor_devedor.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("crd_cnpj")) 
                        {
                           whereClause += " OR UPPER(credor_devedor.crd_cnpj) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(credor_devedor.crd_cnpj) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_credor_devedor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  credor_devedor.id_credor_devedor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  credor_devedor.id_credor_devedor = :credor_devedor_ID_5843 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("credor_devedor_ID_5843", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoCredorDevedor" || parametro.FieldName == "cre_tipo_credor_devedor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  credor_devedor.cre_tipo_credor_devedor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  credor_devedor.cre_tipo_credor_devedor = :credor_devedor_TipoCredorDevedor_6174 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("credor_devedor_TipoCredorDevedor_6174", NpgsqlDbType.Enum,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Nome" || parametro.FieldName == "crd_nome")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  credor_devedor.crd_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  credor_devedor.crd_nome LIKE :credor_devedor_Nome_8532 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("credor_devedor_Nome_8532", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  credor_devedor.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  credor_devedor.version = :credor_devedor_Version_4322 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("credor_devedor_Version_4322", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  credor_devedor.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  credor_devedor.entity_uid LIKE :credor_devedor_EntityUid_9603 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("credor_devedor_EntityUid_9603", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Ativo" || parametro.FieldName == "crd_ativo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  credor_devedor.crd_ativo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  credor_devedor.crd_ativo = :credor_devedor_Ativo_935 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("credor_devedor_Ativo_935", NpgsqlDbType.Boolean, parametro.Fieldvalue));
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
                         whereClause += "  credor_devedor.id_fornecedor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  credor_devedor.id_fornecedor = :credor_devedor_Fornecedor_8016 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("credor_devedor_Fornecedor_8016", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Funcionario" || parametro.FieldName == "id_funcionario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.FuncionarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.FuncionarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  credor_devedor.id_funcionario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  credor_devedor.id_funcionario = :credor_devedor_Funcionario_7060 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("credor_devedor_Funcionario_7060", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Vendedor" || parametro.FieldName == "id_vendedor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.VendedorClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.VendedorClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  credor_devedor.id_vendedor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  credor_devedor.id_vendedor = :credor_devedor_Vendedor_7132 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("credor_devedor_Vendedor_7132", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cliente" || parametro.FieldName == "id_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.ClienteClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.ClienteClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  credor_devedor.id_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  credor_devedor.id_cliente = :credor_devedor_Cliente_2264 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("credor_devedor_Cliente_2264", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cnpj" || parametro.FieldName == "crd_cnpj")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  credor_devedor.crd_cnpj IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  credor_devedor.crd_cnpj LIKE :credor_devedor_Cnpj_7530 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("credor_devedor_Cnpj_7530", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomeExato" || parametro.FieldName == "NomeExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  credor_devedor.crd_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  credor_devedor.crd_nome LIKE :credor_devedor_Nome_2287 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("credor_devedor_Nome_2287", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  credor_devedor.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  credor_devedor.entity_uid LIKE :credor_devedor_EntityUid_5140 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("credor_devedor_EntityUid_5140", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CnpjExato" || parametro.FieldName == "CnpjExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  credor_devedor.crd_cnpj IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  credor_devedor.crd_cnpj LIKE :credor_devedor_Cnpj_5710 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("credor_devedor_Cnpj_5710", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  CredorDevedorClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (CredorDevedorClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(CredorDevedorClass), Convert.ToInt32(read["id_credor_devedor"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new CredorDevedorClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_credor_devedor"]);
                     entidade.TipoCredorDevedor = (read["cre_tipo_credor_devedor"] != DBNull.Value ? read["cre_tipo_credor_devedor"].ToString() : null);
                     entidade.Nome = (read["crd_nome"] != DBNull.Value ? read["crd_nome"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Ativo = Convert.ToBoolean(read["crd_ativo"]);
                     if (read["id_fornecedor"] != DBNull.Value)
                     {
                        entidade.Fornecedor = (BibliotecaEntidades.Entidades.FornecedorClass)BibliotecaEntidades.Entidades.FornecedorClass.GetEntidade(Convert.ToInt32(read["id_fornecedor"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Fornecedor = null ;
                     }
                     if (read["id_funcionario"] != DBNull.Value)
                     {
                        entidade.Funcionario = (BibliotecaEntidades.Entidades.FuncionarioClass)BibliotecaEntidades.Entidades.FuncionarioClass.GetEntidade(Convert.ToInt32(read["id_funcionario"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Funcionario = null ;
                     }
                     if (read["id_vendedor"] != DBNull.Value)
                     {
                        entidade.Vendedor = (BibliotecaEntidades.Entidades.VendedorClass)BibliotecaEntidades.Entidades.VendedorClass.GetEntidade(Convert.ToInt32(read["id_vendedor"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Vendedor = null ;
                     }
                     if (read["id_cliente"] != DBNull.Value)
                     {
                        entidade.Cliente = (BibliotecaEntidades.Entidades.ClienteClass)BibliotecaEntidades.Entidades.ClienteClass.GetEntidade(Convert.ToInt32(read["id_cliente"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Cliente = null ;
                     }
                     entidade.Cnpj = (read["crd_cnpj"] != DBNull.Value ? read["crd_cnpj"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (CredorDevedorClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
