using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using Npgsql;

namespace BibliotecaCompras
{
    public partial class OrcamentoCompraForm2 : IWTBaseForm
    {
        private Dictionary<long, OrcamentoCompraClass> orcamentos;
        private Dictionary<long, string> fornecedores;
        private IWTPostgreNpgsqlConnection conn;
        private int pageIndex;
        private int orcQty;
        private OrcamentoCompraForm formStep1;
        
        public OrcamentoCompraForm2(Dictionary<long, OrcamentoCompraClass> orcs, IWTPostgreNpgsqlConnection conn, OrcamentoCompraForm formStep1 )
        {
            InitializeComponent();
            if (orcs.Count != 0)
            {
                this.orcamentos = orcs;
                this.conn = conn;
                this.formStep1 = formStep1;
                this.pageIndex = 0;
                this.orcQty = orcamentos.Count;
                this.loadAllFornecedoresToShow();
                this.loadGrid();
                this.lblFornecedor.Text = fornecedores[orcamentos.ElementAt(pageIndex).Key];
                if (this.pageIndex == (this.orcQty - 1))
                {
                    this.btnNext.Text = "Finalizar";
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

                this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "idProdutoMaterial";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].Visible = false;
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].Name = "ID";

                this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "Quantidade";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Quantidade";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].ReadOnly = false;
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
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "infoAdicionalProdutoMaterial";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Informação Adicional";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].ReadOnly = true;
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "unidadeCompraProdutoMaterial";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Unid. de Compra";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].ReadOnly = true;
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "unidadesPorUnidadeCompraProdutoMaterial";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Unidades por Unid. de Compra";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].ReadOnly = true;
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "LotePadraoCompraProdutoMaterial";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Lote Padrão";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].ReadOnly = true;
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "politicaEstoque";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Política Estoque";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].ReadOnly = true;
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                OrcamentoCompraClass orc = orcamentos.ElementAt(pageIndex).Value;
                this.dataGridView1.DataSource = new List<OrcamentoCompraItemClass>(orc.orcamentoCompraItemList.Values);

                this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.dataGridView1.MultiSelect = false;
                
            }catch(Exception e)
            {
                MessageBox.Show("Erro ao carregar datagrid.\r\n" + e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void loadAllFornecedoresToShow()
        {
            try
            {
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText = "SELECT id_fornecedor, for_razao_social FROM fornecedor";
                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                this.fornecedores = new Dictionary<long, string>();
                while (read.Read())
                {
                    this.fornecedores.Add(Convert.ToInt32(read["id_fornecedor"]), read["for_razao_social"].ToString());
                }
                read.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar fornecedores.\r\n" + e.Message, e);
            }
        }

        private void generateOrcamentos()
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                command = this.conn.CreateCommand();
                command.Transaction = this.conn.BeginTransaction();

                foreach (OrcamentoCompraClass orcamento in orcamentos.Values)
                {
                    orcamento.save(ref command);
                }

                OrcamentoReportForm form = new OrcamentoReportForm(ref command, new List<OrcamentoCompraClass>(orcamentos.Values), false);
                form.Show();

                command.Transaction.Commit();

                this.formStep1.Close();
                this.Close();
                

            }
            catch (Exception e)
            {
                if (command != null && command.Transaction != null && command.Transaction.IsActive)
                {
                    command.Transaction.Rollback();
                }
                MessageBox.Show("Erro ao gerar orçamentos.\r\n" + e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Eventos

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (this.pageIndex == (this.orcQty - 1))
            {
                //Generate orcamentos e send email
                this.generateOrcamentos();
            }
            else
            {
                this.pageIndex++;
                this.lblFornecedor.Text = fornecedores[orcamentos.ElementAt(pageIndex).Key];
                this.loadGrid();
                if (this.pageIndex == (this.orcQty - 1))
                {
                    this.btnNext.Text = "Finalizar";
                }
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            if (this.pageIndex == 0)
            {
                //volta p tela de seleção de produtos e materiais
                if (MessageBox.Show("As alterações realizadas nos orçamentos serão perdidas. Deseja voltar para a seleção de produtos/materiais?","ATENÇÃO",MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    this.Close();    
                }
            }
            else
            {
                this.pageIndex--;
                this.lblFornecedor.Text = fornecedores[orcamentos.ElementAt(pageIndex).Key];
                this.loadGrid();
                if (this.pageIndex < (this.orcQty - 1))
                {
                    this.btnNext.Text = "Avançar >>>";
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
                    dataGridView1.Rows[e.RowIndex].ErrorText = "Quantidade inválida";
                    MessageBox.Show(this, "Quantidade inválida para o item: " + dataGridView1.Rows[e.RowIndex].Cells[2].Value, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                double temp = 0;
                if (!double.TryParse(e.FormattedValue.ToString(), out temp))
                {
                    dataGridView1.Rows[e.RowIndex].ErrorText = "Quantidade inválida";
                    MessageBox.Show(this, "Quantidade inválida para o item: " + dataGridView1.Rows[e.RowIndex].Cells[2].Value, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
        }
        
        
    }
}
