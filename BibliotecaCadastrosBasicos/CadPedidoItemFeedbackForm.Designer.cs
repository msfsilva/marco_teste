namespace BibliotecaCadastrosBasicos
{
    partial class CadPedidoItemFeedbackForm
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
            this.btnFeedbackOk = new IWTDotNetLib.IWTButton(this.components);
            this.txtFeedback = new IWTDotNetLib.IWTTextBox(this.components);
            this.SuspendLayout();
            // 
            // btnFeedbackOk
            // 
            this.btnFeedbackOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFeedbackOk.LiberadoQuandoCadastroUtilizado = false;
            this.btnFeedbackOk.Location = new System.Drawing.Point(276, 355);
            this.btnFeedbackOk.Name = "btnFeedbackOk";
            this.btnFeedbackOk.Size = new System.Drawing.Size(75, 23);
            this.btnFeedbackOk.TabIndex = 5;
            this.btnFeedbackOk.Text = "OK";
            this.btnFeedbackOk.UseVisualStyleBackColor = true;
            this.btnFeedbackOk.Click += new System.EventHandler(this.btnFeedbackOk_Click);
            // 
            // txtFeedback
            // 
            this.txtFeedback.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFeedback.BindingField = null;
            this.txtFeedback.LiberadoQuandoCadastroUtilizado = false;
            this.txtFeedback.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtFeedback.Location = new System.Drawing.Point(12, 8);
            this.txtFeedback.Multiline = true;
            this.txtFeedback.Name = "txtFeedback";
            this.txtFeedback.Size = new System.Drawing.Size(339, 341);
            this.txtFeedback.TabIndex = 4;
            // 
            // CadPedidoItemFeedbackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(363, 390);
            this.Controls.Add(this.btnFeedbackOk);
            this.Controls.Add(this.txtFeedback);
            this.Name = "CadPedidoItemFeedbackForm";
            this.Text = "Incluir Feedback";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IWTDotNetLib.IWTButton btnFeedbackOk;
        private IWTDotNetLib.IWTTextBox txtFeedback;
    }
}