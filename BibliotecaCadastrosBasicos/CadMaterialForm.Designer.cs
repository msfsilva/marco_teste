using System.Windows.Forms;

namespace BibliotecaCadastrosBasicos
{
    partial class CadMaterialForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lnkConfiguracoes = new IWTDotNetLib.IWTLinkLabel(this.components);
            this.grbPrincipal = new System.Windows.Forms.GroupBox();
            this.iwtTextBox1 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new IWTDotNetLib.IWTLabel(this.components);
            this.FamiliaMaterial = new IWTDotNetLib.IWTMultiColumnComboBox(this.components);
            this.label7 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtCodigo = new IWTDotNetLib.IWTTextBox(this.components);
            this.txtMatMarcasHomologadas = new IWTDotNetLib.IWTTextBox(this.components);
            this.label6 = new IWTDotNetLib.IWTLabel(this.components);
            this.label21 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudComprimento = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.nudLargura = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.label8 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtMatDescricaoComplementar = new IWTDotNetLib.IWTTextBox(this.components);
            this.label5 = new IWTDotNetLib.IWTLabel(this.components);
            this.label1 = new IWTDotNetLib.IWTLabel(this.components);
            this.Acabamento = new IWTDotNetLib.IWTMultiColumnComboBox(this.components);
            this.label10 = new IWTDotNetLib.IWTLabel(this.components);
            this.UnidadeMedida = new IWTDotNetLib.IWTMultiColumnComboBox(this.components);
            this.txtMatDescricao = new IWTDotNetLib.IWTTextBox(this.components);
            this.nudMatMedida = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.label2 = new IWTDotNetLib.IWTLabel(this.components);
            this.label3 = new IWTDotNetLib.IWTLabel(this.components);
            this.grbCompras = new System.Windows.Forms.GroupBox();
            this.nudLotePadrao = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.iwtLabel2 = new IWTDotNetLib.IWTLabel(this.components);
            this.lblSugestaoLeadTime = new IWTDotNetLib.IWTLabel(this.components);
            this.nudMargemRecebimento = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.label37 = new IWTDotNetLib.IWTLabel(this.components);
            this.chkMargemRecebimento = new IWTDotNetLib.IWTCheckBox(this.components);
            this.chkComprador = new IWTDotNetLib.IWTCheckBox(this.components);
            this.Comprador = new IWTDotNetLib.IWTMultiColumnComboBox(this.components);
            this.label31 = new IWTDotNetLib.IWTLabel(this.components);
            this.lblLeadtimeCompras = new IWTDotNetLib.IWTLabel(this.components);
            this.lblLeadtimePCP = new IWTDotNetLib.IWTLabel(this.components);
            this.nudLeadtimeCompra = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.label20 = new IWTDotNetLib.IWTLabel(this.components);
            this.chkUnidadeCompra = new IWTDotNetLib.IWTCheckBox(this.components);
            this.lblUnidades = new IWTDotNetLib.IWTLabel(this.components);
            this.nudConversaoUnidades = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.label16 = new IWTDotNetLib.IWTLabel(this.components);
            this.label15 = new IWTDotNetLib.IWTLabel(this.components);
            this.UnidadeMedidaCompra = new IWTDotNetLib.IWTMultiColumnComboBox(this.components);
            this.nudLoteMinimo = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.label14 = new IWTDotNetLib.IWTLabel(this.components);
            this.grbPoliticaEstoque = new System.Windows.Forms.GroupBox();
            this.chkImpedirSolicitacaoAutomatica = new IWTDotNetLib.IWTCheckBox(this.components);
            this.lblSugeridoAcimaCompras = new IWTDotNetLib.IWTLabel(this.components);
            this.lblDisparo = new IWTDotNetLib.IWTLabel(this.components);
            this.label23 = new IWTDotNetLib.IWTLabel(this.components);
            this.label22 = new IWTDotNetLib.IWTLabel(this.components);
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblFaixaC = new IWTDotNetLib.IWTLabel(this.components);
            this.lblFaixaB = new IWTDotNetLib.IWTLabel(this.components);
            this.lblFaixaA = new IWTDotNetLib.IWTLabel(this.components);
            this.lblClassificacaoABC = new IWTDotNetLib.IWTLabel(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label13 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudVerde = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.lblReverVermelho = new IWTDotNetLib.IWTLabel(this.components);
            this.nudAmarelo = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.lblReverAmarelo = new IWTDotNetLib.IWTLabel(this.components);
            this.label12 = new IWTDotNetLib.IWTLabel(this.components);
            this.lblReverVerde = new IWTDotNetLib.IWTLabel(this.components);
            this.nudVermelho = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.label11 = new IWTDotNetLib.IWTLabel(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label17 = new IWTDotNetLib.IWTLabel(this.components);
            this.lblVermelhoSugerido = new IWTDotNetLib.IWTLabel(this.components);
            this.label18 = new IWTDotNetLib.IWTLabel(this.components);
            this.lblVerdeSugerido = new IWTDotNetLib.IWTLabel(this.components);
            this.label19 = new IWTDotNetLib.IWTLabel(this.components);
            this.lbAmareloSugerido = new IWTDotNetLib.IWTLabel(this.components);
            this.rdbNaoAplicavel = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbProducaoRepetitiva = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbMRP = new IWTDotNetLib.IWTRadioButton(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.chkFornecedorPreferencial = new IWTDotNetLib.IWTCheckBox(this.components);
            this.ensFornecedor = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.chkUnidadeCompraFornecedor = new IWTDotNetLib.IWTCheckBox(this.components);
            this.grbUnidadeCompraFornecedor = new System.Windows.Forms.GroupBox();
            this.iwtLabel3 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudFornecedorLotePadrao = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.cmbFornecedorUnidadeCompra = new IWTDotNetLib.IWTMultiColumnComboBox(this.components);
            this.label36 = new IWTDotNetLib.IWTLabel(this.components);
            this.label35 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudFornecedorUnidadesPorUnidadeCompra = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.nudFornecedorLoteMinimo = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.label34 = new IWTDotNetLib.IWTLabel(this.components);
            this.label30 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudIPINaoIncluso = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.label28 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudImcsIncluso = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.label29 = new IWTDotNetLib.IWTLabel(this.components);
            this.lblFornecedorUnidadeCompra = new IWTDotNetLib.IWTLabel(this.components);
            this.label27 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudUltimoPreco = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.label9 = new IWTDotNetLib.IWTLabel(this.components);
            this.btnRemove = new IWTDotNetLib.IWTButton(this.components);
            this.btnAdd = new IWTDotNetLib.IWTButton(this.components);
            this.dataGridView1 = new IWTDotNetLib.IWTDataGridView(this.components);
            this.FornecedorNomeFantasia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FornecedorRazao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UltimoPreco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IPI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ICMS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UltimoCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnidadeCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtdPorUnidadeCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoteMinimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LotePadraoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PreferencialColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label33 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudControleValidadeMeses = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.label32 = new IWTDotNetLib.IWTLabel(this.components);
            this.chkControleValidade = new IWTDotNetLib.IWTCheckBox(this.components);
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.Imagem = new IWTDotNetLib.IWTImage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.grbRevisao = new System.Windows.Forms.GroupBox();
            this.lblRevisaoJustificativa = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisaoData = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisaoUsuario = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisaoJustificativaLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisaoDataLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisaoUsuarioLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.btnSalvarComo = new IWTDotNetLib.IWTButton(this.components);
            this.ofdImagem = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grbPrincipal.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudComprimento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLargura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMatMedida)).BeginInit();
            this.grbCompras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLotePadrao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMargemRecebimento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLeadtimeCompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudConversaoUnidades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLoteMinimo)).BeginInit();
            this.grbPoliticaEstoque.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudVerde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmarelo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVermelho)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.grbUnidadeCompraFornecedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFornecedorLotePadrao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFornecedorUnidadesPorUnidadeCompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFornecedorLoteMinimo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIPINaoIncluso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImcsIncluso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUltimoPreco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudControleValidadeMeses)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.grbRevisao.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.btnSalvarComo);
            this.splitContainer1.Size = new System.Drawing.Size(799, 732);
            this.splitContainer1.SplitterDistance = 690;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(12, 8);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(712, 8);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(799, 690);
            this.tabControl1.TabIndex = 28;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lnkConfiguracoes);
            this.tabPage1.Controls.Add(this.grbPrincipal);
            this.tabPage1.Controls.Add(this.grbCompras);
            this.tabPage1.Controls.Add(this.grbPoliticaEstoque);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(791, 664);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Material";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lnkConfiguracoes
            // 
            this.lnkConfiguracoes.AutoSize = true;
            this.lnkConfiguracoes.BindingField = null;
            this.lnkConfiguracoes.LiberadoQuandoCadastroUtilizado = false;
            this.lnkConfiguracoes.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lnkConfiguracoes.Location = new System.Drawing.Point(683, 644);
            this.lnkConfiguracoes.Name = "lnkConfiguracoes";
            this.lnkConfiguracoes.Size = new System.Drawing.Size(94, 13);
            this.lnkConfiguracoes.TabIndex = 3;
            this.lnkConfiguracoes.TabStop = true;
            this.lnkConfiguracoes.Text = "Ver Configurações";
            this.lnkConfiguracoes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkConfiguracoes_LinkClicked);
            // 
            // grbPrincipal
            // 
            this.grbPrincipal.Controls.Add(this.iwtTextBox1);
            this.grbPrincipal.Controls.Add(this.iwtLabel1);
            this.grbPrincipal.Controls.Add(this.groupBox1);
            this.grbPrincipal.Controls.Add(this.txtMatMarcasHomologadas);
            this.grbPrincipal.Controls.Add(this.label6);
            this.grbPrincipal.Controls.Add(this.label21);
            this.grbPrincipal.Controls.Add(this.nudComprimento);
            this.grbPrincipal.Controls.Add(this.nudLargura);
            this.grbPrincipal.Controls.Add(this.label8);
            this.grbPrincipal.Controls.Add(this.txtMatDescricaoComplementar);
            this.grbPrincipal.Controls.Add(this.label5);
            this.grbPrincipal.Controls.Add(this.label1);
            this.grbPrincipal.Controls.Add(this.Acabamento);
            this.grbPrincipal.Controls.Add(this.label10);
            this.grbPrincipal.Controls.Add(this.UnidadeMedida);
            this.grbPrincipal.Controls.Add(this.txtMatDescricao);
            this.grbPrincipal.Controls.Add(this.nudMatMedida);
            this.grbPrincipal.Controls.Add(this.label2);
            this.grbPrincipal.Controls.Add(this.label3);
            this.grbPrincipal.Location = new System.Drawing.Point(13, 2);
            this.grbPrincipal.Name = "grbPrincipal";
            this.grbPrincipal.Size = new System.Drawing.Size(764, 223);
            this.grbPrincipal.TabIndex = 0;
            this.grbPrincipal.TabStop = false;
            this.grbPrincipal.Text = "Dados";
            // 
            // iwtTextBox1
            // 
            this.iwtTextBox1.BindingField = "Gtin";
            this.iwtTextBox1.DebugMode = false;
            this.iwtTextBox1.LiberadoQuandoCadastroUtilizado = true;
            this.iwtTextBox1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox1.Location = new System.Drawing.Point(549, 197);
            this.iwtTextBox1.MaxLength = 14;
            this.iwtTextBox1.ModoBarcode = false;
            this.iwtTextBox1.ModoBusca = false;
            this.iwtTextBox1.Name = "iwtTextBox1";
            this.iwtTextBox1.NaoLimparDepoisBarcode = false;
            this.iwtTextBox1.Size = new System.Drawing.Size(209, 20);
            this.iwtTextBox1.TabIndex = 11;
            this.toolTip1.SetToolTip(this.iwtTextBox1, "Preencher com o código GTIN-8, GTIN-12, GTIN-13 ou GTIN-14 (antigos código EAN, U" +
        "PC, DUN-14), não informar caso o material não possua esse código.");
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(510, 200);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(33, 13);
            this.iwtLabel1.TabIndex = 173;
            this.iwtLabel1.Text = "GTIN";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.FamiliaMaterial);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Location = new System.Drawing.Point(29, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(729, 64);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Código do Material";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(11, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(37, 20);
            this.panel1.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BindingField = null;
            this.label4.LiberadoQuandoCadastroUtilizado = false;
            this.label4.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label4.Location = new System.Drawing.Point(464, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Identificacação";
            // 
            // FamiliaMaterial
            // 
            this.FamiliaMaterial.BindingField = "FamiliaMaterial";
            this.FamiliaMaterial.ColumnsToDisplay = null;
            this.FamiliaMaterial.DisableAutoSelectOnEmpty = false;
            this.FamiliaMaterial.DropDownHeight = 1;
            this.FamiliaMaterial.FormattingEnabled = true;
            this.FamiliaMaterial.IntegralHeight = false;
            this.FamiliaMaterial.LiberadoQuandoCadastroUtilizado = false;
            this.FamiliaMaterial.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.FamiliaMaterial.Location = new System.Drawing.Point(61, 32);
            this.FamiliaMaterial.Name = "FamiliaMaterial";
            this.FamiliaMaterial.SelectedRow = null;
            this.FamiliaMaterial.Size = new System.Drawing.Size(400, 21);
            this.FamiliaMaterial.TabIndex = 0;
            this.FamiliaMaterial.Table = null;
            this.FamiliaMaterial.SelectedIndexChanged += new System.EventHandler(this.cmbFamiliaMaterial_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BindingField = null;
            this.label7.LiberadoQuandoCadastroUtilizado = false;
            this.label7.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label7.Location = new System.Drawing.Point(58, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Familia";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BindingField = "Codigo";
            this.txtCodigo.DebugMode = false;
            this.txtCodigo.LiberadoQuandoCadastroUtilizado = false;
            this.txtCodigo.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtCodigo.Location = new System.Drawing.Point(467, 33);
            this.txtCodigo.MaxLength = 22;
            this.txtCodigo.ModoBarcode = false;
            this.txtCodigo.ModoBusca = false;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.NaoLimparDepoisBarcode = false;
            this.txtCodigo.Size = new System.Drawing.Size(256, 20);
            this.txtCodigo.TabIndex = 1;
            // 
            // txtMatMarcasHomologadas
            // 
            this.txtMatMarcasHomologadas.BindingField = "MarcasHomologadas";
            this.txtMatMarcasHomologadas.DebugMode = false;
            this.txtMatMarcasHomologadas.LiberadoQuandoCadastroUtilizado = true;
            this.txtMatMarcasHomologadas.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtMatMarcasHomologadas.Location = new System.Drawing.Point(143, 198);
            this.txtMatMarcasHomologadas.MaxLength = 255;
            this.txtMatMarcasHomologadas.ModoBarcode = false;
            this.txtMatMarcasHomologadas.ModoBusca = false;
            this.txtMatMarcasHomologadas.Name = "txtMatMarcasHomologadas";
            this.txtMatMarcasHomologadas.NaoLimparDepoisBarcode = false;
            this.txtMatMarcasHomologadas.Size = new System.Drawing.Size(347, 20);
            this.txtMatMarcasHomologadas.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BindingField = null;
            this.label6.LiberadoQuandoCadastroUtilizado = false;
            this.label6.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label6.Location = new System.Drawing.Point(577, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Dimensão 3";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BindingField = null;
            this.label21.LiberadoQuandoCadastroUtilizado = false;
            this.label21.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label21.Location = new System.Drawing.Point(26, 201);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(110, 13);
            this.label21.TabIndex = 30;
            this.label21.Text = "Marcas Homologadas";
            // 
            // nudComprimento
            // 
            this.nudComprimento.BindingField = "MedidaComprimento";
            this.nudComprimento.DecimalPlaces = 2;
            this.nudComprimento.LiberadoQuandoCadastroUtilizado = false;
            this.nudComprimento.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudComprimento.Location = new System.Drawing.Point(646, 93);
            this.nudComprimento.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudComprimento.Name = "nudComprimento";
            this.nudComprimento.Size = new System.Drawing.Size(112, 20);
            this.nudComprimento.TabIndex = 3;
            // 
            // nudLargura
            // 
            this.nudLargura.BindingField = "MedidaLargura";
            this.nudLargura.DecimalPlaces = 2;
            this.nudLargura.LiberadoQuandoCadastroUtilizado = false;
            this.nudLargura.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudLargura.Location = new System.Drawing.Point(405, 93);
            this.nudLargura.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudLargura.Name = "nudLargura";
            this.nudLargura.Size = new System.Drawing.Size(112, 20);
            this.nudLargura.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BindingField = null;
            this.label8.LiberadoQuandoCadastroUtilizado = false;
            this.label8.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label8.Location = new System.Drawing.Point(73, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Acabamento";
            // 
            // txtMatDescricaoComplementar
            // 
            this.txtMatDescricaoComplementar.BindingField = "DescricaoAdicional";
            this.txtMatDescricaoComplementar.DebugMode = false;
            this.txtMatDescricaoComplementar.LiberadoQuandoCadastroUtilizado = true;
            this.txtMatDescricaoComplementar.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtMatDescricaoComplementar.Location = new System.Drawing.Point(143, 172);
            this.txtMatDescricaoComplementar.MaxLength = 255;
            this.txtMatDescricaoComplementar.ModoBarcode = false;
            this.txtMatDescricaoComplementar.ModoBusca = false;
            this.txtMatDescricaoComplementar.Name = "txtMatDescricaoComplementar";
            this.txtMatDescricaoComplementar.NaoLimparDepoisBarcode = false;
            this.txtMatDescricaoComplementar.Size = new System.Drawing.Size(615, 20);
            this.txtMatDescricaoComplementar.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BindingField = null;
            this.label5.LiberadoQuandoCadastroUtilizado = false;
            this.label5.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label5.Location = new System.Drawing.Point(336, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Dimensão 2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BindingField = null;
            this.label1.LiberadoQuandoCadastroUtilizado = false;
            this.label1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label1.Location = new System.Drawing.Point(82, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descrição";
            // 
            // Acabamento
            // 
            this.Acabamento.BindingField = "Acabamento";
            this.Acabamento.ColumnsToDisplay = null;
            this.Acabamento.DisableAutoSelectOnEmpty = false;
            this.Acabamento.DropDownHeight = 1;
            this.Acabamento.FormattingEnabled = true;
            this.Acabamento.IntegralHeight = false;
            this.Acabamento.LiberadoQuandoCadastroUtilizado = false;
            this.Acabamento.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Acabamento.Location = new System.Drawing.Point(143, 119);
            this.Acabamento.Name = "Acabamento";
            this.Acabamento.SelectedRow = null;
            this.Acabamento.Size = new System.Drawing.Size(255, 21);
            this.Acabamento.TabIndex = 4;
            this.Acabamento.Table = null;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BindingField = null;
            this.label10.LiberadoQuandoCadastroUtilizado = false;
            this.label10.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label10.Location = new System.Drawing.Point(13, 175);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(124, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Descrição complementar";
            // 
            // UnidadeMedida
            // 
            this.UnidadeMedida.BindingField = "UnidadeMedida";
            this.UnidadeMedida.ColumnsToDisplay = null;
            this.UnidadeMedida.DisableAutoSelectOnEmpty = false;
            this.UnidadeMedida.DropDownHeight = 1;
            this.UnidadeMedida.FormattingEnabled = true;
            this.UnidadeMedida.IntegralHeight = false;
            this.UnidadeMedida.LiberadoQuandoCadastroUtilizado = false;
            this.UnidadeMedida.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.UnidadeMedida.Location = new System.Drawing.Point(549, 119);
            this.UnidadeMedida.Name = "UnidadeMedida";
            this.UnidadeMedida.SelectedRow = null;
            this.UnidadeMedida.Size = new System.Drawing.Size(209, 21);
            this.UnidadeMedida.TabIndex = 5;
            this.UnidadeMedida.Table = null;
            this.UnidadeMedida.SelectedIndexChanged += new System.EventHandler(this.cmbUnidade_SelectedIndexChanged);
            // 
            // txtMatDescricao
            // 
            this.txtMatDescricao.BindingField = "Descricao";
            this.txtMatDescricao.DebugMode = false;
            this.txtMatDescricao.LiberadoQuandoCadastroUtilizado = true;
            this.txtMatDescricao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtMatDescricao.Location = new System.Drawing.Point(143, 146);
            this.txtMatDescricao.MaxLength = 50;
            this.txtMatDescricao.ModoBarcode = false;
            this.txtMatDescricao.ModoBusca = false;
            this.txtMatDescricao.Name = "txtMatDescricao";
            this.txtMatDescricao.NaoLimparDepoisBarcode = false;
            this.txtMatDescricao.Size = new System.Drawing.Size(615, 20);
            this.txtMatDescricao.TabIndex = 8;
            // 
            // nudMatMedida
            // 
            this.nudMatMedida.BindingField = "Medida";
            this.nudMatMedida.DecimalPlaces = 2;
            this.nudMatMedida.LiberadoQuandoCadastroUtilizado = false;
            this.nudMatMedida.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudMatMedida.Location = new System.Drawing.Point(143, 93);
            this.nudMatMedida.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudMatMedida.Name = "nudMatMedida";
            this.nudMatMedida.Size = new System.Drawing.Size(111, 20);
            this.nudMatMedida.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BindingField = null;
            this.label2.LiberadoQuandoCadastroUtilizado = false;
            this.label2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label2.Location = new System.Drawing.Point(432, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Unidade de Utilização";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BindingField = null;
            this.label3.LiberadoQuandoCadastroUtilizado = false;
            this.label3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label3.Location = new System.Drawing.Point(74, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Dimensão 1";
            // 
            // grbCompras
            // 
            this.grbCompras.Controls.Add(this.nudLotePadrao);
            this.grbCompras.Controls.Add(this.iwtLabel2);
            this.grbCompras.Controls.Add(this.lblSugestaoLeadTime);
            this.grbCompras.Controls.Add(this.nudMargemRecebimento);
            this.grbCompras.Controls.Add(this.label37);
            this.grbCompras.Controls.Add(this.chkMargemRecebimento);
            this.grbCompras.Controls.Add(this.chkComprador);
            this.grbCompras.Controls.Add(this.Comprador);
            this.grbCompras.Controls.Add(this.label31);
            this.grbCompras.Controls.Add(this.lblLeadtimeCompras);
            this.grbCompras.Controls.Add(this.lblLeadtimePCP);
            this.grbCompras.Controls.Add(this.nudLeadtimeCompra);
            this.grbCompras.Controls.Add(this.label20);
            this.grbCompras.Controls.Add(this.chkUnidadeCompra);
            this.grbCompras.Controls.Add(this.lblUnidades);
            this.grbCompras.Controls.Add(this.nudConversaoUnidades);
            this.grbCompras.Controls.Add(this.label16);
            this.grbCompras.Controls.Add(this.label15);
            this.grbCompras.Controls.Add(this.UnidadeMedidaCompra);
            this.grbCompras.Controls.Add(this.nudLoteMinimo);
            this.grbCompras.Controls.Add(this.label14);
            this.grbCompras.Location = new System.Drawing.Point(13, 226);
            this.grbCompras.Name = "grbCompras";
            this.grbCompras.Size = new System.Drawing.Size(764, 203);
            this.grbCompras.TabIndex = 0;
            this.grbCompras.TabStop = false;
            this.grbCompras.Text = "Compras";
            // 
            // nudLotePadrao
            // 
            this.nudLotePadrao.BindingField = "LotePadrao";
            this.nudLotePadrao.DecimalPlaces = 4;
            this.nudLotePadrao.LiberadoQuandoCadastroUtilizado = true;
            this.nudLotePadrao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudLotePadrao.Location = new System.Drawing.Point(314, 98);
            this.nudLotePadrao.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudLotePadrao.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.nudLotePadrao.Name = "nudLotePadrao";
            this.nudLotePadrao.Size = new System.Drawing.Size(140, 20);
            this.nudLotePadrao.TabIndex = 4;
            this.nudLotePadrao.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // iwtLabel2
            // 
            this.iwtLabel2.AutoSize = true;
            this.iwtLabel2.BindingField = null;
            this.iwtLabel2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel2.Location = new System.Drawing.Point(46, 100);
            this.iwtLabel2.Name = "iwtLabel2";
            this.iwtLabel2.Size = new System.Drawing.Size(263, 13);
            this.iwtLabel2.TabIndex = 51;
            this.iwtLabel2.Text = "Lote Padrão de Fornecimento em unidades de compra";
            // 
            // lblSugestaoLeadTime
            // 
            this.lblSugestaoLeadTime.BindingField = null;
            this.lblSugestaoLeadTime.LiberadoQuandoCadastroUtilizado = false;
            this.lblSugestaoLeadTime.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblSugestaoLeadTime.Location = new System.Drawing.Point(496, 110);
            this.lblSugestaoLeadTime.Name = "lblSugestaoLeadTime";
            this.lblSugestaoLeadTime.Size = new System.Drawing.Size(262, 22);
            this.lblSugestaoLeadTime.TabIndex = 49;
            this.lblSugestaoLeadTime.Text = "Leadtime Aquisição Calculado";
            // 
            // nudMargemRecebimento
            // 
            this.nudMargemRecebimento.BindingField = "MargemRecebimento";
            this.nudMargemRecebimento.DecimalPlaces = 2;
            this.nudMargemRecebimento.Enabled = false;
            this.nudMargemRecebimento.LiberadoQuandoCadastroUtilizado = true;
            this.nudMargemRecebimento.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudMargemRecebimento.Location = new System.Drawing.Point(314, 176);
            this.nudMargemRecebimento.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudMargemRecebimento.Name = "nudMargemRecebimento";
            this.nudMargemRecebimento.Size = new System.Drawing.Size(140, 20);
            this.nudMargemRecebimento.TabIndex = 8;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.BindingField = null;
            this.label37.LiberadoQuandoCadastroUtilizado = false;
            this.label37.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label37.Location = new System.Drawing.Point(117, 178);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(191, 13);
            this.label37.TabIndex = 48;
            this.label37.Text = "Margem de Aceite de Recebimento (%)";
            // 
            // chkMargemRecebimento
            // 
            this.chkMargemRecebimento.AutoSize = true;
            this.chkMargemRecebimento.BindingField = "PossuiMargemRecebimento";
            this.chkMargemRecebimento.LiberadoQuandoCadastroUtilizado = true;
            this.chkMargemRecebimento.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkMargemRecebimento.Location = new System.Drawing.Point(460, 178);
            this.chkMargemRecebimento.Name = "chkMargemRecebimento";
            this.chkMargemRecebimento.Size = new System.Drawing.Size(15, 14);
            this.chkMargemRecebimento.TabIndex = 9;
            this.chkMargemRecebimento.UseVisualStyleBackColor = true;
            this.chkMargemRecebimento.CheckedChanged += new System.EventHandler(this.chkMargemRecebimento_CheckedChanged);
            // 
            // chkComprador
            // 
            this.chkComprador.AutoSize = true;
            this.chkComprador.BindingField = "PossuiComprador";
            this.chkComprador.LiberadoQuandoCadastroUtilizado = true;
            this.chkComprador.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkComprador.Location = new System.Drawing.Point(460, 152);
            this.chkComprador.Name = "chkComprador";
            this.chkComprador.Size = new System.Drawing.Size(15, 14);
            this.chkComprador.TabIndex = 7;
            this.chkComprador.UseVisualStyleBackColor = true;
            this.chkComprador.CheckedChanged += new System.EventHandler(this.chkComprador_CheckedChanged);
            // 
            // Comprador
            // 
            this.Comprador.BindingField = "Comprador";
            this.Comprador.ColumnsToDisplay = null;
            this.Comprador.DisableAutoSelectOnEmpty = false;
            this.Comprador.DropDownHeight = 1;
            this.Comprador.Enabled = false;
            this.Comprador.FormattingEnabled = true;
            this.Comprador.IntegralHeight = false;
            this.Comprador.LiberadoQuandoCadastroUtilizado = true;
            this.Comprador.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Comprador.Location = new System.Drawing.Point(111, 149);
            this.Comprador.Name = "Comprador";
            this.Comprador.SelectedRow = null;
            this.Comprador.Size = new System.Drawing.Size(343, 21);
            this.Comprador.TabIndex = 6;
            this.Comprador.Table = null;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.BindingField = null;
            this.label31.LiberadoQuandoCadastroUtilizado = false;
            this.label31.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label31.Location = new System.Drawing.Point(47, 152);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(58, 13);
            this.label31.TabIndex = 45;
            this.label31.Text = "Comprador";
            // 
            // lblLeadtimeCompras
            // 
            this.lblLeadtimeCompras.BindingField = null;
            this.lblLeadtimeCompras.LiberadoQuandoCadastroUtilizado = false;
            this.lblLeadtimeCompras.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblLeadtimeCompras.Location = new System.Drawing.Point(496, 88);
            this.lblLeadtimeCompras.Name = "lblLeadtimeCompras";
            this.lblLeadtimeCompras.Size = new System.Drawing.Size(262, 22);
            this.lblLeadtimeCompras.TabIndex = 42;
            // 
            // lblLeadtimePCP
            // 
            this.lblLeadtimePCP.BindingField = null;
            this.lblLeadtimePCP.LiberadoQuandoCadastroUtilizado = false;
            this.lblLeadtimePCP.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblLeadtimePCP.Location = new System.Drawing.Point(496, 66);
            this.lblLeadtimePCP.Name = "lblLeadtimePCP";
            this.lblLeadtimePCP.Size = new System.Drawing.Size(262, 22);
            this.lblLeadtimePCP.TabIndex = 41;
            // 
            // nudLeadtimeCompra
            // 
            this.nudLeadtimeCompra.BindingField = "LeadTimeCompra";
            this.nudLeadtimeCompra.LiberadoQuandoCadastroUtilizado = true;
            this.nudLeadtimeCompra.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudLeadtimeCompra.Location = new System.Drawing.Point(314, 124);
            this.nudLeadtimeCompra.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudLeadtimeCompra.Name = "nudLeadtimeCompra";
            this.nudLeadtimeCompra.Size = new System.Drawing.Size(140, 20);
            this.nudLeadtimeCompra.TabIndex = 5;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BindingField = null;
            this.label20.LiberadoQuandoCadastroUtilizado = false;
            this.label20.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label20.Location = new System.Drawing.Point(166, 126);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(142, 13);
            this.label20.TabIndex = 39;
            this.label20.Text = "Leadtime de Aquisição (dias)";
            // 
            // chkUnidadeCompra
            // 
            this.chkUnidadeCompra.AutoSize = true;
            this.chkUnidadeCompra.BindingField = "UnidadeCompraSelecionada";
            this.chkUnidadeCompra.Checked = true;
            this.chkUnidadeCompra.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUnidadeCompra.LiberadoQuandoCadastroUtilizado = false;
            this.chkUnidadeCompra.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkUnidadeCompra.Location = new System.Drawing.Point(460, 22);
            this.chkUnidadeCompra.Name = "chkUnidadeCompra";
            this.chkUnidadeCompra.Size = new System.Drawing.Size(15, 14);
            this.chkUnidadeCompra.TabIndex = 0;
            this.chkUnidadeCompra.UseVisualStyleBackColor = true;
            this.chkUnidadeCompra.CheckedChanged += new System.EventHandler(this.chkUnidadeCompra_CheckedChanged);
            // 
            // lblUnidades
            // 
            this.lblUnidades.BindingField = null;
            this.lblUnidades.LiberadoQuandoCadastroUtilizado = false;
            this.lblUnidades.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblUnidades.Location = new System.Drawing.Point(472, 41);
            this.lblUnidades.Name = "lblUnidades";
            this.lblUnidades.Size = new System.Drawing.Size(286, 25);
            this.lblUnidades.TabIndex = 11;
            // 
            // nudConversaoUnidades
            // 
            this.nudConversaoUnidades.BindingField = "UnidadesPorUnCompra";
            this.nudConversaoUnidades.DecimalPlaces = 4;
            this.nudConversaoUnidades.LiberadoQuandoCadastroUtilizado = false;
            this.nudConversaoUnidades.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudConversaoUnidades.Location = new System.Drawing.Point(314, 46);
            this.nudConversaoUnidades.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudConversaoUnidades.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.nudConversaoUnidades.Name = "nudConversaoUnidades";
            this.nudConversaoUnidades.Size = new System.Drawing.Size(140, 20);
            this.nudConversaoUnidades.TabIndex = 2;
            this.nudConversaoUnidades.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudConversaoUnidades.ValueChanged += new System.EventHandler(this.nudConversaoUnidades_ValueChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BindingField = null;
            this.label16.LiberadoQuandoCadastroUtilizado = false;
            this.label16.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label16.Location = new System.Drawing.Point(4, 48);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(304, 13);
            this.label16.TabIndex = 9;
            this.label16.Text = "Quantidade de Unidades de Utilização por Unidade de Compra";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BindingField = null;
            this.label15.LiberadoQuandoCadastroUtilizado = false;
            this.label15.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label15.Location = new System.Drawing.Point(4, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(101, 13);
            this.label15.TabIndex = 7;
            this.label15.Text = "Unidade de Compra";
            // 
            // UnidadeMedidaCompra
            // 
            this.UnidadeMedidaCompra.BindingField = "UnidadeMedidaCompra";
            this.UnidadeMedidaCompra.ColumnsToDisplay = null;
            this.UnidadeMedidaCompra.DisableAutoSelectOnEmpty = false;
            this.UnidadeMedidaCompra.DropDownHeight = 1;
            this.UnidadeMedidaCompra.FormattingEnabled = true;
            this.UnidadeMedidaCompra.IntegralHeight = false;
            this.UnidadeMedidaCompra.LiberadoQuandoCadastroUtilizado = false;
            this.UnidadeMedidaCompra.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.UnidadeMedidaCompra.Location = new System.Drawing.Point(111, 19);
            this.UnidadeMedidaCompra.Name = "UnidadeMedidaCompra";
            this.UnidadeMedidaCompra.SelectedRow = null;
            this.UnidadeMedidaCompra.Size = new System.Drawing.Size(343, 21);
            this.UnidadeMedidaCompra.TabIndex = 1;
            this.UnidadeMedidaCompra.Table = null;
            this.UnidadeMedidaCompra.SelectedIndexChanged += new System.EventHandler(this.cmbUnidadeCompra_SelectedIndexChanged);
            // 
            // nudLoteMinimo
            // 
            this.nudLoteMinimo.BindingField = "LoteMinimo";
            this.nudLoteMinimo.DecimalPlaces = 4;
            this.nudLoteMinimo.LiberadoQuandoCadastroUtilizado = true;
            this.nudLoteMinimo.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudLoteMinimo.Location = new System.Drawing.Point(314, 72);
            this.nudLoteMinimo.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudLoteMinimo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.nudLoteMinimo.Name = "nudLoteMinimo";
            this.nudLoteMinimo.Size = new System.Drawing.Size(140, 20);
            this.nudLoteMinimo.TabIndex = 3;
            this.nudLoteMinimo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BindingField = null;
            this.label14.LiberadoQuandoCadastroUtilizado = false;
            this.label14.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label14.Location = new System.Drawing.Point(46, 74);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(262, 13);
            this.label14.TabIndex = 35;
            this.label14.Text = "Lote Minimo de Fornecimento em unidades de compra";
            // 
            // grbPoliticaEstoque
            // 
            this.grbPoliticaEstoque.Controls.Add(this.chkImpedirSolicitacaoAutomatica);
            this.grbPoliticaEstoque.Controls.Add(this.lblSugeridoAcimaCompras);
            this.grbPoliticaEstoque.Controls.Add(this.lblDisparo);
            this.grbPoliticaEstoque.Controls.Add(this.label23);
            this.grbPoliticaEstoque.Controls.Add(this.label22);
            this.grbPoliticaEstoque.Controls.Add(this.groupBox5);
            this.grbPoliticaEstoque.Controls.Add(this.groupBox4);
            this.grbPoliticaEstoque.Controls.Add(this.groupBox3);
            this.grbPoliticaEstoque.Controls.Add(this.rdbNaoAplicavel);
            this.grbPoliticaEstoque.Controls.Add(this.rdbProducaoRepetitiva);
            this.grbPoliticaEstoque.Controls.Add(this.rdbMRP);
            this.grbPoliticaEstoque.Location = new System.Drawing.Point(19, 435);
            this.grbPoliticaEstoque.Name = "grbPoliticaEstoque";
            this.grbPoliticaEstoque.Size = new System.Drawing.Size(764, 205);
            this.grbPoliticaEstoque.TabIndex = 1;
            this.grbPoliticaEstoque.TabStop = false;
            this.grbPoliticaEstoque.Text = "Politica de Estoque";
            // 
            // chkImpedirSolicitacaoAutomatica
            // 
            this.chkImpedirSolicitacaoAutomatica.AutoSize = true;
            this.chkImpedirSolicitacaoAutomatica.BindingField = "ImpedirSolicitacaoAuto";
            this.chkImpedirSolicitacaoAutomatica.LiberadoQuandoCadastroUtilizado = true;
            this.chkImpedirSolicitacaoAutomatica.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkImpedirSolicitacaoAutomatica.Location = new System.Drawing.Point(11, 155);
            this.chkImpedirSolicitacaoAutomatica.Name = "chkImpedirSolicitacaoAutomatica";
            this.chkImpedirSolicitacaoAutomatica.Size = new System.Drawing.Size(284, 17);
            this.chkImpedirSolicitacaoAutomatica.TabIndex = 6;
            this.chkImpedirSolicitacaoAutomatica.Text = "Impedir Geração Automática de Solicitação de Compra";
            this.chkImpedirSolicitacaoAutomatica.UseVisualStyleBackColor = true;
            // 
            // lblSugeridoAcimaCompras
            // 
            this.lblSugeridoAcimaCompras.AutoSize = true;
            this.lblSugeridoAcimaCompras.BindingField = null;
            this.lblSugeridoAcimaCompras.LiberadoQuandoCadastroUtilizado = false;
            this.lblSugeridoAcimaCompras.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblSugeridoAcimaCompras.Location = new System.Drawing.Point(657, 180);
            this.lblSugeridoAcimaCompras.Name = "lblSugeridoAcimaCompras";
            this.lblSugeridoAcimaCompras.Size = new System.Drawing.Size(0, 13);
            this.lblSugeridoAcimaCompras.TabIndex = 9;
            // 
            // lblDisparo
            // 
            this.lblDisparo.AutoSize = true;
            this.lblDisparo.BindingField = null;
            this.lblDisparo.LiberadoQuandoCadastroUtilizado = false;
            this.lblDisparo.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblDisparo.Location = new System.Drawing.Point(657, 155);
            this.lblDisparo.Name = "lblDisparo";
            this.lblDisparo.Size = new System.Drawing.Size(0, 13);
            this.lblDisparo.TabIndex = 8;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BindingField = null;
            this.label23.LiberadoQuandoCadastroUtilizado = false;
            this.label23.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label23.Location = new System.Drawing.Point(402, 180);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(249, 13);
            this.label23.TabIndex = 10;
            this.label23.Text = "% Sugerido de compras acima do valor configurado";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BindingField = null;
            this.label22.LiberadoQuandoCadastroUtilizado = false;
            this.label22.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label22.Location = new System.Drawing.Point(469, 155);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(182, 13);
            this.label22.TabIndex = 7;
            this.label22.Text = "Disparo da Solicitação de compras %";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblFaixaC);
            this.groupBox5.Controls.Add(this.lblFaixaB);
            this.groupBox5.Controls.Add(this.lblFaixaA);
            this.groupBox5.Controls.Add(this.lblClassificacaoABC);
            this.groupBox5.Location = new System.Drawing.Point(443, 42);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(244, 100);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Classificação";
            // 
            // lblFaixaC
            // 
            this.lblFaixaC.AutoSize = true;
            this.lblFaixaC.BindingField = null;
            this.lblFaixaC.LiberadoQuandoCadastroUtilizado = false;
            this.lblFaixaC.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblFaixaC.Location = new System.Drawing.Point(121, 67);
            this.lblFaixaC.Name = "lblFaixaC";
            this.lblFaixaC.Size = new System.Drawing.Size(0, 13);
            this.lblFaixaC.TabIndex = 46;
            // 
            // lblFaixaB
            // 
            this.lblFaixaB.AutoSize = true;
            this.lblFaixaB.BindingField = null;
            this.lblFaixaB.LiberadoQuandoCadastroUtilizado = false;
            this.lblFaixaB.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblFaixaB.Location = new System.Drawing.Point(121, 44);
            this.lblFaixaB.Name = "lblFaixaB";
            this.lblFaixaB.Size = new System.Drawing.Size(0, 13);
            this.lblFaixaB.TabIndex = 45;
            // 
            // lblFaixaA
            // 
            this.lblFaixaA.AutoSize = true;
            this.lblFaixaA.BindingField = null;
            this.lblFaixaA.LiberadoQuandoCadastroUtilizado = false;
            this.lblFaixaA.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblFaixaA.Location = new System.Drawing.Point(121, 21);
            this.lblFaixaA.Name = "lblFaixaA";
            this.lblFaixaA.Size = new System.Drawing.Size(0, 13);
            this.lblFaixaA.TabIndex = 44;
            // 
            // lblClassificacaoABC
            // 
            this.lblClassificacaoABC.AutoSize = true;
            this.lblClassificacaoABC.BindingField = null;
            this.lblClassificacaoABC.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassificacaoABC.LiberadoQuandoCadastroUtilizado = false;
            this.lblClassificacaoABC.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblClassificacaoABC.Location = new System.Drawing.Point(18, 19);
            this.lblClassificacaoABC.Name = "lblClassificacaoABC";
            this.lblClassificacaoABC.Size = new System.Drawing.Size(67, 63);
            this.lblClassificacaoABC.TabIndex = 43;
            this.lblClassificacaoABC.Text = "C";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.nudVerde);
            this.groupBox4.Controls.Add(this.lblReverVermelho);
            this.groupBox4.Controls.Add(this.nudAmarelo);
            this.groupBox4.Controls.Add(this.lblReverAmarelo);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.lblReverVerde);
            this.groupBox4.Controls.Add(this.nudVermelho);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Location = new System.Drawing.Point(184, 42);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(253, 100);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Estoques de Segurança Configurados";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BindingField = null;
            this.label13.LiberadoQuandoCadastroUtilizado = false;
            this.label13.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label13.Location = new System.Drawing.Point(6, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 37;
            this.label13.Text = "Verde";
            // 
            // nudVerde
            // 
            this.nudVerde.BindingField = "Verde";
            this.nudVerde.Enabled = false;
            this.nudVerde.LiberadoQuandoCadastroUtilizado = true;
            this.nudVerde.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudVerde.Location = new System.Drawing.Point(63, 17);
            this.nudVerde.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudVerde.Name = "nudVerde";
            this.nudVerde.Size = new System.Drawing.Size(93, 20);
            this.nudVerde.TabIndex = 0;
            this.nudVerde.ValueChanged += new System.EventHandler(this.nudVerde_ValueChanged);
            // 
            // lblReverVermelho
            // 
            this.lblReverVermelho.AutoSize = true;
            this.lblReverVermelho.BindingField = null;
            this.lblReverVermelho.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReverVermelho.ForeColor = System.Drawing.Color.Red;
            this.lblReverVermelho.LiberadoQuandoCadastroUtilizado = false;
            this.lblReverVermelho.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblReverVermelho.Location = new System.Drawing.Point(162, 71);
            this.lblReverVermelho.Name = "lblReverVermelho";
            this.lblReverVermelho.Size = new System.Drawing.Size(0, 13);
            this.lblReverVermelho.TabIndex = 47;
            // 
            // nudAmarelo
            // 
            this.nudAmarelo.BindingField = "Amarelo";
            this.nudAmarelo.Enabled = false;
            this.nudAmarelo.LiberadoQuandoCadastroUtilizado = true;
            this.nudAmarelo.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudAmarelo.Location = new System.Drawing.Point(63, 43);
            this.nudAmarelo.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudAmarelo.Name = "nudAmarelo";
            this.nudAmarelo.Size = new System.Drawing.Size(93, 20);
            this.nudAmarelo.TabIndex = 1;
            this.nudAmarelo.ValueChanged += new System.EventHandler(this.nudAmarelo_ValueChanged);
            // 
            // lblReverAmarelo
            // 
            this.lblReverAmarelo.AutoSize = true;
            this.lblReverAmarelo.BindingField = null;
            this.lblReverAmarelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReverAmarelo.ForeColor = System.Drawing.Color.Red;
            this.lblReverAmarelo.LiberadoQuandoCadastroUtilizado = false;
            this.lblReverAmarelo.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblReverAmarelo.Location = new System.Drawing.Point(162, 45);
            this.lblReverAmarelo.Name = "lblReverAmarelo";
            this.lblReverAmarelo.Size = new System.Drawing.Size(0, 13);
            this.lblReverAmarelo.TabIndex = 46;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BindingField = null;
            this.label12.LiberadoQuandoCadastroUtilizado = false;
            this.label12.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label12.Location = new System.Drawing.Point(6, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 13);
            this.label12.TabIndex = 39;
            this.label12.Text = "Amarelo";
            // 
            // lblReverVerde
            // 
            this.lblReverVerde.AutoSize = true;
            this.lblReverVerde.BindingField = null;
            this.lblReverVerde.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReverVerde.ForeColor = System.Drawing.Color.Red;
            this.lblReverVerde.LiberadoQuandoCadastroUtilizado = false;
            this.lblReverVerde.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblReverVerde.Location = new System.Drawing.Point(162, 19);
            this.lblReverVerde.Name = "lblReverVerde";
            this.lblReverVerde.Size = new System.Drawing.Size(0, 13);
            this.lblReverVerde.TabIndex = 45;
            // 
            // nudVermelho
            // 
            this.nudVermelho.BindingField = "Vermelho";
            this.nudVermelho.Enabled = false;
            this.nudVermelho.LiberadoQuandoCadastroUtilizado = true;
            this.nudVermelho.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudVermelho.Location = new System.Drawing.Point(63, 69);
            this.nudVermelho.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudVermelho.Name = "nudVermelho";
            this.nudVermelho.Size = new System.Drawing.Size(93, 20);
            this.nudVermelho.TabIndex = 2;
            this.nudVermelho.ValueChanged += new System.EventHandler(this.nudVermelho_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BindingField = null;
            this.label11.LiberadoQuandoCadastroUtilizado = false;
            this.label11.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label11.Location = new System.Drawing.Point(6, 71);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 41;
            this.label11.Text = "Vermelho";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.lblVermelhoSugerido);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.lblVerdeSugerido);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.lbAmareloSugerido);
            this.groupBox3.Location = new System.Drawing.Point(11, 42);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(167, 100);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Demanda Sugerida";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BindingField = null;
            this.label17.LiberadoQuandoCadastroUtilizado = false;
            this.label17.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label17.Location = new System.Drawing.Point(12, 72);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(51, 13);
            this.label17.TabIndex = 51;
            this.label17.Text = "Vermelho";
            // 
            // lblVermelhoSugerido
            // 
            this.lblVermelhoSugerido.AutoSize = true;
            this.lblVermelhoSugerido.BackColor = System.Drawing.Color.Red;
            this.lblVermelhoSugerido.BindingField = null;
            this.lblVermelhoSugerido.LiberadoQuandoCadastroUtilizado = false;
            this.lblVermelhoSugerido.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblVermelhoSugerido.Location = new System.Drawing.Point(86, 70);
            this.lblVermelhoSugerido.Name = "lblVermelhoSugerido";
            this.lblVermelhoSugerido.Size = new System.Drawing.Size(0, 13);
            this.lblVermelhoSugerido.TabIndex = 44;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BindingField = null;
            this.label18.LiberadoQuandoCadastroUtilizado = false;
            this.label18.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label18.Location = new System.Drawing.Point(12, 46);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(45, 13);
            this.label18.TabIndex = 50;
            this.label18.Text = "Amarelo";
            // 
            // lblVerdeSugerido
            // 
            this.lblVerdeSugerido.AutoSize = true;
            this.lblVerdeSugerido.BackColor = System.Drawing.Color.Lime;
            this.lblVerdeSugerido.BindingField = null;
            this.lblVerdeSugerido.LiberadoQuandoCadastroUtilizado = false;
            this.lblVerdeSugerido.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblVerdeSugerido.Location = new System.Drawing.Point(86, 20);
            this.lblVerdeSugerido.Name = "lblVerdeSugerido";
            this.lblVerdeSugerido.Size = new System.Drawing.Size(0, 13);
            this.lblVerdeSugerido.TabIndex = 42;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BindingField = null;
            this.label19.LiberadoQuandoCadastroUtilizado = false;
            this.label19.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label19.Location = new System.Drawing.Point(12, 20);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 13);
            this.label19.TabIndex = 49;
            this.label19.Text = "Verde";
            // 
            // lbAmareloSugerido
            // 
            this.lbAmareloSugerido.AutoSize = true;
            this.lbAmareloSugerido.BackColor = System.Drawing.Color.Yellow;
            this.lbAmareloSugerido.BindingField = null;
            this.lbAmareloSugerido.LiberadoQuandoCadastroUtilizado = false;
            this.lbAmareloSugerido.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lbAmareloSugerido.Location = new System.Drawing.Point(86, 44);
            this.lbAmareloSugerido.Name = "lbAmareloSugerido";
            this.lbAmareloSugerido.Size = new System.Drawing.Size(0, 13);
            this.lbAmareloSugerido.TabIndex = 43;
            // 
            // rdbNaoAplicavel
            // 
            this.rdbNaoAplicavel.AutoSize = true;
            this.rdbNaoAplicavel.BindingField = "PoliticaEstoque_NaoAplicavel";
            this.rdbNaoAplicavel.Checked = true;
            this.rdbNaoAplicavel.LiberadoQuandoCadastroUtilizado = true;
            this.rdbNaoAplicavel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbNaoAplicavel.Location = new System.Drawing.Point(150, 19);
            this.rdbNaoAplicavel.Name = "rdbNaoAplicavel";
            this.rdbNaoAplicavel.Size = new System.Drawing.Size(91, 17);
            this.rdbNaoAplicavel.TabIndex = 2;
            this.rdbNaoAplicavel.TabStop = true;
            this.rdbNaoAplicavel.Text = "Não Aplicável";
            this.rdbNaoAplicavel.UseVisualStyleBackColor = true;
            this.rdbNaoAplicavel.CheckedChanged += new System.EventHandler(this.rdbNaoAplicavel_CheckedChanged);
            // 
            // rdbProducaoRepetitiva
            // 
            this.rdbProducaoRepetitiva.AutoSize = true;
            this.rdbProducaoRepetitiva.BindingField = "PoliticaEstoque_Kanban";
            this.rdbProducaoRepetitiva.LiberadoQuandoCadastroUtilizado = true;
            this.rdbProducaoRepetitiva.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbProducaoRepetitiva.Location = new System.Drawing.Point(73, 19);
            this.rdbProducaoRepetitiva.Name = "rdbProducaoRepetitiva";
            this.rdbProducaoRepetitiva.Size = new System.Drawing.Size(62, 17);
            this.rdbProducaoRepetitiva.TabIndex = 1;
            this.rdbProducaoRepetitiva.Text = "Kanban";
            this.rdbProducaoRepetitiva.UseVisualStyleBackColor = true;
            this.rdbProducaoRepetitiva.CheckedChanged += new System.EventHandler(this.rdbProducaoRepetitiva_CheckedChanged);
            // 
            // rdbMRP
            // 
            this.rdbMRP.AutoSize = true;
            this.rdbMRP.BindingField = "PoliticaEstoque_MRP";
            this.rdbMRP.LiberadoQuandoCadastroUtilizado = true;
            this.rdbMRP.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbMRP.Location = new System.Drawing.Point(9, 19);
            this.rdbMRP.Name = "rdbMRP";
            this.rdbMRP.Size = new System.Drawing.Size(49, 17);
            this.rdbMRP.TabIndex = 0;
            this.rdbMRP.Text = "MRP";
            this.rdbMRP.UseVisualStyleBackColor = true;
            this.rdbMRP.CheckedChanged += new System.EventHandler(this.rdbMRP_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(791, 664);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Fornecedores";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.chkFornecedorPreferencial);
            this.splitContainer2.Panel1.Controls.Add(this.ensFornecedor);
            this.splitContainer2.Panel1.Controls.Add(this.chkUnidadeCompraFornecedor);
            this.splitContainer2.Panel1.Controls.Add(this.grbUnidadeCompraFornecedor);
            this.splitContainer2.Panel1.Controls.Add(this.label30);
            this.splitContainer2.Panel1.Controls.Add(this.nudIPINaoIncluso);
            this.splitContainer2.Panel1.Controls.Add(this.label28);
            this.splitContainer2.Panel1.Controls.Add(this.nudImcsIncluso);
            this.splitContainer2.Panel1.Controls.Add(this.label29);
            this.splitContainer2.Panel1.Controls.Add(this.lblFornecedorUnidadeCompra);
            this.splitContainer2.Panel1.Controls.Add(this.label27);
            this.splitContainer2.Panel1.Controls.Add(this.nudUltimoPreco);
            this.splitContainer2.Panel1.Controls.Add(this.label9);
            this.splitContainer2.Panel1.Controls.Add(this.btnRemove);
            this.splitContainer2.Panel1.Controls.Add(this.btnAdd);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer2.Size = new System.Drawing.Size(785, 658);
            this.splitContainer2.SplitterDistance = 214;
            this.splitContainer2.TabIndex = 0;
            // 
            // chkFornecedorPreferencial
            // 
            this.chkFornecedorPreferencial.AutoSize = true;
            this.chkFornecedorPreferencial.BindingField = null;
            this.chkFornecedorPreferencial.LiberadoQuandoCadastroUtilizado = false;
            this.chkFornecedorPreferencial.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkFornecedorPreferencial.Location = new System.Drawing.Point(689, 37);
            this.chkFornecedorPreferencial.Name = "chkFornecedorPreferencial";
            this.chkFornecedorPreferencial.Size = new System.Drawing.Size(82, 17);
            this.chkFornecedorPreferencial.TabIndex = 4;
            this.chkFornecedorPreferencial.Text = "Preferencial";
            this.chkFornecedorPreferencial.UseVisualStyleBackColor = true;
            // 
            // ensFornecedor
            // 
            this.ensFornecedor.BindingField = null;
            this.ensFornecedor.ColunasDropdown = null;
            this.ensFornecedor.DesabilitarAutoCompletar = false;
            this.ensFornecedor.DesabilitarChekBox = true;
            this.ensFornecedor.DesabilitarLupa = false;
            this.ensFornecedor.DesabilitarSeta = false;
            this.ensFornecedor.EntidadeSelecionada = null;
            this.ensFornecedor.FormSelecao = null;
            this.ensFornecedor.LiberadoQuandoCadastroUtilizado = false;
            this.ensFornecedor.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensFornecedor.Location = new System.Drawing.Point(111, 7);
            this.ensFornecedor.ModoVisualizacaoGrid = null;
            this.ensFornecedor.Name = "ensFornecedor";
            this.ensFornecedor.ParametroBuscaGuiada = null;
            this.ensFornecedor.ParametrosBuscaObrigatorios = null;
            this.ensFornecedor.Size = new System.Drawing.Size(584, 23);
            this.ensFornecedor.TabIndex = 0;
            // 
            // chkUnidadeCompraFornecedor
            // 
            this.chkUnidadeCompraFornecedor.AutoSize = true;
            this.chkUnidadeCompraFornecedor.BindingField = null;
            this.chkUnidadeCompraFornecedor.LiberadoQuandoCadastroUtilizado = true;
            this.chkUnidadeCompraFornecedor.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkUnidadeCompraFornecedor.Location = new System.Drawing.Point(507, 151);
            this.chkUnidadeCompraFornecedor.Name = "chkUnidadeCompraFornecedor";
            this.chkUnidadeCompraFornecedor.Size = new System.Drawing.Size(15, 14);
            this.chkUnidadeCompraFornecedor.TabIndex = 5;
            this.chkUnidadeCompraFornecedor.UseVisualStyleBackColor = true;
            this.chkUnidadeCompraFornecedor.CheckedChanged += new System.EventHandler(this.chkUnidadeCompraFornecedor_CheckedChanged);
            // 
            // grbUnidadeCompraFornecedor
            // 
            this.grbUnidadeCompraFornecedor.Controls.Add(this.iwtLabel3);
            this.grbUnidadeCompraFornecedor.Controls.Add(this.nudFornecedorLotePadrao);
            this.grbUnidadeCompraFornecedor.Controls.Add(this.cmbFornecedorUnidadeCompra);
            this.grbUnidadeCompraFornecedor.Controls.Add(this.label36);
            this.grbUnidadeCompraFornecedor.Controls.Add(this.label35);
            this.grbUnidadeCompraFornecedor.Controls.Add(this.nudFornecedorUnidadesPorUnidadeCompra);
            this.grbUnidadeCompraFornecedor.Controls.Add(this.nudFornecedorLoteMinimo);
            this.grbUnidadeCompraFornecedor.Controls.Add(this.label34);
            this.grbUnidadeCompraFornecedor.Enabled = false;
            this.grbUnidadeCompraFornecedor.Location = new System.Drawing.Point(41, 87);
            this.grbUnidadeCompraFornecedor.Name = "grbUnidadeCompraFornecedor";
            this.grbUnidadeCompraFornecedor.Size = new System.Drawing.Size(460, 124);
            this.grbUnidadeCompraFornecedor.TabIndex = 6;
            this.grbUnidadeCompraFornecedor.TabStop = false;
            this.grbUnidadeCompraFornecedor.Text = "Sobrescrever Unidade de Compra";
            // 
            // iwtLabel3
            // 
            this.iwtLabel3.AutoSize = true;
            this.iwtLabel3.BindingField = null;
            this.iwtLabel3.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel3.Location = new System.Drawing.Point(50, 100);
            this.iwtLabel3.Name = "iwtLabel3";
            this.iwtLabel3.Size = new System.Drawing.Size(263, 13);
            this.iwtLabel3.TabIndex = 44;
            this.iwtLabel3.Text = "Lote Padrão de Fornecimento em unidades de compra";
            // 
            // nudFornecedorLotePadrao
            // 
            this.nudFornecedorLotePadrao.BindingField = null;
            this.nudFornecedorLotePadrao.DecimalPlaces = 4;
            this.nudFornecedorLotePadrao.LiberadoQuandoCadastroUtilizado = true;
            this.nudFornecedorLotePadrao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudFornecedorLotePadrao.Location = new System.Drawing.Point(318, 98);
            this.nudFornecedorLotePadrao.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudFornecedorLotePadrao.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.nudFornecedorLotePadrao.Name = "nudFornecedorLotePadrao";
            this.nudFornecedorLotePadrao.Size = new System.Drawing.Size(136, 20);
            this.nudFornecedorLotePadrao.TabIndex = 43;
            this.nudFornecedorLotePadrao.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cmbFornecedorUnidadeCompra
            // 
            this.cmbFornecedorUnidadeCompra.BindingField = null;
            this.cmbFornecedorUnidadeCompra.ColumnsToDisplay = null;
            this.cmbFornecedorUnidadeCompra.DisableAutoSelectOnEmpty = false;
            this.cmbFornecedorUnidadeCompra.DropDownHeight = 1;
            this.cmbFornecedorUnidadeCompra.FormattingEnabled = true;
            this.cmbFornecedorUnidadeCompra.IntegralHeight = false;
            this.cmbFornecedorUnidadeCompra.LiberadoQuandoCadastroUtilizado = true;
            this.cmbFornecedorUnidadeCompra.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.cmbFornecedorUnidadeCompra.Location = new System.Drawing.Point(115, 19);
            this.cmbFornecedorUnidadeCompra.Name = "cmbFornecedorUnidadeCompra";
            this.cmbFornecedorUnidadeCompra.SelectedRow = null;
            this.cmbFornecedorUnidadeCompra.Size = new System.Drawing.Size(339, 21);
            this.cmbFornecedorUnidadeCompra.TabIndex = 0;
            this.cmbFornecedorUnidadeCompra.Table = null;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.BindingField = null;
            this.label36.LiberadoQuandoCadastroUtilizado = false;
            this.label36.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label36.Location = new System.Drawing.Point(8, 22);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(101, 13);
            this.label36.TabIndex = 42;
            this.label36.Text = "Unidade de Compra";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.BindingField = null;
            this.label35.LiberadoQuandoCadastroUtilizado = false;
            this.label35.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label35.Location = new System.Drawing.Point(50, 74);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(262, 13);
            this.label35.TabIndex = 41;
            this.label35.Text = "Lote Minimo de Fornecimento em unidades de compra";
            // 
            // nudFornecedorUnidadesPorUnidadeCompra
            // 
            this.nudFornecedorUnidadesPorUnidadeCompra.BindingField = null;
            this.nudFornecedorUnidadesPorUnidadeCompra.DecimalPlaces = 4;
            this.nudFornecedorUnidadesPorUnidadeCompra.LiberadoQuandoCadastroUtilizado = true;
            this.nudFornecedorUnidadesPorUnidadeCompra.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudFornecedorUnidadesPorUnidadeCompra.Location = new System.Drawing.Point(318, 46);
            this.nudFornecedorUnidadesPorUnidadeCompra.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudFornecedorUnidadesPorUnidadeCompra.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.nudFornecedorUnidadesPorUnidadeCompra.Name = "nudFornecedorUnidadesPorUnidadeCompra";
            this.nudFornecedorUnidadesPorUnidadeCompra.Size = new System.Drawing.Size(136, 20);
            this.nudFornecedorUnidadesPorUnidadeCompra.TabIndex = 1;
            this.nudFornecedorUnidadesPorUnidadeCompra.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudFornecedorLoteMinimo
            // 
            this.nudFornecedorLoteMinimo.BindingField = null;
            this.nudFornecedorLoteMinimo.DecimalPlaces = 4;
            this.nudFornecedorLoteMinimo.LiberadoQuandoCadastroUtilizado = true;
            this.nudFornecedorLoteMinimo.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudFornecedorLoteMinimo.Location = new System.Drawing.Point(318, 72);
            this.nudFornecedorLoteMinimo.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudFornecedorLoteMinimo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.nudFornecedorLoteMinimo.Name = "nudFornecedorLoteMinimo";
            this.nudFornecedorLoteMinimo.Size = new System.Drawing.Size(136, 20);
            this.nudFornecedorLoteMinimo.TabIndex = 2;
            this.nudFornecedorLoteMinimo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BindingField = null;
            this.label34.LiberadoQuandoCadastroUtilizado = false;
            this.label34.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label34.Location = new System.Drawing.Point(8, 48);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(304, 13);
            this.label34.TabIndex = 40;
            this.label34.Text = "Quantidade de Unidades de Utilização por Unidade de Compra";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.BindingField = null;
            this.label30.LiberadoQuandoCadastroUtilizado = false;
            this.label30.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label30.Location = new System.Drawing.Point(44, 13);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(61, 13);
            this.label30.TabIndex = 20;
            this.label30.Text = "Fornecedor";
            // 
            // nudIPINaoIncluso
            // 
            this.nudIPINaoIncluso.BindingField = null;
            this.nudIPINaoIncluso.DecimalPlaces = 2;
            this.nudIPINaoIncluso.LiberadoQuandoCadastroUtilizado = true;
            this.nudIPINaoIncluso.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudIPINaoIncluso.Location = new System.Drawing.Point(572, 36);
            this.nudIPINaoIncluso.Name = "nudIPINaoIncluso";
            this.nudIPINaoIncluso.Size = new System.Drawing.Size(111, 20);
            this.nudIPINaoIncluso.TabIndex = 3;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BindingField = null;
            this.label28.LiberadoQuandoCadastroUtilizado = false;
            this.label28.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label28.Location = new System.Drawing.Point(469, 38);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(97, 13);
            this.label28.TabIndex = 16;
            this.label28.Text = "IPI Não Incluso (%)";
            // 
            // nudImcsIncluso
            // 
            this.nudImcsIncluso.BindingField = null;
            this.nudImcsIncluso.DecimalPlaces = 2;
            this.nudImcsIncluso.LiberadoQuandoCadastroUtilizado = true;
            this.nudImcsIncluso.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudImcsIncluso.Location = new System.Drawing.Point(343, 36);
            this.nudImcsIncluso.Name = "nudImcsIncluso";
            this.nudImcsIncluso.Size = new System.Drawing.Size(111, 20);
            this.nudImcsIncluso.TabIndex = 2;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BindingField = null;
            this.label29.LiberadoQuandoCadastroUtilizado = false;
            this.label29.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label29.Location = new System.Drawing.Point(250, 38);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(87, 13);
            this.label29.TabIndex = 3;
            this.label29.Text = "ICMS Incluso (%)";
            // 
            // lblFornecedorUnidadeCompra
            // 
            this.lblFornecedorUnidadeCompra.AutoSize = true;
            this.lblFornecedorUnidadeCompra.BindingField = null;
            this.lblFornecedorUnidadeCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFornecedorUnidadeCompra.LiberadoQuandoCadastroUtilizado = false;
            this.lblFornecedorUnidadeCompra.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblFornecedorUnidadeCompra.Location = new System.Drawing.Point(148, 71);
            this.lblFornecedorUnidadeCompra.Name = "lblFornecedorUnidadeCompra";
            this.lblFornecedorUnidadeCompra.Size = new System.Drawing.Size(0, 13);
            this.lblFornecedorUnidadeCompra.TabIndex = 8;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BindingField = null;
            this.label27.LiberadoQuandoCadastroUtilizado = false;
            this.label27.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label27.Location = new System.Drawing.Point(38, 71);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(104, 13);
            this.label27.TabIndex = 7;
            this.label27.Text = "Unidade de Compra:";
            // 
            // nudUltimoPreco
            // 
            this.nudUltimoPreco.BindingField = null;
            this.nudUltimoPreco.DecimalPlaces = 4;
            this.nudUltimoPreco.LiberadoQuandoCadastroUtilizado = true;
            this.nudUltimoPreco.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudUltimoPreco.Location = new System.Drawing.Point(111, 36);
            this.nudUltimoPreco.Maximum = new decimal(new int[] {
            276447232,
            23283,
            0,
            0});
            this.nudUltimoPreco.Name = "nudUltimoPreco";
            this.nudUltimoPreco.Size = new System.Drawing.Size(111, 20);
            this.nudUltimoPreco.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BindingField = null;
            this.label9.LiberadoQuandoCadastroUtilizado = false;
            this.label9.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label9.Location = new System.Drawing.Point(38, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Ultimo Preço";
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.LiberadoQuandoCadastroUtilizado = true;
            this.btnRemove.Location = new System.Drawing.Point(657, 171);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(123, 23);
            this.btnRemove.TabIndex = 8;
            this.btnRemove.Text = "Remover";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.LiberadoQuandoCadastroUtilizado = true;
            this.btnAdd.Location = new System.Drawing.Point(657, 146);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(121, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Adicionar/Atualizar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            this.FornecedorNomeFantasia,
            this.FornecedorRazao,
            this.UltimoPreco,
            this.IPI,
            this.ICMS,
            this.UltimoCompra,
            this.UnidadeCompra,
            this.QtdPorUnidadeCompra,
            this.LoteMinimo,
            this.LotePadraoColumn,
            this.PreferencialColumn});
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
            this.dataGridView1.Size = new System.Drawing.Size(785, 440);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // FornecedorNomeFantasia
            // 
            this.FornecedorNomeFantasia.DataPropertyName = "FornecedorNomeFantasia";
            this.FornecedorNomeFantasia.HeaderText = "Nome Fantasia";
            this.FornecedorNomeFantasia.Name = "FornecedorNomeFantasia";
            this.FornecedorNomeFantasia.ReadOnly = true;
            // 
            // FornecedorRazao
            // 
            this.FornecedorRazao.DataPropertyName = "FornecedorRazao";
            this.FornecedorRazao.HeaderText = "Razão Social";
            this.FornecedorRazao.Name = "FornecedorRazao";
            this.FornecedorRazao.ReadOnly = true;
            // 
            // UltimoPreco
            // 
            this.UltimoPreco.DataPropertyName = "UltimoPreco";
            this.UltimoPreco.HeaderText = "Último Preço";
            this.UltimoPreco.Name = "UltimoPreco";
            this.UltimoPreco.ReadOnly = true;
            // 
            // IPI
            // 
            this.IPI.DataPropertyName = "Ipi";
            this.IPI.HeaderText = "IPI";
            this.IPI.Name = "IPI";
            this.IPI.ReadOnly = true;
            // 
            // ICMS
            // 
            this.ICMS.DataPropertyName = "Icms";
            this.ICMS.HeaderText = "ICMS";
            this.ICMS.Name = "ICMS";
            this.ICMS.ReadOnly = true;
            // 
            // UltimoCompra
            // 
            this.UltimoCompra.DataPropertyName = "DataUltimaCompra";
            this.UltimoCompra.HeaderText = "Último Compra";
            this.UltimoCompra.Name = "UltimoCompra";
            this.UltimoCompra.ReadOnly = true;
            // 
            // UnidadeCompra
            // 
            this.UnidadeCompra.DataPropertyName = "UnidadeMedidaCompra";
            this.UnidadeCompra.HeaderText = "Unidade Compra";
            this.UnidadeCompra.Name = "UnidadeCompra";
            this.UnidadeCompra.ReadOnly = true;
            // 
            // QtdPorUnidadeCompra
            // 
            this.QtdPorUnidadeCompra.DataPropertyName = "UnidadesPorUnCompra";
            this.QtdPorUnidadeCompra.HeaderText = "Qtd. Por Unidade Compra";
            this.QtdPorUnidadeCompra.Name = "QtdPorUnidadeCompra";
            this.QtdPorUnidadeCompra.ReadOnly = true;
            // 
            // LoteMinimo
            // 
            this.LoteMinimo.DataPropertyName = "LoteMinimo";
            this.LoteMinimo.HeaderText = "Lote Mínimo";
            this.LoteMinimo.Name = "LoteMinimo";
            this.LoteMinimo.ReadOnly = true;
            // 
            // LotePadraoColumn
            // 
            this.LotePadraoColumn.DataPropertyName = "LotePadrao";
            this.LotePadraoColumn.HeaderText = "Lote Padrão";
            this.LotePadraoColumn.Name = "LotePadraoColumn";
            this.LotePadraoColumn.ReadOnly = true;
            // 
            // PreferencialColumn
            // 
            this.PreferencialColumn.DataPropertyName = "Preferencial";
            this.PreferencialColumn.HeaderText = "Preferencial";
            this.PreferencialColumn.Name = "PreferencialColumn";
            this.PreferencialColumn.ReadOnly = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.label33);
            this.tabPage5.Controls.Add(this.nudControleValidadeMeses);
            this.tabPage5.Controls.Add(this.label32);
            this.tabPage5.Controls.Add(this.chkControleValidade);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(791, 664);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Validade";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.BindingField = null;
            this.label33.LiberadoQuandoCadastroUtilizado = false;
            this.label33.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label33.Location = new System.Drawing.Point(18, 27);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(160, 13);
            this.label33.TabIndex = 3;
            this.label33.Text = "Controle de Validade do Material";
            // 
            // nudControleValidadeMeses
            // 
            this.nudControleValidadeMeses.BindingField = "ControleValidadeMeses";
            this.nudControleValidadeMeses.Enabled = false;
            this.nudControleValidadeMeses.LiberadoQuandoCadastroUtilizado = true;
            this.nudControleValidadeMeses.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudControleValidadeMeses.Location = new System.Drawing.Point(184, 47);
            this.nudControleValidadeMeses.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudControleValidadeMeses.Name = "nudControleValidadeMeses";
            this.nudControleValidadeMeses.Size = new System.Drawing.Size(85, 20);
            this.nudControleValidadeMeses.TabIndex = 2;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.BindingField = null;
            this.label32.LiberadoQuandoCadastroUtilizado = false;
            this.label32.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label32.Location = new System.Drawing.Point(8, 49);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(170, 13);
            this.label32.TabIndex = 1;
            this.label32.Text = "Prazo de Validade Padrão (Meses)";
            // 
            // chkControleValidade
            // 
            this.chkControleValidade.AutoSize = true;
            this.chkControleValidade.BindingField = "ControleValidade";
            this.chkControleValidade.LiberadoQuandoCadastroUtilizado = true;
            this.chkControleValidade.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkControleValidade.Location = new System.Drawing.Point(184, 27);
            this.chkControleValidade.Name = "chkControleValidade";
            this.chkControleValidade.Size = new System.Drawing.Size(15, 14);
            this.chkControleValidade.TabIndex = 0;
            this.chkControleValidade.UseVisualStyleBackColor = true;
            this.chkControleValidade.CheckedChanged += new System.EventHandler(this.chkControleValidade_CheckedChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.Imagem);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(791, 664);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Imagem";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // Imagem
            // 
            this.Imagem.BindingField = "Imagem";
            this.Imagem.LiberadoQuandoCadastroUtilizado = true;
            this.Imagem.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Imagem.Location = new System.Drawing.Point(8, 6);
            this.Imagem.Name = "Imagem";
            this.Imagem.Size = new System.Drawing.Size(775, 616);
            this.Imagem.TabIndex = 55;
            this.Imagem.Value = null;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.grbRevisao);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(791, 664);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Última Revisão";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // grbRevisao
            // 
            this.grbRevisao.Controls.Add(this.lblRevisaoJustificativa);
            this.grbRevisao.Controls.Add(this.lblRevisaoData);
            this.grbRevisao.Controls.Add(this.lblRevisaoUsuario);
            this.grbRevisao.Controls.Add(this.lblRevisaoJustificativaLabel);
            this.grbRevisao.Controls.Add(this.lblRevisaoDataLabel);
            this.grbRevisao.Controls.Add(this.lblRevisaoUsuarioLabel);
            this.grbRevisao.Location = new System.Drawing.Point(8, 6);
            this.grbRevisao.Name = "grbRevisao";
            this.grbRevisao.Size = new System.Drawing.Size(775, 94);
            this.grbRevisao.TabIndex = 65;
            this.grbRevisao.TabStop = false;
            this.grbRevisao.Text = "Revisão";
            // 
            // lblRevisaoJustificativa
            // 
            this.lblRevisaoJustificativa.AutoSize = true;
            this.lblRevisaoJustificativa.BindingField = "UltimaRevisao";
            this.lblRevisaoJustificativa.LiberadoQuandoCadastroUtilizado = false;
            this.lblRevisaoJustificativa.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblRevisaoJustificativa.Location = new System.Drawing.Point(100, 62);
            this.lblRevisaoJustificativa.Name = "lblRevisaoJustificativa";
            this.lblRevisaoJustificativa.Size = new System.Drawing.Size(0, 13);
            this.lblRevisaoJustificativa.TabIndex = 5;
            // 
            // lblRevisaoData
            // 
            this.lblRevisaoData.AutoSize = true;
            this.lblRevisaoData.BindingField = "UltimaRevisaoData";
            this.lblRevisaoData.LiberadoQuandoCadastroUtilizado = false;
            this.lblRevisaoData.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblRevisaoData.Location = new System.Drawing.Point(100, 39);
            this.lblRevisaoData.Name = "lblRevisaoData";
            this.lblRevisaoData.Size = new System.Drawing.Size(0, 13);
            this.lblRevisaoData.TabIndex = 4;
            // 
            // lblRevisaoUsuario
            // 
            this.lblRevisaoUsuario.AutoSize = true;
            this.lblRevisaoUsuario.BindingField = "UltimaRevisaoUsuario";
            this.lblRevisaoUsuario.LiberadoQuandoCadastroUtilizado = false;
            this.lblRevisaoUsuario.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblRevisaoUsuario.Location = new System.Drawing.Point(100, 16);
            this.lblRevisaoUsuario.Name = "lblRevisaoUsuario";
            this.lblRevisaoUsuario.Size = new System.Drawing.Size(0, 13);
            this.lblRevisaoUsuario.TabIndex = 3;
            // 
            // lblRevisaoJustificativaLabel
            // 
            this.lblRevisaoJustificativaLabel.AutoSize = true;
            this.lblRevisaoJustificativaLabel.BindingField = null;
            this.lblRevisaoJustificativaLabel.LiberadoQuandoCadastroUtilizado = false;
            this.lblRevisaoJustificativaLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblRevisaoJustificativaLabel.Location = new System.Drawing.Point(16, 62);
            this.lblRevisaoJustificativaLabel.Name = "lblRevisaoJustificativaLabel";
            this.lblRevisaoJustificativaLabel.Size = new System.Drawing.Size(62, 13);
            this.lblRevisaoJustificativaLabel.TabIndex = 2;
            this.lblRevisaoJustificativaLabel.Text = "Justificativa";
            // 
            // lblRevisaoDataLabel
            // 
            this.lblRevisaoDataLabel.AutoSize = true;
            this.lblRevisaoDataLabel.BindingField = null;
            this.lblRevisaoDataLabel.LiberadoQuandoCadastroUtilizado = false;
            this.lblRevisaoDataLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblRevisaoDataLabel.Location = new System.Drawing.Point(48, 39);
            this.lblRevisaoDataLabel.Name = "lblRevisaoDataLabel";
            this.lblRevisaoDataLabel.Size = new System.Drawing.Size(30, 13);
            this.lblRevisaoDataLabel.TabIndex = 1;
            this.lblRevisaoDataLabel.Text = "Data";
            // 
            // lblRevisaoUsuarioLabel
            // 
            this.lblRevisaoUsuarioLabel.AutoSize = true;
            this.lblRevisaoUsuarioLabel.BindingField = null;
            this.lblRevisaoUsuarioLabel.LiberadoQuandoCadastroUtilizado = false;
            this.lblRevisaoUsuarioLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblRevisaoUsuarioLabel.Location = new System.Drawing.Point(35, 16);
            this.lblRevisaoUsuarioLabel.Name = "lblRevisaoUsuarioLabel";
            this.lblRevisaoUsuarioLabel.Size = new System.Drawing.Size(43, 13);
            this.lblRevisaoUsuarioLabel.TabIndex = 0;
            this.lblRevisaoUsuarioLabel.Text = "Usuário";
            // 
            // btnSalvarComo
            // 
            this.btnSalvarComo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvarComo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSalvarComo.FlatAppearance.BorderSize = 0;
            this.btnSalvarComo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvarComo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSalvarComo.LiberadoQuandoCadastroUtilizado = true;
            this.btnSalvarComo.Location = new System.Drawing.Point(323, 8);
            this.btnSalvarComo.Margin = new System.Windows.Forms.Padding(0);
            this.btnSalvarComo.Name = "btnSalvarComo";
            this.btnSalvarComo.Size = new System.Drawing.Size(169, 23);
            this.btnSalvarComo.TabIndex = 3;
            this.btnSalvarComo.Text = "Copiar Material";
            this.btnSalvarComo.UseVisualStyleBackColor = false;
            this.btnSalvarComo.Click += new System.EventHandler(this.btnSalvarComo_Click);
            // 
            // ofdImagem
            // 
            this.ofdImagem.Filter = "Imagens JPG|*.jpg";
            this.ofdImagem.RestoreDirectory = true;
            // 
            // CadMaterialForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(799, 732);
            this.Name = "CadMaterialForm";
            this.Text = "Material";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.grbPrincipal.ResumeLayout(false);
            this.grbPrincipal.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudComprimento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLargura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMatMedida)).EndInit();
            this.grbCompras.ResumeLayout(false);
            this.grbCompras.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLotePadrao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMargemRecebimento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLeadtimeCompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudConversaoUnidades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLoteMinimo)).EndInit();
            this.grbPoliticaEstoque.ResumeLayout(false);
            this.grbPoliticaEstoque.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudVerde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmarelo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVermelho)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.grbUnidadeCompraFornecedor.ResumeLayout(false);
            this.grbUnidadeCompraFornecedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFornecedorLotePadrao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFornecedorUnidadesPorUnidadeCompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFornecedorLoteMinimo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIPINaoIncluso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImcsIncluso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUltimoPreco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudControleValidadeMeses)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.grbRevisao.ResumeLayout(false);
            this.grbRevisao.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private IWTDotNetLib.IWTLabel label1;
        private IWTDotNetLib.IWTLabel label2;
        private IWTDotNetLib.IWTTextBox txtMatDescricao;
        private IWTDotNetLib.IWTNumericUpDown nudMatMedida;
        private IWTDotNetLib.IWTLabel label3;
        private IWTDotNetLib.IWTNumericUpDown nudComprimento;
        private IWTDotNetLib.IWTLabel label6;
        private IWTDotNetLib.IWTNumericUpDown nudLargura;
        private IWTDotNetLib.IWTLabel label5;
        private IWTDotNetLib.IWTTextBox txtCodigo;
        private IWTDotNetLib.IWTLabel label4;
        private IWTDotNetLib.IWTLabel label8;
        private IWTDotNetLib.IWTMultiColumnComboBox Acabamento;
        private IWTDotNetLib.IWTMultiColumnComboBox UnidadeMedida;
        private IWTDotNetLib.IWTMultiColumnComboBox FamiliaMaterial;
        private IWTDotNetLib.IWTLabel label7;
        private System.Windows.Forms.GroupBox grbPoliticaEstoque;
        private IWTDotNetLib.IWTRadioButton rdbNaoAplicavel;
        private IWTDotNetLib.IWTRadioButton rdbProducaoRepetitiva;
        private IWTDotNetLib.IWTRadioButton rdbMRP;
        private IWTDotNetLib.IWTTextBox txtMatDescricaoComplementar;
        private IWTDotNetLib.IWTLabel label10;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private IWTDotNetLib.IWTButton btnAdd;
        private IWTDotNetLib.IWTButton btnRemove;
        private IWTDotNetLib.IWTDataGridView dataGridView1;
        private IWTDotNetLib.IWTLabel label11;
        private IWTDotNetLib.IWTNumericUpDown nudVermelho;
        private IWTDotNetLib.IWTLabel label12;
        private IWTDotNetLib.IWTNumericUpDown nudAmarelo;
        private IWTDotNetLib.IWTLabel label13;
        private IWTDotNetLib.IWTNumericUpDown nudVerde;
        private IWTDotNetLib.IWTLabel label14;
        private IWTDotNetLib.IWTNumericUpDown nudLoteMinimo;
        private IWTDotNetLib.IWTNumericUpDown nudUltimoPreco;
        private IWTDotNetLib.IWTLabel label9;
        private System.Windows.Forms.GroupBox grbCompras;
        private IWTDotNetLib.IWTLabel label15;
        private IWTDotNetLib.IWTLabel label16;
        private IWTDotNetLib.IWTLabel lblUnidades;
        private IWTDotNetLib.IWTNumericUpDown nudConversaoUnidades;
        private IWTDotNetLib.IWTLabel lblVermelhoSugerido;
        private IWTDotNetLib.IWTLabel lbAmareloSugerido;
        private IWTDotNetLib.IWTLabel lblClassificacaoABC;
        private IWTDotNetLib.IWTLabel lblVerdeSugerido;
        private IWTDotNetLib.IWTLabel lblReverVermelho;
        private IWTDotNetLib.IWTLabel lblReverAmarelo;
        private IWTDotNetLib.IWTLabel lblReverVerde;
        private IWTDotNetLib.IWTCheckBox chkUnidadeCompra;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private IWTDotNetLib.IWTLabel label17;
        private IWTDotNetLib.IWTLabel label18;
        private IWTDotNetLib.IWTLabel label19;
        private IWTDotNetLib.IWTNumericUpDown nudLeadtimeCompra;
        private IWTDotNetLib.IWTLabel label20;
        private IWTDotNetLib.IWTTextBox txtMatMarcasHomologadas;
        private IWTDotNetLib.IWTLabel label21;
        private IWTDotNetLib.IWTLabel lblLeadtimeCompras;
        private IWTDotNetLib.IWTLabel lblLeadtimePCP;
        private IWTDotNetLib.IWTLabel lblFaixaC;
        private IWTDotNetLib.IWTLabel lblFaixaB;
        private IWTDotNetLib.IWTLabel lblFaixaA;
        private IWTDotNetLib.IWTLabel label22;
        private IWTDotNetLib.IWTLabel lblSugeridoAcimaCompras;
        private IWTDotNetLib.IWTLabel lblDisparo;
        private IWTDotNetLib.IWTLabel label23;
        private IWTDotNetLib.IWTCheckBox chkImpedirSolicitacaoAutomatica;
        private System.Windows.Forms.GroupBox grbPrincipal;
        private System.Windows.Forms.TabPage tabPage3;
        private IWTDotNetLib.IWTButton btnSalvarComo;
        private IWTDotNetLib.IWTLinkLabel lnkConfiguracoes;
        private IWTDotNetLib.IWTLabel label27;
        private IWTDotNetLib.IWTLabel lblFornecedorUnidadeCompra;
        private IWTDotNetLib.IWTNumericUpDown nudIPINaoIncluso;
        private IWTDotNetLib.IWTLabel label28;
        private IWTDotNetLib.IWTNumericUpDown nudImcsIncluso;
        private IWTDotNetLib.IWTLabel label29;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.OpenFileDialog ofdImagem;
        private IWTDotNetLib.IWTLabel label30;
        private IWTDotNetLib.IWTCheckBox chkComprador;
        private IWTDotNetLib.IWTMultiColumnComboBox Comprador;
        private IWTDotNetLib.IWTLabel label31;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tabPage5;
        private IWTDotNetLib.IWTLabel label33;
        private IWTDotNetLib.IWTNumericUpDown nudControleValidadeMeses;
        private IWTDotNetLib.IWTLabel label32;
        private IWTDotNetLib.IWTCheckBox chkControleValidade;
        private IWTDotNetLib.IWTNumericUpDown nudFornecedorUnidadesPorUnidadeCompra;
        private IWTDotNetLib.IWTLabel label34;
        private IWTDotNetLib.IWTMultiColumnComboBox cmbFornecedorUnidadeCompra;
        private IWTDotNetLib.IWTNumericUpDown nudFornecedorLoteMinimo;
        private IWTDotNetLib.IWTLabel label35;
        private IWTDotNetLib.IWTLabel label36;
        private System.Windows.Forms.GroupBox grbUnidadeCompraFornecedor;
        private IWTDotNetLib.IWTCheckBox chkUnidadeCompraFornecedor;
        private IWTDotNetLib.IWTNumericUpDown nudMargemRecebimento;
        private IWTDotNetLib.IWTLabel label37;
        private IWTDotNetLib.IWTCheckBox chkMargemRecebimento;
        private IWTDotNetLib.IWTImage Imagem;
        private GroupBox grbRevisao;
        private IWTDotNetLib.IWTLabel lblRevisaoJustificativa;
        private IWTDotNetLib.IWTLabel lblRevisaoData;
        private IWTDotNetLib.IWTLabel lblRevisaoUsuario;
        private IWTDotNetLib.IWTLabel lblRevisaoJustificativaLabel;
        private IWTDotNetLib.IWTLabel lblRevisaoDataLabel;
        private IWTDotNetLib.IWTLabel lblRevisaoUsuarioLabel;
        private IWTDotNetLib.IWTMultiColumnComboBox UnidadeMedidaCompra;
        private IWTDotNetLib.IWTEntitySelection ensFornecedor;
        private IWTDotNetLib.IWTTextBox iwtTextBox1;
        private IWTDotNetLib.IWTLabel iwtLabel1;
        private ToolTip toolTip1;
        private IWTDotNetLib.IWTLabel lblSugestaoLeadTime;
        private IWTDotNetLib.IWTNumericUpDown nudLotePadrao;
        private IWTDotNetLib.IWTLabel iwtLabel2;
        private IWTDotNetLib.IWTLabel iwtLabel3;
        private IWTDotNetLib.IWTNumericUpDown nudFornecedorLotePadrao;
        private IWTDotNetLib.IWTCheckBox chkFornecedorPreferencial;
        private DataGridViewTextBoxColumn FornecedorNomeFantasia;
        private DataGridViewTextBoxColumn FornecedorRazao;
        private DataGridViewTextBoxColumn UltimoPreco;
        private DataGridViewTextBoxColumn IPI;
        private DataGridViewTextBoxColumn ICMS;
        private DataGridViewTextBoxColumn UltimoCompra;
        private DataGridViewTextBoxColumn UnidadeCompra;
        private DataGridViewTextBoxColumn QtdPorUnidadeCompra;
        private DataGridViewTextBoxColumn LoteMinimo;
        private DataGridViewTextBoxColumn LotePadraoColumn;
        private DataGridViewCheckBoxColumn PreferencialColumn;
    }
}