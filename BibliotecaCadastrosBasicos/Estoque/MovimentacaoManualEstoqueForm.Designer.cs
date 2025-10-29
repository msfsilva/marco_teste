namespace BibliotecaCadastrosBasicos.Estoque
{
    partial class MovimentacaoManualEstoqueForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.rdbEpi = new System.Windows.Forms.RadioButton();
            this.rdbProdutoK = new System.Windows.Forms.RadioButton();
            this.lblSelecionado = new System.Windows.Forms.Label();
            this.lblSelecionadoTitulo = new System.Windows.Forms.Label();
            this.rdbDocumento = new System.Windows.Forms.RadioButton();
            this.rdbRecurso = new System.Windows.Forms.RadioButton();
            this.rdbProduto = new System.Windows.Forms.RadioButton();
            this.rdbMaterial = new System.Windows.Forms.RadioButton();
            this.spcEstoque = new System.Windows.Forms.SplitContainer();
            this.dgvEstoquesLocalizados = new System.Windows.Forms.DataGridView();
            this.lblUnidadeMedida = new System.Windows.Forms.Label();
            this.btnExcluirGaveta = new System.Windows.Forms.Button();
            this.btnHistorico = new System.Windows.Forms.Button();
            this.btnTrocarGaveta = new System.Windows.Forms.Button();
            this.btnNovaGaveta = new System.Windows.Forms.Button();
            this.nudQuantidade = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.txtJustificativa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblQtdEstoqueSelecionado = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblQtdTotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.spcBuscas = new System.Windows.Forms.SplitContainer();
            this.dgvEpi = new System.Windows.Forms.DataGridView();
            this.dgvProdutoK = new System.Windows.Forms.DataGridView();
            this.dgvProduto = new System.Windows.Forms.DataGridView();
            this.dgvMaterial = new System.Windows.Forms.DataGridView();
            this.dgvDocumento = new System.Windows.Forms.DataGridView();
            this.dgvRecurso = new System.Windows.Forms.DataGridView();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.timerBusca = new System.Windows.Forms.Timer(this.components);
            this.btnHistoricoMovimentacaoCompleto = new IWTDotNetLib.IWTButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcEstoque)).BeginInit();
            this.spcEstoque.Panel1.SuspendLayout();
            this.spcEstoque.Panel2.SuspendLayout();
            this.spcEstoque.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstoquesLocalizados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spcBuscas)).BeginInit();
            this.spcBuscas.Panel1.SuspendLayout();
            this.spcBuscas.Panel2.SuspendLayout();
            this.spcBuscas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEpi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutoK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecurso)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnSair);
            this.splitContainer1.Panel2.Controls.Add(this.btnAlterar);
            this.splitContainer1.Size = new System.Drawing.Size(927, 528);
            this.splitContainer1.SplitterDistance = 466;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.rdbEpi);
            this.splitContainer2.Panel1.Controls.Add(this.rdbProdutoK);
            this.splitContainer2.Panel1.Controls.Add(this.lblSelecionado);
            this.splitContainer2.Panel1.Controls.Add(this.lblSelecionadoTitulo);
            this.splitContainer2.Panel1.Controls.Add(this.rdbDocumento);
            this.splitContainer2.Panel1.Controls.Add(this.rdbRecurso);
            this.splitContainer2.Panel1.Controls.Add(this.rdbProduto);
            this.splitContainer2.Panel1.Controls.Add(this.rdbMaterial);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.spcBuscas);
            this.splitContainer2.Panel2.Controls.Add(this.spcEstoque);
            this.splitContainer2.Size = new System.Drawing.Size(927, 466);
            this.splitContainer2.SplitterDistance = 53;
            this.splitContainer2.TabIndex = 0;
            // 
            // rdbEpi
            // 
            this.rdbEpi.AutoSize = true;
            this.rdbEpi.Location = new System.Drawing.Point(506, 12);
            this.rdbEpi.Name = "rdbEpi";
            this.rdbEpi.Size = new System.Drawing.Size(40, 17);
            this.rdbEpi.TabIndex = 6;
            this.rdbEpi.Text = "Epi";
            this.rdbEpi.UseVisualStyleBackColor = true;
            this.rdbEpi.CheckedChanged += new System.EventHandler(this.rdbEpi_CheckedChanged);
            // 
            // rdbProdutoK
            // 
            this.rdbProdutoK.AutoSize = true;
            this.rdbProdutoK.Location = new System.Drawing.Point(156, 12);
            this.rdbProdutoK.Name = "rdbProdutoK";
            this.rdbProdutoK.Size = new System.Drawing.Size(177, 17);
            this.rdbProdutoK.TabIndex = 2;
            this.rdbProdutoK.Text = "Kanban de Itens Manufaturados";
            this.rdbProdutoK.UseVisualStyleBackColor = true;
            this.rdbProdutoK.CheckedChanged += new System.EventHandler(this.rdbProdutoK_CheckedChanged);
            // 
            // lblSelecionado
            // 
            this.lblSelecionado.AutoSize = true;
            this.lblSelecionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelecionado.Location = new System.Drawing.Point(79, 32);
            this.lblSelecionado.Name = "lblSelecionado";
            this.lblSelecionado.Size = new System.Drawing.Size(0, 13);
            this.lblSelecionado.TabIndex = 5;
            // 
            // lblSelecionadoTitulo
            // 
            this.lblSelecionadoTitulo.AutoSize = true;
            this.lblSelecionadoTitulo.Location = new System.Drawing.Point(12, 32);
            this.lblSelecionadoTitulo.Name = "lblSelecionadoTitulo";
            this.lblSelecionadoTitulo.Size = new System.Drawing.Size(72, 13);
            this.lblSelecionadoTitulo.TabIndex = 4;
            this.lblSelecionadoTitulo.Text = "Selecionado: ";
            // 
            // rdbDocumento
            // 
            this.rdbDocumento.AutoSize = true;
            this.rdbDocumento.Location = new System.Drawing.Point(420, 12);
            this.rdbDocumento.Name = "rdbDocumento";
            this.rdbDocumento.Size = new System.Drawing.Size(80, 17);
            this.rdbDocumento.TabIndex = 4;
            this.rdbDocumento.Text = "Documento";
            this.rdbDocumento.UseVisualStyleBackColor = true;
            this.rdbDocumento.CheckedChanged += new System.EventHandler(this.rdbDocumento_CheckedChanged);
            // 
            // rdbRecurso
            // 
            this.rdbRecurso.AutoSize = true;
            this.rdbRecurso.Location = new System.Drawing.Point(345, 12);
            this.rdbRecurso.Name = "rdbRecurso";
            this.rdbRecurso.Size = new System.Drawing.Size(65, 17);
            this.rdbRecurso.TabIndex = 3;
            this.rdbRecurso.Text = "Recurso";
            this.rdbRecurso.UseVisualStyleBackColor = true;
            this.rdbRecurso.CheckedChanged += new System.EventHandler(this.rdbRecurso_CheckedChanged);
            // 
            // rdbProduto
            // 
            this.rdbProduto.AutoSize = true;
            this.rdbProduto.Location = new System.Drawing.Point(84, 12);
            this.rdbProduto.Name = "rdbProduto";
            this.rdbProduto.Size = new System.Drawing.Size(62, 17);
            this.rdbProduto.TabIndex = 1;
            this.rdbProduto.Text = "Produto";
            this.rdbProduto.UseVisualStyleBackColor = true;
            this.rdbProduto.CheckedChanged += new System.EventHandler(this.rdbProduto_CheckedChanged);
            // 
            // rdbMaterial
            // 
            this.rdbMaterial.AutoSize = true;
            this.rdbMaterial.Checked = true;
            this.rdbMaterial.Location = new System.Drawing.Point(12, 12);
            this.rdbMaterial.Name = "rdbMaterial";
            this.rdbMaterial.Size = new System.Drawing.Size(62, 17);
            this.rdbMaterial.TabIndex = 0;
            this.rdbMaterial.TabStop = true;
            this.rdbMaterial.Text = "Material";
            this.rdbMaterial.UseVisualStyleBackColor = true;
            this.rdbMaterial.CheckedChanged += new System.EventHandler(this.rdbMaterial_CheckedChanged);
            // 
            // spcEstoque
            // 
            this.spcEstoque.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcEstoque.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.spcEstoque.Location = new System.Drawing.Point(0, 0);
            this.spcEstoque.Name = "spcEstoque";
            this.spcEstoque.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcEstoque.Panel1
            // 
            this.spcEstoque.Panel1.Controls.Add(this.dgvEstoquesLocalizados);
            // 
            // spcEstoque.Panel2
            // 
            this.spcEstoque.Panel2.Controls.Add(this.lblUnidadeMedida);
            this.spcEstoque.Panel2.Controls.Add(this.btnExcluirGaveta);
            this.spcEstoque.Panel2.Controls.Add(this.btnHistorico);
            this.spcEstoque.Panel2.Controls.Add(this.btnTrocarGaveta);
            this.spcEstoque.Panel2.Controls.Add(this.btnNovaGaveta);
            this.spcEstoque.Panel2.Controls.Add(this.nudQuantidade);
            this.spcEstoque.Panel2.Controls.Add(this.label5);
            this.spcEstoque.Panel2.Controls.Add(this.txtJustificativa);
            this.spcEstoque.Panel2.Controls.Add(this.label3);
            this.spcEstoque.Panel2.Controls.Add(this.lblQtdEstoqueSelecionado);
            this.spcEstoque.Panel2.Controls.Add(this.label4);
            this.spcEstoque.Panel2.Controls.Add(this.lblQtdTotal);
            this.spcEstoque.Panel2.Controls.Add(this.label2);
            this.spcEstoque.Size = new System.Drawing.Size(927, 409);
            this.spcEstoque.SplitterDistance = 254;
            this.spcEstoque.TabIndex = 2;
            // 
            // dgvEstoquesLocalizados
            // 
            this.dgvEstoquesLocalizados.AllowUserToAddRows = false;
            this.dgvEstoquesLocalizados.AllowUserToDeleteRows = false;
            this.dgvEstoquesLocalizados.AllowUserToOrderColumns = true;
            this.dgvEstoquesLocalizados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstoquesLocalizados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEstoquesLocalizados.Location = new System.Drawing.Point(0, 0);
            this.dgvEstoquesLocalizados.Name = "dgvEstoquesLocalizados";
            this.dgvEstoquesLocalizados.ReadOnly = true;
            this.dgvEstoquesLocalizados.Size = new System.Drawing.Size(927, 254);
            this.dgvEstoquesLocalizados.TabIndex = 0;
            this.dgvEstoquesLocalizados.Visible = false;
            this.dgvEstoquesLocalizados.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvEstoquesLocalizados_CellMouseDoubleClick);
            this.dgvEstoquesLocalizados.SelectionChanged += new System.EventHandler(this.dgvEstoquesLocalizados_SelectionChanged);
            // 
            // lblUnidadeMedida
            // 
            this.lblUnidadeMedida.AutoSize = true;
            this.lblUnidadeMedida.Location = new System.Drawing.Point(297, 117);
            this.lblUnidadeMedida.Name = "lblUnidadeMedida";
            this.lblUnidadeMedida.Size = new System.Drawing.Size(0, 13);
            this.lblUnidadeMedida.TabIndex = 7;
            // 
            // btnExcluirGaveta
            // 
            this.btnExcluirGaveta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcluirGaveta.Location = new System.Drawing.Point(742, 97);
            this.btnExcluirGaveta.Name = "btnExcluirGaveta";
            this.btnExcluirGaveta.Size = new System.Drawing.Size(173, 23);
            this.btnExcluirGaveta.TabIndex = 4;
            this.btnExcluirGaveta.Text = "Excluir da Gaveta";
            this.btnExcluirGaveta.UseVisualStyleBackColor = true;
            this.btnExcluirGaveta.Click += new System.EventHandler(this.btnExcluirGaveta_Click);
            // 
            // btnHistorico
            // 
            this.btnHistorico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistorico.Location = new System.Drawing.Point(742, 123);
            this.btnHistorico.Name = "btnHistorico";
            this.btnHistorico.Size = new System.Drawing.Size(173, 23);
            this.btnHistorico.TabIndex = 5;
            this.btnHistorico.Text = "Histórico de Movimentação";
            this.btnHistorico.UseVisualStyleBackColor = true;
            this.btnHistorico.Click += new System.EventHandler(this.btnHistorico_Click);
            // 
            // btnTrocarGaveta
            // 
            this.btnTrocarGaveta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTrocarGaveta.Location = new System.Drawing.Point(742, 71);
            this.btnTrocarGaveta.Name = "btnTrocarGaveta";
            this.btnTrocarGaveta.Size = new System.Drawing.Size(173, 23);
            this.btnTrocarGaveta.TabIndex = 3;
            this.btnTrocarGaveta.Text = "Trocar de Gaveta";
            this.btnTrocarGaveta.UseVisualStyleBackColor = true;
            this.btnTrocarGaveta.Click += new System.EventHandler(this.btnTrocarGaveta_Click);
            // 
            // btnNovaGaveta
            // 
            this.btnNovaGaveta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNovaGaveta.Location = new System.Drawing.Point(742, 45);
            this.btnNovaGaveta.Name = "btnNovaGaveta";
            this.btnNovaGaveta.Size = new System.Drawing.Size(173, 23);
            this.btnNovaGaveta.TabIndex = 2;
            this.btnNovaGaveta.Text = "Incluir em Nova Gaveta";
            this.btnNovaGaveta.UseVisualStyleBackColor = true;
            this.btnNovaGaveta.Click += new System.EventHandler(this.btnNovaGaveta_Click);
            // 
            // nudQuantidade
            // 
            this.nudQuantidade.DecimalPlaces = 4;
            this.nudQuantidade.Enabled = false;
            this.nudQuantidade.Location = new System.Drawing.Point(171, 115);
            this.nudQuantidade.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudQuantidade.Minimum = new decimal(new int[] {
            1215752192,
            23,
            0,
            -2147483648});
            this.nudQuantidade.Name = "nudQuantidade";
            this.nudQuantidade.Size = new System.Drawing.Size(120, 20);
            this.nudQuantidade.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Nova Quantidade na Gaveta";
            // 
            // txtJustificativa
            // 
            this.txtJustificativa.Enabled = false;
            this.txtJustificativa.Location = new System.Drawing.Point(16, 30);
            this.txtJustificativa.Multiline = true;
            this.txtJustificativa.Name = "txtJustificativa";
            this.txtJustificativa.Size = new System.Drawing.Size(367, 68);
            this.txtJustificativa.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Justificativa do Ajuste";
            // 
            // lblQtdEstoqueSelecionado
            // 
            this.lblQtdEstoqueSelecionado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQtdEstoqueSelecionado.AutoSize = true;
            this.lblQtdEstoqueSelecionado.Location = new System.Drawing.Point(872, 26);
            this.lblQtdEstoqueSelecionado.Name = "lblQtdEstoqueSelecionado";
            this.lblQtdEstoqueSelecionado.Size = new System.Drawing.Size(0, 13);
            this.lblQtdEstoqueSelecionado.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(739, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Qtd Gaveta Selecionada:";
            // 
            // lblQtdTotal
            // 
            this.lblQtdTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQtdTotal.AutoSize = true;
            this.lblQtdTotal.Location = new System.Drawing.Point(872, 7);
            this.lblQtdTotal.Name = "lblQtdTotal";
            this.lblQtdTotal.Size = new System.Drawing.Size(0, 13);
            this.lblQtdTotal.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(770, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Qtd Total Estoque:";
            // 
            // spcBuscas
            // 
            this.spcBuscas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcBuscas.Location = new System.Drawing.Point(0, 0);
            this.spcBuscas.Name = "spcBuscas";
            this.spcBuscas.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcBuscas.Panel1
            // 
            this.spcBuscas.Panel1.Controls.Add(this.dgvEpi);
            this.spcBuscas.Panel1.Controls.Add(this.dgvProdutoK);
            this.spcBuscas.Panel1.Controls.Add(this.dgvProduto);
            this.spcBuscas.Panel1.Controls.Add(this.dgvMaterial);
            this.spcBuscas.Panel1.Controls.Add(this.dgvDocumento);
            this.spcBuscas.Panel1.Controls.Add(this.dgvRecurso);
            // 
            // spcBuscas.Panel2
            // 
            this.spcBuscas.Panel2.Controls.Add(this.btnHistoricoMovimentacaoCompleto);
            this.spcBuscas.Panel2.Controls.Add(this.txtBusca);
            this.spcBuscas.Panel2.Controls.Add(this.label1);
            this.spcBuscas.Size = new System.Drawing.Size(927, 409);
            this.spcBuscas.SplitterDistance = 348;
            this.spcBuscas.TabIndex = 1;
            // 
            // dgvEpi
            // 
            this.dgvEpi.AllowUserToAddRows = false;
            this.dgvEpi.AllowUserToDeleteRows = false;
            this.dgvEpi.AllowUserToOrderColumns = true;
            this.dgvEpi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEpi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEpi.Location = new System.Drawing.Point(0, 0);
            this.dgvEpi.Name = "dgvEpi";
            this.dgvEpi.ReadOnly = true;
            this.dgvEpi.Size = new System.Drawing.Size(927, 348);
            this.dgvEpi.TabIndex = 5;
            // 
            // dgvProdutoK
            // 
            this.dgvProdutoK.AllowUserToAddRows = false;
            this.dgvProdutoK.AllowUserToDeleteRows = false;
            this.dgvProdutoK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutoK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProdutoK.Location = new System.Drawing.Point(0, 0);
            this.dgvProdutoK.MultiSelect = false;
            this.dgvProdutoK.Name = "dgvProdutoK";
            this.dgvProdutoK.ReadOnly = true;
            this.dgvProdutoK.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdutoK.Size = new System.Drawing.Size(927, 348);
            this.dgvProdutoK.TabIndex = 4;
            this.dgvProdutoK.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvProdutoK_CellMouseDoubleClick);
            // 
            // dgvProduto
            // 
            this.dgvProduto.AllowUserToAddRows = false;
            this.dgvProduto.AllowUserToDeleteRows = false;
            this.dgvProduto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProduto.Location = new System.Drawing.Point(0, 0);
            this.dgvProduto.MultiSelect = false;
            this.dgvProduto.Name = "dgvProduto";
            this.dgvProduto.ReadOnly = true;
            this.dgvProduto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProduto.Size = new System.Drawing.Size(927, 348);
            this.dgvProduto.TabIndex = 1;
            this.dgvProduto.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvProduto_CellMouseDoubleClick);
            // 
            // dgvMaterial
            // 
            this.dgvMaterial.AllowUserToAddRows = false;
            this.dgvMaterial.AllowUserToDeleteRows = false;
            this.dgvMaterial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMaterial.Location = new System.Drawing.Point(0, 0);
            this.dgvMaterial.MultiSelect = false;
            this.dgvMaterial.Name = "dgvMaterial";
            this.dgvMaterial.ReadOnly = true;
            this.dgvMaterial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMaterial.Size = new System.Drawing.Size(927, 348);
            this.dgvMaterial.TabIndex = 0;
            this.dgvMaterial.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvMaterial_CellMouseDoubleClick);
            // 
            // dgvDocumento
            // 
            this.dgvDocumento.AllowUserToAddRows = false;
            this.dgvDocumento.AllowUserToDeleteRows = false;
            this.dgvDocumento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocumento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocumento.Location = new System.Drawing.Point(0, 0);
            this.dgvDocumento.MultiSelect = false;
            this.dgvDocumento.Name = "dgvDocumento";
            this.dgvDocumento.ReadOnly = true;
            this.dgvDocumento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocumento.Size = new System.Drawing.Size(927, 348);
            this.dgvDocumento.TabIndex = 3;
            this.dgvDocumento.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDocumento_CellMouseDoubleClick);
            // 
            // dgvRecurso
            // 
            this.dgvRecurso.AllowUserToAddRows = false;
            this.dgvRecurso.AllowUserToDeleteRows = false;
            this.dgvRecurso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecurso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecurso.Location = new System.Drawing.Point(0, 0);
            this.dgvRecurso.MultiSelect = false;
            this.dgvRecurso.Name = "dgvRecurso";
            this.dgvRecurso.ReadOnly = true;
            this.dgvRecurso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecurso.Size = new System.Drawing.Size(927, 348);
            this.dgvRecurso.TabIndex = 2;
            this.dgvRecurso.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvRecurso_CellMouseDoubleClick);
            // 
            // txtBusca
            // 
            this.txtBusca.Location = new System.Drawing.Point(68, 20);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(327, 20);
            this.txtBusca.TabIndex = 1;
            this.txtBusca.TextChanged += new System.EventHandler(this.txtBusca_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Busca";
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(12, 18);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(75, 23);
            this.btnSair.TabIndex = 1;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlterar.Location = new System.Drawing.Point(840, 18);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(75, 23);
            this.btnAlterar.TabIndex = 0;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // timerBusca
            // 
            this.timerBusca.Interval = 500;
            this.timerBusca.Tick += new System.EventHandler(this.timerBusca_Tick);
            // 
            // btnHistoricoMovimentacaoCompleto
            // 
            this.btnHistoricoMovimentacaoCompleto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistoricoMovimentacaoCompleto.LiberadoQuandoCadastroUtilizado = false;
            this.btnHistoricoMovimentacaoCompleto.Location = new System.Drawing.Point(700, 20);
            this.btnHistoricoMovimentacaoCompleto.Name = "btnHistoricoMovimentacaoCompleto";
            this.btnHistoricoMovimentacaoCompleto.Size = new System.Drawing.Size(215, 23);
            this.btnHistoricoMovimentacaoCompleto.TabIndex = 2;
            this.btnHistoricoMovimentacaoCompleto.Text = "Histórico de Movimentação Completo";
            this.btnHistoricoMovimentacaoCompleto.UseVisualStyleBackColor = true;
            this.btnHistoricoMovimentacaoCompleto.Click += new System.EventHandler(this.btnHistoricoMovimentacaoCompleto_Click);
            // 
            // MovimentacaoManualEstoqueForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(927, 528);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MovimentacaoManualEstoqueForm";
            this.Text = "Movimentação Manual de Estoque";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.spcEstoque.Panel1.ResumeLayout(false);
            this.spcEstoque.Panel2.ResumeLayout(false);
            this.spcEstoque.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcEstoque)).EndInit();
            this.spcEstoque.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstoquesLocalizados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidade)).EndInit();
            this.spcBuscas.Panel1.ResumeLayout(false);
            this.spcBuscas.Panel2.ResumeLayout(false);
            this.spcBuscas.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcBuscas)).EndInit();
            this.spcBuscas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEpi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutoK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecurso)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.RadioButton rdbDocumento;
        private System.Windows.Forms.RadioButton rdbRecurso;
        private System.Windows.Forms.RadioButton rdbProduto;
        private System.Windows.Forms.RadioButton rdbMaterial;
        private System.Windows.Forms.DataGridView dgvEstoquesLocalizados;
        private System.Windows.Forms.SplitContainer spcBuscas;
        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timerBusca;
        private System.Windows.Forms.DataGridView dgvProduto;
        private System.Windows.Forms.DataGridView dgvMaterial;
        private System.Windows.Forms.DataGridView dgvDocumento;
        private System.Windows.Forms.DataGridView dgvRecurso;
        private System.Windows.Forms.SplitContainer spcEstoque;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudQuantidade;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtJustificativa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblQtdEstoqueSelecionado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblQtdTotal;
        private System.Windows.Forms.Label lblSelecionado;
        private System.Windows.Forms.Label lblSelecionadoTitulo;
        private System.Windows.Forms.Button btnNovaGaveta;
        private System.Windows.Forms.Button btnTrocarGaveta;
        private System.Windows.Forms.Button btnHistorico;
        private System.Windows.Forms.Button btnExcluirGaveta;
        private System.Windows.Forms.RadioButton rdbProdutoK;
        private System.Windows.Forms.DataGridView dgvProdutoK;
        private System.Windows.Forms.RadioButton rdbEpi;
        private System.Windows.Forms.DataGridView dgvEpi;
        private System.Windows.Forms.Label lblUnidadeMedida;
        private IWTDotNetLib.IWTButton btnHistoricoMovimentacaoCompleto;
    }
}