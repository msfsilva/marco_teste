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
     [Table("dashboard_pedidos","dap")]
     public class DashboardPedidosBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do DashboardPedidosClass";
protected const string ErroDelete = "Erro ao excluir o DashboardPedidosClass  ";
protected const string ErroSave = "Erro ao salvar o DashboardPedidosClass.";
protected const string ErroPedidoObrigatorio = "O campo Pedido é obrigatório";
protected const string ErroPedidoComprimento = "O campo Pedido deve ter no máximo 255 caracteres";
protected const string ErroClienteObrigatorio = "O campo Cliente é obrigatório";
protected const string ErroClienteComprimento = "O campo Cliente deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do DashboardPedidosClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade DashboardPedidosClass está sendo utilizada.";
#endregion
       protected string _pedidoOriginal{get;private set;}
       private string _pedidoOriginalCommited{get; set;}
        private string _valuePedido;
         [Column("dap_pedido")]
        public virtual string Pedido
         { 
            get { return this._valuePedido; } 
            set 
            { 
                if (this._valuePedido == value)return;
                 this._valuePedido = value; 
            } 
        } 

       protected string _clienteOriginal{get;private set;}
       private string _clienteOriginalCommited{get; set;}
        private string _valueCliente;
         [Column("dap_cliente")]
        public virtual string Cliente
         { 
            get { return this._valueCliente; } 
            set 
            { 
                if (this._valueCliente == value)return;
                 this._valueCliente = value; 
            } 
        } 

       protected DateTime _dataEntregaOriginal{get;private set;}
       private DateTime _dataEntregaOriginalCommited{get; set;}
        private DateTime _valueDataEntrega;
         [Column("dap_data_entrega")]
        public virtual DateTime DataEntrega
         { 
            get { return this._valueDataEntrega; } 
            set 
            { 
                if (this._valueDataEntrega == value)return;
                 this._valueDataEntrega = value; 
            } 
        } 

       protected int _semanaOriginal{get;private set;}
       private int _semanaOriginalCommited{get; set;}
        private int _valueSemana;
         [Column("dap_semana")]
        public virtual int Semana
         { 
            get { return this._valueSemana; } 
            set 
            { 
                if (this._valueSemana == value)return;
                 this._valueSemana = value; 
            } 
        } 

       protected int _anoSemanaOriginal{get;private set;}
       private int _anoSemanaOriginalCommited{get; set;}
        private int _valueAnoSemana;
         [Column("dap_ano_semana")]
        public virtual int AnoSemana
         { 
            get { return this._valueAnoSemana; } 
            set 
            { 
                if (this._valueAnoSemana == value)return;
                 this._valueAnoSemana = value; 
            } 
        } 

       protected EasiDashboardSituacaoPedido _statusOriginal{get;private set;}
       private EasiDashboardSituacaoPedido _statusOriginalCommited{get; set;}
        private EasiDashboardSituacaoPedido _valueStatus;
         [Column("dap_status")]
        public virtual EasiDashboardSituacaoPedido Status
         { 
            get { return this._valueStatus; } 
            set 
            { 
                if (this._valueStatus == value)return;
                 this._valueStatus = value; 
            } 
        } 

        public bool Status_Bloqueado
         { 
            get { return this._valueStatus == BibliotecaEntidades.Base.EasiDashboardSituacaoPedido.Bloqueado; } 
            set { if (value) this._valueStatus = BibliotecaEntidades.Base.EasiDashboardSituacaoPedido.Bloqueado; }
         } 

        public bool Status_Atrasado
         { 
            get { return this._valueStatus == BibliotecaEntidades.Base.EasiDashboardSituacaoPedido.Atrasado; } 
            set { if (value) this._valueStatus = BibliotecaEntidades.Base.EasiDashboardSituacaoPedido.Atrasado; }
         } 

        public bool Status_Finalizado
         { 
            get { return this._valueStatus == BibliotecaEntidades.Base.EasiDashboardSituacaoPedido.Finalizado; } 
            set { if (value) this._valueStatus = BibliotecaEntidades.Base.EasiDashboardSituacaoPedido.Finalizado; }
         } 

        public bool Status_ParaSemana
         { 
            get { return this._valueStatus == BibliotecaEntidades.Base.EasiDashboardSituacaoPedido.ParaSemana; } 
            set { if (value) this._valueStatus = BibliotecaEntidades.Base.EasiDashboardSituacaoPedido.ParaSemana; }
         } 

        public bool Status_NoPrazo
         { 
            get { return this._valueStatus == BibliotecaEntidades.Base.EasiDashboardSituacaoPedido.NoPrazo; } 
            set { if (value) this._valueStatus = BibliotecaEntidades.Base.EasiDashboardSituacaoPedido.NoPrazo; }
         } 

       protected SipaDashboardSituacaoProcesso _configuracaoOriginal{get;private set;}
       private SipaDashboardSituacaoProcesso _configuracaoOriginalCommited{get; set;}
        private SipaDashboardSituacaoProcesso _valueConfiguracao;
         [Column("dap_configuracao")]
        public virtual SipaDashboardSituacaoProcesso Configuracao
         { 
            get { return this._valueConfiguracao; } 
            set 
            { 
                if (this._valueConfiguracao == value)return;
                 this._valueConfiguracao = value; 
            } 
        } 

        public bool Configuracao_NaoConcluido
         { 
            get { return this._valueConfiguracao == BibliotecaEntidades.Base.SipaDashboardSituacaoProcesso.NaoConcluido; } 
            set { if (value) this._valueConfiguracao = BibliotecaEntidades.Base.SipaDashboardSituacaoProcesso.NaoConcluido; }
         } 

        public bool Configuracao_Concluido
         { 
            get { return this._valueConfiguracao == BibliotecaEntidades.Base.SipaDashboardSituacaoProcesso.Concluido; } 
            set { if (value) this._valueConfiguracao = BibliotecaEntidades.Base.SipaDashboardSituacaoProcesso.Concluido; }
         } 

        public bool Configuracao_ConcluidoComAtraso
         { 
            get { return this._valueConfiguracao == BibliotecaEntidades.Base.SipaDashboardSituacaoProcesso.ConcluidoComAtraso; } 
            set { if (value) this._valueConfiguracao = BibliotecaEntidades.Base.SipaDashboardSituacaoProcesso.ConcluidoComAtraso; }
         } 

       protected SipaDashboardSituacaoProcesso _producaoOriginal{get;private set;}
       private SipaDashboardSituacaoProcesso _producaoOriginalCommited{get; set;}
        private SipaDashboardSituacaoProcesso _valueProducao;
         [Column("dap_producao")]
        public virtual SipaDashboardSituacaoProcesso Producao
         { 
            get { return this._valueProducao; } 
            set 
            { 
                if (this._valueProducao == value)return;
                 this._valueProducao = value; 
            } 
        } 

        public bool Producao_NaoConcluido
         { 
            get { return this._valueProducao == BibliotecaEntidades.Base.SipaDashboardSituacaoProcesso.NaoConcluido; } 
            set { if (value) this._valueProducao = BibliotecaEntidades.Base.SipaDashboardSituacaoProcesso.NaoConcluido; }
         } 

        public bool Producao_Concluido
         { 
            get { return this._valueProducao == BibliotecaEntidades.Base.SipaDashboardSituacaoProcesso.Concluido; } 
            set { if (value) this._valueProducao = BibliotecaEntidades.Base.SipaDashboardSituacaoProcesso.Concluido; }
         } 

        public bool Producao_ConcluidoComAtraso
         { 
            get { return this._valueProducao == BibliotecaEntidades.Base.SipaDashboardSituacaoProcesso.ConcluidoComAtraso; } 
            set { if (value) this._valueProducao = BibliotecaEntidades.Base.SipaDashboardSituacaoProcesso.ConcluidoComAtraso; }
         } 

       protected SipaDashboardSituacaoProcesso _conferenciaOriginal{get;private set;}
       private SipaDashboardSituacaoProcesso _conferenciaOriginalCommited{get; set;}
        private SipaDashboardSituacaoProcesso _valueConferencia;
         [Column("dap_conferencia")]
        public virtual SipaDashboardSituacaoProcesso Conferencia
         { 
            get { return this._valueConferencia; } 
            set 
            { 
                if (this._valueConferencia == value)return;
                 this._valueConferencia = value; 
            } 
        } 

        public bool Conferencia_NaoConcluido
         { 
            get { return this._valueConferencia == BibliotecaEntidades.Base.SipaDashboardSituacaoProcesso.NaoConcluido; } 
            set { if (value) this._valueConferencia = BibliotecaEntidades.Base.SipaDashboardSituacaoProcesso.NaoConcluido; }
         } 

        public bool Conferencia_Concluido
         { 
            get { return this._valueConferencia == BibliotecaEntidades.Base.SipaDashboardSituacaoProcesso.Concluido; } 
            set { if (value) this._valueConferencia = BibliotecaEntidades.Base.SipaDashboardSituacaoProcesso.Concluido; }
         } 

        public bool Conferencia_ConcluidoComAtraso
         { 
            get { return this._valueConferencia == BibliotecaEntidades.Base.SipaDashboardSituacaoProcesso.ConcluidoComAtraso; } 
            set { if (value) this._valueConferencia = BibliotecaEntidades.Base.SipaDashboardSituacaoProcesso.ConcluidoComAtraso; }
         } 

       protected SipaDashboardSituacaoProcesso _embarqueOriginal{get;private set;}
       private SipaDashboardSituacaoProcesso _embarqueOriginalCommited{get; set;}
        private SipaDashboardSituacaoProcesso _valueEmbarque;
         [Column("dap_embarque")]
        public virtual SipaDashboardSituacaoProcesso Embarque
         { 
            get { return this._valueEmbarque; } 
            set 
            { 
                if (this._valueEmbarque == value)return;
                 this._valueEmbarque = value; 
            } 
        } 

        public bool Embarque_NaoConcluido
         { 
            get { return this._valueEmbarque == BibliotecaEntidades.Base.SipaDashboardSituacaoProcesso.NaoConcluido; } 
            set { if (value) this._valueEmbarque = BibliotecaEntidades.Base.SipaDashboardSituacaoProcesso.NaoConcluido; }
         } 

        public bool Embarque_Concluido
         { 
            get { return this._valueEmbarque == BibliotecaEntidades.Base.SipaDashboardSituacaoProcesso.Concluido; } 
            set { if (value) this._valueEmbarque = BibliotecaEntidades.Base.SipaDashboardSituacaoProcesso.Concluido; }
         } 

        public bool Embarque_ConcluidoComAtraso
         { 
            get { return this._valueEmbarque == BibliotecaEntidades.Base.SipaDashboardSituacaoProcesso.ConcluidoComAtraso; } 
            set { if (value) this._valueEmbarque = BibliotecaEntidades.Base.SipaDashboardSituacaoProcesso.ConcluidoComAtraso; }
         } 

       protected SipaDashboardSituacaoProcesso _faturamentoOriginal{get;private set;}
       private SipaDashboardSituacaoProcesso _faturamentoOriginalCommited{get; set;}
        private SipaDashboardSituacaoProcesso _valueFaturamento;
         [Column("dap_faturamento")]
        public virtual SipaDashboardSituacaoProcesso Faturamento
         { 
            get { return this._valueFaturamento; } 
            set 
            { 
                if (this._valueFaturamento == value)return;
                 this._valueFaturamento = value; 
            } 
        } 

        public bool Faturamento_NaoConcluido
         { 
            get { return this._valueFaturamento == BibliotecaEntidades.Base.SipaDashboardSituacaoProcesso.NaoConcluido; } 
            set { if (value) this._valueFaturamento = BibliotecaEntidades.Base.SipaDashboardSituacaoProcesso.NaoConcluido; }
         } 

        public bool Faturamento_Concluido
         { 
            get { return this._valueFaturamento == BibliotecaEntidades.Base.SipaDashboardSituacaoProcesso.Concluido; } 
            set { if (value) this._valueFaturamento = BibliotecaEntidades.Base.SipaDashboardSituacaoProcesso.Concluido; }
         } 

        public bool Faturamento_ConcluidoComAtraso
         { 
            get { return this._valueFaturamento == BibliotecaEntidades.Base.SipaDashboardSituacaoProcesso.ConcluidoComAtraso; } 
            set { if (value) this._valueFaturamento = BibliotecaEntidades.Base.SipaDashboardSituacaoProcesso.ConcluidoComAtraso; }
         } 

       protected double _valorOriginal{get;private set;}
       private double _valorOriginalCommited{get; set;}
        private double _valueValor;
         [Column("dap_valor")]
        public virtual double Valor
         { 
            get { return this._valueValor; } 
            set 
            { 
                if (this._valueValor == value)return;
                 this._valueValor = value; 
            } 
        } 

       protected bool _urgenteOriginal{get;private set;}
       private bool _urgenteOriginalCommited{get; set;}
        private bool _valueUrgente;
         [Column("dap_urgente")]
        public virtual bool Urgente
         { 
            get { return this._valueUrgente; } 
            set 
            { 
                if (this._valueUrgente == value)return;
                 this._valueUrgente = value; 
            } 
        } 

        public DashboardPedidosBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Configuracao = (SipaDashboardSituacaoProcesso)0;
           this.Producao = (SipaDashboardSituacaoProcesso)0;
           this.Conferencia = (SipaDashboardSituacaoProcesso)0;
           this.Embarque = (SipaDashboardSituacaoProcesso)0;
           this.Faturamento = (SipaDashboardSituacaoProcesso)0;
           this.Valor = 0;
           this.Urgente = false;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static DashboardPedidosClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (DashboardPedidosClass) GetEntity(typeof(DashboardPedidosClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Pedido))
                {
                    throw new Exception(ErroPedidoObrigatorio);
                }
                if (Pedido.Length >255)
                {
                    throw new Exception( ErroPedidoComprimento);
                }
                if (string.IsNullOrEmpty(Cliente))
                {
                    throw new Exception(ErroClienteObrigatorio);
                }
                if (Cliente.Length >255)
                {
                    throw new Exception( ErroClienteComprimento);
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
                    "  public.dashboard_pedidos  " +
                    "WHERE " +
                    "  id_dashboard_pedidos = :id";
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
                        "  public.dashboard_pedidos   " +
                        "SET  " + 
                        "  dap_pedido = :dap_pedido, " + 
                        "  dap_cliente = :dap_cliente, " + 
                        "  dap_data_entrega = :dap_data_entrega, " + 
                        "  dap_semana = :dap_semana, " + 
                        "  dap_ano_semana = :dap_ano_semana, " + 
                        "  dap_status = :dap_status, " + 
                        "  dap_configuracao = :dap_configuracao, " + 
                        "  dap_producao = :dap_producao, " + 
                        "  dap_conferencia = :dap_conferencia, " + 
                        "  dap_embarque = :dap_embarque, " + 
                        "  dap_faturamento = :dap_faturamento, " + 
                        "  dap_valor = :dap_valor, " + 
                        "  dap_urgente = :dap_urgente, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_dashboard_pedidos = :id " +
                        "RETURNING id_dashboard_pedidos;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.dashboard_pedidos " +
                        "( " +
                        "  dap_pedido , " + 
                        "  dap_cliente , " + 
                        "  dap_data_entrega , " + 
                        "  dap_semana , " + 
                        "  dap_ano_semana , " + 
                        "  dap_status , " + 
                        "  dap_configuracao , " + 
                        "  dap_producao , " + 
                        "  dap_conferencia , " + 
                        "  dap_embarque , " + 
                        "  dap_faturamento , " + 
                        "  dap_valor , " + 
                        "  dap_urgente , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :dap_pedido , " + 
                        "  :dap_cliente , " + 
                        "  :dap_data_entrega , " + 
                        "  :dap_semana , " + 
                        "  :dap_ano_semana , " + 
                        "  :dap_status , " + 
                        "  :dap_configuracao , " + 
                        "  :dap_producao , " + 
                        "  :dap_conferencia , " + 
                        "  :dap_embarque , " + 
                        "  :dap_faturamento , " + 
                        "  :dap_valor , " + 
                        "  :dap_urgente , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_dashboard_pedidos;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dap_pedido", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Pedido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dap_cliente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Cliente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dap_data_entrega", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataEntrega ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dap_semana", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Semana ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dap_ano_semana", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.AnoSemana ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dap_status", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Status);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dap_configuracao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Configuracao);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dap_producao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Producao);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dap_conferencia", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Conferencia);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dap_embarque", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Embarque);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dap_faturamento", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Faturamento);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dap_valor", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Valor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dap_urgente", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Urgente ?? DBNull.Value;
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
        public static DashboardPedidosClass CopiarEntidade(DashboardPedidosClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               DashboardPedidosClass toRet = new DashboardPedidosClass(usuario,conn);
 toRet.Pedido= entidadeCopiar.Pedido;
 toRet.Cliente= entidadeCopiar.Cliente;
 toRet.DataEntrega= entidadeCopiar.DataEntrega;
 toRet.Semana= entidadeCopiar.Semana;
 toRet.AnoSemana= entidadeCopiar.AnoSemana;
 toRet.Status= entidadeCopiar.Status;
 toRet.Configuracao= entidadeCopiar.Configuracao;
 toRet.Producao= entidadeCopiar.Producao;
 toRet.Conferencia= entidadeCopiar.Conferencia;
 toRet.Embarque= entidadeCopiar.Embarque;
 toRet.Faturamento= entidadeCopiar.Faturamento;
 toRet.Valor= entidadeCopiar.Valor;
 toRet.Urgente= entidadeCopiar.Urgente;

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
       _pedidoOriginal = Pedido;
       _pedidoOriginalCommited = _pedidoOriginal;
       _clienteOriginal = Cliente;
       _clienteOriginalCommited = _clienteOriginal;
       _dataEntregaOriginal = DataEntrega;
       _dataEntregaOriginalCommited = _dataEntregaOriginal;
       _semanaOriginal = Semana;
       _semanaOriginalCommited = _semanaOriginal;
       _anoSemanaOriginal = AnoSemana;
       _anoSemanaOriginalCommited = _anoSemanaOriginal;
       _statusOriginal = Status;
       _statusOriginalCommited = _statusOriginal;
       _configuracaoOriginal = Configuracao;
       _configuracaoOriginalCommited = _configuracaoOriginal;
       _producaoOriginal = Producao;
       _producaoOriginalCommited = _producaoOriginal;
       _conferenciaOriginal = Conferencia;
       _conferenciaOriginalCommited = _conferenciaOriginal;
       _embarqueOriginal = Embarque;
       _embarqueOriginalCommited = _embarqueOriginal;
       _faturamentoOriginal = Faturamento;
       _faturamentoOriginalCommited = _faturamentoOriginal;
       _valorOriginal = Valor;
       _valorOriginalCommited = _valorOriginal;
       _urgenteOriginal = Urgente;
       _urgenteOriginalCommited = _urgenteOriginal;
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
       _pedidoOriginalCommited = Pedido;
       _clienteOriginalCommited = Cliente;
       _dataEntregaOriginalCommited = DataEntrega;
       _semanaOriginalCommited = Semana;
       _anoSemanaOriginalCommited = AnoSemana;
       _statusOriginalCommited = Status;
       _configuracaoOriginalCommited = Configuracao;
       _producaoOriginalCommited = Producao;
       _conferenciaOriginalCommited = Conferencia;
       _embarqueOriginalCommited = Embarque;
       _faturamentoOriginalCommited = Faturamento;
       _valorOriginalCommited = Valor;
       _urgenteOriginalCommited = Urgente;
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
               Pedido=_pedidoOriginal;
               _pedidoOriginalCommited=_pedidoOriginal;
               Cliente=_clienteOriginal;
               _clienteOriginalCommited=_clienteOriginal;
               DataEntrega=_dataEntregaOriginal;
               _dataEntregaOriginalCommited=_dataEntregaOriginal;
               Semana=_semanaOriginal;
               _semanaOriginalCommited=_semanaOriginal;
               AnoSemana=_anoSemanaOriginal;
               _anoSemanaOriginalCommited=_anoSemanaOriginal;
               Status=_statusOriginal;
               _statusOriginalCommited=_statusOriginal;
               Configuracao=_configuracaoOriginal;
               _configuracaoOriginalCommited=_configuracaoOriginal;
               Producao=_producaoOriginal;
               _producaoOriginalCommited=_producaoOriginal;
               Conferencia=_conferenciaOriginal;
               _conferenciaOriginalCommited=_conferenciaOriginal;
               Embarque=_embarqueOriginal;
               _embarqueOriginalCommited=_embarqueOriginal;
               Faturamento=_faturamentoOriginal;
               _faturamentoOriginalCommited=_faturamentoOriginal;
               Valor=_valorOriginal;
               _valorOriginalCommited=_valorOriginal;
               Urgente=_urgenteOriginal;
               _urgenteOriginalCommited=_urgenteOriginal;
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
       dirty = _pedidoOriginal != Pedido;
      if (dirty) return true;
       dirty = _clienteOriginal != Cliente;
      if (dirty) return true;
       dirty = _dataEntregaOriginal != DataEntrega;
      if (dirty) return true;
       dirty = _semanaOriginal != Semana;
      if (dirty) return true;
       dirty = _anoSemanaOriginal != AnoSemana;
      if (dirty) return true;
       dirty = _statusOriginal != Status;
      if (dirty) return true;
       dirty = _configuracaoOriginal != Configuracao;
      if (dirty) return true;
       dirty = _producaoOriginal != Producao;
      if (dirty) return true;
       dirty = _conferenciaOriginal != Conferencia;
      if (dirty) return true;
       dirty = _embarqueOriginal != Embarque;
      if (dirty) return true;
       dirty = _faturamentoOriginal != Faturamento;
      if (dirty) return true;
       dirty = _valorOriginal != Valor;
      if (dirty) return true;
       dirty = _urgenteOriginal != Urgente;
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
       dirty = _pedidoOriginalCommited != Pedido;
      if (dirty) return true;
       dirty = _clienteOriginalCommited != Cliente;
      if (dirty) return true;
       dirty = _dataEntregaOriginalCommited != DataEntrega;
      if (dirty) return true;
       dirty = _semanaOriginalCommited != Semana;
      if (dirty) return true;
       dirty = _anoSemanaOriginalCommited != AnoSemana;
      if (dirty) return true;
       dirty = _statusOriginalCommited != Status;
      if (dirty) return true;
       dirty = _configuracaoOriginalCommited != Configuracao;
      if (dirty) return true;
       dirty = _producaoOriginalCommited != Producao;
      if (dirty) return true;
       dirty = _conferenciaOriginalCommited != Conferencia;
      if (dirty) return true;
       dirty = _embarqueOriginalCommited != Embarque;
      if (dirty) return true;
       dirty = _faturamentoOriginalCommited != Faturamento;
      if (dirty) return true;
       dirty = _valorOriginalCommited != Valor;
      if (dirty) return true;
       dirty = _urgenteOriginalCommited != Urgente;
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
             case "Pedido":
                return this.Pedido;
             case "Cliente":
                return this.Cliente;
             case "DataEntrega":
                return this.DataEntrega;
             case "Semana":
                return this.Semana;
             case "AnoSemana":
                return this.AnoSemana;
             case "Status":
                return this.Status;
             case "Configuracao":
                return this.Configuracao;
             case "Producao":
                return this.Producao;
             case "Conferencia":
                return this.Conferencia;
             case "Embarque":
                return this.Embarque;
             case "Faturamento":
                return this.Faturamento;
             case "Valor":
                return this.Valor;
             case "Urgente":
                return this.Urgente;
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
                  command.CommandText += " COUNT(dashboard_pedidos.id_dashboard_pedidos) " ;
               }
               else
               {
               command.CommandText += "dashboard_pedidos.id_dashboard_pedidos, " ;
               command.CommandText += "dashboard_pedidos.dap_pedido, " ;
               command.CommandText += "dashboard_pedidos.dap_cliente, " ;
               command.CommandText += "dashboard_pedidos.dap_data_entrega, " ;
               command.CommandText += "dashboard_pedidos.dap_semana, " ;
               command.CommandText += "dashboard_pedidos.dap_ano_semana, " ;
               command.CommandText += "dashboard_pedidos.dap_status, " ;
               command.CommandText += "dashboard_pedidos.dap_configuracao, " ;
               command.CommandText += "dashboard_pedidos.dap_producao, " ;
               command.CommandText += "dashboard_pedidos.dap_conferencia, " ;
               command.CommandText += "dashboard_pedidos.dap_embarque, " ;
               command.CommandText += "dashboard_pedidos.dap_faturamento, " ;
               command.CommandText += "dashboard_pedidos.dap_valor, " ;
               command.CommandText += "dashboard_pedidos.dap_urgente, " ;
               command.CommandText += "dashboard_pedidos.entity_uid, " ;
               command.CommandText += "dashboard_pedidos.version " ;
               }
               command.CommandText += " FROM  dashboard_pedidos ";
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
                        orderByClause += " , dap_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(dap_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = dashboard_pedidos.id_acs_usuario_ultima_revisao ";
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
                     case "id_dashboard_pedidos":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , dashboard_pedidos.id_dashboard_pedidos " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(dashboard_pedidos.id_dashboard_pedidos) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dap_pedido":
                     case "Pedido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , dashboard_pedidos.dap_pedido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(dashboard_pedidos.dap_pedido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dap_cliente":
                     case "Cliente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , dashboard_pedidos.dap_cliente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(dashboard_pedidos.dap_cliente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dap_data_entrega":
                     case "DataEntrega":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , dashboard_pedidos.dap_data_entrega " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(dashboard_pedidos.dap_data_entrega) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dap_semana":
                     case "Semana":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , dashboard_pedidos.dap_semana " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(dashboard_pedidos.dap_semana) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dap_ano_semana":
                     case "AnoSemana":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , dashboard_pedidos.dap_ano_semana " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(dashboard_pedidos.dap_ano_semana) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dap_status":
                     case "Status":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , dashboard_pedidos.dap_status " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(dashboard_pedidos.dap_status) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dap_configuracao":
                     case "Configuracao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , dashboard_pedidos.dap_configuracao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(dashboard_pedidos.dap_configuracao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dap_producao":
                     case "Producao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , dashboard_pedidos.dap_producao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(dashboard_pedidos.dap_producao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dap_conferencia":
                     case "Conferencia":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , dashboard_pedidos.dap_conferencia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(dashboard_pedidos.dap_conferencia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dap_embarque":
                     case "Embarque":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , dashboard_pedidos.dap_embarque " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(dashboard_pedidos.dap_embarque) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dap_faturamento":
                     case "Faturamento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , dashboard_pedidos.dap_faturamento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(dashboard_pedidos.dap_faturamento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dap_valor":
                     case "Valor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , dashboard_pedidos.dap_valor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(dashboard_pedidos.dap_valor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dap_urgente":
                     case "Urgente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , dashboard_pedidos.dap_urgente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(dashboard_pedidos.dap_urgente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , dashboard_pedidos.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(dashboard_pedidos.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , dashboard_pedidos.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(dashboard_pedidos.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("dap_pedido")) 
                        {
                           whereClause += " OR UPPER(dashboard_pedidos.dap_pedido) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(dashboard_pedidos.dap_pedido) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("dap_cliente")) 
                        {
                           whereClause += " OR UPPER(dashboard_pedidos.dap_cliente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(dashboard_pedidos.dap_cliente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(dashboard_pedidos.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(dashboard_pedidos.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_dashboard_pedidos")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  dashboard_pedidos.id_dashboard_pedidos IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  dashboard_pedidos.id_dashboard_pedidos = :dashboard_pedidos_ID_9430 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dashboard_pedidos_ID_9430", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Pedido" || parametro.FieldName == "dap_pedido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  dashboard_pedidos.dap_pedido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  dashboard_pedidos.dap_pedido LIKE :dashboard_pedidos_Pedido_3122 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dashboard_pedidos_Pedido_3122", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cliente" || parametro.FieldName == "dap_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  dashboard_pedidos.dap_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  dashboard_pedidos.dap_cliente LIKE :dashboard_pedidos_Cliente_371 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dashboard_pedidos_Cliente_371", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataEntrega" || parametro.FieldName == "dap_data_entrega")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  dashboard_pedidos.dap_data_entrega IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  dashboard_pedidos.dap_data_entrega = :dashboard_pedidos_DataEntrega_8472 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dashboard_pedidos_DataEntrega_8472", NpgsqlDbType.Date, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Semana" || parametro.FieldName == "dap_semana")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  dashboard_pedidos.dap_semana IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  dashboard_pedidos.dap_semana = :dashboard_pedidos_Semana_1842 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dashboard_pedidos_Semana_1842", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AnoSemana" || parametro.FieldName == "dap_ano_semana")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  dashboard_pedidos.dap_ano_semana IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  dashboard_pedidos.dap_ano_semana = :dashboard_pedidos_AnoSemana_759 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dashboard_pedidos_AnoSemana_759", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Status" || parametro.FieldName == "dap_status")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is EasiDashboardSituacaoPedido)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo EasiDashboardSituacaoPedido");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  dashboard_pedidos.dap_status IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  dashboard_pedidos.dap_status = :dashboard_pedidos_Status_9705 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dashboard_pedidos_Status_9705", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Configuracao" || parametro.FieldName == "dap_configuracao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is SipaDashboardSituacaoProcesso)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo SipaDashboardSituacaoProcesso");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  dashboard_pedidos.dap_configuracao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  dashboard_pedidos.dap_configuracao = :dashboard_pedidos_Configuracao_7330 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dashboard_pedidos_Configuracao_7330", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Producao" || parametro.FieldName == "dap_producao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is SipaDashboardSituacaoProcesso)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo SipaDashboardSituacaoProcesso");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  dashboard_pedidos.dap_producao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  dashboard_pedidos.dap_producao = :dashboard_pedidos_Producao_6927 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dashboard_pedidos_Producao_6927", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Conferencia" || parametro.FieldName == "dap_conferencia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is SipaDashboardSituacaoProcesso)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo SipaDashboardSituacaoProcesso");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  dashboard_pedidos.dap_conferencia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  dashboard_pedidos.dap_conferencia = :dashboard_pedidos_Conferencia_1264 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dashboard_pedidos_Conferencia_1264", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Embarque" || parametro.FieldName == "dap_embarque")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is SipaDashboardSituacaoProcesso)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo SipaDashboardSituacaoProcesso");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  dashboard_pedidos.dap_embarque IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  dashboard_pedidos.dap_embarque = :dashboard_pedidos_Embarque_5408 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dashboard_pedidos_Embarque_5408", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Faturamento" || parametro.FieldName == "dap_faturamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is SipaDashboardSituacaoProcesso)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo SipaDashboardSituacaoProcesso");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  dashboard_pedidos.dap_faturamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  dashboard_pedidos.dap_faturamento = :dashboard_pedidos_Faturamento_7201 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dashboard_pedidos_Faturamento_7201", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Valor" || parametro.FieldName == "dap_valor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  dashboard_pedidos.dap_valor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  dashboard_pedidos.dap_valor = :dashboard_pedidos_Valor_5132 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dashboard_pedidos_Valor_5132", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Urgente" || parametro.FieldName == "dap_urgente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  dashboard_pedidos.dap_urgente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  dashboard_pedidos.dap_urgente = :dashboard_pedidos_Urgente_8950 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dashboard_pedidos_Urgente_8950", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
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
                         whereClause += "  dashboard_pedidos.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  dashboard_pedidos.entity_uid LIKE :dashboard_pedidos_EntityUid_6183 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dashboard_pedidos_EntityUid_6183", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  dashboard_pedidos.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  dashboard_pedidos.version = :dashboard_pedidos_Version_4405 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dashboard_pedidos_Version_4405", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PedidoExato" || parametro.FieldName == "PedidoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  dashboard_pedidos.dap_pedido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  dashboard_pedidos.dap_pedido LIKE :dashboard_pedidos_Pedido_7534 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dashboard_pedidos_Pedido_7534", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ClienteExato" || parametro.FieldName == "ClienteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  dashboard_pedidos.dap_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  dashboard_pedidos.dap_cliente LIKE :dashboard_pedidos_Cliente_2815 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dashboard_pedidos_Cliente_2815", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  dashboard_pedidos.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  dashboard_pedidos.entity_uid LIKE :dashboard_pedidos_EntityUid_1821 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dashboard_pedidos_EntityUid_1821", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  DashboardPedidosClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (DashboardPedidosClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(DashboardPedidosClass), Convert.ToInt32(read["id_dashboard_pedidos"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new DashboardPedidosClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_dashboard_pedidos"]);
                     entidade.Pedido = (read["dap_pedido"] != DBNull.Value ? read["dap_pedido"].ToString() : null);
                     entidade.Cliente = (read["dap_cliente"] != DBNull.Value ? read["dap_cliente"].ToString() : null);
                     entidade.DataEntrega = (DateTime)read["dap_data_entrega"];
                     entidade.Semana = (int)read["dap_semana"];
                     entidade.AnoSemana = (int)read["dap_ano_semana"];
                     entidade.Status = (EasiDashboardSituacaoPedido) (read["dap_status"] != DBNull.Value ? Enum.ToObject(typeof(EasiDashboardSituacaoPedido), read["dap_status"]) : null);
                     entidade.Configuracao = (SipaDashboardSituacaoProcesso) (read["dap_configuracao"] != DBNull.Value ? Enum.ToObject(typeof(SipaDashboardSituacaoProcesso), read["dap_configuracao"]) : null);
                     entidade.Producao = (SipaDashboardSituacaoProcesso) (read["dap_producao"] != DBNull.Value ? Enum.ToObject(typeof(SipaDashboardSituacaoProcesso), read["dap_producao"]) : null);
                     entidade.Conferencia = (SipaDashboardSituacaoProcesso) (read["dap_conferencia"] != DBNull.Value ? Enum.ToObject(typeof(SipaDashboardSituacaoProcesso), read["dap_conferencia"]) : null);
                     entidade.Embarque = (SipaDashboardSituacaoProcesso) (read["dap_embarque"] != DBNull.Value ? Enum.ToObject(typeof(SipaDashboardSituacaoProcesso), read["dap_embarque"]) : null);
                     entidade.Faturamento = (SipaDashboardSituacaoProcesso) (read["dap_faturamento"] != DBNull.Value ? Enum.ToObject(typeof(SipaDashboardSituacaoProcesso), read["dap_faturamento"]) : null);
                     entidade.Valor = (double)read["dap_valor"];
                     entidade.Urgente = Convert.ToBoolean(Convert.ToInt16(read["dap_urgente"]));
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (DashboardPedidosClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
