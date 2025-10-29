#region Referencias

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.SDC;
using BibliotecaEntidades.SDC.dto;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;
using ProjectConstants;
using dbProvider;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using SolicitacaoCompraClass = BibliotecaEntidades.Operacoes.Compras.SolicitacaoCompraClass;

#endregion

namespace BibliotecaCompras
{
    public enum TipoTelaSolicitacao
    {
        Todos,
        AguardandoCompras,
        AguardandoRecebimento,
        Abertas,
        TodasLiberadas
    }

    public partial class SolicitacaoCompraListForm : IWTBaseForm
    {
        private readonly IWTPostgreNpgsqlConnection conn;
        private readonly AcsUsuarioClass _acsUsuario;
        private BindingSource binding;

        private readonly int diasVerde;
        private readonly int diasAmarelo;
        private readonly int diasVermelho;
        private readonly int mesesMedia;
        private readonly double categoriaAAcimaDe;
        private readonly double categoriaBAcimaDe;
        private readonly double margemAvisoKB;


        private readonly int diasPCP;

        private readonly int leadtimeCompras;
        private readonly double sugeridoAcimaCompras;
        private readonly double disparoSolicitacaoAuto;
        private readonly string tipoCalculoSemana;
        private readonly string diaCalculoSemana;

        private readonly TipoTelaSolicitacao tipoTelaSolicitacao;

        private List<int> compradores;

        private readonly int? idOrdemCompra;

        private bool _exibindoDadosAdicionais = false;

        public SolicitacaoCompraListForm(
            int diasVerde,
            int diasAmarelo, int diasVermelho, int mesesMedia,
            double categoriaAAcimaDe, double categoriaBAcimaDe,
            double margemAvisoKB,
            int diasPCP,
            int leadtimeCompras,
            double sugeridoAcimaCompras, double disparoSolicitacaoAuto,
            string tipoCalculoSemana, string diaCalculoSemana,
            TipoTelaSolicitacao tipoTelaSolicitacao,
            int? idOrdemCompra,
            IWTPostgreNpgsqlConnection conn, AcsUsuarioClass _acsUsuario)
        {
            InitializeComponent();
            this.conn = conn;
            this._acsUsuario = _acsUsuario;
            this.diasVerde = diasVerde;
            this.diasAmarelo = diasAmarelo;
            this.diasVermelho = diasVermelho;
            this.mesesMedia = mesesMedia;
            this.categoriaAAcimaDe = categoriaAAcimaDe;
            this.categoriaBAcimaDe = categoriaBAcimaDe;
            this.margemAvisoKB = margemAvisoKB;
            this.diasPCP = diasPCP;

            this.leadtimeCompras = leadtimeCompras;
            this.sugeridoAcimaCompras = sugeridoAcimaCompras;
            this.disparoSolicitacaoAuto = disparoSolicitacaoAuto;

            this.tipoCalculoSemana = tipoCalculoSemana;
            this.diaCalculoSemana = diaCalculoSemana;

            this.idOrdemCompra = idOrdemCompra;

            if (this.idOrdemCompra != null)
            {
                this.btnCancelar.Visible = false;
                this.btnAprovacaoPCP.Visible = false;
                this.btnExcluir.Visible = false;
                this.btnNovo.Visible = false;

                this.chkNovas.Checked = false;

                this.chkOc.Enabled = false;
                this.nudOC.Enabled = false;
            }

            this.tipoTelaSolicitacao = tipoTelaSolicitacao;


            this.initializeComboComprador();

            this.rdbCompradorAtual.Checked = true;
            this.cmbComprador.Enabled = false;

            this.setScreenMode();

            this.initializeGrid();

            if (IWTConfiguration.Conf.getBoolConf(ProjectConstants.Constants.SIMULADOR_COMPRAS_HABILITADO))
            {
                btnGerarOC.Visible = false;
            }



        }

        private void setScreenMode()
        {
            try
            {
                switch (TipoModulo.Tipo)
                {
                    case TipoForm.Expedicao:
                        this.btnAprovacaoPCP.Visible = false;
                        this.btnNovo.Visible = false;
                        this.btnCancelar.Visible = false;
                        this.btnExcluir.Visible = false;
                        this.btnGerenciarFeedbaks.Visible = false;
                        this.rdbTodosCompradores.Checked = true;

                        switch (tipoTelaSolicitacao)
                        {
                            case TipoTelaSolicitacao.AguardandoCompras:
                                this.chkAprovadasPCP.Checked = true;
                                this.chkNovas.Checked = false;
                                this.groupBox1.Enabled = false;
                                this.btnGerarOC.Visible = true;
                                break;
                            case TipoTelaSolicitacao.AguardandoRecebimento:
                                this.chkCompradas.Checked = true;
                                this.chkRecebidasParcial.Checked = true;
                                this.chkNovas.Checked = false;
                                this.groupBox1.Enabled = false;
                                this.btnGerarOC.Visible = false;

                                break;
                            case TipoTelaSolicitacao.Abertas:
                                this.chkAprovadasCompras.Checked = true;
                                this.chkAprovadasPCP.Checked = true;
                                this.chkCompradas.Checked = true;
                                this.chkRecebidasParcial.Checked = true;
                                this.chkNovas.Checked = true;
                                this.groupBox1.Enabled = false;
                                this.btnGerarOC.Visible = false;
                                break;
                            case TipoTelaSolicitacao.Todos:
                                this.btnGerarOC.Visible = false;
                                break;
                            case TipoTelaSolicitacao.TodasLiberadas:
                                this.chkAprovadasCompras.Checked = true;
                                this.chkAprovadasPCP.Checked = true;
                                this.chkCompradas.Checked = true;
                                this.chkRecebidasParcial.Checked = true;
                                this.chkNovas.Checked = false;
                                this.groupBox1.Enabled = false;
                                this.btnGerarOC.Visible = false;
                                this.btnEditar.Visible = false;
                                break;


                        }
                        break;




                    case TipoForm.Compras:
                        this.btnAprovacaoPCP.Visible = false;
                        this.btnNovo.Visible = false;
                        this.btnCancelar.Visible = false;
                        this.btnExcluir.Visible = false;
                        this.btnGerenciarFeedbaks.Visible = true;
                      

                        switch (tipoTelaSolicitacao)
                        {
                            case TipoTelaSolicitacao.AguardandoCompras:
                                this.chkAprovadasPCP.Checked = true;
                                this.chkNovas.Checked = false;
                                this.groupBox1.Enabled = false;
                                this.btnGerarOC.Visible = true;
                                break;
                            case TipoTelaSolicitacao.AguardandoRecebimento:
                                this.chkCompradas.Checked = true;
                                this.chkRecebidasParcial.Checked = true;
                                this.chkNovas.Checked = false;
                                this.groupBox1.Enabled = false;
                                this.btnGerarOC.Visible = false;

                                break;
                            case TipoTelaSolicitacao.Abertas:
                                this.chkAprovadasCompras.Checked = true;
                                this.chkAprovadasPCP.Checked = true;
                                this.chkCompradas.Checked = true;
                                this.chkRecebidasParcial.Checked = true;
                                this.chkNovas.Checked = true;
                                this.groupBox1.Enabled = false;
                                this.btnGerarOC.Visible = false;
                                break;
                            case TipoTelaSolicitacao.Todos:
                                this.btnGerarOC.Visible = false;
                                break;


                        }
                        break;

                    default:
                        this.btnGerarOC.Visible = false;
                        this.btnGerenciarFeedbaks.Visible = false;
                        break;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao definir o tipo da tela.\r\n" + e.Message, e);
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
                filter += " AND ( " +
                          " UPPER(identificacao) LIKE '%" + this.txtBusca.Text.Trim().ToUpper() + "%' " +
                          " OR UPPER(aus_login) LIKE '%" + this.txtBusca.Text.Trim().ToUpper() + "%' " +
                          " OR UPPER(usuPCP) LIKE '%" + this.txtBusca.Text.Trim().ToUpper() + "%' " +
                          " OR LOWER(identificacao) LIKE '%" + this.txtBusca.Text.Trim().ToLower() + "%' " +
                          " OR LOWER(aus_login) LIKE '%" + this.txtBusca.Text.Trim().ToLower() + "%' " +
                          " OR LOWER(usuPCP) LIKE '%" + this.txtBusca.Text.Trim().ToLower() + "%' " +
                          " OR LOWER(for_razao_social) LIKE '%" + this.txtBusca.Text.Trim().ToLower() + "%' " +
                          " OR LOWER(for_razao_social) LIKE '%" + this.txtBusca.Text.Trim().ToLower() + "%' " +
                          ") ";
            }

            if (this.nudSC.Enabled)
            {
                filter += " AND ( " +
                          " tab.id_solicitacao_compra = " + this.nudSC.Value.ToString() + " " +
                          ") ";
            }


            string compradorSearch = "";

            if (this.rdbBuscaComprador.Checked)
            {
                if (this.cmbComprador.SelectedValue != null)
                {
                    compradorSearch += " OR ( tab.id_comprador = " + this.cmbComprador.SelectedValue + " ) ";
                }
            }
            else
            {
                if (this.rdbCompradorAtual.Checked)
                {
                    compradorSearch += " OR ( tab.id_comprador IS NULL ) ";

                    if (this.compradores != null)
                    {
                        for (int i = 0; i < this.compradores.Count; i++)
                        {
                            compradorSearch += " OR ( tab.id_comprador = " + this.compradores[i] + " ) ";
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(compradorSearch))
            {
                filter += " AND (" + compradorSearch.Substring(3) + ") ";
            }


            string filterStatus = "";
            if (this.chkNovas.Checked)
            {
                filterStatus += " OR tab.status = 0 ";
            }

            if (this.chkAprovadasPCP.Checked)
            {
                filterStatus += " OR tab.status = 1 ";
            }

            if (this.chkAprovadasCompras.Checked)
            {
                filterStatus += " OR tab.status = 2 ";
            }

            if (this.chkCompradas.Checked)
            {
                filterStatus += " OR tab.status = 3 ";
            }

            if (this.chkRecebidasParcial.Checked)
            {
                filterStatus += " OR tab.status = 4 ";
            }

            if (this.chkRecebidas.Checked)
            {
                filterStatus += " OR tab.status = 5 ";
            }

            if (this.chkCanceladas.Checked)
            {
                filterStatus += " OR tab.status = 6 ";
            }

            if (filterStatus.Length > 0)
            {
                filter += " AND (" + filterStatus.Substring(3) + ") ";
            }

            if (this.idOrdemCompra != null)
            {
                filter += " AND tab.id_ordem_compra = " + this.idOrdemCompra;
            }
            else
            {
                if (this.nudOC.Enabled)
                {
                    filter += " AND ( " +
                              " tab.id_ordem_compra = " + this.nudOC.Value.ToString() + " " +
                              ") ";
                }
            }

            if (filter.Length > 0)
            {
                filter = " WHERE " + filter.Substring(4);
            }

            string filter2 = "";
            if (txtRecebimentos.Enabled && txtRecebimentos.Visible && !string.IsNullOrWhiteSpace(txtRecebimentos.Text))
            {
                filter2 = " HAVING iwt_agregate_clientes_nf('NF '||  public.lote.lot_nf_numero || ' ('||to_char(public.lote.lot_data_recebimento,'DD/MM/YYYY')||')') LIKE '%" + txtRecebimentos.Text + "%' ";
            }

            string sql =
                "SELECT                                                                                                                         " +

                "  tab.identificacao,                                                                                                           " +
                "  tab.medida, " +
                "  tab.descricao, " +
                "  tab.descricao2, " +
                "  tab.soc_unidade_compra, " +
                "  tab.codigo_interno, " +
                "  tab.politica_estoque, " +
                "  CASE tab.estoque_seguranca_tipo WHEN 1 THEN 'Verde' WHEN 2 THEN 'Amarelo' WHEN 3 THEN 'Vermelho' ELSE '' END, " +
                "  tab.estoque_seguranca, " +
                "  tab.id_solicitacao_compra,                                                                                                   " +
                "  tab.soc_qtd,                                                                                                                 " +
                "  tab.soc_data_abertura,                                                                                                       " +
                "  CAST(tab.soc_data_abertura + interval '" + diasPCP + " day' AS date) as limitePCP, " +
                "  tab.soc_data_aprovacao_pcp, " +
                "  tab.id_ordem_compra, " +
                "   public.comprador.com_apelido, " +
                "  CAST(COALESCE(tab.soc_data_abertura, tab.soc_data_aprovacao_pcp) + interval '" + leadtimeCompras + " day' AS date) as limiteCompras, " +
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
                "  tab.status as stat_original, " +
                "  tab.id_comprador, " +
                "  scf_texto, " +
                "  iwt_agregate_clientes_nf('NF '||  public.lote.lot_nf_numero || ' ('||to_char(public.lote.lot_data_recebimento,'DD/MM/YYYY')||')') as recebimentos, " +
                "  soc_qtd_original, " +
                "  soc_entrega_prevista_original,  " +
                "  CASE soc_tipo_alocacao_estoque WHEN 0 THEN 'Matéria Prima' WHEN 1 THEN 'Consumo' ELSE '' END, " +
                "  soc_observacao " +
                "FROM (                                                                                                                         " +
                "SELECT  " +
                "  public.solicitacao_compra.id_solicitacao_compra, " +
                "  public.produto.pro_codigo AS identificacao, " +
                "  '' AS medida,  " +
                "  public.produto.pro_descricao as descricao,  " +
                "  public.produto.pro_descricao_adicional as descricao2,  " +
                "  COALESCE(public.solicitacao_compra.soc_unidade_compra, public.unidade_medida.unm_abreviada) as soc_unidade_compra,  " +
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
                "  COALESCE(public.ordem_compra.id_comprador, produto.id_comprador, classificacao_produto.id_comprador) as id_comprador, " +
                "  CAST(public.produto.id_produto as VARCHAR) as codigo_interno, " +
                "  soc_qtd_original, " +
                "  soc_entrega_prevista_original, " +
                "  soc_tipo_alocacao_estoque, " +
                "  soc_observacao " +
                "FROM " +
                "  public.solicitacao_compra " +
                "  INNER JOIN public.produto ON (public.solicitacao_compra.id_produto = public.produto.id_produto) " +
                "  INNER JOIN public.classificacao_produto ON (public.classificacao_produto.id_classificacao_produto = public.produto.id_classificacao_produto)   " +
                "  INNER JOIN public.acs_usuario ON (public.solicitacao_compra.id_acs_usuario = public.acs_usuario.id_acs_usuario) " +
                "  LEFT OUTER JOIN public.acs_usuario u2 ON (public.solicitacao_compra.id_acs_usuario_pcp = u2.id_acs_usuario) " +
                "  LEFT OUTER JOIN public.ordem_compra ON (public.solicitacao_compra.id_ordem_compra = public.ordem_compra.id_ordem_compra) " +
                "  LEFT OUTER JOIN public.fornecedor ON (public.ordem_compra.id_fornecedor = public.fornecedor.id_fornecedor) " +
                "  LEFT OUTER JOIN public.unidade_medida ON(public.produto.id_unidade_medida_compra = public.unidade_medida.id_unidade_medida) "+
                "UNION ALL																													        " +
                "SELECT  " +
                "  public.solicitacao_compra.id_solicitacao_compra, " +
                "  familia_material.fam_codigo || ' ' || public.material.mat_codigo || ' (M'||public.material.id_material||')' AS identificacao, " +
                "  replace( " +
                "  replace( " +
                "  replace( " +
                "    to_char(public.material.mat_medida,'FM99990D99999') || 'x' ||  " +
                "    to_char(public.material.mat_medida_largura,'FM99990D99999')|| 'x' || " +
                "    to_char(public.material.mat_medida_comprimento,'FM99990D99999')||' '" +
                "    , '0.x0.x0.','') " +
                "    , '.x','x') " +
                "    , '. ','') " +
                "  AS medida, " +
                "  public.material.mat_descricao as descricao, " +
                "  public.material.mat_descricao_adicional as descricao2, " +
                "  COALESCE(public.solicitacao_compra.soc_unidade_compra, public.unidade_medida.unm_abreviada) as soc_unidade_compra,  " +
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
                "  COALESCE(public.ordem_compra.id_comprador, material.id_comprador, familia_material.id_comprador) as id_comprador, " +
                "  'M'||CAST(public.material.id_material as VARCHAR) as codigo_interno, " +
                "  soc_qtd_original, " +
                "  soc_entrega_prevista_original, " +
                "  soc_tipo_alocacao_estoque, " +
                "  soc_observacao " +
                "FROM " +
                "  public.solicitacao_compra " +
                "  INNER JOIN public.material ON (public.solicitacao_compra.id_material = public.material.id_material) " +
                "  LEFT OUTER JOIN familia_material ON (public.material.id_familia_material = familia_material.id_familia_material) " +
                "  INNER JOIN public.acs_usuario ON (public.solicitacao_compra.id_acs_usuario = public.acs_usuario.id_acs_usuario) " +
                "  LEFT OUTER JOIN public.acs_usuario u2 ON (public.solicitacao_compra.id_acs_usuario_pcp = u2.id_acs_usuario) " +
                "  LEFT OUTER JOIN public.ordem_compra ON (public.solicitacao_compra.id_ordem_compra = public.ordem_compra.id_ordem_compra) " +
                "  LEFT OUTER JOIN public.fornecedor ON (public.ordem_compra.id_fornecedor = public.fornecedor.id_fornecedor) " +
                "  LEFT OUTER JOIN public.unidade_medida ON(public.material.id_unidade_medida_compra = public.unidade_medida.id_unidade_medida) " +
                "UNION ALL																													        " +
                "SELECT  " +
                "  public.solicitacao_compra.id_solicitacao_compra, " +
                "  public.epi.epi_identificacao AS identificacao, " +
                "  '' AS medida, " +
                "  public.epi.epi_descricao as descricao, " +
                "  public.epi.epi_descricao_adicional as descricao2, " +
                "  COALESCE(public.solicitacao_compra.soc_unidade_compra, public.unidade_medida.unm_abreviada) as soc_unidade_compra,  " +
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
                "  public.ordem_compra.id_comprador as id_comprador, " +
                "  CAST(public.epi.id_epi as VARCHAR) as codigo_interno, " +
                "  soc_qtd_original, " +
                "  soc_entrega_prevista_original, " +
                "  soc_tipo_alocacao_estoque, " +
                "  soc_observacao " +
                "FROM " +
                "  public.solicitacao_compra " +
                "  INNER JOIN public.epi ON (public.solicitacao_compra.id_epi = public.epi.id_epi) " +
                "  INNER JOIN public.acs_usuario ON (public.solicitacao_compra.id_acs_usuario = public.acs_usuario.id_acs_usuario) " +
                "  LEFT OUTER JOIN public.acs_usuario u2 ON (public.solicitacao_compra.id_acs_usuario_pcp = u2.id_acs_usuario) " +
                "  LEFT OUTER JOIN public.ordem_compra ON (public.solicitacao_compra.id_ordem_compra = public.ordem_compra.id_ordem_compra) " +
                "  LEFT OUTER JOIN public.fornecedor ON (public.ordem_compra.id_fornecedor = public.fornecedor.id_fornecedor) " +
                "  LEFT OUTER JOIN public.unidade_medida ON(public.epi.id_unidade_medida_compra = public.unidade_medida.id_unidade_medida) " +
                ") AS tab  " +
                "LEFT OUTER JOIN public.comprador ON (tab.id_comprador = public.comprador.id_comprador)  " +
                "LEFT OUTER JOIN (SELECT * FROM public.solicitacao_compra_feedback f WHERE f.scf_atual = 1) as feedback ON (tab.id_solicitacao_compra = feedback.id_solicitacao_compra) " +
                "LEFT JOIN public.lote_solicitacao_compra ON (tab.id_solicitacao_compra = public.lote_solicitacao_compra.id_solicitacao_compra) " +
                "LEFT JOIN public.lote ON (public.lote_solicitacao_compra.id_lote = public.lote.id_lote) " +

                filter +
                " GROUP BY " +
                "  tab.identificacao,                                                                                                           " +
                "  tab.medida, " +
                "  tab.descricao, " +
                "  tab.descricao2, " +
                "  tab.soc_unidade_compra, " +
                "  tab.codigo_interno, " +
                "  tab.politica_estoque, " +
                "  tab.estoque_seguranca_tipo, " +
                "  tab.estoque_seguranca, " +
                "  tab.id_solicitacao_compra,                                                                                                   " +
                "  tab.soc_qtd,                                                                                                                 " +
                "  tab.soc_data_abertura,                                                                                                       " +
                "  tab.soc_data_aprovacao_pcp, " +
                "  tab.id_ordem_compra, " +
                "   public.comprador.com_apelido, " +
                "  tab.soc_data_aprovacao_compras, " +
                "  tab.soc_saldo_recebimento,   																							    " +
                "  tab.soc_entrega_prevista, " +
                "  tab.status, " +
                "  tab.for_razao_social, " +
                "  tab.aus_login,                                                                                                                " +
                "  tab.status, " +
                "  tab.id_comprador, " +
                "  scf_texto, " +
                "  soc_qtd_original, " +
                "  soc_entrega_prevista_original, " +
                "  soc_tipo_alocacao_estoque, " +
                "  soc_observacao " +
                filter2 +
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


                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[0], "Identificação", 150, DataGridViewAutoSizeColumnMode.None, true);

                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[1], "Dimensão", 80, DataGridViewAutoSizeColumnMode.None, false);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[2], "Descrição", 200, DataGridViewAutoSizeColumnMode.None, false);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[3], "Descrição Adicional", 150, DataGridViewAutoSizeColumnMode.None, false);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[4], "Unidade Compra", 70, DataGridViewAutoSizeColumnMode.None, false);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[5], "Código Interno / ID", 60, DataGridViewAutoSizeColumnMode.None, false);

                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[6], "Pol. Estoque", 80, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[7], "Estoque Segurança", 70, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[8], "Estoque Segurança Data", 100, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[9], "N° da\r\nSolicitação", 70, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[10], "Quantidade", 70, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[11], "Data Solicitação", 100, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[12], "Prazo PCP", 100, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[13], "Aprovação PCP", 100, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[14], "N° da OC", 70, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[15], "Comprador", 70, DataGridViewAutoSizeColumnMode.None, true);

                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[16], "Prazo Compras", 100, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[17], "Aprovação Compras", 100, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[18], "Saldo Recebimento", 85, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[19], "Entrega Prevista", 80, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[20], "Status", 90, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[21], "Fornecedor", 150, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[22], "Solicitante", 70, DataGridViewAutoSizeColumnMode.None, true);
                this.dataGridView1.Columns[23].Visible = false;
                this.dataGridView1.Columns[24].Visible = false;
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[25], "Feedback", 350, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[26], "Recebimentos", 350, DataGridViewAutoSizeColumnMode.None, false);

                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[27], "Quantidade Original", 70, DataGridViewAutoSizeColumnMode.None, false);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[28], "Entrega Prevista Original", 80, DataGridViewAutoSizeColumnMode.None, false);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[29], "Tipo da SC", 100, DataGridViewAutoSizeColumnMode.None, false);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[30], "Observação", 350, DataGridViewAutoSizeColumnMode.None, true);


                this.dataGridView1.Columns[6].HeaderCell.Style.ForeColor = Color.Green;
                this.dataGridView1.Columns[7].HeaderCell.Style.ForeColor = Color.Green;
                this.dataGridView1.Columns[8].HeaderCell.Style.ForeColor = Color.Green;
                this.dataGridView1.Columns[9].HeaderCell.Style.ForeColor = Color.Green;
                this.dataGridView1.Columns[10].HeaderCell.Style.ForeColor = Color.Green;
                this.dataGridView1.Columns[11].HeaderCell.Style.ForeColor = Color.Green;
                this.dataGridView1.Columns[12].HeaderCell.Style.ForeColor = Color.Green;
                this.dataGridView1.Columns[13].HeaderCell.Style.ForeColor = Color.Green;

                this.dataGridView1.Columns[14].HeaderCell.Style.ForeColor = Color.Blue;
                this.dataGridView1.Columns[15].HeaderCell.Style.ForeColor = Color.Blue;
                this.dataGridView1.Columns[16].HeaderCell.Style.ForeColor = Color.Blue;
                this.dataGridView1.Columns[17].HeaderCell.Style.ForeColor = Color.Blue;
                this.dataGridView1.Columns[18].HeaderCell.Style.ForeColor = Color.Blue;
                this.dataGridView1.Columns[19].HeaderCell.Style.ForeColor = Color.Blue;
                this.dataGridView1.Columns[20].HeaderCell.Style.ForeColor = Color.Blue;
                this.dataGridView1.Columns[21].HeaderCell.Style.ForeColor = Color.Blue;
                this.dataGridView1.Columns[22].HeaderCell.Style.ForeColor = Color.Blue;
                this.dataGridView1.Columns[27].HeaderCell.Style.ForeColor = Color.Blue;
                this.dataGridView1.Columns[28].HeaderCell.Style.ForeColor = Color.Blue;
                this.dataGridView1.Columns[29].HeaderCell.Style.ForeColor = Color.Blue;


                switch (TipoModulo.Tipo)
                {
                    case TipoForm.Expedicao:
                    case TipoForm.Compras:

                        this.dataGridView1.Columns[6].Visible = false;
                        this.dataGridView1.Columns[7].Visible = false;
                        this.dataGridView1.Columns[8].Visible = false;
                        this.dataGridView1.Columns[9].Visible = false;
                        this.dataGridView1.Columns[10].Visible = false;
                        this.dataGridView1.Columns[11].Visible = false;
                        this.dataGridView1.Columns[12].Visible = false;
                        this.dataGridView1.Columns[13].Visible = false;


                        break;
                    default:
                        this.dataGridView1.Columns[14].Visible = false;
                        this.dataGridView1.Columns[15].Visible = false;
                        this.dataGridView1.Columns[16].Visible = false;
                        this.dataGridView1.Columns[17].Visible = false;
                        this.dataGridView1.Columns[18].Visible = false;
                        this.dataGridView1.Columns[19].Visible = false;
                        this.dataGridView1.Columns[20].Visible = false;
                        this.dataGridView1.Columns[21].Visible = false;
                        this.dataGridView1.Columns[22].Visible = false;
                        break;
                }


            }

            this.lblQtdSolicitacoes.Text = this.dataGridView1.RowCount.ToString();


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

            ExibirOcultarDadosAdicionais();

        }

        private void Novo()
        {
            try
            {
                SolicitacaoCompraForm form = new SolicitacaoCompraForm(
                    null,true,
                    this._acsUsuario, this.conn);
                form.ShowDialog();
                this.initializeGrid();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao cadastrar um novo item.\r\n" + e.Message);
            }
        }

        private void Excluir()
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show(this, "Você deseja excluir o(s) item(s) selecionado(s)?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }

                    List<int> toCancel = new List<int>();
                    foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
                    {
                        int id = Convert.ToInt32(row.Cells["id_solicitacao_compra"].Value);
                        if (row.Cells["stat_original"].Value.ToString() == "0")
                        {

                            toCancel.Add(id);
                        }
                        else
                        {
                            throw new Exception("A solicitação " + id + " selecionada mas não pode ser excluida pois seu status não é \"Nova\".");
                        }
                    }

                    command = this.conn.CreateCommand();
                    command.Transaction = command.Connection.BeginTransaction();
                    command.CommandText =
                        "DELETE FROM  " +
                        "  public.solicitacao_compra  " +
                        "WHERE  " +
                        "  id_solicitacao_compra = :id_solicitacao_compra " +
                        "; ";

                    foreach (int idOC in toCancel)
                    {
                        command.Parameters.Clear();
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_solicitacao_compra", NpgsqlDbType.Integer));
                        command.Parameters[command.Parameters.Count - 1].Value = idOC;

                        command.ExecuteNonQuery();
                    }

                    foreach (int id in toCancel)
                    {
                        ApiSimuladorCompras.SincronizarSolicitacaoCompra(id,"EXCLUIR",_acsUsuario, command);
                    }
                    
                    command.Transaction.Commit();
                    this.initializeGrid();

                }
                else
                {
                    throw new Exception("Selecione a linha que você deseja excluir.");
                }
            }
            catch (Exception e)
            {
                command?.Transaction?.Rollback();

                throw new Exception("Erro ao excluir o item selecionado.\r\n" + e.Message);
            }
        }

        private void AprovarPCP()
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    if (this.dataGridView1.SelectedRows[0].Cells["stat_original"].Value.ToString() == "0")
                    {
                        int id = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells["id_solicitacao_compra"].Value);

                        SolicitacaoCompraClass sc = new SolicitacaoCompraClass(id, null, this._acsUsuario, this.conn);

                        SolicitacaoCompraForm form = new SolicitacaoCompraForm(sc,true,
                                                                               this._acsUsuario, this.conn);
                        form.ShowDialog();
                        this.initializeGrid();
                    }
                    else
                    {
                        throw new Exception("Só é possível aprovar uma Solicitação Não Liberada.");
                    }
                }
                else
                {
                    throw new Exception("Selecione a linha que você deseja aprovar.");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao aprovar o item.\r\n" + e.Message);
            }
        }

        private void Cancelar()
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show(this, "Você deseja cancelar a(s) Solicitação(ões) de Compra selecionada(s)?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }

                    List<int> toCancel = new List<int>();
                    foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
                    {
                        int id = Convert.ToInt32(row.Cells["id_solicitacao_compra"].Value);

                        if (row.Cells["stat_original"].Value.ToString() != "6")
                        {
                            toCancel.Add(id);
                        }
                        else
                        {
                            throw new Exception("A Solicitação " + id + " selecionada já foi cancelada anteriormente.");
                        }
                    }

                    foreach (int idOC in toCancel)
                    {
                        SolicitacaoCompraClass sol = new SolicitacaoCompraClass(idOC, null, this._acsUsuario, this.conn);
                        sol.Cancelar();
                        sol.Save(false);
                    }

                    this.initializeGrid();
                }
                else
                {
                    throw new Exception("Selecione a(s) Solicitação(ões) que você deseja cancelar.");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao cancelar o(s) item(ns) selecionado(s).\r\n" + e.Message);
            }
        }

        private void FormatarLinha(int linha, int coluna)
        {


            try
            {
                if (coluna == 0 || coluna == 8 || coluna == 15)
                {
                    if (TipoModulo.Tipo == TipoForm.PCP)
                    {


                        object valor = this.dataGridView1.Rows[linha].Cells["limitePCP"].Value;
                        if (valor != null)
                        {
                            if (Convert.ToInt32(this.dataGridView1.Rows[linha].Cells["stat_original"].Value) == 0)
                            {
                                DateTime limitePCP = Convert.ToDateTime(valor);
                                int compare = Configurations.DataIndependenteClass.GetData().Date.CompareTo(limitePCP.Date);

                                if (compare > 0)
                                {
                                    //Vermelho
                                    foreach (DataGridViewCell cell in this.dataGridView1.Rows[linha].Cells)
                                    {
                                        cell.Style.BackColor = Color.Red;
                                    }
                                }
                                else
                                {
                                    if (compare == 0)
                                    {
                                        //Amarelo
                                        foreach (DataGridViewCell cell in this.dataGridView1.Rows[linha].Cells)
                                        {
                                            cell.Style.BackColor = Color.Yellow;
                                        }
                                    }
                                }

                            }
                        }



                    }

                    if (TipoModulo.Tipo == TipoForm.Compras || TipoModulo.Tipo == TipoForm.Expedicao)
                    {

                        switch (tipoTelaSolicitacao)
                        {
                            case TipoTelaSolicitacao.AguardandoCompras:

                                object valor = this.dataGridView1.Rows[linha].Cells["limiteCompras"].Value;
                                if (valor != null)
                                {
                                    if (Convert.ToInt32(this.dataGridView1.Rows[linha].Cells["stat_original"].Value) ==
                                        1)
                                    {
                                        DateTime limiteCompras = Convert.ToDateTime(valor);
                                        int compare = Configurations.DataIndependenteClass.GetData().Date.CompareTo(limiteCompras.Date);

                                        if (compare > 0)
                                        {
                                            //Vermelho
                                            foreach (DataGridViewCell cell in this.dataGridView1.Rows[linha].Cells)
                                            {
                                                cell.Style.BackColor = Color.Red;
                                            }
                                        }
                                        else
                                        {
                                            if (compare == 0)
                                            {
                                                //Amarelo
                                                foreach (DataGridViewCell cell in this.dataGridView1.Rows[linha].Cells)
                                                {
                                                    cell.Style.BackColor = Color.Yellow;
                                                }
                                            }
                                        }

                                    }
                                }



                                break;
                            case TipoTelaSolicitacao.TodasLiberadas:
                            case TipoTelaSolicitacao.Abertas:
                            case TipoTelaSolicitacao.AguardandoRecebimento:

                                valor = this.dataGridView1.Rows[linha].Cells["entregaPrevista"].Value;
                                if (valor != null)
                                {
                                    if (Convert.ToInt32(this.dataGridView1.Rows[linha].Cells["stat_original"].Value) ==
                                        2 ||
                                        Convert.ToInt32(this.dataGridView1.Rows[linha].Cells["stat_original"].Value) ==
                                        3 ||
                                        Convert.ToInt32(this.dataGridView1.Rows[linha].Cells["stat_original"].Value) ==
                                        4)
                                    {
                                        DateTime limiteEntrega = Convert.ToDateTime(valor);
                                        int compare = Configurations.DataIndependenteClass.GetData().Date.CompareTo(limiteEntrega.Date);

                                        if (compare > 0)
                                        {
                                            //Vermelho
                                            foreach (DataGridViewCell cell in this.dataGridView1.Rows[linha].Cells)
                                            {
                                                cell.Style.BackColor = Color.Red;
                                            }
                                        }
                                        else
                                        {
                                            if (compare == 0)
                                            {
                                                //Amarelo
                                                foreach (DataGridViewCell cell in this.dataGridView1.Rows[linha].Cells)
                                                {
                                                    cell.Style.BackColor = Color.Yellow;
                                                }
                                            }
                                        }

                                    }

                                }
                                break;

                            case TipoTelaSolicitacao.Todos:

                                break;
                        }

                    }
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao formatar a linha.\r\n" + e.Message, e);
            }
        }

        private void Editar()
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    if (this.dataGridView1.SelectedRows[0].Cells["stat_original"].Value.ToString() == "0")
                    {
                        int id = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells["id_solicitacao_compra"].Value);
                        SolicitacaoCompraClass sc = new SolicitacaoCompraClass(id, null, this._acsUsuario, this.conn);
                        SolicitacaoCompraForm form = new SolicitacaoCompraForm(sc,false, this._acsUsuario, this.conn);
                        form.ShowDialog();
                        this.initializeGrid();
                    }
                    else
                    {
                        throw new Exception("Só é possível editar uma Solicitação Não Liberada.");
                    }
                }
                else
                {
                    throw new Exception("Selecione a linha que você deseja editar.");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao editar o item.\r\n" + e.Message);
            }
        }

        private void ExibirOcultarDadosAdicionais()
        {
            try
            {
                

                this.dataGridView1.Columns[1].Visible = _exibindoDadosAdicionais;
                this.dataGridView1.Columns[2].Visible = _exibindoDadosAdicionais;
                this.dataGridView1.Columns[3].Visible = _exibindoDadosAdicionais;
                this.dataGridView1.Columns[4].Visible = _exibindoDadosAdicionais;
                this.dataGridView1.Columns[5].Visible = _exibindoDadosAdicionais;
                this.dataGridView1.Columns[26].Visible = _exibindoDadosAdicionais;
                this.dataGridView1.Columns[27].Visible = _exibindoDadosAdicionais;
                this.dataGridView1.Columns[28].Visible = _exibindoDadosAdicionais;
                this.dataGridView1.Columns[29].Visible = _exibindoDadosAdicionais;
                

                this.dataGridView1.Columns[1].Width = 80;
                this.dataGridView1.Columns[2].Width = 200;
                this.dataGridView1.Columns[3].Width = 150;
                this.dataGridView1.Columns[4].Width = 70;
                this.dataGridView1.Columns[5].Width = 60;
                this.dataGridView1.Columns[26].Width = 350;


                lblRecebimentos.Visible = _exibindoDadosAdicionais;
                txtRecebimentos.Visible = _exibindoDadosAdicionais;




                switch (TipoModulo.Tipo)
                {
                    case TipoForm.Expedicao:
                    case TipoForm.Compras:

                        this.dataGridView1.Columns[6].Visible = _exibindoDadosAdicionais;
                        this.dataGridView1.Columns[7].Visible = _exibindoDadosAdicionais;
                        this.dataGridView1.Columns[8].Visible = _exibindoDadosAdicionais;
                        this.dataGridView1.Columns[9].Visible = _exibindoDadosAdicionais;
                        this.dataGridView1.Columns[10].Visible = _exibindoDadosAdicionais;
                        this.dataGridView1.Columns[11].Visible = _exibindoDadosAdicionais;

                        this.dataGridView1.Columns[13].Visible = _exibindoDadosAdicionais;


                        break;
                    default:
                        this.dataGridView1.Columns[14].Visible = _exibindoDadosAdicionais;
                        this.dataGridView1.Columns[15].Visible = _exibindoDadosAdicionais;

                        this.dataGridView1.Columns[17].Visible = _exibindoDadosAdicionais;
                        this.dataGridView1.Columns[18].Visible = _exibindoDadosAdicionais;
                        this.dataGridView1.Columns[19].Visible = _exibindoDadosAdicionais;
                        this.dataGridView1.Columns[20].Visible = _exibindoDadosAdicionais;
                        this.dataGridView1.Columns[21].Visible = _exibindoDadosAdicionais;
                        this.dataGridView1.Columns[22].Visible = _exibindoDadosAdicionais;
                        break;
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao exibir ou ocultar os dados adicionais.\r\n" + e.Message, e);
            }
        }

        private void initializeComboComprador()
        {
            string sql =
                "SELECT  " +
                "  public.comprador.id_comprador, " +
                "  public.comprador.com_apelido " +
                "FROM " +
                "  public.comprador " +
                "ORDER BY com_apelido";


            IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.conn);
            if (adapter != null)
            {
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                BindingSource binding = new BindingSource();
                binding.DataSource = ds.Tables[0];
                this.cmbComprador.DataSource = binding;
                this.cmbComprador.ValueMember = "id_comprador";
                this.cmbComprador.DisplayMember = "com_apelido";


            }
        }

        private void getComprador()
        {
            try
            {
                //Identifica o comprador que está sendo utilizado
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText =
                    "SELECT  " +
                    "  public.comprador.id_comprador " +
                    "FROM " +
                    "  public.comprador " +
                    "WHERE " +
                    "  public.comprador.id_acs_usuario = " + this._acsUsuario.ID + " ";
                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                //if (!read.HasRows)
                //{
                //    throw new Exception("Você não possui nenhum comprador cadastrado. Cadastre um comprador antes de continuar.");
                //}
                compradores = new List<int>();
                while (read.Read())
                {
                    compradores.Add(Convert.ToInt32(read["id_comprador"]));
                }
                read.Close();

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao identificar o comprador.\r\n" + e.Message, e);
            }
        }

        private int selecaoComprador()
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

        private void GerarOC()
        {
            try
            {

                
                OCForm f = new OCForm(this.selecaoComprador());

                f.ShowDialog();
                this.initializeGrid();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao cadastrar um nova ordem de compra.\r\n" + e.Message);
            }
        }

        private void GerenciarFeedbaks()
        {
            if (this.dataGridView1.SelectedRows.Count==0)
            {
                return;
            }

            int idSc = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells["id_solicitacao_compra"].Value);
            BibliotecaEntidades.Entidades.SolicitacaoCompraClass sc = SolicitacaoCompraBaseClass.GetEntidade(idSc, LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);

            SolicitacaoCompraFeedbackForm form = new SolicitacaoCompraFeedbackForm(sc);
            form.ShowDialog(this);
            this.initializeGrid();

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

        private void btnAprovacaoPCP_Click(object sender, EventArgs e)
        {
            try
            {
                this.AprovarPCP();
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

        private void chkAprovadasPCP_CheckedChanged(object sender, EventArgs e)
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

        private void chkAprovadasCompras_CheckedChanged(object sender, EventArgs e)
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

        private void chkIdOC_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.nudSC.Enabled = this.chkSc.Checked;
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

        private void lnkDadosAdicionais_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                _exibindoDadosAdicionais = !_exibindoDadosAdicionais;

                this.ExibirOcultarDadosAdicionais();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void rdbBuscaComprador_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.compradores == null)
                {
                    this.getComprador();
                }

                this.cmbComprador.Enabled = true;
                this.initializeGrid();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbTodosCompradores_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.rdbTodosCompradores.Checked)
                {
                    if (this.compradores == null)
                    {
                        this.getComprador();
                    }

                    this.cmbComprador.Enabled = false;
                    this.initializeGrid();
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbCompradorAtual_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.rdbCompradorAtual.Checked)
                {

                    if (this.compradores == null)
                    {
                        this.getComprador();
                    }

                    this.cmbComprador.Enabled = false;
                    this.initializeGrid();
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.rdbTodosCompradores.Checked = true;
                return;
            }
        }

        private void cmbComprador_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.compradores == null)
                {
                    this.getComprador();
                }

                this.timerBusca.Stop();
                this.timerBusca.Start();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGerarOC_Click(object sender, EventArgs e)
        {
            try
            {
                this.GerarOC();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnGerenciarFeedbaks_Click(object sender, EventArgs e)
        {
            try
            {
                this.GerenciarFeedbaks();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtRecebimentos_OperacaoBuscaEncerrada(object sender, string valor)
        {
            try
            {
                this.initializeGrid();   
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

        private void chkOc_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.nudOC.Enabled = this.chkOc.Checked;
                this.initializeGrid();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nudOC_ValueChanged(object sender, EventArgs e)
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
    }
}
