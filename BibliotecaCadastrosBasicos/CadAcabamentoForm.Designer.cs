namespace BibliotecaCadastrosBasicos
{
    partial class CadAcabamentoForm
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
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel2 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel3 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel4 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtTextBox1 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtTextBox2 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtTextBox3 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtTextBox4 = new IWTDotNetLib.IWTTextBox(this.components);
            this.grbRevisao = new System.Windows.Forms.GroupBox();
            this.lblRevisaoJustificativa = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisaoData = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisaoUsuario = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisaoJustificativaLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisaoDataLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisaoUsuarioLabel = new IWTDotNetLib.IWTLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grbRevisao.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grbRevisao);
            this.splitContainer1.Panel1.Controls.Add(this.iwtTextBox4);
            this.splitContainer1.Panel1.Controls.Add(this.iwtTextBox3);
            this.splitContainer1.Panel1.Controls.Add(this.iwtTextBox2);
            this.splitContainer1.Panel1.Controls.Add(this.iwtTextBox1);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel4);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel3);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel2);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel1);
            this.splitContainer1.Size = new System.Drawing.Size(421, 318);
            this.splitContainer1.SplitterDistance = 252;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(334, 20);
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(12, 15);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(68, 13);
            this.iwtLabel1.TabIndex = 0;
            this.iwtLabel1.Text = "Identificação";
            // 
            // iwtLabel2
            // 
            this.iwtLabel2.AutoSize = true;
            this.iwtLabel2.BindingField = null;
            this.iwtLabel2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel2.Location = new System.Drawing.Point(25, 41);
            this.iwtLabel2.Name = "iwtLabel2";
            this.iwtLabel2.Size = new System.Drawing.Size(55, 13);
            this.iwtLabel2.TabIndex = 1;
            this.iwtLabel2.Text = "Descrição";
            // 
            // iwtLabel3
            // 
            this.iwtLabel3.AutoSize = true;
            this.iwtLabel3.BindingField = null;
            this.iwtLabel3.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel3.Location = new System.Drawing.Point(7, 67);
            this.iwtLabel3.Name = "iwtLabel3";
            this.iwtLabel3.Size = new System.Drawing.Size(73, 13);
            this.iwtLabel3.TabIndex = 2;
            this.iwtLabel3.Text = "Norma Cliente";
            // 
            // iwtLabel4
            // 
            this.iwtLabel4.AutoSize = true;
            this.iwtLabel4.BindingField = null;
            this.iwtLabel4.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel4.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel4.Location = new System.Drawing.Point(54, 93);
            this.iwtLabel4.Name = "iwtLabel4";
            this.iwtLabel4.Size = new System.Drawing.Size(26, 13);
            this.iwtLabel4.TabIndex = 3;
            this.iwtLabel4.Text = "Obs";
            // 
            // iwtTextBox1
            // 
            this.iwtTextBox1.BindingField = "Identificacao";
            this.iwtTextBox1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtTextBox1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox1.Location = new System.Drawing.Point(87, 12);
            this.iwtTextBox1.MaxLength = 20;
            this.iwtTextBox1.Name = "iwtTextBox1";
            this.iwtTextBox1.Size = new System.Drawing.Size(311, 20);
            this.iwtTextBox1.TabIndex = 4;
            // 
            // iwtTextBox2
            // 
            this.iwtTextBox2.BindingField = "DescricaoTecnica";
            this.iwtTextBox2.LiberadoQuandoCadastroUtilizado = true;
            this.iwtTextBox2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox2.Location = new System.Drawing.Point(86, 38);
            this.iwtTextBox2.MaxLength = 255;
            this.iwtTextBox2.Name = "iwtTextBox2";
            this.iwtTextBox2.Size = new System.Drawing.Size(311, 20);
            this.iwtTextBox2.TabIndex = 5;
            // 
            // iwtTextBox3
            // 
            this.iwtTextBox3.BindingField = "NormaCliente";
            this.iwtTextBox3.LiberadoQuandoCadastroUtilizado = true;
            this.iwtTextBox3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox3.Location = new System.Drawing.Point(86, 64);
            this.iwtTextBox3.MaxLength = 255;
            this.iwtTextBox3.Name = "iwtTextBox3";
            this.iwtTextBox3.Size = new System.Drawing.Size(311, 20);
            this.iwtTextBox3.TabIndex = 6;
            // 
            // iwtTextBox4
            // 
            this.iwtTextBox4.BindingField = "Obs";
            this.iwtTextBox4.LiberadoQuandoCadastroUtilizado = true;
            this.iwtTextBox4.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox4.Location = new System.Drawing.Point(86, 90);
            this.iwtTextBox4.MaxLength = 255;
            this.iwtTextBox4.Name = "iwtTextBox4";
            this.iwtTextBox4.Size = new System.Drawing.Size(311, 20);
            this.iwtTextBox4.TabIndex = 7;
            // 
            // grbRevisao
            // 
            this.grbRevisao.Controls.Add(this.lblRevisaoJustificativa);
            this.grbRevisao.Controls.Add(this.lblRevisaoData);
            this.grbRevisao.Controls.Add(this.lblRevisaoUsuario);
            this.grbRevisao.Controls.Add(this.lblRevisaoJustificativaLabel);
            this.grbRevisao.Controls.Add(this.lblRevisaoDataLabel);
            this.grbRevisao.Controls.Add(this.lblRevisaoUsuarioLabel);
            this.grbRevisao.Location = new System.Drawing.Point(16, 135);
            this.grbRevisao.Name = "grbRevisao";
            this.grbRevisao.Size = new System.Drawing.Size(382, 94);
            this.grbRevisao.TabIndex = 8;
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
            // CadAcabamentoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(421, 318);
            this.Name = "CadAcabamentoForm";
            this.Text = "Acabamento";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grbRevisao.ResumeLayout(false);
            this.grbRevisao.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTLabel iwtLabel4;
        private IWTDotNetLib.IWTLabel iwtLabel3;
        private IWTDotNetLib.IWTLabel iwtLabel2;
        private IWTDotNetLib.IWTTextBox iwtTextBox4;
        private IWTDotNetLib.IWTTextBox iwtTextBox3;
        private IWTDotNetLib.IWTTextBox iwtTextBox2;
        private IWTDotNetLib.IWTTextBox iwtTextBox1;
        private System.Windows.Forms.GroupBox grbRevisao;
        private IWTDotNetLib.IWTLabel lblRevisaoJustificativaLabel;
        private IWTDotNetLib.IWTLabel lblRevisaoDataLabel;
        private IWTDotNetLib.IWTLabel lblRevisaoUsuarioLabel;
        private IWTDotNetLib.IWTLabel lblRevisaoJustificativa;
        private IWTDotNetLib.IWTLabel lblRevisaoData;
        private IWTDotNetLib.IWTLabel lblRevisaoUsuario;
    }
}