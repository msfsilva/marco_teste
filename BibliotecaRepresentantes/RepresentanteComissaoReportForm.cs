using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Entidades;
using Configurations;
using CrystalDecisions.Shared;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule;
using ProjectConstants;

namespace BibliotecaRepresentantes
{
    public partial class RepresentanteComissaoReportForm : IWTBaseForm
    {
        public RepresentanteComissaoReportForm()
        {
            InitializeComponent();
            this.crystalReportViewer1.ShowLogo = false;
            this.loadComboRepresentante();
            this.loadComboVendedor();


            switch (ControleComissao.Modo)
            {
                case ModoControleComissao.Pedido:
                    this.lblAvisoModoComissao.Text = "As comissões serão exibidas levando como data base a data de entrada do pedido, e como valor base o valor total do pedido.";
                    break;
                case ModoControleComissao.Faturamento:
                    this.lblAvisoModoComissao.Text = "As comissões serão exibidas levando como data base a data de faturamento, e como valor base o valor dos faturamentos realizados.";
                    break;
                case ModoControleComissao.ContaReceber:
                    this.lblAvisoModoComissao.Text = "As comissões serão exibidas levando como data base a data de pagamento das contas a receber do pedido, e como valor base o valor das conta a receber.";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void loadComboRepresentante()
        {
            try
            {

                RepresentanteClass representante = new RepresentanteClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<RepresentanteClass> representantes =
                    representante.Search(new List<SearchParameterClass>()
                                             {
                                                 new SearchParameterClass("rep_razao_social", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String)
                                             }).
                        ConvertAll(a => (RepresentanteClass) a);


                this.cmbRepresentante.DataSource = representantes;
                this.cmbRepresentante.DisplayMember = "RazaoSocial";
                this.cmbRepresentante.ValueMember = "ID";
                this.cmbRepresentante.autoSize = true;
                this.cmbRepresentante.Table = representantes;
                this.cmbRepresentante.ColumnsToDisplay = new[] {"RazaoSocial", "Cnpj", "Fone1", "Email"};
                this.cmbRepresentante.HeadersToDisplay = new[] {"Razão Social", "Cnpj", "Fone", "E-mail"};


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

        private void Gerar()
        {
            try
            {
                this.crystalReportViewer1.ReportSource = null;

                if (this.chkEnviarEmail.Checked)
                {
                    if (MessageBox.Show(this, "Foi selecionado que o sistema deverá enviar o relatório por email para o representante que possuir email configurado, deseja continuar?", "Envio de Email", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }


                string[] tmp = this.txtMesAno.Text.Split(new string[] {"/"}, StringSplitOptions.RemoveEmptyEntries);
                if (tmp.Length!=2)
                {
                    throw new Exception("O mês e o ano devem ser preenchidos corretamente");
                }
                int mes;
                int ano;
                if (!int.TryParse(tmp[0], out  mes) || !int.TryParse(tmp[1], out  ano))
                {
                    throw new Exception("O mês e o ano devem ser preenchidos corretamente");
                }

                if (this.cmbRepresentante.Enabled && this.cmbRepresentante.SelectedValue==null)
                {
                    throw new Exception("Selecione o representante ou desabilite o campo para gerar para todos.");
                }

                if (this.cmbVendedor.Enabled && this.cmbVendedor.SelectedValue == null)
                {
                    throw new Exception("Selecione o vendedor ou desabilite o campo para gerar para todos.");
                }


                RepresentanteClass representanteSelecionado = null;
                VendedorClass vendedorSelecionado = null;
                if (this.cmbRepresentante.Enabled)
                {
                    representanteSelecionado = (RepresentanteClass) this.cmbRepresentante.SelectedItem;
                }

                if (this.cmbVendedor.Enabled)
                {
                    vendedorSelecionado = (VendedorClass) this.cmbVendedor.SelectedItem;
                }


                List<ComissaoReportDataSource> dados = ComissaoOperacoesClass.GerarRelatorioComissoes(
                    representanteSelecionado,
                    vendedorSelecionado,
                    mes,
                    ano,
                    this.chkSomenteSemComissao.Checked,
                    this.SingleConnection
                    );
               

                if (dados.Count==0)
                {
                    MessageBox.Show(this, "Não existem dados para os parâmetros selecionados.", "Relatório Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
                RepresentanteComissaoReport rep = new RepresentanteComissaoReport();

                rep.SetDataSource(dados);
                rep.SetParameterValue("mesAno", this.txtMesAno.Text);
                rep.SetParameterValue("ObservacaoGeracao", this.lblAvisoModoComissao.Text);

                this.crystalReportViewer1.ReportSource = rep;


                if (this.chkEnviarEmail.Checked)
                {

                    string remetente = IWTConfiguration.Conf.getConf(Constants.PEDIDO_EMAIL_REMETENTE);

                    bool enviarEmailCopia = Convert.ToBoolean(Convert.ToInt16(IWTConfiguration.Conf.getConf(Constants.ENVIAR_EMAIL_COPIA_RELATORIO_COMISSOES)));
                    string destinarioEmailCopia = enviarEmailCopia ? (";" + IWTConfiguration.Conf.getConf(Constants.DESTINATARIO_EMAIL_COPIA_RELATORIO_COMISSOES)) : "";

                    EnviaEmailRelatorioComissoesClass enviaEmail = new EnviaEmailRelatorioComissoesClass(LoginClass.UsuarioLogado.loggedUser,SingleConnection);

                    if (this.cmbRepresentante.Enabled)
                    {
                        //O relatório foi gerado para somente um representante pode enviar ele mesmo.
                        RepresentanteClass representante = (RepresentanteClass) this.cmbRepresentante.SelectedItem;
                        if (!string.IsNullOrEmpty(representante.Email))
                        {
                            enviaEmail.Enviar(
                                representante.Email + destinarioEmailCopia,
                                remetente,
                                representante.RazaoSocial,
                                this.txtMesAno.Text,
                                rep.ExportToStream(ExportFormatType.PortableDocFormat)
                                );
                        }

                        return;
                    }

                    if (this.cmbVendedor.Enabled)
                    {
                        //O relatório foi gerado para somente um vendedor pode enviar ele mesmo.
                        VendedorClass vendedor = (VendedorClass) this.cmbVendedor.SelectedItem;
                        if (!string.IsNullOrEmpty(vendedor.Email))
                        {
                            enviaEmail.Enviar(
                                vendedor.Email + destinarioEmailCopia,
                                remetente,
                                vendedor.RazaoSocial,
                                this.txtMesAno.Text,
                                rep.ExportToStream(ExportFormatType.PortableDocFormat)
                                );
                        }

                        return;
                    }

                    //O relatório é completo, ele deve ser separado para enviar para cada representante e para cada vendendor somente o seu relatório
                    #region Representantes
                    RepresentanteClass search = new RepresentanteClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                    List<RepresentanteClass> representantes =
                        search.Search(new List<SearchParameterClass>()
                                          {
                                              new SearchParameterClass("rep_razao_social", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String)
                                          }).
                            ConvertAll(a => (RepresentanteClass) a);

                    foreach (RepresentanteClass representante in representantes.Where(a => !string.IsNullOrEmpty(a.Email)))
                    {
                        dados = ComissaoOperacoesClass.GerarRelatorioComissoes(
                            representante,
                            null,
                            mes,
                            ano,
                            this.chkSomenteSemComissao.Checked,
                            this.SingleConnection
                            );

                        rep = new RepresentanteComissaoReport();

                        rep.SetDataSource(dados);
                        rep.SetParameterValue("mesAno", this.txtMesAno.Text);
                        rep.SetParameterValue("ObservacaoGeracao", this.lblAvisoModoComissao.Text);

                        enviaEmail.Enviar(
                            representante.Email + destinarioEmailCopia,
                            remetente,
                            representante.RazaoSocial,
                            this.txtMesAno.Text,
                            rep.ExportToStream(ExportFormatType.PortableDocFormat)
                            );
                    }

                    #endregion


                    #region Vendedores
                    VendedorClass search2 = new VendedorClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                    List<VendedorClass> vendedores =
                        search2.Search(new List<SearchParameterClass>()
                                          {
                                              new SearchParameterClass("ven_razao_social", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String)
                                          }).
                            ConvertAll(a => (VendedorClass)a);

                    foreach (VendedorClass vendedor in vendedores.Where(a => !string.IsNullOrEmpty(a.Email)))
                    {
                        dados = ComissaoOperacoesClass.GerarRelatorioComissoes(
                            null,
                            vendedor, 
                            mes,
                            ano,
                            this.chkSomenteSemComissao.Checked,
                            this.SingleConnection
                            );

                        rep = new RepresentanteComissaoReport();

                        rep.SetDataSource(dados);
                        rep.SetParameterValue("mesAno", this.txtMesAno.Text);
                        rep.SetParameterValue("ObservacaoGeracao", this.lblAvisoModoComissao.Text);

                        enviaEmail.Enviar(
                            vendedor.Email + destinarioEmailCopia,
                            remetente,
                            vendedor.RazaoSocial,
                            this.txtMesAno.Text,
                            rep.ExportToStream(ExportFormatType.PortableDocFormat)
                            );
                    }

                    #endregion
                }


            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar o relatório de comissões.\r\n" + e.Message, e);
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
   

        private void chkVendedor_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbVendedor.Enabled = this.chkVendedor.Checked;

            if (this.cmbVendedor.Enabled)
            {
                this.chkRepresentante.Checked = false;
            }
        }
        #endregion

    }
}
