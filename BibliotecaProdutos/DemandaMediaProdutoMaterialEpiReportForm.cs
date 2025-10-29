using System;
using System.Windows.Forms;
using BibliotecaCadastrosBasicos;
using BibliotecaControleRevisao;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using ProjectConstants;

namespace BibliotecaProdutos
{
    public partial class DemandaMediaProdutoMaterialEpiReportForm : IWTBaseForm
    {
        public DemandaMediaProdutoMaterialEpiReportForm()
        {
            InitializeComponent();
            this.crystalReportViewer1.ShowLogo = false;
            this.ensSelecaoItem.FormSelecao = new CadMaterialListForm(TipoModulo.Tipo, true, somenteAtivos: true);
            this.ensSelecaoItem.EntidadeSelecionada = null;
        }

        private void btnGerarRep_Click(object sender, EventArgs e)
        {
            try
            {
                int tipoItem = 0;
                string descTipoItem = "";
                if (rdbMaterial.Checked)
                {
                    tipoItem = 0;
                    descTipoItem = "Materiais";
                }

                if (rdbProduto.Checked)
                {
                    tipoItem = 1;
                    descTipoItem = "Produtos";
                }

                if (rdbEpi.Checked)
                {
                    tipoItem = 2;
                    descTipoItem = "EPIs";
                }

                if (rdbProdutoK.Checked)
                {
                    tipoItem = 3;
                    descTipoItem = "Kanban de Itens Manufaturados";
                }

                AbstractEntity itemSelecionado = null;
                if (this.ensSelecaoItem.Enabled)
                {
                    if (this.ensSelecaoItem.EntidadeSelecionada != null)
                    {
                        itemSelecionado = this.ensSelecaoItem.EntidadeSelecionada;
                    }
                    else
                    {
                        throw new ExcecaoTratada("Selecione a entidade para busca ou desmarque o campo para buscar todas.");
                    }
                }

                DemandaMediaProdutoEpiReport rep = new DemandaMediaProdutoEpiReport();
                rep.SetDataSource(DemandaMediaProdutoMaterialEpiClass.gerarRelatorio(tipoItem,itemSelecionado, this.SingleConnection));
                AcsUsuarioClass user = LoginClass.UsuarioLogado.loggedUser;
                rep.SetParameterValue(0, descTipoItem);
                rep.SetParameterValue("diasVerde", "Est. Dias Verde: " + Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_DIAS_VERDE)));
                rep.SetParameterValue("diasAmarelo", "Est. Dias Amarelo: " + Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_DIAS_AMARELO)));
                rep.SetParameterValue("diasVermelho", "Est. Dias Vermelho: " + Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_DIAS_VERMELHO)));
                rep.SetParameterValue("mesesMedia", "Est. Meses Média: " + Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_N_MESES_MEDIA)));
                rep.SetParameterValue("categoriaAAcimaDe", "Est. Classificação A: " + Convert.ToDouble(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_CLASSIFICACAO_A)));
                rep.SetParameterValue("categoriaBAcimaDe", "Est. Classificação B: " + Convert.ToDouble(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_CLASSIFICACAO_B)));
                rep.SetParameterValue("margemAvisoKB", "Est. Margem Rev. Kb: " + Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_MARGEM_REVISAO_KB)));
                
                this.crystalReportViewer1.ReportSource = rep;
            }
            catch (Exception a)
            {
                MessageBox.Show("Erro ao gerar relatório.\r\n" + a.Message, "Relatório de Demandas Sugeridas",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbMaterial_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbMaterial.Checked)
            {
                this.ensSelecaoItem.FormSelecao = new CadMaterialListForm(TipoModulo.Tipo, true, somenteAtivos: true);
                this.ensSelecaoItem.EntidadeSelecionada = null;
            }
        }

        private void rdbProduto_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbProduto.Checked)
            {
                this.ensSelecaoItem.FormSelecao = new CadProdutoListForm(TipoModulo.Tipo, true, somenteAtivos: true);
                this.ensSelecaoItem.EntidadeSelecionada = null;
            }
        }

        private void rdbEpi_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbEpi.Checked)
            {
                this.ensSelecaoItem.FormSelecao = new CadEpiListForm(TipoModulo.Tipo);
                this.ensSelecaoItem.EntidadeSelecionada = null;
            }
        }

        private void rdbProdutoK_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbProdutoK.Checked)
            {
                this.ensSelecaoItem.FormSelecao = new CadAgrupadorItemSemelhanteListForm(TipoModulo.Tipo);
                this.ensSelecaoItem.EntidadeSelecionada = null;
            }
        }
    }
}
