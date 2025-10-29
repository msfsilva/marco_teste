namespace BibliotecaPedidos
{
    public class PedidoEspelhoParametrosBuscaClass
    {
        public long idCliente { get;  set; }
        public string numero { get;  set; }
        public int? posicao { get;  set; }

        public PedidoEspelhoParametrosBuscaClass(long idCliente, string numero, int? posicao)
        {
            this.idCliente = idCliente;
            this.numero = numero;
            this.posicao = posicao;
        }

        public PedidoEspelhoParametrosBuscaClass()
        {
            
        }
    }
}
