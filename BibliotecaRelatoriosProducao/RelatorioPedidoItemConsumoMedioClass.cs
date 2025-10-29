#region Referencias

using System;
using System.Collections.Generic;
using IWTPostgreNpgsql;
using Npgsql;

#endregion

namespace BibliotecaRelatoriosProducao
{

    internal enum TipoRelatorioPedidoItemConsumoMedio { ordernarMensal, ordernarTrimestral, ordernarSemestral, ordernarAnual }

    public class RelatorioPedidoItemConsumoMedioClass
    {
        readonly IWTPostgreNpgsqlConnection conn;
        public Dictionary<itemRelatorioPedidoItemConsumoMedioKeyClass, itemRelatorioPedidoItemConsumoMedioClass> Itens { get; private set; }
        public itemRelatorioPedidoItemConsumoMedioClass itemUnico
        {
            get
            {
                if (this.Itens != null && this.Itens.Count > 0)
                {
                    return new List<itemRelatorioPedidoItemConsumoMedioClass>(this.Itens.Values)[0];
                }
                else
                {
                    return null;
                }
            }
        }


        public RelatorioPedidoItemConsumoMedioClass(IWTPostgreNpgsqlConnection conn)
        {
            this.conn = conn;
        }


        public void Calcular(long? idProduto, long? idCliente, long? idProdutoK, string dimensao, bool somenteMensal)
        {
            try
            {
                this.Itens = new Dictionary<itemRelatorioPedidoItemConsumoMedioKeyClass, itemRelatorioPedidoItemConsumoMedioClass>();
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();

                #region Mensal
                DateTime dataInicio = Configurations.DataIndependenteClass.GetData().AddMonths(-1);


                if (idProdutoK.HasValue)
                {
                    command.CommandText =
                        "SELECT  " +
                        "  public.produto_k.id_produto_k as id_produto,   " +
                        "  public.produto_k.prk_codigo as pro_codigo,   " +
                        "  '' as pro_descricao,   " +
                        "  SUM(public.pedido_item.pei_quantidade) as qtdTotal, " +
                        "  SUM(public.pedido_item.pei_preco_total) as precoTotal, " +
                        "  MAX(pei_data_entrada) as dataUltimoPedido, " +
                        "  public.order_item_etiqueta.oie_dimensao " +
                        "FROM   " +
                        "  public.pedido_item   " +
                        "  LEFT OUTER JOIN public.order_item_etiqueta ON (public.pedido_item.id_pedido_item = public.order_item_etiqueta.id_pedido_item) " +
                        "  INNER JOIN public.produto_k ON produto_k.id_produto_k = order_item_etiqueta.id_produto_k " +
                        "  INNER JOIN public.cliente ON (public.pedido_item.id_cliente = public.cliente.id_cliente) " +
                        "WHERE " +
                        "  pei_data_entrada > '" + dataInicio.ToString("yyyy-MM-dd") + "' AND " +
                        "  (public.order_item_etiqueta.oie_item_original_pedido = 1 OR public.order_item_etiqueta.oie_item_original_pedido IS NULL) " +
                        " AND produto_k.id_produto_k = " + idProdutoK.Value + " " +
                        " GROUP BY " +
                        "  public.produto_k.id_produto_k,   " +
                        "  public.produto_k.prk_codigo, " +
                        "  public.order_item_etiqueta.oie_dimensao ";
                }
                else
                {
                    command.CommandText =
                        "SELECT  " +
                        "  public.produto.id_produto,   " +
                        "  public.produto.pro_codigo,   " +
                        "  public.produto.pro_descricao,   " +
                        "  SUM(public.pedido_item.pei_quantidade) as qtdTotal, " +
                        "  SUM(public.pedido_item.pei_preco_total) as precoTotal, " +
                        "  MAX(pei_data_entrada) as dataUltimoPedido, " +
                        "  public.order_item_etiqueta.oie_dimensao " +
                        "FROM   " +
                        "  public.pedido_item   " +
                        "  INNER JOIN public.produto ON (public.pedido_item.id_produto = public.produto.id_produto)  " +
                        "  LEFT OUTER JOIN public.order_item_etiqueta ON (public.pedido_item.id_pedido_item = public.order_item_etiqueta.id_pedido_item) " +
                        "  INNER JOIN public.cliente ON (public.pedido_item.id_cliente = public.cliente.id_cliente) " +
                        "WHERE " +
                        "  pei_data_entrada > '" + dataInicio.ToString("yyyy-MM-dd") + "' AND " +
                        "  (public.order_item_etiqueta.oie_item_original_pedido = 1 OR public.order_item_etiqueta.oie_item_original_pedido IS NULL) ";

                    if (idProduto.HasValue)
                    {
                        string DimensaoClause = "";
                        if (dimensao == "" || dimensao == "0" || string.IsNullOrWhiteSpace(dimensao))
                        {
                            DimensaoClause = " (oie_dimensao IS NULL OR oie_dimensao LIKE '' OR oie_dimensao LIKE '0' )";
                        }
                        else{
                            DimensaoClause = " oie_dimensao LIKE '" + dimensao + "' ";
                        }

                        command.CommandText += " AND produto.id_produto = " + idProduto.Value + " AND " + DimensaoClause + " ";
                    }

                    if(idCliente.HasValue)
                    {
                        command.CommandText += " AND public.cliente.id_cliente = " + idCliente.Value + " ";
                    }
                    

                    command.CommandText +=
                        " GROUP BY " +
                        "  public.produto.id_produto,   " +
                        "  public.produto.pro_codigo, " +
                        "  public.produto.pro_descricao, " +
                        "  public.order_item_etiqueta.oie_dimensao ";
                }


                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();


                itemRelatorioPedidoItemConsumoMedioKeyClass keyTemp;
                while (read.Read())
                {
                   keyTemp =
                   new itemRelatorioPedidoItemConsumoMedioKeyClass(
                          read["id_produto"].ToString(),
                          read["oie_dimensao"] + "");
                    Itens.Add(
                        keyTemp,
                        new itemRelatorioPedidoItemConsumoMedioClass(
                            read["id_produto"].ToString(),
                            read["pro_codigo"].ToString(),
                            read["pro_descricao"].ToString(),
                            read["oie_dimensao"]+"",
                            Convert.ToDateTime(read["dataUltimoPedido"]),
                            Convert.ToDouble(read["qtdTotal"]),
                            Convert.ToDouble(read["precoTotal"])
                            ));

                }
                read.Close();

                #endregion

                if (!somenteMensal)
                {
                    #region Trimestral
                    dataInicio = Configurations.DataIndependenteClass.GetData().AddMonths(-3);


                    if (idProdutoK.HasValue)
                    {
                        command.CommandText =
                            "SELECT  " +
                            "  public.produto_k.id_produto_k as id_produto,   " +
                            "  public.produto_k.prk_codigo as pro_codigo,   " +
                            "  '' as pro_descricao,   " +
                            "  SUM(public.pedido_item.pei_quantidade) as qtdTotal, " +
                            "  SUM(public.pedido_item.pei_preco_total) as precoTotal, " +
                            "  MAX(pei_data_entrada) as dataUltimoPedido, " +
                            "  public.order_item_etiqueta.oie_dimensao " +
                            "FROM   " +
                            "  public.pedido_item   " +
                            "  LEFT OUTER JOIN public.order_item_etiqueta ON (public.pedido_item.id_pedido_item = public.order_item_etiqueta.id_pedido_item) " +
                            "  INNER JOIN public.produto_k ON produto_k.id_produto_k = order_item_etiqueta.id_produto_k " +
                            "  INNER JOIN public.cliente ON (public.pedido_item.id_cliente = public.cliente.id_cliente)" +
                            "WHERE " +
                            "  pei_data_entrada > '" + dataInicio.ToString("yyyy-MM-dd") + "' AND " +
                            "  (public.order_item_etiqueta.oie_item_original_pedido = 1 OR public.order_item_etiqueta.oie_item_original_pedido IS NULL) " +
                            " AND produto_k.id_produto_k = " + idProdutoK.Value + " " +
                            " GROUP BY " +
                            "  public.produto_k.id_produto_k,   " +
                            "  public.produto_k.prk_codigo, " +
                            "  public.order_item_etiqueta.oie_dimensao ";
                    }
                    else
                    {
                        command.CommandText =
                            "SELECT  " +
                            "  public.produto.id_produto,   " +
                            "  public.produto.pro_codigo,   " +
                            "  public.produto.pro_descricao,   " +
                            "  SUM(public.pedido_item.pei_quantidade) as qtdTotal, " +
                            "  SUM(public.pedido_item.pei_preco_total) as precoTotal, " +
                            "  MAX(pei_data_entrada) as dataUltimoPedido, " +
                            "  public.order_item_etiqueta.oie_dimensao " +
                            "FROM   " +
                            "  public.pedido_item   " +
                            "  INNER JOIN public.produto ON (public.pedido_item.id_produto = public.produto.id_produto)  " +
                            "  LEFT OUTER JOIN public.order_item_etiqueta ON (public.pedido_item.id_pedido_item = public.order_item_etiqueta.id_pedido_item) " +
                            "  INNER JOIN public.cliente ON (public.pedido_item.id_cliente = public.cliente.id_cliente) " +
                            "WHERE " +
                            "  pei_data_entrada > '" + dataInicio.ToString("yyyy-MM-dd") + "' AND " +
                            "  (public.order_item_etiqueta.oie_item_original_pedido = 1 OR public.order_item_etiqueta.oie_item_original_pedido IS NULL)  ";

                        if (idProduto.HasValue)
                        {
                            string DimensaoClause = "";
                            if (dimensao == "" || dimensao == "0" || string.IsNullOrWhiteSpace(dimensao))
                            {
                                DimensaoClause = " (oie_dimensao IS NULL OR oie_dimensao LIKE '' OR oie_dimensao LIKE '0' )";
                            }
                            else
                            {
                                DimensaoClause = " oie_dimensao LIKE '" + dimensao + "' ";
                            }

                            command.CommandText += " AND produto.id_produto = " + idProduto.Value + " AND " + DimensaoClause + " ";
                        }

                        if (idCliente.HasValue)
                        {
                            command.CommandText += " AND public.cliente.id_cliente = " + idCliente.Value + " ";
                        }

                        command.CommandText +=
                            "GROUP BY " +
                            "  public.produto.id_produto,   " +
                            "  public.produto.pro_codigo, " +
                            "  public.produto.pro_descricao, " +
                            "  public.order_item_etiqueta.oie_dimensao ";
                    }
                    read = command.ExecuteReader();

                    while (read.Read())
                    {
                        keyTemp =
                        new itemRelatorioPedidoItemConsumoMedioKeyClass(
                               read["id_produto"].ToString(),
                               read["oie_dimensao"] + "");


                        if (!Itens.ContainsKey(keyTemp))
                        {
                            Itens.Add(
                               keyTemp,
                              new itemRelatorioPedidoItemConsumoMedioClass(
                                  read["id_produto"].ToString(),
                                  read["pro_codigo"].ToString(),
                                  read["pro_descricao"].ToString(),
                                  read["oie_dimensao"] + "",
                                  Convert.ToDateTime(read["dataUltimoPedido"]),
                                  0,
                                  0
                                  ));
                        }

                        Itens[keyTemp].setTrimestre(
                            Convert.ToDouble(read["qtdTotal"]),
                            Convert.ToDouble(read["precoTotal"])
                         );
                    }
                    read.Close();

                    #endregion

                    #region Semestral
                    dataInicio = Configurations.DataIndependenteClass.GetData().AddMonths(-6);

                    if (idProdutoK.HasValue)
                    {
                        command.CommandText =
                            "SELECT  " +
                            "  public.produto_k.id_produto_k as id_produto,   " +
                            "  public.produto_k.prk_codigo as pro_codigo,   " +
                            "  '' as pro_descricao,   " +
                            "  SUM(public.pedido_item.pei_quantidade) as qtdTotal, " +
                            "  SUM(public.pedido_item.pei_preco_total) as precoTotal, " +
                            "  MAX(pei_data_entrada) as dataUltimoPedido, " +
                            "  public.order_item_etiqueta.oie_dimensao " +
                            "FROM   " +
                            "  public.pedido_item   " +
                            "  LEFT OUTER JOIN public.order_item_etiqueta ON (public.pedido_item.id_pedido_item = public.order_item_etiqueta.id_pedido_item) " +
                            "  INNER JOIN public.produto_k ON produto_k.id_produto_k = order_item_etiqueta.id_produto_k " +
                            "  INNER JOIN public.cliente ON (public.pedido_item.id_cliente = public.cliente.id_cliente) " +
                            "WHERE " +
                            "  pei_data_entrada > '" + dataInicio.ToString("yyyy-MM-dd") + "' AND " +
                            "  (public.order_item_etiqueta.oie_item_original_pedido = 1 OR public.order_item_etiqueta.oie_item_original_pedido IS NULL) " +
                            " AND produto_k.id_produto_k = " + idProdutoK.Value + " " +
                            " GROUP BY " +
                            "  public.produto_k.id_produto_k,   " +
                            "  public.produto_k.prk_codigo, " +
                            "  public.order_item_etiqueta.oie_dimensao ";
                    }
                    else
                    {
                        command.CommandText =
                            "SELECT  " +
                            "  public.produto.id_produto,   " +
                            "  public.produto.pro_codigo,   " +
                            "  public.produto.pro_descricao,   " +
                            "  SUM(public.pedido_item.pei_quantidade) as qtdTotal, " +
                            "  SUM(public.pedido_item.pei_preco_total) as precoTotal, " +
                            "  MAX(pei_data_entrada) as dataUltimoPedido, " +
                            "  public.order_item_etiqueta.oie_dimensao " +
                            "FROM   " +
                            "  public.pedido_item   " +
                            "  INNER JOIN public.produto ON (public.pedido_item.id_produto = public.produto.id_produto)  " +
                            "  LEFT OUTER JOIN public.order_item_etiqueta ON (public.pedido_item.id_pedido_item = public.order_item_etiqueta.id_pedido_item) " +
                            "  INNER JOIN public.cliente ON (public.pedido_item.id_cliente = public.cliente.id_cliente)  " +
                            "WHERE " +
                            "  pei_data_entrada > '" + dataInicio.ToString("yyyy-MM-dd") + "' AND   " +
                            "  (public.order_item_etiqueta.oie_item_original_pedido = 1 OR public.order_item_etiqueta.oie_item_original_pedido IS NULL)  ";

                        if (idProduto.HasValue)
                        {
                            string DimensaoClause = "";
                            if (dimensao == "" || dimensao == "0" || string.IsNullOrWhiteSpace(dimensao))
                            {
                                DimensaoClause = " (oie_dimensao IS NULL OR oie_dimensao LIKE '' OR oie_dimensao LIKE '0' )";
                            }
                            else
                            {
                                DimensaoClause = " oie_dimensao LIKE '" + dimensao + "' ";
                            }

                            command.CommandText += " AND produto.id_produto = " + idProduto.Value + " AND " + DimensaoClause + " ";
                        }

                        if (idCliente.HasValue)
                        {
                            command.CommandText += " AND public.cliente.id_cliente = " + idCliente.Value + " ";
                        }

                        command.CommandText +=
                            "GROUP BY " +
                            "  public.produto.id_produto,   " +
                            "  public.produto.pro_codigo, " +
                            "  public.produto.pro_descricao , " +
                            "  public.order_item_etiqueta.oie_dimensao ";
                    }
                    read = command.ExecuteReader();

                    while (read.Read())
                    {
                        keyTemp =
                        new itemRelatorioPedidoItemConsumoMedioKeyClass(
                               read["id_produto"].ToString(),
                               read["oie_dimensao"] + "");

                        if (!Itens.ContainsKey(keyTemp))
                        {
                            Itens.Add(
                              keyTemp,
                              new itemRelatorioPedidoItemConsumoMedioClass(
                                  read["id_produto"].ToString(),
                                  read["pro_codigo"].ToString(),
                                  read["pro_descricao"].ToString(),
                                  read["oie_dimensao"] + "",
                                  Convert.ToDateTime(read["dataUltimoPedido"]),
                                  0,
                                  0
                                  ));
                        }

                        Itens[keyTemp].setSemestre(
                            Convert.ToDouble(read["qtdTotal"]),
                            Convert.ToDouble(read["precoTotal"])
                         );
                    }
                    read.Close();

                    #endregion

                    #region Anual
                    dataInicio = Configurations.DataIndependenteClass.GetData().AddMonths(-12);

                    if (idProdutoK.HasValue)
                    {
                        command.CommandText =
                            "SELECT  " +
                            "  public.produto_k.id_produto_k as id_produto,   " +
                            "  public.produto_k.prk_codigo as pro_codigo,   " +
                            "  '' as pro_descricao,   " +
                            "  SUM(public.pedido_item.pei_quantidade) as qtdTotal, " +
                            "  SUM(public.pedido_item.pei_preco_total) as precoTotal, " +
                            "  MAX(pei_data_entrada) as dataUltimoPedido, " +
                            "  public.order_item_etiqueta.oie_dimensao " +
                            "FROM   " +
                            "  public.pedido_item   " +
                            "  LEFT OUTER JOIN public.order_item_etiqueta ON (public.pedido_item.id_pedido_item = public.order_item_etiqueta.id_pedido_item) " +
                            "  INNER JOIN public.produto_k ON produto_k.id_produto_k = order_item_etiqueta.id_produto_k " +
                            "  INNER JOIN public.cliente ON (public.pedido_item.id_cliente = public.cliente.id_cliente) " +
                            "WHERE " +
                            "  pei_data_entrada > '" + dataInicio.ToString("yyyy-MM-dd") + "' AND " +
                            "  (public.order_item_etiqueta.oie_item_original_pedido = 1 OR public.order_item_etiqueta.oie_item_original_pedido IS NULL) " +
                            " AND produto_k.id_produto_k = " + idProdutoK.Value + " " +
                            " GROUP BY " +
                            "  public.produto_k.id_produto_k,   " +
                            "  public.produto_k.prk_codigo, " +
                            "  public.order_item_etiqueta.oie_dimensao ";
                    }
                    else
                    {
                        command.CommandText =
                            "SELECT  " +
                            "  public.produto.id_produto,   " +
                            "  public.produto.pro_codigo,   " +
                            "  public.produto.pro_descricao,   " +
                            "  SUM(public.pedido_item.pei_quantidade) as qtdTotal, " +
                            "  SUM(public.pedido_item.pei_preco_total) as precoTotal, " +
                            "  MAX(pei_data_entrada) as dataUltimoPedido, " +
                            "  public.order_item_etiqueta.oie_dimensao " +
                            "FROM   " +
                            "  public.pedido_item   " +
                            "  INNER JOIN public.produto ON (public.pedido_item.id_produto = public.produto.id_produto)  " +
                            "  LEFT OUTER JOIN public.order_item_etiqueta ON (public.pedido_item.id_pedido_item = public.order_item_etiqueta.id_pedido_item) " +
                            "  INNER JOIN public.cliente ON (public.pedido_item.id_cliente = public.cliente.id_cliente) " +
                            "WHERE " +
                            "  pei_data_entrada > '" + dataInicio.ToString("yyyy-MM-dd") + "'  AND  " +
                            "  (public.order_item_etiqueta.oie_item_original_pedido = 1 OR public.order_item_etiqueta.oie_item_original_pedido IS NULL)  ";

                        if (idProduto.HasValue)
                        {
                            string DimensaoClause = "";
                            if (dimensao == "" || dimensao == "0" || string.IsNullOrWhiteSpace(dimensao))
                            {
                                DimensaoClause = " (oie_dimensao IS NULL OR oie_dimensao LIKE '' OR oie_dimensao LIKE '0' )";
                            }
                            else
                            {
                                DimensaoClause = " oie_dimensao LIKE '" + dimensao + "' ";
                            }

                            command.CommandText += " AND produto.id_produto = " + idProduto.Value + " AND " + DimensaoClause + " ";
                        }

                        if (idCliente.HasValue)
                        {
                            command.CommandText += " AND public.cliente.id_cliente = " + idCliente.Value + " ";
                        }

                        command.CommandText +=
                            "GROUP BY " +
                            "  public.produto.id_produto,   " +
                            "  public.produto.pro_codigo, " +
                            "  public.produto.pro_descricao, " +
                            "  public.order_item_etiqueta.oie_dimensao ";
                    }
                    read = command.ExecuteReader();

                    while (read.Read())
                    {
                        keyTemp =
                       new itemRelatorioPedidoItemConsumoMedioKeyClass(
                              read["id_produto"].ToString(),
                              read["oie_dimensao"] + "");


                        if (!Itens.ContainsKey(keyTemp))
                        {
                            Itens.Add(
                              keyTemp,
                              new itemRelatorioPedidoItemConsumoMedioClass(
                                  read["id_produto"].ToString(),
                                  read["pro_codigo"].ToString(),
                                  read["pro_descricao"].ToString(),
                                  read["oie_dimensao"] + "",
                                  Convert.ToDateTime(read["dataUltimoPedido"]),
                                  0,
                                  0
                                  ));
                        }

                        Itens[keyTemp].setAno(
                            Convert.ToDouble(read["qtdTotal"]),
                            Convert.ToDouble(read["precoTotal"])
                         );
                    }
                    read.Close();

                    #endregion
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao calcular o relatório.\r\n" + e.Message, e);
            }
        }


        internal List<itemRelatorioPedidoItemConsumoMedioClass> gerarRelatorio(TipoRelatorioPedidoItemConsumoMedio Tipo, bool forcarCalculo, long? idProduto, long? idCliente, string dimensao)
        {

            try
            {
                if (this.Itens == null || forcarCalculo)
                {
                    this.Calcular(idProduto, idCliente,null,dimensao, false);
                }

                List<itemRelatorioPedidoItemConsumoMedioClass> toRet;
                toRet = new List<itemRelatorioPedidoItemConsumoMedioClass>(Itens.Values);
                switch (Tipo)
                {
                    case TipoRelatorioPedidoItemConsumoMedio.ordernarMensal:
                        toRet.Sort(comparaMensal);
                        break;
                    case TipoRelatorioPedidoItemConsumoMedio.ordernarTrimestral:
                        toRet.Sort(comparaTrimestral);
                        break;
                    case TipoRelatorioPedidoItemConsumoMedio.ordernarSemestral:
                        toRet.Sort(comparaSemestral);
                        break;
                    case TipoRelatorioPedidoItemConsumoMedio.ordernarAnual:
                        toRet.Sort(comparaAnual);
                        break;
                }


                
                return toRet;

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar o relatório.\r\n" + e.Message, e);
            }
        }


        private static int comparaMensal(itemRelatorioPedidoItemConsumoMedioClass y, itemRelatorioPedidoItemConsumoMedioClass x)
        {

            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (y == null)
                // ...and y is null, x is greater.
                {
                    return 1;
                }
                else
                {
                    return x.valorTotalMensal.CompareTo(y.valorTotalMensal);

                }
            }

        }

        private static int comparaTrimestral(itemRelatorioPedidoItemConsumoMedioClass y, itemRelatorioPedidoItemConsumoMedioClass x)
        {

            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (y == null)
                // ...and y is null, x is greater.
                {
                    return 1;
                }
                else
                {
                    return x.valorTotalTrimestral.CompareTo(y.valorTotalTrimestral);

                }
            }

        }

        private static int comparaSemestral(itemRelatorioPedidoItemConsumoMedioClass y, itemRelatorioPedidoItemConsumoMedioClass x)
        {

            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (y == null)
                // ...and y is null, x is greater.
                {
                    return 1;
                }
                else
                {
                    return x.valorTotalSemestral.CompareTo(y.valorTotalSemestral);

                }
            }

        }

        private static int comparaAnual(itemRelatorioPedidoItemConsumoMedioClass y, itemRelatorioPedidoItemConsumoMedioClass x)
        {

            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (y == null)
                // ...and y is null, x is greater.
                {
                    return 1;
                }
                else
                {
                    return x.valorTotalAnual.CompareTo(y.valorTotalAnual);

                }
            }

        }

    }

    public class itemRelatorioPedidoItemConsumoMedioKeyClass : IComparable<itemRelatorioPedidoItemConsumoMedioKeyClass>, IEquatable<itemRelatorioPedidoItemConsumoMedioKeyClass>
    {
        public string idProduto { get; private set; }
        public string dimensaoProduto { get; private set; }

        public itemRelatorioPedidoItemConsumoMedioKeyClass(string idProduto, string dimensaoProduto)
        {
            this.idProduto = idProduto;
            this.dimensaoProduto = dimensaoProduto;
        }

        #region Implementation of IComparable<itemRelatorioPedidoItemConsumoMedioKeyClass>

        public int CompareTo(itemRelatorioPedidoItemConsumoMedioKeyClass other)
        {
            if (this.idProduto.Equals(other.idProduto))
            {
                return this.dimensaoProduto.CompareTo(other.dimensaoProduto);
            }
            else
            {
                return this.idProduto.CompareTo(other.idProduto);
            }
        }

        #endregion

        #region Implementation of IEquatable<itemRelatorioPedidoItemConsumoMedioKeyClass>

        public bool Equals(itemRelatorioPedidoItemConsumoMedioKeyClass other)
        {
            return this.idProduto.Equals(other.idProduto) && this.dimensaoProduto.Equals(other.dimensaoProduto);
        }

        #endregion

        public override int GetHashCode()
        {
            return this.idProduto.GetHashCode()*this.dimensaoProduto.GetHashCode();
        }
    }

    public class itemRelatorioPedidoItemConsumoMedioClass
    {
        public string idProduto { get; private set; }
        public string codProduto { get; private set; }
        public string descricaoProduto { get; private set; }
        public string dimensaoProduto { get; private set; }

        public DateTime dataUltimoPedido { get; private set; }

        public double qtdTotalMensal { get; private set; }
        public double qtdMediaMensal
        {
            get
            {
                return this.qtdTotalMensal;
            }
        }
        public double valorMedioMensal
        {
            get
            {
                return this.valorTotalMensal;
            }
        }
        public double valorTotalMensal { get; private set; }

        public double qtdTotalTrimestral { get; private set; }
        public double qtdMediaTrimestral
        {
            get
            {
                return this.qtdTotalTrimestral/3;
            }
        }
        public double valorMedioTrimestral
        {
            get
            {
                return this.valorTotalTrimestral / 3;
            }
        }
        public double valorTotalTrimestral { get; private set; }

        public double qtdTotalSemestral { get; private set; }
        public double qtdMediaSemestral
        {
            get
            {
                return this.qtdTotalSemestral/6;
            }
        }
        public double valorMedioSemestral
        {
            get
            {
                return this.valorTotalSemestral / 6;
            }
        }
        public double valorTotalSemestral { get; private set; }

        public double qtdTotalAnual { get; private set; }
        public double qtdMediaAnual
        {
            get
            {
                return this.qtdTotalAnual/12;
            }
        }
        public double valorMedioAnual
        {
            get
            {
                return this.valorTotalAnual / 12;
            }
        }
        public double valorTotalAnual { get; private set; }

        


        //public List<pedidoRelatorioPedidoItemConsumoMedioClass> Pedidos { get; private set; }

        public itemRelatorioPedidoItemConsumoMedioClass(
            string idProduto,
            string codProduto,
            string descricaoProduto,
            string dimensaoProduto,
            DateTime dataUltimoPedido,
            double qtdTotalMensal,
            double valorTotalMensal
            )
        {
            this.idProduto = idProduto;
            this.codProduto = codProduto;
            this.descricaoProduto = descricaoProduto;
            this.dimensaoProduto = dimensaoProduto;
            this.dataUltimoPedido = dataUltimoPedido;
            this.qtdTotalMensal = qtdTotalMensal;
            this.valorTotalMensal = valorTotalMensal;

        }

        internal void setTrimestre(double qtdTotalTrimestral, double valorTotalTrimestral)
        {
            this.qtdTotalTrimestral = qtdTotalTrimestral;
            this.valorTotalTrimestral = valorTotalTrimestral;
        }

        internal void setSemestre(double qtdTotalSemestral, double valorTotalSemestral)
        {
            this.qtdTotalSemestral = qtdTotalSemestral;
            this.valorTotalSemestral = valorTotalSemestral;
        }

        internal void setAno(double qtdTotalAnual, double valorTotalAnual)
        {
            this.qtdTotalAnual = qtdTotalAnual;
            this.valorTotalAnual = valorTotalAnual;
        }

        /*internal void addPedido (string Pedido, DateTime dataEntrada, DateTime dataEntrega, double Quantidade, double Saldo, string Situacao)
        {
            this.Pedidos.Add(new pedidoRelatorioPedidoItemConsumoMedioClass(Pedido, dataEntrada, dataEntrega, Quantidade, Saldo, Situacao,this));
        }*/



    }

    internal class pedidoRelatorioPedidoItemConsumoMedioClass
    {
        public string Pedido { get; private set; }
        public DateTime dataEntrada { get; private set; }
        public DateTime dataEntrega { get; private set; }
        public double Quantidade { get; private set; }
        public double Saldo { get; private set; }
        public string Situacao { get; private set; }

        readonly itemRelatorioPedidoItemConsumoMedioClass Pai;


        public string codProduto
        {
            get
            {
                return this.Pai.codProduto;
            }
        }

        public string descricaoProduto
        {
            get
            {
                return this.Pai.descricaoProduto;
            }
        }

        public double mediaTrimestral
        {
            get
            {
                return this.Pai.qtdTotalTrimestral;
            }
        }
        public double mediaSemestral
        {
            get
            {
                return this.Pai.qtdTotalSemestral;
            }
        }
        public double mediaAnual
        {
            get
            {
                return this.Pai.qtdTotalAnual;
            }
        }


        internal pedidoRelatorioPedidoItemConsumoMedioClass
            (string Pedido, DateTime dataEntrada, DateTime dataEntrega, double Quantidade, double Saldo, string Situacao, itemRelatorioPedidoItemConsumoMedioClass Pai)
        {
            this.Pedido = Pedido;
            this.dataEntrada = dataEntrada;
            this.dataEntrega = dataEntrega;
            this.Quantidade = Quantidade;
            this.Saldo = Saldo;
            this.Situacao = Situacao;
            this.Pai = Pai;
        }




    }

}
