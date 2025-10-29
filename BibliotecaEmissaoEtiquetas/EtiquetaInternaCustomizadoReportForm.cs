#region Referencias

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using CrystalDecisions.CrystalReports.Engine;
using BarcodeLib;
using BibliotecaEntidades.ClassesAuxiliares;
using Configurations;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.qrcode;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using ModuloEtiquetasInternas;
using Npgsql;
using ProjectConstants;
using ZXing;
using ZXing.Common;
using PaperSize = CrystalDecisions.Shared.PaperSize;
using Barcode = BarcodeLib.Barcode;
using EncodeHintType = iTextSharp.text.pdf.qrcode.EncodeHintType;

#endregion

namespace BibliotecaEmissaoEtiquetas
{
    public partial class EtiquetaInternaCustomizadoReportForm : IWTBaseForm
    {
        readonly string semana;
        readonly string oc;
        readonly string pos;
        readonly string codigoItem;
        readonly bool anteriores;

        List<string> etiquetasImpressas;
        private readonly List<OrderItemEtiquetaClass> _etiquetas;
        readonly IWTPostgreNpgsqlConnection _conn;
        AcsUsuarioClass Usuario;

        public EtiquetaInternaCustomizadoReportForm(string semana, bool anteriores, string internalLabelPrinter, string internalLabelPaper,AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            this.semana = semana;
            this.anteriores = anteriores;
            this._conn = conn;
            this.Usuario = usuario;

            this.FillReport(internalLabelPrinter, internalLabelPaper);
        }

        public EtiquetaInternaCustomizadoReportForm(string oc, string pos, string cod, string internalLabelPrinter, string internalLabelPaper, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            this.oc = oc;
            this.pos = pos;
            this.codigoItem = cod;
            this._conn = conn;
            this.Usuario = usuario;

            this.FillReport(internalLabelPrinter, internalLabelPaper);
        }


        public EtiquetaInternaCustomizadoReportForm(List<OrderItemEtiquetaClass> etiquetas, string internalLabelPrinter, string internalLabelPaper, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            _etiquetas = etiquetas;
            this._conn = conn;
            this.Usuario = usuario;

            this.FillReport(internalLabelPrinter, internalLabelPaper);
        }



        private void FillReport(string internalLabelPrinter, string internalLabelPaper)
        {
            this.crystalReportViewer1.ReportSource = null;

            bool etiquetaVertical = IWTConfiguration.Conf.getBoolConf(Constants.ETIQUETA_PRODUTO_VERTICAL);

            string etiquetasTemp = "";

            etiquetasImpressas = new List<string>();
       
            Dictionary<string, string> listOcs = new Dictionary<string, string>();

            EtiquetaInternaDataSet ds = new EtiquetaInternaDataSet();

            IWTPostgreNpgsqlDataReader read;

            IWTPostgreNpgsqlCommand command =this._conn.CreateCommand();
            if (_etiquetas != null)
            {
                if (_etiquetas.Count == 0)
                {
                    throw new ExcecaoTratada("Não foi encontrada nenhum ID para impressão de etiquetas");
                }

                foreach (OrderItemEtiquetaClass etiqueta in _etiquetas)
                {
                    OrderItemEtiquetaClass paiAtual = etiqueta.PedidoItemLinhaPrincipalPedido.CollectionOrderItemEtiquetaClassPedidoItem.First();
                    //OrderItemEtiquetaClass paiAtual = etiqueta;
                    //while (paiAtual.OrderItemEtiquetaPai != null)
                    //{
                    //    paiAtual = paiAtual.OrderItemEtiquetaPai;
                    //}

                    if (!listOcs.ContainsKey(paiAtual.OrderNumber + "_" + paiAtual.OrderPos))
                    {
                        listOcs.Add(paiAtual.OrderNumber + "_" + paiAtual.OrderPos, paiAtual.ID.ToString());
                    }
                }
                
            }
            else
            {

                if (this.oc == null)
                {
                    command.CommandText = "SELECT oie_order_number,oie_order_pos,id_order_item_etiqueta  FROM order_item_etiqueta WHERE oie_nivel_item=0 AND oie_nota_fiscal=1 ORDER BY oie_order_number, oie_order_pos";
                    read = command.ExecuteReader();
                    while (read.Read())
                    {
                        try
                        {
                            listOcs.Add(read["oie_order_number"] + "_" + read["oie_order_pos"], read["id_order_item_etiqueta"].ToString());

                        }
                        catch (ArgumentException a)
                        {
                        }
                    }

                    read.Close();
                }
                else
                {
                    command.CommandText = "SELECT oie_order_number,oie_order_pos,id_order_item_etiqueta FROM order_item_etiqueta WHERE oie_order_number = '" + this.oc + "' AND oie_order_pos=" + this.pos + " AND oie_nivel_item=0 AND oie_nota_fiscal=1 ORDER BY oie_order_number, oie_order_pos";
                    read = command.ExecuteReader();
                    while (read.Read())
                    {
                        try
                        {
                            listOcs.Add(read["oie_order_number"] + "_" + read["oie_order_pos"], read["id_order_item_etiqueta"].ToString());

                        }
                        catch (ArgumentException a)
                        {
                        }
                    }

                    read.Close();
                }
            }



            if (_etiquetas == null)
            {
                if (this.oc == null)
                {
                    if (anteriores)
                    {
                        command.CommandText =
                            "  SELECT * FROM " +
                            "  public.order_item_etiqueta                                                                                     " +
                            "  LEFT OUTER JOIN public.pedido_kit ON (public.order_item_etiqueta.oie_order_number = public.pedido_kit.pek_oc)  " +
                            "  AND (public.order_item_etiqueta.oie_order_pos = public.pedido_kit.pek_pos)                                     " +
                            "  LEFT OUTER JOIN public.kit_tipo_kit ON (public.pedido_kit.pek_tipo_kit = public.kit_tipo_kit.pek_tipo_kit)     " +
                            "  LEFT OUTER JOIN public.cliente ON (public.order_item_etiqueta.id_cliente = public.cliente.id_cliente) " +
                            " WHERE oie_pps <= " + this.semana + " AND oie_tipo_item=1 AND oie_etiqueta_interna=1 AND oie_cnc IS NOT NULL AND oie_coordenada_x IS NOT NULL AND oie_coordenada_y IS NOT NULL AND oie_etiqueta_interna_impressa = 0 " +
                            //" ORDER BY oie_cnc, oie_coordenada_x, oie_coordenada_y, oie_order_number, oie_order_pos,oie_codigo_item, oie_dimensao";
                            "   ORDER BY " +
                            " CASE \"isNumber\"(oie_cnc) WHEN true THEN CAST(oie_cnc AS DOUBLE PRECISION) ELSE 99999999 END, " +
                            " oie_cnc, " +
                            " CASE \"isNumber\"(oie_coordenada_x) WHEN true THEN CAST(oie_coordenada_x AS DOUBLE PRECISION) ELSE 99999999 END,    " +
                            " oie_coordenada_x, " +
                            " CASE \"isNumber\"(oie_coordenada_y) WHEN true THEN CAST(oie_coordenada_y AS DOUBLE PRECISION) ELSE 99999999 END,	 " +
                            " oie_coordenada_y, " +
                            " oie_order_number, " +
                            " oie_order_pos, " +
                            " oie_codigo_item, " +
                            " oie_dimensao; ";
                    }
                    else
                    {
                        command.CommandText =
                            "  SELECT * FROM " +
                            "  public.order_item_etiqueta                                                                                     " +
                            "  LEFT OUTER JOIN public.pedido_kit ON (public.order_item_etiqueta.oie_order_number = public.pedido_kit.pek_oc)  " +
                            "  AND (public.order_item_etiqueta.oie_order_pos = public.pedido_kit.pek_pos)                                     " +
                            "  LEFT OUTER JOIN public.kit_tipo_kit ON (public.pedido_kit.pek_tipo_kit = public.kit_tipo_kit.pek_tipo_kit)     " +
                            "  LEFT OUTER JOIN public.cliente ON (public.order_item_etiqueta.id_cliente = public.cliente.id_cliente) " +
                            " WHERE oie_pps = " + this.semana + " AND oie_tipo_item=1 AND oie_etiqueta_interna=1 AND oie_cnc IS NOT NULL AND oie_coordenada_x IS NOT NULL AND oie_coordenada_y IS NOT NULL AND oie_etiqueta_interna_impressa = 0 " +
                            //" ORDER BY oie_cnc, oie_coordenada_x, oie_coordenada_y, oie_order_number, oie_order_pos,oie_codigo_item, oie_dimensao";
                            "   ORDER BY " +
                            " CASE \"isNumber\"(oie_cnc) WHEN true THEN CAST(oie_cnc AS DOUBLE PRECISION) ELSE 99999999 END, " +
                            " oie_cnc, " +
                            " CASE \"isNumber\"(oie_coordenada_x) WHEN true THEN CAST(oie_coordenada_x AS DOUBLE PRECISION) ELSE 99999999 END,    " +
                            " oie_coordenada_x, " +
                            " CASE \"isNumber\"(oie_coordenada_y) WHEN true THEN CAST(oie_coordenada_y AS DOUBLE PRECISION) ELSE 99999999 END,	 " +
                            " oie_coordenada_y, " +
                            " oie_order_number, " +
                            " oie_order_pos, " +
                            " oie_codigo_item, " +
                            " oie_dimensao; ";
                    }
                }
                else
                {
                    command.CommandText =
                        "  SELECT * FROM " +
                        "  public.order_item_etiqueta                                                                                     " +
                        "  LEFT OUTER JOIN public.pedido_kit ON (public.order_item_etiqueta.oie_order_number = public.pedido_kit.pek_oc)  " +
                        "  AND (public.order_item_etiqueta.oie_order_pos = public.pedido_kit.pek_pos)                                     " +
                        "  LEFT OUTER JOIN public.kit_tipo_kit ON (public.pedido_kit.pek_tipo_kit = public.kit_tipo_kit.pek_tipo_kit)     " +
                        "  LEFT OUTER JOIN public.cliente ON (public.order_item_etiqueta.id_cliente = public.cliente.id_cliente) " +
                        " WHERE oie_order_number = '" + this.oc + "' AND oie_order_pos=" + this.pos + " AND oie_tipo_item=1 AND oie_etiqueta_interna=1 AND oie_cnc IS NOT NULL AND oie_coordenada_x IS NOT NULL AND oie_coordenada_y IS NOT NULL AND oie_etiqueta_interna_impressa = 1 AND oie_codigo_item='" + this.codigoItem + "' " +
                        //" ORDER BY oie_cnc, oie_coordenada_x, oie_coordenada_y, oie_order_number, oie_order_pos,oie_codigo_item, oie_dimensao";
                        "   ORDER BY " +
                        " CASE \"isNumber\"(oie_cnc) WHEN true THEN CAST(oie_cnc AS DOUBLE PRECISION) ELSE 99999999 END, " +
                        " oie_cnc, " +
                        " CASE \"isNumber\"(oie_coordenada_x) WHEN true THEN CAST(oie_coordenada_x AS DOUBLE PRECISION) ELSE 99999999 END,    " +
                        " oie_coordenada_x, " +
                        " CASE \"isNumber\"(oie_coordenada_y) WHEN true THEN CAST(oie_coordenada_y AS DOUBLE PRECISION) ELSE 99999999 END,	 " +
                        " oie_coordenada_y, " +
                        " oie_order_number, " +
                        " oie_order_pos, " +
                        " oie_codigo_item, " +
                        " oie_dimensao; ";
                }
            }
            else
            {
                
                string idOcs = _etiquetas.Aggregate("", (result,item) => result+","+item.ID);
                idOcs = "( " + idOcs.Substring(1) + " )";
                command.CommandText = 
                "  SELECT * FROM " +
                    "  public.order_item_etiqueta                                                                                     " +
                    "  LEFT OUTER JOIN public.pedido_kit ON (public.order_item_etiqueta.oie_order_number = public.pedido_kit.pek_oc)  " +
                    "  AND (public.order_item_etiqueta.oie_order_pos = public.pedido_kit.pek_pos)                                     " +
                    "  LEFT OUTER JOIN public.kit_tipo_kit ON (public.pedido_kit.pek_tipo_kit = public.kit_tipo_kit.pek_tipo_kit)     " +
                    "  LEFT OUTER JOIN public.cliente ON (public.order_item_etiqueta.id_cliente = public.cliente.id_cliente) " +
                    " WHERE order_item_etiqueta.id_order_item_etiqueta IN "+idOcs+" " +
                    "   ORDER BY " +
                    " CASE \"isNumber\"(oie_cnc) WHEN true THEN CAST(oie_cnc AS DOUBLE PRECISION) ELSE 99999999 END, " +
                    " oie_cnc, " +
                    " CASE \"isNumber\"(oie_coordenada_x) WHEN true THEN CAST(oie_coordenada_x AS DOUBLE PRECISION) ELSE 99999999 END,    " +
                    " oie_coordenada_x, " +
                    " CASE \"isNumber\"(oie_coordenada_y) WHEN true THEN CAST(oie_coordenada_y AS DOUBLE PRECISION) ELSE 99999999 END,	 " +
                    " oie_coordenada_y, " +
                    " oie_order_number, " +
                    " oie_order_pos, " +
                    " oie_codigo_item, " +
                    " oie_dimensao; ";

            }

            read = command.ExecuteReader();

            string cncAtual = null;

            while (read.Read())
            {


                //IC|ID_ORDER_NUMBER_ETIQUETA_PAI|COD_DO_ITEM
                if (!listOcs.ContainsKey(read["oie_order_number"] + "_" + read["oie_order_pos"]))
                {
                    MessageBox.Show(this, "O pedido " + read["oie_order_number"] + "/" + read["oie_order_pos"] + " não possui pai cadastrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }

                etiquetasImpressas.Add(read["id_order_item_etiqueta"].ToString());
       
                //-------------- tabela de codigos de barras

                string idCodigoBarras = "";
                double qtdUtilizar = Math.Ceiling(Convert.ToDouble(read["oie_quantidade"]) / Convert.ToDouble(read["oie_qtd_etiquetas"]));

                try
                {

                    


                    //busca se tem
                    IWTPostgreNpgsqlCommand commandBarras =this._conn.CreateCommand();
                    commandBarras.CommandText = "SELECT id_codigo_barra FROM codigo_barra WHERE cob_codigo_item='" + read["oie_codigo_item"] + "' AND cob_dimensao='" + read["oie_dimensao"] + "' AND cob_qtd_por_etiqueta = " + qtdUtilizar.ToString(CultureInfo.InvariantCulture);
                    IWTPostgreNpgsqlDataReader readBarras = commandBarras.ExecuteReader();

                    readBarras.Read();
                    if (readBarras.HasRows)
                    {
                        idCodigoBarras = readBarras["id_codigo_barra"].ToString();
                    }
                    else
                    {
                        readBarras.Close();
                        commandBarras.CommandText = "INSERT INTO codigo_barra (cob_codigo_item, cob_dimensao,cob_qtd_por_etiqueta) VALUES ('" + read["oie_codigo_item"] + "','" + read["oie_dimensao"] + "'," + qtdUtilizar.ToString(CultureInfo.InvariantCulture)+") RETURNING id_codigo_barra;";
                        idCodigoBarras = commandBarras.ExecuteScalar().ToString();

                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show("Erro na geração do código de barras.\r\n" + ee.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



                //idCodigoBarras = idCodigoBarras.PadLeft(6, '0');



                EtiquetaInternaDataSet.EtiquetaInternaCRow row;

                if (cncAtual != read["oie_cnc"].ToString())
                {
                    if (cncAtual != null)
                    {
                        row = ds.EtiquetaInternaC.NewEtiquetaInternaCRow();

                        row.barcode = null;
                        row.qrcode = null;
                        row.codigo_item = "";
                        row.desc_item = "";
                        row.medida_item = "";
                        row.order_number = "- FIM CNC -";
                        row.order_pos = "";
                        row.semana = "";
                        row.cnc = cncAtual;
                        row.coordenada_x = "";
                        row.coordenada_y = "";
                        row.sequencial = "";
                        row.usuario = "";
                        row.cliente = "";

                        ds.EtiquetaInternaC.AddEtiquetaInternaCRow(row);
                    }
                    cncAtual = read["oie_cnc"].ToString();
                }

                string numerosOps = "";
                byte[] logoEmpresa = BuscarLogoEmpresa(etiquetaVertical);
                if (etiquetaVertical)
                {
                    numerosOps = BuscarOps(Convert.ToInt64(read["id_order_item_etiqueta"]), _conn);
                    if (numerosOps.EndsWith("/"))
                    {
                        numerosOps = numerosOps.Substring(0, numerosOps.Length - 1);
                    }
                    
                }
               



                for (int i = 0; i < Convert.ToInt32(read["oie_qtd_etiquetas"]); i++)
                {
                    row = ds.EtiquetaInternaC.NewEtiquetaInternaCRow();

                    //Codigo de Barras
                    string barcodeText;
                 
            
                    barcodeText = "ICN|" + listOcs[read["oie_order_number"] + "_" + read["oie_order_pos"]] + "|" + idCodigoBarras + "|" + (i + 1).ToString();
                    

                
                    row.codigo_item = read["oie_codigo_item"].ToString();
                    row.desc_item = read["oie_descricao"].ToString();
                    row.medida_item = read["oie_dimensao"].ToString();
                    row.order_number = read["oie_order_number"].ToString();
                    row.order_pos = read["oie_order_pos"].ToString();
                    row.semana = read["oie_pps"].ToString();
                    row.cnc = read["oie_cnc"].ToString();
                    row.coordenada_x = read["oie_coordenada_x"].ToString();
                    row.coordenada_y = read["oie_coordenada_y"].ToString();
                    row.sequencial = (i+1).ToString() + "/" + read["oie_qtd_etiquetas"];
                    row.usuario = this.Usuario.Login;
                    row.cliente = read["cli_nome_resumido"].ToString();
                    row.logoEmpresa = logoEmpresa;
                    row.ops = numerosOps;

                    long idOrderItemEtiqueta = Convert.ToInt64(read["id_order_item_etiqueta"]);

                    row.unidade_medida = CustomizacoesClienteFactory.Factory.EtiquetaCustomizadaCarregaUnidadeMedida(idOrderItemEtiqueta, Usuario, _conn);
                    if (CustomizacoesClienteFactory.Factory.EtiquetaCustomizadaExibeQtdEtiqueta(idOrderItemEtiqueta, Usuario, _conn))
                    {
                        row.quantidade_por_etiqueta = qtdUtilizar;
                    }
                    else
                    {
                        row.quantidade_por_etiqueta = -1;
                    }



                    if (row.quantidade_por_etiqueta == -1)
                    {
                        byte[] array = null;

                        using (Barcode barcode = new Barcode())
                        {
                            barcode.Alignment = AlignmentPositions.CENTER;
                            if (etiquetaVertical)
                            {
                                barcode.Height = 300;
                                barcode.Width = 850;
                            }
                            else
                            {
                                barcode.Height = 300;
                                barcode.Width = 850;

                            }

                            barcode.ImageFormat = ImageFormat.Jpeg;

                            using (Bitmap codeBar = new Bitmap(barcode.Encode(TYPE.CODE128, barcodeText)))
                            {
                                codeBar.SetResolution(300, 300);

                                using (MemoryStream ms = new MemoryStream())
                                {
                                    if (etiquetaVertical)
                                    {
                                        codeBar.RotateFlip(RotateFlipType.Rotate90FlipNone);
                                    }

                                    codeBar.Save(ms, ImageFormat.Jpeg);
                                    ms.Seek(0, SeekOrigin.Begin);

                                    using (BinaryReader br = new BinaryReader(ms))
                                    {
                                        array = br.ReadBytes((int)ms.Length);
                                    }
                                }
                            }
                        }


                        row.barcode = array;
                    }
                    else
                    {


                        BarcodeWriter writer = new BarcodeWriter
                        {
                            Format = BarcodeFormat.QR_CODE,
                            Options = new EncodingOptions
                            {
                                Height = 110,
                                Width = 110,
                                Margin = 0,
                                NoPadding = true,
                                PureBarcode = true
                            }
                        };

                        writer.Options.Hints.Add(ZXing.EncodeHintType.CHARACTER_SET, "UTF-8");
                        writer.Options.Hints.Add(ZXing.EncodeHintType.ERROR_CORRECTION, ZXing.QrCode.Internal.ErrorCorrectionLevel.H);

                        using (Bitmap codeBar = writer.Write(barcodeText))
                        {
                            using (MemoryStream ms2 = new MemoryStream())
                            {

                                if (etiquetaVertical)
                                {
                                    codeBar.RotateFlip(RotateFlipType.Rotate90FlipNone);
                                }

                                codeBar.Save(ms2, ImageFormat.Bmp);
                                ms2.Seek(0, SeekOrigin.Begin);

                                using (BinaryReader br = new BinaryReader(ms2))
                                {
                                    row.qrcode = br.ReadBytes((int)ms2.Length);
                                }
                            }
                        }


                        //    Dictionary<EncodeHintType, object> hints = new Dictionary<EncodeHintType, object>();
                        //hints.Add(EncodeHintType.CHARACTER_SET, "UTF-8");
                        //hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);

                        //    BarcodeQRCode qrcode = new BarcodeQRCode(barcodeText, 100, 100, hints);


                        //    using (Bitmap codeBar = qrcode.CreateDrawingImage())
                        //    {
                        //        codeBar.SetResolution(300, 300);
                        //        using (MemoryStream ms2 = new MemoryStream())
                        //        {

                        //            if (etiquetaVertical)
                        //            {
                        //                codeBar.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        //            }

                        //            codeBar.Save(ms2, ImageFormat.Bmp);
                        //            ms2.Seek(0, SeekOrigin.Begin);

                        //            using (BinaryReader br = new BinaryReader(ms2))
                        //            {
                        //                row.barcode = br.ReadBytes((int)ms2.Length);
                        //            }
                        //        }
                        //    }
                        }

                        ds.EtiquetaInternaC.AddEtiquetaInternaCRow(row);

                    etiquetasTemp += barcodeText + Environment.NewLine;
                }
            }

            ReportDocument report;
            report = etiquetaVertical ? (ReportDocument) new EtiquetaInternaCustomizadaVerticarReport() : new EtiquetaInternaCReport();
            

            report.SetDataSource(ds);
            report.Refresh();


            IWTFunctions.IWTFunctions.DefineImpressoraReport(ref report, internalLabelPrinter, internalLabelPaper);


            
            this.crystalReportViewer1.ReportSource = report;
        }

        public static byte[] BuscarLogoEmpresa(bool vertical)
        {
            byte[] tmp = IWTConfiguration.Conf.getBinaryConf(Constants.LOGO_EMPRESA); ;

            if (tmp != null)
            {
                MemoryStream ms = new MemoryStream(tmp);
                Image imagem = Image.FromStream(ms);

                imagem = IWTFunctions.IWTFunctions.ResizeImage(imagem, 100, 100, false);

                ms = new MemoryStream();
                if (vertical)
                {
                    imagem.RotateFlip(RotateFlipType.Rotate270FlipNone);
                }

                imagem.Save(ms, ImageFormat.Bmp);

                tmp = ms.ToArray();
            }

            return tmp;
        }

        private string BuscarOps(long idOrderItemEtiqueta, IWTPostgreNpgsqlConnection conn)
        {
            List<OrdemProducaoClass> ordensProducaoPedido = new OrdemProducaoClass(Usuario, conn).Search(new List<SearchParameterClass>()
            {
                new SearchParameterClass("PedidoIdOrderItemEtiqueta", idOrderItemEtiqueta)
            }).ConvertAll(a => (OrdemProducaoClass) a);

            ordensProducaoPedido = ordensProducaoPedido.Distinct().ToList();
            string toRet = ordensProducaoPedido.Aggregate("", (current, op) => current + (op.ID + "/"));

            return toRet;
        }

        private bool saveImpressas()
        {
            try
            {
                if (this.etiquetasImpressas.Count > 0)
                {
                    IWTPostgreNpgsqlCommand command = this._conn.CreateCommand();
                    command.CommandText = "UPDATE order_item_etiqueta SET oie_etiqueta_interna_impressa=1 WHERE ";

                    foreach (string id in this.etiquetasImpressas)
                    {
                        command.CommandText += " id_order_item_etiqueta=" + id + " OR ";
                    }

                    command.CommandText = command.CommandText.Substring(0, command.CommandText.Length - 3);

                    command.ExecuteNonQuery();

       
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(this, "Erro ao definir etiquetas como impressas.\r\n" + e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }


        #region Eventos
        private void EtiquetaInternaCustomizadoReportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(this, "A impressão das etiquetas foi concluida com sucesso?", "Impressão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Salva impressas
                if (!this.saveImpressas())
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }

        }
        #endregion




    }
}
