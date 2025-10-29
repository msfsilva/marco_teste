#region Referencias

using System;
using System.IO;
using System.Threading;

#endregion

namespace BibliotecaCompras
{
    public class ImportNFEntradaRunner
    {
        private readonly ImportNFEntrada importNFEntrada;
        readonly int SleepTimeAfterRun;
        public Boolean running = false;
        private Boolean _toStop = false;
        private readonly string logFile;
        readonly Semaphore geralRunning;
        readonly string importLogPath;

        public ImportNFEntradaRunner(
           ImportNFEntrada importNFEntrada,
            string importLogPath,
            int Intervalo, ref Semaphore geralRunning)
        {

            this.importNFEntrada = importNFEntrada;
            this.SleepTimeAfterRun = Intervalo * 60 * 1000;
            this.geralRunning = geralRunning;
            this.importLogPath = importLogPath;
            this.logFile = @AppDomain.CurrentDomain.BaseDirectory + "\\"+ Configurations.DataIndependenteClass.GetData().ToString("yyyyMMdd") + "-LogImportacaoNFEntrada.txt";
        }

         public void start()
        {
            while (!_toStop)
            {
                try
                {

                    running = true;

                    this.geralRunning?.WaitOne();

                    this.importNFEntrada.Importar();

                    if (this.importNFEntrada.erros.Length > 0)
                    {
                        File.WriteAllText(@importLogPath, importNFEntrada.erros);
                        
                    }

                    running = false;


                }
                catch (Exception a)
                {
                    try
                    {
                        if (File.Exists(this.logFile))
                        {
                            FileInfo fi = new FileInfo(this.logFile);
                            if (fi.Length > 104857600)
                            {
                                fi.Delete();
                            }
                        }

                        StreamWriter logWriter = new StreamWriter(this.logFile, true);
                        logWriter.WriteLine("Erro não esperado: " + a);
                        logWriter.Close();
                    }
                    catch
                    {
                    }
                }
                finally
                {
                    this.geralRunning?.Release();
                }
                Thread.Sleep(SleepTimeAfterRun);
            }

        }

         public void SafeStop()
         {
             this._toStop = true;
         }
    }
}
