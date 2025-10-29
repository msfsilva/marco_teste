namespace BibliotecaEntidades.Operacoes.Estoque
{
    partial class EnviaItemEstoqueForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblItemEstoque = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblLocalAtual = new System.Windows.Forms.Label();
            this.lblLocalEstoque = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.nudQuantidade = new System.Windows.Forms.NumericUpDown();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.lblObservacoes = new System.Windows.Forms.Label();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.dgvGaveta = new System.Windows.Forms.DataGridView();
            this.dgvPrateleira = new System.Windows.Forms.DataGridView();
            this.dgvCorredor = new System.Windows.Forms.DataGridView();
            this.dgvEstoque = new System.Windows.Forms.DataGridView();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.lblBusca = new System.Windows.Forms.Label();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnAvancar = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblUnidade = new System.Windows.Forms.Label();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGaveta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrateleira)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCorredor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstoque)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item a ser enviado para o Estoque:";
            // 
            // lblItemEstoque
            // 
            this.lblItemEstoque.AutoSize = true;
            this.lblItemEstoque.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemEstoque.Location = new System.Drawing.Point(181, 9);
            this.lblItemEstoque.Name = "lblItemEstoque";
            this.lblItemEstoque.Size = new System.Drawing.Size(0, 13);
            this.lblItemEstoque.TabIndex = 1;
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
            this.splitContainer1.Panel1.Controls.Add(this.lblLocalAtual);
            this.splitContainer1.Panel1.Controls.Add(this.lblLocalEstoque);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.lblItemEstoque);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(742, 448);
            this.splitContainer1.SplitterDistance = 88;
            this.splitContainer1.TabIndex = 2;
            // 
            // lblLocalAtual
            // 
            this.lblLocalAtual.AutoSize = true;
            this.lblLocalAtual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalAtual.Location = new System.Drawing.Point(3, 64);
            this.lblLocalAtual.Name = "lblLocalAtual";
            this.lblLocalAtual.Size = new System.Drawing.Size(152, 16);
            this.lblLocalAtual.TabIndex = 4;
            this.lblLocalAtual.Text = "Selecione o Estoque";
            // 
            // lblLocalEstoque
            // 
            this.lblLocalEstoque.AutoSize = true;
            this.lblLocalEstoque.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalEstoque.Location = new System.Drawing.Point(124, 38);
            this.lblLocalEstoque.Name = "lblLocalEstoque";
            this.lblLocalEstoque.Size = new System.Drawing.Size(0, 13);
            this.lblLocalEstoque.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Local Selecionado";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnVoltar);
            this.splitContainer2.Panel2.Controls.Add(this.btnAvancar);
            this.splitContainer2.Size = new System.Drawing.Size(742, 356);
            this.splitContainer2.SplitterDistance = 292;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.lblUnidade);
            this.splitContainer3.Panel1.Controls.Add(this.nudQuantidade);
            this.splitContainer3.Panel1.Controls.Add(this.lblQuantidade);
            this.splitContainer3.Panel1.Controls.Add(this.lblObservacoes);
            this.splitContainer3.Panel1.Controls.Add(this.txtObservacao);
            this.splitContainer3.Panel1.Controls.Add(this.dgvGaveta);
            this.splitContainer3.Panel1.Controls.Add(this.dgvPrateleira);
            this.splitContainer3.Panel1.Controls.Add(this.dgvCorredor);
            this.splitContainer3.Panel1.Controls.Add(this.dgvEstoque);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.txtBusca);
            this.splitContainer3.Panel2.Controls.Add(this.lblBusca);
            this.splitContainer3.Size = new System.Drawing.Size(742, 292);
            this.splitContainer3.SplitterDistance = 254;
            this.splitContainer3.TabIndex = 0;
            // 
            // nudQuantidade
            // 
            this.nudQuantidade.DecimalPlaces = 4;
            this.nudQuantidade.Location = new System.Drawing.Point(15, 134);
            this.nudQuantidade.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudQuantidade.Name = "nudQuantidade";
            this.nudQuantidade.Size = new System.Drawing.Size(120, 20);
            this.nudQuantidade.TabIndex = 7;
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Location = new System.Drawing.Point(9, 118);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(62, 13);
            this.lblQuantidade.TabIndex = 6;
            this.lblQuantidade.Text = "Quantidade";
            // 
            // lblObservacoes
            // 
            this.lblObservacoes.AutoSize = true;
            this.lblObservacoes.Location = new System.Drawing.Point(12, 20);
            this.lblObservacoes.Name = "lblObservacoes";
            this.lblObservacoes.Size = new System.Drawing.Size(70, 13);
            this.lblObservacoes.TabIndex = 5;
            this.lblObservacoes.Text = "Observações";
            // 
            // txtObservacao
            // 
            this.txtObservacao.Location = new System.Drawing.Point(15, 36);
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(343, 69);
            this.txtObservacao.TabIndex = 4;
            // 
            // dgvGaveta
            // 
            this.dgvGaveta.AllowUserToAddRows = false;
            this.dgvGaveta.AllowUserToDeleteRows = false;
            this.dgvGaveta.AllowUserToOrderColumns = true;
            this.dgvGaveta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGaveta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGaveta.Location = new System.Drawing.Point(0, 0);
            this.dgvGaveta.Name = "dgvGaveta";
            this.dgvGaveta.ReadOnly = true;
            this.dgvGaveta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGaveta.Size = new System.Drawing.Size(742, 254);
            this.dgvGaveta.TabIndex = 3;
            this.dgvGaveta.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvGaveta_CellMouseDoubleClick);
            // 
            // dgvPrateleira
            // 
            this.dgvPrateleira.AllowUserToAddRows = false;
            this.dgvPrateleira.AllowUserToDeleteRows = false;
            this.dgvPrateleira.AllowUserToOrderColumns = true;
            this.dgvPrateleira.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrateleira.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPrateleira.Location = new System.Drawing.Point(0, 0);
            this.dgvPrateleira.Name = "dgvPrateleira";
            this.dgvPrateleira.ReadOnly = true;
            this.dgvPrateleira.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrateleira.Size = new System.Drawing.Size(742, 254);
            this.dgvPrateleira.TabIndex = 2;
            this.dgvPrateleira.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPrateleira_CellMouseDoubleClick);
            // 
            // dgvCorredor
            // 
            this.dgvCorredor.AllowUserToAddRows = false;
            this.dgvCorredor.AllowUserToDeleteRows = false;
            this.dgvCorredor.AllowUserToOrderColumns = true;
            this.dgvCorredor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCorredor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCorredor.Location = new System.Drawing.Point(0, 0);
            this.dgvCorredor.Name = "dgvCorredor";
            this.dgvCorredor.ReadOnly = true;
            this.dgvCorredor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCorredor.Size = new System.Drawing.Size(742, 254);
            this.dgvCorredor.TabIndex = 1;
            this.dgvCorredor.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCorredor_CellMouseDoubleClick);
            // 
            // dgvEstoque
            // 
            this.dgvEstoque.AllowUserToAddRows = false;
            this.dgvEstoque.AllowUserToDeleteRows = false;
            this.dgvEstoque.AllowUserToOrderColumns = true;
            this.dgvEstoque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstoque.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEstoque.Location = new System.Drawing.Point(0, 0);
            this.dgvEstoque.Name = "dgvEstoque";
            this.dgvEstoque.ReadOnly = true;
            this.dgvEstoque.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEstoque.Size = new System.Drawing.Size(742, 254);
            this.dgvEstoque.TabIndex = 0;
            this.dgvEstoque.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvEstoque_CellMouseDoubleClick);
            // 
            // txtBusca
            // 
            this.txtBusca.Location = new System.Drawing.Point(55, 8);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(299, 20);
            this.txtBusca.TabIndex = 1;
            this.txtBusca.TextChanged += new System.EventHandler(this.txtBusca_TextChanged);
            // 
            // lblBusca
            // 
            this.lblBusca.AutoSize = true;
            this.lblBusca.Location = new System.Drawing.Point(12, 11);
            this.lblBusca.Name = "lblBusca";
            this.lblBusca.Size = new System.Drawing.Size(37, 13);
            this.lblBusca.TabIndex = 0;
            this.lblBusca.Text = "Busca";
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(12, 19);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(75, 23);
            this.btnVoltar.TabIndex = 1;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnAvancar
            // 
            this.btnAvancar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAvancar.Location = new System.Drawing.Point(655, 19);
            this.btnAvancar.Name = "btnAvancar";
            this.btnAvancar.Size = new System.Drawing.Size(75, 23);
            this.btnAvancar.TabIndex = 0;
            this.btnAvancar.Text = "Continuar";
            this.btnAvancar.UseVisualStyleBackColor = true;
            this.btnAvancar.Click += new System.EventHandler(this.btnAvancar_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblUnidade
            // 
            this.lblUnidade.AutoSize = true;
            this.lblUnidade.Location = new System.Drawing.Point(141, 136);
            this.lblUnidade.Name = "lblUnidade";
            this.lblUnidade.Size = new System.Drawing.Size(0, 13);
            this.lblUnidade.TabIndex = 8;
            // 
            // EnviaItemEstoqueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(742, 448);
            this.Controls.Add(this.splitContainer1);
            this.Name = "EnviaItemEstoqueForm";
            this.Text = "Enviar Item para o Estoque";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGaveta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrateleira)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCorredor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstoque)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblItemEstoque;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblLocalEstoque;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnAvancar;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.Label lblBusca;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridView dgvGaveta;
        private System.Windows.Forms.DataGridView dgvPrateleira;
        private System.Windows.Forms.DataGridView dgvCorredor;
        private System.Windows.Forms.DataGridView dgvEstoque;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.Label lblObservacoes;
        private System.Windows.Forms.Label lblLocalAtual;
        private System.Windows.Forms.NumericUpDown nudQuantidade;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.Label lblUnidade;
    }
}