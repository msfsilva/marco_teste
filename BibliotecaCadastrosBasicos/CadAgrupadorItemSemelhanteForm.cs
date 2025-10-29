using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using ProjectConstants;


namespace BibliotecaCadastrosBasicos
{
    public partial class CadAgrupadorItemSemelhanteForm : IWTForm
    {

        private decimal sugestao_acima_config  = Convert.ToDecimal(IWTConfiguration.Conf.getConf(Constants.PERCENTUAL_GERACAO_OP_KB_ACIMA_ESTOQUE_VERDE));
        private bool loadingComboProduto = true;
        private bool Loading;
        private bool _salvarComo = false;

        private ProdutoKClass KbManufaturado
        {
            get { return (ProdutoKClass) this.Entity; }
        }

        public CadAgrupadorItemSemelhanteForm(ProdutoKClass entidade)
            : base(entidade, typeof(ProdutoKClass), LoginClass.UsuarioLogado.loggedUser,null)
        {
            InitializeComponent();

            this.ensProduto.FormSelecao = new CadProdutoListForm(TipoModulo.Tipo, somenteAtivos: true);
    
        }

        public CadAgrupadorItemSemelhanteForm(ProdutoKClass entidade, CadAgrupadorItemSemelhanteListForm listForm)
            : base(entidade, listForm, listForm.SingleConnection)
        {

            InitializeComponent();
            this.ensProduto.FormSelecao = new CadProdutoListForm(TipoModulo.Tipo, somenteAtivos: true);

        }




        //Faz a selecao correta do item no combo caso a tela seja modo Kanban
        private void cmbProdutoSelecaoModoKanban()
        {

            try
            {
                loadingComboProduto = true;
                if ((((ProdutoKClass) this.Entity).CollectionProdutoKProdutoClassProdutoK).Count == 1)
                {
                    this.ensProduto.EntidadeSelecionada = (((ProdutoKClass) this.Entity).CollectionProdutoKProdutoClassProdutoK)[0].Produto;
                }
                else
                {
                   this.ensProduto.Clear();
                    this.ensProduto_EntityChange(null, null);
                }


                loadingComboProduto = false;
            }
            catch(Exception e)
            {
                throw new Exception("Erro ao selecionar o produto.\r\n" + e.Message);
            }
        }

        //Carrega a quantidade por etiqueta no componente
        private void nudQtdPorEtiquetaSetValorModoKanban()
        {
            if ((((ProdutoKClass)this.Entity).CollectionProdutoKEtiquetaClassProdutoK).Count == 1)
            {
                    nudQtdPorEtiqueta.Value = Convert.ToDecimal((((ProdutoKClass)this.Entity).CollectionProdutoKEtiquetaClassProdutoK).ToArray()[0].QuantidadePorEtiqueta);
            }
        }


        private void configuraModoVisualizacao()
        {
            
            if (rdKbManufaturado.Checked)
            {
                dgvProdutos.Visible = false;
                dgvEtiquetas.Visible = false;
                btnProdutoAdicionar.Visible = false;
                btnProdutoRemover.Visible = false;
                btnEtiquetaAdicionar.Visible = false;
                btnEtiquetaRemover.Visible = false;
                if (this.WindowState!=FormWindowState.Maximized &&  this.Height < 470)
                {
                    this.Height = 470;
                }
            }
            else
            {
                dgvProdutos.Visible = true;
                dgvEtiquetas.Visible = true;
                btnProdutoAdicionar.Visible = true;
                btnProdutoRemover.Visible = true;
                btnEtiquetaAdicionar.Visible = true;
                btnEtiquetaRemover.Visible = true;
                if (this.WindowState != FormWindowState.Maximized && this.Height < 632)
                {
                    this.Height = 632;
                }
            }
        }

        private void atualizaValorProduzir()
        {
            if (this.Entity.ID==-1 || !this.Loading)
            {
                decimal produzir = nudVerde.Value + (nudVerde.Value*(sugestao_acima_config/100));
                if (produzir%1 > 0)
                {
                    produzir = (produzir + 1) - (produzir%1);
                }

                nudLoteProducao.Value = produzir;
            }

        }

        private void loadComboClassificacao()
        {
            try
            {
                ClassificacaoProdutoClass classificacao = new ClassificacaoProdutoClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<ClassificacaoProdutoClass> classificacoes =
                    classificacao.Search(new List<SearchParameterClass> {new SearchParameterClass("clp_identificacao", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String)}).ConvertAll(a => (ClassificacaoProdutoClass) a);


                this.cmbClassificacao.DataSource = classificacoes;
                this.cmbClassificacao.DisplayMember = "Identificacao";
                this.cmbClassificacao.ValueMember = "ID";
                this.cmbClassificacao.autoSize = true;
                this.cmbClassificacao.Table = classificacoes;
                this.cmbClassificacao.ColumnsToDisplay = new[] { "Identificacao", "Descricao" };
                this.cmbClassificacao.HeadersToDisplay = new[] { "Identificação", "Descrição" };

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção da classificação.\r\n" + e.Message);
            }
        }

        private void initializeGridProdutos()
        {
            this.dgvProdutos.DataSource = null;
            this.dgvProdutos.DataSource = new AdvancedList<ProdutoKProdutoClass>(((ProdutoKClass)this.Entity).CollectionProdutoKProdutoClassProdutoK);
            this.dgvProdutos.Refresh();

            ListSortDirection ls = ListSortDirection.Ascending;
            if (this.dgvProdutos.SortOrder==SortOrder.Descending)
            {
                ls = ListSortDirection.Descending;
            }

            this.dgvProdutos.Sort(this.dgvProdutos.SortedColumn ?? this.dgvProdutos.Columns[0], ls);
        }

        private void initializeGridEtiquetas()
        {
            this.dgvEtiquetas.DataSource = null;
            this.dgvEtiquetas.DataSource = new AdvancedList<ProdutoKEtiquetaClass>(((ProdutoKClass) this.Entity).CollectionProdutoKEtiquetaClassProdutoK);
            this.dgvEtiquetas.Refresh();

            ListSortDirection ls = ListSortDirection.Ascending;
            if (this.dgvEtiquetas.SortOrder == SortOrder.Descending)
            {
                ls = ListSortDirection.Descending;
            }

            this.dgvEtiquetas.Sort(this.dgvEtiquetas.SortedColumn ?? this.dgvEtiquetas.Columns[0], ls);
        }

        private void AdicionarProduto()
        {
            try
            {
                if (this.ensProduto.EntidadeSelecionada!=null)
                {
                    ((ProdutoKClass)this.Entity).AdicionarProduto((ProdutoClass)this.ensProduto.EntidadeSelecionada);
                    this.initializeGridProdutos();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao adicionar o produto.\r\n" + e.Message, e);
            }
        }

        private void ExcluirProduto()
        {
            try
            {
                foreach (IWTDataGridViewRow row in this.dgvProdutos.SelectedRows)
                {
                    ((ProdutoKClass)this.Entity).RemoverProduto((ProdutoKProdutoClass)row.DataBoundItem);
                }
                this.initializeGridProdutos();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao remover o produto.\r\n" + e.Message, e);
            }
        }

        private void AdicionarEtiqueta()
        {
            try
            {
                if (this.nudQtdPorEtiqueta.Value > 0 )
                {
                    ((ProdutoKClass)this.Entity).AdicionarEtiqueta(Convert.ToDouble(this.nudQtdPorEtiqueta.Value));
                    this.initializeGridEtiquetas();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao adicionar a etiqueta.\r\n" + e.Message, e);
            }

        }

        private void ExcluirEtiqueta()
        {

            try
            {
                foreach (IWTDataGridViewRow row in this.dgvEtiquetas.SelectedRows)
                {
                    ((ProdutoKClass)this.Entity).RemoverEtiqueta((ProdutoKEtiquetaClass)row.DataBoundItem);
                }
                this.initializeGridEtiquetas();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao remover a etiqueta.\r\n" + e.Message, e);
            }
        }

        private void atualizaSugestoes()
        {
            long idProdutoK = this.Entity.ID;
            IWTPostgreNpgsqlCommand command = this.SingleConnection.CreateCommand();

            int mesesMedia = Int32.Parse(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_N_MESES_MEDIA));

            #region Médias

            DateTime dataFim = Configurations.DataIndependenteClass.GetData().Date;
            DateTime dataInicio = Configurations.DataIndependenteClass.GetData().Date.AddMonths(-1*mesesMedia);

            command.CommandText =
                "SELECT  " +
                "  SUM(order_item_etiqueta.oie_quantidade) as qtdTotal " +
                "FROM   " +
                "  order_item_etiqueta   " +
                "  INNER JOIN (" +
                "    SELECT pedido_item.pei_numero,pedido_item.pei_posicao, pedido_item.id_cliente,pedido_item.pei_data_entrada FROM  " +
                "       public.pedido_item WHERE pei_sub_linha = 0 " +
                " ) as tab ON " +
                "    (tab.pei_numero = public.order_item_etiqueta.oie_order_number) AND " +
                "    (tab.pei_posicao = public.order_item_etiqueta.oie_order_pos) AND " +
                "    (tab.id_cliente = public.order_item_etiqueta.id_cliente)  " +
                "  INNER JOIN public.produto_k ON produto_k.id_produto_k = order_item_etiqueta.id_produto_k " +
                "WHERE " +
                "  (pei_data_entrada BETWEEN '" + dataInicio.Date.ToString("yyyy-MM-dd") + "' AND '" + dataFim.Date.ToString("yyyy-MM-dd") + "' )  AND " +
                "  produto_k.id_produto_k = " + idProdutoK + " " +
                " GROUP BY " +
                "  public.produto_k.id_produto_k,   " +
                "  public.produto_k.prk_codigo, " +
                "  public.order_item_etiqueta.oie_dimensao ";


            double? tmp = command.ExecuteScalar() as double?;
            double mediaMensal = (tmp.HasValue ? tmp.Value : 0) / mesesMedia;


            double mediaDiaria = mediaMensal / 30;
            int diasVerde = Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_DIAS_VERDE));
            int diasAmarelo = Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_DIAS_AMARELO));
            int diasVermelho = Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_DIAS_VERMELHO));

            this.lblVerdeSugerido.Text = (mediaDiaria * diasVerde).ToString("F4", CultureInfo.CurrentCulture);
            this.lbAmareloSugerido.Text = (mediaDiaria * diasAmarelo).ToString("F4", CultureInfo.CurrentCulture);
            this.lblVermelhoSugerido.Text = (mediaDiaria * diasVermelho).ToString("F4", CultureInfo.CurrentCulture);

            #endregion

            /*
            if (this.Material != null)
            {
                this.Material.clearSugestaoKb();

                if (this.cmbUnidade.SelectedValue != null)
                {
                    this.Material.idUnidadeMedidaUso = Convert.ToInt32(this.cmbUnidade.SelectedValue);
                    this.Material.unidadeMedidaUso = this.cmbUnidade.SelectedRow[this.cmbUnidade.DisplayMember].ToString();
                }

                this.Material.estoqueVerde = Convert.ToDouble(this.nudVerde.Value);
                this.Material.estoqueAmarelo = Convert.ToDouble(this.nudAmarelo.Value);
                this.Material.estoqueVermelho = Convert.ToDouble(this.nudVermelho.Value);

                this.Material.unidadesUtilizacaoPorUnidadeCompra = Convert.ToDouble(this.nudConversaoUnidades.Value);

                if (this.cmbUnidadeCompra.Enabled)
                {
                    this.Material.idUnidadeMedidaCompra = Convert.ToInt32(this.cmbUnidadeCompra.SelectedValue);
                    this.Material.unidadeMedidaCompra = this.cmbUnidadeCompra.SelectedRow[this.cmbUnidadeCompra.DisplayMember].ToString();
                }
                else
                {
                    this.Material.idUnidadeMedidaCompra = null;
                    this.Material.unidadeMedidaCompra = "";
                }


                if (this.Material.sugestaoKB != null)
                {
                    this.lblVerdeSugerido.Text = Convert.ToInt32(this.Material.sugestaoKB.Verde).ToString("D") + " " + this.Material.sugestaoKB.Unidade;
                    this.lbAmareloSugerido.Text = Convert.ToInt32(this.Material.sugestaoKB.Amarelo).ToString("D") + " " + this.Material.sugestaoKB.Unidade;
                    this.lblVermelhoSugerido.Text = Convert.ToInt32(this.Material.sugestaoKB.Vermelho).ToString("D") + " " + this.Material.sugestaoKB.Unidade;

                    this.lblClassificacaoABC.Text = this.Material.sugestaoKB.ClassificacaoABC;

                    this.lblReverVerde.Text = this.Material.sugestaoKB.obsRevisarKBVerde;
                    this.lblReverAmarelo.Text = this.Material.sugestaoKB.obsRevisarKBAmarelo;
                    this.lblReverVermelho.Text = this.Material.sugestaoKB.obsRevisarKBVermelho;
              


                }*
            }*/
        }

        private void habilitarCopia()
        {
            this.Text = "COPIANDO Kanban de Manufaturados: " + KbManufaturado;
            this.btnSalvar.Text = "Salvar Cópia";

            foreach (Control c in this.Controls)
            {
                if (c is IWTBaseControl)
                {
                    ((IWTBaseControl)c).removeForceDisable();
                }
                else
                {
                    c.Enabled = true;
                }
            }
            this.btnSalvar.Visible = true;
            this.btnSalvar.Enabled = true;
            this.btnCancelar.Enabled = true;

            this.btnSalvarComo.Visible = false;

            this.txtCodigo.removeForceDisable();
            this.txtDimensao.removeForceDisable();

            this.rdAgrupador.removeForceDisable();
            this.rdKbManufaturado.removeForceDisable();

            this.rdAgrupador_CheckedChanged(null,null);


            this._salvarComo = true;
            this.DesabilitarAvisoAlteradoAoFechar = true;
        }

        private void SalvarComo()
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {

                command = this.SingleConnection.CreateCommand();
                command.Transaction = command.Connection.BeginTransaction();
                this.KbManufaturado.SalvarComo(ref command);

                command.Transaction.Commit();
                MessageBox.Show(this, "Cópia realizada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.ListForm.ForceInitializeDataGrid();
                this.Close();
            }
            catch (ExcecaoTratada e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                throw;
            }
            catch (Exception e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                throw new ExcecaoTratada("\r\n" + e.Message, e);
            }
        }

        protected override void btnSalvar_Click(object sender, EventArgs e)
        {
            if (this._salvarComo)
            {
                this.SalvarComo();
            }
            else
            {
                base.btnSalvar_Click(sender, e);
            }
        }

        #region Eventos
        protected override void OnShown(EventArgs e)
        {
            try
            {
                this.Loading = true;

                this.loadComboClassificacao();
                this.atualizaSugestoes();

                base.OnShown(e);

                if ((((ProdutoKClass) this.Entity).CollectionProdutoKProdutoClassProdutoK).Count > 1 ||
                    (((ProdutoKClass) this.Entity).CollectionProdutoKEtiquetaClassProdutoK).Count > 1)
                {
                    rdAgrupador.Checked = true;
                }
                else
                {
                    cmbProdutoSelecaoModoKanban();
                    nudQtdPorEtiquetaSetValorModoKanban();
                }
                this.configuraModoVisualizacao();

                if (this.Entity.ID == -1)
                {
                    ((ProdutoKClass) this.Entity).AdicionarEtiqueta(1);
                }

                this.initializeGridProdutos();
                this.initializeGridEtiquetas();

                

            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Loading = false;
            }

        }

        private void btnProdutoAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                this.AdicionarProduto();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }    

        private void btnProdutoRemover_Click(object sender, EventArgs e)
        {
            try
            {
                this.ExcluirProduto();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnEtiquetaAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                this.AdicionarEtiqueta();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEtiquetaRemover_Click(object sender, EventArgs e)
        {
            try
            {
                this.ExcluirEtiqueta();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nudVerde_ValueChanged(object sender, EventArgs e)
        {
            atualizaValorProduzir();
        }

        private void rdKbManufaturado_CheckedChanged(object sender, EventArgs e)
        {
            if (rdKbManufaturado.Checked)
            {
                if ((((ProdutoKClass) this.Entity).CollectionProdutoKProdutoClassProdutoK).Count > 1 && rdKbManufaturado.Checked)
                   
                {
                    MessageBox.Show(
                        "Não é permitido alterar o modo de visualização de agrupador para KB Manufaturado pois existe mais de 1 produto adicionado.",
                        "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rdAgrupador.Checked = true;
                    return;
                }

                if( (((ProdutoKClass)this.Entity).CollectionProdutoKEtiquetaClassProdutoK).Count > 1 && rdKbManufaturado.Checked)
                {
                    MessageBox.Show(
                        "Não é permitido alterar o modo de visualização de agrupador para KB Manufaturado pois existe mais de 1 etiqueta adicionada.",
                        "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rdAgrupador.Checked = true;
                    return;
                    
                }

                configuraModoVisualizacao();
            }
        }

        private void rdAgrupador_CheckedChanged(object sender, EventArgs e)
        {
            if (rdAgrupador.Checked)
            {
                configuraModoVisualizacao();
            }
        }

        private void nudQtdPorEtiqueta_ValueChanged(object sender, EventArgs e)
        {
            if (rdKbManufaturado.Checked && !loadingComboProduto)
            {
                if (((ProdutoKClass) this.Entity).CollectionProdutoKEtiquetaClassProdutoK.Count > 0)
                {
                    ((ProdutoKClass) this.Entity).RemoverEtiqueta(
                        ((ProdutoKClass) this.Entity).CollectionProdutoKEtiquetaClassProdutoK.ToArray()[0]);
                }
                ((ProdutoKClass) this.Entity).AdicionarEtiqueta(Convert.ToDouble(nudQtdPorEtiqueta.Value));
            }
        }

        private void ensProduto_EntityChange(object sender, EventArgs e)
        {
            try
            {
                if (rdKbManufaturado.Checked && !loadingComboProduto)
                {
                    if (ensProduto.EntidadeSelecionada != null)
                    {
                        if (((ProdutoKClass)this.Entity).CollectionProdutoKProdutoClassProdutoK.Count > 0)
                        {
                            ((ProdutoKClass)this.Entity).RemoverProduto(((ProdutoKClass)this.Entity).CollectionProdutoKProdutoClassProdutoK.ToArray()[0]);
                        }
                        ((ProdutoKClass)this.Entity).AdicionarProduto((ProdutoClass)ensProduto.EntidadeSelecionada);
                    }
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvarComo_Click(object sender, EventArgs e)
        {
            try
            {
                this.habilitarCopia();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion


    }

    

}
