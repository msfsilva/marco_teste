namespace BibliotecaCadastrosBasicos.NovaEstruturaProduto
{
    partial class CadProdutoMaterialFormNew
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
            this.label1 = new System.Windows.Forms.Label();
            this.nudQuantidade = new System.Windows.Forms.NumericUpDown();
            this.btnOk = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtQtdCondicionalRegra = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.rdbQtdCondicional = new System.Windows.Forms.RadioButton();
            this.rdbQtdFixa = new System.Windows.Forms.RadioButton();
            this.chkCondicional = new System.Windows.Forms.CheckBox();
            this.txtRegraCondicional = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lblUnidadeMaterial = new System.Windows.Forms.Label();
            this.grbPlanoCorte = new System.Windows.Forms.GroupBox();
            this.chkDimensao3 = new System.Windows.Forms.CheckBox();
            this.chkDimensao2 = new System.Windows.Forms.CheckBox();
            this.chkDimensao1 = new System.Windows.Forms.CheckBox();
            this.txtPlanoCorteInfoAdd = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbPostoTrabalhoCorte = new IWTDotNetLib.IWTMultiColumnComboBox(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.grbDimensao3 = new System.Windows.Forms.GroupBox();
            this.cmbUnidade3 = new IWTDotNetLib.IWTMultiColumnComboBox(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.txtDimensao3 = new System.Windows.Forms.TextBox();
            this.rdbDimensao3Pai = new System.Windows.Forms.RadioButton();
            this.rdbDimensao3 = new System.Windows.Forms.RadioButton();
            this.cmbDimensao3 = new IWTDotNetLib.IWTMultiColumnComboBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.grbDimensao2 = new System.Windows.Forms.GroupBox();
            this.cmbUnidade2 = new IWTDotNetLib.IWTMultiColumnComboBox(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.txtDimensao2 = new System.Windows.Forms.TextBox();
            this.rdbDimensao2Pai = new System.Windows.Forms.RadioButton();
            this.rdbDimensao2 = new System.Windows.Forms.RadioButton();
            this.cmbDimensao2 = new IWTDotNetLib.IWTMultiColumnComboBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.grbDimensao1 = new System.Windows.Forms.GroupBox();
            this.cmbUnidade1 = new IWTDotNetLib.IWTMultiColumnComboBox(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.txtDimensao1 = new System.Windows.Forms.TextBox();
            this.rdbDimensao1Pai = new System.Windows.Forms.RadioButton();
            this.rdbDimensao1 = new System.Windows.Forms.RadioButton();
            this.cmbDimensao1 = new IWTDotNetLib.IWTMultiColumnComboBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudPlanoCorteQuantidade = new System.Windows.Forms.NumericUpDown();
            this.chkPlanoCorte = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grbPlanoCorte.SuspendLayout();
            this.grbDimensao3.SuspendLayout();
            this.grbDimensao2.SuspendLayout();
            this.grbDimensao1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPlanoCorteQuantidade)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quantidade do Item por Unidade do Pai";
            // 
            // nudQuantidade
            // 
            this.nudQuantidade.DecimalPlaces = 5;
            this.nudQuantidade.Location = new System.Drawing.Point(28, 27);
            this.nudQuantidade.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudQuantidade.Name = "nudQuantidade";
            this.nudQuantidade.Size = new System.Drawing.Size(181, 20);
            this.nudQuantidade.TabIndex = 1;
            this.nudQuantidade.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(515, 18);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
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
            this.splitContainer1.Panel1.Controls.Add(this.txtQtdCondicionalRegra);
            this.splitContainer1.Panel1.Controls.Add(this.label13);
            this.splitContainer1.Panel1.Controls.Add(this.rdbQtdCondicional);
            this.splitContainer1.Panel1.Controls.Add(this.rdbQtdFixa);
            this.splitContainer1.Panel1.Controls.Add(this.chkCondicional);
            this.splitContainer1.Panel1.Controls.Add(this.txtRegraCondicional);
            this.splitContainer1.Panel1.Controls.Add(this.label12);
            this.splitContainer1.Panel1.Controls.Add(this.lblUnidadeMaterial);
            this.splitContainer1.Panel1.Controls.Add(this.grbPlanoCorte);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.nudQuantidade);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnOk);
            this.splitContainer1.Size = new System.Drawing.Size(602, 749);
            this.splitContainer1.SplitterDistance = 681;
            this.splitContainer1.TabIndex = 0;
            // 
            // txtQtdCondicionalRegra
            // 
            this.txtQtdCondicionalRegra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtQtdCondicionalRegra.Enabled = false;
            this.txtQtdCondicionalRegra.Location = new System.Drawing.Point(28, 66);
            this.txtQtdCondicionalRegra.Multiline = true;
            this.txtQtdCondicionalRegra.Name = "txtQtdCondicionalRegra";
            this.txtQtdCondicionalRegra.Size = new System.Drawing.Size(181, 75);
            this.txtQtdCondicionalRegra.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 50);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(120, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "Quantidade Condicional";
            // 
            // rdbQtdCondicional
            // 
            this.rdbQtdCondicional.AutoSize = true;
            this.rdbQtdCondicional.Location = new System.Drawing.Point(215, 69);
            this.rdbQtdCondicional.Name = "rdbQtdCondicional";
            this.rdbQtdCondicional.Size = new System.Drawing.Size(14, 13);
            this.rdbQtdCondicional.TabIndex = 2;
            this.rdbQtdCondicional.UseVisualStyleBackColor = true;
            this.rdbQtdCondicional.CheckedChanged += new System.EventHandler(this.rdbQtdCondicional_CheckedChanged);
            // 
            // rdbQtdFixa
            // 
            this.rdbQtdFixa.AutoSize = true;
            this.rdbQtdFixa.Checked = true;
            this.rdbQtdFixa.Location = new System.Drawing.Point(215, 29);
            this.rdbQtdFixa.Name = "rdbQtdFixa";
            this.rdbQtdFixa.Size = new System.Drawing.Size(14, 13);
            this.rdbQtdFixa.TabIndex = 0;
            this.rdbQtdFixa.TabStop = true;
            this.rdbQtdFixa.UseVisualStyleBackColor = true;
            this.rdbQtdFixa.CheckedChanged += new System.EventHandler(this.rdbQtdFixa_CheckedChanged);
            // 
            // chkCondicional
            // 
            this.chkCondicional.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkCondicional.AutoSize = true;
            this.chkCondicional.Location = new System.Drawing.Point(575, 30);
            this.chkCondicional.Name = "chkCondicional";
            this.chkCondicional.Size = new System.Drawing.Size(15, 14);
            this.chkCondicional.TabIndex = 4;
            this.chkCondicional.UseVisualStyleBackColor = true;
            this.chkCondicional.CheckedChanged += new System.EventHandler(this.chkCondicional_CheckedChanged);
            // 
            // txtRegraCondicional
            // 
            this.txtRegraCondicional.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegraCondicional.Enabled = false;
            this.txtRegraCondicional.Location = new System.Drawing.Point(269, 27);
            this.txtRegraCondicional.Multiline = true;
            this.txtRegraCondicional.Name = "txtRegraCondicional";
            this.txtRegraCondicional.Size = new System.Drawing.Size(300, 114);
            this.txtRegraCondicional.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(266, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(105, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Inclusão Condicional";
            // 
            // lblUnidadeMaterial
            // 
            this.lblUnidadeMaterial.AutoSize = true;
            this.lblUnidadeMaterial.Location = new System.Drawing.Point(215, 29);
            this.lblUnidadeMaterial.Name = "lblUnidadeMaterial";
            this.lblUnidadeMaterial.Size = new System.Drawing.Size(0, 13);
            this.lblUnidadeMaterial.TabIndex = 2;
            // 
            // grbPlanoCorte
            // 
            this.grbPlanoCorte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbPlanoCorte.Controls.Add(this.chkDimensao3);
            this.grbPlanoCorte.Controls.Add(this.chkDimensao2);
            this.grbPlanoCorte.Controls.Add(this.chkDimensao1);
            this.grbPlanoCorte.Controls.Add(this.txtPlanoCorteInfoAdd);
            this.grbPlanoCorte.Controls.Add(this.label8);
            this.grbPlanoCorte.Controls.Add(this.cmbPostoTrabalhoCorte);
            this.grbPlanoCorte.Controls.Add(this.label7);
            this.grbPlanoCorte.Controls.Add(this.grbDimensao3);
            this.grbPlanoCorte.Controls.Add(this.grbDimensao2);
            this.grbPlanoCorte.Controls.Add(this.grbDimensao1);
            this.grbPlanoCorte.Controls.Add(this.label3);
            this.grbPlanoCorte.Controls.Add(this.nudPlanoCorteQuantidade);
            this.grbPlanoCorte.Controls.Add(this.chkPlanoCorte);
            this.grbPlanoCorte.Controls.Add(this.label2);
            this.grbPlanoCorte.Location = new System.Drawing.Point(3, 147);
            this.grbPlanoCorte.Name = "grbPlanoCorte";
            this.grbPlanoCorte.Size = new System.Drawing.Size(596, 531);
            this.grbPlanoCorte.TabIndex = 6;
            this.grbPlanoCorte.TabStop = false;
            this.grbPlanoCorte.Text = "Plano de Corte";
            // 
            // chkDimensao3
            // 
            this.chkDimensao3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDimensao3.AutoSize = true;
            this.chkDimensao3.Location = new System.Drawing.Point(572, 376);
            this.chkDimensao3.Name = "chkDimensao3";
            this.chkDimensao3.Size = new System.Drawing.Size(15, 14);
            this.chkDimensao3.TabIndex = 7;
            this.chkDimensao3.UseVisualStyleBackColor = true;
            this.chkDimensao3.CheckedChanged += new System.EventHandler(this.chkDimensao3_CheckedChanged);
            // 
            // chkDimensao2
            // 
            this.chkDimensao2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDimensao2.AutoSize = true;
            this.chkDimensao2.Location = new System.Drawing.Point(572, 264);
            this.chkDimensao2.Name = "chkDimensao2";
            this.chkDimensao2.Size = new System.Drawing.Size(15, 14);
            this.chkDimensao2.TabIndex = 5;
            this.chkDimensao2.UseVisualStyleBackColor = true;
            this.chkDimensao2.CheckedChanged += new System.EventHandler(this.chkDimensao2_CheckedChanged);
            // 
            // chkDimensao1
            // 
            this.chkDimensao1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDimensao1.AutoSize = true;
            this.chkDimensao1.Checked = true;
            this.chkDimensao1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDimensao1.Location = new System.Drawing.Point(572, 152);
            this.chkDimensao1.Name = "chkDimensao1";
            this.chkDimensao1.Size = new System.Drawing.Size(15, 14);
            this.chkDimensao1.TabIndex = 3;
            this.chkDimensao1.UseVisualStyleBackColor = true;
            this.chkDimensao1.CheckedChanged += new System.EventHandler(this.chkDimensao1_CheckedChanged);
            // 
            // txtPlanoCorteInfoAdd
            // 
            this.txtPlanoCorteInfoAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlanoCorteInfoAdd.Enabled = false;
            this.txtPlanoCorteInfoAdd.Location = new System.Drawing.Point(15, 456);
            this.txtPlanoCorteInfoAdd.Multiline = true;
            this.txtPlanoCorteInfoAdd.Name = "txtPlanoCorteInfoAdd";
            this.txtPlanoCorteInfoAdd.Size = new System.Drawing.Size(551, 70);
            this.txtPlanoCorteInfoAdd.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 440);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Informações Adicionais";
            // 
            // cmbPostoTrabalhoCorte
            // 
            this.cmbPostoTrabalhoCorte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPostoTrabalhoCorte.BindingField = null;
            this.cmbPostoTrabalhoCorte.ColumnsToDisplay = null;
            this.cmbPostoTrabalhoCorte.DisableAutoSelectOnEmpty = false;
            this.cmbPostoTrabalhoCorte.DropDownHeight = 1;
            this.cmbPostoTrabalhoCorte.Enabled = false;
            this.cmbPostoTrabalhoCorte.FormattingEnabled = true;
            this.cmbPostoTrabalhoCorte.IntegralHeight = false;
            this.cmbPostoTrabalhoCorte.LiberadoQuandoCadastroUtilizado = false;
            this.cmbPostoTrabalhoCorte.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.cmbPostoTrabalhoCorte.Location = new System.Drawing.Point(224, 74);
            this.cmbPostoTrabalhoCorte.Name = "cmbPostoTrabalhoCorte";
            this.cmbPostoTrabalhoCorte.SelectedRow = null;
            this.cmbPostoTrabalhoCorte.Size = new System.Drawing.Size(319, 21);
            this.cmbPostoTrabalhoCorte.TabIndex = 2;
            this.cmbPostoTrabalhoCorte.Table = null;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(85, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Posto de trabalho do Corte";
            // 
            // grbDimensao3
            // 
            this.grbDimensao3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbDimensao3.Controls.Add(this.cmbUnidade3);
            this.grbDimensao3.Controls.Add(this.label9);
            this.grbDimensao3.Controls.Add(this.txtDimensao3);
            this.grbDimensao3.Controls.Add(this.rdbDimensao3Pai);
            this.grbDimensao3.Controls.Add(this.rdbDimensao3);
            this.grbDimensao3.Controls.Add(this.cmbDimensao3);
            this.grbDimensao3.Controls.Add(this.label6);
            this.grbDimensao3.Enabled = false;
            this.grbDimensao3.Location = new System.Drawing.Point(15, 325);
            this.grbDimensao3.Name = "grbDimensao3";
            this.grbDimensao3.Size = new System.Drawing.Size(551, 106);
            this.grbDimensao3.TabIndex = 8;
            this.grbDimensao3.TabStop = false;
            this.grbDimensao3.Text = "Dimensão 3";
            // 
            // cmbUnidade3
            // 
            this.cmbUnidade3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbUnidade3.BindingField = null;
            this.cmbUnidade3.ColumnsToDisplay = null;
            this.cmbUnidade3.DisableAutoSelectOnEmpty = false;
            this.cmbUnidade3.DropDownHeight = 1;
            this.cmbUnidade3.Enabled = false;
            this.cmbUnidade3.FormattingEnabled = true;
            this.cmbUnidade3.IntegralHeight = false;
            this.cmbUnidade3.LiberadoQuandoCadastroUtilizado = false;
            this.cmbUnidade3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.cmbUnidade3.Location = new System.Drawing.Point(67, 77);
            this.cmbUnidade3.Name = "cmbUnidade3";
            this.cmbUnidade3.SelectedRow = null;
            this.cmbUnidade3.Size = new System.Drawing.Size(461, 21);
            this.cmbUnidade3.TabIndex = 4;
            this.cmbUnidade3.Table = null;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Unidade";
            // 
            // txtDimensao3
            // 
            this.txtDimensao3.Enabled = false;
            this.txtDimensao3.Location = new System.Drawing.Point(162, 51);
            this.txtDimensao3.Name = "txtDimensao3";
            this.txtDimensao3.Size = new System.Drawing.Size(100, 20);
            this.txtDimensao3.TabIndex = 2;
            // 
            // rdbDimensao3Pai
            // 
            this.rdbDimensao3Pai.AutoSize = true;
            this.rdbDimensao3Pai.Enabled = false;
            this.rdbDimensao3Pai.Location = new System.Drawing.Point(308, 52);
            this.rdbDimensao3Pai.Name = "rdbDimensao3Pai";
            this.rdbDimensao3Pai.Size = new System.Drawing.Size(128, 17);
            this.rdbDimensao3Pai.TabIndex = 3;
            this.rdbDimensao3Pai.Text = "Dimensão do Item Pai";
            this.rdbDimensao3Pai.UseVisualStyleBackColor = true;
            this.rdbDimensao3Pai.CheckedChanged += new System.EventHandler(this.rdbDimensao3Pai_CheckedChanged);
            // 
            // rdbDimensao3
            // 
            this.rdbDimensao3.AutoSize = true;
            this.rdbDimensao3.Checked = true;
            this.rdbDimensao3.Enabled = false;
            this.rdbDimensao3.Location = new System.Drawing.Point(67, 52);
            this.rdbDimensao3.Name = "rdbDimensao3";
            this.rdbDimensao3.Size = new System.Drawing.Size(99, 17);
            this.rdbDimensao3.TabIndex = 1;
            this.rdbDimensao3.TabStop = true;
            this.rdbDimensao3.Text = "Valor Dimensão";
            this.rdbDimensao3.UseVisualStyleBackColor = true;
            this.rdbDimensao3.CheckedChanged += new System.EventHandler(this.rdbDimensao3_CheckedChanged);
            // 
            // cmbDimensao3
            // 
            this.cmbDimensao3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDimensao3.BindingField = null;
            this.cmbDimensao3.ColumnsToDisplay = null;
            this.cmbDimensao3.DisableAutoSelectOnEmpty = false;
            this.cmbDimensao3.DropDownHeight = 1;
            this.cmbDimensao3.Enabled = false;
            this.cmbDimensao3.FormattingEnabled = true;
            this.cmbDimensao3.IntegralHeight = false;
            this.cmbDimensao3.LiberadoQuandoCadastroUtilizado = false;
            this.cmbDimensao3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.cmbDimensao3.Location = new System.Drawing.Point(67, 23);
            this.cmbDimensao3.Name = "cmbDimensao3";
            this.cmbDimensao3.SelectedRow = null;
            this.cmbDimensao3.Size = new System.Drawing.Size(461, 21);
            this.cmbDimensao3.TabIndex = 0;
            this.cmbDimensao3.Table = null;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Dimensão";
            // 
            // grbDimensao2
            // 
            this.grbDimensao2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbDimensao2.Controls.Add(this.cmbUnidade2);
            this.grbDimensao2.Controls.Add(this.label10);
            this.grbDimensao2.Controls.Add(this.txtDimensao2);
            this.grbDimensao2.Controls.Add(this.rdbDimensao2Pai);
            this.grbDimensao2.Controls.Add(this.rdbDimensao2);
            this.grbDimensao2.Controls.Add(this.cmbDimensao2);
            this.grbDimensao2.Controls.Add(this.label5);
            this.grbDimensao2.Enabled = false;
            this.grbDimensao2.Location = new System.Drawing.Point(15, 213);
            this.grbDimensao2.Name = "grbDimensao2";
            this.grbDimensao2.Size = new System.Drawing.Size(551, 106);
            this.grbDimensao2.TabIndex = 6;
            this.grbDimensao2.TabStop = false;
            this.grbDimensao2.Text = "Dimensão 2";
            // 
            // cmbUnidade2
            // 
            this.cmbUnidade2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbUnidade2.BindingField = null;
            this.cmbUnidade2.ColumnsToDisplay = null;
            this.cmbUnidade2.DisableAutoSelectOnEmpty = false;
            this.cmbUnidade2.DropDownHeight = 1;
            this.cmbUnidade2.Enabled = false;
            this.cmbUnidade2.FormattingEnabled = true;
            this.cmbUnidade2.IntegralHeight = false;
            this.cmbUnidade2.LiberadoQuandoCadastroUtilizado = false;
            this.cmbUnidade2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.cmbUnidade2.Location = new System.Drawing.Point(67, 77);
            this.cmbUnidade2.Name = "cmbUnidade2";
            this.cmbUnidade2.SelectedRow = null;
            this.cmbUnidade2.Size = new System.Drawing.Size(461, 21);
            this.cmbUnidade2.TabIndex = 4;
            this.cmbUnidade2.Table = null;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Unidade";
            // 
            // txtDimensao2
            // 
            this.txtDimensao2.Enabled = false;
            this.txtDimensao2.Location = new System.Drawing.Point(162, 51);
            this.txtDimensao2.Name = "txtDimensao2";
            this.txtDimensao2.Size = new System.Drawing.Size(100, 20);
            this.txtDimensao2.TabIndex = 2;
            // 
            // rdbDimensao2Pai
            // 
            this.rdbDimensao2Pai.AutoSize = true;
            this.rdbDimensao2Pai.Enabled = false;
            this.rdbDimensao2Pai.Location = new System.Drawing.Point(308, 52);
            this.rdbDimensao2Pai.Name = "rdbDimensao2Pai";
            this.rdbDimensao2Pai.Size = new System.Drawing.Size(128, 17);
            this.rdbDimensao2Pai.TabIndex = 3;
            this.rdbDimensao2Pai.Text = "Dimensão do Item Pai";
            this.rdbDimensao2Pai.UseVisualStyleBackColor = true;
            this.rdbDimensao2Pai.CheckedChanged += new System.EventHandler(this.rdbDimensao2Pai_CheckedChanged);
            // 
            // rdbDimensao2
            // 
            this.rdbDimensao2.AutoSize = true;
            this.rdbDimensao2.Checked = true;
            this.rdbDimensao2.Enabled = false;
            this.rdbDimensao2.Location = new System.Drawing.Point(67, 52);
            this.rdbDimensao2.Name = "rdbDimensao2";
            this.rdbDimensao2.Size = new System.Drawing.Size(99, 17);
            this.rdbDimensao2.TabIndex = 1;
            this.rdbDimensao2.TabStop = true;
            this.rdbDimensao2.Text = "Valor Dimensão";
            this.rdbDimensao2.UseVisualStyleBackColor = true;
            this.rdbDimensao2.CheckedChanged += new System.EventHandler(this.rdbDimensao2_CheckedChanged);
            // 
            // cmbDimensao2
            // 
            this.cmbDimensao2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDimensao2.BindingField = null;
            this.cmbDimensao2.ColumnsToDisplay = null;
            this.cmbDimensao2.DisableAutoSelectOnEmpty = false;
            this.cmbDimensao2.DropDownHeight = 1;
            this.cmbDimensao2.Enabled = false;
            this.cmbDimensao2.FormattingEnabled = true;
            this.cmbDimensao2.IntegralHeight = false;
            this.cmbDimensao2.LiberadoQuandoCadastroUtilizado = false;
            this.cmbDimensao2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.cmbDimensao2.Location = new System.Drawing.Point(67, 23);
            this.cmbDimensao2.Name = "cmbDimensao2";
            this.cmbDimensao2.SelectedRow = null;
            this.cmbDimensao2.Size = new System.Drawing.Size(461, 21);
            this.cmbDimensao2.TabIndex = 0;
            this.cmbDimensao2.Table = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Dimensão";
            // 
            // grbDimensao1
            // 
            this.grbDimensao1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbDimensao1.Controls.Add(this.cmbUnidade1);
            this.grbDimensao1.Controls.Add(this.label11);
            this.grbDimensao1.Controls.Add(this.txtDimensao1);
            this.grbDimensao1.Controls.Add(this.rdbDimensao1Pai);
            this.grbDimensao1.Controls.Add(this.rdbDimensao1);
            this.grbDimensao1.Controls.Add(this.cmbDimensao1);
            this.grbDimensao1.Controls.Add(this.label4);
            this.grbDimensao1.Location = new System.Drawing.Point(15, 101);
            this.grbDimensao1.Name = "grbDimensao1";
            this.grbDimensao1.Size = new System.Drawing.Size(551, 106);
            this.grbDimensao1.TabIndex = 4;
            this.grbDimensao1.TabStop = false;
            this.grbDimensao1.Text = "Dimensão 1";
            // 
            // cmbUnidade1
            // 
            this.cmbUnidade1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbUnidade1.BindingField = null;
            this.cmbUnidade1.ColumnsToDisplay = null;
            this.cmbUnidade1.DisableAutoSelectOnEmpty = false;
            this.cmbUnidade1.DropDownHeight = 1;
            this.cmbUnidade1.Enabled = false;
            this.cmbUnidade1.FormattingEnabled = true;
            this.cmbUnidade1.IntegralHeight = false;
            this.cmbUnidade1.LiberadoQuandoCadastroUtilizado = false;
            this.cmbUnidade1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.cmbUnidade1.Location = new System.Drawing.Point(67, 77);
            this.cmbUnidade1.Name = "cmbUnidade1";
            this.cmbUnidade1.SelectedRow = null;
            this.cmbUnidade1.Size = new System.Drawing.Size(461, 21);
            this.cmbUnidade1.TabIndex = 5;
            this.cmbUnidade1.Table = null;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Unidade";
            // 
            // txtDimensao1
            // 
            this.txtDimensao1.Enabled = false;
            this.txtDimensao1.Location = new System.Drawing.Point(162, 51);
            this.txtDimensao1.Name = "txtDimensao1";
            this.txtDimensao1.Size = new System.Drawing.Size(100, 20);
            this.txtDimensao1.TabIndex = 3;
            // 
            // rdbDimensao1Pai
            // 
            this.rdbDimensao1Pai.AutoSize = true;
            this.rdbDimensao1Pai.Enabled = false;
            this.rdbDimensao1Pai.Location = new System.Drawing.Point(308, 52);
            this.rdbDimensao1Pai.Name = "rdbDimensao1Pai";
            this.rdbDimensao1Pai.Size = new System.Drawing.Size(128, 17);
            this.rdbDimensao1Pai.TabIndex = 4;
            this.rdbDimensao1Pai.Text = "Dimensão do Item Pai";
            this.rdbDimensao1Pai.UseVisualStyleBackColor = true;
            this.rdbDimensao1Pai.CheckedChanged += new System.EventHandler(this.rdbDimensao1Pai_CheckedChanged);
            // 
            // rdbDimensao1
            // 
            this.rdbDimensao1.AutoSize = true;
            this.rdbDimensao1.Checked = true;
            this.rdbDimensao1.Enabled = false;
            this.rdbDimensao1.Location = new System.Drawing.Point(67, 52);
            this.rdbDimensao1.Name = "rdbDimensao1";
            this.rdbDimensao1.Size = new System.Drawing.Size(99, 17);
            this.rdbDimensao1.TabIndex = 2;
            this.rdbDimensao1.TabStop = true;
            this.rdbDimensao1.Text = "Valor Dimensão";
            this.rdbDimensao1.UseVisualStyleBackColor = true;
            this.rdbDimensao1.CheckedChanged += new System.EventHandler(this.rdbDimensao1_CheckedChanged);
            // 
            // cmbDimensao1
            // 
            this.cmbDimensao1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDimensao1.BindingField = null;
            this.cmbDimensao1.ColumnsToDisplay = null;
            this.cmbDimensao1.DisableAutoSelectOnEmpty = false;
            this.cmbDimensao1.DropDownHeight = 1;
            this.cmbDimensao1.Enabled = false;
            this.cmbDimensao1.FormattingEnabled = true;
            this.cmbDimensao1.IntegralHeight = false;
            this.cmbDimensao1.LiberadoQuandoCadastroUtilizado = false;
            this.cmbDimensao1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.cmbDimensao1.Location = new System.Drawing.Point(67, 23);
            this.cmbDimensao1.Name = "cmbDimensao1";
            this.cmbDimensao1.SelectedRow = null;
            this.cmbDimensao1.Size = new System.Drawing.Size(461, 21);
            this.cmbDimensao1.TabIndex = 0;
            this.cmbDimensao1.Table = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Dimensão";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(204, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Quantidade de Cortes por Unidade do Pai";
            // 
            // nudPlanoCorteQuantidade
            // 
            this.nudPlanoCorteQuantidade.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudPlanoCorteQuantidade.DecimalPlaces = 5;
            this.nudPlanoCorteQuantidade.Enabled = false;
            this.nudPlanoCorteQuantidade.Location = new System.Drawing.Point(224, 48);
            this.nudPlanoCorteQuantidade.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudPlanoCorteQuantidade.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            327680});
            this.nudPlanoCorteQuantidade.Name = "nudPlanoCorteQuantidade";
            this.nudPlanoCorteQuantidade.Size = new System.Drawing.Size(319, 20);
            this.nudPlanoCorteQuantidade.TabIndex = 1;
            this.nudPlanoCorteQuantidade.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chkPlanoCorte
            // 
            this.chkPlanoCorte.AutoSize = true;
            this.chkPlanoCorte.Location = new System.Drawing.Point(224, 28);
            this.chkPlanoCorte.Name = "chkPlanoCorte";
            this.chkPlanoCorte.Size = new System.Drawing.Size(15, 14);
            this.chkPlanoCorte.TabIndex = 0;
            this.chkPlanoCorte.UseVisualStyleBackColor = true;
            this.chkPlanoCorte.CheckedChanged += new System.EventHandler(this.chkPlanoCorte_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Possui Plano de Corte";
            // 
            // CadProdutoMaterialFormNew
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(602, 749);
            this.Controls.Add(this.splitContainer1);
            this.Name = "CadProdutoMaterialFormNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quantidade";
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidade)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grbPlanoCorte.ResumeLayout(false);
            this.grbPlanoCorte.PerformLayout();
            this.grbDimensao3.ResumeLayout(false);
            this.grbDimensao3.PerformLayout();
            this.grbDimensao2.ResumeLayout(false);
            this.grbDimensao2.PerformLayout();
            this.grbDimensao1.ResumeLayout(false);
            this.grbDimensao1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPlanoCorteQuantidade)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudQuantidade;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grbPlanoCorte;
        private System.Windows.Forms.CheckBox chkPlanoCorte;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudPlanoCorteQuantidade;
        private IWTDotNetLib.IWTMultiColumnComboBox cmbDimensao1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdbDimensao1Pai;
        private System.Windows.Forms.RadioButton rdbDimensao1;
        private System.Windows.Forms.GroupBox grbDimensao3;
        private System.Windows.Forms.TextBox txtDimensao3;
        private System.Windows.Forms.RadioButton rdbDimensao3Pai;
        private System.Windows.Forms.RadioButton rdbDimensao3;
        private IWTDotNetLib.IWTMultiColumnComboBox cmbDimensao3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox grbDimensao2;
        private System.Windows.Forms.TextBox txtDimensao2;
        private System.Windows.Forms.RadioButton rdbDimensao2Pai;
        private System.Windows.Forms.RadioButton rdbDimensao2;
        private IWTDotNetLib.IWTMultiColumnComboBox cmbDimensao2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDimensao1;
        private IWTDotNetLib.IWTMultiColumnComboBox cmbPostoTrabalhoCorte;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPlanoCorteInfoAdd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkDimensao3;
        private System.Windows.Forms.CheckBox chkDimensao2;
        private System.Windows.Forms.CheckBox chkDimensao1;
        private System.Windows.Forms.GroupBox grbDimensao1;
        private IWTDotNetLib.IWTMultiColumnComboBox cmbUnidade3;
        private System.Windows.Forms.Label label9;
        private IWTDotNetLib.IWTMultiColumnComboBox cmbUnidade2;
        private System.Windows.Forms.Label label10;
        private IWTDotNetLib.IWTMultiColumnComboBox cmbUnidade1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblUnidadeMaterial;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chkCondicional;
        private System.Windows.Forms.TextBox txtRegraCondicional;
        private System.Windows.Forms.RadioButton rdbQtdFixa;
        private System.Windows.Forms.TextBox txtQtdCondicionalRegra;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RadioButton rdbQtdCondicional;
    }
}