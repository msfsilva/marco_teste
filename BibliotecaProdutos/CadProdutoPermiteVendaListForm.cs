using System;
using System.Data;
using System.Windows.Forms;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaProdutos
{
    public partial class CadProdutoPermiteVendaListForm : IWTBaseForm
    {
        private IWTPostgreNpgsqlConnection conn;
        AcsUsuarioClass Usuario;
        TipoForm Tipo;

        private BindingSource binding;

        public CadProdutoPermiteVendaListForm( AcsUsuarioClass usuario, TipoForm tipo, IWTPostgreNpgsqlConnection conn)
        {
            Usuario = usuario;
            Tipo = tipo;
            this.conn = conn;
            InitializeComponent();
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


            string filter = "";

            if (this.txtBusca.Text.Trim().Length > 0)
            {

                filter = " WHERE ( " +
                         " UPPER(pro_codigo) LIKE '%" + this.txtBusca.Text.ToUpper().Trim() + "%' " +
                         " OR LOWER(pro_codigo) LIKE '%" + this.txtBusca.Text.ToLower().Trim() + "%' " +
                         " OR UPPER(pro_codigo_cliente) LIKE '%" + this.txtBusca.Text.ToUpper().Trim() + "%' " +
                         " OR LOWER(pro_codigo_cliente) LIKE '%" + this.txtBusca.Text.ToLower().Trim() + "%' " +
                         " OR UPPER(pro_descricao) LIKE '%" + this.txtBusca.Text.ToUpper().Trim() + "%' " +
                         " OR LOWER(pro_descricao) LIKE '%" + this.txtBusca.Text.ToLower().Trim() + "%' " +
                         ") ";
            }


            string sql =
                "SELECT    " +
                "  produto.id_produto,   " +
                "  pro_codigo,   " +
                "  pro_codigo_cliente,   " +
                "  pro_descricao,   " +
                "  public.cliente.cli_nome_resumido,   " +
                "  CASE pro_tipo_aquisicao WHEN 0 THEN 'Fabricado' WHEN 1 THEN 'Comprado' ELSE 'Inválido' END,   " +
                "  pro_permite_venda, " +
                "   tab.prr_observacao " +
                "FROM    " +
                "  public.produto   " +
                "  LEFT OUTER JOIN public.cliente ON (public.produto.id_cliente = public.cliente.id_cliente)   " +
                "  LEFT OUTER JOIN  " +
                "  (SELECT  " +
                "    produto_revisao.prr_observacao, " +
                "    produto_revisao.id_produto, " +
                "    rank() OVER w AS ran " +
                "    FROM public.produto_revisao " +
                "     WHERE produto_revisao.prr_tipo = 4 WINDOW w AS (PARTITION BY " +
                "          produto_revisao.id_produto " +
                "         ORDER BY produto_revisao.prr_data DESC, " +
                "          produto_revisao.id_produto_revisao DESC " +
                "   )  " +
                "  ) as tab ON (public.produto.id_produto = tab.id_produto AND ran = 1 )  " +

                filter + " " +
                "ORDER BY " +
                "  pro_codigo";

            IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.conn);

            DataSet ds = new DataSet();
            adapter.Fill(ds);

            binding = new BindingSource {DataSource = ds.Tables[0], Filter = atualFilter};
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = binding;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = true;

            this.dataGridView1.Columns[0].Visible = false;
            IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[1], "Código", 150,
                                                    DataGridViewAutoSizeColumnMode.None, true);
            IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[2], "Código Cliente", 150,
                                                    DataGridViewAutoSizeColumnMode.None, true);
            IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[3], "Descrição", 230,
                                                    DataGridViewAutoSizeColumnMode.None, true);
            IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[4], "Cliente", 80,
                                                    DataGridViewAutoSizeColumnMode.None, true);
            IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[5], "Aquisição", 80,
                                                    DataGridViewAutoSizeColumnMode.None, true);
            IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[6], "Permite Venda", 82,
                                                    DataGridViewAutoSizeColumnMode.None, true);
            IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[7], "Justificativa", 150,
                                                    DataGridViewAutoSizeColumnMode.None, true);

            DataGridViewColumn column = dataGridView1.Columns["pro_permite_venda"];

            if (column != null)
            {
                DataGridViewCheckBoxColumn tmp = new DataGridViewCheckBoxColumn
                                                     {
                                                         FalseValue = "0",
                                                         TrueValue = "1",
                                                         DataPropertyName = column.DataPropertyName,
                                                         DisplayIndex = column.DisplayIndex,
                                                         ReadOnly = column.ReadOnly,
                                                         AutoSizeMode = column.AutoSizeMode,
                                                         Width = column.Width,
                                                         Name = column.Name,
                                                         HeaderText = column.HeaderText
                                                     };
                dataGridView1.Columns.Remove(tmp.Name);
                dataGridView1.Columns.Add(tmp);
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

        private void AlterarPermitir(bool permitir)
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    command = this.conn.CreateCommand();
                    command.Transaction = this.conn.BeginTransaction();


                    foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
                    {
                        int id = Convert.ToInt32(row.Cells["id_produto"].Value);

                        ProdutoClass produto = ProdutoBaseClass.GetEntidade(id, this.Usuario, this.conn);
                        produto.PermiteVenda=permitir;
                        produto.SavePermissaoVenda(ref command);
                    }

                    command.Transaction.Commit();
                    
                    this.initializeGrid();
                }
            }
            catch (Exception e)
            {
                 if (command != null && command.Transaction!=null)
                {
                    command.Transaction.Rollback();
                }
                throw new Exception("Erro ao alterar o item.\r\n" + e.Message);
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

        private void btnPermitir_Click(object sender, EventArgs e)
        {
            try
            {
                this.AlterarPermitir(true);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProibir_Click(object sender, EventArgs e)
        {
            try
            {
                this.AlterarPermitir(false);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
