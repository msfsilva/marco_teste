#region Referencias

using System;
using IWTPostgreNpgsql;

using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;

#endregion

namespace BibliotecaControleRevisao
{
    public class RevisaoGenericaClass
    {
        public string justificativaAtual { get; private set; }
        public DateTime? Data { get; private set; }
        public AcsUsuarioClass Usuario { get; private set; }

        public RevisaoGenericaClass(string justificativa, DateTime? Data, AcsUsuarioClass usuario)
        {
            this.justificativaAtual = justificativa;
            this.Data = Data;
            this.Usuario = usuario;
        }

        public RevisaoGenericaClass(string justificativa, AcsUsuarioClass usuarioRevisor)
        {
            this.justificativaAtual = justificativa;
            this.Data = DateTime.Now;
            this.Usuario = usuarioRevisor;
        }

        public void Revisar(string justificativa, AcsUsuarioClass usuarioRevisor)
        {
            this.justificativaAtual = justificativa;
            this.Data = DateTime.Now;
            this.Usuario = usuarioRevisor;
        }
    }
}
