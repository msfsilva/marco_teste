#region Referencias

using System;
using System.Globalization;
using System.Windows.Forms;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;

#endregion

namespace BibliotecaTelasOP
{
    public partial class CadPrecosItensFixosForm : IWTBaseForm
    {
        readonly IWTPostgreNpgsqlConnection conn;
        readonly int? id;
        public CadPrecosItensFixosForm(IWTPostgreNpgsqlConnection conn, int? id)
        {
            InitializeComponent();
            this.conn = conn;
            this.id = id;

            if (this.id != null)
            {
                this.loadEdit();
            }
        }

        private void loadEdit()
        {
            try
            {
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText =
                   "SELECT                            " +
                    "  id_tabela_preco_item_fixo,      " +
                    "  tpf_codigo,                     " +
                    "  tpf_lote_ativo,                 " +
                    "  tpf_data_inicio,                " +
                    "  tpf_preco,                      " +
                    "  tpf_qtd_lote_orcado,            " +
                    "  tpf_origem_preco                " +
                    "FROM                              " +
                    "  public.tabela_preco_item_fixo   " +
                "WHERE " +
                "  id_tabela_preco_item_fixo = " + this.id;

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                if (read.HasRows)
                {
                    read.Read();
                    this.txtCodigo.Text = read["tpf_codigo"].ToString();                    
                    this.dtpDataIncio.Text = read["tpf_data_inicio"].ToString();
                    this.txtOrigemPreco.Text = read["tpf_origem_preco"].ToString();
                    if (read["tpf_lote_ativo"] != DBNull.Value)
                    {
                        this.nudLote.Value = Convert.ToDecimal(read["tpf_lote_ativo"], CultureInfo.InvariantCulture);
                    }

                    if (read["tpf_qtd_lote_orcado"] != DBNull.Value)
                    {
                        this.nudQtdLoteOrcado.Value = Convert.ToDecimal(read["tpf_qtd_lote_orcado"], CultureInfo.InvariantCulture);
                    }

                    if (read["tpf_preco"] != DBNull.Value)
                    {
                        this.nudPreco.Value = Convert.ToDecimal(read["tpf_preco"], CultureInfo.InvariantCulture);
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
                //this.validateRequiredFields();

                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();

                if (id == null)
                {
                    command.CommandText =
                    "INSERT INTO                     " +
                    "  public.tabela_preco_item_fixo " +
                    "(                               " +                   
                    "  tpf_codigo,                   " +
                    "  tpf_lote_ativo,               " +
                    "  tpf_data_inicio,              " +
                    "  tpf_preco,                    " +
                    "  tpf_qtd_lote_orcado,          " +
                    "  tpf_origem_preco              " +
                    ")                               " +
                    "VALUES (                        " +                    
                    "  :tpf_codigo,                  " +
                    "  :tpf_lote_ativo,              " +
                    "  :tpf_data_inicio,             " +
                    "  :tpf_preco,                   " +
                    "  :tpf_qtd_lote_orcado,         " +
                    "  :tpf_origem_preco             " +
                    ");";
                }
                else
                {
                    command.CommandText =
                    "UPDATE                                                    " +
                    "  public.tabela_preco_item_fixo                           " +
                    "SET                                                       " +
                    "  tpf_codigo = :tpf_codigo,                               " +
                    "  tpf_lote_ativo = :tpf_lote_ativo,                       " +
                    "  tpf_data_inicio = :tpf_data_inicio,                     " +
                    "  tpf_preco = :tpf_preco,                                 " +
                    "  tpf_qtd_lote_orcado = :tpf_qtd_lote_orcado,             " +
                    "  tpf_origem_preco = :tpf_origem_preco                    " +
                    "                                                          " +
                    "WHERE                                                     " +
                    "  id_tabela_preco_item_fixo = :id_tabela_preco_item_fixo  " +
                    ";                                                         ";
                }

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_tabela_preco_item_fixo", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = id;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tpf_codigo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.txtCodigo.Text.Trim();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tpf_lote_ativo", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = this.nudLote.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tpf_data_inicio", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = this.dtpDataIncio.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tpf_preco", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = this.nudPreco.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tpf_qtd_lote_orcado", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = this.nudQtdLoteOrcado.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tpf_origem_preco", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.txtOrigemPreco.Text.Trim();
                
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
                //if (this.txtMatDescricao.Text.Trim().Length == 0)
                //{
                //    throw new Exception("Campo de descrição é obrigatório.");
                //}

                //if (this.txtMatUnidadeMedida.Text.Trim().Length == 0)
                //{
                //    throw new Exception("Campo de unidade de medida é obrigatório.");
                //}
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
