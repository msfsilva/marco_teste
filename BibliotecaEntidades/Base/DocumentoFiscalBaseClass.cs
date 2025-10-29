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
     [Table("documento_fiscal","dof")]
     public class DocumentoFiscalBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do DocumentoFiscalClass";
protected const string ErroDelete = "Erro ao excluir o DocumentoFiscalClass  ";
protected const string ErroSave = "Erro ao salvar o DocumentoFiscalClass.";
protected const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
protected const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroDocumentoFiscalTipoObrigatorio = "O campo DocumentoFiscalTipo é obrigatório";
protected const string ErroDocumentoFiscalDestinoObrigatorio = "O campo DocumentoFiscalDestino é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do DocumentoFiscalClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade DocumentoFiscalClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.DocumentoFiscalTipoClass _documentoFiscalTipoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.DocumentoFiscalTipoClass _documentoFiscalTipoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.DocumentoFiscalTipoClass _valueDocumentoFiscalTipo;
        [Column("id_documento_fiscal_tipo", "documento_fiscal_tipo", "id_documento_fiscal_tipo")]
       public virtual BibliotecaEntidades.Entidades.DocumentoFiscalTipoClass DocumentoFiscalTipo
        { 
           get {                 return this._valueDocumentoFiscalTipo; } 
           set 
           { 
                if (this._valueDocumentoFiscalTipo == value)return;
                 this._valueDocumentoFiscalTipo = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.DocumentoFiscalDestinoClass _documentoFiscalDestinoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.DocumentoFiscalDestinoClass _documentoFiscalDestinoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.DocumentoFiscalDestinoClass _valueDocumentoFiscalDestino;
        [Column("id_documento_fiscal_destino", "documento_fiscal_destino", "id_documento_fiscal_destino")]
       public virtual BibliotecaEntidades.Entidades.DocumentoFiscalDestinoClass DocumentoFiscalDestino
        { 
           get {                 return this._valueDocumentoFiscalDestino; } 
           set 
           { 
                if (this._valueDocumentoFiscalDestino == value)return;
                 this._valueDocumentoFiscalDestino = value; 
           } 
       } 

       protected IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioEnvioOriginal{get;private set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioEnvioOriginalCommited {get; set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _valueAcsUsuarioEnvio;
        [Column("id_acs_usuario_envio", "acs_usuario", "id_acs_usuario")]
       public virtual IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass AcsUsuarioEnvio
        { 
           get {                 return this._valueAcsUsuarioEnvio; } 
           set 
           { 
                if (this._valueAcsUsuarioEnvio == value)return;
                 this._valueAcsUsuarioEnvio = value; 
           } 
       } 

       protected string _identificacaoOriginal{get;private set;}
       private string _identificacaoOriginalCommited{get; set;}
        private string _valueIdentificacao;
         [Column("dof_identificacao")]
        public virtual string Identificacao
         { 
            get { return this._valueIdentificacao; } 
            set 
            { 
                if (this._valueIdentificacao == value)return;
                 this._valueIdentificacao = value; 
            } 
        } 

       protected string _descricaoOriginal{get;private set;}
       private string _descricaoOriginalCommited{get; set;}
        private string _valueDescricao;
         [Column("dof_descricao")]
        public virtual string Descricao
         { 
            get { return this._valueDescricao; } 
            set 
            { 
                if (this._valueDescricao == value)return;
                 this._valueDescricao = value; 
            } 
        } 

       protected string _observacaoOriginal{get;private set;}
       private string _observacaoOriginalCommited{get; set;}
        private string _valueObservacao;
         [Column("dof_observacao")]
        public virtual string Observacao
         { 
            get { return this._valueObservacao; } 
            set 
            { 
                if (this._valueObservacao == value)return;
                 this._valueObservacao = value; 
            } 
        } 

       protected DateTime? _dataEnvioOriginal{get;private set;}
       private DateTime? _dataEnvioOriginalCommited{get; set;}
        private DateTime? _valueDataEnvio;
         [Column("dof_data_envio")]
        public virtual DateTime? DataEnvio
         { 
            get { return this._valueDataEnvio; } 
            set 
            { 
                if (this._valueDataEnvio == value)return;
                 this._valueDataEnvio = value; 
            } 
        } 

        public DocumentoFiscalBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static DocumentoFiscalClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (DocumentoFiscalClass) GetEntity(typeof(DocumentoFiscalClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Identificacao))
                {
                    throw new Exception(ErroIdentificacaoObrigatorio);
                }
                if (Identificacao.Length >255)
                {
                    throw new Exception( ErroIdentificacaoComprimento);
                }
                if ( _valueDocumentoFiscalTipo == null)
                {
                    throw new Exception(ErroDocumentoFiscalTipoObrigatorio);
                }
                if ( _valueDocumentoFiscalDestino == null)
                {
                    throw new Exception(ErroDocumentoFiscalDestinoObrigatorio);
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
                    "  public.documento_fiscal  " +
                    "WHERE " +
                    "  id_documento_fiscal = :id";
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
                        "  public.documento_fiscal   " +
                        "SET  " + 
                        "  id_documento_fiscal_tipo = :id_documento_fiscal_tipo, " + 
                        "  id_documento_fiscal_destino = :id_documento_fiscal_destino, " + 
                        "  id_acs_usuario_envio = :id_acs_usuario_envio, " + 
                        "  dof_identificacao = :dof_identificacao, " + 
                        "  dof_descricao = :dof_descricao, " + 
                        "  dof_observacao = :dof_observacao, " + 
                        "  dof_data_envio = :dof_data_envio, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_documento_fiscal = :id " +
                        "RETURNING id_documento_fiscal;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.documento_fiscal " +
                        "( " +
                        "  id_documento_fiscal_tipo , " + 
                        "  id_documento_fiscal_destino , " + 
                        "  id_acs_usuario_envio , " + 
                        "  dof_identificacao , " + 
                        "  dof_descricao , " + 
                        "  dof_observacao , " + 
                        "  dof_data_envio , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_documento_fiscal_tipo , " + 
                        "  :id_documento_fiscal_destino , " + 
                        "  :id_acs_usuario_envio , " + 
                        "  :dof_identificacao , " + 
                        "  :dof_descricao , " + 
                        "  :dof_observacao , " + 
                        "  :dof_data_envio , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_documento_fiscal;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_documento_fiscal_tipo", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.DocumentoFiscalTipo==null ? (object) DBNull.Value : this.DocumentoFiscalTipo.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_documento_fiscal_destino", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.DocumentoFiscalDestino==null ? (object) DBNull.Value : this.DocumentoFiscalDestino.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_envio", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuarioEnvio==null ? (object) DBNull.Value : this.AcsUsuarioEnvio.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dof_identificacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Identificacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dof_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Descricao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dof_observacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Observacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dof_data_envio", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataEnvio ?? DBNull.Value;
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
        public static DocumentoFiscalClass CopiarEntidade(DocumentoFiscalClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               DocumentoFiscalClass toRet = new DocumentoFiscalClass(usuario,conn);
 toRet.DocumentoFiscalTipo= entidadeCopiar.DocumentoFiscalTipo;
 toRet.DocumentoFiscalDestino= entidadeCopiar.DocumentoFiscalDestino;
 toRet.AcsUsuarioEnvio= entidadeCopiar.AcsUsuarioEnvio;
 toRet.Identificacao= entidadeCopiar.Identificacao;
 toRet.Descricao= entidadeCopiar.Descricao;
 toRet.Observacao= entidadeCopiar.Observacao;
 toRet.DataEnvio= entidadeCopiar.DataEnvio;

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
       _documentoFiscalTipoOriginal = DocumentoFiscalTipo;
       _documentoFiscalTipoOriginalCommited = _documentoFiscalTipoOriginal;
       _documentoFiscalDestinoOriginal = DocumentoFiscalDestino;
       _documentoFiscalDestinoOriginalCommited = _documentoFiscalDestinoOriginal;
       _acsUsuarioEnvioOriginal = AcsUsuarioEnvio;
       _acsUsuarioEnvioOriginalCommited = _acsUsuarioEnvioOriginal;
       _identificacaoOriginal = Identificacao;
       _identificacaoOriginalCommited = _identificacaoOriginal;
       _descricaoOriginal = Descricao;
       _descricaoOriginalCommited = _descricaoOriginal;
       _observacaoOriginal = Observacao;
       _observacaoOriginalCommited = _observacaoOriginal;
       _dataEnvioOriginal = DataEnvio;
       _dataEnvioOriginalCommited = _dataEnvioOriginal;
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
       _documentoFiscalTipoOriginalCommited = DocumentoFiscalTipo;
       _documentoFiscalDestinoOriginalCommited = DocumentoFiscalDestino;
       _acsUsuarioEnvioOriginalCommited = AcsUsuarioEnvio;
       _identificacaoOriginalCommited = Identificacao;
       _descricaoOriginalCommited = Descricao;
       _observacaoOriginalCommited = Observacao;
       _dataEnvioOriginalCommited = DataEnvio;
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
               DocumentoFiscalTipo=_documentoFiscalTipoOriginal;
               _documentoFiscalTipoOriginalCommited=_documentoFiscalTipoOriginal;
               DocumentoFiscalDestino=_documentoFiscalDestinoOriginal;
               _documentoFiscalDestinoOriginalCommited=_documentoFiscalDestinoOriginal;
               AcsUsuarioEnvio=_acsUsuarioEnvioOriginal;
               _acsUsuarioEnvioOriginalCommited=_acsUsuarioEnvioOriginal;
               Identificacao=_identificacaoOriginal;
               _identificacaoOriginalCommited=_identificacaoOriginal;
               Descricao=_descricaoOriginal;
               _descricaoOriginalCommited=_descricaoOriginal;
               Observacao=_observacaoOriginal;
               _observacaoOriginalCommited=_observacaoOriginal;
               DataEnvio=_dataEnvioOriginal;
               _dataEnvioOriginalCommited=_dataEnvioOriginal;
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
       if (_documentoFiscalTipoOriginal!=null)
       {
          dirty = !_documentoFiscalTipoOriginal.Equals(DocumentoFiscalTipo);
       }
       else
       {
            dirty = DocumentoFiscalTipo != null;
       }
      if (dirty) return true;
       if (_documentoFiscalDestinoOriginal!=null)
       {
          dirty = !_documentoFiscalDestinoOriginal.Equals(DocumentoFiscalDestino);
       }
       else
       {
            dirty = DocumentoFiscalDestino != null;
       }
      if (dirty) return true;
       if (_acsUsuarioEnvioOriginal!=null)
       {
          dirty = !_acsUsuarioEnvioOriginal.Equals(AcsUsuarioEnvio);
       }
       else
       {
            dirty = AcsUsuarioEnvio != null;
       }
      if (dirty) return true;
       dirty = _identificacaoOriginal != Identificacao;
      if (dirty) return true;
       dirty = _descricaoOriginal != Descricao;
      if (dirty) return true;
       dirty = _observacaoOriginal != Observacao;
      if (dirty) return true;
       dirty = _dataEnvioOriginal != DataEnvio;
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
       if (_documentoFiscalTipoOriginalCommited!=null)
       {
          dirty = !_documentoFiscalTipoOriginalCommited.Equals(DocumentoFiscalTipo);
       }
       else
       {
            dirty = DocumentoFiscalTipo != null;
       }
      if (dirty) return true;
       if (_documentoFiscalDestinoOriginalCommited!=null)
       {
          dirty = !_documentoFiscalDestinoOriginalCommited.Equals(DocumentoFiscalDestino);
       }
       else
       {
            dirty = DocumentoFiscalDestino != null;
       }
      if (dirty) return true;
       if (_acsUsuarioEnvioOriginalCommited!=null)
       {
          dirty = !_acsUsuarioEnvioOriginalCommited.Equals(AcsUsuarioEnvio);
       }
       else
       {
            dirty = AcsUsuarioEnvio != null;
       }
      if (dirty) return true;
       dirty = _identificacaoOriginalCommited != Identificacao;
      if (dirty) return true;
       dirty = _descricaoOriginalCommited != Descricao;
      if (dirty) return true;
       dirty = _observacaoOriginalCommited != Observacao;
      if (dirty) return true;
       dirty = _dataEnvioOriginalCommited != DataEnvio;
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
             case "DocumentoFiscalTipo":
                return this.DocumentoFiscalTipo;
             case "DocumentoFiscalDestino":
                return this.DocumentoFiscalDestino;
             case "AcsUsuarioEnvio":
                return this.AcsUsuarioEnvio;
             case "Identificacao":
                return this.Identificacao;
             case "Descricao":
                return this.Descricao;
             case "Observacao":
                return this.Observacao;
             case "DataEnvio":
                return this.DataEnvio;
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
             if (DocumentoFiscalTipo!=null)
                DocumentoFiscalTipo.ChangeSingleConnection(newConnection);
             if (DocumentoFiscalDestino!=null)
                DocumentoFiscalDestino.ChangeSingleConnection(newConnection);
             if (AcsUsuarioEnvio!=null)
                AcsUsuarioEnvio.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(documento_fiscal.id_documento_fiscal) " ;
               }
               else
               {
               command.CommandText += "documento_fiscal.id_documento_fiscal, " ;
               command.CommandText += "documento_fiscal.id_documento_fiscal_tipo, " ;
               command.CommandText += "documento_fiscal.id_documento_fiscal_destino, " ;
               command.CommandText += "documento_fiscal.id_acs_usuario_envio, " ;
               command.CommandText += "documento_fiscal.dof_identificacao, " ;
               command.CommandText += "documento_fiscal.dof_descricao, " ;
               command.CommandText += "documento_fiscal.dof_observacao, " ;
               command.CommandText += "documento_fiscal.dof_data_envio, " ;
               command.CommandText += "documento_fiscal.entity_uid, " ;
               command.CommandText += "documento_fiscal.version " ;
               }
               command.CommandText += " FROM  documento_fiscal ";
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
                        orderByClause += " , dof_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(dof_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = documento_fiscal.id_acs_usuario_ultima_revisao ";
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
                     case "id_documento_fiscal":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , documento_fiscal.id_documento_fiscal " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(documento_fiscal.id_documento_fiscal) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_documento_fiscal_tipo":
                     case "DocumentoFiscalTipo":
                     command.CommandText += " LEFT JOIN documento_fiscal_tipo as documento_fiscal_tipo_DocumentoFiscalTipo ON documento_fiscal_tipo_DocumentoFiscalTipo.id_documento_fiscal_tipo = documento_fiscal.id_documento_fiscal_tipo ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , documento_fiscal_tipo_DocumentoFiscalTipo.dft_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(documento_fiscal_tipo_DocumentoFiscalTipo.dft_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_documento_fiscal_destino":
                     case "DocumentoFiscalDestino":
                     command.CommandText += " LEFT JOIN documento_fiscal_destino as documento_fiscal_destino_DocumentoFiscalDestino ON documento_fiscal_destino_DocumentoFiscalDestino.id_documento_fiscal_destino = documento_fiscal.id_documento_fiscal_destino ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , documento_fiscal_destino_DocumentoFiscalDestino.dfd_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(documento_fiscal_destino_DocumentoFiscalDestino.dfd_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_envio":
                     case "AcsUsuarioEnvio":
                     orderByClause += " , documento_fiscal.id_acs_usuario_envio " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "dof_identificacao":
                     case "Identificacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , documento_fiscal.dof_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(documento_fiscal.dof_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dof_descricao":
                     case "Descricao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , documento_fiscal.dof_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(documento_fiscal.dof_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dof_observacao":
                     case "Observacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , documento_fiscal.dof_observacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(documento_fiscal.dof_observacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dof_data_envio":
                     case "DataEnvio":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , documento_fiscal.dof_data_envio " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(documento_fiscal.dof_data_envio) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , documento_fiscal.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(documento_fiscal.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , documento_fiscal.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(documento_fiscal.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("dof_identificacao")) 
                        {
                           whereClause += " OR UPPER(documento_fiscal.dof_identificacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(documento_fiscal.dof_identificacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("dof_descricao")) 
                        {
                           whereClause += " OR UPPER(documento_fiscal.dof_descricao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(documento_fiscal.dof_descricao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("dof_observacao")) 
                        {
                           whereClause += " OR UPPER(documento_fiscal.dof_observacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(documento_fiscal.dof_observacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(documento_fiscal.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(documento_fiscal.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_documento_fiscal")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_fiscal.id_documento_fiscal IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_fiscal.id_documento_fiscal = :documento_fiscal_ID_7665 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_fiscal_ID_7665", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DocumentoFiscalTipo" || parametro.FieldName == "id_documento_fiscal_tipo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.DocumentoFiscalTipoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.DocumentoFiscalTipoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_fiscal.id_documento_fiscal_tipo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_fiscal.id_documento_fiscal_tipo = :documento_fiscal_DocumentoFiscalTipo_7279 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_fiscal_DocumentoFiscalTipo_7279", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DocumentoFiscalDestino" || parametro.FieldName == "id_documento_fiscal_destino")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.DocumentoFiscalDestinoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.DocumentoFiscalDestinoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_fiscal.id_documento_fiscal_destino IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_fiscal.id_documento_fiscal_destino = :documento_fiscal_DocumentoFiscalDestino_6035 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_fiscal_DocumentoFiscalDestino_6035", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcsUsuarioEnvio" || parametro.FieldName == "id_acs_usuario_envio")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_fiscal.id_acs_usuario_envio IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_fiscal.id_acs_usuario_envio = :documento_fiscal_AcsUsuarioEnvio_3816 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_fiscal_AcsUsuarioEnvio_3816", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Identificacao" || parametro.FieldName == "dof_identificacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_fiscal.dof_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_fiscal.dof_identificacao LIKE :documento_fiscal_Identificacao_1772 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_fiscal_Identificacao_1772", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Descricao" || parametro.FieldName == "dof_descricao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_fiscal.dof_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_fiscal.dof_descricao LIKE :documento_fiscal_Descricao_3277 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_fiscal_Descricao_3277", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Observacao" || parametro.FieldName == "dof_observacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_fiscal.dof_observacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_fiscal.dof_observacao LIKE :documento_fiscal_Observacao_2470 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_fiscal_Observacao_2470", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataEnvio" || parametro.FieldName == "dof_data_envio")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_fiscal.dof_data_envio IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_fiscal.dof_data_envio = :documento_fiscal_DataEnvio_4445 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_fiscal_DataEnvio_4445", NpgsqlDbType.Date, parametro.Fieldvalue));
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
                         whereClause += "  documento_fiscal.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_fiscal.entity_uid LIKE :documento_fiscal_EntityUid_8115 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_fiscal_EntityUid_8115", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  documento_fiscal.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_fiscal.version = :documento_fiscal_Version_7879 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_fiscal_Version_7879", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IdentificacaoExato" || parametro.FieldName == "IdentificacaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_fiscal.dof_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_fiscal.dof_identificacao LIKE :documento_fiscal_Identificacao_1022 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_fiscal_Identificacao_1022", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescricaoExato" || parametro.FieldName == "DescricaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_fiscal.dof_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_fiscal.dof_descricao LIKE :documento_fiscal_Descricao_7030 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_fiscal_Descricao_7030", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  documento_fiscal.dof_observacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_fiscal.dof_observacao LIKE :documento_fiscal_Observacao_8371 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_fiscal_Observacao_8371", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  documento_fiscal.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_fiscal.entity_uid LIKE :documento_fiscal_EntityUid_1396 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_fiscal_EntityUid_1396", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  DocumentoFiscalClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (DocumentoFiscalClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(DocumentoFiscalClass), Convert.ToInt32(read["id_documento_fiscal"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new DocumentoFiscalClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_documento_fiscal"]);
                     if (read["id_documento_fiscal_tipo"] != DBNull.Value)
                     {
                        entidade.DocumentoFiscalTipo = (BibliotecaEntidades.Entidades.DocumentoFiscalTipoClass)BibliotecaEntidades.Entidades.DocumentoFiscalTipoClass.GetEntidade(Convert.ToInt32(read["id_documento_fiscal_tipo"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.DocumentoFiscalTipo = null ;
                     }
                     if (read["id_documento_fiscal_destino"] != DBNull.Value)
                     {
                        entidade.DocumentoFiscalDestino = (BibliotecaEntidades.Entidades.DocumentoFiscalDestinoClass)BibliotecaEntidades.Entidades.DocumentoFiscalDestinoClass.GetEntidade(Convert.ToInt32(read["id_documento_fiscal_destino"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.DocumentoFiscalDestino = null ;
                     }
                     if (read["id_acs_usuario_envio"] != DBNull.Value)
                     {
                        entidade.AcsUsuarioEnvio = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_envio"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuarioEnvio = null ;
                     }
                     entidade.Identificacao = (read["dof_identificacao"] != DBNull.Value ? read["dof_identificacao"].ToString() : null);
                     entidade.Descricao = (read["dof_descricao"] != DBNull.Value ? read["dof_descricao"].ToString() : null);
                     entidade.Observacao = (read["dof_observacao"] != DBNull.Value ? read["dof_observacao"].ToString() : null);
                     entidade.DataEnvio = read["dof_data_envio"] as DateTime?;
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (DocumentoFiscalClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
