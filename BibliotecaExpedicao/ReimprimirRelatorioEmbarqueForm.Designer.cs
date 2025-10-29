namespace BibliotecaExpedicao
{
    partial class ReimprimirRelatorioEmbarqueForm
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
            this.nudNumeroEmbarque = new System.Windows.Forms.NumericUpDown();
            this.rdbEmbarqueNumero = new System.Windows.Forms.RadioButton();
            this.rdbUltimoEmbarque = new System.Windows.Forms.RadioButton();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumeroEmbarque)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.nudNumeroEmbarque);
            this.splitContainer1.Panel1.Controls.Add(this.rdbEmbarqueNumero);
            this.splitContainer1.Panel1.Controls.Add(this.rdbUltimoEmbarque);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.crystalReportViewer1);
            this.splitContainer1.Size = new System.Drawing.Size(523, 527);
            this.splitContainer1.SplitterDistance = 52;
            this.splitContainer1.TabIndex = 0;
            // 
            // nudNumeroEmbarque
            // 
            this.nudNumeroEmbarque.Enabled = false;
            this.nudNumeroEmbarque.Location = new System.Drawing.Point(256, 16);
            this.nudNumeroEmbarque.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudNumeroEmbarque.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumeroEmbarque.Name = "nudNumeroEmbarque";
            this.nudNumeroEmbarque.Size = new System.Drawing.Size(95, 20);
            this.nudNumeroEmbarque.TabIndex = 2;
            this.nudNumeroEmbarque.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumeroEmbarque.ValueChanged += new System.EventHandler(this.nudNumeroEmbarque_ValueChanged);
            // 
            // rdbEmbarqueNumero
            // 
            this.rdbEmbarqueNumero.AutoSize = true;
            this.rdbEmbarqueNumero.Location = new System.Drawing.Point(162, 16);
            this.rdbEmbarqueNumero.Name = "rdbEmbarqueNumero";
            this.rdbEmbarqueNumero.Size = new System.Drawing.Size(88, 17);
            this.rdbEmbarqueNumero.TabIndex = 1;
            this.rdbEmbarqueNumero.Text = "Embarque Nº";
            this.rdbEmbarqueNumero.UseVisualStyleBackColor = true;
            this.rdbEmbarqueNumero.CheckedChanged += new System.EventHandler(this.rdbEmbarqueNumero_CheckedChanged);
            // 
            // rdbUltimoEmbarque
            // 
            this.rdbUltimoEmbarque.AutoSize = true;
            this.rdbUltimoEmbarque.Checked = true;
            this.rdbUltimoEmbarque.Location = new System.Drawing.Point(12, 16);
            this.rdbUltimoEmbarque.Name = "rdbUltimoEmbarque";
            this.rdbUltimoEmbarque.Size = new System.Drawing.Size(105, 17);
            this.rdbUltimoEmbarque.TabIndex = 0;
            this.rdbUltimoEmbarque.TabStop = true;
            this.rdbUltimoEmbarque.Text = "Último Embarque";
            this.rdbUltimoEmbarque.UseVisualStyleBackColor = true;
            this.rdbUltimoEmbarque.CheckedChanged += new System.EventHandler(this.rdbUltimoEmbarque_CheckedChanged);
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ShowParameterPanelButton = false;
            this.crystalReportViewer1.Size = new System.Drawing.Size(523, 471);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // ReimprimirRelatorioEmbarqueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(523, 527);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ReimprimirRelatorioEmbarqueForm";
            this.Text = "Reimpressão Relatório de Embarque";
            this.Shown += new System.EventHandler(this.ReimprimirRelatorioEmbarqueForm_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudNumeroEmbarque)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.NumericUpDown nudNumeroEmbarque;
        private System.Windows.Forms.RadioButton rdbEmbarqueNumero;
        private System.Windows.Forms.RadioButton rdbUltimoEmbarque;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
    }
}