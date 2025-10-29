#region Referencias

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule;
using IWTPostgreNpgsql;

#endregion

namespace ModuloAcompanhamentoPedidos
{
    public partial class RastreamentoProducaoForm : IWTBaseForm
    {
        readonly IWTPostgreNpgsqlConnection _conn;
        readonly string _oc;
        readonly int _pos;
        readonly long _idCliente;
        BindingSource binding;

        readonly PedidoItemClass _pedido;

        public RastreamentoProducaoForm(string oc, int pos, long idCliente, IWTPostgreNpgsqlConnection conn)
        {
            
            this._oc = oc;
            this._pos = pos;
            this._idCliente = idCliente;

            this._conn = conn;

            ClienteClass cliente = ClienteClass.GetEntidade(idCliente, LoginClass.UsuarioLogado.loggedUser, _conn);
            List<PedidoItemClass> possiveisPedidos = PedidoItemClass.BuscaPedido(_oc, _pos, cliente, LoginClass.UsuarioLogado.loggedUser, _conn);
            if (possiveisPedidos.Count == 0)
            {
                throw new ExcecaoTratada("Não foram encontrados pedidos para o número " + _oc + "/" + _pos + " no cliente " + cliente.Nome);
            }

            if (possiveisPedidos.Count > 1)
            {
                throw new Exception("Foram encontrados múltiplos pedidos para o número " + _oc + "/" + _pos + " no cliente " + cliente.Nome);
            }

            _pedido = possiveisPedidos.First();

            inicializarTel();

        }


        public RastreamentoProducaoForm(long idPedidoItem, IWTPostgreNpgsqlConnection conn)
        {
            this._conn = conn;

            _pedido = PedidoItemClass.GetEntidade(idPedidoItem,LoginClass.UsuarioLogado.loggedUser,conn);

            this._oc = _pedido.Numero;
            this._pos = _pedido.Posicao;
            this._idCliente = _pedido.Cliente.ID;

            

            inicializarTel();

        }

        private void inicializarTel()
        {
            InitializeComponent();

            this.lblPedido.Text = "Pedido Selecionado: " + this._oc + "/" + this._pos;

            this.initializeGrid();
            LoadGridFeedback();



        }

        private void LoadGridFeedback()
        {
            this.dgvFeedbacks.AutoGenerateColumns = false;
            this.dgvFeedbacks.Columns.Clear();

            this.dgvFeedbacks.Columns.Add(new DataGridViewTextBoxColumn());
            this.dgvFeedbacks.Columns[this.dgvFeedbacks.Columns.Count - 1].DataPropertyName = "Data";
            this.dgvFeedbacks.Columns[this.dgvFeedbacks.Columns.Count - 1].Name = "Data";
            this.dgvFeedbacks.Columns[this.dgvFeedbacks.Columns.Count - 1].HeaderText = "Data";
            this.dgvFeedbacks.Columns[this.dgvFeedbacks.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            this.dgvFeedbacks.Columns.Add(new DataGridViewTextBoxColumn());
            this.dgvFeedbacks.Columns[this.dgvFeedbacks.Columns.Count - 1].DataPropertyName = "AcsUsuario";
            this.dgvFeedbacks.Columns[this.dgvFeedbacks.Columns.Count - 1].Name = "AcsUsuario";
            this.dgvFeedbacks.Columns[this.dgvFeedbacks.Columns.Count - 1].HeaderText = "Responsável";
            this.dgvFeedbacks.Columns[this.dgvFeedbacks.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            this.dgvFeedbacks.Columns.Add(new DataGridViewTextBoxColumn());
            this.dgvFeedbacks.Columns[this.dgvFeedbacks.Columns.Count - 1].DataPropertyName = "Texto";
            this.dgvFeedbacks.Columns[this.dgvFeedbacks.Columns.Count - 1].Name = "Texto";
            this.dgvFeedbacks.Columns[this.dgvFeedbacks.Columns.Count - 1].HeaderText = "Feedback";
            this.dgvFeedbacks.Columns[this.dgvFeedbacks.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.dgvFeedbacks.Columns[this.dgvFeedbacks.Columns.Count - 1].Width = 350;

            this.dgvFeedbacks.DataSource = new AdvancedList<PedidoItemFeedbackClass>(this._pedido.CollectionPedidoItemFeedbackClassPedidoItem.OrderBy(a => a.Data));


        }

        private void initializeGrid()
        {
            #region Salvando Posição do Grid
            int scrollIndex = 0;
            if (this.dataGridView1.FirstDisplayedScrollingRowIndex > 0)
            {
                scrollIndex = this.dataGridView1.FirstDisplayedScrollingRowIndex;
            }

            int selectRowIndex = 0;
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                selectRowIndex = this.dataGridView1.SelectedRows[0].Index;
            }
            #endregion

            #region Salvando FiltroAtual

            string atualFilter;
            if (this.binding != null)
            {
                atualFilter = this.binding.Filter;
            }
            else
            {
                atualFilter = "";
            }

            #endregion

            #region Salvando o Sort Atual do Grid

            string sortedColumName = null;
            SortOrder? sortedMode = null;
            if (this.dataGridView1.SortedColumn != null)
            {
                sortedColumName = this.dataGridView1.SortedColumn.Name;
                sortedMode = this.dataGridView1.SortOrder;
            }

            #endregion



            string sql =
                /*
                "SELECT  " +
                "  public.order_item_etiqueta.oie_codigo_item, " +
                "  op.opp_quantidade, " +
                " CASE WHEN  op.id_ordem_producao IS NULL THEN " +
                "      CASE WHEN (produto_k.prk_emite_op IS NOT NULL AND produto_k.prk_emite_op = 1) OR ( produto_k.prk_emite_op IS NULL AND produto.pro_emite_op = 1) THEN 'OP Não Emitida' "+
                "       ELSE 'Não Emite OP' END "+
                "    ELSE   "+
                "      CASE orp_situacao WHEN 3 THEN 'Cancelada' WHEN 2 THEN 'Encerrada em '|| to_char(orp_data_encerramento, 'DD/MM/YYYY HH24:MI:SS') ||' - '|| usuarioEncerramento  ELSE   "+
                "        CASE WHEN tab.id_ordem_producao IS NULL THEN 'Não Iniciada' ELSE   "+
                "            CASE posto_trabalho.pos_acompanhamento    "+
                "              WHEN 1 THEN    "+
                "                'Passou às ' || to_char(tab.opt_tempo1, 'DD/MM/YYYY HH24:MI:SS') ||' - '||tab.opt_operador_tempo_1     "+
                "              WHEN 2 THEN    "+
                "                CASE WHEN tab.opt_tempo2 IS NOT NULL THEN 'Saiu '||tab.opt_posto_codigo || ' às ' || to_char(tab.opt_tempo2, 'DD/MM/YYYY HH24:MI:SS') ||' - '||tab.opt_operador_tempo_2 ELSE 'Em '|| tab.opt_posto_codigo || ' às ' || to_char(tab.opt_tempo1, 'DD/MM/YYYY HH24:MI:SS') ||' - '||tab.opt_operador_tempo_1 END    "+
                "              WHEN 3 THEN    "+
                "                CASE WHEN tab.opt_tempo3 IS NOT NULL THEN 'Saiu '||tab.opt_posto_codigo || ' às ' || to_char(tab.opt_tempo3, 'DD/MM/YYYY HH24:MI:SS') ||' - '||tab.opt_operador_tempo_3 ELSE 'Em '|| tab.opt_posto_codigo || ' às ' || to_char(tab.opt_tempo1, 'DD/MM/YYYY HH24:MI:SS') ||' - '||tab.opt_operador_tempo_1 END    "+
                "              ELSE 'Erro'   "+
                "            END  "+ 
                "        END   "+
                "      END   "+
                "  END as situacao, "+
                "  op.id_ordem_producao " +
                "FROM " +
                "  public.order_item_etiqueta " +
                //"  LEFT OUTER JOIN public.pedido_item ON pedido_item.id_pedido_item = order_item_etiqueta.id_pedido_item "+
                "  LEFT OUTER JOIN ( " +
                "  	SELECT ordem_producao_pedido.id_ordem_producao,ordem_producao_pedido.id_order_item_etiqueta, ordem_producao.orp_situacao,ordem_producao_pedido.opp_quantidade, ordem_producao.id_produto, aus_login as usuarioEncerramento,ordem_producao.orp_data_encerramento   FROM public.ordem_producao_pedido JOIN ordem_producao ON ordem_producao_pedido.id_ordem_producao = ordem_producao.id_ordem_producao LEFT JOIN acs_usuario ON ordem_producao.id_acs_usuario_encerramento = acs_usuario.id_acs_usuario " +
                "  ) as op ON (public.order_item_etiqueta.id_order_item_etiqueta = op.id_order_item_etiqueta) " +
                "  LEFT OUTER JOIN (  " +
                " 	SELECT ordem_producao_posto_trabalho.* FROM ( " +
                "	SELECT id_ordem_producao, max(opt_sequencia) as seq	 " +
                "		FROM ordem_producao_posto_trabalho " +
                "		WHERE opt_tempo1 IS NOT NULL OR opt_tempo2 IS NOT NULL OR opt_tempo3 IS NOT NULL OR opt_tempo4 IS NOT NULL " +
                "		GROUP BY id_ordem_producao " +
                "        ) as seqMax JOIN ordem_producao_posto_trabalho ON ordem_producao_posto_trabalho.id_ordem_producao = seqMax.id_ordem_producao AND ordem_producao_posto_trabalho.opt_sequencia = seqMax.seq " +
                "        ) as tab ON op.id_ordem_producao = tab.id_ordem_producao " +
                "	LEFT OUTER JOIN posto_trabalho ON posto_trabalho.id_posto_trabalho = tab.id_posto_trabalho " +
                "	LEFT OUTER JOIN produto ON produto.id_produto = op.id_produto " +
                "   LEFT OUTER JOIN produto_k ON order_item_etiqueta.id_produto_k = produto_k.id_produto_k "+
                "WHERE " +
                "   public.order_item_etiqueta.oie_order_number LIKE '" + this.OC + "' AND " +
                "   public.order_item_etiqueta.oie_order_pos = " + this.Pos + " ";
                */

                "SELECT  " +
                " CASE pei_configurado WHEN 1 THEN oie_codigo_item ELSE pei_produto_codigo_cliente END AS codigo_item, " +
                " CASE pei_configurado WHEN 1 THEN oie_descricao ELSE pei_produto_descricao_cliente END AS descricao_item, " +
                " op.opp_quantidade,   " +
                " CASE WHEN pei_configurado = 0 THEN 'Não Configurado' ELSE " +
                "   CASE WHEN  op.id_ordem_producao IS NULL THEN   " +
                "        CASE WHEN (produto_k.prk_emite_op IS NOT NULL AND produto_k.prk_emite_op = 1) OR ( produto_k.prk_emite_op IS NULL AND produto.pro_emite_op = 1) THEN 'OP Não Emitida'  " +
                "         ELSE 'Não Emite OP' END  " +
                "      ELSE    " +
                "        CASE orp_situacao WHEN 3 THEN 'Cancelada' WHEN 2 THEN 'Encerrada em '|| to_char(orp_data_encerramento, 'DD/MM/YYYY HH24:MI:SS') ||' - '|| usuarioEncerramento  ELSE    " +
                "          CASE WHEN tab.id_ordem_producao IS NULL THEN 'Não Iniciada' ELSE    " +
                "              CASE posto_trabalho.pos_acompanhamento     " +
                "                WHEN 1 THEN     " +
                "                  'Passou ' || tab.opt_posto_codigo || ' às ' || to_char(tab.opt_tempo1, 'DD/MM/YYYY HH24:MI:SS') ||' - '||tab.opt_operador_tempo_1      " +
                "                WHEN 2 THEN     " +
                "                  CASE WHEN tab.opt_tempo2 IS NOT NULL THEN 'Saiu '||tab.opt_posto_codigo || ' às ' || to_char(tab.opt_tempo2, 'DD/MM/YYYY HH24:MI:SS') ||' - '||tab.opt_operador_tempo_2 ELSE 'Em '|| tab.opt_posto_codigo || ' às ' || to_char(tab.opt_tempo1, 'DD/MM/YYYY HH24:MI:SS') ||' - '||tab.opt_operador_tempo_1 END     " +
                "                WHEN 3 THEN     " +
                "                  CASE WHEN tab.opt_tempo3 IS NOT NULL THEN 'Saiu '||tab.opt_posto_codigo || ' às ' || to_char(tab.opt_tempo3, 'DD/MM/YYYY HH24:MI:SS') ||' - '||tab.opt_operador_tempo_3 ELSE 'Em '|| tab.opt_posto_codigo || ' às ' || to_char(tab.opt_tempo1, 'DD/MM/YYYY HH24:MI:SS') ||' - '||tab.opt_operador_tempo_1 END     " +
                "                WHEN 4 THEN     " +
                "                  'Passou ' || tab.opt_posto_codigo || ' às ' || to_char(tab.opt_tempo1, 'DD/MM/YYYY HH24:MI:SS') ||' - '||tab.opt_operador_tempo_1      " +
                "                ELSE 'Erro'    " +
                "              END  " +
                "          END   " +
                "        END  " +
                "     END      " +
                "  END as situacao,  " +
                "  op.id_ordem_producao,   " +
                "  public.estoque.est_identificacao || ' - '||  public.estoque_corredor.esc_identificacao|| ' - '||  public.estoque_prateleira.esp_identificacao|| ' - '||  public.estoque_gaveta.esg_identificacao as estoqueString, "+
                "  posto_trabalho.pos_cor_destaque_evolucao "+
                "FROM " +
                "    public.pedido_item " +
                "    LEFT OUTER JOIN public.order_item_etiqueta ON  " +
                "    (public.pedido_item.id_pedido_item = public.order_item_etiqueta.id_pedido_item) OR " +
                "    ( " +
                "       public.order_item_etiqueta.id_pedido_item IS NULL AND  " +
                "       public.order_item_etiqueta.oie_order_number = public.pedido_item.pei_numero AND  " +
                "       public.order_item_etiqueta.oie_order_pos = public.pedido_item.pei_posicao AND " +
                "       public.order_item_etiqueta.id_cliente = public.pedido_item.id_cliente AND  " +
                "       public.order_item_etiqueta.oie_nivel_item = public.pedido_item.pei_sub_linha    " +
                "    )  " +
                "    LEFT OUTER JOIN (   " +
                "        SELECT ordem_producao_pedido.id_ordem_producao,ordem_producao_pedido.id_order_item_etiqueta, ordem_producao.orp_situacao,ordem_producao_pedido.opp_quantidade, ordem_producao.id_produto, aus_login as usuarioEncerramento,ordem_producao.orp_data_encerramento, ordem_producao.id_estoque_gaveta   FROM public.ordem_producao_pedido JOIN ordem_producao ON ordem_producao_pedido.id_ordem_producao = ordem_producao.id_ordem_producao LEFT JOIN acs_usuario ON ordem_producao.id_acs_usuario_encerramento = acs_usuario.id_acs_usuario   " +
                "    ) as op ON (public.order_item_etiqueta.id_order_item_etiqueta = op.id_order_item_etiqueta)   " +
                "    LEFT OUTER JOIN (    " +
                "    SELECT ordem_producao_posto_trabalho.* FROM (   " +
                "    SELECT id_ordem_producao, max(opt_sequencia) as seq	   " +
                "        FROM ordem_producao_posto_trabalho   " +
                "        WHERE opt_tempo1 IS NOT NULL OR opt_tempo2 IS NOT NULL OR opt_tempo3 IS NOT NULL OR opt_tempo4 IS NOT NULL   " +
                "        GROUP BY id_ordem_producao   " +
                "          ) as seqMax JOIN ordem_producao_posto_trabalho ON ordem_producao_posto_trabalho.id_ordem_producao = seqMax.id_ordem_producao AND ordem_producao_posto_trabalho.opt_sequencia = seqMax.seq   " +
                "          ) as tab ON op.id_ordem_producao = tab.id_ordem_producao   " +
                "    LEFT OUTER JOIN posto_trabalho ON posto_trabalho.id_posto_trabalho = tab.id_posto_trabalho   " +
                "    LEFT OUTER JOIN produto ON produto.id_produto = order_item_etiqueta.id_produto   " +
                "    LEFT OUTER JOIN produto_k ON order_item_etiqueta.id_produto_k = produto_k.id_produto_k  " +
                "    LEFT OUTER JOIN public.estoque_gaveta ON (op.id_estoque_gaveta = public.estoque_gaveta.id_estoque_gaveta) " +
                "    LEFT OUTER JOIN public.estoque_prateleira ON (public.estoque_gaveta.id_estoque_prateleira = public.estoque_prateleira.id_estoque_prateleira) "+
                "    LEFT OUTER JOIN public.estoque_corredor ON (public.estoque_prateleira.id_estoque_corredor = public.estoque_corredor.id_estoque_corredor) "+
                "    LEFT OUTER JOIN public.estoque ON (public.estoque_corredor.id_estoque = public.estoque.id_estoque) "+
                "WHERE  " +
                "  public.pedido_item.pei_numero LIKE '" + this._oc + "' AND " +
                "  public.pedido_item.pei_posicao = " + this._pos + " AND " +
                "  public.pedido_item.id_cliente = " + this._idCliente + " ";

            IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this._conn);
            if (adapter != null)
            {
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                binding = new BindingSource();
                binding.DataSource = ds.Tables[0];
                binding.Filter = atualFilter;
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = binding;

                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[0], "Item", 120, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[1], "Descrição", 120, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[2], "Quantidade", 80, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[3], "Situação", 220, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[4], "Nº OP", 80, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[5], "Estoque Saída OP", 120, DataGridViewAutoSizeColumnMode.None, true);
                this.dataGridView1.Columns[6].Visible = false;

            }


            #region Restaurando Sort Atual do Grid

            if (sortedColumName != null)
            {
                string sortString = sortedColumName;
                switch (sortedMode)
                {
                    case SortOrder.Ascending:
                        sortString += " ASC";
                        break;
                    case SortOrder.Descending:
                        sortString += " DESC";
                        break;
                }

                this.binding.Sort = sortString;
            }
            #endregion

            #region Restaurando Posição do Grid
            for (int i = 0; i < this.dataGridView1.SelectedRows.Count; i++)
            {
                this.dataGridView1.SelectedRows[i].Selected = false;
            }
            if (this.dataGridView1.Rows.Count > 0)
            {
                while (selectRowIndex > 0 && selectRowIndex >= this.dataGridView1.Rows.Count)
                {
                    selectRowIndex--;
                }


                this.dataGridView1.Rows[selectRowIndex].Selected = true;

                while (scrollIndex > 0 && scrollIndex >= this.dataGridView1.Rows.Count)
                {
                    scrollIndex--;
                }

                this.dataGridView1.FirstDisplayedScrollingRowIndex = scrollIndex;
            }
            #endregion



        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "situacao" && e.Value != null)
            {

                string corEspecifica = dataGridView1.Rows[e.RowIndex].Cells["pos_cor_destaque_evolucao"].Value.ToString();


                switch (e.Value.ToString())
                {
                    case "Não Configurado":
                    case "Não Emite OP":
                        foreach (DataGridViewCell cell in dataGridView1.Rows[e.RowIndex].Cells)
                        {
                            cell.Style.BackColor = Color.White;
                        }
                        break;
                    case "Encerrada":
                        foreach (DataGridViewCell cell in dataGridView1.Rows[e.RowIndex].Cells)
                        {
                            cell.Style.BackColor = Color.Green;
                        }
                        break;

                    case "Não Iniciada":
                    case "Cancelada":
                    case "Erro":
                        foreach (DataGridViewCell cell in dataGridView1.Rows[e.RowIndex].Cells)
                        {
                            cell.Style.BackColor = Color.Red;
                        }
                        break;
                    default:

                        if (e.Value.ToString().StartsWith("Encerrada"))
                        {
                            foreach (DataGridViewCell cell in dataGridView1.Rows[e.RowIndex].Cells)
                            {
                                cell.Style.BackColor = Color.Green;
                            }
                        }
                        else
                        {
                            Color cor = Color.Yellow;
                            if (!string.IsNullOrEmpty(corEspecifica))
                            {
                                cor = ColorTranslator.FromHtml(corEspecifica);
                            }


                            foreach (DataGridViewCell cell in dataGridView1.Rows[e.RowIndex].Cells)
                            {
                                cell.Style.BackColor = cor;
                            }
                        }
                        break;

                }


            }
        }

    }
}
