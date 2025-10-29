namespace BibliotecaRelatoriosProducao
{
    partial class RelatorioPedidoItemConsumoMedioReportForm
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
            this.cmbCliente = new IWTCustomControls.InheritedCombo.MultiColumnComboBox(this.components);
            this.label30 = new System.Windows.Forms.Label();
            this.chkProduto = new System.Windows.Forms.CheckBox();
            this.chkCliente = new System.Windows.Forms.CheckBox();
            this.grbProduto = new System.Windows.Forms.GroupBox();
            this.btnBuscaProduto = new System.Windows.Forms.Button();
            this.txtBuscaProduto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDimensao = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGerar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbAnual = new System.Windows.Forms.RadioButton();
            this.rdbSemestral = new System.Windows.Forms.RadioButton();
            this.rdbTrimestral = new System.Windows.Forms.RadioButton();
            this.rdbMensal = new System.Windows.Forms.RadioButton();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grbProduto.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cmbCliente);
            this.splitContainer1.Panel1.Controls.Add(this.label30);
            this.splitContainer1.Panel1.Controls.Add(this.chkProduto);
            this.splitContainer1.Panel1.Controls.Add(this.chkCliente);
            this.splitContainer1.Panel1.Controls.Add(this.grbProduto);
            this.splitContainer1.Panel1.Controls.Add(this.btnGerar);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.crystalReportViewer1);
            this.splitContainer1.Size = new System.Drawing.Size(686, 593);
            this.splitContainer1.SplitterDistance = 180;
            this.splitContainer1.TabIndex = 0;
            // 
            // cmbCliente
            // 
            this.cmbCliente.DropDownHeight = 1;
            this.cmbCliente.Enabled = false;
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.IntegralHeight = false;
            this.cmbCliente.Location = new System.Drawing.Point(69, 149);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.SelectedRow = null;
            this.cmbCliente.Size = new System.Drawing.Size(287, 21);
            this.cmbCliente.TabIndex = 150;
            this.cmbCliente.Table = null;
            this.cmbCliente.SelectedIndexChanged += new System.EventHandler(this.cmbCliente_SelectedIndexChanged);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(24, 154);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(39, 13);
            this.label30.TabIndex = 151;
            this.label30.Text = "Cliente";
            // 
            // chkProduto
            // 
            this.chkProduto.AutoSize = true;
            this.chkProduto.Location = new System.Drawing.Point(568, 73);
            this.chkProduto.Name = "chkProduto";
            this.chkProduto.Size = new System.Drawing.Size(15, 14);
            this.chkProduto.TabIndex = 7;
            this.chkProduto.UseVisualStyleBackColor = true;
            this.chkProduto.CheckedChanged += new System.EventHandler(this.chkProduto_CheckedChanged);
            // 
            // chkCliente
            // 
            this.chkCliente.AutoSize = true;
            this.chkCliente.Location = new System.Drawing.Point(362, 154);
            this.chkCliente.Name = "chkCliente";
            this.chkCliente.Size = new System.Drawing.Size(15, 14);
            this.chkCliente.TabIndex = 149;
            this.chkCliente.UseVisualStyleBackColor = true;
            this.chkCliente.CheckedChanged += new System.EventHandler(this.chkCliente_CheckedChanged);
            // 
            // grbProduto
            // 
            this.grbProduto.Controls.Add(this.btnBuscaProduto);
            this.grbProduto.Controls.Add(this.txtBuscaProduto);
            this.grbProduto.Controls.Add(this.label4);
            this.grbProduto.Controls.Add(this.lblDescricao);
            this.grbProduto.Controls.Add(this.label3);
            this.grbProduto.Controls.Add(this.txtDimensao);
            this.grbProduto.Controls.Add(this.label2);
            this.grbProduto.Controls.Add(this.label1);
            this.grbProduto.Enabled = false;
            this.grbProduto.Location = new System.Drawing.Point(12, 68);
            this.grbProduto.Name = "grbProduto";
            this.grbProduto.Size = new System.Drawing.Size(541, 72);
            this.grbProduto.TabIndex = 6;
            this.grbProduto.TabStop = false;
            this.grbProduto.Text = "Seleção de Produto";
            // 
            // btnBuscaProduto
            // 
            this.btnBuscaProduto.Location = new System.Drawing.Point(266, 20);
            this.btnBuscaProduto.Name = "btnBuscaProduto";
            this.btnBuscaProduto.Size = new System.Drawing.Size(78, 23);
            this.btnBuscaProduto.TabIndex = 87;
            this.btnBuscaProduto.Text = "Selecionar";
            this.btnBuscaProduto.UseVisualStyleBackColor = true;
            this.btnBuscaProduto.Click += new System.EventHandler(this.btnBuscaProduto_Click);
            // 
            // txtBuscaProduto
            // 
            this.txtBuscaProduto.BackColor = System.Drawing.SystemColors.Window;
            this.txtBuscaProduto.Location = new System.Drawing.Point(85, 22);
            this.txtBuscaProduto.Name = "txtBuscaProduto";
            this.txtBuscaProduto.Size = new System.Drawing.Size(175, 20);
            this.txtBuscaProduto.TabIndex = 86;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(411, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "Use zero para dimensão fixa";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescricao.Location = new System.Drawing.Point(82, 49);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(0, 13);
            this.lblDescricao.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Descrição ";
            // 
            // txtDimensao
            // 
            this.txtDimensao.Location = new System.Drawing.Point(414, 23);
            this.txtDimensao.Name = "txtDimensao";
            this.txtDimensao.Size = new System.Drawing.Size(118, 20);
            this.txtDimensao.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(358, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Dimensão";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Item";
            // 
            // btnGerar
            // 
            this.btnGerar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGerar.Location = new System.Drawing.Point(599, 152);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(75, 23);
            this.btnGerar.TabIndex = 3;
            this.btnGerar.Text = "Gerar";
            this.btnGerar.UseVisualStyleBackColor = true;
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbAnual);
            this.groupBox1.Controls.Add(this.rdbSemestral);
            this.groupBox1.Controls.Add(this.rdbTrimestral);
            this.groupBox1.Controls.Add(this.rdbMensal);
            this.groupBox1.Location = new System.Drawing.Point(12, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 52);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ordenação";
            // 
            // rdbAnual
            // 
            this.rdbAnual.AutoSize = true;
            this.rdbAnual.Location = new System.Drawing.Point(266, 22);
            this.rdbAnual.Name = "rdbAnual";
            this.rdbAnual.Size = new System.Drawing.Size(52, 17);
            this.rdbAnual.TabIndex = 3;
            this.rdbAnual.Text = "Anual";
            this.rdbAnual.UseVisualStyleBackColor = true;
            // 
            // rdbSemestral
            // 
            this.rdbSemestral.AutoSize = true;
            this.rdbSemestral.Location = new System.Drawing.Point(175, 22);
            this.rdbSemestral.Name = "rdbSemestral";
            this.rdbSemestral.Size = new System.Drawing.Size(71, 17);
            this.rdbSemestral.TabIndex = 2;
            this.rdbSemestral.Text = "Semestral";
            this.rdbSemestral.UseVisualStyleBackColor = true;
            // 
            // rdbTrimestral
            // 
            this.rdbTrimestral.AutoSize = true;
            this.rdbTrimestral.Location = new System.Drawing.Point(87, 22);
            this.rdbTrimestral.Name = "rdbTrimestral";
            this.rdbTrimestral.Size = new System.Drawing.Size(70, 17);
            this.rdbTrimestral.TabIndex = 1;
            this.rdbTrimestral.Text = "Trimestral";
            this.rdbTrimestral.UseVisualStyleBackColor = true;
            // 
            // rdbMensal
            // 
            this.rdbMensal.AutoSize = true;
            this.rdbMensal.Checked = true;
            this.rdbMensal.Location = new System.Drawing.Point(13, 21);
            this.rdbMensal.Name = "rdbMensal";
            this.rdbMensal.Size = new System.Drawing.Size(59, 17);
            this.rdbMensal.TabIndex = 0;
            this.rdbMensal.TabStop = true;
            this.rdbMensal.Text = "Mensal";
            this.rdbMensal.UseVisualStyleBackColor = true;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.ShowLogo = false;
            this.crystalReportViewer1.ShowParameterPanelButton = false;
            this.crystalReportViewer1.Size = new System.Drawing.Size(686, 409);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // RelatorioPedidoItemConsumoMedioReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(686, 593);
            this.Controls.Add(this.splitContainer1);
            this.Name = "RelatorioPedidoItemConsumoMedioReportForm";
            this.Text = "Demanda média de itens do cliente";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grbProduto.ResumeLayout(false);
            this.grbProduto.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Button btnGerar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbAnual;
        private System.Windows.Forms.RadioButton rdbSemestral;
        private System.Windows.Forms.RadioButton rdbTrimestral;
        private System.Windows.Forms.RadioButton rdbMensal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grbProduto;
        private System.Windows.Forms.CheckBox chkProduto;
        private System.Windows.Forms.TextBox txtDimensao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBuscaProduto;
        private System.Windows.Forms.TextBox txtBuscaProduto;
        private IWTCustomControls.InheritedCombo.MultiColumnComboBox cmbCliente;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.CheckBox chkCliente;
    }
}