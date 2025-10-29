using System.Windows.Forms;

namespace BibliotecaFinanceiro
{
    partial class CadEmitenteForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ensCidade = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.txtCep = new System.Windows.Forms.MaskedTextBox();
            this.txtIM = new System.Windows.Forms.MaskedTextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.txtCNAE = new System.Windows.Forms.MaskedTextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbNormal = new System.Windows.Forms.RadioButton();
            this.rdbSimplesExcesso = new System.Windows.Forms.RadioButton();
            this.rdbSimples = new System.Windows.Forms.RadioButton();
            this.txtTelefone = new System.Windows.Forms.MaskedTextBox();
            this.txtFax = new System.Windows.Forms.MaskedTextBox();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.txtNomeContato = new System.Windows.Forms.TextBox();
            this.txtComplento = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.txtIE = new System.Windows.Forms.TextBox();
            this.txtCNPJ = new System.Windows.Forms.TextBox();
            this.txtEmpresa = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.grbCertificado = new System.Windows.Forms.GroupBox();
            this.cmbCertificados = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtObsPadraoNfe = new System.Windows.Forms.TextBox();
            this.txtVersaoEmissor = new System.Windows.Forms.TextBox();
            this.txtPathOutNF = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.btnPath = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.gbxPIS = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cmbModTributPis = new System.Windows.Forms.ComboBox();
            this.cbxImpRetidoPis = new System.Windows.Forms.CheckBox();
            this.nudAliquotaPis = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.cmbCSTPis = new System.Windows.Forms.ComboBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.gbxCOFINS = new System.Windows.Forms.GroupBox();
            this.label24 = new System.Windows.Forms.Label();
            this.cmbModTributCofins = new System.Windows.Forms.ComboBox();
            this.cbxImpRetidoCofins = new System.Windows.Forms.CheckBox();
            this.nudAliquotaCofins = new System.Windows.Forms.NumericUpDown();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.cmbCSTCofins = new System.Windows.Forms.ComboBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.chkArquivamentoNFe = new System.Windows.Forms.CheckBox();
            this.grbArquivamentoNFe = new System.Windows.Forms.GroupBox();
            this.btnPastaDanfe = new System.Windows.Forms.Button();
            this.txtPastaDanfe = new System.Windows.Forms.TextBox();
            this.btnPastaXML = new System.Windows.Forms.Button();
            this.txtPastaXML = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.chkImpressaoDanfe = new System.Windows.Forms.CheckBox();
            this.grbImpressaoDanfe = new System.Windows.Forms.GroupBox();
            this.cmbImpressoraDanfe2 = new System.Windows.Forms.ComboBox();
            this.label33 = new System.Windows.Forms.Label();
            this.cmbImpressoraDanfe1 = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.chkEnvioNfeEmail = new System.Windows.Forms.CheckBox();
            this.grbEnvioNFeEmail = new System.Windows.Forms.GroupBox();
            this.txtEnvioNFeRemetente = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkEnvioNFeCliente = new System.Windows.Forms.CheckBox();
            this.label31 = new System.Windows.Forms.Label();
            this.txtEnvioDANFEDestino = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.chkEnvioDANFE = new System.Windows.Forms.CheckBox();
            this.label30 = new System.Windows.Forms.Label();
            this.txtEnvioXMLDestino = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.chkEnvioXML = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.txtAutorizadoDocumento = new System.Windows.Forms.MaskedTextBox();
            this.rdbAutorizadosCNPJ = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbAutorizadosCPF = new IWTDotNetLib.IWTRadioButton(this.components);
            this.btnAutorizadosExcluir = new IWTDotNetLib.IWTButton(this.components);
            this.btnAutorizadosNovo = new IWTDotNetLib.IWTButton(this.components);
            this.dgvAutorizados = new System.Windows.Forms.DataGridView();
            this.AutorizadosColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.grbCertificado.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.gbxPIS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAliquotaPis)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.gbxCOFINS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAliquotaCofins)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.grbArquivamentoNFe.SuspendLayout();
            this.grbImpressaoDanfe.SuspendLayout();
            this.grbEnvioNFeEmail.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutorizados)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
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
            this.splitContainer1.Panel2.Controls.Add(this.btnCancelar);
            this.splitContainer1.Panel2.Controls.Add(this.btnSalvar);
            this.splitContainer1.Size = new System.Drawing.Size(784, 491);
            this.splitContainer1.SplitterDistance = 430;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 430);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ensCidade);
            this.tabPage1.Controls.Add(this.txtCep);
            this.tabPage1.Controls.Add(this.txtIM);
            this.tabPage1.Controls.Add(this.label38);
            this.tabPage1.Controls.Add(this.txtCNAE);
            this.tabPage1.Controls.Add(this.label37);
            this.tabPage1.Controls.Add(this.label36);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.txtTelefone);
            this.tabPage1.Controls.Add(this.txtFax);
            this.tabPage1.Controls.Add(this.txtBairro);
            this.tabPage1.Controls.Add(this.txtNomeContato);
            this.tabPage1.Controls.Add(this.txtComplento);
            this.tabPage1.Controls.Add(this.txtNumero);
            this.tabPage1.Controls.Add(this.txtEndereco);
            this.tabPage1.Controls.Add(this.txtIE);
            this.tabPage1.Controls.Add(this.txtCNPJ);
            this.tabPage1.Controls.Add(this.txtEmpresa);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(776, 404);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dados do Emitente";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ensCidade
            // 
            this.ensCidade.BindingField = null;
            this.ensCidade.ColunasDropdown = null;
            this.ensCidade.DesabilitarAutoCompletar = false;
            this.ensCidade.DesabilitarChekBox = true;
            this.ensCidade.DesabilitarLupa = false;
            this.ensCidade.DesabilitarSeta = false;
            this.ensCidade.EntidadeSelecionada = null;
            this.ensCidade.FormSelecao = null;
            this.ensCidade.LiberadoQuandoCadastroUtilizado = false;
            this.ensCidade.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensCidade.Location = new System.Drawing.Point(108, 167);
            this.ensCidade.ModoVisualizacaoGrid = null;
            this.ensCidade.Name = "ensCidade";
            this.ensCidade.ParametroBuscaGuiada = null;
            this.ensCidade.ParametrosBuscaObrigatorios = null;
            this.ensCidade.Size = new System.Drawing.Size(364, 23);
            this.ensCidade.TabIndex = 53;
            // 
            // txtCep
            // 
            this.txtCep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCep.Location = new System.Drawing.Point(587, 141);
            this.txtCep.Mask = "00000-000";
            this.txtCep.Name = "txtCep";
            this.txtCep.Size = new System.Drawing.Size(181, 20);
            this.txtCep.TabIndex = 52;
            // 
            // txtIM
            // 
            this.txtIM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIM.Location = new System.Drawing.Point(587, 63);
            this.txtIM.Mask = "000000000000000";
            this.txtIM.Name = "txtIM";
            this.txtIM.Size = new System.Drawing.Size(181, 20);
            this.txtIM.TabIndex = 4;
            // 
            // label38
            // 
            this.label38.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(503, 66);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(78, 13);
            this.label38.TabIndex = 49;
            this.label38.Text = "Insc. Municipal";
            // 
            // txtCNAE
            // 
            this.txtCNAE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCNAE.Location = new System.Drawing.Point(587, 37);
            this.txtCNAE.Mask = "0000000";
            this.txtCNAE.Name = "txtCNAE";
            this.txtCNAE.Size = new System.Drawing.Size(181, 20);
            this.txtCNAE.TabIndex = 2;
            // 
            // label37
            // 
            this.label37.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(545, 40);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(36, 13);
            this.label37.TabIndex = 47;
            this.label37.Text = "CNAE";
            // 
            // label36
            // 
            this.label36.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(537, 92);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(44, 13);
            this.label36.TabIndex = 45;
            this.label36.Text = "Número";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rdbNormal);
            this.groupBox1.Controls.Add(this.rdbSimplesExcesso);
            this.groupBox1.Controls.Add(this.rdbSimples);
            this.groupBox1.Location = new System.Drawing.Point(11, 295);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(757, 46);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Regime Tributário";
            // 
            // rdbNormal
            // 
            this.rdbNormal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbNormal.AutoSize = true;
            this.rdbNormal.Location = new System.Drawing.Point(654, 19);
            this.rdbNormal.Name = "rdbNormal";
            this.rdbNormal.Size = new System.Drawing.Size(97, 17);
            this.rdbNormal.TabIndex = 2;
            this.rdbNormal.TabStop = true;
            this.rdbNormal.Text = "Regime Normal";
            this.rdbNormal.UseVisualStyleBackColor = true;
            // 
            // rdbSimplesExcesso
            // 
            this.rdbSimplesExcesso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbSimplesExcesso.AutoSize = true;
            this.rdbSimplesExcesso.Location = new System.Drawing.Point(236, 19);
            this.rdbSimplesExcesso.Name = "rdbSimplesExcesso";
            this.rdbSimplesExcesso.Size = new System.Drawing.Size(284, 17);
            this.rdbSimplesExcesso.TabIndex = 1;
            this.rdbSimplesExcesso.TabStop = true;
            this.rdbSimplesExcesso.Text = "Simples Nacional - excesso de sublime de receita bruta";
            this.rdbSimplesExcesso.UseVisualStyleBackColor = true;
            // 
            // rdbSimples
            // 
            this.rdbSimples.AutoSize = true;
            this.rdbSimples.Location = new System.Drawing.Point(6, 19);
            this.rdbSimples.Name = "rdbSimples";
            this.rdbSimples.Size = new System.Drawing.Size(106, 17);
            this.rdbSimples.TabIndex = 0;
            this.rdbSimples.TabStop = true;
            this.rdbSimples.Text = "Simples Nacional";
            this.rdbSimples.UseVisualStyleBackColor = true;
            // 
            // txtTelefone
            // 
            this.txtTelefone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTelefone.Location = new System.Drawing.Point(108, 196);
            this.txtTelefone.Mask = "99999900000000";
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(364, 20);
            this.txtTelefone.TabIndex = 15;
            this.txtTelefone.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // txtFax
            // 
            this.txtFax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFax.Location = new System.Drawing.Point(587, 196);
            this.txtFax.Mask = "99999900000000";
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(181, 20);
            this.txtFax.TabIndex = 16;
            this.txtFax.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // txtBairro
            // 
            this.txtBairro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBairro.Location = new System.Drawing.Point(108, 141);
            this.txtBairro.MaxLength = 60;
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(364, 20);
            this.txtBairro.TabIndex = 8;
            // 
            // txtNomeContato
            // 
            this.txtNomeContato.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNomeContato.Location = new System.Drawing.Point(108, 222);
            this.txtNomeContato.Name = "txtNomeContato";
            this.txtNomeContato.Size = new System.Drawing.Size(660, 20);
            this.txtNomeContato.TabIndex = 17;
            // 
            // txtComplento
            // 
            this.txtComplento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComplento.Location = new System.Drawing.Point(108, 115);
            this.txtComplento.MaxLength = 60;
            this.txtComplento.Name = "txtComplento";
            this.txtComplento.Size = new System.Drawing.Size(364, 20);
            this.txtComplento.TabIndex = 7;
            // 
            // txtNumero
            // 
            this.txtNumero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumero.Location = new System.Drawing.Point(587, 89);
            this.txtNumero.MaxLength = 60;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(181, 20);
            this.txtNumero.TabIndex = 6;
            this.txtNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumero_KeyPress);
            // 
            // txtEndereco
            // 
            this.txtEndereco.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEndereco.Location = new System.Drawing.Point(108, 89);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(364, 20);
            this.txtEndereco.TabIndex = 5;
            // 
            // txtIE
            // 
            this.txtIE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIE.Location = new System.Drawing.Point(108, 63);
            this.txtIE.Name = "txtIE";
            this.txtIE.Size = new System.Drawing.Size(364, 20);
            this.txtIE.TabIndex = 3;
            // 
            // txtCNPJ
            // 
            this.txtCNPJ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCNPJ.Location = new System.Drawing.Point(108, 37);
            this.txtCNPJ.MaxLength = 14;
            this.txtCNPJ.Name = "txtCNPJ";
            this.txtCNPJ.Size = new System.Drawing.Size(364, 20);
            this.txtCNPJ.TabIndex = 1;
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmpresa.Location = new System.Drawing.Point(108, 11);
            this.txtEmpresa.MaxLength = 60;
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.Size = new System.Drawing.Size(660, 20);
            this.txtEmpresa.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(53, 201);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 13);
            this.label15.TabIndex = 24;
            this.label15.Text = "Telefone";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(557, 199);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(24, 13);
            this.label14.TabIndex = 23;
            this.label14.Text = "Fax";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 225);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "Nome do Contato";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 66);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Inscrição Estadual";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(49, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Endereço";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(68, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Bairro";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(553, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "CEP";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(62, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Cidade";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Complemento";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(68, 40);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "CNPJ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome da Empresa";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grbCertificado);
            this.tabPage2.Controls.Add(this.txtObsPadraoNfe);
            this.tabPage2.Controls.Add(this.txtVersaoEmissor);
            this.tabPage2.Controls.Add(this.txtPathOutNF);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label27);
            this.tabPage2.Controls.Add(this.btnPath);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(776, 404);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Dados para Emissão de NF";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // grbCertificado
            // 
            this.grbCertificado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbCertificado.Controls.Add(this.cmbCertificados);
            this.grbCertificado.Controls.Add(this.label18);
            this.grbCertificado.Location = new System.Drawing.Point(21, 58);
            this.grbCertificado.Name = "grbCertificado";
            this.grbCertificado.Size = new System.Drawing.Size(747, 82);
            this.grbCertificado.TabIndex = 49;
            this.grbCertificado.TabStop = false;
            this.grbCertificado.Text = "Certificado Emissão NFe";
            // 
            // cmbCertificados
            // 
            this.cmbCertificados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCertificados.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCertificados.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCertificados.FormattingEnabled = true;
            this.cmbCertificados.Location = new System.Drawing.Point(26, 43);
            this.cmbCertificados.Name = "cmbCertificados";
            this.cmbCertificados.Size = new System.Drawing.Size(678, 21);
            this.cmbCertificados.TabIndex = 1;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(10, 26);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(57, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Certificado";
            // 
            // txtObsPadraoNfe
            // 
            this.txtObsPadraoNfe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObsPadraoNfe.Location = new System.Drawing.Point(145, 159);
            this.txtObsPadraoNfe.MaxLength = 3000;
            this.txtObsPadraoNfe.Multiline = true;
            this.txtObsPadraoNfe.Name = "txtObsPadraoNfe";
            this.txtObsPadraoNfe.Size = new System.Drawing.Size(623, 49);
            this.txtObsPadraoNfe.TabIndex = 48;
            // 
            // txtVersaoEmissor
            // 
            this.txtVersaoEmissor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVersaoEmissor.Location = new System.Drawing.Point(145, 32);
            this.txtVersaoEmissor.Name = "txtVersaoEmissor";
            this.txtVersaoEmissor.Size = new System.Drawing.Size(580, 20);
            this.txtVersaoEmissor.TabIndex = 46;
            // 
            // txtPathOutNF
            // 
            this.txtPathOutNF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPathOutNF.Enabled = false;
            this.txtPathOutNF.Location = new System.Drawing.Point(145, 6);
            this.txtPathOutNF.Name = "txtPathOutNF";
            this.txtPathOutNF.Size = new System.Drawing.Size(580, 20);
            this.txtPathOutNF.TabIndex = 36;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 167);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 13);
            this.label11.TabIndex = 47;
            this.label11.Text = "Obs. Padrão NFE";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(18, 35);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(94, 13);
            this.label27.TabIndex = 45;
            this.label27.Text = "Versão do Emissor";
            // 
            // btnPath
            // 
            this.btnPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPath.Location = new System.Drawing.Point(733, 4);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(35, 23);
            this.btnPath.TabIndex = 38;
            this.btnPath.Text = "...";
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(18, 8);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(95, 13);
            this.label16.TabIndex = 31;
            this.label16.Text = "Local Saida de NF";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.gbxPIS);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(776, 404);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "PIS";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // gbxPIS
            // 
            this.gbxPIS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxPIS.Controls.Add(this.label21);
            this.gbxPIS.Controls.Add(this.cmbModTributPis);
            this.gbxPIS.Controls.Add(this.cbxImpRetidoPis);
            this.gbxPIS.Controls.Add(this.nudAliquotaPis);
            this.gbxPIS.Controls.Add(this.label22);
            this.gbxPIS.Controls.Add(this.label23);
            this.gbxPIS.Controls.Add(this.cmbCSTPis);
            this.gbxPIS.Location = new System.Drawing.Point(8, 3);
            this.gbxPIS.Name = "gbxPIS";
            this.gbxPIS.Size = new System.Drawing.Size(760, 129);
            this.gbxPIS.TabIndex = 26;
            this.gbxPIS.TabStop = false;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(20, 49);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(116, 13);
            this.label21.TabIndex = 37;
            this.label21.Text = "Modalidade Tributação";
            // 
            // cmbModTributPis
            // 
            this.cmbModTributPis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbModTributPis.FormattingEnabled = true;
            this.cmbModTributPis.Location = new System.Drawing.Point(142, 46);
            this.cmbModTributPis.Name = "cmbModTributPis";
            this.cmbModTributPis.Size = new System.Drawing.Size(612, 21);
            this.cmbModTributPis.TabIndex = 36;
            // 
            // cbxImpRetidoPis
            // 
            this.cbxImpRetidoPis.AutoSize = true;
            this.cbxImpRetidoPis.Location = new System.Drawing.Point(142, 99);
            this.cbxImpRetidoPis.Name = "cbxImpRetidoPis";
            this.cbxImpRetidoPis.Size = new System.Drawing.Size(97, 17);
            this.cbxImpRetidoPis.TabIndex = 35;
            this.cbxImpRetidoPis.Text = "Imposto Retido";
            this.cbxImpRetidoPis.UseVisualStyleBackColor = true;
            // 
            // nudAliquotaPis
            // 
            this.nudAliquotaPis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudAliquotaPis.DecimalPlaces = 2;
            this.nudAliquotaPis.Location = new System.Drawing.Point(142, 73);
            this.nudAliquotaPis.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudAliquotaPis.Name = "nudAliquotaPis";
            this.nudAliquotaPis.Size = new System.Drawing.Size(317, 20);
            this.nudAliquotaPis.TabIndex = 33;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(89, 75);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(47, 13);
            this.label22.TabIndex = 34;
            this.label22.Text = "Alíquota";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(108, 22);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(28, 13);
            this.label23.TabIndex = 30;
            this.label23.Text = "CST";
            // 
            // cmbCSTPis
            // 
            this.cmbCSTPis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCSTPis.FormattingEnabled = true;
            this.cmbCSTPis.Location = new System.Drawing.Point(142, 19);
            this.cmbCSTPis.Name = "cmbCSTPis";
            this.cmbCSTPis.Size = new System.Drawing.Size(612, 21);
            this.cmbCSTPis.TabIndex = 29;
            this.cmbCSTPis.SelectedIndexChanged += new System.EventHandler(this.cmbCSTPis_SelectedIndexChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.gbxCOFINS);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(776, 404);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Cofins";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // gbxCOFINS
            // 
            this.gbxCOFINS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxCOFINS.Controls.Add(this.label24);
            this.gbxCOFINS.Controls.Add(this.cmbModTributCofins);
            this.gbxCOFINS.Controls.Add(this.cbxImpRetidoCofins);
            this.gbxCOFINS.Controls.Add(this.nudAliquotaCofins);
            this.gbxCOFINS.Controls.Add(this.label25);
            this.gbxCOFINS.Controls.Add(this.label26);
            this.gbxCOFINS.Controls.Add(this.cmbCSTCofins);
            this.gbxCOFINS.Location = new System.Drawing.Point(8, 3);
            this.gbxCOFINS.Name = "gbxCOFINS";
            this.gbxCOFINS.Size = new System.Drawing.Size(760, 129);
            this.gbxCOFINS.TabIndex = 25;
            this.gbxCOFINS.TabStop = false;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(20, 49);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(116, 13);
            this.label24.TabIndex = 37;
            this.label24.Text = "Modalidade Tributação";
            // 
            // cmbModTributCofins
            // 
            this.cmbModTributCofins.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbModTributCofins.FormattingEnabled = true;
            this.cmbModTributCofins.Location = new System.Drawing.Point(142, 46);
            this.cmbModTributCofins.Name = "cmbModTributCofins";
            this.cmbModTributCofins.Size = new System.Drawing.Size(612, 21);
            this.cmbModTributCofins.TabIndex = 36;
            // 
            // cbxImpRetidoCofins
            // 
            this.cbxImpRetidoCofins.AutoSize = true;
            this.cbxImpRetidoCofins.Location = new System.Drawing.Point(142, 99);
            this.cbxImpRetidoCofins.Name = "cbxImpRetidoCofins";
            this.cbxImpRetidoCofins.Size = new System.Drawing.Size(97, 17);
            this.cbxImpRetidoCofins.TabIndex = 35;
            this.cbxImpRetidoCofins.Text = "Imposto Retido";
            this.cbxImpRetidoCofins.UseVisualStyleBackColor = true;
            // 
            // nudAliquotaCofins
            // 
            this.nudAliquotaCofins.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudAliquotaCofins.DecimalPlaces = 2;
            this.nudAliquotaCofins.Location = new System.Drawing.Point(142, 73);
            this.nudAliquotaCofins.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudAliquotaCofins.Name = "nudAliquotaCofins";
            this.nudAliquotaCofins.Size = new System.Drawing.Size(317, 20);
            this.nudAliquotaCofins.TabIndex = 33;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(89, 75);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(47, 13);
            this.label25.TabIndex = 34;
            this.label25.Text = "Alíquota";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(108, 22);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(28, 13);
            this.label26.TabIndex = 30;
            this.label26.Text = "CST";
            // 
            // cmbCSTCofins
            // 
            this.cmbCSTCofins.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCSTCofins.FormattingEnabled = true;
            this.cmbCSTCofins.Location = new System.Drawing.Point(142, 19);
            this.cmbCSTCofins.Name = "cmbCSTCofins";
            this.cmbCSTCofins.Size = new System.Drawing.Size(612, 21);
            this.cmbCSTCofins.TabIndex = 29;
            this.cmbCSTCofins.SelectedIndexChanged += new System.EventHandler(this.cmbCSTCofins_SelectedIndexChanged);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.chkArquivamentoNFe);
            this.tabPage5.Controls.Add(this.grbArquivamentoNFe);
            this.tabPage5.Controls.Add(this.chkImpressaoDanfe);
            this.tabPage5.Controls.Add(this.grbImpressaoDanfe);
            this.tabPage5.Controls.Add(this.chkEnvioNfeEmail);
            this.tabPage5.Controls.Add(this.grbEnvioNFeEmail);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(776, 404);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Envio/Impressão Automáticos da NFe";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // chkArquivamentoNFe
            // 
            this.chkArquivamentoNFe.AutoSize = true;
            this.chkArquivamentoNFe.Location = new System.Drawing.Point(749, 354);
            this.chkArquivamentoNFe.Name = "chkArquivamentoNFe";
            this.chkArquivamentoNFe.Size = new System.Drawing.Size(15, 14);
            this.chkArquivamentoNFe.TabIndex = 4;
            this.chkArquivamentoNFe.UseVisualStyleBackColor = true;
            this.chkArquivamentoNFe.CheckedChanged += new System.EventHandler(this.chkArquivamentoNFe_CheckedChanged);
            // 
            // grbArquivamentoNFe
            // 
            this.grbArquivamentoNFe.Controls.Add(this.btnPastaDanfe);
            this.grbArquivamentoNFe.Controls.Add(this.txtPastaDanfe);
            this.grbArquivamentoNFe.Controls.Add(this.btnPastaXML);
            this.grbArquivamentoNFe.Controls.Add(this.txtPastaXML);
            this.grbArquivamentoNFe.Controls.Add(this.label34);
            this.grbArquivamentoNFe.Controls.Add(this.label35);
            this.grbArquivamentoNFe.Enabled = false;
            this.grbArquivamentoNFe.Location = new System.Drawing.Point(17, 313);
            this.grbArquivamentoNFe.Name = "grbArquivamentoNFe";
            this.grbArquivamentoNFe.Size = new System.Drawing.Size(726, 85);
            this.grbArquivamentoNFe.TabIndex = 5;
            this.grbArquivamentoNFe.TabStop = false;
            this.grbArquivamentoNFe.Text = "Arquivar NFe";
            // 
            // btnPastaDanfe
            // 
            this.btnPastaDanfe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPastaDanfe.Location = new System.Drawing.Point(685, 48);
            this.btnPastaDanfe.Name = "btnPastaDanfe";
            this.btnPastaDanfe.Size = new System.Drawing.Size(35, 23);
            this.btnPastaDanfe.TabIndex = 42;
            this.btnPastaDanfe.Text = "...";
            this.btnPastaDanfe.UseVisualStyleBackColor = true;
            this.btnPastaDanfe.Click += new System.EventHandler(this.btnPastaDanfe_Click);
            // 
            // txtPastaDanfe
            // 
            this.txtPastaDanfe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPastaDanfe.Enabled = false;
            this.txtPastaDanfe.Location = new System.Drawing.Point(97, 50);
            this.txtPastaDanfe.Name = "txtPastaDanfe";
            this.txtPastaDanfe.Size = new System.Drawing.Size(580, 20);
            this.txtPastaDanfe.TabIndex = 1;
            // 
            // btnPastaXML
            // 
            this.btnPastaXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPastaXML.Location = new System.Drawing.Point(685, 22);
            this.btnPastaXML.Name = "btnPastaXML";
            this.btnPastaXML.Size = new System.Drawing.Size(35, 23);
            this.btnPastaXML.TabIndex = 40;
            this.btnPastaXML.Text = "...";
            this.btnPastaXML.UseVisualStyleBackColor = true;
            this.btnPastaXML.Click += new System.EventHandler(this.btnPastaXML_Click);
            // 
            // txtPastaXML
            // 
            this.txtPastaXML.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPastaXML.Enabled = false;
            this.txtPastaXML.Location = new System.Drawing.Point(97, 24);
            this.txtPastaXML.Name = "txtPastaXML";
            this.txtPastaXML.Size = new System.Drawing.Size(580, 20);
            this.txtPastaXML.TabIndex = 0;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(18, 53);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(73, 13);
            this.label34.TabIndex = 12;
            this.label34.Text = "Pasta DANFE";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(32, 27);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(59, 13);
            this.label35.TabIndex = 10;
            this.label35.Text = "Pasta XML";
            // 
            // chkImpressaoDanfe
            // 
            this.chkImpressaoDanfe.AutoSize = true;
            this.chkImpressaoDanfe.Location = new System.Drawing.Point(749, 256);
            this.chkImpressaoDanfe.Name = "chkImpressaoDanfe";
            this.chkImpressaoDanfe.Size = new System.Drawing.Size(15, 14);
            this.chkImpressaoDanfe.TabIndex = 2;
            this.chkImpressaoDanfe.UseVisualStyleBackColor = true;
            this.chkImpressaoDanfe.CheckedChanged += new System.EventHandler(this.chkImpressaoDanfe_CheckedChanged);
            // 
            // grbImpressaoDanfe
            // 
            this.grbImpressaoDanfe.Controls.Add(this.cmbImpressoraDanfe2);
            this.grbImpressaoDanfe.Controls.Add(this.label33);
            this.grbImpressaoDanfe.Controls.Add(this.cmbImpressoraDanfe1);
            this.grbImpressaoDanfe.Controls.Add(this.label32);
            this.grbImpressaoDanfe.Enabled = false;
            this.grbImpressaoDanfe.Location = new System.Drawing.Point(17, 219);
            this.grbImpressaoDanfe.Name = "grbImpressaoDanfe";
            this.grbImpressaoDanfe.Size = new System.Drawing.Size(726, 88);
            this.grbImpressaoDanfe.TabIndex = 3;
            this.grbImpressaoDanfe.TabStop = false;
            this.grbImpressaoDanfe.Text = "Imprimir DANFE";
            // 
            // cmbImpressoraDanfe2
            // 
            this.cmbImpressoraDanfe2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbImpressoraDanfe2.FormattingEnabled = true;
            this.cmbImpressoraDanfe2.Location = new System.Drawing.Point(86, 51);
            this.cmbImpressoraDanfe2.Name = "cmbImpressoraDanfe2";
            this.cmbImpressoraDanfe2.Size = new System.Drawing.Size(634, 21);
            this.cmbImpressoraDanfe2.TabIndex = 1;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(13, 54);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(67, 13);
            this.label33.TabIndex = 12;
            this.label33.Text = "Impressora 2";
            // 
            // cmbImpressoraDanfe1
            // 
            this.cmbImpressoraDanfe1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbImpressoraDanfe1.FormattingEnabled = true;
            this.cmbImpressoraDanfe1.Location = new System.Drawing.Point(86, 24);
            this.cmbImpressoraDanfe1.Name = "cmbImpressoraDanfe1";
            this.cmbImpressoraDanfe1.Size = new System.Drawing.Size(634, 21);
            this.cmbImpressoraDanfe1.TabIndex = 0;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(13, 27);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(67, 13);
            this.label32.TabIndex = 10;
            this.label32.Text = "Impressora 1";
            // 
            // chkEnvioNfeEmail
            // 
            this.chkEnvioNfeEmail.AutoSize = true;
            this.chkEnvioNfeEmail.Location = new System.Drawing.Point(749, 102);
            this.chkEnvioNfeEmail.Name = "chkEnvioNfeEmail";
            this.chkEnvioNfeEmail.Size = new System.Drawing.Size(15, 14);
            this.chkEnvioNfeEmail.TabIndex = 0;
            this.chkEnvioNfeEmail.UseVisualStyleBackColor = true;
            this.chkEnvioNfeEmail.CheckedChanged += new System.EventHandler(this.chkEnvioNfeEmail_CheckedChanged);
            // 
            // grbEnvioNFeEmail
            // 
            this.grbEnvioNFeEmail.Controls.Add(this.txtEnvioNFeRemetente);
            this.grbEnvioNFeEmail.Controls.Add(this.label8);
            this.grbEnvioNFeEmail.Controls.Add(this.chkEnvioNFeCliente);
            this.grbEnvioNFeEmail.Controls.Add(this.label31);
            this.grbEnvioNFeEmail.Controls.Add(this.txtEnvioDANFEDestino);
            this.grbEnvioNFeEmail.Controls.Add(this.label29);
            this.grbEnvioNFeEmail.Controls.Add(this.chkEnvioDANFE);
            this.grbEnvioNFeEmail.Controls.Add(this.label30);
            this.grbEnvioNFeEmail.Controls.Add(this.txtEnvioXMLDestino);
            this.grbEnvioNFeEmail.Controls.Add(this.label28);
            this.grbEnvioNFeEmail.Controls.Add(this.chkEnvioXML);
            this.grbEnvioNFeEmail.Controls.Add(this.label19);
            this.grbEnvioNFeEmail.Enabled = false;
            this.grbEnvioNFeEmail.Location = new System.Drawing.Point(17, 6);
            this.grbEnvioNFeEmail.Name = "grbEnvioNFeEmail";
            this.grbEnvioNFeEmail.Size = new System.Drawing.Size(726, 207);
            this.grbEnvioNFeEmail.TabIndex = 1;
            this.grbEnvioNFeEmail.TabStop = false;
            this.grbEnvioNFeEmail.Text = "Envio da NFe por Email";
            // 
            // txtEnvioNFeRemetente
            // 
            this.txtEnvioNFeRemetente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEnvioNFeRemetente.Location = new System.Drawing.Point(180, 19);
            this.txtEnvioNFeRemetente.Name = "txtEnvioNFeRemetente";
            this.txtEnvioNFeRemetente.Size = new System.Drawing.Size(540, 20);
            this.txtEnvioNFeRemetente.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(109, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Rementente";
            // 
            // chkEnvioNFeCliente
            // 
            this.chkEnvioNFeCliente.AutoSize = true;
            this.chkEnvioNFeCliente.Location = new System.Drawing.Point(180, 176);
            this.chkEnvioNFeCliente.Name = "chkEnvioNFeCliente";
            this.chkEnvioNFeCliente.Size = new System.Drawing.Size(15, 14);
            this.chkEnvioNFeCliente.TabIndex = 5;
            this.chkEnvioNFeCliente.UseVisualStyleBackColor = true;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(46, 176);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(128, 13);
            this.label31.TabIndex = 8;
            this.label31.Text = "Enviar NFe para o Cliente";
            // 
            // txtEnvioDANFEDestino
            // 
            this.txtEnvioDANFEDestino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEnvioDANFEDestino.Enabled = false;
            this.txtEnvioDANFEDestino.Location = new System.Drawing.Point(180, 137);
            this.txtEnvioDANFEDestino.Name = "txtEnvioDANFEDestino";
            this.txtEnvioDANFEDestino.Size = new System.Drawing.Size(540, 20);
            this.txtEnvioDANFEDestino.TabIndex = 4;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(43, 140);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(131, 13);
            this.label29.TabIndex = 6;
            this.label29.Text = "Endereço Destino DANFE";
            // 
            // chkEnvioDANFE
            // 
            this.chkEnvioDANFE.AutoSize = true;
            this.chkEnvioDANFE.Location = new System.Drawing.Point(180, 120);
            this.chkEnvioDANFE.Name = "chkEnvioDANFE";
            this.chkEnvioDANFE.Size = new System.Drawing.Size(15, 14);
            this.chkEnvioDANFE.TabIndex = 3;
            this.chkEnvioDANFE.UseVisualStyleBackColor = true;
            this.chkEnvioDANFE.CheckedChanged += new System.EventHandler(this.chkEnvioDANFE_CheckedChanged);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(13, 120);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(161, 13);
            this.label30.TabIndex = 4;
            this.label30.Text = "Enviar DANFE Automaticamente";
            // 
            // txtEnvioXMLDestino
            // 
            this.txtEnvioXMLDestino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEnvioXMLDestino.Enabled = false;
            this.txtEnvioXMLDestino.Location = new System.Drawing.Point(180, 82);
            this.txtEnvioXMLDestino.Name = "txtEnvioXMLDestino";
            this.txtEnvioXMLDestino.Size = new System.Drawing.Size(540, 20);
            this.txtEnvioXMLDestino.TabIndex = 2;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(57, 85);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(117, 13);
            this.label28.TabIndex = 2;
            this.label28.Text = "Endereço Destino XML";
            // 
            // chkEnvioXML
            // 
            this.chkEnvioXML.AutoSize = true;
            this.chkEnvioXML.Location = new System.Drawing.Point(180, 65);
            this.chkEnvioXML.Name = "chkEnvioXML";
            this.chkEnvioXML.Size = new System.Drawing.Size(15, 14);
            this.chkEnvioXML.TabIndex = 1;
            this.chkEnvioXML.UseVisualStyleBackColor = true;
            this.chkEnvioXML.CheckedChanged += new System.EventHandler(this.chkEnvioXML_CheckedChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(27, 65);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(147, 13);
            this.label19.TabIndex = 0;
            this.label19.Text = "Enviar XML Automaticamente";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.txtAutorizadoDocumento);
            this.tabPage6.Controls.Add(this.rdbAutorizadosCNPJ);
            this.tabPage6.Controls.Add(this.rdbAutorizadosCPF);
            this.tabPage6.Controls.Add(this.btnAutorizadosExcluir);
            this.tabPage6.Controls.Add(this.btnAutorizadosNovo);
            this.tabPage6.Controls.Add(this.dgvAutorizados);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(776, 404);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Autorização Download NFe";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // txtAutorizadoDocumento
            // 
            this.txtAutorizadoDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAutorizadoDocumento.Location = new System.Drawing.Point(377, 18);
            this.txtAutorizadoDocumento.Name = "txtAutorizadoDocumento";
            this.txtAutorizadoDocumento.Size = new System.Drawing.Size(229, 20);
            this.txtAutorizadoDocumento.TabIndex = 6;
            // 
            // rdbAutorizadosCNPJ
            // 
            this.rdbAutorizadosCNPJ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbAutorizadosCNPJ.AutoSize = true;
            this.rdbAutorizadosCNPJ.BindingField = null;
            this.rdbAutorizadosCNPJ.LiberadoQuandoCadastroUtilizado = false;
            this.rdbAutorizadosCNPJ.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbAutorizadosCNPJ.Location = new System.Drawing.Point(319, 19);
            this.rdbAutorizadosCNPJ.Name = "rdbAutorizadosCNPJ";
            this.rdbAutorizadosCNPJ.Size = new System.Drawing.Size(52, 17);
            this.rdbAutorizadosCNPJ.TabIndex = 5;
            this.rdbAutorizadosCNPJ.TabStop = true;
            this.rdbAutorizadosCNPJ.Text = "CNPJ";
            this.rdbAutorizadosCNPJ.UseVisualStyleBackColor = true;
            this.rdbAutorizadosCNPJ.CheckedChanged += new System.EventHandler(this.rdbAutorizadosCNPJ_CheckedChanged);
            // 
            // rdbAutorizadosCPF
            // 
            this.rdbAutorizadosCPF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbAutorizadosCPF.AutoSize = true;
            this.rdbAutorizadosCPF.BindingField = null;
            this.rdbAutorizadosCPF.Checked = true;
            this.rdbAutorizadosCPF.LiberadoQuandoCadastroUtilizado = false;
            this.rdbAutorizadosCPF.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbAutorizadosCPF.Location = new System.Drawing.Point(268, 19);
            this.rdbAutorizadosCPF.Name = "rdbAutorizadosCPF";
            this.rdbAutorizadosCPF.Size = new System.Drawing.Size(45, 17);
            this.rdbAutorizadosCPF.TabIndex = 4;
            this.rdbAutorizadosCPF.TabStop = true;
            this.rdbAutorizadosCPF.Text = "CPF";
            this.rdbAutorizadosCPF.UseVisualStyleBackColor = true;
            this.rdbAutorizadosCPF.CheckedChanged += new System.EventHandler(this.rdbAutorizadosCPF_CheckedChanged);
            // 
            // btnAutorizadosExcluir
            // 
            this.btnAutorizadosExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAutorizadosExcluir.LiberadoQuandoCadastroUtilizado = false;
            this.btnAutorizadosExcluir.Location = new System.Drawing.Point(693, 16);
            this.btnAutorizadosExcluir.Name = "btnAutorizadosExcluir";
            this.btnAutorizadosExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnAutorizadosExcluir.TabIndex = 3;
            this.btnAutorizadosExcluir.Text = "Excluir";
            this.btnAutorizadosExcluir.UseVisualStyleBackColor = true;
            this.btnAutorizadosExcluir.Click += new System.EventHandler(this.btnAutorizadosExcluir_Click);
            // 
            // btnAutorizadosNovo
            // 
            this.btnAutorizadosNovo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAutorizadosNovo.LiberadoQuandoCadastroUtilizado = false;
            this.btnAutorizadosNovo.Location = new System.Drawing.Point(612, 16);
            this.btnAutorizadosNovo.Name = "btnAutorizadosNovo";
            this.btnAutorizadosNovo.Size = new System.Drawing.Size(75, 23);
            this.btnAutorizadosNovo.TabIndex = 1;
            this.btnAutorizadosNovo.Text = "Incluir";
            this.btnAutorizadosNovo.UseVisualStyleBackColor = true;
            this.btnAutorizadosNovo.Click += new System.EventHandler(this.btnAutorizadosNovo_Click);
            // 
            // dgvAutorizados
            // 
            this.dgvAutorizados.AllowUserToAddRows = false;
            this.dgvAutorizados.AllowUserToDeleteRows = false;
            this.dgvAutorizados.AllowUserToOrderColumns = true;
            this.dgvAutorizados.AllowUserToResizeRows = false;
            this.dgvAutorizados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAutorizados.BackgroundColor = System.Drawing.Color.White;
            this.dgvAutorizados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAutorizados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AutorizadosColumn});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(209)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAutorizados.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAutorizados.Location = new System.Drawing.Point(8, 46);
            this.dgvAutorizados.MultiSelect = false;
            this.dgvAutorizados.Name = "dgvAutorizados";
            this.dgvAutorizados.ReadOnly = true;
            this.dgvAutorizados.RowHeadersVisible = false;
            this.dgvAutorizados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAutorizados.Size = new System.Drawing.Size(760, 352);
            this.dgvAutorizados.TabIndex = 0;
            // 
            // AutorizadosColumn
            // 
            this.AutorizadosColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AutorizadosColumn.DataPropertyName = "DocumentoAutorizado";
            this.AutorizadosColumn.HeaderText = "Documentos Autorizados";
            this.AutorizadosColumn.Name = "AutorizadosColumn";
            this.AutorizadosColumn.ReadOnly = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(12, 17);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.Location = new System.Drawing.Point(697, 17);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 0;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // CadEmitenteForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(784, 491);
            this.Controls.Add(this.splitContainer1);
            this.Name = "CadEmitenteForm";
            this.Text = "Configurações da Emissão de NFe";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.grbCertificado.ResumeLayout(false);
            this.grbCertificado.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.gbxPIS.ResumeLayout(false);
            this.gbxPIS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAliquotaPis)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.gbxCOFINS.ResumeLayout(false);
            this.gbxCOFINS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAliquotaCofins)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.grbArquivamentoNFe.ResumeLayout(false);
            this.grbArquivamentoNFe.PerformLayout();
            this.grbImpressaoDanfe.ResumeLayout(false);
            this.grbImpressaoDanfe.PerformLayout();
            this.grbEnvioNFeEmail.ResumeLayout(false);
            this.grbEnvioNFeEmail.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutorizados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private IWTDotNetLib.IWTEntitySelection ensCidade;
        private MaskedTextBox txtCep;
        private MaskedTextBox txtIM;
        private Label label38;
        private MaskedTextBox txtCNAE;
        private Label label37;
        private Label label36;
        private GroupBox groupBox1;
        private RadioButton rdbNormal;
        private RadioButton rdbSimplesExcesso;
        private RadioButton rdbSimples;
        private MaskedTextBox txtTelefone;
        private MaskedTextBox txtFax;
        private TextBox txtBairro;
        private TextBox txtNomeContato;
        private TextBox txtComplento;
        private TextBox txtNumero;
        private TextBox txtEndereco;
        private TextBox txtIE;
        private TextBox txtCNPJ;
        private TextBox txtEmpresa;
        private Label label15;
        private Label label14;
        private Label label13;
        private Label label10;
        private Label label9;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label3;
        private Label label12;
        private Label label1;
        private TabPage tabPage2;
        private GroupBox grbCertificado;
        private ComboBox cmbCertificados;
        private Label label18;
        private TextBox txtObsPadraoNfe;
        private TextBox txtVersaoEmissor;
        private TextBox txtPathOutNF;
        private Label label11;
        private Label label27;
        private Button btnPath;
        private Label label16;
        private TabPage tabPage3;
        private GroupBox gbxPIS;
        private Label label21;
        private ComboBox cmbModTributPis;
        private CheckBox cbxImpRetidoPis;
        private NumericUpDown nudAliquotaPis;
        private Label label22;
        private Label label23;
        private ComboBox cmbCSTPis;
        private TabPage tabPage4;
        private GroupBox gbxCOFINS;
        private Label label24;
        private ComboBox cmbModTributCofins;
        private CheckBox cbxImpRetidoCofins;
        private NumericUpDown nudAliquotaCofins;
        private Label label25;
        private Label label26;
        private ComboBox cmbCSTCofins;
        private TabPage tabPage5;
        private CheckBox chkArquivamentoNFe;
        private GroupBox grbArquivamentoNFe;
        private Button btnPastaDanfe;
        private TextBox txtPastaDanfe;
        private Button btnPastaXML;
        private TextBox txtPastaXML;
        private Label label34;
        private Label label35;
        private CheckBox chkImpressaoDanfe;
        private GroupBox grbImpressaoDanfe;
        private ComboBox cmbImpressoraDanfe2;
        private Label label33;
        private ComboBox cmbImpressoraDanfe1;
        private Label label32;
        private CheckBox chkEnvioNfeEmail;
        private GroupBox grbEnvioNFeEmail;
        private TextBox txtEnvioNFeRemetente;
        private Label label8;
        private CheckBox chkEnvioNFeCliente;
        private Label label31;
        private TextBox txtEnvioDANFEDestino;
        private Label label29;
        private CheckBox chkEnvioDANFE;
        private Label label30;
        private TextBox txtEnvioXMLDestino;
        private Label label28;
        private CheckBox chkEnvioXML;
        private Label label19;
        private TabPage tabPage6;
        private DataGridView dgvAutorizados;
        private IWTDotNetLib.IWTButton btnAutorizadosExcluir;
        private IWTDotNetLib.IWTButton btnAutorizadosNovo;
        private IWTDotNetLib.IWTRadioButton rdbAutorizadosCNPJ;
        private IWTDotNetLib.IWTRadioButton rdbAutorizadosCPF;
        private MaskedTextBox txtAutorizadoDocumento;
        private DataGridViewTextBoxColumn AutorizadosColumn;
    }
}