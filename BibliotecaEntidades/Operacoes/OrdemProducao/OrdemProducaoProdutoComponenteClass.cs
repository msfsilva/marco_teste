using System;
using IWTPostgreNpgsql;
using NpgsqlTypes;

namespace BibliotecaEntidades.Operacoes.OrdemProducao
{
    public class OrdemProducaoProdutoComponenteClass
    {
        public long? IdOrdemProducaoProdutoComponente { get; private set; }
        public long? IdProduto{ get; private set; }
        public long? IdProdutoK { get; private set; }
        public string Codigo { get; private set; }
        public string Descricao { get; private set; }

        public string Dimensao { get; private set; }

        public double Quantidade { get; internal set; }


        

        private IWTPostgreNpgsqlConnection conn;
        private readonly OrdemProducaoClass Parent;

        public bool toDelete { get; private set; }

        public OrdemProducaoProdutoComponenteClass(long? idOrdemProducaoProdutoComponente, long? idProduto, long? idProdutoK, string codigo, string descricao, double quantidade, string dimensao, OrdemProducaoClass parent, IWTPostgreNpgsqlConnection conn)
        {
            IdOrdemProducaoProdutoComponente = idOrdemProducaoProdutoComponente;
            IdProduto = idProduto;
            IdProdutoK = idProdutoK;
            Codigo = codigo;
            Descricao = descricao;
            Quantidade = quantidade;
            Parent = parent;
            Dimensao = dimensao;
            this.conn = conn;

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
                    if (IdOrdemProducaoProdutoComponente.HasValue)
                    {
                        command.CommandText =
                            "DELETE FROM  " +
                            "  public.ordem_producao_produto_componente  " +
                            "WHERE  " +
                            "  id_ordem_producao_produto_componente = :id_ordem_producao_produto_componente " +
                            "; ";

                        command.Parameters.Clear();

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao_produto_componente", NpgsqlDbType.Integer));
                        command.Parameters[command.Parameters.Count - 1].Value = this.IdOrdemProducaoProdutoComponente;
                        command.ExecuteNonQuery();
                    }
                }
                else
                {
                    if (!this.IdOrdemProducaoProdutoComponente.HasValue)
                    {
                        command.CommandText =
                            "INSERT INTO " +
                            "public.ordem_producao_produto_componente  " +
                            "( " +
                            "  id_ordem_producao, " +
                            "  id_produto, " +
                            "  id_produto_k, " +
                            "  opc_produto_codigo, " +
                            "  opc_produto_descricao, " +
                            "  opc_quantidade, " +
                            "  opc_dimensao "+
                            ") " +
                            "VALUES ( " +
                            "  :id_ordem_producao, " +
                            "  :id_produto, " +
                            "  :id_produto_k, " +
                            "  :opc_produto_codigo, " +
                            "  :opc_produto_descricao, " +
                            "  :opc_quantidade, " +
                            "  :opc_dimensao " +
                            ") RETURNING id_ordem_producao_produto_componente;";
                    }
                    else
                    {
                        command.CommandText =
                            "UPDATE  " +
                            "  public.ordem_producao_produto_componente  " +
                            "SET  " +
                            "  id_ordem_producao = :id_ordem_producao, " +
                            "  id_produto = :id_produto, " +
                            "  id_produto_k = :id_produto_k, " +
                            "  opc_produto_codigo = :opc_produto_codigo, " +
                            "  opc_produto_descricao = :opc_produto_descricao, " +
                            "  opc_quantidade = :opc_quantidade, " +
                            "  opc_dimensao = :opc_dimensao " +
                            "WHERE  " +
                            "  id_ordem_producao_produto_componente = :id_ordem_producao_produto_componente " +
                            "RETURNING  id_ordem_producao_produto_componente;";
                    }

                    command.Parameters.Clear();

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao_produto_componente", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.IdOrdemProducaoProdutoComponente;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Parent.idOrdemProducao;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.IdProduto;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto_k", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.IdProdutoK;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_quantidade", NpgsqlDbType.Double));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Quantidade;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_produto_descricao", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Descricao;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_produto_codigo", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Codigo;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_dimensao", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Dimensao;





                    this.IdOrdemProducaoProdutoComponente = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar o Produto Componente.\r\n" + e.Message);
            }
        }

    }
}