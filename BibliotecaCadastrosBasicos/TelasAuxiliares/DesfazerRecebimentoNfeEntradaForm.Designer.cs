namespace BibliotecaCadastrosBasicos.TelasAuxiliares
{
    partial class DesfazerRecebimentoNfeEntradaForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtCNPJ = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.btnDesfazerRecebimento = new IWTDotNetLib.IWTButton(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(574, 57);
            this.label1.TabIndex = 0;
            this.label1.Text = "Essa operação irá desfazer o recebimento de uma nota fiscal de entrada, depois de" +
    " executada não poderá ser desfeita e todo o recebimento deverá ser feito novamen" +
    "te se for necessário";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCNPJ
            // 
            this.txtCNPJ.Location = new System.Drawing.Point(123, 80);
            this.txtCNPJ.Name = "txtCNPJ";
            this.txtCNPJ.Size = new System.Drawing.Size(188, 20);
            this.txtCNPJ.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "CNPJ do Fornecedor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Série da NFe";
            // 
            // txtSerie
            // 
            this.txtSerie.Location = new System.Drawing.Point(123, 106);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(188, 20);
            this.txtSerie.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Número da NFe";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(123, 132);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(188, 20);
            this.txtNumero.TabIndex = 5;
            // 
            // btnDesfazerRecebimento
            // 
            this.btnDesfazerRecebimento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDesfazerRecebimento.LiberadoQuandoCadastroUtilizado = false;
            this.btnDesfazerRecebimento.Location = new System.Drawing.Point(419, 167);
            this.btnDesfazerRecebimento.Name = "btnDesfazerRecebimento";
            this.btnDesfazerRecebimento.Size = new System.Drawing.Size(158, 23);
            this.btnDesfazerRecebimento.TabIndex = 7;
            this.btnDesfazerRecebimento.Text = "Desfazer Recebimento";
            this.btnDesfazerRecebimento.UseVisualStyleBackColor = true;
            this.btnDesfazerRecebimento.Click += new System.EventHandler(this.btnDesfazerRecebimento_Click);
            // 
            // DesfazerRecebimentoNfeEntradaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 202);
            this.Controls.Add(this.btnDesfazerRecebimento);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSerie);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCNPJ);
            this.Controls.Add(this.label1);
            this.Name = "DesfazerRecebimentoNfeEntradaForm";
            this.Text = "Desfazer Recebimento de NFe de Entrada";
            this.Load += new System.EventHandler(this.DesfazerRecebimentoNfeEntradaForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCNPJ;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNumero;
        private IWTDotNetLib.IWTButton btnDesfazerRecebimento;
    }
}