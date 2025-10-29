#region Referencias

using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BibiliotecaGerenciamentoKB;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using ProjectConstants;


#endregion

namespace BibliotecaCadastrosBasicos
{
    public partial class CadProdutoPCPForm : IWTForm
    {
        private ProdutoClass Produto
        {
            get { return (ProdutoClass) this.Entity; }
        }
        private double categoriaAAcimaDe = double.Parse(Configurations.IWTConfiguration.Conf.getConf(Constants.ESTOQUE_CLASSIFICACAO_A));
        private double categoriaBAcimaDe = double.Parse(Configurations.IWTConfiguration.Conf.getConf(Constants.ESTOQUE_CLASSIFICACAO_B));
        private int leadtimeCompras = int.Parse(Configurations.IWTConfiguration.Conf.getConf(Constants.DIAS_PROGRAMACAO_COMPRAS));
        private int leadtimePCP = int.Parse(Configurations.IWTConfiguration.Conf.getConf(Constants.DIAS_PROGRAMACAO_PCP));
        private double sugeridoAcimaCompras = double.Parse(Configurations.IWTConfiguration.Conf.getConf(Constants.SUGESTAO_ACIMA_CONFIGURADO));
        private double disparoSolicitacaoAuto = double.Parse(Configurations.IWTConfiguration.Conf.getConf(Constants.DISPARO_SOLICACAO_COMPRAS));
        private int diasVerde = int.Parse(Configurations.IWTConfiguration.Conf.getConf(Constants.ESTOQUE_DIAS_VERDE));
        private int diasAmarelo = int.Parse(Configurations.IWTConfiguration.Conf.getConf(Constants.ESTOQUE_DIAS_AMARELO));
        private int diasVermelho = int.Parse(Configurations.IWTConfiguration.Conf.getConf(Constants.ESTOQUE_DIAS_VERMELHO));
        private int mesesMedia = int.Parse(Configurations.IWTConfiguration.Conf.getConf(Constants.ESTOQUE_N_MESES_MEDIA));
        private double margemAvisoKB = double.Parse(Configurations.IWTConfiguration.Conf.getConf(Constants.ESTOQUE_MARGEM_REVISAO_KB));


        public CadProdutoPCPForm(AbstractEntity entity, bool somenteLeitura = false) : base(entity, typeof(ProdutoClass), LoginClass.UsuarioLogado.loggedUser, null)
        {
            this.SomenteLeitura = somenteLeitura;
            InitializeComponent();
        }

        public CadProdutoPCPForm(AbstractEntity entity, IWTListForm listForm, bool somenteLeitura = false)
            : base(entity, listForm, listForm.SingleConnection)
        {
            this.SomenteLeitura = somenteLeitura;
            InitializeComponent();
        }



        protected override void OnShown(EventArgs e)
        {
            ensFornecedor.FormSelecao = new CadFornecedorListForm(TipoModulo.Tipo);
          
            this.loadComboUnidadeCompra();
            this.loadComboCompradores();
            this.loadComboUnidadeCompraFornecedor();

            if (!this.SomenteLeitura)
            {
                if (!IWTConfiguration.Conf.getBoolConf(Constants.PLANO_CORTE_HABILITADO))
                {
                    this.chkEmitePlanoCorte.Checked = false;
                    this.chkEmitePlanoCorte.Enabled = false;
                }
                else
                {
                    this.chkEmitePlanoCorte.Enabled = true;
                }
            }


            if (this.Produto != null)
            {
                if (Produto.TipoAquisicao == TipoAquisicao.Comprado && Produto.EmiteOp)
                {
                    MessageBox.Show(this,  "O produto que está sendo editado está configurado como Comprado e ao mesmo tempo emite OP, essa configuração não é mais suportada pelo EASI. Você deve ajustar o cadastro e se for necessária a geração da OP ela deve estar selecionada em um item acima na estrutura de produtos.", "Inconsistência de cadastro encontrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            base.OnShown(e);

            if (Entity != null)
            {
                this.loadGridFornecedor();
                this.exibeParametros();
                this.atualizaTextoConversaoUnidades();
                this.atualizaSugestoes();
            }

            if (IWTLicensing.ControleLicenciamentoClass.Licenca != null && IWTLicensing.ControleLicenciamentoClass.Licenca.TipoLicenca != "COMPLETO")
            {
                this.chkEmiteOp.Checked = false;
                this.chkEmiteOp.Visible = false;

                this.chkEmitePlanoCorte.Checked = false;
                this.chkEmitePlanoCorte.Visible = false;

                this.chkImprimirEstrutura.Checked = false;
                this.chkImprimirEstrutura.Visible = false;

                this.chkImprimirRelacionadas.Checked = false;
                this.chkImprimirRelacionadas.Visible = false;

                this.chkRastreamentoMP.Checked = false;
                this.chkRastreamentoMP.Visible = false;
            }
        }


        private void loadComboUnidadeCompra()
        {

            try
            {
                UnidadeMedidaClass search = new UnidadeMedidaClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<UnidadeMedidaClass> entidades =
                    search.Search(new List<SearchParameterClass>()
                                      {
                                          new SearchParameterClass("unm_abreviada", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica)

                                      }).
                        ConvertAll(a => (UnidadeMedidaClass) a);


                this.cmbUnidadeCompra.DataSource = entidades;
                this.cmbUnidadeCompra.DisplayMember = "Abreviada";
                this.cmbUnidadeCompra.ValueMember = "ID";
                this.cmbUnidadeCompra.autoSize = true;
                this.cmbUnidadeCompra.Table = entidades;
                this.cmbUnidadeCompra.ColumnsToDisplay = new[] {"Abreviada", "NomeUnidade", "Obs"};
                this.cmbUnidadeCompra.HeadersToDisplay = new string[] {"Unidade", "Nome", "Obs."};

            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao carregar os dados para seleção da unidade de compra.\r\n" + e.Message);
            }
        }

        private void loadComboCompradores()
        {


            try
            {

                CompradorClass search = new CompradorClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<CompradorClass> entidades =
                    search.Search(new List<SearchParameterClass>()
                                      {
                                          new SearchParameterClass("com_apelido", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica),
                                          new SearchParameterClass("com_nome", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica)

                                      }).
                        ConvertAll(a => (CompradorClass)a);


                this.cmbComprador.DataSource = entidades;
                this.cmbComprador.DisplayMember = "Apelido";
                this.cmbComprador.ValueMember = "ID";
                this.cmbComprador.autoSize = true;
                this.cmbComprador.Table = entidades;
                this.cmbComprador.ColumnsToDisplay = new[] { "Apelido", "Nome", "AcsUsuario" };
                this.cmbComprador.HeadersToDisplay = new[] { "Apelido", "Nome", "Usuário" };

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção do comprador.\r\n" + e.Message);
            }
        }

        private void loadComboUnidadeCompraFornecedor()
        {

            try
            {
                BibliotecaEntidades.Entidades.UnidadeMedidaClass search = new BibliotecaEntidades.Entidades.UnidadeMedidaClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<BibliotecaEntidades.Entidades.UnidadeMedidaClass> resultados =
                    search.Search(new List<SearchParameterClass>() { new SearchParameterClass("Abreviada", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String) }).ConvertAll(a => (BibliotecaEntidades.Entidades.UnidadeMedidaClass)a);


                this.cmbFornecedorUnidadeCompra.DataSource = resultados;
                this.cmbFornecedorUnidadeCompra.DisplayMember = "Abreviada";
                this.cmbFornecedorUnidadeCompra.ValueMember = "ID";
                this.cmbFornecedorUnidadeCompra.autoSize = true;
                this.cmbFornecedorUnidadeCompra.Table = resultados;
                this.cmbFornecedorUnidadeCompra.ColumnsToDisplay = new[] { "Abreviada", "NomeUnidade", "Obs" };
                this.cmbFornecedorUnidadeCompra.HeadersToDisplay = new[] { "Abreviada", "Nome", "Obs" };


            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção.\r\n" + e.Message);
            }
        }

        protected override void Salvar(IWTPostgreNpgsqlCommand command = null)
        {
            if (this.cmbComprador.Enabled && this.cmbComprador.SelectedValue == null)
            {
                throw new Exception("Selecione um comprador ou desative o campo.");
            }

            if (command == null)
            {
                command = this.SingleConnection.CreateCommand();
            }
            this.Produto.SavePCP(ref command);

            this.Close();
        }

     

        private void loadGridFornecedor()
        {

            try
            {
                this.dataGridView1.AutoGenerateColumns = false;
                this.dataGridView1.DataSource = null;
                this.dataGridView1.DataSource = new AdvancedList<ProdutoFornecedorClass>(this.Produto.CollectionProdutoFornecedorClassProduto.Where(a => a.Ativo));
            }
            catch (ExcecaoTratada e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao preencher o grid de fornecedores\r\n" + e.Message, e);
            }

         

        }

        private void aquisicaoChanged()
        {
            if (rdbComprado.Checked)
            {
                (tabPage2 as Control).Enabled = true;
                this.grbCompras.Enabled = true;

                chkEmiteOp.Checked = false;
                chkEmiteOp.forceDisable();
                chkEmitePlanoCorte.forceDisable();
                chkImprimirEstrutura.forceDisable();
                chkImprimirRelacionadas.forceDisable();
                chkRastreamentoMP.forceDisable();
                
            }
            else
            {
                (tabPage2 as Control).Enabled = false;
                this.grbCompras.Enabled = false;
                chkEmiteOp.removeForceDisable();
                chkEmitePlanoCorte.removeForceDisable();
                chkImprimirEstrutura.removeForceDisable();
                chkImprimirRelacionadas.removeForceDisable();
                chkRastreamentoMP.removeForceDisable();
            }
        }

        private void atualizaTextoConversaoUnidades()
        {
            try
            {



                if (this.cmbUnidadeCompra.SelectedItem != null)
                {
                    this.lblUnidades.Text = " 1 " + this.cmbUnidadeCompra.SelectedItem + " => " + this.nudConversaoUnidades.Value.ToString("F4") + " " + this.Produto.UnidadeMedida;
                }


            }
            catch (Exception e)
            {
                throw new Exception("Erro ao atualizar conversão de unidades de medida.\r\n" + e.Message, e);
            }
        }

        private void atualizaSugestoes()
        {

            if (this.Entity != null)
            {


                Produto.clearSugestaoKb();

                if (Produto.sugestaoKB != null)
                {
                    this.lblVerdeSugerido.Text = Convert.ToInt32(Produto.sugestaoKB.Verde).ToString("D") + " " + Produto.sugestaoKB.Unidade;
                    this.lbAmareloSugerido.Text = Convert.ToInt32(Produto.sugestaoKB.Amarelo).ToString("D") + " " + Produto.sugestaoKB.Unidade;
                    this.lblVermelhoSugerido.Text = Convert.ToInt32(Produto.sugestaoKB.Vermelho).ToString("D") + " " + Produto.sugestaoKB.Unidade;

                    this.lblClassificacaoABC.Text = Produto.sugestaoKB.ClassificacaoABC;

                    this.lblReverVerde.Text = Produto.sugestaoKB.obsRevisarKBVerde;
                    this.lblReverAmarelo.Text = Produto.sugestaoKB.obsRevisarKBAmarelo;
                    this.lblReverVermelho.Text = Produto.sugestaoKB.obsRevisarKBVermelho;


                }

                if (Produto.TipoAquisicao == TipoAquisicao.Comprado)
                {
                    this.lblSugestaoLeadTime.Text = "Leadtime Aquisição Calculado: " + Produto.getSugestaoLeadtime() + " dias";
                }
                else
                {
                    this.lblSugestaoLeadTime.Text = "";
                }
            }
        }

        private void exibeParametros()
        {
            try
            {

                this.lblFaixaA.Text = "A: > R$ " + this.categoriaAAcimaDe.ToString("F2", CultureInfo.CurrentCulture);
                this.lblFaixaB.Text = "B: > R$ " + this.categoriaBAcimaDe.ToString("F2", CultureInfo.CurrentCulture);
                this.lblFaixaC.Text = "C: < R$ " + this.categoriaBAcimaDe.ToString("F2", CultureInfo.CurrentCulture);
                this.lblLeadtimeCompras.Text = "Leadtime Compras: " + this.leadtimeCompras.ToString() + " dias";
                this.lblLeadtimePCP.Text = "Leadtime PCP: " + this.leadtimePCP.ToString() + " dias";
                this.lblSugeridoAcimaCompras.Text = this.sugeridoAcimaCompras.ToString("F2", CultureInfo.CurrentCulture) + " %";
                this.lblDisparo.Text = this.disparoSolicitacaoAuto.ToString("F2", CultureInfo.CurrentCulture) + " %";
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao exibir os parametros.\r\n" + e.Message, e);
            }
        }

        #region Funções Grid Fornecedores
        private void RemoverFornecedor()
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {

                }

                
                foreach (IWTDataGridViewRow row in this.dataGridView1.SelectedRows)
                {
                    ProdutoFornecedorClass pf = (ProdutoFornecedorClass)row.DataBoundItem;
                    Produto.removerFornecedorProduto(pf);
                }

                this.loadGridFornecedor();
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao remover o(s) fornecedor(es) selecionado(s).\r\n" + e.Message, e);
            }
        }

        private void AdicionarFornecedor()
        {
            try
            {
                if (this.ensFornecedor.EntidadeSelecionada == null)
                {
                    throw new Exception("Selecione um fornecedor para adicionar ou atualizar.");
                }

                UnidadeMedidaClass unidadeCompra = null;
                double? qtdUnidadeUso = null;
                double? loteMinimo = null;
                double? lotePadrao = null;

                if (cmbFornecedorUnidadeCompra.Enabled)
                {
                    if (cmbFornecedorUnidadeCompra.SelectedItem == null)
                    {
                        throw new Exception("Selecione uma unidade de compra ou desabilite a opção.");
                    }
                    unidadeCompra = (UnidadeMedidaClass)this.cmbFornecedorUnidadeCompra.SelectedItem;
                    qtdUnidadeUso = (double)this.nudFornecedorUnidadesPorUnidadeCompra.Value;
                    loteMinimo = (double)this.nudFornecedorLoteMinimo.Value;
                    lotePadrao = (double)this.nudFornecedorLotePadrao.Value;


                }


                this.Produto.adicionarFornecedor((FornecedorClass) this.ensFornecedor.EntidadeSelecionada,
                                                                  (double)this.nudUltimoPreco.Value,
                                                                  (double)this.nudImcsIncluso.Value, (double)this.nudIPINaoIncluso.Value,
                                                                  unidadeCompra, chkFornecedorPreferencial.Checked, qtdUnidadeUso,loteMinimo, lotePadrao);
                this.loadGridFornecedor();
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao adicionar ou atualizar o fornecedor.\r\n" + e.Message, e);
            }
        }

        private void SelecionarFornecedor()
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    ProdutoFornecedorClass produtoFornecedor = (ProdutoFornecedorClass)((IWTDataGridViewRow)dataGridView1.SelectedRows[0]).DataBoundItem;



                    this.ensFornecedor.EntidadeSelecionada = produtoFornecedor.Fornecedor;



                    this.nudUltimoPreco.Value = (decimal)produtoFornecedor.UltimoPreco;
                    this.nudImcsIncluso.Value = (decimal)produtoFornecedor.Icms;
                    this.nudIPINaoIncluso.Value = (decimal)produtoFornecedor.Ipi;
                    chkFornecedorPreferencial.Checked = produtoFornecedor.Preferencial;

                    if (produtoFornecedor.UnidadeMedidaCompra != null)
                    {
                        this.chkUnidadeCompraFornecedor.Checked = true;
                        this.cmbFornecedorUnidadeCompra.SelectedItem = produtoFornecedor.UnidadeMedidaCompra;
                        if (produtoFornecedor.LotePadrao.HasValue)
                            this.nudFornecedorLotePadrao.Value = (decimal)produtoFornecedor.LotePadrao;
                        if (produtoFornecedor.LoteMinimo.HasValue)
                            this.nudFornecedorLoteMinimo.Value = (decimal)produtoFornecedor.LoteMinimo;
                        if (produtoFornecedor.UnidadesPorUnCompra.HasValue)
                            this.nudFornecedorUnidadesPorUnidadeCompra.Value = (decimal)produtoFornecedor.UnidadesPorUnCompra;
                    }
                    else
                    {
                        this.chkUnidadeCompraFornecedor.Checked = false;
                    }
                }
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao carregar os dados da linha selecionada.\r\n" + e.Message, e);

            }
        }

  
        private void atualizaTextoUnidadeFornecedor()
        {
            try
            {
                if (cmbFornecedorUnidadeCompra.Enabled)
                {
                    if (this.cmbFornecedorUnidadeCompra.SelectedItem != null)
                    {
                        this.lblFornecedorUnidadeCompra.Text = ((UnidadeMedidaClass)cmbFornecedorUnidadeCompra.SelectedItem).Abreviada;
                    }
                }

                else
                {
                    if (this.cmbFornecedorUnidadeCompra.SelectedItem != null)
                    {
                        this.lblFornecedorUnidadeCompra.Text =
                            ((UnidadeMedidaClass)cmbFornecedorUnidadeCompra.SelectedItem).Abreviada;
                    }
                }

            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao atualizar conversão de unidades de medida.\r\n" + e.Message, e);
            }
        }
        #endregion

              
        #region Eventos

        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.AdicionarFornecedor();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                this.RemoverFornecedor();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbComprado_CheckedChanged(object sender, EventArgs e)
        {
            this.aquisicaoChanged();
        }

        private void rdbFabricado_CheckedChanged(object sender, EventArgs e)
        {
            this.aquisicaoChanged();
        }

        private void rdbMRP_CheckedChanged(object sender, EventArgs e)
        {
            this.nudLotePadrao.Enabled = rdbProducaoRepetitiva.Checked || rdbMRP.Checked;
            this.nudLoteMinimo.Enabled = rdbProducaoRepetitiva.Checked || rdbMRP.Checked;
            this.nudAmarelo.Enabled = rdbProducaoRepetitiva.Checked;
            this.nudVerde.Enabled = rdbProducaoRepetitiva.Checked;
            this.nudVermelho.Enabled = rdbProducaoRepetitiva.Checked;
            this.lblReverVerde.Visible = rdbProducaoRepetitiva.Checked;
            this.lblReverAmarelo.Visible = rdbProducaoRepetitiva.Checked;
            this.lblReverVermelho.Visible = rdbProducaoRepetitiva.Checked;
        }

        private void rdbProducaoRepetitiva_CheckedChanged(object sender, EventArgs e)
        {
            this.nudLotePadrao.Enabled = rdbProducaoRepetitiva.Checked || rdbMRP.Checked;
            this.nudLoteMinimo.Enabled = rdbProducaoRepetitiva.Checked || rdbMRP.Checked;
            this.nudAmarelo.Enabled = rdbProducaoRepetitiva.Checked;
            this.nudVerde.Enabled = rdbProducaoRepetitiva.Checked;
            this.nudVermelho.Enabled = rdbProducaoRepetitiva.Checked;
            this.lblReverVerde.Visible = rdbProducaoRepetitiva.Checked;
            this.lblReverAmarelo.Visible = rdbProducaoRepetitiva.Checked;
            this.lblReverVermelho.Visible = rdbProducaoRepetitiva.Checked;
        }

        private void rdbNaoAplicavel_CheckedChanged(object sender, EventArgs e)
        {
            this.nudLotePadrao.Enabled = rdbProducaoRepetitiva.Checked || rdbMRP.Checked;
            this.nudLoteMinimo.Enabled = rdbProducaoRepetitiva.Checked || rdbMRP.Checked;
            this.nudAmarelo.Enabled = rdbProducaoRepetitiva.Checked;
            this.nudVerde.Enabled = rdbProducaoRepetitiva.Checked;
            this.nudVermelho.Enabled = rdbProducaoRepetitiva.Checked;
            this.lblReverVerde.Visible = rdbProducaoRepetitiva.Checked;
            this.lblReverAmarelo.Visible = rdbProducaoRepetitiva.Checked;
            this.lblReverVermelho.Visible = rdbProducaoRepetitiva.Checked;
        }


  
        private void cmbUnidadeCompra_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.atualizaTextoConversaoUnidades();
                this.atualizaSugestoes();
                this.atualizaTextoUnidadeFornecedor();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkUnidadeCompra_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.chkUnidadeCompra.Checked)
            {
                this.nudConversaoUnidades.Enabled = false;
                this.nudConversaoUnidades.Value = 1;
                this.cmbUnidadeCompra.Enabled = false;
            }
            else
            {
                this.nudConversaoUnidades.Enabled = true;
                this.cmbUnidadeCompra.Enabled = true;
            }
            this.atualizaSugestoes();
            this.atualizaTextoUnidadeFornecedor();
        }

        private void nudConversaoUnidades_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.atualizaTextoConversaoUnidades();
                this.atualizaSugestoes();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nudVerde_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.atualizaSugestoes();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nudAmarelo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.atualizaSugestoes();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nudVermelho_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.atualizaSugestoes();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkConfiguracoes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                ConfigCompraVisualizacaoForm form = new ConfigCompraVisualizacaoForm(
                    this.diasVerde,
                    this.diasAmarelo,
                    this.diasVermelho,
                    this.mesesMedia,
                    this.margemAvisoKB);
                form.Show();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void chkComprador_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbComprador.Enabled = this.chkComprador.Checked;
        }



        private void chkUnidadeCompraFornecedor_CheckedChanged(object sender, EventArgs e)
        {
            this.grbUnidadeCompraFornecedor.Enabled = this.chkUnidadeCompraFornecedor.Checked;
        }

        private void chkMargemRecebimento_CheckedChanged(object sender, EventArgs e)
        {
            this.nudMargemRecebimento.Enabled = this.chkMargemRecebimento.Checked;
        }


  
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {

                this.SelecionarFornecedor();

            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


    }
}
