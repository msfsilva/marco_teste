using System;
using System.Collections.Generic;
using System.Threading;
using BibliotecaEntidades.Entidades;
using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using NpgsqlTypes;

namespace BibliotecaAutomacoes
{
    public class SalvarInventarioRunnerClass
    {
        private readonly Semaphore _semaphore;
        private IWTPostgreNpgsqlConnection connection;
        private AcsUsuarioClass _usuarioAtual;
        private bool _stop;

        public SalvarInventarioRunnerClass(ref Semaphore semaphore,IWTPostgreNpgsqlConnection connection, AcsUsuarioClass usuarioAtual)
        {
            _semaphore = semaphore;
            this.connection = connection;
            _usuarioAtual = usuarioAtual;
        }

        public void Start()
        {
            _semaphore?.WaitOne();
            try
            {
                IWTPostgreNpgsqlCommand command = null;
                try
                {


                    DateTime data = DataIndependenteClass.GetData().AddMonths(-1);



                    command = connection.CreateCommand();
                    command.Transaction = command.Connection.BeginTransaction();


                    command.CommandText =
                        "SELECT public.estoque.id_estoque " +
                        "FROM public.estoque " +
                        "     LEFT OUTER JOIN ( " +
                        " " +
                        "     SELECT * FROM public.estoque_historico_valor WHERE   " +
                        "      public.estoque_historico_valor.ehv_ano = :ano AND " +
                        "      public.estoque_historico_valor.ehv_mes = :mes  " +
                        "     ) as historico " +
                        "      " +
                        "     ON ( public.estoque.id_estoque = historico.id_estoque) " +
                        "WHERE " +
                        "      historico.id_estoque_historico_valor IS NULL ";

                    command.Parameters.Clear();

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ano", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = data.Year;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mes", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = data.Month;

                    IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                    List<EstoqueClass> idsEstoqueGerar = new List<EstoqueClass>();

                    while (read.Read())
                    {
                        idsEstoqueGerar.Add(
                            EstoqueClass.GetEntidade(Convert.ToInt32(read["id_estoque"]),
                                _usuarioAtual,
                                connection)
                        );
                    }

                    read.Close();

                    command.CommandText =
                        "SELECT  " +
                        "    COALESCE(sum(public.material_ultima_compra.ultimo_preco_unidade_uso * public.estoque_gaveta_item.egi_quantidade),0) +  " +
                        "    COALESCE(sum(public.epi_ultima_compra.ultimo_preco_unidade_uso * public.estoque_gaveta_item.egi_quantidade),0) +    " +
                        "    COALESCE(sum(public.produto_ultima_compra.ultimo_preco_unidade_uso * public.estoque_gaveta_item.egi_quantidade),0) + " +
                        "    COALESCE(sum(public.produto_preco.prp_preco * public.estoque_gaveta_item.egi_quantidade),0)                     " +
                        "FROM " +
                        "  public.estoque_gaveta_item " +
                        "  INNER JOIN public.estoque_gaveta ON(public.estoque_gaveta_item.id_estoque_gaveta = public.estoque_gaveta.id_estoque_gaveta) " +
                        "  INNER JOIN public.estoque_prateleira ON(public.estoque_gaveta.id_estoque_prateleira = public.estoque_prateleira.id_estoque_prateleira) " +
                        "  INNER JOIN public.estoque_corredor ON(public.estoque_prateleira.id_estoque_corredor = public.estoque_corredor.id_estoque_corredor) " +
                        "  INNER JOIN public.estoque ON(public.estoque_corredor.id_estoque = public.estoque.id_estoque) " +
                        "  LEFT OUTER JOIN public.material ON (public.estoque_gaveta_item.id_material = public.material.id_material) " +
                        "  LEFT OUTER JOIN public.material_ultima_compra ON (public.material.id_material = public.material_ultima_compra.id_material) " +
                        "  LEFT OUTER JOIN public.epi ON (public.estoque_gaveta_item.id_epi = public.epi.id_epi) " +
                        "  LEFT OUTER JOIN public.epi_ultima_compra ON (public.epi.id_epi = public.epi_ultima_compra.id_epi) " +
                        "  LEFT OUTER JOIN public.produto produto_comprado ON (public.estoque_gaveta_item.id_produto = produto_comprado.id_produto) " +
                        "  AND (produto_comprado.pro_tipo_aquisicao = 1) " +
                        "  LEFT OUTER JOIN public.produto_ultima_compra ON (produto_comprado.id_produto = public.produto_ultima_compra.id_produto) " +
                        "  LEFT OUTER JOIN public.produto produto_fabricado ON (public.estoque_gaveta_item.id_produto = produto_fabricado.id_produto) " +
                        "  AND (produto_fabricado.pro_tipo_aquisicao = 0) " +
                        "  LEFT OUTER JOIN public.produto_preco ON (produto_fabricado.id_produto = public.produto_preco.id_produto) " +
                        "  AND (public.produto_preco.prp_fim_vigencia IS NULL) " +
                        "WHERE " +
                        "  public.estoque.id_estoque = :id_estoque AND " +
                        "  public.estoque_gaveta_item.egi_ativo = 1 ";
                    command.Parameters.Clear();

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_estoque", NpgsqlDbType.Integer));

                    command.Prepare();

                    List<EstoqueHistoricoValorClass> toSave = new List<EstoqueHistoricoValorClass>();

                    foreach (EstoqueClass estoque in idsEstoqueGerar)
                    {
                        if (_stop)
                        {
                            break;
                        }



                        command.Parameters["id_estoque"].Value = estoque.ID;
                        object result = command.ExecuteScalar();

                        double valor = result is double ? (double) result : 0;
                        toSave.Add(new EstoqueHistoricoValorClass(_usuarioAtual, connection)
                            {
                                Ano = data.Year,
                                Mes = data.Month,
                                DataGeracao = DataIndependenteClass.GetData(),
                                Estoque = estoque,
                                Valor = valor

                            }
                        );
                    }

                    foreach (EstoqueHistoricoValorClass historicoValorClass in toSave)
                    {
                        historicoValorClass.Save(ref command);
                    }


                    command.Transaction.Commit();

                }
                catch (ExcecaoTratada)
                {
                    if (command != null && command.Transaction != null)
                    {
                        command.Transaction.Rollback();
                    }
                    throw;
                }
                catch (Exception e)
                {
                    if (command != null && command.Transaction != null)
                    {
                        command.Transaction.Rollback();
                    }
                    throw new Exception("Erro inesperado ao salvar o histórico de valor do estoque.\r\n" + e.Message, e);
                }
            }
            finally
            {
                _semaphore?.Release();
            }
        }

        public void SafeStop()
        {
            _stop = true;
        }
    }
}
