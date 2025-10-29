#region Referencias

using System;

#endregion

namespace BibliotecaInterfaceModulosCliente
{
    public class EasiException : Exception
    {
        public string motivo { get; private set; }
        public string Complemento { get; set; }
        
        public EasiException(string m, string mensagem)
            : base(mensagem)
        {
            this.motivo = m;
        }

        public EasiException(string m)
            : base()
        {
            this.motivo = m;
        }

        
    }
}
