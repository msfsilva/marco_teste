using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BibliotecaCentroCusto;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaRepresentantes
{
    public partial class GerarComissoeRepresentantesForm : IWTBaseForm
    {
        private CentroCustoLucroClass CentroCustoLucroSelecionado;

        public GerarComissoeRepresentantesForm()
        {
            InitializeComponent();
            this.loadComboContaBancaria();
            this.loadComboRepresentante();
            this.loadComboVendedor();
        }

        private void loadComboRepresentante()
        {
            try
            {

                RepresentanteClass representante = new RepresentanteClass(LoginClass.UsuarioLogado.loggedUser,this.SingleConnection);
                List<RepresentanteClass> representantes =
                    representante.Search(new List<SearchParameterClass>()
                                             {
                                                 new SearchParameterClass("rep_razao_social", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String)
                                             }).
                        ConvertAll(a => (RepresentanteClass)a);


                this.cmbRepresentante.DataSource = representantes;
                this.cmbRepresentante.DisplayMember = "RazaoSocial";
                this.cmbRepresentante.ValueMember = "ID";
                this.cmbRepresentante.autoSize = true;
                this.cmbRepresentante.Table = representantes;
                this.cmbRepresentante.ColumnsToDisplay = new[] { "RazaoSocial", "Cnpj", "Fone1", "Email" };
                this.cmbRepresentante.HeadersToDisplay = new[] { "Razão Social", "Cnpj", "Fone", "E-mail" };


            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção de Representantes.\r\n" + e.Message);
            }
        }

        private void loadComboVendedor()
        {
            try
            {

                VendedorClass Vendedor = new VendedorClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<VendedorClass> Vendedors =
                    Vendedor.Search(new List<SearchParameterClass>()
                                             {
                                                 new SearchParameterClass("RazaoSocial", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String)
                                             }).
                        ConvertAll(a => (VendedorClass)a);


                this.cmbVendedor.DataSource = Vendedors;
                this.cmbVendedor.DisplayMember = "RazaoSocial";
                this.cmbVendedor.ValueMember = "ID";
                this.cmbVendedor.autoSize = true;
                this.cmbVendedor.Table = Vendedors;
                this.cmbVendedor.ColumnsToDisplay = new[] { "RazaoSocial", "Cnpj", "Fone1", "Email" };
                this.cmbVendedor.HeadersToDisplay = new[] { "Razão Social", "Cnpj", "Fone", "E-mail" };


            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção de Vendedores.\r\n" + e.Message);
            }
        }


        private void loadComboContaBancaria()
        {
            try
            {
                ContaBancariaClass contaBancaria = new ContaBancariaClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<ContaBancariaClass> contasBancarias =
                    contaBancaria.Search(new List<SearchParameterClass>() { new SearchParameterClass("cba_identificacao", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String) }).ConvertAll(a => (ContaBancariaClass)a);


                this.cmbContaBancaria.DataSource = contasBancarias;
                this.cmbContaBancaria.DisplayMember = "Identificacao";
                this.cmbContaBancaria.ValueMember = "ID";
                this.cmbContaBancaria.autoSize = true;
                this.cmbContaBancaria.Table = contasBancarias;
                this.cmbContaBancaria.ColumnsToDisplay = new[] { "Identificacao", "NomeBanco", "Agencia", "NumeroConta", "CodigoBanco" };
                this.cmbContaBancaria.HeadersToDisplay = new[] { "Identificação", "Banco", "Agência", "Conta", "Código Banco" };

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção da Conta Bancária.\r\n" + e.Message);
            }
        }

        private void selecionarCentroCusto()
        {
            try
            {
                SelecaoCentroCustoLucroForm form = new SelecaoCentroCustoLucroForm(CentroCustoLucroNatureza.Custo);
                form.ShowDialog();

                if (form.CentroSelecionado != null)
                {
                    this.txtCentroCusto.Text = form.CentroSelecionado.ToString();
                    this.CentroCustoLucroSelecionado = form.CentroSelecionado;
                }
                else
                {
                    this.CentroCustoLucroSelecionado = null;

                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao selecionar o centro de custo\r\n" + e.Message, e);
            }
        }

        private void Gerar()
        {
            try
            {
                if (MessageBox.Show(this,"Essa operação irá gerar as contas a pagar das comissões pendentes conforme as seleções, deseja continuar?","Geração das Comissões",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
                {
                    return;
                }


                string[] tmp = this.txtMesAno.Text.Split(new string[] {"/"}, StringSplitOptions.RemoveEmptyEntries);
                if (tmp.Length != 2)
                {
                    throw new Exception("O mês e o ano devem ser preenchidos corretamente");
                }
                int mes;
                int ano;
                if (!int.TryParse(tmp[0], out mes) || !int.TryParse(tmp[1], out ano))
                {
                    throw new Exception("O mês e o ano devem ser preenchidos corretamente");
                }

                if (this.cmbRepresentante.Enabled && this.cmbRepresentante.SelectedValue == null)
                {
                    throw new Exception("Selecione o representante ou desabilite o campo para gerar para todos.");
                }

                if (this.cmbVendedor.Enabled && this.cmbVendedor.SelectedValue == null)
                {
                    throw new Exception("Selecione o vendedor ou desabilite o campo para gerar para todos.");
                }

                if (this.cmbContaBancaria.SelectedItem == null)
                {
                    throw new Exception("Selecione a conta bancária antes de gerar.");
                }

                if (CentroCustoLucroSelecionado== null)
                {
                    throw new Exception("Selecione o centro de custo antes de gerar.");
                }

                RepresentanteClass representante = null;
                if (this.cmbRepresentante.Enabled)
                {
                    representante = (RepresentanteClass) this.cmbRepresentante.SelectedItem;
                }

                VendedorClass vendedor = null;
                if (this.cmbVendedor.Enabled)
                {
                    vendedor = (VendedorClass)this.cmbVendedor.SelectedItem;
                }

                ComissaoOperacoesClass.GerarContasPagarComissoes(
                    representante,
                    vendedor,
                    mes,
                    ano,
                    this.dtpVencimento.Value,
                    (ContaBancariaClass) this.cmbContaBancaria.SelectedItem,
                    this.CentroCustoLucroSelecionado,
                    this.SingleConnection
                    );

                MessageBox.Show(this, "Contas geradas com sucesso!", "Geração das Comissões", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();



            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar as contas de comissão.\r\n" + e.Message, e);
            }
        }

        #region Eventos
        private void chkRepresentante_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbRepresentante.Enabled = this.chkRepresentante.Checked;

            if (this.cmbRepresentante.Enabled)
            {
                this.chkVendedor.Checked = false;
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

        private void btnGerar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Gerar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

     

        #endregion

        private void chkVendedor_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbVendedor.Enabled = this.chkVendedor.Checked;

            if (this.cmbVendedor.Enabled)
            {
                this.chkRepresentante.Checked = false;
            }
        }
    }
}
