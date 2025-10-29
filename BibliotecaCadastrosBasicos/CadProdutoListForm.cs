using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using BibliotecaCadastrosBasicos.EstruturaProduto;
using BibliotecaCadastrosBasicos.NovaEstruturaProduto;
using BibliotecaCadastrosBasicos.Relatórios;
using BibliotecaCalculoCusto;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Entidades;
using BibliotecaTributos;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Base;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTDotNetLib.TelaProgresso;
using IWTNF;
using IWTNF.Entidades.Entidades;
using IWTPostgreNpgsql;
using IWTTreeComponent;
using ProjectConstants;


namespace BibliotecaCadastrosBasicos
{
    public partial class CadProdutoListForm : IWTListForm
    {
        private TipoForm Tipo;
        private readonly bool _filtroSomenteVenda;
        private readonly bool _filtroSomenteComprados;
        private readonly bool _somenteAtivos;
        private readonly bool _somenteSemPreco;


        
        private ArredondamentoNF arrendodamentoNF = (ArredondamentoNF)Enum.ToObject(typeof(ArredondamentoNF), Constants.ArredondamentoNF);
        EmitenteClass emitenteCompleto;

        public CadProdutoListForm(TipoForm tipo, bool modoSelecao = false, string filtroSelecao = null, bool filtroSomenteVenda = false, bool filtroSomenteComprados = false, bool somenteAtivos = false, bool somenteSemPreco = false)
        {
            InitializeComponent();
            this.Tipo = tipo;
            base.FiltroSelecao = filtroSelecao;
            base.ModoSelecao = modoSelecao;
            _filtroSomenteVenda = filtroSomenteVenda;
            _filtroSomenteComprados = filtroSomenteComprados;
            _somenteAtivos = somenteAtivos;
            _somenteSemPreco = somenteSemPreco;


        


        }

        #region Funções List

        public override Type getTipoEntidade()
        {
            return typeof (BibliotecaEntidades.Entidades.ProdutoClass);
        }

        protected override void chamadaForm(AbstractEntity entidade)
        {

            try
            {
                CadProdutoForm form = new CadProdutoForm((ProdutoClass) entidade, this, this.Tipo);
                form.VerificaUtilizacao = this.Tipo != TipoForm.Gerencial;
                form.ShowDialog();
                this.ForceInitializeDataGrid();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public override IWTDataGridView getDataGrid()
        {
            return this.iwtDataGridView1;
        }

        public override AcsUsuarioClass getUsuarioAtual()
        {
            return LoginClass.UsuarioLogado.loggedUser;
        }

        public override List<SearchParameterClass> getParametrosBuscaIniciais()
        {
            List<SearchParameterClass> toRet = new List<SearchParameterClass>()
                               {
                                   new SearchParameterClass("Codigo", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String)
                               };

            if (this._filtroSomenteVenda)
            {
                toRet.Add(new SearchParameterClass("PermiteVenda", true));
            }

            if (this._filtroSomenteComprados)
            {
                toRet.Add(new SearchParameterClass("TipoAquisicao", BibliotecaEntidades.Base.TipoAquisicao.Comprado));
            }

            if (this._somenteAtivos)
            {
                toRet.Add(new SearchParameterClass("Ativo", true));
            }

            if (_somenteSemPreco)
            {
                toRet.Add(new SearchParameterClass("SemPreco", true));
            }


            return toRet;
        }

        #endregion

        private void defineTipoForm()
        {
            try
            {
                switch (Tipo)
                {
                    case TipoForm.Engenharia:
                        this.btnPCP.Enabled = false;
                        this.btnCusto.Enabled = true;
                        this.btnEditar.Enabled = true;
                        this.btnEstrutura.Enabled = true;
                        this.btnExcluir.Enabled = true;
                        this.btnNovo.Enabled = true;
                        this.btnRevisao.Enabled = true;
                        this.btnEtiqueta.Enabled = true;
                        break;

                    case TipoForm.PCP:
                        this.btnPCP.Enabled = true;
                        this.btnCusto.Enabled = false;
                        this.btnEditar.Enabled = true;
                        this.btnEstrutura.Enabled = true;
                        this.btnExcluir.Enabled = false;
                        this.btnNovo.Enabled = false;
                        this.btnRevisao.Enabled = false;
                        this.btnEtiqueta.Enabled = true;
                        break;
                    case TipoForm.Gerencial:
                        this.btnPCP.Enabled = true;
                        this.btnCusto.Enabled = true;
                        this.btnEditar.Enabled = true;
                        this.btnEstrutura.Enabled = true;
                        this.btnExcluir.Enabled = true;
                        this.btnNovo.Enabled = true;
                        this.btnRevisao.Enabled = true;
                        this.btnEtiqueta.Enabled = true;
                        break;

                    case TipoForm.Financeiro:
                        this.btnPCP.Enabled = false;
                        this.btnCusto.Enabled = false;
                        this.btnEditar.Enabled = true;
                        this.btnEstrutura.Enabled = false;
                        this.btnExcluir.Enabled = false;
                        this.btnNovo.Enabled = true;
                        this.btnRevisao.Enabled = false;
                        this.btnEtiqueta.Enabled = false;
                        break;
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao definir o tipo do formulário\r\n" + e.Message, e);
            }
        }

      

        private void Estrutura(bool edicao)
        {
            try
            {
                if (this.getDataGrid().SelectedRows.Count > 0)
                {
                    ProdutoClass prod = ((ProdutoClass) ((IWTDataGridViewRow)getDataGrid().SelectedRows[0]).DataBoundItem);

                    bool estruturaSomenteLeitura = !edicao;
                    if (this.SomenteLeitura)
                    {
                        estruturaSomenteLeitura = true;
                    }


                    NovaEstruturaProduto.CadProdutoEstruturaFormNew form = new CadProdutoEstruturaFormNew(prod, Tipo, estruturaSomenteLeitura);
                    form.ShowDialog();

                    

                    this.ForceInitializeDataGrid();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao editar a estrutura do item.\r\n" + e.Message);
            }
        }

        private void PCP()
        {
            try
            {
                if (this.getDataGrid().SelectedRows.Count > 0)
                {
                    ProdutoClass prod = ((ProdutoClass)((IWTDataGridViewRow)getDataGrid().SelectedRows[0]).DataBoundItem);

                    CadProdutoPCPForm form = new CadProdutoPCPForm(prod, this, (this.Tipo != TipoForm.PCP) && (this.Tipo != TipoForm.Gerencial));
                    form.ShowDialog();
                    this.ForceInitializeDataGrid();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao editar a estrutura do item.\r\n" + e.Message);
            }
        }

        private void Custo()
        {
            try
            {
                if (this.getDataGrid().SelectedRows.Count > 0)
                {

                    BibliotecaEntidades.Entidades.ProdutoClass prod = ((BibliotecaEntidades.Entidades.ProdutoClass) ((IWTDataGridViewRow)getDataGrid().SelectedRows[0]).DataBoundItem);
                    

                    CalculoCustoForm form = new CalculoCustoForm(
                        prod.ID,
                        prod.VersaoEstruturaAtual,
                        prod.Codigo,
                        prod.Descricao,
                        this.arrendodamentoNF,
                        this.SingleConnection);

                    form.ShowDialog();

                    this.ForceInitializeDataGrid();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao realizar a simulação de custo do item.\r\n" + e.Message);
            }
        }

        private void emRevisao()
        {

            try
            {
                if (this.getDataGrid().SelectedRows.Count > 0)
                {
                    BibliotecaEntidades.Entidades.ProdutoClass prod = ((BibliotecaEntidades.Entidades.ProdutoClass)((IWTDataGridViewRow)getDataGrid().SelectedRows[0]).DataBoundItem);


                    if (MessageBox.Show(this, "Essa operação irá " + (prod.EstruturaEmRevisao ? "retirar" : "colocar") + " a estrutura do produto em revisão. Deseja continuar?", "Revisão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                        DialogResult.Yes)
                    {


                        if (prod.EstruturaEmRevisao)
                        {
                            //Voltando da revisão

                            string justificativa;
                            JustificativaForm formJustificativa =
                                new JustificativaForm("Sr(a). " + this.getUsuarioAtual().Name + " (" + this.getUsuarioAtual().Login +
                                                       ") essa operação será registrada como uma revisão da estrutura do produto em seu nome. Você deseja prosseguir?");
                            formJustificativa.ShowDialog();


                            if (formJustificativa.Abortar)
                            {

                                this.ForceInitializeDataGrid();
                                return;
                            }
                            else
                            {
                                justificativa = formJustificativa.Justificativa;
                            }

                            string mensagem;
                            List<ProdutoEstruturaLockClass> locks = new List<ProdutoEstruturaLockClass>();
                            if (!NewEstruturaProdutoClass.LockItensRelacionados(prod, this.SingleConnection, out mensagem, ref locks))
                            {
                                throw new ExcecaoTratada("Não é possível retirar o item de revisão. " + mensagem);
                            }


                            IWTPostgreNpgsqlConnection runnerConn = new IWTPostgreNpgsqlConnection(this.SingleConnection.ConnectionString);
                            runnerConn.Open();
                            
                            LockKeepAliveRunner runner = new LockKeepAliveRunner(runnerConn, locks);
                            Thread tr = new Thread(runner.Start);
                            tr.Start();

                            prod.setAlterado(true, true);
                            prod.EstruturaEmRevisaoObservacao = "";
                            TelaProgressoRunner telaProgresso = new TelaProgressoRunner("Retirando item de revisão", 4, this);
                            NewEstruturaProdutoClass.SalvarEstrutura(prod, justificativa, ref telaProgresso, true);


                            runner.ToStop = true;
                            tr.Join();
                            runnerConn.Close();

                            NewEstruturaProdutoClass.Unlock(locks, SingleConnection);

                            prod = CadProdutoEstruturaFormNew.marretadaNova(prod, true, SingleConnection);

                            telaProgresso.Finished();
                        }
                        else
                        {
                            string mensagem;
                            List<ProdutoEstruturaLockClass> locks = new List<ProdutoEstruturaLockClass>();
                            if (!NewEstruturaProdutoClass.VerificaLockItensRelacionados(prod, SingleConnection, out mensagem, ref locks))
                            {
                                throw new ExcecaoTratada("Não é possível colocar o item em revisão. " + mensagem);
                            }


                            JustificativaForm formJustificativa = new JustificativaForm("Defina a observação para o item em revisão: ", "Observação da Revisão", false, false, true, false);
                            formJustificativa.ShowDialog();


                            if (formJustificativa.Abortar)
                            {

                                prod.EstruturaEmRevisaoObservacao = "";
                            }
                            else
                            {
                                prod.EstruturaEmRevisaoObservacao = formJustificativa.Justificativa;
                            }



                            prod.EstruturaEmRevisao = !prod.EstruturaEmRevisao;
                            prod.DesabilitarJustificativaRevisaoProduto = true;
                            prod.Save();
                            prod.DesabilitarJustificativaRevisaoProduto = false;
                        }



                        




                    }



                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                BufferAbstractEntity.limparBuffer();
                this.ForceInitializeDataGrid();
            }


        }


        private void EtiquetaCompraRepetitiva()
        {
            try
            {
                if (this.getDataGrid().SelectedRows.Count > 0)
                {
                    List<ProdutoClass> produtos = new List<ProdutoClass>();
                    foreach (IWTDataGridViewRow row in this.getDataGrid().SelectedRows)
                    {

                        produtos.Add((ProdutoClass) row.DataBoundItem);

                    }

                    EtiquetaCompraRepetitivaReportForm form = new EtiquetaCompraRepetitivaReportForm(
                        null,
                        null,
                        null,
                        produtos);

                    if (!form.Abort)
                    {
                        form.Show();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar as etiquetas de Kanban.\r\n" + e.Message, e);
            }
        }


        private void criarEditarKbMan()
        {
            try
            {
                if (this.getDataGrid().SelectedRows.Count == 1)
                {
                    ProdutoClass produto = (ProdutoClass) ((IWTDataGridViewRow) getDataGrid().SelectedRows[0]).DataBoundItem;
                    
                    
                    if (produto.TipoAquisicao != BibliotecaEntidades.Base.TipoAquisicao.Fabricado)
                    {
                        throw new Exception("O item não pode possuir Kanban de manufaturados pois está configurado como Comprado.");
                    }
                    ProdutoKProdutoClass produtoKProduto = new ProdutoKProdutoClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                    List<AbstractEntity> produtoKProdutos = produtoKProduto.Search(new List<SearchParameterClass>()
                                                                                       {
                                                                                           new SearchParameterClass("Produto",
                                                                                                                    produto,
                                                                                                                    SearchOperacao.FiltroNormal,
                                                                                                                    SearchOrdenacao.Asc,
                                                                                                                    TipoOrdenacao.String)
                                                                                       });
                    if (produtoKProdutos.Count > 1)
                    {
                        MessageBox.Show(
                            "Não é possível criar/editar KB de manufaturados pois o produto possui mais de um agrupador.",
                            "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (produtoKProdutos.Count == 1)
                    {
                        ProdutoKProdutoClass prod = produtoKProdutos[0] as ProdutoKProdutoClass;
                        CadAgrupadorItemSemelhanteForm frm = new CadAgrupadorItemSemelhanteForm(prod.ProdutoK);
                        frm.ModoMasterDetail = false;
                        frm.ShowDialog();
                    }
                    if (produtoKProdutos.Count == 0)
                    {
                        ProdutoKClass produtok = new ProdutoKClass(this.getUsuarioAtual(),this.SingleConnection);
                        produtok.Codigo = produto.Codigo + "-KB";
                        produtok.AdicionarProduto(produto);
                        produtok.Ativo = true;
                        produtok.Dimensao = "0";
                        CadAgrupadorItemSemelhanteForm frm = new CadAgrupadorItemSemelhanteForm(produtok);
                        frm.ModoMasterDetail = false;
                        frm.ShowDialog();
                    }
                }
                else if (this.getDataGrid().SelectedRows.Count < 1)
                {
                    MessageBox.Show("Selecione um produto para criar/editar KB de manufaturados.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (this.getDataGrid().SelectedRows.Count > 1)
                {
                    MessageBox.Show("Selecione somente um produto para criar/editar KB de manufaturados.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception a)
            {
                throw new Exception("Erro na chamada do cadastro de KB de ítens manufaturados.\r\n" + a.Message, a);
            }
        }

        private void HistoricoCompra()
        {
            try
            {
                if (this.getDataGrid().SelectedRows.Count <= 0)
                {
                    throw new ExcecaoTratada("Selecione ao menos um produto antes de abrir o histórico de compra");

                }

                List<AbstractEntity> produtos = new List<AbstractEntity>();
                foreach (IWTDataGridViewRow row in this.getDataGrid().SelectedRows)
                {
                    if (((ProdutoClass)row.DataBoundItem).TipoAquisicao!=BibliotecaEntidades.Base.TipoAquisicao.Comprado)
                    {
                        continue;
                    }

                    produtos.Add((ProdutoClass)row.DataBoundItem);
                }

                if (produtos.Count==0)
                {
                    throw new ExcecaoTratada("Não foi selecionado nenhum produto comprado para a geração do histórico");
                }

                EvolucaoPrecoCompraReportForm form = new EvolucaoPrecoCompraReportForm(produtos, EvolucaoPrecoCompraReportClass.SelecaoEntidadeRelatorio.Produto);
                form.Show(this);
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("\r\n" + e.Message, e);
            }
        }


        #region Eventos

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            defineTipoForm();

            if (IWTLicensing.ControleLicenciamentoClass.Licenca != null && IWTLicensing.ControleLicenciamentoClass.Licenca.TipoLicenca != "COMPLETO")
            {
                this.btnCriarEditarKbMan.Visible = false;
            }


            if (this._somenteAtivos)
            {
                this.grbFiltroStatus.Visible = false;
            }
            this.rdbAtivo.Checked = true;

            if (!IWTConfiguration.Conf.getBoolConf(Constants.TRABALHAR_COM_BLOQUEIO_PRODUTO_POR_PRECO_VENCIDO))
            {
                this.getDataGrid().Columns.Remove(BloqueioPrecoVencido);
                this.btnBloqueioVencido.Visible = false;
                this.btnDesbloqueioVencido.Visible = false;
            }
            else if (!LoginClass.UsuarioLogado.HasAccess("MODULO_GERENCIAL_CADASTROS_OPERACIONAIS_PRODUTOS_PERMISSAO_BLOQUEIO_DESBLOQUEIO_PRODUTO_POR_PRECO_VENCIDO", AcsTipoAcesso.Escrita))
            {
                this.btnBloqueioVencido.Visible = false;
                this.btnDesbloqueioVencido.Visible = false;
            }
        }

        private void CadProdutoListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
        
        private void btnEstrutura_Click(object sender, EventArgs e)
        {
            try
            {
                this.Estrutura(true);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPCP_Click(object sender, EventArgs e)
        {
            try
            {
                this.PCP();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCusto_Click(object sender, EventArgs e)
        {
            try
            {
                this.Custo();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRevisao_Click(object sender, EventArgs e)
        {
            try
            {
                this.emRevisao();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnEtiqueta_Click(object sender, EventArgs e)
        {
            try
            {
                this.EtiquetaCompraRepetitiva();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnCriarEditarKbMan_Click(object sender, EventArgs e)
        {
            try
            {
                criarEditarKbMan();

            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        
        private void btnHistoricoCompra_Click(object sender, EventArgs e)
        {
            try
            {
                this.HistoricoCompra();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnVisualizarEstrutura_Click(object sender, EventArgs e)
        {
            try
            {
                this.Estrutura(false);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnBloqueioVencido_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.getDataGrid().SelectedRows.Count <= 0)
                {
                    throw new ExcecaoTratada("Selecione ao menos um produto antes de realizar a operação de bloqueio por preço vencido.");

                }

                List<AbstractEntity> produtos = new List<AbstractEntity>();
                foreach (IWTDataGridViewRow row in this.getDataGrid().SelectedRows)
                {
                    if (((ProdutoClass)row.DataBoundItem).BloqueioPrecoVencido)
                    {
                        continue;
                    }

                    produtos.Add((ProdutoClass)row.DataBoundItem);
                }

                if (produtos.Count == 0)
                {
                    throw new ExcecaoTratada("Não foi selecionado nenhum produto desbloqueado para bloqueio por preço vencido");
                }

                foreach (ProdutoClass produto in produtos)
                {
                    produto.BloquearPorPrecoVencido();
                }
                this.ForceInitializeDataGrid();
            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDesbloqueioVencido_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.getDataGrid().SelectedRows.Count <= 0)
                {
                    throw new ExcecaoTratada("Selecione ao menos um produto antes de realizar a operação de desbloqueio por preço vencido.");

                }

                List<AbstractEntity> produtos = new List<AbstractEntity>();
                foreach (IWTDataGridViewRow row in this.getDataGrid().SelectedRows)
                {
                    if (!((ProdutoClass)row.DataBoundItem).BloqueioPrecoVencido)
                    {
                        continue;
                    }

                    produtos.Add((ProdutoClass)row.DataBoundItem);
                }

                if (produtos.Count == 0)
                {
                    throw new ExcecaoTratada("Não foi selecionado nenhum produto bloqueado para desbloqueio por preço vencido");
                }

                foreach (ProdutoClass produto in produtos)
                {
                    produto.DesbloquearPorPrecoVencido();
                }
                this.ForceInitializeDataGrid();
            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }
}
