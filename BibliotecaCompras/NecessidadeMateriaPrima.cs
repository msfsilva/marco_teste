#region Referencias

using System;
using System.Collections.Generic;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;

#endregion

namespace BibliotecaCompras
{
    public class NecessidadeMateriaPrima
    {
        DateTime Fim;
        readonly List<int> idsAgrupadores;
        readonly string tipoCalculoSemana;
        readonly string diaCalculoSemana;

        readonly IWTPostgreNpgsqlConnection conn;

        public Dictionary<int, NecessidadeMateriaPrimaMaterial> ItensRelatorio { get; private set; }

       
        public NecessidadeMateriaPrima(DateTime Fim,List<int> idsAgrupadores, string tipoCalculoSemana, string diaCalculoSemana, IWTPostgreNpgsqlConnection conn)
        {
            this.Fim = Fim;
            this.conn = conn;
            this.diaCalculoSemana = diaCalculoSemana;
            this.tipoCalculoSemana = tipoCalculoSemana;

            this.idsAgrupadores = idsAgrupadores;

            this.ItensRelatorio = new Dictionary<int, NecessidadeMateriaPrimaMaterial>();
        }

        public void Start()
        {
            try
            {
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText =
                "SELECT  " +
                "  public.material.id_material, " +
                "  public.material.mat_descricao, " +
                "  public.material.mat_medida, " +
                "  public.material.mat_medida_largura, " +
                "  public.material.mat_medida_comprimento, " +
                "  public.material.mat_codigo, " +
                "  public.familia_material.fam_codigo, " +
                "  public.material.mat_descricao_adicional, " +
                "  public.pedido_item.pei_data_entrega, " +
                "  public.order_item_etiqueta.id_order_item_etiqueta, " +
                "  public.produto_material.prm_quantidade * public.pedido_item.pei_quantidade as quantidade, " +
                "  public.unidade_medida.unm_abreviada, " +
                "  public.agrupador_material.agm_identificacao "+
                "FROM " +
                "  public.order_item_etiqueta " +
                "  INNER JOIN public.produto ON (public.order_item_etiqueta.id_produto = public.produto.id_produto) " +
                "  INNER JOIN public.produto_material ON (public.produto.id_produto = public.produto_material.id_produto AND produto.pro_versao_estrutura_atual = prm_versao_estrutura) " +
                "  INNER JOIN public.material ON (public.produto_material.id_material = public.material.id_material) " +
                //"  INNER JOIN public.pedido_item ON (public.order_item_etiqueta.id_pedido_item = public.pedido_item.id_pedido_item) " +
                "  INNER JOIN public.pedido_item ON  "+
                "     ( " +
                "	     public.order_item_etiqueta.oie_order_number = public.pedido_item.pei_numero AND  "+
                "         public.order_item_etiqueta.oie_order_pos = public.pedido_item.pei_posicao AND  "+
                "         public.order_item_etiqueta.id_cliente = public.pedido_item.id_cliente AND  "+
                "	     public.pedido_item.pei_sub_linha = 0  "+
                "     ) "+
                "  INNER JOIN public.familia_material ON (public.material.id_familia_material = public.familia_material.id_familia_material) " +
                "  INNER JOIN public.unidade_medida ON (public.material.id_unidade_medida = public.unidade_medida.id_unidade_medida) " +
                "  LEFT OUTER JOIN public.agrupador_material ON (public.familia_material.id_agrupador_material = public.agrupador_material.id_agrupador_material) "+
                "WHERE " +
                "  public.order_item_etiqueta.oie_compra_mp_gerado = 0 AND  " +
                "  public.pedido_item.pei_data_entrega < '" + this.Fim.Date.AddDays(1).ToString("yyyy-MM-dd") + "' AND  " +
                "  public.material.mat_politica_estoque = 0 AND  " +
                "  (public.pedido_item.pei_status = 0 OR " +
                "  public.pedido_item.pei_status = 3) ";

                if (idsAgrupadores != null && idsAgrupadores.Count > 0)
                {
                    string sqlAgrupadores = "";
                    foreach (int idAgrup in this.idsAgrupadores)
                    {
                        sqlAgrupadores += " OR agrupador_material.id_agrupador_material = " + idAgrup + " ";
                    }
                    command.CommandText += " AND (" + sqlAgrupadores.Substring(3) + ")";

                }

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();


                while (read.Read())
                {
                    int idMaterial = Convert.ToInt32(read["id_material"]);
                    if (!this.ItensRelatorio.ContainsKey(idMaterial))
                    {
                        this.ItensRelatorio.Add(idMaterial, new NecessidadeMateriaPrimaMaterial(idMaterial,
                            read["mat_codigo"].ToString(), read["mat_descricao"].ToString(),
                            read["mat_descricao_adicional"].ToString(), read["fam_codigo"].ToString(), read["unm_abreviada"].ToString(),
                            Convert.ToDouble(read["mat_medida"]), Convert.ToDouble(read["mat_medida_largura"]),
                            Convert.ToDouble(read["mat_medida_comprimento"]),
                            read["agm_identificacao"].ToString(),
                            this.tipoCalculoSemana, this.diaCalculoSemana, this.conn));

                    }

                    this.ItensRelatorio[idMaterial].addPedido(
                        Convert.ToDouble(read["quantidade"]),
                        Convert.ToDateTime(read["pei_data_entrega"]),
                        Convert.ToInt32(read["id_order_item_etiqueta"])
                        );
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao montar o relatório de compra de materiais auxiliares.\r\n" + e.Message, e);
            }

        }


        public void saveReport()
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                command = this.conn.CreateCommand();
                command.Transaction = this.conn.BeginTransaction();

                foreach (NecessidadeMateriaPrimaMaterial mat in this.ItensRelatorio.Values)
                {
                    mat.Save(ref command);
                }

                command.Transaction.Commit();

            }
            catch (Exception e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                throw new Exception("Erro ao salvar os pedidos como gerados.\r\n" + e.Message, e);
            }
        }

    }

    public class NecessidadeMateriaPrimaMaterial
    {
        public Int32 idMaterial { get; private set; }
        public String codigoMaterial { get; private set; }
        public String descMaterial { get; private set; }
        public String descAdicionalMaterial { get; private set; }
        public String familiaMaterial { get; private set; }
        public String unidadeMedida { get; private set; }
        public String agrupadorMaterial { get; private set; }
        public Double medida1 { get; private set; }
        public Double medida2 { get; private set; }
        public Double medida3 { get; private set; }
        public Double qtdTotal { get; private set; }
        public DateTime menorDataUtilizacao { get; private set; }
        public List<Int32> idsPedidoConfiguradoAtualizar { get; private set; }

        public String menorSemanaUtilizacao
        {
            get
            {
                int weekNum = IWTFunctions.IWTFunctions.getNumeroSemana(this.menorDataUtilizacao, this.tipoCalculoSemana, this.diaCalculoSemana);
                return this.menorDataUtilizacao.ToString("yy") + weekNum.ToString().PadLeft(2, '0');

            }
        }

        IWTPostgreNpgsqlConnection conn;
        readonly string tipoCalculoSemana;
        readonly string diaCalculoSemana;

        public NecessidadeMateriaPrimaMaterial(Int32 idMaterial, String codigoMaterial, String descMaterial, String descAdicionalMaterial,
            String familiaMaterial, String unidadeMedida, Double medida1, Double medida2, Double medida3,
            string agrupadorMaterial,
            string tipoCalculoSemana, string diaCalculoSemana,
            IWTPostgreNpgsqlConnection conn)
        {
            
            this.idMaterial = idMaterial;
            this.descMaterial = descMaterial;
            this.descAdicionalMaterial = descAdicionalMaterial;
            this.familiaMaterial = familiaMaterial;
            this.medida1 = medida1;
            this.medida2 = medida2;
            this.medida3 = medida3;
            this.codigoMaterial = codigoMaterial;
            this.unidadeMedida = unidadeMedida;

            this.agrupadorMaterial = agrupadorMaterial;


            this.conn = conn;
            this.diaCalculoSemana = diaCalculoSemana;
            this.tipoCalculoSemana = tipoCalculoSemana;
            this.idsPedidoConfiguradoAtualizar = new List<int>();

        }

        public void addPedido(Double Quantidade, DateTime dataUtilizacao, Int32 idPedidoConfigurado)
        {
            this.qtdTotal += Quantidade;
            if (this.idsPedidoConfiguradoAtualizar.Count == 0 || dataUtilizacao.CompareTo(this.menorDataUtilizacao) < 0)
            {
                this.menorDataUtilizacao = dataUtilizacao;
            }
            this.idsPedidoConfiguradoAtualizar.Add(idPedidoConfigurado);
        }


        internal void Save(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                command.CommandText =
                    "UPDATE order_item_etiqueta SET oie_compra_mp_gerado = 1, oie_compra_mp_data_geracao = :oie_compra_mp_data_geracao WHERE id_order_item_etiqueta = :id_order_item_etiqueta";

                foreach (int idPedidoConfigurado in this.idsPedidoConfiguradoAtualizar)
                {
                    command.Parameters.Clear();
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_compra_mp_data_geracao", NpgsqlDbType.Timestamp));
                    command.Parameters[command.Parameters.Count - 1].Value = Configurations.DataIndependenteClass.GetData();
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_order_item_etiqueta", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = idPedidoConfigurado;
                    command.ExecuteNonQuery();
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar o item do relatório.\r\n" + e.Message, e);
            }
        }
    }
}
