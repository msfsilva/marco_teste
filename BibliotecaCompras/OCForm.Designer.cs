namespace BibliotecaCompras
{
    partial class OCForm
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
            this.wizardStep1 = new System.Windows.Forms.Panel();
            this.cmbEpi = new IWTDotNetLib.IWTMultiColumnComboBox(this.components);
            this.rdbEpi = new System.Windows.Forms.RadioButton();
            this.cmbFornecedor = new IWTCustomControls.InheritedCombo.MultiColumnComboBox(this.components);
            this.cmbProduto = new IWTCustomControls.InheritedCombo.MultiColumnComboBox(this.components);
            this.cmbMaterial = new IWTCustomControls.InheritedCombo.MultiColumnComboBox(this.components);
            this.rdbFornecedor = new System.Windows.Forms.RadioButton();
            this.rdbMaterial = new System.Windows.Forms.RadioButton();
            this.rdbProduto = new System.Windows.Forms.RadioButton();
            this.wizardStep2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nudDesconto = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.chkFormaPagto = new System.Windows.Forms.CheckBox();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.cmbFormaPagto = new IWTCustomControls.InheritedCombo.MultiColumnComboBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOutroFornecedor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFornecedor2 = new IWTCustomControls.InheritedCombo.MultiColumnComboBox(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNextFinish = new System.Windows.Forms.Button();
            this.wizardStep1.SuspendLayout();
            this.wizardStep2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDesconto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizardStep1
            // 
            this.wizardStep1.Controls.Add(this.cmbEpi);
            this.wizardStep1.Controls.Add(this.rdbEpi);
            this.wizardStep1.Controls.Add(this.cmbFornecedor);
            this.wizardStep1.Controls.Add(this.cmbProduto);
            this.wizardStep1.Controls.Add(this.cmbMaterial);
            this.wizardStep1.Controls.Add(this.rdbFornecedor);
            this.wizardStep1.Controls.Add(this.rdbMaterial);
            this.wizardStep1.Controls.Add(this.rdbProduto);
            this.wizardStep1.Location = new System.Drawing.Point(7, 14);
            this.wizardStep1.Name = "wizardStep1";
            this.wizardStep1.Size = new System.Drawing.Size(1047, 77);
            this.wizardStep1.TabIndex = 0;
            // 
            // cmbEpi
            // 
            this.cmbEpi.BindingField = null;
            this.cmbEpi.ColumnsToDisplay = null;
            this.cmbEpi.DisableAutoSelectOnEmpty = false;
            this.cmbEpi.DropDownHeight = 1;
            this.cmbEpi.FormattingEnabled = true;
            this.cmbEpi.IntegralHeight = false;
            this.cmbEpi.LiberadoQuandoCadastroUtilizado = false;
            this.cmbEpi.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.cmbEpi.Location = new System.Drawing.Point(509, 37);
            this.cmbEpi.Name = "cmbEpi";
            this.cmbEpi.SelectedRow = null;
            this.cmbEpi.Size = new System.Drawing.Size(242, 21);
            this.cmbEpi.TabIndex = 8;
            this.cmbEpi.Table = null;
            // 
            // rdbEpi
            // 
            this.rdbEpi.AutoSize = true;
            this.rdbEpi.Location = new System.Drawing.Point(509, 14);
            this.rdbEpi.Name = "rdbEpi";
            this.rdbEpi.Size = new System.Drawing.Size(40, 17);
            this.rdbEpi.TabIndex = 7;
            this.rdbEpi.Text = "Epi";
            this.rdbEpi.UseVisualStyleBackColor = true;
            this.rdbEpi.CheckedChanged += new System.EventHandler(this.rdbEpi_CheckedChanged);
            // 
            // cmbFornecedor
            // 
            this.cmbFornecedor.ColumnsToDisplay = null;
            this.cmbFornecedor.DisableAutoSelectOnEmpty = false;
            this.cmbFornecedor.DropDownHeight = 1;
            this.cmbFornecedor.FormattingEnabled = true;
            this.cmbFornecedor.IntegralHeight = false;
            this.cmbFornecedor.Location = new System.Drawing.Point(757, 37);
            this.cmbFornecedor.Name = "cmbFornecedor";
            this.cmbFornecedor.SelectedRow = null;
            this.cmbFornecedor.Size = new System.Drawing.Size(242, 21);
            this.cmbFornecedor.TabIndex = 6;
            this.cmbFornecedor.Table = null;
            // 
            // cmbProduto
            // 
            this.cmbProduto.ColumnsToDisplay = null;
            this.cmbProduto.DisableAutoSelectOnEmpty = false;
            this.cmbProduto.DropDownHeight = 1;
            this.cmbProduto.FormattingEnabled = true;
            this.cmbProduto.IntegralHeight = false;
            this.cmbProduto.Location = new System.Drawing.Point(13, 37);
            this.cmbProduto.Name = "cmbProduto";
            this.cmbProduto.SelectedRow = null;
            this.cmbProduto.Size = new System.Drawing.Size(242, 21);
            this.cmbProduto.TabIndex = 5;
            this.cmbProduto.Table = null;
            // 
            // cmbMaterial
            // 
            this.cmbMaterial.ColumnsToDisplay = null;
            this.cmbMaterial.DisableAutoSelectOnEmpty = false;
            this.cmbMaterial.DropDownHeight = 1;
            this.cmbMaterial.FormattingEnabled = true;
            this.cmbMaterial.IntegralHeight = false;
            this.cmbMaterial.Location = new System.Drawing.Point(261, 37);
            this.cmbMaterial.Name = "cmbMaterial";
            this.cmbMaterial.SelectedRow = null;
            this.cmbMaterial.Size = new System.Drawing.Size(242, 21);
            this.cmbMaterial.TabIndex = 4;
            this.cmbMaterial.Table = null;
            // 
            // rdbFornecedor
            // 
            this.rdbFornecedor.AutoSize = true;
            this.rdbFornecedor.Location = new System.Drawing.Point(757, 14);
            this.rdbFornecedor.Name = "rdbFornecedor";
            this.rdbFornecedor.Size = new System.Drawing.Size(79, 17);
            this.rdbFornecedor.TabIndex = 2;
            this.rdbFornecedor.Text = "Fornecedor";
            this.rdbFornecedor.UseVisualStyleBackColor = true;
            this.rdbFornecedor.CheckedChanged += new System.EventHandler(this.rdbFornecedor_CheckedChanged);
            // 
            // rdbMaterial
            // 
            this.rdbMaterial.AutoSize = true;
            this.rdbMaterial.Location = new System.Drawing.Point(261, 14);
            this.rdbMaterial.Name = "rdbMaterial";
            this.rdbMaterial.Size = new System.Drawing.Size(62, 17);
            this.rdbMaterial.TabIndex = 1;
            this.rdbMaterial.Text = "Material";
            this.rdbMaterial.UseVisualStyleBackColor = true;
            this.rdbMaterial.CheckedChanged += new System.EventHandler(this.rdbMaterial_CheckedChanged);
            // 
            // rdbProduto
            // 
            this.rdbProduto.AutoSize = true;
            this.rdbProduto.Checked = true;
            this.rdbProduto.Location = new System.Drawing.Point(13, 14);
            this.rdbProduto.Name = "rdbProduto";
            this.rdbProduto.Size = new System.Drawing.Size(62, 17);
            this.rdbProduto.TabIndex = 0;
            this.rdbProduto.TabStop = true;
            this.rdbProduto.Text = "Produto";
            this.rdbProduto.UseVisualStyleBackColor = true;
            this.rdbProduto.CheckedChanged += new System.EventHandler(this.rdbProduto_CheckedChanged);
            // 
            // wizardStep2
            // 
            this.wizardStep2.Controls.Add(this.splitContainer1);
            this.wizardStep2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardStep2.Location = new System.Drawing.Point(0, 0);
            this.wizardStep2.Name = "wizardStep2";
            this.wizardStep2.Size = new System.Drawing.Size(1066, 390);
            this.wizardStep2.TabIndex = 1;
            this.wizardStep2.Visible = false;
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
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.nudDesconto);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.chkFormaPagto);
            this.splitContainer1.Panel2.Controls.Add(this.txtObs);
            this.splitContainer1.Panel2.Controls.Add(this.cmbFormaPagto);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.btnOutroFornecedor);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.cmbFornecedor2);
            this.splitContainer1.Size = new System.Drawing.Size(1066, 390);
            this.splitContainer1.SplitterDistance = 272;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1066, 272);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // nudDesconto
            // 
            this.nudDesconto.DecimalPlaces = 4;
            this.nudDesconto.Location = new System.Drawing.Point(502, 39);
            this.nudDesconto.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            131072});
            this.nudDesconto.Name = "nudDesconto";
            this.nudDesconto.Size = new System.Drawing.Size(120, 20);
            this.nudDesconto.TabIndex = 4;
            this.nudDesconto.ValueChanged += new System.EventHandler(this.nudDesconto_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(429, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Desconto(%)";
            // 
            // chkFormaPagto
            // 
            this.chkFormaPagto.AutoSize = true;
            this.chkFormaPagto.Checked = true;
            this.chkFormaPagto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFormaPagto.Location = new System.Drawing.Point(374, 41);
            this.chkFormaPagto.Name = "chkFormaPagto";
            this.chkFormaPagto.Size = new System.Drawing.Size(15, 14);
            this.chkFormaPagto.TabIndex = 3;
            this.chkFormaPagto.UseVisualStyleBackColor = true;
            this.chkFormaPagto.CheckedChanged += new System.EventHandler(this.chkFormaPagto_CheckedChanged);
            // 
            // txtObs
            // 
            this.txtObs.Location = new System.Drawing.Point(126, 66);
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(496, 34);
            this.txtObs.TabIndex = 5;
            // 
            // cmbFormaPagto
            // 
            this.cmbFormaPagto.ColumnsToDisplay = null;
            this.cmbFormaPagto.DisableAutoSelectOnEmpty = false;
            this.cmbFormaPagto.DropDownHeight = 1;
            this.cmbFormaPagto.FormattingEnabled = true;
            this.cmbFormaPagto.IntegralHeight = false;
            this.cmbFormaPagto.Location = new System.Drawing.Point(126, 39);
            this.cmbFormaPagto.Name = "cmbFormaPagto";
            this.cmbFormaPagto.SelectedRow = null;
            this.cmbFormaPagto.Size = new System.Drawing.Size(242, 21);
            this.cmbFormaPagto.TabIndex = 2;
            this.cmbFormaPagto.Table = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Observação";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Forma de Pagamento";
            // 
            // btnOutroFornecedor
            // 
            this.btnOutroFornecedor.Enabled = false;
            this.btnOutroFornecedor.Location = new System.Drawing.Point(461, 12);
            this.btnOutroFornecedor.Name = "btnOutroFornecedor";
            this.btnOutroFornecedor.Size = new System.Drawing.Size(161, 23);
            this.btnOutroFornecedor.TabIndex = 1;
            this.btnOutroFornecedor.Text = "Escolher Outro Fornecedor";
            this.btnOutroFornecedor.UseVisualStyleBackColor = true;
            this.btnOutroFornecedor.Visible = false;
            this.btnOutroFornecedor.Click += new System.EventHandler(this.btnOutroFornecedor_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(896, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "TOTAL";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Fornecedor";
            this.label1.Visible = false;
            // 
            // cmbFornecedor2
            // 
            this.cmbFornecedor2.ColumnsToDisplay = null;
            this.cmbFornecedor2.DisableAutoSelectOnEmpty = false;
            this.cmbFornecedor2.DropDownHeight = 1;
            this.cmbFornecedor2.Enabled = false;
            this.cmbFornecedor2.FormattingEnabled = true;
            this.cmbFornecedor2.IntegralHeight = false;
            this.cmbFornecedor2.Location = new System.Drawing.Point(126, 12);
            this.cmbFornecedor2.Name = "cmbFornecedor2";
            this.cmbFornecedor2.SelectedRow = null;
            this.cmbFornecedor2.Size = new System.Drawing.Size(329, 21);
            this.cmbFornecedor2.TabIndex = 0;
            this.cmbFornecedor2.Table = null;
            this.cmbFornecedor2.Visible = false;
            this.cmbFornecedor2.SelectedIndexChanged += new System.EventHandler(this.cmbFornecedor2_SelectedIndexChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.wizardStep1);
            this.splitContainer2.Panel1.Controls.Add(this.wizardStep2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer2.Panel2.Controls.Add(this.btnNextFinish);
            this.splitContainer2.Size = new System.Drawing.Size(1066, 440);
            this.splitContainer2.SplitterDistance = 390;
            this.splitContainer2.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 11);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNextFinish
            // 
            this.btnNextFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextFinish.Location = new System.Drawing.Point(979, 11);
            this.btnNextFinish.Name = "btnNextFinish";
            this.btnNextFinish.Size = new System.Drawing.Size(75, 23);
            this.btnNextFinish.TabIndex = 0;
            this.btnNextFinish.Text = "Avançar";
            this.btnNextFinish.UseVisualStyleBackColor = true;
            this.btnNextFinish.Click += new System.EventHandler(this.btnNextFinish_Click);
            // 
            // OCForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1066, 440);
            this.Controls.Add(this.splitContainer2);
            this.Name = "OCForm";
            this.Text = "Ordem de Compra";
            this.wizardStep1.ResumeLayout(false);
            this.wizardStep1.PerformLayout();
            this.wizardStep2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDesconto)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel wizardStep1;
        private System.Windows.Forms.RadioButton rdbFornecedor;
        private System.Windows.Forms.RadioButton rdbMaterial;
        private System.Windows.Forms.RadioButton rdbProduto;
        private System.Windows.Forms.Panel wizardStep2;
        private IWTCustomControls.InheritedCombo.MultiColumnComboBox cmbFornecedor;
        private IWTCustomControls.InheritedCombo.MultiColumnComboBox cmbProduto;
        private IWTCustomControls.InheritedCombo.MultiColumnComboBox cmbMaterial;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private IWTCustomControls.InheritedCombo.MultiColumnComboBox cmbFornecedor2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNextFinish;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOutroFornecedor;
        private IWTCustomControls.InheritedCombo.MultiColumnComboBox cmbFormaPagto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtObs;
        private System.Windows.Forms.CheckBox chkFormaPagto;
        private System.Windows.Forms.NumericUpDown nudDesconto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rdbEpi;
        private IWTDotNetLib.IWTMultiColumnComboBox cmbEpi;
    }
}