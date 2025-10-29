using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadFuncaoForm : IWTForm
    {
        public CadFuncaoForm(FuncaoClass funcao, CadFuncaoListForm listForm)
            : base(funcao, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
        }

        public CadFuncaoForm(FuncaoClass funcao)
            : base(funcao, typeof(FuncaoClass), LoginClass.UsuarioLogado.loggedUser,null)
        {
            InitializeComponent();
        }

        private void initializeGrid()
        {
            this.dgvEpis.DataSource = null;
            //this.dgvEpis.ResetBindings();
            this.dgvEpis.AutoGenerateColumns = false;
            this.dgvEpis.DataSource = new AdvancedList<FuncaoEpiClass>(((FuncaoClass)this.Entity).CollectionFuncaoEpiClassFuncao);
            this.dgvEpis.Refresh();

            //ListSortDirection ls = ListSortDirection.Ascending;
            //if (this.dgvEpis.SortOrder == SortOrder.Descending)
            //{
            //    ls = ListSortDirection.Descending;
            //}

            //this.dgvEpis.Sort(this.dgvEpis.SortedColumn ?? this.dgvEpis.Columns[0], ls);
        }

        private void btnAddEpi_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbEpi.SelectedItem != null)
                {
                    ((FuncaoClass) this.Entity).addEpi((EpiClass)this.cmbEpi.SelectedItem);
                    this.initializeGrid();
                }
                else
                {
                    throw new Exception("Selecione um Epi para ser adicionado.");
                }
                
            }
            catch (Exception a)
            {
                MessageBox.Show("Erro ao adicionar Epi.\r\n" + a.Message, "Adicionar Epi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoverEpi_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in this.dgvEpis.SelectedRows)
                {
                    ((FuncaoClass)this.Entity).removeEpi((FuncaoEpiClass)row.DataBoundItem);
                }
                initializeGrid();
            }
            catch (Exception a)
            {
                MessageBox.Show("Erro ao remover Epi.\r\n" + a.Message, "Remover Epi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void loadComboEpi()
        {
            try
            {
                EpiClass search = new EpiClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<EpiClass> epis =
                    search.Search(new List<SearchParameterClass>() { new SearchParameterClass("epi_identificacao", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String) }).ConvertAll(a => (EpiClass)a);

                this.cmbEpi.DataSource = epis;
                this.cmbEpi.DisplayMember = "Identificacao";
                this.cmbEpi.ValueMember = "ID";
                this.cmbEpi.autoSize = true;
                this.cmbEpi.Table = epis;
                this.cmbEpi.ColumnsToDisplay = new[] { "Identificacao", "Descricao" };
                this.cmbEpi.HeadersToDisplay = new[] { "Identificação", "Descrição" };



            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção de Estados.\r\n" + e.Message);
            }
        }

        private void CadFuncaoForm_Shown(object sender, EventArgs e)
        {
            try
            {
                //base.OnShown(e);
                this.loadComboEpi();
                this.initializeGrid();
                
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvEpis_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
         

    }
}
