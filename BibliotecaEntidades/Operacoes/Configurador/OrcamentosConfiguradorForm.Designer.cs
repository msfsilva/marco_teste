namespace BibliotecaEntidades.Operacoes.Configurador
{
    partial class OrcamentosConfiguradorForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblQtdPedidos = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rdbConfigurado = new System.Windows.Forms.RadioButton();
            this.rdbNaoConfigurados = new System.Windows.Forms.RadioButton();
            this.btnConfigurar = new System.Windows.Forms.Button();
            this.rdbAprovados = new System.Windows.Forms.RadioButton();
            this.rdbTodos = new System.Windows.Forms.RadioButton();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDesfazer = new System.Windows.Forms.Button();
            this.rdbPendentes = new System.Windows.Forms.RadioButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.timerBusca = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1061, 318);
            this.dataGridView1.TabIndex = 0;
            // 
            // lblQtdPedidos
            // 
            this.lblQtdPedidos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQtdPedidos.AutoSize = true;
            this.lblQtdPedidos.Location = new System.Drawing.Point(969, 11);
            this.lblQtdPedidos.Name = "lblQtdPedidos";
            this.lblQtdPedidos.Size = new System.Drawing.Size(0, 13);
            this.lblQtdPedidos.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(832, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Quantidade de Orçamentos";
            // 
            // rdbConfigurado
            // 
            this.rdbConfigurado.AutoSize = true;
            this.rdbConfigurado.Location = new System.Drawing.Point(168, 33);
            this.rdbConfigurado.Name = "rdbConfigurado";
            this.rdbConfigurado.Size = new System.Drawing.Size(87, 17);
            this.rdbConfigurado.TabIndex = 6;
            this.rdbConfigurado.Text = "Configurados";
            this.rdbConfigurado.UseVisualStyleBackColor = true;
            this.rdbConfigurado.CheckedChanged += new System.EventHandler(this.rdbConfigurado_CheckedChanged);
            // 
            // rdbNaoConfigurados
            // 
            this.rdbNaoConfigurados.AutoSize = true;
            this.rdbNaoConfigurados.Checked = true;
            this.rdbNaoConfigurados.Location = new System.Drawing.Point(52, 33);
            this.rdbNaoConfigurados.Name = "rdbNaoConfigurados";
            this.rdbNaoConfigurados.Size = new System.Drawing.Size(110, 17);
            this.rdbNaoConfigurados.TabIndex = 5;
            this.rdbNaoConfigurados.TabStop = true;
            this.rdbNaoConfigurados.Text = "Não Configurados";
            this.rdbNaoConfigurados.UseVisualStyleBackColor = true;
            this.rdbNaoConfigurados.CheckedChanged += new System.EventHandler(this.rdbNaoConfigurados_CheckedChanged);
            // 
            // btnConfigurar
            // 
            this.btnConfigurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfigurar.Location = new System.Drawing.Point(839, 27);
            this.btnConfigurar.Name = "btnConfigurar";
            this.btnConfigurar.Size = new System.Drawing.Size(75, 23);
            this.btnConfigurar.TabIndex = 1;
            this.btnConfigurar.Text = "Configurar";
            this.btnConfigurar.UseVisualStyleBackColor = true;
            this.btnConfigurar.Click += new System.EventHandler(this.btnConfigurar_Click);
            // 
            // rdbAprovados
            // 
            this.rdbAprovados.AutoSize = true;
            this.rdbAprovados.Location = new System.Drawing.Point(94, 14);
            this.rdbAprovados.Name = "rdbAprovados";
            this.rdbAprovados.Size = new System.Drawing.Size(76, 17);
            this.rdbAprovados.TabIndex = 3;
            this.rdbAprovados.Text = "Aprovados";
            this.rdbAprovados.UseVisualStyleBackColor = true;
            this.rdbAprovados.CheckedChanged += new System.EventHandler(this.Aprovados_CheckedChanged);
            // 
            // rdbTodos
            // 
            this.rdbTodos.AutoSize = true;
            this.rdbTodos.Location = new System.Drawing.Point(176, 14);
            this.rdbTodos.Name = "rdbTodos";
            this.rdbTodos.Size = new System.Drawing.Size(55, 17);
            this.rdbTodos.TabIndex = 2;
            this.rdbTodos.Text = "Todos";
            this.rdbTodos.UseVisualStyleBackColor = true;
            this.rdbTodos.CheckedChanged += new System.EventHandler(this.rdbTodos_CheckedChanged);
            // 
            // txtBusca
            // 
            this.txtBusca.Location = new System.Drawing.Point(71, 8);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(203, 20);
            this.txtBusca.TabIndex = 4;
            this.txtBusca.TextChanged += new System.EventHandler(this.txtBusca_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Orçamento";
            // 
            // btnDesfazer
            // 
            this.btnDesfazer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDesfazer.Location = new System.Drawing.Point(920, 27);
            this.btnDesfazer.Name = "btnDesfazer";
            this.btnDesfazer.Size = new System.Drawing.Size(129, 23);
            this.btnDesfazer.TabIndex = 2;
            this.btnDesfazer.Text = "Desfazer Configuração";
            this.btnDesfazer.UseVisualStyleBackColor = true;
            this.btnDesfazer.Click += new System.EventHandler(this.btnDesfazer_Click);
            // 
            // rdbPendentes
            // 
            this.rdbPendentes.AutoSize = true;
            this.rdbPendentes.Checked = true;
            this.rdbPendentes.Location = new System.Drawing.Point(12, 14);
            this.rdbPendentes.Name = "rdbPendentes";
            this.rdbPendentes.Size = new System.Drawing.Size(76, 17);
            this.rdbPendentes.TabIndex = 0;
            this.rdbPendentes.TabStop = true;
            this.rdbPendentes.Text = "Pendentes";
            this.rdbPendentes.UseVisualStyleBackColor = true;
            this.rdbPendentes.CheckedChanged += new System.EventHandler(this.rdbPendentes_CheckedChanged);
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
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.lblQtdPedidos);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.rdbConfigurado);
            this.splitContainer1.Panel2.Controls.Add(this.rdbNaoConfigurados);
            this.splitContainer1.Panel2.Controls.Add(this.txtBusca);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.btnDesfazer);
            this.splitContainer1.Panel2.Controls.Add(this.btnConfigurar);
            this.splitContainer1.Size = new System.Drawing.Size(1061, 384);
            this.splitContainer1.SplitterDistance = 318;
            this.splitContainer1.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbAprovados);
            this.groupBox1.Controls.Add(this.rdbTodos);
            this.groupBox1.Controls.Add(this.rdbPendentes);
            this.groupBox1.Location = new System.Drawing.Point(340, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 40);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Situação do Orçamento";
            // 
            // timerBusca
            // 
            this.timerBusca.Tick += new System.EventHandler(this.timerBusca_Tick);
            // 
            // OrcamentosConfiguradorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1061, 384);
            this.Controls.Add(this.splitContainer1);
            this.Name = "OrcamentosConfiguradorForm";
            this.Text = "Orçamentos Configurados / Não Configurados";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblQtdPedidos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdbConfigurado;
        private System.Windows.Forms.RadioButton rdbNaoConfigurados;
        private System.Windows.Forms.Button btnConfigurar;
        private System.Windows.Forms.RadioButton rdbAprovados;
        private System.Windows.Forms.RadioButton rdbTodos;
        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDesfazer;
        private System.Windows.Forms.RadioButton rdbPendentes;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Timer timerBusca;
    }
}