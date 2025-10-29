using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    partial class CadProdutoPrecoForm
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
            this.Preco = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.Regra = new IWTDotNetLib.IWTTextBox(this.components);
            this.FimVigencia = new IWTDotNetLib.IWTDateTimePicker(this.components);
            this.Justificativa = new IWTDotNetLib.IWTTextBox(this.components);
            this.label8 = new IWTDotNetLib.IWTLabel(this.components);
            this.label7 = new IWTDotNetLib.IWTLabel(this.components);
            this.lblJustificativa = new IWTDotNetLib.IWTLabel(this.components);
            this.lblUsuario = new IWTDotNetLib.IWTLabel(this.components);
            this.lblDataInicio = new IWTDotNetLib.IWTLabel(this.components);
            this.label5 = new IWTDotNetLib.IWTLabel(this.components);
            this.label4 = new IWTDotNetLib.IWTLabel(this.components);
            this.lblProduto = new IWTDotNetLib.IWTLabel(this.components);
            this.label3 = new IWTDotNetLib.IWTLabel(this.components);
            this.rdbSomarPrecosFilhos = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbRegra = new IWTDotNetLib.IWTRadioButton(this.components);
            this.grbRegra = new System.Windows.Forms.GroupBox();
            this.label2 = new IWTDotNetLib.IWTLabel(this.components);
            this.rdbPrecoFixo = new IWTDotNetLib.IWTRadioButton(this.components);
            this.grbFixo = new System.Windows.Forms.GroupBox();
            this.label1 = new IWTDotNetLib.IWTLabel(this.components);
            this.grbSomarFilhos = new System.Windows.Forms.GroupBox();
            this.rdbTodosFilhosPedidoEstrutura = new IWTDotNetLib.IWTRadioButton(this.components);
            this.dataGridView1 = new IWTDotNetLib.IWTDataGridView(this.components);
            this.SomaPrecoColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ProdutoFilhoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantidadeFilhoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rdbSomenteSelecionados = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbTodosFilhos = new IWTDotNetLib.IWTRadioButton(this.components);
            this.cmsVariaveis = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.variável1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.variável2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.variável3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.variável4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dimensãoDoItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dimensãoDoItemPaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ensProduto = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.pnlRevisao = new System.Windows.Forms.Panel();
            this.pnlNovo = new System.Windows.Forms.Panel();
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel2 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtDateTimePicker1 = new IWTDotNetLib.IWTDateTimePicker(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Preco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FimVigencia)).BeginInit();
            this.grbRegra.SuspendLayout();
            this.grbFixo.SuspendLayout();
            this.grbSomarFilhos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.cmsVariaveis.SuspendLayout();
            this.pnlRevisao.SuspendLayout();
            this.pnlNovo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iwtDateTimePicker1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.pnlNovo);
            this.splitContainer1.Panel1.Controls.Add(this.pnlRevisao);
            this.splitContainer1.Panel1.Controls.Add(this.rdbSomarPrecosFilhos);
            this.splitContainer1.Panel1.Controls.Add(this.rdbRegra);
            this.splitContainer1.Panel1.Controls.Add(this.grbRegra);
            this.splitContainer1.Panel1.Controls.Add(this.rdbPrecoFixo);
            this.splitContainer1.Panel1.Controls.Add(this.grbFixo);
            this.splitContainer1.Panel1.Controls.Add(this.grbSomarFilhos);
            this.splitContainer1.Size = new System.Drawing.Size(581, 637);
            this.splitContainer1.SplitterDistance = 571;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(499, 20);
            // 
            // Preco
            // 
            this.Preco.BindingField = "Preco";
            this.Preco.DecimalPlaces = 4;
            this.Preco.LiberadoQuandoCadastroUtilizado = false;
            this.Preco.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Preco.Location = new System.Drawing.Point(86, 19);
            this.Preco.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.Preco.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.Preco.Name = "Preco";
            this.Preco.Size = new System.Drawing.Size(150, 20);
            this.Preco.TabIndex = 3;
            // 
            // Regra
            // 
            this.Regra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Regra.BindingField = "Regra";
            this.Regra.DebugMode = false;
            this.Regra.LiberadoQuandoCadastroUtilizado = false;
            this.Regra.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Regra.Location = new System.Drawing.Point(48, 19);
            this.Regra.ModoBarcode = false;
            this.Regra.Multiline = true;
            this.Regra.Name = "Regra";
            this.Regra.Size = new System.Drawing.Size(480, 63);
            this.Regra.TabIndex = 5;
            // 
            // FimVigencia
            // 
            this.FimVigencia.BindingField = "FimVigencia";
            this.FimVigencia.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FimVigencia.LiberadoQuandoCadastroUtilizado = false;
            this.FimVigencia.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.FimVigencia.Location = new System.Drawing.Point(151, 73);
            this.FimVigencia.Name = "FimVigencia";
            this.FimVigencia.Size = new System.Drawing.Size(150, 20);
            this.FimVigencia.TabIndex = 9;
            this.FimVigencia.Value = new System.DateTime(2015, 9, 21, 10, 30, 14, 882);
            // 
            // Justificativa
            // 
            this.Justificativa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Justificativa.BindingField = "Justificativa";
            this.Justificativa.DebugMode = false;
            this.Justificativa.LiberadoQuandoCadastroUtilizado = false;
            this.Justificativa.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Justificativa.Location = new System.Drawing.Point(151, 99);
            this.Justificativa.ModoBarcode = false;
            this.Justificativa.Name = "Justificativa";
            this.Justificativa.Size = new System.Drawing.Size(404, 20);
            this.Justificativa.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BindingField = null;
            this.label8.LiberadoQuandoCadastroUtilizado = false;
            this.label8.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label8.Location = new System.Drawing.Point(12, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "Justificativa Nova Revisão";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BindingField = null;
            this.label7.LiberadoQuandoCadastroUtilizado = false;
            this.label7.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label7.Location = new System.Drawing.Point(46, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Data Encerramento";
            // 
            // lblJustificativa
            // 
            this.lblJustificativa.AutoSize = true;
            this.lblJustificativa.BindingField = null;
            this.lblJustificativa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJustificativa.LiberadoQuandoCadastroUtilizado = false;
            this.lblJustificativa.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblJustificativa.Location = new System.Drawing.Point(79, 51);
            this.lblJustificativa.Name = "lblJustificativa";
            this.lblJustificativa.Size = new System.Drawing.Size(0, 13);
            this.lblJustificativa.TabIndex = 31;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.BindingField = "AcsUsuario";
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.LiberadoQuandoCadastroUtilizado = false;
            this.lblUsuario.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblUsuario.Location = new System.Drawing.Point(277, 49);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(0, 13);
            this.lblUsuario.TabIndex = 30;
            // 
            // lblDataInicio
            // 
            this.lblDataInicio.AutoSize = true;
            this.lblDataInicio.BindingField = "InicioVigenciaFormatada";
            this.lblDataInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataInicio.LiberadoQuandoCadastroUtilizado = false;
            this.lblDataInicio.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblDataInicio.Location = new System.Drawing.Point(79, 28);
            this.lblDataInicio.Name = "lblDataInicio";
            this.lblDataInicio.Size = new System.Drawing.Size(0, 13);
            this.lblDataInicio.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BindingField = null;
            this.label5.LiberadoQuandoCadastroUtilizado = false;
            this.label5.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label5.Location = new System.Drawing.Point(186, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Usuário Revisor:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BindingField = null;
            this.label4.LiberadoQuandoCadastroUtilizado = false;
            this.label4.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label4.Location = new System.Drawing.Point(12, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Data Inicio:";
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.BindingField = "Produto";
            this.lblProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduto.LiberadoQuandoCadastroUtilizado = false;
            this.lblProduto.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblProduto.Location = new System.Drawing.Point(79, 6);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(0, 13);
            this.lblProduto.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BindingField = null;
            this.label3.LiberadoQuandoCadastroUtilizado = false;
            this.label3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label3.Location = new System.Drawing.Point(12, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Produto: ";
            // 
            // rdbSomarPrecosFilhos
            // 
            this.rdbSomarPrecosFilhos.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.rdbSomarPrecosFilhos.AutoSize = true;
            this.rdbSomarPrecosFilhos.BindingField = "PrecoSomarFilhos";
            this.rdbSomarPrecosFilhos.LiberadoQuandoCadastroUtilizado = false;
            this.rdbSomarPrecosFilhos.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbSomarPrecosFilhos.Location = new System.Drawing.Point(560, 421);
            this.rdbSomarPrecosFilhos.Name = "rdbSomarPrecosFilhos";
            this.rdbSomarPrecosFilhos.Size = new System.Drawing.Size(14, 13);
            this.rdbSomarPrecosFilhos.TabIndex = 23;
            this.rdbSomarPrecosFilhos.UseVisualStyleBackColor = true;
            this.rdbSomarPrecosFilhos.CheckedChanged += new System.EventHandler(this.rdbSomarPrecosFilhos_CheckedChanged);
            // 
            // rdbRegra
            // 
            this.rdbRegra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbRegra.AutoSize = true;
            this.rdbRegra.BindingField = "PrecoVariavelRegra";
            this.rdbRegra.LiberadoQuandoCadastroUtilizado = false;
            this.rdbRegra.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbRegra.Location = new System.Drawing.Point(557, 237);
            this.rdbRegra.Name = "rdbRegra";
            this.rdbRegra.Size = new System.Drawing.Size(14, 13);
            this.rdbRegra.TabIndex = 20;
            this.rdbRegra.UseVisualStyleBackColor = true;
            this.rdbRegra.CheckedChanged += new System.EventHandler(this.rdbRegra_CheckedChanged);
            // 
            // grbRegra
            // 
            this.grbRegra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbRegra.Controls.Add(this.label2);
            this.grbRegra.Controls.Add(this.Regra);
            this.grbRegra.Enabled = false;
            this.grbRegra.Location = new System.Drawing.Point(12, 195);
            this.grbRegra.Name = "grbRegra";
            this.grbRegra.Size = new System.Drawing.Size(539, 88);
            this.grbRegra.TabIndex = 21;
            this.grbRegra.TabStop = false;
            this.grbRegra.Text = "Preço Variável - Regra de Cálculo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BindingField = null;
            this.label2.LiberadoQuandoCadastroUtilizado = false;
            this.label2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Regra";
            // 
            // rdbPrecoFixo
            // 
            this.rdbPrecoFixo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbPrecoFixo.AutoSize = true;
            this.rdbPrecoFixo.BindingField = "PrecoFixo";
            this.rdbPrecoFixo.Checked = true;
            this.rdbPrecoFixo.LiberadoQuandoCadastroUtilizado = false;
            this.rdbPrecoFixo.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbPrecoFixo.Location = new System.Drawing.Point(557, 157);
            this.rdbPrecoFixo.Name = "rdbPrecoFixo";
            this.rdbPrecoFixo.Size = new System.Drawing.Size(14, 13);
            this.rdbPrecoFixo.TabIndex = 18;
            this.rdbPrecoFixo.TabStop = true;
            this.rdbPrecoFixo.UseVisualStyleBackColor = true;
            this.rdbPrecoFixo.CheckedChanged += new System.EventHandler(this.rdbPrecoFixo_CheckedChanged);
            // 
            // grbFixo
            // 
            this.grbFixo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbFixo.Controls.Add(this.label1);
            this.grbFixo.Controls.Add(this.Preco);
            this.grbFixo.Location = new System.Drawing.Point(12, 133);
            this.grbFixo.Name = "grbFixo";
            this.grbFixo.Size = new System.Drawing.Size(539, 56);
            this.grbFixo.TabIndex = 19;
            this.grbFixo.TabStop = false;
            this.grbFixo.Text = "Preço Fixo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BindingField = null;
            this.label1.LiberadoQuandoCadastroUtilizado = false;
            this.label1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Preço Unitário";
            // 
            // grbSomarFilhos
            // 
            this.grbSomarFilhos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbSomarFilhos.Controls.Add(this.rdbTodosFilhosPedidoEstrutura);
            this.grbSomarFilhos.Controls.Add(this.dataGridView1);
            this.grbSomarFilhos.Controls.Add(this.rdbSomenteSelecionados);
            this.grbSomarFilhos.Controls.Add(this.rdbTodosFilhos);
            this.grbSomarFilhos.Enabled = false;
            this.grbSomarFilhos.Location = new System.Drawing.Point(12, 289);
            this.grbSomarFilhos.Name = "grbSomarFilhos";
            this.grbSomarFilhos.Size = new System.Drawing.Size(539, 279);
            this.grbSomarFilhos.TabIndex = 25;
            this.grbSomarFilhos.TabStop = false;
            this.grbSomarFilhos.Text = "Preço Variável - Somar Preços dos Filhos";
            // 
            // rdbTodosFilhosPedidoEstrutura
            // 
            this.rdbTodosFilhosPedidoEstrutura.AutoSize = true;
            this.rdbTodosFilhosPedidoEstrutura.BindingField = "PrecoVariavelSomaTodosFilhosPedidoEEstrutura";
            this.rdbTodosFilhosPedidoEstrutura.LiberadoQuandoCadastroUtilizado = false;
            this.rdbTodosFilhosPedidoEstrutura.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbTodosFilhosPedidoEstrutura.Location = new System.Drawing.Point(162, 19);
            this.rdbTodosFilhosPedidoEstrutura.Name = "rdbTodosFilhosPedidoEstrutura";
            this.rdbTodosFilhosPedidoEstrutura.Size = new System.Drawing.Size(204, 17);
            this.rdbTodosFilhosPedidoEstrutura.TabIndex = 1;
            this.rdbTodosFilhosPedidoEstrutura.Text = "Todos os Filhos do Pedido e Estrutura";
            this.rdbTodosFilhosPedidoEstrutura.UseVisualStyleBackColor = true;
            this.rdbTodosFilhosPedidoEstrutura.CheckedChanged += new System.EventHandler(this.rdbTodosFilhosPedidoEstrutura_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.CacheDados = null;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SomaPrecoColumn,
            this.ProdutoFilhoColumn,
            this.QuantidadeFilhoColumn});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.None;
            this.dataGridView1.Enabled = false;
            this.dataGridView1.Location = new System.Drawing.Point(6, 42);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(527, 231);
            this.dataGridView1.TabIndex = 3;
            // 
            // SomaPrecoColumn
            // 
            this.SomaPrecoColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SomaPrecoColumn.DataPropertyName = "SomaPreco";
            this.SomaPrecoColumn.HeaderText = "Somar Preço";
            this.SomaPrecoColumn.Name = "SomaPrecoColumn";
            this.SomaPrecoColumn.ReadOnly = true;
            this.SomaPrecoColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SomaPrecoColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ProdutoFilhoColumn
            // 
            this.ProdutoFilhoColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ProdutoFilhoColumn.DataPropertyName = "ProdutoFilho";
            this.ProdutoFilhoColumn.HeaderText = "Item";
            this.ProdutoFilhoColumn.Name = "ProdutoFilhoColumn";
            this.ProdutoFilhoColumn.ReadOnly = true;
            this.ProdutoFilhoColumn.Width = 275;
            // 
            // QuantidadeFilhoColumn
            // 
            this.QuantidadeFilhoColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.QuantidadeFilhoColumn.DataPropertyName = "QuantidadeFilho";
            this.QuantidadeFilhoColumn.HeaderText = "Qtd";
            this.QuantidadeFilhoColumn.Name = "QuantidadeFilhoColumn";
            this.QuantidadeFilhoColumn.ReadOnly = true;
            this.QuantidadeFilhoColumn.Width = 90;
            // 
            // rdbSomenteSelecionados
            // 
            this.rdbSomenteSelecionados.AutoSize = true;
            this.rdbSomenteSelecionados.BindingField = "PrecoVariavelSomaFilhosPedidoSelecionados";
            this.rdbSomenteSelecionados.LiberadoQuandoCadastroUtilizado = false;
            this.rdbSomenteSelecionados.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbSomenteSelecionados.Location = new System.Drawing.Point(372, 19);
            this.rdbSomenteSelecionados.Name = "rdbSomenteSelecionados";
            this.rdbSomenteSelecionados.Size = new System.Drawing.Size(134, 17);
            this.rdbSomenteSelecionados.TabIndex = 2;
            this.rdbSomenteSelecionados.Text = "Somente Selecionados";
            this.rdbSomenteSelecionados.UseVisualStyleBackColor = true;
            this.rdbSomenteSelecionados.CheckedChanged += new System.EventHandler(this.rdbSomenteSelecionados_CheckedChanged);
            // 
            // rdbTodosFilhos
            // 
            this.rdbTodosFilhos.AutoSize = true;
            this.rdbTodosFilhos.BindingField = "PrecoVariavelSomaTodosFilhosPedido";
            this.rdbTodosFilhos.Checked = true;
            this.rdbTodosFilhos.LiberadoQuandoCadastroUtilizado = false;
            this.rdbTodosFilhos.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbTodosFilhos.Location = new System.Drawing.Point(6, 19);
            this.rdbTodosFilhos.Name = "rdbTodosFilhos";
            this.rdbTodosFilhos.Size = new System.Drawing.Size(150, 17);
            this.rdbTodosFilhos.TabIndex = 0;
            this.rdbTodosFilhos.TabStop = true;
            this.rdbTodosFilhos.Text = "Todos os Filhos do Pedido";
            this.rdbTodosFilhos.UseVisualStyleBackColor = true;
            this.rdbTodosFilhos.CheckedChanged += new System.EventHandler(this.rdbTodosFilhos_CheckedChanged);
            // 
            // cmsVariaveis
            // 
            this.cmsVariaveis.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.variável1ToolStripMenuItem,
            this.variável2ToolStripMenuItem,
            this.variável3ToolStripMenuItem,
            this.variável4ToolStripMenuItem,
            this.dimensãoDoItemToolStripMenuItem,
            this.dimensãoDoItemPaiToolStripMenuItem});
            this.cmsVariaveis.Name = "cmsVariaveis";
            this.cmsVariaveis.Size = new System.Drawing.Size(191, 136);
            this.cmsVariaveis.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsVariaveis_ItemClicked);
            // 
            // variável1ToolStripMenuItem
            // 
            this.variável1ToolStripMenuItem.Name = "variável1ToolStripMenuItem";
            this.variável1ToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.variável1ToolStripMenuItem.Text = "Variável 1";
            // 
            // variável2ToolStripMenuItem
            // 
            this.variável2ToolStripMenuItem.Name = "variável2ToolStripMenuItem";
            this.variável2ToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.variável2ToolStripMenuItem.Text = "Variável 2";
            // 
            // variável3ToolStripMenuItem
            // 
            this.variável3ToolStripMenuItem.Name = "variável3ToolStripMenuItem";
            this.variável3ToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.variável3ToolStripMenuItem.Text = "Variável 3";
            // 
            // variável4ToolStripMenuItem
            // 
            this.variável4ToolStripMenuItem.Name = "variável4ToolStripMenuItem";
            this.variável4ToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.variável4ToolStripMenuItem.Text = "Variável 4";
            // 
            // dimensãoDoItemToolStripMenuItem
            // 
            this.dimensãoDoItemToolStripMenuItem.Name = "dimensãoDoItemToolStripMenuItem";
            this.dimensãoDoItemToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.dimensãoDoItemToolStripMenuItem.Text = "Dimensão do Item";
            // 
            // dimensãoDoItemPaiToolStripMenuItem
            // 
            this.dimensãoDoItemPaiToolStripMenuItem.Name = "dimensãoDoItemPaiToolStripMenuItem";
            this.dimensãoDoItemPaiToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.dimensãoDoItemPaiToolStripMenuItem.Text = "Dimensão do Item Pai";
            // 
            // ensProduto
            // 
            this.ensProduto.BindingField = "Produto";
            this.ensProduto.DesabilitarAutoCompletar = false;
            this.ensProduto.DesabilitarChekBox = true;
            this.ensProduto.DesabilitarLupa = false;
            this.ensProduto.DesabilitarSeta = false;
            this.ensProduto.EntidadeSelecionada = null;
            this.ensProduto.FormSelecao = null;
            this.ensProduto.LiberadoQuandoCadastroUtilizado = false;
            this.ensProduto.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensProduto.Location = new System.Drawing.Point(87, 36);
            this.ensProduto.ModoVisualizacaoGrid = null;
            this.ensProduto.Name = "ensProduto";
            this.ensProduto.ParametrosBuscaObrigatorios = null;
            this.ensProduto.Size = new System.Drawing.Size(479, 23);
            this.ensProduto.TabIndex = 34;
            this.ensProduto.Leave += new System.EventHandler(this.ensProduto_Leave);
            // 
            // pnlRevisao
            // 
            this.pnlRevisao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRevisao.Controls.Add(this.label8);
            this.pnlRevisao.Controls.Add(this.Justificativa);
            this.pnlRevisao.Controls.Add(this.label7);
            this.pnlRevisao.Controls.Add(this.FimVigencia);
            this.pnlRevisao.Controls.Add(this.lblJustificativa);
            this.pnlRevisao.Controls.Add(this.label3);
            this.pnlRevisao.Controls.Add(this.lblUsuario);
            this.pnlRevisao.Controls.Add(this.lblProduto);
            this.pnlRevisao.Controls.Add(this.lblDataInicio);
            this.pnlRevisao.Controls.Add(this.label4);
            this.pnlRevisao.Controls.Add(this.label5);
            this.pnlRevisao.Location = new System.Drawing.Point(3, 3);
            this.pnlRevisao.Name = "pnlRevisao";
            this.pnlRevisao.Size = new System.Drawing.Size(575, 124);
            this.pnlRevisao.TabIndex = 35;
            // 
            // pnlNovo
            // 
            this.pnlNovo.Controls.Add(this.iwtLabel2);
            this.pnlNovo.Controls.Add(this.iwtDateTimePicker1);
            this.pnlNovo.Controls.Add(this.iwtLabel1);
            this.pnlNovo.Controls.Add(this.ensProduto);
            this.pnlNovo.Location = new System.Drawing.Point(3, 3);
            this.pnlNovo.Name = "pnlNovo";
            this.pnlNovo.Size = new System.Drawing.Size(575, 124);
            this.pnlNovo.TabIndex = 4;
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(31, 42);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(50, 13);
            this.iwtLabel1.TabIndex = 34;
            this.iwtLabel1.Text = "Produto: ";
            // 
            // iwtLabel2
            // 
            this.iwtLabel2.AutoSize = true;
            this.iwtLabel2.BindingField = null;
            this.iwtLabel2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel2.Location = new System.Drawing.Point(6, 64);
            this.iwtLabel2.Name = "iwtLabel2";
            this.iwtLabel2.Size = new System.Drawing.Size(75, 13);
            this.iwtLabel2.TabIndex = 36;
            this.iwtLabel2.Text = "Data de Início";
            // 
            // iwtDateTimePicker1
            // 
            this.iwtDateTimePicker1.BindingField = "InicioVigencia";
            this.iwtDateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.iwtDateTimePicker1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtDateTimePicker1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtDateTimePicker1.Location = new System.Drawing.Point(87, 60);
            this.iwtDateTimePicker1.Name = "iwtDateTimePicker1";
            this.iwtDateTimePicker1.Size = new System.Drawing.Size(150, 20);
            this.iwtDateTimePicker1.TabIndex = 35;
            this.iwtDateTimePicker1.Value = new System.DateTime(2015, 9, 21, 11, 17, 34, 260);
            // 
            // CadProdutoPrecoForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(581, 637);
            this.Name = "CadProdutoPrecoForm";
            this.Text = "Regra de Preço do Produto";
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Preco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FimVigencia)).EndInit();
            this.grbRegra.ResumeLayout(false);
            this.grbRegra.PerformLayout();
            this.grbFixo.ResumeLayout(false);
            this.grbFixo.PerformLayout();
            this.grbSomarFilhos.ResumeLayout(false);
            this.grbSomarFilhos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.cmsVariaveis.ResumeLayout(false);
            this.pnlRevisao.ResumeLayout(false);
            this.pnlRevisao.PerformLayout();
            this.pnlNovo.ResumeLayout(false);
            this.pnlNovo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iwtDateTimePicker1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IWTDotNetLib.IWTNumericUpDown Preco;
        private IWTDotNetLib.IWTTextBox Regra;
        private IWTDotNetLib.IWTDateTimePicker FimVigencia;
        private IWTDotNetLib.IWTTextBox Justificativa;
        private IWTLabel label8;
        private IWTLabel label7;
        private IWTLabel lblJustificativa;
        private IWTLabel lblUsuario;
        private IWTLabel lblDataInicio;
        private IWTLabel label5;
        private IWTLabel label4;
        private IWTLabel lblProduto;
        private IWTLabel label3;
        private IWTRadioButton rdbSomarPrecosFilhos;
        private IWTRadioButton rdbRegra;
        private System.Windows.Forms.GroupBox grbRegra;
        private IWTLabel label2;
        private IWTRadioButton rdbPrecoFixo;
        private System.Windows.Forms.GroupBox grbFixo;
        private IWTLabel label1;
        private System.Windows.Forms.GroupBox grbSomarFilhos;
        private IWTRadioButton rdbTodosFilhosPedidoEstrutura;
        private IWTRadioButton rdbSomenteSelecionados;
        private IWTRadioButton rdbTodosFilhos;
        private IWTDataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip cmsVariaveis;
        private System.Windows.Forms.ToolStripMenuItem variável1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem variável2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem variável3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem variável4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dimensãoDoItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dimensãoDoItemPaiToolStripMenuItem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SomaPrecoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdutoFilhoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantidadeFilhoColumn;
        private IWTEntitySelection ensProduto;
        private System.Windows.Forms.Panel pnlRevisao;
        private System.Windows.Forms.Panel pnlNovo;
        private IWTLabel iwtLabel2;
        private IWTDateTimePicker iwtDateTimePicker1;
        private IWTLabel iwtLabel1;
    }
} 
