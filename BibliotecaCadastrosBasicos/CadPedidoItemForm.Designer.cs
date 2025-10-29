using System.Windows.Forms;

namespace BibliotecaCadastrosBasicos
{
    partial class CadPedidoItemForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadPedidoItemForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ensOperacaoCompleta = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.object_b471de83_fc7c_41a4_afcc_245cbad138db = new IWTDotNetLib.IWTCheckBox(this.components);
            this.object_a07cbcd3_dae8_4fc4_8aa6_6a8d61fd128b = new IWTDotNetLib.IWTTextBox(this.components);
            this.nudPosicao = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.ensOperacao = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.ensCliente = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.btnDocumentosPedido = new IWTDotNetLib.IWTButton(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkFreteSemResponsavel = new IWTDotNetLib.IWTCheckBox(this.components);
            this.grpFreteResponsavel = new System.Windows.Forms.GroupBox();
            this.iwtRadioButton1 = new IWTDotNetLib.IWTRadioButton(this.components);
            this.iwtRadioButton2 = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbFreteSemFrete = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbFreteDestinatario = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbFreteEmitente = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbFreteTerceiros = new IWTDotNetLib.IWTRadioButton(this.components);
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rdbFreteNormal = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbFreteRateado = new IWTDotNetLib.IWTRadioButton(this.components);
            this.nudFrete = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.label11 = new IWTDotNetLib.IWTLabel(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label35 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtOrdemVenda = new IWTDotNetLib.IWTTextBox(this.components);
            this.txtProjeto = new IWTDotNetLib.IWTTextBox(this.components);
            this.label19 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtArmazenagem = new IWTDotNetLib.IWTTextBox(this.components);
            this.btnMateriaisCliente = new IWTDotNetLib.IWTButton(this.components);
            this.label20 = new IWTDotNetLib.IWTLabel(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.iwtLabel10 = new IWTDotNetLib.IWTLabel(this.components);
            this.ensPedidoClassificacao = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.cbxEntregaParc = new IWTDotNetLib.IWTCheckBox(this.components);
            this.cbxVolumeUnico = new IWTDotNetLib.IWTCheckBox(this.components);
            this.chkRastrearMP = new IWTDotNetLib.IWTCheckBox(this.components);
            this.chkExportacao = new IWTDotNetLib.IWTCheckBox(this.components);
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.ensCentroCustoLucro = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.ensFormaPagamento = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.ensContaBancaria = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.label33 = new IWTDotNetLib.IWTLabel(this.components);
            this.label9 = new IWTDotNetLib.IWTLabel(this.components);
            this.label32 = new IWTDotNetLib.IWTLabel(this.components);
            this.chkTipoKit = new IWTDotNetLib.IWTCheckBox(this.components);
            this.cmbTipoKit = new IWTDotNetLib.IWTComboBox(this.components);
            this.label8 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtInfoEspeciais = new IWTDotNetLib.IWTTextBox(this.components);
            this.label3 = new IWTDotNetLib.IWTLabel(this.components);
            this.label31 = new IWTDotNetLib.IWTLabel(this.components);
            this.dtpDataPedido = new IWTDotNetLib.IWTDateTimePicker(this.components);
            this.grbCancelamento = new System.Windows.Forms.GroupBox();
            this.txtCancelamentoJustificativa = new IWTDotNetLib.IWTTextBox(this.components);
            this.label30 = new IWTDotNetLib.IWTLabel(this.components);
            this.dtpCancelamentoData = new IWTDotNetLib.IWTDateTimePicker(this.components);
            this.label29 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtCancelamentoUsuario = new IWTDotNetLib.IWTTextBox(this.components);
            this.label26 = new IWTDotNetLib.IWTLabel(this.components);
            this.grbOriginais = new System.Windows.Forms.GroupBox();
            this.nudValorOriginal = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.label16 = new IWTDotNetLib.IWTLabel(this.components);
            this.dtpDataEntregaOriginal = new IWTDotNetLib.IWTDateTimePicker(this.components);
            this.label14 = new IWTDotNetLib.IWTLabel(this.components);
            this.gbxUrgente = new System.Windows.Forms.GroupBox();
            this.txtUrgenteInfos = new IWTDotNetLib.IWTTextBox(this.components);
            this.label13 = new IWTDotNetLib.IWTLabel(this.components);
            this.dtpUrgenteData = new IWTDotNetLib.IWTDateTimePicker(this.components);
            this.label12 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtUrgenteSolicitante = new IWTDotNetLib.IWTTextBox(this.components);
            this.label6 = new IWTDotNetLib.IWTLabel(this.components);
            this.rdbUrgenteCritico = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbUrgenteUrgente = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbUrgenteAntecipacao = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbUrgenteNormal = new IWTDotNetLib.IWTRadioButton(this.components);
            this.btnVariaveis = new IWTDotNetLib.IWTButton(this.components);
            this.label22 = new IWTDotNetLib.IWTLabel(this.components);
            this.dtpDataEntrega = new IWTDotNetLib.IWTDateTimePicker(this.components);
            this.label7 = new IWTDotNetLib.IWTLabel(this.components);
            this.label17 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtOc = new IWTDotNetLib.IWTMaskedTextBox(this.components);
            this.label23 = new IWTDotNetLib.IWTLabel(this.components);
            this.label18 = new IWTDotNetLib.IWTLabel(this.components);
            this.gbxPrincipal = new System.Windows.Forms.GroupBox();
            this.iwtLabel9 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudDesconto = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.lnkEstrutura = new System.Windows.Forms.LinkLabel();
            this.ensNCM = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.ensItemPrincipal = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.lnkDetalhesPrincipal = new System.Windows.Forms.LinkLabel();
            this.lblTotal = new IWTDotNetLib.IWTLabel(this.components);
            this.label21 = new IWTDotNetLib.IWTLabel(this.components);
            this.label15 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudValorUnit = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.label5 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudQtd = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.txtDescricao = new IWTDotNetLib.IWTTextBox(this.components);
            this.label2 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtCodigo = new IWTDotNetLib.IWTTextBox(this.components);
            this.label4 = new IWTDotNetLib.IWTLabel(this.components);
            this.gbxItem = new System.Windows.Forms.GroupBox();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.ensSubItem = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.chk = new IWTDotNetLib.IWTCheckBox(this.components);
            this.txt = new IWTDotNetLib.IWTTextBox(this.components);
            this.lnkDetalhesSub = new System.Windows.Forms.LinkLabel();
            this.btnEditarItem = new IWTDotNetLib.IWTButton(this.components);
            this.label28 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtCodigoItem = new IWTDotNetLib.IWTTextBox(this.components);
            this.label27 = new IWTDotNetLib.IWTLabel(this.components);
            this.label10 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtDescricaoItem = new IWTDotNetLib.IWTTextBox(this.components);
            this.nudQtdItem = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.label25 = new IWTDotNetLib.IWTLabel(this.components);
            this.btnAdicionar = new IWTDotNetLib.IWTButton(this.components);
            this.btnRemover = new IWTDotNetLib.IWTButton(this.components);
            this.btnConfirmarEdicao = new IWTDotNetLib.IWTButton(this.components);
            this.dataGridView1 = new IWTDotNetLib.IWTDataGridView(this.components);
            this.Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProdutoCodigoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProdutoDescricaoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label24 = new IWTDotNetLib.IWTLabel(this.components);
            this.comboBox4 = new IWTDotNetLib.IWTComboBox(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.rdbEmissorNFeSecundario = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbEmissorNFePrimario = new IWTDotNetLib.IWTRadioButton(this.components);
            this.iwtLabel5 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtTextBox1 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel4 = new IWTDotNetLib.IWTLabel(this.components);
            this.grbFeedback = new System.Windows.Forms.GroupBox();
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this.dgvFeedbacks = new IWTDotNetLib.IWTDataGridView(this.components);
            this.btnFeedbackOk = new IWTDotNetLib.IWTButton(this.components);
            this.txtFeedback = new IWTDotNetLib.IWTTextBox(this.components);
            this.label37 = new IWTDotNetLib.IWTLabel(this.components);
            this.btnFeedbackAdicionar = new IWTDotNetLib.IWTButton(this.components);
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtObservacaoEspelhoPed = new IWTDotNetLib.IWTTextBox(this.components);
            this.label36 = new IWTDotNetLib.IWTLabel(this.components);
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.grpComissaoVendedor = new System.Windows.Forms.GroupBox();
            this.ensVendedor = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.iwtLabel2 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudComissaoVendedor = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.iwtLabel3 = new IWTDotNetLib.IWTLabel(this.components);
            this.grpComissaoRepresentante = new System.Windows.Forms.GroupBox();
            this.ensRepresentante = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudComissaoRepresentante = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.label34 = new IWTDotNetLib.IWTLabel(this.components);
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.dgPedidoItemQualidade = new IWTDotNetLib.IWTDataGridView(this.components);
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toDelete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new IWTDotNetLib.IWTButton(this.components);
            this.btnDownload = new IWTDotNetLib.IWTButton(this.components);
            this.btnRemove = new IWTDotNetLib.IWTButton(this.components);
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.ensOperacaoCompletaEnvioTerceiros = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.lblOperacaoCompletaEnvioTerceiros = new IWTDotNetLib.IWTLabel(this.components);
            this.ensOperacaoEnvioTerceiros = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.lblOperacaoEnvioTerceiros = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel8 = new IWTDotNetLib.IWTLabel(this.components);
            this.ensClienteEnvioTerceiros = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.iwtLabel7 = new IWTDotNetLib.IWTLabel(this.components);
            this.chkEnvioTerceiros = new IWTDotNetLib.IWTCheckBox(this.components);
            this.tabHistoricoAlteracoes = new System.Windows.Forms.TabPage();
            this.dgvHistoricoAlteracoes = new IWTDotNetLib.IWTDataGridView(this.components);
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PedidoItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Justificativa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabFeedbackSecundario = new System.Windows.Forms.TabPage();
            this.grbFeedbackSecundario = new System.Windows.Forms.GroupBox();
            this.splitContainer7 = new System.Windows.Forms.SplitContainer();
            this.dgvFeedbacksSecundarios = new IWTDotNetLib.IWTDataGridView(this.components);
            this.btnFeedbackSecundarioOk = new IWTDotNetLib.IWTButton(this.components);
            this.txtFeedbackSecundario = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel11 = new IWTDotNetLib.IWTLabel(this.components);
            this.btnFeedbackSecundarioAdicionar = new IWTDotNetLib.IWTButton(this.components);
            this.btnCopiar = new IWTDotNetLib.IWTButton(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.possuiProdutosVencidosLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.ensOperacaoCompleta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPosicao)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.grpFreteResponsavel.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFrete)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDataPedido)).BeginInit();
            this.grbCancelamento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpCancelamentoData)).BeginInit();
            this.grbOriginais.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudValorOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDataEntregaOriginal)).BeginInit();
            this.gbxUrgente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpUrgenteData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDataEntrega)).BeginInit();
            this.gbxPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDesconto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudValorUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQtd)).BeginInit();
            this.gbxItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.ensSubItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQtdItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.grbFeedback.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).BeginInit();
            this.splitContainer6.Panel1.SuspendLayout();
            this.splitContainer6.Panel2.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeedbacks)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.grpComissaoVendedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudComissaoVendedor)).BeginInit();
            this.grpComissaoRepresentante.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudComissaoRepresentante)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPedidoItemQualidade)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.tabHistoricoAlteracoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoricoAlteracoes)).BeginInit();
            this.tabFeedbackSecundario.SuspendLayout();
            this.grbFeedbackSecundario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).BeginInit();
            this.splitContainer7.Panel1.SuspendLayout();
            this.splitContainer7.Panel2.SuspendLayout();
            this.splitContainer7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeedbacksSecundarios)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.possuiProdutosVencidosLbl);
            this.splitContainer1.Panel2.Controls.Add(this.btnCopiar);
            this.splitContainer1.Size = new System.Drawing.Size(1095, 726);
            this.splitContainer1.SplitterDistance = 675;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(12, 12);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(1013, 12);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabHistoricoAlteracoes);
            this.tabControl1.Controls.Add(this.tabFeedbackSecundario);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1095, 675);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.splitContainer2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1087, 649);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dados do Pedido";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gbxItem);
            this.splitContainer2.Size = new System.Drawing.Size(1081, 643);
            this.splitContainer2.SplitterDistance = 452;
            this.splitContainer2.TabIndex = 1;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.gbxPrincipal);
            this.splitContainer3.Size = new System.Drawing.Size(1081, 452);
            this.splitContainer3.SplitterDistance = 381;
            this.splitContainer3.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ensOperacaoCompleta);
            this.groupBox1.Controls.Add(this.nudPosicao);
            this.groupBox1.Controls.Add(this.ensOperacao);
            this.groupBox1.Controls.Add(this.ensCliente);
            this.groupBox1.Controls.Add(this.btnDocumentosPedido);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox7);
            this.groupBox1.Controls.Add(this.chkTipoKit);
            this.groupBox1.Controls.Add(this.cmbTipoKit);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtInfoEspeciais);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label31);
            this.groupBox1.Controls.Add(this.dtpDataPedido);
            this.groupBox1.Controls.Add(this.grbCancelamento);
            this.groupBox1.Controls.Add(this.grbOriginais);
            this.groupBox1.Controls.Add(this.gbxUrgente);
            this.groupBox1.Controls.Add(this.rdbUrgenteCritico);
            this.groupBox1.Controls.Add(this.rdbUrgenteUrgente);
            this.groupBox1.Controls.Add(this.rdbUrgenteAntecipacao);
            this.groupBox1.Controls.Add(this.rdbUrgenteNormal);
            this.groupBox1.Controls.Add(this.btnVariaveis);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.dtpDataEntrega);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.txtOc);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1081, 381);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pedido";
            // 
            // ensOperacaoCompleta
            // 
            this.ensOperacaoCompleta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ensOperacaoCompleta.BindingField = "OperacaoCompleta";
            this.ensOperacaoCompleta.ColunasDropdown = null;
            this.ensOperacaoCompleta.Controls.Add(this.object_b471de83_fc7c_41a4_afcc_245cbad138db);
            this.ensOperacaoCompleta.Controls.Add(this.object_a07cbcd3_dae8_4fc4_8aa6_6a8d61fd128b);
            this.ensOperacaoCompleta.DesabilitarAutoCompletar = false;
            this.ensOperacaoCompleta.DesabilitarChekBox = true;
            this.ensOperacaoCompleta.DesabilitarLupa = false;
            this.ensOperacaoCompleta.DesabilitarSeta = false;
            this.ensOperacaoCompleta.EntidadeSelecionada = null;
            this.ensOperacaoCompleta.FormSelecao = null;
            this.ensOperacaoCompleta.LiberadoQuandoCadastroUtilizado = false;
            this.ensOperacaoCompleta.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensOperacaoCompleta.Location = new System.Drawing.Point(80, 44);
            this.ensOperacaoCompleta.ModoVisualizacaoGrid = null;
            this.ensOperacaoCompleta.Name = "ensOperacaoCompleta";
            this.ensOperacaoCompleta.ParametroBuscaGuiada = null;
            this.ensOperacaoCompleta.ParametrosBuscaObrigatorios = null;
            this.ensOperacaoCompleta.Size = new System.Drawing.Size(247, 23);
            this.ensOperacaoCompleta.TabIndex = 78;
            // 
            // object_b471de83_fc7c_41a4_afcc_245cbad138db
            // 
            this.object_b471de83_fc7c_41a4_afcc_245cbad138db.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.object_b471de83_fc7c_41a4_afcc_245cbad138db.AutoSize = true;
            this.object_b471de83_fc7c_41a4_afcc_245cbad138db.BindingField = "";
            this.object_b471de83_fc7c_41a4_afcc_245cbad138db.Checked = true;
            this.object_b471de83_fc7c_41a4_afcc_245cbad138db.CheckState = System.Windows.Forms.CheckState.Checked;
            this.object_b471de83_fc7c_41a4_afcc_245cbad138db.LiberadoQuandoCadastroUtilizado = false;
            this.object_b471de83_fc7c_41a4_afcc_245cbad138db.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.object_b471de83_fc7c_41a4_afcc_245cbad138db.Location = new System.Drawing.Point(368, 4);
            this.object_b471de83_fc7c_41a4_afcc_245cbad138db.Name = "object_b471de83_fc7c_41a4_afcc_245cbad138db";
            this.object_b471de83_fc7c_41a4_afcc_245cbad138db.Size = new System.Drawing.Size(15, 14);
            this.object_b471de83_fc7c_41a4_afcc_245cbad138db.TabIndex = 1;
            this.object_b471de83_fc7c_41a4_afcc_245cbad138db.UseVisualStyleBackColor = true;
            this.object_b471de83_fc7c_41a4_afcc_245cbad138db.Visible = false;
            // 
            // object_a07cbcd3_dae8_4fc4_8aa6_6a8d61fd128b
            // 
            this.object_a07cbcd3_dae8_4fc4_8aa6_6a8d61fd128b.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.object_a07cbcd3_dae8_4fc4_8aa6_6a8d61fd128b.BindingField = "";
            this.object_a07cbcd3_dae8_4fc4_8aa6_6a8d61fd128b.DebugMode = false;
            this.object_a07cbcd3_dae8_4fc4_8aa6_6a8d61fd128b.LiberadoQuandoCadastroUtilizado = false;
            this.object_a07cbcd3_dae8_4fc4_8aa6_6a8d61fd128b.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.object_a07cbcd3_dae8_4fc4_8aa6_6a8d61fd128b.Location = new System.Drawing.Point(0, 1);
            this.object_a07cbcd3_dae8_4fc4_8aa6_6a8d61fd128b.ModoBarcode = false;
            this.object_a07cbcd3_dae8_4fc4_8aa6_6a8d61fd128b.ModoBusca = false;
            this.object_a07cbcd3_dae8_4fc4_8aa6_6a8d61fd128b.Name = "object_a07cbcd3_dae8_4fc4_8aa6_6a8d61fd128b";
            this.object_a07cbcd3_dae8_4fc4_8aa6_6a8d61fd128b.NaoLimparDepoisBarcode = false;
            this.object_a07cbcd3_dae8_4fc4_8aa6_6a8d61fd128b.Size = new System.Drawing.Size(351, 20);
            this.object_a07cbcd3_dae8_4fc4_8aa6_6a8d61fd128b.TabIndex = 3;
            // 
            // nudPosicao
            // 
            this.nudPosicao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudPosicao.BindingField = "Posicao";
            this.nudPosicao.LiberadoQuandoCadastroUtilizado = false;
            this.nudPosicao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudPosicao.Location = new System.Drawing.Point(531, 19);
            this.nudPosicao.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudPosicao.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPosicao.Name = "nudPosicao";
            this.nudPosicao.Size = new System.Drawing.Size(48, 20);
            this.nudPosicao.TabIndex = 77;
            this.nudPosicao.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ensOperacao
            // 
            this.ensOperacao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ensOperacao.BindingField = "Operacao";
            this.ensOperacao.ColunasDropdown = null;
            this.ensOperacao.DesabilitarAutoCompletar = false;
            this.ensOperacao.DesabilitarChekBox = true;
            this.ensOperacao.DesabilitarLupa = false;
            this.ensOperacao.DesabilitarSeta = false;
            this.ensOperacao.EntidadeSelecionada = null;
            this.ensOperacao.FormSelecao = null;
            this.ensOperacao.LiberadoQuandoCadastroUtilizado = false;
            this.ensOperacao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensOperacao.Location = new System.Drawing.Point(80, 44);
            this.ensOperacao.ModoVisualizacaoGrid = null;
            this.ensOperacao.Name = "ensOperacao";
            this.ensOperacao.ParametroBuscaGuiada = null;
            this.ensOperacao.ParametrosBuscaObrigatorios = null;
            this.ensOperacao.Size = new System.Drawing.Size(247, 23);
            this.ensOperacao.TabIndex = 76;
            // 
            // ensCliente
            // 
            this.ensCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ensCliente.BindingField = "Cliente";
            this.ensCliente.ColunasDropdown = null;
            this.ensCliente.DesabilitarAutoCompletar = false;
            this.ensCliente.DesabilitarChekBox = true;
            this.ensCliente.DesabilitarLupa = false;
            this.ensCliente.DesabilitarSeta = false;
            this.ensCliente.EntidadeSelecionada = null;
            this.ensCliente.FormSelecao = null;
            this.ensCliente.LiberadoQuandoCadastroUtilizado = false;
            this.ensCliente.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensCliente.Location = new System.Drawing.Point(81, 16);
            this.ensCliente.ModoVisualizacaoGrid = null;
            this.ensCliente.Name = "ensCliente";
            this.ensCliente.ParametroBuscaGuiada = null;
            this.ensCliente.ParametrosBuscaObrigatorios = null;
            this.ensCliente.Size = new System.Drawing.Size(238, 23);
            this.ensCliente.TabIndex = 0;
            this.ensCliente.EntityChange += new System.EventHandler(this.ensCliente_EntityChange);
            // 
            // btnDocumentosPedido
            // 
            this.btnDocumentosPedido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDocumentosPedido.Enabled = false;
            this.btnDocumentosPedido.LiberadoQuandoCadastroUtilizado = false;
            this.btnDocumentosPedido.Location = new System.Drawing.Point(939, 345);
            this.btnDocumentosPedido.Name = "btnDocumentosPedido";
            this.btnDocumentosPedido.Size = new System.Drawing.Size(130, 23);
            this.btnDocumentosPedido.TabIndex = 20;
            this.btnDocumentosPedido.Text = "Documentos do Pedido";
            this.btnDocumentosPedido.UseVisualStyleBackColor = true;
            this.btnDocumentosPedido.Click += new System.EventHandler(this.btnDocumentosPedido_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.chkFreteSemResponsavel);
            this.groupBox4.Controls.Add(this.grpFreteResponsavel);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.nudFrete);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Location = new System.Drawing.Point(307, 69);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(482, 111);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Frete";
            // 
            // chkFreteSemResponsavel
            // 
            this.chkFreteSemResponsavel.AutoSize = true;
            this.chkFreteSemResponsavel.BindingField = "UtilizarResponsavelFreteDoProduto";
            this.chkFreteSemResponsavel.Checked = true;
            this.chkFreteSemResponsavel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFreteSemResponsavel.LiberadoQuandoCadastroUtilizado = false;
            this.chkFreteSemResponsavel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkFreteSemResponsavel.Location = new System.Drawing.Point(138, 17);
            this.chkFreteSemResponsavel.Name = "chkFreteSemResponsavel";
            this.chkFreteSemResponsavel.Size = new System.Drawing.Size(177, 17);
            this.chkFreteSemResponsavel.TabIndex = 6;
            this.chkFreteSemResponsavel.Text = "Utilizar Responsável do Produto";
            this.chkFreteSemResponsavel.UseVisualStyleBackColor = true;
            this.chkFreteSemResponsavel.CheckedChanged += new System.EventHandler(this.chkFreteSemResponsavel_CheckedChanged);
            // 
            // grpFreteResponsavel
            // 
            this.grpFreteResponsavel.Controls.Add(this.iwtRadioButton1);
            this.grpFreteResponsavel.Controls.Add(this.iwtRadioButton2);
            this.grpFreteResponsavel.Controls.Add(this.rdbFreteSemFrete);
            this.grpFreteResponsavel.Controls.Add(this.rdbFreteDestinatario);
            this.grpFreteResponsavel.Controls.Add(this.rdbFreteEmitente);
            this.grpFreteResponsavel.Controls.Add(this.rdbFreteTerceiros);
            this.grpFreteResponsavel.Enabled = false;
            this.grpFreteResponsavel.Location = new System.Drawing.Point(137, 42);
            this.grpFreteResponsavel.Name = "grpFreteResponsavel";
            this.grpFreteResponsavel.Size = new System.Drawing.Size(339, 57);
            this.grpFreteResponsavel.TabIndex = 5;
            this.grpFreteResponsavel.TabStop = false;
            this.grpFreteResponsavel.Text = "Responsável";
            // 
            // iwtRadioButton1
            // 
            this.iwtRadioButton1.AutoSize = true;
            this.iwtRadioButton1.BindingField = "ResponsavelFrete_ProprioRemetente";
            this.iwtRadioButton1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtRadioButton1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtRadioButton1.Location = new System.Drawing.Point(207, 16);
            this.iwtRadioButton1.Name = "iwtRadioButton1";
            this.iwtRadioButton1.Size = new System.Drawing.Size(113, 17);
            this.iwtRadioButton1.TabIndex = 4;
            this.iwtRadioButton1.TabStop = true;
            this.iwtRadioButton1.Text = "Próprio Remetente";
            this.iwtRadioButton1.UseVisualStyleBackColor = true;
            // 
            // iwtRadioButton2
            // 
            this.iwtRadioButton2.AutoSize = true;
            this.iwtRadioButton2.BindingField = "ResponsavelFrete_ProprioDestinatario";
            this.iwtRadioButton2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtRadioButton2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtRadioButton2.Location = new System.Drawing.Point(207, 33);
            this.iwtRadioButton2.Name = "iwtRadioButton2";
            this.iwtRadioButton2.Size = new System.Drawing.Size(117, 17);
            this.iwtRadioButton2.TabIndex = 5;
            this.iwtRadioButton2.TabStop = true;
            this.iwtRadioButton2.Text = "Próprio Destinatário";
            this.iwtRadioButton2.UseVisualStyleBackColor = true;
            // 
            // rdbFreteSemFrete
            // 
            this.rdbFreteSemFrete.AutoSize = true;
            this.rdbFreteSemFrete.BindingField = "ResponsavelFrete_SemFrete";
            this.rdbFreteSemFrete.LiberadoQuandoCadastroUtilizado = false;
            this.rdbFreteSemFrete.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbFreteSemFrete.Location = new System.Drawing.Point(114, 32);
            this.rdbFreteSemFrete.Name = "rdbFreteSemFrete";
            this.rdbFreteSemFrete.Size = new System.Drawing.Size(64, 17);
            this.rdbFreteSemFrete.TabIndex = 3;
            this.rdbFreteSemFrete.TabStop = true;
            this.rdbFreteSemFrete.Text = "S/ Frete";
            this.rdbFreteSemFrete.UseVisualStyleBackColor = true;
            // 
            // rdbFreteDestinatario
            // 
            this.rdbFreteDestinatario.AutoSize = true;
            this.rdbFreteDestinatario.BindingField = "ResponsavelFrete_Cliente";
            this.rdbFreteDestinatario.LiberadoQuandoCadastroUtilizado = false;
            this.rdbFreteDestinatario.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbFreteDestinatario.Location = new System.Drawing.Point(22, 33);
            this.rdbFreteDestinatario.Name = "rdbFreteDestinatario";
            this.rdbFreteDestinatario.Size = new System.Drawing.Size(81, 17);
            this.rdbFreteDestinatario.TabIndex = 1;
            this.rdbFreteDestinatario.Text = "Destinatário";
            this.rdbFreteDestinatario.UseVisualStyleBackColor = true;
            // 
            // rdbFreteEmitente
            // 
            this.rdbFreteEmitente.AutoSize = true;
            this.rdbFreteEmitente.BindingField = "ResponsavelFrete_Emitente";
            this.rdbFreteEmitente.Checked = true;
            this.rdbFreteEmitente.LiberadoQuandoCadastroUtilizado = false;
            this.rdbFreteEmitente.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbFreteEmitente.Location = new System.Drawing.Point(22, 15);
            this.rdbFreteEmitente.Name = "rdbFreteEmitente";
            this.rdbFreteEmitente.Size = new System.Drawing.Size(66, 17);
            this.rdbFreteEmitente.TabIndex = 0;
            this.rdbFreteEmitente.TabStop = true;
            this.rdbFreteEmitente.Text = "Emitente";
            this.rdbFreteEmitente.UseVisualStyleBackColor = true;
            // 
            // rdbFreteTerceiros
            // 
            this.rdbFreteTerceiros.AutoSize = true;
            this.rdbFreteTerceiros.BindingField = "ResponsavelFrete_Terceiros";
            this.rdbFreteTerceiros.LiberadoQuandoCadastroUtilizado = false;
            this.rdbFreteTerceiros.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbFreteTerceiros.Location = new System.Drawing.Point(114, 15);
            this.rdbFreteTerceiros.Name = "rdbFreteTerceiros";
            this.rdbFreteTerceiros.Size = new System.Drawing.Size(69, 17);
            this.rdbFreteTerceiros.TabIndex = 2;
            this.rdbFreteTerceiros.TabStop = true;
            this.rdbFreteTerceiros.Text = "Terceiros";
            this.rdbFreteTerceiros.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rdbFreteNormal);
            this.groupBox5.Controls.Add(this.rdbFreteRateado);
            this.groupBox5.Location = new System.Drawing.Point(12, 42);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(118, 57);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Tipo";
            // 
            // rdbFreteNormal
            // 
            this.rdbFreteNormal.AutoSize = true;
            this.rdbFreteNormal.BindingField = "FormaFrete_Normal";
            this.rdbFreteNormal.Checked = true;
            this.rdbFreteNormal.LiberadoQuandoCadastroUtilizado = false;
            this.rdbFreteNormal.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbFreteNormal.Location = new System.Drawing.Point(10, 16);
            this.rdbFreteNormal.Name = "rdbFreteNormal";
            this.rdbFreteNormal.Size = new System.Drawing.Size(58, 17);
            this.rdbFreteNormal.TabIndex = 3;
            this.rdbFreteNormal.TabStop = true;
            this.rdbFreteNormal.Text = "Normal";
            this.rdbFreteNormal.UseVisualStyleBackColor = true;
            // 
            // rdbFreteRateado
            // 
            this.rdbFreteRateado.AutoSize = true;
            this.rdbFreteRateado.BindingField = "FormaFrete_RateadoItens";
            this.rdbFreteRateado.LiberadoQuandoCadastroUtilizado = false;
            this.rdbFreteRateado.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbFreteRateado.Location = new System.Drawing.Point(10, 36);
            this.rdbFreteRateado.Name = "rdbFreteRateado";
            this.rdbFreteRateado.Size = new System.Drawing.Size(92, 17);
            this.rdbFreteRateado.TabIndex = 0;
            this.rdbFreteRateado.Text = "Rateado Itens";
            this.rdbFreteRateado.UseVisualStyleBackColor = true;
            // 
            // nudFrete
            // 
            this.nudFrete.BindingField = "Frete";
            this.nudFrete.DecimalPlaces = 4;
            this.nudFrete.LiberadoQuandoCadastroUtilizado = false;
            this.nudFrete.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudFrete.Location = new System.Drawing.Point(42, 16);
            this.nudFrete.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudFrete.Name = "nudFrete";
            this.nudFrete.Size = new System.Drawing.Size(88, 20);
            this.nudFrete.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BindingField = null;
            this.label11.LiberadoQuandoCadastroUtilizado = false;
            this.label11.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label11.Location = new System.Drawing.Point(11, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Valor";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label35);
            this.groupBox2.Controls.Add(this.txtOrdemVenda);
            this.groupBox2.Controls.Add(this.txtProjeto);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.txtArmazenagem);
            this.groupBox2.Controls.Add(this.btnMateriaisCliente);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Location = new System.Drawing.Point(400, 300);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(533, 75);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Informações do Cliente";
            // 
            // label35
            // 
            this.label35.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label35.AutoSize = true;
            this.label35.BindingField = null;
            this.label35.LiberadoQuandoCadastroUtilizado = false;
            this.label35.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label35.Location = new System.Drawing.Point(296, 21);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(72, 13);
            this.label35.TabIndex = 50;
            this.label35.Text = "Ordem Venda";
            // 
            // txtOrdemVenda
            // 
            this.txtOrdemVenda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOrdemVenda.BindingField = "OrdemVenda";
            this.txtOrdemVenda.DebugMode = false;
            this.txtOrdemVenda.LiberadoQuandoCadastroUtilizado = false;
            this.txtOrdemVenda.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtOrdemVenda.Location = new System.Drawing.Point(374, 17);
            this.txtOrdemVenda.MaxLength = 50;
            this.txtOrdemVenda.ModoBarcode = false;
            this.txtOrdemVenda.ModoBusca = false;
            this.txtOrdemVenda.Name = "txtOrdemVenda";
            this.txtOrdemVenda.NaoLimparDepoisBarcode = false;
            this.txtOrdemVenda.Size = new System.Drawing.Size(153, 20);
            this.txtOrdemVenda.TabIndex = 49;
            // 
            // txtProjeto
            // 
            this.txtProjeto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProjeto.BindingField = "ProjetoCliente";
            this.txtProjeto.DebugMode = false;
            this.txtProjeto.LiberadoQuandoCadastroUtilizado = false;
            this.txtProjeto.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtProjeto.Location = new System.Drawing.Point(84, 16);
            this.txtProjeto.MaxLength = 255;
            this.txtProjeto.ModoBarcode = false;
            this.txtProjeto.ModoBusca = false;
            this.txtProjeto.Name = "txtProjeto";
            this.txtProjeto.NaoLimparDepoisBarcode = false;
            this.txtProjeto.Size = new System.Drawing.Size(195, 20);
            this.txtProjeto.TabIndex = 0;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BindingField = null;
            this.label19.LiberadoQuandoCadastroUtilizado = false;
            this.label19.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label19.Location = new System.Drawing.Point(38, 19);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(40, 13);
            this.label19.TabIndex = 46;
            this.label19.Text = "Projeto";
            // 
            // txtArmazenagem
            // 
            this.txtArmazenagem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtArmazenagem.BindingField = "ArmazenagemCliente";
            this.txtArmazenagem.DebugMode = false;
            this.txtArmazenagem.LiberadoQuandoCadastroUtilizado = false;
            this.txtArmazenagem.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtArmazenagem.Location = new System.Drawing.Point(84, 42);
            this.txtArmazenagem.MaxLength = 255;
            this.txtArmazenagem.ModoBarcode = false;
            this.txtArmazenagem.ModoBusca = false;
            this.txtArmazenagem.Name = "txtArmazenagem";
            this.txtArmazenagem.NaoLimparDepoisBarcode = false;
            this.txtArmazenagem.Size = new System.Drawing.Size(195, 20);
            this.txtArmazenagem.TabIndex = 1;
            // 
            // btnMateriaisCliente
            // 
            this.btnMateriaisCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMateriaisCliente.LiberadoQuandoCadastroUtilizado = false;
            this.btnMateriaisCliente.Location = new System.Drawing.Point(285, 42);
            this.btnMateriaisCliente.Name = "btnMateriaisCliente";
            this.btnMateriaisCliente.Size = new System.Drawing.Size(242, 23);
            this.btnMateriaisCliente.TabIndex = 2;
            this.btnMateriaisCliente.Text = "Materiais enviados pelo Cliente/Industrialização";
            this.btnMateriaisCliente.UseVisualStyleBackColor = true;
            this.btnMateriaisCliente.Click += new System.EventHandler(this.btnMateriaisCliente_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BindingField = null;
            this.label20.LiberadoQuandoCadastroUtilizado = false;
            this.label20.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label20.Location = new System.Drawing.Point(4, 45);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(74, 13);
            this.label20.TabIndex = 48;
            this.label20.Text = "Armazenagem";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.iwtLabel10);
            this.groupBox3.Controls.Add(this.ensPedidoClassificacao);
            this.groupBox3.Controls.Add(this.cbxEntregaParc);
            this.groupBox3.Controls.Add(this.cbxVolumeUnico);
            this.groupBox3.Controls.Add(this.chkRastrearMP);
            this.groupBox3.Controls.Add(this.chkExportacao);
            this.groupBox3.Location = new System.Drawing.Point(8, 99);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(293, 81);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Configurações";
            // 
            // iwtLabel10
            // 
            this.iwtLabel10.AutoSize = true;
            this.iwtLabel10.BindingField = null;
            this.iwtLabel10.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel10.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel10.Location = new System.Drawing.Point(2, 60);
            this.iwtLabel10.Name = "iwtLabel10";
            this.iwtLabel10.Size = new System.Drawing.Size(69, 13);
            this.iwtLabel10.TabIndex = 5;
            this.iwtLabel10.Text = "Classificação";
            // 
            // ensPedidoClassificacao
            // 
            this.ensPedidoClassificacao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ensPedidoClassificacao.BindingField = "PedidoClassificacao";
            this.ensPedidoClassificacao.ColunasDropdown = null;
            this.ensPedidoClassificacao.DesabilitarAutoCompletar = false;
            this.ensPedidoClassificacao.DesabilitarChekBox = false;
            this.ensPedidoClassificacao.DesabilitarLupa = false;
            this.ensPedidoClassificacao.DesabilitarSeta = false;
            this.ensPedidoClassificacao.EntidadeSelecionada = null;
            this.ensPedidoClassificacao.FormSelecao = null;
            this.ensPedidoClassificacao.LiberadoQuandoCadastroUtilizado = false;
            this.ensPedidoClassificacao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensPedidoClassificacao.Location = new System.Drawing.Point(73, 54);
            this.ensPedidoClassificacao.ModoVisualizacaoGrid = null;
            this.ensPedidoClassificacao.Name = "ensPedidoClassificacao";
            this.ensPedidoClassificacao.ParametroBuscaGuiada = null;
            this.ensPedidoClassificacao.ParametrosBuscaObrigatorios = null;
            this.ensPedidoClassificacao.Size = new System.Drawing.Size(214, 23);
            this.ensPedidoClassificacao.TabIndex = 4;
            // 
            // cbxEntregaParc
            // 
            this.cbxEntregaParc.AutoSize = true;
            this.cbxEntregaParc.BindingField = "PermiteEntregaParcial";
            this.cbxEntregaParc.Checked = true;
            this.cbxEntregaParc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxEntregaParc.LiberadoQuandoCadastroUtilizado = false;
            this.cbxEntregaParc.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.cbxEntregaParc.Location = new System.Drawing.Point(14, 21);
            this.cbxEntregaParc.Name = "cbxEntregaParc";
            this.cbxEntregaParc.Size = new System.Drawing.Size(136, 17);
            this.cbxEntregaParc.TabIndex = 0;
            this.cbxEntregaParc.Text = "Permite Entrega Parcial";
            this.cbxEntregaParc.UseVisualStyleBackColor = true;
            // 
            // cbxVolumeUnico
            // 
            this.cbxVolumeUnico.AutoSize = true;
            this.cbxVolumeUnico.BindingField = "VolumeUnico";
            this.cbxVolumeUnico.Checked = true;
            this.cbxVolumeUnico.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxVolumeUnico.LiberadoQuandoCadastroUtilizado = false;
            this.cbxVolumeUnico.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.cbxVolumeUnico.Location = new System.Drawing.Point(14, 38);
            this.cbxVolumeUnico.Name = "cbxVolumeUnico";
            this.cbxVolumeUnico.Size = new System.Drawing.Size(92, 17);
            this.cbxVolumeUnico.TabIndex = 1;
            this.cbxVolumeUnico.Text = "Volume Único";
            this.cbxVolumeUnico.UseVisualStyleBackColor = true;
            // 
            // chkRastrearMP
            // 
            this.chkRastrearMP.AutoSize = true;
            this.chkRastrearMP.BindingField = "RastreamentoMaterial";
            this.chkRastrearMP.LiberadoQuandoCadastroUtilizado = false;
            this.chkRastrearMP.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkRastrearMP.Location = new System.Drawing.Point(156, 38);
            this.chkRastrearMP.Name = "chkRastrearMP";
            this.chkRastrearMP.Size = new System.Drawing.Size(133, 17);
            this.chkRastrearMP.TabIndex = 3;
            this.chkRastrearMP.Text = "Rastrear Matéria Prima";
            this.chkRastrearMP.UseVisualStyleBackColor = true;
            // 
            // chkExportacao
            // 
            this.chkExportacao.AutoSize = true;
            this.chkExportacao.BindingField = "Exportacao";
            this.chkExportacao.LiberadoQuandoCadastroUtilizado = false;
            this.chkExportacao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkExportacao.Location = new System.Drawing.Point(156, 21);
            this.chkExportacao.Name = "chkExportacao";
            this.chkExportacao.Size = new System.Drawing.Size(80, 17);
            this.chkExportacao.TabIndex = 2;
            this.chkExportacao.Text = "Exportação";
            this.chkExportacao.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.ensCentroCustoLucro);
            this.groupBox7.Controls.Add(this.ensFormaPagamento);
            this.groupBox7.Controls.Add(this.ensContaBancaria);
            this.groupBox7.Controls.Add(this.label33);
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Controls.Add(this.label32);
            this.groupBox7.Location = new System.Drawing.Point(8, 186);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(869, 108);
            this.groupBox7.TabIndex = 17;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Informações Financeiras";
            // 
            // ensCentroCustoLucro
            // 
            this.ensCentroCustoLucro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ensCentroCustoLucro.BindingField = "CentroCustoLucro";
            this.ensCentroCustoLucro.ColunasDropdown = null;
            this.ensCentroCustoLucro.DesabilitarAutoCompletar = false;
            this.ensCentroCustoLucro.DesabilitarChekBox = false;
            this.ensCentroCustoLucro.DesabilitarLupa = false;
            this.ensCentroCustoLucro.DesabilitarSeta = false;
            this.ensCentroCustoLucro.Enabled = false;
            this.ensCentroCustoLucro.EntidadeSelecionada = null;
            this.ensCentroCustoLucro.FormSelecao = null;
            this.ensCentroCustoLucro.LiberadoQuandoCadastroUtilizado = false;
            this.ensCentroCustoLucro.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensCentroCustoLucro.Location = new System.Drawing.Point(128, 48);
            this.ensCentroCustoLucro.ModoVisualizacaoGrid = null;
            this.ensCentroCustoLucro.Name = "ensCentroCustoLucro";
            this.ensCentroCustoLucro.ParametroBuscaGuiada = null;
            this.ensCentroCustoLucro.ParametrosBuscaObrigatorios = null;
            this.ensCentroCustoLucro.Size = new System.Drawing.Size(735, 23);
            this.ensCentroCustoLucro.TabIndex = 16;
            // 
            // ensFormaPagamento
            // 
            this.ensFormaPagamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ensFormaPagamento.BindingField = "FormaPagamento";
            this.ensFormaPagamento.ColunasDropdown = null;
            this.ensFormaPagamento.DesabilitarAutoCompletar = false;
            this.ensFormaPagamento.DesabilitarChekBox = false;
            this.ensFormaPagamento.DesabilitarLupa = false;
            this.ensFormaPagamento.DesabilitarSeta = false;
            this.ensFormaPagamento.Enabled = false;
            this.ensFormaPagamento.EntidadeSelecionada = null;
            this.ensFormaPagamento.FormSelecao = null;
            this.ensFormaPagamento.LiberadoQuandoCadastroUtilizado = false;
            this.ensFormaPagamento.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensFormaPagamento.Location = new System.Drawing.Point(128, 70);
            this.ensFormaPagamento.ModoVisualizacaoGrid = null;
            this.ensFormaPagamento.Name = "ensFormaPagamento";
            this.ensFormaPagamento.ParametroBuscaGuiada = null;
            this.ensFormaPagamento.ParametrosBuscaObrigatorios = null;
            this.ensFormaPagamento.Size = new System.Drawing.Size(735, 23);
            this.ensFormaPagamento.TabIndex = 15;
            // 
            // ensContaBancaria
            // 
            this.ensContaBancaria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ensContaBancaria.BindingField = "ContaBancaria";
            this.ensContaBancaria.ColunasDropdown = null;
            this.ensContaBancaria.DesabilitarAutoCompletar = false;
            this.ensContaBancaria.DesabilitarChekBox = false;
            this.ensContaBancaria.DesabilitarLupa = false;
            this.ensContaBancaria.DesabilitarSeta = false;
            this.ensContaBancaria.Enabled = false;
            this.ensContaBancaria.EntidadeSelecionada = null;
            this.ensContaBancaria.FormSelecao = null;
            this.ensContaBancaria.LiberadoQuandoCadastroUtilizado = false;
            this.ensContaBancaria.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensContaBancaria.Location = new System.Drawing.Point(128, 26);
            this.ensContaBancaria.ModoVisualizacaoGrid = null;
            this.ensContaBancaria.Name = "ensContaBancaria";
            this.ensContaBancaria.ParametroBuscaGuiada = null;
            this.ensContaBancaria.ParametrosBuscaObrigatorios = null;
            this.ensContaBancaria.Size = new System.Drawing.Size(735, 23);
            this.ensContaBancaria.TabIndex = 14;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.BindingField = null;
            this.label33.LiberadoQuandoCadastroUtilizado = false;
            this.label33.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label33.Location = new System.Drawing.Point(15, 75);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(108, 13);
            this.label33.TabIndex = 13;
            this.label33.Text = "Forma de Pagamento";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BindingField = null;
            this.label9.LiberadoQuandoCadastroUtilizado = false;
            this.label9.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label9.Location = new System.Drawing.Point(40, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Centro de Lucro";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.BindingField = null;
            this.label32.LiberadoQuandoCadastroUtilizado = false;
            this.label32.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label32.Location = new System.Drawing.Point(43, 31);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(80, 13);
            this.label32.TabIndex = 7;
            this.label32.Text = "Conta Bancária";
            // 
            // chkTipoKit
            // 
            this.chkTipoKit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTipoKit.AutoSize = true;
            this.chkTipoKit.BindingField = "PossuiKit";
            this.chkTipoKit.LiberadoQuandoCadastroUtilizado = false;
            this.chkTipoKit.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkTipoKit.Location = new System.Drawing.Point(774, 49);
            this.chkTipoKit.Name = "chkTipoKit";
            this.chkTipoKit.Size = new System.Drawing.Size(15, 14);
            this.chkTipoKit.TabIndex = 75;
            this.chkTipoKit.UseVisualStyleBackColor = true;
            this.chkTipoKit.CheckedChanged += new System.EventHandler(this.chkTipoKit_CheckedChanged);
            // 
            // cmbTipoKit
            // 
            this.cmbTipoKit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipoKit.BindingField = "TipoKitLoadClass";
            this.cmbTipoKit.Enabled = false;
            this.cmbTipoKit.FormattingEnabled = true;
            this.cmbTipoKit.LiberadoQuandoCadastroUtilizado = false;
            this.cmbTipoKit.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.cmbTipoKit.Location = new System.Drawing.Point(586, 46);
            this.cmbTipoKit.Name = "cmbTipoKit";
            this.cmbTipoKit.Size = new System.Drawing.Size(186, 21);
            this.cmbTipoKit.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.BindingField = null;
            this.label8.LiberadoQuandoCadastroUtilizado = false;
            this.label8.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label8.Location = new System.Drawing.Point(561, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(19, 13);
            this.label8.TabIndex = 73;
            this.label8.Text = "Kit";
            // 
            // txtInfoEspeciais
            // 
            this.txtInfoEspeciais.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInfoEspeciais.BindingField = "InformacaoEspecial";
            this.txtInfoEspeciais.DebugMode = false;
            this.txtInfoEspeciais.LiberadoQuandoCadastroUtilizado = false;
            this.txtInfoEspeciais.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtInfoEspeciais.Location = new System.Drawing.Point(81, 73);
            this.txtInfoEspeciais.MaxLength = 255;
            this.txtInfoEspeciais.ModoBarcode = false;
            this.txtInfoEspeciais.ModoBusca = false;
            this.txtInfoEspeciais.Name = "txtInfoEspeciais";
            this.txtInfoEspeciais.NaoLimparDepoisBarcode = false;
            this.txtInfoEspeciais.Size = new System.Drawing.Size(220, 20);
            this.txtInfoEspeciais.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BindingField = null;
            this.label3.LiberadoQuandoCadastroUtilizado = false;
            this.label3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label3.Location = new System.Drawing.Point(5, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 72;
            this.label3.Text = "Inf. Especiais";
            // 
            // label31
            // 
            this.label31.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label31.AutoSize = true;
            this.label31.BindingField = null;
            this.label31.LiberadoQuandoCadastroUtilizado = false;
            this.label31.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label31.Location = new System.Drawing.Point(585, 20);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(75, 13);
            this.label31.TabIndex = 70;
            this.label31.Text = "Data Cadastro";
            // 
            // dtpDataPedido
            // 
            this.dtpDataPedido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDataPedido.BindingField = "DataEntrada";
            this.dtpDataPedido.Enabled = false;
            this.dtpDataPedido.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataPedido.LiberadoQuandoCadastroUtilizado = false;
            this.dtpDataPedido.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.dtpDataPedido.Location = new System.Drawing.Point(666, 16);
            this.dtpDataPedido.Name = "dtpDataPedido";
            this.dtpDataPedido.Size = new System.Drawing.Size(106, 20);
            this.dtpDataPedido.TabIndex = 4;
            this.dtpDataPedido.Value = new System.DateTime(2025, 2, 25, 14, 8, 7, 494);
            // 
            // grbCancelamento
            // 
            this.grbCancelamento.Controls.Add(this.txtCancelamentoJustificativa);
            this.grbCancelamento.Controls.Add(this.label30);
            this.grbCancelamento.Controls.Add(this.dtpCancelamentoData);
            this.grbCancelamento.Controls.Add(this.label29);
            this.grbCancelamento.Controls.Add(this.txtCancelamentoUsuario);
            this.grbCancelamento.Controls.Add(this.label26);
            this.grbCancelamento.Location = new System.Drawing.Point(8, 300);
            this.grbCancelamento.Name = "grbCancelamento";
            this.grbCancelamento.Size = new System.Drawing.Size(386, 75);
            this.grbCancelamento.TabIndex = 19;
            this.grbCancelamento.TabStop = false;
            this.grbCancelamento.Text = "Cancelamento";
            // 
            // txtCancelamentoJustificativa
            // 
            this.txtCancelamentoJustificativa.BindingField = "JustificativaCancelamento";
            this.txtCancelamentoJustificativa.DebugMode = false;
            this.txtCancelamentoJustificativa.Enabled = false;
            this.txtCancelamentoJustificativa.LiberadoQuandoCadastroUtilizado = false;
            this.txtCancelamentoJustificativa.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtCancelamentoJustificativa.Location = new System.Drawing.Point(77, 47);
            this.txtCancelamentoJustificativa.ModoBarcode = false;
            this.txtCancelamentoJustificativa.ModoBusca = false;
            this.txtCancelamentoJustificativa.Name = "txtCancelamentoJustificativa";
            this.txtCancelamentoJustificativa.NaoLimparDepoisBarcode = false;
            this.txtCancelamentoJustificativa.Size = new System.Drawing.Size(295, 20);
            this.txtCancelamentoJustificativa.TabIndex = 2;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.BindingField = null;
            this.label30.LiberadoQuandoCadastroUtilizado = false;
            this.label30.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label30.Location = new System.Drawing.Point(10, 50);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(62, 13);
            this.label30.TabIndex = 70;
            this.label30.Text = "Justificativa";
            // 
            // dtpCancelamentoData
            // 
            this.dtpCancelamentoData.BindingField = "DataCancelamento";
            this.dtpCancelamentoData.Enabled = false;
            this.dtpCancelamentoData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCancelamentoData.LiberadoQuandoCadastroUtilizado = false;
            this.dtpCancelamentoData.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.dtpCancelamentoData.Location = new System.Drawing.Point(266, 21);
            this.dtpCancelamentoData.Name = "dtpCancelamentoData";
            this.dtpCancelamentoData.Size = new System.Drawing.Size(106, 20);
            this.dtpCancelamentoData.TabIndex = 1;
            this.dtpCancelamentoData.Value = new System.DateTime(2025, 2, 25, 14, 8, 7, 499);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BindingField = null;
            this.label29.LiberadoQuandoCadastroUtilizado = false;
            this.label29.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label29.Location = new System.Drawing.Point(230, 24);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(30, 13);
            this.label29.TabIndex = 2;
            this.label29.Text = "Data";
            // 
            // txtCancelamentoUsuario
            // 
            this.txtCancelamentoUsuario.BindingField = "AcsUsuarioCancelamento";
            this.txtCancelamentoUsuario.DebugMode = false;
            this.txtCancelamentoUsuario.Enabled = false;
            this.txtCancelamentoUsuario.LiberadoQuandoCadastroUtilizado = false;
            this.txtCancelamentoUsuario.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtCancelamentoUsuario.Location = new System.Drawing.Point(77, 22);
            this.txtCancelamentoUsuario.ModoBarcode = false;
            this.txtCancelamentoUsuario.ModoBusca = false;
            this.txtCancelamentoUsuario.Name = "txtCancelamentoUsuario";
            this.txtCancelamentoUsuario.NaoLimparDepoisBarcode = false;
            this.txtCancelamentoUsuario.Size = new System.Drawing.Size(80, 20);
            this.txtCancelamentoUsuario.TabIndex = 0;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BindingField = null;
            this.label26.LiberadoQuandoCadastroUtilizado = false;
            this.label26.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label26.Location = new System.Drawing.Point(30, 24);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(43, 13);
            this.label26.TabIndex = 0;
            this.label26.Text = "Usuario";
            // 
            // grbOriginais
            // 
            this.grbOriginais.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grbOriginais.Controls.Add(this.nudValorOriginal);
            this.grbOriginais.Controls.Add(this.label16);
            this.grbOriginais.Controls.Add(this.dtpDataEntregaOriginal);
            this.grbOriginais.Controls.Add(this.label14);
            this.grbOriginais.Location = new System.Drawing.Point(883, 186);
            this.grbOriginais.Name = "grbOriginais";
            this.grbOriginais.Size = new System.Drawing.Size(192, 108);
            this.grbOriginais.TabIndex = 18;
            this.grbOriginais.TabStop = false;
            this.grbOriginais.Text = "Dados Originais";
            // 
            // nudValorOriginal
            // 
            this.nudValorOriginal.BindingField = "PrecoTotalOriginal";
            this.nudValorOriginal.DecimalPlaces = 4;
            this.nudValorOriginal.Enabled = false;
            this.nudValorOriginal.LiberadoQuandoCadastroUtilizado = false;
            this.nudValorOriginal.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudValorOriginal.Location = new System.Drawing.Point(88, 57);
            this.nudValorOriginal.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudValorOriginal.Name = "nudValorOriginal";
            this.nudValorOriginal.Size = new System.Drawing.Size(98, 20);
            this.nudValorOriginal.TabIndex = 68;
            this.nudValorOriginal.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BindingField = null;
            this.label16.LiberadoQuandoCadastroUtilizado = false;
            this.label16.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label16.Location = new System.Drawing.Point(51, 59);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(31, 13);
            this.label16.TabIndex = 67;
            this.label16.Text = "Valor";
            // 
            // dtpDataEntregaOriginal
            // 
            this.dtpDataEntregaOriginal.BindingField = "DataEntregaOriginal";
            this.dtpDataEntregaOriginal.Enabled = false;
            this.dtpDataEntregaOriginal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataEntregaOriginal.LiberadoQuandoCadastroUtilizado = false;
            this.dtpDataEntregaOriginal.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.dtpDataEntregaOriginal.Location = new System.Drawing.Point(87, 31);
            this.dtpDataEntregaOriginal.Name = "dtpDataEntregaOriginal";
            this.dtpDataEntregaOriginal.Size = new System.Drawing.Size(100, 20);
            this.dtpDataEntregaOriginal.TabIndex = 65;
            this.dtpDataEntregaOriginal.Value = new System.DateTime(2025, 2, 25, 14, 8, 7, 510);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BindingField = null;
            this.label14.LiberadoQuandoCadastroUtilizado = false;
            this.label14.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label14.Location = new System.Drawing.Point(11, 35);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 13);
            this.label14.TabIndex = 66;
            this.label14.Text = "Data Entrega";
            // 
            // gbxUrgente
            // 
            this.gbxUrgente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxUrgente.Controls.Add(this.txtUrgenteInfos);
            this.gbxUrgente.Controls.Add(this.label13);
            this.gbxUrgente.Controls.Add(this.dtpUrgenteData);
            this.gbxUrgente.Controls.Add(this.label12);
            this.gbxUrgente.Controls.Add(this.txtUrgenteSolicitante);
            this.gbxUrgente.Controls.Add(this.label6);
            this.gbxUrgente.Enabled = false;
            this.gbxUrgente.Location = new System.Drawing.Point(795, 41);
            this.gbxUrgente.Name = "gbxUrgente";
            this.gbxUrgente.Size = new System.Drawing.Size(280, 118);
            this.gbxUrgente.TabIndex = 16;
            this.gbxUrgente.TabStop = false;
            this.gbxUrgente.Text = "Urgente";
            // 
            // txtUrgenteInfos
            // 
            this.txtUrgenteInfos.BindingField = "UrgenteInformacoesComplementares";
            this.txtUrgenteInfos.DebugMode = false;
            this.txtUrgenteInfos.LiberadoQuandoCadastroUtilizado = false;
            this.txtUrgenteInfos.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtUrgenteInfos.Location = new System.Drawing.Point(9, 80);
            this.txtUrgenteInfos.ModoBarcode = false;
            this.txtUrgenteInfos.ModoBusca = false;
            this.txtUrgenteInfos.Multiline = true;
            this.txtUrgenteInfos.Name = "txtUrgenteInfos";
            this.txtUrgenteInfos.NaoLimparDepoisBarcode = false;
            this.txtUrgenteInfos.Size = new System.Drawing.Size(265, 32);
            this.txtUrgenteInfos.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BindingField = null;
            this.label13.LiberadoQuandoCadastroUtilizado = false;
            this.label13.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label13.Location = new System.Drawing.Point(6, 64);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(146, 13);
            this.label13.TabIndex = 4;
            this.label13.Text = "Informações Complementares";
            // 
            // dtpUrgenteData
            // 
            this.dtpUrgenteData.BindingField = "UrgenteDataPrometida";
            this.dtpUrgenteData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpUrgenteData.LiberadoQuandoCadastroUtilizado = false;
            this.dtpUrgenteData.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.dtpUrgenteData.Location = new System.Drawing.Point(99, 40);
            this.dtpUrgenteData.Name = "dtpUrgenteData";
            this.dtpUrgenteData.Size = new System.Drawing.Size(95, 20);
            this.dtpUrgenteData.TabIndex = 1;
            this.dtpUrgenteData.Value = new System.DateTime(2025, 2, 25, 14, 8, 7, 510);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BindingField = null;
            this.label12.LiberadoQuandoCadastroUtilizado = false;
            this.label12.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label12.Location = new System.Drawing.Point(13, 44);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Data Prometida";
            // 
            // txtUrgenteSolicitante
            // 
            this.txtUrgenteSolicitante.BindingField = "UrgenteSolicitante";
            this.txtUrgenteSolicitante.DebugMode = false;
            this.txtUrgenteSolicitante.LiberadoQuandoCadastroUtilizado = false;
            this.txtUrgenteSolicitante.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtUrgenteSolicitante.Location = new System.Drawing.Point(99, 14);
            this.txtUrgenteSolicitante.ModoBarcode = false;
            this.txtUrgenteSolicitante.ModoBusca = false;
            this.txtUrgenteSolicitante.Name = "txtUrgenteSolicitante";
            this.txtUrgenteSolicitante.NaoLimparDepoisBarcode = false;
            this.txtUrgenteSolicitante.Size = new System.Drawing.Size(176, 20);
            this.txtUrgenteSolicitante.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BindingField = null;
            this.label6.LiberadoQuandoCadastroUtilizado = false;
            this.label6.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label6.Location = new System.Drawing.Point(37, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Solicitante";
            // 
            // rdbUrgenteCritico
            // 
            this.rdbUrgenteCritico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbUrgenteCritico.AutoSize = true;
            this.rdbUrgenteCritico.BindingField = "Urgente_Critico";
            this.rdbUrgenteCritico.LiberadoQuandoCadastroUtilizado = false;
            this.rdbUrgenteCritico.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbUrgenteCritico.Location = new System.Drawing.Point(1013, 18);
            this.rdbUrgenteCritico.Name = "rdbUrgenteCritico";
            this.rdbUrgenteCritico.Size = new System.Drawing.Size(56, 17);
            this.rdbUrgenteCritico.TabIndex = 15;
            this.rdbUrgenteCritico.Text = "Crítico";
            this.rdbUrgenteCritico.UseVisualStyleBackColor = true;
            this.rdbUrgenteCritico.CheckedChanged += new System.EventHandler(this.rdbUrgenteCritico_CheckedChanged);
            // 
            // rdbUrgenteUrgente
            // 
            this.rdbUrgenteUrgente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbUrgenteUrgente.AutoSize = true;
            this.rdbUrgenteUrgente.BindingField = "Urgente_Urgente";
            this.rdbUrgenteUrgente.LiberadoQuandoCadastroUtilizado = false;
            this.rdbUrgenteUrgente.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbUrgenteUrgente.Location = new System.Drawing.Point(950, 18);
            this.rdbUrgenteUrgente.Name = "rdbUrgenteUrgente";
            this.rdbUrgenteUrgente.Size = new System.Drawing.Size(63, 17);
            this.rdbUrgenteUrgente.TabIndex = 14;
            this.rdbUrgenteUrgente.Text = "Urgente";
            this.rdbUrgenteUrgente.UseVisualStyleBackColor = true;
            this.rdbUrgenteUrgente.CheckedChanged += new System.EventHandler(this.rdbUrgenteUrgente_CheckedChanged);
            // 
            // rdbUrgenteAntecipacao
            // 
            this.rdbUrgenteAntecipacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbUrgenteAntecipacao.AutoSize = true;
            this.rdbUrgenteAntecipacao.BindingField = "Urgente_Antecipacao";
            this.rdbUrgenteAntecipacao.LiberadoQuandoCadastroUtilizado = false;
            this.rdbUrgenteAntecipacao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbUrgenteAntecipacao.Location = new System.Drawing.Point(859, 18);
            this.rdbUrgenteAntecipacao.Name = "rdbUrgenteAntecipacao";
            this.rdbUrgenteAntecipacao.Size = new System.Drawing.Size(85, 17);
            this.rdbUrgenteAntecipacao.TabIndex = 13;
            this.rdbUrgenteAntecipacao.Text = "Antecipação";
            this.rdbUrgenteAntecipacao.UseVisualStyleBackColor = true;
            this.rdbUrgenteAntecipacao.CheckedChanged += new System.EventHandler(this.rdbUrgenteAntecipacao_CheckedChanged);
            // 
            // rdbUrgenteNormal
            // 
            this.rdbUrgenteNormal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbUrgenteNormal.AutoSize = true;
            this.rdbUrgenteNormal.BindingField = "Urgente_Normal";
            this.rdbUrgenteNormal.Checked = true;
            this.rdbUrgenteNormal.LiberadoQuandoCadastroUtilizado = false;
            this.rdbUrgenteNormal.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbUrgenteNormal.Location = new System.Drawing.Point(795, 18);
            this.rdbUrgenteNormal.Name = "rdbUrgenteNormal";
            this.rdbUrgenteNormal.Size = new System.Drawing.Size(58, 17);
            this.rdbUrgenteNormal.TabIndex = 12;
            this.rdbUrgenteNormal.TabStop = true;
            this.rdbUrgenteNormal.Text = "Normal";
            this.rdbUrgenteNormal.UseVisualStyleBackColor = true;
            this.rdbUrgenteNormal.CheckedChanged += new System.EventHandler(this.rdbUrgenteNormal_CheckedChanged);
            // 
            // btnVariaveis
            // 
            this.btnVariaveis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVariaveis.Enabled = false;
            this.btnVariaveis.LiberadoQuandoCadastroUtilizado = false;
            this.btnVariaveis.Location = new System.Drawing.Point(939, 316);
            this.btnVariaveis.Name = "btnVariaveis";
            this.btnVariaveis.Size = new System.Drawing.Size(131, 23);
            this.btnVariaveis.TabIndex = 20;
            this.btnVariaveis.Text = "Variáveis do Pedido";
            this.btnVariaveis.UseVisualStyleBackColor = true;
            this.btnVariaveis.Click += new System.EventHandler(this.btnVariaveis_Click);
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.AutoSize = true;
            this.label22.BindingField = null;
            this.label22.LiberadoQuandoCadastroUtilizado = false;
            this.label22.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label22.Location = new System.Drawing.Point(332, 49);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(70, 13);
            this.label22.TabIndex = 52;
            this.label22.Text = "Data Entrega";
            // 
            // dtpDataEntrega
            // 
            this.dtpDataEntrega.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDataEntrega.BindingField = "DataEntrega";
            this.dtpDataEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataEntrega.LiberadoQuandoCadastroUtilizado = false;
            this.dtpDataEntrega.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.dtpDataEntrega.Location = new System.Drawing.Point(408, 45);
            this.dtpDataEntrega.Name = "dtpDataEntrega";
            this.dtpDataEntrega.Size = new System.Drawing.Size(106, 20);
            this.dtpDataEntrega.TabIndex = 6;
            this.dtpDataEntrega.Value = new System.DateTime(2025, 2, 25, 14, 8, 7, 526);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BindingField = null;
            this.label7.LiberadoQuandoCadastroUtilizado = false;
            this.label7.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label7.Location = new System.Drawing.Point(36, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "Cliente";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.BindingField = null;
            this.label17.LiberadoQuandoCadastroUtilizado = false;
            this.label17.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label17.Location = new System.Drawing.Point(325, 22);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 13);
            this.label17.TabIndex = 42;
            this.label17.Text = "Pedido / Linha";
            // 
            // txtOc
            // 
            this.txtOc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOc.AsciiOnly = true;
            this.txtOc.BindingField = "Numero";
            this.txtOc.LiberadoQuandoCadastroUtilizado = false;
            this.txtOc.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtOc.Location = new System.Drawing.Point(408, 19);
            this.txtOc.Mask = "AAAAAAAAAA";
            this.txtOc.Name = "txtOc";
            this.txtOc.Size = new System.Drawing.Size(106, 20);
            this.txtOc.TabIndex = 2;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BindingField = null;
            this.label23.LiberadoQuandoCadastroUtilizado = false;
            this.label23.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label23.Location = new System.Drawing.Point(20, 50);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(54, 13);
            this.label23.TabIndex = 54;
            this.label23.Text = "Operação";
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.BindingField = null;
            this.label18.LiberadoQuandoCadastroUtilizado = false;
            this.label18.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label18.Location = new System.Drawing.Point(513, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(12, 13);
            this.label18.TabIndex = 3;
            this.label18.Text = "/";
            // 
            // gbxPrincipal
            // 
            this.gbxPrincipal.Controls.Add(this.iwtLabel9);
            this.gbxPrincipal.Controls.Add(this.nudDesconto);
            this.gbxPrincipal.Controls.Add(this.lnkEstrutura);
            this.gbxPrincipal.Controls.Add(this.ensNCM);
            this.gbxPrincipal.Controls.Add(this.ensItemPrincipal);
            this.gbxPrincipal.Controls.Add(this.lnkDetalhesPrincipal);
            this.gbxPrincipal.Controls.Add(this.lblTotal);
            this.gbxPrincipal.Controls.Add(this.label21);
            this.gbxPrincipal.Controls.Add(this.label15);
            this.gbxPrincipal.Controls.Add(this.nudValorUnit);
            this.gbxPrincipal.Controls.Add(this.label5);
            this.gbxPrincipal.Controls.Add(this.nudQtd);
            this.gbxPrincipal.Controls.Add(this.txtDescricao);
            this.gbxPrincipal.Controls.Add(this.label2);
            this.gbxPrincipal.Controls.Add(this.txtCodigo);
            this.gbxPrincipal.Controls.Add(this.label4);
            this.gbxPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxPrincipal.Location = new System.Drawing.Point(0, 0);
            this.gbxPrincipal.Name = "gbxPrincipal";
            this.gbxPrincipal.Size = new System.Drawing.Size(1081, 67);
            this.gbxPrincipal.TabIndex = 0;
            this.gbxPrincipal.TabStop = false;
            this.gbxPrincipal.Text = "Item Principal (Pai)";
            // 
            // iwtLabel9
            // 
            this.iwtLabel9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtLabel9.AutoSize = true;
            this.iwtLabel9.BindingField = null;
            this.iwtLabel9.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel9.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel9.Location = new System.Drawing.Point(799, 44);
            this.iwtLabel9.Name = "iwtLabel9";
            this.iwtLabel9.Size = new System.Drawing.Size(53, 13);
            this.iwtLabel9.TabIndex = 53;
            this.iwtLabel9.Text = "Desconto";
            // 
            // nudDesconto
            // 
            this.nudDesconto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudDesconto.BindingField = "Desconto";
            this.nudDesconto.DecimalPlaces = 4;
            this.nudDesconto.LiberadoQuandoCadastroUtilizado = false;
            this.nudDesconto.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudDesconto.Location = new System.Drawing.Point(861, 42);
            this.nudDesconto.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudDesconto.Name = "nudDesconto";
            this.nudDesconto.Size = new System.Drawing.Size(72, 20);
            this.nudDesconto.TabIndex = 54;
            this.nudDesconto.ValueChanged += new System.EventHandler(this.nudDesconto_ValueChanged);
            // 
            // lnkEstrutura
            // 
            this.lnkEstrutura.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkEstrutura.AutoSize = true;
            this.lnkEstrutura.Location = new System.Drawing.Point(428, 45);
            this.lnkEstrutura.Name = "lnkEstrutura";
            this.lnkEstrutura.Size = new System.Drawing.Size(49, 13);
            this.lnkEstrutura.TabIndex = 52;
            this.lnkEstrutura.TabStop = true;
            this.lnkEstrutura.Text = "Estrutura";
            this.lnkEstrutura.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkEstrutura_LinkClicked);
            // 
            // ensNCM
            // 
            this.ensNCM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ensNCM.BindingField = "Ncm";
            this.ensNCM.ColunasDropdown = null;
            this.ensNCM.DesabilitarAutoCompletar = false;
            this.ensNCM.DesabilitarChekBox = false;
            this.ensNCM.DesabilitarLupa = false;
            this.ensNCM.DesabilitarSeta = false;
            this.ensNCM.EntidadeSelecionada = null;
            this.ensNCM.FormSelecao = null;
            this.ensNCM.LiberadoQuandoCadastroUtilizado = false;
            this.ensNCM.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensNCM.Location = new System.Drawing.Point(42, 40);
            this.ensNCM.ModoVisualizacaoGrid = null;
            this.ensNCM.Name = "ensNCM";
            this.ensNCM.ParametroBuscaGuiada = null;
            this.ensNCM.ParametrosBuscaObrigatorios = null;
            this.ensNCM.Size = new System.Drawing.Size(378, 23);
            this.ensNCM.TabIndex = 4;
            // 
            // ensItemPrincipal
            // 
            this.ensItemPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ensItemPrincipal.BindingField = "Produto";
            this.ensItemPrincipal.ColunasDropdown = null;
            this.ensItemPrincipal.DesabilitarAutoCompletar = false;
            this.ensItemPrincipal.DesabilitarChekBox = true;
            this.ensItemPrincipal.DesabilitarLupa = false;
            this.ensItemPrincipal.DesabilitarSeta = false;
            this.ensItemPrincipal.EntidadeSelecionada = null;
            this.ensItemPrincipal.FormSelecao = null;
            this.ensItemPrincipal.LiberadoQuandoCadastroUtilizado = false;
            this.ensItemPrincipal.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensItemPrincipal.Location = new System.Drawing.Point(6, 16);
            this.ensItemPrincipal.ModoVisualizacaoGrid = null;
            this.ensItemPrincipal.Name = "ensItemPrincipal";
            this.ensItemPrincipal.ParametroBuscaGuiada = null;
            this.ensItemPrincipal.ParametrosBuscaObrigatorios = null;
            this.ensItemPrincipal.Size = new System.Drawing.Size(414, 23);
            this.ensItemPrincipal.TabIndex = 50;
            this.ensItemPrincipal.EntityChange += new System.EventHandler(this.ensItemPrincipal_EntityChange);
            // 
            // lnkDetalhesPrincipal
            // 
            this.lnkDetalhesPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkDetalhesPrincipal.AutoSize = true;
            this.lnkDetalhesPrincipal.Location = new System.Drawing.Point(428, 22);
            this.lnkDetalhesPrincipal.Name = "lnkDetalhesPrincipal";
            this.lnkDetalhesPrincipal.Size = new System.Drawing.Size(49, 13);
            this.lnkDetalhesPrincipal.TabIndex = 51;
            this.lnkDetalhesPrincipal.TabStop = true;
            this.lnkDetalhesPrincipal.Text = "Detalhes";
            this.lnkDetalhesPrincipal.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDetalhesPrincipal_LinkClicked);
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.BindingField = null;
            this.lblTotal.LiberadoQuandoCadastroUtilizado = false;
            this.lblTotal.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblTotal.Location = new System.Drawing.Point(939, 45);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(37, 13);
            this.lblTotal.TabIndex = 7;
            this.lblTotal.Text = "Total: ";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BindingField = null;
            this.label21.LiberadoQuandoCadastroUtilizado = false;
            this.label21.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label21.Location = new System.Drawing.Point(5, 45);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(31, 13);
            this.label21.TabIndex = 50;
            this.label21.Text = "NCM";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.BindingField = null;
            this.label15.LiberadoQuandoCadastroUtilizado = false;
            this.label15.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label15.Location = new System.Drawing.Point(659, 44);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 13);
            this.label15.TabIndex = 6;
            this.label15.Text = "Valor Unit.";
            // 
            // nudValorUnit
            // 
            this.nudValorUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudValorUnit.BindingField = "PrecoUnitario";
            this.nudValorUnit.DecimalPlaces = 4;
            this.nudValorUnit.LiberadoQuandoCadastroUtilizado = false;
            this.nudValorUnit.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudValorUnit.Location = new System.Drawing.Point(721, 42);
            this.nudValorUnit.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudValorUnit.Name = "nudValorUnit";
            this.nudValorUnit.Size = new System.Drawing.Size(72, 20);
            this.nudValorUnit.TabIndex = 6;
            this.nudValorUnit.ValueChanged += new System.EventHandler(this.nudValorUnit_ValueChanged);
            this.nudValorUnit.Click += new System.EventHandler(this.nudValorUnit_Click);
            this.nudValorUnit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudValorUnit_KeyPress);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BindingField = null;
            this.label5.LiberadoQuandoCadastroUtilizado = false;
            this.label5.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label5.Location = new System.Drawing.Point(543, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Qtd";
            // 
            // nudQtd
            // 
            this.nudQtd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudQtd.BindingField = "Quantidade";
            this.nudQtd.DecimalPlaces = 5;
            this.nudQtd.LiberadoQuandoCadastroUtilizado = false;
            this.nudQtd.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudQtd.Location = new System.Drawing.Point(573, 42);
            this.nudQtd.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudQtd.Name = "nudQtd";
            this.nudQtd.Size = new System.Drawing.Size(66, 20);
            this.nudQtd.TabIndex = 5;
            this.nudQtd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQtd.ValueChanged += new System.EventHandler(this.nudQtd_ValueChanged);
            // 
            // txtDescricao
            // 
            this.txtDescricao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescricao.BindingField = "ProdutoDescricaoCliente";
            this.txtDescricao.DebugMode = false;
            this.txtDescricao.LiberadoQuandoCadastroUtilizado = false;
            this.txtDescricao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtDescricao.Location = new System.Drawing.Point(848, 19);
            this.txtDescricao.MaxLength = 255;
            this.txtDescricao.ModoBarcode = false;
            this.txtDescricao.ModoBusca = false;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.NaoLimparDepoisBarcode = false;
            this.txtDescricao.Size = new System.Drawing.Size(221, 20);
            this.txtDescricao.TabIndex = 2;
            this.txtDescricao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescricao_KeyPress);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BindingField = null;
            this.label2.LiberadoQuandoCadastroUtilizado = false;
            this.label2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label2.Location = new System.Drawing.Point(766, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Descrição Fat.";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodigo.BindingField = "ProdutoCodigoCliente";
            this.txtCodigo.DebugMode = false;
            this.txtCodigo.LiberadoQuandoCadastroUtilizado = false;
            this.txtCodigo.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtCodigo.Location = new System.Drawing.Point(594, 19);
            this.txtCodigo.MaxLength = 15;
            this.txtCodigo.ModoBarcode = false;
            this.txtCodigo.ModoBusca = false;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.NaoLimparDepoisBarcode = false;
            this.txtCodigo.Size = new System.Drawing.Size(162, 20);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BindingField = null;
            this.label4.LiberadoQuandoCadastroUtilizado = false;
            this.label4.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label4.Location = new System.Drawing.Point(486, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Código Faturamento";
            // 
            // gbxItem
            // 
            this.gbxItem.Controls.Add(this.splitContainer4);
            this.gbxItem.Controls.Add(this.label24);
            this.gbxItem.Controls.Add(this.comboBox4);
            this.gbxItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxItem.Enabled = false;
            this.gbxItem.Location = new System.Drawing.Point(0, 0);
            this.gbxItem.Name = "gbxItem";
            this.gbxItem.Size = new System.Drawing.Size(1081, 187);
            this.gbxItem.TabIndex = 0;
            this.gbxItem.TabStop = false;
            this.gbxItem.Text = "Sublinhas (Kit)";
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer4.Location = new System.Drawing.Point(3, 16);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.ensSubItem);
            this.splitContainer4.Panel1.Controls.Add(this.lnkDetalhesSub);
            this.splitContainer4.Panel1.Controls.Add(this.btnEditarItem);
            this.splitContainer4.Panel1.Controls.Add(this.label28);
            this.splitContainer4.Panel1.Controls.Add(this.txtCodigoItem);
            this.splitContainer4.Panel1.Controls.Add(this.label27);
            this.splitContainer4.Panel1.Controls.Add(this.label10);
            this.splitContainer4.Panel1.Controls.Add(this.txtDescricaoItem);
            this.splitContainer4.Panel1.Controls.Add(this.nudQtdItem);
            this.splitContainer4.Panel1.Controls.Add(this.label25);
            this.splitContainer4.Panel1.Controls.Add(this.btnAdicionar);
            this.splitContainer4.Panel1.Controls.Add(this.btnRemover);
            this.splitContainer4.Panel1.Controls.Add(this.btnConfirmarEdicao);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer4.Size = new System.Drawing.Size(1075, 168);
            this.splitContainer4.SplitterDistance = 338;
            this.splitContainer4.TabIndex = 63;
            // 
            // ensSubItem
            // 
            this.ensSubItem.BindingField = "";
            this.ensSubItem.ColunasDropdown = null;
            this.ensSubItem.Controls.Add(this.chk);
            this.ensSubItem.Controls.Add(this.txt);
            this.ensSubItem.DesabilitarAutoCompletar = false;
            this.ensSubItem.DesabilitarChekBox = true;
            this.ensSubItem.DesabilitarLupa = false;
            this.ensSubItem.DesabilitarSeta = false;
            this.ensSubItem.EntidadeSelecionada = null;
            this.ensSubItem.FormSelecao = null;
            this.ensSubItem.LiberadoQuandoCadastroUtilizado = false;
            this.ensSubItem.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensSubItem.Location = new System.Drawing.Point(95, 5);
            this.ensSubItem.ModoVisualizacaoGrid = null;
            this.ensSubItem.Name = "ensSubItem";
            this.ensSubItem.ParametroBuscaGuiada = null;
            this.ensSubItem.ParametrosBuscaObrigatorios = null;
            this.ensSubItem.Size = new System.Drawing.Size(235, 23);
            this.ensSubItem.TabIndex = 50;
            this.ensSubItem.EntityChange += new System.EventHandler(this.ensSubItem_EntityChange);
            // 
            // chk
            // 
            this.chk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chk.AutoSize = true;
            this.chk.BindingField = "";
            this.chk.Checked = true;
            this.chk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk.LiberadoQuandoCadastroUtilizado = false;
            this.chk.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chk.Location = new System.Drawing.Point(36, 4);
            this.chk.Name = "chk";
            this.chk.Size = new System.Drawing.Size(15, 14);
            this.chk.TabIndex = 1;
            this.chk.UseVisualStyleBackColor = true;
            this.chk.Visible = false;
            // 
            // txt
            // 
            this.txt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt.BindingField = "";
            this.txt.DebugMode = false;
            this.txt.LiberadoQuandoCadastroUtilizado = false;
            this.txt.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txt.Location = new System.Drawing.Point(0, 1);
            this.txt.ModoBarcode = false;
            this.txt.ModoBusca = false;
            this.txt.Name = "txt";
            this.txt.NaoLimparDepoisBarcode = false;
            this.txt.Size = new System.Drawing.Size(19, 20);
            this.txt.TabIndex = 3;
            // 
            // lnkDetalhesSub
            // 
            this.lnkDetalhesSub.AutoSize = true;
            this.lnkDetalhesSub.Location = new System.Drawing.Point(285, 31);
            this.lnkDetalhesSub.Name = "lnkDetalhesSub";
            this.lnkDetalhesSub.Size = new System.Drawing.Size(49, 13);
            this.lnkDetalhesSub.TabIndex = 51;
            this.lnkDetalhesSub.TabStop = true;
            this.lnkDetalhesSub.Text = "Detalhes";
            this.lnkDetalhesSub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDetalhesSub_LinkClicked);
            // 
            // btnEditarItem
            // 
            this.btnEditarItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditarItem.LiberadoQuandoCadastroUtilizado = false;
            this.btnEditarItem.Location = new System.Drawing.Point(10, 134);
            this.btnEditarItem.Name = "btnEditarItem";
            this.btnEditarItem.Size = new System.Drawing.Size(103, 23);
            this.btnEditarItem.TabIndex = 63;
            this.btnEditarItem.Text = "Editar Subitem";
            this.btnEditarItem.UseVisualStyleBackColor = true;
            this.btnEditarItem.Click += new System.EventHandler(this.btnEditarItem_Click);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BindingField = null;
            this.label28.LiberadoQuandoCadastroUtilizado = false;
            this.label28.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label28.Location = new System.Drawing.Point(2, 48);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(91, 13);
            this.label28.TabIndex = 28;
            this.label28.Text = "Cód. Faturamento";
            // 
            // txtCodigoItem
            // 
            this.txtCodigoItem.BindingField = null;
            this.txtCodigoItem.DebugMode = false;
            this.txtCodigoItem.LiberadoQuandoCadastroUtilizado = false;
            this.txtCodigoItem.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtCodigoItem.Location = new System.Drawing.Point(94, 45);
            this.txtCodigoItem.MaxLength = 15;
            this.txtCodigoItem.ModoBarcode = false;
            this.txtCodigoItem.ModoBusca = false;
            this.txtCodigoItem.Name = "txtCodigoItem";
            this.txtCodigoItem.NaoLimparDepoisBarcode = false;
            this.txtCodigoItem.Size = new System.Drawing.Size(240, 20);
            this.txtCodigoItem.TabIndex = 1;
            this.txtCodigoItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoItem_KeyPress);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BindingField = null;
            this.label27.LiberadoQuandoCadastroUtilizado = false;
            this.label27.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label27.Location = new System.Drawing.Point(38, 74);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(55, 13);
            this.label27.TabIndex = 29;
            this.label27.Text = "Descrição";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BindingField = null;
            this.label10.LiberadoQuandoCadastroUtilizado = false;
            this.label10.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label10.Location = new System.Drawing.Point(12, 100);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 13);
            this.label10.TabIndex = 59;
            this.label10.Text = "Qtd";
            // 
            // txtDescricaoItem
            // 
            this.txtDescricaoItem.BindingField = null;
            this.txtDescricaoItem.DebugMode = false;
            this.txtDescricaoItem.LiberadoQuandoCadastroUtilizado = false;
            this.txtDescricaoItem.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtDescricaoItem.Location = new System.Drawing.Point(94, 71);
            this.txtDescricaoItem.MaxLength = 255;
            this.txtDescricaoItem.ModoBarcode = false;
            this.txtDescricaoItem.ModoBusca = false;
            this.txtDescricaoItem.Name = "txtDescricaoItem";
            this.txtDescricaoItem.NaoLimparDepoisBarcode = false;
            this.txtDescricaoItem.Size = new System.Drawing.Size(240, 20);
            this.txtDescricaoItem.TabIndex = 2;
            this.txtDescricaoItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescricaoItem_KeyPress);
            // 
            // nudQtdItem
            // 
            this.nudQtdItem.BindingField = null;
            this.nudQtdItem.DecimalPlaces = 5;
            this.nudQtdItem.LiberadoQuandoCadastroUtilizado = false;
            this.nudQtdItem.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudQtdItem.Location = new System.Drawing.Point(39, 98);
            this.nudQtdItem.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudQtdItem.Name = "nudQtdItem";
            this.nudQtdItem.Size = new System.Drawing.Size(66, 20);
            this.nudQtdItem.TabIndex = 4;
            this.nudQtdItem.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BindingField = null;
            this.label25.LiberadoQuandoCadastroUtilizado = false;
            this.label25.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label25.Location = new System.Drawing.Point(17, 10);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(76, 13);
            this.label25.TabIndex = 32;
            this.label25.Text = "Código Interno";
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdicionar.LiberadoQuandoCadastroUtilizado = false;
            this.btnAdicionar.Location = new System.Drawing.Point(119, 134);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(103, 23);
            this.btnAdicionar.TabIndex = 6;
            this.btnAdicionar.Text = "Adicionar Subitem";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemover.LiberadoQuandoCadastroUtilizado = false;
            this.btnRemover.Location = new System.Drawing.Point(228, 134);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(102, 23);
            this.btnRemover.TabIndex = 7;
            this.btnRemover.Text = "Remover Subitem";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnConfirmarEdicao
            // 
            this.btnConfirmarEdicao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnConfirmarEdicao.LiberadoQuandoCadastroUtilizado = false;
            this.btnConfirmarEdicao.Location = new System.Drawing.Point(9, 134);
            this.btnConfirmarEdicao.Name = "btnConfirmarEdicao";
            this.btnConfirmarEdicao.Size = new System.Drawing.Size(103, 23);
            this.btnConfirmarEdicao.TabIndex = 64;
            this.btnConfirmarEdicao.Text = "Confirmar Edição";
            this.btnConfirmarEdicao.UseVisualStyleBackColor = true;
            this.btnConfirmarEdicao.Visible = false;
            this.btnConfirmarEdicao.Click += new System.EventHandler(this.btnConfirmarEdicao_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.CacheDados = null;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Produto,
            this.ProdutoCodigoCliente,
            this.ProdutoDescricaoCliente,
            this.Quantidade});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(209)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(733, 168);
            this.dataGridView1.TabIndex = 0;
            // 
            // Produto
            // 
            this.Produto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Produto.DataPropertyName = "Produto";
            this.Produto.HeaderText = "Código";
            this.Produto.MinimumWidth = 100;
            this.Produto.Name = "Produto";
            this.Produto.ReadOnly = true;
            // 
            // ProdutoCodigoCliente
            // 
            this.ProdutoCodigoCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ProdutoCodigoCliente.DataPropertyName = "ProdutoCodigoCliente";
            this.ProdutoCodigoCliente.HeaderText = "Código Cliente";
            this.ProdutoCodigoCliente.Name = "ProdutoCodigoCliente";
            this.ProdutoCodigoCliente.ReadOnly = true;
            // 
            // ProdutoDescricaoCliente
            // 
            this.ProdutoDescricaoCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ProdutoDescricaoCliente.DataPropertyName = "ProdutoDescricaoCliente";
            this.ProdutoDescricaoCliente.HeaderText = "Descrição";
            this.ProdutoDescricaoCliente.Name = "ProdutoDescricaoCliente";
            this.ProdutoDescricaoCliente.ReadOnly = true;
            this.ProdutoDescricaoCliente.Width = 80;
            // 
            // Quantidade
            // 
            this.Quantidade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Quantidade.DataPropertyName = "Quantidade";
            this.Quantidade.HeaderText = "Quantidade";
            this.Quantidade.Name = "Quantidade";
            this.Quantidade.ReadOnly = true;
            this.Quantidade.Width = 87;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BindingField = null;
            this.label24.LiberadoQuandoCadastroUtilizado = false;
            this.label24.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label24.Location = new System.Drawing.Point(235, -18);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(28, 13);
            this.label24.TabIndex = 0;
            this.label24.Text = "CST";
            // 
            // comboBox4
            // 
            this.comboBox4.BindingField = null;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.LiberadoQuandoCadastroUtilizado = false;
            this.comboBox4.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.comboBox4.Location = new System.Drawing.Point(269, -21);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(223, 21);
            this.comboBox4.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.Controls.Add(this.groupBox8);
            this.tabPage2.Controls.Add(this.grbFeedback);
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1087, 649);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Informações Adicionais";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.Controls.Add(this.rdbEmissorNFeSecundario);
            this.groupBox8.Controls.Add(this.rdbEmissorNFePrimario);
            this.groupBox8.Controls.Add(this.iwtLabel5);
            this.groupBox8.Controls.Add(this.iwtTextBox1);
            this.groupBox8.Controls.Add(this.iwtLabel4);
            this.groupBox8.Location = new System.Drawing.Point(6, 101);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(1075, 124);
            this.groupBox8.TabIndex = 1;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Nota Fiscal";
            // 
            // rdbEmissorNFeSecundario
            // 
            this.rdbEmissorNFeSecundario.AutoSize = true;
            this.rdbEmissorNFeSecundario.BindingField = "EmissorNfe_Secundario";
            this.rdbEmissorNFeSecundario.LiberadoQuandoCadastroUtilizado = true;
            this.rdbEmissorNFeSecundario.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbEmissorNFeSecundario.Location = new System.Drawing.Point(129, 98);
            this.rdbEmissorNFeSecundario.Name = "rdbEmissorNFeSecundario";
            this.rdbEmissorNFeSecundario.Size = new System.Drawing.Size(79, 17);
            this.rdbEmissorNFeSecundario.TabIndex = 4;
            this.rdbEmissorNFeSecundario.Text = "Secundário";
            this.rdbEmissorNFeSecundario.UseVisualStyleBackColor = true;
            // 
            // rdbEmissorNFePrimario
            // 
            this.rdbEmissorNFePrimario.AutoSize = true;
            this.rdbEmissorNFePrimario.BindingField = "EmissorNfe_Primario";
            this.rdbEmissorNFePrimario.Checked = true;
            this.rdbEmissorNFePrimario.LiberadoQuandoCadastroUtilizado = true;
            this.rdbEmissorNFePrimario.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbEmissorNFePrimario.Location = new System.Drawing.Point(129, 75);
            this.rdbEmissorNFePrimario.Name = "rdbEmissorNFePrimario";
            this.rdbEmissorNFePrimario.Size = new System.Drawing.Size(65, 17);
            this.rdbEmissorNFePrimario.TabIndex = 3;
            this.rdbEmissorNFePrimario.TabStop = true;
            this.rdbEmissorNFePrimario.Text = "Principal";
            this.rdbEmissorNFePrimario.UseVisualStyleBackColor = true;
            // 
            // iwtLabel5
            // 
            this.iwtLabel5.AutoSize = true;
            this.iwtLabel5.BindingField = null;
            this.iwtLabel5.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel5.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel5.Location = new System.Drawing.Point(71, 77);
            this.iwtLabel5.Name = "iwtLabel5";
            this.iwtLabel5.Size = new System.Drawing.Size(48, 13);
            this.iwtLabel5.TabIndex = 2;
            this.iwtLabel5.Text = "Emitente";
            // 
            // iwtTextBox1
            // 
            this.iwtTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtTextBox1.BindingField = "ObservacaoNf";
            this.iwtTextBox1.DebugMode = false;
            this.iwtTextBox1.LiberadoQuandoCadastroUtilizado = true;
            this.iwtTextBox1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox1.Location = new System.Drawing.Point(129, 19);
            this.iwtTextBox1.ModoBarcode = false;
            this.iwtTextBox1.ModoBusca = false;
            this.iwtTextBox1.Multiline = true;
            this.iwtTextBox1.Name = "iwtTextBox1";
            this.iwtTextBox1.NaoLimparDepoisBarcode = false;
            this.iwtTextBox1.Size = new System.Drawing.Size(922, 50);
            this.iwtTextBox1.TabIndex = 1;
            // 
            // iwtLabel4
            // 
            this.iwtLabel4.AutoSize = true;
            this.iwtLabel4.BindingField = null;
            this.iwtLabel4.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel4.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel4.Location = new System.Drawing.Point(58, 22);
            this.iwtLabel4.Name = "iwtLabel4";
            this.iwtLabel4.Size = new System.Drawing.Size(65, 13);
            this.iwtLabel4.TabIndex = 0;
            this.iwtLabel4.Text = "Observação";
            // 
            // grbFeedback
            // 
            this.grbFeedback.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbFeedback.Controls.Add(this.splitContainer6);
            this.grbFeedback.Location = new System.Drawing.Point(8, 231);
            this.grbFeedback.Name = "grbFeedback";
            this.grbFeedback.Size = new System.Drawing.Size(1071, 412);
            this.grbFeedback.TabIndex = 2;
            this.grbFeedback.TabStop = false;
            this.grbFeedback.Text = "Feedback do Cliente";
            // 
            // splitContainer6
            // 
            this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer6.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer6.Location = new System.Drawing.Point(3, 16);
            this.splitContainer6.Name = "splitContainer6";
            // 
            // splitContainer6.Panel1
            // 
            this.splitContainer6.Panel1.Controls.Add(this.dgvFeedbacks);
            // 
            // splitContainer6.Panel2
            // 
            this.splitContainer6.Panel2.Controls.Add(this.btnFeedbackOk);
            this.splitContainer6.Panel2.Controls.Add(this.txtFeedback);
            this.splitContainer6.Panel2.Controls.Add(this.label37);
            this.splitContainer6.Panel2.Controls.Add(this.btnFeedbackAdicionar);
            this.splitContainer6.Size = new System.Drawing.Size(1065, 393);
            this.splitContainer6.SplitterDistance = 718;
            this.splitContainer6.TabIndex = 0;
            // 
            // dgvFeedbacks
            // 
            this.dgvFeedbacks.AllowUserToAddRows = false;
            this.dgvFeedbacks.AllowUserToDeleteRows = false;
            this.dgvFeedbacks.AllowUserToOrderColumns = true;
            this.dgvFeedbacks.AllowUserToResizeRows = false;
            this.dgvFeedbacks.BackgroundColor = System.Drawing.Color.White;
            this.dgvFeedbacks.CacheDados = null;
            this.dgvFeedbacks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(209)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFeedbacks.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFeedbacks.Location = new System.Drawing.Point(0, 0);
            this.dgvFeedbacks.MultiSelect = false;
            this.dgvFeedbacks.Name = "dgvFeedbacks";
            this.dgvFeedbacks.ReadOnly = true;
            this.dgvFeedbacks.RowHeadersVisible = false;
            this.dgvFeedbacks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFeedbacks.Size = new System.Drawing.Size(718, 393);
            this.dgvFeedbacks.TabIndex = 0;
            this.dgvFeedbacks.SelectionChanged += new System.EventHandler(this.dgvFeedbacks_SelectionChanged);
            // 
            // btnFeedbackOk
            // 
            this.btnFeedbackOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFeedbackOk.Enabled = false;
            this.btnFeedbackOk.LiberadoQuandoCadastroUtilizado = false;
            this.btnFeedbackOk.Location = new System.Drawing.Point(265, 334);
            this.btnFeedbackOk.Name = "btnFeedbackOk";
            this.btnFeedbackOk.Size = new System.Drawing.Size(75, 23);
            this.btnFeedbackOk.TabIndex = 3;
            this.btnFeedbackOk.Text = "OK";
            this.btnFeedbackOk.UseVisualStyleBackColor = true;
            this.btnFeedbackOk.Click += new System.EventHandler(this.btnFeedbackOk_Click);
            // 
            // txtFeedback
            // 
            this.txtFeedback.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFeedback.BindingField = null;
            this.txtFeedback.DebugMode = false;
            this.txtFeedback.Enabled = false;
            this.txtFeedback.LiberadoQuandoCadastroUtilizado = false;
            this.txtFeedback.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtFeedback.Location = new System.Drawing.Point(18, 61);
            this.txtFeedback.ModoBarcode = false;
            this.txtFeedback.ModoBusca = false;
            this.txtFeedback.Multiline = true;
            this.txtFeedback.Name = "txtFeedback";
            this.txtFeedback.NaoLimparDepoisBarcode = false;
            this.txtFeedback.Size = new System.Drawing.Size(307, 257);
            this.txtFeedback.TabIndex = 2;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.BindingField = null;
            this.label37.LiberadoQuandoCadastroUtilizado = false;
            this.label37.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label37.Location = new System.Drawing.Point(3, 45);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(85, 13);
            this.label37.TabIndex = 1;
            this.label37.Text = "Texto Feedback";
            // 
            // btnFeedbackAdicionar
            // 
            this.btnFeedbackAdicionar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFeedbackAdicionar.LiberadoQuandoCadastroUtilizado = false;
            this.btnFeedbackAdicionar.Location = new System.Drawing.Point(18, 8);
            this.btnFeedbackAdicionar.Name = "btnFeedbackAdicionar";
            this.btnFeedbackAdicionar.Size = new System.Drawing.Size(307, 23);
            this.btnFeedbackAdicionar.TabIndex = 0;
            this.btnFeedbackAdicionar.Text = "Adicionar Feedback";
            this.btnFeedbackAdicionar.UseVisualStyleBackColor = true;
            this.btnFeedbackAdicionar.Click += new System.EventHandler(this.btnFeedbackAdicionar_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.txtObservacaoEspelhoPed);
            this.groupBox6.Controls.Add(this.label36);
            this.groupBox6.Location = new System.Drawing.Point(6, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1073, 89);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Espelho do Pedido";
            // 
            // txtObservacaoEspelhoPed
            // 
            this.txtObservacaoEspelhoPed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObservacaoEspelhoPed.BindingField = "ObsPadraoEspelho";
            this.txtObservacaoEspelhoPed.DebugMode = false;
            this.txtObservacaoEspelhoPed.LiberadoQuandoCadastroUtilizado = false;
            this.txtObservacaoEspelhoPed.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtObservacaoEspelhoPed.Location = new System.Drawing.Point(129, 19);
            this.txtObservacaoEspelhoPed.ModoBarcode = false;
            this.txtObservacaoEspelhoPed.ModoBusca = false;
            this.txtObservacaoEspelhoPed.Multiline = true;
            this.txtObservacaoEspelhoPed.Name = "txtObservacaoEspelhoPed";
            this.txtObservacaoEspelhoPed.NaoLimparDepoisBarcode = false;
            this.txtObservacaoEspelhoPed.Size = new System.Drawing.Size(920, 57);
            this.txtObservacaoEspelhoPed.TabIndex = 1;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.BindingField = null;
            this.label36.LiberadoQuandoCadastroUtilizado = false;
            this.label36.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label36.Location = new System.Drawing.Point(21, 22);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(102, 13);
            this.label36.TabIndex = 0;
            this.label36.Text = "Observação Padrão";
            // 
            // tabPage4
            // 
            this.tabPage4.AutoScroll = true;
            this.tabPage4.Controls.Add(this.grpComissaoVendedor);
            this.tabPage4.Controls.Add(this.grpComissaoRepresentante);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1087, 649);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Comissões";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // grpComissaoVendedor
            // 
            this.grpComissaoVendedor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpComissaoVendedor.Controls.Add(this.ensVendedor);
            this.grpComissaoVendedor.Controls.Add(this.iwtLabel2);
            this.grpComissaoVendedor.Controls.Add(this.nudComissaoVendedor);
            this.grpComissaoVendedor.Controls.Add(this.iwtLabel3);
            this.grpComissaoVendedor.Location = new System.Drawing.Point(8, 87);
            this.grpComissaoVendedor.Name = "grpComissaoVendedor";
            this.grpComissaoVendedor.Size = new System.Drawing.Size(1071, 71);
            this.grpComissaoVendedor.TabIndex = 1;
            this.grpComissaoVendedor.TabStop = false;
            this.grpComissaoVendedor.Text = "Comissão Vendedor";
            // 
            // ensVendedor
            // 
            this.ensVendedor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ensVendedor.BindingField = "Vendedor";
            this.ensVendedor.ColunasDropdown = null;
            this.ensVendedor.DesabilitarAutoCompletar = false;
            this.ensVendedor.DesabilitarChekBox = false;
            this.ensVendedor.DesabilitarLupa = false;
            this.ensVendedor.DesabilitarSeta = false;
            this.ensVendedor.Enabled = false;
            this.ensVendedor.EntidadeSelecionada = null;
            this.ensVendedor.FormSelecao = null;
            this.ensVendedor.LiberadoQuandoCadastroUtilizado = false;
            this.ensVendedor.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensVendedor.Location = new System.Drawing.Point(86, 16);
            this.ensVendedor.ModoVisualizacaoGrid = null;
            this.ensVendedor.Name = "ensVendedor";
            this.ensVendedor.ParametroBuscaGuiada = null;
            this.ensVendedor.ParametrosBuscaObrigatorios = null;
            this.ensVendedor.Size = new System.Drawing.Size(979, 23);
            this.ensVendedor.TabIndex = 17;
            this.ensVendedor.EntityChange += new System.EventHandler(this.ensVendedor_EntityChange);
            this.ensVendedor.EnabledChanged += new System.EventHandler(this.ensVendedor_EnabledChanged);
            // 
            // iwtLabel2
            // 
            this.iwtLabel2.AutoSize = true;
            this.iwtLabel2.BindingField = null;
            this.iwtLabel2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel2.Location = new System.Drawing.Point(27, 21);
            this.iwtLabel2.Name = "iwtLabel2";
            this.iwtLabel2.Size = new System.Drawing.Size(53, 13);
            this.iwtLabel2.TabIndex = 13;
            this.iwtLabel2.Text = "Vendedor";
            // 
            // nudComissaoVendedor
            // 
            this.nudComissaoVendedor.BindingField = "PercComissaoVendedor";
            this.nudComissaoVendedor.DecimalPlaces = 2;
            this.nudComissaoVendedor.Enabled = false;
            this.nudComissaoVendedor.LiberadoQuandoCadastroUtilizado = false;
            this.nudComissaoVendedor.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudComissaoVendedor.Location = new System.Drawing.Point(86, 45);
            this.nudComissaoVendedor.Name = "nudComissaoVendedor";
            this.nudComissaoVendedor.Size = new System.Drawing.Size(120, 20);
            this.nudComissaoVendedor.TabIndex = 2;
            // 
            // iwtLabel3
            // 
            this.iwtLabel3.AutoSize = true;
            this.iwtLabel3.BindingField = null;
            this.iwtLabel3.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel3.Location = new System.Drawing.Point(15, 49);
            this.iwtLabel3.Name = "iwtLabel3";
            this.iwtLabel3.Size = new System.Drawing.Size(66, 13);
            this.iwtLabel3.TabIndex = 16;
            this.iwtLabel3.Text = "Comissão(%)";
            // 
            // grpComissaoRepresentante
            // 
            this.grpComissaoRepresentante.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpComissaoRepresentante.Controls.Add(this.ensRepresentante);
            this.grpComissaoRepresentante.Controls.Add(this.iwtLabel1);
            this.grpComissaoRepresentante.Controls.Add(this.nudComissaoRepresentante);
            this.grpComissaoRepresentante.Controls.Add(this.label34);
            this.grpComissaoRepresentante.Location = new System.Drawing.Point(8, 6);
            this.grpComissaoRepresentante.Name = "grpComissaoRepresentante";
            this.grpComissaoRepresentante.Size = new System.Drawing.Size(1071, 75);
            this.grpComissaoRepresentante.TabIndex = 0;
            this.grpComissaoRepresentante.TabStop = false;
            this.grpComissaoRepresentante.Text = "Comissão Representante";
            // 
            // ensRepresentante
            // 
            this.ensRepresentante.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ensRepresentante.BindingField = "Representante";
            this.ensRepresentante.ColunasDropdown = null;
            this.ensRepresentante.DesabilitarAutoCompletar = false;
            this.ensRepresentante.DesabilitarChekBox = false;
            this.ensRepresentante.DesabilitarLupa = false;
            this.ensRepresentante.DesabilitarSeta = false;
            this.ensRepresentante.Enabled = false;
            this.ensRepresentante.EntidadeSelecionada = null;
            this.ensRepresentante.FormSelecao = null;
            this.ensRepresentante.LiberadoQuandoCadastroUtilizado = false;
            this.ensRepresentante.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensRepresentante.Location = new System.Drawing.Point(86, 17);
            this.ensRepresentante.ModoVisualizacaoGrid = null;
            this.ensRepresentante.Name = "ensRepresentante";
            this.ensRepresentante.ParametroBuscaGuiada = null;
            this.ensRepresentante.ParametrosBuscaObrigatorios = null;
            this.ensRepresentante.Size = new System.Drawing.Size(975, 23);
            this.ensRepresentante.TabIndex = 17;
            this.ensRepresentante.EntityChange += new System.EventHandler(this.ensRepresentante_EntityChange);
            this.ensRepresentante.EnabledChanged += new System.EventHandler(this.ensRepresentante_EnabledChanged);
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(6, 23);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(77, 13);
            this.iwtLabel1.TabIndex = 13;
            this.iwtLabel1.Text = "Representante";
            // 
            // nudComissaoRepresentante
            // 
            this.nudComissaoRepresentante.BindingField = "PercComissaoRepresentante";
            this.nudComissaoRepresentante.DecimalPlaces = 2;
            this.nudComissaoRepresentante.Enabled = false;
            this.nudComissaoRepresentante.LiberadoQuandoCadastroUtilizado = false;
            this.nudComissaoRepresentante.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudComissaoRepresentante.Location = new System.Drawing.Point(86, 46);
            this.nudComissaoRepresentante.Name = "nudComissaoRepresentante";
            this.nudComissaoRepresentante.Size = new System.Drawing.Size(120, 20);
            this.nudComissaoRepresentante.TabIndex = 4;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BindingField = null;
            this.label34.LiberadoQuandoCadastroUtilizado = false;
            this.label34.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label34.Location = new System.Drawing.Point(15, 50);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(66, 13);
            this.label34.TabIndex = 16;
            this.label34.Text = "Comissão(%)";
            // 
            // tabPage3
            // 
            this.tabPage3.AutoScroll = true;
            this.tabPage3.Controls.Add(this.splitContainer5);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1087, 649);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Qualidade";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer5.Location = new System.Drawing.Point(3, 3);
            this.splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.dgPedidoItemQualidade);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.btnAdd);
            this.splitContainer5.Panel2.Controls.Add(this.btnDownload);
            this.splitContainer5.Panel2.Controls.Add(this.btnRemove);
            this.splitContainer5.Size = new System.Drawing.Size(1081, 643);
            this.splitContainer5.SplitterDistance = 945;
            this.splitContainer5.TabIndex = 7;
            // 
            // dgPedidoItemQualidade
            // 
            this.dgPedidoItemQualidade.AllowUserToAddRows = false;
            this.dgPedidoItemQualidade.AllowUserToDeleteRows = false;
            this.dgPedidoItemQualidade.AllowUserToOrderColumns = true;
            this.dgPedidoItemQualidade.AllowUserToResizeRows = false;
            this.dgPedidoItemQualidade.BackgroundColor = System.Drawing.Color.White;
            this.dgPedidoItemQualidade.CacheDados = null;
            this.dgPedidoItemQualidade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPedidoItemQualidade.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.toDelete,
            this.Column3,
            this.Column1,
            this.Column4});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(209)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgPedidoItemQualidade.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgPedidoItemQualidade.Location = new System.Drawing.Point(0, 0);
            this.dgPedidoItemQualidade.MultiSelect = false;
            this.dgPedidoItemQualidade.Name = "dgPedidoItemQualidade";
            this.dgPedidoItemQualidade.ReadOnly = true;
            this.dgPedidoItemQualidade.RowHeadersVisible = false;
            this.dgPedidoItemQualidade.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPedidoItemQualidade.Size = new System.Drawing.Size(945, 643);
            this.dgPedidoItemQualidade.TabIndex = 3;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "ID";
            this.Column2.HeaderText = "ID";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            // 
            // toDelete
            // 
            this.toDelete.DataPropertyName = "toDelete";
            this.toDelete.HeaderText = "toDelete";
            this.toDelete.Name = "toDelete";
            this.toDelete.ReadOnly = true;
            this.toDelete.Visible = false;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "NomeArquivo";
            this.Column3.HeaderText = "Nome do Arquivo";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 250;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "DescricaoArquivo";
            this.Column1.HeaderText = "Descrição";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 530;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Arquivo";
            this.Column4.HeaderText = "arquivo";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Visible = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.LiberadoQuandoCadastroUtilizado = false;
            this.btnAdd.Location = new System.Drawing.Point(29, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Adicionar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownload.LiberadoQuandoCadastroUtilizado = false;
            this.btnDownload.Location = new System.Drawing.Point(29, 63);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 6;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.LiberadoQuandoCadastroUtilizado = false;
            this.btnRemove.Location = new System.Drawing.Point(29, 33);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "Remover";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.AutoScroll = true;
            this.tabPage5.Controls.Add(this.ensOperacaoCompletaEnvioTerceiros);
            this.tabPage5.Controls.Add(this.lblOperacaoCompletaEnvioTerceiros);
            this.tabPage5.Controls.Add(this.ensOperacaoEnvioTerceiros);
            this.tabPage5.Controls.Add(this.lblOperacaoEnvioTerceiros);
            this.tabPage5.Controls.Add(this.iwtLabel8);
            this.tabPage5.Controls.Add(this.ensClienteEnvioTerceiros);
            this.tabPage5.Controls.Add(this.iwtLabel7);
            this.tabPage5.Controls.Add(this.chkEnvioTerceiros);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1087, 649);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Envio Para Terceiros";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // ensOperacaoCompletaEnvioTerceiros
            // 
            this.ensOperacaoCompletaEnvioTerceiros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ensOperacaoCompletaEnvioTerceiros.BindingField = "OperacaoCompletaEnvioTerceiros";
            this.ensOperacaoCompletaEnvioTerceiros.ColunasDropdown = null;
            this.ensOperacaoCompletaEnvioTerceiros.DesabilitarAutoCompletar = false;
            this.ensOperacaoCompletaEnvioTerceiros.DesabilitarChekBox = true;
            this.ensOperacaoCompletaEnvioTerceiros.DesabilitarLupa = false;
            this.ensOperacaoCompletaEnvioTerceiros.DesabilitarSeta = false;
            this.ensOperacaoCompletaEnvioTerceiros.EntidadeSelecionada = null;
            this.ensOperacaoCompletaEnvioTerceiros.FormSelecao = null;
            this.ensOperacaoCompletaEnvioTerceiros.LiberadoQuandoCadastroUtilizado = false;
            this.ensOperacaoCompletaEnvioTerceiros.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensOperacaoCompletaEnvioTerceiros.Location = new System.Drawing.Point(161, 244);
            this.ensOperacaoCompletaEnvioTerceiros.ModoVisualizacaoGrid = null;
            this.ensOperacaoCompletaEnvioTerceiros.Name = "ensOperacaoCompletaEnvioTerceiros";
            this.ensOperacaoCompletaEnvioTerceiros.ParametroBuscaGuiada = null;
            this.ensOperacaoCompletaEnvioTerceiros.ParametrosBuscaObrigatorios = null;
            this.ensOperacaoCompletaEnvioTerceiros.Size = new System.Drawing.Size(908, 23);
            this.ensOperacaoCompletaEnvioTerceiros.TabIndex = 7;
            // 
            // lblOperacaoCompletaEnvioTerceiros
            // 
            this.lblOperacaoCompletaEnvioTerceiros.AutoSize = true;
            this.lblOperacaoCompletaEnvioTerceiros.BindingField = null;
            this.lblOperacaoCompletaEnvioTerceiros.LiberadoQuandoCadastroUtilizado = false;
            this.lblOperacaoCompletaEnvioTerceiros.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblOperacaoCompletaEnvioTerceiros.Location = new System.Drawing.Point(18, 249);
            this.lblOperacaoCompletaEnvioTerceiros.Name = "lblOperacaoCompletaEnvioTerceiros";
            this.lblOperacaoCompletaEnvioTerceiros.Size = new System.Drawing.Size(137, 13);
            this.lblOperacaoCompletaEnvioTerceiros.TabIndex = 6;
            this.lblOperacaoCompletaEnvioTerceiros.Text = "Operacao - Envio Terceiros";
            // 
            // ensOperacaoEnvioTerceiros
            // 
            this.ensOperacaoEnvioTerceiros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ensOperacaoEnvioTerceiros.BindingField = "OperacaoEnvioTerceiros";
            this.ensOperacaoEnvioTerceiros.ColunasDropdown = null;
            this.ensOperacaoEnvioTerceiros.DesabilitarAutoCompletar = false;
            this.ensOperacaoEnvioTerceiros.DesabilitarChekBox = true;
            this.ensOperacaoEnvioTerceiros.DesabilitarLupa = false;
            this.ensOperacaoEnvioTerceiros.DesabilitarSeta = false;
            this.ensOperacaoEnvioTerceiros.EntidadeSelecionada = null;
            this.ensOperacaoEnvioTerceiros.FormSelecao = null;
            this.ensOperacaoEnvioTerceiros.LiberadoQuandoCadastroUtilizado = false;
            this.ensOperacaoEnvioTerceiros.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensOperacaoEnvioTerceiros.Location = new System.Drawing.Point(161, 207);
            this.ensOperacaoEnvioTerceiros.ModoVisualizacaoGrid = null;
            this.ensOperacaoEnvioTerceiros.Name = "ensOperacaoEnvioTerceiros";
            this.ensOperacaoEnvioTerceiros.ParametroBuscaGuiada = null;
            this.ensOperacaoEnvioTerceiros.ParametrosBuscaObrigatorios = null;
            this.ensOperacaoEnvioTerceiros.Size = new System.Drawing.Size(908, 23);
            this.ensOperacaoEnvioTerceiros.TabIndex = 5;
            // 
            // lblOperacaoEnvioTerceiros
            // 
            this.lblOperacaoEnvioTerceiros.AutoSize = true;
            this.lblOperacaoEnvioTerceiros.BindingField = null;
            this.lblOperacaoEnvioTerceiros.LiberadoQuandoCadastroUtilizado = false;
            this.lblOperacaoEnvioTerceiros.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblOperacaoEnvioTerceiros.Location = new System.Drawing.Point(18, 212);
            this.lblOperacaoEnvioTerceiros.Name = "lblOperacaoEnvioTerceiros";
            this.lblOperacaoEnvioTerceiros.Size = new System.Drawing.Size(137, 13);
            this.lblOperacaoEnvioTerceiros.TabIndex = 4;
            this.lblOperacaoEnvioTerceiros.Text = "Operacao - Envio Terceiros";
            // 
            // iwtLabel8
            // 
            this.iwtLabel8.AutoSize = true;
            this.iwtLabel8.BindingField = null;
            this.iwtLabel8.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel8.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel8.Location = new System.Drawing.Point(33, 157);
            this.iwtLabel8.Name = "iwtLabel8";
            this.iwtLabel8.Size = new System.Drawing.Size(122, 13);
            this.iwtLabel8.TabIndex = 3;
            this.iwtLabel8.Text = "Cliente - Envio Terceiros";
            // 
            // ensClienteEnvioTerceiros
            // 
            this.ensClienteEnvioTerceiros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ensClienteEnvioTerceiros.BindingField = "ClienteEnvioTerceiros";
            this.ensClienteEnvioTerceiros.ColunasDropdown = null;
            this.ensClienteEnvioTerceiros.DesabilitarAutoCompletar = false;
            this.ensClienteEnvioTerceiros.DesabilitarChekBox = true;
            this.ensClienteEnvioTerceiros.DesabilitarLupa = false;
            this.ensClienteEnvioTerceiros.DesabilitarSeta = false;
            this.ensClienteEnvioTerceiros.EntidadeSelecionada = null;
            this.ensClienteEnvioTerceiros.FormSelecao = null;
            this.ensClienteEnvioTerceiros.LiberadoQuandoCadastroUtilizado = false;
            this.ensClienteEnvioTerceiros.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensClienteEnvioTerceiros.Location = new System.Drawing.Point(161, 152);
            this.ensClienteEnvioTerceiros.ModoVisualizacaoGrid = null;
            this.ensClienteEnvioTerceiros.Name = "ensClienteEnvioTerceiros";
            this.ensClienteEnvioTerceiros.ParametroBuscaGuiada = null;
            this.ensClienteEnvioTerceiros.ParametrosBuscaObrigatorios = null;
            this.ensClienteEnvioTerceiros.Size = new System.Drawing.Size(908, 23);
            this.ensClienteEnvioTerceiros.TabIndex = 2;
            // 
            // iwtLabel7
            // 
            this.iwtLabel7.BindingField = null;
            this.iwtLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iwtLabel7.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel7.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel7.Location = new System.Drawing.Point(13, 16);
            this.iwtLabel7.Name = "iwtLabel7";
            this.iwtLabel7.Size = new System.Drawing.Size(1056, 66);
            this.iwtLabel7.TabIndex = 1;
            this.iwtLabel7.Text = resources.GetString("iwtLabel7.Text");
            this.iwtLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkEnvioTerceiros
            // 
            this.chkEnvioTerceiros.AutoSize = true;
            this.chkEnvioTerceiros.BindingField = "EnvioTerceiros";
            this.chkEnvioTerceiros.LiberadoQuandoCadastroUtilizado = false;
            this.chkEnvioTerceiros.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkEnvioTerceiros.Location = new System.Drawing.Point(16, 106);
            this.chkEnvioTerceiros.Name = "chkEnvioTerceiros";
            this.chkEnvioTerceiros.Size = new System.Drawing.Size(124, 17);
            this.chkEnvioTerceiros.TabIndex = 0;
            this.chkEnvioTerceiros.Text = "Envio para Terceiros";
            this.chkEnvioTerceiros.UseVisualStyleBackColor = true;
            this.chkEnvioTerceiros.CheckedChanged += new System.EventHandler(this.chkEnvioTerceiros_CheckedChanged);
            // 
            // tabHistoricoAlteracoes
            // 
            this.tabHistoricoAlteracoes.Controls.Add(this.dgvHistoricoAlteracoes);
            this.tabHistoricoAlteracoes.Location = new System.Drawing.Point(4, 22);
            this.tabHistoricoAlteracoes.Name = "tabHistoricoAlteracoes";
            this.tabHistoricoAlteracoes.Padding = new System.Windows.Forms.Padding(3);
            this.tabHistoricoAlteracoes.Size = new System.Drawing.Size(1087, 649);
            this.tabHistoricoAlteracoes.TabIndex = 5;
            this.tabHistoricoAlteracoes.Text = "Histórico de Alterações";
            this.tabHistoricoAlteracoes.UseVisualStyleBackColor = true;
            // 
            // dgvHistoricoAlteracoes
            // 
            this.dgvHistoricoAlteracoes.AllowUserToAddRows = false;
            this.dgvHistoricoAlteracoes.AllowUserToDeleteRows = false;
            this.dgvHistoricoAlteracoes.AllowUserToOrderColumns = true;
            this.dgvHistoricoAlteracoes.AllowUserToResizeRows = false;
            this.dgvHistoricoAlteracoes.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistoricoAlteracoes.CacheDados = null;
            this.dgvHistoricoAlteracoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistoricoAlteracoes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.PedidoItem,
            this.Justificativa,
            this.Data,
            this.Usuario});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(209)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHistoricoAlteracoes.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHistoricoAlteracoes.Location = new System.Drawing.Point(3, 3);
            this.dgvHistoricoAlteracoes.Name = "dgvHistoricoAlteracoes";
            this.dgvHistoricoAlteracoes.ReadOnly = true;
            this.dgvHistoricoAlteracoes.RowHeadersVisible = false;
            this.dgvHistoricoAlteracoes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistoricoAlteracoes.Size = new System.Drawing.Size(1081, 643);
            this.dgvHistoricoAlteracoes.TabIndex = 1;
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // PedidoItem
            // 
            this.PedidoItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PedidoItem.DataPropertyName = "PedidoItem";
            this.PedidoItem.HeaderText = "Pedido Item";
            this.PedidoItem.Name = "PedidoItem";
            this.PedidoItem.ReadOnly = true;
            this.PedidoItem.Width = 150;
            // 
            // Justificativa
            // 
            this.Justificativa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Justificativa.DataPropertyName = "Justificativa";
            this.Justificativa.HeaderText = "Justificativa";
            this.Justificativa.Name = "Justificativa";
            this.Justificativa.ReadOnly = true;
            this.Justificativa.Width = 350;
            // 
            // Data
            // 
            this.Data.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Data.DataPropertyName = "Data";
            this.Data.HeaderText = "Data";
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            // 
            // Usuario
            // 
            this.Usuario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Usuario.DataPropertyName = "Usuario";
            this.Usuario.HeaderText = "Usuário";
            this.Usuario.Name = "Usuario";
            this.Usuario.ReadOnly = true;
            this.Usuario.Width = 150;
            // 
            // tabFeedbackSecundario
            // 
            this.tabFeedbackSecundario.Controls.Add(this.grbFeedbackSecundario);
            this.tabFeedbackSecundario.Location = new System.Drawing.Point(4, 22);
            this.tabFeedbackSecundario.Name = "tabFeedbackSecundario";
            this.tabFeedbackSecundario.Padding = new System.Windows.Forms.Padding(3);
            this.tabFeedbackSecundario.Size = new System.Drawing.Size(1087, 649);
            this.tabFeedbackSecundario.TabIndex = 6;
            this.tabFeedbackSecundario.Text = "Planejamento";
            this.tabFeedbackSecundario.UseVisualStyleBackColor = true;
            // 
            // grbFeedbackSecundario
            // 
            this.grbFeedbackSecundario.Controls.Add(this.splitContainer7);
            this.grbFeedbackSecundario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbFeedbackSecundario.Location = new System.Drawing.Point(3, 3);
            this.grbFeedbackSecundario.Name = "grbFeedbackSecundario";
            this.grbFeedbackSecundario.Size = new System.Drawing.Size(1081, 643);
            this.grbFeedbackSecundario.TabIndex = 3;
            this.grbFeedbackSecundario.TabStop = false;
            this.grbFeedbackSecundario.Text = "Planejamento";
            // 
            // splitContainer7
            // 
            this.splitContainer7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer7.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer7.Location = new System.Drawing.Point(3, 16);
            this.splitContainer7.Name = "splitContainer7";
            // 
            // splitContainer7.Panel1
            // 
            this.splitContainer7.Panel1.Controls.Add(this.dgvFeedbacksSecundarios);
            // 
            // splitContainer7.Panel2
            // 
            this.splitContainer7.Panel2.Controls.Add(this.btnFeedbackSecundarioOk);
            this.splitContainer7.Panel2.Controls.Add(this.txtFeedbackSecundario);
            this.splitContainer7.Panel2.Controls.Add(this.iwtLabel11);
            this.splitContainer7.Panel2.Controls.Add(this.btnFeedbackSecundarioAdicionar);
            this.splitContainer7.Size = new System.Drawing.Size(1075, 624);
            this.splitContainer7.SplitterDistance = 728;
            this.splitContainer7.TabIndex = 0;
            // 
            // dgvFeedbacksSecundarios
            // 
            this.dgvFeedbacksSecundarios.AllowUserToAddRows = false;
            this.dgvFeedbacksSecundarios.AllowUserToDeleteRows = false;
            this.dgvFeedbacksSecundarios.AllowUserToOrderColumns = true;
            this.dgvFeedbacksSecundarios.AllowUserToResizeRows = false;
            this.dgvFeedbacksSecundarios.BackgroundColor = System.Drawing.Color.White;
            this.dgvFeedbacksSecundarios.CacheDados = null;
            this.dgvFeedbacksSecundarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(209)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFeedbacksSecundarios.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvFeedbacksSecundarios.Location = new System.Drawing.Point(0, 0);
            this.dgvFeedbacksSecundarios.MultiSelect = false;
            this.dgvFeedbacksSecundarios.Name = "dgvFeedbacksSecundarios";
            this.dgvFeedbacksSecundarios.ReadOnly = true;
            this.dgvFeedbacksSecundarios.RowHeadersVisible = false;
            this.dgvFeedbacksSecundarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFeedbacksSecundarios.Size = new System.Drawing.Size(728, 624);
            this.dgvFeedbacksSecundarios.TabIndex = 0;
            this.dgvFeedbacksSecundarios.SelectionChanged += new System.EventHandler(this.dgvFeedbacksSecundarios_SelectionChanged);
            // 
            // btnFeedbackSecundarioOk
            // 
            this.btnFeedbackSecundarioOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFeedbackSecundarioOk.Enabled = false;
            this.btnFeedbackSecundarioOk.LiberadoQuandoCadastroUtilizado = false;
            this.btnFeedbackSecundarioOk.Location = new System.Drawing.Point(265, 565);
            this.btnFeedbackSecundarioOk.Name = "btnFeedbackSecundarioOk";
            this.btnFeedbackSecundarioOk.Size = new System.Drawing.Size(75, 23);
            this.btnFeedbackSecundarioOk.TabIndex = 3;
            this.btnFeedbackSecundarioOk.Text = "OK";
            this.btnFeedbackSecundarioOk.UseVisualStyleBackColor = true;
            this.btnFeedbackSecundarioOk.Click += new System.EventHandler(this.btnFeedbackSecundarioOk_Click);
            // 
            // txtFeedbackSecundario
            // 
            this.txtFeedbackSecundario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFeedbackSecundario.BindingField = null;
            this.txtFeedbackSecundario.DebugMode = false;
            this.txtFeedbackSecundario.Enabled = false;
            this.txtFeedbackSecundario.LiberadoQuandoCadastroUtilizado = false;
            this.txtFeedbackSecundario.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtFeedbackSecundario.Location = new System.Drawing.Point(18, 61);
            this.txtFeedbackSecundario.ModoBarcode = false;
            this.txtFeedbackSecundario.ModoBusca = false;
            this.txtFeedbackSecundario.Multiline = true;
            this.txtFeedbackSecundario.Name = "txtFeedbackSecundario";
            this.txtFeedbackSecundario.NaoLimparDepoisBarcode = false;
            this.txtFeedbackSecundario.Size = new System.Drawing.Size(307, 488);
            this.txtFeedbackSecundario.TabIndex = 2;
            // 
            // iwtLabel11
            // 
            this.iwtLabel11.AutoSize = true;
            this.iwtLabel11.BindingField = null;
            this.iwtLabel11.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel11.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel11.Location = new System.Drawing.Point(3, 45);
            this.iwtLabel11.Name = "iwtLabel11";
            this.iwtLabel11.Size = new System.Drawing.Size(101, 13);
            this.iwtLabel11.TabIndex = 1;
            this.iwtLabel11.Text = "Texto Planejamento";
            // 
            // btnFeedbackSecundarioAdicionar
            // 
            this.btnFeedbackSecundarioAdicionar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFeedbackSecundarioAdicionar.LiberadoQuandoCadastroUtilizado = false;
            this.btnFeedbackSecundarioAdicionar.Location = new System.Drawing.Point(18, 8);
            this.btnFeedbackSecundarioAdicionar.Name = "btnFeedbackSecundarioAdicionar";
            this.btnFeedbackSecundarioAdicionar.Size = new System.Drawing.Size(307, 23);
            this.btnFeedbackSecundarioAdicionar.TabIndex = 0;
            this.btnFeedbackSecundarioAdicionar.Text = "Adicionar Planejamento";
            this.btnFeedbackSecundarioAdicionar.UseVisualStyleBackColor = true;
            this.btnFeedbackSecundarioAdicionar.Click += new System.EventHandler(this.btnFeedbackSecundarioAdicionar_Click);
            // 
            // btnCopiar
            // 
            this.btnCopiar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopiar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCopiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopiar.LiberadoQuandoCadastroUtilizado = false;
            this.btnCopiar.Location = new System.Drawing.Point(407, 12);
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(279, 23);
            this.btnCopiar.TabIndex = 2;
            this.btnCopiar.Text = "Copiar Pedido";
            this.btnCopiar.UseVisualStyleBackColor = false;
            this.btnCopiar.Click += new System.EventHandler(this.btnCopiar_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.InitialDirectory = "C:\\";
            this.openFileDialog1.Title = "Localizar Arquivos";
            // 
            // possuiProdutosVencidosLbl
            // 
            this.possuiProdutosVencidosLbl.AutoSize = true;
            this.possuiProdutosVencidosLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.possuiProdutosVencidosLbl.ForeColor = System.Drawing.Color.Red;
            this.possuiProdutosVencidosLbl.Location = new System.Drawing.Point(110, 12);
            this.possuiProdutosVencidosLbl.Name = "possuiProdutosVencidosLbl";
            this.possuiProdutosVencidosLbl.Size = new System.Drawing.Size(265, 20);
            this.possuiProdutosVencidosLbl.TabIndex = 3;
            this.possuiProdutosVencidosLbl.Text = "Possui Produtos com Preço Vencido";
            this.possuiProdutosVencidosLbl.Visible = false;
            // 
            // CadPedidoItemForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1095, 726);
            this.Name = "CadPedidoItemForm";
            this.Text = "Pedido";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ensOperacaoCompleta.ResumeLayout(false);
            this.ensOperacaoCompleta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPosicao)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.grpFreteResponsavel.ResumeLayout(false);
            this.grpFreteResponsavel.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFrete)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDataPedido)).EndInit();
            this.grbCancelamento.ResumeLayout(false);
            this.grbCancelamento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpCancelamentoData)).EndInit();
            this.grbOriginais.ResumeLayout(false);
            this.grbOriginais.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudValorOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDataEntregaOriginal)).EndInit();
            this.gbxUrgente.ResumeLayout(false);
            this.gbxUrgente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpUrgenteData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDataEntrega)).EndInit();
            this.gbxPrincipal.ResumeLayout(false);
            this.gbxPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDesconto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudValorUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQtd)).EndInit();
            this.gbxItem.ResumeLayout(false);
            this.gbxItem.PerformLayout();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.ensSubItem.ResumeLayout(false);
            this.ensSubItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQtdItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.grbFeedback.ResumeLayout(false);
            this.splitContainer6.Panel1.ResumeLayout(false);
            this.splitContainer6.Panel2.ResumeLayout(false);
            this.splitContainer6.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).EndInit();
            this.splitContainer6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeedbacks)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.grpComissaoVendedor.ResumeLayout(false);
            this.grpComissaoVendedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudComissaoVendedor)).EndInit();
            this.grpComissaoRepresentante.ResumeLayout(false);
            this.grpComissaoRepresentante.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudComissaoRepresentante)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPedidoItemQualidade)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabHistoricoAlteracoes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoricoAlteracoes)).EndInit();
            this.tabFeedbackSecundario.ResumeLayout(false);
            this.grbFeedbackSecundario.ResumeLayout(false);
            this.splitContainer7.Panel1.ResumeLayout(false);
            this.splitContainer7.Panel2.ResumeLayout(false);
            this.splitContainer7.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).EndInit();
            this.splitContainer7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeedbacksSecundarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion


        private IWTDotNetLib.IWTButton btnCopiar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox groupBox1;
        private IWTDotNetLib.IWTButton btnDocumentosPedido;
        private System.Windows.Forms.GroupBox groupBox4;
        private IWTDotNetLib.IWTCheckBox chkFreteSemResponsavel;
        private System.Windows.Forms.GroupBox grpFreteResponsavel;
        private IWTDotNetLib.IWTRadioButton rdbFreteSemFrete;
        private IWTDotNetLib.IWTRadioButton rdbFreteDestinatario;
        private IWTDotNetLib.IWTRadioButton rdbFreteEmitente;
        private IWTDotNetLib.IWTRadioButton rdbFreteTerceiros;
        private System.Windows.Forms.GroupBox groupBox5;
        private IWTDotNetLib.IWTRadioButton rdbFreteNormal;
        private IWTDotNetLib.IWTRadioButton rdbFreteRateado;
        private IWTDotNetLib.IWTNumericUpDown nudFrete;
        private IWTDotNetLib.IWTLabel label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private IWTDotNetLib.IWTLabel label35;
        private IWTDotNetLib.IWTTextBox txtOrdemVenda;
        private IWTDotNetLib.IWTTextBox txtProjeto;
        private IWTDotNetLib.IWTLabel label19;
        private IWTDotNetLib.IWTTextBox txtArmazenagem;
        private IWTDotNetLib.IWTButton btnMateriaisCliente;
        private IWTDotNetLib.IWTLabel label20;
        private System.Windows.Forms.GroupBox groupBox3;
        private IWTDotNetLib.IWTCheckBox cbxEntregaParc;
        private IWTDotNetLib.IWTCheckBox cbxVolumeUnico;
        private IWTDotNetLib.IWTCheckBox chkRastrearMP;
        private IWTDotNetLib.IWTCheckBox chkExportacao;
        private System.Windows.Forms.GroupBox groupBox7;
        private IWTDotNetLib.IWTLabel label33;
        private IWTDotNetLib.IWTLabel label9;
        private IWTDotNetLib.IWTLabel label32;
        private IWTDotNetLib.IWTCheckBox chkTipoKit;
        private IWTDotNetLib.IWTComboBox cmbTipoKit;
        private IWTDotNetLib.IWTLabel label8;
        private IWTDotNetLib.IWTTextBox txtInfoEspeciais;
        private IWTDotNetLib.IWTLabel label3;
        private IWTDotNetLib.IWTLabel label31;
        private IWTDotNetLib.IWTDateTimePicker dtpDataPedido;
        private System.Windows.Forms.GroupBox grbCancelamento;
        private IWTDotNetLib.IWTTextBox txtCancelamentoJustificativa;
        private IWTDotNetLib.IWTLabel label30;
        private IWTDotNetLib.IWTDateTimePicker dtpCancelamentoData;
        private IWTDotNetLib.IWTLabel label29;
        private IWTDotNetLib.IWTTextBox txtCancelamentoUsuario;
        private IWTDotNetLib.IWTLabel label26;
        private System.Windows.Forms.GroupBox grbOriginais;
        private IWTDotNetLib.IWTNumericUpDown nudValorOriginal;
        private IWTDotNetLib.IWTLabel label16;
        private IWTDotNetLib.IWTDateTimePicker dtpDataEntregaOriginal;
        private IWTDotNetLib.IWTLabel label14;
        private System.Windows.Forms.GroupBox gbxUrgente;
        private IWTDotNetLib.IWTTextBox txtUrgenteInfos;
        private IWTDotNetLib.IWTLabel label13;
        private IWTDotNetLib.IWTDateTimePicker dtpUrgenteData;
        private IWTDotNetLib.IWTLabel label12;
        private IWTDotNetLib.IWTTextBox txtUrgenteSolicitante;
        private IWTDotNetLib.IWTLabel label6;
        private IWTDotNetLib.IWTRadioButton rdbUrgenteCritico;
        private IWTDotNetLib.IWTRadioButton rdbUrgenteUrgente;
        private IWTDotNetLib.IWTRadioButton rdbUrgenteAntecipacao;
        private IWTDotNetLib.IWTRadioButton rdbUrgenteNormal;
        private IWTDotNetLib.IWTButton btnVariaveis;
        private IWTDotNetLib.IWTLabel label22;
        private IWTDotNetLib.IWTDateTimePicker dtpDataEntrega;
        private IWTDotNetLib.IWTLabel label7;
        private IWTDotNetLib.IWTLabel label17;
        private IWTDotNetLib.IWTMaskedTextBox txtOc;
        private IWTDotNetLib.IWTLabel label23;
        private IWTDotNetLib.IWTLabel label18;
        private System.Windows.Forms.GroupBox gbxPrincipal;
        private System.Windows.Forms.LinkLabel lnkDetalhesPrincipal;
        private IWTDotNetLib.IWTLabel lblTotal;
        private IWTDotNetLib.IWTLabel label21;
        private IWTDotNetLib.IWTLabel label15;
        private IWTDotNetLib.IWTNumericUpDown nudValorUnit;
        private IWTDotNetLib.IWTLabel label5;
        private IWTDotNetLib.IWTNumericUpDown nudQtd;
        private IWTDotNetLib.IWTTextBox txtDescricao;
        private IWTDotNetLib.IWTLabel label2;
        private IWTDotNetLib.IWTTextBox txtCodigo;
        private IWTDotNetLib.IWTLabel label4;
        private System.Windows.Forms.GroupBox gbxItem;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.LinkLabel lnkDetalhesSub;
        private IWTDotNetLib.IWTButton btnEditarItem;
        private IWTDotNetLib.IWTLabel label28;
        private IWTDotNetLib.IWTTextBox txtCodigoItem;
        private IWTDotNetLib.IWTLabel label27;
        private IWTDotNetLib.IWTLabel label10;
        private IWTDotNetLib.IWTTextBox txtDescricaoItem;
        private IWTDotNetLib.IWTNumericUpDown nudQtdItem;
        private IWTDotNetLib.IWTLabel label25;
        private IWTDotNetLib.IWTButton btnAdicionar;
        private IWTDotNetLib.IWTButton btnRemover;
        private IWTDotNetLib.IWTButton btnConfirmarEdicao;
        private IWTDotNetLib.IWTDataGridView dataGridView1;
        private IWTDotNetLib.IWTLabel label24;
        private IWTDotNetLib.IWTComboBox comboBox4;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox6;
        private IWTDotNetLib.IWTLabel label36;
        private IWTDotNetLib.IWTTextBox txtObservacaoEspelhoPed;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private IWTDotNetLib.IWTButton btnDownload;
        private IWTDotNetLib.IWTButton btnRemove;
        private IWTDotNetLib.IWTButton btnAdd;
        private IWTDotNetLib.IWTDataGridView dgPedidoItemQualidade;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn toDelete;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column4;
        private GroupBox grbFeedback;
        private SplitContainer splitContainer6;
        private IWTDotNetLib.IWTButton btnFeedbackAdicionar;
        private IWTDotNetLib.IWTLabel label37;
        private IWTDotNetLib.IWTButton btnFeedbackOk;
        private IWTDotNetLib.IWTTextBox txtFeedback;
        private IWTDotNetLib.IWTDataGridView dgvFeedbacks;
        private TabPage tabPage4;
        private GroupBox grpComissaoRepresentante;
        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTNumericUpDown nudComissaoRepresentante;
        private IWTDotNetLib.IWTLabel label34;
        private GroupBox grpComissaoVendedor;
        private IWTDotNetLib.IWTLabel iwtLabel2;
        private IWTDotNetLib.IWTNumericUpDown nudComissaoVendedor;
        private IWTDotNetLib.IWTLabel iwtLabel3;
        private IWTDotNetLib.IWTEntitySelection ensItemPrincipal;
        private IWTDotNetLib.IWTEntitySelection ensSubItem;
        private IWTDotNetLib.IWTCheckBox chk;
        private IWTDotNetLib.IWTTextBox txt;
        private IWTDotNetLib.IWTEntitySelection ensCliente;
        private IWTDotNetLib.IWTEntitySelection ensOperacao;
        private IWTDotNetLib.IWTEntitySelection ensContaBancaria;
        private IWTDotNetLib.IWTEntitySelection ensFormaPagamento;
        private IWTDotNetLib.IWTEntitySelection ensCentroCustoLucro;
        private IWTDotNetLib.IWTEntitySelection ensVendedor;
        private IWTDotNetLib.IWTEntitySelection ensRepresentante;
        private IWTDotNetLib.IWTNumericUpDown nudPosicao;
        private DataGridViewTextBoxColumn Produto;
        private DataGridViewTextBoxColumn ProdutoCodigoCliente;
        private DataGridViewTextBoxColumn ProdutoDescricaoCliente;
        private DataGridViewTextBoxColumn Quantidade;
        private GroupBox groupBox8;
        private IWTDotNetLib.IWTTextBox iwtTextBox1;
        private IWTDotNetLib.IWTLabel iwtLabel4;
        private IWTDotNetLib.IWTEntitySelection ensNCM;
        private IWTDotNetLib.IWTRadioButton iwtRadioButton1;
        private IWTDotNetLib.IWTRadioButton iwtRadioButton2;
        private IWTDotNetLib.IWTLabel iwtLabel5;
        private IWTDotNetLib.IWTRadioButton rdbEmissorNFeSecundario;
        private IWTDotNetLib.IWTRadioButton rdbEmissorNFePrimario;
        private IWTDotNetLib.IWTEntitySelection ensOperacaoCompleta;
        private IWTDotNetLib.IWTCheckBox object_b471de83_fc7c_41a4_afcc_245cbad138db;
        private IWTDotNetLib.IWTTextBox object_a07cbcd3_dae8_4fc4_8aa6_6a8d61fd128b;
        private TabPage tabPage5;
        private IWTDotNetLib.IWTLabel iwtLabel7;
        private IWTDotNetLib.IWTCheckBox chkEnvioTerceiros;
        private IWTDotNetLib.IWTLabel iwtLabel8;
        private IWTDotNetLib.IWTEntitySelection ensClienteEnvioTerceiros;
        private IWTDotNetLib.IWTLabel lblOperacaoEnvioTerceiros;
        private IWTDotNetLib.IWTEntitySelection ensOperacaoEnvioTerceiros;
        private IWTDotNetLib.IWTEntitySelection ensOperacaoCompletaEnvioTerceiros;
        private IWTDotNetLib.IWTLabel lblOperacaoCompletaEnvioTerceiros;
        private LinkLabel lnkEstrutura;
        private IWTDotNetLib.IWTLabel iwtLabel9;
        private IWTDotNetLib.IWTNumericUpDown nudDesconto;
        private IWTDotNetLib.IWTLabel iwtLabel10;
        private IWTDotNetLib.IWTEntitySelection ensPedidoClassificacao;
        private TabPage tabHistoricoAlteracoes;
        private IWTDotNetLib.IWTDataGridView dgvHistoricoAlteracoes;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn PedidoItem;
        private DataGridViewTextBoxColumn Justificativa;
        private DataGridViewTextBoxColumn Data;
        private DataGridViewTextBoxColumn Usuario;
        private TabPage tabFeedbackSecundario;
        private GroupBox grbFeedbackSecundario;
        private SplitContainer splitContainer7;
        private IWTDotNetLib.IWTDataGridView dgvFeedbacksSecundarios;
        private IWTDotNetLib.IWTButton btnFeedbackSecundarioOk;
        private IWTDotNetLib.IWTTextBox txtFeedbackSecundario;
        private IWTDotNetLib.IWTLabel iwtLabel11;
        private IWTDotNetLib.IWTButton btnFeedbackSecundarioAdicionar;
        private Label possuiProdutosVencidosLbl;
    }
}