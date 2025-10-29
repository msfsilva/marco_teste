#region Referencias

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BibliotecaCadastrosBasicos.NovaEstruturaProduto;
using BibliotecaCentroCusto;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.ClassesAuxiliares.EstruturaEstoque;
using BibliotecaEntidades.Entidades;
using BibliotecaPedidos;
using Configurations;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Base;
using IWTFunctions;
using IWTPostgreNpgsql;
using Npgsql;
using ProjectConstants;

#endregion

namespace BibliotecaCadastrosBasicos
{


    public partial class CadPedidoItemForm : IWTForm
    {

        private bool loading = true;

        private bool codigoAutomatico = true;
        private bool descricaoAutomatica = true;
        private bool precoAutomatico = true;

        private bool codigoItemAutomatico = true;
        private bool descricaoItemAutomatica = true;
        

        private bool salvarComo;

        private TipoForm Tipo;
        private readonly bool _orcamento;


        protected PedidoItemClass Pedido
        {
            get { return (PedidoItemClass) this.Entity; }
        }

        private PedidoItemClass SubItemSelecionado;


        public CadPedidoItemForm(PedidoItemClass pedidoItem, CadPedidoItemListForm listForm, TipoForm tipoForm, bool orcamento = false)
            : base(pedidoItem, listForm, listForm.SingleConnection)
        {
            InitializeComponent();

            this.Tipo = tipoForm;
            _orcamento = orcamento;

            Init();
        }

        public CadPedidoItemForm(PedidoItemClass pedidoItem, TipoForm tipoForm, bool orcamento = false)
            : base(pedidoItem, typeof (PedidoItemClass), LoginClass.UsuarioLogado.loggedUser, null)
        {
            InitializeComponent();

            this.Tipo = tipoForm;
            _orcamento = orcamento;

            Init();
        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        private void Init()
        {
            ensItemPrincipal.FormSelecao = new CadProdutoListForm(this.Tipo, filtroSomenteVenda: true, somenteAtivos: true);
            ensSubItem.FormSelecao = new CadProdutoListForm(this.Tipo, filtroSomenteVenda: true, somenteAtivos: true);
            ensCliente.FormSelecao = new CadClienteListForm(this.Tipo);
            ensContaBancaria.FormSelecao = new CadContaBancariaListForm(this.Tipo);
            ensFormaPagamento.FormSelecao = new CadFormaPagamentoListForm(this.Tipo);
            ensOperacao.FormSelecao = new CadOperacaoListForm(this.Tipo);
            ensOperacaoCompleta.FormSelecao = new CadOperacaoCompletaListForm();
            ensCentroCustoLucro.FormSelecao = new SelecaoCentroCustoLucroForm(CentroCustoLucroNatureza.Lucro);
            ensRepresentante.FormSelecao = new CadRepresentanteListForm(this.Tipo);
            ensVendedor.FormSelecao = new CadVendedorListForm(this.Tipo);

            ensClienteEnvioTerceiros.FormSelecao = new CadClienteListForm(TipoModulo.Tipo);
            ensOperacaoEnvioTerceiros.FormSelecao = new CadOperacaoListForm(TipoModulo.Tipo);
            ensOperacaoCompletaEnvioTerceiros.FormSelecao = new CadOperacaoCompletaListForm();

            ensNCM.FormSelecao = new CadNcmListForm(this.Tipo);

            ensPedidoClassificacao.FormSelecao = new CadPedidoClassificacaoListForm();

            dgPedidoItemQualidade.AutoGenerateColumns = false;

            if (this._orcamento)
            {
                tabControl1.TabPages.Remove(tabPage3);
                this.rdbUrgenteAntecipacao.Visible = false;
                this.rdbUrgenteCritico.Visible = false;
                this.rdbUrgenteNormal.Visible = false;
                this.rdbUrgenteUrgente.Visible = false;
                this.gbxUrgente.Visible = false;
                this.grbOriginais.Visible = false;
                this.btnMateriaisCliente.Visible = false;
                this.Text = "Orçamento";
                this.btnCopiar.Text = "Copiar Orçamento";
                this.tabPage3.Visible = false;

                this.grbFeedback.Visible = false;
                this.grbFeedbackSecundario.Visible = false;

                this.tabPage5.Visible = false;
            }


            if (!IWTConfiguration.Conf.getBoolConf(Constants.HISTORICO_ALTERACOES_PEDIDO))
            {
                tabHistoricoAlteracoes.Visible = false;
                tabControl1.TabPages.Remove(tabHistoricoAlteracoes);
            }

            this.loadKits();

            if (this.Pedido.ID != -1)

            {
                Label possuiProdutosVencidos = this.possuiProdutosVencidosLbl;
                possuiProdutosVencidos.Visible = this.Pedido.possuiProdutoVencido();
            }
        }

        private void atualizaGridPedidoItemQualidade()
        {
            dgPedidoItemQualidade.DataSource = null;
            dgPedidoItemQualidade.DataSource = new AdvancedList<PedidoItemQualidadeClass>(this.Pedido.CollectionPedidoItemQualidadeClassPedidoItem);
            dgPedidoItemQualidade.Refresh();
        }

        private void updateGrid()
        {
            try
            {

               

             
                dataGridView1.DataSource = null;

                dataGridView1.DataSource = this.Pedido.CollectionPedidoItemClassPedidoItemPai;

                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.MultiSelect = false;

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados dos Itens do pedido no grid.\r\n" + e.Message);
            }
        }

        private void editFieldsMode()
        {
            if (!this._orcamento && this.Pedido != null && this.Pedido.Status != StatusPedido.Pendente && this.Pedido.Status != StatusPedido.Reaberto)
            {

                this.tabPage1.Enabled = false;

                groupBox6.Enabled = false;
                groupBox8.Enabled = false;

                this.tabPage4.Enabled = false;
                this.tabPage5.Enabled = false;

                this.btnCancelar.Enabled = false;
                this.btnCopiar.Enabled = true;
            }
            else
            {
                this.nudValorUnit.Enabled = true;
                if (this.Pedido != null && Pedido.Configurado)
                {
                    this.ensItemPrincipal.forceDisable();
                    this.ensCliente.forceDisable();
                    this.txtOc.forceDisable();
                    this.nudPosicao.forceDisable();

                    this.txtProjeto.forceDisable();
                    this.txtArmazenagem.forceDisable();
                    this.txtCodigo.forceDisable();
                    this.txtDescricao.forceDisable();
                    this.cbxEntregaParc.forceDisable();
                    this.cbxVolumeUnico.forceDisable();
                    this.nudQtd.forceDisable();
                    this.nudQtdItem.forceDisable();
                    this.txtCodigoItem.forceDisable();
                    this.txtDescricaoItem.forceDisable();

                    this.ensSubItem.forceDisable();

                    this.chkExportacao.forceDisable();
                    this.btnConfirmarEdicao.forceDisable();
                    this.btnEditarItem.forceDisable();
                    this.btnAdicionar.forceDisable();
                    this.btnRemover.forceDisable();

                    this.txtInfoEspeciais.forceDisable();

                    this.gbxItem.Enabled = false;
                    this.cmbTipoKit.forceDisable();
                    this.chkTipoKit.forceDisable();

                }

            }
        }

        private void loadKits()
        {
            try
            {
                  

                List<LoadClass> kits = new List<LoadClass>();

                IWTPostgreNpgsqlCommand command = this.SingleConnection.CreateCommand();
                command.CommandText = "SELECT  " +
                    "  public.kit_tipo_kit.pek_tipo_kit " +
                    "FROM " +
                    "  public.kit_tipo_kit " +
                    "ORDER BY " +
                    "  public.kit_tipo_kit.pek_tipo_kit "; 

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    kits.Add(new LoadClass(read["pek_tipo_kit"].ToString(), read["pek_tipo_kit"].ToString()));
                }




                this.cmbTipoKit.DataSource = kits;
                this.cmbTipoKit.ValueMember = "id";
                this.cmbTipoKit.DisplayMember = "descricao";

            }
            catch (Exception a)
            {
                MessageBox.Show("Erro ao carregar dados dos kits.\r\n" + a.Message, "Dados do Cliente",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void validateRequiredFieldsToSave()
        {
            try
            {
                if (this.txtOc.Text.Trim().Length == 0)
                {
                    throw new Exception("Campo Numero do pedido é obrigatório.");
                }

                

                if (this.txtDescricao.Enabled && this.txtDescricao.Text.Trim().Length == 0)
                {
                    throw new Exception("Campo Descrição é obrigatório.");
                }

                if (this.txtCodigo.Enabled && this.txtCodigo.Text.Trim().Length == 0)
                {
                    throw new Exception("Campo Código é obrigatório.");
                }

                if (this.ensNCM.Enabled && this.ensNCM.EntidadeSelecionada == null)
                {
                    throw new Exception("Campo NCM é obrigatório.");
                }

                if (this.ensCliente.EntidadeSelecionada == null)
                {
                    throw new Exception("Campo Cliente é obrigatório. Selecione um item da lista de seleção.");
                }


                if (!IWTConfiguration.Conf.getBoolConf(Constants.PERMITE_PEDIDO_SEM_OPERACAO))
                {
                    if (IWTConfiguration.Conf.getBoolConf(Constants.TRIBUTACAO_OPERACAO))
                    {
                        if (this.ensOperacaoCompleta.EntidadeSelecionada == null)
                        {
                            throw new Exception("Campo Operação é obrigatório. Selecione um item da lista de seleção.");
                        }
                    }

                    else
                    {
                        if (this.ensOperacao.EntidadeSelecionada == null)
                        {
                            throw new Exception("Campo Operação é obrigatório. Selecione um item da lista de seleção.");
                        }
                    }
                }

                if (gbxUrgente.Enabled)
                {
                    if (this.txtUrgenteSolicitante.Text.Trim().Length == 0)
                    {
                        throw new Exception("Campo de Solicitante é obrigatório para pedidos urgentes.");
                    }
                }

                if (this.cmbTipoKit.Enabled && this.cmbTipoKit.SelectedValue == null)
                {
                    throw new Exception("Selecione o tipo do kit ou desabilite a opção de kit.");
                }

                if (ensContaBancaria.Enabled && ensContaBancaria.EntidadeSelecionada == null)
                {
                    throw new Exception("Selecione uma conta bancária ou desabilite o campo");
                }

                if (ensCentroCustoLucro.Enabled && this.ensCentroCustoLucro.EntidadeSelecionada == null)
                {
                    throw new Exception("Selecione um centro de custo ou desabilite o campo");
                }

                if (ensFormaPagamento.Enabled && ensFormaPagamento.EntidadeSelecionada == null)
                {
                    throw new Exception("Selecione uma forma de pagamento ou desabilite o campo");
                }

                if (ensRepresentante.Enabled)
                {
                    if (ensRepresentante.EntidadeSelecionada == null)
                    {
                        throw new Exception("Informe o Representante a receber comissão ou inabilite os campos de Comissão");
                    }
                    if (nudComissaoRepresentante.Value == 0)
                    {
                        throw new Exception("Informe um percentual de Comissão para o Representante ou inabilite os campos de Comissão");
                    }
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao validar os campos obrigatórios.\r\n" + e.Message);
            }
        }

        protected override void Salvar(IWTPostgreNpgsqlCommand command = null)
        {
            this.validateRequiredFieldsToSave();


            if (!this.Pedido.Configurado)
            {
                this.Pedido.SetKit(this.cmbTipoKit.Enabled ? this.cmbTipoKit.SelectedValue.ToString() : null);
            }


            if (!this.salvarComo)
            {
                base.Salvar(command);
            }
            else
            {
                this.SalvarComo();
            }

            EnviarEmail();
        }

        private void SalvarComo()
        {

            this.Pedido.SalvarComo();

            this.ListForm.ForceInitializeDataGrid();

            this.Close();

        }

        private void EnviarEmail()
        {
            try
            {

                PedidoAgrupador agrupador = new PedidoAgrupador(
                    PedidoOrcamento.Pedido,
                    this.txtOc.Text.Trim(),
                    this.Pedido.Cliente,
                    this.Pedido.Representante,
                    this.Pedido.Vendedor,
                    LoginClass.UsuarioLogado.loggedUser, 
                    this.SingleConnection
                    );


                agrupador.AdicionarPedido(this.Pedido);

                agrupador.EnviarEmail();
            }
            catch (Exception e)
            {
                MessageBox.Show(this, "Ocorreu um erro ao enviar os emails do pedido/orçamento.\r\n" + e.Message, "Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void validateRequiredFields()
        {
            try
            {
                if (this.ensSubItem.EntidadeSelecionada == null)
                {
                    throw new Exception("Campo Produto é obrigatório.");
                }

                if (this.txtDescricaoItem.Text.Trim().Length == 0)
                {
                    throw new Exception("Campo Descrição do item é obrigatório.");
                }

                if (this.txtCodigoItem.Text.Trim().Length == 0)
                {
                    throw new Exception("Campo Código do item é obrigatório.");
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao validar os campos obrigatórios.\r\n" + e.Message);
            }
        }

        private void cleanItemFields()
        {
            this.ensSubItem.Clear();
            this.txtCodigoItem.Clear();
            this.txtDescricaoItem.Clear();
            this.SubItemSelecionado = null;
            
            codigoItemAutomatico = true;
            descricaoItemAutomatica = true;

            this.nudQtdItem.Value = 1;
        }

        private void updateTotalMainItem()
        {

            double valorTotal = (double) (nudQtd.Value * nudValorUnit.Value) - (double) nudDesconto.Value;
            lblTotal.Text = "Total: R$ " + valorTotal.ToString("F2", CultureInfo.CurrentCulture);
        }

        private void updateNCMPrincipal()
        {

            ProdutoClass produto = (ProdutoClass) this.ensItemPrincipal.EntidadeSelecionada;

            if (produto != null && !this.ensNCM.Enabled)
            {
                if (produto.CollectionProdutoFiscalClassProduto.Any() && produto.CollectionProdutoFiscalClassProduto.First().Ncm != null)
                {
                    ensNCM.EntidadeSelecionada= produto.CollectionProdutoFiscalClassProduto.First().Ncm;
                }
            }

        }

        private void Editar()
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count == 0)
                {
                    throw new Exception("Selecione o subitem a ser editado");
                }

                this.SubItemSelecionado = (PedidoItemClass) ((IWTDataGridViewRow) this.dataGridView1.SelectedRows[0]).DataBoundItem;


                codigoItemAutomatico = false;
                descricaoItemAutomatica = false;

                ensSubItem.EntidadeSelecionada = SubItemSelecionado.Produto;

                this.txtCodigoItem.Text = SubItemSelecionado.ProdutoCodigoCliente;
                this.txtDescricaoItem.Text = SubItemSelecionado.ProdutoDescricaoCliente;

                this.nudQtdItem.Value = (decimal) SubItemSelecionado.Quantidade;

                this.btnEditarItem.Visible = false;
                this.btnConfirmarEdicao.Visible = true;

                this.dataGridView1.Enabled = false;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao editar o subitem.\r\n" + e.Message, e);
            }
        }

        private void ConfirmarEdicao()
        {
            try
            {
                PedidoItemClass sublinha = (PedidoItemClass) ((IWTDataGridViewRow) this.dataGridView1.SelectedRows[0]).DataBoundItem;

                sublinha.Quantidade = (double) this.nudQtdItem.Value;

                sublinha.ProdutoCodigoCliente = this.txtCodigoItem.Text;
                sublinha.ProdutoDescricaoCliente = this.txtDescricaoItem.Text;


                this.btnEditarItem.Visible = true;
                this.btnConfirmarEdicao.Visible = false;

                this.dataGridView1.Enabled = true;

                this.updateGrid();
                this.cleanItemFields();


            }
            catch (Exception e)
            {
                throw new Exception("Erro ao confirmar a edição do subitem.\r\n" + e.Message, e);
            }
        }

        private void MateriaisCliente()
        {
            try
            {

                List<LoteClass> lotesDisponiveis = this.Pedido.CollectionPedidoItemLoteClienteClassPedidoItem.Select(loteCliente => loteCliente.Lote).ToList();

                LoteClass search = new LoteClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                lotesDisponiveis.AddRange(search.Search(new List<SearchParameterClass>
                                                            {
                                                                new SearchParameterClass("Cliente", this.Pedido.Cliente),
                                                                new SearchParameterClass("Situacao", StatusLote.EmAberto),
                                                                new SearchParameterClass("SaldoVinculoPedidoAberto", true),
                                                            }).ConvertAll(a => (LoteClass) a));



                if (lotesDisponiveis.Count == 0)
                {
                    throw new Exception(
                        "Não existem lotes disponíveis para o cliente selecionado. Realize o recebimento dos materiais antes de continuar.");
                }




                CadPedidoItemMaterialClienteForm form = new CadPedidoItemMaterialClienteForm(this.Pedido, lotesDisponiveis);
                form.ShowDialog();

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao editar os materiais do cliente.\r\n" + e.Message, e);
            }
        }

        private void habilitarCopiar()
        {

            this.tabPage1.Enabled = true;
            this.tabPage2.Enabled = true;
            this.tabPage3.Enabled = true;
            this.tabPage4.Enabled = true;
            this.tabPage5.Enabled = true;
            tabFeedbackSecundario.Enabled = true;


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
            this.btnSalvar.Enabled = true;
            this.btnCancelar.Enabled = true;


            this.nudValorUnit.removeForceDisable();

            this.ensItemPrincipal.removeForceDisable();
            this.ensOperacao.removeForceDisable();
            this.ensCliente.removeForceDisable();
            this.dtpDataEntrega.removeForceDisable();
            this.txtOc.removeForceDisable();
            this.nudPosicao.removeForceDisable();
            this.ensNCM.removeForceDisable();
            this.txtProjeto.removeForceDisable();
            this.txtArmazenagem.removeForceDisable();
            this.txtCodigo.removeForceDisable();
            this.txtDescricao.removeForceDisable();
            this.nudFrete.removeForceDisable();
            this.cbxEntregaParc.removeForceDisable();
            this.cbxVolumeUnico.removeForceDisable();
            this.nudQtd.removeForceDisable();
            //this.dtpDataPedido.removeForceDisable();

            this.nudQtdItem.removeForceDisable();
            this.txtCodigoItem.removeForceDisable();
            this.txtDescricaoItem.removeForceDisable();
            //this.cmbProdItem.removeForceDisable();
            this.ensSubItem.removeForceDisable();

            this.chkExportacao.removeForceDisable();
            this.btnConfirmarEdicao.removeForceDisable();
            this.btnEditarItem.removeForceDisable();
            this.btnAdicionar.removeForceDisable();
            this.btnRemover.removeForceDisable();

            this.txtInfoEspeciais.removeForceDisable();

            this.chkTipoKit.removeForceDisable();
            this.gbxItem.Enabled = true;
            this.cmbTipoKit.removeForceDisable();

            this.chkRastrearMP.removeForceDisable();


            this.salvarComo = true;

            this.grbCancelamento.Visible = false;

            this.Text = "COPIANDO " + this.Text;
            this.btnCopiar.Visible = false;

            this.btnSalvar.Text = "Salvar Cópia";


            this.chkTipoKit_CheckedChanged(null, null);
            AjustaEnvioTerceirosTela();

        }

        private void detalhesPrincipal()
        {
            try
            {
                if (this.Pedido.Produto != null)
                {
                    CadProdutoForm form = new CadProdutoForm(this.Pedido.Produto, this.Tipo)
                                              {
                                                  SomenteLeitura = true
                                              };
                    form.Show();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao abrir os detalhes do produto.\r\n" + e.Message, e);
            }
        }

        private void detalhesSub()
        {
            try
            {
                if (this.SubItemSelecionado != null && this.SubItemSelecionado.Produto != null)
                {
                    CadProdutoForm form = new CadProdutoForm(this.SubItemSelecionado.Produto, this.Tipo)
                                              {
                                                  SomenteLeitura = true
                                              };
                    form.Show();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao abrir os detalhes do produto.\r\n" + e.Message, e);
            }

        }

        private void selecionarCliente()
        {
            try
            {
                if (this.ensCliente.EntidadeSelecionada != null)
                {
                    ClienteClass cliente = (ClienteClass) ensCliente.EntidadeSelecionada;

                    if (!ensCentroCustoLucro.Enabled)
                    {
                        if (cliente.PossuiCentroCustoLucro)
                        {
                            ensCentroCustoLucro.EntidadeSelecionada = cliente.CentroCustoLucro;
                        }
                        else
                        {
                            ensCentroCustoLucro.Clear();
                        }
                    }

                    if (!ensContaBancaria.Enabled)
                    {
                        if (cliente.PossuiContaBancaria)
                        {
                            this.ensContaBancaria.EntidadeSelecionada = cliente.ContaBancaria;
                        }
                        else
                        {
                            this.ensContaBancaria.Clear();

                        }
                    }

                    if (!ensFormaPagamento.Enabled)
                    {
                        if (cliente.PossuiFormaPagamento)
                        {
                            this.ensFormaPagamento.EntidadeSelecionada = cliente.FormaPagamento;
                        }
                        else
                        {
                            this.ensFormaPagamento.Clear();

                        }
                    }


                    if (!loading)
                    {

                        if (cliente.Representante != null)
                        {
                            ensRepresentante.Enabled = true;
                            ensRepresentante.EntidadeSelecionada = cliente.Representante;
                            if (cliente.PercComissaoRepresentante.HasValue)
                            {
                                nudComissaoRepresentante.Value = (decimal) cliente.PercComissaoRepresentante;
                            }
                            else
                            {
                                nudComissaoRepresentante.Value = (decimal) cliente.Representante.Comissao;
                            }
                        }
                        else
                        {
                            ensRepresentante.Enabled = false;
                            nudComissaoRepresentante.Value = 0;
                        }

                        if (cliente.Vendedor != null)
                        {
                            ensVendedor.Enabled = true;
                            ensVendedor.EntidadeSelecionada = cliente.Vendedor;
                            if (cliente.PercComissaoVendedor.HasValue)
                            {
                                nudComissaoVendedor.Value = (decimal) cliente.PercComissaoVendedor;
                            }
                            else
                            {
                                nudComissaoVendedor.Value = (decimal) cliente.Vendedor.Comissao;
                            }
                        }
                        else
                        {
                            ensVendedor.Enabled = false;
                            nudComissaoVendedor.Value = 0;
                        }
                    }

                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao selecionar o cliente.\r\n" + e.Message, e);
            }
        }
        
        private void SelecionarArquivo()
        {
            try
            {
                if (this.Pedido != null)
                {
                    CadPedidoItemSelecaoArquivoQualidadeForm selecao = new CadPedidoItemSelecaoArquivoQualidadeForm();
                    selecao.ShowDialog();
                    if (selecao.PedidoItemQualidade != null)
                    {
                        PedidoItemQualidadeClass pedidoItemQualidade = selecao.PedidoItemQualidade;
                        pedidoItemQualidade.PedidoItem = this.Pedido;


                        this.Pedido.CollectionPedidoItemQualidadeClassPedidoItem.Add(pedidoItemQualidade);
                        atualizaGridPedidoItemQualidade();
                    }
                }


            }
            catch (Exception a)
            {
                throw new Exception("Erro ao abrir a seleção de arquivos\r\n" + a.Message);
            }
        }

        private void DeletarArquivo()
        {
            try
            {
                if (dgPedidoItemQualidade.CurrentRow == null)
                {
                    throw new Exception("Selecione o arquivo que deseja excluir.");
                }
                dgPedidoItemQualidade.CurrentRow.Cells[1].Value = true;
                atualizaGridPedidoItemQualidade();
                MessageBox.Show("Removido com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            catch (Exception a)
            {
                throw new Exception("Erro ao remover o arquivo selecionado.\r\n" + a.Message);
            }
        }

        private void DownloadArquivo()
        {
            try
            {
                if (this.dgPedidoItemQualidade.SelectedRows.Count <= 0) return;

                PedidoItemQualidadeClass pedidoItem = (PedidoItemQualidadeClass) this.dgPedidoItemQualidade.SelectedRows[0].DataBoundItem;
                byte[] arquivo = pedidoItem.Arquivo;



                folderBrowserDialog1.ShowNewFolderButton = true;
                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string path = folderBrowserDialog1.SelectedPath;
                    File.WriteAllBytes(path + "\\" + pedidoItem.NomeArquivo, arquivo);
                    MessageBox.Show(this, "Arquivo salvo com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar o arquivo\r\n" + e.Message, e);
            }
        }

        #region Feedback

        private void LoadGridFeedback()
        {
            this.dgvFeedbacks.AutoGenerateColumns = false;
            this.dgvFeedbacks.Columns.Clear();

            this.dgvFeedbacks.Columns.Add(new DataGridViewTextBoxColumn());
            this.dgvFeedbacks.Columns[this.dgvFeedbacks.Columns.Count - 1].DataPropertyName = "Data";
            this.dgvFeedbacks.Columns[this.dgvFeedbacks.Columns.Count - 1].Name = "Data";
            this.dgvFeedbacks.Columns[this.dgvFeedbacks.Columns.Count - 1].HeaderText = "Data";
            this.dgvFeedbacks.Columns[this.dgvFeedbacks.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            this.dgvFeedbacks.Columns.Add(new DataGridViewTextBoxColumn());
            this.dgvFeedbacks.Columns[this.dgvFeedbacks.Columns.Count - 1].DataPropertyName = "AcsUsuario";
            this.dgvFeedbacks.Columns[this.dgvFeedbacks.Columns.Count - 1].Name = "AcsUsuario";
            this.dgvFeedbacks.Columns[this.dgvFeedbacks.Columns.Count - 1].HeaderText = "Responsável";
            this.dgvFeedbacks.Columns[this.dgvFeedbacks.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            this.dgvFeedbacks.Columns.Add(new DataGridViewTextBoxColumn());
            this.dgvFeedbacks.Columns[this.dgvFeedbacks.Columns.Count - 1].DataPropertyName = "Texto";
            this.dgvFeedbacks.Columns[this.dgvFeedbacks.Columns.Count - 1].Name = "Texto";
            this.dgvFeedbacks.Columns[this.dgvFeedbacks.Columns.Count - 1].HeaderText = "Feedback";
            this.dgvFeedbacks.Columns[this.dgvFeedbacks.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.dgvFeedbacks.Columns[this.dgvFeedbacks.Columns.Count - 1].Width = 350;

            this.dgvFeedbacks.DataSource = new AdvancedList<PedidoItemFeedbackClass>(this.Pedido.CollectionPedidoItemFeedbackClassPedidoItem.OrderBy(a => a.Data));


        }

        private void NovoFeedback()
        {
            try
            {
                this.btnFeedbackAdicionar.Enabled = false;
                this.txtFeedback.Enabled = true;
                this.txtFeedback.Clear();
                this.btnFeedbackOk.Enabled = true;
                this.txtFeedback.Focus();

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao criar o novo feedback \r\n" + e.Message, e);
            }
        }

        private void NovoFeedbackInserir()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(this.txtFeedback.Text))
                {
                    throw new Exception("O feedback não pode ser vazio");
                }

                PedidoItemFeedbackClass feedback = new PedidoItemFeedbackClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection)
                {
                    Texto = this.txtFeedback.Text.Trim(),
                    PedidoItem = this.Pedido,
                    AcsUsuario = LoginClass.UsuarioLogado.loggedUser,
                    Data = Configurations.DataIndependenteClass.GetData(),
                    Atual = true
                };

                this.Pedido.CollectionPedidoItemFeedbackClassPedidoItem.Add(feedback);

                this.LoadGridFeedback();

                this.btnFeedbackAdicionar.Enabled = true;
                this.txtFeedback.Enabled = false;
                this.txtFeedback.Clear();
                this.btnFeedbackOk.Enabled = false;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao incluir o novo feedback no pedido\r\n" + e.Message, e);
            }
        }

        private void FeedbackSelecionado()
        {
            try
            {
                if (this.dgvFeedbacks.SelectedRows.Count > 0)
                {
                    this.txtFeedback.Text = ((PedidoItemFeedbackClass)dgvFeedbacks.SelectedRows[0].DataBoundItem).Texto;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao selecionar o feedback\r\n" + e.Message, e);
            }
        }


        #endregion


        #region Feedback Secundario

        private void LoadGridFeedbackSecundario()
        {
            this.dgvFeedbacksSecundarios.AutoGenerateColumns = false;
            this.dgvFeedbacksSecundarios.Columns.Clear();

            this.dgvFeedbacksSecundarios.Columns.Add(new DataGridViewTextBoxColumn());
            this.dgvFeedbacksSecundarios.Columns[this.dgvFeedbacksSecundarios.Columns.Count - 1].DataPropertyName = "Data";
            this.dgvFeedbacksSecundarios.Columns[this.dgvFeedbacksSecundarios.Columns.Count - 1].Name = "Data";
            this.dgvFeedbacksSecundarios.Columns[this.dgvFeedbacksSecundarios.Columns.Count - 1].HeaderText = "Data";
            this.dgvFeedbacksSecundarios.Columns[this.dgvFeedbacksSecundarios.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            this.dgvFeedbacksSecundarios.Columns.Add(new DataGridViewTextBoxColumn());
            this.dgvFeedbacksSecundarios.Columns[this.dgvFeedbacksSecundarios.Columns.Count - 1].DataPropertyName = "AcsUsuario";
            this.dgvFeedbacksSecundarios.Columns[this.dgvFeedbacksSecundarios.Columns.Count - 1].Name = "AcsUsuario";
            this.dgvFeedbacksSecundarios.Columns[this.dgvFeedbacksSecundarios.Columns.Count - 1].HeaderText = "Responsável";
            this.dgvFeedbacksSecundarios.Columns[this.dgvFeedbacksSecundarios.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            this.dgvFeedbacksSecundarios.Columns.Add(new DataGridViewTextBoxColumn());
            this.dgvFeedbacksSecundarios.Columns[this.dgvFeedbacksSecundarios.Columns.Count - 1].DataPropertyName = "Texto";
            this.dgvFeedbacksSecundarios.Columns[this.dgvFeedbacksSecundarios.Columns.Count - 1].Name = "Texto";
            this.dgvFeedbacksSecundarios.Columns[this.dgvFeedbacksSecundarios.Columns.Count - 1].HeaderText = "Planejamento";
            this.dgvFeedbacksSecundarios.Columns[this.dgvFeedbacksSecundarios.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.dgvFeedbacksSecundarios.Columns[this.dgvFeedbacksSecundarios.Columns.Count - 1].Width = 350;

            this.dgvFeedbacksSecundarios.DataSource = new AdvancedList<PedidoItemFeedbackSecundarioClass>(this.Pedido.CollectionPedidoItemFeedbackSecundarioClassPedidoItem.OrderBy(a => a.Data));


        }

        private void NovoFeedbackSecundario()
        {
            try
            {
                this.btnFeedbackSecundarioAdicionar.Enabled = false;
                this.txtFeedbackSecundario.Enabled = true;
                this.txtFeedbackSecundario.Clear();
                this.btnFeedbackSecundarioOk.Enabled = true;
                this.txtFeedbackSecundario.Focus();

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao criar o novo feedback secundário \r\n" + e.Message, e);
            }
        }

        private void NovoFeedbackSecundarioInserir()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(this.txtFeedbackSecundario.Text))
                {
                    throw new Exception("O feedback não pode ser vazio");
                }

                PedidoItemFeedbackSecundarioClass feedback = new PedidoItemFeedbackSecundarioClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection)
                {
                    Texto = this.txtFeedbackSecundario.Text.Trim(),
                    PedidoItem = this.Pedido,
                    AcsUsuario = LoginClass.UsuarioLogado.loggedUser,
                    Data = Configurations.DataIndependenteClass.GetData(),
                    Atual = true
                };

                this.Pedido.CollectionPedidoItemFeedbackSecundarioClassPedidoItem.Add(feedback);

                this.LoadGridFeedbackSecundario();

                this.btnFeedbackSecundarioAdicionar.Enabled = true;
                this.txtFeedbackSecundario.Enabled = false;
                this.txtFeedbackSecundario.Clear();
                this.btnFeedbackSecundarioOk.Enabled = false;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao incluir o novo feedback secundário no pedido\r\n" + e.Message, e);
            }
        }

        private void FeedbackSecundarioSelecionado()
        {
            try
            {
                if (this.dgvFeedbacksSecundarios.SelectedRows.Count > 0)
                {
                    this.txtFeedbackSecundario.Text = ((PedidoItemFeedbackSecundarioClass)dgvFeedbacksSecundarios.SelectedRows[0].DataBoundItem).Texto;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao selecionar o feedback secundário\r\n" + e.Message, e);
            }
        }


        #endregion

        private void EstruturaPrincipal()
        {
            if (ensItemPrincipal.EntidadeSelecionada == null)
            {
                return;
            }

            ProdutoClass produto = (ProdutoClass) ensItemPrincipal.EntidadeSelecionada;

            CadProdutoEstruturaFormNew form = new CadProdutoEstruturaFormNew(produto, Tipo, true);
            form.ShowDialog();
        }
        private void AjustaEnvioTerceirosTela()
        {
            if (IWTConfiguration.Conf.getBoolConf(Constants.TRIBUTACAO_OPERACAO))
            {
                ensOperacaoEnvioTerceiros.forceDisable();
                ensOperacaoEnvioTerceiros.Visible = false;
                lblOperacaoEnvioTerceiros.Visible = false;

                ensOperacaoCompletaEnvioTerceiros.Visible = true;
                lblOperacaoCompletaEnvioTerceiros.Visible = true;

                if (chkEnvioTerceiros.Checked)
                {
                    ensOperacaoCompletaEnvioTerceiros.removeForceDisable();
                }
                else
                {
                    ensOperacaoCompletaEnvioTerceiros.forceDisable();
                }
            }
            else
            {
                ensOperacaoCompletaEnvioTerceiros.forceDisable();
                ensOperacaoCompletaEnvioTerceiros.Visible = false;
                lblOperacaoCompletaEnvioTerceiros.Visible = false;

                ensOperacaoEnvioTerceiros.Visible = true;
                lblOperacaoEnvioTerceiros.Visible = true;

                if (chkEnvioTerceiros.Checked)
                {
                    ensOperacaoEnvioTerceiros.removeForceDisable();
                }
                else
                {
                    ensOperacaoEnvioTerceiros.forceDisable();
                }

            }

            if (chkEnvioTerceiros.Checked)
            {
                ensClienteEnvioTerceiros.removeForceDisable();
            }

            else
            {
                ensClienteEnvioTerceiros.forceDisable();
            }
        }

        private void CarregaHistoricoAlteracoes()
        {
            this.dgvHistoricoAlteracoes.DataSource = new AdvancedList<PedidoItemHistoricoAlteracoesClass>(this.Pedido.CollectionPedidoItemHistoricoAlteracoesClassPedidoItem.OrderByDescending(a => a.Data));
        }


        #region Eventos

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                this.validateRequiredFields();

                this.Pedido.adicionarSubitem(
                    (ProdutoClass) this.ensSubItem.EntidadeSelecionada, txtCodigoItem.Text, txtDescricaoItem.Text, Convert.ToDouble(nudQtdItem.Value), 0);


                this.updateGrid();
                this.cleanItemFields();
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    PedidoItemClass subLinha = (PedidoItemClass) ((IWTDataGridViewRow) dataGridView1.SelectedRows[0]).DataBoundItem;
                    this.Pedido.excluirSubItem(subLinha);
                    this.updateGrid();
                }
                else
                {
                    throw new Exception("Selecione o subitem que você deseja remover.");
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nudQtd_ValueChanged(object sender, EventArgs e)
        {
            this.updateTotalMainItem();
        }

        private void nudValorUnit_ValueChanged(object sender, EventArgs e)
        {
            this.updateTotalMainItem();
        }

        private void btnVariaveis_Click(object sender, EventArgs e)
        {
            if (this.Pedido.Numero != null)
            {
                CadPedidoItemVariavelListForm form = new CadPedidoItemVariavelListForm(this.Pedido);
                form.ShowDialog();
            }

        }

        private void rdbUrgenteNormal_CheckedChanged(object sender, EventArgs e)
        {
            this.gbxUrgente.Enabled = !rdbUrgenteNormal.Checked;
        }

        private void rdbUrgenteAntecipacao_CheckedChanged(object sender, EventArgs e)
        {
            this.gbxUrgente.Enabled = !rdbUrgenteNormal.Checked;
        }

        private void rdbUrgenteUrgente_CheckedChanged(object sender, EventArgs e)
        {
            this.gbxUrgente.Enabled = !rdbUrgenteNormal.Checked;

        }

        private void rdbUrgenteCritico_CheckedChanged(object sender, EventArgs e)
        {
            this.gbxUrgente.Enabled = !rdbUrgenteNormal.Checked;

        }

        private void btnEditarItem_Click(object sender, EventArgs e)
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

        private void btnConfirmarEdicao_Click(object sender, EventArgs e)
        {
            try
            {
                this.ConfirmarEdicao();
            }

            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkTipoKit_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbTipoKit.Enabled = this.chkTipoKit.Checked;
            this.gbxItem.Enabled = this.chkTipoKit.Checked;
        }

        private void btnMateriaisCliente_Click(object sender, EventArgs e)
        {
            try
            {
                this.MateriaisCliente();
            }

            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            codigoAutomatico = false;
        }

        private void txtDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            descricaoAutomatica = false;
        }

        private void txtCodigoItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            codigoItemAutomatico = false;
        }

        private void txtDescricaoItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            descricaoItemAutomatica = false;
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!LoginClass.UsuarioLogado.HasAccess("MODULO_PCP_PEDIDOS_VALORES", AcsTipoAcesso.Escrita))
                {
                    throw new ExcecaoTratada("Desculpe não é possível utilizar essa funcionalidade pois o seu usuário não possui acesso aos valores dos pedidos");
                }


                this.habilitarCopiar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkDetalhesPrincipal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.detalhesPrincipal();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkDetalhesSub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.detalhesSub();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnShown(EventArgs e)
        {
            try
            {
                if (Entity != null)
                {
                    loading = true;
                    this.editFieldsMode();
                    this.updateGrid();
                    this.btnVariaveis.Enabled = true;
                    this.btnDocumentosPedido.Enabled = true;
                    loading = false;
                }
                else
                {
                    tabControl1.TabPages.Remove(tabPage3);
                    this.grbFeedback.Visible = false;


                    this.txtOc.Text = this.Pedido.Numero;
                    this.nudPosicao.Value = this.Pedido.Posicao;
                }


                if (this.Pedido != null && this.Pedido.ID != -1)
                {
                    this.loading = true;
                }

                base.OnShown(e);



                this.selecionarCliente();

                if (this.Pedido.ID == -1)
                {

                    this.Pedido.InicializarNumeracaoAutomatica();

                    this.txtOc.Text = this.Pedido.Numero;
                    this.nudPosicao.Value = this.Pedido.Posicao;


                }
                else
                {
                    this.loading = false;
                }



                this.LoadGridFeedback();


                if (!IWTConfiguration.Conf.getBoolConf(Constants.FEEDBACK_SECUNDARIO_HABILITADO))
                {
                    tabControl1.TabPages.Remove(tabFeedbackSecundario);
                }
                else
                {
                    LoadGridFeedbackSecundario();
                }

                this.atualizaGridPedidoItemQualidade();

                this.grbCancelamento.Visible = this.Pedido.Status == StatusPedido.Cancelado;
                this.grbOriginais.Visible = this.Pedido.ID != -1;




                this.updateTotalMainItem();

                if (IWTLicensing.ControleLicenciamentoClass.Licenca != null && IWTLicensing.ControleLicenciamentoClass.Licenca.TipoLicenca != "COMPLETO")
                {
                    this.btnVariaveis.Visible = false;

                    this.cbxEntregaParc.Checked = false;
                    this.cbxEntregaParc.Visible = false;

                    this.chkRastrearMP.Checked = false;
                    this.chkRastrearMP.Visible = false;

                    this.cbxVolumeUnico.Checked = false;
                    this.cbxVolumeUnico.Visible = false;

                    this.chkTipoKit.Checked = false;
                    this.chkTipoKit.Visible = false;
                    this.cmbTipoKit.Visible = false;
                    this.label8.Visible = false;

                    this.gbxItem.Visible = false;

                }


                if (IWTConfiguration.Conf.getBoolConf(Constants.EMITENTE_NF_SECUNDARIO_HABILITADO))
                {
                    rdbEmissorNFePrimario.Text = "Principal (" + NotaFiscalFuncoesAuxiliares.CarregaNomeEmpresa(EasiEmissorNFe.Primario) + ")";
                    rdbEmissorNFeSecundario.Text = "Secundário (" + NotaFiscalFuncoesAuxiliares.CarregaNomeEmpresa(EasiEmissorNFe.Secundario) + ")";
                }
                else
                {
                    rdbEmissorNFePrimario.Checked = true;
                    rdbEmissorNFePrimario.Visible = false;
                    rdbEmissorNFeSecundario.Visible = false;
                    iwtLabel5.Visible = false;
                }

                if (!_orcamento)
                {
                    if (IWTConfiguration.Conf.getBoolConf(Constants.TRIBUTACAO_OPERACAO))
                    {
                        ensOperacao.forceDisable();
                        ensOperacao.Visible = false;
                    }
                    else
                    {
                        ensOperacaoCompleta.forceDisable();
                        ensOperacaoCompleta.Visible = false;
                    }
                }
                else
                {
                    ensOperacaoCompleta.forceDisable();
                    ensOperacaoCompleta.Visible = false;
                }

                AjustaEnvioTerceirosTela();


                if (Tipo == TipoForm.PCP && !LoginClass.UsuarioLogado.HasAccess("MODULO_PCP_PEDIDOS_VALORES", AcsTipoAcesso.Escrita))
                {
                    nudValorUnit.Visible = false;
                    nudValorOriginal.Visible = false;
                    lblTotal.Visible = false;
                    label15.Visible = false;
                }



                if (IWTConfiguration.Conf.getBoolConf(Constants.HISTORICO_ALTERACOES_PEDIDO))
                {
                    CarregaHistoricoAlteracoes();
                }

            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDocumentosPedido_Click(object sender, EventArgs e)
        {
            try
            {
                CadPedidoItemDocumentoForm form = new CadPedidoItemDocumentoForm(this.Pedido);
                form.ShowDialog();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkFreteSemResponsavel_CheckedChanged(object sender, EventArgs e)
        {
            grpFreteResponsavel.Enabled = !chkFreteSemResponsavel.Checked;
        }

        private void ensRepresentante_EntityChange(object sender, EventArgs e)
        {
            try
            {
                if (ensRepresentante.EntidadeSelecionada != null)
                {
                    RepresentanteClass rep = (RepresentanteClass)ensRepresentante.EntidadeSelecionada;
                    nudComissaoRepresentante.Value = (Decimal)rep.Comissao;
                }
            }
            catch (Exception a)
            {
                throw new Exception("Erro ao carregar a comissão do Representante selecionado\r\n" + a.Message);
            }
        }

        private void ensVendedor_EntityChange(object sender, EventArgs e)
        {
            try
            {
                if (ensVendedor.EntidadeSelecionada != null)
                {
                    VendedorClass ven = (VendedorClass)ensVendedor.EntidadeSelecionada;
                    nudComissaoVendedor.Value = (Decimal)ven.Comissao;
                }
            }
            catch (Exception a)
            {
                throw new Exception("Erro ao carregar a comissão do Vendedor selecionado\r\n" + a.Message);
            }
        } 

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                SelecionarArquivo();

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
                DeletarArquivo();

            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                DownloadArquivo();

            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFeedbackAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                this.NovoFeedback();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFeedbackOk_Click(object sender, EventArgs e)
        {
            try
            {
                this.NovoFeedbackInserir();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvFeedbacks_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                this.FeedbackSelecionado();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ensCliente_EntityChange(object sender, EventArgs e)
        {
            try
            {
                this.selecionarCliente();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ensItemPrincipal_EntityChange(object sender, EventArgs e)
        {
            try
            {


                if (ensItemPrincipal.EntidadeSelecionada == null) return;

                if (codigoAutomatico)
                {
                    this.txtCodigo.Text = ((ProdutoClass) this.ensItemPrincipal.EntidadeSelecionada).CodigoCliente;
                }

                if (descricaoAutomatica)
                {
                    this.txtDescricao.Text = ((ProdutoClass) this.ensItemPrincipal.EntidadeSelecionada).Descricao;
                }

                if (precoAutomatico)
                {
                    if (((ProdutoClass)this.ensItemPrincipal.EntidadeSelecionada).CalculoPreco_Fixo)
                    {
                        List<ProdutoPrecoClass> precos = ((ProdutoClass)this.ensItemPrincipal.EntidadeSelecionada).CollectionProdutoPrecoClassProduto.Where(
                             a => Configurations.DataIndependenteClass.GetData().Date >= a.InicioVigencia.Date && (!a.FimVigencia.HasValue || Configurations.DataIndependenteClass.GetData().Date <= a.FimVigencia.Value.Date)).ToList();
                        ProdutoPrecoClass preco = null;
                        if (precos.Count == 1)
                        {
                            preco = precos[0];
                        }

                        if (precos.Count > 1)
                        {
                            preco = precos.OrderByDescending(a => a.ID).First();
                        }

                        if (preco != null)
                        {
                            this.nudValorUnit.Value = (decimal)preco.Preco;
                        }
                        else
                        {
                            this.nudValorUnit.Value = 0;
                        }
                    }
                }

                updateNCMPrincipal();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ensSubItem_EntityChange(object sender, EventArgs e)
        {
            try
            {
                if (ensSubItem.EntidadeSelecionada == null) return;

                if (codigoItemAutomatico)
                {
                    this.txtCodigoItem.Text = ((ProdutoClass) this.ensSubItem.EntidadeSelecionada).CodigoCliente;
                }

                if (descricaoItemAutomatica)
                {
                    this.txtDescricaoItem.Text = ((ProdutoClass) this.ensSubItem.EntidadeSelecionada).Descricao;
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ensRepresentante_EnabledChanged(object sender, EventArgs e)
        {
            this.nudComissaoRepresentante.Enabled = this.ensRepresentante.Enabled;
        }

        private void ensVendedor_EnabledChanged(object sender, EventArgs e)
        {
            this.nudComissaoVendedor.Enabled = this.ensVendedor.Enabled;
        }

        private void nudValorUnit_Click(object sender, EventArgs e)
        {
            this.precoAutomatico = false;
        }

        private void nudValorUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.precoAutomatico = false;
        }

        private void chkEnvioTerceiros_CheckedChanged(object sender, EventArgs e)
        {
        try
            {
                AjustaEnvioTerceirosTela();
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

        private void lnkEstrutura_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                EstruturaPrincipal();
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
        
        private void nudDesconto_ValueChanged(object sender, EventArgs e)
        {
             try
            {
                this.updateTotalMainItem();   
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

        protected override void SalvarInterno(IWTPostgreNpgsqlCommand command = null, bool fechar = true)
        {
            this.Pedido.SalvarJustificativa(command);

            base.SalvarInterno(command, fechar);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
        }

        private void btnFeedbackSecundarioAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                this.NovoFeedbackSecundario();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFeedbackSecundarioOk_Click(object sender, EventArgs e)
        {
            try
            {
                this.NovoFeedbackSecundarioInserir();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    
        private void dgvFeedbacksSecundarios_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                this.FeedbackSecundarioSelecionado();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
