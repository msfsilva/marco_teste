namespace BibliotecaExpedicao
{
    partial class QuantidadeParcialForm
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
            this.nudQuantidade = new System.Windows.Forms.NumericUpDown();
            this.btnContinuar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudQtdVolumes = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQtdVolumes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Esse item permite conferência parcial, informe qual a quantidade que deseja confe" +
    "rir.";
            // 
            // nudQuantidade
            // 
            this.nudQuantidade.DecimalPlaces = 4;
            this.nudQuantidade.Location = new System.Drawing.Point(61, 41);
            this.nudQuantidade.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudQuantidade.Name = "nudQuantidade";
            this.nudQuantidade.Size = new System.Drawing.Size(120, 20);
            this.nudQuantidade.TabIndex = 1;
            // 
            // btnContinuar
            // 
            this.btnContinuar.Location = new System.Drawing.Point(252, 80);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(75, 23);
            this.btnContinuar.TabIndex = 2;
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.UseVisualStyleBackColor = true;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Itens";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Volumes";
            // 
            // nudQtdVolumes
            // 
            this.nudQtdVolumes.Location = new System.Drawing.Point(61, 67);
            this.nudQtdVolumes.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudQtdVolumes.Name = "nudQtdVolumes";
            this.nudQtdVolumes.Size = new System.Drawing.Size(120, 20);
            this.nudQtdVolumes.TabIndex = 4;
            // 
            // QuantidadeParcialForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(339, 115);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudQtdVolumes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnContinuar);
            this.Controls.Add(this.nudQuantidade);
            this.Controls.Add(this.label1);
            this.Name = "QuantidadeParcialForm";
            this.Text = "Conferência Parcial";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuantidadeParcialForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQtdVolumes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudQuantidade;
        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudQtdVolumes;
    }
}