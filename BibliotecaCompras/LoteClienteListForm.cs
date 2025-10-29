#region Referencias

using System;
using System.Data;
using System.Windows.Forms;
using BibliotecaCadastrosBasicos;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Operacoes.Compras;
using BibliotecaEntidades.Operacoes.OrdemProducao;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

#endregion

namespace BibliotecaCompras
{
    public partial class LoteClienteListForm : IWTBaseForm
    {
        readonly IWTPostgreNpgsqlConnection conn;
        BindingSource binding;
        readonly TipoForm Tipo;
        readonly AcsUsuarioClass Usuario;
        readonly string internalLabelPrinter;
        readonly string internalLabelPaper;

        public LoteClienteListForm(string internalLabelPrinter, string internalLabelPaper, TipoForm Tipo, AcsUsuarioClass Usuario, IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            this.Usuario = Usuario;
            this.Tipo = Tipo;
            this.internalLabelPaper = internalLabelPaper;
            this.internalLabelPrinter = internalLabelPrinter;
            this.initializeGrid();


            if (this.Tipo == TipoForm.Expedicao)
            {
                this.btnCancelar.Enabled = false;
                this.btnForcarEncerramento.Enabled = false;
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


            #region Filtro

            string filter = "";
            if (this.txtBusca.Text.Trim().Length > 0)
            {
                filter += " AND ( " +
                          " cli_nome_resumido LIKE '%" + this.txtBusca.Text.Trim() + "%' " +
                          " OR lot_numero LIKE '%" + this.txtBusca.Text.Trim() + "%' " +
                          " OR lot_nf_numero LIKE '%" + this.txtBusca.Text.Trim() + "%' " +
                          " OR " +
                          "  CASE  " +
                          "    WHEN material.id_material IS NOT NULL " +
                          "      THEN public.familia_material.fam_codigo || public.material.mat_codigo " +
                          "    ELSE  pro_codigo " +
                          "  END LIKE '%" + this.txtBusca.Text.Trim() + "%' " +
                          " ) ";
            }


            if (this.rdbAbertos.Checked)
            {
                filter += " AND ( lot_situacao = 0 ) ";
            }

            if (this.rdbEncerrados.Checked)
            {
                filter += " AND ( lot_situacao = 1 ) ";
            }

            if (this.rdbCancelados.Checked)
            {
                filter += " AND ( lot_situacao = 2 ) ";
            }


            #endregion

            string sql =
                "SELECT  " +
                "  public.lote.id_lote, " +
                "  public.cliente.cli_nome_resumido, " +
                "  CASE  " +
                "    WHEN material.id_material IS NOT NULL " +
                "      THEN public.familia_material.fam_codigo || public.material.mat_codigo " +
                "    ELSE  pro_codigo " +
                "  END AS codigo, " +
                "  public.lote.lot_numero, " +
                "  public.lote.lot_nf_numero, " +
                "  public.lote.lot_qtd, " +
                "  public.lote.lot_data_recebimento, " +
                "  public.lote.lot_saldo_devolucao, " +
                "  CASE public.lote.lot_situacao WHEN 0 THEN 'Em Aberto' WHEN 1 THEN 'Encerrado' WHEN 2 THEN 'Cancelado' END as situacao, " +
                "  public.lote.lot_situacao " +
                "FROM " +
                "  public.lote " +
                "  INNER JOIN public.cliente ON (public.lote.id_cliente = public.cliente.id_cliente) " +
                "  LEFT OUTER JOIN public.material ON (public.lote.id_material = public.material.id_material) " +
                "  LEFT OUTER JOIN public.familia_material ON (public.material.id_familia_material = public.familia_material.id_familia_material) " +
                "  LEFT OUTER JOIN public.produto ON (public.lote.id_produto = public.produto.id_produto) " +
                "WHERE " +
                "  public.lote.id_cliente IS NOT NULL " +
                filter +
                "ORDER BY " +
                "  public.lote.lot_numero ";

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
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[1], "Cliente", 80, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[2], "Produto/Material", 150, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[3], "Lote", 80, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[4], "NF Cliente", 80, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[5], "Quantidade", 80, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[6], "Data Recebimento", 80, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[7], "Saldo", 80, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[8], "Situação", 80, DataGridViewAutoSizeColumnMode.None, true);
                this.dataGridView1.Columns[9].Visible = false;


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

        private void Novo()
        {
            try
            {
                LoteClienteForm form = new LoteClienteForm(this.conn, null, this.internalLabelPrinter, this.internalLabelPaper, this.Tipo, this.Usuario);
                form.ShowDialog();
                this.initializeGrid();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao cadastrar um novo item.\r\n" + e.Message);
            }
        }

        private void ForcarEncerramento()
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    if (this.dataGridView1.SelectedRows[0].Cells["lot_situacao"].Value.ToString() == "0")
                    {

                        if (MessageBox.Show(this, "Você deseja forçar o encerramento o item selecionado?", "Encerramento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {

                            int? id = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells["id_lote"].Value);

                            LoteClass lote = new LoteClass(id, this.Usuario, this.conn);
                            lote.ForcarEncerramento();
                            lote.Salvar();

                            this.initializeGrid();
                        }
                    }
                    else
                    {
                        throw new Exception("Só é possível encerrar um lote em aberto");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao realizar o encerramento.\r\n" + e.Message, e);
            }
        }

        private void Cancelar()
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    if (this.dataGridView1.SelectedRows[0].Cells["lot_situacao"].Value.ToString() == "0")
                    {
                        if (MessageBox.Show(this, "Você deseja cancelar o item selecionado?", "Cancelamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {

                            int? id = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells["id_lote"].Value);

                            LoteClass lote = new LoteClass(id, this.Usuario, this.conn);
                            lote.Cancelar();
                            lote.Salvar();

                            this.initializeGrid();
                        }
                    }
                    else
                    {
                        throw new Exception("Só é possível cancelar um lote em aberto");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao realizar o cancelamento.\r\n" + e.Message, e);
            }
        }

        private void VisualizarDados()
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                throw new ExcecaoTratada("Selecione um lote para visualizar o uso");
            }

            int? id = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells["id_lote"].Value);

            LoteClienteForm form = new LoteClienteForm(this.conn, id, this.internalLabelPrinter, this.internalLabelPaper, this.Tipo, this.Usuario);
            form.ShowDialog();
            this.initializeGrid();

        }

        private void VisualizarUso()
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                throw new ExcecaoTratada("Selecione um lote para visualizar o uso");
            }

            long id = Convert.ToInt64(this.dataGridView1.SelectedRows[0].Cells["id_lote"].Value);

            BibliotecaEntidades.Entidades.LoteClass lote = BibliotecaEntidades.Entidades.LoteClass.GetEntidade(id, this.Usuario, this.conn);

            CadPedidoItemLoteClienteListForm form = new CadPedidoItemLoteClienteListForm(lote);
            form.ShowDialog(this);

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

        private void rdbPendentes_CheckedChanged(object sender, EventArgs e)
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

        private void rdbEncerrados_CheckedChanged(object sender, EventArgs e)
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

        private void rdbTodos_CheckedChanged(object sender, EventArgs e)
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


        private void rdbCancelados_CheckedChanged(object sender, EventArgs e)
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

        private void btnForcarEncerramento_Click(object sender, EventArgs e)
        {
            try
            {
                this.ForcarEncerramento();
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


        private void iwtButton1_Click(object sender, EventArgs e)
        {
            try
            {
                VisualizarDados();
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



        private void iwtButton2_Click(object sender, EventArgs e)
        {
            try
            {
                VisualizarUso();
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
