#region Referencias

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using dbProvider;

#endregion

namespace BibliotecaFinanceiro
{
    public partial class SituacaoConferenciaPedidosForm : IWTBaseForm
    {
        private BindingSource binding;
        private readonly bool somentePalletsFechados;
        public SituacaoConferenciaPedidosForm(bool somentePalletsFechados)
        {
            InitializeComponent();
            this.somentePalletsFechados = somentePalletsFechados;
            this.initializeGrid();

            if (this.somentePalletsFechados)
            {
                this.groupBox1.Visible = false;
                this.groupBox2.Visible = false;
                this.groupBox3.Visible = false;

            }

        }

        private void initializeGrid()
        {
            IWTPostgreNpgsqlAdapter adapter;
            DataSet dataSet;
            try
            {
                string sql;
                if (somentePalletsFechados)
                {
                    sql = "SELECT " +
                                "  public.order_item_etiqueta.id_order_item_etiqueta, " +
                                "  public.order_item_etiqueta.oie_order_number, " +
                                "  public.order_item_etiqueta.oie_order_pos, " +
                                "  public.order_item_etiqueta.oie_codigo_item, " +
                                "  public.order_item_etiqueta.oie_dimensao, " +
                                "  public.order_item_etiqueta.oie_pps, " +
                                "  public.order_item_etiqueta.oie_qtd_etiquetas, " +
                                "  public.order_item_etiqueta.oie_situacao_conferencia, " +
                                "  CASE public.order_item_etiqueta.oie_situacao_conferencia WHEN 0 THEN 'Não Iniciada' WHEN 1 THEN 'Parcial' ELSE 'Conferida' END AS situacao_extenso, " +
                                "  public.order_item_etiqueta.oie_etiqueta_expedicao_impressa, " +
                                "  CASE public.order_item_etiqueta.oie_etiqueta_expedicao_impressa WHEN 0 THEN 'Não' ELSE 'Sim' END AS impressao_expedicao, " +
                                "  public.order_item_etiqueta.oie_pallet, " +
                                "  public.order_item_etiqueta.oie_nota_fiscal_emitida, " +
                                "  CASE public.order_item_etiqueta.oie_nota_fiscal_emitida WHEN 0 THEN 'Não' ELSE 'Sim' END AS nota_fiscal_emitida, " +
                                "  public.order_item_etiqueta.oie_situacao_conferencia_nf, " +
                                "  CASE public.order_item_etiqueta.oie_situacao_conferencia_nf WHEN 0 THEN 'Não Iniciada' WHEN 1 THEN 'Parcial' ELSE 'Conferida' END AS situacao_nf_extenso " +
                                "FROM " +
                                "  public.order_item_etiqueta JOIN pallet ON order_item_etiqueta.oie_pallet = pallet.pal_numero " +
                                "WHERE " +
                                "  public.order_item_etiqueta.oie_nivel_item=0 AND " +
                                "  public.order_item_etiqueta.oie_nota_fiscal_emitida=0 AND " +
                                " ( "+
                                "  public.pallet.pal_fechado = 1 OR " +
                                "  public.pallet.pal_especial = 1 " +
                                " ) "+
                                "ORDER BY " +
                                "  public.order_item_etiqueta.oie_pps, " +
                                "  public.order_item_etiqueta.oie_order_number";
                }
                else
                {
                    sql = "SELECT " +
                                "  public.order_item_etiqueta.id_order_item_etiqueta, " +
                                "  public.order_item_etiqueta.oie_order_number, " +
                                "  public.order_item_etiqueta.oie_order_pos, " +
                                "  public.order_item_etiqueta.oie_codigo_item, " +
                                "  public.order_item_etiqueta.oie_dimensao, " +
                                "  public.order_item_etiqueta.oie_pps, " +
                                "  public.order_item_etiqueta.oie_qtd_etiquetas, " +
                                "  public.order_item_etiqueta.oie_situacao_conferencia, " +
                                "  CASE public.order_item_etiqueta.oie_situacao_conferencia WHEN 0 THEN 'Não Iniciada' WHEN 1 THEN 'Parcial' ELSE 'Conferida' END AS situacao_extenso, " +
                                "  public.order_item_etiqueta.oie_etiqueta_expedicao_impressa, " +
                                "  CASE public.order_item_etiqueta.oie_etiqueta_expedicao_impressa WHEN 0 THEN 'Não' ELSE 'Sim' END AS impressao_expedicao, " +
                                "  public.order_item_etiqueta.oie_pallet, " +
                                "  public.order_item_etiqueta.oie_nota_fiscal_emitida, " +
                                "  CASE public.order_item_etiqueta.oie_nota_fiscal_emitida WHEN 0 THEN 'Não' ELSE 'Sim' END AS nota_fiscal_emitida, " +
                                "  public.order_item_etiqueta.oie_situacao_conferencia_nf, " +
                                "  CASE public.order_item_etiqueta.oie_situacao_conferencia_nf WHEN 0 THEN 'Não Iniciada' WHEN 1 THEN 'Parcial' ELSE 'Conferida' END AS situacao_nf_extenso " +
                                "FROM " +
                                "  public.order_item_etiqueta " +
                                "WHERE " +
                                "  public.order_item_etiqueta.oie_nivel_item=0 " +
                                "ORDER BY " +
                                "  public.order_item_etiqueta.oie_pps, " +
                                "  public.order_item_etiqueta.oie_order_number";
                }
                adapter = new IWTPostgreNpgsqlAdapter(sql, DbConnection.Connection);
                if (adapter != null)
                {
                    dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    binding = new BindingSource();
                    binding.DataSource = dataSet.Tables[0];
                    //binding.Sort = "oie_pps,oie_order_number";
                    //binding.Filter = "";

                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = binding;

                    dataGridView1.Columns[0].HeaderText = "ID";
                    dataGridView1.Columns[1].HeaderText = "OC";
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[2].HeaderText = "Pós";
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[3].HeaderText = "Item";
                    dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[3].MinimumWidth = 100;
                    dataGridView1.Columns[4].HeaderText = "Medida";
                    dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[5].HeaderText = "Semana";
                    dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[6].HeaderText = "Qtd Total Etiquetas";
                    dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[7].Visible = false;
                    dataGridView1.Columns[8].HeaderText = "Situação Conferência";
                    dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[9].Visible = false;
                    dataGridView1.Columns[10].HeaderText = "Etiqueta Expedição Impressa";
                    dataGridView1.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[11].HeaderText = "Pallet";
                    dataGridView1.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[12].Visible = false;
                    dataGridView1.Columns[13].HeaderText = "NF Emitida";
                    dataGridView1.Columns[13].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[14].Visible = false;
                    dataGridView1.Columns[15].HeaderText = "Situação Conferência NF";
                    dataGridView1.Columns[15].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    this.updateSearch();

                    dataGridView1.Columns[0].Visible = false;
                }
               
            }
            catch (Exception z)
            {
                MessageBox.Show("Erro em carregar o Grid. \n" + z.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void updateSearch()
        {
            string filter = "";

            if (this.txtSemana.Text.Trim().Length > 0)
            {
                filter += " AND oie_pps=" + this.txtSemana.Text.Trim() + " ";
            }
            if (this.txtOC.Text.Trim().Length > 0)
            {
                filter += " AND oie_order_number LIKE '%" + this.txtOC.Text.Trim() + "%' ";
            }
            if (this.txtPallet.Text.Trim().Length > 0)
            {
                filter += " AND oie_pallet = " + this.txtPallet.Text.Trim() + " ";
            }

            string filter2 = "";
            if (chkNaoConferidos.Checked)
            {
                filter2 += " OR oie_situacao_conferencia = 0 ";
            }
            if (chkParcial.Checked)
            {
                filter2 += " OR oie_situacao_conferencia = 1 ";
            }
            if (chkTotal.Checked)
            {
                filter2 += " OR oie_situacao_conferencia = 2 ";
            }

            if (filter2.Length > 0)
            {
                filter += " AND (" + filter2.Substring(3) + ")";
            }

            if (!this.rdbNfEmitidaTodos.Checked)
            {
                filter += " AND oie_nota_fiscal_emitida=" + Convert.ToInt16(this.rdbNfEmitidaSim.Checked) + " ";
            }

            filter2 = "";
            if (chkNfNaoConferidos.Checked)
            {
                filter2 += " OR oie_situacao_conferencia_nf = 0 ";
            }
            if (chkNfParcial.Checked)
            {
                filter2 += " OR oie_situacao_conferencia_nf = 1 ";
            }
            if (chkNfTotal.Checked)
            {
                filter2 += " OR oie_situacao_conferencia_nf = 2 ";
            }

            if (filter2.Length > 0)
            {
                filter += " AND (" + filter2.Substring(3) + ")";
            }


            if (filter.Length > 0)
            {
                filter = filter.Substring(4);
            }

            this.binding.Filter = filter;
        }

        private void marcarNfEmitida(List<string> ids)
        {
            string sqlWhere = "";
            foreach (string id in ids)
            {
                sqlWhere += " OR id_order_item_etiqueta =" + id;
            }
            if (sqlWhere.Length > 0)
            {
                sqlWhere = sqlWhere.Substring(3);
            }
            IWTPostgreNpgsqlCommand command = DbConnection.Connection.CreateCommand();
            command.CommandText = "UPDATE order_item_etiqueta SET oie_nota_fiscal_emitida=1 WHERE " + sqlWhere;
            command.ExecuteNonQuery();

            this.initializeGrid();

        }


        private void emitirNf(List<string> ids)
        {



        }

        #region Eventos
        private void lnkAtualizar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.initializeGrid();
        }

        private void txtSemana_TextChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
        }

        private void txtOC_TextChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            this.updateSearch();
        }
 

        private void chkNaoConferidos_CheckedChanged(object sender, EventArgs e)
        {
            this.updateSearch();
        }

        private void chkParcial_CheckedChanged(object sender, EventArgs e)
        {
            this.updateSearch();
        }

        private void chkTotal_CheckedChanged(object sender, EventArgs e)
        {
            this.updateSearch();
        }


        private void rdbNfEmitidaSim_CheckedChanged(object sender, EventArgs e)
        {
            this.updateSearch();
        }

        private void rdbNfEmitidaNao_CheckedChanged(object sender, EventArgs e)
        {
            this.updateSearch();
        }

        private void rdbNfEmitidaTodos_CheckedChanged(object sender, EventArgs e)
        {
            this.updateSearch();
        }

        private void chkNfNaoConferidos_CheckedChanged(object sender, EventArgs e)
        {
            this.updateSearch();
        }

        private void chkNfParcial_CheckedChanged(object sender, EventArgs e)
        {
            this.updateSearch();
        }

        private void chkNfTotal_CheckedChanged(object sender, EventArgs e)
        {
            this.updateSearch();
        }

        private void txtPallet_TextChanged(object sender, EventArgs e)
        {
            this.updateSearch();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show(this, "Deseja marcar como emitida as notas fiscais das linhas selecionadas?", "NF", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        List<string> ids = new List<string>();

                        for (int i = 0; i < this.dataGridView1.SelectedRows.Count; i++)
                        {
                            ids.Add(dataGridView1.SelectedRows[i].Cells["id_order_item_etiqueta"].Value.ToString());
                        }

                        //this.marcarNfEmitida(ids);
                        this.emitirNf(ids);
                    }
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, "Erro ao marcar a nf das ocs como emitida.\r\n" + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        #endregion
    }
}
