using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using BibliotecaCompras;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Operacoes.CalculoPreco;
using BibliotecaEntidades.Operacoes.Configurador;
using BibliotecaInterfaceModulosCliente;
using BibliotecaNFeCompleta;
using BibliotecaTributos;
using Configurations;
using dbProvider;
using IWTDotNetLib.ComplexLoginModule;
using IWTPostgreNpgsql;
using ProjectConstants;

namespace BibliotecaAutomacoes
{
    public class InitAllProcessClass
    {
        private readonly IConfiguradorEASIFactory _configuradorEasiFactory;
        protected Semaphore geralRunning;
        public CalculoPrecoRunnerClass PrecoRunner { get; protected set; }
        public Thread PrecoThread { get; protected set; }


        public ImportRunnerClass ImportRunner { get; protected set; }
        public ImportNFEntradaRunner ImportNfEntradaRunner { get; protected set; }
        public ExportPedidosRunnerClass ExportPedidosRunner { get; protected set; }
        public ExportContasRunnerClass ExportContasRunner { get; protected set; }
        public NFeEasiCompletoRunner NFeRunner { get; protected set; }

        public NFeEasiCompletoRunner NFeRunner2 { get; protected set; }

        public VerificaVencimentoEpiRunnerClass VerificaVencimentoEpiRunner { get; protected set; }
        public SalvarInventarioRunnerClass SalvarInventarioRunner { get; protected set; }
        public ConfiguradorAutomaticoPedidos ConfiguracaoAutomaticaRunner{ get; protected set; }

        public IntegracaoGad integracaoGadRunner { get; protected set; }

        public Thread ImportThread { get; protected set; }
        public Thread ImportNfEntradaThread { get; protected set; }
        public Thread ExportPedidosThread { get; protected set; }
        public Thread ExportContasThread { get; protected set; }
        public Thread NFeThread { get; protected set; }

        public Thread NFeThread2 { get; protected set; }
        public Thread VerificaVencimentoEpiThread { get; protected set; }
        public Thread SalvarInventarioThread { get; protected set; }
        public Thread ConfiguracaoAutomaticaThread { get; protected set; }

        public Thread IntegracaoGadThread { get; protected set; }
        

        protected const string IMPORT_PEDIDOS_AREA_NAME = "IMPORTACAO_PEDIDOS";
        protected const string IMPORT_NFE_AREA_NAME = "IMPORTACAO_NF_ENTRADA";


        protected bool _inibeImportacaoPedido = false;
        protected bool _inibeExportacaoPedido = false;
        protected bool _inibeExportacaoContas = false;
        protected bool _inibeImportacaoNFEntrada = false;
        protected bool _inibeVerificaEPI = false;
        protected bool _inibeHistoricoEstoque = false;
        protected bool _inibeConfiguracaoAutomatica = false;
        protected bool _inibeIntegracaoGad = false;
        protected bool _inibeNfe = false;



        protected IWTPostgreNpgsqlConnection connCalculoPreco;
        protected IWTPostgreNpgsqlConnection connImportacaoPedido;
        protected IWTPostgreNpgsqlConnection connExportacaoPedido;
        protected IWTPostgreNpgsqlConnection connExportacaoContas;
        protected IWTPostgreNpgsqlConnection connImportacaoNFEntrada;
        protected IWTPostgreNpgsqlConnection connVerificaEPI;
        protected IWTPostgreNpgsqlConnection connHistoricoEstoque;
        protected IWTPostgreNpgsqlConnection connConfiguracaoAutomatica;

        public InitAllProcessClass(IConfiguradorEASIFactory configuradorEasiFactory, Semaphore geralRunning)
        {
            _configuradorEasiFactory = configuradorEasiFactory;
            this.geralRunning = geralRunning;
        }

        public virtual void Init()
        {
            try
            {
                try
                {
                    if (!_inibeImportacaoPedido)
                    {
                        inicializarImportacaoPedidos();
                    }

                }
                catch (Exception e)
                {
                    MessageBox.Show(null, "Erro ao inicializar a importação de pedidos.\r\n" + e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                try
                {
                    if (!_inibeImportacaoNFEntrada)
                    {
                        inicializarImportacaoNFEntrada();
                    }

                }
                catch (Exception e)
                {
                    MessageBox.Show(null, "Erro ao inicializar a importação das notas fiscais de entrada.\r\n" + e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                try
                {
                    if (!_inibeExportacaoPedido)
                    {
                        initicializarExportacaoPedidos();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(null, "Erro ao inicializar a exportação de pedidos.\r\n" + e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                try
                {
                    if (!_inibeExportacaoContas)
                    {
                        initicializarExportacaoContas();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(null, "Erro ao inicializar a exportação das contas.\r\n" + e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                try
                {
                    if (!_inibeNfe)
                    {
                        initcializarNFe();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(null, "Erro ao inicializar o controle da NFe.\r\n" + e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                try
                {
                    if (!_inibeVerificaEPI)
                    {
                        initicializarVerificacaoVencimentoEpi();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(null, "Erro ao inicializar a verificação de vencimento de EPIs.\r\n" + e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                try
                {
                    if (!_inibeHistoricoEstoque)
                    {
                        initicializarSalvarHistoricoEstoque();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(null, "Erro ao inicializar a o salvamento dos valores históricos do estoque.\r\n" + e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                try
                {
                    if (!_inibeConfiguracaoAutomatica)
                    {
                        initicializarConfiguracaoAutomatica();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(null, "Erro ao inicializar a configuração automática de pedidos.\r\n" + e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                try
                {
                    if (!_inibeIntegracaoGad)
                    {
                        initicializarIntegracaoGad();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(null, "Erro ao inicializar a integração com o GAD.\r\n" + e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao inicializar o módulo de automações.\r\n" + e.Message, e);
            }
        }

        protected virtual void inicializarImportacaoPedidos()
        {
           
            connCalculoPreco = new IWTPostgreNpgsqlConnection(DbConnection.connectionString);
            connCalculoPreco.Open();

            PrecoRunner = new CalculoPrecoRunnerClass(connCalculoPreco, IWTConfiguration.Conf.getConf(Constants.LOG_EASI), ref geralRunning, LoginClass.UsuarioLogado.loggedUser,
                IWTConfiguration.Conf.getBoolConf(Constants.TABELA_PRECOS_AUTOMATICO),
                Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.TABELA_PRECOS_HORA)),
                Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.TABELA_PRECOS_MINUTO)));
            PrecoThread = new Thread(PrecoRunner.Start) {IsBackground = true};
            PrecoThread.Start();

            connImportacaoPedido = new IWTPostgreNpgsqlConnection(DbConnection.connectionString);
            connImportacaoPedido.Open();

            //Obtém os módulos de processamento de pedidos do cliente
            List < ProcessamentoBase > modulosRodar = getModulosClienteRodar();
            if (modulosRodar.Count > 0)
            {
                ImportRunner = new ImportRunnerClass(
                    IWTConfiguration.Conf.getConf(Constants.INTERVALO_IMPORTACAO_PEDIDOS), modulosRodar,
                    ref geralRunning);
                ImportThread = new Thread(ImportRunner.start) { IsBackground = true };
                ImportThread.Start();
            }
        }

        protected virtual List<ProcessamentoBase> getModulosClienteRodar()
        {
            return new List<ProcessamentoBase>();
        }

        protected virtual void inicializarImportacaoNFEntrada()
        {
            if (IWTConfiguration.Conf.getConf(Constants.INTERVALO_IMPORTACAO_NF_COMPRA) != "")
            {
                connImportacaoNFEntrada = new IWTPostgreNpgsqlConnection(DbConnection.connectionString);
                connImportacaoNFEntrada.Open();
                                
                ImportNfEntradaRunner =
                    new ImportNFEntradaRunner(
                        new ImportNFEntrada(IWTConfiguration.Conf.getConf(Constants.NFE_COMPRA_ENTRADA),
                                            IWTConfiguration.Conf.getConf(Constants.NFE_COMPRA_SAIDA),
                                            LoginClass.UsuarioLogado.loggedUser,
                                            connImportacaoNFEntrada),
                        IWTConfiguration.Conf.getConf(Constants.LOG_EASI),
                        int.Parse(IWTConfiguration.Conf.getConf(Constants.INTERVALO_IMPORTACAO_NF_COMPRA)),
                        ref geralRunning);

                ImportNfEntradaThread = new Thread(ImportNfEntradaRunner.start) {IsBackground = true};
                ImportNfEntradaThread.Start();
            }

        }

        protected virtual void initicializarExportacaoPedidos()
        {
            if (IWTConfiguration.Conf.getBoolConf(Constants.EXPORTACAO_PEDIDOS_ATIVA))
            {
                string diretorioSaida = IWTConfiguration.Conf.getConf(Constants.DIRETORIO_EXPORTACAO_CSV);
                if (string.IsNullOrEmpty(diretorioSaida) || !Directory.Exists(diretorioSaida))
                {
                    throw new Exception(
                        "O diretório de saída para a exportação de pedidos não existe ou não foi configurado.");
                }
                connExportacaoPedido = new IWTPostgreNpgsqlConnection( DbConnection.connectionString);
                connExportacaoPedido.Open();

                ExportPedidosRunner = new ExportPedidosRunnerClass(ref geralRunning,connExportacaoPedido);
                ExportPedidosThread = new Thread(ExportPedidosRunner.Start) { IsBackground = true };
                ExportPedidosThread.Start();
            }

        }

        protected virtual void initicializarExportacaoContas()
        {
            if (IWTConfiguration.Conf.getBoolConf(Constants.EXPORTACAO_CONTAS_ATIVA))
            {
                string diretorioSaida = IWTConfiguration.Conf.getConf(Constants.DIRETORIO_EXPORTACAO_CSV);
                if (string.IsNullOrEmpty(diretorioSaida) || !Directory.Exists(diretorioSaida))
                {
                    throw new Exception(
                        "O diretório de saída para a exportação de contas não existe ou não foi configurado.");
                }
                connExportacaoContas = new IWTPostgreNpgsqlConnection(DbConnection.connectionString);
                connExportacaoContas.Open();

                ExportContasRunner = new ExportContasRunnerClass(ref geralRunning, connExportacaoContas);
                ExportContasThread = new Thread(ExportContasRunner.Start) { IsBackground = true };
                ExportContasThread.Start();
            }

        }

        protected virtual void initcializarNFe()
        {
            try
            {
                Semaphore semaphoreNFe = new Semaphore(1, 1);

                if (IWTConfiguration.Conf.getConf(Constants.TIPO_EMISSAO_NFE)!="0")
                {
                    EmitenteClass emitente;
                    PisCofinsInfo pisCofinsDefault;

                    NotaFiscalFuncoesAuxiliares.CarregaEmitente(DbConnection.Connection, out emitente, EasiEmissorNFe.Primario , out pisCofinsDefault);


                    NFeRunner = new NFeEasiCompletoRunner(emitente.SerialCertificado,
                        semaphoreNFe,
                        emitente.Estado,
                        emitente.Cnpj,
                        LoginClass.LogById(LoginClass.UsuarioLogado.loggedUser.ID, DbConnection.Connection, true).loggedUser,
                        DbConnection.connectionString,
                         IWTConfiguration.Conf.getBinaryConf(Constants.LOGO_EMPRESA),
                        emitente.DadosSalvarEnviarNfe);

                    NFeThread = new Thread(NFeRunner.Start) { IsBackground = true };
                    NFeThread.Start();


                    NotaFiscalFuncoesAuxiliares.CarregaEmitente(DbConnection.Connection, out emitente, EasiEmissorNFe.Secundario, out pisCofinsDefault);

                    if (!string.IsNullOrWhiteSpace(emitente.Cnpj))
                    {
                        NFeRunner2 = new NFeEasiCompletoRunner(emitente.SerialCertificado,
                            semaphoreNFe,
                            emitente.Estado,
                            emitente.Cnpj,
                            LoginClass.LogById(LoginClass.UsuarioLogado.loggedUser.ID, DbConnection.Connection, true).loggedUser,
                            DbConnection.connectionString,
                            IWTConfiguration.Conf.getBinaryConf(Constants.LOGO_EMPRESA),
                            emitente.DadosSalvarEnviarNfe);

                        NFeThread2 = new Thread(NFeRunner2.Start) { IsBackground = true };
                        NFeThread2.Start();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao inicializar os threads da NFe.\r\n" + e.Message, e);
            }
        }

        protected virtual void initicializarVerificacaoVencimentoEpi()
        {
            connVerificaEPI = new IWTPostgreNpgsqlConnection(DbConnection.connectionString);
            connVerificaEPI.Open();

            VerificaVencimentoEpiRunner = new VerificaVencimentoEpiRunnerClass(ref geralRunning, connVerificaEPI);
            VerificaVencimentoEpiThread = new Thread(VerificaVencimentoEpiRunner.Start) { IsBackground = true };
            VerificaVencimentoEpiThread.Start();
        }

        protected virtual void initicializarSalvarHistoricoEstoque()
        {
            connHistoricoEstoque = new IWTPostgreNpgsqlConnection(DbConnection.connectionString);
            connHistoricoEstoque.Open();

            SalvarInventarioRunner = new SalvarInventarioRunnerClass(ref geralRunning, connHistoricoEstoque, LoginClass.LogById(LoginClass.UsuarioLogado.loggedUser.ID, connHistoricoEstoque, true).loggedUser);
            SalvarInventarioThread = new Thread(SalvarInventarioRunner.Start) { IsBackground = true };
            SalvarInventarioThread.Start();
        }
        
        protected virtual void initicializarConfiguracaoAutomatica()
        {
            connConfiguracaoAutomatica = new IWTPostgreNpgsqlConnection(DbConnection.connectionString);
            connConfiguracaoAutomatica.Open();

            ConfiguracaoAutomaticaRunner = new ConfiguradorAutomaticoPedidos(ref geralRunning, _configuradorEasiFactory, LoginClass.LogById(LoginClass.UsuarioLogado.loggedUser.ID, connConfiguracaoAutomatica, true).loggedUser, connConfiguracaoAutomatica);
            ConfiguracaoAutomaticaThread = new Thread(ConfiguracaoAutomaticaRunner.Start) { IsBackground = true };
            ConfiguracaoAutomaticaThread.Start();
        }

        protected virtual void initicializarIntegracaoGad()
        {
            if (ConfiguraConexaoGad.GadAtivo)
            {
                integracaoGadRunner = new IntegracaoGad(ref geralRunning, DbConnection.connectionString);
                IntegracaoGadThread = new Thread(integracaoGadRunner.Start) {IsBackground = true};
                IntegracaoGadThread.Start();
            }
        }
        

        public virtual void Fechar()
        {
            try
            {
                if (ImportThread != null)
                {
                    ImportRunner.SafeStop();
                    if (!ImportThread.Join(2000))
                    {
                        try
                        {
                            ImportThread.Abort();
                        }
                        catch (ThreadAbortException)
                        {

                        }

                    }
                }

                if (ImportNfEntradaThread != null)
                {
                    ImportNfEntradaRunner.SafeStop();
                    if (!ImportNfEntradaThread.Join(2000))
                    {
                        try
                        {
                            ImportNfEntradaThread.Abort();
                        }
                        catch (ThreadAbortException)
                        {

                        }
                    }
                }

                if (ExportPedidosThread != null)
                {
                    ExportPedidosRunner.SafeStop();
                    if (!ExportPedidosThread.Join(2000))
                    {
                        try
                        {
                            ExportPedidosThread.Abort();
                        }
                        catch (ThreadAbortException)
                        {

                        }
                    }
                }

                if (ExportContasThread != null)
                {
                    ExportContasRunner.SafeStop();
                    if (!ExportContasThread.Join(2000))
                    {
                        try
                        {
                            ExportContasThread.Abort();
                        }
                        catch (ThreadAbortException)
                        {

                        }
                    }
                }

                if (NFeThread != null)
                {
                    NFeRunner.Interromper();
                    if (!NFeThread.Join(2000))
                    {
                        try
                        {
                            NFeThread.Abort();
                        }
                        catch (ThreadAbortException)
                        {

                        }
                    }
                }

                if (NFeThread2 != null)
                {
                    NFeRunner2.Interromper();
                    if (!NFeThread2.Join(2000))
                    {
                        try
                        {
                            NFeThread2.Abort();
                        }
                        catch (ThreadAbortException)
                        {

                        }
                    }
                }


                if (VerificaVencimentoEpiThread != null)
                {
                    VerificaVencimentoEpiRunner.SafeStop();
                    if (!VerificaVencimentoEpiThread.Join(2000))
                    {
                        try
                        {
                            VerificaVencimentoEpiThread.Abort();
                        }
                        catch (ThreadAbortException)
                        {

                        }
                    }
                }

                if (PrecoThread != null)
                {
                    PrecoRunner.SafeStop();
                    if (!PrecoThread.Join(2000))
                    {
                        try
                        {
                            PrecoThread.Abort();
                        }
                        catch (ThreadAbortException)
                        {

                        }
                    }
                }

                if (SalvarInventarioThread != null)
                {
                    SalvarInventarioRunner.SafeStop();
                    if (!SalvarInventarioThread.Join(2000))
                    {
                        try
                        {
                            SalvarInventarioThread.Abort();
                        }
                        catch (ThreadAbortException)
                        {

                        }
                    }
                }
                
                if (ConfiguracaoAutomaticaThread != null)
                {
                    ConfiguracaoAutomaticaRunner.SafeStop();
                    if (!ConfiguracaoAutomaticaThread.Join(2000))
                    {
                        try
                        {
                            ConfiguracaoAutomaticaThread.Abort();
                        }
                        catch (ThreadAbortException)
                        {

                        }
                    }
                }

                if (IntegracaoGadThread != null)
                {
                    integracaoGadRunner.SafeStop();
                    if (!IntegracaoGadThread.Join(2000))
                    {
                        try
                        {
                            IntegracaoGadThread.Abort();
                        }
                        catch (ThreadAbortException)
                        {

                        }
                    }
                }

                if (connCalculoPreco != null && connCalculoPreco.State == ConnectionState.Open)
                    connCalculoPreco.ForceClose();

                if (connImportacaoPedido != null && connImportacaoPedido.State == ConnectionState.Open)
                    connImportacaoPedido.ForceClose();

                if (connImportacaoNFEntrada != null && connImportacaoNFEntrada.State == ConnectionState.Open)
                    connImportacaoNFEntrada.ForceClose();

                if (connExportacaoPedido != null && connExportacaoPedido.State == ConnectionState.Open)
                    connExportacaoPedido.ForceClose();

                if (connExportacaoContas != null && connExportacaoContas.State == ConnectionState.Open)
                    connExportacaoContas.ForceClose();

                if (connVerificaEPI != null && connVerificaEPI.State == ConnectionState.Open)
                    connVerificaEPI.ForceClose();

                if (connHistoricoEstoque != null && connHistoricoEstoque.State == ConnectionState.Open)
                    connHistoricoEstoque.ForceClose();
                
                if (connConfiguracaoAutomatica != null && connConfiguracaoAutomatica.State == ConnectionState.Open)
                    connConfiguracaoAutomatica.ForceClose();

            }
            catch
            {

            }
        }
    }
}
