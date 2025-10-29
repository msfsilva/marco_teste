namespace BibliotecaRepresentantes
{
    partial class GerarComissoeRepresentantesForm
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
            this.dtpVencimento = new IWTDotNetLib.IWTDateTimePicker(this.components);
            this.label1 = new IWTDotNetLib.IWTLabel(this.components);
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnCentroCusto = new System.Windows.Forms.Button();
            this.txtCentroCusto = new IWTDotNetLib.IWTTextBox(this.components);
            this.label13 = new IWTDotNetLib.IWTLabel(this.components);
            this.cmbContaBancaria = new IWTDotNetLib.IWTMultiColumnComboBox(this.components);
            this.label8 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtMesAno = new IWTDotNetLib.IWTMaskedTextBox(this.components);
            this.chkRepresentante = new IWTDotNetLib.IWTCheckBox(this.components);
            this.cmbRepresentante = new IWTDotNetLib.IWTMultiColumnComboBox(this.components);
            this.iwtLabel2 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.btnGerar = new IWTDotNetLib.IWTButton(this.components);
            this.cmbVendedor = new IWTDotNetLib.IWTMultiColumnComboBox(this.components);
            this.iwtLabel6 = new IWTDotNetLib.IWTLabel(this.components);
            this.chkVendedor = new IWTDotNetLib.IWTCheckBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.chkVendedor);
            this.splitContainer1.Panel1.Controls.Add(this.cmbVendedor);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel6);
            this.splitContainer1.Panel1.Controls.Add(this.dtpVencimento);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox7);
            this.splitContainer1.Panel1.Controls.Add(this.txtMesAno);
            this.splitContainer1.Panel1.Controls.Add(this.chkRepresentante);
            this.splitContainer1.Panel1.Controls.Add(this.cmbRepresentante);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel2);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnGerar);
            this.splitContainer1.Size = new System.Drawing.Size(668, 333);
            this.splitContainer1.SplitterDistance = 267;
            this.splitContainer1.TabIndex = 0;
            // 
            // dtpVencimento
            // 
            this.dtpVencimento.BindingField = null;
            this.dtpVencimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpVencimento.LiberadoQuandoCadastroUtilizado = false;
            this.dtpVencimento.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.dtpVencimento.Location = new System.Drawing.Point(159, 92);
            this.dtpVencimento.Name = "dtpVencimento";
            this.dtpVencimento.Size = new System.Drawing.Size(108, 20);
            this.dtpVencimento.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BindingField = null;
            this.label1.LiberadoQuandoCadastroUtilizado = false;
            this.label1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label1.Location = new System.Drawing.Point(17, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Vencimento das Comissões";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnCentroCusto);
            this.groupBox7.Controls.Add(this.txtCentroCusto);
            this.groupBox7.Controls.Add(this.label13);
            this.groupBox7.Controls.Add(this.cmbContaBancaria);
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Location = new System.Drawing.Point(11, 172);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(624, 79);
            this.groupBox7.TabIndex = 6;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Informações Financeiras para Comissões que não tiverem definidas as suas próprias" +
    " Informações";
            // 
            // btnCentroCusto
            // 
            this.btnCentroCusto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCentroCusto.Location = new System.Drawing.Point(556, 44);
            this.btnCentroCusto.Name = "btnCentroCusto";
            this.btnCentroCusto.Size = new System.Drawing.Size(38, 23);
            this.btnCentroCusto.TabIndex = 1;
            this.btnCentroCusto.Text = "...";
            this.btnCentroCusto.UseVisualStyleBackColor = true;
            this.btnCentroCusto.Click += new System.EventHandler(this.btnCentroCusto_Click);
            // 
            // txtCentroCusto
            // 
            this.txtCentroCusto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCentroCusto.BindingField = null;
            this.txtCentroCusto.LiberadoQuandoCadastroUtilizado = false;
            this.txtCentroCusto.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtCentroCusto.Location = new System.Drawing.Point(159, 46);
            this.txtCentroCusto.Name = "txtCentroCusto";
            this.txtCentroCusto.ReadOnly = true;
            this.txtCentroCusto.Size = new System.Drawing.Size(391, 20);
            this.txtCentroCusto.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BindingField = null;
            this.label13.LiberadoQuandoCadastroUtilizado = false;
            this.label13.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label13.Location = new System.Drawing.Point(33, 49);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 13);
            this.label13.TabIndex = 10;
            this.label13.Text = "Centro de Custo";
            // 
            // cmbContaBancaria
            // 
            this.cmbContaBancaria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbContaBancaria.BindingField = "ContaBancaria";
            this.cmbContaBancaria.ColumnsToDisplay = null;
            this.cmbContaBancaria.DisableAutoSelectOnEmpty = false;
            this.cmbContaBancaria.DropDownHeight = 1;
            this.cmbContaBancaria.FormattingEnabled = true;
            this.cmbContaBancaria.IntegralHeight = false;
            this.cmbContaBancaria.LiberadoQuandoCadastroUtilizado = false;
            this.cmbContaBancaria.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.cmbContaBancaria.Location = new System.Drawing.Point(159, 19);
            this.cmbContaBancaria.Name = "cmbContaBancaria";
            this.cmbContaBancaria.SelectedRow = null;
            this.cmbContaBancaria.Size = new System.Drawing.Size(435, 21);
            this.cmbContaBancaria.TabIndex = 0;
            this.cmbContaBancaria.Table = null;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BindingField = null;
            this.label8.LiberadoQuandoCadastroUtilizado = false;
            this.label8.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label8.Location = new System.Drawing.Point(36, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Conta Bancária";
            // 
            // txtMesAno
            // 
            this.txtMesAno.BindingField = null;
            this.txtMesAno.LiberadoQuandoCadastroUtilizado = false;
            this.txtMesAno.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtMesAno.Location = new System.Drawing.Point(159, 12);
            this.txtMesAno.Mask = "00/0000";
            this.txtMesAno.Name = "txtMesAno";
            this.txtMesAno.Size = new System.Drawing.Size(108, 20);
            this.txtMesAno.TabIndex = 0;
            // 
            // chkRepresentante
            // 
            this.chkRepresentante.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRepresentante.AutoSize = true;
            this.chkRepresentante.BindingField = null;
            this.chkRepresentante.LiberadoQuandoCadastroUtilizado = false;
            this.chkRepresentante.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkRepresentante.Location = new System.Drawing.Point(642, 41);
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
            this.cmbRepresentante.Location = new System.Drawing.Point(159, 38);
            this.cmbRepresentante.Name = "cmbRepresentante";
            this.cmbRepresentante.SelectedRow = null;
            this.cmbRepresentante.Size = new System.Drawing.Size(477, 21);
            this.cmbRepresentante.TabIndex = 2;
            this.cmbRepresentante.Table = null;
            // 
            // iwtLabel2
            // 
            this.iwtLabel2.AutoSize = true;
            this.iwtLabel2.BindingField = null;
            this.iwtLabel2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel2.Location = new System.Drawing.Point(101, 15);
            this.iwtLabel2.Name = "iwtLabel2";
            this.iwtLabel2.Size = new System.Drawing.Size(51, 13);
            this.iwtLabel2.TabIndex = 4;
            this.iwtLabel2.Text = "Mes/Ano";
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(75, 41);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(77, 13);
            this.iwtLabel1.TabIndex = 3;
            this.iwtLabel1.Text = "Representante";
            // 
            // btnGerar
            // 
            this.btnGerar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGerar.LiberadoQuandoCadastroUtilizado = false;
            this.btnGerar.Location = new System.Drawing.Point(581, 20);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(75, 23);
            this.btnGerar.TabIndex = 0;
            this.btnGerar.Text = "Gerar";
            this.btnGerar.UseVisualStyleBackColor = true;
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
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
            this.cmbVendedor.Location = new System.Drawing.Point(159, 65);
            this.cmbVendedor.Name = "cmbVendedor";
            this.cmbVendedor.SelectedRow = null;
            this.cmbVendedor.Size = new System.Drawing.Size(477, 21);
            this.cmbVendedor.TabIndex = 4;
            this.cmbVendedor.Table = null;
            // 
            // iwtLabel6
            // 
            this.iwtLabel6.AutoSize = true;
            this.iwtLabel6.BindingField = null;
            this.iwtLabel6.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel6.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel6.Location = new System.Drawing.Point(99, 68);
            this.iwtLabel6.Name = "iwtLabel6";
            this.iwtLabel6.Size = new System.Drawing.Size(53, 13);
            this.iwtLabel6.TabIndex = 17;
            this.iwtLabel6.Text = "Vendedor";
            // 
            // chkVendedor
            // 
            this.chkVendedor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkVendedor.AutoSize = true;
            this.chkVendedor.BindingField = null;
            this.chkVendedor.LiberadoQuandoCadastroUtilizado = false;
            this.chkVendedor.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkVendedor.Location = new System.Drawing.Point(642, 68);
            this.chkVendedor.Name = "chkVendedor";
            this.chkVendedor.Size = new System.Drawing.Size(15, 14);
            this.chkVendedor.TabIndex = 3;
            this.chkVendedor.UseVisualStyleBackColor = true;
            this.chkVendedor.CheckedChanged += new System.EventHandler(this.chkVendedor_CheckedChanged);
            // 
            // GerarComissoeRepresentantesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(668, 333);
            this.Controls.Add(this.splitContainer1);
            this.Name = "GerarComissoeRepresentantesForm";
            this.Text = "Gerar Comissões dos Representantes";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private IWTDotNetLib.IWTButton btnGerar;
        private IWTDotNetLib.IWTMaskedTextBox txtMesAno;
        private IWTDotNetLib.IWTCheckBox chkRepresentante;
        private IWTDotNetLib.IWTMultiColumnComboBox cmbRepresentante;
        private IWTDotNetLib.IWTLabel iwtLabel2;
        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTLabel label1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnCentroCusto;
        private IWTDotNetLib.IWTTextBox txtCentroCusto;
        private IWTDotNetLib.IWTLabel label13;
        private IWTDotNetLib.IWTMultiColumnComboBox cmbContaBancaria;
        private IWTDotNetLib.IWTLabel label8;
        private IWTDotNetLib.IWTDateTimePicker dtpVencimento;
        private IWTDotNetLib.IWTMultiColumnComboBox cmbVendedor;
        private IWTDotNetLib.IWTLabel iwtLabel6;
        private IWTDotNetLib.IWTCheckBox chkVendedor;
    }
}