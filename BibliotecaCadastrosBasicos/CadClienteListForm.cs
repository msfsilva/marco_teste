using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;
using BibliotecaCadastrosBasicos.ClassesAuxiliares;
using BibliotecaCadastrosBasicos.Relatórios;
using BibliotecaCadastrosBasicos.TelasAuxiliares;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Relatorios;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using ProjectConstants;
using PaperSize = CrystalDecisions.Shared.PaperSize;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadClienteListForm : IWTListForm
    {
        private TipoForm Tipo;

        public CadClienteListForm(TipoForm tipo)
        {
            InitializeComponent();
            this.Tipo = tipo;
        }

        public override Type getTipoEntidade()
        {
            return typeof(ClienteClass);

        }

        protected override void chamadaForm(AbstractEntity entidade)
        {
            try
            {
                CadClienteForm form = new CadClienteForm((ClienteClass)entidade, this);
                form.VerificaUtilizacao = this.Tipo != TipoForm.Gerencial;
                form.ShowDialog();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override IWTDataGridView getDataGrid()
        {
            return this.iwtDataGridView1;
        }

        public override AcsUsuarioClass getUsuarioAtual()
        {
            return LoginClass.UsuarioLogado.loggedUser;
        }

        public override List<SearchParameterClass> getParametrosBuscaIniciais()
        {
            return new List<SearchParameterClass>() { new SearchParameterClass("cli_nome_resumido", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String) };
        }


        private void EtiquetaEnderecos()
        {
            try
            {
                if (this.getDataGrid().SelectedRows.Count == 0)
                {
                    throw new ExcecaoTratada("Selecione ao menos um cliente para a geração da etiqueta de endereçamento.");
                }

                DialogResult res = MessageBox.Show(this, "Deseja gerar uma etiqueta de remetente para cada etiqueta de cliente gerada?", "Etiqueta de remetente", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (res == DialogResult.Cancel) return;

                bool gerarRemetente = res == DialogResult.Yes;

                List<ClienteClass> clientes = new List<ClienteClass>();

                foreach (IWTDataGridViewRow row in this.getDataGrid().SelectedRows)
                {
                    clientes.Add((ClienteClass) row.DataBoundItem);
                }

                  List<EtiquetaEnderecamentoReportClass> etiquetas = EtiquetaEnderecamentoReportClass.GerarEtiquetas(clientes, gerarRemetente, this.SingleConnection);

                bool gerado = false;
                if (IWTConfiguration.Conf.getBoolConf(Constants.ETIQUETA_CLIENTE_ZEBRA))
                {

                    EtiquetaEnderecamentoReport rep = new EtiquetaEnderecamentoReport();
                    rep.SetDataSource(etiquetas);


                    try
                    {
                        int j;
                        Boolean found1 = false;
                        string PaperList = "";
                        int rawKind1 = 0;
                        PrintDocument doctoprint = new PrintDocument();
                        doctoprint.PrinterSettings.PrinterName = IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_ZEBRA_IMPRESSORA);

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
                                if (paperSizeCollection[j].PaperName == IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_ZEBRA_PAPEL))
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

                    ViewReportPadraoForm form = new ViewReportPadraoForm("Etiquetas de Endereçamento", rep);
                    form.Show(this);

                    gerado = true;
                }


                if (IWTConfiguration.Conf.getBoolConf(Constants.ETIQUETA_CLIENTE_LASER))
                {
                    ImprimirEtiquetasClienteBmp(etiquetas);
                    gerado = true;
                }

                if (!gerado)
                {
                    throw new ExcecaoTratada("Configure no módulo de administração de sistema o tipo de impressão a ser utilizada para a etiqueta de cliente");
                }

            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao gerar as etiquetas de endereçamento.\r\n" + e.Message, e);
            }
        }


        #region EtiquetasClienteBM

        

        List<Bitmap> imagens;
        private int pagAtual = 0;
        private void ImprimirEtiquetasClienteBmp(List<EtiquetaEnderecamentoReportClass> etiquetas)
        {
            try
            {
                int etiquetaColunas = (int)(IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_ETIQUETA_COLUNAS) != null ? decimal.Parse(IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_ETIQUETA_COLUNAS), CultureInfo.InvariantCulture) : 1);
                int etiquetaLinhas = (int)(IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_ETIQUETA_LINHAS) != null ? decimal.Parse(IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_ETIQUETA_LINHAS), CultureInfo.InvariantCulture) : 1);

                TelaPosicaoInicialImpressaoEtiqueta form = new TelaPosicaoInicialImpressaoEtiqueta(etiquetaColunas, etiquetaLinhas);
                form.ShowDialog(this);

                imagens = EtiquetaEnderecamentoReportClass.GerarEtiquetasBmp(etiquetas, form.Linha, form.Coluna);


                PrintDocument doc = new PrintDocument();
                doc.PrintPage += this.pd_PrintPage;
                doc.OriginAtMargins = false;

                PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();


                printPreviewDialog1.Document = doc;


                PrintDialog printDialog1 = new PrintDialog();
                printDialog1.Document = doc;

                printPreviewDialog1.SetBounds(0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    doc.PrinterSettings = printDialog1.PrinterSettings;
                    printPreviewDialog1.ShowDialog(this);
                }




            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao imprimir as etiquetas dos lotes\r\n" + e.Message, e);
            }
        }

        void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(imagens[pagAtual], 0, 0);
            pagAtual++;
            if (pagAtual < imagens.Count)
            {
                e.HasMorePages = true;
            }
            else
            {
                pagAtual = 0;
            }
        }

        #endregion

        private void ImprimirListagemClientes()
        {
            try
            {
                List<ClienteFornecedorReportClass> ds = ClienteFornecedorReportClass.getClientes(LoginClass.UsuarioLogado.loggedUser, SingleConnection);
                ClientesReport rep = new ClientesReport();
                rep.SetDataSource(ds);
                ViewReportPadraoForm form = new ViewReportPadraoForm("Listagem de Clientes",rep);
                form.Show(this);
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao gerar a listagem de clientes para impressão.\r\n" + e.Message, e);
            }
        }


        #region Eventos
        private void btnEtiquetaEnderecos_Click(object sender, EventArgs e)
        {
            try
            {
                this.EtiquetaEnderecos();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void btnImprirmirRelatorioClientes_Click(object sender, EventArgs e)
        {
            try
            {
                this.ImprimirListagemClientes();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

   
    }
}
