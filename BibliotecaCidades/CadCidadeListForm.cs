using System;
using System.Data;
using System.Windows.Forms;
using IWTFormsLib;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;

namespace BibliotecaCidades
{
    public partial class CadCidadeListForm : IWTListForm
    {

        public CadCidadeListForm(IWTPostgreNpgsqlConnection conn)
            : base(conn)
        {
            InitializeComponent();
        }

        #region Overrides of IWTListForm

        protected override IWTPostgreNpgsqlAdapter getAdapter()
        {
            return new IWTPostgreNpgsqlAdapter(
                "SELECT  "+
                "  public.cidade.id_cidade, " +
                "  public.cidade.cid_nome, "+
                "  public.cidade.cid_codigo_ibge, "+
                "  public.estado.est_sigla "+
                "FROM "+
                "  public.cidade "+
                "  INNER JOIN public.estado ON (public.cidade.id_estado = public.estado.id_estado) "+
                "ORDER BY "+
                "  public.estado.est_sigla, "+
                "  public.cidade.cid_nome",
                this.Conn
                );
        }

        protected override void formatColumns(DataGridViewColumnCollection Columns)
        {
            IWTFunctions.IWTFunctions.setGridColumn(Columns[0], "", 0, DataGridViewAutoSizeColumnMode.AllCells, false);
            IWTFunctions.IWTFunctions.setGridColumn(Columns[1], "Cidade", 200, DataGridViewAutoSizeColumnMode.AllCells, true);
            IWTFunctions.IWTFunctions.setGridColumn(Columns[2], "Cód. IBGE", 100, DataGridViewAutoSizeColumnMode.AllCells, true);
            IWTFunctions.IWTFunctions.setGridColumn(Columns[3], "Estado", 60, DataGridViewAutoSizeColumnMode.AllCells, true);

        }

        protected override string getStringBusca()
        {
            return "cid_nome LIKE '%" + this.getValorCampoBusca() + "%' OR Convert(cid_codigo_ibge,  'System.String') = '%" + this.getValorCampoBusca() + "%'  OR est_sigla LIKE '%" + this.getValorCampoBusca() + "%' ";
        }

        protected override void Novo()
        {
            try
            {
                CadCidadeForm form = new CadCidadeForm(this.Conn, null);
                form.ShowDialog();
                this.initializeGrid();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao cadastrar um novo item.\r\n" + e.Message);
            }
        }

        protected override void Editar()
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    int? id = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells["id_cidade"].Value);

                    CadCidadeForm form = new CadCidadeForm(this.Conn, id);
                    form.ShowDialog();
                    this.initializeGrid();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao editar o item.\r\n" + e.Message);
            }
        }

        protected override void Excluir()
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {

                    if (MessageBox.Show(this, "Você deseja excluir o item selecionado?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells["id_cidade"].Value);
                        IWTPostgreNpgsqlCommand command = this.Conn.CreateCommand();
                        command.CommandText =
                            "DELETE FROM  " +
                            "  public.cidade  " +
                            "WHERE  " +
                            "  id_cidade = :id_cidade " +
                            "; ";
                        command.Parameters.Clear();
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_cidade", NpgsqlDbType.Integer));
                        command.Parameters[command.Parameters.Count - 1].Value = id;

                        command.ExecuteNonQuery();

                        this.initializeGrid();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    throw new Exception("Selecione a linha que você deseja excluir.");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao excluir o item selecionado.\r\n" + e.Message);
            }
        }

        #endregion
    }

}
