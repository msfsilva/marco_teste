using System;

namespace BibliotecaEntidades.Operacoes.Configurador
{
    public class PedidoDocumentoConfigurador : IEquatable<PedidoDocumentoConfigurador>, IComparable<PedidoDocumentoConfigurador>
    {
        public string Tipo { get; private set; }
        public string Codigo { get; private set; }
        public string Revisao { get; private set; }

        public PedidoDocumentoConfigurador(string tipo, string codigo, string revisao)
        {
            Tipo = tipo;
            Codigo = codigo;
            Revisao = revisao;
        }

        public bool Equals(PedidoDocumentoConfigurador other)
        {
            if (other == null)
            {
                return false;
            }
            else
            {
                return this.CompareTo(other) == 0;
            }
        }

        public int CompareTo(PedidoDocumentoConfigurador other)
        {
            if (other == null)
            {
                return 1;
            }

            int res = this.Tipo.CompareTo(other.Tipo);
            if (res != 0)
            {
                return res;
            }

            res = this.Codigo.CompareTo(other.Codigo);
            if (res != 0)
            {
                return res;
            }

            res = this.Revisao.CompareTo(other.Revisao);
            if (res != 0)
            {
                return res;
            }

            return 0;

        }

    }
}