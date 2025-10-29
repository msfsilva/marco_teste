namespace BibliotecaCompras
{
    public class OrcamentoCompraItemKeyClass
    {
        private long? idProduto;
        private long? idMaterial;
        private long? idEpi;

        public OrcamentoCompraItemKeyClass(long? _idProduto, long? _idMaterial, long? _idEpi)
        {
            this.idProduto = _idProduto;
            this.idMaterial = _idMaterial;
            this.idEpi = _idEpi;
        }



    }
}
