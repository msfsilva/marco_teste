namespace BibliotecaCompras
{
    internal class FornecedorUnidadePrecoClass
    {
        public string IdFornecedor { get; private set; }
        public double Preco { get; private set; }
        public double? QtdUnidadeUsoPorUnidadeCompra { get; private set; }
        public string UnidadeCompra { get; private set; }

        public FornecedorUnidadePrecoClass(string idFornecedor, double? preco, double? qtdUnidadeUsoPorUnidadeCompra, string unidadeCompra)
        {
            IdFornecedor = idFornecedor;
            Preco = preco.HasValue ? preco.Value : 0;
            QtdUnidadeUsoPorUnidadeCompra = qtdUnidadeUsoPorUnidadeCompra;
            UnidadeCompra = unidadeCompra;
        }
    }
}
