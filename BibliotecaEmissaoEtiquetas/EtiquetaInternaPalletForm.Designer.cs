namespace BibliotecaEmissaoEtiquetas
{
    partial class EtiquetaInternaPalletForm
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
            this.nudInicio = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudFim = new System.Windows.Forms.NumericUpDown();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudInicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFim)).BeginInit();
            this.SuspendLayout();
            // 
            // nudInicio
            // 
            this.nudInicio.Location = new System.Drawing.Point(58, 12);
            this.nudInicio.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudInicio.Name = "nudInicio";
            this.nudInicio.Size = new System.Drawing.Size(62, 20);
            this.nudInicio.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Início";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fim";
            // 
            // nudFim
            // 
            this.nudFim.Location = new System.Drawing.Point(58, 38);
            this.nudFim.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudFim.Name = "nudFim";
            this.nudFim.Size = new System.Drawing.Size(62, 20);
            this.nudFim.TabIndex = 2;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(223, 83);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // EtiquetaInternaPalletForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(310, 118);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudFim);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudInicio);
            this.Name = "EtiquetaInternaPalletForm";
            this.Text = "Geração de etiquetas interna Pallet";
            ((System.ComponentModel.ISupportInitialize)(this.nudInicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFim)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudInicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudFim;
        private System.Windows.Forms.Button btnOk;
    }
}