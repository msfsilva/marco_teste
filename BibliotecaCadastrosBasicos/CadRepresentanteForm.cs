using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BibliotecaCentroCusto;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadRepresentanteForm : IWTForm
    {
        public CadRepresentanteForm(RepresentanteClass entidade, CadRepresentanteListForm listForm)
            : base(entidade, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
        }

        public CadRepresentanteForm(RepresentanteClass entidade)
            : base(entidade, typeof(RepresentanteClass), LoginClass.UsuarioLogado.loggedUser, null)
        {
            InitializeComponent();
            
        }


        protected override void OnShown(EventArgs e)
        {
            loadComboCidade();
            loadComboContaBancaria();

            if (((RepresentanteClass)this.Entity).CentroCustoLucro != null)
            {
                this.txtCentroCusto.Text = ((RepresentanteClass)this.Entity).CentroCustoLucro.ToString();
            }

            if (!string.IsNullOrEmpty(((RepresentanteClass)this.Entity).Cnpj))
            {
                string tmpCNPJ = ((RepresentanteClass)this.Entity).Cnpj.Replace("/", "").Replace("-", "").Replace(".", "");
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

        }


        private void loadComboCidade()
        {
            try
            {

                CidadeClass cidade = new CidadeClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<CidadeClass> cidades =
                    cidade.Search(new List<SearchParameterClass>()
                                            {
                                                new SearchParameterClass("cid_nome", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String)
                                            }).
                        ConvertAll(a => (CidadeClass)a);


                this.cmbCidade.DataSource = cidades;
                this.cmbCidade.DisplayMember = "Nome";
                this.cmbCidade.ValueMember = "ID";
                this.cmbCidade.autoSize = true;
                this.cmbCidade.Table = cidades;
                this.cmbCidade.ColumnsToDisplay = new[] { "Nome", "Estado", "CodigoIbge" };
                this.cmbCidade.HeadersToDisplay = new[] { "Nome", "Estado", "Código IBGE" };

                
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção da Cidade.\r\n" + e.Message);
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

                if (form.CentroSelecionado == null)
                {
                    this.txtCentroCusto.Text = "";
                    ((RepresentanteClass)this.Entity).CentroCustoLucro = null;
                }
                else
                {
                    this.txtCentroCusto.Text = form.CentroSelecionado.ToString();
                    ((RepresentanteClass)this.Entity).CentroCustoLucro = form.CentroSelecionado;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao selecionar o centro de custo padrão\r\n" + e.Message, e);
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
                    this.chkIsentoIE.Enabled = true;
                    this.txtInscMunicipal.Enabled = true;

                    this.txtCNPJ.Mask = @"00\.000\.000\/0000\-00";

                    #endregion
                }
                else
                {
                    #region PF
                    this.lblCNPJ.Text = "CPF";
                    this.chkIsentoIE.Enabled = false;
                    this.chkIsentoIE.Checked = true;
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

        #region Eventos


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

        private void chkIsentoIE_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsentoIE.Checked == true)
            {
                txtIE.Text = "ISENTO";
                txtIE.Enabled = false;
                ((RepresentanteClass)this.Entity).InscricaoEstadual = txtIE.Text;
            }
            else
            {
                txtIE.Text = "";
                txtIE.Enabled = true;
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


        #endregion




    }
}
