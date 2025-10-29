using BibliotecaEntidades.ClassesAuxiliares;
using IWTNF.Entidades.Entidades;

namespace BibliotecaNotasFiscais
{
    public class nfEmitida
    {
        internal organizaNfClass infosNota { private set; get; }
        public NfPrincipalClass nf { private set; get; }

        public EmitenteClass Emitente { private set; get; }

        internal nfEmitida(organizaNfClass infosNota, NfPrincipalClass nf, EmitenteClass emitente)
        {
            this.infosNota = infosNota;
            this.nf = nf;
            Emitente = emitente;
        }


    }
}