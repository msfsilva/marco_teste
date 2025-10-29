namespace BibliotecaCadastrosBasicos.NovaEstruturaProduto
{
    partial class EstruturaProdutoReportFormNew
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cmbVersaoEstrutura = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rdbFilhosPrimeiro = new System.Windows.Forms.RadioButton();
            this.rdbPrimeiroComponentesPai = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
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
            this.crystalReportViewer1.Size = new System.Drawing.Size(564, 444);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
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
            this.splitContainer1.Panel1.Controls.Add(this.rdbPrimeiroComponentesPai);
            this.splitContainer1.Panel1.Controls.Add(this.rdbFilhosPrimeiro);
            this.splitContainer1.Panel1.Controls.Add(this.cmbVersaoEstrutura);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.crystalReportViewer1);
            this.splitContainer1.Size = new System.Drawing.Size(564, 524);
            this.splitContainer1.SplitterDistance = 76;
            this.splitContainer1.TabIndex = 1;
            // 
            // cmbVersaoEstrutura
            // 
            this.cmbVersaoEstrutura.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbVersaoEstrutura.FormattingEnabled = true;
            this.cmbVersaoEstrutura.Location = new System.Drawing.Point(118, 17);
            this.cmbVersaoEstrutura.Name = "cmbVersaoEstrutura";
            this.cmbVersaoEstrutura.Size = new System.Drawing.Size(434, 21);
            this.cmbVersaoEstrutura.TabIndex = 1;
            this.cmbVersaoEstrutura.SelectedIndexChanged += new System.EventHandler(this.cmbVersaoEstrutura_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Versão da Estrutura";
            // 
            // rdbFilhosPrimeiro
            // 
            this.rdbFilhosPrimeiro.AutoSize = true;
            this.rdbFilhosPrimeiro.Checked = true;
            this.rdbFilhosPrimeiro.Location = new System.Drawing.Point(118, 44);
            this.rdbFilhosPrimeiro.Name = "rdbFilhosPrimeiro";
            this.rdbFilhosPrimeiro.Size = new System.Drawing.Size(134, 17);
            this.rdbFilhosPrimeiro.TabIndex = 2;
            this.rdbFilhosPrimeiro.TabStop = true;
            this.rdbFilhosPrimeiro.Text = "Exibir Primeiro os Filhos";
            this.rdbFilhosPrimeiro.UseVisualStyleBackColor = true;
            this.rdbFilhosPrimeiro.CheckedChanged += new System.EventHandler(this.rdbFilhosPrimeiro_CheckedChanged);
            // 
            // rdbPrimeiroComponentesPai
            // 
            this.rdbPrimeiroComponentesPai.AutoSize = true;
            this.rdbPrimeiroComponentesPai.Location = new System.Drawing.Point(258, 44);
            this.rdbPrimeiroComponentesPai.Name = "rdbPrimeiroComponentesPai";
            this.rdbPrimeiroComponentesPai.Size = new System.Drawing.Size(232, 17);
            this.rdbPrimeiroComponentesPai.TabIndex = 3;
            this.rdbPrimeiroComponentesPai.Text = "Exibir Primeiro os Materiais/Recursos do Pai";
            this.rdbPrimeiroComponentesPai.UseVisualStyleBackColor = true;
            this.rdbPrimeiroComponentesPai.CheckedChanged += new System.EventHandler(this.rdbPrimeiroComponentesPai_CheckedChanged);
            // 
            // EstruturaProdutoReportFormNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(564, 524);
            this.Controls.Add(this.splitContainer1);
            this.Name = "EstruturaProdutoReportFormNew";
            this.Text = "Estrutura de Produto";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbVersaoEstrutura;
        private System.Windows.Forms.RadioButton rdbPrimeiroComponentesPai;
        private System.Windows.Forms.RadioButton rdbFilhosPrimeiro;
    }
}