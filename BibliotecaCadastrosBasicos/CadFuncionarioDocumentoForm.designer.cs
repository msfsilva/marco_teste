namespace BibliotecaCadastrosBasicos
{
    partial class CadFuncionarioDocumentoForm
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
            this.IdentificacaoLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.Identificacao = new IWTDotNetLib.IWTTextBox(this.components);
            this.txtArquivo = new System.Windows.Forms.TextBox();
            this.btnSelecionar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.txtArquivo);
            this.splitContainer1.Panel1.Controls.Add(this.btnSelecionar);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.IdentificacaoLabel);
            this.splitContainer1.Panel1.Controls.Add(this.Identificacao);
            this.splitContainer1.Size = new System.Drawing.Size(480, 149);
            this.splitContainer1.SplitterDistance = 83;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(393, 20);
            // 
            // IdentificacaoLabel
            // 
            this.IdentificacaoLabel.AutoSize = true;
            this.IdentificacaoLabel.BindingField = null;
            this.IdentificacaoLabel.LiberadoQuandoCadastroUtilizado = false;
            this.IdentificacaoLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.IdentificacaoLabel.Location = new System.Drawing.Point(19, 15);
            this.IdentificacaoLabel.Name = "IdentificacaoLabel";
            this.IdentificacaoLabel.Size = new System.Drawing.Size(68, 13);
            this.IdentificacaoLabel.TabIndex = 2;
            this.IdentificacaoLabel.Text = "Identificação";
            // 
            // Identificacao
            // 
            this.Identificacao.BindingField = "Identificacao";
            this.Identificacao.DebugMode = false;
            this.Identificacao.LiberadoQuandoCadastroUtilizado = false;
            this.Identificacao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Identificacao.Location = new System.Drawing.Point(93, 12);
            this.Identificacao.MaxLength = 255;
            this.Identificacao.ModoBarcode = false;
            this.Identificacao.ModoBusca = false;
            this.Identificacao.Name = "Identificacao";
            this.Identificacao.NaoLimparDepoisBarcode = false;
            this.Identificacao.Size = new System.Drawing.Size(375, 20);
            this.Identificacao.TabIndex = 0;
            // 
            // txtArquivo
            // 
            this.txtArquivo.Enabled = false;
            this.txtArquivo.Location = new System.Drawing.Point(93, 38);
            this.txtArquivo.Name = "txtArquivo";
            this.txtArquivo.Size = new System.Drawing.Size(294, 20);
            this.txtArquivo.TabIndex = 1;
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.Location = new System.Drawing.Point(393, 37);
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Size = new System.Drawing.Size(75, 23);
            this.btnSelecionar.TabIndex = 2;
            this.btnSelecionar.Text = "Selecionar";
            this.btnSelecionar.UseVisualStyleBackColor = true;
            this.btnSelecionar.Click += new System.EventHandler(this.btnSelecionar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Arquivo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // CadFuncionarioDocumentoForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(480, 149);
            this.Name = "CadFuncionarioDocumentoForm";
            this.Text = "Funcionario Documento";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private IWTDotNetLib.IWTLabel IdentificacaoLabel;
        private IWTDotNetLib.IWTTextBox Identificacao;
        private System.Windows.Forms.TextBox txtArquivo;
        private System.Windows.Forms.Button btnSelecionar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
} 
