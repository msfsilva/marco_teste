using System;

namespace BibliotecaNotasFiscais
{
    internal class OrganizaNfSubItemKey : IEquatable<OrganizaNfSubItemKey>
    {
        public bool Equals(OrganizaNfSubItemKey other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Id, other.Id) && string.Equals(Oc, other.Oc) && string.Equals(Pos, other.Pos) && IdCliente == other.IdCliente && PedidoNovo.Equals(other.PedidoNovo) && string.Equals(IdPedidoItem, other.IdPedidoItem) && string.Equals(IdProduto, other.IdProduto) && string.Equals(IdProdutoK, other.IdProdutoK) && ItemOriginalPedido.Equals(other.ItemOriginalPedido) && string.Equals(ObservacaoPedido, other.ObservacaoPedido) && QtdTotalPedido.Equals(other.QtdTotalPedido) && ValorUnitario.Equals(other.ValorUnitario)&& ValorDesconto.Equals(other.ValorDesconto);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OrganizaNfSubItemKey) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Id != null ? Id.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Oc != null ? Oc.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Pos != null ? Pos.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ IdCliente;
                hashCode = (hashCode*397) ^ PedidoNovo.GetHashCode();
                hashCode = (hashCode*397) ^ (IdPedidoItem != null ? IdPedidoItem.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (IdProduto != null ? IdProduto.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (IdProdutoK != null ? IdProdutoK.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ ItemOriginalPedido.GetHashCode();
                hashCode = (hashCode*397) ^ (ObservacaoPedido != null ? ObservacaoPedido.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ QtdTotalPedido.GetHashCode();
                hashCode = (hashCode*397) ^ ValorUnitario.GetHashCode();
                hashCode = (hashCode*397) ^ ValorDesconto.GetHashCode();
                return hashCode;
            }
        }

        internal int Id { get; private set; }
        internal string Oc { get; private set; }
        internal string Pos { get; private set; }
        internal int IdCliente { get; private set; }
        internal bool PedidoNovo { get; private set; }
        internal string IdPedidoItem { get; private set; }

        internal string IdProduto { get; private set; }
        internal string IdProdutoK { get; private set; }
        internal bool ItemOriginalPedido { get; private set; }
        internal string ObservacaoPedido { get; private set; }
        public double QtdTotalPedido { get; set; }
        public double ValorUnitario { get; private set; }
        public double ValorDesconto { get; private set; }

        public OrganizaNfSubItemKey(int id, string oc, string pos, int idCliente, bool pedidoNovo, string idPedidoItem, string idProduto, string idProdutoK, bool itemOriginalPedido, string observacaoPedido, double valorUnitario, double qtdTotalPedido, double valorDesconto)
        {
            Id = id;
            Oc = oc;
            Pos = pos;
            IdCliente = idCliente;
            PedidoNovo = pedidoNovo;
            IdPedidoItem = idPedidoItem;
            IdProduto = idProduto;
            IdProdutoK = idProdutoK;
            ItemOriginalPedido = itemOriginalPedido;
            ObservacaoPedido = observacaoPedido;
            ValorUnitario = valorUnitario;
            QtdTotalPedido = qtdTotalPedido;
            ValorDesconto = valorDesconto;
        }
    }
}