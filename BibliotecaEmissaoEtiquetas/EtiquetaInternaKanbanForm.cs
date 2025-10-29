#region Referencias

using System;
using System.Data;
using System.Windows.Forms;
using IWTDotNetLib;
using IWTPostgreNpgsql;

#endregion

namespace BibliotecaEmissaoEtiquetas
{
    public partial class EtiquetaInternaKanbanForm : IWTBaseForm
    {
        readonly IWTPostgreNpgsqlConnection conn;
        public EtiquetaInternaKanbanForm(IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            this.initializeCombo();
        }

        private void initializeCombo()
        {
            IWTPostgreNpgsqlAdapter a1;
            DataSet ds1;
            BindingSource binding1;


            a1 = new IWTPostgreNpgsqlAdapter("SELECT id_produto_k,(prk_codigo || ' - ' || prk_dimensao) as texto FROM produto_k WHERE prk_ativo=1 ORDER BY prk_codigo, prk_dimensao", this.conn);

            if (a1 != null)
            {
                ds1 = new DataSet();

                a1.Fill(ds1);

                binding1 = new BindingSource();
                binding1.DataSource = ds1.Tables[0];
             

                cmbProduto.DataSource = binding1;
                this.cmbProduto.DisplayMember = "texto";
                this.cmbProduto.ValueMember = "id_produto_k";
            }

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cmbProduto.SelectedValue != null)
            {
                //EtiquetaInternaKanbanReportForm form = new EtiquetaInternaKanbanReportForm(cmbProduto.SelectedValue.ToString(), Convert.ToInt16(txtQuantidade.Value));
                //form.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Você deve preencher todos os campos.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
