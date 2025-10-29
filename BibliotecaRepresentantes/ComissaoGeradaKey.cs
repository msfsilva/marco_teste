using System;
using BibliotecaEntidades.Entidades;

namespace BibliotecaRepresentantes
{
    internal class ComissaoGeradaKey : IEquatable<ComissaoGeradaKey>
    {
        public RepresentanteClass Representante { get; private set; }
        public VendedorClass Vendedor { get; private set; }
        public string Tipo { get; private set; }
        public ContaBancariaClass ContaBancaria { get; private set; }
        public CentroCustoLucroClass CentroCusto { get; private set; }

        public ComissaoGeradaKey(RepresentanteClass representante, VendedorClass vendedor, string Tipo, ContaBancariaClass contaBancaria, CentroCustoLucroClass centroCusto)
        {
            Representante = representante;
            Vendedor = vendedor;
            this.Tipo = Tipo;
            ContaBancaria = contaBancaria;
            CentroCusto = centroCusto;
        }


        public bool Equals(ComissaoGeradaKey other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Representante, Representante) && Equals(other.Vendedor, Vendedor) && Equals(other.Tipo, Tipo) && Equals(other.ContaBancaria, ContaBancaria) && Equals(other.CentroCusto, CentroCusto);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(ComissaoGeradaKey)) return false;
            return Equals((ComissaoGeradaKey)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = (Representante != null ? Representante.GetHashCode() : 0);
                result = (result*397) ^ (Vendedor != null ? Vendedor.GetHashCode() : 0);
                result = (result*397) ^ (Tipo != null ? Tipo.GetHashCode() : 0);
                result = (result*397) ^ (ContaBancaria != null ? ContaBancaria.GetHashCode() : 0);
                result = (result*397) ^ (CentroCusto != null ? CentroCusto.GetHashCode() : 0);
                return result;
            }
        }

        public static bool operator ==(ComissaoGeradaKey left, ComissaoGeradaKey right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ComissaoGeradaKey left, ComissaoGeradaKey right)
        {
            return !Equals(left, right);
        }
    }
}