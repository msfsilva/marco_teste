using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadTransporteForm : IWTForm
    {
        public CadTransporteForm(TransporteClass transporte, CadTransporteListForm listForm)
            : base(transporte, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
            this.iesCidade.FormSelecao = new CadCidadeListForm(BibliotecaControleRevisao.TipoModulo.Tipo);
            this.iesEstadoVeiculo.FormSelecao = new CadEstadoListForm();
        }

        public CadTransporteForm(TransporteClass transporte):base(transporte, typeof(TransporteClass), LoginClass.UsuarioLogado.loggedUser,null)
        {
            InitializeComponent();
            this.iesCidade.FormSelecao = new CadCidadeListForm(BibliotecaControleRevisao.TipoModulo.Tipo);
            this.iesEstadoVeiculo.FormSelecao = new CadEstadoListForm();
        }


        protected override void OnShown(EventArgs e)
        {
           // this.loadComboUF();

            if (this.Entity != null)
            {
                if (!string.IsNullOrEmpty(((TransporteClass)this.Entity).CpfCnpj))
                {
                    string tmpCNPJ = ((TransporteClass) this.Entity).CpfCnpj.Replace("/", "").Replace("-", "").Replace(".", "");
                    if (tmpCNPJ.Length == 11)
                    {
                        this.rdbPF.Checked = true;
                    }
                    else
                    {
                        this.rdbPJ.Checked = true;
                    }
                }
            }


            base.OnShown(e);

        }


/*
        private void loadComboUF()
        {
            try
            {
                EstadoClass estado = new EstadoClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<EstadoClass> estados =
                    estado.Search(new List<SearchParameterClass>() { new SearchParameterClass("est_nome", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String) }).ConvertAll(a => (EstadoClass)a);

                //UF do Transporte
                this.cmbUf.DataSource = estados;
                this.cmbUf.DisplayMember = "Nome";
                this.cmbUf.ValueMember = "ID";
                this.cmbUf.autoSize = true;
                this.cmbUf.Table = estados;
                this.cmbUf.ColumnsToDisplay = new[] { "Nome", "Sigla" };
                this.cmbUf.HeadersToDisplay = new[] { "Nome", "Sigla" };

                EstadoClass estadoVeiculo = new EstadoClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<EstadoClass> estadosVeiculos =
                    estadoVeiculo.Search(new List<SearchParameterClass>() { new SearchParameterClass("est_nome", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String) }).ConvertAll(a => (EstadoClass)a);


                //UF de veículos
                this.cmbUfVeiculo.DataSource = estadosVeiculos;
                this.cmbUfVeiculo.DisplayMember = "Nome";
                this.cmbUfVeiculo.ValueMember = "ID";
                this.cmbUfVeiculo.autoSize = true;
                this.cmbUfVeiculo.Table = estadosVeiculos;
                this.cmbUfVeiculo.ColumnsToDisplay = new[] { "Nome", "Sigla" };
                this.cmbUfVeiculo.HeadersToDisplay = new[] { "Nome", "Sigla" };


            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção de Estados.\r\n" + e.Message);
            }
        }
        private void loadComboCidade()
        {
            try
            {
                int id = 0;
                if (((TransporteClass)this.Entity).Cidade != null)
                {
                    id = ((TransporteClass)this.Entity).Cidade.ID;
                }
                if (this.cmbUf.SelectedItem != null)
                {
                    CidadeClass cidade = new CidadeClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                    List<CidadeClass> cidades =
                        cidade.Search(new List<SearchParameterClass>()
                                             {
                                                 new SearchParameterClass("Estado",
                                                                          (EstadoClass) this.cmbUf.SelectedItem)
                                             }).
                            ConvertAll(a => (CidadeClass)a);


                    this.cmbCidade.DataSource = cidades;
                    this.cmbCidade.DisplayMember = "Nome";
                    this.cmbCidade.ValueMember = "ID";
                    this.cmbCidade.autoSize = true;
                    this.cmbCidade.Table = cidades;
                    this.cmbCidade.ColumnsToDisplay = new[] { "Nome", "Estado", "CodigoIbge" };
                    this.cmbCidade.HeadersToDisplay = new[] { "Nome", "Estado", "Código IBGE" };

                    cmbCidade.SelectedValue = id;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção da Cidade de Cobrança.\r\n" + e.Message);
            }
        }
        */
        private void defineTipoPessoa()
        {
            try
            {
                if (this.rdbPJ.Checked)
                {
                    #region PJ

                    this.lblRazao.Text = "Razão";
                    txtIe.Enabled = true;
                    this.lblCNPJ.Text = "CNPJ";
                    this.txtCNPJ.Mask = @"00\.000\.000\/0000\-00";

                    #endregion
                }
                else
                {
                    #region PF

                    this.txtIe.Text = "";
                    this.txtIe.Enabled = false;
                    this.lblRazao.Text = "Nome";
                    this.lblCNPJ.Text = "CPF";
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
        /*
        private void cmbUf_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadComboCidade();
        }
        */
        private void rdbPF_CheckedChanged(object sender, EventArgs e)
        {
            defineTipoPessoa();
        }

        private void rdbPJ_CheckedChanged(object sender, EventArgs e)
        {
            defineTipoPessoa();
        }

        #endregion

        private void iesCidade_EntityChange(object sender, EventArgs e)
        {
            try
            {
                SelecionaCidade();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SelecionaCidade()
        {
            try
            {
                this.labEstado.Text = ((CidadeClass) this.iesCidade.EntidadeSelecionada).Estado.ToString();
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
    }
}
