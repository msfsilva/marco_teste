#region Referencias

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using IWTCustomControls;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using Npgsql;

#endregion

namespace BibliotecaWhereUsed
{
    public partial class WhereUsedReportForm : Form
    {
        readonly WhereUsedReport rep;
        public WhereUsedReportForm(IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            this.rep = new WhereUsedReport(conn);
        }

        private void initializeGrid()
        {
            try
            {
                if (this.txtBusca.Text.Trim().Length < 3)
                {
                    this.dataGridView1.Columns.Clear();
                    return;
                }

                WhereUsedTipo tipo = WhereUsedTipo.Material;

                if (this.rdbMaterial.Checked)
                {
                    tipo = WhereUsedTipo.Material;
                }

                if (this.rdbProdutos.Checked)
                {
                    tipo = WhereUsedTipo.Produto;
                }

                if (this.rdbDocumentos.Checked)
                {
                    tipo = WhereUsedTipo.Documento ;
                }

                if (this.rdbRecursos.Checked)
                {
                    tipo = WhereUsedTipo.Recurso;
                }

                if (this.rdbAcabamento.Checked)
                {
                    tipo = WhereUsedTipo.Acabamento;
                }

                if (this.rdbFornecedores.Checked)
                {
                    tipo = WhereUsedTipo.Fornecedor;
                }

                if (this.rdbPostos.Checked)
                {
                    tipo = WhereUsedTipo.PostoTrabalho;
                }

                

                List<WhereUsedItem> ds = this.rep.gerarRelatorio(tipo, this.txtBusca.Text.Trim());

                this.dataGridView1.Columns.Clear();

                this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "itemBuscaCodigoInterno";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].Name = "itemBuscaCodigoInterno";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Item encontrado - Código Interno";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "itemBusca";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].Name = "itemBusca";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Item encontrado";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                
                if (tipo == WhereUsedTipo.Produto || tipo == WhereUsedTipo.Material)
                {
                    this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                    this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "itemBuscaUltimoPrecoCompra";
                    this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].Name = "itemBuscaUltimoPrecoCompra";
                    this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Item encontrado - Ultimo Preço Compra ";
                    this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                
                if (tipo == WhereUsedTipo.PostoTrabalho)
                {
                    this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                    this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "itemBuscaUnidadeMedida";
                    this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].Name = "itemBuscaUnidadeMedida";
                    this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Item encontrado - Informações Complementares ";
                    this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

                

                this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "Tipo";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].Name = "Tipo";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Utilizado em - Tipo";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "utilizadoEmIdentificacao";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].Name = "utilizadoEmIdentificacao";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Utilizado em - Identificação";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                if (tipo != WhereUsedTipo.PostoTrabalho)
                {
                    this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                    this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "utilizadoEmQtdCompleto";
                    this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].Name = "utilizadoEmQtdCompleto";
                    this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Utilizado em - Quantidade";
                    this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                }
                this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "utilizadoEmDescricao";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].Name = "utilizadoEmDescricao";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Utilizado em - Descrição";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


                
                

                this.dataGridView1.AutoGenerateColumns = false;
                this.dataGridView1.DataSource = new AdvancedList<WhereUsedItem>(ds);

            }
            catch (Exception e)
            {
                throw new Exception("\r\n" + e.Message, e);
            }
        }

        #region Eventos
        private void rdbMaterial_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.initializeGrid();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void rdbProdutos_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.initializeGrid();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void rdbDocumentos_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.initializeGrid();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void rdbRecursos_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.initializeGrid();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void rdbAcabamento_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.initializeGrid();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = false;
                this.initializeGrid();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       

        private void rdbFornecedores_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.initializeGrid();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
        private void rdbPostos_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.initializeGrid();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }
}
