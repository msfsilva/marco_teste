namespace BibliotecaCadastrosBasicos
{
    partial class CadEpiCaForm
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
            this.NumeroLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.Numero = new IWTDotNetLib.IWTTextBox(this.components);
            this.ValidadeLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.Validade = new IWTDotNetLib.IWTDateTimePicker(this.components);
            this.VencidoLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.Vencido = new IWTDotNetLib.IWTCheckBox(this.components);
            this.grbRevisao = new System.Windows.Forms.GroupBox();
            this.lblRevisaoJustificativa = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisaoData = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisaoUsuario = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisaoJustificativaLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisaoDataLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisaoUsuarioLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lnkDocumento = new IWTDotNetLib.IWTLinkLabel(this.components);
            this.btnDocumentoEscaneado = new IWTDotNetLib.IWTButton(this.components);
            this.ofdDocumento = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Validade)).BeginInit();
            this.grbRevisao.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.NumeroLabel);
            this.splitContainer1.Panel1.Controls.Add(this.Numero);
            this.splitContainer1.Panel1.Controls.Add(this.ValidadeLabel);
            this.splitContainer1.Panel1.Controls.Add(this.Validade);
            this.splitContainer1.Panel1.Controls.Add(this.VencidoLabel);
            this.splitContainer1.Panel1.Controls.Add(this.Vencido);
            this.splitContainer1.Panel1.Controls.Add(this.grbRevisao);
            this.splitContainer1.Size = new System.Drawing.Size(414, 366);
            this.splitContainer1.SplitterDistance = 300;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(327, 20);
            // 
            // NumeroLabel
            // 
            this.NumeroLabel.AutoSize = true;
            this.NumeroLabel.BindingField = null;
            this.NumeroLabel.LiberadoQuandoCadastroUtilizado = false;
            this.NumeroLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.NumeroLabel.Location = new System.Drawing.Point(17, 15);
            this.NumeroLabel.Name = "NumeroLabel";
            this.NumeroLabel.Size = new System.Drawing.Size(44, 13);
            this.NumeroLabel.TabIndex = 0;
            this.NumeroLabel.Text = "Número";
            // 
            // Numero
            // 
            this.Numero.BindingField = "Numero";
            this.Numero.DebugMode = false;
            this.Numero.LiberadoQuandoCadastroUtilizado = false;
            this.Numero.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Numero.Location = new System.Drawing.Point(67, 12);
            this.Numero.ModoBarcode = false;
            this.Numero.Name = "Numero";
            this.Numero.Size = new System.Drawing.Size(150, 20);
            this.Numero.TabIndex = 1;
            // 
            // ValidadeLabel
            // 
            this.ValidadeLabel.AutoSize = true;
            this.ValidadeLabel.BindingField = null;
            this.ValidadeLabel.LiberadoQuandoCadastroUtilizado = false;
            this.ValidadeLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ValidadeLabel.Location = new System.Drawing.Point(13, 41);
            this.ValidadeLabel.Name = "ValidadeLabel";
            this.ValidadeLabel.Size = new System.Drawing.Size(48, 13);
            this.ValidadeLabel.TabIndex = 6;
            this.ValidadeLabel.Text = "Validade";
            // 
            // Validade
            // 
            this.Validade.BindingField = "Validade";
            this.Validade.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Validade.LiberadoQuandoCadastroUtilizado = false;
            this.Validade.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Validade.Location = new System.Drawing.Point(67, 38);
            this.Validade.Name = "Validade";
            this.Validade.Size = new System.Drawing.Size(150, 20);
            this.Validade.TabIndex = 7;
            this.Validade.Value = new System.DateTime(2014, 9, 16, 14, 43, 24, 732);
            this.Validade.CloseUp += new System.EventHandler(this.Validade_CloseUp);
            this.Validade.ValueChanged += new System.EventHandler(this.Validade_ValueChanged);
            this.Validade.Validated += new System.EventHandler(this.Validade_Validated);
            // 
            // VencidoLabel
            // 
            this.VencidoLabel.AutoSize = true;
            this.VencidoLabel.BindingField = null;
            this.VencidoLabel.LiberadoQuandoCadastroUtilizado = false;
            this.VencidoLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.VencidoLabel.Location = new System.Drawing.Point(15, 64);
            this.VencidoLabel.Name = "VencidoLabel";
            this.VencidoLabel.Size = new System.Drawing.Size(46, 13);
            this.VencidoLabel.TabIndex = 8;
            this.VencidoLabel.Text = "Vencido";
            // 
            // Vencido
            // 
            this.Vencido.AutoSize = true;
            this.Vencido.BindingField = "VencidoTela";
            this.Vencido.LiberadoQuandoCadastroUtilizado = false;
            this.Vencido.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Vencido.Location = new System.Drawing.Point(67, 64);
            this.Vencido.Name = "Vencido";
            this.Vencido.Size = new System.Drawing.Size(15, 14);
            this.Vencido.TabIndex = 9;
            this.Vencido.UseVisualStyleBackColor = true;
            // 
            // grbRevisao
            // 
            this.grbRevisao.Controls.Add(this.lblRevisaoJustificativa);
            this.grbRevisao.Controls.Add(this.lblRevisaoData);
            this.grbRevisao.Controls.Add(this.lblRevisaoUsuario);
            this.grbRevisao.Controls.Add(this.lblRevisaoJustificativaLabel);
            this.grbRevisao.Controls.Add(this.lblRevisaoDataLabel);
            this.grbRevisao.Controls.Add(this.lblRevisaoUsuarioLabel);
            this.grbRevisao.Location = new System.Drawing.Point(20, 187);
            this.grbRevisao.Name = "grbRevisao";
            this.grbRevisao.Size = new System.Drawing.Size(382, 94);
            this.grbRevisao.TabIndex = 10;
            this.grbRevisao.TabStop = false;
            this.grbRevisao.Text = "Revisão";
            // 
            // lblRevisaoJustificativa
            // 
            this.lblRevisaoJustificativa.AutoSize = true;
            this.lblRevisaoJustificativa.BindingField = "UltimaRevisao";
            this.lblRevisaoJustificativa.LiberadoQuandoCadastroUtilizado = false;
            this.lblRevisaoJustificativa.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblRevisaoJustificativa.Location = new System.Drawing.Point(100, 62);
            this.lblRevisaoJustificativa.Name = "lblRevisaoJustificativa";
            this.lblRevisaoJustificativa.Size = new System.Drawing.Size(0, 13);
            this.lblRevisaoJustificativa.TabIndex = 5;
            // 
            // lblRevisaoData
            // 
            this.lblRevisaoData.AutoSize = true;
            this.lblRevisaoData.BindingField = "UltimaRevisaoData";
            this.lblRevisaoData.LiberadoQuandoCadastroUtilizado = false;
            this.lblRevisaoData.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblRevisaoData.Location = new System.Drawing.Point(100, 39);
            this.lblRevisaoData.Name = "lblRevisaoData";
            this.lblRevisaoData.Size = new System.Drawing.Size(0, 13);
            this.lblRevisaoData.TabIndex = 4;
            // 
            // lblRevisaoUsuario
            // 
            this.lblRevisaoUsuario.AutoSize = true;
            this.lblRevisaoUsuario.BindingField = "UltimaRevisaoUsuario";
            this.lblRevisaoUsuario.LiberadoQuandoCadastroUtilizado = false;
            this.lblRevisaoUsuario.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblRevisaoUsuario.Location = new System.Drawing.Point(100, 16);
            this.lblRevisaoUsuario.Name = "lblRevisaoUsuario";
            this.lblRevisaoUsuario.Size = new System.Drawing.Size(0, 13);
            this.lblRevisaoUsuario.TabIndex = 3;
            // 
            // lblRevisaoJustificativaLabel
            // 
            this.lblRevisaoJustificativaLabel.AutoSize = true;
            this.lblRevisaoJustificativaLabel.BindingField = null;
            this.lblRevisaoJustificativaLabel.LiberadoQuandoCadastroUtilizado = false;
            this.lblRevisaoJustificativaLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblRevisaoJustificativaLabel.Location = new System.Drawing.Point(16, 62);
            this.lblRevisaoJustificativaLabel.Name = "lblRevisaoJustificativaLabel";
            this.lblRevisaoJustificativaLabel.Size = new System.Drawing.Size(62, 13);
            this.lblRevisaoJustificativaLabel.TabIndex = 2;
            this.lblRevisaoJustificativaLabel.Text = "Justificativa";
            // 
            // lblRevisaoDataLabel
            // 
            this.lblRevisaoDataLabel.AutoSize = true;
            this.lblRevisaoDataLabel.BindingField = null;
            this.lblRevisaoDataLabel.LiberadoQuandoCadastroUtilizado = false;
            this.lblRevisaoDataLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblRevisaoDataLabel.Location = new System.Drawing.Point(48, 39);
            this.lblRevisaoDataLabel.Name = "lblRevisaoDataLabel";
            this.lblRevisaoDataLabel.Size = new System.Drawing.Size(30, 13);
            this.lblRevisaoDataLabel.TabIndex = 1;
            this.lblRevisaoDataLabel.Text = "Data";
            // 
            // lblRevisaoUsuarioLabel
            // 
            this.lblRevisaoUsuarioLabel.AutoSize = true;
            this.lblRevisaoUsuarioLabel.BindingField = null;
            this.lblRevisaoUsuarioLabel.LiberadoQuandoCadastroUtilizado = false;
            this.lblRevisaoUsuarioLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblRevisaoUsuarioLabel.Location = new System.Drawing.Point(35, 16);
            this.lblRevisaoUsuarioLabel.Name = "lblRevisaoUsuarioLabel";
            this.lblRevisaoUsuarioLabel.Size = new System.Drawing.Size(43, 13);
            this.lblRevisaoUsuarioLabel.TabIndex = 0;
            this.lblRevisaoUsuarioLabel.Text = "Usuário";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lnkDocumento);
            this.groupBox2.Controls.Add(this.btnDocumentoEscaneado);
            this.groupBox2.Location = new System.Drawing.Point(67, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(335, 71);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Documento Escaneado/PDF";
            // 
            // lnkDocumento
            // 
            this.lnkDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkDocumento.BindingField = null;
            this.lnkDocumento.LiberadoQuandoCadastroUtilizado = true;
            this.lnkDocumento.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lnkDocumento.Location = new System.Drawing.Point(6, 29);
            this.lnkDocumento.Name = "lnkDocumento";
            this.lnkDocumento.Size = new System.Drawing.Size(233, 13);
            this.lnkDocumento.TabIndex = 11;
            this.lnkDocumento.TabStop = true;
            this.lnkDocumento.Text = "Download: ";
            this.lnkDocumento.Visible = false;
            this.lnkDocumento.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDocumento_LinkClicked);
            // 
            // btnDocumentoEscaneado
            // 
            this.btnDocumentoEscaneado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDocumentoEscaneado.LiberadoQuandoCadastroUtilizado = false;
            this.btnDocumentoEscaneado.Location = new System.Drawing.Point(245, 38);
            this.btnDocumentoEscaneado.Name = "btnDocumentoEscaneado";
            this.btnDocumentoEscaneado.Size = new System.Drawing.Size(85, 23);
            this.btnDocumentoEscaneado.TabIndex = 0;
            this.btnDocumentoEscaneado.Text = "Selecionar";
            this.btnDocumentoEscaneado.UseVisualStyleBackColor = true;
            this.btnDocumentoEscaneado.Click += new System.EventHandler(this.btnDocumentoEscaneado_Click);
            // 
            // ofdDocumento
            // 
            this.ofdDocumento.DefaultExt = "pdf";
            this.ofdDocumento.Filter = "PDF|*.pdf|JPG|*.jpg|BMP|*.bmp|PNG|*.png";
            this.ofdDocumento.RestoreDirectory = true;
            // 
            // CadEpiCaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(414, 366);
            this.Name = "CadEpiCaForm";
            this.Text = "CA";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Validade)).EndInit();
            this.grbRevisao.ResumeLayout(false);
            this.grbRevisao.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private IWTDotNetLib.IWTLabel NumeroLabel;
        private IWTDotNetLib.IWTTextBox Numero;
        private IWTDotNetLib.IWTLabel ValidadeLabel;
        private IWTDotNetLib.IWTDateTimePicker Validade;
        private IWTDotNetLib.IWTLabel VencidoLabel;
        private IWTDotNetLib.IWTCheckBox Vencido;
        private System.Windows.Forms.GroupBox grbRevisao;
        private IWTDotNetLib.IWTLabel lblRevisaoJustificativaLabel;
        private IWTDotNetLib.IWTLabel lblRevisaoDataLabel;
        private IWTDotNetLib.IWTLabel lblRevisaoUsuarioLabel;
        private IWTDotNetLib.IWTLabel lblRevisaoJustificativa;
        private IWTDotNetLib.IWTLabel lblRevisaoData; 
        private IWTDotNetLib.IWTLabel lblRevisaoUsuario;
        private System.Windows.Forms.GroupBox groupBox2;
        private IWTDotNetLib.IWTLinkLabel lnkDocumento;
        private IWTDotNetLib.IWTButton btnDocumentoEscaneado;
        private System.Windows.Forms.OpenFileDialog ofdDocumento; 
    }
} 
