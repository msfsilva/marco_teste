using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaInterfaceModulosCliente
{
    public class PedidoJaExistente : EasiException
    {

        public PedidoJaExistente(string oc, int pos) : base("Pedido já existente.", oc + "/" + pos)
        {
        }
    }
}
