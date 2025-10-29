namespace BibliotecaEntidades.Operacoes.OrdemProducao
{
    partial class JustificarQtdMenorForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.rdbRepor = new System.Windows.Forms.RadioButton();
            this.rdbNaoRepor = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbJustificativa = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(367, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "A quantidade indicada na saída do posto atual é menor do que a quantidade previst" +
                "a.";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(304, 162);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // rdbRepor
            // 
            this.rdbRepor.AutoSize = true;
            this.rdbRepor.Checked = true;
            this.rdbRepor.Location = new System.Drawing.Point(29, 52);
            this.rdbRepor.Name = "rdbRepor";
            this.rdbRepor.Size = new System.Drawing.Size(152, 17);
            this.rdbRepor.TabIndex = 0;
            this.rdbRepor.TabStop = true;
            this.rdbRepor.Text = "Esse item deve ser reposto";
            this.rdbRepor.UseVisualStyleBackColor = true;
            // 
            // rdbNaoRepor
            // 
            this.rdbNaoRepor.AutoSize = true;
            this.rdbNaoRepor.Location = new System.Drawing.Point(29, 75);
            this.rdbNaoRepor.Name = "rdbNaoRepor";
            this.rdbNaoRepor.Size = new System.Drawing.Size(178, 17);
            this.rdbNaoRepor.TabIndex = 1;
            this.rdbNaoRepor.Text = "Esse item NÃO deve ser reposto";
            this.rdbNaoRepor.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Justificativa";
            // 
            // cmbJustificativa
            // 
            this.cmbJustificativa.FormattingEnabled = true;
            this.cmbJustificativa.Location = new System.Drawing.Point(29, 127);
            this.cmbJustificativa.Name = "cmbJustificativa";
            this.cmbJustificativa.Size = new System.Drawing.Size(337, 21);
            this.cmbJustificativa.TabIndex = 4;
            // 
            // JustificarQtdMenorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(391, 197);
            this.Controls.Add(this.cmbJustificativa);
            this.Controls.Add(this.rdbNaoRepor);
            this.Controls.Add(this.rdbRepor);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "JustificarQtdMenorForm";
            this.Text = "Justificativa de Redução de Quantidade";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.JustificarQtdMenorForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.RadioButton rdbRepor;
        private System.Windows.Forms.RadioButton rdbNaoRepor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbJustificativa;
    }
}