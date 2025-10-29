using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BibliotecaInterfaceModulosCliente
{
    class ProcessaArquivoException : Exception
    {
        public string motivo { get; set; }

        public ProcessaArquivoException(string m)
        {
            motivo = m;
        }
    }
}
