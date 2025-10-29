using System;
using System.Data;
using System.Windows.Forms;
using IWTFormsLib;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;

namespace BibliotecaCidades
{
    public partial class CadCidadeForm : IWTForm
    {

        public CadCidadeForm(IWTPostgreNpgsqlConnection conn, int? id, bool somenteVisualizacao)
            : base(conn, id, somenteVisualizacao)
        {
            InitializeComponent();
            this.initializeGridEstados();
        }

        public CadCidadeForm(IWTPostgreNpgsqlConnection conn, int? id)
            : base(conn, id)
        {
            InitializeComponent();
            this.initializeGridEstados();
        }

        #region Overrides of IWTForm

        protected override void loadEdit()
        {
            try
            {
                IWTPostgreNpgsqlCommand command = this.Conn.CreateCommand();
                command.CommandText =
                    "SELECT  " +
                    "  cid_nome, " +
                    "  cid_codigo_ibge, " +
                    "  id_estado " +
                    "FROM " +
                    "  public.cidade " +
                    "WHERE " +
                    "  id_cidade = " + this.Id;

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                if (read.HasRows)
                {
                    read.Read();

                    this.txtNome.Text = read["cid_nome"].ToString();
                    this.nudCodigoIBGE.Value = Convert.ToInt32(read["cid_codigo_ibge"].ToString());
                    this.cmbEstado.SelectedValue = read["id_estado"];

                    read.Close();
                }
                else
                {
                    throw new Exception("ID Inválido: " + this.Id);
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para edição.\r\n" + e.Message);
            }
        }

        protected override void validateRequiredFields()
        {
            try
            {
                if (this.txtNome.Text.Trim().Length == 0)
                {
                    throw new Exception("Campo de Nome é obrigatório.");
                }


                if (this.cmbEstado.Enabled && this.cmbEstado.SelectedValue == null)
                {
                    throw new Exception("Campo de Estado é obrigatório.");
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao validar os campos obrigatórios.\r\n" + e.Message);
            }
        }

        protected override string getInsertQuery()
        {
            return
                "INSERT INTO  " +
                "  public.cidade " +
                "( " +
                "  cid_nome, " +
                "  cid_codigo_ibge, " +
                "  id_estado " +
                ")  " +
                "VALUES ( " +
                "  :cid_nome, " +
                "  :cid_codigo_ibge, " +
                "  :id_estado " +
                "); ";
        }

        protected override string getUpdateQuery()
        {
            return
                "UPDATE  " +
                "  public.cidade   " +
                "SET  " +
                "  cid_nome = :cid_nome, " +
                "  cid_codigo_ibge = :cid_codigo_ibge, " +
                "  id_estado = :id_estado " +
                "WHERE  " +
                "  id_cidade = :id_cidade " +
                "; ";
        }

        protected override void fillParameters(IWTPostgreNpgsqlCommandParameterCollection parameters)
        {
            parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_cidade", NpgsqlDbType.Integer));
            parameters[parameters.Count - 1].Value = this.Id;
            parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_estado", NpgsqlDbType.Integer));
            parameters[parameters.Count - 1].Value = this.cmbEstado.SelectedValue;
            parameters.Add(new IWTPostgreNpgsqlCommandParameter("cid_nome", NpgsqlDbType.Varchar));
            parameters[parameters.Count - 1].Value = this.txtNome.Text;
            parameters.Add(new IWTPostgreNpgsqlCommandParameter("cid_codigo_ibge", NpgsqlDbType.Integer));
            parameters[parameters.Count - 1].Value = this.nudCodigoIBGE.Value;
        }

        #endregion


        private void initializeGridEstados()
        {
            try
            {
                const string sql = "SELECT  " +
                                    "  public.estado.id_estado, " +
                                    "  public.estado.est_sigla, " +
                                    "  public.estado.est_nome " +
                                    "FROM " +
                                    "  public.estado " +
                                    "ORDER BY " +
                                    "  public.estado.est_sigla, " +
                                    "  public.estado.est_nome ";


                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.Conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                BindingSource binding = new BindingSource { DataSource = ds.Tables[0] };
                this.cmbEstado.DataSource = binding;
                this.cmbEstado.ValueMember = "id_estado";
                this.cmbEstado.DisplayMember = "est_sigla";
                this.cmbEstado.autoSize = true;
                this.cmbEstado.Table = ds.Tables[0];
                this.cmbEstado.ColumnsToDisplay = new[] { "est_sigla", "est_nome" };
                this.cmbEstado.HeadersToDisplay = new[] { "Sigla", "Nome" };

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção do estado.\r\n" + e.Message);
            }
        }

    }
}