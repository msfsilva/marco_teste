#region Referencias

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BibliotecaCadastrosBasicos.Estoque;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Operacoes.Compras;
using BibliotecaEntidades.Operacoes.Estoque;
using BibliotecaEntidades.Operacoes.OrdemProducao;
using BibliotecaProdutos;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using LoteClass = BibliotecaEntidades.Operacoes.Compras.LoteClass;
using SolicitacaoCompraClass = BibliotecaEntidades.Operacoes.Compras.SolicitacaoCompraClass;

#endregion

namespace BibliotecaCompras
{
    enum TipoTela { SelecaoFornecedor, SelecaoLinhas, SelecaoLinhasMaterial, SelecaoLinhasProduto, SelecaoEstoque, SelecaoLinhasEpi }

    public partial class RecebimentoForm : IWTBaseForm
    {
        readonly int IdNf;
        readonly AcsUsuarioClass Usuario;
        readonly IWTPostgreNpgsqlConnection conn;
        readonly NFEntradaClass NF;
        NFEntradaItemClass linhaSelecionada;
        OCsDisponiveisClass Solicitacoes;
        TipoTela telaAtual;

        bool loading = false;
        bool loadingGridProdutoMaterial = false;
        readonly string internalLabelPrinter;
        readonly string internalLabelPaper;

        public RecebimentoForm(int IdNf, string internalLabelPrinter, string internalLabelPaper, AcsUsuarioClass Usuario, IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            this.IdNf = IdNf;
            this.Usuario = Usuario;
            this.conn = conn;

            this.internalLabelPaper = internalLabelPaper;
            this.internalLabelPrinter = internalLabelPrinter;

            this.Solicitacoes = new OCsDisponiveisClass(this.Usuario, this.conn);

            this.NF = new NFEntradaClass(this.IdNf, this.Usuario, this.conn);

            if (this.NF.Fornecedor != null)
            {
                this.setScreenMode(TipoTela.SelecaoLinhas);
            }
            else
            {
                this.setScreenMode(TipoTela.SelecaoFornecedor);
            }

            this.initializeComboEmissorCertificado();

            this.WindowState = FormWindowState.Maximized;

        }

        private void setScreenMode(TipoTela novoTipo)
        {
            this.loading = true;
            TipoTela telaAnterior = this.telaAtual;
            this.telaAtual = novoTipo;

            this.carregarCabecalho();

            try
            {
                switch (this.telaAtual)
                {
                    case TipoTela.SelecaoFornecedor:
                        this.splLinhas.Visible = false;
                        this.splSelecaoFornecedor.Visible = true;
                        this.txtBuscaFornecedor.Text = "";
                        this.initializeGridFornecedor();

                        this.btnVoltar.Text = "Fechar";
                        this.btnAvançar.Enabled = true;
                        this.btnVoltar.Enabled = true;

                        break;
                    case TipoTela.SelecaoLinhas:
                        this.splLinhas.Visible = true;

                        this.splPreenchimento.Visible = true;
                        this.splEstoque.Visible = false;
                        this.splSelecaoFornecedor.Visible = false;
                        this.splProdutoMaterial.Enabled = false;
                        this.txtBuscaMaterialProduto.Clear();
                        this.btnVoltar.Enabled = false;

                        this.initializeGridLinhas();
                        break;

                    case TipoTela.SelecaoLinhasMaterial:
                        this.splLinhas.Visible = true;

                        this.splPreenchimento.Visible = true;
                        this.splEstoque.Visible = false;
                        this.splSelecaoFornecedor.Visible = false;
                        this.splProdutoMaterial.Enabled = true;
                        this.txtBuscaMaterialProduto.Clear();
                        this.dgvMaterial.Visible = true;
                        this.dgvProduto.Visible = false;
                        this.dgvEpi.Visible = false;
                        this.btnVoltar.Enabled = false;

                        this.initializeGridProdutoMaterial();
                        this.initializeComboOCs();

                        if (this.linhaSelecionada == null || this.linhaSelecionada.Material == null)
                        {
                            this.rdbMaterial.Checked = true;
                            this.chkOrdemCompra.Checked = false;
                            if (this.linhaSelecionada == null)
                            {
                                this.nudQtdRecebida.Value = 1;
                            }
                            else
                            {
                                this.nudQtdRecebida.Value = Convert.ToDecimal(linhaSelecionada.Quantidade);
                            }
                            this.dtpEmbalagem.Value = Configurations.DataIndependenteClass.GetData();
                            this.dtpFabricacao.Value = Configurations.DataIndependenteClass.GetData();
                            this.dtpValidade.Value = Configurations.DataIndependenteClass.GetData();

                            this.cmbEntidadeCertificadora.SelectedValue = -1;
                            this.chkEntidadeCertificadora.Checked = false;
                            this.txtCertificado.Text = "";
                            this.txtNumeroLote.Text = "";
                            this.txtObs.Text = "";
                        }
                        else
                        {
                            this.rdbMaterial.Checked = true;
                            if (this.linhaSelecionada.Lote.solicitacoesCompraAtuais.Count > 0)
                            {
                                this.chkOrdemCompra.Checked = true;
                                this.cmbOrdemCompra.SelectedValue = this.linhaSelecionada.Lote.solicitacoesCompraAtuais[0].Solicitacao.idSolicitacaoCompra;
                            }
                            else
                            {
                                this.chkOrdemCompra.Checked = false;
                            }

                            this.txtNumeroLote.Text = this.linhaSelecionada.Lote.Numero;
                            this.nudQtdRecebida.Value = Convert.ToDecimal(this.linhaSelecionada.Lote.qtdUnidadeCompra);
                            if (this.linhaSelecionada.Lote.getDataEmbalagem() != null)
                            {
                                this.chkEmbalagem.Checked = true;
                                this.dtpEmbalagem.Value = this.linhaSelecionada.Lote.getDataEmbalagem().Value;
                            }
                            else
                            {
                                this.chkEmbalagem.Checked = false;
                            }

                            if (this.linhaSelecionada.Lote.getDataFabricacao() != null)
                            {
                                this.chkFabricacao.Checked = true;
                                this.dtpFabricacao.Value = this.linhaSelecionada.Lote.getDataFabricacao().Value;
                            }
                            else
                            {
                                this.chkFabricacao.Checked = false;
                            }

                            if (this.linhaSelecionada.Lote.getDataValidade() != null)
                            {
                                this.chkValidade.Checked = true;
                                this.dtpValidade.Value = this.linhaSelecionada.Lote.getDataValidade().Value;
                            }
                            else
                            {
                                this.chkValidade.Checked = false;
                            }

                            if (this.linhaSelecionada.Lote.getIdEmissorCertificado() != null)
                            {
                                this.chkEntidadeCertificadora.Checked = true;
                                this.cmbEntidadeCertificadora.SelectedValue = this.linhaSelecionada.Lote.getIdEmissorCertificado();
                            }
                            else
                            {
                                this.chkEntidadeCertificadora.Checked = false;
                            }

                            this.txtCertificado.Text = this.linhaSelecionada.Lote.Certificado;
                            this.txtNumeroLote.Text = this.linhaSelecionada.Lote.Numero;
                            this.txtObs.Text = this.linhaSelecionada.Lote.Observacoes;



                        }

                        this.btnVoltar.Text = "Voltar";

                        break;

                    case TipoTela.SelecaoLinhasEpi:
                        this.splLinhas.Visible = true;

                        this.splPreenchimento.Visible = true;
                        this.splEstoque.Visible = false;
                        this.splSelecaoFornecedor.Visible = false;
                        this.splProdutoMaterial.Enabled = true;
                        this.txtBuscaMaterialProduto.Clear();
                        this.dgvMaterial.Visible = false;
                        this.dgvProduto.Visible = false;
                        this.dgvEpi.Visible = true;
                        this.btnVoltar.Enabled = false;

                        this.initializeGridProdutoMaterial();
                        this.initializeComboOCs();

                        if (this.linhaSelecionada == null || this.linhaSelecionada.Material == null)
                        {
                            this.rdbEpi.Checked = true;
                            this.chkOrdemCompra.Checked = false;
                            if (this.linhaSelecionada == null)
                            {
                                this.nudQtdRecebida.Value = 1;
                            }
                            else
                            {
                                this.nudQtdRecebida.Value = Convert.ToDecimal(linhaSelecionada.Quantidade);
                            }
                            this.dtpEmbalagem.Value = Configurations.DataIndependenteClass.GetData();
                            this.dtpFabricacao.Value = Configurations.DataIndependenteClass.GetData();
                            this.dtpValidade.Value = Configurations.DataIndependenteClass.GetData();

                            this.cmbEntidadeCertificadora.SelectedValue = -1;
                            this.chkEntidadeCertificadora.Checked = false;
                            this.txtCertificado.Text = "";
                            this.txtNumeroLote.Text = "";
                            this.txtObs.Text = "";
                        }
                        else
                        {
                            this.rdbEpi.Checked = true;
                            if (this.linhaSelecionada.Lote.solicitacoesCompraAtuais.Count > 0)
                            {
                                this.chkOrdemCompra.Checked = true;
                                this.cmbOrdemCompra.SelectedValue = this.linhaSelecionada.Lote.solicitacoesCompraAtuais[0].Solicitacao.idSolicitacaoCompra;
                            }
                            else
                            {
                                this.chkOrdemCompra.Checked = false;
                            }

                            this.txtNumeroLote.Text = this.linhaSelecionada.Lote.Numero;
                            this.nudQtdRecebida.Value = Convert.ToDecimal(this.linhaSelecionada.Lote.qtdUnidadeCompra);
                            if (this.linhaSelecionada.Lote.getDataEmbalagem() != null)
                            {
                                this.chkEmbalagem.Checked = true;
                                this.dtpEmbalagem.Value = this.linhaSelecionada.Lote.getDataEmbalagem().Value;
                            }
                            else
                            {
                                this.chkEmbalagem.Checked = false;
                            }

                            if (this.linhaSelecionada.Lote.getDataFabricacao() != null)
                            {
                                this.chkFabricacao.Checked = true;
                                this.dtpFabricacao.Value = this.linhaSelecionada.Lote.getDataFabricacao().Value;
                            }
                            else
                            {
                                this.chkFabricacao.Checked = false;
                            }

                            if (this.linhaSelecionada.Lote.getDataValidade() != null)
                            {
                                this.chkValidade.Checked = true;
                                this.dtpValidade.Value = this.linhaSelecionada.Lote.getDataValidade().Value;
                            }
                            else
                            {
                                this.chkValidade.Checked = false;
                            }

                            if (this.linhaSelecionada.Lote.getIdEmissorCertificado() != null)
                            {
                                this.chkEntidadeCertificadora.Checked = true;
                                this.cmbEntidadeCertificadora.SelectedValue = this.linhaSelecionada.Lote.getIdEmissorCertificado();
                            }
                            else
                            {
                                this.chkEntidadeCertificadora.Checked = false;
                            }

                            this.txtCertificado.Text = this.linhaSelecionada.Lote.Certificado;
                            this.txtNumeroLote.Text = this.linhaSelecionada.Lote.Numero;
                            this.txtObs.Text = this.linhaSelecionada.Lote.Observacoes;
                            
                        }

                        this.btnVoltar.Text = "Voltar";

                        break;
                    case TipoTela.SelecaoLinhasProduto:
                        this.splLinhas.Visible = true;
                        this.splSelecaoFornecedor.Visible = false;

                        this.splPreenchimento.Visible = true;
                        this.splEstoque.Visible = false;

                        this.splProdutoMaterial.Enabled = true;
                        this.dgvMaterial.Visible = false;
                        this.dgvProduto.Visible = true;
                        this.dgvEpi.Visible = false;
                        this.btnVoltar.Enabled = false;

                        this.initializeGridProdutoMaterial();
                        this.initializeComboOCs();

                        if (this.linhaSelecionada == null || this.linhaSelecionada.Produto == null)
                        {
                            this.rdbProduto.Checked = true;
                            this.chkOrdemCompra.Checked = false;
                            if (this.linhaSelecionada == null)
                            {
                                this.nudQtdRecebida.Value = 1;
                            }
                            else
                            {
                                this.nudQtdRecebida.Value = Convert.ToDecimal(linhaSelecionada.Quantidade);
                            }
                            this.dtpEmbalagem.Value = Configurations.DataIndependenteClass.GetData();
                            this.dtpFabricacao.Value = Configurations.DataIndependenteClass.GetData();
                            this.dtpValidade.Value = Configurations.DataIndependenteClass.GetData();

                            this.cmbEntidadeCertificadora.SelectedValue = -1;
                            this.chkEntidadeCertificadora.Checked = false;
                            this.txtCertificado.Text = "";
                            this.txtNumeroLote.Text = "";
                            this.txtObs.Text = "";
                        }
                        else
                        {
                            this.rdbProduto.Checked = true;
                            if (this.linhaSelecionada.Lote.solicitacoesCompraAtuais.Count > 0)
                            {
                                this.chkOrdemCompra.Checked = true;
                                this.cmbOrdemCompra.SelectedValue = this.linhaSelecionada.Lote.solicitacoesCompraAtuais[0].Solicitacao.idSolicitacaoCompra;
                            }
                            else
                            {
                                this.chkOrdemCompra.Checked = false;
                            }

                            this.txtNumeroLote.Text = this.linhaSelecionada.Lote.Numero;
                            this.nudQtdRecebida.Value = Convert.ToDecimal(this.linhaSelecionada.Lote.qtdUnidadeCompra);

                            if (this.linhaSelecionada.Lote.getDataEmbalagem() != null)
                            {
                                this.chkEmbalagem.Checked = true;
                                this.dtpEmbalagem.Value = this.linhaSelecionada.Lote.getDataEmbalagem().Value;
                            }
                            else
                            {
                                this.chkEmbalagem.Checked = false;
                            }

                            if (this.linhaSelecionada.Lote.getDataFabricacao() != null)
                            {
                                this.chkFabricacao.Checked = true;
                                this.dtpFabricacao.Value = this.linhaSelecionada.Lote.getDataFabricacao().Value;
                            }
                            else
                            {
                                this.chkFabricacao.Checked = false;
                            }

                            if (this.linhaSelecionada.Lote.getDataValidade() != null)
                            {
                                this.chkValidade.Checked = true;
                                this.dtpValidade.Value = this.linhaSelecionada.Lote.getDataValidade().Value;
                            }
                            else
                            {
                                this.chkValidade.Checked = false;
                            }

                            if (this.linhaSelecionada.Lote.getIdEmissorCertificado() != null)
                            {
                                this.chkEntidadeCertificadora.Checked = true;
                                this.cmbEntidadeCertificadora.SelectedValue = this.linhaSelecionada.Lote.getIdEmissorCertificado();
                            }
                            else
                            {
                                this.chkEntidadeCertificadora.Checked = false;
                            }

                            this.txtCertificado.Text = this.linhaSelecionada.Lote.Certificado;
                            this.txtNumeroLote.Text = this.linhaSelecionada.Lote.Numero;
                            this.txtObs.Text = this.linhaSelecionada.Lote.Observacoes;


                        }
                        this.btnVoltar.Text = "Voltar";

                        break;

                    case TipoTela.SelecaoEstoque:
                        this.splLinhas.Visible = true;
                        this.splSelecaoFornecedor.Visible = false;
                        this.splPreenchimento.Visible = false;
                        this.splEstoque.Visible = true;

                        this.initializeGridEstoques();

                        if (this.dgvEstoque.Rows.Count == 0)
                        {
                            this.itemSemEstoque();
                            break;
                        }

                        if (this.dgvEstoque.Rows.Count == 1)
                        {
                            this.itemComUmEstoque();
                            break;
                        }

                        break;

                }

                this.loading = false;

                if (this.telaAtual != TipoTela.SelecaoFornecedor)
                {
                    if (this.NF.todasLinhasVinculadas())
                    {
                        this.btnAvançar.Enabled = true;
                    }
                    else
                    {
                        this.btnAvançar.Enabled = false;
                    }
                }

                if (this.telaAtual == TipoTela.SelecaoLinhas)
                {
                    this.selecionaLinha();
                }
            }
            catch (Exception e)
            {
                if (this.telaAtual != telaAnterior)
                {
                    this.setScreenMode(telaAnterior);
                }
                throw new Exception("Erro ao definir o tipo da Tela\r\n" + e.Message, e);
            }
        }

        private void initializeGridFornecedor()
        {

            if (this.telaAtual != TipoTela.SelecaoFornecedor)
            {
                return;
            }

            try
            {
                #region Salvando Posição do Grid
                int scrollIndex = 0;
                if (this.dgvFornecedor.FirstDisplayedScrollingRowIndex > 0)
                {
                    scrollIndex = this.dgvFornecedor.FirstDisplayedScrollingRowIndex;
                }

                int selectRowIndex = 0;
                if (this.dgvFornecedor.SelectedRows.Count > 0)
                {
                    selectRowIndex = this.dgvFornecedor.SelectedRows[0].Index;
                }
                #endregion


                string filter = "";
                if (this.txtBuscaFornecedor.Text.Trim().Length > 0)
                {
                    filter += " AND ( " +
                              " UPPER(for_razao_social) LIKE '%" + this.txtBuscaFornecedor.Text.Trim().ToUpper() + "%' " +
                              " OR LOWER(for_razao_social) LIKE '%" + this.txtBuscaFornecedor.Text.Trim().ToLower() + "%' " +
                              " OR UPPER(for_nome_fantasia) LIKE '%" + this.txtBuscaFornecedor.Text.Trim().ToUpper() +"%'" +
                              " OR LOWER(for_nome_fantasia) LIKE '%" + this.txtBuscaFornecedor.Text.Trim().ToLower() + "%'" +
                              " OR for_cnpj LIKE '%" + this.txtBuscaFornecedor.Text.Trim() + "%'" +
                              ") ";
                }

                if (this.NF.possiveisFornecedores != null && this.NF.possiveisFornecedores.Count > 0)
                {

                    string filterInterno = "";
                    foreach (FornecedorClass fornecedor in this.NF.possiveisFornecedores)
                    {
                        filterInterno += " OR id_fornecedor = " + fornecedor.ID + " ";
                    }

                    filter += " AND ( " + filterInterno.Substring(3) + " ) ";
                }

                if (filter.Length > 0)
                {
                    filter = " WHERE " + filter.Substring(4);
                }

                string sql =
                    "SELECT    " +
                    "  public.fornecedor.id_fornecedor,   " +
                    "  public.fornecedor.for_razao_social,   " +
                    "  public.fornecedor.for_nome_fantasia,   " +
                    "  public.fornecedor.for_cnpj,  " +
                    "  public.cidade.cid_nome,   " +
                    "  public.estado.est_sigla   " +
                    "FROM   " +
                    "  public.fornecedor " +
                    "  LEFT JOIN public.cidade ON (public.fornecedor.id_cidade = public.cidade.id_cidade)  " +
                    "  LEFT JOIN public.estado ON (public.cidade.id_estado = public.estado.id_estado) " +
                    filter +
                    "ORDER BY " +
                    "  public.fornecedor.for_razao_social ";

                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.conn);
                if (adapter != null)
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    BindingSource binding = new BindingSource();
                    binding.DataSource = ds.Tables[0];
                    dgvFornecedor.AutoGenerateColumns = true;
                    dgvFornecedor.DataSource = binding;

                    dgvFornecedor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvFornecedor.MultiSelect = false;

                    this.dgvFornecedor.Columns[0].Visible = false;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvFornecedor.Columns[1], "Razão Social", 240, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvFornecedor.Columns[2], "Nome Fantasia", 240, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvFornecedor.Columns[3], "CNPJ", 100, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvFornecedor.Columns[4], "Cidade", 100, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvFornecedor.Columns[5], "Estado", 80, DataGridViewAutoSizeColumnMode.None, true);



                }



                #region Restaurando Posição do Grid
                for (int i = 0; i < this.dgvFornecedor.SelectedRows.Count; i++)
                {
                    this.dgvFornecedor.SelectedRows[i].Selected = false;
                }
                if (this.dgvFornecedor.Rows.Count > 0)
                {
                    while (selectRowIndex > 0 && selectRowIndex >= this.dgvFornecedor.Rows.Count)
                    {
                        selectRowIndex--;
                    }


                    this.dgvFornecedor.Rows[selectRowIndex].Selected = true;

                    while (scrollIndex > 0 && scrollIndex >= this.dgvFornecedor.Rows.Count)
                    {
                        scrollIndex--;
                    }

                    this.dgvFornecedor.FirstDisplayedScrollingRowIndex = scrollIndex;
                }
                #endregion


            }
            catch (Exception e)
            {
                throw new Exception("Erro ao preencher o grid de fornecedor.\r\n" + e.Message, e);
            }
        }

        private void initializeGridProdutoMaterial()
        {
            try
            {
                if (this.rdbMaterial.Checked)
                {
                    this.initializeGridMaterial();
                }
                else
                {
                    if (this.rdbEpi.Checked)
                    {
                        this.initializeGridEpi();
                    }
                    else
                    {
                        this.initializeGridProduto();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        
        private void initializeGridProduto()
        {
            if (this.telaAtual != TipoTela.SelecaoLinhasProduto)
            {
                return;
            }

            try
            {
                this.loadingGridProdutoMaterial = true;

                this.dgvProduto.Columns.Clear();

                this.dgvProduto.AutoGenerateColumns = false;



                this.dgvProduto.Columns.Add(new DataGridViewTextBoxColumn());
                this.dgvProduto.Columns[this.dgvProduto.Columns.Count - 1].DataPropertyName = "idProdutoMaterial";
                this.dgvProduto.Columns[this.dgvProduto.Columns.Count - 1].Name = "idProdutoMaterial";
                this.dgvProduto.Columns[this.dgvProduto.Columns.Count - 1].Visible = false;

                this.dgvProduto.Columns.Add(new DataGridViewTextBoxColumn());
                this.dgvProduto.Columns[this.dgvProduto.Columns.Count - 1].DataPropertyName = "politicaEstoque";
                this.dgvProduto.Columns[this.dgvProduto.Columns.Count - 1].Name = "politicaEstoque";
                this.dgvProduto.Columns[this.dgvProduto.Columns.Count - 1].HeaderText = "Estoque";
                this.dgvProduto.Columns[this.dgvProduto.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.dgvProduto.Columns[this.dgvProduto.Columns.Count - 1].MinimumWidth = 80;

                this.dgvProduto.Columns.Add(new DataGridViewTextBoxColumn());
                this.dgvProduto.Columns[this.dgvProduto.Columns.Count - 1].DataPropertyName = "codigoProdutoMaterial";
                this.dgvProduto.Columns[this.dgvProduto.Columns.Count - 1].Name = "codigoProdutoMaterial";
                this.dgvProduto.Columns[this.dgvProduto.Columns.Count - 1].HeaderText = "Código";
                this.dgvProduto.Columns[this.dgvProduto.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.dgvProduto.Columns[this.dgvProduto.Columns.Count - 1].MinimumWidth = 80;

                this.dgvProduto.Columns.Add(new DataGridViewTextBoxColumn());
                this.dgvProduto.Columns[this.dgvProduto.Columns.Count - 1].DataPropertyName = "descricaoProdutoMaterial";
                this.dgvProduto.Columns[this.dgvProduto.Columns.Count - 1].Name = "descricaoProdutoMaterial";
                this.dgvProduto.Columns[this.dgvProduto.Columns.Count - 1].HeaderText = "Descrição";
                this.dgvProduto.Columns[this.dgvProduto.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.dgvProduto.Columns[this.dgvProduto.Columns.Count - 1].MinimumWidth = 120;

                this.dgvProduto.Columns.Add(new DataGridViewTextBoxColumn());
                this.dgvProduto.Columns[this.dgvProduto.Columns.Count - 1].DataPropertyName = "infoAdicionalProdutoMaterial";
                this.dgvProduto.Columns[this.dgvProduto.Columns.Count - 1].Name = "infoAdicionalProdutoMaterial";
                this.dgvProduto.Columns[this.dgvProduto.Columns.Count - 1].HeaderText = "Classificação";
                this.dgvProduto.Columns[this.dgvProduto.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.dgvProduto.Columns[this.dgvProduto.Columns.Count - 1].MinimumWidth = 100;

                this.dgvProduto.Columns.Add(new DataGridViewTextBoxColumn());
                this.dgvProduto.Columns[this.dgvProduto.Columns.Count - 1].DataPropertyName = "UnidadeCompra";
                this.dgvProduto.Columns[this.dgvProduto.Columns.Count - 1].Name = "UnidadeCompra";
                this.dgvProduto.Columns[this.dgvProduto.Columns.Count - 1].Visible = false;

                this.dgvProduto.Columns.Add(new DataGridViewTextBoxColumn());
                this.dgvProduto.Columns[this.dgvProduto.Columns.Count - 1].DataPropertyName = "unidadeUsoProdutoMaterial";
                this.dgvProduto.Columns[this.dgvProduto.Columns.Count - 1].Name = "unidadeUsoProdutoMaterial";
                this.dgvProduto.Columns[this.dgvProduto.Columns.Count - 1].Visible = false;

                this.dgvProduto.Columns.Add(new DataGridViewTextBoxColumn());
                this.dgvProduto.Columns[this.dgvProduto.Columns.Count - 1].DataPropertyName = "UnidadesUsoPorUnidadeCompra";
                this.dgvProduto.Columns[this.dgvProduto.Columns.Count - 1].Name = "UnidadesUsoPorUnidadeCompra";
                this.dgvProduto.Columns[this.dgvProduto.Columns.Count - 1].Visible = false;

                List<SolicitacaoQuantidadeClass> solicitacoesLinhaAtual = new List<SolicitacaoQuantidadeClass>();

                if (this.linhaSelecionada != null)
                {
                    if (this.linhaSelecionada.Lote != null)
                    {
                        if (this.linhaSelecionada.Lote.solicitacoesCompraAtuais != null)
                        {
                            foreach (LoteSolicitacao sol in this.linhaSelecionada.Lote.solicitacoesCompraAtuais)
                            {
                                solicitacoesLinhaAtual.Add(new SolicitacaoQuantidadeClass(sol.Solicitacao, sol.quantidadeUnidadeCompra));
                            }
                        }
                    }
                }

                this.Solicitacoes.setQuantidadesLinhaSelecionada(solicitacoesLinhaAtual);

                AdvancedList<AgrupamentoSolicitacaoDisponivel> ds;

                if (this.NF.Fornecedor != null)
                {
                    ds = new AdvancedList<AgrupamentoSolicitacaoDisponivel>(this.Solicitacoes.SolicitacoesNaoRecebidasComSaldoProduto.Where(a =>a.Fornecedor == this.NF.Fornecedor));
                }
                else
                {
                    ds = new AdvancedList<AgrupamentoSolicitacaoDisponivel>(this.Solicitacoes.SolicitacoesNaoRecebidasComSaldoProduto);
                }

                


                if (this.txtBuscaMaterialProduto.Text.Trim().Length > 0)
                {
                    string busca = this.txtBuscaMaterialProduto.Text.Trim().ToUpper();
                    ds = new AdvancedList<AgrupamentoSolicitacaoDisponivel>(
                        ds.Where(a => a.codigoProdutoMaterial.ToUpper().Contains(busca) || a.descricaoProdutoMaterial.ToUpper().Contains(busca) || a.infoAdicionalProdutoMaterial.ToUpper().Contains(busca)));

                }


                this.dgvProduto.DataSource = ds;


                this.dgvProduto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.dgvProduto.MultiSelect = false;



                if (this.linhaSelecionada != null && this.linhaSelecionada.Produto != null)
                {
                    for (int i = 0; i < this.dgvProduto.SelectedRows.Count; i++)
                    {
                        this.dgvProduto.SelectedRows[i].Selected = false;
                    }

                    for (int i = 0; i < this.dgvProduto.Rows.Count; i++)
                    {
                        if (this.dgvProduto["idProdutoMaterial", i].Value.ToString() == this.linhaSelecionada.Produto.ID.ToString())
                        {
                            this.dgvProduto.Rows[i].Selected = true;
                            break;
                        }
                    }
                }
                else
                {
                    if (this.dgvProduto.Rows.Count > 0)
                    {
                        for (int i = 0; i < this.dgvProduto.SelectedRows.Count; i++)
                        {
                            this.dgvProduto.SelectedRows[i].Selected = false;
                        }

                        this.dgvProduto.Rows[0].Selected = true;
                    }
                }

                this.loadingGridProdutoMaterial = false;
                this.initializeComboOCs();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao preencher o grid de produtos.\r\n" + e.Message, e);
            }
        }

        private void initializeGridMaterial()
        {
            if (this.telaAtual != TipoTela.SelecaoLinhasMaterial)
            {
                return;
            }

            try
            {
                this.loadingGridProdutoMaterial = true;

                this.dgvMaterial.Columns.Clear();

                this.dgvMaterial.AutoGenerateColumns = false;



                this.dgvMaterial.Columns.Add(new DataGridViewTextBoxColumn());
                this.dgvMaterial.Columns[this.dgvMaterial.Columns.Count - 1].DataPropertyName = "idProdutoMaterial";
                this.dgvMaterial.Columns[this.dgvMaterial.Columns.Count - 1].Name = "idProdutoMaterial";
                this.dgvMaterial.Columns[this.dgvMaterial.Columns.Count - 1].Visible = false;

                this.dgvMaterial.Columns.Add(new DataGridViewTextBoxColumn());
                this.dgvMaterial.Columns[this.dgvMaterial.Columns.Count - 1].DataPropertyName = "politicaEstoque";
                this.dgvMaterial.Columns[this.dgvMaterial.Columns.Count - 1].Name = "politicaEstoque";
                this.dgvMaterial.Columns[this.dgvMaterial.Columns.Count - 1].HeaderText = "Estoque";
                this.dgvMaterial.Columns[this.dgvMaterial.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.dgvMaterial.Columns[this.dgvMaterial.Columns.Count - 1].MinimumWidth = 80;

                this.dgvMaterial.Columns.Add(new DataGridViewTextBoxColumn());
                this.dgvMaterial.Columns[this.dgvMaterial.Columns.Count - 1].DataPropertyName = "codigoProdutoMaterial";
                this.dgvMaterial.Columns[this.dgvMaterial.Columns.Count - 1].Name = "codigoProdutoMaterial";
                this.dgvMaterial.Columns[this.dgvMaterial.Columns.Count - 1].HeaderText = "Identificação";
                this.dgvMaterial.Columns[this.dgvMaterial.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.dgvMaterial.Columns[this.dgvMaterial.Columns.Count - 1].MinimumWidth = 80;

                this.dgvMaterial.Columns.Add(new DataGridViewTextBoxColumn());
                this.dgvMaterial.Columns[this.dgvMaterial.Columns.Count - 1].DataPropertyName = "descricaoProdutoMaterial";
                this.dgvMaterial.Columns[this.dgvMaterial.Columns.Count - 1].Name = "descricaoProdutoMaterial";
                this.dgvMaterial.Columns[this.dgvMaterial.Columns.Count - 1].HeaderText = "Descrição";
                this.dgvMaterial.Columns[this.dgvMaterial.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.dgvMaterial.Columns[this.dgvMaterial.Columns.Count - 1].MinimumWidth = 120;

                this.dgvMaterial.Columns.Add(new DataGridViewTextBoxColumn());
                this.dgvMaterial.Columns[this.dgvMaterial.Columns.Count - 1].DataPropertyName = "infoAdicionalProdutoMaterial";
                this.dgvMaterial.Columns[this.dgvMaterial.Columns.Count - 1].Name = "infoAdicionalProdutoMaterial";
                this.dgvMaterial.Columns[this.dgvMaterial.Columns.Count - 1].HeaderText = "Dimensões";
                this.dgvMaterial.Columns[this.dgvMaterial.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.dgvMaterial.Columns[this.dgvMaterial.Columns.Count - 1].MinimumWidth = 100;



                List<SolicitacaoQuantidadeClass> solicitacoesLinhaAtual = new List<SolicitacaoQuantidadeClass>();

                if (this.linhaSelecionada != null)
                {
                    if (this.linhaSelecionada.Lote != null)
                    {
                        if (this.linhaSelecionada.Lote.solicitacoesCompraAtuais != null)
                        {
                            foreach (LoteSolicitacao sol in this.linhaSelecionada.Lote.solicitacoesCompraAtuais)
                            {
                                solicitacoesLinhaAtual.Add(new SolicitacaoQuantidadeClass(sol.Solicitacao, sol.quantidadeUnidadeCompra));
                            }
                        }
                    }
                }

                this.Solicitacoes.setQuantidadesLinhaSelecionada(solicitacoesLinhaAtual);

                AdvancedList<AgrupamentoSolicitacaoDisponivel> ds;

                if (this.NF.Fornecedor != null)
                {
                    ds = new AdvancedList<AgrupamentoSolicitacaoDisponivel>(this.Solicitacoes.SolicitacoesNaoRecebidasComSaldoMaterial.Where(a => a.Fornecedor == this.NF.Fornecedor));
                }
                else
                {
                    ds = new AdvancedList<AgrupamentoSolicitacaoDisponivel>(this.Solicitacoes.SolicitacoesNaoRecebidasComSaldoMaterial);
                }


                if (this.txtBuscaMaterialProduto.Text.Trim().Length > 0)
                {
                    string busca = this.txtBuscaMaterialProduto.Text.Trim().ToUpper();
                    ds = new AdvancedList<AgrupamentoSolicitacaoDisponivel>(
                        ds.Where(a => a.codigoProdutoMaterial.ToUpper().Contains(busca) || a.descricaoProdutoMaterial.ToUpper().Contains(busca) || a.infoAdicionalProdutoMaterial.ToUpper().Contains(busca)));

                }

                this.dgvMaterial.DataSource = ds;


                this.dgvMaterial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.dgvMaterial.MultiSelect = false;



                if (this.linhaSelecionada != null && this.linhaSelecionada.Material != null)
                {
                    for (int i = 0; i < this.dgvMaterial.SelectedRows.Count; i++)
                    {
                        this.dgvMaterial.SelectedRows[i].Selected = false;
                    }

                    for (int i = 0; i < this.dgvMaterial.Rows.Count; i++)
                    {
                        if (this.dgvMaterial["idProdutoMaterial", i].Value.ToString() == this.linhaSelecionada.Material.ID.ToString())
                        {
                            this.dgvMaterial.Rows[i].Selected = true;
                            break;
                        }
                    }
                }
                else
                {
                    if (this.dgvMaterial.Rows.Count > 0)
                    {
                        for (int i = 0; i < this.dgvMaterial.SelectedRows.Count; i++)
                        {
                            this.dgvMaterial.SelectedRows[i].Selected = false;
                        }

                        this.dgvMaterial.Rows[0].Selected = true;
                    }
                }
                this.loadingGridProdutoMaterial = false;
                this.initializeComboOCs();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao preencher o grid de materiais.\r\n" + e.Message, e);
            }
        }

        private void initializeGridEpi()
        {
            if (this.telaAtual != TipoTela.SelecaoLinhasEpi)
            {
                return;
            }

            try
            {
                this.loadingGridProdutoMaterial = true;

                this.dgvEpi.Columns.Clear();

                this.dgvEpi.AutoGenerateColumns = false;



                this.dgvEpi.Columns.Add(new DataGridViewTextBoxColumn());
                this.dgvEpi.Columns[this.dgvEpi.Columns.Count - 1].DataPropertyName = "idProdutoMaterial";
                this.dgvEpi.Columns[this.dgvEpi.Columns.Count - 1].Name = "idProdutoMaterial";
                this.dgvEpi.Columns[this.dgvEpi.Columns.Count - 1].Visible = false;

                this.dgvEpi.Columns.Add(new DataGridViewTextBoxColumn());
                this.dgvEpi.Columns[this.dgvEpi.Columns.Count - 1].DataPropertyName = "politicaEstoque";
                this.dgvEpi.Columns[this.dgvEpi.Columns.Count - 1].Name = "politicaEstoque";
                this.dgvEpi.Columns[this.dgvEpi.Columns.Count - 1].HeaderText = "Estoque";
                this.dgvEpi.Columns[this.dgvEpi.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.dgvEpi.Columns[this.dgvEpi.Columns.Count - 1].MinimumWidth = 80;

                this.dgvEpi.Columns.Add(new DataGridViewTextBoxColumn());
                this.dgvEpi.Columns[this.dgvEpi.Columns.Count - 1].DataPropertyName = "codigoProdutoMaterial";
                this.dgvEpi.Columns[this.dgvEpi.Columns.Count - 1].Name = "codigoProdutoMaterial";
                this.dgvEpi.Columns[this.dgvEpi.Columns.Count - 1].HeaderText = "Identificação";
                this.dgvEpi.Columns[this.dgvEpi.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.dgvEpi.Columns[this.dgvEpi.Columns.Count - 1].MinimumWidth = 80;

                this.dgvEpi.Columns.Add(new DataGridViewTextBoxColumn());
                this.dgvEpi.Columns[this.dgvEpi.Columns.Count - 1].DataPropertyName = "descricaoProdutoMaterial";
                this.dgvEpi.Columns[this.dgvEpi.Columns.Count - 1].Name = "descricaoProdutoMaterial";
                this.dgvEpi.Columns[this.dgvEpi.Columns.Count - 1].HeaderText = "Descrição";
                this.dgvEpi.Columns[this.dgvEpi.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.dgvEpi.Columns[this.dgvEpi.Columns.Count - 1].MinimumWidth = 120;

                this.dgvEpi.Columns.Add(new DataGridViewTextBoxColumn());
                this.dgvEpi.Columns[this.dgvEpi.Columns.Count - 1].DataPropertyName = "infoAdicionalProdutoMaterial";
                this.dgvEpi.Columns[this.dgvEpi.Columns.Count - 1].Name = "infoAdicionalProdutoMaterial";
                this.dgvEpi.Columns[this.dgvEpi.Columns.Count - 1].HeaderText = "Dimensões";
                this.dgvEpi.Columns[this.dgvEpi.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.dgvEpi.Columns[this.dgvEpi.Columns.Count - 1].MinimumWidth = 100;



                List<SolicitacaoQuantidadeClass> solicitacoesLinhaAtual = new List<SolicitacaoQuantidadeClass>();

                if (this.linhaSelecionada != null)
                {
                    if (this.linhaSelecionada.Lote != null)
                    {
                        if (this.linhaSelecionada.Lote.solicitacoesCompraAtuais != null)
                        {
                            foreach (LoteSolicitacao sol in this.linhaSelecionada.Lote.solicitacoesCompraAtuais)
                            {
                                solicitacoesLinhaAtual.Add(new SolicitacaoQuantidadeClass(sol.Solicitacao, sol.quantidadeUnidadeCompra));
                            }
                        }
                    }
                }

                this.Solicitacoes.setQuantidadesLinhaSelecionada(solicitacoesLinhaAtual);

                AdvancedList<AgrupamentoSolicitacaoDisponivel> ds;

                if (this.NF.Fornecedor != null)
                {
                    ds = new AdvancedList<AgrupamentoSolicitacaoDisponivel>(this.Solicitacoes.SolicitacoesNaoRecebidasComSaldoEpi.Where(a => a.Fornecedor == this.NF.Fornecedor));
                }
                else
                {
                    ds = new AdvancedList<AgrupamentoSolicitacaoDisponivel>(this.Solicitacoes.SolicitacoesNaoRecebidasComSaldoEpi);
                }


                if (this.txtBuscaMaterialProduto.Text.Trim().Length > 0)
                {
                    string busca = this.txtBuscaMaterialProduto.Text.Trim().ToUpper();
                    ds = new AdvancedList<AgrupamentoSolicitacaoDisponivel>(
                        ds.Where(a => a.codigoProdutoMaterial.ToUpper().Contains(busca) || a.descricaoProdutoMaterial.ToUpper().Contains(busca) || a.infoAdicionalProdutoMaterial.ToUpper().Contains(busca)));

                }

                this.dgvEpi.DataSource = ds;


                this.dgvEpi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.dgvEpi.MultiSelect = false;



                if (this.linhaSelecionada != null && this.linhaSelecionada.Epi != null)
                {
                    for (int i = 0; i < this.dgvEpi.SelectedRows.Count; i++)
                    {
                        this.dgvEpi.SelectedRows[i].Selected = false;
                    }

                    for (int i = 0; i < this.dgvEpi.Rows.Count; i++)
                    {
                        if (this.dgvEpi["idProdutoMaterial", i].Value.ToString() == this.linhaSelecionada.Epi.ID.ToString())
                        {
                            this.dgvEpi.Rows[i].Selected = true;
                            break;
                        }
                    }
                }
                else
                {
                    if (this.dgvEpi.Rows.Count > 0)
                    {
                        for (int i = 0; i < this.dgvEpi.SelectedRows.Count; i++)
                        {
                            this.dgvEpi.SelectedRows[i].Selected = false;
                        }

                        this.dgvEpi.Rows[0].Selected = true;
                    }
                }
                this.loadingGridProdutoMaterial = false;
                this.initializeComboOCs();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao preencher o grid de Epi.\r\n" + e.Message, e);
            }
        }

        private void initializeGridLinhas()
        {
            if (this.telaAtual != TipoTela.SelecaoLinhas && this.telaAtual != TipoTela.SelecaoLinhasMaterial && this.telaAtual != TipoTela.SelecaoLinhasProduto)
            {
                return;
            }

            try
            {

                this.dgvLinhas.Columns.Clear();

                this.dgvLinhas.AutoGenerateColumns = false;

                this.dgvLinhas.Columns.Add(new DataGridViewTextBoxColumn());
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].DataPropertyName = "Linha";
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].HeaderText = "Linha";
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].Name = "Linha";
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                this.dgvLinhas.Columns.Add(new DataGridViewTextBoxColumn());
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].DataPropertyName = "Codigo";
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].HeaderText = "Código";
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                this.dgvLinhas.Columns.Add(new DataGridViewTextBoxColumn());
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].DataPropertyName = "Descricao";
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].HeaderText = "Descrição";
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].MinimumWidth = 100;

                this.dgvLinhas.Columns.Add(new DataGridViewTextBoxColumn());
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].DataPropertyName = "Quantidade";
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].HeaderText = "Quantidade";
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                this.dgvLinhas.Columns.Add(new DataGridViewTextBoxColumn());
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].DataPropertyName = "Unidade";
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].HeaderText = "Unidade";
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                this.dgvLinhas.Columns.Add(new DataGridViewTextBoxColumn());
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].DataPropertyName = "codigoItemSistema";
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].HeaderText = "Item";
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].Name = "codigoItemSistema";
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.dgvLinhas.Columns[this.dgvLinhas.Columns.Count - 1].MinimumWidth = 150;


                this.dgvLinhas.DataSource = new AdvancedList<NFEntradaItemClass>(this.NF.linhasNaoVinculadas);


                this.dgvLinhas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.dgvLinhas.MultiSelect = false;

                if (this.dgvLinhas.Rows.Count > 0 && this.dgvLinhas.SelectedRows.Count == 0)
                {
                    this.dgvLinhas.Rows[0].Selected = true;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao preencher o grid de linhas.\r\n" + e.Message, e);
            }
        }

        private void initializeComboOCs()
        {

            try
            {
                if (this.loadingGridProdutoMaterial)
                {
                    return;
                }


                this.carregarLabelUnidade();

                List<SolicitacaoDisponivel> dadosCombo = new List<SolicitacaoDisponivel>();
                if (this.linhaSelecionada == null) return;
                switch (this.telaAtual)
                {
                    case TipoTela.SelecaoLinhasMaterial:
                        if (this.dgvMaterial.SelectedRows.Count > 0)
                        {
                            int idMaterialSelecionado = Convert.ToInt32(this.dgvMaterial.SelectedRows[0].Cells["idProdutoMaterial"].Value);
                            dadosCombo = this.Solicitacoes.getSolicitacoesMaterialComSaldo(idMaterialSelecionado);

                        }
                        else
                        {
                            return;
                        }
                        break;
                    case TipoTela.SelecaoLinhasProduto:
                        if (this.dgvProduto.SelectedRows.Count > 0)
                        {
                            int idProdutoSelecionado = Convert.ToInt32(this.dgvProduto.SelectedRows[0].Cells["idProdutoMaterial"].Value);
                            dadosCombo = this.Solicitacoes.getSolicitacoesProdutoComSaldo(idProdutoSelecionado);
                        }
                        else
                        {
                            return;
                        }
                        break;
                    case TipoTela.SelecaoLinhasEpi:
                        if (this.dgvEpi.SelectedRows.Count > 0)
                        {
                            int idEpiSelecionado = Convert.ToInt32(this.dgvEpi.SelectedRows[0].Cells["idProdutoMaterial"].Value);
                            dadosCombo = this.Solicitacoes.getSolicitacoesEpiComSaldo(idEpiSelecionado);
                        }
                        else
                        {
                            return;
                        }
                        break;
                    default:
                        return;
                }

                if (NF.Fornecedor != null)
                {
                    dadosCombo = new List<SolicitacaoDisponivel>(dadosCombo.Where(a => a.Solicitacao.OrdemCompra.Fornecedor == NF.Fornecedor));
                }

                //BindingList<SolicitacaoCompraClass> list = new BindingList<SolicitacaoCompraClass>(dadosCombo);
                this.cmbOrdemCompra.DataSource = dadosCombo;
                this.cmbOrdemCompra.ValueMember = "idSolicitacaoCompra";
                this.cmbOrdemCompra.DisplayMember = "identificacaoCompletaSolicitacao";


            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados do combo de ocs\r\n" + e.Message, e);
            }
        }

        private void carregarLabelUnidade()
        {
            try
            {
                string unidadeCompra = "";
                string unidadeUso = "";
                string maximoTolerancia = "";

                if (this.telaAtual == TipoTela.SelecaoLinhasMaterial)
                {
                    if (this.dgvMaterial.SelectedRows.Count > 0)
                    {
                        AgrupamentoSolicitacaoDisponivel selecionado = (AgrupamentoSolicitacaoDisponivel) this.dgvMaterial.SelectedRows[0].DataBoundItem;

                        if (cmbOrdemCompra.Enabled)
                        {
                            if (this.cmbOrdemCompra.SelectedItem!=null)
                            {
                                SolicitacaoDisponivel solicitacao = (SolicitacaoDisponivel) this.cmbOrdemCompra.SelectedItem;
                                unidadeUso = solicitacao.unidadeUsoProdutoMaterial;
                                maximoTolerancia = solicitacao.StringQuantidadeMaxima;

                            }
                            else
                            {
                                unidadeUso = "";
                                maximoTolerancia = "";
                                
                            }
                        }
                        else
                        {

                            if (selecionado.UnidadeCompra != null)
                            {
                                unidadeCompra = selecionado.UnidadeCompra;
                            }

                            unidadeUso = selecionado.unidadeUsoProdutoMaterial;
                            maximoTolerancia = selecionado.StringQuantidadeMaxima;
                        }
                    }
                }
                else
                {
                    if (this.telaAtual == TipoTela.SelecaoLinhasProduto)
                    {
                        if (this.dgvProduto.SelectedRows.Count > 0)
                        {
                            AgrupamentoSolicitacaoDisponivel selecionado = (AgrupamentoSolicitacaoDisponivel) this.dgvProduto.SelectedRows[0].DataBoundItem;

                            if (cmbOrdemCompra.Enabled)
                            {
                                if (this.cmbOrdemCompra.SelectedItem != null)
                                {
                                    SolicitacaoDisponivel solicitacao = (SolicitacaoDisponivel) this.cmbOrdemCompra.SelectedItem;
                                    unidadeUso = solicitacao.unidadeUsoProdutoMaterial;
                                    maximoTolerancia = solicitacao.StringQuantidadeMaxima;

                                }
                                else
                                {
                                    unidadeUso = "";
                                    maximoTolerancia = "";

                                }
                            }
                            else
                            {

                                if (selecionado.UnidadeCompra != null)
                                {
                                    unidadeCompra = selecionado.UnidadeCompra;
                                }
                                unidadeUso = selecionado.unidadeUsoProdutoMaterial;
                                maximoTolerancia = selecionado.StringQuantidadeMaxima;
                            }
                        }
                    }
                }

                this.lblUnidadeIdentificacao.Text = unidadeCompra.Length > 0 ? unidadeCompra : unidadeUso;
                this.lblUnidadeIdentificacao.Text += "  -  Máximo Permitido = " + maximoTolerancia;


            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar o label de unidade\r\n" + e.Message, e);
            }
        }

        private void initializeComboEmissorCertificado()
        {
            string sql =
                    "SELECT  " +
                    "  id_emissor_certificado, " +
                    "  emc_identificacao " +
                    "FROM  " +
                    "  public.emissor_certificado " +
                    "ORDER BY emc_identificacao";


            IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.conn);
            if (adapter != null)
            {
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                BindingSource binding = new BindingSource();
                binding.DataSource = ds.Tables[0];
                this.cmbEntidadeCertificadora.DataSource = binding;
                this.cmbEntidadeCertificadora.ValueMember = "id_emissor_certificado";
                this.cmbEntidadeCertificadora.DisplayMember = "emc_identificacao";


            }
        }

        private void initializeGridEstoques()
        {
            try
            {
                if (this.telaAtual != TipoTela.SelecaoEstoque) return;

                this.dgvEstoque.Columns.Clear();

                this.dgvEstoque.AutoGenerateColumns = false;
                this.dgvEstoque.ReadOnly = false;

                this.dgvEstoque.Columns.Add(new DataGridViewTextBoxColumn());
                this.dgvEstoque.Columns[this.dgvEstoque.Columns.Count - 1].DataPropertyName = "Gaveta";
                this.dgvEstoque.Columns[this.dgvEstoque.Columns.Count - 1].HeaderText = "Gaveta";
                this.dgvEstoque.Columns[this.dgvEstoque.Columns.Count - 1].Name = "Gaveta";
                this.dgvEstoque.Columns[this.dgvEstoque.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.dgvEstoque.Columns[this.dgvEstoque.Columns.Count - 1].ReadOnly = true;

                this.dgvEstoque.Columns.Add(new DataGridViewTextBoxColumn());
                this.dgvEstoque.Columns[this.dgvEstoque.Columns.Count - 1].DataPropertyName = "Quantidade";
                this.dgvEstoque.Columns[this.dgvEstoque.Columns.Count - 1].HeaderText = "Quantidade";
                this.dgvEstoque.Columns[this.dgvEstoque.Columns.Count - 1].Name = "Quantidade";
                this.dgvEstoque.Columns[this.dgvEstoque.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.dgvEstoque.Columns[this.dgvEstoque.Columns.Count - 1].ReadOnly = false;


                this.dgvEstoque.DataSource = new BindingList<LoteEstoque>(this.linhaSelecionada.Lote.gavetasEstoque);

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados do estoque.\r\n" + e.Message, e);
            }
        }

        private void selecionaLinha()
        {
            try
            {
                if (this.loading) return;
                if (this.dgvLinhas.SelectedRows.Count > 0)
                {
                    int numeroLinha = Convert.ToInt32(this.dgvLinhas.SelectedRows[0].Cells["Linha"].Value);
                    this.linhaSelecionada = this.NF.linhasAtuais[numeroLinha];

                    if (this.linhaSelecionada.solicitacaoCompra == null)
                    {
                        if (this.rdbMaterial.Checked)
                        {
                            this.setScreenMode(TipoTela.SelecaoLinhasMaterial);
                        }
                        else
                        {
                            if (this.rdbProduto.Checked)
                            {
                                this.setScreenMode(TipoTela.SelecaoLinhasProduto);
                            }
                            else
                            {
                                if (rdbEpi.Checked)
                                {
                                    this.setScreenMode(TipoTela.SelecaoLinhasEpi);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (this.linhaSelecionada.Material != null)
                        {
                            this.setScreenMode(TipoTela.SelecaoLinhasMaterial);
                        }
                        else
                        {
                            this.setScreenMode(TipoTela.SelecaoLinhasProduto);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao selecionar a linha para entrada de dados\r\n" + e.Message, e);
            }
        }

        private void Ok()
        {
            try
            {
                if (this.telaAtual != TipoTela.SelecaoEstoque)
                {

                    BibliotecaEntidades.Entidades.MaterialClass material = null;
                    BibliotecaEntidades.Entidades.ProdutoClass produto = null;
                    EpiClass epi = null;

                    string codigoItem;
                    string descricaoItem;
                    double qtdPorUnidadeCompra = 1;

                    if (this.rdbMaterial.Checked)
                    {
                        if (this.dgvMaterial.SelectedRows.Count > 0)
                        {
                            AgrupamentoSolicitacaoDisponivel selecionado = (AgrupamentoSolicitacaoDisponivel)this.dgvMaterial.SelectedRows[0].DataBoundItem;

                            material =
                                MaterialBaseClass.GetEntidade(
                                    Convert.ToInt32(this.dgvMaterial.SelectedRows[0].Cells["idProdutoMaterial"].Value), this.Usuario, this.conn);
                            codigoItem = this.dgvMaterial.SelectedRows[0].Cells["codigoProdutoMaterial"].Value.ToString();
                            descricaoItem = this.dgvMaterial.SelectedRows[0].Cells["descricaoProdutoMaterial"].Value.ToString();

                            if (selecionado.UnidadeCompra != null)
                            {
                                qtdPorUnidadeCompra = selecionado.UnidadesUsoPorUnidadeCompra;
                            }
                        }
                        else
                        {
                            throw new Exception("Selecione um material antes de continuar.");
                        }
                    }
                    else
                    {
                        if (this.rdbEpi.Checked)
                        {
                            if (this.dgvEpi.SelectedRows.Count > 0)
                            {
                                AgrupamentoSolicitacaoDisponivel selecionado = (AgrupamentoSolicitacaoDisponivel)this.dgvEpi.SelectedRows[0].DataBoundItem;

                                epi =
                                    EpiBaseClass.GetEntidade(Convert.ToInt32(this.dgvEpi.SelectedRows[0].Cells["idProdutoMaterial"].Value), this.Usuario, this.SingleConnection);
                                codigoItem = this.dgvEpi.SelectedRows[0].Cells["codigoProdutoMaterial"].Value.ToString();
                                descricaoItem = this.dgvEpi.SelectedRows[0].Cells["descricaoProdutoMaterial"].Value.ToString();

                                if (selecionado.UnidadeCompra != null)
                                {
                                    qtdPorUnidadeCompra = selecionado.UnidadesUsoPorUnidadeCompra;
                                }
                            }
                            else
                            {
                                throw new Exception("Selecione um epi antes de continuar.");
                            }
                        }
                        else
                        {
                            if (this.dgvProduto.SelectedRows.Count > 0)
                            {
                                AgrupamentoSolicitacaoDisponivel selecionado = (AgrupamentoSolicitacaoDisponivel)this.dgvProduto.SelectedRows[0].DataBoundItem;

                                produto =
                                    ProdutoBaseClass.GetEntidade(
                                        Convert.ToInt32(this.dgvProduto.SelectedRows[0].Cells["idProdutoMaterial"].Value),
                                        this.Usuario, this.conn);

                                codigoItem = this.dgvProduto.SelectedRows[0].Cells["codigoProdutoMaterial"].Value.ToString();
                                descricaoItem = this.dgvProduto.SelectedRows[0].Cells["descricaoProdutoMaterial"].Value.ToString();

                                if (selecionado.UnidadeCompra != null)
                                {
                                    qtdPorUnidadeCompra = selecionado.UnidadesUsoPorUnidadeCompra;
                                }
                            }
                            else
                            {
                                throw new Exception("Selecione um produto antes de continuar.");
                            }
                        }
                    }

                    SolicitacaoCompraClass solicitacao = null;
                    if (this.cmbOrdemCompra.Enabled)
                    {
                        if (this.cmbOrdemCompra.SelectedValue != null)
                        {
                            solicitacao = this.Solicitacoes.getSolicitacaoByID(Convert.ToInt32(this.cmbOrdemCompra.SelectedValue)).Solicitacao;
                        }
                        else
                        {
                            throw new Exception("Selecione uma solicitação de compra ou deixe a seleção automática");
                        }
                    }




                    string numeroLote = null;
                    //if (this.txtNumeroLote.Enabled)
                    //{
                    //    if (this.txtNumeroLote.Text.Trim().Length > 0)
                    //    {
                    numeroLote = this.txtNumeroLote.Text.Trim();
                    //    }
                    //    else
                    //    {
                    //        throw new Exception("Preencha o número do lote ou deixe no automático.");
                    //    }
                    //}

                    DateTime? dataEmbalagem = null;
                    if (this.dtpEmbalagem.Enabled)
                    {
                        dataEmbalagem = this.dtpEmbalagem.Value;
                    }

                    DateTime? dataFabricacao = null;
                    if (this.dtpFabricacao.Enabled)
                    {
                        dataFabricacao = this.dtpFabricacao.Value;
                    }

                    DateTime? dataValidade = null;
                    if (this.dtpValidade.Enabled)
                    {
                        dataValidade = this.dtpValidade.Value;
                    }

                    int? idEntidadeCertificadora = null;
                    string entidadeCertificadora = "";
                    if (this.cmbEntidadeCertificadora.Enabled)
                    {
                        if (this.cmbEntidadeCertificadora.SelectedValue == null)
                        {
                            throw new Exception("Selecione uma entidade certificadora ou desabilite o campo");
                        }

                        idEntidadeCertificadora = Convert.ToInt32(this.cmbEntidadeCertificadora.SelectedValue);
                        entidadeCertificadora = this.cmbEntidadeCertificadora.Text;
                    }


                    if (this.linhaSelecionada.Lote == null)
                    {
                        this.linhaSelecionada.setLote(
                            produto,
                            material,
                            epi,
                            solicitacao,
                            this.NF.Fornecedor,
                            numeroLote,
                            Convert.ToDouble(this.nudQtdRecebida.Value) * qtdPorUnidadeCompra,
                            Convert.ToDouble(this.nudQtdRecebida.Value),
                            qtdPorUnidadeCompra,
                            dataFabricacao,
                            dataEmbalagem,
                            dataValidade,
                            codigoItem,
                            descricaoItem,
                            idEntidadeCertificadora,
                            entidadeCertificadora,
                            this.txtObs.Text,
                            this.txtCertificado.Text,
                            Convert.ToInt32(this.nudQtdEtiquetasLote.Value),
                            ref this.Solicitacoes,
                            this);
                    }
                    else
                    {
                        this.linhaSelecionada.alterarLote(
                            produto,
                            material,
                            epi,
                            solicitacao,
                            this.NF.Fornecedor,
                            numeroLote,
                            Convert.ToDouble(this.nudQtdRecebida.Value) * qtdPorUnidadeCompra,
                            Convert.ToDouble(this.nudQtdRecebida.Value),
                            qtdPorUnidadeCompra,
                            dataFabricacao,
                            dataEmbalagem,
                            dataValidade,
                            codigoItem,
                            descricaoItem,
                            idEntidadeCertificadora,
                            entidadeCertificadora,
                            this.txtObs.Text,
                            this.txtCertificado.Text,
                            Convert.ToInt32(this.nudQtdEtiquetasLote.Value),
                            ref this.Solicitacoes, 
                            this);
                    }

                    this.setScreenMode(TipoTela.SelecaoEstoque);
                }
                else
                {
                    this.linhaSelecionada.Lote.quantidadeEstoqueValida();
                    this.proximaLinha();
                }

            }
            catch (Exception e)
            {
                this.linhaSelecionada.limparLote();
                throw new Exception("Erro ao atualizar os dados das linhas\r\n" + e.Message, e);
            }
        }

        private void itemComUmEstoque()
        {
            try
            {
                this.loading = false;
                this.proximaLinha();
                this.loading = true;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao definir o estoque unico.\r\n" + e.Message, e);
            }
        }

        private void itemSemEstoque()
        {
            try
            {
                MessageBox.Show(this, "Esse item não possui nenhuma localização de estoque selecionada. Você deverá escolher uma agora.", "Item sem localização de estoque", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EnviaItemEstoqueForm form;
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                if (this.linhaSelecionada.Material != null)
                {
                    

                    form = new EnviaItemEstoqueForm(
                        EnviaItemEstoqueForm.tipoUtilizacao.Material,
                        this.dgvMaterial.SelectedRows[0].Cells["codigoProdutoMaterial"].Value.ToString(),
                        false,
                        0,
                        ((AgrupamentoSolicitacaoDisponivel)(this.dgvMaterial.SelectedRows[0].DataBoundItem)).UnidadesUsoPorUnidadeCompra.ToString(),
                        false,
                        "Criação da Gaveta",
                        this.linhaSelecionada.Material,
                        false,
                        null,
                        this.Usuario,
                        this.conn,
                        ref command,
                        "Recebimento");
                }
                else
                {
                    if (linhaSelecionada.Produto!=null)
                    {
                        form = new EnviaItemEstoqueForm(
                            EnviaItemEstoqueForm.tipoUtilizacao.Produto,
                            this.dgvProduto.SelectedRows[0].Cells["codigoProdutoMaterial"].Value.ToString(),
                            false,
                            0,
                            ((AgrupamentoSolicitacaoDisponivel) (this.dgvProduto.SelectedRows[0].DataBoundItem)).UnidadesUsoPorUnidadeCompra.ToString(),
                            false,
                            "Criação da Gaveta",
                            this.linhaSelecionada.Produto,
                            false,
                            null,
                            this.Usuario,
                            this.conn,
                            ref command,
                            "Recebimento");
                    }
                    else
                    {
                        if (linhaSelecionada.Epi != null)
                        {
                            form = new EnviaItemEstoqueForm(
                                EnviaItemEstoqueForm.tipoUtilizacao.Epi,
                                this.dgvEpi.SelectedRows[0].Cells["codigoProdutoMaterial"].Value.ToString(),
                                false,
                                0,
                                ((AgrupamentoSolicitacaoDisponivel)(this.dgvEpi.SelectedRows[0].DataBoundItem)).UnidadesUsoPorUnidadeCompra.ToString(),
                                false,
                                "Criação da Gaveta",
                                this.linhaSelecionada.Epi,
                                false,
                                null,
                                this.Usuario,
                                this.conn,
                                ref command,
                                "Recebimento");
                        }
                        else
                        {
                            throw new ExcecaoTratada("Tipo de Item inválido para a seleção de estoques");
                        }
                    }
                }

                form.ShowDialog();
                if (form.Cancelar)
                {
                    this.loading = false;
                    this.linhaSelecionada.recarregarEstoquesLote();
                    this.selecionaLinha();
                    this.loading = true;
                    this.setScreenMode(TipoTela.SelecaoLinhas);
                }
                else
                {
                    this.loading = false;
                    this.linhaSelecionada.recarregarEstoquesLote();
                    this.selecionaLinha();
                    this.loading = true;
                    this.setScreenMode(TipoTela.SelecaoEstoque);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao criar um novo estoque para o item.\r\n" + e.Message, e);
            }
        }

        private void proximaLinha()
        {
            try
            {
                if (this.NF.todasLinhasVinculadas())
                {
                    //Ultima linha
                    if (MessageBox.Show(this, "Você editou a ultima linha da nota fiscal, deseja salvar agora?", "Salvar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.Avancar();
                    }
                    else
                    {
                        this.setScreenMode(TipoTela.SelecaoLinhas);
                    }
                }
                else
                {
                    if (this.dgvLinhas.SelectedRows.Count > 0)
                    {
                        int indexLinhaAtual = this.dgvLinhas.SelectedRows[0].Index;
                        if (indexLinhaAtual == this.dgvLinhas.Rows.Count - 1)
                        {

                            this.setScreenMode(TipoTela.SelecaoLinhas);

                        }
                        else
                        {
                            this.dgvLinhas.Rows[indexLinhaAtual].Selected = false;
                            this.dgvLinhas.Rows[indexLinhaAtual + 1].Selected = true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao selecionar a próxima linha.\r\n" + e.Message, e);
            }
        }

        private void Avancar()
        {
            try
            {
                switch (this.telaAtual)
                {
                    case TipoTela.SelecaoFornecedor:
                        //if (this.NF.idFornecedor == null)
                        //{
                        if (this.dgvFornecedor.SelectedRows.Count > 0)
                        {
                            if (MessageBox.Show(this,"O fornecedor selecionado foi: "+this.dgvFornecedor.SelectedRows[0].Cells["for_razao_social"].Value+" - CNPJ: "+this.dgvFornecedor.SelectedRows[0].Cells["for_cnpj"].Value+". Deseja continuar?","Seleção de Fornecedor",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                this.NF.Fornecedor = FornecedorClass.GetEntidade(Convert.ToInt32(this.dgvFornecedor.SelectedRows[0].Cells["id_fornecedor"].Value), Usuario, conn);
                            }
                            else
                            {
                                return;
                            }


                            
                        }
                        else
                        {
                            throw new Exception("Selecione um fornecedor antes de continuar");
                        }
                        //}

                        this.setScreenMode(TipoTela.SelecaoLinhas);

                        break;
                    case TipoTela.SelecaoLinhasMaterial:
                    case TipoTela.SelecaoLinhasProduto:
                    case TipoTela.SelecaoEstoque:

                        if (this.NF.todasLinhasVinculadas())
                        {
                            IWTPostgreNpgsqlCommand command = null;
                            try
                            {
                                command = this.conn.CreateCommand();
                                command.Transaction = this.conn.BeginTransaction();

                                this.NF.Salvar(this, ref command);
                                AvisoRecebimentoReportForm form = new AvisoRecebimentoReportForm(this.NF);
                                this.Hide();
                                form.ShowDialog();

                                List<LoteClass> lotesEtiqueta = new List<LoteClass>();

                                foreach (NFEntradaItemClass linha in this.NF.linhasAtuais.Values.Where(a => a.Lote.qtdEtiquetas > 0))
                                {
                                    lotesEtiqueta.Add(linha.Lote);
                                }

                                if (lotesEtiqueta.Count > 0)
                                {
                                    LoteEtiquetaReportForm form2 = new LoteEtiquetaReportForm(lotesEtiqueta, this.internalLabelPrinter, this.internalLabelPaper);
                                    form2.ShowDialog();

                                }

                                if (lotesEtiqueta.Count(
                                    a=>
                                    (a.Produto != null && a.Produto.PoliticaEstoque == PoliticaEstoque.MRP) ||
                                    (a.Material!=null && a.Material.PoliticaEstoque == PoliticaEstoque.MRP)
                                    )>0)
                                {
                                    LoteEtiquetaMRPReportForm form3 = new LoteEtiquetaMRPReportForm(lotesEtiqueta,
                                                                                                    this.conn,
                                                                                                    this.internalLabelPrinter,
                                                                                                    this.internalLabelPaper);
                                    form3.ShowDialog();
                                }
                                
                                command.Transaction.Commit();

                                this.Show();
                                MessageBox.Show(this, "Recebimento concluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            catch (Exception a)
                            {
                                this.Show();
                                if (command != null && command.Transaction != null)
                                {
                                    command.Transaction.Rollback();
                                }
                                throw a;
                            }
                        }
                        else
                        {
                            throw new Exception("Não é possível avançar pois existem linhas não preenchidas.");
                        }

                        break;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao avançar o passo da tela.\r\n" + e.Message, e);
            }

        }

        private void Voltar()
        {
            try
            {
                switch (this.telaAtual)
                {
                    case TipoTela.SelecaoFornecedor:
                        this.Close();
                        return;
                        break;
                    case TipoTela.SelecaoLinhasMaterial:
                    case TipoTela.SelecaoLinhasProduto:

                        this.setScreenMode(TipoTela.SelecaoFornecedor);
                        break;
                    case TipoTela.SelecaoEstoque:
                        this.selecionaLinha();

                        break;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao voltar.\r\n" + e.Message, e);
            }
        }

        private void carregarCabecalho()
        {
            try
            {
                if (this.NF != null)
                {
                    this.lblNFCNPJ.Text = this.NF.CNPJFornecedor;
                    this.lblNFData.Text = this.NF.dataNf.ToString("dd/MM/yyyy");
                    this.lblNFFornecedor.Text = this.NF.razaoFornecedor;
                    this.lblNFNumero.Text = this.NF.Numero;
                    this.lblNFSerie.Text = this.NF.Serie;

                    if ((this.NF.Fornecedor) == null)
                    {
                        this.lblNFFornecedorSelecionado.Text = "";
                    }
                    else
                    {
                        this.lblNFFornecedorSelecionado.Text = this.NF.nomeFornecedorSistema;
                    }

                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados cabeçalho.\r\n" + e.Message, e);
            }
        }

        #region Eventos
        private void txtBuscaFornecedor_TextChanged(object sender, EventArgs e)
        {
            timFornecedor.Stop();
            timFornecedor.Start();
        }

        private void timFornecedor_Tick(object sender, EventArgs e)
        {
            try
            {
                timFornecedor.Enabled = false;
                this.initializeGridFornecedor();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timMaterialProduto_Tick(object sender, EventArgs e)
        {
            try
            {
                timMaterialProduto.Enabled = false;
                this.initializeGridProdutoMaterial();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbMaterial_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.rdbMaterial.Checked)
                {
                    this.setScreenMode(TipoTela.SelecaoLinhasMaterial);
                }
                else
                {
                    if (this.rdbProduto.Checked)
                    {
                        this.setScreenMode(TipoTela.SelecaoLinhasProduto);
                    }
                    else
                    {
                        this.setScreenMode(TipoTela.SelecaoLinhasEpi);
                    }
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbProduto_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.rdbMaterial.Checked)
                {
                    this.setScreenMode(TipoTela.SelecaoLinhasMaterial);
                }
                else
                {
                    if (this.rdbProduto.Checked)
                    {
                        this.setScreenMode(TipoTela.SelecaoLinhasProduto);
                    }
                    else
                    {
                        this.setScreenMode(TipoTela.SelecaoLinhasEpi);
                    }
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbEpi_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.rdbMaterial.Checked)
                {
                    this.setScreenMode(TipoTela.SelecaoLinhasMaterial);
                }
                else
                {
                    if (this.rdbProduto.Checked)
                    {
                        this.setScreenMode(TipoTela.SelecaoLinhasProduto);
                    }
                    else
                    {
                        this.setScreenMode(TipoTela.SelecaoLinhasEpi);
                    }
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void txtBuscaMaterialProduto_TextChanged(object sender, EventArgs e)
        {
            timMaterialProduto.Stop();
            timMaterialProduto.Start();
        }

        private void chkOrdemCompra_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.chkOrdemCompra.Checked)
                {
                    if (this.cmbOrdemCompra.DataSource !=null && ((List<SolicitacaoDisponivel>)this.cmbOrdemCompra.DataSource).Count == 0)
                    {
                        this.chkOrdemCompra.Checked = false;
                    }
                }

                this.cmbOrdemCompra.Enabled = chkOrdemCompra.Checked;

                carregarLabelUnidade();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                this.Ok();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAvançar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Avancar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Voltar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLinhas_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                this.selecionaLinha();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProduto_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                this.initializeComboOCs();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMaterial_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                this.initializeComboOCs();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvEstoque_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                double temp = 0;
                if (!double.TryParse(e.FormattedValue.ToString(), out temp))
                {
                    this.dgvEstoque.Rows[e.RowIndex].ErrorText = "Quantidade inválida";
                    MessageBox.Show(this, "Valor inválido para a quantidade", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
        }

        private void dgvEstoque_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvEstoque.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        private void dgvEstoque_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // If the data source raises an exception when a cell value is 
            // commited, display an error message.
            if (e.Exception != null)
            {
                if ((e.Context & DataGridViewDataErrorContexts.Parsing) != 0)
                {
                    this.dgvEstoque.Rows[e.RowIndex].ErrorText = "Quantidade inválida";
                    MessageBox.Show(this, "Valor inválido para a quantidade", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void chkFabricacao_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpFabricacao.Enabled = this.chkFabricacao.Checked;
        }

        private void chkEmbalagem_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpEmbalagem.Enabled = this.chkEmbalagem.Checked;
        }

        private void chkValidade_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpValidade.Enabled = this.chkValidade.Checked;
        }

        private void chkEntidadeCertificadora_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.cmbEntidadeCertificadora.Enabled = chkEntidadeCertificadora.Checked;
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLinhas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (this.dgvLinhas.Columns[e.ColumnIndex].Name == "codigoItemSistema")
                {
                    if (this.dgvLinhas["codigoItemSistema", e.RowIndex].Value == null || dgvLinhas["codigoItemSistema", e.RowIndex].Value.ToString().Length == 0)
                    {
                        foreach (DataGridViewCell cell in dgvLinhas.Rows[e.RowIndex].Cells)
                        {
                            cell.Style.BackColor = Color.White;
                        }
                    }
                    else
                    {
                        foreach (DataGridViewCell cell in dgvLinhas.Rows[e.RowIndex].Cells)
                        {
                            cell.Style.BackColor = Color.LightGreen;
                        }
                    }
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
     
        private void dgvMaterial_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (this.dgvMaterial.Columns[e.ColumnIndex].Name == "politicaEstoque")
                {
                    if (this.dgvMaterial["politicaEstoque", e.RowIndex].Value.ToString() == "MRP")
                    {
                        foreach (DataGridViewCell cell in dgvMaterial.Rows[e.RowIndex].Cells)
                        {
                            cell.Style.ForeColor = Color.Blue;
                        }
                    }
                    //else
                    //{
                    //    if (this.dgvMaterial["politicaEstoque", e.RowIndex].Value.ToString() == "Kanban")
                    //    {
                    //        foreach (DataGridViewCell cell in dgvMaterial.Rows[e.RowIndex].Cells)
                    //        {
                    //            cell.Style.BackColor = Color.LightGreen;
                    //        }
                    //    }
                    //}
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProduto_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (this.dgvProduto.Columns[e.ColumnIndex].Name == "politicaEstoque")
                {
                    if (this.dgvProduto["politicaEstoque", e.RowIndex].Value.ToString() == "MRP")
                    {
                        foreach (DataGridViewCell cell in dgvProduto.Rows[e.RowIndex].Cells)
                        {
                            cell.Style.ForeColor = Color.Blue;
                        }
                    }
                    //else
                    //{
                    //    if (this.dgvMaterial["politicaEstoque", e.RowIndex].Value.ToString() == "Kanban")
                    //    {
                    //        foreach (DataGridViewCell cell in dgvMaterial.Rows[e.RowIndex].Cells)
                    //        {
                    //            cell.Style.BackColor = Color.LightGreen;
                    //        }
                    //    }
                    //}
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void dgvEpi_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                this.initializeComboOCs();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvEpi_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           
        }

        private void cmbOrdemCompra_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
{
    carregarLabelUnidade();
}
catch (Exception a)
{
    MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
        }

      




    }
}
