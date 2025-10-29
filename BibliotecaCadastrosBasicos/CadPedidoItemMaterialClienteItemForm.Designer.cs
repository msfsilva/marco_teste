using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    partial class CadPedidoItemMaterialClienteItemForm
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
            this.label1 = new IWTLabel();
            this.cmbLote = new IWTMultiColumnComboBox(this.components);
            this.label2 = new IWTLabel();
            this.nudQuantidade = new IWTNumericUpDown();
            this.btnOK = new IWTButton();
            this.btnCancelar = new IWTButton();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidade)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lote";
            // 
            // cmbLote
            // 
            this.cmbLote.FormattingEnabled = true;
            this.cmbLote.Location = new System.Drawing.Point(76, 19);
            this.cmbLote.Name = "cmbLote";
            this.cmbLote.SelectedRow = null;
            this.cmbLote.Size = new System.Drawing.Size(258, 21);
            this.cmbLote.TabIndex = 1;
            this.cmbLote.Table = null;
            this.cmbLote.SelectedIndexChanged += new System.EventHandler(this.cmbLote_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Quantidade";
            // 
            // nudQuantidade
            // 
            this.nudQuantidade.DecimalPlaces = 4;
            this.nudQuantidade.Location = new System.Drawing.Point(76, 53);
            this.nudQuantidade.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudQuantidade.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.nudQuantidade.Name = "nudQuantidade";
            this.nudQuantidade.Size = new System.Drawing.Size(100, 20);
            this.nudQuantidade.TabIndex = 3;
            this.nudQuantidade.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(259, 106);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(12, 106);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // CadPedidoMaterialClienteItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(346, 140);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.nudQuantidade);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbLote);
            this.Controls.Add(this.label1);
            this.Name = "CadPedidoMaterialClienteItemForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lote do Cliente";
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IWTDotNetLib.IWTLabel label1;
        private IWTDotNetLib.IWTMultiColumnComboBox cmbLote;
        private IWTDotNetLib.IWTLabel label2;
        private IWTDotNetLib.IWTNumericUpDown nudQuantidade;
        private IWTDotNetLib.IWTButton btnOK;
        private IWTDotNetLib.IWTButton btnCancelar;
    }
}