using System;
using System.IO;
using System.Net;
using IWTDotNetLib;

namespace BibliotecaEntidades.SDC.Auxiliares
{
    internal class ProxyHelper
    {
        private static WebProxy proxy = null;
        private static bool proxyLoaded = false;       

        private ProxyHelper()
        {
            
        }
       
        public static WebProxy GetProxy()
        {
            StreamReader read = null;
            try
            {
                if (!proxyLoaded)
                {
                    if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "proxyconf.txt"))
                    {
                        string _usuarioProxy = "";
                        string _senhaProxy = "";
                        string _enderecoProxy = "";
                        string _domainProxy = "";
                        string line;
                        read = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "proxyconf.txt");
                        while (!read.EndOfStream)
                        {
                            line = read.ReadLine();
                            if (string.IsNullOrWhiteSpace(line))
                            {
                                continue;
                            }

                            if (line.StartsWith("usuario:"))
                            {
                                _usuarioProxy = line.Replace("usuario:", "").Replace("\r\n", "").Trim();
                            }
                            if (line.StartsWith("senha:"))
                            {
                                _senhaProxy = line.Replace("senha:", "").Replace("\r\n", "").Trim();
                            }
                            if (line.StartsWith("endereco:"))
                            {
                                _enderecoProxy = line.Replace("endereco:", "").Replace("\r\n", "").Trim();
                            }
                            if (line.StartsWith("domain:"))
                            {
                                _domainProxy = line.Replace("domain:", "").Replace("\r\n", "").Trim();
                            }
                        }

                        proxy = new WebProxy(_enderecoProxy, false)
                        {
                            Credentials = new NetworkCredential(_usuarioProxy, _senhaProxy, _domainProxy)
                        };

                        proxyLoaded = true;
                    }
                }
                return proxy;
            }
            catch (ExcecaoTratada e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao verificar se existe proxy ou obter os dados do proxy");
            }
            finally
            {
                if (read != null)
                {
                    read.Close();
                }
            }
        }
    }
}
