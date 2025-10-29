#region Referencias

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using NpgsqlTypes;

#endregion

namespace BibliotecaCompras
{
    public partial class CadNFEntradaListForm : IWTBaseForm
    {
        readonly IWTPostgreNpgsqlConnection conn;
        BindingSource binding;
        readonly AcsUsuarioClass Usuario;

        public CadNFEntradaListForm(AcsUsuarioClass Usuario, IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            this.Usuario = Usuario;


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
                "SELECT    " +
                "  public.nota_fiscal_entrada.id_nota_fiscal_entrada,   " +
                "  public.nota_fiscal_entrada.nen_razao_fornecedor,   " +
                "  public.nota_fiscal_entrada.nen_cnpj,   " +
                "  public.nota_fiscal_entrada.nen_numero_nf,   " +
                "  public.nota_fiscal_entrada.nen_serie_nf,   " +
                "  public.nota_fiscal_entrada.nen_data_nf,   " +
                "  public.nota_fiscal_entrada.nen_valor_total,   " +
                "  public.nota_fiscal_entrada.nen_data_importacao, " +
                "  Editar   " +
                "FROM   " +
                "  public.nota_fiscal_entrada   " +
                "  LEFT JOIN ( " +
                "    SELECT  nota_fiscal_entrada.id_nota_fiscal_entrada, 1 as Editar  " +
                "    FROM  " +
                "      public.nota_fiscal_entrada   " +
                "      INNER JOIN public.nota_fiscal_entrada_linha ON (public.nota_fiscal_entrada.id_nota_fiscal_entrada = public.nota_fiscal_entrada_linha.id_nota_fiscal_entrada)   " +
                "    WHERE   " +
                "      public.nota_fiscal_entrada_linha.nel_vinculada = 0   " +
                "    GROUP BY   " +
                "      public.nota_fiscal_entrada.id_nota_fiscal_entrada,   " +
                "      public.nota_fiscal_entrada.nen_razao_fornecedor,   " +
                "      public.nota_fiscal_entrada.nen_cnpj,   " +
                "      public.nota_fiscal_entrada.nen_numero_nf,   " +
                "      public.nota_fiscal_entrada.nen_serie_nf,   " +
                "      public.nota_fiscal_entrada.nen_data_nf,   " +
                "      public.nota_fiscal_entrada.nen_valor_total,   " +
                "      public.nota_fiscal_entrada.nen_data_importacao   " +
                "  ) as pendentes  " +
                "  ON nota_fiscal_entrada.id_nota_fiscal_entrada = pendentes.id_nota_fiscal_entrada " +
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
                this.dataGridView1.Columns[8].Visible = false;


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

                if(grpBuscaDataNF.Enabled)
                {
                    if(dtpDataNFInicio.Text != "")
                    {
                        filter += " AND (nen_data_nf > '" + dtpDataNFInicio.Value.ToString("yyyy-MM-dd") + "') ";  
                    }
                    if (dtpDataNFFim.Text != "")
                    {
                        filter += " AND (nen_data_nf < '" + dtpDataNFFim.Value.AddDays(1).ToString("yyyy-MM-dd") + "') ";  
                    }
                }

                if(grpDataImportacao.Enabled)
                {
                    if (dtpDataImpInicio.Text != "")
                    {
                        filter += " AND (nen_data_importacao > '" + dtpDataImpInicio.Value.ToString("yyyy-MM-dd") + "' ) "; 
                    }
                    if (dtpDataNFFim.Text != "")
                    {
                        filter +=  " AND (nen_data_importacao < '" + dtpDataImpFim.Value.AddDays(1).ToString("yyyy-MM-dd") + "' ) ";
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

        private void Novo()
        {
            try
            {
                CadNFEntradaForm form = new CadNFEntradaForm(null,false, this.conn, this.Usuario);
                form.ShowDialog();

                this.initializeGrid();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        private void Editar()
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    bool somenteVisualizacao = false;
                    if (this.dataGridView1.SelectedRows[0].Cells["Editar"].Value.ToString() != "1")
                    {
                        somenteVisualizacao = true;
                        //throw new Exception("Não é possível editar ou excluir uma nota fiscal para qual já foi realizado o recebimento.");
                    }

                    int? id = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells["id_nota_fiscal_entrada"].Value);

                    CadNFEntradaForm form = new CadNFEntradaForm(id,somenteVisualizacao, this.conn, this.Usuario);
                    form.ShowDialog();
                    this.initializeGrid();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao editar o item.\r\n" + e.Message);
            }
        }

        public class NfsEntradaExcluir
        {
            public long IdNotaEntrada { get; set; }
            public string NumeroNf{ get; set; }
            public bool? Editar { get; set; }
        }

        public static void Excluir(List<NfsEntradaExcluir> notasExcluir, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
                if (MessageBox.Show(null, "Você deseja excluir o(s) item(ns) selecionado(s)?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }


                if (notasExcluir.Count == 0)
                {
                    throw new Exception("Selecione a nota fiscal que você deseja excluir.");
                }

                string erros = "";

                foreach (NfsEntradaExcluir nf in notasExcluir)
                {
                    IWTPostgreNpgsqlCommand command = null;
                    try
                    {
                        command = conn.CreateCommand();
                        command.Transaction = command.Connection.BeginTransaction();

                        if (!nf.Editar.HasValue)
                        {
                            command.CommandText =

                                "    SELECT  nota_fiscal_entrada.id_nota_fiscal_entrada, 1 as Editar  " +
                                "    FROM  " +
                                "      public.nota_fiscal_entrada   " +
                                "      INNER JOIN public.nota_fiscal_entrada_linha ON (public.nota_fiscal_entrada.id_nota_fiscal_entrada = public.nota_fiscal_entrada_linha.id_nota_fiscal_entrada)   " +
                                "    WHERE   " +
                                "      public.nota_fiscal_entrada_linha.nel_vinculada = 0  AND " +
                                "      public.nota_fiscal_entrada.id_nota_fiscal_entrada = :id_nota_fiscal_entrada " +
                                "    GROUP BY   " +
                                "      public.nota_fiscal_entrada.id_nota_fiscal_entrada,   " +
                                "      public.nota_fiscal_entrada.nen_razao_fornecedor,   " +
                                "      public.nota_fiscal_entrada.nen_cnpj,   " +
                                "      public.nota_fiscal_entrada.nen_numero_nf,   " +
                                "      public.nota_fiscal_entrada.nen_serie_nf,   " +
                                "      public.nota_fiscal_entrada.nen_data_nf,   " +
                                "      public.nota_fiscal_entrada.nen_valor_total,   " +
                                "      public.nota_fiscal_entrada.nen_data_importacao   ";

                            command.Parameters.Clear();

                            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nota_fiscal_entrada", NpgsqlDbType.Integer));
                            command.Parameters[command.Parameters.Count - 1].Value = (int) nf.IdNotaEntrada;

                            IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                            nf.Editar = read.HasRows;
                            read.Close();
                        }


                        if (!nf.Editar.Value)
                        {
                            erros += "Não é possível editar ou excluir uma nota fiscal para qual já foi realizado o recebimento - " + nf.NumeroNf + "." + Environment.NewLine;
                             command?.Transaction?.Rollback();
                            continue;
                        }

                        command.CommandText =
                            "SELECT  " +
                            "  COUNT(public.conta_pagar.id_conta_pagar) AS qtd " +
                            "FROM " +
                            "  public.conta_pagar " +
                            "WHERE " +
                            "  public.conta_pagar.id_nota_fiscal_entrada = :id_nota_fiscal_entrada AND  " +
                            "  public.conta_pagar.cop_data_pagamento IS NOT NULL ";

                        command.Parameters.Clear();

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nota_fiscal_entrada", NpgsqlDbType.Integer));
                        command.Parameters[command.Parameters.Count - 1].Value = (int) nf.IdNotaEntrada;

                        object tmp = command.ExecuteScalar();
                        int qtdContasPagarPagas = Convert.ToInt32(tmp);

                        if (qtdContasPagarPagas > 0)
                        {
                            erros += "Já existem contas pagas vinculadas a essa nota, realize o estorno antes de excluir a nota de entrada - " + nf.NumeroNf + "." + Environment.NewLine;
                            command?.Transaction?.Rollback();
                            continue;
                        }


                        command.CommandText =
                            "DELETE " +
                            "FROM " +
                            "  public.conta_pagar " +
                            "WHERE " +
                            "  public.conta_pagar.id_nota_fiscal_entrada = :id_nota_fiscal_entrada ";

                        command.ExecuteNonQuery();

                        command.CommandText =
                            "DELETE FROM  " +
                            "  public.nota_fiscal_entrada  " +
                            "WHERE  " +
                            "  id_nota_fiscal_entrada = :id_nota_fiscal_entrada " +
                            "; ";

                        command.ExecuteNonQuery();

                        command.Transaction.Commit();
                        
                    }
                    catch (Exception e)
                    {
                        command?.Transaction?.Rollback();
                        erros += "Erro inesperado ao excluir a NF - " + nf.NumeroNf + ": " + e.Message + Environment.NewLine;
                        continue;
                    }
                }

                if (!string.IsNullOrWhiteSpace(erros))
                {
                    throw new ExcecaoTratada(erros);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao excluir o(s) item(ns) selecionado(s).\r\n" + e.Message);
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                List<NfsEntradaExcluir> itensExcluir = new List<NfsEntradaExcluir>();
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    itensExcluir.Add(new NfsEntradaExcluir()
                    {
                        Editar = Convert.ToBoolean(Convert.ToInt16(row.Cells["Editar"].Value==DBNull.Value?0: row.Cells["Editar"].Value)),
                        IdNotaEntrada = Convert.ToInt64(row.Cells["id_nota_fiscal_entrada"].Value),
                        NumeroNf = row.Cells["nen_numero_nf"].Value.ToString()
                    });
                }
                Excluir(itensExcluir, SingleConnection);

            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                initializeGrid();
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

        #endregion
    }
}
