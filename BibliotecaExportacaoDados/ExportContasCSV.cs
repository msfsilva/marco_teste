using System;
using System.Globalization;
using System.IO;
using System.Text;
using IWTPostgreNpgsql;
using Npgsql;

namespace BibliotecaExportacaoDados
{
    public enum TipoContaExportCSV
    {
        Pagar,
        Receber,
        Todas
    }

    public enum BaixadasContaExportCSV
    {
        Pagas,
        Abertas,
        Todas
    }


    public class ExportContasCSV
    {
         readonly IWTPostgreNpgsqlConnection conn;

        public ExportContasCSV(IWTPostgreNpgsqlConnection conn)
        {
            this.conn = conn;
        }

         public string gerarCSV(DateTime? dataInicio, DateTime? dataFim, TipoContaExportCSV tipoConta, BaixadasContaExportCSV baixadas,
            string outputDir)
         {
               StreamWriter writer = null;
               try
               {
                   #region Testa Dir e cria arquivo saida

                   if (!Directory.Exists(outputDir))
                   {
                       throw new Exception("Diretório de saída inválido.");
                   }

                   string fileName = outputDir + "/exportContasEasi.csv";
                   writer = new StreamWriter(fileName, false, Encoding.GetEncoding(1252));
                   writer.AutoFlush = true;


                   #endregion

                   #region Cabeçalho

                   string linhaCabecalho =
                       "Tipo;Vencimento;Nº Documento;Valor;Data Pagamento;Valor Pago;Descrição;Data Emissão;Desconto;Acréscimo;Meio de Pagamento;" +
                       "Nota Fiscal;Cliente/Fornecedor;Cliente/Fornecedor CNPJ;Banco;Cód. Banco;Agência;Conta;Centro Custo/Lucro Código;Centro Custo/Lucro Identificação;Pedidos";

                   writer.WriteLine(linhaCabecalho);

                   #endregion


                   #region Buscas

                   string sqlClausePagar = "";
                   string sqlClauseReceber = "";
                   if (dataInicio.HasValue)
                   {
                       sqlClauseReceber += " AND ((cor_data_pagamento IS NULL AND cor_data_vencimento >= '" +
                                           dataInicio.Value.ToString("yyyy-MM-dd") + "') OR cor_data_pagamento >= '" +
                                           dataInicio.Value.ToString("yyyy-MM-dd") + "') ";

                       sqlClausePagar += " AND ((cop_data_pagamento IS NULL AND cop_data_vencimento >= '" +
                                           dataInicio.Value.ToString("yyyy-MM-dd") + "') OR cop_data_pagamento >= '" +
                                           dataInicio.Value.ToString("yyyy-MM-dd") + "') ";

                   }

                   if (dataFim.HasValue)
                   {
                       sqlClauseReceber += " AND ((cor_data_pagamento IS NULL AND cor_data_vencimento < '" +
                                           dataFim.Value.AddDays(1).ToString("yyyy-MM-dd") + "') OR cor_data_pagamento < '" +
                                           dataFim.Value.AddDays(1).ToString("yyyy-MM-dd") + "') ";

                       sqlClausePagar += " AND ((cop_data_pagamento IS NULL AND cop_data_vencimento < '" +
                                           dataFim.Value.AddDays(1).ToString("yyyy-MM-dd") + "') OR cop_data_pagamento < '" +
                                           dataFim.Value.AddDays(1).ToString("yyyy-MM-dd") + "') ";

                   }

                   switch (baixadas)
                   {
                       case BaixadasContaExportCSV.Pagas:
                           sqlClauseReceber += " AND cor_data_pagamento IS NOT NULL ";
                           sqlClausePagar += " AND cop_data_pagamento IS NOT NULL ";
                           break;
                       case BaixadasContaExportCSV.Abertas:
                           sqlClauseReceber += " AND cor_data_pagamento IS NULL ";
                           sqlClausePagar += " AND cop_data_pagamento IS NULL ";
                           break;
                       case BaixadasContaExportCSV.Todas:
                           break;
                       default:
                           throw new ArgumentOutOfRangeException("baixadas");
                   }

                   if (sqlClausePagar.Length>0)
                   {
                       sqlClausePagar = " WHERE " + sqlClausePagar.Substring(4);
                       sqlClauseReceber = " WHERE " + sqlClauseReceber.Substring(4);
                   }

                   string sqlPagar =
                       "SELECT  " +
                       "  'PAGAR' as tipo, " +
                       "  public.conta_pagar.cop_data_vencimento as vencimento, " +
                       "  public.conta_pagar.cop_num_documento as documento, " +
                       "  public.conta_pagar.cop_valor as valor, " +
                       "  public.conta_pagar.cop_data_pagamento as data_pagamento, " +
                       "  public.conta_pagar.cop_valor_pago as valor_pago, " +
                       "  public.conta_pagar.cop_historico as historico, " +
                       "  public.conta_pagar.cop_data_emissao as data_emissao, " +
                       "  public.conta_pagar.cop_desconto as desconto, " +
                       "  public.conta_pagar.cop_acrescimo as acrescimo, " +
                       "  public.tipo_pagamento.tip_identificacao as tipo_pagto, " +
                       "  public.nota_fiscal_entrada.nen_numero_nf as numero_nf, " +
                       "  public.nota_fiscal_entrada.nen_data_nf as data_nf, " +
                       "  public.credor_devedor.crd_nome as nome, " +
                       "  public.credor_devedor.crd_cnpj as cnpj, " +
                       "  public.conta_bancaria.cba_nome_banco as banco, " +
                       "  public.conta_bancaria.cba_codigo_banco as banco_cod, " +
                       "  public.conta_bancaria.cba_numero_conta as numero_conta, " +
                       "  public.conta_bancaria.cba_agencia as agencia, " +
                       "  public.centro_custo_lucro.ccl_codigo, " +
                       "  public.centro_custo_lucro.ccl_identificacao, " +
                       "  '' as pedidos " +
                       "FROM " +
                       "  public.conta_pagar " +
                       "  LEFT JOIN public.tipo_pagamento ON (public.conta_pagar.id_tipo_pagamento = public.tipo_pagamento.id_tipo_pagamento) " +
                       "  LEFT JOIN public.nota_fiscal_entrada ON (public.conta_pagar.id_nota_fiscal_entrada = public.nota_fiscal_entrada.id_nota_fiscal_entrada) " +
                       "  LEFT JOIN public.credor_devedor ON (public.conta_pagar.id_credor = public.credor_devedor.id_credor_devedor) " +
                       "  LEFT JOIN public.centro_custo_lucro ON (public.conta_pagar.id_centro_custo_lucro = public.centro_custo_lucro.id_centro_custo_lucro) " +
                       "  LEFT JOIN public.conta_bancaria ON (public.conta_pagar.id_conta_bancaria = public.conta_bancaria.id_conta_bancaria) " +
                       sqlClausePagar;

                   string sqlReceber =
                       "SELECT  " +
                       "  'RECEBER' as tipo, " +
                       "  public.conta_receber.cor_data_vencimento as vencimento, " +
                       "  public.conta_receber.cor_num_documento as documento, " +
                       "  public.conta_receber.cor_valor as valor, " +
                       "  public.conta_receber.cor_data_pagamento as data_pagamento, " +
                       "  public.conta_receber.cor_valor_pago as valor_pago, " +
                       "  public.conta_receber.cor_historico as historico, " +
                       "  public.conta_receber.cor_data_emissao as data_emissao, " +
                       "  public.conta_receber.cor_desconto as desconto, " +
                       "  public.conta_receber.cor_acrescimo as acrescimo, " +
                       "  public.tipo_pagamento.tip_identificacao as tipo_pagto, " +
                       "  CAST (public.nf_principal.nfp_numero AS VARCHAR) as numero_nf, " +
                       "  public.nf_principal.nfp_data_emissao as data_nf, " +
                       "  public.credor_devedor.crd_nome as nome, " +
                       "  public.credor_devedor.crd_cnpj as cnpj, " +
                       "  public.conta_bancaria.cba_nome_banco as banco, " +
                       "  public.conta_bancaria.cba_codigo_banco as banco_cod, " +
                       "  public.conta_bancaria.cba_numero_conta as numero_conta, " +
                       "  public.conta_bancaria.cba_agencia as agencia, " +
                       "  public.centro_custo_lucro.ccl_codigo, " +
                       "  public.centro_custo_lucro.ccl_identificacao ," +
                       "  iwt_agregate_pedidos_op(pedido_item.pei_numero ||'/'|| pedido_item.pei_posicao) pedidos " +
                       "FROM " +
                       "  public.conta_receber " +
                       "  LEFT JOIN public.tipo_pagamento ON (public.conta_receber.id_tipo_pagamento = public.tipo_pagamento.id_tipo_pagamento) " +
                       "  LEFT JOIN public.nf_principal ON (public.conta_receber.id_nf_principal = public.nf_principal.id_nf_principal) " +
                       "  LEFT JOIN public.credor_devedor ON (public.conta_receber.id_devedor = public.credor_devedor.id_credor_devedor) " +
                       "  LEFT JOIN public.centro_custo_lucro ON (public.conta_receber.id_centro_custo_lucro = public.centro_custo_lucro.id_centro_custo_lucro) " +
                       "  LEFT JOIN public.conta_bancaria ON (public.conta_receber.id_conta_bancaria = public.conta_bancaria.id_conta_bancaria) " +
                       "  LEFT JOIN public.atendimento ON (public.atendimento.id_nf_principal=public.nf_principal.id_nf_principal) " +
                       "  LEFT JOIN public.pedido_item ON (public.pedido_item.id_pedido_item=public.atendimento.id_pedido_item) "
                       + sqlClauseReceber +
                       " GROUP BY " +
                       "    public.conta_receber.cor_data_vencimento, " +
                       "    public.conta_receber.cor_num_documento,  " +
                       "    public.conta_receber.cor_valor, " +
                       "    public.conta_receber.cor_data_pagamento, " +
                       "    public.conta_receber.cor_valor_pago, " +
                       "    public.conta_receber.cor_historico, " +
                       "    public.conta_receber.cor_data_emissao, " +
                       "    public.conta_receber.cor_desconto, " +
                       "    public.conta_receber.cor_acrescimo, " +
                       "    public.tipo_pagamento.tip_identificacao, " +
                       "    CAST (public.nf_principal.nfp_numero AS VARCHAR), " +
                       "    public.nf_principal.nfp_data_emissao, " +
                       "    public.credor_devedor.crd_nome, " +
                       "    public.credor_devedor.crd_cnpj, " +
                       "    public.conta_bancaria.cba_nome_banco, " +
                       "    public.conta_bancaria.cba_codigo_banco, " +
                       "    public.conta_bancaria.cba_numero_conta, " +
                       "    public.conta_bancaria.cba_agencia, " +
                       "    public.centro_custo_lucro.ccl_codigo, " +
                       "    public.centro_custo_lucro.ccl_identificacao ";
                       

                   string sql = "SELECT * FROM ";
                   switch (tipoConta)
                   {
                       case TipoContaExportCSV.Pagar:
                           sql += " ( " + sqlPagar + ") as tab ORDER BY vencimento";
                           break;
                       case TipoContaExportCSV.Receber:
                           sql += " ( " + sqlReceber + ") as tab ORDER BY vencimento";
                           break;
                       case TipoContaExportCSV.Todas:
                           sql += " ( " + sqlPagar + " UNION ALL " + sqlReceber + " ) as tab ORDER BY vencimento";
                           break;
                       default:
                           throw new ArgumentOutOfRangeException("tipoConta");
                   }

                   #endregion

                   IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                   command.CommandText = sql;
                   

                   IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                   while (read.Read())
                   {

                       writer.Write(read["tipo"].ToString() + ";");
                       writer.Write(Convert.ToDateTime(read["vencimento"]).ToString("dd-MM-yyyy") + ";");
                       writer.Write(read["documento"].ToString().Replace("\r\n", "") + ";");
                       writer.Write(Convert.ToDouble(read["valor"]).ToString("F5", CultureInfo.GetCultureInfo("pt-BR")).Replace("\r\n", "") + ";");
                       if (read["data_pagamento"] != DBNull.Value)
                       {
                           writer.Write(Convert.ToDateTime(read["data_pagamento"]).ToString("dd-MM-yyyy") + ";");
                       }
                       else
                       {
                           writer.Write(";");
                       }

                       if (read["valor_pago"] != DBNull.Value)
                       {
                           writer.Write(
                               Convert.ToDouble(read["valor_pago"]).ToString("F5", CultureInfo.GetCultureInfo("pt-BR")).
                                   Replace("\r\n", "") + ";");
                       }
                       else
                       {
                           writer.Write(";");
                       }

                       writer.Write(read["historico"].ToString().Replace("\r\n", "") + ";");
                       writer.Write(Convert.ToDateTime(read["data_emissao"]).ToString("dd-MM-yyyy") + ";");
                       writer.Write(Convert.ToDouble(read["desconto"]).ToString("F5", CultureInfo.GetCultureInfo("pt-BR")).Replace("\r\n", "") + ";");
                       writer.Write(Convert.ToDouble(read["acrescimo"]).ToString("F5", CultureInfo.GetCultureInfo("pt-BR")).Replace("\r\n", "") + ";");
                       writer.Write(read["tipo_pagto"].ToString().Replace("\r\n", "") + ";");
                       writer.Write(read["numero_nf"].ToString().Replace("\r\n", "") + ";");
                       writer.Write(read["nome"].ToString().Replace("\r\n", "") + ";");
                       writer.Write(read["cnpj"].ToString().Replace("\r\n", "") + ";");
                       writer.Write(read["banco"].ToString().Replace("\r\n", "") + ";");
                       writer.Write(read["banco_cod"].ToString().Replace("\r\n", "") + ";");
                       writer.Write(read["agencia"].ToString().Replace("\r\n", "") + ";");
                       writer.Write(read["numero_conta"].ToString().Replace("\r\n", "") + ";");
                       writer.Write("\""+read["ccl_codigo"].ToString().Replace("\r\n", "") + "\";");
                       writer.Write(read["ccl_identificacao"].ToString().Replace("\r\n", "") + ";");
                       writer.Write(read["pedidos"].ToString().Replace("\r\n", "") + ";");

                       writer.WriteLine();

                   }

                   read.Close();


                   return fileName;

               }
               catch (Exception e)
               {
                   throw new Exception("Erro ao exportar os pedidos em CSV.\r\n" + e.Message, e);
               }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
         }
  
    }
}
