using IWTCustomControls;

namespace BibliotecaExpedicao
{
    partial class EmbarqueLiberacaoForm
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
            this.grbModoOperacao = new System.Windows.Forms.GroupBox();
            this.rdbBarCode = new System.Windows.Forms.RadioButton();
            this.rdbManual = new System.Windows.Forms.RadioButton();
            this.grbCaixa = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBarcodeEmbarque = new BarcodeTextBox(this.components);
            this.btnEmbarque = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.grbModoOperacao.SuspendLayout();
            this.grbCaixa.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbModoOperacao
            // 
            this.grbModoOperacao.Controls.Add(this.rdbBarCode);
            this.grbModoOperacao.Controls.Add(this.rdbManual);
            this.grbModoOperacao.Location = new System.Drawing.Point(12, 12);
            this.grbModoOperacao.Name = "grbModoOperacao";
            this.grbModoOperacao.Size = new System.Drawing.Size(185, 51);
            this.grbModoOperacao.TabIndex = 1;
            this.grbModoOperacao.TabStop = false;
            this.grbModoOperacao.Text = "Modo de Operação";
            // 
            // rdbBarCode
            // 
            this.rdbBarCode.AutoSize = true;
            this.rdbBarCode.Checked = true;
            this.rdbBarCode.Location = new System.Drawing.Point(6, 19);
            this.rdbBarCode.Name = "rdbBarCode";
            this.rdbBarCode.Size = new System.Drawing.Size(91, 17);
            this.rdbBarCode.TabIndex = 0;
            this.rdbBarCode.TabStop = true;
            this.rdbBarCode.Text = "Código Barras";
            this.rdbBarCode.UseVisualStyleBackColor = true;
            this.rdbBarCode.CheckedChanged += new System.EventHandler(this.rdbBarCode_CheckedChanged);
            // 
            // rdbManual
            // 
            this.rdbManual.AutoSize = true;
            this.rdbManual.Location = new System.Drawing.Point(97, 19);
            this.rdbManual.Name = "rdbManual";
            this.rdbManual.Size = new System.Drawing.Size(60, 17);
            this.rdbManual.TabIndex = 1;
            this.rdbManual.Text = "Manual";
            this.rdbManual.UseVisualStyleBackColor = true;
            this.rdbManual.CheckedChanged += new System.EventHandler(this.rdbManual_CheckedChanged);
            // 
            // grbCaixa
            // 
            this.grbCaixa.Controls.Add(this.label1);
            this.grbCaixa.Controls.Add(this.txtBarcodeEmbarque);
            this.grbCaixa.Controls.Add(this.btnEmbarque);
            this.grbCaixa.Location = new System.Drawing.Point(12, 69);
            this.grbCaixa.Name = "grbCaixa";
            this.grbCaixa.Size = new System.Drawing.Size(382, 51);
            this.grbCaixa.TabIndex = 0;
            this.grbCaixa.TabStop = false;
            this.grbCaixa.Text = "Seleção do Embarque";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Identificador do Embarque";
            // 
            // txtBarcodeEmbarque
            // 
            this.txtBarcodeEmbarque.Location = new System.Drawing.Point(153, 17);
            this.txtBarcodeEmbarque.Name = "txtBarcodeEmbarque";
            this.txtBarcodeEmbarque.Size = new System.Drawing.Size(149, 20);
            this.txtBarcodeEmbarque.TabIndex = 0;
            this.txtBarcodeEmbarque.TextChanged += new System.EventHandler(this.txtBarcodePallet_TextChanged);
            // 
            // btnEmbarque
            // 
            this.btnEmbarque.Enabled = false;
            this.btnEmbarque.Location = new System.Drawing.Point(308, 15);
            this.btnEmbarque.Name = "btnEmbarque";
            this.btnEmbarque.Size = new System.Drawing.Size(47, 23);
            this.btnEmbarque.TabIndex = 1;
            this.btnEmbarque.Text = "OK";
            this.btnEmbarque.UseVisualStyleBackColor = true;
            this.btnEmbarque.Click += new System.EventHandler(this.btnPallet_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // EmbarqueLiberacaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(425, 140);
            this.Controls.Add(this.grbCaixa);
            this.Controls.Add(this.grbModoOperacao);
            this.Name = "EmbarqueLiberacaoForm";
            this.Text = "Liberação de Embarque";
            this.grbModoOperacao.ResumeLayout(false);
            this.grbModoOperacao.PerformLayout();
            this.grbCaixa.ResumeLayout(false);
            this.grbCaixa.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbModoOperacao;
        private System.Windows.Forms.RadioButton rdbBarCode;
        private System.Windows.Forms.RadioButton rdbManual;
        private System.Windows.Forms.GroupBox grbCaixa;
        private System.Windows.Forms.Label label1;
        private IWTCustomControls.BarcodeTextBox txtBarcodeEmbarque;
        private System.Windows.Forms.Button btnEmbarque;
        private System.Windows.Forms.Timer timer1;
    }
}