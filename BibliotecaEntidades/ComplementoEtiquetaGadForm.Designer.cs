namespace BibliotecaEntidades
{
    partial class ComplementoEtiquetaGadForm
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
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtBarcode = new IWTDotNetLib.IWTTextBox(this.components);
            this.SuspendLayout();
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(12, 18);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(355, 17);
            this.iwtLabel1.TabIndex = 0;
            this.iwtLabel1.Text = "Leia o código de barras INFERIOR da etiqueta do GAD";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBarcode.BindingField = null;
            this.txtBarcode.DebugMode = false;
            this.txtBarcode.LiberadoQuandoCadastroUtilizado = false;
            this.txtBarcode.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtBarcode.Location = new System.Drawing.Point(15, 49);
            this.txtBarcode.ModoBarcode = true;
            this.txtBarcode.ModoBusca = false;
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.NaoLimparDepoisBarcode = false;
            this.txtBarcode.Size = new System.Drawing.Size(457, 20);
            this.txtBarcode.TabIndex = 1;
            this.txtBarcode.OperacaoBarcodeEncerrada += new IWTDotNetLib.IWTTextBox.OperacaoBarcodeEncerradaDelegate(this.txtBarcode_OperacaoBarcodeEncerrada);
            // 
            // ComplementoEtiquetaGadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 92);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.iwtLabel1);
            this.Name = "ComplementoEtiquetaGadForm";
            this.Text = "Complemento Etiqueta GAD";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTTextBox txtBarcode;
    }
}