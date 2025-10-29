using System;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using NpgsqlTypes;

namespace BibliotecaEntidades.Operacoes.OrdemProducao
{
    public class OrdemProducaoDiferencaClass
    {
        public long? idOrdemProducaoDiferenca { get; private set; }
        public AcsUsuarioClass Usuario { get; set; }
        public int idJustificativa { get; set; }
        public bool? Repor { get; set; }
        public bool? Reposto { get; set; }
        public long idOrdemProducaoPostoTrabalho { get; set; }
        public double Quantidade { get; set; }
        public int? Destino { get; set; }
        public int? idEstoque { get; set; }



        private readonly IWTPostgreNpgsqlConnection conn;
        private readonly OrdemProducaoClass Parent;

        public bool toDelete { get; private set; }

        public OrdemProducaoDiferencaClass(long? idOrdemProducaoDiferenca, long idOrdemProducaoPostoTrabalho, AcsUsuarioClass usuario, int idJustificativa, bool? Repor, bool? Reposto, double Quantidade, int? Destino, int? idEstoque, OrdemProducaoClass Parent, IWTPostgreNpgsqlConnection conn)
        {
            this.Parent = Parent;
            this.conn = conn;
            this.idOrdemProducaoDiferenca = idOrdemProducaoDiferenca;

            this.Usuario = usuario;
            this.idJustificativa = idJustificativa;
            this.Repor = Repor;
            this.Reposto = Reposto;
            this.idOrdemProducaoPostoTrabalho = idOrdemProducaoPostoTrabalho;
            this.Quantidade = Quantidade;

            this.Destino = Destino;
            this.idEstoque = idEstoque;


            this.toDelete = false;
        }

        public void Delete()
        {
            this.toDelete = true;
        }

        public void Save(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (toDelete)
                {
                    if (this.idOrdemProducaoDiferenca != null)
                    {
                        command.CommandText =
                            "DELETE FROM  " +
                            "  public.ordem_producao_diferenca  " +
                            "WHERE " +
                            "  id_ordem_producao_diferenca = :id_ordem_producao_diferenca ";


                        command.Parameters.Clear();

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao_diferenca", NpgsqlDbType.Integer));
                        command.Parameters[command.Parameters.Count - 1].Value = this.idOrdemProducaoDiferenca;
                        command.ExecuteNonQuery();
                    }
                }
                else
                {
                    if (this.idOrdemProducaoDiferenca == null)
                    {
                        command.CommandText =
                            "INSERT INTO  " +
                            "  public.ordem_producao_diferenca " +
                            "( " +
                            "  id_ordem_producao, " +
                            "  id_ordem_producao_posto_trabalho, " +
                            "  id_acs_usuario, " +
                            "  id_motivo_alteracao_qtd_op, " +
                            "  opd_repor, " +
                            "  opd_reposto, " +
                            "  opd_quantidade, " +
                            "  opd_destino, " +
                            "  id_estoque " +
                            ")  " +
                            "VALUES ( " +
                            "  :id_ordem_producao, " +
                            "  :id_ordem_producao_posto_trabalho, " +
                            "  :id_acs_usuario, " +
                            "  :id_motivo_alteracao_qtd_op, " +
                            "  :opd_repor, " +
                            "  :opd_reposto, " +
                            "  :opd_quantidade, " +
                            "  :opd_destino, " +
                            "  :id_estoque " +
                            ") RETURNING id_ordem_producao_diferenca;";
                    }
                    else
                    {
                        command.CommandText =
                            "UPDATE  " +
                            "  public.ordem_producao_diferenca   " +
                            "SET  " +
                            "  id_ordem_producao = :id_ordem_producao, " +
                            "  id_ordem_producao_posto_trabalho = :id_ordem_producao_posto_trabalho, " +
                            "  id_acs_usuario = :id_acs_usuario, " +
                            "  id_motivo_alteracao_qtd_op = :id_motivo_alteracao_qtd_op, " +
                            "  opd_repor = :opd_repor, " +
                            "  opd_reposto = :opd_reposto, " +
                            "  opd_quantidade = :opd_quantidade, " +
                            "  opd_destino = :opd_destino, " +
                            "  id_estoque = :id_estoque " +
                            "WHERE  " +
                            "  id_ordem_producao_diferenca = :id_ordem_producao_diferenca " +
                            "RETURNING  id_ordem_producao_diferenca;";
                    }

                    command.Parameters.Clear();

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao_diferenca", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.idOrdemProducaoDiferenca;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Parent.idOrdemProducao;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao_posto_trabalho", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.idOrdemProducaoPostoTrabalho;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Usuario.ID;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_motivo_alteracao_qtd_op", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.idJustificativa;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opd_repor", NpgsqlDbType.Smallint));
                    command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Repor);
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opd_reposto", NpgsqlDbType.Smallint));
                    command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Reposto);
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opd_quantidade", NpgsqlDbType.Double));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Quantidade;

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opd_destino", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Destino;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_estoque", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.idEstoque;

                    this.idOrdemProducaoDiferenca = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar a Diferença.\r\n" + e.Message);
            }
        }
    }
}