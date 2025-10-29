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
     [Table("produto_bloqueio_qualidade","pbq")]
     public class ProdutoBloqueioQualidadeBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do ProdutoBloqueioQualidadeClass";
protected const string ErroDelete = "Erro ao excluir o ProdutoBloqueioQualidadeClass  ";
protected const string ErroSave = "Erro ao salvar o ProdutoBloqueioQualidadeClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroMotivoBloqueioObrigatorio = "O campo MotivoBloqueio é obrigatório";
protected const string ErroMotivoBloqueioComprimento = "O campo MotivoBloqueio deve ter no máximo 255 caracteres";
protected const string ErroProdutoObrigatorio = "O campo Produto é obrigatório";
protected const string ErroAcsUsuarioObrigatorio = "O campo AcsUsuario é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do ProdutoBloqueioQualidadeClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade ProdutoBloqueioQualidadeClass está sendo utilizada.";
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

       protected DateTime _dataBloqueioOriginal{get;private set;}
       private DateTime _dataBloqueioOriginalCommited{get; set;}
        private DateTime _valueDataBloqueio;
         [Column("pbq_data_bloqueio")]
        public virtual DateTime DataBloqueio
         { 
            get { return this._valueDataBloqueio; } 
            set 
            { 
                if (this._valueDataBloqueio == value)return;
                 this._valueDataBloqueio = value; 
            } 
        } 

       protected bool _ativoOriginal{get;private set;}
       private bool _ativoOriginalCommited{get; set;}
        private bool _valueAtivo;
         [Column("pbq_ativo")]
        public virtual bool Ativo
         { 
            get { return this._valueAtivo; } 
            set 
            { 
                if (this._valueAtivo == value)return;
                 this._valueAtivo = value; 
            } 
        } 

       protected IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioEncerramentoBloqueioOriginal{get;private set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioEncerramentoBloqueioOriginalCommited {get; set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _valueAcsUsuarioEncerramentoBloqueio;
        [Column("id_acs_usuario_encerramento_bloqueio", "acs_usuario", "id_acs_usuario")]
       public virtual IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass AcsUsuarioEncerramentoBloqueio
        { 
           get {                 return this._valueAcsUsuarioEncerramentoBloqueio; } 
           set 
           { 
                if (this._valueAcsUsuarioEncerramentoBloqueio == value)return;
                 this._valueAcsUsuarioEncerramentoBloqueio = value; 
           } 
       } 

       protected DateTime? _dataEncerramentoBloqueioOriginal{get;private set;}
       private DateTime? _dataEncerramentoBloqueioOriginalCommited{get; set;}
        private DateTime? _valueDataEncerramentoBloqueio;
         [Column("pbq_data_encerramento_bloqueio")]
        public virtual DateTime? DataEncerramentoBloqueio
         { 
            get { return this._valueDataEncerramentoBloqueio; } 
            set 
            { 
                if (this._valueDataEncerramentoBloqueio == value)return;
                 this._valueDataEncerramentoBloqueio = value; 
            } 
        } 

       protected string _motivoBloqueioOriginal{get;private set;}
       private string _motivoBloqueioOriginalCommited{get; set;}
        private string _valueMotivoBloqueio;
         [Column("pbq_motivo_bloqueio")]
        public virtual string MotivoBloqueio
         { 
            get { return this._valueMotivoBloqueio; } 
            set 
            { 
                if (this._valueMotivoBloqueio == value)return;
                 this._valueMotivoBloqueio = value; 
            } 
        } 

        public ProdutoBloqueioQualidadeBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static ProdutoBloqueioQualidadeClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (ProdutoBloqueioQualidadeClass) GetEntity(typeof(ProdutoBloqueioQualidadeClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(MotivoBloqueio))
                {
                    throw new Exception(ErroMotivoBloqueioObrigatorio);
                }
                if (MotivoBloqueio.Length >255)
                {
                    throw new Exception( ErroMotivoBloqueioComprimento);
                }
                if ( _valueProduto == null)
                {
                    throw new Exception(ErroProdutoObrigatorio);
                }
                if ( _valueAcsUsuario == null)
                {
                    throw new Exception(ErroAcsUsuarioObrigatorio);
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
                    "  public.produto_bloqueio_qualidade  " +
                    "WHERE " +
                    "  id_produto_bloqueio_qualidade = :id";
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
                        "  public.produto_bloqueio_qualidade   " +
                        "SET  " + 
                        "  id_produto = :id_produto, " + 
                        "  id_acs_usuario = :id_acs_usuario, " + 
                        "  pbq_data_bloqueio = :pbq_data_bloqueio, " + 
                        "  pbq_ativo = :pbq_ativo, " + 
                        "  id_acs_usuario_encerramento_bloqueio = :id_acs_usuario_encerramento_bloqueio, " + 
                        "  pbq_data_encerramento_bloqueio = :pbq_data_encerramento_bloqueio, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  pbq_motivo_bloqueio = :pbq_motivo_bloqueio "+
                        "WHERE  " +
                        "  id_produto_bloqueio_qualidade = :id " +
                        "RETURNING id_produto_bloqueio_qualidade;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.produto_bloqueio_qualidade " +
                        "( " +
                        "  id_produto , " + 
                        "  id_acs_usuario , " + 
                        "  pbq_data_bloqueio , " + 
                        "  pbq_ativo , " + 
                        "  id_acs_usuario_encerramento_bloqueio , " + 
                        "  pbq_data_encerramento_bloqueio , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  pbq_motivo_bloqueio  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_produto , " + 
                        "  :id_acs_usuario , " + 
                        "  :pbq_data_bloqueio , " + 
                        "  :pbq_ativo , " + 
                        "  :id_acs_usuario_encerramento_bloqueio , " + 
                        "  :pbq_data_encerramento_bloqueio , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :pbq_motivo_bloqueio  "+
                        ")RETURNING id_produto_bloqueio_qualidade;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Produto==null ? (object) DBNull.Value : this.Produto.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuario==null ? (object) DBNull.Value : this.AcsUsuario.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pbq_data_bloqueio", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataBloqueio ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pbq_ativo", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Ativo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_encerramento_bloqueio", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuarioEncerramentoBloqueio==null ? (object) DBNull.Value : this.AcsUsuarioEncerramentoBloqueio.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pbq_data_encerramento_bloqueio", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataEncerramentoBloqueio ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pbq_motivo_bloqueio", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.MotivoBloqueio ?? DBNull.Value;

 
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
        public static ProdutoBloqueioQualidadeClass CopiarEntidade(ProdutoBloqueioQualidadeClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               ProdutoBloqueioQualidadeClass toRet = new ProdutoBloqueioQualidadeClass(usuario,conn);
 toRet.Produto= entidadeCopiar.Produto;
 toRet.AcsUsuario= entidadeCopiar.AcsUsuario;
 toRet.DataBloqueio= entidadeCopiar.DataBloqueio;
 toRet.Ativo= entidadeCopiar.Ativo;
 toRet.AcsUsuarioEncerramentoBloqueio= entidadeCopiar.AcsUsuarioEncerramentoBloqueio;
 toRet.DataEncerramentoBloqueio= entidadeCopiar.DataEncerramentoBloqueio;
 toRet.MotivoBloqueio= entidadeCopiar.MotivoBloqueio;

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
       _acsUsuarioOriginal = AcsUsuario;
       _acsUsuarioOriginalCommited = _acsUsuarioOriginal;
       _dataBloqueioOriginal = DataBloqueio;
       _dataBloqueioOriginalCommited = _dataBloqueioOriginal;
       _ativoOriginal = Ativo;
       _ativoOriginalCommited = _ativoOriginal;
       _acsUsuarioEncerramentoBloqueioOriginal = AcsUsuarioEncerramentoBloqueio;
       _acsUsuarioEncerramentoBloqueioOriginalCommited = _acsUsuarioEncerramentoBloqueioOriginal;
       _dataEncerramentoBloqueioOriginal = DataEncerramentoBloqueio;
       _dataEncerramentoBloqueioOriginalCommited = _dataEncerramentoBloqueioOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _motivoBloqueioOriginal = MotivoBloqueio;
       _motivoBloqueioOriginalCommited = _motivoBloqueioOriginal;

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
       _acsUsuarioOriginalCommited = AcsUsuario;
       _dataBloqueioOriginalCommited = DataBloqueio;
       _ativoOriginalCommited = Ativo;
       _acsUsuarioEncerramentoBloqueioOriginalCommited = AcsUsuarioEncerramentoBloqueio;
       _dataEncerramentoBloqueioOriginalCommited = DataEncerramentoBloqueio;
       _versionOriginalCommited = Version;
       _motivoBloqueioOriginalCommited = MotivoBloqueio;

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
               AcsUsuario=_acsUsuarioOriginal;
               _acsUsuarioOriginalCommited=_acsUsuarioOriginal;
               DataBloqueio=_dataBloqueioOriginal;
               _dataBloqueioOriginalCommited=_dataBloqueioOriginal;
               Ativo=_ativoOriginal;
               _ativoOriginalCommited=_ativoOriginal;
               AcsUsuarioEncerramentoBloqueio=_acsUsuarioEncerramentoBloqueioOriginal;
               _acsUsuarioEncerramentoBloqueioOriginalCommited=_acsUsuarioEncerramentoBloqueioOriginal;
               DataEncerramentoBloqueio=_dataEncerramentoBloqueioOriginal;
               _dataEncerramentoBloqueioOriginalCommited=_dataEncerramentoBloqueioOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               MotivoBloqueio=_motivoBloqueioOriginal;
               _motivoBloqueioOriginalCommited=_motivoBloqueioOriginal;

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
       if (_acsUsuarioOriginal!=null)
       {
          dirty = !_acsUsuarioOriginal.Equals(AcsUsuario);
       }
       else
       {
            dirty = AcsUsuario != null;
       }
      if (dirty) return true;
       dirty = _dataBloqueioOriginal != DataBloqueio;
      if (dirty) return true;
       dirty = _ativoOriginal != Ativo;
      if (dirty) return true;
       if (_acsUsuarioEncerramentoBloqueioOriginal!=null)
       {
          dirty = !_acsUsuarioEncerramentoBloqueioOriginal.Equals(AcsUsuarioEncerramentoBloqueio);
       }
       else
       {
            dirty = AcsUsuarioEncerramentoBloqueio != null;
       }
      if (dirty) return true;
       dirty = _dataEncerramentoBloqueioOriginal != DataEncerramentoBloqueio;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _motivoBloqueioOriginal != MotivoBloqueio;

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
       if (_acsUsuarioOriginalCommited!=null)
       {
          dirty = !_acsUsuarioOriginalCommited.Equals(AcsUsuario);
       }
       else
       {
            dirty = AcsUsuario != null;
       }
      if (dirty) return true;
       dirty = _dataBloqueioOriginalCommited != DataBloqueio;
      if (dirty) return true;
       dirty = _ativoOriginalCommited != Ativo;
      if (dirty) return true;
       if (_acsUsuarioEncerramentoBloqueioOriginalCommited!=null)
       {
          dirty = !_acsUsuarioEncerramentoBloqueioOriginalCommited.Equals(AcsUsuarioEncerramentoBloqueio);
       }
       else
       {
            dirty = AcsUsuarioEncerramentoBloqueio != null;
       }
      if (dirty) return true;
       dirty = _dataEncerramentoBloqueioOriginalCommited != DataEncerramentoBloqueio;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _motivoBloqueioOriginalCommited != MotivoBloqueio;

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
             case "AcsUsuario":
                return this.AcsUsuario;
             case "DataBloqueio":
                return this.DataBloqueio;
             case "Ativo":
                return this.Ativo;
             case "AcsUsuarioEncerramentoBloqueio":
                return this.AcsUsuarioEncerramentoBloqueio;
             case "DataEncerramentoBloqueio":
                return this.DataEncerramentoBloqueio;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "MotivoBloqueio":
                return this.MotivoBloqueio;
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
             if (AcsUsuario!=null)
                AcsUsuario.ChangeSingleConnection(newConnection);
             if (AcsUsuarioEncerramentoBloqueio!=null)
                AcsUsuarioEncerramentoBloqueio.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(produto_bloqueio_qualidade.id_produto_bloqueio_qualidade) " ;
               }
               else
               {
               command.CommandText += "produto_bloqueio_qualidade.id_produto_bloqueio_qualidade, " ;
               command.CommandText += "produto_bloqueio_qualidade.id_produto, " ;
               command.CommandText += "produto_bloqueio_qualidade.id_acs_usuario, " ;
               command.CommandText += "produto_bloqueio_qualidade.pbq_data_bloqueio, " ;
               command.CommandText += "produto_bloqueio_qualidade.pbq_ativo, " ;
               command.CommandText += "produto_bloqueio_qualidade.id_acs_usuario_encerramento_bloqueio, " ;
               command.CommandText += "produto_bloqueio_qualidade.pbq_data_encerramento_bloqueio, " ;
               command.CommandText += "produto_bloqueio_qualidade.entity_uid, " ;
               command.CommandText += "produto_bloqueio_qualidade.version, " ;
               command.CommandText += "produto_bloqueio_qualidade.pbq_motivo_bloqueio " ;
               }
               command.CommandText += " FROM  produto_bloqueio_qualidade ";
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
                        orderByClause += " , pbq_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(pbq_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = produto_bloqueio_qualidade.id_acs_usuario_ultima_revisao ";
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
                     case "id_produto_bloqueio_qualidade":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_bloqueio_qualidade.id_produto_bloqueio_qualidade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_bloqueio_qualidade.id_produto_bloqueio_qualidade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_produto":
                     case "Produto":
                     command.CommandText += " LEFT JOIN produto as produto_Produto ON produto_Produto.id_produto = produto_bloqueio_qualidade.id_produto ";                     switch (parametro.TipoOrdenacao)
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
                     case "id_acs_usuario":
                     case "AcsUsuario":
                     orderByClause += " , produto_bloqueio_qualidade.id_acs_usuario " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "pbq_data_bloqueio":
                     case "DataBloqueio":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_bloqueio_qualidade.pbq_data_bloqueio " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_bloqueio_qualidade.pbq_data_bloqueio) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pbq_ativo":
                     case "Ativo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_bloqueio_qualidade.pbq_ativo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_bloqueio_qualidade.pbq_ativo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_encerramento_bloqueio":
                     case "AcsUsuarioEncerramentoBloqueio":
                     orderByClause += " , produto_bloqueio_qualidade.id_acs_usuario_encerramento_bloqueio " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "pbq_data_encerramento_bloqueio":
                     case "DataEncerramentoBloqueio":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , produto_bloqueio_qualidade.pbq_data_encerramento_bloqueio " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_bloqueio_qualidade.pbq_data_encerramento_bloqueio) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_bloqueio_qualidade.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_bloqueio_qualidade.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , produto_bloqueio_qualidade.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(produto_bloqueio_qualidade.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pbq_motivo_bloqueio":
                     case "MotivoBloqueio":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_bloqueio_qualidade.pbq_motivo_bloqueio " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_bloqueio_qualidade.pbq_motivo_bloqueio) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           whereClause += " OR UPPER(produto_bloqueio_qualidade.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto_bloqueio_qualidade.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pbq_motivo_bloqueio")) 
                        {
                           whereClause += " OR UPPER(produto_bloqueio_qualidade.pbq_motivo_bloqueio) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(produto_bloqueio_qualidade.pbq_motivo_bloqueio) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_produto_bloqueio_qualidade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_bloqueio_qualidade.id_produto_bloqueio_qualidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_bloqueio_qualidade.id_produto_bloqueio_qualidade = :produto_bloqueio_qualidade_ID_9158 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_bloqueio_qualidade_ID_9158", NpgsqlDbType.Bigint, parametro.Fieldvalue));
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
                         whereClause += "  produto_bloqueio_qualidade.id_produto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_bloqueio_qualidade.id_produto = :produto_bloqueio_qualidade_Produto_8906 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_bloqueio_qualidade_Produto_8906", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  produto_bloqueio_qualidade.id_acs_usuario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_bloqueio_qualidade.id_acs_usuario = :produto_bloqueio_qualidade_AcsUsuario_6275 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_bloqueio_qualidade_AcsUsuario_6275", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataBloqueio" || parametro.FieldName == "pbq_data_bloqueio")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_bloqueio_qualidade.pbq_data_bloqueio IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_bloqueio_qualidade.pbq_data_bloqueio = :produto_bloqueio_qualidade_DataBloqueio_4957 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_bloqueio_qualidade_DataBloqueio_4957", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Ativo" || parametro.FieldName == "pbq_ativo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_bloqueio_qualidade.pbq_ativo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_bloqueio_qualidade.pbq_ativo = :produto_bloqueio_qualidade_Ativo_2057 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_bloqueio_qualidade_Ativo_2057", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcsUsuarioEncerramentoBloqueio" || parametro.FieldName == "id_acs_usuario_encerramento_bloqueio")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_bloqueio_qualidade.id_acs_usuario_encerramento_bloqueio IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_bloqueio_qualidade.id_acs_usuario_encerramento_bloqueio = :produto_bloqueio_qualidade_AcsUsuarioEncerramentoBloqueio_5320 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_bloqueio_qualidade_AcsUsuarioEncerramentoBloqueio_5320", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataEncerramentoBloqueio" || parametro.FieldName == "pbq_data_encerramento_bloqueio")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_bloqueio_qualidade.pbq_data_encerramento_bloqueio IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_bloqueio_qualidade.pbq_data_encerramento_bloqueio = :produto_bloqueio_qualidade_DataEncerramentoBloqueio_1337 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_bloqueio_qualidade_DataEncerramentoBloqueio_1337", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
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
                         whereClause += "  produto_bloqueio_qualidade.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_bloqueio_qualidade.entity_uid LIKE :produto_bloqueio_qualidade_EntityUid_757 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_bloqueio_qualidade_EntityUid_757", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  produto_bloqueio_qualidade.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_bloqueio_qualidade.version = :produto_bloqueio_qualidade_Version_3782 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_bloqueio_qualidade_Version_3782", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MotivoBloqueio" || parametro.FieldName == "pbq_motivo_bloqueio")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_bloqueio_qualidade.pbq_motivo_bloqueio IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_bloqueio_qualidade.pbq_motivo_bloqueio LIKE :produto_bloqueio_qualidade_MotivoBloqueio_2858 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_bloqueio_qualidade_MotivoBloqueio_2858", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  produto_bloqueio_qualidade.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_bloqueio_qualidade.entity_uid LIKE :produto_bloqueio_qualidade_EntityUid_6410 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_bloqueio_qualidade_EntityUid_6410", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MotivoBloqueioExato" || parametro.FieldName == "MotivoBloqueioExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  produto_bloqueio_qualidade.pbq_motivo_bloqueio IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  produto_bloqueio_qualidade.pbq_motivo_bloqueio LIKE :produto_bloqueio_qualidade_MotivoBloqueio_2742 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("produto_bloqueio_qualidade_MotivoBloqueio_2742", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  ProdutoBloqueioQualidadeClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (ProdutoBloqueioQualidadeClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(ProdutoBloqueioQualidadeClass), Convert.ToInt32(read["id_produto_bloqueio_qualidade"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new ProdutoBloqueioQualidadeClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_produto_bloqueio_qualidade"]);
                     if (read["id_produto"] != DBNull.Value)
                     {
                        entidade.Produto = (BibliotecaEntidades.Entidades.ProdutoClass)BibliotecaEntidades.Entidades.ProdutoClass.GetEntidade(Convert.ToInt32(read["id_produto"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Produto = null ;
                     }
                     if (read["id_acs_usuario"] != DBNull.Value)
                     {
                        entidade.AcsUsuario = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuario = null ;
                     }
                     entidade.DataBloqueio = (DateTime)read["pbq_data_bloqueio"];
                     entidade.Ativo = Convert.ToBoolean(Convert.ToInt16(read["pbq_ativo"]));
                     if (read["id_acs_usuario_encerramento_bloqueio"] != DBNull.Value)
                     {
                        entidade.AcsUsuarioEncerramentoBloqueio = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_encerramento_bloqueio"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuarioEncerramentoBloqueio = null ;
                     }
                     entidade.DataEncerramentoBloqueio = read["pbq_data_encerramento_bloqueio"] as DateTime?;
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.MotivoBloqueio = (read["pbq_motivo_bloqueio"] != DBNull.Value ? read["pbq_motivo_bloqueio"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (ProdutoBloqueioQualidadeClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
