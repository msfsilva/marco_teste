namespace BibliotecaCadastrosBasicos 
{ 
    partial class CadKanbanAcionamentoListForm 
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
            this.iwtSearchPanel1 = new IWTDotNetLib.IWTSearchPanel();
            this.chkDataAcionamento = new IWTDotNetLib.IWTCheckBox(this.components);
            this.rdbEncerrados = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbEmAberto = new IWTDotNetLib.IWTRadioButton(this.components);
            this.grbDataAcionamento = new System.Windows.Forms.GroupBox();
            this.iwtLabel3 = new IWTDotNetLib.IWTLabel(this.components);
            this.DataAcionamentoAte = new IWTDotNetLib.IWTDateTimePicker(this.components);
            this.iwtLabel2 = new IWTDotNetLib.IWTLabel(this.components);
            this.DataAcionamentoDe = new IWTDotNetLib.IWTDateTimePicker(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.iwtRadioButton9 = new IWTDotNetLib.IWTRadioButton(this.components);
            this.iwtRadioButton8 = new IWTDotNetLib.IWTRadioButton(this.components);
            this.iwtRadioButton7 = new IWTDotNetLib.IWTRadioButton(this.components);
            this.iwtRadioButton6 = new IWTDotNetLib.IWTRadioButton(this.components);
            this.iwtRadioButton5 = new IWTDotNetLib.IWTRadioButton(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.iwtRadioButton4 = new IWTDotNetLib.IWTRadioButton(this.components);
            this.iwtRadioButton3 = new IWTDotNetLib.IWTRadioButton(this.components);
            this.iwtRadioButton2 = new IWTDotNetLib.IWTRadioButton(this.components);
            this.iwtRadioButton1 = new IWTDotNetLib.IWTRadioButton(this.components);
            this.iwtTextBox1 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtDataGridView1 = new IWTDotNetLib.IWTDataGridView(this.components);
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoEntidadeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdentificacaoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescricaoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DimensaoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataAcionamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AcsUsuarioAcionamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Encerrado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.RetiradaManual = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DataRetirada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AcsUsuarioRetirada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EntidadeRetiradaAutomatica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRetirarAviso = new IWTDotNetLib.IWTButton(this.components);
            this.lnkAtualizar = new IWTDotNetLib.IWTLinkLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.iwtSearchPanel1.SuspendLayout();
            this.grbDataAcionamento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataAcionamentoAte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataAcionamentoDe)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iwtDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Location = new System.Drawing.Point(0, 381);
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.iwtSearchPanel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lnkAtualizar);
            this.splitContainer2.Panel2.Controls.Add(this.btnRetirarAviso);
            this.splitContainer2.Size = new System.Drawing.Size(1011, 99);
            this.splitContainer2.SplitterDistance = 851;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.iwtDataGridView1);
            this.panel1.Size = new System.Drawing.Size(1011, 347);
            this.panel1.Controls.SetChildIndex(this.iwtDataGridView1, 0);
            // 
            // iwtSearchPanel1
            // 
            this.iwtSearchPanel1.Controls.Add(this.chkDataAcionamento);
            this.iwtSearchPanel1.Controls.Add(this.rdbEncerrados);
            this.iwtSearchPanel1.Controls.Add(this.rdbEmAberto);
            this.iwtSearchPanel1.Controls.Add(this.grbDataAcionamento);
            this.iwtSearchPanel1.Controls.Add(this.groupBox2);
            this.iwtSearchPanel1.Controls.Add(this.groupBox1);
            this.iwtSearchPanel1.Controls.Add(this.iwtTextBox1);
            this.iwtSearchPanel1.Controls.Add(this.iwtLabel1);
            this.iwtSearchPanel1.Location = new System.Drawing.Point(0, 0);
            this.iwtSearchPanel1.Name = "iwtSearchPanel1";
            this.iwtSearchPanel1.ParametrosBuscaIniciais = null;
            this.iwtSearchPanel1.Size = new System.Drawing.Size(851, 99);
            this.iwtSearchPanel1.TabIndex = 0;
            // 
            // chkDataAcionamento
            // 
            this.chkDataAcionamento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDataAcionamento.AutoSize = true;
            this.chkDataAcionamento.BindingField = null;
            this.chkDataAcionamento.LiberadoQuandoCadastroUtilizado = false;
            this.chkDataAcionamento.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkDataAcionamento.Location = new System.Drawing.Point(835, 33);
            this.chkDataAcionamento.Name = "chkDataAcionamento";
            this.chkDataAcionamento.Size = new System.Drawing.Size(15, 14);
            this.chkDataAcionamento.TabIndex = 6;
            this.chkDataAcionamento.UseVisualStyleBackColor = true;
            this.chkDataAcionamento.CheckedChanged += new System.EventHandler(this.chkDataAcionamento_CheckedChanged);
            // 
            // rdbEncerrados
            // 
            this.rdbEncerrados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbEncerrados.AutoSize = true;
            this.rdbEncerrados.BindingField = "Encerrado";
            this.rdbEncerrados.LiberadoQuandoCadastroUtilizado = false;
            this.rdbEncerrados.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbEncerrados.Location = new System.Drawing.Point(761, 75);
            this.rdbEncerrados.Name = "rdbEncerrados";
            this.rdbEncerrados.Size = new System.Drawing.Size(79, 17);
            this.rdbEncerrados.TabIndex = 5;
            this.rdbEncerrados.Text = "Encerrados";
            this.rdbEncerrados.UseVisualStyleBackColor = true;
            // 
            // rdbEmAberto
            // 
            this.rdbEmAberto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbEmAberto.AutoSize = true;
            this.rdbEmAberto.BindingField = null;
            this.rdbEmAberto.Checked = true;
            this.rdbEmAberto.LiberadoQuandoCadastroUtilizado = false;
            this.rdbEmAberto.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbEmAberto.Location = new System.Drawing.Point(681, 75);
            this.rdbEmAberto.Name = "rdbEmAberto";
            this.rdbEmAberto.Size = new System.Drawing.Size(74, 17);
            this.rdbEmAberto.TabIndex = 4;
            this.rdbEmAberto.TabStop = true;
            this.rdbEmAberto.Text = "Em Aberto";
            this.rdbEmAberto.UseVisualStyleBackColor = true;
            // 
            // grbDataAcionamento
            // 
            this.grbDataAcionamento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.grbDataAcionamento.Controls.Add(this.iwtLabel3);
            this.grbDataAcionamento.Controls.Add(this.DataAcionamentoAte);
            this.grbDataAcionamento.Controls.Add(this.iwtLabel2);
            this.grbDataAcionamento.Controls.Add(this.DataAcionamentoDe);
            this.grbDataAcionamento.Enabled = false;
            this.grbDataAcionamento.Location = new System.Drawing.Point(681, 0);
            this.grbDataAcionamento.Name = "grbDataAcionamento";
            this.grbDataAcionamento.Size = new System.Drawing.Size(145, 69);
            this.grbDataAcionamento.TabIndex = 3;
            this.grbDataAcionamento.TabStop = false;
            this.grbDataAcionamento.Text = "Data de Entrada do Aviso";
            // 
            // iwtLabel3
            // 
            this.iwtLabel3.AutoSize = true;
            this.iwtLabel3.BindingField = null;
            this.iwtLabel3.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel3.Location = new System.Drawing.Point(4, 47);
            this.iwtLabel3.Name = "iwtLabel3";
            this.iwtLabel3.Size = new System.Drawing.Size(23, 13);
            this.iwtLabel3.TabIndex = 3;
            this.iwtLabel3.Text = "Até";
            // 
            // DataAcionamentoAte
            // 
            this.DataAcionamentoAte.BindingField = "DataAcionamentoAte";
            this.DataAcionamentoAte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DataAcionamentoAte.LiberadoQuandoCadastroUtilizado = false;
            this.DataAcionamentoAte.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.DataAcionamentoAte.Location = new System.Drawing.Point(31, 45);
            this.DataAcionamentoAte.Name = "DataAcionamentoAte";
            this.DataAcionamentoAte.Size = new System.Drawing.Size(107, 20);
            this.DataAcionamentoAte.TabIndex = 2;
            this.DataAcionamentoAte.Value = new System.DateTime(2021, 2, 1, 15, 26, 46, 141);
            // 
            // iwtLabel2
            // 
            this.iwtLabel2.AutoSize = true;
            this.iwtLabel2.BindingField = null;
            this.iwtLabel2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel2.Location = new System.Drawing.Point(6, 21);
            this.iwtLabel2.Name = "iwtLabel2";
            this.iwtLabel2.Size = new System.Drawing.Size(21, 13);
            this.iwtLabel2.TabIndex = 1;
            this.iwtLabel2.Text = "De";
            // 
            // DataAcionamentoDe
            // 
            this.DataAcionamentoDe.BindingField = "DataAcionamentoDe";
            this.DataAcionamentoDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DataAcionamentoDe.LiberadoQuandoCadastroUtilizado = false;
            this.DataAcionamentoDe.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.DataAcionamentoDe.Location = new System.Drawing.Point(31, 19);
            this.DataAcionamentoDe.Name = "DataAcionamentoDe";
            this.DataAcionamentoDe.Size = new System.Drawing.Size(107, 20);
            this.DataAcionamentoDe.TabIndex = 0;
            this.DataAcionamentoDe.Value = new System.DateTime(2021, 2, 1, 15, 26, 46, 145);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.iwtRadioButton9);
            this.groupBox2.Controls.Add(this.iwtRadioButton8);
            this.groupBox2.Controls.Add(this.iwtRadioButton7);
            this.groupBox2.Controls.Add(this.iwtRadioButton6);
            this.groupBox2.Controls.Add(this.iwtRadioButton5);
            this.groupBox2.Location = new System.Drawing.Point(478, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(197, 96);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo";
            // 
            // iwtRadioButton9
            // 
            this.iwtRadioButton9.AutoSize = true;
            this.iwtRadioButton9.BindingField = null;
            this.iwtRadioButton9.Checked = true;
            this.iwtRadioButton9.LiberadoQuandoCadastroUtilizado = false;
            this.iwtRadioButton9.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtRadioButton9.Location = new System.Drawing.Point(6, 65);
            this.iwtRadioButton9.Name = "iwtRadioButton9";
            this.iwtRadioButton9.Size = new System.Drawing.Size(55, 17);
            this.iwtRadioButton9.TabIndex = 4;
            this.iwtRadioButton9.TabStop = true;
            this.iwtRadioButton9.Text = "Todos";
            this.iwtRadioButton9.UseVisualStyleBackColor = true;
            // 
            // iwtRadioButton8
            // 
            this.iwtRadioButton8.AutoSize = true;
            this.iwtRadioButton8.BindingField = "TipoItemProdutoK";
            this.iwtRadioButton8.LiberadoQuandoCadastroUtilizado = false;
            this.iwtRadioButton8.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtRadioButton8.Location = new System.Drawing.Point(81, 42);
            this.iwtRadioButton8.Name = "iwtRadioButton8";
            this.iwtRadioButton8.Size = new System.Drawing.Size(113, 17);
            this.iwtRadioButton8.TabIndex = 3;
            this.iwtRadioButton8.Text = "KB Manufaturados";
            this.iwtRadioButton8.UseVisualStyleBackColor = true;
            // 
            // iwtRadioButton7
            // 
            this.iwtRadioButton7.AutoSize = true;
            this.iwtRadioButton7.BindingField = "TipoItemEpi";
            this.iwtRadioButton7.LiberadoQuandoCadastroUtilizado = false;
            this.iwtRadioButton7.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtRadioButton7.Location = new System.Drawing.Point(6, 42);
            this.iwtRadioButton7.Name = "iwtRadioButton7";
            this.iwtRadioButton7.Size = new System.Drawing.Size(40, 17);
            this.iwtRadioButton7.TabIndex = 2;
            this.iwtRadioButton7.Text = "Epi";
            this.iwtRadioButton7.UseVisualStyleBackColor = true;
            // 
            // iwtRadioButton6
            // 
            this.iwtRadioButton6.AutoSize = true;
            this.iwtRadioButton6.BindingField = "TipoItemProduto";
            this.iwtRadioButton6.LiberadoQuandoCadastroUtilizado = false;
            this.iwtRadioButton6.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtRadioButton6.Location = new System.Drawing.Point(81, 19);
            this.iwtRadioButton6.Name = "iwtRadioButton6";
            this.iwtRadioButton6.Size = new System.Drawing.Size(62, 17);
            this.iwtRadioButton6.TabIndex = 1;
            this.iwtRadioButton6.Text = "Produto";
            this.iwtRadioButton6.UseVisualStyleBackColor = true;
            // 
            // iwtRadioButton5
            // 
            this.iwtRadioButton5.AutoSize = true;
            this.iwtRadioButton5.BindingField = "TipoItemMaterial";
            this.iwtRadioButton5.LiberadoQuandoCadastroUtilizado = false;
            this.iwtRadioButton5.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtRadioButton5.Location = new System.Drawing.Point(6, 19);
            this.iwtRadioButton5.Name = "iwtRadioButton5";
            this.iwtRadioButton5.Size = new System.Drawing.Size(62, 17);
            this.iwtRadioButton5.TabIndex = 0;
            this.iwtRadioButton5.Text = "Material";
            this.iwtRadioButton5.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.iwtRadioButton4);
            this.groupBox1.Controls.Add(this.iwtRadioButton3);
            this.groupBox1.Controls.Add(this.iwtRadioButton2);
            this.groupBox1.Controls.Add(this.iwtRadioButton1);
            this.groupBox1.Location = new System.Drawing.Point(15, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 67);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Estoque de Segurança";
            // 
            // iwtRadioButton4
            // 
            this.iwtRadioButton4.AutoSize = true;
            this.iwtRadioButton4.BindingField = null;
            this.iwtRadioButton4.Checked = true;
            this.iwtRadioButton4.LiberadoQuandoCadastroUtilizado = false;
            this.iwtRadioButton4.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtRadioButton4.Location = new System.Drawing.Point(129, 44);
            this.iwtRadioButton4.Name = "iwtRadioButton4";
            this.iwtRadioButton4.Size = new System.Drawing.Size(55, 17);
            this.iwtRadioButton4.TabIndex = 3;
            this.iwtRadioButton4.TabStop = true;
            this.iwtRadioButton4.Text = "Todos";
            this.iwtRadioButton4.UseVisualStyleBackColor = true;
            // 
            // iwtRadioButton3
            // 
            this.iwtRadioButton3.AutoSize = true;
            this.iwtRadioButton3.BindingField = "Tipo_Vermelho";
            this.iwtRadioButton3.LiberadoQuandoCadastroUtilizado = false;
            this.iwtRadioButton3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtRadioButton3.Location = new System.Drawing.Point(20, 46);
            this.iwtRadioButton3.Name = "iwtRadioButton3";
            this.iwtRadioButton3.Size = new System.Drawing.Size(69, 17);
            this.iwtRadioButton3.TabIndex = 2;
            this.iwtRadioButton3.Text = "Vermelho";
            this.iwtRadioButton3.UseVisualStyleBackColor = true;
            // 
            // iwtRadioButton2
            // 
            this.iwtRadioButton2.AutoSize = true;
            this.iwtRadioButton2.BindingField = "Tipo_Amarelo";
            this.iwtRadioButton2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtRadioButton2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtRadioButton2.Location = new System.Drawing.Point(129, 23);
            this.iwtRadioButton2.Name = "iwtRadioButton2";
            this.iwtRadioButton2.Size = new System.Drawing.Size(63, 17);
            this.iwtRadioButton2.TabIndex = 1;
            this.iwtRadioButton2.Text = "Amarelo";
            this.iwtRadioButton2.UseVisualStyleBackColor = true;
            // 
            // iwtRadioButton1
            // 
            this.iwtRadioButton1.AutoSize = true;
            this.iwtRadioButton1.BindingField = "Tipo_Verde";
            this.iwtRadioButton1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtRadioButton1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtRadioButton1.Location = new System.Drawing.Point(20, 23);
            this.iwtRadioButton1.Name = "iwtRadioButton1";
            this.iwtRadioButton1.Size = new System.Drawing.Size(53, 17);
            this.iwtRadioButton1.TabIndex = 0;
            this.iwtRadioButton1.Text = "Verde";
            this.iwtRadioButton1.UseVisualStyleBackColor = true;
            // 
            // iwtTextBox1
            // 
            this.iwtTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtTextBox1.BindingField = "BuscaCompleta";
            this.iwtTextBox1.DebugMode = false;
            this.iwtTextBox1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtTextBox1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox1.Location = new System.Drawing.Point(52, 3);
            this.iwtTextBox1.ModoBarcode = false;
            this.iwtTextBox1.ModoBusca = false;
            this.iwtTextBox1.Name = "iwtTextBox1";
            this.iwtTextBox1.NaoLimparDepoisBarcode = false;
            this.iwtTextBox1.Size = new System.Drawing.Size(407, 20);
            this.iwtTextBox1.TabIndex = 1;
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(12, 6);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(37, 13);
            this.iwtLabel1.TabIndex = 0;
            this.iwtLabel1.Text = "Busca";
            // 
            // iwtDataGridView1
            // 
            this.iwtDataGridView1.AllowUserToAddRows = false;
            this.iwtDataGridView1.AllowUserToDeleteRows = false;
            this.iwtDataGridView1.AllowUserToOrderColumns = true;
            this.iwtDataGridView1.AllowUserToResizeRows = false;
            this.iwtDataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.iwtDataGridView1.CacheDados = null;
            this.iwtDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.iwtDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.TipoEntidadeColumn,
            this.IdentificacaoColumn,
            this.DescricaoColumn,
            this.DimensaoColumn,
            this.Tipo,
            this.DataAcionamento,
            this.AcsUsuarioAcionamento,
            this.Encerrado,
            this.RetiradaManual,
            this.DataRetirada,
            this.AcsUsuarioRetirada,
            this.EntidadeRetiradaAutomatica});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(209)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.iwtDataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.iwtDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.iwtDataGridView1.Name = "iwtDataGridView1";
            this.iwtDataGridView1.ReadOnly = true;
            this.iwtDataGridView1.RowHeadersVisible = false;
            this.iwtDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.iwtDataGridView1.Size = new System.Drawing.Size(1011, 309);
            this.iwtDataGridView1.TabIndex = 0;
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
            // TipoEntidadeColumn
            // 
            this.TipoEntidadeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TipoEntidadeColumn.DataPropertyName = "TipoEntidade";
            this.TipoEntidadeColumn.HeaderText = "Tipo";
            this.TipoEntidadeColumn.Name = "TipoEntidadeColumn";
            this.TipoEntidadeColumn.ReadOnly = true;
            this.TipoEntidadeColumn.Width = 150;
            // 
            // IdentificacaoColumn
            // 
            this.IdentificacaoColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IdentificacaoColumn.DataPropertyName = "Identificacao";
            this.IdentificacaoColumn.HeaderText = "Identificação";
            this.IdentificacaoColumn.Name = "IdentificacaoColumn";
            this.IdentificacaoColumn.ReadOnly = true;
            this.IdentificacaoColumn.Width = 150;
            // 
            // DescricaoColumn
            // 
            this.DescricaoColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DescricaoColumn.DataPropertyName = "Descricao";
            this.DescricaoColumn.HeaderText = "Descrição";
            this.DescricaoColumn.Name = "DescricaoColumn";
            this.DescricaoColumn.ReadOnly = true;
            this.DescricaoColumn.Width = 150;
            // 
            // DimensaoColumn
            // 
            this.DimensaoColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DimensaoColumn.DataPropertyName = "Dimensao";
            this.DimensaoColumn.HeaderText = "Dimensão";
            this.DimensaoColumn.Name = "DimensaoColumn";
            this.DimensaoColumn.ReadOnly = true;
            this.DimensaoColumn.Width = 150;
            // 
            // Tipo
            // 
            this.Tipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Tipo.DataPropertyName = "Tipo";
            this.Tipo.HeaderText = "Estoque de Segurança";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            this.Tipo.Width = 150;
            // 
            // DataAcionamento
            // 
            this.DataAcionamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DataAcionamento.DataPropertyName = "DataAcionamento";
            this.DataAcionamento.HeaderText = "Data da Entrada do Aviso";
            this.DataAcionamento.Name = "DataAcionamento";
            this.DataAcionamento.ReadOnly = true;
            // 
            // AcsUsuarioAcionamento
            // 
            this.AcsUsuarioAcionamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.AcsUsuarioAcionamento.DataPropertyName = "AcsUsuarioAcionamento";
            this.AcsUsuarioAcionamento.HeaderText = "Usuário Entrada do Aviso";
            this.AcsUsuarioAcionamento.Name = "AcsUsuarioAcionamento";
            this.AcsUsuarioAcionamento.ReadOnly = true;
            this.AcsUsuarioAcionamento.Width = 150;
            // 
            // Encerrado
            // 
            this.Encerrado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Encerrado.DataPropertyName = "Encerrado";
            this.Encerrado.HeaderText = "Aviso Encerrado";
            this.Encerrado.Name = "Encerrado";
            this.Encerrado.ReadOnly = true;
            this.Encerrado.Width = 70;
            // 
            // RetiradaManual
            // 
            this.RetiradaManual.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.RetiradaManual.DataPropertyName = "RetiradaManual";
            this.RetiradaManual.HeaderText = "Retirada Manual do Aviso";
            this.RetiradaManual.Name = "RetiradaManual";
            this.RetiradaManual.ReadOnly = true;
            this.RetiradaManual.Width = 70;
            // 
            // DataRetirada
            // 
            this.DataRetirada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DataRetirada.DataPropertyName = "DataRetirada";
            this.DataRetirada.HeaderText = "Data da Retirada do Aviso";
            this.DataRetirada.Name = "DataRetirada";
            this.DataRetirada.ReadOnly = true;
            // 
            // AcsUsuarioRetirada
            // 
            this.AcsUsuarioRetirada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.AcsUsuarioRetirada.DataPropertyName = "AcsUsuarioRetirada";
            this.AcsUsuarioRetirada.HeaderText = "Usuário Retirada do Aviso";
            this.AcsUsuarioRetirada.Name = "AcsUsuarioRetirada";
            this.AcsUsuarioRetirada.ReadOnly = true;
            this.AcsUsuarioRetirada.Width = 150;
            // 
            // EntidadeRetiradaAutomatica
            // 
            this.EntidadeRetiradaAutomatica.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.EntidadeRetiradaAutomatica.DataPropertyName = "EntidadeRetiradaAutomatica";
            this.EntidadeRetiradaAutomatica.HeaderText = "Entidade Origem da Retirada Automática do Aviso";
            this.EntidadeRetiradaAutomatica.Name = "EntidadeRetiradaAutomatica";
            this.EntidadeRetiradaAutomatica.ReadOnly = true;
            this.EntidadeRetiradaAutomatica.Visible = false;
            this.EntidadeRetiradaAutomatica.Width = 150;
            // 
            // btnRetirarAviso
            // 
            this.btnRetirarAviso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRetirarAviso.LiberadoQuandoCadastroUtilizado = false;
            this.btnRetirarAviso.Location = new System.Drawing.Point(12, 29);
            this.btnRetirarAviso.Name = "btnRetirarAviso";
            this.btnRetirarAviso.Size = new System.Drawing.Size(132, 58);
            this.btnRetirarAviso.TabIndex = 0;
            this.btnRetirarAviso.Text = "Retirar aviso de Estoque de Segurança Manualmente";
            this.btnRetirarAviso.UseVisualStyleBackColor = true;
            this.btnRetirarAviso.Click += new System.EventHandler(this.btnRetirarAviso_Click);
            // 
            // lnkAtualizar
            // 
            this.lnkAtualizar.AutoSize = true;
            this.lnkAtualizar.BindingField = null;
            this.lnkAtualizar.LiberadoQuandoCadastroUtilizado = false;
            this.lnkAtualizar.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lnkAtualizar.Location = new System.Drawing.Point(97, 6);
            this.lnkAtualizar.Name = "lnkAtualizar";
            this.lnkAtualizar.Size = new System.Drawing.Size(47, 13);
            this.lnkAtualizar.TabIndex = 1;
            this.lnkAtualizar.TabStop = true;
            this.lnkAtualizar.Text = "Atualizar";
            this.lnkAtualizar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAtualizar_LinkClicked);
            // 
            // CadKanbanAcionamentoListForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1011, 480);
            this.Name = "CadKanbanAcionamentoListForm";
            this.Text = "Itens em Estoque de Segurança";
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.iwtSearchPanel1.ResumeLayout(false);
            this.iwtSearchPanel1.PerformLayout();
            this.grbDataAcionamento.ResumeLayout(false);
            this.grbDataAcionamento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataAcionamentoAte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataAcionamentoDe)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iwtDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IWTDotNetLib.IWTSearchPanel iwtSearchPanel1;
        private IWTDotNetLib.IWTTextBox iwtTextBox1;
        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTDataGridView iwtDataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdutoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EpiColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdutoKColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EncerradoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataAcionamentoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcsUsuarioAcionamentoColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn RetiradaManualColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataRetiradaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcsUsuarioRetiradaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntidadeRetiradaAutomaticaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoEntidadeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdentificacaoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescricaoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DimensaoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataAcionamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcsUsuarioAcionamento;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Encerrado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn RetiradaManual;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataRetirada;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcsUsuarioRetirada;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntidadeRetiradaAutomatica;
        private System.Windows.Forms.GroupBox groupBox1;
        private IWTDotNetLib.IWTRadioButton iwtRadioButton4;
        private IWTDotNetLib.IWTRadioButton iwtRadioButton3;
        private IWTDotNetLib.IWTRadioButton iwtRadioButton2;
        private IWTDotNetLib.IWTRadioButton iwtRadioButton1;
        private System.Windows.Forms.GroupBox groupBox2;
        private IWTDotNetLib.IWTRadioButton iwtRadioButton5;
        private IWTDotNetLib.IWTRadioButton iwtRadioButton9;
        private IWTDotNetLib.IWTRadioButton iwtRadioButton8;
        private IWTDotNetLib.IWTRadioButton iwtRadioButton7;
        private IWTDotNetLib.IWTRadioButton iwtRadioButton6;
        private System.Windows.Forms.GroupBox grbDataAcionamento;
        private IWTDotNetLib.IWTLabel iwtLabel2;
        private IWTDotNetLib.IWTDateTimePicker DataAcionamentoDe;
        private IWTDotNetLib.IWTLabel iwtLabel3;
        private IWTDotNetLib.IWTDateTimePicker DataAcionamentoAte;
        private IWTDotNetLib.IWTRadioButton rdbEmAberto;
        private IWTDotNetLib.IWTRadioButton rdbEncerrados;
        private IWTDotNetLib.IWTLinkLabel lnkAtualizar;
        private IWTDotNetLib.IWTButton btnRetirarAviso;
        private IWTDotNetLib.IWTCheckBox chkDataAcionamento;
    }
} 
