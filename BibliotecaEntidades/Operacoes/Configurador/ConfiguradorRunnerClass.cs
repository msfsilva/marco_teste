#region Referencias

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaTributos;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

#endregion

namespace BibliotecaEntidades.Operacoes.Configurador
{
    public class RetornoConfigurador
    {
        public string Aviso { get; set; }
        public string Erro { get; set; }
    }

    public class ConfiguradorRunnerManagerClass : BackgroundWorker
    {
        
        readonly string tipoCalculoSemana;
        readonly string diaCalculoSemana;

        internal List<ConfiguradorPedido> pedidosConfigurar;
        internal List<ConfiguradorPedido> pedidoConfigurados;
        internal List<IWTPostgreNpgsqlConnection> conn;


        readonly List<ConfiguradorRunner> Configuradores;
        internal Semaphore acessoPedidos;
        readonly int totalPedidos;

        private List<string> _avisos;
        private List<string> _erros;


        public ConfiguradorRunnerManagerClass(List<IWTPostgreNpgsqlConnection> conn, string tipoCalculoSemana, string diaCalculoSemana, int qtdThreads, List<ConfiguradorPedido> pedidosConfigurar, IConfiguradorEASIFactory configuradorEasiFactory)
        {
            this.conn = conn;
            
            
            this.tipoCalculoSemana = tipoCalculoSemana;
            this.diaCalculoSemana = diaCalculoSemana;
            this.pedidosConfigurar = pedidosConfigurar;
            this.acessoPedidos = new Semaphore(1, 1);
            this.pedidoConfigurados = new List<ConfiguradorPedido>();
            this.totalPedidos = pedidosConfigurar.Count;
            
            this.WorkerReportsProgress = true;
            this.WorkerSupportsCancellation = true;

            this.Configuradores = new List<ConfiguradorRunner>();

            if (this.conn.Count < qtdThreads)
            {
                throw new Exception("O número de conexões fornecidas deve ser igual ou maios ao numero de threads.");
            }

            for (int i = 0; i < qtdThreads; i++)
            {
                this.Configuradores.Add(new ConfiguradorRunner(this.conn[i], LoginClass.LogById(LoginClass.UsuarioLogado.loggedUser.ID, conn[i], true).loggedUser, this.tipoCalculoSemana, this.diaCalculoSemana, this, configuradorEasiFactory));
            }

            _avisos = new List<string>();
            _erros = new List<string>();

        }

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            RetornoConfigurador ret = new RetornoConfigurador();

            for (int i = 0; i < this.Configuradores.Count; i++)
            {
                ConfiguradorRunner conf = this.Configuradores[i];
                conf.ProgressChanged += new ProgressChangedEventHandler(conf_ProgressChanged);
                conf.RunWorkerCompleted += new RunWorkerCompletedEventHandler(conf_RunWorkerCompleted);
                conf.RunWorkerAsync();
            }

            while (this.Configuradores.Count > 0)
            {
                Thread.Sleep(1000);
            }


            
            foreach (string aviso in _avisos)
            {
                ret.Aviso += aviso;
            }
            foreach (string erro in _erros)
            {
                ret.Erro += erro;
            }
            e.Result = ret;

        }

        void conf_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.acessoPedidos.WaitOne();
            if (totalPedidos > 0)
            {
                int progress = ((totalPedidos - this.pedidosConfigurar.Count) / totalPedidos) * 100;
                this.ReportProgress(progress);
            }

            ConfiguradorRunner conf = ((ConfiguradorRunner) sender);
            this.Configuradores.Remove(conf);
            if (e.Result != null)
            {
                _erros.Add(e.Result.ToString());
            }

            if (!string.IsNullOrWhiteSpace(conf.Avisos))
            {
                _avisos.Add(conf.Avisos);
            }

            this.acessoPedidos.Release();
        }

        void conf_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.acessoPedidos.WaitOne();
            double progress = ((double)(totalPedidos - this.pedidosConfigurar.Count) / totalPedidos) * 100;
            int tm = (int)Math.Truncate(progress);
            this.ReportProgress(tm);
            this.acessoPedidos.Release();
        }

    }

    public class ConfiguradorRunner: BackgroundWorker
    {
        internal IWTPostgreNpgsqlConnection conn { get; private set; }
        private readonly AcsUsuarioClass _usuario;
        
        readonly string tipoCalculoSemana;
        readonly string diaCalculoSemana;

        ConfiguradorPedido Pedido;
        readonly IConfiguradorEASI Configurador;
        readonly ConfiguradorRunnerManagerClass Parent;

        public string Avisos { get; private set; }

        public ConfiguradorRunner(IWTPostgreNpgsqlConnection conn,AcsUsuarioClass usuario, string tipoCalculoSemana, string diaCalculoSemana, ConfiguradorRunnerManagerClass Parent, IConfiguradorEASIFactory configuradorEasiFactory)
        {
            
            this.conn = conn;
            _usuario = usuario;
            this.tipoCalculoSemana = tipoCalculoSemana;
            this.diaCalculoSemana = diaCalculoSemana;
            this.Parent = Parent;
            this.WorkerReportsProgress = true;
            this.WorkerSupportsCancellation = true;

            this.Configurador = configuradorEasiFactory.getInstance(this.conn,_usuario, this.tipoCalculoSemana, this.diaCalculoSemana);
        }

        public void setPedido(ConfiguradorPedido Pedido)
        {
            this.Pedido = Pedido;
        }

        protected override void OnDoWork(DoWorkEventArgs e)
        {


            string Error = "";
            do
            {
                if (!this.CancellationPending)
                {
                    
                    this.Parent.acessoPedidos.WaitOne();
                    if (this.Parent.pedidosConfigurar.Count > 0)
                    {
                        this.setPedido(this.Parent.pedidosConfigurar[0]);
                        this.Parent.pedidoConfigurados.Add(this.Parent.pedidosConfigurar[0]);
                        this.Parent.pedidosConfigurar.RemoveAt(0);
                       
                    }
                    else
                    {
                        this.Parent.acessoPedidos.Release();
                        break;
                    }

                    this.Parent.acessoPedidos.Release();
                    try
                    {
                        string aviso;
                        this.Configurador.configurarPedido(this.Pedido.oc, this.Pedido.pos, this.Pedido.idCliente, this.Pedido.clienteEspecial, this.Pedido.TipoEntidade, out aviso);

                        if (!string.IsNullOrWhiteSpace(aviso))
                        {
                            Avisos += aviso;
                        }
                        Pedido.Configurado = true;
                    }
                    catch (Exception a)
                    {
                        Error += "Erro ao configurar o pedido: " + this.Pedido.oc + "/" + this.Pedido.pos + " - " + a.Message + "\r\n\r\n";
                    }
                    finally
                    {
                        this.ReportProgress(1); 
                    }

                }
                else
                {
                    e.Cancel = true;
                    return;
                }
            }
            while (true);

            base.OnDoWork(e);

            if (Error.Length > 0)
            {
                e.Result = Error;
            }
            else
            {
                e.Result = "";
            }
            
        }

    }

    public class ConfiguradorPedido
    {
        public int IdItemPedido { get; private set; }
        public string oc { get; private set; }
        public int pos { get; private set; }
        public string idCliente { get; private set; }
        public int clienteEspecial { get; private set; }
        public PedidoOrcamento TipoEntidade { get; private set; }

        public bool Configurado { get; set; }

        public ConfiguradorPedido(string oc, int pos, string idCliente, int clienteEspecial, PedidoOrcamento tipoEntidade, int idItemPedido)
        {
            this.oc = oc;
            this.pos = pos;
            this.idCliente = idCliente;
            this.clienteEspecial = clienteEspecial;
            this.TipoEntidade = tipoEntidade;
            IdItemPedido = idItemPedido;
        }
    }
}
