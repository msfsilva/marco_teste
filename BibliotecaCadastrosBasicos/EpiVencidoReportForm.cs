using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Relatorios;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;

namespace BibliotecaCadastrosBasicos
{
    public partial class EpiVencidoReportForm : IWTBaseForm
    {
        public EpiVencidoReportForm()
        {
            InitializeComponent();
            this.btnGerarReport_Click(null, null);
        }
        
        private void btnGerarReport_Click(object sender, EventArgs e)
        {
            try
            {
                this.initReport();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void initReport()
        {
            try
            {
                FuncionarioEpiClass search = new FuncionarioEpiClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<FuncionarioEpiClass> funcionarioEpis =
                    search.Search(new List<SearchParameterClass>()
                    {
                        new SearchParameterClass("EpisVencidos", this.cbxVencAte.Checked ? (DateTime?)this.dtpVencAte.Value : Configurations.DataIndependenteClass.GetData(), SearchOperacao.FiltroNormal, SearchOrdenacao.Asc, TipoOrdenacao.Data)
                    }).ConvertAll(a => (FuncionarioEpiClass)a);

                List<EpiVencidoReportClass> episVencidos = funcionarioEpis.Where(a => a.Funcionario.Ativo && a.Situacao != SituacaoFuncionarioEpi.Descartado).Select(epi => new EpiVencidoReportClass(epi, this.cbxVencAte.Checked ? (DateTime?) this.dtpVencAte.Value : null)).ToList();

                if (episVencidos.Count == 0)
                {
                    MessageBox.Show(this, this.cbxVencAte.Checked ? "Não há EPIs vencidos até " + this.dtpVencAte.Value.ToString("dd/MM/yyyy") : "Não há EPIs vencidos até a data de hoje", "EPIs Vencidos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                AcsUsuarioClass user = LoginClass.UsuarioLogado.loggedUser;
                EpiVencidoReport rep = new EpiVencidoReport();
                rep.SetDataSource(episVencidos);
                rep.SetParameterValue(0, "Impresso por " + user + " em " + Configurations.DataIndependenteClass.GetData().ToString("dd/MM/yyyy"));

                this.crystalReportViewer1.ReportSource = rep;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os EPIs vencidos.\r\n" + e.Message, e);
            }
        }

        private void cbxVencAte_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpVencAte.Enabled = this.cbxVencAte.Checked;
        }
    }
}
