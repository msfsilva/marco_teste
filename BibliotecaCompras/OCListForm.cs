#region Referencias

using System;
using System.Data;
using System.Windows.Forms;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Operacoes.Compras;

using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;
using ProjectConstants;
using dbProvider;

#endregion

namespace BibliotecaCompras
{
    public partial class OCListForm : IWTBaseForm
    {
        private readonly bool _somenteVisualizacao;

        BindingSource binding;


        private readonly int diasVerde;
        private readonly int diasAmarelo;
        private readonly int diasVermelho;
        private readonly int mesesMedia;
        private readonly double categoriaAAcimaDe;
        private readonly double categoriaBAcimaDe;
        private readonly double margemAvisoKB;

        private readonly int leadtimePCP;
        private readonly int leadtimeCompras;
        private readonly double sugeridoAcimaCompras;
        private readonly double disparoSolicitacaoAuto;
        readonly string tipoCalculoSemana;
        readonly string diaCalculoSemana;


        public OCListForm(bool somenteVisualizacao = false)
        {
            _somenteVisualizacao = somenteVisualizacao;
            InitializeComponent();





            this.diasVerde = Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_DIAS_VERDE));
            this.diasAmarelo = Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_DIAS_AMARELO));
            this.diasVermelho = Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_DIAS_VERMELHO));
            this.mesesMedia = Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_N_MESES_MEDIA));
            this.categoriaAAcimaDe = Convert.ToDouble(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_CLASSIFICACAO_A));
            this.categoriaBAcimaDe = Convert.ToDouble(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_CLASSIFICACAO_B));
            this.margemAvisoKB = Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_MARGEM_REVISAO_KB));

            this.leadtimePCP = Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.DIAS_PROGRAMACAO_PCP));
            this.leadtimeCompras = Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.DIAS_PROGRAMACAO_COMPRAS));
            this.sugeridoAcimaCompras = Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_MARGEM_REVISAO_KB));
            this.disparoSolicitacaoAuto = Convert.ToDouble(IWTConfiguration.Conf.getConf(Constants.SUGESTAO_ACIMA_CONFIGURADO));

            this.tipoCalculoSemana = IWTConfiguration.Conf.getConf(Constants.SEMANA_TIPO_DEFINICAO);
            this.diaCalculoSemana = IWTConfiguration.Conf.getConf(Constants.SEMANA_DIA);


            this.initializeGrid();

            if (somenteVisualizacao)
            {
                btnCancelar.Visible = false;
                btnEditar.Visible = false;
                btnEnviar.Visible = false;
                btnExcluir.Visible = false;
                btnNovo.Visible = false;
            }

            if (IWTConfiguration.Conf.getBoolConf(ProjectConstants.Constants.SIMULADOR_COMPRAS_HABILITADO))
            {
                btnNovo.Visible = false;
            }
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

            string filter = "";
            if (this.txtBusca.Text.Trim().Length > 0)
            {
                filter += " AND ( "+
                    " aus_login ILIKE '%" + this.txtBusca.Text.Trim() + "%' " +
                    " OR for_nome_fantasia ILIKE '%" + this.txtBusca.Text.Trim() + "%'" +
                    " OR com_apelido ILIKE '%" + this.txtBusca.Text.Trim() + "%'" +
                    ") ";
            }

            if (this.nudIdOC.Enabled)
            {
                filter += " AND ( " +
                                " id_ordem_compra = " + this.nudIdOC.Value.ToString() + " " +
                              ") ";
            }


            string filterStatus = "";
            if (this.chkNovas.Checked)
            {
                filterStatus += " OR orc_status = 0 ";
            }

            if (this.chkCompradas.Checked)
            {
                filterStatus += " OR orc_status = 1 ";
            }

            if (this.chkRecebidasParcial.Checked)
            {
                filterStatus += " OR orc_status = 2 ";
            }

            if (this.chkRecebidas.Checked)
            {
                filterStatus += " OR orc_status = 3 ";
            }

            if (this.chkCanceladas.Checked)
            {
                filterStatus += " OR orc_status = 4 ";
            }

            if (this.chkAguardandoAprovacao.Checked)
            {
                filterStatus += " OR orc_status = 5 ";
            }


            if (filterStatus.Length > 0)
            {
                filter += " AND (" + filterStatus.Substring(3) + ") ";
            }


            if (filter.Length > 0)
            {
                filter = " WHERE " + filter.Substring(4);
            }

            string sql =
            "SELECT                                                                                                                      " +
            "  public.ordem_compra.id_ordem_compra,                                                                                      " +
            "  public.ordem_compra.orc_data,                                                                                             " +
            "  public.ordem_compra.orc_valor,                                                                                            " +
            "  CASE ordem_compra.orc_status WHEN 0 THEN 'Não Enviadas' WHEN 1 THEN 'Enviada' WHEN 2 THEN 'Recebida parcial' WHEN 3 THEN 'Recebida' WHEN 4 THEN 'Cancelada' WHEN 5 THEN 'Aguardando Aprovação' ELSE '' END AS status, " +
            "  orc_justificativa_cancelamento, " +
            "  public.fornecedor.for_nome_fantasia,                                                                                      " +
            "  public.comprador.com_apelido, " +
            "  public.acs_usuario.aus_login,                                                                                             " +
            "  ordem_compra.orc_status,                                                                                                  " +
            "  public.ordem_compra.orc_desconto_p,                                                                                       " +
            "  public.ordem_compra.orc_desconto_r                                                                                        " +
            "FROM                                                                                                                        " +
            "  public.ordem_compra                                                                                                       " +
            "  INNER JOIN public.fornecedor ON (public.ordem_compra.id_fornecedor = public.fornecedor.id_fornecedor)                     " +
            "  INNER JOIN public.acs_usuario ON (public.ordem_compra.id_acs_usuario = public.acs_usuario.id_acs_usuario)             " +
            "  LEFT OUTER JOIN public.comprador ON (public.ordem_compra.id_comprador = public.comprador.id_comprador) "+ 
            filter +
            "ORDER BY " +
            "  ordem_compra.id_ordem_compra ";

            IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, DbConnection.Connection);
            if (adapter != null)
            {
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                DataTable dt = ds.Tables[0];

                DataColumn valorComDescontoColumn = new DataColumn("ValorComDesconto", typeof(decimal));
                dt.Columns.Add(valorComDescontoColumn);
                valorComDescontoColumn.SetOrdinal(2);
                
                foreach (DataRow row in dt.Rows)
                {
                    double valorComDesconto = 0;

                    double valor = (double)row["orc_valor"];
                    double descontoP = row["orc_desconto_p"] != DBNull.Value ? (double)row["orc_desconto_p"] : 0;
                    double descontoR = row["orc_desconto_r"] != DBNull.Value ? (double)row["orc_desconto_r"] : 0;


                    valorComDesconto = valor;

                    if (descontoP > 0)
                    {
                        double desconto = descontoP / 100;

                        Double? valorTotal = (valor * (1 - desconto));

                        if (valorTotal.HasValue)
                        {
                            valorComDesconto = valorTotal.Value;
                        }

                    }

                    else if (descontoR > 0)
                    {
                        Double? valorTotal = valor - descontoR;

                        if (valorTotal.HasValue)
                        {
                            valorComDesconto = valorTotal.Value;
                        }

                    }

                    row["ValorComDesconto"] = Math.Round(valorComDesconto, 2);
                }

                dt.Columns.Remove("orc_valor");
                dt.Columns.Remove("orc_desconto_p");
                dt.Columns.Remove("orc_desconto_r");

                binding = new BindingSource();
                binding.DataSource = dt;
                binding.Filter = atualFilter;
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = binding;

                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.MultiSelect = true;

               
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[0], "N° da OC", 80, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[1], "Data", 120, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[2], "Valor Total com Desconto", 100, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[3], "Status", 100, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[4], "Justificativa", 100, DataGridViewAutoSizeColumnMode.None, this.chkCanceladas.Checked);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[5], "Fornecedor", 120, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[6], "Comprador", 100, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[7], "Responsável", 120, DataGridViewAutoSizeColumnMode.None, true);
                this.dataGridView1.Columns[8].Visible = false;
                this.dataGridView1.Columns[2].DefaultCellStyle.Format = "C2";
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

        private string getSiglaUF(int id)
        {
            try
            {
                IWTPostgreNpgsqlCommand cmd = DbConnection.Connection.CreateCommand();
                cmd.CommandText = "SELECT est_sigla FROM estado WHERE id_estado = " + id.ToString();
                IWTPostgreNpgsqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                string uf = rd["est_sigla"].ToString();
                rd.Close();

                return uf;
            }
            catch (Exception a)
            {
                throw new Exception("Erro ao buscar sigla do estado do solicitante. \r\n" + a.Message);
            }
        }

        private void Novo()
        {
            try
            {          
                OCForm f = new OCForm(this.getComprador());
                f.ShowDialog();               
                this.initializeGrid();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao cadastrar um novo item.\r\n" + e.Message);
            }
        }

        private void Excluir()
        {
            IWTPostgreNpgsqlCommand command = DbConnection.Connection.CreateCommand();
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    if (Convert.ToInt16(this.dataGridView1.SelectedRows[0].Cells["orc_status"].Value) == 0)
                    {
                        if (
                            MessageBox.Show(this, "Você deseja Excluir a OC selecionada?", "Exclusão",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int id = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells["id_ordem_compra"].Value);

                            command.Transaction = command.Connection.BeginTransaction();

                            OrdemCompraClass oc = new OrdemCompraClass(id, ref command, LoginClass.UsuarioLogado.loggedUser, true);
                            foreach (SolicitacaoCompraClass solicitacaoCompraClass in oc.Solicitacoes.Values)
                            {
                                solicitacaoCompraClass.removerOC();
                                solicitacaoCompraClass.Save(ref command, null, true);
                            }


                            command.CommandText =
                                "DELETE FROM  " +
                                "  public.ordem_compra  " +
                                "WHERE  " +
                                "  id_ordem_compra = :id_ordem_compra " +
                                "; ";
                            command.Parameters.Clear();
                            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_compra",
                                                                                        NpgsqlDbType.Integer));
                            command.Parameters[command.Parameters.Count - 1].Value = id;

                            command.ExecuteNonQuery();

                            command.Transaction.Commit();


                            this.initializeGrid();
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        throw new Exception("Não é possivel excluir uma OC com status : " +
                                            this.dataGridView1.SelectedRows[0].Cells["status"].Value.ToString().ToUpper());
                    }
                }
                else
                {
                    throw new Exception("Selecione a linha que você deseja excluir.");
                }
            }
            catch (Exception e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                throw new Exception("Erro ao excluir o item selecionado.\r\n" + e.Message);
            }
        }

        private void VisualizarOC()
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int? id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id_ordem_compra"].Value);
                    IWTPostgreNpgsqlCommand command = DbConnection.Connection.CreateCommand();

                    byte[] logoEmpresa = IWTConfiguration.Conf.getBinaryConf(Constants.LOGO_EMPRESA);

                    OcReportForm rep = new OcReportForm(ref command, id, logoEmpresa, null, "");
                    rep.ShowDialog();
                }
            }
            catch (Exception s)
            {
                throw new Exception("Erro ao imprimir OC. \r\n" + s.Message);
            }   
        }


        private void Cancelar()
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                command = DbConnection.Connection.CreateCommand();
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    if (this.dataGridView1.SelectedRows[0].Cells["orc_status"].Value.ToString() == "3")
                    {
                        throw new Exception("A OC ja foi recebida.");
                    }

                    if (this.dataGridView1.SelectedRows[0].Cells["orc_status"].Value.ToString() == "2")
                    {
                        throw new Exception("A OC ja foi recebida parcialmente, cancele o saldo através da tela de \"Solicitações de compra com Saldo dentro da Margem de encerramento\" ao invés de cancelar a OC inteira.");
                    }

                    if (MessageBox.Show(this, "Essa operação irá CANCELAR a Ordem de compra e todas as solicitações de compra dela, você deseja cancelar a OC selecionada?", "Cancelamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells["id_ordem_compra"].Value);

                        OCCancelamentoForm form = new OCCancelamentoForm(id.ToString());
                        form.ShowDialog();
                        if (form.Confirmar)
                        {

                            command.Transaction = command.Connection.BeginTransaction();
                            OrdemCompraClass oc = new OrdemCompraClass(id, ref command, LoginClass.UsuarioLogado.loggedUser, true);
                            oc.Cancelar(form.Justificativa);
                            oc.Salvar(ref command);

                            command.Transaction.Commit();
                        }
                        this.initializeGrid();

                    }
                    else
                    {
                        return;
                    }

                }
                else
                {
                    throw new Exception("Selecione a linha que você deseja cancelar.");
                }
            }
            catch (Exception e)
            {

                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                
                throw new Exception("Erro ao Cancelar OC.\r\n" + e.Message, e);
            }

        }

        private void Enviar()
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {

                    if (MessageBox.Show(this, "Você deseja marcar a OC selecionada como enviada?", "Envio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells["id_ordem_compra"].Value);

                        StatusOrdemCompra status = (StatusOrdemCompra)Enum.ToObject(typeof(StatusOrdemCompra), dataGridView1.SelectedRows[0].Cells["orc_status"].Value);

                        if (status == StatusOrdemCompra.AguardandoAprovacaoCompras)
                        {
                            throw new ExcecaoTratada("Não é possível fazer o envio de uma OC aguardando aprovação");
                        }

                        command = DbConnection.Connection.CreateCommand();
                        command.Transaction = command.Connection.BeginTransaction();
                        OrdemCompraClass oc = new OrdemCompraClass(id, ref command, LoginClass.UsuarioLogado.loggedUser,true);
                        oc.setEnviada();
                        oc.Salvar(ref command);

                        command.Transaction.Commit();

                        this.initializeGrid();
                    }
                    else
                    {
                        return;
                    }

                }
                else
                {
                    throw new Exception("Selecione a linha que você deseja enviar.");
                }
            }
            catch (Exception e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                throw new Exception("Erro ao enviar o item selecionado.\r\n" + e.Message);
            }
        }

        private void verSolicitacoes()
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int? id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id_ordem_compra"].Value);

                    SolicitacaoCompraListForm form = new SolicitacaoCompraListForm(
                        this.diasVerde,
                        this.diasAmarelo,
                        this.diasVermelho,
                        this.mesesMedia,
                        this.categoriaAAcimaDe,
                        this.categoriaBAcimaDe,
                        this.margemAvisoKB,
                        this.leadtimePCP,
                        this.leadtimeCompras,
                        this.sugeridoAcimaCompras,
                        this.disparoSolicitacaoAuto,
                        this.tipoCalculoSemana,
                        this.diaCalculoSemana,
                        TipoTelaSolicitacao.Todos,
                        id,
                        DbConnection.Connection,
                        LoginClass.UsuarioLogado.loggedUser);

                    form.ShowDialog();
                }
            }
            catch (Exception s)
            {
                throw new Exception("Erro ao visualizar as solicitações da OC. \r\n" + s.Message);
            }   
        }

        private int getComprador()
        {
            try
            {
                //Identifica o comprador que está sendo utilizado
                IWTPostgreNpgsqlCommand command = DbConnection.Connection.CreateCommand();
                command.CommandText =
                "SELECT  " +
                "  public.comprador.id_comprador " +
                "FROM " +
                "  public.comprador " +
                "WHERE " +
                "  public.comprador.id_acs_usuario = " + LoginClass.UsuarioLogado.loggedUser.ID + " ";
                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                int? idComprador = null;
                bool variosCompradores = false;

                if (!read.HasRows)
                {
                    throw new Exception("Você não possui nenhum comprador cadastrado. Cadastre um comprador antes de continuar.");
                }

                while (read.Read())
                {
                    if (idComprador != null)
                    {
                        variosCompradores = true;
                        break;
                    }
                    idComprador = Convert.ToInt32(read["id_comprador"]);
                }
                read.Close();

                if (variosCompradores)
                {
                    SelecaoCompradorForm form = new SelecaoCompradorForm();
                    form.ShowDialog();
                    idComprador = form.CompradorSelecionado;
                }

                if (idComprador != null) return idComprador.Value;
                throw new Exception("O Comprador não foi identificado.");
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao identificar o comprador.\r\n" + e.Message, e);
            }
        }

        private void Editar()
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id_ordem_compra"].Value);

                    StatusOrdemCompra status = (StatusOrdemCompra) Enum.ToObject(typeof(StatusOrdemCompra), dataGridView1.SelectedRows[0].Cells["orc_status"].Value);

                    if (status!= StatusOrdemCompra.AguardandoAprovacaoCompras && status!= StatusOrdemCompra.Nova &&
                        status != StatusOrdemCompra.Enviada && status != StatusOrdemCompra.RecebidaParcial)
                    {
                        throw new Exception("Só é possível editar uma OC antes de ser enviada");
                    }

                    OCEditForm form = new OCEditForm(id);
                    form.ShowDialog();

                    this.initializeGrid();
                }
            }
            catch (Exception s)
            {
                throw new Exception("Erro ao ediar a OC. \r\n" + s.Message);
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

        private void btnNovo_Click(object sender, EventArgs e)
        {
            try
            {
                this.Novo();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                this.Excluir();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            try
            {
                this.VisualizarOC();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cancelar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Enviar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkNovas_CheckedChanged(object sender, EventArgs e)
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

        private void chkCompradas_CheckedChanged(object sender, EventArgs e)
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

        private void chkRecebidasParcial_CheckedChanged(object sender, EventArgs e)
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

        private void chkRecebidas_CheckedChanged(object sender, EventArgs e)
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

        private void chkCanceladas_CheckedChanged(object sender, EventArgs e)
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

        private void nudIdOC_ValueChanged(object sender, EventArgs e)
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

        private void chkIdOC_CheckedChanged(object sender, EventArgs e)
        {
            
            try
            {
                this.nudIdOC.Enabled = this.chkIdOC.Checked;
                this.initializeGrid();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!_somenteVisualizacao)
                {
                    this.verSolicitacoes();
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Editar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void chkAguardandoAprovacao_CheckedChanged(object sender, EventArgs e)
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







        #endregion


    }
}
