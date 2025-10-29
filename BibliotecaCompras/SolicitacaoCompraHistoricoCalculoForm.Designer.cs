namespace BibliotecaCompras
{
    partial class SolicitacaoCompraHistoricoCalculoForm
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
            this.txtHistoricoCalculo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtHistoricoCalculo
            // 
            this.txtHistoricoCalculo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHistoricoCalculo.Location = new System.Drawing.Point(12, 12);
            this.txtHistoricoCalculo.Multiline = true;
            this.txtHistoricoCalculo.Name = "txtHistoricoCalculo";
            this.txtHistoricoCalculo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtHistoricoCalculo.Size = new System.Drawing.Size(743, 296);
            this.txtHistoricoCalculo.TabIndex = 0;
            // 
            // SolicitacaoCompraHistoricoCalculoForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(767, 320);
            this.Controls.Add(this.txtHistoricoCalculo);
            this.Name = "SolicitacaoCompraHistoricoCalculoForm";
            this.Text = "Histórico de Cálculo da SC";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtHistoricoCalculo;
    }
}