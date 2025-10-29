namespace BibliotecaPedidos
{
    internal class MateriaisPedidoReportClass
    {
        public string Material { get; private set; }
        public string Dimensao { get; private set; }
        public double Quantidade { get; private set; }

        public string Pedido { get; private set; }
        public string Cliente { get; private set; }
        public string UnidadeUso { get; private set; }
        public string UnidadeCompra { get; private set; }
        public double QuantidadeUnidadeCompra { get; private set; }
        public string DescricaoMaterial { get; private set; }

        public string DescricaoAdicionalMaterial { get; private set; }


        public MateriaisPedidoReportClass(string pedido, string cliente, string material, string descricaoMaterial, string descricaoAdicionalMaterial, string dimensao, double quantidade, string unidadeUso, double quantidadeUnidadeCompra, string unidadeCompra)
        {
            DescricaoMaterial = descricaoMaterial;
            QuantidadeUnidadeCompra = quantidadeUnidadeCompra;
            UnidadeCompra = unidadeCompra;
            UnidadeUso = unidadeUso;
            Cliente = cliente;
            Pedido = pedido;
            Material = material;
            Dimensao = dimensao;
            Quantidade = quantidade;
            DescricaoAdicionalMaterial = descricaoAdicionalMaterial;

        }
    }
}
