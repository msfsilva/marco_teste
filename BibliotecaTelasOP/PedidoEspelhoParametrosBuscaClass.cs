using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BibliotecaTelasOP
{
    public class PedidoEspelhoParametrosBuscaClass
    {
        public int idCliente { get;  set; }
        public string numero { get;  set; }
        public int? posicao { get;  set; }

        public PedidoEspelhoParametrosBuscaClass(int idCliente, string numero, int? posicao)
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
