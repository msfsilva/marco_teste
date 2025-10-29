namespace BibliotecaGerenciamentoLog
{
    partial class LogListForm
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
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.timerBusca = new System.Windows.Forms.Timer(this.components);
            this.rdbInformacao = new System.Windows.Forms.RadioButton();
            this.rdbAviso = new System.Windows.Forms.RadioButton();
            this.rdbErros = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAteData = new System.Windows.Forms.CheckBox();
            this.chkDeData = new System.Windows.Forms.CheckBox();
            this.dtpAteData = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpDeData = new System.Windows.Forms.DateTimePicker();
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
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(682, 289);
            this.dataGridView1.TabIndex = 0;
            // 
            // txtBusca
            // 
            this.txtBusca.Location = new System.Drawing.Point(55, 29);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(177, 20);
            this.txtBusca.TabIndex = 4;
            this.txtBusca.TextChanged += new System.EventHandler(this.txtBusca_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Busca";
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
            this.splitContainer1.Panel2.Controls.Add(this.rdbErros);
            this.splitContainer1.Panel2.Controls.Add(this.rdbAviso);
            this.splitContainer1.Panel2.Controls.Add(this.rdbInformacao);
            this.splitContainer1.Panel2.Controls.Add(this.txtBusca);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.btnExcluir);
            this.splitContainer1.Size = new System.Drawing.Size(682, 372);
            this.splitContainer1.SplitterDistance = 289;
            this.splitContainer1.TabIndex = 3;
            // 
            // btnExcluir
            // 
            this.btnExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcluir.Location = new System.Drawing.Point(595, 28);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 2;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // timerBusca
            // 
            this.timerBusca.Tick += new System.EventHandler(this.timerBusca_Tick);
            // 
            // rdbInformacao
            // 
            this.rdbInformacao.AutoSize = true;
            this.rdbInformacao.Location = new System.Drawing.Point(265, 11);
            this.rdbInformacao.Name = "rdbInformacao";
            this.rdbInformacao.Size = new System.Drawing.Size(78, 17);
            this.rdbInformacao.TabIndex = 5;
            this.rdbInformacao.Text = "Informação";
            this.rdbInformacao.UseVisualStyleBackColor = true;
            this.rdbInformacao.CheckedChanged += new System.EventHandler(this.rdbInformacao_CheckedChanged);
            // 
            // rdbAviso
            // 
            this.rdbAviso.AutoSize = true;
            this.rdbAviso.Location = new System.Drawing.Point(265, 30);
            this.rdbAviso.Name = "rdbAviso";
            this.rdbAviso.Size = new System.Drawing.Size(51, 17);
            this.rdbAviso.TabIndex = 6;
            this.rdbAviso.Text = "Aviso";
            this.rdbAviso.UseVisualStyleBackColor = true;
            this.rdbAviso.CheckedChanged += new System.EventHandler(this.rdbAviso_CheckedChanged);
            // 
            // rdbErros
            // 
            this.rdbErros.AutoSize = true;
            this.rdbErros.Checked = true;
            this.rdbErros.Location = new System.Drawing.Point(265, 50);
            this.rdbErros.Name = "rdbErros";
            this.rdbErros.Size = new System.Drawing.Size(49, 17);
            this.rdbErros.TabIndex = 7;
            this.rdbErros.TabStop = true;
            this.rdbErros.Text = "Erros";
            this.rdbErros.UseVisualStyleBackColor = true;
            this.rdbErros.CheckedChanged += new System.EventHandler(this.rdbErros_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAteData);
            this.groupBox1.Controls.Add(this.chkDeData);
            this.groupBox1.Controls.Add(this.dtpAteData);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.dtpDeData);
            this.groupBox1.Location = new System.Drawing.Point(394, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(139, 69);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data";
            // 
            // chkAteData
            // 
            this.chkAteData.AutoSize = true;
            this.chkAteData.Location = new System.Drawing.Point(121, 47);
            this.chkAteData.Name = "chkAteData";
            this.chkAteData.Size = new System.Drawing.Size(15, 14);
            this.chkAteData.TabIndex = 5;
            this.chkAteData.UseVisualStyleBackColor = true;
            this.chkAteData.CheckedChanged += new System.EventHandler(this.chkAteData_CheckedChanged);
            // 
            // chkDeData
            // 
            this.chkDeData.AutoSize = true;
            this.chkDeData.Location = new System.Drawing.Point(121, 23);
            this.chkDeData.Name = "chkDeData";
            this.chkDeData.Size = new System.Drawing.Size(15, 14);
            this.chkDeData.TabIndex = 4;
            this.chkDeData.UseVisualStyleBackColor = true;
            this.chkDeData.CheckedChanged += new System.EventHandler(this.chkDeData_CheckedChanged);
            // 
            // dtpAteData
            // 
            this.dtpAteData.Enabled = false;
            this.dtpAteData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAteData.Location = new System.Drawing.Point(27, 43);
            this.dtpAteData.Name = "dtpAteData";
            this.dtpAteData.Size = new System.Drawing.Size(90, 20);
            this.dtpAteData.TabIndex = 3;
            this.dtpAteData.ValueChanged += new System.EventHandler(this.dtpAteData_ValueChanged);
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
            // dtpDeData
            // 
            this.dtpDeData.Enabled = false;
            this.dtpDeData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDeData.Location = new System.Drawing.Point(27, 19);
            this.dtpDeData.Name = "dtpDeData";
            this.dtpDeData.Size = new System.Drawing.Size(90, 20);
            this.dtpDeData.TabIndex = 0;
            this.dtpDeData.ValueChanged += new System.EventHandler(this.dtpDeData_ValueChanged);
            // 
            // LogListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(682, 372);
            this.Controls.Add(this.splitContainer1);
            this.Name = "LogListForm";
            this.Text = "Log";
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
        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Timer timerBusca;
        private System.Windows.Forms.RadioButton rdbErros;
        private System.Windows.Forms.RadioButton rdbAviso;
        private System.Windows.Forms.RadioButton rdbInformacao;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkAteData;
        private System.Windows.Forms.CheckBox chkDeData;
        private System.Windows.Forms.DateTimePicker dtpAteData;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpDeData;
    }
}