namespace BibliotecaPedidos
{
    public class PedidoSelecaoClass
    {
        public string Oc { get; private set; }
        public int Pos { get; private set; }
        public long IdCliente { get; private set; }

        public PedidoSelecaoClass(string oc, int pos, long idCliente)
        {
            Oc = oc;
            Pos = pos;
            IdCliente = idCliente;
        }
    }
}