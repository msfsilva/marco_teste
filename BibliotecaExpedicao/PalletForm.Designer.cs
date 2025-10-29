using IWTCustomControls;

namespace BibliotecaExpedicao
{
    partial class PalletForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtPallet = new BarcodeTextBox(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnSair = new System.Windows.Forms.Button();
            this.grbModoOperacao.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbModoOperacao
            // 
            this.grbModoOperacao.Controls.Add(this.rdbBarCode);
            this.grbModoOperacao.Controls.Add(this.rdbManual);
            this.grbModoOperacao.Location = new System.Drawing.Point(12, 12);
            this.grbModoOperacao.Name = "grbModoOperacao";
            this.grbModoOperacao.Size = new System.Drawing.Size(185, 51);
            this.grbModoOperacao.TabIndex = 6;
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
            this.rdbBarCode.TabIndex = 1;
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
            this.rdbManual.TabIndex = 2;
            this.rdbManual.Text = "Manual";
            this.rdbManual.UseVisualStyleBackColor = true;
            this.rdbManual.CheckedChanged += new System.EventHandler(this.rdbManual_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Pallet";
            // 
            // txtPallet
            // 
            this.txtPallet.Location = new System.Drawing.Point(54, 82);
            this.txtPallet.Name = "txtPallet";
            this.txtPallet.Size = new System.Drawing.Size(284, 20);
            this.txtPallet.TabIndex = 0;
            this.txtPallet.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtPallet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPallet_KeyDown);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnSair
            // 
            this.btnSair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSair.Location = new System.Drawing.Point(178, 120);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(186, 23);
            this.btnSair.TabIndex = 3;
            this.btnSair.Text = "Sair da Conferência";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // PalletForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(376, 155);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.txtPallet);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grbModoOperacao);
            this.Name = "PalletForm";
            this.Text = "Seleção do Pallet";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PalletForm_FormClosing);
            this.grbModoOperacao.ResumeLayout(false);
            this.grbModoOperacao.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbModoOperacao;
        private System.Windows.Forms.RadioButton rdbBarCode;
        private System.Windows.Forms.RadioButton rdbManual;
        private System.Windows.Forms.Label label1;
        private IWTCustomControls.BarcodeTextBox txtPallet;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnSair;
    }
}