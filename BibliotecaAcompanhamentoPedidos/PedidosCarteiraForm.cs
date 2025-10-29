#region Referencias

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BibliotecaCadastrosBasicos;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib.ComplexLoginModule.Entidades.Base;
using IWTPostgreNpgsql;

#endregion

namespace ModuloAcompanhamentoPedidos
{
    public partial class PedidosCarteiraForm : IWTBaseForm
    {

        private readonly IWTPostgreNpgsqlConnection connection;
        public PedidosCarteiraForm( IWTPostgreNpgsqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
            this.initializeGrid();
        }

        private void initializeGrid()
        {
            string searchClause = "";
            string searchClauseNovos = "";
            string searchClauseAntigos = "";
            //Montagem Where
            if (this.txtBusca.Text.Trim().Length > 0)
            {
                searchClause += " AND (UPPER(numero||'/'||posicao) LIKE UPPER('%" + this.txtBusca.Text.Trim() + "%') OR UPPER(item) LIKE UPPER('%" +
                                this.txtBusca.Text.Trim() + "%') OR UPPER(classificacao) LIKE UPPER('%" + this.txtBusca.Text.Trim() + "%') " +
                                "OR UPPER(projeto) LIKE UPPER('%" + this.txtBusca.Text.Trim() + "%') " +
                                "OR UPPER(item_descricao) LIKE UPPER('%" + this.txtBusca.Text.Trim() + "%') " +
                                ") ";
            }

            if (this.txtBuscaConferencia.Text.Trim().Length > 0)
            {
                searchClause += " AND (UPPER(oic_identificacao_estacao) LIKE UPPER('%" + this.txtBuscaConferencia.Text.Trim() + "%') OR UPPER(oic_identificacao_usuario) LIKE UPPER('%" +
                                this.txtBuscaConferencia.Text.Trim() + "%') " +
                                ") ";
            }



            //Status

            string searchStatusNovos = "";
            string searchStatusAntigos = "";
            if (chkPendente.Checked)
            {
                //searchStatus += " OR status_pedido = '0' ";
                searchStatusNovos += " OR pei_status = '0' ";
                searchStatusAntigos += " OR oie_status_pedido = 'P' ";
            }

            if (chkEncerrado.Checked)
            {
                //searchStatus += " OR status_pedido = '1' ";
                searchStatusNovos += " OR pei_status = '1' ";
                searchStatusAntigos += " OR oie_status_pedido = 'E' ";
            }

            if (chkCancelado.Checked)
            {
                //searchStatus += " OR status_pedido = '2' ";
                searchStatusNovos += " OR pei_status = '2' ";
                searchStatusAntigos += " OR oie_status_pedido = 'C' ";
            }

            if (searchStatusNovos.Length > 0)
            {
                //searchClause += " AND ( " + searchStatus.Substring(3) + " )";
                searchClauseNovos += " AND ( " + searchStatusNovos.Substring(3) + " )";
                searchClauseAntigos += " AND ( " + searchStatusAntigos.Substring(3) + " )";
            }
            //Fim Status

            //Conferencia
            string searchConf = "";


            if (chkFabricacao.Checked)
            {
                searchConf += " OR (oic_conferencia_pallet IS NULL AND status_pedido = 0) ";
            }

            if (chkConfParcial.Checked)
            {
                searchConf += " OR (oic_conferencia_pallet = 0 AND oie_situacao_conferencia = 1) ";
            }

            if (chkConferido.Checked)
            {
                searchConf += " OR (oic_conferencia_pallet = 0 AND oie_situacao_conferencia = 2) ";
            }

            if (chkPalletConf.Checked)
            {
                searchConf += " OR (id_embarque IS NULL AND oic_conferencia_pallet = 1) ";
            }

            if (chkEmbarcado.Checked)
            {
                searchConf += " OR (id_embarque IS NOT NULL ) ";
            }

            if (chkFinalizado.Checked)
            {
                searchConf += " OR (status_pedido <> 0) ";
            }

            if (searchConf.Length > 0)
            {
                searchClause += " AND ( " + searchConf.Substring(3) + " )";
            }
            //Fim Conferencia


            IWTPostgreNpgsqlAdapter adapter;
            DataSet dataSet;
            try
            {


                string sql =
                    "SELECT                                                                                                                                                                             " +
                    "numero,                                                                                                                                                                            " +
                    "posicao,                                                                                                                                                                           " +
                    "projeto, " +
                    "item,                                                                                                                                                                              " +
                    "pro_codigo, "+
                    "item_descricao, "+
                    "pro_descricao, "+
                    "classificacao, " +
                    "CASE WHEN saldo<0 THEN 0 ELSE saldo END,                                                                                                                                           " +
                    "preco,                                                                                                                                                                             " +
                    "data_configuracao, " +
                    "CASE status_pedido                                                                                                                                                                 " +
                    "	WHEN 0 THEN 'Pendente'                                                                                                                                                            " +
                    "    WHEN 1 THEN 'Encerrado'                                                                                                                                                        " +
                    "    WHEN 2 THEN 'Cancelado'                                                                                                                                                        " +
                    "    WHEN 3 THEN 'Reaberto'                                                                                                                                                         " +
                    "    WHEN 4 THEN 'Suspenso'                                                                                                                                                         " +
                    "END as statu,                                                                                                                                                                      " +
                    "CASE WHEN status_pedido = 0 THEN                                                                                                                                                   " +
                    "	CASE                                                                                                                                                                              " +
                    "  	WHEN oic_conferencia_pallet IS NULL THEN 'Em Fabricação'                                                                                                                        " +
                    "    ELSE                                                                                                                                                                           " +
                    "   	CASE WHEN id_embarque IS NOT NULL THEN 'Pedido Embarcado'                                                                                                                     " +
                    "        ELSE                                                                                                                                                                       " +
                    "      		CASE WHEN oic_conferencia_pallet = 0 THEN                                                                                                                                 " +
                    "            	CASE WHEN oie_situacao_conferencia = 2 THEN 'Pedido Conferido Total'                                                                                                  " +
                    "                ELSE 'Pedido Conferido Parcial'                                                                                                                                    " +
                    "                END                                                                                                                                                                " +
                    "            ELSE                                                                                                                                                                   " +
                    "        	 'Pallet Conferido'                                                                                                                                                       " +
                    "            END                                                                                                                                                                    " +
                    "        END                                                                                                                                                                        " +
                    "	END                                                                                                                                                                               " +
                    "ELSE 'Finalizado' END as situacao,                                                                                                                                                 " +
                    "oic_data_conferencia, "+
                    "qtd_conferida, "+
                    "oic_identificacao_estacao, "+
                    "oic_identificacao_usuario, "+
                    "oic_conferencia_pallet_data, " +
                    "emb_data_hora, "+
                    "data_encerramento, "+
                    "pif_texto, " +
                    "CASE urgente                                                                                                                                                                       " +
                    "	WHEN 0 THEN                                                                                                                                                                       " +
                    "    	CASE                                                                                                                                                                          " +
                    "	        WHEN ped_cliente IS NOT NULL AND substring(ped_cliente for 2) NOT LIKE '45' THEN 'Urgente'                                                                                " +
                    "        END                                                                                                                                                                        " +
                    "    WHEN 1 THEN 'Antecipação'                                                                                                                                                      " +
                    "    WHEN 2 THEN 'Urgente'                                                                                                                                                          " +
                    "    WHEN 3 THEN 'Crítico'                                                                                                                                                          " +
                    "END as urgente, " +
                    "urgente_data_prometida, " +
                    "  id_cliente, " +
                    "  id_pedido_item "+
                    "                                                                                                                                                                                   " +
                    "                                                                                                                                                                                   " +
                    "FROM(                                                                                                                                                                              " +
                    "SELECT                                                                                                                                                                             " +
                    "  public.pedido_item.pei_numero as numero,                                                                                                                                         " +
                    "  public.pedido_item.pei_posicao as posicao,                                                                                                                                       " +
                    "  public.pedido_item.pei_projeto_cliente as projeto, "+
                    "  public.pedido_item.pei_produto_codigo_cliente as item,                                                                                                                           " +
                    "  public.pedido_item.pei_produto_descricao_cliente as item_descricao, "+
                    "  public.classificacao_produto.clp_identificacao as classificacao, " +
                    "  public.pedido_item.pei_saldo as saldo,                                                                                                                                           " +
                    "  public.pedido_item.pei_preco_unitario as preco,                                                                                                                                  " +
                    "  public.pedido_item.pei_status as status_pedido,                                                                                                                                  " +
                    "  public.pedido_item.pei_urgente as urgente,                                                                                                                                       " +
                    "  public.order_item_etiqueta.id_order_item_etiqueta,                                                                                                                               " +
                    "  public.order_item_etiqueta_conferencia.oic_conferencia_pallet,                                                                                                                   " +
                    "  public.order_item_etiqueta_conferencia.id_embarque,                                                                                                                              " +
                    "  public.order_item_etiqueta.oie_situacao_conferencia,                                                                                                                             " +
                    "  public.pedido_item.pei_data_configuracao as data_configuracao,                                                                                                                             " +
                    "  pei_numero as ped_cliente,                                                                                                                                                     " +
                    "  public.pedido_item.id_cliente, " +
                    "  public.order_item_etiqueta_conferencia.oic_data_conferencia, " +
                    "  public.order_item_etiqueta_conferencia.oic_conferencia_pallet_data, "+
                    "  public.embarque.emb_data_hora, "+
                    "  COALESCE(public.pedido_item.pei_data_cancelamento, public.pedido_item.pei_data_encerramento) as data_encerramento, "+
                    "  public.order_item_etiqueta_conferencia.oic_quantidade_conferida as qtd_conferida, " +
                    "  public.order_item_etiqueta_conferencia.oic_identificacao_estacao, "+
                    "  public.order_item_etiqueta_conferencia.oic_identificacao_usuario, " +
                    "  public.produto.pro_codigo, "+
                    "  public.produto.pro_descricao, "+
                    "  pei_urgente_data_prometida as urgente_data_prometida, " +
                    "  pif_texto, " +
                    "  pedido_item.id_pedido_item " +
                    "FROM                                                                                                                                                                               " +
                    "  public.pedido_item                                                                                                                                                               " +
                    "  LEFT OUTER JOIN public.order_item_etiqueta ON (public.pedido_item.id_pedido_item = public.order_item_etiqueta.id_pedido_item)                                                    " +
                    "  LEFT OUTER JOIN public.order_item_etiqueta_conferencia ON (public.order_item_etiqueta.id_order_item_etiqueta = public.order_item_etiqueta_conferencia.id_order_item_etiqueta)    " +
                    "  LEFT OUTER JOIN public.produto ON public.produto.id_produto = public.pedido_item.id_produto " +
                    "  LEFT OUTER JOIN public.classificacao_produto ON public.classificacao_produto.id_classificacao_produto = public.produto.id_classificacao_produto " +
                    "  LEFT OUTER JOIN public.embarque  ON (public.order_item_etiqueta_conferencia.id_embarque = public.embarque.id_embarque) "+
                    "  LEFT OUTER JOIN \r\n  (\r\n  SELECT id_pedido_item, pif_texto FROM public.pedido_item_feedback \r\n  WHERE\r\n  pif_atual = 1\r\n  ) as feedback\r\n   ON (public.pedido_item.id_pedido_item = feedback.id_pedido_item) "+
                    "WHERE                                                                                                                                                                              " +
                    "  public.pedido_item.pei_sub_linha = 0 AND                                                                                                                                         " +
                    "  (public.pedido_item.pei_configurado = 1 AND                                                                                                                                      " +
                    "  public.order_item_etiqueta.id_order_item_etiqueta IS NOT NULL OR                                                                                                                 " +
                    "  public.pedido_item.pei_configurado = 0)                                                                                                                                          " +
                    searchClauseNovos+" "+
                    "                                                                                                                                                                                   " +
                    "  UNION ALL                                                                                                                                                                            " +
                    "                                                                                                                                                                                   " +
                    "                                                                                                                                                                                   " +
                    "SELECT                                                                                                                                                                             " +
                    "  public.order_item_etiqueta.oie_order_number as numero,                                                                                                                           " +
                    "  public.order_item_etiqueta.oie_order_pos as posicao,                                                                                                                             " +
                    "  '' as projeto, "+
                    "  public.order_item_etiqueta.oie_codigo_cliente as item,                                                                                                                           " +
                    "  '' as item_descricao, " +
                    "  '' as classificacao, " +
                    "  public.order_item_etiqueta.oie_saldo as saldo,                                                                                                                                   " +
                    "  public.order_item_etiqueta.oie_preco_unitario as preco,                                                                                                                          " +
                    "  CASE public.order_item_etiqueta.oie_status_pedido WHEN 'P' THEN 0 WHEN 'E' THEN 1 WHEN 'C' THEN 2 WHEN 'R' THEN 3 END as status_pedido,                                          " +
                    "  0 as urgente,                                                                                                                                                                    " +
                    "  public.order_item_etiqueta.id_order_item_etiqueta,                                                                                                                               " +
                    "  public.order_item_etiqueta_conferencia.oic_conferencia_pallet,                                                                                                                   " +
                    "  public.order_item_etiqueta_conferencia.id_embarque,                                                                                                                              " +
                    "  public.order_item_etiqueta.oie_situacao_conferencia,                                                                                                                             " +
                    "  NULL as data_configuracao, " +
                    "  oie_order_number as ped_cliente,                                                                                                                                                     " +
                    "  public.order_item_etiqueta.id_cliente, " +
                    "  public.order_item_etiqueta_conferencia.oic_data_conferencia, " +
                    "  public.order_item_etiqueta_conferencia.oic_conferencia_pallet_data, " +
                    "  public.embarque.emb_data_hora, " +
                    "  NULL, "+
                    "  public.order_item_etiqueta_conferencia.oic_quantidade_conferida as qtd_conferida, " +
                    "  public.order_item_etiqueta_conferencia.oic_identificacao_estacao, " +
                    "  public.order_item_etiqueta_conferencia.oic_identificacao_usuario, " +
                    " '', "+
                    " '', " +
                    " NULL, "+
                    " '', " +
                    " NULL "+
                    "FROM                                                                                                                                                                               " +
                    "  public.order_item_etiqueta                                                                                                                                                       " +
                    "  LEFT OUTER JOIN public.order_item_etiqueta_conferencia ON (public.order_item_etiqueta.id_order_item_etiqueta = public.order_item_etiqueta_conferencia.id_order_item_etiqueta)    " +
                    "  LEFT OUTER JOIN public.embarque  ON (public.order_item_etiqueta_conferencia.id_embarque = public.embarque.id_embarque) " +
                    "WHERE                                                                                                                                                                              " +
                    "  public.order_item_etiqueta.oie_nota_fiscal = 1 AND                                                                                                                               " +
                    "  public.order_item_etiqueta.id_pedido_item IS NULL                                                                                                                                " +
                    searchClauseAntigos + " " +
                    " ) as tab                                                                                                                                                                          " +
                    "                                                                                                                                                                                   ";

                if (searchClause.Length > 0)
                {
                    sql += " WHERE " + searchClause.Substring(4) + " ";
                }
                sql +=
                    "                                                                                                                                                                                   " +
                    "ORDER BY                                                                                                                                                                           " +
                    "numero,                                                                                                                                                                            " +
                    "posicao,                                                                                                                                                                           " +
                    "status_pedido                                                                                                                                                                      ";


                adapter = new IWTPostgreNpgsqlAdapter(sql, this.connection);

                dataSet = new DataSet();
                adapter.Fill(dataSet);

                BindingSource binding = new BindingSource();
                binding.DataSource = dataSet.Tables[0];

                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = binding;

                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[0], "Pedido", 100,DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[1], "Posição", 50,DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[2], "Projeto", 100, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[3], "Item", 100,DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[4], "Item - Interno", 100, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[5], "Descrição", 100, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[6], "Descrição - Interna", 100, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[7], "Classificação", 90,DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[8], "Saldo", 80,DataGridViewAutoSizeColumnMode.None, true);

                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[9], "Valor Unit", 80, DataGridViewAutoSizeColumnMode.None, true);
                if (!LoginClass.UsuarioLogado.HasAccess("MODULO_PCP_PEDIDOS_VALORES", AcsTipoAcesso.Escrita))
                {
                    this.dataGridView1.Columns[9].Visible = false;
                }
                


                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[10], "Configuracao", 95,DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[11], "Status", 100,DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[12], "Situação", 150,DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[13], "Data Conferência", 95,DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[14], "Quantidade Conferida", 95, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[15], "Estação de Conferência", 95, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[16], "Usuario Conferente", 95, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[17], "Data Conferência Pallet", 95, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[18], "Data Embarque", 95, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[19], "Data Encerramento / Cancelamento", 95, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[20], "Feedback", 250, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[21], "Urgente", 100,DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[22], "Data Prometida", 95, DataGridViewAutoSizeColumnMode.None, true);
                this.dataGridView1.Columns[23].Visible = false;
                this.dataGridView1.Columns[24].Visible = false;




                //Carrega o total

                this.lblQtdPedidos.Text = this.dataGridView1.RowCount.ToString();

                /*string sql2 =
                     "SELECT " +
                     "COUNT (*) as qtdLinhas "+
                     "FROM ( " + sql + " ) as tab";
                

                 IWTPostgreNpgsqlCommand command = this.connection.CreateCommand();
                 command.CommandText = sql2;

                 IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                 read.Read();
                 if (read["qtdLinhas"] != DBNull.Value)
                 {
                     this.lblQtdPedidos.Text = Convert.ToInt32(read["qtdLinhas"]).ToString();
                 }
                 else
                 {
                     this.lblQtdPedidos.Text = "0";
                 }
                 read.Close();
                 */
            }
            catch (Exception z)
            {
                MessageBox.Show("Erro em carregar o Grid. \n" + z.Message, "Erro", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
        }

        private void AbrirDetalhesProducao(int indiceLinha)
        {
            try
            {
                RastreamentoProducaoForm form;
                if (this.dataGridView1.Rows[indiceLinha].Cells["id_pedido_item"].Value != null)
                {
                 form = new RastreamentoProducaoForm(Convert.ToInt64(this.dataGridView1.Rows[indiceLinha].Cells["id_pedido_item"].Value), this.connection);
                }
                else
                {
                    form = new RastreamentoProducaoForm(
                        this.dataGridView1.Rows[indiceLinha].Cells["numero"].Value.ToString(),
                        Convert.ToInt32(this.dataGridView1.Rows[indiceLinha].Cells["posicao"].Value),
                        Convert.ToInt64(this.dataGridView1.Rows[indiceLinha].Cells["id_cliente"].Value), 
                        this.connection);
                }





                form.Show();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar o rastreamento de produção.\r\n" + e.Message);
            }
        }


        private void NovoFeedback()
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count < 1)
                {
                    throw new Exception("Selecione ao menos um pedido para incluir um feedback.");
                }

                List<PedidoItemClass> pedidos = new List<PedidoItemClass>();

                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    if (row.Cells["id_pedido_item"].Value != null)
                    {

                        PedidoItemClass pedido = PedidoItemClass.GetEntidade(Convert.ToInt64(row.Cells["id_pedido_item"].Value), LoginClass.UsuarioLogado.loggedUser, SingleConnection);

                        if (pedido.Status != StatusPedido.Pendente && pedido.Status != StatusPedido.Reaberto)
                        {
                            throw new Exception("Só é possível incluir feedbacks em pedidos pendentes ou reabertos (" + pedido + ").");
                        }
                        else
                        {
                            pedidos.Add(pedido);
                        }
                    }
                }

                CadPedidoItemFeedbackForm form = new CadPedidoItemFeedbackForm(pedidos, false);
                form.ShowDialog(this);

            }
            catch (ExcecaoTratada)
            {
                BufferAbstractEntity.limparBuffer();
                throw;
            }
            catch (Exception e)
            {
                BufferAbstractEntity.limparBuffer();
                throw new Exception("Erro inesperado ao inserir um novo feedback.\r\n" + e.Message, e);
            }
            finally
            {
                initializeGrid();
            }
        }


        #region Eventos
        private void txtOC_TextChanged(object sender, EventArgs e)
        {
            timerBusca.Stop();
            timerBusca.Start();
        }


        private void chkPendente_CheckedChanged(object sender, EventArgs e)
        {
            this.initializeGrid();
        }

        private void chkEncerrado_CheckedChanged(object sender, EventArgs e)
        {
            this.initializeGrid();
        }

        private void chkCancelado_CheckedChanged(object sender, EventArgs e)
        {
            this.initializeGrid();
        }

        private void lnkAtualizar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.initializeGrid();
        }

             
  
      
        private void chkFabricacao_CheckedChanged(object sender, EventArgs e)
        {
            this.initializeGrid();
        }

        private void chkConfParcial_CheckedChanged(object sender, EventArgs e)
        {
            this.initializeGrid();
        }

        private void chkConferido_CheckedChanged(object sender, EventArgs e)
        {
            this.initializeGrid();
        }

        private void chkPalletConf_CheckedChanged(object sender, EventArgs e)
        {
            this.initializeGrid();
        }

        private void chkEmbarcado_CheckedChanged(object sender, EventArgs e)
        {
            this.initializeGrid();
        }

        private void chkFinalizado_CheckedChanged(object sender, EventArgs e)
        {
            this.initializeGrid();
        }


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    this.AbrirDetalhesProducao(e.RowIndex);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timerBusca_Tick(object sender, EventArgs e)
        {
            timerBusca.Enabled = false;
            this.initializeGrid();
        }

        private void txtBuscaConferencia_TextChanged(object sender, EventArgs e)
        {
            timerBusca.Stop();
            timerBusca.Start();
        }


        private void btnFeedback_Click(object sender, EventArgs e)
        {
            try {
                this.NovoFeedback();
            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        
    }
}
