namespace BibliotecaEmissaoEtiquetas
{
    partial class EtiquetaInternaCustomizadoForm
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
            this.btnOk = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPos = new System.Windows.Forms.MaskedTextBox();
            this.rdbSemana = new System.Windows.Forms.RadioButton();
            this.rdbOc = new System.Windows.Forms.RadioButton();
            this.txtSemana = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCodItem = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grbSemana = new System.Windows.Forms.GroupBox();
            this.rdbTodosAnteriores = new System.Windows.Forms.RadioButton();
            this.rdbSomenteSemana = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.grbSemana.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Número";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(312, 207);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "OC";
            // 
            // txtOc
            // 
            this.txtOc.Location = new System.Drawing.Point(106, 19);
            this.txtOc.Name = "txtOc";
            this.txtOc.Size = new System.Drawing.Size(73, 20);
            this.txtOc.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(182, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "/";
            // 
            // txtPos
            // 
            this.txtPos.Location = new System.Drawing.Point(200, 19);
            this.txtPos.Mask = "99";
            this.txtPos.Name = "txtPos";
            this.txtPos.Size = new System.Drawing.Size(24, 20);
            this.txtPos.TabIndex = 6;
            // 
            // rdbSemana
            // 
            this.rdbSemana.AutoSize = true;
            this.rdbSemana.Checked = true;
            this.rdbSemana.Location = new System.Drawing.Point(296, 22);
            this.rdbSemana.Name = "rdbSemana";
            this.rdbSemana.Size = new System.Drawing.Size(14, 13);
            this.rdbSemana.TabIndex = 7;
            this.rdbSemana.TabStop = true;
            this.rdbSemana.UseVisualStyleBackColor = true;
            this.rdbSemana.CheckedChanged += new System.EventHandler(this.rdbSemana_CheckedChanged);
            // 
            // rdbOc
            // 
            this.rdbOc.AutoSize = true;
            this.rdbOc.Location = new System.Drawing.Point(327, 111);
            this.rdbOc.Name = "rdbOc";
            this.rdbOc.Size = new System.Drawing.Size(14, 13);
            this.rdbOc.TabIndex = 8;
            this.rdbOc.UseVisualStyleBackColor = true;
            this.rdbOc.CheckedChanged += new System.EventHandler(this.rdbOc_CheckedChanged);
            // 
            // txtSemana
            // 
            this.txtSemana.Location = new System.Drawing.Point(62, 19);
            this.txtSemana.Mask = "00000000000000";
            this.txtSemana.Name = "txtSemana";
            this.txtSemana.Size = new System.Drawing.Size(128, 20);
            this.txtSemana.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCodItem);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPos);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtOc);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(12, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 100);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reimpressão de Etiqueta";
            // 
            // txtCodItem
            // 
            this.txtCodItem.Location = new System.Drawing.Point(117, 60);
            this.txtCodItem.Name = "txtCodItem";
            this.txtCodItem.Size = new System.Drawing.Size(186, 20);
            this.txtCodItem.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Código Item (Interno)";
            // 
            // grbSemana
            // 
            this.grbSemana.Controls.Add(this.rdbTodosAnteriores);
            this.grbSemana.Controls.Add(this.rdbSomenteSemana);
            this.grbSemana.Controls.Add(this.txtSemana);
            this.grbSemana.Controls.Add(this.label1);
            this.grbSemana.Location = new System.Drawing.Point(16, 8);
            this.grbSemana.Name = "grbSemana";
            this.grbSemana.Size = new System.Drawing.Size(274, 67);
            this.grbSemana.TabIndex = 11;
            this.grbSemana.TabStop = false;
            this.grbSemana.Text = "Semana";
            // 
            // rdbTodosAnteriores
            // 
            this.rdbTodosAnteriores.AutoSize = true;
            this.rdbTodosAnteriores.Location = new System.Drawing.Point(145, 44);
            this.rdbTodosAnteriores.Name = "rdbTodosAnteriores";
            this.rdbTodosAnteriores.Size = new System.Drawing.Size(105, 17);
            this.rdbTodosAnteriores.TabIndex = 11;
            this.rdbTodosAnteriores.Text = "Todos Anteriores";
            this.rdbTodosAnteriores.UseVisualStyleBackColor = true;
            // 
            // rdbSomenteSemana
            // 
            this.rdbSomenteSemana.AutoSize = true;
            this.rdbSomenteSemana.Checked = true;
            this.rdbSomenteSemana.Location = new System.Drawing.Point(15, 44);
            this.rdbSomenteSemana.Name = "rdbSomenteSemana";
            this.rdbSomenteSemana.Size = new System.Drawing.Size(124, 17);
            this.rdbSomenteSemana.TabIndex = 10;
            this.rdbSomenteSemana.TabStop = true;
            this.rdbSomenteSemana.Text = "Somente na Semana";
            this.rdbSomenteSemana.UseVisualStyleBackColor = true;
            // 
            // EtiquetaInternaCustomizadoForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(399, 242);
            this.Controls.Add(this.grbSemana);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rdbOc);
            this.Controls.Add(this.rdbSemana);
            this.Controls.Add(this.btnOk);
            this.Name = "EtiquetaInternaCustomizadoForm";
            this.Text = "Geração de etiquetas interna Customizado";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbSemana.ResumeLayout(false);
            this.grbSemana.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtPos;
        private System.Windows.Forms.RadioButton rdbSemana;
        private System.Windows.Forms.RadioButton rdbOc;
        private System.Windows.Forms.MaskedTextBox txtSemana;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCodItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox grbSemana;
        private System.Windows.Forms.RadioButton rdbTodosAnteriores;
        private System.Windows.Forms.RadioButton rdbSomenteSemana;
    }
}