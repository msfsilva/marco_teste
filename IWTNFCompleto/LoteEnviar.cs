using System.Collections.Generic;
using IWTNFCompleto.BibliotecaEntidades.Entidades;

namespace IWTNFCompleto
{
    public class LoteEnviar
    {
        public NfeCompletoLoteClass NfeCompletoLote { get; set; }
        public int NumeroLoteInterno { get; set; }
        public bool LoteEnviado { get; set; }
        public string Recibo { get; set; }
        public string Observacao { get; set; }
        public List<NotaEnviar> Notas { get; set; }

        public LoteEnviar()
        {
            this.Notas = new List<NotaEnviar>();
            this.LoteEnviado = false;
        }
    }
}