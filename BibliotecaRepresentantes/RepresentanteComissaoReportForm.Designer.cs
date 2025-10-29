namespace BibliotecaRepresentantes
{
    partial class RepresentanteComissaoReportForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chkVendedor = new IWTDotNetLib.IWTCheckBox(this.components);
            this.cmbVendedor = new IWTDotNetLib.IWTMultiColumnComboBox(this.components);
            this.iwtLabel6 = new IWTDotNetLib.IWTLabel(this.components);
            this.chkSomenteSemComissao = new IWTDotNetLib.IWTCheckBox(this.components);
            this.iwtLabel4 = new IWTDotNetLib.IWTLabel(this.components);
            this.btnGerar = new IWTDotNetLib.IWTButton(this.components);
            this.chkEnviarEmail = new IWTDotNetLib.IWTCheckBox(this.components);
            this.txtMesAno = new IWTDotNetLib.IWTMaskedTextBox(this.components);
            this.chkRepresentante = new IWTDotNetLib.IWTCheckBox(this.components);
            this.cmbRepresentante = new IWTDotNetLib.IWTMultiColumnComboBox(this.components);
            this.iwtLabel2 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel3 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.lblAvisoModoComissao = new IWTDotNetLib.IWTLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblAvisoModoComissao);
            this.splitContainer1.Panel1.Controls.Add(this.chkVendedor);
            this.splitContainer1.Panel1.Controls.Add(this.cmbVendedor);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel6);
            this.splitContainer1.Panel1.Controls.Add(this.chkSomenteSemComissao);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel4);
            this.splitContainer1.Panel1.Controls.Add(this.btnGerar);
            this.splitContainer1.Panel1.Controls.Add(this.chkEnviarEmail);
            this.splitContainer1.Panel1.Controls.Add(this.txtMesAno);
            this.splitContainer1.Panel1.Controls.Add(this.chkRepresentante);
            this.splitContainer1.Panel1.Controls.Add(this.cmbRepresentante);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel2);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel3);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.crystalReportViewer1);
            this.splitContainer1.Size = new System.Drawing.Size(904, 614);
            this.splitContainer1.SplitterDistance = 150;
            this.splitContainer1.TabIndex = 0;
            // 
            // chkVendedor
            // 
            this.chkVendedor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkVendedor.AutoSize = true;
            this.chkVendedor.BindingField = null;
            this.chkVendedor.LiberadoQuandoCadastroUtilizado = false;
            this.chkVendedor.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkVendedor.Location = new System.Drawing.Point(875, 76);
            this.chkVendedor.Name = "chkVendedor";
            this.chkVendedor.Size = new System.Drawing.Size(15, 14);
            this.chkVendedor.TabIndex = 3;
            this.chkVendedor.UseVisualStyleBackColor = true;
            this.chkVendedor.CheckedChanged += new System.EventHandler(this.chkVendedor_CheckedChanged);
            // 
            // cmbVendedor
            // 
            this.cmbVendedor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbVendedor.BindingField = null;
            this.cmbVendedor.ColumnsToDisplay = null;
            this.cmbVendedor.DisableAutoSelectOnEmpty = false;
            this.cmbVendedor.DropDownHeight = 1;
            this.cmbVendedor.Enabled = false;
            this.cmbVendedor.FormattingEnabled = true;
            this.cmbVendedor.IntegralHeight = false;
            this.cmbVendedor.LiberadoQuandoCadastroUtilizado = false;
            this.cmbVendedor.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.cmbVendedor.Location = new System.Drawing.Point(213, 73);
            this.cmbVendedor.Name = "cmbVendedor";
            this.cmbVendedor.SelectedRow = null;
            this.cmbVendedor.Size = new System.Drawing.Size(656, 21);
            this.cmbVendedor.TabIndex = 4;
            this.cmbVendedor.Table = null;
            // 
            // iwtLabel6
            // 
            this.iwtLabel6.AutoSize = true;
            this.iwtLabel6.BindingField = null;
            this.iwtLabel6.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel6.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel6.Location = new System.Drawing.Point(154, 76);
            this.iwtLabel6.Name = "iwtLabel6";
            this.iwtLabel6.Size = new System.Drawing.Size(53, 13);
            this.iwtLabel6.TabIndex = 7;
            this.iwtLabel6.Text = "Vendedor";
            // 
            // chkSomenteSemComissao
            // 
            this.chkSomenteSemComissao.AutoSize = true;
            this.chkSomenteSemComissao.BindingField = null;
            this.chkSomenteSemComissao.LiberadoQuandoCadastroUtilizado = false;
            this.chkSomenteSemComissao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkSomenteSemComissao.Location = new System.Drawing.Point(213, 100);
            this.chkSomenteSemComissao.Name = "chkSomenteSemComissao";
            this.chkSomenteSemComissao.Size = new System.Drawing.Size(15, 14);
            this.chkSomenteSemComissao.TabIndex = 5;
            this.chkSomenteSemComissao.UseVisualStyleBackColor = true;
            // 
            // iwtLabel4
            // 
            this.iwtLabel4.AutoSize = true;
            this.iwtLabel4.BindingField = null;
            this.iwtLabel4.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel4.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel4.Location = new System.Drawing.Point(7, 100);
            this.iwtLabel4.Name = "iwtLabel4";
            this.iwtLabel4.Size = new System.Drawing.Size(200, 13);
            this.iwtLabel4.TabIndex = 5;
            this.iwtLabel4.Text = "Somente Pedidos Sem Comissão Gerada";
            // 
            // btnGerar
            // 
            this.btnGerar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGerar.LiberadoQuandoCadastroUtilizado = false;
            this.btnGerar.Location = new System.Drawing.Point(799, 119);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(93, 23);
            this.btnGerar.TabIndex = 7;
            this.btnGerar.Text = "Gerar/Enviar";
            this.btnGerar.UseVisualStyleBackColor = true;
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            // 
            // chkEnviarEmail
            // 
            this.chkEnviarEmail.AutoSize = true;
            this.chkEnviarEmail.BindingField = null;
            this.chkEnviarEmail.LiberadoQuandoCadastroUtilizado = false;
            this.chkEnviarEmail.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkEnviarEmail.Location = new System.Drawing.Point(213, 120);
            this.chkEnviarEmail.Name = "chkEnviarEmail";
            this.chkEnviarEmail.Size = new System.Drawing.Size(15, 14);
            this.chkEnviarEmail.TabIndex = 6;
            this.chkEnviarEmail.UseVisualStyleBackColor = true;
            // 
            // txtMesAno
            // 
            this.txtMesAno.BindingField = null;
            this.txtMesAno.LiberadoQuandoCadastroUtilizado = false;
            this.txtMesAno.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtMesAno.Location = new System.Drawing.Point(214, 23);
            this.txtMesAno.Mask = "00/0000";
            this.txtMesAno.Name = "txtMesAno";
            this.txtMesAno.Size = new System.Drawing.Size(85, 20);
            this.txtMesAno.TabIndex = 0;
            // 
            // chkRepresentante
            // 
            this.chkRepresentante.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRepresentante.AutoSize = true;
            this.chkRepresentante.BindingField = null;
            this.chkRepresentante.LiberadoQuandoCadastroUtilizado = false;
            this.chkRepresentante.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkRepresentante.Location = new System.Drawing.Point(875, 52);
            this.chkRepresentante.Name = "chkRepresentante";
            this.chkRepresentante.Size = new System.Drawing.Size(15, 14);
            this.chkRepresentante.TabIndex = 1;
            this.chkRepresentante.UseVisualStyleBackColor = true;
            this.chkRepresentante.CheckedChanged += new System.EventHandler(this.chkRepresentante_CheckedChanged);
            // 
            // cmbRepresentante
            // 
            this.cmbRepresentante.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRepresentante.BindingField = null;
            this.cmbRepresentante.ColumnsToDisplay = null;
            this.cmbRepresentante.DisableAutoSelectOnEmpty = false;
            this.cmbRepresentante.DropDownHeight = 1;
            this.cmbRepresentante.Enabled = false;
            this.cmbRepresentante.FormattingEnabled = true;
            this.cmbRepresentante.IntegralHeight = false;
            this.cmbRepresentante.LiberadoQuandoCadastroUtilizado = false;
            this.cmbRepresentante.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.cmbRepresentante.Location = new System.Drawing.Point(213, 49);
            this.cmbRepresentante.Name = "cmbRepresentante";
            this.cmbRepresentante.SelectedRow = null;
            this.cmbRepresentante.Size = new System.Drawing.Size(656, 21);
            this.cmbRepresentante.TabIndex = 2;
            this.cmbRepresentante.Table = null;
            // 
            // iwtLabel2
            // 
            this.iwtLabel2.AutoSize = true;
            this.iwtLabel2.BindingField = null;
            this.iwtLabel2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel2.Location = new System.Drawing.Point(157, 26);
            this.iwtLabel2.Name = "iwtLabel2";
            this.iwtLabel2.Size = new System.Drawing.Size(51, 13);
            this.iwtLabel2.TabIndex = 0;
            this.iwtLabel2.Text = "Mes/Ano";
            // 
            // iwtLabel3
            // 
            this.iwtLabel3.AutoSize = true;
            this.iwtLabel3.BindingField = null;
            this.iwtLabel3.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel3.Location = new System.Drawing.Point(123, 120);
            this.iwtLabel3.Name = "iwtLabel3";
            this.iwtLabel3.Size = new System.Drawing.Size(83, 13);
            this.iwtLabel3.TabIndex = 0;
            this.iwtLabel3.Text = "Enviar por Email";
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(131, 52);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(77, 13);
            this.iwtLabel1.TabIndex = 0;
            this.iwtLabel1.Text = "Representante";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(904, 460);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // lblAvisoModoComissao
            // 
            this.lblAvisoModoComissao.AutoSize = true;
            this.lblAvisoModoComissao.BindingField = null;
            this.lblAvisoModoComissao.LiberadoQuandoCadastroUtilizado = false;
            this.lblAvisoModoComissao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblAvisoModoComissao.Location = new System.Drawing.Point(305, 23);
            this.lblAvisoModoComissao.Name = "lblAvisoModoComissao";
            this.lblAvisoModoComissao.Size = new System.Drawing.Size(0, 13);
            this.lblAvisoModoComissao.TabIndex = 8;
            // 
            // RepresentanteComissaoReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(904, 614);
            this.Controls.Add(this.splitContainer1);
            this.Name = "RepresentanteComissaoReportForm";
            this.Text = "Comissões dos Representantes";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private IWTDotNetLib.IWTCheckBox chkRepresentante;
        private IWTDotNetLib.IWTMultiColumnComboBox cmbRepresentante;
        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTMaskedTextBox txtMesAno;
        private IWTDotNetLib.IWTLabel iwtLabel2;
        private IWTDotNetLib.IWTButton btnGerar;
        private IWTDotNetLib.IWTCheckBox chkEnviarEmail;
        private IWTDotNetLib.IWTLabel iwtLabel3;
        private IWTDotNetLib.IWTCheckBox chkSomenteSemComissao;
        private IWTDotNetLib.IWTLabel iwtLabel4;
        private IWTDotNetLib.IWTCheckBox chkVendedor;
        private IWTDotNetLib.IWTMultiColumnComboBox cmbVendedor;
        private IWTDotNetLib.IWTLabel iwtLabel6;
        private IWTDotNetLib.IWTLabel lblAvisoModoComissao;
    }
}