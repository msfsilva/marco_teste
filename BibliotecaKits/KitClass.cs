#region Referencias

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using IWTPostgreNpgsql;
using Npgsql;

#endregion

namespace ModuloKits
{
    public class KitClass
    {

        public bool Imprimir { get; set; }
        public int IdOrderItemEtiqueta { private set; get; }
        public string oc { private set; get; }
        public string pos { private set; get; }
        public string idModelo { private set; get; }
        public string modeloKit { private set; get; }
        public DateTime dataEntrega { private set; get; }
        public string situacao { private set; get; }
        public string pallet { private set; get; }
        public string embarque { private set; get; }
        public string item { private set; get; }
        public DateTime? dataImpressao { private set; get; }
        public string urgente { private set; get; }
        public string cliente { private set; get; }
        public string itemCliente { private set; get; }
        public string idCliente { private set; get; }
        public DateTime dataEntrada { private set; get; }
        public DateTime? urgetenteDataPrometida { private set; get; }
        public string classificacao { private set; get; }


        public string Projeto { private set; get; }


        public KitClass(int idOrderItemEtiqueta, string oc, string pos, string idModelo, string modeloKit, DateTime dataEntrega, string situacao,
                        string pallet, string embarque, string item, DateTime? dataImpressao, string urgente,
                        DateTime? urgetenteDataPrometida, string cliente, string itemCliente, string idCliente,
                        DateTime dataEntrada, string classificacao, string projeto)
        {
            this.IdOrderItemEtiqueta = idOrderItemEtiqueta;
            this.oc = oc;
            this.pos = pos;
            this.idModelo = idModelo;
            this.modeloKit = modeloKit;
            this.dataEntrega = dataEntrega;
            this.situacao = situacao;
            this.pallet = pallet;
            this.embarque = embarque;
            this.item = item;
            this.dataImpressao = dataImpressao;
            this.urgente = urgente;
            this.urgetenteDataPrometida = urgetenteDataPrometida;
            this.cliente = cliente;
            this.itemCliente = itemCliente;
            this.idCliente = idCliente;
            this.dataEntrada = dataEntrada;
            this.classificacao = classificacao;
            Projeto = projeto;
        }
    }

    public class KitClassComparer : IComparer<KitClass>
    {
        #region IComparer Members

        public int Compare(KitClass a, KitClass b)
        {
            int cmp = a.dataEntrega.CompareTo(b.dataEntrega);
            if (cmp != 0) return cmp;
            cmp = string.Compare(a.Projeto ?? "", b.Projeto ?? "", StringComparison.Ordinal);
            if (cmp != 0) return cmp;
            cmp = string.Compare(a.modeloKit ?? "", b.modeloKit ?? "", StringComparison.Ordinal);
            if (cmp != 0) return cmp;
            cmp = string.Compare(a.oc ?? "", b.oc ?? "", StringComparison.Ordinal);
            if (cmp != 0) return cmp;
            return string.Compare(a.pos ?? "", b.pos ?? "", StringComparison.Ordinal);
        }



        #endregion
    }



    public class KitReportClass
    {
        
        private readonly byte[] logoEmpresa;

        public KitReportClass(List<KitClass> listOcs, byte[] logo, string printer, bool modelo,
                              IWTPostgreNpgsqlConnection conn)
        {
            string tempDir = Environment.GetEnvironmentVariable("temp");

            Byte[] imagemPK = null;
            Int16 indice = 0;
            KitReportDataSet ds = new KitReportDataSet();
            KitReportDataSet dsLista = new KitReportDataSet();
            IWTPostgreNpgsqlCommand command = conn.CreateCommand();
            IWTPostgreNpgsqlDataReader read;
            KitReportDataSet.headerRow headRow;
            KitReportDataSet.detailRow detRow;
            KitReportDataSet.sub_acessoriosRow subRow;

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



            if (listOcs.Count > 0)
            {
                command.Transaction = conn.BeginTransaction();
            }

            foreach (KitClass obj in listOcs)
            {
                bool impAcessorios = false;
                bool impDimensoes = false;
                bool impInformacoesEspeciais = false;
                bool impVariaveis = false;
                bool impLabelComprimento = false;
                bool impVariaveisKit = false;
                bool somenteLista = false;


                try
                {
                    //Busca o tipo
                    command.CommandText = "SELECT * FROM tipo_kit WHERE id_tipo_kit=" + obj.idModelo;
                    read = command.ExecuteReader();
                    if (!read.HasRows)
                    {
                        throw new Exception("Modelo de item inválido, entre em contato com a equipe IWT.");
                    }
                    read.Read();

                    impAcessorios = Convert.ToBoolean(Convert.ToInt16(read["tik_imp_acessorios"]));
                    impDimensoes = Convert.ToBoolean(Convert.ToInt16(read["tik_imp_dimensoes"]));
                    impInformacoesEspeciais = Convert.ToBoolean(Convert.ToInt16(read["tik_imp_saf"]));
                    impVariaveis = Convert.ToBoolean(Convert.ToInt16(read["tik_imp_variaveis"]));
                    impLabelComprimento = Convert.ToBoolean(Convert.ToInt16(read["tik_imp_label_comprimento"]));
                    impVariaveisKit = Convert.ToBoolean(Convert.ToInt16(read["tik_imprime_variaveis_kit"]));
                    somenteLista = Convert.ToBoolean(Convert.ToInt16(read["tik_somente_lista"]));

                    if (read["tik_etiqueta"] != DBNull.Value)
                    {
                        imagemPK = (Byte[]) read["tik_etiqueta"];
                    }

                    read.Close();
                    //Cabeçalho / Etiqueta / BarCode / pps 
                    command.CommandText =
                        "SELECT oie_informacoes_especiais, " +
                        "       oie_order_number, " +
                        "       oie_order_pos, " +
                        "       oie_ovm, " +
                        "       oie_codigo_cliente, " +
                        "       oie_pps, " +
                        "       oie_dimensao, " +
                        "       oie_status_pedido, " +
                        "       oie_packinglist_kit_impresso, " +
                        "       p.pei_projeto_cliente," +
                        "       o.oie_var_1_nome, " +
                        "       o.oie_var_1_valor, " +
                        "       o.oie_var_2_nome, " +
                        "       o.oie_var_2_valor, " +
                        "       o.oie_var_3_nome, " +
                        "       o.oie_var_3_valor, " +
                        "       o.oie_var_4_nome, " +
                        "       o.oie_var_4_valor, " +
                        "       o.id_order_item_etiqueta " +
                        "FROM order_item_etiqueta o  " +
                        "LEFT JOIN pedido_item p ON p.id_pedido_item = o.id_pedido_item " +
                        "WHERE  " +
                        "        id_order_item_etiqueta = " + obj.IdOrderItemEtiqueta;
                    //"      (oie_order_number = '" + obj.oc + "' AND " +
                    //"      oie_order_pos = " + obj.pos + ") AND " +
                    //"      p.id_cliente = " + obj.idCliente + " AND " +
                    //"      oie_nivel_item = 0 AND " +
                    //"      oie_nota_fiscal = 1; ";

                    read = command.ExecuteReader();
                    if (!read.HasRows)
                    {
                        continue;
                    }
                    read.Read();

                    if (!modelo)
                    {
                        if (read["oie_packinglist_kit_impresso"].ToString() == "1")
                        {
                            if (listOcs.Count == 1)
                            {
                                throw new Exception("O Packing List do Kit da OC/Pos: " + obj.oc + "/" + obj.pos +
                                                    " já foi impresso.");
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }




                    if (!somenteLista)
                    {
                        headRow = ds.header.NewheaderRow();
                    }
                    else
                    {
                        headRow = dsLista.header.NewheaderRow();
                    }

                    headRow.id = indice;

                    if (modelo)
                    {
                        headRow.modelo = "NÃO UTILIZAR P/ EMBALAR KIT";
                    }
                    else
                    {
                        headRow.modelo = "";
                    }

                    if (impLabelComprimento)
                    {
                        headRow.label_comprimento = "Comprimento do CJ Montado";
                    }
                    else
                    {
                        headRow.label_comprimento = "";
                    }


                    if (impInformacoesEspeciais)
                    {
                        headRow.informacoesEspeciais = read["oie_informacoes_especiais"].ToString();
                    }

                    headRow.oc = read["oie_order_number"].ToString();
                    headRow.pos = read["oie_order_pos"].ToString();


                    string projeto = read["oie_ovm"].ToString();
                    if (String.IsNullOrEmpty(projeto))
                    {
                        projeto = read["pei_projeto_cliente"].ToString();
                    }

                    headRow.projeto = projeto;

                    if (impDimensoes)
                    {
                        if (read["oie_dimensao"].ToString().Trim().Length > 0 && read["oie_dimensao"].ToString() != "0")
                        {
                            headRow.dimensao = read["oie_dimensao"].ToString();
                        }
                        else
                        {
                            headRow.dimensao = "";
                        }

                    }
                    headRow.nome_kit = obj.modeloKit;
                    headRow.cod_item = read["oie_codigo_cliente"].ToString();
                    headRow.status_pedido = read["oie_status_pedido"].ToString();
                    headRow.data_entrega = obj.dataEntrega.ToString("dd/MM/yyyy");
                    headRow.data_pedido = obj.dataEntrada;

                    headRow.pps = read["oie_pps"].ToString();


                    headRow.imprimir_todas_variaveis = impVariaveisKit;
                    headRow.hvar_1 = read["oie_var_1_nome"] + ": " + read["oie_var_1_valor"];
                    headRow.hvar_2 = read["oie_var_2_nome"] + ": " + read["oie_var_2_valor"];
                    headRow.hvar_3 = read["oie_var_3_nome"] + ": " + read["oie_var_3_valor"];
                    headRow.hvar_4 = read["oie_var_4_nome"] + ": " + read["oie_var_4_valor"];


                    headRow.etiqueta = imagemPK;

                    headRow.logoEmpresa = this.logoEmpresa;

                    Process process = new Process();
                    process.StartInfo.WorkingDirectory = @AppDomain.CurrentDomain.BaseDirectory + "\\barcode\\";
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    process.StartInfo.FileName = @AppDomain.CurrentDomain.BaseDirectory + "\\barcode\\barcode.exe";

                    string oc = read["oie_order_number"].ToString();
                    oc = oc.Replace(' ', ';');

                    process.StartInfo.Arguments = "OIE_" + obj.IdOrderItemEtiqueta + " " + tempDir + "\\code.bmp";
                    process.Start();
                    process.WaitForExit();

                    FileStream fs = new FileStream(@tempDir + "\\code.bmp", FileMode.Open);
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] array = br.ReadBytes((int) fs.Length);
                    br.Close();
                    fs.Close();

                    headRow.bar_code = array;

                    if (!somenteLista)
                    {
                        ds.header.AddheaderRow(headRow);
                    }
                    else
                    {
                        dsLista.header.AddheaderRow(headRow);
                    }


                    read.Close();
                }
                catch (Exception a)
                {
                    if (command != null && command.Transaction != null)
                    {
                        command.Transaction.Rollback();
                    }
                    throw new Exception("Erro ao buscar dados do Pai. \r\n" + a.Message);
                }

                if (!somenteLista)
                {
                    try
                    {
                        //Filhos
                        /*command.CommandText = "SELECT oie_quantidade, oie_codigo_cliente, oie_descricao, oie_tipo_item, oie_codigo_item, oie_dimensao,oie_var_1_nome, oie_var_2_nome, oie_var_3_nome, oie_var_4_nome, oie_var_1_valor, oie_var_2_valor, oie_var_3_valor, oie_var_4_valor,oie_qtd_etiquetas " +
                                              " FROM  order_item_etiqueta  " +
                                              " WHERE (oie_order_number = '" + obj.oc + "' AND oie_order_pos = " + obj.pos + ") AND oie_etiqueta_interna = 1 " +
                                              "ORDER BY oie_codigo_cliente,oie_descricao,oie_codigo_item DESC";
                        */


                        command.CommandText =
                            "SELECT * FROM ( " +
                            "SELECT oie_quantidade, oie_codigo_cliente, oie_descricao, oie_tipo_item, oie_codigo_item, " +
                            " oie_dimensao,oie_var_1_nome, oie_var_2_nome, oie_var_3_nome, oie_var_4_nome, oie_var_1_valor,  " +
                            " oie_var_2_valor, oie_var_3_valor, oie_var_4_valor,oie_qtd_etiquetas  " +
                            "FROM  order_item_etiqueta " +
                            "WHERE (oie_order_number = '" + obj.oc + "' AND oie_order_pos = " + obj.pos + " AND id_cliente = " + obj.idCliente +
                            ") AND oie_etiqueta_interna = 1 AND oie_tipo_item = 1 " +
                            "UNION ALL " +
                            "SELECT SUM(oie_quantidade), oie_codigo_cliente, oie_descricao, oie_tipo_item, oie_codigo_item, " +
                            " oie_dimensao,oie_var_1_nome, oie_var_2_nome, oie_var_3_nome, oie_var_4_nome, oie_var_1_valor,  " +
                            " oie_var_2_valor, oie_var_3_valor, oie_var_4_valor, SUM(oie_qtd_etiquetas)  " +
                            "FROM  order_item_etiqueta " +
                            "WHERE (oie_order_number = '" + obj.oc + "' AND oie_order_pos = " + obj.pos + " AND id_cliente = " + obj.idCliente +
                            ") AND oie_etiqueta_interna = 1 AND oie_tipo_item = 0 " +
                            "GROUP BY " +
                            "oie_codigo_cliente, oie_descricao, oie_tipo_item, oie_codigo_item, " +
                            " oie_dimensao,oie_var_1_nome, oie_var_2_nome, oie_var_3_nome, oie_var_4_nome, oie_var_1_valor,  " +
                            " oie_var_2_valor, oie_var_3_valor, oie_var_4_valor " +
                            ") as tab " +
                            "ORDER BY oie_codigo_cliente, " +
                            "CASE WHEN \"isNumber\"(translate(oie_dimensao,'/*+!@#$%', 'ssssssss')) is true THEN  CAST (oie_dimensao as DOUBLE PRECISION) ELSE 99999999 END DESC, " +
                            "oie_dimensao DESC," +
                            "oie_codigo_item DESC," +
                            " oie_descricao ";

                        read = command.ExecuteReader();
                        while (read.Read())
                        {
                            detRow = ds.detail.NewdetailRow();

                            //Tratamento especial rubber packing

                            //switch (read["oie_codigo_cliente"].ToString())
                            //{
                            //    case "51914256":
                            //        qtdItem = read["oie_qtd_etiquetas"].ToString();
                            //        dimensao = (Convert.ToDouble(read["oie_dimensao"]) * 2).ToString("F0", CultureInfo.CurrentCulture);
                            //        break;

                            //    case "51914260":
                            //        qtdItem = read["oie_qtd_etiquetas"].ToString();
                            //        dimensao = read["oie_dimensao"].ToString();
                            //        break;

                            //    default:
                            //        qtdItem = read["oie_quantidade"].ToString();
                            //        dimensao = read["oie_dimensao"].ToString();
                            //        break;
                            //}

                            string qtdItem = read["oie_quantidade"].ToString();
                            string dimensao = read["oie_dimensao"].ToString();


                            detRow.id = indice;
                            detRow.qtd = qtdItem;
                            detRow.cod_item = read["oie_codigo_cliente"].ToString();
                            detRow.descricao = read["oie_descricao"].ToString();
                            if (read["oie_tipo_item"].ToString() == "0") // kanban
                            {
                                detRow.tipo = "kanban";
                                detRow.cod_kanban = read["oie_codigo_item"].ToString();
                            }
                            else
                            {
                                detRow.tipo = "";
                                detRow.cod_kanban = "";
                            }

                            if (impDimensoes)
                            {
                                if (dimensao.Trim().Length > 0 && dimensao != "0")
                                {
                                    detRow.dimensao = dimensao;
                                }
                                else
                                {
                                    detRow.dimensao = "";
                                }
                            }

                            if (impVariaveis)
                            {
                                if (read["oie_var_1_nome"].ToString() != "")
                                {
                                    detRow.var_1 = read["oie_var_1_nome"] + ":" + read["oie_var_1_valor"];
                                }

                                if (read["oie_var_2_nome"].ToString() != "")
                                {
                                    detRow.var_2 = read["oie_var_2_nome"] + ":" + read["oie_var_2_valor"];
                                }

                                if (read["oie_var_3_nome"].ToString() != "")
                                {
                                    detRow.var_3 = read["oie_var_3_nome"] + ":" + read["oie_var_3_valor"];
                                }

                                if (read["oie_var_4_nome"].ToString() != "")
                                {
                                    detRow.var_4 = read["oie_var_4_nome"] + ":" + read["oie_var_4_valor"];
                                }
                            }

                            detRow.imprime_dimensoes = impDimensoes;
                            detRow.imprime_variaveis = impVariaveis;

                            ds.detail.AdddetailRow(detRow);
                        }
                        read.Close();
                    }
                    catch (Exception b)
                    {
                        if (command != null && command.Transaction != null)
                        {
                            command.Transaction.Rollback();
                        }
                        throw new Exception("Erro ao buscar dados dos Filhos. \r\n" + b.Message);
                    }



                    if (impAcessorios)
                    {
                        try
                        {
                            //Sub Acessorios
                            command.CommandText = "SELECT oie_codigo_item " +
                                                  " FROM order_item_etiqueta " +
                                                  " WHERE (oie_order_number = '" + obj.oc + "' AND oie_order_pos = " +
                                                  obj.pos + " AND id_cliente = " + obj.idCliente + ") AND oie_nivel_item = 0 AND oie_nota_fiscal <> 1";
                            read = command.ExecuteReader();
                            while (read.Read())
                            {
                                subRow = ds.sub_acessorios.Newsub_acessoriosRow();

                                subRow.id = indice;
                                subRow.descricao_acessorio = read["oie_codigo_item"].ToString();

                                ds.sub_acessorios.Addsub_acessoriosRow(subRow);
                            }
                            read.Close();

                        }
                        catch (Exception c)
                        {
                            if (command != null && command.Transaction != null)
                            {
                                command.Transaction.Rollback();
                            }
                            throw new Exception("Erro ao buscar dados dos Acessórios. \r\n" + c.Message);
                        }

                    }

                }

                if (!modelo)
                {
                    try
                    {
                        command.CommandText =
                            "UPDATE order_item_etiqueta SET oie_packinglist_kit_impresso = 1, oie_data_impressao_op=NOW() WHERE oie_order_number = '" +
                            obj.oc + "' AND oie_order_pos = " + obj.pos + " AND id_cliente = " + obj.idCliente;
                        command.ExecuteNonQuery();
                    }
                    catch (Exception d)
                    {
                        if (command != null && command.Transaction != null)
                        {
                            command.Transaction.Rollback();
                        }
                        throw new Exception("Erro ao atualizar flag de impressão. \r\n" + d.Message);
                    }
                }
                indice++;
            }

            command.Transaction.Commit();

            //PrintReport

            if (ds.header.Count > 0)
            {
                KitReport rep = new KitReport();
                rep.SetDataSource(ds);



                if (printer != null)
                {
                    if (ds.header.Rows.Count > 0)
                    {
                        rep.PrintOptions.PrinterName = printer; // IWTConfiguration.Conf.getConf(Program.PKL_PRINTER);
                        rep.PrintToPrinter(1, false, 0, 99999);
                    }
                    else
                    {
                        throw new Exception("Todos os kits já foram impressos para as opções selecionadas.");
                    }

                }
                else
                {
                    KitReportForm form = new KitReportForm(rep);
                    form.ShowDialog();
                }

            }

            if (dsLista.header.Count > 0)
            {
                KitSoListaReport rep = new KitSoListaReport();
                rep.SetDataSource(dsLista);



                if (printer != null)
                {
                    if (ds.header.Rows.Count > 0)
                    {
                        rep.PrintOptions.PrinterName = printer; // IWTConfiguration.Conf.getConf(Program.PKL_PRINTER);
                        rep.PrintToPrinter(1, false, 0, 99999);
                    }
                    else
                    {
                        throw new Exception("Todos os kits já foram impressos para as opções selecionadas.");
                    }

                }
                else
                {
                    KitReportForm form = new KitReportForm(rep);
                    form.ShowDialog();
                }

            }
        }
    }
}
