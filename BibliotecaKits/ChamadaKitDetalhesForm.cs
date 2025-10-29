#region Referencias

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using ModuloAcompanhamentoPedidos;

#endregion

namespace ModuloKits
{
    public partial class ChamadaKitDetalhesForm : IWTBaseForm
    {
        public bool continuar = false;
        public List<KitClass> ListOcs { get; }
        private List<KitClass> _ocsFiltradas;
        private bool kit;
        readonly IWTPostgreNpgsqlConnection _conn;

        public ChamadaKitDetalhesForm(ref List<KitClass> listOcs, bool kit, IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            this._conn = conn;
            this.ListOcs = listOcs;
            this.kit = kit;
            this.InitializeGrid();
            
            this.confScreen();
            
        }

        private void confScreen()
        {
            /*if (this.kit)
            {
                this.btnContinuar.Enabled = true;
            }
            else
            {
                this.btnContinuar.Enabled = false;
            }*/

        }

        private void InitializeGrid(string filtro = null)
        {
            this.dataGridView1.Columns.Clear();
            this.dataGridView1.AutoGenerateColumns = false;

            this.dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "Imprimir";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Imprimir";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].ReadOnly = false;

            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "dataEntrega";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Data Entrega";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "modeloKit";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Kit";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            if (!kit)
            {
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].Visible = false;
            }

            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "oc";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "OC";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].Name = "oc";

            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "pos";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Pos";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].Name = "pos";

            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "item";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Item";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "itemCliente";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Item Cliente";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "Projeto";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Projeto";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "cliente";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Cliente";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "classificacao";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Classificação";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "situacao";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Situação do Pedido";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "pallet";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Pallet";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "embarque";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Embarque";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "dataImpressao";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Data da Impressão";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "urgente";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Urgente";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "urgetenteDataPrometida";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Urgente Data Prometida";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "idCliente";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].Name = "idCliente";
            this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].Visible = false;

            if (string.IsNullOrEmpty(filtro))
            {
                this._ocsFiltradas = ListOcs;
            }
            else
            {

                filtro = filtro.ToUpperInvariant();
                this._ocsFiltradas = this.ListOcs.Where(a =>
                    a.cliente.ToUpperInvariant().Contains(filtro) ||
                    a.Projeto.ToUpperInvariant().Contains(filtro) ||
                    a.classificacao.ToUpperInvariant().Contains(filtro) ||
                    a.embarque.ToUpperInvariant().Contains(filtro) ||
                    a.item.ToUpperInvariant().Contains(filtro) ||
                    a.itemCliente.ToUpperInvariant().Contains(filtro) ||
                    a.modeloKit.ToUpperInvariant().Contains(filtro) ||
                    a.oc.ToUpperInvariant().Contains(filtro) ||
                    a.pallet.ToUpperInvariant().Contains(filtro) ||
                    a.situacao.ToUpperInvariant().Contains(filtro) ||
                    a.urgente.ToUpperInvariant().Contains(filtro)
                ).ToList();
            }

            this._ocsFiltradas.Sort(new KitClassComparer());
            this.dataGridView1.DataSource = new AdvancedList<KitClass>(this._ocsFiltradas);
        }

        private void MarcarTodos(bool b)
        {
            for (int i = 0; i < this._ocsFiltradas.Count; i++)
            {
                this._ocsFiltradas[i].Imprimir = b;
            }

            this.dataGridView1.Invalidate();

        }


        #region Eventos
        private void btnContinuar_Click(object sender, EventArgs e)
        {
            this.continuar = true;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.continuar = false;
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
           
                    string oc = this.dataGridView1.Rows[e.RowIndex].Cells["oc"].Value.ToString();
                    int pos = Convert.ToInt32(this.dataGridView1.Rows[e.RowIndex].Cells["pos"].Value);
                    long idCliente = Convert.ToInt64(this.dataGridView1.Rows[e.RowIndex].Cells["idCliente"].Value);
                    RastreamentoProducaoForm form = new RastreamentoProducaoForm(oc, pos, idCliente, this._conn);
                    form.ShowDialog();
           
            }
            catch (Exception a)
            {
                MessageBox.Show(this, "Erro ao exibir o rastreamento.\r\n" + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkMarcarTodos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.MarcarTodos(true);
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
                this.MarcarTodos(false);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBusca_OperacaoBuscaEncerrada(object sender, string valor)
        {
            try
            {
                this.InitializeGrid(valor);
            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion


    }
}
