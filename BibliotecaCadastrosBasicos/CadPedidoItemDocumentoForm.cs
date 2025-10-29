using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadPedidoItemDocumentoForm : IWTBaseForm
    {
        private PedidoItemClass Pedido;
        public CadPedidoItemDocumentoForm(PedidoItemClass pedido)
        {
            InitializeComponent();
            this.Pedido = pedido;
            this.initializeCombo();

            
        }

        private void initializeCombo()
        {
            try
            {
                List<PedidoItemClass> itens = new List<PedidoItemClass>();
                itens.Add(Pedido);
                itens.AddRange(Pedido.CollectionPedidoItemClassPedidoItemPai);

                this.cmbItem.DataSource = itens;
                this.cmbItem.DisplayMember = "Produto";
                this.cmbItem.ValueMember = "ID";
                this.cmbItem.autoSize = true;
                this.cmbItem.Table = itens;
                this.cmbItem.ColumnsToDisplay = new[] { "SubLinha", "Produto" };
                this.cmbItem.HeadersToDisplay = new string[] { "SubLinha", "Produto" };
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar o combo de itens.\r\n" + e.Message, e);
            }
        }

        private void initializeGrid()
        {
            try
            {
                this.dataGridView1.AutoGenerateColumns = false;
                List<PedidoDocumentoClass> docs = new List<PedidoDocumentoClass>(this.Pedido.CollectionPedidoDocumentoClassPedidoItem);
                docs.AddRange(this.Pedido.CollectionPedidoItemClassPedidoItemPai.SelectMany(a => a.CollectionPedidoDocumentoClassPedidoItem));

                this.dataGridView1.DataSource = docs;
            }
            catch (ExcecaoTratada e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("\r\n" + e.Message, e);
            }
        }

        private void selecionarLinha()
        {
            try
            {
                PedidoDocumentoClass selecionado = (PedidoDocumentoClass) ((IWTDataGridViewRow) this.dataGridView1.SelectedRows[0]).DataBoundItem;
                this.cmbItem.SelectedItem = selecionado.PedidoItem;
                this.txtFamilia.Text = selecionado.Tipo;
                this.txtIdentificacao.Text = selecionado.Codigo;
                this.txtRevisao.Text = selecionado.Revisao;
            }
            catch (ExcecaoTratada e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao selecionar a linha do grid\r\n" + e.Message, e);
            }
        }

        private void AdicionarAtualizar()
        {
            try
            {
                if (this.cmbItem.SelectedItem == null)
                {
                    throw new ExcecaoTratada("A seleção do item do pedido é obrigatória");
                }

                if (string.IsNullOrWhiteSpace(this.txtFamilia.Text))
                {
                    throw new ExcecaoTratada("O Valor da familia é obrigatório");
                }

                if (string.IsNullOrWhiteSpace(this.txtIdentificacao.Text))
                {
                    throw new ExcecaoTratada("O Valor da identificacao é obrigatório");
                }

                if (string.IsNullOrWhiteSpace(this.txtRevisao.Text))
                {
                    throw new ExcecaoTratada("O Valor da revisao é obrigatório");
                }

                PedidoItemClass itemSelecionado = (PedidoItemClass) this.cmbItem.SelectedItem;

                itemSelecionado.AtualizarIncluirDocumento(this.txtFamilia.Text.Trim(), this.txtIdentificacao.Text.Trim(), this.txtRevisao.Text.Trim());
                initializeGrid();
            }
            catch (ExcecaoTratada e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao atualizar/adicionar o documento no item do pedido\r\n" + e.Message, e);
            }
        }

        private void Excluir()
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count == 0) throw new ExcecaoTratada("Selecione ao menos um documento para ser excluído");
                if (MessageBox.Show(this, "Deseja excluir os itens selecionados?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

                foreach (IWTDataGridViewRow row in this.dataGridView1.SelectedRows)
                {
                    PedidoDocumentoClass selecionado = (PedidoDocumentoClass) row.DataBoundItem;
                    this.Pedido.ExcluirDocumentoPedido(selecionado);
                }

                initializeGrid();
            }
            catch (ExcecaoTratada e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao excluir o documento do pedido\r\n" + e.Message, e);
            }
        }


        #region Eventos

        private void CadPedidoDocumentoForm_Shown(object sender, EventArgs e)
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.selecionarLinha();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                this.AdicionarAtualizar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void btnFechar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

 
        #endregion

       

      

    }
}
