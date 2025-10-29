#region Referencias

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Operacoes.Estoque;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;
using ProjectConstants;

using PaperSize = CrystalDecisions.Shared.PaperSize;

#endregion

namespace BibliotecaCadastrosBasicos.Relatórios
{
    public partial class EtiquetaCompraRepetitivaReportForm : IWTBaseForm
    {
        private readonly List<MaterialClass> materiais;
        private readonly List<ProdutoClass> produtos;
        private readonly List<ProdutoKClass> produtosK;
        private readonly List<EpiClass> epis;

        readonly string internalLabelPrinter;
        readonly string internalLabelPaper;
        public bool Abort { get; private set; }

        public EtiquetaCompraRepetitivaReportForm(List<ProdutoKClass> produtosK, List<EpiClass> epis, List<MaterialClass> materiais, List<ProdutoClass> _produtos)
        {
            InitializeComponent();
            this.materiais = materiais;
            this.produtos = _produtos;
            this.produtosK = produtosK;
            this.epis = epis;
                                                                                                        
            this.internalLabelPaper = IWTConfiguration.Conf.getConf(Constants.INTERNAL_LABEL_PAPER);
            this.internalLabelPrinter = IWTConfiguration.Conf.getConf(Constants.INTERNAL_LABEL_PRINTER);

            this.gerarRelatorio();
        }

        private void gerarRelatorio()
        {
            try
            {

                string tipoEtiqueta = "";
                int tipoEtiquetaBarcode = 0;
                if (this.rdbVerde.Checked)
                {
                    tipoEtiqueta = "Verde";
                    tipoEtiquetaBarcode = 1;
                }

                if (this.rdbAmarelo.Checked)
                {
                    tipoEtiqueta = "Amarelo";
                    tipoEtiquetaBarcode = 2;
                }

                if (this.rdbVermelho.Checked)
                {
                    tipoEtiqueta = "Vermelho";
                    tipoEtiquetaBarcode = 3;
                }

                EtiquetaCompraRepetitivaReportDataSet ds = new EtiquetaCompraRepetitivaReportDataSet();
                EtiquetaCompraRepetitivaReportDataSet.etiquetaRow row;

               

                IWTPostgreNpgsqlCommand command = this.SingleConnection.CreateCommand();
                string tempDir = Environment.GetEnvironmentVariable("temp");

                Process process = new Process();
                process.StartInfo.WorkingDirectory = @AppDomain.CurrentDomain.BaseDirectory + "\\barcode\\";
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.StartInfo.FileName = @AppDomain.CurrentDomain.BaseDirectory + "\\barcode\\barcode.exe";

                if (produtosK != null)
                {
                    #region ProdutosKb

                    foreach (ProdutoKClass prodK in this.produtosK)
                    {
                        if (prodK.QtdContainer == 0)
                        {
                            prodK.QtdContainer = 1;
                        }

                        for (int i = 0; i < prodK.QtdContainer; i++)
                        {

                            string unidadeMedidaCompra = "";
                            string unidadesUtilizacaoPorUnidadeCompra = "";
                            string unidadeMedida = "";
                            try
                            {

                                command.CommandText =
                                    "SELECT  " +
                                    "  p.pro_unidades_por_un_compra, " +
                                    "  unid_compra.unm_abreviada unidade_compra, " +
                                    "  unid_m.unm_abreviada unidade_medida " +
                                    "FROM  " +
                                    "  public.produto p LEFT JOIN unidade_medida unid_compra ON (p.id_unidade_medida_compra = unid_compra.id_unidade_medida)" +
                                    "  LEFT JOIN unidade_medida unid_m ON (p.id_unidade_medida = unid_m.id_unidade_medida)" +
                                    "WHERE " +
                                    "  id_produto = :id_produto ";

                                command.Parameters.Clear();

                                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto",
                                                                                            NpgsqlDbType.Integer));
                                command.Parameters[command.Parameters.Count - 1].Value =
                                    prodK.CollectionProdutoKProdutoClassProdutoK[0].Produto.ID;

                                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                                if (!read.HasRows)
                                {
                                    throw new Exception("ID Inválido");
                                }

                                read.Read();

                                unidadeMedida = read["unidade_medida"].ToString();
                                unidadeMedidaCompra = read["unidade_compra"].ToString();
                                unidadesUtilizacaoPorUnidadeCompra = read["pro_unidades_por_un_compra"].ToString();

                                read.Close();

                            }
                            catch (Exception e)
                            {
                                throw new Exception(
                                    "Erro ao carregar os dados do Produto do Agrupador.\r\n" + e.Message, e);
                            }

                            List<EstoqueGavetaClass> gavetas = EstoqueMovimentacao.BuscaTodasGavetasProdutoK(prodK);

                            if (gavetas.Count == 0)
                            {
                                MessageBox.Show(this,
                                                "O produto " + prodK +
                                                " não pode gerar etiquetas de Kanban pois não possui gavetas cadastradas.",
                                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                continue;

                            }

                            foreach (EstoqueGavetaClass gaveta in gavetas)
                            {
                                
                                
                                row = ds.etiqueta.NewetiquetaRow();
                                //row.acabamento = "";
                                //row.descricao = prodK.Codigo;

                                row.numero_etiqueta = "Nº " + (i + 1) + "/" + prodK.QtdContainer;

                                row.estoque_uso_verde = prodK.Verde;
                                row.estoque_uso_amarelo = prodK.Amarelo;
                                row.estoque_uso_vermelho = prodK.Vermelho;
                                row.descricao = prodK.Descricao;
                                row.dimensao = prodK.Dimensao;
                                row.acabamento = prodK.ClassificacaoProduto.ToString();

                                row.manufaturado = true;

                                row.qtd_produzir = prodK.LoteProducao;

                                row.item = prodK.Codigo;

                                row.unidade_uso = unidadeMedida;

                                row.usuario = LoginClass.UsuarioLogado.loggedUser.Login;
                                row.tipo_etiqueta = tipoEtiqueta;

                                row.local_estoque = gaveta.GetLocalizacaoCompleta();

                                process.StartInfo.Arguments = "CRK|" + gaveta.ID + "|" + prodK.ID + "|" + tipoEtiquetaBarcode + " " + tempDir + "\\code.bmp";

                                process.Start();
                                process.WaitForExit();

                                if ((i + 1) == prodK.QtdContainer)
                                {
                                    FileStream fs = new FileStream(@tempDir + "\\code.bmp", FileMode.Open);
                                    BinaryReader br = new BinaryReader(fs);
                                    Byte[] array = br.ReadBytes((int) fs.Length);
                                    br.Close();
                                    fs.Close();

                                    row.codigo_barra = array;
                                }

                                ds.etiqueta.AddetiquetaRow(row);
                            }
                        }

                    }

                    #endregion
                }

                if (epis != null)
                {
                    #region EPIs

                    foreach (EpiClass epi in this.epis)
                    {
                        
                        List<EstoqueGavetaClass> gavetas = EstoqueMovimentacao.BuscaTodasGavetasEpi(epi);

                        if (gavetas.Count == 0)
                        {
                            MessageBox.Show(this,
                                            "O EPI " + epi +
                                            " não pode gerar etiquetas de Kanban pois não possui gavetas cadastradas.",
                                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            continue;

                        }

                        foreach (EstoqueGavetaClass gaveta in gavetas)
                        {
                           
                            row = ds.etiqueta.NewetiquetaRow();
                            //row.acabamento = "";
                            //row.descricao = prodK.Codigo;

                            row.manufaturado = false;
                            row.estoque_compra_verde = epi.Verde/ epi.UnidadesPorUnidadeCompra;
                            row.estoque_uso_verde = epi.Verde;

                            row.estoque_compra_amarelo = epi.Amarelo / epi.UnidadesPorUnidadeCompra;
                            row.estoque_uso_amarelo = epi.Amarelo;

                            row.estoque_compra_vermelho = epi.Vermelho / epi.UnidadesPorUnidadeCompra;
                            row.estoque_uso_vermelho = epi.Vermelho;

                            row.item = epi.Identificacao;

                            row.unidade_compra = epi.UnidadeMedidaCompra + " de " +
                                                 epi.UnidadesPorUnidadeCompra + " " +
                                                 epi.UnidadeMedidaUso;

                            row.unidade_uso = epi.UnidadeMedidaUso.ToString();

                            row.usuario = LoginClass.UsuarioLogado.loggedUser.Login;
                            row.tipo_etiqueta = tipoEtiqueta;

                            row.local_estoque = gaveta.GetLocalizacaoCompleta();

                            process.StartInfo.Arguments = "CREP|" + gaveta.ID + "|" + epi.ID + "|" + tipoEtiquetaBarcode + " " + tempDir + "\\code.bmp";

                            process.Start();
                            process.WaitForExit();

                            FileStream fs = new FileStream(@tempDir + "\\code.bmp", FileMode.Open);
                            BinaryReader br = new BinaryReader(fs);
                            Byte[] array = br.ReadBytes((int)fs.Length);
                            br.Close();
                            fs.Close();

                            row.codigo_barra = array;

                            ds.etiqueta.AddetiquetaRow(row);
                        }
                    }

                    #endregion
                }

                if (materiais != null)
                {
                    #region Materiais

                    foreach (MaterialClass Material in this.materiais)
                    {

                        if (Material.PoliticaEstoque !=PoliticaEstoque.Kanban)
                        {
                            MessageBox.Show(this,
                                            "O Material " + Material +
                                            " não pode gerar etiquetas de Kanban pois não está cadastrado dessa forma.",
                                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            continue;
                        }
                        List<EstoqueGavetaClass> gavetas = EstoqueMovimentacao.BuscaTodasGavetasMaterial(Material, null);

                        if (gavetas.Count == 0)
                        {
                            MessageBox.Show(this,
                                            "O Material " + Material +
                                            " não pode gerar etiquetas de Kanban pois não possui gavetas cadastradas.",
                                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            continue;

                        }

                        foreach (EstoqueGavetaClass gaveta in gavetas)
                        {
                            row = ds.etiqueta.NewetiquetaRow();
                            row.acabamento = Material.Acabamento.ToString();
                            row.descricao = Material.Descricao;



                            row.estoque_compra_verde = Material.Verde / Material.UnidadesPorUnCompra;
                            row.estoque_uso_verde = Material.Verde;


                            row.estoque_compra_amarelo = Material.Amarelo / Material.UnidadesPorUnCompra;
                            row.estoque_uso_amarelo = Material.Amarelo;


                            row.estoque_compra_vermelho = Material.Vermelho / Material.UnidadesPorUnCompra;
                            row.estoque_uso_vermelho = Material.Vermelho;



                            row.item = Material.CodigoComFamilia;
                            row.unidade_compra = Material.UnidadeMedidaCompra + " de " +
                                                 Material.UnidadesPorUnCompra + " " +
                                                 Material.UnidadeMedida;
                            row.unidade_uso = Material.UnidadeMedida.ToString();
                            row.usuario = LoginClass.UsuarioLogado.loggedUser.Login;
                            row.tipo_etiqueta = tipoEtiqueta;

                            row.dimensao = Material.MedidaCompleta;

                            row.local_estoque = gaveta.GetLocalizacaoCompleta();

                            process.StartInfo.Arguments = "CR|" + gaveta.ID + "|" + Material.ID + "|" + tipoEtiquetaBarcode + " " + tempDir +
                                                          "\\code.bmp";

                            process.Start();
                            process.WaitForExit();

                            FileStream fs = new FileStream(@tempDir + "\\code.bmp", FileMode.Open);
                            BinaryReader br = new BinaryReader(fs);
                            Byte[] array = br.ReadBytes((int)fs.Length);
                            br.Close();
                            fs.Close();

                            row.codigo_barra = array;



                            ds.etiqueta.AddetiquetaRow(row);
                        }
                    }

                    #endregion
                }

                if (produtos != null)
                {
                    #region Produtos

                    foreach (ProdutoClass produto in this.produtos)
                    {
                        
                        if (produto.PoliticaEstoque != PoliticaEstoque.Kanban)
                        {
                            MessageBox.Show(this,
                                            "O produto " + produto +
                                            " não pode gerar etiquetas de Kanban pois não está cadastrado dessa forma.",
                                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            continue;
                        }
                        List<EstoqueGavetaClass> gavetas = EstoqueMovimentacao.BuscaTodasGavetasProduto(produto, null);

                        if (gavetas.Count == 0)
                        {
                            MessageBox.Show(this,
                                            "O produto " + produto +
                                            " não pode gerar etiquetas de Kanban pois não possui gavetas cadastradas.",
                                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            continue;

                        }

                        foreach (EstoqueGavetaClass gaveta in gavetas)
                        {
                            row = ds.etiqueta.NewetiquetaRow();
                            if (produto.Acabamento != null)
                            {
                                row.acabamento = produto.Acabamento.ToString();                                
                            }

                            row.descricao = produto.Descricao;


                            row.estoque_compra_verde = produto.Verde / produto.UnidadesPorUnCompra;
                            row.estoque_uso_verde = produto.Verde;



                            row.estoque_compra_amarelo = produto.Amarelo / produto.UnidadesPorUnCompra;
                            row.estoque_uso_amarelo = produto.Amarelo;



                            row.estoque_compra_vermelho = produto.Vermelho / produto.UnidadesPorUnCompra;
                            row.estoque_uso_vermelho = produto.Vermelho;



                            row.item = produto.Codigo;
                            row.unidade_compra = produto.UnidadeMedidaCompra + " de " +
                                                 produto.UnidadesPorUnCompra + " " +
                                                 produto.UnidadeMedida;
                            row.unidade_uso = produto.UnidadeMedida.ToString();
                            row.usuario = LoginClass.UsuarioLogado.loggedUser.ToString();
                            row.tipo_etiqueta = tipoEtiqueta;


                            row.local_estoque = gaveta.GetLocalizacaoCompleta();

                            process.StartInfo.Arguments = "CR2|" + gaveta.ID + "|" + produto.ID + "|" + tipoEtiquetaBarcode + " " + tempDir +
                                                          "\\code.bmp";

                            process.Start();
                            process.WaitForExit();

                            FileStream fs = new FileStream(@tempDir + "\\code.bmp", FileMode.Open);
                            BinaryReader br = new BinaryReader(fs);
                            Byte[] array = br.ReadBytes((int)fs.Length);
                            br.Close();
                            fs.Close();

                            row.codigo_barra = array;



                            ds.etiqueta.AddetiquetaRow(row);
                        }
                    }

                    #endregion
                }
               

                if (ds.Tables[0].Rows.Count <= 0)
                {
                    this.Abort = true;
                    return;
                        
                }

                EtiquetaCompraRepetitivaReport rep = new EtiquetaCompraRepetitivaReport();
                rep.SetDataSource(ds);

                rep.Refresh();

                try
                {
                    int j;
                    Boolean found1 = false;
                    string PaperList = "";
                    int rawKind1 = 0;
                    PrintDocument doctoprint = new PrintDocument();
                    doctoprint.PrinterSettings.PrinterName = internalLabelPrinter;

                    if (!doctoprint.PrinterSettings.IsValid)
                    {
                        string PrinterList = "Você deve selecionar entre uma das impressoras abaixo, coloca-la na configuração e gerar o relatório novamente.\r\n";
                        foreach (string strPrinter in PrinterSettings.InstalledPrinters)
                        {
                            PrinterList += "\r\n" + strPrinter;
                        }
                        MessageBox.Show("Impressora de Etiquetas não encontrada!\r\n\r\n" + PrinterList, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        PrinterSettings.PaperSizeCollection paperSizeCollection = doctoprint.PrinterSettings.PaperSizes;

                        for (j = 0; j < paperSizeCollection.Count; j++)
                        {

                            PaperList += "\r\n" + paperSizeCollection[j].PaperName;
                            if (paperSizeCollection[j].PaperName == internalLabelPaper)
                            {
                                rawKind1 = (int)(paperSizeCollection[j].GetType().GetField("kind", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(paperSizeCollection[j]));
                                found1 = true;
                            }
                        }

                        if (!found1)
                        {
                            MessageBox.Show("Papel da Etiqueta não encontrado!\r\n Você deve selecionar entre os papeis abaixo, coloca-lo na configuração e gerar o relatório novamente.\r\n" + PaperList, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        rep.PrintOptions.PrinterName = doctoprint.PrinterSettings.PrinterName;
                        rep.PrintOptions.PaperSize = (PaperSize)rawKind1;
                    }
                }
                catch (Exception r)
                {
                    MessageBox.Show("Erro ao definir o tipo de papel correto! \r\n" + r, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.crystalReportViewer1.ReportSource = rep;
                

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar o relatório.\r\n" + e.Message, e);
            }
        }

        private void rdbVerde_CheckedChanged(object sender, EventArgs e)
        {
            this.gerarRelatorio();
        }

        private void rdbAmarelo_CheckedChanged(object sender, EventArgs e)
        {
            this.gerarRelatorio();
        }

        private void rdbVermelho_CheckedChanged(object sender, EventArgs e)
        {
            this.gerarRelatorio();
        }


    }
}
