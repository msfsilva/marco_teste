#region Referencias

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using IWTPostgreNpgsql;
using Npgsql;
using iTextSharp.text.pdf;

#endregion

namespace ModuloKits
{
    class SemKitReportClass
    {
        private readonly byte[] logoEmpresa;

        public SemKitReportClass(List<KitClass> OCs,byte[] logo, string printer, IWTPostgreNpgsqlConnection conn, bool reimpressao)
        {
            IWTPostgreNpgsqlCommand command = null;

                #region Logo

            logoEmpresa = logo;

            if (logoEmpresa != null)
            {
                MemoryStream ms = new MemoryStream(logoEmpresa);
                Image imagem = Image.FromStream(ms);

                imagem = IWTFunctions.IWTFunctions.ResizeImage(imagem, 100, 100, false);

                ms = new MemoryStream();
                imagem.Save(ms, ImageFormat.Bmp);
                logoEmpresa = ms.ToArray();
            }


            #endregion

            try
            {
                command = conn.CreateCommand();
                command.Transaction = conn.BeginTransaction();

                if (OCs.Count == 0)
                {
                    throw new Exception("Nenhum item atende aos critérios selecionados.");
                }

                command.CommandText =
                    "CREATE LOCAL TEMP TABLE \"op_exp_select_temp\" ( " +
                    "  \"onu\" VARCHAR(255),  " +
                    "  \"op\" INTEGER, " +
                    "  \"id_cliente\" INTEGER, " +
                    "  \"data_entrega\" DATE, " +
                    "  \"modelo_kit\" VARCHAR(255), " +
                    "  \"id_order_item_etiqueta\" INTEGER "+
                    ") ON COMMIT DROP;";

                //command.CommandText =
                //   "CREATE TABLE \"op_exp_select_temp\" ( " +
                //   "  \"onu\" VARCHAR(255),  " +
                //   "  \"op\" INTEGER, " +
                //   "  \"id_cliente\" INTEGER, " +
                //   "  \"data_entrega\" DATE, " +
                //   "  \"modelo_kit\" VARCHAR(255) " +
                //   ") WITH OIDS;";

                command.ExecuteNonQuery();

                command.CommandText = "INSERT INTO op_exp_select_temp(onu,op,id_cliente, data_entrega,modelo_kit, id_order_item_etiqueta) VALUES ";

                List<int> jaInseridos = new List<int>();


                foreach (KitClass oc in OCs)
                {
                    //if (oc.dataImpressao == null || reimpressao)
                    //{
                    if (!jaInseridos.Contains(oc.IdOrderItemEtiqueta))
                    {
                        command.CommandText += "('" + oc.oc + "'," + oc.pos + "," + oc.idCliente + ",'" + oc.dataEntrega.ToString("yyyy-MM-dd") + "','" + oc.modeloKit + "'," + oc.IdOrderItemEtiqueta + "),";
                        jaInseridos.Add(oc.IdOrderItemEtiqueta);
                    }
                    //}

                }
                if (jaInseridos.Count == 0)
                {
                    throw new Exception("Nenhum item atende aos parâmetros selecionados.");
                }

                command.CommandText = command.CommandText.Remove(command.CommandText.Length - 1);
                command.ExecuteNonQuery();

                command.CommandText =
                    "SELECT order_item_etiqueta.*, " +
                    "       op_exp_select_temp.*, " +
                    "       order_item.*, " +
                    "       local_fabricacao.lof_identificacao, " +
                    "       pei_urgente, " +
                    "       pei_urgente_solicitante, " +
                    "       pei_urgente_data_prometida, " +
                    "       cliente.cli_nome_resumido, " +
                    "       pei_projeto_cliente," +
                    "       pei_data_entrada " +
                    "FROM order_item_etiqueta " +
                    "     JOIN op_exp_select_temp ON order_item_etiqueta.id_order_item_etiqueta = op_exp_select_temp.id_order_item_etiqueta " +
                    "     LEFT OUTER JOIN order_item ON oie_order_number = order_number AND oie_order_pos = order_pos " +
                    "     LEFT OUTER JOIN produto ON order_item_etiqueta.id_produto = produto.id_produto " +
                    "     LEFT OUTER JOIN local_fabricacao ON produto.id_local_fabricacao = local_fabricacao.id_local_fabricacao " +
                    "     LEFT JOIN pedido_item ON pedido_item.id_pedido_item = order_item_etiqueta.id_pedido_item " +
                    "     LEFT JOIN cliente ON pedido_item.id_cliente = cliente.id_cliente " +
                    "ORDER BY CASE " +
                    "           WHEN \"isNumber\"(translate(public.order_item_etiqueta.oie_dimensao,'/*+!@#$%', 'ssssssss')) THEN CAST " +
                    "            (public.order_item_etiqueta.oie_dimensao AS DOUBLE PRECISION) " +
                    "           ELSE 99999999 " +
                    "         END, " +
                    "         public.order_item_etiqueta.oie_order_number, " +
                    "         public.order_item_etiqueta.oie_order_pos; ";

                //Alteração Marcelo na clausula ORDER BY

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                SemKitReportDataSet ds = new SemKitReportDataSet();
                SemKitReportDataSet.relatorioRow row;

                string tempDir = Environment.GetEnvironmentVariable("temp");

                Process process = new Process();
                process.StartInfo.WorkingDirectory = @AppDomain.CurrentDomain.BaseDirectory + "\\barcode\\";
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.StartInfo.FileName = @AppDomain.CurrentDomain.BaseDirectory + "\\barcode\\barcode.exe";
                FileStream fs;
                BinaryReader br;
                Byte[] array;


                while (read.Read())
                {
                    row = ds.relatorio.NewrelatorioRow();
                    row.cliente = read["cli_nome_resumido"].ToString();



                    row.data_entrega = Convert.ToDateTime(read["data_entrega"]);
                    if (read["order_date"] != DBNull.Value)
                    {
                        row.data_pedido = Convert.ToDateTime(read["order_date"]);
                    }
                    else
                    {
                        row.data_pedido = Convert.ToDateTime(read["pei_data_entrada"]);
                    }
                    row.deps = read["oie_deps"].ToString();
                    row.dimensao = read["oie_dimensao"].ToString();
                    row.kit = read["modelo_kit"].ToString();
                    row.kit_resumido = read["oie_kit_fantasia"].ToString();
                    row.oc = read["oie_order_number"].ToString();
                    row.pos = Convert.ToInt32(read["oie_order_pos"]);
                    row.produto_codigo = read["oie_codigo_item"].ToString();
                    row.produto_descricao = read["oie_descricao"].ToString();
                    row.produto_descricao_cliente = read["oie_descricao_cliente"].ToString();
                    string projeto = read["oie_peps"].ToString();
                    if (String.IsNullOrEmpty(projeto))
                    {
                        projeto = read["pei_projeto_cliente"].ToString();
                    }
                    row.projeto = projeto;

                    row.revisao_desenho = read["oie_revisao_desenho"].ToString();
                    row.status = read["oie_status_pedido"].ToString();
                    row.tipo_ligacao = read["oie_tipo_ligacao"].ToString();
                    row.var_1_nome = read["oie_var_1_nome"].ToString();
                    row.var_1_valor = read["oie_var_1_valor"].ToString();
                    row.var_2_nome = read["oie_var_2_nome"].ToString();
                    row.var_2_valor = read["oie_var_2_valor"].ToString();
                    row.ver_oc = read["oie_ver_oc"].ToString();
                    row.tipo_acabamento = read["oie_acabamento_superficial"].ToString();
                    row.acabamento = read["oie_acab_item_pai"].ToString();
                    row.quantidade = Convert.ToDouble(read["oie_saldo_conferencia"]);
                    row.qtdOriginal = Convert.ToDouble(read["oie_quantidade"]);
                    row.logoEmpresa = this.logoEmpresa;
                    //row.modelo = reimpressao;
                    row.fabricante = read["lof_identificacao"].ToString();

                    row.armazenagem = read["oie_armazenagem_cliente"].ToString();
                    row.ovm = read["oie_ovm"].ToString();
                    if (row.ovm == "0")
                    {
                        row.ovm = "";
                    }

                    row.informacoes_especiais = read["oie_informacoes_especiais"].ToString();

                    row.produto_codigo_cliente = read["oie_codigo_cliente"].ToString();

                    string obsUrgente = "";
                    if (read["pei_urgente"] != DBNull.Value)
                    {

                        switch (Convert.ToInt16(read["pei_urgente"]))
                        {
                            case 0:
                                obsUrgente = "";
                                break;
                            case 1:
                                obsUrgente = "Antecipação - ";
                                break;
                            case 2:
                                obsUrgente = "Urgente - ";
                                break;
                            case 3:
                                obsUrgente = "Critico - ";
                                break;
                        }
                        if (read["pei_urgente_data_prometida"] != DBNull.Value)
                        {
                            obsUrgente += read["pei_urgente_solicitante"] + " para " + Convert.ToDateTime(read["pei_urgente_data_prometida"]).ToString("dd/MM/yyyy");
                        }
                    }

                    row.obs_urgente = obsUrgente;
                    string oc = read["oie_order_number"].ToString();

                    oc = oc.Replace(' ', ';');

                    

                    Barcode128 code128 = new Barcode128();
                    code128.CodeType = Barcode.CODE128;
                    code128.ChecksumText = true;
                    code128.GenerateChecksum = true;
                    code128.StartStopText = true;
                    code128.BarHeight = 85;
                    code128.Code = "OIE_" + read["id_order_item_etiqueta"];
                    row.codigo_barras_texto = code128.Code;
                    
                    Bitmap codeBar = new Bitmap(code128.CreateDrawingImage(Color.Black, Color.White));
                    codeBar.Save(@tempDir + "\\code.bmp");

                    ImageConverter converter = new ImageConverter();
                    array = (byte[])converter.ConvertTo(codeBar, typeof(byte[]));

                    row.codigo_barras = array;


                    ds.relatorio.AddrelatorioRow(row);
                }

                read.Close();

                if (!reimpressao)
                {
                    //command.CommandText = "UPDATE order_item_etiqueta SET oie_packinglist_kit_impresso = 1, oie_data_impressao_op=NOW() WHERE oie_packinglist_kit_impresso = 0 AND oie_nota_fiscal=1 AND oie_order_number || oie_order_pos IN ( SELECT onu||op FROM op_exp_select_temp);";
                    //command.ExecuteNonQuery();
                }

                command.Transaction.Commit();

                SemKitReport rep = new SemKitReport();
                rep.SetDataSource(ds);

                //KitReportForm form = new KitReportForm(rep);
                //form.Show();

                //if (printer != null)
                //{
                //  if (ds.relatorio.Rows.Count > 0)
                //  {
                //    rep.PrintOptions.PrinterName = printer; // IWTConfiguration.Conf.getConf(Program.PKL_PRINTER);
                //    rep.PrintToPrinter(1, false, 0, 99999);
                //  }
                //  else
                //  {
                //    throw new Exception("Todos os itens já foram impressos para as opções selecionadas.");
                //  }
                //}
                //else
                //{
                if (ds.relatorio.Rows.Count > 0)
                {
                    KitReportForm form = new KitReportForm(rep);
                    form.ShowDialog();
                }
                else
                {
                    throw new Exception("Todos os itens já foram impressos para as opções selecionadas.");
                }
                //}   
            }
            catch (Exception e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }

                throw new Exception("Erro ao montar o relatório de itens sem kit.\r\n" + e.Message);

            }
        }
    }
}
