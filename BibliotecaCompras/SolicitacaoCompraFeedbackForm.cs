using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaCompras
{
    public partial class SolicitacaoCompraFeedbackForm : IWTBaseForm
    {
        private readonly BibliotecaEntidades.Entidades.SolicitacaoCompraClass _solicitacaoCompra;

        public SolicitacaoCompraFeedbackForm(BibliotecaEntidades.Entidades.SolicitacaoCompraClass solicitacaoCompra)
        {
            _solicitacaoCompra = solicitacaoCompra;
            InitializeComponent();

            LoadGridFeedback();
        }


        private void LoadGridFeedback()
        {
            this.dgvFeedbacks.AutoGenerateColumns = false;
            this.dgvFeedbacks.Columns.Clear();

            this.dgvFeedbacks.Columns.Add(new DataGridViewTextBoxColumn());
            this.dgvFeedbacks.Columns[this.dgvFeedbacks.Columns.Count - 1].DataPropertyName = "Data";
            this.dgvFeedbacks.Columns[this.dgvFeedbacks.Columns.Count - 1].Name = "Data";
            this.dgvFeedbacks.Columns[this.dgvFeedbacks.Columns.Count - 1].HeaderText = "Data";
            this.dgvFeedbacks.Columns[this.dgvFeedbacks.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            this.dgvFeedbacks.Columns.Add(new DataGridViewTextBoxColumn());
            this.dgvFeedbacks.Columns[this.dgvFeedbacks.Columns.Count - 1].DataPropertyName = "AcsUsuario";
            this.dgvFeedbacks.Columns[this.dgvFeedbacks.Columns.Count - 1].Name = "AcsUsuario";
            this.dgvFeedbacks.Columns[this.dgvFeedbacks.Columns.Count - 1].HeaderText = "Responsável";
            this.dgvFeedbacks.Columns[this.dgvFeedbacks.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            this.dgvFeedbacks.Columns.Add(new DataGridViewTextBoxColumn());
            this.dgvFeedbacks.Columns[this.dgvFeedbacks.Columns.Count - 1].DataPropertyName = "Texto";
            this.dgvFeedbacks.Columns[this.dgvFeedbacks.Columns.Count - 1].Name = "Texto";
            this.dgvFeedbacks.Columns[this.dgvFeedbacks.Columns.Count - 1].HeaderText = "Feedback";
            this.dgvFeedbacks.Columns[this.dgvFeedbacks.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.dgvFeedbacks.Columns[this.dgvFeedbacks.Columns.Count - 1].Width = 350;

            this.dgvFeedbacks.DataSource = new AdvancedList<SolicitacaoCompraFeedbackClass>(this._solicitacaoCompra.CollectionSolicitacaoCompraFeedbackClassSolicitacaoCompra.OrderBy(a => a.Data));


        }

        private void NovoFeedback()
        {
            try
            {
                this.btnFeedbackAdicionar.Enabled = false;
                this.txtFeedback.Enabled = true;
                this.txtFeedback.Clear();
                this.btnFeedbackOk.Enabled = true;
                this.txtFeedback.Focus();

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao criar o novo feedback \r\n" + e.Message, e);
            }
        }

        private void NovoFeedbackInserir()
        {
            try
            {
                this._solicitacaoCompra.AdicionarFeedback(this.txtFeedback.Text);
                this._solicitacaoCompra.Save();

                this.LoadGridFeedback();

                this.btnFeedbackAdicionar.Enabled = true;
                this.txtFeedback.Enabled = false;
                this.txtFeedback.Clear();
                this.btnFeedbackOk.Enabled = false;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao incluir o novo feedback\r\n" + e.Message, e);
            }
        }

        private void FeedbackSelecionado()
        {
            try
            {
                if (this.dgvFeedbacks.SelectedRows.Count > 0)
                {
                    this.txtFeedback.Text = ((SolicitacaoCompraFeedbackClass)dgvFeedbacks.SelectedRows[0].DataBoundItem).Texto;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao selecionar o feedback\r\n" + e.Message, e);
            }
        }

        #region Eventos
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnFeedbackAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                this.NovoFeedback();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFeedbackOk_Click(object sender, EventArgs e)
        {
            try
            {
                this.NovoFeedbackInserir();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvFeedbacks_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                this.FeedbackSelecionado();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
