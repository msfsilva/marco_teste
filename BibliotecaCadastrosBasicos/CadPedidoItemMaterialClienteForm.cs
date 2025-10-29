#region Referencias

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using BibliotecaNotasFiscais;
using IWTDotNetLib;
using IWTLog;
using Newtonsoft.Json;

#endregion

namespace BibliotecaCadastrosBasicos
{
    public partial class CadPedidoItemMaterialClienteForm : IWTBaseForm
    {
        readonly List<LoteClass> lotesClienteDisponiveis;
        readonly PedidoItemClass Pedido;
        public CadPedidoItemMaterialClienteForm(PedidoItemClass Pedido, List<LoteClass> lotesClienteDisponiveis)
        {
            InitializeComponent();
            this.lotesClienteDisponiveis = lotesClienteDisponiveis;
            this.Pedido = Pedido;
            this.initializeGrid();
        }

        private void initializeGrid()
        {
            try
            {
                dataGridView1.Columns.Clear();

                dataGridView1.AutoGenerateColumns = false;


                this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "Lote";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].Name = "Lote";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Lote";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "Quantidade";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].Name = "Quantidade";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Quantidade";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


                this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "SaldoDevolucao";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].Name = "SaldoDevolucao";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Saldo de Devolução";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


                this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "OpsUtilizandoPedidoLoteString";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].Name = "OpsUtilizandoPedidoLoteString";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "OPs Utilizando";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;



                dataGridView1.DataSource = this.Pedido.CollectionPedidoItemLoteClienteClassPedidoItem;

                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.MultiSelect = false;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar o grid.\r\n" + e.Message, e);
            }
        }

        private void OK()
        {
            this.Close();
        }

        private void Adicionar()
        {
            try
            {
                List<LoteClass> lotesTmp = this.lotesClienteDisponiveis.Where(lote => lote.SaldoVinculoPedido > 0 && this.Pedido.CollectionPedidoItemLoteClienteClassPedidoItem.All(a => a.Lote != lote)).ToList();


                CadPedidoItemMaterialClienteItemForm form = new CadPedidoItemMaterialClienteItemForm(ref lotesTmp);
                form.ShowDialog();

                if (!form.cancelar)
                {

             

                    this.Pedido.AddLoteCliente(form.LoteSelecionado, form.Quantidade);


                    this.initializeGrid();
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao adicionar o lote.\r\n" + e.Message, e);
            }
        }

        private void Excluir()
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show(this, "Deseja excluir o item selecionado?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        PedidoItemLoteClienteClass lote = (PedidoItemLoteClienteClass)this.dataGridView1.SelectedRows[0].DataBoundItem;
                        this.Pedido.ExcluirLoteCliente(lote);
                        this.initializeGrid();
                    }
                }
                else
                {
                    throw new Exception("Selecione o lote a ser excluido.");
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao excluir o lote.\r\n" + e.Message, e);
            }
        }




        #region Eventos
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.OK();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                this.Excluir();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Adicionar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
