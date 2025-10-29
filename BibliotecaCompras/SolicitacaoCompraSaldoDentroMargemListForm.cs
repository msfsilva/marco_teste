#region Referencias

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using BibliotecaEntidades.Operacoes.Compras;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using ProjectConstants;

#endregion

namespace BibliotecaCompras
{

    public partial class SolicitacaoCompraSaldoDentroMargemListForm : IWTBaseForm
    {
        readonly IWTPostgreNpgsqlConnection conn;
        readonly AcsUsuarioClass _acsUsuario;
        BindingSource binding;


        public SolicitacaoCompraSaldoDentroMargemListForm(
        
            IWTPostgreNpgsqlConnection conn, AcsUsuarioClass _acsUsuario)
        {
            InitializeComponent();
            this.conn = conn;
            this._acsUsuario = _acsUsuario;
     


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
                filter += " AND ( " +
                            " UPPER(identificacao) LIKE '%" + this.txtBusca.Text.Trim().ToUpper() + "%' " +
                            " OR UPPER(aus_login) LIKE '%" + this.txtBusca.Text.Trim().ToUpper() + "%' " +
                            " OR UPPER(usuPCP) LIKE '%" + this.txtBusca.Text.Trim().ToUpper() + "%' " +
                            " OR LOWER(identificacao) LIKE '%" + this.txtBusca.Text.Trim().ToLower() + "%' " +
                            " OR LOWER(aus_login) LIKE '%" + this.txtBusca.Text.Trim().ToLower() + "%' " +
                            " OR LOWER(usuPCP) LIKE '%" + this.txtBusca.Text.Trim().ToLower() + "%' " +

                ") ";
            }

            if (this.nudIdOC.Enabled)
            {
                filter += " AND ( " +
                                " id_solicitacao_compra = " + this.nudIdOC.Value.ToString() + " " +
                              ") ";
            }

            filter += " AND (tab.status = 4 OR tab.status = 3) ";
      


            string filterStatus = "";
          

            if (filterStatus.Length > 0)
            {
                filter += " AND (" + filterStatus.Substring(3) + ") ";
            }

          


            if (filter.Length > 0)
            {
                filter = " WHERE " + filter.Substring(4);
            }


            int diasPCP = Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.DIAS_PROGRAMACAO_PCP));
            int leadtimeCompras = Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.DIAS_PROGRAMACAO_COMPRAS));
            double margemPadrao = Convert.ToDouble(IWTConfiguration.Conf.getConf(Constants.MARGEM_PADRAO_ACEITE_RECEBIMENTO_COMPRAS));

            string sql =
                "SELECT                                                                                                                         " +
                "  tab.identificacao,                                                                                                           " +
                "  tab.medida, " +
                "  tab.descricao, " +
                "  tab.descricao2, " +
                "  tab.soc_unidade_compra, " +
                "  tab.politica_estoque, " +
                "  CASE tab.estoque_seguranca_tipo WHEN 1 THEN 'Verde' WHEN 2 THEN 'Amarelo' WHEN 3 THEN 'Vermelho' ELSE '' END, " +
                "  tab.estoque_seguranca, " +
                "  tab.id_solicitacao_compra,                                                                                                   " +
                "  tab.soc_qtd,                                                                                                                 " +
                "  tab.soc_data_abertura,                                                                                                       " +
                "  CAST(tab.soc_data_abertura + interval '" + diasPCP + " day' AS date) as limitePCP, " +
                "  tab.soc_data_aprovacao_pcp, " +
                "  tab.id_ordem_compra, " +
                "  tab.com_apelido, " +
                "  CAST(COALESCE(tab.soc_data_abertura, tab.soc_data_aprovacao_pcp) + interval '" + leadtimeCompras +
                " day' AS date) as limiteCompras, " +
                "  tab.soc_data_aprovacao_compras, " +
                "  tab.soc_saldo_recebimento,   																							    " +
                "  CAST(tab.soc_entrega_prevista AS date) as entregaPrevista , " +
                "  CASE tab.status " +
                "     WHEN 0 THEN 'Não Liberada' " +
                "     WHEN 1 THEN 'Aprovada PCP' " +
                "     WHEN 2 THEN 'Aprovada Compras' " +
                "     WHEN 3 THEN 'Comprada' " +
                "     WHEN 4 THEN 'Recebida Parcial' " +
                "     WHEN 5 THEN 'Recebida Total' " +
                "     WHEN 6 THEN 'Cancelada' " +
                "     ELSE '' END " +
                "  AS status_traduzido, " +
                "  tab.for_razao_social, " +
                "  tab.aus_login,                                                                                                                " +
                "  tab.atende_margem_recebimento, " +
                "  tab.status as stat_original, " +
                "  tab.id_comprador, " +
                "  scf_texto "+
                "FROM (                                                                                                                         " +
                "SELECT  " +
                "  public.solicitacao_compra.id_solicitacao_compra, " +
                "  public.produto.pro_codigo AS identificacao, " +
                "  '' AS medida,  " +
                "  public.produto.pro_descricao as descricao,  " +
                "  public.produto.pro_descricao_adicional as descricao2,  " +
                "  public.solicitacao_compra.soc_unidade_compra,  " +
                "  public.solicitacao_compra.soc_qtd, " +
                "  public.solicitacao_compra.soc_data_abertura, " +
                "  public.solicitacao_compra.soc_saldo_recebimento, " +
                "  public.acs_usuario.aus_login, " +
                "  public.solicitacao_compra.soc_status AS status, " +
                "  public.solicitacao_compra.soc_entrega_prevista, " +
                "  public.solicitacao_compra.soc_data_aprovacao_pcp, " +
                "  u2.aus_login AS usupcp, " +
                "  public.ordem_compra.id_ordem_compra, " +
                "  public.fornecedor.for_razao_social, " +
                "  public.solicitacao_compra.soc_data_aprovacao_compras, " +
                "  CASE public.produto.pro_politica_estoque " +
                "    WHEN 0 " +
                "      THEN 'MRP' " +
                "    WHEN 1 " +
                "      THEN 'Prod Repetitiva' " +
                "    ELSE  'Não Aplicável' " +
                "  END AS politica_estoque, " +
                "  public.produto.pro_utilizando_estoque_seguranca_data AS estoque_seguranca, " +
                "  public.produto.pro_utilizando_estoque_seguranca AS estoque_seguranca_tipo, " +
                "  public.comprador.com_apelido, " +
                "  public.comprador.id_comprador, " +
                " solicitacao_compra.soc_saldo_recebimento <= COALESCE(produto.pro_margem_recebimento, " +
                margemPadrao.ToString("F2", CultureInfo.InvariantCulture) + " )/100 * solicitacao_compra.soc_qtd as atende_margem_recebimento " +
                "FROM " +
                "  public.solicitacao_compra " +
                "  INNER JOIN public.produto ON (public.solicitacao_compra.id_produto = public.produto.id_produto) " +
                "  INNER JOIN public.acs_usuario ON (public.solicitacao_compra.id_acs_usuario = public.acs_usuario.id_acs_usuario) " +
                "  LEFT OUTER JOIN public.acs_usuario u2 ON (public.solicitacao_compra.id_acs_usuario_pcp = u2.id_acs_usuario) " +
                "  LEFT OUTER JOIN public.ordem_compra ON (public.solicitacao_compra.id_ordem_compra = public.ordem_compra.id_ordem_compra) " +
                "  LEFT OUTER JOIN public.fornecedor ON (public.ordem_compra.id_fornecedor = public.fornecedor.id_fornecedor) " +
                "  LEFT OUTER JOIN public.comprador ON (public.ordem_compra.id_comprador = public.comprador.id_comprador) " +
                "UNION ALL																													        " +
                "SELECT  " +
                "  public.solicitacao_compra.id_solicitacao_compra, " +
                "  familia_material.fam_codigo || ' ' || public.material.mat_codigo ||' (M'||public.material.id_material||')' AS identificacao, " +
                "  replace( " +
                "    public.material.mat_medida || 'x' ||  " +
                "    public.material.mat_medida_largura|| 'x' || " +
                "    public.material.mat_medida_comprimento, '0x0x0','') " +
                "  AS medida, " +
                "  public.material.mat_descricao as descricao, " +
                "  public.material.mat_descricao_adicional as descricao2, " +
                "  public.solicitacao_compra.soc_unidade_compra, " +
                "  public.solicitacao_compra.soc_qtd, " +
                "  public.solicitacao_compra.soc_data_abertura, " +
                "  public.solicitacao_compra.soc_saldo_recebimento, " +
                "  public.acs_usuario.aus_login, " +
                "  public.solicitacao_compra.soc_status AS status, " +
                "  public.solicitacao_compra.soc_entrega_prevista, " +
                "  public.solicitacao_compra.soc_data_aprovacao_pcp, " +
                "  u2.aus_login AS usupcp, " +
                "  public.ordem_compra.id_ordem_compra, " +
                "  public.fornecedor.for_razao_social, " +
                "  public.solicitacao_compra.soc_data_aprovacao_compras, " +
                "  CASE public.material.mat_politica_estoque " +
                "    WHEN 0 " +
                "      THEN 'MRP' " +
                "    WHEN 1 " +
                "      THEN 'Prod Repetitiva' " +
                "    ELSE  'Não Aplicável' " +
                "  END AS politica_estoque, " +
                "  public.material.mat_utilizando_estoque_seguranca_data AS estoque_seguranca, " +
                "  public.material.mat_utilizando_estoque_seguranca AS estoque_seguranca_tipo, " +
                "  public.comprador.com_apelido, " +
                "  public.comprador.id_comprador, " +
                "  solicitacao_compra.soc_saldo_recebimento <= COALESCE(material.mat_margem_recebimento, " +
                margemPadrao.ToString("F2", CultureInfo.InvariantCulture) + " )/100 * solicitacao_compra.soc_qtd as atende_margem_recebimento " +
                "FROM " +
                "  public.solicitacao_compra " +
                "  INNER JOIN public.material ON (public.solicitacao_compra.id_material = public.material.id_material) " +
                "  LEFT OUTER JOIN familia_material ON (public.material.id_familia_material = familia_material.id_familia_material) " +
                "  INNER JOIN public.acs_usuario ON (public.solicitacao_compra.id_acs_usuario = public.acs_usuario.id_acs_usuario) " +
                "  LEFT OUTER JOIN public.acs_usuario u2 ON (public.solicitacao_compra.id_acs_usuario_pcp = u2.id_acs_usuario) " +
                "  LEFT OUTER JOIN public.ordem_compra ON (public.solicitacao_compra.id_ordem_compra = public.ordem_compra.id_ordem_compra) " +
                "  LEFT OUTER JOIN public.fornecedor ON (public.ordem_compra.id_fornecedor = public.fornecedor.id_fornecedor) " +
                "  LEFT OUTER JOIN public.comprador ON (public.ordem_compra.id_comprador = public.comprador.id_comprador) " +
                "UNION ALL " +
                "SELECT    " +
                "        public.solicitacao_compra.id_solicitacao_compra,   " +
                "        epi.epi_identificacao AS identificacao,   " +
                "        '' AS medida, " +
                "       public.epi.epi_descricao as descricao,   " +
                "        public.epi.epi_descricao_adicional as descricao2,   " +
                "        public.solicitacao_compra.soc_unidade_compra,   " +
                "        public.solicitacao_compra.soc_qtd,   " +
                "        public.solicitacao_compra.soc_data_abertura,   " +
                "        public.solicitacao_compra.soc_saldo_recebimento,   " +
                "        public.acs_usuario.aus_login,   " +
                "        public.solicitacao_compra.soc_status AS status,   " +
                "        public.solicitacao_compra.soc_entrega_prevista,   " +
                "        public.solicitacao_compra.soc_data_aprovacao_pcp,   " +
                "        u3.aus_login AS usupcp,   " +
                "        public.ordem_compra.id_ordem_compra,   " +
                "        public.fornecedor.for_razao_social,   " +
                "        public.solicitacao_compra.soc_data_aprovacao_compras,   " +
                "        'Não Aplicável' AS politica_estoque, " +
                "        public.epi.epi_utilizando_estoque_seguranca_data AS estoque_seguranca,   " +
                "        public.epi.epi_utilizando_estoque_seguranca AS estoque_seguranca_tipo,   " +
                "        public.comprador.com_apelido,   " +
                "        public.comprador.id_comprador, " +
                "        solicitacao_compra.soc_saldo_recebimento <= COALESCE(epi.epi_margem_recebimento,  " +
                margemPadrao.ToString("F2", CultureInfo.InvariantCulture) + " )/100 * solicitacao_compra.soc_qtd as atende_margem_recebimento " +
                "        FROM " +
                "        public.solicitacao_compra " +
                "        INNER JOIN public.epi ON(public.solicitacao_compra.id_epi = public.epi.id_epi)   " +
                "        INNER JOIN public.acs_usuario ON(public.solicitacao_compra.id_acs_usuario = public.acs_usuario.id_acs_usuario)   " +
                "        LEFT OUTER JOIN public.acs_usuario u3 ON(public.solicitacao_compra.id_acs_usuario_pcp = u3.id_acs_usuario)   " +
                "        LEFT OUTER JOIN public.ordem_compra ON(public.solicitacao_compra.id_ordem_compra = public.ordem_compra.id_ordem_compra)   " +
                "        LEFT OUTER JOIN public.fornecedor ON(public.ordem_compra.id_fornecedor = public.fornecedor.id_fornecedor) " +
                "        LEFT OUTER JOIN public.comprador ON(public.ordem_compra.id_comprador = public.comprador.id_comprador) " +
                ") AS tab  " +
                " LEFT OUTER JOIN (SELECT * FROM public.solicitacao_compra_feedback f WHERE f.scf_atual = 1) as feedback ON (tab.id_solicitacao_compra = feedback.id_solicitacao_compra) " +
                filter +
                " ORDER BY " +
                "  CAST(tab.soc_data_abertura + interval '" + diasPCP + " day' AS date), " +
                "  CAST(tab.soc_entrega_prevista AS date), " +
                "  tab.identificacao ";

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
                

                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[0], "Identificação", 150,
                                                        DataGridViewAutoSizeColumnMode.None, true);

                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[1], "Dimensão", 80,
                                                        DataGridViewAutoSizeColumnMode.None, false);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[2], "Descrição", 200,
                                                        DataGridViewAutoSizeColumnMode.None, false);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[3], "Descrição Adicional", 150,
                                                        DataGridViewAutoSizeColumnMode.None, false);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[4], "Unidade Compra", 70,
                                                        DataGridViewAutoSizeColumnMode.None, false);

                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[5], "Pol. Estoque", 80,
                                                        DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[6], "Estoque Segurança", 70,
                                                        DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[7], "Estoque Segurança Data", 100,
                                                        DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[8], "N° da\r\nSolicitação", 70,
                                                        DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[9], "Quantidade", 70,
                                                        DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[10], "Data Solicitação", 100,
                                                        DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[11], "Prazo PCP", 100,
                                                        DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[12], "Aprovação PCP", 100,
                                                        DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[13], "N° da OC", 70,
                                                        DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[14], "Comprador", 70,
                                                        DataGridViewAutoSizeColumnMode.None, true);

                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[15], "Prazo Compras", 100,
                                                        DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[16], "Aprovação Compras", 100,
                                                        DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[17], "Saldo Recebimento", 85,
                                                        DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[18], "Entrega Prevista", 80,
                                                        DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[19], "Status", 90,
                                                        DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[20], "Fornecedor", 150,
                                                        DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[21], "Solicitante", 70,
                                                        DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[22], "Saldo na Margem de Encerramento", 180,
                                         DataGridViewAutoSizeColumnMode.None, true);

                this.dataGridView1.Columns[23].Visible = false;
                this.dataGridView1.Columns[24].Visible = false;

                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[25], "Feedback", 150, DataGridViewAutoSizeColumnMode.None, true);

                this.dataGridView1.Columns[5].HeaderCell.Style.ForeColor = Color.Green;
                this.dataGridView1.Columns[6].HeaderCell.Style.ForeColor = Color.Green;
                this.dataGridView1.Columns[7].HeaderCell.Style.ForeColor = Color.Green;
                this.dataGridView1.Columns[8].HeaderCell.Style.ForeColor = Color.Green;
                this.dataGridView1.Columns[9].HeaderCell.Style.ForeColor = Color.Green;
                this.dataGridView1.Columns[10].HeaderCell.Style.ForeColor = Color.Green;
                this.dataGridView1.Columns[11].HeaderCell.Style.ForeColor = Color.Green;
                this.dataGridView1.Columns[12].HeaderCell.Style.ForeColor = Color.Green;

                this.dataGridView1.Columns[13].HeaderCell.Style.ForeColor = Color.Blue;
                this.dataGridView1.Columns[14].HeaderCell.Style.ForeColor = Color.Blue;
                this.dataGridView1.Columns[15].HeaderCell.Style.ForeColor = Color.Blue;
                this.dataGridView1.Columns[16].HeaderCell.Style.ForeColor = Color.Blue;
                this.dataGridView1.Columns[17].HeaderCell.Style.ForeColor = Color.Blue;
                this.dataGridView1.Columns[18].HeaderCell.Style.ForeColor = Color.Blue;
                this.dataGridView1.Columns[19].HeaderCell.Style.ForeColor = Color.Blue;
                this.dataGridView1.Columns[20].HeaderCell.Style.ForeColor = Color.Blue;
                this.dataGridView1.Columns[21].HeaderCell.Style.ForeColor = Color.Blue;
                this.dataGridView1.Columns[22].HeaderCell.Style.ForeColor = Color.Blue;



                this.dataGridView1.Columns[15].Visible = false;




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

        private void Cancelar()
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show(this, "Você deseja cancelar o(s) saldo(s) da(s) Solicitação(ões) de Compra selecionada(s)?", "Cancelar Saldo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }

                    List<int> toCancel = new List<int>();
                    foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
                    {
                        int id = Convert.ToInt32(row.Cells["id_solicitacao_compra"].Value);

                        if (row.Cells["stat_original"].Value.ToString() != "6")
                        {
                            if (row.Cells["atende_margem_recebimento"].Value.Equals(true))
                            {
                                toCancel.Add(id);
                            }
                            else
                            {
                                throw new Exception("A Solicitação " + id + " selecionada não pode ser cancelada pois o saldo de recebimento não está dentro da margem para encerramento.");
                            }
                            
                        }
                        else
                        {
                            throw new Exception("A Solicitação " + id + " selecionada já foi cancelada anteriormente.");
                        }
                    }

                    foreach (int idOC in toCancel)
                    {
                        SolicitacaoCompraClass sol = new SolicitacaoCompraClass(idOC, null, this._acsUsuario, this.conn);
                        sol.CancelarSaldo();
                        sol.Save(false);
                    }

                    this.initializeGrid();
                }
                else
                {
                    throw new Exception("Selecione a(s) Solicitação(ões) que você deseja cancelar o saldo.");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao cancelar o(s) saldo(s)  do(s) item(ns) selecionado(s).\r\n" + e.Message);
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

    

        #endregion

    }
}
