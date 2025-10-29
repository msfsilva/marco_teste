namespace BibliotecaCadastrosBasicos
{
    partial class CadLogConfiguracaoAutomaticaPedidosForm
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
            this.DataLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.Data = new IWTDotNetLib.IWTDateTimePicker(this.components);
            this.EstacaoLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.Estacao = new IWTDotNetLib.IWTTextBox(this.components);
            this.ConteudoLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.Conteudo = new IWTDotNetLib.IWTTextBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Data)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.DataLabel);
            this.splitContainer1.Panel1.Controls.Add(this.Data);
            this.splitContainer1.Panel1.Controls.Add(this.EstacaoLabel);
            this.splitContainer1.Panel1.Controls.Add(this.Estacao);
            this.splitContainer1.Panel1.Controls.Add(this.ConteudoLabel);
            this.splitContainer1.Panel1.Controls.Add(this.Conteudo);
            this.splitContainer1.Size = new System.Drawing.Size(631, 502);
            this.splitContainer1.SplitterDistance = 436;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(544, 20);
            // 
            // DataLabel
            // 
            this.DataLabel.AutoSize = true;
            this.DataLabel.BindingField = null;
            this.DataLabel.LiberadoQuandoCadastroUtilizado = false;
            this.DataLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.DataLabel.Location = new System.Drawing.Point(26, 15);
            this.DataLabel.Name = "DataLabel";
            this.DataLabel.Size = new System.Drawing.Size(30, 13);
            this.DataLabel.TabIndex = 0;
            this.DataLabel.Text = "Data";
            // 
            // Data
            // 
            this.Data.BindingField = "Data";
            this.Data.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Data.LiberadoQuandoCadastroUtilizado = false;
            this.Data.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Data.Location = new System.Drawing.Point(62, 12);
            this.Data.Name = "Data";
            this.Data.Size = new System.Drawing.Size(150, 20);
            this.Data.TabIndex = 1;
            this.Data.Value = new System.DateTime(2017, 8, 8, 14, 31, 26, 120);
            // 
            // EstacaoLabel
            // 
            this.EstacaoLabel.AutoSize = true;
            this.EstacaoLabel.BindingField = null;
            this.EstacaoLabel.LiberadoQuandoCadastroUtilizado = false;
            this.EstacaoLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.EstacaoLabel.Location = new System.Drawing.Point(10, 42);
            this.EstacaoLabel.Name = "EstacaoLabel";
            this.EstacaoLabel.Size = new System.Drawing.Size(46, 13);
            this.EstacaoLabel.TabIndex = 2;
            this.EstacaoLabel.Text = "Estação";
            // 
            // Estacao
            // 
            this.Estacao.BindingField = "Estacao";
            this.Estacao.DebugMode = false;
            this.Estacao.LiberadoQuandoCadastroUtilizado = false;
            this.Estacao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Estacao.Location = new System.Drawing.Point(62, 39);
            this.Estacao.MaxLength = 255;
            this.Estacao.ModoBarcode = false;
            this.Estacao.ModoBusca = false;
            this.Estacao.Name = "Estacao";
            this.Estacao.NaoLimparDepoisBarcode = false;
            this.Estacao.Size = new System.Drawing.Size(150, 20);
            this.Estacao.TabIndex = 3;
            // 
            // ConteudoLabel
            // 
            this.ConteudoLabel.AutoSize = true;
            this.ConteudoLabel.BindingField = null;
            this.ConteudoLabel.LiberadoQuandoCadastroUtilizado = false;
            this.ConteudoLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ConteudoLabel.Location = new System.Drawing.Point(3, 69);
            this.ConteudoLabel.Name = "ConteudoLabel";
            this.ConteudoLabel.Size = new System.Drawing.Size(53, 13);
            this.ConteudoLabel.TabIndex = 4;
            this.ConteudoLabel.Text = "Conteúdo";
            // 
            // Conteudo
            // 
            this.Conteudo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Conteudo.BindingField = "Conteudo";
            this.Conteudo.DebugMode = false;
            this.Conteudo.LiberadoQuandoCadastroUtilizado = false;
            this.Conteudo.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Conteudo.Location = new System.Drawing.Point(62, 66);
            this.Conteudo.ModoBarcode = false;
            this.Conteudo.ModoBusca = false;
            this.Conteudo.Multiline = true;
            this.Conteudo.Name = "Conteudo";
            this.Conteudo.NaoLimparDepoisBarcode = false;
            this.Conteudo.ReadOnly = true;
            this.Conteudo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Conteudo.Size = new System.Drawing.Size(557, 358);
            this.Conteudo.TabIndex = 5;
            // 
            // CadLogConfiguracaoAutomaticaPedidosForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(631, 502);
            this.Name = "CadLogConfiguracaoAutomaticaPedidosForm";
            this.Text = "Logs das Configurações Automáticas de Pedidos";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Data)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IWTDotNetLib.IWTLabel DataLabel;
        private IWTDotNetLib.IWTDateTimePicker Data;
        private IWTDotNetLib.IWTLabel EstacaoLabel;
        private IWTDotNetLib.IWTTextBox Estacao;
        private IWTDotNetLib.IWTLabel ConteudoLabel;
        private IWTDotNetLib.IWTTextBox Conteudo;
    }
} 
