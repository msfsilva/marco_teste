#region Referencias

using System;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;

#endregion

namespace BibliotecaCompras
{
    class LoteEtiquetaMRPReportClass
    {
        public int idPedidoItem { get; private set; }
        public int idLote { get; private set; }
        public string Lote { get; private set; }
        public string Cliente { get; private set; }
        public string Pedido { get; private set; }
        public string ItemPai { get; private set; }
        public double Quantidade { get; private set; }


        public LoteEtiquetaMRPReportClass(int idPedidoItem, double quantidade, string lote, int idLote)
        {
            this.idPedidoItem = idPedidoItem;
            this.idLote = idLote;
            Quantidade = quantidade;
            Lote = lote;
        }

        public void Load(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                command.CommandText =
                    "SELECT  " +
                    "  public.pedido_item.pei_numero || '/' || public.pedido_item.pei_posicao as Pedido, " +
                    "  public.produto.pro_codigo, " +
                    "  public.cliente.cli_nome_resumido " +
                    "FROM " +
                    "  public.pedido_item " +
                    "  INNER JOIN public.produto ON (public.pedido_item.id_produto = public.produto.id_produto) " +
                    "  INNER JOIN public.cliente ON (public.pedido_item.id_cliente = public.cliente.id_cliente) " +
                    "WHERE " +
                    "  public.pedido_item.id_pedido_item = :id_pedido_item ";
             
                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_pedido_item", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.idPedidoItem;

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                if (!read.HasRows)
                {
                    throw new Exception("ID Inválido");
                }

                read.Read();

                this.Pedido = read["Pedido"].ToString();
                this.ItemPai = read["pro_codigo"].ToString();
                this.Cliente = read["cli_nome_resumido"].ToString();

                read.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados da etiqueta de MRP\r\n" + e.Message, e);
            }

        }
    }
}
