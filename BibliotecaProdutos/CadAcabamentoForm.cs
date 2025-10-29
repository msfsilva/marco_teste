#region Referencias

using System;
using System.Data;
using System.Windows.Forms;
using BibliotecaControleRevisao;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;
using ComplexLoginModule;

#endregion

namespace BibliotecaProdutos
{
    public partial class CadAcabamentoForm : Form
    {
        IWTPostgreNpgsqlConnection conn;
        int? id;
        TipoForm Tipo;
        AcsUsuario Usuario;

        RevisaoGenericaClass Revisao;

        public CadAcabamentoForm(TipoForm Tipo, AcsUsuario Usuario,IWTPostgreNpgsqlConnection conn, int? id)
        {
            this.initForm(Tipo, Usuario, conn, id, false);
        }

        public CadAcabamentoForm(TipoForm Tipo, AcsUsuario Usuario,IWTPostgreNpgsqlConnection conn, int? id, bool somenteVisualizacao)
        {
            this.initForm(Tipo, Usuario, conn, id, somenteVisualizacao);
        }


        private void initForm(TipoForm Tipo, AcsUsuario Usuario,IWTPostgreNpgsqlConnection conn, int? id, bool somenteVisualizacao)
        {
            InitializeComponent();
            this.conn = conn;
            this.id = id;
            this.Usuario = Usuario;
            this.Tipo = Tipo;

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
                    "  acb_identificacao, "+
                    "  acb_descricao_tecnica, "+
                    "  acb_obs, "+
                    "  acb_norma_cliente, "+
                    "  acb_ultima_revisao, " +
                    "  acb_ultima_revisao_data, " +
                    "  id_acs_usuario_ultima_revisao " +
                    "FROM  "+
                    "  public.acabamento "+
                    "WHERE " +
                    "  id_acabamento = " + this.id;

                NpgsqlDataReader read = command.ExecuteReader();
                if (read.HasRows)
                {
                    read.Read();

                    this.txtAcsIdentificacao.Text = read["acb_identificacao"].ToString();
                    this.txtAcsDescricao.Text = read["acb_descricao_tecnica"].ToString();
                    this.txtAcsObs.Text = read["acb_obs"].ToString();
                    this.txtAcbNormaCliente.Text = read["acb_norma_cliente"].ToString();

                    if (read["acb_ultima_revisao_data"] != DBNull.Value)
                    {
                        this.Revisao = new RevisaoGenericaClass(
                            read["acb_ultima_revisao"].ToString(),
                            Convert.ToDateTime(read["acb_ultima_revisao_data"]),
                            Convert.ToInt32(read["id_acs_usuario_ultima_revisao"]),
                            this.conn);

                        this.lblRevisao.Text = this.Revisao.justificativaAtual;
                        this.lblRevisaoData.Text = this.Revisao.Data.Value.ToString("dd/MM/yyyy hh:mm:SS");
                        this.lblRevisaoUsuario.Text = this.Revisao.Usuario.acsLogin;
                    }
                    else
                    {
                        this.Revisao = null;
                    }

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

                if (this.Tipo != TipoForm.Gerencial)
                {
                    if (this.Utilizado())
                    {
                        throw new Exception("Não é possível salvar esse Acabamento pois ele já está sendo utilizado. A alteração só pode ser realizada através do módulo de Administração do Sistema.");
                    }
                }

                if (id.HasValue)
                {
                    RevisaoProdutoForm formJustificativa =
                        new RevisaoProdutoForm("Sr(a). " + this.Usuario.acsName + " (" + this.Usuario.acsLogin +
                                               ") essa operação será registrada como uma revisão em seu nome. Você deseja prosseguir?");
                    formJustificativa.ShowDialog();

                    if (formJustificativa.Abortar)
                    {
                        return;
                    }
                    else
                    {
                        if (this.Revisao != null)
                        {
                            this.Revisao.Revisar(formJustificativa.Justificativa, this.Usuario);
                        }
                        else
                        {
                            this.Revisao = new RevisaoGenericaClass(formJustificativa.Justificativa, this.Usuario);
                        }

                    }

                }
                else
                {
                    this.Revisao = new RevisaoGenericaClass("Cadastro Inicial", this.Usuario);
                }

                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();

                if (id == null)
                {
                    command.CommandText =
                    "INSERT INTO  " +
                    "  public.acabamento " +
                    "( " +
                    "  acb_identificacao, " +
                    "  acb_descricao_tecnica, " +
                    "  acb_obs, " +
                    "  acb_norma_cliente, "+
                    "  acb_ultima_revisao, " +
                    "  acb_ultima_revisao_data, " +
                    "  id_acs_usuario_ultima_revisao " +
                    ")  " +
                    "VALUES ( " +
                    "  :acb_identificacao, " +
                    "  :acb_descricao_tecnica, " +
                    "  :acb_obs, " +
                    "  :acb_norma_cliente, "+
                    "  :acb_ultima_revisao, " +
                    "  :acb_ultima_revisao_data, " +
                    "  :id_acs_usuario_ultima_revisao " +
                    ");";
                }
                else
                {
                    command.CommandText =
                    "UPDATE " +
                    "  public.acabamento  " +
                    "SET " +
                    "  acb_identificacao = :acb_identificacao," +
                    "  acb_descricao_tecnica = :acb_descricao_tecnica," +
                    "  acb_obs = :acb_obs, " +
                    "  acb_norma_cliente = :acb_norma_cliente, "+
                    "  acb_ultima_revisao = :acb_ultima_revisao, " +
                    "  acb_ultima_revisao_data = :acb_ultima_revisao_data, " +
                    "  id_acs_usuario_ultima_revisao = :id_acs_usuario_ultima_revisao " +
                    "WHERE " +
                    "  id_acabamento = :id_acabamento";
                }

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acabamento", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = id;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("acb_identificacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.txtAcsIdentificacao.Text.Trim();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("acb_descricao_tecnica", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.txtAcsDescricao.Text.Trim();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("acb_obs", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.txtAcsObs.Text.Trim();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("acb_norma_cliente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.txtAcbNormaCliente.Text.Trim();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("acb_ultima_revisao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.Revisao.justificativaAtual;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("acb_ultima_revisao_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = this.Revisao.Data;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_ultima_revisao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.Revisao.Usuario.Id;


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
                if (this.txtAcsIdentificacao.Text.Trim().Length == 0)
                {
                    throw new Exception("Campo de Identificação é obrigatório.");
                }

                if (this.txtAcsDescricao.Text.Trim().Length == 0)
                {
                    throw new Exception("Campo de descrição é obrigatório.");
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao validar os campos obrigatórios.\r\n" + e.Message);
            }
        }

        private bool Utilizado()
        {
            try
            {
                if (this.id == null)
                {
                    return false;
                }

                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acabamento", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = id;

                command.CommandText =
                "SELECT  " +
                "  COUNT(public.produto.id_produto) " +
                "FROM " +
                "  public.produto " +
                "WHERE " +
                "  public.produto.id_acabamento = :id_acabamento ";

                int count = Convert.ToInt32(command.ExecuteScalar());

                if (count > 0)
                {
                    return true;
                }

                command.CommandText =
                 "SELECT  " +
                 "  COUNT(public.material.id_material) " +
                 "FROM " +
                 "  public.material " +
                 "WHERE " +
                 "  public.material.id_acabamento = :id_acabamento ";

                count = Convert.ToInt32(command.ExecuteScalar());

                if (count > 0)
                {
                    return true;
                }


                command.CommandText =
                 "SELECT  " +
                 "  COUNT(public.produto_acabamento.id_produto_acabamento) " +
                 "FROM " +
                 "  public.produto_acabamento " +
                 "WHERE " +
                 "  public.produto_acabamento.id_acabamento = :id_acabamento ";

                count = Convert.ToInt32(command.ExecuteScalar());

                if (count > 0)
                {
                    return true;
                }


                return false;

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao verificar se o item está sendo utilizado.\r\n" + e.Message, e);
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
