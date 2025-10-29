using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using BibliotecaCadastrosBasicos;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using Configurations;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using dbProvider;
using ProjectConstants;
using SolicitacaoCompraClass = BibliotecaEntidades.Entidades.SolicitacaoCompraClass;

namespace BibliotecaCompras
{
    public partial class OCEditForm : IWTBaseForm
    {
        BibliotecaEntidades.Entidades.OrdemCompraClass ordemCompra;

        internal bool NecessitaAprovacao { get; private set; }

        public OCEditForm(int idOrdemCompra)
        {
            InitializeComponent();

            this.InitializeEdit(idOrdemCompra);

            this.ensFormaPagto.FormSelecao = new CadFormaPagamentoListForm(TipoModulo.Tipo);
            this.ensFornecedor.FormSelecao = new CadFornecedorListForm(TipoModulo.Tipo);
            
        }

     
        private void InitializeEdit(int idOrdemCompra)
        {
            try
            {
                this.ordemCompra = BibliotecaEntidades.Entidades.OrdemCompraClass.GetEntidade(idOrdemCompra, LoginClass.UsuarioLogado.loggedUser, SingleConnection);
                this.ensFornecedor.EntidadeSelecionada = this.ordemCompra.Fornecedor;

                this.Text += " nº " + idOrdemCompra;
                
                this.txtComprasEmailTexto.Text = this.ordemCompra.MsgEmail;
                this.txtComprasRodape.Text = this.ordemCompra.Rodape;
                this.txtObservacao.Text = this.ordemCompra.Observacao;
                this.ensFormaPagto.EntidadeSelecionada = this.ordemCompra.FormaPagamento;

                this.InitializeGrid();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregas os dados para a tela.\r\n" + e.Message, e);
            }
        }

        private void InitializeGrid()
        {
            try
            {
                if (this.ordemCompra.Status.Equals(StatusOrdemCompra.Enviada) || this.ordemCompra.Status.Equals(StatusOrdemCompra.RecebidaParcial))
                {
                    this.ensFormaPagto.Enabled = false;
                    this.btnRemoverItenSelecionado.Enabled = false;
                    this.ensFornecedor.Enabled = false;
                    this.txtObservacao.Enabled = false;
                    this.txtComprasRodape.Enabled = false;
                    this.txtComprasEmailTexto.Enabled = false;
                }

                this.dataGridView1.AutoGenerateColumns = false;
                this.dataGridView1.Columns.Clear();
                
                this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "NumeroLinhaOc";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].Name = "linhaOC";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Nº Linha";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "ID";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].Name = "idSolicitacaoCompra";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Nº Solicitação";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "CodigoItem";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].Name = "codigoProdutoMaterial";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Produto/Material";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                
                this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "UnidadeCompra";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].Name = "unidadeCompraProdutoMaterial";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Unidade de Compra";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                
                this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "Qtd";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].Name = "Quantidade";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Quantidade";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                
                this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "ValorUnitarioOc";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].Name = "ValorUnitarioCompra";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Valor Unitário";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DefaultCellStyle.Format = "C4";

                this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "ValorTotalOc";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].Name = "ValorTotalCompra";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Valor Total Bruto";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DefaultCellStyle.Format = "C4";
                
                this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "ValorComDesconto";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].Name = "ValorComDesconto";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Valor Total Com Desconto";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DefaultCellStyle.Format = "C4";

                this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "ValorTotalOcComImpostos";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].Name = "ValorTotalCompraComImpostos";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Total com Impostos";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DefaultCellStyle.Format = "C4";

                this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "AliquotaIcmsOc";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].Name = "AliquotaICMSCompra";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "ICMS";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DefaultCellStyle.Format = "0.00\\%";
                
                this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "AliquotaIpiOc";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].Name = "AliquotaIPICompra";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "IPI";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DefaultCellStyle.Format = "0.00\\%";
                
                this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "EntregaPrevista";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].Name = "EntregaPrevista";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Entrega Prevista";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DefaultCellStyle.Format = "dd/MM/yyyy";

                this.dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn());
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "NaoAtualizaPrecoRecebimento";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].Name = "NaoAtualizaPrecoRecebimento";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Não Atualiza Preço no Recebimento";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


                this.dataGridView1.DataSource = this.ordemCompra.CollectionSolicitacaoCompraClassOrdemCompra;
                
                AtualizarTotais();


            }
            catch (Exception e)
            {
                throw new Exception("Erro ao inicializar o grid de solicitações\r\n" + e.Message, e);
            }
        }
        
        private void AtualizarTotais()
        {

            this.ordemCompra.RecalcularTotais();

            this.lblValorTotal.Text = this.ordemCompra.Valor.ToString("C2", CultureInfo.CurrentCulture);
            this.lblValorTotalDesconto.Text = this.ordemCompra.ValorFinalComDesconto().ToString("C2", CultureInfo.CurrentCulture);
            this.lblValorTotalImpostos.Text = this.ordemCompra.ValorComImpostos.ToString("C2", CultureInfo.CurrentCulture);

        }

        private void Salvar()
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                this.verificarNecessidadeAprovacao();

                this.ordemCompra.SetFornecedor((FornecedorClass) this.ensFornecedor.EntidadeSelecionada);

                this.ordemCompra.SetMensagens(this.txtComprasEmailTexto.Text, this.txtComprasRodape.Text);

                this.ordemCompra.SetFormaPagamento((FormaPagamentoClass) this.ensFormaPagto.EntidadeSelecionada);
                this.ordemCompra.SetObservacao(this.txtObservacao.Text);

                command = DbConnection.Connection.CreateCommand();
                command.Transaction = command.Connection.BeginTransaction();
                if (IWTConfiguration.Conf.getBoolConf(Constants.FLUXO_APROVACAO_COMPRAS_HABILITADO) &&
                IWTConfiguration.Conf.getBoolConf(Constants.SIMULADOR_COMPRAS_HABILITADO) && this.NecessitaAprovacao)
                {
                    OrdemCompraClass.GerarAprovacao(this.ordemCompra, LoginClass.UsuarioLogado.loggedUser, SingleConnection, ref command);
                    ordemCompra.Status = StatusOrdemCompra.AguardandoAprovacaoCompras;
                }
                this.ordemCompra.Save(ref command);

                command.Transaction.Commit();

                MessageBox.Show(this, "OC alterada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); 

            }
            catch (Exception e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }

                throw new Exception("Erro ao salvar\r\n" + e.Message, e);
            }
        }

        private void verificarNecessidadeAprovacao()
        {
            if ((!this.ordemCompra.Status.Equals(StatusOrdemCompra.Enviada) && !this.ordemCompra.Status.Equals(StatusOrdemCompra.RecebidaParcial)) &&
                (!this.ordemCompra.Fornecedor.ID.Equals(this.ensFornecedor.EntidadeSelecionada.ID) ||
                !this.ordemCompra.MsgEmail.Equals(this.txtComprasEmailTexto.Text) ||
                !this.ordemCompra.Rodape.Equals(this.txtComprasRodape.Text) ||
                !this.ordemCompra.FormaPagamento.ID.Equals(this.ensFormaPagto.EntidadeSelecionada.ID) ||
                !this.ordemCompra.Observacao.Equals(this.txtObservacao.Text))
                )
            {
                NecessitaAprovacao = true;
            }
        }

        private void Remover()
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show(this, "Essa operação irá remover a solicitação de compra da OC e retorna-la para o status de nova. Deseja Continuar", "Remoção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {


                        this.ordemCompra.RemoverLinha((BibliotecaEntidades.Entidades.SolicitacaoCompraClass) ((IWTDataGridViewRow)(dataGridView1.SelectedRows[0])).DataBoundItem);
                        

                        this.InitializeGrid();
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao remover a linha.\r\n" + e.Message, e);
            }
        }

        private void Editar()
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {

                    //int id = (int)this.dataGridView1.SelectedRows[0].Cells["idSolicitacaoCompra"].Value;
                    BibliotecaEntidades.Entidades.SolicitacaoCompraClass sol = (BibliotecaEntidades.Entidades.SolicitacaoCompraClass) ((IWTDataGridViewRow)dataGridView1.SelectedRows[0]).DataBoundItem;

                    double valorUnitarioCompra = 0;
                    double aliquotaICMS = 0;
                    double aliquotaIPI = 0;
                    StatusSolicitacaoCompra status = StatusSolicitacaoCompra.Nova;
                    DateTime DataPrevista = DateTime.Now;
                    bool naoAtualizaPrecoRecebimento = false;

                    if (sol.ValorUnitarioOc.HasValue)
                    {
                        valorUnitarioCompra = sol.ValorUnitarioOc.Value;
                    }

                    if (sol.AliquotaIcmsOc.HasValue)
                    {
                        aliquotaICMS = sol.AliquotaIcmsOc.Value;
                    }

                    if (sol.AliquotaIpiOc.HasValue)
                    {
                        aliquotaIPI = sol.AliquotaIpiOc.Value;
                    }

                    if (sol.Status.HasValue)
                    {
                        status = sol.Status.Value;
                    }

                    if (sol.EntregaPrevista.HasValue)
                    {
                        DataPrevista = sol.EntregaPrevista.Value;
                    }
                    if (sol.NaoAtualizaPrecoRecebimento)
                    {
                        naoAtualizaPrecoRecebimento = sol.NaoAtualizaPrecoRecebimento;
                    }

                    OCEditLinhaForm form = new OCEditLinhaForm(
                        sol.CodigoItem,
                        valorUnitarioCompra,
                        aliquotaICMS,
                        aliquotaIPI,
                        sol.Qtd??0,
                        ordemCompra.Status,
                        DataPrevista,
                        naoAtualizaPrecoRecebimento
                        );

                    form.ShowDialog();
                    sol.AtualizarDadosCompra(form.ValorUnitario, form.AliquotaIcms, form.AliquotaIpi, form.EntregaPrevista, form.NaoAtualizaPrecoRecebimento);
                    if ((!this.ordemCompra.Status.Equals(StatusOrdemCompra.Enviada) && !this.ordemCompra.Status.Equals(StatusOrdemCompra.RecebidaParcial)) && !this.NecessitaAprovacao)
                    {
                        this.NecessitaAprovacao = form.ScChanged;
                    }
                    this.ordemCompra.RecalcularTotais();

                    this.dataGridView1.InvalidateRow(dataGridView1.SelectedRows[0].Index);
                    AtualizarTotais();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao editar a linha.\r\n" + e.Message, e);
            }
        }
        
        #region Eventos
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                this.Salvar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnRemoverItenSelecionado_Click(object sender, EventArgs e)
        {
            try
            {
                this.Remover();
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
        #endregion
    }
}
