using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using dbProvider;

namespace BibliotecaCompras
{
    public partial class OrcamentoRecebimentoForm : IWTBaseForm
    {
        

        private OrcamentoCompraClass orcamento;


        public OrcamentoRecebimentoForm( OrcamentoCompraClass orcamento)
        {
            InitializeComponent();
            this.orcamento = orcamento;

            this.loadGrid();
            this.loadFornecedorLabels();
        }

        private void loadFornecedorLabels()
        {
            if (this.orcamento != null)
            {
                this.lblNumOrc.Text = this.orcamento.idOrcamentoCompra.ToString();
                this.lblFornecedor.Text = this.orcamento.razaoFornecedor;
                this.lblPrazo.Text = this.orcamento.prazo.ToString();
                this.lblSituacao.Text = this.orcamento.situacao.ToString();
                this.lblResp.Text = this.orcamento.idUsuario.Name;

                if (this.orcamento.situacao == SituacaoOrcComp.Encerrada)
                {
                    this.btnOk.Enabled = false;
                    this.dataGridView1.Enabled = false;
                }
            }
        }

        private void loadGrid()
        {
            try
            {
                this.dataGridView1.Columns.Clear();

                this.dataGridView1.ReadOnly = false;
                this.dataGridView1.AutoGenerateColumns = false;

                this.dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn());
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "idProdutoMaterial";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].Visible = false;
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].Name = "ID";

                this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "Selecionado";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].ReadOnly = false;
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "Quantidade";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Quantidade";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].ReadOnly = true;
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "codigoProdutoMaterial";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Identificação";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].ReadOnly = true;
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "descricaoProdutoMaterial";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Descrição";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].ReadOnly = true;
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "ValorRecebido";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Preço(R$)";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].ReadOnly = false;
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DefaultCellStyle.Format = "C2";

                this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "IpiRecebimento";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "IPI(%)";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].ReadOnly = false;
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DefaultCellStyle.Format = "0.00\\%";

                this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "IcmsRecebimento";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "ICMS(%)";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].ReadOnly = false;
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DefaultCellStyle.Format = "0.00\\%";

                this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "DataRecebimento";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Data Recebimento";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].ReadOnly = true;
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "UsuarioRecebimento";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Usuário Recebimento";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].ReadOnly = true;
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                
                this.dataGridView1.DataSource = new List<OrcamentoCompraItemClass>(this.orcamento.orcamentoCompraItemList.Values);

                DataGridViewColumn column = this.dataGridView1.Columns[1];
                DataGridViewCheckBoxColumn tmp = null;

                tmp = new DataGridViewCheckBoxColumn();
                tmp.FalseValue = "0";
                tmp.TrueValue = "1";
                tmp.DataPropertyName = column.DataPropertyName;
                tmp.DisplayIndex = column.DisplayIndex;
                tmp.ReadOnly = column.ReadOnly;
                tmp.AutoSizeMode = column.AutoSizeMode;
                tmp.Width = column.Width;
                tmp.Name = column.Name;
                tmp.HeaderText = column.HeaderText;
                this.dataGridView1.Columns.Remove(tmp.Name);
                this.dataGridView1.Columns.Add(tmp);

                this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.dataGridView1.MultiSelect = false;
                
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro ao carregar datagrid.\r\n" + e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void realizarRecebimento()
        {

            IWTPostgreNpgsqlCommand command = null;

            try
            {
                //Verifica se o orçamento ja foi totalmente recebido
                if (this.orcamento.situacao == SituacaoOrcComp.Encerrada)
                {
                    throw new Exception("Este orçamento ja foi totalmente recebido!");
                }

                command = DbConnection.Connection.CreateCommand();
                command.Transaction = command.Connection.BeginTransaction();
                bool parcial = false;
                
                //Percorre os itens do orçamento
                foreach (OrcamentoCompraItemClass item in this.orcamento.orcamentoCompraItemList.Values)
                {
                    //Verificar se o checkBox foi selecionado
                    if (item.selecionado == 1) 
                    {
                        //Verifica se o item ja foi recebido anteriormente
                        if (item.dataRecebimento == null)
                        {
                            //Veirficar se todas as informações foram preenchidas (valor / IPI / ICMS)
                            if (item.valorRecebido > 0 && item.ipiRecebimento != null && item.icmsRecebimento != null)
                            {
                                this.atualizaItemFornecedor(ref command, item); //Atualiza os dados do item no fornecedor
                                item.setUsuarioRecebimento(LoginClass.UsuarioLogado.loggedUser);
                                item.setDataRecebimento();
                            }
                            else
                            {
                                throw new Exception("Preencha os campos Valor, IPI e ICMS do item: " + item.descricaoProdutoMaterial);
                            }
                        }
                        else
                        {
                            throw new Exception("O item: " + item.descricaoProdutoMaterial + " ja foi recebido!");
                        }
                    }
                    else
                    {
                        /*Caso algum item não tenha sido selecionado e seus dados de recebimento não estão preechidos
                         * então é um recebimento parcial do orçamento. */
                        if (item.valorRecebido == 0 || item.valorRecebido == null || item.ipiRecebimento == null || item.icmsRecebimento == null)
                        {
                            parcial = true;
                        }
                    }
                }

                // Define/atualiza a situação do orçamento
                if (parcial)
                {
                    this.orcamento.setRetornoParcial();
                }
                else
                {
                    this.orcamento.setEncerrado();
                }
                
                this.orcamento.save(ref command);
               
                command.Transaction.Commit();

                MessageBox.Show(this, "Orçamento recebido com sucesso!", "Orçamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception a)
            {
                if (command != null && command.Transaction != null && command.Transaction.IsActive)
                {
                    command.Transaction.Rollback();
                    
                }
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void atualizaItemFornecedor(ref IWTPostgreNpgsqlCommand command, OrcamentoCompraItemClass item)
        {
            try
            {
                if (item.Material != null)
                {
                    MaterialFornecedorClass fornecedor = item.Material.CollectionMaterialFornecedorClassMaterial.First(a => a.Fornecedor.ID == item.orcamentoCompra.idFornecedor);

                    fornecedor.setUltimoPreco((double)item.valorRecebido, (double)item.icmsRecebimento, (double)item.ipiRecebimento);
                    fornecedor.Save(ref command);
                }
                else
                {
                    if (item.Produto != null)
                    {
                        item.Produto.CollectionProdutoFornecedorClassProduto.First(a=>a.Fornecedor.ID==item.orcamentoCompra.idFornecedor).setUltimoPreco((double)item.valorRecebido, (double)item.icmsRecebimento, (double)item.ipiRecebimento);
                        item.Produto.CollectionProdutoFornecedorClassProduto.First(a => a.Fornecedor.ID == item.orcamentoCompra.idFornecedor).Save(ref command);
                    }else
                    {
                        item.Epi.CollectionEpiFornecedorClassEpi[item.orcamentoCompra.idFornecedor].setUltimoPreco((double)item.valorRecebido, (double)item.icmsRecebimento, (double)item.ipiRecebimento);
                        item.Epi.CollectionEpiFornecedorClassEpi[item.orcamentoCompra.idFornecedor].Save(ref command);
                    }
                }
                
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao atualizar Material/Produto/Epi do fornecedor.\r\n" + e.Message, e);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.realizarRecebimento();
        }

        

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            
            if (e.ColumnIndex == 4)
            {
                double temp = 0;
                if (!double.TryParse(e.FormattedValue.ToString(), out temp))
                {
                    dataGridView1.Rows[e.RowIndex].ErrorText = "Valor inválido";
                    MessageBox.Show(this, "Valor inválido para o item: " + dataGridView1.Rows[e.RowIndex].Cells[2].Value, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
                /*
                if (dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString() != "")
                {
                    dataGridView1.Rows[e.RowIndex].ErrorText = "Item recebido";
                    MessageBox.Show(this, "O item: " + dataGridView1.Rows[e.RowIndex].Cells[2].Value + " ja foi recebido e não pode ser alterado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
                 * */
                
            }
            if (e.ColumnIndex == 5)
            {
                double temp = 0;
                if (!double.TryParse(e.FormattedValue.ToString(), out temp))
                {
                    dataGridView1.Rows[e.RowIndex].ErrorText = "Valor inválido";
                    MessageBox.Show(this, "IPI inválido para o item: " + dataGridView1.Rows[e.RowIndex].Cells[2].Value, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
                
            }
            if (e.ColumnIndex == 6)
            {
                double temp = 0;
                if (!double.TryParse(e.FormattedValue.ToString(), out temp))
                {
                    dataGridView1.Rows[e.RowIndex].ErrorText = "Valor inválido";
                    MessageBox.Show(this, "ICMS inválido para o item: " + dataGridView1.Rows[e.RowIndex].Cells[2].Value, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
                
            }
             
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // If the data source raises an exception when a cell value is 
            // commited, display an error message.
            if (e.Exception != null)
            {
                if ((e.Context & DataGridViewDataErrorContexts.Parsing) != 0)
                {
                    dataGridView1.Rows[e.RowIndex].ErrorText = "Valor inválido";
                    MessageBox.Show(this, "Valor inválido para o item: " + dataGridView1.Rows[e.RowIndex].Cells[2].Value, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
       
    }
}
