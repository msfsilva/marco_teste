using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using dbProvider;
using SolicitacaoCompraClass = BibliotecaEntidades.Operacoes.Compras.SolicitacaoCompraClass;

namespace BibliotecaCompras
{
    public partial class OrcamentoCompraForm : IWTBaseForm
    {
        private BindingSource bindingMat;
        private BindingSource bindingProd;
        private BindingSource bindingSol;
        private BindingSource bindingEpi;
        private byte[] logoEmpresa;

        private int diasPCP;
        private int leadTimeCompras;
        private IWTPostgreNpgsqlConnection conn;
        public OrcamentoCompraForm( byte[] logoEmpresa, int diasPCP, int leadTimeCompras, IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();

            this.logoEmpresa = logoEmpresa;

            this.diasPCP = diasPCP;
            this.leadTimeCompras = leadTimeCompras;
            this.conn = conn;

            this.loadGridProduto();
            this.loadGridMateriais();
            this.loadGridSolicitacoes();
            this.loadGridEpi();
            

            this.dgvProduto.Visible = true;
            this.rdbProduto.Checked = true;
            this.lblTipo.Text = "Produtos";
        }

        private void loadGridSolicitacoes()
        {
            try
            {
                string filter = " AND (" +
                    " UPPER(identificacao) LIKE '%" + this.txtBusca.Text.Trim().ToUpper() + "%' " +
                    " OR LOWER(identificacao) LIKE '%" + this.txtBusca.Text.Trim().ToLower() + "%' " +
                    " ) ";

                bindingSol = new BindingSource();

                string sql =
                    "SELECT                                                                                                                         " +
                    "  tab.id_item,   " +
                    "  tab.selecao, " +
                    "  tab.identificacao,   " +
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
                    "  CAST(COALESCE(tab.soc_data_abertura, tab.soc_data_aprovacao_pcp) + interval '" + this.leadTimeCompras + " day' AS date) as limiteCompras, " +
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
                    "  tab.status as stat_original " +
                    "FROM (                                                                                                                         " +
                    "SELECT  " +
                    "  public.produto.id_produto as id_item, " +
                    "  0 AS selecao, " +
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
                    "  public.comprador.com_apelido " +
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
                    "  public.material.id_material as id_item, " +
                    "  0 AS selecao, " +
                    "  public.solicitacao_compra.id_solicitacao_compra, " +
                    "  familia_material.fam_codigo || ' ' || public.material.mat_codigo AS identificacao, " +
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
                    "  public.comprador.com_apelido " +
                    "FROM " +
                    "  public.solicitacao_compra " +
                    "  INNER JOIN public.material ON (public.solicitacao_compra.id_material = public.material.id_material) " +
                    "  LEFT OUTER JOIN familia_material ON (public.material.id_familia_material = familia_material.id_familia_material) " +
                    "  INNER JOIN public.acs_usuario ON (public.solicitacao_compra.id_acs_usuario = public.acs_usuario.id_acs_usuario) " +
                    "  LEFT OUTER JOIN public.acs_usuario u2 ON (public.solicitacao_compra.id_acs_usuario_pcp = u2.id_acs_usuario) " +
                    "  LEFT OUTER JOIN public.ordem_compra ON (public.solicitacao_compra.id_ordem_compra = public.ordem_compra.id_ordem_compra) " +
                    "  LEFT OUTER JOIN public.fornecedor ON (public.ordem_compra.id_fornecedor = public.fornecedor.id_fornecedor) " +
                    "  LEFT OUTER JOIN public.comprador ON (public.ordem_compra.id_comprador = public.comprador.id_comprador) " +
                    " UNION ALL   " +
               "SELECT  " +
                    "  public.epi.id_epi as id_item, " +
                    "  0 AS selecao, " +
                    "  public.solicitacao_compra.id_solicitacao_compra, " +
                    "  public.epi.epi_identificacao AS identificacao, " +
                    "  '' AS medida, " +
                    "  public.epi.epi_descricao as descricao, " +
                    "  public.epi.epi_descricao_adicional as descricao2, " +
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
                    "  'Prod Repetitiva' AS politica_estoque, " +
                    "  NULL AS estoque_seguranca, " +
                    "  0 AS estoque_seguranca_tipo, " +
                    "  public.comprador.com_apelido " +
                    "FROM " +
                    "  public.solicitacao_compra " +
                    "  INNER JOIN public.epi ON (public.solicitacao_compra.id_epi = public.epi.id_epi) " +
                    "  INNER JOIN public.acs_usuario ON (public.solicitacao_compra.id_acs_usuario = public.acs_usuario.id_acs_usuario) " +
                    "  LEFT OUTER JOIN public.acs_usuario u2 ON (public.solicitacao_compra.id_acs_usuario_pcp = u2.id_acs_usuario) " +
                    "  LEFT OUTER JOIN public.ordem_compra ON (public.solicitacao_compra.id_ordem_compra = public.ordem_compra.id_ordem_compra) " +
                    "  LEFT OUTER JOIN public.fornecedor ON (public.ordem_compra.id_fornecedor = public.fornecedor.id_fornecedor) " +
                    "  LEFT OUTER JOIN public.comprador ON (public.ordem_compra.id_comprador = public.comprador.id_comprador) " +
                    ") AS tab  " +
                    " WHERE tab.status = 1" +
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

                    bindingSol = new BindingSource();
                    bindingSol.DataSource = ds.Tables[0];
                    //bindingSol.Filter = atualFilter;
                    dgvSolicitacaoCompra.AutoGenerateColumns = true;
                    dgvSolicitacaoCompra.DataSource = bindingSol;

                    dgvSolicitacaoCompra.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvSolicitacaoCompra.MultiSelect = true;
                    dgvSolicitacaoCompra.ReadOnly = false;
                    
                    this.dgvSolicitacaoCompra.Columns[1].ReadOnly = false;
                    this.dgvSolicitacaoCompra.Columns[2].ReadOnly = true;
                    this.dgvSolicitacaoCompra.Columns[3].ReadOnly = true;
                    this.dgvSolicitacaoCompra.Columns[4].ReadOnly = true;
                    this.dgvSolicitacaoCompra.Columns[5].ReadOnly = true;
                    this.dgvSolicitacaoCompra.Columns[6].ReadOnly = true;
                    this.dgvSolicitacaoCompra.Columns[7].ReadOnly = true;
                    this.dgvSolicitacaoCompra.Columns[8].ReadOnly = true;
                    this.dgvSolicitacaoCompra.Columns[9].ReadOnly = true;
                    this.dgvSolicitacaoCompra.Columns[10].ReadOnly = true;
                    this.dgvSolicitacaoCompra.Columns[11].ReadOnly = true;
                    this.dgvSolicitacaoCompra.Columns[12].ReadOnly = true;
                    this.dgvSolicitacaoCompra.Columns[13].ReadOnly = true;
                    this.dgvSolicitacaoCompra.Columns[14].ReadOnly = true;
                    this.dgvSolicitacaoCompra.Columns[15].ReadOnly = true;
                    this.dgvSolicitacaoCompra.Columns[16].ReadOnly = true;
                    this.dgvSolicitacaoCompra.Columns[17].ReadOnly = true;
                    this.dgvSolicitacaoCompra.Columns[18].ReadOnly = true;
                    this.dgvSolicitacaoCompra.Columns[19].ReadOnly = true;
                    this.dgvSolicitacaoCompra.Columns[20].ReadOnly = true;
                    this.dgvSolicitacaoCompra.Columns[21].ReadOnly = true;
                    this.dgvSolicitacaoCompra.Columns[22].ReadOnly = true;
                    this.dgvSolicitacaoCompra.Columns[23].ReadOnly = true;

                    this.dgvSolicitacaoCompra.Columns[0].Visible = false;

                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvSolicitacaoCompra.Columns[1], "", 30, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvSolicitacaoCompra.Columns[2], "Identificação", 150, DataGridViewAutoSizeColumnMode.None, true);

                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvSolicitacaoCompra.Columns[3], "Dimensão", 80, DataGridViewAutoSizeColumnMode.None, false);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvSolicitacaoCompra.Columns[4], "Descrição", 200, DataGridViewAutoSizeColumnMode.None, false);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvSolicitacaoCompra.Columns[5], "Descrição Adicional", 150, DataGridViewAutoSizeColumnMode.None, false);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvSolicitacaoCompra.Columns[6], "Unidade Compra", 70, DataGridViewAutoSizeColumnMode.None, false);

                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvSolicitacaoCompra.Columns[7], "Pol. Estoque", 80, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvSolicitacaoCompra.Columns[8], "Estoque Segurança", 70, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvSolicitacaoCompra.Columns[9], "Estoque Segurança Data", 100, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvSolicitacaoCompra.Columns[10], "N° da\r\nSolicitação", 70, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvSolicitacaoCompra.Columns[11], "Quantidade", 70, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvSolicitacaoCompra.Columns[12], "Data Solicitação", 100, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvSolicitacaoCompra.Columns[13], "Prazo PCP", 100, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvSolicitacaoCompra.Columns[14], "Aprovação PCP", 100, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvSolicitacaoCompra.Columns[15], "N° da OC", 70, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvSolicitacaoCompra.Columns[16], "Comprador", 70, DataGridViewAutoSizeColumnMode.None, true);

                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvSolicitacaoCompra.Columns[17], "Prazo Compras", 100, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvSolicitacaoCompra.Columns[18], "Aprovação Compras", 100, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvSolicitacaoCompra.Columns[19], "Saldo Recebimento", 85, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvSolicitacaoCompra.Columns[20], "Entrega Prevista", 80, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvSolicitacaoCompra.Columns[21], "Status", 90, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvSolicitacaoCompra.Columns[22], "Fornecedor", 150, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvSolicitacaoCompra.Columns[23], "Solicitante", 70, DataGridViewAutoSizeColumnMode.None, true);
                    this.dgvSolicitacaoCompra.Columns[24].Visible = false;

                    this.dgvSolicitacaoCompra.Columns[7].HeaderCell.Style.ForeColor = Color.Green;
                    this.dgvSolicitacaoCompra.Columns[8].HeaderCell.Style.ForeColor = Color.Green;
                    this.dgvSolicitacaoCompra.Columns[9].HeaderCell.Style.ForeColor = Color.Green;
                    this.dgvSolicitacaoCompra.Columns[10].HeaderCell.Style.ForeColor = Color.Green;
                    this.dgvSolicitacaoCompra.Columns[11].HeaderCell.Style.ForeColor = Color.Green;
                    this.dgvSolicitacaoCompra.Columns[12].HeaderCell.Style.ForeColor = Color.Green;
                    this.dgvSolicitacaoCompra.Columns[13].HeaderCell.Style.ForeColor = Color.Green;
                    this.dgvSolicitacaoCompra.Columns[14].HeaderCell.Style.ForeColor = Color.Green;

                    this.dgvSolicitacaoCompra.Columns[15].HeaderCell.Style.ForeColor = Color.Blue;
                    this.dgvSolicitacaoCompra.Columns[16].HeaderCell.Style.ForeColor = Color.Blue;
                    this.dgvSolicitacaoCompra.Columns[17].HeaderCell.Style.ForeColor = Color.Blue;
                    this.dgvSolicitacaoCompra.Columns[18].HeaderCell.Style.ForeColor = Color.Blue;
                    this.dgvSolicitacaoCompra.Columns[19].HeaderCell.Style.ForeColor = Color.Blue;
                    this.dgvSolicitacaoCompra.Columns[20].HeaderCell.Style.ForeColor = Color.Blue;
                    this.dgvSolicitacaoCompra.Columns[21].HeaderCell.Style.ForeColor = Color.Blue;
                    this.dgvSolicitacaoCompra.Columns[22].HeaderCell.Style.ForeColor = Color.Blue;
                    this.dgvSolicitacaoCompra.Columns[23].HeaderCell.Style.ForeColor = Color.Blue;

                }
                       
                DataGridViewColumn column = dgvSolicitacaoCompra.Columns["selecao"];
                DataGridViewCheckBoxColumn tmp = null;

                tmp = new DataGridViewCheckBoxColumn();
                tmp.FalseValue = "0";
                tmp.TrueValue = "1";
                tmp.DataPropertyName = column.DataPropertyName;
                tmp.DisplayIndex = column.DisplayIndex;
                tmp.ReadOnly = column.ReadOnly;
                tmp.AutoSizeMode = column.AutoSizeMode;
                tmp.Width = column.Width;
                tmp.Name = column.Name;
                tmp.HeaderText = column.HeaderText;
                dgvSolicitacaoCompra.Columns.Remove(tmp.Name);
                dgvSolicitacaoCompra.Columns.Add(tmp);
            }
            catch (Exception e)
            {
                MessageBox.Show(this, "Erro ao carregar o grid de Solicitações de Compra.\r\n" + e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                               
            }
        }

        private void loadGridProduto()
        {
            try
            {
                string filter = " AND (" +
                    " UPPER(pro_codigo) LIKE '%" + this.txtBusca.Text.Trim().ToUpper() + "%' " +
                    " OR UPPER(pro_codigo_cliente) LIKE '%" + this.txtBusca.Text.Trim().ToUpper() + "%' " +
                    " OR UPPER(pro_descricao) LIKE '%" + this.txtBusca.Text.Trim().ToUpper() + "%' " +
                    " OR UPPER(lof_identificacao) LIKE '%" + this.txtBusca.Text.Trim().ToUpper() + "%' " +
                    " OR LOWER(pro_codigo) LIKE '%" + this.txtBusca.Text.Trim().ToLower() + "%' " +
                    " OR LOWER(pro_codigo_cliente) LIKE '%" + this.txtBusca.Text.Trim().ToLower() + "%' " +
                    " OR LOWER(pro_descricao) LIKE '%" + this.txtBusca.Text.Trim().ToLower() + "%' " +
                    " OR LOWER(lof_identificacao) LIKE '%" + this.txtBusca.Text.Trim().ToLower() + "%' " +
                    " ) ";


                bindingProd = new BindingSource();

                string sql = "SELECT  " +
                                    "  id_produto, " +
                                    "  0 AS selecao, " +
                                    "  0.0 AS quantidade, " +
                                    "  pro_codigo, " +
                                    "  pro_codigo_cliente, " +
                                    "  pro_descricao, " +
                                    "  CASE pro_tipo_aquisicao WHEN 0 THEN 'Fabricado' WHEN 1 THEN 'Comprado' ELSE 'Inválido' END, " +
                                    "  CASE WHEN u2.unm_abreviada IS NOT NULL THEN u2.unm_abreviada ELSE public.unidade_medida.unm_abreviada END as unidade, " +
                                    "  pro_emite_op, " +
                                    "  pro_versao_estrutura_atual " +
                                    "FROM  " +
                                    "  public.produto " +
                                    "  LEFT OUTER JOIN public.local_fabricacao ON (public.produto.id_local_fabricacao = public.local_fabricacao.id_local_fabricacao) " +
                                    "  LEFT JOIN public.unidade_medida ON (public.produto.id_unidade_medida = public.unidade_medida.id_unidade_medida) " +
                                    "  LEFT JOIN public.unidade_medida u2 ON (public.produto.id_unidade_medida_compra = u2.id_unidade_medida) " +
                                    "WHERE pro_tipo_aquisicao = 1 " +
                                    filter +
                                    "ORDER BY " +
                                    "  pro_codigo";

                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.conn);
                if (adapter != null)
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    bindingProd.DataSource = ds.Tables[0];


                    dgvProduto.AutoGenerateColumns = true;
                    dgvProduto.DataSource = bindingProd;

                    dgvProduto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvProduto.MultiSelect = false;
                    dgvProduto.ReadOnly = false;
                    this.dgvProduto.Columns[0].Visible = false;
                    this.dgvProduto.Columns[1].ReadOnly = false;
                    this.dgvProduto.Columns[2].ReadOnly = false;
                    this.dgvProduto.Columns[3].ReadOnly = true;
                    this.dgvProduto.Columns[4].ReadOnly = true;
                    this.dgvProduto.Columns[5].ReadOnly = true;
                    this.dgvProduto.Columns[6].ReadOnly = true;
                    this.dgvProduto.Columns[7].ReadOnly = true;
                    this.dgvProduto.Columns[8].ReadOnly = true;
                    this.dgvProduto.Columns[9].ReadOnly = true;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvProduto.Columns[1], "", 30, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvProduto.Columns[2], "Quantidade", 80, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvProduto.Columns[3], "Código", 100, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvProduto.Columns[4], "Código Cliente", 100, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvProduto.Columns[5], "Descrição", 160, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvProduto.Columns[6], "Aquisição", 80, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvProduto.Columns[7], "Unidade Compra", 80, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvProduto.Columns[8], "Emite OP", 80, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvProduto.Columns[9], "Rev. Atual", 60, DataGridViewAutoSizeColumnMode.None, true);


                    DataGridViewColumn column = dgvProduto.Columns["selecao"];
                    DataGridViewCheckBoxColumn tmp = null;

                    tmp = new DataGridViewCheckBoxColumn();
                    tmp.FalseValue = "0";
                    tmp.TrueValue = "1";
                    tmp.DataPropertyName = column.DataPropertyName;
                    tmp.DisplayIndex = column.DisplayIndex;
                    tmp.ReadOnly = column.ReadOnly;
                    tmp.AutoSizeMode = column.AutoSizeMode;
                    tmp.Width = column.Width;
                    tmp.Name = column.Name;
                    tmp.HeaderText = column.HeaderText;
                    dgvProduto.Columns.Remove(tmp.Name);
                    dgvProduto.Columns.Add(tmp);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(this, "Erro ao carregar o grid de produtos.\r\n" + e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void loadGridMateriais()
        {
            try
            {
                bindingMat = new BindingSource();
                string filter = " ( " +
                    " UPPER(fam_codigo || mat_codigo) LIKE '%" + this.txtBusca.Text.Trim().ToUpper() + "%' " +
                    " OR UPPER(mat_codigo) LIKE '%" + this.txtBusca.Text.Trim().ToUpper() + "%' " +
                    " OR UPPER(mat_descricao) LIKE '%" + this.txtBusca.Text.Trim().ToUpper() + "%' " +
                    " OR LOWER(fam_codigo || mat_codigo) LIKE '%" + this.txtBusca.Text.Trim().ToLower() + "%' " +
                    " OR LOWER(mat_codigo) LIKE '%" + this.txtBusca.Text.Trim().ToLower() + "%' " +
                    " OR LOWER(mat_descricao) LIKE '%" + this.txtBusca.Text.Trim().ToLower() + "%' " +
                    " ) ";
                        
                               
                string sql = "SELECT  " +
                              "  public.material.id_material, " +
                              "  0 AS selecao, " +
                              "  0.0 AS quantidade, " +
                              "  public.familia_material.fam_codigo || ' ' || public.material.mat_codigo as codigo, " +
                              "  public.material.mat_descricao, " +
                              "  public.material.mat_descricao_adicional, " +
                              "  public.material.mat_medida, " +
                              "  public.material.mat_medida_largura, " +
                              "  public.material.mat_medida_comprimento, " +
                              "  CASE WHEN u2.unm_abreviada IS NOT NULL THEN u2.unm_abreviada ELSE public.unidade_medida.unm_abreviada END as unidade, " +
                              "  CASE public.material.mat_politica_estoque WHEN 0 THEN 'MRP' WHEN 1 THEN 'Kanban' ELSE 'Não Aplicável' END AS politica_estoque " +
                              "FROM " +
                              "  public.material " +
                              "  LEFT JOIN public.unidade_medida ON (public.material.id_unidade_medida = public.unidade_medida.id_unidade_medida) " +
                              "  LEFT JOIN public.unidade_medida u2 ON (public.material.id_unidade_medida_compra = u2.id_unidade_medida) " +
                              "  LEFT JOIN public.familia_material ON (public.material.id_familia_material = public.familia_material.id_familia_material) " +
                              "  LEFT JOIN public.agrupador_material ON (public.agrupador_material.id_agrupador_material = public.familia_material.id_agrupador_material) " +
                              "WHERE " +
                              filter +
                              "ORDER BY " +
                              "  mat_descricao";

                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.conn);
                if (adapter != null)
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    bindingMat.DataSource = ds.Tables[0];

                    dgvMaterial.AutoGenerateColumns = true;
                    dgvMaterial.DataSource = bindingMat;

                    dgvMaterial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvMaterial.MultiSelect = false;
                    dgvMaterial.ReadOnly = false;
                    this.dgvMaterial.Columns[0].Visible = false;
                    this.dgvMaterial.Columns[1].ReadOnly = false;
                    this.dgvMaterial.Columns[2].ReadOnly = false;
                    this.dgvMaterial.Columns[3].ReadOnly = true;
                    this.dgvMaterial.Columns[4].ReadOnly = true;
                    this.dgvMaterial.Columns[5].ReadOnly = true;
                    this.dgvMaterial.Columns[6].ReadOnly = true;
                    this.dgvMaterial.Columns[7].ReadOnly = true;
                    this.dgvMaterial.Columns[8].ReadOnly = true;
                    this.dgvMaterial.Columns[9].ReadOnly = true;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvMaterial.Columns[1], "", 30, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvMaterial.Columns[2], "Quantidade", 80, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvMaterial.Columns[3], "Material", 120, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvMaterial.Columns[4], "Descrição", 150, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvMaterial.Columns[5], "Descrição Adicional", 150, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvMaterial.Columns[6], "Dimensão 1", 80, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvMaterial.Columns[7], "Dimensão 2", 80, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvMaterial.Columns[8], "Dimensão 3", 80, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvMaterial.Columns[9], "Unidade Compra", 80, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvMaterial.Columns[10], "Politica Estoque", 100, DataGridViewAutoSizeColumnMode.None, true);

                    DataGridViewColumn column2 = dgvMaterial.Columns["selecao"];
                    DataGridViewCheckBoxColumn tmp2 = null;

                    tmp2 = new DataGridViewCheckBoxColumn();
                    tmp2.FalseValue = "0";
                    tmp2.TrueValue = "1";
                    tmp2.DataPropertyName = column2.DataPropertyName;
                    tmp2.DisplayIndex = column2.DisplayIndex;
                    tmp2.ReadOnly = column2.ReadOnly;
                    tmp2.AutoSizeMode = column2.AutoSizeMode;
                    tmp2.Width = column2.Width;
                    tmp2.Name = column2.Name;
                    tmp2.HeaderText = column2.HeaderText;
                    dgvMaterial.Columns.Remove(tmp2.Name);
                    dgvMaterial.Columns.Add(tmp2);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(this, "Erro ao carregar o grid de materiais.\r\n" + e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }

        }

        private void loadGridEpi()
        {
            try
            {
                bindingEpi = new BindingSource();
                string filter = " ( " +
                    " UPPER(epi_identificacao) LIKE '%" + this.txtBusca.Text.Trim().ToUpper() + "%' " +
                    " OR UPPER(epi_descricao) LIKE '%" + this.txtBusca.Text.Trim().ToUpper() + "%' " +
                    " OR UPPER(epi_descricao_adicional) LIKE '%" + this.txtBusca.Text.Trim().ToUpper() + "%' " +
                    " OR LOWER(epi_identificacao) LIKE '%" + this.txtBusca.Text.Trim().ToLower() + "%' " +
                    " OR LOWER(epi_descricao) LIKE '%" + this.txtBusca.Text.Trim().ToLower() + "%' " +
                    " OR LOWER(epi_descricao_adicional) LIKE '%" + this.txtBusca.Text.Trim().ToLower() + "%' " +
                    " ) ";


                string sql = "SELECT  " +
                              "  public.epi.id_epi, " +
                              "  0 AS selecao, " +
                              "  0.0 AS quantidade, " +
                              "  public.epi.epi_identificacao, " +
                              "  public.epi.epi_descricao, " +
                              "  public.epi.epi_descricao_adicional, " +
                              "  CASE WHEN u2.unm_abreviada IS NOT NULL THEN u2.unm_abreviada ELSE public.unidade_medida.unm_abreviada END as unidade, " +
                              "  'Kanban' AS politica_estoque " +
                              "FROM " +
                              "  public.epi " +
                              "  JOIN public.unidade_medida ON (public.epi.id_unidade_medida_uso = public.unidade_medida.id_unidade_medida) " +
                              "  LEFT JOIN public.unidade_medida u2 ON (public.epi.id_unidade_medida_compra = u2.id_unidade_medida) " +
                              "WHERE " +
                              filter +
                              "ORDER BY " +
                              "  epi_identificacao";

                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.conn);
                if (adapter != null)
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    bindingEpi.DataSource = ds.Tables[0];

                    dgvEpi.AutoGenerateColumns = true;
                    dgvEpi.DataSource = bindingEpi;

                    dgvEpi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvEpi.MultiSelect = false;
                    dgvEpi.ReadOnly = false;
                    this.dgvEpi.Columns[0].Visible = false;
                    this.dgvEpi.Columns[1].ReadOnly = false;
                    this.dgvEpi.Columns[2].ReadOnly = false;
                    this.dgvEpi.Columns[3].ReadOnly = true;
                    this.dgvEpi.Columns[4].ReadOnly = true;
                    this.dgvEpi.Columns[5].ReadOnly = true;
                    this.dgvEpi.Columns[6].ReadOnly = true;
                    this.dgvEpi.Columns[7].ReadOnly = true;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvEpi.Columns[1], "", 30, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvEpi.Columns[2], "Quantidade", 80, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvEpi.Columns[3], "Epi", 120, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvEpi.Columns[4], "Descrição", 150, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvEpi.Columns[5], "Descrição Adicional", 150, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvEpi.Columns[6], "Unidade Compra", 80, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvEpi.Columns[7], "Politica Estoque", 100, DataGridViewAutoSizeColumnMode.None, true);

                    DataGridViewColumn column2 = dgvEpi.Columns["selecao"];
                    DataGridViewCheckBoxColumn tmp2 = null;

                    tmp2 = new DataGridViewCheckBoxColumn();
                    tmp2.FalseValue = "0";
                    tmp2.TrueValue = "1";
                    tmp2.DataPropertyName = column2.DataPropertyName;
                    tmp2.DisplayIndex = column2.DisplayIndex;
                    tmp2.ReadOnly = column2.ReadOnly;
                    tmp2.AutoSizeMode = column2.AutoSizeMode;
                    tmp2.Width = column2.Width;
                    tmp2.Name = column2.Name;
                    tmp2.HeaderText = column2.HeaderText;
                    dgvEpi.Columns.Remove(tmp2.Name);
                    dgvEpi.Columns.Add(tmp2);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(this, "Erro ao carregar o grid de EPIs.\r\n" + e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void updateSearch()
        {
            try
            {
                string filterMat = " codigo LIKE '%" + this.txtBusca.Text.Trim() + "%' " +
                                   " OR mat_descricao LIKE '%" + this.txtBusca.Text.Trim() + "%' ";

                string filterProd = " pro_codigo LIKE '%" + this.txtBusca.Text.Trim()+ "%' " +
                                    " OR pro_codigo_cliente LIKE '%" + this.txtBusca.Text.Trim() + "%' " +
                                    " OR pro_descricao LIKE '%" + this.txtBusca.Text.Trim() + "%' ";

                string filterSol = " identificacao LIKE '%" + this.txtBusca.Text.Trim() + "%' ";

                string filterEpi = " epi_identificacao LIKE '%" + this.txtBusca.Text.Trim() + "%' " +
                                  " OR epi_descricao LIKE '%" + this.txtBusca.Text.Trim() + "%' ";

                if (rdbProduto.Checked)
                {
                    bindingProd.Filter = filterProd;
                }
                else
                {
                    if (rdbMaterial.Checked)
                    {
                        bindingMat.Filter = filterMat;

                    }else
                    {
                        if (rdbSolCompra.Checked)
                        {
                            bindingSol.Filter = filterSol;
                        }else
                        {
                            bindingEpi.Filter = filterEpi;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao realizar a busca.\r\n" + e.Message);
            }
        }

        private void next()
        {
            try
            {
                Dictionary<long, OrcamentoCompraClass> orcamentos = new Dictionary<long, OrcamentoCompraClass>();

                //Percorre dataGrid de produtos
                for (int i = 0; i < dgvProduto.RowCount; i++)
                {
                    //Verifica se o produto foi selecionado (checked)
                    if (dgvProduto.Rows[i].Cells[1].Value.ToString() == "1")
                    {
                        int idProd = Convert.ToInt32(dgvProduto.Rows[i].Cells[0].Value);
                        double qtd = Convert.ToDouble(dgvProduto.Rows[i].Cells[2].Value);

                        //Carrega o produto
                        ProdutoClass produto = ProdutoBaseClass.GetEntidade(idProd, LoginClass.UsuarioLogado.loggedUser, this.conn);

                        if (produto.CollectionProdutoFornecedorClassProduto.Where(a=>a.Ativo).ToList().Count == 0)
                        {
                            MessageBox.Show("O produto: " + produto.Codigo + " não possui fornecedor cadastrado e será ignorado na montagem do orçamento.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            //Percorre os fornecedores do produto
                            foreach (ProdutoFornecedorClass fornecedor in produto.CollectionProdutoFornecedorClassProduto.Where(a => a.Ativo).ToList())
                            {
                                //Caso o ja exista um orçamento do fornecedor => Add. o produto no "orcamentoCompraItemList"
                                if (orcamentos.ContainsKey(fornecedor.Fornecedor.ID))
                                {
                                    orcamentos[fornecedor.Fornecedor.ID].addItem(idProd, null, null, qtd,conn);
                                }
                                else
                                {
                                    //Caso não exista um orçamento do fornecedor => Cria um novo orçamento => Add. orçamento no "Dictionary<int,OrcamentoCompraClass>" => Add. o produto no "orcamentoCompraItemList"
                                    orcamentos.Add(fornecedor.Fornecedor.ID,
                                                   new OrcamentoCompraClass(null,
                                                                            fornecedor.Fornecedor.ID,
                                                                            fornecedor.Fornecedor.RazaoSocial,
                                                                            LoginClass.UsuarioLogado.loggedUser,
                                                                            Configurations.DataIndependenteClass.GetData(),
                                                                            Convert.ToInt32(this.nudPrazo.Value),
                                                                            SituacaoOrcComp.Nova,
                                                                            this.logoEmpresa));
                                    orcamentos[fornecedor.Fornecedor.ID].addItem(idProd, null, null, qtd,conn);
                                }
                            }
                        }
                    }
                }

                //Percorre dataGrid de material
                for (int j = 0; j < dgvMaterial.RowCount; j++)
                {
                    //Verifica se o material foi selecionado (checked)
                    if (dgvMaterial.Rows[j].Cells[1].Value.ToString() == "1")
                    {
                        int idMat = Convert.ToInt32(dgvMaterial.Rows[j].Cells[0].Value);
                        double qtd = Convert.ToDouble(dgvMaterial.Rows[j].Cells[2].Value);

                        //Carrega o material
                        MaterialClass material = MaterialBaseClass.GetEntidade(idMat, LoginClass.UsuarioLogado.loggedUser, this.conn);

                        if (material.CollectionMaterialFornecedorClassMaterial.Where(a => a.Ativo).ToList().Count == 0)
                        {
                            MessageBox.Show("O material: " + material.CodigoComFamilia + " não possui fornecedor cadastrado e será ignorado na montagem do orçamento.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            //Percorre os fornecedores do material
                            foreach (MaterialFornecedorClass fornecedor in material.CollectionMaterialFornecedorClassMaterial.Where(a => a.Ativo).ToList())
                            {
                                //Caso o ja exista um orçamento do fornecedor => Add. o material no "orcamentoCompraItemList"
                                if (orcamentos.ContainsKey(fornecedor.Fornecedor.ID))
                                {
                                    orcamentos[fornecedor.ID].addItem(null, idMat, null, qtd,conn);
                                }
                                else
                                {
                                    //Caso não exista um orçamento do fornecedor => Cria um novo orçamento => Add. orçamento no "Dictionary<int,OrcamentoCompraClass>" => Add. o material no "orcamentoCompraItemList"
                                    orcamentos.Add(fornecedor.Fornecedor.ID,
                                                   new OrcamentoCompraClass( null, fornecedor.Fornecedor.ID,
                                                                            fornecedor.Fornecedor.RazaoSocial,
                                                                            LoginClass.UsuarioLogado.loggedUser,
                                                                            Configurations.DataIndependenteClass.GetData(),
                                                                            Convert.ToInt32(this.nudPrazo.Value),
                                                                            SituacaoOrcComp.Nova,
                                                                            this.logoEmpresa));
                                    orcamentos[fornecedor.Fornecedor.ID].addItem(null, idMat, null, qtd,conn);
                                }
                            }
                        }
                    }
                }

                //Percorre dataGrid de solicitações de compra
                for (int k = 0; k < dgvSolicitacaoCompra.RowCount; k++)
                {
                    //Verifica se a solicitação foi selecionada (checked)
                    if (dgvSolicitacaoCompra.Rows[k].Cells[1].Value.ToString() == "1")
                    {
                        int idSolicitacao =
                            Convert.ToInt32(dgvSolicitacaoCompra.Rows[k].Cells["id_solicitacao_compra"].Value);

                        //Carrega a solicitação
                        SolicitacaoCompraClass solicitacao = new SolicitacaoCompraClass(idSolicitacao, null,
                                                                                        LoginClass.UsuarioLogado.
                                                                                            loggedUser,
                                                                                        this.conn);

                        //Verifica se a solicitação de compra é de PRODUTO ou MATERIAL e carrega o mesmo no orçamento

                        //Produto
                        if (solicitacao.Produto != null)
                        {
                            //Carrega o produto
                            ProdutoClass produto = solicitacao.Produto;

                            if (produto.CollectionProdutoFornecedorClassProduto.Where(a => a.Ativo).ToList().Count == 0)
                            {
                                MessageBox.Show(
                                    "O produto: " + produto.Codigo +
                                    " não possui fornecedor cadastrado e será ignorado na montagem do orçamento.",
                                    "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                //Percorre os fornecedores do produto
                                foreach (ProdutoFornecedorClass fornecedor in produto.CollectionProdutoFornecedorClassProduto.Where(a => a.Ativo).ToList())
                                {
                                    //Caso o ja exista um orçamento do fornecedor => Add. o produto no "orcamentoCompraItemList"
                                    if (orcamentos.ContainsKey(fornecedor.Fornecedor.ID))
                                    {
                                        orcamentos[fornecedor.Fornecedor.ID].addItem(produto.ID, null, null,
                                                                                    solicitacao.Quantidade,conn);
                                    }
                                    else
                                    {
                                        //Caso não exista um orçamento do fornecedor => Cria um novo orçamento => Add. orçamento no "Dictionary<int,OrcamentoCompraClass>" => Add. o produto no "orcamentoCompraItemList"
                                        orcamentos.Add(fornecedor.Fornecedor.ID,
                                                       new OrcamentoCompraClass(null, fornecedor.Fornecedor.ID,
                                                                                fornecedor.Fornecedor.RazaoSocial,
                                                                                LoginClass.UsuarioLogado.loggedUser,
                                                                                Configurations.DataIndependenteClass.GetData(),
                                                                                Convert.ToInt32(this.nudPrazo.Value),
                                                                                SituacaoOrcComp.Nova,
                                                                                this.logoEmpresa));
                                        orcamentos[fornecedor.Fornecedor.ID].addItem(produto.ID, null, null,
                                                                                    solicitacao.Quantidade,conn);
                                    }
                                }
                            }
                        }
                        else
                        {
                            //Material
                            if (solicitacao.Material != null)
                            {
                                //Carrega o material
                                MaterialClass material = solicitacao.Material;

                                if (material.CollectionMaterialFornecedorClassMaterial.Where(a => a.Ativo).ToList().Count == 0)
                                {
                                    MessageBox.Show(
                                        "O material: " + material.CodigoComFamilia +
                                        " não possui fornecedor cadastrado e será ignorado na montagem do orçamento.",
                                        "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    //Percorre os fornecedores do material
                                    foreach (MaterialFornecedorClass fornecedor in material.CollectionMaterialFornecedorClassMaterial.Where(a => a.Ativo).ToList())
                                    {
                                        //Caso o ja exista um orçamento do fornecedor => Add. o material no "orcamentoCompraItemList"
                                        if (orcamentos.ContainsKey(fornecedor.Fornecedor.ID))
                                        {
                                            orcamentos[fornecedor.Fornecedor.ID].addItem(null, material.ID, null,
                                                                                        solicitacao.Quantidade,conn);
                                        }
                                        else
                                        {
                                            //Caso não exista um orçamento do fornecedor => Cria um novo orçamento => Add. orçamento no "Dictionary<int,OrcamentoCompraClass>" => Add. o material no "orcamentoCompraItemList"
                                            orcamentos.Add(fornecedor.Fornecedor.ID,
                                                           new OrcamentoCompraClass(null, fornecedor.Fornecedor.ID,
                                                                                    fornecedor.Fornecedor.RazaoSocial,
                                                                                    LoginClass.UsuarioLogado.loggedUser,
                                                                                    Configurations.DataIndependenteClass.GetData(),
                                                                                    Convert.ToInt32(this.nudPrazo.Value),
                                                                                    SituacaoOrcComp.Nova,
                                                                                    this.logoEmpresa));
                                            orcamentos[fornecedor.Fornecedor.ID].addItem(null, material.ID, null,
                                                                                        solicitacao.Quantidade,conn);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                //Epi
                                if (solicitacao.Epi != null)
                                {
                                    //Carrega o Epi
                                    EpiClass epi = solicitacao.Epi;

                                    if (epi.CollectionEpiFornecedorClassEpi.Where(a => a.Ativo).ToList().Count == 0)
                                    {
                                        MessageBox.Show("O epi : " + epi.Identificacao + " não possui fornecedor cadastrado e será ignorado na montagem do orçamento.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        //Percorre os fornecedores do Epi
                                        foreach (EpiFornecedorClass fornecedor in epi.CollectionEpiFornecedorClassEpi.Where(a => a.Ativo).ToList())
                                        {
                                            //Caso o ja exista um orçamento do fornecedor => Add. o material no "orcamentoCompraItemList"
                                            if (orcamentos.ContainsKey(fornecedor.Fornecedor.ID))
                                            {
                                                orcamentos[fornecedor.Fornecedor.ID].addItem(null, null, epi.ID, solicitacao.Quantidade,conn);
                                            }
                                            else
                                            {
                                                //Caso não exista um orçamento do fornecedor => Cria um novo orçamento => Add. orçamento no "Dictionary<int,OrcamentoCompraClass>" => Add. o material no "orcamentoCompraItemList"
                                                orcamentos.Add(fornecedor.Fornecedor.ID,
                                                               new OrcamentoCompraClass(null, fornecedor.Fornecedor.ID,
                                                                                        fornecedor.Fornecedor.RazaoSocial,
                                                                                        LoginClass.UsuarioLogado.loggedUser,
                                                                                        Configurations.DataIndependenteClass.GetData(),
                                                                                        Convert.ToInt32(this.nudPrazo.Value),
                                                                                        SituacaoOrcComp.Nova,
                                                                                        this.logoEmpresa));
                                                orcamentos[fornecedor.Fornecedor.ID].addItem(null, null, epi.ID, solicitacao.Quantidade,conn);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    
                }

                //Percorre dataGrid de Epi
                for (int j = 0; j < dgvEpi.RowCount; j++)
                {
                    //Verifica se o Epi foi selecionado (checked)
                    if (dgvEpi.Rows[j].Cells[1].Value.ToString() == "1")
                    {
                        int idEpi = Convert.ToInt32(dgvEpi.Rows[j].Cells[0].Value);
                        double qtd = Convert.ToDouble(dgvEpi.Rows[j].Cells[2].Value);

                        //Carrega o Epi
                        EpiClass epi = EpiBaseClass.GetEntidade(idEpi, LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);

                        if (epi.CollectionEpiFornecedorClassEpi.Where(a => a.Ativo).ToList().Count == 0)
                        {
                            MessageBox.Show("O epi : " + epi.Identificacao + " não possui fornecedor cadastrado e será ignorado na montagem do orçamento.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            //Percorre os fornecedores do Epi
                            foreach (EpiFornecedorClass fornecedor in epi.CollectionEpiFornecedorClassEpi.Where(a => a.Ativo).ToList())
                            {
                                //Caso o ja exista um orçamento do fornecedor => Add. o material no "orcamentoCompraItemList"
                                if (orcamentos.ContainsKey(fornecedor.Fornecedor.ID))
                                {
                                    orcamentos[fornecedor.Fornecedor.ID].addItem(null, null, epi.ID, qtd,conn);
                                }
                                else
                                {
                                    //Caso não exista um orçamento do fornecedor => Cria um novo orçamento => Add. orçamento no "Dictionary<int,OrcamentoCompraClass>" => Add. o material no "orcamentoCompraItemList"
                                    orcamentos.Add(fornecedor.Fornecedor.ID,
                                                   new OrcamentoCompraClass(null, fornecedor.Fornecedor.ID,
                                                                            fornecedor.Fornecedor.RazaoSocial,
                                                                            LoginClass.UsuarioLogado.loggedUser,
                                                                            Configurations.DataIndependenteClass.GetData(),
                                                                            Convert.ToInt32(this.nudPrazo.Value),
                                                                            SituacaoOrcComp.Nova,
                                                                            this.logoEmpresa));
                                    orcamentos[fornecedor.Fornecedor.ID].addItem(null, null, epi.ID, qtd,conn);
                                }
                            }
                        }
                    }
                }

                if (orcamentos.Count > 0)
                {
                    OrcamentoCompraForm2 form = new OrcamentoCompraForm2(orcamentos, this.conn, this);
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Selecione um produto, material ou epi.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, "Erro na montagem dos orçamentos.\r\n" + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #region Eventos

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.next();
        }

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                this.timer1.Enabled = false;
                this.updateSearch();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMaterial_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                double temp = 0;
                if (!double.TryParse(e.FormattedValue.ToString(), out temp))
                {
                    dgvMaterial.Rows[e.RowIndex].ErrorText = "Quantidade inválida";
                    MessageBox.Show(this, "Quantidade inválida para o material: " + dgvMaterial.Rows[e.RowIndex].Cells["codigo"].Value, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
        }

        private void dgvMaterial_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // If the data source raises an exception when a cell value is 
            // commited, display an error message.
            if (e.Exception != null)
            {
                if ((e.Context & DataGridViewDataErrorContexts.Parsing) != 0)
                {
                    dgvMaterial.Rows[e.RowIndex].ErrorText = "Quantidade inválida";
                    MessageBox.Show(this, "Quantidade inválida para o material: " + dgvMaterial.Rows[e.RowIndex].Cells["codigo"].Value, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvProduto_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                double temp = 0;
                if (!double.TryParse(e.FormattedValue.ToString(), out temp))
                {
                    dgvProduto.Rows[e.RowIndex].ErrorText = "Quantidade inválida";
                    MessageBox.Show(this, "Quantidade inválida para o produto: " + dgvProduto.Rows[e.RowIndex].Cells["pro_codigo"].Value, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
        }

        private void dgvProduto_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // If the data source raises an exception when a cell value is 
            // commited, display an error message.
            if (e.Exception != null)
            {
                if ((e.Context & DataGridViewDataErrorContexts.Parsing) != 0)
                {
                    dgvProduto.Rows[e.RowIndex].ErrorText = "Quantidade inválida";
                    MessageBox.Show(this, "Quantidade inválida para o produto: " + dgvProduto.Rows[e.RowIndex].Cells["pro_codigo"].Value, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvEpi_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // If the data source raises an exception when a cell value is 
            // commited, display an error message.
            if (e.Exception != null)
            {
                if ((e.Context & DataGridViewDataErrorContexts.Parsing) != 0)
                {
                    dgvEpi.Rows[e.RowIndex].ErrorText = "Quantidade inválida";
                    MessageBox.Show(this, "Quantidade inválida para o epi: " + dgvEpi.Rows[e.RowIndex].Cells["epi_identificacao"].Value, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvEpi_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                double temp = 0;
                if (!double.TryParse(e.FormattedValue.ToString(), out temp))
                {
                    dgvEpi.Rows[e.RowIndex].ErrorText = "Quantidade inválida";
                    MessageBox.Show(this, "Quantidade inválida para o epi: " + dgvEpi.Rows[e.RowIndex].Cells["epi_identificacao"].Value, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
        }

        private void rdbProduto_CheckedChanged(object sender, EventArgs e)
        {
            this.dgvProduto.Visible = rdbProduto.Checked;
            this.dgvMaterial.Visible = rdbMaterial.Checked;
            this.dgvSolicitacaoCompra.Visible = rdbSolCompra.Checked;
            this.dgvEpi.Visible = rdbEpi.Checked;

            this.lblTipo.Text = "Produtos";

        }

        private void rdbMaterial_CheckedChanged(object sender, EventArgs e)
        {
            this.dgvProduto.Visible = rdbProduto.Checked;
            this.dgvMaterial.Visible = rdbMaterial.Checked;
            this.dgvSolicitacaoCompra.Visible = rdbSolCompra.Checked;
            this.dgvEpi.Visible = rdbEpi.Checked;

            this.lblTipo.Text = "Materiais";
        }

        private void rdbSolCompra_CheckedChanged(object sender, EventArgs e)
        {
            this.dgvProduto.Visible = rdbProduto.Checked;
            this.dgvMaterial.Visible = rdbMaterial.Checked;
            this.dgvSolicitacaoCompra.Visible = rdbSolCompra.Checked;
            this.dgvEpi.Visible = rdbEpi.Checked;

            this.lblTipo.Text = "Solicitações De Compra";
        }

        private void rdbEpi_CheckedChanged(object sender, EventArgs e)
        {
            this.dgvProduto.Visible = rdbProduto.Checked;
            this.dgvMaterial.Visible = rdbMaterial.Checked;
            this.dgvSolicitacaoCompra.Visible = rdbSolCompra.Checked;
            this.dgvEpi.Visible = rdbEpi.Checked;

            this.lblTipo.Text = "Epi";
        }

        private void dgvProduto_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvProduto.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        private void dgvMaterial_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvMaterial.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        private void dgvEpi_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvEpi.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        #endregion

        

      

     
       

        

        

        

      
        
               
       
    }
}
