namespace BibliotecaCompras
{
    partial class RecebimentoAprovacaoDivergencia
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
            this.lblDivergerncias = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAprovarDivergencia = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(388, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Foram encontradas as seguintes divergências durante o recebimento:";
            // 
            // lblDivergerncias
            // 
            this.lblDivergerncias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDivergerncias.Location = new System.Drawing.Point(33, 33);
            this.lblDivergerncias.Name = "lblDivergerncias";
            this.lblDivergerncias.Size = new System.Drawing.Size(512, 98);
            this.lblDivergerncias.TabIndex = 1;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.Location = new System.Drawing.Point(15, 145);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(138, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar Operação";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAprovarDivergencia
            // 
            this.btnAprovarDivergencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAprovarDivergencia.Location = new System.Drawing.Point(387, 145);
            this.btnAprovarDivergencia.Name = "btnAprovarDivergencia";
            this.btnAprovarDivergencia.Size = new System.Drawing.Size(158, 23);
            this.btnAprovarDivergencia.TabIndex = 3;
            this.btnAprovarDivergencia.Text = "Aprovar Divergência";
            this.btnAprovarDivergencia.UseVisualStyleBackColor = true;
            this.btnAprovarDivergencia.Click += new System.EventHandler(this.btnAprovarDivergencia_Click);
            // 
            // RecebimentoAprovacaoDivergencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 180);
            this.Controls.Add(this.btnAprovarDivergencia);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblDivergerncias);
            this.Controls.Add(this.label1);
            this.Name = "RecebimentoAprovacaoDivergencia";
            this.Text = "Divergência no Recebimento";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDivergerncias;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAprovarDivergencia;
    }
}