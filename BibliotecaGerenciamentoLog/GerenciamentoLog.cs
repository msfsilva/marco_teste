#region Referencias

using System;
using System.Data;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;

#endregion

namespace BibliotecaGerenciamentoLog
{
    public enum TipoLog { Info, Aviso, Erro }
    public static class GerenciamentoLog
    {
        
        
        public static void InserirLog(TipoLog Tipo, string Usuario, string Local, string Evento, IWTPostgreNpgsqlConnection conn)
        {
            IWTPostgreNpgsqlConnection conn2 = null;
            try
            {
                //IWTPostgreNpgsqlCommand command = conn.CreateCommand();
                conn2 = new IWTPostgreNpgsqlConnection(conn.ConnectionString);
                conn2.Open();

                IWTPostgreNpgsqlCommand command = conn2.CreateCommand();




                command.CommandText =
                    "INSERT INTO  " +
                    "  public.log_eventos " +
                    "( " +
                    "  loe_data, " +
                    "  loe_tipo, " +
                    "  loe_usuario_responsavel, " +
                    "  loe_local_geracao, " +
                    "  loe_evento " +
                    ")  " +
                    "VALUES ( " +
                    "  :loe_data, " +
                    "  :loe_tipo, " +
                    "  :loe_usuario_responsavel, " +
                    "  :loe_local_geracao, " +
                    "  :loe_evento " +
                    ");";

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("loe_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = DateTime.Now;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("loe_tipo", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Tipo;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("loe_usuario_responsavel", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = Usuario;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("loe_local_geracao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = Local;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("loe_evento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = Evento;
                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao inserir o Log.\r\n" + e.Message, e);
            }
            finally
            {
                if (conn2 != null)
                    conn2.ForceClose();
            }
        }
    }
}
