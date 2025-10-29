using System;
using System.Collections.Generic;
using System.Windows.Forms;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;
using dbProvider;
using System.Linq;


namespace BibliotecaPedidos
{
    public partial class MateriaisPedidoReportForm : IWTBaseForm
    {
        private readonly List<PedidoSelecaoClass> _selecionados;


        public MateriaisPedidoReportForm(List<PedidoSelecaoClass> selecionados)
        {
            InitializeComponent();
            _selecionados = selecionados;
        }

        private void gerarRelatorio()
        {
            try
            {
                IWTPostgreNpgsqlCommand command = DbConnection.Connection.CreateCommand();
                string whereClause = _selecionados.Aggregate("", (current, pedido) => current + (" OR (order_item_etiqueta.oie_order_number LIKE '" + pedido.Oc + "' AND order_item_etiqueta.oie_order_pos = " + pedido.Pos + " AND order_item_etiqueta.id_cliente = " + pedido.IdCliente + ") "));
                if (whereClause.Length <= 0)
                {
                    return;
                }

                whereClause = whereClause.Substring(3);


                command.CommandText =
                    "SELECT  " +
                    "  public.order_item_etiqueta.oie_order_number||'/'|| " +
                    "  public.order_item_etiqueta.oie_order_pos as pedido, " +
                    "  public.order_item_etiqueta.id_cliente, " +
                    "  SUM(public.pedido_item_configurado_material.pcm_quantidade_total) AS qtd, " +
                    "  public.cliente.cli_nome_resumido, " +
                    "  public.agrupador_material.agm_identificacao || ' ' || public.familia_material.fam_codigo||' ' || public.material.mat_codigo AS mat, " +
                    "  public.material.mat_medida||' x ' || public.material.mat_medida_largura||' x ' || public.material.mat_medida_comprimento AS medida, " +
                    "  public.material.mat_descricao, " +
                    "  public.material.mat_unidades_por_un_compra, " +
                    "  unidade_compra.unm_abreviada AS un_compra, " +
                    "  unidade_uso.unm_abreviada AS un_uso, " +
                    "  public.material.mat_descricao_adicional " +
                    "FROM " +
                    "  public.order_item_etiqueta " +
                    "  INNER JOIN public.pedido_item_configurado_material ON (public.order_item_etiqueta.id_order_item_etiqueta = public.pedido_item_configurado_material.id_order_item_etiqueta) " +
                    "  INNER JOIN public.material ON (public.pedido_item_configurado_material.id_material = public.material.id_material) " +
                    "  INNER JOIN public.cliente ON (public.order_item_etiqueta.id_cliente = public.cliente.id_cliente) " +
                    "  INNER JOIN public.familia_material ON (public.material.id_familia_material = public.familia_material.id_familia_material) " +
                    "  INNER JOIN public.agrupador_material ON (public.familia_material.id_agrupador_material = public.agrupador_material.id_agrupador_material) " +
                    "  LEFT JOIN public.unidade_medida unidade_compra ON (public.material.id_unidade_medida_compra = unidade_compra.id_unidade_medida) " +
                    "  LEFT JOIN public.unidade_medida unidade_uso ON (public.material.id_unidade_medida = unidade_uso.id_unidade_medida) " +
                    "WHERE "+
                    whereClause+" "+
                    "GROUP BY " +
                    "  public.order_item_etiqueta.oie_order_number, " +
                    "  public.order_item_etiqueta.oie_order_pos, " +
                    "  public.order_item_etiqueta.id_cliente, " +
                    "  public.cliente.cli_nome_resumido, " +
                    "  mat, " +
                    "  medida, " +
                    "  public.material.mat_descricao, " +
                    "  public.material.mat_unidades_por_un_compra, " +
                    "  unidade_compra.unm_abreviada, " +
                    "  unidade_uso.unm_abreviada, " +
                    "  public.material.mat_descricao_adicional " +
                    "ORDER BY " +
                    "  public.order_item_etiqueta.oie_order_number, " +
                    "  public.order_item_etiqueta.oie_order_pos, " +
                    "  public.agrupador_material.agm_identificacao || ' ' || public.familia_material.fam_codigo||' ' || public.material.mat_codigo ";

             
                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                List<MateriaisPedidoReportClass> materiais = new List<MateriaisPedidoReportClass>();
                while (read.Read())
                {
                    materiais.Add(
                        new MateriaisPedidoReportClass(
                            read["pedido"].ToString(),
                            read["cli_nome_resumido"].ToString(),
                            read["mat"].ToString(),
                            read["mat_descricao"].ToString(),
                            read["mat_descricao_adicional"].ToString(),
                            read["medida"].ToString(),
                            Convert.ToDouble(read["qtd"]),
                            read["un_uso"].ToString(),
                            Convert.ToDouble(read["qtd"])/Convert.ToDouble(read["mat_unidades_por_un_compra"]),
                            (read["un_compra"] !=DBNull.Value?read["un_compra"]:read["un_uso"]).ToString()
                            
                            )
                        );
                }
                read.Close();

                MateriaisPedidoReport rep = new MateriaisPedidoReport();
                rep.SetDataSource(materiais);
                this.crystalReportViewer1.ReportSource = rep;

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar o relatório.\r\n" + e.Message, e);
            }
        }

        private void MateriaisPedidoReportForm_Shown(object sender, EventArgs e)
        {
            try
            {
                this.gerarRelatorio();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
