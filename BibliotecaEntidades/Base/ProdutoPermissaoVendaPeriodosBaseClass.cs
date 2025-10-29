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
     [Table("produto_permissao_venda_periodos","pvp")]
     public class ProdutoPermissaoVendaPeriodosBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do ProdutoPermissaoVendaPeriodosClass";
protected const string ErroDelete = "Erro ao excluir o ProdutoPermissaoVendaPeriodosClass  ";
protected const string ErroSave = "Erro ao salvar o ProdutoPermissaoVendaPeriodosClass.";
protected const string ErroInicioJustificativaObrigatorio = "O campo InicioJustificativa é obrigatório";
protected const string ErroInicioJustificativaComprimento = "O campo InicioJustificativa deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroProdutoObrigatorio = "O campo Produto é obrigatório";
protected const string ErroAcsUsuarioInicioObrigatorio = "O campo AcsUsuarioInicio é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do ProdutoPermissaoVendaPeriodosClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade ProdutoPermissaoVendaPeriodosClass está sendo utilizada.";
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

       protected IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioInicioOriginal{get;private set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioInicioOriginalCommited {get; set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _valueAcsUsuarioInicio;
        [Column("id_acs_usuario_inicio", "acs_usuario", "id_acs_usuario")]
       public virtual IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass AcsUsuarioInicio
        { 
           get {                 return this._valueAcsUsuarioInicio; } 
           set 
           { 
                if (this._valueAcsUsuarioInicio == value)return;
                 this._valueAcsUsuarioInicio = value; 
           } 
       } 

       protected DateTime _inicioOriginal{get;private set;}
       private DateTime _inicioOriginalCommited{get; set;}
        private DateTime _valueInicio;
         [Column("pvp_inicio")]
        public virtual DateTime Inicio
         { 
            get { return this._valueInicio; } 
            set 
            { 
                if (this._valueInicio == value)return;
                 this._valueInicio = value; 
            } 
        } 

       protected string _inicioJustificativaOriginal{get;private set;}
       private string _inicioJustificativaOriginalCommited{get; set;}
        private string _valueInicioJustificativa;
         [Column("pvp_inicio_justificativa")]
        public virtual string InicioJustificativa
         { 
            get { return this._valueInicioJustificativa; } 
            set 
            { 
                if (this._valueInicioJustificativa == value)return;
                 this._valueInicioJustificativa = value; 
            } 
        } 

       protected IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioTerminoOriginal{get;private set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioTerminoOriginalCommited {get; set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _valueAcsUsuarioTermino;
        [Column("id_acs_usuario_termino", "acs_usuario", "id_acs_usuario")]
       public virtual IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass AcsUsuarioTermino
        { 
           get {                 return this._valueAcsUsuarioTermino; } 
           set 
           { 
                if (this._valueAcsUsuarioTermino == value)return;
                 this._valueAcsUsuarioTermino = value; 
           } 
       } 

       protected DateTime? _terminoOriginal{get;private set;}
       private DateTime? _terminoOriginalCommited{get; set;}
        private DateTime? _valueTermino;
         [Column("pvp_termino")]
        public virtual DateTime? Termino
         { 
            get { return this._valueTermino; } 
            set 
            { 
                if (this._valueTermino == value)return;
                 this._valueTermino = value; 
            } 
        } 

       protected string _terminoJustificativaOriginal{get;private set;}
       private string _terminoJustificativaOriginalCommited{get; set;}
        private string _valueTerminoJustificativa;
         [Column("pvp_termino_justificativa")]
        public virtual string TerminoJustificativa
         { 
            get { return this._valueTerminoJustificativa; } 
            set 
            { 
                if (this._valueTerminoJustificativa == value)return;
                 this._valueTerminoJustificativa = value; 
            } 
        } 

        public ProdutoPermissaoVendaPeriodosBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static ProdutoPermissaoVendaPeriodosClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (ProdutoPermissaoVendaPeriodosClass) GetEntity(typeof(ProdutoPermissaoVendaPeriodosClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(InicioJustificativa))
                {
                    throw new Exception(ErroInicioJustificativaObrigatorio);
                }
                if (InicioJustificativa.Length >255)
                {
                    throw new Exception( ErroInicioJustificativaComprimento);
                }
                if ( _valueProduto == null)
                {
                    throw new Exception(ErroProdutoObrigatorio);
                }
                if ( _valueAcsUsuarioInicio == null)
                {
                    throw new Exception(ErroAcsUsuarioInicioObrigatorio);
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
                    "  public.produto_permissao_venda_periodos  " +
                    "WHERE " +
                    "  id_produto_permissao_venda_periodos = :id";
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
                        "  public.produto_permissao_venda_periodos   " +
                        "SET  " + 
                        "  id_produto = :id_produto, " + 
                        "  id_acs_usuario_inicio = :id_acs_usuario_inicio, " + 
                        "  pvp_inicio = :pvp_inicio, " + 
                        "  pvp_inicio_justificativa = :pvp_inicio_justificativa, " + 
                        "  id_acs_usuario_termino = :id_acs_usuario_termino, " + 
                        "  pvp_termino = :pvp_termino, " + 
                        "  pvp_termino_justificativa = :pvp_termino_justificativa, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_produto_permissao_venda_periodos = :id " +
                        "RETURNING id_produto_permissao_venda_periodos;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.produto_permissao_venda_periodos " +
                        "( " +
                        "  id_produto , " + 
                        "  id_acs_usuario_inicio , " + 
                        "  pvp_inicio , " + 
                        "  pvp_inicio_justificativa , " + 
                        "  id_acs_usuario_termino , " + 
                        "  pvp_termino , " + 
                        "  pvp_termino_justificativa , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_produto , " + 
                        "  :id_acs_usuario_inicio , " + 
                        "  :pvp_inicio , " + 
                        "  :pvp_inicio_justificativa , " + 
                        "  :id_acs_usuario_termino , " + 
                        "  :pvp_termino , " + 
                        "  :pvp_termino_justificativa , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_produto_permissao_venda_periodos;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Produto==null ? (object) DBNull.Value : this.Produto.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_inicio", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuarioInicio==null ? (object) DBNull.Value : this.AcsUsuarioInicio.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pvp_inicio", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Inicio ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pvp_inicio_justificativa", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.InicioJustificativa ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_termino", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuarioTermino==null ? (object) DBNull.Value : this.AcsUsuarioTermino.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pvp_termino", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Termino ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pvp_termino_justificativa", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.TerminoJustificativa ?? DBNull.Value;
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
        public static ProdutoPermissaoVendaPeriodosClass CopiarEntidade(ProdutoPermissaoVendaPeriodosClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               ProdutoPermissaoVendaPeriodosClass toRet = new ProdutoPermissaoVendaPeriodosClass(usuario,conn);
 toRet.Produto= entidadeCopiar.Produto;
 toRet.AcsUsuarioInicio= entidadeCopiar.AcsUsuarioInicio;
 toRet.Inicio= entidadeCopiar.Inicio;
 toRet.InicioJustificativa= entidadeCopiar.InicioJustificativa;
 toRet.AcsUsuarioTermino= entidadeCopiar.AcsUsuarioTermino;
 toRet.Termino= entidadeCopiar.Termino;
 toRet.TerminoJustificativa= entidadeCopiar.TerminoJustificativa;

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
       _acsUsuarioInicioOriginal = AcsUsuarioInicio;
       _acsUsuarioInicioOriginalCommited = _acsUsuarioInicioOriginal;
       _inicioOriginal = Inicio;
       _inicioOriginalCommited = _inicioOriginal;
       _inicioJustificativaOriginal = InicioJustificativa;
       _inicioJustificativaOriginalCommited = _inicioJustificativaOriginal;
       _acsUsuarioTerminoOriginal = AcsUsuarioTermino;
       _acsUsuarioTerminoOriginalCommited = _acsUsuarioTerminoOriginal;
       _terminoOriginal = Termino;
       _terminoOriginalCommited = _terminoOriginal;
       _terminoJustificativaOriginal = TerminoJustificativa;
       _terminoJustificativaOriginalCommited = _terminoJustificativaOriginal;
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
       _acsUsuarioInicioOriginalCommited = AcsUsuarioInicio;
       _inicioOriginalCommited = Inicio;
       _inicioJustificativaOriginalCommited = InicioJustificativa;
       _acsUsuarioTerminoOriginalCommited = AcsUsuarioTermino;
       _terminoOriginalCommited = Termino;
       _terminoJustificativaOriginalCommited = TerminoJustificativa;
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
               AcsUsuarioInicio=_acsUsuarioInicioOriginal;
               _acsUsuarioInicioOriginalCommited=_acsUsuarioInicioOriginal;
               Inicio=_inicioOriginal;
               _inicioOriginalCommited=_inicioOriginal;
               InicioJustificativa=_inicioJustificativaOriginal;
               _inicioJustificativaOriginalCommited=_inicioJustificativaOriginal;
               AcsUsuarioTermino=_acsUsuarioTerminoOriginal;
               _acsUsuarioTerminoOriginalCommited=_acsUsuarioTerminoOriginal;
               Termino=_terminoOriginal;
               _terminoOriginalCommited=_terminoOriginal;
               TerminoJustificativa=_terminoJustificativaOriginal;
               _terminoJustificativaOriginalCommited=_terminoJustificativaOriginal;
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
       if (_acsUsuarioInicioOriginal!=null)
       {
          dirty = !_acsUsuarioInicioOriginal.Equals(AcsUsuarioInicio);
       }
       else
       {
            dirty = AcsUsuarioInicio != null;
       }
      if (dirty) return true;
       dirty = _inicioOriginal != Inicio;
      if (dirty) return true;
       dirty = _inicioJustificativaOriginal != InicioJustificativa;
      if (dirty) return true;
       if (_acsUsuarioTerminoOriginal!=null)
       {
          dirty = !_acsUsuarioTerminoOriginal.Equals(AcsUsuarioTermino);
       }
       else
       {
            dirty = AcsUsuarioTermino != null;
       }
      if (dirty) return true;
       dirty = _terminoOriginal != Termino;
      if (dirty) return true;
       dirty = _terminoJustificativaOriginal != TerminoJustificativa;
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
       if (_produtoOriginalCommited!=null)
       {
          dirty = !_produtoOriginalCommited.Equals(Produto);
       }
       else
       {
            dirty = Produto != null;
       }
      if (dirty) return true;
       if (_acsUsuarioInicioOriginalCommited!=null)
       {
          dirty = !_acsUsuarioInicioOriginalCommited.Equals(AcsUsuarioInicio);
       }
       else
       {
            dirty = AcsUsuarioInicio != null;
       }
      if (dirty) return true;
       dirty = _inicioOriginalCommited != Inicio;
      if (dirty) return true;
       dirty = _inicioJustificativaOriginalCommited != InicioJustificativa;
      if (dirty) return true;
       if (_acsUsuarioTerminoOriginalCommited!=null)
       {
          dirty = !_acsUsuarioTerminoOriginalCommited.Equals(AcsUsuarioTermino);
       }
       else
       {
            dirty = AcsUsuarioTermino != null;
       }
      if (dirty) return true;
       dirty = _terminoOriginalCommited != Termino;
      if (dirty) return true;
       dirty = _terminoJustificativaOriginalCommited != TerminoJustificativa;
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
             case "Produto":
                return this.Produto;
             case "AcsUsuarioInicio":
                return this.AcsUsuarioInicio;
             case "Inicio":
                return this.Inicio;
             case "InicioJustificativa":
                return this.InicioJustificativa;
             case "AcsUsuarioTermino":
                return this.AcsUsuarioTermino;
             case "Termino":
                return this.Termino;
             case "TerminoJustificativa":
                return this.TerminoJustificativa;
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
             if (Produto!=null)
                Produto.ChangeSingleConnection(newConnection);
             if (AcsUsuarioInicio!=null)
                AcsUsuarioInicio.ChangeSingleConnection(newConnection);
             if (AcsUsuarioTermino!=null)
                AcsUsuarioTermino.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(produto_permissao_venda_periodos.id_produto_permissao_venda_periodos) " ;
               }
               else
               {
               command.CommandText += "produto_permissao_venda_periodos.id_produto_permissao_venda_periodos, " ;
               command.CommandText += "produto_permissao_venda_periodos.id_produto, " ;
               command.CommandText += "produto_permissao_venda_periodos.id_acs_usuario_inicio, " ;
               command.CommandText += "produto_permissao_venda_periodos.pvp_inicio, " ;
               command.CommandText += "produto_permissao_venda_periodos.pvp_inicio_justificativa, " ;
               command.CommandText += "produto_permissao_venda_periodos.id_acs_usuario_termino, " ;
               command.CommandText += "produto_permissao_venda_periodos.pvp_termino, " ;
               command.CommandText += "produto_permissao_venda_periodos.pvp_termino_justificativa, " ;
               command.CommandText += "produto_permissao_venda_periodos.entity_uid, " ;
               command.CommandText += "produto_permissao_venda_periodos.version " ;
               }
               command.CommandText += " FROM  produto_permissao_venda_periodos ";
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
                        orderByClause += " , pvp_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(pvp_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = produto_permissao_venda_periodos.id_acs_usuario_ultima_revisao ";
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
                     case "id_produto_permissao_venda_periodos":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_permissao_venda_periodos.id_produto_permissao_venda_periodos " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_permissao_venda_periodos.id_produto_permissao_venda_periodos) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_produto":
                     case "Produto":
                     command.CommandText += " LEFT JOIN produto as produto_Produto ON produto_Produto.id_produto = produto_permissao_venda_periodos.id_produto ";                     switch (parametro.TipoOrdenacao)
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
                     case "id_acs_usuario_inicio":
                     case "AcsUsuarioInicio":
                     orderByClause += " , produto_permissao_venda_periodos.id_acs_usuario_inicio " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "pvp_inicio":
                     case "Inicio":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_permissao_venda_periodos.pvp_inicio " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_permissao_venda_periodos.pvp_inicio) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pvp_inicio_justificativa":
                     case "InicioJustificativa":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_permissao_venda_periodos.pvp_inicio_justificativa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_permissao_venda_periodos.pvp_inicio_justificativa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_termino":
                     case "AcsUsuarioTermino":
                     orderByClause += " , produto_permissao_venda_periodos.id_acs_usuario_termino " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "pvp_termino":
                     case "Termino":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_permissao_venda_periodos.pvp_termino " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_permissao_venda_periodos.pvp_termino) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pvp_termino_justificativa":
                     case "TerminoJustificativa":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_permissao_venda_periodos.pvp_termino_justificativa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_permissao_venda_periodos.pvp_termino_justificativa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_permissao_venda_periodos.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_permissao_venda_periodos.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , produto_permissao_venda_periodos.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_permissao_venda_periodos.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pvp_inicio_justificativa")) 
                        {
                           whereClause += " OR UPPER(produto_permissao_venda_periodos.pvp_inicio_justificativa) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto_permissao_venda_periodos.pvp_inicio_justificativa) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pvp_termino_justificativa")) 
                        {
                           whereClause += " OR UPPER(produto_permissao_venda_periodos.pvp_termino_justificativa) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto_permissao_venda_periodos.pvp_termino_justificativa) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(produto_permissao_venda_periodos.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto_permissao_venda_periodos.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_produto_permissao_venda_periodos")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_permissao_venda_periodos.id_produto_permissao_venda_periodos IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_permissao_venda_periodos.id_produto_permissao_venda_periodos = :produto_permissao_venda_periodos_ID_555 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_permissao_venda_periodos_ID_555", NpgsqlDbType.Bigint, parametro.Fieldvalue));
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
                         whereClause += "  produto_permissao_venda_periodos.id_produto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_permissao_venda_periodos.id_produto = :produto_permissao_venda_periodos_Produto_9692 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_permissao_venda_periodos_Produto_9692", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcsUsuarioInicio" || parametro.FieldName == "id_acs_usuario_inicio")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_permissao_venda_periodos.id_acs_usuario_inicio IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_permissao_venda_periodos.id_acs_usuario_inicio = :produto_permissao_venda_periodos_AcsUsuarioInicio_4858 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_permissao_venda_periodos_AcsUsuarioInicio_4858", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Inicio" || parametro.FieldName == "pvp_inicio")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_permissao_venda_periodos.pvp_inicio IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_permissao_venda_periodos.pvp_inicio = :produto_permissao_venda_periodos_Inicio_3777 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_permissao_venda_periodos_Inicio_3777", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "InicioJustificativa" || parametro.FieldName == "pvp_inicio_justificativa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_permissao_venda_periodos.pvp_inicio_justificativa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_permissao_venda_periodos.pvp_inicio_justificativa LIKE :produto_permissao_venda_periodos_InicioJustificativa_4137 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_permissao_venda_periodos_InicioJustificativa_4137", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcsUsuarioTermino" || parametro.FieldName == "id_acs_usuario_termino")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_permissao_venda_periodos.id_acs_usuario_termino IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_permissao_venda_periodos.id_acs_usuario_termino = :produto_permissao_venda_periodos_AcsUsuarioTermino_8776 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_permissao_venda_periodos_AcsUsuarioTermino_8776", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Termino" || parametro.FieldName == "pvp_termino")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_permissao_venda_periodos.pvp_termino IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_permissao_venda_periodos.pvp_termino = :produto_permissao_venda_periodos_Termino_8615 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_permissao_venda_periodos_Termino_8615", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TerminoJustificativa" || parametro.FieldName == "pvp_termino_justificativa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_permissao_venda_periodos.pvp_termino_justificativa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_permissao_venda_periodos.pvp_termino_justificativa LIKE :produto_permissao_venda_periodos_TerminoJustificativa_3115 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_permissao_venda_periodos_TerminoJustificativa_3115", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  produto_permissao_venda_periodos.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_permissao_venda_periodos.entity_uid LIKE :produto_permissao_venda_periodos_EntityUid_6985 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_permissao_venda_periodos_EntityUid_6985", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  produto_permissao_venda_periodos.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_permissao_venda_periodos.version = :produto_permissao_venda_periodos_Version_9108 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_permissao_venda_periodos_Version_9108", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "InicioJustificativaExato" || parametro.FieldName == "InicioJustificativaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_permissao_venda_periodos.pvp_inicio_justificativa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_permissao_venda_periodos.pvp_inicio_justificativa LIKE :produto_permissao_venda_periodos_InicioJustificativa_7832 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_permissao_venda_periodos_InicioJustificativa_7832", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TerminoJustificativaExato" || parametro.FieldName == "TerminoJustificativaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_permissao_venda_periodos.pvp_termino_justificativa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_permissao_venda_periodos.pvp_termino_justificativa LIKE :produto_permissao_venda_periodos_TerminoJustificativa_5742 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_permissao_venda_periodos_TerminoJustificativa_5742", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  produto_permissao_venda_periodos.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_permissao_venda_periodos.entity_uid LIKE :produto_permissao_venda_periodos_EntityUid_1782 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_permissao_venda_periodos_EntityUid_1782", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  ProdutoPermissaoVendaPeriodosClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (ProdutoPermissaoVendaPeriodosClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(ProdutoPermissaoVendaPeriodosClass), Convert.ToInt32(read["id_produto_permissao_venda_periodos"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new ProdutoPermissaoVendaPeriodosClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_produto_permissao_venda_periodos"]);
                     if (read["id_produto"] != DBNull.Value)
                     {
                        entidade.Produto = (BibliotecaEntidades.Entidades.ProdutoClass)BibliotecaEntidades.Entidades.ProdutoClass.GetEntidade(Convert.ToInt32(read["id_produto"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Produto = null ;
                     }
                     if (read["id_acs_usuario_inicio"] != DBNull.Value)
                     {
                        entidade.AcsUsuarioInicio = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_inicio"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuarioInicio = null ;
                     }
                     entidade.Inicio = (DateTime)read["pvp_inicio"];
                     entidade.InicioJustificativa = (read["pvp_inicio_justificativa"] != DBNull.Value ? read["pvp_inicio_justificativa"].ToString() : null);
                     if (read["id_acs_usuario_termino"] != DBNull.Value)
                     {
                        entidade.AcsUsuarioTermino = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_termino"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuarioTermino = null ;
                     }
                     entidade.Termino = read["pvp_termino"] as DateTime?;
                     entidade.TerminoJustificativa = (read["pvp_termino_justificativa"] != DBNull.Value ? read["pvp_termino_justificativa"].ToString() : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (ProdutoPermissaoVendaPeriodosClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
