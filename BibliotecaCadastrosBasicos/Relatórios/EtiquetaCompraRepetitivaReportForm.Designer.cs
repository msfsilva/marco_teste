namespace BibliotecaCadastrosBasicos.Relatórios
{
    partial class EtiquetaCompraRepetitivaReportForm
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
            this.rdbVerde = new System.Windows.Forms.RadioButton();
            this.rdbAmarelo = new System.Windows.Forms.RadioButton();
            this.rdbVermelho = new System.Windows.Forms.RadioButton();
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
            this.crystalReportViewer1.ShowParameterPanelButton = false;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(586, 471);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            this.crystalReportViewer1.ShowLogo = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.rdbVermelho);
            this.splitContainer1.Panel1.Controls.Add(this.rdbAmarelo);
            this.splitContainer1.Panel1.Controls.Add(this.rdbVerde);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.crystalReportViewer1);
            this.splitContainer1.Size = new System.Drawing.Size(586, 526);
            this.splitContainer1.SplitterDistance = 51;
            this.splitContainer1.TabIndex = 1;
            // 
            // rdbVerde
            // 
            this.rdbVerde.AutoSize = true;
            this.rdbVerde.Location = new System.Drawing.Point(12, 21);
            this.rdbVerde.Name = "rdbVerde";
            this.rdbVerde.Size = new System.Drawing.Size(53, 17);
            this.rdbVerde.TabIndex = 0;
            this.rdbVerde.Text = "Verde";
            this.rdbVerde.UseVisualStyleBackColor = true;
            this.rdbVerde.CheckedChanged += new System.EventHandler(this.rdbVerde_CheckedChanged);
            // 
            // rdbAmarelo
            // 
            this.rdbAmarelo.AutoSize = true;
            this.rdbAmarelo.Location = new System.Drawing.Point(71, 21);
            this.rdbAmarelo.Name = "rdbAmarelo";
            this.rdbAmarelo.Size = new System.Drawing.Size(63, 17);
            this.rdbAmarelo.TabIndex = 1;
            this.rdbAmarelo.Text = "Amarelo";
            this.rdbAmarelo.UseVisualStyleBackColor = true;
            this.rdbAmarelo.CheckedChanged += new System.EventHandler(this.rdbAmarelo_CheckedChanged);
            // 
            // rdbVermelho
            // 
            this.rdbVermelho.AutoSize = true;
            this.rdbVermelho.Checked = true;
            this.rdbVermelho.Location = new System.Drawing.Point(140, 21);
            this.rdbVermelho.Name = "rdbVermelho";
            this.rdbVermelho.Size = new System.Drawing.Size(69, 17);
            this.rdbVermelho.TabIndex = 2;
            this.rdbVermelho.TabStop = true;
            this.rdbVermelho.Text = "Vermelho";
            this.rdbVermelho.UseVisualStyleBackColor = true;
            this.rdbVermelho.CheckedChanged += new System.EventHandler(this.rdbVermelho_CheckedChanged);
            // 
            // EtiquetaCompraRepetitivaReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(586, 526);
            this.Controls.Add(this.splitContainer1);
            this.Name = "EtiquetaCompraRepetitivaReportForm";
            this.Text = "Etiquetas de Kanban";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RadioButton rdbVermelho;
        private System.Windows.Forms.RadioButton rdbAmarelo;
        private System.Windows.Forms.RadioButton rdbVerde;
    }
}