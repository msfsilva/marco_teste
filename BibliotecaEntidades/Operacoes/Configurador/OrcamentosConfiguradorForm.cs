using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaTributos;
using IWTDotNetLib.ComplexLoginModule;
using IWTCustomControls;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Operacoes.Configurador
{
    public partial class OrcamentosConfiguradorForm : IWTBaseForm
    {
        readonly IWTPostgreNpgsqlConnection conn;
        BindingSource binding;
        readonly string tipoCalculoSemana;
        readonly string diaCalculoSemana;
        readonly int qtdThreads;
        private IConfiguradorEASIFactory configuradorEasiFactory;

        public OrcamentosConfiguradorForm(IWTPostgreNpgsqlConnection conn, string tipoCalculoSemana, string diaCalculoSemana, int qtdThreads, IConfiguradorEASIFactory configuradorEasiFactory)
        {
            InitializeComponent();
            this.conn = conn;
            
            this.tipoCalculoSemana = tipoCalculoSemana;
            this.diaCalculoSemana = diaCalculoSemana;
            this.qtdThreads = qtdThreads;
            this.configuradorEasiFactory = configuradorEasiFactory;
            this.initializeGrid();
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
                whereClause += " AND public.orcamento_item.ori_configurado = 1 ";
                this.btnConfigurar.Enabled = false;
                this.btnDesfazer.Enabled = true;
            }
            else
            {
                whereClause += " AND public.orcamento_item.ori_configurado = 0 ";
                this.btnConfigurar.Enabled = true;
                this.btnDesfazer.Enabled = false;
            }

            if (this.txtBusca.Text.Trim().Length > 0)
            {
                whereClause += " AND (ori_numero LIKE '%" + this.txtBusca.Text.Trim() + "%' OR " +
                    " ori_produto_codigo_cliente LIKE '%" + this.txtBusca.Text.Trim() + "%' OR " +
                    " ori_projeto_cliente LIKE '%" + this.txtBusca.Text.Trim() + "%' OR " +
                    " cli_nome_resumido LIKE '%" + this.txtBusca.Text.Trim() + "%' OR " +
                    " clp_identificacao LIKE '%" + this.txtBusca.Text.Trim() + "%' " +
                    ") ";
            }

            if (rdbPendentes.Checked)
            {
                whereClause += " AND (ori_status = 0) ";
            }

            if (rdbAprovados.Checked)
            {
                whereClause += " AND (ori_status =1 ) ";
            }



            string sql =
                "SELECT  " +
                "  public.orcamento_item.id_orcamento_item, " +
                "  public.orcamento_item.ori_data_entrada, " +
                "  public.classificacao_produto.clp_identificacao, " +
                "  public.orcamento_item.ori_numero, " +
                "  public.orcamento_item.ori_posicao, " +
                "  public.orcamento_item.ori_produto_codigo_cliente, " +
                "  public.orcamento_configurado.orc_dimensao, " +
                "  public.orcamento_item.ori_projeto_cliente, " +
                "  public.orcamento_item.ori_quantidade, " +
                "  public.orcamento_item.ori_data_entrega, " +
                "  public.orcamento_item.ori_data_configuracao, " +
                "  public.cliente.cli_nome_resumido, " +
                "  public.cliente.id_cliente, " +
                "  public.familia_cliente.fac_tipo_especial, " +
                "  public.orcamento_item.ori_status " +
                "FROM " +
                "  public.orcamento_item " +
                "  INNER JOIN public.cliente ON (public.orcamento_item.id_cliente = public.cliente.id_cliente) " +
                "  LEFT JOIN public.familia_cliente ON (public.cliente.id_familia_cliente = public.familia_cliente.id_familia_cliente) " +
                "  LEFT JOIN orcamento_kit ON (orcamento_kit.ork_oc = orcamento_item.ori_numero AND orcamento_kit.ork_pos = orcamento_item.ori_posicao  AND orcamento_item.id_cliente = orcamento_kit.id_cliente) " +
                "  LEFT JOIN public.produto ON (public.orcamento_item.id_produto = public.produto.id_produto) " +
                "  LEFT JOIN public.classificacao_produto ON (public.produto.id_classificacao_produto = public.classificacao_produto.id_classificacao_produto) " +
                "  LEFT JOIN public.orcamento_configurado ON orcamento_item.id_orcamento_item = orcamento_configurado.id_orcamento_item " +
                "WHERE " +
                "  public.orcamento_item.ori_sub_linha = 0 " +
                " " + whereClause + " " +
                "ORDER BY " +
                "  CAST (ori_data_entrada AS DATE) , clp_identificacao, ork_tipo_kit, ori_numero, ori_posicao ";

            IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.conn);
            
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
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[5], "Produto", 120, DataGridViewAutoSizeColumnMode.None, true);
                if (rdbConfigurado.Checked)
                {
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[6], "Dimensão", 80, DataGridViewAutoSizeColumnMode.None, true);
                }
                else
                {
                    this.dataGridView1.Columns[6].Visible = false;
                }
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[7], "Projeto", 120, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[8], "Quantidade", 70, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[9], "Data Entrega", 80, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[10], "Data Configuração", 110, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[11], "Cliente", 80, DataGridViewAutoSizeColumnMode.None, true);
                this.dataGridView1.Columns[12].Visible = false;
                this.dataGridView1.Columns[13].Visible = false;
                this.dataGridView1.Columns[14].Visible = false;

            

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

                    List<ConfiguradorPedido> orcamentos = new List<ConfiguradorPedido>();
                    foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
                    {
                        try
                        {


                            idCliente = row.Cells["id_cliente"].Value.ToString();
                            oc = row.Cells["ori_numero"].Value.ToString();
                            pos = Convert.ToInt32(row.Cells["ori_posicao"].Value);

                            if (row.Cells["ori_status"].Value.ToString() != "0")
                            {
                                throw new Exception("Não é possível configurar um orçamento que não esteja pendente");
                            }

                            if (row.Cells["fac_tipo_especial"].Value != DBNull.Value)
                            {
                                clienteEspecial = Convert.ToInt32(row.Cells["fac_tipo_especial"].Value);
                            }
                            else
                            {
                                clienteEspecial = 0;
                            }
                            orcamentos.Add(new ConfiguradorPedido(oc, pos, idCliente, clienteEspecial, PedidoOrcamento.Orcamento, Convert.ToInt32(row.Cells["id_orcamento_item"].Value)));
                        }
                        catch (Exception e)
                        {
                            error += "Erro ao configurar o orçamento: " + oc + "/" + pos + " - " + e.Message + "\r\n\r\n";
                        }

                    }

                    

                    //int qtdThreads = 4;

                    if (orcamentos.Count > 0)
                    {

                        List<IWTPostgreNpgsqlConnection> tmpConn = new List<IWTPostgreNpgsqlConnection>();
                        for (int i = 0; i < qtdThreads; i++)
                        {
                            IWTPostgreNpgsqlConnection tmp = new IWTPostgreNpgsqlConnection(this.conn.ConnectionString);
                            tmp.Open();
                            tmpConn.Add(tmp);

                        }


                        ConfiguradorStatusForm form = new ConfiguradorStatusForm(tmpConn, this.tipoCalculoSemana,
                            this.diaCalculoSemana, qtdThreads, orcamentos, this.configuradorEasiFactory);
                        form.ShowDialog();
                        for (int i = 0; i < qtdThreads; i++)
                        {
                            tmpConn[i].Close();
                        }


                        error += form.Error;
                    }

                    if (error.Length > 0)
                    {
                        if (error.Length > 1000)
                        {
                            ScrollableMessageBox message = new ScrollableMessageBox(null, "Alguns orçamentos não foram configurados.\r\n" + error, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            message.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show(null, "Alguns orçamentos não foram configurados.\r\n" + error, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Orçamentos Configurados com Sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    if (MessageBox.Show(this, "Você tem certeza que deseja desfazer a configuração do item? Caso isso seja realizado todos os dados de acompanhamento, expedição e ops desse orcamento serão apagados!", "Desfazer Configuração", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        IConfiguradorEASI conf = this.configuradorEasiFactory.getInstance(this.conn, (AcsUsuarioClass) LoginClass.LogById(LoginClass.UsuarioLogado.loggedUser.ID, conn, true).loggedUser, this.tipoCalculoSemana, this.diaCalculoSemana);
                        string idCliente;
                        string oc;
                        int pos;
                        int clienteEspecial;
                        foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
                        {


                            idCliente = row.Cells["id_cliente"].Value.ToString();
                            oc = row.Cells["ori_numero"].Value.ToString();
                            pos = Convert.ToInt32(row.Cells["ori_posicao"].Value);

                            if (row.Cells["ori_status"].Value.ToString() != "0")
                            {
                                throw new Exception("Não é possível desconfigurar um orçamento que não esteja pendente.");
                            }

                            if (row.Cells["fac_tipo_especial"].Value != DBNull.Value)
                            {
                                clienteEspecial = Convert.ToInt32(row.Cells["fac_tipo_especial"].Value);
                            }
                            else
                            {
                                clienteEspecial = 0;
                            }
                            conf.desconfigurarPedido(oc, pos, idCliente, PedidoOrcamento.Orcamento);
                        }
                        this.initializeGrid();

                        MessageBox.Show(this, "Orçamentos Desconfigurados com Sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao desconfigurar o item.\r\n" + e.Message);
            }
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


        private void timerBusca_Tick(object sender, EventArgs e)
        {
            try
            {
                this.timerBusca.Enabled = false;
                this.initializeGrid();
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
        }

        private void Aprovados_CheckedChanged(object sender, EventArgs e)
        {
            this.initializeGrid();
        }

        private void rdbTodos_CheckedChanged(object sender, EventArgs e)
        {
            this.initializeGrid();
        }




        private void rdbConfigurado_CheckedChanged(object sender, EventArgs e)
        {
            this.initializeGrid();
        }

        private void rdbNaoConfigurados_CheckedChanged(object sender, EventArgs e)
        {
            this.initializeGrid();
        }


        #endregion
    }
}
