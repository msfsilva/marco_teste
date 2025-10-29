using System.Data;
using System.Windows.Forms;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using NpgsqlTypes;

namespace BibliotecaFinanceiro
{
    public partial class OPsUtilizadasNFeListForm : IWTBaseForm
    {
        BindingSource binding;
        readonly IWTPostgreNpgsqlConnection conn;
        public OPsUtilizadasNFeListForm(long idNFe, IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            this.initializeGrid(idNFe);
        }

        private void initializeGrid(long idNFe)
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

            string atualFilter = "";
            if (binding != null)
            {
                atualFilter = binding.Filter;
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


            const string sql =
                "SELECT  " +
                "  public.ordem_producao_pedido.opp_order_number ||'/'|| public.ordem_producao_pedido.opp_order_pos, " +
                "  public.ordem_producao_pedido.opp_produto_codigo, " +
                "  public.ordem_producao_pedido.opp_quantidade, " +
                "  public.ordem_producao.id_ordem_producao, " +
                "  public.ordem_producao.orp_data, " +
                "  CASE orp_situacao WHEN 0 THEN 'Nova' WHEN 1 THEN 'Em produção' WHEN 2 THEN 'Encerrada' WHEN 3 THEN 'Cancelada' ELSE 'Erro' END as situacao " +
                "FROM " +
                "  public.nf_principal " +
                "  INNER JOIN public.atendimento ON (public.nf_principal.id_nf_principal = public.atendimento.id_nf_principal) " +
                "  INNER JOIN public.order_item_etiqueta_conferencia ON (public.atendimento.id_order_item_etiqueta_conferencia = public.order_item_etiqueta_conferencia.id_order_item_etiqueta_conferencia) " +
                "  INNER JOIN public.ordem_producao_pedido ON (public.order_item_etiqueta_conferencia.id_order_item_etiqueta = public.ordem_producao_pedido.id_order_item_etiqueta) " +
                "  INNER JOIN public.ordem_producao ON (public.ordem_producao_pedido.id_ordem_producao = public.ordem_producao.id_ordem_producao) " +
                "WHERE " +
                "  public.nf_principal.id_nf_principal = :id_nf_principal " +
                "ORDER BY " +
                "  public.ordem_producao_pedido.opp_order_number ||'/'|| public.ordem_producao_pedido.opp_order_pos, " +
                "  public.ordem_producao_pedido.opp_produto_codigo, " +
                "  public.ordem_producao_pedido.id_ordem_producao ";
                

            IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.conn);
            adapter.Parameters.Clear();

            adapter.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nf_principal", NpgsqlDbType.Integer));
            adapter.Parameters[adapter.Parameters.Count - 1].Value = idNFe;

            DataSet ds = new DataSet();
            adapter.Fill(ds);

            binding = new BindingSource { DataSource = ds.Tables[0], Filter = atualFilter };
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = binding;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = true;

            IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[0], "Pedido", 80, DataGridViewAutoSizeColumnMode.None, true);
            IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[1], "Produto", 100, DataGridViewAutoSizeColumnMode.None, true);
            IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[2], "Quantidade", 80, DataGridViewAutoSizeColumnMode.None, true);
            IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[3], "Ordem Produção", 80, DataGridViewAutoSizeColumnMode.None, true);
            IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[4], "Data", 100, DataGridViewAutoSizeColumnMode.None, true);
            IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[5], "Situação", 80, DataGridViewAutoSizeColumnMode.None, true);
            
            


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

                binding.Sort = sortString;
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
    }
}


       
