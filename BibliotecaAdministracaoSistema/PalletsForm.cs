#region Referencias

using System;
using System.Data;
using System.Windows.Forms;
using BibliotecaExpedicao;
using Configurations;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using Npgsql;
using ProjectConstants;
using dbProvider;

#endregion

namespace BibliotecaAdministracaoSistema
{
    public partial class PalletsForm : IWTBaseForm
    {
        private BindingSource binding;
        public PalletsForm()
        {
            InitializeComponent();
            this.initializeGrid();

            
            if (IWTConfiguration.Conf.getBoolConf(Constants.BLOQUEAR_LIBERACAO_PALLET))
            {
                this.btnLiberar.Enabled = false;
                this.btnLiberar.Visible = false;
            }

            if (!IWTConfiguration.Conf.getBoolConf(Constants.EXIGIR_CONFERENCIA_PALLET))
            {
                this.btnDesfazerConferencia.Enabled = false;
                this.btnDesfazerConferencia.Visible = false;
            }
        }

        private void initializeGrid()
        {
            IWTPostgreNpgsqlAdapter adapter;
            DataSet dataSet;
            try
            {
                string sql = "SELECT  " +
                        "  pal_numero, " +
                        "  CASE pal_ocupado WHEN 0 THEN 'Não' ELSE 'Sim' END as ocupado, " +
                        "  CASE pal_fechado WHEN 0 THEN 'Não' ELSE 'Sim' END as fechado, " +
                        "  CASE pal_conferido WHEN 0 THEN 'Não' ELSE 'Sim' END as conferido, " +
                        "  pal_ocupado, " +
                        "  pal_fechado, " +
                        "  pal_conferido, " +
                        "  pal_especial, " +
                        "  CASE pal_especial WHEN 0 THEN 'Não' ELSE 'Sim' END as especial, " +
                        "  pal_sequencia, " +
                        "  pal_bloqueado, " +
                        "  CASE pal_bloqueado WHEN 0 THEN 'Não' ELSE 'Sim' END as bloqueado, " +
                        "  pal_utilizado_momento, " +
                        "  CASE pal_utilizado_momento WHEN 0 THEN 'Não' ELSE 'Sim' END as utilizado " +
                        "FROM " +
                        "  public.pallet "+
                        "ORDER BY pal_numero";

                adapter = new IWTPostgreNpgsqlAdapter(sql, this.SingleConnection);
                if (adapter != null)
                {
                    dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    binding = new BindingSource();
                    binding.DataSource = dataSet.Tables[0];

                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = binding;

                    dataGridView1.Columns[0].HeaderText = "Número";
                    dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[0].MinimumWidth = 100;
                    dataGridView1.Columns[1].HeaderText = "Ocupado";
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[2].HeaderText = "Fechado";
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[3].HeaderText = "Conferido";
                    dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[4].Visible = false;
                    dataGridView1.Columns[5].Visible = false;
                    dataGridView1.Columns[6].Visible = false;
                    dataGridView1.Columns[7].Visible = false;
                    dataGridView1.Columns[8].HeaderText = "Especial";
                    dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[9].Visible = false;
                    dataGridView1.Columns[10].Visible = false;
                    dataGridView1.Columns[11].HeaderText = "Bloqueado";
                    dataGridView1.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[12].Visible = false;
                    dataGridView1.Columns[13].HeaderText = "Utilizado Momento";
                    dataGridView1.Columns[13].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                this.updateSearch();
            }
            catch (Exception z)
            {
                MessageBox.Show("Erro em carregar o Grid. \n" + z.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void updateSearch()
        {
            string sql = "";
            if (this.txtNumero.Text.Trim().Length > 0)
            {
                sql += " AND pal_numero = " + this.txtNumero.Text;
            }

            if (!rdbOcupadoTodos.Checked)
            {
                sql += " AND pal_ocupado=" + Convert.ToInt16(rdbOcupadoSim.Checked).ToString() + " ";
            }
            if (!rdbFechadoTodos.Checked)
            {
                sql += " AND pal_fechado=" + Convert.ToInt16(rdbFechadoSim.Checked).ToString() + " ";
            }
            if (!rdbConferidoTodos.Checked)
            {
                sql += " AND pal_conferido=" + Convert.ToInt16(rdbConferidoSim.Checked).ToString() + " ";
            }

            if (sql.Length > 0)
            {
                this.binding.Filter = sql.Substring(4);
            }
            else
            {
                this.binding.Filter = "";
            }
        }

        private void bloquearPallet(string numPallet)
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                command = this.SingleConnection.CreateCommand();
                command.CommandText = "UPDATE pallet SET pal_bloqueado = CASE pal_bloqueado WHEN 1 THEN 0 ELSE 1 END WHERE pal_numero = " + numPallet;
                command.ExecuteNonQuery();

                this.initializeGrid();
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao bloquear/desbloquear o pallet.\r\n" + e.Message);
            }
        }

        private void LiberarPallet(string numPallet)
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                if (MessageBox.Show(this, "Essa operação só deverá ser utilizada em casos extremos, sua utilização NÃO retornará os pedidos do pallet para o status anterior. Essa operação marcará o pallet como livre e aberto para utilização. Utilize com cuidado. Deseja continuar?", "Liberação Manual de pallet", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    command = this.SingleConnection.CreateCommand();
                    command.CommandText = "UPDATE pallet SET pal_ocupado = 0, pal_fechado=0, pal_conferido=0, id_usuario = NULL, pal_utilizado_momento =0 WHERE public.pallet.pal_numero = " + numPallet + " ;";
                    command.ExecuteNonQuery();

                    this.initializeGrid();
                }
            }
            catch (Exception e)
            {


                throw new Exception("Erro inesperado ao bloquear/desbloquear o pallet.\r\n" + e.Message);
            }
        }

        private void LiberarBloqueioPallet(string numPallet)
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                if (MessageBox.Show(this, "Essa operação irá retirar o bloqueio que impede que o mesmo pallet seja aberto em dois computadores simultâneos. Só a utilize caso o pallet tenha ficado bloqueado e não esteja aberto em nenhum terminal. Deseja continuar?", "Liberação Bloqueio de pallet", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    command = this.SingleConnection.CreateCommand();
                    command.CommandText = "UPDATE pallet SET pal_utilizado_momento =0 WHERE public.pallet.pal_numero = " + numPallet + " ;";
                    command.ExecuteNonQuery();

                    this.initializeGrid();
                }
            }
            catch (Exception e)
            {


                throw new Exception("Erro inesperado ao bloquear/desbloquear o pallet.\r\n" + e.Message);
            }
        }

        private void desfazerConferencia(string numPallet)
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                if (
                    MessageBox.Show(this, "Essa operação irá desfazer a conferência do pallet. Deseja continuar?",
                                    "Desfazer Conferência de pallet", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                    DialogResult.Yes)
                {
                    command = this.SingleConnection.CreateCommand();
                    command.Transaction = command.Connection.BeginTransaction();

                    PalletConferencia Pallet = new PalletConferencia(Convert.ToInt32(numPallet), this.SingleConnection);
                    Pallet.setConferido(false);
                    Pallet.Save(command);

                    command.CommandText =
                        "SELECT id_order_item_etiqueta FROM order_item_etiqueta_conferencia_nf WHERE oin_pallet=" +
                        Pallet.Numero + " AND oin_pallet_sequencia = " + Pallet.Sequencia;
                    IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                    string whereClause = "";

                    while (read.Read())
                    {
                        whereClause += " OR id_order_item_etiqueta = " + read["id_order_item_etiqueta"] + " ";
                    }
                    read.Close();

                    if (whereClause.Length > 0)
                    {
                        command.CommandText = "UPDATE order_item_etiqueta SET oie_situacao_conferencia_nf=0 WHERE " +
                                              whereClause.Substring(3);
                        command.ExecuteNonQuery();
                    }

                    command.CommandText =
                        "UPDATE order_item_etiqueta_conferencia SET oic_conferencia_pallet=0, oic_conferencia_pallet_usuario = NULL, oic_conferencia_pallet_data = NULL WHERE oic_pallet=" +
                        Pallet.Numero + " AND oic_pallet_sequencia=" + Pallet.Sequencia + ";";
                    command.ExecuteNonQuery();

                    command.CommandText = "DELETE FROM order_item_etiqueta_conferencia_nf WHERE oin_pallet=" +
                                          Pallet.Numero + " AND oin_pallet_sequencia = " + Pallet.Sequencia;
                    command.ExecuteNonQuery();

                    command.Transaction.Commit();

                    this.initializeGrid();
                }
            }
            catch (Exception e)
            {
                if (command != null)
                {
                    try
                    {
                        if (command.Transaction != null)
                        {
                            command.Transaction.Rollback();
                        }
                    }
                    catch
                    {
                    }
                }

                throw new Exception("Erro inesperado ao desfazer a conferência do pallet.\r\n" + e.Message);
            }
        }

        private void forcarFechamento(string numPallet)
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                if (
                    MessageBox.Show(this, "Essa operação irá fechar o pallet. Deseja continuar?",
                                    "Forçar Fechamento de pallet", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                    DialogResult.Yes)
                {
                    command = this.SingleConnection.CreateCommand();
                    command.Transaction = command.Connection.BeginTransaction();

                    PalletConferencia Pallet = new PalletConferencia(Convert.ToInt32(numPallet), this.SingleConnection);
                    Pallet.setFechado(true);
                    Pallet.Save(command);

                    command.Transaction.Commit();

                    this.initializeGrid();
                }
            }
            catch (Exception e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }

                throw new Exception("Erro inesperado ao desfazer a conferência do pallet.\r\n" + e.Message);
            }
        }

        #region Eventos

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            this.updateSearch();

        }

        private void rdbOcupadoSim_CheckedChanged(object sender, EventArgs e)
        {
            this.updateSearch();
        }

        private void rdbOcupadoNao_CheckedChanged(object sender, EventArgs e)
        {
            this.updateSearch();
        }

        private void rdbFechadoSim_CheckedChanged(object sender, EventArgs e)
        {
            this.updateSearch();
        }

        private void rdbFechadoNao_CheckedChanged(object sender, EventArgs e)
        {
            this.updateSearch();
        }

        private void lnkAtualizar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.initializeGrid();
        }
     
        private void rdbOcupadoTodos_CheckedChanged(object sender, EventArgs e)
        {
            this.updateSearch();
        }

        private void rdbFechadoTodos_CheckedChanged(object sender, EventArgs e)
        {
            this.updateSearch();
        }
      

        private void rdbConferidoSim_CheckedChanged(object sender, EventArgs e)
        {
            this.updateSearch();
        }

        private void rdbConferidoNao_CheckedChanged(object sender, EventArgs e)
        {
            this.updateSearch();
        }

        private void rdbConferidoTodos_CheckedChanged(object sender, EventArgs e)
        {
            this.updateSearch();
        }
      
        private void btnAlterarPallet_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    string ocupado = this.dataGridView1.SelectedRows[0].Cells["pal_ocupado"].Value.ToString();
                    string fechado = this.dataGridView1.SelectedRows[0].Cells["pal_fechado"].Value.ToString();
                    string sequencia = this.dataGridView1.SelectedRows[0].Cells["pal_sequencia"].Value.ToString();

                    if (ocupado == "1")
                    {
                        bool somenteVisualizacao = fechado != "1";
                        AlterarPalletForm form = new AlterarPalletForm(this.dataGridView1.SelectedRows[0].Cells["pal_numero"].Value.ToString(), sequencia, somenteVisualizacao);
                        form.ShowDialog();

                    }
                    else
                    {
                        MessageBox.Show(this, "O pallet deve estar ocupado e fechado para ser alterado.", "Alteração de conteúdo do pallet", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.initializeGrid();

           
        }

        private void btnBloquear_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    this.bloquearPallet(this.dataGridView1.SelectedRows[0].Cells["pal_numero"].Value.ToString());
                }
                catch (Exception a)
                {
                    MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.initializeGrid();
            }

        }
       

        private void btnLiberar_Click(object sender, EventArgs e)
        {
            try
            {
                this.LiberarPallet(this.dataGridView1.SelectedRows[0].Cells["pal_numero"].Value.ToString());
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

         private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.LiberarBloqueioPallet(this.dataGridView1.SelectedRows[0].Cells["pal_numero"].Value.ToString());
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

         private void btnDesfazerConferencia_Click(object sender, EventArgs e)
         {
             try
             {
                 this.desfazerConferencia(this.dataGridView1.SelectedRows[0].Cells["pal_numero"].Value.ToString());
             }
             catch (Exception a)
             {
                 MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
         }

     
         private void btnFechamento_Click(object sender, EventArgs e)
         {
             try
             {
                 this.forcarFechamento(this.dataGridView1.SelectedRows[0].Cells["pal_numero"].Value.ToString());
             }
             catch (Exception a)
             {
                 MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
         }

        
        #endregion




    }
}
