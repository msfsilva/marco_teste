using System;
using System.Collections.Generic;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;

namespace BibliotecaQualidade
{
    public class ObsolescenciaRelatClass
    {
        IWTPostgreNpgsqlConnection conn;
        public List<ObsolescenciaItemRelatClass> Itens { get; private set; }

        public ObsolescenciaRelatClass(IWTPostgreNpgsqlConnection conn)
        {
            this.conn = conn;
        }

        public void Gerar(int mes, int ano)
        {

            try
            {
                this.Itens = new List<ObsolescenciaItemRelatClass>();
                DateTime dataInicial = new DateTime(ano, mes, 1);
                DateTime dataFinal = dataInicial.AddMonths(1).AddDays(-1);

                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText =
                    "SELECT  " +
                    "  public.material.id_material, " +
                    //"  public.agrupador_material.agm_identificacao|| ' '|| " +
                    "  public.familia_material.fam_codigo || ' '|| " +
                    "  public.material.mat_codigo as mat_completo, " +
                    "  public.nota_fiscal_entrada_linha.nel_quantidade, " +
                    "  coalesce(public.lote.lot_data_validade, public.lote.lot_data_fabricacao + CAST((coalesce(mat_controle_validade_meses, 0) || 'months') as interval)) AS validade, " +
                    "  public.lote.lot_numero " +
                    "FROM " +
                    "  public.historico_compra_material " +
                    "  INNER JOIN public.nota_fiscal_entrada_linha ON (public.historico_compra_material.id_nota_fiscal_entrada_linha = public.nota_fiscal_entrada_linha.id_nota_fiscal_entrada_linha) " +
                    "  INNER JOIN public.lote ON (public.historico_compra_material.id_lote = public.lote.id_lote) " +
                    "  INNER JOIN public.material ON (public.historico_compra_material.id_material = public.material.id_material) " +
                    "  INNER JOIN public.familia_material ON (public.material.id_familia_material = public.familia_material.id_familia_material) " +
                    "  INNER JOIN public.agrupador_material ON (public.familia_material.id_agrupador_material = public.agrupador_material.id_agrupador_material) " +
                    "WHERE " +
                    "  public.material.mat_controle_validade = 1 AND  " +
                    "  (public.lote.lot_data_validade IS NOT NULL OR  " +
                    "  public.lote.lot_data_fabricacao IS NOT NULL) AND " +
                    "  CAST(coalesce(public.lote.lot_data_validade, public.lote.lot_data_fabricacao + CAST((coalesce(mat_controle_validade_meses, 0) || 'months') as interval)) AS DATE) BETWEEN :dataInicial AND :dataFinal " +
                    "ORDER BY " +
                    //"  public.agrupador_material.agm_identificacao, " +
                    "  public.familia_material.fam_codigo, " +
                    "  public.material.mat_codigo, " +
                    "  CAST(coalesce(public.lote.lot_data_validade, public.lote.lot_data_fabricacao + CAST((coalesce(mat_controle_validade_meses, 0) || 'months') as interval)) AS DATE) ";

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dataInicial", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = dataInicial;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dataFinal", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = dataFinal;


                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    this.Itens.Add(
                        new ObsolescenciaItemRelatClass(
                            Convert.ToInt32(read["id_material"]),
                            read["mat_completo"].ToString(),
                            read["lot_numero"].ToString(),
                            Convert.ToDouble(read["nel_quantidade"]),
                            Convert.ToDateTime(read["validade"])
                            )
                        );
                }
                read.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar o relatório de obsolescência de materiais\r\n" + e.Message, e);
            }

        }
    }

    public class ObsolescenciaItemRelatClass
    {
        public int IdMaterial { get; private set; }
        public string Material { get; private set; }
        public string NumeroLote { get; private set; }
        public double Quantidade { get; private set; }
        public DateTime DataValidade { get; private set; }

        public ObsolescenciaItemRelatClass(int idMaterial, string material, string numeroLote, double quantidade, DateTime dataValidade)
        {
            IdMaterial = idMaterial;
            Material = material;
            NumeroLote = numeroLote;
            Quantidade = quantidade;
            DataValidade = dataValidade;
        }
    }
}
