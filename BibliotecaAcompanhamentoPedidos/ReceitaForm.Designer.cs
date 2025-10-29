namespace ModuloAcompanhamentoPedidos
{
    partial class ReceitaForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.rdbAtrasados = new System.Windows.Forms.RadioButton();
            this.lblLeadTime = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAteDataEntrega = new System.Windows.Forms.CheckBox();
            this.chkDeDataEntrega = new System.Windows.Forms.CheckBox();
            this.dtpAteDataEntrega = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpDeDataEntrega = new System.Windows.Forms.DateTimePicker();
            this.lblQtdLinhas = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rdbEncerrados = new System.Windows.Forms.RadioButton();
            this.rdbPendentes = new System.Windows.Forms.RadioButton();
            this.rdbTodos = new System.Windows.Forms.RadioButton();
            this.lblValorSemIPI = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblValorRecebido = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lnkAtualizar = new System.Windows.Forms.LinkLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkAteDataNF = new System.Windows.Forms.CheckBox();
            this.chkDeDataNF = new System.Windows.Forms.CheckBox();
            this.dtpAteDataNF = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpDeDataNF = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkAteDataEntrada = new System.Windows.Forms.CheckBox();
            this.chkDeDataEntrada = new System.Windows.Forms.CheckBox();
            this.dtpAteDataEntrada = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpDeDataEntrada = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.rdbAtrasados);
            this.splitContainer1.Panel2.Controls.Add(this.lblLeadTime);
            this.splitContainer1.Panel2.Controls.Add(this.label11);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.lblQtdLinhas);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.rdbEncerrados);
            this.splitContainer1.Panel2.Controls.Add(this.rdbPendentes);
            this.splitContainer1.Panel2.Controls.Add(this.rdbTodos);
            this.splitContainer1.Panel2.Controls.Add(this.lblValorSemIPI);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.lblValorRecebido);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.lnkAtualizar);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.txtBusca);
            this.splitContainer1.Size = new System.Drawing.Size(1067, 525);
            this.splitContainer1.SplitterDistance = 438;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1067, 438);
            this.dataGridView1.TabIndex = 0;
            // 
            // rdbAtrasados
            // 
            this.rdbAtrasados.AutoSize = true;
            this.rdbAtrasados.Location = new System.Drawing.Point(142, 45);
            this.rdbAtrasados.Name = "rdbAtrasados";
            this.rdbAtrasados.Size = new System.Drawing.Size(72, 17);
            this.rdbAtrasados.TabIndex = 30;
            this.rdbAtrasados.Text = "Atrasados";
            this.rdbAtrasados.UseVisualStyleBackColor = true;
            this.rdbAtrasados.CheckedChanged += new System.EventHandler(this.rdbAtrasados_CheckedChanged);
            // 
            // lblLeadTime
            // 
            this.lblLeadTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLeadTime.AutoSize = true;
            this.lblLeadTime.Location = new System.Drawing.Point(817, 27);
            this.lblLeadTime.Name = "lblLeadTime";
            this.lblLeadTime.Size = new System.Drawing.Size(13, 13);
            this.lblLeadTime.TabIndex = 29;
            this.lblLeadTime.Text = "a";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(692, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "Lead time Médio:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAteDataEntrega);
            this.groupBox1.Controls.Add(this.chkDeDataEntrega);
            this.groupBox1.Controls.Add(this.dtpAteDataEntrega);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.dtpDeDataEntrega);
            this.groupBox1.Location = new System.Drawing.Point(391, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(139, 69);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Prevista Entrega";
            // 
            // chkAteDataEntrega
            // 
            this.chkAteDataEntrega.AutoSize = true;
            this.chkAteDataEntrega.Location = new System.Drawing.Point(121, 47);
            this.chkAteDataEntrega.Name = "chkAteDataEntrega";
            this.chkAteDataEntrega.Size = new System.Drawing.Size(15, 14);
            this.chkAteDataEntrega.TabIndex = 5;
            this.chkAteDataEntrega.UseVisualStyleBackColor = true;
            this.chkAteDataEntrega.CheckedChanged += new System.EventHandler(this.chkAteDataEntrega_CheckedChanged);
            // 
            // chkDeDataEntrega
            // 
            this.chkDeDataEntrega.AutoSize = true;
            this.chkDeDataEntrega.Location = new System.Drawing.Point(121, 23);
            this.chkDeDataEntrega.Name = "chkDeDataEntrega";
            this.chkDeDataEntrega.Size = new System.Drawing.Size(15, 14);
            this.chkDeDataEntrega.TabIndex = 4;
            this.chkDeDataEntrega.UseVisualStyleBackColor = true;
            this.chkDeDataEntrega.CheckedChanged += new System.EventHandler(this.chkDeDataEntrega_CheckedChanged);
            // 
            // dtpAteDataEntrega
            // 
            this.dtpAteDataEntrega.Enabled = false;
            this.dtpAteDataEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAteDataEntrega.Location = new System.Drawing.Point(27, 43);
            this.dtpAteDataEntrega.Name = "dtpAteDataEntrega";
            this.dtpAteDataEntrega.Size = new System.Drawing.Size(90, 20);
            this.dtpAteDataEntrega.TabIndex = 3;
            this.dtpAteDataEntrega.ValueChanged += new System.EventHandler(this.dtpAteDataEntrega_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "até";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "de";
            // 
            // dtpDeDataEntrega
            // 
            this.dtpDeDataEntrega.Enabled = false;
            this.dtpDeDataEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDeDataEntrega.Location = new System.Drawing.Point(27, 19);
            this.dtpDeDataEntrega.Name = "dtpDeDataEntrega";
            this.dtpDeDataEntrega.Size = new System.Drawing.Size(90, 20);
            this.dtpDeDataEntrega.TabIndex = 0;
            this.dtpDeDataEntrega.ValueChanged += new System.EventHandler(this.dtpDeDataEntrega_ValueChanged);
            // 
            // lblQtdLinhas
            // 
            this.lblQtdLinhas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQtdLinhas.AutoSize = true;
            this.lblQtdLinhas.Location = new System.Drawing.Point(817, 12);
            this.lblQtdLinhas.Name = "lblQtdLinhas";
            this.lblQtdLinhas.Size = new System.Drawing.Size(13, 13);
            this.lblQtdLinhas.TabIndex = 27;
            this.lblQtdLinhas.Text = "a";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(692, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Quantidade Linhas:";
            // 
            // rdbEncerrados
            // 
            this.rdbEncerrados.AutoSize = true;
            this.rdbEncerrados.Checked = true;
            this.rdbEncerrados.Location = new System.Drawing.Point(142, 29);
            this.rdbEncerrados.Name = "rdbEncerrados";
            this.rdbEncerrados.Size = new System.Drawing.Size(72, 17);
            this.rdbEncerrados.TabIndex = 25;
            this.rdbEncerrados.TabStop = true;
            this.rdbEncerrados.Text = "Faturados";
            this.rdbEncerrados.UseVisualStyleBackColor = true;
            this.rdbEncerrados.CheckedChanged += new System.EventHandler(this.rdbEncerrados_CheckedChanged);
            // 
            // rdbPendentes
            // 
            this.rdbPendentes.AutoSize = true;
            this.rdbPendentes.Location = new System.Drawing.Point(12, 45);
            this.rdbPendentes.Name = "rdbPendentes";
            this.rdbPendentes.Size = new System.Drawing.Size(76, 17);
            this.rdbPendentes.TabIndex = 24;
            this.rdbPendentes.Text = "Pendentes";
            this.rdbPendentes.UseVisualStyleBackColor = true;
            this.rdbPendentes.CheckedChanged += new System.EventHandler(this.rdbPendentes_CheckedChanged);
            // 
            // rdbTodos
            // 
            this.rdbTodos.AutoSize = true;
            this.rdbTodos.Location = new System.Drawing.Point(12, 29);
            this.rdbTodos.Name = "rdbTodos";
            this.rdbTodos.Size = new System.Drawing.Size(55, 17);
            this.rdbTodos.TabIndex = 23;
            this.rdbTodos.Text = "Todos";
            this.rdbTodos.UseVisualStyleBackColor = true;
            this.rdbTodos.CheckedChanged += new System.EventHandler(this.rdbTodos_CheckedChanged);
            // 
            // lblValorSemIPI
            // 
            this.lblValorSemIPI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValorSemIPI.AutoSize = true;
            this.lblValorSemIPI.Location = new System.Drawing.Point(817, 57);
            this.lblValorSemIPI.Name = "lblValorSemIPI";
            this.lblValorSemIPI.Size = new System.Drawing.Size(13, 13);
            this.lblValorSemIPI.TabIndex = 22;
            this.lblValorSemIPI.Text = "a";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(692, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Valor dos Produtos: ";
            // 
            // lblValorRecebido
            // 
            this.lblValorRecebido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValorRecebido.AutoSize = true;
            this.lblValorRecebido.Location = new System.Drawing.Point(817, 42);
            this.lblValorRecebido.Name = "lblValorRecebido";
            this.lblValorRecebido.Size = new System.Drawing.Size(13, 13);
            this.lblValorRecebido.TabIndex = 20;
            this.lblValorRecebido.Text = "a";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(692, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Valor Total: ";
            // 
            // lnkAtualizar
            // 
            this.lnkAtualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkAtualizar.AutoSize = true;
            this.lnkAtualizar.Location = new System.Drawing.Point(1008, 62);
            this.lnkAtualizar.Name = "lnkAtualizar";
            this.lnkAtualizar.Size = new System.Drawing.Size(47, 13);
            this.lnkAtualizar.TabIndex = 11;
            this.lnkAtualizar.TabStop = true;
            this.lnkAtualizar.Text = "Atualizar";
            this.lnkAtualizar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAtualizar_LinkClicked);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkAteDataNF);
            this.groupBox3.Controls.Add(this.chkDeDataNF);
            this.groupBox3.Controls.Add(this.dtpAteDataNF);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.dtpDeDataNF);
            this.groupBox3.Location = new System.Drawing.Point(240, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(139, 69);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Data NF";
            // 
            // chkAteDataNF
            // 
            this.chkAteDataNF.AutoSize = true;
            this.chkAteDataNF.Checked = true;
            this.chkAteDataNF.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAteDataNF.Location = new System.Drawing.Point(121, 47);
            this.chkAteDataNF.Name = "chkAteDataNF";
            this.chkAteDataNF.Size = new System.Drawing.Size(15, 14);
            this.chkAteDataNF.TabIndex = 5;
            this.chkAteDataNF.UseVisualStyleBackColor = true;
            this.chkAteDataNF.CheckedChanged += new System.EventHandler(this.chkAteDataNF_CheckedChanged);
            // 
            // chkDeDataNF
            // 
            this.chkDeDataNF.AutoSize = true;
            this.chkDeDataNF.Checked = true;
            this.chkDeDataNF.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDeDataNF.Location = new System.Drawing.Point(121, 23);
            this.chkDeDataNF.Name = "chkDeDataNF";
            this.chkDeDataNF.Size = new System.Drawing.Size(15, 14);
            this.chkDeDataNF.TabIndex = 4;
            this.chkDeDataNF.UseVisualStyleBackColor = true;
            this.chkDeDataNF.CheckedChanged += new System.EventHandler(this.chkDeDataNF_CheckedChanged);
            // 
            // dtpAteDataNF
            // 
            this.dtpAteDataNF.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAteDataNF.Location = new System.Drawing.Point(27, 43);
            this.dtpAteDataNF.Name = "dtpAteDataNF";
            this.dtpAteDataNF.Size = new System.Drawing.Size(90, 20);
            this.dtpAteDataNF.TabIndex = 3;
            this.dtpAteDataNF.ValueChanged += new System.EventHandler(this.dtpAteDataNF_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "até";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "de";
            // 
            // dtpDeDataNF
            // 
            this.dtpDeDataNF.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDeDataNF.Location = new System.Drawing.Point(27, 19);
            this.dtpDeDataNF.Name = "dtpDeDataNF";
            this.dtpDeDataNF.Size = new System.Drawing.Size(90, 20);
            this.dtpDeDataNF.TabIndex = 0;
            this.dtpDeDataNF.ValueChanged += new System.EventHandler(this.dtpDeDataNF_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Busca";
            // 
            // txtBusca
            // 
            this.txtBusca.Location = new System.Drawing.Point(55, 3);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(159, 20);
            this.txtBusca.TabIndex = 14;
            this.txtBusca.TextChanged += new System.EventHandler(this.txtOC_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkAteDataEntrada);
            this.groupBox2.Controls.Add(this.chkDeDataEntrada);
            this.groupBox2.Controls.Add(this.dtpAteDataEntrada);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.dtpDeDataEntrada);
            this.groupBox2.Location = new System.Drawing.Point(542, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(139, 69);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data Entrada do Pedido";
            // 
            // chkAteDataEntrada
            // 
            this.chkAteDataEntrada.AutoSize = true;
            this.chkAteDataEntrada.Location = new System.Drawing.Point(121, 47);
            this.chkAteDataEntrada.Name = "chkAteDataEntrada";
            this.chkAteDataEntrada.Size = new System.Drawing.Size(15, 14);
            this.chkAteDataEntrada.TabIndex = 5;
            this.chkAteDataEntrada.UseVisualStyleBackColor = true;
            this.chkAteDataEntrada.CheckedChanged += new System.EventHandler(this.chkAteDataEntrada_CheckedChanged);
            // 
            // chkDeDataEntrada
            // 
            this.chkDeDataEntrada.AutoSize = true;
            this.chkDeDataEntrada.Location = new System.Drawing.Point(121, 23);
            this.chkDeDataEntrada.Name = "chkDeDataEntrada";
            this.chkDeDataEntrada.Size = new System.Drawing.Size(15, 14);
            this.chkDeDataEntrada.TabIndex = 4;
            this.chkDeDataEntrada.UseVisualStyleBackColor = true;
            this.chkDeDataEntrada.CheckedChanged += new System.EventHandler(this.chkDeDataEntrada_CheckedChanged);
            // 
            // dtpAteDataEntrada
            // 
            this.dtpAteDataEntrada.Enabled = false;
            this.dtpAteDataEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAteDataEntrada.Location = new System.Drawing.Point(27, 43);
            this.dtpAteDataEntrada.Name = "dtpAteDataEntrada";
            this.dtpAteDataEntrada.Size = new System.Drawing.Size(90, 20);
            this.dtpAteDataEntrada.TabIndex = 3;
            this.dtpAteDataEntrada.ValueChanged += new System.EventHandler(this.dtpAteDataEntrada_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "até";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(19, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "de";
            // 
            // dtpDeDataEntrada
            // 
            this.dtpDeDataEntrada.Enabled = false;
            this.dtpDeDataEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDeDataEntrada.Location = new System.Drawing.Point(27, 19);
            this.dtpDeDataEntrada.Name = "dtpDeDataEntrada";
            this.dtpDeDataEntrada.Size = new System.Drawing.Size(90, 20);
            this.dtpDeDataEntrada.TabIndex = 0;
            this.dtpDeDataEntrada.ValueChanged += new System.EventHandler(this.dtpDeDataEntrada_ValueChanged);
            // 
            // ReceitaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1067, 525);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ReceitaForm";
            this.Text = "Backlog";
            this.Shown += new System.EventHandler(this.ReceitaForm_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkAteDataNF;
        private System.Windows.Forms.CheckBox chkDeDataNF;
        private System.Windows.Forms.DateTimePicker dtpAteDataNF;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpDeDataNF;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.LinkLabel lnkAtualizar;
        private System.Windows.Forms.Label lblValorRecebido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblValorSemIPI;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rdbEncerrados;
        private System.Windows.Forms.RadioButton rdbPendentes;
        private System.Windows.Forms.RadioButton rdbTodos;
        private System.Windows.Forms.Label lblQtdLinhas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkAteDataEntrega;
        private System.Windows.Forms.CheckBox chkDeDataEntrega;
        private System.Windows.Forms.DateTimePicker dtpAteDataEntrega;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpDeDataEntrega;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblLeadTime;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton rdbAtrasados;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkAteDataEntrada;
        private System.Windows.Forms.CheckBox chkDeDataEntrada;
        private System.Windows.Forms.DateTimePicker dtpAteDataEntrada;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpDeDataEntrada;

    }
}