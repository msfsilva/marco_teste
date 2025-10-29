#region Referencias

using System;
using System.Text;
using System.Windows.Forms;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;

#endregion

namespace BibliotecaInterfaceModulosCliente
{
    public partial class CadPedidoRejeitadoForm : IWTBaseForm
    {
        readonly IWTPostgreNpgsqlConnection conn;
        readonly int? id;
        readonly Encoding fileEncoding;
        public CadPedidoRejeitadoForm(IWTPostgreNpgsqlConnection conn, int? id)
        {
            InitializeComponent();
            this.conn = conn;
            this.id = id;
            this.fileEncoding = Encoding.GetEncoding(1252);


            if (this.id != null)
            {
                this.loadEdit();
            }

            this.WindowState = FormWindowState.Maximized;
        }

        private void loadEdit()
        {
            try
            {
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText =
                    "SELECT  " +
                    "  public.pedido_rejeitado.id_pedido_rejeitado, " +
                    "  public.pedido_rejeitado.per_nome_arquivo, " +
                    "  public.pedido_rejeitado.per_motivo_rejeicao, " +
                    "  public.pedido_rejeitado.per_observacao, " +
                    "  public.pedido_rejeitado.per_modulo_importador, " +
                    "  public.pedido_rejeitado.per_data_entrada, " +
                    "  public.pedido_rejeitado.per_data_ultimo_processamento, " +
                    "  public.pedido_rejeitado.per_arquivo " +
                    "FROM " +
                    "  public.pedido_rejeitado " +
                    "WHERE " +
                    "  public.pedido_rejeitado.id_pedido_rejeitado = " + this.id;

                    
                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                if (read.HasRows)
                {
                    read.Read();

                    this.txtArquivo.Text = this.fileEncoding.GetString((byte[])read["per_arquivo"]);
                    this.txtModulo.Text = read["per_modulo_importador"].ToString();
                    this.txtMotivoRejeicao.Text = read["per_motivo_rejeicao"].ToString();
                    this.txtNomeArquivo.Text = read["per_nome_arquivo"].ToString();
                    this.txtObs.Text = read["per_observacao"].ToString();
                    this.dtpDataEntrada.Value = Convert.ToDateTime(read["per_data_entrada"]);
                    this.dtpDataUltimoProc.Value = Convert.ToDateTime(read["per_data_ultimo_processamento"]);

                    read.Close();;
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

            
                    command.CommandText =
                    "UPDATE  " +
                    "  public.pedido_rejeitado   " +
                    "SET  " +
                    "  per_arquivo = :per_arquivo " +
                    "WHERE  " +
                    "  id_pedido_rejeitado = :id_pedido_rejeitado " +
                    ";";
               

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_pedido_rejeitado", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = id;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("per_arquivo",NpgsqlDbType.Bytea));
                command.Parameters[command.Parameters.Count - 1].Value = this.fileEncoding.GetBytes(this.txtArquivo.Text);
                
                command.ExecuteNonQuery();


                this.Close();;
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
                if (this.txtArquivo.Text.Trim().Length == 0)
                {
                    throw new Exception("Campo de arquivo é obrigatório.");
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao validar os campos obrigatórios.\r\n" + e.Message);
            }
        }

        #region Eventos
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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

      
        #endregion

    }
}
