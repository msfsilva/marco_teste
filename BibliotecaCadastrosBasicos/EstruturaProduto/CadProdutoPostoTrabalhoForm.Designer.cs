namespace BibliotecaCadastrosBasicos.EstruturaProduto
{
    partial class CadProdutoPostoTrabalhoForm
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nudTempoSetup = new System.Windows.Forms.NumericUpDown();
            this.nudTempoProducao = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudTempoSetup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTempoProducao)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(21, 84);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(247, 84);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tempo Setup ( horas )";
            // 
            // nudTempoSetup
            // 
            this.nudTempoSetup.DecimalPlaces = 2;
            this.nudTempoSetup.Location = new System.Drawing.Point(173, 12);
            this.nudTempoSetup.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudTempoSetup.Name = "nudTempoSetup";
            this.nudTempoSetup.Size = new System.Drawing.Size(120, 20);
            this.nudTempoSetup.TabIndex = 0;
            // 
            // nudTempoProducao
            // 
            this.nudTempoProducao.DecimalPlaces = 2;
            this.nudTempoProducao.Location = new System.Drawing.Point(173, 38);
            this.nudTempoProducao.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudTempoProducao.Name = "nudTempoProducao";
            this.nudTempoProducao.Size = new System.Drawing.Size(120, 20);
            this.nudTempoProducao.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Tempo Produção ( segundos )";
            // 
            // CadProdutoPostoTrabalhoForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(334, 119);
            this.Controls.Add(this.nudTempoProducao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudTempoSetup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOk);
            this.Name = "CadProdutoPostoTrabalhoForm";
            this.Text = "Inclusão de Posto de Trabalho";
            ((System.ComponentModel.ISupportInitialize)(this.nudTempoSetup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTempoProducao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudTempoSetup;
        private System.Windows.Forms.NumericUpDown nudTempoProducao;
        private System.Windows.Forms.Label label2;
    }
}