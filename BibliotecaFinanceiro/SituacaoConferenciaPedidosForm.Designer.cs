namespace BibliotecaFinanceiro
{
    partial class SituacaoConferenciaPedidosForm
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
            this.chkTotal = new System.Windows.Forms.CheckBox();
            this.chkParcial = new System.Windows.Forms.CheckBox();
            this.chkNaoConferidos = new System.Windows.Forms.CheckBox();
            this.lnkAtualizar = new System.Windows.Forms.LinkLabel();
            this.txtOC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSemana = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkNfParcial = new System.Windows.Forms.CheckBox();
            this.chkNfTotal = new System.Windows.Forms.CheckBox();
            this.chkNfNaoConferidos = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtPallet = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rdbNfEmitidaSim = new System.Windows.Forms.RadioButton();
            this.rdbNfEmitidaNao = new System.Windows.Forms.RadioButton();
            this.rdbNfEmitidaTodos = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.txtPallet);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.lnkAtualizar);
            this.splitContainer1.Panel2.Controls.Add(this.txtOC);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.txtSemana);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(747, 405);
            this.splitContainer1.SplitterDistance = 321;
            this.splitContainer1.TabIndex = 0;
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
            this.dataGridView1.Size = new System.Drawing.Size(747, 321);
            this.dataGridView1.TabIndex = 0;
            // 
            // chkTotal
            // 
            this.chkTotal.AutoSize = true;
            this.chkTotal.Checked = true;
            this.chkTotal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTotal.Location = new System.Drawing.Point(6, 46);
            this.chkTotal.Name = "chkTotal";
            this.chkTotal.Size = new System.Drawing.Size(132, 17);
            this.chkTotal.TabIndex = 10;
            this.chkTotal.Text = "Totalmente Conferidos";
            this.chkTotal.UseVisualStyleBackColor = true;
            this.chkTotal.CheckedChanged += new System.EventHandler(this.chkTotal_CheckedChanged);
            // 
            // chkParcial
            // 
            this.chkParcial.AutoSize = true;
            this.chkParcial.Location = new System.Drawing.Point(6, 29);
            this.chkParcial.Name = "chkParcial";
            this.chkParcial.Size = new System.Drawing.Size(140, 17);
            this.chkParcial.TabIndex = 9;
            this.chkParcial.Text = "Parcialmente Conferidos";
            this.chkParcial.UseVisualStyleBackColor = true;
            this.chkParcial.CheckedChanged += new System.EventHandler(this.chkParcial_CheckedChanged);
            // 
            // chkNaoConferidos
            // 
            this.chkNaoConferidos.AutoSize = true;
            this.chkNaoConferidos.Location = new System.Drawing.Point(6, 12);
            this.chkNaoConferidos.Name = "chkNaoConferidos";
            this.chkNaoConferidos.Size = new System.Drawing.Size(99, 17);
            this.chkNaoConferidos.TabIndex = 8;
            this.chkNaoConferidos.Text = "Não Conferidos";
            this.chkNaoConferidos.UseVisualStyleBackColor = true;
            this.chkNaoConferidos.CheckedChanged += new System.EventHandler(this.chkNaoConferidos_CheckedChanged);
            // 
            // lnkAtualizar
            // 
            this.lnkAtualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkAtualizar.AutoSize = true;
            this.lnkAtualizar.Location = new System.Drawing.Point(697, 5);
            this.lnkAtualizar.Name = "lnkAtualizar";
            this.lnkAtualizar.Size = new System.Drawing.Size(47, 13);
            this.lnkAtualizar.TabIndex = 7;
            this.lnkAtualizar.TabStop = true;
            this.lnkAtualizar.Text = "Atualizar";
            this.lnkAtualizar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAtualizar_LinkClicked);
            // 
            // txtOC
            // 
            this.txtOC.Location = new System.Drawing.Point(56, 30);
            this.txtOC.Name = "txtOC";
            this.txtOC.Size = new System.Drawing.Size(100, 20);
            this.txtOC.TabIndex = 6;
            this.txtOC.TextChanged += new System.EventHandler(this.txtOC_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "OC";
            // 
            // txtSemana
            // 
            this.txtSemana.Location = new System.Drawing.Point(56, 10);
            this.txtSemana.Name = "txtSemana";
            this.txtSemana.Size = new System.Drawing.Size(100, 20);
            this.txtSemana.TabIndex = 1;
            this.txtSemana.TextChanged += new System.EventHandler(this.txtSemana_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Semana";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkParcial);
            this.groupBox1.Controls.Add(this.chkTotal);
            this.groupBox1.Controls.Add(this.chkNaoConferidos);
            this.groupBox1.Location = new System.Drawing.Point(169, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 69);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Conferência";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkNfParcial);
            this.groupBox2.Controls.Add(this.chkNfTotal);
            this.groupBox2.Controls.Add(this.chkNfNaoConferidos);
            this.groupBox2.Location = new System.Drawing.Point(413, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(150, 70);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Conferência NF";
            // 
            // chkNfParcial
            // 
            this.chkNfParcial.AutoSize = true;
            this.chkNfParcial.Location = new System.Drawing.Point(6, 29);
            this.chkNfParcial.Name = "chkNfParcial";
            this.chkNfParcial.Size = new System.Drawing.Size(140, 17);
            this.chkNfParcial.TabIndex = 9;
            this.chkNfParcial.Text = "Parcialmente Conferidos";
            this.chkNfParcial.UseVisualStyleBackColor = true;
            this.chkNfParcial.CheckedChanged += new System.EventHandler(this.chkNfParcial_CheckedChanged);
            // 
            // chkNfTotal
            // 
            this.chkNfTotal.AutoSize = true;
            this.chkNfTotal.Location = new System.Drawing.Point(6, 46);
            this.chkNfTotal.Name = "chkNfTotal";
            this.chkNfTotal.Size = new System.Drawing.Size(132, 17);
            this.chkNfTotal.TabIndex = 10;
            this.chkNfTotal.Text = "Totalmente Conferidos";
            this.chkNfTotal.UseVisualStyleBackColor = true;
            this.chkNfTotal.CheckedChanged += new System.EventHandler(this.chkNfTotal_CheckedChanged);
            // 
            // chkNfNaoConferidos
            // 
            this.chkNfNaoConferidos.AutoSize = true;
            this.chkNfNaoConferidos.Checked = true;
            this.chkNfNaoConferidos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNfNaoConferidos.Location = new System.Drawing.Point(6, 12);
            this.chkNfNaoConferidos.Name = "chkNfNaoConferidos";
            this.chkNfNaoConferidos.Size = new System.Drawing.Size(99, 17);
            this.chkNfNaoConferidos.TabIndex = 8;
            this.chkNfNaoConferidos.Text = "Não Conferidos";
            this.chkNfNaoConferidos.UseVisualStyleBackColor = true;
            this.chkNfNaoConferidos.CheckedChanged += new System.EventHandler(this.chkNfNaoConferidos_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdbNfEmitidaTodos);
            this.groupBox3.Controls.Add(this.rdbNfEmitidaNao);
            this.groupBox3.Controls.Add(this.rdbNfEmitidaSim);
            this.groupBox3.Location = new System.Drawing.Point(319, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(94, 69);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "NF Emitida";
            // 
            // txtPallet
            // 
            this.txtPallet.Location = new System.Drawing.Point(56, 50);
            this.txtPallet.Name = "txtPallet";
            this.txtPallet.Size = new System.Drawing.Size(100, 20);
            this.txtPallet.TabIndex = 15;
            this.txtPallet.TextChanged += new System.EventHandler(this.txtPallet_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Pallet";
            // 
            // rdbNfEmitidaSim
            // 
            this.rdbNfEmitidaSim.AutoSize = true;
            this.rdbNfEmitidaSim.Location = new System.Drawing.Point(6, 12);
            this.rdbNfEmitidaSim.Name = "rdbNfEmitidaSim";
            this.rdbNfEmitidaSim.Size = new System.Drawing.Size(42, 17);
            this.rdbNfEmitidaSim.TabIndex = 0;
            this.rdbNfEmitidaSim.Text = "Sim";
            this.rdbNfEmitidaSim.UseVisualStyleBackColor = true;
            this.rdbNfEmitidaSim.CheckedChanged += new System.EventHandler(this.rdbNfEmitidaSim_CheckedChanged);
            // 
            // rdbNfEmitidaNao
            // 
            this.rdbNfEmitidaNao.AutoSize = true;
            this.rdbNfEmitidaNao.Checked = true;
            this.rdbNfEmitidaNao.Location = new System.Drawing.Point(6, 29);
            this.rdbNfEmitidaNao.Name = "rdbNfEmitidaNao";
            this.rdbNfEmitidaNao.Size = new System.Drawing.Size(45, 17);
            this.rdbNfEmitidaNao.TabIndex = 1;
            this.rdbNfEmitidaNao.TabStop = true;
            this.rdbNfEmitidaNao.Text = "Não";
            this.rdbNfEmitidaNao.UseVisualStyleBackColor = true;
            this.rdbNfEmitidaNao.CheckedChanged += new System.EventHandler(this.rdbNfEmitidaNao_CheckedChanged);
            // 
            // rdbNfEmitidaTodos
            // 
            this.rdbNfEmitidaTodos.AutoSize = true;
            this.rdbNfEmitidaTodos.Location = new System.Drawing.Point(6, 46);
            this.rdbNfEmitidaTodos.Name = "rdbNfEmitidaTodos";
            this.rdbNfEmitidaTodos.Size = new System.Drawing.Size(55, 17);
            this.rdbNfEmitidaTodos.TabIndex = 2;
            this.rdbNfEmitidaTodos.Text = "Todos";
            this.rdbNfEmitidaTodos.UseVisualStyleBackColor = true;
            this.rdbNfEmitidaTodos.CheckedChanged += new System.EventHandler(this.rdbNfEmitidaTodos_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(605, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Nota Fiscal Emitida";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SituacaoConferenciaPedidosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(747, 405);
            this.Controls.Add(this.splitContainer1);
            this.Name = "SituacaoConferenciaPedidosForm";
            this.Text = "Situação Atual dos Pedidos";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtSemana;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.LinkLabel lnkAtualizar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox chkTotal;
        private System.Windows.Forms.CheckBox chkParcial;
        private System.Windows.Forms.CheckBox chkNaoConferidos;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkNfParcial;
        private System.Windows.Forms.CheckBox chkNfTotal;
        private System.Windows.Forms.CheckBox chkNfNaoConferidos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPallet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdbNfEmitidaTodos;
        private System.Windows.Forms.RadioButton rdbNfEmitidaNao;
        private System.Windows.Forms.RadioButton rdbNfEmitidaSim;
        private System.Windows.Forms.Button button1;
    }
}