using System;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using NpgsqlTypes;

namespace BibliotecaEntidades.Operacoes.OrdemProducao
{
    public class OrdemProducaoHistoricoClass
    {
        public int? idOrdemProducaoHistorico { get; private set; }
        public string Historico { get; private set; }
        public AcsUsuarioClass Usuario { get; private set; }
        public DateTime Hora { get; private set; }

        public bool toDelete { get; private set; }
        private IWTPostgreNpgsqlConnection conn;
        private readonly OrdemProducaoClass Parent;

        public OrdemProducaoHistoricoClass(int? idOrdemProducaoHistorico, AcsUsuarioClass Usuario, DateTime Hora, string Historico, OrdemProducaoClass Parent, IWTPostgreNpgsqlConnection conn)
        {
            this.idOrdemProducaoHistorico = idOrdemProducaoHistorico;
            this.Historico = Historico;
            this.Usuario = Usuario;
            this.Hora = Hora;

            this.conn = conn;
            this.Parent = Parent;
        }

        public void Save(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (toDelete)
                {
                    if (this.idOrdemProducaoHistorico != null)
                    {
                        command.CommandText =
                            "DELETE FROM  " +
                            "  public.ordem_producao_historico  " +
                            "WHERE  " +
                            "  id_ordem_producao_historico = :id_ordem_producao_historico " +
                            ";";


                        command.Parameters.Clear();

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao_historico", NpgsqlDbType.Integer));
                        command.Parameters[command.Parameters.Count - 1].Value = this.idOrdemProducaoHistorico;
                        command.ExecuteNonQuery();
                    }
                }
                else
                {
                    if (this.idOrdemProducaoHistorico == null)
                    {
                        command.CommandText =
                            "INSERT INTO  " +
                            "  public.ordem_producao_historico "+
                            "( "+
                            "  id_ordem_producao, "+
                            "  id_acs_usuario, "+
                            "  oph_historico, "+
                            "  oph_data_hora "+
                            ")  "+
                            "VALUES ( "+
                            "  :id_ordem_producao, "+
                            "  :id_acs_usuario, "+
                            "  :oph_historico, "+
                            "  :oph_data_hora "+
                            ") RETURNING id_ordem_producao_historico;";
                    }
                    else
                    {
                        command.CommandText =
                            "UPDATE  " +
                            "  public.ordem_producao_historico   "+
                            "SET  "+
                            "  id_ordem_producao = :id_ordem_producao, "+
                            "  id_acs_usuario = :id_acs_usuario, "+
                            "  oph_historico = :oph_historico, "+
                            "  oph_data_hora = :oph_data_hora "+
                            "WHERE  "+
                            "  id_ordem_producao_historico = :id_ordem_producao_historico "+
                            "RETURNING  id_ordem_producao_historico;";
                    }

                    command.Parameters.Clear();

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao_historico", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.idOrdemProducaoHistorico;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Parent.idOrdemProducao;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Usuario.ID;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oph_historico", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Historico;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oph_data_hora", NpgsqlDbType.Timestamp));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Hora;


                    this.idOrdemProducaoHistorico = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar o histórico.\r\n" + e.Message);
            }
        }

    }
}