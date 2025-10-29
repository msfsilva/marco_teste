namespace BibliotecaEntidades.Operacoes.OrdemProducao
{
    partial class JustificarQtdMaiorForm
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
            this.rdbDescartar = new System.Windows.Forms.RadioButton();
            this.rdbCliente = new System.Windows.Forms.RadioButton();
            this.rdbEstoque = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
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
            this.label1.TabIndex = 1;
            this.label1.Text = "A quantidade indicada na saída do último posto é maior do que a quantidade previs" +
                "ta.";
            // 
            // rdbDescartar
            // 
            this.rdbDescartar.AutoSize = true;
            this.rdbDescartar.Checked = true;
            this.rdbDescartar.Location = new System.Drawing.Point(15, 52);
            this.rdbDescartar.Name = "rdbDescartar";
            this.rdbDescartar.Size = new System.Drawing.Size(102, 17);
            this.rdbDescartar.TabIndex = 0;
            this.rdbDescartar.TabStop = true;
            this.rdbDescartar.Text = "Descartar Sobra";
            this.rdbDescartar.UseVisualStyleBackColor = true;
            // 
            // rdbCliente
            // 
            this.rdbCliente.AutoSize = true;
            this.rdbCliente.Location = new System.Drawing.Point(15, 75);
            this.rdbCliente.Name = "rdbCliente";
            this.rdbCliente.Size = new System.Drawing.Size(123, 17);
            this.rdbCliente.TabIndex = 1;
            this.rdbCliente.Text = "Enviar para o Cliente";
            this.rdbCliente.UseVisualStyleBackColor = true;
            // 
            // rdbEstoque
            // 
            this.rdbEstoque.AutoSize = true;
            this.rdbEstoque.Enabled = false;
            this.rdbEstoque.Location = new System.Drawing.Point(15, 98);
            this.rdbEstoque.Name = "rdbEstoque";
            this.rdbEstoque.Size = new System.Drawing.Size(130, 17);
            this.rdbEstoque.TabIndex = 2;
            this.rdbEstoque.Text = "Enviar para o Estoque";
            this.rdbEstoque.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(304, 186);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Justificativa";
            // 
            // cmbJustificativa
            // 
            this.cmbJustificativa.FormattingEnabled = true;
            this.cmbJustificativa.Location = new System.Drawing.Point(25, 144);
            this.cmbJustificativa.Name = "cmbJustificativa";
            this.cmbJustificativa.Size = new System.Drawing.Size(337, 21);
            this.cmbJustificativa.TabIndex = 7;
            // 
            // JustificarQtdMaiorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(391, 221);
            this.Controls.Add(this.cmbJustificativa);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rdbEstoque);
            this.Controls.Add(this.rdbCliente);
            this.Controls.Add(this.rdbDescartar);
            this.Controls.Add(this.label1);
            this.Name = "JustificarQtdMaiorForm";
            this.Text = "Justificativa de Aumento de Quantidade";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.JustificarQtdMaiorForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbDescartar;
        private System.Windows.Forms.RadioButton rdbCliente;
        private System.Windows.Forms.RadioButton rdbEstoque;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbJustificativa;
    }
}