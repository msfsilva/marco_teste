#region Referencias

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BibliotecaComunicacaoGAD.api;
using BibliotecaComunicacaoGAD.dto;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Operacoes.Configurador;
using BibliotecaTributos;
using Configurations;
using IWTCustomControls;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib.TelaProgresso;
using IWTPostgreNpgsql;
using ProjectConstants;

#endregion

namespace BibliotecaCadastrosBasicos.TelasAuxiliares
{
    public partial class PedidosConfiguradorForm : IWTBaseForm
    {
        private readonly IWTPostgreNpgsqlConnection conn;
        private BindingSource binding;
        
        private readonly string tipoCalculoSemana;
        private readonly string diaCalculoSemana;
        private readonly int qtdThreads;
        private IConfiguradorEASIFactory configuradorEasiFactory;

        public PedidosConfiguradorForm(IWTPostgreNpgsqlConnection conn, string tipoCalculoSemana, string diaCalculoSemana, int qtdThreads, IConfiguradorEASIFactory configuradorEasiFactory)
        {
            InitializeComponent();
            this.conn = conn;
            this.tipoCalculoSemana = tipoCalculoSemana;
            this.diaCalculoSemana = diaCalculoSemana;
            this.qtdThreads = qtdThreads;
            this.configuradorEasiFactory = configuradorEasiFactory;
            //this.initializeGrid();
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

            string whereClause = "";

            if (rdbConfigurado.Checked)
            {
                whereClause += " AND public.pedido_item.pei_configurado = 1 ";
                this.btnConfigurar.Enabled = false;
                this.btnDesfazer.Enabled = true;
            }
            else
            {
                whereClause += " AND public.pedido_item.pei_configurado = 0 ";
                this.btnConfigurar.Enabled = true;
                this.btnDesfazer.Enabled = false;
            }

            if (this.txtBusca.Text.Trim().Length > 0)
            {
                whereClause += " AND (" +
                               " UPPER(pei_numero) LIKE '%" + this.txtBusca.Text.Trim().ToUpper() + "%' OR " +
                               " UPPER(pei_produto_codigo_cliente) LIKE '%" + this.txtBusca.Text.Trim().ToUpper() + "%' OR " +
                               " UPPER(pei_projeto_cliente) LIKE '%" + this.txtBusca.Text.Trim().ToUpper() + "%' OR " +
                               " UPPER(cli_nome_resumido) LIKE '%" + this.txtBusca.Text.Trim().ToUpper() + "%' OR " +
                               " UPPER(clp_identificacao) LIKE '%" + this.txtBusca.Text.Trim().ToUpper() + "%' OR " +
                               " LOWER(pei_numero) LIKE '%" + this.txtBusca.Text.Trim().ToLower() + "%' OR " +
                               " LOWER(pei_produto_codigo_cliente) LIKE '%" + this.txtBusca.Text.Trim().ToLower() + "%' OR " +
                               " LOWER(pei_projeto_cliente) LIKE '%" + this.txtBusca.Text.Trim().ToLower() + "%' OR " +
                               " LOWER(cli_nome_resumido) LIKE '%" + this.txtBusca.Text.Trim().ToLower() + "%' OR " +
                               " LOWER(clp_identificacao) LIKE '%" + this.txtBusca.Text.Trim().ToLower() + "%' " +
                               ") ";
            }

            if (rdbPendentes.Checked)
            {
                BotaoVariaveisPedido.Enabled = true;

                if (chkSuspensos.Checked)
                {
                    whereClause += " AND (pei_status = 0 OR pei_status = 3 OR pei_status = 4) ";
                }
                else
                {
                    whereClause += " AND (pei_status = 0 OR pei_status = 3) ";
                }
            }
            else
            {
                BotaoVariaveisPedido.Enabled = false;
            }

            if (rdbEncerrados.Checked)
            {
                whereClause += " AND (pei_status <> 0 AND pei_status <> 3 AND pei_status <> 4) ";
            }

            if (rdbAtrasados.Checked)
            {
                if (chkSuspensos.Checked)
                {
                    whereClause += " AND (pei_status = 0 OR pei_status = 3 OR pei_status = 4)  AND  pei_data_entrega < CURRENT_DATE ";
                }
                else
                {
                    whereClause += " AND (pei_status = 0 OR pei_status = 3)  AND  pei_data_entrega < CURRENT_DATE ";
                }
                
            }



            string sql =
                "SELECT  " +
                "  public.pedido_item.id_pedido_item, " +
                "  public.pedido_item.pei_data_entrada, " +
                "  public.classificacao_produto.clp_identificacao, " +
                "  public.pedido_item.pei_numero, " +
                "  public.pedido_item.pei_posicao, " +
                "  public.pedido_item.pei_produto_codigo_cliente, " +
                "  public.produto.pro_codigo, "+
                "  public.order_item_etiqueta.oie_dimensao, " +
                "  public.pedido_item.pei_projeto_cliente, " +
                "  public.pedido_item.pei_saldo, " +
                "  public.pedido_item.pei_data_entrega, " +
                "  0 as semana_entrega, " +
                "  public.pedido_item.pei_data_configuracao, " +
                "  public.cliente.cli_nome_resumido, " +
                "  public.cliente.id_cliente, " +
                "  public.familia_cliente.fac_tipo_especial, " +
                "  public.pedido_item.pei_status, " +
                "  feedback.pif_texto, " +
                "  public.pedido_item.pei_suspensao_obs, " +
                "  public.produto.pro_estrutura_em_revisao, " +
                "  public.pedido_item.pei_produto_descricao_cliente, " +
                "  public.produto.pro_descricao,  " +
                "  CASE pei_situacao_gad WHEN 0 THEN 'Sem GAD' WHEN 1 THEN 'Enviado - Ag. Processamento' WHEN 2 THEN 'Em Análise' WHEN 3 THEN 'Liberado' WHEN 4 THEN 'Programado' WHEN 5 THEN 'Cancelado' WHEN 6 THEN 'Erro ao recepcionar pedido' WHEN 7 THEN 'Erro no Pedido' ELSE '' END as situacao_gad, "+
                "  pei_situacao_gad_mensagem, "+
                "  prg_nome "+
                "FROM " +
                "  public.pedido_item " +
                "  INNER JOIN public.cliente ON (public.pedido_item.id_cliente = public.cliente.id_cliente) " +
                "  LEFT JOIN public.familia_cliente ON (public.cliente.id_familia_cliente = public.familia_cliente.id_familia_cliente) " +
                "  LEFT JOIN pedido_kit ON (pedido_kit.pek_oc = pedido_item.pei_numero AND pedido_kit.pek_pos = pedido_item.pei_posicao  AND pedido_item.id_cliente = pedido_kit.id_cliente) " +
                "  LEFT JOIN public.produto ON (public.pedido_item.id_produto = public.produto.id_produto) " +
                "  LEFT JOIN public.classificacao_produto ON (public.produto.id_classificacao_produto = public.classificacao_produto.id_classificacao_produto) " +
                "  LEFT JOIN public.order_item_etiqueta ON pedido_item.id_pedido_item = order_item_etiqueta.id_pedido_item " +
                "  LEFT OUTER JOIN (SELECT * FROM public.pedido_item_feedback f WHERE f.pif_atual = 1) as feedback ON (public.pedido_item.id_pedido_item = feedback.id_pedido_item) " +
                "  LEFT OUTER JOIN programacao ON pedido_item.id_programacao = programacao.id_programacao "+
                "WHERE " +
                "  public.pedido_item.pei_sub_linha = 0 " +
                " " + whereClause + " " +
                "ORDER BY " +
                "  CAST (pei_data_entrada AS DATE) , clp_identificacao, pek_tipo_kit, pei_numero, pei_posicao ";

            IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.conn);
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
                dataGridView1.MultiSelect = true;

                this.dataGridView1.Columns[0].Visible = false;
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[1], "Data Cadastro", 110, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[2], "Classificação", 140, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[3], "Pedido", 120, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[4], "Pos", 50, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[5], "Produto - Cliente", 120, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[6], "Produto - Interno", 120, DataGridViewAutoSizeColumnMode.None, true);
                if (rdbConfigurado.Checked)
                {
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[7], "Dimensão", 80, DataGridViewAutoSizeColumnMode.None, true);
                }
                else
                {
                    this.dataGridView1.Columns[7].Visible = false;
                }
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[8], "Projeto", 120, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[9], "Saldo", 70, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[10], "Data Entrega", 80, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[11], "Semana Entrega", 80, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[12], "Data Configuração", 110, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[13], "Cliente", 80, DataGridViewAutoSizeColumnMode.None, true);
                this.dataGridView1.Columns[14].Visible = false;
                this.dataGridView1.Columns[15].Visible = false;
                this.dataGridView1.Columns[16].Visible = false;
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[17], "Feedback", 350, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[18], "Observação de Suspensão / Retirada de Suspensão", 350, DataGridViewAutoSizeColumnMode.None, true);
                this.dataGridView1.Columns[19].Visible = false;
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[20], "Descrição Produto Cliente", 150, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[21], "Descrição Produto Interna", 150, DataGridViewAutoSizeColumnMode.None, true);

                if (ConfiguraConexaoGad.GadAtivo)
                {
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[22], "Situação GAD", 110, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[23], "Mensagem GAD", 150, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[24], "Programação GAD", 150, DataGridViewAutoSizeColumnMode.None, true);
                }
                else
                {
                    this.dataGridView1.Columns[22].Visible = false;
                    this.dataGridView1.Columns[23].Visible = false;
                    this.dataGridView1.Columns[24].Visible = false;
                }



            }

            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                DateTime dataEntrega = Convert.ToDateTime(row.Cells["pei_data_entrega"].Value);
                int weekNum = IWTFunctions.IWTFunctions.getNumeroSemana(dataEntrega, tipoCalculoSemana, diaCalculoSemana);
                row.Cells["semana_entrega"].Value = Convert.ToInt32(dataEntrega.ToString("yy") + weekNum.ToString().PadLeft(2, '0'));
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

            this.lblQtdPedidos.Text = this.dataGridView1.Rows.Count.ToString();

            this.groupBox2.Visible = this.rdbNaoConfigurados.Checked;

        }

        private void updateSearch()
        {
            try
            {

                this.initializeGrid();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, "Erro ao realizar a busca.\r\n" + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Configurar()
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    string idCliente;
                    string oc = "";
                    int pos = 0;
                    int clienteEspecial;

                    string error = "";

                    string avisos = "";

                    List<ConfiguradorPedido> pedidos = new List<ConfiguradorPedido>();
                    List<ConfiguradorPedido> pedidosSelecionados = new List<ConfiguradorPedido>();
                    foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
                    {
                        try
                        {


                            idCliente = row.Cells["id_cliente"].Value.ToString();
                            oc = row.Cells["pei_numero"].Value.ToString();
                            pos = Convert.ToInt32(row.Cells["pei_posicao"].Value);

                            if (row.Cells["pei_status"].Value.ToString() != "0" && row.Cells["pei_status"].Value.ToString() != "3" && row.Cells["pei_status"].Value.ToString() != "4")
                            {
                                throw new Exception("Não é possível configurar um pedido que não esteja pendente ou reaberto.");
                            }

                            if (IWTConfiguration.Conf.getBoolConf(Constants.TRABALHAR_COM_BLOQUEIO_PRODUTO_POR_PRECO_VENCIDO))
                            {
                                if (row.Cells["id_pedido_item"].Value != null)
                                {
                                    PedidoItemClass pedido = PedidoItemClass.GetEntidade(Convert.ToInt64(row.Cells["id_pedido_item"].Value), LoginClass.UsuarioLogado.loggedUser, SingleConnection);
                                    string produtoBloqueado = pedido.ProdutoCodigoCliente;
                                    if (pedido.ProdutoBloqueioPrecoVencido)
                                    {
                                        throw new Exception("Não é possível configurar um pedido de um produto bloqueado pelo preço vencido, favor desbloquear o produto para continuar. O produto que está bloqueado é o " + produtoBloqueado + ".");
                                    }
                                }
                                
                            }

                            if (row.Cells["fac_tipo_especial"].Value != DBNull.Value)
                            {
                                clienteEspecial = Convert.ToInt32(row.Cells["fac_tipo_especial"].Value);
                            }
                            else
                            {
                                clienteEspecial = 0;
                            }
                            pedidos.Add(new ConfiguradorPedido(oc, pos, idCliente, clienteEspecial, PedidoOrcamento.Pedido, Convert.ToInt32(row.Cells["id_pedido_item"].Value)));
                            pedidosSelecionados.Add(pedidos.Last());
                            //conf.configurarPedido(oc, pos, idCliente, clienteEspecial);
                        }
                        catch (Exception e)
                        {
                            error += "Erro ao configurar o pedido: " + oc + "/" + pos + " - " + e.Message + "\r\n\r\n";
                        }

                    }

                    int qtdThreads = 1;

                    List<IWTPostgreNpgsqlConnection> tmpConn = new List<IWTPostgreNpgsqlConnection>();
                    for (int i = 0; i < qtdThreads; i++)
                    {
                        IWTPostgreNpgsqlConnection tmp = new IWTPostgreNpgsqlConnection(this.conn.ConnectionString);
                        tmp.Open();
                        tmpConn.Add(tmp);

                    }


                    ConfiguradorStatusForm form = new ConfiguradorStatusForm(tmpConn,  this.tipoCalculoSemana,
                        this.diaCalculoSemana, qtdThreads, pedidos, this.configuradorEasiFactory);
                    form.ShowDialog();
                    for (int i = 0; i < qtdThreads; i++)
                    {
                        tmpConn[i].Close();
                    }

                    if (!string.IsNullOrWhiteSpace(form.Avisos))
                    {
                        if (form.Avisos.Length > 1000)
                        {
                            ScrollableMessageBox message = new ScrollableMessageBox(null, "Alguns pedidos geraram avisos.\r\n" + form.Avisos, "Avisos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            message.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show(null, "Alguns pedidos geraram avisos.\r\n" + form.Avisos, "Avisos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    error += form.Error;


                    if (error.Length > 0)
                    {
                        if (error.Length > 1000)
                        {
                            ScrollableMessageBox message = new ScrollableMessageBox(null, "Alguns pedidos não foram configurados.\r\n" + error, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            message.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show(null, "Alguns pedidos não foram configurados.\r\n" + error, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Pedidos Configurados com Sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    this.initializeGrid();

                }
            }
            catch (Exception e)
            {
                this.initializeGrid();
                throw new Exception("Erro ao Configurar o item.\r\n" + e.Message);
            }
        }

  

        private void DesfazerConfiguracao()
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    if (
                        MessageBox.Show(this, "Você tem certeza que deseja desfazer a configuração do item? Caso isso seja realizado todos os dados de acompanhamento, expedição e ops desse pedido serão apagados!", "Desfazer Configuração",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        IConfiguradorEASI conf = this.configuradorEasiFactory.getInstance(this.conn,LoginClass.LogById(LoginClass.UsuarioLogado.loggedUser.ID, conn, true).loggedUser,  this.tipoCalculoSemana, this.diaCalculoSemana);
                        string idCliente;
                        string oc;
                        int pos;
                        int clienteEspecial;
                        foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
                        {


                            idCliente = row.Cells["id_cliente"].Value.ToString();
                            oc = row.Cells["pei_numero"].Value.ToString();
                            pos = Convert.ToInt32(row.Cells["pei_posicao"].Value);

                            if (row.Cells["pei_status"].Value.ToString() != "0" && row.Cells["pei_status"].Value.ToString() != "3")
                            {
                                throw new Exception("Não é possível desconfigurar um pedido que não esteja pendente ou reaberto.");
                            }

                            if (row.Cells["fac_tipo_especial"].Value != DBNull.Value)
                            {
                                clienteEspecial = Convert.ToInt32(row.Cells["fac_tipo_especial"].Value);
                            }
                            else
                            {
                                clienteEspecial = 0;
                            }
                            conf.desconfigurarPedido(oc, pos, idCliente, PedidoOrcamento.Pedido);
                        }
                        this.initializeGrid();

                        MessageBox.Show(this, "Pedidos Desconfigurados com Sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao editar o item.\r\n" + e.Message);
            }
        }

        private void FormatarLinha(int linha, int coluna)
        {
            try
            {
                if (rdbConfigurado.Checked) return;
                if (coluna != 1 && coluna != 8 && coluna != 16)
                {
                    return;
                }

                if (this.dataGridView1.Rows[linha].Cells["pro_estrutura_em_revisao"].Value.ToString() != "1")
                {
                    return;
                }

                //Vermelho
                foreach (DataGridViewCell cell in this.dataGridView1.Rows[linha].Cells)
                {
                    cell.Style.BackColor = Color.Red;
                }
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao formatar as linhas com itens em revisão.\r\n" + e.Message, e);
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

                foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
                {
                    int idPedido = Convert.ToInt32(row.Cells["id_pedido_item"].Value);

                    PedidoItemClass pedido = PedidoItemClass.GetEntidade(idPedido, LoginClass.UsuarioLogado.loggedUser, SingleConnection);
                    if (pedido.Status != StatusPedido.Pendente && pedido.Status != StatusPedido.Reaberto)
                    {
                        throw new Exception("Só é possível incluir feedbacks em pedidos pendentes ou reabertos (" + pedido + ").");
                    }
                    else
                    {
                        pedidos.Add(pedido);
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
                this.initializeGrid();
            }
        }

        private List<string> GetVariaveisDaRegra(string regra, string complemento)
        {
            List<string> vars = new List<string>();
            if (!String.IsNullOrWhiteSpace(regra))
            {
                int inicio = 0;
                bool iniFound = false;

                for (int i = 0; i < regra.Length; i++)
                {
                    if (regra[i] == '$')
                    {
                        if (iniFound)
                        {
                            string varNomeOriginal = regra.Substring(inicio + 1, i - (inicio + 1));
                            vars.Add(varNomeOriginal.ToUpper());

                            iniFound = false;
                        }
                        else
                        {
                            iniFound = true;
                            inicio = i;
                        }
                    }                    
                }
            }
            return vars;
        }

        private List<string> GetVariaveisProdutoEstrutura(ProdutoClass produto)
        {
            List<string> vars = new List<string>();
            string complemento = "";
            foreach (ProdutoMaterialClass material in produto.Materiais)
            {
                complemento = "(" + produto.Codigo + " - " + material.Material.CodigoInterno + ")";
                vars.AddRange(GetVariaveisDaRegra(material.MaterialCondicionalRegra, complemento));
                vars.AddRange(GetVariaveisDaRegra(material.QtdCondicionalRegra, complemento));
            }

            complemento = "("+produto.Codigo+ " - Dimensao)";
            vars.AddRange(GetVariaveisDaRegra(produto.RegraDimensao, complemento));

            complemento = "(" + produto.Codigo + " - Regra Validação 1)";
            vars.AddRange(GetVariaveisDaRegra(produto.RegraValidVar1, complemento));

            complemento = "(" + produto.Codigo + " - Regra Validação 2)";
            vars.AddRange(GetVariaveisDaRegra(produto.RegraValidVar2, complemento));

            complemento = "(" + produto.Codigo + " - Regra Validação 3)";
            vars.AddRange(GetVariaveisDaRegra(produto.RegraValidVar3, complemento));

            complemento = "(" + produto.Codigo + " - Regra Validação 4)";
            vars.AddRange(GetVariaveisDaRegra(produto.RegraValidVar4, complemento));

            foreach (ProdutoPaiFilhoClass paiFilho in produto.Filhos)
            {
                complemento = "(" + produto.Codigo + " - "+ paiFilho.codigoFilho + ")";
                vars.AddRange(GetVariaveisDaRegra(paiFilho.FilhoCondicionalRegra, complemento));
                vars.AddRange(GetVariaveisDaRegra(paiFilho.QtdCondicionalRegra, complemento));

                vars.AddRange(GetVariaveisProdutoEstrutura(paiFilho.ProdutoFilho));
            }

            return vars;
        }

        private void VerificarVariaveisConfiguracao()
        {
            List<string> vars = new List<string>();

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                int idPedido = Convert.ToInt32(row.Cells["id_pedido_item"].Value);

                PedidoItemClass pedido = PedidoItemClass.GetEntidade(idPedido, LoginClass.UsuarioLogado.loggedUser, SingleConnection);

                if (pedido.Status != StatusPedido.Pendente && pedido.Status != StatusPedido.Reaberto)
                {
                    //ignora
                }
                else
                {
                    vars.AddRange(GetVariaveisProdutoEstrutura(pedido.Produto)); 
                }
            }

            vars= vars.GroupBy(x => x).Select(y => y.FirstOrDefault()).OrderBy(a => a).ToList();            

            string listaVars = vars.Aggregate((i, j) => i + Environment.NewLine + j);
            ScrollableMessageBox messageBox = new ScrollableMessageBox(this, listaVars, "Variáveis dos pedidos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            messageBox.ShowDialog();
        }



        #region Eventos

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.timerBusca.Stop();
                this.timerBusca.Start();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.updateSearch();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.updateSearch();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timerBusca_Tick(object sender, EventArgs e)
        {
            try
            {
                this.timerBusca.Enabled = false;
                this.updateSearch();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfigurar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Configurar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDesfazer_Click(object sender, EventArgs e)
        {
            try
            {
                this.DesfazerConfiguracao();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void rdbPendentes_CheckedChanged(object sender, EventArgs e)
        {
            this.initializeGrid();
            this.chkSuspensos.Enabled = this.rdbPendentes.Checked || this.rdbAtrasados.Checked;
        }

        private void rdbEncerrados_CheckedChanged(object sender, EventArgs e)
        {
            this.initializeGrid();
        }

        private void rdbTodos_CheckedChanged(object sender, EventArgs e)
        {
            this.initializeGrid();
        }



        private void PedidosConfiguradorForm_Shown(object sender, EventArgs e)
        {
            try
            {
                this.initializeGrid();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                this.FormatarLinha(e.RowIndex, e.ColumnIndex);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void chkSuspensos_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.initializeGrid();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

     
        private void chkSuspensos_EnabledChanged(object sender, EventArgs e)
        {
            try
            {
                this.initializeGrid();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbAtrasados_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.initializeGrid();
                this.chkSuspensos.Enabled = this.rdbPendentes.Checked || this.rdbAtrasados.Checked;
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFeedback_Click(object sender, EventArgs e)
        {
              try
              {
                  this.NovoFeedback();
              }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                VerificarVariaveisConfiguracao();
            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, a.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        #endregion

        private void BotaoVariaveisPedido_Click(object sender, EventArgs e)
        {
            try
            {
                abrirVariaveisPedido();
            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, a.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void abrirVariaveisPedido()
        {
            if (this.dataGridView1.SelectedRows.Count == 1)
            {

                if (this.dataGridView1.SelectedRows[0] != null)
                {
                    int idPedido = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells["id_pedido_item"].Value);

                    PedidoItemClass pedido = PedidoItemClass.GetEntidade(idPedido, LoginClass.UsuarioLogado.loggedUser, SingleConnection);

                    if (pedido == null)
                    {
                        throw new ExcecaoTratada("Erro ao buscar as variáveis, nenhum registro de pedido foi encontrado para o id ." + this.dataGridView1.SelectedRows[0].Cells["id_pedido_item"].Value);
                    }

                    CadPedidoItemVariavelListForm form = new CadPedidoItemVariavelListForm(pedido);
                    form.ShowDialog();
                }
            }
            else
            {
                throw new ExcecaoTratada("Erro ao buscar as variáveis, mais de um pedido foi selecionado.");
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                onChangeSelectedRows();
            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, a.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void onChangeSelectedRows()
        {
            if (this.dataGridView1.SelectedRows.Count > 1)
            {
                BotaoVariaveisPedido.Enabled = false;
            }
            else if (rdbPendentes.Checked)
            {
                BotaoVariaveisPedido.Enabled = true;
            }
        }
    }
}
