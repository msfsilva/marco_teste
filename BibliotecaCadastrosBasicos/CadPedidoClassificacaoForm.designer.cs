namespace BibliotecaCadastrosBasicos
{
    partial class CadPedidoClassificacaoForm
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
            this.DescricaoLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.Descricao = new IWTDotNetLib.IWTTextBox(this.components);
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
            this.splitContainer1.Panel1.Controls.Add(this.IdentificacaoLabel);
            this.splitContainer1.Panel1.Controls.Add(this.Identificacao);
            this.splitContainer1.Panel1.Controls.Add(this.DescricaoLabel);
            this.splitContainer1.Panel1.Controls.Add(this.Descricao);
            this.splitContainer1.Size = new System.Drawing.Size(480, 155);
            this.splitContainer1.SplitterDistance = 89;
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
            this.IdentificacaoLabel.Location = new System.Drawing.Point(20, 16);
            this.IdentificacaoLabel.Name = "IdentificacaoLabel";
            this.IdentificacaoLabel.Size = new System.Drawing.Size(68, 13);
            this.IdentificacaoLabel.TabIndex = 0;
            this.IdentificacaoLabel.Text = "Identificação";
            // 
            // Identificacao
            // 
            this.Identificacao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Identificacao.BindingField = "Identificacao";
            this.Identificacao.DebugMode = false;
            this.Identificacao.LiberadoQuandoCadastroUtilizado = false;
            this.Identificacao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Identificacao.Location = new System.Drawing.Point(94, 13);
            this.Identificacao.MaxLength = 255;
            this.Identificacao.ModoBarcode = false;
            this.Identificacao.ModoBusca = false;
            this.Identificacao.Name = "Identificacao";
            this.Identificacao.NaoLimparDepoisBarcode = false;
            this.Identificacao.Size = new System.Drawing.Size(374, 20);
            this.Identificacao.TabIndex = 1;
            // 
            // DescricaoLabel
            // 
            this.DescricaoLabel.AutoSize = true;
            this.DescricaoLabel.BindingField = null;
            this.DescricaoLabel.LiberadoQuandoCadastroUtilizado = false;
            this.DescricaoLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.DescricaoLabel.Location = new System.Drawing.Point(33, 43);
            this.DescricaoLabel.Name = "DescricaoLabel";
            this.DescricaoLabel.Size = new System.Drawing.Size(55, 13);
            this.DescricaoLabel.TabIndex = 2;
            this.DescricaoLabel.Text = "Descrição";
            // 
            // Descricao
            // 
            this.Descricao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Descricao.BindingField = "Descricao";
            this.Descricao.DebugMode = false;
            this.Descricao.LiberadoQuandoCadastroUtilizado = false;
            this.Descricao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Descricao.Location = new System.Drawing.Point(94, 40);
            this.Descricao.MaxLength = 255;
            this.Descricao.ModoBarcode = false;
            this.Descricao.ModoBusca = false;
            this.Descricao.Name = "Descricao";
            this.Descricao.NaoLimparDepoisBarcode = false;
            this.Descricao.Size = new System.Drawing.Size(374, 20);
            this.Descricao.TabIndex = 3;
            // 
            // CadPedidoClassificacaoForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(480, 155);
            this.Name = "CadPedidoClassificacaoForm";
            this.Text = "Classificação de Pedidos";
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
        private IWTDotNetLib.IWTLabel DescricaoLabel;
        private IWTDotNetLib.IWTTextBox Descricao;
    }
} 
