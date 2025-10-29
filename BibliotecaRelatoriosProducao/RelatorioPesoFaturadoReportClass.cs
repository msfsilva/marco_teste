using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;
using dbProvider;

namespace BibliotecaRelatoriosProducao
{
    public class RelatorioPesoFaturadoReportClass
    {
        private class MediaAnoClass
        {
            public int Ano { get; set; }

            private int maiorMes;
            public double Qtd { get; private set; }

            public MediaAnoClass(int ano)
            {
                Ano = ano;
                maiorMes = 1;
                Qtd = 0;
            }

            public double MediaMensal
            {
                get { return Qtd/(maiorMes); }
            }

            public void adicionarQuantidade(int mes, double qtd)
            {
                if (mes > maiorMes) maiorMes = mes;

                Qtd += qtd;
            }
        }

        public string CodigoItem { get; private set; }
        public int Mes { get; private set; }
        public int Ano { get; private set; }
        public double PesoTotal { get; private set; }
        public double Qtd { get; private set; }
        public string Pedido { get; private set; }
        public string Cliente { get; private set; }

        public double MediaAnual { get; private set; }
        public double TotalAnual { get; private set; }

        public RelatorioPesoFaturadoReportClass(string codigoItem, int mes, int ano, double pesoTotal, double qtd, string pedido, string cliente)
        {
            CodigoItem = codigoItem;
            Mes = mes;
            Ano = ano;
            PesoTotal = pesoTotal;
            Qtd = qtd;
            Pedido = pedido;
            Cliente = cliente;
        }

        public static List<RelatorioPesoFaturadoReportClass> Gerar(DateTime inicio, DateTime fim, out string intervaloDados)
        {
            try
            {

                DateTime inicioDados = new DateTime(inicio.Year, 1, 1);
                DateTime fimDados = new DateTime(fim.Year + 1, 1, 1);

                IWTPostgreNpgsqlCommand command = DbConnection.Connection.CreateCommand();
                command.CommandText =
                    "SELECT  " +
                    "  public.order_item_etiqueta_conferencia.oic_codigo_item, " +
                    "  SUM(public.order_item_etiqueta_conferencia.oic_quantidade_conferida * public.order_item_etiqueta_conferencia.oic_peso_unitario) AS peso, " +
                    "  EXTRACT('month' FROM public.order_item_etiqueta_conferencia.oic_data_conferencia) AS mes, " +
                    "  EXTRACT('year' FROM public.order_item_etiqueta_conferencia.oic_data_conferencia) AS ano, " +
                    "  (public.order_item_etiqueta_conferencia.oic_order_number ||'/'|| public.order_item_etiqueta_conferencia.oic_order_pos) AS pedido, " +
                    "  SUM(public.order_item_etiqueta_conferencia.oic_quantidade_conferida) AS qtd, " +
                    "  public.cliente.cli_nome_resumido " +
                    "FROM " +
                    "  public.order_item_etiqueta_conferencia " +
                    "  INNER JOIN public.order_item_etiqueta ON (public.order_item_etiqueta_conferencia.id_order_item_etiqueta = public.order_item_etiqueta.id_order_item_etiqueta) " +
                    "  INNER JOIN public.cliente ON (public.order_item_etiqueta.id_cliente = public.cliente.id_cliente) " +
                    "WHERE " +
                    "  public.order_item_etiqueta_conferencia.oic_data_conferencia BETWEEN :data_inicial AND :data_final " +
                    "GROUP BY " +
                    "  public.order_item_etiqueta_conferencia.oic_codigo_item, " +
                    "  EXTRACT('month' FROM public.order_item_etiqueta_conferencia.oic_data_conferencia), " +
                    "  EXTRACT('year' FROM public.order_item_etiqueta_conferencia.oic_data_conferencia), " +
                    "  pedido, " +
                    "  public.cliente.cli_nome_resumido " +
                    "HAVING " +
                    "  SUM(public.order_item_etiqueta_conferencia.oic_quantidade_conferida * public.order_item_etiqueta_conferencia.oic_peso_unitario) > 0 " +
                    "ORDER BY " +
                    "  EXTRACT('year' FROM public.order_item_etiqueta_conferencia.oic_data_conferencia), " +
                    "  EXTRACT ('month' FROM public.order_item_etiqueta_conferencia.oic_data_conferencia), " +
                    "  public.order_item_etiqueta_conferencia.oic_codigo_item ";

                command.Parameters.Clear();


                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("data_inicial", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = inicioDados.Date;

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("data_final", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = fimDados.Date;
                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                List<RelatorioPesoFaturadoReportClass> toRet = new List<RelatorioPesoFaturadoReportClass>();
                Dictionary<int, MediaAnoClass> mediasPesosAno = new Dictionary<int, MediaAnoClass>();

                while (read.Read())
                {
                    toRet.Add(new RelatorioPesoFaturadoReportClass(
                                  read["oic_codigo_item"].ToString(),
                                  Convert.ToInt32(read["mes"]),
                                  Convert.ToInt32(read["ano"]),
                                  Convert.ToDouble(read["peso"]),
                                  Convert.ToDouble(read["qtd"]),
                                  read["pedido"].ToString(),
                                  read["cli_nome_resumido"].ToString()
                                  ));

                    int ano = Convert.ToInt32(read["ano"]);
                    if (!mediasPesosAno.ContainsKey(ano))
                    {
                        mediasPesosAno.Add(ano, new MediaAnoClass(ano));
                    }
                    mediasPesosAno[ano].adicionarQuantidade(Convert.ToInt32(read["mes"]), Convert.ToDouble(read["peso"]));
                }

                read.Close();

                foreach (RelatorioPesoFaturadoReportClass linha in toRet)
                {
                    linha.MediaAnual = mediasPesosAno[linha.Ano].MediaMensal;
                    linha.TotalAnual = mediasPesosAno[linha.Ano].Qtd;
                }

                toRet = toRet.Where(

                    a => ((a.Ano == inicio.Year && a.Mes >= inicio.Month) || (a.Ano > inicio.Year))
                         && (a.Ano == fim.Year && a.Mes <= fim.Month) || (a.Ano < fim.Year)

                    ).ToList();

                if (toRet.Count == 0)
                {
                    throw new Exception("Não existem registros para o período selecionado");
                }

                intervaloDados = inicio.ToString("dd/MM/yyyy") + " à " + fim.ToString("dd/MM/yyyy");
                return toRet;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar o relatório.\r\n" + e.Message, e);
            }
        }


    }
}
