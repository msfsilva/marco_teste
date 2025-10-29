namespace BibliotecaCompras
{
    partial class OCListForm
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
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.chkIdOC = new System.Windows.Forms.CheckBox();
            this.nudIdOC = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAguardandoAprovacao = new System.Windows.Forms.CheckBox();
            this.chkCanceladas = new System.Windows.Forms.CheckBox();
            this.chkRecebidas = new System.Windows.Forms.CheckBox();
            this.chkRecebidasParcial = new System.Windows.Forms.CheckBox();
            this.chkCompradas = new System.Windows.Forms.CheckBox();
            this.chkNovas = new System.Windows.Forms.CheckBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnVisualizar = new System.Windows.Forms.Button();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.timerBusca = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIdOC)).BeginInit();
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
            this.splitContainer1.Panel2.Controls.Add(this.btnEditar);
            this.splitContainer1.Panel2.Controls.Add(this.btnEnviar);
            this.splitContainer1.Panel2.Controls.Add(this.chkIdOC);
            this.splitContainer1.Panel2.Controls.Add(this.nudIdOC);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.btnCancelar);
            this.splitContainer1.Panel2.Controls.Add(this.btnVisualizar);
            this.splitContainer1.Panel2.Controls.Add(this.txtBusca);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.btnExcluir);
            this.splitContainer1.Panel2.Controls.Add(this.btnNovo);
            this.splitContainer1.Size = new System.Drawing.Size(847, 382);
            this.splitContainer1.SplitterDistance = 272;
            this.splitContainer1.TabIndex = 2;
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
            this.dataGridView1.Size = new System.Drawing.Size(847, 272);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.Location = new System.Drawing.Point(663, 30);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(172, 23);
            this.btnEditar.TabIndex = 5;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnviar.Location = new System.Drawing.Point(663, 54);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(80, 23);
            this.btnEnviar.TabIndex = 7;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // chkIdOC
            // 
            this.chkIdOC.AutoSize = true;
            this.chkIdOC.Location = new System.Drawing.Point(184, 57);
            this.chkIdOC.Name = "chkIdOC";
            this.chkIdOC.Size = new System.Drawing.Size(15, 14);
            this.chkIdOC.TabIndex = 1;
            this.chkIdOC.UseVisualStyleBackColor = true;
            this.chkIdOC.CheckedChanged += new System.EventHandler(this.chkIdOC_CheckedChanged);
            // 
            // nudIdOC
            // 
            this.nudIdOC.Enabled = false;
            this.nudIdOC.Location = new System.Drawing.Point(58, 54);
            this.nudIdOC.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.nudIdOC.Name = "nudIdOC";
            this.nudIdOC.Size = new System.Drawing.Size(120, 20);
            this.nudIdOC.TabIndex = 2;
            this.nudIdOC.ValueChanged += new System.EventHandler(this.nudIdOC_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Número";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAguardandoAprovacao);
            this.groupBox1.Controls.Add(this.chkCanceladas);
            this.groupBox1.Controls.Add(this.chkRecebidas);
            this.groupBox1.Controls.Add(this.chkRecebidasParcial);
            this.groupBox1.Controls.Add(this.chkCompradas);
            this.groupBox1.Controls.Add(this.chkNovas);
            this.groupBox1.Location = new System.Drawing.Point(256, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 81);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // chkAguardandoAprovacao
            // 
            this.chkAguardandoAprovacao.AutoSize = true;
            this.chkAguardandoAprovacao.Location = new System.Drawing.Point(18, 15);
            this.chkAguardandoAprovacao.Name = "chkAguardandoAprovacao";
            this.chkAguardandoAprovacao.Size = new System.Drawing.Size(139, 17);
            this.chkAguardandoAprovacao.TabIndex = 0;
            this.chkAguardandoAprovacao.Text = "Aguardando Aprovação";
            this.chkAguardandoAprovacao.UseVisualStyleBackColor = true;
            this.chkAguardandoAprovacao.CheckedChanged += new System.EventHandler(this.chkAguardandoAprovacao_CheckedChanged);
            // 
            // chkCanceladas
            // 
            this.chkCanceladas.AutoSize = true;
            this.chkCanceladas.Location = new System.Drawing.Point(174, 54);
            this.chkCanceladas.Name = "chkCanceladas";
            this.chkCanceladas.Size = new System.Drawing.Size(82, 17);
            this.chkCanceladas.TabIndex = 5;
            this.chkCanceladas.Text = "Canceladas";
            this.chkCanceladas.UseVisualStyleBackColor = true;
            this.chkCanceladas.CheckedChanged += new System.EventHandler(this.chkCanceladas_CheckedChanged);
            // 
            // chkRecebidas
            // 
            this.chkRecebidas.AutoSize = true;
            this.chkRecebidas.Location = new System.Drawing.Point(174, 34);
            this.chkRecebidas.Name = "chkRecebidas";
            this.chkRecebidas.Size = new System.Drawing.Size(77, 17);
            this.chkRecebidas.TabIndex = 4;
            this.chkRecebidas.Text = "Recebidas";
            this.chkRecebidas.UseVisualStyleBackColor = true;
            this.chkRecebidas.CheckedChanged += new System.EventHandler(this.chkRecebidas_CheckedChanged);
            // 
            // chkRecebidasParcial
            // 
            this.chkRecebidasParcial.AutoSize = true;
            this.chkRecebidasParcial.Location = new System.Drawing.Point(174, 15);
            this.chkRecebidasParcial.Name = "chkRecebidasParcial";
            this.chkRecebidasParcial.Size = new System.Drawing.Size(141, 17);
            this.chkRecebidasParcial.TabIndex = 3;
            this.chkRecebidasParcial.Text = "Recebidas Parcialmente";
            this.chkRecebidasParcial.UseVisualStyleBackColor = true;
            this.chkRecebidasParcial.CheckedChanged += new System.EventHandler(this.chkRecebidasParcial_CheckedChanged);
            // 
            // chkCompradas
            // 
            this.chkCompradas.AutoSize = true;
            this.chkCompradas.Location = new System.Drawing.Point(18, 54);
            this.chkCompradas.Name = "chkCompradas";
            this.chkCompradas.Size = new System.Drawing.Size(79, 17);
            this.chkCompradas.TabIndex = 2;
            this.chkCompradas.Text = "Compradas";
            this.chkCompradas.UseVisualStyleBackColor = true;
            this.chkCompradas.CheckedChanged += new System.EventHandler(this.chkCompradas_CheckedChanged);
            // 
            // chkNovas
            // 
            this.chkNovas.AutoSize = true;
            this.chkNovas.Checked = true;
            this.chkNovas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNovas.Location = new System.Drawing.Point(18, 34);
            this.chkNovas.Name = "chkNovas";
            this.chkNovas.Size = new System.Drawing.Size(93, 17);
            this.chkNovas.TabIndex = 1;
            this.chkNovas.Text = "Não Enviadas";
            this.chkNovas.UseVisualStyleBackColor = true;
            this.chkNovas.CheckedChanged += new System.EventHandler(this.chkNovas_CheckedChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(663, 78);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 23);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVisualizar.Location = new System.Drawing.Point(749, 54);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(86, 23);
            this.btnVisualizar.TabIndex = 8;
            this.btnVisualizar.Text = "Visualizar";
            this.btnVisualizar.UseVisualStyleBackColor = true;
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
            // 
            // txtBusca
            // 
            this.txtBusca.Location = new System.Drawing.Point(58, 28);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(177, 20);
            this.txtBusca.TabIndex = 0;
            this.txtBusca.TextChanged += new System.EventHandler(this.txtBusca_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Busca";
            // 
            // btnExcluir
            // 
            this.btnExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcluir.Location = new System.Drawing.Point(749, 78);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(86, 23);
            this.btnExcluir.TabIndex = 10;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNovo.Location = new System.Drawing.Point(663, 6);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(172, 23);
            this.btnNovo.TabIndex = 4;
            this.btnNovo.Text = "Gerar Nova OC";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // timerBusca
            // 
            this.timerBusca.Tick += new System.EventHandler(this.timerBusca_Tick);
            // 
            // OCListForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(847, 382);
            this.Controls.Add(this.splitContainer1);
            this.Name = "OCListForm";
            this.Text = "Ordens de Compra";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIdOC)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Timer timerBusca;
        private System.Windows.Forms.Button btnVisualizar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkCanceladas;
        private System.Windows.Forms.CheckBox chkRecebidas;
        private System.Windows.Forms.CheckBox chkRecebidasParcial;
        private System.Windows.Forms.CheckBox chkCompradas;
        private System.Windows.Forms.CheckBox chkNovas;
        private System.Windows.Forms.CheckBox chkIdOC;
        private System.Windows.Forms.NumericUpDown nudIdOC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.CheckBox chkAguardandoAprovacao;
    }
}