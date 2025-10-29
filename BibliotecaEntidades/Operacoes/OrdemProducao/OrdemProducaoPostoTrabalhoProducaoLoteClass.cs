using System;
using BibliotecaEntidades.Entidades;
using IWTPostgreNpgsql;
using NpgsqlTypes;
using LoteClass = BibliotecaEntidades.Operacoes.Compras.LoteClass;

namespace BibliotecaEntidades.Operacoes.OrdemProducao
{
    public class OrdemProducaoPostoTrabalhoProducaoLoteClass
    {
        public int? idOrdemProducaoPostoTrabalhoProducaoLote { private set; get; }
        public LoteClass Lote { private set; get; }
        readonly OrdemProducaoPostoTrabalhoProducaoClass Parent;
        IWTPostgreNpgsqlConnection conn;

        public bool toDelete { get; private set; }

        public OrdemProducaoPostoTrabalhoProducaoLoteClass(int? idOrdemProducaoPostoTrabalhoProducaoLote, LoteClass Lote, OrdemProducaoPostoTrabalhoProducaoClass Parent, IWTPostgreNpgsqlConnection conn)
        {
            this.idOrdemProducaoPostoTrabalhoProducaoLote = idOrdemProducaoPostoTrabalhoProducaoLote;
            this.Lote = Lote;
            this.Parent = Parent;
            this.conn = conn;

        }

        public void Save(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (toDelete)
                {
                    if (idOrdemProducaoPostoTrabalhoProducaoLote != null)
                    {
                        command.CommandText =
                            "DELETE FROM  " +
                            "  public.ordem_producao_posto_trabalho_producao_lote  " +
                            "WHERE  " +
                            "  id_ordem_producao_posto_trabalho_producao_lote = :id_ordem_producao_posto_trabalho_producao_lote " +
                            ";";

                        command.Parameters.Clear();

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao_posto_trabalho_producao_lote", NpgsqlDbType.Integer));
                        command.Parameters[command.Parameters.Count - 1].Value = this.idOrdemProducaoPostoTrabalhoProducaoLote;
                        command.ExecuteNonQuery();
                    }
                }
                else
                {
                    if (this.idOrdemProducaoPostoTrabalhoProducaoLote == null)
                    {
                        command.CommandText =
                            "INSERT INTO  " +
                            "  public.ordem_producao_posto_trabalho_producao_lote " +
                            "( " +
                            "  id_ordem_producao_posto_trabalho_producao, " +
                            "  id_lote " +
                            ")  " +
                            "VALUES ( " +
                            "  :id_ordem_producao_posto_trabalho_producao, " +
                            "  :id_lote " +
                            ") RETURNING id_ordem_producao_posto_trabalho_producao_lote;";

                    }
                    else
                    {
                        command.CommandText =
                            "UPDATE  " +
                            "  public.ordem_producao_posto_trabalho_producao_lote   "+
                            "SET  "+
                            "  id_ordem_producao_posto_trabalho_producao = :id_ordem_producao_posto_trabalho_producao, "+
                            "  id_lote = :id_lote "+
                            "WHERE  "+
                            "  id_ordem_producao_posto_trabalho_producao_lote = :id_ordem_producao_posto_trabalho_producao_lote "+
                            "RETURNING  id_ordem_producao_posto_trabalho_producao;";
                    }


                    command.Parameters.Clear();

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao_posto_trabalho_producao_lote", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.idOrdemProducaoPostoTrabalhoProducaoLote;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao_posto_trabalho_producao", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Parent.idOrdemProducaoPostoTrabalhoProducao;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_lote", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Lote.getID();
                    

                    this.idOrdemProducaoPostoTrabalhoProducaoLote = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar o Lote na produção do Posto de Trabalho.\r\n" + e.Message);
            }
        }
    }
}