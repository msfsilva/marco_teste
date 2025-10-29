namespace BibliotecaAdministracaoSistema
{
    partial class EncerramentoSemanaConfCustomizadaForm
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
            this.btnEncerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPPS = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnEncerrar
            // 
            this.btnEncerrar.Location = new System.Drawing.Point(237, 57);
            this.btnEncerrar.Name = "btnEncerrar";
            this.btnEncerrar.Size = new System.Drawing.Size(75, 23);
            this.btnEncerrar.TabIndex = 1;
            this.btnEncerrar.Text = "Encerrar";
            this.btnEncerrar.UseVisualStyleBackColor = true;
            this.btnEncerrar.Click += new System.EventHandler(this.btnEncerrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Semana a Encerrar";
            // 
            // cmbPPS
            // 
            this.cmbPPS.FormattingEnabled = true;
            this.cmbPPS.Location = new System.Drawing.Point(116, 13);
            this.cmbPPS.Name = "cmbPPS";
            this.cmbPPS.Size = new System.Drawing.Size(150, 21);
            this.cmbPPS.TabIndex = 2;
            // 
            // EncerramentoSemanaConfCustomizadaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(324, 92);
            this.Controls.Add(this.cmbPPS);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEncerrar);
            this.Name = "EncerramentoSemanaConfCustomizadaForm";
            this.Text = "Encerramento de Semana";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEncerrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPPS;
    }
}