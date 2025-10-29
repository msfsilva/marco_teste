namespace BibliotecaExportacaoDados
{
    partial class ExportaPedidoCSVForm
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
            this.btnExportar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpEntradaInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpEntradaFim = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkEntradaInicio = new System.Windows.Forms.CheckBox();
            this.chkEntradaFim = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkEntregaFim = new System.Windows.Forms.CheckBox();
            this.chkEntregaInicio = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpEntregaFim = new System.Windows.Forms.DateTimePicker();
            this.dtpEntregaInicio = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkPendente = new System.Windows.Forms.CheckBox();
            this.chkSuspenso = new System.Windows.Forms.CheckBox();
            this.chkEncerrado = new System.Windows.Forms.CheckBox();
            this.chkCancelado = new System.Windows.Forms.CheckBox();
            this.chkReaberto = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkUrgente = new System.Windows.Forms.CheckBox();
            this.chkAntecipacao = new System.Windows.Forms.CheckBox();
            this.chkNormal = new System.Windows.Forms.CheckBox();
            this.chkCritico = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNumeroPedido = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPosPedido = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbCliente = new IWTCustomControls.InheritedCombo.MultiColumnComboBox(this.components);
            this.chkCliente = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnDiretorioSaida = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.btnDiretorioSaida);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.textBox1);
            this.splitContainer1.Panel1.Controls.Add(this.chkCliente);
            this.splitContainer1.Panel1.Controls.Add(this.cmbCliente);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.txtPosPedido);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.txtNumeroPedido);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnExportar);
            this.splitContainer1.Size = new System.Drawing.Size(476, 413);
            this.splitContainer1.SplitterDistance = 346;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.Location = new System.Drawing.Point(389, 17);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(75, 23);
            this.btnExportar.TabIndex = 0;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkEntradaFim);
            this.groupBox1.Controls.Add(this.chkEntradaInicio);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpEntradaFim);
            this.groupBox1.Controls.Add(this.dtpEntradaInicio);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 85);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Entrada";
            // 
            // dtpEntradaInicio
            // 
            this.dtpEntradaInicio.Enabled = false;
            this.dtpEntradaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEntradaInicio.Location = new System.Drawing.Point(45, 19);
            this.dtpEntradaInicio.Name = "dtpEntradaInicio";
            this.dtpEntradaInicio.Size = new System.Drawing.Size(119, 20);
            this.dtpEntradaInicio.TabIndex = 0;
            // 
            // dtpEntradaFim
            // 
            this.dtpEntradaFim.Enabled = false;
            this.dtpEntradaFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEntradaFim.Location = new System.Drawing.Point(45, 45);
            this.dtpEntradaFim.Name = "dtpEntradaFim";
            this.dtpEntradaFim.Size = new System.Drawing.Size(119, 20);
            this.dtpEntradaFim.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Inicio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fim";
            // 
            // chkEntradaInicio
            // 
            this.chkEntradaInicio.AutoSize = true;
            this.chkEntradaInicio.Location = new System.Drawing.Point(170, 22);
            this.chkEntradaInicio.Name = "chkEntradaInicio";
            this.chkEntradaInicio.Size = new System.Drawing.Size(15, 14);
            this.chkEntradaInicio.TabIndex = 1;
            this.chkEntradaInicio.UseVisualStyleBackColor = true;
            this.chkEntradaInicio.CheckedChanged += new System.EventHandler(this.chkEntradaInicio_CheckedChanged);
            // 
            // chkEntradaFim
            // 
            this.chkEntradaFim.AutoSize = true;
            this.chkEntradaFim.Location = new System.Drawing.Point(170, 49);
            this.chkEntradaFim.Name = "chkEntradaFim";
            this.chkEntradaFim.Size = new System.Drawing.Size(15, 14);
            this.chkEntradaFim.TabIndex = 3;
            this.chkEntradaFim.UseVisualStyleBackColor = true;
            this.chkEntradaFim.CheckedChanged += new System.EventHandler(this.chkEntradaFim_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkEntregaFim);
            this.groupBox2.Controls.Add(this.chkEntregaInicio);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dtpEntregaFim);
            this.groupBox2.Controls.Add(this.dtpEntregaInicio);
            this.groupBox2.Location = new System.Drawing.Point(250, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 85);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data Entrega";
            // 
            // chkEntregaFim
            // 
            this.chkEntregaFim.AutoSize = true;
            this.chkEntregaFim.Location = new System.Drawing.Point(170, 49);
            this.chkEntregaFim.Name = "chkEntregaFim";
            this.chkEntregaFim.Size = new System.Drawing.Size(15, 14);
            this.chkEntregaFim.TabIndex = 3;
            this.chkEntregaFim.UseVisualStyleBackColor = true;
            this.chkEntregaFim.CheckedChanged += new System.EventHandler(this.chkEntregaFim_CheckedChanged);
            // 
            // chkEntregaInicio
            // 
            this.chkEntregaInicio.AutoSize = true;
            this.chkEntregaInicio.Location = new System.Drawing.Point(170, 22);
            this.chkEntregaInicio.Name = "chkEntregaInicio";
            this.chkEntregaInicio.Size = new System.Drawing.Size(15, 14);
            this.chkEntregaInicio.TabIndex = 1;
            this.chkEntregaInicio.UseVisualStyleBackColor = true;
            this.chkEntregaInicio.CheckedChanged += new System.EventHandler(this.chkEntregaInicio_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Fim";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Inicio";
            // 
            // dtpEntregaFim
            // 
            this.dtpEntregaFim.Enabled = false;
            this.dtpEntregaFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEntregaFim.Location = new System.Drawing.Point(45, 45);
            this.dtpEntregaFim.Name = "dtpEntregaFim";
            this.dtpEntregaFim.Size = new System.Drawing.Size(119, 20);
            this.dtpEntregaFim.TabIndex = 2;
            // 
            // dtpEntregaInicio
            // 
            this.dtpEntregaInicio.Enabled = false;
            this.dtpEntregaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEntregaInicio.Location = new System.Drawing.Point(45, 19);
            this.dtpEntregaInicio.Name = "dtpEntregaInicio";
            this.dtpEntregaInicio.Size = new System.Drawing.Size(119, 20);
            this.dtpEntregaInicio.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkReaberto);
            this.groupBox3.Controls.Add(this.chkCancelado);
            this.groupBox3.Controls.Add(this.chkEncerrado);
            this.groupBox3.Controls.Add(this.chkSuspenso);
            this.groupBox3.Controls.Add(this.chkPendente);
            this.groupBox3.Location = new System.Drawing.Point(12, 116);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 91);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Status";
            // 
            // chkPendente
            // 
            this.chkPendente.AutoSize = true;
            this.chkPendente.Checked = true;
            this.chkPendente.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPendente.Location = new System.Drawing.Point(9, 19);
            this.chkPendente.Name = "chkPendente";
            this.chkPendente.Size = new System.Drawing.Size(72, 17);
            this.chkPendente.TabIndex = 0;
            this.chkPendente.Text = "Pendente";
            this.chkPendente.UseVisualStyleBackColor = true;
            // 
            // chkSuspenso
            // 
            this.chkSuspenso.AutoSize = true;
            this.chkSuspenso.Checked = true;
            this.chkSuspenso.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSuspenso.Location = new System.Drawing.Point(9, 42);
            this.chkSuspenso.Name = "chkSuspenso";
            this.chkSuspenso.Size = new System.Drawing.Size(73, 17);
            this.chkSuspenso.TabIndex = 1;
            this.chkSuspenso.Text = "Suspenso";
            this.chkSuspenso.UseVisualStyleBackColor = true;
            // 
            // chkEncerrado
            // 
            this.chkEncerrado.AutoSize = true;
            this.chkEncerrado.Checked = true;
            this.chkEncerrado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEncerrado.Location = new System.Drawing.Point(9, 65);
            this.chkEncerrado.Name = "chkEncerrado";
            this.chkEncerrado.Size = new System.Drawing.Size(75, 17);
            this.chkEncerrado.TabIndex = 2;
            this.chkEncerrado.Text = "Encerrado";
            this.chkEncerrado.UseVisualStyleBackColor = true;
            // 
            // chkCancelado
            // 
            this.chkCancelado.AutoSize = true;
            this.chkCancelado.Checked = true;
            this.chkCancelado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCancelado.Location = new System.Drawing.Point(105, 19);
            this.chkCancelado.Name = "chkCancelado";
            this.chkCancelado.Size = new System.Drawing.Size(77, 17);
            this.chkCancelado.TabIndex = 3;
            this.chkCancelado.Text = "Cancelado";
            this.chkCancelado.UseVisualStyleBackColor = true;
            // 
            // chkReaberto
            // 
            this.chkReaberto.AutoSize = true;
            this.chkReaberto.Checked = true;
            this.chkReaberto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReaberto.Location = new System.Drawing.Point(105, 42);
            this.chkReaberto.Name = "chkReaberto";
            this.chkReaberto.Size = new System.Drawing.Size(70, 17);
            this.chkReaberto.TabIndex = 4;
            this.chkReaberto.Text = "Reaberto";
            this.chkReaberto.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkCritico);
            this.groupBox4.Controls.Add(this.chkUrgente);
            this.groupBox4.Controls.Add(this.chkAntecipacao);
            this.groupBox4.Controls.Add(this.chkNormal);
            this.groupBox4.Location = new System.Drawing.Point(250, 116);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 91);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Urgente";
            // 
            // chkUrgente
            // 
            this.chkUrgente.AutoSize = true;
            this.chkUrgente.Checked = true;
            this.chkUrgente.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUrgente.Location = new System.Drawing.Point(9, 65);
            this.chkUrgente.Name = "chkUrgente";
            this.chkUrgente.Size = new System.Drawing.Size(64, 17);
            this.chkUrgente.TabIndex = 2;
            this.chkUrgente.Text = "Urgente";
            this.chkUrgente.UseVisualStyleBackColor = true;
            // 
            // chkAntecipacao
            // 
            this.chkAntecipacao.AutoSize = true;
            this.chkAntecipacao.Checked = true;
            this.chkAntecipacao.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAntecipacao.Location = new System.Drawing.Point(9, 42);
            this.chkAntecipacao.Name = "chkAntecipacao";
            this.chkAntecipacao.Size = new System.Drawing.Size(86, 17);
            this.chkAntecipacao.TabIndex = 1;
            this.chkAntecipacao.Text = "Antecipação";
            this.chkAntecipacao.UseVisualStyleBackColor = true;
            // 
            // chkNormal
            // 
            this.chkNormal.AutoSize = true;
            this.chkNormal.Checked = true;
            this.chkNormal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNormal.Location = new System.Drawing.Point(9, 19);
            this.chkNormal.Name = "chkNormal";
            this.chkNormal.Size = new System.Drawing.Size(59, 17);
            this.chkNormal.TabIndex = 0;
            this.chkNormal.Text = "Normal";
            this.chkNormal.UseVisualStyleBackColor = true;
            // 
            // chkCritico
            // 
            this.chkCritico.AutoSize = true;
            this.chkCritico.Checked = true;
            this.chkCritico.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCritico.Location = new System.Drawing.Point(121, 19);
            this.chkCritico.Name = "chkCritico";
            this.chkCritico.Size = new System.Drawing.Size(57, 17);
            this.chkCritico.TabIndex = 3;
            this.chkCritico.Text = "Crítico";
            this.chkCritico.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Número do Pedido";
            // 
            // txtNumeroPedido
            // 
            this.txtNumeroPedido.Location = new System.Drawing.Point(119, 218);
            this.txtNumeroPedido.Name = "txtNumeroPedido";
            this.txtNumeroPedido.Size = new System.Drawing.Size(169, 20);
            this.txtNumeroPedido.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(294, 221);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "/";
            // 
            // txtPosPedido
            // 
            this.txtPosPedido.Location = new System.Drawing.Point(312, 218);
            this.txtPosPedido.Name = "txtPosPedido";
            this.txtPosPedido.Size = new System.Drawing.Size(46, 20);
            this.txtPosPedido.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(74, 261);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Cliente";
            // 
            // cmbCliente
            // 
            this.cmbCliente.Enabled = false;
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(119, 258);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.SelectedRow = null;
            this.cmbCliente.Size = new System.Drawing.Size(308, 21);
            this.cmbCliente.TabIndex = 6;
            this.cmbCliente.Table = null;
            // 
            // chkCliente
            // 
            this.chkCliente.AutoSize = true;
            this.chkCliente.Location = new System.Drawing.Point(433, 261);
            this.chkCliente.Name = "chkCliente";
            this.chkCliente.Size = new System.Drawing.Size(15, 14);
            this.chkCliente.TabIndex = 7;
            this.chkCliente.UseVisualStyleBackColor = true;
            this.chkCliente.CheckedChanged += new System.EventHandler(this.chkCliente_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(119, 306);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(308, 20);
            this.textBox1.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 309);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Diretório de Saída";
            // 
            // btnDiretorioSaida
            // 
            this.btnDiretorioSaida.Location = new System.Drawing.Point(433, 304);
            this.btnDiretorioSaida.Name = "btnDiretorioSaida";
            this.btnDiretorioSaida.Size = new System.Drawing.Size(31, 23);
            this.btnDiretorioSaida.TabIndex = 9;
            this.btnDiretorioSaida.Text = "...";
            this.btnDiretorioSaida.UseVisualStyleBackColor = true;
            this.btnDiretorioSaida.Click += new System.EventHandler(this.btnDiretorioSaida_Click);
            // 
            // ExportaPedidoCSVForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(476, 413);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ExportaPedidoCSVForm";
            this.Text = "Exportar Pedidos em CSV";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkEntregaFim;
        private System.Windows.Forms.CheckBox chkEntregaInicio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpEntregaFim;
        private System.Windows.Forms.DateTimePicker dtpEntregaInicio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkEntradaFim;
        private System.Windows.Forms.CheckBox chkEntradaInicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpEntradaFim;
        private System.Windows.Forms.DateTimePicker dtpEntradaInicio;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkPendente;
        private System.Windows.Forms.CheckBox chkReaberto;
        private System.Windows.Forms.CheckBox chkCancelado;
        private System.Windows.Forms.CheckBox chkEncerrado;
        private System.Windows.Forms.CheckBox chkSuspenso;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkUrgente;
        private System.Windows.Forms.CheckBox chkAntecipacao;
        private System.Windows.Forms.CheckBox chkNormal;
        private System.Windows.Forms.CheckBox chkCritico;
        private System.Windows.Forms.TextBox txtPosPedido;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNumeroPedido;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkCliente;
        private IWTCustomControls.InheritedCombo.MultiColumnComboBox cmbCliente;
        private System.Windows.Forms.Button btnDiretorioSaida;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}