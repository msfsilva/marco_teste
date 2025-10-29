namespace BibliotecaCadastrosBasicos
{
    partial class CadObservacaoAdicionalNfeForm
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
            this.CfopLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.Cfop = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.NcmLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.Ncm = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.CstIcmsLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.CstIcms = new IWTDotNetLib.IWTTextBox(this.components);
            this.ObservacaoLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.Observacao = new IWTDotNetLib.IWTTextBox(this.components);
            this.ObservacaoFiscoLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.ObservacaoFisco = new IWTDotNetLib.IWTTextBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Cfop)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.CfopLabel);
            this.splitContainer1.Panel1.Controls.Add(this.Cfop);
            this.splitContainer1.Panel1.Controls.Add(this.NcmLabel);
            this.splitContainer1.Panel1.Controls.Add(this.Ncm);
            this.splitContainer1.Panel1.Controls.Add(this.CstIcmsLabel);
            this.splitContainer1.Panel1.Controls.Add(this.CstIcms);
            this.splitContainer1.Panel1.Controls.Add(this.ObservacaoLabel);
            this.splitContainer1.Panel1.Controls.Add(this.Observacao);
            this.splitContainer1.Panel1.Controls.Add(this.ObservacaoFiscoLabel);
            this.splitContainer1.Panel1.Controls.Add(this.ObservacaoFisco);
            this.splitContainer1.Size = new System.Drawing.Size(561, 310);
            this.splitContainer1.SplitterDistance = 244;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(474, 20);
            // 
            // CfopLabel
            // 
            this.CfopLabel.AutoSize = true;
            this.CfopLabel.BindingField = null;
            this.CfopLabel.LiberadoQuandoCadastroUtilizado = false;
            this.CfopLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.CfopLabel.Location = new System.Drawing.Point(159, 15);
            this.CfopLabel.Name = "CfopLabel";
            this.CfopLabel.Size = new System.Drawing.Size(35, 13);
            this.CfopLabel.TabIndex = 0;
            this.CfopLabel.Text = "CFOP";
            // 
            // Cfop
            // 
            this.Cfop.BindingField = "Cfop";
            this.Cfop.LiberadoQuandoCadastroUtilizado = false;
            this.Cfop.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Cfop.Location = new System.Drawing.Point(200, 12);
            this.Cfop.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.Cfop.Name = "Cfop";
            this.Cfop.Size = new System.Drawing.Size(150, 20);
            this.Cfop.TabIndex = 1;
            // 
            // NcmLabel
            // 
            this.NcmLabel.AutoSize = true;
            this.NcmLabel.BindingField = null;
            this.NcmLabel.LiberadoQuandoCadastroUtilizado = false;
            this.NcmLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.NcmLabel.Location = new System.Drawing.Point(163, 42);
            this.NcmLabel.Name = "NcmLabel";
            this.NcmLabel.Size = new System.Drawing.Size(31, 13);
            this.NcmLabel.TabIndex = 2;
            this.NcmLabel.Text = "NCM";
            // 
            // Ncm
            // 
            this.Ncm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Ncm.BindingField = "Ncm";
            this.Ncm.ColunasDropdown = null;
            this.Ncm.DesabilitarAutoCompletar = false;
            this.Ncm.DesabilitarChekBox = false;
            this.Ncm.DesabilitarLupa = false;
            this.Ncm.DesabilitarSeta = false;
            this.Ncm.EntidadeSelecionada = null;
            this.Ncm.FormSelecao = null;
            this.Ncm.LiberadoQuandoCadastroUtilizado = false;
            this.Ncm.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Ncm.Location = new System.Drawing.Point(200, 39);
            this.Ncm.ModoVisualizacaoGrid = null;
            this.Ncm.Name = "Ncm";
            this.Ncm.ParametroBuscaGuiada = null;
            this.Ncm.ParametrosBuscaObrigatorios = null;
            this.Ncm.Size = new System.Drawing.Size(349, 21);
            this.Ncm.TabIndex = 3;
            // 
            // CstIcmsLabel
            // 
            this.CstIcmsLabel.AutoSize = true;
            this.CstIcmsLabel.BindingField = null;
            this.CstIcmsLabel.LiberadoQuandoCadastroUtilizado = false;
            this.CstIcmsLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.CstIcmsLabel.Location = new System.Drawing.Point(95, 69);
            this.CstIcmsLabel.Name = "CstIcmsLabel";
            this.CstIcmsLabel.Size = new System.Drawing.Size(99, 13);
            this.CstIcmsLabel.TabIndex = 4;
            this.CstIcmsLabel.Text = "CST/CSOSN ICMS";
            // 
            // CstIcms
            // 
            this.CstIcms.BindingField = "CstIcms";
            this.CstIcms.DebugMode = false;
            this.CstIcms.LiberadoQuandoCadastroUtilizado = false;
            this.CstIcms.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.CstIcms.Location = new System.Drawing.Point(200, 66);
            this.CstIcms.MaxLength = 3;
            this.CstIcms.ModoBarcode = false;
            this.CstIcms.ModoBusca = false;
            this.CstIcms.Name = "CstIcms";
            this.CstIcms.NaoLimparDepoisBarcode = false;
            this.CstIcms.Size = new System.Drawing.Size(51, 20);
            this.CstIcms.TabIndex = 5;
            // 
            // ObservacaoLabel
            // 
            this.ObservacaoLabel.AutoSize = true;
            this.ObservacaoLabel.BindingField = null;
            this.ObservacaoLabel.LiberadoQuandoCadastroUtilizado = false;
            this.ObservacaoLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ObservacaoLabel.Location = new System.Drawing.Point(129, 96);
            this.ObservacaoLabel.Name = "ObservacaoLabel";
            this.ObservacaoLabel.Size = new System.Drawing.Size(65, 13);
            this.ObservacaoLabel.TabIndex = 6;
            this.ObservacaoLabel.Text = "Observação";
            // 
            // Observacao
            // 
            this.Observacao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Observacao.BindingField = "Observacao";
            this.Observacao.DebugMode = false;
            this.Observacao.LiberadoQuandoCadastroUtilizado = false;
            this.Observacao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Observacao.Location = new System.Drawing.Point(200, 93);
            this.Observacao.ModoBarcode = false;
            this.Observacao.ModoBusca = false;
            this.Observacao.Multiline = true;
            this.Observacao.Name = "Observacao";
            this.Observacao.NaoLimparDepoisBarcode = false;
            this.Observacao.Size = new System.Drawing.Size(349, 64);
            this.Observacao.TabIndex = 7;
            // 
            // ObservacaoFiscoLabel
            // 
            this.ObservacaoFiscoLabel.AutoSize = true;
            this.ObservacaoFiscoLabel.BindingField = null;
            this.ObservacaoFiscoLabel.LiberadoQuandoCadastroUtilizado = false;
            this.ObservacaoFiscoLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ObservacaoFiscoLabel.Location = new System.Drawing.Point(101, 166);
            this.ObservacaoFiscoLabel.Name = "ObservacaoFiscoLabel";
            this.ObservacaoFiscoLabel.Size = new System.Drawing.Size(93, 13);
            this.ObservacaoFiscoLabel.TabIndex = 8;
            this.ObservacaoFiscoLabel.Text = "Observação Fisco";
            // 
            // ObservacaoFisco
            // 
            this.ObservacaoFisco.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ObservacaoFisco.BindingField = "ObservacaoFisco";
            this.ObservacaoFisco.DebugMode = false;
            this.ObservacaoFisco.LiberadoQuandoCadastroUtilizado = false;
            this.ObservacaoFisco.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ObservacaoFisco.Location = new System.Drawing.Point(200, 163);
            this.ObservacaoFisco.ModoBarcode = false;
            this.ObservacaoFisco.ModoBusca = false;
            this.ObservacaoFisco.Multiline = true;
            this.ObservacaoFisco.Name = "ObservacaoFisco";
            this.ObservacaoFisco.NaoLimparDepoisBarcode = false;
            this.ObservacaoFisco.Size = new System.Drawing.Size(349, 63);
            this.ObservacaoFisco.TabIndex = 9;
            // 
            // CadObservacaoAdicionalNfeForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(561, 310);
            this.Name = "CadObservacaoAdicionalNfeForm";
            this.Text = "Observação Adicional NFe";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Cfop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IWTDotNetLib.IWTLabel CfopLabel;
        private IWTDotNetLib.IWTNumericUpDown Cfop;
        private IWTDotNetLib.IWTLabel NcmLabel;
        private IWTDotNetLib.IWTEntitySelection Ncm;
        private IWTDotNetLib.IWTLabel CstIcmsLabel;
        private IWTDotNetLib.IWTTextBox CstIcms;
        private IWTDotNetLib.IWTLabel ObservacaoLabel;
        private IWTDotNetLib.IWTTextBox Observacao;
        private IWTDotNetLib.IWTLabel ObservacaoFiscoLabel;
        private IWTDotNetLib.IWTTextBox ObservacaoFisco;
    }
} 
