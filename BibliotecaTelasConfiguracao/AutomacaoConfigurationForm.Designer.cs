namespace BibliotecaTelasConfiguracao
{
    partial class AutomacaoConfigurationForm
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
            this.btnSalvar = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.grbCertificado = new System.Windows.Forms.GroupBox();
            this.cmbCertificados = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCertificadosSecundario = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grbCertificado.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.Location = new System.Drawing.Point(447, 193);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 3;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "mdb";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Banco de Dados Access|*.mdb";
            this.openFileDialog1.RestoreDirectory = true;
            // 
            // grbCertificado
            // 
            this.grbCertificado.Controls.Add(this.cmbCertificadosSecundario);
            this.grbCertificado.Controls.Add(this.label2);
            this.grbCertificado.Controls.Add(this.cmbCertificados);
            this.grbCertificado.Controls.Add(this.label1);
            this.grbCertificado.Location = new System.Drawing.Point(25, 12);
            this.grbCertificado.Name = "grbCertificado";
            this.grbCertificado.Size = new System.Drawing.Size(495, 164);
            this.grbCertificado.TabIndex = 6;
            this.grbCertificado.TabStop = false;
            this.grbCertificado.Text = "Certificado Emissão NFe";
            // 
            // cmbCertificados
            // 
            this.cmbCertificados.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCertificados.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCertificados.FormattingEnabled = true;
            this.cmbCertificados.Location = new System.Drawing.Point(26, 43);
            this.cmbCertificados.Name = "cmbCertificados";
            this.cmbCertificados.Size = new System.Drawing.Size(446, 21);
            this.cmbCertificados.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Certificado Emitente Primário";
            // 
            // cmbCertificadosSecundario
            // 
            this.cmbCertificadosSecundario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCertificadosSecundario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCertificadosSecundario.FormattingEnabled = true;
            this.cmbCertificadosSecundario.Location = new System.Drawing.Point(26, 105);
            this.cmbCertificadosSecundario.Name = "cmbCertificadosSecundario";
            this.cmbCertificadosSecundario.Size = new System.Drawing.Size(446, 21);
            this.cmbCertificadosSecundario.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Certificado Emitente Secundário";
            // 
            // AutomacaoConfigurationForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(545, 228);
            this.Controls.Add(this.grbCertificado);
            this.Controls.Add(this.btnSalvar);
            this.Name = "AutomacaoConfigurationForm";
            this.Text = "Configurações";
            this.grbCertificado.ResumeLayout(false);
            this.grbCertificado.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox grbCertificado;
        private System.Windows.Forms.ComboBox cmbCertificados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCertificadosSecundario;
        private System.Windows.Forms.Label label2;
    }
}