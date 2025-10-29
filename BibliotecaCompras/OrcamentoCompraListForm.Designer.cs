namespace BibliotecaCompras
{
    partial class OrcamentoCompraListForm
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
            this.btnVisualizar = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.dtpBusca = new System.Windows.Forms.DateTimePicker();
            this.cbxDataAb = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxEncerrada = new System.Windows.Forms.CheckBox();
            this.cbxRetornoParcial = new System.Windows.Forms.CheckBox();
            this.cbxAguardandoRetorno = new System.Windows.Forms.CheckBox();
            this.cbxNovas = new System.Windows.Forms.CheckBox();
            this.btnRecebimento = new System.Windows.Forms.Button();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.btnVisualizar);
            this.splitContainer1.Panel2.Controls.Add(this.btnEnviar);
            this.splitContainer1.Panel2.Controls.Add(this.dtpBusca);
            this.splitContainer1.Panel2.Controls.Add(this.cbxDataAb);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.btnRecebimento);
            this.splitContainer1.Panel2.Controls.Add(this.txtBusca);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.btnExcluir);
            this.splitContainer1.Panel2.Controls.Add(this.btnNovo);
            this.splitContainer1.Size = new System.Drawing.Size(826, 414);
            this.splitContainer1.SplitterDistance = 305;
            this.splitContainer1.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(826, 305);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVisualizar.Location = new System.Drawing.Point(737, 30);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(77, 23);
            this.btnVisualizar.TabIndex = 14;
            this.btnVisualizar.Text = "Visualizar";
            this.btnVisualizar.UseVisualStyleBackColor = true;
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnviar.Location = new System.Drawing.Point(658, 30);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(77, 23);
            this.btnEnviar.TabIndex = 13;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // dtpBusca
            // 
            this.dtpBusca.Enabled = false;
            this.dtpBusca.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBusca.Location = new System.Drawing.Point(89, 38);
            this.dtpBusca.Name = "dtpBusca";
            this.dtpBusca.Size = new System.Drawing.Size(117, 20);
            this.dtpBusca.TabIndex = 12;
            this.dtpBusca.ValueChanged += new System.EventHandler(this.dtpBusca_ValueChanged);
            // 
            // cbxDataAb
            // 
            this.cbxDataAb.AutoSize = true;
            this.cbxDataAb.Location = new System.Drawing.Point(212, 41);
            this.cbxDataAb.Name = "cbxDataAb";
            this.cbxDataAb.Size = new System.Drawing.Size(15, 14);
            this.cbxDataAb.TabIndex = 1;
            this.cbxDataAb.UseVisualStyleBackColor = true;
            this.cbxDataAb.CheckedChanged += new System.EventHandler(this.chkIdOC_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Data Abertura";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxEncerrada);
            this.groupBox1.Controls.Add(this.cbxRetornoParcial);
            this.groupBox1.Controls.Add(this.cbxAguardandoRetorno);
            this.groupBox1.Controls.Add(this.cbxNovas);
            this.groupBox1.Location = new System.Drawing.Point(285, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(149, 90);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // cbxEncerrada
            // 
            this.cbxEncerrada.AutoSize = true;
            this.cbxEncerrada.Location = new System.Drawing.Point(18, 67);
            this.cbxEncerrada.Name = "cbxEncerrada";
            this.cbxEncerrada.Size = new System.Drawing.Size(80, 17);
            this.cbxEncerrada.TabIndex = 3;
            this.cbxEncerrada.Text = "Encerrados";
            this.cbxEncerrada.UseVisualStyleBackColor = true;
            this.cbxEncerrada.CheckedChanged += new System.EventHandler(this.cbxEncerrada_CheckedChanged);
            // 
            // cbxRetornoParcial
            // 
            this.cbxRetornoParcial.AutoSize = true;
            this.cbxRetornoParcial.Location = new System.Drawing.Point(18, 50);
            this.cbxRetornoParcial.Name = "cbxRetornoParcial";
            this.cbxRetornoParcial.Size = new System.Drawing.Size(99, 17);
            this.cbxRetornoParcial.TabIndex = 2;
            this.cbxRetornoParcial.Text = "Retorno Parcial";
            this.cbxRetornoParcial.UseVisualStyleBackColor = true;
            this.cbxRetornoParcial.CheckedChanged += new System.EventHandler(this.cbxRetornoParcial_CheckedChanged);
            // 
            // cbxAguardandoRetorno
            // 
            this.cbxAguardandoRetorno.AutoSize = true;
            this.cbxAguardandoRetorno.Location = new System.Drawing.Point(18, 33);
            this.cbxAguardandoRetorno.Name = "cbxAguardandoRetorno";
            this.cbxAguardandoRetorno.Size = new System.Drawing.Size(125, 17);
            this.cbxAguardandoRetorno.TabIndex = 1;
            this.cbxAguardandoRetorno.Text = "Aguardando Retorno";
            this.cbxAguardandoRetorno.UseVisualStyleBackColor = true;
            this.cbxAguardandoRetorno.CheckedChanged += new System.EventHandler(this.cbxAguardandoRetorno_CheckedChanged);
            // 
            // cbxNovas
            // 
            this.cbxNovas.AutoSize = true;
            this.cbxNovas.Checked = true;
            this.cbxNovas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxNovas.Location = new System.Drawing.Point(18, 16);
            this.cbxNovas.Name = "cbxNovas";
            this.cbxNovas.Size = new System.Drawing.Size(57, 17);
            this.cbxNovas.TabIndex = 0;
            this.cbxNovas.Text = "Novos";
            this.cbxNovas.UseVisualStyleBackColor = true;
            this.cbxNovas.CheckedChanged += new System.EventHandler(this.cbxNovas_CheckedChanged);
            // 
            // btnRecebimento
            // 
            this.btnRecebimento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRecebimento.Location = new System.Drawing.Point(658, 55);
            this.btnRecebimento.Name = "btnRecebimento";
            this.btnRecebimento.Size = new System.Drawing.Size(156, 23);
            this.btnRecebimento.TabIndex = 6;
            this.btnRecebimento.Text = "Recebimento";
            this.btnRecebimento.UseVisualStyleBackColor = true;
            this.btnRecebimento.Click += new System.EventHandler(this.btnRecebimento_Click);
            // 
            // txtBusca
            // 
            this.txtBusca.Location = new System.Drawing.Point(89, 13);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(138, 20);
            this.txtBusca.TabIndex = 0;
            this.txtBusca.TextChanged += new System.EventHandler(this.txtBusca_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Número";
            // 
            // btnExcluir
            // 
            this.btnExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcluir.Location = new System.Drawing.Point(658, 80);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(156, 23);
            this.btnExcluir.TabIndex = 8;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNovo.Location = new System.Drawing.Point(658, 5);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(156, 23);
            this.btnNovo.TabIndex = 4;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // OrcamentoCompraListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(826, 414);
            this.Controls.Add(this.splitContainer1);
            this.Name = "OrcamentoCompraListForm";
            this.Text = "Orçamentos de Compra";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox cbxDataAb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbxEncerrada;
        private System.Windows.Forms.CheckBox cbxRetornoParcial;
        private System.Windows.Forms.CheckBox cbxAguardandoRetorno;
        private System.Windows.Forms.CheckBox cbxNovas;
        private System.Windows.Forms.Button btnRecebimento;
        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.DateTimePicker dtpBusca;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Button btnVisualizar;
    }
}