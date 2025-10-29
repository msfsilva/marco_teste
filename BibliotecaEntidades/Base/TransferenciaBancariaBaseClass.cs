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
     [Table("transferencia_bancaria","trb")]
     public class TransferenciaBancariaBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do TransferenciaBancariaClass";
protected const string ErroDelete = "Erro ao excluir o TransferenciaBancariaClass  ";
protected const string ErroSave = "Erro ao salvar o TransferenciaBancariaClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroContaBancariaOrigemObrigatorio = "O campo ContaBancariaOrigem é obrigatório";
protected const string ErroContaBancariaDestinoObrigatorio = "O campo ContaBancariaDestino é obrigatório";
protected const string ErroAcsUsuarioObrigatorio = "O campo AcsUsuario é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do TransferenciaBancariaClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade TransferenciaBancariaClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.ContaBancariaClass _contaBancariaOrigemOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.ContaBancariaClass _contaBancariaOrigemOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.ContaBancariaClass _valueContaBancariaOrigem;
        [Column("id_conta_bancaria_origem", "conta_bancaria", "id_conta_bancaria")]
       public virtual BibliotecaEntidades.Entidades.ContaBancariaClass ContaBancariaOrigem
        { 
           get {                 return this._valueContaBancariaOrigem; } 
           set 
           { 
                if (this._valueContaBancariaOrigem == value)return;
                 this._valueContaBancariaOrigem = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.ContaBancariaClass _contaBancariaDestinoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.ContaBancariaClass _contaBancariaDestinoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.ContaBancariaClass _valueContaBancariaDestino;
        [Column("id_conta_bancaria_destino", "conta_bancaria", "id_conta_bancaria")]
       public virtual BibliotecaEntidades.Entidades.ContaBancariaClass ContaBancariaDestino
        { 
           get {                 return this._valueContaBancariaDestino; } 
           set 
           { 
                if (this._valueContaBancariaDestino == value)return;
                 this._valueContaBancariaDestino = value; 
           } 
       } 

       protected double _valorOriginal{get;private set;}
       private double _valorOriginalCommited{get; set;}
        private double _valueValor;
         [Column("trb_valor")]
        public virtual double Valor
         { 
            get { return this._valueValor; } 
            set 
            { 
                if (this._valueValor == value)return;
                 this._valueValor = value; 
            } 
        } 

       protected DateTime _dataOriginal{get;private set;}
       private DateTime _dataOriginalCommited{get; set;}
        private DateTime _valueData;
         [Column("trb_data")]
        public virtual DateTime Data
         { 
            get { return this._valueData; } 
            set 
            { 
                if (this._valueData == value)return;
                 this._valueData = value; 
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

       protected BibliotecaEntidades.Entidades.ConciliacaoBancariaClass _conciliacaoBancariaOrigemOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.ConciliacaoBancariaClass _conciliacaoBancariaOrigemOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.ConciliacaoBancariaClass _valueConciliacaoBancariaOrigem;
        [Column("id_conciliacao_bancaria_origem", "conciliacao_bancaria", "id_conciliacao_bancaria")]
       public virtual BibliotecaEntidades.Entidades.ConciliacaoBancariaClass ConciliacaoBancariaOrigem
        { 
           get {                 return this._valueConciliacaoBancariaOrigem; } 
           set 
           { 
                if (this._valueConciliacaoBancariaOrigem == value)return;
                 this._valueConciliacaoBancariaOrigem = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.ConciliacaoBancariaClass _conciliacaoBancariaDestinoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.ConciliacaoBancariaClass _conciliacaoBancariaDestinoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.ConciliacaoBancariaClass _valueConciliacaoBancariaDestino;
        [Column("id_conciliacao_bancaria_destino", "conciliacao_bancaria", "id_conciliacao_bancaria")]
       public virtual BibliotecaEntidades.Entidades.ConciliacaoBancariaClass ConciliacaoBancariaDestino
        { 
           get {                 return this._valueConciliacaoBancariaDestino; } 
           set 
           { 
                if (this._valueConciliacaoBancariaDestino == value)return;
                 this._valueConciliacaoBancariaDestino = value; 
           } 
       } 

        public TransferenciaBancariaBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static TransferenciaBancariaClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (TransferenciaBancariaClass) GetEntity(typeof(TransferenciaBancariaClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if ( _valueContaBancariaOrigem == null)
                {
                    throw new Exception(ErroContaBancariaOrigemObrigatorio);
                }
                if ( _valueContaBancariaDestino == null)
                {
                    throw new Exception(ErroContaBancariaDestinoObrigatorio);
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
                    "  public.transferencia_bancaria  " +
                    "WHERE " +
                    "  id_transferencia_bancaria = :id";
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
                        "  public.transferencia_bancaria   " +
                        "SET  " + 
                        "  id_conta_bancaria_origem = :id_conta_bancaria_origem, " + 
                        "  id_conta_bancaria_destino = :id_conta_bancaria_destino, " + 
                        "  trb_valor = :trb_valor, " + 
                        "  trb_data = :trb_data, " + 
                        "  id_acs_usuario = :id_acs_usuario, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  id_conciliacao_bancaria_origem = :id_conciliacao_bancaria_origem, " + 
                        "  id_conciliacao_bancaria_destino = :id_conciliacao_bancaria_destino "+
                        "WHERE  " +
                        "  id_transferencia_bancaria = :id " +
                        "RETURNING id_transferencia_bancaria;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.transferencia_bancaria " +
                        "( " +
                        "  id_conta_bancaria_origem , " + 
                        "  id_conta_bancaria_destino , " + 
                        "  trb_valor , " + 
                        "  trb_data , " + 
                        "  id_acs_usuario , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  id_conciliacao_bancaria_origem , " + 
                        "  id_conciliacao_bancaria_destino  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_conta_bancaria_origem , " + 
                        "  :id_conta_bancaria_destino , " + 
                        "  :trb_valor , " + 
                        "  :trb_data , " + 
                        "  :id_acs_usuario , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :id_conciliacao_bancaria_origem , " + 
                        "  :id_conciliacao_bancaria_destino  "+
                        ")RETURNING id_transferencia_bancaria;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_conta_bancaria_origem", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.ContaBancariaOrigem==null ? (object) DBNull.Value : this.ContaBancariaOrigem.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_conta_bancaria_destino", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.ContaBancariaDestino==null ? (object) DBNull.Value : this.ContaBancariaDestino.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("trb_valor", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Valor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("trb_data", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Data ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuario==null ? (object) DBNull.Value : this.AcsUsuario.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_conciliacao_bancaria_origem", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.ConciliacaoBancariaOrigem==null ? (object) DBNull.Value : this.ConciliacaoBancariaOrigem.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_conciliacao_bancaria_destino", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.ConciliacaoBancariaDestino==null ? (object) DBNull.Value : this.ConciliacaoBancariaDestino.ID;

 
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
        public static TransferenciaBancariaClass CopiarEntidade(TransferenciaBancariaClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               TransferenciaBancariaClass toRet = new TransferenciaBancariaClass(usuario,conn);
 toRet.ContaBancariaOrigem= entidadeCopiar.ContaBancariaOrigem;
 toRet.ContaBancariaDestino= entidadeCopiar.ContaBancariaDestino;
 toRet.Valor= entidadeCopiar.Valor;
 toRet.Data= entidadeCopiar.Data;
 toRet.AcsUsuario= entidadeCopiar.AcsUsuario;
 toRet.ConciliacaoBancariaOrigem= entidadeCopiar.ConciliacaoBancariaOrigem;
 toRet.ConciliacaoBancariaDestino= entidadeCopiar.ConciliacaoBancariaDestino;

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
       _contaBancariaOrigemOriginal = ContaBancariaOrigem;
       _contaBancariaOrigemOriginalCommited = _contaBancariaOrigemOriginal;
       _contaBancariaDestinoOriginal = ContaBancariaDestino;
       _contaBancariaDestinoOriginalCommited = _contaBancariaDestinoOriginal;
       _valorOriginal = Valor;
       _valorOriginalCommited = _valorOriginal;
       _dataOriginal = Data;
       _dataOriginalCommited = _dataOriginal;
       _acsUsuarioOriginal = AcsUsuario;
       _acsUsuarioOriginalCommited = _acsUsuarioOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _conciliacaoBancariaOrigemOriginal = ConciliacaoBancariaOrigem;
       _conciliacaoBancariaOrigemOriginalCommited = _conciliacaoBancariaOrigemOriginal;
       _conciliacaoBancariaDestinoOriginal = ConciliacaoBancariaDestino;
       _conciliacaoBancariaDestinoOriginalCommited = _conciliacaoBancariaDestinoOriginal;

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
       _contaBancariaOrigemOriginalCommited = ContaBancariaOrigem;
       _contaBancariaDestinoOriginalCommited = ContaBancariaDestino;
       _valorOriginalCommited = Valor;
       _dataOriginalCommited = Data;
       _acsUsuarioOriginalCommited = AcsUsuario;
       _versionOriginalCommited = Version;
       _conciliacaoBancariaOrigemOriginalCommited = ConciliacaoBancariaOrigem;
       _conciliacaoBancariaDestinoOriginalCommited = ConciliacaoBancariaDestino;

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
               ContaBancariaOrigem=_contaBancariaOrigemOriginal;
               _contaBancariaOrigemOriginalCommited=_contaBancariaOrigemOriginal;
               ContaBancariaDestino=_contaBancariaDestinoOriginal;
               _contaBancariaDestinoOriginalCommited=_contaBancariaDestinoOriginal;
               Valor=_valorOriginal;
               _valorOriginalCommited=_valorOriginal;
               Data=_dataOriginal;
               _dataOriginalCommited=_dataOriginal;
               AcsUsuario=_acsUsuarioOriginal;
               _acsUsuarioOriginalCommited=_acsUsuarioOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               ConciliacaoBancariaOrigem=_conciliacaoBancariaOrigemOriginal;
               _conciliacaoBancariaOrigemOriginalCommited=_conciliacaoBancariaOrigemOriginal;
               ConciliacaoBancariaDestino=_conciliacaoBancariaDestinoOriginal;
               _conciliacaoBancariaDestinoOriginalCommited=_conciliacaoBancariaDestinoOriginal;

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
       if (_contaBancariaOrigemOriginal!=null)
       {
          dirty = !_contaBancariaOrigemOriginal.Equals(ContaBancariaOrigem);
       }
       else
       {
            dirty = ContaBancariaOrigem != null;
       }
      if (dirty) return true;
       if (_contaBancariaDestinoOriginal!=null)
       {
          dirty = !_contaBancariaDestinoOriginal.Equals(ContaBancariaDestino);
       }
       else
       {
            dirty = ContaBancariaDestino != null;
       }
      if (dirty) return true;
       dirty = _valorOriginal != Valor;
      if (dirty) return true;
       dirty = _dataOriginal != Data;
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
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       if (_conciliacaoBancariaOrigemOriginal!=null)
       {
          dirty = !_conciliacaoBancariaOrigemOriginal.Equals(ConciliacaoBancariaOrigem);
       }
       else
       {
            dirty = ConciliacaoBancariaOrigem != null;
       }
      if (dirty) return true;
       if (_conciliacaoBancariaDestinoOriginal!=null)
       {
          dirty = !_conciliacaoBancariaDestinoOriginal.Equals(ConciliacaoBancariaDestino);
       }
       else
       {
            dirty = ConciliacaoBancariaDestino != null;
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
       if (_contaBancariaOrigemOriginalCommited!=null)
       {
          dirty = !_contaBancariaOrigemOriginalCommited.Equals(ContaBancariaOrigem);
       }
       else
       {
            dirty = ContaBancariaOrigem != null;
       }
      if (dirty) return true;
       if (_contaBancariaDestinoOriginalCommited!=null)
       {
          dirty = !_contaBancariaDestinoOriginalCommited.Equals(ContaBancariaDestino);
       }
       else
       {
            dirty = ContaBancariaDestino != null;
       }
      if (dirty) return true;
       dirty = _valorOriginalCommited != Valor;
      if (dirty) return true;
       dirty = _dataOriginalCommited != Data;
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
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       if (_conciliacaoBancariaOrigemOriginalCommited!=null)
       {
          dirty = !_conciliacaoBancariaOrigemOriginalCommited.Equals(ConciliacaoBancariaOrigem);
       }
       else
       {
            dirty = ConciliacaoBancariaOrigem != null;
       }
      if (dirty) return true;
       if (_conciliacaoBancariaDestinoOriginalCommited!=null)
       {
          dirty = !_conciliacaoBancariaDestinoOriginalCommited.Equals(ConciliacaoBancariaDestino);
       }
       else
       {
            dirty = ConciliacaoBancariaDestino != null;
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
             case "ContaBancariaOrigem":
                return this.ContaBancariaOrigem;
             case "ContaBancariaDestino":
                return this.ContaBancariaDestino;
             case "Valor":
                return this.Valor;
             case "Data":
                return this.Data;
             case "AcsUsuario":
                return this.AcsUsuario;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "ConciliacaoBancariaOrigem":
                return this.ConciliacaoBancariaOrigem;
             case "ConciliacaoBancariaDestino":
                return this.ConciliacaoBancariaDestino;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (ContaBancariaOrigem!=null)
                ContaBancariaOrigem.ChangeSingleConnection(newConnection);
             if (ContaBancariaDestino!=null)
                ContaBancariaDestino.ChangeSingleConnection(newConnection);
             if (AcsUsuario!=null)
                AcsUsuario.ChangeSingleConnection(newConnection);
             if (ConciliacaoBancariaOrigem!=null)
                ConciliacaoBancariaOrigem.ChangeSingleConnection(newConnection);
             if (ConciliacaoBancariaDestino!=null)
                ConciliacaoBancariaDestino.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(transferencia_bancaria.id_transferencia_bancaria) " ;
               }
               else
               {
               command.CommandText += "transferencia_bancaria.id_transferencia_bancaria, " ;
               command.CommandText += "transferencia_bancaria.id_conta_bancaria_origem, " ;
               command.CommandText += "transferencia_bancaria.id_conta_bancaria_destino, " ;
               command.CommandText += "transferencia_bancaria.trb_valor, " ;
               command.CommandText += "transferencia_bancaria.trb_data, " ;
               command.CommandText += "transferencia_bancaria.id_acs_usuario, " ;
               command.CommandText += "transferencia_bancaria.entity_uid, " ;
               command.CommandText += "transferencia_bancaria.version, " ;
               command.CommandText += "transferencia_bancaria.id_conciliacao_bancaria_origem, " ;
               command.CommandText += "transferencia_bancaria.id_conciliacao_bancaria_destino " ;
               }
               command.CommandText += " FROM  transferencia_bancaria ";
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
                        orderByClause += " , trb_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(trb_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = transferencia_bancaria.id_acs_usuario_ultima_revisao ";
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
                     case "id_transferencia_bancaria":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , transferencia_bancaria.id_transferencia_bancaria " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(transferencia_bancaria.id_transferencia_bancaria) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_conta_bancaria_origem":
                     case "ContaBancariaOrigem":
                     command.CommandText += " LEFT JOIN conta_bancaria as conta_bancaria_ContaBancariaOrigem ON conta_bancaria_ContaBancariaOrigem.id_conta_bancaria = transferencia_bancaria.id_conta_bancaria_origem ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , conta_bancaria_ContaBancariaOrigem.cba_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(conta_bancaria_ContaBancariaOrigem.cba_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_conta_bancaria_destino":
                     case "ContaBancariaDestino":
                     command.CommandText += " LEFT JOIN conta_bancaria as conta_bancaria_ContaBancariaDestino ON conta_bancaria_ContaBancariaDestino.id_conta_bancaria = transferencia_bancaria.id_conta_bancaria_destino ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , conta_bancaria_ContaBancariaDestino.cba_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(conta_bancaria_ContaBancariaDestino.cba_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "trb_valor":
                     case "Valor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , transferencia_bancaria.trb_valor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(transferencia_bancaria.trb_valor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "trb_data":
                     case "Data":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , transferencia_bancaria.trb_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(transferencia_bancaria.trb_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario":
                     case "AcsUsuario":
                     orderByClause += " , transferencia_bancaria.id_acs_usuario " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , transferencia_bancaria.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(transferencia_bancaria.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , transferencia_bancaria.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(transferencia_bancaria.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_conciliacao_bancaria_origem":
                     case "ConciliacaoBancariaOrigem":
                     command.CommandText += " LEFT JOIN conciliacao_bancaria as conciliacao_bancaria_ConciliacaoBancariaOrigem ON conciliacao_bancaria_ConciliacaoBancariaOrigem.id_conciliacao_bancaria = transferencia_bancaria.id_conciliacao_bancaria_origem ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conciliacao_bancaria_ConciliacaoBancariaOrigem.id_conciliacao_bancaria " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conciliacao_bancaria_ConciliacaoBancariaOrigem.id_conciliacao_bancaria) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_conciliacao_bancaria_destino":
                     case "ConciliacaoBancariaDestino":
                     command.CommandText += " LEFT JOIN conciliacao_bancaria as conciliacao_bancaria_ConciliacaoBancariaDestino ON conciliacao_bancaria_ConciliacaoBancariaDestino.id_conciliacao_bancaria = transferencia_bancaria.id_conciliacao_bancaria_destino ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conciliacao_bancaria_ConciliacaoBancariaDestino.id_conciliacao_bancaria " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conciliacao_bancaria_ConciliacaoBancariaDestino.id_conciliacao_bancaria) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           whereClause += " OR UPPER(transferencia_bancaria.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(transferencia_bancaria.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_transferencia_bancaria")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  transferencia_bancaria.id_transferencia_bancaria IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transferencia_bancaria.id_transferencia_bancaria = :transferencia_bancaria_ID_5538 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transferencia_bancaria_ID_5538", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ContaBancariaOrigem" || parametro.FieldName == "id_conta_bancaria_origem")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.ContaBancariaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.ContaBancariaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  transferencia_bancaria.id_conta_bancaria_origem IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transferencia_bancaria.id_conta_bancaria_origem = :transferencia_bancaria_ContaBancariaOrigem_7426 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transferencia_bancaria_ContaBancariaOrigem_7426", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ContaBancariaDestino" || parametro.FieldName == "id_conta_bancaria_destino")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.ContaBancariaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.ContaBancariaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  transferencia_bancaria.id_conta_bancaria_destino IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transferencia_bancaria.id_conta_bancaria_destino = :transferencia_bancaria_ContaBancariaDestino_5280 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transferencia_bancaria_ContaBancariaDestino_5280", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Valor" || parametro.FieldName == "trb_valor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  transferencia_bancaria.trb_valor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transferencia_bancaria.trb_valor = :transferencia_bancaria_Valor_6748 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transferencia_bancaria_Valor_6748", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Data" || parametro.FieldName == "trb_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  transferencia_bancaria.trb_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transferencia_bancaria.trb_data = :transferencia_bancaria_Data_8454 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transferencia_bancaria_Data_8454", NpgsqlDbType.Date, parametro.Fieldvalue));
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
                         whereClause += "  transferencia_bancaria.id_acs_usuario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transferencia_bancaria.id_acs_usuario = :transferencia_bancaria_AcsUsuario_2058 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transferencia_bancaria_AcsUsuario_2058", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  transferencia_bancaria.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transferencia_bancaria.entity_uid LIKE :transferencia_bancaria_EntityUid_7583 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transferencia_bancaria_EntityUid_7583", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  transferencia_bancaria.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transferencia_bancaria.version = :transferencia_bancaria_Version_5742 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transferencia_bancaria_Version_5742", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ConciliacaoBancariaOrigem" || parametro.FieldName == "id_conciliacao_bancaria_origem")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.ConciliacaoBancariaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.ConciliacaoBancariaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  transferencia_bancaria.id_conciliacao_bancaria_origem IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transferencia_bancaria.id_conciliacao_bancaria_origem = :transferencia_bancaria_ConciliacaoBancariaOrigem_9982 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transferencia_bancaria_ConciliacaoBancariaOrigem_9982", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ConciliacaoBancariaDestino" || parametro.FieldName == "id_conciliacao_bancaria_destino")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.ConciliacaoBancariaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.ConciliacaoBancariaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  transferencia_bancaria.id_conciliacao_bancaria_destino IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transferencia_bancaria.id_conciliacao_bancaria_destino = :transferencia_bancaria_ConciliacaoBancariaDestino_4361 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transferencia_bancaria_ConciliacaoBancariaDestino_4361", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  transferencia_bancaria.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  transferencia_bancaria.entity_uid LIKE :transferencia_bancaria_EntityUid_7132 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("transferencia_bancaria_EntityUid_7132", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  TransferenciaBancariaClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (TransferenciaBancariaClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(TransferenciaBancariaClass), Convert.ToInt32(read["id_transferencia_bancaria"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new TransferenciaBancariaClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_transferencia_bancaria"]);
                     if (read["id_conta_bancaria_origem"] != DBNull.Value)
                     {
                        entidade.ContaBancariaOrigem = (BibliotecaEntidades.Entidades.ContaBancariaClass)BibliotecaEntidades.Entidades.ContaBancariaClass.GetEntidade(Convert.ToInt32(read["id_conta_bancaria_origem"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.ContaBancariaOrigem = null ;
                     }
                     if (read["id_conta_bancaria_destino"] != DBNull.Value)
                     {
                        entidade.ContaBancariaDestino = (BibliotecaEntidades.Entidades.ContaBancariaClass)BibliotecaEntidades.Entidades.ContaBancariaClass.GetEntidade(Convert.ToInt32(read["id_conta_bancaria_destino"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.ContaBancariaDestino = null ;
                     }
                     entidade.Valor = (double)read["trb_valor"];
                     entidade.Data = (DateTime)read["trb_data"];
                     if (read["id_acs_usuario"] != DBNull.Value)
                     {
                        entidade.AcsUsuario = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuario = null ;
                     }
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     if (read["id_conciliacao_bancaria_origem"] != DBNull.Value)
                     {
                        entidade.ConciliacaoBancariaOrigem = (BibliotecaEntidades.Entidades.ConciliacaoBancariaClass)BibliotecaEntidades.Entidades.ConciliacaoBancariaClass.GetEntidade(Convert.ToInt32(read["id_conciliacao_bancaria_origem"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.ConciliacaoBancariaOrigem = null ;
                     }
                     if (read["id_conciliacao_bancaria_destino"] != DBNull.Value)
                     {
                        entidade.ConciliacaoBancariaDestino = (BibliotecaEntidades.Entidades.ConciliacaoBancariaClass)BibliotecaEntidades.Entidades.ConciliacaoBancariaClass.GetEntidade(Convert.ToInt32(read["id_conciliacao_bancaria_destino"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.ConciliacaoBancariaDestino = null ;
                     }
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (TransferenciaBancariaClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
