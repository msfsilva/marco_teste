#region Referencias

using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Operacoes.VisualizacaoNf;
using BibliotecaNotasFiscais;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTNF.Entidades.Base;
using IWTNF.Entidades.Entidades;
using IWTPostgreNpgsql;
using Npgsql;
using dbProvider;

#endregion

namespace BibliotecaFinanceiro
{
    public partial class ListagemNFForm : IWTBaseForm
    {
        private IWTPostgreNpgsqlAdapter a;
        private DataSet ds;
        private BindingSource binding;
        IWTPostgreNpgsqlConnection conn;

        public ListagemNFForm(IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            dtpFim.Enabled = false;
            dtpInicio.Enabled = false;
            cbxBuscaData.Checked = true;
            loadGrid();
        }

        private void loadGrid()
        {


            string sql =
                "SELECT DISTINCT " +
                "  public.nf_principal.id_nf_principal, " +
                "  public.nf_principal.nfp_numero, " +
                "  COALESCE(public.nf_cliente.nfc_razao,'EMISSÃO EXTERNA') as nfc_razao, " +
                "  public.nf_principal.nfp_data_emissao, " +
                "  CASE nf_principal.nfp_situacao " +
                "    WHEN 'N' " +
                "      THEN 'Normal' " +
                "    WHEN '' " +
                "      THEN 'Normal' " +
                "    ELSE  'Cancelada' " +
                "  END AS nof_situacao_clean, " +
                "  public.nf_principal.nfp_situacao, " +
                "  public.nf_totais.nfo_valor_total_nf, " +
                "  public.order_item_etiqueta_conferencia.id_embarque," +
                "  CASE nf_principal.nfp_situacao " +
                "    WHEN 'C' " +
                "      THEN public.nf_principal_cancelamento_justificativa.ncj_justificativa " +
                "    ELSE '' " +
                "  END as justificativaCancelamento, " +
                "  nfp_serie, "+
                "  nfp_modelo_doc_fiscal " +
                "FROM " +
                "  public.nf_principal " +
                "  LEFT JOIN public.nf_cliente ON (public.nf_principal.id_nf_principal = public.nf_cliente.id_nf_principal) " +
                "  LEFT JOIN public.nf_totais ON (public.nf_principal.id_nf_principal = public.nf_totais.id_nf_principal) " +
                "  LEFT JOIN public.atendimento ON (public.nf_principal.id_nf_principal = public.atendimento.id_nf_principal) " +
                "  LEFT JOIN public.order_item_etiqueta_conferencia ON (public.atendimento.id_order_item_etiqueta_conferencia = public.order_item_etiqueta_conferencia.id_order_item_etiqueta_conferencia) " +
                "  LEFT JOIN public.nf_principal_cancelamento_justificativa ON (public.nf_principal.id_nf_principal = public.nf_principal_cancelamento_justificativa.id_nf_principal) " +
                "  LEFT OUTER JOIN public.nf_emitente ON (public.nf_principal.id_nf_principal = public.nf_emitente.id_nf_principal) " +
                "  LEFT JOIN public.nfe_completo_nota ON (nf_principal.nfp_numero = nfe_completo_nota.nfn_numero  " +
                "  AND nf_principal.nfp_serie = nfe_completo_nota.nfn_serie AND nf_principal.nfp_modelo_doc_fiscal = '55'  " +
                "  AND nf_emitente.nfe_cnpj_cpf = nfe_completo_nota.nfn_cnpj_emitente) " +
                "WHERE nfe_completo_nota.id_nfe_completo_nota IS NULL AND nf_principal.nfp_enviar_nfe_receita = 0 AND nf_principal.nfp_homologacao = 0";

            a = new IWTPostgreNpgsqlAdapter(sql, this.conn);

            if (a != null)
            {
                ds = new DataSet();

                a.Fill(ds);

                binding = new BindingSource();
                binding.DataSource = ds.Tables[0];
                binding.Sort = "nfp_numero";
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = binding;

                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[1].HeaderText = "Numero";
                dataGridView1.Columns[2].HeaderText = "Cliente";
                dataGridView1.Columns[3].HeaderText = "Data";
                dataGridView1.Columns[4].HeaderText = "Situação";

                dataGridView1.Columns[6].HeaderText = "Valor";
                dataGridView1.Columns[8].HeaderText = "Justificativa Cancelamento";

                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[7].Visible = false;

                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                
            }

            this.binding.Filter = this.reloadFilter;
        }  

        private void cancelarNFe()
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                if (dataGridView1.SelectedRows.Count != 1)
                {
                    throw new Exception("Selecione apenas uma nota fiscal para cancelar!");
                }
                else
                {
                    if (dataGridView1.SelectedRows[0].Cells["nfp_situacao"].Value.ToString() == "C")
                    {
                        throw new Exception("Não é possível cancelar uma nota fiscal que já está cancelada.");
                    }

                    if (MessageBox.Show(this, "Você tem certeza que deseja cancelar a nota fiscal selecionada?", "Cancelamento de NF", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int idNfPrincipal = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id_nf_principal"].Value);
                        //int serie = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["nfp_serie"].Value);
                        //string modelo = dataGridView1.SelectedRows[0].Cells["nfp_modelo_doc_fiscal"].Value.ToString();

                        string justificativaCancelamento;

                        JustificativaCancelamentoNFeForm form = new JustificativaCancelamentoNFeForm();
                        form.ShowDialog();
                        if (!form.cancelamentoSalvo)
                        {
                            return;
                        }
                        else
                        {
                            justificativaCancelamento = form.justificativa;
                        }


                        command = DbConnection.Connection.CreateCommand();
                        command.Transaction = command.Connection.BeginTransaction();

                        NotaFiscalFuncoesAuxiliares.CancelarNFe(idNfPrincipal, justificativaCancelamento, LoginClass.UsuarioLogado.loggedUser, command);

                        command.Transaction.Commit();
                        MessageBox.Show(this, "Nota Fiscal Cancelada com sucesso!", "Cancelamento de NF", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.loadGrid();
                    }
                    else
                    {
                        return;
                    }

                }
            }
            catch (Exception e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                throw new Exception("Erro ao cancelar a NFe.\r\n" + e.Message, e);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (binding != null)
            {
                this.binding.Filter = this.reloadFilter;
            }
        }

        private string reloadFilter
        {
            get
            {
                string filtro = "";
                //if (rdbNFCancelada.Checked)
                //{
                //    filtro = " nfp_situacao = 'C'";
                //}
                //else
                //{
                //    filtro = " nfp_situacao <> 'C'";
                //}

                if (txtBuscaNumNF.Text != "")
                {
                    filtro += " AND nfp_numero = " + txtBuscaNumNF.Text + "";
                }

                if (!cbxBuscaData.Checked)
                {
                    filtro += " AND ( nfp_data_emissao > '" + dtpInicio.Value.ToString("yyyy-MM-dd") + "' AND nfp_data_emissao < '" + dtpFim.Value.AddDays(1).ToString() + "')";
                }

                return filtro.Length > 0 ? filtro.Substring(4) : filtro;
            }
        }

        private void dtpInicio_ValueChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
        }

        private void dtpFim_ValueChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
        }

        private void txtBuscaNumNF_TextChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
        }
 
        private void btnCancelarNF_Click(object sender, EventArgs e)
        {

            try
            {
               this.cancelarNFe();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void updateSaldo(NfPrincipalClass nf)
        {
            IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();

            
            
            string idsOrderItemEtiquetaConferencia ="";
            string sql = "";
            try
            {
                //command.CommandText = "SELECT * FROM (atendimento JOIN order_item_etiqueta_conferencia ON atendimento.id_order_item_etiqueta_conferencia = order_item_etiqueta_conferencia.id_order_item_etiqueta_conferencia) JOIN order_item_etiqueta ON atendimento.id_order_item_etiqueta = order_item_etiqueta.id_order_item_etiqueta WHERE id_nf_principal = " + nf.IdNfPrincipal;
                command.CommandText =
                    "SELECT * " +
                    "FROM ( "+
                    "   atendimento "+
                    "   LEFT JOIN order_item_etiqueta_conferencia ON atendimento.id_order_item_etiqueta_conferencia = order_item_etiqueta_conferencia.id_order_item_etiqueta_conferencia) "+
                    "     JOIN order_item_etiqueta ON atendimento.id_order_item_etiqueta = order_item_etiqueta.id_order_item_etiqueta "+
                    "WHERE id_nf_principal = "+nf.ID;
                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {

                        //string novoStatus = read["oie_status_pedido"].ToString();
                        //string novoStatus2 = "1";
                        //if (novoStatus == "E")
                        //{
                        string novoStatus = "P";
                        string novoStatus2 = "0";
                        //}
                        double qtdAtendimento = Convert.ToDouble(read["ate_quantidade"]);


                        double novoSaldo = Convert.ToDouble(read["oie_saldo"]) + qtdAtendimento;

                        sql += "UPDATE order_item_etiqueta SET oie_saldo = " + novoSaldo.ToString("F2", CultureInfo.InvariantCulture) + ", oie_status_pedido='" + novoStatus + "' WHERE id_order_item_etiqueta = " + read["id_order_item_etiqueta"] + "; ";

                        if (read["id_pedido_item"] != DBNull.Value)
                        {
                            sql += "UPDATE pedido_item SET pei_saldo = " +
                                  novoSaldo.ToString("F2", CultureInfo.InvariantCulture) +
                                  ", pei_status = " + novoStatus2 + " WHERE id_pedido_item=" + read["id_pedido_item"] + "; ";
                        }
                        else
                        {
                            sql += "UPDATE pedido_item SET pei_saldo = " +
                                   novoSaldo.ToString("F2", CultureInfo.InvariantCulture) +
                                   ", pei_status = " + novoStatus2 + " WHERE pei_numero LIKE '" + read["oic_order_number"] +
                                   "' AND pei_posicao = " + read["oic_order_pos"] + " AND pei_sub_linha = 0; ";
                        }

                        sql += "UPDATE order_item SET \"status\" = 'WAIT_INVOI' WHERE order_number='" +
                               read["oie_order_number"] + "' AND order_pos=" + read["oie_order_pos"] + "; ";

                        if (read["oic_pallet"] != DBNull.Value)
                        {
                            idsOrderItemEtiquetaConferencia += " OR (oic_order_number='" + read["oic_order_number"] + "' AND oic_order_pos=" + read["oic_order_pos"] + " AND oic_pallet=" + read["oic_pallet"] + " AND oic_pallet_sequencia=" + read["oic_pallet_sequencia"] + ") ";
                        }
                        else
                        {
                            sql += "UPDATE order_item_etiqueta SET oie_saldo_conferencia = oie_saldo_conferencia+ " + qtdAtendimento.ToString("F2", CultureInfo.InvariantCulture) + ", oie_situacao_conferencia=0, oie_situacao_conferencia_nf=0 WHERE id_order_item_etiqueta = " + read["id_order_item_etiqueta"] + "; ";
                        }

                    }
                }
                read.Close();

                //Atualiza saldos Conferencia


                if (idsOrderItemEtiquetaConferencia.Length > 0)
                {
                    idsOrderItemEtiquetaConferencia = idsOrderItemEtiquetaConferencia.Substring(4);


                    command.CommandText = "SELECT * FROM order_item_etiqueta_conferencia WHERE " + idsOrderItemEtiquetaConferencia;
                    read = command.ExecuteReader();

                    while (read.Read())
                    {
                        sql += "UPDATE order_item_etiqueta SET oie_saldo_conferencia = oie_saldo_conferencia+ " + Convert.ToDouble(read["oic_quantidade_conferida"]).ToString("F2", CultureInfo.InvariantCulture) + ", oie_situacao_conferencia=0, oie_situacao_conferencia_nf=0 WHERE id_order_item_etiqueta = " + read["id_order_item_etiqueta"] + "; ";
                        sql += "DELETE FROM order_item_etiqueta_conferencia WHERE id_order_item_etiqueta_conferencia = " + read["id_order_item_etiqueta_conferencia"] + "; ";
                        
                    }
                }

                if (sql.Length > 0)
                {
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception a)
            {
                throw new Exception("Erro ao atualizar saldos. \r\n" + a.Message);
            }

        }

        private void cbxBuscaData_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxBuscaData.Checked)
            {
                dtpFim.Enabled = false;
                dtpInicio.Enabled = false;
            }
            else
            {
                dtpFim.Enabled = true;
                dtpInicio.Enabled = true;
            }

            timer1.Stop();
            timer1.Start();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            try
            {
                this.visualizarNF();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void visualizarNF()
        {
            try
            {
                if (dataGridView1.SelectedRows.Count != 1)
                {
                    MessageBox.Show(this, "Selecione apenas uma nota fiscal para visualizar!", "Visualizar de NF", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {

                      try
                      {


                          NfPrincipalClass nf = NfPrincipalBaseClass.GetEntidade(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id_nf_principal"].Value), LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);

                          VisualNFeForm form = new VisualNFeForm(nf, dataGridView1.SelectedRows[0].Cells["id_embarque"].Value.ToString(), VisualNFeFormUtilizacao.Visualizacao);
                          form.Show();

                          OPsUtilizadasNFeListForm form2 = new OPsUtilizadasNFeListForm(nf.ID, this.conn);
                          form2.Show();
                      }
                      catch
                      {
                          throw;
                      }

                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao visualizar a NFe\r\n" + e.Message, e);
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name=="nof_situacao_clean")
            {
                if (e.Value.ToString() == "Cancelada")
                {
                    foreach (DataGridViewCell cell in dataGridView1.Rows[e.RowIndex].Cells)
                    {
                        cell.Style.BackColor = Color.Red;
                    }
                }
                else
                {
                    foreach (DataGridViewCell cell in dataGridView1.Rows[e.RowIndex].Cells)
                    {
                        cell.Style.BackColor = Color.White;
                    }  
                }


            }

        }

        
    }
}
