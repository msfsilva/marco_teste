using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BibliotecaCentroCusto;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using Configurations;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using ProjectConstants;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadFornecedorForm : IWTForm
    {
        FornecedorClass Fornecedor
        {
            get { return (FornecedorClass) this.Entity; }
        }


        public CadFornecedorForm(FornecedorClass fornecedor, CadFornecedorListForm listForm)
            : base(fornecedor, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
            this.iesCidade.FormSelecao = new CadCidadeListForm(BibliotecaControleRevisao.TipoModulo.Tipo);
        }




        private void loadComboFormaPagto()
        {
            try
            {
                FormaPagamentoClass formaPagamento = new FormaPagamentoClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<FormaPagamentoClass> formasPagamento =
                    formaPagamento.Search(new List<SearchParameterClass>() {new SearchParameterClass("fop_identificacao", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String)}).ConvertAll(a => (FormaPagamentoClass) a);


                this.cmbFormaPagto.DataSource = formasPagamento;
                this.cmbFormaPagto.DisplayMember = "Identificacao";
                this.cmbFormaPagto.ValueMember = "ID";
                this.cmbFormaPagto.autoSize = true;
                this.cmbFormaPagto.Table = formasPagamento;
                this.cmbFormaPagto.ColumnsToDisplay = new[] {"Identificacao", "Descricao"};
                this.cmbFormaPagto.HeadersToDisplay = new[] {"Identificação", "Descrição"};


            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao carregar os dados para seleção da Forma de Pagamento.\r\n" + e.Message);
            }
        }

        private void loadComboContaBancaria()
        {
            try
            {
                ContaBancariaClass contaBancaria = new ContaBancariaClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<ContaBancariaClass> contasBancarias =
                    contaBancaria.Search(new List<SearchParameterClass>() {new SearchParameterClass("cba_identificacao", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String)}).ConvertAll(a => (ContaBancariaClass) a);


                this.cmbContaBancaria.DataSource = contasBancarias;
                this.cmbContaBancaria.DisplayMember = "Identificacao";
                this.cmbContaBancaria.ValueMember = "ID";
                this.cmbContaBancaria.autoSize = true;
                this.cmbContaBancaria.Table = contasBancarias;
                this.cmbContaBancaria.ColumnsToDisplay = new[] {"Identificacao", "NomeBanco", "Agencia", "NumeroConta", "CodigoBanco"};
                this.cmbContaBancaria.HeadersToDisplay = new[] {"Identificação", "Banco", "Agência", "Conta", "Código Banco"};

            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao carregar os dados para seleção da Conta Bancária.\r\n" + e.Message);
            }
        }

        private void defineTipoPessoa()
        {
            try
            {
                if (this.rdbPJ.Checked)
                {
                    #region PJ

                    this.lblCNPJ.Text = "CNPJ";
                    this.grbIE.Enabled = true;

                    this.txtInscMunicipal.Enabled = true;

                    this.txtCNPJ.Mask = @"00\.000\.000\/0000\-00";

                    #endregion
                }
                else
                {
                    #region PF

                    this.lblCNPJ.Text = "CPF";
                    this.rdbNaoContribuinte.Checked = true;

                    this.grbIE.Enabled = false;

                    this.txtInscMunicipal.Enabled = false;

                    this.txtCNPJ.Mask = @"000\.000\.000\-00";

                    #endregion
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao definir o tipo de pessoa.\r\n" + e.Message, e);
            }
        }

        private void selecionarCentroCusto()
        {
            try
            {
                SelecaoCentroCustoLucroForm form = new SelecaoCentroCustoLucroForm(CentroCustoLucroNatureza.Custo);
                form.ShowDialog();

                if (form.CentroSelecionado == null)
                {
                    this.chkCentroCusto.Checked = false;
                }
                else
                {
                    this.txtCentroCusto.Text = form.CentroSelecionado.ToString();
                    ((FornecedorClass) this.Entity).CentroCustoLucro = form.CentroSelecionado;
                }
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao selecionar o centro de custo padrão\r\n" + e.Message, e);
            }
        }

        private void HabilitaDesabilitaCampos()
        {
            try
            {
                if (this.cbxEstrangeiro.Checked)
                {
                    this.rdbIsento.Checked = true;
                }

                this.gbxTipoPessoa.Enabled = !this.cbxEstrangeiro.Checked;
                this.txtCNPJ.Enabled = !this.cbxEstrangeiro.Checked;
                this.txtIE.Enabled = !this.cbxEstrangeiro.Checked;
                this.grbIE.Enabled = !this.cbxEstrangeiro.Checked;
                this.txtInscMunicipal.Enabled = !this.cbxEstrangeiro.Checked;
            }
            catch (ExcecaoTratada e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro inesperado ao ajustar a tela.\r\n" + e.Message, e);
            }
        }

        private void MostraEstado()
        {
            try
            {
                if (iesCidade.EntidadeSelecionada != null)
                {
                    ((FornecedorClass) this.Entity).Estado = ((CidadeClass) iesCidade.EntidadeSelecionada).Estado;
                    ((FornecedorClass) this.Entity).Pais = ((CidadeClass) iesCidade.EntidadeSelecionada).Pais.Nome;
                    ((FornecedorClass)this.Entity).CodigoPais = ((CidadeClass)iesCidade.EntidadeSelecionada).Pais.Codigo;

                    labEstado.Text = ((FornecedorClass) this.Entity).Estado.ToString();
                    labPais.Text = ((FornecedorClass) this.Entity).Pais;
                }
                else
                {
                    ((FornecedorClass) this.Entity).Estado = null;
                    ((FornecedorClass) this.Entity).Pais = null;
                    ((FornecedorClass) this.Entity).CodigoPais = null;
                    labEstado.Text = "";
                    labPais.Text = "";

                }
            }
            catch (ExcecaoTratada e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro inesperado ao identificar o estado.\r\n" + e.Message, e);
            }
        }


        #region Contatos do Fornecedor

        private void InitializeGridContatosFornecedor()
        {
            try
            {
                this.dgvContatosFornecedor.DataSource = this.Fornecedor.CollectionFornecedorContatoClassFornecedor;
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao montar a listagem de animais\r\n" + e.Message, e);
            }
        }

        private void ExcluirFornecedorContato()
        {
            try
            {
                if (this.dgvContatosFornecedor.SelectedRows.Count == 0) return;

                if (DialogResult.Yes != MessageBox.Show(this, "Deseja excluir o Contato do Fornecedor selecionado?", "Exclusão de Contato do Fornecedor", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    return;
                }

                FornecedorContatoClass contato = (FornecedorContatoClass)((IWTDataGridViewRow)this.dgvContatosFornecedor.SelectedRows[0]).DataBoundItem;
                this.Fornecedor.ExcluirFornecedorContato(contato);
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao excluir o FornecedorContato.\r\n" + e.Message, e);
            }
        }

        private void EditarFornecedorContato()
        {
            try
            {
                if (this.dgvContatosFornecedor.SelectedRows.Count == 0) return;

                FornecedorContatoClass contato = (FornecedorContatoClass)((IWTDataGridViewRow)this.dgvContatosFornecedor.SelectedRows[0]).DataBoundItem;
                CadFornecedorContatoForm form = new CadFornecedorContatoForm(contato);
                form.ShowDialog(this);

                this.dgvContatosFornecedor.InvalidateRow(this.dgvContatosFornecedor.SelectedRows[0].Index);

                if (form.salvar)
                {
                    contato.setAlterado();
                }

            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao editar o contato.\r\n" + e.Message, e);
            }
        }

        private void NovoFornecedorContato()
        {
            FornecedorContatoClass contato = new FornecedorContatoClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection)
            {
                Fornecedor = this.Fornecedor
            };
            CadFornecedorContatoForm form = new CadFornecedorContatoForm(contato);
            form.ShowDialog(this);

            if (form.salvar)
            {
                this.Fornecedor.AdicionarFornecedorContato(contato);
                contato.setAlterado();
            }
        }

        #endregion

        private void DefineTipoIE()
        {
            if (this.rdbIsento.Checked)
            {
                txtIE.Text = "ISENTO";
                txtIE.Enabled = false;
                ((FornecedorClass)this.Entity).InscEstadual = txtIE.Text;
            }
            else
            {
                txtIE.Text = "";
                txtIE.Enabled = true;
            }
        }

        #region eventos


        private void rdbPF_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.defineTipoPessoa();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbPJ_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.defineTipoPessoa();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCentroCusto_Click(object sender, EventArgs e)
        {
            try
            {
                this.selecionarCentroCusto();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkContaBancaria_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbContaBancaria.Enabled = this.chkContaBancaria.Checked;
        }

        private void chkCentroCusto_CheckedChanged(object sender, EventArgs e)
        {
            this.btnCentroCusto.Enabled = this.chkCentroCusto.Checked;
            if (!this.chkCentroCusto.Checked)
            {
                //this.centroCustoSelecionado = null;
                this.txtCentroCusto.Clear();
            }
        }

        private void cbxFormaPagto_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbFormaPagto.Enabled = this.cbxFormaPagto.Checked;
        }

        private void chkEnvioEmail_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = this.chkEnvioEmail.Checked;
        }

      

        protected override void OnShown(EventArgs e)
        {
            this.loadComboContaBancaria();
            this.loadComboFormaPagto();

            if (((FornecedorClass) this.Entity).CentroCustoLucro != null)
            {
                this.txtCentroCusto.Text = ((FornecedorClass) this.Entity).CentroCustoLucro.ToString();
            }

            if (!string.IsNullOrEmpty(((FornecedorClass) this.Entity).Cnpj))
            {
                string tmpCNPJ = ((FornecedorClass) this.Entity).Cnpj.Replace("/", "").Replace("-", "").Replace(".", "");
                if (tmpCNPJ.Length == 11)
                {
                    this.rdbPF.Checked = true;
                }
                else
                {
                    this.rdbPJ.Checked = true;
                }
            }

            if (this.Fornecedor.ID == -1 && IWTConfiguration.Conf.getBoolConf(Constants.COMPRA_REVISAR_NOVOS_FORNEC))
            {
                this.Fornecedor.ContaRevisarRecebimento = true;
            }

            base.OnShown(e);

            InitializeGridContatosFornecedor();

        }

        private void iwtCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                HabilitaDesabilitaCampos();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void iesCidade_EntityChange(object sender, EventArgs e)
        {
            try
            {
                MostraEstado();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnContatoNovo_Click(object sender, EventArgs e)
        {
            try
            {
                NovoFornecedorContato();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnContatoEditar_Click(object sender, EventArgs e)
        {
            try
            {
                EditarFornecedorContato();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnContatoExcluir_Click(object sender, EventArgs e)
        {
            ExcluirFornecedorContato();
        }

        private void rdbContribuinte_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                DefineTipoIE();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbIsento_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                DefineTipoIE();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbNaoContribuinte_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                DefineTipoIE();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

    }
}
