namespace BibliotecaCompras
{
    partial class SolicitacaoCompraFeedbackForm
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
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this.dgvFeedbacks = new System.Windows.Forms.DataGridView();
            this.btnFeedbackOk = new System.Windows.Forms.Button();
            this.txtFeedback = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.btnFeedbackAdicionar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).BeginInit();
            this.splitContainer6.Panel1.SuspendLayout();
            this.splitContainer6.Panel2.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeedbacks)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer6);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnFechar);
            this.splitContainer1.Size = new System.Drawing.Size(902, 518);
            this.splitContainer1.SplitterDistance = 446;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer6
            // 
            this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer6.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer6.Location = new System.Drawing.Point(0, 0);
            this.splitContainer6.Name = "splitContainer6";
            // 
            // splitContainer6.Panel1
            // 
            this.splitContainer6.Panel1.Controls.Add(this.dgvFeedbacks);
            // 
            // splitContainer6.Panel2
            // 
            this.splitContainer6.Panel2.Controls.Add(this.btnFeedbackOk);
            this.splitContainer6.Panel2.Controls.Add(this.txtFeedback);
            this.splitContainer6.Panel2.Controls.Add(this.label37);
            this.splitContainer6.Panel2.Controls.Add(this.btnFeedbackAdicionar);
            this.splitContainer6.Size = new System.Drawing.Size(902, 446);
            this.splitContainer6.SplitterDistance = 627;
            this.splitContainer6.TabIndex = 2;
            // 
            // dgvFeedbacks
            // 
            this.dgvFeedbacks.AllowUserToAddRows = false;
            this.dgvFeedbacks.AllowUserToDeleteRows = false;
            this.dgvFeedbacks.AllowUserToOrderColumns = true;
            this.dgvFeedbacks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFeedbacks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFeedbacks.Location = new System.Drawing.Point(0, 0);
            this.dgvFeedbacks.MultiSelect = false;
            this.dgvFeedbacks.Name = "dgvFeedbacks";
            this.dgvFeedbacks.ReadOnly = true;
            this.dgvFeedbacks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFeedbacks.Size = new System.Drawing.Size(627, 446);
            this.dgvFeedbacks.TabIndex = 0;
            this.dgvFeedbacks.SelectionChanged += new System.EventHandler(this.dgvFeedbacks_SelectionChanged);
            // 
            // btnFeedbackOk
            // 
            this.btnFeedbackOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFeedbackOk.Enabled = false;
            this.btnFeedbackOk.Location = new System.Drawing.Point(193, 401);
            this.btnFeedbackOk.Name = "btnFeedbackOk";
            this.btnFeedbackOk.Size = new System.Drawing.Size(75, 23);
            this.btnFeedbackOk.TabIndex = 3;
            this.btnFeedbackOk.Text = "OK";
            this.btnFeedbackOk.UseVisualStyleBackColor = true;
            this.btnFeedbackOk.Click += new System.EventHandler(this.btnFeedbackOk_Click);
            // 
            // txtFeedback
            // 
            this.txtFeedback.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFeedback.Enabled = false;
            this.txtFeedback.Location = new System.Drawing.Point(18, 75);
            this.txtFeedback.Multiline = true;
            this.txtFeedback.Name = "txtFeedback";
            this.txtFeedback.Size = new System.Drawing.Size(235, 310);
            this.txtFeedback.TabIndex = 2;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(3, 59);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(85, 13);
            this.label37.TabIndex = 1;
            this.label37.Text = "Texto Feedback";
            // 
            // btnFeedbackAdicionar
            // 
            this.btnFeedbackAdicionar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFeedbackAdicionar.Location = new System.Drawing.Point(18, 22);
            this.btnFeedbackAdicionar.Name = "btnFeedbackAdicionar";
            this.btnFeedbackAdicionar.Size = new System.Drawing.Size(235, 23);
            this.btnFeedbackAdicionar.TabIndex = 0;
            this.btnFeedbackAdicionar.Text = "Adicionar Feedback";
            this.btnFeedbackAdicionar.UseVisualStyleBackColor = true;
            this.btnFeedbackAdicionar.Click += new System.EventHandler(this.btnFeedbackAdicionar_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(12, 23);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 0;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // SolicitacaoCompraFeedbackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(902, 518);
            this.Controls.Add(this.splitContainer1);
            this.Name = "SolicitacaoCompraFeedbackForm";
            this.Text = "Feedbacks da Solicitação de compra";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer6.Panel1.ResumeLayout(false);
            this.splitContainer6.Panel2.ResumeLayout(false);
            this.splitContainer6.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).EndInit();
            this.splitContainer6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeedbacks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer6;
        private System.Windows.Forms.DataGridView dgvFeedbacks;
        private System.Windows.Forms.Button btnFeedbackOk;
        private System.Windows.Forms.TextBox txtFeedback;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Button btnFeedbackAdicionar;
        private System.Windows.Forms.Button btnFechar;
    }
}