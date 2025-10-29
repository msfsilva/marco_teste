using System;
using BibliotecaEntidades.Entidades;
using IWTPostgreNpgsql;
using NpgsqlTypes;

namespace BibliotecaEntidades.Operacoes.OrdemProducao
{
    public class OrdemProducaoEstoqueClass
    {
        public int? idOrdemProducaoEstoque { get; private set; }
        public EstoqueGavetaItemClass gavItem { get; private set; }
        public double Quantidade { get; private set; }
        public string estoqueNome
        {
            get
            {
                if (this.gavItem != null)
                {
                    return this.gavItem.EstoqueString;
                }
                return "";
            }
        }



        public bool toDelete { get; private set; }
        private IWTPostgreNpgsqlConnection conn;
        private readonly OrdemProducaoClass Parent;


        public OrdemProducaoEstoqueClass(int? idOrdemProducaoEstoque, EstoqueGavetaItemClass gavItem, double Quantidade, OrdemProducaoClass Parent, IWTPostgreNpgsqlConnection conn)
        {
            this.idOrdemProducaoEstoque = idOrdemProducaoEstoque;
          
            this.Quantidade = Quantidade;
            this.conn = conn;
            this.Parent = Parent;
            this.toDelete = false;
            this.gavItem = gavItem;
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
                    if (this.idOrdemProducaoEstoque != null)
                    {
                        command.CommandText =
                            "DELETE FROM  " +
                            "  public.ordem_producao_estoque  " +
                            "WHERE  " +
                            "  id_ordem_producao_estoque = :id_ordem_producao_estoque " +
                            ";";


                        command.Parameters.Clear();

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao_estoque", NpgsqlDbType.Integer));
                        command.Parameters[command.Parameters.Count - 1].Value = this.idOrdemProducaoEstoque;
                        command.ExecuteNonQuery();
                    }
                }
                else
                {
                    if (this.idOrdemProducaoEstoque == null)
                    {
                        command.CommandText =
                            "INSERT INTO  " +
                            "  public.ordem_producao_estoque " +
                            "( " +
                            "  id_ordem_producao, " +
                            "  id_estoque_gaveta_item, " +
                            "  ope_quantidade " +
                            ")  " +
                            "VALUES ( " +
                            "  :id_ordem_producao, " +
                            "  :id_estoque_gaveta_item, " +
                            "  :ope_quantidade " +
                            ") RETURNING id_ordem_producao_estoque;";
                    }
                    else
                    {
                        command.CommandText =
                            "UPDATE  " +
                            "  public.ordem_producao_estoque   " +
                            "SET  " +
                            "  id_ordem_producao = :id_ordem_producao, " +
                            "  id_estoque_gaveta_item = :id_estoque_gaveta_item, " +
                            "  ope_quantidade = :ope_quantidade " +
                            "WHERE  " +
                            "  id_ordem_producao_estoque = :id_ordem_producao_estoque " +
                            "RETURNING  id_ordem_producao_estoque;";
                    }

                    command.Parameters.Clear();

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao_estoque", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.idOrdemProducaoEstoque;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Parent.idOrdemProducao;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_estoque_gaveta_item", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.gavItem.ID;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ope_quantidade", NpgsqlDbType.Double));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Quantidade;

                    

                    this.idOrdemProducaoEstoque = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar a utilizãção do Estoque.\r\n" + e.Message);
            }
        }
    }
}