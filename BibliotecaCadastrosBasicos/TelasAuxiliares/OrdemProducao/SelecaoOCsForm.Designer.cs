namespace BibliotecaCadastrosBasicos.TelasAuxiliares.OrdemProducao
{
    partial class SelecaoOCsForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbSomenteAgrupadores = new System.Windows.Forms.RadioButton();
            this.rdbAgrupadoresTodos = new System.Windows.Forms.RadioButton();
            this.rdbSomenteProdutos = new System.Windows.Forms.RadioButton();
            this.lnkDesmarcarTodos = new System.Windows.Forms.LinkLabel();
            this.lnkMarcarTodos = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbNaoKit = new System.Windows.Forms.RadioButton();
            this.rdbTodos = new System.Windows.Forms.RadioButton();
            this.rdbKit = new System.Windows.Forms.RadioButton();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnContinuar = new System.Windows.Forms.Button();
            this.timerBusca = new System.Windows.Forms.Timer(this.components);
            this.grbDataEntrega = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDataEntregaDe = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDataEntregaAte = new System.Windows.Forms.DateTimePicker();
            this.chkDataEntrega = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grbDataEntrega.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.chkDataEntrega);
            this.splitContainer1.Panel2.Controls.Add(this.grbDataEntrega);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.lnkDesmarcarTodos);
            this.splitContainer1.Panel2.Controls.Add(this.lnkMarcarTodos);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.txtBusca);
            this.splitContainer1.Panel2.Controls.Add(this.lblQuantidade);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.btnCancelar);
            this.splitContainer1.Panel2.Controls.Add(this.btnContinuar);
            this.splitContainer1.Size = new System.Drawing.Size(1023, 418);
            this.splitContainer1.SplitterDistance = 339;
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
            this.dataGridView1.Size = new System.Drawing.Size(1023, 339);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbSomenteAgrupadores);
            this.groupBox2.Controls.Add(this.rdbAgrupadoresTodos);
            this.groupBox2.Controls.Add(this.rdbSomenteProdutos);
            this.groupBox2.Location = new System.Drawing.Point(284, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(202, 69);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kanban de Itens Manufaturados";
            // 
            // rdbSomenteAgrupadores
            // 
            this.rdbSomenteAgrupadores.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbSomenteAgrupadores.AutoSize = true;
            this.rdbSomenteAgrupadores.Location = new System.Drawing.Point(6, 13);
            this.rdbSomenteAgrupadores.Name = "rdbSomenteAgrupadores";
            this.rdbSomenteAgrupadores.Size = new System.Drawing.Size(112, 17);
            this.rdbSomenteAgrupadores.TabIndex = 2;
            this.rdbSomenteAgrupadores.Text = "Somente Kanbans";
            this.rdbSomenteAgrupadores.UseVisualStyleBackColor = true;
            this.rdbSomenteAgrupadores.CheckedChanged += new System.EventHandler(this.rdbSomenteAgrupadores_CheckedChanged);
            // 
            // rdbAgrupadoresTodos
            // 
            this.rdbAgrupadoresTodos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbAgrupadoresTodos.AutoSize = true;
            this.rdbAgrupadoresTodos.Checked = true;
            this.rdbAgrupadoresTodos.Location = new System.Drawing.Point(6, 47);
            this.rdbAgrupadoresTodos.Name = "rdbAgrupadoresTodos";
            this.rdbAgrupadoresTodos.Size = new System.Drawing.Size(55, 17);
            this.rdbAgrupadoresTodos.TabIndex = 4;
            this.rdbAgrupadoresTodos.TabStop = true;
            this.rdbAgrupadoresTodos.Text = "Todos";
            this.rdbAgrupadoresTodos.UseVisualStyleBackColor = true;
            this.rdbAgrupadoresTodos.CheckedChanged += new System.EventHandler(this.rdbAgrupadoresTodos_CheckedChanged);
            // 
            // rdbSomenteProdutos
            // 
            this.rdbSomenteProdutos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbSomenteProdutos.AutoSize = true;
            this.rdbSomenteProdutos.Location = new System.Drawing.Point(6, 30);
            this.rdbSomenteProdutos.Name = "rdbSomenteProdutos";
            this.rdbSomenteProdutos.Size = new System.Drawing.Size(135, 17);
            this.rdbSomenteProdutos.TabIndex = 3;
            this.rdbSomenteProdutos.Text = "Somente Não Kanbans";
            this.rdbSomenteProdutos.UseVisualStyleBackColor = true;
            this.rdbSomenteProdutos.CheckedChanged += new System.EventHandler(this.rdbSomenteProdutos_CheckedChanged);
            // 
            // lnkDesmarcarTodos
            // 
            this.lnkDesmarcarTodos.AutoSize = true;
            this.lnkDesmarcarTodos.Location = new System.Drawing.Point(82, 3);
            this.lnkDesmarcarTodos.Name = "lnkDesmarcarTodos";
            this.lnkDesmarcarTodos.Size = new System.Drawing.Size(91, 13);
            this.lnkDesmarcarTodos.TabIndex = 11;
            this.lnkDesmarcarTodos.TabStop = true;
            this.lnkDesmarcarTodos.Text = "Desmarcar Todos";
            this.lnkDesmarcarTodos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDesmarcarTodos_LinkClicked);
            // 
            // lnkMarcarTodos
            // 
            this.lnkMarcarTodos.AutoSize = true;
            this.lnkMarcarTodos.Location = new System.Drawing.Point(3, 3);
            this.lnkMarcarTodos.Name = "lnkMarcarTodos";
            this.lnkMarcarTodos.Size = new System.Drawing.Size(73, 13);
            this.lnkMarcarTodos.TabIndex = 10;
            this.lnkMarcarTodos.TabStop = true;
            this.lnkMarcarTodos.Text = "Marcar Todos";
            this.lnkMarcarTodos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkMarcarTodos_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(706, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Busca";
            // 
            // txtBusca
            // 
            this.txtBusca.Location = new System.Drawing.Point(709, 28);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(207, 20);
            this.txtBusca.TabIndex = 8;
            this.txtBusca.TextChanged += new System.EventHandler(this.txtBusca_TextChanged);
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Location = new System.Drawing.Point(881, 3);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(0, 13);
            this.lblQuantidade.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbNaoKit);
            this.groupBox1.Controls.Add(this.rdbTodos);
            this.groupBox1.Controls.Add(this.rdbKit);
            this.groupBox1.Location = new System.Drawing.Point(189, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(89, 69);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kit/Não Kit";
            // 
            // rdbNaoKit
            // 
            this.rdbNaoKit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbNaoKit.AutoSize = true;
            this.rdbNaoKit.Location = new System.Drawing.Point(6, 13);
            this.rdbNaoKit.Name = "rdbNaoKit";
            this.rdbNaoKit.Size = new System.Drawing.Size(60, 17);
            this.rdbNaoKit.TabIndex = 2;
            this.rdbNaoKit.Text = "Não Kit";
            this.rdbNaoKit.UseVisualStyleBackColor = true;
            this.rdbNaoKit.CheckedChanged += new System.EventHandler(this.rdbNaoKit_CheckedChanged);
            // 
            // rdbTodos
            // 
            this.rdbTodos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbTodos.AutoSize = true;
            this.rdbTodos.Checked = true;
            this.rdbTodos.Location = new System.Drawing.Point(6, 47);
            this.rdbTodos.Name = "rdbTodos";
            this.rdbTodos.Size = new System.Drawing.Size(55, 17);
            this.rdbTodos.TabIndex = 4;
            this.rdbTodos.TabStop = true;
            this.rdbTodos.Text = "Todos";
            this.rdbTodos.UseVisualStyleBackColor = true;
            this.rdbTodos.CheckedChanged += new System.EventHandler(this.rdbTodos_CheckedChanged);
            // 
            // rdbKit
            // 
            this.rdbKit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbKit.AutoSize = true;
            this.rdbKit.Location = new System.Drawing.Point(6, 30);
            this.rdbKit.Name = "rdbKit";
            this.rdbKit.Size = new System.Drawing.Size(37, 17);
            this.rdbKit.TabIndex = 3;
            this.rdbKit.Text = "Kit";
            this.rdbKit.UseVisualStyleBackColor = true;
            this.rdbKit.CheckedChanged += new System.EventHandler(this.rdbKit_CheckedChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(12, 40);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnContinuar
            // 
            this.btnContinuar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnContinuar.Location = new System.Drawing.Point(936, 26);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(75, 23);
            this.btnContinuar.TabIndex = 0;
            this.btnContinuar.Text = "Gerar";
            this.btnContinuar.UseVisualStyleBackColor = true;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // timerBusca
            // 
            this.timerBusca.Tick += new System.EventHandler(this.timerBusca_Tick);
            // 
            // grbDataEntrega
            // 
            this.grbDataEntrega.Controls.Add(this.dtpDataEntregaAte);
            this.grbDataEntrega.Controls.Add(this.label3);
            this.grbDataEntrega.Controls.Add(this.dtpDataEntregaDe);
            this.grbDataEntrega.Controls.Add(this.label2);
            this.grbDataEntrega.Enabled = false;
            this.grbDataEntrega.Location = new System.Drawing.Point(492, 2);
            this.grbDataEntrega.Name = "grbDataEntrega";
            this.grbDataEntrega.Size = new System.Drawing.Size(158, 69);
            this.grbDataEntrega.TabIndex = 12;
            this.grbDataEntrega.TabStop = false;
            this.grbDataEntrega.Text = "Data de Entrega";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "De";
            // 
            // dtpDataEntregaDe
            // 
            this.dtpDataEntregaDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataEntregaDe.Location = new System.Drawing.Point(33, 15);
            this.dtpDataEntregaDe.Name = "dtpDataEntregaDe";
            this.dtpDataEntregaDe.Size = new System.Drawing.Size(111, 20);
            this.dtpDataEntregaDe.TabIndex = 1;
            this.dtpDataEntregaDe.ValueChanged += new System.EventHandler(this.dtpDataEntregaDe_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Até";
            // 
            // dtpDataEntregaAte
            // 
            this.dtpDataEntregaAte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataEntregaAte.Location = new System.Drawing.Point(33, 41);
            this.dtpDataEntregaAte.Name = "dtpDataEntregaAte";
            this.dtpDataEntregaAte.Size = new System.Drawing.Size(111, 20);
            this.dtpDataEntregaAte.TabIndex = 1;
            this.dtpDataEntregaAte.ValueChanged += new System.EventHandler(this.dtpDataEntregaAte_ValueChanged);
            // 
            // chkDataEntrega
            // 
            this.chkDataEntrega.AutoSize = true;
            this.chkDataEntrega.Location = new System.Drawing.Point(656, 31);
            this.chkDataEntrega.Name = "chkDataEntrega";
            this.chkDataEntrega.Size = new System.Drawing.Size(15, 14);
            this.chkDataEntrega.TabIndex = 13;
            this.chkDataEntrega.UseVisualStyleBackColor = true;
            this.chkDataEntrega.CheckedChanged += new System.EventHandler(this.chkDataEntrega_CheckedChanged);
            // 
            // SelecaoOCsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1023, 418);
            this.Controls.Add(this.splitContainer1);
            this.Name = "SelecaoOCsForm";
            this.Text = "Pedidos para Geração de OP";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbDataEntrega.ResumeLayout(false);
            this.grbDataEntrega.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.RadioButton rdbKit;
        private System.Windows.Forms.RadioButton rdbNaoKit;
        private System.Windows.Forms.RadioButton rdbTodos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.Timer timerBusca;
        private System.Windows.Forms.LinkLabel lnkDesmarcarTodos;
        private System.Windows.Forms.LinkLabel lnkMarcarTodos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbSomenteAgrupadores;
        private System.Windows.Forms.RadioButton rdbAgrupadoresTodos;
        private System.Windows.Forms.RadioButton rdbSomenteProdutos;
        private System.Windows.Forms.GroupBox grbDataEntrega;
        private System.Windows.Forms.DateTimePicker dtpDataEntregaAte;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDataEntregaDe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkDataEntrega;

    }
}