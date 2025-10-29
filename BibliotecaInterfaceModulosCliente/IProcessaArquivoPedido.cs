#region Referencias

using System.IO;

#endregion

namespace BibliotecaInterfaceModulosCliente
{
    public interface IProcessaArquivoPedido
    {    
        void run(StreamReader sr, ClienteConfiguracao configuracao, string origem);
    }
}
