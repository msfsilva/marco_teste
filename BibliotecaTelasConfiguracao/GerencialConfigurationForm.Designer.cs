using Configurations;
using ProjectConstants;

namespace BibliotecaTelasConfiguracao
{
    partial class GerencialConfigurationForm
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.GroupBox groupBox13;
            this.rdSomenteSbZero = new System.Windows.Forms.RadioButton();
            this.rdImprimirTodos = new System.Windows.Forms.RadioButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.iwtLabel17 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudAvisoItensSemPedido = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.chkAvisoItensSemPedido = new System.Windows.Forms.CheckBox();
            this.chkQtdFracionariaOP = new System.Windows.Forms.CheckBox();
            this.chkUtilizarEstoqueOP = new System.Windows.Forms.CheckBox();
            this.pcbLogo = new System.Windows.Forms.PictureBox();
            this.btnLogo = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.nudNumThreads = new System.Windows.Forms.NumericUpDown();
            this.label43 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label41 = new System.Windows.Forms.Label();
            this.cmbSemanaDia = new System.Windows.Forms.ComboBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.rdbSemanaQuatroDias = new System.Windows.Forms.RadioButton();
            this.rdSemanaInteira = new System.Windows.Forms.RadioButton();
            this.rdbSemanaPrimeiroDia = new System.Windows.Forms.RadioButton();
            this.chkSupplyOn = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnLogEasi = new System.Windows.Forms.Button();
            this.txtDiretorioLogEasi = new System.Windows.Forms.TextBox();
            this.label63 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSaidaNFeEntrada = new System.Windows.Forms.Button();
            this.txtSaidaNFeEntrada = new System.Windows.Forms.TextBox();
            this.btnEntradaNFeEntrada = new System.Windows.Forms.Button();
            this.txtEntradaNFeEntrada = new System.Windows.Forms.TextBox();
            this.btnSaidaArquivoDados = new System.Windows.Forms.Button();
            this.txtDiretorioExportacaoCSV = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtEstacaoAutomacao = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel21 = new IWTDotNetLib.IWTLabel(this.components);
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.nudTabelaPrecosMinutos = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.iwtLabel20 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudTabelaPrecosHora = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.iwtLabel19 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtRadioButton1 = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbTabelaPrecosAutomatico = new IWTDotNetLib.IWTRadioButton(this.components);
            this.grbExportacaoContas = new System.Windows.Forms.GroupBox();
            this.label49 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.nudExportacaoContasMinuto = new System.Windows.Forms.NumericUpDown();
            this.chkExportacaoContas = new System.Windows.Forms.CheckBox();
            this.grbExportacaoPedidos = new System.Windows.Forms.GroupBox();
            this.label46 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.nudExportacaoPedidosIntervalo = new System.Windows.Forms.NumericUpDown();
            this.chkExportacaoPedidos = new System.Windows.Forms.CheckBox();
            this.label20 = new System.Windows.Forms.Label();
            this.nudIntervaloImportacaoNFEntrada = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.nudIntervaloImportacaoPedidos = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.LimiteSessaonumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.nudDiasDuplicata = new System.Windows.Forms.NumericUpDown();
            this.label27 = new System.Windows.Forms.Label();
            this.nudPorcentagemCancelamentoSaldo = new System.Windows.Forms.NumericUpDown();
            this.label25 = new System.Windows.Forms.Label();
            this.nudSegundosConferencia = new System.Windows.Forms.NumericUpDown();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.rdbEtiquetaProdutoVertical = new System.Windows.Forms.RadioButton();
            this.rdbEtiquetaProdutoHorizontal = new System.Windows.Forms.RadioButton();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.rdbEtiquetaPequenaRecebimento = new System.Windows.Forms.RadioButton();
            this.rdbEtiquetaMediaRecebimento = new System.Windows.Forms.RadioButton();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.rdbEtiquetaPequena = new System.Windows.Forms.RadioButton();
            this.rdbEtiquetaMedia = new System.Windows.Forms.RadioButton();
            this.rdbEtiquetaGrande = new System.Windows.Forms.RadioButton();
            this.grbEtiquetaExpedicao = new System.Windows.Forms.GroupBox();
            this.cmbPapelExpedicao = new System.Windows.Forms.ComboBox();
            this.cmbImpressoraExpedicao = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbPapelInterno = new System.Windows.Forms.ComboBox();
            this.cmbImpressoraInterna = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.tabPage14 = new System.Windows.Forms.TabPage();
            this.rdbEtiquetaClienteComum = new System.Windows.Forms.RadioButton();
            this.rdbEtiquetaClienteZebra = new System.Windows.Forms.RadioButton();
            this.grbEtiquetaClienteComum = new System.Windows.Forms.GroupBox();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.nudEtiquetaAltura = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.nudEtiquetaLinhas = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.iwtLabel8 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel9 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel10 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudEtiquetaColunas = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.nudEtiquetaLargura = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.iwtLabel11 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudEtiquetaIntervaloVertical = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.nudEtiquetaIntervaloHorizontal = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.iwtLabel12 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel13 = new IWTDotNetLib.IWTLabel(this.components);
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.nudPapelAltura = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.nudPapelMargemDireita = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.iwtLabel4 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel7 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel6 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudPapelMargemInferior = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.nudPapelLargura = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.iwtLabel5 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudPapelMargemSuperior = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.nudPapelMargemEsquerda = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.iwtLabel14 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel15 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudResolucao = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.iwtLabel16 = new IWTDotNetLib.IWTLabel(this.components);
            this.grbEtiquetaClienteZebra = new System.Windows.Forms.GroupBox();
            this.cmbEtiquetaClientePapel = new System.Windows.Forms.ComboBox();
            this.cmbEtiquetaClienteImpressora = new System.Windows.Forms.ComboBox();
            this.label64 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.chkDestinatarioConfiguracaoAutomatica = new System.Windows.Forms.CheckBox();
            this.grbDestinatarioConfiguracaoAutomatica = new System.Windows.Forms.GroupBox();
            this.txtDestinatarioConfiguracaoAutomatica = new System.Windows.Forms.TextBox();
            this.label66 = new System.Windows.Forms.Label();
            this.chkEnvioOrcamentoDestInterno = new System.Windows.Forms.CheckBox();
            this.chkEnvioPedidoDestInterno = new System.Windows.Forms.CheckBox();
            this.grpDestInternoPedido = new System.Windows.Forms.GroupBox();
            this.txtDestinatarioInternoPedido = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.grpDestInternoOrcamento = new System.Windows.Forms.GroupBox();
            this.txtDestinatarioInternoOrcamento = new System.Windows.Forms.TextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtRementePedidoOrcamento = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.txtRemetenteCompras = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.chkAvisoEmissaoNF = new System.Windows.Forms.CheckBox();
            this.grbAvisoEmissaoNF = new System.Windows.Forms.GroupBox();
            this.txtDestinatario = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.txtRemetente = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkSmtpSSH = new System.Windows.Forms.CheckBox();
            this.txtSmtpSenha = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.txtSmtpUsuario = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.chkSmtpAutenticado = new System.Windows.Forms.CheckBox();
            this.nudSmtpPort = new System.Windows.Forms.NumericUpDown();
            this.label33 = new System.Windows.Forms.Label();
            this.txtSmtpHost = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.nudDiasArmazenagemOP = new System.Windows.Forms.NumericUpDown();
            this.label42 = new System.Windows.Forms.Label();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.chkExigirDocumentosOpZerada = new System.Windows.Forms.CheckBox();
            this.label69 = new System.Windows.Forms.Label();
            this.chkSuprimirQtdUnitariaMaterialOP = new System.Windows.Forms.CheckBox();
            this.label62 = new System.Windows.Forms.Label();
            this.chkPermitirSelecaoImpressoraExp = new System.Windows.Forms.CheckBox();
            this.nudPorcentagemProducaoAcima = new System.Windows.Forms.NumericUpDown();
            this.label60 = new System.Windows.Forms.Label();
            this.nudMesesCustoHora = new System.Windows.Forms.NumericUpDown();
            this.label58 = new System.Windows.Forms.Label();
            this.chkSuprimirOrdensZeradasKb = new System.Windows.Forms.CheckBox();
            this.label56 = new System.Windows.Forms.Label();
            this.cmbImpressoraOP = new System.Windows.Forms.ComboBox();
            this.label45 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.iwtLabel18 = new IWTDotNetLib.IWTLabel(this.components);
            this.chkEstoquePermitirCriacaoLocalEstoque = new IWTDotNetLib.IWTCheckBox(this.components);
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.nudEstoqueInventarioPrecoMedioMeses = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.iwtLabel3 = new IWTDotNetLib.IWTLabel(this.components);
            this.chkEstoqueInventarioPrecoMedio = new IWTDotNetLib.IWTCheckBox(this.components);
            this.iwtLabel2 = new IWTDotNetLib.IWTLabel(this.components);
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.rdbTipoFormMovA5 = new System.Windows.Forms.RadioButton();
            this.rdbTipoFormMovEtqM = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.nudEstoqueClassificacaoB = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.nudEstoqueClassificacaoA = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.nudEstoqueMeses = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.nudEstoqueMargemRevisaoKb = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.nudEstoqueDiasVermelho = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudEstoqueDiasAmarelo = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudEstoqueDiasVerde = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.chkComprasFluxoAprovacao = new IWTDotNetLib.IWTCheckBox(this.components);
            this.label71 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.chkComprasContasRevisarPadraoFornecedores = new IWTDotNetLib.IWTCheckBox(this.components);
            this.label68 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.chkComprasPermitirPrazoDomingo = new IWTDotNetLib.IWTCheckBox(this.components);
            this.chkComprasPermitirPrazoSabado = new IWTDotNetLib.IWTCheckBox(this.components);
            this.nudMargemRecebimento = new System.Windows.Forms.NumericUpDown();
            this.label44 = new System.Windows.Forms.Label();
            this.txtComprasEmailTexto = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtComprasRodape = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.nudComprasDias = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.nudComprasSugeridoAcimaConfigurado = new System.Windows.Forms.NumericUpDown();
            this.nudComprasDisparoSolicitacaoCompra = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.nudComprasDiasPCP = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.nudDocumentosQtdMaximaCopias = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.chkEnviarEmailRelComissoes = new IWTDotNetLib.IWTCheckBox(this.components);
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtEmailRelComissoes = new IWTDotNetLib.IWTTextBox(this.components);
            this.btnCentroCusto = new System.Windows.Forms.Button();
            this.txtCentroCusto = new IWTDotNetLib.IWTTextBox(this.components);
            this.cmbContaBancaria = new IWTDotNetLib.IWTMultiColumnComboBox(this.components);
            this.label55 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.tabPage12 = new System.Windows.Forms.TabPage();
            this.chkAvisoContaRecorrente = new System.Windows.Forms.CheckBox();
            this.label57 = new System.Windows.Forms.Label();
            this.nudDiasAvisoContaRecorrente = new System.Windows.Forms.NumericUpDown();
            this.cbxAvisoConciliacao = new System.Windows.Forms.CheckBox();
            this.label51 = new System.Windows.Forms.Label();
            this.nudDiasAvisoConc = new System.Windows.Forms.NumericUpDown();
            this.tabPage13 = new System.Windows.Forms.TabPage();
            this.numDiasvalidadePrecoProduto = new System.Windows.Forms.NumericUpDown();
            this.iwtLabel24 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel23 = new IWTDotNetLib.IWTLabel(this.components);
            this.chkRegistrarAlteracoesPedido = new IWTDotNetLib.IWTCheckBox(this.components);
            this.iwtLabel22 = new IWTDotNetLib.IWTLabel(this.components);
            this.chkPesoVolumeNFe = new IWTDotNetLib.IWTCheckBox(this.components);
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.rdbNumeroPedidoNaoIncluir = new System.Windows.Forms.RadioButton();
            this.rdbNumeroPedidoObservacao = new System.Windows.Forms.RadioButton();
            this.rdbNumeroPedidoDescricaoItem = new System.Windows.Forms.RadioButton();
            this.chkPermitirFaturarPedido = new System.Windows.Forms.CheckBox();
            this.label61 = new System.Windows.Forms.Label();
            this.txtObsPadraoEspelho = new System.Windows.Forms.TextBox();
            this.label59 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ofdLogo = new System.Windows.Forms.OpenFileDialog();
            this.label72 = new System.Windows.Forms.Label();
            this.chkMarcarAutomaticamenteOcComDescontoParaNaoAtualizarPrecoProduto = new IWTDotNetLib.IWTCheckBox(this.components);
            groupBox13 = new System.Windows.Forms.GroupBox();
            groupBox13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAvisoItensSemPedido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumThreads)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTabelaPrecosMinutos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTabelaPrecosHora)).BeginInit();
            this.grbExportacaoContas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudExportacaoContasMinuto)).BeginInit();
            this.grbExportacaoPedidos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudExportacaoPedidosIntervalo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntervaloImportacaoNFEntrada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntervaloImportacaoPedidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LimiteSessaonumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiasDuplicata)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPorcentagemCancelamentoSaldo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSegundosConferencia)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.grbEtiquetaExpedicao.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage14.SuspendLayout();
            this.grbEtiquetaClienteComum.SuspendLayout();
            this.groupBox16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEtiquetaAltura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEtiquetaLinhas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEtiquetaColunas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEtiquetaLargura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEtiquetaIntervaloVertical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEtiquetaIntervaloHorizontal)).BeginInit();
            this.groupBox17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPapelAltura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPapelMargemDireita)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPapelMargemInferior)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPapelLargura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPapelMargemSuperior)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPapelMargemEsquerda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudResolucao)).BeginInit();
            this.grbEtiquetaClienteZebra.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.grbDestinatarioConfiguracaoAutomatica.SuspendLayout();
            this.grpDestInternoPedido.SuspendLayout();
            this.grpDestInternoOrcamento.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.grbAvisoEmissaoNF.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSmtpPort)).BeginInit();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiasArmazenagemOP)).BeginInit();
            this.tabPage8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPorcentagemProducaoAcima)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMesesCustoHora)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.groupBox14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEstoqueInventarioPrecoMedioMeses)).BeginInit();
            this.groupBox12.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEstoqueClassificacaoB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEstoqueClassificacaoA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEstoqueMeses)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEstoqueMargemRevisaoKb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEstoqueDiasVermelho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEstoqueDiasAmarelo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEstoqueDiasVerde)).BeginInit();
            this.tabPage9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMargemRecebimento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudComprasDias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudComprasSugeridoAcimaConfigurado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudComprasDisparoSolicitacaoCompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudComprasDiasPCP)).BeginInit();
            this.tabPage10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDocumentosQtdMaximaCopias)).BeginInit();
            this.tabPage11.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.tabPage12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiasAvisoContaRecorrente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiasAvisoConc)).BeginInit();
            this.tabPage13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDiasvalidadePrecoProduto)).BeginInit();
            this.groupBox15.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox13
            // 
            groupBox13.Controls.Add(this.rdSomenteSbZero);
            groupBox13.Controls.Add(this.rdImprimirTodos);
            groupBox13.Location = new System.Drawing.Point(181, 22);
            groupBox13.Name = "groupBox13";
            groupBox13.Size = new System.Drawing.Size(624, 62);
            groupBox13.TabIndex = 0;
            groupBox13.TabStop = false;
            groupBox13.Text = "Tipo de Impressão Pedido Kit";
            // 
            // rdSomenteSbZero
            // 
            this.rdSomenteSbZero.AutoSize = true;
            this.rdSomenteSbZero.Location = new System.Drawing.Point(233, 25);
            this.rdSomenteSbZero.Name = "rdSomenteSbZero";
            this.rdSomenteSbZero.Size = new System.Drawing.Size(139, 17);
            this.rdSomenteSbZero.TabIndex = 1;
            this.rdSomenteSbZero.Text = "Somente sub-Linha zero";
            this.rdSomenteSbZero.UseVisualStyleBackColor = true;
            // 
            // rdImprimirTodos
            // 
            this.rdImprimirTodos.AutoSize = true;
            this.rdImprimirTodos.Checked = true;
            this.rdImprimirTodos.Location = new System.Drawing.Point(88, 25);
            this.rdImprimirTodos.Name = "rdImprimirTodos";
            this.rdImprimirTodos.Size = new System.Drawing.Size(89, 17);
            this.rdImprimirTodos.TabIndex = 0;
            this.rdImprimirTodos.TabStop = true;
            this.rdImprimirTodos.Text = "Imprimir todos";
            this.rdImprimirTodos.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button2);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Size = new System.Drawing.Size(1003, 550);
            this.splitContainer1.SplitterDistance = 513;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage14);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage8);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage9);
            this.tabControl1.Controls.Add(this.tabPage10);
            this.tabControl1.Controls.Add(this.tabPage11);
            this.tabControl1.Controls.Add(this.tabPage12);
            this.tabControl1.Controls.Add(this.tabPage13);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1003, 513);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.iwtLabel17);
            this.tabPage5.Controls.Add(this.nudAvisoItensSemPedido);
            this.tabPage5.Controls.Add(this.chkAvisoItensSemPedido);
            this.tabPage5.Controls.Add(this.chkQtdFracionariaOP);
            this.tabPage5.Controls.Add(this.chkUtilizarEstoqueOP);
            this.tabPage5.Controls.Add(this.pcbLogo);
            this.tabPage5.Controls.Add(this.btnLogo);
            this.tabPage5.Controls.Add(this.label17);
            this.tabPage5.Controls.Add(this.nudNumThreads);
            this.tabPage5.Controls.Add(this.label43);
            this.tabPage5.Controls.Add(this.groupBox4);
            this.tabPage5.Controls.Add(this.chkSupplyOn);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(995, 487);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Geral";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // iwtLabel17
            // 
            this.iwtLabel17.AutoSize = true;
            this.iwtLabel17.BindingField = null;
            this.iwtLabel17.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel17.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel17.Location = new System.Drawing.Point(396, 230);
            this.iwtLabel17.Name = "iwtLabel17";
            this.iwtLabel17.Size = new System.Drawing.Size(26, 13);
            this.iwtLabel17.TabIndex = 12;
            this.iwtLabel17.Text = "dias";
            // 
            // nudAvisoItensSemPedido
            // 
            this.nudAvisoItensSemPedido.BindingField = null;
            this.nudAvisoItensSemPedido.Enabled = false;
            this.nudAvisoItensSemPedido.LiberadoQuandoCadastroUtilizado = false;
            this.nudAvisoItensSemPedido.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudAvisoItensSemPedido.Location = new System.Drawing.Point(270, 229);
            this.nudAvisoItensSemPedido.Maximum = new decimal(new int[] {
            3650,
            0,
            0,
            0});
            this.nudAvisoItensSemPedido.Name = "nudAvisoItensSemPedido";
            this.nudAvisoItensSemPedido.Size = new System.Drawing.Size(120, 20);
            this.nudAvisoItensSemPedido.TabIndex = 7;
            // 
            // chkAvisoItensSemPedido
            // 
            this.chkAvisoItensSemPedido.AutoSize = true;
            this.chkAvisoItensSemPedido.Location = new System.Drawing.Point(8, 230);
            this.chkAvisoItensSemPedido.Name = "chkAvisoItensSemPedido";
            this.chkAvisoItensSemPedido.Size = new System.Drawing.Size(269, 17);
            this.chkAvisoItensSemPedido.TabIndex = 6;
            this.chkAvisoItensSemPedido.Text = "Aviso para pedidos de itens sem pedidos a mais de ";
            this.chkAvisoItensSemPedido.UseVisualStyleBackColor = true;
            this.chkAvisoItensSemPedido.CheckedChanged += new System.EventHandler(this.chkAvisoItensSemPedido_CheckedChanged);
            // 
            // chkQtdFracionariaOP
            // 
            this.chkQtdFracionariaOP.AutoSize = true;
            this.chkQtdFracionariaOP.Location = new System.Drawing.Point(8, 207);
            this.chkQtdFracionariaOP.Name = "chkQtdFracionariaOP";
            this.chkQtdFracionariaOP.Size = new System.Drawing.Size(361, 17);
            this.chkQtdFracionariaOP.TabIndex = 5;
            this.chkQtdFracionariaOP.Text = "Permitir Quantidades Fracionárias na geração das Ordens de Produção";
            this.chkQtdFracionariaOP.UseVisualStyleBackColor = true;
            // 
            // chkUtilizarEstoqueOP
            // 
            this.chkUtilizarEstoqueOP.AutoSize = true;
            this.chkUtilizarEstoqueOP.Location = new System.Drawing.Point(8, 184);
            this.chkUtilizarEstoqueOP.Name = "chkUtilizarEstoqueOP";
            this.chkUtilizarEstoqueOP.Size = new System.Drawing.Size(393, 17);
            this.chkUtilizarEstoqueOP.TabIndex = 4;
            this.chkUtilizarEstoqueOP.Text = "Utilizar Estoques de Produtos Acabados na geração das Ordens de Produção";
            this.chkUtilizarEstoqueOP.UseVisualStyleBackColor = true;
            // 
            // pcbLogo
            // 
            this.pcbLogo.Location = new System.Drawing.Point(111, 284);
            this.pcbLogo.Name = "pcbLogo";
            this.pcbLogo.Size = new System.Drawing.Size(100, 100);
            this.pcbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbLogo.TabIndex = 7;
            this.pcbLogo.TabStop = false;
            // 
            // btnLogo
            // 
            this.btnLogo.Location = new System.Drawing.Point(18, 321);
            this.btnLogo.Name = "btnLogo";
            this.btnLogo.Size = new System.Drawing.Size(85, 23);
            this.btnLogo.TabIndex = 8;
            this.btnLogo.Text = "Selecionar";
            this.btnLogo.UseVisualStyleBackColor = true;
            this.btnLogo.Click += new System.EventHandler(this.btnLogo_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(15, 305);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(90, 13);
            this.label17.TabIndex = 5;
            this.label17.Text = "Logo da Empresa";
            // 
            // nudNumThreads
            // 
            this.nudNumThreads.Location = new System.Drawing.Point(340, 147);
            this.nudNumThreads.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudNumThreads.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumThreads.Name = "nudNumThreads";
            this.nudNumThreads.Size = new System.Drawing.Size(59, 20);
            this.nudNumThreads.TabIndex = 3;
            this.nudNumThreads.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(5, 149);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(329, 13);
            this.label43.TabIndex = 2;
            this.label43.Text = "Número de Processadores a serem utilizados em operações críticas:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label41);
            this.groupBox4.Controls.Add(this.cmbSemanaDia);
            this.groupBox4.Controls.Add(this.label40);
            this.groupBox4.Controls.Add(this.label39);
            this.groupBox4.Controls.Add(this.label38);
            this.groupBox4.Controls.Add(this.rdbSemanaQuatroDias);
            this.groupBox4.Controls.Add(this.rdSemanaInteira);
            this.groupBox4.Controls.Add(this.rdbSemanaPrimeiroDia);
            this.groupBox4.Location = new System.Drawing.Point(8, 33);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(583, 108);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Identificação da Semana";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(6, 82);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(80, 13);
            this.label41.TabIndex = 7;
            this.label41.Text = "Dia da Semana";
            // 
            // cmbSemanaDia
            // 
            this.cmbSemanaDia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSemanaDia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSemanaDia.FormattingEnabled = true;
            this.cmbSemanaDia.Items.AddRange(new object[] {
            "Domingo",
            "Segunda Feira",
            "Terça Feira",
            "Quarta Feira",
            "Quinta Feira",
            "Sexta Feira",
            "Sábado"});
            this.cmbSemanaDia.Location = new System.Drawing.Point(92, 79);
            this.cmbSemanaDia.Name = "cmbSemanaDia";
            this.cmbSemanaDia.Size = new System.Drawing.Size(160, 21);
            this.cmbSemanaDia.TabIndex = 6;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(26, 59);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(539, 13);
            this.label40.TabIndex = 5;
            this.label40.Text = "A primeira semana do ano inicia na primeira semana com 4 dias ou mais antes do di" +
    "a da semana indicado abaixo.";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(26, 39);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(375, 13);
            this.label39.TabIndex = 4;
            this.label39.Text = "A primeira semana do ano inicia na primeria ocorrencia do dia indicado abaixo.";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(26, 19);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(502, 13);
            this.label38.TabIndex = 3;
            this.label38.Text = "A primeira semana do ano inicia no primeiro dia do ano e termina antes do dia da " +
    "semana indicado abaixo";
            // 
            // rdbSemanaQuatroDias
            // 
            this.rdbSemanaQuatroDias.AutoSize = true;
            this.rdbSemanaQuatroDias.Location = new System.Drawing.Point(6, 59);
            this.rdbSemanaQuatroDias.Name = "rdbSemanaQuatroDias";
            this.rdbSemanaQuatroDias.Size = new System.Drawing.Size(14, 13);
            this.rdbSemanaQuatroDias.TabIndex = 2;
            this.rdbSemanaQuatroDias.TabStop = true;
            this.rdbSemanaQuatroDias.UseVisualStyleBackColor = true;
            // 
            // rdSemanaInteira
            // 
            this.rdSemanaInteira.AutoSize = true;
            this.rdSemanaInteira.Location = new System.Drawing.Point(6, 39);
            this.rdSemanaInteira.Name = "rdSemanaInteira";
            this.rdSemanaInteira.Size = new System.Drawing.Size(14, 13);
            this.rdSemanaInteira.TabIndex = 1;
            this.rdSemanaInteira.TabStop = true;
            this.rdSemanaInteira.UseVisualStyleBackColor = true;
            // 
            // rdbSemanaPrimeiroDia
            // 
            this.rdbSemanaPrimeiroDia.AutoSize = true;
            this.rdbSemanaPrimeiroDia.Location = new System.Drawing.Point(6, 19);
            this.rdbSemanaPrimeiroDia.Name = "rdbSemanaPrimeiroDia";
            this.rdbSemanaPrimeiroDia.Size = new System.Drawing.Size(14, 13);
            this.rdbSemanaPrimeiroDia.TabIndex = 0;
            this.rdbSemanaPrimeiroDia.TabStop = true;
            this.rdbSemanaPrimeiroDia.UseVisualStyleBackColor = true;
            // 
            // chkSupplyOn
            // 
            this.chkSupplyOn.AutoSize = true;
            this.chkSupplyOn.Location = new System.Drawing.Point(8, 10);
            this.chkSupplyOn.Name = "chkSupplyOn";
            this.chkSupplyOn.Size = new System.Drawing.Size(106, 17);
            this.chkSupplyOn.TabIndex = 0;
            this.chkSupplyOn.Text = "Utilizar SupplyOn";
            this.chkSupplyOn.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnLogEasi);
            this.tabPage2.Controls.Add(this.txtDiretorioLogEasi);
            this.tabPage2.Controls.Add(this.label63);
            this.tabPage2.Controls.Add(this.groupBox7);
            this.tabPage2.Controls.Add(this.btnSaidaArquivoDados);
            this.tabPage2.Controls.Add(this.txtDiretorioExportacaoCSV);
            this.tabPage2.Controls.Add(this.label26);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(995, 487);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Diretórios";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnLogEasi
            // 
            this.btnLogEasi.Location = new System.Drawing.Point(621, 82);
            this.btnLogEasi.Name = "btnLogEasi";
            this.btnLogEasi.Size = new System.Drawing.Size(37, 23);
            this.btnLogEasi.TabIndex = 3;
            this.btnLogEasi.Text = "...";
            this.btnLogEasi.UseVisualStyleBackColor = true;
            this.btnLogEasi.Click += new System.EventHandler(this.btnLogEasi_Click);
            // 
            // txtDiretorioLogEasi
            // 
            this.txtDiretorioLogEasi.Location = new System.Drawing.Point(101, 82);
            this.txtDiretorioLogEasi.Name = "txtDiretorioLogEasi";
            this.txtDiretorioLogEasi.Size = new System.Drawing.Size(514, 20);
            this.txtDiretorioLogEasi.TabIndex = 2;
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(15, 66);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(201, 13);
            this.label63.TabIndex = 41;
            this.label63.Text = "Local de Saída do Log Principal do EASI";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label12);
            this.groupBox7.Controls.Add(this.label10);
            this.groupBox7.Controls.Add(this.btnSaidaNFeEntrada);
            this.groupBox7.Controls.Add(this.txtSaidaNFeEntrada);
            this.groupBox7.Controls.Add(this.btnEntradaNFeEntrada);
            this.groupBox7.Controls.Add(this.txtEntradaNFeEntrada);
            this.groupBox7.Location = new System.Drawing.Point(18, 116);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(656, 86);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Importação de NFe de Entrada";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(44, 53);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 13);
            this.label12.TabIndex = 45;
            this.label12.Text = "Saída";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(36, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 44;
            this.label10.Text = "Entrada";
            // 
            // btnSaidaNFeEntrada
            // 
            this.btnSaidaNFeEntrada.Location = new System.Drawing.Point(603, 48);
            this.btnSaidaNFeEntrada.Name = "btnSaidaNFeEntrada";
            this.btnSaidaNFeEntrada.Size = new System.Drawing.Size(37, 23);
            this.btnSaidaNFeEntrada.TabIndex = 43;
            this.btnSaidaNFeEntrada.Text = "...";
            this.btnSaidaNFeEntrada.UseVisualStyleBackColor = true;
            this.btnSaidaNFeEntrada.Click += new System.EventHandler(this.btnSaidaNFeEntrada_Click);
            // 
            // txtSaidaNFeEntrada
            // 
            this.txtSaidaNFeEntrada.Location = new System.Drawing.Point(83, 50);
            this.txtSaidaNFeEntrada.Name = "txtSaidaNFeEntrada";
            this.txtSaidaNFeEntrada.Size = new System.Drawing.Size(514, 20);
            this.txtSaidaNFeEntrada.TabIndex = 42;
            // 
            // btnEntradaNFeEntrada
            // 
            this.btnEntradaNFeEntrada.Location = new System.Drawing.Point(603, 19);
            this.btnEntradaNFeEntrada.Name = "btnEntradaNFeEntrada";
            this.btnEntradaNFeEntrada.Size = new System.Drawing.Size(37, 23);
            this.btnEntradaNFeEntrada.TabIndex = 41;
            this.btnEntradaNFeEntrada.Text = "...";
            this.btnEntradaNFeEntrada.UseVisualStyleBackColor = true;
            this.btnEntradaNFeEntrada.Click += new System.EventHandler(this.btnEntradaNFeEntrada_Click);
            // 
            // txtEntradaNFeEntrada
            // 
            this.txtEntradaNFeEntrada.Location = new System.Drawing.Point(83, 21);
            this.txtEntradaNFeEntrada.Name = "txtEntradaNFeEntrada";
            this.txtEntradaNFeEntrada.Size = new System.Drawing.Size(514, 20);
            this.txtEntradaNFeEntrada.TabIndex = 40;
            // 
            // btnSaidaArquivoDados
            // 
            this.btnSaidaArquivoDados.Location = new System.Drawing.Point(621, 43);
            this.btnSaidaArquivoDados.Name = "btnSaidaArquivoDados";
            this.btnSaidaArquivoDados.Size = new System.Drawing.Size(37, 23);
            this.btnSaidaArquivoDados.TabIndex = 1;
            this.btnSaidaArquivoDados.Text = "...";
            this.btnSaidaArquivoDados.UseVisualStyleBackColor = true;
            this.btnSaidaArquivoDados.Click += new System.EventHandler(this.btnCodigoBarras_Click);
            // 
            // txtDiretorioExportacaoCSV
            // 
            this.txtDiretorioExportacaoCSV.Location = new System.Drawing.Point(101, 43);
            this.txtDiretorioExportacaoCSV.Name = "txtDiretorioExportacaoCSV";
            this.txtDiretorioExportacaoCSV.Size = new System.Drawing.Size(514, 20);
            this.txtDiretorioExportacaoCSV.TabIndex = 0;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(15, 27);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(248, 13);
            this.label26.TabIndex = 37;
            this.label26.Text = "Local de Exportação dos Arquivos de Dados (CSV)";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtEstacaoAutomacao);
            this.tabPage3.Controls.Add(this.iwtLabel21);
            this.tabPage3.Controls.Add(this.groupBox18);
            this.tabPage3.Controls.Add(this.grbExportacaoContas);
            this.tabPage3.Controls.Add(this.chkExportacaoContas);
            this.tabPage3.Controls.Add(this.grbExportacaoPedidos);
            this.tabPage3.Controls.Add(this.chkExportacaoPedidos);
            this.tabPage3.Controls.Add(this.label20);
            this.tabPage3.Controls.Add(this.nudIntervaloImportacaoNFEntrada);
            this.tabPage3.Controls.Add(this.label22);
            this.tabPage3.Controls.Add(this.label21);
            this.tabPage3.Controls.Add(this.nudIntervaloImportacaoPedidos);
            this.tabPage3.Controls.Add(this.label19);
            this.tabPage3.Controls.Add(this.LimiteSessaonumericUpDown);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.label28);
            this.tabPage3.Controls.Add(this.nudDiasDuplicata);
            this.tabPage3.Controls.Add(this.label27);
            this.tabPage3.Controls.Add(this.nudPorcentagemCancelamentoSaldo);
            this.tabPage3.Controls.Add(this.label25);
            this.tabPage3.Controls.Add(this.nudSegundosConferencia);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(995, 487);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Automações / Timers";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtEstacaoAutomacao
            // 
            this.txtEstacaoAutomacao.BindingField = null;
            this.txtEstacaoAutomacao.DebugMode = false;
            this.txtEstacaoAutomacao.LiberadoQuandoCadastroUtilizado = false;
            this.txtEstacaoAutomacao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtEstacaoAutomacao.Location = new System.Drawing.Point(263, 436);
            this.txtEstacaoAutomacao.ModoBarcode = false;
            this.txtEstacaoAutomacao.ModoBusca = false;
            this.txtEstacaoAutomacao.Name = "txtEstacaoAutomacao";
            this.txtEstacaoAutomacao.NaoLimparDepoisBarcode = false;
            this.txtEstacaoAutomacao.Size = new System.Drawing.Size(368, 20);
            this.txtEstacaoAutomacao.TabIndex = 54;
            // 
            // iwtLabel21
            // 
            this.iwtLabel21.AutoSize = true;
            this.iwtLabel21.BindingField = null;
            this.iwtLabel21.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel21.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel21.Location = new System.Drawing.Point(12, 439);
            this.iwtLabel21.Name = "iwtLabel21";
            this.iwtLabel21.Size = new System.Drawing.Size(245, 13);
            this.iwtLabel21.TabIndex = 53;
            this.iwtLabel21.Text = "Estação Autorizada a rodar Módulo de Automação";
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.nudTabelaPrecosMinutos);
            this.groupBox18.Controls.Add(this.iwtLabel20);
            this.groupBox18.Controls.Add(this.nudTabelaPrecosHora);
            this.groupBox18.Controls.Add(this.iwtLabel19);
            this.groupBox18.Controls.Add(this.iwtRadioButton1);
            this.groupBox18.Controls.Add(this.rdbTabelaPrecosAutomatico);
            this.groupBox18.Location = new System.Drawing.Point(15, 327);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(328, 82);
            this.groupBox18.TabIndex = 52;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Tabela de Preços";
            // 
            // nudTabelaPrecosMinutos
            // 
            this.nudTabelaPrecosMinutos.BindingField = null;
            this.nudTabelaPrecosMinutos.Enabled = false;
            this.nudTabelaPrecosMinutos.LiberadoQuandoCadastroUtilizado = false;
            this.nudTabelaPrecosMinutos.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudTabelaPrecosMinutos.Location = new System.Drawing.Point(273, 46);
            this.nudTabelaPrecosMinutos.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nudTabelaPrecosMinutos.Name = "nudTabelaPrecosMinutos";
            this.nudTabelaPrecosMinutos.Size = new System.Drawing.Size(50, 20);
            this.nudTabelaPrecosMinutos.TabIndex = 4;
            // 
            // iwtLabel20
            // 
            this.iwtLabel20.AutoSize = true;
            this.iwtLabel20.BindingField = null;
            this.iwtLabel20.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel20.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel20.Location = new System.Drawing.Point(220, 50);
            this.iwtLabel20.Name = "iwtLabel20";
            this.iwtLabel20.Size = new System.Drawing.Size(47, 13);
            this.iwtLabel20.TabIndex = 3;
            this.iwtLabel20.Text = "Minutos:";
            // 
            // nudTabelaPrecosHora
            // 
            this.nudTabelaPrecosHora.BindingField = null;
            this.nudTabelaPrecosHora.Enabled = false;
            this.nudTabelaPrecosHora.LiberadoQuandoCadastroUtilizado = false;
            this.nudTabelaPrecosHora.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudTabelaPrecosHora.Location = new System.Drawing.Point(142, 46);
            this.nudTabelaPrecosHora.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.nudTabelaPrecosHora.Name = "nudTabelaPrecosHora";
            this.nudTabelaPrecosHora.Size = new System.Drawing.Size(50, 20);
            this.nudTabelaPrecosHora.TabIndex = 2;
            // 
            // iwtLabel19
            // 
            this.iwtLabel19.AutoSize = true;
            this.iwtLabel19.BindingField = null;
            this.iwtLabel19.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel19.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel19.Location = new System.Drawing.Point(103, 50);
            this.iwtLabel19.Name = "iwtLabel19";
            this.iwtLabel19.Size = new System.Drawing.Size(33, 13);
            this.iwtLabel19.TabIndex = 1;
            this.iwtLabel19.Text = "Hora:";
            // 
            // iwtRadioButton1
            // 
            this.iwtRadioButton1.AutoSize = true;
            this.iwtRadioButton1.BindingField = null;
            this.iwtRadioButton1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtRadioButton1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtRadioButton1.Location = new System.Drawing.Point(10, 46);
            this.iwtRadioButton1.Name = "iwtRadioButton1";
            this.iwtRadioButton1.Size = new System.Drawing.Size(74, 17);
            this.iwtRadioButton1.TabIndex = 0;
            this.iwtRadioButton1.Text = "Agendado";
            this.iwtRadioButton1.UseVisualStyleBackColor = true;
            // 
            // rdbTabelaPrecosAutomatico
            // 
            this.rdbTabelaPrecosAutomatico.AutoSize = true;
            this.rdbTabelaPrecosAutomatico.BindingField = null;
            this.rdbTabelaPrecosAutomatico.Checked = true;
            this.rdbTabelaPrecosAutomatico.LiberadoQuandoCadastroUtilizado = false;
            this.rdbTabelaPrecosAutomatico.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbTabelaPrecosAutomatico.Location = new System.Drawing.Point(10, 19);
            this.rdbTabelaPrecosAutomatico.Name = "rdbTabelaPrecosAutomatico";
            this.rdbTabelaPrecosAutomatico.Size = new System.Drawing.Size(78, 17);
            this.rdbTabelaPrecosAutomatico.TabIndex = 0;
            this.rdbTabelaPrecosAutomatico.TabStop = true;
            this.rdbTabelaPrecosAutomatico.Text = "Automático";
            this.rdbTabelaPrecosAutomatico.UseVisualStyleBackColor = true;
            this.rdbTabelaPrecosAutomatico.CheckedChanged += new System.EventHandler(this.rdbTabelaPrecosAutomatico_CheckedChanged);
            // 
            // grbExportacaoContas
            // 
            this.grbExportacaoContas.Controls.Add(this.label49);
            this.grbExportacaoContas.Controls.Add(this.label50);
            this.grbExportacaoContas.Controls.Add(this.nudExportacaoContasMinuto);
            this.grbExportacaoContas.Enabled = false;
            this.grbExportacaoContas.Location = new System.Drawing.Point(285, 251);
            this.grbExportacaoContas.Name = "grbExportacaoContas";
            this.grbExportacaoContas.Size = new System.Drawing.Size(151, 58);
            this.grbExportacaoContas.TabIndex = 51;
            this.grbExportacaoContas.TabStop = false;
            this.grbExportacaoContas.Text = "Exportação de Contas";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(13, 26);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(45, 13);
            this.label49.TabIndex = 43;
            this.label49.Text = "Período";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(122, 26);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(15, 13);
            this.label50.TabIndex = 47;
            this.label50.Text = "m";
            // 
            // nudExportacaoContasMinuto
            // 
            this.nudExportacaoContasMinuto.Location = new System.Drawing.Point(60, 19);
            this.nudExportacaoContasMinuto.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudExportacaoContasMinuto.Name = "nudExportacaoContasMinuto";
            this.nudExportacaoContasMinuto.Size = new System.Drawing.Size(61, 20);
            this.nudExportacaoContasMinuto.TabIndex = 45;
            // 
            // chkExportacaoContas
            // 
            this.chkExportacaoContas.AutoSize = true;
            this.chkExportacaoContas.Location = new System.Drawing.Point(442, 276);
            this.chkExportacaoContas.Name = "chkExportacaoContas";
            this.chkExportacaoContas.Size = new System.Drawing.Size(15, 14);
            this.chkExportacaoContas.TabIndex = 50;
            this.chkExportacaoContas.UseVisualStyleBackColor = true;
            this.chkExportacaoContas.CheckedChanged += new System.EventHandler(this.chkExportacaoContas_CheckedChanged);
            // 
            // grbExportacaoPedidos
            // 
            this.grbExportacaoPedidos.Controls.Add(this.label46);
            this.grbExportacaoPedidos.Controls.Add(this.label48);
            this.grbExportacaoPedidos.Controls.Add(this.nudExportacaoPedidosIntervalo);
            this.grbExportacaoPedidos.Enabled = false;
            this.grbExportacaoPedidos.Location = new System.Drawing.Point(25, 251);
            this.grbExportacaoPedidos.Name = "grbExportacaoPedidos";
            this.grbExportacaoPedidos.Size = new System.Drawing.Size(178, 58);
            this.grbExportacaoPedidos.TabIndex = 49;
            this.grbExportacaoPedidos.TabStop = false;
            this.grbExportacaoPedidos.Text = "Exportação de Pedidos";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(12, 26);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(45, 13);
            this.label46.TabIndex = 43;
            this.label46.Text = "Período";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(132, 26);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(15, 13);
            this.label48.TabIndex = 47;
            this.label48.Text = "m";
            // 
            // nudExportacaoPedidosIntervalo
            // 
            this.nudExportacaoPedidosIntervalo.Location = new System.Drawing.Point(60, 19);
            this.nudExportacaoPedidosIntervalo.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudExportacaoPedidosIntervalo.Name = "nudExportacaoPedidosIntervalo";
            this.nudExportacaoPedidosIntervalo.Size = new System.Drawing.Size(66, 20);
            this.nudExportacaoPedidosIntervalo.TabIndex = 45;
            // 
            // chkExportacaoPedidos
            // 
            this.chkExportacaoPedidos.AutoSize = true;
            this.chkExportacaoPedidos.Location = new System.Drawing.Point(209, 272);
            this.chkExportacaoPedidos.Name = "chkExportacaoPedidos";
            this.chkExportacaoPedidos.Size = new System.Drawing.Size(15, 14);
            this.chkExportacaoPedidos.TabIndex = 48;
            this.chkExportacaoPedidos.UseVisualStyleBackColor = true;
            this.chkExportacaoPedidos.CheckedChanged += new System.EventHandler(this.chkExportacaoPedidos_CheckedChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(286, 190);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(15, 13);
            this.label20.TabIndex = 42;
            this.label20.Text = "m";
            // 
            // nudIntervaloImportacaoNFEntrada
            // 
            this.nudIntervaloImportacaoNFEntrada.Location = new System.Drawing.Point(224, 183);
            this.nudIntervaloImportacaoNFEntrada.Maximum = new decimal(new int[] {
            1874919424,
            2328306,
            0,
            0});
            this.nudIntervaloImportacaoNFEntrada.Name = "nudIntervaloImportacaoNFEntrada";
            this.nudIntervaloImportacaoNFEntrada.Size = new System.Drawing.Size(61, 20);
            this.nudIntervaloImportacaoNFEntrada.TabIndex = 5;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(12, 186);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(211, 13);
            this.label22.TabIndex = 41;
            this.label22.Text = "Intervalo de Importação de NFs de Entrada";
            this.label22.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(286, 164);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(15, 13);
            this.label21.TabIndex = 39;
            this.label21.Text = "m";
            // 
            // nudIntervaloImportacaoPedidos
            // 
            this.nudIntervaloImportacaoPedidos.Location = new System.Drawing.Point(224, 157);
            this.nudIntervaloImportacaoPedidos.Maximum = new decimal(new int[] {
            1874919424,
            2328306,
            0,
            0});
            this.nudIntervaloImportacaoPedidos.Name = "nudIntervaloImportacaoPedidos";
            this.nudIntervaloImportacaoPedidos.Size = new System.Drawing.Size(61, 20);
            this.nudIntervaloImportacaoPedidos.TabIndex = 4;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(20, 160);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(203, 13);
            this.label19.TabIndex = 38;
            this.label19.Text = "Intervalo Geral de Importação de Pedidos";
            this.label19.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LimiteSessaonumericUpDown
            // 
            this.LimiteSessaonumericUpDown.Location = new System.Drawing.Point(224, 36);
            this.LimiteSessaonumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.LimiteSessaonumericUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.LimiteSessaonumericUpDown.Name = "LimiteSessaonumericUpDown";
            this.LimiteSessaonumericUpDown.Size = new System.Drawing.Size(61, 20);
            this.LimiteSessaonumericUpDown.TabIndex = 0;
            this.LimiteSessaonumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(28, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(195, 13);
            this.label11.TabIndex = 30;
            this.label11.Text = "Limite de Sessão Expedição (segundos)";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(12, 126);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(211, 30);
            this.label28.TabIndex = 29;
            this.label28.Text = "Dias Corridos para o Vencimento da Duplicata";
            this.label28.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // nudDiasDuplicata
            // 
            this.nudDiasDuplicata.Location = new System.Drawing.Point(224, 131);
            this.nudDiasDuplicata.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.nudDiasDuplicata.Name = "nudDiasDuplicata";
            this.nudDiasDuplicata.Size = new System.Drawing.Size(61, 20);
            this.nudDiasDuplicata.TabIndex = 3;
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(12, 92);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(211, 30);
            this.label27.TabIndex = 27;
            this.label27.Text = "Porcentagem permitida para Cancelar saldo (%)";
            this.label27.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // nudPorcentagemCancelamentoSaldo
            // 
            this.nudPorcentagemCancelamentoSaldo.Location = new System.Drawing.Point(224, 97);
            this.nudPorcentagemCancelamentoSaldo.Name = "nudPorcentagemCancelamentoSaldo";
            this.nudPorcentagemCancelamentoSaldo.Size = new System.Drawing.Size(61, 20);
            this.nudPorcentagemCancelamentoSaldo.TabIndex = 2;
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(12, 57);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(211, 30);
            this.label25.TabIndex = 25;
            this.label25.Text = "Segundos Disponíveis para a Conferência";
            this.label25.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // nudSegundosConferencia
            // 
            this.nudSegundosConferencia.Location = new System.Drawing.Point(224, 62);
            this.nudSegundosConferencia.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudSegundosConferencia.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSegundosConferencia.Name = "nudSegundosConferencia";
            this.nudSegundosConferencia.Size = new System.Drawing.Size(61, 20);
            this.nudSegundosConferencia.TabIndex = 1;
            this.nudSegundosConferencia.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox19);
            this.tabPage4.Controls.Add(this.groupBox10);
            this.tabPage4.Controls.Add(this.groupBox9);
            this.tabPage4.Controls.Add(this.grbEtiquetaExpedicao);
            this.tabPage4.Controls.Add(this.groupBox1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(995, 487);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Etiquetas";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.rdbEtiquetaProdutoVertical);
            this.groupBox19.Controls.Add(this.rdbEtiquetaProdutoHorizontal);
            this.groupBox19.Location = new System.Drawing.Point(8, 384);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(496, 52);
            this.groupBox19.TabIndex = 20;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "Tipo de Etiqueta Produtos";
            // 
            // rdbEtiquetaProdutoVertical
            // 
            this.rdbEtiquetaProdutoVertical.AutoSize = true;
            this.rdbEtiquetaProdutoVertical.Location = new System.Drawing.Point(170, 19);
            this.rdbEtiquetaProdutoVertical.Name = "rdbEtiquetaProdutoVertical";
            this.rdbEtiquetaProdutoVertical.Size = new System.Drawing.Size(144, 17);
            this.rdbEtiquetaProdutoVertical.TabIndex = 1;
            this.rdbEtiquetaProdutoVertical.Text = "Código de Barras Vertical";
            this.rdbEtiquetaProdutoVertical.UseVisualStyleBackColor = true;
            // 
            // rdbEtiquetaProdutoHorizontal
            // 
            this.rdbEtiquetaProdutoHorizontal.AutoSize = true;
            this.rdbEtiquetaProdutoHorizontal.Checked = true;
            this.rdbEtiquetaProdutoHorizontal.Location = new System.Drawing.Point(8, 19);
            this.rdbEtiquetaProdutoHorizontal.Name = "rdbEtiquetaProdutoHorizontal";
            this.rdbEtiquetaProdutoHorizontal.Size = new System.Drawing.Size(156, 17);
            this.rdbEtiquetaProdutoHorizontal.TabIndex = 0;
            this.rdbEtiquetaProdutoHorizontal.TabStop = true;
            this.rdbEtiquetaProdutoHorizontal.Text = "Código de Barras Horizontal";
            this.rdbEtiquetaProdutoHorizontal.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.rdbEtiquetaPequenaRecebimento);
            this.groupBox10.Controls.Add(this.rdbEtiquetaMediaRecebimento);
            this.groupBox10.Location = new System.Drawing.Point(8, 324);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(496, 54);
            this.groupBox10.TabIndex = 19;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Tipo de Etiqueta de Recebimento";
            // 
            // rdbEtiquetaPequenaRecebimento
            // 
            this.rdbEtiquetaPequenaRecebimento.AutoSize = true;
            this.rdbEtiquetaPequenaRecebimento.Location = new System.Drawing.Point(114, 23);
            this.rdbEtiquetaPequenaRecebimento.Name = "rdbEtiquetaPequenaRecebimento";
            this.rdbEtiquetaPequenaRecebimento.Size = new System.Drawing.Size(110, 17);
            this.rdbEtiquetaPequenaRecebimento.TabIndex = 2;
            this.rdbEtiquetaPequenaRecebimento.Text = "Etiqueta Pequena";
            this.rdbEtiquetaPequenaRecebimento.UseVisualStyleBackColor = true;
            // 
            // rdbEtiquetaMediaRecebimento
            // 
            this.rdbEtiquetaMediaRecebimento.AutoSize = true;
            this.rdbEtiquetaMediaRecebimento.Checked = true;
            this.rdbEtiquetaMediaRecebimento.Location = new System.Drawing.Point(8, 23);
            this.rdbEtiquetaMediaRecebimento.Name = "rdbEtiquetaMediaRecebimento";
            this.rdbEtiquetaMediaRecebimento.Size = new System.Drawing.Size(96, 17);
            this.rdbEtiquetaMediaRecebimento.TabIndex = 1;
            this.rdbEtiquetaMediaRecebimento.TabStop = true;
            this.rdbEtiquetaMediaRecebimento.Text = "Etiqueta Média";
            this.rdbEtiquetaMediaRecebimento.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.rdbEtiquetaPequena);
            this.groupBox9.Controls.Add(this.rdbEtiquetaMedia);
            this.groupBox9.Controls.Add(this.rdbEtiquetaGrande);
            this.groupBox9.Location = new System.Drawing.Point(8, 264);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(496, 54);
            this.groupBox9.TabIndex = 18;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Tipo de Etiqueta de Expedição";
            // 
            // rdbEtiquetaPequena
            // 
            this.rdbEtiquetaPequena.AutoSize = true;
            this.rdbEtiquetaPequena.Location = new System.Drawing.Point(216, 23);
            this.rdbEtiquetaPequena.Name = "rdbEtiquetaPequena";
            this.rdbEtiquetaPequena.Size = new System.Drawing.Size(110, 17);
            this.rdbEtiquetaPequena.TabIndex = 2;
            this.rdbEtiquetaPequena.Text = "Etiqueta Pequena";
            this.rdbEtiquetaPequena.UseVisualStyleBackColor = true;
            // 
            // rdbEtiquetaMedia
            // 
            this.rdbEtiquetaMedia.AutoSize = true;
            this.rdbEtiquetaMedia.Location = new System.Drawing.Point(114, 23);
            this.rdbEtiquetaMedia.Name = "rdbEtiquetaMedia";
            this.rdbEtiquetaMedia.Size = new System.Drawing.Size(96, 17);
            this.rdbEtiquetaMedia.TabIndex = 1;
            this.rdbEtiquetaMedia.Text = "Etiqueta Média";
            this.rdbEtiquetaMedia.UseVisualStyleBackColor = true;
            this.rdbEtiquetaMedia.CheckedChanged += new System.EventHandler(this.rdbEtiquetaMedia_CheckedChanged);
            // 
            // rdbEtiquetaGrande
            // 
            this.rdbEtiquetaGrande.AutoSize = true;
            this.rdbEtiquetaGrande.Checked = true;
            this.rdbEtiquetaGrande.Location = new System.Drawing.Point(6, 23);
            this.rdbEtiquetaGrande.Name = "rdbEtiquetaGrande";
            this.rdbEtiquetaGrande.Size = new System.Drawing.Size(102, 17);
            this.rdbEtiquetaGrande.TabIndex = 0;
            this.rdbEtiquetaGrande.TabStop = true;
            this.rdbEtiquetaGrande.Text = "Etiqueta Grande";
            this.rdbEtiquetaGrande.UseVisualStyleBackColor = true;
            this.rdbEtiquetaGrande.CheckedChanged += new System.EventHandler(this.rdbEtiquetaGrande_CheckedChanged);
            // 
            // grbEtiquetaExpedicao
            // 
            this.grbEtiquetaExpedicao.Controls.Add(this.cmbPapelExpedicao);
            this.grbEtiquetaExpedicao.Controls.Add(this.cmbImpressoraExpedicao);
            this.grbEtiquetaExpedicao.Controls.Add(this.label29);
            this.grbEtiquetaExpedicao.Controls.Add(this.label32);
            this.grbEtiquetaExpedicao.Location = new System.Drawing.Point(8, 140);
            this.grbEtiquetaExpedicao.Name = "grbEtiquetaExpedicao";
            this.grbEtiquetaExpedicao.Size = new System.Drawing.Size(496, 118);
            this.grbEtiquetaExpedicao.TabIndex = 17;
            this.grbEtiquetaExpedicao.TabStop = false;
            this.grbEtiquetaExpedicao.Text = "Etiqueta Expedição (10,8 cm x 18,9 cm)";
            // 
            // cmbPapelExpedicao
            // 
            this.cmbPapelExpedicao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPapelExpedicao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPapelExpedicao.Enabled = false;
            this.cmbPapelExpedicao.FormattingEnabled = true;
            this.cmbPapelExpedicao.Location = new System.Drawing.Point(26, 82);
            this.cmbPapelExpedicao.Name = "cmbPapelExpedicao";
            this.cmbPapelExpedicao.Size = new System.Drawing.Size(446, 21);
            this.cmbPapelExpedicao.TabIndex = 16;
            // 
            // cmbImpressoraExpedicao
            // 
            this.cmbImpressoraExpedicao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbImpressoraExpedicao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbImpressoraExpedicao.FormattingEnabled = true;
            this.cmbImpressoraExpedicao.Location = new System.Drawing.Point(26, 32);
            this.cmbImpressoraExpedicao.Name = "cmbImpressoraExpedicao";
            this.cmbImpressoraExpedicao.Size = new System.Drawing.Size(446, 21);
            this.cmbImpressoraExpedicao.TabIndex = 15;
            this.cmbImpressoraExpedicao.SelectedIndexChanged += new System.EventHandler(this.cmbImpressoraExpedicao_SelectedIndexChanged);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(10, 66);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(80, 13);
            this.label29.TabIndex = 14;
            this.label29.Text = "Nome do Papel";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(10, 16);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(104, 13);
            this.label32.TabIndex = 13;
            this.label32.Text = "Nome da Impressora";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbPapelInterno);
            this.groupBox1.Controls.Add(this.cmbImpressoraInterna);
            this.groupBox1.Controls.Add(this.label30);
            this.groupBox1.Controls.Add(this.label31);
            this.groupBox1.Location = new System.Drawing.Point(8, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(496, 118);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Etiqueta Interna (8 cm x 3,3 cm)";
            // 
            // cmbPapelInterno
            // 
            this.cmbPapelInterno.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPapelInterno.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPapelInterno.Enabled = false;
            this.cmbPapelInterno.FormattingEnabled = true;
            this.cmbPapelInterno.Location = new System.Drawing.Point(26, 82);
            this.cmbPapelInterno.Name = "cmbPapelInterno";
            this.cmbPapelInterno.Size = new System.Drawing.Size(446, 21);
            this.cmbPapelInterno.TabIndex = 16;
            // 
            // cmbImpressoraInterna
            // 
            this.cmbImpressoraInterna.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbImpressoraInterna.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbImpressoraInterna.FormattingEnabled = true;
            this.cmbImpressoraInterna.Location = new System.Drawing.Point(26, 32);
            this.cmbImpressoraInterna.Name = "cmbImpressoraInterna";
            this.cmbImpressoraInterna.Size = new System.Drawing.Size(446, 21);
            this.cmbImpressoraInterna.TabIndex = 15;
            this.cmbImpressoraInterna.SelectedIndexChanged += new System.EventHandler(this.cmbImpressoraInterna_SelectedIndexChanged);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(10, 66);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(80, 13);
            this.label30.TabIndex = 14;
            this.label30.Text = "Nome do Papel";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(10, 16);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(104, 13);
            this.label31.TabIndex = 13;
            this.label31.Text = "Nome da Impressora";
            // 
            // tabPage14
            // 
            this.tabPage14.Controls.Add(this.rdbEtiquetaClienteComum);
            this.tabPage14.Controls.Add(this.rdbEtiquetaClienteZebra);
            this.tabPage14.Controls.Add(this.grbEtiquetaClienteComum);
            this.tabPage14.Controls.Add(this.grbEtiquetaClienteZebra);
            this.tabPage14.Location = new System.Drawing.Point(4, 22);
            this.tabPage14.Name = "tabPage14";
            this.tabPage14.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage14.Size = new System.Drawing.Size(995, 487);
            this.tabPage14.TabIndex = 14;
            this.tabPage14.Text = "Etiqueta de Clientes";
            this.tabPage14.UseVisualStyleBackColor = true;
            // 
            // rdbEtiquetaClienteComum
            // 
            this.rdbEtiquetaClienteComum.AutoSize = true;
            this.rdbEtiquetaClienteComum.Location = new System.Drawing.Point(958, 286);
            this.rdbEtiquetaClienteComum.Name = "rdbEtiquetaClienteComum";
            this.rdbEtiquetaClienteComum.Size = new System.Drawing.Size(14, 13);
            this.rdbEtiquetaClienteComum.TabIndex = 3;
            this.rdbEtiquetaClienteComum.UseVisualStyleBackColor = true;
            this.rdbEtiquetaClienteComum.CheckedChanged += new System.EventHandler(this.rdbEtiquetaClienteComum_CheckedChanged);
            // 
            // rdbEtiquetaClienteZebra
            // 
            this.rdbEtiquetaClienteZebra.AutoSize = true;
            this.rdbEtiquetaClienteZebra.Checked = true;
            this.rdbEtiquetaClienteZebra.Location = new System.Drawing.Point(958, 80);
            this.rdbEtiquetaClienteZebra.Name = "rdbEtiquetaClienteZebra";
            this.rdbEtiquetaClienteZebra.Size = new System.Drawing.Size(14, 13);
            this.rdbEtiquetaClienteZebra.TabIndex = 2;
            this.rdbEtiquetaClienteZebra.TabStop = true;
            this.rdbEtiquetaClienteZebra.UseVisualStyleBackColor = true;
            this.rdbEtiquetaClienteZebra.CheckedChanged += new System.EventHandler(this.rdbEtiquetaClienteZebra_CheckedChanged);
            // 
            // grbEtiquetaClienteComum
            // 
            this.grbEtiquetaClienteComum.Controls.Add(this.groupBox16);
            this.grbEtiquetaClienteComum.Controls.Add(this.groupBox17);
            this.grbEtiquetaClienteComum.Controls.Add(this.nudResolucao);
            this.grbEtiquetaClienteComum.Controls.Add(this.iwtLabel16);
            this.grbEtiquetaClienteComum.Location = new System.Drawing.Point(8, 157);
            this.grbEtiquetaClienteComum.Name = "grbEtiquetaClienteComum";
            this.grbEtiquetaClienteComum.Size = new System.Drawing.Size(944, 270);
            this.grbEtiquetaClienteComum.TabIndex = 1;
            this.grbEtiquetaClienteComum.TabStop = false;
            this.grbEtiquetaClienteComum.Text = "Impressora Comum";
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.nudEtiquetaAltura);
            this.groupBox16.Controls.Add(this.nudEtiquetaLinhas);
            this.groupBox16.Controls.Add(this.iwtLabel8);
            this.groupBox16.Controls.Add(this.iwtLabel9);
            this.groupBox16.Controls.Add(this.iwtLabel10);
            this.groupBox16.Controls.Add(this.nudEtiquetaColunas);
            this.groupBox16.Controls.Add(this.nudEtiquetaLargura);
            this.groupBox16.Controls.Add(this.iwtLabel11);
            this.groupBox16.Controls.Add(this.nudEtiquetaIntervaloVertical);
            this.groupBox16.Controls.Add(this.nudEtiquetaIntervaloHorizontal);
            this.groupBox16.Controls.Add(this.iwtLabel12);
            this.groupBox16.Controls.Add(this.iwtLabel13);
            this.groupBox16.Location = new System.Drawing.Point(18, 157);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(484, 100);
            this.groupBox16.TabIndex = 8;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Etiqueta";
            // 
            // nudEtiquetaAltura
            // 
            this.nudEtiquetaAltura.BindingField = null;
            this.nudEtiquetaAltura.DecimalPlaces = 2;
            this.nudEtiquetaAltura.LiberadoQuandoCadastroUtilizado = false;
            this.nudEtiquetaAltura.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudEtiquetaAltura.Location = new System.Drawing.Point(134, 19);
            this.nudEtiquetaAltura.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudEtiquetaAltura.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudEtiquetaAltura.Name = "nudEtiquetaAltura";
            this.nudEtiquetaAltura.Size = new System.Drawing.Size(89, 20);
            this.nudEtiquetaAltura.TabIndex = 0;
            this.nudEtiquetaAltura.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudEtiquetaLinhas
            // 
            this.nudEtiquetaLinhas.BindingField = null;
            this.nudEtiquetaLinhas.LiberadoQuandoCadastroUtilizado = false;
            this.nudEtiquetaLinhas.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudEtiquetaLinhas.Location = new System.Drawing.Point(369, 71);
            this.nudEtiquetaLinhas.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudEtiquetaLinhas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudEtiquetaLinhas.Name = "nudEtiquetaLinhas";
            this.nudEtiquetaLinhas.Size = new System.Drawing.Size(89, 20);
            this.nudEtiquetaLinhas.TabIndex = 5;
            this.nudEtiquetaLinhas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // iwtLabel8
            // 
            this.iwtLabel8.AutoSize = true;
            this.iwtLabel8.BindingField = null;
            this.iwtLabel8.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel8.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel8.Location = new System.Drawing.Point(69, 21);
            this.iwtLabel8.Name = "iwtLabel8";
            this.iwtLabel8.Size = new System.Drawing.Size(59, 13);
            this.iwtLabel8.TabIndex = 26;
            this.iwtLabel8.Text = "Altura (mm)";
            // 
            // iwtLabel9
            // 
            this.iwtLabel9.AutoSize = true;
            this.iwtLabel9.BindingField = null;
            this.iwtLabel9.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel9.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel9.Location = new System.Drawing.Point(275, 73);
            this.iwtLabel9.Name = "iwtLabel9";
            this.iwtLabel9.Size = new System.Drawing.Size(88, 13);
            this.iwtLabel9.TabIndex = 23;
            this.iwtLabel9.Text = "Linhas p/ Página";
            // 
            // iwtLabel10
            // 
            this.iwtLabel10.AutoSize = true;
            this.iwtLabel10.BindingField = null;
            this.iwtLabel10.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel10.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel10.Location = new System.Drawing.Point(295, 21);
            this.iwtLabel10.Name = "iwtLabel10";
            this.iwtLabel10.Size = new System.Drawing.Size(68, 13);
            this.iwtLabel10.TabIndex = 22;
            this.iwtLabel10.Text = "Largura (mm)";
            // 
            // nudEtiquetaColunas
            // 
            this.nudEtiquetaColunas.BindingField = null;
            this.nudEtiquetaColunas.LiberadoQuandoCadastroUtilizado = false;
            this.nudEtiquetaColunas.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudEtiquetaColunas.Location = new System.Drawing.Point(134, 71);
            this.nudEtiquetaColunas.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudEtiquetaColunas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudEtiquetaColunas.Name = "nudEtiquetaColunas";
            this.nudEtiquetaColunas.Size = new System.Drawing.Size(89, 20);
            this.nudEtiquetaColunas.TabIndex = 4;
            this.nudEtiquetaColunas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudEtiquetaLargura
            // 
            this.nudEtiquetaLargura.BindingField = null;
            this.nudEtiquetaLargura.DecimalPlaces = 2;
            this.nudEtiquetaLargura.LiberadoQuandoCadastroUtilizado = false;
            this.nudEtiquetaLargura.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudEtiquetaLargura.Location = new System.Drawing.Point(369, 19);
            this.nudEtiquetaLargura.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudEtiquetaLargura.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudEtiquetaLargura.Name = "nudEtiquetaLargura";
            this.nudEtiquetaLargura.Size = new System.Drawing.Size(89, 20);
            this.nudEtiquetaLargura.TabIndex = 1;
            this.nudEtiquetaLargura.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // iwtLabel11
            // 
            this.iwtLabel11.AutoSize = true;
            this.iwtLabel11.BindingField = null;
            this.iwtLabel11.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel11.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel11.Location = new System.Drawing.Point(37, 73);
            this.iwtLabel11.Name = "iwtLabel11";
            this.iwtLabel11.Size = new System.Drawing.Size(91, 13);
            this.iwtLabel11.TabIndex = 20;
            this.iwtLabel11.Text = "Quantida Colunas";
            // 
            // nudEtiquetaIntervaloVertical
            // 
            this.nudEtiquetaIntervaloVertical.BindingField = null;
            this.nudEtiquetaIntervaloVertical.DecimalPlaces = 2;
            this.nudEtiquetaIntervaloVertical.LiberadoQuandoCadastroUtilizado = false;
            this.nudEtiquetaIntervaloVertical.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudEtiquetaIntervaloVertical.Location = new System.Drawing.Point(134, 45);
            this.nudEtiquetaIntervaloVertical.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudEtiquetaIntervaloVertical.Name = "nudEtiquetaIntervaloVertical";
            this.nudEtiquetaIntervaloVertical.Size = new System.Drawing.Size(89, 20);
            this.nudEtiquetaIntervaloVertical.TabIndex = 2;
            // 
            // nudEtiquetaIntervaloHorizontal
            // 
            this.nudEtiquetaIntervaloHorizontal.BindingField = null;
            this.nudEtiquetaIntervaloHorizontal.DecimalPlaces = 2;
            this.nudEtiquetaIntervaloHorizontal.LiberadoQuandoCadastroUtilizado = false;
            this.nudEtiquetaIntervaloHorizontal.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudEtiquetaIntervaloHorizontal.Location = new System.Drawing.Point(369, 45);
            this.nudEtiquetaIntervaloHorizontal.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudEtiquetaIntervaloHorizontal.Name = "nudEtiquetaIntervaloHorizontal";
            this.nudEtiquetaIntervaloHorizontal.Size = new System.Drawing.Size(89, 20);
            this.nudEtiquetaIntervaloHorizontal.TabIndex = 3;
            // 
            // iwtLabel12
            // 
            this.iwtLabel12.AutoSize = true;
            this.iwtLabel12.BindingField = null;
            this.iwtLabel12.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel12.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel12.Location = new System.Drawing.Point(17, 47);
            this.iwtLabel12.Name = "iwtLabel12";
            this.iwtLabel12.Size = new System.Drawing.Size(111, 13);
            this.iwtLabel12.TabIndex = 16;
            this.iwtLabel12.Text = "Intervalo Vertical (mm)";
            // 
            // iwtLabel13
            // 
            this.iwtLabel13.AutoSize = true;
            this.iwtLabel13.BindingField = null;
            this.iwtLabel13.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel13.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel13.Location = new System.Drawing.Point(240, 47);
            this.iwtLabel13.Name = "iwtLabel13";
            this.iwtLabel13.Size = new System.Drawing.Size(123, 13);
            this.iwtLabel13.TabIndex = 18;
            this.iwtLabel13.Text = "Intervalo Horizontal (mm)";
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.nudPapelAltura);
            this.groupBox17.Controls.Add(this.nudPapelMargemDireita);
            this.groupBox17.Controls.Add(this.iwtLabel4);
            this.groupBox17.Controls.Add(this.iwtLabel7);
            this.groupBox17.Controls.Add(this.iwtLabel6);
            this.groupBox17.Controls.Add(this.nudPapelMargemInferior);
            this.groupBox17.Controls.Add(this.nudPapelLargura);
            this.groupBox17.Controls.Add(this.iwtLabel5);
            this.groupBox17.Controls.Add(this.nudPapelMargemSuperior);
            this.groupBox17.Controls.Add(this.nudPapelMargemEsquerda);
            this.groupBox17.Controls.Add(this.iwtLabel14);
            this.groupBox17.Controls.Add(this.iwtLabel15);
            this.groupBox17.Location = new System.Drawing.Point(18, 51);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(484, 100);
            this.groupBox17.TabIndex = 7;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Papel";
            // 
            // nudPapelAltura
            // 
            this.nudPapelAltura.BindingField = null;
            this.nudPapelAltura.DecimalPlaces = 2;
            this.nudPapelAltura.LiberadoQuandoCadastroUtilizado = false;
            this.nudPapelAltura.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudPapelAltura.Location = new System.Drawing.Point(134, 23);
            this.nudPapelAltura.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPapelAltura.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPapelAltura.Name = "nudPapelAltura";
            this.nudPapelAltura.Size = new System.Drawing.Size(89, 20);
            this.nudPapelAltura.TabIndex = 0;
            this.nudPapelAltura.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudPapelMargemDireita
            // 
            this.nudPapelMargemDireita.BindingField = null;
            this.nudPapelMargemDireita.DecimalPlaces = 2;
            this.nudPapelMargemDireita.LiberadoQuandoCadastroUtilizado = false;
            this.nudPapelMargemDireita.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudPapelMargemDireita.Location = new System.Drawing.Point(369, 75);
            this.nudPapelMargemDireita.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPapelMargemDireita.Name = "nudPapelMargemDireita";
            this.nudPapelMargemDireita.Size = new System.Drawing.Size(89, 20);
            this.nudPapelMargemDireita.TabIndex = 5;
            // 
            // iwtLabel4
            // 
            this.iwtLabel4.AutoSize = true;
            this.iwtLabel4.BindingField = null;
            this.iwtLabel4.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel4.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel4.Location = new System.Drawing.Point(69, 25);
            this.iwtLabel4.Name = "iwtLabel4";
            this.iwtLabel4.Size = new System.Drawing.Size(59, 13);
            this.iwtLabel4.TabIndex = 14;
            this.iwtLabel4.Text = "Altura (mm)";
            // 
            // iwtLabel7
            // 
            this.iwtLabel7.AutoSize = true;
            this.iwtLabel7.BindingField = null;
            this.iwtLabel7.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel7.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel7.Location = new System.Drawing.Point(260, 77);
            this.iwtLabel7.Name = "iwtLabel7";
            this.iwtLabel7.Size = new System.Drawing.Size(103, 13);
            this.iwtLabel7.TabIndex = 12;
            this.iwtLabel7.Text = "Margem Direita (mm)";
            // 
            // iwtLabel6
            // 
            this.iwtLabel6.AutoSize = true;
            this.iwtLabel6.BindingField = null;
            this.iwtLabel6.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel6.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel6.Location = new System.Drawing.Point(295, 25);
            this.iwtLabel6.Name = "iwtLabel6";
            this.iwtLabel6.Size = new System.Drawing.Size(68, 13);
            this.iwtLabel6.TabIndex = 12;
            this.iwtLabel6.Text = "Largura (mm)";
            // 
            // nudPapelMargemInferior
            // 
            this.nudPapelMargemInferior.BindingField = null;
            this.nudPapelMargemInferior.DecimalPlaces = 2;
            this.nudPapelMargemInferior.LiberadoQuandoCadastroUtilizado = false;
            this.nudPapelMargemInferior.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudPapelMargemInferior.Location = new System.Drawing.Point(134, 75);
            this.nudPapelMargemInferior.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPapelMargemInferior.Name = "nudPapelMargemInferior";
            this.nudPapelMargemInferior.Size = new System.Drawing.Size(89, 20);
            this.nudPapelMargemInferior.TabIndex = 4;
            // 
            // nudPapelLargura
            // 
            this.nudPapelLargura.BindingField = null;
            this.nudPapelLargura.DecimalPlaces = 2;
            this.nudPapelLargura.LiberadoQuandoCadastroUtilizado = false;
            this.nudPapelLargura.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudPapelLargura.Location = new System.Drawing.Point(369, 23);
            this.nudPapelLargura.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPapelLargura.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPapelLargura.Name = "nudPapelLargura";
            this.nudPapelLargura.Size = new System.Drawing.Size(89, 20);
            this.nudPapelLargura.TabIndex = 1;
            this.nudPapelLargura.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // iwtLabel5
            // 
            this.iwtLabel5.AutoSize = true;
            this.iwtLabel5.BindingField = null;
            this.iwtLabel5.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel5.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel5.Location = new System.Drawing.Point(23, 77);
            this.iwtLabel5.Name = "iwtLabel5";
            this.iwtLabel5.Size = new System.Drawing.Size(105, 13);
            this.iwtLabel5.TabIndex = 10;
            this.iwtLabel5.Text = "Margem Inferior (mm)";
            // 
            // nudPapelMargemSuperior
            // 
            this.nudPapelMargemSuperior.BindingField = null;
            this.nudPapelMargemSuperior.DecimalPlaces = 2;
            this.nudPapelMargemSuperior.LiberadoQuandoCadastroUtilizado = false;
            this.nudPapelMargemSuperior.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudPapelMargemSuperior.Location = new System.Drawing.Point(134, 49);
            this.nudPapelMargemSuperior.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPapelMargemSuperior.Name = "nudPapelMargemSuperior";
            this.nudPapelMargemSuperior.Size = new System.Drawing.Size(89, 20);
            this.nudPapelMargemSuperior.TabIndex = 2;
            // 
            // nudPapelMargemEsquerda
            // 
            this.nudPapelMargemEsquerda.BindingField = null;
            this.nudPapelMargemEsquerda.DecimalPlaces = 2;
            this.nudPapelMargemEsquerda.LiberadoQuandoCadastroUtilizado = false;
            this.nudPapelMargemEsquerda.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudPapelMargemEsquerda.Location = new System.Drawing.Point(369, 49);
            this.nudPapelMargemEsquerda.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPapelMargemEsquerda.Name = "nudPapelMargemEsquerda";
            this.nudPapelMargemEsquerda.Size = new System.Drawing.Size(89, 20);
            this.nudPapelMargemEsquerda.TabIndex = 3;
            // 
            // iwtLabel14
            // 
            this.iwtLabel14.AutoSize = true;
            this.iwtLabel14.BindingField = null;
            this.iwtLabel14.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel14.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel14.Location = new System.Drawing.Point(16, 51);
            this.iwtLabel14.Name = "iwtLabel14";
            this.iwtLabel14.Size = new System.Drawing.Size(112, 13);
            this.iwtLabel14.TabIndex = 6;
            this.iwtLabel14.Text = "Margem Superior (mm)";
            // 
            // iwtLabel15
            // 
            this.iwtLabel15.AutoSize = true;
            this.iwtLabel15.BindingField = null;
            this.iwtLabel15.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel15.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel15.Location = new System.Drawing.Point(245, 51);
            this.iwtLabel15.Name = "iwtLabel15";
            this.iwtLabel15.Size = new System.Drawing.Size(118, 13);
            this.iwtLabel15.TabIndex = 8;
            this.iwtLabel15.Text = "Margem Esquerda (mm)";
            // 
            // nudResolucao
            // 
            this.nudResolucao.BindingField = null;
            this.nudResolucao.LiberadoQuandoCadastroUtilizado = false;
            this.nudResolucao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudResolucao.Location = new System.Drawing.Point(128, 25);
            this.nudResolucao.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudResolucao.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nudResolucao.Name = "nudResolucao";
            this.nudResolucao.Size = new System.Drawing.Size(89, 20);
            this.nudResolucao.TabIndex = 6;
            this.nudResolucao.Value = new decimal(new int[] {
            203,
            0,
            0,
            0});
            // 
            // iwtLabel16
            // 
            this.iwtLabel16.AutoSize = true;
            this.iwtLabel16.BindingField = null;
            this.iwtLabel16.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel16.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel16.Location = new System.Drawing.Point(19, 27);
            this.iwtLabel16.Name = "iwtLabel16";
            this.iwtLabel16.Size = new System.Drawing.Size(81, 13);
            this.iwtLabel16.TabIndex = 9;
            this.iwtLabel16.Text = "Resolução (dpi)";
            // 
            // grbEtiquetaClienteZebra
            // 
            this.grbEtiquetaClienteZebra.Controls.Add(this.cmbEtiquetaClientePapel);
            this.grbEtiquetaClienteZebra.Controls.Add(this.cmbEtiquetaClienteImpressora);
            this.grbEtiquetaClienteZebra.Controls.Add(this.label64);
            this.grbEtiquetaClienteZebra.Controls.Add(this.label65);
            this.grbEtiquetaClienteZebra.Location = new System.Drawing.Point(8, 22);
            this.grbEtiquetaClienteZebra.Name = "grbEtiquetaClienteZebra";
            this.grbEtiquetaClienteZebra.Size = new System.Drawing.Size(944, 129);
            this.grbEtiquetaClienteZebra.TabIndex = 0;
            this.grbEtiquetaClienteZebra.TabStop = false;
            this.grbEtiquetaClienteZebra.Text = "Impressora de Etiquetas";
            // 
            // cmbEtiquetaClientePapel
            // 
            this.cmbEtiquetaClientePapel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbEtiquetaClientePapel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbEtiquetaClientePapel.FormattingEnabled = true;
            this.cmbEtiquetaClientePapel.Location = new System.Drawing.Point(22, 90);
            this.cmbEtiquetaClientePapel.Name = "cmbEtiquetaClientePapel";
            this.cmbEtiquetaClientePapel.Size = new System.Drawing.Size(916, 21);
            this.cmbEtiquetaClientePapel.TabIndex = 20;
            // 
            // cmbEtiquetaClienteImpressora
            // 
            this.cmbEtiquetaClienteImpressora.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbEtiquetaClienteImpressora.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbEtiquetaClienteImpressora.FormattingEnabled = true;
            this.cmbEtiquetaClienteImpressora.Location = new System.Drawing.Point(22, 40);
            this.cmbEtiquetaClienteImpressora.Name = "cmbEtiquetaClienteImpressora";
            this.cmbEtiquetaClienteImpressora.Size = new System.Drawing.Size(916, 21);
            this.cmbEtiquetaClienteImpressora.TabIndex = 19;
            this.cmbEtiquetaClienteImpressora.SelectedIndexChanged += new System.EventHandler(this.cmbEtiquetaClienteImpressora_SelectedIndexChanged);
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(6, 74);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(80, 13);
            this.label64.TabIndex = 18;
            this.label64.Text = "Nome do Papel";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(6, 24);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(104, 13);
            this.label65.TabIndex = 17;
            this.label65.Text = "Nome da Impressora";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.chkDestinatarioConfiguracaoAutomatica);
            this.tabPage6.Controls.Add(this.grbDestinatarioConfiguracaoAutomatica);
            this.tabPage6.Controls.Add(this.chkEnvioOrcamentoDestInterno);
            this.tabPage6.Controls.Add(this.chkEnvioPedidoDestInterno);
            this.tabPage6.Controls.Add(this.grpDestInternoPedido);
            this.tabPage6.Controls.Add(this.grpDestInternoOrcamento);
            this.tabPage6.Controls.Add(this.groupBox2);
            this.tabPage6.Controls.Add(this.groupBox8);
            this.tabPage6.Controls.Add(this.chkAvisoEmissaoNF);
            this.tabPage6.Controls.Add(this.grbAvisoEmissaoNF);
            this.tabPage6.Controls.Add(this.groupBox3);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(995, 487);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Notificações de Email";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // chkDestinatarioConfiguracaoAutomatica
            // 
            this.chkDestinatarioConfiguracaoAutomatica.AutoSize = true;
            this.chkDestinatarioConfiguracaoAutomatica.Checked = true;
            this.chkDestinatarioConfiguracaoAutomatica.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDestinatarioConfiguracaoAutomatica.Location = new System.Drawing.Point(501, 433);
            this.chkDestinatarioConfiguracaoAutomatica.Name = "chkDestinatarioConfiguracaoAutomatica";
            this.chkDestinatarioConfiguracaoAutomatica.Size = new System.Drawing.Size(15, 14);
            this.chkDestinatarioConfiguracaoAutomatica.TabIndex = 18;
            this.chkDestinatarioConfiguracaoAutomatica.UseVisualStyleBackColor = true;
            this.chkDestinatarioConfiguracaoAutomatica.CheckedChanged += new System.EventHandler(this.chkDestinatarioConfiguracaoAutomatica_CheckedChanged);
            // 
            // grbDestinatarioConfiguracaoAutomatica
            // 
            this.grbDestinatarioConfiguracaoAutomatica.Controls.Add(this.txtDestinatarioConfiguracaoAutomatica);
            this.grbDestinatarioConfiguracaoAutomatica.Controls.Add(this.label66);
            this.grbDestinatarioConfiguracaoAutomatica.Location = new System.Drawing.Point(17, 414);
            this.grbDestinatarioConfiguracaoAutomatica.Name = "grbDestinatarioConfiguracaoAutomatica";
            this.grbDestinatarioConfiguracaoAutomatica.Size = new System.Drawing.Size(478, 50);
            this.grbDestinatarioConfiguracaoAutomatica.TabIndex = 17;
            this.grbDestinatarioConfiguracaoAutomatica.TabStop = false;
            this.grbDestinatarioConfiguracaoAutomatica.Text = "Notificações da Configuração Automática de Pedidos";
            // 
            // txtDestinatarioConfiguracaoAutomatica
            // 
            this.txtDestinatarioConfiguracaoAutomatica.Location = new System.Drawing.Point(79, 19);
            this.txtDestinatarioConfiguracaoAutomatica.Name = "txtDestinatarioConfiguracaoAutomatica";
            this.txtDestinatarioConfiguracaoAutomatica.Size = new System.Drawing.Size(364, 20);
            this.txtDestinatarioConfiguracaoAutomatica.TabIndex = 12;
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(9, 22);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(63, 13);
            this.label66.TabIndex = 11;
            this.label66.Text = "Destinatário";
            // 
            // chkEnvioOrcamentoDestInterno
            // 
            this.chkEnvioOrcamentoDestInterno.AutoSize = true;
            this.chkEnvioOrcamentoDestInterno.Checked = true;
            this.chkEnvioOrcamentoDestInterno.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnvioOrcamentoDestInterno.Location = new System.Drawing.Point(500, 377);
            this.chkEnvioOrcamentoDestInterno.Name = "chkEnvioOrcamentoDestInterno";
            this.chkEnvioOrcamentoDestInterno.Size = new System.Drawing.Size(15, 14);
            this.chkEnvioOrcamentoDestInterno.TabIndex = 16;
            this.chkEnvioOrcamentoDestInterno.UseVisualStyleBackColor = true;
            this.chkEnvioOrcamentoDestInterno.CheckedChanged += new System.EventHandler(this.chkEnvioOrcamentoDestInterno_CheckedChanged);
            // 
            // chkEnvioPedidoDestInterno
            // 
            this.chkEnvioPedidoDestInterno.AutoSize = true;
            this.chkEnvioPedidoDestInterno.Checked = true;
            this.chkEnvioPedidoDestInterno.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnvioPedidoDestInterno.Location = new System.Drawing.Point(502, 325);
            this.chkEnvioPedidoDestInterno.Name = "chkEnvioPedidoDestInterno";
            this.chkEnvioPedidoDestInterno.Size = new System.Drawing.Size(15, 14);
            this.chkEnvioPedidoDestInterno.TabIndex = 15;
            this.chkEnvioPedidoDestInterno.UseVisualStyleBackColor = true;
            this.chkEnvioPedidoDestInterno.CheckedChanged += new System.EventHandler(this.chkEnvioPedidoDestInterno_CheckedChanged);
            // 
            // grpDestInternoPedido
            // 
            this.grpDestInternoPedido.Controls.Add(this.txtDestinatarioInternoPedido);
            this.grpDestInternoPedido.Controls.Add(this.label52);
            this.grpDestInternoPedido.Location = new System.Drawing.Point(17, 306);
            this.grpDestInternoPedido.Name = "grpDestInternoPedido";
            this.grpDestInternoPedido.Size = new System.Drawing.Size(478, 50);
            this.grpDestInternoPedido.TabIndex = 14;
            this.grpDestInternoPedido.TabStop = false;
            this.grpDestInternoPedido.Text = "Envio de Pedido - Destinatário Interno";
            // 
            // txtDestinatarioInternoPedido
            // 
            this.txtDestinatarioInternoPedido.Location = new System.Drawing.Point(78, 19);
            this.txtDestinatarioInternoPedido.Name = "txtDestinatarioInternoPedido";
            this.txtDestinatarioInternoPedido.Size = new System.Drawing.Size(365, 20);
            this.txtDestinatarioInternoPedido.TabIndex = 12;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(9, 22);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(63, 13);
            this.label52.TabIndex = 11;
            this.label52.Text = "Destinatário";
            // 
            // grpDestInternoOrcamento
            // 
            this.grpDestInternoOrcamento.Controls.Add(this.txtDestinatarioInternoOrcamento);
            this.grpDestInternoOrcamento.Controls.Add(this.label53);
            this.grpDestInternoOrcamento.Location = new System.Drawing.Point(16, 358);
            this.grpDestInternoOrcamento.Name = "grpDestInternoOrcamento";
            this.grpDestInternoOrcamento.Size = new System.Drawing.Size(478, 50);
            this.grpDestInternoOrcamento.TabIndex = 14;
            this.grpDestInternoOrcamento.TabStop = false;
            this.grpDestInternoOrcamento.Text = "Envio de Orçamento - Destinatário Interno";
            // 
            // txtDestinatarioInternoOrcamento
            // 
            this.txtDestinatarioInternoOrcamento.Location = new System.Drawing.Point(79, 19);
            this.txtDestinatarioInternoOrcamento.Name = "txtDestinatarioInternoOrcamento";
            this.txtDestinatarioInternoOrcamento.Size = new System.Drawing.Size(364, 20);
            this.txtDestinatarioInternoOrcamento.TabIndex = 12;
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(9, 22);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(63, 13);
            this.label53.TabIndex = 11;
            this.label53.Text = "Destinatário";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtRementePedidoOrcamento);
            this.groupBox2.Controls.Add(this.label47);
            this.groupBox2.Location = new System.Drawing.Point(17, 250);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(478, 50);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Envio de Pedido, Orçamento e Relatórios";
            // 
            // txtRementePedidoOrcamento
            // 
            this.txtRementePedidoOrcamento.Location = new System.Drawing.Point(78, 19);
            this.txtRementePedidoOrcamento.Name = "txtRementePedidoOrcamento";
            this.txtRementePedidoOrcamento.Size = new System.Drawing.Size(365, 20);
            this.txtRementePedidoOrcamento.TabIndex = 12;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(9, 22);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(59, 13);
            this.label47.TabIndex = 11;
            this.label47.Text = "Remetente";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.txtRemetenteCompras);
            this.groupBox8.Controls.Add(this.label18);
            this.groupBox8.Location = new System.Drawing.Point(16, 190);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(478, 50);
            this.groupBox8.TabIndex = 3;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Envio de Ordem de Compra e pedido de Cotação";
            // 
            // txtRemetenteCompras
            // 
            this.txtRemetenteCompras.Location = new System.Drawing.Point(78, 19);
            this.txtRemetenteCompras.Name = "txtRemetenteCompras";
            this.txtRemetenteCompras.Size = new System.Drawing.Size(365, 20);
            this.txtRemetenteCompras.TabIndex = 12;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(9, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 13);
            this.label18.TabIndex = 11;
            this.label18.Text = "Remetente";
            // 
            // chkAvisoEmissaoNF
            // 
            this.chkAvisoEmissaoNF.AutoSize = true;
            this.chkAvisoEmissaoNF.Checked = true;
            this.chkAvisoEmissaoNF.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAvisoEmissaoNF.Location = new System.Drawing.Point(500, 143);
            this.chkAvisoEmissaoNF.Name = "chkAvisoEmissaoNF";
            this.chkAvisoEmissaoNF.Size = new System.Drawing.Size(15, 14);
            this.chkAvisoEmissaoNF.TabIndex = 2;
            this.chkAvisoEmissaoNF.UseVisualStyleBackColor = true;
            this.chkAvisoEmissaoNF.CheckedChanged += new System.EventHandler(this.chkAvisoEmissaoNF_CheckedChanged);
            // 
            // grbAvisoEmissaoNF
            // 
            this.grbAvisoEmissaoNF.Controls.Add(this.txtDestinatario);
            this.grbAvisoEmissaoNF.Controls.Add(this.label37);
            this.grbAvisoEmissaoNF.Controls.Add(this.txtRemetente);
            this.grbAvisoEmissaoNF.Controls.Add(this.label36);
            this.grbAvisoEmissaoNF.Location = new System.Drawing.Point(16, 118);
            this.grbAvisoEmissaoNF.Name = "grbAvisoEmissaoNF";
            this.grbAvisoEmissaoNF.Size = new System.Drawing.Size(478, 66);
            this.grbAvisoEmissaoNF.TabIndex = 1;
            this.grbAvisoEmissaoNF.TabStop = false;
            this.grbAvisoEmissaoNF.Text = "Aviso de Emissão de NF";
            // 
            // txtDestinatario
            // 
            this.txtDestinatario.Location = new System.Drawing.Point(78, 40);
            this.txtDestinatario.Name = "txtDestinatario";
            this.txtDestinatario.Size = new System.Drawing.Size(365, 20);
            this.txtDestinatario.TabIndex = 12;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(9, 43);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(63, 13);
            this.label37.TabIndex = 11;
            this.label37.Text = "Destinatário";
            // 
            // txtRemetente
            // 
            this.txtRemetente.Location = new System.Drawing.Point(78, 19);
            this.txtRemetente.Name = "txtRemetente";
            this.txtRemetente.Size = new System.Drawing.Size(365, 20);
            this.txtRemetente.TabIndex = 10;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(9, 22);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(59, 13);
            this.label36.TabIndex = 9;
            this.label36.Text = "Remetente";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkSmtpSSH);
            this.groupBox3.Controls.Add(this.txtSmtpSenha);
            this.groupBox3.Controls.Add(this.label35);
            this.groupBox3.Controls.Add(this.txtSmtpUsuario);
            this.groupBox3.Controls.Add(this.label34);
            this.groupBox3.Controls.Add(this.chkSmtpAutenticado);
            this.groupBox3.Controls.Add(this.nudSmtpPort);
            this.groupBox3.Controls.Add(this.label33);
            this.groupBox3.Controls.Add(this.txtSmtpHost);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(16, 15);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(524, 97);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Servidor SMTP";
            // 
            // chkSmtpSSH
            // 
            this.chkSmtpSSH.AutoSize = true;
            this.chkSmtpSSH.Enabled = false;
            this.chkSmtpSSH.Location = new System.Drawing.Point(149, 38);
            this.chkSmtpSSH.Name = "chkSmtpSSH";
            this.chkSmtpSSH.Size = new System.Drawing.Size(104, 17);
            this.chkSmtpSSH.TabIndex = 3;
            this.chkSmtpSSH.Text = "Criptografia SSH";
            this.chkSmtpSSH.UseVisualStyleBackColor = true;
            // 
            // txtSmtpSenha
            // 
            this.txtSmtpSenha.Enabled = false;
            this.txtSmtpSenha.Location = new System.Drawing.Point(288, 61);
            this.txtSmtpSenha.Name = "txtSmtpSenha";
            this.txtSmtpSenha.PasswordChar = '*';
            this.txtSmtpSenha.Size = new System.Drawing.Size(174, 20);
            this.txtSmtpSenha.TabIndex = 5;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(244, 64);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(38, 13);
            this.label35.TabIndex = 7;
            this.label35.Text = "Senha";
            // 
            // txtSmtpUsuario
            // 
            this.txtSmtpUsuario.Enabled = false;
            this.txtSmtpUsuario.Location = new System.Drawing.Point(58, 61);
            this.txtSmtpUsuario.Name = "txtSmtpUsuario";
            this.txtSmtpUsuario.Size = new System.Drawing.Size(174, 20);
            this.txtSmtpUsuario.TabIndex = 4;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(9, 64);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(43, 13);
            this.label34.TabIndex = 5;
            this.label34.Text = "Usuario";
            // 
            // chkSmtpAutenticado
            // 
            this.chkSmtpAutenticado.AutoSize = true;
            this.chkSmtpAutenticado.Location = new System.Drawing.Point(9, 39);
            this.chkSmtpAutenticado.Name = "chkSmtpAutenticado";
            this.chkSmtpAutenticado.Size = new System.Drawing.Size(83, 17);
            this.chkSmtpAutenticado.TabIndex = 2;
            this.chkSmtpAutenticado.Text = "Autenticado";
            this.chkSmtpAutenticado.UseVisualStyleBackColor = true;
            this.chkSmtpAutenticado.CheckedChanged += new System.EventHandler(this.chkSmtpAutenticado_CheckedChanged);
            // 
            // nudSmtpPort
            // 
            this.nudSmtpPort.Location = new System.Drawing.Point(288, 13);
            this.nudSmtpPort.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudSmtpPort.Name = "nudSmtpPort";
            this.nudSmtpPort.Size = new System.Drawing.Size(73, 20);
            this.nudSmtpPort.TabIndex = 1;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(250, 16);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(32, 13);
            this.label33.TabIndex = 2;
            this.label33.Text = "Porta";
            // 
            // txtSmtpHost
            // 
            this.txtSmtpHost.Location = new System.Drawing.Point(58, 13);
            this.txtSmtpHost.Name = "txtSmtpHost";
            this.txtSmtpHost.Size = new System.Drawing.Size(174, 20);
            this.txtSmtpHost.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Servidor";
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.nudDiasArmazenagemOP);
            this.tabPage7.Controls.Add(this.label42);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(995, 487);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Qualidade";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // nudDiasArmazenagemOP
            // 
            this.nudDiasArmazenagemOP.Location = new System.Drawing.Point(194, 24);
            this.nudDiasArmazenagemOP.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nudDiasArmazenagemOP.Name = "nudDiasArmazenagemOP";
            this.nudDiasArmazenagemOP.Size = new System.Drawing.Size(101, 20);
            this.nudDiasArmazenagemOP.TabIndex = 1;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(8, 26);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(180, 13);
            this.label42.TabIndex = 0;
            this.label42.Text = "Prazo de Armazenagem de OP (dias)";
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.chkExigirDocumentosOpZerada);
            this.tabPage8.Controls.Add(this.label69);
            this.tabPage8.Controls.Add(this.chkSuprimirQtdUnitariaMaterialOP);
            this.tabPage8.Controls.Add(this.label62);
            this.tabPage8.Controls.Add(this.chkPermitirSelecaoImpressoraExp);
            this.tabPage8.Controls.Add(this.nudPorcentagemProducaoAcima);
            this.tabPage8.Controls.Add(this.label60);
            this.tabPage8.Controls.Add(this.nudMesesCustoHora);
            this.tabPage8.Controls.Add(this.label58);
            this.tabPage8.Controls.Add(this.chkSuprimirOrdensZeradasKb);
            this.tabPage8.Controls.Add(this.label56);
            this.tabPage8.Controls.Add(this.cmbImpressoraOP);
            this.tabPage8.Controls.Add(this.label45);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(995, 487);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Text = "Produção";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // chkExigirDocumentosOpZerada
            // 
            this.chkExigirDocumentosOpZerada.AutoSize = true;
            this.chkExigirDocumentosOpZerada.Location = new System.Drawing.Point(22, 265);
            this.chkExigirDocumentosOpZerada.Name = "chkExigirDocumentosOpZerada";
            this.chkExigirDocumentosOpZerada.Size = new System.Drawing.Size(15, 14);
            this.chkExigirDocumentosOpZerada.TabIndex = 27;
            this.chkExigirDocumentosOpZerada.UseVisualStyleBackColor = true;
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(8, 249);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(396, 13);
            this.label69.TabIndex = 28;
            this.label69.Text = "Exigir cópias de Documentos quando a Ordem de Produção tiver Quantidade Zero";
            // 
            // chkSuprimirQtdUnitariaMaterialOP
            // 
            this.chkSuprimirQtdUnitariaMaterialOP.AutoSize = true;
            this.chkSuprimirQtdUnitariaMaterialOP.Location = new System.Drawing.Point(22, 117);
            this.chkSuprimirQtdUnitariaMaterialOP.Name = "chkSuprimirQtdUnitariaMaterialOP";
            this.chkSuprimirQtdUnitariaMaterialOP.Size = new System.Drawing.Size(15, 14);
            this.chkSuprimirQtdUnitariaMaterialOP.TabIndex = 2;
            this.chkSuprimirQtdUnitariaMaterialOP.UseVisualStyleBackColor = true;
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(8, 101);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(364, 13);
            this.label62.TabIndex = 26;
            this.label62.Text = "Suprimir a campo de quantidade unitária do Material na Ordem de Produção";
            // 
            // chkPermitirSelecaoImpressoraExp
            // 
            this.chkPermitirSelecaoImpressoraExp.AutoSize = true;
            this.chkPermitirSelecaoImpressoraExp.Location = new System.Drawing.Point(22, 215);
            this.chkPermitirSelecaoImpressoraExp.Name = "chkPermitirSelecaoImpressoraExp";
            this.chkPermitirSelecaoImpressoraExp.Size = new System.Drawing.Size(357, 17);
            this.chkPermitirSelecaoImpressoraExp.TabIndex = 5;
            this.chkPermitirSelecaoImpressoraExp.Text = "Permitir a seleção manual da impressora de Ordem de Produção de Kit";
            this.chkPermitirSelecaoImpressoraExp.UseVisualStyleBackColor = true;
            // 
            // nudPorcentagemProducaoAcima
            // 
            this.nudPorcentagemProducaoAcima.DecimalPlaces = 2;
            this.nudPorcentagemProducaoAcima.Location = new System.Drawing.Point(266, 171);
            this.nudPorcentagemProducaoAcima.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPorcentagemProducaoAcima.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudPorcentagemProducaoAcima.Name = "nudPorcentagemProducaoAcima";
            this.nudPorcentagemProducaoAcima.Size = new System.Drawing.Size(138, 20);
            this.nudPorcentagemProducaoAcima.TabIndex = 4;
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(5, 173);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(255, 13);
            this.label60.TabIndex = 24;
            this.label60.Text = "% de Produção acima do estoque verde configurado";
            // 
            // nudMesesCustoHora
            // 
            this.nudMesesCustoHora.Location = new System.Drawing.Point(266, 145);
            this.nudMesesCustoHora.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudMesesCustoHora.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMesesCustoHora.Name = "nudMesesCustoHora";
            this.nudMesesCustoHora.Size = new System.Drawing.Size(138, 20);
            this.nudMesesCustoHora.TabIndex = 3;
            this.nudMesesCustoHora.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(16, 147);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(244, 13);
            this.label58.TabIndex = 21;
            this.label58.Text = "Quantidade de Meses para Cálculo do Custo Hora";
            // 
            // chkSuprimirOrdensZeradasKb
            // 
            this.chkSuprimirOrdensZeradasKb.AutoSize = true;
            this.chkSuprimirOrdensZeradasKb.Location = new System.Drawing.Point(22, 84);
            this.chkSuprimirOrdensZeradasKb.Name = "chkSuprimirOrdensZeradasKb";
            this.chkSuprimirOrdensZeradasKb.Size = new System.Drawing.Size(15, 14);
            this.chkSuprimirOrdensZeradasKb.TabIndex = 1;
            this.chkSuprimirOrdensZeradasKb.UseVisualStyleBackColor = true;
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(8, 68);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(832, 13);
            this.label56.TabIndex = 19;
            this.label56.Text = "Suprimir a Impressão das Ordens de Produção de Kanbans de itens manufaturados com" +
    " Quantidade Zero ( as ordens não serão impressas e já serão criadas como encerra" +
    "das)";
            // 
            // cmbImpressoraOP
            // 
            this.cmbImpressoraOP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbImpressoraOP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbImpressoraOP.FormattingEnabled = true;
            this.cmbImpressoraOP.Location = new System.Drawing.Point(22, 28);
            this.cmbImpressoraOP.Name = "cmbImpressoraOP";
            this.cmbImpressoraOP.Size = new System.Drawing.Size(446, 21);
            this.cmbImpressoraOP.TabIndex = 0;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(6, 12);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(137, 13);
            this.label45.TabIndex = 17;
            this.label45.Text = "Nome da Impressora de OP";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.iwtLabel18);
            this.tabPage1.Controls.Add(this.chkEstoquePermitirCriacaoLocalEstoque);
            this.tabPage1.Controls.Add(this.groupBox14);
            this.tabPage1.Controls.Add(this.groupBox12);
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Controls.Add(this.nudEstoqueMeses);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(995, 487);
            this.tabPage1.TabIndex = 8;
            this.tabPage1.Text = "Estoque";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // iwtLabel18
            // 
            this.iwtLabel18.AutoSize = true;
            this.iwtLabel18.BindingField = null;
            this.iwtLabel18.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel18.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel18.Location = new System.Drawing.Point(8, 402);
            this.iwtLabel18.Name = "iwtLabel18";
            this.iwtLabel18.Size = new System.Drawing.Size(354, 13);
            this.iwtLabel18.TabIndex = 23;
            this.iwtLabel18.Text = "Permitir a Criação de Novos Locais de Estoque nos Processos Produtivos";
            // 
            // chkEstoquePermitirCriacaoLocalEstoque
            // 
            this.chkEstoquePermitirCriacaoLocalEstoque.AutoSize = true;
            this.chkEstoquePermitirCriacaoLocalEstoque.BindingField = null;
            this.chkEstoquePermitirCriacaoLocalEstoque.LiberadoQuandoCadastroUtilizado = false;
            this.chkEstoquePermitirCriacaoLocalEstoque.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkEstoquePermitirCriacaoLocalEstoque.Location = new System.Drawing.Point(368, 402);
            this.chkEstoquePermitirCriacaoLocalEstoque.Name = "chkEstoquePermitirCriacaoLocalEstoque";
            this.chkEstoquePermitirCriacaoLocalEstoque.Size = new System.Drawing.Size(15, 14);
            this.chkEstoquePermitirCriacaoLocalEstoque.TabIndex = 22;
            this.chkEstoquePermitirCriacaoLocalEstoque.UseVisualStyleBackColor = true;
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.nudEstoqueInventarioPrecoMedioMeses);
            this.groupBox14.Controls.Add(this.iwtLabel3);
            this.groupBox14.Controls.Add(this.chkEstoqueInventarioPrecoMedio);
            this.groupBox14.Controls.Add(this.iwtLabel2);
            this.groupBox14.Location = new System.Drawing.Point(11, 332);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(418, 54);
            this.groupBox14.TabIndex = 21;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Geração de Inventário";
            // 
            // nudEstoqueInventarioPrecoMedioMeses
            // 
            this.nudEstoqueInventarioPrecoMedioMeses.BindingField = null;
            this.nudEstoqueInventarioPrecoMedioMeses.Enabled = false;
            this.nudEstoqueInventarioPrecoMedioMeses.LiberadoQuandoCadastroUtilizado = false;
            this.nudEstoqueInventarioPrecoMedioMeses.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudEstoqueInventarioPrecoMedioMeses.Location = new System.Drawing.Point(307, 24);
            this.nudEstoqueInventarioPrecoMedioMeses.Name = "nudEstoqueInventarioPrecoMedioMeses";
            this.nudEstoqueInventarioPrecoMedioMeses.Size = new System.Drawing.Size(81, 20);
            this.nudEstoqueInventarioPrecoMedioMeses.TabIndex = 3;
            this.nudEstoqueInventarioPrecoMedioMeses.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // iwtLabel3
            // 
            this.iwtLabel3.AutoSize = true;
            this.iwtLabel3.BindingField = null;
            this.iwtLabel3.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel3.Location = new System.Drawing.Point(187, 26);
            this.iwtLabel3.Name = "iwtLabel3";
            this.iwtLabel3.Size = new System.Drawing.Size(114, 13);
            this.iwtLabel3.TabIndex = 2;
            this.iwtLabel3.Text = "Qtd Meses para Média";
            // 
            // chkEstoqueInventarioPrecoMedio
            // 
            this.chkEstoqueInventarioPrecoMedio.AutoSize = true;
            this.chkEstoqueInventarioPrecoMedio.BindingField = null;
            this.chkEstoqueInventarioPrecoMedio.LiberadoQuandoCadastroUtilizado = false;
            this.chkEstoqueInventarioPrecoMedio.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkEstoqueInventarioPrecoMedio.Location = new System.Drawing.Point(147, 25);
            this.chkEstoqueInventarioPrecoMedio.Name = "chkEstoqueInventarioPrecoMedio";
            this.chkEstoqueInventarioPrecoMedio.Size = new System.Drawing.Size(15, 14);
            this.chkEstoqueInventarioPrecoMedio.TabIndex = 1;
            this.chkEstoqueInventarioPrecoMedio.UseVisualStyleBackColor = true;
            this.chkEstoqueInventarioPrecoMedio.CheckedChanged += new System.EventHandler(this.chkEstoqueInventarioPrecoMedio_CheckedChanged);
            // 
            // iwtLabel2
            // 
            this.iwtLabel2.AutoSize = true;
            this.iwtLabel2.BindingField = null;
            this.iwtLabel2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel2.Location = new System.Drawing.Point(6, 26);
            this.iwtLabel2.Name = "iwtLabel2";
            this.iwtLabel2.Size = new System.Drawing.Size(135, 13);
            this.iwtLabel2.TabIndex = 0;
            this.iwtLabel2.Text = "Inventário por Preço Médio";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.rdbTipoFormMovA5);
            this.groupBox12.Controls.Add(this.rdbTipoFormMovEtqM);
            this.groupBox12.Location = new System.Drawing.Point(11, 272);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(418, 54);
            this.groupBox12.TabIndex = 20;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Tipo de Formulário de Movimentação";
            // 
            // rdbTipoFormMovA5
            // 
            this.rdbTipoFormMovA5.AutoSize = true;
            this.rdbTipoFormMovA5.Checked = true;
            this.rdbTipoFormMovA5.Location = new System.Drawing.Point(18, 23);
            this.rdbTipoFormMovA5.Name = "rdbTipoFormMovA5";
            this.rdbTipoFormMovA5.Size = new System.Drawing.Size(86, 17);
            this.rdbTipoFormMovA5.TabIndex = 2;
            this.rdbTipoFormMovA5.TabStop = true;
            this.rdbTipoFormMovA5.Text = "Meio A4 (A5)";
            this.rdbTipoFormMovA5.UseVisualStyleBackColor = true;
            // 
            // rdbTipoFormMovEtqM
            // 
            this.rdbTipoFormMovEtqM.AutoSize = true;
            this.rdbTipoFormMovEtqM.Location = new System.Drawing.Point(134, 23);
            this.rdbTipoFormMovEtqM.Name = "rdbTipoFormMovEtqM";
            this.rdbTipoFormMovEtqM.Size = new System.Drawing.Size(96, 17);
            this.rdbTipoFormMovEtqM.TabIndex = 1;
            this.rdbTipoFormMovEtqM.Text = "Etiqueta Média";
            this.rdbTipoFormMovEtqM.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.nudEstoqueClassificacaoB);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.nudEstoqueClassificacaoA);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Location = new System.Drawing.Point(11, 181);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(418, 85);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Classificação ABC";
            // 
            // nudEstoqueClassificacaoB
            // 
            this.nudEstoqueClassificacaoB.DecimalPlaces = 2;
            this.nudEstoqueClassificacaoB.Location = new System.Drawing.Point(268, 40);
            this.nudEstoqueClassificacaoB.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudEstoqueClassificacaoB.Name = "nudEstoqueClassificacaoB";
            this.nudEstoqueClassificacaoB.Size = new System.Drawing.Size(120, 20);
            this.nudEstoqueClassificacaoB.TabIndex = 13;
            this.nudEstoqueClassificacaoB.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(244, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Classificação \"B\" Acima de (R$ por média mensal)";
            // 
            // nudEstoqueClassificacaoA
            // 
            this.nudEstoqueClassificacaoA.DecimalPlaces = 2;
            this.nudEstoqueClassificacaoA.Location = new System.Drawing.Point(268, 14);
            this.nudEstoqueClassificacaoA.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudEstoqueClassificacaoA.Name = "nudEstoqueClassificacaoA";
            this.nudEstoqueClassificacaoA.Size = new System.Drawing.Size(120, 20);
            this.nudEstoqueClassificacaoA.TabIndex = 11;
            this.nudEstoqueClassificacaoA.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(244, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Classificação \"A\" Acima de (R$ por média mensal)";
            // 
            // nudEstoqueMeses
            // 
            this.nudEstoqueMeses.Location = new System.Drawing.Point(245, 14);
            this.nudEstoqueMeses.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudEstoqueMeses.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudEstoqueMeses.Name = "nudEstoqueMeses";
            this.nudEstoqueMeses.Size = new System.Drawing.Size(138, 20);
            this.nudEstoqueMeses.TabIndex = 2;
            this.nudEstoqueMeses.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Quantidade de Meses para Média de Utilização";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.nudEstoqueMargemRevisaoKb);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.nudEstoqueDiasVermelho);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.nudEstoqueDiasAmarelo);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.nudEstoqueDiasVerde);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Location = new System.Drawing.Point(11, 40);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(418, 135);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Kanban";
            // 
            // nudEstoqueMargemRevisaoKb
            // 
            this.nudEstoqueMargemRevisaoKb.Location = new System.Drawing.Point(268, 100);
            this.nudEstoqueMargemRevisaoKb.Name = "nudEstoqueMargemRevisaoKb";
            this.nudEstoqueMargemRevisaoKb.Size = new System.Drawing.Size(120, 20);
            this.nudEstoqueMargemRevisaoKb.TabIndex = 10;
            this.nudEstoqueMargemRevisaoKb.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(93, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(166, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Margem (%) para aviso de revisão";
            // 
            // nudEstoqueDiasVermelho
            // 
            this.nudEstoqueDiasVermelho.Location = new System.Drawing.Point(268, 74);
            this.nudEstoqueDiasVermelho.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudEstoqueDiasVermelho.Name = "nudEstoqueDiasVermelho";
            this.nudEstoqueDiasVermelho.Size = new System.Drawing.Size(120, 20);
            this.nudEstoqueDiasVermelho.TabIndex = 8;
            this.nudEstoqueDiasVermelho.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(237, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Dias de Utilização Média para Estoque Vermelho";
            // 
            // nudEstoqueDiasAmarelo
            // 
            this.nudEstoqueDiasAmarelo.Location = new System.Drawing.Point(268, 48);
            this.nudEstoqueDiasAmarelo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudEstoqueDiasAmarelo.Name = "nudEstoqueDiasAmarelo";
            this.nudEstoqueDiasAmarelo.Size = new System.Drawing.Size(120, 20);
            this.nudEstoqueDiasAmarelo.TabIndex = 6;
            this.nudEstoqueDiasAmarelo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(231, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Dias de Utilização Média para Estoque Amarelo";
            // 
            // nudEstoqueDiasVerde
            // 
            this.nudEstoqueDiasVerde.Location = new System.Drawing.Point(268, 22);
            this.nudEstoqueDiasVerde.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudEstoqueDiasVerde.Name = "nudEstoqueDiasVerde";
            this.nudEstoqueDiasVerde.Size = new System.Drawing.Size(120, 20);
            this.nudEstoqueDiasVerde.TabIndex = 4;
            this.nudEstoqueDiasVerde.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Dias de Utilização Média para Estoque Verde";
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.chkMarcarAutomaticamenteOcComDescontoParaNaoAtualizarPrecoProduto);
            this.tabPage9.Controls.Add(this.label72);
            this.tabPage9.Controls.Add(this.chkComprasFluxoAprovacao);
            this.tabPage9.Controls.Add(this.label71);
            this.tabPage9.Controls.Add(this.label70);
            this.tabPage9.Controls.Add(this.chkComprasContasRevisarPadraoFornecedores);
            this.tabPage9.Controls.Add(this.label68);
            this.tabPage9.Controls.Add(this.label67);
            this.tabPage9.Controls.Add(this.chkComprasPermitirPrazoDomingo);
            this.tabPage9.Controls.Add(this.chkComprasPermitirPrazoSabado);
            this.tabPage9.Controls.Add(this.nudMargemRecebimento);
            this.tabPage9.Controls.Add(this.label44);
            this.tabPage9.Controls.Add(this.txtComprasEmailTexto);
            this.tabPage9.Controls.Add(this.label24);
            this.tabPage9.Controls.Add(this.txtComprasRodape);
            this.tabPage9.Controls.Add(this.label23);
            this.tabPage9.Controls.Add(this.nudComprasDias);
            this.tabPage9.Controls.Add(this.label15);
            this.tabPage9.Controls.Add(this.nudComprasSugeridoAcimaConfigurado);
            this.tabPage9.Controls.Add(this.nudComprasDisparoSolicitacaoCompra);
            this.tabPage9.Controls.Add(this.label14);
            this.tabPage9.Controls.Add(this.label13);
            this.tabPage9.Controls.Add(this.nudComprasDiasPCP);
            this.tabPage9.Controls.Add(this.label9);
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(995, 487);
            this.tabPage9.TabIndex = 9;
            this.tabPage9.Text = "Compras";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // chkComprasFluxoAprovacao
            // 
            this.chkComprasFluxoAprovacao.AutoSize = true;
            this.chkComprasFluxoAprovacao.BindingField = null;
            this.chkComprasFluxoAprovacao.LiberadoQuandoCadastroUtilizado = false;
            this.chkComprasFluxoAprovacao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkComprasFluxoAprovacao.Location = new System.Drawing.Point(274, 422);
            this.chkComprasFluxoAprovacao.Name = "chkComprasFluxoAprovacao";
            this.chkComprasFluxoAprovacao.Size = new System.Drawing.Size(15, 14);
            this.chkComprasFluxoAprovacao.TabIndex = 27;
            this.chkComprasFluxoAprovacao.UseVisualStyleBackColor = true;
            // 
            // label71
            // 
            this.label71.Location = new System.Drawing.Point(34, 422);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(234, 31);
            this.label71.TabIndex = 26;
            this.label71.Text = "Habilitar Fluxo de Aprovação";
            this.label71.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label70
            // 
            this.label70.Location = new System.Drawing.Point(13, 386);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(255, 31);
            this.label70.TabIndex = 25;
            this.label70.Text = "Contas do recebimento como a revisar por padrão para novos fornecedores";
            this.label70.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chkComprasContasRevisarPadraoFornecedores
            // 
            this.chkComprasContasRevisarPadraoFornecedores.AutoSize = true;
            this.chkComprasContasRevisarPadraoFornecedores.BindingField = null;
            this.chkComprasContasRevisarPadraoFornecedores.LiberadoQuandoCadastroUtilizado = false;
            this.chkComprasContasRevisarPadraoFornecedores.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkComprasContasRevisarPadraoFornecedores.Location = new System.Drawing.Point(274, 394);
            this.chkComprasContasRevisarPadraoFornecedores.Name = "chkComprasContasRevisarPadraoFornecedores";
            this.chkComprasContasRevisarPadraoFornecedores.Size = new System.Drawing.Size(15, 14);
            this.chkComprasContasRevisarPadraoFornecedores.TabIndex = 24;
            this.chkComprasContasRevisarPadraoFornecedores.UseVisualStyleBackColor = true;
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(13, 356);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(255, 13);
            this.label68.TabIndex = 23;
            this.label68.Text = "Permitir Prazo de Solicitação de Compra no Domingo";
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(18, 336);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(250, 13);
            this.label67.TabIndex = 22;
            this.label67.Text = "Permitir Prazo de Solicitação de Compra no Sábado";
            // 
            // chkComprasPermitirPrazoDomingo
            // 
            this.chkComprasPermitirPrazoDomingo.AutoSize = true;
            this.chkComprasPermitirPrazoDomingo.BindingField = null;
            this.chkComprasPermitirPrazoDomingo.LiberadoQuandoCadastroUtilizado = false;
            this.chkComprasPermitirPrazoDomingo.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkComprasPermitirPrazoDomingo.Location = new System.Drawing.Point(274, 356);
            this.chkComprasPermitirPrazoDomingo.Name = "chkComprasPermitirPrazoDomingo";
            this.chkComprasPermitirPrazoDomingo.Size = new System.Drawing.Size(15, 14);
            this.chkComprasPermitirPrazoDomingo.TabIndex = 21;
            this.chkComprasPermitirPrazoDomingo.UseVisualStyleBackColor = true;
            // 
            // chkComprasPermitirPrazoSabado
            // 
            this.chkComprasPermitirPrazoSabado.AutoSize = true;
            this.chkComprasPermitirPrazoSabado.BindingField = null;
            this.chkComprasPermitirPrazoSabado.LiberadoQuandoCadastroUtilizado = false;
            this.chkComprasPermitirPrazoSabado.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkComprasPermitirPrazoSabado.Location = new System.Drawing.Point(274, 336);
            this.chkComprasPermitirPrazoSabado.Name = "chkComprasPermitirPrazoSabado";
            this.chkComprasPermitirPrazoSabado.Size = new System.Drawing.Size(15, 14);
            this.chkComprasPermitirPrazoSabado.TabIndex = 20;
            this.chkComprasPermitirPrazoSabado.UseVisualStyleBackColor = true;
            // 
            // nudMargemRecebimento
            // 
            this.nudMargemRecebimento.DecimalPlaces = 2;
            this.nudMargemRecebimento.Location = new System.Drawing.Point(274, 292);
            this.nudMargemRecebimento.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudMargemRecebimento.Name = "nudMargemRecebimento";
            this.nudMargemRecebimento.Size = new System.Drawing.Size(138, 20);
            this.nudMargemRecebimento.TabIndex = 18;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(68, 294);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(200, 13);
            this.label44.TabIndex = 19;
            this.label44.Text = "Margem de Aceite para Recebimento (%)";
            // 
            // txtComprasEmailTexto
            // 
            this.txtComprasEmailTexto.AcceptsReturn = true;
            this.txtComprasEmailTexto.AcceptsTab = true;
            this.txtComprasEmailTexto.Location = new System.Drawing.Point(274, 215);
            this.txtComprasEmailTexto.Multiline = true;
            this.txtComprasEmailTexto.Name = "txtComprasEmailTexto";
            this.txtComprasEmailTexto.Size = new System.Drawing.Size(508, 71);
            this.txtComprasEmailTexto.TabIndex = 5;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(6, 218);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(262, 13);
            this.label24.TabIndex = 17;
            this.label24.Text = "Mensagem do Email para Envio de Ordens de Compra";
            // 
            // txtComprasRodape
            // 
            this.txtComprasRodape.AcceptsReturn = true;
            this.txtComprasRodape.AcceptsTab = true;
            this.txtComprasRodape.Location = new System.Drawing.Point(274, 138);
            this.txtComprasRodape.Multiline = true;
            this.txtComprasRodape.Name = "txtComprasRodape";
            this.txtComprasRodape.Size = new System.Drawing.Size(508, 71);
            this.txtComprasRodape.TabIndex = 4;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(108, 141);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(160, 13);
            this.label23.TabIndex = 16;
            this.label23.Text = "Rodapé para Ordens de Compra";
            // 
            // nudComprasDias
            // 
            this.nudComprasDias.Location = new System.Drawing.Point(274, 32);
            this.nudComprasDias.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudComprasDias.Name = "nudComprasDias";
            this.nudComprasDias.Size = new System.Drawing.Size(138, 20);
            this.nudComprasDias.TabIndex = 1;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(15, 34);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(253, 13);
            this.label15.TabIndex = 9;
            this.label15.Text = "Intervalos de dias para Compras liberar a Solicitação";
            // 
            // nudComprasSugeridoAcimaConfigurado
            // 
            this.nudComprasSugeridoAcimaConfigurado.DecimalPlaces = 2;
            this.nudComprasSugeridoAcimaConfigurado.Location = new System.Drawing.Point(274, 101);
            this.nudComprasSugeridoAcimaConfigurado.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudComprasSugeridoAcimaConfigurado.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudComprasSugeridoAcimaConfigurado.Name = "nudComprasSugeridoAcimaConfigurado";
            this.nudComprasSugeridoAcimaConfigurado.Size = new System.Drawing.Size(138, 20);
            this.nudComprasSugeridoAcimaConfigurado.TabIndex = 3;
            // 
            // nudComprasDisparoSolicitacaoCompra
            // 
            this.nudComprasDisparoSolicitacaoCompra.DecimalPlaces = 2;
            this.nudComprasDisparoSolicitacaoCompra.Location = new System.Drawing.Point(274, 75);
            this.nudComprasDisparoSolicitacaoCompra.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudComprasDisparoSolicitacaoCompra.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudComprasDisparoSolicitacaoCompra.Name = "nudComprasDisparoSolicitacaoCompra";
            this.nudComprasDisparoSolicitacaoCompra.Size = new System.Drawing.Size(138, 20);
            this.nudComprasDisparoSolicitacaoCompra.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(19, 103);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(249, 13);
            this.label14.TabIndex = 6;
            this.label14.Text = "% Sugerido de compras acima do valor configurado";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(86, 77);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(182, 13);
            this.label13.TabIndex = 5;
            this.label13.Text = "Disparo da Solicitação de compras %";
            // 
            // nudComprasDiasPCP
            // 
            this.nudComprasDiasPCP.Location = new System.Drawing.Point(274, 6);
            this.nudComprasDiasPCP.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudComprasDiasPCP.Name = "nudComprasDiasPCP";
            this.nudComprasDiasPCP.Size = new System.Drawing.Size(138, 20);
            this.nudComprasDiasPCP.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(242, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Intervalos de dias para o PCP liberar a Solicitação";
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.nudDocumentosQtdMaximaCopias);
            this.tabPage10.Controls.Add(this.label16);
            this.tabPage10.Location = new System.Drawing.Point(4, 22);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10.Size = new System.Drawing.Size(995, 487);
            this.tabPage10.TabIndex = 10;
            this.tabPage10.Text = "Documentos";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // nudDocumentosQtdMaximaCopias
            // 
            this.nudDocumentosQtdMaximaCopias.Location = new System.Drawing.Point(276, 20);
            this.nudDocumentosQtdMaximaCopias.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudDocumentosQtdMaximaCopias.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDocumentosQtdMaximaCopias.Name = "nudDocumentosQtdMaximaCopias";
            this.nudDocumentosQtdMaximaCopias.Size = new System.Drawing.Size(142, 20);
            this.nudDocumentosQtdMaximaCopias.TabIndex = 1;
            this.nudDocumentosQtdMaximaCopias.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(264, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Quantidade Máxima de Cópias por Documento/Familia";
            // 
            // tabPage11
            // 
            this.tabPage11.Controls.Add(this.groupBox11);
            this.tabPage11.Location = new System.Drawing.Point(4, 22);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage11.Size = new System.Drawing.Size(995, 487);
            this.tabPage11.TabIndex = 11;
            this.tabPage11.Text = "Vendas";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.chkEnviarEmailRelComissoes);
            this.groupBox11.Controls.Add(this.iwtLabel1);
            this.groupBox11.Controls.Add(this.txtEmailRelComissoes);
            this.groupBox11.Controls.Add(this.btnCentroCusto);
            this.groupBox11.Controls.Add(this.txtCentroCusto);
            this.groupBox11.Controls.Add(this.cmbContaBancaria);
            this.groupBox11.Controls.Add(this.label55);
            this.groupBox11.Controls.Add(this.label54);
            this.groupBox11.Location = new System.Drawing.Point(8, 17);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(774, 159);
            this.groupBox11.TabIndex = 0;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Configurações Padrão para Comissões";
            // 
            // chkEnviarEmailRelComissoes
            // 
            this.chkEnviarEmailRelComissoes.AutoSize = true;
            this.chkEnviarEmailRelComissoes.BindingField = null;
            this.chkEnviarEmailRelComissoes.LiberadoQuandoCadastroUtilizado = false;
            this.chkEnviarEmailRelComissoes.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkEnviarEmailRelComissoes.Location = new System.Drawing.Point(594, 116);
            this.chkEnviarEmailRelComissoes.Name = "chkEnviarEmailRelComissoes";
            this.chkEnviarEmailRelComissoes.Size = new System.Drawing.Size(15, 14);
            this.chkEnviarEmailRelComissoes.TabIndex = 21;
            this.chkEnviarEmailRelComissoes.UseVisualStyleBackColor = true;
            this.chkEnviarEmailRelComissoes.CheckedChanged += new System.EventHandler(this.chkEnviarEmailRelComissoes_CheckedChanged);
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(45, 116);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(163, 13);
            this.iwtLabel1.TabIndex = 20;
            this.iwtLabel1.Text = "E-mail Cópia Relatório Comissões";
            // 
            // txtEmailRelComissoes
            // 
            this.txtEmailRelComissoes.BindingField = null;
            this.txtEmailRelComissoes.DebugMode = false;
            this.txtEmailRelComissoes.LiberadoQuandoCadastroUtilizado = false;
            this.txtEmailRelComissoes.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtEmailRelComissoes.Location = new System.Drawing.Point(214, 113);
            this.txtEmailRelComissoes.ModoBarcode = false;
            this.txtEmailRelComissoes.ModoBusca = false;
            this.txtEmailRelComissoes.Name = "txtEmailRelComissoes";
            this.txtEmailRelComissoes.NaoLimparDepoisBarcode = false;
            this.txtEmailRelComissoes.Size = new System.Drawing.Size(373, 20);
            this.txtEmailRelComissoes.TabIndex = 19;
            // 
            // btnCentroCusto
            // 
            this.btnCentroCusto.Location = new System.Drawing.Point(549, 70);
            this.btnCentroCusto.Name = "btnCentroCusto";
            this.btnCentroCusto.Size = new System.Drawing.Size(38, 23);
            this.btnCentroCusto.TabIndex = 18;
            this.btnCentroCusto.Text = "...";
            this.btnCentroCusto.UseVisualStyleBackColor = true;
            this.btnCentroCusto.Click += new System.EventHandler(this.btnCentroCusto_Click);
            // 
            // txtCentroCusto
            // 
            this.txtCentroCusto.BindingField = "";
            this.txtCentroCusto.DebugMode = false;
            this.txtCentroCusto.LiberadoQuandoCadastroUtilizado = false;
            this.txtCentroCusto.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtCentroCusto.Location = new System.Drawing.Point(214, 72);
            this.txtCentroCusto.ModoBarcode = false;
            this.txtCentroCusto.ModoBusca = false;
            this.txtCentroCusto.Name = "txtCentroCusto";
            this.txtCentroCusto.NaoLimparDepoisBarcode = false;
            this.txtCentroCusto.ReadOnly = true;
            this.txtCentroCusto.Size = new System.Drawing.Size(330, 20);
            this.txtCentroCusto.TabIndex = 17;
            // 
            // cmbContaBancaria
            // 
            this.cmbContaBancaria.BindingField = "ContaBancaria";
            this.cmbContaBancaria.ColumnsToDisplay = null;
            this.cmbContaBancaria.DisableAutoSelectOnEmpty = false;
            this.cmbContaBancaria.DropDownHeight = 1;
            this.cmbContaBancaria.FormattingEnabled = true;
            this.cmbContaBancaria.IntegralHeight = false;
            this.cmbContaBancaria.LiberadoQuandoCadastroUtilizado = false;
            this.cmbContaBancaria.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.cmbContaBancaria.Location = new System.Drawing.Point(214, 28);
            this.cmbContaBancaria.Name = "cmbContaBancaria";
            this.cmbContaBancaria.SelectedRow = null;
            this.cmbContaBancaria.Size = new System.Drawing.Size(374, 21);
            this.cmbContaBancaria.TabIndex = 16;
            this.cmbContaBancaria.Table = null;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(35, 71);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(173, 13);
            this.label55.TabIndex = 1;
            this.label55.Text = "Centro de Custo Padrão Comissões";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(38, 36);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(170, 13);
            this.label54.TabIndex = 0;
            this.label54.Text = "Conta Bancária Padrão Comissões";
            // 
            // tabPage12
            // 
            this.tabPage12.Controls.Add(this.chkAvisoContaRecorrente);
            this.tabPage12.Controls.Add(this.label57);
            this.tabPage12.Controls.Add(this.nudDiasAvisoContaRecorrente);
            this.tabPage12.Controls.Add(this.cbxAvisoConciliacao);
            this.tabPage12.Controls.Add(this.label51);
            this.tabPage12.Controls.Add(this.nudDiasAvisoConc);
            this.tabPage12.Location = new System.Drawing.Point(4, 22);
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage12.Size = new System.Drawing.Size(995, 487);
            this.tabPage12.TabIndex = 12;
            this.tabPage12.Text = "Financeiro";
            this.tabPage12.UseVisualStyleBackColor = true;
            // 
            // chkAvisoContaRecorrente
            // 
            this.chkAvisoContaRecorrente.AutoSize = true;
            this.chkAvisoContaRecorrente.Location = new System.Drawing.Point(404, 53);
            this.chkAvisoContaRecorrente.Name = "chkAvisoContaRecorrente";
            this.chkAvisoContaRecorrente.Size = new System.Drawing.Size(15, 14);
            this.chkAvisoContaRecorrente.TabIndex = 5;
            this.chkAvisoContaRecorrente.UseVisualStyleBackColor = true;
            this.chkAvisoContaRecorrente.CheckedChanged += new System.EventHandler(this.chkAvisoContaRecorrente_CheckedChanged);
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(16, 52);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(278, 13);
            this.label57.TabIndex = 4;
            this.label57.Text = "Dias de Aviso Antes do Vencimento da Conta Recorrente";
            // 
            // nudDiasAvisoContaRecorrente
            // 
            this.nudDiasAvisoContaRecorrente.Enabled = false;
            this.nudDiasAvisoContaRecorrente.Location = new System.Drawing.Point(300, 50);
            this.nudDiasAvisoContaRecorrente.Maximum = new decimal(new int[] {
            1316134912,
            2328,
            0,
            0});
            this.nudDiasAvisoContaRecorrente.Name = "nudDiasAvisoContaRecorrente";
            this.nudDiasAvisoContaRecorrente.Size = new System.Drawing.Size(97, 20);
            this.nudDiasAvisoContaRecorrente.TabIndex = 3;
            // 
            // cbxAvisoConciliacao
            // 
            this.cbxAvisoConciliacao.AutoSize = true;
            this.cbxAvisoConciliacao.Location = new System.Drawing.Point(404, 27);
            this.cbxAvisoConciliacao.Name = "cbxAvisoConciliacao";
            this.cbxAvisoConciliacao.Size = new System.Drawing.Size(15, 14);
            this.cbxAvisoConciliacao.TabIndex = 2;
            this.cbxAvisoConciliacao.UseVisualStyleBackColor = true;
            this.cbxAvisoConciliacao.CheckedChanged += new System.EventHandler(this.cbxAvisoConciliacao_CheckedChanged);
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(149, 27);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(145, 13);
            this.label51.TabIndex = 1;
            this.label51.Text = "Dias de Aviso de Conciliação";
            // 
            // nudDiasAvisoConc
            // 
            this.nudDiasAvisoConc.Enabled = false;
            this.nudDiasAvisoConc.Location = new System.Drawing.Point(300, 24);
            this.nudDiasAvisoConc.Maximum = new decimal(new int[] {
            1316134912,
            2328,
            0,
            0});
            this.nudDiasAvisoConc.Name = "nudDiasAvisoConc";
            this.nudDiasAvisoConc.Size = new System.Drawing.Size(97, 20);
            this.nudDiasAvisoConc.TabIndex = 0;
            // 
            // tabPage13
            // 
            this.tabPage13.Controls.Add(this.numDiasvalidadePrecoProduto);
            this.tabPage13.Controls.Add(this.iwtLabel24);
            this.tabPage13.Controls.Add(this.iwtLabel23);
            this.tabPage13.Controls.Add(this.chkRegistrarAlteracoesPedido);
            this.tabPage13.Controls.Add(this.iwtLabel22);
            this.tabPage13.Controls.Add(this.chkPesoVolumeNFe);
            this.tabPage13.Controls.Add(this.groupBox15);
            this.tabPage13.Controls.Add(this.chkPermitirFaturarPedido);
            this.tabPage13.Controls.Add(this.label61);
            this.tabPage13.Controls.Add(groupBox13);
            this.tabPage13.Controls.Add(this.txtObsPadraoEspelho);
            this.tabPage13.Controls.Add(this.label59);
            this.tabPage13.Location = new System.Drawing.Point(4, 22);
            this.tabPage13.Name = "tabPage13";
            this.tabPage13.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage13.Size = new System.Drawing.Size(995, 487);
            this.tabPage13.TabIndex = 13;
            this.tabPage13.Text = "Pedido/Orçamento";
            this.tabPage13.UseVisualStyleBackColor = true;
            // 
            // numDiasvalidadePrecoProduto
            // 
            this.numDiasvalidadePrecoProduto.Location = new System.Drawing.Point(226, 403);
            this.numDiasvalidadePrecoProduto.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.numDiasvalidadePrecoProduto.Name = "numDiasvalidadePrecoProduto";
            this.numDiasvalidadePrecoProduto.Size = new System.Drawing.Size(120, 20);
            this.numDiasvalidadePrecoProduto.TabIndex = 13;
            // 
            // iwtLabel24
            // 
            this.iwtLabel24.AutoSize = true;
            this.iwtLabel24.BindingField = null;
            this.iwtLabel24.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel24.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel24.Location = new System.Drawing.Point(32, 405);
            this.iwtLabel24.Name = "iwtLabel24";
            this.iwtLabel24.Size = new System.Drawing.Size(188, 13);
            this.iwtLabel24.TabIndex = 12;
            this.iwtLabel24.Text = "Dias de Validade do Preço do Produto";
            // 
            // iwtLabel23
            // 
            this.iwtLabel23.AutoSize = true;
            this.iwtLabel23.BindingField = null;
            this.iwtLabel23.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel23.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel23.Location = new System.Drawing.Point(23, 352);
            this.iwtLabel23.Name = "iwtLabel23";
            this.iwtLabel23.Size = new System.Drawing.Size(153, 13);
            this.iwtLabel23.TabIndex = 11;
            this.iwtLabel23.Text = "Registrar Alterações do Pedido";
            // 
            // chkRegistrarAlteracoesPedido
            // 
            this.chkRegistrarAlteracoesPedido.AutoSize = true;
            this.chkRegistrarAlteracoesPedido.BindingField = null;
            this.chkRegistrarAlteracoesPedido.LiberadoQuandoCadastroUtilizado = false;
            this.chkRegistrarAlteracoesPedido.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkRegistrarAlteracoesPedido.Location = new System.Drawing.Point(181, 352);
            this.chkRegistrarAlteracoesPedido.Name = "chkRegistrarAlteracoesPedido";
            this.chkRegistrarAlteracoesPedido.Size = new System.Drawing.Size(15, 14);
            this.chkRegistrarAlteracoesPedido.TabIndex = 10;
            this.chkRegistrarAlteracoesPedido.UseVisualStyleBackColor = true;
            // 
            // iwtLabel22
            // 
            this.iwtLabel22.AutoSize = true;
            this.iwtLabel22.BindingField = null;
            this.iwtLabel22.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel22.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel22.Location = new System.Drawing.Point(19, 333);
            this.iwtLabel22.Name = "iwtLabel22";
            this.iwtLabel22.Size = new System.Drawing.Size(156, 13);
            this.iwtLabel22.TabIndex = 9;
            this.iwtLabel22.Text = "Confirmar Peso/Volume da NFe";
            // 
            // chkPesoVolumeNFe
            // 
            this.chkPesoVolumeNFe.AutoSize = true;
            this.chkPesoVolumeNFe.BindingField = null;
            this.chkPesoVolumeNFe.LiberadoQuandoCadastroUtilizado = false;
            this.chkPesoVolumeNFe.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkPesoVolumeNFe.Location = new System.Drawing.Point(181, 332);
            this.chkPesoVolumeNFe.Name = "chkPesoVolumeNFe";
            this.chkPesoVolumeNFe.Size = new System.Drawing.Size(15, 14);
            this.chkPesoVolumeNFe.TabIndex = 8;
            this.chkPesoVolumeNFe.UseVisualStyleBackColor = true;
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.rdbNumeroPedidoNaoIncluir);
            this.groupBox15.Controls.Add(this.rdbNumeroPedidoObservacao);
            this.groupBox15.Controls.Add(this.rdbNumeroPedidoDescricaoItem);
            this.groupBox15.Location = new System.Drawing.Point(171, 214);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(634, 78);
            this.groupBox15.TabIndex = 3;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Número do Pedido na Nota Fiscal";
            // 
            // rdbNumeroPedidoNaoIncluir
            // 
            this.rdbNumeroPedidoNaoIncluir.AutoSize = true;
            this.rdbNumeroPedidoNaoIncluir.Location = new System.Drawing.Point(394, 32);
            this.rdbNumeroPedidoNaoIncluir.Name = "rdbNumeroPedidoNaoIncluir";
            this.rdbNumeroPedidoNaoIncluir.Size = new System.Drawing.Size(76, 17);
            this.rdbNumeroPedidoNaoIncluir.TabIndex = 2;
            this.rdbNumeroPedidoNaoIncluir.Text = "Não Incluir";
            this.rdbNumeroPedidoNaoIncluir.UseVisualStyleBackColor = true;
            // 
            // rdbNumeroPedidoObservacao
            // 
            this.rdbNumeroPedidoObservacao.AutoSize = true;
            this.rdbNumeroPedidoObservacao.Location = new System.Drawing.Point(259, 32);
            this.rdbNumeroPedidoObservacao.Name = "rdbNumeroPedidoObservacao";
            this.rdbNumeroPedidoObservacao.Size = new System.Drawing.Size(129, 17);
            this.rdbNumeroPedidoObservacao.TabIndex = 1;
            this.rdbNumeroPedidoObservacao.Text = "Incluir na Observação";
            this.rdbNumeroPedidoObservacao.UseVisualStyleBackColor = true;
            // 
            // rdbNumeroPedidoDescricaoItem
            // 
            this.rdbNumeroPedidoDescricaoItem.AutoSize = true;
            this.rdbNumeroPedidoDescricaoItem.Checked = true;
            this.rdbNumeroPedidoDescricaoItem.Location = new System.Drawing.Point(98, 32);
            this.rdbNumeroPedidoDescricaoItem.Name = "rdbNumeroPedidoDescricaoItem";
            this.rdbNumeroPedidoDescricaoItem.Size = new System.Drawing.Size(155, 17);
            this.rdbNumeroPedidoDescricaoItem.TabIndex = 0;
            this.rdbNumeroPedidoDescricaoItem.TabStop = true;
            this.rdbNumeroPedidoDescricaoItem.Text = "Incluir na descrição do Item";
            this.rdbNumeroPedidoDescricaoItem.UseVisualStyleBackColor = true;
            // 
            // chkPermitirFaturarPedido
            // 
            this.chkPermitirFaturarPedido.AutoSize = true;
            this.chkPermitirFaturarPedido.Location = new System.Drawing.Point(181, 183);
            this.chkPermitirFaturarPedido.Name = "chkPermitirFaturarPedido";
            this.chkPermitirFaturarPedido.Size = new System.Drawing.Size(15, 14);
            this.chkPermitirFaturarPedido.TabIndex = 2;
            this.chkPermitirFaturarPedido.UseVisualStyleBackColor = true;
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(32, 184);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(144, 13);
            this.label61.TabIndex = 7;
            this.label61.Text = "Permitir Faturar Pedido Direto";
            // 
            // txtObsPadraoEspelho
            // 
            this.txtObsPadraoEspelho.Location = new System.Drawing.Point(181, 103);
            this.txtObsPadraoEspelho.MaxLength = 255;
            this.txtObsPadraoEspelho.Multiline = true;
            this.txtObsPadraoEspelho.Name = "txtObsPadraoEspelho";
            this.txtObsPadraoEspelho.Size = new System.Drawing.Size(624, 58);
            this.txtObsPadraoEspelho.TabIndex = 1;
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(32, 106);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(143, 13);
            this.label59.TabIndex = 0;
            this.label59.Text = "Observação Padrão Espelho";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(835, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Salvar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(916, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Fechar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ofdLogo
            // 
            this.ofdLogo.Filter = "Imagens JPG|*.jpg";
            this.ofdLogo.RestoreDirectory = true;
            // 
            // label72
            // 
            this.label72.Location = new System.Drawing.Point(34, 443);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(234, 31);
            this.label72.TabIndex = 28;
            this.label72.Text = "Marcar automaticamente OC com desconto para não atualizar preços de produtos";
            this.label72.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chkMarcarAutomaticamenteOcComDescontoParaNaoAtualizarPrecoProduto
            // 
            this.chkMarcarAutomaticamenteOcComDescontoParaNaoAtualizarPrecoProduto.AutoSize = true;
            this.chkMarcarAutomaticamenteOcComDescontoParaNaoAtualizarPrecoProduto.BindingField = null;
            this.chkMarcarAutomaticamenteOcComDescontoParaNaoAtualizarPrecoProduto.LiberadoQuandoCadastroUtilizado = false;
            this.chkMarcarAutomaticamenteOcComDescontoParaNaoAtualizarPrecoProduto.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkMarcarAutomaticamenteOcComDescontoParaNaoAtualizarPrecoProduto.Location = new System.Drawing.Point(274, 450);
            this.chkMarcarAutomaticamenteOcComDescontoParaNaoAtualizarPrecoProduto.Name = "chkMarcarAutomaticamenteOcComDescontoParaNaoAtualizarPrecoProduto";
            this.chkMarcarAutomaticamenteOcComDescontoParaNaoAtualizarPrecoProduto.Size = new System.Drawing.Size(15, 14);
            this.chkMarcarAutomaticamenteOcComDescontoParaNaoAtualizarPrecoProduto.TabIndex = 29;
            this.chkMarcarAutomaticamenteOcComDescontoParaNaoAtualizarPrecoProduto.UseVisualStyleBackColor = true;
            // 
            // GerencialConfigurationForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1003, 550);
            this.Controls.Add(this.splitContainer1);
            this.Name = "GerencialConfigurationForm";
            this.Text = "Configurações";
            groupBox13.ResumeLayout(false);
            groupBox13.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAvisoItensSemPedido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumThreads)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTabelaPrecosMinutos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTabelaPrecosHora)).EndInit();
            this.grbExportacaoContas.ResumeLayout(false);
            this.grbExportacaoContas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudExportacaoContasMinuto)).EndInit();
            this.grbExportacaoPedidos.ResumeLayout(false);
            this.grbExportacaoPedidos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudExportacaoPedidosIntervalo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntervaloImportacaoNFEntrada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntervaloImportacaoPedidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LimiteSessaonumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiasDuplicata)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPorcentagemCancelamentoSaldo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSegundosConferencia)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.grbEtiquetaExpedicao.ResumeLayout(false);
            this.grbEtiquetaExpedicao.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage14.ResumeLayout(false);
            this.tabPage14.PerformLayout();
            this.grbEtiquetaClienteComum.ResumeLayout(false);
            this.grbEtiquetaClienteComum.PerformLayout();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEtiquetaAltura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEtiquetaLinhas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEtiquetaColunas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEtiquetaLargura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEtiquetaIntervaloVertical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEtiquetaIntervaloHorizontal)).EndInit();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPapelAltura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPapelMargemDireita)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPapelMargemInferior)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPapelLargura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPapelMargemSuperior)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPapelMargemEsquerda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudResolucao)).EndInit();
            this.grbEtiquetaClienteZebra.ResumeLayout(false);
            this.grbEtiquetaClienteZebra.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.grbDestinatarioConfiguracaoAutomatica.ResumeLayout(false);
            this.grbDestinatarioConfiguracaoAutomatica.PerformLayout();
            this.grpDestInternoPedido.ResumeLayout(false);
            this.grpDestInternoPedido.PerformLayout();
            this.grpDestInternoOrcamento.ResumeLayout(false);
            this.grpDestInternoOrcamento.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.grbAvisoEmissaoNF.ResumeLayout(false);
            this.grbAvisoEmissaoNF.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSmtpPort)).EndInit();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiasArmazenagemOP)).EndInit();
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPorcentagemProducaoAcima)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMesesCustoHora)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEstoqueInventarioPrecoMedioMeses)).EndInit();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEstoqueClassificacaoB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEstoqueClassificacaoA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEstoqueMeses)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEstoqueMargemRevisaoKb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEstoqueDiasVermelho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEstoqueDiasAmarelo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEstoqueDiasVerde)).EndInit();
            this.tabPage9.ResumeLayout(false);
            this.tabPage9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMargemRecebimento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudComprasDias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudComprasSugeridoAcimaConfigurado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudComprasDisparoSolicitacaoCompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudComprasDiasPCP)).EndInit();
            this.tabPage10.ResumeLayout(false);
            this.tabPage10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDocumentosQtdMaximaCopias)).EndInit();
            this.tabPage11.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.tabPage12.ResumeLayout(false);
            this.tabPage12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiasAvisoContaRecorrente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiasAvisoConc)).EndInit();
            this.tabPage13.ResumeLayout(false);
            this.tabPage13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDiasvalidadePrecoProduto)).EndInit();
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.SplitContainer splitContainer1;
      private System.Windows.Forms.TabControl tabControl1;
      private System.Windows.Forms.TabPage tabPage2;
      private System.Windows.Forms.Button button2;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
      private System.Windows.Forms.OpenFileDialog openFileDialog1;
      private System.Windows.Forms.TabPage tabPage3;
      private System.Windows.Forms.Label label25;
      private System.Windows.Forms.NumericUpDown nudSegundosConferencia;
      private System.Windows.Forms.Button btnSaidaArquivoDados;
      private System.Windows.Forms.TextBox txtDiretorioExportacaoCSV;
      private System.Windows.Forms.Label label26;
      private System.Windows.Forms.Label label27;
      private System.Windows.Forms.NumericUpDown nudPorcentagemCancelamentoSaldo;
      private System.Windows.Forms.Label label28;
      private System.Windows.Forms.NumericUpDown nudDiasDuplicata;
      private System.Windows.Forms.NumericUpDown LimiteSessaonumericUpDown;
      private System.Windows.Forms.Label label11;
      private System.Windows.Forms.TabPage tabPage4;
      private System.Windows.Forms.GroupBox grbEtiquetaExpedicao;
      private System.Windows.Forms.ComboBox cmbPapelExpedicao;
      private System.Windows.Forms.ComboBox cmbImpressoraExpedicao;
      private System.Windows.Forms.Label label29;
      private System.Windows.Forms.Label label32;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.ComboBox cmbPapelInterno;
      private System.Windows.Forms.ComboBox cmbImpressoraInterna;
      private System.Windows.Forms.Label label30;
      private System.Windows.Forms.Label label31;
      private System.Windows.Forms.TabPage tabPage5;
      private System.Windows.Forms.CheckBox chkSupplyOn;
      private System.Windows.Forms.TabPage tabPage6;
      private System.Windows.Forms.GroupBox grbAvisoEmissaoNF;
      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.CheckBox chkAvisoEmissaoNF;
      private System.Windows.Forms.NumericUpDown nudSmtpPort;
      private System.Windows.Forms.Label label33;
      private System.Windows.Forms.TextBox txtSmtpHost;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.TextBox txtSmtpSenha;
      private System.Windows.Forms.Label label35;
      private System.Windows.Forms.TextBox txtSmtpUsuario;
      private System.Windows.Forms.Label label34;
      private System.Windows.Forms.CheckBox chkSmtpAutenticado;
      private System.Windows.Forms.TextBox txtDestinatario;
      private System.Windows.Forms.Label label37;
      private System.Windows.Forms.TextBox txtRemetente;
      private System.Windows.Forms.Label label36;
      private System.Windows.Forms.GroupBox groupBox4;
      private System.Windows.Forms.RadioButton rdbSemanaPrimeiroDia;
      private System.Windows.Forms.RadioButton rdbSemanaQuatroDias;
      private System.Windows.Forms.RadioButton rdSemanaInteira;
      private System.Windows.Forms.Label label38;
      private System.Windows.Forms.Label label39;
      private System.Windows.Forms.Label label40;
      private System.Windows.Forms.Label label41;
      private System.Windows.Forms.ComboBox cmbSemanaDia;
      private System.Windows.Forms.TabPage tabPage7;
      private System.Windows.Forms.NumericUpDown nudDiasArmazenagemOP;
      private System.Windows.Forms.Label label42;
      private System.Windows.Forms.Label label43;
      private System.Windows.Forms.NumericUpDown nudNumThreads;
      private System.Windows.Forms.TabPage tabPage8;
      private System.Windows.Forms.ComboBox cmbImpressoraOP;
      private System.Windows.Forms.Label label45;
      private System.Windows.Forms.TabPage tabPage1;
      private System.Windows.Forms.GroupBox groupBox5;
      private System.Windows.Forms.NumericUpDown nudEstoqueMeses;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.NumericUpDown nudEstoqueDiasVermelho;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.NumericUpDown nudEstoqueDiasAmarelo;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.NumericUpDown nudEstoqueDiasVerde;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.NumericUpDown nudEstoqueMargemRevisaoKb;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.GroupBox groupBox6;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.NumericUpDown nudEstoqueClassificacaoB;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.NumericUpDown nudEstoqueClassificacaoA;
      private System.Windows.Forms.TabPage tabPage9;
      private System.Windows.Forms.NumericUpDown nudComprasDiasPCP;
      private System.Windows.Forms.Label label9;
      private System.Windows.Forms.GroupBox groupBox7;
      private System.Windows.Forms.Label label12;
      private System.Windows.Forms.Label label10;
      private System.Windows.Forms.Button btnSaidaNFeEntrada;
      private System.Windows.Forms.TextBox txtSaidaNFeEntrada;
      private System.Windows.Forms.Button btnEntradaNFeEntrada;
      private System.Windows.Forms.TextBox txtEntradaNFeEntrada;
      private System.Windows.Forms.NumericUpDown nudComprasSugeridoAcimaConfigurado;
      private System.Windows.Forms.NumericUpDown nudComprasDisparoSolicitacaoCompra;
      private System.Windows.Forms.Label label14;
      private System.Windows.Forms.Label label13;
      private System.Windows.Forms.NumericUpDown nudComprasDias;
      private System.Windows.Forms.Label label15;
      private System.Windows.Forms.TabPage tabPage10;
      private System.Windows.Forms.NumericUpDown nudDocumentosQtdMaximaCopias;
      private System.Windows.Forms.Label label16;
      private System.Windows.Forms.PictureBox pcbLogo;
      private System.Windows.Forms.Button btnLogo;
      private System.Windows.Forms.Label label17;
      private System.Windows.Forms.OpenFileDialog ofdLogo;
      private System.Windows.Forms.GroupBox groupBox8;
      private System.Windows.Forms.TextBox txtRemetenteCompras;
      private System.Windows.Forms.Label label18;
      private System.Windows.Forms.Label label21;
      private System.Windows.Forms.NumericUpDown nudIntervaloImportacaoPedidos;
      private System.Windows.Forms.Label label19;
      private System.Windows.Forms.Label label20;
      private System.Windows.Forms.NumericUpDown nudIntervaloImportacaoNFEntrada;
      private System.Windows.Forms.Label label22;
      private System.Windows.Forms.TextBox txtComprasEmailTexto;
      private System.Windows.Forms.Label label24;
      private System.Windows.Forms.TextBox txtComprasRodape;
      private System.Windows.Forms.Label label23;
      private System.Windows.Forms.CheckBox chkUtilizarEstoqueOP;
      private System.Windows.Forms.GroupBox groupBox9;
      private System.Windows.Forms.RadioButton rdbEtiquetaMedia;
      private System.Windows.Forms.RadioButton rdbEtiquetaGrande;
      private System.Windows.Forms.NumericUpDown nudMargemRecebimento;
      private System.Windows.Forms.Label label44;
      private System.Windows.Forms.GroupBox grbExportacaoPedidos;
      private System.Windows.Forms.Label label46;
      private System.Windows.Forms.Label label48;
      private System.Windows.Forms.NumericUpDown nudExportacaoPedidosIntervalo;
      private System.Windows.Forms.GroupBox grbExportacaoContas;
      private System.Windows.Forms.Label label49;
      private System.Windows.Forms.Label label50;
      private System.Windows.Forms.NumericUpDown nudExportacaoContasMinuto;
      private System.Windows.Forms.CheckBox chkExportacaoContas;
      private System.Windows.Forms.RadioButton rdbEtiquetaPequena;
      private System.Windows.Forms.CheckBox chkExportacaoPedidos;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.TextBox txtRementePedidoOrcamento;
      private System.Windows.Forms.Label label47;
      private System.Windows.Forms.CheckBox chkEnvioOrcamentoDestInterno;
      private System.Windows.Forms.CheckBox chkEnvioPedidoDestInterno;
      private System.Windows.Forms.GroupBox grpDestInternoPedido;
      private System.Windows.Forms.TextBox txtDestinatarioInternoPedido;
      private System.Windows.Forms.Label label52;
      private System.Windows.Forms.GroupBox grpDestInternoOrcamento;
      private System.Windows.Forms.TextBox txtDestinatarioInternoOrcamento;
      private System.Windows.Forms.Label label53;
      private System.Windows.Forms.GroupBox groupBox10;
      private System.Windows.Forms.RadioButton rdbEtiquetaPequenaRecebimento;
      private System.Windows.Forms.RadioButton rdbEtiquetaMediaRecebimento;
      private System.Windows.Forms.TabPage tabPage11;
      private System.Windows.Forms.GroupBox groupBox11;
      private System.Windows.Forms.Label label55;
      private System.Windows.Forms.Label label54;
      private System.Windows.Forms.Button btnCentroCusto;
      private IWTDotNetLib.IWTTextBox txtCentroCusto;
      private IWTDotNetLib.IWTMultiColumnComboBox cmbContaBancaria;
      private System.Windows.Forms.GroupBox groupBox12;
      private System.Windows.Forms.RadioButton rdbTipoFormMovA5;
      private System.Windows.Forms.RadioButton rdbTipoFormMovEtqM;
      private System.Windows.Forms.TabPage tabPage12;
      private System.Windows.Forms.CheckBox cbxAvisoConciliacao;
      private System.Windows.Forms.Label label51;
      private System.Windows.Forms.NumericUpDown nudDiasAvisoConc;
      private System.Windows.Forms.CheckBox chkSmtpSSH;
      private System.Windows.Forms.CheckBox chkSuprimirOrdensZeradasKb;
      private System.Windows.Forms.Label label56;
      private System.Windows.Forms.CheckBox chkAvisoContaRecorrente;
      private System.Windows.Forms.Label label57;
      private System.Windows.Forms.NumericUpDown nudDiasAvisoContaRecorrente;
      private System.Windows.Forms.NumericUpDown nudMesesCustoHora;
      private System.Windows.Forms.Label label58;
      private IWTDotNetLib.IWTTextBox txtEmailRelComissoes;
      private IWTDotNetLib.IWTLabel iwtLabel1;
      private IWTDotNetLib.IWTCheckBox chkEnviarEmailRelComissoes;
      private System.Windows.Forms.TabPage tabPage13;
      private System.Windows.Forms.Label label59;
      private System.Windows.Forms.RadioButton rdSomenteSbZero;
      private System.Windows.Forms.RadioButton rdImprimirTodos;
      private System.Windows.Forms.TextBox txtObsPadraoEspelho;
      private System.Windows.Forms.NumericUpDown nudPorcentagemProducaoAcima;
      private System.Windows.Forms.Label label60;
      private System.Windows.Forms.CheckBox chkPermitirFaturarPedido;
      private System.Windows.Forms.Label label61;
      private System.Windows.Forms.CheckBox chkPermitirSelecaoImpressoraExp;
      private System.Windows.Forms.CheckBox chkQtdFracionariaOP;
      private System.Windows.Forms.CheckBox chkSuprimirQtdUnitariaMaterialOP;
      private System.Windows.Forms.Label label62;
      private System.Windows.Forms.Button btnLogEasi;
      private System.Windows.Forms.TextBox txtDiretorioLogEasi;
      private System.Windows.Forms.Label label63;
      private System.Windows.Forms.GroupBox groupBox14;
      private IWTDotNetLib.IWTNumericUpDown nudEstoqueInventarioPrecoMedioMeses;
      private IWTDotNetLib.IWTLabel iwtLabel3;
      private IWTDotNetLib.IWTCheckBox chkEstoqueInventarioPrecoMedio;
      private IWTDotNetLib.IWTLabel iwtLabel2;
      private System.Windows.Forms.GroupBox groupBox15;
      private System.Windows.Forms.RadioButton rdbNumeroPedidoNaoIncluir;
      private System.Windows.Forms.RadioButton rdbNumeroPedidoObservacao;
      private System.Windows.Forms.RadioButton rdbNumeroPedidoDescricaoItem;
      private System.Windows.Forms.TabPage tabPage14;
      private System.Windows.Forms.GroupBox grbEtiquetaClienteZebra;
      private System.Windows.Forms.GroupBox grbEtiquetaClienteComum;
      private System.Windows.Forms.RadioButton rdbEtiquetaClienteComum;
      private System.Windows.Forms.RadioButton rdbEtiquetaClienteZebra;
      private System.Windows.Forms.ComboBox cmbEtiquetaClientePapel;
      private System.Windows.Forms.ComboBox cmbEtiquetaClienteImpressora;
      private System.Windows.Forms.Label label64;
      private System.Windows.Forms.Label label65;
      private System.Windows.Forms.GroupBox groupBox16;
      private IWTDotNetLib.IWTNumericUpDown nudEtiquetaAltura;
      private IWTDotNetLib.IWTNumericUpDown nudEtiquetaLinhas;
      private IWTDotNetLib.IWTLabel iwtLabel8;
      private IWTDotNetLib.IWTLabel iwtLabel9;
      private IWTDotNetLib.IWTLabel iwtLabel10;
      private IWTDotNetLib.IWTNumericUpDown nudEtiquetaColunas;
      private IWTDotNetLib.IWTNumericUpDown nudEtiquetaLargura;
      private IWTDotNetLib.IWTLabel iwtLabel11;
      private IWTDotNetLib.IWTNumericUpDown nudEtiquetaIntervaloVertical;
      private IWTDotNetLib.IWTNumericUpDown nudEtiquetaIntervaloHorizontal;
      private IWTDotNetLib.IWTLabel iwtLabel12;
      private IWTDotNetLib.IWTLabel iwtLabel13;
      private System.Windows.Forms.GroupBox groupBox17;
      private IWTDotNetLib.IWTNumericUpDown nudPapelAltura;
      private IWTDotNetLib.IWTNumericUpDown nudPapelMargemDireita;
      private IWTDotNetLib.IWTLabel iwtLabel4;
      private IWTDotNetLib.IWTLabel iwtLabel7;
      private IWTDotNetLib.IWTLabel iwtLabel6;
      private IWTDotNetLib.IWTNumericUpDown nudPapelMargemInferior;
      private IWTDotNetLib.IWTNumericUpDown nudPapelLargura;
      private IWTDotNetLib.IWTLabel iwtLabel5;
      private IWTDotNetLib.IWTNumericUpDown nudPapelMargemSuperior;
      private IWTDotNetLib.IWTNumericUpDown nudPapelMargemEsquerda;
      private IWTDotNetLib.IWTLabel iwtLabel14;
      private IWTDotNetLib.IWTLabel iwtLabel15;
      private IWTDotNetLib.IWTNumericUpDown nudResolucao;
      private IWTDotNetLib.IWTLabel iwtLabel16;
        private IWTDotNetLib.IWTLabel iwtLabel17;
        private IWTDotNetLib.IWTNumericUpDown nudAvisoItensSemPedido;
        private System.Windows.Forms.CheckBox chkAvisoItensSemPedido;
        private System.Windows.Forms.CheckBox chkDestinatarioConfiguracaoAutomatica;
        private System.Windows.Forms.GroupBox grbDestinatarioConfiguracaoAutomatica;
        private System.Windows.Forms.TextBox txtDestinatarioConfiguracaoAutomatica;
        private System.Windows.Forms.Label label66;
        private IWTDotNetLib.IWTCheckBox chkComprasPermitirPrazoDomingo;
        private IWTDotNetLib.IWTCheckBox chkComprasPermitirPrazoSabado;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.Label label67;
        private IWTDotNetLib.IWTLabel iwtLabel18;
        private IWTDotNetLib.IWTCheckBox chkEstoquePermitirCriacaoLocalEstoque;

        private System.Windows.Forms.CheckBox chkExigirDocumentosOpZerada;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.GroupBox groupBox18;
        private IWTDotNetLib.IWTRadioButton rdbTabelaPrecosAutomatico;
        private IWTDotNetLib.IWTRadioButton iwtRadioButton1;
        private IWTDotNetLib.IWTNumericUpDown nudTabelaPrecosHora;
        private IWTDotNetLib.IWTLabel iwtLabel19;
        private IWTDotNetLib.IWTNumericUpDown nudTabelaPrecosMinutos;
        private IWTDotNetLib.IWTLabel iwtLabel20;
        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.RadioButton rdbEtiquetaProdutoVertical;
        private System.Windows.Forms.RadioButton rdbEtiquetaProdutoHorizontal;
        private IWTDotNetLib.IWTLabel iwtLabel21;
        private IWTDotNetLib.IWTTextBox txtEstacaoAutomacao;
        private IWTDotNetLib.IWTLabel iwtLabel22;
        private IWTDotNetLib.IWTCheckBox chkPesoVolumeNFe;
        private IWTDotNetLib.IWTLabel iwtLabel23;
        private IWTDotNetLib.IWTCheckBox chkRegistrarAlteracoesPedido;
        private System.Windows.Forms.Label label70;
        private IWTDotNetLib.IWTCheckBox chkComprasContasRevisarPadraoFornecedores;
        private IWTDotNetLib.IWTCheckBox chkComprasFluxoAprovacao;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.NumericUpDown numDiasvalidadePrecoProduto;
        private IWTDotNetLib.IWTLabel iwtLabel24;
        private IWTDotNetLib.IWTCheckBox chkMarcarAutomaticamenteOcComDescontoParaNaoAtualizarPrecoProduto;
        private System.Windows.Forms.Label label72;
    }
}