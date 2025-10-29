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
     [Table("pallet","pal")]
     public class PalletBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do PalletClass";
protected const string ErroDelete = "Erro ao excluir o PalletClass  ";
protected const string ErroSave = "Erro ao salvar o PalletClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do PalletClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade PalletClass está sendo utilizada.";
#endregion
       protected int _numeroOriginal{get;private set;}
       private int _numeroOriginalCommited{get; set;}
        private int _valueNumero;
         [Column("pal_numero")]
        public virtual int Numero
         { 
            get { return this._valueNumero; } 
            set 
            { 
                if (this._valueNumero == value)return;
                 this._valueNumero = value; 
            } 
        } 

       protected bool _ocupadoOriginal{get;private set;}
       private bool _ocupadoOriginalCommited{get; set;}
        private bool _valueOcupado;
         [Column("pal_ocupado")]
        public virtual bool Ocupado
         { 
            get { return this._valueOcupado; } 
            set 
            { 
                if (this._valueOcupado == value)return;
                 this._valueOcupado = value; 
            } 
        } 

       protected bool _fechadoOriginal{get;private set;}
       private bool _fechadoOriginalCommited{get; set;}
        private bool _valueFechado;
         [Column("pal_fechado")]
        public virtual bool Fechado
         { 
            get { return this._valueFechado; } 
            set 
            { 
                if (this._valueFechado == value)return;
                 this._valueFechado = value; 
            } 
        } 

       protected bool _especialOriginal{get;private set;}
       private bool _especialOriginalCommited{get; set;}
        private bool _valueEspecial;
         [Column("pal_especial")]
        public virtual bool Especial
         { 
            get { return this._valueEspecial; } 
            set 
            { 
                if (this._valueEspecial == value)return;
                 this._valueEspecial = value; 
            } 
        } 

       protected bool _conferidoOriginal{get;private set;}
       private bool _conferidoOriginalCommited{get; set;}
        private bool _valueConferido;
         [Column("pal_conferido")]
        public virtual bool Conferido
         { 
            get { return this._valueConferido; } 
            set 
            { 
                if (this._valueConferido == value)return;
                 this._valueConferido = value; 
            } 
        } 

       protected long _sequenciaOriginal{get;private set;}
       private long _sequenciaOriginalCommited{get; set;}
        private long _valueSequencia;
         [Column("pal_sequencia")]
        public virtual long Sequencia
         { 
            get { return this._valueSequencia; } 
            set 
            { 
                if (this._valueSequencia == value)return;
                 this._valueSequencia = value; 
            } 
        } 

       protected bool _bloqueadoOriginal{get;private set;}
       private bool _bloqueadoOriginalCommited{get; set;}
        private bool _valueBloqueado;
         [Column("pal_bloqueado")]
        public virtual bool Bloqueado
         { 
            get { return this._valueBloqueado; } 
            set 
            { 
                if (this._valueBloqueado == value)return;
                 this._valueBloqueado = value; 
            } 
        } 

       protected int? _idUsuarioOriginal{get;private set;}
       private int? _idUsuarioOriginalCommited{get; set;}
        private int? _valueIdUsuario;
         [Column("id_usuario")]
        public virtual int? IdUsuario
         { 
            get { return this._valueIdUsuario; } 
            set 
            { 
                if (this._valueIdUsuario == value)return;
                 this._valueIdUsuario = value; 
            } 
        } 

       protected bool _utilizadoMomentoOriginal{get;private set;}
       private bool _utilizadoMomentoOriginalCommited{get; set;}
        private bool _valueUtilizadoMomento;
         [Column("pal_utilizado_momento")]
        public virtual bool UtilizadoMomento
         { 
            get { return this._valueUtilizadoMomento; } 
            set 
            { 
                if (this._valueUtilizadoMomento == value)return;
                 this._valueUtilizadoMomento = value; 
            } 
        } 

        public PalletBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Ocupado = false;
           this.Fechado = false;
           this.Especial = false;
           this.Conferido = false;
           this.Sequencia = 0;
           this.Bloqueado = false;
           this.UtilizadoMomento = false;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static PalletClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (PalletClass) GetEntity(typeof(PalletClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {

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
                    "  public.pallet  " +
                    "WHERE " +
                    "  id_pallet = :id";
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
                        "  public.pallet   " +
                        "SET  " + 
                        "  pal_numero = :pal_numero, " + 
                        "  pal_ocupado = :pal_ocupado, " + 
                        "  pal_fechado = :pal_fechado, " + 
                        "  pal_especial = :pal_especial, " + 
                        "  pal_conferido = :pal_conferido, " + 
                        "  pal_sequencia = :pal_sequencia, " + 
                        "  pal_bloqueado = :pal_bloqueado, " + 
                        "  id_usuario = :id_usuario, " + 
                        "  pal_utilizado_momento = :pal_utilizado_momento, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_pallet = :id " +
                        "RETURNING id_pallet;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.pallet " +
                        "( " +
                        "  pal_numero , " + 
                        "  pal_ocupado , " + 
                        "  pal_fechado , " + 
                        "  pal_especial , " + 
                        "  pal_conferido , " + 
                        "  pal_sequencia , " + 
                        "  pal_bloqueado , " + 
                        "  id_usuario , " + 
                        "  pal_utilizado_momento , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :pal_numero , " + 
                        "  :pal_ocupado , " + 
                        "  :pal_fechado , " + 
                        "  :pal_especial , " + 
                        "  :pal_conferido , " + 
                        "  :pal_sequencia , " + 
                        "  :pal_bloqueado , " + 
                        "  :id_usuario , " + 
                        "  :pal_utilizado_momento , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_pallet;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pal_numero", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Numero ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pal_ocupado", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Ocupado ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pal_fechado", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Fechado ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pal_especial", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Especial ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pal_conferido", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Conferido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pal_sequencia", NpgsqlDbType.Bigint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Sequencia ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pal_bloqueado", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Bloqueado ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_usuario", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IdUsuario ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pal_utilizado_momento", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UtilizadoMomento ?? DBNull.Value;
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
        public static PalletClass CopiarEntidade(PalletClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               PalletClass toRet = new PalletClass(usuario,conn);
 toRet.Numero= entidadeCopiar.Numero;
 toRet.Ocupado= entidadeCopiar.Ocupado;
 toRet.Fechado= entidadeCopiar.Fechado;
 toRet.Especial= entidadeCopiar.Especial;
 toRet.Conferido= entidadeCopiar.Conferido;
 toRet.Sequencia= entidadeCopiar.Sequencia;
 toRet.Bloqueado= entidadeCopiar.Bloqueado;
 toRet.IdUsuario= entidadeCopiar.IdUsuario;
 toRet.UtilizadoMomento= entidadeCopiar.UtilizadoMomento;

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
       _numeroOriginal = Numero;
       _numeroOriginalCommited = _numeroOriginal;
       _ocupadoOriginal = Ocupado;
       _ocupadoOriginalCommited = _ocupadoOriginal;
       _fechadoOriginal = Fechado;
       _fechadoOriginalCommited = _fechadoOriginal;
       _especialOriginal = Especial;
       _especialOriginalCommited = _especialOriginal;
       _conferidoOriginal = Conferido;
       _conferidoOriginalCommited = _conferidoOriginal;
       _sequenciaOriginal = Sequencia;
       _sequenciaOriginalCommited = _sequenciaOriginal;
       _bloqueadoOriginal = Bloqueado;
       _bloqueadoOriginalCommited = _bloqueadoOriginal;
       _idUsuarioOriginal = IdUsuario;
       _idUsuarioOriginalCommited = _idUsuarioOriginal;
       _utilizadoMomentoOriginal = UtilizadoMomento;
       _utilizadoMomentoOriginalCommited = _utilizadoMomentoOriginal;
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
       _numeroOriginalCommited = Numero;
       _ocupadoOriginalCommited = Ocupado;
       _fechadoOriginalCommited = Fechado;
       _especialOriginalCommited = Especial;
       _conferidoOriginalCommited = Conferido;
       _sequenciaOriginalCommited = Sequencia;
       _bloqueadoOriginalCommited = Bloqueado;
       _idUsuarioOriginalCommited = IdUsuario;
       _utilizadoMomentoOriginalCommited = UtilizadoMomento;
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
               Numero=_numeroOriginal;
               _numeroOriginalCommited=_numeroOriginal;
               Ocupado=_ocupadoOriginal;
               _ocupadoOriginalCommited=_ocupadoOriginal;
               Fechado=_fechadoOriginal;
               _fechadoOriginalCommited=_fechadoOriginal;
               Especial=_especialOriginal;
               _especialOriginalCommited=_especialOriginal;
               Conferido=_conferidoOriginal;
               _conferidoOriginalCommited=_conferidoOriginal;
               Sequencia=_sequenciaOriginal;
               _sequenciaOriginalCommited=_sequenciaOriginal;
               Bloqueado=_bloqueadoOriginal;
               _bloqueadoOriginalCommited=_bloqueadoOriginal;
               IdUsuario=_idUsuarioOriginal;
               _idUsuarioOriginalCommited=_idUsuarioOriginal;
               UtilizadoMomento=_utilizadoMomentoOriginal;
               _utilizadoMomentoOriginalCommited=_utilizadoMomentoOriginal;
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
       dirty = _numeroOriginal != Numero;
      if (dirty) return true;
       dirty = _ocupadoOriginal != Ocupado;
      if (dirty) return true;
       dirty = _fechadoOriginal != Fechado;
      if (dirty) return true;
       dirty = _especialOriginal != Especial;
      if (dirty) return true;
       dirty = _conferidoOriginal != Conferido;
      if (dirty) return true;
       dirty = _sequenciaOriginal != Sequencia;
      if (dirty) return true;
       dirty = _bloqueadoOriginal != Bloqueado;
      if (dirty) return true;
       dirty = _idUsuarioOriginal != IdUsuario;
      if (dirty) return true;
       dirty = _utilizadoMomentoOriginal != UtilizadoMomento;
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
       dirty = _numeroOriginalCommited != Numero;
      if (dirty) return true;
       dirty = _ocupadoOriginalCommited != Ocupado;
      if (dirty) return true;
       dirty = _fechadoOriginalCommited != Fechado;
      if (dirty) return true;
       dirty = _especialOriginalCommited != Especial;
      if (dirty) return true;
       dirty = _conferidoOriginalCommited != Conferido;
      if (dirty) return true;
       dirty = _sequenciaOriginalCommited != Sequencia;
      if (dirty) return true;
       dirty = _bloqueadoOriginalCommited != Bloqueado;
      if (dirty) return true;
       dirty = _idUsuarioOriginalCommited != IdUsuario;
      if (dirty) return true;
       dirty = _utilizadoMomentoOriginalCommited != UtilizadoMomento;
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
             case "Numero":
                return this.Numero;
             case "Ocupado":
                return this.Ocupado;
             case "Fechado":
                return this.Fechado;
             case "Especial":
                return this.Especial;
             case "Conferido":
                return this.Conferido;
             case "Sequencia":
                return this.Sequencia;
             case "Bloqueado":
                return this.Bloqueado;
             case "IdUsuario":
                return this.IdUsuario;
             case "UtilizadoMomento":
                return this.UtilizadoMomento;
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
                  command.CommandText += " COUNT(pallet.id_pallet) " ;
               }
               else
               {
               command.CommandText += "pallet.pal_numero, " ;
               command.CommandText += "pallet.pal_ocupado, " ;
               command.CommandText += "pallet.pal_fechado, " ;
               command.CommandText += "pallet.pal_especial, " ;
               command.CommandText += "pallet.pal_conferido, " ;
               command.CommandText += "pallet.pal_sequencia, " ;
               command.CommandText += "pallet.pal_bloqueado, " ;
               command.CommandText += "pallet.id_usuario, " ;
               command.CommandText += "pallet.pal_utilizado_momento, " ;
               command.CommandText += "pallet.entity_uid, " ;
               command.CommandText += "pallet.version, " ;
               command.CommandText += "pallet.id_pallet " ;
               }
               command.CommandText += " FROM  pallet ";
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
                        orderByClause += " , pal_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(pal_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = pallet.id_acs_usuario_ultima_revisao ";
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
                     case "pal_numero":
                     case "Numero":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pallet.pal_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pallet.pal_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pal_ocupado":
                     case "Ocupado":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pallet.pal_ocupado " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pallet.pal_ocupado) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pal_fechado":
                     case "Fechado":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pallet.pal_fechado " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pallet.pal_fechado) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pal_especial":
                     case "Especial":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pallet.pal_especial " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pallet.pal_especial) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pal_conferido":
                     case "Conferido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pallet.pal_conferido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pallet.pal_conferido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pal_sequencia":
                     case "Sequencia":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pallet.pal_sequencia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pallet.pal_sequencia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pal_bloqueado":
                     case "Bloqueado":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pallet.pal_bloqueado " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pallet.pal_bloqueado) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_usuario":
                     case "IdUsuario":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pallet.id_usuario " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pallet.id_usuario) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pal_utilizado_momento":
                     case "UtilizadoMomento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pallet.pal_utilizado_momento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pallet.pal_utilizado_momento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pallet.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pallet.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , pallet.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pallet.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_pallet":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pallet.id_pallet " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pallet.id_pallet) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           whereClause += " OR UPPER(pallet.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pallet.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "Numero" || parametro.FieldName == "pal_numero")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pallet.pal_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pallet.pal_numero = :pallet_Numero_7087 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pallet_Numero_7087", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Ocupado" || parametro.FieldName == "pal_ocupado")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pallet.pal_ocupado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pallet.pal_ocupado = :pallet_Ocupado_4316 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pallet_Ocupado_4316", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Fechado" || parametro.FieldName == "pal_fechado")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pallet.pal_fechado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pallet.pal_fechado = :pallet_Fechado_8686 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pallet_Fechado_8686", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Especial" || parametro.FieldName == "pal_especial")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pallet.pal_especial IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pallet.pal_especial = :pallet_Especial_2726 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pallet_Especial_2726", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Conferido" || parametro.FieldName == "pal_conferido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pallet.pal_conferido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pallet.pal_conferido = :pallet_Conferido_838 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pallet_Conferido_838", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Sequencia" || parametro.FieldName == "pal_sequencia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pallet.pal_sequencia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pallet.pal_sequencia = :pallet_Sequencia_8961 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pallet_Sequencia_8961", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Bloqueado" || parametro.FieldName == "pal_bloqueado")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pallet.pal_bloqueado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pallet.pal_bloqueado = :pallet_Bloqueado_3667 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pallet_Bloqueado_3667", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IdUsuario" || parametro.FieldName == "id_usuario")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pallet.id_usuario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pallet.id_usuario = :pallet_IdUsuario_6553 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pallet_IdUsuario_6553", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UtilizadoMomento" || parametro.FieldName == "pal_utilizado_momento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pallet.pal_utilizado_momento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pallet.pal_utilizado_momento = :pallet_UtilizadoMomento_7822 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pallet_UtilizadoMomento_7822", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
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
                         whereClause += "  pallet.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pallet.entity_uid LIKE :pallet_EntityUid_1572 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pallet_EntityUid_1572", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  pallet.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pallet.version = :pallet_Version_1626 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pallet_Version_1626", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_pallet")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pallet.id_pallet IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pallet.id_pallet = :pallet_ID_3940 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pallet_ID_3940", NpgsqlDbType.Bigint, parametro.Fieldvalue));
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
                         whereClause += "  pallet.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pallet.entity_uid LIKE :pallet_EntityUid_1655 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pallet_EntityUid_1655", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  PalletClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (PalletClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(PalletClass), Convert.ToInt32(read["id_pallet"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new PalletClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.Numero = (int)read["pal_numero"];
                     entidade.Ocupado = Convert.ToBoolean(Convert.ToInt16(read["pal_ocupado"]));
                     entidade.Fechado = Convert.ToBoolean(Convert.ToInt16(read["pal_fechado"]));
                     entidade.Especial = Convert.ToBoolean(Convert.ToInt16(read["pal_especial"]));
                     entidade.Conferido = Convert.ToBoolean(Convert.ToInt16(read["pal_conferido"]));
                     entidade.Sequencia = Convert.ToInt64(read["pal_sequencia"]);
                     entidade.Bloqueado = Convert.ToBoolean(Convert.ToInt16(read["pal_bloqueado"]));
                     entidade.IdUsuario = read["id_usuario"] as int?;
                     entidade.UtilizadoMomento = Convert.ToBoolean(Convert.ToInt16(read["pal_utilizado_momento"]));
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.ID = Convert.ToInt64(read["id_pallet"]);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (PalletClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
