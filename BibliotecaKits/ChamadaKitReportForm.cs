#region Referencias

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Configurations;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using Npgsql;
using ProjectConstants;

#endregion

namespace ModuloKits
{
    public partial class ChamadaKitReportForm : IWTBaseForm
    {
        private readonly string printer;
        private readonly bool mod;
        private readonly IWTPostgreNpgsqlConnection conn;
        private readonly bool kit;
        readonly string tipoCalculoSemana;
        readonly string diaCalculoSemana;
        private readonly byte[] logoEmpresa;

        public ChamadaKitReportForm(string printerName,byte[] logo, bool modelo, IWTPostgreNpgsqlConnection conn, bool kit, string tipoCalculoSemana, string diaCalculoSemana)
        {
            InitializeComponent();            
            this.printer = printerName;
            this.logoEmpresa = logo;
            this.mod = modelo;
            this.conn = conn;
            this.kit = kit;
            this.tipoCalculoSemana = tipoCalculoSemana;
            this.diaCalculoSemana = diaCalculoSemana;
            this.loadComboFabricante();
            this.loadComboCliente();
            this.loadComboProduto();
            

            this.confScreen();
        }

        private void loadComboCliente()
        {
            try
            {
                string sql =

                "SELECT  " +
                "  public.cliente.id_cliente, " +
                "  public.cliente.id_familia_cliente, " +
                "  public.familia_cliente.fac_nome, " +
                "  public.cliente.cli_nome_resumido " +
                "FROM " +
                "  public.familia_cliente " +
                "  JOIN public.cliente ON (public.familia_cliente.id_familia_cliente = public.cliente.id_familia_cliente) " +
                "ORDER BY " +
                "  public.familia_cliente.fac_nome, " +
                "  public.cliente.cli_nome_resumido ";


                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.conn);
                if (adapter != null)
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    BindingSource binding = new BindingSource();
                    binding.DataSource = ds.Tables[0];
                    this.cmbCliente.DataSource = binding;
                    this.cmbCliente.ValueMember = "id_cliente";
                    this.cmbCliente.DisplayMember = "cli_nome_resumido";
                    this.cmbCliente.autoSize = true;
                    this.cmbCliente.Table = ds.Tables[0];
                    this.cmbCliente.ColumnsToDisplay = new string[] { "fac_nome", "cli_nome_resumido" };
                    this.cmbCliente.HeadersToDisplay = new string[] { "Agrupador", "Nome Resumido" };


                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção do Cliente.\r\n" + e.Message);
            }
        }

        private void confScreen()
        {
            if (!kit)
            {
                this.rdbData.Checked = true;
                this.rdbEmbarqueImediato.Enabled = false;
                this.rdbMatAdicional.Enabled = true;
                this.rdbOcPos.Enabled = true;
                this.rdbPps.Enabled = false;
                this.gbxOcPos.Enabled = false;
                this.gbxPps.Enabled = false;
                this.gbxData.Enabled = true;
                this.rdbReprovados.Enabled = true;
                this.rdbReprovados.Visible= true;
                //this.dtpData.MaxDate = Configurations.DataIndependenteClass.GetData().AddMonths(1);

                this.rdbFabricante.Visible = true;
                this.gbxFabricante.Visible = true;

                this.rdbCliente.Enabled = true;
                this.gbxCliente.Visible = true;

                this.rdbProduto.Enabled = true;
                this.gbxProduto.Visible = true;

                this.gbxSaldo.Visible = true;
                this.rdbSaldoTodos.Checked = true;
            }
            else
            {
                this.rdbReprovados.Enabled = false;
                this.rdbReprovados.Visible = false;

                this.rdbFabricante.Visible = false;
                this.gbxFabricante.Visible = false;

                this.rdbCliente.Enabled = true;
                this.gbxCliente.Visible = true;

                this.rdbProduto.Visible = true;
                this.gbxProduto.Visible = true;

                if (mod)
                {
                    this.gbxPps.Enabled = false;
                    this.rdbPps.Enabled = false;
                    this.rdbOcPos.Checked = true;
                    this.gbxOcPos.Enabled = true;
                    this.rdbData.Enabled = false;
                    this.gbxData.Enabled = false;
                    this.rdbMatAdicional.Enabled = false;
                    this.rdbEmbarqueImediato.Enabled = false;
                    this.rdbCliente.Enabled = false;
                }
                else
                {
                    this.rdbData.Checked = true;
                }

                this.gbxSaldo.Visible = false;
                this.rdbSaldoTodos.Checked = true;
            }

            this.dtpData.Value = Configurations.DataIndependenteClass.GetData();

            if (this.kit)
            {
                this.Text = "OP de Kits";
            }
            else
            {
                this.Text = "Programa de Expedição - Itens Não KIT";
            }
        }

        private void loadComboFabricante()
        {
            try
            {
                string sql =
                    "SELECT  " +
                    "  id_local_fabricacao, " +
                    "  lof_identificacao, " +
                    "  lof_descricao " +
                    "FROM  " +
                    "  public.local_fabricacao " +
                    "ORDER BY  public.local_fabricacao.lof_identificacao";


                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.conn);
                if (adapter != null)
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    BindingSource binding = new BindingSource();
                    binding.DataSource = ds.Tables[0];
                    this.cmbFabricante.DataSource = binding;
                    this.cmbFabricante.ValueMember = "id_local_fabricacao";
                    this.cmbFabricante.DisplayMember = "lof_identificacao";
                    this.cmbFabricante.autoSize = true;
                    this.cmbFabricante.Table = ds.Tables[0];
                    this.cmbFabricante.ColumnsToDisplay = new string[] { "lof_identificacao", "lof_descricao" };
                    this.cmbFabricante.HeadersToDisplay = new string[] { "Identificação", "Descrição" };

                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção do fabricante.\r\n" + e.Message);
            }
        }

        private void loadComboProduto()
        {
            try
            {
                   string sql =
                    "SELECT                              " +
                    "  id_produto,                       " +
                    "  pro_codigo,                     " +
                    "  pro_codigo_cliente, " +
                    "  pro_descricao " +
                    "FROM                                " +
                    "  public.produto                    " +
                    "ORDER BY pro_codigo";

                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.conn);
                if (adapter != null)
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    BindingSource binding = new BindingSource();
                    binding.DataSource = ds.Tables[0];
                    this.cmbProduto.DataSource = binding;
                    this.cmbProduto.ValueMember = "id_produto";
                    this.cmbProduto.DisplayMember = "pro_codigo";
                    this.cmbProduto.autoSize = true;
                    this.cmbProduto.Table = ds.Tables[0];
                    this.cmbProduto.ColumnsToDisplay = new string[] { "pro_codigo", "pro_codigo_cliente", "pro_descricao" };
                    this.cmbProduto.HeadersToDisplay = new string[] { "Código", "Código Cliente", "Descrição" };

                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção do produto.\r\n" + e.Message);
            }
        }

        private List<KitClass> buscaOcs(string pps)
        {
         //identifica a data final da semana
            if (pps.Length != 3 && pps.Length != 4)
            {
                throw new Exception("Semana inválida. A semana deve ter 3 ou 4 caracteres");
            }
            try
            {
                int ano = int.Parse(pps.Substring(0, 2))+2000;
                int semana = int.Parse(pps.Substring(2));

                DateTime date = new DateTime(ano, 1, 1);
                int semanaTmp = IWTFunctions.IWTFunctions.getNumeroSemana(date, this.tipoCalculoSemana, this.diaCalculoSemana);
                while (semana != semanaTmp)
                {
                    date = date.AddDays(1);
                    semanaTmp = IWTFunctions.IWTFunctions.getNumeroSemana(date, this.tipoCalculoSemana, this.diaCalculoSemana);
                }

                //Corre para o último dia da semana
                date = date.AddDays(6);
                return this.buscaOcs(date, false, false, false,false,false, null, null, null, null, null, null);

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao identificar o término da semana.\r\n" + e.Message);
            }

        }

        private List<KitClass> buscaOcs(DateTime? data, bool urgenteAntecipacao, bool urgenteUrgente, bool urgenteCritico, bool embImediato, bool somenteReprovados, int? idFabricante, string oc, string pos, int? idCliente, int? idProduto, string projeto)
        {
            IWTPostgreNpgsqlCommand command = conn.CreateCommand();
            List<KitClass> toRet = new List<KitClass>();
            string sql = "";



            sql =
                "SELECT *,                                                                                                                                                                                                                                          " +
                "  CASE WHEN pei_status = 0 THEN                                                                                                                                                                                                                    " +
                "	CASE                                                                                                                                                                                                                                            " +
                "  	WHEN oic_conferencia_pallet IS NULL THEN 'Em Fabricação'                                                                                                                                                                                        " +
                "    ELSE                                                                                                                                                                                                                                           " +
                "    	CASE WHEN id_embarque IS NOT NULL THEN 'Pedido Embarcado'                                                                                                                                                                                   " +
                "        ELSE                                                                                                                                                                                                                                       " +
                "      		CASE WHEN oic_conferencia_pallet = 0 THEN                                                                                                                                                                                               " +
                "            	CASE WHEN oie_situacao_conferencia = 2 THEN 'Pedido Conferido Total'                                                                                                                                                                " +
                "                ELSE 'Pedido Conferido Parcial'                                                                                                                                                                                                    " +
                "                END                                                                                                                                                                                                                                " +
                "            ELSE                                                                                                                                                                                                                                   " +
                "        	 'Pallet Conferido'                                                                                                                                                                                                                     " +
                "            END                                                                                                                                                                                                                                    " +
                "        END                                                                                                                                                                                                                                        " +
                "	END                                                                                                                                                                                                                                             " +
                "ELSE                                                                                                                                                                                                                                               " +
                "	CASE WHEN pei_status = 3 THEN 'Reaberto' ELSE 'Finalizado' END                                                                                                                                                                                 " +
                "END AS situacao,                                                                                                                                                                                                                                   " +
                "CASE WHEN evolution_status = '224' OR (fac_tipo_especial  = 1 AND substring(pei_numero for 2) NOT LIKE '45') THEN 'Urgente' ELSE   " +
                "CASE pei_urgente WHEN 0 THEN 'Normal' WHEN 1 THEN 'Antecipação' WHEN 2 THEN 'Urgente' WHEN 3 THEN 'Crítico' END END AS urgente                                                                                                                         " +
                "                                                                                                                                                                                                                                                   " +
                " FROM (                                                                                                                                                                                                                                            " +
                "                                                                                                                                                                                                                                                   " +
                "   SELECT public.order_item_etiqueta.oie_order_number as pei_numero, " +
                "       public.order_item_etiqueta.oie_order_pos as pei_posicao, "+
                "       public.kit_tipo_kit.ktk_sequencia, "+
                "       public.kit_tipo_kit.id_tipo_kit, "+
                "       public.kit_tipo_kit.pek_tipo_kit, "+
                "       public.order_item_etiqueta.oie_data_entrega as pei_data_entrega, "+
                "       public.order_item_etiqueta.oie_dimensao, "+
                "       public.order_item_etiqueta.oie_var_1_valor, "+
                "       public.order_item_etiqueta.oie_var_2_valor, "+
                "       CASE order_item_etiqueta.oie_status_pedido "+
                "         WHEN 'P' THEN 0 "+
                "         WHEN 'E' THEN 1 "+
                "         WHEN 'C' THEN 2 "+
                "         WHEN 'R' THEN 3 "+
                "       END AS pei_status, "+
                "       public.order_item_etiqueta_conferencia.oic_conferencia_pallet, "+
                "       public.order_item_etiqueta_conferencia.id_embarque, "+
                "       public.order_item_etiqueta.oie_situacao_conferencia, "+
                "       public.order_item_etiqueta_conferencia.oic_pallet, "+
                "       public.order_item_etiqueta.oie_codigo_item, "+
                "       public.order_item_etiqueta.oie_data_impressao_op, "+
                "       public.order_item_etiqueta.oie_ovm, "+
                "       public.cliente.cli_nome_resumido, "+
                "       public.order_item.evolution_status, "+
                "       0 as pei_urgente, "+
                "       NULL as pei_urgente_data_prometida, "+
                "       public.produto.id_local_fabricacao, "+
                "       public.familia_cliente.fac_tipo_especial, "+
                "       public.order_item_etiqueta.oie_codigo_cliente,                                                                                                                                                                                                      " +
                "       public.cliente.id_cliente, " +
                "       public.order_item_etiqueta.oie_data_entrega as pei_data_entrada, " +
                "       public.order_item_etiqueta.id_produto, " +
                "       public.order_item_etiqueta.id_order_item_etiqueta, " +
                "       public.order_item_etiqueta.oie_ovm as pei_projeto_cliente, " +
                "       public.order_item_etiqueta.oie_kit_fantasia " +
                "FROM public.order_item_etiqueta  "+
                "     LEFT OUTER JOIN public.order_item_etiqueta_conferencia ON ( public.order_item_etiqueta.id_order_item_etiqueta = public.order_item_etiqueta_conferencia.id_order_item_etiqueta) AND "+
                "            public.order_item_etiqueta_conferencia.oic_nf_emitida = 0 "+ 
                "     LEFT OUTER JOIN public.pedido_kit ON (public.order_item_etiqueta.oie_order_number = "+
                "      public.pedido_kit.pek_oc) AND (public.order_item_etiqueta.oie_order_pos = "+
                "       public.pedido_kit.pek_pos) "+
                "     LEFT OUTER JOIN public.cliente ON (public.order_item_etiqueta.id_cliente = "+
                "      public.cliente.id_cliente) "+
                "     LEFT OUTER JOIN public.familia_cliente ON ( "+
                "     public.cliente.id_familia_cliente = "+
                "      public.familia_cliente.id_familia_cliente) "+
                "     LEFT OUTER JOIN public.kit_tipo_kit ON (public.pedido_kit.pek_tipo_kit = "+
                "      public.kit_tipo_kit.pek_tipo_kit) "+
                "     LEFT OUTER JOIN public.order_item ON (public.order_item_etiqueta.oie_order_number = "+
                "      public.order_item.order_number) AND (public.order_item_etiqueta.oie_order_pos = "+
                "       public.order_item.order_pos) "+
                "     LEFT JOIN public.produto ON (public.order_item_etiqueta.id_produto = "+
                "      public.produto.id_produto) "+
                "WHERE public.order_item_etiqueta.oie_nota_fiscal = 1 AND "+
                "      public.order_item_etiqueta.id_pedido_item IS NULL ";
            if (!this.mod)
            {
                sql +=
                "  AND (order_item_etiqueta.oie_status_pedido = 'P' OR                                                                                                                                                                                                            " +
                "  order_item_etiqueta.oie_status_pedido = 'R')                                                                                                                                                                                                               ";

            }

            if (!kit)
            {
                if (rdbSaldoCom.Checked)
                {
                    sql += " AND (order_item_etiqueta.oie_saldo_conferencia <> 0 ) ";
                }
                if (rdbSaldoSem.Checked)
                {
                    sql += " AND (order_item_etiqueta.oie_saldo_conferencia = 0 ) ";
                }
            }
             sql+=   "                                                                                                                                                                                                                                                   " +
                "                                                                                                                                                                                                                                                   " +
                "UNION                                                                                                                                                                                                                                               " +
                "                                                                                                                                                                                                                                                   " +
                "                                                                                                                                                                                                                                                   " +
                "SELECT                                                                                                                                                                                                                                             " +
                "  public.pedido_item.pei_numero,                                                                                                                                                                                                                   " +
                "  public.pedido_item.pei_posicao,                                                                                                                                                                                                                  " +
                "  public.kit_tipo_kit.ktk_sequencia,                                                                                                                                                                                                               " +
                "  public.kit_tipo_kit.id_tipo_kit,                                                                                                                                                                                                             " +
                "  public.kit_tipo_kit.pek_tipo_kit,                                                                                                                                                                                                                " +
                "  public.pedido_item.pei_data_entrega,                                                                                                                                                                                                             " +
                "  public.order_item_etiqueta.oie_dimensao,                                                                                                                                                                                                         " +
                "  public.order_item_etiqueta.oie_var_1_valor,                                                                                                                                                                                                      " +
                "  public.order_item_etiqueta.oie_var_2_valor,                                                                                                                                                                                                      " +
                "  public.pedido_item.pei_status,                                                                                                                                                                                                                   " +
                "  public.order_item_etiqueta_conferencia.oic_conferencia_pallet,                                                                                                                                                                                   " +
                "  public.order_item_etiqueta_conferencia.id_embarque,                                                                                                                                                                                              " +
                "  public.order_item_etiqueta.oie_situacao_conferencia,                                                                                                                                                                                             " +
                "  public.order_item_etiqueta_conferencia.oic_pallet,                                                                                                                                                                                               " +
                "  public.order_item_etiqueta.oie_codigo_item,                                                                                                                                                                                                      " +
                "  public.order_item_etiqueta.oie_data_impressao_op,                                                                                                                                                                                                " +
                "  public.order_item_etiqueta.oie_ovm,                                                                                                                                                                                                              " +
                "  public.cliente.cli_nome_resumido,                                                                                                                                                                                                                " +
                "  public.order_item.evolution_status,                                                                                                                                                                                                              " +
                "  public.pedido_item.pei_urgente,  " +
                "  public.pedido_item.pei_urgente_data_prometida, "+
                "  public.produto.id_local_fabricacao,                                                                                                                                                                                                              " +
                "  public.familia_cliente.fac_tipo_especial,                                                                                                                                                                                                        " +
                "  public.order_item_etiqueta.oie_codigo_cliente,                                                                                                                                                                                                     " +
                "  public.cliente.id_cliente, "+
                "  public.pedido_item.pei_data_entrada, " +
                "  public.pedido_item.id_produto, " +
                "  public.order_item_etiqueta.id_order_item_etiqueta, " +
                "  public.pedido_item.pei_projeto_cliente, " +
                "  public.order_item_etiqueta.oie_kit_fantasia " +
                "FROM                                                                                                                                                                                                                                               " +
                "  public.pedido_item                                                                                                                                                                                                                               " +
                "  LEFT OUTER JOIN public.order_item_etiqueta ON (public.pedido_item.id_pedido_item = public.order_item_etiqueta.id_pedido_item)                                                                                                                    " +
                "  LEFT OUTER JOIN public.order_item_etiqueta_conferencia ON (public.order_item_etiqueta.id_order_item_etiqueta = public.order_item_etiqueta_conferencia.id_order_item_etiqueta)                                                                    " +
                "  AND (public.order_item_etiqueta_conferencia.oic_nf_emitida = 0)                                                                                                                                                                                  " +
                "  LEFT OUTER JOIN public.pedido_kit ON (public.pedido_item.pei_numero = public.pedido_kit.pek_oc)                                                                                                                                                  " +
                "  AND (public.pedido_item.pei_posicao = public.pedido_kit.pek_pos)                                                                                                                                                                                 " +
                "  LEFT OUTER JOIN public.cliente ON (public.pedido_item.id_cliente = public.cliente.id_cliente)                                                                                                                                                    " +
                "  LEFT OUTER JOIN public.familia_cliente ON (public.cliente.id_familia_cliente = public.familia_cliente.id_familia_cliente)                                                                                                                        " +
                "  LEFT OUTER JOIN public.kit_tipo_kit ON (public.pedido_kit.pek_tipo_kit = public.kit_tipo_kit.pek_tipo_kit)                                                                                                                                       " +
                "  LEFT OUTER JOIN public.order_item ON (public.pedido_item.pei_numero = public.order_item.order_number)                                                                                                                                            " +
                "  AND (public.pedido_item.pei_posicao = public.order_item.order_pos)                                                                                                                                                                               " +
                "  INNER JOIN public.produto ON (public.pedido_item.id_produto = public.produto.id_produto)                                                                                                                                                         " +
                "WHERE                                                                                                                                                                                                                                              " +
                "  public.pedido_item.pei_sub_linha = 0 AND                                                                                                                                                                                                         " +
                "  public.order_item_etiqueta.oie_nota_fiscal = 1                                                                                                                                                                                               " ;
             if (!this.mod)
             {
                 sql += " AND (public.pedido_item.pei_status = 0 OR                                                                                                                                                                                                            " +
                 "  public.pedido_item.pei_status = 3)                                                                                                                                                                                                               ";
             }

            if (!kit)
            {
                if (rdbSaldoCom.Checked)
                {
                    sql += " AND (order_item_etiqueta.oie_saldo_conferencia <> 0 ) ";
                }
                if (rdbSaldoSem.Checked)
                {
                    sql += " AND (order_item_etiqueta.oie_saldo_conferencia = 0 ) ";
                }
            }
            sql += "                                                                                                                                                                                                                                                   " +
                ") as tab                                                                                                                                                                                                                                           ";


            string searchClause = "";

            if (this.kit)
            {
                searchClause += " AND pek_tipo_kit IS NOT NULL ";
            }
            else
            {
                searchClause += " AND pek_tipo_kit IS NULL ";
            }

            if (data != null)
            {
                searchClause += " AND pei_data_entrega <= '" + data.Value.ToString("yyyy-MM-dd") + "' ";

            }

            if (urgenteAntecipacao || urgenteUrgente || urgenteCritico)
            {
                string searchTmp = "";

                if (urgenteAntecipacao)
                {
                    searchTmp += " OR (pei_urgente = 1) ";
                }

                if (urgenteUrgente)
                {
                    searchTmp += " OR (pei_urgente = 2 OR (substring(pei_numero for 2) NOT LIKE '45' AND fac_tipo_especial = 1) )";
                }

                if (urgenteCritico)
                {
                     searchTmp += " OR (pei_urgente = 3) ";
                }

                searchClause += " AND (" + searchTmp.Substring(3) + ")";
            }

            if (embImediato)
            {
                searchClause += " AND evolution_status = '640' ";
            }

            if (somenteReprovados)
            {
                searchClause += " AND pei_status = 3 ";
            }

            if (idFabricante != null)
            {
                searchClause += " AND id_local_fabricacao = " + idFabricante;
            }


            if (oc != null && pos != null)
            {
                searchClause += " AND (pei_numero LIKE '" + oc + "' AND pei_posicao = " + pos + ") ";
            }

            if (idCliente !=null)
            {
                searchClause += " AND (id_cliente = " + idCliente + ") ";
            }

            if (idProduto.HasValue)
            {
                searchClause += " AND (id_produto = " + idProduto + ") ";
            }

            if (projeto != null)
            {
                searchClause += " AND (pei_projeto_cliente = '" + projeto + "') ";
            }

            if (searchClause.Length > 0)
            {
                sql += " WHERE " + searchClause.Substring(4);
            }

            

                sql += " "+
                " ORDER BY pei_data_entrega ASC, oie_ovm, ktk_sequencia, iwt_maior_variavel(oie_var_1_valor,oie_var_2_valor),pei_numero,pei_posicao                                                                                                                ";


            //command.CommandText = "SELECT oie_order_number, oie_order_pos, ktk_sequencia FROM tipo_kit JOIN (kit_tipo_kit JOIN (pedido_kit JOIN order_item_etiqueta ON pedido_kit.pek_oc = order_item_etiqueta.oie_order_number AND pedido_kit.pek_pos = order_item_etiqueta.oie_order_pos) ON kit_tipo_kit.pek_tipo_kit = pedido_kit.pek_tipo_kit) ON tipo_kit.id_tipo_kit = kit_tipo_kit.id_tipo_kit WHERE oie_pps = '" + txtPps.Text + "' AND oie_nota_fiscal = 1 ORDER BY ktk_sequencia, oie_order_number, oie_order_pos";
            command.CommandText = sql;
            IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
            DateTime? dataImpressao = null;


            while (read.Read())
            {
                if (read["oie_data_impressao_op"] != DBNull.Value)
                {
                    dataImpressao = Convert.ToDateTime(read["oie_data_impressao_op"]);
                }
                else
                {
                    dataImpressao = null;
                }

                DateTime? dataUrgentePrometida = read["pei_urgente_data_prometida"] as DateTime?;
                
                toRet.Add(
                    new KitClass(
                        Convert.ToInt32(read["id_order_item_etiqueta"]),
                        read["pei_numero"].ToString(),
                        read["pei_posicao"].ToString(),
                        read["id_tipo_kit"].ToString(),
                        read["pek_tipo_kit"].ToString(),
                        Convert.ToDateTime(read["pei_data_entrega"]),
                        read["situacao"].ToString(),
                        read["oic_pallet"].ToString(),
                        read["id_embarque"].ToString(),
                        read["oie_codigo_item"].ToString(),
                        dataImpressao,
                        read["urgente"].ToString(),
                        dataUrgentePrometida,
                        read["cli_nome_resumido"].ToString(),
                        read["oie_codigo_cliente"].ToString(),
                        read["id_cliente"].ToString(),
                        Convert.ToDateTime(read["pei_data_entrada"]),
                        read["oie_kit_fantasia"].ToString(),
                        read["pei_projeto_cliente"].ToString()
                        ));
            }
            read.Close();

            return toRet;
        }
        


 
        #region eventos

        private void rdbPps_CheckedChanged(object sender, EventArgs e)
        {
            this.radioButtonChange();            
        }

        private void rdbOcPos_CheckedChanged(object sender, EventArgs e)
        {
            this.radioButtonChange();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
       
            List<KitClass> listOcs = null;

            try
            {
                if (rdbPps.Checked && txtPps.Text.Trim().Length > 0)
                {
                    listOcs = this.buscaOcs(txtPps.Text.Trim());
                }

                if (rdbOcPos.Checked && txtOc.Text.Trim().Length > 0 && txtPos.Text.Trim().Length > 0)
                {

                    listOcs = this.buscaOcs(null, false, false, false, false, false, null, txtOc.Text.Trim(), txtPos.Text.Trim(), null, null, null);
                }

                if (rdbData.Checked)
                {
                    listOcs = this.buscaOcs(this.dtpData.Value, false, false, false, false, false, null, null, null, null, null, null);
                }

                if (rdbMatAdicional.Checked)
                {
                    if (!chkUrgenteAntecipacao.Checked && !chkUrgenteUrgente.Checked && !chkUrgenteCritico.Checked)
                    {
                        throw new ExcecaoTratada("Indique ao menos um tipo de urgência para a qual você deseja imprimir os relatórios");
                    }

                    listOcs = this.buscaOcs(null, chkUrgenteAntecipacao.Checked, chkUrgenteUrgente.Checked, chkUrgenteCritico.Checked, false, false, null, null, null, null, null, null);
                }

                if (rdbEmbarqueImediato.Checked)
                {
                    listOcs = this.buscaOcs(null, false, false, false, true, false, null, null, null, null, null, null);
                }

                if (rdbReprovados.Checked)
                {
                    listOcs = this.buscaOcs(null, false, false, false, false, true, null, null, null, null, null, null);
                }

                if (rdbFabricante.Checked)
                {
                    listOcs = this.buscaOcs(null, false, false, false, false, false, (int?)cmbFabricante.SelectedValue, null, null, null, null, null);
                }

                if (rdbCliente.Checked)
                {

                    listOcs = this.buscaOcs(null, false, false, false, false, false, null, null, null, (int?)cmbCliente.SelectedValue, null, null);
                }

                if (rdbProduto.Checked)
                {
                    listOcs = this.buscaOcs(null, false, false, false, false, false, null, null, null, null, (int?)cmbProduto.SelectedValue, null);
                }

                if (rdbProjeto.Checked && txtProjeto.Text.Trim().Length > 0)
                {
                    listOcs = this.buscaOcs(null, false, false, false, false, false, null, null, null, null, null, txtProjeto.Text.Trim());
                }

                if (listOcs?.Count > 0)
                {
                    if (!mod)
                    {
                        //List<KitClass> tmpList = new List<KitClass>();
                        //tmpList.AddRange(listOcs);

                        ChamadaKitDetalhesForm form = new ChamadaKitDetalhesForm(ref listOcs, this.kit,this.conn);
                        form.ShowDialog();
                        if (!form.continuar)
                        {
                            return;
                        }

                        listOcs = listOcs.Where(a => a.Imprimir).ToList();
                    }

                    string msg = "";
                    if (this.kit)
                    {
                        msg = "Essa operação irá imprimir as OPs com as opções selecionadas, deseja continuar?";
                    }
                    else
                    {
                        msg = "Essa operação irá imprimir o programa de expedição de itens sem kit com as opções selecionadas, deseja continuar?";
                    }

                    if (MessageBox.Show(this, msg, "Impressão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }

                    
                    if (this.kit)
                    {
                        if (IWTConfiguration.Conf.getConf(Constants.PERMITIR_SELECAO_IMPRESSORA_EXP) != null)
                        {
                            if (IWTConfiguration.Conf.getBoolConf(Constants.PERMITIR_SELECAO_IMPRESSORA_EXP))
                            {
                                KitReportClass kitReport1 = new KitReportClass(listOcs, this.logoEmpresa, null, mod, conn);
                            }
                            else
                            {
                                KitReportClass kitReport2 = new KitReportClass(listOcs, this.logoEmpresa, this.printer, mod, conn);
                            }
                        }
                        else
                        {
                            KitReportClass kitReport2 = new KitReportClass(listOcs, this.logoEmpresa, this.printer, mod, conn);
                        }

                    }
                    else
                    {
                        SemKitReportClass semKitReport = new SemKitReportClass(listOcs,this.logoEmpresa,this.printer, conn, mod);
                    }
                }
                else
                {
                    throw new Exception("Não existem itens para serem impressos com as opções selecionadas.");
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message,"Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }    
            
        }

        private void rdbData_CheckedChanged(object sender, EventArgs e)
        {
            this.radioButtonChange();
        }

        private void rdbMatAdicional_CheckedChanged(object sender, EventArgs e)
        {
            this.radioButtonChange();
        }
     
        private void rdbEmbarqueImediato_CheckedChanged(object sender, EventArgs e)
        {
            this.radioButtonChange();
        }
        
        private void rdbReprovados_CheckedChanged(object sender, EventArgs e)
        {
            this.radioButtonChange();
        }
       
        private void rdbFabricante_CheckedChanged(object sender, EventArgs e)
        {
            this.radioButtonChange();
        }

        private void rdbCliente_CheckedChanged(object sender, EventArgs e)
        {
            this.radioButtonChange();
        }

        private void rdbProduto_CheckedChanged(object sender, EventArgs e)
        {
            this.radioButtonChange();
        }

        private void rdbProjeto_CheckedChanged(object sender, EventArgs e)
        {
            this.radioButtonChange();
        }

        private void radioButtonChange()
        {
            this.gbxPps.Enabled = this.rdbPps.Checked;
            this.gbxOcPos.Enabled = this.rdbOcPos.Checked;
            this.gbxData.Enabled = this.rdbData.Checked;
            this.gbxFabricante.Enabled = this.rdbFabricante.Checked;
            this.gbxCliente.Enabled = this.rdbCliente.Checked;
            this.gbxProduto.Enabled = this.rdbProduto.Checked;
            this.gbxProjeto.Enabled = this.rdbProjeto.Checked;
            this.grbUrgente.Enabled = rdbMatAdicional.Checked;

        }



        private void rdbMatAdicional_CheckedChanged_1(object sender, EventArgs e)
        {
            this.radioButtonChange();
        }


        #endregion
    }
}