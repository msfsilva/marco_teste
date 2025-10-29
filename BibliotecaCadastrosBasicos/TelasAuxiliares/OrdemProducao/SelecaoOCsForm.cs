#region Referencias

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using BibliotecaEntidades.Operacoes.OrdemProducao;
using IWTDotNetLib;

#endregion

namespace BibliotecaCadastrosBasicos.TelasAuxiliares.OrdemProducao
{
    public partial class SelecaoOCsForm : IWTBaseForm
    {
        internal bool okPressed = false;
        public List<OrdemProducaoOc> OcsSelecionadas { get; private set; }
        BindingList<OrdemProducaoOc> ocsFiltradas;
        readonly List<OrdemProducaoOc> ocsOriginal;

        public SelecaoOCsForm(List<OrdemProducaoOc> ocs, TipoItemSelecao tipoItem)
        {


            InitializeComponent();

            ocs = ocs.Where(a => !a.opImpressa).ToList();

            this.ocsFiltradas = new BindingList<OrdemProducaoOc>(ocs);
            this.ocsOriginal = ocs;
            this.updateSearch();
            //this.initializeGrid();

            if (tipoItem == TipoItemSelecao.SomenteKit)
            {
                rdbKit.Checked = true;
                rdbNaoKit.Enabled = false;
                rdbNaoKit.Checked = false;
                rdbTodos.Enabled = false;

            }

            if (tipoItem == TipoItemSelecao.SomenteNaoKit)
            {
                rdbNaoKit.Checked = true;
                rdbKit.Enabled = false;
                rdbKit.Checked = false;
                rdbTodos.Enabled = false;

            }
            
        }

        private void initializeGrid()
        {
            dataGridView1.Columns.Clear();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ReadOnly = false;

            this.dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "Gerar";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Gerar";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].ReadOnly = false;

            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "oc";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "OC";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].ReadOnly = true;

            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "pos";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Pos";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].ReadOnly = true;

            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "codProduto";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Código Produto";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].ReadOnly = true;

            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "produtoCodigoAgrupador";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Agrupador";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].ReadOnly = true;

            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "Dimensao";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Dimensão";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].ReadOnly = true;

                
            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "descProduto";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Descrição Produto";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].ReadOnly = true;

            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "tipoDocumento";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Tipo Documento";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].ReadOnly = true;

            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "numeroDocumento";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Número Documento";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].ReadOnly = true;

            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "revDocumento";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Revisão Documento";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].ReadOnly = true;

            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "Cliente";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Produto";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].ReadOnly = true;


            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "dataEntrega";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Entrega";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].ReadOnly = true;

            this.dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "produtoCadastrado";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Produto Cadastrado";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].ReadOnly = true;

            this.dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "kit";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Kit";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].ReadOnly = true;

            this.dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "opImpressa";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Impressa";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].ReadOnly = true;

            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "dataImpressaoOp";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Data Impressão";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].ReadOnly = true;

            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "DocumentoMaisRestritivo";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Validação de Documento Mais Restritiva";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].ReadOnly = true;

            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "Feedback";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Feedback";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].ReadOnly = true;

            dataGridView1.DataSource = new AdvancedList<OrdemProducaoOc>(ocsFiltradas);

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = true;


            this.lblQuantidade.Text = "Qtd: " + this.ocsFiltradas.Count.ToString();
        }

        private void updateSearch()
        {
            ocsFiltradas = new BindingList<OrdemProducaoOc>();
            if (rdbNaoKit.Checked)
            {
                foreach (OrdemProducaoOc oc in this.ocsOriginal.Where(oc => !oc.kit))
                {
                    if (rdbAgrupadoresTodos.Checked)
                    {
                        this.ocsFiltradas.Add(oc);
                    }
                    else
                    {
                        if (rdbSomenteAgrupadores.Checked && !string.IsNullOrWhiteSpace(oc.produtoCodigoAgrupador))
                        {
                            this.ocsFiltradas.Add(oc);
                        }
                        else
                        {
                            if (rdbSomenteProdutos.Checked && string.IsNullOrWhiteSpace(oc.produtoCodigoAgrupador))
                            {
                                this.ocsFiltradas.Add(oc);
                            }
                        }
                    }
                }
            }

            if (rdbKit.Checked)
            {
                foreach (OrdemProducaoOc oc in this.ocsOriginal.Where(oc => oc.kit))
                {
                    if (rdbAgrupadoresTodos.Checked)
                    {
                        this.ocsFiltradas.Add(oc);
                    }
                    else
                    {
                        if (rdbSomenteAgrupadores.Checked && !string.IsNullOrWhiteSpace(oc.produtoCodigoAgrupador))
                        {
                            this.ocsFiltradas.Add(oc);
                        }
                        else
                        {
                            if (rdbSomenteProdutos.Checked && string.IsNullOrWhiteSpace(oc.produtoCodigoAgrupador))
                            {
                                this.ocsFiltradas.Add(oc);
                            }
                        }
                    }
                }
            }

            if (rdbTodos.Checked)
            {
                foreach (OrdemProducaoOc oc in this.ocsOriginal)
                {

                    if (rdbAgrupadoresTodos.Checked)
                    {
                        this.ocsFiltradas.Add(oc);
                    }
                    else
                    {
                        if (rdbSomenteAgrupadores.Checked && !string.IsNullOrWhiteSpace(oc.produtoCodigoAgrupador))
                        {
                            this.ocsFiltradas.Add(oc);
                        }
                        else
                        {
                            if (rdbSomenteProdutos.Checked && string.IsNullOrWhiteSpace(oc.produtoCodigoAgrupador))
                            {
                                this.ocsFiltradas.Add(oc);
                            }
                        }
                    }
                }
            }

            if (this.grbDataEntrega.Enabled)
            {
                ocsFiltradas = new BindingList<OrdemProducaoOc>(ocsFiltradas.Where(a => a.dataEntrega.Date >= dtpDataEntregaDe.Value.Date && a.dataEntrega.Date <= dtpDataEntregaAte.Value.Date).ToList());
            }


            if (!string.IsNullOrEmpty(this.txtBusca.Text.Trim()))
            {
                this.ocsFiltradas =
                    new BindingList<OrdemProducaoOc>(
                        this.ocsFiltradas.Where(a =>
                                                a.Cliente.ToLower().Contains(this.txtBusca.Text.Trim().ToLower()) ||
                                                a.codProduto.ToLower().Contains(this.txtBusca.Text.Trim().ToLower()) ||
                                                a.descProduto.ToLower().Contains(this.txtBusca.Text.Trim().ToLower()) ||
                                                a.numeroDocumento.ToLower().Contains(this.txtBusca.Text.Trim().ToLower()) ||
                                                a.oc.ToLower().Contains(this.txtBusca.Text.Trim().ToLower()) ||
                                                a.produtoCodigoAgrupador.ToLower().Contains(
                                                    this.txtBusca.Text.Trim().ToLower())
                            ).ToList()
                            );
            }

            this.initializeGrid();
        }


        private void marcarTodos(bool b)
        {
            for (int i = 0; i < this.ocsFiltradas.Count; i++)
            {
                this.ocsFiltradas[i].Gerar = b;
            }

            this.dataGridView1.Invalidate();

         }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            okPressed = false;
            this.Close();
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            okPressed = true;
            this.OcsSelecionadas = new List<OrdemProducaoOc>(this.ocsOriginal.Where(a => a.Gerar));
            this.Close();
        }

        private void rdbNaoKit_CheckedChanged(object sender, EventArgs e)
        {
            this.updateSearch();
        }

        private void rdbKit_CheckedChanged(object sender, EventArgs e)
        {
            this.updateSearch();
        }

        private void rdbTodos_CheckedChanged(object sender, EventArgs e)
        {
            this.updateSearch();
        }

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            timerBusca.Stop();
            timerBusca.Start();
        }

        private void timerBusca_Tick(object sender, EventArgs e)
        {
            try
            {
                this.timerBusca.Enabled = false;
                this.updateSearch();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkMarcarTodos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.marcarTodos(true);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }



        private void lnkDesmarcarTodos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.marcarTodos(false);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbSomenteAgrupadores_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.updateSearch();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbSomenteProdutos_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.updateSearch();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbAgrupadoresTodos_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.updateSearch();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpDataEntregaDe_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.updateSearch();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpDataEntregaAte_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.updateSearch();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkDataEntrega_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.grbDataEntrega.Enabled = this.chkDataEntrega.Checked;
                this.updateSearch();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
