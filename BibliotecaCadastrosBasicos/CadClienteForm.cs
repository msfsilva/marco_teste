using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BibliotecaCentroCusto;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTPostgreNpgsql;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadClienteForm : IWTForm
    {
        private ClienteClass Cliente
        {
            get { return (ClienteClass) this.Entity; }
        }

        private CentroCustoLucroClass centroCustoSelecionado;

        public CadClienteForm(ClienteClass cliente, CadClienteListForm listForm)
            : base(cliente, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
            iesCidade.FormSelecao = new CadCidadeListForm(BibliotecaControleRevisao.TipoModulo.Tipo);
            iesCidadeSec.FormSelecao = new CadCidadeListForm(BibliotecaControleRevisao.TipoModulo.Tipo);
            ensFormaPagamento.FormSelecao = new CadFormaPagamentoListForm(BibliotecaControleRevisao.TipoModulo.Tipo);
            ensContaBancaria.FormSelecao = new CadContaBancariaListForm(BibliotecaControleRevisao.TipoModulo.Tipo);
            ensFamilia.FormSelecao = new CadFamiliaClienteListForm(BibliotecaControleRevisao.TipoModulo.Tipo);
            ensRepresentante.FormSelecao = new CadRepresentanteListForm(BibliotecaControleRevisao.TipoModulo.Tipo);
            ensVendedor.FormSelecao = new CadVendedorListForm(BibliotecaControleRevisao.TipoModulo.Tipo);
        }

        public CadClienteForm(ClienteClass cliente)
            : base(cliente, typeof (ClienteClass), LoginClass.UsuarioLogado.loggedUser, null)
        {
            InitializeComponent();
            iesCidade.FormSelecao = new CadCidadeListForm(BibliotecaControleRevisao.TipoModulo.Tipo);
            iesCidadeSec.FormSelecao = new CadCidadeListForm(BibliotecaControleRevisao.TipoModulo.Tipo);
            ensFormaPagamento.FormSelecao = new CadFormaPagamentoListForm(BibliotecaControleRevisao.TipoModulo.Tipo);
            ensContaBancaria.FormSelecao = new CadContaBancariaListForm(BibliotecaControleRevisao.TipoModulo.Tipo);
            ensFamilia.FormSelecao = new CadFamiliaClienteListForm(BibliotecaControleRevisao.TipoModulo.Tipo);
            ensRepresentante.FormSelecao = new CadRepresentanteListForm(BibliotecaControleRevisao.TipoModulo.Tipo);
            ensVendedor.FormSelecao = new CadVendedorListForm(BibliotecaControleRevisao.TipoModulo.Tipo);
        }

        protected override void OnShown(EventArgs e)
        {
            if (((ClienteClass) this.Entity).CentroCustoLucro != null)
            {
                this.txtCentroCusto.Text = ((ClienteClass) this.Entity).CentroCustoLucro.ToString();
            }

            if (!string.IsNullOrEmpty(((ClienteClass) this.Entity).Cnpj))
            {
                string tmpCNPJ = ((ClienteClass) this.Entity).Cnpj.Replace("/", "").Replace("-", "").Replace(".", "");
                if (tmpCNPJ.Length == 11)
                {
                    this.rdbPF.Checked = true;
                }
                else
                {
                    this.rdbPJ.Checked = true;
                }
            }



            base.OnShown(e);

            InitializeGridContatosCliente();

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
                    
                    this.txtInscINSS.Enabled = true;
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

                    this.txtInscINSS.Enabled = false;
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
                SelecaoCentroCustoLucroForm form = new SelecaoCentroCustoLucroForm(CentroCustoLucroNatureza.Lucro);
                form.ShowDialog();

                if (form.CentroSelecionado == null)
                {
                    this.chkCentroCusto.Checked = false;
                }
                else
                {
                    this.txtCentroCusto.Text = form.CentroSelecionado.ToString();
                    ((ClienteClass) this.Entity).CentroCustoLucro = form.CentroSelecionado;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao selecionar o centro de custo padrão\r\n" + e.Message, e);
            }
        }

        private void CidadeSecSelecionada()
        {
            try
            {
                ((ClienteClass) this.Entity).Estado = ((CidadeClass) iesCidadeSec.EntidadeSelecionada).Estado;
                ((ClienteClass) this.Entity).Pais = ((CidadeClass) iesCidadeSec.EntidadeSelecionada).Pais.Nome;
                labEstadoSec.Text = ((ClienteClass) this.Entity).Estado.Nome;
                labPaisSec.Text = ((CidadeClass) iesCidadeSec.EntidadeSelecionada).Pais.Nome;
            }
            catch (ExcecaoTratada e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro inesperado ao selecionar a cidade secundária.\r\n" + e.Message, e);
            }
        }

        private void CidadeSelecionada()
        {
            try
            {
                ((ClienteClass) this.Entity).EstadoCob = ((CidadeClass) iesCidade.EntidadeSelecionada).Estado;
                ((ClienteClass) this.Entity).PaisCob = ((CidadeClass) iesCidade.EntidadeSelecionada).Pais.Nome;
                ((ClienteClass) this.Entity).CodigoPaisCob = ((CidadeClass) iesCidade.EntidadeSelecionada).Pais.Codigo;

                labEstadoCob.Text = ((ClienteClass) this.Entity).EstadoCob.Nome;
                labPaisCob.Text = ((CidadeClass) iesCidade.EntidadeSelecionada).Pais.Nome;
                labCodIbge.Text = ((ClienteClass) this.Entity).CodigoPaisCob.ToString();
            }
            catch (ExcecaoTratada e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro inesperado ao selecionar a cidade.\r\n" + e.Message, e);
            }
        }

        #region Contatos do Cliente

        private void InitializeGridContatosCliente()
        {
            try
            {
                this.dgvContatosCliente.DataSource = this.Cliente.CollectionClienteContatoClassCliente;
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

        private void ExcluirClienteContato()
        {
            try
            {
                if (this.dgvContatosCliente.SelectedRows.Count == 0) return;

                if (DialogResult.Yes != MessageBox.Show(this, "Deseja excluir o Contato do Cliente selecionado?", "Exclusão de Contato do Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    return;
                }

                ClienteContatoClass contato = (ClienteContatoClass) ((IWTDataGridViewRow) this.dgvContatosCliente.SelectedRows[0]).DataBoundItem;
                this.Cliente.ExcluirClienteContato(contato);
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao excluir o ClienteContato.\r\n" + e.Message, e);
            }
        }

        private void EditarClienteContato()
        {
            try
            {
                if (this.dgvContatosCliente.SelectedRows.Count == 0) return;

                ClienteContatoClass contato = (ClienteContatoClass) ((IWTDataGridViewRow) this.dgvContatosCliente.SelectedRows[0]).DataBoundItem;
                CadClienteContatoForm form = new CadClienteContatoForm(contato);
                form.ShowDialog(this);

                this.dgvContatosCliente.InvalidateRow(this.dgvContatosCliente.SelectedRows[0].Index);

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

        private void NovoClienteContato()
        {
            ClienteContatoClass contato = new ClienteContatoClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection)
            {
                Cliente = this.Cliente
            };
            CadClienteContatoForm form = new CadClienteContatoForm(contato);
            form.ShowDialog(this);

            if (form.salvar)
            {
                this.Cliente.AdicionarClienteContato(contato);
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
                ((ClienteClass) this.Entity).Ie = txtIE.Text;
            }
            else
            {
                txtIE.Text = "";
                txtIE.Enabled = true;
            }
        }

        #region Eventos

        private void btnCopyEndCob_Click(object sender, EventArgs e)
        {
            this.txtEnderecoSec.Text = this.txtEnderecoCob.Text;
            this.txtNumeroSec.Text = this.txtNumeroCob.Text;
            this.txtComplementoSec.Text = this.txtComplementoCob.Text;
            this.txtBairroSec.Text = this.txtBairroCob.Text;
            this.txtCepSec.Text = this.txtCepCob.Text;
            this.labEstadoSec.Text = ((ClienteClass) this.Entity).EstadoCob.ToString();
            this.labPaisSec.Text = this.labPaisCob.Text;
            this.iesCidadeSec.EntidadeSelecionada = ((ClienteClass) this.Entity).CidadeCob;
        }



        private void ensFamilia_EntityChange(object sender, EventArgs e)
        {
            try
            {
                if (this.ensFamilia.EntidadeSelecionada != null)
                {

                    if (((FamiliaClienteClass) this.ensFamilia.EntidadeSelecionada).TipoEspecial == TipoFamiliaEspecial.EASSA)
                    {
                        this.chkControleEspecialCliente.Enabled = true;
                    }
                    else
                    {
                        this.chkControleEspecialCliente.Enabled = false;
                        this.chkControleEspecialCliente.Checked = false;
                    }
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

        private void chkCentroCusto_CheckedChanged(object sender, EventArgs e)
        {
            this.btnCentroCusto.Enabled = this.chkCentroCusto.Checked;
            if (!this.chkCentroCusto.Checked)
            {
                this.centroCustoSelecionado = null;
                this.txtCentroCusto.Clear();
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

        private void chkEnvioEmail_CheckedChanged(object sender, EventArgs e)
        {
            grpEnvioEmails.Enabled = chkEnvioEmail.Checked;
        }

        private void chkComissaoRepresentante_CheckedChanged(object sender, EventArgs e)
        {
            nudComissaoRepresentante.Enabled = chkComissaoRepresentante.Checked;
        }

        private void chkComissaoVendedor_CheckedChanged(object sender, EventArgs e)
        {
            nudComissaoVendedor.Enabled = chkComissaoVendedor.Checked;
        }

        private void iesCidade_EntityChange(object sender, EventArgs e)
        {
            try
            {
                CidadeSelecionada();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void iesCidadeSec_EntityChange(object sender, EventArgs e)
        {
            try
            {
                CidadeSecSelecionada();
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
                NovoClienteContato();
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
                EditarClienteContato();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnContatoExcluir_Click(object sender, EventArgs e)
        {
            ExcluirClienteContato();
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


        protected override void Salvar(IWTPostgreNpgsqlCommand command = null)
        {
            
            if (!string.IsNullOrWhiteSpace(Cliente.Email))
            {
                if (!IWTFunctions.IWTFunctions.ValidaEmail(Cliente.Email))
                {
                    throw new ExcecaoTratada("Email inválido, o(s) email(s) devem ser válidos e separados por ; ");
                }
            }

            if (!string.IsNullOrWhiteSpace(Cliente.Email))
            {
                if (!IWTFunctions.IWTFunctions.ValidaEmail(Cliente.Email))
                {
                    throw new ExcecaoTratada("Email inválido, o(s) email(s) devem ser válidos e separados por ; ");
                }
            }

            if (!string.IsNullOrWhiteSpace(Cliente.EmailDanfe))
            {
                if (!IWTFunctions.IWTFunctions.ValidaEmail(Cliente.EmailDanfe))
                {
                    throw new ExcecaoTratada("Email para envio da Danfe, o(s) email(s) devem ser válidos e separados por ; ");
                }
            }

            if (!string.IsNullOrWhiteSpace(Cliente.EmailOrcamento))
            {
                if (!IWTFunctions.IWTFunctions.ValidaEmail(Cliente.EmailOrcamento))
                {
                    throw new ExcecaoTratada("Email para envio do orçamento inválido, o(s) email(s) devem ser válidos e separados por ; ");
                }
            }

            if (!string.IsNullOrWhiteSpace(Cliente.EmailPedido))
            {
                if (!IWTFunctions.IWTFunctions.ValidaEmail(Cliente.EmailPedido))
                {
                    throw new ExcecaoTratada("Email para envio do pedido inválido, o(s) email(s) devem ser válidos e separados por ; ");
                }
            }

            if (!string.IsNullOrWhiteSpace(Cliente.EmailXml))
            {
                if (!IWTFunctions.IWTFunctions.ValidaEmail(Cliente.EmailXml))
                {
                    throw new ExcecaoTratada("Email para envio do XML inválido, o(s) email(s) devem ser válidos e separados por ; ");
                }
            }

            base.Salvar(command);
        }

    }
}
