using System;
using System.IO;
using System.Threading;
using BibliotecaExportacaoDados;
using Configurations;
using IWTPostgreNpgsql;
using ProjectConstants;

namespace BibliotecaAutomacoes
{
    public class ExportPedidosRunnerClass
    {
        private readonly Semaphore _semaphore;
        private ExportaPedidosCSV exportaPedidos;
        private int Hora;
        private int Minuto;
        private bool Ativo;
        public Boolean running;
        private Boolean _toStop;
        readonly int SleepTimeAfterRun;
        private string logFile;


        public ExportPedidosRunnerClass(ref Semaphore semaphore, IWTPostgreNpgsqlConnection conn)
        {
            _semaphore = semaphore;
            exportaPedidos = new ExportaPedidosCSV(conn);
            SleepTimeAfterRun = ((int.Parse(IWTConfiguration.Conf.getConf(Constants.EXPORTACAO_PEDIDOS_INTERVALO))*60)*1000);
            logFile = AppDomain.CurrentDomain.BaseDirectory + "\\logExportacaoPedidos" + DataIndependenteClass.GetData().ToString("yyyMMdd") + ".txt";

            Ativo = IWTConfiguration.Conf.getBoolConf(Constants.EXPORTACAO_PEDIDOS_ATIVA);

        
        }

        public void Start()
        {
            while (!_toStop)
            {
                try
                {
                    running = true;
                    if (Ativo)
                    {
                        _semaphore?.WaitOne();
                        try
                        {
                            exportaPedidos.gerarCSV(null, null, null, null, null, null, null, null,
                                IWTConfiguration.Conf.getConf(
                                    Constants.DIRETORIO_EXPORTACAO_CSV));
                        }
                        finally
                        {
                            _semaphore?.Release();
                        }
                    }

                    running = false;
                   
                }
                catch (Exception a)
                {
                    try
                    {
                        if (File.Exists(logFile))
                        {
                            FileInfo fi = new FileInfo(logFile);
                            if (fi.Length>104857600)
                            {
                                fi.Delete();
                            }
                        }

                        StreamWriter logWriter = new StreamWriter(logFile, true);
                        logWriter.WriteLine("Erro não esperado: " + a);
                        logWriter.Close();
                    }
                    catch
                    {
                    }

                }

                Thread.Sleep(SleepTimeAfterRun);
            }

        }

        public void SafeStop()
        {
            _toStop = true;
        }
    }
}
