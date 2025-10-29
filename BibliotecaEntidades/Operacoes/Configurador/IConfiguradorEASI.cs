using System.Collections.Generic;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Entidades;

namespace BibliotecaEntidades.Operacoes.Configurador
{
    public interface IConfiguradorEASI
    {
        void configurarPedido(string oc, int pos, string idCliente, int clienteEspecial, PedidoOrcamento tipoEntidade, out string avisos);

        Dictionary<string, Variavel> getVariaveis(string oc, int pos, string idCliente, PedidoOrcamento tipoEntidade);

        Dictionary<string, Variavel> getVariaveisItem(string oc, int pos, string idCliente, int subLinha, PedidoOrcamento tipoEntidade);

        List<PedidoDocumentoConfigurador> getDocumentos(int idPedidoItem);

        void desconfigurarPedido(string oc, int pos, string idCliente, PedidoOrcamento tipoEntidade);

        List<PedidoDocumentoConfigurador> searchDocumentosCliente();

        bool validaDocumentosItemFilho(string oc, int pos, ClienteClass cliente, ProdutoClass produto);
    }
}
