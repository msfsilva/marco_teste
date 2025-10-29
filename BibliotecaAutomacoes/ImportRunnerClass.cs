#region Referencias

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using BibliotecaInterfaceModulosCliente;
using Configurations;

#endregion

namespace BibliotecaAutomacoes
{
    public class ImportRunnerClass
    {
        protected readonly Int32 SleepTimeAfterRun;
        public Boolean running;
        protected Boolean _toStop;
        protected readonly string logFile;
        protected readonly Semaphore geralRunning;

        protected List<ProcessamentoBase> modulosClienteRodar;

        public ImportRunnerClass(
            string Intervalo,
            List<ProcessamentoBase> modulosClienteRodar,
            ref Semaphore geralRunning)
        {

            SleepTimeAfterRun = Convert.ToInt32(Intervalo)*60*1000;
            this.modulosClienteRodar = modulosClienteRodar;
            this.geralRunning = geralRunning;
            logFile = AppDomain.CurrentDomain.BaseDirectory + "\\logImportacaoPedidos_" + DataIndependenteClass.GetData().ToString("yyyMMdd") + ".txt";
        }

        public void start()
        {
            while (!_toStop)
            {
                try
                {

                    running = true;

                    geralRunning?.WaitOne();
                    RodarFuncoesEspecificasClienteAntesImportacaoPedido();

                    foreach (ProcessamentoBase moduloCliente in modulosClienteRodar)
                    {
                        moduloCliente.start();
                    }

                    RodarFuncoesEspecificasClienteAposImportacaoPedido();

                    running = false;
                   



                    //Thread.Sleep(SleepTime);
                }
                catch (Exception a)
                {
                    try
                    {
                        if (File.Exists(logFile))
                        {
                            FileInfo fi = new FileInfo(logFile);
                            if (fi.Length > 104857600)
                            {
                                fi.Delete();
                            }
                        }

                        StreamWriter logWriter = new StreamWriter(logFile, true);
                        logWriter.WriteLine("Erro não esperado: " + a);
                        logWriter.Close();
                        if (running)
                        {
                            geralRunning.Release();
                        }
                    }
                    catch
                    {
                    }
                }
                finally
                {
                    geralRunning?.Release();
                }

                Thread.Sleep(SleepTimeAfterRun);
            }

        }

        public void SafeStop()
        {
            _toStop = true;
        }

        protected virtual void RodarFuncoesEspecificasClienteAntesImportacaoPedido()
        {

        }
        protected virtual void RodarFuncoesEspecificasClienteAposImportacaoPedido()
        {

        }
    }
}
