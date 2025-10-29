#region Referencias

using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Globalization;
using System.Media;
using System.Reflection;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Operacoes.OrdemProducao;

using IWTDotNetLib.ComplexLoginModule;
using CrystalDecisions.CrystalReports.Engine;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTFunctions;
using IWTPostgreNpgsql;
using Npgsql;
using PaperSize = CrystalDecisions.Shared.PaperSize;

#endregion

namespace BibliotecaExpedicao
{
    

    public partial class ConferenciaPedidosForm : IWTBaseForm
    {

        protected ConferenciaDefaultClass ocEmConferencia = null;
        protected PalletConferencia palletEmConferencia = null;
        protected const string AREA_NAME = "MODULO_CONFERENCIA";
        protected int tempoConferenciaRestante;

        protected IWTPostgreNpgsqlConnection conn;
        protected AcsUsuarioClass Usuario;
        protected string tipoCalculoSemana;
        protected string diaCalculoSemana;
        protected int segundosLimteConferencia;
        protected string impressoraEtiquetaExpedicao;
        protected string etiquetaExpedicao;
        

        protected string internalLabelPrinter;
        protected string internalLaberPaper;

        readonly protected string Fornecedor;
        readonly protected byte[] fornecedorLogo;

        private readonly bool UtilizarEstoqueOP;

        protected TipoEtiquetaExpedicao TipoEtiqueta;
        IOrdemProducaoFactory iOrdemProducaoFactory;

        protected IConferenciaFactory FactoryConferencia;

        private static string _arquivoLogEmbalagem = AppDomain.CurrentDomain.BaseDirectory + "\\LogEmbalagem-"+DateTime.Now.ToString("yyyy-MM-dd")+".txt";


        public ConferenciaPedidosForm(
            string impressoraEtiquetaExpedicao, string etiquetaExpedicao,
            string internalLabelPrinter, string internalLaberPaper, 
            int segundosLimteConferencia, string tipoCalculoSemana, string diaCalculoSemana, string Fornecedor, byte[] fornecedorLogo,  AcsUsuarioClass Usuario, IWTPostgreNpgsqlConnection conn, bool UtilizarEstoqueOP,
            TipoEtiquetaExpedicao tipoEtiqueta, IOrdemProducaoFactory iOrdemProducaoFactory, IConferenciaFactory factoryConferencia = null)
        {
            InitializeComponent();

            this.conn = conn;
            this.Usuario = Usuario;
            this.tipoCalculoSemana = tipoCalculoSemana;
            this.diaCalculoSemana = diaCalculoSemana;
            this.segundosLimteConferencia = segundosLimteConferencia;

            this.UtilizarEstoqueOP = UtilizarEstoqueOP;

            this.etiquetaExpedicao = etiquetaExpedicao;
            this.impressoraEtiquetaExpedicao = impressoraEtiquetaExpedicao;


            this.WindowState = FormWindowState.Maximized;
            this.lblUsuario.Text = this.Usuario.Login;
            this.Text = this.Usuario.Login + " - " + this.Text;

            this.internalLabelPrinter = internalLabelPrinter;
            this.internalLaberPaper = internalLaberPaper;

            this.Fornecedor = Fornecedor;
            this.fornecedorLogo = fornecedorLogo;


            this.TipoEtiqueta = tipoEtiqueta;
            this.iOrdemProducaoFactory = iOrdemProducaoFactory;
            

            if (factoryConferencia == null)
            {
                FactoryConferencia = new EASIConferenciaFactory();
            }
            else
            {
                this.FactoryConferencia = factoryConferencia;
            }

            this.loadPallet();

          
        }


        #region Metodos Padrão - Operação da Tela
        private void ResetForm()
        {
            if (ocEmConferencia != null)
            {
                ocEmConferencia.Dispose();
            }

            this.timerConferencia.Enabled = false;
            this.timerCaixa.Enabled = false;
            this.timerItem.Enabled = false;
            this.grbCaixa.Enabled = true;
            this.grbItem.Enabled = false;
            this.grbModoOperacao.Enabled = true;
            this.btnSalvar.Enabled = false;
            this.ocEmConferencia = null;
            this.txtBarcodeCaixa.Text = "";
            this.txtBarcodeItem.Text = "";
            this.lstConferidos.Items.Clear();
            this.lstDisponiveis.Items.Clear();

            this.fecharPallet();
            this.loadPallet();

            this.txtBarcodeCaixa.Focus();

            this.lblPedido.Text = "Pedido: ";
            this.lblCliente.Text = "Cliente: ";
            this.lblItem.Text = "Item: ";




        }

        private void loadCaixaInfo(string barcode)
        {
            this.btnSalvar.Enabled = false;

            barcode = barcode.Trim().Replace("\r\n", "");
            if (barcode != "")
            {
                try
                {
                    ocEmConferencia = FactoryConferencia.getConferenciaInstance(barcode,
                        this.iOrdemProducaoFactory,
                        this.Usuario,
                        this.conn, 
                        this);

                    if (ocEmConferencia.ExigeValidacaoPesoExpedicao)
                    {
                        ConferenciaPedidoPesoForm form = new ConferenciaPedidoPesoForm(ocEmConferencia.CodItemPai, ocEmConferencia.PesoPaiUnitario);
                        form.ShowDialog(this);

                        ocEmConferencia.PesoPaiUnitario = form.Peso;
                    }


                    this.lblPedido.Text = "Pedido: " + ocEmConferencia.OrderNumber + "/" + ocEmConferencia.OrderPos;
                    this.lblCliente.Text = "Cliente: " + ocEmConferencia.Cliente;
                    this.lblItem.Text = "Item: " + ocEmConferencia.CodItemPai + " - " + ocEmConferencia.DescItemPai;

                    LogClass.EscreverLog("Inicio da Conferência: " + ocEmConferencia.OrderNumber + "/" + ocEmConferencia.OrderPos + " (" + this.palletEmConferencia.Numero + "-" + this.palletEmConferencia.Sequencia + ")", _arquivoLogEmbalagem, true);

                    if (ocEmConferencia.Abort)
                    {
                        this.ResetForm();
                        return;
                    }

                }
                catch (Exception a)
                {
                    if (a.Message.ToUpper().Contains("BROKEN"))
                    {
                        MessageBox.Show(this, "O sistema perdeu a conexão com o servidor e será encerrado agora.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                        return;
                    }
                    else
                    {
                        MessageBox.Show(this, "Erro ao carregar as informações da oc.\r\n" + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.ResetForm();
                        return;
                    }
                }

                ocEmConferencia.SetPallet(this.palletEmConferencia);

                this.grbModoOperacao.Enabled = false;
                this.grbCaixa.Enabled = false;
                this.grbItem.Enabled = true;

                //this.btnSalvar.Enabled = true;
                this.loadLists();
                if (this.ocEmConferencia != null)
                {
                    this.txtBarcodeItem.Focus();
                    if (this.ocEmConferencia.UtilizarTimer)
                    {
                        try
                        {
                            IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                            command.CommandText = "SELECT pro_tempo_limite FROM produto WHERE pro_codigo LIKE '" + this.ocEmConferencia.CodItemPai + "'";

                            object tmp = command.ExecuteScalar();
                            if (tmp != null)
                            {
                                tempoConferenciaRestante = (int)tmp;
                            }
                            else
                            {
                                tempoConferenciaRestante =this.segundosLimteConferencia;
                            }
                        }
                        catch (Exception e)
                        {
                            tempoConferenciaRestante = this.segundosLimteConferencia;
                        }


                        this.updateTempoRestante();
                        this.timerConferencia.Interval = 1000;
                        this.timerConferencia.Enabled = true;
                    }
                    else
                    {

                        this.lblTempo.Text = "";
                    }


                }
                else
                {
                    //this.ResetForm();
                }

            }

            

        }

        private void loadLists()
        {
            this.lstConferidos.Items.Clear();
            this.lstDisponiveis.Items.Clear();

            foreach (ItemConferencia item in this.ocEmConferencia.Itens)
            {
                if (item.SaldoNessaOperacao > 0)
                {
                    this.lstDisponiveis.Items.Add(item.Key.OrderNumber + "/" + item.Key.OrderPos + " - " + item.Key.CodProduto + " - " + item.Key.Medida + ": " + item.SaldoNessaOperacao.ToString(CultureInfo.CurrentCulture));
                }
                if (item.QtdConferidaNessaOperacao > 0)
                {
                    this.lstConferidos.Items.Add(item.Key.OrderNumber + "/" + item.Key.OrderPos + " - " + item.Key.CodProduto + " - " + item.Key.Medida + ": " + item.QtdConferidaNessaOperacao.ToString(CultureInfo.CurrentCulture));
                }
            }

            if (this.lstDisponiveis.Items.Count == 0)
            {
                timerConferencia.Enabled = false;
                this.SalvarConferencia();
            }
        } 

        private void confereItem(string barcode)
        {
         

            if (barcode != "")
            {
                bool umaConferenciaReal = false;
                try
                {
                    string[] codigoBarras = barcode.Split(new string[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);


                   
                    foreach (string codigo in codigoBarras)
                    {
                        LogClass.EscreverLog("Conferir Item Conferência: " + ocEmConferencia.OrderNumber + "/" + ocEmConferencia.OrderPos + " (" + this.palletEmConferencia.Numero + "-" + this.palletEmConferencia.Sequencia + ")", _arquivoLogEmbalagem, true);

                        if (ocEmConferencia.ConferirItem(codigo))
                        {
                            umaConferenciaReal = true;
                        }

                        LogClass.EscreverLog("Fim Item Conferência: " + ocEmConferencia.OrderNumber + "/" + ocEmConferencia.OrderPos + " (" + this.palletEmConferencia.Numero + "-" + this.palletEmConferencia.Sequencia + ")", _arquivoLogEmbalagem, true);
                    }
                    if (umaConferenciaReal)
                    {
                        SoundPlayer simpleSound = new SoundPlayer(@AppDomain.CurrentDomain.BaseDirectory + "\\certo.wav");
                        simpleSound.Play();
                    }


                }
                catch (Exception a)
                {
                    if (a.Message.ToUpper().Contains("BROKEN"))
                    {
                        MessageBox.Show(this, "O sistema perdeu a conexão com o servidor e será encerrado agora.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                    else
                    {
                        SoundPlayer simpleSound = new SoundPlayer(@AppDomain.CurrentDomain.BaseDirectory + "\\errado.wav");
                        simpleSound.Play();
                        MessageBox.Show(this, "Erro ao conferir o item.\r\n" + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (umaConferenciaReal)
                {
                    this.loadLists();
                }
                this.txtBarcodeItem.Text = "";
                this.txtBarcodeItem.Focus();
            }

        }    

        private void SalvarConferencia()
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                ocEmConferencia.setCaminhoLog(_arquivoLogEmbalagem);

                LogClass.EscreverLog("Salvar Conferência: " + ocEmConferencia.OrderNumber + "/" + ocEmConferencia.OrderPos + " (" + this.palletEmConferencia.Numero + "-" + this.palletEmConferencia.Sequencia + ")", _arquivoLogEmbalagem, true);

                command = this.conn.CreateCommand();
                command.Transaction = this.conn.BeginTransaction();

                OrderItemEtiquetaConferenciaClass conferencia;
                bool ss = ocEmConferencia.Salvar(ref command, out conferencia);

                if (ss)
                {
                    LogClass.EscreverLog("Antes Imprimir Etiqueta: " + ocEmConferencia.OrderNumber + "/" + ocEmConferencia.OrderPos + " (" + this.palletEmConferencia.Numero + "-" + this.palletEmConferencia.Sequencia + ")", _arquivoLogEmbalagem, true);
                    this.PrintEtiqueta(ref command, conferencia);
                    LogClass.EscreverLog("Depois Imprimir Etiqueta: " + ocEmConferencia.OrderNumber + "/" + ocEmConferencia.OrderPos + " (" + this.palletEmConferencia.Numero + "-" + this.palletEmConferencia.Sequencia + ")", _arquivoLogEmbalagem, true);
                    command.Transaction.Commit();
                    LogClass.EscreverLog("Depois Comit Salvar: " + ocEmConferencia.OrderNumber + "/" + ocEmConferencia.OrderPos + " (" + this.palletEmConferencia.Numero + "-" + this.palletEmConferencia.Sequencia + ")", _arquivoLogEmbalagem, true);

                    this.ResetForm();
                }
                else
                {
                    LogClass.EscreverLog("Conferência NÃO salva: " + ocEmConferencia.OrderNumber + "/" + ocEmConferencia.OrderPos + " (" + this.palletEmConferencia.Numero + "-" + this.palletEmConferencia.Sequencia + ")", _arquivoLogEmbalagem, true);
                    if (command != null && command.Transaction != null)
                    {
                        command.Transaction.Rollback();
                    }

                    this.btnSalvar.Enabled = true;
                }

            }
            catch (Exception e)
            {
                LogClass.EscreverLog("Erro salvar conferência: "+e.Message+": " + ocEmConferencia.OrderNumber + "/" + ocEmConferencia.OrderPos + " (" + this.palletEmConferencia.Numero + "-" + this.palletEmConferencia.Sequencia + ")", _arquivoLogEmbalagem, true);
                if (e.Message.ToUpper().Contains("BROKEN"))
                {
                    MessageBox.Show(this, "O sistema perdeu a conexão com o servidor e será encerrado agora.", "Erro",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    return;
                }


                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }

                MessageBox.Show(this, e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.ResetForm();
            }




            

        }

        private void updateTempoRestante()
        {
            int horas;
            int minutos;
            int segundos;

            horas = (int)(this.tempoConferenciaRestante / 3600);
            minutos = (int)((this.tempoConferenciaRestante - (horas*3600)) / 60);
            segundos = this.tempoConferenciaRestante - (horas * 3600) - (minutos * 60);

            this.lblTempo.Text = horas.ToString("D2") + "h " + minutos.ToString("D2") + "m " + segundos.ToString("D2") + " s";


        }

        private void loadPallet()
        {
            try
            {
                if (this.palletEmConferencia == null)
                {
                    PalletForm form = new PalletForm(this.Usuario,this.conn);
                    if (!form.IsDisposed)
                    {
                        form.ShowDialog();
                    }

                    while (!form.sairSistema && form.palletToRet == null)
                    {
                        MessageBox.Show(this, "Você deve escolher um pallet para poder continuar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        form.ShowDialog();
                    }

                    if (form.sairSistema)
                    {
                        this.Close();
                    }
                    else
                    {
                        LogClass.EscreverLog("Inicio da Conferência Pallet: " + form.palletToRet.Numero + " (" + form.palletToRet.Sequencia + ")", _arquivoLogEmbalagem, true);
                        this.palletEmConferencia = form.palletToRet;
                        this.palletEmConferencia.setOcupado(true, this.Usuario);
                        this.palletEmConferencia.setFechado(false);
                        this.palletEmConferencia.setUtilizadoMomento(true);
                        this.palletEmConferencia.Save();
                        this.lblPallet.Text = this.palletEmConferencia.Numero.ToString();


                    }
                }
            }
            catch (Exception e)
            {
                if (e.Message.ToUpper().Contains("BROKEN"))
                {
                    MessageBox.Show(this, "O sistema perdeu a conexão com o servidor e será encerrado agora.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show(this, e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

        }

        private void fecharPallet()
        {
            try
            {
                FechamentoPalletForm form = new FechamentoPalletForm();
                form.ShowDialog();

                if (form.fecharPallet)
                {
                    LogClass.EscreverLog("Fechamento do Pallet: " + this.palletEmConferencia.Numero + " (" + this.palletEmConferencia.Sequencia + ")", _arquivoLogEmbalagem, true);
                    this.palletEmConferencia.setFechado(true);
                    this.palletEmConferencia.setUtilizadoMomento(false);
                    this.palletEmConferencia.Save();
                    this.palletEmConferencia = null;
                }
            }
            catch (Exception e)
            {
                if (e.Message.ToUpper().Contains("BROKEN"))
                {
                    MessageBox.Show(this, "O sistema perdeu a conexão com o servidor e será encerrado agora.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show(this, e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }

        }

        #endregion

        #region Metodos especificos cliente

        public virtual string getCubagem(double? altura, double? largura, double? comprimento, out string cubagemM3)
        {
            if (!altura.HasValue || !largura.HasValue || !comprimento.HasValue)
            {
                cubagemM3 = "0";
                return "0,00";
            }

            cubagemM3 = (altura.Value*largura.Value*comprimento.Value).ToString("F2", CultureInfo.CurrentCulture);
            return cubagemM3;
        }

        protected virtual void PrintEtiqueta(ref IWTPostgreNpgsqlCommand command, OrderItemEtiquetaConferenciaClass conferencia)
        {
            try
            {
                command.CommandText =
                    "SELECT  " +
                    "  public.order_item_etiqueta.oie_qtd_etiqueta_exp_volume, " +
                    "  public.order_item_etiqueta.oie_volumes, " +
                    "  public.order_item_etiqueta.oie_codigo_cliente, " +
                    "  public.order_item_etiqueta.oie_ovm, " +
                    "  public.order_item_etiqueta.oie_descricao_cliente, " +
                    "  public.order_item_etiqueta.oie_altura, " +
                    "  public.order_item_etiqueta.oie_largura, " +
                    "  public.order_item_etiqueta.oie_comprimento, " +
                    "  public.order_item_etiqueta.oie_armazenagem_cliente, " +
                    "  public.order_item_etiqueta.oie_deps, " +
                    "  public.order_item_etiqueta.oie_peps, " +
                    "  public.cliente.cli_nome, " +
                    "  public.cliente.cli_endereco_cob, " +
                    "  public.cliente.cli_bairro_cob, " +
                    "  public.cliente.cli_cep_cob, " +
                    "  public.cliente.cli_endereco_numero_cob, " +
                    "  public.cliente.cli_complemento_cob, " +
                    "  public.cidade.cid_nome, " +
                    "  public.estado.est_sigla " +
                    "FROM " +
                    "  public.order_item_etiqueta " +
                    "  INNER JOIN public.cliente ON (public.order_item_etiqueta.id_cliente = public.cliente.id_cliente) " +
                    "  LEFT OUTER JOIN public.cidade ON (public.cliente.id_cidade_cob = public.cidade.id_cidade) " +
                    "  LEFT OUTER JOIN public.estado ON (public.cidade.id_estado = public.estado.id_estado) " +
                    "WHERE " +
                    "  order_item_etiqueta.id_order_item_etiqueta= " + ocEmConferencia.IdOrderItemEtiqueta;
                    

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                List<EtiquetaExpedicaoClass> etiquetasImprimir = new List<EtiquetaExpedicaoClass>();

                while (read.Read())
                {
                    int volumes = this.ocEmConferencia.Volumes.Count;
                    int copias = Convert.ToInt32(read["oie_qtd_etiqueta_exp_volume"]);


                   

                    string endereco = read["cli_endereco_cob"] + ", " +
                                   read["cli_endereco_numero_cob"] +
                                   (String.IsNullOrWhiteSpace(read["cli_complemento_cob"].ToString())? ", " : " - " + read["cli_complemento_cob"] + ", ") +
                                   read["cli_bairro_cob"] + " CEP: " +
                                   read["cli_cep_cob"] + " - " +
                                   read["cid_nome"] + ", " +
                                   read["est_sigla"];


                    foreach (OrderItemEtiquetaConferenciaVolumesClass volume in conferencia.CollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferencia)
                    {
                        
                        EtiquetaExpedicaoClass tmp = null;
                        for (int j = 0; j < copias; j++)
                        {
                            if (j == 0)
                            {
                                tmp = new EtiquetaExpedicaoClass(
                                    read["cli_nome"].ToString(),
                                    volume.Cubagem,
                                    this.Fornecedor,
                                    this.fornecedorLogo,
                                    read["oie_codigo_cliente"].ToString(),
                                    read["oie_descricao_cliente"].ToString(),
                                    volume.Quantidade,
                                    read["oie_armazenagem_cliente"].ToString(),
                                    this.ocEmConferencia.OrderNumber,
                                    this.ocEmConferencia.OrderPos,
                                    read["oie_ovm"].ToString(),
                                    volume.Peso,
                                    volume.NumeroVolume,
                                    volumes,
                                    this.Usuario.Login,
                                    this.palletEmConferencia.Numero.ToString(),
                                    false,
                                    this.TipoEtiqueta,
                                    ocEmConferencia.IdOrderItemEtiqueta,
                                    endereco,
                                    volume.ID
                                    );

                                tmp.Sequencial = (j + 1) + "/" + copias.ToString();

                                etiquetasImprimir.Add(tmp);
                            }
                            else
                            {
                                EtiquetaExpedicaoClass tmp2 = tmp.Clone();
                                tmp2.Sequencial = (j + 1) + "/" + copias.ToString();

                                etiquetasImprimir.Add(tmp2);
                            }                            
                           
                        }

                       
                    }

                }

                read.Close();

                if (etiquetasImprimir.Count == 0)
                {
                    MessageBox.Show("Não existe nenhuma etiqueta a ser impressa!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ReportDocument rep;

                switch (TipoEtiqueta)
                {
                    case TipoEtiquetaExpedicao.Grande:
                        rep = new EtiquetaExpedicaoReport();
                        break;
                    case TipoEtiquetaExpedicao.Media:
                        rep = new EtiquetaExpedicaoMediaReport();
                        break;
                    case TipoEtiquetaExpedicao.Pequena:
                        rep = new EtiquetaExpedicaoPequenaReport();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                

                rep.SetDataSource(etiquetasImprimir);
                rep.Refresh();

                //Definindo papel correto
                try
                {
                    int j;
                    Boolean found1 = false;
                    string PaperList = "";
                    int rawKind1 = 0;
                    PrintDocument doctoprint = new PrintDocument();
                    doctoprint.PrinterSettings.PrinterName = this.impressoraEtiquetaExpedicao;
                    rep.PrintOptions.PrinterName = doctoprint.PrinterSettings.PrinterName;

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
                            if (paperSizeCollection[j].PaperName == this.etiquetaExpedicao)
                            {
                                FieldInfo fieldInfo = paperSizeCollection[j].GetType().GetField("kind", BindingFlags.Instance | BindingFlags.NonPublic);
                                if (fieldInfo != null)
                                {
                                    rawKind1 = (int) (fieldInfo.GetValue(paperSizeCollection[j]));
                                    found1 = true;
                                }
                            }
                        }

                        if (!found1)
                        {
                            MessageBox.Show("Papel da Etiqueta não encontrado!\r\n Você deve selecionar entre os papeis abaixo, coloca-lo na configuração e gerar o relatório novamente.\r\n" + PaperList, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                       
                        PaperSize tmpaa = (PaperSize)rawKind1;
                        rep.PrintOptions.PaperSize = tmpaa;
                    }
                }
                catch (Exception r)
                {
                    MessageBox.Show("Erro ao definir o tipo de papel correto! (" + impressoraEtiquetaExpedicao + "-" + etiquetaExpedicao + ")\r\n" + r, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                rep.PrintToPrinter(1, false, 0, 99999);

            }
            catch (Exception e)
            {
                if (e.Message.ToUpper().Contains("BROKEN"))
                {
                    MessageBox.Show(this, "O sistema perdeu a conexão com o servidor e será encerrado agora.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                else
                {
                    throw new Exception("Erro ao imprimir a etiqueta.\r\n" + e.Message);
                }
            }
        }

        #endregion

        #region Eventos
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.ResetForm();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            //this.ResetForm();

            this.txtBarcodeCaixa.ShortcutsEnabled = true;
        }

        private void rdbBarCode_CheckedChanged(object sender, EventArgs e)
        {
            this.btnCaixa.Enabled = rdbManual.Checked;
            this.btnItem.Enabled = rdbManual.Checked;
        }

        private void rdbManual_CheckedChanged(object sender, EventArgs e)
        {
            this.btnCaixa.Enabled = rdbManual.Checked;
            this.btnItem.Enabled = rdbManual.Checked;
        }

        private void txtBarcodeCaixa_TextChanged(object sender, EventArgs e)
        {
            timerCaixa.Stop();
            timerCaixa.Start();
        }

        private void timerCaixa_Tick(object sender, EventArgs e)
        {
            timerCaixa.Enabled = false;
            if (this.rdbBarCode.Checked)
            {
                this.loadCaixaInfo(this.txtBarcodeCaixa.Text);
            }

        }

        private void btnCaixa_Click(object sender, EventArgs e)
        {
            this.loadCaixaInfo(this.txtBarcodeCaixa.Text);
        }

        private void txtBarcodeItem_TextChanged(object sender, EventArgs e)
        {
            timerItem.Stop();
            timerItem.Start();
        }

        private void timerItem_Tick(object sender, EventArgs e)
        {
            timerItem.Enabled = false;
            if (this.rdbBarCode.Checked)
            {
                this.confereItem(this.txtBarcodeItem.Text);
            }
        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            this.confereItem(this.txtBarcodeItem.Text);
        }
     
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            this.SalvarConferencia();
        }
      
        private void txtBarcodeCaixa_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.rdbManual.Checked && (e.KeyCode == Keys.Return || e.KeyCode== Keys.Enter))
            {
                this.btnCaixa_Click(null, null);
            }
        }

        private void txtBarcodeItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.rdbManual.Checked && (e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter))
            {
                this.btnItem_Click(null, null);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (this.Usuario == null)
            {
                Application.Exit();
            }
        }

        private void timerConferencia_Tick(object sender, EventArgs e)
        {
            timerConferencia.Enabled = false;
            this.tempoConferenciaRestante--;
            if (tempoConferenciaRestante == 0)
            {
                MessageBox.Show(this, "Você excedeu o tempo limite configurado para a conferência de um item. Por motivos de segurança a conferência deverá ser reiniciada!", "Tempo limite excedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.ResetForm();
            }
            else
            {
                timerConferencia.Stop();
                timerConferencia.Start();
            }
            this.updateTempoRestante();
            
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.palletEmConferencia != null && !this.palletEmConferencia.Fechado)
            {
                DialogResult res = MessageBox.Show(this,"Você está saindo do sistema sem fechar o pallet deseja mante-lo aberto para continuar posteriormente?","Pallet Aberto",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
                if (res == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
                else
                {
                    try
                    {
                        if (res == DialogResult.No)
                        {
                            this.palletEmConferencia.setFechado(true);
                        }
                        this.palletEmConferencia.setUtilizadoMomento(false);
                        this.palletEmConferencia.Save();
                    }
                    catch (Exception a)
                    {
                        if (a.Message.ToUpper().Contains("BROKEN"))
                        {
                            MessageBox.Show(this, "O sistema perdeu a conexão com o servidor e será encerrado agora.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Application.Exit();
                            return;
                        }
                        else
                        {
                            MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

            
            }
        }

        private void lstDisponiveis_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void lstConferidos_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
      
        private void lstDisponiveis_SelectedValueChanged(object sender, EventArgs e)
        {
            lstDisponiveis.SelectedIndex = -1;
        }

        private void lstConferidos_SelectedValueChanged(object sender, EventArgs e)
        {
            lstConferidos.SelectedIndex = -1;
        }
        #endregion

    }


   
}
