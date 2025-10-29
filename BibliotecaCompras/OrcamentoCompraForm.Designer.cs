namespace BibliotecaCompras
{
    partial class OrcamentoCompraForm
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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.lblTipo = new System.Windows.Forms.Label();
            this.rdbSolCompra = new System.Windows.Forms.RadioButton();
            this.rdbMaterial = new System.Windows.Forms.RadioButton();
            this.rdbProduto = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.nudPrazo = new System.Windows.Forms.NumericUpDown();
            this.dgvSolicitacaoCompra = new System.Windows.Forms.DataGridView();
            this.dgvProduto = new System.Windows.Forms.DataGridView();
            this.dgvMaterial = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.rdbEpi = new System.Windows.Forms.RadioButton();
            this.dgvEpi = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrazo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitacaoCompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEpi)).BeginInit();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Panel2.Controls.Add(this.btnNext);
            this.splitContainer1.Size = new System.Drawing.Size(828, 516);
            this.splitContainer1.SplitterDistance = 468;
            this.splitContainer1.TabIndex = 0;
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
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.label1);
            this.splitContainer2.Panel2.Controls.Add(this.txtBusca);
            this.splitContainer2.Size = new System.Drawing.Size(828, 468);
            this.splitContainer2.SplitterDistance = 405;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.rdbEpi);
            this.splitContainer4.Panel1.Controls.Add(this.lblTipo);
            this.splitContainer4.Panel1.Controls.Add(this.rdbSolCompra);
            this.splitContainer4.Panel1.Controls.Add(this.rdbMaterial);
            this.splitContainer4.Panel1.Controls.Add(this.rdbProduto);
            this.splitContainer4.Panel1.Controls.Add(this.label4);
            this.splitContainer4.Panel1.Controls.Add(this.nudPrazo);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.dgvSolicitacaoCompra);
            this.splitContainer4.Panel2.Controls.Add(this.dgvProduto);
            this.splitContainer4.Panel2.Controls.Add(this.dgvMaterial);
            this.splitContainer4.Panel2.Controls.Add(this.dgvEpi);
            this.splitContainer4.Size = new System.Drawing.Size(828, 405);
            this.splitContainer4.SplitterDistance = 53;
            this.splitContainer4.TabIndex = 1;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipo.Location = new System.Drawing.Point(12, 33);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(71, 13);
            this.lblTipo.TabIndex = 5;
            this.lblTipo.Text = "matProdSol";
            // 
            // rdbSolCompra
            // 
            this.rdbSolCompra.AutoSize = true;
            this.rdbSolCompra.Checked = true;
            this.rdbSolCompra.Location = new System.Drawing.Point(603, 29);
            this.rdbSolCompra.Name = "rdbSolCompra";
            this.rdbSolCompra.Size = new System.Drawing.Size(131, 17);
            this.rdbSolCompra.TabIndex = 1;
            this.rdbSolCompra.TabStop = true;
            this.rdbSolCompra.Text = "Solicitação de Compra";
            this.rdbSolCompra.UseVisualStyleBackColor = true;
            this.rdbSolCompra.CheckedChanged += new System.EventHandler(this.rdbSolCompra_CheckedChanged);
            // 
            // rdbMaterial
            // 
            this.rdbMaterial.AutoSize = true;
            this.rdbMaterial.Location = new System.Drawing.Point(490, 29);
            this.rdbMaterial.Name = "rdbMaterial";
            this.rdbMaterial.Size = new System.Drawing.Size(62, 17);
            this.rdbMaterial.TabIndex = 3;
            this.rdbMaterial.Text = "Material";
            this.rdbMaterial.UseVisualStyleBackColor = true;
            this.rdbMaterial.CheckedChanged += new System.EventHandler(this.rdbMaterial_CheckedChanged);
            // 
            // rdbProduto
            // 
            this.rdbProduto.AutoSize = true;
            this.rdbProduto.Location = new System.Drawing.Point(422, 29);
            this.rdbProduto.Name = "rdbProduto";
            this.rdbProduto.Size = new System.Drawing.Size(62, 17);
            this.rdbProduto.TabIndex = 2;
            this.rdbProduto.Text = "Produto";
            this.rdbProduto.UseVisualStyleBackColor = true;
            this.rdbProduto.CheckedChanged += new System.EventHandler(this.rdbProduto_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(213, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Prazo para Devolução do Orçamento (Dias)";
            // 
            // nudPrazo
            // 
            this.nudPrazo.Location = new System.Drawing.Point(231, 7);
            this.nudPrazo.Name = "nudPrazo";
            this.nudPrazo.Size = new System.Drawing.Size(80, 20);
            this.nudPrazo.TabIndex = 0;
            // 
            // dgvSolicitacaoCompra
            // 
            this.dgvSolicitacaoCompra.AllowUserToAddRows = false;
            this.dgvSolicitacaoCompra.AllowUserToDeleteRows = false;
            this.dgvSolicitacaoCompra.AllowUserToOrderColumns = true;
            this.dgvSolicitacaoCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSolicitacaoCompra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSolicitacaoCompra.Location = new System.Drawing.Point(0, 0);
            this.dgvSolicitacaoCompra.Name = "dgvSolicitacaoCompra";
            this.dgvSolicitacaoCompra.ReadOnly = true;
            this.dgvSolicitacaoCompra.Size = new System.Drawing.Size(828, 348);
            this.dgvSolicitacaoCompra.TabIndex = 2;
            // 
            // dgvProduto
            // 
            this.dgvProduto.AllowUserToAddRows = false;
            this.dgvProduto.AllowUserToDeleteRows = false;
            this.dgvProduto.AllowUserToOrderColumns = true;
            this.dgvProduto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProduto.Location = new System.Drawing.Point(0, 0);
            this.dgvProduto.Name = "dgvProduto";
            this.dgvProduto.ReadOnly = true;
            this.dgvProduto.Size = new System.Drawing.Size(828, 348);
            this.dgvProduto.TabIndex = 1;
            this.dgvProduto.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProduto_CellEndEdit);
            this.dgvProduto.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvProduto_CellValidating);
            this.dgvProduto.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvProduto_DataError);
            // 
            // dgvMaterial
            // 
            this.dgvMaterial.AllowUserToAddRows = false;
            this.dgvMaterial.AllowUserToDeleteRows = false;
            this.dgvMaterial.AllowUserToOrderColumns = true;
            this.dgvMaterial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMaterial.Location = new System.Drawing.Point(0, 0);
            this.dgvMaterial.Name = "dgvMaterial";
            this.dgvMaterial.ReadOnly = true;
            this.dgvMaterial.Size = new System.Drawing.Size(828, 348);
            this.dgvMaterial.TabIndex = 0;
            this.dgvMaterial.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMaterial_CellEndEdit);
            this.dgvMaterial.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvMaterial_CellValidating);
            this.dgvMaterial.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvMaterial_DataError);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Busca";
            // 
            // txtBusca
            // 
            this.txtBusca.Location = new System.Drawing.Point(64, 21);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(349, 20);
            this.txtBusca.TabIndex = 0;
            this.txtBusca.TextChanged += new System.EventHandler(this.txtBusca_TextChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(12, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(741, 9);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Avançar";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // rdbEpi
            // 
            this.rdbEpi.AutoSize = true;
            this.rdbEpi.Location = new System.Drawing.Point(557, 29);
            this.rdbEpi.Name = "rdbEpi";
            this.rdbEpi.Size = new System.Drawing.Size(40, 17);
            this.rdbEpi.TabIndex = 7;
            this.rdbEpi.Text = "Epi";
            this.rdbEpi.UseVisualStyleBackColor = true;
            this.rdbEpi.CheckedChanged += new System.EventHandler(this.rdbEpi_CheckedChanged);
            // 
            // dgvEpi
            // 
            this.dgvEpi.AllowUserToAddRows = false;
            this.dgvEpi.AllowUserToDeleteRows = false;
            this.dgvEpi.AllowUserToOrderColumns = true;
            this.dgvEpi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEpi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEpi.Location = new System.Drawing.Point(0, 0);
            this.dgvEpi.Name = "dgvEpi";
            this.dgvEpi.ReadOnly = true;
            this.dgvEpi.Size = new System.Drawing.Size(828, 348);
            this.dgvEpi.TabIndex = 3;
            this.dgvEpi.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEpi_CellEndEdit);
            this.dgvEpi.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvEpi_CellValidating);
            this.dgvEpi.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvEpi_DataError);
            // 
            // OrcamentoCompraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(828, 516);
            this.Controls.Add(this.splitContainer1);
            this.Name = "OrcamentoCompraForm";
            this.Text = "Orçamento de Compra";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudPrazo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitacaoCompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEpi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.RadioButton rdbMaterial;
        private System.Windows.Forms.RadioButton rdbProduto;
        private System.Windows.Forms.RadioButton rdbSolCompra;
        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvMaterial;
        private System.Windows.Forms.DataGridView dgvProduto;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudPrazo;
        private System.Windows.Forms.DataGridView dgvSolicitacaoCompra;
        private System.Windows.Forms.RadioButton rdbEpi;
        private System.Windows.Forms.DataGridView dgvEpi;
    }
}