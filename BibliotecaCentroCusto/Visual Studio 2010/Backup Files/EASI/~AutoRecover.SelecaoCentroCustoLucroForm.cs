#region Referencias

using System;
using System.Windows.Forms;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;

#endregion

namespace BibliotecaCentroCusto
{
    public partial class SelecaoCentroCustoLucroForm : Form
    {
        readonly CentroCustoLucroNatureza TipoSelecao;
        readonly IWTPostgreNpgsqlConnection _conn;

        public CentroCustoLucroClass CentroSelecionado { get; private set; }

        public SelecaoCentroCustoLucroForm(CustoLucro tipoSelecao, IWTPostgreNpgsqlConnection conn)
        {

            InitializeComponent();
            this.TipoSelecao = tipoSelecao;
            this._conn = conn;

            switch (tipoSelecao)
            {
                case CustoLucro.Custo:
                    this.Text += "Custo";
                    break;
                case CustoLucro.Lucro:
                    this.Text += "Lucro";
                    break;
                default:
                    throw new ArgumentOutOfRangeException("tipoSelecao");
            }

            this.loadCentroCustos();

        }

        private void loadCentroCustos()
        {
            try
            {
                IWTPostgreNpgsqlCommand command = this._conn.CreateCommand();
                command.CommandText =
                    "SELECT  " +
                    "  public.centro_custo_lucro.id_centro_custo_lucro " +
                    "FROM " +
                    "  public.centro_custo_lucro " +
                    "WHERE " +
                    "  public.centro_custo_lucro.id_centro_custo_lucro_pai IS NULL AND " +
                    "  (public.centro_custo_lucro.ccl_natureza = :ccl_natureza OR public.centro_custo_lucro.ccl_natureza = -1 )";

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ccl_natureza", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.TipoSelecao);
                NpgsqlDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    this.treeView1.Nodes.Add(new CentroCustoLucroClass(Convert.ToInt32(read["id_centro_custo_lucro"]), null,this.TipoSelecao, this._conn));
                }
                read.Close();

                this.treeView1.TreeViewNodeSorter = new CentroCustoLucroNodeSorter();
                this.treeView1.Sort();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Selecionar()
        {
            try
            {
                if (this.treeView1.SelectedNode == null)
                {
                    throw new Exception("Selecione um centro de custo/lucro antes de continuar.");
                }

                if (((CentroCustoLucroClass)treeView1.SelectedNode).Filhos.Count > 0)
                {
                    throw new Exception("Você deve selecionar um centro de custo/lucro que não possua filhos antes de continuar.");
                }

                this.CentroSelecionado = (CentroCustoLucroClass) this.treeView1.SelectedNode;
                this.Close(); 

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao Selecionar\r\n" + e.Message, e);
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


    }
}
