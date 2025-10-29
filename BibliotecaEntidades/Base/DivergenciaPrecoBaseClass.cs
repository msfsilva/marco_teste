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
     [Table("divergencia_preco","div")]
     public class DivergenciaPrecoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do DivergenciaPrecoClass";
protected const string ErroDelete = "Erro ao excluir o DivergenciaPrecoClass  ";
protected const string ErroSave = "Erro ao salvar o DivergenciaPrecoClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do DivergenciaPrecoClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade DivergenciaPrecoClass está sendo utilizada.";
#endregion
       protected string _ocOriginal{get;private set;}
       private string _ocOriginalCommited{get; set;}
        private string _valueOc;
         [Column("div_oc")]
        public virtual string Oc
         { 
            get { return this._valueOc; } 
            set 
            { 
                if (this._valueOc == value)return;
                 this._valueOc = value; 
            } 
        } 

       protected int? _posOriginal{get;private set;}
       private int? _posOriginalCommited{get; set;}
        private int? _valuePos;
         [Column("div_pos")]
        public virtual int? Pos
         { 
            get { return this._valuePos; } 
            set 
            { 
                if (this._valuePos == value)return;
                 this._valuePos = value; 
            } 
        } 

       protected string _mensagemOriginal{get;private set;}
       private string _mensagemOriginalCommited{get; set;}
        private string _valueMensagem;
         [Column("div_mensagem")]
        public virtual string Mensagem
         { 
            get { return this._valueMensagem; } 
            set 
            { 
                if (this._valueMensagem == value)return;
                 this._valueMensagem = value; 
            } 
        } 

       protected double? _precoTabelaOriginal{get;private set;}
       private double? _precoTabelaOriginalCommited{get; set;}
        private double? _valuePrecoTabela;
         [Column("div_preco_tabela")]
        public virtual double? PrecoTabela
         { 
            get { return this._valuePrecoTabela; } 
            set 
            { 
                if (this._valuePrecoTabela == value)return;
                 this._valuePrecoTabela = value; 
            } 
        } 

       protected double? _precoPedidoOriginal{get;private set;}
       private double? _precoPedidoOriginalCommited{get; set;}
        private double? _valuePrecoPedido;
         [Column("div_preco_pedido")]
        public virtual double? PrecoPedido
         { 
            get { return this._valuePrecoPedido; } 
            set 
            { 
                if (this._valuePrecoPedido == value)return;
                 this._valuePrecoPedido = value; 
            } 
        } 

       protected double? _precoClienteOriginal{get;private set;}
       private double? _precoClienteOriginalCommited{get; set;}
        private double? _valuePrecoCliente;
         [Column("div_preco_cliente")]
        public virtual double? PrecoCliente
         { 
            get { return this._valuePrecoCliente; } 
            set 
            { 
                if (this._valuePrecoCliente == value)return;
                 this._valuePrecoCliente = value; 
            } 
        } 

       protected string _usuarioOriginal{get;private set;}
       private string _usuarioOriginalCommited{get; set;}
        private string _valueUsuario;
         [Column("div_usuario")]
        public virtual string Usuario
         { 
            get { return this._valueUsuario; } 
            set 
            { 
                if (this._valueUsuario == value)return;
                 this._valueUsuario = value; 
            } 
        } 

       protected DateTime? _datahoraOriginal{get;private set;}
       private DateTime? _datahoraOriginalCommited{get; set;}
        private DateTime? _valueDatahora;
         [Column("div_datahora")]
        public virtual DateTime? Datahora
         { 
            get { return this._valueDatahora; } 
            set 
            { 
                if (this._valueDatahora == value)return;
                 this._valueDatahora = value; 
            } 
        } 

       protected StatusDivergenciaPreco _statusOriginal{get;private set;}
       private StatusDivergenciaPreco _statusOriginalCommited{get; set;}
        private StatusDivergenciaPreco _valueStatus;
         [Column("div_status")]
        public virtual StatusDivergenciaPreco Status
         { 
            get { return this._valueStatus; } 
            set 
            { 
                if (this._valueStatus == value)return;
                 this._valueStatus = value; 
            } 
        } 

        public bool Status_Pendente
         { 
            get { return this._valueStatus == BibliotecaEntidades.Base.StatusDivergenciaPreco.Pendente; } 
            set { if (value) this._valueStatus = BibliotecaEntidades.Base.StatusDivergenciaPreco.Pendente; }
         } 

        public bool Status_Encerrada
         { 
            get { return this._valueStatus == BibliotecaEntidades.Base.StatusDivergenciaPreco.Encerrada; } 
            set { if (value) this._valueStatus = BibliotecaEntidades.Base.StatusDivergenciaPreco.Encerrada; }
         } 

       protected string _codigoItemOriginal{get;private set;}
       private string _codigoItemOriginalCommited{get; set;}
        private string _valueCodigoItem;
         [Column("div_codigo_item")]
        public virtual string CodigoItem
         { 
            get { return this._valueCodigoItem; } 
            set 
            { 
                if (this._valueCodigoItem == value)return;
                 this._valueCodigoItem = value; 
            } 
        } 

        public DivergenciaPrecoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Status = (StatusDivergenciaPreco)0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static DivergenciaPrecoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (DivergenciaPrecoClass) GetEntity(typeof(DivergenciaPrecoClass),id,usuarioAtual,connection, operacao);
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
                    "  public.divergencia_preco  " +
                    "WHERE " +
                    "  id_divergencia_preco = :id";
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
                        "  public.divergencia_preco   " +
                        "SET  " + 
                        "  div_oc = :div_oc, " + 
                        "  div_pos = :div_pos, " + 
                        "  div_mensagem = :div_mensagem, " + 
                        "  div_preco_tabela = :div_preco_tabela, " + 
                        "  div_preco_pedido = :div_preco_pedido, " + 
                        "  div_preco_cliente = :div_preco_cliente, " + 
                        "  div_usuario = :div_usuario, " + 
                        "  div_datahora = :div_datahora, " + 
                        "  div_status = :div_status, " + 
                        "  div_codigo_item = :div_codigo_item, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_divergencia_preco = :id " +
                        "RETURNING id_divergencia_preco;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.divergencia_preco " +
                        "( " +
                        "  div_oc , " + 
                        "  div_pos , " + 
                        "  div_mensagem , " + 
                        "  div_preco_tabela , " + 
                        "  div_preco_pedido , " + 
                        "  div_preco_cliente , " + 
                        "  div_usuario , " + 
                        "  div_datahora , " + 
                        "  div_status , " + 
                        "  div_codigo_item , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :div_oc , " + 
                        "  :div_pos , " + 
                        "  :div_mensagem , " + 
                        "  :div_preco_tabela , " + 
                        "  :div_preco_pedido , " + 
                        "  :div_preco_cliente , " + 
                        "  :div_usuario , " + 
                        "  :div_datahora , " + 
                        "  :div_status , " + 
                        "  :div_codigo_item , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_divergencia_preco;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("div_oc", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Oc ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("div_pos", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Pos ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("div_mensagem", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Mensagem ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("div_preco_tabela", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PrecoTabela ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("div_preco_pedido", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PrecoPedido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("div_preco_cliente", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PrecoCliente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("div_usuario", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Usuario ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("div_datahora", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Datahora ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("div_status", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Status);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("div_codigo_item", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CodigoItem ?? DBNull.Value;
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
        public static DivergenciaPrecoClass CopiarEntidade(DivergenciaPrecoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               DivergenciaPrecoClass toRet = new DivergenciaPrecoClass(usuario,conn);
 toRet.Oc= entidadeCopiar.Oc;
 toRet.Pos= entidadeCopiar.Pos;
 toRet.Mensagem= entidadeCopiar.Mensagem;
 toRet.PrecoTabela= entidadeCopiar.PrecoTabela;
 toRet.PrecoPedido= entidadeCopiar.PrecoPedido;
 toRet.PrecoCliente= entidadeCopiar.PrecoCliente;
 toRet.Usuario= entidadeCopiar.Usuario;
 toRet.Datahora= entidadeCopiar.Datahora;
 toRet.Status= entidadeCopiar.Status;
 toRet.CodigoItem= entidadeCopiar.CodigoItem;

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
       _ocOriginal = Oc;
       _ocOriginalCommited = _ocOriginal;
       _posOriginal = Pos;
       _posOriginalCommited = _posOriginal;
       _mensagemOriginal = Mensagem;
       _mensagemOriginalCommited = _mensagemOriginal;
       _precoTabelaOriginal = PrecoTabela;
       _precoTabelaOriginalCommited = _precoTabelaOriginal;
       _precoPedidoOriginal = PrecoPedido;
       _precoPedidoOriginalCommited = _precoPedidoOriginal;
       _precoClienteOriginal = PrecoCliente;
       _precoClienteOriginalCommited = _precoClienteOriginal;
       _usuarioOriginal = Usuario;
       _usuarioOriginalCommited = _usuarioOriginal;
       _datahoraOriginal = Datahora;
       _datahoraOriginalCommited = _datahoraOriginal;
       _statusOriginal = Status;
       _statusOriginalCommited = _statusOriginal;
       _codigoItemOriginal = CodigoItem;
       _codigoItemOriginalCommited = _codigoItemOriginal;
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
       _ocOriginalCommited = Oc;
       _posOriginalCommited = Pos;
       _mensagemOriginalCommited = Mensagem;
       _precoTabelaOriginalCommited = PrecoTabela;
       _precoPedidoOriginalCommited = PrecoPedido;
       _precoClienteOriginalCommited = PrecoCliente;
       _usuarioOriginalCommited = Usuario;
       _datahoraOriginalCommited = Datahora;
       _statusOriginalCommited = Status;
       _codigoItemOriginalCommited = CodigoItem;
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
               Oc=_ocOriginal;
               _ocOriginalCommited=_ocOriginal;
               Pos=_posOriginal;
               _posOriginalCommited=_posOriginal;
               Mensagem=_mensagemOriginal;
               _mensagemOriginalCommited=_mensagemOriginal;
               PrecoTabela=_precoTabelaOriginal;
               _precoTabelaOriginalCommited=_precoTabelaOriginal;
               PrecoPedido=_precoPedidoOriginal;
               _precoPedidoOriginalCommited=_precoPedidoOriginal;
               PrecoCliente=_precoClienteOriginal;
               _precoClienteOriginalCommited=_precoClienteOriginal;
               Usuario=_usuarioOriginal;
               _usuarioOriginalCommited=_usuarioOriginal;
               Datahora=_datahoraOriginal;
               _datahoraOriginalCommited=_datahoraOriginal;
               Status=_statusOriginal;
               _statusOriginalCommited=_statusOriginal;
               CodigoItem=_codigoItemOriginal;
               _codigoItemOriginalCommited=_codigoItemOriginal;
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
       dirty = _ocOriginal != Oc;
      if (dirty) return true;
       dirty = _posOriginal != Pos;
      if (dirty) return true;
       dirty = _mensagemOriginal != Mensagem;
      if (dirty) return true;
       dirty = _precoTabelaOriginal != PrecoTabela;
      if (dirty) return true;
       dirty = _precoPedidoOriginal != PrecoPedido;
      if (dirty) return true;
       dirty = _precoClienteOriginal != PrecoCliente;
      if (dirty) return true;
       dirty = _usuarioOriginal != Usuario;
      if (dirty) return true;
       dirty = _datahoraOriginal != Datahora;
      if (dirty) return true;
       dirty = _statusOriginal != Status;
      if (dirty) return true;
       dirty = _codigoItemOriginal != CodigoItem;
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
       dirty = _ocOriginalCommited != Oc;
      if (dirty) return true;
       dirty = _posOriginalCommited != Pos;
      if (dirty) return true;
       dirty = _mensagemOriginalCommited != Mensagem;
      if (dirty) return true;
       dirty = _precoTabelaOriginalCommited != PrecoTabela;
      if (dirty) return true;
       dirty = _precoPedidoOriginalCommited != PrecoPedido;
      if (dirty) return true;
       dirty = _precoClienteOriginalCommited != PrecoCliente;
      if (dirty) return true;
       dirty = _usuarioOriginalCommited != Usuario;
      if (dirty) return true;
       dirty = _datahoraOriginalCommited != Datahora;
      if (dirty) return true;
       dirty = _statusOriginalCommited != Status;
      if (dirty) return true;
       dirty = _codigoItemOriginalCommited != CodigoItem;
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
             case "Oc":
                return this.Oc;
             case "Pos":
                return this.Pos;
             case "Mensagem":
                return this.Mensagem;
             case "PrecoTabela":
                return this.PrecoTabela;
             case "PrecoPedido":
                return this.PrecoPedido;
             case "PrecoCliente":
                return this.PrecoCliente;
             case "Usuario":
                return this.Usuario;
             case "Datahora":
                return this.Datahora;
             case "Status":
                return this.Status;
             case "CodigoItem":
                return this.CodigoItem;
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
                  command.CommandText += " COUNT(divergencia_preco.id_divergencia_preco) " ;
               }
               else
               {
               command.CommandText += "divergencia_preco.id_divergencia_preco, " ;
               command.CommandText += "divergencia_preco.div_oc, " ;
               command.CommandText += "divergencia_preco.div_pos, " ;
               command.CommandText += "divergencia_preco.div_mensagem, " ;
               command.CommandText += "divergencia_preco.div_preco_tabela, " ;
               command.CommandText += "divergencia_preco.div_preco_pedido, " ;
               command.CommandText += "divergencia_preco.div_preco_cliente, " ;
               command.CommandText += "divergencia_preco.div_usuario, " ;
               command.CommandText += "divergencia_preco.div_datahora, " ;
               command.CommandText += "divergencia_preco.div_status, " ;
               command.CommandText += "divergencia_preco.div_codigo_item, " ;
               command.CommandText += "divergencia_preco.entity_uid, " ;
               command.CommandText += "divergencia_preco.version " ;
               }
               command.CommandText += " FROM  divergencia_preco ";
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
                        orderByClause += " , div_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(div_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = divergencia_preco.id_acs_usuario_ultima_revisao ";
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
                     case "id_divergencia_preco":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , divergencia_preco.id_divergencia_preco " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(divergencia_preco.id_divergencia_preco) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "div_oc":
                     case "Oc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , divergencia_preco.div_oc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(divergencia_preco.div_oc) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "div_pos":
                     case "Pos":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , divergencia_preco.div_pos " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(divergencia_preco.div_pos) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "div_mensagem":
                     case "Mensagem":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , divergencia_preco.div_mensagem " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(divergencia_preco.div_mensagem) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "div_preco_tabela":
                     case "PrecoTabela":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , divergencia_preco.div_preco_tabela " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(divergencia_preco.div_preco_tabela) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "div_preco_pedido":
                     case "PrecoPedido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , divergencia_preco.div_preco_pedido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(divergencia_preco.div_preco_pedido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "div_preco_cliente":
                     case "PrecoCliente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , divergencia_preco.div_preco_cliente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(divergencia_preco.div_preco_cliente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "div_usuario":
                     case "Usuario":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , divergencia_preco.div_usuario " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(divergencia_preco.div_usuario) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "div_datahora":
                     case "Datahora":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , divergencia_preco.div_datahora " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(divergencia_preco.div_datahora) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "div_status":
                     case "Status":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , divergencia_preco.div_status " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(divergencia_preco.div_status) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "div_codigo_item":
                     case "CodigoItem":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , divergencia_preco.div_codigo_item " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(divergencia_preco.div_codigo_item) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , divergencia_preco.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(divergencia_preco.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , divergencia_preco.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(divergencia_preco.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("div_oc")) 
                        {
                           whereClause += " OR UPPER(divergencia_preco.div_oc) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(divergencia_preco.div_oc) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("div_mensagem")) 
                        {
                           whereClause += " OR UPPER(divergencia_preco.div_mensagem) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(divergencia_preco.div_mensagem) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("div_usuario")) 
                        {
                           whereClause += " OR UPPER(divergencia_preco.div_usuario) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(divergencia_preco.div_usuario) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("div_codigo_item")) 
                        {
                           whereClause += " OR UPPER(divergencia_preco.div_codigo_item) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(divergencia_preco.div_codigo_item) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(divergencia_preco.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(divergencia_preco.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_divergencia_preco")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  divergencia_preco.id_divergencia_preco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  divergencia_preco.id_divergencia_preco = :divergencia_preco_ID_8536 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("divergencia_preco_ID_8536", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Oc" || parametro.FieldName == "div_oc")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  divergencia_preco.div_oc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  divergencia_preco.div_oc LIKE :divergencia_preco_Oc_2426 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("divergencia_preco_Oc_2426", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Pos" || parametro.FieldName == "div_pos")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  divergencia_preco.div_pos IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  divergencia_preco.div_pos = :divergencia_preco_Pos_5672 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("divergencia_preco_Pos_5672", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Mensagem" || parametro.FieldName == "div_mensagem")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  divergencia_preco.div_mensagem IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  divergencia_preco.div_mensagem LIKE :divergencia_preco_Mensagem_9346 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("divergencia_preco_Mensagem_9346", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PrecoTabela" || parametro.FieldName == "div_preco_tabela")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  divergencia_preco.div_preco_tabela IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  divergencia_preco.div_preco_tabela = :divergencia_preco_PrecoTabela_7335 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("divergencia_preco_PrecoTabela_7335", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PrecoPedido" || parametro.FieldName == "div_preco_pedido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  divergencia_preco.div_preco_pedido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  divergencia_preco.div_preco_pedido = :divergencia_preco_PrecoPedido_2721 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("divergencia_preco_PrecoPedido_2721", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PrecoCliente" || parametro.FieldName == "div_preco_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  divergencia_preco.div_preco_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  divergencia_preco.div_preco_cliente = :divergencia_preco_PrecoCliente_195 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("divergencia_preco_PrecoCliente_195", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Usuario" || parametro.FieldName == "div_usuario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  divergencia_preco.div_usuario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  divergencia_preco.div_usuario LIKE :divergencia_preco_Usuario_8383 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("divergencia_preco_Usuario_8383", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Datahora" || parametro.FieldName == "div_datahora")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  divergencia_preco.div_datahora IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  divergencia_preco.div_datahora = :divergencia_preco_Datahora_175 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("divergencia_preco_Datahora_175", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Status" || parametro.FieldName == "div_status")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is StatusDivergenciaPreco)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo StatusDivergenciaPreco");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  divergencia_preco.div_status IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  divergencia_preco.div_status = :divergencia_preco_Status_5566 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("divergencia_preco_Status_5566", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoItem" || parametro.FieldName == "div_codigo_item")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  divergencia_preco.div_codigo_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  divergencia_preco.div_codigo_item LIKE :divergencia_preco_CodigoItem_6880 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("divergencia_preco_CodigoItem_6880", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  divergencia_preco.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  divergencia_preco.entity_uid LIKE :divergencia_preco_EntityUid_5180 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("divergencia_preco_EntityUid_5180", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  divergencia_preco.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  divergencia_preco.version = :divergencia_preco_Version_5277 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("divergencia_preco_Version_5277", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OcExato" || parametro.FieldName == "OcExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  divergencia_preco.div_oc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  divergencia_preco.div_oc LIKE :divergencia_preco_Oc_3635 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("divergencia_preco_Oc_3635", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MensagemExato" || parametro.FieldName == "MensagemExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  divergencia_preco.div_mensagem IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  divergencia_preco.div_mensagem LIKE :divergencia_preco_Mensagem_8829 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("divergencia_preco_Mensagem_8829", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UsuarioExato" || parametro.FieldName == "UsuarioExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  divergencia_preco.div_usuario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  divergencia_preco.div_usuario LIKE :divergencia_preco_Usuario_6350 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("divergencia_preco_Usuario_6350", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoItemExato" || parametro.FieldName == "CodigoItemExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  divergencia_preco.div_codigo_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  divergencia_preco.div_codigo_item LIKE :divergencia_preco_CodigoItem_5213 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("divergencia_preco_CodigoItem_5213", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  divergencia_preco.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  divergencia_preco.entity_uid LIKE :divergencia_preco_EntityUid_7181 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("divergencia_preco_EntityUid_7181", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  DivergenciaPrecoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (DivergenciaPrecoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(DivergenciaPrecoClass), Convert.ToInt32(read["id_divergencia_preco"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new DivergenciaPrecoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_divergencia_preco"]);
                     entidade.Oc = (read["div_oc"] != DBNull.Value ? read["div_oc"].ToString() : null);
                     entidade.Pos = read["div_pos"] as int?;
                     entidade.Mensagem = (read["div_mensagem"] != DBNull.Value ? read["div_mensagem"].ToString() : null);
                     entidade.PrecoTabela = read["div_preco_tabela"] as double?;
                     entidade.PrecoPedido = read["div_preco_pedido"] as double?;
                     entidade.PrecoCliente = read["div_preco_cliente"] as double?;
                     entidade.Usuario = (read["div_usuario"] != DBNull.Value ? read["div_usuario"].ToString() : null);
                     entidade.Datahora = read["div_datahora"] as DateTime?;
                     entidade.Status = (StatusDivergenciaPreco) (read["div_status"] != DBNull.Value ? Enum.ToObject(typeof(StatusDivergenciaPreco), read["div_status"]) : null);
                     entidade.CodigoItem = (read["div_codigo_item"] != DBNull.Value ? read["div_codigo_item"].ToString() : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (DivergenciaPrecoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
