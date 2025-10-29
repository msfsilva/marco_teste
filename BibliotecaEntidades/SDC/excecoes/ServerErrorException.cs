using System.Runtime.CompilerServices;
using BibliotecaEntidades.SDC.dto;
using IWTDotNetLib;

namespace BibliotecaEntidades.SDC.excecoes
{
    public class ServerErrorException : ExcecaoTratada
    {
        public ErrorClass error { get; }


        public ServerErrorException(ErrorClass error) : base(error.message)
        {
            this.error = error;
        }
    }
}
