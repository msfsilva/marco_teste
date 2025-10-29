namespace BibliotecaCadastrosBasicos
{
    partial class EpiVencidoReportForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cbxVencAte = new System.Windows.Forms.CheckBox();
            this.dtpVencAte = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGerarReport = new System.Windows.Forms.Button();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
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
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnGerarReport);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.dtpVencAte);
            this.splitContainer1.Panel1.Controls.Add(this.cbxVencAte);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.crystalReportViewer1);
            this.splitContainer1.Size = new System.Drawing.Size(883, 457);
            this.splitContainer1.SplitterDistance = 56;
            this.splitContainer1.TabIndex = 0;
            // 
            // cbxVencAte
            // 
            this.cbxVencAte.AutoSize = true;
            this.cbxVencAte.Location = new System.Drawing.Point(208, 20);
            this.cbxVencAte.Name = "cbxVencAte";
            this.cbxVencAte.Size = new System.Drawing.Size(15, 14);
            this.cbxVencAte.TabIndex = 0;
            this.cbxVencAte.UseVisualStyleBackColor = true;
            this.cbxVencAte.CheckedChanged += new System.EventHandler(this.cbxVencAte_CheckedChanged);
            // 
            // dtpVencAte
            // 
            this.dtpVencAte.Enabled = false;
            this.dtpVencAte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpVencAte.Location = new System.Drawing.Point(102, 16);
            this.dtpVencAte.Name = "dtpVencAte";
            this.dtpVencAte.Size = new System.Drawing.Size(100, 20);
            this.dtpVencAte.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Vencidos Até";
            // 
            // btnGerarReport
            // 
            this.btnGerarReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGerarReport.Location = new System.Drawing.Point(793, 16);
            this.btnGerarReport.Name = "btnGerarReport";
            this.btnGerarReport.Size = new System.Drawing.Size(75, 24);
            this.btnGerarReport.TabIndex = 0;
            this.btnGerarReport.Text = "Gerar";
            this.btnGerarReport.UseVisualStyleBackColor = true;
            this.btnGerarReport.Click += new System.EventHandler(this.btnGerarReport_Click);
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(883, 397);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // EpiVencidoReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(883, 457);
            this.Controls.Add(this.splitContainer1);
            this.Name = "EpiVencidoReportForm";
            this.Text = "Relatório de EPIs Vencidos";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpVencAte;
        private System.Windows.Forms.CheckBox cbxVencAte;
        private System.Windows.Forms.Button btnGerarReport;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
    }
}