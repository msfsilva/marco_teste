using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BibliotecaCadastrosBasicos;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;

namespace BibliotecaProdutos
{
    public partial class CargaFabricaReportForm : IWTBaseForm
    {
        public CargaFabricaReportForm()
        {
            InitializeComponent();

            ensClassificacao.FormSelecao = new CadClassificacaoProdutoListForm(TipoModulo.Tipo);
        }


        private void AjustaCamposDatas()
        {
            this.grbDatas.Enabled = rdbEntrada.Checked || this.rdbEntrega.Checked;

            if (this.grbDatas.Enabled)
            {
                this.grbDatas.Enabled = true;
                if (rdbEntrada.Checked) this.grbDatas.Text = "Datas de Entrada";
                if (rdbEntrega.Checked) this.grbDatas.Text = "Datas de Entrega";
            }
            else
            {
                this.grbDatas.Enabled = false;
                this.grbDatas.Text = "";
            }

            if (rdbClassificacao.Checked)
            {
                ensClassificacao.removeForceDisable();
            }
            else
            {
                ensClassificacao.forceDisable();
            }
            
        }

        private void GerarRelatorio()
        {
            this.crystalReportViewer1.ReportSource = null;

            AcsUsuarioClass user = LoginClass.UsuarioLogado.loggedUser;


            DateTime? dataEntregaIni = rdbEntrega.Checked ? dtpDe.Value : (DateTime?) null;
            DateTime? dataEntregaFim = rdbEntrega.Checked ? dtpAte.Value : (DateTime?) null;
            DateTime? dataEntradaIni = rdbEntrada.Checked ? dtpDe.Value : (DateTime?) null;
            DateTime? dataEntradaFim = rdbEntrada.Checked ? dtpAte.Value : (DateTime?) null;
            ClassificacaoProdutoClass classificacao = (ClassificacaoProdutoClass) (rdbClassificacao.Enabled ? ensClassificacao.EntidadeSelecionada : null);


            List<CargaFabricaReportClass> ds = CargaFabricaReportClass.GerarReport(dataEntregaIni, dataEntregaFim, dataEntradaIni, dataEntradaFim, classificacao, SingleConnection);
            if (ds.Count == 0)
            {
                throw new ExcecaoTratada("Não há dados para geração do relatório");
            }


            CargaFabricaReport rep = new CargaFabricaReport();
            rep.SetDataSource(ds);
            rep.SetParameterValue(0, "Impresso por " + user + " em " + Configurations.DataIndependenteClass.GetData().ToString("dd/MM/yyyy"));

            this.crystalReportViewer1.ReportSource = rep;
        }

        #region Eventos







        private void rdbCompleto_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                AjustaCamposDatas();
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

        private void rdbEntrega_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                AjustaCamposDatas();
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

        private void rdbEntrada_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                AjustaCamposDatas();
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

        private void rdbClassificacao_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                AjustaCamposDatas();
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

        private void btnGerar_Click(object sender, EventArgs e)
        {
            try
            {
                GerarRelatorio();
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

        private void CargaFabricaReportForm_Shown(object sender, EventArgs e)
        {
            AjustaCamposDatas();
        }
    }

    #endregion
}
