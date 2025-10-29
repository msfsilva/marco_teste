#region Referencias

using System;
using System.Data;
using System.Windows.Forms;
using BibliotecaExpedicao;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using dbProvider;

#endregion

namespace BibliotecaAdministracaoSistema
{
    public partial class EmbarqueForm : IWTBaseForm
    {
        public EmbarqueForm()
        {
            InitializeComponent();
            this.initializeGrid();
        }

        private void initializeGrid()
        {
            IWTPostgreNpgsqlAdapter adapter;
            DataSet dataSet;
            try
            {
                string sql = "SELECT  " +
                        "  id_embarque, " +
                        "  CASE emb_liberado_nf WHEN 0 THEN 'Não' ELSE 'Sim' END as liberado, " +
                        "  CASE emb_nf_emitida WHEN 0 THEN 'Não' ELSE 'Sim' END as nf_emitida, " +
                        "  emb_liberado_nf, " +
                        "  emb_nf_emitida " +
                        "FROM " +
                        "  public.embarque " +
                        "ORDER BY id_embarque";

                adapter = new IWTPostgreNpgsqlAdapter(sql, this.SingleConnection);
                if (adapter != null)
                {
                    dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    BindingSource binding = new BindingSource();
                    binding.DataSource = dataSet.Tables[0];

                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = binding;

                    dataGridView1.Columns[0].HeaderText = "Número";
                    dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[0].MinimumWidth = 100;
                    dataGridView1.Columns[1].HeaderText = "Liberado Emissão NF";
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[2].HeaderText = "NF Emitida";
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[3].Visible = false;
                    dataGridView1.Columns[4].Visible = false;
                }
            }
            catch (Exception z)
            {
                MessageBox.Show("Erro em carregar o Grid. \n" + z.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void excluirEmbarque(int idEmbarque)
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                command = SingleConnection.CreateCommand();
                command.Transaction = command.Connection.BeginTransaction();
                BibliotecaEntidades.Entidades.EmbarqueClass.DeleteEmbarque(idEmbarque, command, false);

                command.Transaction.Commit();
            }
            catch (Exception e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                throw new Exception("Erro ao excluir o embarque.\r\n" + e.Message);
            }
        }

        #region Eventos
        private void lnkAtualizar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.initializeGrid();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    int idEmbarque = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells["id_embarque"].Value);
                    if (Convert.ToInt16(this.dataGridView1.SelectedRows[0].Cells["emb_nf_emitida"].Value) == 0)
                    {
                        if (MessageBox.Show(this, "Essa operação excluirá o embarque selecionado deixando os pedidos livres para realizar uma nova conferência e palletização. Deseja continuar?", "Exclusão de Embarque", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            this.excluirEmbarque(idEmbarque);
                        }
                    }
                    else
                    {
                        throw new Exception("Impossível excluir um embarque com nota fiscal emitida");
                    }

                    this.initializeGrid();
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    
        private void btnDesmontarEmbarque_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    int idEmbarque = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells["id_embarque"].Value);
                    if (Convert.ToInt16(this.dataGridView1.SelectedRows[0].Cells["emb_nf_emitida"].Value) == 0)
                    {
                        if (MessageBox.Show(this, "Essa operação excluirá o embarque selecionado deixando os pallets montados e conferidos prontos para serem incluídos em outro embarque. Deseja continuar?", "Desmontagem de Embarque", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            EmbarqueClass.DesmontarEmbarque(idEmbarque);
                        }
                    }
                    else
                    {
                        throw new Exception("Impossível desmontar um embarque com nota fiscal emitida");
                    }

                    this.initializeGrid();
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }
}
