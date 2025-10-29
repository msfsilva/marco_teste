#region Referencias

using System;
using System.Data;
using System.Windows.Forms;
using IWTDotNetLib;
using IWTPostgreNpgsql;

#endregion

namespace BibliotecaEntidades.Operacoes.OrdemProducao
{
    public partial class JustificarQtdMenorForm : IWTBaseForm
    {
        public bool? repor { private set; get; }
        public int idJustificativa { private set; get; }
        public bool exibirRepor { private set; get; }
        readonly IWTPostgreNpgsqlConnection conn;

        public JustificarQtdMenorForm(IWTPostgreNpgsqlConnection conn, bool exibirRepor)
        {
            InitializeComponent();
            this.conn = conn;

            this.loadCombo();
            this.exibirRepor = exibirRepor;

            if (exibirRepor)
            {
                rdbRepor.Visible = true;
                rdbNaoRepor.Visible = true;
            }
            else
            {
                rdbRepor.Visible = false;
                rdbNaoRepor.Visible = false;
            }

        }

        private void loadCombo()
        {

            string sql =
                "SELECT  " +
                "  id_motivo_alteracao_qtd_op, " +
                "  mao_motivo " +
                "FROM  " +
                "  public.motivo_alteracao_qtd_op " +
                "WHERE " +
                "  mao_tipo = 0 " +
                "ORDER BY mao_motivo";


            IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.conn);
            if (adapter != null)
            {
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                BindingSource binding = new BindingSource();
                binding.DataSource = ds.Tables[0];
                this.cmbJustificativa.DataSource = binding;
                this.cmbJustificativa.ValueMember = "id_motivo_alteracao_qtd_op";
                this.cmbJustificativa.DisplayMember = "mao_motivo";
                

            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void JustificarQtdMenorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                e.Cancel = true;
                if (this.cmbJustificativa.SelectedValue == null)
                {
                    throw new Exception("Campo Justificativa é obrigatório");
                }

                if (this.exibirRepor)
                {
                    this.repor = this.rdbRepor.Checked;
                }
                else
                {
                    this.repor = null;
                }

                this.idJustificativa = (int)this.cmbJustificativa.SelectedValue;

                e.Cancel = false;
            }
            catch (Exception a)
            {
                MessageBox.Show(this, "Erro ao preencher a justificativa.\r\n" + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
