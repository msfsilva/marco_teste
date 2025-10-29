using System;
using System.Data;
using System.Windows.Forms;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using dbProvider;

namespace BibliotecaCompras
{
    public partial class SelecaoCompradorForm : IWTBaseForm
    {


        public int? CompradorSelecionado { get; private set; }

        public SelecaoCompradorForm()
        {
            InitializeComponent();

        }


        private void initializeGrid()
        {
            try
            {
                string sql =
                "SELECT  " +
                "  public.comprador.id_comprador, " +
                "  public.comprador.com_apelido, " +
                "  public.comprador.com_nome, " +
                "  public.comprador.com_email " +
                "FROM " +
                "  public.comprador " +
                "WHERE " +
                "  public.comprador.id_acs_usuario  = " + LoginClass.UsuarioLogado.loggedUser.ID + " " +
                "ORDER BY " +
                "  public.comprador.com_apelido, " +
                "  public.comprador.com_nome ";

                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, DbConnection.Connection);

                DataSet ds = new DataSet();
                adapter.Fill(ds);

                BindingSource binding = new BindingSource { DataSource = ds.Tables[0] };
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = binding;

                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.MultiSelect = true;

                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[0], "", 0, DataGridViewAutoSizeColumnMode.AllCells, false);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[1], "Apelido", 80, DataGridViewAutoSizeColumnMode.AllCells, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[2], "Nome", 140, DataGridViewAutoSizeColumnMode.AllCells, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[3], "Email", 100, DataGridViewAutoSizeColumnMode.AllCells, true);



            }
            catch (Exception e)
            {
                throw new Exception("Erro ao montar a listagem de compradores\r\n" + e.Message, e);
            }
        }

        private void Selecionar()
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count == 0)
                    return;
                
                
                this.CompradorSelecionado = this.dataGridView1.SelectedRows[0].Cells["id_comprador"].Value as int?;
                this.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao selecionar o comprador.\r\n" + e.Message, e);
            }
        }


        #region Eventos
        private void SelecaoCompradorForm_Shown(object sender, EventArgs e)
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
       

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.Selecionar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}