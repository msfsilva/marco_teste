namespace BibliotecaEntidades.Operacoes.CalculoPreco
{
    partial class DivergenciasForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtOc = new System.Windows.Forms.TextBox();
            this.cbxPend = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPos = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAjusteRealiz = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.btnAjusteRealiz);
            this.splitContainer1.Size = new System.Drawing.Size(880, 416);
            this.splitContainer1.SplitterDistance = 326;
            this.splitContainer1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(880, 326);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtOc);
            this.groupBox1.Controls.Add(this.cbxPend);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtPos);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(25, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 75);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Busca";
            // 
            // txtOc
            // 
            this.txtOc.Location = new System.Drawing.Point(41, 19);
            this.txtOc.Name = "txtOc";
            this.txtOc.Size = new System.Drawing.Size(141, 20);
            this.txtOc.TabIndex = 4;
            this.txtOc.TextChanged += new System.EventHandler(this.txtOc_TextChanged);
            // 
            // cbxPend
            // 
            this.cbxPend.AutoSize = true;
            this.cbxPend.Checked = true;
            this.cbxPend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxPend.Location = new System.Drawing.Point(194, 47);
            this.cbxPend.Name = "cbxPend";
            this.cbxPend.Size = new System.Drawing.Size(77, 17);
            this.cbxPend.TabIndex = 5;
            this.cbxPend.Text = "Pendentes";
            this.cbxPend.UseVisualStyleBackColor = true;
            this.cbxPend.CheckedChanged += new System.EventHandler(this.cbxPend_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "OC";
            // 
            // txtPos
            // 
            this.txtPos.Location = new System.Drawing.Point(41, 45);
            this.txtPos.Name = "txtPos";
            this.txtPos.Size = new System.Drawing.Size(68, 20);
            this.txtPos.TabIndex = 4;
            this.txtPos.TextChanged += new System.EventHandler(this.txtPos_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pos";
            // 
            // btnAjusteRealiz
            // 
            this.btnAjusteRealiz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAjusteRealiz.Location = new System.Drawing.Point(766, 25);
            this.btnAjusteRealiz.Name = "btnAjusteRealiz";
            this.btnAjusteRealiz.Size = new System.Drawing.Size(102, 40);
            this.btnAjusteRealiz.TabIndex = 2;
            this.btnAjusteRealiz.Text = "Ajuste Realizado";
            this.btnAjusteRealiz.UseVisualStyleBackColor = true;
            this.btnAjusteRealiz.Click += new System.EventHandler(this.btnAjusteRealiz_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // DivergenciasForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(880, 416);
            this.Controls.Add(this.splitContainer1);
            this.Name = "DivergenciasForm";
            this.Text = "Divergencias";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtPos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAjusteRealiz;
        private System.Windows.Forms.CheckBox cbxPend;
        private System.Windows.Forms.TextBox txtOc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}