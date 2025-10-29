namespace BibliotecaTelasOP
{
    partial class CadPrecosItensVariaveisListForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtProdutoClassificacao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rdbSemPreco = new System.Windows.Forms.RadioButton();
            this.rdbNormais = new System.Windows.Forms.RadioButton();
            this.rdbAntigos = new System.Windows.Forms.RadioButton();
            this.rdbTodos = new System.Windows.Forms.RadioButton();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.txtPos = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPedido = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkNaoEncerrados = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
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
            this.dataGridView1.Size = new System.Drawing.Size(654, 239);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
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
            this.splitContainer1.Panel2.Controls.Add(this.chkNaoEncerrados);
            this.splitContainer1.Panel2.Controls.Add(this.txtProdutoClassificacao);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.rdbSemPreco);
            this.splitContainer1.Panel2.Controls.Add(this.rdbNormais);
            this.splitContainer1.Panel2.Controls.Add(this.rdbAntigos);
            this.splitContainer1.Panel2.Controls.Add(this.rdbTodos);
            this.splitContainer1.Panel2.Controls.Add(this.btnExcluir);
            this.splitContainer1.Panel2.Controls.Add(this.btnEditar);
            this.splitContainer1.Panel2.Controls.Add(this.btnNovo);
            this.splitContainer1.Panel2.Controls.Add(this.txtPos);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.txtPedido);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(654, 354);
            this.splitContainer1.SplitterDistance = 239;
            this.splitContainer1.TabIndex = 2;
            // 
            // txtProdutoClassificacao
            // 
            this.txtProdutoClassificacao.Location = new System.Drawing.Point(123, 37);
            this.txtProdutoClassificacao.Name = "txtProdutoClassificacao";
            this.txtProdutoClassificacao.Size = new System.Drawing.Size(253, 20);
            this.txtProdutoClassificacao.TabIndex = 15;
            this.txtProdutoClassificacao.TextChanged += new System.EventHandler(this.txtProdutoClassificacao_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Produto/Classificação";
            // 
            // rdbSemPreco
            // 
            this.rdbSemPreco.AutoSize = true;
            this.rdbSemPreco.Location = new System.Drawing.Point(199, 67);
            this.rdbSemPreco.Name = "rdbSemPreco";
            this.rdbSemPreco.Size = new System.Drawing.Size(77, 17);
            this.rdbSemPreco.TabIndex = 13;
            this.rdbSemPreco.Text = "Sem Preço";
            this.rdbSemPreco.UseVisualStyleBackColor = true;
            this.rdbSemPreco.CheckedChanged += new System.EventHandler(this.rdbSemPreco_CheckedChanged);
            // 
            // rdbNormais
            // 
            this.rdbNormais.AutoSize = true;
            this.rdbNormais.Location = new System.Drawing.Point(134, 65);
            this.rdbNormais.Name = "rdbNormais";
            this.rdbNormais.Size = new System.Drawing.Size(63, 17);
            this.rdbNormais.TabIndex = 12;
            this.rdbNormais.Text = "Normais";
            this.rdbNormais.UseVisualStyleBackColor = true;
            this.rdbNormais.CheckedChanged += new System.EventHandler(this.rdbNormais_CheckedChanged);
            // 
            // rdbAntigos
            // 
            this.rdbAntigos.AutoSize = true;
            this.rdbAntigos.Location = new System.Drawing.Point(73, 65);
            this.rdbAntigos.Name = "rdbAntigos";
            this.rdbAntigos.Size = new System.Drawing.Size(60, 17);
            this.rdbAntigos.TabIndex = 11;
            this.rdbAntigos.Text = "Antigos";
            this.rdbAntigos.UseVisualStyleBackColor = true;
            this.rdbAntigos.CheckedChanged += new System.EventHandler(this.rdbAntigos_CheckedChanged);
            // 
            // rdbTodos
            // 
            this.rdbTodos.AutoSize = true;
            this.rdbTodos.Location = new System.Drawing.Point(12, 65);
            this.rdbTodos.Name = "rdbTodos";
            this.rdbTodos.Size = new System.Drawing.Size(55, 17);
            this.rdbTodos.TabIndex = 10;
            this.rdbTodos.Text = "Todos";
            this.rdbTodos.UseVisualStyleBackColor = true;
            this.rdbTodos.CheckedChanged += new System.EventHandler(this.rdbTodos_CheckedChanged);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcluir.Location = new System.Drawing.Point(566, 48);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 9;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.Location = new System.Drawing.Point(485, 48);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 8;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNovo.Location = new System.Drawing.Point(404, 48);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 23);
            this.btnNovo.TabIndex = 7;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // txtPos
            // 
            this.txtPos.Location = new System.Drawing.Point(229, 11);
            this.txtPos.Name = "txtPos";
            this.txtPos.Size = new System.Drawing.Size(32, 20);
            this.txtPos.TabIndex = 4;
            this.txtPos.TextChanged += new System.EventHandler(this.txtPos_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "/";
            // 
            // txtPedido
            // 
            this.txtPedido.Location = new System.Drawing.Point(123, 11);
            this.txtPedido.Name = "txtPedido";
            this.txtPedido.Size = new System.Drawing.Size(82, 20);
            this.txtPedido.TabIndex = 2;
            this.txtPedido.TextChanged += new System.EventHandler(this.txtPedido_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pedido";
            // 
            // chkNaoEncerrados
            // 
            this.chkNaoEncerrados.AutoSize = true;
            this.chkNaoEncerrados.Checked = true;
            this.chkNaoEncerrados.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNaoEncerrados.Location = new System.Drawing.Point(12, 88);
            this.chkNaoEncerrados.Name = "chkNaoEncerrados";
            this.chkNaoEncerrados.Size = new System.Drawing.Size(189, 17);
            this.chkNaoEncerrados.TabIndex = 16;
            this.chkNaoEncerrados.Text = "Somente Pedidos Não Encerrados";
            this.chkNaoEncerrados.UseVisualStyleBackColor = true;
            this.chkNaoEncerrados.CheckedChanged += new System.EventHandler(this.chkNaoEncerrados_CheckedChanged);
            // 
            // CadPrecosItensVariaveisListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(654, 354);
            this.Controls.Add(this.splitContainer1);
            this.Name = "CadPrecosItensVariaveisListForm";
            this.Text = "Tabela de Preços de Pedidos";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtPos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPedido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.RadioButton rdbSemPreco;
        private System.Windows.Forms.RadioButton rdbNormais;
        private System.Windows.Forms.RadioButton rdbAntigos;
        private System.Windows.Forms.RadioButton rdbTodos;
        private System.Windows.Forms.TextBox txtProdutoClassificacao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkNaoEncerrados;
    }
}