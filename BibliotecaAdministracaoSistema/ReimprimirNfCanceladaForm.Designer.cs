namespace BibliotecaAdministracaoSistema
{
    partial class ReimprimirNfCanceladaForm
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
            this.nudNumeroNF = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLocalArquivo = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnArquivo = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumeroNF)).BeginInit();
            this.SuspendLayout();
            // 
            // nudNumeroNF
            // 
            this.nudNumeroNF.Location = new System.Drawing.Point(74, 29);
            this.nudNumeroNF.Maximum = new decimal(new int[] {
            276447231,
            23283,
            0,
            0});
            this.nudNumeroNF.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumeroNF.Name = "nudNumeroNF";
            this.nudNumeroNF.Size = new System.Drawing.Size(120, 20);
            this.nudNumeroNF.TabIndex = 0;
            this.nudNumeroNF.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nº Nota";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Local para salvar o arquivo";
            // 
            // txtLocalArquivo
            // 
            this.txtLocalArquivo.Location = new System.Drawing.Point(30, 82);
            this.txtLocalArquivo.Name = "txtLocalArquivo";
            this.txtLocalArquivo.ReadOnly = true;
            this.txtLocalArquivo.Size = new System.Drawing.Size(297, 20);
            this.txtLocalArquivo.TabIndex = 3;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "txt";
            this.saveFileDialog1.Filter = "Arquivos TXT|*.txt";
            this.saveFileDialog1.RestoreDirectory = true;
            // 
            // btnArquivo
            // 
            this.btnArquivo.Location = new System.Drawing.Point(333, 79);
            this.btnArquivo.Name = "btnArquivo";
            this.btnArquivo.Size = new System.Drawing.Size(35, 23);
            this.btnArquivo.TabIndex = 4;
            this.btnArquivo.Text = "...";
            this.btnArquivo.UseVisualStyleBackColor = true;
            this.btnArquivo.Click += new System.EventHandler(this.btnArquivo_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(293, 124);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // ReimprimirNfCanceladaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(380, 159);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnArquivo);
            this.Controls.Add(this.txtLocalArquivo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudNumeroNF);
            this.Name = "ReimprimirNfCanceladaForm";
            this.Text = "Regerar arquivo de Nfe Cancelada";
            ((System.ComponentModel.ISupportInitialize)(this.nudNumeroNF)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudNumeroNF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLocalArquivo;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnArquivo;
        private System.Windows.Forms.Button btnOk;
    }
}