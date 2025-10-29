using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using BibliotecaEntidades.Base;
using Configurations;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;
using ProjectConstants;

using iTextSharp.text.pdf;

namespace BibliotecaEntidades.Relatorios
{
    public enum SituacaoPedido { Atraso, EmProducao, NaoConfigurado }
    public class PedidosPendentesReportClass
    {
        private readonly string StatusPedido;
        public byte[] logoCli { get; private set; }
        public DateTime DataEntrega { get; private set; }
        public DateTime DataPedido { get; private set; }
        public string Pedido { get; private set; }
        public string Pos { get; private set; }
        public string ClienteResumido { get; private set; }
        public string Cliente { get; private set; }
        public string Codigo { get; private set; }
        public string Projeto { get; private set; }
        public string Descrição { get; private set; }
        public string Acabamento { get; private set; }
        public double quantidade { get; private set; }
        public double saldo { get; private set; }
        public string DataConfiguracao { get; private set; }
        public string Configurado { get; private set; }
        public string CodigoBarras { get; private set; }
        public byte[] barCode { get; private set; }
        public DateTime DataEntregaOriginal { get; private set; }
        public string TipoFrete { get; private set; }


        public string Status
        {
            get
            {
                if (this.DataEntrega < Configurations.DataIndependenteClass.GetData().Date)
                {
                    return "ATRASO";
                }

                if (this.Configurado == "1" && this.StatusPedido == "0")
                {
                    return "Em Produção";
                }

                if (this.Configurado == "0" && this.StatusPedido == "0")
                {
                    return "Não Configurado";
                }

                if (this.StatusPedido == "4")
                {
                    return "REABERTO";
                }
                return "";
            }
        }

        private DateTime dtIni;
        private DateTime dtFim;
        public string TituloData
        {
            get { return "Data de entrega de " + dtIni.ToString("dd/MM/yyyy") + " a " + dtFim.ToString("dd/MM/yyyy"); }
        }

        public string SemanaEntrega
        {
            get
            {
                int weekNum = IWTFunctions.IWTFunctions.getNumeroSemana(this.DataEntrega, IWTConfiguration.Conf.getConf(Constants.SEMANA_TIPO_DEFINICAO), IWTConfiguration.Conf.getConf(Constants.SEMANA_DIA));
                return Convert.ToInt32(this.DataEntrega.ToString("yy") + weekNum.ToString().PadLeft(2, '0')).ToString(CultureInfo.InvariantCulture);
            }
        }

        public string SemanaAtual
        {
            get
            {
                int weekNum = IWTFunctions.IWTFunctions.getNumeroSemana(Configurations.DataIndependenteClass.GetData(), IWTConfiguration.Conf.getConf(Constants.SEMANA_TIPO_DEFINICAO), IWTConfiguration.Conf.getConf(Constants.SEMANA_DIA));
                return Convert.ToInt32(Configurations.DataIndependenteClass.GetData().ToString("yy") + weekNum.ToString().PadLeft(2, '0')).ToString(CultureInfo.InvariantCulture);
            }
        }

        public PedidosPendentesReportClass(byte[] logoCli, DateTime dataEntrega, DateTime dataPedido, string pedido, string pos, string clienteResumido, string cliente, string codigo, string projeto, string descrição, string acabamento, double quantidade, double saldo, DateTime? dataConfiguracao, string configurado, string statusPedido, DateTime ini, DateTime fim, string codigoBarras, DateTime dataEntregaOriginal, string tipoFrete, string cidade)
        {
            DataEntrega = dataEntrega;
            this.DataPedido = dataPedido;
            Pedido = pedido;
            Pos = pos;
            Cliente = cliente;
            ClienteResumido = clienteResumido;
            if (!string.IsNullOrWhiteSpace(cidade))
            {
                Cliente += " (" + cidade + ")";
            }
            Codigo = codigo;
            
            Projeto = projeto;
            Descrição = descrição;
            Acabamento = acabamento;
            this.quantidade = quantidade;
            this.saldo = saldo;
            if (dataConfiguracao != null)
            {
                DataConfiguracao = dataConfiguracao.Value.ToString("dd/MM/yyyy");
            }else
            {
                DataConfiguracao = "";
            }
            this.CodigoBarras = codigoBarras;
            this.Configurado = configurado;
            this.StatusPedido = statusPedido;
            this.logoCli = logoCli;

            this.dtIni = ini;
            this.dtFim = fim;

            this.DataEntregaOriginal = dataEntregaOriginal;
            this.TipoFrete = tipoFrete;

            if (this.CodigoBarras != "")
            {
                Barcode128 code128 = new Barcode128();
                code128.CodeType = Barcode.CODE128;
                code128.ChecksumText = true;
                code128.GenerateChecksum = true;
                code128.StartStopText = true;
                code128.BarHeight = 85;
                code128.Code = this.CodigoBarras;

                string tempDir = Environment.GetEnvironmentVariable("temp");
                Bitmap codeBar = new Bitmap(code128.CreateDrawingImage(Color.Black, Color.White));
                codeBar.Save(@tempDir + "\\code.bmp");

                ImageConverter converter = new ImageConverter();
                Byte[] array = (byte[])converter.ConvertTo(codeBar, typeof(byte[]));

                this.barCode = array;
            }


        }

        public static List<PedidosPendentesReportClass> generateReport(DateTime ini, DateTime fim, IWTPostgreNpgsqlConnection singleConnection)
        {
            try
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

                }

                #endregion

                IWTPostgreNpgsqlCommand command = singleConnection.CreateCommand();
                command.CommandText =
                                "SELECT                                                                                                                     " +
                                "  public.pedido_item.pei_numero,                                                                                           " +
                                "  public.pedido_item.pei_posicao,                                                                                          " +
                                "  public.pedido_item.pei_quantidade,                                                                                       " +
                                "  public.pedido_item.pei_saldo,                                                                                            " +
                                "  public.pedido_item.pei_data_entrega,                                                                                     " +
                                "  public.pedido_item.pei_data_entrega_original,                                                                            " +
                                "  COALESCE(public.order_item_etiqueta.oie_acab_item_pai, acabamento.acb_identificacao) AS descricao_acabamento,                                " +
                                "  COALESCE(public.order_item_etiqueta.oie_desc_item_pai, produto.pro_descricao) AS descricao_item,                                           " +
                                "  public.pedido_item.pei_data_configuracao,                                                                                " +
                                "  public.pedido_item.pei_configurado,                                                                                      " +
                                "  COALESCE(public.order_item_etiqueta.oie_codigo_item_pai, produto.pro_codigo) AS codigo_item,                                            " +
                                "  public.cliente.cli_nome,                                                                                                 " +
                                "  public.cliente.cli_nome_resumido,                                                                                        " +
                                "  pedido_item.pei_projeto_cliente,                                                                                         " +
                                "  pedido_item.pei_status,                                                                                                  " +
                                "  public.pedido_item.pei_data_entrada,                                                                                     " +
                                "  public.order_item_etiqueta.id_order_item_etiqueta,                                                                                     " +
                                "  COALESCE(public.pedido_item.pei_responsavel_frete ,public.cliente.cli_responsavel_frete, produto.pro_responsavel_frete) as responsavel_frete, " +
                                "  cidade.cid_nome, "+
                                "  estado.est_sigla  " +
                                "FROM                                                                                                                       " +
                                "  public.pedido_item                                                                                                       " +
                                "  LEFT JOIN public.order_item_etiqueta ON (public.pedido_item.id_pedido_item = public.order_item_etiqueta.id_pedido_item)  " +
                                "  LEFT JOIN public.produto ON (public.produto.id_produto = public.pedido_item.id_produto) " +
                                "  LEFT JOIN public.produto_acabamento ON (public.produto.id_produto = public.produto_acabamento.id_produto AND public.produto.pro_versao_estrutura_atual = produto_acabamento.pac_versao_estrutura) " +
                                "  LEFT JOIN public.acabamento ON (public.acabamento.id_acabamento = public.produto.id_acabamento) " +
                                "  INNER JOIN public.cliente ON (public.pedido_item.id_cliente = public.cliente.id_cliente)                                 " +
                                "  LEFT OUTER JOIN public.cidade ON (public.cliente.id_cidade_cob = public.cidade.id_cidade) "+
                                "  LEFT OUTER JOIN public.estado ON (public.cidade.id_estado = public.estado.id_estado) "+
                                "WHERE                                                                                                                      " +
                                "   (public.pedido_item.pei_data_entrega < '" + Configurations.DataIndependenteClass.GetData().ToString("yyyy-MM-dd") + "' OR public.pedido_item.pei_data_entrega BETWEEN :ini AND :fim)               " +
                                "   AND (pei_status = 0 OR pei_status = 4)  " +
                                "   AND pei_sub_linha = 0                                                                                  " +
                                "GROUP BY                                                                                                                   " +
                                "  public.pedido_item.pei_numero,                                                                                           " +
                                "  public.pedido_item.pei_posicao,                                                                                          " +
                                "  public.pedido_item.pei_quantidade,                                                                                       " +
                                "  public.pedido_item.pei_saldo,                                                                                            " +
                                "  public.pedido_item.pei_data_entrega,                                                                                     " +
                                "  public.pedido_item.pei_data_entrega_original,                                                                            " +
                                "  public.order_item_etiqueta.oie_acab_item_pai,                                                                   " +
                                "  public.order_item_etiqueta.oie_desc_item_pai,                                                                   " +
                                "  public.pedido_item.pei_data_configuracao,                                                                                " +
                                "  public.pedido_item.pei_configurado,                                                                                      " +
                                "  public.order_item_etiqueta.oie_codigo_item_pai,                                                                   " +
                                "  public.cliente.cli_nome,                                                                                                 " +
                                "  public.cliente.cli_nome_resumido,                                                                                                 " +
                                "  pedido_item.pei_projeto_cliente,                                                                                         " +
                                "  pedido_item.pei_status,                                                                                                  " +
                                "  public.pedido_item.pei_data_entrada,                                                                                     " +
                                "  acabamento.acb_identificacao,                                                                                                  " +
                                "  produto.pro_descricao,                                                                                                  " +
                                "  produto.pro_codigo,                                                                                                  " +
                                "  order_item_etiqueta.id_order_item_etiqueta,                                                                                                   " +
                                "  public.pedido_item.pei_responsavel_frete, " +
                                "  public.cliente.cli_responsavel_frete, " +
                                "  produto.pro_responsavel_frete, " +
                                "  cidade.cid_nome, " +
                                "  estado.est_sigla  " +
                                "ORDER BY                                                                                                                   " +
                                "  public.pedido_item.pei_status,                                                                                           " +
                                "  public.pedido_item.pei_data_entrega                                                                                      ";

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ini", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = ini;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fim", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = fim;

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                if (!read.HasRows)
                {
                    throw new Exception("Não ha dados para geração do relatório");
                }
                List<PedidosPendentesReportClass> ds = new List<PedidosPendentesReportClass>();
                while (read.Read())
                {

                    string tipoFrete = "";
                    if (read["responsavel_frete"] != DBNull.Value)
                    {
                        switch ((ResponsavelFrete)Enum.ToObject(typeof(ResponsavelFrete), read["responsavel_frete"]))
                        {
                            case ResponsavelFrete.Emitente:
                                tipoFrete = "Emitente (CIF)";
                                break;
                            case ResponsavelFrete.Cliente:
                                tipoFrete = "Cliente (FOB)";
                                break;
                            case ResponsavelFrete.Terceiros:
                                tipoFrete = "Terceiros";
                                break;
                            case ResponsavelFrete.SemFrete:
                                tipoFrete = "Sem Frete";
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }

                    string cidade = "";
                    if (read["cid_nome"]!=DBNull.Value)
                    {
                        cidade = read["cid_nome"] + " - " + read["est_sigla"];
                    }

                    ds.Add(new PedidosPendentesReportClass(tmp,
                                                           Convert.ToDateTime(read["pei_data_entrega"]),
                                                           Convert.ToDateTime(read["pei_data_entrada"]),
                                                           read["pei_numero"].ToString(),
                                                           read["pei_posicao"].ToString(),
                                                           read["cli_nome_resumido"].ToString(),
                                                           read["cli_nome"].ToString(),
                                                           read["codigo_item"].ToString(),
                                                           read["pei_projeto_cliente"].ToString(),
                                                           read["descricao_item"].ToString(),
                                                           read["descricao_acabamento"].ToString(),
                                                           Convert.ToDouble(read["pei_quantidade"]),
                                                           Convert.ToDouble(read["pei_saldo"]),
                                                           read["pei_data_configuracao"] != DBNull.Value ? (DateTime?) Convert.ToDateTime(read["pei_data_configuracao"]) : null,
                                                           read["pei_configurado"].ToString(),
                                                           read["pei_status"].ToString(), ini, fim,
                                                           read["id_order_item_etiqueta"] != DBNull.Value ? "OIE_" + read["id_order_item_etiqueta"].ToString() : "",
                                                           read["pei_data_entrega_original"] != DBNull.Value ? Convert.ToDateTime(read["pei_data_entrega_original"]) : Convert.ToDateTime(read["pei_data_entrega"]),
                                                           tipoFrete,
                                                           cidade
                               )
                        );
                }
                read.Close();

                return ds;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}
