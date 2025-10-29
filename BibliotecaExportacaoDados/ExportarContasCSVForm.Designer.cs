namespace BibliotecaExportacaoDados
{
    partial class ExportarContasCSVForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbTodas = new System.Windows.Forms.RadioButton();
            this.rdbReceber = new System.Windows.Forms.RadioButton();
            this.rdbPagar = new System.Windows.Forms.RadioButton();
            this.btnDiretorioSaida = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdbSituacaoTodas = new System.Windows.Forms.RadioButton();
            this.rdbSituacaoPagas = new System.Windows.Forms.RadioButton();
            this.rdbSituacaoAbertas = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkDataFim = new System.Windows.Forms.CheckBox();
            this.chkDataInicio = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDataFim = new System.Windows.Forms.DateTimePicker();
            this.dtpDataInicio = new System.Windows.Forms.DateTimePicker();
            this.btnExportar = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.btnDiretorioSaida);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.textBox1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnExportar);
            this.splitContainer1.Size = new System.Drawing.Size(476, 282);
            this.splitContainer1.SplitterDistance = 215;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbTodas);
            this.groupBox2.Controls.Add(this.rdbReceber);
            this.groupBox2.Controls.Add(this.rdbPagar);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(452, 49);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo";
            // 
            // rdbTodas
            // 
            this.rdbTodas.AutoSize = true;
            this.rdbTodas.Checked = true;
            this.rdbTodas.Location = new System.Drawing.Point(384, 19);
            this.rdbTodas.Name = "rdbTodas";
            this.rdbTodas.Size = new System.Drawing.Size(55, 17);
            this.rdbTodas.TabIndex = 2;
            this.rdbTodas.TabStop = true;
            this.rdbTodas.Text = "Todas";
            this.rdbTodas.UseVisualStyleBackColor = true;
            // 
            // rdbReceber
            // 
            this.rdbReceber.AutoSize = true;
            this.rdbReceber.Location = new System.Drawing.Point(192, 19);
            this.rdbReceber.Name = "rdbReceber";
            this.rdbReceber.Size = new System.Drawing.Size(111, 17);
            this.rdbReceber.TabIndex = 1;
            this.rdbReceber.Text = "Contas a Receber";
            this.rdbReceber.UseVisualStyleBackColor = true;
            // 
            // rdbPagar
            // 
            this.rdbPagar.AutoSize = true;
            this.rdbPagar.Location = new System.Drawing.Point(13, 18);
            this.rdbPagar.Name = "rdbPagar";
            this.rdbPagar.Size = new System.Drawing.Size(98, 17);
            this.rdbPagar.TabIndex = 0;
            this.rdbPagar.Text = "Contas a Pagar";
            this.rdbPagar.UseVisualStyleBackColor = true;
            // 
            // btnDiretorioSaida
            // 
            this.btnDiretorioSaida.Location = new System.Drawing.Point(433, 168);
            this.btnDiretorioSaida.Name = "btnDiretorioSaida";
            this.btnDiretorioSaida.Size = new System.Drawing.Size(31, 23);
            this.btnDiretorioSaida.TabIndex = 3;
            this.btnDiretorioSaida.Text = "...";
            this.btnDiretorioSaida.UseVisualStyleBackColor = true;
            this.btnDiretorioSaida.Click += new System.EventHandler(this.btnDiretorioSaida_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 173);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Diretório de Saída";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(119, 170);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(308, 20);
            this.textBox1.TabIndex = 8;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdbSituacaoTodas);
            this.groupBox3.Controls.Add(this.rdbSituacaoPagas);
            this.groupBox3.Controls.Add(this.rdbSituacaoAbertas);
            this.groupBox3.Location = new System.Drawing.Point(246, 67);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(218, 91);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Situação";
            // 
            // rdbSituacaoTodas
            // 
            this.rdbSituacaoTodas.AutoSize = true;
            this.rdbSituacaoTodas.Checked = true;
            this.rdbSituacaoTodas.Location = new System.Drawing.Point(6, 62);
            this.rdbSituacaoTodas.Name = "rdbSituacaoTodas";
            this.rdbSituacaoTodas.Size = new System.Drawing.Size(55, 17);
            this.rdbSituacaoTodas.TabIndex = 2;
            this.rdbSituacaoTodas.TabStop = true;
            this.rdbSituacaoTodas.Text = "Todas";
            this.rdbSituacaoTodas.UseVisualStyleBackColor = true;
            // 
            // rdbSituacaoPagas
            // 
            this.rdbSituacaoPagas.AutoSize = true;
            this.rdbSituacaoPagas.Location = new System.Drawing.Point(6, 40);
            this.rdbSituacaoPagas.Name = "rdbSituacaoPagas";
            this.rdbSituacaoPagas.Size = new System.Drawing.Size(111, 17);
            this.rdbSituacaoPagas.TabIndex = 1;
            this.rdbSituacaoPagas.Text = "Pagas/Recebidas";
            this.rdbSituacaoPagas.UseVisualStyleBackColor = true;
            // 
            // rdbSituacaoAbertas
            // 
            this.rdbSituacaoAbertas.AutoSize = true;
            this.rdbSituacaoAbertas.Location = new System.Drawing.Point(6, 18);
            this.rdbSituacaoAbertas.Name = "rdbSituacaoAbertas";
            this.rdbSituacaoAbertas.Size = new System.Drawing.Size(61, 17);
            this.rdbSituacaoAbertas.TabIndex = 0;
            this.rdbSituacaoAbertas.Text = "Abertas";
            this.rdbSituacaoAbertas.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkDataFim);
            this.groupBox1.Controls.Add(this.chkDataInicio);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpDataFim);
            this.groupBox1.Controls.Add(this.dtpDataInicio);
            this.groupBox1.Location = new System.Drawing.Point(12, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 91);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Vencimento/Pagamento";
            // 
            // chkDataFim
            // 
            this.chkDataFim.AutoSize = true;
            this.chkDataFim.Location = new System.Drawing.Point(170, 49);
            this.chkDataFim.Name = "chkDataFim";
            this.chkDataFim.Size = new System.Drawing.Size(15, 14);
            this.chkDataFim.TabIndex = 2;
            this.chkDataFim.UseVisualStyleBackColor = true;
            this.chkDataFim.CheckedChanged += new System.EventHandler(this.chkDataFim_CheckedChanged);
            // 
            // chkDataInicio
            // 
            this.chkDataInicio.AutoSize = true;
            this.chkDataInicio.Location = new System.Drawing.Point(170, 22);
            this.chkDataInicio.Name = "chkDataInicio";
            this.chkDataInicio.Size = new System.Drawing.Size(15, 14);
            this.chkDataInicio.TabIndex = 0;
            this.chkDataInicio.UseVisualStyleBackColor = true;
            this.chkDataInicio.CheckedChanged += new System.EventHandler(this.chkDataInicio_CheckedChanged);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Inicio";
            // 
            // dtpDataFim
            // 
            this.dtpDataFim.Enabled = false;
            this.dtpDataFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataFim.Location = new System.Drawing.Point(45, 45);
            this.dtpDataFim.Name = "dtpDataFim";
            this.dtpDataFim.Size = new System.Drawing.Size(119, 20);
            this.dtpDataFim.TabIndex = 3;
            // 
            // dtpDataInicio
            // 
            this.dtpDataInicio.Enabled = false;
            this.dtpDataInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataInicio.Location = new System.Drawing.Point(45, 19);
            this.dtpDataInicio.Name = "dtpDataInicio";
            this.dtpDataInicio.Size = new System.Drawing.Size(119, 20);
            this.dtpDataInicio.TabIndex = 1;
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
            // ExportarContasCSVForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(476, 282);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ExportarContasCSVForm";
            this.Text = "Exportar Contas em CSV";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbTodas;
        private System.Windows.Forms.RadioButton rdbReceber;
        private System.Windows.Forms.RadioButton rdbPagar;
        private System.Windows.Forms.Button btnDiretorioSaida;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdbSituacaoTodas;
        private System.Windows.Forms.RadioButton rdbSituacaoPagas;
        private System.Windows.Forms.RadioButton rdbSituacaoAbertas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkDataFim;
        private System.Windows.Forms.CheckBox chkDataInicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDataFim;
        private System.Windows.Forms.DateTimePicker dtpDataInicio;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}