namespace BibliotecaCadastrosBasicos.NovaEstruturaProduto
{
    partial class NewConfigurarExibicaoEstruturaForm
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
            this.rdbHorizontal = new System.Windows.Forms.RadioButton();
            this.rdbVertical = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbArvoreHorizontal = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nudAlturaVertical = new System.Windows.Forms.NumericUpDown();
            this.lblAltura = new System.Windows.Forms.Label();
            this.nudLarguraVertical = new System.Windows.Forms.NumericUpDown();
            this.lblLargura = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nudTamanhoFonte = new System.Windows.Forms.NumericUpDown();
            this.chkNegrito = new System.Windows.Forms.CheckBox();
            this.btnFechar = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.nudAlturaHorizontal = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudLarguraHorizontal = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nudTamanhoFonteLigacao = new System.Windows.Forms.NumericUpDown();
            this.chkNegritoLigacao = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.nudAlturaArvoreHorizontal = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nudLarguraArvoreHorizontal = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlturaVertical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLarguraVertical)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTamanhoFonte)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlturaHorizontal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLarguraHorizontal)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTamanhoFonteLigacao)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlturaArvoreHorizontal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLarguraArvoreHorizontal)).BeginInit();
            this.SuspendLayout();
            // 
            // rdbHorizontal
            // 
            this.rdbHorizontal.Location = new System.Drawing.Point(82, 19);
            this.rdbHorizontal.Name = "rdbHorizontal";
            this.rdbHorizontal.Size = new System.Drawing.Size(72, 17);
            this.rdbHorizontal.TabIndex = 5;
            this.rdbHorizontal.Text = "Horizontal";
            this.rdbHorizontal.UseVisualStyleBackColor = true;
            this.rdbHorizontal.CheckedChanged += new System.EventHandler(this.rdbHorizontal_CheckedChanged);
            // 
            // rdbVertical
            // 
            this.rdbVertical.Checked = true;
            this.rdbVertical.Location = new System.Drawing.Point(16, 19);
            this.rdbVertical.Name = "rdbVertical";
            this.rdbVertical.Size = new System.Drawing.Size(60, 17);
            this.rdbVertical.TabIndex = 4;
            this.rdbVertical.TabStop = true;
            this.rdbVertical.Text = "Vertical";
            this.rdbVertical.UseVisualStyleBackColor = true;
            this.rdbVertical.CheckedChanged += new System.EventHandler(this.rdbVertical_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbArvoreHorizontal);
            this.groupBox1.Controls.Add(this.rdbHorizontal);
            this.groupBox1.Controls.Add(this.rdbVertical);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 45);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modo de Exibição Padrão";
            // 
            // rdbArvoreHorizontal
            // 
            this.rdbArvoreHorizontal.Location = new System.Drawing.Point(160, 19);
            this.rdbArvoreHorizontal.Name = "rdbArvoreHorizontal";
            this.rdbArvoreHorizontal.Size = new System.Drawing.Size(125, 17);
            this.rdbArvoreHorizontal.TabIndex = 7;
            this.rdbArvoreHorizontal.Text = "Árvore Horizontal";
            this.rdbArvoreHorizontal.UseVisualStyleBackColor = true;
            this.rdbArvoreHorizontal.CheckedChanged += new System.EventHandler(this.rdbArvoreHorizontal_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nudAlturaVertical);
            this.groupBox2.Controls.Add(this.lblAltura);
            this.groupBox2.Controls.Add(this.nudLarguraVertical);
            this.groupBox2.Controls.Add(this.lblLargura);
            this.groupBox2.Location = new System.Drawing.Point(12, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(377, 49);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dimensão dos Objetos no Modo Vertical";
            // 
            // nudAlturaVertical
            // 
            this.nudAlturaVertical.Location = new System.Drawing.Point(233, 21);
            this.nudAlturaVertical.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudAlturaVertical.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAlturaVertical.Name = "nudAlturaVertical";
            this.nudAlturaVertical.Size = new System.Drawing.Size(60, 20);
            this.nudAlturaVertical.TabIndex = 3;
            this.nudAlturaVertical.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAlturaVertical.ValueChanged += new System.EventHandler(this.nudAltura_ValueChanged);
            // 
            // lblAltura
            // 
            this.lblAltura.AutoSize = true;
            this.lblAltura.Location = new System.Drawing.Point(193, 23);
            this.lblAltura.Name = "lblAltura";
            this.lblAltura.Size = new System.Drawing.Size(34, 13);
            this.lblAltura.TabIndex = 2;
            this.lblAltura.Text = "Altura";
            // 
            // nudLarguraVertical
            // 
            this.nudLarguraVertical.Location = new System.Drawing.Point(66, 21);
            this.nudLarguraVertical.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudLarguraVertical.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLarguraVertical.Name = "nudLarguraVertical";
            this.nudLarguraVertical.Size = new System.Drawing.Size(60, 20);
            this.nudLarguraVertical.TabIndex = 1;
            this.nudLarguraVertical.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLarguraVertical.ValueChanged += new System.EventHandler(this.nudLargura_ValueChanged);
            // 
            // lblLargura
            // 
            this.lblLargura.AutoSize = true;
            this.lblLargura.Location = new System.Drawing.Point(17, 23);
            this.lblLargura.Name = "lblLargura";
            this.lblLargura.Size = new System.Drawing.Size(43, 13);
            this.lblLargura.TabIndex = 0;
            this.lblLargura.Text = "Largura";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.nudTamanhoFonte);
            this.groupBox3.Controls.Add(this.chkNegrito);
            this.groupBox3.Location = new System.Drawing.Point(12, 228);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(377, 49);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Fonte";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(178, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tamanho";
            // 
            // nudTamanhoFonte
            // 
            this.nudTamanhoFonte.Location = new System.Drawing.Point(233, 18);
            this.nudTamanhoFonte.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTamanhoFonte.Name = "nudTamanhoFonte";
            this.nudTamanhoFonte.Size = new System.Drawing.Size(60, 20);
            this.nudTamanhoFonte.TabIndex = 4;
            this.nudTamanhoFonte.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTamanhoFonte.ValueChanged += new System.EventHandler(this.nudTamanhoFonte_ValueChanged);
            // 
            // chkNegrito
            // 
            this.chkNegrito.AutoSize = true;
            this.chkNegrito.Location = new System.Drawing.Point(16, 19);
            this.chkNegrito.Name = "chkNegrito";
            this.chkNegrito.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkNegrito.Size = new System.Drawing.Size(60, 17);
            this.chkNegrito.TabIndex = 0;
            this.chkNegrito.Text = "Negrito";
            this.chkNegrito.UseVisualStyleBackColor = true;
            this.chkNegrito.CheckedChanged += new System.EventHandler(this.chkNegrito_CheckedChanged);
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFechar.Location = new System.Drawing.Point(12, 346);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 10;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.nudAlturaHorizontal);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.nudLarguraHorizontal);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Location = new System.Drawing.Point(12, 118);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(377, 49);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Dimensão dos Objetos no Modo Horizontal";
            // 
            // nudAlturaHorizontal
            // 
            this.nudAlturaHorizontal.Location = new System.Drawing.Point(233, 21);
            this.nudAlturaHorizontal.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudAlturaHorizontal.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAlturaHorizontal.Name = "nudAlturaHorizontal";
            this.nudAlturaHorizontal.Size = new System.Drawing.Size(60, 20);
            this.nudAlturaHorizontal.TabIndex = 3;
            this.nudAlturaHorizontal.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAlturaHorizontal.ValueChanged += new System.EventHandler(this.nudAlturaHorizontal_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Altura";
            // 
            // nudLarguraHorizontal
            // 
            this.nudLarguraHorizontal.Location = new System.Drawing.Point(66, 21);
            this.nudLarguraHorizontal.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudLarguraHorizontal.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLarguraHorizontal.Name = "nudLarguraHorizontal";
            this.nudLarguraHorizontal.Size = new System.Drawing.Size(60, 20);
            this.nudLarguraHorizontal.TabIndex = 1;
            this.nudLarguraHorizontal.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLarguraHorizontal.ValueChanged += new System.EventHandler(this.nudLarguraHorizontal_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Largura";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.nudTamanhoFonteLigacao);
            this.groupBox5.Controls.Add(this.chkNegritoLigacao);
            this.groupBox5.Location = new System.Drawing.Point(12, 283);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(377, 49);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Fonte Informações Ligação";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(178, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tamanho";
            // 
            // nudTamanhoFonteLigacao
            // 
            this.nudTamanhoFonteLigacao.Location = new System.Drawing.Point(233, 18);
            this.nudTamanhoFonteLigacao.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTamanhoFonteLigacao.Name = "nudTamanhoFonteLigacao";
            this.nudTamanhoFonteLigacao.Size = new System.Drawing.Size(60, 20);
            this.nudTamanhoFonteLigacao.TabIndex = 4;
            this.nudTamanhoFonteLigacao.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTamanhoFonteLigacao.ValueChanged += new System.EventHandler(this.nudTamanhoFonteLigacao_ValueChanged);
            // 
            // chkNegritoLigacao
            // 
            this.chkNegritoLigacao.AutoSize = true;
            this.chkNegritoLigacao.Location = new System.Drawing.Point(16, 19);
            this.chkNegritoLigacao.Name = "chkNegritoLigacao";
            this.chkNegritoLigacao.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkNegritoLigacao.Size = new System.Drawing.Size(60, 17);
            this.chkNegritoLigacao.TabIndex = 0;
            this.chkNegritoLigacao.Text = "Negrito";
            this.chkNegritoLigacao.UseVisualStyleBackColor = true;
            this.chkNegritoLigacao.CheckedChanged += new System.EventHandler(this.chkNegritoLigacao_CheckedChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.nudAlturaArvoreHorizontal);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.nudLarguraArvoreHorizontal);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Location = new System.Drawing.Point(12, 173);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(377, 49);
            this.groupBox6.TabIndex = 9;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Dimensão dos Objetos no Modo Árvore Horizontal";
            // 
            // nudAlturaArvoreHorizontal
            // 
            this.nudAlturaArvoreHorizontal.Location = new System.Drawing.Point(233, 21);
            this.nudAlturaArvoreHorizontal.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudAlturaArvoreHorizontal.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAlturaArvoreHorizontal.Name = "nudAlturaArvoreHorizontal";
            this.nudAlturaArvoreHorizontal.Size = new System.Drawing.Size(60, 20);
            this.nudAlturaArvoreHorizontal.TabIndex = 3;
            this.nudAlturaArvoreHorizontal.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAlturaArvoreHorizontal.ValueChanged += new System.EventHandler(this.nudAlturaArvoreHorizontal_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(193, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Altura";
            // 
            // nudLarguraArvoreHorizontal
            // 
            this.nudLarguraArvoreHorizontal.Location = new System.Drawing.Point(66, 21);
            this.nudLarguraArvoreHorizontal.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudLarguraArvoreHorizontal.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLarguraArvoreHorizontal.Name = "nudLarguraArvoreHorizontal";
            this.nudLarguraArvoreHorizontal.Size = new System.Drawing.Size(60, 20);
            this.nudLarguraArvoreHorizontal.TabIndex = 1;
            this.nudLarguraArvoreHorizontal.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLarguraArvoreHorizontal.ValueChanged += new System.EventHandler(this.nudLarguraArvoreHorizontal_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Largura";
            // 
            // ConfigurarExibicaoEstruturaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(420, 381);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ConfigurarExibicaoEstruturaForm";
            this.Text = "Configuração da Tela de Estrutura de Produto";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigurarExibicaoEstruturaForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlturaVertical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLarguraVertical)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTamanhoFonte)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlturaHorizontal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLarguraHorizontal)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTamanhoFonteLigacao)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlturaArvoreHorizontal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLarguraArvoreHorizontal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbHorizontal;
        private System.Windows.Forms.RadioButton rdbVertical;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nudAlturaVertical;
        private System.Windows.Forms.Label lblAltura;
        private System.Windows.Forms.NumericUpDown nudLarguraVertical;
        private System.Windows.Forms.Label lblLargura;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudTamanhoFonte;
        private System.Windows.Forms.CheckBox chkNegrito;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown nudAlturaHorizontal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudLarguraHorizontal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudTamanhoFonteLigacao;
        private System.Windows.Forms.CheckBox chkNegritoLigacao;
        private System.Windows.Forms.RadioButton rdbArvoreHorizontal;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.NumericUpDown nudAlturaArvoreHorizontal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudLarguraArvoreHorizontal;
        private System.Windows.Forms.Label label6;
    }
}