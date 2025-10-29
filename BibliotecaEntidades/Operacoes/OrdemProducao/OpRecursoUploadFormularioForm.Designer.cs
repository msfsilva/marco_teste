namespace BibliotecaEntidades.Operacoes.OrdemProducao
{
    partial class OpRecursoUploadFormularioForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblFormulario = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lnkDocumento = new System.Windows.Forms.LinkLabel();
            this.btnDocumentoEscaneado = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.ofdDocumento = new System.Windows.Forms.OpenFileDialog();
            this.fbdDocumento = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblFormulario);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnOK);
            this.splitContainer1.Size = new System.Drawing.Size(602, 163);
            this.splitContainer1.SplitterDistance = 110;
            this.splitContainer1.TabIndex = 0;
            // 
            // lblFormulario
            // 
            this.lblFormulario.AutoSize = true;
            this.lblFormulario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormulario.Location = new System.Drawing.Point(70, 15);
            this.lblFormulario.Name = "lblFormulario";
            this.lblFormulario.Size = new System.Drawing.Size(0, 13);
            this.lblFormulario.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Fomulário:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lnkDocumento);
            this.groupBox1.Controls.Add(this.btnDocumentoEscaneado);
            this.groupBox1.Location = new System.Drawing.Point(3, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(596, 61);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Formulário Escaneado/PDF";
            // 
            // lnkDocumento
            // 
            this.lnkDocumento.AutoSize = true;
            this.lnkDocumento.Location = new System.Drawing.Point(6, 29);
            this.lnkDocumento.Name = "lnkDocumento";
            this.lnkDocumento.Size = new System.Drawing.Size(61, 13);
            this.lnkDocumento.TabIndex = 11;
            this.lnkDocumento.TabStop = true;
            this.lnkDocumento.Text = "Download: ";
            this.lnkDocumento.Visible = false;
            this.lnkDocumento.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDocumento_LinkClicked);
            // 
            // btnDocumentoEscaneado
            // 
            this.btnDocumentoEscaneado.Location = new System.Drawing.Point(505, 24);
            this.btnDocumentoEscaneado.Name = "btnDocumentoEscaneado";
            this.btnDocumentoEscaneado.Size = new System.Drawing.Size(85, 23);
            this.btnDocumentoEscaneado.TabIndex = 10;
            this.btnDocumentoEscaneado.Text = "Selecionar";
            this.btnDocumentoEscaneado.UseVisualStyleBackColor = true;
            this.btnDocumentoEscaneado.Click += new System.EventHandler(this.btnDocumentoEscaneado_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(515, 14);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ofdDocumento
            // 
            this.ofdDocumento.DefaultExt = "pdf";
            this.ofdDocumento.Filter = "PDF|*.pdf|JPG|*.jpg|BMP|*.bmp|PNG|*.png";
            this.ofdDocumento.RestoreDirectory = true;
            // 
            // OpRecursoUploadFormularioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(602, 163);
            this.Controls.Add(this.splitContainer1);
            this.Name = "OpRecursoUploadFormularioForm";
            this.Text = "Carregamento de formulário preenchido";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OpRecursoUploadFormularioForm_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel lnkDocumento;
        private System.Windows.Forms.Button btnDocumentoEscaneado;
        private System.Windows.Forms.OpenFileDialog ofdDocumento;
        private System.Windows.Forms.FolderBrowserDialog fbdDocumento;
        private System.Windows.Forms.Label lblFormulario;
        private System.Windows.Forms.Label label1;
    }
}