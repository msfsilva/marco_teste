namespace BibliotecaCadastrosBasicos.Relatórios
{
    partial class RelatorioCompletoEstoqueReportForm
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
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkMateriais = new System.Windows.Forms.CheckBox();
            this.chkProdutos = new System.Windows.Forms.CheckBox();
            this.chkEPIs = new System.Windows.Forms.CheckBox();
            this.btnGerar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(2, 54);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ShowLogo = false;
            this.crystalReportViewer1.Size = new System.Drawing.Size(597, 496);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnGerar);
            this.panel1.Controls.Add(this.chkEPIs);
            this.panel1.Controls.Add(this.chkProdutos);
            this.panel1.Controls.Add(this.chkMateriais);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(597, 46);
            this.panel1.TabIndex = 1;
            // 
            // chkMateriais
            // 
            this.chkMateriais.AutoSize = true;
            this.chkMateriais.Checked = true;
            this.chkMateriais.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMateriais.Location = new System.Drawing.Point(11, 14);
            this.chkMateriais.Name = "chkMateriais";
            this.chkMateriais.Size = new System.Drawing.Size(99, 17);
            this.chkMateriais.TabIndex = 0;
            this.chkMateriais.Text = "Incluir Materiais";
            this.chkMateriais.UseVisualStyleBackColor = true;
            // 
            // chkProdutos
            // 
            this.chkProdutos.AutoSize = true;
            this.chkProdutos.Location = new System.Drawing.Point(116, 14);
            this.chkProdutos.Name = "chkProdutos";
            this.chkProdutos.Size = new System.Drawing.Size(99, 17);
            this.chkProdutos.TabIndex = 1;
            this.chkProdutos.Text = "Incluir Produtos";
            this.chkProdutos.UseVisualStyleBackColor = true;
            // 
            // chkEPIs
            // 
            this.chkEPIs.AutoSize = true;
            this.chkEPIs.Location = new System.Drawing.Point(221, 14);
            this.chkEPIs.Name = "chkEPIs";
            this.chkEPIs.Size = new System.Drawing.Size(79, 17);
            this.chkEPIs.TabIndex = 2;
            this.chkEPIs.Text = "Incluir EPIs";
            this.chkEPIs.UseVisualStyleBackColor = true;
            // 
            // btnGerar
            // 
            this.btnGerar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGerar.Location = new System.Drawing.Point(512, 10);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(75, 23);
            this.btnGerar.TabIndex = 3;
            this.btnGerar.Text = "Gerar";
            this.btnGerar.UseVisualStyleBackColor = true;
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            // 
            // RelatorioCompletoEstoqueReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 552);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "RelatorioCompletoEstoqueReportForm";
            this.Text = "Relatório Completo de Estoque";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkEPIs;
        private System.Windows.Forms.CheckBox chkProdutos;
        private System.Windows.Forms.CheckBox chkMateriais;
        private System.Windows.Forms.Button btnGerar;
    }
}