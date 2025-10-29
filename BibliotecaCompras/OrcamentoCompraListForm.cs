using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaTributos;
using Configurations;
using CrystalDecisions.Shared;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using ProjectConstants;
using dbProvider;
using IWTDotNetLib.ComplexLoginModule;

namespace BibliotecaCompras
{
    public partial class OrcamentoCompraListForm : IWTBaseForm
    {
        BindingSource binding;

        private byte[] logoEmpresa;
        
        private int diasPCP;
        private int leadTimeCompras;

        

        public OrcamentoCompraListForm()
        {
            InitializeComponent();
            
            this.logoEmpresa = IWTConfiguration.Conf.getBinaryConf(Constants.LOGO_EMPRESA);
          
            this.diasPCP = int.Parse(IWTConfiguration.Conf.getConf(Constants.DIAS_PROGRAMACAO_PCP));
            this.leadTimeCompras = int.Parse(IWTConfiguration.Conf.getConf(Constants.DIAS_PROGRAMACAO_COMPRAS));


            this.initializeGrid();
        }

        private void initializeGrid()
        {
            #region Salvando Posição do Grid
            int scrollIndex = 0;
            if (this.dataGridView1.FirstDisplayedScrollingRowIndex > 0)
            {
                scrollIndex = this.dataGridView1.FirstDisplayedScrollingRowIndex;
            }

            int selectRowIndex = 0;
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                selectRowIndex = this.dataGridView1.SelectedRows[0].Index;
            }
            #endregion

            #region Salvando FiltroAtual

            string atualFilter;
            if (this.binding != null)
            {
                atualFilter = this.binding.Filter;
            }
            else
            {
                atualFilter = "";
            }

            #endregion

            #region Salvando o Sort Atual do Grid

            string sortedColumName = null;
            SortOrder? sortedMode = null;
            if (this.dataGridView1.SortedColumn != null)
            {
                sortedColumName = this.dataGridView1.SortedColumn.Name;
                sortedMode = this.dataGridView1.SortOrder;
            }

            #endregion
            
            string filter = "";
            if (this.txtBusca.Text.Trim().Length > 0)
            {
                filter += " AND " +
                            " id_orcamento_compra = " + this.txtBusca.Text.Trim() + " ";
            }

            if (this.dtpBusca.Enabled)
            {
                filter += " AND ( " +
                                " CAST(oco_data_abertura AS DATE) = '" + this.dtpBusca.Value.ToString("yyyy-MM-dd") + "' " +
                              ") ";
            }


            string filterStatus = "";
            if (this.cbxNovas.Checked)
            {
                filterStatus += " OR oco_situacao = 0 ";
            }

            if (this.cbxAguardandoRetorno.Checked)
            {
                filterStatus += " OR oco_situacao = 1 ";
            }

            if (this.cbxRetornoParcial.Checked)
            {
                filterStatus += " OR oco_situacao = 2 ";
            }

            if (this.cbxEncerrada.Checked)
            {
                filterStatus += " OR oco_situacao = 3 ";
            }

            if (filterStatus.Length > 0)
            {
                filter += " AND (" + filterStatus.Substring(3) + ") ";
            }

            if (filter.Length > 0)
            {
                filter = " WHERE " + filter.Substring(4);
            }

            string sql = "SELECT                                                                                                          " +
                            "  public.orcamento_compra.id_orcamento_compra,                                                                  " +
                            "  public.fornecedor.for_razao_social,                                                                           " +
                            "  CAST(public.orcamento_compra.oco_data_abertura AS DATE),                                                                    " +
                            "  public.orcamento_compra.oco_prazo,                                                                            " +
                            "  CASE public.orcamento_compra.oco_situacao " +
                                "WHEN 0 THEN 'Novo' " +
                                "WHEN 1 THEN 'Aguardando Retorno' " +
                                "WHEN 2 THEN 'Retorno Parcial' " +
                                "WHEN 3 THEN 'Encerrado' " +
                                "END AS situacao,                                                                         " +
                            "  public.acs_usuario.aus_name                                                                                   " +
                            "FROM                                                                                                            " +
                            "  public.orcamento_compra                                                                                       " +
                            "  INNER JOIN public.fornecedor ON (public.orcamento_compra.id_fornecedor = public.fornecedor.id_fornecedor)     " +
                            "  INNER JOIN public.acs_usuario ON (public.orcamento_compra.id_acs_usuario = public.acs_usuario.id_acs_usuario) " +
                             filter +
                            " ORDER BY " +
                            " id_orcamento_compra";
                         

                
            IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, DbConnection.Connection);
            if (adapter != null)
            {
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                binding = new BindingSource();
                binding.DataSource = ds.Tables[0];
                //binding.Filter = atualFilter;
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = binding;

                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.MultiSelect = true;
                
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[0], "Número", 100, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[1], "Fornecedor", 190, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[2], "Data Abertura", 90, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[3], "Prazo(Dias)", 70, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[4], "Situação", 120, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[5], "Usuário Responsável", 120, DataGridViewAutoSizeColumnMode.None, true);
                
            }

            #region Restaurando Sort Atual do Grid

            if (sortedColumName != null)
            {
                string sortString = sortedColumName;
                switch (sortedMode)
                {
                    case SortOrder.Ascending:
                        sortString += " ASC";
                        break;
                    case SortOrder.Descending:
                        sortString += " DESC";
                        break;
                }

                this.binding.Sort = sortString;
            }
            #endregion

            #region Restaurando Posição do Grid
            for (int i = 0; i < this.dataGridView1.SelectedRows.Count; i++)
            {
                this.dataGridView1.SelectedRows[i].Selected = false;
            }
            if (this.dataGridView1.Rows.Count > 0)
            {
                while (selectRowIndex > 0 && selectRowIndex >= this.dataGridView1.Rows.Count)
                {
                    selectRowIndex--;
                }


                this.dataGridView1.Rows[selectRowIndex].Selected = true;

                while (scrollIndex > 0 && scrollIndex >= this.dataGridView1.Rows.Count)
                {
                    scrollIndex--;
                }

                this.dataGridView1.FirstDisplayedScrollingRowIndex = scrollIndex;
            }
            #endregion

        }

        private void enviarOrcamento()
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                command = DbConnection.Connection.CreateCommand();
                command.Transaction = command.Connection.BeginTransaction();

                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    for (int i = 0; i < this.dataGridView1.SelectedRows.Count; i++)
                    {
                        OrcamentoCompraClass orc = new OrcamentoCompraClass(
                                                                        (int)this.dataGridView1.SelectedRows[i].Cells[0].Value, 
                                                                        this.logoEmpresa);

                        EnviaOrcamentoEmailClass enviadorEmail = new EnviaOrcamentoEmailClass(NotaFiscalFuncoesAuxiliares.CarregaNomeEmpresa(), LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);

                        if (orc.fornecedorEnviaEmail)
                        {
                            if (
                                MessageBox.Show(this,
                                                "O EASI está configurado para e enviar automaticamente a Solicitação de Orçamento para o fornecedor " +
                                                orc.razaoFornecedor +
                                                ". Deseja enviar agora?\r\nSIM: Envia email para o fornecedor.\r\n NÃO: Apenas marca como enviado.",
                                                "Envio Automático de Email", MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question) == DialogResult.Yes)
                            {


                                string Destinatario = orc.forEmail;
                                string Remetente = IWTConfiguration.Conf.getConf(Constants.COMPRAS_EMAIL_REMETENTE); 
                                string msgEmail = null;

                                OrcamentoReport rep = new OrcamentoReport();
                                rep.SetDataSource(orc.orcamentoCompraItemList.Values);
                                rep.SetParameterValue("idImprimir", orc.idOrcamentoCompra);

                                enviadorEmail.setOrc(orc.idOrcamentoCompra.Value,
                                                     rep.ExportToStream(ExportFormatType.PortableDocFormat));
                                enviadorEmail.Enviar(Destinatario, Remetente, msgEmail);
                            }

                        }

                        orc.setEnviada();
                        orc.save(ref command);

                       
                    }
                    command.Transaction.Commit();
                    
                    MessageBox.Show("Orçamento(s) enviado(s) com sucesso!" , "Envio de Orçamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.initializeGrid();
                }
                else
                {
                    throw new Exception("Selecione a linha que você deseja enviar.");
                }
            }
            catch (Exception e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                MessageBox.Show("Erro ao enviar orçamento.\r\n" + e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        private void realizarRecebimento()
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    if (dataGridView1.SelectedRows[0].Cells["situacao"].Value.ToString() != "Novo")
                    {
                        OrcamentoCompraClass orc = new OrcamentoCompraClass((int?)this.dataGridView1.SelectedRows[0].Cells[0].Value);
                        if (orc.idOrcamentoCompra != null)
                        {
                            OrcamentoRecebimentoForm recebimento = new OrcamentoRecebimentoForm( orc);
                            recebimento.ShowDialog();
                        }
                    }
                    else
                    {
                        throw new Exception("O Orçamento selecionado não foi enviado ao fornecedor.");
                    }
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void visualizarOrcamento()
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                command = DbConnection.Connection.CreateCommand();

                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    OrcamentoCompraClass orc;
                    List<OrcamentoCompraClass> listToPrint = new List<OrcamentoCompraClass>();
                    for (int i = 0; i < this.dataGridView1.SelectedRows.Count; i++)
                    {
                        orc = new OrcamentoCompraClass(
                                                       (int)this.dataGridView1.SelectedRows[i].Cells[0].Value,
                                                       this.logoEmpresa);
                        listToPrint.Add(orc);
                    }
                    
                    OrcamentoReportForm reportForm = new OrcamentoReportForm(ref command, listToPrint, true);
                    reportForm.Show();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(this,"Erro ao visualizar orçamentos.\r\n" + e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void excluir()
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show(this, "Confirma a exclusão dos orçamentos selecionados?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        command = DbConnection.Connection.CreateCommand();
                        command.Transaction = command.Connection.BeginTransaction();

                        OrcamentoCompraClass orc;
                        string errorMessage = "";
                        for (int i = 0; i < this.dataGridView1.SelectedRows.Count; i++)
                        {
                            orc = new OrcamentoCompraClass(
                                                       (int)this.dataGridView1.SelectedRows[i].Cells[0].Value,
                                                       this.logoEmpresa);
                            if (orc.situacao == SituacaoOrcComp.Nova)
                            {
                                orc.ToDelete();
                            }
                            else
                            {
                                errorMessage += "N° " + orc.idOrcamentoCompra + "\r\n";
                            }
                            orc.save(ref command);
                        }

                        command.Transaction.Commit();
                        
                        if (errorMessage != "")
                        {
                            MessageBox.Show(this, "O(s) Orçamento(s) " + errorMessage + " não foi/foram excluido(s) pois ja foi/foram enviado(s) ao(s) fornecedor(es).", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }else
                        {
                            MessageBox.Show("Orçamento(s) excluido(s) com sucesso!", "Exclusão de Orçamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        this.initializeGrid();
                    }
                }
            }
            catch (Exception a)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        

        #region Eventos

        private void btnNovo_Click(object sender, EventArgs e)
        {
            OrcamentoCompraForm form = new OrcamentoCompraForm(this.logoEmpresa, this.diasPCP, this.leadTimeCompras,this.SingleConnection);
            form.Show();
            this.initializeGrid();
        }

        private void btnRecebimento_Click(object sender, EventArgs e)
        {
            this.realizarRecebimento();
            this.initializeGrid();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            this.excluir();
        }
        
        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
        }

        private void dtpBusca_ValueChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
        }

        private void chkIdOC_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpBusca.Enabled = this.cbxDataAb.Checked;
            timer1.Stop();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            this.initializeGrid();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            this.enviarOrcamento();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            this.visualizarOrcamento();
        }

        private void cbxNovas_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
        }

        private void cbxAguardandoRetorno_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
        }

        private void cbxRetornoParcial_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
        }

        private void cbxEncerrada_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
        }





        #endregion

       

        

     

        

        

        
    }
}
