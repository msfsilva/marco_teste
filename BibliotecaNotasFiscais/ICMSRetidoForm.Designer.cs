namespace BibliotecaNotasFiscais
{
    partial class IcmsRetidoForm
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
            this.lblItem = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nudRemetenteBC = new System.Windows.Forms.NumericUpDown();
            this.nudRemetenteValor = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nudDestValor = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudDestBC = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRemetenteBC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRemetenteValor)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDestValor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDestBC)).BeginInit();
            this.SuspendLayout();
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Location = new System.Drawing.Point(12, 34);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(0, 13);
            this.lblItem.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Entre com as informações da Retenção do ICMS ST do item:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudRemetenteValor);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nudRemetenteBC);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(15, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 43);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Remetente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "BC:";
            // 
            // nudRemetenteBC
            // 
            this.nudRemetenteBC.DecimalPlaces = 2;
            this.nudRemetenteBC.Location = new System.Drawing.Point(36, 14);
            this.nudRemetenteBC.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudRemetenteBC.Name = "nudRemetenteBC";
            this.nudRemetenteBC.Size = new System.Drawing.Size(120, 20);
            this.nudRemetenteBC.TabIndex = 1;
            // 
            // nudRemetenteValor
            // 
            this.nudRemetenteValor.DecimalPlaces = 2;
            this.nudRemetenteValor.Location = new System.Drawing.Point(216, 14);
            this.nudRemetenteValor.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudRemetenteValor.Name = "nudRemetenteValor";
            this.nudRemetenteValor.Size = new System.Drawing.Size(120, 20);
            this.nudRemetenteValor.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(176, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Valor:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nudDestValor);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.nudDestBC);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(15, 105);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(355, 43);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Destinatário";
            // 
            // nudDestValor
            // 
            this.nudDestValor.DecimalPlaces = 2;
            this.nudDestValor.Location = new System.Drawing.Point(216, 14);
            this.nudDestValor.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudDestValor.Name = "nudDestValor";
            this.nudDestValor.Size = new System.Drawing.Size(120, 20);
            this.nudDestValor.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(176, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Valor:";
            // 
            // nudDestBC
            // 
            this.nudDestBC.DecimalPlaces = 2;
            this.nudDestBC.Location = new System.Drawing.Point(36, 14);
            this.nudDestBC.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudDestBC.Name = "nudDestBC";
            this.nudDestBC.Size = new System.Drawing.Size(120, 20);
            this.nudDestBC.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "BC:";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(305, 162);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // ICMSRetidoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(392, 197);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblItem);
            this.Name = "IcmsRetidoForm";
            this.Text = "ICMSRetidoForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ICMSRetidoForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRemetenteBC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRemetenteValor)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDestValor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDestBC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudRemetenteValor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudRemetenteBC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nudDestValor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudDestBC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnOk;
    }
}