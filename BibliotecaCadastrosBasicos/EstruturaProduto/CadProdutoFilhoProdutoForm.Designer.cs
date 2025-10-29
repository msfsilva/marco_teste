namespace BibliotecaCadastrosBasicos.EstruturaProduto
{
    partial class CadProdutoFilhoProdutoForm
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
            this.btnOk = new System.Windows.Forms.Button();
            this.nudQuantidade = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPosicaoDesenhoPai = new System.Windows.Forms.TextBox();
            this.chkCondicional = new System.Windows.Forms.CheckBox();
            this.txtRegraCondicional = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.txtQtdCondicionalRegra = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.rdbQtdCondicional = new System.Windows.Forms.RadioButton();
            this.rdbQtdFixa = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidade)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(288, 336);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // nudQuantidade
            // 
            this.nudQuantidade.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudQuantidade.DecimalPlaces = 5;
            this.nudQuantidade.Location = new System.Drawing.Point(25, 27);
            this.nudQuantidade.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudQuantidade.Name = "nudQuantidade";
            this.nudQuantidade.Size = new System.Drawing.Size(300, 20);
            this.nudQuantidade.TabIndex = 1;
            this.nudQuantidade.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Quantidade do Item por Unidade do Pai";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Posição no Desenho do Pai";
            // 
            // txtPosicaoDesenhoPai
            // 
            this.txtPosicaoDesenhoPai.Location = new System.Drawing.Point(27, 194);
            this.txtPosicaoDesenhoPai.MaxLength = 5;
            this.txtPosicaoDesenhoPai.Name = "txtPosicaoDesenhoPai";
            this.txtPosicaoDesenhoPai.Size = new System.Drawing.Size(181, 20);
            this.txtPosicaoDesenhoPai.TabIndex = 4;
            // 
            // chkCondicional
            // 
            this.chkCondicional.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkCondicional.AutoSize = true;
            this.chkCondicional.Location = new System.Drawing.Point(331, 234);
            this.chkCondicional.Name = "chkCondicional";
            this.chkCondicional.Size = new System.Drawing.Size(15, 14);
            this.chkCondicional.TabIndex = 5;
            this.chkCondicional.UseVisualStyleBackColor = true;
            this.chkCondicional.CheckedChanged += new System.EventHandler(this.chkCondicional_CheckedChanged);
            // 
            // txtRegraCondicional
            // 
            this.txtRegraCondicional.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegraCondicional.Enabled = false;
            this.txtRegraCondicional.Location = new System.Drawing.Point(25, 234);
            this.txtRegraCondicional.Multiline = true;
            this.txtRegraCondicional.Name = "txtRegraCondicional";
            this.txtRegraCondicional.Size = new System.Drawing.Size(300, 75);
            this.txtRegraCondicional.TabIndex = 6;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(22, 218);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(105, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Inclusão Condicional";
            // 
            // txtQtdCondicionalRegra
            // 
            this.txtQtdCondicionalRegra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQtdCondicionalRegra.Enabled = false;
            this.txtQtdCondicionalRegra.Location = new System.Drawing.Point(25, 66);
            this.txtQtdCondicionalRegra.Multiline = true;
            this.txtQtdCondicionalRegra.Name = "txtQtdCondicionalRegra";
            this.txtQtdCondicionalRegra.Size = new System.Drawing.Size(300, 72);
            this.txtQtdCondicionalRegra.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 50);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(120, 13);
            this.label13.TabIndex = 11;
            this.label13.Text = "Quantidade Condicional";
            // 
            // rdbQtdCondicional
            // 
            this.rdbQtdCondicional.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbQtdCondicional.AutoSize = true;
            this.rdbQtdCondicional.Location = new System.Drawing.Point(331, 69);
            this.rdbQtdCondicional.Name = "rdbQtdCondicional";
            this.rdbQtdCondicional.Size = new System.Drawing.Size(14, 13);
            this.rdbQtdCondicional.TabIndex = 2;
            this.rdbQtdCondicional.UseVisualStyleBackColor = true;
            this.rdbQtdCondicional.CheckedChanged += new System.EventHandler(this.rdbQtdCondicional_CheckedChanged);
            // 
            // rdbQtdFixa
            // 
            this.rdbQtdFixa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbQtdFixa.AutoSize = true;
            this.rdbQtdFixa.Checked = true;
            this.rdbQtdFixa.Location = new System.Drawing.Point(331, 29);
            this.rdbQtdFixa.Name = "rdbQtdFixa";
            this.rdbQtdFixa.Size = new System.Drawing.Size(14, 13);
            this.rdbQtdFixa.TabIndex = 0;
            this.rdbQtdFixa.TabStop = true;
            this.rdbQtdFixa.UseVisualStyleBackColor = true;
            this.rdbQtdFixa.CheckedChanged += new System.EventHandler(this.rdbQtdFixa_CheckedChanged);
            // 
            // CadProdutoFilhoProdutoForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(375, 371);
            this.Controls.Add(this.rdbQtdFixa);
            this.Controls.Add(this.txtQtdCondicionalRegra);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.rdbQtdCondicional);
            this.Controls.Add(this.chkCondicional);
            this.Controls.Add(this.txtRegraCondicional);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtPosicaoDesenhoPai);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.nudQuantidade);
            this.Controls.Add(this.label1);
            this.Name = "CadProdutoFilhoProdutoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quantidade";
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.NumericUpDown nudQuantidade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPosicaoDesenhoPai;
        private System.Windows.Forms.CheckBox chkCondicional;
        private System.Windows.Forms.TextBox txtRegraCondicional;
        private System.Windows.Forms.Label label12;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox txtQtdCondicionalRegra;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RadioButton rdbQtdCondicional;
        private System.Windows.Forms.RadioButton rdbQtdFixa;
    }
}