using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;

using BibliotecaEntidades.Base;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Operacoes.Configurador;
using BibliotecaEntidades.Operacoes.EnvioEmail;
using BibliotecaTributos;
using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using ProjectConstants;

namespace BibliotecaAutomacoes
{
    public class ConfiguradorAutomaticoPedidos
    {
        private readonly Semaphore _semaphore;
        private readonly IConfiguradorEASIFactory _configuradorEasiFactory;
        private readonly AcsUsuarioClass _usuario;
        private readonly IWTPostgreNpgsqlConnection _conn;


        private Boolean _toStop;
        readonly int _sleepTimeAfterRun = 36000;
        private readonly string _logFile;

        
        private readonly string _tipoCalculoSemana;
        private readonly string _diaCalculoSemana;

        private readonly ServidorEmailClass _smtpPadrao;
        private readonly string _destinatarioEmailReport;

        public ConfiguradorAutomaticoPedidos(ref Semaphore semaphore, IConfiguradorEASIFactory configuradorEasiFactory, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            _semaphore = semaphore;
            _configuradorEasiFactory = configuradorEasiFactory;
            _usuario = usuario;
            _conn = conn;
         
            _logFile = AppDomain.CurrentDomain.BaseDirectory + "\\logConfiguradorAutomaticoPedidos" + DataIndependenteClass.GetData().ToString("yyyMMdd") + ".txt";
            
            EmitenteClass emitente;
            

            
            _tipoCalculoSemana = IWTConfiguration.Conf.getConf(Constants.SEMANA_TIPO_DEFINICAO);
            _diaCalculoSemana = IWTConfiguration.Conf.getConf(Constants.SEMANA_DIA);

            _smtpPadrao = ServidorEmailClass.GetServidorEmailPadrao();
            
            if (IWTConfiguration.Conf.getBoolConf(Constants.ENVIO_EMAIL_CONFIGURACAO_AUTOMATICA_PEDIDOS))
            {
                _destinatarioEmailReport = IWTConfiguration.Conf.getConf(Constants.DESTINATARIO_CONFIGURACAO_AUTOMATICA_PEDIDOS);
            }
            else
            {
                _destinatarioEmailReport = null;
            }
        }

        public void Start()
        {
            while (!_toStop)
            {
                try
                {
                   
                    try
                    {
                        _semaphore?.WaitOne();
                        string logAvisos;
                        string logErros;
                        ConfigurarPedidosPendentes(out logAvisos, out logErros);

                        TratamentoAvisosErros(logAvisos, logErros);
                    }
                    finally
                    {
                        _semaphore?.Release();
                    }
                }
                catch (Exception a)
                {
                    try
                    {
                        if (File.Exists(_logFile))
                        {
                            FileInfo fi = new FileInfo(_logFile);
                            if (fi.Length > 104857600)
                            {
                                fi.Delete();
                            }
                        }

                        StreamWriter logWriter = new StreamWriter(_logFile, true);
                        logWriter.WriteLine("Erro não esperado: " + a);
                        logWriter.Close();
                    }
                    catch
                    {
                    }
                }
                finally
                {
                    int segundos = _sleepTimeAfterRun;
                    while (!_toStop && segundos > 0)
                    {
                        Thread.Sleep(1000);
                        segundos--;
                    }
                }



            }
            

        }

        private void TratamentoAvisosErros(string logAvisos, string logErros)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(logAvisos) && string.IsNullOrWhiteSpace(logErros))
                {
                    return;
                }

                string conteudoFinal = "";
                if (!string.IsNullOrWhiteSpace(logErros))
                {
                    conteudoFinal += "---------------------------- ERROS ----------------------------" + Environment.NewLine;
                    conteudoFinal += logErros;
                    conteudoFinal += Environment.NewLine;
                }
                
                if (!string.IsNullOrWhiteSpace(logAvisos))
                {
                    conteudoFinal += "---------------------------- AVISOS ----------------------------" + Environment.NewLine;
                    conteudoFinal += logAvisos;
                    conteudoFinal += Environment.NewLine;
                }
                
                LogConfiguracaoAutomaticaPedidosClass log = new LogConfiguracaoAutomaticaPedidosClass(_usuario,_conn)
                {
                    Data = DateTime.Now,
                    Estacao = Environment.MachineName,
                    Conteudo = conteudoFinal
                };
                log.Save();

                if (!string.IsNullOrWhiteSpace(_destinatarioEmailReport))
                {
                    EnvioEmailClass.EnviaEmailDireto(_destinatarioEmailReport, _smtpPadrao.RemetentePadrao, "EASI - Configuração Automática de Pedidos", conteudoFinal, false, null, _usuario, _conn);
                }
                

            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao realizar o tratamento dos avisos e erros" + e.Message);
            }
        }

        private void ConfigurarPedidosPendentes(out string logAvisos, out string logErros)
        {
            logAvisos= "";
            logErros = "";
            try
            {
                List<PedidoItemClass> pedidoSemConfigurar = new PedidoItemClass(_usuario, _conn).Search(new List<SearchParameterClass>()
                {
                    new SearchParameterClass("Pendente", true),
                    new SearchParameterClass("Configurado", false),
                    new SearchParameterClass("SubLinha", 0)
                }).ConvertAll(a => (PedidoItemClass) a).ToList();

                DateTime dataAtual = DataIndependenteClass.GetData();

                List<ConfiguradorPedido> pedidosConfigurar = new List<ConfiguradorPedido>();
                foreach (PedidoItemClass pedido in pedidoSemConfigurar)
                {
                    if (pedido.Produto.ClassificacaoProduto == null)
                    {
                        logAvisos += pedido + ": Produto sem Classificação de Produto" + Environment.NewLine;
                        continue;
                    }
                    if (!pedido.Produto.ClassificacaoProduto.ConfiguracaoAutomatica)
                    {
                        logAvisos += pedido + ": Pedido sem configuração automática"+ Environment.NewLine;
                        continue;
                    }

                    if (!pedido.Produto.ClassificacaoProduto.ConfiguracaoAutomaticaIntervalo.HasValue)
                    {
                        throw new ExcecaoTratada(pedido + ": O pedido não pode ser configurado pois a classificação do produto (" + pedido.Produto.ClassificacaoProduto + ") não possui intervalo definido");
                    }

                    if (!pedido.Produto.ClassificacaoProduto.ConfiguracaoAutomaticaReferencia.HasValue)
                    {
                        throw new ExcecaoTratada(pedido+": O pedido não pode ser configurado pois a classificação do produto (" + pedido.Produto.ClassificacaoProduto + ") não possui redferência definida");
                    }

                    DateTime dataConfiguracaoPedido;
                    switch (pedido.Produto.ClassificacaoProduto.ConfiguracaoAutomaticaReferencia)
                    {
                        case EasiConfiguracaoAutomaticaReferencia.DataCadastro:

                            dataConfiguracaoPedido = pedido.DataEntrada.AddDays(pedido.Produto.ClassificacaoProduto.ConfiguracaoAutomaticaIntervalo.Value);
                            break;
                        case EasiConfiguracaoAutomaticaReferencia.DataEntrega:
                            dataConfiguracaoPedido = pedido.DataEntrega.AddDays(-1 * pedido.Produto.ClassificacaoProduto.ConfiguracaoAutomaticaIntervalo.Value);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    if (dataConfiguracaoPedido.Date.CompareTo(dataAtual.Date) > 0)
                    {
                        logAvisos += pedido + ": Pedido só será configurado a partir do dia "+dataConfiguracaoPedido.ToString("dd/MM/yyyy")+ Environment.NewLine;
                        continue;
                    }

                    pedidosConfigurar.Add(new ConfiguradorPedido(pedido.Numero, pedido.Posicao, pedido.Cliente.ID.ToString(CultureInfo.InvariantCulture), (int) pedido.Cliente.FamiliaCliente.TipoEspecial, PedidoOrcamento.Pedido,(int) pedido.ID));

                }


                
                IConfiguradorEASI configurador = _configuradorEasiFactory.getInstance(_conn, _usuario, _tipoCalculoSemana, _diaCalculoSemana);
                foreach (ConfiguradorPedido pedido in pedidosConfigurar)
                {
                    
                    try
                    {
                        string aviso;
                        configurador.configurarPedido(pedido.oc, pedido.pos, pedido.idCliente, pedido.clienteEspecial, pedido.TipoEntidade, out aviso);

                        if (!string.IsNullOrWhiteSpace(aviso))
                        {
                            if (aviso.StartsWith(Environment.NewLine))
                            {
                                aviso = aviso.Substring((Environment.NewLine.Length));
                            }

                            logAvisos += pedido.oc + "/" + pedido.pos + ": " + aviso ;
                        }
                    }
                    catch (Exception a)
                    {
                        logErros +=  pedido.oc + "/" + pedido.pos+": Erro ao configurar o pedido - " + a.Message + Environment.NewLine;
                    }
                }

            }
            catch (ExcecaoTratada e)
            {
                logErros += e.Message + Environment.NewLine;
            }
            catch (Exception e)
            {
                logErros += "Erro inesperado ao configurar os pedidos" + e.Message + Environment.NewLine;
            }

        }

        public void SafeStop()
        {
            _toStop = true;
        }
    }
}