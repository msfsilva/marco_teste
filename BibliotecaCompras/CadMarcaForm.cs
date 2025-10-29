#region Referencias

using System;
using System.Windows.Forms;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;

#endregion

namespace BibliotecaCompras
{
    public partial class CadMarcaForm : IWTBaseForm
    {
      IWTPostgreNpgsqlConnection conn;
        int? id;
        public CadMarcaForm(IWTPostgreNpgsqlConnection conn, int? id)
        {
            this.initForm(conn, id, false);
        }

        public CadMarcaForm(IWTPostgreNpgsqlConnection conn, int? id, bool somenteVisualizacao)
        {
            this.initForm(conn, id, somenteVisualizacao);
        }

        private void initForm(IWTPostgreNpgsqlConnection conn, int? id, bool somenteVisualizacao)
        {
            InitializeComponent();
            this.conn = conn;
            this.id = id;

            if (this.id != null)
            {
                this.loadEdit();
            }

            if (somenteVisualizacao)
            {
                foreach (Control c in this.Controls)
                {
                    c.Enabled = false;
                }
            }
        }

        private void loadEdit()
        {
            try
            {
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText =
                    "SELECT  " +
                    "  id_marca, "+
                    "  mar_identificacao, "+
                    "  mar_descricao "+
                    "FROM  "+
                    "  public.marca "+
                    "WHERE " +
                    "  id_marca = " + this.id;

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                if (read.HasRows)
                {
                    read.Read();

                    this.txtIdentificacao.Text = read["mar_identificacao"].ToString();
                    this.txtDescricao.Text = read["mar_descricao"].ToString();

                    read.Close();
                }
                else
                {
                    throw new Exception("ID Inválido: " + this.id);
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para edição.\r\n" + e.Message);
            }
        }

        private void Salvar()
        {
            try
            {
                this.validateRequiredFields();

                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();

                if (id == null)
                {
                    command.CommandText =
                    "INSERT INTO  " +
                    "  public.marca "+
                    "( "+
                    "  mar_identificacao, "+
                    "  mar_descricao "+
                    ")  "+
                    "VALUES ( "+
                    "  :mar_identificacao, "+
                    "  :mar_descricao "+
                    ");";
                }
                else
                {
                    command.CommandText =
                    "UPDATE  " +
                    "  public.marca   "+
                    "SET  "+
                    "  mar_identificacao = :mar_identificacao, "+
                    "  mar_descricao = :mar_descricao "+
                    "WHERE  "+
                    "  id_marca = :id_marca "+
                    ";";
                }

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_marca", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = id;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mar_identificacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.txtIdentificacao.Text.Trim();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mar_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.txtDescricao.Text.Trim();

                command.ExecuteNonQuery();


                this.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar.\r\n" + e.Message);
            }
        }

        private void validateRequiredFields()
        {
            try
            {
                if (this.txtIdentificacao.Text.Trim().Length == 0)
                {
                    throw new Exception("Campo de Identificação é obrigatório.");
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao validar os campos obrigatórios.\r\n" + e.Message);
            }
        }

        #region Eventos
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Salvar();
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
