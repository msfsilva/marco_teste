using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Configurations;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;
using ProjectConstants;

namespace BibliotecaQualidade
{
    public class AcompanhamentoTemposReportClass
    {
        public int IdOrdemProducao { get; private set; }
        public string CodigoPosto { get; private set; }
        public string NomePosto { get; private set; }
        public int LeadTimePostoOp  { get; private set; }
        public double TempoPrevistoToleranciaProducao { get; private set; }
        public double TempoPrevistoToleranciaSetup { get; private set; }
        public double TempoEfetivoProducao { get; private set; }
        public double TempoEfetivoSetup { get; private set; }
        private byte[] logoCli;
        public byte[] LogoCliente
        {
            get
            {
                if (this.logoCli == null)
                {
                    #region Logo

                    byte[] tmp = IWTConfiguration.Conf.getBinaryConf(Constants.LOGO_EMPRESA);

                    if (tmp != null)
                    {
                        MemoryStream ms = new MemoryStream(tmp);
                        Image imagem = Image.FromStream(ms);

                        imagem = IWTFunctions.IWTFunctions.ResizeImage(imagem, 100, 100, false);

                        ms = new MemoryStream();
                        imagem.Save(ms, ImageFormat.Bmp);
                        tmp = ms.ToArray();
                        this.logoCli = tmp;
                    }

                    #endregion
                }
                return this.logoCli;
            }
        }

        

        private AcompanhamentoTemposReportClass(int idOrdemProducao, string codigoPosto, string nomePosto, int leadTimePostoOp, double tempoPrevistoToleranciaProducao, double tempoPrevistoToleranciaSetup, double tempoEfetivoProducao, double tempoEfetivoSetup)
        {
            IdOrdemProducao = idOrdemProducao;
            CodigoPosto = codigoPosto;
            NomePosto = nomePosto;
            LeadTimePostoOp = leadTimePostoOp;
            TempoPrevistoToleranciaProducao = tempoPrevistoToleranciaProducao;
            TempoPrevistoToleranciaSetup = tempoPrevistoToleranciaSetup;
            TempoEfetivoProducao = tempoEfetivoProducao;
            TempoEfetivoSetup = tempoEfetivoSetup;

            
        }

        public static List<AcompanhamentoTemposReportClass> generateReport(int tolerancia, DateTime data, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
                List<AcompanhamentoTemposReportClass> Itens = new List<AcompanhamentoTemposReportClass>();

                IWTPostgreNpgsqlCommand command = conn.CreateCommand();
                command.CommandText =
                    "SELECT * FROM                                                                                                                                                                                  " +
                    "(                                                                                                                                                                                            " +
                    " SELECT *,  rank() OVER w AS ran FROM                                                                                                                                                        " +
                    " (                                                                                                                                                                                           " +
                    " SELECT *                                                                                                                                                                                    " +
                    "    FROM                                                                                                                                                                                     " +
                    "    (                                                                                                                                                                                        " +
                    "        SELECT                                                                                                                                                                               " +
                    "          0 AS tipo,                                                                                                                                                                         " +
                    "          public.ordem_producao_posto_trabalho.id_ordem_producao,                                                                                                                            " +
                    "          public.ordem_producao_posto_trabalho.id_ordem_producao_posto_trabalho,                                                                                                             " +
                    "          public.posto_trabalho.pos_codigo,                                                                                                                                                  " +
                    "          public.posto_trabalho.pos_nome,                                                                                                                                                    " +
                    "          (CAST(EXTRACT(EPOCH FROM  ordem_producao.orp_data_encerramento - ordem_producao.orp_data) AS INTEGER))/86400 AS lead_time_op_dias,                                                 " +
                    "                                                                                                                                                                                             " +
                    "          CASE WHEN public.ordem_producao_posto_trabalho.opt_tempo3 IS NULL THEN                                                                                                             " +
                    "            ((ordem_producao_posto_trabalho.opt_tempo_producao * public.ordem_producao.orp_quantidade) + (ordem_producao_posto_trabalho.opt_tempo_setup * 3600)) * (1+(:tolerancia*0.01))    " +
                    "          ELSE                                                                                                                                                                               " +
                    "            (ordem_producao_posto_trabalho.opt_tempo_producao * public.ordem_producao.orp_quantidade) * (1+(:tolerancia*0.01))                                                               " +
                    "          END AS tempo_previsto_tolerancia_prod,                                                                                                                                             " +
                    "                                                                                                                                                                                             " +
                    "          (ordem_producao_posto_trabalho.opt_tempo_setup*3600) * (1+(:tolerancia*0.01)) AS tempo_previsto_tolerancia_setup,                                                                  " +
                    "                                                                                                                                                                                             " +
                    "          CASE WHEN public.ordem_producao_posto_trabalho.opt_tempo3 IS NULL THEN                                                                                                             " +
                    "            CAST(EXTRACT(EPOCH FROM ordem_producao_posto_trabalho.opt_tempo2 - ordem_producao_posto_trabalho.opt_tempo1) AS Integer) + (ordem_producao_posto_trabalho.opt_tempo_setup * 3600)  " +
                    "          ELSE                                                                                                                                                                                " +
                    "            CAST(EXTRACT(EPOCH FROM ordem_producao_posto_trabalho.opt_tempo3 - ordem_producao_posto_trabalho.opt_tempo2) AS Integer)                                                          " +
                    "          END AS efetivo_producao,                                                                                                                                                           " +
                    "                                                                                                                                                                                             " +
                    "          CASE WHEN public.ordem_producao_posto_trabalho.opt_tempo3 IS NOT NULL THEN                                                                                                         " +
                    "             ordem_producao_posto_trabalho.opt_tempo_setup                                                                                                                                   " +
                    "          ELSE                                                                                                                                                                               " +
                    "             0                                                                                                                                                                               " +
                    "          END AS efetivo_setup                                                                                                                                                               " +
                    "        FROM                                                                                                                                                                                 " +
                    "          public.ordem_producao                                                                                                                                                              " +
                    "            JOIN ordem_producao_posto_trabalho ON (ordem_producao.id_ordem_producao = ordem_producao_posto_trabalho.id_ordem_producao )                                                      " +
                    "            JOIN public.posto_trabalho ON (public.ordem_producao_posto_trabalho.id_posto_trabalho = public.posto_trabalho.id_posto_trabalho)                                                 " +
                    "        WHERE                                                                                                                                                                                " +
                    "          public.ordem_producao.orp_situacao = 2 AND                                                                                                                                         " +
                    "          public.ordem_producao.orp_data_encerramento > :dataInicial AND                                                                                                                     " +
                    "          public.ordem_producao_posto_trabalho.opt_tempo2 IS NOT NULL                                                                                                                        " +
                    "    ) as postos_trabalho_tempo                                                                                                                                                               " +
                    "    WHERE                                                                                                                                                                                    " +
                    "      (postos_trabalho_tempo.efetivo_producao > postos_trabalho_tempo.tempo_previsto_tolerancia_prod) OR                                                                                     " +
                    "      (postos_trabalho_tempo.efetivo_setup > postos_trabalho_tempo.tempo_previsto_tolerancia_setup)                                                                                          " +
                    "                                                                                                                                                                                             " +
                    "  UNION ALL                                                                                                                                                                                " +
                    "                                                                                                                                                                                             " +
                    "    SELECT  1 AS tipo,                                                                                                                                                                       " +
                    "    		ordem_producao.id_ordem_producao,                                                                                                                                                 " +
                    "			public.ordem_producao_posto_trabalho.id_ordem_producao_posto_trabalho,                                                                                                            " +
                    "            posto_trabalho.pos_codigo,                                                                                                                                                       " +
                    "            posto_trabalho.pos_nome,                                                                                                                                                         " +
                    "            CAST(EXTRACT(EPOCH FROM  ordem_producao.orp_data_encerramento - ordem_producao.orp_data) AS Integer)/86400 AS lead_time_op_dias,                                                     " +
                    "            0,0,0,0                                                                                                                                                                          " +
                    "    FROM (                                                                                                                                                                                   " +
                    "                                                                                                                                                                                             " +
                    "    	SELECT                                                                                                                                                                                " +
                    "          DISTINCT postos_trabalho_tempo.id_ordem_producao                                                                                                                                   " +
                    "        FROM                                                                                                                                                                                 " +
                    "        (                                                                                                                                                                                    " +
                    "          SELECT                                                                                                                                                                             " +
                    "            public.ordem_producao_posto_trabalho.id_ordem_producao,                                                                                                                          " +
                    "            public.ordem_producao_posto_trabalho.id_ordem_producao_posto_trabalho,                                                                                                           " +
                    "            CASE WHEN public.ordem_producao_posto_trabalho.opt_tempo3 IS NULL THEN                                                                                                           " +
                    "              ((ordem_producao_posto_trabalho.opt_tempo_producao * public.ordem_producao.orp_quantidade) + (ordem_producao_posto_trabalho.opt_tempo_setup * 3600)) * (1+(:tolerancia*0.01))    " +
                    "            ELSE                                                                                                                                                                             " +
                    "              (ordem_producao_posto_trabalho.opt_tempo_producao * public.ordem_producao.orp_quantidade) * (1+(:tolerancia*0.01))                                                               " +
                    "            END AS tempo_previsto_tolerancia_prod,                                                                                                                                           " +
                    "                                                                                                                                                                                             " +
                    "            (ordem_producao_posto_trabalho.opt_tempo_setup*3600) * (1+(:tolerancia*0.01)) AS tempo_previsto_tolerancia_setup,                                                                " +
                    "                                                                                                                                                                                             " +
                    "            CASE WHEN public.ordem_producao_posto_trabalho.opt_tempo3 IS NULL THEN                                                                                                           " +
                    "              CAST(EXTRACT(EPOCH FROM ordem_producao_posto_trabalho.opt_tempo2 - ordem_producao_posto_trabalho.opt_tempo1) AS Integer) + (ordem_producao_posto_trabalho.opt_tempo_setup * 3600)  " +
                    "            ELSE                                                                                                                                                                             " +
                    "              CAST(EXTRACT(EPOCH FROM ordem_producao_posto_trabalho.opt_tempo3 - ordem_producao_posto_trabalho.opt_tempo2) AS Integer)                                                           " +
                    "            END AS efetivo_producao,                                                                                                                                                         " +
                    "                                                                                                                                                                                             " +
                    "            CASE WHEN public.ordem_producao_posto_trabalho.opt_tempo3 IS NOT NULL THEN                                                                                                       " +
                    "               ordem_producao_posto_trabalho.opt_tempo_setup                                                                                                                                 " +
                    "            ELSE                                                                                                                                                                             " +
                    "               0                                                                                                                                                                             " +
                    "            END AS efetivo_setup                                                                                                                                                             " +
                    "          FROM                                                                                                                                                                               " +
                    "            public.ordem_producao                                                                                                                                                            " +
                    "            JOIN ordem_producao_posto_trabalho ON (ordem_producao.id_ordem_producao = ordem_producao_posto_trabalho.id_ordem_producao	)                                                     " +
                    "            JOIN public.posto_trabalho ON (public.ordem_producao_posto_trabalho.id_posto_trabalho = public.posto_trabalho.id_posto_trabalho)                                                 " +
                    "          WHERE                                                                                                                                                                              " +
                    "            public.ordem_producao.orp_situacao = 2 AND                                                                                                                                       " +
                    "            public.ordem_producao.orp_data_encerramento > :dataInicial AND                                                                                                                   " +
                    "            public.ordem_producao_posto_trabalho.opt_tempo2 IS NOT NULL                                                                                                                      " +
                    "                                                                                                                                                                                             " +
                    "        ) as postos_trabalho_tempo                                                                                                                                                           " +
                    "    WHERE                                                                                                                                                                                    " +
                    "      (postos_trabalho_tempo.efetivo_producao > postos_trabalho_tempo.tempo_previsto_tolerancia_prod) OR                                                                                     " +
                    "      (postos_trabalho_tempo.efetivo_setup > postos_trabalho_tempo.tempo_previsto_tolerancia_setup)                                                                                          " +
                    "                                                                                                                                                                                             " +
                    "        ) AS op_problema                                                                                                                                                                     " +
                    "           JOIN public.ordem_producao ON (ordem_producao.id_ordem_producao = op_problema.id_ordem_producao)                                                                                  " +
                    "        	JOIN ordem_producao_posto_trabalho ON (ordem_producao.id_ordem_producao = ordem_producao_posto_trabalho.id_ordem_producao	)                                                     " +
                    "       		 JOIN public.posto_trabalho ON (public.ordem_producao_posto_trabalho.id_posto_trabalho = public.posto_trabalho.id_posto_trabalho)                                             " +
                    "                                                                                                                                                                                             " +
                    "                                                                                                                                                                                             " +
                    ") AS todos_dados                                                                                                                                                                             " +
                    " WINDOW w AS (PARTITION BY                                                                                                                                                                   " +
                    "          id_ordem_producao_posto_trabalho                                                                                                                                                   " +
                    "         ORDER BY tipo)                                                                                                                                                                      " +
                    "                                                                                                                                                                                             " +
                    ") AS final WHERE ran = 1                                                                                                                                                                     ";

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dataInicial", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = data;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tolerancia", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = tolerancia;


                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    Itens.Add(
                        new AcompanhamentoTemposReportClass(Convert.ToInt32(read["id_ordem_producao"]),
                                                            read["pos_codigo"].ToString(),
                                                            read["pos_nome"].ToString(),
                                                            Convert.ToInt32(read["lead_time_op_dias"]),
                                                            Convert.ToDouble(read["tempo_previsto_tolerancia_prod"]),
                                                            Convert.ToDouble(read["tempo_previsto_tolerancia_setup"]),
                                                            Convert.ToDouble(read["efetivo_producao"]),
                                                            Convert.ToDouble(read["efetivo_setup"])));
                }

                return Itens;

                read.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar o relatório de acompanhamento de tempos\r\n" + e.Message, e);
            }
        }
    }
}
