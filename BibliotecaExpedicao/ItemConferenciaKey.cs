using System;

namespace BibliotecaExpedicao
{
    public class ItemConferenciaKey : IEquatable<ItemConferenciaKey>
    {
        public int IdCliente { get; private set; }
        public string OrderNumber { get; private set; }
        public int OrderPos { get; private set; }
        public string CodProduto { get; private set; }
        public string CodProdutoCliente { get; private set; }
        public string DescricaoProduto { get; private set; }
        public TipoItem Tipo { get; private set; }
        public string Medida { get; private set; }
        public string Var1Nome { get; private set; }
        public string Var1Valor { get; private set; }
        public string Var2Nome { get; private set; }
        public string Var2Valor { get; private set; }
        public string Var3Nome { get; private set; }
        public string Var3Valor { get; private set; }
        public string Var4Nome { get; private set; }
        public string Var4Valor { get; private set; }

        public string idProduto { get; private set; }
        public string idProdutoK { get; private set; }
        
        public bool itemOriginalPedido { get; private set; }
        public bool itemEmiteNF { get; private set; }

        public ItemConferenciaKey(
            string orderNumber, int orderPos,int idCliente,
            string codProduto, string codProdutoCliente, string idProduto,
            string idProdutoK, string descricaoProduto, TipoItem tipo, string medida, string var1Nome, string var1Valor,
            string var2Nome, string var2Valor, string var3Nome, string var3Valor, string var4Nome, string var4Valor,
            bool itemOriginalPedido, bool itemEmiteNF)
        {
            IdCliente = idCliente;
            this.OrderNumber = orderNumber;
            this.OrderPos = orderPos;
            this.CodProduto = codProduto;
            this.CodProdutoCliente = codProdutoCliente;
            this.DescricaoProduto = descricaoProduto;
            Tipo = tipo;
            Medida = medida;
            this.Var1Nome = var1Nome;
            this.Var1Valor = var1Valor;
            this.Var2Nome = var2Nome;
            this.Var2Valor = var2Valor;
            this.Var3Nome = var3Nome;
            this.Var3Valor = var3Valor;
            this.Var4Nome = var4Nome;
            this.Var4Valor = var4Valor;

            this.idProduto = idProduto;
            this.idProdutoK = idProdutoK;
            this.itemOriginalPedido = itemOriginalPedido;
            this.itemEmiteNF = itemEmiteNF;
        }

        #region IEquatable<itemConferenciaKey> Members

        public bool Equals(ItemConferenciaKey other)
        {
            return
                this.OrderNumber == other.OrderNumber &&
                this.OrderPos == other.OrderPos &&
                this.CodProduto == other.CodProduto &&
                this.CodProdutoCliente == other.CodProdutoCliente &&
                this.DescricaoProduto == other.DescricaoProduto &&
                this.Tipo == other.Tipo &&
                this.Medida == other.Medida &&
                this.Var1Nome == other.Var1Nome &&
                this.Var1Valor == other.Var1Valor &&
                this.Var2Nome == other.Var2Nome &&
                this.Var2Valor == other.Var2Valor &&
                this.Var3Nome == other.Var3Nome &&
                this.Var3Valor == other.Var3Valor &&
                this.Var4Nome == other.Var4Nome &&
                this.Var4Valor == other.Var4Valor &&
                this.idProduto == other.idProduto &&
                this.idProdutoK == other.idProdutoK &&
                this.itemOriginalPedido == other.itemOriginalPedido &&
                this.itemEmiteNF == other.itemEmiteNF &&
                this.IdCliente == other.IdCliente;
        }

        #endregion
    }
}