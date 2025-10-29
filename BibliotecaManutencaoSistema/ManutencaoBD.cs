#region Referencias

using System;
using System.Windows.Forms;
using IWTPostgreNpgsql;
using Npgsql;

#endregion

namespace BibliotecaManutencaoSistema
{
    public static class ManutencaoBD
    {

        public static void CorrigeBD(IWTPostgreNpgsqlConnection conn)
        {
            try
            {
                CorrigeNF(conn);
                MessageBox.Show(null, "Manutenção realizada com sucesso!", "Manutenção do Banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao realizar a manutenção do banco de dados.\r\n" + e.Message);
            }

        }


        private static void CorrigeNF(IWTPostgreNpgsqlConnection conn)
        {
            try
            {
                IWTPostgreNpgsqlCommand command = conn.CreateCommand();
                command.CommandText = "SELECT id_nf_principal, nfp_numero FROM nf_principal WHERE nfp_tipo_emitente <> '' AND id_nf_principal NOT IN (SELECT id_nf_principal FROM atendimento)";
                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                if (read.HasRows)
                {
                    string message = "";
                    while (read.Read())
                    {
                        message += ", " + read["nfp_numero"] + "";
                    }
                    read.Close();

                    if (MessageBox.Show(null, "A operação de manutenção irá excluir as notas fiscais de número(s) " + message + ". Deseja continuar?","Manutenção do Banco de dados",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        command.CommandText = "DELETE FROM nf_principal WHERE nfp_tipo_emitente <> '' AND id_nf_principal NOT IN (SELECT id_nf_principal FROM atendimento)";
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao realizar a manutenção das tabelas de Nota fiscal\r\n" + e.Message);
            }
        }
    }
}
