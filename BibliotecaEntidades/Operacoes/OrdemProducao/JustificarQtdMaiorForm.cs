#region Referencias

using System;
using System.Data;
using System.Windows.Forms;
using IWTDotNetLib;
using IWTPostgreNpgsql;

#endregion

namespace BibliotecaEntidades.Operacoes.OrdemProducao
{
    public partial class JustificarQtdMaiorForm : IWTBaseForm
    {
        public int tipo { private set; get; }
        public int? idEstoque { private set; get; }
        public int idJustificativa { private set; get; }
        readonly IWTPostgreNpgsqlConnection conn;

        public JustificarQtdMaiorForm(IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            this.loadCombo();
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
                "  mao_tipo = 1 " +
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

        private void JustificarQtdMaiorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                e.Cancel = true;
                if (this.cmbJustificativa.SelectedValue == null)
                {
                    throw new Exception("Campo Justificativa é obrigatório");
                }

                if (this.rdbDescartar.Checked)
                {
                    this.tipo = 0;
                }

                if (this.rdbCliente.Checked)
                {
                    this.tipo = 1;
                }

                if (this.rdbEstoque.Checked)
                {
                    this.tipo = 2;
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
