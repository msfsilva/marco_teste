namespace BibliotecaCadastrosBasicos
{
    partial class CadClienteContatoForm
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
            this.NomeLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.Nome = new IWTDotNetLib.IWTTextBox(this.components);
            this.SetorLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.Setor = new IWTDotNetLib.IWTTextBox(this.components);
            this.FoneLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.Fone = new IWTDotNetLib.IWTTextBox(this.components);
            this.EmailLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.Email = new IWTDotNetLib.IWTTextBox(this.components);
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
            this.splitContainer1.Panel1.Controls.Add(this.NomeLabel);
            this.splitContainer1.Panel1.Controls.Add(this.Nome);
            this.splitContainer1.Panel1.Controls.Add(this.SetorLabel);
            this.splitContainer1.Panel1.Controls.Add(this.Setor);
            this.splitContainer1.Panel1.Controls.Add(this.FoneLabel);
            this.splitContainer1.Panel1.Controls.Add(this.Fone);
            this.splitContainer1.Panel1.Controls.Add(this.EmailLabel);
            this.splitContainer1.Panel1.Controls.Add(this.Email);
            this.splitContainer1.Size = new System.Drawing.Size(480, 205);
            this.splitContainer1.SplitterDistance = 139;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(393, 20);
            // 
            // NomeLabel
            // 
            this.NomeLabel.AutoSize = true;
            this.NomeLabel.BindingField = null;
            this.NomeLabel.LiberadoQuandoCadastroUtilizado = false;
            this.NomeLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.NomeLabel.Location = new System.Drawing.Point(20, 16);
            this.NomeLabel.Name = "NomeLabel";
            this.NomeLabel.Size = new System.Drawing.Size(35, 13);
            this.NomeLabel.TabIndex = 2;
            this.NomeLabel.Text = "Nome";
            // 
            // Nome
            // 
            this.Nome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Nome.BindingField = "Nome";
            this.Nome.DebugMode = false;
            this.Nome.LiberadoQuandoCadastroUtilizado = false;
            this.Nome.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Nome.Location = new System.Drawing.Point(61, 13);
            this.Nome.MaxLength = 255;
            this.Nome.ModoBarcode = false;
            this.Nome.Name = "Nome";
            this.Nome.Size = new System.Drawing.Size(395, 20);
            this.Nome.TabIndex = 3;
            // 
            // SetorLabel
            // 
            this.SetorLabel.AutoSize = true;
            this.SetorLabel.BindingField = null;
            this.SetorLabel.LiberadoQuandoCadastroUtilizado = false;
            this.SetorLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.SetorLabel.Location = new System.Drawing.Point(23, 43);
            this.SetorLabel.Name = "SetorLabel";
            this.SetorLabel.Size = new System.Drawing.Size(32, 13);
            this.SetorLabel.TabIndex = 4;
            this.SetorLabel.Text = "Setor";
            // 
            // Setor
            // 
            this.Setor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Setor.BindingField = "Setor";
            this.Setor.DebugMode = false;
            this.Setor.LiberadoQuandoCadastroUtilizado = false;
            this.Setor.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Setor.Location = new System.Drawing.Point(61, 40);
            this.Setor.MaxLength = 255;
            this.Setor.ModoBarcode = false;
            this.Setor.Name = "Setor";
            this.Setor.Size = new System.Drawing.Size(395, 20);
            this.Setor.TabIndex = 5;
            // 
            // FoneLabel
            // 
            this.FoneLabel.AutoSize = true;
            this.FoneLabel.BindingField = null;
            this.FoneLabel.LiberadoQuandoCadastroUtilizado = false;
            this.FoneLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.FoneLabel.Location = new System.Drawing.Point(24, 70);
            this.FoneLabel.Name = "FoneLabel";
            this.FoneLabel.Size = new System.Drawing.Size(31, 13);
            this.FoneLabel.TabIndex = 6;
            this.FoneLabel.Text = "Fone";
            // 
            // Fone
            // 
            this.Fone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Fone.BindingField = "Fone";
            this.Fone.DebugMode = false;
            this.Fone.LiberadoQuandoCadastroUtilizado = false;
            this.Fone.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Fone.Location = new System.Drawing.Point(61, 67);
            this.Fone.MaxLength = 255;
            this.Fone.ModoBarcode = false;
            this.Fone.Name = "Fone";
            this.Fone.Size = new System.Drawing.Size(395, 20);
            this.Fone.TabIndex = 7;
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.BindingField = null;
            this.EmailLabel.LiberadoQuandoCadastroUtilizado = false;
            this.EmailLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.EmailLabel.Location = new System.Drawing.Point(23, 97);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(32, 13);
            this.EmailLabel.TabIndex = 8;
            this.EmailLabel.Text = "Email";
            // 
            // Email
            // 
            this.Email.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Email.BindingField = "Email";
            this.Email.DebugMode = false;
            this.Email.LiberadoQuandoCadastroUtilizado = false;
            this.Email.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Email.Location = new System.Drawing.Point(61, 94);
            this.Email.MaxLength = 255;
            this.Email.ModoBarcode = false;
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(395, 20);
            this.Email.TabIndex = 9;
            // 
            // CadClienteContatoForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(480, 205);
            this.Name = "CadClienteContatoForm";
            this.Text = "Contatos do Cliente";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private IWTDotNetLib.IWTLabel NomeLabel;
        private IWTDotNetLib.IWTTextBox Nome;
        private IWTDotNetLib.IWTLabel SetorLabel;
        private IWTDotNetLib.IWTTextBox Setor;
        private IWTDotNetLib.IWTLabel FoneLabel;
        private IWTDotNetLib.IWTTextBox Fone;
        private IWTDotNetLib.IWTLabel EmailLabel;
        private IWTDotNetLib.IWTTextBox Email;
    }
} 
