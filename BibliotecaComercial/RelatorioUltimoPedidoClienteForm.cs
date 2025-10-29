using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaComercial
{
    public partial class RelatorioUltimoPedidoClienteForm : IWTBaseForm
    {
        public RelatorioUltimoPedidoClienteForm()
        {
            InitializeComponent();
            this.crystalReportViewer1.ShowLogo = false;
        }

        private void RelatorioUltimoPedidoClienteForm_Load(object sender, EventArgs e)
        {
            loadComboRepresentante();
            cmbRepresentante.Enabled = chkRepresentante.Checked;

        }


        private void loadComboRepresentante()
        {
            try
            {
                RepresentanteClass representante = new RepresentanteClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<RepresentanteClass> representanteList =
                    representante.Search(new List<SearchParameterClass>() { new SearchParameterClass("rep_razao_social", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String) }).ConvertAll(a => (RepresentanteClass)a);


                this.cmbRepresentante.DataSource = representanteList;
                this.cmbRepresentante.DisplayMember = "RazaoSocial";
                this.cmbRepresentante.ValueMember = "ID";
                this.cmbRepresentante.autoSize = true;
                this.cmbRepresentante.Table = representanteList;
                this.cmbRepresentante.ColumnsToDisplay = new[] { "RazaoSocial", "Cnpj", "Fone1", "Endereco", "EnderecoNumero", "Bairro", "Cidade" };
                this.cmbRepresentante.HeadersToDisplay = new[] { "Razão Social", "Cnpj", "Telefone", "Endereço", "Número", "Bairro", "Cidade" };
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção da Família.\r\n" + e.Message);
            }
        }

        private void chkRepresentante_CheckedChanged(object sender, EventArgs e)
        {
            cmbRepresentante.Enabled = chkRepresentante.Checked;
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            DateTime inicio;
            int? idRepresentante = null;
            if(dtpInicio.Value == null)
            {
                throw new Exception("Informe a data de início da busca");
            }else
            {
                inicio = dtpInicio.Value;
            }

         
            if(chkRepresentante.Checked && cmbRepresentante.SelectedItem == null)
            {
                throw new Exception("Informe o Representante ou desmarque o campo");
            }else
            {
                if (chkRepresentante.Checked && cmbRepresentante.SelectedItem != null)
                {
                    idRepresentante = int.Parse(cmbRepresentante.SelectedValue.ToString());
                }
            }

            try
            {

                RptUltimoPedidoCliente rel = new RptUltimoPedidoCliente();

                rel.SetDataSource(RelatorioUltimoPedidoClienteClass.gerar(inicio, idRepresentante,SingleConnection));

                string parametroData = "Data a partir de : " + inicio.ToString("dd/MM/yyyy");
                rel.SetParameterValue("dataInicio", parametroData);

                string representanteParamentro = "";
                if (idRepresentante.HasValue)
                {

                    representanteParamentro = "Representante: " + cmbRepresentante.SelectedItem.ToString();
                    rel.SetParameterValue("representante", representanteParamentro);
                }
                else
                {
                    rel.SetParameterValue("representante", representanteParamentro);
                }

                this.crystalReportViewer1.ReportSource = rel;
            }catch(Exception a)
            {
                MessageBox.Show("Erro ao gerar o relatório\r\n" + a.Message, "ERRO", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }




        }

       
    }
}
