using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using IWTFunctions;

namespace IWTNFCompleto
{
    public static class ProxyClass
    {
        private static string _usuarioProxy;
        public static string UsuarioProxy
        {
            get
            {
                if (_usuarioProxy == null)
                {
                    LoadProxy();
                }
                return _usuarioProxy;
            }
        }

        private static string _senhaProxy;
        public static string SenhaProxy
        {
            get
            {
                if (_senhaProxy == null)
                {
                    LoadProxy();
                }
                return _senhaProxy;
            }
        }

        private static string _enderecoProxy;
        public static string EnderecoProxy
        {
            get
            {
                if (_enderecoProxy == null)
                {
                    LoadProxy();
                }
                return _enderecoProxy;
            }
        }

        private static string _domainProxy;
        public static string DomainProxy
        {
            get
            {
                if (_domainProxy == null)
                {
                    LoadProxy();
                }
                return _domainProxy;
            }
        }

        private static bool? _comProxy = null;
        public static bool ComProxy
        {
            get
            {
                if (_comProxy == null)
                {
                    LoadProxy();
                }
                return _comProxy.HasValue && _comProxy.Value;
            }
        }

        private static void LoadProxy()
        {
            string pathArquivoProxy = System.Reflection.Assembly.GetEntryAssembly().Location;
            pathArquivoProxy = Path.GetDirectoryName(pathArquivoProxy);
            pathArquivoProxy += "\\proxyconf.txt";


            //LogClass.EscreverLog("Caminho arquivo Proxy: " + pathArquivoProxy,caminhoLog);

            if (File.Exists(pathArquivoProxy))
            {
                //LogClass.EscreverLog("Existe arquivo Proxy", caminhoLog);

                StreamReader read = null;
                try
                {
                    string line;
                    read = new StreamReader(pathArquivoProxy);
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
                            //LogClass.EscreverLog("Proxy usuário: " + _usuarioProxy, caminhoLog);
                        }
                        if (line.StartsWith("senha:"))
                        {
                            _senhaProxy = line.Replace("senha:", "").Replace("\r\n", "").Trim();
                            //LogClass.EscreverLog("Proxy senha: " + _senhaProxy, caminhoLog);
                        }
                        if (line.StartsWith("endereco:"))
                        {
                            _enderecoProxy = line.Replace("endereco:", "").Replace("\r\n", "").Trim();
                            //LogClass.EscreverLog("Proxy endereço: " + _enderecoProxy, caminhoLog);
                        }
                        if (line.StartsWith("domain:"))
                        {
                            _domainProxy = line.Replace("domain:", "").Replace("\r\n", "").Trim();
                            //LogClass.EscreverLog("Proxy domain: " + _domainProxy, caminhoLog);
                        }
                    }
                }
                finally
                {
                    if (read != null)
                    {
                        read.Close();

                    }

                    _comProxy = !string.IsNullOrWhiteSpace(_enderecoProxy);
                }
            }
            else
            {
                //LogClass.EscreverLog("Não Existe arquivo Proxy", caminhoLog);
            }

        }
    }
}
