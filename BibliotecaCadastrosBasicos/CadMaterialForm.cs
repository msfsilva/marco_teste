#region Referencias

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BibiliotecaGerenciamentoKB;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using ProjectConstants;

#endregion

namespace BibliotecaCadastrosBasicos
{

    public partial class CadMaterialForm : IWTForm
    {
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
        private bool _salvarComo= false;


        public CadMaterialForm(MaterialClass entidade, CadMaterialListForm listForm)
            : base(entidade, listForm, listForm.SingleConnection)
        {
            
            InitializeComponent();
            loadComboUnidadeMedida();
            loadComboFamiliaMaterial();
            loadComboAcabamento();
            loadComboUnidadeMedidaCompra();
            loadComboComprador();
            loadComboFornecedorUnidadeMedidaCompra();
        }

        public CadMaterialForm(MaterialClass entidade)
            : base(entidade, typeof(MaterialClass), LoginClass.UsuarioLogado.loggedUser,null)
        {
         
            InitializeComponent();

            loadComboUnidadeMedida();
            loadComboFamiliaMaterial();
            loadComboAcabamento();
            loadComboUnidadeMedidaCompra();
            loadComboComprador();
            loadComboFornecedorUnidadeMedidaCompra();
        }

        #region Carregamento Combos

        private void loadComboUnidadeMedida()
        {
            try
            {
                BibliotecaEntidades.Entidades.UnidadeMedidaClass search = new BibliotecaEntidades.Entidades.UnidadeMedidaClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<BibliotecaEntidades.Entidades.UnidadeMedidaClass> resultados =
                    search.Search(new List<SearchParameterClass>() { new SearchParameterClass("Abreviada", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String) }).ConvertAll(a => (BibliotecaEntidades.Entidades.UnidadeMedidaClass)a);


                this.UnidadeMedida.DataSource = resultados;
                this.UnidadeMedida.DisplayMember = "Abreviada";
                this.UnidadeMedida.ValueMember = "ID";
                this.UnidadeMedida.autoSize = true;
                this.UnidadeMedida.Table = resultados;
                this.UnidadeMedida.ColumnsToDisplay = new[] { "Abreviada","NomeUnidade","Obs" };
                this.UnidadeMedida.HeadersToDisplay = new[] { "Abreviada", "Nome", "Obs" };


            }
            catch (ExcecaoTratada)
            {
                throw ;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção.\r\n" + e.Message);
            }
        }
        private void loadComboFamiliaMaterial()
        {
            try
            {
                BibliotecaEntidades.Entidades.FamiliaMaterialClass search = new BibliotecaEntidades.Entidades.FamiliaMaterialClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<BibliotecaEntidades.Entidades.FamiliaMaterialClass> resultados =
                    search.Search(new List<SearchParameterClass>() { new SearchParameterClass("Codigo", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String) }).ConvertAll(a => (BibliotecaEntidades.Entidades.FamiliaMaterialClass)a);


                this.FamiliaMaterial.DataSource = resultados;
                this.FamiliaMaterial.DisplayMember = "Codigo";
                this.FamiliaMaterial.ValueMember = "ID";
                this.FamiliaMaterial.autoSize = true;
                this.FamiliaMaterial.Table = resultados;
                this.FamiliaMaterial.ColumnsToDisplay = new[] { "Codigo", "Descricao" };
                this.FamiliaMaterial.HeadersToDisplay = new[] { "Código", "Descrição" };

                
            }
            catch (ExcecaoTratada)
            {
                throw ;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção.\r\n" + e.Message);
            }
        }
        private void loadComboAcabamento()
        {
            try
            {
                BibliotecaEntidades.Entidades.AcabamentoClass search = new BibliotecaEntidades.Entidades.AcabamentoClass(LoginClass.UsuarioLogado.loggedUser,this.SingleConnection);
                List<BibliotecaEntidades.Entidades.AcabamentoClass> resultados =
                    search.Search(new List<SearchParameterClass>() { new SearchParameterClass("Identificacao", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String) }).ConvertAll(a => (BibliotecaEntidades.Entidades.AcabamentoClass)a);


                this.Acabamento.DataSource = resultados;
                this.Acabamento.DisplayMember = "Identificacao";
                this.Acabamento.ValueMember = "ID";
                this.Acabamento.autoSize = true;
                this.Acabamento.Table = resultados;
                this.Acabamento.ColumnsToDisplay = new[] { "Identificacao", "DescricaoTecnica" };
                this.Acabamento.HeadersToDisplay = new[] { "Código", "Descrição" };


            }
            catch (ExcecaoTratada)
            {
                throw ;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção.\r\n" + e.Message);
            }
        }
        private void loadComboUnidadeMedidaCompra()
        {
            try
            {
                BibliotecaEntidades.Entidades.UnidadeMedidaClass search = new BibliotecaEntidades.Entidades.UnidadeMedidaClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<BibliotecaEntidades.Entidades.UnidadeMedidaClass> resultados =
                    search.Search(new List<SearchParameterClass>() { new SearchParameterClass("Abreviada", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String) }).ConvertAll(a => (BibliotecaEntidades.Entidades.UnidadeMedidaClass)a);


                this.UnidadeMedidaCompra.DataSource = resultados;
                this.UnidadeMedidaCompra.DisplayMember = "Abreviada";
                this.UnidadeMedidaCompra.ValueMember = "ID";
                this.UnidadeMedidaCompra.autoSize = true;
                this.UnidadeMedidaCompra.Table = resultados;
                this.UnidadeMedidaCompra.ColumnsToDisplay = new[] { "Abreviada","NomeUnidade","Obs" };
                this.UnidadeMedidaCompra.HeadersToDisplay = new[] { "Abreviada", "Nome", "Obs" };


            }
            catch (ExcecaoTratada)
            {
                throw ;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção.\r\n" + e.Message);
            }
        }
        private void loadComboComprador()
        {
            try
            {
                BibliotecaEntidades.Entidades.CompradorClass search = new BibliotecaEntidades.Entidades.CompradorClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<BibliotecaEntidades.Entidades.CompradorClass> resultados =
                    search.Search(new List<SearchParameterClass>()
                                      {
                                          new SearchParameterClass("Apelido", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String),
                                          new SearchParameterClass("Nome", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String)
                                      }).ConvertAll(a => (BibliotecaEntidades.Entidades.CompradorClass) a);


                this.Comprador.DataSource = resultados;
                this.Comprador.DisplayMember = "Apelido";
                this.Comprador.ValueMember = "ID";
                this.Comprador.autoSize = true;
                this.Comprador.Table = resultados;
                this.Comprador.ColumnsToDisplay = new[] { "Apelido","Nome","AcsUsuario" };
                this.Comprador.HeadersToDisplay = new[] {"Apelido", "Nome", "Usuário"  };


            }
            catch (ExcecaoTratada)
            {
                throw ;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção.\r\n" + e.Message);
            }
        }

        private void loadComboFornecedorUnidadeMedidaCompra()
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

        #endregion

        private void defineTipoForm()
        {
            try
            {
                switch (TipoModulo.Tipo)
                {
                    case TipoForm.Engenharia:
                        this.grbCompras.Enabled = false;
                        this.grbPoliticaEstoque.Enabled = false;
                        this.grbPrincipal.Enabled = true;
                        break;

                    case TipoForm.PCP:
                        this.grbCompras.Enabled = true;
                        this.grbPoliticaEstoque.Enabled = true;
                        this.grbPrincipal.Enabled = false;
                        break;
                    case TipoForm.Gerencial:
                        this.grbCompras.Enabled = true;
                        this.grbPoliticaEstoque.Enabled = true;
                        this.grbPrincipal.Enabled = true;
                        break;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao definir o tipo do formulário\r\n" + e.Message, e);
            }
        }

        private void atualizaTextoConversaoUnidades()
        {
            try
            {



                if (this.UnidadeMedidaCompra.SelectedItem != null && this.UnidadeMedida.SelectedItem != null)
                {

                    UnidadeMedidaClass unidadeUso = (UnidadeMedidaClass)this.UnidadeMedida.SelectedItem;
                    UnidadeMedidaClass unidadeCompra = (UnidadeMedidaClass)this.UnidadeMedidaCompra.SelectedItem;

                    this.lblUnidades.Text = " 1 " +
                                            unidadeCompra.Abreviada +
                                            " => " + this.nudConversaoUnidades.Value.ToString("F4") + " " +
                                            unidadeUso.Abreviada;

                }







            }
            catch (Exception e)
            {
                throw new Exception("Erro ao atualizar conversão de unidades de medida.\r\n" + e.Message, e);
            }
        }

        private void loadGridFornecedor()
        {
            try
            {
                this.dataGridView1.AutoGenerateColumns = false;
                this.dataGridView1.DataSource = null;
                this.dataGridView1.DataSource = new AdvancedList<MaterialFornecedorClass>(((MaterialClass) this.Entity).CollectionMaterialFornecedorClassMaterial.Where(a => a.Ativo));
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

        private void atualizaSugestoes()
        {


            if (this.Entity != null)
            {
                MaterialClass Material = (MaterialClass)this.Entity;

                Material.clearSugestaoKb();

                if (Material.sugestaoKB != null)
                {
                    this.lblVerdeSugerido.Text = Convert.ToInt32(Material.sugestaoKB.Verde).ToString("D") + " " + Material.sugestaoKB.Unidade;
                    this.lbAmareloSugerido.Text = Convert.ToInt32(Material.sugestaoKB.Amarelo).ToString("D") + " " + Material.sugestaoKB.Unidade;
                    this.lblVermelhoSugerido.Text = Convert.ToInt32(Material.sugestaoKB.Vermelho).ToString("D") + " " + Material.sugestaoKB.Unidade;

                    this.lblClassificacaoABC.Text = Material.sugestaoKB.ClassificacaoABC;

                    this.lblReverVerde.Text = Material.sugestaoKB.obsRevisarKBVerde;
                    this.lblReverAmarelo.Text = Material.sugestaoKB.obsRevisarKBAmarelo;
                    this.lblReverVermelho.Text = Material.sugestaoKB.obsRevisarKBVermelho;


                }

                this.lblSugestaoLeadTime.Text = "Leadtime Aquisição Calculado: " + Material.getSugestaoLeadtime() + " dias";
            }
        }

        private void SalvarComo()
        {
            if (MessageBox.Show(this, "Essa operação irá realizar uma cópia do material atual como um novo material, certifique-se de que a identificação foi alterada. Você deseja continuar?", "Salvar como...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.VerificaUtilizacao = false;

                this.Entity = ((MaterialClass)this.Entity).SalvarComo();
                if (this.ListForm!=null)
                {
                    this.ListForm.ForceInitializeDataGrid();
                }

                this.Close();
            }
            else
            {
                return;
            }
        }

        private void HabilitarCopiar()
        {
            this.Text = "COPIANDO Item: " + this.txtCodigo.Text;
            this.btnSalvar.Text = "Salvar Cópia";

            foreach (Control c in this.Controls)
            {
                if (c is IWTBaseControl)
                {
                    ((IWTBaseControl) c).removeForceDisable();
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

            this.FamiliaMaterial.removeForceDisable();
            this.txtCodigo.removeForceDisable();
            this.nudComprimento.removeForceDisable();
            this.nudLargura.removeForceDisable();
            this.Acabamento.removeForceDisable();
            this.UnidadeMedida.removeForceDisable();
            this.nudMatMedida.removeForceDisable();
            this.chkUnidadeCompra.removeForceDisable();
            this.nudConversaoUnidades.removeForceDisable();
            this.UnidadeMedidaCompra.removeForceDisable();
            this.rdbNaoAplicavel.removeForceDisable();
            this.rdbProducaoRepetitiva.removeForceDisable();
            this.rdbMRP.removeForceDisable();
            this.ensFornecedor.removeForceDisable();

            this._salvarComo = true;
            this.DesabilitarAvisoAlteradoAoFechar = true;
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

                MaterialClass material = (MaterialClass) this.Entity;
                foreach (IWTDataGridViewRow row in this.dataGridView1.SelectedRows)
                {
                    MaterialFornecedorClass mf = (MaterialFornecedorClass) row.DataBoundItem;
                    material.removerFornecedorMaterial(mf);
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




                ((MaterialClass)this.Entity).adicionarFornecedor((FornecedorClass) this.ensFornecedor.EntidadeSelecionada,
                                                                  (double)this.nudUltimoPreco.Value,
                                                                  (double)this.nudImcsIncluso.Value, (double)this.nudIPINaoIncluso.Value,
                                                                  unidadeCompra, qtdUnidadeUso, chkFornecedorPreferencial.Checked, loteMinimo, lotePadrao);
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
                    MaterialFornecedorClass materialFornecedor = (MaterialFornecedorClass)((IWTDataGridViewRow)dataGridView1.SelectedRows[0]).DataBoundItem;

                    
                    
                    this.ensFornecedor.EntidadeSelecionada = materialFornecedor.Fornecedor;
                  


                    this.nudUltimoPreco.Value = (decimal)materialFornecedor.UltimoPreco;
                    this.nudImcsIncluso.Value = (decimal)materialFornecedor.Icms;
                    this.nudIPINaoIncluso.Value = (decimal)materialFornecedor.Ipi;
                    chkFornecedorPreferencial.Checked = materialFornecedor.Preferencial;

                    if (materialFornecedor.UnidadeMedidaCompra!=null)
                    {
                        this.chkUnidadeCompraFornecedor.Checked = true;
                        this.cmbFornecedorUnidadeCompra.SelectedItem = materialFornecedor.UnidadeMedidaCompra;
                        if (materialFornecedor.LotePadrao.HasValue)
                            this.nudFornecedorLotePadrao.Value = (decimal)materialFornecedor.LotePadrao;
                        if (materialFornecedor.LoteMinimo.HasValue)
                            this.nudFornecedorLoteMinimo.Value = (decimal)materialFornecedor.LoteMinimo;
                        if (materialFornecedor.UnidadesPorUnCompra.HasValue)
                            this.nudFornecedorUnidadesPorUnidadeCompra.Value = (decimal)materialFornecedor.UnidadesPorUnCompra;
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



                if (UnidadeMedidaCompra.Enabled)
                {
                    if (this.UnidadeMedidaCompra.SelectedItem != null)
                    {
                        this.lblFornecedorUnidadeCompra.Text = ((UnidadeMedidaClass) UnidadeMedidaCompra.SelectedItem).Abreviada;
                    }
                }

                else
                {
                    if (this.UnidadeMedida.SelectedItem != null)
                    {
                        this.lblFornecedorUnidadeCompra.Text =
                            ((UnidadeMedidaClass)UnidadeMedida.SelectedItem).Abreviada;
                    }
                }





            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao atualizar conversão de unidades de medida.\r\n" + e.Message, e);
            }
        }
        #endregion

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
            defineTipoForm();

            ensFornecedor.FormSelecao = new CadFornecedorListForm(TipoModulo.Tipo);

            base.OnShown(e);

            if (Entity != null)
            {
                this.loadGridFornecedor();
                this.exibeParametros();
                this.atualizaTextoConversaoUnidades();
                this.atualizaSugestoes();
            }

            
        }


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

        private void rdbMRP_CheckedChanged(object sender, EventArgs e)
        {

            this.nudLoteMinimo.Enabled = rdbProducaoRepetitiva.Checked || rdbMRP.Checked;
            this.nudLotePadrao.Enabled = rdbProducaoRepetitiva.Checked || rdbMRP.Checked;
            this.nudAmarelo.Enabled = rdbProducaoRepetitiva.Checked;
            this.nudVerde.Enabled = rdbProducaoRepetitiva.Checked;
            this.nudVermelho.Enabled = rdbProducaoRepetitiva.Checked;
            this.lblReverVerde.Visible = rdbProducaoRepetitiva.Checked;
            this.lblReverAmarelo.Visible = rdbProducaoRepetitiva.Checked;
            this.lblReverVermelho.Visible = rdbProducaoRepetitiva.Checked;

        }

        private void rdbProducaoRepetitiva_CheckedChanged(object sender, EventArgs e)
        {
            this.nudLoteMinimo.Enabled = rdbProducaoRepetitiva.Checked || rdbMRP.Checked;
            this.nudLotePadrao.Enabled = rdbProducaoRepetitiva.Checked || rdbMRP.Checked;
            this.nudAmarelo.Enabled = rdbProducaoRepetitiva.Checked;
            this.nudVerde.Enabled = rdbProducaoRepetitiva.Checked;
            this.nudVermelho.Enabled = rdbProducaoRepetitiva.Checked;
            this.lblReverVerde.Visible = rdbProducaoRepetitiva.Checked;
            this.lblReverAmarelo.Visible = rdbProducaoRepetitiva.Checked;
            this.lblReverVermelho.Visible = rdbProducaoRepetitiva.Checked;
        }

        private void rdbNaoAplicavel_CheckedChanged(object sender, EventArgs e)
        {
            this.nudLoteMinimo.Enabled = rdbProducaoRepetitiva.Checked || rdbMRP.Checked;
            this.nudLotePadrao.Enabled = rdbProducaoRepetitiva.Checked || rdbMRP.Checked;
            this.nudAmarelo.Enabled = rdbProducaoRepetitiva.Checked;
            this.nudVerde.Enabled = rdbProducaoRepetitiva.Checked;
            this.nudVermelho.Enabled = rdbProducaoRepetitiva.Checked;
            this.lblReverVerde.Visible = rdbProducaoRepetitiva.Checked;
            this.lblReverAmarelo.Visible = rdbProducaoRepetitiva.Checked;
            this.lblReverVermelho.Visible = rdbProducaoRepetitiva.Checked;
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

        private void cmbUnidade_SelectedIndexChanged(object sender, EventArgs e)
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

        private void chkUnidadeCompra_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.chkUnidadeCompra.Checked)
            {
                this.nudConversaoUnidades.Enabled = false;
                this.nudConversaoUnidades.Value = 1;
                this.UnidadeMedidaCompra.Enabled = false;
            }
            else
            {
                this.nudConversaoUnidades.Enabled = true;
                this.nudConversaoUnidades.Value = 1;
                this.UnidadeMedidaCompra.Enabled = true;
            }
            this.atualizaSugestoes();
            this.atualizaTextoUnidadeFornecedor();
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

        private void btnSalvarComo_Click(object sender, EventArgs e)
        {
            try
            {
                this.HabilitarCopiar();
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

        private void cmbFamiliaMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.FamiliaMaterial.SelectedItem != null)
                {

                    this.panel1.BackColor =
                        ColorTranslator.FromHtml(((FamiliaMaterialClass)(FamiliaMaterial.SelectedItem)).AgrupadorMaterial.Cor);

                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void chkComprador_CheckedChanged(object sender, EventArgs e)
        {
            this.Comprador.Enabled = this.chkComprador.Checked;
        }

        private void chkControleValidade_CheckedChanged(object sender, EventArgs e)
        {
            this.nudControleValidadeMeses.Enabled = this.chkControleValidade.Checked;
        }

        private void chkUnidadeCompraFornecedor_CheckedChanged(object sender, EventArgs e)
        {
            this.grbUnidadeCompraFornecedor.Enabled = this.chkUnidadeCompraFornecedor.Checked;
        }

        private void chkMargemRecebimento_CheckedChanged(object sender, EventArgs e)
        {
            this.nudMargemRecebimento.Enabled = this.chkMargemRecebimento.Checked;
        }
        #endregion

      

    }
}
