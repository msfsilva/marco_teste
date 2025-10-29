#region Referencias

using System;
using System.Data;
using System.Windows.Forms;
using BibliotecaCadastrosBasicos.EstruturaProduto;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib;
using IWTPostgreNpgsql;

#endregion

namespace BibliotecaCadastrosBasicos.NovaEstruturaProduto
{
    public partial class EstruturaProdutoReportFormNew : IWTBaseForm
    {
        private ProdutoClass _produto;
        private NewProdutoTreeClass EstruturaAtual;

        readonly bool loading = false;

        public EstruturaProdutoReportFormNew(ProdutoClass produto)
        {
            _produto = produto;
            InitializeComponent();
            try
            {
            
                this.loading = true;
                this.initCombo();

                this.cmbVersaoEstrutura.SelectedValue = _produto.VersaoEstruturaAtual;
                this.loading = false;
                this.gerarRelatorio();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void initCombo()
        {
            try
            {
                string sql =
                    "SELECT " +
                    "  public.produto_revisao.prr_versao_estrutura, " +
                    "  'Rev. ' || public.produto_revisao.prr_versao_estrutura || ' - ' || " +
                    "  public.produto_revisao.prr_data || ' - ' || " +
                    "  public.acs_usuario.aus_login || ' - ' || " +
                    "  public.produto_revisao.prr_observacao as dados " +
                    "FROM  " +
                    "  public.produto_revisao " +
                    "  INNER JOIN public.acs_usuario ON (public.produto_revisao.id_acs_usuario = public.acs_usuario.id_acs_usuario) " +
                    "WHERE  " +
                    "  public.produto_revisao.id_produto_revisao IN ( " +
                    " " +
                    "SELECT  " +
                    " MIN(public.produto_revisao.id_produto_revisao) " +
                    "FROM " +
                    "  public.produto_revisao   " +
                    "WHERE " +
                    "  public.produto_revisao.id_produto = " + this._produto.ID + " " +
                    "GROUP BY " +
                    "  public.produto_revisao.prr_versao_estrutura " +
                    ") " +
                    " " +
                    "ORDER BY " +
                    "  public.produto_revisao.prr_data ";


                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.SingleConnection);

                DataSet ds = new DataSet();
                adapter.Fill(ds);

                BindingSource binding = new BindingSource();
                binding.DataSource = ds.Tables[0];
                this.cmbVersaoEstrutura.DataSource = binding;
                this.cmbVersaoEstrutura.ValueMember = "prr_versao_estrutura";
                this.cmbVersaoEstrutura.DisplayMember = "dados";



            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar as revisões;\r\n" + e.Message, e);
            }
        }

        private void gerarRelatorio()
        {
            try
            {
                if (this.loading) return;
                EstruturaProdutoReport rep = new EstruturaProdutoReport();

                int? versaoEstrutura = null;
                if (cmbVersaoEstrutura.SelectedValue != null)
                {
                    versaoEstrutura = Convert.ToInt32(cmbVersaoEstrutura.SelectedValue);
                }
                else
                {
                    versaoEstrutura = _produto.VersaoEstruturaAtual;
                }

                if (versaoEstrutura != _produto.VersaoEstruturaCarregada || EstruturaAtual==null)
                {
                    _produto.VersaoEstruturaCarregada = versaoEstrutura.Value;
                    EstruturaAtual = new NewProdutoTreeClass(_produto);
                }

                TipoRelatorioEstrutura tipo = TipoRelatorioEstrutura.PrimeiroFilhos;
                if (this.rdbPrimeiroComponentesPai.Checked)
                {
                    tipo = TipoRelatorioEstrutura.PrimeiroComponentesPai;
                    
                }


                rep.SetDataSource(NewProdutoReportClass.fillReport(EstruturaAtual, tipo));

                this.crystalReportViewer1.ReportSource = rep;
                this.crystalReportViewer1.Refresh();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar o relatório\r\n" + e.Message, e);
            }


        }

        private void cmbVersaoEstrutura_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.gerarRelatorio();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void rdbFilhosPrimeiro_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.gerarRelatorio();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbPrimeiroComponentesPai_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.gerarRelatorio();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    
}
