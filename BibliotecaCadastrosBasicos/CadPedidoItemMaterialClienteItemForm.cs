#region Referencias

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib;

#endregion

namespace BibliotecaCadastrosBasicos
{
    public partial class CadPedidoItemMaterialClienteItemForm : IWTBaseForm
    {
        public LoteClass LoteSelecionado = null;
        public double Quantidade = 0;
        readonly BindingList<LoteClass> lotesDisponiveis;

        internal bool cancelar{get;private set;}

        bool loading = false;
        public CadPedidoItemMaterialClienteItemForm(ref List<LoteClass> lotesDisponiveis)
        {
            this.cancelar = true;

            InitializeComponent();
            this.lotesDisponiveis = new BindingList<LoteClass>(lotesDisponiveis);
            this.loadComboLotes();

        }

        private void loadComboLotes()
        {
            try
            {
                this.loading = true;

                this.cmbLote.DataSource = lotesDisponiveis;
                this.cmbLote.ValueMember = "ID";
                this.cmbLote.DisplayMember = "Numero";
                this.cmbLote.autoSize = true;
                this.cmbLote.Table = lotesDisponiveis;
                this.cmbLote.ColumnsToDisplay = new string[]
                                                    {
                                                        "Numero", "MaterialProduto", "SaldoVinculoPedido", "NfNumero", "NfData", "FornecedorCliente"
                                                    };
                this.cmbLote.HeadersToDisplay = new string[]
                                                    {"Numero", "Item", "Saldo de Vínculo", "Nota Fiscal", "Data NF", "Cliente"};

                this.loading = false;
                this.selecionaLote();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os lotes para inclusão.\r\n" + e.Message, e);
            }
        }

        private void selecionaLote()
        {
            try
            {
                if (!this.loading)
                {
                    if (this.cmbLote.SelectedItem != null)
                    {
                        this.nudQuantidade.Maximum = Convert.ToDecimal(((LoteClass) cmbLote.SelectedItem).SaldoDevolucao);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("\r\n" + e.Message, e);
            }
        }

        private void OK()
        {
            try
            {
                if (this.cmbLote.SelectedItem == null)
                {
                    throw new Exception("Selecione um lote antes de continuar.");
                }

                
                this.LoteSelecionado = (LoteClass) this.cmbLote.SelectedItem;
                this.Quantidade = Convert.ToDouble(this.nudQuantidade.Value);

                this.cancelar = false;
                this.Close();

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao registrar os dados.\r\n" + e.Message, e);
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.cancelar = true;
                this.Close();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
     
        private void cmbLote_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.selecionaLote();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

     
    }
}
