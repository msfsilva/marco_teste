#region Referencias

using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;

#endregion

namespace BibliotecaTelasOP
{
    public partial class CadPrecosItensVariaveisForm : IWTBaseForm
    {
        readonly IWTPostgreNpgsqlConnection conn;
        readonly int? id;
        public CadPrecosItensVariaveisForm(IWTPostgreNpgsqlConnection conn, int? id)
        {
            InitializeComponent();
            this.conn = conn;
            this.id = id;

            loadClientes();
            if (this.id != null)
            {
                this.loadEdit();
            }
        }
        public CadPrecosItensVariaveisForm(IWTPostgreNpgsqlConnection conn, string oc, int pos, ClienteClass cliente)
        {
            InitializeComponent();
            this.conn = conn;
            this.id = null;

            loadClientes();
            this.txtOc.Text = oc;
            this.nudPos.Value = pos;
            this.cmbCliente.SelectedItem = cliente;

        }


        private void loadClientes()
        {
            try
            {


                ClienteClass search = new ClienteClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<ClienteClass> clientes =
                    search.Search(new List<SearchParameterClass>()
                                      {
                                          new SearchParameterClass("NomeResumido", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String)
                                      }).
                        ConvertAll(a => (ClienteClass) a);


                this.cmbCliente.DataSource = clientes;
                this.cmbCliente.ValueMember = "ID";
                this.cmbCliente.DisplayMember = "NomeResumido";
                this.cmbCliente.autoSize = true;
                this.cmbCliente.Table = clientes;
                this.cmbCliente.ColumnsToDisplay = new string[] {"NomeResumido", "Nome"};
                this.cmbCliente.HeadersToDisplay = new string[] {"Nome Resumido", "Razão"};



            }
            catch (Exception a)
            {
                MessageBox.Show("Erro ao carregar dados do cliente.\r\n" + a.Message, "Dados do Cliente",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       

        private void loadEdit()
        {
            try
            {
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText =
                   "SELECT                                 " +                
                    "  tpv_order_number,                    " +
                    "  tpv_pos,                             " +
                    "  tpv_preco,                           " +
                    "  tpv_kit,                              " +
                    "  id_cliente "+
                    "FROM                                   " +
                    "  public.tabela_preco_item_variavel    " +                  
                    "WHERE " +
                    "  id_tabela_preco_item_variavel = " + this.id;

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                if (read.HasRows)
                {
                    read.Read();

                    this.txtOc.Text = read["tpv_order_number"].ToString();                    
                    if (read["tpv_preco"] != DBNull.Value)
                    {
                        this.nudPreco.Value = Convert.ToDecimal(read["tpv_preco"], CultureInfo.InvariantCulture);
                    }

                    if (read["tpv_pos"] != DBNull.Value)
                    {
                        this.nudPos.Value = Convert.ToDecimal(read["tpv_pos"]);
                    }

                    if (read["id_cliente"] != DBNull.Value)
                    {
                        ClienteClass cli = ClienteBaseClass.GetEntidade(Convert.ToInt32(read["id_cliente"]), LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                        this.cmbCliente.SelectedItem = cli;
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
                    "INSERT INTO                         " +
                    "  public.tabela_preco_item_variavel " +
                    "(                                   " +                   
                    "  tpv_order_number,                 " +
                    "  tpv_pos,                          " +
                    "  tpv_preco,                        " +
                    "  tpv_antigo,                        "+
                    "  id_cliente "+
                    ")                                   " +
                    "VALUES (                            " +                    
                    "  :tpv_order_number,                " +
                    "  :tpv_pos,                         " +
                    "  :tpv_preco,                       " +
                    "  0,                                 " +
                    "  :id_cliente "+
                    ");                                  ";
                }
                else
                {
                    command.CommandText =
                    "UPDATE                                                           " +
                    "  public.tabela_preco_item_variavel                              " +
                    "SET                                                              " +
                    "  tpv_order_number = :tpv_order_number,                          " +
                    "  tpv_pos = :tpv_pos,                                            " +
                    "  tpv_preco = :tpv_preco,                                        " +
                    "  tpv_antigo = 0,                                                 " +
                    "  id_cliente = :id_cliente "+
                    "WHERE                                                            " +
                    "  id_tabela_preco_item_variavel = :id_tabela_preco_item_variavel " +
                    ";                                                                ";
                }

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_tabela_preco_item_variavel", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = id;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tpv_order_number", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.txtOc.Text.Trim();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tpv_pos", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.nudPos.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tpv_preco", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToDouble(this.nudPreco.Value);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_cliente", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = ((ClienteClass) this.cmbCliente.SelectedItem).ID;
                
                
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
