#region Referencias

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

#endregion

namespace BibliotecaCompras
{
    public partial class CadNFEntradaPendentesListForm : IWTBaseForm
    {
        readonly IWTPostgreNpgsqlConnection conn;
        BindingSource binding;
        readonly AcsUsuarioClass Usuario;
        readonly string internalLabelPrinter;
        readonly string internalLabelPaper;

        public CadNFEntradaPendentesListForm( string internalLabelPrinter, string internalLabelPaper,AcsUsuarioClass Usuario, IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            this.Usuario = Usuario;
            this.internalLabelPaper = internalLabelPaper;
            this.internalLabelPrinter = internalLabelPrinter;

            this.dtpDataImpFim.Value = Configurations.DataIndependenteClass.GetData();
            this.dtpDataImpInicio.Value = Configurations.DataIndependenteClass.GetData();
            this.dtpDataNFFim.Value = Configurations.DataIndependenteClass.GetData();
            this.dtpDataNFInicio.Value = Configurations.DataIndependenteClass.GetData();

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


            string sql =
                "SELECT  " +
                "  public.nota_fiscal_entrada.id_nota_fiscal_entrada, " +
                "  public.nota_fiscal_entrada.nen_razao_fornecedor, " +
                "  public.nota_fiscal_entrada.nen_cnpj, " +
                "  public.nota_fiscal_entrada.nen_numero_nf, " +
                "  public.nota_fiscal_entrada.nen_serie_nf, " +
                "  public.nota_fiscal_entrada.nen_data_nf, " +
                "  public.nota_fiscal_entrada.nen_valor_total, " +
                "  public.nota_fiscal_entrada.nen_data_importacao " +
                "FROM " +
                "  public.nota_fiscal_entrada " +
                "  INNER JOIN public.nota_fiscal_entrada_linha ON (public.nota_fiscal_entrada.id_nota_fiscal_entrada = public.nota_fiscal_entrada_linha.id_nota_fiscal_entrada) " +
                "  LEFT JOIN public.fornecedor ON fornecedor.id_fornecedor = nota_fiscal_entrada.id_fornecedor "+
                "WHERE " +
                "  public.nota_fiscal_entrada_linha.nel_vinculada = 0 AND ( fornecedor.for_realiza_recebimento IS NULL OR fornecedor.for_realiza_recebimento = 1 ) " +
                "GROUP BY " +
                "  public.nota_fiscal_entrada.id_nota_fiscal_entrada, " +
                "  public.nota_fiscal_entrada.nen_razao_fornecedor, " +
                "  public.nota_fiscal_entrada.nen_cnpj, " +
                "  public.nota_fiscal_entrada.nen_numero_nf, " +
                "  public.nota_fiscal_entrada.nen_serie_nf, " +
                "  public.nota_fiscal_entrada.nen_data_nf, " +
                "  public.nota_fiscal_entrada.nen_valor_total, " +
                "  public.nota_fiscal_entrada.nen_data_importacao " +
                "ORDER BY " +
                "  public.nota_fiscal_entrada.nen_data_importacao DESC, nen_razao_fornecedor ASC ";

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
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[1], "Razão", 275, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[2], "CNPJ", 120, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[3], "Número NF", 50, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[4], "Série NF", 40, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[5], "Data NF", 100, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[6], "Valor", 80, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[7], "Data Importação", 100, DataGridViewAutoSizeColumnMode.None, true);



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

            this.updateSearch();

        }

        private void updateSearch()
        {
            try
            {
                string filter = "";
                if (this.txtBusca.Text.Trim().Length > 0)
                {
                    filter += " AND (nen_razao_fornecedor LIKE '%" + this.txtBusca.Text.Trim() + "%' OR nen_numero_nf LIKE '%" + this.txtBusca.Text.Trim() + "%' " +
                              "       OR nen_cnpj LIKE '%" + this.txtBusca.Text.Trim() + "%' OR nen_serie_nf LIKE '%" + this.txtBusca.Text.Trim() + "%') ";
                }

                if (grpBuscaDataNF.Enabled)
                {
                    if (dtpDataNFInicio.Text != "")
                    {
                        filter += " AND (nen_data_nf > '" + dtpDataNFInicio.Value.ToString("yyyy-MM-dd") + "') ";
                    }
                    if (dtpDataNFFim.Text != "")
                    {
                        filter += " AND (nen_data_nf < '" + dtpDataNFFim.Value.AddDays(1).ToString("yyyy-MM-dd") + "') ";
                    }
                }

                if (grpDataImportacao.Enabled)
                {
                    if (dtpDataImpInicio.Text != "")
                    {
                        filter += " AND (nen_data_importacao > '" + dtpDataImpInicio.Value.ToString("yyyy-MM-dd") + "' ) ";
                    }
                    if (dtpDataNFFim.Text != "")
                    {
                        filter += " AND (nen_data_importacao < '" + dtpDataImpFim.Value.AddDays(1).ToString("yyyy-MM-dd") + "' ) ";
                    }

                }

                if (filter.Length > 0)
                {
                    this.binding.Filter = filter.Substring(4);
                }
                else
                {
                    this.binding.Filter = "";
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao realizar a busca.\r\n" + e.Message);
            }

        }

        private void Receber()
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    int linhaSelecionada = this.dataGridView1.SelectedRows[0].Index;

                    DialogResult resp = DialogResult.Yes;
                    while (resp == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32(this.dataGridView1.Rows[linhaSelecionada].Cells["id_nota_fiscal_entrada"].Value);
                        RecebimentoForm form = new RecebimentoForm(id,this.internalLabelPrinter,this.internalLabelPaper, this.Usuario, this.conn);
                        form.ShowDialog();

                        if (linhaSelecionada < this.dataGridView1.Rows.Count - 1)
                        {
                            resp = MessageBox.Show(this, "Deseja realizar o recebimento da próxima nota fiscal pendente?", "Próxima", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            linhaSelecionada++;
                        }
                        else
                        {
                            resp = DialogResult.No;
                        }
                    }

                    this.initializeGrid();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao receber o item.\r\n" + e.Message);
            }
        }

        private void Excluir()
        {
            try
            {
                List<CadNFEntradaListForm.NfsEntradaExcluir> itensExcluir = new List<CadNFEntradaListForm.NfsEntradaExcluir>();
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    itensExcluir.Add(new CadNFEntradaListForm.NfsEntradaExcluir()
                    {
                        Editar = null,
                        IdNotaEntrada = Convert.ToInt64(row.Cells["id_nota_fiscal_entrada"].Value),
                        NumeroNf = row.Cells["nen_numero_nf"].Value.ToString()
                    });
                }
                CadNFEntradaListForm.Excluir(itensExcluir, SingleConnection);

            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao excluir as notas de entrada" + Environment.NewLine + e.Message, e);
            }
            finally
            {
                initializeGrid();
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
                this.updateSearch();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReceber_Click(object sender, EventArgs e)
        {
            try
            {
                this.Receber();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkAtivaBuscaDataNF_CheckedChanged(object sender, EventArgs e)
        {


            try
            {
                grpBuscaDataNF.Enabled = chkAtivaBuscaDataNF.Checked;
                this.initializeGrid();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void chkAtivaBuscaDataImp_CheckedChanged(object sender, EventArgs e)
        {


            try
            {
                grpDataImportacao.Enabled = chkAtivaBuscaDataImp.Checked;
                this.initializeGrid();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dtpDataNFInicio_ValueChanged(object sender, EventArgs e)
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

        private void dtpDataNFFim_ValueChanged(object sender, EventArgs e)
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

        private void dtpDataImpInicio_ValueChanged(object sender, EventArgs e)
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

        private void dtpDataImpFim_ValueChanged(object sender, EventArgs e)
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



        private void btnExcluir_Click(object sender, EventArgs e)
        {
              try
              {
                  Excluir();
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
