#region Referencias

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTPostgreNpgsql;

#endregion

namespace BibliotecaCadastrosBasicos
{
    public partial class CadDocumentoCopiaHistoricoForm : IWTBaseForm
    {
        readonly IWTPostgreNpgsqlConnection conn;
        readonly DocumentoCopiaClass copia;
        readonly TipoForm Tipo;
        public CadDocumentoCopiaHistoricoForm(ref DocumentoCopiaClass copia,TipoForm Tipo, IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            this.copia = copia;
            this.Tipo = Tipo;

            if (copia.Ocupada)
            {
                this.btnLiberar.Enabled = true;
                this.txtJustificativa.Enabled = true;
            }
            else
            {
                this.btnLiberar.Enabled = false;
                this.txtJustificativa.Enabled = false;
            }

            if (this.Tipo != TipoForm.Gerencial)
            {
                this.btnLiberar.Enabled = false;
            }


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



            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;


            List<OrdemProducaoDocumentoOpClass> documentoOps = new List<OrdemProducaoDocumentoOpClass>();
            foreach (OrdemProducaoDocumentoClass ordemProducaoDocumentoClass in this.copia.CollectionOrdemProducaoDocumentoClassDocumentoCopia)
            {
                documentoOps.AddRange(ordemProducaoDocumentoClass.CollectionOrdemProducaoDocumentoOpClassOrdemProducaoDocumento);
            }


            this.dataGridView1.DataSource = new AdvancedList<OrdemProducaoDocumentoOpClass>(documentoOps.OrderBy(a => a.OpData));





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

        private void Liberar()
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                if (
                    MessageBox.Show(this,
                                    "Você deseja liberar o documento para que ele seja utilizado em outras OP novas?",
                                    "Liberação de Documento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                    DialogResult.Yes)
                {

                    if (this.txtJustificativa.Text.Trim().Length < 10)
                    {
                        throw new Exception("A jsutificativa deve ter ao menos 10 caracteres válidos.");
                    }
                    command = this.conn.CreateCommand();
                    command.Transaction = this.conn.BeginTransaction();

                    copia.Liberar(ref command, this.txtJustificativa.Text.Trim());

                    command.Transaction.Commit();

                    this.Close();
                }
            }
            catch (Exception e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                throw new Exception("Erro ao liberar o documento.\r\n" + e.Message);
            }
        }


        #region Eventos
        private void btnLiberar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Liberar();
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
        #endregion
    }
}
